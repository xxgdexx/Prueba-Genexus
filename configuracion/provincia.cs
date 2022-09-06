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
   public class provincia : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A139PaiCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A139PaiCod, A140EstCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.provincia.aspx")), "configuracion.provincia.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.provincia.aspx")))) ;
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
                  AV10PaiCod = GetPar( "PaiCod");
                  AssignAttri("", false, "AV10PaiCod", AV10PaiCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPAICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PaiCod, "")), context));
                  AV11EstCod = GetPar( "EstCod");
                  AssignAttri("", false, "AV11EstCod", AV11EstCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vESTCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11EstCod, "")), context));
                  AV7ProvCod = GetPar( "ProvCod");
                  AssignAttri("", false, "AV7ProvCod", AV7ProvCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROVCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProvCod, "")), context));
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
            Form.Meta.addItem("description", "Provincia", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public provincia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public provincia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_PaiCod ,
                           string aP2_EstCod ,
                           string aP3_ProvCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10PaiCod = aP1_PaiCod;
         this.AV11EstCod = aP2_EstCod;
         this.AV7ProvCod = aP3_ProvCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProvSts = new GXCombobox();
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
         if ( cmbProvSts.ItemCount > 0 )
         {
            A1742ProvSts = (short)(NumberUtil.Val( cmbProvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0))), "."));
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
            AssignProp("", false, cmbProvSts_Internalname, "Values", cmbProvSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpaicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpaicod_Internalname, "Pais", "", "", lblTextblockpaicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paicod.SetProperty("Caption", Combo_paicod_Caption);
         ucCombo_paicod.SetProperty("Cls", Combo_paicod_Cls);
         ucCombo_paicod.SetProperty("DataListProc", Combo_paicod_Datalistproc);
         ucCombo_paicod.SetProperty("DataListProcParametersPrefix", Combo_paicod_Datalistprocparametersprefix);
         ucCombo_paicod.SetProperty("EmptyItem", Combo_paicod_Emptyitem);
         ucCombo_paicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_paicod.SetProperty("DropDownOptionsData", AV15PaiCod_Data);
         ucCombo_paicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paicod_Internalname, "COMBO_PAICODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaiCod_Internalname, "Pais", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPaiCod_Visible, edtPaiCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedestcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockestcod_Internalname, "Departamento", "", "", lblTextblockestcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_estcod.SetProperty("Caption", Combo_estcod_Caption);
         ucCombo_estcod.SetProperty("Cls", Combo_estcod_Cls);
         ucCombo_estcod.SetProperty("DataListProc", Combo_estcod_Datalistproc);
         ucCombo_estcod.SetProperty("EmptyItem", Combo_estcod_Emptyitem);
         ucCombo_estcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_estcod.SetProperty("DropDownOptionsData", AV21EstCod_Data);
         ucCombo_estcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_estcod_Internalname, "COMBO_ESTCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstCod_Internalname, "Estado", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", edtEstCod_Visible, edtEstCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Provincia.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvDsc_Internalname, "Provincia", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvDsc_Internalname, StringUtil.RTrim( A603ProvDsc), StringUtil.RTrim( context.localUtil.Format( A603ProvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtProvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbProvSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProvSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProvSts, cmbProvSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0)), 1, cmbProvSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbProvSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 1, "HLP_Configuracion\\Provincia.htm");
         cmbProvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         AssignProp("", false, cmbProvSts_Internalname, "Values", (string)(cmbProvSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Provincia.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_paicod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombopaicod_Internalname, StringUtil.RTrim( AV20ComboPaiCod), StringUtil.RTrim( context.localUtil.Format( AV20ComboPaiCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaicod_Visible, edtavCombopaicod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Provincia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_estcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboestcod_Internalname, StringUtil.RTrim( AV22ComboEstCod), StringUtil.RTrim( context.localUtil.Format( AV22ComboEstCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboestcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboestcod_Visible, edtavComboestcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Provincia.htm");
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
         E115V2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPAICOD_DATA"), AV15PaiCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vESTCOD_DATA"), AV21EstCod_Data);
               /* Read saved values. */
               Z139PaiCod = cgiGet( "Z139PaiCod");
               Z140EstCod = cgiGet( "Z140EstCod");
               Z141ProvCod = cgiGet( "Z141ProvCod");
               Z603ProvDsc = cgiGet( "Z603ProvDsc");
               Z1741ProvAbr = cgiGet( "Z1741ProvAbr");
               Z1742ProvSts = (short)(context.localUtil.CToN( cgiGet( "Z1742ProvSts"), ".", ","));
               A1741ProvAbr = cgiGet( "Z1741ProvAbr");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV23Cond_PaiCod = cgiGet( "vCOND_PAICOD");
               AV10PaiCod = cgiGet( "vPAICOD");
               AV11EstCod = cgiGet( "vESTCOD");
               AV7ProvCod = cgiGet( "vPROVCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A1741ProvAbr = cgiGet( "PROVABR");
               A1500PaiDsc = cgiGet( "PAIDSC");
               Combo_paicod_Objectcall = cgiGet( "COMBO_PAICOD_Objectcall");
               Combo_paicod_Class = cgiGet( "COMBO_PAICOD_Class");
               Combo_paicod_Icontype = cgiGet( "COMBO_PAICOD_Icontype");
               Combo_paicod_Icon = cgiGet( "COMBO_PAICOD_Icon");
               Combo_paicod_Caption = cgiGet( "COMBO_PAICOD_Caption");
               Combo_paicod_Tooltip = cgiGet( "COMBO_PAICOD_Tooltip");
               Combo_paicod_Cls = cgiGet( "COMBO_PAICOD_Cls");
               Combo_paicod_Selectedvalue_set = cgiGet( "COMBO_PAICOD_Selectedvalue_set");
               Combo_paicod_Selectedvalue_get = cgiGet( "COMBO_PAICOD_Selectedvalue_get");
               Combo_paicod_Selectedtext_set = cgiGet( "COMBO_PAICOD_Selectedtext_set");
               Combo_paicod_Selectedtext_get = cgiGet( "COMBO_PAICOD_Selectedtext_get");
               Combo_paicod_Gamoauthtoken = cgiGet( "COMBO_PAICOD_Gamoauthtoken");
               Combo_paicod_Ddointernalname = cgiGet( "COMBO_PAICOD_Ddointernalname");
               Combo_paicod_Titlecontrolalign = cgiGet( "COMBO_PAICOD_Titlecontrolalign");
               Combo_paicod_Dropdownoptionstype = cgiGet( "COMBO_PAICOD_Dropdownoptionstype");
               Combo_paicod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Enabled"));
               Combo_paicod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Visible"));
               Combo_paicod_Titlecontrolidtoreplace = cgiGet( "COMBO_PAICOD_Titlecontrolidtoreplace");
               Combo_paicod_Datalisttype = cgiGet( "COMBO_PAICOD_Datalisttype");
               Combo_paicod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Allowmultipleselection"));
               Combo_paicod_Datalistfixedvalues = cgiGet( "COMBO_PAICOD_Datalistfixedvalues");
               Combo_paicod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Isgriditem"));
               Combo_paicod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Hasdescription"));
               Combo_paicod_Datalistproc = cgiGet( "COMBO_PAICOD_Datalistproc");
               Combo_paicod_Datalistprocparametersprefix = cgiGet( "COMBO_PAICOD_Datalistprocparametersprefix");
               Combo_paicod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAICOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_paicod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeonlyselectedoption"));
               Combo_paicod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeselectalloption"));
               Combo_paicod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Emptyitem"));
               Combo_paicod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeaddnewoption"));
               Combo_paicod_Htmltemplate = cgiGet( "COMBO_PAICOD_Htmltemplate");
               Combo_paicod_Multiplevaluestype = cgiGet( "COMBO_PAICOD_Multiplevaluestype");
               Combo_paicod_Loadingdata = cgiGet( "COMBO_PAICOD_Loadingdata");
               Combo_paicod_Noresultsfound = cgiGet( "COMBO_PAICOD_Noresultsfound");
               Combo_paicod_Emptyitemtext = cgiGet( "COMBO_PAICOD_Emptyitemtext");
               Combo_paicod_Onlyselectedvalues = cgiGet( "COMBO_PAICOD_Onlyselectedvalues");
               Combo_paicod_Selectalltext = cgiGet( "COMBO_PAICOD_Selectalltext");
               Combo_paicod_Multiplevaluesseparator = cgiGet( "COMBO_PAICOD_Multiplevaluesseparator");
               Combo_paicod_Addnewoptiontext = cgiGet( "COMBO_PAICOD_Addnewoptiontext");
               Combo_paicod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAICOD_Gxcontroltype"), ".", ","));
               Combo_estcod_Objectcall = cgiGet( "COMBO_ESTCOD_Objectcall");
               Combo_estcod_Class = cgiGet( "COMBO_ESTCOD_Class");
               Combo_estcod_Icontype = cgiGet( "COMBO_ESTCOD_Icontype");
               Combo_estcod_Icon = cgiGet( "COMBO_ESTCOD_Icon");
               Combo_estcod_Caption = cgiGet( "COMBO_ESTCOD_Caption");
               Combo_estcod_Tooltip = cgiGet( "COMBO_ESTCOD_Tooltip");
               Combo_estcod_Cls = cgiGet( "COMBO_ESTCOD_Cls");
               Combo_estcod_Selectedvalue_set = cgiGet( "COMBO_ESTCOD_Selectedvalue_set");
               Combo_estcod_Selectedvalue_get = cgiGet( "COMBO_ESTCOD_Selectedvalue_get");
               Combo_estcod_Selectedtext_set = cgiGet( "COMBO_ESTCOD_Selectedtext_set");
               Combo_estcod_Selectedtext_get = cgiGet( "COMBO_ESTCOD_Selectedtext_get");
               Combo_estcod_Gamoauthtoken = cgiGet( "COMBO_ESTCOD_Gamoauthtoken");
               Combo_estcod_Ddointernalname = cgiGet( "COMBO_ESTCOD_Ddointernalname");
               Combo_estcod_Titlecontrolalign = cgiGet( "COMBO_ESTCOD_Titlecontrolalign");
               Combo_estcod_Dropdownoptionstype = cgiGet( "COMBO_ESTCOD_Dropdownoptionstype");
               Combo_estcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Enabled"));
               Combo_estcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Visible"));
               Combo_estcod_Titlecontrolidtoreplace = cgiGet( "COMBO_ESTCOD_Titlecontrolidtoreplace");
               Combo_estcod_Datalisttype = cgiGet( "COMBO_ESTCOD_Datalisttype");
               Combo_estcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Allowmultipleselection"));
               Combo_estcod_Datalistfixedvalues = cgiGet( "COMBO_ESTCOD_Datalistfixedvalues");
               Combo_estcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Isgriditem"));
               Combo_estcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Hasdescription"));
               Combo_estcod_Datalistproc = cgiGet( "COMBO_ESTCOD_Datalistproc");
               Combo_estcod_Datalistprocparametersprefix = cgiGet( "COMBO_ESTCOD_Datalistprocparametersprefix");
               Combo_estcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_ESTCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_estcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Includeonlyselectedoption"));
               Combo_estcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Includeselectalloption"));
               Combo_estcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Emptyitem"));
               Combo_estcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Includeaddnewoption"));
               Combo_estcod_Htmltemplate = cgiGet( "COMBO_ESTCOD_Htmltemplate");
               Combo_estcod_Multiplevaluestype = cgiGet( "COMBO_ESTCOD_Multiplevaluestype");
               Combo_estcod_Loadingdata = cgiGet( "COMBO_ESTCOD_Loadingdata");
               Combo_estcod_Noresultsfound = cgiGet( "COMBO_ESTCOD_Noresultsfound");
               Combo_estcod_Emptyitemtext = cgiGet( "COMBO_ESTCOD_Emptyitemtext");
               Combo_estcod_Onlyselectedvalues = cgiGet( "COMBO_ESTCOD_Onlyselectedvalues");
               Combo_estcod_Selectalltext = cgiGet( "COMBO_ESTCOD_Selectalltext");
               Combo_estcod_Multiplevaluesseparator = cgiGet( "COMBO_ESTCOD_Multiplevaluesseparator");
               Combo_estcod_Addnewoptiontext = cgiGet( "COMBO_ESTCOD_Addnewoptiontext");
               Combo_estcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_ESTCOD_Gxcontroltype"), ".", ","));
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
               A139PaiCod = cgiGet( edtPaiCod_Internalname);
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = cgiGet( edtEstCod_Internalname);
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = cgiGet( edtProvCod_Internalname);
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A603ProvDsc = cgiGet( edtProvDsc_Internalname);
               AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
               cmbProvSts.CurrentValue = cgiGet( cmbProvSts_Internalname);
               A1742ProvSts = (short)(NumberUtil.Val( cgiGet( cmbProvSts_Internalname), "."));
               AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
               AV20ComboPaiCod = cgiGet( edtavCombopaicod_Internalname);
               AssignAttri("", false, "AV20ComboPaiCod", AV20ComboPaiCod);
               AV22ComboEstCod = cgiGet( edtavComboestcod_Internalname);
               AssignAttri("", false, "AV22ComboEstCod", AV22ComboEstCod);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Provincia");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ProvAbr", StringUtil.RTrim( context.localUtil.Format( A1741ProvAbr, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\provincia:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A139PaiCod = GetPar( "PaiCod");
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = GetPar( "EstCod");
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  A141ProvCod = GetPar( "ProvCod");
                  AssignAttri("", false, "A141ProvCod", A141ProvCod);
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
                     sMode127 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode127;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound127 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5V0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAICOD");
                        AnyError = 1;
                        GX_FocusControl = edtPaiCod_Internalname;
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
                           E115V2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125V2 ();
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
            E125V2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5V127( ) ;
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
            DisableAttributes5V127( ) ;
         }
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
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

      protected void CONFIRM_5V0( )
      {
         BeforeValidate5V127( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5V127( ) ;
            }
            else
            {
               CheckExtendedTable5V127( ) ;
               CloseExtendedTableCursors5V127( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5V0( )
      {
      }

      protected void E115V2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtEstCod_Visible = 0;
         AssignProp("", false, edtEstCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstCod_Visible), 5, 0), true);
         AV22ComboEstCod = "";
         AssignAttri("", false, "AV22ComboEstCod", AV22ComboEstCod);
         edtavComboestcod_Visible = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Visible), 5, 0), true);
         edtPaiCod_Visible = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaiCod_Visible), 5, 0), true);
         AV20ComboPaiCod = "";
         AssignAttri("", false, "AV20ComboPaiCod", AV20ComboPaiCod);
         edtavCombopaicod_Visible = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPAICOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOESTCOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E125V2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV24SGAuDocGls = "Provincia N° " + StringUtil.Trim( A141ProvCod) + " " + StringUtil.Trim( A603ProvDsc);
            AV25Codigo = A141ProvCod;
            GXt_char2 = "CNF";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV24SGAuDocGls, ref  AV25Codigo, ref  AV25Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV13TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.provinciaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOESTCOD' Routine */
         returnInSub = false;
         Combo_estcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"EstCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaiCod\": \"\", \"EstCod\": \"\", \"ProvCod\": \"\", \"Cond_PaiCod\": \"#%1#\"", edtPaiCod_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "DataListProcParametersPrefix", Combo_estcod_Datalistprocparametersprefix);
         GXt_char4 = AV19Combo_DataJson;
         new GeneXus.Programs.configuracion.provincialoaddvcombo(context ).execute(  "EstCod",  Gx_mode,  false,  AV10PaiCod,  AV11EstCod,  AV7ProvCod,  A139PaiCod,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char4) ;
         AV19Combo_DataJson = GXt_char4;
         Combo_estcod_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
         Combo_estcod_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedText_set", Combo_estcod_Selectedtext_set);
         AV22ComboEstCod = AV17ComboSelectedValue;
         AssignAttri("", false, "AV22ComboEstCod", AV22ComboEstCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EstCod)) )
         {
            Combo_estcod_Enabled = false;
            ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPAICOD' Routine */
         returnInSub = false;
         GXt_char4 = AV19Combo_DataJson;
         new GeneXus.Programs.configuracion.provincialoaddvcombo(context ).execute(  "PaiCod",  Gx_mode,  false,  AV10PaiCod,  AV11EstCod,  AV7ProvCod,  A139PaiCod,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char4) ;
         AV19Combo_DataJson = GXt_char4;
         Combo_paicod_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
         Combo_paicod_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
         AV20ComboPaiCod = AV17ComboSelectedValue;
         AssignAttri("", false, "AV20ComboPaiCod", AV20ComboPaiCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            Combo_paicod_Enabled = false;
            ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         }
      }

      protected void ZM5V127( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z603ProvDsc = T005V3_A603ProvDsc[0];
               Z1741ProvAbr = T005V3_A1741ProvAbr[0];
               Z1742ProvSts = T005V3_A1742ProvSts[0];
            }
            else
            {
               Z603ProvDsc = A603ProvDsc;
               Z1741ProvAbr = A1741ProvAbr;
               Z1742ProvSts = A1742ProvSts;
            }
         }
         if ( GX_JID == -15 )
         {
            Z141ProvCod = A141ProvCod;
            Z603ProvDsc = A603ProvDsc;
            Z1741ProvAbr = A1741ProvAbr;
            Z1742ProvSts = A1742ProvSts;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z1500PaiDsc = A1500PaiDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            edtPaiCod_Enabled = 0;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPaiCod_Enabled = 1;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            edtPaiCod_Enabled = 0;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EstCod)) )
         {
            edtEstCod_Enabled = 0;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         else
         {
            edtEstCod_Enabled = 1;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EstCod)) )
         {
            edtEstCod_Enabled = 0;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProvCod)) )
         {
            A141ProvCod = AV7ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProvCod)) )
         {
            edtProvCod_Enabled = 0;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         else
         {
            edtProvCod_Enabled = 1;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProvCod)) )
         {
            edtProvCod_Enabled = 0;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EstCod)) )
         {
            A140EstCod = AV11EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         else
         {
            A140EstCod = AV22ComboEstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            A139PaiCod = AV10PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         else
         {
            A139PaiCod = AV20ComboPaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
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
         if ( IsIns( )  && (0==A1742ProvSts) && ( Gx_BScreen == 0 ) )
         {
            A1742ProvSts = 1;
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T005V4 */
            pr_default.execute(2, new Object[] {A139PaiCod});
            A1500PaiDsc = T005V4_A1500PaiDsc[0];
            pr_default.close(2);
         }
      }

      protected void Load5V127( )
      {
         /* Using cursor T005V6 */
         pr_default.execute(4, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound127 = 1;
            A603ProvDsc = T005V6_A603ProvDsc[0];
            AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
            A1500PaiDsc = T005V6_A1500PaiDsc[0];
            A1741ProvAbr = T005V6_A1741ProvAbr[0];
            A1742ProvSts = T005V6_A1742ProvSts[0];
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
            ZM5V127( -15) ;
         }
         pr_default.close(4);
         OnLoadActions5V127( ) ;
      }

      protected void OnLoadActions5V127( )
      {
      }

      protected void CheckExtendedTable5V127( )
      {
         nIsDirty_127 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T005V4 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T005V4_A1500PaiDsc[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Pais", "", "", "", "", "", "", "", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005V5 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A140EstCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Estado", "", "", "", "", "", "", "", ""), 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtEstCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141ProvCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Provincia", "", "", "", "", "", "", "", ""), 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtProvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A603ProvDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Provincia", "", "", "", "", "", "", "", ""), 1, "PROVDSC");
            AnyError = 1;
            GX_FocusControl = edtProvDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5V127( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( string A139PaiCod )
      {
         /* Using cursor T005V7 */
         pr_default.execute(5, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T005V7_A1500PaiDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1500PaiDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_17( string A139PaiCod ,
                                string A140EstCod )
      {
         /* Using cursor T005V8 */
         pr_default.execute(6, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey5V127( )
      {
         /* Using cursor T005V9 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound127 = 1;
         }
         else
         {
            RcdFound127 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005V3 */
         pr_default.execute(1, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5V127( 15) ;
            RcdFound127 = 1;
            A141ProvCod = T005V3_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A603ProvDsc = T005V3_A603ProvDsc[0];
            AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
            A1741ProvAbr = T005V3_A1741ProvAbr[0];
            A1742ProvSts = T005V3_A1742ProvSts[0];
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
            A139PaiCod = T005V3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005V3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5V127( ) ;
            if ( AnyError == 1 )
            {
               RcdFound127 = 0;
               InitializeNonKey5V127( ) ;
            }
            Gx_mode = sMode127;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound127 = 0;
            InitializeNonKey5V127( ) ;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode127;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5V127( ) ;
         if ( RcdFound127 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound127 = 0;
         /* Using cursor T005V10 */
         pr_default.execute(8, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T005V10_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T005V10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V10_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T005V10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005V10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V10_A141ProvCod[0], A141ProvCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T005V10_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T005V10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V10_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T005V10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005V10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V10_A141ProvCod[0], A141ProvCod) > 0 ) ) )
            {
               A139PaiCod = T005V10_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T005V10_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T005V10_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               RcdFound127 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound127 = 0;
         /* Using cursor T005V11 */
         pr_default.execute(9, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T005V11_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T005V11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V11_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T005V11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005V11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V11_A141ProvCod[0], A141ProvCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T005V11_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T005V11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V11_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T005V11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005V11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005V11_A141ProvCod[0], A141ProvCod) < 0 ) ) )
            {
               A139PaiCod = T005V11_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T005V11_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T005V11_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               RcdFound127 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5V127( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5V127( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound127 == 1 )
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = Z140EstCod;
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  A141ProvCod = Z141ProvCod;
                  AssignAttri("", false, "A141ProvCod", A141ProvCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAICOD");
                  AnyError = 1;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5V127( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5V127( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAICOD");
                     AnyError = 1;
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5V127( ) ;
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
         if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = Z140EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = Z141ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5V127( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005V2 */
            pr_default.execute(0, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPROVINCIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z603ProvDsc, T005V2_A603ProvDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1741ProvAbr, T005V2_A1741ProvAbr[0]) != 0 ) || ( Z1742ProvSts != T005V2_A1742ProvSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z603ProvDsc, T005V2_A603ProvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.provincia:[seudo value changed for attri]"+"ProvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z603ProvDsc);
                  GXUtil.WriteLogRaw("Current: ",T005V2_A603ProvDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1741ProvAbr, T005V2_A1741ProvAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.provincia:[seudo value changed for attri]"+"ProvAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1741ProvAbr);
                  GXUtil.WriteLogRaw("Current: ",T005V2_A1741ProvAbr[0]);
               }
               if ( Z1742ProvSts != T005V2_A1742ProvSts[0] )
               {
                  GXUtil.WriteLog("configuracion.provincia:[seudo value changed for attri]"+"ProvSts");
                  GXUtil.WriteLogRaw("Old: ",Z1742ProvSts);
                  GXUtil.WriteLogRaw("Current: ",T005V2_A1742ProvSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPROVINCIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5V127( )
      {
         BeforeValidate5V127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5V127( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5V127( 0) ;
            CheckOptimisticConcurrency5V127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5V127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5V127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005V12 */
                     pr_default.execute(10, new Object[] {A141ProvCod, A603ProvDsc, A1741ProvAbr, A1742ProvSts, A139PaiCod, A140EstCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPROVINCIA");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption5V0( ) ;
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
               Load5V127( ) ;
            }
            EndLevel5V127( ) ;
         }
         CloseExtendedTableCursors5V127( ) ;
      }

      protected void Update5V127( )
      {
         BeforeValidate5V127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5V127( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5V127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5V127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5V127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005V13 */
                     pr_default.execute(11, new Object[] {A603ProvDsc, A1741ProvAbr, A1742ProvSts, A139PaiCod, A140EstCod, A141ProvCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPROVINCIA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPROVINCIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5V127( ) ;
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
            EndLevel5V127( ) ;
         }
         CloseExtendedTableCursors5V127( ) ;
      }

      protected void DeferredUpdate5V127( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5V127( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5V127( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5V127( ) ;
            AfterConfirm5V127( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5V127( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005V14 */
                  pr_default.execute(12, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPROVINCIA");
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
         sMode127 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5V127( ) ;
         Gx_mode = sMode127;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5V127( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005V15 */
            pr_default.execute(13, new Object[] {A139PaiCod});
            A1500PaiDsc = T005V15_A1500PaiDsc[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005V16 */
            pr_default.execute(14, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Distritos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel5V127( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5V127( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("configuracion.provincia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("configuracion.provincia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5V127( )
      {
         /* Scan By routine */
         /* Using cursor T005V17 */
         pr_default.execute(15);
         RcdFound127 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound127 = 1;
            A139PaiCod = T005V17_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005V17_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005V17_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5V127( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound127 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound127 = 1;
            A139PaiCod = T005V17_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005V17_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005V17_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
      }

      protected void ScanEnd5V127( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm5V127( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5V127( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5V127( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5V127( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5V127( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5V127( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5V127( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtProvDsc_Enabled = 0;
         AssignProp("", false, edtProvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvDsc_Enabled), 5, 0), true);
         cmbProvSts.Enabled = 0;
         AssignProp("", false, cmbProvSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProvSts.Enabled), 5, 0), true);
         edtavCombopaicod_Enabled = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         edtavComboestcod_Enabled = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5V127( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5V0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810261721", false, true);
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
         GXEncryptionTmp = "configuracion.provincia.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10PaiCod)) + "," + UrlEncode(StringUtil.RTrim(AV11EstCod)) + "," + UrlEncode(StringUtil.RTrim(AV7ProvCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.provincia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Provincia");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ProvAbr", StringUtil.RTrim( context.localUtil.Format( A1741ProvAbr, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\provincia:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z603ProvDsc", StringUtil.RTrim( Z603ProvDsc));
         GxWebStd.gx_hidden_field( context, "Z1741ProvAbr", StringUtil.RTrim( Z1741ProvAbr));
         GxWebStd.gx_hidden_field( context, "Z1742ProvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1742ProvSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAICOD_DATA", AV15PaiCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAICOD_DATA", AV15PaiCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTCOD_DATA", AV21EstCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTCOD_DATA", AV21EstCod_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vCOND_PAICOD", StringUtil.RTrim( AV23Cond_PaiCod));
         GxWebStd.gx_hidden_field( context, "vPAICOD", StringUtil.RTrim( AV10PaiCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PaiCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTCOD", StringUtil.RTrim( AV11EstCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11EstCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROVCOD", StringUtil.RTrim( AV7ProvCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProvCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVABR", StringUtil.RTrim( A1741ProvAbr));
         GxWebStd.gx_hidden_field( context, "PAIDSC", StringUtil.RTrim( A1500PaiDsc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Objectcall", StringUtil.RTrim( Combo_paicod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Cls", StringUtil.RTrim( Combo_paicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedvalue_set", StringUtil.RTrim( Combo_paicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedtext_set", StringUtil.RTrim( Combo_paicod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Datalistproc", StringUtil.RTrim( Combo_paicod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_paicod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Emptyitem", StringUtil.BoolToStr( Combo_paicod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Objectcall", StringUtil.RTrim( Combo_estcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Cls", StringUtil.RTrim( Combo_estcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_set", StringUtil.RTrim( Combo_estcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedtext_set", StringUtil.RTrim( Combo_estcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Datalistproc", StringUtil.RTrim( Combo_estcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_estcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Emptyitem", StringUtil.BoolToStr( Combo_estcod_Emptyitem));
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
         GXEncryptionTmp = "configuracion.provincia.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10PaiCod)) + "," + UrlEncode(StringUtil.RTrim(AV11EstCod)) + "," + UrlEncode(StringUtil.RTrim(AV7ProvCod));
         return formatLink("configuracion.provincia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Provincia" ;
      }

      public override string GetPgmdesc( )
      {
         return "Provincia" ;
      }

      protected void InitializeNonKey5V127( )
      {
         A603ProvDsc = "";
         AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
         A1500PaiDsc = "";
         AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
         A1741ProvAbr = "";
         AssignAttri("", false, "A1741ProvAbr", A1741ProvAbr);
         A1742ProvSts = 1;
         AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         Z603ProvDsc = "";
         Z1741ProvAbr = "";
         Z1742ProvSts = 0;
      }

      protected void InitAll5V127( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         InitializeNonKey5V127( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1742ProvSts = i1742ProvSts;
         AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261758", true, true);
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
         context.AddJavascriptSource("configuracion/provincia.js", "?202281810261759", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblockpaicod_Internalname = "TEXTBLOCKPAICOD";
         Combo_paicod_Internalname = "COMBO_PAICOD";
         edtPaiCod_Internalname = "PAICOD";
         divTablesplittedpaicod_Internalname = "TABLESPLITTEDPAICOD";
         lblTextblockestcod_Internalname = "TEXTBLOCKESTCOD";
         Combo_estcod_Internalname = "COMBO_ESTCOD";
         edtEstCod_Internalname = "ESTCOD";
         divTablesplittedestcod_Internalname = "TABLESPLITTEDESTCOD";
         edtProvCod_Internalname = "PROVCOD";
         edtProvDsc_Internalname = "PROVDSC";
         cmbProvSts_Internalname = "PROVSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopaicod_Internalname = "vCOMBOPAICOD";
         divSectionattribute_paicod_Internalname = "SECTIONATTRIBUTE_PAICOD";
         edtavComboestcod_Internalname = "vCOMBOESTCOD";
         divSectionattribute_estcod_Internalname = "SECTIONATTRIBUTE_ESTCOD";
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
         Form.Caption = "Provincia";
         Combo_estcod_Datalistprocparametersprefix = "";
         edtavComboestcod_Jsonclick = "";
         edtavComboestcod_Enabled = 0;
         edtavComboestcod_Visible = 1;
         edtavCombopaicod_Jsonclick = "";
         edtavCombopaicod_Enabled = 0;
         edtavCombopaicod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbProvSts_Jsonclick = "";
         cmbProvSts.Enabled = 1;
         edtProvDsc_Jsonclick = "";
         edtProvDsc_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtEstCod_Visible = 1;
         Combo_estcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_estcod_Datalistproc = "Configuracion.ProvinciaLoadDVCombo";
         Combo_estcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_estcod_Caption = "";
         Combo_estcod_Enabled = Convert.ToBoolean( -1);
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
         edtPaiCod_Visible = 1;
         Combo_paicod_Emptyitem = Convert.ToBoolean( 0);
         Combo_paicod_Datalistprocparametersprefix = " \"ComboName\": \"PaiCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaiCod\": \"\", \"EstCod\": \"\", \"ProvCod\": \"\"";
         Combo_paicod_Datalistproc = "Configuracion.ProvinciaLoadDVCombo";
         Combo_paicod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_paicod_Caption = "";
         Combo_paicod_Enabled = Convert.ToBoolean( -1);
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
         cmbProvSts.Name = "PROVSTS";
         cmbProvSts.WebTags = "";
         cmbProvSts.addItem("1", "ACTIVO", 0);
         cmbProvSts.addItem("0", "INACTIVO", 0);
         if ( cmbProvSts.ItemCount > 0 )
         {
            if ( (0==A1742ProvSts) )
            {
               A1742ProvSts = 1;
               AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
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

      public void Valid_Paicod( )
      {
         /* Using cursor T005V15 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A1500PaiDsc = T005V15_A1500PaiDsc[0];
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Pais", "", "", "", "", "", "", "", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
      }

      public void Valid_Estcod( )
      {
         /* Using cursor T005V18 */
         pr_default.execute(16, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(16);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A140EstCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Estado", "", "", "", "", "", "", "", ""), 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtEstCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10PaiCod',fld:'vPAICOD',pic:'',hsh:true},{av:'AV11EstCod',fld:'vESTCOD',pic:'',hsh:true},{av:'AV7ProvCod',fld:'vPROVCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV10PaiCod',fld:'vPAICOD',pic:'',hsh:true},{av:'AV11EstCod',fld:'vESTCOD',pic:'',hsh:true},{av:'AV7ProvCod',fld:'vPROVCOD',pic:'',hsh:true},{av:'A1741ProvAbr',fld:'PROVABR',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125V2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'A603ProvDsc',fld:'PROVDSC',pic:''},{av:'AV13TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''}]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[]");
         setEventMetadata("VALID_PROVCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVDSC","{handler:'Valid_Provdsc',iparms:[]");
         setEventMetadata("VALID_PROVDSC",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPAICOD","{handler:'Validv_Combopaicod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPAICOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOESTCOD","{handler:'Validv_Comboestcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOESTCOD",",oparms:[]}");
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
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV10PaiCod = "";
         wcpOAV11EstCod = "";
         wcpOAV7ProvCod = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z603ProvDsc = "";
         Z1741ProvAbr = "";
         Combo_estcod_Selectedvalue_get = "";
         Combo_paicod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockpaicod_Jsonclick = "";
         ucCombo_paicod = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15PaiCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockestcod_Jsonclick = "";
         ucCombo_estcod = new GXUserControl();
         AV21EstCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A141ProvCod = "";
         A603ProvDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboPaiCod = "";
         AV22ComboEstCod = "";
         A1741ProvAbr = "";
         AV23Cond_PaiCod = "";
         A1500PaiDsc = "";
         Combo_paicod_Objectcall = "";
         Combo_paicod_Class = "";
         Combo_paicod_Icontype = "";
         Combo_paicod_Icon = "";
         Combo_paicod_Tooltip = "";
         Combo_paicod_Selectedvalue_set = "";
         Combo_paicod_Selectedtext_set = "";
         Combo_paicod_Selectedtext_get = "";
         Combo_paicod_Gamoauthtoken = "";
         Combo_paicod_Ddointernalname = "";
         Combo_paicod_Titlecontrolalign = "";
         Combo_paicod_Dropdownoptionstype = "";
         Combo_paicod_Titlecontrolidtoreplace = "";
         Combo_paicod_Datalisttype = "";
         Combo_paicod_Datalistfixedvalues = "";
         Combo_paicod_Htmltemplate = "";
         Combo_paicod_Multiplevaluestype = "";
         Combo_paicod_Loadingdata = "";
         Combo_paicod_Noresultsfound = "";
         Combo_paicod_Emptyitemtext = "";
         Combo_paicod_Onlyselectedvalues = "";
         Combo_paicod_Selectalltext = "";
         Combo_paicod_Multiplevaluesseparator = "";
         Combo_paicod_Addnewoptiontext = "";
         Combo_estcod_Objectcall = "";
         Combo_estcod_Class = "";
         Combo_estcod_Icontype = "";
         Combo_estcod_Icon = "";
         Combo_estcod_Tooltip = "";
         Combo_estcod_Selectedvalue_set = "";
         Combo_estcod_Selectedtext_set = "";
         Combo_estcod_Selectedtext_get = "";
         Combo_estcod_Gamoauthtoken = "";
         Combo_estcod_Ddointernalname = "";
         Combo_estcod_Titlecontrolalign = "";
         Combo_estcod_Dropdownoptionstype = "";
         Combo_estcod_Titlecontrolidtoreplace = "";
         Combo_estcod_Datalisttype = "";
         Combo_estcod_Datalistfixedvalues = "";
         Combo_estcod_Htmltemplate = "";
         Combo_estcod_Multiplevaluestype = "";
         Combo_estcod_Loadingdata = "";
         Combo_estcod_Noresultsfound = "";
         Combo_estcod_Emptyitemtext = "";
         Combo_estcod_Onlyselectedvalues = "";
         Combo_estcod_Selectalltext = "";
         Combo_estcod_Multiplevaluesseparator = "";
         Combo_estcod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode127 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV24SGAuDocGls = "";
         AV25Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char4 = "";
         Z1500PaiDsc = "";
         T005V4_A1500PaiDsc = new string[] {""} ;
         T005V6_A141ProvCod = new string[] {""} ;
         T005V6_A603ProvDsc = new string[] {""} ;
         T005V6_A1500PaiDsc = new string[] {""} ;
         T005V6_A1741ProvAbr = new string[] {""} ;
         T005V6_A1742ProvSts = new short[1] ;
         T005V6_A139PaiCod = new string[] {""} ;
         T005V6_A140EstCod = new string[] {""} ;
         T005V5_A139PaiCod = new string[] {""} ;
         T005V7_A1500PaiDsc = new string[] {""} ;
         T005V8_A139PaiCod = new string[] {""} ;
         T005V9_A139PaiCod = new string[] {""} ;
         T005V9_A140EstCod = new string[] {""} ;
         T005V9_A141ProvCod = new string[] {""} ;
         T005V3_A141ProvCod = new string[] {""} ;
         T005V3_A603ProvDsc = new string[] {""} ;
         T005V3_A1741ProvAbr = new string[] {""} ;
         T005V3_A1742ProvSts = new short[1] ;
         T005V3_A139PaiCod = new string[] {""} ;
         T005V3_A140EstCod = new string[] {""} ;
         T005V10_A139PaiCod = new string[] {""} ;
         T005V10_A140EstCod = new string[] {""} ;
         T005V10_A141ProvCod = new string[] {""} ;
         T005V11_A139PaiCod = new string[] {""} ;
         T005V11_A140EstCod = new string[] {""} ;
         T005V11_A141ProvCod = new string[] {""} ;
         T005V2_A141ProvCod = new string[] {""} ;
         T005V2_A603ProvDsc = new string[] {""} ;
         T005V2_A1741ProvAbr = new string[] {""} ;
         T005V2_A1742ProvSts = new short[1] ;
         T005V2_A139PaiCod = new string[] {""} ;
         T005V2_A140EstCod = new string[] {""} ;
         T005V15_A1500PaiDsc = new string[] {""} ;
         T005V16_A139PaiCod = new string[] {""} ;
         T005V16_A140EstCod = new string[] {""} ;
         T005V16_A141ProvCod = new string[] {""} ;
         T005V16_A142DisCod = new string[] {""} ;
         T005V17_A139PaiCod = new string[] {""} ;
         T005V17_A140EstCod = new string[] {""} ;
         T005V17_A141ProvCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T005V18_A139PaiCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.provincia__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.provincia__default(),
            new Object[][] {
                new Object[] {
               T005V2_A141ProvCod, T005V2_A603ProvDsc, T005V2_A1741ProvAbr, T005V2_A1742ProvSts, T005V2_A139PaiCod, T005V2_A140EstCod
               }
               , new Object[] {
               T005V3_A141ProvCod, T005V3_A603ProvDsc, T005V3_A1741ProvAbr, T005V3_A1742ProvSts, T005V3_A139PaiCod, T005V3_A140EstCod
               }
               , new Object[] {
               T005V4_A1500PaiDsc
               }
               , new Object[] {
               T005V5_A139PaiCod
               }
               , new Object[] {
               T005V6_A141ProvCod, T005V6_A603ProvDsc, T005V6_A1500PaiDsc, T005V6_A1741ProvAbr, T005V6_A1742ProvSts, T005V6_A139PaiCod, T005V6_A140EstCod
               }
               , new Object[] {
               T005V7_A1500PaiDsc
               }
               , new Object[] {
               T005V8_A139PaiCod
               }
               , new Object[] {
               T005V9_A139PaiCod, T005V9_A140EstCod, T005V9_A141ProvCod
               }
               , new Object[] {
               T005V10_A139PaiCod, T005V10_A140EstCod, T005V10_A141ProvCod
               }
               , new Object[] {
               T005V11_A139PaiCod, T005V11_A140EstCod, T005V11_A141ProvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005V15_A1500PaiDsc
               }
               , new Object[] {
               T005V16_A139PaiCod, T005V16_A140EstCod, T005V16_A141ProvCod, T005V16_A142DisCod
               }
               , new Object[] {
               T005V17_A139PaiCod, T005V17_A140EstCod, T005V17_A141ProvCod
               }
               , new Object[] {
               T005V18_A139PaiCod
               }
            }
         );
         Z1742ProvSts = 1;
         A1742ProvSts = 1;
         i1742ProvSts = 1;
      }

      private short Z1742ProvSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1742ProvSts ;
      private short Gx_BScreen ;
      private short RcdFound127 ;
      private short GX_JID ;
      private short nIsDirty_127 ;
      private short gxajaxcallmode ;
      private short i1742ProvSts ;
      private int trnEnded ;
      private int edtPaiCod_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Visible ;
      private int edtEstCod_Enabled ;
      private int edtProvCod_Enabled ;
      private int edtProvDsc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombopaicod_Visible ;
      private int edtavCombopaicod_Enabled ;
      private int edtavComboestcod_Visible ;
      private int edtavComboestcod_Enabled ;
      private int Combo_paicod_Datalistupdateminimumcharacters ;
      private int Combo_paicod_Gxcontroltype ;
      private int Combo_estcod_Datalistupdateminimumcharacters ;
      private int Combo_estcod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV10PaiCod ;
      private string wcpOAV11EstCod ;
      private string wcpOAV7ProvCod ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z603ProvDsc ;
      private string Z1741ProvAbr ;
      private string Combo_estcod_Selectedvalue_get ;
      private string Combo_paicod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV10PaiCod ;
      private string AV11EstCod ;
      private string AV7ProvCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbProvSts_Internalname ;
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
      private string divTablesplittedpaicod_Internalname ;
      private string lblTextblockpaicod_Internalname ;
      private string lblTextblockpaicod_Jsonclick ;
      private string Combo_paicod_Caption ;
      private string Combo_paicod_Cls ;
      private string Combo_paicod_Datalistproc ;
      private string Combo_paicod_Datalistprocparametersprefix ;
      private string Combo_paicod_Internalname ;
      private string TempTags ;
      private string edtPaiCod_Jsonclick ;
      private string divTablesplittedestcod_Internalname ;
      private string lblTextblockestcod_Internalname ;
      private string lblTextblockestcod_Jsonclick ;
      private string Combo_estcod_Caption ;
      private string Combo_estcod_Cls ;
      private string Combo_estcod_Datalistproc ;
      private string Combo_estcod_Internalname ;
      private string edtEstCod_Internalname ;
      private string edtEstCod_Jsonclick ;
      private string edtProvCod_Internalname ;
      private string A141ProvCod ;
      private string edtProvCod_Jsonclick ;
      private string edtProvDsc_Internalname ;
      private string A603ProvDsc ;
      private string edtProvDsc_Jsonclick ;
      private string cmbProvSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_paicod_Internalname ;
      private string edtavCombopaicod_Internalname ;
      private string AV20ComboPaiCod ;
      private string edtavCombopaicod_Jsonclick ;
      private string divSectionattribute_estcod_Internalname ;
      private string edtavComboestcod_Internalname ;
      private string AV22ComboEstCod ;
      private string edtavComboestcod_Jsonclick ;
      private string A1741ProvAbr ;
      private string AV23Cond_PaiCod ;
      private string A1500PaiDsc ;
      private string Combo_paicod_Objectcall ;
      private string Combo_paicod_Class ;
      private string Combo_paicod_Icontype ;
      private string Combo_paicod_Icon ;
      private string Combo_paicod_Tooltip ;
      private string Combo_paicod_Selectedvalue_set ;
      private string Combo_paicod_Selectedtext_set ;
      private string Combo_paicod_Selectedtext_get ;
      private string Combo_paicod_Gamoauthtoken ;
      private string Combo_paicod_Ddointernalname ;
      private string Combo_paicod_Titlecontrolalign ;
      private string Combo_paicod_Dropdownoptionstype ;
      private string Combo_paicod_Titlecontrolidtoreplace ;
      private string Combo_paicod_Datalisttype ;
      private string Combo_paicod_Datalistfixedvalues ;
      private string Combo_paicod_Htmltemplate ;
      private string Combo_paicod_Multiplevaluestype ;
      private string Combo_paicod_Loadingdata ;
      private string Combo_paicod_Noresultsfound ;
      private string Combo_paicod_Emptyitemtext ;
      private string Combo_paicod_Onlyselectedvalues ;
      private string Combo_paicod_Selectalltext ;
      private string Combo_paicod_Multiplevaluesseparator ;
      private string Combo_paicod_Addnewoptiontext ;
      private string Combo_estcod_Objectcall ;
      private string Combo_estcod_Class ;
      private string Combo_estcod_Icontype ;
      private string Combo_estcod_Icon ;
      private string Combo_estcod_Tooltip ;
      private string Combo_estcod_Selectedvalue_set ;
      private string Combo_estcod_Selectedtext_set ;
      private string Combo_estcod_Selectedtext_get ;
      private string Combo_estcod_Gamoauthtoken ;
      private string Combo_estcod_Ddointernalname ;
      private string Combo_estcod_Titlecontrolalign ;
      private string Combo_estcod_Dropdownoptionstype ;
      private string Combo_estcod_Titlecontrolidtoreplace ;
      private string Combo_estcod_Datalisttype ;
      private string Combo_estcod_Datalistfixedvalues ;
      private string Combo_estcod_Datalistprocparametersprefix ;
      private string Combo_estcod_Htmltemplate ;
      private string Combo_estcod_Multiplevaluestype ;
      private string Combo_estcod_Loadingdata ;
      private string Combo_estcod_Noresultsfound ;
      private string Combo_estcod_Emptyitemtext ;
      private string Combo_estcod_Onlyselectedvalues ;
      private string Combo_estcod_Selectalltext ;
      private string Combo_estcod_Multiplevaluesseparator ;
      private string Combo_estcod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode127 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string Z1500PaiDsc ;
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
      private bool Combo_paicod_Emptyitem ;
      private bool Combo_estcod_Emptyitem ;
      private bool Combo_paicod_Enabled ;
      private bool Combo_paicod_Visible ;
      private bool Combo_paicod_Allowmultipleselection ;
      private bool Combo_paicod_Isgriditem ;
      private bool Combo_paicod_Hasdescription ;
      private bool Combo_paicod_Includeonlyselectedoption ;
      private bool Combo_paicod_Includeselectalloption ;
      private bool Combo_paicod_Includeaddnewoption ;
      private bool Combo_estcod_Enabled ;
      private bool Combo_estcod_Visible ;
      private bool Combo_estcod_Allowmultipleselection ;
      private bool Combo_estcod_Isgriditem ;
      private bool Combo_estcod_Hasdescription ;
      private bool Combo_estcod_Includeonlyselectedoption ;
      private bool Combo_estcod_Includeselectalloption ;
      private bool Combo_estcod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string AV24SGAuDocGls ;
      private string AV25Codigo ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private IGxSession AV14WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_paicod ;
      private GXUserControl ucCombo_estcod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProvSts ;
      private IDataStoreProvider pr_default ;
      private string[] T005V4_A1500PaiDsc ;
      private string[] T005V6_A141ProvCod ;
      private string[] T005V6_A603ProvDsc ;
      private string[] T005V6_A1500PaiDsc ;
      private string[] T005V6_A1741ProvAbr ;
      private short[] T005V6_A1742ProvSts ;
      private string[] T005V6_A139PaiCod ;
      private string[] T005V6_A140EstCod ;
      private string[] T005V5_A139PaiCod ;
      private string[] T005V7_A1500PaiDsc ;
      private string[] T005V8_A139PaiCod ;
      private string[] T005V9_A139PaiCod ;
      private string[] T005V9_A140EstCod ;
      private string[] T005V9_A141ProvCod ;
      private string[] T005V3_A141ProvCod ;
      private string[] T005V3_A603ProvDsc ;
      private string[] T005V3_A1741ProvAbr ;
      private short[] T005V3_A1742ProvSts ;
      private string[] T005V3_A139PaiCod ;
      private string[] T005V3_A140EstCod ;
      private string[] T005V10_A139PaiCod ;
      private string[] T005V10_A140EstCod ;
      private string[] T005V10_A141ProvCod ;
      private string[] T005V11_A139PaiCod ;
      private string[] T005V11_A140EstCod ;
      private string[] T005V11_A141ProvCod ;
      private string[] T005V2_A141ProvCod ;
      private string[] T005V2_A603ProvDsc ;
      private string[] T005V2_A1741ProvAbr ;
      private short[] T005V2_A1742ProvSts ;
      private string[] T005V2_A139PaiCod ;
      private string[] T005V2_A140EstCod ;
      private string[] T005V15_A1500PaiDsc ;
      private string[] T005V16_A139PaiCod ;
      private string[] T005V16_A140EstCod ;
      private string[] T005V16_A141ProvCod ;
      private string[] T005V16_A142DisCod ;
      private string[] T005V17_A139PaiCod ;
      private string[] T005V17_A140EstCod ;
      private string[] T005V17_A141ProvCod ;
      private string[] T005V18_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15PaiCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21EstCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
   }

   public class provincia__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class provincia__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005V6;
        prmT005V6 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V4;
        prmT005V4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005V5;
        prmT005V5 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005V7;
        prmT005V7 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005V8;
        prmT005V8 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005V9;
        prmT005V9 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V3;
        prmT005V3 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V10;
        prmT005V10 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V11;
        prmT005V11 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V2;
        prmT005V2 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V12;
        prmT005V12 = new Object[] {
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@ProvDsc",GXType.NChar,100,0) ,
        new ParDef("@ProvAbr",GXType.NChar,5,0) ,
        new ParDef("@ProvSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT005V13;
        prmT005V13 = new Object[] {
        new ParDef("@ProvDsc",GXType.NChar,100,0) ,
        new ParDef("@ProvAbr",GXType.NChar,5,0) ,
        new ParDef("@ProvSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V14;
        prmT005V14 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V16;
        prmT005V16 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005V17;
        prmT005V17 = new Object[] {
        };
        Object[] prmT005V15;
        prmT005V15 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005V18;
        prmT005V18 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005V2", "SELECT [ProvCod], [ProvDsc], [ProvAbr], [ProvSts], [PaiCod], [EstCod] FROM [CPROVINCIA] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V3", "SELECT [ProvCod], [ProvDsc], [ProvAbr], [ProvSts], [PaiCod], [EstCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V4", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V5", "SELECT [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V6", "SELECT TM1.[ProvCod], TM1.[ProvDsc], T2.[PaiDsc], TM1.[ProvAbr], TM1.[ProvSts], TM1.[PaiCod], TM1.[EstCod] FROM ([CPROVINCIA] TM1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = TM1.[PaiCod]) WHERE TM1.[PaiCod] = @PaiCod and TM1.[EstCod] = @EstCod and TM1.[ProvCod] = @ProvCod ORDER BY TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005V6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V7", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V8", "SELECT [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V9", "SELECT [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005V9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V10", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE ( [PaiCod] > @PaiCod or [PaiCod] = @PaiCod and [EstCod] > @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] > @ProvCod) ORDER BY [PaiCod], [EstCod], [ProvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005V10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005V11", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE ( [PaiCod] < @PaiCod or [PaiCod] = @PaiCod and [EstCod] < @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] < @ProvCod) ORDER BY [PaiCod] DESC, [EstCod] DESC, [ProvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005V11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005V12", "INSERT INTO [CPROVINCIA]([ProvCod], [ProvDsc], [ProvAbr], [ProvSts], [PaiCod], [EstCod]) VALUES(@ProvCod, @ProvDsc, @ProvAbr, @ProvSts, @PaiCod, @EstCod)", GxErrorMask.GX_NOMASK,prmT005V12)
           ,new CursorDef("T005V13", "UPDATE [CPROVINCIA] SET [ProvDsc]=@ProvDsc, [ProvAbr]=@ProvAbr, [ProvSts]=@ProvSts  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod", GxErrorMask.GX_NOMASK,prmT005V13)
           ,new CursorDef("T005V14", "DELETE FROM [CPROVINCIA]  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod", GxErrorMask.GX_NOMASK,prmT005V14)
           ,new CursorDef("T005V15", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V16", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005V17", "SELECT [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] ORDER BY [PaiCod], [EstCod], [ProvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005V17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005V18", "SELECT [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005V18,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
