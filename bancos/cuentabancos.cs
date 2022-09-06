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
namespace GeneXus.Programs.bancos {
   public class cuentabancos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A372BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A372BanCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A180MonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A378CBCueCod = GetPar( "CBCueCod");
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A378CBCueCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.cuentabancos.aspx")), "bancos.cuentabancos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.cuentabancos.aspx")))) ;
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
                  AV7BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
                  AssignAttri("", false, "AV7BanCod", StringUtil.LTrimStr( (decimal)(AV7BanCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vBANCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BanCod), "ZZZZZ9"), context));
                  AV8CBCod = GetPar( "CBCod");
                  AssignAttri("", false, "AV8CBCod", AV8CBCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCBCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8CBCod, "")), context));
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
            Form.Meta.addItem("description", "Cuenta Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cuentabancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cuentabancos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_BanCod ,
                           string aP2_CBCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7BanCod = aP1_BanCod;
         this.AV8CBCod = aP2_CBCod;
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
         GxWebStd.gx_div_start( context, divTablesplittedbancod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockbancod_Internalname, "Banco", "", "", lblTextblockbancod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_bancod.SetProperty("Caption", Combo_bancod_Caption);
         ucCombo_bancod.SetProperty("Cls", Combo_bancod_Cls);
         ucCombo_bancod.SetProperty("DataListProc", Combo_bancod_Datalistproc);
         ucCombo_bancod.SetProperty("DataListProcParametersPrefix", Combo_bancod_Datalistprocparametersprefix);
         ucCombo_bancod.SetProperty("EmptyItem", Combo_bancod_Emptyitem);
         ucCombo_bancod.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
         ucCombo_bancod.SetProperty("DropDownOptionsData", AV17BanCod_Data);
         ucCombo_bancod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_bancod_Internalname, "COMBO_BANCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBanCod_Internalname, "Codigo Banco", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanCod_Jsonclick, 0, "Attribute", "", "", "", "", edtBanCod_Visible, edtBanCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBCod_Internalname, "N° Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCod_Internalname, StringUtil.RTrim( A377CBCod), StringUtil.RTrim( context.localUtil.Format( A377CBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCod_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmoncod_Internalname, "Moneda", "", "", lblTextblockmoncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_moncod.SetProperty("Caption", Combo_moncod_Caption);
         ucCombo_moncod.SetProperty("Cls", Combo_moncod_Cls);
         ucCombo_moncod.SetProperty("DataListProc", Combo_moncod_Datalistproc);
         ucCombo_moncod.SetProperty("DataListProcParametersPrefix", Combo_moncod_Datalistprocparametersprefix);
         ucCombo_moncod.SetProperty("EmptyItem", Combo_moncod_Emptyitem);
         ucCombo_moncod.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
         ucCombo_moncod.SetProperty("DropDownOptionsData", AV23MonCod_Data);
         ucCombo_moncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_moncod_Internalname, "COMBO_MONCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonCod_Internalname, "Codigo Moneda", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", edtMonCod_Visible, edtMonCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedcbcuecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcbcuecod_Internalname, "Cuenta Contable", "", "", lblTextblockcbcuecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cbcuecod.SetProperty("Caption", Combo_cbcuecod_Caption);
         ucCombo_cbcuecod.SetProperty("Cls", Combo_cbcuecod_Cls);
         ucCombo_cbcuecod.SetProperty("DataListProc", Combo_cbcuecod_Datalistproc);
         ucCombo_cbcuecod.SetProperty("DataListProcParametersPrefix", Combo_cbcuecod_Datalistprocparametersprefix);
         ucCombo_cbcuecod.SetProperty("EmptyItem", Combo_cbcuecod_Emptyitem);
         ucCombo_cbcuecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
         ucCombo_cbcuecod.SetProperty("DropDownOptionsData", AV25CBCueCod_Data);
         ucCombo_cbcuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cbcuecod_Internalname, "COMBO_CBCUECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBCueCod_Internalname, "CBCue Cod", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCueCod_Internalname, StringUtil.RTrim( A378CBCueCod), StringUtil.RTrim( context.localUtil.Format( A378CBCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCueCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCBCueCod_Visible, edtCBCueCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBCheqInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBCheqInicio_Internalname, "Cheque Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCheqInicio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A490CBCheqInicio), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBCheqInicio_Enabled!=0) ? context.localUtil.Format( (decimal)(A490CBCheqInicio), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A490CBCheqInicio), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCheqInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCheqInicio_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBCheqFinal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBCheqFinal_Internalname, "Cheque Final", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCheqFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A489CBCheqFinal), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBCheqFinal_Enabled!=0) ? context.localUtil.Format( (decimal)(A489CBCheqFinal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A489CBCheqFinal), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCheqFinal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCheqFinal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBCheqActual_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBCheqActual_Internalname, "Cheque Actual", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCheqActual_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488CBCheqActual), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBCheqActual_Enabled!=0) ? context.localUtil.Format( (decimal)(A488CBCheqActual), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A488CBCheqActual), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCheqActual_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCheqActual_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A504CBSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A504CBSts), "9") : context.localUtil.Format( (decimal)(A504CBSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\CuentaBancos.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_bancod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombobancod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ComboBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombobancod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22ComboBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV22ComboBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombobancod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombobancod_Visible, edtavCombobancod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_moncod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombomoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ComboMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombomoncod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24ComboMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV24ComboMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomoncod_Visible, edtavCombomoncod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cbcuecod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocbcuecod_Internalname, StringUtil.RTrim( AV26ComboCBCueCod), StringUtil.RTrim( context.localUtil.Format( AV26ComboCBCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocbcuecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocbcuecod_Visible, edtavCombocbcuecod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCBCueDsc_Internalname, StringUtil.RTrim( A491CBCueDsc), StringUtil.RTrim( context.localUtil.Format( A491CBCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", edtCBCueDsc_Visible, edtCBCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\CuentaBancos.htm");
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
         E116B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV18DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vBANCOD_DATA"), AV17BanCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vMONCOD_DATA"), AV23MonCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCBCUECOD_DATA"), AV25CBCueCod_Data);
               /* Read saved values. */
               Z372BanCod = (int)(context.localUtil.CToN( cgiGet( "Z372BanCod"), ".", ","));
               Z377CBCod = cgiGet( "Z377CBCod");
               Z504CBSts = (short)(context.localUtil.CToN( cgiGet( "Z504CBSts"), ".", ","));
               Z490CBCheqInicio = (long)(context.localUtil.CToN( cgiGet( "Z490CBCheqInicio"), ".", ","));
               Z489CBCheqFinal = (long)(context.localUtil.CToN( cgiGet( "Z489CBCheqFinal"), ".", ","));
               Z488CBCheqActual = (long)(context.localUtil.CToN( cgiGet( "Z488CBCheqActual"), ".", ","));
               Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
               Z378CBCueCod = cgiGet( "Z378CBCueCod");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N180MonCod = (int)(context.localUtil.CToN( cgiGet( "N180MonCod"), ".", ","));
               N378CBCueCod = cgiGet( "N378CBCueCod");
               AV7BanCod = (int)(context.localUtil.CToN( cgiGet( "vBANCOD"), ".", ","));
               AV8CBCod = cgiGet( "vCBCOD");
               AV14Insert_MonCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_MONCOD"), ".", ","));
               AV15Insert_CBCueCod = cgiGet( "vINSERT_CBCUECOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A482BanDsc = cgiGet( "BANDSC");
               AV31Pgmname = cgiGet( "vPGMNAME");
               Combo_bancod_Objectcall = cgiGet( "COMBO_BANCOD_Objectcall");
               Combo_bancod_Class = cgiGet( "COMBO_BANCOD_Class");
               Combo_bancod_Icontype = cgiGet( "COMBO_BANCOD_Icontype");
               Combo_bancod_Icon = cgiGet( "COMBO_BANCOD_Icon");
               Combo_bancod_Caption = cgiGet( "COMBO_BANCOD_Caption");
               Combo_bancod_Tooltip = cgiGet( "COMBO_BANCOD_Tooltip");
               Combo_bancod_Cls = cgiGet( "COMBO_BANCOD_Cls");
               Combo_bancod_Selectedvalue_set = cgiGet( "COMBO_BANCOD_Selectedvalue_set");
               Combo_bancod_Selectedvalue_get = cgiGet( "COMBO_BANCOD_Selectedvalue_get");
               Combo_bancod_Selectedtext_set = cgiGet( "COMBO_BANCOD_Selectedtext_set");
               Combo_bancod_Selectedtext_get = cgiGet( "COMBO_BANCOD_Selectedtext_get");
               Combo_bancod_Gamoauthtoken = cgiGet( "COMBO_BANCOD_Gamoauthtoken");
               Combo_bancod_Ddointernalname = cgiGet( "COMBO_BANCOD_Ddointernalname");
               Combo_bancod_Titlecontrolalign = cgiGet( "COMBO_BANCOD_Titlecontrolalign");
               Combo_bancod_Dropdownoptionstype = cgiGet( "COMBO_BANCOD_Dropdownoptionstype");
               Combo_bancod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Enabled"));
               Combo_bancod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Visible"));
               Combo_bancod_Titlecontrolidtoreplace = cgiGet( "COMBO_BANCOD_Titlecontrolidtoreplace");
               Combo_bancod_Datalisttype = cgiGet( "COMBO_BANCOD_Datalisttype");
               Combo_bancod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Allowmultipleselection"));
               Combo_bancod_Datalistfixedvalues = cgiGet( "COMBO_BANCOD_Datalistfixedvalues");
               Combo_bancod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Isgriditem"));
               Combo_bancod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Hasdescription"));
               Combo_bancod_Datalistproc = cgiGet( "COMBO_BANCOD_Datalistproc");
               Combo_bancod_Datalistprocparametersprefix = cgiGet( "COMBO_BANCOD_Datalistprocparametersprefix");
               Combo_bancod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_BANCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_bancod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Includeonlyselectedoption"));
               Combo_bancod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Includeselectalloption"));
               Combo_bancod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Emptyitem"));
               Combo_bancod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_BANCOD_Includeaddnewoption"));
               Combo_bancod_Htmltemplate = cgiGet( "COMBO_BANCOD_Htmltemplate");
               Combo_bancod_Multiplevaluestype = cgiGet( "COMBO_BANCOD_Multiplevaluestype");
               Combo_bancod_Loadingdata = cgiGet( "COMBO_BANCOD_Loadingdata");
               Combo_bancod_Noresultsfound = cgiGet( "COMBO_BANCOD_Noresultsfound");
               Combo_bancod_Emptyitemtext = cgiGet( "COMBO_BANCOD_Emptyitemtext");
               Combo_bancod_Onlyselectedvalues = cgiGet( "COMBO_BANCOD_Onlyselectedvalues");
               Combo_bancod_Selectalltext = cgiGet( "COMBO_BANCOD_Selectalltext");
               Combo_bancod_Multiplevaluesseparator = cgiGet( "COMBO_BANCOD_Multiplevaluesseparator");
               Combo_bancod_Addnewoptiontext = cgiGet( "COMBO_BANCOD_Addnewoptiontext");
               Combo_bancod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_BANCOD_Gxcontroltype"), ".", ","));
               Combo_moncod_Objectcall = cgiGet( "COMBO_MONCOD_Objectcall");
               Combo_moncod_Class = cgiGet( "COMBO_MONCOD_Class");
               Combo_moncod_Icontype = cgiGet( "COMBO_MONCOD_Icontype");
               Combo_moncod_Icon = cgiGet( "COMBO_MONCOD_Icon");
               Combo_moncod_Caption = cgiGet( "COMBO_MONCOD_Caption");
               Combo_moncod_Tooltip = cgiGet( "COMBO_MONCOD_Tooltip");
               Combo_moncod_Cls = cgiGet( "COMBO_MONCOD_Cls");
               Combo_moncod_Selectedvalue_set = cgiGet( "COMBO_MONCOD_Selectedvalue_set");
               Combo_moncod_Selectedvalue_get = cgiGet( "COMBO_MONCOD_Selectedvalue_get");
               Combo_moncod_Selectedtext_set = cgiGet( "COMBO_MONCOD_Selectedtext_set");
               Combo_moncod_Selectedtext_get = cgiGet( "COMBO_MONCOD_Selectedtext_get");
               Combo_moncod_Gamoauthtoken = cgiGet( "COMBO_MONCOD_Gamoauthtoken");
               Combo_moncod_Ddointernalname = cgiGet( "COMBO_MONCOD_Ddointernalname");
               Combo_moncod_Titlecontrolalign = cgiGet( "COMBO_MONCOD_Titlecontrolalign");
               Combo_moncod_Dropdownoptionstype = cgiGet( "COMBO_MONCOD_Dropdownoptionstype");
               Combo_moncod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Enabled"));
               Combo_moncod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Visible"));
               Combo_moncod_Titlecontrolidtoreplace = cgiGet( "COMBO_MONCOD_Titlecontrolidtoreplace");
               Combo_moncod_Datalisttype = cgiGet( "COMBO_MONCOD_Datalisttype");
               Combo_moncod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Allowmultipleselection"));
               Combo_moncod_Datalistfixedvalues = cgiGet( "COMBO_MONCOD_Datalistfixedvalues");
               Combo_moncod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Isgriditem"));
               Combo_moncod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Hasdescription"));
               Combo_moncod_Datalistproc = cgiGet( "COMBO_MONCOD_Datalistproc");
               Combo_moncod_Datalistprocparametersprefix = cgiGet( "COMBO_MONCOD_Datalistprocparametersprefix");
               Combo_moncod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_MONCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_moncod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Includeonlyselectedoption"));
               Combo_moncod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Includeselectalloption"));
               Combo_moncod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Emptyitem"));
               Combo_moncod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MONCOD_Includeaddnewoption"));
               Combo_moncod_Htmltemplate = cgiGet( "COMBO_MONCOD_Htmltemplate");
               Combo_moncod_Multiplevaluestype = cgiGet( "COMBO_MONCOD_Multiplevaluestype");
               Combo_moncod_Loadingdata = cgiGet( "COMBO_MONCOD_Loadingdata");
               Combo_moncod_Noresultsfound = cgiGet( "COMBO_MONCOD_Noresultsfound");
               Combo_moncod_Emptyitemtext = cgiGet( "COMBO_MONCOD_Emptyitemtext");
               Combo_moncod_Onlyselectedvalues = cgiGet( "COMBO_MONCOD_Onlyselectedvalues");
               Combo_moncod_Selectalltext = cgiGet( "COMBO_MONCOD_Selectalltext");
               Combo_moncod_Multiplevaluesseparator = cgiGet( "COMBO_MONCOD_Multiplevaluesseparator");
               Combo_moncod_Addnewoptiontext = cgiGet( "COMBO_MONCOD_Addnewoptiontext");
               Combo_moncod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_MONCOD_Gxcontroltype"), ".", ","));
               Combo_cbcuecod_Objectcall = cgiGet( "COMBO_CBCUECOD_Objectcall");
               Combo_cbcuecod_Class = cgiGet( "COMBO_CBCUECOD_Class");
               Combo_cbcuecod_Icontype = cgiGet( "COMBO_CBCUECOD_Icontype");
               Combo_cbcuecod_Icon = cgiGet( "COMBO_CBCUECOD_Icon");
               Combo_cbcuecod_Caption = cgiGet( "COMBO_CBCUECOD_Caption");
               Combo_cbcuecod_Tooltip = cgiGet( "COMBO_CBCUECOD_Tooltip");
               Combo_cbcuecod_Cls = cgiGet( "COMBO_CBCUECOD_Cls");
               Combo_cbcuecod_Selectedvalue_set = cgiGet( "COMBO_CBCUECOD_Selectedvalue_set");
               Combo_cbcuecod_Selectedvalue_get = cgiGet( "COMBO_CBCUECOD_Selectedvalue_get");
               Combo_cbcuecod_Selectedtext_set = cgiGet( "COMBO_CBCUECOD_Selectedtext_set");
               Combo_cbcuecod_Selectedtext_get = cgiGet( "COMBO_CBCUECOD_Selectedtext_get");
               Combo_cbcuecod_Gamoauthtoken = cgiGet( "COMBO_CBCUECOD_Gamoauthtoken");
               Combo_cbcuecod_Ddointernalname = cgiGet( "COMBO_CBCUECOD_Ddointernalname");
               Combo_cbcuecod_Titlecontrolalign = cgiGet( "COMBO_CBCUECOD_Titlecontrolalign");
               Combo_cbcuecod_Dropdownoptionstype = cgiGet( "COMBO_CBCUECOD_Dropdownoptionstype");
               Combo_cbcuecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Enabled"));
               Combo_cbcuecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Visible"));
               Combo_cbcuecod_Titlecontrolidtoreplace = cgiGet( "COMBO_CBCUECOD_Titlecontrolidtoreplace");
               Combo_cbcuecod_Datalisttype = cgiGet( "COMBO_CBCUECOD_Datalisttype");
               Combo_cbcuecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Allowmultipleselection"));
               Combo_cbcuecod_Datalistfixedvalues = cgiGet( "COMBO_CBCUECOD_Datalistfixedvalues");
               Combo_cbcuecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Isgriditem"));
               Combo_cbcuecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Hasdescription"));
               Combo_cbcuecod_Datalistproc = cgiGet( "COMBO_CBCUECOD_Datalistproc");
               Combo_cbcuecod_Datalistprocparametersprefix = cgiGet( "COMBO_CBCUECOD_Datalistprocparametersprefix");
               Combo_cbcuecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBCUECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cbcuecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Includeonlyselectedoption"));
               Combo_cbcuecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Includeselectalloption"));
               Combo_cbcuecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Emptyitem"));
               Combo_cbcuecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CBCUECOD_Includeaddnewoption"));
               Combo_cbcuecod_Htmltemplate = cgiGet( "COMBO_CBCUECOD_Htmltemplate");
               Combo_cbcuecod_Multiplevaluestype = cgiGet( "COMBO_CBCUECOD_Multiplevaluestype");
               Combo_cbcuecod_Loadingdata = cgiGet( "COMBO_CBCUECOD_Loadingdata");
               Combo_cbcuecod_Noresultsfound = cgiGet( "COMBO_CBCUECOD_Noresultsfound");
               Combo_cbcuecod_Emptyitemtext = cgiGet( "COMBO_CBCUECOD_Emptyitemtext");
               Combo_cbcuecod_Onlyselectedvalues = cgiGet( "COMBO_CBCUECOD_Onlyselectedvalues");
               Combo_cbcuecod_Selectalltext = cgiGet( "COMBO_CBCUECOD_Selectalltext");
               Combo_cbcuecod_Multiplevaluesseparator = cgiGet( "COMBO_CBCUECOD_Multiplevaluesseparator");
               Combo_cbcuecod_Addnewoptiontext = cgiGet( "COMBO_CBCUECOD_Addnewoptiontext");
               Combo_cbcuecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBCUECOD_Gxcontroltype"), ".", ","));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A372BanCod = 0;
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               }
               else
               {
                  A372BanCod = (int)(context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ","));
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               }
               A377CBCod = cgiGet( edtCBCod_Internalname);
               AssignAttri("", false, "A377CBCod", A377CBCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A180MonCod = 0;
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               }
               else
               {
                  A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               }
               A378CBCueCod = cgiGet( edtCBCueCod_Internalname);
               AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCBCheqInicio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBCheqInicio_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBCHEQINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtCBCheqInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A490CBCheqInicio = 0;
                  AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
               }
               else
               {
                  A490CBCheqInicio = (long)(context.localUtil.CToN( cgiGet( edtCBCheqInicio_Internalname), ".", ","));
                  AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCBCheqFinal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBCheqFinal_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBCHEQFINAL");
                  AnyError = 1;
                  GX_FocusControl = edtCBCheqFinal_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A489CBCheqFinal = 0;
                  AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
               }
               else
               {
                  A489CBCheqFinal = (long)(context.localUtil.CToN( cgiGet( edtCBCheqFinal_Internalname), ".", ","));
                  AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCBCheqActual_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBCheqActual_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBCHEQACTUAL");
                  AnyError = 1;
                  GX_FocusControl = edtCBCheqActual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A488CBCheqActual = 0;
                  AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
               }
               else
               {
                  A488CBCheqActual = (long)(context.localUtil.CToN( cgiGet( edtCBCheqActual_Internalname), ".", ","));
                  AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBSTS");
                  AnyError = 1;
                  GX_FocusControl = edtCBSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A504CBSts = 0;
                  AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
               }
               else
               {
                  A504CBSts = (short)(context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ","));
                  AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
               }
               AV22ComboBanCod = (int)(context.localUtil.CToN( cgiGet( edtavCombobancod_Internalname), ".", ","));
               AssignAttri("", false, "AV22ComboBanCod", StringUtil.LTrimStr( (decimal)(AV22ComboBanCod), 6, 0));
               AV24ComboMonCod = (int)(context.localUtil.CToN( cgiGet( edtavCombomoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV24ComboMonCod", StringUtil.LTrimStr( (decimal)(AV24ComboMonCod), 6, 0));
               AV26ComboCBCueCod = cgiGet( edtavCombocbcuecod_Internalname);
               AssignAttri("", false, "AV26ComboCBCueCod", AV26ComboCBCueCod);
               A491CBCueDsc = cgiGet( edtCBCueDsc_Internalname);
               AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CuentaBancos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("bancos\\cuentabancos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A372BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
                  A377CBCod = GetPar( "CBCod");
                  AssignAttri("", false, "A377CBCod", A377CBCod);
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
                     sMode174 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode174;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound174 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "BANCOD");
                        AnyError = 1;
                        GX_FocusControl = edtBanCod_Internalname;
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
                           E116B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126B2 ();
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
            E126B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6B174( ) ;
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
            DisableAttributes6B174( ) ;
         }
         AssignProp("", false, edtavCombobancod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombobancod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombomoncod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomoncod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocbcuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbcuecod_Enabled), 5, 0), true);
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

      protected void CONFIRM_6B0( )
      {
         BeforeValidate6B174( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6B174( ) ;
            }
            else
            {
               CheckExtendedTable6B174( ) ;
               CloseExtendedTableCursors6B174( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6B0( )
      {
      }

      protected void E116B2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV18DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV18DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtCBCueCod_Visible = 0;
         AssignProp("", false, edtCBCueCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCBCueCod_Visible), 5, 0), true);
         AV26ComboCBCueCod = "";
         AssignAttri("", false, "AV26ComboCBCueCod", AV26ComboCBCueCod);
         edtavCombocbcuecod_Visible = 0;
         AssignProp("", false, edtavCombocbcuecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocbcuecod_Visible), 5, 0), true);
         edtMonCod_Visible = 0;
         AssignProp("", false, edtMonCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMonCod_Visible), 5, 0), true);
         AV24ComboMonCod = 0;
         AssignAttri("", false, "AV24ComboMonCod", StringUtil.LTrimStr( (decimal)(AV24ComboMonCod), 6, 0));
         edtavCombomoncod_Visible = 0;
         AssignProp("", false, edtavCombomoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomoncod_Visible), 5, 0), true);
         edtBanCod_Visible = 0;
         AssignProp("", false, edtBanCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtBanCod_Visible), 5, 0), true);
         AV22ComboBanCod = 0;
         AssignAttri("", false, "AV22ComboBanCod", StringUtil.LTrimStr( (decimal)(AV22ComboBanCod), 6, 0));
         edtavCombobancod_Visible = 0;
         AssignProp("", false, edtavCombobancod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombobancod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOBANCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOMONCOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCBCUECOD' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "MonCod") == 0 )
               {
                  AV14Insert_MonCod = (int)(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_MonCod", StringUtil.LTrimStr( (decimal)(AV14Insert_MonCod), 6, 0));
                  if ( ! (0==AV14Insert_MonCod) )
                  {
                     AV24ComboMonCod = AV14Insert_MonCod;
                     AssignAttri("", false, "AV24ComboMonCod", StringUtil.LTrimStr( (decimal)(AV24ComboMonCod), 6, 0));
                     Combo_moncod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV24ComboMonCod), 6, 0));
                     ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedValue_set", Combo_moncod_Selectedvalue_set);
                     GXt_char2 = AV21Combo_DataJson;
                     new GeneXus.Programs.bancos.cuentabancosloaddvcombo(context ).execute(  "MonCod",  "GET",  false,  AV7BanCod,  AV8CBCod,  AV16TrnContextAtt.gxTpr_Attributevalue, out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
                     AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
                     AV21Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
                     Combo_moncod_Selectedtext_set = AV20ComboSelectedText;
                     ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedText_set", Combo_moncod_Selectedtext_set);
                     Combo_moncod_Enabled = false;
                     ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_moncod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "CBCueCod") == 0 )
               {
                  AV15Insert_CBCueCod = AV16TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV15Insert_CBCueCod", AV15Insert_CBCueCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_CBCueCod)) )
                  {
                     AV26ComboCBCueCod = AV15Insert_CBCueCod;
                     AssignAttri("", false, "AV26ComboCBCueCod", AV26ComboCBCueCod);
                     Combo_cbcuecod_Selectedvalue_set = AV26ComboCBCueCod;
                     ucCombo_cbcuecod.SendProperty(context, "", false, Combo_cbcuecod_Internalname, "SelectedValue_set", Combo_cbcuecod_Selectedvalue_set);
                     GXt_char2 = AV21Combo_DataJson;
                     new GeneXus.Programs.bancos.cuentabancosloaddvcombo(context ).execute(  "CBCueCod",  "GET",  false,  AV7BanCod,  AV8CBCod,  AV16TrnContextAtt.gxTpr_Attributevalue, out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
                     AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
                     AV21Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
                     Combo_cbcuecod_Selectedtext_set = AV20ComboSelectedText;
                     ucCombo_cbcuecod.SendProperty(context, "", false, Combo_cbcuecod_Internalname, "SelectedText_set", Combo_cbcuecod_Selectedtext_set);
                     Combo_cbcuecod_Enabled = false;
                     ucCombo_cbcuecod.SendProperty(context, "", false, Combo_cbcuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbcuecod_Enabled));
                  }
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
         edtCBCueDsc_Visible = 0;
         AssignProp("", false, edtCBCueDsc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCBCueDsc_Visible), 5, 0), true);
      }

      protected void E126B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV28SGAuDocGls = "Cuenta de Banco N° " + StringUtil.Trim( A482BanDsc) + " " + StringUtil.Trim( A377CBCod);
            AV29Codigo = A377CBCod;
            GXt_char2 = "TES";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV28SGAuDocGls, ref  AV29Codigo, ref  AV29Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("bancos.cuentabancosww.aspx") );
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
         /* 'LOADCOMBOCBCUECOD' Routine */
         returnInSub = false;
         GXt_char4 = AV21Combo_DataJson;
         new GeneXus.Programs.bancos.cuentabancosloaddvcombo(context ).execute(  "CBCueCod",  Gx_mode,  false,  AV7BanCod,  AV8CBCod,  "", out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
         AV21Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
         Combo_cbcuecod_Selectedvalue_set = AV19ComboSelectedValue;
         ucCombo_cbcuecod.SendProperty(context, "", false, Combo_cbcuecod_Internalname, "SelectedValue_set", Combo_cbcuecod_Selectedvalue_set);
         Combo_cbcuecod_Selectedtext_set = AV20ComboSelectedText;
         ucCombo_cbcuecod.SendProperty(context, "", false, Combo_cbcuecod_Internalname, "SelectedText_set", Combo_cbcuecod_Selectedtext_set);
         AV26ComboCBCueCod = AV19ComboSelectedValue;
         AssignAttri("", false, "AV26ComboCBCueCod", AV26ComboCBCueCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cbcuecod_Enabled = false;
            ucCombo_cbcuecod.SendProperty(context, "", false, Combo_cbcuecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbcuecod_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMONCOD' Routine */
         returnInSub = false;
         GXt_char4 = AV21Combo_DataJson;
         new GeneXus.Programs.bancos.cuentabancosloaddvcombo(context ).execute(  "MonCod",  Gx_mode,  false,  AV7BanCod,  AV8CBCod,  "", out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
         AV21Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
         Combo_moncod_Selectedvalue_set = AV19ComboSelectedValue;
         ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedValue_set", Combo_moncod_Selectedvalue_set);
         Combo_moncod_Selectedtext_set = AV20ComboSelectedText;
         ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "SelectedText_set", Combo_moncod_Selectedtext_set);
         AV24ComboMonCod = (int)(NumberUtil.Val( AV19ComboSelectedValue, "."));
         AssignAttri("", false, "AV24ComboMonCod", StringUtil.LTrimStr( (decimal)(AV24ComboMonCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_moncod_Enabled = false;
            ucCombo_moncod.SendProperty(context, "", false, Combo_moncod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_moncod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOBANCOD' Routine */
         returnInSub = false;
         GXt_char4 = AV21Combo_DataJson;
         new GeneXus.Programs.bancos.cuentabancosloaddvcombo(context ).execute(  "BanCod",  Gx_mode,  false,  AV7BanCod,  AV8CBCod,  "", out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
         AV21Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
         Combo_bancod_Selectedvalue_set = AV19ComboSelectedValue;
         ucCombo_bancod.SendProperty(context, "", false, Combo_bancod_Internalname, "SelectedValue_set", Combo_bancod_Selectedvalue_set);
         Combo_bancod_Selectedtext_set = AV20ComboSelectedText;
         ucCombo_bancod.SendProperty(context, "", false, Combo_bancod_Internalname, "SelectedText_set", Combo_bancod_Selectedtext_set);
         AV22ComboBanCod = (int)(NumberUtil.Val( AV19ComboSelectedValue, "."));
         AssignAttri("", false, "AV22ComboBanCod", StringUtil.LTrimStr( (decimal)(AV22ComboBanCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7BanCod) )
         {
            Combo_bancod_Enabled = false;
            ucCombo_bancod.SendProperty(context, "", false, Combo_bancod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_bancod_Enabled));
         }
      }

      protected void ZM6B174( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z504CBSts = T006B3_A504CBSts[0];
               Z490CBCheqInicio = T006B3_A490CBCheqInicio[0];
               Z489CBCheqFinal = T006B3_A489CBCheqFinal[0];
               Z488CBCheqActual = T006B3_A488CBCheqActual[0];
               Z180MonCod = T006B3_A180MonCod[0];
               Z378CBCueCod = T006B3_A378CBCueCod[0];
            }
            else
            {
               Z504CBSts = A504CBSts;
               Z490CBCheqInicio = A490CBCheqInicio;
               Z489CBCheqFinal = A489CBCheqFinal;
               Z488CBCheqActual = A488CBCheqActual;
               Z180MonCod = A180MonCod;
               Z378CBCueCod = A378CBCueCod;
            }
         }
         if ( GX_JID == -20 )
         {
            Z377CBCod = A377CBCod;
            Z504CBSts = A504CBSts;
            Z490CBCheqInicio = A490CBCheqInicio;
            Z489CBCheqFinal = A489CBCheqFinal;
            Z488CBCheqActual = A488CBCheqActual;
            Z372BanCod = A372BanCod;
            Z180MonCod = A180MonCod;
            Z378CBCueCod = A378CBCueCod;
            Z482BanDsc = A482BanDsc;
            Z491CBCueDsc = A491CBCueDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Bancos.CuentaBancos";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7BanCod) )
         {
            edtBanCod_Enabled = 0;
            AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         }
         else
         {
            edtBanCod_Enabled = 1;
            AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7BanCod) )
         {
            edtBanCod_Enabled = 0;
            AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CBCod)) )
         {
            A377CBCod = AV8CBCod;
            AssignAttri("", false, "A377CBCod", A377CBCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CBCod)) )
         {
            edtCBCod_Enabled = 0;
            AssignProp("", false, edtCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCBCod_Enabled = 1;
            AssignProp("", false, edtCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CBCod)) )
         {
            edtCBCod_Enabled = 0;
            AssignProp("", false, edtCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7BanCod) )
         {
            A372BanCod = AV7BanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
         else
         {
            A372BanCod = AV22ComboBanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_MonCod) )
         {
            edtMonCod_Enabled = 0;
            AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         }
         else
         {
            edtMonCod_Enabled = 1;
            AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_CBCueCod)) )
         {
            edtCBCueCod_Enabled = 0;
            AssignProp("", false, edtCBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCueCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCBCueCod_Enabled = 1;
            AssignProp("", false, edtCBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCueCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_MonCod) )
         {
            A180MonCod = AV14Insert_MonCod;
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
         else
         {
            A180MonCod = AV24ComboMonCod;
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_CBCueCod)) )
         {
            A378CBCueCod = AV15Insert_CBCueCod;
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
         }
         else
         {
            A378CBCueCod = AV26ComboCBCueCod;
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
         }
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
         if ( IsIns( )  && (0==A504CBSts) && ( Gx_BScreen == 0 ) )
         {
            A504CBSts = 1;
            AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T006B4 */
            pr_default.execute(2, new Object[] {A372BanCod});
            A482BanDsc = T006B4_A482BanDsc[0];
            pr_default.close(2);
            /* Using cursor T006B6 */
            pr_default.execute(4, new Object[] {A378CBCueCod});
            A491CBCueDsc = T006B6_A491CBCueDsc[0];
            AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
            pr_default.close(4);
         }
      }

      protected void Load6B174( )
      {
         /* Using cursor T006B7 */
         pr_default.execute(5, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound174 = 1;
            A482BanDsc = T006B7_A482BanDsc[0];
            A504CBSts = T006B7_A504CBSts[0];
            AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
            A490CBCheqInicio = T006B7_A490CBCheqInicio[0];
            AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
            A489CBCheqFinal = T006B7_A489CBCheqFinal[0];
            AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
            A488CBCheqActual = T006B7_A488CBCheqActual[0];
            AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
            A491CBCueDsc = T006B7_A491CBCueDsc[0];
            AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
            A180MonCod = T006B7_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A378CBCueCod = T006B7_A378CBCueCod[0];
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            ZM6B174( -20) ;
         }
         pr_default.close(5);
         OnLoadActions6B174( ) ;
      }

      protected void OnLoadActions6B174( )
      {
      }

      protected void CheckExtendedTable6B174( )
      {
         nIsDirty_174 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T006B4 */
         pr_default.execute(2, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A482BanDsc = T006B4_A482BanDsc[0];
         pr_default.close(2);
         if ( (0==A372BanCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo Banco", "", "", "", "", "", "", "", ""), 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A377CBCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta Banco", "", "", "", "", "", "", "", ""), 1, "CBCOD");
            AnyError = 1;
            GX_FocusControl = edtCBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006B5 */
         pr_default.execute(3, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( (0==A180MonCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo Moneda", "", "", "", "", "", "", "", ""), 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006B6 */
         pr_default.execute(4, new Object[] {A378CBCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A491CBCueDsc = T006B6_A491CBCueDsc[0];
         AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
         pr_default.close(4);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A378CBCueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "CBCue Cod", "", "", "", "", "", "", "", ""), 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6B174( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( int A372BanCod )
      {
         /* Using cursor T006B8 */
         pr_default.execute(6, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A482BanDsc = T006B8_A482BanDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A482BanDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_22( int A180MonCod )
      {
         /* Using cursor T006B9 */
         pr_default.execute(7, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_23( string A378CBCueCod )
      {
         /* Using cursor T006B10 */
         pr_default.execute(8, new Object[] {A378CBCueCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A491CBCueDsc = T006B10_A491CBCueDsc[0];
         AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A491CBCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey6B174( )
      {
         /* Using cursor T006B11 */
         pr_default.execute(9, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound174 = 1;
         }
         else
         {
            RcdFound174 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006B3 */
         pr_default.execute(1, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6B174( 20) ;
            RcdFound174 = 1;
            A377CBCod = T006B3_A377CBCod[0];
            AssignAttri("", false, "A377CBCod", A377CBCod);
            A504CBSts = T006B3_A504CBSts[0];
            AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
            A490CBCheqInicio = T006B3_A490CBCheqInicio[0];
            AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
            A489CBCheqFinal = T006B3_A489CBCheqFinal[0];
            AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
            A488CBCheqActual = T006B3_A488CBCheqActual[0];
            AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
            A372BanCod = T006B3_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A180MonCod = T006B3_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A378CBCueCod = T006B3_A378CBCueCod[0];
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            Z372BanCod = A372BanCod;
            Z377CBCod = A377CBCod;
            sMode174 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6B174( ) ;
            if ( AnyError == 1 )
            {
               RcdFound174 = 0;
               InitializeNonKey6B174( ) ;
            }
            Gx_mode = sMode174;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound174 = 0;
            InitializeNonKey6B174( ) ;
            sMode174 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode174;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6B174( ) ;
         if ( RcdFound174 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound174 = 0;
         /* Using cursor T006B12 */
         pr_default.execute(10, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T006B12_A372BanCod[0] < A372BanCod ) || ( T006B12_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T006B12_A377CBCod[0], A377CBCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T006B12_A372BanCod[0] > A372BanCod ) || ( T006B12_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T006B12_A377CBCod[0], A377CBCod) > 0 ) ) )
            {
               A372BanCod = T006B12_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               A377CBCod = T006B12_A377CBCod[0];
               AssignAttri("", false, "A377CBCod", A377CBCod);
               RcdFound174 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound174 = 0;
         /* Using cursor T006B13 */
         pr_default.execute(11, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T006B13_A372BanCod[0] > A372BanCod ) || ( T006B13_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T006B13_A377CBCod[0], A377CBCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T006B13_A372BanCod[0] < A372BanCod ) || ( T006B13_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T006B13_A377CBCod[0], A377CBCod) < 0 ) ) )
            {
               A372BanCod = T006B13_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               A377CBCod = T006B13_A377CBCod[0];
               AssignAttri("", false, "A377CBCod", A377CBCod);
               RcdFound174 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6B174( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6B174( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound174 == 1 )
            {
               if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
               {
                  A372BanCod = Z372BanCod;
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
                  A377CBCod = Z377CBCod;
                  AssignAttri("", false, "A377CBCod", A377CBCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6B174( ) ;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6B174( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6B174( ) ;
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
         if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
         {
            A372BanCod = Z372BanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A377CBCod = Z377CBCod;
            AssignAttri("", false, "A377CBCod", A377CBCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6B174( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006B2 */
            pr_default.execute(0, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCUENTABANCO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z504CBSts != T006B2_A504CBSts[0] ) || ( Z490CBCheqInicio != T006B2_A490CBCheqInicio[0] ) || ( Z489CBCheqFinal != T006B2_A489CBCheqFinal[0] ) || ( Z488CBCheqActual != T006B2_A488CBCheqActual[0] ) || ( Z180MonCod != T006B2_A180MonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z378CBCueCod, T006B2_A378CBCueCod[0]) != 0 ) )
            {
               if ( Z504CBSts != T006B2_A504CBSts[0] )
               {
                  GXUtil.WriteLog("bancos.cuentabancos:[seudo value changed for attri]"+"CBSts");
                  GXUtil.WriteLogRaw("Old: ",Z504CBSts);
                  GXUtil.WriteLogRaw("Current: ",T006B2_A504CBSts[0]);
               }
               if ( Z490CBCheqInicio != T006B2_A490CBCheqInicio[0] )
               {
                  GXUtil.WriteLog("bancos.cuentabancos:[seudo value changed for attri]"+"CBCheqInicio");
                  GXUtil.WriteLogRaw("Old: ",Z490CBCheqInicio);
                  GXUtil.WriteLogRaw("Current: ",T006B2_A490CBCheqInicio[0]);
               }
               if ( Z489CBCheqFinal != T006B2_A489CBCheqFinal[0] )
               {
                  GXUtil.WriteLog("bancos.cuentabancos:[seudo value changed for attri]"+"CBCheqFinal");
                  GXUtil.WriteLogRaw("Old: ",Z489CBCheqFinal);
                  GXUtil.WriteLogRaw("Current: ",T006B2_A489CBCheqFinal[0]);
               }
               if ( Z488CBCheqActual != T006B2_A488CBCheqActual[0] )
               {
                  GXUtil.WriteLog("bancos.cuentabancos:[seudo value changed for attri]"+"CBCheqActual");
                  GXUtil.WriteLogRaw("Old: ",Z488CBCheqActual);
                  GXUtil.WriteLogRaw("Current: ",T006B2_A488CBCheqActual[0]);
               }
               if ( Z180MonCod != T006B2_A180MonCod[0] )
               {
                  GXUtil.WriteLog("bancos.cuentabancos:[seudo value changed for attri]"+"MonCod");
                  GXUtil.WriteLogRaw("Old: ",Z180MonCod);
                  GXUtil.WriteLogRaw("Current: ",T006B2_A180MonCod[0]);
               }
               if ( StringUtil.StrCmp(Z378CBCueCod, T006B2_A378CBCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.cuentabancos:[seudo value changed for attri]"+"CBCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z378CBCueCod);
                  GXUtil.WriteLogRaw("Current: ",T006B2_A378CBCueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCUENTABANCO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6B174( )
      {
         BeforeValidate6B174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6B174( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6B174( 0) ;
            CheckOptimisticConcurrency6B174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6B174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6B174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006B14 */
                     pr_default.execute(12, new Object[] {A377CBCod, A504CBSts, A490CBCheqInicio, A489CBCheqFinal, A488CBCheqActual, A372BanCod, A180MonCod, A378CBCueCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCUENTABANCO");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption6B0( ) ;
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
               Load6B174( ) ;
            }
            EndLevel6B174( ) ;
         }
         CloseExtendedTableCursors6B174( ) ;
      }

      protected void Update6B174( )
      {
         BeforeValidate6B174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6B174( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6B174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6B174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6B174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006B15 */
                     pr_default.execute(13, new Object[] {A504CBSts, A490CBCheqInicio, A489CBCheqFinal, A488CBCheqActual, A180MonCod, A378CBCueCod, A372BanCod, A377CBCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCUENTABANCO");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCUENTABANCO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6B174( ) ;
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
            EndLevel6B174( ) ;
         }
         CloseExtendedTableCursors6B174( ) ;
      }

      protected void DeferredUpdate6B174( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6B174( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6B174( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6B174( ) ;
            AfterConfirm6B174( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6B174( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006B16 */
                  pr_default.execute(14, new Object[] {A372BanCod, A377CBCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCUENTABANCO");
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
         sMode174 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6B174( ) ;
         Gx_mode = sMode174;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6B174( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006B17 */
            pr_default.execute(15, new Object[] {A372BanCod});
            A482BanDsc = T006B17_A482BanDsc[0];
            pr_default.close(15);
            /* Using cursor T006B18 */
            pr_default.execute(16, new Object[] {A378CBCueCod});
            A491CBCueDsc = T006B18_A491CBCueDsc[0];
            AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T006B19 */
            pr_default.execute(17, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006B20 */
            pr_default.execute(18, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006B21 */
            pr_default.execute(19, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T006B22 */
            pr_default.execute(20, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Libro Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T006B23 */
            pr_default.execute(21, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T006B24 */
            pr_default.execute(22, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T006B25 */
            pr_default.execute(23, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T006B26 */
            pr_default.execute(24, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T006B27 */
            pr_default.execute(25, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel6B174( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6B174( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("bancos.cuentabancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("bancos.cuentabancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6B174( )
      {
         /* Scan By routine */
         /* Using cursor T006B28 */
         pr_default.execute(26);
         RcdFound174 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound174 = 1;
            A372BanCod = T006B28_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A377CBCod = T006B28_A377CBCod[0];
            AssignAttri("", false, "A377CBCod", A377CBCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6B174( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound174 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound174 = 1;
            A372BanCod = T006B28_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A377CBCod = T006B28_A377CBCod[0];
            AssignAttri("", false, "A377CBCod", A377CBCod);
         }
      }

      protected void ScanEnd6B174( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm6B174( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6B174( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6B174( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6B174( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6B174( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6B174( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6B174( )
      {
         edtBanCod_Enabled = 0;
         AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         edtCBCod_Enabled = 0;
         AssignProp("", false, edtCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCod_Enabled), 5, 0), true);
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         edtCBCueCod_Enabled = 0;
         AssignProp("", false, edtCBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCueCod_Enabled), 5, 0), true);
         edtCBCheqInicio_Enabled = 0;
         AssignProp("", false, edtCBCheqInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCheqInicio_Enabled), 5, 0), true);
         edtCBCheqFinal_Enabled = 0;
         AssignProp("", false, edtCBCheqFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCheqFinal_Enabled), 5, 0), true);
         edtCBCheqActual_Enabled = 0;
         AssignProp("", false, edtCBCheqActual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCheqActual_Enabled), 5, 0), true);
         edtCBSts_Enabled = 0;
         AssignProp("", false, edtCBSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBSts_Enabled), 5, 0), true);
         edtavCombobancod_Enabled = 0;
         AssignProp("", false, edtavCombobancod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombobancod_Enabled), 5, 0), true);
         edtavCombomoncod_Enabled = 0;
         AssignProp("", false, edtavCombomoncod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomoncod_Enabled), 5, 0), true);
         edtavCombocbcuecod_Enabled = 0;
         AssignProp("", false, edtavCombocbcuecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbcuecod_Enabled), 5, 0), true);
         edtCBCueDsc_Enabled = 0;
         AssignProp("", false, edtCBCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCueDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6B174( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810263649", false, true);
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
         GXEncryptionTmp = "bancos.cuentabancos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BanCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV8CBCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.cuentabancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CuentaBancos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("bancos\\cuentabancos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z372BanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z377CBCod", StringUtil.RTrim( Z377CBCod));
         GxWebStd.gx_hidden_field( context, "Z504CBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z504CBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z490CBCheqInicio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z490CBCheqInicio), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z489CBCheqFinal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z489CBCheqFinal), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z488CBCheqActual", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488CBCheqActual), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z378CBCueCod", StringUtil.RTrim( Z378CBCueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N378CBCueCod", StringUtil.RTrim( A378CBCueCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBANCOD_DATA", AV17BanCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBANCOD_DATA", AV17BanCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMONCOD_DATA", AV23MonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMONCOD_DATA", AV23MonCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCBCUECOD_DATA", AV25CBCueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCBCUECOD_DATA", AV25CBCueCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vBANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BanCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCBCOD", StringUtil.RTrim( AV8CBCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vCBCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8CBCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CBCUECOD", StringUtil.RTrim( AV15Insert_CBCueCod));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BANDSC", StringUtil.RTrim( A482BanDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV31Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Objectcall", StringUtil.RTrim( Combo_bancod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Cls", StringUtil.RTrim( Combo_bancod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Selectedvalue_set", StringUtil.RTrim( Combo_bancod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Selectedtext_set", StringUtil.RTrim( Combo_bancod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Enabled", StringUtil.BoolToStr( Combo_bancod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Datalistproc", StringUtil.RTrim( Combo_bancod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_bancod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_BANCOD_Emptyitem", StringUtil.BoolToStr( Combo_bancod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Objectcall", StringUtil.RTrim( Combo_moncod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Cls", StringUtil.RTrim( Combo_moncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_moncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Selectedtext_set", StringUtil.RTrim( Combo_moncod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Enabled", StringUtil.BoolToStr( Combo_moncod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Datalistproc", StringUtil.RTrim( Combo_moncod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_moncod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_MONCOD_Emptyitem", StringUtil.BoolToStr( Combo_moncod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Objectcall", StringUtil.RTrim( Combo_cbcuecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Cls", StringUtil.RTrim( Combo_cbcuecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Selectedvalue_set", StringUtil.RTrim( Combo_cbcuecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Selectedtext_set", StringUtil.RTrim( Combo_cbcuecod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Enabled", StringUtil.BoolToStr( Combo_cbcuecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Datalistproc", StringUtil.RTrim( Combo_cbcuecod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cbcuecod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CBCUECOD_Emptyitem", StringUtil.BoolToStr( Combo_cbcuecod_Emptyitem));
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
         GXEncryptionTmp = "bancos.cuentabancos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BanCod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV8CBCod));
         return formatLink("bancos.cuentabancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.CuentaBancos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cuenta Bancos" ;
      }

      protected void InitializeNonKey6B174( )
      {
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         A378CBCueCod = "";
         AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
         A482BanDsc = "";
         AssignAttri("", false, "A482BanDsc", A482BanDsc);
         A490CBCheqInicio = 0;
         AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
         A489CBCheqFinal = 0;
         AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
         A488CBCheqActual = 0;
         AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
         A491CBCueDsc = "";
         AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
         A504CBSts = 1;
         AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
         Z504CBSts = 0;
         Z490CBCheqInicio = 0;
         Z489CBCheqFinal = 0;
         Z488CBCheqActual = 0;
         Z180MonCod = 0;
         Z378CBCueCod = "";
      }

      protected void InitAll6B174( )
      {
         A372BanCod = 0;
         AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         A377CBCod = "";
         AssignAttri("", false, "A377CBCod", A377CBCod);
         InitializeNonKey6B174( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A504CBSts = i504CBSts;
         AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026374", true, true);
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
         context.AddJavascriptSource("bancos/cuentabancos.js", "?20228181026374", false, true);
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
         lblTextblockbancod_Internalname = "TEXTBLOCKBANCOD";
         Combo_bancod_Internalname = "COMBO_BANCOD";
         edtBanCod_Internalname = "BANCOD";
         divTablesplittedbancod_Internalname = "TABLESPLITTEDBANCOD";
         edtCBCod_Internalname = "CBCOD";
         lblTextblockmoncod_Internalname = "TEXTBLOCKMONCOD";
         Combo_moncod_Internalname = "COMBO_MONCOD";
         edtMonCod_Internalname = "MONCOD";
         divTablesplittedmoncod_Internalname = "TABLESPLITTEDMONCOD";
         lblTextblockcbcuecod_Internalname = "TEXTBLOCKCBCUECOD";
         Combo_cbcuecod_Internalname = "COMBO_CBCUECOD";
         edtCBCueCod_Internalname = "CBCUECOD";
         divTablesplittedcbcuecod_Internalname = "TABLESPLITTEDCBCUECOD";
         edtCBCheqInicio_Internalname = "CBCHEQINICIO";
         edtCBCheqFinal_Internalname = "CBCHEQFINAL";
         edtCBCheqActual_Internalname = "CBCHEQACTUAL";
         edtCBSts_Internalname = "CBSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombobancod_Internalname = "vCOMBOBANCOD";
         divSectionattribute_bancod_Internalname = "SECTIONATTRIBUTE_BANCOD";
         edtavCombomoncod_Internalname = "vCOMBOMONCOD";
         divSectionattribute_moncod_Internalname = "SECTIONATTRIBUTE_MONCOD";
         edtavCombocbcuecod_Internalname = "vCOMBOCBCUECOD";
         divSectionattribute_cbcuecod_Internalname = "SECTIONATTRIBUTE_CBCUECOD";
         edtCBCueDsc_Internalname = "CBCUEDSC";
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
         Form.Caption = "Cuenta Bancos";
         edtCBCueDsc_Jsonclick = "";
         edtCBCueDsc_Enabled = 0;
         edtCBCueDsc_Visible = 1;
         edtavCombocbcuecod_Jsonclick = "";
         edtavCombocbcuecod_Enabled = 0;
         edtavCombocbcuecod_Visible = 1;
         edtavCombomoncod_Jsonclick = "";
         edtavCombomoncod_Enabled = 0;
         edtavCombomoncod_Visible = 1;
         edtavCombobancod_Jsonclick = "";
         edtavCombobancod_Enabled = 0;
         edtavCombobancod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCBSts_Jsonclick = "";
         edtCBSts_Enabled = 1;
         edtCBCheqActual_Jsonclick = "";
         edtCBCheqActual_Enabled = 1;
         edtCBCheqFinal_Jsonclick = "";
         edtCBCheqFinal_Enabled = 1;
         edtCBCheqInicio_Jsonclick = "";
         edtCBCheqInicio_Enabled = 1;
         edtCBCueCod_Jsonclick = "";
         edtCBCueCod_Enabled = 1;
         edtCBCueCod_Visible = 1;
         Combo_cbcuecod_Emptyitem = Convert.ToBoolean( 0);
         Combo_cbcuecod_Datalistprocparametersprefix = " \"ComboName\": \"CBCueCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BanCod\": 0, \"CBCod\": \"\"";
         Combo_cbcuecod_Datalistproc = "Bancos.CuentaBancosLoadDVCombo";
         Combo_cbcuecod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_cbcuecod_Caption = "";
         Combo_cbcuecod_Enabled = Convert.ToBoolean( -1);
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
         edtMonCod_Visible = 1;
         Combo_moncod_Emptyitem = Convert.ToBoolean( 0);
         Combo_moncod_Datalistprocparametersprefix = " \"ComboName\": \"MonCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BanCod\": 0, \"CBCod\": \"\"";
         Combo_moncod_Datalistproc = "Bancos.CuentaBancosLoadDVCombo";
         Combo_moncod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_moncod_Caption = "";
         Combo_moncod_Enabled = Convert.ToBoolean( -1);
         edtCBCod_Jsonclick = "";
         edtCBCod_Enabled = 1;
         edtBanCod_Jsonclick = "";
         edtBanCod_Enabled = 1;
         edtBanCod_Visible = 1;
         Combo_bancod_Emptyitem = Convert.ToBoolean( 0);
         Combo_bancod_Datalistprocparametersprefix = " \"ComboName\": \"BanCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"BanCod\": 0, \"CBCod\": \"\"";
         Combo_bancod_Datalistproc = "Bancos.CuentaBancosLoadDVCombo";
         Combo_bancod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_bancod_Caption = "";
         Combo_bancod_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Bancod( )
      {
         /* Using cursor T006B17 */
         pr_default.execute(15, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
         }
         A482BanDsc = T006B17_A482BanDsc[0];
         pr_default.close(15);
         if ( (0==A372BanCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo Banco", "", "", "", "", "", "", "", ""), 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A482BanDsc", StringUtil.RTrim( A482BanDsc));
      }

      public void Valid_Moncod( )
      {
         /* Using cursor T006B29 */
         pr_default.execute(27, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
         }
         pr_default.close(27);
         if ( (0==A180MonCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo Moneda", "", "", "", "", "", "", "", ""), 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cbcuecod( )
      {
         /* Using cursor T006B18 */
         pr_default.execute(16, new Object[] {A378CBCueCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
         }
         A491CBCueDsc = T006B18_A491CBCueDsc[0];
         pr_default.close(16);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A378CBCueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "CBCue Cod", "", "", "", "", "", "", "", ""), 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A491CBCueDsc", StringUtil.RTrim( A491CBCueDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7BanCod',fld:'vBANCOD',pic:'ZZZZZ9',hsh:true},{av:'AV8CBCod',fld:'vCBCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7BanCod',fld:'vBANCOD',pic:'ZZZZZ9',hsh:true},{av:'AV8CBCod',fld:'vCBCOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126B2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A482BanDsc',fld:'BANDSC',pic:''},{av:'A377CBCod',fld:'CBCOD',pic:''},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_BANCOD","{handler:'Valid_Bancod',iparms:[{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9'},{av:'A482BanDsc',fld:'BANDSC',pic:''}]");
         setEventMetadata("VALID_BANCOD",",oparms:[{av:'A482BanDsc',fld:'BANDSC',pic:''}]}");
         setEventMetadata("VALID_CBCOD","{handler:'Valid_Cbcod',iparms:[]");
         setEventMetadata("VALID_CBCOD",",oparms:[]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[]}");
         setEventMetadata("VALID_CBCUECOD","{handler:'Valid_Cbcuecod',iparms:[{av:'A378CBCueCod',fld:'CBCUECOD',pic:''},{av:'A491CBCueDsc',fld:'CBCUEDSC',pic:''}]");
         setEventMetadata("VALID_CBCUECOD",",oparms:[{av:'A491CBCueDsc',fld:'CBCUEDSC',pic:''}]}");
         setEventMetadata("VALIDV_COMBOBANCOD","{handler:'Validv_Combobancod',iparms:[]");
         setEventMetadata("VALIDV_COMBOBANCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOMONCOD","{handler:'Validv_Combomoncod',iparms:[]");
         setEventMetadata("VALIDV_COMBOMONCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCBCUECOD","{handler:'Validv_Combocbcuecod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCBCUECOD",",oparms:[]}");
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
         pr_default.close(27);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV8CBCod = "";
         Z377CBCod = "";
         Z378CBCueCod = "";
         N378CBCueCod = "";
         Combo_cbcuecod_Selectedvalue_get = "";
         Combo_moncod_Selectedvalue_get = "";
         Combo_bancod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A378CBCueCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockbancod_Jsonclick = "";
         ucCombo_bancod = new GXUserControl();
         AV18DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17BanCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A377CBCod = "";
         lblTextblockmoncod_Jsonclick = "";
         ucCombo_moncod = new GXUserControl();
         AV23MonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcbcuecod_Jsonclick = "";
         ucCombo_cbcuecod = new GXUserControl();
         AV25CBCueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV26ComboCBCueCod = "";
         A491CBCueDsc = "";
         AV15Insert_CBCueCod = "";
         A482BanDsc = "";
         AV31Pgmname = "";
         Combo_bancod_Objectcall = "";
         Combo_bancod_Class = "";
         Combo_bancod_Icontype = "";
         Combo_bancod_Icon = "";
         Combo_bancod_Tooltip = "";
         Combo_bancod_Selectedvalue_set = "";
         Combo_bancod_Selectedtext_set = "";
         Combo_bancod_Selectedtext_get = "";
         Combo_bancod_Gamoauthtoken = "";
         Combo_bancod_Ddointernalname = "";
         Combo_bancod_Titlecontrolalign = "";
         Combo_bancod_Dropdownoptionstype = "";
         Combo_bancod_Titlecontrolidtoreplace = "";
         Combo_bancod_Datalisttype = "";
         Combo_bancod_Datalistfixedvalues = "";
         Combo_bancod_Htmltemplate = "";
         Combo_bancod_Multiplevaluestype = "";
         Combo_bancod_Loadingdata = "";
         Combo_bancod_Noresultsfound = "";
         Combo_bancod_Emptyitemtext = "";
         Combo_bancod_Onlyselectedvalues = "";
         Combo_bancod_Selectalltext = "";
         Combo_bancod_Multiplevaluesseparator = "";
         Combo_bancod_Addnewoptiontext = "";
         Combo_moncod_Objectcall = "";
         Combo_moncod_Class = "";
         Combo_moncod_Icontype = "";
         Combo_moncod_Icon = "";
         Combo_moncod_Tooltip = "";
         Combo_moncod_Selectedvalue_set = "";
         Combo_moncod_Selectedtext_set = "";
         Combo_moncod_Selectedtext_get = "";
         Combo_moncod_Gamoauthtoken = "";
         Combo_moncod_Ddointernalname = "";
         Combo_moncod_Titlecontrolalign = "";
         Combo_moncod_Dropdownoptionstype = "";
         Combo_moncod_Titlecontrolidtoreplace = "";
         Combo_moncod_Datalisttype = "";
         Combo_moncod_Datalistfixedvalues = "";
         Combo_moncod_Htmltemplate = "";
         Combo_moncod_Multiplevaluestype = "";
         Combo_moncod_Loadingdata = "";
         Combo_moncod_Noresultsfound = "";
         Combo_moncod_Emptyitemtext = "";
         Combo_moncod_Onlyselectedvalues = "";
         Combo_moncod_Selectalltext = "";
         Combo_moncod_Multiplevaluesseparator = "";
         Combo_moncod_Addnewoptiontext = "";
         Combo_cbcuecod_Objectcall = "";
         Combo_cbcuecod_Class = "";
         Combo_cbcuecod_Icontype = "";
         Combo_cbcuecod_Icon = "";
         Combo_cbcuecod_Tooltip = "";
         Combo_cbcuecod_Selectedvalue_set = "";
         Combo_cbcuecod_Selectedtext_set = "";
         Combo_cbcuecod_Selectedtext_get = "";
         Combo_cbcuecod_Gamoauthtoken = "";
         Combo_cbcuecod_Ddointernalname = "";
         Combo_cbcuecod_Titlecontrolalign = "";
         Combo_cbcuecod_Dropdownoptionstype = "";
         Combo_cbcuecod_Titlecontrolidtoreplace = "";
         Combo_cbcuecod_Datalisttype = "";
         Combo_cbcuecod_Datalistfixedvalues = "";
         Combo_cbcuecod_Htmltemplate = "";
         Combo_cbcuecod_Multiplevaluestype = "";
         Combo_cbcuecod_Loadingdata = "";
         Combo_cbcuecod_Noresultsfound = "";
         Combo_cbcuecod_Emptyitemtext = "";
         Combo_cbcuecod_Onlyselectedvalues = "";
         Combo_cbcuecod_Selectalltext = "";
         Combo_cbcuecod_Multiplevaluesseparator = "";
         Combo_cbcuecod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode174 = "";
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
         AV16TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV21Combo_DataJson = "";
         AV19ComboSelectedValue = "";
         AV20ComboSelectedText = "";
         AV28SGAuDocGls = "";
         AV29Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         GXt_char4 = "";
         Z482BanDsc = "";
         Z491CBCueDsc = "";
         T006B4_A482BanDsc = new string[] {""} ;
         T006B6_A491CBCueDsc = new string[] {""} ;
         T006B7_A377CBCod = new string[] {""} ;
         T006B7_A482BanDsc = new string[] {""} ;
         T006B7_A504CBSts = new short[1] ;
         T006B7_A490CBCheqInicio = new long[1] ;
         T006B7_A489CBCheqFinal = new long[1] ;
         T006B7_A488CBCheqActual = new long[1] ;
         T006B7_A491CBCueDsc = new string[] {""} ;
         T006B7_A372BanCod = new int[1] ;
         T006B7_A180MonCod = new int[1] ;
         T006B7_A378CBCueCod = new string[] {""} ;
         T006B5_A180MonCod = new int[1] ;
         T006B8_A482BanDsc = new string[] {""} ;
         T006B9_A180MonCod = new int[1] ;
         T006B10_A491CBCueDsc = new string[] {""} ;
         T006B11_A372BanCod = new int[1] ;
         T006B11_A377CBCod = new string[] {""} ;
         T006B3_A377CBCod = new string[] {""} ;
         T006B3_A504CBSts = new short[1] ;
         T006B3_A490CBCheqInicio = new long[1] ;
         T006B3_A489CBCheqFinal = new long[1] ;
         T006B3_A488CBCheqActual = new long[1] ;
         T006B3_A372BanCod = new int[1] ;
         T006B3_A180MonCod = new int[1] ;
         T006B3_A378CBCueCod = new string[] {""} ;
         T006B12_A372BanCod = new int[1] ;
         T006B12_A377CBCod = new string[] {""} ;
         T006B13_A372BanCod = new int[1] ;
         T006B13_A377CBCod = new string[] {""} ;
         T006B2_A377CBCod = new string[] {""} ;
         T006B2_A504CBSts = new short[1] ;
         T006B2_A490CBCheqInicio = new long[1] ;
         T006B2_A489CBCheqFinal = new long[1] ;
         T006B2_A488CBCheqActual = new long[1] ;
         T006B2_A372BanCod = new int[1] ;
         T006B2_A180MonCod = new int[1] ;
         T006B2_A378CBCueCod = new string[] {""} ;
         T006B17_A482BanDsc = new string[] {""} ;
         T006B18_A491CBCueDsc = new string[] {""} ;
         T006B19_A348UsuCod = new string[] {""} ;
         T006B20_A412PagReg = new long[1] ;
         T006B21_A387TSMovCod = new string[] {""} ;
         T006B22_A379LBBanCod = new int[1] ;
         T006B22_A380LBCBCod = new string[] {""} ;
         T006B22_A381LBRegistro = new string[] {""} ;
         T006B23_A365EntCod = new int[1] ;
         T006B23_A366AperEntCod = new string[] {""} ;
         T006B24_A358CajCod = new int[1] ;
         T006B24_A359AperCajCod = new string[] {""} ;
         T006B25_A354TSAntCod = new string[] {""} ;
         T006B26_A270LiqCod = new string[] {""} ;
         T006B26_A236LiqPrvCod = new string[] {""} ;
         T006B26_A271LiqCodItem = new int[1] ;
         T006B27_A166CobTip = new string[] {""} ;
         T006B27_A167CobCod = new string[] {""} ;
         T006B28_A372BanCod = new int[1] ;
         T006B28_A377CBCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T006B29_A180MonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancos__default(),
            new Object[][] {
                new Object[] {
               T006B2_A377CBCod, T006B2_A504CBSts, T006B2_A490CBCheqInicio, T006B2_A489CBCheqFinal, T006B2_A488CBCheqActual, T006B2_A372BanCod, T006B2_A180MonCod, T006B2_A378CBCueCod
               }
               , new Object[] {
               T006B3_A377CBCod, T006B3_A504CBSts, T006B3_A490CBCheqInicio, T006B3_A489CBCheqFinal, T006B3_A488CBCheqActual, T006B3_A372BanCod, T006B3_A180MonCod, T006B3_A378CBCueCod
               }
               , new Object[] {
               T006B4_A482BanDsc
               }
               , new Object[] {
               T006B5_A180MonCod
               }
               , new Object[] {
               T006B6_A491CBCueDsc
               }
               , new Object[] {
               T006B7_A377CBCod, T006B7_A482BanDsc, T006B7_A504CBSts, T006B7_A490CBCheqInicio, T006B7_A489CBCheqFinal, T006B7_A488CBCheqActual, T006B7_A491CBCueDsc, T006B7_A372BanCod, T006B7_A180MonCod, T006B7_A378CBCueCod
               }
               , new Object[] {
               T006B8_A482BanDsc
               }
               , new Object[] {
               T006B9_A180MonCod
               }
               , new Object[] {
               T006B10_A491CBCueDsc
               }
               , new Object[] {
               T006B11_A372BanCod, T006B11_A377CBCod
               }
               , new Object[] {
               T006B12_A372BanCod, T006B12_A377CBCod
               }
               , new Object[] {
               T006B13_A372BanCod, T006B13_A377CBCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006B17_A482BanDsc
               }
               , new Object[] {
               T006B18_A491CBCueDsc
               }
               , new Object[] {
               T006B19_A348UsuCod
               }
               , new Object[] {
               T006B20_A412PagReg
               }
               , new Object[] {
               T006B21_A387TSMovCod
               }
               , new Object[] {
               T006B22_A379LBBanCod, T006B22_A380LBCBCod, T006B22_A381LBRegistro
               }
               , new Object[] {
               T006B23_A365EntCod, T006B23_A366AperEntCod
               }
               , new Object[] {
               T006B24_A358CajCod, T006B24_A359AperCajCod
               }
               , new Object[] {
               T006B25_A354TSAntCod
               }
               , new Object[] {
               T006B26_A270LiqCod, T006B26_A236LiqPrvCod, T006B26_A271LiqCodItem
               }
               , new Object[] {
               T006B27_A166CobTip, T006B27_A167CobCod
               }
               , new Object[] {
               T006B28_A372BanCod, T006B28_A377CBCod
               }
               , new Object[] {
               T006B29_A180MonCod
               }
            }
         );
         AV31Pgmname = "Bancos.CuentaBancos";
         Z504CBSts = 1;
         A504CBSts = 1;
         i504CBSts = 1;
      }

      private short Z504CBSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A504CBSts ;
      private short Gx_BScreen ;
      private short RcdFound174 ;
      private short GX_JID ;
      private short nIsDirty_174 ;
      private short gxajaxcallmode ;
      private short i504CBSts ;
      private int wcpOAV7BanCod ;
      private int Z372BanCod ;
      private int Z180MonCod ;
      private int N180MonCod ;
      private int A372BanCod ;
      private int A180MonCod ;
      private int AV7BanCod ;
      private int trnEnded ;
      private int edtBanCod_Visible ;
      private int edtBanCod_Enabled ;
      private int edtCBCod_Enabled ;
      private int edtMonCod_Visible ;
      private int edtMonCod_Enabled ;
      private int edtCBCueCod_Visible ;
      private int edtCBCueCod_Enabled ;
      private int edtCBCheqInicio_Enabled ;
      private int edtCBCheqFinal_Enabled ;
      private int edtCBCheqActual_Enabled ;
      private int edtCBSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV22ComboBanCod ;
      private int edtavCombobancod_Enabled ;
      private int edtavCombobancod_Visible ;
      private int AV24ComboMonCod ;
      private int edtavCombomoncod_Enabled ;
      private int edtavCombomoncod_Visible ;
      private int edtavCombocbcuecod_Visible ;
      private int edtavCombocbcuecod_Enabled ;
      private int edtCBCueDsc_Visible ;
      private int edtCBCueDsc_Enabled ;
      private int AV14Insert_MonCod ;
      private int Combo_bancod_Datalistupdateminimumcharacters ;
      private int Combo_bancod_Gxcontroltype ;
      private int Combo_moncod_Datalistupdateminimumcharacters ;
      private int Combo_moncod_Gxcontroltype ;
      private int Combo_cbcuecod_Datalistupdateminimumcharacters ;
      private int Combo_cbcuecod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV32GXV1 ;
      private int idxLst ;
      private long Z490CBCheqInicio ;
      private long Z489CBCheqFinal ;
      private long Z488CBCheqActual ;
      private long A490CBCheqInicio ;
      private long A489CBCheqFinal ;
      private long A488CBCheqActual ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV8CBCod ;
      private string Z377CBCod ;
      private string Z378CBCueCod ;
      private string N378CBCueCod ;
      private string Combo_cbcuecod_Selectedvalue_get ;
      private string Combo_moncod_Selectedvalue_get ;
      private string Combo_bancod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A378CBCueCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV8CBCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtBanCod_Internalname ;
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
      private string divTablesplittedbancod_Internalname ;
      private string lblTextblockbancod_Internalname ;
      private string lblTextblockbancod_Jsonclick ;
      private string Combo_bancod_Caption ;
      private string Combo_bancod_Cls ;
      private string Combo_bancod_Datalistproc ;
      private string Combo_bancod_Datalistprocparametersprefix ;
      private string Combo_bancod_Internalname ;
      private string TempTags ;
      private string edtBanCod_Jsonclick ;
      private string edtCBCod_Internalname ;
      private string A377CBCod ;
      private string edtCBCod_Jsonclick ;
      private string divTablesplittedmoncod_Internalname ;
      private string lblTextblockmoncod_Internalname ;
      private string lblTextblockmoncod_Jsonclick ;
      private string Combo_moncod_Caption ;
      private string Combo_moncod_Cls ;
      private string Combo_moncod_Datalistproc ;
      private string Combo_moncod_Datalistprocparametersprefix ;
      private string Combo_moncod_Internalname ;
      private string edtMonCod_Internalname ;
      private string edtMonCod_Jsonclick ;
      private string divTablesplittedcbcuecod_Internalname ;
      private string lblTextblockcbcuecod_Internalname ;
      private string lblTextblockcbcuecod_Jsonclick ;
      private string Combo_cbcuecod_Caption ;
      private string Combo_cbcuecod_Cls ;
      private string Combo_cbcuecod_Datalistproc ;
      private string Combo_cbcuecod_Datalistprocparametersprefix ;
      private string Combo_cbcuecod_Internalname ;
      private string edtCBCueCod_Internalname ;
      private string edtCBCueCod_Jsonclick ;
      private string edtCBCheqInicio_Internalname ;
      private string edtCBCheqInicio_Jsonclick ;
      private string edtCBCheqFinal_Internalname ;
      private string edtCBCheqFinal_Jsonclick ;
      private string edtCBCheqActual_Internalname ;
      private string edtCBCheqActual_Jsonclick ;
      private string edtCBSts_Internalname ;
      private string edtCBSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_bancod_Internalname ;
      private string edtavCombobancod_Internalname ;
      private string edtavCombobancod_Jsonclick ;
      private string divSectionattribute_moncod_Internalname ;
      private string edtavCombomoncod_Internalname ;
      private string edtavCombomoncod_Jsonclick ;
      private string divSectionattribute_cbcuecod_Internalname ;
      private string edtavCombocbcuecod_Internalname ;
      private string AV26ComboCBCueCod ;
      private string edtavCombocbcuecod_Jsonclick ;
      private string edtCBCueDsc_Internalname ;
      private string A491CBCueDsc ;
      private string edtCBCueDsc_Jsonclick ;
      private string AV15Insert_CBCueCod ;
      private string A482BanDsc ;
      private string AV31Pgmname ;
      private string Combo_bancod_Objectcall ;
      private string Combo_bancod_Class ;
      private string Combo_bancod_Icontype ;
      private string Combo_bancod_Icon ;
      private string Combo_bancod_Tooltip ;
      private string Combo_bancod_Selectedvalue_set ;
      private string Combo_bancod_Selectedtext_set ;
      private string Combo_bancod_Selectedtext_get ;
      private string Combo_bancod_Gamoauthtoken ;
      private string Combo_bancod_Ddointernalname ;
      private string Combo_bancod_Titlecontrolalign ;
      private string Combo_bancod_Dropdownoptionstype ;
      private string Combo_bancod_Titlecontrolidtoreplace ;
      private string Combo_bancod_Datalisttype ;
      private string Combo_bancod_Datalistfixedvalues ;
      private string Combo_bancod_Htmltemplate ;
      private string Combo_bancod_Multiplevaluestype ;
      private string Combo_bancod_Loadingdata ;
      private string Combo_bancod_Noresultsfound ;
      private string Combo_bancod_Emptyitemtext ;
      private string Combo_bancod_Onlyselectedvalues ;
      private string Combo_bancod_Selectalltext ;
      private string Combo_bancod_Multiplevaluesseparator ;
      private string Combo_bancod_Addnewoptiontext ;
      private string Combo_moncod_Objectcall ;
      private string Combo_moncod_Class ;
      private string Combo_moncod_Icontype ;
      private string Combo_moncod_Icon ;
      private string Combo_moncod_Tooltip ;
      private string Combo_moncod_Selectedvalue_set ;
      private string Combo_moncod_Selectedtext_set ;
      private string Combo_moncod_Selectedtext_get ;
      private string Combo_moncod_Gamoauthtoken ;
      private string Combo_moncod_Ddointernalname ;
      private string Combo_moncod_Titlecontrolalign ;
      private string Combo_moncod_Dropdownoptionstype ;
      private string Combo_moncod_Titlecontrolidtoreplace ;
      private string Combo_moncod_Datalisttype ;
      private string Combo_moncod_Datalistfixedvalues ;
      private string Combo_moncod_Htmltemplate ;
      private string Combo_moncod_Multiplevaluestype ;
      private string Combo_moncod_Loadingdata ;
      private string Combo_moncod_Noresultsfound ;
      private string Combo_moncod_Emptyitemtext ;
      private string Combo_moncod_Onlyselectedvalues ;
      private string Combo_moncod_Selectalltext ;
      private string Combo_moncod_Multiplevaluesseparator ;
      private string Combo_moncod_Addnewoptiontext ;
      private string Combo_cbcuecod_Objectcall ;
      private string Combo_cbcuecod_Class ;
      private string Combo_cbcuecod_Icontype ;
      private string Combo_cbcuecod_Icon ;
      private string Combo_cbcuecod_Tooltip ;
      private string Combo_cbcuecod_Selectedvalue_set ;
      private string Combo_cbcuecod_Selectedtext_set ;
      private string Combo_cbcuecod_Selectedtext_get ;
      private string Combo_cbcuecod_Gamoauthtoken ;
      private string Combo_cbcuecod_Ddointernalname ;
      private string Combo_cbcuecod_Titlecontrolalign ;
      private string Combo_cbcuecod_Dropdownoptionstype ;
      private string Combo_cbcuecod_Titlecontrolidtoreplace ;
      private string Combo_cbcuecod_Datalisttype ;
      private string Combo_cbcuecod_Datalistfixedvalues ;
      private string Combo_cbcuecod_Htmltemplate ;
      private string Combo_cbcuecod_Multiplevaluestype ;
      private string Combo_cbcuecod_Loadingdata ;
      private string Combo_cbcuecod_Noresultsfound ;
      private string Combo_cbcuecod_Emptyitemtext ;
      private string Combo_cbcuecod_Onlyselectedvalues ;
      private string Combo_cbcuecod_Selectalltext ;
      private string Combo_cbcuecod_Multiplevaluesseparator ;
      private string Combo_cbcuecod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode174 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string Z482BanDsc ;
      private string Z491CBCueDsc ;
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
      private bool Combo_bancod_Emptyitem ;
      private bool Combo_moncod_Emptyitem ;
      private bool Combo_cbcuecod_Emptyitem ;
      private bool Combo_bancod_Enabled ;
      private bool Combo_bancod_Visible ;
      private bool Combo_bancod_Allowmultipleselection ;
      private bool Combo_bancod_Isgriditem ;
      private bool Combo_bancod_Hasdescription ;
      private bool Combo_bancod_Includeonlyselectedoption ;
      private bool Combo_bancod_Includeselectalloption ;
      private bool Combo_bancod_Includeaddnewoption ;
      private bool Combo_moncod_Enabled ;
      private bool Combo_moncod_Visible ;
      private bool Combo_moncod_Allowmultipleselection ;
      private bool Combo_moncod_Isgriditem ;
      private bool Combo_moncod_Hasdescription ;
      private bool Combo_moncod_Includeonlyselectedoption ;
      private bool Combo_moncod_Includeselectalloption ;
      private bool Combo_moncod_Includeaddnewoption ;
      private bool Combo_cbcuecod_Enabled ;
      private bool Combo_cbcuecod_Visible ;
      private bool Combo_cbcuecod_Allowmultipleselection ;
      private bool Combo_cbcuecod_Isgriditem ;
      private bool Combo_cbcuecod_Hasdescription ;
      private bool Combo_cbcuecod_Includeonlyselectedoption ;
      private bool Combo_cbcuecod_Includeselectalloption ;
      private bool Combo_cbcuecod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV21Combo_DataJson ;
      private string AV19ComboSelectedValue ;
      private string AV20ComboSelectedText ;
      private string AV28SGAuDocGls ;
      private string AV29Codigo ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_bancod ;
      private GXUserControl ucCombo_moncod ;
      private GXUserControl ucCombo_cbcuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006B4_A482BanDsc ;
      private string[] T006B6_A491CBCueDsc ;
      private string[] T006B7_A377CBCod ;
      private string[] T006B7_A482BanDsc ;
      private short[] T006B7_A504CBSts ;
      private long[] T006B7_A490CBCheqInicio ;
      private long[] T006B7_A489CBCheqFinal ;
      private long[] T006B7_A488CBCheqActual ;
      private string[] T006B7_A491CBCueDsc ;
      private int[] T006B7_A372BanCod ;
      private int[] T006B7_A180MonCod ;
      private string[] T006B7_A378CBCueCod ;
      private int[] T006B5_A180MonCod ;
      private string[] T006B8_A482BanDsc ;
      private int[] T006B9_A180MonCod ;
      private string[] T006B10_A491CBCueDsc ;
      private int[] T006B11_A372BanCod ;
      private string[] T006B11_A377CBCod ;
      private string[] T006B3_A377CBCod ;
      private short[] T006B3_A504CBSts ;
      private long[] T006B3_A490CBCheqInicio ;
      private long[] T006B3_A489CBCheqFinal ;
      private long[] T006B3_A488CBCheqActual ;
      private int[] T006B3_A372BanCod ;
      private int[] T006B3_A180MonCod ;
      private string[] T006B3_A378CBCueCod ;
      private int[] T006B12_A372BanCod ;
      private string[] T006B12_A377CBCod ;
      private int[] T006B13_A372BanCod ;
      private string[] T006B13_A377CBCod ;
      private string[] T006B2_A377CBCod ;
      private short[] T006B2_A504CBSts ;
      private long[] T006B2_A490CBCheqInicio ;
      private long[] T006B2_A489CBCheqFinal ;
      private long[] T006B2_A488CBCheqActual ;
      private int[] T006B2_A372BanCod ;
      private int[] T006B2_A180MonCod ;
      private string[] T006B2_A378CBCueCod ;
      private string[] T006B17_A482BanDsc ;
      private string[] T006B18_A491CBCueDsc ;
      private string[] T006B19_A348UsuCod ;
      private long[] T006B20_A412PagReg ;
      private string[] T006B21_A387TSMovCod ;
      private int[] T006B22_A379LBBanCod ;
      private string[] T006B22_A380LBCBCod ;
      private string[] T006B22_A381LBRegistro ;
      private int[] T006B23_A365EntCod ;
      private string[] T006B23_A366AperEntCod ;
      private int[] T006B24_A358CajCod ;
      private string[] T006B24_A359AperCajCod ;
      private string[] T006B25_A354TSAntCod ;
      private string[] T006B26_A270LiqCod ;
      private string[] T006B26_A236LiqPrvCod ;
      private int[] T006B26_A271LiqCodItem ;
      private string[] T006B27_A166CobTip ;
      private string[] T006B27_A167CobCod ;
      private int[] T006B28_A372BanCod ;
      private string[] T006B28_A377CBCod ;
      private int[] T006B29_A180MonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17BanCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23MonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25CBCueCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV18DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
   }

   public class cuentabancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cuentabancos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006B7;
        prmT006B7 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B4;
        prmT006B4 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006B5;
        prmT006B5 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006B6;
        prmT006B6 = new Object[] {
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006B8;
        prmT006B8 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006B9;
        prmT006B9 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006B10;
        prmT006B10 = new Object[] {
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006B11;
        prmT006B11 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B3;
        prmT006B3 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B12;
        prmT006B12 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B13;
        prmT006B13 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B2;
        prmT006B2 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B14;
        prmT006B14 = new Object[] {
        new ParDef("@CBCod",GXType.NChar,20,0) ,
        new ParDef("@CBSts",GXType.Int16,1,0) ,
        new ParDef("@CBCheqInicio",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqFinal",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqActual",GXType.Decimal,10,0) ,
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006B15;
        prmT006B15 = new Object[] {
        new ParDef("@CBSts",GXType.Int16,1,0) ,
        new ParDef("@CBCheqInicio",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqFinal",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqActual",GXType.Decimal,10,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@CBCueCod",GXType.NChar,15,0) ,
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B16;
        prmT006B16 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B19;
        prmT006B19 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B20;
        prmT006B20 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B21;
        prmT006B21 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B22;
        prmT006B22 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B23;
        prmT006B23 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B24;
        prmT006B24 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B25;
        prmT006B25 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B26;
        prmT006B26 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B27;
        prmT006B27 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT006B28;
        prmT006B28 = new Object[] {
        };
        Object[] prmT006B17;
        prmT006B17 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006B29;
        prmT006B29 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006B18;
        prmT006B18 = new Object[] {
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006B2", "SELECT [CBCod], [CBSts], [CBCheqInicio], [CBCheqFinal], [CBCheqActual], [BanCod], [MonCod], [CBCueCod] AS CBCueCod FROM [TSCUENTABANCO] WITH (UPDLOCK) WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B3", "SELECT [CBCod], [CBSts], [CBCheqInicio], [CBCheqFinal], [CBCheqActual], [BanCod], [MonCod], [CBCueCod] AS CBCueCod FROM [TSCUENTABANCO] WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B4", "SELECT [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B5", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B6", "SELECT [CueDsc] AS CBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B7", "SELECT TM1.[CBCod], T2.[BanDsc], TM1.[CBSts], TM1.[CBCheqInicio], TM1.[CBCheqFinal], TM1.[CBCheqActual], T3.[CueDsc] AS CBCueDsc, TM1.[BanCod], TM1.[MonCod], TM1.[CBCueCod] AS CBCueCod FROM (([TSCUENTABANCO] TM1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = TM1.[BanCod]) INNER JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = TM1.[CBCueCod]) WHERE TM1.[BanCod] = @BanCod and TM1.[CBCod] = @CBCod ORDER BY TM1.[BanCod], TM1.[CBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006B7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B8", "SELECT [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B9", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B10", "SELECT [CueDsc] AS CBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B11", "SELECT [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006B11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B12", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE ( [BanCod] > @BanCod or [BanCod] = @BanCod and [CBCod] > @CBCod) ORDER BY [BanCod], [CBCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006B12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B13", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE ( [BanCod] < @BanCod or [BanCod] = @BanCod and [CBCod] < @CBCod) ORDER BY [BanCod] DESC, [CBCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006B13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B14", "INSERT INTO [TSCUENTABANCO]([CBCod], [CBSts], [CBCheqInicio], [CBCheqFinal], [CBCheqActual], [BanCod], [MonCod], [CBCueCod]) VALUES(@CBCod, @CBSts, @CBCheqInicio, @CBCheqFinal, @CBCheqActual, @BanCod, @MonCod, @CBCueCod)", GxErrorMask.GX_NOMASK,prmT006B14)
           ,new CursorDef("T006B15", "UPDATE [TSCUENTABANCO] SET [CBSts]=@CBSts, [CBCheqInicio]=@CBCheqInicio, [CBCheqFinal]=@CBCheqFinal, [CBCheqActual]=@CBCheqActual, [MonCod]=@MonCod, [CBCueCod]=@CBCueCod  WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod", GxErrorMask.GX_NOMASK,prmT006B15)
           ,new CursorDef("T006B16", "DELETE FROM [TSCUENTABANCO]  WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod", GxErrorMask.GX_NOMASK,prmT006B16)
           ,new CursorDef("T006B17", "SELECT [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B18", "SELECT [CueDsc] AS CBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B19", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuMosBanCod] = @BanCod AND [UsuMosCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B20", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagBanCod] = @BanCod AND [PagCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B21", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovBanCod] = @BanCod AND [TSMovCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B22", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @BanCod AND [LBCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B23", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEBanCod] = @BanCod AND [AperECueBan] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B24", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperBanCod] = @BanCod AND [AperCueBan] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B25", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [TSAntBanCod] = @BanCod AND [TSAntCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B26", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqBanCod] = @BanCod AND [LiqBanCue] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B27", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobBanCod] = @BanCod AND [CobCbCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006B28", "SELECT [BanCod], [CBCod] FROM [TSCUENTABANCO] ORDER BY [BanCod], [CBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006B28,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006B29", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006B29,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
