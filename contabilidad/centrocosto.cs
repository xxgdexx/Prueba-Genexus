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
   public class centrocosto : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A80COSCueDestino = GetPar( "COSCueDestino");
            n80COSCueDestino = false;
            AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A80COSCueDestino) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.centrocosto.aspx")), "contabilidad.centrocosto.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.centrocosto.aspx")))) ;
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
                  AV7COSCod = GetPar( "COSCod");
                  AssignAttri("", false, "AV7COSCod", AV7COSCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCOSCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7COSCod, "")), context));
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
            Form.Meta.addItem("description", "Centros de Costos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public centrocosto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public centrocosto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_COSCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7COSCod = aP1_COSCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCOSSts = new GXCombobox();
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
         if ( cmbCOSSts.ItemCount > 0 )
         {
            A762COSSts = (short)(NumberUtil.Val( cmbCOSSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0))), "."));
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCOSSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            AssignProp("", false, cmbCOSSts_Internalname, "Values", cmbCOSSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod), StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSCod_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSDsc_Internalname, "Centro de Costos", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSDsc_Internalname, StringUtil.RTrim( A761COSDsc), StringUtil.RTrim( context.localUtil.Format( A761COSDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtCOSDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSAbr_Internalname, StringUtil.RTrim( A759COSAbr), StringUtil.RTrim( context.localUtil.Format( A759COSAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcoscuedestino_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcoscuedestino_Internalname, "Cuenta Contable Destino", "", "", lblTextblockcoscuedestino_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_coscuedestino.SetProperty("Caption", Combo_coscuedestino_Caption);
         ucCombo_coscuedestino.SetProperty("Cls", Combo_coscuedestino_Cls);
         ucCombo_coscuedestino.SetProperty("DropDownOptionsData", AV15COSCueDestino_Data);
         ucCombo_coscuedestino.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_coscuedestino_Internalname, "COMBO_COSCUEDESTINOContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSCueDestino_Internalname, "Cuenta Destino", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSCueDestino_Internalname, StringUtil.RTrim( A80COSCueDestino), StringUtil.RTrim( context.localUtil.Format( A80COSCueDestino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSCueDestino_Jsonclick, 0, "Attribute", "", "", "", "", edtCOSCueDestino_Visible, edtCOSCueDestino_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\CentroCosto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCOSSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCOSSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCOSSts, cmbCOSSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0)), 1, cmbCOSSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCOSSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 1, "HLP_Contabilidad\\CentroCosto.htm");
         cmbCOSSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         AssignProp("", false, cmbCOSSts_Internalname, "Values", (string)(cmbCOSSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\CentroCosto.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_coscuedestino_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocoscuedestino_Internalname, StringUtil.RTrim( AV20ComboCOSCueDestino), StringUtil.RTrim( context.localUtil.Format( AV20ComboCOSCueDestino, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocoscuedestino_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocoscuedestino_Visible, edtavCombocoscuedestino_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\CentroCosto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E116O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vCOSCUEDESTINO_DATA"), AV15COSCueDestino_Data);
               /* Read saved values. */
               Z79COSCod = cgiGet( "Z79COSCod");
               Z761COSDsc = cgiGet( "Z761COSDsc");
               Z759COSAbr = cgiGet( "Z759COSAbr");
               Z762COSSts = (short)(context.localUtil.CToN( cgiGet( "Z762COSSts"), ".", ","));
               Z80COSCueDestino = cgiGet( "Z80COSCueDestino");
               n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N80COSCueDestino = cgiGet( "N80COSCueDestino");
               n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
               AV7COSCod = cgiGet( "vCOSCOD");
               AV13Insert_COSCueDestino = cgiGet( "vINSERT_COSCUEDESTINO");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A760CosCueDestinoDsc = cgiGet( "COSCUEDESTINODSC");
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_coscuedestino_Objectcall = cgiGet( "COMBO_COSCUEDESTINO_Objectcall");
               Combo_coscuedestino_Class = cgiGet( "COMBO_COSCUEDESTINO_Class");
               Combo_coscuedestino_Icontype = cgiGet( "COMBO_COSCUEDESTINO_Icontype");
               Combo_coscuedestino_Icon = cgiGet( "COMBO_COSCUEDESTINO_Icon");
               Combo_coscuedestino_Caption = cgiGet( "COMBO_COSCUEDESTINO_Caption");
               Combo_coscuedestino_Tooltip = cgiGet( "COMBO_COSCUEDESTINO_Tooltip");
               Combo_coscuedestino_Cls = cgiGet( "COMBO_COSCUEDESTINO_Cls");
               Combo_coscuedestino_Selectedvalue_set = cgiGet( "COMBO_COSCUEDESTINO_Selectedvalue_set");
               Combo_coscuedestino_Selectedvalue_get = cgiGet( "COMBO_COSCUEDESTINO_Selectedvalue_get");
               Combo_coscuedestino_Selectedtext_set = cgiGet( "COMBO_COSCUEDESTINO_Selectedtext_set");
               Combo_coscuedestino_Selectedtext_get = cgiGet( "COMBO_COSCUEDESTINO_Selectedtext_get");
               Combo_coscuedestino_Gamoauthtoken = cgiGet( "COMBO_COSCUEDESTINO_Gamoauthtoken");
               Combo_coscuedestino_Ddointernalname = cgiGet( "COMBO_COSCUEDESTINO_Ddointernalname");
               Combo_coscuedestino_Titlecontrolalign = cgiGet( "COMBO_COSCUEDESTINO_Titlecontrolalign");
               Combo_coscuedestino_Dropdownoptionstype = cgiGet( "COMBO_COSCUEDESTINO_Dropdownoptionstype");
               Combo_coscuedestino_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Enabled"));
               Combo_coscuedestino_Visible = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Visible"));
               Combo_coscuedestino_Titlecontrolidtoreplace = cgiGet( "COMBO_COSCUEDESTINO_Titlecontrolidtoreplace");
               Combo_coscuedestino_Datalisttype = cgiGet( "COMBO_COSCUEDESTINO_Datalisttype");
               Combo_coscuedestino_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Allowmultipleselection"));
               Combo_coscuedestino_Datalistfixedvalues = cgiGet( "COMBO_COSCUEDESTINO_Datalistfixedvalues");
               Combo_coscuedestino_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Isgriditem"));
               Combo_coscuedestino_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Hasdescription"));
               Combo_coscuedestino_Datalistproc = cgiGet( "COMBO_COSCUEDESTINO_Datalistproc");
               Combo_coscuedestino_Datalistprocparametersprefix = cgiGet( "COMBO_COSCUEDESTINO_Datalistprocparametersprefix");
               Combo_coscuedestino_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_COSCUEDESTINO_Datalistupdateminimumcharacters"), ".", ","));
               Combo_coscuedestino_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Includeonlyselectedoption"));
               Combo_coscuedestino_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Includeselectalloption"));
               Combo_coscuedestino_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Emptyitem"));
               Combo_coscuedestino_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_COSCUEDESTINO_Includeaddnewoption"));
               Combo_coscuedestino_Htmltemplate = cgiGet( "COMBO_COSCUEDESTINO_Htmltemplate");
               Combo_coscuedestino_Multiplevaluestype = cgiGet( "COMBO_COSCUEDESTINO_Multiplevaluestype");
               Combo_coscuedestino_Loadingdata = cgiGet( "COMBO_COSCUEDESTINO_Loadingdata");
               Combo_coscuedestino_Noresultsfound = cgiGet( "COMBO_COSCUEDESTINO_Noresultsfound");
               Combo_coscuedestino_Emptyitemtext = cgiGet( "COMBO_COSCUEDESTINO_Emptyitemtext");
               Combo_coscuedestino_Onlyselectedvalues = cgiGet( "COMBO_COSCUEDESTINO_Onlyselectedvalues");
               Combo_coscuedestino_Selectalltext = cgiGet( "COMBO_COSCUEDESTINO_Selectalltext");
               Combo_coscuedestino_Multiplevaluesseparator = cgiGet( "COMBO_COSCUEDESTINO_Multiplevaluesseparator");
               Combo_coscuedestino_Addnewoptiontext = cgiGet( "COMBO_COSCUEDESTINO_Addnewoptiontext");
               Combo_coscuedestino_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_COSCUEDESTINO_Gxcontroltype"), ".", ","));
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
               A79COSCod = cgiGet( edtCOSCod_Internalname);
               n79COSCod = false;
               AssignAttri("", false, "A79COSCod", A79COSCod);
               A761COSDsc = cgiGet( edtCOSDsc_Internalname);
               AssignAttri("", false, "A761COSDsc", A761COSDsc);
               A759COSAbr = cgiGet( edtCOSAbr_Internalname);
               AssignAttri("", false, "A759COSAbr", A759COSAbr);
               A80COSCueDestino = cgiGet( edtCOSCueDestino_Internalname);
               n80COSCueDestino = false;
               AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
               n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
               cmbCOSSts.CurrentValue = cgiGet( cmbCOSSts_Internalname);
               A762COSSts = (short)(NumberUtil.Val( cgiGet( cmbCOSSts_Internalname), "."));
               AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
               AV20ComboCOSCueDestino = cgiGet( edtavCombocoscuedestino_Internalname);
               AssignAttri("", false, "AV20ComboCOSCueDestino", AV20ComboCOSCueDestino);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CentroCosto");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\centrocosto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A79COSCod = GetPar( "COSCod");
                  n79COSCod = false;
                  AssignAttri("", false, "A79COSCod", A79COSCod);
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
                     sMode58 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode58;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound58 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COSCOD");
                        AnyError = 1;
                        GX_FocusControl = edtCOSCod_Internalname;
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
                           E116O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126O2 ();
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
            E126O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6O58( ) ;
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
            DisableAttributes6O58( ) ;
         }
         AssignProp("", false, edtavCombocoscuedestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocoscuedestino_Enabled), 5, 0), true);
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

      protected void CONFIRM_6O0( )
      {
         BeforeValidate6O58( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6O58( ) ;
            }
            else
            {
               CheckExtendedTable6O58( ) ;
               CloseExtendedTableCursors6O58( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6O0( )
      {
      }

      protected void E116O2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         edtCOSCueDestino_Visible = 0;
         AssignProp("", false, edtCOSCueDestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCOSCueDestino_Visible), 5, 0), true);
         AV20ComboCOSCueDestino = "";
         AssignAttri("", false, "AV20ComboCOSCueDestino", AV20ComboCOSCueDestino);
         edtavCombocoscuedestino_Visible = 0;
         AssignProp("", false, edtavCombocoscuedestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocoscuedestino_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCOSCUEDESTINO' */
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "COSCueDestino") == 0 )
               {
                  AV13Insert_COSCueDestino = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_COSCueDestino", AV13Insert_COSCueDestino);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_COSCueDestino)) )
                  {
                     AV20ComboCOSCueDestino = AV13Insert_COSCueDestino;
                     AssignAttri("", false, "AV20ComboCOSCueDestino", AV20ComboCOSCueDestino);
                     Combo_coscuedestino_Selectedvalue_set = AV20ComboCOSCueDestino;
                     ucCombo_coscuedestino.SendProperty(context, "", false, Combo_coscuedestino_Internalname, "SelectedValue_set", Combo_coscuedestino_Selectedvalue_set);
                     Combo_coscuedestino_Enabled = false;
                     ucCombo_coscuedestino.SendProperty(context, "", false, Combo_coscuedestino_Internalname, "Enabled", StringUtil.BoolToStr( Combo_coscuedestino_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
      }

      protected void E126O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22SGAuDocGls = "Centro de Costo N° " + StringUtil.Trim( A79COSCod) + " " + StringUtil.Trim( A761COSDsc);
            AV23Codigo = StringUtil.Trim( A79COSCod);
            GXt_char1 = "CON";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV22SGAuDocGls, ref  AV23Codigo, ref  AV23Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.centrocostoww.aspx") );
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
         /* 'LOADCOMBOCOSCUEDESTINO' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV15COSCueDestino_Data;
         new GeneXus.Programs.contabilidad.centrocostoloaddvcombo(context ).execute(  "COSCueDestino",  Gx_mode,  AV7COSCod, out  AV17ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV15COSCueDestino_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_coscuedestino_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_coscuedestino.SendProperty(context, "", false, Combo_coscuedestino_Internalname, "SelectedValue_set", Combo_coscuedestino_Selectedvalue_set);
         AV20ComboCOSCueDestino = AV17ComboSelectedValue;
         AssignAttri("", false, "AV20ComboCOSCueDestino", AV20ComboCOSCueDestino);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_coscuedestino_Enabled = false;
            ucCombo_coscuedestino.SendProperty(context, "", false, Combo_coscuedestino_Internalname, "Enabled", StringUtil.BoolToStr( Combo_coscuedestino_Enabled));
         }
      }

      protected void ZM6O58( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z761COSDsc = T006O3_A761COSDsc[0];
               Z759COSAbr = T006O3_A759COSAbr[0];
               Z762COSSts = T006O3_A762COSSts[0];
               Z80COSCueDestino = T006O3_A80COSCueDestino[0];
            }
            else
            {
               Z761COSDsc = A761COSDsc;
               Z759COSAbr = A759COSAbr;
               Z762COSSts = A762COSSts;
               Z80COSCueDestino = A80COSCueDestino;
            }
         }
         if ( GX_JID == -12 )
         {
            Z79COSCod = A79COSCod;
            Z761COSDsc = A761COSDsc;
            Z759COSAbr = A759COSAbr;
            Z762COSSts = A762COSSts;
            Z80COSCueDestino = A80COSCueDestino;
            Z760CosCueDestinoDsc = A760CosCueDestinoDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "Contabilidad.CentroCosto";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7COSCod)) )
         {
            A79COSCod = AV7COSCod;
            n79COSCod = false;
            AssignAttri("", false, "A79COSCod", A79COSCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7COSCod)) )
         {
            edtCOSCod_Enabled = 0;
            AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCOSCod_Enabled = 1;
            AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7COSCod)) )
         {
            edtCOSCod_Enabled = 0;
            AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_COSCueDestino)) )
         {
            edtCOSCueDestino_Enabled = 0;
            AssignProp("", false, edtCOSCueDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCueDestino_Enabled), 5, 0), true);
         }
         else
         {
            edtCOSCueDestino_Enabled = 1;
            AssignProp("", false, edtCOSCueDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCueDestino_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_COSCueDestino)) )
         {
            A80COSCueDestino = AV13Insert_COSCueDestino;
            n80COSCueDestino = false;
            AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ComboCOSCueDestino)) )
            {
               A80COSCueDestino = "";
               n80COSCueDestino = false;
               AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
               n80COSCueDestino = true;
               AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ComboCOSCueDestino)) )
               {
                  A80COSCueDestino = AV20ComboCOSCueDestino;
                  n80COSCueDestino = false;
                  AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
               }
            }
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
         if ( IsIns( )  && (0==A762COSSts) && ( Gx_BScreen == 0 ) )
         {
            A762COSSts = 1;
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T006O4 */
            pr_default.execute(2, new Object[] {n80COSCueDestino, A80COSCueDestino});
            A760CosCueDestinoDsc = T006O4_A760CosCueDestinoDsc[0];
            pr_default.close(2);
         }
      }

      protected void Load6O58( )
      {
         /* Using cursor T006O5 */
         pr_default.execute(3, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
            A761COSDsc = T006O5_A761COSDsc[0];
            AssignAttri("", false, "A761COSDsc", A761COSDsc);
            A759COSAbr = T006O5_A759COSAbr[0];
            AssignAttri("", false, "A759COSAbr", A759COSAbr);
            A762COSSts = T006O5_A762COSSts[0];
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            A760CosCueDestinoDsc = T006O5_A760CosCueDestinoDsc[0];
            A80COSCueDestino = T006O5_A80COSCueDestino[0];
            n80COSCueDestino = T006O5_n80COSCueDestino[0];
            AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
            ZM6O58( -12) ;
         }
         pr_default.close(3);
         OnLoadActions6O58( ) ;
      }

      protected void OnLoadActions6O58( )
      {
      }

      protected void CheckExtendedTable6O58( )
      {
         nIsDirty_58 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo de C.Costo", "", "", "", "", "", "", "", ""), 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A761COSDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Centro de Costos", "", "", "", "", "", "", "", ""), 1, "COSDSC");
            AnyError = 1;
            GX_FocusControl = edtCOSDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006O4 */
         pr_default.execute(2, new Object[] {n80COSCueDestino, A80COSCueDestino});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "COSCUEDESTINO");
               AnyError = 1;
               GX_FocusControl = edtCOSCueDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A760CosCueDestinoDsc = T006O4_A760CosCueDestinoDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors6O58( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( string A80COSCueDestino )
      {
         /* Using cursor T006O6 */
         pr_default.execute(4, new Object[] {n80COSCueDestino, A80COSCueDestino});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "COSCUEDESTINO");
               AnyError = 1;
               GX_FocusControl = edtCOSCueDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A760CosCueDestinoDsc = T006O6_A760CosCueDestinoDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A760CosCueDestinoDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey6O58( )
      {
         /* Using cursor T006O7 */
         pr_default.execute(5, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006O3 */
         pr_default.execute(1, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6O58( 12) ;
            RcdFound58 = 1;
            A79COSCod = T006O3_A79COSCod[0];
            n79COSCod = T006O3_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A761COSDsc = T006O3_A761COSDsc[0];
            AssignAttri("", false, "A761COSDsc", A761COSDsc);
            A759COSAbr = T006O3_A759COSAbr[0];
            AssignAttri("", false, "A759COSAbr", A759COSAbr);
            A762COSSts = T006O3_A762COSSts[0];
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            A80COSCueDestino = T006O3_A80COSCueDestino[0];
            n80COSCueDestino = T006O3_n80COSCueDestino[0];
            AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
            Z79COSCod = A79COSCod;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6O58( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey6O58( ) ;
            }
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey6O58( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6O58( ) ;
         if ( RcdFound58 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound58 = 0;
         /* Using cursor T006O8 */
         pr_default.execute(6, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T006O8_A79COSCod[0], A79COSCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T006O8_A79COSCod[0], A79COSCod) > 0 ) ) )
            {
               A79COSCod = T006O8_A79COSCod[0];
               n79COSCod = T006O8_n79COSCod[0];
               AssignAttri("", false, "A79COSCod", A79COSCod);
               RcdFound58 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound58 = 0;
         /* Using cursor T006O9 */
         pr_default.execute(7, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T006O9_A79COSCod[0], A79COSCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T006O9_A79COSCod[0], A79COSCod) < 0 ) ) )
            {
               A79COSCod = T006O9_A79COSCod[0];
               n79COSCod = T006O9_n79COSCod[0];
               AssignAttri("", false, "A79COSCod", A79COSCod);
               RcdFound58 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6O58( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6O58( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
               {
                  A79COSCod = Z79COSCod;
                  n79COSCod = false;
                  AssignAttri("", false, "A79COSCod", A79COSCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6O58( ) ;
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6O58( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCOSCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCOSCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6O58( ) ;
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
         if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
         {
            A79COSCod = Z79COSCod;
            n79COSCod = false;
            AssignAttri("", false, "A79COSCod", A79COSCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6O58( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006O2 */
            pr_default.execute(0, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOSTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z761COSDsc, T006O2_A761COSDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z759COSAbr, T006O2_A759COSAbr[0]) != 0 ) || ( Z762COSSts != T006O2_A762COSSts[0] ) || ( StringUtil.StrCmp(Z80COSCueDestino, T006O2_A80COSCueDestino[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z761COSDsc, T006O2_A761COSDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.centrocosto:[seudo value changed for attri]"+"COSDsc");
                  GXUtil.WriteLogRaw("Old: ",Z761COSDsc);
                  GXUtil.WriteLogRaw("Current: ",T006O2_A761COSDsc[0]);
               }
               if ( StringUtil.StrCmp(Z759COSAbr, T006O2_A759COSAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.centrocosto:[seudo value changed for attri]"+"COSAbr");
                  GXUtil.WriteLogRaw("Old: ",Z759COSAbr);
                  GXUtil.WriteLogRaw("Current: ",T006O2_A759COSAbr[0]);
               }
               if ( Z762COSSts != T006O2_A762COSSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.centrocosto:[seudo value changed for attri]"+"COSSts");
                  GXUtil.WriteLogRaw("Old: ",Z762COSSts);
                  GXUtil.WriteLogRaw("Current: ",T006O2_A762COSSts[0]);
               }
               if ( StringUtil.StrCmp(Z80COSCueDestino, T006O2_A80COSCueDestino[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.centrocosto:[seudo value changed for attri]"+"COSCueDestino");
                  GXUtil.WriteLogRaw("Old: ",Z80COSCueDestino);
                  GXUtil.WriteLogRaw("Current: ",T006O2_A80COSCueDestino[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBCOSTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6O58( )
      {
         BeforeValidate6O58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6O58( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6O58( 0) ;
            CheckOptimisticConcurrency6O58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6O58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6O58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006O10 */
                     pr_default.execute(8, new Object[] {n79COSCod, A79COSCod, A761COSDsc, A759COSAbr, A762COSSts, n80COSCueDestino, A80COSCueDestino});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOSTOS");
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
                           ResetCaption6O0( ) ;
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
               Load6O58( ) ;
            }
            EndLevel6O58( ) ;
         }
         CloseExtendedTableCursors6O58( ) ;
      }

      protected void Update6O58( )
      {
         BeforeValidate6O58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6O58( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6O58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6O58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6O58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006O11 */
                     pr_default.execute(9, new Object[] {A761COSDsc, A759COSAbr, A762COSSts, n80COSCueDestino, A80COSCueDestino, n79COSCod, A79COSCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOSTOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOSTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6O58( ) ;
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
            EndLevel6O58( ) ;
         }
         CloseExtendedTableCursors6O58( ) ;
      }

      protected void DeferredUpdate6O58( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6O58( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6O58( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6O58( ) ;
            AfterConfirm6O58( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6O58( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006O12 */
                  pr_default.execute(10, new Object[] {n79COSCod, A79COSCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBCOSTOS");
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
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6O58( ) ;
         Gx_mode = sMode58;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6O58( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006O13 */
            pr_default.execute(11, new Object[] {n80COSCueDestino, A80COSCueDestino});
            A760CosCueDestinoDsc = T006O13_A760CosCueDestinoDsc[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T006O14 */
            pr_default.execute(12, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Activo Fijo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T006O15 */
            pr_default.execute(13, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"+" ("+"C.Costo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T006O16 */
            pr_default.execute(14, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"+" ("+"C.Costo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T006O17 */
            pr_default.execute(15, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"+" ("+"Centro de Costos"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T006O18 */
            pr_default.execute(16, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"+" ("+"Centro de Costos"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T006O19 */
            pr_default.execute(17, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006O20 */
            pr_default.execute(18, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006O21 */
            pr_default.execute(19, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T006O22 */
            pr_default.execute(20, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T006O23 */
            pr_default.execute(21, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T006O24 */
            pr_default.execute(22, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTACTIVOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T006O25 */
            pr_default.execute(23, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel6O58( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6O58( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("contabilidad.centrocosto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("contabilidad.centrocosto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6O58( )
      {
         /* Scan By routine */
         /* Using cursor T006O26 */
         pr_default.execute(24);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound58 = 1;
            A79COSCod = T006O26_A79COSCod[0];
            n79COSCod = T006O26_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6O58( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound58 = 1;
            A79COSCod = T006O26_A79COSCod[0];
            n79COSCod = T006O26_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
         }
      }

      protected void ScanEnd6O58( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm6O58( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6O58( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6O58( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6O58( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6O58( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6O58( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6O58( )
      {
         edtCOSCod_Enabled = 0;
         AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         edtCOSDsc_Enabled = 0;
         AssignProp("", false, edtCOSDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSDsc_Enabled), 5, 0), true);
         edtCOSAbr_Enabled = 0;
         AssignProp("", false, edtCOSAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSAbr_Enabled), 5, 0), true);
         edtCOSCueDestino_Enabled = 0;
         AssignProp("", false, edtCOSCueDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCueDestino_Enabled), 5, 0), true);
         cmbCOSSts.Enabled = 0;
         AssignProp("", false, cmbCOSSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCOSSts.Enabled), 5, 0), true);
         edtavCombocoscuedestino_Enabled = 0;
         AssignProp("", false, edtavCombocoscuedestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocoscuedestino_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6O58( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6O0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264950", false, true);
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
         GXEncryptionTmp = "contabilidad.centrocosto.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7COSCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.centrocosto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CentroCosto");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\centrocosto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z761COSDsc", StringUtil.RTrim( Z761COSDsc));
         GxWebStd.gx_hidden_field( context, "Z759COSAbr", StringUtil.RTrim( Z759COSAbr));
         GxWebStd.gx_hidden_field( context, "Z762COSSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z762COSSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z80COSCueDestino", StringUtil.RTrim( Z80COSCueDestino));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N80COSCueDestino", StringUtil.RTrim( A80COSCueDestino));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSCUEDESTINO_DATA", AV15COSCueDestino_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSCUEDESTINO_DATA", AV15COSCueDestino_Data);
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
         GxWebStd.gx_hidden_field( context, "vCOSCOD", StringUtil.RTrim( AV7COSCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOSCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7COSCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COSCUEDESTINO", StringUtil.RTrim( AV13Insert_COSCueDestino));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COSCUEDESTINODSC", StringUtil.RTrim( A760CosCueDestinoDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCUEDESTINO_Objectcall", StringUtil.RTrim( Combo_coscuedestino_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCUEDESTINO_Cls", StringUtil.RTrim( Combo_coscuedestino_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCUEDESTINO_Selectedvalue_set", StringUtil.RTrim( Combo_coscuedestino_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COSCUEDESTINO_Enabled", StringUtil.BoolToStr( Combo_coscuedestino_Enabled));
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
         GXEncryptionTmp = "contabilidad.centrocosto.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7COSCod));
         return formatLink("contabilidad.centrocosto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.CentroCosto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Centros de Costos" ;
      }

      protected void InitializeNonKey6O58( )
      {
         A80COSCueDestino = "";
         n80COSCueDestino = false;
         AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
         n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
         A761COSDsc = "";
         AssignAttri("", false, "A761COSDsc", A761COSDsc);
         A759COSAbr = "";
         AssignAttri("", false, "A759COSAbr", A759COSAbr);
         A760CosCueDestinoDsc = "";
         AssignAttri("", false, "A760CosCueDestinoDsc", A760CosCueDestinoDsc);
         A762COSSts = 1;
         AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         Z761COSDsc = "";
         Z759COSAbr = "";
         Z762COSSts = 0;
         Z80COSCueDestino = "";
      }

      protected void InitAll6O58( )
      {
         A79COSCod = "";
         n79COSCod = false;
         AssignAttri("", false, "A79COSCod", A79COSCod);
         InitializeNonKey6O58( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A762COSSts = i762COSSts;
         AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264975", true, true);
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
         context.AddJavascriptSource("contabilidad/centrocosto.js", "?202281810264975", false, true);
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
         edtCOSCod_Internalname = "COSCOD";
         edtCOSDsc_Internalname = "COSDSC";
         edtCOSAbr_Internalname = "COSABR";
         lblTextblockcoscuedestino_Internalname = "TEXTBLOCKCOSCUEDESTINO";
         Combo_coscuedestino_Internalname = "COMBO_COSCUEDESTINO";
         edtCOSCueDestino_Internalname = "COSCUEDESTINO";
         divTablesplittedcoscuedestino_Internalname = "TABLESPLITTEDCOSCUEDESTINO";
         cmbCOSSts_Internalname = "COSSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocoscuedestino_Internalname = "vCOMBOCOSCUEDESTINO";
         divSectionattribute_coscuedestino_Internalname = "SECTIONATTRIBUTE_COSCUEDESTINO";
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
         Form.Caption = "Centros de Costos";
         edtavCombocoscuedestino_Jsonclick = "";
         edtavCombocoscuedestino_Enabled = 0;
         edtavCombocoscuedestino_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCOSSts_Jsonclick = "";
         cmbCOSSts.Enabled = 1;
         edtCOSCueDestino_Jsonclick = "";
         edtCOSCueDestino_Enabled = 1;
         edtCOSCueDestino_Visible = 1;
         Combo_coscuedestino_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_coscuedestino_Enabled = Convert.ToBoolean( -1);
         edtCOSAbr_Jsonclick = "";
         edtCOSAbr_Enabled = 1;
         edtCOSDsc_Jsonclick = "";
         edtCOSDsc_Enabled = 1;
         edtCOSCod_Jsonclick = "";
         edtCOSCod_Enabled = 1;
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
         cmbCOSSts.Name = "COSSTS";
         cmbCOSSts.WebTags = "";
         cmbCOSSts.addItem("1", "ACTIVO", 0);
         cmbCOSSts.addItem("0", "INACTIVO", 0);
         if ( cmbCOSSts.ItemCount > 0 )
         {
            if ( (0==A762COSSts) )
            {
               A762COSSts = 1;
               AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
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

      public void Valid_Coscuedestino( )
      {
         n80COSCueDestino = false;
         /* Using cursor T006O13 */
         pr_default.execute(11, new Object[] {n80COSCueDestino, A80COSCueDestino});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "COSCUEDESTINO");
               AnyError = 1;
               GX_FocusControl = edtCOSCueDestino_Internalname;
            }
         }
         A760CosCueDestinoDsc = T006O13_A760CosCueDestinoDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A760CosCueDestinoDsc", StringUtil.RTrim( A760CosCueDestinoDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7COSCod',fld:'vCOSCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7COSCod',fld:'vCOSCOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126O2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A761COSDsc',fld:'COSDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_COSCOD","{handler:'Valid_Coscod',iparms:[]");
         setEventMetadata("VALID_COSCOD",",oparms:[]}");
         setEventMetadata("VALID_COSDSC","{handler:'Valid_Cosdsc',iparms:[]");
         setEventMetadata("VALID_COSDSC",",oparms:[]}");
         setEventMetadata("VALID_COSCUEDESTINO","{handler:'Valid_Coscuedestino',iparms:[{av:'A80COSCueDestino',fld:'COSCUEDESTINO',pic:''},{av:'A760CosCueDestinoDsc',fld:'COSCUEDESTINODSC',pic:''}]");
         setEventMetadata("VALID_COSCUEDESTINO",",oparms:[{av:'A760CosCueDestinoDsc',fld:'COSCUEDESTINODSC',pic:''}]}");
         setEventMetadata("VALIDV_COMBOCOSCUEDESTINO","{handler:'Validv_Combocoscuedestino',iparms:[]");
         setEventMetadata("VALIDV_COMBOCOSCUEDESTINO",",oparms:[]}");
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
         wcpOAV7COSCod = "";
         Z79COSCod = "";
         Z761COSDsc = "";
         Z759COSAbr = "";
         Z80COSCueDestino = "";
         N80COSCueDestino = "";
         Combo_coscuedestino_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A80COSCueDestino = "";
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
         A79COSCod = "";
         A761COSDsc = "";
         A759COSAbr = "";
         lblTextblockcoscuedestino_Jsonclick = "";
         ucCombo_coscuedestino = new GXUserControl();
         Combo_coscuedestino_Caption = "";
         AV15COSCueDestino_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboCOSCueDestino = "";
         AV13Insert_COSCueDestino = "";
         A760CosCueDestinoDsc = "";
         AV25Pgmname = "";
         Combo_coscuedestino_Objectcall = "";
         Combo_coscuedestino_Class = "";
         Combo_coscuedestino_Icontype = "";
         Combo_coscuedestino_Icon = "";
         Combo_coscuedestino_Tooltip = "";
         Combo_coscuedestino_Selectedvalue_set = "";
         Combo_coscuedestino_Selectedtext_set = "";
         Combo_coscuedestino_Selectedtext_get = "";
         Combo_coscuedestino_Gamoauthtoken = "";
         Combo_coscuedestino_Ddointernalname = "";
         Combo_coscuedestino_Titlecontrolalign = "";
         Combo_coscuedestino_Dropdownoptionstype = "";
         Combo_coscuedestino_Titlecontrolidtoreplace = "";
         Combo_coscuedestino_Datalisttype = "";
         Combo_coscuedestino_Datalistfixedvalues = "";
         Combo_coscuedestino_Datalistproc = "";
         Combo_coscuedestino_Datalistprocparametersprefix = "";
         Combo_coscuedestino_Htmltemplate = "";
         Combo_coscuedestino_Multiplevaluestype = "";
         Combo_coscuedestino_Loadingdata = "";
         Combo_coscuedestino_Noresultsfound = "";
         Combo_coscuedestino_Emptyitemtext = "";
         Combo_coscuedestino_Onlyselectedvalues = "";
         Combo_coscuedestino_Selectalltext = "";
         Combo_coscuedestino_Multiplevaluesseparator = "";
         Combo_coscuedestino_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode58 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV22SGAuDocGls = "";
         AV23Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_char3 = "";
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         Z760CosCueDestinoDsc = "";
         T006O4_A760CosCueDestinoDsc = new string[] {""} ;
         T006O5_A79COSCod = new string[] {""} ;
         T006O5_n79COSCod = new bool[] {false} ;
         T006O5_A761COSDsc = new string[] {""} ;
         T006O5_A759COSAbr = new string[] {""} ;
         T006O5_A762COSSts = new short[1] ;
         T006O5_A760CosCueDestinoDsc = new string[] {""} ;
         T006O5_A80COSCueDestino = new string[] {""} ;
         T006O5_n80COSCueDestino = new bool[] {false} ;
         T006O6_A760CosCueDestinoDsc = new string[] {""} ;
         T006O7_A79COSCod = new string[] {""} ;
         T006O7_n79COSCod = new bool[] {false} ;
         T006O3_A79COSCod = new string[] {""} ;
         T006O3_n79COSCod = new bool[] {false} ;
         T006O3_A761COSDsc = new string[] {""} ;
         T006O3_A759COSAbr = new string[] {""} ;
         T006O3_A762COSSts = new short[1] ;
         T006O3_A80COSCueDestino = new string[] {""} ;
         T006O3_n80COSCueDestino = new bool[] {false} ;
         T006O8_A79COSCod = new string[] {""} ;
         T006O8_n79COSCod = new bool[] {false} ;
         T006O9_A79COSCod = new string[] {""} ;
         T006O9_n79COSCod = new bool[] {false} ;
         T006O2_A79COSCod = new string[] {""} ;
         T006O2_n79COSCod = new bool[] {false} ;
         T006O2_A761COSDsc = new string[] {""} ;
         T006O2_A759COSAbr = new string[] {""} ;
         T006O2_A762COSSts = new short[1] ;
         T006O2_A80COSCueDestino = new string[] {""} ;
         T006O2_n80COSCueDestino = new bool[] {false} ;
         T006O13_A760CosCueDestinoDsc = new string[] {""} ;
         T006O14_A2109AMovCod = new string[] {""} ;
         T006O15_A365EntCod = new int[1] ;
         T006O15_A403MVLEntCod = new string[] {""} ;
         T006O15_A404MVLEITem = new int[1] ;
         T006O16_A365EntCod = new int[1] ;
         T006O16_A403MVLEntCod = new string[] {""} ;
         T006O16_A404MVLEITem = new int[1] ;
         T006O17_A358CajCod = new int[1] ;
         T006O17_A391MVLCajCod = new string[] {""} ;
         T006O17_A392MVLITem = new int[1] ;
         T006O18_A358CajCod = new int[1] ;
         T006O18_A391MVLCajCod = new string[] {""} ;
         T006O18_A392MVLITem = new int[1] ;
         T006O19_A379LBBanCod = new int[1] ;
         T006O19_A380LBCBCod = new string[] {""} ;
         T006O19_A381LBRegistro = new string[] {""} ;
         T006O19_A383LBDITem = new int[1] ;
         T006O20_A289OrdCod = new string[] {""} ;
         T006O21_A149TipCod = new string[] {""} ;
         T006O21_A243ComCod = new string[] {""} ;
         T006O21_A244PrvCod = new string[] {""} ;
         T006O21_A250ComDItem = new short[1] ;
         T006O21_A251ComDOrdCod = new string[] {""} ;
         T006O22_A2280CBTipPre = new int[1] ;
         T006O22_A2281CBTipTipo = new string[] {""} ;
         T006O22_A2282CBLinPre = new int[1] ;
         T006O22_A2283CBRubPre = new int[1] ;
         T006O22_A2284CBRubDItem = new int[1] ;
         T006O23_A2263CBFlujCAno = new short[1] ;
         T006O23_A2264CBFlujCMes = new short[1] ;
         T006O23_A2265CBFlujCBanCod = new int[1] ;
         T006O23_A2266CBFlujCCuenta = new string[] {""} ;
         T006O23_A2267CBFlujCRegistro = new string[] {""} ;
         T006O23_A2268CBFlujCItem = new int[1] ;
         T006O24_A2100ACTActCod = new string[] {""} ;
         T006O25_A127VouAno = new short[1] ;
         T006O25_A128VouMes = new short[1] ;
         T006O25_A126TASICod = new int[1] ;
         T006O25_A129VouNum = new string[] {""} ;
         T006O25_A130VouDSec = new int[1] ;
         T006O26_A79COSCod = new string[] {""} ;
         T006O26_n79COSCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.centrocosto__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.centrocosto__default(),
            new Object[][] {
                new Object[] {
               T006O2_A79COSCod, T006O2_A761COSDsc, T006O2_A759COSAbr, T006O2_A762COSSts, T006O2_A80COSCueDestino, T006O2_n80COSCueDestino
               }
               , new Object[] {
               T006O3_A79COSCod, T006O3_A761COSDsc, T006O3_A759COSAbr, T006O3_A762COSSts, T006O3_A80COSCueDestino, T006O3_n80COSCueDestino
               }
               , new Object[] {
               T006O4_A760CosCueDestinoDsc
               }
               , new Object[] {
               T006O5_A79COSCod, T006O5_A761COSDsc, T006O5_A759COSAbr, T006O5_A762COSSts, T006O5_A760CosCueDestinoDsc, T006O5_A80COSCueDestino, T006O5_n80COSCueDestino
               }
               , new Object[] {
               T006O6_A760CosCueDestinoDsc
               }
               , new Object[] {
               T006O7_A79COSCod
               }
               , new Object[] {
               T006O8_A79COSCod
               }
               , new Object[] {
               T006O9_A79COSCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006O13_A760CosCueDestinoDsc
               }
               , new Object[] {
               T006O14_A2109AMovCod
               }
               , new Object[] {
               T006O15_A365EntCod, T006O15_A403MVLEntCod, T006O15_A404MVLEITem
               }
               , new Object[] {
               T006O16_A365EntCod, T006O16_A403MVLEntCod, T006O16_A404MVLEITem
               }
               , new Object[] {
               T006O17_A358CajCod, T006O17_A391MVLCajCod, T006O17_A392MVLITem
               }
               , new Object[] {
               T006O18_A358CajCod, T006O18_A391MVLCajCod, T006O18_A392MVLITem
               }
               , new Object[] {
               T006O19_A379LBBanCod, T006O19_A380LBCBCod, T006O19_A381LBRegistro, T006O19_A383LBDITem
               }
               , new Object[] {
               T006O20_A289OrdCod
               }
               , new Object[] {
               T006O21_A149TipCod, T006O21_A243ComCod, T006O21_A244PrvCod, T006O21_A250ComDItem, T006O21_A251ComDOrdCod
               }
               , new Object[] {
               T006O22_A2280CBTipPre, T006O22_A2281CBTipTipo, T006O22_A2282CBLinPre, T006O22_A2283CBRubPre, T006O22_A2284CBRubDItem
               }
               , new Object[] {
               T006O23_A2263CBFlujCAno, T006O23_A2264CBFlujCMes, T006O23_A2265CBFlujCBanCod, T006O23_A2266CBFlujCCuenta, T006O23_A2267CBFlujCRegistro, T006O23_A2268CBFlujCItem
               }
               , new Object[] {
               T006O24_A2100ACTActCod
               }
               , new Object[] {
               T006O25_A127VouAno, T006O25_A128VouMes, T006O25_A126TASICod, T006O25_A129VouNum, T006O25_A130VouDSec
               }
               , new Object[] {
               T006O26_A79COSCod
               }
            }
         );
         AV25Pgmname = "Contabilidad.CentroCosto";
         Z762COSSts = 1;
         A762COSSts = 1;
         i762COSSts = 1;
      }

      private short Z762COSSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A762COSSts ;
      private short Gx_BScreen ;
      private short RcdFound58 ;
      private short GX_JID ;
      private short nIsDirty_58 ;
      private short gxajaxcallmode ;
      private short i762COSSts ;
      private int trnEnded ;
      private int edtCOSCod_Enabled ;
      private int edtCOSDsc_Enabled ;
      private int edtCOSAbr_Enabled ;
      private int edtCOSCueDestino_Visible ;
      private int edtCOSCueDestino_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocoscuedestino_Visible ;
      private int edtavCombocoscuedestino_Enabled ;
      private int Combo_coscuedestino_Datalistupdateminimumcharacters ;
      private int Combo_coscuedestino_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7COSCod ;
      private string Z79COSCod ;
      private string Z761COSDsc ;
      private string Z759COSAbr ;
      private string Z80COSCueDestino ;
      private string N80COSCueDestino ;
      private string Combo_coscuedestino_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A80COSCueDestino ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7COSCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSCod_Internalname ;
      private string cmbCOSSts_Internalname ;
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
      private string A79COSCod ;
      private string edtCOSCod_Jsonclick ;
      private string edtCOSDsc_Internalname ;
      private string A761COSDsc ;
      private string edtCOSDsc_Jsonclick ;
      private string edtCOSAbr_Internalname ;
      private string A759COSAbr ;
      private string edtCOSAbr_Jsonclick ;
      private string divTablesplittedcoscuedestino_Internalname ;
      private string lblTextblockcoscuedestino_Internalname ;
      private string lblTextblockcoscuedestino_Jsonclick ;
      private string Combo_coscuedestino_Caption ;
      private string Combo_coscuedestino_Cls ;
      private string Combo_coscuedestino_Internalname ;
      private string edtCOSCueDestino_Internalname ;
      private string edtCOSCueDestino_Jsonclick ;
      private string cmbCOSSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_coscuedestino_Internalname ;
      private string edtavCombocoscuedestino_Internalname ;
      private string AV20ComboCOSCueDestino ;
      private string edtavCombocoscuedestino_Jsonclick ;
      private string AV13Insert_COSCueDestino ;
      private string A760CosCueDestinoDsc ;
      private string AV25Pgmname ;
      private string Combo_coscuedestino_Objectcall ;
      private string Combo_coscuedestino_Class ;
      private string Combo_coscuedestino_Icontype ;
      private string Combo_coscuedestino_Icon ;
      private string Combo_coscuedestino_Tooltip ;
      private string Combo_coscuedestino_Selectedvalue_set ;
      private string Combo_coscuedestino_Selectedtext_set ;
      private string Combo_coscuedestino_Selectedtext_get ;
      private string Combo_coscuedestino_Gamoauthtoken ;
      private string Combo_coscuedestino_Ddointernalname ;
      private string Combo_coscuedestino_Titlecontrolalign ;
      private string Combo_coscuedestino_Dropdownoptionstype ;
      private string Combo_coscuedestino_Titlecontrolidtoreplace ;
      private string Combo_coscuedestino_Datalisttype ;
      private string Combo_coscuedestino_Datalistfixedvalues ;
      private string Combo_coscuedestino_Datalistproc ;
      private string Combo_coscuedestino_Datalistprocparametersprefix ;
      private string Combo_coscuedestino_Htmltemplate ;
      private string Combo_coscuedestino_Multiplevaluestype ;
      private string Combo_coscuedestino_Loadingdata ;
      private string Combo_coscuedestino_Noresultsfound ;
      private string Combo_coscuedestino_Emptyitemtext ;
      private string Combo_coscuedestino_Onlyselectedvalues ;
      private string Combo_coscuedestino_Selectalltext ;
      private string Combo_coscuedestino_Multiplevaluesseparator ;
      private string Combo_coscuedestino_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode58 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string Z760CosCueDestinoDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n80COSCueDestino ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_coscuedestino_Enabled ;
      private bool Combo_coscuedestino_Visible ;
      private bool Combo_coscuedestino_Allowmultipleselection ;
      private bool Combo_coscuedestino_Isgriditem ;
      private bool Combo_coscuedestino_Hasdescription ;
      private bool Combo_coscuedestino_Includeonlyselectedoption ;
      private bool Combo_coscuedestino_Includeselectalloption ;
      private bool Combo_coscuedestino_Emptyitem ;
      private bool Combo_coscuedestino_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n79COSCod ;
      private bool returnInSub ;
      private string AV22SGAuDocGls ;
      private string AV23Codigo ;
      private string AV17ComboSelectedValue ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_coscuedestino ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCOSSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006O4_A760CosCueDestinoDsc ;
      private string[] T006O5_A79COSCod ;
      private bool[] T006O5_n79COSCod ;
      private string[] T006O5_A761COSDsc ;
      private string[] T006O5_A759COSAbr ;
      private short[] T006O5_A762COSSts ;
      private string[] T006O5_A760CosCueDestinoDsc ;
      private string[] T006O5_A80COSCueDestino ;
      private bool[] T006O5_n80COSCueDestino ;
      private string[] T006O6_A760CosCueDestinoDsc ;
      private string[] T006O7_A79COSCod ;
      private bool[] T006O7_n79COSCod ;
      private string[] T006O3_A79COSCod ;
      private bool[] T006O3_n79COSCod ;
      private string[] T006O3_A761COSDsc ;
      private string[] T006O3_A759COSAbr ;
      private short[] T006O3_A762COSSts ;
      private string[] T006O3_A80COSCueDestino ;
      private bool[] T006O3_n80COSCueDestino ;
      private string[] T006O8_A79COSCod ;
      private bool[] T006O8_n79COSCod ;
      private string[] T006O9_A79COSCod ;
      private bool[] T006O9_n79COSCod ;
      private string[] T006O2_A79COSCod ;
      private bool[] T006O2_n79COSCod ;
      private string[] T006O2_A761COSDsc ;
      private string[] T006O2_A759COSAbr ;
      private short[] T006O2_A762COSSts ;
      private string[] T006O2_A80COSCueDestino ;
      private bool[] T006O2_n80COSCueDestino ;
      private string[] T006O13_A760CosCueDestinoDsc ;
      private string[] T006O14_A2109AMovCod ;
      private int[] T006O15_A365EntCod ;
      private string[] T006O15_A403MVLEntCod ;
      private int[] T006O15_A404MVLEITem ;
      private int[] T006O16_A365EntCod ;
      private string[] T006O16_A403MVLEntCod ;
      private int[] T006O16_A404MVLEITem ;
      private int[] T006O17_A358CajCod ;
      private string[] T006O17_A391MVLCajCod ;
      private int[] T006O17_A392MVLITem ;
      private int[] T006O18_A358CajCod ;
      private string[] T006O18_A391MVLCajCod ;
      private int[] T006O18_A392MVLITem ;
      private int[] T006O19_A379LBBanCod ;
      private string[] T006O19_A380LBCBCod ;
      private string[] T006O19_A381LBRegistro ;
      private int[] T006O19_A383LBDITem ;
      private string[] T006O20_A289OrdCod ;
      private string[] T006O21_A149TipCod ;
      private string[] T006O21_A243ComCod ;
      private string[] T006O21_A244PrvCod ;
      private short[] T006O21_A250ComDItem ;
      private string[] T006O21_A251ComDOrdCod ;
      private int[] T006O22_A2280CBTipPre ;
      private string[] T006O22_A2281CBTipTipo ;
      private int[] T006O22_A2282CBLinPre ;
      private int[] T006O22_A2283CBRubPre ;
      private int[] T006O22_A2284CBRubDItem ;
      private short[] T006O23_A2263CBFlujCAno ;
      private short[] T006O23_A2264CBFlujCMes ;
      private int[] T006O23_A2265CBFlujCBanCod ;
      private string[] T006O23_A2266CBFlujCCuenta ;
      private string[] T006O23_A2267CBFlujCRegistro ;
      private int[] T006O23_A2268CBFlujCItem ;
      private string[] T006O24_A2100ACTActCod ;
      private short[] T006O25_A127VouAno ;
      private short[] T006O25_A128VouMes ;
      private int[] T006O25_A126TASICod ;
      private string[] T006O25_A129VouNum ;
      private int[] T006O25_A130VouDSec ;
      private string[] T006O26_A79COSCod ;
      private bool[] T006O26_n79COSCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15COSCueDestino_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class centrocosto__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class centrocosto__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006O5;
        prmT006O5 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O4;
        prmT006O4 = new Object[] {
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006O6;
        prmT006O6 = new Object[] {
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006O7;
        prmT006O7 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O3;
        prmT006O3 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O8;
        prmT006O8 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O9;
        prmT006O9 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O2;
        prmT006O2 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O10;
        prmT006O10 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@COSDsc",GXType.NChar,100,0) ,
        new ParDef("@COSAbr",GXType.NChar,5,0) ,
        new ParDef("@COSSts",GXType.Int16,1,0) ,
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006O11;
        prmT006O11 = new Object[] {
        new ParDef("@COSDsc",GXType.NChar,100,0) ,
        new ParDef("@COSAbr",GXType.NChar,5,0) ,
        new ParDef("@COSSts",GXType.Int16,1,0) ,
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O12;
        prmT006O12 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O14;
        prmT006O14 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O15;
        prmT006O15 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O16;
        prmT006O16 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O17;
        prmT006O17 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O18;
        prmT006O18 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O19;
        prmT006O19 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O20;
        prmT006O20 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O21;
        prmT006O21 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O22;
        prmT006O22 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O23;
        prmT006O23 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O24;
        prmT006O24 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O25;
        prmT006O25 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006O26;
        prmT006O26 = new Object[] {
        };
        Object[] prmT006O13;
        prmT006O13 = new Object[] {
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006O2", "SELECT [COSCod], [COSDsc], [COSAbr], [COSSts], [COSCueDestino] AS COSCueDestino FROM [CBCOSTOS] WITH (UPDLOCK) WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O3", "SELECT [COSCod], [COSDsc], [COSAbr], [COSSts], [COSCueDestino] AS COSCueDestino FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O4", "SELECT [CueDsc] AS CosCueDestinoDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @COSCueDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O5", "SELECT TM1.[COSCod], TM1.[COSDsc], TM1.[COSAbr], TM1.[COSSts], T2.[CueDsc] AS CosCueDestinoDsc, TM1.[COSCueDestino] AS COSCueDestino FROM ([CBCOSTOS] TM1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[COSCueDestino]) WHERE TM1.[COSCod] = @COSCod ORDER BY TM1.[COSCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006O5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O6", "SELECT [CueDsc] AS CosCueDestinoDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @COSCueDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O7", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O8", "SELECT TOP 1 [COSCod] FROM [CBCOSTOS] WHERE ( [COSCod] > @COSCod) ORDER BY [COSCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006O8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O9", "SELECT TOP 1 [COSCod] FROM [CBCOSTOS] WHERE ( [COSCod] < @COSCod) ORDER BY [COSCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006O9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O10", "INSERT INTO [CBCOSTOS]([COSCod], [COSDsc], [COSAbr], [COSSts], [COSCueDestino]) VALUES(@COSCod, @COSDsc, @COSAbr, @COSSts, @COSCueDestino)", GxErrorMask.GX_NOMASK,prmT006O10)
           ,new CursorDef("T006O11", "UPDATE [CBCOSTOS] SET [COSDsc]=@COSDsc, [COSAbr]=@COSAbr, [COSSts]=@COSSts, [COSCueDestino]=@COSCueDestino  WHERE [COSCod] = @COSCod", GxErrorMask.GX_NOMASK,prmT006O11)
           ,new CursorDef("T006O12", "DELETE FROM [CBCOSTOS]  WHERE [COSCod] = @COSCod", GxErrorMask.GX_NOMASK,prmT006O12)
           ,new CursorDef("T006O13", "SELECT [CueDsc] AS CosCueDestinoDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @COSCueDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006O14", "SELECT TOP 1 [AMovCod] FROM [ACTMOVACTIVO] WHERE [AMovCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O15", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEComCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O16", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLECosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O17", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLComCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O18", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O19", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBDCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O20", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [OrdCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O21", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O22", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O23", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O24", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O25", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006O25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006O26", "SELECT [COSCod] FROM [CBCOSTOS] ORDER BY [COSCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006O26,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 21 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 23 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
