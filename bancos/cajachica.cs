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
   public class cajachica : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vCCAJCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASACCAJCOD6D169( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A91CueCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.cajachica.aspx")), "bancos.cajachica.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.cajachica.aspx")))) ;
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
                  AV7CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
                  AssignAttri("", false, "AV7CajCod", StringUtil.LTrimStr( (decimal)(AV7CajCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCAJCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CajCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Caja Chica", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCajDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cajachica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cajachica( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CajCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CajCod = aP1_CajCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCajSts = new GXCombobox();
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
         if ( cmbCajSts.ItemCount > 0 )
         {
            A487CajSts = (short)(NumberUtil.Val( cmbCajSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0))), "."));
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCajSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0));
            AssignProp("", false, cmbCajSts_Internalname, "Values", cmbCajSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCajDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCajDsc_Internalname, "Caja Chica", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajDsc_Internalname, StringUtil.RTrim( A486CajDsc), StringUtil.RTrim( context.localUtil.Format( A486CajDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtCajDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CajaChica.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCajAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCajAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajAbr_Internalname, StringUtil.RTrim( A485CajAbr), StringUtil.RTrim( context.localUtil.Format( A485CajAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CajaChica.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcuecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuecod_Internalname, "Cuenta Contable", "", "", lblTextblockcuecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CajaChica.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuecod.SetProperty("Caption", Combo_cuecod_Caption);
         ucCombo_cuecod.SetProperty("Cls", Combo_cuecod_Cls);
         ucCombo_cuecod.SetProperty("DataListProc", Combo_cuecod_Datalistproc);
         ucCombo_cuecod.SetProperty("DataListProcParametersPrefix", Combo_cuecod_Datalistprocparametersprefix);
         ucCombo_cuecod.SetProperty("EmptyItem", Combo_cuecod_Emptyitem);
         ucCombo_cuecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_cuecod.SetProperty("DropDownOptionsData", AV15CueCod_Data);
         ucCombo_cuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuecod_Internalname, "COMBO_CUECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCueCod_Visible, edtCueCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CajaChica.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCajSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCajSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCajSts, cmbCajSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0)), 1, cmbCajSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCajSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Bancos\\CajaChica.htm");
         cmbCajSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         AssignProp("", false, cmbCajSts_Internalname, "Values", (string)(cmbCajSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CajaChica.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CajaChica.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CajaChica.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_cuecod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocuecod_Internalname, StringUtil.RTrim( AV20ComboCueCod), StringUtil.RTrim( context.localUtil.Format( AV20ComboCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuecod_Visible, edtavCombocuecod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CajaChica.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A358CajCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCajCod_Visible, edtCajCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CajaChica.htm");
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
         E116D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCUECOD_DATA"), AV15CueCod_Data);
               /* Read saved values. */
               Z358CajCod = (int)(context.localUtil.CToN( cgiGet( "Z358CajCod"), ".", ","));
               Z486CajDsc = cgiGet( "Z486CajDsc");
               Z485CajAbr = cgiGet( "Z485CajAbr");
               Z487CajSts = (short)(context.localUtil.CToN( cgiGet( "Z487CajSts"), ".", ","));
               Z91CueCod = cgiGet( "Z91CueCod");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N91CueCod = cgiGet( "N91CueCod");
               AV7CajCod = (int)(context.localUtil.CToN( cgiGet( "vCAJCOD"), ".", ","));
               AV21cCajCod = (int)(context.localUtil.CToN( cgiGet( "vCCAJCOD"), ".", ","));
               AV13Insert_CueCod = cgiGet( "vINSERT_CUECOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_cuecod_Objectcall = cgiGet( "COMBO_CUECOD_Objectcall");
               Combo_cuecod_Class = cgiGet( "COMBO_CUECOD_Class");
               Combo_cuecod_Icontype = cgiGet( "COMBO_CUECOD_Icontype");
               Combo_cuecod_Icon = cgiGet( "COMBO_CUECOD_Icon");
               Combo_cuecod_Caption = cgiGet( "COMBO_CUECOD_Caption");
               Combo_cuecod_Tooltip = cgiGet( "COMBO_CUECOD_Tooltip");
               Combo_cuecod_Cls = cgiGet( "COMBO_CUECOD_Cls");
               Combo_cuecod_Selectedvalue_set = cgiGet( "COMBO_CUECOD_Selectedvalue_set");
               Combo_cuecod_Selectedvalue_get = cgiGet( "COMBO_CUECOD_Selectedvalue_get");
               Combo_cuecod_Selectedtext_set = cgiGet( "COMBO_CUECOD_Selectedtext_set");
               Combo_cuecod_Selectedtext_get = cgiGet( "COMBO_CUECOD_Selectedtext_get");
               Combo_cuecod_Gamoauthtoken = cgiGet( "COMBO_CUECOD_Gamoauthtoken");
               Combo_cuecod_Ddointernalname = cgiGet( "COMBO_CUECOD_Ddointernalname");
               Combo_cuecod_Titlecontrolalign = cgiGet( "COMBO_CUECOD_Titlecontrolalign");
               Combo_cuecod_Dropdownoptionstype = cgiGet( "COMBO_CUECOD_Dropdownoptionstype");
               Combo_cuecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Enabled"));
               Combo_cuecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Visible"));
               Combo_cuecod_Titlecontrolidtoreplace = cgiGet( "COMBO_CUECOD_Titlecontrolidtoreplace");
               Combo_cuecod_Datalisttype = cgiGet( "COMBO_CUECOD_Datalisttype");
               Combo_cuecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Allowmultipleselection"));
               Combo_cuecod_Datalistfixedvalues = cgiGet( "COMBO_CUECOD_Datalistfixedvalues");
               Combo_cuecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Isgriditem"));
               Combo_cuecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Hasdescription"));
               Combo_cuecod_Datalistproc = cgiGet( "COMBO_CUECOD_Datalistproc");
               Combo_cuecod_Datalistprocparametersprefix = cgiGet( "COMBO_CUECOD_Datalistprocparametersprefix");
               Combo_cuecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cuecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Includeonlyselectedoption"));
               Combo_cuecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Includeselectalloption"));
               Combo_cuecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Emptyitem"));
               Combo_cuecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUECOD_Includeaddnewoption"));
               Combo_cuecod_Htmltemplate = cgiGet( "COMBO_CUECOD_Htmltemplate");
               Combo_cuecod_Multiplevaluestype = cgiGet( "COMBO_CUECOD_Multiplevaluestype");
               Combo_cuecod_Loadingdata = cgiGet( "COMBO_CUECOD_Loadingdata");
               Combo_cuecod_Noresultsfound = cgiGet( "COMBO_CUECOD_Noresultsfound");
               Combo_cuecod_Emptyitemtext = cgiGet( "COMBO_CUECOD_Emptyitemtext");
               Combo_cuecod_Onlyselectedvalues = cgiGet( "COMBO_CUECOD_Onlyselectedvalues");
               Combo_cuecod_Selectalltext = cgiGet( "COMBO_CUECOD_Selectalltext");
               Combo_cuecod_Multiplevaluesseparator = cgiGet( "COMBO_CUECOD_Multiplevaluesseparator");
               Combo_cuecod_Addnewoptiontext = cgiGet( "COMBO_CUECOD_Addnewoptiontext");
               Combo_cuecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUECOD_Gxcontroltype"), ".", ","));
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
               A486CajDsc = cgiGet( edtCajDsc_Internalname);
               AssignAttri("", false, "A486CajDsc", A486CajDsc);
               A485CajAbr = cgiGet( edtCajAbr_Internalname);
               AssignAttri("", false, "A485CajAbr", A485CajAbr);
               A91CueCod = cgiGet( edtCueCod_Internalname);
               AssignAttri("", false, "A91CueCod", A91CueCod);
               cmbCajSts.CurrentValue = cgiGet( cmbCajSts_Internalname);
               A487CajSts = (short)(NumberUtil.Val( cgiGet( cmbCajSts_Internalname), "."));
               AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
               AV20ComboCueCod = cgiGet( edtavCombocuecod_Internalname);
               AssignAttri("", false, "AV20ComboCueCod", AV20ComboCueCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A358CajCod = 0;
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               }
               else
               {
                  A358CajCod = (int)(context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ","));
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CajaChica");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A358CajCod != Z358CajCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("bancos\\cajachica:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
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
                     sMode169 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode169;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound169 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CAJCOD");
                        AnyError = 1;
                        GX_FocusControl = edtCajCod_Internalname;
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
                           E116D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126D2 ();
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
            E126D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6D169( ) ;
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
            DisableAttributes6D169( ) ;
         }
         AssignProp("", false, edtavCombocuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuecod_Enabled), 5, 0), true);
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

      protected void CONFIRM_6D0( )
      {
         BeforeValidate6D169( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6D169( ) ;
            }
            else
            {
               CheckExtendedTable6D169( ) ;
               CloseExtendedTableCursors6D169( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6D0( )
      {
      }

      protected void E116D2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtCueCod_Visible = 0;
         AssignProp("", false, edtCueCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueCod_Visible), 5, 0), true);
         AV20ComboCueCod = "";
         AssignAttri("", false, "AV20ComboCueCod", AV20ComboCueCod);
         edtavCombocuecod_Visible = 0;
         AssignProp("", false, edtavCombocuecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCUECOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CueCod") == 0 )
               {
                  AV13Insert_CueCod = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_CueCod", AV13Insert_CueCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CueCod)) )
                  {
                     AV20ComboCueCod = AV13Insert_CueCod;
                     AssignAttri("", false, "AV20ComboCueCod", AV20ComboCueCod);
                     Combo_cuecod_Selectedvalue_set = AV20ComboCueCod;
                     ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedValue_set", Combo_cuecod_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.bancos.cajachicaloaddvcombo(context ).execute(  "CueCod",  "GET",  false,  AV7CajCod,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_cuecod_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedText_set", Combo_cuecod_Selectedtext_set);
                     Combo_cuecod_Enabled = false;
                     ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuecod_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtCajCod_Visible = 0;
         AssignProp("", false, edtCajCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCajCod_Visible), 5, 0), true);
      }

      protected void E126D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22SGAuDocGls = "Caja Chica N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A358CajCod), 10, 0)) + " " + StringUtil.Trim( A486CajDsc);
            AV23Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A358CajCod), 10, 0));
            GXt_char2 = "TES";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV22SGAuDocGls, ref  AV23Codigo, ref  AV23Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("bancos.cajachicaww.aspx") );
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
         /* 'LOADCOMBOCUECOD' Routine */
         returnInSub = false;
         GXt_char4 = AV19Combo_DataJson;
         new GeneXus.Programs.bancos.cajachicaloaddvcombo(context ).execute(  "CueCod",  Gx_mode,  false,  AV7CajCod,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_cuecod_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedValue_set", Combo_cuecod_Selectedvalue_set);
         Combo_cuecod_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedText_set", Combo_cuecod_Selectedtext_set);
         AV20ComboCueCod = AV17ComboSelectedValue;
         AssignAttri("", false, "AV20ComboCueCod", AV20ComboCueCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuecod_Enabled = false;
            ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuecod_Enabled));
         }
      }

      protected void ZM6D169( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z486CajDsc = T006D3_A486CajDsc[0];
               Z485CajAbr = T006D3_A485CajAbr[0];
               Z487CajSts = T006D3_A487CajSts[0];
               Z91CueCod = T006D3_A91CueCod[0];
            }
            else
            {
               Z486CajDsc = A486CajDsc;
               Z485CajAbr = A485CajAbr;
               Z487CajSts = A487CajSts;
               Z91CueCod = A91CueCod;
            }
         }
         if ( GX_JID == -15 )
         {
            Z358CajCod = A358CajCod;
            Z486CajDsc = A486CajDsc;
            Z485CajAbr = A485CajAbr;
            Z487CajSts = A487CajSts;
            Z91CueCod = A91CueCod;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "Bancos.CajaChica";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CajCod) )
         {
            A358CajCod = AV7CajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         }
         if ( ! (0==AV7CajCod) )
         {
            edtCajCod_Enabled = 0;
            AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCajCod_Enabled = 1;
            AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CajCod) )
         {
            edtCajCod_Enabled = 0;
            AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CueCod)) )
         {
            edtCueCod_Enabled = 0;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCueCod_Enabled = 1;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CueCod)) )
         {
            A91CueCod = AV13Insert_CueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
         else
         {
            A91CueCod = AV20ComboCueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
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
         if ( IsIns( )  && (0==A487CajSts) && ( Gx_BScreen == 0 ) )
         {
            A487CajSts = 1;
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load6D169( )
      {
         /* Using cursor T006D5 */
         pr_default.execute(3, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound169 = 1;
            A486CajDsc = T006D5_A486CajDsc[0];
            AssignAttri("", false, "A486CajDsc", A486CajDsc);
            A485CajAbr = T006D5_A485CajAbr[0];
            AssignAttri("", false, "A485CajAbr", A485CajAbr);
            A487CajSts = T006D5_A487CajSts[0];
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
            A91CueCod = T006D5_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            ZM6D169( -15) ;
         }
         pr_default.close(3);
         OnLoadActions6D169( ) ;
      }

      protected void OnLoadActions6D169( )
      {
      }

      protected void CheckExtendedTable6D169( )
      {
         nIsDirty_169 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A486CajDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripción de Caja", "", "", "", "", "", "", "", ""), 1, "CAJDSC");
            AnyError = 1;
            GX_FocusControl = edtCajDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A485CajAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura", "", "", "", "", "", "", "", ""), 1, "CAJABR");
            AnyError = 1;
            GX_FocusControl = edtCajAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006D4 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6D169( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( string A91CueCod )
      {
         /* Using cursor T006D6 */
         pr_default.execute(4, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey6D169( )
      {
         /* Using cursor T006D7 */
         pr_default.execute(5, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound169 = 1;
         }
         else
         {
            RcdFound169 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006D3 */
         pr_default.execute(1, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6D169( 15) ;
            RcdFound169 = 1;
            A358CajCod = T006D3_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A486CajDsc = T006D3_A486CajDsc[0];
            AssignAttri("", false, "A486CajDsc", A486CajDsc);
            A485CajAbr = T006D3_A485CajAbr[0];
            AssignAttri("", false, "A485CajAbr", A485CajAbr);
            A487CajSts = T006D3_A487CajSts[0];
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
            A91CueCod = T006D3_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            Z358CajCod = A358CajCod;
            sMode169 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6D169( ) ;
            if ( AnyError == 1 )
            {
               RcdFound169 = 0;
               InitializeNonKey6D169( ) ;
            }
            Gx_mode = sMode169;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound169 = 0;
            InitializeNonKey6D169( ) ;
            sMode169 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode169;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6D169( ) ;
         if ( RcdFound169 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound169 = 0;
         /* Using cursor T006D8 */
         pr_default.execute(6, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T006D8_A358CajCod[0] < A358CajCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T006D8_A358CajCod[0] > A358CajCod ) ) )
            {
               A358CajCod = T006D8_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               RcdFound169 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound169 = 0;
         /* Using cursor T006D9 */
         pr_default.execute(7, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T006D9_A358CajCod[0] > A358CajCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T006D9_A358CajCod[0] < A358CajCod ) ) )
            {
               A358CajCod = T006D9_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               RcdFound169 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6D169( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCajDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6D169( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound169 == 1 )
            {
               if ( A358CajCod != Z358CajCod )
               {
                  A358CajCod = Z358CajCod;
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCajDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6D169( ) ;
                  GX_FocusControl = edtCajDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A358CajCod != Z358CajCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtCajDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6D169( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCajDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6D169( ) ;
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
         if ( A358CajCod != Z358CajCod )
         {
            A358CajCod = Z358CajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCajDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6D169( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006D2 */
            pr_default.execute(0, new Object[] {A358CajCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCAJACHICA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z486CajDsc, T006D2_A486CajDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z485CajAbr, T006D2_A485CajAbr[0]) != 0 ) || ( Z487CajSts != T006D2_A487CajSts[0] ) || ( StringUtil.StrCmp(Z91CueCod, T006D2_A91CueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z486CajDsc, T006D2_A486CajDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.cajachica:[seudo value changed for attri]"+"CajDsc");
                  GXUtil.WriteLogRaw("Old: ",Z486CajDsc);
                  GXUtil.WriteLogRaw("Current: ",T006D2_A486CajDsc[0]);
               }
               if ( StringUtil.StrCmp(Z485CajAbr, T006D2_A485CajAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.cajachica:[seudo value changed for attri]"+"CajAbr");
                  GXUtil.WriteLogRaw("Old: ",Z485CajAbr);
                  GXUtil.WriteLogRaw("Current: ",T006D2_A485CajAbr[0]);
               }
               if ( Z487CajSts != T006D2_A487CajSts[0] )
               {
                  GXUtil.WriteLog("bancos.cajachica:[seudo value changed for attri]"+"CajSts");
                  GXUtil.WriteLogRaw("Old: ",Z487CajSts);
                  GXUtil.WriteLogRaw("Current: ",T006D2_A487CajSts[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T006D2_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.cajachica:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T006D2_A91CueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCAJACHICA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6D169( )
      {
         BeforeValidate6D169( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6D169( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6D169( 0) ;
            CheckOptimisticConcurrency6D169( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6D169( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6D169( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006D10 */
                     pr_default.execute(8, new Object[] {A358CajCod, A486CajDsc, A485CajAbr, A487CajSts, A91CueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCAJACHICA");
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
                           ResetCaption6D0( ) ;
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
               Load6D169( ) ;
            }
            EndLevel6D169( ) ;
         }
         CloseExtendedTableCursors6D169( ) ;
      }

      protected void Update6D169( )
      {
         BeforeValidate6D169( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6D169( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6D169( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6D169( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6D169( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006D11 */
                     pr_default.execute(9, new Object[] {A486CajDsc, A485CajAbr, A487CajSts, A91CueCod, A358CajCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCAJACHICA");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCAJACHICA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6D169( ) ;
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
            EndLevel6D169( ) ;
         }
         CloseExtendedTableCursors6D169( ) ;
      }

      protected void DeferredUpdate6D169( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6D169( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6D169( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6D169( ) ;
            AfterConfirm6D169( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6D169( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006D12 */
                  pr_default.execute(10, new Object[] {A358CajCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCAJACHICA");
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
         sMode169 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6D169( ) ;
         Gx_mode = sMode169;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6D169( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006D13 */
            pr_default.execute(11, new Object[] {A358CajCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006D14 */
            pr_default.execute(12, new Object[] {A358CajCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel6D169( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6D169( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("bancos.cajachica",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("bancos.cajachica",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6D169( )
      {
         /* Scan By routine */
         /* Using cursor T006D15 */
         pr_default.execute(13);
         RcdFound169 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound169 = 1;
            A358CajCod = T006D15_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6D169( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound169 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound169 = 1;
            A358CajCod = T006D15_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         }
      }

      protected void ScanEnd6D169( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm6D169( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV21cCajCod;
            GXt_char4 = "CAJACHICA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV21cCajCod = (int)(GXt_int5);
            AssignAttri("", false, "AV21cCajCod", StringUtil.LTrimStr( (decimal)(AV21cCajCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A358CajCod = AV21cCajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         }
      }

      protected void BeforeInsert6D169( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6D169( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6D169( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6D169( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6D169( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6D169( )
      {
         edtCajDsc_Enabled = 0;
         AssignProp("", false, edtCajDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajDsc_Enabled), 5, 0), true);
         edtCajAbr_Enabled = 0;
         AssignProp("", false, edtCajAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajAbr_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         cmbCajSts.Enabled = 0;
         AssignProp("", false, cmbCajSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCajSts.Enabled), 5, 0), true);
         edtavCombocuecod_Enabled = 0;
         AssignProp("", false, edtavCombocuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuecod_Enabled), 5, 0), true);
         edtCajCod_Enabled = 0;
         AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6D169( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6D0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262953", false, true);
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
         GXEncryptionTmp = "bancos.cajachica.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CajCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.cajachica.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CajaChica");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("bancos\\cajachica:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z486CajDsc", StringUtil.RTrim( Z486CajDsc));
         GxWebStd.gx_hidden_field( context, "Z485CajAbr", StringUtil.RTrim( Z485CajAbr));
         GxWebStd.gx_hidden_field( context, "Z487CajSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z487CajSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N91CueCod", StringUtil.RTrim( A91CueCod));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUECOD_DATA", AV15CueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUECOD_DATA", AV15CueCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vCAJCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCAJCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CajCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCCAJCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21cCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUECOD", StringUtil.RTrim( AV13Insert_CueCod));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Objectcall", StringUtil.RTrim( Combo_cuecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Cls", StringUtil.RTrim( Combo_cuecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Selectedvalue_set", StringUtil.RTrim( Combo_cuecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Selectedtext_set", StringUtil.RTrim( Combo_cuecod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Enabled", StringUtil.BoolToStr( Combo_cuecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Datalistproc", StringUtil.RTrim( Combo_cuecod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cuecod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECOD_Emptyitem", StringUtil.BoolToStr( Combo_cuecod_Emptyitem));
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
         GXEncryptionTmp = "bancos.cajachica.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CajCod,6,0));
         return formatLink("bancos.cajachica.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.CajaChica" ;
      }

      public override string GetPgmdesc( )
      {
         return "Caja Chica" ;
      }

      protected void InitializeNonKey6D169( )
      {
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         AV21cCajCod = 0;
         AssignAttri("", false, "AV21cCajCod", StringUtil.LTrimStr( (decimal)(AV21cCajCod), 6, 0));
         A486CajDsc = "";
         AssignAttri("", false, "A486CajDsc", A486CajDsc);
         A485CajAbr = "";
         AssignAttri("", false, "A485CajAbr", A485CajAbr);
         A487CajSts = 1;
         AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         Z486CajDsc = "";
         Z485CajAbr = "";
         Z487CajSts = 0;
         Z91CueCod = "";
      }

      protected void InitAll6D169( )
      {
         A358CajCod = 0;
         AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         InitializeNonKey6D169( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A487CajSts = i487CajSts;
         AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262980", true, true);
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
         context.AddJavascriptSource("bancos/cajachica.js", "?202281810262981", false, true);
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
         edtCajDsc_Internalname = "CAJDSC";
         edtCajAbr_Internalname = "CAJABR";
         lblTextblockcuecod_Internalname = "TEXTBLOCKCUECOD";
         Combo_cuecod_Internalname = "COMBO_CUECOD";
         edtCueCod_Internalname = "CUECOD";
         divTablesplittedcuecod_Internalname = "TABLESPLITTEDCUECOD";
         cmbCajSts_Internalname = "CAJSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocuecod_Internalname = "vCOMBOCUECOD";
         divSectionattribute_cuecod_Internalname = "SECTIONATTRIBUTE_CUECOD";
         edtCajCod_Internalname = "CAJCOD";
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
         Form.Caption = "Caja Chica";
         edtCajCod_Jsonclick = "";
         edtCajCod_Enabled = 1;
         edtCajCod_Visible = 1;
         edtavCombocuecod_Jsonclick = "";
         edtavCombocuecod_Enabled = 0;
         edtavCombocuecod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCajSts_Jsonclick = "";
         cmbCajSts.Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtCueCod_Visible = 1;
         Combo_cuecod_Emptyitem = Convert.ToBoolean( 0);
         Combo_cuecod_Datalistprocparametersprefix = " \"ComboName\": \"CueCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CajCod\": 0";
         Combo_cuecod_Datalistproc = "Bancos.CajaChicaLoadDVCombo";
         Combo_cuecod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_cuecod_Caption = "";
         Combo_cuecod_Enabled = Convert.ToBoolean( -1);
         edtCajAbr_Jsonclick = "";
         edtCajAbr_Enabled = 1;
         edtCajDsc_Jsonclick = "";
         edtCajDsc_Enabled = 1;
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

      protected void GX8ASACCAJCOD6D169( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV21cCajCod;
            GXt_char4 = "CAJACHICA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV21cCajCod = (int)(GXt_int5);
            AssignAttri("", false, "AV21cCajCod", StringUtil.LTrimStr( (decimal)(AV21cCajCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21cCajCod), 6, 0, ".", "")))+"\"") ;
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
         cmbCajSts.Name = "CAJSTS";
         cmbCajSts.WebTags = "";
         cmbCajSts.addItem("1", "ACTIVO", 0);
         cmbCajSts.addItem("0", "INACTIVO", 0);
         if ( cmbCajSts.ItemCount > 0 )
         {
            if ( (0==A487CajSts) )
            {
               A487CajSts = 1;
               AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
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

      public void Valid_Cuecod( )
      {
         /* Using cursor T006D16 */
         pr_default.execute(14, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         pr_default.close(14);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CajCod',fld:'vCAJCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CajCod',fld:'vCAJCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126D2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'},{av:'A486CajDsc',fld:'CAJDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CAJDSC","{handler:'Valid_Cajdsc',iparms:[]");
         setEventMetadata("VALID_CAJDSC",",oparms:[]}");
         setEventMetadata("VALID_CAJABR","{handler:'Valid_Cajabr',iparms:[]");
         setEventMetadata("VALID_CAJABR",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCUECOD","{handler:'Validv_Combocuecod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUECOD",",oparms:[]}");
         setEventMetadata("VALID_CAJCOD","{handler:'Valid_Cajcod',iparms:[]");
         setEventMetadata("VALID_CAJCOD",",oparms:[]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z486CajDsc = "";
         Z485CajAbr = "";
         Z91CueCod = "";
         N91CueCod = "";
         Combo_cuecod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A91CueCod = "";
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
         A486CajDsc = "";
         A485CajAbr = "";
         lblTextblockcuecod_Jsonclick = "";
         ucCombo_cuecod = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15CueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboCueCod = "";
         AV13Insert_CueCod = "";
         AV25Pgmname = "";
         Combo_cuecod_Objectcall = "";
         Combo_cuecod_Class = "";
         Combo_cuecod_Icontype = "";
         Combo_cuecod_Icon = "";
         Combo_cuecod_Tooltip = "";
         Combo_cuecod_Selectedvalue_set = "";
         Combo_cuecod_Selectedtext_set = "";
         Combo_cuecod_Selectedtext_get = "";
         Combo_cuecod_Gamoauthtoken = "";
         Combo_cuecod_Ddointernalname = "";
         Combo_cuecod_Titlecontrolalign = "";
         Combo_cuecod_Dropdownoptionstype = "";
         Combo_cuecod_Titlecontrolidtoreplace = "";
         Combo_cuecod_Datalisttype = "";
         Combo_cuecod_Datalistfixedvalues = "";
         Combo_cuecod_Htmltemplate = "";
         Combo_cuecod_Multiplevaluestype = "";
         Combo_cuecod_Loadingdata = "";
         Combo_cuecod_Noresultsfound = "";
         Combo_cuecod_Emptyitemtext = "";
         Combo_cuecod_Onlyselectedvalues = "";
         Combo_cuecod_Selectalltext = "";
         Combo_cuecod_Multiplevaluesseparator = "";
         Combo_cuecod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode169 = "";
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
         AV22SGAuDocGls = "";
         AV23Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         T006D5_A358CajCod = new int[1] ;
         T006D5_A486CajDsc = new string[] {""} ;
         T006D5_A485CajAbr = new string[] {""} ;
         T006D5_A487CajSts = new short[1] ;
         T006D5_A91CueCod = new string[] {""} ;
         T006D4_A91CueCod = new string[] {""} ;
         T006D6_A91CueCod = new string[] {""} ;
         T006D7_A358CajCod = new int[1] ;
         T006D3_A358CajCod = new int[1] ;
         T006D3_A486CajDsc = new string[] {""} ;
         T006D3_A485CajAbr = new string[] {""} ;
         T006D3_A487CajSts = new short[1] ;
         T006D3_A91CueCod = new string[] {""} ;
         T006D8_A358CajCod = new int[1] ;
         T006D9_A358CajCod = new int[1] ;
         T006D2_A358CajCod = new int[1] ;
         T006D2_A486CajDsc = new string[] {""} ;
         T006D2_A485CajAbr = new string[] {""} ;
         T006D2_A487CajSts = new short[1] ;
         T006D2_A91CueCod = new string[] {""} ;
         T006D13_A358CajCod = new int[1] ;
         T006D13_A391MVLCajCod = new string[] {""} ;
         T006D13_A392MVLITem = new int[1] ;
         T006D14_A358CajCod = new int[1] ;
         T006D14_A359AperCajCod = new string[] {""} ;
         T006D15_A358CajCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char4 = "";
         T006D16_A91CueCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.bancos.cajachica__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cajachica__default(),
            new Object[][] {
                new Object[] {
               T006D2_A358CajCod, T006D2_A486CajDsc, T006D2_A485CajAbr, T006D2_A487CajSts, T006D2_A91CueCod
               }
               , new Object[] {
               T006D3_A358CajCod, T006D3_A486CajDsc, T006D3_A485CajAbr, T006D3_A487CajSts, T006D3_A91CueCod
               }
               , new Object[] {
               T006D4_A91CueCod
               }
               , new Object[] {
               T006D5_A358CajCod, T006D5_A486CajDsc, T006D5_A485CajAbr, T006D5_A487CajSts, T006D5_A91CueCod
               }
               , new Object[] {
               T006D6_A91CueCod
               }
               , new Object[] {
               T006D7_A358CajCod
               }
               , new Object[] {
               T006D8_A358CajCod
               }
               , new Object[] {
               T006D9_A358CajCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006D13_A358CajCod, T006D13_A391MVLCajCod, T006D13_A392MVLITem
               }
               , new Object[] {
               T006D14_A358CajCod, T006D14_A359AperCajCod
               }
               , new Object[] {
               T006D15_A358CajCod
               }
               , new Object[] {
               T006D16_A91CueCod
               }
            }
         );
         AV25Pgmname = "Bancos.CajaChica";
         Z487CajSts = 1;
         A487CajSts = 1;
         i487CajSts = 1;
      }

      private short Z487CajSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A487CajSts ;
      private short Gx_BScreen ;
      private short RcdFound169 ;
      private short GX_JID ;
      private short nIsDirty_169 ;
      private short gxajaxcallmode ;
      private short i487CajSts ;
      private int wcpOAV7CajCod ;
      private int Z358CajCod ;
      private int AV7CajCod ;
      private int trnEnded ;
      private int edtCajDsc_Enabled ;
      private int edtCajAbr_Enabled ;
      private int edtCueCod_Visible ;
      private int edtCueCod_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocuecod_Visible ;
      private int edtavCombocuecod_Enabled ;
      private int A358CajCod ;
      private int edtCajCod_Visible ;
      private int edtCajCod_Enabled ;
      private int AV21cCajCod ;
      private int Combo_cuecod_Datalistupdateminimumcharacters ;
      private int Combo_cuecod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private long GXt_int5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z486CajDsc ;
      private string Z485CajAbr ;
      private string Z91CueCod ;
      private string N91CueCod ;
      private string Combo_cuecod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCajDsc_Internalname ;
      private string cmbCajSts_Internalname ;
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
      private string A486CajDsc ;
      private string edtCajDsc_Jsonclick ;
      private string edtCajAbr_Internalname ;
      private string A485CajAbr ;
      private string edtCajAbr_Jsonclick ;
      private string divTablesplittedcuecod_Internalname ;
      private string lblTextblockcuecod_Internalname ;
      private string lblTextblockcuecod_Jsonclick ;
      private string Combo_cuecod_Caption ;
      private string Combo_cuecod_Cls ;
      private string Combo_cuecod_Datalistproc ;
      private string Combo_cuecod_Datalistprocparametersprefix ;
      private string Combo_cuecod_Internalname ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string cmbCajSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_cuecod_Internalname ;
      private string edtavCombocuecod_Internalname ;
      private string AV20ComboCueCod ;
      private string edtavCombocuecod_Jsonclick ;
      private string edtCajCod_Internalname ;
      private string edtCajCod_Jsonclick ;
      private string AV13Insert_CueCod ;
      private string AV25Pgmname ;
      private string Combo_cuecod_Objectcall ;
      private string Combo_cuecod_Class ;
      private string Combo_cuecod_Icontype ;
      private string Combo_cuecod_Icon ;
      private string Combo_cuecod_Tooltip ;
      private string Combo_cuecod_Selectedvalue_set ;
      private string Combo_cuecod_Selectedtext_set ;
      private string Combo_cuecod_Selectedtext_get ;
      private string Combo_cuecod_Gamoauthtoken ;
      private string Combo_cuecod_Ddointernalname ;
      private string Combo_cuecod_Titlecontrolalign ;
      private string Combo_cuecod_Dropdownoptionstype ;
      private string Combo_cuecod_Titlecontrolidtoreplace ;
      private string Combo_cuecod_Datalisttype ;
      private string Combo_cuecod_Datalistfixedvalues ;
      private string Combo_cuecod_Htmltemplate ;
      private string Combo_cuecod_Multiplevaluestype ;
      private string Combo_cuecod_Loadingdata ;
      private string Combo_cuecod_Noresultsfound ;
      private string Combo_cuecod_Emptyitemtext ;
      private string Combo_cuecod_Onlyselectedvalues ;
      private string Combo_cuecod_Selectalltext ;
      private string Combo_cuecod_Multiplevaluesseparator ;
      private string Combo_cuecod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode169 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
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
      private bool Combo_cuecod_Emptyitem ;
      private bool Combo_cuecod_Enabled ;
      private bool Combo_cuecod_Visible ;
      private bool Combo_cuecod_Allowmultipleselection ;
      private bool Combo_cuecod_Isgriditem ;
      private bool Combo_cuecod_Hasdescription ;
      private bool Combo_cuecod_Includeonlyselectedoption ;
      private bool Combo_cuecod_Includeselectalloption ;
      private bool Combo_cuecod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string AV22SGAuDocGls ;
      private string AV23Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_cuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCajSts ;
      private IDataStoreProvider pr_default ;
      private int[] T006D5_A358CajCod ;
      private string[] T006D5_A486CajDsc ;
      private string[] T006D5_A485CajAbr ;
      private short[] T006D5_A487CajSts ;
      private string[] T006D5_A91CueCod ;
      private string[] T006D4_A91CueCod ;
      private string[] T006D6_A91CueCod ;
      private int[] T006D7_A358CajCod ;
      private int[] T006D3_A358CajCod ;
      private string[] T006D3_A486CajDsc ;
      private string[] T006D3_A485CajAbr ;
      private short[] T006D3_A487CajSts ;
      private string[] T006D3_A91CueCod ;
      private int[] T006D8_A358CajCod ;
      private int[] T006D9_A358CajCod ;
      private int[] T006D2_A358CajCod ;
      private string[] T006D2_A486CajDsc ;
      private string[] T006D2_A485CajAbr ;
      private short[] T006D2_A487CajSts ;
      private string[] T006D2_A91CueCod ;
      private int[] T006D13_A358CajCod ;
      private string[] T006D13_A391MVLCajCod ;
      private int[] T006D13_A392MVLITem ;
      private int[] T006D14_A358CajCod ;
      private string[] T006D14_A359AperCajCod ;
      private int[] T006D15_A358CajCod ;
      private string[] T006D16_A91CueCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15CueCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class cajachica__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cajachica__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006D5;
        prmT006D5 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D4;
        prmT006D4 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006D6;
        prmT006D6 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006D7;
        prmT006D7 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D3;
        prmT006D3 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D8;
        prmT006D8 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D9;
        prmT006D9 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D2;
        prmT006D2 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D10;
        prmT006D10 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@CajDsc",GXType.NChar,100,0) ,
        new ParDef("@CajAbr",GXType.NChar,5,0) ,
        new ParDef("@CajSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006D11;
        prmT006D11 = new Object[] {
        new ParDef("@CajDsc",GXType.NChar,100,0) ,
        new ParDef("@CajAbr",GXType.NChar,5,0) ,
        new ParDef("@CajSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D12;
        prmT006D12 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D13;
        prmT006D13 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D14;
        prmT006D14 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT006D15;
        prmT006D15 = new Object[] {
        };
        Object[] prmT006D16;
        prmT006D16 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006D2", "SELECT [CajCod], [CajDsc], [CajAbr], [CajSts], [CueCod] FROM [TSCAJACHICA] WITH (UPDLOCK) WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D3", "SELECT [CajCod], [CajDsc], [CajAbr], [CajSts], [CueCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D4", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D5", "SELECT TM1.[CajCod], TM1.[CajDsc], TM1.[CajAbr], TM1.[CajSts], TM1.[CueCod] FROM [TSCAJACHICA] TM1 WHERE TM1.[CajCod] = @CajCod ORDER BY TM1.[CajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006D5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D6", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D7", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D8", "SELECT TOP 1 [CajCod] FROM [TSCAJACHICA] WHERE ( [CajCod] > @CajCod) ORDER BY [CajCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006D8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006D9", "SELECT TOP 1 [CajCod] FROM [TSCAJACHICA] WHERE ( [CajCod] < @CajCod) ORDER BY [CajCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006D9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006D10", "INSERT INTO [TSCAJACHICA]([CajCod], [CajDsc], [CajAbr], [CajSts], [CueCod]) VALUES(@CajCod, @CajDsc, @CajAbr, @CajSts, @CueCod)", GxErrorMask.GX_NOMASK,prmT006D10)
           ,new CursorDef("T006D11", "UPDATE [TSCAJACHICA] SET [CajDsc]=@CajDsc, [CajAbr]=@CajAbr, [CajSts]=@CajSts, [CueCod]=@CueCod  WHERE [CajCod] = @CajCod", GxErrorMask.GX_NOMASK,prmT006D11)
           ,new CursorDef("T006D12", "DELETE FROM [TSCAJACHICA]  WHERE [CajCod] = @CajCod", GxErrorMask.GX_NOMASK,prmT006D12)
           ,new CursorDef("T006D13", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006D14", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006D15", "SELECT [CajCod] FROM [TSCAJACHICA] ORDER BY [CajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006D15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006D16", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006D16,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
