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
   public class condicionpago : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCCONPCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACCONPCOD5J75( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.condicionpago.aspx")), "configuracion.condicionpago.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.condicionpago.aspx")))) ;
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
                  AV7Conpcod = (int)(NumberUtil.Val( GetPar( "Conpcod"), "."));
                  AssignAttri("", false, "AV7Conpcod", StringUtil.LTrimStr( (decimal)(AV7Conpcod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONPCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Conpcod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Condiciones de Pago", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public condicionpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public condicionpago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_Conpcod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Conpcod = aP1_Conpcod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbConpSts = new GXCombobox();
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
         if ( cmbConpSts.ItemCount > 0 )
         {
            A754ConpSts = (short)(NumberUtil.Val( cmbConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0))), "."));
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            AssignProp("", false, cmbConpSts_Internalname, "Values", cmbConpSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtConpDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConpDsc_Internalname, "Condición de Pago", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpDsc_Internalname, StringUtil.RTrim( A753ConpDsc), StringUtil.RTrim( context.localUtil.Format( A753ConpDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\CondicionPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtConpAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConpAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpAbr_Internalname, StringUtil.RTrim( A751ConpAbr), StringUtil.RTrim( context.localUtil.Format( A751ConpAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\CondicionPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtConpDias_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConpDias_Internalname, "Dias", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A752ConpDias), 4, 0, ".", "")), StringUtil.LTrim( ((edtConpDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A752ConpDias), "ZZZ9") : context.localUtil.Format( (decimal)(A752ConpDias), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpDias_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\CondicionPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbConpSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConpSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConpSts, cmbConpSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0)), 1, cmbConpSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbConpSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_Configuracion\\CondicionPago.htm");
         cmbConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         AssignProp("", false, cmbConpSts_Internalname, "Values", (string)(cmbConpSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\CondicionPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\CondicionPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\CondicionPago.htm");
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
         GxWebStd.gx_single_line_edit( context, edtConpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConpcod_Enabled!=0) ? context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpcod_Jsonclick, 0, "Attribute", "", "", "", "", edtConpcod_Visible, edtConpcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\CondicionPago.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpSunat_Internalname, A755ConpSunat, StringUtil.RTrim( context.localUtil.Format( A755ConpSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpSunat_Jsonclick, 0, "Attribute", "", "", "", "", edtConpSunat_Visible, edtConpSunat_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\CondicionPago.htm");
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
         E115J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z137Conpcod = (int)(context.localUtil.CToN( cgiGet( "Z137Conpcod"), ".", ","));
               Z753ConpDsc = cgiGet( "Z753ConpDsc");
               Z751ConpAbr = cgiGet( "Z751ConpAbr");
               Z752ConpDias = (short)(context.localUtil.CToN( cgiGet( "Z752ConpDias"), ".", ","));
               Z754ConpSts = (short)(context.localUtil.CToN( cgiGet( "Z754ConpSts"), ".", ","));
               Z755ConpSunat = cgiGet( "Z755ConpSunat");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7Conpcod = (int)(context.localUtil.CToN( cgiGet( "vCONPCOD"), ".", ","));
               AV15cConpCod = (int)(context.localUtil.CToN( cgiGet( "vCCONPCOD"), ".", ","));
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
               A753ConpDsc = cgiGet( edtConpDsc_Internalname);
               AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
               A751ConpAbr = cgiGet( edtConpAbr_Internalname);
               AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
               if ( ( ( context.localUtil.CToN( cgiGet( edtConpDias_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConpDias_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONPDIAS");
                  AnyError = 1;
                  GX_FocusControl = edtConpDias_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A752ConpDias = 0;
                  AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
               }
               else
               {
                  A752ConpDias = (short)(context.localUtil.CToN( cgiGet( edtConpDias_Internalname), ".", ","));
                  AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
               }
               cmbConpSts.CurrentValue = cgiGet( cmbConpSts_Internalname);
               A754ConpSts = (short)(NumberUtil.Val( cgiGet( cmbConpSts_Internalname), "."));
               AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
               A137Conpcod = (int)(context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ","));
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               A755ConpSunat = cgiGet( edtConpSunat_Internalname);
               AssignAttri("", false, "A755ConpSunat", A755ConpSunat);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CondicionPago");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A137Conpcod != Z137Conpcod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\condicionpago:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A137Conpcod = (int)(NumberUtil.Val( GetPar( "Conpcod"), "."));
                  AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
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
                     sMode75 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode75;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound75 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONPCOD");
                        AnyError = 1;
                        GX_FocusControl = edtConpcod_Internalname;
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
                           E115J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125J2 ();
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
            E125J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5J75( ) ;
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
            DisableAttributes5J75( ) ;
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

      protected void CONFIRM_5J0( )
      {
         BeforeValidate5J75( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5J75( ) ;
            }
            else
            {
               CheckExtendedTable5J75( ) ;
               CloseExtendedTableCursors5J75( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5J0( )
      {
      }

      protected void E115J2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtConpcod_Visible = 0;
         AssignProp("", false, edtConpcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConpcod_Visible), 5, 0), true);
         edtConpSunat_Visible = 0;
         AssignProp("", false, edtConpSunat_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConpSunat_Visible), 5, 0), true);
      }

      protected void E125J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13SGAuDocGls = "Condición de Pago N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A137Conpcod), 10, 0)) + " " + StringUtil.Trim( A753ConpDsc);
            AV14Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A137Conpcod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV13SGAuDocGls, ref  AV14Codigo, ref  AV14Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.condicionpagoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5J75( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z753ConpDsc = T005J3_A753ConpDsc[0];
               Z751ConpAbr = T005J3_A751ConpAbr[0];
               Z752ConpDias = T005J3_A752ConpDias[0];
               Z754ConpSts = T005J3_A754ConpSts[0];
               Z755ConpSunat = T005J3_A755ConpSunat[0];
            }
            else
            {
               Z753ConpDsc = A753ConpDsc;
               Z751ConpAbr = A751ConpAbr;
               Z752ConpDias = A752ConpDias;
               Z754ConpSts = A754ConpSts;
               Z755ConpSunat = A755ConpSunat;
            }
         }
         if ( GX_JID == -9 )
         {
            Z137Conpcod = A137Conpcod;
            Z753ConpDsc = A753ConpDsc;
            Z751ConpAbr = A751ConpAbr;
            Z752ConpDias = A752ConpDias;
            Z754ConpSts = A754ConpSts;
            Z755ConpSunat = A755ConpSunat;
         }
      }

      protected void standaloneNotModal( )
      {
         edtConpcod_Enabled = 0;
         AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtConpcod_Enabled = 0;
         AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Conpcod) )
         {
            A137Conpcod = AV7Conpcod;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
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
         if ( IsIns( )  && (0==A754ConpSts) && ( Gx_BScreen == 0 ) )
         {
            A754ConpSts = 1;
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         }
      }

      protected void Load5J75( )
      {
         /* Using cursor T005J4 */
         pr_default.execute(2, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound75 = 1;
            A753ConpDsc = T005J4_A753ConpDsc[0];
            AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
            A751ConpAbr = T005J4_A751ConpAbr[0];
            AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
            A752ConpDias = T005J4_A752ConpDias[0];
            AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
            A754ConpSts = T005J4_A754ConpSts[0];
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            A755ConpSunat = T005J4_A755ConpSunat[0];
            AssignAttri("", false, "A755ConpSunat", A755ConpSunat);
            ZM5J75( -9) ;
         }
         pr_default.close(2);
         OnLoadActions5J75( ) ;
      }

      protected void OnLoadActions5J75( )
      {
      }

      protected void CheckExtendedTable5J75( )
      {
         nIsDirty_75 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A753ConpDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Condicion de pago", "", "", "", "", "", "", "", ""), 1, "CONPDSC");
            AnyError = 1;
            GX_FocusControl = edtConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A751ConpAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura condicion pago", "", "", "", "", "", "", "", ""), 1, "CONPABR");
            AnyError = 1;
            GX_FocusControl = edtConpAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A752ConpDias) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Dias", "", "", "", "", "", "", "", ""), 1, "CONPDIAS");
            AnyError = 1;
            GX_FocusControl = edtConpDias_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5J75( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5J75( )
      {
         /* Using cursor T005J5 */
         pr_default.execute(3, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005J3 */
         pr_default.execute(1, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5J75( 9) ;
            RcdFound75 = 1;
            A137Conpcod = T005J3_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            A753ConpDsc = T005J3_A753ConpDsc[0];
            AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
            A751ConpAbr = T005J3_A751ConpAbr[0];
            AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
            A752ConpDias = T005J3_A752ConpDias[0];
            AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
            A754ConpSts = T005J3_A754ConpSts[0];
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            A755ConpSunat = T005J3_A755ConpSunat[0];
            AssignAttri("", false, "A755ConpSunat", A755ConpSunat);
            Z137Conpcod = A137Conpcod;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5J75( ) ;
            if ( AnyError == 1 )
            {
               RcdFound75 = 0;
               InitializeNonKey5J75( ) ;
            }
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey5J75( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5J75( ) ;
         if ( RcdFound75 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound75 = 0;
         /* Using cursor T005J6 */
         pr_default.execute(4, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005J6_A137Conpcod[0] < A137Conpcod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005J6_A137Conpcod[0] > A137Conpcod ) ) )
            {
               A137Conpcod = T005J6_A137Conpcod[0];
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               RcdFound75 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound75 = 0;
         /* Using cursor T005J7 */
         pr_default.execute(5, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005J7_A137Conpcod[0] > A137Conpcod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005J7_A137Conpcod[0] < A137Conpcod ) ) )
            {
               A137Conpcod = T005J7_A137Conpcod[0];
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               RcdFound75 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5J75( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5J75( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound75 == 1 )
            {
               if ( A137Conpcod != Z137Conpcod )
               {
                  A137Conpcod = Z137Conpcod;
                  AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConpcod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConpDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5J75( ) ;
                  GX_FocusControl = edtConpDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A137Conpcod != Z137Conpcod )
               {
                  /* Insert record */
                  GX_FocusControl = edtConpDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5J75( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtConpcod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtConpDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5J75( ) ;
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
         if ( A137Conpcod != Z137Conpcod )
         {
            A137Conpcod = Z137Conpcod;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConpDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5J75( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005J2 */
            pr_default.execute(0, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCONDICIONPAGO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z753ConpDsc, T005J2_A753ConpDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z751ConpAbr, T005J2_A751ConpAbr[0]) != 0 ) || ( Z752ConpDias != T005J2_A752ConpDias[0] ) || ( Z754ConpSts != T005J2_A754ConpSts[0] ) || ( StringUtil.StrCmp(Z755ConpSunat, T005J2_A755ConpSunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z753ConpDsc, T005J2_A753ConpDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.condicionpago:[seudo value changed for attri]"+"ConpDsc");
                  GXUtil.WriteLogRaw("Old: ",Z753ConpDsc);
                  GXUtil.WriteLogRaw("Current: ",T005J2_A753ConpDsc[0]);
               }
               if ( StringUtil.StrCmp(Z751ConpAbr, T005J2_A751ConpAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.condicionpago:[seudo value changed for attri]"+"ConpAbr");
                  GXUtil.WriteLogRaw("Old: ",Z751ConpAbr);
                  GXUtil.WriteLogRaw("Current: ",T005J2_A751ConpAbr[0]);
               }
               if ( Z752ConpDias != T005J2_A752ConpDias[0] )
               {
                  GXUtil.WriteLog("configuracion.condicionpago:[seudo value changed for attri]"+"ConpDias");
                  GXUtil.WriteLogRaw("Old: ",Z752ConpDias);
                  GXUtil.WriteLogRaw("Current: ",T005J2_A752ConpDias[0]);
               }
               if ( Z754ConpSts != T005J2_A754ConpSts[0] )
               {
                  GXUtil.WriteLog("configuracion.condicionpago:[seudo value changed for attri]"+"ConpSts");
                  GXUtil.WriteLogRaw("Old: ",Z754ConpSts);
                  GXUtil.WriteLogRaw("Current: ",T005J2_A754ConpSts[0]);
               }
               if ( StringUtil.StrCmp(Z755ConpSunat, T005J2_A755ConpSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.condicionpago:[seudo value changed for attri]"+"ConpSunat");
                  GXUtil.WriteLogRaw("Old: ",Z755ConpSunat);
                  GXUtil.WriteLogRaw("Current: ",T005J2_A755ConpSunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CCONDICIONPAGO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5J75( )
      {
         BeforeValidate5J75( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5J75( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5J75( 0) ;
            CheckOptimisticConcurrency5J75( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5J75( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5J75( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005J8 */
                     pr_default.execute(6, new Object[] {A137Conpcod, A753ConpDsc, A751ConpAbr, A752ConpDias, A754ConpSts, A755ConpSunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CCONDICIONPAGO");
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
                           ResetCaption5J0( ) ;
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
               Load5J75( ) ;
            }
            EndLevel5J75( ) ;
         }
         CloseExtendedTableCursors5J75( ) ;
      }

      protected void Update5J75( )
      {
         BeforeValidate5J75( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5J75( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5J75( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5J75( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5J75( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005J9 */
                     pr_default.execute(7, new Object[] {A753ConpDsc, A751ConpAbr, A752ConpDias, A754ConpSts, A755ConpSunat, A137Conpcod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CCONDICIONPAGO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCONDICIONPAGO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5J75( ) ;
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
            EndLevel5J75( ) ;
         }
         CloseExtendedTableCursors5J75( ) ;
      }

      protected void DeferredUpdate5J75( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5J75( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5J75( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5J75( ) ;
            AfterConfirm5J75( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5J75( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005J10 */
                  pr_default.execute(8, new Object[] {A137Conpcod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CCONDICIONPAGO");
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
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5J75( ) ;
         Gx_mode = sMode75;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5J75( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005J11 */
            pr_default.execute(9, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005J12 */
            pr_default.execute(10, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T005J13 */
            pr_default.execute(11, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005J14 */
            pr_default.execute(12, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005J15 */
            pr_default.execute(13, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005J16 */
            pr_default.execute(14, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005J17 */
            pr_default.execute(15, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005J18 */
            pr_default.execute(16, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel5J75( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5J75( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.condicionpago",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.condicionpago",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5J75( )
      {
         /* Scan By routine */
         /* Using cursor T005J19 */
         pr_default.execute(17);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound75 = 1;
            A137Conpcod = T005J19_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5J75( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound75 = 1;
            A137Conpcod = T005J19_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
      }

      protected void ScanEnd5J75( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm5J75( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV15cConpCod;
            GXt_char3 = "CONPAGO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV15cConpCod = (int)(GXt_int4);
            AssignAttri("", false, "AV15cConpCod", StringUtil.LTrimStr( (decimal)(AV15cConpCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A137Conpcod = AV15cConpCod;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
      }

      protected void BeforeInsert5J75( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5J75( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5J75( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5J75( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5J75( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5J75( )
      {
         edtConpDsc_Enabled = 0;
         AssignProp("", false, edtConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpDsc_Enabled), 5, 0), true);
         edtConpAbr_Enabled = 0;
         AssignProp("", false, edtConpAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpAbr_Enabled), 5, 0), true);
         edtConpDias_Enabled = 0;
         AssignProp("", false, edtConpDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpDias_Enabled), 5, 0), true);
         cmbConpSts.Enabled = 0;
         AssignProp("", false, cmbConpSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConpSts.Enabled), 5, 0), true);
         edtConpcod_Enabled = 0;
         AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         edtConpSunat_Enabled = 0;
         AssignProp("", false, edtConpSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpSunat_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5J75( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2022818102601", false, true);
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
         GXEncryptionTmp = "configuracion.condicionpago.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7Conpcod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.condicionpago.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CondicionPago");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\condicionpago:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z753ConpDsc", StringUtil.RTrim( Z753ConpDsc));
         GxWebStd.gx_hidden_field( context, "Z751ConpAbr", StringUtil.RTrim( Z751ConpAbr));
         GxWebStd.gx_hidden_field( context, "Z752ConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z752ConpDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z754ConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z754ConpSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z755ConpSunat", Z755ConpSunat);
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
         GxWebStd.gx_hidden_field( context, "vCONPCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONPCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Conpcod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCCONPCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cConpCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.condicionpago.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7Conpcod,6,0));
         return formatLink("configuracion.condicionpago.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.CondicionPago" ;
      }

      public override string GetPgmdesc( )
      {
         return "Condiciones de Pago" ;
      }

      protected void InitializeNonKey5J75( )
      {
         AV15cConpCod = 0;
         AssignAttri("", false, "AV15cConpCod", StringUtil.LTrimStr( (decimal)(AV15cConpCod), 6, 0));
         A753ConpDsc = "";
         AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
         A751ConpAbr = "";
         AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
         A752ConpDias = 0;
         AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
         A755ConpSunat = "";
         AssignAttri("", false, "A755ConpSunat", A755ConpSunat);
         A754ConpSts = 1;
         AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         Z753ConpDsc = "";
         Z751ConpAbr = "";
         Z752ConpDias = 0;
         Z754ConpSts = 0;
         Z755ConpSunat = "";
      }

      protected void InitAll5J75( )
      {
         A137Conpcod = 0;
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         InitializeNonKey5J75( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A754ConpSts = i754ConpSts;
         AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026018", true, true);
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
         context.AddJavascriptSource("configuracion/condicionpago.js", "?20228181026019", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtConpDsc_Internalname = "CONPDSC";
         edtConpAbr_Internalname = "CONPABR";
         edtConpDias_Internalname = "CONPDIAS";
         cmbConpSts_Internalname = "CONPSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtConpcod_Internalname = "CONPCOD";
         edtConpSunat_Internalname = "CONPSUNAT";
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
         Form.Caption = "Condiciones de Pago";
         edtConpSunat_Jsonclick = "";
         edtConpSunat_Enabled = 1;
         edtConpSunat_Visible = 1;
         edtConpcod_Jsonclick = "";
         edtConpcod_Enabled = 0;
         edtConpcod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbConpSts_Jsonclick = "";
         cmbConpSts.Enabled = 1;
         edtConpDias_Jsonclick = "";
         edtConpDias_Enabled = 1;
         edtConpAbr_Jsonclick = "";
         edtConpAbr_Enabled = 1;
         edtConpDsc_Jsonclick = "";
         edtConpDsc_Enabled = 1;
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

      protected void GX4ASACCONPCOD5J75( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV15cConpCod;
            GXt_char3 = "CONPAGO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV15cConpCod = (int)(GXt_int4);
            AssignAttri("", false, "AV15cConpCod", StringUtil.LTrimStr( (decimal)(AV15cConpCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cConpCod), 6, 0, ".", "")))+"\"") ;
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
         cmbConpSts.Name = "CONPSTS";
         cmbConpSts.WebTags = "";
         cmbConpSts.addItem("1", "ACTIVO", 0);
         cmbConpSts.addItem("0", "INACTIVO", 0);
         if ( cmbConpSts.ItemCount > 0 )
         {
            if ( (0==A754ConpSts) )
            {
               A754ConpSts = 1;
               AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Conpcod',fld:'vCONPCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Conpcod',fld:'vCONPCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A137Conpcod',fld:'CONPCOD',pic:'ZZZZZ9'},{av:'A753ConpDsc',fld:'CONPDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CONPDSC","{handler:'Valid_Conpdsc',iparms:[]");
         setEventMetadata("VALID_CONPDSC",",oparms:[]}");
         setEventMetadata("VALID_CONPABR","{handler:'Valid_Conpabr',iparms:[]");
         setEventMetadata("VALID_CONPABR",",oparms:[]}");
         setEventMetadata("VALID_CONPDIAS","{handler:'Valid_Conpdias',iparms:[]");
         setEventMetadata("VALID_CONPDIAS",",oparms:[]}");
         setEventMetadata("VALID_CONPCOD","{handler:'Valid_Conpcod',iparms:[]");
         setEventMetadata("VALID_CONPCOD",",oparms:[]}");
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
         Z753ConpDsc = "";
         Z751ConpAbr = "";
         Z755ConpSunat = "";
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
         A753ConpDsc = "";
         A751ConpAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A755ConpSunat = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode75 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV13SGAuDocGls = "";
         AV14Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T005J4_A137Conpcod = new int[1] ;
         T005J4_A753ConpDsc = new string[] {""} ;
         T005J4_A751ConpAbr = new string[] {""} ;
         T005J4_A752ConpDias = new short[1] ;
         T005J4_A754ConpSts = new short[1] ;
         T005J4_A755ConpSunat = new string[] {""} ;
         T005J5_A137Conpcod = new int[1] ;
         T005J3_A137Conpcod = new int[1] ;
         T005J3_A753ConpDsc = new string[] {""} ;
         T005J3_A751ConpAbr = new string[] {""} ;
         T005J3_A752ConpDias = new short[1] ;
         T005J3_A754ConpSts = new short[1] ;
         T005J3_A755ConpSunat = new string[] {""} ;
         T005J6_A137Conpcod = new int[1] ;
         T005J7_A137Conpcod = new int[1] ;
         T005J2_A137Conpcod = new int[1] ;
         T005J2_A753ConpDsc = new string[] {""} ;
         T005J2_A751ConpAbr = new string[] {""} ;
         T005J2_A752ConpDias = new short[1] ;
         T005J2_A754ConpSts = new short[1] ;
         T005J2_A755ConpSunat = new string[] {""} ;
         T005J11_A244PrvCod = new string[] {""} ;
         T005J12_A289OrdCod = new string[] {""} ;
         T005J13_A149TipCod = new string[] {""} ;
         T005J13_A243ComCod = new string[] {""} ;
         T005J13_A244PrvCod = new string[] {""} ;
         T005J14_A149TipCod = new string[] {""} ;
         T005J14_A24DocNum = new string[] {""} ;
         T005J15_A210PedCod = new string[] {""} ;
         T005J16_A191ImpItem = new long[1] ;
         T005J17_A177CotCod = new string[] {""} ;
         T005J18_A45CliCod = new string[] {""} ;
         T005J19_A137Conpcod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.condicionpago__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.condicionpago__default(),
            new Object[][] {
                new Object[] {
               T005J2_A137Conpcod, T005J2_A753ConpDsc, T005J2_A751ConpAbr, T005J2_A752ConpDias, T005J2_A754ConpSts, T005J2_A755ConpSunat
               }
               , new Object[] {
               T005J3_A137Conpcod, T005J3_A753ConpDsc, T005J3_A751ConpAbr, T005J3_A752ConpDias, T005J3_A754ConpSts, T005J3_A755ConpSunat
               }
               , new Object[] {
               T005J4_A137Conpcod, T005J4_A753ConpDsc, T005J4_A751ConpAbr, T005J4_A752ConpDias, T005J4_A754ConpSts, T005J4_A755ConpSunat
               }
               , new Object[] {
               T005J5_A137Conpcod
               }
               , new Object[] {
               T005J6_A137Conpcod
               }
               , new Object[] {
               T005J7_A137Conpcod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005J11_A244PrvCod
               }
               , new Object[] {
               T005J12_A289OrdCod
               }
               , new Object[] {
               T005J13_A149TipCod, T005J13_A243ComCod, T005J13_A244PrvCod
               }
               , new Object[] {
               T005J14_A149TipCod, T005J14_A24DocNum
               }
               , new Object[] {
               T005J15_A210PedCod
               }
               , new Object[] {
               T005J16_A191ImpItem
               }
               , new Object[] {
               T005J17_A177CotCod
               }
               , new Object[] {
               T005J18_A45CliCod
               }
               , new Object[] {
               T005J19_A137Conpcod
               }
            }
         );
         Z754ConpSts = 1;
         A754ConpSts = 1;
         i754ConpSts = 1;
      }

      private short Z752ConpDias ;
      private short Z754ConpSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A754ConpSts ;
      private short A752ConpDias ;
      private short Gx_BScreen ;
      private short RcdFound75 ;
      private short GX_JID ;
      private short nIsDirty_75 ;
      private short gxajaxcallmode ;
      private short i754ConpSts ;
      private int wcpOAV7Conpcod ;
      private int Z137Conpcod ;
      private int AV7Conpcod ;
      private int trnEnded ;
      private int edtConpDsc_Enabled ;
      private int edtConpAbr_Enabled ;
      private int edtConpDias_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A137Conpcod ;
      private int edtConpcod_Enabled ;
      private int edtConpcod_Visible ;
      private int edtConpSunat_Visible ;
      private int edtConpSunat_Enabled ;
      private int AV15cConpCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z753ConpDsc ;
      private string Z751ConpAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConpDsc_Internalname ;
      private string cmbConpSts_Internalname ;
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
      private string A753ConpDsc ;
      private string edtConpDsc_Jsonclick ;
      private string edtConpAbr_Internalname ;
      private string A751ConpAbr ;
      private string edtConpAbr_Jsonclick ;
      private string edtConpDias_Internalname ;
      private string edtConpDias_Jsonclick ;
      private string cmbConpSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtConpcod_Internalname ;
      private string edtConpcod_Jsonclick ;
      private string edtConpSunat_Internalname ;
      private string edtConpSunat_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode75 ;
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
      private string Z755ConpSunat ;
      private string A755ConpSunat ;
      private string AV13SGAuDocGls ;
      private string AV14Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConpSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005J4_A137Conpcod ;
      private string[] T005J4_A753ConpDsc ;
      private string[] T005J4_A751ConpAbr ;
      private short[] T005J4_A752ConpDias ;
      private short[] T005J4_A754ConpSts ;
      private string[] T005J4_A755ConpSunat ;
      private int[] T005J5_A137Conpcod ;
      private int[] T005J3_A137Conpcod ;
      private string[] T005J3_A753ConpDsc ;
      private string[] T005J3_A751ConpAbr ;
      private short[] T005J3_A752ConpDias ;
      private short[] T005J3_A754ConpSts ;
      private string[] T005J3_A755ConpSunat ;
      private int[] T005J6_A137Conpcod ;
      private int[] T005J7_A137Conpcod ;
      private int[] T005J2_A137Conpcod ;
      private string[] T005J2_A753ConpDsc ;
      private string[] T005J2_A751ConpAbr ;
      private short[] T005J2_A752ConpDias ;
      private short[] T005J2_A754ConpSts ;
      private string[] T005J2_A755ConpSunat ;
      private string[] T005J11_A244PrvCod ;
      private string[] T005J12_A289OrdCod ;
      private string[] T005J13_A149TipCod ;
      private string[] T005J13_A243ComCod ;
      private string[] T005J13_A244PrvCod ;
      private string[] T005J14_A149TipCod ;
      private string[] T005J14_A24DocNum ;
      private string[] T005J15_A210PedCod ;
      private long[] T005J16_A191ImpItem ;
      private string[] T005J17_A177CotCod ;
      private string[] T005J18_A45CliCod ;
      private int[] T005J19_A137Conpcod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class condicionpago__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class condicionpago__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
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
        Object[] prmT005J4;
        prmT005J4 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J5;
        prmT005J5 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J3;
        prmT005J3 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J6;
        prmT005J6 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J7;
        prmT005J7 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J2;
        prmT005J2 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J8;
        prmT005J8 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0) ,
        new ParDef("@ConpDsc",GXType.NChar,100,0) ,
        new ParDef("@ConpAbr",GXType.NChar,5,0) ,
        new ParDef("@ConpDias",GXType.Int16,4,0) ,
        new ParDef("@ConpSts",GXType.Int16,1,0) ,
        new ParDef("@ConpSunat",GXType.NVarChar,20,0)
        };
        Object[] prmT005J9;
        prmT005J9 = new Object[] {
        new ParDef("@ConpDsc",GXType.NChar,100,0) ,
        new ParDef("@ConpAbr",GXType.NChar,5,0) ,
        new ParDef("@ConpDias",GXType.Int16,4,0) ,
        new ParDef("@ConpSts",GXType.Int16,1,0) ,
        new ParDef("@ConpSunat",GXType.NVarChar,20,0) ,
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J10;
        prmT005J10 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J11;
        prmT005J11 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J12;
        prmT005J12 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J13;
        prmT005J13 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J14;
        prmT005J14 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J15;
        prmT005J15 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J16;
        prmT005J16 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J17;
        prmT005J17 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J18;
        prmT005J18 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT005J19;
        prmT005J19 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005J2", "SELECT [Conpcod], [ConpDsc], [ConpAbr], [ConpDias], [ConpSts], [ConpSunat] FROM [CCONDICIONPAGO] WITH (UPDLOCK) WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005J3", "SELECT [Conpcod], [ConpDsc], [ConpAbr], [ConpDias], [ConpSts], [ConpSunat] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005J4", "SELECT TM1.[Conpcod], TM1.[ConpDsc], TM1.[ConpAbr], TM1.[ConpDias], TM1.[ConpSts], TM1.[ConpSunat] FROM [CCONDICIONPAGO] TM1 WHERE TM1.[Conpcod] = @Conpcod ORDER BY TM1.[Conpcod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005J5", "SELECT [Conpcod] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005J6", "SELECT TOP 1 [Conpcod] FROM [CCONDICIONPAGO] WHERE ( [Conpcod] > @Conpcod) ORDER BY [Conpcod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J7", "SELECT TOP 1 [Conpcod] FROM [CCONDICIONPAGO] WHERE ( [Conpcod] < @Conpcod) ORDER BY [Conpcod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005J7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J8", "INSERT INTO [CCONDICIONPAGO]([Conpcod], [ConpDsc], [ConpAbr], [ConpDias], [ConpSts], [ConpSunat]) VALUES(@Conpcod, @ConpDsc, @ConpAbr, @ConpDias, @ConpSts, @ConpSunat)", GxErrorMask.GX_NOMASK,prmT005J8)
           ,new CursorDef("T005J9", "UPDATE [CCONDICIONPAGO] SET [ConpDsc]=@ConpDsc, [ConpAbr]=@ConpAbr, [ConpDias]=@ConpDias, [ConpSts]=@ConpSts, [ConpSunat]=@ConpSunat  WHERE [Conpcod] = @Conpcod", GxErrorMask.GX_NOMASK,prmT005J9)
           ,new CursorDef("T005J10", "DELETE FROM [CCONDICIONPAGO]  WHERE [Conpcod] = @Conpcod", GxErrorMask.GX_NOMASK,prmT005J10)
           ,new CursorDef("T005J11", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J12", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [OrdConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J13", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [ComConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J14", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J15", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [PedConp] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J16", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J17", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CotConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J18", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005J18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005J19", "SELECT [Conpcod] FROM [CCONDICIONPAGO] ORDER BY [Conpcod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005J19,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
