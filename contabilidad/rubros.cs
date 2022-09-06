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
   public class rubros : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TOTRUB") == 0 )
         {
            A114TotTipo = GetPar( "TotTipo");
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLATOTRUB7565( A114TotTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A114TotTipo = GetPar( "TotTipo");
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A114TotTipo, A115TotRub) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rubros.aspx")), "contabilidad.rubros.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rubros.aspx")))) ;
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
                  AV11RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
                  AssignAttri("", false, "AV11RubCod", StringUtil.LTrimStr( (decimal)(AV11RubCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vRUBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11RubCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Rubros", 0) ;
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

      public rubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_TotTipo ,
                           int aP2_TotRub ,
                           int aP3_RubCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV9TotTipo = aP1_TotTipo;
         this.AV10TotRub = aP2_TotRub;
         this.AV11RubCod = aP3_RubCod;
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
         dynTotRub = new GXCombobox();
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
         if ( dynTotRub.ItemCount > 0 )
         {
            A115TotRub = (int)(NumberUtil.Val( dynTotRub.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0))), "."));
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTotRub.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0));
            AssignProp("", false, dynTotRub_Internalname, "Values", dynTotRub.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTotTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTotTipo_Internalname, "Tipo de Reporte", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTotTipo, cmbTotTipo_Internalname, StringUtil.RTrim( A114TotTipo), 1, cmbTotTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTotTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeRealWidth", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 1, "HLP_Contabilidad\\Rubros.htm");
         cmbTotTipo.CurrentValue = StringUtil.RTrim( A114TotTipo);
         AssignProp("", false, cmbTotTipo_Internalname, "Values", (string)(cmbTotTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynTotRub_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynTotRub_Internalname, "Codigo Rubro Totales", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTotRub, dynTotRub_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0)), 1, dynTotRub_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTotRub.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 1, "HLP_Contabilidad\\Rubros.htm");
         dynTotRub.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0));
         AssignProp("", false, dynTotRub_Internalname, "Values", (string)(dynTotRub.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotDsc_Internalname, "Titulo de Totales", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTotDsc_Internalname, StringUtil.RTrim( A1928TotDsc), StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubCod_Internalname, "Codigo Rubro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubDsc_Internalname, "Rubro", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubDsc_Internalname, StringUtil.RTrim( A1822RubDsc), StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtRubDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubDscTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubDscTot_Internalname, "Totales de Rubros", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubDscTot_Internalname, StringUtil.RTrim( A1823RubDscTot), StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubDscTot_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtRubDscTot_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubOrd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubOrd_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A117RubOrd), 2, 0, ".", "")), StringUtil.LTrim( ((edtRubOrd_Enabled!=0) ? context.localUtil.Format( (decimal)(A117RubOrd), "Z9") : context.localUtil.Format( (decimal)(A117RubOrd), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubOrd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubOrd_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1829RubSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtRubSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1829RubSts), "9") : context.localUtil.Format( (decimal)(A1829RubSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Rubros.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Rubros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Rubros.htm");
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
         E11752 ();
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
               Z116RubCod = (int)(context.localUtil.CToN( cgiGet( "Z116RubCod"), ".", ","));
               Z1822RubDsc = cgiGet( "Z1822RubDsc");
               Z1823RubDscTot = cgiGet( "Z1823RubDscTot");
               Z117RubOrd = (short)(context.localUtil.CToN( cgiGet( "Z117RubOrd"), ".", ","));
               Z1829RubSts = (short)(context.localUtil.CToN( cgiGet( "Z1829RubSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV9TotTipo = cgiGet( "vTOTTIPO");
               AV10TotRub = (int)(context.localUtil.CToN( cgiGet( "vTOTRUB"), ".", ","));
               AV11RubCod = (int)(context.localUtil.CToN( cgiGet( "vRUBCOD"), ".", ","));
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
               dynTotRub.CurrentValue = cgiGet( dynTotRub_Internalname);
               A115TotRub = (int)(NumberUtil.Val( cgiGet( dynTotRub_Internalname), "."));
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A1928TotDsc = cgiGet( edtTotDsc_Internalname);
               AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBCOD");
                  AnyError = 1;
                  GX_FocusControl = edtRubCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A116RubCod = 0;
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               }
               else
               {
                  A116RubCod = (int)(context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ","));
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               }
               A1822RubDsc = cgiGet( edtRubDsc_Internalname);
               AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
               A1823RubDscTot = cgiGet( edtRubDscTot_Internalname);
               AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubOrd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubOrd_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBORD");
                  AnyError = 1;
                  GX_FocusControl = edtRubOrd_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A117RubOrd = 0;
                  AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
               }
               else
               {
                  A117RubOrd = (short)(context.localUtil.CToN( cgiGet( edtRubOrd_Internalname), ".", ","));
                  AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBSTS");
                  AnyError = 1;
                  GX_FocusControl = edtRubSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1829RubSts = 0;
                  AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
               }
               else
               {
                  A1829RubSts = (short)(context.localUtil.CToN( cgiGet( edtRubSts_Internalname), ".", ","));
                  AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Rubros");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\rubros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A116RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
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
                     sMode65 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode65;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound65 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_750( ) ;
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
                           E11752 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12752 ();
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
            E12752 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7565( ) ;
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
            DisableAttributes7565( ) ;
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

      protected void CONFIRM_750( )
      {
         BeforeValidate7565( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7565( ) ;
            }
            else
            {
               CheckExtendedTable7565( ) ;
               CloseExtendedTableCursors7565( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption750( )
      {
      }

      protected void E11752( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12752( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV13TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.rubrosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM7565( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1822RubDsc = T00753_A1822RubDsc[0];
               Z1823RubDscTot = T00753_A1823RubDscTot[0];
               Z117RubOrd = T00753_A117RubOrd[0];
               Z1829RubSts = T00753_A1829RubSts[0];
            }
            else
            {
               Z1822RubDsc = A1822RubDsc;
               Z1823RubDscTot = A1823RubDscTot;
               Z117RubOrd = A117RubOrd;
               Z1829RubSts = A1829RubSts;
            }
         }
         if ( GX_JID == -12 )
         {
            Z116RubCod = A116RubCod;
            Z1822RubDsc = A1822RubDsc;
            Z1823RubDscTot = A1823RubDscTot;
            Z117RubOrd = A117RubOrd;
            Z1829RubSts = A1829RubSts;
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z1928TotDsc = A1928TotDsc;
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
            dynTotRub.Enabled = 0;
            AssignProp("", false, dynTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTotRub.Enabled), 5, 0), true);
         }
         else
         {
            dynTotRub.Enabled = 1;
            AssignProp("", false, dynTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTotRub.Enabled), 5, 0), true);
         }
         if ( ! (0==AV10TotRub) )
         {
            dynTotRub.Enabled = 0;
            AssignProp("", false, dynTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTotRub.Enabled), 5, 0), true);
         }
         if ( ! (0==AV11RubCod) )
         {
            A116RubCod = AV11RubCod;
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         }
         if ( ! (0==AV11RubCod) )
         {
            edtRubCod_Enabled = 0;
            AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         }
         else
         {
            edtRubCod_Enabled = 1;
            AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV11RubCod) )
         {
            edtRubCod_Enabled = 0;
            AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1829RubSts) && ( Gx_BScreen == 0 ) )
         {
            A1829RubSts = 1;
            AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXATOTRUB_html7565( A114TotTipo) ;
            /* Using cursor T00754 */
            pr_default.execute(2, new Object[] {A114TotTipo, A115TotRub});
            A1928TotDsc = T00754_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            pr_default.close(2);
         }
      }

      protected void Load7565( )
      {
         /* Using cursor T00755 */
         pr_default.execute(3, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound65 = 1;
            A1928TotDsc = T00755_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            A1822RubDsc = T00755_A1822RubDsc[0];
            AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
            A1823RubDscTot = T00755_A1823RubDscTot[0];
            AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
            A117RubOrd = T00755_A117RubOrd[0];
            AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
            A1829RubSts = T00755_A1829RubSts[0];
            AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
            ZM7565( -12) ;
         }
         pr_default.close(3);
         OnLoadActions7565( ) ;
      }

      protected void OnLoadActions7565( )
      {
         GXATOTRUB_html7565( A114TotTipo) ;
      }

      protected void CheckExtendedTable7565( )
      {
         nIsDirty_65 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXATOTRUB_html7565( A114TotTipo) ;
         /* Using cursor T00754 */
         pr_default.execute(2, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1928TotDsc = T00754_A1928TotDsc[0];
         AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7565( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( string A114TotTipo ,
                                int A115TotRub )
      {
         /* Using cursor T00756 */
         pr_default.execute(4, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1928TotDsc = T00756_A1928TotDsc[0];
         AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1928TotDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey7565( )
      {
         /* Using cursor T00757 */
         pr_default.execute(5, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound65 = 1;
         }
         else
         {
            RcdFound65 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00753 */
         pr_default.execute(1, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7565( 12) ;
            RcdFound65 = 1;
            A116RubCod = T00753_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A1822RubDsc = T00753_A1822RubDsc[0];
            AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
            A1823RubDscTot = T00753_A1823RubDscTot[0];
            AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
            A117RubOrd = T00753_A117RubOrd[0];
            AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
            A1829RubSts = T00753_A1829RubSts[0];
            AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
            A114TotTipo = T00753_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T00753_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            sMode65 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7565( ) ;
            if ( AnyError == 1 )
            {
               RcdFound65 = 0;
               InitializeNonKey7565( ) ;
            }
            Gx_mode = sMode65;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound65 = 0;
            InitializeNonKey7565( ) ;
            sMode65 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode65;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7565( ) ;
         if ( RcdFound65 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound65 = 0;
         /* Using cursor T00758 */
         pr_default.execute(6, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00758_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T00758_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00758_A115TotRub[0] < A115TotRub ) || ( T00758_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T00758_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00758_A116RubCod[0] < A116RubCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00758_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T00758_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00758_A115TotRub[0] > A115TotRub ) || ( T00758_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T00758_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00758_A116RubCod[0] > A116RubCod ) ) )
            {
               A114TotTipo = T00758_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T00758_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T00758_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               RcdFound65 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound65 = 0;
         /* Using cursor T00759 */
         pr_default.execute(7, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00759_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T00759_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00759_A115TotRub[0] > A115TotRub ) || ( T00759_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T00759_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00759_A116RubCod[0] > A116RubCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00759_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T00759_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00759_A115TotRub[0] < A115TotRub ) || ( T00759_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T00759_A114TotTipo[0], A114TotTipo) == 0 ) && ( T00759_A116RubCod[0] < A116RubCod ) ) )
            {
               A114TotTipo = T00759_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T00759_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T00759_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               RcdFound65 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7565( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7565( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound65 == 1 )
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
               {
                  A114TotTipo = Z114TotTipo;
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = Z115TotRub;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  A116RubCod = Z116RubCod;
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
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
                  Update7565( ) ;
                  GX_FocusControl = cmbTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
               {
                  /* Insert record */
                  GX_FocusControl = cmbTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7565( ) ;
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
                     Insert7565( ) ;
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
         if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
         {
            A114TotTipo = Z114TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = Z115TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = Z116RubCod;
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
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

      protected void CheckOptimisticConcurrency7565( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00752 */
            pr_default.execute(0, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1822RubDsc, T00752_A1822RubDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1823RubDscTot, T00752_A1823RubDscTot[0]) != 0 ) || ( Z117RubOrd != T00752_A117RubOrd[0] ) || ( Z1829RubSts != T00752_A1829RubSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1822RubDsc, T00752_A1822RubDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.rubros:[seudo value changed for attri]"+"RubDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1822RubDsc);
                  GXUtil.WriteLogRaw("Current: ",T00752_A1822RubDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1823RubDscTot, T00752_A1823RubDscTot[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.rubros:[seudo value changed for attri]"+"RubDscTot");
                  GXUtil.WriteLogRaw("Old: ",Z1823RubDscTot);
                  GXUtil.WriteLogRaw("Current: ",T00752_A1823RubDscTot[0]);
               }
               if ( Z117RubOrd != T00752_A117RubOrd[0] )
               {
                  GXUtil.WriteLog("contabilidad.rubros:[seudo value changed for attri]"+"RubOrd");
                  GXUtil.WriteLogRaw("Old: ",Z117RubOrd);
                  GXUtil.WriteLogRaw("Current: ",T00752_A117RubOrd[0]);
               }
               if ( Z1829RubSts != T00752_A1829RubSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.rubros:[seudo value changed for attri]"+"RubSts");
                  GXUtil.WriteLogRaw("Old: ",Z1829RubSts);
                  GXUtil.WriteLogRaw("Current: ",T00752_A1829RubSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7565( )
      {
         BeforeValidate7565( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7565( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7565( 0) ;
            CheckOptimisticConcurrency7565( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7565( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7565( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007510 */
                     pr_default.execute(8, new Object[] {A116RubCod, A1822RubDsc, A1823RubDscTot, A117RubOrd, A1829RubSts, A114TotTipo, A115TotRub});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROS");
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
                           ResetCaption750( ) ;
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
               Load7565( ) ;
            }
            EndLevel7565( ) ;
         }
         CloseExtendedTableCursors7565( ) ;
      }

      protected void Update7565( )
      {
         BeforeValidate7565( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7565( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7565( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7565( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7565( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007511 */
                     pr_default.execute(9, new Object[] {A1822RubDsc, A1823RubDscTot, A117RubOrd, A1829RubSts, A114TotTipo, A115TotRub, A116RubCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7565( ) ;
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
            EndLevel7565( ) ;
         }
         CloseExtendedTableCursors7565( ) ;
      }

      protected void DeferredUpdate7565( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7565( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7565( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7565( ) ;
            AfterConfirm7565( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7565( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007512 */
                  pr_default.execute(10, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBRUBROS");
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
         sMode65 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7565( ) ;
         Gx_mode = sMode65;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7565( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXATOTRUB_html7565( A114TotTipo) ;
            /* Using cursor T007513 */
            pr_default.execute(11, new Object[] {A114TotTipo, A115TotRub});
            A1928TotDsc = T007513_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007514 */
            pr_default.execute(12, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Rubros Lineas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel7565( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7565( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("contabilidad.rubros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues750( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("contabilidad.rubros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7565( )
      {
         /* Scan By routine */
         /* Using cursor T007515 */
         pr_default.execute(13);
         RcdFound65 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound65 = 1;
            A114TotTipo = T007515_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T007515_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T007515_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7565( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound65 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound65 = 1;
            A114TotTipo = T007515_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T007515_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T007515_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         }
      }

      protected void ScanEnd7565( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm7565( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7565( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7565( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7565( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7565( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7565( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7565( )
      {
         cmbTotTipo.Enabled = 0;
         AssignProp("", false, cmbTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotTipo.Enabled), 5, 0), true);
         dynTotRub.Enabled = 0;
         AssignProp("", false, dynTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTotRub.Enabled), 5, 0), true);
         edtTotDsc_Enabled = 0;
         AssignProp("", false, edtTotDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotDsc_Enabled), 5, 0), true);
         edtRubCod_Enabled = 0;
         AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         edtRubDsc_Enabled = 0;
         AssignProp("", false, edtRubDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubDsc_Enabled), 5, 0), true);
         edtRubDscTot_Enabled = 0;
         AssignProp("", false, edtRubDscTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubDscTot_Enabled), 5, 0), true);
         edtRubOrd_Enabled = 0;
         AssignProp("", false, edtRubOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubOrd_Enabled), 5, 0), true);
         edtRubSts_Enabled = 0;
         AssignProp("", false, edtRubSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7565( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues750( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265951", false, true);
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
         GXEncryptionTmp = "contabilidad.rubros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV9TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV10TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11RubCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.rubros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Rubros");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\rubros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116RubCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z116RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1822RubDsc", StringUtil.RTrim( Z1822RubDsc));
         GxWebStd.gx_hidden_field( context, "Z1823RubDscTot", StringUtil.RTrim( Z1823RubDscTot));
         GxWebStd.gx_hidden_field( context, "Z117RubOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z117RubOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1829RubSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1829RubSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV13TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV13TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTOTTIPO", StringUtil.RTrim( AV9TotTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOTTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TotTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vTOTRUB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOTRUB", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TotRub), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRUBCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRUBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11RubCod), "ZZZZZ9"), context));
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
         GXEncryptionTmp = "contabilidad.rubros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV9TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV10TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11RubCod,6,0));
         return formatLink("contabilidad.rubros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.Rubros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rubros" ;
      }

      protected void InitializeNonKey7565( )
      {
         A1928TotDsc = "";
         AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
         A1822RubDsc = "";
         AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
         A1823RubDscTot = "";
         AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
         A117RubOrd = 0;
         AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
         A1829RubSts = 1;
         AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
         Z1822RubDsc = "";
         Z1823RubDscTot = "";
         Z117RubOrd = 0;
         Z1829RubSts = 0;
      }

      protected void InitAll7565( )
      {
         A114TotTipo = "";
         AssignAttri("", false, "A114TotTipo", A114TotTipo);
         A115TotRub = 0;
         AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         A116RubCod = 0;
         AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         InitializeNonKey7565( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1829RubSts = i1829RubSts;
         AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265975", true, true);
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
         context.AddJavascriptSource("contabilidad/rubros.js", "?202281810265976", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbTotTipo_Internalname = "TOTTIPO";
         dynTotRub_Internalname = "TOTRUB";
         edtTotDsc_Internalname = "TOTDSC";
         edtRubCod_Internalname = "RUBCOD";
         edtRubDsc_Internalname = "RUBDSC";
         edtRubDscTot_Internalname = "RUBDSCTOT";
         edtRubOrd_Internalname = "RUBORD";
         edtRubSts_Internalname = "RUBSTS";
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
         Form.Caption = "Rubros";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtRubSts_Jsonclick = "";
         edtRubSts_Enabled = 1;
         edtRubOrd_Jsonclick = "";
         edtRubOrd_Enabled = 1;
         edtRubDscTot_Jsonclick = "";
         edtRubDscTot_Enabled = 1;
         edtRubDsc_Jsonclick = "";
         edtRubDsc_Enabled = 1;
         edtRubCod_Jsonclick = "";
         edtRubCod_Enabled = 1;
         edtTotDsc_Jsonclick = "";
         edtTotDsc_Enabled = 0;
         dynTotRub_Jsonclick = "";
         dynTotRub.Enabled = 1;
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
         GXATOTRUB_html7565( A114TotTipo) ;
         /* End function dynload_actions */
      }

      protected void GXDLATOTRUB7565( string A114TotTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATOTRUB_data7565( A114TotTipo) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXATOTRUB_html7565( string A114TotTipo )
      {
         int gxdynajaxvalue;
         GXDLATOTRUB_data7565( A114TotTipo) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTotRub.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTotRub.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATOTRUB_data7565( string A114TotTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor T007516 */
         pr_default.execute(14, new Object[] {A114TotTipo});
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T007516_A115TotRub[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T007516_A1928TotDsc[0]));
            pr_default.readNext(14);
         }
         pr_default.close(14);
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
         dynTotRub.Name = "TOTRUB";
         dynTotRub.WebTags = "";
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

      public void Valid_Tottipo( )
      {
         A114TotTipo = cmbTotTipo.CurrentValue;
         A115TotRub = (int)(NumberUtil.Val( dynTotRub.CurrentValue, "."));
         GXATOTRUB_html7565( A114TotTipo) ;
         dynload_actions( ) ;
         if ( cmbTotTipo.ItemCount > 0 )
         {
            A114TotTipo = cmbTotTipo.getValidValue(A114TotTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTotTipo.CurrentValue = StringUtil.RTrim( A114TotTipo);
         }
         if ( dynTotRub.ItemCount > 0 )
         {
            A115TotRub = (int)(NumberUtil.Val( dynTotRub.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTotRub.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")));
         dynTotRub.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0));
         AssignProp("", false, dynTotRub_Internalname, "Values", dynTotRub.ToJavascriptSource(), true);
      }

      public void Valid_Totrub( )
      {
         A114TotTipo = cmbTotTipo.CurrentValue;
         A115TotRub = (int)(NumberUtil.Val( dynTotRub.CurrentValue, "."));
         /* Using cursor T007517 */
         pr_default.execute(15, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = cmbTotTipo_Internalname;
         }
         A1928TotDsc = T007517_A1928TotDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         if ( cmbTotTipo.ItemCount > 0 )
         {
            A114TotTipo = cmbTotTipo.getValidValue(A114TotTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTotTipo.CurrentValue = StringUtil.RTrim( A114TotTipo);
         }
         if ( dynTotRub.ItemCount > 0 )
         {
            A115TotRub = (int)(NumberUtil.Val( dynTotRub.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTotRub.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A115TotRub), 6, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1928TotDsc", StringUtil.RTrim( A1928TotDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TotTipo',fld:'vTOTTIPO',pic:'',hsh:true},{av:'AV10TotRub',fld:'vTOTRUB',pic:'ZZZZZ9',hsh:true},{av:'AV11RubCod',fld:'vRUBCOD',pic:'ZZZZZ9',hsh:true},{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV9TotTipo',fld:'vTOTTIPO',pic:'',hsh:true},{av:'AV10TotRub',fld:'vTOTRUB',pic:'ZZZZZ9',hsh:true},{av:'AV11RubCod',fld:'vRUBCOD',pic:'ZZZZZ9',hsh:true},{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12752',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_TOTTIPO","{handler:'Valid_Tottipo',iparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TOTTIPO",",oparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_TOTRUB","{handler:'Valid_Totrub',iparms:[{av:'A1928TotDsc',fld:'TOTDSC',pic:''},{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TOTRUB",",oparms:[{av:'A1928TotDsc',fld:'TOTDSC',pic:''},{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_RUBCOD","{handler:'Valid_Rubcod',iparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_RUBCOD",",oparms:[{av:'cmbTotTipo'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'dynTotRub'},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]}");
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
         pr_default.close(15);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV9TotTipo = "";
         Z114TotTipo = "";
         Z1822RubDsc = "";
         Z1823RubDscTot = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A114TotTipo = "";
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
         A1928TotDsc = "";
         A1822RubDsc = "";
         A1823RubDscTot = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode65 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         Z1928TotDsc = "";
         T00754_A1928TotDsc = new string[] {""} ;
         T00755_A116RubCod = new int[1] ;
         T00755_A1928TotDsc = new string[] {""} ;
         T00755_A1822RubDsc = new string[] {""} ;
         T00755_A1823RubDscTot = new string[] {""} ;
         T00755_A117RubOrd = new short[1] ;
         T00755_A1829RubSts = new short[1] ;
         T00755_A114TotTipo = new string[] {""} ;
         T00755_A115TotRub = new int[1] ;
         T00756_A1928TotDsc = new string[] {""} ;
         T00757_A114TotTipo = new string[] {""} ;
         T00757_A115TotRub = new int[1] ;
         T00757_A116RubCod = new int[1] ;
         T00753_A116RubCod = new int[1] ;
         T00753_A1822RubDsc = new string[] {""} ;
         T00753_A1823RubDscTot = new string[] {""} ;
         T00753_A117RubOrd = new short[1] ;
         T00753_A1829RubSts = new short[1] ;
         T00753_A114TotTipo = new string[] {""} ;
         T00753_A115TotRub = new int[1] ;
         T00758_A114TotTipo = new string[] {""} ;
         T00758_A115TotRub = new int[1] ;
         T00758_A116RubCod = new int[1] ;
         T00759_A114TotTipo = new string[] {""} ;
         T00759_A115TotRub = new int[1] ;
         T00759_A116RubCod = new int[1] ;
         T00752_A116RubCod = new int[1] ;
         T00752_A1822RubDsc = new string[] {""} ;
         T00752_A1823RubDscTot = new string[] {""} ;
         T00752_A117RubOrd = new short[1] ;
         T00752_A1829RubSts = new short[1] ;
         T00752_A114TotTipo = new string[] {""} ;
         T00752_A115TotRub = new int[1] ;
         T007513_A1928TotDsc = new string[] {""} ;
         T007514_A114TotTipo = new string[] {""} ;
         T007514_A115TotRub = new int[1] ;
         T007514_A116RubCod = new int[1] ;
         T007514_A118RubLinCod = new int[1] ;
         T007515_A114TotTipo = new string[] {""} ;
         T007515_A115TotRub = new int[1] ;
         T007515_A116RubCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T007516_A114TotTipo = new string[] {""} ;
         T007516_A115TotRub = new int[1] ;
         T007516_A1928TotDsc = new string[] {""} ;
         T007517_A1928TotDsc = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubros__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubros__default(),
            new Object[][] {
                new Object[] {
               T00752_A116RubCod, T00752_A1822RubDsc, T00752_A1823RubDscTot, T00752_A117RubOrd, T00752_A1829RubSts, T00752_A114TotTipo, T00752_A115TotRub
               }
               , new Object[] {
               T00753_A116RubCod, T00753_A1822RubDsc, T00753_A1823RubDscTot, T00753_A117RubOrd, T00753_A1829RubSts, T00753_A114TotTipo, T00753_A115TotRub
               }
               , new Object[] {
               T00754_A1928TotDsc
               }
               , new Object[] {
               T00755_A116RubCod, T00755_A1928TotDsc, T00755_A1822RubDsc, T00755_A1823RubDscTot, T00755_A117RubOrd, T00755_A1829RubSts, T00755_A114TotTipo, T00755_A115TotRub
               }
               , new Object[] {
               T00756_A1928TotDsc
               }
               , new Object[] {
               T00757_A114TotTipo, T00757_A115TotRub, T00757_A116RubCod
               }
               , new Object[] {
               T00758_A114TotTipo, T00758_A115TotRub, T00758_A116RubCod
               }
               , new Object[] {
               T00759_A114TotTipo, T00759_A115TotRub, T00759_A116RubCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007513_A1928TotDsc
               }
               , new Object[] {
               T007514_A114TotTipo, T007514_A115TotRub, T007514_A116RubCod, T007514_A118RubLinCod
               }
               , new Object[] {
               T007515_A114TotTipo, T007515_A115TotRub, T007515_A116RubCod
               }
               , new Object[] {
               T007516_A114TotTipo, T007516_A115TotRub, T007516_A1928TotDsc
               }
               , new Object[] {
               T007517_A1928TotDsc
               }
            }
         );
         Z1829RubSts = 1;
         A1829RubSts = 1;
         i1829RubSts = 1;
      }

      private short Z117RubOrd ;
      private short Z1829RubSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A117RubOrd ;
      private short A1829RubSts ;
      private short Gx_BScreen ;
      private short RcdFound65 ;
      private short GX_JID ;
      private short nIsDirty_65 ;
      private short gxajaxcallmode ;
      private short i1829RubSts ;
      private int wcpOAV10TotRub ;
      private int wcpOAV11RubCod ;
      private int Z115TotRub ;
      private int Z116RubCod ;
      private int A115TotRub ;
      private int AV10TotRub ;
      private int AV11RubCod ;
      private int trnEnded ;
      private int edtTotDsc_Enabled ;
      private int A116RubCod ;
      private int edtRubCod_Enabled ;
      private int edtRubDsc_Enabled ;
      private int edtRubDscTot_Enabled ;
      private int edtRubOrd_Enabled ;
      private int edtRubSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV9TotTipo ;
      private string Z114TotTipo ;
      private string Z1822RubDsc ;
      private string Z1823RubDscTot ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A114TotTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV9TotTipo ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbTotTipo_Internalname ;
      private string dynTotRub_Internalname ;
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
      private string dynTotRub_Jsonclick ;
      private string edtTotDsc_Internalname ;
      private string A1928TotDsc ;
      private string edtTotDsc_Jsonclick ;
      private string edtRubCod_Internalname ;
      private string edtRubCod_Jsonclick ;
      private string edtRubDsc_Internalname ;
      private string A1822RubDsc ;
      private string edtRubDsc_Jsonclick ;
      private string edtRubDscTot_Internalname ;
      private string A1823RubDscTot ;
      private string edtRubDscTot_Jsonclick ;
      private string edtRubOrd_Internalname ;
      private string edtRubOrd_Jsonclick ;
      private string edtRubSts_Internalname ;
      private string edtRubSts_Jsonclick ;
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
      private string sMode65 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1928TotDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string gxwrpcisep ;
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
      private bool gxdyncontrolsrefreshing ;
      private IGxSession AV14WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTotTipo ;
      private GXCombobox dynTotRub ;
      private IDataStoreProvider pr_default ;
      private string[] T00754_A1928TotDsc ;
      private int[] T00755_A116RubCod ;
      private string[] T00755_A1928TotDsc ;
      private string[] T00755_A1822RubDsc ;
      private string[] T00755_A1823RubDscTot ;
      private short[] T00755_A117RubOrd ;
      private short[] T00755_A1829RubSts ;
      private string[] T00755_A114TotTipo ;
      private int[] T00755_A115TotRub ;
      private string[] T00756_A1928TotDsc ;
      private string[] T00757_A114TotTipo ;
      private int[] T00757_A115TotRub ;
      private int[] T00757_A116RubCod ;
      private int[] T00753_A116RubCod ;
      private string[] T00753_A1822RubDsc ;
      private string[] T00753_A1823RubDscTot ;
      private short[] T00753_A117RubOrd ;
      private short[] T00753_A1829RubSts ;
      private string[] T00753_A114TotTipo ;
      private int[] T00753_A115TotRub ;
      private string[] T00758_A114TotTipo ;
      private int[] T00758_A115TotRub ;
      private int[] T00758_A116RubCod ;
      private string[] T00759_A114TotTipo ;
      private int[] T00759_A115TotRub ;
      private int[] T00759_A116RubCod ;
      private int[] T00752_A116RubCod ;
      private string[] T00752_A1822RubDsc ;
      private string[] T00752_A1823RubDscTot ;
      private short[] T00752_A117RubOrd ;
      private short[] T00752_A1829RubSts ;
      private string[] T00752_A114TotTipo ;
      private int[] T00752_A115TotRub ;
      private string[] T007513_A1928TotDsc ;
      private string[] T007514_A114TotTipo ;
      private int[] T007514_A115TotRub ;
      private int[] T007514_A116RubCod ;
      private int[] T007514_A118RubLinCod ;
      private string[] T007515_A114TotTipo ;
      private int[] T007515_A115TotRub ;
      private int[] T007515_A116RubCod ;
      private string[] T007516_A114TotTipo ;
      private int[] T007516_A115TotRub ;
      private string[] T007516_A1928TotDsc ;
      private string[] T007517_A1928TotDsc ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
   }

   public class rubros__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class rubros__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00755;
        prmT00755 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT00754;
        prmT00754 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00756;
        prmT00756 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT00757;
        prmT00757 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT00753;
        prmT00753 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT00758;
        prmT00758 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT00759;
        prmT00759 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT00752;
        prmT00752 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007510;
        prmT007510 = new Object[] {
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubDsc",GXType.NChar,100,0) ,
        new ParDef("@RubDscTot",GXType.NChar,100,0) ,
        new ParDef("@RubOrd",GXType.Int16,2,0) ,
        new ParDef("@RubSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT007511;
        prmT007511 = new Object[] {
        new ParDef("@RubDsc",GXType.NChar,100,0) ,
        new ParDef("@RubDscTot",GXType.NChar,100,0) ,
        new ParDef("@RubOrd",GXType.Int16,2,0) ,
        new ParDef("@RubSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007512;
        prmT007512 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007513;
        prmT007513 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT007514;
        prmT007514 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007515;
        prmT007515 = new Object[] {
        };
        Object[] prmT007516;
        prmT007516 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0)
        };
        Object[] prmT007517;
        prmT007517 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00752", "SELECT [RubCod], [RubDsc], [RubDscTot], [RubOrd], [RubSts], [TotTipo], [TotRub] FROM [CBRUBROS] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00752,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00753", "SELECT [RubCod], [RubDsc], [RubDscTot], [RubOrd], [RubSts], [TotTipo], [TotRub] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00753,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00754", "SELECT [TotDsc] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT00754,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00755", "SELECT TM1.[RubCod], T2.[TotDsc], TM1.[RubDsc], TM1.[RubDscTot], TM1.[RubOrd], TM1.[RubSts], TM1.[TotTipo], TM1.[TotRub] FROM ([CBRUBROS] TM1 INNER JOIN [CBRUBROST] T2 ON T2.[TotTipo] = TM1.[TotTipo] AND T2.[TotRub] = TM1.[TotRub]) WHERE TM1.[TotTipo] = @TotTipo and TM1.[TotRub] = @TotRub and TM1.[RubCod] = @RubCod ORDER BY TM1.[TotTipo], TM1.[TotRub], TM1.[RubCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00755,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00756", "SELECT [TotDsc] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT00756,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00757", "SELECT [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00757,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00758", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE ( [TotTipo] > @TotTipo or [TotTipo] = @TotTipo and [TotRub] > @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] > @RubCod) ORDER BY [TotTipo], [TotRub], [RubCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00758,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00759", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE ( [TotTipo] < @TotTipo or [TotTipo] = @TotTipo and [TotRub] < @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] < @RubCod) ORDER BY [TotTipo] DESC, [TotRub] DESC, [RubCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00759,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007510", "INSERT INTO [CBRUBROS]([RubCod], [RubDsc], [RubDscTot], [RubOrd], [RubSts], [TotTipo], [TotRub]) VALUES(@RubCod, @RubDsc, @RubDscTot, @RubOrd, @RubSts, @TotTipo, @TotRub)", GxErrorMask.GX_NOMASK,prmT007510)
           ,new CursorDef("T007511", "UPDATE [CBRUBROS] SET [RubDsc]=@RubDsc, [RubDscTot]=@RubDscTot, [RubOrd]=@RubOrd, [RubSts]=@RubSts  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod", GxErrorMask.GX_NOMASK,prmT007511)
           ,new CursorDef("T007512", "DELETE FROM [CBRUBROS]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod", GxErrorMask.GX_NOMASK,prmT007512)
           ,new CursorDef("T007513", "SELECT [TotDsc] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT007513,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007514", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007514,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007515", "SELECT [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] ORDER BY [TotTipo], [TotRub], [RubCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007515,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007516", "SELECT [TotTipo], [TotRub], [TotDsc] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo ORDER BY [TotDsc] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007516,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007517", "SELECT [TotDsc] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT007517,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
     }
  }

}

}
