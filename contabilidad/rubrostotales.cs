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
   public class rubrostotales : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rubrostotales.aspx")), "contabilidad.rubrostotales.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rubrostotales.aspx")))) ;
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
                  AV9TotTipo = GetPar( "TotTipo");
                  AssignAttri("", false, "AV9TotTipo", AV9TotTipo);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTOTTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TotTipo, "")), context));
                  AV10TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
                  AssignAttri("", false, "AV10TotRub", StringUtil.LTrimStr( (decimal)(AV10TotRub), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTOTRUB", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TotRub), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Rubros Totales", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public rubrostotales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubrostotales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_TotTipo ,
                           int aP2_TotRub )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV9TotTipo = aP1_TotTipo;
         this.AV10TotRub = aP2_TotRub;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTotTipo = new GXCombobox();
         cmbTotSts = new GXCombobox();
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
         if ( cmbTotTipo.ItemCount > 0 )
         {
            A114TotTipo = cmbTotTipo.getValidValue(A114TotTipo);
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTotTipo.CurrentValue = StringUtil.RTrim( A114TotTipo);
            AssignProp("", false, cmbTotTipo_Internalname, "Values", cmbTotTipo.ToJavascriptSource(), true);
         }
         if ( cmbTotSts.ItemCount > 0 )
         {
            A1930TotSts = (short)(NumberUtil.Val( cmbTotSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0))), "."));
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTotSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
            AssignProp("", false, cmbTotSts_Internalname, "Values", cmbTotSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTotTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTotTipo_Internalname, "Tipo de Reporte", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTotTipo, cmbTotTipo_Internalname, StringUtil.RTrim( A114TotTipo), 1, cmbTotTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTotTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeRealWidth", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 1, "HLP_Contabilidad\\RubrosTotales.htm");
         cmbTotTipo.CurrentValue = StringUtil.RTrim( A114TotTipo);
         AssignProp("", false, cmbTotTipo_Internalname, "Values", (string)(cmbTotTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotRub_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotRub_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotRub_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotRub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotRub_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotDsc_Internalname, "Titulo de Totales", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotDsc_Internalname, StringUtil.RTrim( A1928TotDsc), StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTotDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotDscTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotDscTot_Internalname, "Totales", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotDscTot_Internalname, StringUtil.RTrim( A1929TotDscTot), StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotDscTot_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTotDscTot_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotOrd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotOrd_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A120TotOrd), 2, 0, ".", "")), StringUtil.LTrim( ((edtTotOrd_Enabled!=0) ? context.localUtil.Format( (decimal)(A120TotOrd), "Z9") : context.localUtil.Format( (decimal)(A120TotOrd), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotOrd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotOrd_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTotSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTotSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTotSts, cmbTotSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0)), 1, cmbTotSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTotSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 1, "HLP_Contabilidad\\RubrosTotales.htm");
         cmbTotSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         AssignProp("", false, cmbTotSts_Internalname, "Values", (string)(cmbTotSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\RubrosTotales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11742 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z114TotTipo = cgiGet( "Z114TotTipo");
               Z115TotRub = (int)(context.localUtil.CToN( cgiGet( "Z115TotRub"), ".", ","));
               Z1928TotDsc = cgiGet( "Z1928TotDsc");
               Z1929TotDscTot = cgiGet( "Z1929TotDscTot");
               Z120TotOrd = (short)(context.localUtil.CToN( cgiGet( "Z120TotOrd"), ".", ","));
               Z1930TotSts = (short)(context.localUtil.CToN( cgiGet( "Z1930TotSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV9TotTipo = cgiGet( "vTOTTIPO");
               AV10TotRub = (int)(context.localUtil.CToN( cgiGet( "vTOTRUB"), ".", ","));
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
               cmbTotTipo.CurrentValue = cgiGet( cmbTotTipo_Internalname);
               A114TotTipo = cgiGet( cmbTotTipo_Internalname);
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTRUB");
                  AnyError = 1;
                  GX_FocusControl = edtTotRub_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A115TotRub = 0;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               }
               else
               {
                  A115TotRub = (int)(context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ","));
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               }
               A1928TotDsc = cgiGet( edtTotDsc_Internalname);
               AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
               A1929TotDscTot = cgiGet( edtTotDscTot_Internalname);
               AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTotOrd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotOrd_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTORD");
                  AnyError = 1;
                  GX_FocusControl = edtTotOrd_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A120TotOrd = 0;
                  AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
               }
               else
               {
                  A120TotOrd = (short)(context.localUtil.CToN( cgiGet( edtTotOrd_Internalname), ".", ","));
                  AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
               }
               cmbTotSts.CurrentValue = cgiGet( cmbTotSts_Internalname);
               A1930TotSts = (short)(NumberUtil.Val( cgiGet( cmbTotSts_Internalname), "."));
               AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"RubrosTotales");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\rubrostotales:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A114TotTipo = GetPar( "TotTipo");
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
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
                     sMode68 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode68;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound68 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_740( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TOTTIPO");
                        AnyError = 1;
                        GX_FocusControl = cmbTotTipo_Internalname;
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
                           E11742 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12742 ();
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
            E12742 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7468( ) ;
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
            DisableAttributes7468( ) ;
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

      protected void CONFIRM_740( )
      {
         BeforeValidate7468( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7468( ) ;
            }
            else
            {
               CheckExtendedTable7468( ) ;
               CloseExtendedTableCursors7468( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption740( )
      {
      }

      protected void E11742( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12742( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.rubrostotalesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM7468( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1928TotDsc = T00743_A1928TotDsc[0];
               Z1929TotDscTot = T00743_A1929TotDscTot[0];
               Z120TotOrd = T00743_A120TotOrd[0];
               Z1930TotSts = T00743_A1930TotSts[0];
            }
            else
            {
               Z1928TotDsc = A1928TotDsc;
               Z1929TotDscTot = A1929TotDscTot;
               Z120TotOrd = A120TotOrd;
               Z1930TotSts = A1930TotSts;
            }
         }
         if ( GX_JID == -12 )
         {
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z1928TotDsc = A1928TotDsc;
            Z1929TotDscTot = A1929TotDscTot;
            Z120TotOrd = A120TotOrd;
            Z1930TotSts = A1930TotSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9TotTipo)) )
         {
            A114TotTipo = AV9TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9TotTipo)) )
         {
            cmbTotTipo.Enabled = 0;
            AssignProp("", false, cmbTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotTipo.Enabled), 5, 0), true);
         }
         else
         {
            cmbTotTipo.Enabled = 1;
            AssignProp("", false, cmbTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotTipo.Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9TotTipo)) )
         {
            cmbTotTipo.Enabled = 0;
            AssignProp("", false, cmbTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotTipo.Enabled), 5, 0), true);
         }
         if ( ! (0==AV10TotRub) )
         {
            A115TotRub = AV10TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
         if ( ! (0==AV10TotRub) )
         {
            edtTotRub_Enabled = 0;
            AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         }
         else
         {
            edtTotRub_Enabled = 1;
            AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10TotRub) )
         {
            edtTotRub_Enabled = 0;
            AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1930TotSts) && ( Gx_BScreen == 0 ) )
         {
            A1930TotSts = 1;
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load7468( )
      {
         /* Using cursor T00744 */
         pr_default.execute(2, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound68 = 1;
            A1928TotDsc = T00744_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            A1929TotDscTot = T00744_A1929TotDscTot[0];
            AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
            A120TotOrd = T00744_A120TotOrd[0];
            AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
            A1930TotSts = T00744_A1930TotSts[0];
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
            ZM7468( -12) ;
         }
         pr_default.close(2);
         OnLoadActions7468( ) ;
      }

      protected void OnLoadActions7468( )
      {
      }

      protected void CheckExtendedTable7468( )
      {
         nIsDirty_68 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A114TotTipo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Reporte", "", "", "", "", "", "", "", ""), 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A115TotRub) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo Rubro Totales", "", "", "", "", "", "", "", ""), 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = edtTotRub_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1928TotDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Titulo de Totales", "", "", "", "", "", "", "", ""), 1, "TOTDSC");
            AnyError = 1;
            GX_FocusControl = edtTotDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A120TotOrd) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "N° Orden", "", "", "", "", "", "", "", ""), 1, "TOTORD");
            AnyError = 1;
            GX_FocusControl = edtTotOrd_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7468( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7468( )
      {
         /* Using cursor T00745 */
         pr_default.execute(3, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00743 */
         pr_default.execute(1, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7468( 12) ;
            RcdFound68 = 1;
            A114TotTipo = T00743_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T00743_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A1928TotDsc = T00743_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            A1929TotDscTot = T00743_A1929TotDscTot[0];
            AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
            A120TotOrd = T00743_A120TotOrd[0];
            AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
            A1930TotSts = T00743_A1930TotSts[0];
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7468( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey7468( ) ;
            }
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey7468( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7468( ) ;
         if ( RcdFound68 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound68 = 0;
         /* Using cursor T00746 */
         pr_default.execute(4, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00746_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T00746_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00746_A115TotRub[0] < A115TotRub ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00746_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T00746_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00746_A115TotRub[0] > A115TotRub ) ) )
            {
               A114TotTipo = T00746_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T00746_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               RcdFound68 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound68 = 0;
         /* Using cursor T00747 */
         pr_default.execute(5, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00747_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T00747_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00747_A115TotRub[0] > A115TotRub ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00747_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T00747_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00747_A115TotRub[0] < A115TotRub ) ) )
            {
               A114TotTipo = T00747_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T00747_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               RcdFound68 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7468( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7468( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
               {
                  A114TotTipo = Z114TotTipo;
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = Z115TotRub;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOTTIPO");
                  AnyError = 1;
                  GX_FocusControl = cmbTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7468( ) ;
                  GX_FocusControl = cmbTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
               {
                  /* Insert record */
                  GX_FocusControl = cmbTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7468( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOTTIPO");
                     AnyError = 1;
                     GX_FocusControl = cmbTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7468( ) ;
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
         if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
         {
            A114TotTipo = Z114TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = Z115TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7468( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00742 */
            pr_default.execute(0, new Object[] {A114TotTipo, A115TotRub});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROST"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1928TotDsc, T00742_A1928TotDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1929TotDscTot, T00742_A1929TotDscTot[0]) != 0 ) || ( Z120TotOrd != T00742_A120TotOrd[0] ) || ( Z1930TotSts != T00742_A1930TotSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1928TotDsc, T00742_A1928TotDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.rubrostotales:[seudo value changed for attri]"+"TotDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1928TotDsc);
                  GXUtil.WriteLogRaw("Current: ",T00742_A1928TotDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1929TotDscTot, T00742_A1929TotDscTot[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.rubrostotales:[seudo value changed for attri]"+"TotDscTot");
                  GXUtil.WriteLogRaw("Old: ",Z1929TotDscTot);
                  GXUtil.WriteLogRaw("Current: ",T00742_A1929TotDscTot[0]);
               }
               if ( Z120TotOrd != T00742_A120TotOrd[0] )
               {
                  GXUtil.WriteLog("contabilidad.rubrostotales:[seudo value changed for attri]"+"TotOrd");
                  GXUtil.WriteLogRaw("Old: ",Z120TotOrd);
                  GXUtil.WriteLogRaw("Current: ",T00742_A120TotOrd[0]);
               }
               if ( Z1930TotSts != T00742_A1930TotSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.rubrostotales:[seudo value changed for attri]"+"TotSts");
                  GXUtil.WriteLogRaw("Old: ",Z1930TotSts);
                  GXUtil.WriteLogRaw("Current: ",T00742_A1930TotSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROST"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7468( )
      {
         BeforeValidate7468( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7468( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7468( 0) ;
            CheckOptimisticConcurrency7468( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7468( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7468( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00748 */
                     pr_default.execute(6, new Object[] {A114TotTipo, A115TotRub, A1928TotDsc, A1929TotDscTot, A120TotOrd, A1930TotSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROST");
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
                           ResetCaption740( ) ;
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
               Load7468( ) ;
            }
            EndLevel7468( ) ;
         }
         CloseExtendedTableCursors7468( ) ;
      }

      protected void Update7468( )
      {
         BeforeValidate7468( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7468( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7468( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7468( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7468( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00749 */
                     pr_default.execute(7, new Object[] {A1928TotDsc, A1929TotDscTot, A120TotOrd, A1930TotSts, A114TotTipo, A115TotRub});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROST");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROST"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7468( ) ;
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
            EndLevel7468( ) ;
         }
         CloseExtendedTableCursors7468( ) ;
      }

      protected void DeferredUpdate7468( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7468( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7468( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7468( ) ;
            AfterConfirm7468( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7468( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007410 */
                  pr_default.execute(8, new Object[] {A114TotTipo, A115TotRub});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBRUBROST");
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
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7468( ) ;
         Gx_mode = sMode68;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7468( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007411 */
            pr_default.execute(9, new Object[] {A114TotTipo, A115TotRub});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Rubros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel7468( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7468( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("contabilidad.rubrostotales",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues740( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("contabilidad.rubrostotales",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7468( )
      {
         /* Scan By routine */
         /* Using cursor T007412 */
         pr_default.execute(10);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound68 = 1;
            A114TotTipo = T007412_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T007412_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7468( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound68 = 1;
            A114TotTipo = T007412_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T007412_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
      }

      protected void ScanEnd7468( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm7468( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7468( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7468( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7468( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7468( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7468( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7468( )
      {
         cmbTotTipo.Enabled = 0;
         AssignProp("", false, cmbTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotTipo.Enabled), 5, 0), true);
         edtTotRub_Enabled = 0;
         AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         edtTotDsc_Enabled = 0;
         AssignProp("", false, edtTotDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotDsc_Enabled), 5, 0), true);
         edtTotDscTot_Enabled = 0;
         AssignProp("", false, edtTotDscTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotDscTot_Enabled), 5, 0), true);
         edtTotOrd_Enabled = 0;
         AssignProp("", false, edtTotOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotOrd_Enabled), 5, 0), true);
         cmbTotSts.Enabled = 0;
         AssignProp("", false, cmbTotSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7468( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues740( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265757", false, true);
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
         GXEncryptionTmp = "contabilidad.rubrostotales.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV9TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV10TotRub,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.rubrostotales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"RubrosTotales");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\rubrostotales:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1928TotDsc", StringUtil.RTrim( Z1928TotDsc));
         GxWebStd.gx_hidden_field( context, "Z1929TotDscTot", StringUtil.RTrim( Z1929TotDscTot));
         GxWebStd.gx_hidden_field( context, "Z120TotOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120TotOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1930TotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1930TotSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vTOTTIPO", StringUtil.RTrim( AV9TotTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOTTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TotTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vTOTRUB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOTRUB", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TotRub), "ZZZZZ9"), context));
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
         GXEncryptionTmp = "contabilidad.rubrostotales.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV9TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV10TotRub,6,0));
         return formatLink("contabilidad.rubrostotales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.RubrosTotales" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rubros Totales" ;
      }

      protected void InitializeNonKey7468( )
      {
         A1928TotDsc = "";
         AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
         A1929TotDscTot = "";
         AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
         A120TotOrd = 0;
         AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
         A1930TotSts = 1;
         AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         Z1928TotDsc = "";
         Z1929TotDscTot = "";
         Z120TotOrd = 0;
         Z1930TotSts = 0;
      }

      protected void InitAll7468( )
      {
         A114TotTipo = "";
         AssignAttri("", false, "A114TotTipo", A114TotTipo);
         A115TotRub = 0;
         AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         InitializeNonKey7468( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1930TotSts = i1930TotSts;
         AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265774", true, true);
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
         context.AddJavascriptSource("contabilidad/rubrostotales.js", "?202281810265775", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbTotTipo_Internalname = "TOTTIPO";
         edtTotRub_Internalname = "TOTRUB";
         edtTotDsc_Internalname = "TOTDSC";
         edtTotDscTot_Internalname = "TOTDSCTOT";
         edtTotOrd_Internalname = "TOTORD";
         cmbTotSts_Internalname = "TOTSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Rubros Totales";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTotSts_Jsonclick = "";
         cmbTotSts.Enabled = 1;
         edtTotOrd_Jsonclick = "";
         edtTotOrd_Enabled = 1;
         edtTotDscTot_Jsonclick = "";
         edtTotDscTot_Enabled = 1;
         edtTotDsc_Jsonclick = "";
         edtTotDsc_Enabled = 1;
         edtTotRub_Jsonclick = "";
         edtTotRub_Enabled = 1;
         cmbTotTipo_Jsonclick = "";
         cmbTotTipo.Enabled = 1;
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
         cmbTotTipo.Name = "TOTTIPO";
         cmbTotTipo.WebTags = "";
         if ( cmbTotTipo.ItemCount > 0 )
         {
            A114TotTipo = cmbTotTipo.getValidValue(A114TotTipo);
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
         }
         cmbTotSts.Name = "TOTSTS";
         cmbTotSts.WebTags = "";
         cmbTotSts.addItem("1", "ACTIVO", 0);
         cmbTotSts.addItem("0", "INACTIVO", 0);
         if ( cmbTotSts.ItemCount > 0 )
         {
            if ( (0==A1930TotSts) )
            {
               A1930TotSts = 1;
               AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TotTipo',fld:'vTOTTIPO',pic:'',hsh:true},{av:'AV10TotRub',fld:'vTOTRUB',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV9TotTipo',fld:'vTOTTIPO',pic:'',hsh:true},{av:'AV10TotRub',fld:'vTOTRUB',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12742',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TOTTIPO","{handler:'Valid_Tottipo',iparms:[]");
         setEventMetadata("VALID_TOTTIPO",",oparms:[]}");
         setEventMetadata("VALID_TOTRUB","{handler:'Valid_Totrub',iparms:[]");
         setEventMetadata("VALID_TOTRUB",",oparms:[]}");
         setEventMetadata("VALID_TOTDSC","{handler:'Valid_Totdsc',iparms:[]");
         setEventMetadata("VALID_TOTDSC",",oparms:[]}");
         setEventMetadata("VALID_TOTORD","{handler:'Valid_Totord',iparms:[]");
         setEventMetadata("VALID_TOTORD",",oparms:[]}");
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
         wcpOAV9TotTipo = "";
         Z114TotTipo = "";
         Z1928TotDsc = "";
         Z1929TotDscTot = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A114TotTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode68 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         T00744_A114TotTipo = new string[] {""} ;
         T00744_A115TotRub = new int[1] ;
         T00744_A1928TotDsc = new string[] {""} ;
         T00744_A1929TotDscTot = new string[] {""} ;
         T00744_A120TotOrd = new short[1] ;
         T00744_A1930TotSts = new short[1] ;
         T00745_A114TotTipo = new string[] {""} ;
         T00745_A115TotRub = new int[1] ;
         T00743_A114TotTipo = new string[] {""} ;
         T00743_A115TotRub = new int[1] ;
         T00743_A1928TotDsc = new string[] {""} ;
         T00743_A1929TotDscTot = new string[] {""} ;
         T00743_A120TotOrd = new short[1] ;
         T00743_A1930TotSts = new short[1] ;
         T00746_A114TotTipo = new string[] {""} ;
         T00746_A115TotRub = new int[1] ;
         T00747_A114TotTipo = new string[] {""} ;
         T00747_A115TotRub = new int[1] ;
         T00742_A114TotTipo = new string[] {""} ;
         T00742_A115TotRub = new int[1] ;
         T00742_A1928TotDsc = new string[] {""} ;
         T00742_A1929TotDscTot = new string[] {""} ;
         T00742_A120TotOrd = new short[1] ;
         T00742_A1930TotSts = new short[1] ;
         T007411_A114TotTipo = new string[] {""} ;
         T007411_A115TotRub = new int[1] ;
         T007411_A116RubCod = new int[1] ;
         T007412_A114TotTipo = new string[] {""} ;
         T007412_A115TotRub = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubrostotales__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubrostotales__default(),
            new Object[][] {
                new Object[] {
               T00742_A114TotTipo, T00742_A115TotRub, T00742_A1928TotDsc, T00742_A1929TotDscTot, T00742_A120TotOrd, T00742_A1930TotSts
               }
               , new Object[] {
               T00743_A114TotTipo, T00743_A115TotRub, T00743_A1928TotDsc, T00743_A1929TotDscTot, T00743_A120TotOrd, T00743_A1930TotSts
               }
               , new Object[] {
               T00744_A114TotTipo, T00744_A115TotRub, T00744_A1928TotDsc, T00744_A1929TotDscTot, T00744_A120TotOrd, T00744_A1930TotSts
               }
               , new Object[] {
               T00745_A114TotTipo, T00745_A115TotRub
               }
               , new Object[] {
               T00746_A114TotTipo, T00746_A115TotRub
               }
               , new Object[] {
               T00747_A114TotTipo, T00747_A115TotRub
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007411_A114TotTipo, T007411_A115TotRub, T007411_A116RubCod
               }
               , new Object[] {
               T007412_A114TotTipo, T007412_A115TotRub
               }
            }
         );
         Z1930TotSts = 1;
         A1930TotSts = 1;
         i1930TotSts = 1;
      }

      private short Z120TotOrd ;
      private short Z1930TotSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1930TotSts ;
      private short A120TotOrd ;
      private short Gx_BScreen ;
      private short RcdFound68 ;
      private short GX_JID ;
      private short nIsDirty_68 ;
      private short gxajaxcallmode ;
      private short i1930TotSts ;
      private int wcpOAV10TotRub ;
      private int Z115TotRub ;
      private int AV10TotRub ;
      private int trnEnded ;
      private int A115TotRub ;
      private int edtTotRub_Enabled ;
      private int edtTotDsc_Enabled ;
      private int edtTotDscTot_Enabled ;
      private int edtTotOrd_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV9TotTipo ;
      private string Z114TotTipo ;
      private string Z1928TotDsc ;
      private string Z1929TotDscTot ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV9TotTipo ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbTotTipo_Internalname ;
      private string A114TotTipo ;
      private string cmbTotSts_Internalname ;
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
      private string cmbTotTipo_Jsonclick ;
      private string edtTotRub_Internalname ;
      private string edtTotRub_Jsonclick ;
      private string edtTotDsc_Internalname ;
      private string A1928TotDsc ;
      private string edtTotDsc_Jsonclick ;
      private string edtTotDscTot_Internalname ;
      private string A1929TotDscTot ;
      private string edtTotDscTot_Jsonclick ;
      private string edtTotOrd_Internalname ;
      private string edtTotOrd_Jsonclick ;
      private string cmbTotSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode68 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
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
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTotTipo ;
      private GXCombobox cmbTotSts ;
      private IDataStoreProvider pr_default ;
      private string[] T00744_A114TotTipo ;
      private int[] T00744_A115TotRub ;
      private string[] T00744_A1928TotDsc ;
      private string[] T00744_A1929TotDscTot ;
      private short[] T00744_A120TotOrd ;
      private short[] T00744_A1930TotSts ;
      private string[] T00745_A114TotTipo ;
      private int[] T00745_A115TotRub ;
      private string[] T00743_A114TotTipo ;
      private int[] T00743_A115TotRub ;
      private string[] T00743_A1928TotDsc ;
      private string[] T00743_A1929TotDscTot ;
      private short[] T00743_A120TotOrd ;
      private short[] T00743_A1930TotSts ;
      private string[] T00746_A114TotTipo ;
      private int[] T00746_A115TotRub ;
      private string[] T00747_A114TotTipo ;
      private int[] T00747_A115TotRub ;
      private string[] T00742_A114TotTipo ;
      private int[] T00742_A115TotRub ;
      private string[] T00742_A1928TotDsc ;
      private string[] T00742_A1929TotDscTot ;
      private short[] T00742_A120TotOrd ;
      private short[] T00742_A1930TotSts ;
      private string[] T007411_A114TotTipo ;
      private int[] T007411_A115TotRub ;
      private int[] T007411_A116RubCod ;
      private string[] T007412_A114TotTipo ;
      private int[] T007412_A115TotRub ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class rubrostotales__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class rubrostotales__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00744;
        prmT00744 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00745;
        prmT00745 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00743;
        prmT00743 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00746;
        prmT00746 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00747;
        prmT00747 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00742;
        prmT00742 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00748;
        prmT00748 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@TotDsc",GXType.NChar,100,0) ,
        new ParDef("@TotDscTot",GXType.NChar,100,0) ,
        new ParDef("@TotOrd",GXType.Int16,2,0) ,
        new ParDef("@TotSts",GXType.Int16,1,0)
        };
        Object[] prmT00749;
        prmT00749 = new Object[] {
        new ParDef("@TotDsc",GXType.NChar,100,0) ,
        new ParDef("@TotDscTot",GXType.NChar,100,0) ,
        new ParDef("@TotOrd",GXType.Int16,2,0) ,
        new ParDef("@TotSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT007410;
        prmT007410 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT007411;
        prmT007411 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT007412;
        prmT007412 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00742", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd], [TotSts] FROM [CBRUBROST] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT00742,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00743", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd], [TotSts] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT00743,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00744", "SELECT TM1.[TotTipo], TM1.[TotRub], TM1.[TotDsc], TM1.[TotDscTot], TM1.[TotOrd], TM1.[TotSts] FROM [CBRUBROST] TM1 WHERE TM1.[TotTipo] = @TotTipo and TM1.[TotRub] = @TotRub ORDER BY TM1.[TotTipo], TM1.[TotRub]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00744,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00745", "SELECT [TotTipo], [TotRub] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00745,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00746", "SELECT TOP 1 [TotTipo], [TotRub] FROM [CBRUBROST] WHERE ( [TotTipo] > @TotTipo or [TotTipo] = @TotTipo and [TotRub] > @TotRub) ORDER BY [TotTipo], [TotRub]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00746,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00747", "SELECT TOP 1 [TotTipo], [TotRub] FROM [CBRUBROST] WHERE ( [TotTipo] < @TotTipo or [TotTipo] = @TotTipo and [TotRub] < @TotRub) ORDER BY [TotTipo] DESC, [TotRub] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00747,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00748", "INSERT INTO [CBRUBROST]([TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd], [TotSts]) VALUES(@TotTipo, @TotRub, @TotDsc, @TotDscTot, @TotOrd, @TotSts)", GxErrorMask.GX_NOMASK,prmT00748)
           ,new CursorDef("T00749", "UPDATE [CBRUBROST] SET [TotDsc]=@TotDsc, [TotDscTot]=@TotDscTot, [TotOrd]=@TotOrd, [TotSts]=@TotSts  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub", GxErrorMask.GX_NOMASK,prmT00749)
           ,new CursorDef("T007410", "DELETE FROM [CBRUBROST]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub", GxErrorMask.GX_NOMASK,prmT007410)
           ,new CursorDef("T007411", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT007411,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007412", "SELECT [TotTipo], [TotRub] FROM [CBRUBROST] ORDER BY [TotTipo], [TotRub]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007412,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
