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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.contabilidad {
   public class r_comprobantediario : GXDataArea
   {
      public r_comprobantediario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprobantediario( IGxContext context )
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
         cmbavMes = new GXCombobox();
         radavCopc = new GXRadio();
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
         PA652( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START652( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810315960", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.r_comprobantediario.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTASICOD_DATA", AV15TASICod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTASICOD_DATA", AV15TASICod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVOUNUM_DATA", AV18VouNum_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVOUNUM_DATA", AV18VouNum_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCCOSTO_DATA", AV22cCosto_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCCOSTO_DATA", AV22cCosto_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_TASICOD_Cls", StringUtil.RTrim( Combo_tasicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TASICOD_Selectedvalue_set", StringUtil.RTrim( Combo_tasicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Cls", StringUtil.RTrim( Combo_vounum_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Selectedvalue_set", StringUtil.RTrim( Combo_vounum_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Selectedtext_set", StringUtil.RTrim( Combo_vounum_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Datalistproc", StringUtil.RTrim( Combo_vounum_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Datalistprocparametersprefix", StringUtil.RTrim( Combo_vounum_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CCOSTO_Cls", StringUtil.RTrim( Combo_ccosto_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CCOSTO_Selectedvalue_set", StringUtil.RTrim( Combo_ccosto_Selectedvalue_set));
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
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Target", StringUtil.RTrim( Innewwindow_Target));
         GxWebStd.gx_hidden_field( context, "COMBO_CCOSTO_Selectedvalue_get", StringUtil.RTrim( Combo_ccosto_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Selectedvalue_get", StringUtil.RTrim( Combo_vounum_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TASICOD_Selectedvalue_get", StringUtil.RTrim( Combo_tasicod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_VOUNUM_Selectedvalue_get", StringUtil.RTrim( Combo_vounum_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TASICOD_Selectedvalue_get", StringUtil.RTrim( Combo_tasicod_Selectedvalue_get));
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
            WE652( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT652( ) ;
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
         return formatLink("contabilidad.r_comprobantediario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.R_ComprobanteDiario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Libro Diario" ;
      }

      protected void WB650( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableano_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockano_Internalname, "Año", "", "", lblTextblockano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAno_Internalname, "Año", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Ano), 4, 0, ".", "")), StringUtil.LTrim( ((edtavAno_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Ano), "ZZZ9") : context.localUtil.Format( (decimal)(AV5Ano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemes_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockmes_Internalname, "Mes", "", "", lblTextblockmes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMes_Internalname, "Mes", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMes, cmbavMes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6Mes), 2, 0)), 1, cmbavMes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 1, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            cmbavMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6Mes), 2, 0));
            AssignProp("", false, cmbavMes_Internalname, "Values", (string)(cmbavMes.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtasicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tasicod_Internalname, "Tipo de Asiento", "", "", lblTextblockcombo_tasicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tasicod.SetProperty("Caption", Combo_tasicod_Caption);
            ucCombo_tasicod.SetProperty("Cls", Combo_tasicod_Cls);
            ucCombo_tasicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_tasicod.SetProperty("DropDownOptionsData", AV15TASICod_Data);
            ucCombo_tasicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tasicod_Internalname, "COMBO_TASICODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedvounum_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_vounum_Internalname, "N° de Asiento", "", "", lblTextblockcombo_vounum_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_vounum.SetProperty("Caption", Combo_vounum_Caption);
            ucCombo_vounum.SetProperty("Cls", Combo_vounum_Cls);
            ucCombo_vounum.SetProperty("DataListProc", Combo_vounum_Datalistproc);
            ucCombo_vounum.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_vounum.SetProperty("DropDownOptionsData", AV18VouNum_Data);
            ucCombo_vounum.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_vounum_Internalname, "COMBO_VOUNUMContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedccosto_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_ccosto_Internalname, "Centro de Costo", "", "", lblTextblockcombo_ccosto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_ccosto.SetProperty("Caption", Combo_ccosto_Caption);
            ucCombo_ccosto.SetProperty("Cls", Combo_ccosto_Cls);
            ucCombo_ccosto.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_ccosto.SetProperty("DropDownOptionsData", AV22cCosto_Data);
            ucCombo_ccosto.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_ccosto_Internalname, "COMBO_CCOSTOContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecopc_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcopc_Internalname, "Tipo Reporte", "", "", lblTextblockcopc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Tipo Reporte", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavCopc, radavCopc_Internalname, StringUtil.Str( (decimal)(AV10cOpc), 1, 0), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavCopc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedccuenta1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockccuenta1_Internalname, "Cuenta Desde", "", "", lblTextblockccuenta1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_73_652( true) ;
         }
         else
         {
            wb_table1_73_652( false) ;
         }
         return  ;
      }

      protected void wb_table1_73_652e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedccuenta2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockccuenta2_Internalname, "Cuenta Hasta", "", "", lblTextblockccuenta2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table2_90_652( true) ;
         }
         else
         {
            wb_table2_90_652( false) ;
         }
         return  ;
      }

      protected void wb_table2_90_652e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Salir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow.Render(context, "innewwindow", Innewwindow_Internalname, "INNEWWINDOWContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTasicod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TASICod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7TASICod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTasicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavTasicod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVounum_Internalname, StringUtil.RTrim( AV8VouNum), StringUtil.RTrim( context.localUtil.Format( AV8VouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVounum_Jsonclick, 0, "Attribute", "", "", "", "", edtavVounum_Visible, 1, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcosto_Internalname, StringUtil.RTrim( AV9cCosto), StringUtil.RTrim( context.localUtil.Format( AV9cCosto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcosto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcosto_Visible, 1, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START652( )
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
            Form.Meta.addItem("description", "Libro Diario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP650( ) ;
      }

      protected void WS652( )
      {
         START652( ) ;
         EVT652( ) ;
      }

      protected void EVT652( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_TASICOD.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11652 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_VOUNUM.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12652 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E13652 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E14652 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E15652 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E16652 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE652( )
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

      protected void PA652( )
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
               GX_FocusControl = edtavAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         if ( cmbavMes.ItemCount > 0 )
         {
            AV6Mes = (short)(NumberUtil.Val( cmbavMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6Mes), 2, 0))), "."));
            AssignAttri("", false, "AV6Mes", StringUtil.LTrimStr( (decimal)(AV6Mes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6Mes), 2, 0));
            AssignProp("", false, cmbavMes_Internalname, "Values", cmbavMes.ToJavascriptSource(), true);
         }
         AV10cOpc = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cOpc), 1, 0, ".", "")), ".", ","));
         AssignAttri("", false, "AV10cOpc", StringUtil.Str( (decimal)(AV10cOpc), 1, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF652( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         AssignProp("", false, edtavCcuedsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc1_Enabled), 5, 0), true);
         edtavCcuedsc2_Enabled = 0;
         AssignProp("", false, edtavCcuedsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc2_Enabled), 5, 0), true);
      }

      protected void RF652( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E16652 ();
            WB650( ) ;
         }
      }

      protected void send_integrity_lvl_hashes652( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         AssignProp("", false, edtavCcuedsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc1_Enabled), 5, 0), true);
         edtavCcuedsc2_Enabled = 0;
         AssignProp("", false, edtavCcuedsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc2_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP650( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13652 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vTASICOD_DATA"), AV15TASICod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vVOUNUM_DATA"), AV18VouNum_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCCOSTO_DATA"), AV22cCosto_Data);
            /* Read saved values. */
            Combo_tasicod_Cls = cgiGet( "COMBO_TASICOD_Cls");
            Combo_tasicod_Selectedvalue_set = cgiGet( "COMBO_TASICOD_Selectedvalue_set");
            Combo_vounum_Cls = cgiGet( "COMBO_VOUNUM_Cls");
            Combo_vounum_Selectedvalue_set = cgiGet( "COMBO_VOUNUM_Selectedvalue_set");
            Combo_vounum_Selectedtext_set = cgiGet( "COMBO_VOUNUM_Selectedtext_set");
            Combo_vounum_Datalistproc = cgiGet( "COMBO_VOUNUM_Datalistproc");
            Combo_vounum_Datalistprocparametersprefix = cgiGet( "COMBO_VOUNUM_Datalistprocparametersprefix");
            Combo_ccosto_Cls = cgiGet( "COMBO_CCOSTO_Cls");
            Combo_ccosto_Selectedvalue_set = cgiGet( "COMBO_CCOSTO_Selectedvalue_set");
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
            Innewwindow_Target = cgiGet( "INNEWWINDOW_Target");
            Combo_vounum_Selectedvalue_get = cgiGet( "COMBO_VOUNUM_Selectedvalue_get");
            Combo_tasicod_Selectedvalue_get = cgiGet( "COMBO_TASICOD_Selectedvalue_get");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vANO");
               GX_FocusControl = edtavAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Ano = 0;
               AssignAttri("", false, "AV5Ano", StringUtil.LTrimStr( (decimal)(AV5Ano), 4, 0));
            }
            else
            {
               AV5Ano = (short)(context.localUtil.CToN( cgiGet( edtavAno_Internalname), ".", ","));
               AssignAttri("", false, "AV5Ano", StringUtil.LTrimStr( (decimal)(AV5Ano), 4, 0));
            }
            cmbavMes.CurrentValue = cgiGet( cmbavMes_Internalname);
            AV6Mes = (short)(NumberUtil.Val( cgiGet( cmbavMes_Internalname), "."));
            AssignAttri("", false, "AV6Mes", StringUtil.LTrimStr( (decimal)(AV6Mes), 2, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( radavCopc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavCopc_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPC");
               wbErr = true;
               AV10cOpc = 0;
               AssignAttri("", false, "AV10cOpc", StringUtil.Str( (decimal)(AV10cOpc), 1, 0));
            }
            else
            {
               AV10cOpc = (short)(context.localUtil.CToN( cgiGet( radavCopc_Internalname), ".", ","));
               AssignAttri("", false, "AV10cOpc", StringUtil.Str( (decimal)(AV10cOpc), 1, 0));
            }
            AV11cCuenta1 = cgiGet( edtavCcuenta1_Internalname);
            AssignAttri("", false, "AV11cCuenta1", AV11cCuenta1);
            AV12cCueDsc1 = cgiGet( edtavCcuedsc1_Internalname);
            AssignAttri("", false, "AV12cCueDsc1", AV12cCueDsc1);
            AV13cCuenta2 = cgiGet( edtavCcuenta2_Internalname);
            AssignAttri("", false, "AV13cCuenta2", AV13cCuenta2);
            AV14cCueDsc2 = cgiGet( edtavCcuedsc2_Internalname);
            AssignAttri("", false, "AV14cCueDsc2", AV14cCueDsc2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTasicod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTasicod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTASICOD");
               GX_FocusControl = edtavTasicod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7TASICod = 0;
               AssignAttri("", false, "AV7TASICod", StringUtil.LTrimStr( (decimal)(AV7TASICod), 6, 0));
            }
            else
            {
               AV7TASICod = (int)(context.localUtil.CToN( cgiGet( edtavTasicod_Internalname), ".", ","));
               AssignAttri("", false, "AV7TASICod", StringUtil.LTrimStr( (decimal)(AV7TASICod), 6, 0));
            }
            AV8VouNum = cgiGet( edtavVounum_Internalname);
            AssignAttri("", false, "AV8VouNum", AV8VouNum);
            AV9cCosto = cgiGet( edtavCcosto_Internalname);
            AssignAttri("", false, "AV9cCosto", AV9cCosto);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13652 ();
         if (returnInSub) return;
      }

      protected void E13652( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavCcosto_Visible = 0;
         AssignProp("", false, edtavCcosto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCcosto_Visible), 5, 0), true);
         edtavVounum_Visible = 0;
         AssignProp("", false, edtavVounum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVounum_Visible), 5, 0), true);
         edtavTasicod_Visible = 0;
         AssignProp("", false, edtavTasicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTasicod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTASICOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOVOUNUM' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCCOSTO' */
         S132 ();
         if (returnInSub) return;
         AV5Ano = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV5Ano", StringUtil.LTrimStr( (decimal)(AV5Ano), 4, 0));
         AV6Mes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV6Mes", StringUtil.LTrimStr( (decimal)(AV6Mes), 2, 0));
         AV10cOpc = 1;
         AssignAttri("", false, "AV10cOpc", StringUtil.Str( (decimal)(AV10cOpc), 1, 0));
      }

      protected void E14652( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.r_librodiariopdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV5Ano,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6Mes,2,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TASICod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV8VouNum)) + "," + UrlEncode(StringUtil.RTrim(AV9cCosto)) + "," + UrlEncode(StringUtil.RTrim(AV11cCuenta1)) + "," + UrlEncode(StringUtil.RTrim(AV13cCuenta2)) + "," + UrlEncode(StringUtil.LTrimStr(AV10cOpc,1,0));
         Innewwindow_Target = formatLink("contabilidad.r_librodiariopdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E15652( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E12652( )
      {
         /* Combo_vounum_Onoptionclicked Routine */
         returnInSub = false;
         AV8VouNum = Combo_vounum_Selectedvalue_get;
         AssignAttri("", false, "AV8VouNum", AV8VouNum);
         /*  Sending Event outputs  */
      }

      protected void E11652( )
      {
         /* Combo_tasicod_Onoptionclicked Routine */
         returnInSub = false;
         AV21Cond_TASICod = AV7TASICod;
         AV7TASICod = (int)(NumberUtil.Val( Combo_tasicod_Selectedvalue_get, "."));
         AssignAttri("", false, "AV7TASICod", StringUtil.LTrimStr( (decimal)(AV7TASICod), 6, 0));
         if ( AV21Cond_TASICod != AV7TASICod )
         {
            AV8VouNum = "";
            AssignAttri("", false, "AV8VouNum", AV8VouNum);
            Combo_vounum_Selectedvalue_set = "";
            ucCombo_vounum.SendProperty(context, "", false, Combo_vounum_Internalname, "SelectedValue_set", Combo_vounum_Selectedvalue_set);
            Combo_vounum_Selectedtext_set = "";
            ucCombo_vounum.SendProperty(context, "", false, Combo_vounum_Internalname, "SelectedText_set", Combo_vounum_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCCOSTO' Routine */
         returnInSub = false;
         /* Using cursor H00652 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A762COSSts = H00652_A762COSSts[0];
            A79COSCod = H00652_A79COSCod[0];
            A761COSDsc = H00652_A761COSDsc[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = A79COSCod;
            AV17Combo_DataItem.gxTpr_Title = A761COSDsc;
            AV22cCosto_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_ccosto_Selectedvalue_set = AV9cCosto;
         ucCombo_ccosto.SendProperty(context, "", false, Combo_ccosto_Internalname, "SelectedValue_set", Combo_ccosto_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOVOUNUM' Routine */
         returnInSub = false;
         Combo_vounum_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"VouNum\", \"Cond_Ano\": \"#%1#\", \"Cond_Mes\": \"#%2#\", \"Cond_TASICod\": \"#%3#\"", edtavAno_Internalname, cmbavMes_Internalname, edtavTasicod_Internalname, "", "", "", "", "", "");
         ucCombo_vounum.SendProperty(context, "", false, Combo_vounum_Internalname, "DataListProcParametersPrefix", Combo_vounum_Datalistprocparametersprefix);
         AV19Cond_Ano = AV5Ano;
         AV20Cond_Mes = AV6Mes;
         AV21Cond_TASICod = AV7TASICod;
         AV26GXLvl135 = 0;
         /* Using cursor H00653 */
         pr_default.execute(1, new Object[] {AV8VouNum});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A129VouNum = H00653_A129VouNum[0];
            AV26GXLvl135 = 1;
            Combo_vounum_Selectedtext_set = A129VouNum;
            ucCombo_vounum.SendProperty(context, "", false, Combo_vounum_Internalname, "SelectedText_set", Combo_vounum_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV26GXLvl135 == 0 )
         {
            Combo_vounum_Selectedtext_set = "";
            ucCombo_vounum.SendProperty(context, "", false, Combo_vounum_Internalname, "SelectedText_set", Combo_vounum_Selectedtext_set);
         }
         Combo_vounum_Selectedvalue_set = AV8VouNum;
         ucCombo_vounum.SendProperty(context, "", false, Combo_vounum_Internalname, "SelectedValue_set", Combo_vounum_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTASICOD' Routine */
         returnInSub = false;
         /* Using cursor H00654 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1896TASISts = H00654_A1896TASISts[0];
            A126TASICod = H00654_A126TASICod[0];
            A1895TASIDsc = H00654_A1895TASIDsc[0];
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A126TASICod), 6, 0));
            AV17Combo_DataItem.gxTpr_Title = A1895TASIDsc;
            AV15TASICod_Data.Add(AV17Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_tasicod_Selectedvalue_set = ((0==AV7TASICod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV7TASICod), 6, 0)));
         ucCombo_tasicod.SendProperty(context, "", false, Combo_tasicod_Internalname, "SelectedValue_set", Combo_tasicod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E16652( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_90_652( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedccuenta2_Internalname, tblTablemergedccuenta2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuenta2_Internalname, "Cuenta", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuenta2_Internalname, StringUtil.RTrim( AV13cCuenta2), StringUtil.RTrim( context.localUtil.Format( AV13cCuenta2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuenta2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcuenta2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtncuehast_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta Hasta", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtncuehast_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17651_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuedsc2_Internalname, "Descripción de Cuenta", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuedsc2_Internalname, StringUtil.RTrim( AV14cCueDsc2), StringUtil.RTrim( context.localUtil.Format( AV14cCueDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuedsc2_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavCcuedsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_90_652e( true) ;
         }
         else
         {
            wb_table2_90_652e( false) ;
         }
      }

      protected void wb_table1_73_652( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedccuenta1_Internalname, tblTablemergedccuenta1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuenta1_Internalname, "Cuenta", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuenta1_Internalname, StringUtil.RTrim( AV11cCuenta1), StringUtil.RTrim( context.localUtil.Format( AV11cCuenta1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuenta1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcuenta1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtncuedes_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta Desde", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtncuedes_Jsonclick, "'"+""+"'"+",false,"+"'"+"e18651_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuedsc1_Internalname, "Descripción de Cuenta", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuedsc1_Internalname, StringUtil.RTrim( AV12cCueDsc1), StringUtil.RTrim( context.localUtil.Format( AV12cCueDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuedsc1_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavCcuedsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ComprobanteDiario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_73_652e( true) ;
         }
         else
         {
            wb_table1_73_652e( false) ;
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
         PA652( ) ;
         WS652( ) ;
         WE652( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181032161", true, true);
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
         context.AddJavascriptSource("contabilidad/r_comprobantediario.js", "?20228181032161", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavMes.Name = "vMES";
         cmbavMes.WebTags = "";
         cmbavMes.addItem("0", "Apertura", 0);
         cmbavMes.addItem("1", "Enero", 0);
         cmbavMes.addItem("2", "Febrero", 0);
         cmbavMes.addItem("3", "Marzo", 0);
         cmbavMes.addItem("4", "Abril", 0);
         cmbavMes.addItem("5", "Mayo", 0);
         cmbavMes.addItem("6", "Junio", 0);
         cmbavMes.addItem("7", "Julio", 0);
         cmbavMes.addItem("8", "Agosto", 0);
         cmbavMes.addItem("9", "Septiembre", 0);
         cmbavMes.addItem("10", "Octubre", 0);
         cmbavMes.addItem("11", "Noviembre", 0);
         cmbavMes.addItem("12", "Diciembre", 0);
         if ( cmbavMes.ItemCount > 0 )
         {
            AV6Mes = (short)(NumberUtil.Val( cmbavMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6Mes), 2, 0))), "."));
            AssignAttri("", false, "AV6Mes", StringUtil.LTrimStr( (decimal)(AV6Mes), 2, 0));
         }
         radavCopc.Name = "vCOPC";
         radavCopc.WebTags = "";
         radavCopc.addItem("1", "Detallado", 0);
         radavCopc.addItem("2", "Resumido", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockano_Internalname = "TEXTBLOCKANO";
         edtavAno_Internalname = "vANO";
         divUnnamedtableano_Internalname = "UNNAMEDTABLEANO";
         lblTextblockmes_Internalname = "TEXTBLOCKMES";
         cmbavMes_Internalname = "vMES";
         divUnnamedtablemes_Internalname = "UNNAMEDTABLEMES";
         lblTextblockcombo_tasicod_Internalname = "TEXTBLOCKCOMBO_TASICOD";
         Combo_tasicod_Internalname = "COMBO_TASICOD";
         divTablesplittedtasicod_Internalname = "TABLESPLITTEDTASICOD";
         lblTextblockcombo_vounum_Internalname = "TEXTBLOCKCOMBO_VOUNUM";
         Combo_vounum_Internalname = "COMBO_VOUNUM";
         divTablesplittedvounum_Internalname = "TABLESPLITTEDVOUNUM";
         lblTextblockcombo_ccosto_Internalname = "TEXTBLOCKCOMBO_CCOSTO";
         Combo_ccosto_Internalname = "COMBO_CCOSTO";
         divTablesplittedccosto_Internalname = "TABLESPLITTEDCCOSTO";
         lblTextblockcopc_Internalname = "TEXTBLOCKCOPC";
         radavCopc_Internalname = "vCOPC";
         divUnnamedtablecopc_Internalname = "UNNAMEDTABLECOPC";
         lblTextblockccuenta1_Internalname = "TEXTBLOCKCCUENTA1";
         edtavCcuenta1_Internalname = "vCCUENTA1";
         imgBtncuedes_Internalname = "BTNCUEDES";
         edtavCcuedsc1_Internalname = "vCCUEDSC1";
         tblTablemergedccuenta1_Internalname = "TABLEMERGEDCCUENTA1";
         divTablesplittedccuenta1_Internalname = "TABLESPLITTEDCCUENTA1";
         lblTextblockccuenta2_Internalname = "TEXTBLOCKCCUENTA2";
         edtavCcuenta2_Internalname = "vCCUENTA2";
         imgBtncuehast_Internalname = "BTNCUEHAST";
         edtavCcuedsc2_Internalname = "vCCUEDSC2";
         tblTablemergedccuenta2_Internalname = "TABLEMERGEDCCUENTA2";
         divTablesplittedccuenta2_Internalname = "TABLESPLITTEDCCUENTA2";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavTasicod_Internalname = "vTASICOD";
         edtavVounum_Internalname = "vVOUNUM";
         edtavCcosto_Internalname = "vCCOSTO";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavCcuedsc1_Jsonclick = "";
         edtavCcuedsc1_Enabled = 1;
         edtavCcuenta1_Jsonclick = "";
         edtavCcuenta1_Enabled = 1;
         edtavCcuedsc2_Jsonclick = "";
         edtavCcuedsc2_Enabled = 1;
         edtavCcuenta2_Jsonclick = "";
         edtavCcuenta2_Enabled = 1;
         edtavCcosto_Jsonclick = "";
         edtavCcosto_Visible = 1;
         edtavVounum_Jsonclick = "";
         edtavVounum_Visible = 1;
         edtavTasicod_Jsonclick = "";
         edtavTasicod_Visible = 1;
         radavCopc_Jsonclick = "";
         Combo_ccosto_Caption = "";
         Combo_vounum_Caption = "";
         Combo_tasicod_Caption = "";
         cmbavMes_Jsonclick = "";
         cmbavMes.Enabled = 1;
         edtavAno_Jsonclick = "";
         edtavAno_Enabled = 1;
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Libro Diario";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_ccosto_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_vounum_Datalistprocparametersprefix = "";
         Combo_vounum_Datalistproc = "Contabilidad.R_ComprobanteDiarioLoadDVCombo";
         Combo_vounum_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tasicod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Libro Diario";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E14652',iparms:[{av:'AV5Ano',fld:'vANO',pic:'ZZZ9'},{av:'cmbavMes'},{av:'AV6Mes',fld:'vMES',pic:'Z9'},{av:'AV7TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'AV8VouNum',fld:'vVOUNUM',pic:''},{av:'AV9cCosto',fld:'vCCOSTO',pic:''},{av:'AV11cCuenta1',fld:'vCCUENTA1',pic:''},{av:'AV13cCuenta2',fld:'vCCUENTA2',pic:''},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E15652',iparms:[{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNCUEDES'","{handler:'E18651',iparms:[{av:'AV11cCuenta1',fld:'vCCUENTA1',pic:''},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNCUEDES'",",oparms:[{av:'AV12cCueDsc1',fld:'vCCUEDSC1',pic:''},{av:'AV11cCuenta1',fld:'vCCUENTA1',pic:''},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNCUEHAST'","{handler:'E17651',iparms:[{av:'AV13cCuenta2',fld:'vCCUENTA2',pic:''},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNCUEHAST'",",oparms:[{av:'AV14cCueDsc2',fld:'vCCUEDSC2',pic:''},{av:'AV13cCuenta2',fld:'vCCUENTA2',pic:''},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("COMBO_VOUNUM.ONOPTIONCLICKED","{handler:'E12652',iparms:[{av:'Combo_vounum_Selectedvalue_get',ctrl:'COMBO_VOUNUM',prop:'SelectedValue_get'},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("COMBO_VOUNUM.ONOPTIONCLICKED",",oparms:[{av:'AV8VouNum',fld:'vVOUNUM',pic:''},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("COMBO_TASICOD.ONOPTIONCLICKED","{handler:'E11652',iparms:[{av:'AV7TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'Combo_tasicod_Selectedvalue_get',ctrl:'COMBO_TASICOD',prop:'SelectedValue_get'},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("COMBO_TASICOD.ONOPTIONCLICKED",",oparms:[{av:'AV7TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'AV8VouNum',fld:'vVOUNUM',pic:''},{av:'Combo_vounum_Selectedvalue_set',ctrl:'COMBO_VOUNUM',prop:'SelectedValue_set'},{av:'Combo_vounum_Selectedtext_set',ctrl:'COMBO_VOUNUM',prop:'SelectedText_set'},{av:'radavCopc'},{av:'AV10cOpc',fld:'vCOPC',pic:'9'}]}");
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
         Combo_ccosto_Selectedvalue_get = "";
         Combo_vounum_Selectedvalue_get = "";
         Combo_tasicod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15TASICod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18VouNum_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22cCosto_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_tasicod_Selectedvalue_set = "";
         Combo_vounum_Selectedvalue_set = "";
         Combo_vounum_Selectedtext_set = "";
         Combo_ccosto_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockano_Jsonclick = "";
         TempTags = "";
         lblTextblockmes_Jsonclick = "";
         lblTextblockcombo_tasicod_Jsonclick = "";
         ucCombo_tasicod = new GXUserControl();
         lblTextblockcombo_vounum_Jsonclick = "";
         ucCombo_vounum = new GXUserControl();
         lblTextblockcombo_ccosto_Jsonclick = "";
         ucCombo_ccosto = new GXUserControl();
         lblTextblockcopc_Jsonclick = "";
         lblTextblockccuenta1_Jsonclick = "";
         lblTextblockccuenta2_Jsonclick = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV8VouNum = "";
         AV9cCosto = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11cCuenta1 = "";
         AV12cCueDsc1 = "";
         AV13cCuenta2 = "";
         AV14cCueDsc2 = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXEncryptionTmp = "";
         scmdbuf = "";
         H00652_A762COSSts = new short[1] ;
         H00652_A79COSCod = new string[] {""} ;
         H00652_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00653_A127VouAno = new short[1] ;
         H00653_A128VouMes = new short[1] ;
         H00653_A126TASICod = new int[1] ;
         H00653_A129VouNum = new string[] {""} ;
         A129VouNum = "";
         H00654_A1896TASISts = new short[1] ;
         H00654_A126TASICod = new int[1] ;
         H00654_A1895TASIDsc = new string[] {""} ;
         A1895TASIDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtncuehast_Jsonclick = "";
         imgBtncuedes_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_comprobantediario__default(),
            new Object[][] {
                new Object[] {
               H00652_A762COSSts, H00652_A79COSCod, H00652_A761COSDsc
               }
               , new Object[] {
               H00653_A127VouAno, H00653_A128VouMes, H00653_A126TASICod, H00653_A129VouNum
               }
               , new Object[] {
               H00654_A1896TASISts, H00654_A126TASICod, H00654_A1895TASIDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         edtavCcuedsc2_Enabled = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV5Ano ;
      private short AV6Mes ;
      private short AV10cOpc ;
      private short nDonePA ;
      private short A762COSSts ;
      private short AV19Cond_Ano ;
      private short AV20Cond_Mes ;
      private short AV26GXLvl135 ;
      private short A1896TASISts ;
      private short nGXWrapped ;
      private int edtavAno_Enabled ;
      private int AV7TASICod ;
      private int edtavTasicod_Visible ;
      private int edtavVounum_Visible ;
      private int edtavCcosto_Visible ;
      private int edtavCcuedsc1_Enabled ;
      private int edtavCcuedsc2_Enabled ;
      private int AV21Cond_TASICod ;
      private int A126TASICod ;
      private int edtavCcuenta2_Enabled ;
      private int edtavCcuenta1_Enabled ;
      private int idxLst ;
      private string Combo_ccosto_Selectedvalue_get ;
      private string Combo_vounum_Selectedvalue_get ;
      private string Combo_tasicod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_tasicod_Cls ;
      private string Combo_tasicod_Selectedvalue_set ;
      private string Combo_vounum_Cls ;
      private string Combo_vounum_Selectedvalue_set ;
      private string Combo_vounum_Selectedtext_set ;
      private string Combo_vounum_Datalistproc ;
      private string Combo_vounum_Datalistprocparametersprefix ;
      private string Combo_ccosto_Cls ;
      private string Combo_ccosto_Selectedvalue_set ;
      private string Dvpanel_panel1_Width ;
      private string Dvpanel_panel1_Cls ;
      private string Dvpanel_panel1_Title ;
      private string Dvpanel_panel1_Iconposition ;
      private string Innewwindow_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panel1_Internalname ;
      private string divPanel1_Internalname ;
      private string divUnnamedtableano_Internalname ;
      private string lblTextblockano_Internalname ;
      private string lblTextblockano_Jsonclick ;
      private string edtavAno_Internalname ;
      private string TempTags ;
      private string edtavAno_Jsonclick ;
      private string divUnnamedtablemes_Internalname ;
      private string lblTextblockmes_Internalname ;
      private string lblTextblockmes_Jsonclick ;
      private string cmbavMes_Internalname ;
      private string cmbavMes_Jsonclick ;
      private string divTablesplittedtasicod_Internalname ;
      private string lblTextblockcombo_tasicod_Internalname ;
      private string lblTextblockcombo_tasicod_Jsonclick ;
      private string Combo_tasicod_Caption ;
      private string Combo_tasicod_Internalname ;
      private string divTablesplittedvounum_Internalname ;
      private string lblTextblockcombo_vounum_Internalname ;
      private string lblTextblockcombo_vounum_Jsonclick ;
      private string Combo_vounum_Caption ;
      private string Combo_vounum_Internalname ;
      private string divTablesplittedccosto_Internalname ;
      private string lblTextblockcombo_ccosto_Internalname ;
      private string lblTextblockcombo_ccosto_Jsonclick ;
      private string Combo_ccosto_Caption ;
      private string Combo_ccosto_Internalname ;
      private string divUnnamedtablecopc_Internalname ;
      private string lblTextblockcopc_Internalname ;
      private string lblTextblockcopc_Jsonclick ;
      private string radavCopc_Internalname ;
      private string radavCopc_Jsonclick ;
      private string divTablesplittedccuenta1_Internalname ;
      private string lblTextblockccuenta1_Internalname ;
      private string lblTextblockccuenta1_Jsonclick ;
      private string divTablesplittedccuenta2_Internalname ;
      private string lblTextblockccuenta2_Internalname ;
      private string lblTextblockccuenta2_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTasicod_Internalname ;
      private string edtavTasicod_Jsonclick ;
      private string edtavVounum_Internalname ;
      private string AV8VouNum ;
      private string edtavVounum_Jsonclick ;
      private string edtavCcosto_Internalname ;
      private string AV9cCosto ;
      private string edtavCcosto_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavCcuedsc1_Internalname ;
      private string edtavCcuedsc2_Internalname ;
      private string AV11cCuenta1 ;
      private string edtavCcuenta1_Internalname ;
      private string AV12cCueDsc1 ;
      private string AV13cCuenta2 ;
      private string edtavCcuenta2_Internalname ;
      private string AV14cCueDsc2 ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A129VouNum ;
      private string A1895TASIDsc ;
      private string sStyleString ;
      private string tblTablemergedccuenta2_Internalname ;
      private string edtavCcuenta2_Jsonclick ;
      private string sImgUrl ;
      private string imgBtncuehast_Internalname ;
      private string imgBtncuehast_Jsonclick ;
      private string edtavCcuedsc2_Jsonclick ;
      private string tblTablemergedccuenta1_Internalname ;
      private string edtavCcuenta1_Jsonclick ;
      private string imgBtncuedes_Internalname ;
      private string imgBtncuedes_Jsonclick ;
      private string edtavCcuedsc1_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_panel1_Autowidth ;
      private bool Dvpanel_panel1_Autoheight ;
      private bool Dvpanel_panel1_Collapsible ;
      private bool Dvpanel_panel1_Collapsed ;
      private bool Dvpanel_panel1_Showcollapseicon ;
      private bool Dvpanel_panel1_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_tasicod ;
      private GXUserControl ucCombo_vounum ;
      private GXUserControl ucCombo_ccosto ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavMes ;
      private GXRadio radavCopc ;
      private IDataStoreProvider pr_default ;
      private short[] H00652_A762COSSts ;
      private string[] H00652_A79COSCod ;
      private string[] H00652_A761COSDsc ;
      private short[] H00653_A127VouAno ;
      private short[] H00653_A128VouMes ;
      private int[] H00653_A126TASICod ;
      private string[] H00653_A129VouNum ;
      private short[] H00654_A1896TASISts ;
      private int[] H00654_A126TASICod ;
      private string[] H00654_A1895TASIDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15TASICod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18VouNum_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22cCosto_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV17Combo_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class r_comprobantediario__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00652;
          prmH00652 = new Object[] {
          };
          Object[] prmH00653;
          prmH00653 = new Object[] {
          new ParDef("@AV8VouNum",GXType.NChar,10,0)
          };
          Object[] prmH00654;
          prmH00654 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00652", "SELECT [COSSts], [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSSts] = 1 ORDER BY [COSDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00652,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00653", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] WHERE [VouNum] = @AV8VouNum ORDER BY [VouAno], [VouMes], [TASICod], [VouNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00653,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00654", "SELECT [TASISts], [TASICod], [TASIDsc] FROM [CBTIPOASIENTO] WHERE [TASISts] = 1 ORDER BY [TASIDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00654,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
