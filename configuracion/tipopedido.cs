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
   public class tipopedido : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"vCTPEDCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASACTPEDCOD65135( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.tipopedido.aspx")), "configuracion.tipopedido.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.tipopedido.aspx")))) ;
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
                  AV7TPedCod = (int)(NumberUtil.Val( GetPar( "TPedCod"), "."));
                  AssignAttri("", false, "AV7TPedCod", StringUtil.LTrimStr( (decimal)(AV7TPedCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTPEDCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TPedCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tipos de Pedidos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTPedDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipopedido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipopedido( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TPedCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TPedCod = aP1_TPedCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkTPedGuia = new GXCheckbox();
         chkTPedFac = new GXCheckbox();
         chkTPedPer = new GXCheckbox();
         cmbTPedSts = new GXCombobox();
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
         A1933TPedGuia = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1933TPedGuia), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
         A1932TPedFac = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1932TPedFac), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
         A1935TPedPer = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1935TPedPer), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
         if ( cmbTPedSts.ItemCount > 0 )
         {
            A1936TPedSts = (short)(NumberUtil.Val( cmbTPedSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0))), "."));
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTPedSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            AssignProp("", false, cmbTPedSts_Internalname, "Values", cmbTPedSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTPedDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTPedDsc_Internalname, "Tipo de Pedidos", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedDsc_Internalname, StringUtil.RTrim( A1931TPedDsc), StringUtil.RTrim( context.localUtil.Format( A1931TPedDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTPedDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoPedido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTPedGuia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTPedGuia_Internalname, "Afecta Guia", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTPedGuia_Internalname, StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0), "", "Afecta Guia", 1, chkTPedGuia.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTPedFac_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTPedFac_Internalname, "Afecta Factura", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTPedFac_Internalname, StringUtil.Str( (decimal)(A1932TPedFac), 1, 0), "", "Afecta Factura", 1, chkTPedFac.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(32, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTPedPer_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTPedPer_Internalname, "Afecta Percepción", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTPedPer_Internalname, StringUtil.Str( (decimal)(A1935TPedPer), 1, 0), "", "Afecta Percepción", 1, chkTPedPer.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtpedmovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktpedmovcod_Internalname, "Movimiento Almacen", "", "", lblTextblocktpedmovcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoPedido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tpedmovcod.SetProperty("Caption", Combo_tpedmovcod_Caption);
         ucCombo_tpedmovcod.SetProperty("Cls", Combo_tpedmovcod_Cls);
         ucCombo_tpedmovcod.SetProperty("DropDownOptionsData", AV11TPedMovCod_Data);
         ucCombo_tpedmovcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tpedmovcod_Internalname, "COMBO_TPEDMOVCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTPedMovCod_Internalname, "Tipo Movimiento Almacen", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1934TPedMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTPedMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1934TPedMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1934TPedMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedMovCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTPedMovCod_Visible, edtTPedMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoPedido.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTPedSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTPedSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTPedSts, cmbTPedSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0)), 1, cmbTPedSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTPedSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 1, "HLP_Configuracion\\TipoPedido.htm");
         cmbTPedSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         AssignProp("", false, cmbTPedSts_Internalname, "Values", (string)(cmbTPedSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoPedido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoPedido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoPedido.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_tpedmovcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotpedmovcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ComboTPedMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotpedmovcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13ComboTPedMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV13ComboTPedMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotpedmovcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotpedmovcod_Visible, edtavCombotpedmovcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoPedido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212TPedCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A212TPedCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTPedCod_Visible, edtTPedCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoPedido.htm");
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
         E11652 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vTPEDMOVCOD_DATA"), AV11TPedMovCod_Data);
               /* Read saved values. */
               Z212TPedCod = (int)(context.localUtil.CToN( cgiGet( "Z212TPedCod"), ".", ","));
               Z1934TPedMovCod = (int)(context.localUtil.CToN( cgiGet( "Z1934TPedMovCod"), ".", ","));
               Z1931TPedDsc = cgiGet( "Z1931TPedDsc");
               Z1933TPedGuia = (short)(context.localUtil.CToN( cgiGet( "Z1933TPedGuia"), ".", ","));
               Z1932TPedFac = (short)(context.localUtil.CToN( cgiGet( "Z1932TPedFac"), ".", ","));
               Z1935TPedPer = (short)(context.localUtil.CToN( cgiGet( "Z1935TPedPer"), ".", ","));
               Z1936TPedSts = (short)(context.localUtil.CToN( cgiGet( "Z1936TPedSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TPedCod = (int)(context.localUtil.CToN( cgiGet( "vTPEDCOD"), ".", ","));
               AV14cTPedCod = (int)(context.localUtil.CToN( cgiGet( "vCTPEDCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               Combo_tpedmovcod_Objectcall = cgiGet( "COMBO_TPEDMOVCOD_Objectcall");
               Combo_tpedmovcod_Class = cgiGet( "COMBO_TPEDMOVCOD_Class");
               Combo_tpedmovcod_Icontype = cgiGet( "COMBO_TPEDMOVCOD_Icontype");
               Combo_tpedmovcod_Icon = cgiGet( "COMBO_TPEDMOVCOD_Icon");
               Combo_tpedmovcod_Caption = cgiGet( "COMBO_TPEDMOVCOD_Caption");
               Combo_tpedmovcod_Tooltip = cgiGet( "COMBO_TPEDMOVCOD_Tooltip");
               Combo_tpedmovcod_Cls = cgiGet( "COMBO_TPEDMOVCOD_Cls");
               Combo_tpedmovcod_Selectedvalue_set = cgiGet( "COMBO_TPEDMOVCOD_Selectedvalue_set");
               Combo_tpedmovcod_Selectedvalue_get = cgiGet( "COMBO_TPEDMOVCOD_Selectedvalue_get");
               Combo_tpedmovcod_Selectedtext_set = cgiGet( "COMBO_TPEDMOVCOD_Selectedtext_set");
               Combo_tpedmovcod_Selectedtext_get = cgiGet( "COMBO_TPEDMOVCOD_Selectedtext_get");
               Combo_tpedmovcod_Gamoauthtoken = cgiGet( "COMBO_TPEDMOVCOD_Gamoauthtoken");
               Combo_tpedmovcod_Ddointernalname = cgiGet( "COMBO_TPEDMOVCOD_Ddointernalname");
               Combo_tpedmovcod_Titlecontrolalign = cgiGet( "COMBO_TPEDMOVCOD_Titlecontrolalign");
               Combo_tpedmovcod_Dropdownoptionstype = cgiGet( "COMBO_TPEDMOVCOD_Dropdownoptionstype");
               Combo_tpedmovcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Enabled"));
               Combo_tpedmovcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Visible"));
               Combo_tpedmovcod_Titlecontrolidtoreplace = cgiGet( "COMBO_TPEDMOVCOD_Titlecontrolidtoreplace");
               Combo_tpedmovcod_Datalisttype = cgiGet( "COMBO_TPEDMOVCOD_Datalisttype");
               Combo_tpedmovcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Allowmultipleselection"));
               Combo_tpedmovcod_Datalistfixedvalues = cgiGet( "COMBO_TPEDMOVCOD_Datalistfixedvalues");
               Combo_tpedmovcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Isgriditem"));
               Combo_tpedmovcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Hasdescription"));
               Combo_tpedmovcod_Datalistproc = cgiGet( "COMBO_TPEDMOVCOD_Datalistproc");
               Combo_tpedmovcod_Datalistprocparametersprefix = cgiGet( "COMBO_TPEDMOVCOD_Datalistprocparametersprefix");
               Combo_tpedmovcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TPEDMOVCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tpedmovcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Includeonlyselectedoption"));
               Combo_tpedmovcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Includeselectalloption"));
               Combo_tpedmovcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Emptyitem"));
               Combo_tpedmovcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TPEDMOVCOD_Includeaddnewoption"));
               Combo_tpedmovcod_Htmltemplate = cgiGet( "COMBO_TPEDMOVCOD_Htmltemplate");
               Combo_tpedmovcod_Multiplevaluestype = cgiGet( "COMBO_TPEDMOVCOD_Multiplevaluestype");
               Combo_tpedmovcod_Loadingdata = cgiGet( "COMBO_TPEDMOVCOD_Loadingdata");
               Combo_tpedmovcod_Noresultsfound = cgiGet( "COMBO_TPEDMOVCOD_Noresultsfound");
               Combo_tpedmovcod_Emptyitemtext = cgiGet( "COMBO_TPEDMOVCOD_Emptyitemtext");
               Combo_tpedmovcod_Onlyselectedvalues = cgiGet( "COMBO_TPEDMOVCOD_Onlyselectedvalues");
               Combo_tpedmovcod_Selectalltext = cgiGet( "COMBO_TPEDMOVCOD_Selectalltext");
               Combo_tpedmovcod_Multiplevaluesseparator = cgiGet( "COMBO_TPEDMOVCOD_Multiplevaluesseparator");
               Combo_tpedmovcod_Addnewoptiontext = cgiGet( "COMBO_TPEDMOVCOD_Addnewoptiontext");
               Combo_tpedmovcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TPEDMOVCOD_Gxcontroltype"), ".", ","));
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
               A1931TPedDsc = cgiGet( edtTPedDsc_Internalname);
               AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTPedGuia_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTPedGuia_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDGUIA");
                  AnyError = 1;
                  GX_FocusControl = chkTPedGuia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1933TPedGuia = 0;
                  AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
               }
               else
               {
                  A1933TPedGuia = (short)(((StringUtil.StrCmp(cgiGet( chkTPedGuia_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTPedFac_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTPedFac_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDFAC");
                  AnyError = 1;
                  GX_FocusControl = chkTPedFac_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1932TPedFac = 0;
                  AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
               }
               else
               {
                  A1932TPedFac = (short)(((StringUtil.StrCmp(cgiGet( chkTPedFac_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTPedPer_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTPedPer_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDPER");
                  AnyError = 1;
                  GX_FocusControl = chkTPedPer_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1935TPedPer = 0;
                  AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
               }
               else
               {
                  A1935TPedPer = (short)(((StringUtil.StrCmp(cgiGet( chkTPedPer_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTPedMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPedMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDMOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPedMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1934TPedMovCod = 0;
                  AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
               }
               else
               {
                  A1934TPedMovCod = (int)(context.localUtil.CToN( cgiGet( edtTPedMovCod_Internalname), ".", ","));
                  AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
               }
               cmbTPedSts.CurrentValue = cgiGet( cmbTPedSts_Internalname);
               A1936TPedSts = (short)(NumberUtil.Val( cgiGet( cmbTPedSts_Internalname), "."));
               AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
               AV13ComboTPedMovCod = (int)(context.localUtil.CToN( cgiGet( edtavCombotpedmovcod_Internalname), ".", ","));
               AssignAttri("", false, "AV13ComboTPedMovCod", StringUtil.LTrimStr( (decimal)(AV13ComboTPedMovCod), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A212TPedCod = 0;
                  AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               }
               else
               {
                  A212TPedCod = (int)(context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ","));
                  AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoPedido");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A212TPedCod != Z212TPedCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\tipopedido:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A212TPedCod = (int)(NumberUtil.Val( GetPar( "TPedCod"), "."));
                  AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
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
                     sMode135 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode135;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound135 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_650( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TPEDCOD");
                        AnyError = 1;
                        GX_FocusControl = edtTPedCod_Internalname;
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
                           E11652 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12652 ();
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
            E12652 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll65135( ) ;
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
            DisableAttributes65135( ) ;
         }
         AssignProp("", false, edtavCombotpedmovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotpedmovcod_Enabled), 5, 0), true);
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

      protected void CONFIRM_650( )
      {
         BeforeValidate65135( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls65135( ) ;
            }
            else
            {
               CheckExtendedTable65135( ) ;
               CloseExtendedTableCursors65135( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption650( )
      {
      }

      protected void E11652( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtTPedMovCod_Visible = 0;
         AssignProp("", false, edtTPedMovCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTPedMovCod_Visible), 5, 0), true);
         AV13ComboTPedMovCod = 0;
         AssignAttri("", false, "AV13ComboTPedMovCod", StringUtil.LTrimStr( (decimal)(AV13ComboTPedMovCod), 6, 0));
         edtavCombotpedmovcod_Visible = 0;
         AssignProp("", false, edtavCombotpedmovcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotpedmovcod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTPEDMOVCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtTPedCod_Visible = 0;
         AssignProp("", false, edtTPedCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTPedCod_Visible), 5, 0), true);
      }

      protected void E12652( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV15SGAuDocGls = "Tipo de Pedido N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A212TPedCod), 10, 0)) + " " + StringUtil.Trim( A1931TPedDsc);
            AV16Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A212TPedCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV15SGAuDocGls, ref  AV16Codigo, ref  AV16Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.tipopedidoww.aspx") );
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
         /* 'LOADCOMBOTPEDMOVCOD' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item4 = AV11TPedMovCod_Data;
         new GeneXus.Programs.configuracion.tipopedidoloaddvcombo(context ).execute(  "TPedMovCod",  Gx_mode,  AV7TPedCod, out  AV12ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item4) ;
         AV11TPedMovCod_Data = GXt_objcol_SdtDVB_SDTComboData_Item4;
         Combo_tpedmovcod_Selectedvalue_set = AV12ComboSelectedValue;
         ucCombo_tpedmovcod.SendProperty(context, "", false, Combo_tpedmovcod_Internalname, "SelectedValue_set", Combo_tpedmovcod_Selectedvalue_set);
         AV13ComboTPedMovCod = (int)(NumberUtil.Val( AV12ComboSelectedValue, "."));
         AssignAttri("", false, "AV13ComboTPedMovCod", StringUtil.LTrimStr( (decimal)(AV13ComboTPedMovCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tpedmovcod_Enabled = false;
            ucCombo_tpedmovcod.SendProperty(context, "", false, Combo_tpedmovcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tpedmovcod_Enabled));
         }
      }

      protected void ZM65135( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1934TPedMovCod = T00653_A1934TPedMovCod[0];
               Z1931TPedDsc = T00653_A1931TPedDsc[0];
               Z1933TPedGuia = T00653_A1933TPedGuia[0];
               Z1932TPedFac = T00653_A1932TPedFac[0];
               Z1935TPedPer = T00653_A1935TPedPer[0];
               Z1936TPedSts = T00653_A1936TPedSts[0];
            }
            else
            {
               Z1934TPedMovCod = A1934TPedMovCod;
               Z1931TPedDsc = A1931TPedDsc;
               Z1933TPedGuia = A1933TPedGuia;
               Z1932TPedFac = A1932TPedFac;
               Z1935TPedPer = A1935TPedPer;
               Z1936TPedSts = A1936TPedSts;
            }
         }
         if ( GX_JID == -9 )
         {
            Z212TPedCod = A212TPedCod;
            Z1934TPedMovCod = A1934TPedMovCod;
            Z1931TPedDsc = A1931TPedDsc;
            Z1933TPedGuia = A1933TPedGuia;
            Z1932TPedFac = A1932TPedFac;
            Z1935TPedPer = A1935TPedPer;
            Z1936TPedSts = A1936TPedSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TPedCod) )
         {
            A212TPedCod = AV7TPedCod;
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         }
         if ( ! (0==AV7TPedCod) )
         {
            edtTPedCod_Enabled = 0;
            AssignProp("", false, edtTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTPedCod_Enabled = 1;
            AssignProp("", false, edtTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TPedCod) )
         {
            edtTPedCod_Enabled = 0;
            AssignProp("", false, edtTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A1934TPedMovCod = AV13ComboTPedMovCod;
         AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
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
         if ( IsIns( )  && (0==A1936TPedSts) && ( Gx_BScreen == 0 ) )
         {
            A1936TPedSts = 1;
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         }
      }

      protected void Load65135( )
      {
         /* Using cursor T00654 */
         pr_default.execute(2, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound135 = 1;
            A1934TPedMovCod = T00654_A1934TPedMovCod[0];
            AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
            A1931TPedDsc = T00654_A1931TPedDsc[0];
            AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
            A1933TPedGuia = T00654_A1933TPedGuia[0];
            AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
            A1932TPedFac = T00654_A1932TPedFac[0];
            AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
            A1935TPedPer = T00654_A1935TPedPer[0];
            AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
            A1936TPedSts = T00654_A1936TPedSts[0];
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            ZM65135( -9) ;
         }
         pr_default.close(2);
         OnLoadActions65135( ) ;
      }

      protected void OnLoadActions65135( )
      {
      }

      protected void CheckExtendedTable65135( )
      {
         nIsDirty_135 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1931TPedDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Pedidos", "", "", "", "", "", "", "", ""), 1, "TPEDDSC");
            AnyError = 1;
            GX_FocusControl = edtTPedDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors65135( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey65135( )
      {
         /* Using cursor T00655 */
         pr_default.execute(3, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound135 = 1;
         }
         else
         {
            RcdFound135 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00653 */
         pr_default.execute(1, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM65135( 9) ;
            RcdFound135 = 1;
            A212TPedCod = T00653_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            A1934TPedMovCod = T00653_A1934TPedMovCod[0];
            AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
            A1931TPedDsc = T00653_A1931TPedDsc[0];
            AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
            A1933TPedGuia = T00653_A1933TPedGuia[0];
            AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
            A1932TPedFac = T00653_A1932TPedFac[0];
            AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
            A1935TPedPer = T00653_A1935TPedPer[0];
            AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
            A1936TPedSts = T00653_A1936TPedSts[0];
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            Z212TPedCod = A212TPedCod;
            sMode135 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load65135( ) ;
            if ( AnyError == 1 )
            {
               RcdFound135 = 0;
               InitializeNonKey65135( ) ;
            }
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound135 = 0;
            InitializeNonKey65135( ) ;
            sMode135 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey65135( ) ;
         if ( RcdFound135 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound135 = 0;
         /* Using cursor T00656 */
         pr_default.execute(4, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00656_A212TPedCod[0] < A212TPedCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00656_A212TPedCod[0] > A212TPedCod ) ) )
            {
               A212TPedCod = T00656_A212TPedCod[0];
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               RcdFound135 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound135 = 0;
         /* Using cursor T00657 */
         pr_default.execute(5, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00657_A212TPedCod[0] > A212TPedCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00657_A212TPedCod[0] < A212TPedCod ) ) )
            {
               A212TPedCod = T00657_A212TPedCod[0];
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               RcdFound135 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey65135( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTPedDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert65135( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound135 == 1 )
            {
               if ( A212TPedCod != Z212TPedCod )
               {
                  A212TPedCod = Z212TPedCod;
                  AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TPEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTPedDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update65135( ) ;
                  GX_FocusControl = edtTPedDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A212TPedCod != Z212TPedCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtTPedDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert65135( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPEDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTPedDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert65135( ) ;
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
         if ( A212TPedCod != Z212TPedCod )
         {
            A212TPedCod = Z212TPedCod;
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTPedDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency65135( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00652 */
            pr_default.execute(0, new Object[] {A212TPedCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPPEDIDO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1934TPedMovCod != T00652_A1934TPedMovCod[0] ) || ( StringUtil.StrCmp(Z1931TPedDsc, T00652_A1931TPedDsc[0]) != 0 ) || ( Z1933TPedGuia != T00652_A1933TPedGuia[0] ) || ( Z1932TPedFac != T00652_A1932TPedFac[0] ) || ( Z1935TPedPer != T00652_A1935TPedPer[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1936TPedSts != T00652_A1936TPedSts[0] ) )
            {
               if ( Z1934TPedMovCod != T00652_A1934TPedMovCod[0] )
               {
                  GXUtil.WriteLog("configuracion.tipopedido:[seudo value changed for attri]"+"TPedMovCod");
                  GXUtil.WriteLogRaw("Old: ",Z1934TPedMovCod);
                  GXUtil.WriteLogRaw("Current: ",T00652_A1934TPedMovCod[0]);
               }
               if ( StringUtil.StrCmp(Z1931TPedDsc, T00652_A1931TPedDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipopedido:[seudo value changed for attri]"+"TPedDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1931TPedDsc);
                  GXUtil.WriteLogRaw("Current: ",T00652_A1931TPedDsc[0]);
               }
               if ( Z1933TPedGuia != T00652_A1933TPedGuia[0] )
               {
                  GXUtil.WriteLog("configuracion.tipopedido:[seudo value changed for attri]"+"TPedGuia");
                  GXUtil.WriteLogRaw("Old: ",Z1933TPedGuia);
                  GXUtil.WriteLogRaw("Current: ",T00652_A1933TPedGuia[0]);
               }
               if ( Z1932TPedFac != T00652_A1932TPedFac[0] )
               {
                  GXUtil.WriteLog("configuracion.tipopedido:[seudo value changed for attri]"+"TPedFac");
                  GXUtil.WriteLogRaw("Old: ",Z1932TPedFac);
                  GXUtil.WriteLogRaw("Current: ",T00652_A1932TPedFac[0]);
               }
               if ( Z1935TPedPer != T00652_A1935TPedPer[0] )
               {
                  GXUtil.WriteLog("configuracion.tipopedido:[seudo value changed for attri]"+"TPedPer");
                  GXUtil.WriteLogRaw("Old: ",Z1935TPedPer);
                  GXUtil.WriteLogRaw("Current: ",T00652_A1935TPedPer[0]);
               }
               if ( Z1936TPedSts != T00652_A1936TPedSts[0] )
               {
                  GXUtil.WriteLog("configuracion.tipopedido:[seudo value changed for attri]"+"TPedSts");
                  GXUtil.WriteLogRaw("Old: ",Z1936TPedSts);
                  GXUtil.WriteLogRaw("Current: ",T00652_A1936TPedSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPPEDIDO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert65135( )
      {
         BeforeValidate65135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable65135( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM65135( 0) ;
            CheckOptimisticConcurrency65135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm65135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert65135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00658 */
                     pr_default.execute(6, new Object[] {A212TPedCod, A1934TPedMovCod, A1931TPedDsc, A1933TPedGuia, A1932TPedFac, A1935TPedPer, A1936TPedSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPPEDIDO");
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
                           ResetCaption650( ) ;
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
               Load65135( ) ;
            }
            EndLevel65135( ) ;
         }
         CloseExtendedTableCursors65135( ) ;
      }

      protected void Update65135( )
      {
         BeforeValidate65135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable65135( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency65135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm65135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate65135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00659 */
                     pr_default.execute(7, new Object[] {A1934TPedMovCod, A1931TPedDsc, A1933TPedGuia, A1932TPedFac, A1935TPedPer, A1936TPedSts, A212TPedCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPPEDIDO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPPEDIDO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate65135( ) ;
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
            EndLevel65135( ) ;
         }
         CloseExtendedTableCursors65135( ) ;
      }

      protected void DeferredUpdate65135( )
      {
      }

      protected void delete( )
      {
         BeforeValidate65135( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency65135( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls65135( ) ;
            AfterConfirm65135( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete65135( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006510 */
                  pr_default.execute(8, new Object[] {A212TPedCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPPEDIDO");
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
         sMode135 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel65135( ) ;
         Gx_mode = sMode135;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls65135( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006511 */
            pr_default.execute(9, new Object[] {A212TPedCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel65135( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete65135( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.tipopedido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues650( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.tipopedido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart65135( )
      {
         /* Scan By routine */
         /* Using cursor T006512 */
         pr_default.execute(10);
         RcdFound135 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound135 = 1;
            A212TPedCod = T006512_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext65135( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound135 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound135 = 1;
            A212TPedCod = T006512_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         }
      }

      protected void ScanEnd65135( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm65135( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV14cTPedCod;
            GXt_char3 = "TIPPEDIDOS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int5) ;
            AV14cTPedCod = (int)(GXt_int5);
            AssignAttri("", false, "AV14cTPedCod", StringUtil.LTrimStr( (decimal)(AV14cTPedCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A212TPedCod = AV14cTPedCod;
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         }
      }

      protected void BeforeInsert65135( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate65135( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete65135( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete65135( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate65135( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes65135( )
      {
         edtTPedDsc_Enabled = 0;
         AssignProp("", false, edtTPedDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedDsc_Enabled), 5, 0), true);
         chkTPedGuia.Enabled = 0;
         AssignProp("", false, chkTPedGuia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTPedGuia.Enabled), 5, 0), true);
         chkTPedFac.Enabled = 0;
         AssignProp("", false, chkTPedFac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTPedFac.Enabled), 5, 0), true);
         chkTPedPer.Enabled = 0;
         AssignProp("", false, chkTPedPer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTPedPer.Enabled), 5, 0), true);
         edtTPedMovCod_Enabled = 0;
         AssignProp("", false, edtTPedMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedMovCod_Enabled), 5, 0), true);
         cmbTPedSts.Enabled = 0;
         AssignProp("", false, cmbTPedSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTPedSts.Enabled), 5, 0), true);
         edtavCombotpedmovcod_Enabled = 0;
         AssignProp("", false, edtavCombotpedmovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotpedmovcod_Enabled), 5, 0), true);
         edtTPedCod_Enabled = 0;
         AssignProp("", false, edtTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes65135( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues650( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026221", false, true);
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
         GXEncryptionTmp = "configuracion.tipopedido.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TPedCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipopedido.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoPedido");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\tipopedido:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z212TPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212TPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1934TPedMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1934TPedMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1931TPedDsc", StringUtil.RTrim( Z1931TPedDsc));
         GxWebStd.gx_hidden_field( context, "Z1933TPedGuia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1933TPedGuia), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1932TPedFac", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1932TPedFac), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1935TPedPer", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1935TPedPer), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1936TPedSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1936TPedSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTPEDMOVCOD_DATA", AV11TPedMovCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTPEDMOVCOD_DATA", AV11TPedMovCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vTPEDCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTPEDCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TPedCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCTPEDCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cTPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_TPEDMOVCOD_Objectcall", StringUtil.RTrim( Combo_tpedmovcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TPEDMOVCOD_Cls", StringUtil.RTrim( Combo_tpedmovcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TPEDMOVCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tpedmovcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TPEDMOVCOD_Enabled", StringUtil.BoolToStr( Combo_tpedmovcod_Enabled));
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
         GXEncryptionTmp = "configuracion.tipopedido.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TPedCod,6,0));
         return formatLink("configuracion.tipopedido.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoPedido" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Pedidos" ;
      }

      protected void InitializeNonKey65135( )
      {
         A1934TPedMovCod = 0;
         AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
         AV14cTPedCod = 0;
         AssignAttri("", false, "AV14cTPedCod", StringUtil.LTrimStr( (decimal)(AV14cTPedCod), 6, 0));
         A1931TPedDsc = "";
         AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
         A1933TPedGuia = 0;
         AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
         A1932TPedFac = 0;
         AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
         A1935TPedPer = 0;
         AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
         A1936TPedSts = 1;
         AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         Z1934TPedMovCod = 0;
         Z1931TPedDsc = "";
         Z1933TPedGuia = 0;
         Z1932TPedFac = 0;
         Z1935TPedPer = 0;
         Z1936TPedSts = 0;
      }

      protected void InitAll65135( )
      {
         A212TPedCod = 0;
         AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         InitializeNonKey65135( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1936TPedSts = i1936TPedSts;
         AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262224", true, true);
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
         context.AddJavascriptSource("configuracion/tipopedido.js", "?202281810262224", false, true);
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
         edtTPedDsc_Internalname = "TPEDDSC";
         chkTPedGuia_Internalname = "TPEDGUIA";
         chkTPedFac_Internalname = "TPEDFAC";
         chkTPedPer_Internalname = "TPEDPER";
         lblTextblocktpedmovcod_Internalname = "TEXTBLOCKTPEDMOVCOD";
         Combo_tpedmovcod_Internalname = "COMBO_TPEDMOVCOD";
         edtTPedMovCod_Internalname = "TPEDMOVCOD";
         divTablesplittedtpedmovcod_Internalname = "TABLESPLITTEDTPEDMOVCOD";
         cmbTPedSts_Internalname = "TPEDSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotpedmovcod_Internalname = "vCOMBOTPEDMOVCOD";
         divSectionattribute_tpedmovcod_Internalname = "SECTIONATTRIBUTE_TPEDMOVCOD";
         edtTPedCod_Internalname = "TPEDCOD";
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
         Form.Caption = "Tipos de Pedidos";
         edtTPedCod_Jsonclick = "";
         edtTPedCod_Enabled = 1;
         edtTPedCod_Visible = 1;
         edtavCombotpedmovcod_Jsonclick = "";
         edtavCombotpedmovcod_Enabled = 0;
         edtavCombotpedmovcod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTPedSts_Jsonclick = "";
         cmbTPedSts.Enabled = 1;
         edtTPedMovCod_Jsonclick = "";
         edtTPedMovCod_Enabled = 1;
         edtTPedMovCod_Visible = 1;
         Combo_tpedmovcod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_tpedmovcod_Enabled = Convert.ToBoolean( -1);
         chkTPedPer.Enabled = 1;
         chkTPedFac.Enabled = 1;
         chkTPedGuia.Enabled = 1;
         edtTPedDsc_Jsonclick = "";
         edtTPedDsc_Enabled = 1;
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

      protected void GX5ASACTPEDCOD65135( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV14cTPedCod;
            GXt_char3 = "TIPPEDIDOS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int5) ;
            AV14cTPedCod = (int)(GXt_int5);
            AssignAttri("", false, "AV14cTPedCod", StringUtil.LTrimStr( (decimal)(AV14cTPedCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cTPedCod), 6, 0, ".", "")))+"\"") ;
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
         chkTPedGuia.Name = "TPEDGUIA";
         chkTPedGuia.WebTags = "";
         chkTPedGuia.Caption = "";
         AssignProp("", false, chkTPedGuia_Internalname, "TitleCaption", chkTPedGuia.Caption, true);
         chkTPedGuia.CheckedValue = "0";
         A1933TPedGuia = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1933TPedGuia), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
         chkTPedFac.Name = "TPEDFAC";
         chkTPedFac.WebTags = "";
         chkTPedFac.Caption = "";
         AssignProp("", false, chkTPedFac_Internalname, "TitleCaption", chkTPedFac.Caption, true);
         chkTPedFac.CheckedValue = "0";
         A1932TPedFac = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1932TPedFac), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
         chkTPedPer.Name = "TPEDPER";
         chkTPedPer.WebTags = "";
         chkTPedPer.Caption = "";
         AssignProp("", false, chkTPedPer_Internalname, "TitleCaption", chkTPedPer.Caption, true);
         chkTPedPer.CheckedValue = "0";
         A1935TPedPer = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1935TPedPer), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
         cmbTPedSts.Name = "TPEDSTS";
         cmbTPedSts.WebTags = "";
         cmbTPedSts.addItem("1", "ACTIVO", 0);
         cmbTPedSts.addItem("0", "INACTIVO", 0);
         if ( cmbTPedSts.ItemCount > 0 )
         {
            if ( (0==A1936TPedSts) )
            {
               A1936TPedSts = 1;
               AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TPedCod',fld:'vTPEDCOD',pic:'ZZZZZ9',hsh:true},{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TPedCod',fld:'vTPEDCOD',pic:'ZZZZZ9',hsh:true},{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12652',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A212TPedCod',fld:'TPEDCOD',pic:'ZZZZZ9'},{av:'A1931TPedDsc',fld:'TPEDDSC',pic:''},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("VALID_TPEDDSC","{handler:'Valid_Tpeddsc',iparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("VALID_TPEDDSC",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOTPEDMOVCOD","{handler:'Validv_Combotpedmovcod',iparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOTPEDMOVCOD",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("VALID_TPEDCOD","{handler:'Valid_Tpedcod',iparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("VALID_TPEDCOD",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
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
         Z1931TPedDsc = "";
         Combo_tpedmovcod_Selectedvalue_get = "";
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
         A1931TPedDsc = "";
         lblTextblocktpedmovcod_Jsonclick = "";
         ucCombo_tpedmovcod = new GXUserControl();
         Combo_tpedmovcod_Caption = "";
         AV11TPedMovCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Combo_tpedmovcod_Objectcall = "";
         Combo_tpedmovcod_Class = "";
         Combo_tpedmovcod_Icontype = "";
         Combo_tpedmovcod_Icon = "";
         Combo_tpedmovcod_Tooltip = "";
         Combo_tpedmovcod_Selectedvalue_set = "";
         Combo_tpedmovcod_Selectedtext_set = "";
         Combo_tpedmovcod_Selectedtext_get = "";
         Combo_tpedmovcod_Gamoauthtoken = "";
         Combo_tpedmovcod_Ddointernalname = "";
         Combo_tpedmovcod_Titlecontrolalign = "";
         Combo_tpedmovcod_Dropdownoptionstype = "";
         Combo_tpedmovcod_Titlecontrolidtoreplace = "";
         Combo_tpedmovcod_Datalisttype = "";
         Combo_tpedmovcod_Datalistfixedvalues = "";
         Combo_tpedmovcod_Datalistproc = "";
         Combo_tpedmovcod_Datalistprocparametersprefix = "";
         Combo_tpedmovcod_Htmltemplate = "";
         Combo_tpedmovcod_Multiplevaluestype = "";
         Combo_tpedmovcod_Loadingdata = "";
         Combo_tpedmovcod_Noresultsfound = "";
         Combo_tpedmovcod_Emptyitemtext = "";
         Combo_tpedmovcod_Onlyselectedvalues = "";
         Combo_tpedmovcod_Selectalltext = "";
         Combo_tpedmovcod_Multiplevaluesseparator = "";
         Combo_tpedmovcod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode135 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV15SGAuDocGls = "";
         AV16Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_objcol_SdtDVB_SDTComboData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV12ComboSelectedValue = "";
         T00654_A212TPedCod = new int[1] ;
         T00654_A1934TPedMovCod = new int[1] ;
         T00654_A1931TPedDsc = new string[] {""} ;
         T00654_A1933TPedGuia = new short[1] ;
         T00654_A1932TPedFac = new short[1] ;
         T00654_A1935TPedPer = new short[1] ;
         T00654_A1936TPedSts = new short[1] ;
         T00655_A212TPedCod = new int[1] ;
         T00653_A212TPedCod = new int[1] ;
         T00653_A1934TPedMovCod = new int[1] ;
         T00653_A1931TPedDsc = new string[] {""} ;
         T00653_A1933TPedGuia = new short[1] ;
         T00653_A1932TPedFac = new short[1] ;
         T00653_A1935TPedPer = new short[1] ;
         T00653_A1936TPedSts = new short[1] ;
         T00656_A212TPedCod = new int[1] ;
         T00657_A212TPedCod = new int[1] ;
         T00652_A212TPedCod = new int[1] ;
         T00652_A1934TPedMovCod = new int[1] ;
         T00652_A1931TPedDsc = new string[] {""} ;
         T00652_A1933TPedGuia = new short[1] ;
         T00652_A1932TPedFac = new short[1] ;
         T00652_A1935TPedPer = new short[1] ;
         T00652_A1936TPedSts = new short[1] ;
         T006511_A210PedCod = new string[] {""} ;
         T006512_A212TPedCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipopedido__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipopedido__default(),
            new Object[][] {
                new Object[] {
               T00652_A212TPedCod, T00652_A1934TPedMovCod, T00652_A1931TPedDsc, T00652_A1933TPedGuia, T00652_A1932TPedFac, T00652_A1935TPedPer, T00652_A1936TPedSts
               }
               , new Object[] {
               T00653_A212TPedCod, T00653_A1934TPedMovCod, T00653_A1931TPedDsc, T00653_A1933TPedGuia, T00653_A1932TPedFac, T00653_A1935TPedPer, T00653_A1936TPedSts
               }
               , new Object[] {
               T00654_A212TPedCod, T00654_A1934TPedMovCod, T00654_A1931TPedDsc, T00654_A1933TPedGuia, T00654_A1932TPedFac, T00654_A1935TPedPer, T00654_A1936TPedSts
               }
               , new Object[] {
               T00655_A212TPedCod
               }
               , new Object[] {
               T00656_A212TPedCod
               }
               , new Object[] {
               T00657_A212TPedCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006511_A210PedCod
               }
               , new Object[] {
               T006512_A212TPedCod
               }
            }
         );
         Z1936TPedSts = 1;
         A1936TPedSts = 1;
         i1936TPedSts = 1;
      }

      private short Z1933TPedGuia ;
      private short Z1932TPedFac ;
      private short Z1935TPedPer ;
      private short Z1936TPedSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1933TPedGuia ;
      private short A1932TPedFac ;
      private short A1935TPedPer ;
      private short A1936TPedSts ;
      private short Gx_BScreen ;
      private short RcdFound135 ;
      private short GX_JID ;
      private short nIsDirty_135 ;
      private short gxajaxcallmode ;
      private short i1936TPedSts ;
      private int wcpOAV7TPedCod ;
      private int Z212TPedCod ;
      private int Z1934TPedMovCod ;
      private int AV7TPedCod ;
      private int trnEnded ;
      private int edtTPedDsc_Enabled ;
      private int A1934TPedMovCod ;
      private int edtTPedMovCod_Enabled ;
      private int edtTPedMovCod_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV13ComboTPedMovCod ;
      private int edtavCombotpedmovcod_Enabled ;
      private int edtavCombotpedmovcod_Visible ;
      private int A212TPedCod ;
      private int edtTPedCod_Visible ;
      private int edtTPedCod_Enabled ;
      private int AV14cTPedCod ;
      private int Combo_tpedmovcod_Datalistupdateminimumcharacters ;
      private int Combo_tpedmovcod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1931TPedDsc ;
      private string Combo_tpedmovcod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTPedDsc_Internalname ;
      private string cmbTPedSts_Internalname ;
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
      private string A1931TPedDsc ;
      private string edtTPedDsc_Jsonclick ;
      private string chkTPedGuia_Internalname ;
      private string chkTPedFac_Internalname ;
      private string chkTPedPer_Internalname ;
      private string divTablesplittedtpedmovcod_Internalname ;
      private string lblTextblocktpedmovcod_Internalname ;
      private string lblTextblocktpedmovcod_Jsonclick ;
      private string Combo_tpedmovcod_Caption ;
      private string Combo_tpedmovcod_Cls ;
      private string Combo_tpedmovcod_Internalname ;
      private string edtTPedMovCod_Internalname ;
      private string edtTPedMovCod_Jsonclick ;
      private string cmbTPedSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_tpedmovcod_Internalname ;
      private string edtavCombotpedmovcod_Internalname ;
      private string edtavCombotpedmovcod_Jsonclick ;
      private string edtTPedCod_Internalname ;
      private string edtTPedCod_Jsonclick ;
      private string Combo_tpedmovcod_Objectcall ;
      private string Combo_tpedmovcod_Class ;
      private string Combo_tpedmovcod_Icontype ;
      private string Combo_tpedmovcod_Icon ;
      private string Combo_tpedmovcod_Tooltip ;
      private string Combo_tpedmovcod_Selectedvalue_set ;
      private string Combo_tpedmovcod_Selectedtext_set ;
      private string Combo_tpedmovcod_Selectedtext_get ;
      private string Combo_tpedmovcod_Gamoauthtoken ;
      private string Combo_tpedmovcod_Ddointernalname ;
      private string Combo_tpedmovcod_Titlecontrolalign ;
      private string Combo_tpedmovcod_Dropdownoptionstype ;
      private string Combo_tpedmovcod_Titlecontrolidtoreplace ;
      private string Combo_tpedmovcod_Datalisttype ;
      private string Combo_tpedmovcod_Datalistfixedvalues ;
      private string Combo_tpedmovcod_Datalistproc ;
      private string Combo_tpedmovcod_Datalistprocparametersprefix ;
      private string Combo_tpedmovcod_Htmltemplate ;
      private string Combo_tpedmovcod_Multiplevaluestype ;
      private string Combo_tpedmovcod_Loadingdata ;
      private string Combo_tpedmovcod_Noresultsfound ;
      private string Combo_tpedmovcod_Emptyitemtext ;
      private string Combo_tpedmovcod_Onlyselectedvalues ;
      private string Combo_tpedmovcod_Selectalltext ;
      private string Combo_tpedmovcod_Multiplevaluesseparator ;
      private string Combo_tpedmovcod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode135 ;
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
      private bool Combo_tpedmovcod_Enabled ;
      private bool Combo_tpedmovcod_Visible ;
      private bool Combo_tpedmovcod_Allowmultipleselection ;
      private bool Combo_tpedmovcod_Isgriditem ;
      private bool Combo_tpedmovcod_Hasdescription ;
      private bool Combo_tpedmovcod_Includeonlyselectedoption ;
      private bool Combo_tpedmovcod_Includeselectalloption ;
      private bool Combo_tpedmovcod_Emptyitem ;
      private bool Combo_tpedmovcod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV15SGAuDocGls ;
      private string AV16Codigo ;
      private string AV12ComboSelectedValue ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tpedmovcod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTPedGuia ;
      private GXCheckbox chkTPedFac ;
      private GXCheckbox chkTPedPer ;
      private GXCombobox cmbTPedSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00654_A212TPedCod ;
      private int[] T00654_A1934TPedMovCod ;
      private string[] T00654_A1931TPedDsc ;
      private short[] T00654_A1933TPedGuia ;
      private short[] T00654_A1932TPedFac ;
      private short[] T00654_A1935TPedPer ;
      private short[] T00654_A1936TPedSts ;
      private int[] T00655_A212TPedCod ;
      private int[] T00653_A212TPedCod ;
      private int[] T00653_A1934TPedMovCod ;
      private string[] T00653_A1931TPedDsc ;
      private short[] T00653_A1933TPedGuia ;
      private short[] T00653_A1932TPedFac ;
      private short[] T00653_A1935TPedPer ;
      private short[] T00653_A1936TPedSts ;
      private int[] T00656_A212TPedCod ;
      private int[] T00657_A212TPedCod ;
      private int[] T00652_A212TPedCod ;
      private int[] T00652_A1934TPedMovCod ;
      private string[] T00652_A1931TPedDsc ;
      private short[] T00652_A1933TPedGuia ;
      private short[] T00652_A1932TPedFac ;
      private short[] T00652_A1935TPedPer ;
      private short[] T00652_A1936TPedSts ;
      private string[] T006511_A210PedCod ;
      private int[] T006512_A212TPedCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11TPedMovCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class tipopedido__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tipopedido__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00654;
        prmT00654 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT00655;
        prmT00655 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT00653;
        prmT00653 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT00656;
        prmT00656 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT00657;
        prmT00657 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT00652;
        prmT00652 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT00658;
        prmT00658 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0) ,
        new ParDef("@TPedMovCod",GXType.Int32,6,0) ,
        new ParDef("@TPedDsc",GXType.NChar,100,0) ,
        new ParDef("@TPedGuia",GXType.Int16,1,0) ,
        new ParDef("@TPedFac",GXType.Int16,1,0) ,
        new ParDef("@TPedPer",GXType.Int16,1,0) ,
        new ParDef("@TPedSts",GXType.Int16,1,0)
        };
        Object[] prmT00659;
        prmT00659 = new Object[] {
        new ParDef("@TPedMovCod",GXType.Int32,6,0) ,
        new ParDef("@TPedDsc",GXType.NChar,100,0) ,
        new ParDef("@TPedGuia",GXType.Int16,1,0) ,
        new ParDef("@TPedFac",GXType.Int16,1,0) ,
        new ParDef("@TPedPer",GXType.Int16,1,0) ,
        new ParDef("@TPedSts",GXType.Int16,1,0) ,
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT006510;
        prmT006510 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT006511;
        prmT006511 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT006512;
        prmT006512 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00652", "SELECT [TPedCod], [TPedMovCod], [TPedDsc], [TPedGuia], [TPedFac], [TPedPer], [TPedSts] FROM [CTIPPEDIDO] WITH (UPDLOCK) WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00652,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00653", "SELECT [TPedCod], [TPedMovCod], [TPedDsc], [TPedGuia], [TPedFac], [TPedPer], [TPedSts] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00653,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00654", "SELECT TM1.[TPedCod], TM1.[TPedMovCod], TM1.[TPedDsc], TM1.[TPedGuia], TM1.[TPedFac], TM1.[TPedPer], TM1.[TPedSts] FROM [CTIPPEDIDO] TM1 WHERE TM1.[TPedCod] = @TPedCod ORDER BY TM1.[TPedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00654,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00655", "SELECT [TPedCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00655,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00656", "SELECT TOP 1 [TPedCod] FROM [CTIPPEDIDO] WHERE ( [TPedCod] > @TPedCod) ORDER BY [TPedCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00656,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00657", "SELECT TOP 1 [TPedCod] FROM [CTIPPEDIDO] WHERE ( [TPedCod] < @TPedCod) ORDER BY [TPedCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00657,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00658", "INSERT INTO [CTIPPEDIDO]([TPedCod], [TPedMovCod], [TPedDsc], [TPedGuia], [TPedFac], [TPedPer], [TPedSts]) VALUES(@TPedCod, @TPedMovCod, @TPedDsc, @TPedGuia, @TPedFac, @TPedPer, @TPedSts)", GxErrorMask.GX_NOMASK,prmT00658)
           ,new CursorDef("T00659", "UPDATE [CTIPPEDIDO] SET [TPedMovCod]=@TPedMovCod, [TPedDsc]=@TPedDsc, [TPedGuia]=@TPedGuia, [TPedFac]=@TPedFac, [TPedPer]=@TPedPer, [TPedSts]=@TPedSts  WHERE [TPedCod] = @TPedCod", GxErrorMask.GX_NOMASK,prmT00659)
           ,new CursorDef("T006510", "DELETE FROM [CTIPPEDIDO]  WHERE [TPedCod] = @TPedCod", GxErrorMask.GX_NOMASK,prmT006510)
           ,new CursorDef("T006511", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006512", "SELECT [TPedCod] FROM [CTIPPEDIDO] ORDER BY [TPedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006512,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
