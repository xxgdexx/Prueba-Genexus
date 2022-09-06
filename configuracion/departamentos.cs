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
namespace GeneXus.Programs.configuracion {
   public class departamentos : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A139PaiCod) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.departamentos.aspx")), "configuracion.departamentos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.departamentos.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10PaiCod = GetPar( "PaiCod");
                  AssignAttri("", false, "AV10PaiCod", AV10PaiCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPAICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PaiCod, "")), context));
                  AV7EstCod = GetPar( "EstCod");
                  AssignAttri("", false, "AV7EstCod", AV7EstCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vESTCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7EstCod, "")), context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Departamentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public departamentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public departamentos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_PaiCod ,
                           string aP2_EstCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10PaiCod = aP1_PaiCod;
         this.AV7EstCod = aP2_EstCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbEstSts = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbEstSts.ItemCount > 0 )
         {
            A975EstSts = (short)(NumberUtil.Val( cmbEstSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0))), "."));
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEstSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            AssignProp("", false, cmbEstSts_Internalname, "Values", cmbEstSts.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpaicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpaicod_Internalname, "Pais", "", "", lblTextblockpaicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paicod.SetProperty("Caption", Combo_paicod_Caption);
         ucCombo_paicod.SetProperty("Cls", Combo_paicod_Cls);
         ucCombo_paicod.SetProperty("DataListProc", Combo_paicod_Datalistproc);
         ucCombo_paicod.SetProperty("DataListProcParametersPrefix", Combo_paicod_Datalistprocparametersprefix);
         ucCombo_paicod.SetProperty("EmptyItem", Combo_paicod_Emptyitem);
         ucCombo_paicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_paicod.SetProperty("DropDownOptionsData", AV14PaiCod_Data);
         ucCombo_paicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paicod_Internalname, "COMBO_PAICODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaiCod_Internalname, "Pais", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPaiCod_Visible, edtPaiCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEstCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEstDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstDsc_Internalname, "Departamento", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstDsc_Internalname, StringUtil.RTrim( A602EstDsc), StringUtil.RTrim( context.localUtil.Format( A602EstDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtEstDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbEstSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbEstSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEstSts, cmbEstSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0)), 1, cmbEstSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbEstSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Configuracion\\Departamentos.htm");
         cmbEstSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         AssignProp("", false, cmbEstSts_Internalname, "Values", (string)(cmbEstSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Departamentos.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_paicod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombopaicod_Internalname, StringUtil.RTrim( AV19ComboPaiCod), StringUtil.RTrim( context.localUtil.Format( AV19ComboPaiCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaicod_Visible, edtavCombopaicod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstAbr_Internalname, StringUtil.RTrim( A974EstAbr), StringUtil.RTrim( context.localUtil.Format( A974EstAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstAbr_Jsonclick, 0, "Attribute", "", "", "", "", edtEstAbr_Visible, edtEstAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Departamentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPAICOD_DATA"), AV14PaiCod_Data);
               /* Read saved values. */
               Z139PaiCod = cgiGet( "Z139PaiCod");
               Z140EstCod = cgiGet( "Z140EstCod");
               Z602EstDsc = cgiGet( "Z602EstDsc");
               Z974EstAbr = cgiGet( "Z974EstAbr");
               Z975EstSts = (short)(context.localUtil.CToN( cgiGet( "Z975EstSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV10PaiCod = cgiGet( "vPAICOD");
               AV7EstCod = cgiGet( "vESTCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A1500PaiDsc = cgiGet( "PAIDSC");
               Combo_paicod_Objectcall = cgiGet( "COMBO_PAICOD_Objectcall");
               Combo_paicod_Class = cgiGet( "COMBO_PAICOD_Class");
               Combo_paicod_Icontype = cgiGet( "COMBO_PAICOD_Icontype");
               Combo_paicod_Icon = cgiGet( "COMBO_PAICOD_Icon");
               Combo_paicod_Caption = cgiGet( "COMBO_PAICOD_Caption");
               Combo_paicod_Tooltip = cgiGet( "COMBO_PAICOD_Tooltip");
               Combo_paicod_Cls = cgiGet( "COMBO_PAICOD_Cls");
               Combo_paicod_Selectedvalue_set = cgiGet( "COMBO_PAICOD_Selectedvalue_set");
               Combo_paicod_Selectedvalue_get = cgiGet( "COMBO_PAICOD_Selectedvalue_get");
               Combo_paicod_Selectedtext_set = cgiGet( "COMBO_PAICOD_Selectedtext_set");
               Combo_paicod_Selectedtext_get = cgiGet( "COMBO_PAICOD_Selectedtext_get");
               Combo_paicod_Gamoauthtoken = cgiGet( "COMBO_PAICOD_Gamoauthtoken");
               Combo_paicod_Ddointernalname = cgiGet( "COMBO_PAICOD_Ddointernalname");
               Combo_paicod_Titlecontrolalign = cgiGet( "COMBO_PAICOD_Titlecontrolalign");
               Combo_paicod_Dropdownoptionstype = cgiGet( "COMBO_PAICOD_Dropdownoptionstype");
               Combo_paicod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Enabled"));
               Combo_paicod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Visible"));
               Combo_paicod_Titlecontrolidtoreplace = cgiGet( "COMBO_PAICOD_Titlecontrolidtoreplace");
               Combo_paicod_Datalisttype = cgiGet( "COMBO_PAICOD_Datalisttype");
               Combo_paicod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Allowmultipleselection"));
               Combo_paicod_Datalistfixedvalues = cgiGet( "COMBO_PAICOD_Datalistfixedvalues");
               Combo_paicod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Isgriditem"));
               Combo_paicod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Hasdescription"));
               Combo_paicod_Datalistproc = cgiGet( "COMBO_PAICOD_Datalistproc");
               Combo_paicod_Datalistprocparametersprefix = cgiGet( "COMBO_PAICOD_Datalistprocparametersprefix");
               Combo_paicod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAICOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_paicod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeonlyselectedoption"));
               Combo_paicod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeselectalloption"));
               Combo_paicod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Emptyitem"));
               Combo_paicod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeaddnewoption"));
               Combo_paicod_Htmltemplate = cgiGet( "COMBO_PAICOD_Htmltemplate");
               Combo_paicod_Multiplevaluestype = cgiGet( "COMBO_PAICOD_Multiplevaluestype");
               Combo_paicod_Loadingdata = cgiGet( "COMBO_PAICOD_Loadingdata");
               Combo_paicod_Noresultsfound = cgiGet( "COMBO_PAICOD_Noresultsfound");
               Combo_paicod_Emptyitemtext = cgiGet( "COMBO_PAICOD_Emptyitemtext");
               Combo_paicod_Onlyselectedvalues = cgiGet( "COMBO_PAICOD_Onlyselectedvalues");
               Combo_paicod_Selectalltext = cgiGet( "COMBO_PAICOD_Selectalltext");
               Combo_paicod_Multiplevaluesseparator = cgiGet( "COMBO_PAICOD_Multiplevaluesseparator");
               Combo_paicod_Addnewoptiontext = cgiGet( "COMBO_PAICOD_Addnewoptiontext");
               Combo_paicod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAICOD_Gxcontroltype"), ".", ","));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A139PaiCod = cgiGet( edtPaiCod_Internalname);
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = cgiGet( edtEstCod_Internalname);
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A602EstDsc = cgiGet( edtEstDsc_Internalname);
               AssignAttri("", false, "A602EstDsc", A602EstDsc);
               cmbEstSts.CurrentValue = cgiGet( cmbEstSts_Internalname);
               A975EstSts = (short)(NumberUtil.Val( cgiGet( cmbEstSts_Internalname), "."));
               AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
               AV19ComboPaiCod = cgiGet( edtavCombopaicod_Internalname);
               AssignAttri("", false, "AV19ComboPaiCod", AV19ComboPaiCod);
               A974EstAbr = cgiGet( edtEstAbr_Internalname);
               AssignAttri("", false, "A974EstAbr", A974EstAbr);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Departamentos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\departamentos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A139PaiCod = GetPar( "PaiCod");
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = GetPar( "EstCod");
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode79 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode79;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound79 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAICOD");
                        AnyError = 1;
                        GX_FocusControl = edtPaiCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E115U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E125U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5U79( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes5U79( ) ;
         }
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_5U0( )
      {
         BeforeValidate5U79( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5U79( ) ;
            }
            else
            {
               CheckExtendedTable5U79( ) ;
               CloseExtendedTableCursors5U79( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5U0( )
      {
      }

      protected void E115U2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtPaiCod_Visible = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaiCod_Visible), 5, 0), true);
         AV19ComboPaiCod = "";
         AssignAttri("", false, "AV19ComboPaiCod", AV19ComboPaiCod);
         edtavCombopaicod_Visible = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPAICOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         edtEstAbr_Visible = 0;
         AssignProp("", false, edtEstAbr_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstAbr_Visible), 5, 0), true);
      }

      protected void E125U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV20SGAuDocGls = "Departamento N° " + StringUtil.Trim( A140EstCod) + " " + StringUtil.Trim( A602EstDsc);
            AV21Codigo = A140EstCod;
            GXt_char2 = "CNF";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV20SGAuDocGls, ref  AV21Codigo, ref  AV21Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.departamentosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPAICOD' Routine */
         returnInSub = false;
         GXt_char4 = AV18Combo_DataJson;
         new GeneXus.Programs.configuracion.departamentosloaddvcombo(context ).execute(  "PaiCod",  Gx_mode,  false,  AV10PaiCod,  AV7EstCod,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char4) ;
         AV18Combo_DataJson = GXt_char4;
         Combo_paicod_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
         Combo_paicod_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
         AV19ComboPaiCod = AV16ComboSelectedValue;
         AssignAttri("", false, "AV19ComboPaiCod", AV19ComboPaiCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            Combo_paicod_Enabled = false;
            ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         }
      }

      protected void ZM5U79( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z602EstDsc = T005U3_A602EstDsc[0];
               Z974EstAbr = T005U3_A974EstAbr[0];
               Z975EstSts = T005U3_A975EstSts[0];
            }
            else
            {
               Z602EstDsc = A602EstDsc;
               Z974EstAbr = A974EstAbr;
               Z975EstSts = A975EstSts;
            }
         }
         if ( GX_JID == -11 )
         {
            Z140EstCod = A140EstCod;
            Z602EstDsc = A602EstDsc;
            Z974EstAbr = A974EstAbr;
            Z975EstSts = A975EstSts;
            Z139PaiCod = A139PaiCod;
            Z1500PaiDsc = A1500PaiDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            edtPaiCod_Enabled = 0;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPaiCod_Enabled = 1;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            edtPaiCod_Enabled = 0;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstCod)) )
         {
            A140EstCod = AV7EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstCod)) )
         {
            edtEstCod_Enabled = 0;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         else
         {
            edtEstCod_Enabled = 1;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstCod)) )
         {
            edtEstCod_Enabled = 0;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            A139PaiCod = AV10PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         else
         {
            A139PaiCod = AV19ComboPaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (0==A975EstSts) && ( Gx_BScreen == 0 ) )
         {
            A975EstSts = 1;
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T005U4 */
            pr_default.execute(2, new Object[] {A139PaiCod});
            A1500PaiDsc = T005U4_A1500PaiDsc[0];
            pr_default.close(2);
         }
      }

      protected void Load5U79( )
      {
         /* Using cursor T005U5 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound79 = 1;
            A602EstDsc = T005U5_A602EstDsc[0];
            AssignAttri("", false, "A602EstDsc", A602EstDsc);
            A1500PaiDsc = T005U5_A1500PaiDsc[0];
            A974EstAbr = T005U5_A974EstAbr[0];
            AssignAttri("", false, "A974EstAbr", A974EstAbr);
            A975EstSts = T005U5_A975EstSts[0];
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            ZM5U79( -11) ;
         }
         pr_default.close(3);
         OnLoadActions5U79( ) ;
      }

      protected void OnLoadActions5U79( )
      {
      }

      protected void CheckExtendedTable5U79( )
      {
         nIsDirty_79 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T005U4 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T005U4_A1500PaiDsc[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Pais", "", "", "", "", "", "", "", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A140EstCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Estado", "", "", "", "", "", "", "", ""), 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtEstCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A602EstDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Departamento", "", "", "", "", "", "", "", ""), 1, "ESTDSC");
            AnyError = 1;
            GX_FocusControl = edtEstDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5U79( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( string A139PaiCod )
      {
         /* Using cursor T005U6 */
         pr_default.execute(4, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T005U6_A1500PaiDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1500PaiDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey5U79( )
      {
         /* Using cursor T005U7 */
         pr_default.execute(5, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005U3 */
         pr_default.execute(1, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5U79( 11) ;
            RcdFound79 = 1;
            A140EstCod = T005U3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A602EstDsc = T005U3_A602EstDsc[0];
            AssignAttri("", false, "A602EstDsc", A602EstDsc);
            A974EstAbr = T005U3_A974EstAbr[0];
            AssignAttri("", false, "A974EstAbr", A974EstAbr);
            A975EstSts = T005U3_A975EstSts[0];
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            A139PaiCod = T005U3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5U79( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey5U79( ) ;
            }
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey5U79( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5U79( ) ;
         if ( RcdFound79 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound79 = 0;
         /* Using cursor T005U8 */
         pr_default.execute(6, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T005U8_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T005U8_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005U8_A140EstCod[0], A140EstCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T005U8_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T005U8_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005U8_A140EstCod[0], A140EstCod) > 0 ) ) )
            {
               A139PaiCod = T005U8_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T005U8_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               RcdFound79 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound79 = 0;
         /* Using cursor T005U9 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T005U9_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T005U9_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005U9_A140EstCod[0], A140EstCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T005U9_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T005U9_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005U9_A140EstCod[0], A140EstCod) < 0 ) ) )
            {
               A139PaiCod = T005U9_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T005U9_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               RcdFound79 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5U79( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5U79( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = Z140EstCod;
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAICOD");
                  AnyError = 1;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5U79( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5U79( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAICOD");
                     AnyError = 1;
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5U79( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = Z140EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5U79( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005U2 */
            pr_default.execute(0, new Object[] {A139PaiCod, A140EstCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CESTADOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z602EstDsc, T005U2_A602EstDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z974EstAbr, T005U2_A974EstAbr[0]) != 0 ) || ( Z975EstSts != T005U2_A975EstSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z602EstDsc, T005U2_A602EstDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.departamentos:[seudo value changed for attri]"+"EstDsc");
                  GXUtil.WriteLogRaw("Old: ",Z602EstDsc);
                  GXUtil.WriteLogRaw("Current: ",T005U2_A602EstDsc[0]);
               }
               if ( StringUtil.StrCmp(Z974EstAbr, T005U2_A974EstAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.departamentos:[seudo value changed for attri]"+"EstAbr");
                  GXUtil.WriteLogRaw("Old: ",Z974EstAbr);
                  GXUtil.WriteLogRaw("Current: ",T005U2_A974EstAbr[0]);
               }
               if ( Z975EstSts != T005U2_A975EstSts[0] )
               {
                  GXUtil.WriteLog("configuracion.departamentos:[seudo value changed for attri]"+"EstSts");
                  GXUtil.WriteLogRaw("Old: ",Z975EstSts);
                  GXUtil.WriteLogRaw("Current: ",T005U2_A975EstSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CESTADOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5U79( )
      {
         BeforeValidate5U79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5U79( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5U79( 0) ;
            CheckOptimisticConcurrency5U79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5U79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5U79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005U10 */
                     pr_default.execute(8, new Object[] {A140EstCod, A602EstDsc, A974EstAbr, A975EstSts, A139PaiCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CESTADOS");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption5U0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load5U79( ) ;
            }
            EndLevel5U79( ) ;
         }
         CloseExtendedTableCursors5U79( ) ;
      }

      protected void Update5U79( )
      {
         BeforeValidate5U79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5U79( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5U79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5U79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5U79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005U11 */
                     pr_default.execute(9, new Object[] {A602EstDsc, A974EstAbr, A975EstSts, A139PaiCod, A140EstCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CESTADOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CESTADOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5U79( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel5U79( ) ;
         }
         CloseExtendedTableCursors5U79( ) ;
      }

      protected void DeferredUpdate5U79( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5U79( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5U79( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5U79( ) ;
            AfterConfirm5U79( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5U79( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005U12 */
                  pr_default.execute(10, new Object[] {A139PaiCod, A140EstCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CESTADOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5U79( ) ;
         Gx_mode = sMode79;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5U79( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005U13 */
            pr_default.execute(11, new Object[] {A139PaiCod});
            A1500PaiDsc = T005U13_A1500PaiDsc[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005U14 */
            pr_default.execute(12, new Object[] {A139PaiCod, A140EstCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Provincias"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel5U79( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5U79( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("configuracion.departamentos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("configuracion.departamentos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5U79( )
      {
         /* Scan By routine */
         /* Using cursor T005U15 */
         pr_default.execute(13);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound79 = 1;
            A139PaiCod = T005U15_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005U15_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5U79( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound79 = 1;
            A139PaiCod = T005U15_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005U15_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
      }

      protected void ScanEnd5U79( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm5U79( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5U79( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5U79( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5U79( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5U79( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5U79( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5U79( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtEstDsc_Enabled = 0;
         AssignProp("", false, edtEstDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstDsc_Enabled), 5, 0), true);
         cmbEstSts.Enabled = 0;
         AssignProp("", false, cmbEstSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEstSts.Enabled), 5, 0), true);
         edtavCombopaicod_Enabled = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         edtEstAbr_Enabled = 0;
         AssignProp("", false, edtEstAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstAbr_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5U79( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5U0( )
      {
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810261596", false, true);
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.departamentos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10PaiCod)) + "," + UrlEncode(StringUtil.RTrim(AV7EstCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.departamentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Departamentos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\departamentos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z602EstDsc", StringUtil.RTrim( Z602EstDsc));
         GxWebStd.gx_hidden_field( context, "Z974EstAbr", StringUtil.RTrim( Z974EstAbr));
         GxWebStd.gx_hidden_field( context, "Z975EstSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z975EstSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAICOD_DATA", AV14PaiCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAICOD_DATA", AV14PaiCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPAICOD", StringUtil.RTrim( AV10PaiCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PaiCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTCOD", StringUtil.RTrim( AV7EstCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7EstCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAIDSC", StringUtil.RTrim( A1500PaiDsc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Objectcall", StringUtil.RTrim( Combo_paicod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Cls", StringUtil.RTrim( Combo_paicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedvalue_set", StringUtil.RTrim( Combo_paicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedtext_set", StringUtil.RTrim( Combo_paicod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Datalistproc", StringUtil.RTrim( Combo_paicod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_paicod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Emptyitem", StringUtil.BoolToStr( Combo_paicod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.departamentos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10PaiCod)) + "," + UrlEncode(StringUtil.RTrim(AV7EstCod));
         return formatLink("configuracion.departamentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Departamentos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Departamentos" ;
      }

      protected void InitializeNonKey5U79( )
      {
         A602EstDsc = "";
         AssignAttri("", false, "A602EstDsc", A602EstDsc);
         A1500PaiDsc = "";
         AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
         A974EstAbr = "";
         AssignAttri("", false, "A974EstAbr", A974EstAbr);
         A975EstSts = 1;
         AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         Z602EstDsc = "";
         Z974EstAbr = "";
         Z975EstSts = 0;
      }

      protected void InitAll5U79( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         InitializeNonKey5U79( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A975EstSts = i975EstSts;
         AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261622", true, true);
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
         context.AddJavascriptSource("configuracion/departamentos.js", "?202281810261623", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblockpaicod_Internalname = "TEXTBLOCKPAICOD";
         Combo_paicod_Internalname = "COMBO_PAICOD";
         edtPaiCod_Internalname = "PAICOD";
         divTablesplittedpaicod_Internalname = "TABLESPLITTEDPAICOD";
         edtEstCod_Internalname = "ESTCOD";
         edtEstDsc_Internalname = "ESTDSC";
         cmbEstSts_Internalname = "ESTSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopaicod_Internalname = "vCOMBOPAICOD";
         divSectionattribute_paicod_Internalname = "SECTIONATTRIBUTE_PAICOD";
         edtEstAbr_Internalname = "ESTABR";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Departamentos";
         edtEstAbr_Jsonclick = "";
         edtEstAbr_Enabled = 1;
         edtEstAbr_Visible = 1;
         edtavCombopaicod_Jsonclick = "";
         edtavCombopaicod_Enabled = 0;
         edtavCombopaicod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbEstSts_Jsonclick = "";
         cmbEstSts.Enabled = 1;
         edtEstDsc_Jsonclick = "";
         edtEstDsc_Enabled = 1;
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
         edtPaiCod_Visible = 1;
         Combo_paicod_Emptyitem = Convert.ToBoolean( 0);
         Combo_paicod_Datalistprocparametersprefix = " \"ComboName\": \"PaiCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaiCod\": \"\", \"EstCod\": \"\"";
         Combo_paicod_Datalistproc = "Configuracion.DepartamentosLoadDVCombo";
         Combo_paicod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_paicod_Caption = "";
         Combo_paicod_Enabled = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Información General";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbEstSts.Name = "ESTSTS";
         cmbEstSts.WebTags = "";
         cmbEstSts.addItem("1", "ACTIVO", 0);
         cmbEstSts.addItem("0", "INACTIVO", 0);
         if ( cmbEstSts.ItemCount > 0 )
         {
            if ( (0==A975EstSts) )
            {
               A975EstSts = 1;
               AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Paicod( )
      {
         /* Using cursor T005U13 */
         pr_default.execute(11, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A1500PaiDsc = T005U13_A1500PaiDsc[0];
         pr_default.close(11);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Pais", "", "", "", "", "", "", "", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10PaiCod',fld:'vPAICOD',pic:'',hsh:true},{av:'AV7EstCod',fld:'vESTCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV10PaiCod',fld:'vPAICOD',pic:'',hsh:true},{av:'AV7EstCod',fld:'vESTCOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A602EstDsc',fld:'ESTDSC',pic:''},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_ESTDSC","{handler:'Valid_Estdsc',iparms:[]");
         setEventMetadata("VALID_ESTDSC",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPAICOD","{handler:'Validv_Combopaicod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPAICOD",",oparms:[]}");
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
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV10PaiCod = "";
         wcpOAV7EstCod = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z602EstDsc = "";
         Z974EstAbr = "";
         Combo_paicod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockpaicod_Jsonclick = "";
         ucCombo_paicod = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14PaiCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A140EstCod = "";
         A602EstDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV19ComboPaiCod = "";
         A974EstAbr = "";
         A1500PaiDsc = "";
         Combo_paicod_Objectcall = "";
         Combo_paicod_Class = "";
         Combo_paicod_Icontype = "";
         Combo_paicod_Icon = "";
         Combo_paicod_Tooltip = "";
         Combo_paicod_Selectedvalue_set = "";
         Combo_paicod_Selectedtext_set = "";
         Combo_paicod_Selectedtext_get = "";
         Combo_paicod_Gamoauthtoken = "";
         Combo_paicod_Ddointernalname = "";
         Combo_paicod_Titlecontrolalign = "";
         Combo_paicod_Dropdownoptionstype = "";
         Combo_paicod_Titlecontrolidtoreplace = "";
         Combo_paicod_Datalisttype = "";
         Combo_paicod_Datalistfixedvalues = "";
         Combo_paicod_Htmltemplate = "";
         Combo_paicod_Multiplevaluestype = "";
         Combo_paicod_Loadingdata = "";
         Combo_paicod_Noresultsfound = "";
         Combo_paicod_Emptyitemtext = "";
         Combo_paicod_Onlyselectedvalues = "";
         Combo_paicod_Selectalltext = "";
         Combo_paicod_Multiplevaluesseparator = "";
         Combo_paicod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode79 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV20SGAuDocGls = "";
         AV21Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         AV18Combo_DataJson = "";
         GXt_char4 = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         Z1500PaiDsc = "";
         T005U4_A1500PaiDsc = new string[] {""} ;
         T005U5_A140EstCod = new string[] {""} ;
         T005U5_A602EstDsc = new string[] {""} ;
         T005U5_A1500PaiDsc = new string[] {""} ;
         T005U5_A974EstAbr = new string[] {""} ;
         T005U5_A975EstSts = new short[1] ;
         T005U5_A139PaiCod = new string[] {""} ;
         T005U6_A1500PaiDsc = new string[] {""} ;
         T005U7_A139PaiCod = new string[] {""} ;
         T005U7_A140EstCod = new string[] {""} ;
         T005U3_A140EstCod = new string[] {""} ;
         T005U3_A602EstDsc = new string[] {""} ;
         T005U3_A974EstAbr = new string[] {""} ;
         T005U3_A975EstSts = new short[1] ;
         T005U3_A139PaiCod = new string[] {""} ;
         T005U8_A139PaiCod = new string[] {""} ;
         T005U8_A140EstCod = new string[] {""} ;
         T005U9_A139PaiCod = new string[] {""} ;
         T005U9_A140EstCod = new string[] {""} ;
         T005U2_A140EstCod = new string[] {""} ;
         T005U2_A602EstDsc = new string[] {""} ;
         T005U2_A974EstAbr = new string[] {""} ;
         T005U2_A975EstSts = new short[1] ;
         T005U2_A139PaiCod = new string[] {""} ;
         T005U13_A1500PaiDsc = new string[] {""} ;
         T005U14_A139PaiCod = new string[] {""} ;
         T005U14_A140EstCod = new string[] {""} ;
         T005U14_A141ProvCod = new string[] {""} ;
         T005U15_A139PaiCod = new string[] {""} ;
         T005U15_A140EstCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.departamentos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.departamentos__default(),
            new Object[][] {
                new Object[] {
               T005U2_A140EstCod, T005U2_A602EstDsc, T005U2_A974EstAbr, T005U2_A975EstSts, T005U2_A139PaiCod
               }
               , new Object[] {
               T005U3_A140EstCod, T005U3_A602EstDsc, T005U3_A974EstAbr, T005U3_A975EstSts, T005U3_A139PaiCod
               }
               , new Object[] {
               T005U4_A1500PaiDsc
               }
               , new Object[] {
               T005U5_A140EstCod, T005U5_A602EstDsc, T005U5_A1500PaiDsc, T005U5_A974EstAbr, T005U5_A975EstSts, T005U5_A139PaiCod
               }
               , new Object[] {
               T005U6_A1500PaiDsc
               }
               , new Object[] {
               T005U7_A139PaiCod, T005U7_A140EstCod
               }
               , new Object[] {
               T005U8_A139PaiCod, T005U8_A140EstCod
               }
               , new Object[] {
               T005U9_A139PaiCod, T005U9_A140EstCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005U13_A1500PaiDsc
               }
               , new Object[] {
               T005U14_A139PaiCod, T005U14_A140EstCod, T005U14_A141ProvCod
               }
               , new Object[] {
               T005U15_A139PaiCod, T005U15_A140EstCod
               }
            }
         );
         Z975EstSts = 1;
         A975EstSts = 1;
         i975EstSts = 1;
      }

      private short Z975EstSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A975EstSts ;
      private short Gx_BScreen ;
      private short RcdFound79 ;
      private short GX_JID ;
      private short nIsDirty_79 ;
      private short gxajaxcallmode ;
      private short i975EstSts ;
      private int trnEnded ;
      private int edtPaiCod_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Enabled ;
      private int edtEstDsc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombopaicod_Visible ;
      private int edtavCombopaicod_Enabled ;
      private int edtEstAbr_Visible ;
      private int edtEstAbr_Enabled ;
      private int Combo_paicod_Datalistupdateminimumcharacters ;
      private int Combo_paicod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV10PaiCod ;
      private string wcpOAV7EstCod ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z602EstDsc ;
      private string Z974EstAbr ;
      private string Combo_paicod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV10PaiCod ;
      private string AV7EstCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbEstSts_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedpaicod_Internalname ;
      private string lblTextblockpaicod_Internalname ;
      private string lblTextblockpaicod_Jsonclick ;
      private string Combo_paicod_Caption ;
      private string Combo_paicod_Cls ;
      private string Combo_paicod_Datalistproc ;
      private string Combo_paicod_Datalistprocparametersprefix ;
      private string Combo_paicod_Internalname ;
      private string TempTags ;
      private string edtPaiCod_Jsonclick ;
      private string edtEstCod_Internalname ;
      private string A140EstCod ;
      private string edtEstCod_Jsonclick ;
      private string edtEstDsc_Internalname ;
      private string A602EstDsc ;
      private string edtEstDsc_Jsonclick ;
      private string cmbEstSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_paicod_Internalname ;
      private string edtavCombopaicod_Internalname ;
      private string AV19ComboPaiCod ;
      private string edtavCombopaicod_Jsonclick ;
      private string edtEstAbr_Internalname ;
      private string A974EstAbr ;
      private string edtEstAbr_Jsonclick ;
      private string A1500PaiDsc ;
      private string Combo_paicod_Objectcall ;
      private string Combo_paicod_Class ;
      private string Combo_paicod_Icontype ;
      private string Combo_paicod_Icon ;
      private string Combo_paicod_Tooltip ;
      private string Combo_paicod_Selectedvalue_set ;
      private string Combo_paicod_Selectedtext_set ;
      private string Combo_paicod_Selectedtext_get ;
      private string Combo_paicod_Gamoauthtoken ;
      private string Combo_paicod_Ddointernalname ;
      private string Combo_paicod_Titlecontrolalign ;
      private string Combo_paicod_Dropdownoptionstype ;
      private string Combo_paicod_Titlecontrolidtoreplace ;
      private string Combo_paicod_Datalisttype ;
      private string Combo_paicod_Datalistfixedvalues ;
      private string Combo_paicod_Htmltemplate ;
      private string Combo_paicod_Multiplevaluestype ;
      private string Combo_paicod_Loadingdata ;
      private string Combo_paicod_Noresultsfound ;
      private string Combo_paicod_Emptyitemtext ;
      private string Combo_paicod_Onlyselectedvalues ;
      private string Combo_paicod_Selectalltext ;
      private string Combo_paicod_Multiplevaluesseparator ;
      private string Combo_paicod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode79 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string Z1500PaiDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_paicod_Emptyitem ;
      private bool Combo_paicod_Enabled ;
      private bool Combo_paicod_Visible ;
      private bool Combo_paicod_Allowmultipleselection ;
      private bool Combo_paicod_Isgriditem ;
      private bool Combo_paicod_Hasdescription ;
      private bool Combo_paicod_Includeonlyselectedoption ;
      private bool Combo_paicod_Includeselectalloption ;
      private bool Combo_paicod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string AV20SGAuDocGls ;
      private string AV21Codigo ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_paicod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEstSts ;
      private IDataStoreProvider pr_default ;
      private string[] T005U4_A1500PaiDsc ;
      private string[] T005U5_A140EstCod ;
      private string[] T005U5_A602EstDsc ;
      private string[] T005U5_A1500PaiDsc ;
      private string[] T005U5_A974EstAbr ;
      private short[] T005U5_A975EstSts ;
      private string[] T005U5_A139PaiCod ;
      private string[] T005U6_A1500PaiDsc ;
      private string[] T005U7_A139PaiCod ;
      private string[] T005U7_A140EstCod ;
      private string[] T005U3_A140EstCod ;
      private string[] T005U3_A602EstDsc ;
      private string[] T005U3_A974EstAbr ;
      private short[] T005U3_A975EstSts ;
      private string[] T005U3_A139PaiCod ;
      private string[] T005U8_A139PaiCod ;
      private string[] T005U8_A140EstCod ;
      private string[] T005U9_A139PaiCod ;
      private string[] T005U9_A140EstCod ;
      private string[] T005U2_A140EstCod ;
      private string[] T005U2_A602EstDsc ;
      private string[] T005U2_A974EstAbr ;
      private short[] T005U2_A975EstSts ;
      private string[] T005U2_A139PaiCod ;
      private string[] T005U13_A1500PaiDsc ;
      private string[] T005U14_A139PaiCod ;
      private string[] T005U14_A140EstCod ;
      private string[] T005U14_A141ProvCod ;
      private string[] T005U15_A139PaiCod ;
      private string[] T005U15_A140EstCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14PaiCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
   }

   public class departamentos__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class departamentos__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005U5;
        prmT005U5 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U4;
        prmT005U4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005U6;
        prmT005U6 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005U7;
        prmT005U7 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U3;
        prmT005U3 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U8;
        prmT005U8 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U9;
        prmT005U9 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U2;
        prmT005U2 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U10;
        prmT005U10 = new Object[] {
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@EstDsc",GXType.NChar,100,0) ,
        new ParDef("@EstAbr",GXType.NChar,5,0) ,
        new ParDef("@EstSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005U11;
        prmT005U11 = new Object[] {
        new ParDef("@EstDsc",GXType.NChar,100,0) ,
        new ParDef("@EstAbr",GXType.NChar,5,0) ,
        new ParDef("@EstSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U12;
        prmT005U12 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U14;
        prmT005U14 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005U15;
        prmT005U15 = new Object[] {
        };
        Object[] prmT005U13;
        prmT005U13 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005U2", "SELECT [EstCod], [EstDsc], [EstAbr], [EstSts], [PaiCod] FROM [CESTADOS] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U3", "SELECT [EstCod], [EstDsc], [EstAbr], [EstSts], [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U4", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U5", "SELECT TM1.[EstCod], TM1.[EstDsc], T2.[PaiDsc], TM1.[EstAbr], TM1.[EstSts], TM1.[PaiCod] FROM ([CESTADOS] TM1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = TM1.[PaiCod]) WHERE TM1.[PaiCod] = @PaiCod and TM1.[EstCod] = @EstCod ORDER BY TM1.[PaiCod], TM1.[EstCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005U5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U6", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005U6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U7", "SELECT [PaiCod], [EstCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U8", "SELECT TOP 1 [PaiCod], [EstCod] FROM [CESTADOS] WHERE ( [PaiCod] > @PaiCod or [PaiCod] = @PaiCod and [EstCod] > @EstCod) ORDER BY [PaiCod], [EstCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005U8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005U9", "SELECT TOP 1 [PaiCod], [EstCod] FROM [CESTADOS] WHERE ( [PaiCod] < @PaiCod or [PaiCod] = @PaiCod and [EstCod] < @EstCod) ORDER BY [PaiCod] DESC, [EstCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005U9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005U10", "INSERT INTO [CESTADOS]([EstCod], [EstDsc], [EstAbr], [EstSts], [PaiCod]) VALUES(@EstCod, @EstDsc, @EstAbr, @EstSts, @PaiCod)", GxErrorMask.GX_NOMASK,prmT005U10)
           ,new CursorDef("T005U11", "UPDATE [CESTADOS] SET [EstDsc]=@EstDsc, [EstAbr]=@EstAbr, [EstSts]=@EstSts  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod", GxErrorMask.GX_NOMASK,prmT005U11)
           ,new CursorDef("T005U12", "DELETE FROM [CESTADOS]  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod", GxErrorMask.GX_NOMASK,prmT005U12)
           ,new CursorDef("T005U13", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005U13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005U14", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005U14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005U15", "SELECT [PaiCod], [EstCod] FROM [CESTADOS] ORDER BY [PaiCod], [EstCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005U15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
     }
  }

}

}
