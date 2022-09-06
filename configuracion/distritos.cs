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
   public class distritos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A139PaiCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = GetPar( "ProvCod");
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A139PaiCod, A140EstCod, A141ProvCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.distritos.aspx")), "configuracion.distritos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.distritos.aspx")))) ;
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
                  AV12ProvCod = GetPar( "ProvCod");
                  AssignAttri("", false, "AV12ProvCod", AV12ProvCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROVCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12ProvCod, "")), context));
                  AV7DisCod = GetPar( "DisCod");
                  AssignAttri("", false, "AV7DisCod", AV7DisCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vDISCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7DisCod, "")), context));
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
            Form.Meta.addItem("description", "Distritos", 0) ;
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

      public distritos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public distritos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_PaiCod ,
                           string aP2_EstCod ,
                           string aP3_ProvCod ,
                           string aP4_DisCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10PaiCod = aP1_PaiCod;
         this.AV11EstCod = aP2_EstCod;
         this.AV12ProvCod = aP3_ProvCod;
         this.AV7DisCod = aP4_DisCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbDisSts = new GXCombobox();
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
         if ( cmbDisSts.ItemCount > 0 )
         {
            A878DisSts = (short)(NumberUtil.Val( cmbDisSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0))), "."));
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDisSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0));
            AssignProp("", false, cmbDisSts_Internalname, "Values", cmbDisSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTextblockpaicod_Internalname, "Pais", "", "", lblTextblockpaicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paicod.SetProperty("Caption", Combo_paicod_Caption);
         ucCombo_paicod.SetProperty("Cls", Combo_paicod_Cls);
         ucCombo_paicod.SetProperty("DataListProc", Combo_paicod_Datalistproc);
         ucCombo_paicod.SetProperty("DataListProcParametersPrefix", Combo_paicod_Datalistprocparametersprefix);
         ucCombo_paicod.SetProperty("EmptyItem", Combo_paicod_Emptyitem);
         ucCombo_paicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_paicod.SetProperty("DropDownOptionsData", AV16PaiCod_Data);
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
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPaiCod_Visible, edtPaiCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockestcod_Internalname, "Departamento", "", "", lblTextblockestcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_estcod.SetProperty("Caption", Combo_estcod_Caption);
         ucCombo_estcod.SetProperty("Cls", Combo_estcod_Cls);
         ucCombo_estcod.SetProperty("DataListProc", Combo_estcod_Datalistproc);
         ucCombo_estcod.SetProperty("EmptyItem", Combo_estcod_Emptyitem);
         ucCombo_estcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_estcod.SetProperty("DropDownOptionsData", AV22EstCod_Data);
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
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", edtEstCod_Visible, edtEstCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedprovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprovcod_Internalname, "Provincia", "", "", lblTextblockprovcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_provcod.SetProperty("Caption", Combo_provcod_Caption);
         ucCombo_provcod.SetProperty("Cls", Combo_provcod_Cls);
         ucCombo_provcod.SetProperty("DataListProc", Combo_provcod_Datalistproc);
         ucCombo_provcod.SetProperty("EmptyItem", Combo_provcod_Emptyitem);
         ucCombo_provcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_provcod.SetProperty("DropDownOptionsData", AV25ProvCod_Data);
         ucCombo_provcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_provcod_Internalname, "COMBO_PROVCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvCod_Internalname, "Provincia", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", edtProvCod_Visible, edtProvCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDisCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDisCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisCod_Internalname, StringUtil.RTrim( A142DisCod), StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDisCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDisDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDisDsc_Internalname, "Distrito", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisDsc_Internalname, StringUtil.RTrim( A604DisDsc), StringUtil.RTrim( context.localUtil.Format( A604DisDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtDisDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbDisSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDisSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDisSts, cmbDisSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0)), 1, cmbDisSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbDisSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 1, "HLP_Configuracion\\Distritos.htm");
         cmbDisSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         AssignProp("", false, cmbDisSts_Internalname, "Values", (string)(cmbDisSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Distritos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtavCombopaicod_Internalname, StringUtil.RTrim( AV21ComboPaiCod), StringUtil.RTrim( context.localUtil.Format( AV21ComboPaiCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaicod_Visible, edtavCombopaicod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_estcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboestcod_Internalname, StringUtil.RTrim( AV23ComboEstCod), StringUtil.RTrim( context.localUtil.Format( AV23ComboEstCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboestcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboestcod_Visible, edtavComboestcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_provcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprovcod_Internalname, StringUtil.RTrim( AV26ComboProvCod), StringUtil.RTrim( context.localUtil.Format( AV26ComboProvCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprovcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprovcod_Visible, edtavComboprovcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Distritos.htm");
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
         E115W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPAICOD_DATA"), AV16PaiCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vESTCOD_DATA"), AV22EstCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROVCOD_DATA"), AV25ProvCod_Data);
               /* Read saved values. */
               Z139PaiCod = cgiGet( "Z139PaiCod");
               Z140EstCod = cgiGet( "Z140EstCod");
               Z141ProvCod = cgiGet( "Z141ProvCod");
               Z142DisCod = cgiGet( "Z142DisCod");
               Z604DisDsc = cgiGet( "Z604DisDsc");
               Z877DisAbr = cgiGet( "Z877DisAbr");
               Z878DisSts = (short)(context.localUtil.CToN( cgiGet( "Z878DisSts"), ".", ","));
               A877DisAbr = cgiGet( "Z877DisAbr");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV24Cond_PaiCod = cgiGet( "vCOND_PAICOD");
               AV27Cond_EstCod = cgiGet( "vCOND_ESTCOD");
               AV10PaiCod = cgiGet( "vPAICOD");
               AV11EstCod = cgiGet( "vESTCOD");
               AV12ProvCod = cgiGet( "vPROVCOD");
               AV7DisCod = cgiGet( "vDISCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A877DisAbr = cgiGet( "DISABR");
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
               Combo_provcod_Objectcall = cgiGet( "COMBO_PROVCOD_Objectcall");
               Combo_provcod_Class = cgiGet( "COMBO_PROVCOD_Class");
               Combo_provcod_Icontype = cgiGet( "COMBO_PROVCOD_Icontype");
               Combo_provcod_Icon = cgiGet( "COMBO_PROVCOD_Icon");
               Combo_provcod_Caption = cgiGet( "COMBO_PROVCOD_Caption");
               Combo_provcod_Tooltip = cgiGet( "COMBO_PROVCOD_Tooltip");
               Combo_provcod_Cls = cgiGet( "COMBO_PROVCOD_Cls");
               Combo_provcod_Selectedvalue_set = cgiGet( "COMBO_PROVCOD_Selectedvalue_set");
               Combo_provcod_Selectedvalue_get = cgiGet( "COMBO_PROVCOD_Selectedvalue_get");
               Combo_provcod_Selectedtext_set = cgiGet( "COMBO_PROVCOD_Selectedtext_set");
               Combo_provcod_Selectedtext_get = cgiGet( "COMBO_PROVCOD_Selectedtext_get");
               Combo_provcod_Gamoauthtoken = cgiGet( "COMBO_PROVCOD_Gamoauthtoken");
               Combo_provcod_Ddointernalname = cgiGet( "COMBO_PROVCOD_Ddointernalname");
               Combo_provcod_Titlecontrolalign = cgiGet( "COMBO_PROVCOD_Titlecontrolalign");
               Combo_provcod_Dropdownoptionstype = cgiGet( "COMBO_PROVCOD_Dropdownoptionstype");
               Combo_provcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Enabled"));
               Combo_provcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Visible"));
               Combo_provcod_Titlecontrolidtoreplace = cgiGet( "COMBO_PROVCOD_Titlecontrolidtoreplace");
               Combo_provcod_Datalisttype = cgiGet( "COMBO_PROVCOD_Datalisttype");
               Combo_provcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Allowmultipleselection"));
               Combo_provcod_Datalistfixedvalues = cgiGet( "COMBO_PROVCOD_Datalistfixedvalues");
               Combo_provcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Isgriditem"));
               Combo_provcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Hasdescription"));
               Combo_provcod_Datalistproc = cgiGet( "COMBO_PROVCOD_Datalistproc");
               Combo_provcod_Datalistprocparametersprefix = cgiGet( "COMBO_PROVCOD_Datalistprocparametersprefix");
               Combo_provcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PROVCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_provcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Includeonlyselectedoption"));
               Combo_provcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Includeselectalloption"));
               Combo_provcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Emptyitem"));
               Combo_provcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Includeaddnewoption"));
               Combo_provcod_Htmltemplate = cgiGet( "COMBO_PROVCOD_Htmltemplate");
               Combo_provcod_Multiplevaluestype = cgiGet( "COMBO_PROVCOD_Multiplevaluestype");
               Combo_provcod_Loadingdata = cgiGet( "COMBO_PROVCOD_Loadingdata");
               Combo_provcod_Noresultsfound = cgiGet( "COMBO_PROVCOD_Noresultsfound");
               Combo_provcod_Emptyitemtext = cgiGet( "COMBO_PROVCOD_Emptyitemtext");
               Combo_provcod_Onlyselectedvalues = cgiGet( "COMBO_PROVCOD_Onlyselectedvalues");
               Combo_provcod_Selectalltext = cgiGet( "COMBO_PROVCOD_Selectalltext");
               Combo_provcod_Multiplevaluesseparator = cgiGet( "COMBO_PROVCOD_Multiplevaluesseparator");
               Combo_provcod_Addnewoptiontext = cgiGet( "COMBO_PROVCOD_Addnewoptiontext");
               Combo_provcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PROVCOD_Gxcontroltype"), ".", ","));
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
               A142DisCod = cgiGet( edtDisCod_Internalname);
               AssignAttri("", false, "A142DisCod", A142DisCod);
               A604DisDsc = cgiGet( edtDisDsc_Internalname);
               AssignAttri("", false, "A604DisDsc", A604DisDsc);
               cmbDisSts.CurrentValue = cgiGet( cmbDisSts_Internalname);
               A878DisSts = (short)(NumberUtil.Val( cgiGet( cmbDisSts_Internalname), "."));
               AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
               AV21ComboPaiCod = cgiGet( edtavCombopaicod_Internalname);
               AssignAttri("", false, "AV21ComboPaiCod", AV21ComboPaiCod);
               AV23ComboEstCod = cgiGet( edtavComboestcod_Internalname);
               AssignAttri("", false, "AV23ComboEstCod", AV23ComboEstCod);
               AV26ComboProvCod = cgiGet( edtavComboprovcod_Internalname);
               AssignAttri("", false, "AV26ComboProvCod", AV26ComboProvCod);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Distritos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("DisAbr", StringUtil.RTrim( context.localUtil.Format( A877DisAbr, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\distritos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A142DisCod = GetPar( "DisCod");
                  AssignAttri("", false, "A142DisCod", A142DisCod);
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
                     sMode77 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode77;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound77 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5W0( ) ;
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
                           E115W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125W2 ();
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
            E125W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5W77( ) ;
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
            DisableAttributes5W77( ) ;
         }
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Enabled), 5, 0), true);
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

      protected void CONFIRM_5W0( )
      {
         BeforeValidate5W77( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5W77( ) ;
            }
            else
            {
               CheckExtendedTable5W77( ) ;
               CloseExtendedTableCursors5W77( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5W0( )
      {
      }

      protected void E115W2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtProvCod_Visible = 0;
         AssignProp("", false, edtProvCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProvCod_Visible), 5, 0), true);
         AV26ComboProvCod = "";
         AssignAttri("", false, "AV26ComboProvCod", AV26ComboProvCod);
         edtavComboprovcod_Visible = 0;
         AssignProp("", false, edtavComboprovcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Visible), 5, 0), true);
         edtEstCod_Visible = 0;
         AssignProp("", false, edtEstCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstCod_Visible), 5, 0), true);
         AV23ComboEstCod = "";
         AssignAttri("", false, "AV23ComboEstCod", AV23ComboEstCod);
         edtavComboestcod_Visible = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Visible), 5, 0), true);
         edtPaiCod_Visible = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaiCod_Visible), 5, 0), true);
         AV21ComboPaiCod = "";
         AssignAttri("", false, "AV21ComboPaiCod", AV21ComboPaiCod);
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
         /* Execute user subroutine: 'LOADCOMBOPROVCOD' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV14TrnContext.FromXml(AV15WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E125W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV28SGAuDocGls = "Distritos N° " + StringUtil.Trim( A604DisDsc);
            AV29Codigo = A142DisCod;
            GXt_char2 = "CNF";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV28SGAuDocGls, ref  AV29Codigo, ref  AV29Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV14TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.distritosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'LOADCOMBOPROVCOD' Routine */
         returnInSub = false;
         Combo_provcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ProvCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaiCod\": \"\", \"EstCod\": \"\", \"ProvCod\": \"\", \"DisCod\": \"\", \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\"", edtPaiCod_Internalname, edtEstCod_Internalname, "", "", "", "", "", "", "");
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "DataListProcParametersPrefix", Combo_provcod_Datalistprocparametersprefix);
         GXt_char4 = AV20Combo_DataJson;
         new GeneXus.Programs.configuracion.distritosloaddvcombo(context ).execute(  "ProvCod",  Gx_mode,  false,  AV10PaiCod,  AV11EstCod,  AV12ProvCod,  AV7DisCod,  A139PaiCod,  A140EstCod,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char4) ;
         AV20Combo_DataJson = GXt_char4;
         Combo_provcod_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
         Combo_provcod_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
         AV26ComboProvCod = AV18ComboSelectedValue;
         AssignAttri("", false, "AV26ComboProvCod", AV26ComboProvCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ProvCod)) )
         {
            Combo_provcod_Enabled = false;
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOESTCOD' Routine */
         returnInSub = false;
         Combo_estcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"EstCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaiCod\": \"\", \"EstCod\": \"\", \"ProvCod\": \"\", \"DisCod\": \"\", \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\"", edtPaiCod_Internalname, edtEstCod_Internalname, "", "", "", "", "", "", "");
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "DataListProcParametersPrefix", Combo_estcod_Datalistprocparametersprefix);
         GXt_char4 = AV20Combo_DataJson;
         new GeneXus.Programs.configuracion.distritosloaddvcombo(context ).execute(  "EstCod",  Gx_mode,  false,  AV10PaiCod,  AV11EstCod,  AV12ProvCod,  AV7DisCod,  A139PaiCod,  A140EstCod,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char4) ;
         AV20Combo_DataJson = GXt_char4;
         Combo_estcod_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
         Combo_estcod_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedText_set", Combo_estcod_Selectedtext_set);
         AV23ComboEstCod = AV18ComboSelectedValue;
         AssignAttri("", false, "AV23ComboEstCod", AV23ComboEstCod);
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
         GXt_char4 = AV20Combo_DataJson;
         new GeneXus.Programs.configuracion.distritosloaddvcombo(context ).execute(  "PaiCod",  Gx_mode,  false,  AV10PaiCod,  AV11EstCod,  AV12ProvCod,  AV7DisCod,  A139PaiCod,  A140EstCod,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char4) ;
         AV20Combo_DataJson = GXt_char4;
         Combo_paicod_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
         Combo_paicod_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
         AV21ComboPaiCod = AV18ComboSelectedValue;
         AssignAttri("", false, "AV21ComboPaiCod", AV21ComboPaiCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            Combo_paicod_Enabled = false;
            ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         }
      }

      protected void ZM5W77( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z604DisDsc = T005W3_A604DisDsc[0];
               Z877DisAbr = T005W3_A877DisAbr[0];
               Z878DisSts = T005W3_A878DisSts[0];
            }
            else
            {
               Z604DisDsc = A604DisDsc;
               Z877DisAbr = A877DisAbr;
               Z878DisSts = A878DisSts;
            }
         }
         if ( GX_JID == -19 )
         {
            Z142DisCod = A142DisCod;
            Z604DisDsc = A604DisDsc;
            Z877DisAbr = A877DisAbr;
            Z878DisSts = A878DisSts;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ProvCod)) )
         {
            edtProvCod_Enabled = 0;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         else
         {
            edtProvCod_Enabled = 1;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ProvCod)) )
         {
            edtProvCod_Enabled = 0;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7DisCod)) )
         {
            A142DisCod = AV7DisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7DisCod)) )
         {
            edtDisCod_Enabled = 0;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
         else
         {
            edtDisCod_Enabled = 1;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7DisCod)) )
         {
            edtDisCod_Enabled = 0;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ProvCod)) )
         {
            A141ProvCod = AV12ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         else
         {
            A141ProvCod = AV26ComboProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EstCod)) )
         {
            A140EstCod = AV11EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         else
         {
            A140EstCod = AV23ComboEstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PaiCod)) )
         {
            A139PaiCod = AV10PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         else
         {
            A139PaiCod = AV21ComboPaiCod;
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
         if ( IsIns( )  && (0==A878DisSts) && ( Gx_BScreen == 0 ) )
         {
            A878DisSts = 1;
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T005W4 */
            pr_default.execute(2, new Object[] {A139PaiCod});
            A1500PaiDsc = T005W4_A1500PaiDsc[0];
            pr_default.close(2);
         }
      }

      protected void Load5W77( )
      {
         /* Using cursor T005W6 */
         pr_default.execute(4, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound77 = 1;
            A1500PaiDsc = T005W6_A1500PaiDsc[0];
            A604DisDsc = T005W6_A604DisDsc[0];
            AssignAttri("", false, "A604DisDsc", A604DisDsc);
            A877DisAbr = T005W6_A877DisAbr[0];
            A878DisSts = T005W6_A878DisSts[0];
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
            ZM5W77( -19) ;
         }
         pr_default.close(4);
         OnLoadActions5W77( ) ;
      }

      protected void OnLoadActions5W77( )
      {
      }

      protected void CheckExtendedTable5W77( )
      {
         nIsDirty_77 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T005W4 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T005W4_A1500PaiDsc[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Pais", "", "", "", "", "", "", "", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A140EstCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Estado", "", "", "", "", "", "", "", ""), 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtEstCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005W5 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141ProvCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Provincia", "", "", "", "", "", "", "", ""), 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtProvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A142DisCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Distrito", "", "", "", "", "", "", "", ""), 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtDisCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A604DisDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Distrito", "", "", "", "", "", "", "", ""), 1, "DISDSC");
            AnyError = 1;
            GX_FocusControl = edtDisDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5W77( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( string A139PaiCod )
      {
         /* Using cursor T005W7 */
         pr_default.execute(5, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T005W7_A1500PaiDsc[0];
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

      protected void gxLoad_21( string A139PaiCod ,
                                string A140EstCod ,
                                string A141ProvCod )
      {
         /* Using cursor T005W8 */
         pr_default.execute(6, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
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

      protected void GetKey5W77( )
      {
         /* Using cursor T005W9 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005W3 */
         pr_default.execute(1, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5W77( 19) ;
            RcdFound77 = 1;
            A142DisCod = T005W3_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A604DisDsc = T005W3_A604DisDsc[0];
            AssignAttri("", false, "A604DisDsc", A604DisDsc);
            A877DisAbr = T005W3_A877DisAbr[0];
            A878DisSts = T005W3_A878DisSts[0];
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
            A139PaiCod = T005W3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005W3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005W3_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            Z142DisCod = A142DisCod;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5W77( ) ;
            if ( AnyError == 1 )
            {
               RcdFound77 = 0;
               InitializeNonKey5W77( ) ;
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey5W77( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5W77( ) ;
         if ( RcdFound77 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound77 = 0;
         /* Using cursor T005W10 */
         pr_default.execute(8, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T005W10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A141ProvCod[0], A141ProvCod) < 0 ) || ( StringUtil.StrCmp(T005W10_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A142DisCod[0], A142DisCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T005W10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A141ProvCod[0], A141ProvCod) > 0 ) || ( StringUtil.StrCmp(T005W10_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W10_A142DisCod[0], A142DisCod) > 0 ) ) )
            {
               A139PaiCod = T005W10_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T005W10_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T005W10_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = T005W10_A142DisCod[0];
               AssignAttri("", false, "A142DisCod", A142DisCod);
               RcdFound77 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound77 = 0;
         /* Using cursor T005W11 */
         pr_default.execute(9, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T005W11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A141ProvCod[0], A141ProvCod) > 0 ) || ( StringUtil.StrCmp(T005W11_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A142DisCod[0], A142DisCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T005W11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A141ProvCod[0], A141ProvCod) < 0 ) || ( StringUtil.StrCmp(T005W11_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T005W11_A142DisCod[0], A142DisCod) < 0 ) ) )
            {
               A139PaiCod = T005W11_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T005W11_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T005W11_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = T005W11_A142DisCod[0];
               AssignAttri("", false, "A142DisCod", A142DisCod);
               RcdFound77 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5W77( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5W77( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound77 == 1 )
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = Z140EstCod;
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  A141ProvCod = Z141ProvCod;
                  AssignAttri("", false, "A141ProvCod", A141ProvCod);
                  A142DisCod = Z142DisCod;
                  AssignAttri("", false, "A142DisCod", A142DisCod);
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
                  Update5W77( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5W77( ) ;
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
                     Insert5W77( ) ;
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
         if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = Z140EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = Z141ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = Z142DisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
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

      protected void CheckOptimisticConcurrency5W77( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005W2 */
            pr_default.execute(0, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CDISTRITOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z604DisDsc, T005W2_A604DisDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z877DisAbr, T005W2_A877DisAbr[0]) != 0 ) || ( Z878DisSts != T005W2_A878DisSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z604DisDsc, T005W2_A604DisDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.distritos:[seudo value changed for attri]"+"DisDsc");
                  GXUtil.WriteLogRaw("Old: ",Z604DisDsc);
                  GXUtil.WriteLogRaw("Current: ",T005W2_A604DisDsc[0]);
               }
               if ( StringUtil.StrCmp(Z877DisAbr, T005W2_A877DisAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.distritos:[seudo value changed for attri]"+"DisAbr");
                  GXUtil.WriteLogRaw("Old: ",Z877DisAbr);
                  GXUtil.WriteLogRaw("Current: ",T005W2_A877DisAbr[0]);
               }
               if ( Z878DisSts != T005W2_A878DisSts[0] )
               {
                  GXUtil.WriteLog("configuracion.distritos:[seudo value changed for attri]"+"DisSts");
                  GXUtil.WriteLogRaw("Old: ",Z878DisSts);
                  GXUtil.WriteLogRaw("Current: ",T005W2_A878DisSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CDISTRITOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5W77( )
      {
         BeforeValidate5W77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5W77( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5W77( 0) ;
            CheckOptimisticConcurrency5W77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5W77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5W77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005W12 */
                     pr_default.execute(10, new Object[] {A142DisCod, A604DisDsc, A877DisAbr, A878DisSts, A139PaiCod, A140EstCod, A141ProvCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CDISTRITOS");
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
                           ResetCaption5W0( ) ;
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
               Load5W77( ) ;
            }
            EndLevel5W77( ) ;
         }
         CloseExtendedTableCursors5W77( ) ;
      }

      protected void Update5W77( )
      {
         BeforeValidate5W77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5W77( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5W77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5W77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5W77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005W13 */
                     pr_default.execute(11, new Object[] {A604DisDsc, A877DisAbr, A878DisSts, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CDISTRITOS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CDISTRITOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5W77( ) ;
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
            EndLevel5W77( ) ;
         }
         CloseExtendedTableCursors5W77( ) ;
      }

      protected void DeferredUpdate5W77( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5W77( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5W77( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5W77( ) ;
            AfterConfirm5W77( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5W77( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005W14 */
                  pr_default.execute(12, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CDISTRITOS");
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5W77( ) ;
         Gx_mode = sMode77;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5W77( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005W15 */
            pr_default.execute(13, new Object[] {A139PaiCod});
            A1500PaiDsc = T005W15_A1500PaiDsc[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005W16 */
            pr_default.execute(14, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005W17 */
            pr_default.execute(15, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Almacen"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005W18 */
            pr_default.execute(16, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel5W77( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5W77( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("configuracion.distritos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("configuracion.distritos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5W77( )
      {
         /* Scan By routine */
         /* Using cursor T005W19 */
         pr_default.execute(17);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound77 = 1;
            A139PaiCod = T005W19_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005W19_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005W19_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T005W19_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5W77( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound77 = 1;
            A139PaiCod = T005W19_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005W19_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005W19_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T005W19_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
      }

      protected void ScanEnd5W77( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm5W77( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5W77( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5W77( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5W77( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5W77( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5W77( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5W77( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtDisCod_Enabled = 0;
         AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         edtDisDsc_Enabled = 0;
         AssignProp("", false, edtDisDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisDsc_Enabled), 5, 0), true);
         cmbDisSts.Enabled = 0;
         AssignProp("", false, cmbDisSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDisSts.Enabled), 5, 0), true);
         edtavCombopaicod_Enabled = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         edtavComboestcod_Enabled = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
         edtavComboprovcod_Enabled = 0;
         AssignProp("", false, edtavComboprovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5W77( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5W0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262197", false, true);
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
         GXEncryptionTmp = "configuracion.distritos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10PaiCod)) + "," + UrlEncode(StringUtil.RTrim(AV11EstCod)) + "," + UrlEncode(StringUtil.RTrim(AV12ProvCod)) + "," + UrlEncode(StringUtil.RTrim(AV7DisCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.distritos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Distritos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("DisAbr", StringUtil.RTrim( context.localUtil.Format( A877DisAbr, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\distritos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "Z604DisDsc", StringUtil.RTrim( Z604DisDsc));
         GxWebStd.gx_hidden_field( context, "Z877DisAbr", StringUtil.RTrim( Z877DisAbr));
         GxWebStd.gx_hidden_field( context, "Z878DisSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z878DisSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAICOD_DATA", AV16PaiCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAICOD_DATA", AV16PaiCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTCOD_DATA", AV22EstCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTCOD_DATA", AV22EstCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROVCOD_DATA", AV25ProvCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROVCOD_DATA", AV25ProvCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV14TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV14TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV14TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCOND_PAICOD", StringUtil.RTrim( AV24Cond_PaiCod));
         GxWebStd.gx_hidden_field( context, "vCOND_ESTCOD", StringUtil.RTrim( AV27Cond_EstCod));
         GxWebStd.gx_hidden_field( context, "vPAICOD", StringUtil.RTrim( AV10PaiCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10PaiCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTCOD", StringUtil.RTrim( AV11EstCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11EstCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROVCOD", StringUtil.RTrim( AV12ProvCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12ProvCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vDISCOD", StringUtil.RTrim( AV7DisCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7DisCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DISABR", StringUtil.RTrim( A877DisAbr));
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
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Objectcall", StringUtil.RTrim( Combo_provcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Cls", StringUtil.RTrim( Combo_provcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedvalue_set", StringUtil.RTrim( Combo_provcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedtext_set", StringUtil.RTrim( Combo_provcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Datalistproc", StringUtil.RTrim( Combo_provcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_provcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Emptyitem", StringUtil.BoolToStr( Combo_provcod_Emptyitem));
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
         GXEncryptionTmp = "configuracion.distritos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10PaiCod)) + "," + UrlEncode(StringUtil.RTrim(AV11EstCod)) + "," + UrlEncode(StringUtil.RTrim(AV12ProvCod)) + "," + UrlEncode(StringUtil.RTrim(AV7DisCod));
         return formatLink("configuracion.distritos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Distritos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Distritos" ;
      }

      protected void InitializeNonKey5W77( )
      {
         A1500PaiDsc = "";
         AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
         A604DisDsc = "";
         AssignAttri("", false, "A604DisDsc", A604DisDsc);
         A877DisAbr = "";
         AssignAttri("", false, "A877DisAbr", A877DisAbr);
         A878DisSts = 1;
         AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         Z604DisDsc = "";
         Z877DisAbr = "";
         Z878DisSts = 0;
      }

      protected void InitAll5W77( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         A142DisCod = "";
         AssignAttri("", false, "A142DisCod", A142DisCod);
         InitializeNonKey5W77( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A878DisSts = i878DisSts;
         AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262243", true, true);
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
         context.AddJavascriptSource("configuracion/distritos.js", "?202281810262243", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         lblTextblockprovcod_Internalname = "TEXTBLOCKPROVCOD";
         Combo_provcod_Internalname = "COMBO_PROVCOD";
         edtProvCod_Internalname = "PROVCOD";
         divTablesplittedprovcod_Internalname = "TABLESPLITTEDPROVCOD";
         edtDisCod_Internalname = "DISCOD";
         edtDisDsc_Internalname = "DISDSC";
         cmbDisSts_Internalname = "DISSTS";
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
         edtavComboprovcod_Internalname = "vCOMBOPROVCOD";
         divSectionattribute_provcod_Internalname = "SECTIONATTRIBUTE_PROVCOD";
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
         Form.Caption = "Distritos";
         Combo_estcod_Datalistprocparametersprefix = "";
         Combo_provcod_Datalistprocparametersprefix = "";
         edtavComboprovcod_Jsonclick = "";
         edtavComboprovcod_Enabled = 0;
         edtavComboprovcod_Visible = 1;
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
         cmbDisSts_Jsonclick = "";
         cmbDisSts.Enabled = 1;
         edtDisDsc_Jsonclick = "";
         edtDisDsc_Enabled = 1;
         edtDisCod_Jsonclick = "";
         edtDisCod_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtProvCod_Visible = 1;
         Combo_provcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_provcod_Datalistproc = "Configuracion.DistritosLoadDVCombo";
         Combo_provcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_provcod_Caption = "";
         Combo_provcod_Enabled = Convert.ToBoolean( -1);
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtEstCod_Visible = 1;
         Combo_estcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_estcod_Datalistproc = "Configuracion.DistritosLoadDVCombo";
         Combo_estcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_estcod_Caption = "";
         Combo_estcod_Enabled = Convert.ToBoolean( -1);
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
         edtPaiCod_Visible = 1;
         Combo_paicod_Emptyitem = Convert.ToBoolean( 0);
         Combo_paicod_Datalistprocparametersprefix = " \"ComboName\": \"PaiCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PaiCod\": \"\", \"EstCod\": \"\", \"ProvCod\": \"\", \"DisCod\": \"\"";
         Combo_paicod_Datalistproc = "Configuracion.DistritosLoadDVCombo";
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
         cmbDisSts.Name = "DISSTS";
         cmbDisSts.WebTags = "";
         cmbDisSts.addItem("1", "ACTIVO", 0);
         cmbDisSts.addItem("0", "INACTIVO", 0);
         if ( cmbDisSts.ItemCount > 0 )
         {
            if ( (0==A878DisSts) )
            {
               A878DisSts = 1;
               AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
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
         /* Using cursor T005W15 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A1500PaiDsc = T005W15_A1500PaiDsc[0];
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

      public void Valid_Provcod( )
      {
         /* Using cursor T005W20 */
         pr_default.execute(18, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(18);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141ProvCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Provincia", "", "", "", "", "", "", "", ""), 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtProvCod_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10PaiCod',fld:'vPAICOD',pic:'',hsh:true},{av:'AV11EstCod',fld:'vESTCOD',pic:'',hsh:true},{av:'AV12ProvCod',fld:'vPROVCOD',pic:'',hsh:true},{av:'AV7DisCod',fld:'vDISCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV14TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV10PaiCod',fld:'vPAICOD',pic:'',hsh:true},{av:'AV11EstCod',fld:'vESTCOD',pic:'',hsh:true},{av:'AV12ProvCod',fld:'vPROVCOD',pic:'',hsh:true},{av:'AV7DisCod',fld:'vDISCOD',pic:'',hsh:true},{av:'A877DisAbr',fld:'DISABR',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125W2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A604DisDsc',fld:'DISDSC',pic:''},{av:'A142DisCod',fld:'DISCOD',pic:''},{av:'AV14TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''}]");
         setEventMetadata("VALID_PROVCOD",",oparms:[]}");
         setEventMetadata("VALID_DISCOD","{handler:'Valid_Discod',iparms:[]");
         setEventMetadata("VALID_DISCOD",",oparms:[]}");
         setEventMetadata("VALID_DISDSC","{handler:'Valid_Disdsc',iparms:[]");
         setEventMetadata("VALID_DISDSC",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPAICOD","{handler:'Validv_Combopaicod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPAICOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOESTCOD","{handler:'Validv_Comboestcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOESTCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPROVCOD","{handler:'Validv_Comboprovcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPROVCOD",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV10PaiCod = "";
         wcpOAV11EstCod = "";
         wcpOAV12ProvCod = "";
         wcpOAV7DisCod = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         Z604DisDsc = "";
         Z877DisAbr = "";
         Combo_provcod_Selectedvalue_get = "";
         Combo_estcod_Selectedvalue_get = "";
         Combo_paicod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
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
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16PaiCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockestcod_Jsonclick = "";
         ucCombo_estcod = new GXUserControl();
         AV22EstCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockprovcod_Jsonclick = "";
         ucCombo_provcod = new GXUserControl();
         AV25ProvCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A142DisCod = "";
         A604DisDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV21ComboPaiCod = "";
         AV23ComboEstCod = "";
         AV26ComboProvCod = "";
         A877DisAbr = "";
         AV24Cond_PaiCod = "";
         AV27Cond_EstCod = "";
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
         Combo_provcod_Objectcall = "";
         Combo_provcod_Class = "";
         Combo_provcod_Icontype = "";
         Combo_provcod_Icon = "";
         Combo_provcod_Tooltip = "";
         Combo_provcod_Selectedvalue_set = "";
         Combo_provcod_Selectedtext_set = "";
         Combo_provcod_Selectedtext_get = "";
         Combo_provcod_Gamoauthtoken = "";
         Combo_provcod_Ddointernalname = "";
         Combo_provcod_Titlecontrolalign = "";
         Combo_provcod_Dropdownoptionstype = "";
         Combo_provcod_Titlecontrolidtoreplace = "";
         Combo_provcod_Datalisttype = "";
         Combo_provcod_Datalistfixedvalues = "";
         Combo_provcod_Htmltemplate = "";
         Combo_provcod_Multiplevaluestype = "";
         Combo_provcod_Loadingdata = "";
         Combo_provcod_Noresultsfound = "";
         Combo_provcod_Emptyitemtext = "";
         Combo_provcod_Onlyselectedvalues = "";
         Combo_provcod_Selectalltext = "";
         Combo_provcod_Multiplevaluesseparator = "";
         Combo_provcod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode77 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV15WebSession = context.GetSession();
         AV28SGAuDocGls = "";
         AV29Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         GXt_char4 = "";
         Z1500PaiDsc = "";
         T005W4_A1500PaiDsc = new string[] {""} ;
         T005W6_A142DisCod = new string[] {""} ;
         T005W6_A1500PaiDsc = new string[] {""} ;
         T005W6_A604DisDsc = new string[] {""} ;
         T005W6_A877DisAbr = new string[] {""} ;
         T005W6_A878DisSts = new short[1] ;
         T005W6_A139PaiCod = new string[] {""} ;
         T005W6_A140EstCod = new string[] {""} ;
         T005W6_A141ProvCod = new string[] {""} ;
         T005W5_A139PaiCod = new string[] {""} ;
         T005W7_A1500PaiDsc = new string[] {""} ;
         T005W8_A139PaiCod = new string[] {""} ;
         T005W9_A139PaiCod = new string[] {""} ;
         T005W9_A140EstCod = new string[] {""} ;
         T005W9_A141ProvCod = new string[] {""} ;
         T005W9_A142DisCod = new string[] {""} ;
         T005W3_A142DisCod = new string[] {""} ;
         T005W3_A604DisDsc = new string[] {""} ;
         T005W3_A877DisAbr = new string[] {""} ;
         T005W3_A878DisSts = new short[1] ;
         T005W3_A139PaiCod = new string[] {""} ;
         T005W3_A140EstCod = new string[] {""} ;
         T005W3_A141ProvCod = new string[] {""} ;
         T005W10_A139PaiCod = new string[] {""} ;
         T005W10_A140EstCod = new string[] {""} ;
         T005W10_A141ProvCod = new string[] {""} ;
         T005W10_A142DisCod = new string[] {""} ;
         T005W11_A139PaiCod = new string[] {""} ;
         T005W11_A140EstCod = new string[] {""} ;
         T005W11_A141ProvCod = new string[] {""} ;
         T005W11_A142DisCod = new string[] {""} ;
         T005W2_A142DisCod = new string[] {""} ;
         T005W2_A604DisDsc = new string[] {""} ;
         T005W2_A877DisAbr = new string[] {""} ;
         T005W2_A878DisSts = new short[1] ;
         T005W2_A139PaiCod = new string[] {""} ;
         T005W2_A140EstCod = new string[] {""} ;
         T005W2_A141ProvCod = new string[] {""} ;
         T005W15_A1500PaiDsc = new string[] {""} ;
         T005W16_A244PrvCod = new string[] {""} ;
         T005W17_A63AlmCod = new int[1] ;
         T005W18_A45CliCod = new string[] {""} ;
         T005W19_A139PaiCod = new string[] {""} ;
         T005W19_A140EstCod = new string[] {""} ;
         T005W19_A141ProvCod = new string[] {""} ;
         T005W19_A142DisCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T005W20_A139PaiCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.distritos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.distritos__default(),
            new Object[][] {
                new Object[] {
               T005W2_A142DisCod, T005W2_A604DisDsc, T005W2_A877DisAbr, T005W2_A878DisSts, T005W2_A139PaiCod, T005W2_A140EstCod, T005W2_A141ProvCod
               }
               , new Object[] {
               T005W3_A142DisCod, T005W3_A604DisDsc, T005W3_A877DisAbr, T005W3_A878DisSts, T005W3_A139PaiCod, T005W3_A140EstCod, T005W3_A141ProvCod
               }
               , new Object[] {
               T005W4_A1500PaiDsc
               }
               , new Object[] {
               T005W5_A139PaiCod
               }
               , new Object[] {
               T005W6_A142DisCod, T005W6_A1500PaiDsc, T005W6_A604DisDsc, T005W6_A877DisAbr, T005W6_A878DisSts, T005W6_A139PaiCod, T005W6_A140EstCod, T005W6_A141ProvCod
               }
               , new Object[] {
               T005W7_A1500PaiDsc
               }
               , new Object[] {
               T005W8_A139PaiCod
               }
               , new Object[] {
               T005W9_A139PaiCod, T005W9_A140EstCod, T005W9_A141ProvCod, T005W9_A142DisCod
               }
               , new Object[] {
               T005W10_A139PaiCod, T005W10_A140EstCod, T005W10_A141ProvCod, T005W10_A142DisCod
               }
               , new Object[] {
               T005W11_A139PaiCod, T005W11_A140EstCod, T005W11_A141ProvCod, T005W11_A142DisCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005W15_A1500PaiDsc
               }
               , new Object[] {
               T005W16_A244PrvCod
               }
               , new Object[] {
               T005W17_A63AlmCod
               }
               , new Object[] {
               T005W18_A45CliCod
               }
               , new Object[] {
               T005W19_A139PaiCod, T005W19_A140EstCod, T005W19_A141ProvCod, T005W19_A142DisCod
               }
               , new Object[] {
               T005W20_A139PaiCod
               }
            }
         );
         Z878DisSts = 1;
         A878DisSts = 1;
         i878DisSts = 1;
      }

      private short Z878DisSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A878DisSts ;
      private short Gx_BScreen ;
      private short RcdFound77 ;
      private short GX_JID ;
      private short nIsDirty_77 ;
      private short gxajaxcallmode ;
      private short i878DisSts ;
      private int trnEnded ;
      private int edtPaiCod_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Visible ;
      private int edtEstCod_Enabled ;
      private int edtProvCod_Visible ;
      private int edtProvCod_Enabled ;
      private int edtDisCod_Enabled ;
      private int edtDisDsc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombopaicod_Visible ;
      private int edtavCombopaicod_Enabled ;
      private int edtavComboestcod_Visible ;
      private int edtavComboestcod_Enabled ;
      private int edtavComboprovcod_Visible ;
      private int edtavComboprovcod_Enabled ;
      private int Combo_paicod_Datalistupdateminimumcharacters ;
      private int Combo_paicod_Gxcontroltype ;
      private int Combo_estcod_Datalistupdateminimumcharacters ;
      private int Combo_estcod_Gxcontroltype ;
      private int Combo_provcod_Datalistupdateminimumcharacters ;
      private int Combo_provcod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV10PaiCod ;
      private string wcpOAV11EstCod ;
      private string wcpOAV12ProvCod ;
      private string wcpOAV7DisCod ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z142DisCod ;
      private string Z604DisDsc ;
      private string Z877DisAbr ;
      private string Combo_provcod_Selectedvalue_get ;
      private string Combo_estcod_Selectedvalue_get ;
      private string Combo_paicod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV10PaiCod ;
      private string AV11EstCod ;
      private string AV12ProvCod ;
      private string AV7DisCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbDisSts_Internalname ;
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
      private string divTablesplittedprovcod_Internalname ;
      private string lblTextblockprovcod_Internalname ;
      private string lblTextblockprovcod_Jsonclick ;
      private string Combo_provcod_Caption ;
      private string Combo_provcod_Cls ;
      private string Combo_provcod_Datalistproc ;
      private string Combo_provcod_Internalname ;
      private string edtProvCod_Internalname ;
      private string edtProvCod_Jsonclick ;
      private string edtDisCod_Internalname ;
      private string A142DisCod ;
      private string edtDisCod_Jsonclick ;
      private string edtDisDsc_Internalname ;
      private string A604DisDsc ;
      private string edtDisDsc_Jsonclick ;
      private string cmbDisSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_paicod_Internalname ;
      private string edtavCombopaicod_Internalname ;
      private string AV21ComboPaiCod ;
      private string edtavCombopaicod_Jsonclick ;
      private string divSectionattribute_estcod_Internalname ;
      private string edtavComboestcod_Internalname ;
      private string AV23ComboEstCod ;
      private string edtavComboestcod_Jsonclick ;
      private string divSectionattribute_provcod_Internalname ;
      private string edtavComboprovcod_Internalname ;
      private string AV26ComboProvCod ;
      private string edtavComboprovcod_Jsonclick ;
      private string A877DisAbr ;
      private string AV24Cond_PaiCod ;
      private string AV27Cond_EstCod ;
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
      private string Combo_provcod_Objectcall ;
      private string Combo_provcod_Class ;
      private string Combo_provcod_Icontype ;
      private string Combo_provcod_Icon ;
      private string Combo_provcod_Tooltip ;
      private string Combo_provcod_Selectedvalue_set ;
      private string Combo_provcod_Selectedtext_set ;
      private string Combo_provcod_Selectedtext_get ;
      private string Combo_provcod_Gamoauthtoken ;
      private string Combo_provcod_Ddointernalname ;
      private string Combo_provcod_Titlecontrolalign ;
      private string Combo_provcod_Dropdownoptionstype ;
      private string Combo_provcod_Titlecontrolidtoreplace ;
      private string Combo_provcod_Datalisttype ;
      private string Combo_provcod_Datalistfixedvalues ;
      private string Combo_provcod_Datalistprocparametersprefix ;
      private string Combo_provcod_Htmltemplate ;
      private string Combo_provcod_Multiplevaluestype ;
      private string Combo_provcod_Loadingdata ;
      private string Combo_provcod_Noresultsfound ;
      private string Combo_provcod_Emptyitemtext ;
      private string Combo_provcod_Onlyselectedvalues ;
      private string Combo_provcod_Selectalltext ;
      private string Combo_provcod_Multiplevaluesseparator ;
      private string Combo_provcod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode77 ;
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
      private bool Combo_provcod_Emptyitem ;
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
      private bool Combo_provcod_Enabled ;
      private bool Combo_provcod_Visible ;
      private bool Combo_provcod_Allowmultipleselection ;
      private bool Combo_provcod_Isgriditem ;
      private bool Combo_provcod_Hasdescription ;
      private bool Combo_provcod_Includeonlyselectedoption ;
      private bool Combo_provcod_Includeselectalloption ;
      private bool Combo_provcod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV20Combo_DataJson ;
      private string AV28SGAuDocGls ;
      private string AV29Codigo ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private IGxSession AV15WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_paicod ;
      private GXUserControl ucCombo_estcod ;
      private GXUserControl ucCombo_provcod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDisSts ;
      private IDataStoreProvider pr_default ;
      private string[] T005W4_A1500PaiDsc ;
      private string[] T005W6_A142DisCod ;
      private string[] T005W6_A1500PaiDsc ;
      private string[] T005W6_A604DisDsc ;
      private string[] T005W6_A877DisAbr ;
      private short[] T005W6_A878DisSts ;
      private string[] T005W6_A139PaiCod ;
      private string[] T005W6_A140EstCod ;
      private string[] T005W6_A141ProvCod ;
      private string[] T005W5_A139PaiCod ;
      private string[] T005W7_A1500PaiDsc ;
      private string[] T005W8_A139PaiCod ;
      private string[] T005W9_A139PaiCod ;
      private string[] T005W9_A140EstCod ;
      private string[] T005W9_A141ProvCod ;
      private string[] T005W9_A142DisCod ;
      private string[] T005W3_A142DisCod ;
      private string[] T005W3_A604DisDsc ;
      private string[] T005W3_A877DisAbr ;
      private short[] T005W3_A878DisSts ;
      private string[] T005W3_A139PaiCod ;
      private string[] T005W3_A140EstCod ;
      private string[] T005W3_A141ProvCod ;
      private string[] T005W10_A139PaiCod ;
      private string[] T005W10_A140EstCod ;
      private string[] T005W10_A141ProvCod ;
      private string[] T005W10_A142DisCod ;
      private string[] T005W11_A139PaiCod ;
      private string[] T005W11_A140EstCod ;
      private string[] T005W11_A141ProvCod ;
      private string[] T005W11_A142DisCod ;
      private string[] T005W2_A142DisCod ;
      private string[] T005W2_A604DisDsc ;
      private string[] T005W2_A877DisAbr ;
      private short[] T005W2_A878DisSts ;
      private string[] T005W2_A139PaiCod ;
      private string[] T005W2_A140EstCod ;
      private string[] T005W2_A141ProvCod ;
      private string[] T005W15_A1500PaiDsc ;
      private string[] T005W16_A244PrvCod ;
      private int[] T005W17_A63AlmCod ;
      private string[] T005W18_A45CliCod ;
      private string[] T005W19_A139PaiCod ;
      private string[] T005W19_A140EstCod ;
      private string[] T005W19_A141ProvCod ;
      private string[] T005W19_A142DisCod ;
      private string[] T005W20_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV16PaiCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22EstCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25ProvCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV14TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
   }

   public class distritos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class distritos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005W6;
        prmT005W6 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W4;
        prmT005W4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005W5;
        prmT005W5 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005W7;
        prmT005W7 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005W8;
        prmT005W8 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005W9;
        prmT005W9 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W3;
        prmT005W3 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W10;
        prmT005W10 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W11;
        prmT005W11 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W2;
        prmT005W2 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W12;
        prmT005W12 = new Object[] {
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@DisDsc",GXType.NChar,100,0) ,
        new ParDef("@DisAbr",GXType.NChar,5,0) ,
        new ParDef("@DisSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT005W13;
        prmT005W13 = new Object[] {
        new ParDef("@DisDsc",GXType.NChar,100,0) ,
        new ParDef("@DisAbr",GXType.NChar,5,0) ,
        new ParDef("@DisSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W14;
        prmT005W14 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W16;
        prmT005W16 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W17;
        prmT005W17 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W18;
        prmT005W18 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005W19;
        prmT005W19 = new Object[] {
        };
        Object[] prmT005W15;
        prmT005W15 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT005W20;
        prmT005W20 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005W2", "SELECT [DisCod], [DisDsc], [DisAbr], [DisSts], [PaiCod], [EstCod], [ProvCod] FROM [CDISTRITOS] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W3", "SELECT [DisCod], [DisDsc], [DisAbr], [DisSts], [PaiCod], [EstCod], [ProvCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W4", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W5", "SELECT [PaiCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W6", "SELECT TM1.[DisCod], T2.[PaiDsc], TM1.[DisDsc], TM1.[DisAbr], TM1.[DisSts], TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod] FROM ([CDISTRITOS] TM1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = TM1.[PaiCod]) WHERE TM1.[PaiCod] = @PaiCod and TM1.[EstCod] = @EstCod and TM1.[ProvCod] = @ProvCod and TM1.[DisCod] = @DisCod ORDER BY TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod], TM1.[DisCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005W6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W7", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W8", "SELECT [PaiCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W9", "SELECT [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W10", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE ( [PaiCod] > @PaiCod or [PaiCod] = @PaiCod and [EstCod] > @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] > @ProvCod or [ProvCod] = @ProvCod and [EstCod] = @EstCod and [PaiCod] = @PaiCod and [DisCod] > @DisCod) ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005W10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005W11", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE ( [PaiCod] < @PaiCod or [PaiCod] = @PaiCod and [EstCod] < @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] < @ProvCod or [ProvCod] = @ProvCod and [EstCod] = @EstCod and [PaiCod] = @PaiCod and [DisCod] < @DisCod) ORDER BY [PaiCod] DESC, [EstCod] DESC, [ProvCod] DESC, [DisCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005W11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005W12", "INSERT INTO [CDISTRITOS]([DisCod], [DisDsc], [DisAbr], [DisSts], [PaiCod], [EstCod], [ProvCod]) VALUES(@DisCod, @DisDsc, @DisAbr, @DisSts, @PaiCod, @EstCod, @ProvCod)", GxErrorMask.GX_NOMASK,prmT005W12)
           ,new CursorDef("T005W13", "UPDATE [CDISTRITOS] SET [DisDsc]=@DisDsc, [DisAbr]=@DisAbr, [DisSts]=@DisSts  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod", GxErrorMask.GX_NOMASK,prmT005W13)
           ,new CursorDef("T005W14", "DELETE FROM [CDISTRITOS]  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod", GxErrorMask.GX_NOMASK,prmT005W14)
           ,new CursorDef("T005W15", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W16", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005W17", "SELECT TOP 1 [AlmCod] FROM [CALMACEN] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005W18", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005W19", "SELECT [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005W19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005W20", "SELECT [PaiCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005W20,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
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
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
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
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
