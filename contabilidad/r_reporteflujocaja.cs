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
   public class r_reporteflujocaja : GXDataArea
   {
      public r_reporteflujocaja( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteflujocaja( IGxContext context )
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
         cmbavJmes = new GXCombobox();
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
         PA532( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START532( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181031259", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.r_reporteflujocaja.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMONCOD_DATA", AV18MonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMONCOD_DATA", AV18MonCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSCOD_DATA", AV8COScod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSCOD_DATA", AV8COScod_Data);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Cls", StringUtil.RTrim( Combo_moncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_moncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Emptyitem", StringUtil.BoolToStr( Combo_moncod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCOD_Cls", StringUtil.RTrim( Combo_coscod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCOD_Selectedvalue_set", StringUtil.RTrim( Combo_coscod_Selectedvalue_set));
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
         GxWebStd.gx_hidden_field( context, "COMBO_COSCOD_Selectedvalue_get", StringUtil.RTrim( Combo_coscod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_get", StringUtil.RTrim( Combo_moncod_Selectedvalue_get));
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
            WE532( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT532( ) ;
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
         return formatLink("contabilidad.r_reporteflujocaja.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.R_ReporteFlujoCaja" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reporte de Flujo de Caja" ;
      }

      protected void WB530( )
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
            GxWebStd.gx_div_start( context, divUnnamedtablejano_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockjano_Internalname, "A�o", "", "", lblTextblockjano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavJano_Internalname, "j Ano", "col-sm-3 AttributeWidthAutoLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavJano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16jAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtavJano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16jAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV16jAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavJano_Jsonclick, 0, "AttributeWidthAuto", "", "", "", "", 1, edtavJano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablejmes_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockjmes_Internalname, "Mes", "", "", lblTextblockjmes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavJmes_Internalname, "j Mes", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavJmes, cmbavJmes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17jMes), 2, 0)), 1, cmbavJmes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavJmes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 1, "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            cmbavJmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17jMes), 2, 0));
            AssignProp("", false, cmbavJmes_Internalname, "Values", (string)(cmbavJmes.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTablesplittedmoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_moncod_Internalname, "Moneda", "", "", lblTextblockcombo_moncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_moncod.SetProperty("Caption", Combo_moncod_Caption);
            ucCombo_moncod.SetProperty("Cls", Combo_moncod_Cls);
            ucCombo_moncod.SetProperty("EmptyItem", Combo_moncod_Emptyitem);
            ucCombo_moncod.SetProperty("DropDownOptionsData", AV18MonCod_Data);
            ucCombo_moncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_moncod_Internalname, "COMBO_MONCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcoscod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_coscod_Internalname, "Centro de Costos", "", "", lblTextblockcombo_coscod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_coscod.SetProperty("Caption", Combo_coscod_Caption);
            ucCombo_coscod.SetProperty("Cls", Combo_coscod_Cls);
            ucCombo_coscod.SetProperty("DropDownOptionsData", AV8COScod_Data);
            ucCombo_coscod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_coscod_Internalname, "COMBO_COSCODContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Salir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12MonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12MonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavMoncod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCoscod_Internalname, StringUtil.RTrim( AV7COScod), StringUtil.RTrim( context.localUtil.Format( AV7COScod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCoscod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCoscod_Visible, 1, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_ReporteFlujoCaja.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START532( )
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
            Form.Meta.addItem("description", "Reporte de Flujo de Caja", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP530( ) ;
      }

      protected void WS532( )
      {
         START532( ) ;
         EVT532( ) ;
      }

      protected void EVT532( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11532 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E12532 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E13532 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14532 ();
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

      protected void WE532( )
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

      protected void PA532( )
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
               GX_FocusControl = edtavJano_Internalname;
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
         if ( cmbavJmes.ItemCount > 0 )
         {
            AV17jMes = (short)(NumberUtil.Val( cmbavJmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17jMes), 2, 0))), "."));
            AssignAttri("", false, "AV17jMes", StringUtil.LTrimStr( (decimal)(AV17jMes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavJmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17jMes), 2, 0));
            AssignProp("", false, cmbavJmes_Internalname, "Values", cmbavJmes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF532( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF532( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14532 ();
            WB530( ) ;
         }
      }

      protected void send_integrity_lvl_hashes532( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP530( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11532 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMONCOD_DATA"), AV18MonCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCOSCOD_DATA"), AV8COScod_Data);
            /* Read saved values. */
            Combo_moncod_Cls = cgiGet( "COMBO_MONCOD_Cls");
            Combo_moncod_Selectedvalue_set = cgiGet( "COMBO_MONCOD_Selectedvalue_set");
            Combo_moncod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Emptyitem"));
            Combo_coscod_Cls = cgiGet( "COMBO_COSCOD_Cls");
            Combo_coscod_Selectedvalue_set = cgiGet( "COMBO_COSCOD_Selectedvalue_set");
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
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavJano_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavJano_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vJANO");
               GX_FocusControl = edtavJano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16jAno = 0;
               AssignAttri("", false, "AV16jAno", StringUtil.LTrimStr( (decimal)(AV16jAno), 4, 0));
            }
            else
            {
               AV16jAno = (short)(context.localUtil.CToN( cgiGet( edtavJano_Internalname), ".", ","));
               AssignAttri("", false, "AV16jAno", StringUtil.LTrimStr( (decimal)(AV16jAno), 4, 0));
            }
            cmbavJmes.CurrentValue = cgiGet( cmbavJmes_Internalname);
            AV17jMes = (short)(NumberUtil.Val( cgiGet( cmbavJmes_Internalname), "."));
            AssignAttri("", false, "AV17jMes", StringUtil.LTrimStr( (decimal)(AV17jMes), 2, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMONCOD");
               GX_FocusControl = edtavMoncod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12MonCod = 0;
               AssignAttri("", false, "AV12MonCod", StringUtil.LTrimStr( (decimal)(AV12MonCod), 6, 0));
            }
            else
            {
               AV12MonCod = (int)(context.localUtil.CToN( cgiGet( edtavMoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV12MonCod", StringUtil.LTrimStr( (decimal)(AV12MonCod), 6, 0));
            }
            AV7COScod = cgiGet( edtavCoscod_Internalname);
            AssignAttri("", false, "AV7COScod", AV7COScod);
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
         E11532 ();
         if (returnInSub) return;
      }

      protected void E11532( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavCoscod_Visible = 0;
         AssignProp("", false, edtavCoscod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCoscod_Visible), 5, 0), true);
         edtavMoncod_Visible = 0;
         AssignProp("", false, edtavMoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMoncod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMONCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOSCOD' */
         S122 ();
         if (returnInSub) return;
         AV16jAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV16jAno", StringUtil.LTrimStr( (decimal)(AV16jAno), 4, 0));
         AV17jMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV17jMes", StringUtil.LTrimStr( (decimal)(AV17jMes), 2, 0));
      }

      protected void E12532( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.r_flujocajapdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV16jAno,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV17jMes,2,0)) + "," + UrlEncode(StringUtil.RTrim(AV7COScod)) + "," + UrlEncode(StringUtil.LTrimStr(AV12MonCod,6,0));
         Innewwindow_Target = formatLink("contabilidad.r_flujocajapdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E13532( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCOSCOD' Routine */
         returnInSub = false;
         /* Using cursor H00532 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A762COSSts = H00532_A762COSSts[0];
            A79COSCod = H00532_A79COSCod[0];
            A761COSDsc = H00532_A761COSDsc[0];
            AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV6Combo_DataItem.gxTpr_Id = A79COSCod;
            AV6Combo_DataItem.gxTpr_Title = A761COSDsc;
            AV8COScod_Data.Add(AV6Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_coscod_Selectedvalue_set = AV7COScod;
         ucCombo_coscod.SendProperty(context, "", false, Combo_coscod_Internalname, "SelectedValue_set", Combo_coscod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOMONCOD' Routine */
         returnInSub = false;
         /* Using cursor H00533 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1235MonSts = H00533_A1235MonSts[0];
            A180MonCod = H00533_A180MonCod[0];
            A1234MonDsc = H00533_A1234MonDsc[0];
            AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
            AV6Combo_DataItem.gxTpr_Title = A1234MonDsc;
            AV18MonCod_Data.Add(AV6Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_moncod_Selectedvalue_set = ((0==AV12MonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV12MonCod), 6, 0)));
         ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedValue_set", Combo_moncod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E14532( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA532( ) ;
         WS532( ) ;
         WE532( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810312620", true, true);
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
         context.AddJavascriptSource("contabilidad/r_reporteflujocaja.js", "?202281810312620", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         cmbavJmes.Name = "vJMES";
         cmbavJmes.WebTags = "";
         cmbavJmes.addItem("1", "Enero", 0);
         cmbavJmes.addItem("2", "Febrero", 0);
         cmbavJmes.addItem("3", "Marzo", 0);
         cmbavJmes.addItem("4", "Abril", 0);
         cmbavJmes.addItem("5", "Mayo", 0);
         cmbavJmes.addItem("6", "Junio", 0);
         cmbavJmes.addItem("7", "Julio", 0);
         cmbavJmes.addItem("8", "Agosto", 0);
         cmbavJmes.addItem("9", "Septiembre", 0);
         cmbavJmes.addItem("10", "Octubre", 0);
         cmbavJmes.addItem("11", "Noviembre", 0);
         cmbavJmes.addItem("12", "Diciembre", 0);
         cmbavJmes.addItem("13", "Cierre", 0);
         if ( cmbavJmes.ItemCount > 0 )
         {
            AV17jMes = (short)(NumberUtil.Val( cmbavJmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17jMes), 2, 0))), "."));
            AssignAttri("", false, "AV17jMes", StringUtil.LTrimStr( (decimal)(AV17jMes), 2, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockjano_Internalname = "TEXTBLOCKJANO";
         edtavJano_Internalname = "vJANO";
         divUnnamedtablejano_Internalname = "UNNAMEDTABLEJANO";
         lblTextblockjmes_Internalname = "TEXTBLOCKJMES";
         cmbavJmes_Internalname = "vJMES";
         divUnnamedtablejmes_Internalname = "UNNAMEDTABLEJMES";
         lblTextblockcombo_moncod_Internalname = "TEXTBLOCKCOMBO_MONCOD";
         Combo_moncod_Internalname = "COMBO_MONCOD";
         divTablesplittedmoncod_Internalname = "TABLESPLITTEDMONCOD";
         lblTextblockcombo_coscod_Internalname = "TEXTBLOCKCOMBO_COSCOD";
         Combo_coscod_Internalname = "COMBO_COSCOD";
         divTablesplittedcoscod_Internalname = "TABLESPLITTEDCOSCOD";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavMoncod_Internalname = "vMONCOD";
         edtavCoscod_Internalname = "vCOSCOD";
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
         edtavCoscod_Jsonclick = "";
         edtavCoscod_Visible = 1;
         edtavMoncod_Jsonclick = "";
         edtavMoncod_Visible = 1;
         cmbavJmes_Jsonclick = "";
         cmbavJmes.Enabled = 1;
         edtavJano_Jsonclick = "";
         edtavJano_Enabled = 1;
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Reporte de Flujo de Caja";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_coscod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_moncod_Emptyitem = Convert.ToBoolean( 0);
         Combo_moncod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Reporte de Flujo de Caja";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E12532',iparms:[{av:'AV16jAno',fld:'vJANO',pic:'ZZZ9'},{av:'cmbavJmes'},{av:'AV17jMes',fld:'vJMES',pic:'Z9'},{av:'AV7COScod',fld:'vCOSCOD',pic:''},{av:'AV12MonCod',fld:'vMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E13532',iparms:[]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[]}");
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
         Combo_coscod_Selectedvalue_get = "";
         Combo_moncod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18MonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV8COScod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_moncod_Selectedvalue_set = "";
         Combo_coscod_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockjano_Jsonclick = "";
         TempTags = "";
         lblTextblockjmes_Jsonclick = "";
         lblTextblockcombo_moncod_Jsonclick = "";
         ucCombo_moncod = new GXUserControl();
         Combo_moncod_Caption = "";
         lblTextblockcombo_coscod_Jsonclick = "";
         ucCombo_coscod = new GXUserControl();
         Combo_coscod_Caption = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         AV7COScod = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXEncryptionTmp = "";
         scmdbuf = "";
         H00532_A762COSSts = new short[1] ;
         H00532_A79COSCod = new string[] {""} ;
         H00532_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00533_A1235MonSts = new short[1] ;
         H00533_A180MonCod = new int[1] ;
         H00533_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_reporteflujocaja__default(),
            new Object[][] {
                new Object[] {
               H00532_A762COSSts, H00532_A79COSCod, H00532_A761COSDsc
               }
               , new Object[] {
               H00533_A1235MonSts, H00533_A180MonCod, H00533_A1234MonDsc
               }
            }
         );
         AV12MonCod = 1;
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

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
      private short AV16jAno ;
      private short AV17jMes ;
      private short nDonePA ;
      private short A762COSSts ;
      private short A1235MonSts ;
      private short nGXWrapped ;
      private int edtavJano_Enabled ;
      private int AV12MonCod ;
      private int edtavMoncod_Visible ;
      private int edtavCoscod_Visible ;
      private int A180MonCod ;
      private int idxLst ;
      private string Combo_coscod_Selectedvalue_get ;
      private string Combo_moncod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_moncod_Cls ;
      private string Combo_moncod_Selectedvalue_set ;
      private string Combo_coscod_Cls ;
      private string Combo_coscod_Selectedvalue_set ;
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
      private string divUnnamedtablejano_Internalname ;
      private string lblTextblockjano_Internalname ;
      private string lblTextblockjano_Jsonclick ;
      private string edtavJano_Internalname ;
      private string TempTags ;
      private string edtavJano_Jsonclick ;
      private string divUnnamedtablejmes_Internalname ;
      private string lblTextblockjmes_Internalname ;
      private string lblTextblockjmes_Jsonclick ;
      private string cmbavJmes_Internalname ;
      private string cmbavJmes_Jsonclick ;
      private string divTablesplittedmoncod_Internalname ;
      private string lblTextblockcombo_moncod_Internalname ;
      private string lblTextblockcombo_moncod_Jsonclick ;
      private string Combo_moncod_Caption ;
      private string Combo_moncod_Internalname ;
      private string divTablesplittedcoscod_Internalname ;
      private string lblTextblockcombo_coscod_Internalname ;
      private string lblTextblockcombo_coscod_Jsonclick ;
      private string Combo_coscod_Caption ;
      private string Combo_coscod_Internalname ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavMoncod_Internalname ;
      private string edtavMoncod_Jsonclick ;
      private string edtavCoscod_Internalname ;
      private string AV7COScod ;
      private string edtavCoscod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A1234MonDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Combo_moncod_Emptyitem ;
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
      private GXUserControl ucCombo_moncod ;
      private GXUserControl ucCombo_coscod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavJmes ;
      private IDataStoreProvider pr_default ;
      private short[] H00532_A762COSSts ;
      private string[] H00532_A79COSCod ;
      private string[] H00532_A761COSDsc ;
      private short[] H00533_A1235MonSts ;
      private int[] H00533_A180MonCod ;
      private string[] H00533_A1234MonDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18MonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV8COScod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV6Combo_DataItem ;
   }

   public class r_reporteflujocaja__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00532;
          prmH00532 = new Object[] {
          };
          Object[] prmH00533;
          prmH00533 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00532", "SELECT [COSSts], [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSSts] = 1 ORDER BY [COSDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00532,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00533", "SELECT [MonSts], [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonSts] = 1 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00533,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}