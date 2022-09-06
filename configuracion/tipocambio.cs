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
   public class tipocambio : GXDataArea
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
            A307TipMonCod = (int)(NumberUtil.Val( GetPar( "TipMonCod"), "."));
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A307TipMonCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.tipocambio.aspx")), "configuracion.tipocambio.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.tipocambio.aspx")))) ;
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
                  AV7TipMonCod = (int)(NumberUtil.Val( GetPar( "TipMonCod"), "."));
                  AssignAttri("", false, "AV7TipMonCod", StringUtil.LTrimStr( (decimal)(AV7TipMonCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPMONCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipMonCod), "ZZZZZ9"), context));
                  AV8TipFech = context.localUtil.ParseDateParm( GetPar( "TipFech"));
                  AssignAttri("", false, "AV8TipFech", context.localUtil.Format(AV8TipFech, "99/99/99"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPFECH", GetSecureSignedToken( "", AV8TipFech, context));
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
            Form.Meta.addItem("description", "Tipo Cambio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipocambio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipocambio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TipMonCod ,
                           DateTime aP2_TipFech )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipMonCod = aP1_TipMonCod;
         this.AV8TipFech = aP2_TipFech;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtipmoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktipmoncod_Internalname, "Moneda", "", "", lblTextblocktipmoncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\TipoCambio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tipmoncod.SetProperty("Caption", Combo_tipmoncod_Caption);
         ucCombo_tipmoncod.SetProperty("Cls", Combo_tipmoncod_Cls);
         ucCombo_tipmoncod.SetProperty("DataListProc", Combo_tipmoncod_Datalistproc);
         ucCombo_tipmoncod.SetProperty("DataListProcParametersPrefix", Combo_tipmoncod_Datalistprocparametersprefix);
         ucCombo_tipmoncod.SetProperty("EmptyItem", Combo_tipmoncod_Emptyitem);
         ucCombo_tipmoncod.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_tipmoncod.SetProperty("DropDownOptionsData", AV14TipMonCod_Data);
         ucCombo_tipmoncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipmoncod_Internalname, "COMBO_TIPMONCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipMonCod_Internalname, "Tipo de Cambio Moneda", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A307TipMonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A307TipMonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipMonCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipMonCod_Visible, edtTipMonCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoCambio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipFech_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipFech_Internalname, "Fecha", "col-sm-3 AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTipFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTipFech_Internalname, context.localUtil.Format(A308TipFech, "99/99/99"), context.localUtil.Format( A308TipFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipFech_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtTipFech_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoCambio.htm");
         GxWebStd.gx_bitmap( context, edtTipFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTipFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Configuracion\\TipoCambio.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipCompra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipCompra_Internalname, "Compra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCompra_Internalname, StringUtil.LTrim( StringUtil.NToC( A1907TipCompra, 15, 5, ".", "")), StringUtil.LTrim( ((edtTipCompra_Enabled!=0) ? context.localUtil.Format( A1907TipCompra, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1907TipCompra, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCompra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCompra_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoCambio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipVenta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipVenta_Internalname, "Venta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipVenta_Internalname, StringUtil.LTrim( StringUtil.NToC( A1920TipVenta, 15, 5, ".", "")), StringUtil.LTrim( ((edtTipVenta_Enabled!=0) ? context.localUtil.Format( A1920TipVenta, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1920TipVenta, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipVenta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipVenta_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoCambio.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoCambio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoCambio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoCambio.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_tipmoncod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotipmoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboTipMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotipmoncod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboTipMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboTipMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotipmoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotipmoncod_Visible, edtavCombotipmoncod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoCambio.htm");
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
         E11682 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPMONCOD_DATA"), AV14TipMonCod_Data);
               /* Read saved values. */
               Z307TipMonCod = (int)(context.localUtil.CToN( cgiGet( "Z307TipMonCod"), ".", ","));
               Z308TipFech = context.localUtil.CToD( cgiGet( "Z308TipFech"), 0);
               Z1907TipCompra = context.localUtil.CToN( cgiGet( "Z1907TipCompra"), ".", ",");
               Z1920TipVenta = context.localUtil.CToN( cgiGet( "Z1920TipVenta"), ".", ",");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TipMonCod = (int)(context.localUtil.CToN( cgiGet( "vTIPMONCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV8TipFech = context.localUtil.CToD( cgiGet( "vTIPFECH"), 0);
               A1234MonDsc = cgiGet( "MONDSC");
               n1234MonDsc = false;
               Combo_tipmoncod_Objectcall = cgiGet( "COMBO_TIPMONCOD_Objectcall");
               Combo_tipmoncod_Class = cgiGet( "COMBO_TIPMONCOD_Class");
               Combo_tipmoncod_Icontype = cgiGet( "COMBO_TIPMONCOD_Icontype");
               Combo_tipmoncod_Icon = cgiGet( "COMBO_TIPMONCOD_Icon");
               Combo_tipmoncod_Caption = cgiGet( "COMBO_TIPMONCOD_Caption");
               Combo_tipmoncod_Tooltip = cgiGet( "COMBO_TIPMONCOD_Tooltip");
               Combo_tipmoncod_Cls = cgiGet( "COMBO_TIPMONCOD_Cls");
               Combo_tipmoncod_Selectedvalue_set = cgiGet( "COMBO_TIPMONCOD_Selectedvalue_set");
               Combo_tipmoncod_Selectedvalue_get = cgiGet( "COMBO_TIPMONCOD_Selectedvalue_get");
               Combo_tipmoncod_Selectedtext_set = cgiGet( "COMBO_TIPMONCOD_Selectedtext_set");
               Combo_tipmoncod_Selectedtext_get = cgiGet( "COMBO_TIPMONCOD_Selectedtext_get");
               Combo_tipmoncod_Gamoauthtoken = cgiGet( "COMBO_TIPMONCOD_Gamoauthtoken");
               Combo_tipmoncod_Ddointernalname = cgiGet( "COMBO_TIPMONCOD_Ddointernalname");
               Combo_tipmoncod_Titlecontrolalign = cgiGet( "COMBO_TIPMONCOD_Titlecontrolalign");
               Combo_tipmoncod_Dropdownoptionstype = cgiGet( "COMBO_TIPMONCOD_Dropdownoptionstype");
               Combo_tipmoncod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Enabled"));
               Combo_tipmoncod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Visible"));
               Combo_tipmoncod_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPMONCOD_Titlecontrolidtoreplace");
               Combo_tipmoncod_Datalisttype = cgiGet( "COMBO_TIPMONCOD_Datalisttype");
               Combo_tipmoncod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Allowmultipleselection"));
               Combo_tipmoncod_Datalistfixedvalues = cgiGet( "COMBO_TIPMONCOD_Datalistfixedvalues");
               Combo_tipmoncod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Isgriditem"));
               Combo_tipmoncod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Hasdescription"));
               Combo_tipmoncod_Datalistproc = cgiGet( "COMBO_TIPMONCOD_Datalistproc");
               Combo_tipmoncod_Datalistprocparametersprefix = cgiGet( "COMBO_TIPMONCOD_Datalistprocparametersprefix");
               Combo_tipmoncod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPMONCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tipmoncod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Includeonlyselectedoption"));
               Combo_tipmoncod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Includeselectalloption"));
               Combo_tipmoncod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Emptyitem"));
               Combo_tipmoncod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPMONCOD_Includeaddnewoption"));
               Combo_tipmoncod_Htmltemplate = cgiGet( "COMBO_TIPMONCOD_Htmltemplate");
               Combo_tipmoncod_Multiplevaluestype = cgiGet( "COMBO_TIPMONCOD_Multiplevaluestype");
               Combo_tipmoncod_Loadingdata = cgiGet( "COMBO_TIPMONCOD_Loadingdata");
               Combo_tipmoncod_Noresultsfound = cgiGet( "COMBO_TIPMONCOD_Noresultsfound");
               Combo_tipmoncod_Emptyitemtext = cgiGet( "COMBO_TIPMONCOD_Emptyitemtext");
               Combo_tipmoncod_Onlyselectedvalues = cgiGet( "COMBO_TIPMONCOD_Onlyselectedvalues");
               Combo_tipmoncod_Selectalltext = cgiGet( "COMBO_TIPMONCOD_Selectalltext");
               Combo_tipmoncod_Multiplevaluesseparator = cgiGet( "COMBO_TIPMONCOD_Multiplevaluesseparator");
               Combo_tipmoncod_Addnewoptiontext = cgiGet( "COMBO_TIPMONCOD_Addnewoptiontext");
               Combo_tipmoncod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPMONCOD_Gxcontroltype"), ".", ","));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPMONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A307TipMonCod = 0;
                  AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               }
               else
               {
                  A307TipMonCod = (int)(context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ","));
                  AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtTipFech_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tipo de Cambio Fecha"}), 1, "TIPFECH");
                  AnyError = 1;
                  GX_FocusControl = edtTipFech_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A308TipFech = DateTime.MinValue;
                  AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               }
               else
               {
                  A308TipFech = context.localUtil.CToD( cgiGet( edtTipFech_Internalname), 2);
                  AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",") > 999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCOMPRA");
                  AnyError = 1;
                  GX_FocusControl = edtTipCompra_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1907TipCompra = 0;
                  AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
               }
               else
               {
                  A1907TipCompra = context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",");
                  AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",") > 999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPVENTA");
                  AnyError = 1;
                  GX_FocusControl = edtTipVenta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1920TipVenta = 0;
                  AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
               }
               else
               {
                  A1920TipVenta = context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",");
                  AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
               }
               AV19ComboTipMonCod = (int)(context.localUtil.CToN( cgiGet( edtavCombotipmoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV19ComboTipMonCod", StringUtil.LTrimStr( (decimal)(AV19ComboTipMonCod), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoCambio");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\tipocambio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A307TipMonCod = (int)(NumberUtil.Val( GetPar( "TipMonCod"), "."));
                  AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                  A308TipFech = context.localUtil.ParseDateParm( GetPar( "TipFech"));
                  AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7TipMonCod) )
                  {
                     A307TipMonCod = AV7TipMonCod;
                     AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                  }
                  else
                  {
                     if ( true )
                     {
                        A307TipMonCod = AV19ComboTipMonCod;
                        AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A307TipMonCod) && ( Gx_BScreen == 0 ) )
                        {
                           A307TipMonCod = 2;
                           AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                        }
                     }
                  }
                  if ( ! (DateTime.MinValue==AV8TipFech) )
                  {
                     A308TipFech = AV8TipFech;
                     AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                  }
                  else
                  {
                     if ( IsIns( )  && (DateTime.MinValue==A308TipFech) && ( Gx_BScreen == 0 ) )
                     {
                        A308TipFech = DateTimeUtil.Today( context);
                        AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode131 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7TipMonCod) )
                     {
                        A307TipMonCod = AV7TipMonCod;
                        AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                     }
                     else
                     {
                        if ( true )
                        {
                           A307TipMonCod = AV19ComboTipMonCod;
                           AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                        }
                        else
                        {
                           if ( IsIns( )  && (0==A307TipMonCod) && ( Gx_BScreen == 0 ) )
                           {
                              A307TipMonCod = 2;
                              AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                           }
                        }
                     }
                     if ( ! (DateTime.MinValue==AV8TipFech) )
                     {
                        A308TipFech = AV8TipFech;
                        AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                     }
                     else
                     {
                        if ( IsIns( )  && (DateTime.MinValue==A308TipFech) && ( Gx_BScreen == 0 ) )
                        {
                           A308TipFech = DateTimeUtil.Today( context);
                           AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                        }
                     }
                     Gx_mode = sMode131;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound131 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_680( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPMONCOD");
                        AnyError = 1;
                        GX_FocusControl = edtTipMonCod_Internalname;
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
                           E11682 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12682 ();
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
            E12682 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll68131( ) ;
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
            DisableAttributes68131( ) ;
         }
         AssignProp("", false, edtavCombotipmoncod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipmoncod_Enabled), 5, 0), true);
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

      protected void CONFIRM_680( )
      {
         BeforeValidate68131( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls68131( ) ;
            }
            else
            {
               CheckExtendedTable68131( ) ;
               CloseExtendedTableCursors68131( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption680( )
      {
      }

      protected void E11682( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtTipMonCod_Visible = 0;
         AssignProp("", false, edtTipMonCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipMonCod_Visible), 5, 0), true);
         AV19ComboTipMonCod = 0;
         AssignAttri("", false, "AV19ComboTipMonCod", StringUtil.LTrimStr( (decimal)(AV19ComboTipMonCod), 6, 0));
         edtavCombotipmoncod_Visible = 0;
         AssignProp("", false, edtavCombotipmoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotipmoncod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPMONCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12682( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.tipocambioww.aspx") );
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
         /* 'LOADCOMBOTIPMONCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new GeneXus.Programs.configuracion.tipocambioloaddvcombo(context ).execute(  "TipMonCod",  Gx_mode,  false,  AV7TipMonCod,  AV8TipFech,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AV18Combo_DataJson = GXt_char2;
         Combo_tipmoncod_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_tipmoncod.SendProperty(context, "", false, Combo_tipmoncod_Internalname, "SelectedValue_set", Combo_tipmoncod_Selectedvalue_set);
         Combo_tipmoncod_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_tipmoncod.SendProperty(context, "", false, Combo_tipmoncod_Internalname, "SelectedText_set", Combo_tipmoncod_Selectedtext_set);
         AV19ComboTipMonCod = (int)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV19ComboTipMonCod", StringUtil.LTrimStr( (decimal)(AV19ComboTipMonCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7TipMonCod) )
         {
            Combo_tipmoncod_Enabled = false;
            ucCombo_tipmoncod.SendProperty(context, "", false, Combo_tipmoncod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipmoncod_Enabled));
         }
      }

      protected void ZM68131( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1907TipCompra = T00683_A1907TipCompra[0];
               Z1920TipVenta = T00683_A1920TipVenta[0];
            }
            else
            {
               Z1907TipCompra = A1907TipCompra;
               Z1920TipVenta = A1920TipVenta;
            }
         }
         if ( GX_JID == -12 )
         {
            Z308TipFech = A308TipFech;
            Z1907TipCompra = A1907TipCompra;
            Z1920TipVenta = A1920TipVenta;
            Z307TipMonCod = A307TipMonCod;
            Z1234MonDsc = A1234MonDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipMonCod) )
         {
            edtTipMonCod_Enabled = 0;
            AssignProp("", false, edtTipMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipMonCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipMonCod_Enabled = 1;
            AssignProp("", false, edtTipMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipMonCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TipMonCod) )
         {
            edtTipMonCod_Enabled = 0;
            AssignProp("", false, edtTipMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipMonCod_Enabled), 5, 0), true);
         }
         if ( ! (DateTime.MinValue==AV8TipFech) )
         {
            edtTipFech_Enabled = 0;
            AssignProp("", false, edtTipFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipFech_Enabled), 5, 0), true);
         }
         else
         {
            edtTipFech_Enabled = 1;
            AssignProp("", false, edtTipFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipFech_Enabled), 5, 0), true);
         }
         if ( ! (DateTime.MinValue==AV8TipFech) )
         {
            edtTipFech_Enabled = 0;
            AssignProp("", false, edtTipFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipFech_Enabled), 5, 0), true);
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
         if ( ! (0==AV7TipMonCod) )
         {
            A307TipMonCod = AV7TipMonCod;
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
         }
         else
         {
            if ( true )
            {
               A307TipMonCod = AV19ComboTipMonCod;
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            }
            else
            {
               if ( IsIns( )  && (0==A307TipMonCod) && ( Gx_BScreen == 0 ) )
               {
                  A307TipMonCod = 2;
                  AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               }
            }
         }
         if ( ! (DateTime.MinValue==AV8TipFech) )
         {
            A308TipFech = AV8TipFech;
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A308TipFech) && ( Gx_BScreen == 0 ) )
            {
               A308TipFech = DateTimeUtil.Today( context);
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00684 */
            pr_default.execute(2, new Object[] {A307TipMonCod});
            A1234MonDsc = T00684_A1234MonDsc[0];
            n1234MonDsc = T00684_n1234MonDsc[0];
            pr_default.close(2);
         }
      }

      protected void Load68131( )
      {
         /* Using cursor T00685 */
         pr_default.execute(3, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound131 = 1;
            A1907TipCompra = T00685_A1907TipCompra[0];
            AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
            A1920TipVenta = T00685_A1920TipVenta[0];
            AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
            A1234MonDsc = T00685_A1234MonDsc[0];
            n1234MonDsc = T00685_n1234MonDsc[0];
            ZM68131( -12) ;
         }
         pr_default.close(3);
         OnLoadActions68131( ) ;
      }

      protected void OnLoadActions68131( )
      {
      }

      protected void CheckExtendedTable68131( )
      {
         nIsDirty_131 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00684 */
         pr_default.execute(2, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1234MonDsc = T00684_A1234MonDsc[0];
         n1234MonDsc = T00684_n1234MonDsc[0];
         pr_default.close(2);
         if ( (0==A307TipMonCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Cambio Moneda", "", "", "", "", "", "", "", ""), 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A308TipFech) || ( DateTimeUtil.ResetTime ( A308TipFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tipo de Cambio Fecha fuera de rango", "OutOfRange", 1, "TIPFECH");
            AnyError = 1;
            GX_FocusControl = edtTipFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A308TipFech) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Cambio Fecha", "", "", "", "", "", "", "", ""), 1, "TIPFECH");
            AnyError = 1;
            GX_FocusControl = edtTipFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A1907TipCompra) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Compra", "", "", "", "", "", "", "", ""), 1, "TIPCOMPRA");
            AnyError = 1;
            GX_FocusControl = edtTipCompra_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A1920TipVenta) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Venta", "", "", "", "", "", "", "", ""), 1, "TIPVENTA");
            AnyError = 1;
            GX_FocusControl = edtTipVenta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors68131( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A307TipMonCod )
      {
         /* Using cursor T00686 */
         pr_default.execute(4, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1234MonDsc = T00686_A1234MonDsc[0];
         n1234MonDsc = T00686_n1234MonDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1234MonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey68131( )
      {
         /* Using cursor T00687 */
         pr_default.execute(5, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound131 = 1;
         }
         else
         {
            RcdFound131 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00683 */
         pr_default.execute(1, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM68131( 12) ;
            RcdFound131 = 1;
            A308TipFech = T00683_A308TipFech[0];
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            A1907TipCompra = T00683_A1907TipCompra[0];
            AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
            A1920TipVenta = T00683_A1920TipVenta[0];
            AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
            A307TipMonCod = T00683_A307TipMonCod[0];
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            Z307TipMonCod = A307TipMonCod;
            Z308TipFech = A308TipFech;
            sMode131 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load68131( ) ;
            if ( AnyError == 1 )
            {
               RcdFound131 = 0;
               InitializeNonKey68131( ) ;
            }
            Gx_mode = sMode131;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound131 = 0;
            InitializeNonKey68131( ) ;
            sMode131 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode131;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey68131( ) ;
         if ( RcdFound131 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound131 = 0;
         /* Using cursor T00688 */
         pr_default.execute(6, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00688_A307TipMonCod[0] < A307TipMonCod ) || ( T00688_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T00688_A308TipFech[0] ) < DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00688_A307TipMonCod[0] > A307TipMonCod ) || ( T00688_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T00688_A308TipFech[0] ) > DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               A307TipMonCod = T00688_A307TipMonCod[0];
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               A308TipFech = T00688_A308TipFech[0];
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               RcdFound131 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound131 = 0;
         /* Using cursor T00689 */
         pr_default.execute(7, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00689_A307TipMonCod[0] > A307TipMonCod ) || ( T00689_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T00689_A308TipFech[0] ) > DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00689_A307TipMonCod[0] < A307TipMonCod ) || ( T00689_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T00689_A308TipFech[0] ) < DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               A307TipMonCod = T00689_A307TipMonCod[0];
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               A308TipFech = T00689_A308TipFech[0];
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               RcdFound131 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey68131( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert68131( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound131 == 1 )
            {
               if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
               {
                  A307TipMonCod = Z307TipMonCod;
                  AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                  A308TipFech = Z308TipFech;
                  AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPMONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update68131( ) ;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert68131( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPMONCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert68131( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
         {
            A307TipMonCod = Z307TipMonCod;
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            A308TipFech = Z308TipFech;
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency68131( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00682 */
            pr_default.execute(0, new Object[] {A307TipMonCod, A308TipFech});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOCAMBIO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1907TipCompra != T00682_A1907TipCompra[0] ) || ( Z1920TipVenta != T00682_A1920TipVenta[0] ) )
            {
               if ( Z1907TipCompra != T00682_A1907TipCompra[0] )
               {
                  GXUtil.WriteLog("configuracion.tipocambio:[seudo value changed for attri]"+"TipCompra");
                  GXUtil.WriteLogRaw("Old: ",Z1907TipCompra);
                  GXUtil.WriteLogRaw("Current: ",T00682_A1907TipCompra[0]);
               }
               if ( Z1920TipVenta != T00682_A1920TipVenta[0] )
               {
                  GXUtil.WriteLog("configuracion.tipocambio:[seudo value changed for attri]"+"TipVenta");
                  GXUtil.WriteLogRaw("Old: ",Z1920TipVenta);
                  GXUtil.WriteLogRaw("Current: ",T00682_A1920TipVenta[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOCAMBIO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert68131( )
      {
         BeforeValidate68131( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable68131( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM68131( 0) ;
            CheckOptimisticConcurrency68131( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm68131( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert68131( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006810 */
                     pr_default.execute(8, new Object[] {A308TipFech, A1907TipCompra, A1920TipVenta, A307TipMonCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOCAMBIO");
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            else
            {
               Load68131( ) ;
            }
            EndLevel68131( ) ;
         }
         CloseExtendedTableCursors68131( ) ;
      }

      protected void Update68131( )
      {
         BeforeValidate68131( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable68131( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency68131( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm68131( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate68131( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006811 */
                     pr_default.execute(9, new Object[] {A1907TipCompra, A1920TipVenta, A307TipMonCod, A308TipFech});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOCAMBIO");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOCAMBIO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate68131( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
            EndLevel68131( ) ;
         }
         CloseExtendedTableCursors68131( ) ;
      }

      protected void DeferredUpdate68131( )
      {
      }

      protected void delete( )
      {
         BeforeValidate68131( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency68131( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls68131( ) ;
            AfterConfirm68131( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete68131( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006812 */
                  pr_default.execute(10, new Object[] {A307TipMonCod, A308TipFech});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOCAMBIO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
         sMode131 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel68131( ) ;
         Gx_mode = sMode131;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls68131( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006813 */
            pr_default.execute(11, new Object[] {A307TipMonCod});
            A1234MonDsc = T006813_A1234MonDsc[0];
            n1234MonDsc = T006813_n1234MonDsc[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel68131( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete68131( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("configuracion.tipocambio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues680( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("configuracion.tipocambio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart68131( )
      {
         /* Scan By routine */
         /* Using cursor T006814 */
         pr_default.execute(12);
         RcdFound131 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound131 = 1;
            A307TipMonCod = T006814_A307TipMonCod[0];
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            A308TipFech = T006814_A308TipFech[0];
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext68131( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound131 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound131 = 1;
            A307TipMonCod = T006814_A307TipMonCod[0];
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            A308TipFech = T006814_A308TipFech[0];
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         }
      }

      protected void ScanEnd68131( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm68131( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert68131( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate68131( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete68131( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete68131( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate68131( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes68131( )
      {
         edtTipMonCod_Enabled = 0;
         AssignProp("", false, edtTipMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipMonCod_Enabled), 5, 0), true);
         edtTipFech_Enabled = 0;
         AssignProp("", false, edtTipFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipFech_Enabled), 5, 0), true);
         edtTipCompra_Enabled = 0;
         AssignProp("", false, edtTipCompra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCompra_Enabled), 5, 0), true);
         edtTipVenta_Enabled = 0;
         AssignProp("", false, edtTipVenta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipVenta_Enabled), 5, 0), true);
         edtavCombotipmoncod_Enabled = 0;
         AssignProp("", false, edtavCombotipmoncod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipmoncod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes68131( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues680( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262590", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         GXEncryptionTmp = "configuracion.tipocambio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipMonCod,6,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV8TipFech));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipocambio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoCambio");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\tipocambio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z307TipMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z307TipMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z308TipFech", context.localUtil.DToC( Z308TipFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1907TipCompra", StringUtil.LTrim( StringUtil.NToC( Z1907TipCompra, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1920TipVenta", StringUtil.LTrim( StringUtil.NToC( Z1920TipVenta, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPMONCOD_DATA", AV14TipMonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPMONCOD_DATA", AV14TipMonCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vTIPMONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPMONCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipMonCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTIPFECH", context.localUtil.DToC( AV8TipFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPFECH", GetSecureSignedToken( "", AV8TipFech, context));
         GxWebStd.gx_hidden_field( context, "MONDSC", StringUtil.RTrim( A1234MonDsc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Objectcall", StringUtil.RTrim( Combo_tipmoncod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Cls", StringUtil.RTrim( Combo_tipmoncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipmoncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Selectedtext_set", StringUtil.RTrim( Combo_tipmoncod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Enabled", StringUtil.BoolToStr( Combo_tipmoncod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Datalistproc", StringUtil.RTrim( Combo_tipmoncod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipmoncod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPMONCOD_Emptyitem", StringUtil.BoolToStr( Combo_tipmoncod_Emptyitem));
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
         GXEncryptionTmp = "configuracion.tipocambio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipMonCod,6,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV8TipFech));
         return formatLink("configuracion.tipocambio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoCambio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo Cambio" ;
      }

      protected void InitializeNonKey68131( )
      {
         A1907TipCompra = 0;
         AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
         A1920TipVenta = 0;
         AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
         A1234MonDsc = "";
         n1234MonDsc = false;
         AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
         Z1907TipCompra = 0;
         Z1920TipVenta = 0;
      }

      protected void InitAll68131( )
      {
         A307TipMonCod = 2;
         AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
         A308TipFech = DateTimeUtil.Today( context);
         AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         InitializeNonKey68131( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262616", true, true);
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
         context.AddJavascriptSource("configuracion/tipocambio.js", "?202281810262616", false, true);
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
         lblTextblocktipmoncod_Internalname = "TEXTBLOCKTIPMONCOD";
         Combo_tipmoncod_Internalname = "COMBO_TIPMONCOD";
         edtTipMonCod_Internalname = "TIPMONCOD";
         divTablesplittedtipmoncod_Internalname = "TABLESPLITTEDTIPMONCOD";
         edtTipFech_Internalname = "TIPFECH";
         edtTipCompra_Internalname = "TIPCOMPRA";
         edtTipVenta_Internalname = "TIPVENTA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotipmoncod_Internalname = "vCOMBOTIPMONCOD";
         divSectionattribute_tipmoncod_Internalname = "SECTIONATTRIBUTE_TIPMONCOD";
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
         Form.Caption = "Tipo Cambio";
         edtavCombotipmoncod_Jsonclick = "";
         edtavCombotipmoncod_Enabled = 0;
         edtavCombotipmoncod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTipVenta_Jsonclick = "";
         edtTipVenta_Enabled = 1;
         edtTipCompra_Jsonclick = "";
         edtTipCompra_Enabled = 1;
         edtTipFech_Jsonclick = "";
         edtTipFech_Enabled = 1;
         edtTipMonCod_Jsonclick = "";
         edtTipMonCod_Enabled = 1;
         edtTipMonCod_Visible = 1;
         Combo_tipmoncod_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipmoncod_Datalistprocparametersprefix = " \"ComboName\": \"TipMonCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TipMonCod\": 0, \"TipFech\": \"\"";
         Combo_tipmoncod_Datalistproc = "Configuracion.TipoCambioLoadDVCombo";
         Combo_tipmoncod_Cls = "ExtendedCombo Attribute";
         Combo_tipmoncod_Caption = "";
         Combo_tipmoncod_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Tipmoncod( )
      {
         n1234MonDsc = false;
         /* Using cursor T006813 */
         pr_default.execute(11, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
         }
         A1234MonDsc = T006813_A1234MonDsc[0];
         n1234MonDsc = T006813_n1234MonDsc[0];
         pr_default.close(11);
         if ( (0==A307TipMonCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Cambio Moneda", "", "", "", "", "", "", "", ""), 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1234MonDsc", StringUtil.RTrim( A1234MonDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TipMonCod',fld:'vTIPMONCOD',pic:'ZZZZZ9',hsh:true},{av:'AV8TipFech',fld:'vTIPFECH',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TipMonCod',fld:'vTIPMONCOD',pic:'ZZZZZ9',hsh:true},{av:'AV8TipFech',fld:'vTIPFECH',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12682',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TIPMONCOD","{handler:'Valid_Tipmoncod',iparms:[{av:'A307TipMonCod',fld:'TIPMONCOD',pic:'ZZZZZ9'},{av:'A1234MonDsc',fld:'MONDSC',pic:''}]");
         setEventMetadata("VALID_TIPMONCOD",",oparms:[{av:'A1234MonDsc',fld:'MONDSC',pic:''}]}");
         setEventMetadata("VALID_TIPFECH","{handler:'Valid_Tipfech',iparms:[]");
         setEventMetadata("VALID_TIPFECH",",oparms:[]}");
         setEventMetadata("VALID_TIPCOMPRA","{handler:'Valid_Tipcompra',iparms:[]");
         setEventMetadata("VALID_TIPCOMPRA",",oparms:[]}");
         setEventMetadata("VALID_TIPVENTA","{handler:'Valid_Tipventa',iparms:[]");
         setEventMetadata("VALID_TIPVENTA",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOTIPMONCOD","{handler:'Validv_Combotipmoncod',iparms:[]");
         setEventMetadata("VALIDV_COMBOTIPMONCOD",",oparms:[]}");
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
         wcpOAV8TipFech = DateTime.MinValue;
         Z308TipFech = DateTime.MinValue;
         Combo_tipmoncod_Selectedvalue_get = "";
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
         lblTextblocktipmoncod_Jsonclick = "";
         ucCombo_tipmoncod = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14TipMonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A308TipFech = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A1234MonDsc = "";
         Combo_tipmoncod_Objectcall = "";
         Combo_tipmoncod_Class = "";
         Combo_tipmoncod_Icontype = "";
         Combo_tipmoncod_Icon = "";
         Combo_tipmoncod_Tooltip = "";
         Combo_tipmoncod_Selectedvalue_set = "";
         Combo_tipmoncod_Selectedtext_set = "";
         Combo_tipmoncod_Selectedtext_get = "";
         Combo_tipmoncod_Gamoauthtoken = "";
         Combo_tipmoncod_Ddointernalname = "";
         Combo_tipmoncod_Titlecontrolalign = "";
         Combo_tipmoncod_Dropdownoptionstype = "";
         Combo_tipmoncod_Titlecontrolidtoreplace = "";
         Combo_tipmoncod_Datalisttype = "";
         Combo_tipmoncod_Datalistfixedvalues = "";
         Combo_tipmoncod_Htmltemplate = "";
         Combo_tipmoncod_Multiplevaluestype = "";
         Combo_tipmoncod_Loadingdata = "";
         Combo_tipmoncod_Noresultsfound = "";
         Combo_tipmoncod_Emptyitemtext = "";
         Combo_tipmoncod_Onlyselectedvalues = "";
         Combo_tipmoncod_Selectalltext = "";
         Combo_tipmoncod_Multiplevaluesseparator = "";
         Combo_tipmoncod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode131 = "";
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
         AV18Combo_DataJson = "";
         GXt_char2 = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         Z1234MonDsc = "";
         T00684_A1234MonDsc = new string[] {""} ;
         T00684_n1234MonDsc = new bool[] {false} ;
         T00685_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T00685_A1907TipCompra = new decimal[1] ;
         T00685_A1920TipVenta = new decimal[1] ;
         T00685_A1234MonDsc = new string[] {""} ;
         T00685_n1234MonDsc = new bool[] {false} ;
         T00685_A307TipMonCod = new int[1] ;
         T00686_A1234MonDsc = new string[] {""} ;
         T00686_n1234MonDsc = new bool[] {false} ;
         T00687_A307TipMonCod = new int[1] ;
         T00687_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T00683_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T00683_A1907TipCompra = new decimal[1] ;
         T00683_A1920TipVenta = new decimal[1] ;
         T00683_A307TipMonCod = new int[1] ;
         T00688_A307TipMonCod = new int[1] ;
         T00688_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T00689_A307TipMonCod = new int[1] ;
         T00689_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T00682_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T00682_A1907TipCompra = new decimal[1] ;
         T00682_A1920TipVenta = new decimal[1] ;
         T00682_A307TipMonCod = new int[1] ;
         T006813_A1234MonDsc = new string[] {""} ;
         T006813_n1234MonDsc = new bool[] {false} ;
         T006814_A307TipMonCod = new int[1] ;
         T006814_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambio__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambio__default(),
            new Object[][] {
                new Object[] {
               T00682_A308TipFech, T00682_A1907TipCompra, T00682_A1920TipVenta, T00682_A307TipMonCod
               }
               , new Object[] {
               T00683_A308TipFech, T00683_A1907TipCompra, T00683_A1920TipVenta, T00683_A307TipMonCod
               }
               , new Object[] {
               T00684_A1234MonDsc, T00684_n1234MonDsc
               }
               , new Object[] {
               T00685_A308TipFech, T00685_A1907TipCompra, T00685_A1920TipVenta, T00685_A1234MonDsc, T00685_n1234MonDsc, T00685_A307TipMonCod
               }
               , new Object[] {
               T00686_A1234MonDsc, T00686_n1234MonDsc
               }
               , new Object[] {
               T00687_A307TipMonCod, T00687_A308TipFech
               }
               , new Object[] {
               T00688_A307TipMonCod, T00688_A308TipFech
               }
               , new Object[] {
               T00689_A307TipMonCod, T00689_A308TipFech
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006813_A1234MonDsc, T006813_n1234MonDsc
               }
               , new Object[] {
               T006814_A307TipMonCod, T006814_A308TipFech
               }
            }
         );
         Z308TipFech = DateTimeUtil.Today( context);
         A308TipFech = DateTimeUtil.Today( context);
         Z307TipMonCod = 2;
         A307TipMonCod = 2;
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound131 ;
      private short GX_JID ;
      private short nIsDirty_131 ;
      private short gxajaxcallmode ;
      private int wcpOAV7TipMonCod ;
      private int Z307TipMonCod ;
      private int A307TipMonCod ;
      private int AV7TipMonCod ;
      private int trnEnded ;
      private int edtTipMonCod_Visible ;
      private int edtTipMonCod_Enabled ;
      private int edtTipFech_Enabled ;
      private int edtTipCompra_Enabled ;
      private int edtTipVenta_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboTipMonCod ;
      private int edtavCombotipmoncod_Enabled ;
      private int edtavCombotipmoncod_Visible ;
      private int Combo_tipmoncod_Datalistupdateminimumcharacters ;
      private int Combo_tipmoncod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private decimal Z1907TipCompra ;
      private decimal Z1920TipVenta ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_tipmoncod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipMonCod_Internalname ;
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
      private string divTablesplittedtipmoncod_Internalname ;
      private string lblTextblocktipmoncod_Internalname ;
      private string lblTextblocktipmoncod_Jsonclick ;
      private string Combo_tipmoncod_Caption ;
      private string Combo_tipmoncod_Cls ;
      private string Combo_tipmoncod_Datalistproc ;
      private string Combo_tipmoncod_Datalistprocparametersprefix ;
      private string Combo_tipmoncod_Internalname ;
      private string TempTags ;
      private string edtTipMonCod_Jsonclick ;
      private string edtTipFech_Internalname ;
      private string edtTipFech_Jsonclick ;
      private string edtTipCompra_Internalname ;
      private string edtTipCompra_Jsonclick ;
      private string edtTipVenta_Internalname ;
      private string edtTipVenta_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_tipmoncod_Internalname ;
      private string edtavCombotipmoncod_Internalname ;
      private string edtavCombotipmoncod_Jsonclick ;
      private string A1234MonDsc ;
      private string Combo_tipmoncod_Objectcall ;
      private string Combo_tipmoncod_Class ;
      private string Combo_tipmoncod_Icontype ;
      private string Combo_tipmoncod_Icon ;
      private string Combo_tipmoncod_Tooltip ;
      private string Combo_tipmoncod_Selectedvalue_set ;
      private string Combo_tipmoncod_Selectedtext_set ;
      private string Combo_tipmoncod_Selectedtext_get ;
      private string Combo_tipmoncod_Gamoauthtoken ;
      private string Combo_tipmoncod_Ddointernalname ;
      private string Combo_tipmoncod_Titlecontrolalign ;
      private string Combo_tipmoncod_Dropdownoptionstype ;
      private string Combo_tipmoncod_Titlecontrolidtoreplace ;
      private string Combo_tipmoncod_Datalisttype ;
      private string Combo_tipmoncod_Datalistfixedvalues ;
      private string Combo_tipmoncod_Htmltemplate ;
      private string Combo_tipmoncod_Multiplevaluestype ;
      private string Combo_tipmoncod_Loadingdata ;
      private string Combo_tipmoncod_Noresultsfound ;
      private string Combo_tipmoncod_Emptyitemtext ;
      private string Combo_tipmoncod_Onlyselectedvalues ;
      private string Combo_tipmoncod_Selectalltext ;
      private string Combo_tipmoncod_Multiplevaluesseparator ;
      private string Combo_tipmoncod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode131 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z1234MonDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime wcpOAV8TipFech ;
      private DateTime Z308TipFech ;
      private DateTime AV8TipFech ;
      private DateTime A308TipFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_tipmoncod_Emptyitem ;
      private bool n1234MonDsc ;
      private bool Combo_tipmoncod_Enabled ;
      private bool Combo_tipmoncod_Visible ;
      private bool Combo_tipmoncod_Allowmultipleselection ;
      private bool Combo_tipmoncod_Isgriditem ;
      private bool Combo_tipmoncod_Hasdescription ;
      private bool Combo_tipmoncod_Includeonlyselectedoption ;
      private bool Combo_tipmoncod_Includeselectalloption ;
      private bool Combo_tipmoncod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tipmoncod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00684_A1234MonDsc ;
      private bool[] T00684_n1234MonDsc ;
      private DateTime[] T00685_A308TipFech ;
      private decimal[] T00685_A1907TipCompra ;
      private decimal[] T00685_A1920TipVenta ;
      private string[] T00685_A1234MonDsc ;
      private bool[] T00685_n1234MonDsc ;
      private int[] T00685_A307TipMonCod ;
      private string[] T00686_A1234MonDsc ;
      private bool[] T00686_n1234MonDsc ;
      private int[] T00687_A307TipMonCod ;
      private DateTime[] T00687_A308TipFech ;
      private DateTime[] T00683_A308TipFech ;
      private decimal[] T00683_A1907TipCompra ;
      private decimal[] T00683_A1920TipVenta ;
      private int[] T00683_A307TipMonCod ;
      private int[] T00688_A307TipMonCod ;
      private DateTime[] T00688_A308TipFech ;
      private int[] T00689_A307TipMonCod ;
      private DateTime[] T00689_A308TipFech ;
      private DateTime[] T00682_A308TipFech ;
      private decimal[] T00682_A1907TipCompra ;
      private decimal[] T00682_A1920TipVenta ;
      private int[] T00682_A307TipMonCod ;
      private string[] T006813_A1234MonDsc ;
      private bool[] T006813_n1234MonDsc ;
      private int[] T006814_A307TipMonCod ;
      private DateTime[] T006814_A308TipFech ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14TipMonCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class tipocambio__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tipocambio__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00685;
        prmT00685 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT00684;
        prmT00684 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        Object[] prmT00686;
        prmT00686 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        Object[] prmT00687;
        prmT00687 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT00683;
        prmT00683 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT00688;
        prmT00688 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT00689;
        prmT00689 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT00682;
        prmT00682 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT006810;
        prmT006810 = new Object[] {
        new ParDef("@TipFech",GXType.Date,8,0) ,
        new ParDef("@TipCompra",GXType.Decimal,15,5) ,
        new ParDef("@TipVenta",GXType.Decimal,15,5) ,
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        Object[] prmT006811;
        prmT006811 = new Object[] {
        new ParDef("@TipCompra",GXType.Decimal,15,5) ,
        new ParDef("@TipVenta",GXType.Decimal,15,5) ,
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT006812;
        prmT006812 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT006814;
        prmT006814 = new Object[] {
        };
        Object[] prmT006813;
        prmT006813 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00682", "SELECT [TipFech], [TipCompra], [TipVenta], [TipMonCod] AS TipMonCod FROM [CTIPOCAMBIO] WITH (UPDLOCK) WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech ",true, GxErrorMask.GX_NOMASK, false, this,prmT00682,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00683", "SELECT [TipFech], [TipCompra], [TipVenta], [TipMonCod] AS TipMonCod FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech ",true, GxErrorMask.GX_NOMASK, false, this,prmT00683,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00684", "SELECT [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @TipMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00684,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00685", "SELECT TM1.[TipFech], TM1.[TipCompra], TM1.[TipVenta], T2.[MonDsc], TM1.[TipMonCod] AS TipMonCod FROM ([CTIPOCAMBIO] TM1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = TM1.[TipMonCod]) WHERE TM1.[TipMonCod] = @TipMonCod and TM1.[TipFech] = @TipFech ORDER BY TM1.[TipMonCod], TM1.[TipFech]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00685,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00686", "SELECT [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @TipMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00686,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00687", "SELECT [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00687,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00688", "SELECT TOP 1 [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] WHERE ( [TipMonCod] > @TipMonCod or [TipMonCod] = @TipMonCod and [TipFech] > @TipFech) ORDER BY [TipMonCod], [TipFech]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00688,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00689", "SELECT TOP 1 [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] WHERE ( [TipMonCod] < @TipMonCod or [TipMonCod] = @TipMonCod and [TipFech] < @TipFech) ORDER BY [TipMonCod] DESC, [TipFech] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00689,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006810", "INSERT INTO [CTIPOCAMBIO]([TipFech], [TipCompra], [TipVenta], [TipMonCod]) VALUES(@TipFech, @TipCompra, @TipVenta, @TipMonCod)", GxErrorMask.GX_NOMASK,prmT006810)
           ,new CursorDef("T006811", "UPDATE [CTIPOCAMBIO] SET [TipCompra]=@TipCompra, [TipVenta]=@TipVenta  WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech", GxErrorMask.GX_NOMASK,prmT006811)
           ,new CursorDef("T006812", "DELETE FROM [CTIPOCAMBIO]  WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech", GxErrorMask.GX_NOMASK,prmT006812)
           ,new CursorDef("T006813", "SELECT [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @TipMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006813,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006814", "SELECT [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] ORDER BY [TipMonCod], [TipFech]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006814,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
     }
  }

}

}
