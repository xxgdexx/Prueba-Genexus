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
   public class conceptocompras : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vCCCONPCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASACCCONPCOD6P57( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A77CConpCueCod = GetPar( "CConpCueCod");
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A77CConpCueCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.conceptocompras.aspx")), "contabilidad.conceptocompras.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.conceptocompras.aspx")))) ;
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
                  AV7CConpCod = (int)(NumberUtil.Val( GetPar( "CConpCod"), "."));
                  AssignAttri("", false, "AV7CConpCod", StringUtil.LTrimStr( (decimal)(AV7CConpCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCCONPCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CConpCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Conceptos de Compras", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public conceptocompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptocompras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CConpCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CConpCod = aP1_CConpCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCConpSts = new GXCombobox();
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
         if ( cmbCConpSts.ItemCount > 0 )
         {
            A517CConpSts = (short)(NumberUtil.Val( cmbCConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0))), "."));
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
            AssignProp("", false, cmbCConpSts_Internalname, "Values", cmbCConpSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCConpDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCConpDsc_Internalname, "Concepto", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCConpDsc_Internalname, StringUtil.RTrim( A78CConpDsc), StringUtil.RTrim( context.localUtil.Format( A78CConpDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtCConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\ConceptoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcconpcuecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcconpcuecod_Internalname, "Cuenta Contable", "", "", lblTextblockcconpcuecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\ConceptoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cconpcuecod.SetProperty("Caption", Combo_cconpcuecod_Caption);
         ucCombo_cconpcuecod.SetProperty("Cls", Combo_cconpcuecod_Cls);
         ucCombo_cconpcuecod.SetProperty("DropDownOptionsData", AV13CConpCueCod_Data);
         ucCombo_cconpcuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cconpcuecod_Internalname, "COMBO_CCONPCUECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCConpCueCod_Internalname, "Cuenta Contable", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCConpCueCod_Internalname, StringUtil.RTrim( A77CConpCueCod), StringUtil.RTrim( context.localUtil.Format( A77CConpCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpCueCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCConpCueCod_Visible, edtCConpCueCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\ConceptoCompras.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCConpSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCConpSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCConpSts, cmbCConpSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0)), 1, cmbCConpSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCConpSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 1, "HLP_Contabilidad\\ConceptoCompras.htm");
         cmbCConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         AssignProp("", false, cmbCConpSts_Internalname, "Values", (string)(cmbCConpSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\ConceptoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\ConceptoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\ConceptoCompras.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_cconpcuecod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocconpcuecod_Internalname, StringUtil.RTrim( AV18ComboCConpCueCod), StringUtil.RTrim( context.localUtil.Format( AV18ComboCConpCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocconpcuecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocconpcuecod_Visible, edtavCombocconpcuecod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\ConceptoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76CConpCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A76CConpCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCConpCod_Visible, edtCConpCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\ConceptoCompras.htm");
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
         E116P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vCCONPCUECOD_DATA"), AV13CConpCueCod_Data);
               /* Read saved values. */
               Z76CConpCod = (int)(context.localUtil.CToN( cgiGet( "Z76CConpCod"), ".", ","));
               Z78CConpDsc = cgiGet( "Z78CConpDsc");
               Z517CConpSts = (short)(context.localUtil.CToN( cgiGet( "Z517CConpSts"), ".", ","));
               Z77CConpCueCod = cgiGet( "Z77CConpCueCod");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N77CConpCueCod = cgiGet( "N77CConpCueCod");
               AV7CConpCod = (int)(context.localUtil.CToN( cgiGet( "vCCONPCOD"), ".", ","));
               AV20cCConpCod = (int)(context.localUtil.CToN( cgiGet( "vCCCONPCOD"), ".", ","));
               AV11Insert_CConpCueCod = cgiGet( "vINSERT_CCONPCUECOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A516CConpCueDsc = cgiGet( "CCONPCUEDSC");
               AV24Pgmname = cgiGet( "vPGMNAME");
               Combo_cconpcuecod_Objectcall = cgiGet( "COMBO_CCONPCUECOD_Objectcall");
               Combo_cconpcuecod_Class = cgiGet( "COMBO_CCONPCUECOD_Class");
               Combo_cconpcuecod_Icontype = cgiGet( "COMBO_CCONPCUECOD_Icontype");
               Combo_cconpcuecod_Icon = cgiGet( "COMBO_CCONPCUECOD_Icon");
               Combo_cconpcuecod_Caption = cgiGet( "COMBO_CCONPCUECOD_Caption");
               Combo_cconpcuecod_Tooltip = cgiGet( "COMBO_CCONPCUECOD_Tooltip");
               Combo_cconpcuecod_Cls = cgiGet( "COMBO_CCONPCUECOD_Cls");
               Combo_cconpcuecod_Selectedvalue_set = cgiGet( "COMBO_CCONPCUECOD_Selectedvalue_set");
               Combo_cconpcuecod_Selectedvalue_get = cgiGet( "COMBO_CCONPCUECOD_Selectedvalue_get");
               Combo_cconpcuecod_Selectedtext_set = cgiGet( "COMBO_CCONPCUECOD_Selectedtext_set");
               Combo_cconpcuecod_Selectedtext_get = cgiGet( "COMBO_CCONPCUECOD_Selectedtext_get");
               Combo_cconpcuecod_Gamoauthtoken = cgiGet( "COMBO_CCONPCUECOD_Gamoauthtoken");
               Combo_cconpcuecod_Ddointernalname = cgiGet( "COMBO_CCONPCUECOD_Ddointernalname");
               Combo_cconpcuecod_Titlecontrolalign = cgiGet( "COMBO_CCONPCUECOD_Titlecontrolalign");
               Combo_cconpcuecod_Dropdownoptionstype = cgiGet( "COMBO_CCONPCUECOD_Dropdownoptionstype");
               Combo_cconpcuecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Enabled"));
               Combo_cconpcuecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Visible"));
               Combo_cconpcuecod_Titlecontrolidtoreplace = cgiGet( "COMBO_CCONPCUECOD_Titlecontrolidtoreplace");
               Combo_cconpcuecod_Datalisttype = cgiGet( "COMBO_CCONPCUECOD_Datalisttype");
               Combo_cconpcuecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Allowmultipleselection"));
               Combo_cconpcuecod_Datalistfixedvalues = cgiGet( "COMBO_CCONPCUECOD_Datalistfixedvalues");
               Combo_cconpcuecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Isgriditem"));
               Combo_cconpcuecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Hasdescription"));
               Combo_cconpcuecod_Datalistproc = cgiGet( "COMBO_CCONPCUECOD_Datalistproc");
               Combo_cconpcuecod_Datalistprocparametersprefix = cgiGet( "COMBO_CCONPCUECOD_Datalistprocparametersprefix");
               Combo_cconpcuecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CCONPCUECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cconpcuecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Includeonlyselectedoption"));
               Combo_cconpcuecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Includeselectalloption"));
               Combo_cconpcuecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Emptyitem"));
               Combo_cconpcuecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CCONPCUECOD_Includeaddnewoption"));
               Combo_cconpcuecod_Htmltemplate = cgiGet( "COMBO_CCONPCUECOD_Htmltemplate");
               Combo_cconpcuecod_Multiplevaluestype = cgiGet( "COMBO_CCONPCUECOD_Multiplevaluestype");
               Combo_cconpcuecod_Loadingdata = cgiGet( "COMBO_CCONPCUECOD_Loadingdata");
               Combo_cconpcuecod_Noresultsfound = cgiGet( "COMBO_CCONPCUECOD_Noresultsfound");
               Combo_cconpcuecod_Emptyitemtext = cgiGet( "COMBO_CCONPCUECOD_Emptyitemtext");
               Combo_cconpcuecod_Onlyselectedvalues = cgiGet( "COMBO_CCONPCUECOD_Onlyselectedvalues");
               Combo_cconpcuecod_Selectalltext = cgiGet( "COMBO_CCONPCUECOD_Selectalltext");
               Combo_cconpcuecod_Multiplevaluesseparator = cgiGet( "COMBO_CCONPCUECOD_Multiplevaluesseparator");
               Combo_cconpcuecod_Addnewoptiontext = cgiGet( "COMBO_CCONPCUECOD_Addnewoptiontext");
               Combo_cconpcuecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CCONPCUECOD_Gxcontroltype"), ".", ","));
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
               A78CConpDsc = cgiGet( edtCConpDsc_Internalname);
               AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
               A77CConpCueCod = cgiGet( edtCConpCueCod_Internalname);
               AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
               cmbCConpSts.CurrentValue = cgiGet( cmbCConpSts_Internalname);
               A517CConpSts = (short)(NumberUtil.Val( cgiGet( cmbCConpSts_Internalname), "."));
               AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
               AV18ComboCConpCueCod = cgiGet( edtavCombocconpcuecod_Internalname);
               AssignAttri("", false, "AV18ComboCConpCueCod", AV18ComboCConpCueCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CCONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCConpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A76CConpCod = 0;
                  AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               }
               else
               {
                  A76CConpCod = (int)(context.localUtil.CToN( cgiGet( edtCConpCod_Internalname), ".", ","));
                  AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptoCompras");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A76CConpCod != Z76CConpCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\conceptocompras:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A76CConpCod = (int)(NumberUtil.Val( GetPar( "CConpCod"), "."));
                  AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
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
                     sMode57 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode57;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound57 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CCONPCOD");
                        AnyError = 1;
                        GX_FocusControl = edtCConpCod_Internalname;
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
                           E116P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126P2 ();
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
            E126P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6P57( ) ;
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
            DisableAttributes6P57( ) ;
         }
         AssignProp("", false, edtavCombocconpcuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocconpcuecod_Enabled), 5, 0), true);
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

      protected void CONFIRM_6P0( )
      {
         BeforeValidate6P57( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6P57( ) ;
            }
            else
            {
               CheckExtendedTable6P57( ) ;
               CloseExtendedTableCursors6P57( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6P0( )
      {
      }

      protected void E116P2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtCConpCueCod_Visible = 0;
         AssignProp("", false, edtCConpCueCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCConpCueCod_Visible), 5, 0), true);
         AV18ComboCConpCueCod = "";
         AssignAttri("", false, "AV18ComboCConpCueCod", AV18ComboCConpCueCod);
         edtavCombocconpcuecod_Visible = 0;
         AssignProp("", false, edtavCombocconpcuecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocconpcuecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCCONPCUECOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CConpCueCod") == 0 )
               {
                  AV11Insert_CConpCueCod = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_CConpCueCod", AV11Insert_CConpCueCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CConpCueCod)) )
                  {
                     AV18ComboCConpCueCod = AV11Insert_CConpCueCod;
                     AssignAttri("", false, "AV18ComboCConpCueCod", AV18ComboCConpCueCod);
                     Combo_cconpcuecod_Selectedvalue_set = AV18ComboCConpCueCod;
                     ucCombo_cconpcuecod.SendProperty(context, "", false, Combo_cconpcuecod_Internalname, "SelectedValue_set", Combo_cconpcuecod_Selectedvalue_set);
                     Combo_cconpcuecod_Enabled = false;
                     ucCombo_cconpcuecod.SendProperty(context, "", false, Combo_cconpcuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cconpcuecod_Enabled));
                  }
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtCConpCod_Visible = 0;
         AssignProp("", false, edtCConpCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCConpCod_Visible), 5, 0), true);
      }

      protected void E126P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV21SGAuDocGls = "Conceptos de Compra N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A76CConpCod), 10, 0)) + " " + StringUtil.Trim( A78CConpDsc);
            AV22Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A76CConpCod), 10, 0));
            GXt_char1 = "CON";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV21SGAuDocGls, ref  AV22Codigo, ref  AV22Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.conceptocomprasww.aspx") );
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
         /* 'LOADCOMBOCCONPCUECOD' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV13CConpCueCod_Data;
         new GeneXus.Programs.contabilidad.conceptocomprasloaddvcombo(context ).execute(  "CConpCueCod",  Gx_mode,  AV7CConpCod, out  AV15ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV13CConpCueCod_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_cconpcuecod_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_cconpcuecod.SendProperty(context, "", false, Combo_cconpcuecod_Internalname, "SelectedValue_set", Combo_cconpcuecod_Selectedvalue_set);
         AV18ComboCConpCueCod = AV15ComboSelectedValue;
         AssignAttri("", false, "AV18ComboCConpCueCod", AV18ComboCConpCueCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cconpcuecod_Enabled = false;
            ucCombo_cconpcuecod.SendProperty(context, "", false, Combo_cconpcuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cconpcuecod_Enabled));
         }
      }

      protected void ZM6P57( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z78CConpDsc = T006P3_A78CConpDsc[0];
               Z517CConpSts = T006P3_A517CConpSts[0];
               Z77CConpCueCod = T006P3_A77CConpCueCod[0];
            }
            else
            {
               Z78CConpDsc = A78CConpDsc;
               Z517CConpSts = A517CConpSts;
               Z77CConpCueCod = A77CConpCueCod;
            }
         }
         if ( GX_JID == -14 )
         {
            Z76CConpCod = A76CConpCod;
            Z78CConpDsc = A78CConpDsc;
            Z517CConpSts = A517CConpSts;
            Z77CConpCueCod = A77CConpCueCod;
            Z516CConpCueDsc = A516CConpCueDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "Contabilidad.ConceptoCompras";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CConpCod) )
         {
            A76CConpCod = AV7CConpCod;
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         }
         if ( ! (0==AV7CConpCod) )
         {
            edtCConpCod_Enabled = 0;
            AssignProp("", false, edtCConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCConpCod_Enabled = 1;
            AssignProp("", false, edtCConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CConpCod) )
         {
            edtCConpCod_Enabled = 0;
            AssignProp("", false, edtCConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CConpCueCod)) )
         {
            edtCConpCueCod_Enabled = 0;
            AssignProp("", false, edtCConpCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCueCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCConpCueCod_Enabled = 1;
            AssignProp("", false, edtCConpCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCueCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CConpCueCod)) )
         {
            A77CConpCueCod = AV11Insert_CConpCueCod;
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
         }
         else
         {
            A77CConpCueCod = AV18ComboCConpCueCod;
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
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
         if ( IsIns( )  && (0==A517CConpSts) && ( Gx_BScreen == 0 ) )
         {
            A517CConpSts = 1;
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T006P4 */
            pr_default.execute(2, new Object[] {A77CConpCueCod});
            A516CConpCueDsc = T006P4_A516CConpCueDsc[0];
            pr_default.close(2);
         }
      }

      protected void Load6P57( )
      {
         /* Using cursor T006P5 */
         pr_default.execute(3, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound57 = 1;
            A78CConpDsc = T006P5_A78CConpDsc[0];
            AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
            A516CConpCueDsc = T006P5_A516CConpCueDsc[0];
            A517CConpSts = T006P5_A517CConpSts[0];
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
            A77CConpCueCod = T006P5_A77CConpCueCod[0];
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            ZM6P57( -14) ;
         }
         pr_default.close(3);
         OnLoadActions6P57( ) ;
      }

      protected void OnLoadActions6P57( )
      {
      }

      protected void CheckExtendedTable6P57( )
      {
         nIsDirty_57 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A78CConpDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Concepto", "", "", "", "", "", "", "", ""), 1, "CCONPDSC");
            AnyError = 1;
            GX_FocusControl = edtCConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006P4 */
         pr_default.execute(2, new Object[] {A77CConpCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A516CConpCueDsc = T006P4_A516CConpCueDsc[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A77CConpCueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta Contable", "", "", "", "", "", "", "", ""), 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6P57( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( string A77CConpCueCod )
      {
         /* Using cursor T006P6 */
         pr_default.execute(4, new Object[] {A77CConpCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A516CConpCueDsc = T006P6_A516CConpCueDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A516CConpCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey6P57( )
      {
         /* Using cursor T006P7 */
         pr_default.execute(5, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound57 = 1;
         }
         else
         {
            RcdFound57 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006P3 */
         pr_default.execute(1, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6P57( 14) ;
            RcdFound57 = 1;
            A76CConpCod = T006P3_A76CConpCod[0];
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
            A78CConpDsc = T006P3_A78CConpDsc[0];
            AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
            A517CConpSts = T006P3_A517CConpSts[0];
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
            A77CConpCueCod = T006P3_A77CConpCueCod[0];
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            Z76CConpCod = A76CConpCod;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6P57( ) ;
            if ( AnyError == 1 )
            {
               RcdFound57 = 0;
               InitializeNonKey6P57( ) ;
            }
            Gx_mode = sMode57;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound57 = 0;
            InitializeNonKey6P57( ) ;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode57;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6P57( ) ;
         if ( RcdFound57 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound57 = 0;
         /* Using cursor T006P8 */
         pr_default.execute(6, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T006P8_A76CConpCod[0] < A76CConpCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T006P8_A76CConpCod[0] > A76CConpCod ) ) )
            {
               A76CConpCod = T006P8_A76CConpCod[0];
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               RcdFound57 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound57 = 0;
         /* Using cursor T006P9 */
         pr_default.execute(7, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T006P9_A76CConpCod[0] > A76CConpCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T006P9_A76CConpCod[0] < A76CConpCod ) ) )
            {
               A76CConpCod = T006P9_A76CConpCod[0];
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               RcdFound57 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6P57( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6P57( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound57 == 1 )
            {
               if ( A76CConpCod != Z76CConpCod )
               {
                  A76CConpCod = Z76CConpCod;
                  AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CCONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCConpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCConpDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6P57( ) ;
                  GX_FocusControl = edtCConpDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A76CConpCod != Z76CConpCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtCConpDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6P57( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CCONPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCConpCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCConpDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6P57( ) ;
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
         if ( A76CConpCod != Z76CConpCod )
         {
            A76CConpCod = Z76CConpCod;
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6P57( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006P2 */
            pr_default.execute(0, new Object[] {A76CConpCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOMPRASCONC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z78CConpDsc, T006P2_A78CConpDsc[0]) != 0 ) || ( Z517CConpSts != T006P2_A517CConpSts[0] ) || ( StringUtil.StrCmp(Z77CConpCueCod, T006P2_A77CConpCueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z78CConpDsc, T006P2_A78CConpDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.conceptocompras:[seudo value changed for attri]"+"CConpDsc");
                  GXUtil.WriteLogRaw("Old: ",Z78CConpDsc);
                  GXUtil.WriteLogRaw("Current: ",T006P2_A78CConpDsc[0]);
               }
               if ( Z517CConpSts != T006P2_A517CConpSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.conceptocompras:[seudo value changed for attri]"+"CConpSts");
                  GXUtil.WriteLogRaw("Old: ",Z517CConpSts);
                  GXUtil.WriteLogRaw("Current: ",T006P2_A517CConpSts[0]);
               }
               if ( StringUtil.StrCmp(Z77CConpCueCod, T006P2_A77CConpCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.conceptocompras:[seudo value changed for attri]"+"CConpCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z77CConpCueCod);
                  GXUtil.WriteLogRaw("Current: ",T006P2_A77CConpCueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBCOMPRASCONC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6P57( )
      {
         BeforeValidate6P57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6P57( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6P57( 0) ;
            CheckOptimisticConcurrency6P57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6P57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6P57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006P10 */
                     pr_default.execute(8, new Object[] {A76CConpCod, A78CConpDsc, A517CConpSts, A77CConpCueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOMPRASCONC");
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
                           ResetCaption6P0( ) ;
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
               Load6P57( ) ;
            }
            EndLevel6P57( ) ;
         }
         CloseExtendedTableCursors6P57( ) ;
      }

      protected void Update6P57( )
      {
         BeforeValidate6P57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6P57( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6P57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6P57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6P57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006P11 */
                     pr_default.execute(9, new Object[] {A78CConpDsc, A517CConpSts, A77CConpCueCod, A76CConpCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOMPRASCONC");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOMPRASCONC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6P57( ) ;
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
            EndLevel6P57( ) ;
         }
         CloseExtendedTableCursors6P57( ) ;
      }

      protected void DeferredUpdate6P57( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6P57( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6P57( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6P57( ) ;
            AfterConfirm6P57( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6P57( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006P12 */
                  pr_default.execute(10, new Object[] {A76CConpCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBCOMPRASCONC");
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
         sMode57 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6P57( ) ;
         Gx_mode = sMode57;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6P57( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006P13 */
            pr_default.execute(11, new Object[] {A77CConpCueCod});
            A516CConpCueDsc = T006P13_A516CConpCueDsc[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel6P57( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6P57( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("contabilidad.conceptocompras",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("contabilidad.conceptocompras",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6P57( )
      {
         /* Scan By routine */
         /* Using cursor T006P14 */
         pr_default.execute(12);
         RcdFound57 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound57 = 1;
            A76CConpCod = T006P14_A76CConpCod[0];
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6P57( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound57 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound57 = 1;
            A76CConpCod = T006P14_A76CConpCod[0];
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         }
      }

      protected void ScanEnd6P57( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm6P57( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV20cCConpCod;
            GXt_char3 = "CONCCOMPRA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int5) ;
            AV20cCConpCod = (int)(GXt_int5);
            AssignAttri("", false, "AV20cCConpCod", StringUtil.LTrimStr( (decimal)(AV20cCConpCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A76CConpCod = AV20cCConpCod;
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         }
      }

      protected void BeforeInsert6P57( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6P57( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6P57( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6P57( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6P57( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6P57( )
      {
         edtCConpDsc_Enabled = 0;
         AssignProp("", false, edtCConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpDsc_Enabled), 5, 0), true);
         edtCConpCueCod_Enabled = 0;
         AssignProp("", false, edtCConpCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCueCod_Enabled), 5, 0), true);
         cmbCConpSts.Enabled = 0;
         AssignProp("", false, cmbCConpSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCConpSts.Enabled), 5, 0), true);
         edtavCombocconpcuecod_Enabled = 0;
         AssignProp("", false, edtavCombocconpcuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocconpcuecod_Enabled), 5, 0), true);
         edtCConpCod_Enabled = 0;
         AssignProp("", false, edtCConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6P57( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6P0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264275", false, true);
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
         GXEncryptionTmp = "contabilidad.conceptocompras.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CConpCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.conceptocompras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptoCompras");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\conceptocompras:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z76CConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76CConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z78CConpDsc", StringUtil.RTrim( Z78CConpDsc));
         GxWebStd.gx_hidden_field( context, "Z517CConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z517CConpSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z77CConpCueCod", StringUtil.RTrim( Z77CConpCueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N77CConpCueCod", StringUtil.RTrim( A77CConpCueCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCCONPCUECOD_DATA", AV13CConpCueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCCONPCUECOD_DATA", AV13CConpCueCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCCONPCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCCONPCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CConpCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCCCONPCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20cCConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CCONPCUECOD", StringUtil.RTrim( AV11Insert_CConpCueCod));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CCONPCUEDSC", StringUtil.RTrim( A516CConpCueDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CCONPCUECOD_Objectcall", StringUtil.RTrim( Combo_cconpcuecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CCONPCUECOD_Cls", StringUtil.RTrim( Combo_cconpcuecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CCONPCUECOD_Selectedvalue_set", StringUtil.RTrim( Combo_cconpcuecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CCONPCUECOD_Enabled", StringUtil.BoolToStr( Combo_cconpcuecod_Enabled));
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
         GXEncryptionTmp = "contabilidad.conceptocompras.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CConpCod,6,0));
         return formatLink("contabilidad.conceptocompras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.ConceptoCompras" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Compras" ;
      }

      protected void InitializeNonKey6P57( )
      {
         A77CConpCueCod = "";
         AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
         AV20cCConpCod = 0;
         AssignAttri("", false, "AV20cCConpCod", StringUtil.LTrimStr( (decimal)(AV20cCConpCod), 6, 0));
         A78CConpDsc = "";
         AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
         A516CConpCueDsc = "";
         AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
         A517CConpSts = 1;
         AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         Z78CConpDsc = "";
         Z517CConpSts = 0;
         Z77CConpCueCod = "";
      }

      protected void InitAll6P57( )
      {
         A76CConpCod = 0;
         AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         InitializeNonKey6P57( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A517CConpSts = i517CConpSts;
         AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026430", true, true);
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
         context.AddJavascriptSource("contabilidad/conceptocompras.js", "?20228181026430", false, true);
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
         edtCConpDsc_Internalname = "CCONPDSC";
         lblTextblockcconpcuecod_Internalname = "TEXTBLOCKCCONPCUECOD";
         Combo_cconpcuecod_Internalname = "COMBO_CCONPCUECOD";
         edtCConpCueCod_Internalname = "CCONPCUECOD";
         divTablesplittedcconpcuecod_Internalname = "TABLESPLITTEDCCONPCUECOD";
         cmbCConpSts_Internalname = "CCONPSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocconpcuecod_Internalname = "vCOMBOCCONPCUECOD";
         divSectionattribute_cconpcuecod_Internalname = "SECTIONATTRIBUTE_CCONPCUECOD";
         edtCConpCod_Internalname = "CCONPCOD";
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
         Form.Caption = "Conceptos de Compras";
         edtCConpCod_Jsonclick = "";
         edtCConpCod_Enabled = 1;
         edtCConpCod_Visible = 1;
         edtavCombocconpcuecod_Jsonclick = "";
         edtavCombocconpcuecod_Enabled = 0;
         edtavCombocconpcuecod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCConpSts_Jsonclick = "";
         cmbCConpSts.Enabled = 1;
         edtCConpCueCod_Jsonclick = "";
         edtCConpCueCod_Enabled = 1;
         edtCConpCueCod_Visible = 1;
         Combo_cconpcuecod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_cconpcuecod_Enabled = Convert.ToBoolean( -1);
         edtCConpDsc_Jsonclick = "";
         edtCConpDsc_Enabled = 1;
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

      protected void GX8ASACCCONPCOD6P57( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV20cCConpCod;
            GXt_char3 = "CONCCOMPRA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int5) ;
            AV20cCConpCod = (int)(GXt_int5);
            AssignAttri("", false, "AV20cCConpCod", StringUtil.LTrimStr( (decimal)(AV20cCConpCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20cCConpCod), 6, 0, ".", "")))+"\"") ;
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
         cmbCConpSts.Name = "CCONPSTS";
         cmbCConpSts.WebTags = "";
         cmbCConpSts.addItem("1", "ACTIVO", 0);
         cmbCConpSts.addItem("0", "INACTIVO", 0);
         if ( cmbCConpSts.ItemCount > 0 )
         {
            if ( (0==A517CConpSts) )
            {
               A517CConpSts = 1;
               AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
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

      public void Valid_Cconpcuecod( )
      {
         /* Using cursor T006P13 */
         pr_default.execute(11, new Object[] {A77CConpCueCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
         }
         A516CConpCueDsc = T006P13_A516CConpCueDsc[0];
         pr_default.close(11);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A77CConpCueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta Contable", "", "", "", "", "", "", "", ""), 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A516CConpCueDsc", StringUtil.RTrim( A516CConpCueDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CConpCod',fld:'vCCONPCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CConpCod',fld:'vCCONPCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126P2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A76CConpCod',fld:'CCONPCOD',pic:'ZZZZZ9'},{av:'A78CConpDsc',fld:'CCONPDSC',pic:''},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CCONPDSC","{handler:'Valid_Cconpdsc',iparms:[]");
         setEventMetadata("VALID_CCONPDSC",",oparms:[]}");
         setEventMetadata("VALID_CCONPCUECOD","{handler:'Valid_Cconpcuecod',iparms:[{av:'A77CConpCueCod',fld:'CCONPCUECOD',pic:''},{av:'A516CConpCueDsc',fld:'CCONPCUEDSC',pic:''}]");
         setEventMetadata("VALID_CCONPCUECOD",",oparms:[{av:'A516CConpCueDsc',fld:'CCONPCUEDSC',pic:''}]}");
         setEventMetadata("VALIDV_COMBOCCONPCUECOD","{handler:'Validv_Combocconpcuecod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCCONPCUECOD",",oparms:[]}");
         setEventMetadata("VALID_CCONPCOD","{handler:'Valid_Cconpcod',iparms:[]");
         setEventMetadata("VALID_CCONPCOD",",oparms:[]}");
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
         Z78CConpDsc = "";
         Z77CConpCueCod = "";
         N77CConpCueCod = "";
         Combo_cconpcuecod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A77CConpCueCod = "";
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
         A78CConpDsc = "";
         lblTextblockcconpcuecod_Jsonclick = "";
         ucCombo_cconpcuecod = new GXUserControl();
         Combo_cconpcuecod_Caption = "";
         AV13CConpCueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV18ComboCConpCueCod = "";
         AV11Insert_CConpCueCod = "";
         A516CConpCueDsc = "";
         AV24Pgmname = "";
         Combo_cconpcuecod_Objectcall = "";
         Combo_cconpcuecod_Class = "";
         Combo_cconpcuecod_Icontype = "";
         Combo_cconpcuecod_Icon = "";
         Combo_cconpcuecod_Tooltip = "";
         Combo_cconpcuecod_Selectedvalue_set = "";
         Combo_cconpcuecod_Selectedtext_set = "";
         Combo_cconpcuecod_Selectedtext_get = "";
         Combo_cconpcuecod_Gamoauthtoken = "";
         Combo_cconpcuecod_Ddointernalname = "";
         Combo_cconpcuecod_Titlecontrolalign = "";
         Combo_cconpcuecod_Dropdownoptionstype = "";
         Combo_cconpcuecod_Titlecontrolidtoreplace = "";
         Combo_cconpcuecod_Datalisttype = "";
         Combo_cconpcuecod_Datalistfixedvalues = "";
         Combo_cconpcuecod_Datalistproc = "";
         Combo_cconpcuecod_Datalistprocparametersprefix = "";
         Combo_cconpcuecod_Htmltemplate = "";
         Combo_cconpcuecod_Multiplevaluestype = "";
         Combo_cconpcuecod_Loadingdata = "";
         Combo_cconpcuecod_Noresultsfound = "";
         Combo_cconpcuecod_Emptyitemtext = "";
         Combo_cconpcuecod_Onlyselectedvalues = "";
         Combo_cconpcuecod_Selectalltext = "";
         Combo_cconpcuecod_Multiplevaluesseparator = "";
         Combo_cconpcuecod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode57 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV21SGAuDocGls = "";
         AV22Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV15ComboSelectedValue = "";
         Z516CConpCueDsc = "";
         T006P4_A516CConpCueDsc = new string[] {""} ;
         T006P5_A76CConpCod = new int[1] ;
         T006P5_A78CConpDsc = new string[] {""} ;
         T006P5_A516CConpCueDsc = new string[] {""} ;
         T006P5_A517CConpSts = new short[1] ;
         T006P5_A77CConpCueCod = new string[] {""} ;
         T006P6_A516CConpCueDsc = new string[] {""} ;
         T006P7_A76CConpCod = new int[1] ;
         T006P3_A76CConpCod = new int[1] ;
         T006P3_A78CConpDsc = new string[] {""} ;
         T006P3_A517CConpSts = new short[1] ;
         T006P3_A77CConpCueCod = new string[] {""} ;
         T006P8_A76CConpCod = new int[1] ;
         T006P9_A76CConpCod = new int[1] ;
         T006P2_A76CConpCod = new int[1] ;
         T006P2_A78CConpDsc = new string[] {""} ;
         T006P2_A517CConpSts = new short[1] ;
         T006P2_A77CConpCueCod = new string[] {""} ;
         T006P13_A516CConpCueDsc = new string[] {""} ;
         T006P14_A76CConpCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.conceptocompras__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.conceptocompras__default(),
            new Object[][] {
                new Object[] {
               T006P2_A76CConpCod, T006P2_A78CConpDsc, T006P2_A517CConpSts, T006P2_A77CConpCueCod
               }
               , new Object[] {
               T006P3_A76CConpCod, T006P3_A78CConpDsc, T006P3_A517CConpSts, T006P3_A77CConpCueCod
               }
               , new Object[] {
               T006P4_A516CConpCueDsc
               }
               , new Object[] {
               T006P5_A76CConpCod, T006P5_A78CConpDsc, T006P5_A516CConpCueDsc, T006P5_A517CConpSts, T006P5_A77CConpCueCod
               }
               , new Object[] {
               T006P6_A516CConpCueDsc
               }
               , new Object[] {
               T006P7_A76CConpCod
               }
               , new Object[] {
               T006P8_A76CConpCod
               }
               , new Object[] {
               T006P9_A76CConpCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006P13_A516CConpCueDsc
               }
               , new Object[] {
               T006P14_A76CConpCod
               }
            }
         );
         AV24Pgmname = "Contabilidad.ConceptoCompras";
         Z517CConpSts = 1;
         A517CConpSts = 1;
         i517CConpSts = 1;
      }

      private short Z517CConpSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A517CConpSts ;
      private short Gx_BScreen ;
      private short RcdFound57 ;
      private short GX_JID ;
      private short nIsDirty_57 ;
      private short gxajaxcallmode ;
      private short i517CConpSts ;
      private int wcpOAV7CConpCod ;
      private int Z76CConpCod ;
      private int AV7CConpCod ;
      private int trnEnded ;
      private int edtCConpDsc_Enabled ;
      private int edtCConpCueCod_Visible ;
      private int edtCConpCueCod_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocconpcuecod_Visible ;
      private int edtavCombocconpcuecod_Enabled ;
      private int A76CConpCod ;
      private int edtCConpCod_Visible ;
      private int edtCConpCod_Enabled ;
      private int AV20cCConpCod ;
      private int Combo_cconpcuecod_Datalistupdateminimumcharacters ;
      private int Combo_cconpcuecod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV25GXV1 ;
      private int idxLst ;
      private long GXt_int5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z78CConpDsc ;
      private string Z77CConpCueCod ;
      private string N77CConpCueCod ;
      private string Combo_cconpcuecod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A77CConpCueCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCConpDsc_Internalname ;
      private string cmbCConpSts_Internalname ;
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
      private string A78CConpDsc ;
      private string edtCConpDsc_Jsonclick ;
      private string divTablesplittedcconpcuecod_Internalname ;
      private string lblTextblockcconpcuecod_Internalname ;
      private string lblTextblockcconpcuecod_Jsonclick ;
      private string Combo_cconpcuecod_Caption ;
      private string Combo_cconpcuecod_Cls ;
      private string Combo_cconpcuecod_Internalname ;
      private string edtCConpCueCod_Internalname ;
      private string edtCConpCueCod_Jsonclick ;
      private string cmbCConpSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_cconpcuecod_Internalname ;
      private string edtavCombocconpcuecod_Internalname ;
      private string AV18ComboCConpCueCod ;
      private string edtavCombocconpcuecod_Jsonclick ;
      private string edtCConpCod_Internalname ;
      private string edtCConpCod_Jsonclick ;
      private string AV11Insert_CConpCueCod ;
      private string A516CConpCueDsc ;
      private string AV24Pgmname ;
      private string Combo_cconpcuecod_Objectcall ;
      private string Combo_cconpcuecod_Class ;
      private string Combo_cconpcuecod_Icontype ;
      private string Combo_cconpcuecod_Icon ;
      private string Combo_cconpcuecod_Tooltip ;
      private string Combo_cconpcuecod_Selectedvalue_set ;
      private string Combo_cconpcuecod_Selectedtext_set ;
      private string Combo_cconpcuecod_Selectedtext_get ;
      private string Combo_cconpcuecod_Gamoauthtoken ;
      private string Combo_cconpcuecod_Ddointernalname ;
      private string Combo_cconpcuecod_Titlecontrolalign ;
      private string Combo_cconpcuecod_Dropdownoptionstype ;
      private string Combo_cconpcuecod_Titlecontrolidtoreplace ;
      private string Combo_cconpcuecod_Datalisttype ;
      private string Combo_cconpcuecod_Datalistfixedvalues ;
      private string Combo_cconpcuecod_Datalistproc ;
      private string Combo_cconpcuecod_Datalistprocparametersprefix ;
      private string Combo_cconpcuecod_Htmltemplate ;
      private string Combo_cconpcuecod_Multiplevaluestype ;
      private string Combo_cconpcuecod_Loadingdata ;
      private string Combo_cconpcuecod_Noresultsfound ;
      private string Combo_cconpcuecod_Emptyitemtext ;
      private string Combo_cconpcuecod_Onlyselectedvalues ;
      private string Combo_cconpcuecod_Selectalltext ;
      private string Combo_cconpcuecod_Multiplevaluesseparator ;
      private string Combo_cconpcuecod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode57 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string Z516CConpCueDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char3 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_cconpcuecod_Enabled ;
      private bool Combo_cconpcuecod_Visible ;
      private bool Combo_cconpcuecod_Allowmultipleselection ;
      private bool Combo_cconpcuecod_Isgriditem ;
      private bool Combo_cconpcuecod_Hasdescription ;
      private bool Combo_cconpcuecod_Includeonlyselectedoption ;
      private bool Combo_cconpcuecod_Includeselectalloption ;
      private bool Combo_cconpcuecod_Emptyitem ;
      private bool Combo_cconpcuecod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV21SGAuDocGls ;
      private string AV22Codigo ;
      private string AV15ComboSelectedValue ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_cconpcuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCConpSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006P4_A516CConpCueDsc ;
      private int[] T006P5_A76CConpCod ;
      private string[] T006P5_A78CConpDsc ;
      private string[] T006P5_A516CConpCueDsc ;
      private short[] T006P5_A517CConpSts ;
      private string[] T006P5_A77CConpCueCod ;
      private string[] T006P6_A516CConpCueDsc ;
      private int[] T006P7_A76CConpCod ;
      private int[] T006P3_A76CConpCod ;
      private string[] T006P3_A78CConpDsc ;
      private short[] T006P3_A517CConpSts ;
      private string[] T006P3_A77CConpCueCod ;
      private int[] T006P8_A76CConpCod ;
      private int[] T006P9_A76CConpCod ;
      private int[] T006P2_A76CConpCod ;
      private string[] T006P2_A78CConpDsc ;
      private short[] T006P2_A517CConpSts ;
      private string[] T006P2_A77CConpCueCod ;
      private string[] T006P13_A516CConpCueDsc ;
      private int[] T006P14_A76CConpCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13CConpCueCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class conceptocompras__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class conceptocompras__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006P5;
        prmT006P5 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P4;
        prmT006P4 = new Object[] {
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006P6;
        prmT006P6 = new Object[] {
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006P7;
        prmT006P7 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P3;
        prmT006P3 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P8;
        prmT006P8 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P9;
        prmT006P9 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P2;
        prmT006P2 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P10;
        prmT006P10 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0) ,
        new ParDef("@CConpDsc",GXType.NChar,100,0) ,
        new ParDef("@CConpSts",GXType.Int16,1,0) ,
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006P11;
        prmT006P11 = new Object[] {
        new ParDef("@CConpDsc",GXType.NChar,100,0) ,
        new ParDef("@CConpSts",GXType.Int16,1,0) ,
        new ParDef("@CConpCueCod",GXType.NChar,15,0) ,
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P12;
        prmT006P12 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT006P14;
        prmT006P14 = new Object[] {
        };
        Object[] prmT006P13;
        prmT006P13 = new Object[] {
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006P2", "SELECT [CConpCod], [CConpDsc], [CConpSts], [CConpCueCod] AS CConpCueCod FROM [CBCOMPRASCONC] WITH (UPDLOCK) WHERE [CConpCod] = @CConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P3", "SELECT [CConpCod], [CConpDsc], [CConpSts], [CConpCueCod] AS CConpCueCod FROM [CBCOMPRASCONC] WHERE [CConpCod] = @CConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P4", "SELECT [CueDsc] AS CConpCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CConpCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P5", "SELECT TM1.[CConpCod], TM1.[CConpDsc], T2.[CueDsc] AS CConpCueDsc, TM1.[CConpSts], TM1.[CConpCueCod] AS CConpCueCod FROM ([CBCOMPRASCONC] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CConpCueCod]) WHERE TM1.[CConpCod] = @CConpCod ORDER BY TM1.[CConpCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006P5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P6", "SELECT [CueDsc] AS CConpCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CConpCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P7", "SELECT [CConpCod] FROM [CBCOMPRASCONC] WHERE [CConpCod] = @CConpCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006P7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P8", "SELECT TOP 1 [CConpCod] FROM [CBCOMPRASCONC] WHERE ( [CConpCod] > @CConpCod) ORDER BY [CConpCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006P8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006P9", "SELECT TOP 1 [CConpCod] FROM [CBCOMPRASCONC] WHERE ( [CConpCod] < @CConpCod) ORDER BY [CConpCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006P9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006P10", "INSERT INTO [CBCOMPRASCONC]([CConpCod], [CConpDsc], [CConpSts], [CConpCueCod]) VALUES(@CConpCod, @CConpDsc, @CConpSts, @CConpCueCod)", GxErrorMask.GX_NOMASK,prmT006P10)
           ,new CursorDef("T006P11", "UPDATE [CBCOMPRASCONC] SET [CConpDsc]=@CConpDsc, [CConpSts]=@CConpSts, [CConpCueCod]=@CConpCueCod  WHERE [CConpCod] = @CConpCod", GxErrorMask.GX_NOMASK,prmT006P11)
           ,new CursorDef("T006P12", "DELETE FROM [CBCOMPRASCONC]  WHERE [CConpCod] = @CConpCod", GxErrorMask.GX_NOMASK,prmT006P12)
           ,new CursorDef("T006P13", "SELECT [CueDsc] AS CConpCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CConpCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006P13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006P14", "SELECT [CConpCod] FROM [CBCOMPRASCONC] ORDER BY [CConpCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006P14,100, GxCacheFrequency.OFF ,true,false )
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
              return;
     }
  }

}

}
