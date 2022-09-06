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
   public class movimientoalmacen : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCMOVCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACMOVCOD5R104( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.movimientoalmacen.aspx")), "configuracion.movimientoalmacen.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.movimientoalmacen.aspx")))) ;
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
                  AV7MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
                  AssignAttri("", false, "AV7MovCod", StringUtil.LTrimStr( (decimal)(AV7MovCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMOVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MovCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Movimiento Almacen", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMovDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public movimientoalmacen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoalmacen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MovCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MovCod = aP1_MovCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMovSts = new GXCombobox();
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
         if ( cmbMovSts.ItemCount > 0 )
         {
            A1240MovSts = (short)(NumberUtil.Val( cmbMovSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0))), "."));
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            AssignProp("", false, cmbMovSts_Internalname, "Values", cmbMovSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovDsc_Internalname, "Movimiento Almacen", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovDsc_Internalname, StringUtil.RTrim( A1239MovDsc), StringUtil.RTrim( context.localUtil.Format( A1239MovDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoAlmacen.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovAbr_Internalname, "Codigo Sunat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovAbr_Internalname, StringUtil.RTrim( A1237MovAbr), StringUtil.RTrim( context.localUtil.Format( A1237MovAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\MovimientoAlmacen.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovTip_Internalname, "Tipo Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovTip_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1241MovTip), 1, 0, ".", "")), StringUtil.LTrim( ((edtMovTip_Enabled!=0) ? context.localUtil.Format( (decimal)(A1241MovTip), "9") : context.localUtil.Format( (decimal)(A1241MovTip), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovTip_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\MovimientoAlmacen.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMovSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMovSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovSts, cmbMovSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0)), 1, cmbMovSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbMovSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_Configuracion\\MovimientoAlmacen.htm");
         cmbMovSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         AssignProp("", false, cmbMovSts_Internalname, "Values", (string)(cmbMovSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoAlmacen.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoAlmacen.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\MovimientoAlmacen.htm");
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
         GxWebStd.gx_single_line_edit( context, edtMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A234MovCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A234MovCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovCod_Jsonclick, 0, "Attribute", "", "", "", "", edtMovCod_Visible, edtMovCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\MovimientoAlmacen.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1238MovAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtMovAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A1238MovAut), "9") : context.localUtil.Format( (decimal)(A1238MovAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovAut_Jsonclick, 0, "Attribute", "", "", "", "", edtMovAut_Visible, edtMovAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\MovimientoAlmacen.htm");
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
         E115R2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z234MovCod = (int)(context.localUtil.CToN( cgiGet( "Z234MovCod"), ".", ","));
               Z1239MovDsc = cgiGet( "Z1239MovDsc");
               Z1237MovAbr = cgiGet( "Z1237MovAbr");
               Z1241MovTip = (short)(context.localUtil.CToN( cgiGet( "Z1241MovTip"), ".", ","));
               Z1240MovSts = (short)(context.localUtil.CToN( cgiGet( "Z1240MovSts"), ".", ","));
               Z1238MovAut = (short)(context.localUtil.CToN( cgiGet( "Z1238MovAut"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7MovCod = (int)(context.localUtil.CToN( cgiGet( "vMOVCOD"), ".", ","));
               AV13cMovCod = (int)(context.localUtil.CToN( cgiGet( "vCMOVCOD"), ".", ","));
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
               A1239MovDsc = cgiGet( edtMovDsc_Internalname);
               AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
               A1237MovAbr = cgiGet( edtMovAbr_Internalname);
               AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMovTip_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovTip_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVTIP");
                  AnyError = 1;
                  GX_FocusControl = edtMovTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1241MovTip = 0;
                  AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
               }
               else
               {
                  A1241MovTip = (short)(context.localUtil.CToN( cgiGet( edtMovTip_Internalname), ".", ","));
                  AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
               }
               cmbMovSts.CurrentValue = cgiGet( cmbMovSts_Internalname);
               A1240MovSts = (short)(NumberUtil.Val( cgiGet( cmbMovSts_Internalname), "."));
               AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A234MovCod = 0;
                  AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               }
               else
               {
                  A234MovCod = (int)(context.localUtil.CToN( cgiGet( edtMovCod_Internalname), ".", ","));
                  AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMovAut_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovAut_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVAUT");
                  AnyError = 1;
                  GX_FocusControl = edtMovAut_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1238MovAut = 0;
                  AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
               }
               else
               {
                  A1238MovAut = (short)(context.localUtil.CToN( cgiGet( edtMovAut_Internalname), ".", ","));
                  AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MovimientoAlmacen");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A234MovCod != Z234MovCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\movimientoalmacen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A234MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
                  AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
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
                     sMode104 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode104;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound104 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5R0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MOVCOD");
                        AnyError = 1;
                        GX_FocusControl = edtMovCod_Internalname;
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
                           E115R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125R2 ();
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
            E125R2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5R104( ) ;
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
            DisableAttributes5R104( ) ;
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

      protected void CONFIRM_5R0( )
      {
         BeforeValidate5R104( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5R104( ) ;
            }
            else
            {
               CheckExtendedTable5R104( ) ;
               CloseExtendedTableCursors5R104( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5R0( )
      {
      }

      protected void E115R2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtMovCod_Visible = 0;
         AssignProp("", false, edtMovCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMovCod_Visible), 5, 0), true);
         edtMovAut_Visible = 0;
         AssignProp("", false, edtMovAut_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMovAut_Visible), 5, 0), true);
      }

      protected void E125R2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Movimiento de almacen N� " + StringUtil.Trim( StringUtil.Str( (decimal)(A234MovCod), 10, 0)) + " " + StringUtil.Trim( A1239MovDsc);
            AV15Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A234MovCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminaci�n";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV15Codigo, ref  AV15Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.movimientoalmacenww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5R104( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1239MovDsc = T005R3_A1239MovDsc[0];
               Z1237MovAbr = T005R3_A1237MovAbr[0];
               Z1241MovTip = T005R3_A1241MovTip[0];
               Z1240MovSts = T005R3_A1240MovSts[0];
               Z1238MovAut = T005R3_A1238MovAut[0];
            }
            else
            {
               Z1239MovDsc = A1239MovDsc;
               Z1237MovAbr = A1237MovAbr;
               Z1241MovTip = A1241MovTip;
               Z1240MovSts = A1240MovSts;
               Z1238MovAut = A1238MovAut;
            }
         }
         if ( GX_JID == -10 )
         {
            Z234MovCod = A234MovCod;
            Z1239MovDsc = A1239MovDsc;
            Z1237MovAbr = A1237MovAbr;
            Z1241MovTip = A1241MovTip;
            Z1240MovSts = A1240MovSts;
            Z1238MovAut = A1238MovAut;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MovCod) )
         {
            A234MovCod = AV7MovCod;
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         }
         if ( ! (0==AV7MovCod) )
         {
            edtMovCod_Enabled = 0;
            AssignProp("", false, edtMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovCod_Enabled), 5, 0), true);
         }
         else
         {
            edtMovCod_Enabled = 1;
            AssignProp("", false, edtMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MovCod) )
         {
            edtMovCod_Enabled = 0;
            AssignProp("", false, edtMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1240MovSts) && ( Gx_BScreen == 0 ) )
         {
            A1240MovSts = 1;
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         }
      }

      protected void Load5R104( )
      {
         /* Using cursor T005R4 */
         pr_default.execute(2, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound104 = 1;
            A1239MovDsc = T005R4_A1239MovDsc[0];
            AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
            A1237MovAbr = T005R4_A1237MovAbr[0];
            AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
            A1241MovTip = T005R4_A1241MovTip[0];
            AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
            A1240MovSts = T005R4_A1240MovSts[0];
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            A1238MovAut = T005R4_A1238MovAut[0];
            AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
            ZM5R104( -10) ;
         }
         pr_default.close(2);
         OnLoadActions5R104( ) ;
      }

      protected void OnLoadActions5R104( )
      {
      }

      protected void CheckExtendedTable5R104( )
      {
         nIsDirty_104 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1239MovDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripcion Movimiento", "", "", "", "", "", "", "", ""), 1, "MOVDSC");
            AnyError = 1;
            GX_FocusControl = edtMovDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1237MovAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura Movimiento", "", "", "", "", "", "", "", ""), 1, "MOVABR");
            AnyError = 1;
            GX_FocusControl = edtMovAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A1241MovTip) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo Mov. Almacen", "", "", "", "", "", "", "", ""), 1, "MOVTIP");
            AnyError = 1;
            GX_FocusControl = edtMovTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5R104( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5R104( )
      {
         /* Using cursor T005R5 */
         pr_default.execute(3, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound104 = 1;
         }
         else
         {
            RcdFound104 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005R3 */
         pr_default.execute(1, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5R104( 10) ;
            RcdFound104 = 1;
            A234MovCod = T005R3_A234MovCod[0];
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
            A1239MovDsc = T005R3_A1239MovDsc[0];
            AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
            A1237MovAbr = T005R3_A1237MovAbr[0];
            AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
            A1241MovTip = T005R3_A1241MovTip[0];
            AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
            A1240MovSts = T005R3_A1240MovSts[0];
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            A1238MovAut = T005R3_A1238MovAut[0];
            AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
            Z234MovCod = A234MovCod;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5R104( ) ;
            if ( AnyError == 1 )
            {
               RcdFound104 = 0;
               InitializeNonKey5R104( ) ;
            }
            Gx_mode = sMode104;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound104 = 0;
            InitializeNonKey5R104( ) ;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode104;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5R104( ) ;
         if ( RcdFound104 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound104 = 0;
         /* Using cursor T005R6 */
         pr_default.execute(4, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005R6_A234MovCod[0] < A234MovCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005R6_A234MovCod[0] > A234MovCod ) ) )
            {
               A234MovCod = T005R6_A234MovCod[0];
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               RcdFound104 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound104 = 0;
         /* Using cursor T005R7 */
         pr_default.execute(5, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005R7_A234MovCod[0] > A234MovCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005R7_A234MovCod[0] < A234MovCod ) ) )
            {
               A234MovCod = T005R7_A234MovCod[0];
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               RcdFound104 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5R104( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMovDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5R104( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound104 == 1 )
            {
               if ( A234MovCod != Z234MovCod )
               {
                  A234MovCod = Z234MovCod;
                  AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMovDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5R104( ) ;
                  GX_FocusControl = edtMovDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A234MovCod != Z234MovCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtMovDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5R104( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMovDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5R104( ) ;
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
         if ( A234MovCod != Z234MovCod )
         {
            A234MovCod = Z234MovCod;
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MOVCOD");
            AnyError = 1;
            GX_FocusControl = edtMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMovDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5R104( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005R2 */
            pr_default.execute(0, new Object[] {A234MovCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVALMACEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1239MovDsc, T005R2_A1239MovDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1237MovAbr, T005R2_A1237MovAbr[0]) != 0 ) || ( Z1241MovTip != T005R2_A1241MovTip[0] ) || ( Z1240MovSts != T005R2_A1240MovSts[0] ) || ( Z1238MovAut != T005R2_A1238MovAut[0] ) )
            {
               if ( StringUtil.StrCmp(Z1239MovDsc, T005R2_A1239MovDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.movimientoalmacen:[seudo value changed for attri]"+"MovDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1239MovDsc);
                  GXUtil.WriteLogRaw("Current: ",T005R2_A1239MovDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1237MovAbr, T005R2_A1237MovAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.movimientoalmacen:[seudo value changed for attri]"+"MovAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1237MovAbr);
                  GXUtil.WriteLogRaw("Current: ",T005R2_A1237MovAbr[0]);
               }
               if ( Z1241MovTip != T005R2_A1241MovTip[0] )
               {
                  GXUtil.WriteLog("configuracion.movimientoalmacen:[seudo value changed for attri]"+"MovTip");
                  GXUtil.WriteLogRaw("Old: ",Z1241MovTip);
                  GXUtil.WriteLogRaw("Current: ",T005R2_A1241MovTip[0]);
               }
               if ( Z1240MovSts != T005R2_A1240MovSts[0] )
               {
                  GXUtil.WriteLog("configuracion.movimientoalmacen:[seudo value changed for attri]"+"MovSts");
                  GXUtil.WriteLogRaw("Old: ",Z1240MovSts);
                  GXUtil.WriteLogRaw("Current: ",T005R2_A1240MovSts[0]);
               }
               if ( Z1238MovAut != T005R2_A1238MovAut[0] )
               {
                  GXUtil.WriteLog("configuracion.movimientoalmacen:[seudo value changed for attri]"+"MovAut");
                  GXUtil.WriteLogRaw("Old: ",Z1238MovAut);
                  GXUtil.WriteLogRaw("Current: ",T005R2_A1238MovAut[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CMOVALMACEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5R104( )
      {
         BeforeValidate5R104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5R104( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5R104( 0) ;
            CheckOptimisticConcurrency5R104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5R104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5R104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005R8 */
                     pr_default.execute(6, new Object[] {A234MovCod, A1239MovDsc, A1237MovAbr, A1241MovTip, A1240MovSts, A1238MovAut});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVALMACEN");
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
                           ResetCaption5R0( ) ;
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
               Load5R104( ) ;
            }
            EndLevel5R104( ) ;
         }
         CloseExtendedTableCursors5R104( ) ;
      }

      protected void Update5R104( )
      {
         BeforeValidate5R104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5R104( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5R104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5R104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5R104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005R9 */
                     pr_default.execute(7, new Object[] {A1239MovDsc, A1237MovAbr, A1241MovTip, A1240MovSts, A1238MovAut, A234MovCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVALMACEN");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVALMACEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5R104( ) ;
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
            EndLevel5R104( ) ;
         }
         CloseExtendedTableCursors5R104( ) ;
      }

      protected void DeferredUpdate5R104( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5R104( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5R104( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5R104( ) ;
            AfterConfirm5R104( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5R104( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005R10 */
                  pr_default.execute(8, new Object[] {A234MovCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CMOVALMACEN");
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
         sMode104 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5R104( ) ;
         Gx_mode = sMode104;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5R104( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005R11 */
            pr_default.execute(9, new Object[] {A234MovCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005R12 */
            pr_default.execute(10, new Object[] {A234MovCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel5R104( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5R104( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.movimientoalmacen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.movimientoalmacen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5R104( )
      {
         /* Scan By routine */
         /* Using cursor T005R13 */
         pr_default.execute(11);
         RcdFound104 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound104 = 1;
            A234MovCod = T005R13_A234MovCod[0];
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5R104( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound104 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound104 = 1;
            A234MovCod = T005R13_A234MovCod[0];
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         }
      }

      protected void ScanEnd5R104( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm5R104( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cMovCod;
            GXt_char3 = "MOVALMACEN";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cMovCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cMovCod", StringUtil.LTrimStr( (decimal)(AV13cMovCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A234MovCod = AV13cMovCod;
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         }
      }

      protected void BeforeInsert5R104( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5R104( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5R104( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5R104( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5R104( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5R104( )
      {
         edtMovDsc_Enabled = 0;
         AssignProp("", false, edtMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovDsc_Enabled), 5, 0), true);
         edtMovAbr_Enabled = 0;
         AssignProp("", false, edtMovAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovAbr_Enabled), 5, 0), true);
         edtMovTip_Enabled = 0;
         AssignProp("", false, edtMovTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovTip_Enabled), 5, 0), true);
         cmbMovSts.Enabled = 0;
         AssignProp("", false, cmbMovSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovSts.Enabled), 5, 0), true);
         edtMovCod_Enabled = 0;
         AssignProp("", false, edtMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovCod_Enabled), 5, 0), true);
         edtMovAut_Enabled = 0;
         AssignProp("", false, edtMovAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovAut_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5R104( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5R0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810261274", false, true);
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
         GXEncryptionTmp = "configuracion.movimientoalmacen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MovCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.movimientoalmacen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MovimientoAlmacen");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\movimientoalmacen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z234MovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z234MovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1239MovDsc", StringUtil.RTrim( Z1239MovDsc));
         GxWebStd.gx_hidden_field( context, "Z1237MovAbr", StringUtil.RTrim( Z1237MovAbr));
         GxWebStd.gx_hidden_field( context, "Z1241MovTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1241MovTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1240MovSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1240MovSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1238MovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1238MovAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vMOVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMOVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MovCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCMOVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cMovCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.movimientoalmacen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MovCod,6,0));
         return formatLink("configuracion.movimientoalmacen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.MovimientoAlmacen" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimiento Almacen" ;
      }

      protected void InitializeNonKey5R104( )
      {
         AV13cMovCod = 0;
         AssignAttri("", false, "AV13cMovCod", StringUtil.LTrimStr( (decimal)(AV13cMovCod), 6, 0));
         A1239MovDsc = "";
         AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
         A1237MovAbr = "";
         AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
         A1241MovTip = 0;
         AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
         A1238MovAut = 0;
         AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
         A1240MovSts = 1;
         AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         Z1239MovDsc = "";
         Z1237MovAbr = "";
         Z1241MovTip = 0;
         Z1240MovSts = 0;
         Z1238MovAut = 0;
      }

      protected void InitAll5R104( )
      {
         A234MovCod = 0;
         AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         InitializeNonKey5R104( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1240MovSts = i1240MovSts;
         AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261293", true, true);
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
         context.AddJavascriptSource("configuracion/movimientoalmacen.js", "?202281810261293", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMovDsc_Internalname = "MOVDSC";
         edtMovAbr_Internalname = "MOVABR";
         edtMovTip_Internalname = "MOVTIP";
         cmbMovSts_Internalname = "MOVSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtMovCod_Internalname = "MOVCOD";
         edtMovAut_Internalname = "MOVAUT";
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
         Form.Caption = "Movimiento Almacen";
         edtMovAut_Jsonclick = "";
         edtMovAut_Enabled = 1;
         edtMovAut_Visible = 1;
         edtMovCod_Jsonclick = "";
         edtMovCod_Enabled = 1;
         edtMovCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbMovSts_Jsonclick = "";
         cmbMovSts.Enabled = 1;
         edtMovTip_Jsonclick = "";
         edtMovTip_Enabled = 1;
         edtMovAbr_Jsonclick = "";
         edtMovAbr_Enabled = 1;
         edtMovDsc_Jsonclick = "";
         edtMovDsc_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informaci�n General";
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

      protected void GX4ASACMOVCOD5R104( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cMovCod;
            GXt_char3 = "MOVALMACEN";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cMovCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cMovCod", StringUtil.LTrimStr( (decimal)(AV13cMovCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cMovCod), 6, 0, ".", "")))+"\"") ;
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
         cmbMovSts.Name = "MOVSTS";
         cmbMovSts.WebTags = "";
         cmbMovSts.addItem("1", "ACTIVO", 0);
         cmbMovSts.addItem("0", "INACTIVO", 0);
         if ( cmbMovSts.ItemCount > 0 )
         {
            if ( (0==A1240MovSts) )
            {
               A1240MovSts = 1;
               AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MovCod',fld:'vMOVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MovCod',fld:'vMOVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125R2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A234MovCod',fld:'MOVCOD',pic:'ZZZZZ9'},{av:'A1239MovDsc',fld:'MOVDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MOVDSC","{handler:'Valid_Movdsc',iparms:[]");
         setEventMetadata("VALID_MOVDSC",",oparms:[]}");
         setEventMetadata("VALID_MOVABR","{handler:'Valid_Movabr',iparms:[]");
         setEventMetadata("VALID_MOVABR",",oparms:[]}");
         setEventMetadata("VALID_MOVTIP","{handler:'Valid_Movtip',iparms:[]");
         setEventMetadata("VALID_MOVTIP",",oparms:[]}");
         setEventMetadata("VALID_MOVCOD","{handler:'Valid_Movcod',iparms:[]");
         setEventMetadata("VALID_MOVCOD",",oparms:[]}");
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
         Z1239MovDsc = "";
         Z1237MovAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A1239MovDsc = "";
         A1237MovAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode104 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14SGAuDocGls = "";
         AV15Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T005R4_A234MovCod = new int[1] ;
         T005R4_A1239MovDsc = new string[] {""} ;
         T005R4_A1237MovAbr = new string[] {""} ;
         T005R4_A1241MovTip = new short[1] ;
         T005R4_A1240MovSts = new short[1] ;
         T005R4_A1238MovAut = new short[1] ;
         T005R5_A234MovCod = new int[1] ;
         T005R3_A234MovCod = new int[1] ;
         T005R3_A1239MovDsc = new string[] {""} ;
         T005R3_A1237MovAbr = new string[] {""} ;
         T005R3_A1241MovTip = new short[1] ;
         T005R3_A1240MovSts = new short[1] ;
         T005R3_A1238MovAut = new short[1] ;
         T005R6_A234MovCod = new int[1] ;
         T005R7_A234MovCod = new int[1] ;
         T005R2_A234MovCod = new int[1] ;
         T005R2_A1239MovDsc = new string[] {""} ;
         T005R2_A1237MovAbr = new string[] {""} ;
         T005R2_A1241MovTip = new short[1] ;
         T005R2_A1240MovSts = new short[1] ;
         T005R2_A1238MovAut = new short[1] ;
         T005R11_A191ImpItem = new long[1] ;
         T005R12_A13MvATip = new string[] {""} ;
         T005R12_A14MvACod = new string[] {""} ;
         T005R13_A234MovCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoalmacen__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoalmacen__default(),
            new Object[][] {
                new Object[] {
               T005R2_A234MovCod, T005R2_A1239MovDsc, T005R2_A1237MovAbr, T005R2_A1241MovTip, T005R2_A1240MovSts, T005R2_A1238MovAut
               }
               , new Object[] {
               T005R3_A234MovCod, T005R3_A1239MovDsc, T005R3_A1237MovAbr, T005R3_A1241MovTip, T005R3_A1240MovSts, T005R3_A1238MovAut
               }
               , new Object[] {
               T005R4_A234MovCod, T005R4_A1239MovDsc, T005R4_A1237MovAbr, T005R4_A1241MovTip, T005R4_A1240MovSts, T005R4_A1238MovAut
               }
               , new Object[] {
               T005R5_A234MovCod
               }
               , new Object[] {
               T005R6_A234MovCod
               }
               , new Object[] {
               T005R7_A234MovCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005R11_A191ImpItem
               }
               , new Object[] {
               T005R12_A13MvATip, T005R12_A14MvACod
               }
               , new Object[] {
               T005R13_A234MovCod
               }
            }
         );
         Z1240MovSts = 1;
         A1240MovSts = 1;
         i1240MovSts = 1;
      }

      private short Z1241MovTip ;
      private short Z1240MovSts ;
      private short Z1238MovAut ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1240MovSts ;
      private short A1241MovTip ;
      private short A1238MovAut ;
      private short Gx_BScreen ;
      private short RcdFound104 ;
      private short GX_JID ;
      private short nIsDirty_104 ;
      private short gxajaxcallmode ;
      private short i1240MovSts ;
      private int wcpOAV7MovCod ;
      private int Z234MovCod ;
      private int AV7MovCod ;
      private int trnEnded ;
      private int edtMovDsc_Enabled ;
      private int edtMovAbr_Enabled ;
      private int edtMovTip_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A234MovCod ;
      private int edtMovCod_Visible ;
      private int edtMovCod_Enabled ;
      private int edtMovAut_Enabled ;
      private int edtMovAut_Visible ;
      private int AV13cMovCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1239MovDsc ;
      private string Z1237MovAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMovDsc_Internalname ;
      private string cmbMovSts_Internalname ;
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
      private string A1239MovDsc ;
      private string edtMovDsc_Jsonclick ;
      private string edtMovAbr_Internalname ;
      private string A1237MovAbr ;
      private string edtMovAbr_Jsonclick ;
      private string edtMovTip_Internalname ;
      private string edtMovTip_Jsonclick ;
      private string cmbMovSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMovCod_Internalname ;
      private string edtMovCod_Jsonclick ;
      private string edtMovAut_Internalname ;
      private string edtMovAut_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode104 ;
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
      private string AV14SGAuDocGls ;
      private string AV15Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMovSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005R4_A234MovCod ;
      private string[] T005R4_A1239MovDsc ;
      private string[] T005R4_A1237MovAbr ;
      private short[] T005R4_A1241MovTip ;
      private short[] T005R4_A1240MovSts ;
      private short[] T005R4_A1238MovAut ;
      private int[] T005R5_A234MovCod ;
      private int[] T005R3_A234MovCod ;
      private string[] T005R3_A1239MovDsc ;
      private string[] T005R3_A1237MovAbr ;
      private short[] T005R3_A1241MovTip ;
      private short[] T005R3_A1240MovSts ;
      private short[] T005R3_A1238MovAut ;
      private int[] T005R6_A234MovCod ;
      private int[] T005R7_A234MovCod ;
      private int[] T005R2_A234MovCod ;
      private string[] T005R2_A1239MovDsc ;
      private string[] T005R2_A1237MovAbr ;
      private short[] T005R2_A1241MovTip ;
      private short[] T005R2_A1240MovSts ;
      private short[] T005R2_A1238MovAut ;
      private long[] T005R11_A191ImpItem ;
      private string[] T005R12_A13MvATip ;
      private string[] T005R12_A14MvACod ;
      private int[] T005R13_A234MovCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class movimientoalmacen__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class movimientoalmacen__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005R4;
        prmT005R4 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R5;
        prmT005R5 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R3;
        prmT005R3 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R6;
        prmT005R6 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R7;
        prmT005R7 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R2;
        prmT005R2 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R8;
        prmT005R8 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0) ,
        new ParDef("@MovDsc",GXType.NChar,100,0) ,
        new ParDef("@MovAbr",GXType.NChar,5,0) ,
        new ParDef("@MovTip",GXType.Int16,1,0) ,
        new ParDef("@MovSts",GXType.Int16,1,0) ,
        new ParDef("@MovAut",GXType.Int16,1,0)
        };
        Object[] prmT005R9;
        prmT005R9 = new Object[] {
        new ParDef("@MovDsc",GXType.NChar,100,0) ,
        new ParDef("@MovAbr",GXType.NChar,5,0) ,
        new ParDef("@MovTip",GXType.Int16,1,0) ,
        new ParDef("@MovSts",GXType.Int16,1,0) ,
        new ParDef("@MovAut",GXType.Int16,1,0) ,
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R10;
        prmT005R10 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R11;
        prmT005R11 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R12;
        prmT005R12 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT005R13;
        prmT005R13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005R2", "SELECT [MovCod], [MovDsc], [MovAbr], [MovTip], [MovSts], [MovAut] FROM [CMOVALMACEN] WITH (UPDLOCK) WHERE [MovCod] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005R3", "SELECT [MovCod], [MovDsc], [MovAbr], [MovTip], [MovSts], [MovAut] FROM [CMOVALMACEN] WHERE [MovCod] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005R4", "SELECT TM1.[MovCod], TM1.[MovDsc], TM1.[MovAbr], TM1.[MovTip], TM1.[MovSts], TM1.[MovAut] FROM [CMOVALMACEN] TM1 WHERE TM1.[MovCod] = @MovCod ORDER BY TM1.[MovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005R4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005R5", "SELECT [MovCod] FROM [CMOVALMACEN] WHERE [MovCod] = @MovCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005R6", "SELECT TOP 1 [MovCod] FROM [CMOVALMACEN] WHERE ( [MovCod] > @MovCod) ORDER BY [MovCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005R6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005R7", "SELECT TOP 1 [MovCod] FROM [CMOVALMACEN] WHERE ( [MovCod] < @MovCod) ORDER BY [MovCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005R7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005R8", "INSERT INTO [CMOVALMACEN]([MovCod], [MovDsc], [MovAbr], [MovTip], [MovSts], [MovAut]) VALUES(@MovCod, @MovDsc, @MovAbr, @MovTip, @MovSts, @MovAut)", GxErrorMask.GX_NOMASK,prmT005R8)
           ,new CursorDef("T005R9", "UPDATE [CMOVALMACEN] SET [MovDsc]=@MovDsc, [MovAbr]=@MovAbr, [MovTip]=@MovTip, [MovSts]=@MovSts, [MovAut]=@MovAut  WHERE [MovCod] = @MovCod", GxErrorMask.GX_NOMASK,prmT005R9)
           ,new CursorDef("T005R10", "DELETE FROM [CMOVALMACEN]  WHERE [MovCod] = @MovCod", GxErrorMask.GX_NOMASK,prmT005R10)
           ,new CursorDef("T005R11", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpMovCod] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005R11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005R12", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MvAMov] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005R12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005R13", "SELECT [MovCod] FROM [CMOVALMACEN] ORDER BY [MovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005R13,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
