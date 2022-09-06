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
   public class entregarendir : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vCENTCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASACENTCOD6F175( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A91CueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A970EntCodAux = GetPar( "EntCodAux");
            n970EntCodAux = false;
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A70TipACod, A970EntCodAux) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.entregarendir.aspx")), "bancos.entregarendir.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.entregarendir.aspx")))) ;
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
                  AV10EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
                  AssignAttri("", false, "AV10EntCod", StringUtil.LTrimStr( (decimal)(AV10EntCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vENTCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10EntCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Entrega Rendir Cuenta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEntDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public entregarendir( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public entregarendir( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_EntCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10EntCod = aP1_EntCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbEntSts = new GXCombobox();
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
         if ( cmbEntSts.ItemCount > 0 )
         {
            A973EntSts = (short)(NumberUtil.Val( cmbEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0))), "."));
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0));
            AssignProp("", false, cmbEntSts_Internalname, "Values", cmbEntSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntDsc_Internalname, "Entrega a Rendir", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntDsc_Internalname, StringUtil.RTrim( A972EntDsc), StringUtil.RTrim( context.localUtil.Format( A972EntDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtEntDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\EntregaRendir.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockcuecod_Internalname, "Cuenta Contable", "", "", lblTextblockcuecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\EntregaRendir.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuecod.SetProperty("Caption", Combo_cuecod_Caption);
         ucCombo_cuecod.SetProperty("Cls", Combo_cuecod_Cls);
         ucCombo_cuecod.SetProperty("DataListProc", Combo_cuecod_Datalistproc);
         ucCombo_cuecod.SetProperty("DataListProcParametersPrefix", Combo_cuecod_Datalistprocparametersprefix);
         ucCombo_cuecod.SetProperty("EmptyItem", Combo_cuecod_Emptyitem);
         ucCombo_cuecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cuecod.SetProperty("DropDownOptionsData", AV16CueCod_Data);
         ucCombo_cuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuecod_Internalname, "COMBO_CUECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCueCod_Visible, edtCueCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\EntregaRendir.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntCodAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntCodAux_Internalname, "Auxiliar", "col-sm-3 AttributeRealWidth100WithLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntCodAux_Internalname, StringUtil.RTrim( A970EntCodAux), StringUtil.RTrim( context.localUtil.Format( A970EntCodAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCodAux_Jsonclick, 0, "AttributeRealWidth100With", "", "", "", "", 1, edtEntCodAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\EntregaRendir.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbEntSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbEntSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEntSts, cmbEntSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0)), 1, cmbEntSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbEntSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Bancos\\EntregaRendir.htm");
         cmbEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         AssignProp("", false, cmbEntSts_Internalname, "Values", (string)(cmbEntSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\EntregaRendir.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\EntregaRendir.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\EntregaRendir.htm");
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
         GxWebStd.gx_single_line_edit( context, edtavCombocuecod_Internalname, StringUtil.RTrim( AV21ComboCueCod), StringUtil.RTrim( context.localUtil.Format( AV21ComboCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuecod_Visible, edtavCombocuecod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\EntregaRendir.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365EntCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCod_Jsonclick, 0, "Attribute", "", "", "", "", edtEntCod_Visible, edtEntCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\EntregaRendir.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipACod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipACod_Enabled!=0) ? context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipACod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipACod_Visible, edtTipACod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\EntregaRendir.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEntCodAuxDsc_Internalname, StringUtil.RTrim( A971EntCodAuxDsc), StringUtil.RTrim( context.localUtil.Format( A971EntCodAuxDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCodAuxDsc_Jsonclick, 0, "Attribute", "", "", "", "", edtEntCodAuxDsc_Visible, edtEntCodAuxDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\EntregaRendir.htm");
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
         E116F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCUECOD_DATA"), AV16CueCod_Data);
               /* Read saved values. */
               Z365EntCod = (int)(context.localUtil.CToN( cgiGet( "Z365EntCod"), ".", ","));
               Z972EntDsc = cgiGet( "Z972EntDsc");
               Z969EntAbr = cgiGet( "Z969EntAbr");
               Z973EntSts = (short)(context.localUtil.CToN( cgiGet( "Z973EntSts"), ".", ","));
               Z91CueCod = cgiGet( "Z91CueCod");
               Z970EntCodAux = cgiGet( "Z970EntCodAux");
               A969EntAbr = cgiGet( "Z969EntAbr");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N91CueCod = cgiGet( "N91CueCod");
               AV10EntCod = (int)(context.localUtil.CToN( cgiGet( "vENTCOD"), ".", ","));
               AV22cEntCod = (int)(context.localUtil.CToN( cgiGet( "vCENTCOD"), ".", ","));
               AV14Insert_CueCod = cgiGet( "vINSERT_CUECOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A969EntAbr = cgiGet( "ENTABR");
               A860CueDsc = cgiGet( "CUEDSC");
               AV26Pgmname = cgiGet( "vPGMNAME");
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
               A972EntDsc = cgiGet( edtEntDsc_Internalname);
               AssignAttri("", false, "A972EntDsc", A972EntDsc);
               A91CueCod = cgiGet( edtCueCod_Internalname);
               AssignAttri("", false, "A91CueCod", A91CueCod);
               A970EntCodAux = cgiGet( edtEntCodAux_Internalname);
               n970EntCodAux = false;
               AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
               cmbEntSts.CurrentValue = cgiGet( cmbEntSts_Internalname);
               A973EntSts = (short)(NumberUtil.Val( cgiGet( cmbEntSts_Internalname), "."));
               AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
               AV21ComboCueCod = cgiGet( edtavCombocuecod_Internalname);
               AssignAttri("", false, "AV21ComboCueCod", AV21ComboCueCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A365EntCod = 0;
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               }
               else
               {
                  A365EntCod = (int)(context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ","));
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               }
               A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
               n70TipACod = false;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A971EntCodAuxDsc = cgiGet( edtEntCodAuxDsc_Internalname);
               AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"EntregaRendir");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("EntAbr", StringUtil.RTrim( context.localUtil.Format( A969EntAbr, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A365EntCod != Z365EntCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("bancos\\entregarendir:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A365EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
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
                     sMode175 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode175;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound175 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ENTCOD");
                        AnyError = 1;
                        GX_FocusControl = edtEntCod_Internalname;
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
                           E116F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126F2 ();
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
            E126F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6F175( ) ;
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
            DisableAttributes6F175( ) ;
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

      protected void CONFIRM_6F0( )
      {
         BeforeValidate6F175( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6F175( ) ;
            }
            else
            {
               CheckExtendedTable6F175( ) ;
               CloseExtendedTableCursors6F175( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6F0( )
      {
      }

      protected void E116F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtCueCod_Visible = 0;
         AssignProp("", false, edtCueCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueCod_Visible), 5, 0), true);
         AV21ComboCueCod = "";
         AssignAttri("", false, "AV21ComboCueCod", AV21ComboCueCod);
         edtavCombocuecod_Visible = 0;
         AssignProp("", false, edtavCombocuecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCUECOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CueCod") == 0 )
               {
                  AV14Insert_CueCod = AV15TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV14Insert_CueCod", AV14Insert_CueCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_CueCod)) )
                  {
                     AV21ComboCueCod = AV14Insert_CueCod;
                     AssignAttri("", false, "AV21ComboCueCod", AV21ComboCueCod);
                     Combo_cuecod_Selectedvalue_set = AV21ComboCueCod;
                     ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedValue_set", Combo_cuecod_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new GeneXus.Programs.bancos.entregarendirloaddvcombo(context ).execute(  "CueCod",  "GET",  false,  AV10EntCod,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_cuecod_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedText_set", Combo_cuecod_Selectedtext_set);
                     Combo_cuecod_Enabled = false;
                     ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuecod_Enabled));
                  }
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
         edtEntCod_Visible = 0;
         AssignProp("", false, edtEntCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEntCod_Visible), 5, 0), true);
         edtTipACod_Visible = 0;
         AssignProp("", false, edtTipACod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipACod_Visible), 5, 0), true);
         edtEntCodAuxDsc_Visible = 0;
         AssignProp("", false, edtEntCodAuxDsc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEntCodAuxDsc_Visible), 5, 0), true);
      }

      protected void E126F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23SGAuDocGls = "Entrega a Rendir N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A365EntCod), 10, 0)) + " " + StringUtil.Trim( A972EntDsc);
            AV24Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A365EntCod), 10, 0));
            GXt_char2 = "TES";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV23SGAuDocGls, ref  AV24Codigo, ref  AV24Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("bancos.entregarendirww.aspx") );
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
         GXt_char4 = AV20Combo_DataJson;
         new GeneXus.Programs.bancos.entregarendirloaddvcombo(context ).execute(  "CueCod",  Gx_mode,  false,  AV10EntCod,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_cuecod_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedValue_set", Combo_cuecod_Selectedvalue_set);
         Combo_cuecod_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "SelectedText_set", Combo_cuecod_Selectedtext_set);
         AV21ComboCueCod = AV18ComboSelectedValue;
         AssignAttri("", false, "AV21ComboCueCod", AV21ComboCueCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuecod_Enabled = false;
            ucCombo_cuecod.SendProperty(context, "", false, Combo_cuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuecod_Enabled));
         }
      }

      protected void ZM6F175( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z972EntDsc = T006F3_A972EntDsc[0];
               Z969EntAbr = T006F3_A969EntAbr[0];
               Z973EntSts = T006F3_A973EntSts[0];
               Z91CueCod = T006F3_A91CueCod[0];
               Z970EntCodAux = T006F3_A970EntCodAux[0];
            }
            else
            {
               Z972EntDsc = A972EntDsc;
               Z969EntAbr = A969EntAbr;
               Z973EntSts = A973EntSts;
               Z91CueCod = A91CueCod;
               Z970EntCodAux = A970EntCodAux;
            }
         }
         if ( GX_JID == -14 )
         {
            Z365EntCod = A365EntCod;
            Z972EntDsc = A972EntDsc;
            Z969EntAbr = A969EntAbr;
            Z973EntSts = A973EntSts;
            Z91CueCod = A91CueCod;
            Z970EntCodAux = A970EntCodAux;
            Z860CueDsc = A860CueDsc;
            Z70TipACod = A70TipACod;
            Z971EntCodAuxDsc = A971EntCodAuxDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV26Pgmname = "Bancos.EntregaRendir";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV10EntCod) )
         {
            A365EntCod = AV10EntCod;
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         }
         if ( ! (0==AV10EntCod) )
         {
            edtEntCod_Enabled = 0;
            AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         }
         else
         {
            edtEntCod_Enabled = 1;
            AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10EntCod) )
         {
            edtEntCod_Enabled = 0;
            AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_CueCod)) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_CueCod)) )
         {
            A91CueCod = AV14Insert_CueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
         else
         {
            A91CueCod = AV21ComboCueCod;
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
         if ( IsIns( )  && (0==A973EntSts) && ( Gx_BScreen == 0 ) )
         {
            A973EntSts = 1;
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T006F4 */
            pr_default.execute(2, new Object[] {A91CueCod});
            A860CueDsc = T006F4_A860CueDsc[0];
            A70TipACod = T006F4_A70TipACod[0];
            n70TipACod = T006F4_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            pr_default.close(2);
         }
      }

      protected void Load6F175( )
      {
         /* Using cursor T006F6 */
         pr_default.execute(4, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound175 = 1;
            A972EntDsc = T006F6_A972EntDsc[0];
            AssignAttri("", false, "A972EntDsc", A972EntDsc);
            A969EntAbr = T006F6_A969EntAbr[0];
            A860CueDsc = T006F6_A860CueDsc[0];
            A971EntCodAuxDsc = T006F6_A971EntCodAuxDsc[0];
            AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
            A973EntSts = T006F6_A973EntSts[0];
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
            A91CueCod = T006F6_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A70TipACod = T006F6_A70TipACod[0];
            n70TipACod = T006F6_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A970EntCodAux = T006F6_A970EntCodAux[0];
            n970EntCodAux = T006F6_n970EntCodAux[0];
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            ZM6F175( -14) ;
         }
         pr_default.close(4);
         OnLoadActions6F175( ) ;
      }

      protected void OnLoadActions6F175( )
      {
      }

      protected void CheckExtendedTable6F175( )
      {
         nIsDirty_175 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A972EntDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Entrega a Rendir", "", "", "", "", "", "", "", ""), 1, "ENTDSC");
            AnyError = 1;
            GX_FocusControl = edtEntDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006F4 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T006F4_A860CueDsc[0];
         A70TipACod = T006F4_A70TipACod[0];
         n70TipACod = T006F4_n70TipACod[0];
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         pr_default.close(2);
         /* Using cursor T006F5 */
         pr_default.execute(3, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A70TipACod) || String.IsNullOrEmpty(StringUtil.RTrim( A970EntCodAux)) ) )
            {
               GX_msglist.addItem("No existe 'Auxiliar'.", "ForeignKeyNotFound", 1, "ENTCODAUX");
               AnyError = 1;
               GX_FocusControl = edtEntCodAux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A971EntCodAuxDsc = T006F5_A971EntCodAuxDsc[0];
         AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6F175( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( string A91CueCod )
      {
         /* Using cursor T006F7 */
         pr_default.execute(5, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T006F7_A860CueDsc[0];
         A70TipACod = T006F7_A70TipACod[0];
         n70TipACod = T006F7_n70TipACod[0];
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A860CueDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_16( int A70TipACod ,
                                string A970EntCodAux )
      {
         /* Using cursor T006F8 */
         pr_default.execute(6, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A70TipACod) || String.IsNullOrEmpty(StringUtil.RTrim( A970EntCodAux)) ) )
            {
               GX_msglist.addItem("No existe 'Auxiliar'.", "ForeignKeyNotFound", 1, "ENTCODAUX");
               AnyError = 1;
               GX_FocusControl = edtEntCodAux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A971EntCodAuxDsc = T006F8_A971EntCodAuxDsc[0];
         AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A971EntCodAuxDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey6F175( )
      {
         /* Using cursor T006F9 */
         pr_default.execute(7, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound175 = 1;
         }
         else
         {
            RcdFound175 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006F3 */
         pr_default.execute(1, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6F175( 14) ;
            RcdFound175 = 1;
            A365EntCod = T006F3_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A972EntDsc = T006F3_A972EntDsc[0];
            AssignAttri("", false, "A972EntDsc", A972EntDsc);
            A969EntAbr = T006F3_A969EntAbr[0];
            A973EntSts = T006F3_A973EntSts[0];
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
            A91CueCod = T006F3_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A970EntCodAux = T006F3_A970EntCodAux[0];
            n970EntCodAux = T006F3_n970EntCodAux[0];
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            Z365EntCod = A365EntCod;
            sMode175 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6F175( ) ;
            if ( AnyError == 1 )
            {
               RcdFound175 = 0;
               InitializeNonKey6F175( ) ;
            }
            Gx_mode = sMode175;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound175 = 0;
            InitializeNonKey6F175( ) ;
            sMode175 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode175;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6F175( ) ;
         if ( RcdFound175 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound175 = 0;
         /* Using cursor T006F10 */
         pr_default.execute(8, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T006F10_A365EntCod[0] < A365EntCod ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T006F10_A365EntCod[0] > A365EntCod ) ) )
            {
               A365EntCod = T006F10_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               RcdFound175 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound175 = 0;
         /* Using cursor T006F11 */
         pr_default.execute(9, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T006F11_A365EntCod[0] > A365EntCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T006F11_A365EntCod[0] < A365EntCod ) ) )
            {
               A365EntCod = T006F11_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               RcdFound175 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6F175( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEntDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6F175( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound175 == 1 )
            {
               if ( A365EntCod != Z365EntCod )
               {
                  A365EntCod = Z365EntCod;
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEntDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6F175( ) ;
                  GX_FocusControl = edtEntDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A365EntCod != Z365EntCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtEntDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6F175( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEntDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6F175( ) ;
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
         if ( A365EntCod != Z365EntCod )
         {
            A365EntCod = Z365EntCod;
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEntDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6F175( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006F2 */
            pr_default.execute(0, new Object[] {A365EntCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSENTREGAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z972EntDsc, T006F2_A972EntDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z969EntAbr, T006F2_A969EntAbr[0]) != 0 ) || ( Z973EntSts != T006F2_A973EntSts[0] ) || ( StringUtil.StrCmp(Z91CueCod, T006F2_A91CueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z970EntCodAux, T006F2_A970EntCodAux[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z972EntDsc, T006F2_A972EntDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.entregarendir:[seudo value changed for attri]"+"EntDsc");
                  GXUtil.WriteLogRaw("Old: ",Z972EntDsc);
                  GXUtil.WriteLogRaw("Current: ",T006F2_A972EntDsc[0]);
               }
               if ( StringUtil.StrCmp(Z969EntAbr, T006F2_A969EntAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.entregarendir:[seudo value changed for attri]"+"EntAbr");
                  GXUtil.WriteLogRaw("Old: ",Z969EntAbr);
                  GXUtil.WriteLogRaw("Current: ",T006F2_A969EntAbr[0]);
               }
               if ( Z973EntSts != T006F2_A973EntSts[0] )
               {
                  GXUtil.WriteLog("bancos.entregarendir:[seudo value changed for attri]"+"EntSts");
                  GXUtil.WriteLogRaw("Old: ",Z973EntSts);
                  GXUtil.WriteLogRaw("Current: ",T006F2_A973EntSts[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T006F2_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.entregarendir:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T006F2_A91CueCod[0]);
               }
               if ( StringUtil.StrCmp(Z970EntCodAux, T006F2_A970EntCodAux[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.entregarendir:[seudo value changed for attri]"+"EntCodAux");
                  GXUtil.WriteLogRaw("Old: ",Z970EntCodAux);
                  GXUtil.WriteLogRaw("Current: ",T006F2_A970EntCodAux[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSENTREGAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6F175( )
      {
         BeforeValidate6F175( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6F175( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6F175( 0) ;
            CheckOptimisticConcurrency6F175( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6F175( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6F175( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006F12 */
                     pr_default.execute(10, new Object[] {A365EntCod, A972EntDsc, A969EntAbr, A973EntSts, A91CueCod, n970EntCodAux, A970EntCodAux});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("TSENTREGAS");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption6F0( ) ;
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
               Load6F175( ) ;
            }
            EndLevel6F175( ) ;
         }
         CloseExtendedTableCursors6F175( ) ;
      }

      protected void Update6F175( )
      {
         BeforeValidate6F175( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6F175( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6F175( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6F175( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6F175( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006F13 */
                     pr_default.execute(11, new Object[] {A972EntDsc, A969EntAbr, A973EntSts, A91CueCod, n970EntCodAux, A970EntCodAux, A365EntCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("TSENTREGAS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSENTREGAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6F175( ) ;
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
            EndLevel6F175( ) ;
         }
         CloseExtendedTableCursors6F175( ) ;
      }

      protected void DeferredUpdate6F175( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6F175( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6F175( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6F175( ) ;
            AfterConfirm6F175( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6F175( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006F14 */
                  pr_default.execute(12, new Object[] {A365EntCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("TSENTREGAS");
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
         sMode175 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6F175( ) ;
         Gx_mode = sMode175;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6F175( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006F15 */
            pr_default.execute(13, new Object[] {A91CueCod});
            A860CueDsc = T006F15_A860CueDsc[0];
            A70TipACod = T006F15_A70TipACod[0];
            n70TipACod = T006F15_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            pr_default.close(13);
            /* Using cursor T006F16 */
            pr_default.execute(14, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
            A971EntCodAuxDsc = T006F16_A971EntCodAuxDsc[0];
            AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T006F17 */
            pr_default.execute(15, new Object[] {A365EntCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T006F18 */
            pr_default.execute(16, new Object[] {A365EntCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel6F175( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6F175( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("bancos.entregarendir",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("bancos.entregarendir",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6F175( )
      {
         /* Scan By routine */
         /* Using cursor T006F19 */
         pr_default.execute(17);
         RcdFound175 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound175 = 1;
            A365EntCod = T006F19_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6F175( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound175 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound175 = 1;
            A365EntCod = T006F19_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         }
      }

      protected void ScanEnd6F175( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm6F175( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV22cEntCod;
            GXt_char4 = "ENTREGA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV22cEntCod = (int)(GXt_int5);
            AssignAttri("", false, "AV22cEntCod", StringUtil.LTrimStr( (decimal)(AV22cEntCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A365EntCod = AV22cEntCod;
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         }
      }

      protected void BeforeInsert6F175( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6F175( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6F175( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6F175( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6F175( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6F175( )
      {
         edtEntDsc_Enabled = 0;
         AssignProp("", false, edtEntDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntDsc_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtEntCodAux_Enabled = 0;
         AssignProp("", false, edtEntCodAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCodAux_Enabled), 5, 0), true);
         cmbEntSts.Enabled = 0;
         AssignProp("", false, cmbEntSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEntSts.Enabled), 5, 0), true);
         edtavCombocuecod_Enabled = 0;
         AssignProp("", false, edtavCombocuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuecod_Enabled), 5, 0), true);
         edtEntCod_Enabled = 0;
         AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         edtTipACod_Enabled = 0;
         AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         edtEntCodAuxDsc_Enabled = 0;
         AssignProp("", false, edtEntCodAuxDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCodAuxDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6F175( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810263741", false, true);
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
         GXEncryptionTmp = "bancos.entregarendir.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10EntCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.entregarendir.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"EntregaRendir");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EntAbr", StringUtil.RTrim( context.localUtil.Format( A969EntAbr, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("bancos\\entregarendir:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z972EntDsc", StringUtil.RTrim( Z972EntDsc));
         GxWebStd.gx_hidden_field( context, "Z969EntAbr", StringUtil.RTrim( Z969EntAbr));
         GxWebStd.gx_hidden_field( context, "Z973EntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z973EntSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z970EntCodAux", StringUtil.RTrim( Z970EntCodAux));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N91CueCod", StringUtil.RTrim( A91CueCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUECOD_DATA", AV16CueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUECOD_DATA", AV16CueCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vENTCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENTCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10EntCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCENTCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22cEntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUECOD", StringUtil.RTrim( AV14Insert_CueCod));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ENTABR", StringUtil.RTrim( A969EntAbr));
         GxWebStd.gx_hidden_field( context, "CUEDSC", StringUtil.RTrim( A860CueDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
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
         GXEncryptionTmp = "bancos.entregarendir.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10EntCod,6,0));
         return formatLink("bancos.entregarendir.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.EntregaRendir" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entrega Rendir Cuenta" ;
      }

      protected void InitializeNonKey6F175( )
      {
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         AV22cEntCod = 0;
         AssignAttri("", false, "AV22cEntCod", StringUtil.LTrimStr( (decimal)(AV22cEntCod), 6, 0));
         A972EntDsc = "";
         AssignAttri("", false, "A972EntDsc", A972EntDsc);
         A969EntAbr = "";
         AssignAttri("", false, "A969EntAbr", A969EntAbr);
         A860CueDsc = "";
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A70TipACod = 0;
         n70TipACod = false;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         A970EntCodAux = "";
         n970EntCodAux = false;
         AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
         A971EntCodAuxDsc = "";
         AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
         A973EntSts = 1;
         AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         Z972EntDsc = "";
         Z969EntAbr = "";
         Z973EntSts = 0;
         Z91CueCod = "";
         Z970EntCodAux = "";
      }

      protected void InitAll6F175( )
      {
         A365EntCod = 0;
         AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         InitializeNonKey6F175( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A973EntSts = i973EntSts;
         AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810263772", true, true);
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
         context.AddJavascriptSource("bancos/entregarendir.js", "?202281810263772", false, true);
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
         edtEntDsc_Internalname = "ENTDSC";
         lblTextblockcuecod_Internalname = "TEXTBLOCKCUECOD";
         Combo_cuecod_Internalname = "COMBO_CUECOD";
         edtCueCod_Internalname = "CUECOD";
         divTablesplittedcuecod_Internalname = "TABLESPLITTEDCUECOD";
         edtEntCodAux_Internalname = "ENTCODAUX";
         cmbEntSts_Internalname = "ENTSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocuecod_Internalname = "vCOMBOCUECOD";
         divSectionattribute_cuecod_Internalname = "SECTIONATTRIBUTE_CUECOD";
         edtEntCod_Internalname = "ENTCOD";
         edtTipACod_Internalname = "TIPACOD";
         edtEntCodAuxDsc_Internalname = "ENTCODAUXDSC";
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
         Form.Caption = "Entrega Rendir Cuenta";
         edtEntCodAuxDsc_Jsonclick = "";
         edtEntCodAuxDsc_Enabled = 0;
         edtEntCodAuxDsc_Visible = 1;
         edtTipACod_Jsonclick = "";
         edtTipACod_Enabled = 0;
         edtTipACod_Visible = 1;
         edtEntCod_Jsonclick = "";
         edtEntCod_Enabled = 1;
         edtEntCod_Visible = 1;
         edtavCombocuecod_Jsonclick = "";
         edtavCombocuecod_Enabled = 0;
         edtavCombocuecod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbEntSts_Jsonclick = "";
         cmbEntSts.Enabled = 1;
         edtEntCodAux_Jsonclick = "";
         edtEntCodAux_Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtCueCod_Visible = 1;
         Combo_cuecod_Emptyitem = Convert.ToBoolean( 0);
         Combo_cuecod_Datalistprocparametersprefix = " \"ComboName\": \"CueCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"EntCod\": 0";
         Combo_cuecod_Datalistproc = "Bancos.EntregaRendirLoadDVCombo";
         Combo_cuecod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_cuecod_Caption = "";
         Combo_cuecod_Enabled = Convert.ToBoolean( -1);
         edtEntDsc_Jsonclick = "";
         edtEntDsc_Enabled = 1;
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

      protected void GX8ASACENTCOD6F175( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV22cEntCod;
            GXt_char4 = "ENTREGA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV22cEntCod = (int)(GXt_int5);
            AssignAttri("", false, "AV22cEntCod", StringUtil.LTrimStr( (decimal)(AV22cEntCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22cEntCod), 6, 0, ".", "")))+"\"") ;
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
         cmbEntSts.Name = "ENTSTS";
         cmbEntSts.WebTags = "";
         cmbEntSts.addItem("1", "ACTIVO", 0);
         cmbEntSts.addItem("0", "INACTIVO", 0);
         if ( cmbEntSts.ItemCount > 0 )
         {
            if ( (0==A973EntSts) )
            {
               A973EntSts = 1;
               AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
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
         n70TipACod = false;
         /* Using cursor T006F15 */
         pr_default.execute(13, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         A860CueDsc = T006F15_A860CueDsc[0];
         A70TipACod = T006F15_A70TipACod[0];
         n70TipACod = T006F15_n70TipACod[0];
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
         AssignAttri("", false, "A70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
      }

      public void Valid_Entcodaux( )
      {
         n70TipACod = false;
         n970EntCodAux = false;
         /* Using cursor T006F16 */
         pr_default.execute(14, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A70TipACod) || String.IsNullOrEmpty(StringUtil.RTrim( A970EntCodAux)) ) )
            {
               GX_msglist.addItem("No existe 'Auxiliar'.", "ForeignKeyNotFound", 1, "ENTCODAUX");
               AnyError = 1;
               GX_FocusControl = edtEntCodAux_Internalname;
            }
         }
         A971EntCodAuxDsc = T006F16_A971EntCodAuxDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A971EntCodAuxDsc", StringUtil.RTrim( A971EntCodAuxDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10EntCod',fld:'vENTCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV10EntCod',fld:'vENTCOD',pic:'ZZZZZ9',hsh:true},{av:'A969EntAbr',fld:'ENTABR',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126F2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A365EntCod',fld:'ENTCOD',pic:'ZZZZZ9'},{av:'A972EntDsc',fld:'ENTDSC',pic:''},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ENTDSC","{handler:'Valid_Entdsc',iparms:[]");
         setEventMetadata("VALID_ENTDSC",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_ENTCODAUX","{handler:'Valid_Entcodaux',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'},{av:'A970EntCodAux',fld:'ENTCODAUX',pic:''},{av:'A971EntCodAuxDsc',fld:'ENTCODAUXDSC',pic:''}]");
         setEventMetadata("VALID_ENTCODAUX",",oparms:[{av:'A971EntCodAuxDsc',fld:'ENTCODAUXDSC',pic:''}]}");
         setEventMetadata("VALIDV_COMBOCUECOD","{handler:'Validv_Combocuecod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUECOD",",oparms:[]}");
         setEventMetadata("VALID_ENTCOD","{handler:'Valid_Entcod',iparms:[]");
         setEventMetadata("VALID_ENTCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z972EntDsc = "";
         Z969EntAbr = "";
         Z91CueCod = "";
         Z970EntCodAux = "";
         N91CueCod = "";
         Combo_cuecod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A91CueCod = "";
         A970EntCodAux = "";
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
         A972EntDsc = "";
         lblTextblockcuecod_Jsonclick = "";
         ucCombo_cuecod = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16CueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV21ComboCueCod = "";
         A971EntCodAuxDsc = "";
         A969EntAbr = "";
         AV14Insert_CueCod = "";
         A860CueDsc = "";
         AV26Pgmname = "";
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
         sMode175 = "";
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
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         AV23SGAuDocGls = "";
         AV24Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         Z860CueDsc = "";
         Z971EntCodAuxDsc = "";
         T006F4_A860CueDsc = new string[] {""} ;
         T006F4_A70TipACod = new int[1] ;
         T006F4_n70TipACod = new bool[] {false} ;
         T006F6_A365EntCod = new int[1] ;
         T006F6_A972EntDsc = new string[] {""} ;
         T006F6_A969EntAbr = new string[] {""} ;
         T006F6_A860CueDsc = new string[] {""} ;
         T006F6_A971EntCodAuxDsc = new string[] {""} ;
         T006F6_A973EntSts = new short[1] ;
         T006F6_A91CueCod = new string[] {""} ;
         T006F6_A70TipACod = new int[1] ;
         T006F6_n70TipACod = new bool[] {false} ;
         T006F6_A970EntCodAux = new string[] {""} ;
         T006F6_n970EntCodAux = new bool[] {false} ;
         T006F5_A971EntCodAuxDsc = new string[] {""} ;
         T006F7_A860CueDsc = new string[] {""} ;
         T006F7_A70TipACod = new int[1] ;
         T006F7_n70TipACod = new bool[] {false} ;
         T006F8_A971EntCodAuxDsc = new string[] {""} ;
         T006F9_A365EntCod = new int[1] ;
         T006F3_A365EntCod = new int[1] ;
         T006F3_A972EntDsc = new string[] {""} ;
         T006F3_A969EntAbr = new string[] {""} ;
         T006F3_A973EntSts = new short[1] ;
         T006F3_A91CueCod = new string[] {""} ;
         T006F3_A970EntCodAux = new string[] {""} ;
         T006F3_n970EntCodAux = new bool[] {false} ;
         T006F10_A365EntCod = new int[1] ;
         T006F11_A365EntCod = new int[1] ;
         T006F2_A365EntCod = new int[1] ;
         T006F2_A972EntDsc = new string[] {""} ;
         T006F2_A969EntAbr = new string[] {""} ;
         T006F2_A973EntSts = new short[1] ;
         T006F2_A91CueCod = new string[] {""} ;
         T006F2_A970EntCodAux = new string[] {""} ;
         T006F2_n970EntCodAux = new bool[] {false} ;
         T006F15_A860CueDsc = new string[] {""} ;
         T006F15_A70TipACod = new int[1] ;
         T006F15_n70TipACod = new bool[] {false} ;
         T006F16_A971EntCodAuxDsc = new string[] {""} ;
         T006F17_A365EntCod = new int[1] ;
         T006F17_A403MVLEntCod = new string[] {""} ;
         T006F17_A404MVLEITem = new int[1] ;
         T006F18_A365EntCod = new int[1] ;
         T006F18_A366AperEntCod = new string[] {""} ;
         T006F19_A365EntCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char4 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.bancos.entregarendir__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.entregarendir__default(),
            new Object[][] {
                new Object[] {
               T006F2_A365EntCod, T006F2_A972EntDsc, T006F2_A969EntAbr, T006F2_A973EntSts, T006F2_A91CueCod, T006F2_A970EntCodAux, T006F2_n970EntCodAux
               }
               , new Object[] {
               T006F3_A365EntCod, T006F3_A972EntDsc, T006F3_A969EntAbr, T006F3_A973EntSts, T006F3_A91CueCod, T006F3_A970EntCodAux, T006F3_n970EntCodAux
               }
               , new Object[] {
               T006F4_A860CueDsc, T006F4_A70TipACod, T006F4_n70TipACod
               }
               , new Object[] {
               T006F5_A971EntCodAuxDsc
               }
               , new Object[] {
               T006F6_A365EntCod, T006F6_A972EntDsc, T006F6_A969EntAbr, T006F6_A860CueDsc, T006F6_A971EntCodAuxDsc, T006F6_A973EntSts, T006F6_A91CueCod, T006F6_A70TipACod, T006F6_n70TipACod, T006F6_A970EntCodAux,
               T006F6_n970EntCodAux
               }
               , new Object[] {
               T006F7_A860CueDsc, T006F7_A70TipACod, T006F7_n70TipACod
               }
               , new Object[] {
               T006F8_A971EntCodAuxDsc
               }
               , new Object[] {
               T006F9_A365EntCod
               }
               , new Object[] {
               T006F10_A365EntCod
               }
               , new Object[] {
               T006F11_A365EntCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006F15_A860CueDsc, T006F15_A70TipACod, T006F15_n70TipACod
               }
               , new Object[] {
               T006F16_A971EntCodAuxDsc
               }
               , new Object[] {
               T006F17_A365EntCod, T006F17_A403MVLEntCod, T006F17_A404MVLEITem
               }
               , new Object[] {
               T006F18_A365EntCod, T006F18_A366AperEntCod
               }
               , new Object[] {
               T006F19_A365EntCod
               }
            }
         );
         AV26Pgmname = "Bancos.EntregaRendir";
         Z973EntSts = 1;
         A973EntSts = 1;
         i973EntSts = 1;
      }

      private short Z973EntSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A973EntSts ;
      private short Gx_BScreen ;
      private short RcdFound175 ;
      private short GX_JID ;
      private short nIsDirty_175 ;
      private short gxajaxcallmode ;
      private short i973EntSts ;
      private int wcpOAV10EntCod ;
      private int Z365EntCod ;
      private int A70TipACod ;
      private int AV10EntCod ;
      private int trnEnded ;
      private int edtEntDsc_Enabled ;
      private int edtCueCod_Visible ;
      private int edtCueCod_Enabled ;
      private int edtEntCodAux_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocuecod_Visible ;
      private int edtavCombocuecod_Enabled ;
      private int A365EntCod ;
      private int edtEntCod_Visible ;
      private int edtEntCod_Enabled ;
      private int edtTipACod_Enabled ;
      private int edtTipACod_Visible ;
      private int edtEntCodAuxDsc_Visible ;
      private int edtEntCodAuxDsc_Enabled ;
      private int AV22cEntCod ;
      private int Combo_cuecod_Datalistupdateminimumcharacters ;
      private int Combo_cuecod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV27GXV1 ;
      private int Z70TipACod ;
      private int idxLst ;
      private long GXt_int5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z972EntDsc ;
      private string Z969EntAbr ;
      private string Z91CueCod ;
      private string Z970EntCodAux ;
      private string N91CueCod ;
      private string Combo_cuecod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string A970EntCodAux ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEntDsc_Internalname ;
      private string cmbEntSts_Internalname ;
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
      private string A972EntDsc ;
      private string edtEntDsc_Jsonclick ;
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
      private string edtEntCodAux_Internalname ;
      private string edtEntCodAux_Jsonclick ;
      private string cmbEntSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_cuecod_Internalname ;
      private string edtavCombocuecod_Internalname ;
      private string AV21ComboCueCod ;
      private string edtavCombocuecod_Jsonclick ;
      private string edtEntCod_Internalname ;
      private string edtEntCod_Jsonclick ;
      private string edtTipACod_Internalname ;
      private string edtTipACod_Jsonclick ;
      private string edtEntCodAuxDsc_Internalname ;
      private string A971EntCodAuxDsc ;
      private string edtEntCodAuxDsc_Jsonclick ;
      private string A969EntAbr ;
      private string AV14Insert_CueCod ;
      private string A860CueDsc ;
      private string AV26Pgmname ;
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
      private string sMode175 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string Z860CueDsc ;
      private string Z971EntCodAuxDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char4 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n70TipACod ;
      private bool n970EntCodAux ;
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
      private string AV20Combo_DataJson ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private string AV23SGAuDocGls ;
      private string AV24Codigo ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_cuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEntSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006F4_A860CueDsc ;
      private int[] T006F4_A70TipACod ;
      private bool[] T006F4_n70TipACod ;
      private int[] T006F6_A365EntCod ;
      private string[] T006F6_A972EntDsc ;
      private string[] T006F6_A969EntAbr ;
      private string[] T006F6_A860CueDsc ;
      private string[] T006F6_A971EntCodAuxDsc ;
      private short[] T006F6_A973EntSts ;
      private string[] T006F6_A91CueCod ;
      private int[] T006F6_A70TipACod ;
      private bool[] T006F6_n70TipACod ;
      private string[] T006F6_A970EntCodAux ;
      private bool[] T006F6_n970EntCodAux ;
      private string[] T006F5_A971EntCodAuxDsc ;
      private string[] T006F7_A860CueDsc ;
      private int[] T006F7_A70TipACod ;
      private bool[] T006F7_n70TipACod ;
      private string[] T006F8_A971EntCodAuxDsc ;
      private int[] T006F9_A365EntCod ;
      private int[] T006F3_A365EntCod ;
      private string[] T006F3_A972EntDsc ;
      private string[] T006F3_A969EntAbr ;
      private short[] T006F3_A973EntSts ;
      private string[] T006F3_A91CueCod ;
      private string[] T006F3_A970EntCodAux ;
      private bool[] T006F3_n970EntCodAux ;
      private int[] T006F10_A365EntCod ;
      private int[] T006F11_A365EntCod ;
      private int[] T006F2_A365EntCod ;
      private string[] T006F2_A972EntDsc ;
      private string[] T006F2_A969EntAbr ;
      private short[] T006F2_A973EntSts ;
      private string[] T006F2_A91CueCod ;
      private string[] T006F2_A970EntCodAux ;
      private bool[] T006F2_n970EntCodAux ;
      private string[] T006F15_A860CueDsc ;
      private int[] T006F15_A70TipACod ;
      private bool[] T006F15_n70TipACod ;
      private string[] T006F16_A971EntCodAuxDsc ;
      private int[] T006F17_A365EntCod ;
      private string[] T006F17_A403MVLEntCod ;
      private int[] T006F17_A404MVLEITem ;
      private int[] T006F18_A365EntCod ;
      private string[] T006F18_A366AperEntCod ;
      private int[] T006F19_A365EntCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV16CueCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
   }

   public class entregarendir__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class entregarendir__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006F6;
        prmT006F6 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F4;
        prmT006F4 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006F5;
        prmT006F5 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT006F7;
        prmT006F7 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006F8;
        prmT006F8 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT006F9;
        prmT006F9 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F3;
        prmT006F3 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F10;
        prmT006F10 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F11;
        prmT006F11 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F2;
        prmT006F2 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F12;
        prmT006F12 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@EntDsc",GXType.NChar,100,0) ,
        new ParDef("@EntAbr",GXType.NChar,5,0) ,
        new ParDef("@EntSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT006F13;
        prmT006F13 = new Object[] {
        new ParDef("@EntDsc",GXType.NChar,100,0) ,
        new ParDef("@EntAbr",GXType.NChar,5,0) ,
        new ParDef("@EntSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F14;
        prmT006F14 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F17;
        prmT006F17 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F18;
        prmT006F18 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT006F19;
        prmT006F19 = new Object[] {
        };
        Object[] prmT006F15;
        prmT006F15 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006F16;
        prmT006F16 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006F2", "SELECT [EntCod], [EntDsc], [EntAbr], [EntSts], [CueCod], [EntCodAux] AS EntCodAux FROM [TSENTREGAS] WITH (UPDLOCK) WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F3", "SELECT [EntCod], [EntDsc], [EntAbr], [EntSts], [CueCod], [EntCodAux] AS EntCodAux FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F4", "SELECT [CueDsc], [TipACod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F5", "SELECT [TipADDsc] AS EntCodAuxDsc FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @EntCodAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F6", "SELECT TM1.[EntCod], TM1.[EntDsc], TM1.[EntAbr], T2.[CueDsc], T3.[TipADDsc] AS EntCodAuxDsc, TM1.[EntSts], TM1.[CueCod], T2.[TipACod], TM1.[EntCodAux] AS EntCodAux FROM (([TSENTREGAS] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CueCod]) LEFT JOIN [CBAUXILIARES] T3 ON T3.[TipACod] = T2.[TipACod] AND T3.[TipADCod] = TM1.[EntCodAux]) WHERE TM1.[EntCod] = @EntCod ORDER BY TM1.[EntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006F6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F7", "SELECT [CueDsc], [TipACod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F8", "SELECT [TipADDsc] AS EntCodAuxDsc FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @EntCodAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F9", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F10", "SELECT TOP 1 [EntCod] FROM [TSENTREGAS] WHERE ( [EntCod] > @EntCod) ORDER BY [EntCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006F11", "SELECT TOP 1 [EntCod] FROM [TSENTREGAS] WHERE ( [EntCod] < @EntCod) ORDER BY [EntCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006F12", "INSERT INTO [TSENTREGAS]([EntCod], [EntDsc], [EntAbr], [EntSts], [CueCod], [EntCodAux]) VALUES(@EntCod, @EntDsc, @EntAbr, @EntSts, @CueCod, @EntCodAux)", GxErrorMask.GX_NOMASK,prmT006F12)
           ,new CursorDef("T006F13", "UPDATE [TSENTREGAS] SET [EntDsc]=@EntDsc, [EntAbr]=@EntAbr, [EntSts]=@EntSts, [CueCod]=@CueCod, [EntCodAux]=@EntCodAux  WHERE [EntCod] = @EntCod", GxErrorMask.GX_NOMASK,prmT006F13)
           ,new CursorDef("T006F14", "DELETE FROM [TSENTREGAS]  WHERE [EntCod] = @EntCod", GxErrorMask.GX_NOMASK,prmT006F14)
           ,new CursorDef("T006F15", "SELECT [CueDsc], [TipACod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F16", "SELECT [TipADDsc] AS EntCodAuxDsc FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @EntCodAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006F17", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006F18", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006F18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006F19", "SELECT [EntCod] FROM [TSENTREGAS] ORDER BY [EntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006F19,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
