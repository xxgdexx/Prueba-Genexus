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
   public class r_registroinventariopermanentevalorizado : GXDataArea
   {
      public r_registroinventariopermanentevalorizado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroinventariopermanentevalorizado( IGxContext context )
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
         dynavAlmcod = new GXCombobox();
         cmbavCmes = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vALMCOD") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvALMCOD5X2( ) ;
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
         PA5X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181031561", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.r_registroinventariopermanentevalorizado.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vOPCENTRADA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21OpcEntrada), "9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLINCOD_DATA", AV20LinCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLINCOD_DATA", AV20LinCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUBLCOD_DATA", AV23SublCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUBLCOD_DATA", AV23SublCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAMCOD_DATA", AV17FamCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAMCOD_DATA", AV17FamCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vOPCENTRADA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21OpcEntrada), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPCENTRADA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21OpcEntrada), "9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Cls", StringUtil.RTrim( Combo_lincod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_set", StringUtil.RTrim( Combo_lincod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Cls", StringUtil.RTrim( Combo_sublcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_set", StringUtil.RTrim( Combo_sublcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Cls", StringUtil.RTrim( Combo_famcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Selectedvalue_set", StringUtil.RTrim( Combo_famcod_Selectedvalue_set));
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
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Selectedvalue_get", StringUtil.RTrim( Combo_famcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_get", StringUtil.RTrim( Combo_sublcod_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_get", StringUtil.RTrim( Combo_lincod_Selectedvalue_get));
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
            WE5X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5X2( ) ;
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
         return formatLink("contabilidad.r_registroinventariopermanentevalorizado.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.R_RegistroInventarioPermanenteValorizado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Registro de Inventario Permanente Valorizado" ;
      }

      protected void WB5X0( )
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
            GxWebStd.gx_div_start( context, divUnnamedtablealmcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockalmcod_Internalname, "Almacen", "", "", lblTextblockalmcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavAlmcod_Internalname, "Codigo Almacen", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavAlmcod, dynavAlmcod_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10AlmCod), 6, 0)), 1, dynavAlmcod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavAlmcod.Visible, dynavAlmcod.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 1, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            dynavAlmcod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10AlmCod), 6, 0));
            AssignProp("", false, dynavAlmcod_Internalname, "Values", (string)(dynavAlmcod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlincod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_lincod_Internalname, "Línea Producto", "", "", lblTextblockcombo_lincod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_lincod.SetProperty("Caption", Combo_lincod_Caption);
            ucCombo_lincod.SetProperty("Cls", Combo_lincod_Cls);
            ucCombo_lincod.SetProperty("DropDownOptionsData", AV20LinCod_Data);
            ucCombo_lincod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_lincod_Internalname, "COMBO_LINCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsublcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sublcod_Internalname, "Sub LÍnea", "", "", lblTextblockcombo_sublcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sublcod.SetProperty("Caption", Combo_sublcod_Caption);
            ucCombo_sublcod.SetProperty("Cls", Combo_sublcod_Cls);
            ucCombo_sublcod.SetProperty("DropDownOptionsData", AV23SublCod_Data);
            ucCombo_sublcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sublcod_Internalname, "COMBO_SUBLCODContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfamcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_famcod_Internalname, "Familia", "", "", lblTextblockcombo_famcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_famcod.SetProperty("Caption", Combo_famcod_Caption);
            ucCombo_famcod.SetProperty("Cls", Combo_famcod_Cls);
            ucCombo_famcod.SetProperty("DropDownOptionsData", AV17FamCod_Data);
            ucCombo_famcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_famcod_Internalname, "COMBO_FAMCODContainer");
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
            GxWebStd.gx_div_start( context, divTablesplittedprodcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, "Producto", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_56_5X2( true) ;
         }
         else
         {
            wb_table1_56_5X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_56_5X2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divUnnamedtablecano_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcano_Internalname, "Año", "", "", lblTextblockcano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCano_Internalname, "c Ano", "col-sm-3 AttributeWidthAutoLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18cAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18cAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV18cAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCano_Jsonclick, 0, "AttributeWidthAuto", "", "", "", "", 1, edtavCano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtablecmes_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcmes_Internalname, "Mes", "", "", lblTextblockcmes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmes_Internalname, "c Mes", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmes, cmbavCmes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19cMes), 2, 0)), 1, cmbavCmes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavCmes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "", true, 1, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            cmbavCmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19cMes), 2, 0));
            AssignProp("", false, cmbavCmes_Internalname, "Values", (string)(cmbavCmes.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocktipo_Internalname, "Tipo Reporte", "", "", lblTextblocktipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavTipo, radavTipo_Internalname, StringUtil.RTrim( AV9Tipo), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavTipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Salir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLincod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11LinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLincod_Jsonclick, 0, "Attribute", "", "", "", "", edtavLincod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSublcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12SublCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12SublCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSublcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavSublcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFamcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13FamCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13FamCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFamcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavFamcod_Visible, 1, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5X2( )
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
            Form.Meta.addItem("description", "Registro de Inventario Permanente Valorizado", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5X0( ) ;
      }

      protected void WS5X2( )
      {
         START5X2( ) ;
         EVT5X2( ) ;
      }

      protected void EVT5X2( )
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
                              E115X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E125X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E135X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E145X2 ();
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

      protected void WE5X2( )
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

      protected void PA5X2( )
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
               GX_FocusControl = dynavAlmcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvALMCOD5X2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvALMCOD_data5X2( ) ;
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

      protected void GXVvALMCOD_html5X2( )
      {
         int gxdynajaxvalue;
         GXDLVvALMCOD_data5X2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavAlmcod.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavAlmcod.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvALMCOD_data5X2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005X2_A63AlmCod[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005X2_A436AlmDsc[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvALMCOD_html5X2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavAlmcod.ItemCount > 0 )
         {
            AV10AlmCod = (int)(NumberUtil.Val( dynavAlmcod.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10AlmCod), 6, 0))), "."));
            AssignAttri("", false, "AV10AlmCod", StringUtil.LTrimStr( (decimal)(AV10AlmCod), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavAlmcod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10AlmCod), 6, 0));
            AssignProp("", false, dynavAlmcod_Internalname, "Values", dynavAlmcod.ToJavascriptSource(), true);
         }
         if ( cmbavCmes.ItemCount > 0 )
         {
            AV19cMes = (short)(NumberUtil.Val( cmbavCmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19cMes), 2, 0))), "."));
            AssignAttri("", false, "AV19cMes", StringUtil.LTrimStr( (decimal)(AV19cMes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19cMes), 2, 0));
            AssignProp("", false, cmbavCmes_Internalname, "Values", cmbavCmes.ToJavascriptSource(), true);
         }
         AV9Tipo = StringUtil.RTrim( AV9Tipo);
         AssignAttri("", false, "AV9Tipo", AV9Tipo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5X2( ) ;
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
      }

      protected void RF5X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E145X2 ();
            WB5X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5X2( )
      {
         GxWebStd.gx_hidden_field( context, "vOPCENTRADA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21OpcEntrada), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPCENTRADA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21OpcEntrada), "9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
         AssignProp("", false, edtavProddsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProddsc_Enabled), 5, 0), true);
         GXVvALMCOD_html5X2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLINCOD_DATA"), AV20LinCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSUBLCOD_DATA"), AV23SublCod_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vFAMCOD_DATA"), AV17FamCod_Data);
            /* Read saved values. */
            Combo_lincod_Cls = cgiGet( "COMBO_LINCOD_Cls");
            Combo_lincod_Selectedvalue_set = cgiGet( "COMBO_LINCOD_Selectedvalue_set");
            Combo_sublcod_Cls = cgiGet( "COMBO_SUBLCOD_Cls");
            Combo_sublcod_Selectedvalue_set = cgiGet( "COMBO_SUBLCOD_Selectedvalue_set");
            Combo_famcod_Cls = cgiGet( "COMBO_FAMCOD_Cls");
            Combo_famcod_Selectedvalue_set = cgiGet( "COMBO_FAMCOD_Selectedvalue_set");
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
            dynavAlmcod.CurrentValue = cgiGet( dynavAlmcod_Internalname);
            AV10AlmCod = (int)(NumberUtil.Val( cgiGet( dynavAlmcod_Internalname), "."));
            AssignAttri("", false, "AV10AlmCod", StringUtil.LTrimStr( (decimal)(AV10AlmCod), 6, 0));
            AV14ProdCod = StringUtil.Upper( cgiGet( edtavProdcod_Internalname));
            AssignAttri("", false, "AV14ProdCod", AV14ProdCod);
            AV15ProdDsc = cgiGet( edtavProddsc_Internalname);
            AssignAttri("", false, "AV15ProdDsc", AV15ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCano_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCano_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCANO");
               GX_FocusControl = edtavCano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18cAno = 0;
               AssignAttri("", false, "AV18cAno", StringUtil.LTrimStr( (decimal)(AV18cAno), 4, 0));
            }
            else
            {
               AV18cAno = (short)(context.localUtil.CToN( cgiGet( edtavCano_Internalname), ".", ","));
               AssignAttri("", false, "AV18cAno", StringUtil.LTrimStr( (decimal)(AV18cAno), 4, 0));
            }
            cmbavCmes.CurrentValue = cgiGet( cmbavCmes_Internalname);
            AV19cMes = (short)(NumberUtil.Val( cgiGet( cmbavCmes_Internalname), "."));
            AssignAttri("", false, "AV19cMes", StringUtil.LTrimStr( (decimal)(AV19cMes), 2, 0));
            AV9Tipo = cgiGet( radavTipo_Internalname);
            AssignAttri("", false, "AV9Tipo", AV9Tipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLINCOD");
               GX_FocusControl = edtavLincod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11LinCod = 0;
               AssignAttri("", false, "AV11LinCod", StringUtil.LTrimStr( (decimal)(AV11LinCod), 6, 0));
            }
            else
            {
               AV11LinCod = (int)(context.localUtil.CToN( cgiGet( edtavLincod_Internalname), ".", ","));
               AssignAttri("", false, "AV11LinCod", StringUtil.LTrimStr( (decimal)(AV11LinCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSUBLCOD");
               GX_FocusControl = edtavSublcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12SublCod = 0;
               AssignAttri("", false, "AV12SublCod", StringUtil.LTrimStr( (decimal)(AV12SublCod), 6, 0));
            }
            else
            {
               AV12SublCod = (int)(context.localUtil.CToN( cgiGet( edtavSublcod_Internalname), ".", ","));
               AssignAttri("", false, "AV12SublCod", StringUtil.LTrimStr( (decimal)(AV12SublCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFAMCOD");
               GX_FocusControl = edtavFamcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13FamCod = 0;
               AssignAttri("", false, "AV13FamCod", StringUtil.LTrimStr( (decimal)(AV13FamCod), 6, 0));
            }
            else
            {
               AV13FamCod = (int)(context.localUtil.CToN( cgiGet( edtavFamcod_Internalname), ".", ","));
               AssignAttri("", false, "AV13FamCod", StringUtil.LTrimStr( (decimal)(AV13FamCod), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXVvALMCOD_html5X2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E115X2 ();
         if (returnInSub) return;
      }

      protected void E115X2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavFamcod_Visible = 0;
         AssignProp("", false, edtavFamcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFamcod_Visible), 5, 0), true);
         edtavSublcod_Visible = 0;
         AssignProp("", false, edtavSublcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSublcod_Visible), 5, 0), true);
         edtavLincod_Visible = 0;
         AssignProp("", false, edtavLincod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLincod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLINCOD' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUBLCOD' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOFAMCOD' */
         S132 ();
         if (returnInSub) return;
         AV18cAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV18cAno", StringUtil.LTrimStr( (decimal)(AV18cAno), 4, 0));
         AV19cMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV19cMes", StringUtil.LTrimStr( (decimal)(AV19cMes), 2, 0));
         AV9Tipo = "V";
         AssignAttri("", false, "AV9Tipo", AV9Tipo);
         if ( AV21OpcEntrada == 0 )
         {
            dynavAlmcod.Visible = 1;
            AssignProp("", false, dynavAlmcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavAlmcod.Visible), 5, 0), true);
         }
      }

      protected void E125X2( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         AV32Flag = 0;
         AV27FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV19cMes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV18cAno), 10, 0));
         AV25FDesde = context.localUtil.CToD( AV27FechaC, 2);
         AV28Mes2 = (short)(((AV19cMes==12) ? 1 : AV19cMes+1));
         AV29Ano2 = (short)(((AV19cMes==12) ? AV18cAno+1 : AV18cAno));
         AV27FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV28Mes2), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV29Ano2), 10, 0));
         AV26FHasta = DateTimeUtil.DAdd(context.localUtil.CToD( AV27FechaC, 2),-((int)(1)));
         if ( AV21OpcEntrada == 0 )
         {
            if ( (0==AV10AlmCod) )
            {
               GX_msglist.addItem("Falta seleccionar el almacen");
               AV32Flag = 1;
            }
            if ( AV32Flag == 0 )
            {
               if ( StringUtil.StrCmp(AV9Tipo, "V") == 0 )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "contabilidad.r_arreginventariovalorizadopdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV11LinCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12SublCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13FamCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10AlmCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV14ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV25FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV26FHasta));
                  AV24URL = formatLink("contabilidad.r_arreginventariovalorizadopdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  Innewwindow_Target = AV24URL;
                  ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
                  this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
               }
               else
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "contabilidad.r_arreginventariovalorizadohpdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV11LinCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12SublCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13FamCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10AlmCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV14ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV25FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV26FHasta));
                  AV24URL = formatLink("contabilidad.r_arreginventariovalorizadohpdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  Innewwindow_Target = AV24URL;
                  ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
                  this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
               }
            }
         }
         else
         {
            if ( StringUtil.StrCmp(AV9Tipo, "V") == 0 )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "contabilidad.r_registroinventariovalorizadopdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV11LinCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12SublCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13FamCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV14ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV25FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV26FHasta));
               AV24URL = formatLink("contabilidad.r_registroinventariovalorizadopdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               Innewwindow_Target = AV24URL;
               ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
               this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
            }
            else
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "contabilidad.r_registroinventariovalorizadohpdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV11LinCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12SublCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13FamCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV14ProdCod)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV25FDesde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV26FHasta));
               AV24URL = formatLink("contabilidad.r_registroinventariovalorizadohpdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               Innewwindow_Target = AV24URL;
               ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
               this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E135X2( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADCOMBOFAMCOD' Routine */
         returnInSub = false;
         /* Using cursor H005X3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A979FamSts = H005X3_A979FamSts[0];
            A50FamCod = H005X3_A50FamCod[0];
            A977FamDsc = H005X3_A977FamDsc[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 6, 0));
            AV16Combo_DataItem.gxTpr_Title = A977FamDsc;
            AV17FamCod_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_famcod_Selectedvalue_set = ((0==AV13FamCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV13FamCod), 6, 0)));
         ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedValue_set", Combo_famcod_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUBLCOD' Routine */
         returnInSub = false;
         /* Using cursor H005X4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1893SublSts = H005X4_A1893SublSts[0];
            A51SublCod = H005X4_A51SublCod[0];
            A1892SublDsc = H005X4_A1892SublDsc[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 6, 0));
            AV16Combo_DataItem.gxTpr_Title = A1892SublDsc;
            AV23SublCod_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_sublcod_Selectedvalue_set = ((0==AV12SublCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV12SublCod), 6, 0)));
         ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedValue_set", Combo_sublcod_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLINCOD' Routine */
         returnInSub = false;
         /* Using cursor H005X5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1159LinSts = H005X5_A1159LinSts[0];
            A52LinCod = H005X5_A52LinCod[0];
            A1153LinDsc = H005X5_A1153LinDsc[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0));
            AV16Combo_DataItem.gxTpr_Title = A1153LinDsc;
            AV20LinCod_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_lincod_Selectedvalue_set = ((0==AV11LinCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV11LinCod), 6, 0)));
         ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedValue_set", Combo_lincod_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E145X2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_56_5X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcod_Internalname, StringUtil.RTrim( AV14ProdCod), StringUtil.RTrim( context.localUtil.Format( AV14ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProdcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarpro_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Producto", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarpro_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc_Internalname, "Descripcion producto", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc_Internalname, StringUtil.RTrim( AV15ProdDsc), StringUtil.RTrim( context.localUtil.Format( AV15ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProddsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_RegistroInventarioPermanenteValorizado.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_56_5X2e( true) ;
         }
         else
         {
            wb_table1_56_5X2e( false) ;
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
         PA5X2( ) ;
         WS5X2( ) ;
         WE5X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810315789", true, true);
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
         context.AddJavascriptSource("contabilidad/r_registroinventariopermanentevalorizado.js", "?202281810315789", false, true);
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
         dynavAlmcod.Name = "vALMCOD";
         dynavAlmcod.WebTags = "";
         cmbavCmes.Name = "vCMES";
         cmbavCmes.WebTags = "";
         cmbavCmes.addItem("1", "Enero", 0);
         cmbavCmes.addItem("2", "Febrero", 0);
         cmbavCmes.addItem("3", "Marzo", 0);
         cmbavCmes.addItem("4", "Abril", 0);
         cmbavCmes.addItem("5", "Mayo", 0);
         cmbavCmes.addItem("6", "Junio", 0);
         cmbavCmes.addItem("7", "Julio", 0);
         cmbavCmes.addItem("8", "Agosto", 0);
         cmbavCmes.addItem("9", "Septiembre", 0);
         cmbavCmes.addItem("10", "Octubre", 0);
         cmbavCmes.addItem("11", "Noviembre", 0);
         cmbavCmes.addItem("12", "Diciembre", 0);
         if ( cmbavCmes.ItemCount > 0 )
         {
            AV19cMes = (short)(NumberUtil.Val( cmbavCmes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19cMes), 2, 0))), "."));
            AssignAttri("", false, "AV19cMes", StringUtil.LTrimStr( (decimal)(AV19cMes), 2, 0));
         }
         radavTipo.Name = "vTIPO";
         radavTipo.WebTags = "";
         radavTipo.addItem("V", "Vertical", 0);
         radavTipo.addItem("H", "Horizontal", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockalmcod_Internalname = "TEXTBLOCKALMCOD";
         dynavAlmcod_Internalname = "vALMCOD";
         divUnnamedtablealmcod_Internalname = "UNNAMEDTABLEALMCOD";
         lblTextblockcombo_lincod_Internalname = "TEXTBLOCKCOMBO_LINCOD";
         Combo_lincod_Internalname = "COMBO_LINCOD";
         divTablesplittedlincod_Internalname = "TABLESPLITTEDLINCOD";
         lblTextblockcombo_sublcod_Internalname = "TEXTBLOCKCOMBO_SUBLCOD";
         Combo_sublcod_Internalname = "COMBO_SUBLCOD";
         divTablesplittedsublcod_Internalname = "TABLESPLITTEDSUBLCOD";
         lblTextblockcombo_famcod_Internalname = "TEXTBLOCKCOMBO_FAMCOD";
         Combo_famcod_Internalname = "COMBO_FAMCOD";
         divTablesplittedfamcod_Internalname = "TABLESPLITTEDFAMCOD";
         lblTextblockprodcod_Internalname = "TEXTBLOCKPRODCOD";
         edtavProdcod_Internalname = "vPRODCOD";
         imgBtnbuscarpro_Internalname = "BTNBUSCARPRO";
         edtavProddsc_Internalname = "vPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         lblTextblockcano_Internalname = "TEXTBLOCKCANO";
         edtavCano_Internalname = "vCANO";
         divUnnamedtablecano_Internalname = "UNNAMEDTABLECANO";
         lblTextblockcmes_Internalname = "TEXTBLOCKCMES";
         cmbavCmes_Internalname = "vCMES";
         divUnnamedtablecmes_Internalname = "UNNAMEDTABLECMES";
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
         edtavLincod_Internalname = "vLINCOD";
         edtavSublcod_Internalname = "vSUBLCOD";
         edtavFamcod_Internalname = "vFAMCOD";
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
         edtavProddsc_Jsonclick = "";
         edtavProddsc_Enabled = 1;
         edtavProdcod_Jsonclick = "";
         edtavProdcod_Enabled = 1;
         edtavFamcod_Jsonclick = "";
         edtavFamcod_Visible = 1;
         edtavSublcod_Jsonclick = "";
         edtavSublcod_Visible = 1;
         edtavLincod_Jsonclick = "";
         edtavLincod_Visible = 1;
         radavTipo_Jsonclick = "";
         cmbavCmes_Jsonclick = "";
         cmbavCmes.Enabled = 1;
         edtavCano_Jsonclick = "";
         edtavCano_Enabled = 1;
         dynavAlmcod_Jsonclick = "";
         dynavAlmcod.Visible = 1;
         dynavAlmcod.Enabled = 1;
         Innewwindow_Target = "";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Registro de Inventario Permanente Valorizado";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_famcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_sublcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_lincod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Registro de Inventario Permanente Valorizado";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV21OpcEntrada',fld:'vOPCENTRADA',pic:'9',hsh:true},{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E125X2',iparms:[{av:'cmbavCmes'},{av:'AV19cMes',fld:'vCMES',pic:'Z9'},{av:'AV18cAno',fld:'vCANO',pic:'ZZZ9'},{av:'AV21OpcEntrada',fld:'vOPCENTRADA',pic:'9',hsh:true},{av:'AV11LinCod',fld:'vLINCOD',pic:'ZZZZZ9'},{av:'AV12SublCod',fld:'vSUBLCOD',pic:'ZZZZZ9'},{av:'AV13FamCod',fld:'vFAMCOD',pic:'ZZZZZ9'},{av:'AV14ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E135X2',iparms:[{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]}");
         setEventMetadata("'DOBTNBUSCARPRO'","{handler:'E155X1',iparms:[{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("'DOBTNBUSCARPRO'",",oparms:[{av:'AV15ProdDsc',fld:'vPRODDSC',pic:''},{av:'AV14ProdCod',fld:'vPRODCOD',pic:'@!'},{av:'dynavAlmcod'},{av:'AV10AlmCod',fld:'vALMCOD',pic:'ZZZZZ9'},{av:'radavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:''}]}");
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
         Combo_famcod_Selectedvalue_get = "";
         Combo_sublcod_Selectedvalue_get = "";
         Combo_lincod_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20LinCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV23SublCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17FamCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_lincod_Selectedvalue_set = "";
         Combo_sublcod_Selectedvalue_set = "";
         Combo_famcod_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockalmcod_Jsonclick = "";
         TempTags = "";
         lblTextblockcombo_lincod_Jsonclick = "";
         ucCombo_lincod = new GXUserControl();
         Combo_lincod_Caption = "";
         lblTextblockcombo_sublcod_Jsonclick = "";
         ucCombo_sublcod = new GXUserControl();
         Combo_sublcod_Caption = "";
         lblTextblockcombo_famcod_Jsonclick = "";
         ucCombo_famcod = new GXUserControl();
         Combo_famcod_Caption = "";
         lblTextblockprodcod_Jsonclick = "";
         lblTextblockcano_Jsonclick = "";
         lblTextblockcmes_Jsonclick = "";
         lblTextblocktipo_Jsonclick = "";
         AV9Tipo = "";
         bttBtnbtnimprimir_Jsonclick = "";
         bttBtnbtnsalir_Jsonclick = "";
         ucInnewwindow = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H005X2_A63AlmCod = new int[1] ;
         H005X2_A436AlmDsc = new string[] {""} ;
         H005X2_A438AlmSts = new short[1] ;
         H005X2_A434AlmCos = new short[1] ;
         AV14ProdCod = "";
         AV15ProdDsc = "";
         AV27FechaC = "";
         AV25FDesde = DateTime.MinValue;
         AV26FHasta = DateTime.MinValue;
         AV24URL = "";
         GXEncryptionTmp = "";
         H005X3_A979FamSts = new short[1] ;
         H005X3_A50FamCod = new int[1] ;
         H005X3_A977FamDsc = new string[] {""} ;
         A977FamDsc = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H005X4_A1893SublSts = new short[1] ;
         H005X4_A51SublCod = new int[1] ;
         H005X4_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         H005X5_A1159LinSts = new short[1] ;
         H005X5_A52LinCod = new int[1] ;
         H005X5_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscarpro_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registroinventariopermanentevalorizado__default(),
            new Object[][] {
                new Object[] {
               H005X2_A63AlmCod, H005X2_A436AlmDsc, H005X2_A438AlmSts, H005X2_A434AlmCos
               }
               , new Object[] {
               H005X3_A979FamSts, H005X3_A50FamCod, H005X3_A977FamDsc
               }
               , new Object[] {
               H005X4_A1893SublSts, H005X4_A51SublCod, H005X4_A1892SublDsc
               }
               , new Object[] {
               H005X5_A1159LinSts, H005X5_A52LinCod, H005X5_A1153LinDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProddsc_Enabled = 0;
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
      private short AV21OpcEntrada ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18cAno ;
      private short AV19cMes ;
      private short nDonePA ;
      private short AV32Flag ;
      private short AV28Mes2 ;
      private short AV29Ano2 ;
      private short A979FamSts ;
      private short A1893SublSts ;
      private short A1159LinSts ;
      private short nGXWrapped ;
      private int AV10AlmCod ;
      private int edtavCano_Enabled ;
      private int AV11LinCod ;
      private int edtavLincod_Visible ;
      private int AV12SublCod ;
      private int edtavSublcod_Visible ;
      private int AV13FamCod ;
      private int edtavFamcod_Visible ;
      private int gxdynajaxindex ;
      private int edtavProddsc_Enabled ;
      private int A50FamCod ;
      private int A51SublCod ;
      private int A52LinCod ;
      private int edtavProdcod_Enabled ;
      private int idxLst ;
      private string Combo_famcod_Selectedvalue_get ;
      private string Combo_sublcod_Selectedvalue_get ;
      private string Combo_lincod_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_lincod_Cls ;
      private string Combo_lincod_Selectedvalue_set ;
      private string Combo_sublcod_Cls ;
      private string Combo_sublcod_Selectedvalue_set ;
      private string Combo_famcod_Cls ;
      private string Combo_famcod_Selectedvalue_set ;
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
      private string divUnnamedtablealmcod_Internalname ;
      private string lblTextblockalmcod_Internalname ;
      private string lblTextblockalmcod_Jsonclick ;
      private string dynavAlmcod_Internalname ;
      private string TempTags ;
      private string dynavAlmcod_Jsonclick ;
      private string divTablesplittedlincod_Internalname ;
      private string lblTextblockcombo_lincod_Internalname ;
      private string lblTextblockcombo_lincod_Jsonclick ;
      private string Combo_lincod_Caption ;
      private string Combo_lincod_Internalname ;
      private string divTablesplittedsublcod_Internalname ;
      private string lblTextblockcombo_sublcod_Internalname ;
      private string lblTextblockcombo_sublcod_Jsonclick ;
      private string Combo_sublcod_Caption ;
      private string Combo_sublcod_Internalname ;
      private string divTablesplittedfamcod_Internalname ;
      private string lblTextblockcombo_famcod_Internalname ;
      private string lblTextblockcombo_famcod_Jsonclick ;
      private string Combo_famcod_Caption ;
      private string Combo_famcod_Internalname ;
      private string divTablesplittedprodcod_Internalname ;
      private string lblTextblockprodcod_Internalname ;
      private string lblTextblockprodcod_Jsonclick ;
      private string divUnnamedtablecano_Internalname ;
      private string lblTextblockcano_Internalname ;
      private string lblTextblockcano_Jsonclick ;
      private string edtavCano_Internalname ;
      private string edtavCano_Jsonclick ;
      private string divUnnamedtablecmes_Internalname ;
      private string lblTextblockcmes_Internalname ;
      private string lblTextblockcmes_Jsonclick ;
      private string cmbavCmes_Internalname ;
      private string cmbavCmes_Jsonclick ;
      private string divUnnamedtabletipo_Internalname ;
      private string lblTextblocktipo_Internalname ;
      private string lblTextblocktipo_Jsonclick ;
      private string radavTipo_Internalname ;
      private string AV9Tipo ;
      private string radavTipo_Jsonclick ;
      private string bttBtnbtnimprimir_Internalname ;
      private string bttBtnbtnimprimir_Jsonclick ;
      private string bttBtnbtnsalir_Internalname ;
      private string bttBtnbtnsalir_Jsonclick ;
      private string Innewwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLincod_Internalname ;
      private string edtavLincod_Jsonclick ;
      private string edtavSublcod_Internalname ;
      private string edtavSublcod_Jsonclick ;
      private string edtavFamcod_Internalname ;
      private string edtavFamcod_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavProddsc_Internalname ;
      private string AV14ProdCod ;
      private string edtavProdcod_Internalname ;
      private string AV15ProdDsc ;
      private string AV27FechaC ;
      private string GXEncryptionTmp ;
      private string A977FamDsc ;
      private string A1892SublDsc ;
      private string A1153LinDsc ;
      private string sStyleString ;
      private string tblTablemergedprodcod_Internalname ;
      private string edtavProdcod_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscarpro_Internalname ;
      private string imgBtnbuscarpro_Jsonclick ;
      private string edtavProddsc_Jsonclick ;
      private DateTime AV25FDesde ;
      private DateTime AV26FHasta ;
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
      private string AV24URL ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_lincod ;
      private GXUserControl ucCombo_sublcod ;
      private GXUserControl ucCombo_famcod ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavAlmcod ;
      private GXCombobox cmbavCmes ;
      private GXRadio radavTipo ;
      private IDataStoreProvider pr_default ;
      private int[] H005X2_A63AlmCod ;
      private string[] H005X2_A436AlmDsc ;
      private short[] H005X2_A438AlmSts ;
      private short[] H005X2_A434AlmCos ;
      private short[] H005X3_A979FamSts ;
      private int[] H005X3_A50FamCod ;
      private string[] H005X3_A977FamDsc ;
      private short[] H005X4_A1893SublSts ;
      private int[] H005X4_A51SublCod ;
      private string[] H005X4_A1892SublDsc ;
      private short[] H005X5_A1159LinSts ;
      private int[] H005X5_A52LinCod ;
      private string[] H005X5_A1153LinDsc ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20LinCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23SublCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17FamCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class r_registroinventariopermanentevalorizado__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005X2;
          prmH005X2 = new Object[] {
          };
          Object[] prmH005X3;
          prmH005X3 = new Object[] {
          };
          Object[] prmH005X4;
          prmH005X4 = new Object[] {
          };
          Object[] prmH005X5;
          prmH005X5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005X2", "SELECT [AlmCod], [AlmDsc], [AlmSts], [AlmCos] FROM [CALMACEN] WHERE ([AlmSts] = 1) AND ([AlmCos] = 1) ORDER BY [AlmDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005X2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005X3", "SELECT [FamSts], [FamCod], [FamDsc] FROM [CFAMILIA] WHERE [FamSts] = 1 ORDER BY [FamDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005X3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005X4", "SELECT [SublSts], [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublSts] = 1 ORDER BY [SublDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005X4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005X5", "SELECT [LinSts], [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinSts] = 1 ORDER BY [LinDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005X5,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
