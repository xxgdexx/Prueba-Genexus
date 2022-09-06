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
   public class r_librodiarior : GXDataArea
   {
      public r_librodiarior( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_librodiarior( IGxContext context )
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
         dynavTasicod = new GXCombobox();
         dynavVounum = new GXCombobox();
         dynavCcosto = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vTASICOD") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvTASICOD762( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vVOUNUM") == 0 )
            {
               AV5Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
               AssignAttri("", false, "AV5Ano", StringUtil.LTrimStr( (decimal)(AV5Ano), 4, 0));
               AV12Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
               AssignAttri("", false, "AV12Mes", StringUtil.LTrimStr( (decimal)(AV12Mes), 2, 0));
               AV13TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
               AssignAttri("", false, "AV13TASICod", StringUtil.LTrimStr( (decimal)(AV13TASICod), 6, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvVOUNUM762( AV5Ano, AV12Mes, AV13TASICod) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCCOSTO") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCCOSTO762( ) ;
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
         PA762( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START762( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810321918", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.r_librodiarior.aspx") +"\">") ;
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
            WE762( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT762( ) ;
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
         return formatLink("contabilidad.r_librodiarior.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.R_LibroDiarioR" ;
      }

      public override string GetPgmdesc( )
      {
         return "Libro Diario" ;
      }

      protected void WB760( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockano_Internalname, "Año", "", "", lblTextblockano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAno_Internalname, "Ano", "col-sm-3 AttributeWidthAutoLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Ano), 4, 0, ".", "")), StringUtil.LTrim( ((edtavAno_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Ano), "ZZZ9") : context.localUtil.Format( (decimal)(AV5Ano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAno_Jsonclick, 0, "AttributeWidthAuto", "", "", "", "", 1, edtavAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\R_LibroDiarioR.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockmes_Internalname, "Mes", "", "", lblTextblockmes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMes_Internalname, "Mes", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMes, cmbavMes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 2, 0)), 1, cmbavMes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 1, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            cmbavMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 2, 0));
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
            GxWebStd.gx_div_start( context, divUnnamedtabletasicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktasicod_Internalname, "Tipo de Asiento", "", "", lblTextblocktasicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavTasicod_Internalname, "Tipo Asiento", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTasicod, dynavTasicod_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV13TASICod), 6, 0)), 1, dynavTasicod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavTasicod.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            dynavTasicod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13TASICod), 6, 0));
            AssignProp("", false, dynavTasicod_Internalname, "Values", (string)(dynavTasicod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablevounum_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockvounum_Internalname, "N° Asiento", "", "", lblTextblockvounum_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavVounum_Internalname, "N° Asiento", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavVounum, dynavVounum_Internalname, StringUtil.RTrim( AV17VouNum), 1, dynavVounum_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, dynavVounum.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 1, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
            AssignProp("", false, dynavVounum_Internalname, "Values", (string)(dynavVounum.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divUnnamedtableccosto_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockccosto_Internalname, "Centro de Costo", "", "", lblTextblockccosto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCcosto_Internalname, "Codigo de C.Costo", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCcosto, dynavCcosto_Internalname, StringUtil.RTrim( AV18cCosto), 1, dynavCcosto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, dynavCcosto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            dynavCcosto.CurrentValue = StringUtil.RTrim( AV18cCosto);
            AssignProp("", false, dynavCcosto_Internalname, "Values", (string)(dynavCcosto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcopc_Internalname, "Tipo Reporte", "", "", lblTextblockcopc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "c Opc", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Radio button */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavCopc, radavCopc_Internalname, StringUtil.Str( (decimal)(AV9cOpc), 1, 0), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavCopc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "HLP_Contabilidad\\R_LibroDiarioR.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockccuenta1_Internalname, "Cuenta Desde", "", "", lblTextblockccuenta1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table1_76_762( true) ;
         }
         else
         {
            wb_table1_76_762( false) ;
         }
         return  ;
      }

      protected void wb_table1_76_762e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockccuenta2_Internalname, "Cuenta Hasta", "", "", lblTextblockccuenta2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            wb_table2_92_762( true) ;
         }
         else
         {
            wb_table2_92_762( false) ;
         }
         return  ;
      }

      protected void wb_table2_92_762e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnimprimir_Internalname, "", "Imprimir", bttBtnbtnimprimir_Jsonclick, 5, "Imprimir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNIMPRIMIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnsalir_Internalname, "", "Salir", bttBtnbtnsalir_Jsonclick, 5, "Salir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNSALIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\R_LibroDiarioR.htm");
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

      protected void START762( )
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
         STRUP760( ) ;
      }

      protected void WS762( )
      {
         START762( ) ;
         EVT762( ) ;
      }

      protected void EVT762( )
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
                              E11762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNIMPRIMIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnImprimir' */
                              E12762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNSALIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnSalir' */
                              E13762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14762 ();
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

      protected void WE762( )
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

      protected void PA762( )
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
         GXVvVOUNUM_html762( AV5Ano, AV12Mes, AV13TASICod) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvTASICOD762( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvTASICOD_data762( ) ;
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

      protected void GXVvTASICOD_html762( )
      {
         int gxdynajaxvalue;
         GXDLVvTASICOD_data762( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavTasicod.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavTasicod.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvTASICOD_data762( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H00762 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00762_A126TASICod[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00762_A1895TASIDsc[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvVOUNUM762( short AV5Ano ,
                                      short AV12Mes ,
                                      int AV13TASICod )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvVOUNUM_data762( AV5Ano, AV12Mes, AV13TASICod) ;
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

      protected void GXVvVOUNUM_html762( short AV5Ano ,
                                         short AV12Mes ,
                                         int AV13TASICod )
      {
         string gxdynajaxvalue;
         GXDLVvVOUNUM_data762( AV5Ano, AV12Mes, AV13TASICod) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavVounum.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavVounum.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvVOUNUM_data762( short AV5Ano ,
                                           short AV12Mes ,
                                           int AV13TASICod )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H00763 */
         pr_default.execute(1, new Object[] {AV5Ano, AV12Mes, AV13TASICod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.RTrim( H00763_A129VouNum[0]));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00763_A129VouNum[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvCCOSTO762( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCCOSTO_data762( ) ;
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

      protected void GXVvCCOSTO_html762( )
      {
         string gxdynajaxvalue;
         GXDLVvCCOSTO_data762( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCcosto.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavCcosto.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCCOSTO_data762( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H00764 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.RTrim( H00764_A79COSCod[0]));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00764_A761COSDsc[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvTASICOD_html762( ) ;
            GXVvCCOSTO_html762( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavMes.ItemCount > 0 )
         {
            AV12Mes = (short)(NumberUtil.Val( cmbavMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 2, 0))), "."));
            AssignAttri("", false, "AV12Mes", StringUtil.LTrimStr( (decimal)(AV12Mes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 2, 0));
            AssignProp("", false, cmbavMes_Internalname, "Values", cmbavMes.ToJavascriptSource(), true);
         }
         if ( dynavTasicod.ItemCount > 0 )
         {
            AV13TASICod = (int)(NumberUtil.Val( dynavTasicod.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13TASICod), 6, 0))), "."));
            AssignAttri("", false, "AV13TASICod", StringUtil.LTrimStr( (decimal)(AV13TASICod), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavTasicod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13TASICod), 6, 0));
            AssignProp("", false, dynavTasicod_Internalname, "Values", dynavTasicod.ToJavascriptSource(), true);
         }
         if ( dynavVounum.ItemCount > 0 )
         {
            AV17VouNum = dynavVounum.getValidValue(AV17VouNum);
            AssignAttri("", false, "AV17VouNum", AV17VouNum);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
            AssignProp("", false, dynavVounum_Internalname, "Values", dynavVounum.ToJavascriptSource(), true);
         }
         if ( dynavCcosto.ItemCount > 0 )
         {
            AV18cCosto = dynavCcosto.getValidValue(AV18cCosto);
            AssignAttri("", false, "AV18cCosto", AV18cCosto);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCcosto.CurrentValue = StringUtil.RTrim( AV18cCosto);
            AssignProp("", false, dynavCcosto_Internalname, "Values", dynavCcosto.ToJavascriptSource(), true);
         }
         AV9cOpc = (short)(context.localUtil.CToN( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cOpc), 1, 0, ".", "")), ".", ","));
         AssignAttri("", false, "AV9cOpc", StringUtil.Str( (decimal)(AV9cOpc), 1, 0));
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF762( ) ;
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

      protected void RF762( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14762 ();
            WB760( ) ;
         }
      }

      protected void send_integrity_lvl_hashes762( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         AssignProp("", false, edtavCcuedsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc1_Enabled), 5, 0), true);
         edtavCcuedsc2_Enabled = 0;
         AssignProp("", false, edtavCcuedsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc2_Enabled), 5, 0), true);
         GXVvTASICOD_html762( ) ;
         GXVvCCOSTO_html762( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP760( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11762 ();
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
            AV12Mes = (short)(NumberUtil.Val( cgiGet( cmbavMes_Internalname), "."));
            AssignAttri("", false, "AV12Mes", StringUtil.LTrimStr( (decimal)(AV12Mes), 2, 0));
            dynavTasicod.CurrentValue = cgiGet( dynavTasicod_Internalname);
            AV13TASICod = (int)(NumberUtil.Val( cgiGet( dynavTasicod_Internalname), "."));
            AssignAttri("", false, "AV13TASICod", StringUtil.LTrimStr( (decimal)(AV13TASICod), 6, 0));
            dynavVounum.CurrentValue = cgiGet( dynavVounum_Internalname);
            AV17VouNum = cgiGet( dynavVounum_Internalname);
            AssignAttri("", false, "AV17VouNum", AV17VouNum);
            dynavCcosto.CurrentValue = cgiGet( dynavCcosto_Internalname);
            AV18cCosto = cgiGet( dynavCcosto_Internalname);
            AssignAttri("", false, "AV18cCosto", AV18cCosto);
            if ( ( ( context.localUtil.CToN( cgiGet( radavCopc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( radavCopc_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPC");
               wbErr = true;
               AV9cOpc = 0;
               AssignAttri("", false, "AV9cOpc", StringUtil.Str( (decimal)(AV9cOpc), 1, 0));
            }
            else
            {
               AV9cOpc = (short)(context.localUtil.CToN( cgiGet( radavCopc_Internalname), ".", ","));
               AssignAttri("", false, "AV9cOpc", StringUtil.Str( (decimal)(AV9cOpc), 1, 0));
            }
            AV7cCuenta1 = cgiGet( edtavCcuenta1_Internalname);
            AssignAttri("", false, "AV7cCuenta1", AV7cCuenta1);
            AV6cCueDsc1 = cgiGet( edtavCcuedsc1_Internalname);
            AssignAttri("", false, "AV6cCueDsc1", AV6cCueDsc1);
            AV19cCuenta2 = cgiGet( edtavCcuenta2_Internalname);
            AssignAttri("", false, "AV19cCuenta2", AV19cCuenta2);
            AV20cCueDsc2 = cgiGet( edtavCcuedsc2_Internalname);
            AssignAttri("", false, "AV20cCueDsc2", AV20cCueDsc2);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXVvTASICOD_html762( ) ;
            GXVvCCOSTO_html762( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11762 ();
         if (returnInSub) return;
      }

      protected void E11762( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavCcuedsc1_Enabled = 0;
         AssignProp("", false, edtavCcuedsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc1_Enabled), 5, 0), true);
         edtavCcuedsc2_Enabled = 0;
         AssignProp("", false, edtavCcuedsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCcuedsc2_Enabled), 5, 0), true);
         AV5Ano = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV5Ano", StringUtil.LTrimStr( (decimal)(AV5Ano), 4, 0));
         AV12Mes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV12Mes", StringUtil.LTrimStr( (decimal)(AV12Mes), 2, 0));
         AV9cOpc = 1;
         AssignAttri("", false, "AV9cOpc", StringUtil.Str( (decimal)(AV9cOpc), 1, 0));
      }

      protected void E12762( )
      {
         /* 'DoBtnImprimir' Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.r_librodiariopdf.aspx"+UrlEncode(StringUtil.LTrimStr(AV5Ano,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12Mes,2,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13TASICod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV17VouNum)) + "," + UrlEncode(StringUtil.RTrim(AV18cCosto)) + "," + UrlEncode(StringUtil.RTrim(AV7cCuenta1)) + "," + UrlEncode(StringUtil.RTrim(AV19cCuenta2)) + "," + UrlEncode(StringUtil.LTrimStr(AV9cOpc,1,0));
         AV16URL = formatLink("contabilidad.r_librodiariopdf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Innewwindow_Target = AV16URL;
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E13762( )
      {
         /* 'DoBtnSalir' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E14762( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_92_762( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuenta2_Internalname, StringUtil.RTrim( AV19cCuenta2), StringUtil.RTrim( context.localUtil.Format( AV19cCuenta2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuenta2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcuenta2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarcue2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarcue2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15761_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_LibroDiarioR.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuedsc2_Internalname, "Descripción de Cuenta", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuedsc2_Internalname, StringUtil.RTrim( AV20cCueDsc2), StringUtil.RTrim( context.localUtil.Format( AV20cCueDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuedsc2_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavCcuedsc2_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_92_762e( true) ;
         }
         else
         {
            wb_table2_92_762e( false) ;
         }
      }

      protected void wb_table1_76_762( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuenta1_Internalname, StringUtil.RTrim( AV7cCuenta1), StringUtil.RTrim( context.localUtil.Format( AV7cCuenta1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuenta1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcuenta1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellPaddingLeft10'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgBtnbuscarcue_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Buscar Cuenta", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgBtnbuscarcue_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16761_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Contabilidad\\R_LibroDiarioR.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcuedsc1_Internalname, "Descripción de Cuenta", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcuedsc1_Internalname, StringUtil.RTrim( AV6cCueDsc1), StringUtil.RTrim( context.localUtil.Format( AV6cCueDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcuedsc1_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavCcuedsc1_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\R_LibroDiarioR.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_76_762e( true) ;
         }
         else
         {
            wb_table1_76_762e( false) ;
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
         PA762( ) ;
         WS762( ) ;
         WE762( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810322023", true, true);
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
         context.AddJavascriptSource("contabilidad/r_librodiarior.js", "?202281810322024", false, true);
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
            AV12Mes = (short)(NumberUtil.Val( cmbavMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 2, 0))), "."));
            AssignAttri("", false, "AV12Mes", StringUtil.LTrimStr( (decimal)(AV12Mes), 2, 0));
         }
         dynavTasicod.Name = "vTASICOD";
         dynavTasicod.WebTags = "";
         dynavVounum.Name = "vVOUNUM";
         dynavVounum.WebTags = "";
         dynavCcosto.Name = "vCCOSTO";
         dynavCcosto.WebTags = "";
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
         lblTextblocktasicod_Internalname = "TEXTBLOCKTASICOD";
         dynavTasicod_Internalname = "vTASICOD";
         divUnnamedtabletasicod_Internalname = "UNNAMEDTABLETASICOD";
         lblTextblockvounum_Internalname = "TEXTBLOCKVOUNUM";
         dynavVounum_Internalname = "vVOUNUM";
         divUnnamedtablevounum_Internalname = "UNNAMEDTABLEVOUNUM";
         lblTextblockccosto_Internalname = "TEXTBLOCKCCOSTO";
         dynavCcosto_Internalname = "vCCOSTO";
         divUnnamedtableccosto_Internalname = "UNNAMEDTABLECCOSTO";
         lblTextblockcopc_Internalname = "TEXTBLOCKCOPC";
         radavCopc_Internalname = "vCOPC";
         divUnnamedtablecopc_Internalname = "UNNAMEDTABLECOPC";
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
         edtavCcuedsc2_Enabled = 1;
         edtavCcuedsc1_Enabled = 1;
         radavCopc_Jsonclick = "";
         dynavCcosto_Jsonclick = "";
         dynavCcosto.Enabled = 1;
         dynavVounum_Jsonclick = "";
         dynavVounum.Enabled = 1;
         dynavTasicod_Jsonclick = "";
         dynavTasicod.Enabled = 1;
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

      public void Validv_Ano( )
      {
         AV13TASICod = (int)(NumberUtil.Val( dynavTasicod.CurrentValue, "."));
         AV12Mes = (short)(NumberUtil.Val( cmbavMes.CurrentValue, "."));
         AV17VouNum = dynavVounum.CurrentValue;
         AV18cCosto = dynavCcosto.CurrentValue;
         GXVvVOUNUM_html762( AV5Ano, AV12Mes, AV13TASICod) ;
         dynload_actions( ) ;
         if ( dynavVounum.ItemCount > 0 )
         {
            AV17VouNum = dynavVounum.getValidValue(AV17VouNum);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV17VouNum", StringUtil.RTrim( AV17VouNum));
         dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
         AssignProp("", false, dynavVounum_Internalname, "Values", dynavVounum.ToJavascriptSource(), true);
      }

      public void Validv_Mes( )
      {
         AV13TASICod = (int)(NumberUtil.Val( dynavTasicod.CurrentValue, "."));
         AV12Mes = (short)(NumberUtil.Val( cmbavMes.CurrentValue, "."));
         AV17VouNum = dynavVounum.CurrentValue;
         AV18cCosto = dynavCcosto.CurrentValue;
         GXVvVOUNUM_html762( AV5Ano, AV12Mes, AV13TASICod) ;
         dynload_actions( ) ;
         if ( dynavVounum.ItemCount > 0 )
         {
            AV17VouNum = dynavVounum.getValidValue(AV17VouNum);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV17VouNum", StringUtil.RTrim( AV17VouNum));
         dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
         AssignProp("", false, dynavVounum_Internalname, "Values", dynavVounum.ToJavascriptSource(), true);
      }

      public void Validv_Tasicod( )
      {
         AV13TASICod = (int)(NumberUtil.Val( dynavTasicod.CurrentValue, "."));
         AV12Mes = (short)(NumberUtil.Val( cmbavMes.CurrentValue, "."));
         AV17VouNum = dynavVounum.CurrentValue;
         AV18cCosto = dynavCcosto.CurrentValue;
         GXVvVOUNUM_html762( AV5Ano, AV12Mes, AV13TASICod) ;
         dynload_actions( ) ;
         if ( dynavVounum.ItemCount > 0 )
         {
            AV17VouNum = dynavVounum.getValidValue(AV17VouNum);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV17VouNum", StringUtil.RTrim( AV17VouNum));
         dynavVounum.CurrentValue = StringUtil.RTrim( AV17VouNum);
         AssignProp("", false, dynavVounum_Internalname, "Values", dynavVounum.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNIMPRIMIR'","{handler:'E12762',iparms:[{av:'AV5Ano',fld:'vANO',pic:'ZZZ9'},{av:'cmbavMes'},{av:'AV12Mes',fld:'vMES',pic:'Z9'},{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'AV7cCuenta1',fld:'vCCUENTA1',pic:''},{av:'AV19cCuenta2',fld:'vCCUENTA2',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNIMPRIMIR'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNSALIR'","{handler:'E13762',iparms:[{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNSALIR'",",oparms:[{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNBUSCARCUE'","{handler:'E16761',iparms:[{av:'AV7cCuenta1',fld:'vCCUENTA1',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNBUSCARCUE'",",oparms:[{av:'AV6cCueDsc1',fld:'vCCUEDSC1',pic:''},{av:'AV7cCuenta1',fld:'vCCUENTA1',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("'DOBTNBUSCARCUE2'","{handler:'E15761',iparms:[{av:'AV19cCuenta2',fld:'vCCUENTA2',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("'DOBTNBUSCARCUE2'",",oparms:[{av:'AV20cCueDsc2',fld:'vCCUEDSC2',pic:''},{av:'AV19cCuenta2',fld:'vCCUENTA2',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("VALIDV_ANO","{handler:'Validv_Ano',iparms:[{av:'AV5Ano',fld:'vANO',pic:'ZZZ9'},{av:'cmbavMes'},{av:'AV12Mes',fld:'vMES',pic:'Z9'},{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("VALIDV_ANO",",oparms:[{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("VALIDV_MES","{handler:'Validv_Mes',iparms:[{av:'AV5Ano',fld:'vANO',pic:'ZZZ9'},{av:'cmbavMes'},{av:'AV12Mes',fld:'vMES',pic:'Z9'},{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("VALIDV_MES",",oparms:[{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
         setEventMetadata("VALIDV_TASICOD","{handler:'Validv_Tasicod',iparms:[{av:'AV5Ano',fld:'vANO',pic:'ZZZ9'},{av:'cmbavMes'},{av:'AV12Mes',fld:'vMES',pic:'Z9'},{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]");
         setEventMetadata("VALIDV_TASICOD",",oparms:[{av:'dynavVounum'},{av:'AV17VouNum',fld:'vVOUNUM',pic:''},{av:'dynavTasicod'},{av:'AV13TASICod',fld:'vTASICOD',pic:'ZZZZZ9'},{av:'dynavCcosto'},{av:'AV18cCosto',fld:'vCCOSTO',pic:''},{av:'radavCopc'},{av:'AV9cOpc',fld:'vCOPC',pic:'9'}]}");
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
         lblTextblocktasicod_Jsonclick = "";
         lblTextblockvounum_Jsonclick = "";
         AV17VouNum = "";
         lblTextblockccosto_Jsonclick = "";
         AV18cCosto = "";
         lblTextblockcopc_Jsonclick = "";
         lblTextblockccuenta1_Jsonclick = "";
         lblTextblockccuenta2_Jsonclick = "";
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
         H00762_A126TASICod = new int[1] ;
         H00762_A1895TASIDsc = new string[] {""} ;
         H00762_A1896TASISts = new short[1] ;
         H00763_A129VouNum = new string[] {""} ;
         H00763_A127VouAno = new short[1] ;
         H00763_A128VouMes = new short[1] ;
         H00763_A126TASICod = new int[1] ;
         H00764_A79COSCod = new string[] {""} ;
         H00764_A761COSDsc = new string[] {""} ;
         H00764_A762COSSts = new short[1] ;
         AV7cCuenta1 = "";
         AV6cCueDsc1 = "";
         AV19cCuenta2 = "";
         AV20cCueDsc2 = "";
         AV16URL = "";
         GXEncryptionTmp = "";
         sStyleString = "";
         sImgUrl = "";
         imgBtnbuscarcue2_Jsonclick = "";
         imgBtnbuscarcue_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ZV17VouNum = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_librodiarior__default(),
            new Object[][] {
                new Object[] {
               H00762_A126TASICod, H00762_A1895TASIDsc, H00762_A1896TASISts
               }
               , new Object[] {
               H00763_A129VouNum, H00763_A127VouAno, H00763_A128VouMes, H00763_A126TASICod
               }
               , new Object[] {
               H00764_A79COSCod, H00764_A761COSDsc, H00764_A762COSSts
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCcuedsc1_Enabled = 0;
         edtavCcuedsc2_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV5Ano ;
      private short AV12Mes ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV9cOpc ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV13TASICod ;
      private int edtavAno_Enabled ;
      private int gxdynajaxindex ;
      private int edtavCcuedsc1_Enabled ;
      private int edtavCcuedsc2_Enabled ;
      private int edtavCcuenta2_Enabled ;
      private int edtavCcuenta1_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
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
      private string divUnnamedtabletasicod_Internalname ;
      private string lblTextblocktasicod_Internalname ;
      private string lblTextblocktasicod_Jsonclick ;
      private string dynavTasicod_Internalname ;
      private string dynavTasicod_Jsonclick ;
      private string divUnnamedtablevounum_Internalname ;
      private string lblTextblockvounum_Internalname ;
      private string lblTextblockvounum_Jsonclick ;
      private string dynavVounum_Internalname ;
      private string AV17VouNum ;
      private string dynavVounum_Jsonclick ;
      private string divUnnamedtableccosto_Internalname ;
      private string lblTextblockccosto_Internalname ;
      private string lblTextblockccosto_Jsonclick ;
      private string dynavCcosto_Internalname ;
      private string AV18cCosto ;
      private string dynavCcosto_Jsonclick ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCcuedsc1_Internalname ;
      private string edtavCcuedsc2_Internalname ;
      private string AV7cCuenta1 ;
      private string edtavCcuenta1_Internalname ;
      private string AV6cCueDsc1 ;
      private string AV19cCuenta2 ;
      private string edtavCcuenta2_Internalname ;
      private string AV20cCueDsc2 ;
      private string GXEncryptionTmp ;
      private string sStyleString ;
      private string tblTablemergedccuenta2_Internalname ;
      private string edtavCcuenta2_Jsonclick ;
      private string sImgUrl ;
      private string imgBtnbuscarcue2_Internalname ;
      private string imgBtnbuscarcue2_Jsonclick ;
      private string edtavCcuedsc2_Jsonclick ;
      private string tblTablemergedccuenta1_Internalname ;
      private string edtavCcuenta1_Jsonclick ;
      private string imgBtnbuscarcue_Internalname ;
      private string imgBtnbuscarcue_Jsonclick ;
      private string edtavCcuedsc1_Jsonclick ;
      private string ZV17VouNum ;
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
      private string AV16URL ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucInnewwindow ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavMes ;
      private GXCombobox dynavTasicod ;
      private GXCombobox dynavVounum ;
      private GXCombobox dynavCcosto ;
      private GXRadio radavCopc ;
      private IDataStoreProvider pr_default ;
      private int[] H00762_A126TASICod ;
      private string[] H00762_A1895TASIDsc ;
      private short[] H00762_A1896TASISts ;
      private string[] H00763_A129VouNum ;
      private short[] H00763_A127VouAno ;
      private short[] H00763_A128VouMes ;
      private int[] H00763_A126TASICod ;
      private string[] H00764_A79COSCod ;
      private string[] H00764_A761COSDsc ;
      private short[] H00764_A762COSSts ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class r_librodiarior__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00762;
          prmH00762 = new Object[] {
          };
          Object[] prmH00763;
          prmH00763 = new Object[] {
          new ParDef("@AV5Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV13TASICod",GXType.Int32,6,0)
          };
          Object[] prmH00764;
          prmH00764 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00762", "SELECT [TASICod], [TASIDsc], [TASISts] FROM [CBTIPOASIENTO] WHERE [TASISts] = 1 ORDER BY [TASIDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00762,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00763", "SELECT [VouNum], [VouAno], [VouMes], [TASICod] FROM [CBVOUCHER] WHERE ([VouAno] = @AV5Ano) AND ([VouMes] = @AV12Mes) AND ([TASICod] = @AV13TASICod) ORDER BY [VouNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00763,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00764", "SELECT [COSCod], [COSDsc], [COSSts] FROM [CBCOSTOS] WHERE [COSSts] = 1 ORDER BY [COSDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00764,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
