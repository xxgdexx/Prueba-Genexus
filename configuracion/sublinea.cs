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
   public class sublinea : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCSUBLCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACSUBLCOD5M128( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.sublinea.aspx")), "configuracion.sublinea.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.sublinea.aspx")))) ;
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
                  AV7SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AssignAttri("", false, "AV7SublCod", StringUtil.LTrimStr( (decimal)(AV7SublCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUBLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SublCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Sub Linea Productos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSublDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sublinea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sublinea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SublCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SublCod = aP1_SublCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSublDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSublDsc_Internalname, "Sub Linea", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublDsc_Internalname, StringUtil.RTrim( A1892SublDsc), StringUtil.RTrim( context.localUtil.Format( A1892SublDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtSublDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\SubLinea.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSublAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSublAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublAbr_Internalname, StringUtil.RTrim( A1891SublAbr), StringUtil.RTrim( context.localUtil.Format( A1891SublAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\SubLinea.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSublSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSublSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1893SublSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtSublSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1893SublSts), "9") : context.localUtil.Format( (decimal)(A1893SublSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\SubLinea.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\SubLinea.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\SubLinea.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\SubLinea.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSublCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublCod_Jsonclick, 0, "Attribute", "", "", "", "", edtSublCod_Visible, edtSublCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\SubLinea.htm");
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
         E115M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z51SublCod = (int)(context.localUtil.CToN( cgiGet( "Z51SublCod"), ".", ","));
               Z1892SublDsc = cgiGet( "Z1892SublDsc");
               Z1891SublAbr = cgiGet( "Z1891SublAbr");
               Z1893SublSts = (short)(context.localUtil.CToN( cgiGet( "Z1893SublSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7SublCod = (int)(context.localUtil.CToN( cgiGet( "vSUBLCOD"), ".", ","));
               AV13cSubLCod = (int)(context.localUtil.CToN( cgiGet( "vCSUBLCOD"), ".", ","));
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
               A1892SublDsc = cgiGet( edtSublDsc_Internalname);
               AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
               A1891SublAbr = cgiGet( edtSublAbr_Internalname);
               AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSublSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSublSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUBLSTS");
                  AnyError = 1;
                  GX_FocusControl = edtSublSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1893SublSts = 0;
                  AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
               }
               else
               {
                  A1893SublSts = (short)(context.localUtil.CToN( cgiGet( edtSublSts_Internalname), ".", ","));
                  AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUBLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A51SublCod = 0;
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
               else
               {
                  A51SublCod = (int)(context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ","));
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SubLinea");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A51SublCod != Z51SublCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\sublinea:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A51SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
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
                     sMode128 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode128;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound128 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUBLCOD");
                        AnyError = 1;
                        GX_FocusControl = edtSublCod_Internalname;
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
                           E115M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125M2 ();
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
            E125M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5M128( ) ;
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
            DisableAttributes5M128( ) ;
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

      protected void CONFIRM_5M0( )
      {
         BeforeValidate5M128( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5M128( ) ;
            }
            else
            {
               CheckExtendedTable5M128( ) ;
               CloseExtendedTableCursors5M128( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5M0( )
      {
      }

      protected void E115M2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtSublCod_Visible = 0;
         AssignProp("", false, edtSublCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSublCod_Visible), 5, 0), true);
      }

      protected void E125M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV15SGAuDocGls = "Sub Linea N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 10, 0)) + " " + StringUtil.Trim( A1892SublDsc);
            AV14Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV15SGAuDocGls, ref  AV14Codigo, ref  AV14Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.sublineaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5M128( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1892SublDsc = T005M3_A1892SublDsc[0];
               Z1891SublAbr = T005M3_A1891SublAbr[0];
               Z1893SublSts = T005M3_A1893SublSts[0];
            }
            else
            {
               Z1892SublDsc = A1892SublDsc;
               Z1891SublAbr = A1891SublAbr;
               Z1893SublSts = A1893SublSts;
            }
         }
         if ( GX_JID == -8 )
         {
            Z51SublCod = A51SublCod;
            Z1892SublDsc = A1892SublDsc;
            Z1891SublAbr = A1891SublAbr;
            Z1893SublSts = A1893SublSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SublCod) )
         {
            A51SublCod = AV7SublCod;
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
         if ( ! (0==AV7SublCod) )
         {
            edtSublCod_Enabled = 0;
            AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         }
         else
         {
            edtSublCod_Enabled = 1;
            AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7SublCod) )
         {
            edtSublCod_Enabled = 0;
            AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1893SublSts) && ( Gx_BScreen == 0 ) )
         {
            A1893SublSts = 1;
            AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
         }
      }

      protected void Load5M128( )
      {
         /* Using cursor T005M4 */
         pr_default.execute(2, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound128 = 1;
            A1892SublDsc = T005M4_A1892SublDsc[0];
            AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
            A1891SublAbr = T005M4_A1891SublAbr[0];
            AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
            A1893SublSts = T005M4_A1893SublSts[0];
            AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
            ZM5M128( -8) ;
         }
         pr_default.close(2);
         OnLoadActions5M128( ) ;
      }

      protected void OnLoadActions5M128( )
      {
      }

      protected void CheckExtendedTable5M128( )
      {
         nIsDirty_128 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1892SublDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripcion de Sub Linea", "", "", "", "", "", "", "", ""), 1, "SUBLDSC");
            AnyError = 1;
            GX_FocusControl = edtSublDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5M128( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5M128( )
      {
         /* Using cursor T005M5 */
         pr_default.execute(3, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound128 = 1;
         }
         else
         {
            RcdFound128 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005M3 */
         pr_default.execute(1, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5M128( 8) ;
            RcdFound128 = 1;
            A51SublCod = T005M3_A51SublCod[0];
            n51SublCod = T005M3_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            A1892SublDsc = T005M3_A1892SublDsc[0];
            AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
            A1891SublAbr = T005M3_A1891SublAbr[0];
            AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
            A1893SublSts = T005M3_A1893SublSts[0];
            AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
            Z51SublCod = A51SublCod;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5M128( ) ;
            if ( AnyError == 1 )
            {
               RcdFound128 = 0;
               InitializeNonKey5M128( ) ;
            }
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound128 = 0;
            InitializeNonKey5M128( ) ;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5M128( ) ;
         if ( RcdFound128 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound128 = 0;
         /* Using cursor T005M6 */
         pr_default.execute(4, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005M6_A51SublCod[0] < A51SublCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005M6_A51SublCod[0] > A51SublCod ) ) )
            {
               A51SublCod = T005M6_A51SublCod[0];
               n51SublCod = T005M6_n51SublCod[0];
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               RcdFound128 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound128 = 0;
         /* Using cursor T005M7 */
         pr_default.execute(5, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005M7_A51SublCod[0] > A51SublCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005M7_A51SublCod[0] < A51SublCod ) ) )
            {
               A51SublCod = T005M7_A51SublCod[0];
               n51SublCod = T005M7_n51SublCod[0];
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               RcdFound128 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5M128( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSublDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5M128( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound128 == 1 )
            {
               if ( A51SublCod != Z51SublCod )
               {
                  A51SublCod = Z51SublCod;
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUBLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSublDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5M128( ) ;
                  GX_FocusControl = edtSublDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A51SublCod != Z51SublCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtSublDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5M128( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUBLCOD");
                     AnyError = 1;
                     GX_FocusControl = edtSublCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSublDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5M128( ) ;
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
         if ( A51SublCod != Z51SublCod )
         {
            A51SublCod = Z51SublCod;
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUBLCOD");
            AnyError = 1;
            GX_FocusControl = edtSublCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSublDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5M128( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005M2 */
            pr_default.execute(0, new Object[] {n51SublCod, A51SublCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CSUBLPROD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1892SublDsc, T005M2_A1892SublDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1891SublAbr, T005M2_A1891SublAbr[0]) != 0 ) || ( Z1893SublSts != T005M2_A1893SublSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1892SublDsc, T005M2_A1892SublDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.sublinea:[seudo value changed for attri]"+"SublDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1892SublDsc);
                  GXUtil.WriteLogRaw("Current: ",T005M2_A1892SublDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1891SublAbr, T005M2_A1891SublAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.sublinea:[seudo value changed for attri]"+"SublAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1891SublAbr);
                  GXUtil.WriteLogRaw("Current: ",T005M2_A1891SublAbr[0]);
               }
               if ( Z1893SublSts != T005M2_A1893SublSts[0] )
               {
                  GXUtil.WriteLog("configuracion.sublinea:[seudo value changed for attri]"+"SublSts");
                  GXUtil.WriteLogRaw("Old: ",Z1893SublSts);
                  GXUtil.WriteLogRaw("Current: ",T005M2_A1893SublSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CSUBLPROD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5M128( )
      {
         BeforeValidate5M128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5M128( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5M128( 0) ;
            CheckOptimisticConcurrency5M128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5M128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5M128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005M8 */
                     pr_default.execute(6, new Object[] {n51SublCod, A51SublCod, A1892SublDsc, A1891SublAbr, A1893SublSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CSUBLPROD");
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
                           ResetCaption5M0( ) ;
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
               Load5M128( ) ;
            }
            EndLevel5M128( ) ;
         }
         CloseExtendedTableCursors5M128( ) ;
      }

      protected void Update5M128( )
      {
         BeforeValidate5M128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5M128( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5M128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5M128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5M128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005M9 */
                     pr_default.execute(7, new Object[] {A1892SublDsc, A1891SublAbr, A1893SublSts, n51SublCod, A51SublCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CSUBLPROD");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CSUBLPROD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5M128( ) ;
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
            EndLevel5M128( ) ;
         }
         CloseExtendedTableCursors5M128( ) ;
      }

      protected void DeferredUpdate5M128( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5M128( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5M128( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5M128( ) ;
            AfterConfirm5M128( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5M128( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005M10 */
                  pr_default.execute(8, new Object[] {n51SublCod, A51SublCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CSUBLPROD");
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
         sMode128 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5M128( ) ;
         Gx_mode = sMode128;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5M128( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005M11 */
            pr_default.execute(9, new Object[] {n51SublCod, A51SublCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005M12 */
            pr_default.execute(10, new Object[] {n51SublCod, A51SublCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel5M128( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5M128( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.sublinea",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.sublinea",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5M128( )
      {
         /* Scan By routine */
         /* Using cursor T005M13 */
         pr_default.execute(11);
         RcdFound128 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound128 = 1;
            A51SublCod = T005M13_A51SublCod[0];
            n51SublCod = T005M13_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5M128( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound128 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound128 = 1;
            A51SublCod = T005M13_A51SublCod[0];
            n51SublCod = T005M13_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
      }

      protected void ScanEnd5M128( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm5M128( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cSubLCod;
            GXt_char3 = "SUBLINEAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cSubLCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cSubLCod", StringUtil.LTrimStr( (decimal)(AV13cSubLCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A51SublCod = AV13cSubLCod;
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
      }

      protected void BeforeInsert5M128( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5M128( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5M128( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5M128( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5M128( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5M128( )
      {
         edtSublDsc_Enabled = 0;
         AssignProp("", false, edtSublDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublDsc_Enabled), 5, 0), true);
         edtSublAbr_Enabled = 0;
         AssignProp("", false, edtSublAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublAbr_Enabled), 5, 0), true);
         edtSublSts_Enabled = 0;
         AssignProp("", false, edtSublSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublSts_Enabled), 5, 0), true);
         edtSublCod_Enabled = 0;
         AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5M128( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026362", false, true);
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
         GXEncryptionTmp = "configuracion.sublinea.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SublCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.sublinea.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SubLinea");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\sublinea:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1892SublDsc", StringUtil.RTrim( Z1892SublDsc));
         GxWebStd.gx_hidden_field( context, "Z1891SublAbr", StringUtil.RTrim( Z1891SublAbr));
         GxWebStd.gx_hidden_field( context, "Z1893SublSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1893SublSts), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vSUBLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUBLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SublCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCSUBLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cSubLCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.sublinea.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SublCod,6,0));
         return formatLink("configuracion.sublinea.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.SubLinea" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sub Linea Productos" ;
      }

      protected void InitializeNonKey5M128( )
      {
         AV13cSubLCod = 0;
         AssignAttri("", false, "AV13cSubLCod", StringUtil.LTrimStr( (decimal)(AV13cSubLCod), 6, 0));
         A1892SublDsc = "";
         AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
         A1891SublAbr = "";
         AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
         A1893SublSts = 1;
         AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
         Z1892SublDsc = "";
         Z1891SublAbr = "";
         Z1893SublSts = 0;
      }

      protected void InitAll5M128( )
      {
         A51SublCod = 0;
         n51SublCod = false;
         AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         InitializeNonKey5M128( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1893SublSts = i1893SublSts;
         AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026378", true, true);
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
         context.AddJavascriptSource("configuracion/sublinea.js", "?20228181026378", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSublDsc_Internalname = "SUBLDSC";
         edtSublAbr_Internalname = "SUBLABR";
         edtSublSts_Internalname = "SUBLSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtSublCod_Internalname = "SUBLCOD";
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
         Form.Caption = "Sub Linea Productos";
         edtSublCod_Jsonclick = "";
         edtSublCod_Enabled = 1;
         edtSublCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSublSts_Jsonclick = "";
         edtSublSts_Enabled = 1;
         edtSublAbr_Jsonclick = "";
         edtSublAbr_Enabled = 1;
         edtSublDsc_Jsonclick = "";
         edtSublDsc_Enabled = 1;
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

      protected void GX4ASACSUBLCOD5M128( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cSubLCod;
            GXt_char3 = "SUBLINEAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cSubLCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cSubLCod", StringUtil.LTrimStr( (decimal)(AV13cSubLCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cSubLCod), 6, 0, ".", "")))+"\"") ;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7SublCod',fld:'vSUBLCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SublCod',fld:'vSUBLCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125M2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A51SublCod',fld:'SUBLCOD',pic:'ZZZZZ9'},{av:'A1892SublDsc',fld:'SUBLDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SUBLDSC","{handler:'Valid_Subldsc',iparms:[]");
         setEventMetadata("VALID_SUBLDSC",",oparms:[]}");
         setEventMetadata("VALID_SUBLCOD","{handler:'Valid_Sublcod',iparms:[]");
         setEventMetadata("VALID_SUBLCOD",",oparms:[]}");
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
         Z1892SublDsc = "";
         Z1891SublAbr = "";
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
         A1892SublDsc = "";
         A1891SublAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode128 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15SGAuDocGls = "";
         AV14Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T005M4_A51SublCod = new int[1] ;
         T005M4_n51SublCod = new bool[] {false} ;
         T005M4_A1892SublDsc = new string[] {""} ;
         T005M4_A1891SublAbr = new string[] {""} ;
         T005M4_A1893SublSts = new short[1] ;
         T005M5_A51SublCod = new int[1] ;
         T005M5_n51SublCod = new bool[] {false} ;
         T005M3_A51SublCod = new int[1] ;
         T005M3_n51SublCod = new bool[] {false} ;
         T005M3_A1892SublDsc = new string[] {""} ;
         T005M3_A1891SublAbr = new string[] {""} ;
         T005M3_A1893SublSts = new short[1] ;
         T005M6_A51SublCod = new int[1] ;
         T005M6_n51SublCod = new bool[] {false} ;
         T005M7_A51SublCod = new int[1] ;
         T005M7_n51SublCod = new bool[] {false} ;
         T005M2_A51SublCod = new int[1] ;
         T005M2_n51SublCod = new bool[] {false} ;
         T005M2_A1892SublDsc = new string[] {""} ;
         T005M2_A1891SublAbr = new string[] {""} ;
         T005M2_A1893SublSts = new short[1] ;
         T005M11_A83ParTip = new string[] {""} ;
         T005M11_A84ParCod = new int[1] ;
         T005M11_A104ParDItem = new short[1] ;
         T005M12_A28ProdCod = new string[] {""} ;
         T005M13_A51SublCod = new int[1] ;
         T005M13_n51SublCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.sublinea__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.sublinea__default(),
            new Object[][] {
                new Object[] {
               T005M2_A51SublCod, T005M2_A1892SublDsc, T005M2_A1891SublAbr, T005M2_A1893SublSts
               }
               , new Object[] {
               T005M3_A51SublCod, T005M3_A1892SublDsc, T005M3_A1891SublAbr, T005M3_A1893SublSts
               }
               , new Object[] {
               T005M4_A51SublCod, T005M4_A1892SublDsc, T005M4_A1891SublAbr, T005M4_A1893SublSts
               }
               , new Object[] {
               T005M5_A51SublCod
               }
               , new Object[] {
               T005M6_A51SublCod
               }
               , new Object[] {
               T005M7_A51SublCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005M11_A83ParTip, T005M11_A84ParCod, T005M11_A104ParDItem
               }
               , new Object[] {
               T005M12_A28ProdCod
               }
               , new Object[] {
               T005M13_A51SublCod
               }
            }
         );
         Z1893SublSts = 1;
         A1893SublSts = 1;
         i1893SublSts = 1;
      }

      private short Z1893SublSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1893SublSts ;
      private short Gx_BScreen ;
      private short RcdFound128 ;
      private short GX_JID ;
      private short nIsDirty_128 ;
      private short gxajaxcallmode ;
      private short i1893SublSts ;
      private int wcpOAV7SublCod ;
      private int Z51SublCod ;
      private int AV7SublCod ;
      private int trnEnded ;
      private int edtSublDsc_Enabled ;
      private int edtSublAbr_Enabled ;
      private int edtSublSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A51SublCod ;
      private int edtSublCod_Visible ;
      private int edtSublCod_Enabled ;
      private int AV13cSubLCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1892SublDsc ;
      private string Z1891SublAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSublDsc_Internalname ;
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
      private string A1892SublDsc ;
      private string edtSublDsc_Jsonclick ;
      private string edtSublAbr_Internalname ;
      private string A1891SublAbr ;
      private string edtSublAbr_Jsonclick ;
      private string edtSublSts_Internalname ;
      private string edtSublSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSublCod_Internalname ;
      private string edtSublCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode128 ;
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
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV15SGAuDocGls ;
      private string AV14Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T005M4_A51SublCod ;
      private bool[] T005M4_n51SublCod ;
      private string[] T005M4_A1892SublDsc ;
      private string[] T005M4_A1891SublAbr ;
      private short[] T005M4_A1893SublSts ;
      private int[] T005M5_A51SublCod ;
      private bool[] T005M5_n51SublCod ;
      private int[] T005M3_A51SublCod ;
      private bool[] T005M3_n51SublCod ;
      private string[] T005M3_A1892SublDsc ;
      private string[] T005M3_A1891SublAbr ;
      private short[] T005M3_A1893SublSts ;
      private int[] T005M6_A51SublCod ;
      private bool[] T005M6_n51SublCod ;
      private int[] T005M7_A51SublCod ;
      private bool[] T005M7_n51SublCod ;
      private int[] T005M2_A51SublCod ;
      private bool[] T005M2_n51SublCod ;
      private string[] T005M2_A1892SublDsc ;
      private string[] T005M2_A1891SublAbr ;
      private short[] T005M2_A1893SublSts ;
      private string[] T005M11_A83ParTip ;
      private int[] T005M11_A84ParCod ;
      private short[] T005M11_A104ParDItem ;
      private string[] T005M12_A28ProdCod ;
      private int[] T005M13_A51SublCod ;
      private bool[] T005M13_n51SublCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class sublinea__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sublinea__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT005M4;
        prmT005M4 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M5;
        prmT005M5 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M3;
        prmT005M3 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M6;
        prmT005M6 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M7;
        prmT005M7 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M2;
        prmT005M2 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M8;
        prmT005M8 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@SublDsc",GXType.NChar,100,0) ,
        new ParDef("@SublAbr",GXType.NChar,5,0) ,
        new ParDef("@SublSts",GXType.Int16,1,0)
        };
        Object[] prmT005M9;
        prmT005M9 = new Object[] {
        new ParDef("@SublDsc",GXType.NChar,100,0) ,
        new ParDef("@SublAbr",GXType.NChar,5,0) ,
        new ParDef("@SublSts",GXType.Int16,1,0) ,
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M10;
        prmT005M10 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M11;
        prmT005M11 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M12;
        prmT005M12 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005M13;
        prmT005M13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005M2", "SELECT [SublCod], [SublDsc], [SublAbr], [SublSts] FROM [CSUBLPROD] WITH (UPDLOCK) WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005M3", "SELECT [SublCod], [SublDsc], [SublAbr], [SublSts] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005M4", "SELECT TM1.[SublCod], TM1.[SublDsc], TM1.[SublAbr], TM1.[SublSts] FROM [CSUBLPROD] TM1 WHERE TM1.[SublCod] = @SublCod ORDER BY TM1.[SublCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005M5", "SELECT [SublCod] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005M6", "SELECT TOP 1 [SublCod] FROM [CSUBLPROD] WHERE ( [SublCod] > @SublCod) ORDER BY [SublCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005M6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005M7", "SELECT TOP 1 [SublCod] FROM [CSUBLPROD] WHERE ( [SublCod] < @SublCod) ORDER BY [SublCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005M7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005M8", "INSERT INTO [CSUBLPROD]([SublCod], [SublDsc], [SublAbr], [SublSts]) VALUES(@SublCod, @SublDsc, @SublAbr, @SublSts)", GxErrorMask.GX_NOMASK,prmT005M8)
           ,new CursorDef("T005M9", "UPDATE [CSUBLPROD] SET [SublDsc]=@SublDsc, [SublAbr]=@SublAbr, [SublSts]=@SublSts  WHERE [SublCod] = @SublCod", GxErrorMask.GX_NOMASK,prmT005M9)
           ,new CursorDef("T005M10", "DELETE FROM [CSUBLPROD]  WHERE [SublCod] = @SublCod", GxErrorMask.GX_NOMASK,prmT005M10)
           ,new CursorDef("T005M11", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDSubProd] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005M11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005M12", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005M12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005M13", "SELECT [SublCod] FROM [CSUBLPROD] ORDER BY [SublCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005M13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
