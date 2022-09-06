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
   public class tipoasientos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCTASICOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACTASICOD7771( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.tipoasientos.aspx")), "contabilidad.tipoasientos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.tipoasientos.aspx")))) ;
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
                  AV7TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
                  AssignAttri("", false, "AV7TASICod", StringUtil.LTrimStr( (decimal)(AV7TASICod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTASICOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TASICod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tipos de Asientos Contables", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTASIDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipoasientos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoasientos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TASICod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TASICod = aP1_TASICod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTASISts = new GXCombobox();
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
         if ( cmbTASISts.ItemCount > 0 )
         {
            A1896TASISts = (short)(NumberUtil.Val( cmbTASISts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0))), "."));
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTASISts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            AssignProp("", false, cmbTASISts_Internalname, "Values", cmbTASISts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTASIDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTASIDsc_Internalname, "Tipo Asiento", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASIDsc_Internalname, StringUtil.RTrim( A1895TASIDsc), StringUtil.RTrim( context.localUtil.Format( A1895TASIDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASIDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTASIDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\TipoAsientos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTASIAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTASIAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASIAbr_Internalname, StringUtil.RTrim( A1894TASIAbr), StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASIAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASIAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\TipoAsientos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTASISts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTASISts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTASISts, cmbTASISts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0)), 1, cmbTASISts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTASISts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Contabilidad\\TipoAsientos.htm");
         cmbTASISts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         AssignProp("", false, cmbTASISts_Internalname, "Values", (string)(cmbTASISts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\TipoAsientos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\TipoAsientos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\TipoAsientos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126TASICod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASICod_Jsonclick, 0, "Attribute", "", "", "", "", edtTASICod_Visible, edtTASICod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\TipoAsientos.htm");
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
         E11772 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z126TASICod = (int)(context.localUtil.CToN( cgiGet( "Z126TASICod"), ".", ","));
               Z1895TASIDsc = cgiGet( "Z1895TASIDsc");
               Z1894TASIAbr = cgiGet( "Z1894TASIAbr");
               Z1896TASISts = (short)(context.localUtil.CToN( cgiGet( "Z1896TASISts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TASICod = (int)(context.localUtil.CToN( cgiGet( "vTASICOD"), ".", ","));
               AV13cTASICod = (int)(context.localUtil.CToN( cgiGet( "vCTASICOD"), ".", ","));
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
               A1895TASIDsc = cgiGet( edtTASIDsc_Internalname);
               AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
               A1894TASIAbr = cgiGet( edtTASIAbr_Internalname);
               AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
               cmbTASISts.CurrentValue = cgiGet( cmbTASISts_Internalname);
               A1896TASISts = (short)(NumberUtil.Val( cgiGet( cmbTASISts_Internalname), "."));
               AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TASICOD");
                  AnyError = 1;
                  GX_FocusControl = edtTASICod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A126TASICod = 0;
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               }
               else
               {
                  A126TASICod = (int)(context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ","));
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoAsientos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A126TASICod != Z126TASICod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\tipoasientos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A126TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
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
                     sMode71 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode71;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound71 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_770( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TASICOD");
                        AnyError = 1;
                        GX_FocusControl = edtTASICod_Internalname;
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
                           E11772 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12772 ();
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
            E12772 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7771( ) ;
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
            DisableAttributes7771( ) ;
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

      protected void CONFIRM_770( )
      {
         BeforeValidate7771( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7771( ) ;
            }
            else
            {
               CheckExtendedTable7771( ) ;
               CloseExtendedTableCursors7771( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption770( )
      {
      }

      protected void E11772( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtTASICod_Visible = 0;
         AssignProp("", false, edtTASICod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTASICod_Visible), 5, 0), true);
      }

      protected void E12772( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Tipo de Asiento N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A126TASICod), 10, 0)) + " " + StringUtil.Trim( A1895TASIDsc);
            AV15Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A126TASICod), 10, 0));
            GXt_char1 = "CON";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV15Codigo, ref  AV15Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.tipoasientosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM7771( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1895TASIDsc = T00773_A1895TASIDsc[0];
               Z1894TASIAbr = T00773_A1894TASIAbr[0];
               Z1896TASISts = T00773_A1896TASISts[0];
            }
            else
            {
               Z1895TASIDsc = A1895TASIDsc;
               Z1894TASIAbr = A1894TASIAbr;
               Z1896TASISts = A1896TASISts;
            }
         }
         if ( GX_JID == -9 )
         {
            Z126TASICod = A126TASICod;
            Z1895TASIDsc = A1895TASIDsc;
            Z1894TASIAbr = A1894TASIAbr;
            Z1896TASISts = A1896TASISts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TASICod) )
         {
            A126TASICod = AV7TASICod;
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         }
         if ( ! (0==AV7TASICod) )
         {
            edtTASICod_Enabled = 0;
            AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
         }
         else
         {
            edtTASICod_Enabled = 1;
            AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TASICod) )
         {
            edtTASICod_Enabled = 0;
            AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1896TASISts) && ( Gx_BScreen == 0 ) )
         {
            A1896TASISts = 1;
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         }
      }

      protected void Load7771( )
      {
         /* Using cursor T00774 */
         pr_default.execute(2, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound71 = 1;
            A1895TASIDsc = T00774_A1895TASIDsc[0];
            AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
            A1894TASIAbr = T00774_A1894TASIAbr[0];
            AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
            A1896TASISts = T00774_A1896TASISts[0];
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            ZM7771( -9) ;
         }
         pr_default.close(2);
         OnLoadActions7771( ) ;
      }

      protected void OnLoadActions7771( )
      {
      }

      protected void CheckExtendedTable7771( )
      {
         nIsDirty_71 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1895TASIDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo Asiento", "", "", "", "", "", "", "", ""), 1, "TASIDSC");
            AnyError = 1;
            GX_FocusControl = edtTASIDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1894TASIAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura", "", "", "", "", "", "", "", ""), 1, "TASIABR");
            AnyError = 1;
            GX_FocusControl = edtTASIAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7771( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7771( )
      {
         /* Using cursor T00775 */
         pr_default.execute(3, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00773 */
         pr_default.execute(1, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7771( 9) ;
            RcdFound71 = 1;
            A126TASICod = T00773_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A1895TASIDsc = T00773_A1895TASIDsc[0];
            AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
            A1894TASIAbr = T00773_A1894TASIAbr[0];
            AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
            A1896TASISts = T00773_A1896TASISts[0];
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            Z126TASICod = A126TASICod;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7771( ) ;
            if ( AnyError == 1 )
            {
               RcdFound71 = 0;
               InitializeNonKey7771( ) ;
            }
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound71 = 0;
            InitializeNonKey7771( ) ;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7771( ) ;
         if ( RcdFound71 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound71 = 0;
         /* Using cursor T00776 */
         pr_default.execute(4, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00776_A126TASICod[0] < A126TASICod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00776_A126TASICod[0] > A126TASICod ) ) )
            {
               A126TASICod = T00776_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               RcdFound71 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound71 = 0;
         /* Using cursor T00777 */
         pr_default.execute(5, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00777_A126TASICod[0] > A126TASICod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00777_A126TASICod[0] < A126TASICod ) ) )
            {
               A126TASICod = T00777_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               RcdFound71 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7771( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTASIDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7771( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound71 == 1 )
            {
               if ( A126TASICod != Z126TASICod )
               {
                  A126TASICod = Z126TASICod;
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TASICOD");
                  AnyError = 1;
                  GX_FocusControl = edtTASICod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTASIDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7771( ) ;
                  GX_FocusControl = edtTASIDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A126TASICod != Z126TASICod )
               {
                  /* Insert record */
                  GX_FocusControl = edtTASIDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7771( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TASICOD");
                     AnyError = 1;
                     GX_FocusControl = edtTASICod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTASIDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7771( ) ;
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
         if ( A126TASICod != Z126TASICod )
         {
            A126TASICod = Z126TASICod;
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTASIDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7771( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00772 */
            pr_default.execute(0, new Object[] {A126TASICod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBTIPOASIENTO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1895TASIDsc, T00772_A1895TASIDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1894TASIAbr, T00772_A1894TASIAbr[0]) != 0 ) || ( Z1896TASISts != T00772_A1896TASISts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1895TASIDsc, T00772_A1895TASIDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.tipoasientos:[seudo value changed for attri]"+"TASIDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1895TASIDsc);
                  GXUtil.WriteLogRaw("Current: ",T00772_A1895TASIDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1894TASIAbr, T00772_A1894TASIAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.tipoasientos:[seudo value changed for attri]"+"TASIAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1894TASIAbr);
                  GXUtil.WriteLogRaw("Current: ",T00772_A1894TASIAbr[0]);
               }
               if ( Z1896TASISts != T00772_A1896TASISts[0] )
               {
                  GXUtil.WriteLog("contabilidad.tipoasientos:[seudo value changed for attri]"+"TASISts");
                  GXUtil.WriteLogRaw("Old: ",Z1896TASISts);
                  GXUtil.WriteLogRaw("Current: ",T00772_A1896TASISts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBTIPOASIENTO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7771( )
      {
         BeforeValidate7771( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7771( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7771( 0) ;
            CheckOptimisticConcurrency7771( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7771( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7771( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00778 */
                     pr_default.execute(6, new Object[] {A126TASICod, A1895TASIDsc, A1894TASIAbr, A1896TASISts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBTIPOASIENTO");
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
                           ResetCaption770( ) ;
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
               Load7771( ) ;
            }
            EndLevel7771( ) ;
         }
         CloseExtendedTableCursors7771( ) ;
      }

      protected void Update7771( )
      {
         BeforeValidate7771( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7771( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7771( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7771( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7771( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00779 */
                     pr_default.execute(7, new Object[] {A1895TASIDsc, A1894TASIAbr, A1896TASISts, A126TASICod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBTIPOASIENTO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBTIPOASIENTO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7771( ) ;
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
            EndLevel7771( ) ;
         }
         CloseExtendedTableCursors7771( ) ;
      }

      protected void DeferredUpdate7771( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7771( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7771( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7771( ) ;
            AfterConfirm7771( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7771( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007710 */
                  pr_default.execute(8, new Object[] {A126TASICod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBTIPOASIENTO");
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
         sMode71 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7771( ) ;
         Gx_mode = sMode71;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7771( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007711 */
            pr_default.execute(9, new Object[] {A126TASICod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel7771( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7771( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("contabilidad.tipoasientos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues770( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("contabilidad.tipoasientos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7771( )
      {
         /* Scan By routine */
         /* Using cursor T007712 */
         pr_default.execute(10);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound71 = 1;
            A126TASICod = T007712_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7771( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound71 = 1;
            A126TASICod = T007712_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         }
      }

      protected void ScanEnd7771( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm7771( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cTASICod;
            GXt_char3 = "TIPASIENTO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cTASICod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cTASICod", StringUtil.LTrimStr( (decimal)(AV13cTASICod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A126TASICod = AV13cTASICod;
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         }
      }

      protected void BeforeInsert7771( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7771( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7771( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7771( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7771( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7771( )
      {
         edtTASIDsc_Enabled = 0;
         AssignProp("", false, edtTASIDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASIDsc_Enabled), 5, 0), true);
         edtTASIAbr_Enabled = 0;
         AssignProp("", false, edtTASIAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASIAbr_Enabled), 5, 0), true);
         cmbTASISts.Enabled = 0;
         AssignProp("", false, cmbTASISts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTASISts.Enabled), 5, 0), true);
         edtTASICod_Enabled = 0;
         AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7771( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues770( )
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
         context.AddJavascriptSource("gxcfg.js", "?2022818102705", false, true);
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
         GXEncryptionTmp = "contabilidad.tipoasientos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TASICod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.tipoasientos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoAsientos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\tipoasientos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z126TASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1895TASIDsc", StringUtil.RTrim( Z1895TASIDsc));
         GxWebStd.gx_hidden_field( context, "Z1894TASIAbr", StringUtil.RTrim( Z1894TASIAbr));
         GxWebStd.gx_hidden_field( context, "Z1896TASISts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1896TASISts), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vTASICOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTASICOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TASICod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCTASICOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTASICod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "contabilidad.tipoasientos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TASICod,6,0));
         return formatLink("contabilidad.tipoasientos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.TipoAsientos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Asientos Contables" ;
      }

      protected void InitializeNonKey7771( )
      {
         AV13cTASICod = 0;
         AssignAttri("", false, "AV13cTASICod", StringUtil.LTrimStr( (decimal)(AV13cTASICod), 6, 0));
         A1895TASIDsc = "";
         AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
         A1894TASIAbr = "";
         AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
         A1896TASISts = 1;
         AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         Z1895TASIDsc = "";
         Z1894TASIAbr = "";
         Z1896TASISts = 0;
      }

      protected void InitAll7771( )
      {
         A126TASICod = 0;
         AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         InitializeNonKey7771( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1896TASISts = i1896TASISts;
         AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027020", true, true);
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
         context.AddJavascriptSource("contabilidad/tipoasientos.js", "?20228181027021", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTASIDsc_Internalname = "TASIDSC";
         edtTASIAbr_Internalname = "TASIABR";
         cmbTASISts_Internalname = "TASISTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTASICod_Internalname = "TASICOD";
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
         Form.Caption = "Tipos de Asientos Contables";
         edtTASICod_Jsonclick = "";
         edtTASICod_Enabled = 1;
         edtTASICod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTASISts_Jsonclick = "";
         cmbTASISts.Enabled = 1;
         edtTASIAbr_Jsonclick = "";
         edtTASIAbr_Enabled = 1;
         edtTASIDsc_Jsonclick = "";
         edtTASIDsc_Enabled = 1;
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

      protected void GX4ASACTASICOD7771( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cTASICod;
            GXt_char3 = "TIPASIENTO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cTASICod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cTASICod", StringUtil.LTrimStr( (decimal)(AV13cTASICod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTASICod), 6, 0, ".", "")))+"\"") ;
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
         cmbTASISts.Name = "TASISTS";
         cmbTASISts.WebTags = "";
         cmbTASISts.addItem("1", "ACTIVO", 0);
         cmbTASISts.addItem("0", "INACTIVO", 0);
         if ( cmbTASISts.ItemCount > 0 )
         {
            if ( (0==A1896TASISts) )
            {
               A1896TASISts = 1;
               AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TASICod',fld:'vTASICOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TASICod',fld:'vTASICOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12772',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A1895TASIDsc',fld:'TASIDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TASIDSC","{handler:'Valid_Tasidsc',iparms:[]");
         setEventMetadata("VALID_TASIDSC",",oparms:[]}");
         setEventMetadata("VALID_TASIABR","{handler:'Valid_Tasiabr',iparms:[]");
         setEventMetadata("VALID_TASIABR",",oparms:[]}");
         setEventMetadata("VALID_TASICOD","{handler:'Valid_Tasicod',iparms:[]");
         setEventMetadata("VALID_TASICOD",",oparms:[]}");
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
         Z1895TASIDsc = "";
         Z1894TASIAbr = "";
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
         A1895TASIDsc = "";
         A1894TASIAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode71 = "";
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
         T00774_A126TASICod = new int[1] ;
         T00774_A1895TASIDsc = new string[] {""} ;
         T00774_A1894TASIAbr = new string[] {""} ;
         T00774_A1896TASISts = new short[1] ;
         T00775_A126TASICod = new int[1] ;
         T00773_A126TASICod = new int[1] ;
         T00773_A1895TASIDsc = new string[] {""} ;
         T00773_A1894TASIAbr = new string[] {""} ;
         T00773_A1896TASISts = new short[1] ;
         T00776_A126TASICod = new int[1] ;
         T00777_A126TASICod = new int[1] ;
         T00772_A126TASICod = new int[1] ;
         T00772_A1895TASIDsc = new string[] {""} ;
         T00772_A1894TASIAbr = new string[] {""} ;
         T00772_A1896TASISts = new short[1] ;
         T007711_A127VouAno = new short[1] ;
         T007711_A128VouMes = new short[1] ;
         T007711_A126TASICod = new int[1] ;
         T007711_A129VouNum = new string[] {""} ;
         T007712_A126TASICod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoasientos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoasientos__default(),
            new Object[][] {
                new Object[] {
               T00772_A126TASICod, T00772_A1895TASIDsc, T00772_A1894TASIAbr, T00772_A1896TASISts
               }
               , new Object[] {
               T00773_A126TASICod, T00773_A1895TASIDsc, T00773_A1894TASIAbr, T00773_A1896TASISts
               }
               , new Object[] {
               T00774_A126TASICod, T00774_A1895TASIDsc, T00774_A1894TASIAbr, T00774_A1896TASISts
               }
               , new Object[] {
               T00775_A126TASICod
               }
               , new Object[] {
               T00776_A126TASICod
               }
               , new Object[] {
               T00777_A126TASICod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007711_A127VouAno, T007711_A128VouMes, T007711_A126TASICod, T007711_A129VouNum
               }
               , new Object[] {
               T007712_A126TASICod
               }
            }
         );
         Z1896TASISts = 1;
         A1896TASISts = 1;
         i1896TASISts = 1;
      }

      private short Z1896TASISts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1896TASISts ;
      private short Gx_BScreen ;
      private short RcdFound71 ;
      private short GX_JID ;
      private short nIsDirty_71 ;
      private short gxajaxcallmode ;
      private short i1896TASISts ;
      private int wcpOAV7TASICod ;
      private int Z126TASICod ;
      private int AV7TASICod ;
      private int trnEnded ;
      private int edtTASIDsc_Enabled ;
      private int edtTASIAbr_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A126TASICod ;
      private int edtTASICod_Visible ;
      private int edtTASICod_Enabled ;
      private int AV13cTASICod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1895TASIDsc ;
      private string Z1894TASIAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTASIDsc_Internalname ;
      private string cmbTASISts_Internalname ;
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
      private string A1895TASIDsc ;
      private string edtTASIDsc_Jsonclick ;
      private string edtTASIAbr_Internalname ;
      private string A1894TASIAbr ;
      private string edtTASIAbr_Jsonclick ;
      private string cmbTASISts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTASICod_Internalname ;
      private string edtTASICod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode71 ;
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
      private GXCombobox cmbTASISts ;
      private IDataStoreProvider pr_default ;
      private int[] T00774_A126TASICod ;
      private string[] T00774_A1895TASIDsc ;
      private string[] T00774_A1894TASIAbr ;
      private short[] T00774_A1896TASISts ;
      private int[] T00775_A126TASICod ;
      private int[] T00773_A126TASICod ;
      private string[] T00773_A1895TASIDsc ;
      private string[] T00773_A1894TASIAbr ;
      private short[] T00773_A1896TASISts ;
      private int[] T00776_A126TASICod ;
      private int[] T00777_A126TASICod ;
      private int[] T00772_A126TASICod ;
      private string[] T00772_A1895TASIDsc ;
      private string[] T00772_A1894TASIAbr ;
      private short[] T00772_A1896TASISts ;
      private short[] T007711_A127VouAno ;
      private short[] T007711_A128VouMes ;
      private int[] T007711_A126TASICod ;
      private string[] T007711_A129VouNum ;
      private int[] T007712_A126TASICod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class tipoasientos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tipoasientos__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00774;
        prmT00774 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00775;
        prmT00775 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00773;
        prmT00773 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00776;
        prmT00776 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00777;
        prmT00777 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00772;
        prmT00772 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00778;
        prmT00778 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@TASIDsc",GXType.NChar,100,0) ,
        new ParDef("@TASIAbr",GXType.NChar,5,0) ,
        new ParDef("@TASISts",GXType.Int16,1,0)
        };
        Object[] prmT00779;
        prmT00779 = new Object[] {
        new ParDef("@TASIDsc",GXType.NChar,100,0) ,
        new ParDef("@TASIAbr",GXType.NChar,5,0) ,
        new ParDef("@TASISts",GXType.Int16,1,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT007710;
        prmT007710 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT007711;
        prmT007711 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT007712;
        prmT007712 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00772", "SELECT [TASICod], [TASIDsc], [TASIAbr], [TASISts] FROM [CBTIPOASIENTO] WITH (UPDLOCK) WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00772,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00773", "SELECT [TASICod], [TASIDsc], [TASIAbr], [TASISts] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00773,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00774", "SELECT TM1.[TASICod], TM1.[TASIDsc], TM1.[TASIAbr], TM1.[TASISts] FROM [CBTIPOASIENTO] TM1 WHERE TM1.[TASICod] = @TASICod ORDER BY TM1.[TASICod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00774,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00775", "SELECT [TASICod] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00775,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00776", "SELECT TOP 1 [TASICod] FROM [CBTIPOASIENTO] WHERE ( [TASICod] > @TASICod) ORDER BY [TASICod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00776,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00777", "SELECT TOP 1 [TASICod] FROM [CBTIPOASIENTO] WHERE ( [TASICod] < @TASICod) ORDER BY [TASICod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00777,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00778", "INSERT INTO [CBTIPOASIENTO]([TASICod], [TASIDsc], [TASIAbr], [TASISts], [TASISunat]) VALUES(@TASICod, @TASIDsc, @TASIAbr, @TASISts, '')", GxErrorMask.GX_NOMASK,prmT00778)
           ,new CursorDef("T00779", "UPDATE [CBTIPOASIENTO] SET [TASIDsc]=@TASIDsc, [TASIAbr]=@TASIAbr, [TASISts]=@TASISts  WHERE [TASICod] = @TASICod", GxErrorMask.GX_NOMASK,prmT00779)
           ,new CursorDef("T007710", "DELETE FROM [CBTIPOASIENTO]  WHERE [TASICod] = @TASICod", GxErrorMask.GX_NOMASK,prmT007710)
           ,new CursorDef("T007711", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007711,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007712", "SELECT [TASICod] FROM [CBTIPOASIENTO] ORDER BY [TASICod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007712,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
