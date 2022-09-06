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
   public class movimientoventa : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCMOVVCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACMOVVCOD5S105( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.movimientoventa.aspx")), "configuracion.movimientoventa.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.movimientoventa.aspx")))) ;
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
                  AV7MovVCod = (int)(NumberUtil.Val( GetPar( "MovVCod"), "."));
                  AssignAttri("", false, "AV7MovVCod", StringUtil.LTrimStr( (decimal)(AV7MovVCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMOVVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MovVCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Movimiento Venta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMovVDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public movimientoventa( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoventa( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MovVCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MovVCod = aP1_MovVCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMovVTip = new GXCombobox();
         cmbMovVSts = new GXCombobox();
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
         if ( cmbMovVTip.ItemCount > 0 )
         {
            A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
            AssignProp("", false, cmbMovVTip_Internalname, "Values", cmbMovVTip.ToJavascriptSource(), true);
         }
         if ( cmbMovVSts.ItemCount > 0 )
         {
            A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0))), "."));
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            AssignProp("", false, cmbMovVSts_Internalname, "Values", cmbMovVSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovVDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovVDsc_Internalname, "Movimiento Venta", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovVDsc_Internalname, StringUtil.RTrim( A1243MovVDsc), StringUtil.RTrim( context.localUtil.Format( A1243MovVDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovVDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtMovVDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoVenta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovVAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovVAbr_Internalname, "Afecta Unidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovVAbr_Internalname, StringUtil.RTrim( A1242MovVAbr), StringUtil.RTrim( context.localUtil.Format( A1242MovVAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovVAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovVAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoVenta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMovVTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMovVTip_Internalname, "Cargo / Abono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovVTip, cmbMovVTip_Internalname, StringUtil.RTrim( A1245MovVTip), 1, cmbMovVTip_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMovVTip.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Configuracion\\MovimientoVenta.htm");
         cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
         AssignProp("", false, cmbMovVTip_Internalname, "Values", (string)(cmbMovVTip.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMovVSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMovVSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovVSts, cmbMovVSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0)), 1, cmbMovVSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbMovVSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_Configuracion\\MovimientoVenta.htm");
         cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         AssignProp("", false, cmbMovVSts_Internalname, "Values", (string)(cmbMovVSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoVenta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoVenta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoVenta.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovVCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A235MovVCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovVCod_Jsonclick, 0, "Attribute", "", "", "", "", edtMovVCod_Visible, edtMovVCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\MovimientoVenta.htm");
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
         E115S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z235MovVCod = (int)(context.localUtil.CToN( cgiGet( "Z235MovVCod"), ".", ","));
               Z1243MovVDsc = cgiGet( "Z1243MovVDsc");
               Z1242MovVAbr = cgiGet( "Z1242MovVAbr");
               Z1245MovVTip = cgiGet( "Z1245MovVTip");
               Z1244MovVSts = (short)(context.localUtil.CToN( cgiGet( "Z1244MovVSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7MovVCod = (int)(context.localUtil.CToN( cgiGet( "vMOVVCOD"), ".", ","));
               AV11cMovVCod = (int)(context.localUtil.CToN( cgiGet( "vCMOVVCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
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
               A1243MovVDsc = cgiGet( edtMovVDsc_Internalname);
               AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
               A1242MovVAbr = cgiGet( edtMovVAbr_Internalname);
               AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
               cmbMovVTip.CurrentValue = cgiGet( cmbMovVTip_Internalname);
               A1245MovVTip = cgiGet( cmbMovVTip_Internalname);
               AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
               cmbMovVSts.CurrentValue = cgiGet( cmbMovVSts_Internalname);
               A1244MovVSts = (short)(NumberUtil.Val( cgiGet( cmbMovVSts_Internalname), "."));
               AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovVCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A235MovVCod = 0;
                  AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               }
               else
               {
                  A235MovVCod = (int)(context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ","));
                  AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MovimientoVenta");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A235MovVCod != Z235MovVCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\movimientoventa:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A235MovVCod = (int)(NumberUtil.Val( GetPar( "MovVCod"), "."));
                  AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
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
                     sMode105 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode105;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound105 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MOVVCOD");
                        AnyError = 1;
                        GX_FocusControl = edtMovVCod_Internalname;
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
                           E115S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125S2 ();
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
            E125S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5S105( ) ;
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
            DisableAttributes5S105( ) ;
         }
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

      protected void CONFIRM_5S0( )
      {
         BeforeValidate5S105( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5S105( ) ;
            }
            else
            {
               CheckExtendedTable5S105( ) ;
               CloseExtendedTableCursors5S105( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5S0( )
      {
      }

      protected void E115S2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtMovVCod_Visible = 0;
         AssignProp("", false, edtMovVCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMovVCod_Visible), 5, 0), true);
      }

      protected void E125S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV12SGAuDocGls = "Movimiento de Venta N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A235MovVCod), 10, 0)) + " " + StringUtil.Trim( A1243MovVDsc);
            AV13Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A235MovVCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV12SGAuDocGls, ref  AV13Codigo, ref  AV13Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.movimientoventaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5S105( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1243MovVDsc = T005S3_A1243MovVDsc[0];
               Z1242MovVAbr = T005S3_A1242MovVAbr[0];
               Z1245MovVTip = T005S3_A1245MovVTip[0];
               Z1244MovVSts = T005S3_A1244MovVSts[0];
            }
            else
            {
               Z1243MovVDsc = A1243MovVDsc;
               Z1242MovVAbr = A1242MovVAbr;
               Z1245MovVTip = A1245MovVTip;
               Z1244MovVSts = A1244MovVSts;
            }
         }
         if ( GX_JID == -10 )
         {
            Z235MovVCod = A235MovVCod;
            Z1243MovVDsc = A1243MovVDsc;
            Z1242MovVAbr = A1242MovVAbr;
            Z1245MovVTip = A1245MovVTip;
            Z1244MovVSts = A1244MovVSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MovVCod) )
         {
            A235MovVCod = AV7MovVCod;
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         }
         if ( ! (0==AV7MovVCod) )
         {
            edtMovVCod_Enabled = 0;
            AssignProp("", false, edtMovVCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVCod_Enabled), 5, 0), true);
         }
         else
         {
            edtMovVCod_Enabled = 1;
            AssignProp("", false, edtMovVCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MovVCod) )
         {
            edtMovVCod_Enabled = 0;
            AssignProp("", false, edtMovVCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1244MovVSts) && ( Gx_BScreen == 0 ) )
         {
            A1244MovVSts = 1;
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         }
      }

      protected void Load5S105( )
      {
         /* Using cursor T005S4 */
         pr_default.execute(2, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound105 = 1;
            A1243MovVDsc = T005S4_A1243MovVDsc[0];
            AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
            A1242MovVAbr = T005S4_A1242MovVAbr[0];
            AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
            A1245MovVTip = T005S4_A1245MovVTip[0];
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
            A1244MovVSts = T005S4_A1244MovVSts[0];
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            ZM5S105( -10) ;
         }
         pr_default.close(2);
         OnLoadActions5S105( ) ;
      }

      protected void OnLoadActions5S105( )
      {
      }

      protected void CheckExtendedTable5S105( )
      {
         nIsDirty_105 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1243MovVDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripción Mov. Venta", "", "", "", "", "", "", "", ""), 1, "MOVVDSC");
            AnyError = 1;
            GX_FocusControl = edtMovVDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1242MovVAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura Mov. Venta", "", "", "", "", "", "", "", ""), 1, "MOVVABR");
            AnyError = 1;
            GX_FocusControl = edtMovVAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1245MovVTip)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cargo / Abono", "", "", "", "", "", "", "", ""), 1, "MOVVTIP");
            AnyError = 1;
            GX_FocusControl = cmbMovVTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5S105( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5S105( )
      {
         /* Using cursor T005S5 */
         pr_default.execute(3, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound105 = 1;
         }
         else
         {
            RcdFound105 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005S3 */
         pr_default.execute(1, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5S105( 10) ;
            RcdFound105 = 1;
            A235MovVCod = T005S3_A235MovVCod[0];
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
            A1243MovVDsc = T005S3_A1243MovVDsc[0];
            AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
            A1242MovVAbr = T005S3_A1242MovVAbr[0];
            AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
            A1245MovVTip = T005S3_A1245MovVTip[0];
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
            A1244MovVSts = T005S3_A1244MovVSts[0];
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            Z235MovVCod = A235MovVCod;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5S105( ) ;
            if ( AnyError == 1 )
            {
               RcdFound105 = 0;
               InitializeNonKey5S105( ) ;
            }
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound105 = 0;
            InitializeNonKey5S105( ) ;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5S105( ) ;
         if ( RcdFound105 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound105 = 0;
         /* Using cursor T005S6 */
         pr_default.execute(4, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005S6_A235MovVCod[0] < A235MovVCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005S6_A235MovVCod[0] > A235MovVCod ) ) )
            {
               A235MovVCod = T005S6_A235MovVCod[0];
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               RcdFound105 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound105 = 0;
         /* Using cursor T005S7 */
         pr_default.execute(5, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005S7_A235MovVCod[0] > A235MovVCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005S7_A235MovVCod[0] < A235MovVCod ) ) )
            {
               A235MovVCod = T005S7_A235MovVCod[0];
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               RcdFound105 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5S105( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMovVDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5S105( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound105 == 1 )
            {
               if ( A235MovVCod != Z235MovVCod )
               {
                  A235MovVCod = Z235MovVCod;
                  AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MOVVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovVCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMovVDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5S105( ) ;
                  GX_FocusControl = edtMovVDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A235MovVCod != Z235MovVCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtMovVDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5S105( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtMovVCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMovVDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5S105( ) ;
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
         if ( A235MovVCod != Z235MovVCod )
         {
            A235MovVCod = Z235MovVCod;
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MOVVCOD");
            AnyError = 1;
            GX_FocusControl = edtMovVCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMovVDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5S105( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005S2 */
            pr_default.execute(0, new Object[] {A235MovVCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVVENTAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1243MovVDsc, T005S2_A1243MovVDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1242MovVAbr, T005S2_A1242MovVAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z1245MovVTip, T005S2_A1245MovVTip[0]) != 0 ) || ( Z1244MovVSts != T005S2_A1244MovVSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1243MovVDsc, T005S2_A1243MovVDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.movimientoventa:[seudo value changed for attri]"+"MovVDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1243MovVDsc);
                  GXUtil.WriteLogRaw("Current: ",T005S2_A1243MovVDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1242MovVAbr, T005S2_A1242MovVAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.movimientoventa:[seudo value changed for attri]"+"MovVAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1242MovVAbr);
                  GXUtil.WriteLogRaw("Current: ",T005S2_A1242MovVAbr[0]);
               }
               if ( StringUtil.StrCmp(Z1245MovVTip, T005S2_A1245MovVTip[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.movimientoventa:[seudo value changed for attri]"+"MovVTip");
                  GXUtil.WriteLogRaw("Old: ",Z1245MovVTip);
                  GXUtil.WriteLogRaw("Current: ",T005S2_A1245MovVTip[0]);
               }
               if ( Z1244MovVSts != T005S2_A1244MovVSts[0] )
               {
                  GXUtil.WriteLog("configuracion.movimientoventa:[seudo value changed for attri]"+"MovVSts");
                  GXUtil.WriteLogRaw("Old: ",Z1244MovVSts);
                  GXUtil.WriteLogRaw("Current: ",T005S2_A1244MovVSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CMOVVENTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5S105( )
      {
         BeforeValidate5S105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5S105( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5S105( 0) ;
            CheckOptimisticConcurrency5S105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5S105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5S105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005S8 */
                     pr_default.execute(6, new Object[] {A235MovVCod, A1243MovVDsc, A1242MovVAbr, A1245MovVTip, A1244MovVSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVVENTAS");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption5S0( ) ;
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
               Load5S105( ) ;
            }
            EndLevel5S105( ) ;
         }
         CloseExtendedTableCursors5S105( ) ;
      }

      protected void Update5S105( )
      {
         BeforeValidate5S105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5S105( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5S105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5S105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5S105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005S9 */
                     pr_default.execute(7, new Object[] {A1243MovVDsc, A1242MovVAbr, A1245MovVTip, A1244MovVSts, A235MovVCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVVENTAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVVENTAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5S105( ) ;
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
            EndLevel5S105( ) ;
         }
         CloseExtendedTableCursors5S105( ) ;
      }

      protected void DeferredUpdate5S105( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5S105( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5S105( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5S105( ) ;
            AfterConfirm5S105( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5S105( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005S10 */
                  pr_default.execute(8, new Object[] {A235MovVCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CMOVVENTAS");
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
         sMode105 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5S105( ) ;
         Gx_mode = sMode105;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5S105( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005S11 */
            pr_default.execute(9, new Object[] {A235MovVCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel5S105( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5S105( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.movimientoventa",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.movimientoventa",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5S105( )
      {
         /* Scan By routine */
         /* Using cursor T005S12 */
         pr_default.execute(10);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound105 = 1;
            A235MovVCod = T005S12_A235MovVCod[0];
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5S105( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound105 = 1;
            A235MovVCod = T005S12_A235MovVCod[0];
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         }
      }

      protected void ScanEnd5S105( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm5S105( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV11cMovVCod;
            GXt_char3 = "MOVVENTAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV11cMovVCod = (int)(GXt_int4);
            AssignAttri("", false, "AV11cMovVCod", StringUtil.LTrimStr( (decimal)(AV11cMovVCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A235MovVCod = AV11cMovVCod;
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         }
      }

      protected void BeforeInsert5S105( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5S105( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5S105( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5S105( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5S105( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5S105( )
      {
         edtMovVDsc_Enabled = 0;
         AssignProp("", false, edtMovVDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVDsc_Enabled), 5, 0), true);
         edtMovVAbr_Enabled = 0;
         AssignProp("", false, edtMovVAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVAbr_Enabled), 5, 0), true);
         cmbMovVTip.Enabled = 0;
         AssignProp("", false, cmbMovVTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovVTip.Enabled), 5, 0), true);
         cmbMovVSts.Enabled = 0;
         AssignProp("", false, cmbMovVSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovVSts.Enabled), 5, 0), true);
         edtMovVCod_Enabled = 0;
         AssignProp("", false, edtMovVCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5S105( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5S0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026136", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "configuracion.movimientoventa.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MovVCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.movimientoventa.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MovimientoVenta");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\movimientoventa:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z235MovVCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z235MovVCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1243MovVDsc", StringUtil.RTrim( Z1243MovVDsc));
         GxWebStd.gx_hidden_field( context, "Z1242MovVAbr", StringUtil.RTrim( Z1242MovVAbr));
         GxWebStd.gx_hidden_field( context, "Z1245MovVTip", StringUtil.RTrim( Z1245MovVTip));
         GxWebStd.gx_hidden_field( context, "Z1244MovVSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1244MovVSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vMOVVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MovVCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMOVVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MovVCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCMOVVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cMovVCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.movimientoventa.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MovVCod,6,0));
         return formatLink("configuracion.movimientoventa.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.MovimientoVenta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimiento Venta" ;
      }

      protected void InitializeNonKey5S105( )
      {
         AV11cMovVCod = 0;
         AssignAttri("", false, "AV11cMovVCod", StringUtil.LTrimStr( (decimal)(AV11cMovVCod), 6, 0));
         A1243MovVDsc = "";
         AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
         A1242MovVAbr = "";
         AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
         A1245MovVTip = "";
         AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
         A1244MovVSts = 1;
         AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         Z1243MovVDsc = "";
         Z1242MovVAbr = "";
         Z1245MovVTip = "";
         Z1244MovVSts = 0;
      }

      protected void InitAll5S105( )
      {
         A235MovVCod = 0;
         AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         InitializeNonKey5S105( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1244MovVSts = i1244MovVSts;
         AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261323", true, true);
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
         context.AddJavascriptSource("configuracion/movimientoventa.js", "?202281810261323", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMovVDsc_Internalname = "MOVVDSC";
         edtMovVAbr_Internalname = "MOVVABR";
         cmbMovVTip_Internalname = "MOVVTIP";
         cmbMovVSts_Internalname = "MOVVSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtMovVCod_Internalname = "MOVVCOD";
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
         Form.Caption = "Movimiento Venta";
         edtMovVCod_Jsonclick = "";
         edtMovVCod_Enabled = 1;
         edtMovVCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbMovVSts_Jsonclick = "";
         cmbMovVSts.Enabled = 1;
         cmbMovVTip_Jsonclick = "";
         cmbMovVTip.Enabled = 1;
         edtMovVAbr_Jsonclick = "";
         edtMovVAbr_Enabled = 1;
         edtMovVDsc_Jsonclick = "";
         edtMovVDsc_Enabled = 1;
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

      protected void GX4ASACMOVVCOD5S105( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV11cMovVCod;
            GXt_char3 = "MOVVENTAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV11cMovVCod = (int)(GXt_int4);
            AssignAttri("", false, "AV11cMovVCod", StringUtil.LTrimStr( (decimal)(AV11cMovVCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cMovVCod), 6, 0, ".", "")))+"\"") ;
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
         cmbMovVTip.Name = "MOVVTIP";
         cmbMovVTip.WebTags = "";
         cmbMovVTip.addItem("C", "Credito", 0);
         cmbMovVTip.addItem("D", "Debito", 0);
         if ( cmbMovVTip.ItemCount > 0 )
         {
            A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
         }
         cmbMovVSts.Name = "MOVVSTS";
         cmbMovVSts.WebTags = "";
         cmbMovVSts.addItem("1", "ACTIVO", 0);
         cmbMovVSts.addItem("0", "INACTIVO", 0);
         if ( cmbMovVSts.ItemCount > 0 )
         {
            if ( (0==A1244MovVSts) )
            {
               A1244MovVSts = 1;
               AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MovVCod',fld:'vMOVVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MovVCod',fld:'vMOVVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125S2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A235MovVCod',fld:'MOVVCOD',pic:'ZZZZZ9'},{av:'A1243MovVDsc',fld:'MOVVDSC',pic:''},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MOVVDSC","{handler:'Valid_Movvdsc',iparms:[]");
         setEventMetadata("VALID_MOVVDSC",",oparms:[]}");
         setEventMetadata("VALID_MOVVABR","{handler:'Valid_Movvabr',iparms:[]");
         setEventMetadata("VALID_MOVVABR",",oparms:[]}");
         setEventMetadata("VALID_MOVVTIP","{handler:'Valid_Movvtip',iparms:[]");
         setEventMetadata("VALID_MOVVTIP",",oparms:[]}");
         setEventMetadata("VALID_MOVVCOD","{handler:'Valid_Movvcod',iparms:[]");
         setEventMetadata("VALID_MOVVCOD",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1243MovVDsc = "";
         Z1242MovVAbr = "";
         Z1245MovVTip = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1245MovVTip = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A1243MovVDsc = "";
         A1242MovVAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode105 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12SGAuDocGls = "";
         AV13Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T005S4_A235MovVCod = new int[1] ;
         T005S4_A1243MovVDsc = new string[] {""} ;
         T005S4_A1242MovVAbr = new string[] {""} ;
         T005S4_A1245MovVTip = new string[] {""} ;
         T005S4_A1244MovVSts = new short[1] ;
         T005S5_A235MovVCod = new int[1] ;
         T005S3_A235MovVCod = new int[1] ;
         T005S3_A1243MovVDsc = new string[] {""} ;
         T005S3_A1242MovVAbr = new string[] {""} ;
         T005S3_A1245MovVTip = new string[] {""} ;
         T005S3_A1244MovVSts = new short[1] ;
         T005S6_A235MovVCod = new int[1] ;
         T005S7_A235MovVCod = new int[1] ;
         T005S2_A235MovVCod = new int[1] ;
         T005S2_A1243MovVDsc = new string[] {""} ;
         T005S2_A1242MovVAbr = new string[] {""} ;
         T005S2_A1245MovVTip = new string[] {""} ;
         T005S2_A1244MovVSts = new short[1] ;
         T005S11_A149TipCod = new string[] {""} ;
         T005S11_A24DocNum = new string[] {""} ;
         T005S12_A235MovVCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoventa__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoventa__default(),
            new Object[][] {
                new Object[] {
               T005S2_A235MovVCod, T005S2_A1243MovVDsc, T005S2_A1242MovVAbr, T005S2_A1245MovVTip, T005S2_A1244MovVSts
               }
               , new Object[] {
               T005S3_A235MovVCod, T005S3_A1243MovVDsc, T005S3_A1242MovVAbr, T005S3_A1245MovVTip, T005S3_A1244MovVSts
               }
               , new Object[] {
               T005S4_A235MovVCod, T005S4_A1243MovVDsc, T005S4_A1242MovVAbr, T005S4_A1245MovVTip, T005S4_A1244MovVSts
               }
               , new Object[] {
               T005S5_A235MovVCod
               }
               , new Object[] {
               T005S6_A235MovVCod
               }
               , new Object[] {
               T005S7_A235MovVCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005S11_A149TipCod, T005S11_A24DocNum
               }
               , new Object[] {
               T005S12_A235MovVCod
               }
            }
         );
         Z1244MovVSts = 1;
         A1244MovVSts = 1;
         i1244MovVSts = 1;
      }

      private short Z1244MovVSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1244MovVSts ;
      private short Gx_BScreen ;
      private short RcdFound105 ;
      private short GX_JID ;
      private short nIsDirty_105 ;
      private short gxajaxcallmode ;
      private short i1244MovVSts ;
      private int wcpOAV7MovVCod ;
      private int Z235MovVCod ;
      private int AV7MovVCod ;
      private int trnEnded ;
      private int edtMovVDsc_Enabled ;
      private int edtMovVAbr_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A235MovVCod ;
      private int edtMovVCod_Visible ;
      private int edtMovVCod_Enabled ;
      private int AV11cMovVCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1243MovVDsc ;
      private string Z1242MovVAbr ;
      private string Z1245MovVTip ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMovVDsc_Internalname ;
      private string A1245MovVTip ;
      private string cmbMovVTip_Internalname ;
      private string cmbMovVSts_Internalname ;
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
      private string A1243MovVDsc ;
      private string edtMovVDsc_Jsonclick ;
      private string edtMovVAbr_Internalname ;
      private string A1242MovVAbr ;
      private string edtMovVAbr_Jsonclick ;
      private string cmbMovVTip_Jsonclick ;
      private string cmbMovVSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMovVCod_Internalname ;
      private string edtMovVCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode105 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
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
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV12SGAuDocGls ;
      private string AV13Codigo ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMovVTip ;
      private GXCombobox cmbMovVSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005S4_A235MovVCod ;
      private string[] T005S4_A1243MovVDsc ;
      private string[] T005S4_A1242MovVAbr ;
      private string[] T005S4_A1245MovVTip ;
      private short[] T005S4_A1244MovVSts ;
      private int[] T005S5_A235MovVCod ;
      private int[] T005S3_A235MovVCod ;
      private string[] T005S3_A1243MovVDsc ;
      private string[] T005S3_A1242MovVAbr ;
      private string[] T005S3_A1245MovVTip ;
      private short[] T005S3_A1244MovVSts ;
      private int[] T005S6_A235MovVCod ;
      private int[] T005S7_A235MovVCod ;
      private int[] T005S2_A235MovVCod ;
      private string[] T005S2_A1243MovVDsc ;
      private string[] T005S2_A1242MovVAbr ;
      private string[] T005S2_A1245MovVTip ;
      private short[] T005S2_A1244MovVSts ;
      private string[] T005S11_A149TipCod ;
      private string[] T005S11_A24DocNum ;
      private int[] T005S12_A235MovVCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class movimientoventa__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class movimientoventa__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005S4;
        prmT005S4 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S5;
        prmT005S5 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S3;
        prmT005S3 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S6;
        prmT005S6 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S7;
        prmT005S7 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S2;
        prmT005S2 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S8;
        prmT005S8 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0) ,
        new ParDef("@MovVDsc",GXType.NChar,100,0) ,
        new ParDef("@MovVAbr",GXType.NChar,5,0) ,
        new ParDef("@MovVTip",GXType.NChar,1,0) ,
        new ParDef("@MovVSts",GXType.Int16,1,0)
        };
        Object[] prmT005S9;
        prmT005S9 = new Object[] {
        new ParDef("@MovVDsc",GXType.NChar,100,0) ,
        new ParDef("@MovVAbr",GXType.NChar,5,0) ,
        new ParDef("@MovVTip",GXType.NChar,1,0) ,
        new ParDef("@MovVSts",GXType.Int16,1,0) ,
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S10;
        prmT005S10 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S11;
        prmT005S11 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT005S12;
        prmT005S12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005S2", "SELECT [MovVCod], [MovVDsc], [MovVAbr], [MovVTip], [MovVSts] FROM [CMOVVENTAS] WITH (UPDLOCK) WHERE [MovVCod] = @MovVCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005S3", "SELECT [MovVCod], [MovVDsc], [MovVAbr], [MovVTip], [MovVSts] FROM [CMOVVENTAS] WHERE [MovVCod] = @MovVCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005S4", "SELECT TM1.[MovVCod], TM1.[MovVDsc], TM1.[MovVAbr], TM1.[MovVTip], TM1.[MovVSts] FROM [CMOVVENTAS] TM1 WHERE TM1.[MovVCod] = @MovVCod ORDER BY TM1.[MovVCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005S4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005S5", "SELECT [MovVCod] FROM [CMOVVENTAS] WHERE [MovVCod] = @MovVCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005S6", "SELECT TOP 1 [MovVCod] FROM [CMOVVENTAS] WHERE ( [MovVCod] > @MovVCod) ORDER BY [MovVCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005S6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005S7", "SELECT TOP 1 [MovVCod] FROM [CMOVVENTAS] WHERE ( [MovVCod] < @MovVCod) ORDER BY [MovVCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005S7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005S8", "INSERT INTO [CMOVVENTAS]([MovVCod], [MovVDsc], [MovVAbr], [MovVTip], [MovVSts]) VALUES(@MovVCod, @MovVDsc, @MovVAbr, @MovVTip, @MovVSts)", GxErrorMask.GX_NOMASK,prmT005S8)
           ,new CursorDef("T005S9", "UPDATE [CMOVVENTAS] SET [MovVDsc]=@MovVDsc, [MovVAbr]=@MovVAbr, [MovVTip]=@MovVTip, [MovVSts]=@MovVSts  WHERE [MovVCod] = @MovVCod", GxErrorMask.GX_NOMASK,prmT005S9)
           ,new CursorDef("T005S10", "DELETE FROM [CMOVVENTAS]  WHERE [MovVCod] = @MovVCod", GxErrorMask.GX_NOMASK,prmT005S10)
           ,new CursorDef("T005S11", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocMovCod] = @MovVCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005S11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005S12", "SELECT [MovVCod] FROM [CMOVVENTAS] ORDER BY [MovVCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005S12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
