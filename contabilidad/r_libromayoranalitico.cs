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
   public class r_libromayoranalitico : GXDataArea
   {
      public r_libromayoranalitico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libromayoranalitico( IGxContext context )
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
         radavTipo = new GXRadio();
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
         PA612( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START612( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810315724", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.r_libromayoranalitico.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vCCOSTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6cCosto, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vCCOSTO", StringUtil.RTrim( AV6cCosto));
         GxWebStd.gx_hidden_field( context, "gxhash_vCCOSTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6cCosto, "")), context));
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
            WE612( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT612( ) ;
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
         return formatLink("contabilidad.r_libromayoranalitico.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.R_LibroMayorAnalitico" ;
      }

      public override string GetPgmdesc( )
      {
         return "Libro Mayor Analitico" ;
      }

      protected void WB610( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockano_Internalname, "A?o", "", "", lblTextblockano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAno_Internalname, "Ano", "col-sm-3 AttributeWidthAutoLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Ano), 4, 0, ".", "")), StringUtil.LTrim( ((edtavAno_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Ano), "ZZZ9") : context.localUtil.Format( (decimal)(AV5Ano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAno_Jsonclick, 0, "AttributeWidthAuto", "", "", "", "", 1, edtavAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockmes_Internalname, "Mes", "", "", lblTextblockmes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMes, cmbavMes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15Mes), 2, 0)), 1, cmbavMes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMes.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 1, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            cmbavMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15Mes), 2, 0));
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedccuenta1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockccuenta1_Internalname, "Cuenta Desde", "", "", lblTextblockccuenta1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_42_612( true) ;
         }
         else
         {
            wb_table1_42_612( false) ;
         }
         return  ;
      }

      protected void wb_table1_42_612e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedccuenta2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockccuenta2_Internalname, "Cuenta Hasta", "", "", lblTextblockccuenta2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table2_58_612( true) ;
         }
         else
         {
            wb_table2_58_612( false) ;
         }
         return  ;
      }

      protected void wb_table2_58_612e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTablesplittedtipadcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktipadcod_Internalname, "Auxiliar", "", "", lblTextblocktipadcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table3_75_612( true) ;
         }
         else
         {
            wb_table3_75_612( false) ;
         }
         return  ;
      }

      protected void wb_table3_75_612e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletipo_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktipo_Internalname, "Tipo Reporte", "", "", lblTextblocktipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Tipo", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavTipo, radavTipo_Internalname, StringUtil.RTrim( AV20Tipo), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavTipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Salir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START612( )
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
            Form.Meta.addItem("description", "Libro Mayor Analitico", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP610( ) ;
      }

      protected void WS612( )
      {
         START612( ) ;
         EVT612( ) ;
      }

      protected void EVT612( )
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
                              E11612 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E12612 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E13612 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14612 ();
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

      protected void WE612( )
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

      protected void PA612( )
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
            AV15Mes = (short)(NumberUtil.Val( cmbavMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Mes), 2, 0))), "."));
            AssignAttri("", false, "AV15Mes", StringUtil.LTrimStr( (decimal)(AV15Mes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15Mes), 2, 0));
            AssignProp("", false, cmbavMes_Internalname, "Values", cmbavMes.ToJavascriptSource(), true);
         }
         AV20Tipo = StringUtil.RTrim( AV20Tipo);
         AssignAttri("", false, "AV20Tipo", AV20Tipo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF612( ) ;
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
         edtavTipadsc_Enabled = 0;
         AssignProp("", false, edtavTipadsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTipadsc_Enabled), 5, 0), true);
      }

      protected void RF612( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14612 ();
            WB610( ) ;
         }
      }

      protected void send_integrity_lvl_hashes612( )
      {
         GxWebStd.gx_hidden_field( context, "vCCOSTO", StringUtil.RTrim( AV6cCosto));
         GxWebStd.gx_hidden_field( context, "gxhash_vCCOSTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6cCosto, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         AssignProp("", false, edtavCcuedsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc1_Enabled), 5, 0), true);
         edtavCcuedsc2_Enabled = 0;
         AssignProp("", false, edtavCcuedsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc2_Enabled), 5, 0), true);
         edtavTipadsc_Enabled = 0;
         AssignProp("", false, edtavTipadsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTipadsc_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP610( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11612 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
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
            AV15Mes = (short)(NumberUtil.Val( cgiGet( cmbavMes_Internalname), "."));
            AssignAttri("", false, "AV15Mes", StringUtil.LTrimStr( (decimal)(AV15Mes), 2, 0));
            AV9cCuenta1 = cgiGet( edtavCcuenta1_Internalname);
            AssignAttri("", false, "AV9cCuenta1", AV9cCuenta1);
            AV7cCueDsc1 = cgiGet( edtavCcuedsc1_Internalname);
            AssignAttri("", false, "AV7cCueDsc1", AV7cCueDsc1);
            AV10cCuenta2 = cgiGet( edtavCcuenta2_Internalname);
            AssignAttri("", false, "AV10cCuenta2", AV10cCuenta2);
            AV8cCueDsc2 = cgiGet( edtavCcuedsc2_Internalname);
            AssignAttri("", false, "AV8cCueDsc2", AV8cCueDsc2);
            AV18TipADCod = cgiGet( edtavTipadcod_Internalname);
            AssignAttri("", false, "AV18TipADCod", AV18TipADCod);
            AV19TipADsc = cgiGet( edtavTipadsc_Internalname);
            AssignAttri("", false, "AV19TipADsc", AV19TipADsc);
            AV20Tipo = cgiGet( radavTipo_Internalname);
            AssignAttri("", false, "AV20Tipo", AV20Tipo);
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
         E11612 ();
         if (returnInSub) return;
      }

      protected void E11612( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavCcuedsc1_Enabled = 0;
         AssignProp("", false, edtavCcuedsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc1_Enabled), 5, 0), true);
         edtavCcuedsc2_Enabled = 0;
         AssignProp("", false, edtavCcuedsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc2_Enabled), 5, 0), true);
         edtavTipadsc_Enabled = 0;
         AssignProp("", false, edtavTipadsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTipadsc_Enabled), 5, 0), true);
         AV20Tipo = "D";
         AssignAttri("", false, "AV20Tipo", AV20Tipo);
         AV5Ano = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV5Ano", StringUtil.LTrimStr( (decimal)(AV5Ano), 4, 0));
         AV15Mes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV15Mes", StringUtil.LTrimStr( (decimal)(AV15Mes), 2, 0));
      }

      protected void E12612( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.r_libromayomnresumenpdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV5Ano,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15Mes,2,0)) + "," + UrlEncode(StringUtil.RTrim(AV6cCosto)) + "," + UrlEncode(StringUtil.RTrim(AV9cCuenta1)) + "," + UrlEncode(StringUtil.RTrim(AV10cCuenta2)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim(AV18TipADCod)) + "," + UrlEncode(StringUtil.RTrim(AV20Tipo));
         Innewwindow_Target = formatLink("contabilidad.r_libromayomnresumenpdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E13612( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E14612( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_75_612( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtipadcod_Internalname, tblTablemergedtipadcod_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipadcod_Internalname, "Codigo Auxiliar", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipadcod_Internalname, StringUtil.RTrim( AV18TipADCod), StringUtil.RTrim( context.localUtil.Format( AV18TipADCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipadcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTipadcod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscaraux_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscaraux_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15611_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipadsc_Internalname, "Tipo de Auxiliar", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipadsc_Internalname, StringUtil.RTrim( AV19TipADsc), StringUtil.RTrim( context.localUtil.Format( AV19TipADsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipadsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavTipadsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_75_612e( true) ;
         }
         else
         {
            wb_table3_75_612e( false) ;
         }
      }

      protected void wb_table2_58_612( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuenta2_Internalname, StringUtil.RTrim( AV10cCuenta2), StringUtil.RTrim( context.localUtil.Format( AV10cCuenta2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuenta2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcuenta2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarcue2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarcue2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16611_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuedsc2_Internalname, "Descripci?n de Cuenta", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuedsc2_Internalname, StringUtil.RTrim( AV8cCueDsc2), StringUtil.RTrim( context.localUtil.Format( AV8cCueDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuedsc2_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavCcuedsc2_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_58_612e( true) ;
         }
         else
         {
            wb_table2_58_612e( false) ;
         }
      }

      protected void wb_table1_42_612( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuenta1_Internalname, StringUtil.RTrim( AV9cCuenta1), StringUtil.RTrim( context.localUtil.Format( AV9cCuenta1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuenta1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcuenta1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarcue_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarcue_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17611_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuedsc1_Internalname, "Descripci?n de Cuenta", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuedsc1_Internalname, StringUtil.RTrim( AV7cCueDsc1), StringUtil.RTrim( context.localUtil.Format( AV7cCueDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuedsc1_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavCcuedsc1_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroMayorAnalitico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_42_612e( true) ;
         }
         else
         {
            wb_table1_42_612e( false) ;
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
         PA612( ) ;
         WS612( ) ;
         WE612( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181031583", true, true);
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
         context.AddJavascriptSource("contabilidad/r_libromayoranalitico.js", "?20228181031583", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            AV15Mes = (short)(NumberUtil.Val( cmbavMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Mes), 2, 0))), "."));
            AssignAttri("", false, "AV15Mes", StringUtil.LTrimStr( (decimal)(AV15Mes), 2, 0));
         }
         radavTipo.Name = "vTIPO";
         radavTipo.WebTags = "";
         radavTipo.addItem("D", "Detallado", 0);
         radavTipo.addItem("R", "Resumido", 0);
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
         lblTextblockccuenta1_Internalname = "TEXTBLOCKCCUENTA1";
         edtavCcuenta1_Internalname = "vCCUENTA1";
         imgBtnbuscarcue_Internalname = "BTNBUSCARCUE";
         edtavCcuedsc1_Internalname = "vCCUEDSC1";
         tblTablemergedccuenta1_Internalname = "TABLEMERGEDCCUENTA1";
         divTablesplittedccuenta1_Internalname = "TABLESPLITTEDCCUENTA1";
         lblTextblockccuenta2_Internalname = "TEXTBLOCKCCUENTA2";
         edtavCcuenta2_Internalname = "vCCUENTA2";
         imgBtnbuscarcue2_Internalname = "BTNBUSCARCUE2";
         edtavCcuedsc2_Internalname = "vCCUEDSC2";
         tblTablemergedccuenta2_Internalname = "TABLEMERGEDCCUENTA2";
         divTablesplittedccuenta2_Internalname = "TABLESPLITTEDCCUENTA2";
         lblTextblocktipadcod_Internalname = "TEXTBLOCKTIPADCOD";
         edtavTipadcod_Internalname = "vTIPADCOD";
         imgBtnbuscaraux_Internalname = "BTNBUSCARAUX";
         edtavTipadsc_Internalname = "vTIPADSC";
         tblTablemergedtipadcod_Internalname = "TABLEMERGEDTIPADCOD";
         divTablesplittedtipadcod_Internalname = "TABLESPLITTEDTIPADCOD";
         lblTextblocktipo_Internalname = "TEXTBLOCKTIPO";
         radavTipo_Internalname = "vTIPO";
         divUnnamedtabletipo_Internalname = "UNNAMEDTABLETIPO";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnbtnimprimir_Internalname = "BTNBTNIMPRIMIR";
         bttBtnbtnsalir_Internalname = "BTNBTNSALIR";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
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
         edtavCcuenta1_Jsonclick = "";
         edtavCcuenta1_Enabled = 1;
         edtavCcuedsc2_Jsonclick = "";
         edtavCcuenta2_Jsonclick = "";
         edtavCcuenta2_Enabled = 1;
         edtavTipadsc_Jsonclick = "";
         edtavTipadcod_Jsonclick = "";
         edtavTipadcod_Enabled = 1;
         edtavTipadsc_Enabled = 1;
         edtavCcuedsc2_Enabled = 1;
         edtavCcuedsc1_Enabled = 1;
         radavTipo_Jsonclick = "";
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
         Dvpanel_panel1_Title = "Libro Mayor Analitico";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Libro Mayor Analitico";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV6cCosto',fld:'vCCOSTO',pic:'',hsh:true},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E12612',iparms:[{av:'AV5Ano',fld:'vANO',pic:'ZZZ9'},{av:'cmbavMes'},{av:'AV15Mes',fld:'vMES',pic:'Z9'},{av:'AV6cCosto',fld:'vCCOSTO',pic:'',hsh:true},{av:'AV9cCuenta1',fld:'vCCUENTA1',pic:''},{av:'AV10cCuenta2',fld:'vCCUENTA2',pic:''},{av:'AV18TipADCod',fld:'vTIPADCOD',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E13612',iparms:[{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNBUSCARCUE'","{handler:'E17611',iparms:[{av:'AV9cCuenta1',fld:'vCCUENTA1',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNBUSCARCUE'",",oparms:[{av:'AV7cCueDsc1',fld:'vCCUEDSC1',pic:''},{av:'AV9cCuenta1',fld:'vCCUENTA1',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNBUSCARCUE2'","{handler:'E16611',iparms:[{av:'AV10cCuenta2',fld:'vCCUENTA2',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNBUSCARCUE2'",",oparms:[{av:'AV8cCueDsc2',fld:'vCCUEDSC2',pic:''},{av:'AV10cCuenta2',fld:'vCCUENTA2',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNBUSCARAUX'","{handler:'E15611',iparms:[{av:'AV18TipADCod',fld:'vTIPADCOD',pic:''},{av:'AV19TipADsc',fld:'vTIPADSC',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNBUSCARAUX'",",oparms:[{av:'AV19TipADsc',fld:'vTIPADSC',pic:''},{av:'AV18TipADCod',fld:'vTIPADCOD',pic:''},{av:'radavTipo'},{av:'AV20Tipo',fld:'vTIPO',pic:''}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV6cCosto = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockano_Jsonclick = "";
         TempTags = "";
         lblTextblockmes_Jsonclick = "";
         lblTextblockccuenta1_Jsonclick = "";
         lblTextblockccuenta2_Jsonclick = "";
         lblTextblocktipadcod_Jsonclick = "";
         lblTextblocktipo_Jsonclick = "";
         AV20Tipo = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9cCuenta1 = "";
         AV7cCueDsc1 = "";
         AV10cCuenta2 = "";
         AV8cCueDsc2 = "";
         AV18TipADCod = "";
         AV19TipADsc = "";
         GXEncryptionTmp = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscaraux_Jsonclick = "";
         imgBtnbuscarcue2_Jsonclick = "";
         imgBtnbuscarcue_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         edtavCcuedsc2_Enabled = 0;
         edtavTipadsc_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV5Ano ;
      private short AV15Mes ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavAno_Enabled ;
      private int edtavCcuedsc1_Enabled ;
      private int edtavCcuedsc2_Enabled ;
      private int edtavTipadsc_Enabled ;
      private int edtavTipadcod_Enabled ;
      private int edtavCcuenta2_Enabled ;
      private int edtavCcuenta1_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV6cCosto ;
      private string GXKey ;
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
      private string divTablesplittedccuenta1_Internalname ;
      private string lblTextblockccuenta1_Internalname ;
      private string lblTextblockccuenta1_Jsonclick ;
      private string divTablesplittedccuenta2_Internalname ;
      private string lblTextblockccuenta2_Internalname ;
      private string lblTextblockccuenta2_Jsonclick ;
      private string divTablesplittedtipadcod_Internalname ;
      private string lblTextblocktipadcod_Internalname ;
      private string lblTextblocktipadcod_Jsonclick ;
      private string divUnnamedtabletipo_Internalname ;
      private string lblTextblocktipo_Internalname ;
      private string lblTextblocktipo_Jsonclick ;
      private string radavTipo_Internalname ;
      private string AV20Tipo ;
      private string radavTipo_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavCcuedsc1_Internalname ;
      private string edtavCcuedsc2_Internalname ;
      private string edtavTipadsc_Internalname ;
      private string AV9cCuenta1 ;
      private string edtavCcuenta1_Internalname ;
      private string AV7cCueDsc1 ;
      private string AV10cCuenta2 ;
      private string edtavCcuenta2_Internalname ;
      private string AV8cCueDsc2 ;
      private string AV18TipADCod ;
      private string edtavTipadcod_Internalname ;
      private string AV19TipADsc ;
      private string GXEncryptionTmp ;
      private string sStyleString ;
      private string tblTablemergedtipadcod_Internalname ;
      private string edtavTipadcod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscaraux_Internalname ;
      private string imgBtnbuscaraux_Jsonclick ;
      private string edtavTipadsc_Jsonclick ;
      private string tblTablemergedccuenta2_Internalname ;
      private string edtavCcuenta2_Jsonclick ;
      private string imgBtnbuscarcue2_Internalname ;
      private string imgBtnbuscarcue2_Jsonclick ;
      private string edtavCcuedsc2_Jsonclick ;
      private string tblTablemergedccuenta1_Internalname ;
      private string edtavCcuenta1_Jsonclick ;
      private string imgBtnbuscarcue_Internalname ;
      private string imgBtnbuscarcue_Jsonclick ;
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
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavMes ;
      private GXRadio radavTipo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
