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
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuitemww : GXDataArea
   {
      public menuitemww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuitemww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_MenuItemFatherId )
      {
         this.AV57MenuItemFatherId = aP0_MenuItemFatherId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMenuItemType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "MenuItemFatherId");
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
               gxfirstwebparm = GetFirstPar( "MenuItemFatherId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "MenuItemFatherId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_18 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_18"), "."));
               nGXsfl_18_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_18_idx"), "."));
               sGXsfl_18_idx = GetPar( "sGXsfl_18_idx");
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
               AV57MenuItemFatherId = (short)(NumberUtil.Val( GetPar( "MenuItemFatherId"), "."));
               AV132Pgmname = GetPar( "Pgmname");
               AV127TFMenuItemOrder = (short)(NumberUtil.Val( GetPar( "TFMenuItemOrder"), "."));
               AV128TFMenuItemOrder_To = (short)(NumberUtil.Val( GetPar( "TFMenuItemOrder_To"), "."));
               AV80TFMenuItemCaption = GetPar( "TFMenuItemCaption");
               AV81TFMenuItemCaption_Sel = GetPar( "TFMenuItemCaption_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV118TFMenuItemType_Sels);
               AV105TFMenuItemFatherCaption = GetPar( "TFMenuItemFatherCaption");
               AV106TFMenuItemFatherCaption_Sel = GetPar( "TFMenuItemFatherCaption_Sel");
               AV68OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV70OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV57MenuItemFatherId, AV132Pgmname, AV127TFMenuItemOrder, AV128TFMenuItemOrder_To, AV80TFMenuItemCaption, AV81TFMenuItemCaption_Sel, AV118TFMenuItemType_Sels, AV105TFMenuItemFatherCaption, AV106TFMenuItemFatherCaption_Sel, AV68OrderedBy, AV70OrderedDsc) ;
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
         PA0L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0L2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810275758", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/yahoo.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/event.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/treeview.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/dom.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/yahoo-dom-event.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/dragdrop.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/DDSend.js", "", false, true);
         context.AddJavascriptSource("Treeview/TreeviewRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.menuitemww.aspx"+UrlEncode(StringUtil.LTrimStr(AV57MenuItemFatherId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.menuitemww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV132Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMFATHERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV57MenuItemFatherId), "ZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV126GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTREENODECOLLECTIONDATA", AV96treeNodeCollectionData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTREENODECOLLECTIONDATA", AV96treeNodeCollectionData);
         }
         GxWebStd.gx_hidden_field( context, "vSELECTEDTREENODE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75selectedTreeNode), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMENUITEMFATHERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57MenuItemFatherId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMFATHERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV57MenuItemFatherId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV132Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV132Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFMENUITEMORDER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV127TFMenuItemOrder), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFMENUITEMORDER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV128TFMenuItemOrder_To), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFMENUITEMCAPTION", AV80TFMenuItemCaption);
         GxWebStd.gx_hidden_field( context, "vTFMENUITEMCAPTION_SEL", AV81TFMenuItemCaption_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMENUITEMTYPE_SELS", AV118TFMenuItemType_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMENUITEMTYPE_SELS", AV118TFMenuItemType_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFMENUITEMFATHERCAPTION", AV105TFMenuItemFatherCaption);
         GxWebStd.gx_hidden_field( context, "vTFMENUITEMFATHERCAPTION_SEL", AV106TFMenuItemFatherCaption_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV70OrderedDsc);
         GxWebStd.gx_hidden_field( context, "MENUITEMFATHERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A353MenuItemFatherId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "UTTREEVIEW_Style", StringUtil.RTrim( Uttreeview_Style));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE0L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0L2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.menuitemww.aspx"+UrlEncode(StringUtil.LTrimStr(AV57MenuItemFatherId,4,0));
         return formatLink("wwpbaseobjects.menuitemww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.MenuItemWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Menu Item" ;
      }

      protected void WB0L0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"18\">") ;
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAddmenu_Class+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUpdate_Class+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDelete_Class+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Item Order") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Caption") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Type") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Inside Menu") ;
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
               GridColumn.AddObjectProperty("Value", context.convertURL( AV124AddMenu));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAddmenu_Class));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavAddmenu_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavAddmenu_Tooltiptext));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV99Update));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUpdate_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV24Delete));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDelete_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1229MenuItemOrder), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A352MenuItemId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1222MenuItemCaption);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMenuItemCaption_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1232MenuItemType), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A1223MenuItemFatherCaption);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMenuItemFatherCaption_Link));
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
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            nRC_GXsfl_18 = (int)(nGXsfl_18_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV37GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV126GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedsection2_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUttreeview.SetProperty("Style", Uttreeview_Style);
            ucUttreeview.SetProperty("TreeNodeCollectionData", AV96treeNodeCollectionData);
            ucUttreeview.SetProperty("SelectedTreeNode", AV75selectedTreeNode);
            ucUttreeview.Render(context, "treeview", Uttreeview_Internalname, "UTTREEVIEWContainer");
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
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
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
         if ( wbEnd == 18 )
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

      protected void START0L2( )
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
            Form.Meta.addItem("description", " Menu Item", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0L0( ) ;
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
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
                              E110L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E120L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130L2 ();
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
                              nGXsfl_18_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              AV124AddMenu = cgiGet( edtavAddmenu_Internalname);
                              AssignProp("", false, edtavAddmenu_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV124AddMenu)) ? AV140Addmenu_GXI : context.convertURL( context.PathToRelativeUrl( AV124AddMenu))), !bGXsfl_18_Refreshing);
                              AssignProp("", false, edtavAddmenu_Internalname, "SrcSet", context.GetImageSrcSet( AV124AddMenu), true);
                              AV99Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV99Update);
                              AV24Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV24Delete);
                              A1229MenuItemOrder = (short)(context.localUtil.CToN( cgiGet( edtMenuItemOrder_Internalname), ".", ","));
                              A352MenuItemId = (short)(context.localUtil.CToN( cgiGet( edtMenuItemId_Internalname), ".", ","));
                              A1222MenuItemCaption = cgiGet( edtMenuItemCaption_Internalname);
                              cmbMenuItemType.Name = cmbMenuItemType_Internalname;
                              cmbMenuItemType.CurrentValue = cgiGet( cmbMenuItemType_Internalname);
                              A1232MenuItemType = (short)(NumberUtil.Val( cgiGet( cmbMenuItemType_Internalname), "."));
                              A1223MenuItemFatherCaption = cgiGet( edtMenuItemFatherCaption_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E140L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E150L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E160L2 ();
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

      protected void WE0L2( )
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

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.menuitemww.aspx")), "wwpbaseobjects.menuitemww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.menuitemww.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "MenuItemFatherId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV57MenuItemFatherId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
                     AssignAttri("", false, "AV57MenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV57MenuItemFatherId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMFATHERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV57MenuItemFatherId), "ZZZ9"), context));
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
         SubsflControlProps_182( ) ;
         while ( nGXsfl_18_idx <= nRC_GXsfl_18 )
         {
            sendrow_182( ) ;
            nGXsfl_18_idx = ((subGrid_Islastpage==1)&&(nGXsfl_18_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV57MenuItemFatherId ,
                                       string AV132Pgmname ,
                                       short AV127TFMenuItemOrder ,
                                       short AV128TFMenuItemOrder_To ,
                                       string AV80TFMenuItemCaption ,
                                       string AV81TFMenuItemCaption_Sel ,
                                       GxSimpleCollection<short> AV118TFMenuItemType_Sels ,
                                       string AV105TFMenuItemFatherCaption ,
                                       string AV106TFMenuItemFatherCaption_Sel ,
                                       short AV68OrderedBy ,
                                       bool AV70OrderedDsc )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E150L2 ();
         GRID_nCurrentRecord = 0;
         RF0L2( ) ;
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
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV132Pgmname = "WWPBaseObjects.MenuItemWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_18_Refreshing);
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 18;
         /* Execute user event: Refresh */
         E150L2 ();
         nGXsfl_18_idx = 1;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         bGXsfl_18_Refreshing = true;
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
            SubsflControlProps_182( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A352MenuItemId ,
                                                 AV122MenuItemIdCollection ,
                                                 A1232MenuItemType ,
                                                 AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                                 AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                                 AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                                 AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                                 AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                                 AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels.Count ,
                                                 AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                                 AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                                 A1229MenuItemOrder ,
                                                 A1222MenuItemCaption ,
                                                 A1223MenuItemFatherCaption ,
                                                 AV68OrderedBy ,
                                                 AV70OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = StringUtil.Concat( StringUtil.RTrim( AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption), "%", "");
            lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = StringUtil.Concat( StringUtil.RTrim( AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption), "%", "");
            /* Using cursor H000L2 */
            pr_default.execute(0, new Object[] {AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder, AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to, lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption, AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel, lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption, AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_18_idx = 1;
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A353MenuItemFatherId = H000L2_A353MenuItemFatherId[0];
               n353MenuItemFatherId = H000L2_n353MenuItemFatherId[0];
               A1223MenuItemFatherCaption = H000L2_A1223MenuItemFatherCaption[0];
               A1232MenuItemType = H000L2_A1232MenuItemType[0];
               A1222MenuItemCaption = H000L2_A1222MenuItemCaption[0];
               A352MenuItemId = H000L2_A352MenuItemId[0];
               A1229MenuItemOrder = H000L2_A1229MenuItemOrder[0];
               A1223MenuItemFatherCaption = H000L2_A1223MenuItemFatherCaption[0];
               E160L2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 18;
            WB0L0( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV132Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV132Pgmname, "")), context));
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
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A352MenuItemId ,
                                              AV122MenuItemIdCollection ,
                                              A1232MenuItemType ,
                                              AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                              AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                              AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                              AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                              AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                              AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels.Count ,
                                              AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                              AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                              A1229MenuItemOrder ,
                                              A1222MenuItemCaption ,
                                              A1223MenuItemFatherCaption ,
                                              AV68OrderedBy ,
                                              AV70OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = StringUtil.Concat( StringUtil.RTrim( AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption), "%", "");
         lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = StringUtil.Concat( StringUtil.RTrim( AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption), "%", "");
         /* Using cursor H000L3 */
         pr_default.execute(1, new Object[] {AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder, AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to, lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption, AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel, lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption, AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel});
         GRID_nRecordCount = H000L3_AGRID_nRecordCount[0];
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
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV57MenuItemFatherId, AV132Pgmname, AV127TFMenuItemOrder, AV128TFMenuItemOrder_To, AV80TFMenuItemCaption, AV81TFMenuItemCaption_Sel, AV118TFMenuItemType_Sels, AV105TFMenuItemFatherCaption, AV106TFMenuItemFatherCaption_Sel, AV68OrderedBy, AV70OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV57MenuItemFatherId, AV132Pgmname, AV127TFMenuItemOrder, AV128TFMenuItemOrder_To, AV80TFMenuItemCaption, AV81TFMenuItemCaption_Sel, AV118TFMenuItemType_Sels, AV105TFMenuItemFatherCaption, AV106TFMenuItemFatherCaption_Sel, AV68OrderedBy, AV70OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV57MenuItemFatherId, AV132Pgmname, AV127TFMenuItemOrder, AV128TFMenuItemOrder_To, AV80TFMenuItemCaption, AV81TFMenuItemCaption_Sel, AV118TFMenuItemType_Sels, AV105TFMenuItemFatherCaption, AV106TFMenuItemFatherCaption_Sel, AV68OrderedBy, AV70OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV57MenuItemFatherId, AV132Pgmname, AV127TFMenuItemOrder, AV128TFMenuItemOrder_To, AV80TFMenuItemCaption, AV81TFMenuItemCaption_Sel, AV118TFMenuItemType_Sels, AV105TFMenuItemFatherCaption, AV106TFMenuItemFatherCaption_Sel, AV68OrderedBy, AV70OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV57MenuItemFatherId, AV132Pgmname, AV127TFMenuItemOrder, AV128TFMenuItemOrder_To, AV80TFMenuItemCaption, AV81TFMenuItemCaption_Sel, AV118TFMenuItemType_Sels, AV105TFMenuItemFatherCaption, AV106TFMenuItemFatherCaption_Sel, AV68OrderedBy, AV70OrderedDsc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV132Pgmname = "WWPBaseObjects.MenuItemWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E140L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTREENODECOLLECTIONDATA"), AV96treeNodeCollectionData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV23DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_18"), ".", ","));
            AV37GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV39GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV126GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV75selectedTreeNode = (short)(context.localUtil.CToN( cgiGet( "vSELECTEDTREENODE"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Uttreeview_Style = cgiGet( "UTTREEVIEW_Style");
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
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            /* Read variables values. */
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
         E140L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E140L2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Menu Item";
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
         if ( AV68OrderedBy < 1 )
         {
            AV68OrderedBy = 1;
            AssignAttri("", false, "AV68OrderedBy", StringUtil.LTrimStr( (decimal)(AV68OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV23DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV23DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         if ( StringUtil.StrCmp(AV43HTTPRequest.Method, "GET") == 0 )
         {
            /* Using cursor H000L4 */
            pr_default.execute(2, new Object[] {AV57MenuItemFatherId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A352MenuItemId = H000L4_A352MenuItemId[0];
               A1222MenuItemCaption = H000L4_A1222MenuItemCaption[0];
               Form.Caption = "Items of Menu :: "+A1222MenuItemCaption;
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void E150L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV122MenuItemIdCollection.Clear();
         GXt_objcol_int2 = AV122MenuItemIdCollection;
         new GeneXus.Programs.wwpbaseobjects.getmenuitemids(context ).execute(  AV57MenuItemFatherId, out  GXt_objcol_int2) ;
         AV122MenuItemIdCollection = GXt_objcol_int2;
         AV122MenuItemIdCollection.Add(AV57MenuItemFatherId, 0);
         GXt_objcol_SdtTreeNodeCollection_TreeNode3 = AV96treeNodeCollectionData;
         new GeneXus.Programs.wwpbaseobjects.loadmenutreeview(context ).execute(  AV57MenuItemFatherId, out  GXt_objcol_SdtTreeNodeCollection_TreeNode3) ;
         AV96treeNodeCollectionData = GXt_objcol_SdtTreeNodeCollection_TreeNode3;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV102WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV37GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV37GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV37GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char4 = AV126GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV132Pgmname, out  GXt_char4) ;
         AV126GridAppliedFilters = GXt_char4;
         AssignAttri("", false, "AV126GridAppliedFilters", AV126GridAppliedFilters);
         AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV127TFMenuItemOrder;
         AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV128TFMenuItemOrder_To;
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV80TFMenuItemCaption;
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV81TFMenuItemCaption_Sel;
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV118TFMenuItemType_Sels;
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV105TFMenuItemFatherCaption;
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV106TFMenuItemFatherCaption_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV96treeNodeCollectionData", AV96treeNodeCollectionData);
      }

      protected void E110L2( )
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
            AV71PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV71PageToGo) ;
         }
      }

      protected void E120L2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E130L2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV68OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
            AssignAttri("", false, "AV68OrderedBy", StringUtil.LTrimStr( (decimal)(AV68OrderedBy), 4, 0));
            AV70OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV70OrderedDsc", AV70OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MenuItemOrder") == 0 )
            {
               AV127TFMenuItemOrder = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV127TFMenuItemOrder", StringUtil.LTrimStr( (decimal)(AV127TFMenuItemOrder), 4, 0));
               AV128TFMenuItemOrder_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV128TFMenuItemOrder_To", StringUtil.LTrimStr( (decimal)(AV128TFMenuItemOrder_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MenuItemCaption") == 0 )
            {
               AV80TFMenuItemCaption = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV80TFMenuItemCaption", AV80TFMenuItemCaption);
               AV81TFMenuItemCaption_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV81TFMenuItemCaption_Sel", AV81TFMenuItemCaption_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MenuItemType") == 0 )
            {
               AV117TFMenuItemType_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV117TFMenuItemType_SelsJson", AV117TFMenuItemType_SelsJson);
               AV118TFMenuItemType_Sels.FromJSonString(StringUtil.StringReplace( AV117TFMenuItemType_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MenuItemFatherCaption") == 0 )
            {
               AV105TFMenuItemFatherCaption = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV105TFMenuItemFatherCaption", AV105TFMenuItemFatherCaption);
               AV106TFMenuItemFatherCaption_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV106TFMenuItemFatherCaption_Sel", AV106TFMenuItemFatherCaption_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV118TFMenuItemType_Sels", AV118TFMenuItemType_Sels);
      }

      private void E160L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV124AddMenu = context.GetImagePath( "7f618bea-47cd-4ba5-84d7-c430500a42e3", "", context.GetTheme( ));
         AssignAttri("", false, edtavAddmenu_Internalname, AV124AddMenu);
         AV140Addmenu_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7f618bea-47cd-4ba5-84d7-c430500a42e3", "", context.GetTheme( )));
         edtavAddmenu_Tooltiptext = "Add menu option";
         if ( A1232MenuItemType == 2 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(A352MenuItemId,4,0));
            edtavAddmenu_Link = formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavAddmenu_Class = "ActionBaseColorAttribute";
         }
         else
         {
            edtavAddmenu_Link = "";
            edtavAddmenu_Class = "Invisible";
         }
         AV99Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV99Update);
         if ( A353MenuItemFatherId > 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A352MenuItemId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV57MenuItemFatherId,4,0));
            edtavUpdate_Link = formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavUpdate_Class = "Attribute";
         }
         else
         {
            edtavUpdate_Link = "";
            edtavUpdate_Class = "Invisible";
         }
         AV24Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV24Delete);
         if ( A353MenuItemFatherId > 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A352MenuItemId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV57MenuItemFatherId,4,0));
            edtavDelete_Link = formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavDelete_Class = "Attribute";
         }
         else
         {
            edtavDelete_Link = "";
            edtavDelete_Class = "Invisible";
         }
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A352MenuItemId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV57MenuItemFatherId,4,0));
         edtMenuItemCaption_Link = formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A353MenuItemFatherId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV57MenuItemFatherId,4,0));
         edtMenuItemFatherCaption_Link = formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 18;
         }
         sendrow_182( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_18_Refreshing )
         {
            DoAjaxLoad(18, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV68OrderedBy), 4, 0))+":"+(AV70OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV76Session.Get(AV132Pgmname+"GridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV132Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV76Session.Get(AV132Pgmname+"GridState"), null, "", "");
         }
         AV68OrderedBy = AV40GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV68OrderedBy", StringUtil.LTrimStr( (decimal)(AV68OrderedBy), 4, 0));
         AV70OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV70OrderedDsc", AV70OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV141GXV1 = 1;
         while ( AV141GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV141GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMENUITEMORDER") == 0 )
            {
               AV127TFMenuItemOrder = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV127TFMenuItemOrder", StringUtil.LTrimStr( (decimal)(AV127TFMenuItemOrder), 4, 0));
               AV128TFMenuItemOrder_To = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV128TFMenuItemOrder_To", StringUtil.LTrimStr( (decimal)(AV128TFMenuItemOrder_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMENUITEMCAPTION") == 0 )
            {
               AV80TFMenuItemCaption = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFMenuItemCaption", AV80TFMenuItemCaption);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMENUITEMCAPTION_SEL") == 0 )
            {
               AV81TFMenuItemCaption_Sel = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFMenuItemCaption_Sel", AV81TFMenuItemCaption_Sel);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMENUITEMTYPE_SEL") == 0 )
            {
               AV117TFMenuItemType_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV117TFMenuItemType_SelsJson", AV117TFMenuItemType_SelsJson);
               AV118TFMenuItemType_Sels.FromJSonString(AV117TFMenuItemType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMENUITEMFATHERCAPTION") == 0 )
            {
               AV105TFMenuItemFatherCaption = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV105TFMenuItemFatherCaption", AV105TFMenuItemFatherCaption);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMENUITEMFATHERCAPTION_SEL") == 0 )
            {
               AV106TFMenuItemFatherCaption_Sel = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV106TFMenuItemFatherCaption_Sel", AV106TFMenuItemFatherCaption_Sel);
            }
            AV141GXV1 = (int)(AV141GXV1+1);
         }
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFMenuItemCaption_Sel)),  AV81TFMenuItemCaption_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV106TFMenuItemFatherCaption_Sel)),  AV106TFMenuItemFatherCaption_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char4+"|"+((AV118TFMenuItemType_Sels.Count==0) ? "" : AV117TFMenuItemType_SelsJson)+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFMenuItemCaption)),  AV80TFMenuItemCaption, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV105TFMenuItemFatherCaption)),  AV105TFMenuItemFatherCaption, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((0==AV127TFMenuItemOrder) ? "" : StringUtil.Str( (decimal)(AV127TFMenuItemOrder), 4, 0))+"|"+GXt_char5+"||"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV128TFMenuItemOrder_To) ? "" : StringUtil.Str( (decimal)(AV128TFMenuItemOrder_To), 4, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV40GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV40GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV40GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV40GridState.FromXml(AV76Session.Get(AV132Pgmname+"GridState"), null, "", "");
         AV40GridState.gxTpr_Orderedby = AV68OrderedBy;
         AV40GridState.gxTpr_Ordereddsc = AV70OrderedDsc;
         AV40GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV40GridState,  "TFMENUITEMORDER",  "Item Order",  !((0==AV127TFMenuItemOrder)&&(0==AV128TFMenuItemOrder_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV127TFMenuItemOrder), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV128TFMenuItemOrder_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV40GridState,  "TFMENUITEMCAPTION",  "Caption",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFMenuItemCaption)),  0,  AV80TFMenuItemCaption,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFMenuItemCaption_Sel)),  AV81TFMenuItemCaption_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV40GridState,  "TFMENUITEMTYPE_SEL",  "Type",  !(AV118TFMenuItemType_Sels.Count==0),  0,  AV118TFMenuItemType_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV40GridState,  "TFMENUITEMFATHERCAPTION",  "Inside Menu",  !String.IsNullOrEmpty(StringUtil.RTrim( AV105TFMenuItemFatherCaption)),  0,  AV105TFMenuItemFatherCaption,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV106TFMenuItemFatherCaption_Sel)),  AV106TFMenuItemFatherCaption_Sel,  "") ;
         if ( ! (0==AV57MenuItemFatherId) )
         {
            AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV42GridStateFilterValue.gxTpr_Name = "PARM_&MENUITEMFATHERID";
            AV42GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV57MenuItemFatherId), 4, 0);
            AV40GridState.gxTpr_Filtervalues.Add(AV42GridStateFilterValue, 0);
         }
         AV40GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV40GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV132Pgmname+"GridState",  AV40GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV97TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV97TrnContext.gxTpr_Callerobject = AV132Pgmname;
         AV97TrnContext.gxTpr_Callerondelete = true;
         AV97TrnContext.gxTpr_Callerurl = AV43HTTPRequest.ScriptName+"?"+AV43HTTPRequest.QueryString;
         AV97TrnContext.gxTpr_Transactionname = "WWPBaseObjects.MenuItem";
         AV76Session.Set("TrnContext", AV97TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV57MenuItemFatherId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV57MenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV57MenuItemFatherId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMFATHERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV57MenuItemFatherId), "ZZZ9"), context));
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181028136", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/menuitemww.js", "?20228181028137", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/yahoo.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/event.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/treeview.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/dom.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/yahoo-dom-event.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/dragdrop.js", "", false, true);
         context.AddJavascriptSource("Treeview/assets/js/DDSend.js", "", false, true);
         context.AddJavascriptSource("Treeview/TreeviewRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         edtavAddmenu_Internalname = "vADDMENU_"+sGXsfl_18_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_18_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_18_idx;
         edtMenuItemOrder_Internalname = "MENUITEMORDER_"+sGXsfl_18_idx;
         edtMenuItemId_Internalname = "MENUITEMID_"+sGXsfl_18_idx;
         edtMenuItemCaption_Internalname = "MENUITEMCAPTION_"+sGXsfl_18_idx;
         cmbMenuItemType_Internalname = "MENUITEMTYPE_"+sGXsfl_18_idx;
         edtMenuItemFatherCaption_Internalname = "MENUITEMFATHERCAPTION_"+sGXsfl_18_idx;
      }

      protected void SubsflControlProps_fel_182( )
      {
         edtavAddmenu_Internalname = "vADDMENU_"+sGXsfl_18_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_18_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_18_fel_idx;
         edtMenuItemOrder_Internalname = "MENUITEMORDER_"+sGXsfl_18_fel_idx;
         edtMenuItemId_Internalname = "MENUITEMID_"+sGXsfl_18_fel_idx;
         edtMenuItemCaption_Internalname = "MENUITEMCAPTION_"+sGXsfl_18_fel_idx;
         cmbMenuItemType_Internalname = "MENUITEMTYPE_"+sGXsfl_18_fel_idx;
         edtMenuItemFatherCaption_Internalname = "MENUITEMFATHERCAPTION_"+sGXsfl_18_fel_idx;
      }

      protected void sendrow_182( )
      {
         SubsflControlProps_182( ) ;
         WB0L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_18_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_18_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_18_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = edtavAddmenu_Class;
            StyleString = "";
            AV124AddMenu_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV124AddMenu))&&String.IsNullOrEmpty(StringUtil.RTrim( AV140Addmenu_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV124AddMenu)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV124AddMenu)) ? AV140Addmenu_GXI : context.PathToRelativeUrl( AV124AddMenu));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavAddmenu_Internalname,(string)sImgUrl,(string)edtavAddmenu_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavAddmenu_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV124AddMenu_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = edtavUpdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV99Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modificar",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)edtavUpdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)18,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = edtavDelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV24Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)edtavDelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)18,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMenuItemOrder_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1229MenuItemOrder), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1229MenuItemOrder), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMenuItemOrder_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMenuItemId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A352MenuItemId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A352MenuItemId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMenuItemId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMenuItemCaption_Internalname,(string)A1222MenuItemCaption,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMenuItemCaption_Link,(string)"",(string)"",(string)"",(string)edtMenuItemCaption_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbMenuItemType.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MENUITEMTYPE_" + sGXsfl_18_idx;
               cmbMenuItemType.Name = GXCCtl;
               cmbMenuItemType.WebTags = "";
               cmbMenuItemType.addItem("1", "Link Item", 0);
               cmbMenuItemType.addItem("2", "Menu", 0);
               if ( cmbMenuItemType.ItemCount > 0 )
               {
                  A1232MenuItemType = (short)(NumberUtil.Val( cmbMenuItemType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMenuItemType,(string)cmbMenuItemType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0)),(short)1,(string)cmbMenuItemType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbMenuItemType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
            AssignProp("", false, cmbMenuItemType_Internalname, "Values", (string)(cmbMenuItemType.ToJavascriptSource()), !bGXsfl_18_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMenuItemFatherCaption_Internalname,(string)A1223MenuItemFatherCaption,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMenuItemFatherCaption_Link,(string)"",(string)"",(string)"",(string)edtMenuItemFatherCaption_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)18,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_18_idx = ((subGrid_Islastpage==1)&&(nGXsfl_18_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         /* End function sendrow_182 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "MENUITEMTYPE_" + sGXsfl_18_idx;
         cmbMenuItemType.Name = GXCCtl;
         cmbMenuItemType.WebTags = "";
         cmbMenuItemType.addItem("1", "Link Item", 0);
         cmbMenuItemType.addItem("2", "Menu", 0);
         if ( cmbMenuItemType.ItemCount > 0 )
         {
            A1232MenuItemType = (short)(NumberUtil.Val( cmbMenuItemType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavAddmenu_Internalname = "vADDMENU";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtMenuItemOrder_Internalname = "MENUITEMORDER";
         edtMenuItemId_Internalname = "MENUITEMID";
         edtMenuItemCaption_Internalname = "MENUITEMCAPTION";
         cmbMenuItemType_Internalname = "MENUITEMTYPE";
         edtMenuItemFatherCaption_Internalname = "MENUITEMFATHERCAPTION";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Uttreeview_Internalname = "UTTREEVIEW";
         divUnnamedsection2_Internalname = "UNNAMEDSECTION2";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
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
         edtMenuItemFatherCaption_Jsonclick = "";
         cmbMenuItemType_Jsonclick = "";
         edtMenuItemCaption_Jsonclick = "";
         edtMenuItemId_Jsonclick = "";
         edtMenuItemOrder_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtMenuItemFatherCaption_Link = "";
         edtMenuItemCaption_Link = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavAddmenu_Tooltiptext = "Add menu option";
         edtavAddmenu_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Class = "Attribute";
         edtavUpdate_Class = "Attribute";
         edtavAddmenu_Class = "ActionBaseColorAttribute";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WWPBaseObjects.MenuItemWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:Link Item,2:Menu|";
         Ddo_grid_Allowmultipleselection = "||T|";
         Ddo_grid_Datalisttype = "|Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T";
         Ddo_grid_Filterisrange = "T|||";
         Ddo_grid_Filtertype = "Numeric|Character||Character";
         Ddo_grid_Includefilter = "T|T||T";
         Ddo_grid_Includesortasc = "T||T|T";
         Ddo_grid_Columnssortvalues = "1||2|3";
         Ddo_grid_Columnids = "3:MenuItemOrder|5:MenuItemCaption|6:MenuItemType|7:MenuItemFatherCaption";
         Ddo_grid_Gridinternalname = "";
         Uttreeview_Style = "Menu";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Menu Item";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9',hsh:true},{av:'AV132Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV127TFMenuItemOrder',fld:'vTFMENUITEMORDER',pic:'ZZZ9'},{av:'AV128TFMenuItemOrder_To',fld:'vTFMENUITEMORDER_TO',pic:'ZZZ9'},{av:'AV80TFMenuItemCaption',fld:'vTFMENUITEMCAPTION',pic:''},{av:'AV81TFMenuItemCaption_Sel',fld:'vTFMENUITEMCAPTION_SEL',pic:''},{av:'AV118TFMenuItemType_Sels',fld:'vTFMENUITEMTYPE_SELS',pic:''},{av:'AV105TFMenuItemFatherCaption',fld:'vTFMENUITEMFATHERCAPTION',pic:''},{av:'AV106TFMenuItemFatherCaption_Sel',fld:'vTFMENUITEMFATHERCAPTION_SEL',pic:''},{av:'AV68OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV70OrderedDsc',fld:'vORDEREDDSC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV96treeNodeCollectionData',fld:'vTREENODECOLLECTIONDATA',pic:''},{av:'AV37GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV126GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E110L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9',hsh:true},{av:'AV132Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV127TFMenuItemOrder',fld:'vTFMENUITEMORDER',pic:'ZZZ9'},{av:'AV128TFMenuItemOrder_To',fld:'vTFMENUITEMORDER_TO',pic:'ZZZ9'},{av:'AV80TFMenuItemCaption',fld:'vTFMENUITEMCAPTION',pic:''},{av:'AV81TFMenuItemCaption_Sel',fld:'vTFMENUITEMCAPTION_SEL',pic:''},{av:'AV118TFMenuItemType_Sels',fld:'vTFMENUITEMTYPE_SELS',pic:''},{av:'AV105TFMenuItemFatherCaption',fld:'vTFMENUITEMFATHERCAPTION',pic:''},{av:'AV106TFMenuItemFatherCaption_Sel',fld:'vTFMENUITEMFATHERCAPTION_SEL',pic:''},{av:'AV68OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV70OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E120L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9',hsh:true},{av:'AV132Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV127TFMenuItemOrder',fld:'vTFMENUITEMORDER',pic:'ZZZ9'},{av:'AV128TFMenuItemOrder_To',fld:'vTFMENUITEMORDER_TO',pic:'ZZZ9'},{av:'AV80TFMenuItemCaption',fld:'vTFMENUITEMCAPTION',pic:''},{av:'AV81TFMenuItemCaption_Sel',fld:'vTFMENUITEMCAPTION_SEL',pic:''},{av:'AV118TFMenuItemType_Sels',fld:'vTFMENUITEMTYPE_SELS',pic:''},{av:'AV105TFMenuItemFatherCaption',fld:'vTFMENUITEMFATHERCAPTION',pic:''},{av:'AV106TFMenuItemFatherCaption_Sel',fld:'vTFMENUITEMFATHERCAPTION_SEL',pic:''},{av:'AV68OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV70OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E130L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV57MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9',hsh:true},{av:'AV132Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV127TFMenuItemOrder',fld:'vTFMENUITEMORDER',pic:'ZZZ9'},{av:'AV128TFMenuItemOrder_To',fld:'vTFMENUITEMORDER_TO',pic:'ZZZ9'},{av:'AV80TFMenuItemCaption',fld:'vTFMENUITEMCAPTION',pic:''},{av:'AV81TFMenuItemCaption_Sel',fld:'vTFMENUITEMCAPTION_SEL',pic:''},{av:'AV118TFMenuItemType_Sels',fld:'vTFMENUITEMTYPE_SELS',pic:''},{av:'AV105TFMenuItemFatherCaption',fld:'vTFMENUITEMFATHERCAPTION',pic:''},{av:'AV106TFMenuItemFatherCaption_Sel',fld:'vTFMENUITEMFATHERCAPTION_SEL',pic:''},{av:'AV68OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV70OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV68OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV70OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV127TFMenuItemOrder',fld:'vTFMENUITEMORDER',pic:'ZZZ9'},{av:'AV128TFMenuItemOrder_To',fld:'vTFMENUITEMORDER_TO',pic:'ZZZ9'},{av:'AV80TFMenuItemCaption',fld:'vTFMENUITEMCAPTION',pic:''},{av:'AV81TFMenuItemCaption_Sel',fld:'vTFMENUITEMCAPTION_SEL',pic:''},{av:'AV117TFMenuItemType_SelsJson',fld:'vTFMENUITEMTYPE_SELSJSON',pic:''},{av:'AV118TFMenuItemType_Sels',fld:'vTFMENUITEMTYPE_SELS',pic:''},{av:'AV105TFMenuItemFatherCaption',fld:'vTFMENUITEMFATHERCAPTION',pic:''},{av:'AV106TFMenuItemFatherCaption_Sel',fld:'vTFMENUITEMFATHERCAPTION_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E160L2',iparms:[{av:'cmbMenuItemType'},{av:'A1232MenuItemType',fld:'MENUITEMTYPE',pic:'9'},{av:'A352MenuItemId',fld:'MENUITEMID',pic:'ZZZ9'},{av:'A353MenuItemFatherId',fld:'MENUITEMFATHERID',pic:'ZZZ9'},{av:'AV57MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV124AddMenu',fld:'vADDMENU',pic:''},{av:'edtavAddmenu_Tooltiptext',ctrl:'vADDMENU',prop:'Tooltiptext'},{av:'edtavAddmenu_Link',ctrl:'vADDMENU',prop:'Link'},{av:'edtavAddmenu_Class',ctrl:'vADDMENU',prop:'Class'},{av:'AV99Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Class',ctrl:'vUPDATE',prop:'Class'},{av:'AV24Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Class',ctrl:'vDELETE',prop:'Class'},{av:'edtMenuItemCaption_Link',ctrl:'MENUITEMCAPTION',prop:'Link'},{av:'edtMenuItemFatherCaption_Link',ctrl:'MENUITEMFATHERCAPTION',prop:'Link'}]}");
         setEventMetadata("NULL","{handler:'Valid_Menuitemfathercaption',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV132Pgmname = "";
         AV80TFMenuItemCaption = "";
         AV81TFMenuItemCaption_Sel = "";
         AV118TFMenuItemType_Sels = new GxSimpleCollection<short>();
         AV105TFMenuItemFatherCaption = "";
         AV106TFMenuItemFatherCaption_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV126GridAppliedFilters = "";
         AV96treeNodeCollectionData = new GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode>( context, "TreeNode", "SIGERP_ADVANCED");
         AV23DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV124AddMenu = "";
         AV99Update = "";
         AV24Delete = "";
         A1222MenuItemCaption = "";
         A1223MenuItemFatherCaption = "";
         ucGridpaginationbar = new GXUserControl();
         ucUttreeview = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV140Addmenu_GXI = "";
         GXDecQS = "";
         AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = "";
         lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = "";
         AV122MenuItemIdCollection = new GxSimpleCollection<short>();
         AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = "";
         AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = "";
         AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = "";
         AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = "";
         H000L2_A353MenuItemFatherId = new short[1] ;
         H000L2_n353MenuItemFatherId = new bool[] {false} ;
         H000L2_A1223MenuItemFatherCaption = new string[] {""} ;
         H000L2_A1232MenuItemType = new short[1] ;
         H000L2_A1222MenuItemCaption = new string[] {""} ;
         H000L2_A352MenuItemId = new short[1] ;
         H000L2_A1229MenuItemOrder = new short[1] ;
         H000L3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV43HTTPRequest = new GxHttpRequest( context);
         H000L4_A352MenuItemId = new short[1] ;
         H000L4_A1222MenuItemCaption = new string[] {""} ;
         GXt_objcol_int2 = new GxSimpleCollection<short>();
         GXt_objcol_SdtTreeNodeCollection_TreeNode3 = new GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode>( context, "TreeNode", "SIGERP_ADVANCED");
         AV102WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV117TFMenuItemType_SelsJson = "";
         GridRow = new GXWebRow();
         AV76Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         AV97TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitemww__default(),
            new Object[][] {
                new Object[] {
               H000L2_A353MenuItemFatherId, H000L2_n353MenuItemFatherId, H000L2_A1223MenuItemFatherCaption, H000L2_A1232MenuItemType, H000L2_A1222MenuItemCaption, H000L2_A352MenuItemId, H000L2_A1229MenuItemOrder
               }
               , new Object[] {
               H000L3_AGRID_nRecordCount
               }
               , new Object[] {
               H000L4_A352MenuItemId, H000L4_A1222MenuItemCaption
               }
            }
         );
         AV132Pgmname = "WWPBaseObjects.MenuItemWW";
         /* GeneXus formulas. */
         AV132Pgmname = "WWPBaseObjects.MenuItemWW";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short AV57MenuItemFatherId ;
      private short wcpOAV57MenuItemFatherId ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV127TFMenuItemOrder ;
      private short AV128TFMenuItemOrder_To ;
      private short AV68OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV75selectedTreeNode ;
      private short A353MenuItemFatherId ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short A1229MenuItemOrder ;
      private short A352MenuItemId ;
      private short A1232MenuItemType ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ;
      private short AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_18 ;
      private int nGXsfl_18_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count ;
      private int AV71PageToGo ;
      private int AV141GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV37GridCurrentPage ;
      private long AV39GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_18_idx="0001" ;
      private string AV132Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Uttreeview_Style ;
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
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string edtavAddmenu_Class ;
      private string edtavUpdate_Class ;
      private string edtavDelete_Class ;
      private string subGrid_Header ;
      private string edtavAddmenu_Link ;
      private string edtavAddmenu_Tooltiptext ;
      private string AV99Update ;
      private string edtavUpdate_Link ;
      private string AV24Delete ;
      private string edtavDelete_Link ;
      private string edtMenuItemCaption_Link ;
      private string edtMenuItemFatherCaption_Link ;
      private string Gridpaginationbar_Internalname ;
      private string divUnnamedsection2_Internalname ;
      private string Uttreeview_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavAddmenu_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string edtMenuItemOrder_Internalname ;
      private string edtMenuItemId_Internalname ;
      private string edtMenuItemCaption_Internalname ;
      private string cmbMenuItemType_Internalname ;
      private string edtMenuItemFatherCaption_Internalname ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtMenuItemOrder_Jsonclick ;
      private string edtMenuItemId_Jsonclick ;
      private string edtMenuItemCaption_Jsonclick ;
      private string GXCCtl ;
      private string cmbMenuItemType_Jsonclick ;
      private string edtMenuItemFatherCaption_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV70OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n353MenuItemFatherId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV124AddMenu_IsBlob ;
      private string AV117TFMenuItemType_SelsJson ;
      private string AV80TFMenuItemCaption ;
      private string AV81TFMenuItemCaption_Sel ;
      private string AV105TFMenuItemFatherCaption ;
      private string AV106TFMenuItemFatherCaption_Sel ;
      private string AV126GridAppliedFilters ;
      private string A1222MenuItemCaption ;
      private string A1223MenuItemFatherCaption ;
      private string AV140Addmenu_GXI ;
      private string lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ;
      private string lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ;
      private string AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ;
      private string AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ;
      private string AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ;
      private string AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ;
      private string AV124AddMenu ;
      private GxSimpleCollection<short> AV118TFMenuItemType_Sels ;
      private GxSimpleCollection<short> AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ;
      private GxSimpleCollection<short> AV122MenuItemIdCollection ;
      private GxSimpleCollection<short> GXt_objcol_int2 ;
      private IGxSession AV76Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucUttreeview ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMenuItemType ;
      private IDataStoreProvider pr_default ;
      private short[] H000L2_A353MenuItemFatherId ;
      private bool[] H000L2_n353MenuItemFatherId ;
      private string[] H000L2_A1223MenuItemFatherCaption ;
      private short[] H000L2_A1232MenuItemType ;
      private string[] H000L2_A1222MenuItemCaption ;
      private short[] H000L2_A352MenuItemId ;
      private short[] H000L2_A1229MenuItemOrder ;
      private long[] H000L3_AGRID_nRecordCount ;
      private short[] H000L4_A352MenuItemId ;
      private string[] H000L4_A1222MenuItemCaption ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV43HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> AV96treeNodeCollectionData ;
      private GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> GXt_objcol_SdtTreeNodeCollection_TreeNode3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV23DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV97TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV102WWPContext ;
   }

   public class menuitemww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000L2( IGxContext context ,
                                             short A352MenuItemId ,
                                             GxSimpleCollection<short> AV122MenuItemIdCollection ,
                                             short A1232MenuItemType ,
                                             GxSimpleCollection<short> AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                             short AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                             short AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                             string AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                             string AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                             int AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count ,
                                             string AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                             string AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                             short A1229MenuItemOrder ,
                                             string A1222MenuItemCaption ,
                                             string A1223MenuItemFatherCaption ,
                                             short AV68OrderedBy ,
                                             bool AV70OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[MenuItemFatherId] AS MenuItemFatherId, T2.[MenuItemCaption] AS MenuItemFatherCaption, T1.[MenuItemType], T1.[MenuItemCaption], T1.[MenuItemId], T1.[MenuItemOrder]";
         sFromString = " FROM ([SIGERPMenu] T1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = T1.[MenuItemFatherId])";
         sOrderString = "";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122MenuItemIdCollection, "T1.[MenuItemId] IN (", ")")+")");
         if ( ! (0==AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] >= @AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] <= @AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)) ) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] like @lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] = @AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels, "T1.[MenuItemType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)) ) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] like @lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] = @AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( AV68OrderedBy == 1 ) && ! AV70OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MenuItemOrder]";
         }
         else if ( ( AV68OrderedBy == 1 ) && ( AV70OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MenuItemOrder] DESC";
         }
         else if ( ( AV68OrderedBy == 2 ) && ! AV70OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[MenuItemType]";
         }
         else if ( ( AV68OrderedBy == 2 ) && ( AV70OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[MenuItemType] DESC";
         }
         else if ( ( AV68OrderedBy == 3 ) && ! AV70OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[MenuItemCaption]";
         }
         else if ( ( AV68OrderedBy == 3 ) && ( AV70OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[MenuItemCaption] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[MenuItemId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H000L3( IGxContext context ,
                                             short A352MenuItemId ,
                                             GxSimpleCollection<short> AV122MenuItemIdCollection ,
                                             short A1232MenuItemType ,
                                             GxSimpleCollection<short> AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                             short AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                             short AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                             string AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                             string AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                             int AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count ,
                                             string AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                             string AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                             short A1229MenuItemOrder ,
                                             string A1222MenuItemCaption ,
                                             string A1223MenuItemFatherCaption ,
                                             short AV68OrderedBy ,
                                             bool AV70OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([SIGERPMenu] T1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = T1.[MenuItemFatherId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122MenuItemIdCollection, "T1.[MenuItemId] IN (", ")")+")");
         if ( ! (0==AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] >= @AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (0==AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] <= @AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)) ) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] like @lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] = @AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels, "T1.[MenuItemType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)) ) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] like @lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] = @AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV68OrderedBy == 1 ) && ! AV70OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV68OrderedBy == 1 ) && ( AV70OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV68OrderedBy == 2 ) && ! AV70OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV68OrderedBy == 2 ) && ( AV70OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV68OrderedBy == 3 ) && ! AV70OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV68OrderedBy == 3 ) && ( AV70OrderedDsc ) )
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
                     return conditional_H000L2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] );
               case 1 :
                     return conditional_H000L3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] );
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
          Object[] prmH000L4;
          prmH000L4 = new Object[] {
          new ParDef("@AV57MenuItemFatherId",GXType.Int16,4,0)
          };
          Object[] prmH000L2;
          prmH000L2 = new Object[] {
          new ParDef("@AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder",GXType.Int16,4,0) ,
          new ParDef("@AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to",GXType.Int16,4,0) ,
          new ParDef("@lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000L3;
          prmH000L3 = new Object[] {
          new ParDef("@AV133Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder",GXType.Int16,4,0) ,
          new ParDef("@AV134Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to",GXType.Int16,4,0) ,
          new ParDef("@lV135Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV136Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV138Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV139Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L4", "SELECT [MenuItemId], [MenuItemCaption] FROM [SIGERPMenu] WHERE [MenuItemId] = @AV57MenuItemFatherId ORDER BY [MenuItemId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L4,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
