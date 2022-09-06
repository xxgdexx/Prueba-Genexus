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
namespace GeneXus.Programs.almacen {
   public class r_consultastockactual : GXDataArea
   {
      public r_consultastockactual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_consultastockactual( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               nRC_GXsfl_47 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_47"), "."));
               nGXsfl_47_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_47_idx"), "."));
               sGXsfl_47_idx = GetPar( "sGXsfl_47_idx");
               AV32Comen = GetPar( "Comen");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid2_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               subGrid2_Rows = (int)(NumberUtil.Val( GetPar( "subGrid2_Rows"), "."));
               AV15ProdCod = GetPar( "ProdCod");
               AV16ProdDsc = GetPar( "ProdDsc");
               AV32Comen = GetPar( "Comen");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid2_refresh( subGrid2_Rows, AV15ProdCod, AV16ProdDsc, AV32Comen) ;
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
         PA2X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810304842", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("almacen.r_consultastockactual.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCOD", StringUtil.RTrim( AV15ProdCod));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODDSC", StringUtil.RTrim( AV16ProdDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_47", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_47), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRID2PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35Grid2PageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRID2APPLIEDFILTERS", AV36Grid2AppliedFilters);
         GxWebStd.gx_hidden_field( context, "vCLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31cLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCSUBLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33cSubLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODCOD", StringUtil.RTrim( A28ProdCod));
         GxWebStd.gx_hidden_field( context, "GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID2_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Width", StringUtil.RTrim( Dvpanel_panel1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autowidth", StringUtil.BoolToStr( Dvpanel_panel1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autoheight", StringUtil.BoolToStr( Dvpanel_panel1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Cls", StringUtil.RTrim( Dvpanel_panel1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Title", StringUtil.RTrim( Dvpanel_panel1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Collapsible", StringUtil.BoolToStr( Dvpanel_panel1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Collapsed", StringUtil.BoolToStr( Dvpanel_panel1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panel1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Iconposition", StringUtil.RTrim( Dvpanel_panel1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autoscroll", StringUtil.BoolToStr( Dvpanel_panel1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Class", StringUtil.RTrim( Grid2paginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Grid2paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Grid2paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Grid2paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Grid2paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid2paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Grid2paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Grid2paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Grid2paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Grid2paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid2paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Grid2paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Previous", StringUtil.RTrim( Grid2paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Next", StringUtil.RTrim( Grid2paginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Caption", StringUtil.RTrim( Grid2paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Grid2paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Grid2paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GRID2_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid2_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid2paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid2paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid2paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID2PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid2paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE2X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2X2( ) ;
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
         return formatLink("almacen.r_consultastockactual.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Almacen.R_ConsultaStockActual" ;
      }

      public override string GetPgmdesc( )
      {
         return "Consulta de Stock Actual" ;
      }

      protected void WB2X0( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panel1.SetProperty("Width", Dvpanel_panel1_Width);
            ucDvpanel_panel1.SetProperty("AutoWidth", Dvpanel_panel1_Autowidth);
            ucDvpanel_panel1.SetProperty("AutoHeight", Dvpanel_panel1_Autoheight);
            ucDvpanel_panel1.SetProperty("Cls", Dvpanel_panel1_Cls);
            ucDvpanel_panel1.SetProperty("Title", Dvpanel_panel1_Title);
            ucDvpanel_panel1.SetProperty("Collapsible", Dvpanel_panel1_Collapsible);
            ucDvpanel_panel1.SetProperty("Collapsed", Dvpanel_panel1_Collapsed);
            ucDvpanel_panel1.SetProperty("ShowCollapseIcon", Dvpanel_panel1_Showcollapseicon);
            ucDvpanel_panel1.SetProperty("IconPosition", Dvpanel_panel1_Iconposition);
            ucDvpanel_panel1.SetProperty("AutoScroll", Dvpanel_panel1_Autoscroll);
            ucDvpanel_panel1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panel1_Internalname, "DVPANEL_PANEL1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANEL1Container"+"Panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanel1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnexcel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", "Excel", bttBtnbtnexcel_Jsonclick, 5, "Exportal a Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_ConsultaStockActual.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Imprimir PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\R_ConsultaStockActual.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprodcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, "Producto", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\R_ConsultaStockActual.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_32_2X2( true) ;
         }
         else
         {
            wb_table1_32_2X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_32_2X2e( bool wbgen )
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid2tablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"47\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid2_Backcolorstyle == 0 )
               {
                  subGrid2_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
               else
               {
                  subGrid2_Titlebackstyle = 1;
                  if ( subGrid2_Backcolorstyle == 1 )
                  {
                     subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                     if ( StringUtil.Len( subGrid2_Class) > 0 )
                     {
                        subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid2_Class) > 0 )
                     {
                        subGrid2_Linesclass = subGrid2_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Almacen") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Stock") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(36), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid2Container.AddObjectProperty("GridName", "Grid2");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid2Container = new GXWebGrid( context);
               }
               else
               {
                  Grid2Container.Clear();
               }
               Grid2Container.SetWrapped(nGXWrapped);
               Grid2Container.AddObjectProperty("GridName", "Grid2");
               Grid2Container.AddObjectProperty("Header", subGrid2_Header);
               Grid2Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("CmpContext", "");
               Grid2Container.AddObjectProperty("InMasterPage", "false");
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22AlmDsc), 4, 0, ".", "")));
               Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAlmdsc_Enabled), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ProdCode), 4, 0, ".", "")));
               Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProdcode_Enabled), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ProdDsce), 4, 0, ".", "")));
               Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProddsce_Enabled), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( AV25StkAct, 17, 4, ".", "")));
               Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavStkact_Enabled), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", context.convertURL( AV32Comen));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            nRC_GXsfl_47 = (int)(nGXsfl_47_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGrid2paginationbar.SetProperty("Class", Grid2paginationbar_Class);
            ucGrid2paginationbar.SetProperty("ShowFirst", Grid2paginationbar_Showfirst);
            ucGrid2paginationbar.SetProperty("ShowPrevious", Grid2paginationbar_Showprevious);
            ucGrid2paginationbar.SetProperty("ShowNext", Grid2paginationbar_Shownext);
            ucGrid2paginationbar.SetProperty("ShowLast", Grid2paginationbar_Showlast);
            ucGrid2paginationbar.SetProperty("PagesToShow", Grid2paginationbar_Pagestoshow);
            ucGrid2paginationbar.SetProperty("PagingButtonsPosition", Grid2paginationbar_Pagingbuttonsposition);
            ucGrid2paginationbar.SetProperty("PagingCaptionPosition", Grid2paginationbar_Pagingcaptionposition);
            ucGrid2paginationbar.SetProperty("EmptyGridClass", Grid2paginationbar_Emptygridclass);
            ucGrid2paginationbar.SetProperty("RowsPerPageSelector", Grid2paginationbar_Rowsperpageselector);
            ucGrid2paginationbar.SetProperty("RowsPerPageOptions", Grid2paginationbar_Rowsperpageoptions);
            ucGrid2paginationbar.SetProperty("Previous", Grid2paginationbar_Previous);
            ucGrid2paginationbar.SetProperty("Next", Grid2paginationbar_Next);
            ucGrid2paginationbar.SetProperty("Caption", Grid2paginationbar_Caption);
            ucGrid2paginationbar.SetProperty("EmptyGridCaption", Grid2paginationbar_Emptygridcaption);
            ucGrid2paginationbar.SetProperty("RowsPerPageCaption", Grid2paginationbar_Rowsperpagecaption);
            ucGrid2paginationbar.SetProperty("CurrentPage", AV34Grid2CurrentPage);
            ucGrid2paginationbar.SetProperty("PageCount", AV35Grid2PageCount);
            ucGrid2paginationbar.SetProperty("AppliedFilters", AV36Grid2AppliedFilters);
            ucGrid2paginationbar.Render(context, "dvelop.dvpaginationbar", Grid2paginationbar_Internalname, "GRID2PAGINATIONBARContainer");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGrid2currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34Grid2CurrentPage), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34Grid2CurrentPage), "ZZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGrid2currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGrid2currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\R_ConsultaStockActual.htm");
            /* User Defined Control */
            ucGrid2_empowerer.Render(context, "wwp.gridempowerer", Grid2_empowerer_Internalname, "GRID2_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2X2( )
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
            Form.Meta.addItem("description", "Consulta de Stock Actual", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2X0( ) ;
      }

      protected void WS2X2( )
      {
         START2X2( ) ;
         EVT2X2( ) ;
      }

      protected void EVT2X2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRID2PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID2PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnExcel' */
                              E132X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E142X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNBUSCAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnBuscar' */
                              E152X2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "VCOMEN.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "VCOMEN.CLICK") == 0 ) )
                           {
                              nGXsfl_47_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
                              SubsflControlProps_472( ) ;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavAlmdsc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAlmdsc_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vALMDSC");
                                 GX_FocusControl = edtavAlmdsc_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV22AlmDsc = 0;
                                 AssignAttri("", false, edtavAlmdsc_Internalname, StringUtil.LTrimStr( (decimal)(AV22AlmDsc), 4, 0));
                              }
                              else
                              {
                                 AV22AlmDsc = (short)(context.localUtil.CToN( cgiGet( edtavAlmdsc_Internalname), ".", ","));
                                 AssignAttri("", false, edtavAlmdsc_Internalname, StringUtil.LTrimStr( (decimal)(AV22AlmDsc), 4, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavProdcode_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProdcode_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODCODE");
                                 GX_FocusControl = edtavProdcode_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV23ProdCode = 0;
                                 AssignAttri("", false, edtavProdcode_Internalname, StringUtil.LTrimStr( (decimal)(AV23ProdCode), 4, 0));
                              }
                              else
                              {
                                 AV23ProdCode = (short)(context.localUtil.CToN( cgiGet( edtavProdcode_Internalname), ".", ","));
                                 AssignAttri("", false, edtavProdcode_Internalname, StringUtil.LTrimStr( (decimal)(AV23ProdCode), 4, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavProddsce_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProddsce_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODDSCE");
                                 GX_FocusControl = edtavProddsce_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV24ProdDsce = 0;
                                 AssignAttri("", false, edtavProddsce_Internalname, StringUtil.LTrimStr( (decimal)(AV24ProdDsce), 4, 0));
                              }
                              else
                              {
                                 AV24ProdDsce = (short)(context.localUtil.CToN( cgiGet( edtavProddsce_Internalname), ".", ","));
                                 AssignAttri("", false, edtavProddsce_Internalname, StringUtil.LTrimStr( (decimal)(AV24ProdDsce), 4, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavStkact_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavStkact_Internalname), ".", ",") > 9999999999.9999m ) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSTKACT");
                                 GX_FocusControl = edtavStkact_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV25StkAct = 0;
                                 AssignAttri("", false, edtavStkact_Internalname, StringUtil.LTrimStr( AV25StkAct, 15, 4));
                              }
                              else
                              {
                                 AV25StkAct = context.localUtil.CToN( cgiGet( edtavStkact_Internalname), ".", ",");
                                 AssignAttri("", false, edtavStkact_Internalname, StringUtil.LTrimStr( AV25StkAct, 15, 4));
                              }
                              AV32Comen = cgiGet( edtavComen_Internalname);
                              AssignProp("", false, edtavComen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Comen)) ? AV41Comen_GXI : context.convertURL( context.PathToRelativeUrl( AV32Comen))), !bGXsfl_47_Refreshing);
                              AssignProp("", false, edtavComen_Internalname, "SrcSet", context.GetImageSrcSet( AV32Comen), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E162X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E172X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VCOMEN.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Prodcod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCOD"), AV15ProdCod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proddsc Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC"), AV16ProdDsc) != 0 )
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

      protected void WE2X2( )
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

      protected void PA2X2( )
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
               GX_FocusControl = edtavProdcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_472( ) ;
         while ( nGXsfl_47_idx <= nRC_GXsfl_47 )
         {
            sendrow_472( ) ;
            nGXsfl_47_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxgrGrid2_refresh( int subGrid2_Rows ,
                                        string AV15ProdCod ,
                                        string AV16ProdDsc ,
                                        string AV32Comen )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E172X2 ();
         GRID2_nCurrentRecord = 0;
         RF2X2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid2_refresh */
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
         RF2X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
         edtavAlmdsc_Enabled = 0;
         AssignProp("", false, edtavAlmdsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAlmdsc_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtavProdcode_Enabled = 0;
         AssignProp("", false, edtavProdcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProdcode_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtavProddsce_Enabled = 0;
         AssignProp("", false, edtavProddsce_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsce_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtavStkact_Enabled = 0;
         AssignProp("", false, edtavStkact_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStkact_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
      }

      protected void RF2X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 47;
         /* Execute user event: Refresh */
         E172X2 ();
         nGXsfl_47_idx = 1;
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         bGXsfl_47_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_472( ) ;
            GXPagingFrom2 = (int)(((subGrid2_Rows==0) ? 0 : GRID2_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid2_Rows==0) ? 10000 : subGrid2_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16ProdDsc ,
                                                 AV15ProdCod ,
                                                 A28ProdCod ,
                                                 A55ProdDsc } ,
                                                 new int[]{
                                                 }
            });
            lV15ProdCod = StringUtil.PadR( StringUtil.RTrim( AV15ProdCod), 15, "%");
            lV16ProdDsc = StringUtil.PadR( StringUtil.RTrim( AV16ProdDsc), 100, "%");
            /* Using cursor H002X2 */
            pr_default.execute(0, new Object[] {lV15ProdCod, lV16ProdDsc, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_47_idx = 1;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid2_Rows == 0 ) || ( GRID2_nCurrentRecord < subGrid2_fnc_Recordsperpage( ) ) ) ) )
            {
               A55ProdDsc = H002X2_A55ProdDsc[0];
               A28ProdCod = H002X2_A28ProdCod[0];
               E182X2 ();
               pr_default.readNext(0);
            }
            GRID2_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID2_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 47;
            WB2X0( ) ;
         }
         bGXsfl_47_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2X2( )
      {
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         GRID2_nRecordCount = subGrid2_fnc_Recordcount( );
         if ( ((int)((GRID2_nRecordCount) % (subGrid2_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID2_nRecordCount/ (decimal)(subGrid2_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID2_nRecordCount/ (decimal)(subGrid2_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV16ProdDsc ,
                                              AV15ProdCod ,
                                              A28ProdCod ,
                                              A55ProdDsc } ,
                                              new int[]{
                                              }
         });
         lV15ProdCod = StringUtil.PadR( StringUtil.RTrim( AV15ProdCod), 15, "%");
         lV16ProdDsc = StringUtil.PadR( StringUtil.RTrim( AV16ProdDsc), 100, "%");
         /* Using cursor H002X3 */
         pr_default.execute(1, new Object[] {lV15ProdCod, lV16ProdDsc});
         GRID2_nRecordCount = H002X3_AGRID2_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID2_nRecordCount) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         if ( subGrid2_Rows > 0 )
         {
            return subGrid2_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID2_nFirstRecordOnPage/ (decimal)(subGrid2_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid2_firstpage( )
      {
         GRID2_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid2_refresh( subGrid2_Rows, AV15ProdCod, AV16ProdDsc, AV32Comen) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid2_nextpage( )
      {
         GRID2_nRecordCount = subGrid2_fnc_Recordcount( );
         if ( ( GRID2_nRecordCount >= subGrid2_fnc_Recordsperpage( ) ) && ( GRID2_nEOF == 0 ) )
         {
            GRID2_nFirstRecordOnPage = (long)(GRID2_nFirstRecordOnPage+subGrid2_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid2Container.AddObjectProperty("GRID2_nFirstRecordOnPage", GRID2_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid2_refresh( subGrid2_Rows, AV15ProdCod, AV16ProdDsc, AV32Comen) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID2_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid2_previouspage( )
      {
         if ( GRID2_nFirstRecordOnPage >= subGrid2_fnc_Recordsperpage( ) )
         {
            GRID2_nFirstRecordOnPage = (long)(GRID2_nFirstRecordOnPage-subGrid2_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid2_refresh( subGrid2_Rows, AV15ProdCod, AV16ProdDsc, AV32Comen) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid2_lastpage( )
      {
         GRID2_nRecordCount = subGrid2_fnc_Recordcount( );
         if ( GRID2_nRecordCount > subGrid2_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID2_nRecordCount) % (subGrid2_fnc_Recordsperpage( )))) == 0 )
            {
               GRID2_nFirstRecordOnPage = (long)(GRID2_nRecordCount-subGrid2_fnc_Recordsperpage( ));
            }
            else
            {
               GRID2_nFirstRecordOnPage = (long)(GRID2_nRecordCount-((int)((GRID2_nRecordCount) % (subGrid2_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID2_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid2_refresh( subGrid2_Rows, AV15ProdCod, AV16ProdDsc, AV32Comen) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid2_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID2_nFirstRecordOnPage = (long)(subGrid2_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID2_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID2_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID2_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid2_refresh( subGrid2_Rows, AV15ProdCod, AV16ProdDsc, AV32Comen) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
         edtavAlmdsc_Enabled = 0;
         AssignProp("", false, edtavAlmdsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAlmdsc_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtavProdcode_Enabled = 0;
         AssignProp("", false, edtavProdcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProdcode_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtavProddsce_Enabled = 0;
         AssignProp("", false, edtavProddsce_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsce_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         edtavStkact_Enabled = 0;
         AssignProp("", false, edtavStkact_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStkact_Enabled), 5, 0), !bGXsfl_47_Refreshing);
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_47 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_47"), ".", ","));
            AV35Grid2PageCount = (long)(context.localUtil.CToN( cgiGet( "vGRID2PAGECOUNT"), ".", ","));
            AV36Grid2AppliedFilters = cgiGet( "vGRID2APPLIEDFILTERS");
            GRID2_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID2_nFirstRecordOnPage"), ".", ","));
            GRID2_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID2_nEOF"), ".", ","));
            subGrid2_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID2_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Rows), 6, 0, ".", "")));
            Dvpanel_panel1_Width = cgiGet( "DVPANEL_PANEL1_Width");
            Dvpanel_panel1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autowidth"));
            Dvpanel_panel1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autoheight"));
            Dvpanel_panel1_Cls = cgiGet( "DVPANEL_PANEL1_Cls");
            Dvpanel_panel1_Title = cgiGet( "DVPANEL_PANEL1_Title");
            Dvpanel_panel1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Collapsible"));
            Dvpanel_panel1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Collapsed"));
            Dvpanel_panel1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Showcollapseicon"));
            Dvpanel_panel1_Iconposition = cgiGet( "DVPANEL_PANEL1_Iconposition");
            Dvpanel_panel1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autoscroll"));
            Grid2paginationbar_Class = cgiGet( "GRID2PAGINATIONBAR_Class");
            Grid2paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRID2PAGINATIONBAR_Showfirst"));
            Grid2paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRID2PAGINATIONBAR_Showprevious"));
            Grid2paginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRID2PAGINATIONBAR_Shownext"));
            Grid2paginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRID2PAGINATIONBAR_Showlast"));
            Grid2paginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRID2PAGINATIONBAR_Pagestoshow"), ".", ","));
            Grid2paginationbar_Pagingbuttonsposition = cgiGet( "GRID2PAGINATIONBAR_Pagingbuttonsposition");
            Grid2paginationbar_Pagingcaptionposition = cgiGet( "GRID2PAGINATIONBAR_Pagingcaptionposition");
            Grid2paginationbar_Emptygridclass = cgiGet( "GRID2PAGINATIONBAR_Emptygridclass");
            Grid2paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRID2PAGINATIONBAR_Rowsperpageselector"));
            Grid2paginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRID2PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","));
            Grid2paginationbar_Rowsperpageoptions = cgiGet( "GRID2PAGINATIONBAR_Rowsperpageoptions");
            Grid2paginationbar_Previous = cgiGet( "GRID2PAGINATIONBAR_Previous");
            Grid2paginationbar_Next = cgiGet( "GRID2PAGINATIONBAR_Next");
            Grid2paginationbar_Caption = cgiGet( "GRID2PAGINATIONBAR_Caption");
            Grid2paginationbar_Emptygridcaption = cgiGet( "GRID2PAGINATIONBAR_Emptygridcaption");
            Grid2paginationbar_Rowsperpagecaption = cgiGet( "GRID2PAGINATIONBAR_Rowsperpagecaption");
            Grid2_empowerer_Gridinternalname = cgiGet( "GRID2_EMPOWERER_Gridinternalname");
            Grid2paginationbar_Selectedpage = cgiGet( "GRID2PAGINATIONBAR_Selectedpage");
            Grid2paginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRID2PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","));
            /* Read variables values. */
            AV15ProdCod = StringUtil.Upper( cgiGet( edtavProdcod_Internalname));
            AssignAttri("", false, "AV15ProdCod", AV15ProdCod);
            AV16ProdDsc = cgiGet( edtavProddsc_Internalname);
            AssignAttri("", false, "AV16ProdDsc", AV16ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGrid2currentpage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGrid2currentpage_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRID2CURRENTPAGE");
               GX_FocusControl = edtavGrid2currentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34Grid2CurrentPage = 0;
               AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
            }
            else
            {
               AV34Grid2CurrentPage = (long)(context.localUtil.CToN( cgiGet( edtavGrid2currentpage_Internalname), ".", ","));
               AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCOD"), AV15ProdCod) != 0 )
            {
               GRID2_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC"), AV16ProdDsc) != 0 )
            {
               GRID2_nFirstRecordOnPage = 0;
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
         E162X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E162X2( )
      {
         /* Start Routine */
         returnInSub = false;
         Grid2_empowerer_Gridinternalname = subGrid2_Internalname;
         ucGrid2_empowerer.SendProperty(context, "", false, Grid2_empowerer_Internalname, "GridInternalName", Grid2_empowerer_Gridinternalname);
         subGrid2_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Rows), 6, 0, ".", "")));
         AV34Grid2CurrentPage = 1;
         AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
         edtavGrid2currentpage_Visible = 0;
         AssignProp("", false, edtavGrid2currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGrid2currentpage_Visible), 5, 0), true);
         AV35Grid2PageCount = -1;
         AssignAttri("", false, "AV35Grid2PageCount", StringUtil.LTrimStr( (decimal)(AV35Grid2PageCount), 10, 0));
         Grid2paginationbar_Rowsperpageselectedvalue = subGrid2_Rows;
         ucGrid2paginationbar.SendProperty(context, "", false, Grid2paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid2paginationbar_Rowsperpageselectedvalue), 9, 0));
         AV32Comen = context.GetImagePath( "PromptComentario", "", context.GetTheme( ));
         AssignProp("", false, edtavComen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Comen)) ? AV41Comen_GXI : context.convertURL( context.PathToRelativeUrl( AV32Comen))), !bGXsfl_47_Refreshing);
         AssignProp("", false, edtavComen_Internalname, "SrcSet", context.GetImageSrcSet( AV32Comen), true);
         AV41Comen_GXI = GXDbFile.PathToUrl( "PromptComentario");
         AssignProp("", false, edtavComen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Comen)) ? AV41Comen_GXI : context.convertURL( context.PathToRelativeUrl( AV32Comen))), !bGXsfl_47_Refreshing);
         AssignProp("", false, edtavComen_Internalname, "SrcSet", context.GetImageSrcSet( AV32Comen), true);
      }

      protected void E172X2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E182X2( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 47;
         }
         sendrow_472( ) ;
         GRID2_nCurrentRecord = (long)(GRID2_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_47_Refreshing )
         {
            DoAjaxLoad(47, Grid2Row);
         }
      }

      protected void E112X2( )
      {
         /* Grid2paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid2paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV34Grid2CurrentPage = (long)(AV34Grid2CurrentPage-1);
            AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
            subgrid2_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid2paginationbar_Selectedpage, "Next") == 0 )
         {
            AV34Grid2CurrentPage = (long)(AV34Grid2CurrentPage+1);
            AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
            subgrid2_nextpage( ) ;
         }
         else
         {
            AV27PageToGo = (int)(NumberUtil.Val( Grid2paginationbar_Selectedpage, "."));
            AV34Grid2CurrentPage = AV27PageToGo;
            AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
            subgrid2_gotopage( AV27PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E122X2( )
      {
         /* Grid2paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid2_Rows = Grid2paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID2_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Rows), 6, 0, ".", "")));
         AV34Grid2CurrentPage = 1;
         AssignAttri("", false, "AV34Grid2CurrentPage", StringUtil.LTrimStr( (decimal)(AV34Grid2CurrentPage), 10, 0));
         subgrid2_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E132X2( )
      {
         /* 'DoBtnExcel' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         new GeneXus.Programs.almacen.r_consultastockactualexcel(context ).execute( ref  AV15ProdCod, ref  AV16ProdDsc, ref  AV31cLinCod, ref  AV33cSubLCod, out  AV9ExcelFilename, out  AV8ErrorMessage) ;
         AssignAttri("", false, "AV15ProdCod", AV15ProdCod);
         AssignAttri("", false, "AV16ProdDsc", AV16ProdDsc);
         AssignAttri("", false, "AV31cLinCod", StringUtil.LTrimStr( (decimal)(AV31cLinCod), 6, 0));
         AssignAttri("", false, "AV33cSubLCod", StringUtil.LTrimStr( (decimal)(AV33cSubLCod), 6, 0));
         if ( StringUtil.StrCmp(AV9ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV9ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV8ErrorMessage);
         }
         /*  Sending Event outputs  */
      }

      protected void E142X2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E152X2( )
      {
         /* 'DoBtnBuscar' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         context.PopUp(formatLink("generales.wwbusquedaproducto.aspx", new object[] {UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"OutProdCod","OutProdDsc","InTipo"}) , new Object[] {"AV15ProdCod","AV16ProdDsc",});
         /*  Sending Event outputs  */
      }

      protected void E192X2( )
      {
         /* Comen_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "consultaobservacionesproducto.aspx"+UrlEncode(StringUtil.RTrim(A28ProdCod));
         context.PopUp(formatLink("consultaobservacionesproducto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"A28ProdCod"});
         /*  Sending Event outputs  */
      }

      protected void wb_table1_32_2X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedprodcod_Internalname, tblTablemergedprodcod_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcod_Internalname, "Codigo Producto", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcod_Internalname, StringUtil.RTrim( AV15ProdCod), StringUtil.RTrim( context.localUtil.Format( AV15ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProdcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_ConsultaStockActual.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Producto", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgBtnbuscar_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOBTNBUSCAR\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_ConsultaStockActual.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc_Internalname, "Descripcion producto", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc_Internalname, StringUtil.RTrim( AV16ProdDsc), StringUtil.RTrim( context.localUtil.Format( AV16ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProddsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\R_ConsultaStockActual.htm");
            /* Static images/pictures */
            ClassString = "gx-prompt Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgprompt_Prodcod_Proddsc_Internalname, sImgUrl, imgprompt_Prodcod_Proddsc_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\R_ConsultaStockActual.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_32_2X2e( true) ;
         }
         else
         {
            wb_table1_32_2X2e( false) ;
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
         PA2X2( ) ;
         WS2X2( ) ;
         WE2X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810304954", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("almacen/r_consultastockactual.js", "?202281810304955", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_472( )
      {
         edtavAlmdsc_Internalname = "vALMDSC_"+sGXsfl_47_idx;
         edtavProdcode_Internalname = "vPRODCODE_"+sGXsfl_47_idx;
         edtavProddsce_Internalname = "vPRODDSCE_"+sGXsfl_47_idx;
         edtavStkact_Internalname = "vSTKACT_"+sGXsfl_47_idx;
         edtavComen_Internalname = "vCOMEN_"+sGXsfl_47_idx;
      }

      protected void SubsflControlProps_fel_472( )
      {
         edtavAlmdsc_Internalname = "vALMDSC_"+sGXsfl_47_fel_idx;
         edtavProdcode_Internalname = "vPRODCODE_"+sGXsfl_47_fel_idx;
         edtavProddsce_Internalname = "vPRODDSCE_"+sGXsfl_47_fel_idx;
         edtavStkact_Internalname = "vSTKACT_"+sGXsfl_47_fel_idx;
         edtavComen_Internalname = "vCOMEN_"+sGXsfl_47_fel_idx;
      }

      protected void sendrow_472( )
      {
         SubsflControlProps_472( ) ;
         WB2X0( ) ;
         if ( ( subGrid2_Rows * 1 == 0 ) || ( nGXsfl_47_idx <= subGrid2_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid2Row = GXWebRow.GetNew(context,Grid2Container);
            if ( subGrid2_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid2_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
            else if ( subGrid2_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid2_Backstyle = 0;
               subGrid2_Backcolor = subGrid2_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Uniform";
               }
            }
            else if ( subGrid2_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid2_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
               subGrid2_Backcolor = (int)(0x0);
            }
            else if ( subGrid2_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid2_Backstyle = 1;
               if ( ((int)((nGXsfl_47_idx) % (2))) == 0 )
               {
                  subGrid2_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Even";
                  }
               }
               else
               {
                  subGrid2_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Odd";
                  }
               }
            }
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_47_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAlmdsc_Enabled!=0)&&(edtavAlmdsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 48,'',false,'"+sGXsfl_47_idx+"',47)\"" : " ");
            ROClassString = "Attribute";
            Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAlmdsc_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22AlmDsc), 4, 0, ".", "")),StringUtil.LTrim( ((edtavAlmdsc_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22AlmDsc), "ZZZ9") : context.localUtil.Format( (decimal)(AV22AlmDsc), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavAlmdsc_Enabled!=0)&&(edtavAlmdsc_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAlmdsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavAlmdsc_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavProdcode_Enabled!=0)&&(edtavProdcode_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 49,'',false,'"+sGXsfl_47_idx+"',47)\"" : " ");
            ROClassString = "Attribute";
            Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProdcode_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ProdCode), 4, 0, ".", "")),StringUtil.LTrim( ((edtavProdcode_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23ProdCode), "ZZZ9") : context.localUtil.Format( (decimal)(AV23ProdCode), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavProdcode_Enabled!=0)&&(edtavProdcode_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProdcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavProdcode_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavProddsce_Enabled!=0)&&(edtavProddsce_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 50,'',false,'"+sGXsfl_47_idx+"',47)\"" : " ");
            ROClassString = "Attribute";
            Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProddsce_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ProdDsce), 4, 0, ".", "")),StringUtil.LTrim( ((edtavProddsce_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24ProdDsce), "ZZZ9") : context.localUtil.Format( (decimal)(AV24ProdDsce), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavProddsce_Enabled!=0)&&(edtavProddsce_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProddsce_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavProddsce_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavStkact_Enabled!=0)&&(edtavStkact_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 51,'',false,'"+sGXsfl_47_idx+"',47)\"" : " ");
            ROClassString = "Attribute";
            Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavStkact_Internalname,StringUtil.LTrim( StringUtil.NToC( AV25StkAct, 17, 4, ".", "")),StringUtil.LTrim( ((edtavStkact_Enabled!=0) ? context.localUtil.Format( AV25StkAct, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( AV25StkAct, "ZZZZ,ZZZ,ZZ9.9999"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+((edtavStkact_Enabled!=0)&&(edtavStkact_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavStkact_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavStkact_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)47,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavComen_Enabled!=0)&&(edtavComen_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 52,'',false,'',47)\"" : " ");
            ClassString = "Attribute";
            StyleString = "";
            AV32Comen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV32Comen))&&String.IsNullOrEmpty(StringUtil.RTrim( AV41Comen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV32Comen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32Comen)) ? AV41Comen_GXI : context.PathToRelativeUrl( AV32Comen));
            Grid2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavComen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)1,(short)36,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavComen_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVCOMEN.CLICK."+sGXsfl_47_idx+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV32Comen_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes2X2( ) ;
            Grid2Container.AddRow(Grid2Row);
            nGXsfl_47_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         /* End function sendrow_472 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnbtnexcel_Internalname = "BTNBTNEXCEL";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         lblTextblockprodcod_Internalname = "TEXTBLOCKPRODCOD";
         edtavProdcod_Internalname = "vPRODCOD";
         imgBtnbuscar_Internalname = "BTNBUSCAR";
         edtavProddsc_Internalname = "vPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         divTablecontent_Internalname = "TABLECONTENT";
         edtavAlmdsc_Internalname = "vALMDSC";
         edtavProdcode_Internalname = "vPRODCODE";
         edtavProddsce_Internalname = "vPRODDSCE";
         edtavStkact_Internalname = "vSTKACT";
         edtavComen_Internalname = "vCOMEN";
         Grid2paginationbar_Internalname = "GRID2PAGINATIONBAR";
         divGrid2tablewithpaginationbar_Internalname = "GRID2TABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGrid2currentpage_Internalname = "vGRID2CURRENTPAGE";
         Grid2_empowerer_Internalname = "GRID2_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_Prodcod_Proddsc_Internalname = "PROMPT_PRODCOD_PRODDSC";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavComen_Jsonclick = "";
         edtavComen_Visible = -1;
         edtavComen_Enabled = 1;
         edtavStkact_Jsonclick = "";
         edtavStkact_Visible = -1;
         edtavProddsce_Jsonclick = "";
         edtavProddsce_Visible = -1;
         edtavProdcode_Jsonclick = "";
         edtavProdcode_Visible = -1;
         edtavAlmdsc_Jsonclick = "";
         edtavAlmdsc_Visible = -1;
         imgprompt_Prodcod_Proddsc_Link = "";
         edtavProddsc_Jsonclick = "";
         edtavProddsc_Enabled = 1;
         edtavProdcod_Jsonclick = "";
         edtavProdcod_Enabled = 1;
         edtavGrid2currentpage_Jsonclick = "";
         edtavGrid2currentpage_Visible = 1;
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         edtavStkact_Enabled = 1;
         edtavProddsce_Enabled = 1;
         edtavProdcode_Enabled = 1;
         edtavAlmdsc_Enabled = 1;
         subGrid2_Header = "";
         subGrid2_Class = "GridWithPaginationBar WorkWith";
         subGrid2_Backcolorstyle = 0;
         Grid2paginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Grid2paginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Grid2paginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Grid2paginationbar_Next = "WWP_PagingNextCaption";
         Grid2paginationbar_Previous = "WWP_PagingPreviousCaption";
         Grid2paginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Grid2paginationbar_Rowsperpageselectedvalue = 10;
         Grid2paginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Grid2paginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Grid2paginationbar_Pagingcaptionposition = "Left";
         Grid2paginationbar_Pagingbuttonsposition = "Right";
         Grid2paginationbar_Pagestoshow = 5;
         Grid2paginationbar_Showlast = Convert.ToBoolean( 0);
         Grid2paginationbar_Shownext = Convert.ToBoolean( -1);
         Grid2paginationbar_Showprevious = Convert.ToBoolean( -1);
         Grid2paginationbar_Showfirst = Convert.ToBoolean( 0);
         Grid2paginationbar_Class = "PaginationBar";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Reporte de Consulta de Stock Actual";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Consulta de Stock Actual";
         subGrid2_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'subGrid2_Rows',ctrl:'GRID2',prop:'Rows'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV32Comen',fld:'vCOMEN',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID2.LOAD","{handler:'E182X2',iparms:[]");
         setEventMetadata("GRID2.LOAD",",oparms:[]}");
         setEventMetadata("GRID2PAGINATIONBAR.CHANGEPAGE","{handler:'E112X2',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'subGrid2_Rows',ctrl:'GRID2',prop:'Rows'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV32Comen',fld:'vCOMEN',pic:''},{av:'Grid2paginationbar_Selectedpage',ctrl:'GRID2PAGINATIONBAR',prop:'SelectedPage'},{av:'AV34Grid2CurrentPage',fld:'vGRID2CURRENTPAGE',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("GRID2PAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV34Grid2CurrentPage',fld:'vGRID2CURRENTPAGE',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRID2PAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E122X2',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'subGrid2_Rows',ctrl:'GRID2',prop:'Rows'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV32Comen',fld:'vCOMEN',pic:''},{av:'Grid2paginationbar_Rowsperpageselectedvalue',ctrl:'GRID2PAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRID2PAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid2_Rows',ctrl:'GRID2',prop:'Rows'},{av:'AV34Grid2CurrentPage',fld:'vGRID2CURRENTPAGE',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'DOBTNEXCEL'","{handler:'E132X2',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'subGrid2_Rows',ctrl:'GRID2',prop:'Rows'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV32Comen',fld:'vCOMEN',pic:''},{av:'AV31cLinCod',fld:'vCLINCOD',pic:'ZZZZZ9'},{av:'AV33cSubLCod',fld:'vCSUBLCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOBTNEXCEL'",",oparms:[{av:'AV33cSubLCod',fld:'vCSUBLCOD',pic:'ZZZZZ9'},{av:'AV31cLinCod',fld:'vCLINCOD',pic:'ZZZZZ9'},{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E142X2',iparms:[]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[]}");
         setEventMetadata("'DOBTNBUSCAR'","{handler:'E152X2',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'subGrid2_Rows',ctrl:'GRID2',prop:'Rows'},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV32Comen',fld:'vCOMEN',pic:''}]");
         setEventMetadata("'DOBTNBUSCAR'",",oparms:[{av:'AV16ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV15ProdCod',fld:'vPRODCOD',pic:'@!'}]}");
         setEventMetadata("VCOMEN.CLICK","{handler:'E192X2',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VCOMEN.CLICK",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]}");
         setEventMetadata("NULL","{handler:'Validv_Comen',iparms:[]");
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
         Grid2paginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV32Comen = "";
         AV15ProdCod = "";
         AV16ProdDsc = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV36Grid2AppliedFilters = "";
         A28ProdCod = "";
         Grid2_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         TempTags = "";
         bttBtnbtnexcel_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         lblTextblockprodcod_Jsonclick = "";
         Grid2Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid2_Linesclass = "";
         Grid2Column = new GXWebColumn();
         ucGrid2paginationbar = new GXUserControl();
         ucGrid2_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41Comen_GXI = "";
         scmdbuf = "";
         lV15ProdCod = "";
         lV16ProdDsc = "";
         A55ProdDsc = "";
         H002X2_A55ProdDsc = new string[] {""} ;
         H002X2_A28ProdCod = new string[] {""} ;
         H002X3_AGRID2_nRecordCount = new long[1] ;
         Grid2Row = new GXWebRow();
         AV9ExcelFilename = "";
         AV8ErrorMessage = "";
         GXEncryptionTmp = "";
         sImgUrl = "";
         imgBtnbuscar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_consultastockactual__default(),
            new Object[][] {
                new Object[] {
               H002X2_A55ProdDsc, H002X2_A28ProdCod
               }
               , new Object[] {
               H002X3_AGRID2_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         edtavAlmdsc_Enabled = 0;
         edtavProdcode_Enabled = 0;
         edtavProddsce_Enabled = 0;
         edtavStkact_Enabled = 0;
         imgprompt_Prodcod_Proddsc_Link = "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPRODCOD"+"'), id:'"+"vPRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"vPRODDSC"+"'), id:'"+"vPRODDSC"+"'"+",IOType:'out'}"+","+""+"],"+"null"+","+"'', false"+","+"false"+");";
      }

      private short GRID2_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid2_Backcolorstyle ;
      private short subGrid2_Titlebackstyle ;
      private short AV22AlmDsc ;
      private short AV23ProdCode ;
      private short AV24ProdDsce ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private short nDonePA ;
      private short subGrid2_Backstyle ;
      private int Grid2paginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_47 ;
      private int nGXsfl_47_idx=1 ;
      private int subGrid2_Rows ;
      private int AV31cLinCod ;
      private int AV33cSubLCod ;
      private int Grid2paginationbar_Pagestoshow ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Allbackcolor ;
      private int edtavAlmdsc_Enabled ;
      private int edtavProdcode_Enabled ;
      private int edtavProddsce_Enabled ;
      private int edtavStkact_Enabled ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private int edtavGrid2currentpage_Visible ;
      private int subGrid2_Islastpage ;
      private int edtavProddsc_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV27PageToGo ;
      private int edtavProdcod_Enabled ;
      private int idxLst ;
      private int subGrid2_Backcolor ;
      private int edtavAlmdsc_Visible ;
      private int edtavProdcode_Visible ;
      private int edtavProddsce_Visible ;
      private int edtavStkact_Visible ;
      private int edtavComen_Enabled ;
      private int edtavComen_Visible ;
      private long GRID2_nFirstRecordOnPage ;
      private long AV35Grid2PageCount ;
      private long AV34Grid2CurrentPage ;
      private long GRID2_nCurrentRecord ;
      private long GRID2_nRecordCount ;
      private decimal AV25StkAct ;
      private string Grid2paginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_47_idx="0001" ;
      private string AV15ProdCod ;
      private string AV16ProdDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A28ProdCod ;
      private string Dvpanel_panel1_Width ;
      private string Dvpanel_panel1_Cls ;
      private string Dvpanel_panel1_Title ;
      private string Dvpanel_panel1_Iconposition ;
      private string Grid2paginationbar_Class ;
      private string Grid2paginationbar_Pagingbuttonsposition ;
      private string Grid2paginationbar_Pagingcaptionposition ;
      private string Grid2paginationbar_Emptygridclass ;
      private string Grid2paginationbar_Rowsperpageoptions ;
      private string Grid2paginationbar_Previous ;
      private string Grid2paginationbar_Next ;
      private string Grid2paginationbar_Caption ;
      private string Grid2paginationbar_Emptygridcaption ;
      private string Grid2paginationbar_Rowsperpagecaption ;
      private string Grid2_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panel1_Internalname ;
      private string divPanel1_Internalname ;
      private string TempTags ;
      private string bttBtnbtnexcel_Internalname ;
      private string bttBtnbtnexcel_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string divTablesplittedprodcod_Internalname ;
      private string lblTextblockprodcod_Internalname ;
      private string lblTextblockprodcod_Jsonclick ;
      private string divGrid2tablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid2_Internalname ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string subGrid2_Header ;
      private string Grid2paginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGrid2currentpage_Internalname ;
      private string edtavGrid2currentpage_Jsonclick ;
      private string Grid2_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavAlmdsc_Internalname ;
      private string edtavProdcode_Internalname ;
      private string edtavProddsce_Internalname ;
      private string edtavStkact_Internalname ;
      private string edtavComen_Internalname ;
      private string edtavProdcod_Internalname ;
      private string edtavProddsc_Internalname ;
      private string imgprompt_Prodcod_Proddsc_Link ;
      private string scmdbuf ;
      private string lV15ProdCod ;
      private string lV16ProdDsc ;
      private string A55ProdDsc ;
      private string GXEncryptionTmp ;
      private string tblTablemergedprodcod_Internalname ;
      private string edtavProdcod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscar_Internalname ;
      private string imgBtnbuscar_Jsonclick ;
      private string edtavProddsc_Jsonclick ;
      private string imgprompt_Prodcod_Proddsc_Internalname ;
      private string sGXsfl_47_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavAlmdsc_Jsonclick ;
      private string edtavProdcode_Jsonclick ;
      private string edtavProddsce_Jsonclick ;
      private string edtavStkact_Jsonclick ;
      private string edtavComen_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_panel1_Autowidth ;
      private bool Dvpanel_panel1_Autoheight ;
      private bool Dvpanel_panel1_Collapsible ;
      private bool Dvpanel_panel1_Collapsed ;
      private bool Dvpanel_panel1_Showcollapseicon ;
      private bool Dvpanel_panel1_Autoscroll ;
      private bool Grid2paginationbar_Showfirst ;
      private bool Grid2paginationbar_Showprevious ;
      private bool Grid2paginationbar_Shownext ;
      private bool Grid2paginationbar_Showlast ;
      private bool Grid2paginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_47_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV32Comen_IsBlob ;
      private string AV36Grid2AppliedFilters ;
      private string AV41Comen_GXI ;
      private string AV9ExcelFilename ;
      private string AV8ErrorMessage ;
      private string AV32Comen ;
      private GXWebGrid Grid2Container ;
      private GXWebRow Grid2Row ;
      private GXWebColumn Grid2Column ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucGrid2paginationbar ;
      private GXUserControl ucGrid2_empowerer ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H002X2_A55ProdDsc ;
      private string[] H002X2_A28ProdCod ;
      private long[] H002X3_AGRID2_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class r_consultastockactual__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002X2( IGxContext context ,
                                             string AV16ProdDsc ,
                                             string AV15ProdCod ,
                                             string A28ProdCod ,
                                             string A55ProdDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ProdDsc], [ProdCod]";
         sFromString = " FROM [APRODUCTOS]";
         sOrderString = "";
         AddWhere(sWhereString, "([ProdCod] like '%' + RTRIM(LTRIM(@lV15ProdCod)) + '%')");
         AddWhere(sWhereString, "([ProdDsc] like '%' + RTRIM(LTRIM(@lV16ProdDsc)) + '%')");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ProdDsc)) && String.IsNullOrEmpty(StringUtil.RTrim( AV15ProdCod)) )
         {
            AddWhere(sWhereString, "([ProdCod] = 'xxxxxxxxxx')");
         }
         sOrderString += " ORDER BY [ProdCod]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002X3( IGxContext context ,
                                             string AV16ProdDsc ,
                                             string AV15ProdCod ,
                                             string A28ProdCod ,
                                             string A55ProdDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [APRODUCTOS]";
         AddWhere(sWhereString, "([ProdCod] like '%' + RTRIM(LTRIM(@lV15ProdCod)) + '%')");
         AddWhere(sWhereString, "([ProdDsc] like '%' + RTRIM(LTRIM(@lV16ProdDsc)) + '%')");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ProdDsc)) && String.IsNullOrEmpty(StringUtil.RTrim( AV15ProdCod)) )
         {
            AddWhere(sWhereString, "([ProdCod] = 'xxxxxxxxxx')");
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 1 :
                     return conditional_H002X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
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
          Object[] prmH002X2;
          prmH002X2 = new Object[] {
          new ParDef("@lV15ProdCod",GXType.NChar,15,0) ,
          new ParDef("@lV16ProdDsc",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002X3;
          prmH002X3 = new Object[] {
          new ParDef("@lV15ProdCod",GXType.NChar,15,0) ,
          new ParDef("@lV16ProdDsc",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
