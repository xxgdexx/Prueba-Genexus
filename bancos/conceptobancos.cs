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
namespace GeneXus.Programs.bancos {
   public class conceptobancos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vCCONBCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASACCONBCOD6C171( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A374ConBCueCod = GetPar( "ConBCueCod");
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A374ConBCueCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.conceptobancos.aspx")), "bancos.conceptobancos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.conceptobancos.aspx")))) ;
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
                  AV7ConBCod = (int)(NumberUtil.Val( GetPar( "ConBCod"), "."));
                  AssignAttri("", false, "AV7ConBCod", StringUtil.LTrimStr( (decimal)(AV7ConBCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConBCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Conceptos de Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConBDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public conceptobancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptobancos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ConBCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ConBCod = aP1_ConBCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbConBSts = new GXCombobox();
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
         if ( cmbConBSts.ItemCount > 0 )
         {
            A746ConBSts = (short)(NumberUtil.Val( cmbConBSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0))), "."));
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConBSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            AssignProp("", false, cmbConBSts_Internalname, "Values", cmbConBSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtConBDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConBDsc_Internalname, "Concepto", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBDsc_Internalname, StringUtil.RTrim( A745ConBDsc), StringUtil.RTrim( context.localUtil.Format( A745ConBDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtConBDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedconbcuecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockconbcuecod_Internalname, "Cuenta Contable", "", "", lblTextblockconbcuecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\ConceptoBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_conbcuecod.SetProperty("Caption", Combo_conbcuecod_Caption);
         ucCombo_conbcuecod.SetProperty("Cls", Combo_conbcuecod_Cls);
         ucCombo_conbcuecod.SetProperty("DataListProc", Combo_conbcuecod_Datalistproc);
         ucCombo_conbcuecod.SetProperty("DataListProcParametersPrefix", Combo_conbcuecod_Datalistprocparametersprefix);
         ucCombo_conbcuecod.SetProperty("EmptyItem", Combo_conbcuecod_Emptyitem);
         ucCombo_conbcuecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_conbcuecod.SetProperty("DropDownOptionsData", AV15ConBCueCod_Data);
         ucCombo_conbcuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_conbcuecod_Internalname, "COMBO_CONBCUECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConBCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBCueCod_Internalname, StringUtil.RTrim( A374ConBCueCod), StringUtil.RTrim( context.localUtil.Format( A374ConBCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCueCod_Jsonclick, 0, "Attribute", "", "", "", "", edtConBCueCod_Visible, edtConBCueCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoBancos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbConBSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConBSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConBSts, cmbConBSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0)), 1, cmbConBSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbConBSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 1, "HLP_Bancos\\ConceptoBancos.htm");
         cmbConBSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         AssignProp("", false, cmbConBSts_Internalname, "Values", (string)(cmbConBSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\ConceptoBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\ConceptoBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\ConceptoBancos.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_conbcuecod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboconbcuecod_Internalname, StringUtil.RTrim( AV20ComboConBCueCod), StringUtil.RTrim( context.localUtil.Format( AV20ComboConBCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboconbcuecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboconbcuecod_Visible, edtavComboconbcuecod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A355ConBCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A355ConBCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCod_Jsonclick, 0, "Attribute", "", "", "", "", edtConBCod_Visible, edtConBCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\ConceptoBancos.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtConBCueDsc_Internalname, StringUtil.RTrim( A744ConBCueDsc), StringUtil.RTrim( context.localUtil.Format( A744ConBCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", edtConBCueDsc_Visible, edtConBCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\ConceptoBancos.htm");
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
         E116C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCONBCUECOD_DATA"), AV15ConBCueCod_Data);
               /* Read saved values. */
               Z355ConBCod = (int)(context.localUtil.CToN( cgiGet( "Z355ConBCod"), ".", ","));
               Z745ConBDsc = cgiGet( "Z745ConBDsc");
               Z746ConBSts = (short)(context.localUtil.CToN( cgiGet( "Z746ConBSts"), ".", ","));
               Z374ConBCueCod = cgiGet( "Z374ConBCueCod");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N374ConBCueCod = cgiGet( "N374ConBCueCod");
               AV7ConBCod = (int)(context.localUtil.CToN( cgiGet( "vCONBCOD"), ".", ","));
               AV22cConBCod = (int)(context.localUtil.CToN( cgiGet( "vCCONBCOD"), ".", ","));
               AV13Insert_ConBCueCod = cgiGet( "vINSERT_CONBCUECOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV26Pgmname = cgiGet( "vPGMNAME");
               Combo_conbcuecod_Objectcall = cgiGet( "COMBO_CONBCUECOD_Objectcall");
               Combo_conbcuecod_Class = cgiGet( "COMBO_CONBCUECOD_Class");
               Combo_conbcuecod_Icontype = cgiGet( "COMBO_CONBCUECOD_Icontype");
               Combo_conbcuecod_Icon = cgiGet( "COMBO_CONBCUECOD_Icon");
               Combo_conbcuecod_Caption = cgiGet( "COMBO_CONBCUECOD_Caption");
               Combo_conbcuecod_Tooltip = cgiGet( "COMBO_CONBCUECOD_Tooltip");
               Combo_conbcuecod_Cls = cgiGet( "COMBO_CONBCUECOD_Cls");
               Combo_conbcuecod_Selectedvalue_set = cgiGet( "COMBO_CONBCUECOD_Selectedvalue_set");
               Combo_conbcuecod_Selectedvalue_get = cgiGet( "COMBO_CONBCUECOD_Selectedvalue_get");
               Combo_conbcuecod_Selectedtext_set = cgiGet( "COMBO_CONBCUECOD_Selectedtext_set");
               Combo_conbcuecod_Selectedtext_get = cgiGet( "COMBO_CONBCUECOD_Selectedtext_get");
               Combo_conbcuecod_Gamoauthtoken = cgiGet( "COMBO_CONBCUECOD_Gamoauthtoken");
               Combo_conbcuecod_Ddointernalname = cgiGet( "COMBO_CONBCUECOD_Ddointernalname");
               Combo_conbcuecod_Titlecontrolalign = cgiGet( "COMBO_CONBCUECOD_Titlecontrolalign");
               Combo_conbcuecod_Dropdownoptionstype = cgiGet( "COMBO_CONBCUECOD_Dropdownoptionstype");
               Combo_conbcuecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Enabled"));
               Combo_conbcuecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Visible"));
               Combo_conbcuecod_Titlecontrolidtoreplace = cgiGet( "COMBO_CONBCUECOD_Titlecontrolidtoreplace");
               Combo_conbcuecod_Datalisttype = cgiGet( "COMBO_CONBCUECOD_Datalisttype");
               Combo_conbcuecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Allowmultipleselection"));
               Combo_conbcuecod_Datalistfixedvalues = cgiGet( "COMBO_CONBCUECOD_Datalistfixedvalues");
               Combo_conbcuecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Isgriditem"));
               Combo_conbcuecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Hasdescription"));
               Combo_conbcuecod_Datalistproc = cgiGet( "COMBO_CONBCUECOD_Datalistproc");
               Combo_conbcuecod_Datalistprocparametersprefix = cgiGet( "COMBO_CONBCUECOD_Datalistprocparametersprefix");
               Combo_conbcuecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CONBCUECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_conbcuecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Includeonlyselectedoption"));
               Combo_conbcuecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Includeselectalloption"));
               Combo_conbcuecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Emptyitem"));
               Combo_conbcuecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CONBCUECOD_Includeaddnewoption"));
               Combo_conbcuecod_Htmltemplate = cgiGet( "COMBO_CONBCUECOD_Htmltemplate");
               Combo_conbcuecod_Multiplevaluestype = cgiGet( "COMBO_CONBCUECOD_Multiplevaluestype");
               Combo_conbcuecod_Loadingdata = cgiGet( "COMBO_CONBCUECOD_Loadingdata");
               Combo_conbcuecod_Noresultsfound = cgiGet( "COMBO_CONBCUECOD_Noresultsfound");
               Combo_conbcuecod_Emptyitemtext = cgiGet( "COMBO_CONBCUECOD_Emptyitemtext");
               Combo_conbcuecod_Onlyselectedvalues = cgiGet( "COMBO_CONBCUECOD_Onlyselectedvalues");
               Combo_conbcuecod_Selectalltext = cgiGet( "COMBO_CONBCUECOD_Selectalltext");
               Combo_conbcuecod_Multiplevaluesseparator = cgiGet( "COMBO_CONBCUECOD_Multiplevaluesseparator");
               Combo_conbcuecod_Addnewoptiontext = cgiGet( "COMBO_CONBCUECOD_Addnewoptiontext");
               Combo_conbcuecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CONBCUECOD_Gxcontroltype"), ".", ","));
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
               A745ConBDsc = cgiGet( edtConBDsc_Internalname);
               AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
               A374ConBCueCod = cgiGet( edtConBCueCod_Internalname);
               AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
               cmbConBSts.CurrentValue = cgiGet( cmbConBSts_Internalname);
               A746ConBSts = (short)(NumberUtil.Val( cgiGet( cmbConBSts_Internalname), "."));
               AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
               AV20ComboConBCueCod = cgiGet( edtavComboconbcuecod_Internalname);
               AssignAttri("", false, "AV20ComboConBCueCod", AV20ComboConBCueCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONBCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConBCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A355ConBCod = 0;
                  AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               }
               else
               {
                  A355ConBCod = (int)(context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ","));
                  AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               }
               A744ConBCueDsc = cgiGet( edtConBCueDsc_Internalname);
               AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptoBancos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A355ConBCod != Z355ConBCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("bancos\\conceptobancos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A355ConBCod = (int)(NumberUtil.Val( GetPar( "ConBCod"), "."));
                  AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
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
                     sMode171 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode171;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound171 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONBCOD");
                        AnyError = 1;
                        GX_FocusControl = edtConBCod_Internalname;
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
                           E116C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126C2 ();
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
            E126C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6C171( ) ;
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
            DisableAttributes6C171( ) ;
         }
         AssignProp("", false, edtavComboconbcuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboconbcuecod_Enabled), 5, 0), true);
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

      protected void CONFIRM_6C0( )
      {
         BeforeValidate6C171( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6C171( ) ;
            }
            else
            {
               CheckExtendedTable6C171( ) ;
               CloseExtendedTableCursors6C171( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6C0( )
      {
      }

      protected void E116C2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtConBCueCod_Visible = 0;
         AssignProp("", false, edtConBCueCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConBCueCod_Visible), 5, 0), true);
         AV20ComboConBCueCod = "";
         AssignAttri("", false, "AV20ComboConBCueCod", AV20ComboConBCueCod);
         edtavComboconbcuecod_Visible = 0;
         AssignProp("", false, edtavComboconbcuecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboconbcuecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCONBCUECOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ConBCueCod") == 0 )
               {
                  AV13Insert_ConBCueCod = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_ConBCueCod", AV13Insert_ConBCueCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_ConBCueCod)) )
                  {
                     AV20ComboConBCueCod = AV13Insert_ConBCueCod;
                     AssignAttri("", false, "AV20ComboConBCueCod", AV20ComboConBCueCod);
                     Combo_conbcuecod_Selectedvalue_set = AV20ComboConBCueCod;
                     ucCombo_conbcuecod.SendProperty(context, "", false, Combo_conbcuecod_Internalname, "SelectedValue_set", Combo_conbcuecod_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.bancos.conceptobancosloaddvcombo(context ).execute(  "ConBCueCod",  "GET",  false,  AV7ConBCod,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_conbcuecod_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_conbcuecod.SendProperty(context, "", false, Combo_conbcuecod_Internalname, "SelectedText_set", Combo_conbcuecod_Selectedtext_set);
                     Combo_conbcuecod_Enabled = false;
                     ucCombo_conbcuecod.SendProperty(context, "", false, Combo_conbcuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_conbcuecod_Enabled));
                  }
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
         edtConBCod_Visible = 0;
         AssignProp("", false, edtConBCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConBCod_Visible), 5, 0), true);
         edtConBCueDsc_Visible = 0;
         AssignProp("", false, edtConBCueDsc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConBCueDsc_Visible), 5, 0), true);
      }

      protected void E126C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23SGAuDocGls = "Concepto N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A355ConBCod), 10, 0)) + " " + StringUtil.Trim( A745ConBDsc);
            AV24Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A355ConBCod), 10, 0));
            GXt_char2 = "TES";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV23SGAuDocGls, ref  AV24Codigo, ref  AV24Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("bancos.conceptobancosww.aspx") );
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
         /* 'LOADCOMBOCONBCUECOD' Routine */
         returnInSub = false;
         GXt_char4 = AV19Combo_DataJson;
         new GeneXus.Programs.bancos.conceptobancosloaddvcombo(context ).execute(  "ConBCueCod",  Gx_mode,  false,  AV7ConBCod,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_conbcuecod_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_conbcuecod.SendProperty(context, "", false, Combo_conbcuecod_Internalname, "SelectedValue_set", Combo_conbcuecod_Selectedvalue_set);
         Combo_conbcuecod_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_conbcuecod.SendProperty(context, "", false, Combo_conbcuecod_Internalname, "SelectedText_set", Combo_conbcuecod_Selectedtext_set);
         AV20ComboConBCueCod = AV17ComboSelectedValue;
         AssignAttri("", false, "AV20ComboConBCueCod", AV20ComboConBCueCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_conbcuecod_Enabled = false;
            ucCombo_conbcuecod.SendProperty(context, "", false, Combo_conbcuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_conbcuecod_Enabled));
         }
      }

      protected void ZM6C171( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z745ConBDsc = T006C3_A745ConBDsc[0];
               Z746ConBSts = T006C3_A746ConBSts[0];
               Z374ConBCueCod = T006C3_A374ConBCueCod[0];
            }
            else
            {
               Z745ConBDsc = A745ConBDsc;
               Z746ConBSts = A746ConBSts;
               Z374ConBCueCod = A374ConBCueCod;
            }
         }
         if ( GX_JID == -14 )
         {
            Z355ConBCod = A355ConBCod;
            Z745ConBDsc = A745ConBDsc;
            Z746ConBSts = A746ConBSts;
            Z374ConBCueCod = A374ConBCueCod;
            Z744ConBCueDsc = A744ConBCueDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV26Pgmname = "Bancos.ConceptoBancos";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ConBCod) )
         {
            A355ConBCod = AV7ConBCod;
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         }
         if ( ! (0==AV7ConBCod) )
         {
            edtConBCod_Enabled = 0;
            AssignProp("", false, edtConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCod_Enabled), 5, 0), true);
         }
         else
         {
            edtConBCod_Enabled = 1;
            AssignProp("", false, edtConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7ConBCod) )
         {
            edtConBCod_Enabled = 0;
            AssignProp("", false, edtConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_ConBCueCod)) )
         {
            edtConBCueCod_Enabled = 0;
            AssignProp("", false, edtConBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueCod_Enabled), 5, 0), true);
         }
         else
         {
            edtConBCueCod_Enabled = 1;
            AssignProp("", false, edtConBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_ConBCueCod)) )
         {
            A374ConBCueCod = AV13Insert_ConBCueCod;
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
         }
         else
         {
            A374ConBCueCod = AV20ComboConBCueCod;
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
         }
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
         if ( IsIns( )  && (0==A746ConBSts) && ( Gx_BScreen == 0 ) )
         {
            A746ConBSts = 1;
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T006C4 */
            pr_default.execute(2, new Object[] {A374ConBCueCod});
            A744ConBCueDsc = T006C4_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            pr_default.close(2);
         }
      }

      protected void Load6C171( )
      {
         /* Using cursor T006C5 */
         pr_default.execute(3, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound171 = 1;
            A745ConBDsc = T006C5_A745ConBDsc[0];
            AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
            A744ConBCueDsc = T006C5_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            A746ConBSts = T006C5_A746ConBSts[0];
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            A374ConBCueCod = T006C5_A374ConBCueCod[0];
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            ZM6C171( -14) ;
         }
         pr_default.close(3);
         OnLoadActions6C171( ) ;
      }

      protected void OnLoadActions6C171( )
      {
      }

      protected void CheckExtendedTable6C171( )
      {
         nIsDirty_171 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A745ConBDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Concepto", "", "", "", "", "", "", "", ""), 1, "CONBDSC");
            AnyError = 1;
            GX_FocusControl = edtConBDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006C4 */
         pr_default.execute(2, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A744ConBCueDsc = T006C4_A744ConBCueDsc[0];
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A374ConBCueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6C171( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( string A374ConBCueCod )
      {
         /* Using cursor T006C6 */
         pr_default.execute(4, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A744ConBCueDsc = T006C6_A744ConBCueDsc[0];
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A744ConBCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey6C171( )
      {
         /* Using cursor T006C7 */
         pr_default.execute(5, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound171 = 1;
         }
         else
         {
            RcdFound171 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006C3 */
         pr_default.execute(1, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6C171( 14) ;
            RcdFound171 = 1;
            A355ConBCod = T006C3_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            A745ConBDsc = T006C3_A745ConBDsc[0];
            AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
            A746ConBSts = T006C3_A746ConBSts[0];
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            A374ConBCueCod = T006C3_A374ConBCueCod[0];
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            Z355ConBCod = A355ConBCod;
            sMode171 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6C171( ) ;
            if ( AnyError == 1 )
            {
               RcdFound171 = 0;
               InitializeNonKey6C171( ) ;
            }
            Gx_mode = sMode171;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound171 = 0;
            InitializeNonKey6C171( ) ;
            sMode171 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode171;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6C171( ) ;
         if ( RcdFound171 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound171 = 0;
         /* Using cursor T006C8 */
         pr_default.execute(6, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T006C8_A355ConBCod[0] < A355ConBCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T006C8_A355ConBCod[0] > A355ConBCod ) ) )
            {
               A355ConBCod = T006C8_A355ConBCod[0];
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               RcdFound171 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound171 = 0;
         /* Using cursor T006C9 */
         pr_default.execute(7, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T006C9_A355ConBCod[0] > A355ConBCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T006C9_A355ConBCod[0] < A355ConBCod ) ) )
            {
               A355ConBCod = T006C9_A355ConBCod[0];
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               RcdFound171 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6C171( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConBDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6C171( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound171 == 1 )
            {
               if ( A355ConBCod != Z355ConBCod )
               {
                  A355ConBCod = Z355ConBCod;
                  AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONBCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConBCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConBDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6C171( ) ;
                  GX_FocusControl = edtConBDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A355ConBCod != Z355ConBCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtConBDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6C171( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONBCOD");
                     AnyError = 1;
                     GX_FocusControl = edtConBCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtConBDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6C171( ) ;
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
         if ( A355ConBCod != Z355ConBCod )
         {
            A355ConBCod = Z355ConBCod;
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONBCOD");
            AnyError = 1;
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConBDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6C171( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006C2 */
            pr_default.execute(0, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCONCEPTOBANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z745ConBDsc, T006C2_A745ConBDsc[0]) != 0 ) || ( Z746ConBSts != T006C2_A746ConBSts[0] ) || ( StringUtil.StrCmp(Z374ConBCueCod, T006C2_A374ConBCueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z745ConBDsc, T006C2_A745ConBDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.conceptobancos:[seudo value changed for attri]"+"ConBDsc");
                  GXUtil.WriteLogRaw("Old: ",Z745ConBDsc);
                  GXUtil.WriteLogRaw("Current: ",T006C2_A745ConBDsc[0]);
               }
               if ( Z746ConBSts != T006C2_A746ConBSts[0] )
               {
                  GXUtil.WriteLog("bancos.conceptobancos:[seudo value changed for attri]"+"ConBSts");
                  GXUtil.WriteLogRaw("Old: ",Z746ConBSts);
                  GXUtil.WriteLogRaw("Current: ",T006C2_A746ConBSts[0]);
               }
               if ( StringUtil.StrCmp(Z374ConBCueCod, T006C2_A374ConBCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.conceptobancos:[seudo value changed for attri]"+"ConBCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z374ConBCueCod);
                  GXUtil.WriteLogRaw("Current: ",T006C2_A374ConBCueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCONCEPTOBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6C171( )
      {
         BeforeValidate6C171( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6C171( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6C171( 0) ;
            CheckOptimisticConcurrency6C171( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6C171( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6C171( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006C10 */
                     pr_default.execute(8, new Object[] {A355ConBCod, A745ConBDsc, A746ConBSts, A374ConBCueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOBANCOS");
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
                           ResetCaption6C0( ) ;
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
               Load6C171( ) ;
            }
            EndLevel6C171( ) ;
         }
         CloseExtendedTableCursors6C171( ) ;
      }

      protected void Update6C171( )
      {
         BeforeValidate6C171( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6C171( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6C171( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6C171( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6C171( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006C11 */
                     pr_default.execute(9, new Object[] {A745ConBDsc, A746ConBSts, A374ConBCueCod, A355ConBCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOBANCOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCONCEPTOBANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6C171( ) ;
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
            EndLevel6C171( ) ;
         }
         CloseExtendedTableCursors6C171( ) ;
      }

      protected void DeferredUpdate6C171( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6C171( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6C171( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6C171( ) ;
            AfterConfirm6C171( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6C171( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006C12 */
                  pr_default.execute(10, new Object[] {A355ConBCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOBANCOS");
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
         sMode171 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6C171( ) ;
         Gx_mode = sMode171;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6C171( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006C13 */
            pr_default.execute(11, new Object[] {A374ConBCueCod});
            A744ConBCueDsc = T006C13_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T006C14 */
            pr_default.execute(12, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T006C15 */
            pr_default.execute(13, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T006C16 */
            pr_default.execute(14, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T006C17 */
            pr_default.execute(15, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T006C18 */
            pr_default.execute(16, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T006C19 */
            pr_default.execute(17, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006C20 */
            pr_default.execute(18, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006C21 */
            pr_default.execute(19, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel6C171( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6C171( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("bancos.conceptobancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("bancos.conceptobancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6C171( )
      {
         /* Scan By routine */
         /* Using cursor T006C22 */
         pr_default.execute(20);
         RcdFound171 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound171 = 1;
            A355ConBCod = T006C22_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6C171( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound171 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound171 = 1;
            A355ConBCod = T006C22_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         }
      }

      protected void ScanEnd6C171( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm6C171( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV22cConBCod;
            GXt_char4 = "CONBANCOS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV22cConBCod = (int)(GXt_int5);
            AssignAttri("", false, "AV22cConBCod", StringUtil.LTrimStr( (decimal)(AV22cConBCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A355ConBCod = AV22cConBCod;
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         }
      }

      protected void BeforeInsert6C171( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6C171( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6C171( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6C171( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6C171( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6C171( )
      {
         edtConBDsc_Enabled = 0;
         AssignProp("", false, edtConBDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBDsc_Enabled), 5, 0), true);
         edtConBCueCod_Enabled = 0;
         AssignProp("", false, edtConBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueCod_Enabled), 5, 0), true);
         cmbConBSts.Enabled = 0;
         AssignProp("", false, cmbConBSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConBSts.Enabled), 5, 0), true);
         edtavComboconbcuecod_Enabled = 0;
         AssignProp("", false, edtavComboconbcuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboconbcuecod_Enabled), 5, 0), true);
         edtConBCod_Enabled = 0;
         AssignProp("", false, edtConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCod_Enabled), 5, 0), true);
         edtConBCueDsc_Enabled = 0;
         AssignProp("", false, edtConBCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6C171( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810263298", false, true);
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
         GXEncryptionTmp = "bancos.conceptobancos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConBCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.conceptobancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptoBancos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("bancos\\conceptobancos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z355ConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355ConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z745ConBDsc", StringUtil.RTrim( Z745ConBDsc));
         GxWebStd.gx_hidden_field( context, "Z746ConBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z746ConBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z374ConBCueCod", StringUtil.RTrim( Z374ConBCueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N374ConBCueCod", StringUtil.RTrim( A374ConBCueCod));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONBCUECOD_DATA", AV15ConBCueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONBCUECOD_DATA", AV15ConBCueCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCONBCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConBCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCCONBCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22cConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONBCUECOD", StringUtil.RTrim( AV13Insert_ConBCueCod));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Objectcall", StringUtil.RTrim( Combo_conbcuecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Cls", StringUtil.RTrim( Combo_conbcuecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Selectedvalue_set", StringUtil.RTrim( Combo_conbcuecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Selectedtext_set", StringUtil.RTrim( Combo_conbcuecod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Enabled", StringUtil.BoolToStr( Combo_conbcuecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Datalistproc", StringUtil.RTrim( Combo_conbcuecod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_conbcuecod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CONBCUECOD_Emptyitem", StringUtil.BoolToStr( Combo_conbcuecod_Emptyitem));
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
         GXEncryptionTmp = "bancos.conceptobancos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConBCod,6,0));
         return formatLink("bancos.conceptobancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.ConceptoBancos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Bancos" ;
      }

      protected void InitializeNonKey6C171( )
      {
         A374ConBCueCod = "";
         AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
         AV22cConBCod = 0;
         AssignAttri("", false, "AV22cConBCod", StringUtil.LTrimStr( (decimal)(AV22cConBCod), 6, 0));
         A745ConBDsc = "";
         AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
         A744ConBCueDsc = "";
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         A746ConBSts = 1;
         AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         Z745ConBDsc = "";
         Z746ConBSts = 0;
         Z374ConBCueCod = "";
      }

      protected void InitAll6C171( )
      {
         A355ConBCod = 0;
         AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         InitializeNonKey6C171( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A746ConBSts = i746ConBSts;
         AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810263326", true, true);
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
         context.AddJavascriptSource("bancos/conceptobancos.js", "?202281810263326", false, true);
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
         edtConBDsc_Internalname = "CONBDSC";
         lblTextblockconbcuecod_Internalname = "TEXTBLOCKCONBCUECOD";
         Combo_conbcuecod_Internalname = "COMBO_CONBCUECOD";
         edtConBCueCod_Internalname = "CONBCUECOD";
         divTablesplittedconbcuecod_Internalname = "TABLESPLITTEDCONBCUECOD";
         cmbConBSts_Internalname = "CONBSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboconbcuecod_Internalname = "vCOMBOCONBCUECOD";
         divSectionattribute_conbcuecod_Internalname = "SECTIONATTRIBUTE_CONBCUECOD";
         edtConBCod_Internalname = "CONBCOD";
         edtConBCueDsc_Internalname = "CONBCUEDSC";
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
         Form.Caption = "Conceptos de Bancos";
         edtConBCueDsc_Jsonclick = "";
         edtConBCueDsc_Enabled = 0;
         edtConBCueDsc_Visible = 1;
         edtConBCod_Jsonclick = "";
         edtConBCod_Enabled = 1;
         edtConBCod_Visible = 1;
         edtavComboconbcuecod_Jsonclick = "";
         edtavComboconbcuecod_Enabled = 0;
         edtavComboconbcuecod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbConBSts_Jsonclick = "";
         cmbConBSts.Enabled = 1;
         edtConBCueCod_Jsonclick = "";
         edtConBCueCod_Enabled = 1;
         edtConBCueCod_Visible = 1;
         Combo_conbcuecod_Emptyitem = Convert.ToBoolean( 0);
         Combo_conbcuecod_Datalistprocparametersprefix = " \"ComboName\": \"ConBCueCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ConBCod\": 0";
         Combo_conbcuecod_Datalistproc = "Bancos.ConceptoBancosLoadDVCombo";
         Combo_conbcuecod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_conbcuecod_Caption = "";
         Combo_conbcuecod_Enabled = Convert.ToBoolean( -1);
         edtConBDsc_Jsonclick = "";
         edtConBDsc_Enabled = 1;
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

      protected void GX8ASACCONBCOD6C171( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV22cConBCod;
            GXt_char4 = "CONBANCOS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV22cConBCod = (int)(GXt_int5);
            AssignAttri("", false, "AV22cConBCod", StringUtil.LTrimStr( (decimal)(AV22cConBCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22cConBCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbConBSts.Name = "CONBSTS";
         cmbConBSts.WebTags = "";
         cmbConBSts.addItem("1", "ACTIVO", 0);
         cmbConBSts.addItem("0", "INACTIVO", 0);
         if ( cmbConBSts.ItemCount > 0 )
         {
            if ( (0==A746ConBSts) )
            {
               A746ConBSts = 1;
               AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
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

      public void Valid_Conbcuecod( )
      {
         /* Using cursor T006C13 */
         pr_default.execute(11, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
         }
         A744ConBCueDsc = T006C13_A744ConBCueDsc[0];
         pr_default.close(11);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A374ConBCueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A744ConBCueDsc", StringUtil.RTrim( A744ConBCueDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ConBCod',fld:'vCONBCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ConBCod',fld:'vCONBCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126C2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A355ConBCod',fld:'CONBCOD',pic:'ZZZZZ9'},{av:'A745ConBDsc',fld:'CONBDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CONBDSC","{handler:'Valid_Conbdsc',iparms:[]");
         setEventMetadata("VALID_CONBDSC",",oparms:[]}");
         setEventMetadata("VALID_CONBCUECOD","{handler:'Valid_Conbcuecod',iparms:[{av:'A374ConBCueCod',fld:'CONBCUECOD',pic:''},{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''}]");
         setEventMetadata("VALID_CONBCUECOD",",oparms:[{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''}]}");
         setEventMetadata("VALIDV_COMBOCONBCUECOD","{handler:'Validv_Comboconbcuecod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCONBCUECOD",",oparms:[]}");
         setEventMetadata("VALID_CONBCOD","{handler:'Valid_Conbcod',iparms:[]");
         setEventMetadata("VALID_CONBCOD",",oparms:[]}");
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
         Z745ConBDsc = "";
         Z374ConBCueCod = "";
         N374ConBCueCod = "";
         Combo_conbcuecod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A374ConBCueCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A745ConBDsc = "";
         lblTextblockconbcuecod_Jsonclick = "";
         ucCombo_conbcuecod = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15ConBCueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboConBCueCod = "";
         A744ConBCueDsc = "";
         AV13Insert_ConBCueCod = "";
         AV26Pgmname = "";
         Combo_conbcuecod_Objectcall = "";
         Combo_conbcuecod_Class = "";
         Combo_conbcuecod_Icontype = "";
         Combo_conbcuecod_Icon = "";
         Combo_conbcuecod_Tooltip = "";
         Combo_conbcuecod_Selectedvalue_set = "";
         Combo_conbcuecod_Selectedtext_set = "";
         Combo_conbcuecod_Selectedtext_get = "";
         Combo_conbcuecod_Gamoauthtoken = "";
         Combo_conbcuecod_Ddointernalname = "";
         Combo_conbcuecod_Titlecontrolalign = "";
         Combo_conbcuecod_Dropdownoptionstype = "";
         Combo_conbcuecod_Titlecontrolidtoreplace = "";
         Combo_conbcuecod_Datalisttype = "";
         Combo_conbcuecod_Datalistfixedvalues = "";
         Combo_conbcuecod_Htmltemplate = "";
         Combo_conbcuecod_Multiplevaluestype = "";
         Combo_conbcuecod_Loadingdata = "";
         Combo_conbcuecod_Noresultsfound = "";
         Combo_conbcuecod_Emptyitemtext = "";
         Combo_conbcuecod_Onlyselectedvalues = "";
         Combo_conbcuecod_Selectalltext = "";
         Combo_conbcuecod_Multiplevaluesseparator = "";
         Combo_conbcuecod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode171 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         AV23SGAuDocGls = "";
         AV24Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         Z744ConBCueDsc = "";
         T006C4_A744ConBCueDsc = new string[] {""} ;
         T006C5_A355ConBCod = new int[1] ;
         T006C5_A745ConBDsc = new string[] {""} ;
         T006C5_A744ConBCueDsc = new string[] {""} ;
         T006C5_A746ConBSts = new short[1] ;
         T006C5_A374ConBCueCod = new string[] {""} ;
         T006C6_A744ConBCueDsc = new string[] {""} ;
         T006C7_A355ConBCod = new int[1] ;
         T006C3_A355ConBCod = new int[1] ;
         T006C3_A745ConBDsc = new string[] {""} ;
         T006C3_A746ConBSts = new short[1] ;
         T006C3_A374ConBCueCod = new string[] {""} ;
         T006C8_A355ConBCod = new int[1] ;
         T006C9_A355ConBCod = new int[1] ;
         T006C2_A355ConBCod = new int[1] ;
         T006C2_A745ConBDsc = new string[] {""} ;
         T006C2_A746ConBSts = new short[1] ;
         T006C2_A374ConBCueCod = new string[] {""} ;
         T006C13_A744ConBCueDsc = new string[] {""} ;
         T006C14_A379LBBanCod = new int[1] ;
         T006C14_A380LBCBCod = new string[] {""} ;
         T006C14_A381LBRegistro = new string[] {""} ;
         T006C14_A383LBDITem = new int[1] ;
         T006C15_A365EntCod = new int[1] ;
         T006C15_A366AperEntCod = new string[] {""} ;
         T006C16_A358CajCod = new int[1] ;
         T006C16_A359AperCajCod = new string[] {""} ;
         T006C17_A354TSAntCod = new string[] {""} ;
         T006C18_A348UsuCod = new string[] {""} ;
         T006C19_A270LiqCod = new string[] {""} ;
         T006C19_A236LiqPrvCod = new string[] {""} ;
         T006C19_A277LiqMItem = new int[1] ;
         T006C20_A270LiqCod = new string[] {""} ;
         T006C20_A236LiqPrvCod = new string[] {""} ;
         T006C20_A271LiqCodItem = new int[1] ;
         T006C21_A166CobTip = new string[] {""} ;
         T006C21_A167CobCod = new string[] {""} ;
         T006C22_A355ConBCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char4 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptobancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptobancos__default(),
            new Object[][] {
                new Object[] {
               T006C2_A355ConBCod, T006C2_A745ConBDsc, T006C2_A746ConBSts, T006C2_A374ConBCueCod
               }
               , new Object[] {
               T006C3_A355ConBCod, T006C3_A745ConBDsc, T006C3_A746ConBSts, T006C3_A374ConBCueCod
               }
               , new Object[] {
               T006C4_A744ConBCueDsc
               }
               , new Object[] {
               T006C5_A355ConBCod, T006C5_A745ConBDsc, T006C5_A744ConBCueDsc, T006C5_A746ConBSts, T006C5_A374ConBCueCod
               }
               , new Object[] {
               T006C6_A744ConBCueDsc
               }
               , new Object[] {
               T006C7_A355ConBCod
               }
               , new Object[] {
               T006C8_A355ConBCod
               }
               , new Object[] {
               T006C9_A355ConBCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006C13_A744ConBCueDsc
               }
               , new Object[] {
               T006C14_A379LBBanCod, T006C14_A380LBCBCod, T006C14_A381LBRegistro, T006C14_A383LBDITem
               }
               , new Object[] {
               T006C15_A365EntCod, T006C15_A366AperEntCod
               }
               , new Object[] {
               T006C16_A358CajCod, T006C16_A359AperCajCod
               }
               , new Object[] {
               T006C17_A354TSAntCod
               }
               , new Object[] {
               T006C18_A348UsuCod
               }
               , new Object[] {
               T006C19_A270LiqCod, T006C19_A236LiqPrvCod, T006C19_A277LiqMItem
               }
               , new Object[] {
               T006C20_A270LiqCod, T006C20_A236LiqPrvCod, T006C20_A271LiqCodItem
               }
               , new Object[] {
               T006C21_A166CobTip, T006C21_A167CobCod
               }
               , new Object[] {
               T006C22_A355ConBCod
               }
            }
         );
         AV26Pgmname = "Bancos.ConceptoBancos";
         Z746ConBSts = 1;
         A746ConBSts = 1;
         i746ConBSts = 1;
      }

      private short Z746ConBSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A746ConBSts ;
      private short Gx_BScreen ;
      private short RcdFound171 ;
      private short GX_JID ;
      private short nIsDirty_171 ;
      private short gxajaxcallmode ;
      private short i746ConBSts ;
      private int wcpOAV7ConBCod ;
      private int Z355ConBCod ;
      private int AV7ConBCod ;
      private int trnEnded ;
      private int edtConBDsc_Enabled ;
      private int edtConBCueCod_Visible ;
      private int edtConBCueCod_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboconbcuecod_Visible ;
      private int edtavComboconbcuecod_Enabled ;
      private int A355ConBCod ;
      private int edtConBCod_Visible ;
      private int edtConBCod_Enabled ;
      private int edtConBCueDsc_Visible ;
      private int edtConBCueDsc_Enabled ;
      private int AV22cConBCod ;
      private int Combo_conbcuecod_Datalistupdateminimumcharacters ;
      private int Combo_conbcuecod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV27GXV1 ;
      private int idxLst ;
      private long GXt_int5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z745ConBDsc ;
      private string Z374ConBCueCod ;
      private string N374ConBCueCod ;
      private string Combo_conbcuecod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A374ConBCueCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConBDsc_Internalname ;
      private string cmbConBSts_Internalname ;
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
      private string TempTags ;
      private string A745ConBDsc ;
      private string edtConBDsc_Jsonclick ;
      private string divTablesplittedconbcuecod_Internalname ;
      private string lblTextblockconbcuecod_Internalname ;
      private string lblTextblockconbcuecod_Jsonclick ;
      private string Combo_conbcuecod_Caption ;
      private string Combo_conbcuecod_Cls ;
      private string Combo_conbcuecod_Datalistproc ;
      private string Combo_conbcuecod_Datalistprocparametersprefix ;
      private string Combo_conbcuecod_Internalname ;
      private string edtConBCueCod_Internalname ;
      private string edtConBCueCod_Jsonclick ;
      private string cmbConBSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_conbcuecod_Internalname ;
      private string edtavComboconbcuecod_Internalname ;
      private string AV20ComboConBCueCod ;
      private string edtavComboconbcuecod_Jsonclick ;
      private string edtConBCod_Internalname ;
      private string edtConBCod_Jsonclick ;
      private string edtConBCueDsc_Internalname ;
      private string A744ConBCueDsc ;
      private string edtConBCueDsc_Jsonclick ;
      private string AV13Insert_ConBCueCod ;
      private string AV26Pgmname ;
      private string Combo_conbcuecod_Objectcall ;
      private string Combo_conbcuecod_Class ;
      private string Combo_conbcuecod_Icontype ;
      private string Combo_conbcuecod_Icon ;
      private string Combo_conbcuecod_Tooltip ;
      private string Combo_conbcuecod_Selectedvalue_set ;
      private string Combo_conbcuecod_Selectedtext_set ;
      private string Combo_conbcuecod_Selectedtext_get ;
      private string Combo_conbcuecod_Gamoauthtoken ;
      private string Combo_conbcuecod_Ddointernalname ;
      private string Combo_conbcuecod_Titlecontrolalign ;
      private string Combo_conbcuecod_Dropdownoptionstype ;
      private string Combo_conbcuecod_Titlecontrolidtoreplace ;
      private string Combo_conbcuecod_Datalisttype ;
      private string Combo_conbcuecod_Datalistfixedvalues ;
      private string Combo_conbcuecod_Htmltemplate ;
      private string Combo_conbcuecod_Multiplevaluestype ;
      private string Combo_conbcuecod_Loadingdata ;
      private string Combo_conbcuecod_Noresultsfound ;
      private string Combo_conbcuecod_Emptyitemtext ;
      private string Combo_conbcuecod_Onlyselectedvalues ;
      private string Combo_conbcuecod_Selectalltext ;
      private string Combo_conbcuecod_Multiplevaluesseparator ;
      private string Combo_conbcuecod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode171 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string Z744ConBCueDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char4 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_conbcuecod_Emptyitem ;
      private bool Combo_conbcuecod_Enabled ;
      private bool Combo_conbcuecod_Visible ;
      private bool Combo_conbcuecod_Allowmultipleselection ;
      private bool Combo_conbcuecod_Isgriditem ;
      private bool Combo_conbcuecod_Hasdescription ;
      private bool Combo_conbcuecod_Includeonlyselectedoption ;
      private bool Combo_conbcuecod_Includeselectalloption ;
      private bool Combo_conbcuecod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string AV23SGAuDocGls ;
      private string AV24Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_conbcuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConBSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006C4_A744ConBCueDsc ;
      private int[] T006C5_A355ConBCod ;
      private string[] T006C5_A745ConBDsc ;
      private string[] T006C5_A744ConBCueDsc ;
      private short[] T006C5_A746ConBSts ;
      private string[] T006C5_A374ConBCueCod ;
      private string[] T006C6_A744ConBCueDsc ;
      private int[] T006C7_A355ConBCod ;
      private int[] T006C3_A355ConBCod ;
      private string[] T006C3_A745ConBDsc ;
      private short[] T006C3_A746ConBSts ;
      private string[] T006C3_A374ConBCueCod ;
      private int[] T006C8_A355ConBCod ;
      private int[] T006C9_A355ConBCod ;
      private int[] T006C2_A355ConBCod ;
      private string[] T006C2_A745ConBDsc ;
      private short[] T006C2_A746ConBSts ;
      private string[] T006C2_A374ConBCueCod ;
      private string[] T006C13_A744ConBCueDsc ;
      private int[] T006C14_A379LBBanCod ;
      private string[] T006C14_A380LBCBCod ;
      private string[] T006C14_A381LBRegistro ;
      private int[] T006C14_A383LBDITem ;
      private int[] T006C15_A365EntCod ;
      private string[] T006C15_A366AperEntCod ;
      private int[] T006C16_A358CajCod ;
      private string[] T006C16_A359AperCajCod ;
      private string[] T006C17_A354TSAntCod ;
      private string[] T006C18_A348UsuCod ;
      private string[] T006C19_A270LiqCod ;
      private string[] T006C19_A236LiqPrvCod ;
      private int[] T006C19_A277LiqMItem ;
      private string[] T006C20_A270LiqCod ;
      private string[] T006C20_A236LiqPrvCod ;
      private int[] T006C20_A271LiqCodItem ;
      private string[] T006C21_A166CobTip ;
      private string[] T006C21_A167CobCod ;
      private int[] T006C22_A355ConBCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15ConBCueCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class conceptobancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class conceptobancos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006C5;
        prmT006C5 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C4;
        prmT006C4 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006C6;
        prmT006C6 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006C7;
        prmT006C7 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C3;
        prmT006C3 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C8;
        prmT006C8 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C9;
        prmT006C9 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C2;
        prmT006C2 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C10;
        prmT006C10 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0) ,
        new ParDef("@ConBDsc",GXType.NChar,100,0) ,
        new ParDef("@ConBSts",GXType.Int16,1,0) ,
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006C11;
        prmT006C11 = new Object[] {
        new ParDef("@ConBDsc",GXType.NChar,100,0) ,
        new ParDef("@ConBSts",GXType.Int16,1,0) ,
        new ParDef("@ConBCueCod",GXType.NChar,15,0) ,
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C12;
        prmT006C12 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C14;
        prmT006C14 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C15;
        prmT006C15 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C16;
        prmT006C16 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C17;
        prmT006C17 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C18;
        prmT006C18 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C19;
        prmT006C19 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C20;
        prmT006C20 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C21;
        prmT006C21 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT006C22;
        prmT006C22 = new Object[] {
        };
        Object[] prmT006C13;
        prmT006C13 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006C2", "SELECT [ConBCod], [ConBDsc], [ConBSts], [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WITH (UPDLOCK) WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C3", "SELECT [ConBCod], [ConBDsc], [ConBSts], [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C4", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C5", "SELECT TM1.[ConBCod], TM1.[ConBDsc], T2.[CueDsc] AS ConBCueDsc, TM1.[ConBSts], TM1.[ConBCueCod] AS ConBCueCod FROM ([TSCONCEPTOBANCOS] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[ConBCueCod]) WHERE TM1.[ConBCod] = @ConBCod ORDER BY TM1.[ConBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C6", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C7", "SELECT [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C8", "SELECT TOP 1 [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE ( [ConBCod] > @ConBCod) ORDER BY [ConBCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006C8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C9", "SELECT TOP 1 [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE ( [ConBCod] < @ConBCod) ORDER BY [ConBCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C10", "INSERT INTO [TSCONCEPTOBANCOS]([ConBCod], [ConBDsc], [ConBSts], [ConBCueCod]) VALUES(@ConBCod, @ConBDsc, @ConBSts, @ConBCueCod)", GxErrorMask.GX_NOMASK,prmT006C10)
           ,new CursorDef("T006C11", "UPDATE [TSCONCEPTOBANCOS] SET [ConBDsc]=@ConBDsc, [ConBSts]=@ConBSts, [ConBCueCod]=@ConBCueCod  WHERE [ConBCod] = @ConBCod", GxErrorMask.GX_NOMASK,prmT006C11)
           ,new CursorDef("T006C12", "DELETE FROM [TSCONCEPTOBANCOS]  WHERE [ConBCod] = @ConBCod", GxErrorMask.GX_NOMASK,prmT006C12)
           ,new CursorDef("T006C13", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006C14", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBConBan] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C15", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperETmov] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C16", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperTmov] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C17", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C18", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuMosConcepto] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C19", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE [LiqMTMovCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C20", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqTMovCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C21", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006C21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006C22", "SELECT [ConBCod] FROM [TSCONCEPTOBANCOS] ORDER BY [ConBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006C22,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
