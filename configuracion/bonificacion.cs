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
   public class bonificacion : GXDataArea
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
            A81CBonProdCod = GetPar( "CBonProdCod");
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A81CBonProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A82CBonDProdCod = GetPar( "CBonDProdCod");
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A82CBonDProdCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.bonificacion.aspx")), "configuracion.bonificacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.bonificacion.aspx")))) ;
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
                  AV7CBonProdCod = GetPar( "CBonProdCod");
                  AssignAttri("", false, "AV7CBonProdCod", AV7CBonProdCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCBONPRODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CBonProdCod, "@!")), context));
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
            Form.Meta.addItem("description", "Bonificacion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public bonificacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bonificacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CBonProdCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CBonProdCod = aP1_CBonProdCod;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Producto Bonificado", 1, 0, "px", 0, "px", "Group", "", "HLP_Configuracion\\Bonificacion.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divGrup1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcbonprodcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcbonprodcod_Internalname, "Producto", "", "", lblTextblockcbonprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cbonprodcod.SetProperty("Caption", Combo_cbonprodcod_Caption);
         ucCombo_cbonprodcod.SetProperty("Cls", Combo_cbonprodcod_Cls);
         ucCombo_cbonprodcod.SetProperty("DropDownOptionsData", AV13CBonProdCod_Data);
         ucCombo_cbonprodcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cbonprodcod_Internalname, "COMBO_CBONPRODCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonProdCod_Internalname, StringUtil.RTrim( A81CBonProdCod), StringUtil.RTrim( context.localUtil.Format( A81CBonProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonProdCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCBonProdCod_Visible, edtCBonProdCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Producto a Bonificar", 1, 0, "px", 0, "px", "Group", "", "HLP_Configuracion\\Bonificacion.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divGrup2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcbondprodcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcbondprodcod_Internalname, "Producto", "", "", lblTextblockcbondprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cbondprodcod.SetProperty("Caption", Combo_cbondprodcod_Caption);
         ucCombo_cbondprodcod.SetProperty("Cls", Combo_cbondprodcod_Cls);
         ucCombo_cbondprodcod.SetProperty("DropDownOptionsData", AV20CBonDProdCod_Data);
         ucCombo_cbondprodcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cbondprodcod_Internalname, "COMBO_CBONDPRODCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonDProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonDProdCod_Internalname, StringUtil.RTrim( A82CBonDProdCod), StringUtil.RTrim( context.localUtil.Format( A82CBonDProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCBonDProdCod_Visible, edtCBonDProdCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonCan1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonCan1_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonCan1_Internalname, StringUtil.LTrim( StringUtil.NToC( A497CBonCan1, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonCan1_Enabled!=0) ? context.localUtil.Format( A497CBonCan1, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A497CBonCan1, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonCan1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonCan1_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonBon1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonBon1_Internalname, "Bonifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonBon1_Internalname, StringUtil.LTrim( StringUtil.NToC( A492CBonBon1, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonBon1_Enabled!=0) ? context.localUtil.Format( A492CBonBon1, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A492CBonBon1, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonBon1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonBon1_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Bonificacion.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_cbonprodcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocbonprodcod_Internalname, StringUtil.RTrim( AV18ComboCBonProdCod), StringUtil.RTrim( context.localUtil.Format( AV18ComboCBonProdCod, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocbonprodcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocbonprodcod_Visible, edtavCombocbonprodcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Bonificacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cbondprodcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocbondprodcod_Internalname, StringUtil.RTrim( AV21ComboCBonDProdCod), StringUtil.RTrim( context.localUtil.Format( AV21ComboCBonDProdCod, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocbondprodcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocbondprodcod_Visible, edtavCombocbondprodcod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Bonificacion.htm");
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
         E11692 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vCBONPRODCOD_DATA"), AV13CBonProdCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCBONDPRODCOD_DATA"), AV20CBonDProdCod_Data);
               /* Read saved values. */
               Z81CBonProdCod = cgiGet( "Z81CBonProdCod");
               Z497CBonCan1 = context.localUtil.CToN( cgiGet( "Z497CBonCan1"), ".", ",");
               Z492CBonBon1 = context.localUtil.CToN( cgiGet( "Z492CBonBon1"), ".", ",");
               Z498CBonCan2 = context.localUtil.CToN( cgiGet( "Z498CBonCan2"), ".", ",");
               Z493CBonBon2 = context.localUtil.CToN( cgiGet( "Z493CBonBon2"), ".", ",");
               Z499CBonCan3 = context.localUtil.CToN( cgiGet( "Z499CBonCan3"), ".", ",");
               Z494CBonBon3 = context.localUtil.CToN( cgiGet( "Z494CBonBon3"), ".", ",");
               Z500CBonCan4 = context.localUtil.CToN( cgiGet( "Z500CBonCan4"), ".", ",");
               Z495CBonBon4 = context.localUtil.CToN( cgiGet( "Z495CBonBon4"), ".", ",");
               Z501CBonCan5 = context.localUtil.CToN( cgiGet( "Z501CBonCan5"), ".", ",");
               Z496CBonBon5 = context.localUtil.CToN( cgiGet( "Z496CBonBon5"), ".", ",");
               Z82CBonDProdCod = cgiGet( "Z82CBonDProdCod");
               A498CBonCan2 = context.localUtil.CToN( cgiGet( "Z498CBonCan2"), ".", ",");
               A493CBonBon2 = context.localUtil.CToN( cgiGet( "Z493CBonBon2"), ".", ",");
               A499CBonCan3 = context.localUtil.CToN( cgiGet( "Z499CBonCan3"), ".", ",");
               A494CBonBon3 = context.localUtil.CToN( cgiGet( "Z494CBonBon3"), ".", ",");
               A500CBonCan4 = context.localUtil.CToN( cgiGet( "Z500CBonCan4"), ".", ",");
               A495CBonBon4 = context.localUtil.CToN( cgiGet( "Z495CBonBon4"), ".", ",");
               A501CBonCan5 = context.localUtil.CToN( cgiGet( "Z501CBonCan5"), ".", ",");
               A496CBonBon5 = context.localUtil.CToN( cgiGet( "Z496CBonBon5"), ".", ",");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N82CBonDProdCod = cgiGet( "N82CBonDProdCod");
               AV7CBonProdCod = cgiGet( "vCBONPRODCOD");
               AV11Insert_CBonDProdCod = cgiGet( "vINSERT_CBONDPRODCOD");
               A498CBonCan2 = context.localUtil.CToN( cgiGet( "CBONCAN2"), ".", ",");
               A493CBonBon2 = context.localUtil.CToN( cgiGet( "CBONBON2"), ".", ",");
               A499CBonCan3 = context.localUtil.CToN( cgiGet( "CBONCAN3"), ".", ",");
               A494CBonBon3 = context.localUtil.CToN( cgiGet( "CBONBON3"), ".", ",");
               A500CBonCan4 = context.localUtil.CToN( cgiGet( "CBONCAN4"), ".", ",");
               A495CBonBon4 = context.localUtil.CToN( cgiGet( "CBONBON4"), ".", ",");
               A501CBonCan5 = context.localUtil.CToN( cgiGet( "CBONCAN5"), ".", ",");
               A496CBonBon5 = context.localUtil.CToN( cgiGet( "CBONBON5"), ".", ",");
               A503CBonProdDsc = cgiGet( "CBONPRODDSC");
               A502CBonDProdDsc = cgiGet( "CBONDPRODDSC");
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_cbonprodcod_Objectcall = cgiGet( "COMBO_CBONPRODCOD_Objectcall");
               Combo_cbonprodcod_Class = cgiGet( "COMBO_CBONPRODCOD_Class");
               Combo_cbonprodcod_Icontype = cgiGet( "COMBO_CBONPRODCOD_Icontype");
               Combo_cbonprodcod_Icon = cgiGet( "COMBO_CBONPRODCOD_Icon");
               Combo_cbonprodcod_Caption = cgiGet( "COMBO_CBONPRODCOD_Caption");
               Combo_cbonprodcod_Tooltip = cgiGet( "COMBO_CBONPRODCOD_Tooltip");
               Combo_cbonprodcod_Cls = cgiGet( "COMBO_CBONPRODCOD_Cls");
               Combo_cbonprodcod_Selectedvalue_set = cgiGet( "COMBO_CBONPRODCOD_Selectedvalue_set");
               Combo_cbonprodcod_Selectedvalue_get = cgiGet( "COMBO_CBONPRODCOD_Selectedvalue_get");
               Combo_cbonprodcod_Selectedtext_set = cgiGet( "COMBO_CBONPRODCOD_Selectedtext_set");
               Combo_cbonprodcod_Selectedtext_get = cgiGet( "COMBO_CBONPRODCOD_Selectedtext_get");
               Combo_cbonprodcod_Gamoauthtoken = cgiGet( "COMBO_CBONPRODCOD_Gamoauthtoken");
               Combo_cbonprodcod_Ddointernalname = cgiGet( "COMBO_CBONPRODCOD_Ddointernalname");
               Combo_cbonprodcod_Titlecontrolalign = cgiGet( "COMBO_CBONPRODCOD_Titlecontrolalign");
               Combo_cbonprodcod_Dropdownoptionstype = cgiGet( "COMBO_CBONPRODCOD_Dropdownoptionstype");
               Combo_cbonprodcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Enabled"));
               Combo_cbonprodcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Visible"));
               Combo_cbonprodcod_Titlecontrolidtoreplace = cgiGet( "COMBO_CBONPRODCOD_Titlecontrolidtoreplace");
               Combo_cbonprodcod_Datalisttype = cgiGet( "COMBO_CBONPRODCOD_Datalisttype");
               Combo_cbonprodcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Allowmultipleselection"));
               Combo_cbonprodcod_Datalistfixedvalues = cgiGet( "COMBO_CBONPRODCOD_Datalistfixedvalues");
               Combo_cbonprodcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Isgriditem"));
               Combo_cbonprodcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Hasdescription"));
               Combo_cbonprodcod_Datalistproc = cgiGet( "COMBO_CBONPRODCOD_Datalistproc");
               Combo_cbonprodcod_Datalistprocparametersprefix = cgiGet( "COMBO_CBONPRODCOD_Datalistprocparametersprefix");
               Combo_cbonprodcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBONPRODCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cbonprodcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Includeonlyselectedoption"));
               Combo_cbonprodcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Includeselectalloption"));
               Combo_cbonprodcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Emptyitem"));
               Combo_cbonprodcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CBONPRODCOD_Includeaddnewoption"));
               Combo_cbonprodcod_Htmltemplate = cgiGet( "COMBO_CBONPRODCOD_Htmltemplate");
               Combo_cbonprodcod_Multiplevaluestype = cgiGet( "COMBO_CBONPRODCOD_Multiplevaluestype");
               Combo_cbonprodcod_Loadingdata = cgiGet( "COMBO_CBONPRODCOD_Loadingdata");
               Combo_cbonprodcod_Noresultsfound = cgiGet( "COMBO_CBONPRODCOD_Noresultsfound");
               Combo_cbonprodcod_Emptyitemtext = cgiGet( "COMBO_CBONPRODCOD_Emptyitemtext");
               Combo_cbonprodcod_Onlyselectedvalues = cgiGet( "COMBO_CBONPRODCOD_Onlyselectedvalues");
               Combo_cbonprodcod_Selectalltext = cgiGet( "COMBO_CBONPRODCOD_Selectalltext");
               Combo_cbonprodcod_Multiplevaluesseparator = cgiGet( "COMBO_CBONPRODCOD_Multiplevaluesseparator");
               Combo_cbonprodcod_Addnewoptiontext = cgiGet( "COMBO_CBONPRODCOD_Addnewoptiontext");
               Combo_cbonprodcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBONPRODCOD_Gxcontroltype"), ".", ","));
               Combo_cbondprodcod_Objectcall = cgiGet( "COMBO_CBONDPRODCOD_Objectcall");
               Combo_cbondprodcod_Class = cgiGet( "COMBO_CBONDPRODCOD_Class");
               Combo_cbondprodcod_Icontype = cgiGet( "COMBO_CBONDPRODCOD_Icontype");
               Combo_cbondprodcod_Icon = cgiGet( "COMBO_CBONDPRODCOD_Icon");
               Combo_cbondprodcod_Caption = cgiGet( "COMBO_CBONDPRODCOD_Caption");
               Combo_cbondprodcod_Tooltip = cgiGet( "COMBO_CBONDPRODCOD_Tooltip");
               Combo_cbondprodcod_Cls = cgiGet( "COMBO_CBONDPRODCOD_Cls");
               Combo_cbondprodcod_Selectedvalue_set = cgiGet( "COMBO_CBONDPRODCOD_Selectedvalue_set");
               Combo_cbondprodcod_Selectedvalue_get = cgiGet( "COMBO_CBONDPRODCOD_Selectedvalue_get");
               Combo_cbondprodcod_Selectedtext_set = cgiGet( "COMBO_CBONDPRODCOD_Selectedtext_set");
               Combo_cbondprodcod_Selectedtext_get = cgiGet( "COMBO_CBONDPRODCOD_Selectedtext_get");
               Combo_cbondprodcod_Gamoauthtoken = cgiGet( "COMBO_CBONDPRODCOD_Gamoauthtoken");
               Combo_cbondprodcod_Ddointernalname = cgiGet( "COMBO_CBONDPRODCOD_Ddointernalname");
               Combo_cbondprodcod_Titlecontrolalign = cgiGet( "COMBO_CBONDPRODCOD_Titlecontrolalign");
               Combo_cbondprodcod_Dropdownoptionstype = cgiGet( "COMBO_CBONDPRODCOD_Dropdownoptionstype");
               Combo_cbondprodcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Enabled"));
               Combo_cbondprodcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Visible"));
               Combo_cbondprodcod_Titlecontrolidtoreplace = cgiGet( "COMBO_CBONDPRODCOD_Titlecontrolidtoreplace");
               Combo_cbondprodcod_Datalisttype = cgiGet( "COMBO_CBONDPRODCOD_Datalisttype");
               Combo_cbondprodcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Allowmultipleselection"));
               Combo_cbondprodcod_Datalistfixedvalues = cgiGet( "COMBO_CBONDPRODCOD_Datalistfixedvalues");
               Combo_cbondprodcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Isgriditem"));
               Combo_cbondprodcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Hasdescription"));
               Combo_cbondprodcod_Datalistproc = cgiGet( "COMBO_CBONDPRODCOD_Datalistproc");
               Combo_cbondprodcod_Datalistprocparametersprefix = cgiGet( "COMBO_CBONDPRODCOD_Datalistprocparametersprefix");
               Combo_cbondprodcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBONDPRODCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cbondprodcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Includeonlyselectedoption"));
               Combo_cbondprodcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Includeselectalloption"));
               Combo_cbondprodcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Emptyitem"));
               Combo_cbondprodcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CBONDPRODCOD_Includeaddnewoption"));
               Combo_cbondprodcod_Htmltemplate = cgiGet( "COMBO_CBONDPRODCOD_Htmltemplate");
               Combo_cbondprodcod_Multiplevaluestype = cgiGet( "COMBO_CBONDPRODCOD_Multiplevaluestype");
               Combo_cbondprodcod_Loadingdata = cgiGet( "COMBO_CBONDPRODCOD_Loadingdata");
               Combo_cbondprodcod_Noresultsfound = cgiGet( "COMBO_CBONDPRODCOD_Noresultsfound");
               Combo_cbondprodcod_Emptyitemtext = cgiGet( "COMBO_CBONDPRODCOD_Emptyitemtext");
               Combo_cbondprodcod_Onlyselectedvalues = cgiGet( "COMBO_CBONDPRODCOD_Onlyselectedvalues");
               Combo_cbondprodcod_Selectalltext = cgiGet( "COMBO_CBONDPRODCOD_Selectalltext");
               Combo_cbondprodcod_Multiplevaluesseparator = cgiGet( "COMBO_CBONDPRODCOD_Multiplevaluesseparator");
               Combo_cbondprodcod_Addnewoptiontext = cgiGet( "COMBO_CBONDPRODCOD_Addnewoptiontext");
               Combo_cbondprodcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBONDPRODCOD_Gxcontroltype"), ".", ","));
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
               A81CBonProdCod = StringUtil.Upper( cgiGet( edtCBonProdCod_Internalname));
               AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
               A82CBonDProdCod = StringUtil.Upper( cgiGet( edtCBonDProdCod_Internalname));
               AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCBonCan1_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonCan1_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONCAN1");
                  AnyError = 1;
                  GX_FocusControl = edtCBonCan1_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A497CBonCan1 = 0;
                  AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
               }
               else
               {
                  A497CBonCan1 = context.localUtil.CToN( cgiGet( edtCBonCan1_Internalname), ".", ",");
                  AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCBonBon1_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonBon1_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONBON1");
                  AnyError = 1;
                  GX_FocusControl = edtCBonBon1_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A492CBonBon1 = 0;
                  AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
               }
               else
               {
                  A492CBonBon1 = context.localUtil.CToN( cgiGet( edtCBonBon1_Internalname), ".", ",");
                  AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
               }
               AV18ComboCBonProdCod = StringUtil.Upper( cgiGet( edtavCombocbonprodcod_Internalname));
               AssignAttri("", false, "AV18ComboCBonProdCod", AV18ComboCBonProdCod);
               AV21ComboCBonDProdCod = StringUtil.Upper( cgiGet( edtavCombocbondprodcod_Internalname));
               AssignAttri("", false, "AV21ComboCBonDProdCod", AV21ComboCBonDProdCod);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Bonificacion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("CBonCan2", context.localUtil.Format( A498CBonCan2, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonBon2", context.localUtil.Format( A493CBonBon2, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonCan3", context.localUtil.Format( A499CBonCan3, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonBon3", context.localUtil.Format( A494CBonBon3, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonCan4", context.localUtil.Format( A500CBonCan4, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonBon4", context.localUtil.Format( A495CBonBon4, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonCan5", context.localUtil.Format( A501CBonCan5, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("CBonBon5", context.localUtil.Format( A496CBonBon5, "ZZZZZZ,ZZZ,ZZ9.99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\bonificacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A81CBonProdCod = GetPar( "CBonProdCod");
                  AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
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
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_690( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CBONPRODCOD");
                        AnyError = 1;
                        GX_FocusControl = edtCBonProdCod_Internalname;
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
                           E11692 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12692 ();
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
            E12692 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll694( ) ;
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
            DisableAttributes694( ) ;
         }
         AssignProp("", false, edtavCombocbonprodcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbonprodcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocbondprodcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbondprodcod_Enabled), 5, 0), true);
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

      protected void CONFIRM_690( )
      {
         BeforeValidate694( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls694( ) ;
            }
            else
            {
               CheckExtendedTable694( ) ;
               CloseExtendedTableCursors694( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption690( )
      {
      }

      protected void E11692( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtCBonDProdCod_Visible = 0;
         AssignProp("", false, edtCBonDProdCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCBonDProdCod_Visible), 5, 0), true);
         AV21ComboCBonDProdCod = "";
         AssignAttri("", false, "AV21ComboCBonDProdCod", AV21ComboCBonDProdCod);
         edtavCombocbondprodcod_Visible = 0;
         AssignProp("", false, edtavCombocbondprodcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocbondprodcod_Visible), 5, 0), true);
         edtCBonProdCod_Visible = 0;
         AssignProp("", false, edtCBonProdCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCBonProdCod_Visible), 5, 0), true);
         AV18ComboCBonProdCod = "";
         AssignAttri("", false, "AV18ComboCBonProdCod", AV18ComboCBonProdCod);
         edtavCombocbonprodcod_Visible = 0;
         AssignProp("", false, edtavCombocbonprodcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocbonprodcod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCBONPRODCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCBONDPRODCOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CBonDProdCod") == 0 )
               {
                  AV11Insert_CBonDProdCod = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_CBonDProdCod", AV11Insert_CBonDProdCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CBonDProdCod)) )
                  {
                     AV21ComboCBonDProdCod = AV11Insert_CBonDProdCod;
                     AssignAttri("", false, "AV21ComboCBonDProdCod", AV21ComboCBonDProdCod);
                     Combo_cbondprodcod_Selectedvalue_set = AV21ComboCBonDProdCod;
                     ucCombo_cbondprodcod.SendProperty(context, "", false, Combo_cbondprodcod_Internalname, "SelectedValue_set", Combo_cbondprodcod_Selectedvalue_set);
                     Combo_cbondprodcod_Enabled = false;
                     ucCombo_cbondprodcod.SendProperty(context, "", false, Combo_cbondprodcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbondprodcod_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E12692( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.bonificacionww.aspx") );
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
         /* 'LOADCOMBOCBONDPRODCOD' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV20CBonDProdCod_Data;
         new GeneXus.Programs.configuracion.bonificacionloaddvcombo(context ).execute(  "CBonDProdCod",  Gx_mode,  AV7CBonProdCod, out  AV15ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV20CBonDProdCod_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_cbondprodcod_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_cbondprodcod.SendProperty(context, "", false, Combo_cbondprodcod_Internalname, "SelectedValue_set", Combo_cbondprodcod_Selectedvalue_set);
         AV21ComboCBonDProdCod = AV15ComboSelectedValue;
         AssignAttri("", false, "AV21ComboCBonDProdCod", AV21ComboCBonDProdCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cbondprodcod_Enabled = false;
            ucCombo_cbondprodcod.SendProperty(context, "", false, Combo_cbondprodcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbondprodcod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCBONPRODCOD' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV13CBonProdCod_Data;
         new GeneXus.Programs.configuracion.bonificacionloaddvcombo(context ).execute(  "CBonProdCod",  Gx_mode,  AV7CBonProdCod, out  AV15ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV13CBonProdCod_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_cbonprodcod_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_cbonprodcod.SendProperty(context, "", false, Combo_cbonprodcod_Internalname, "SelectedValue_set", Combo_cbonprodcod_Selectedvalue_set);
         AV18ComboCBonProdCod = AV15ComboSelectedValue;
         AssignAttri("", false, "AV18ComboCBonProdCod", AV18ComboCBonProdCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CBonProdCod)) )
         {
            Combo_cbonprodcod_Enabled = false;
            ucCombo_cbonprodcod.SendProperty(context, "", false, Combo_cbonprodcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbonprodcod_Enabled));
         }
      }

      protected void ZM694( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z497CBonCan1 = T00693_A497CBonCan1[0];
               Z492CBonBon1 = T00693_A492CBonBon1[0];
               Z498CBonCan2 = T00693_A498CBonCan2[0];
               Z493CBonBon2 = T00693_A493CBonBon2[0];
               Z499CBonCan3 = T00693_A499CBonCan3[0];
               Z494CBonBon3 = T00693_A494CBonBon3[0];
               Z500CBonCan4 = T00693_A500CBonCan4[0];
               Z495CBonBon4 = T00693_A495CBonBon4[0];
               Z501CBonCan5 = T00693_A501CBonCan5[0];
               Z496CBonBon5 = T00693_A496CBonBon5[0];
               Z82CBonDProdCod = T00693_A82CBonDProdCod[0];
            }
            else
            {
               Z497CBonCan1 = A497CBonCan1;
               Z492CBonBon1 = A492CBonBon1;
               Z498CBonCan2 = A498CBonCan2;
               Z493CBonBon2 = A493CBonBon2;
               Z499CBonCan3 = A499CBonCan3;
               Z494CBonBon3 = A494CBonBon3;
               Z500CBonCan4 = A500CBonCan4;
               Z495CBonBon4 = A495CBonBon4;
               Z501CBonCan5 = A501CBonCan5;
               Z496CBonBon5 = A496CBonBon5;
               Z82CBonDProdCod = A82CBonDProdCod;
            }
         }
         if ( GX_JID == -12 )
         {
            Z497CBonCan1 = A497CBonCan1;
            Z492CBonBon1 = A492CBonBon1;
            Z498CBonCan2 = A498CBonCan2;
            Z493CBonBon2 = A493CBonBon2;
            Z499CBonCan3 = A499CBonCan3;
            Z494CBonBon3 = A494CBonBon3;
            Z500CBonCan4 = A500CBonCan4;
            Z495CBonBon4 = A495CBonBon4;
            Z501CBonCan5 = A501CBonCan5;
            Z496CBonBon5 = A496CBonBon5;
            Z81CBonProdCod = A81CBonProdCod;
            Z82CBonDProdCod = A82CBonDProdCod;
            Z503CBonProdDsc = A503CBonProdDsc;
            Z502CBonDProdDsc = A502CBonDProdDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "Configuracion.Bonificacion";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CBonProdCod)) )
         {
            edtCBonProdCod_Enabled = 0;
            AssignProp("", false, edtCBonProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonProdCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCBonProdCod_Enabled = 1;
            AssignProp("", false, edtCBonProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonProdCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CBonProdCod)) )
         {
            edtCBonProdCod_Enabled = 0;
            AssignProp("", false, edtCBonProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonProdCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CBonProdCod)) )
         {
            A81CBonProdCod = AV7CBonProdCod;
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         }
         else
         {
            A81CBonProdCod = AV18ComboCBonProdCod;
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CBonDProdCod)) )
         {
            edtCBonDProdCod_Enabled = 0;
            AssignProp("", false, edtCBonDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonDProdCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCBonDProdCod_Enabled = 1;
            AssignProp("", false, edtCBonDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonDProdCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CBonDProdCod)) )
         {
            A82CBonDProdCod = AV11Insert_CBonDProdCod;
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
         }
         else
         {
            A82CBonDProdCod = AV21ComboCBonDProdCod;
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00694 */
            pr_default.execute(2, new Object[] {A81CBonProdCod});
            A503CBonProdDsc = T00694_A503CBonProdDsc[0];
            pr_default.close(2);
            /* Using cursor T00695 */
            pr_default.execute(3, new Object[] {A82CBonDProdCod});
            A502CBonDProdDsc = T00695_A502CBonDProdDsc[0];
            pr_default.close(3);
         }
      }

      protected void Load694( )
      {
         /* Using cursor T00696 */
         pr_default.execute(4, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
            A503CBonProdDsc = T00696_A503CBonProdDsc[0];
            A502CBonDProdDsc = T00696_A502CBonDProdDsc[0];
            A497CBonCan1 = T00696_A497CBonCan1[0];
            AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
            A492CBonBon1 = T00696_A492CBonBon1[0];
            AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
            A498CBonCan2 = T00696_A498CBonCan2[0];
            A493CBonBon2 = T00696_A493CBonBon2[0];
            A499CBonCan3 = T00696_A499CBonCan3[0];
            A494CBonBon3 = T00696_A494CBonBon3[0];
            A500CBonCan4 = T00696_A500CBonCan4[0];
            A495CBonBon4 = T00696_A495CBonBon4[0];
            A501CBonCan5 = T00696_A501CBonCan5[0];
            A496CBonBon5 = T00696_A496CBonBon5[0];
            A82CBonDProdCod = T00696_A82CBonDProdCod[0];
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            ZM694( -12) ;
         }
         pr_default.close(4);
         OnLoadActions694( ) ;
      }

      protected void OnLoadActions694( )
      {
      }

      protected void CheckExtendedTable694( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00694 */
         pr_default.execute(2, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A503CBonProdDsc = T00694_A503CBonProdDsc[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A81CBonProdCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo", "", "", "", "", "", "", "", ""), 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00695 */
         pr_default.execute(3, new Object[] {A82CBonDProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A502CBonDProdDsc = T00695_A502CBonDProdDsc[0];
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A82CBonDProdCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo", "", "", "", "", "", "", "", ""), 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A497CBonCan1) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cantidad", "", "", "", "", "", "", "", ""), 1, "CBONCAN1");
            AnyError = 1;
            GX_FocusControl = edtCBonCan1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors694( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( string A81CBonProdCod )
      {
         /* Using cursor T00697 */
         pr_default.execute(5, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A503CBonProdDsc = T00697_A503CBonProdDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A503CBonProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_14( string A82CBonDProdCod )
      {
         /* Using cursor T00698 */
         pr_default.execute(6, new Object[] {A82CBonDProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A502CBonDProdDsc = T00698_A502CBonDProdDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A502CBonDProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey694( )
      {
         /* Using cursor T00699 */
         pr_default.execute(7, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00693 */
         pr_default.execute(1, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM694( 12) ;
            RcdFound4 = 1;
            A497CBonCan1 = T00693_A497CBonCan1[0];
            AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
            A492CBonBon1 = T00693_A492CBonBon1[0];
            AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
            A498CBonCan2 = T00693_A498CBonCan2[0];
            A493CBonBon2 = T00693_A493CBonBon2[0];
            A499CBonCan3 = T00693_A499CBonCan3[0];
            A494CBonBon3 = T00693_A494CBonBon3[0];
            A500CBonCan4 = T00693_A500CBonCan4[0];
            A495CBonBon4 = T00693_A495CBonBon4[0];
            A501CBonCan5 = T00693_A501CBonCan5[0];
            A496CBonBon5 = T00693_A496CBonBon5[0];
            A81CBonProdCod = T00693_A81CBonProdCod[0];
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            A82CBonDProdCod = T00693_A82CBonDProdCod[0];
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            Z81CBonProdCod = A81CBonProdCod;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load694( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey694( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey694( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey694( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T006910 */
         pr_default.execute(8, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006910_A81CBonProdCod[0], A81CBonProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006910_A81CBonProdCod[0], A81CBonProdCod) > 0 ) ) )
            {
               A81CBonProdCod = T006910_A81CBonProdCod[0];
               AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T006911 */
         pr_default.execute(9, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006911_A81CBonProdCod[0], A81CBonProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006911_A81CBonProdCod[0], A81CBonProdCod) < 0 ) ) )
            {
               A81CBonProdCod = T006911_A81CBonProdCod[0];
               AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
               RcdFound4 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey694( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert694( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 )
               {
                  A81CBonProdCod = Z81CBonProdCod;
                  AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CBONPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update694( ) ;
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert694( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CBONPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCBonProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCBonProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert694( ) ;
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
         if ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 )
         {
            A81CBonProdCod = Z81CBonProdCod;
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency694( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00692 */
            pr_default.execute(0, new Object[] {A81CBonProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBONIFICACION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z497CBonCan1 != T00692_A497CBonCan1[0] ) || ( Z492CBonBon1 != T00692_A492CBonBon1[0] ) || ( Z498CBonCan2 != T00692_A498CBonCan2[0] ) || ( Z493CBonBon2 != T00692_A493CBonBon2[0] ) || ( Z499CBonCan3 != T00692_A499CBonCan3[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z494CBonBon3 != T00692_A494CBonBon3[0] ) || ( Z500CBonCan4 != T00692_A500CBonCan4[0] ) || ( Z495CBonBon4 != T00692_A495CBonBon4[0] ) || ( Z501CBonCan5 != T00692_A501CBonCan5[0] ) || ( Z496CBonBon5 != T00692_A496CBonBon5[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z82CBonDProdCod, T00692_A82CBonDProdCod[0]) != 0 ) )
            {
               if ( Z497CBonCan1 != T00692_A497CBonCan1[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonCan1");
                  GXUtil.WriteLogRaw("Old: ",Z497CBonCan1);
                  GXUtil.WriteLogRaw("Current: ",T00692_A497CBonCan1[0]);
               }
               if ( Z492CBonBon1 != T00692_A492CBonBon1[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonBon1");
                  GXUtil.WriteLogRaw("Old: ",Z492CBonBon1);
                  GXUtil.WriteLogRaw("Current: ",T00692_A492CBonBon1[0]);
               }
               if ( Z498CBonCan2 != T00692_A498CBonCan2[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonCan2");
                  GXUtil.WriteLogRaw("Old: ",Z498CBonCan2);
                  GXUtil.WriteLogRaw("Current: ",T00692_A498CBonCan2[0]);
               }
               if ( Z493CBonBon2 != T00692_A493CBonBon2[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonBon2");
                  GXUtil.WriteLogRaw("Old: ",Z493CBonBon2);
                  GXUtil.WriteLogRaw("Current: ",T00692_A493CBonBon2[0]);
               }
               if ( Z499CBonCan3 != T00692_A499CBonCan3[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonCan3");
                  GXUtil.WriteLogRaw("Old: ",Z499CBonCan3);
                  GXUtil.WriteLogRaw("Current: ",T00692_A499CBonCan3[0]);
               }
               if ( Z494CBonBon3 != T00692_A494CBonBon3[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonBon3");
                  GXUtil.WriteLogRaw("Old: ",Z494CBonBon3);
                  GXUtil.WriteLogRaw("Current: ",T00692_A494CBonBon3[0]);
               }
               if ( Z500CBonCan4 != T00692_A500CBonCan4[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonCan4");
                  GXUtil.WriteLogRaw("Old: ",Z500CBonCan4);
                  GXUtil.WriteLogRaw("Current: ",T00692_A500CBonCan4[0]);
               }
               if ( Z495CBonBon4 != T00692_A495CBonBon4[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonBon4");
                  GXUtil.WriteLogRaw("Old: ",Z495CBonBon4);
                  GXUtil.WriteLogRaw("Current: ",T00692_A495CBonBon4[0]);
               }
               if ( Z501CBonCan5 != T00692_A501CBonCan5[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonCan5");
                  GXUtil.WriteLogRaw("Old: ",Z501CBonCan5);
                  GXUtil.WriteLogRaw("Current: ",T00692_A501CBonCan5[0]);
               }
               if ( Z496CBonBon5 != T00692_A496CBonBon5[0] )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonBon5");
                  GXUtil.WriteLogRaw("Old: ",Z496CBonBon5);
                  GXUtil.WriteLogRaw("Current: ",T00692_A496CBonBon5[0]);
               }
               if ( StringUtil.StrCmp(Z82CBonDProdCod, T00692_A82CBonDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.bonificacion:[seudo value changed for attri]"+"CBonDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z82CBonDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00692_A82CBonDProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBONIFICACION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert694( )
      {
         BeforeValidate694( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable694( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM694( 0) ;
            CheckOptimisticConcurrency694( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm694( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert694( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006912 */
                     pr_default.execute(10, new Object[] {A497CBonCan1, A492CBonBon1, A498CBonCan2, A493CBonBon2, A499CBonCan3, A494CBonBon3, A500CBonCan4, A495CBonBon4, A501CBonCan5, A496CBonBon5, A81CBonProdCod, A82CBonDProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBONIFICACION");
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
                           ResetCaption690( ) ;
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
               Load694( ) ;
            }
            EndLevel694( ) ;
         }
         CloseExtendedTableCursors694( ) ;
      }

      protected void Update694( )
      {
         BeforeValidate694( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable694( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency694( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm694( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate694( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006913 */
                     pr_default.execute(11, new Object[] {A497CBonCan1, A492CBonBon1, A498CBonCan2, A493CBonBon2, A499CBonCan3, A494CBonBon3, A500CBonCan4, A495CBonBon4, A501CBonCan5, A496CBonBon5, A82CBonDProdCod, A81CBonProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBONIFICACION");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBONIFICACION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate694( ) ;
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
            EndLevel694( ) ;
         }
         CloseExtendedTableCursors694( ) ;
      }

      protected void DeferredUpdate694( )
      {
      }

      protected void delete( )
      {
         BeforeValidate694( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency694( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls694( ) ;
            AfterConfirm694( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete694( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006914 */
                  pr_default.execute(12, new Object[] {A81CBonProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CBONIFICACION");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel694( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls694( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006915 */
            pr_default.execute(13, new Object[] {A81CBonProdCod});
            A503CBonProdDsc = T006915_A503CBonProdDsc[0];
            pr_default.close(13);
            /* Using cursor T006916 */
            pr_default.execute(14, new Object[] {A82CBonDProdCod});
            A502CBonDProdDsc = T006916_A502CBonDProdDsc[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel694( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete694( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("configuracion.bonificacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues690( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("configuracion.bonificacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart694( )
      {
         /* Scan By routine */
         /* Using cursor T006917 */
         pr_default.execute(15);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
            A81CBonProdCod = T006917_A81CBonProdCod[0];
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext694( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
            A81CBonProdCod = T006917_A81CBonProdCod[0];
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         }
      }

      protected void ScanEnd694( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm694( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert694( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate694( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete694( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete694( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate694( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes694( )
      {
         edtCBonProdCod_Enabled = 0;
         AssignProp("", false, edtCBonProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonProdCod_Enabled), 5, 0), true);
         edtCBonDProdCod_Enabled = 0;
         AssignProp("", false, edtCBonDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonDProdCod_Enabled), 5, 0), true);
         edtCBonCan1_Enabled = 0;
         AssignProp("", false, edtCBonCan1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonCan1_Enabled), 5, 0), true);
         edtCBonBon1_Enabled = 0;
         AssignProp("", false, edtCBonBon1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonBon1_Enabled), 5, 0), true);
         edtavCombocbonprodcod_Enabled = 0;
         AssignProp("", false, edtavCombocbonprodcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbonprodcod_Enabled), 5, 0), true);
         edtavCombocbondprodcod_Enabled = 0;
         AssignProp("", false, edtavCombocbondprodcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbondprodcod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes694( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues690( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262842", false, true);
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
         GXEncryptionTmp = "configuracion.bonificacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CBonProdCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.bonificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Bonificacion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("CBonCan2", context.localUtil.Format( A498CBonCan2, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonBon2", context.localUtil.Format( A493CBonBon2, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonCan3", context.localUtil.Format( A499CBonCan3, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonBon3", context.localUtil.Format( A494CBonBon3, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonCan4", context.localUtil.Format( A500CBonCan4, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonBon4", context.localUtil.Format( A495CBonBon4, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonCan5", context.localUtil.Format( A501CBonCan5, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("CBonBon5", context.localUtil.Format( A496CBonBon5, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\bonificacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z81CBonProdCod", StringUtil.RTrim( Z81CBonProdCod));
         GxWebStd.gx_hidden_field( context, "Z497CBonCan1", StringUtil.LTrim( StringUtil.NToC( Z497CBonCan1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z492CBonBon1", StringUtil.LTrim( StringUtil.NToC( Z492CBonBon1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z498CBonCan2", StringUtil.LTrim( StringUtil.NToC( Z498CBonCan2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z493CBonBon2", StringUtil.LTrim( StringUtil.NToC( Z493CBonBon2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z499CBonCan3", StringUtil.LTrim( StringUtil.NToC( Z499CBonCan3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z494CBonBon3", StringUtil.LTrim( StringUtil.NToC( Z494CBonBon3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z500CBonCan4", StringUtil.LTrim( StringUtil.NToC( Z500CBonCan4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z495CBonBon4", StringUtil.LTrim( StringUtil.NToC( Z495CBonBon4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z501CBonCan5", StringUtil.LTrim( StringUtil.NToC( Z501CBonCan5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z496CBonBon5", StringUtil.LTrim( StringUtil.NToC( Z496CBonBon5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z82CBonDProdCod", StringUtil.RTrim( Z82CBonDProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N82CBonDProdCod", StringUtil.RTrim( A82CBonDProdCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCBONPRODCOD_DATA", AV13CBonProdCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCBONPRODCOD_DATA", AV13CBonProdCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCBONDPRODCOD_DATA", AV20CBonDProdCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCBONDPRODCOD_DATA", AV20CBonDProdCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vCBONPRODCOD", StringUtil.RTrim( AV7CBonProdCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vCBONPRODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CBonProdCod, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CBONDPRODCOD", StringUtil.RTrim( AV11Insert_CBonDProdCod));
         GxWebStd.gx_hidden_field( context, "CBONCAN2", StringUtil.LTrim( StringUtil.NToC( A498CBonCan2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONBON2", StringUtil.LTrim( StringUtil.NToC( A493CBonBon2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONCAN3", StringUtil.LTrim( StringUtil.NToC( A499CBonCan3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONBON3", StringUtil.LTrim( StringUtil.NToC( A494CBonBon3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONCAN4", StringUtil.LTrim( StringUtil.NToC( A500CBonCan4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONBON4", StringUtil.LTrim( StringUtil.NToC( A495CBonBon4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONCAN5", StringUtil.LTrim( StringUtil.NToC( A501CBonCan5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONBON5", StringUtil.LTrim( StringUtil.NToC( A496CBonBon5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBONPRODDSC", StringUtil.RTrim( A503CBonProdDsc));
         GxWebStd.gx_hidden_field( context, "CBONDPRODDSC", StringUtil.RTrim( A502CBonDProdDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONPRODCOD_Objectcall", StringUtil.RTrim( Combo_cbonprodcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONPRODCOD_Cls", StringUtil.RTrim( Combo_cbonprodcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONPRODCOD_Selectedvalue_set", StringUtil.RTrim( Combo_cbonprodcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONPRODCOD_Enabled", StringUtil.BoolToStr( Combo_cbonprodcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONDPRODCOD_Objectcall", StringUtil.RTrim( Combo_cbondprodcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONDPRODCOD_Cls", StringUtil.RTrim( Combo_cbondprodcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONDPRODCOD_Selectedvalue_set", StringUtil.RTrim( Combo_cbondprodcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBONDPRODCOD_Enabled", StringUtil.BoolToStr( Combo_cbondprodcod_Enabled));
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
         GXEncryptionTmp = "configuracion.bonificacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CBonProdCod));
         return formatLink("configuracion.bonificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Bonificacion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Bonificacion" ;
      }

      protected void InitializeNonKey694( )
      {
         A82CBonDProdCod = "";
         AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
         A503CBonProdDsc = "";
         AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
         A502CBonDProdDsc = "";
         AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
         A497CBonCan1 = 0;
         AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
         A492CBonBon1 = 0;
         AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
         A498CBonCan2 = 0;
         AssignAttri("", false, "A498CBonCan2", StringUtil.LTrimStr( A498CBonCan2, 15, 2));
         A493CBonBon2 = 0;
         AssignAttri("", false, "A493CBonBon2", StringUtil.LTrimStr( A493CBonBon2, 15, 2));
         A499CBonCan3 = 0;
         AssignAttri("", false, "A499CBonCan3", StringUtil.LTrimStr( A499CBonCan3, 15, 2));
         A494CBonBon3 = 0;
         AssignAttri("", false, "A494CBonBon3", StringUtil.LTrimStr( A494CBonBon3, 15, 2));
         A500CBonCan4 = 0;
         AssignAttri("", false, "A500CBonCan4", StringUtil.LTrimStr( A500CBonCan4, 15, 2));
         A495CBonBon4 = 0;
         AssignAttri("", false, "A495CBonBon4", StringUtil.LTrimStr( A495CBonBon4, 15, 2));
         A501CBonCan5 = 0;
         AssignAttri("", false, "A501CBonCan5", StringUtil.LTrimStr( A501CBonCan5, 15, 2));
         A496CBonBon5 = 0;
         AssignAttri("", false, "A496CBonBon5", StringUtil.LTrimStr( A496CBonBon5, 15, 2));
         Z497CBonCan1 = 0;
         Z492CBonBon1 = 0;
         Z498CBonCan2 = 0;
         Z493CBonBon2 = 0;
         Z499CBonCan3 = 0;
         Z494CBonBon3 = 0;
         Z500CBonCan4 = 0;
         Z495CBonBon4 = 0;
         Z501CBonCan5 = 0;
         Z496CBonBon5 = 0;
         Z82CBonDProdCod = "";
      }

      protected void InitAll694( )
      {
         A81CBonProdCod = "";
         AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         InitializeNonKey694( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262878", true, true);
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
         context.AddJavascriptSource("configuracion/bonificacion.js", "?202281810262878", false, true);
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
         lblTextblockcbonprodcod_Internalname = "TEXTBLOCKCBONPRODCOD";
         Combo_cbonprodcod_Internalname = "COMBO_CBONPRODCOD";
         edtCBonProdCod_Internalname = "CBONPRODCOD";
         divTablesplittedcbonprodcod_Internalname = "TABLESPLITTEDCBONPRODCOD";
         divGrup1_Internalname = "GRUP1";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         lblTextblockcbondprodcod_Internalname = "TEXTBLOCKCBONDPRODCOD";
         Combo_cbondprodcod_Internalname = "COMBO_CBONDPRODCOD";
         edtCBonDProdCod_Internalname = "CBONDPRODCOD";
         divTablesplittedcbondprodcod_Internalname = "TABLESPLITTEDCBONDPRODCOD";
         edtCBonCan1_Internalname = "CBONCAN1";
         edtCBonBon1_Internalname = "CBONBON1";
         divGrup2_Internalname = "GRUP2";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocbonprodcod_Internalname = "vCOMBOCBONPRODCOD";
         divSectionattribute_cbonprodcod_Internalname = "SECTIONATTRIBUTE_CBONPRODCOD";
         edtavCombocbondprodcod_Internalname = "vCOMBOCBONDPRODCOD";
         divSectionattribute_cbondprodcod_Internalname = "SECTIONATTRIBUTE_CBONDPRODCOD";
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
         Form.Caption = "Bonificacion";
         edtavCombocbondprodcod_Jsonclick = "";
         edtavCombocbondprodcod_Enabled = 0;
         edtavCombocbondprodcod_Visible = 1;
         edtavCombocbonprodcod_Jsonclick = "";
         edtavCombocbonprodcod_Enabled = 0;
         edtavCombocbonprodcod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCBonBon1_Jsonclick = "";
         edtCBonBon1_Enabled = 1;
         edtCBonCan1_Jsonclick = "";
         edtCBonCan1_Enabled = 1;
         edtCBonDProdCod_Jsonclick = "";
         edtCBonDProdCod_Enabled = 1;
         edtCBonDProdCod_Visible = 1;
         Combo_cbondprodcod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_cbondprodcod_Enabled = Convert.ToBoolean( -1);
         edtCBonProdCod_Jsonclick = "";
         edtCBonProdCod_Enabled = 1;
         edtCBonProdCod_Visible = 1;
         Combo_cbonprodcod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_cbonprodcod_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Cbonprodcod( )
      {
         /* Using cursor T006915 */
         pr_default.execute(13, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
         }
         A503CBonProdDsc = T006915_A503CBonProdDsc[0];
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A81CBonProdCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo", "", "", "", "", "", "", "", ""), 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A503CBonProdDsc", StringUtil.RTrim( A503CBonProdDsc));
      }

      public void Valid_Cbondprodcod( )
      {
         /* Using cursor T006916 */
         pr_default.execute(14, new Object[] {A82CBonDProdCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
         }
         A502CBonDProdDsc = T006916_A502CBonDProdDsc[0];
         pr_default.close(14);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A82CBonDProdCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo", "", "", "", "", "", "", "", ""), 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A502CBonDProdDsc", StringUtil.RTrim( A502CBonDProdDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CBonProdCod',fld:'vCBONPRODCOD',pic:'@!',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CBonProdCod',fld:'vCBONPRODCOD',pic:'@!',hsh:true},{av:'A498CBonCan2',fld:'CBONCAN2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A493CBonBon2',fld:'CBONBON2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A499CBonCan3',fld:'CBONCAN3',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A494CBonBon3',fld:'CBONBON3',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A500CBonCan4',fld:'CBONCAN4',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A495CBonBon4',fld:'CBONBON4',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A501CBonCan5',fld:'CBONCAN5',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A496CBonBon5',fld:'CBONBON5',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12692',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CBONPRODCOD","{handler:'Valid_Cbonprodcod',iparms:[{av:'A81CBonProdCod',fld:'CBONPRODCOD',pic:'@!'},{av:'A503CBonProdDsc',fld:'CBONPRODDSC',pic:''}]");
         setEventMetadata("VALID_CBONPRODCOD",",oparms:[{av:'A503CBonProdDsc',fld:'CBONPRODDSC',pic:''}]}");
         setEventMetadata("VALID_CBONDPRODCOD","{handler:'Valid_Cbondprodcod',iparms:[{av:'A82CBonDProdCod',fld:'CBONDPRODCOD',pic:'@!'},{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''}]");
         setEventMetadata("VALID_CBONDPRODCOD",",oparms:[{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''}]}");
         setEventMetadata("VALID_CBONCAN1","{handler:'Valid_Cboncan1',iparms:[]");
         setEventMetadata("VALID_CBONCAN1",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCBONPRODCOD","{handler:'Validv_Combocbonprodcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCBONPRODCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCBONDPRODCOD","{handler:'Validv_Combocbondprodcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCBONDPRODCOD",",oparms:[]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CBonProdCod = "";
         Z81CBonProdCod = "";
         Z82CBonDProdCod = "";
         N82CBonDProdCod = "";
         Combo_cbondprodcod_Selectedvalue_get = "";
         Combo_cbonprodcod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A81CBonProdCod = "";
         A82CBonDProdCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcbonprodcod_Jsonclick = "";
         ucCombo_cbonprodcod = new GXUserControl();
         Combo_cbonprodcod_Caption = "";
         AV13CBonProdCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockcbondprodcod_Jsonclick = "";
         ucCombo_cbondprodcod = new GXUserControl();
         Combo_cbondprodcod_Caption = "";
         AV20CBonDProdCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV18ComboCBonProdCod = "";
         AV21ComboCBonDProdCod = "";
         AV11Insert_CBonDProdCod = "";
         A503CBonProdDsc = "";
         A502CBonDProdDsc = "";
         AV22Pgmname = "";
         Combo_cbonprodcod_Objectcall = "";
         Combo_cbonprodcod_Class = "";
         Combo_cbonprodcod_Icontype = "";
         Combo_cbonprodcod_Icon = "";
         Combo_cbonprodcod_Tooltip = "";
         Combo_cbonprodcod_Selectedvalue_set = "";
         Combo_cbonprodcod_Selectedtext_set = "";
         Combo_cbonprodcod_Selectedtext_get = "";
         Combo_cbonprodcod_Gamoauthtoken = "";
         Combo_cbonprodcod_Ddointernalname = "";
         Combo_cbonprodcod_Titlecontrolalign = "";
         Combo_cbonprodcod_Dropdownoptionstype = "";
         Combo_cbonprodcod_Titlecontrolidtoreplace = "";
         Combo_cbonprodcod_Datalisttype = "";
         Combo_cbonprodcod_Datalistfixedvalues = "";
         Combo_cbonprodcod_Datalistproc = "";
         Combo_cbonprodcod_Datalistprocparametersprefix = "";
         Combo_cbonprodcod_Htmltemplate = "";
         Combo_cbonprodcod_Multiplevaluestype = "";
         Combo_cbonprodcod_Loadingdata = "";
         Combo_cbonprodcod_Noresultsfound = "";
         Combo_cbonprodcod_Emptyitemtext = "";
         Combo_cbonprodcod_Onlyselectedvalues = "";
         Combo_cbonprodcod_Selectalltext = "";
         Combo_cbonprodcod_Multiplevaluesseparator = "";
         Combo_cbonprodcod_Addnewoptiontext = "";
         Combo_cbondprodcod_Objectcall = "";
         Combo_cbondprodcod_Class = "";
         Combo_cbondprodcod_Icontype = "";
         Combo_cbondprodcod_Icon = "";
         Combo_cbondprodcod_Tooltip = "";
         Combo_cbondprodcod_Selectedvalue_set = "";
         Combo_cbondprodcod_Selectedtext_set = "";
         Combo_cbondprodcod_Selectedtext_get = "";
         Combo_cbondprodcod_Gamoauthtoken = "";
         Combo_cbondprodcod_Ddointernalname = "";
         Combo_cbondprodcod_Titlecontrolalign = "";
         Combo_cbondprodcod_Dropdownoptionstype = "";
         Combo_cbondprodcod_Titlecontrolidtoreplace = "";
         Combo_cbondprodcod_Datalisttype = "";
         Combo_cbondprodcod_Datalistfixedvalues = "";
         Combo_cbondprodcod_Datalistproc = "";
         Combo_cbondprodcod_Datalistprocparametersprefix = "";
         Combo_cbondprodcod_Htmltemplate = "";
         Combo_cbondprodcod_Multiplevaluestype = "";
         Combo_cbondprodcod_Loadingdata = "";
         Combo_cbondprodcod_Noresultsfound = "";
         Combo_cbondprodcod_Emptyitemtext = "";
         Combo_cbondprodcod_Onlyselectedvalues = "";
         Combo_cbondprodcod_Selectalltext = "";
         Combo_cbondprodcod_Multiplevaluesseparator = "";
         Combo_cbondprodcod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV15ComboSelectedValue = "";
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z503CBonProdDsc = "";
         Z502CBonDProdDsc = "";
         T00694_A503CBonProdDsc = new string[] {""} ;
         T00695_A502CBonDProdDsc = new string[] {""} ;
         T00696_A503CBonProdDsc = new string[] {""} ;
         T00696_A502CBonDProdDsc = new string[] {""} ;
         T00696_A497CBonCan1 = new decimal[1] ;
         T00696_A492CBonBon1 = new decimal[1] ;
         T00696_A498CBonCan2 = new decimal[1] ;
         T00696_A493CBonBon2 = new decimal[1] ;
         T00696_A499CBonCan3 = new decimal[1] ;
         T00696_A494CBonBon3 = new decimal[1] ;
         T00696_A500CBonCan4 = new decimal[1] ;
         T00696_A495CBonBon4 = new decimal[1] ;
         T00696_A501CBonCan5 = new decimal[1] ;
         T00696_A496CBonBon5 = new decimal[1] ;
         T00696_A81CBonProdCod = new string[] {""} ;
         T00696_A82CBonDProdCod = new string[] {""} ;
         T00697_A503CBonProdDsc = new string[] {""} ;
         T00698_A502CBonDProdDsc = new string[] {""} ;
         T00699_A81CBonProdCod = new string[] {""} ;
         T00693_A497CBonCan1 = new decimal[1] ;
         T00693_A492CBonBon1 = new decimal[1] ;
         T00693_A498CBonCan2 = new decimal[1] ;
         T00693_A493CBonBon2 = new decimal[1] ;
         T00693_A499CBonCan3 = new decimal[1] ;
         T00693_A494CBonBon3 = new decimal[1] ;
         T00693_A500CBonCan4 = new decimal[1] ;
         T00693_A495CBonBon4 = new decimal[1] ;
         T00693_A501CBonCan5 = new decimal[1] ;
         T00693_A496CBonBon5 = new decimal[1] ;
         T00693_A81CBonProdCod = new string[] {""} ;
         T00693_A82CBonDProdCod = new string[] {""} ;
         T006910_A81CBonProdCod = new string[] {""} ;
         T006911_A81CBonProdCod = new string[] {""} ;
         T00692_A497CBonCan1 = new decimal[1] ;
         T00692_A492CBonBon1 = new decimal[1] ;
         T00692_A498CBonCan2 = new decimal[1] ;
         T00692_A493CBonBon2 = new decimal[1] ;
         T00692_A499CBonCan3 = new decimal[1] ;
         T00692_A494CBonBon3 = new decimal[1] ;
         T00692_A500CBonCan4 = new decimal[1] ;
         T00692_A495CBonBon4 = new decimal[1] ;
         T00692_A501CBonCan5 = new decimal[1] ;
         T00692_A496CBonBon5 = new decimal[1] ;
         T00692_A81CBonProdCod = new string[] {""} ;
         T00692_A82CBonDProdCod = new string[] {""} ;
         T006915_A503CBonProdDsc = new string[] {""} ;
         T006916_A502CBonDProdDsc = new string[] {""} ;
         T006917_A81CBonProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.bonificacion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.bonificacion__default(),
            new Object[][] {
                new Object[] {
               T00692_A497CBonCan1, T00692_A492CBonBon1, T00692_A498CBonCan2, T00692_A493CBonBon2, T00692_A499CBonCan3, T00692_A494CBonBon3, T00692_A500CBonCan4, T00692_A495CBonBon4, T00692_A501CBonCan5, T00692_A496CBonBon5,
               T00692_A81CBonProdCod, T00692_A82CBonDProdCod
               }
               , new Object[] {
               T00693_A497CBonCan1, T00693_A492CBonBon1, T00693_A498CBonCan2, T00693_A493CBonBon2, T00693_A499CBonCan3, T00693_A494CBonBon3, T00693_A500CBonCan4, T00693_A495CBonBon4, T00693_A501CBonCan5, T00693_A496CBonBon5,
               T00693_A81CBonProdCod, T00693_A82CBonDProdCod
               }
               , new Object[] {
               T00694_A503CBonProdDsc
               }
               , new Object[] {
               T00695_A502CBonDProdDsc
               }
               , new Object[] {
               T00696_A503CBonProdDsc, T00696_A502CBonDProdDsc, T00696_A497CBonCan1, T00696_A492CBonBon1, T00696_A498CBonCan2, T00696_A493CBonBon2, T00696_A499CBonCan3, T00696_A494CBonBon3, T00696_A500CBonCan4, T00696_A495CBonBon4,
               T00696_A501CBonCan5, T00696_A496CBonBon5, T00696_A81CBonProdCod, T00696_A82CBonDProdCod
               }
               , new Object[] {
               T00697_A503CBonProdDsc
               }
               , new Object[] {
               T00698_A502CBonDProdDsc
               }
               , new Object[] {
               T00699_A81CBonProdCod
               }
               , new Object[] {
               T006910_A81CBonProdCod
               }
               , new Object[] {
               T006911_A81CBonProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006915_A503CBonProdDsc
               }
               , new Object[] {
               T006916_A502CBonDProdDsc
               }
               , new Object[] {
               T006917_A81CBonProdCod
               }
            }
         );
         AV22Pgmname = "Configuracion.Bonificacion";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound4 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_4 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCBonProdCod_Visible ;
      private int edtCBonProdCod_Enabled ;
      private int edtCBonDProdCod_Visible ;
      private int edtCBonDProdCod_Enabled ;
      private int edtCBonCan1_Enabled ;
      private int edtCBonBon1_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocbonprodcod_Visible ;
      private int edtavCombocbonprodcod_Enabled ;
      private int edtavCombocbondprodcod_Visible ;
      private int edtavCombocbondprodcod_Enabled ;
      private int Combo_cbonprodcod_Datalistupdateminimumcharacters ;
      private int Combo_cbonprodcod_Gxcontroltype ;
      private int Combo_cbondprodcod_Datalistupdateminimumcharacters ;
      private int Combo_cbondprodcod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private decimal Z497CBonCan1 ;
      private decimal Z492CBonBon1 ;
      private decimal Z498CBonCan2 ;
      private decimal Z493CBonBon2 ;
      private decimal Z499CBonCan3 ;
      private decimal Z494CBonBon3 ;
      private decimal Z500CBonCan4 ;
      private decimal Z495CBonBon4 ;
      private decimal Z501CBonCan5 ;
      private decimal Z496CBonBon5 ;
      private decimal A497CBonCan1 ;
      private decimal A492CBonBon1 ;
      private decimal A498CBonCan2 ;
      private decimal A493CBonBon2 ;
      private decimal A499CBonCan3 ;
      private decimal A494CBonBon3 ;
      private decimal A500CBonCan4 ;
      private decimal A495CBonBon4 ;
      private decimal A501CBonCan5 ;
      private decimal A496CBonBon5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7CBonProdCod ;
      private string Z81CBonProdCod ;
      private string Z82CBonDProdCod ;
      private string N82CBonDProdCod ;
      private string Combo_cbondprodcod_Selectedvalue_get ;
      private string Combo_cbonprodcod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A81CBonProdCod ;
      private string A82CBonDProdCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7CBonProdCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCBonProdCod_Internalname ;
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
      private string grpUnnamedgroup1_Internalname ;
      private string divGrup1_Internalname ;
      private string divTablesplittedcbonprodcod_Internalname ;
      private string lblTextblockcbonprodcod_Internalname ;
      private string lblTextblockcbonprodcod_Jsonclick ;
      private string Combo_cbonprodcod_Caption ;
      private string Combo_cbonprodcod_Cls ;
      private string Combo_cbonprodcod_Internalname ;
      private string TempTags ;
      private string edtCBonProdCod_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divGrup2_Internalname ;
      private string divTablesplittedcbondprodcod_Internalname ;
      private string lblTextblockcbondprodcod_Internalname ;
      private string lblTextblockcbondprodcod_Jsonclick ;
      private string Combo_cbondprodcod_Caption ;
      private string Combo_cbondprodcod_Cls ;
      private string Combo_cbondprodcod_Internalname ;
      private string edtCBonDProdCod_Internalname ;
      private string edtCBonDProdCod_Jsonclick ;
      private string edtCBonCan1_Internalname ;
      private string edtCBonCan1_Jsonclick ;
      private string edtCBonBon1_Internalname ;
      private string edtCBonBon1_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_cbonprodcod_Internalname ;
      private string edtavCombocbonprodcod_Internalname ;
      private string AV18ComboCBonProdCod ;
      private string edtavCombocbonprodcod_Jsonclick ;
      private string divSectionattribute_cbondprodcod_Internalname ;
      private string edtavCombocbondprodcod_Internalname ;
      private string AV21ComboCBonDProdCod ;
      private string edtavCombocbondprodcod_Jsonclick ;
      private string AV11Insert_CBonDProdCod ;
      private string A503CBonProdDsc ;
      private string A502CBonDProdDsc ;
      private string AV22Pgmname ;
      private string Combo_cbonprodcod_Objectcall ;
      private string Combo_cbonprodcod_Class ;
      private string Combo_cbonprodcod_Icontype ;
      private string Combo_cbonprodcod_Icon ;
      private string Combo_cbonprodcod_Tooltip ;
      private string Combo_cbonprodcod_Selectedvalue_set ;
      private string Combo_cbonprodcod_Selectedtext_set ;
      private string Combo_cbonprodcod_Selectedtext_get ;
      private string Combo_cbonprodcod_Gamoauthtoken ;
      private string Combo_cbonprodcod_Ddointernalname ;
      private string Combo_cbonprodcod_Titlecontrolalign ;
      private string Combo_cbonprodcod_Dropdownoptionstype ;
      private string Combo_cbonprodcod_Titlecontrolidtoreplace ;
      private string Combo_cbonprodcod_Datalisttype ;
      private string Combo_cbonprodcod_Datalistfixedvalues ;
      private string Combo_cbonprodcod_Datalistproc ;
      private string Combo_cbonprodcod_Datalistprocparametersprefix ;
      private string Combo_cbonprodcod_Htmltemplate ;
      private string Combo_cbonprodcod_Multiplevaluestype ;
      private string Combo_cbonprodcod_Loadingdata ;
      private string Combo_cbonprodcod_Noresultsfound ;
      private string Combo_cbonprodcod_Emptyitemtext ;
      private string Combo_cbonprodcod_Onlyselectedvalues ;
      private string Combo_cbonprodcod_Selectalltext ;
      private string Combo_cbonprodcod_Multiplevaluesseparator ;
      private string Combo_cbonprodcod_Addnewoptiontext ;
      private string Combo_cbondprodcod_Objectcall ;
      private string Combo_cbondprodcod_Class ;
      private string Combo_cbondprodcod_Icontype ;
      private string Combo_cbondprodcod_Icon ;
      private string Combo_cbondprodcod_Tooltip ;
      private string Combo_cbondprodcod_Selectedvalue_set ;
      private string Combo_cbondprodcod_Selectedtext_set ;
      private string Combo_cbondprodcod_Selectedtext_get ;
      private string Combo_cbondprodcod_Gamoauthtoken ;
      private string Combo_cbondprodcod_Ddointernalname ;
      private string Combo_cbondprodcod_Titlecontrolalign ;
      private string Combo_cbondprodcod_Dropdownoptionstype ;
      private string Combo_cbondprodcod_Titlecontrolidtoreplace ;
      private string Combo_cbondprodcod_Datalisttype ;
      private string Combo_cbondprodcod_Datalistfixedvalues ;
      private string Combo_cbondprodcod_Datalistproc ;
      private string Combo_cbondprodcod_Datalistprocparametersprefix ;
      private string Combo_cbondprodcod_Htmltemplate ;
      private string Combo_cbondprodcod_Multiplevaluestype ;
      private string Combo_cbondprodcod_Loadingdata ;
      private string Combo_cbondprodcod_Noresultsfound ;
      private string Combo_cbondprodcod_Emptyitemtext ;
      private string Combo_cbondprodcod_Onlyselectedvalues ;
      private string Combo_cbondprodcod_Selectalltext ;
      private string Combo_cbondprodcod_Multiplevaluesseparator ;
      private string Combo_cbondprodcod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode4 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z503CBonProdDsc ;
      private string Z502CBonDProdDsc ;
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
      private bool Combo_cbonprodcod_Enabled ;
      private bool Combo_cbonprodcod_Visible ;
      private bool Combo_cbonprodcod_Allowmultipleselection ;
      private bool Combo_cbonprodcod_Isgriditem ;
      private bool Combo_cbonprodcod_Hasdescription ;
      private bool Combo_cbonprodcod_Includeonlyselectedoption ;
      private bool Combo_cbonprodcod_Includeselectalloption ;
      private bool Combo_cbonprodcod_Emptyitem ;
      private bool Combo_cbonprodcod_Includeaddnewoption ;
      private bool Combo_cbondprodcod_Enabled ;
      private bool Combo_cbondprodcod_Visible ;
      private bool Combo_cbondprodcod_Allowmultipleselection ;
      private bool Combo_cbondprodcod_Isgriditem ;
      private bool Combo_cbondprodcod_Hasdescription ;
      private bool Combo_cbondprodcod_Includeonlyselectedoption ;
      private bool Combo_cbondprodcod_Includeselectalloption ;
      private bool Combo_cbondprodcod_Emptyitem ;
      private bool Combo_cbondprodcod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV15ComboSelectedValue ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_cbonprodcod ;
      private GXUserControl ucCombo_cbondprodcod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00694_A503CBonProdDsc ;
      private string[] T00695_A502CBonDProdDsc ;
      private string[] T00696_A503CBonProdDsc ;
      private string[] T00696_A502CBonDProdDsc ;
      private decimal[] T00696_A497CBonCan1 ;
      private decimal[] T00696_A492CBonBon1 ;
      private decimal[] T00696_A498CBonCan2 ;
      private decimal[] T00696_A493CBonBon2 ;
      private decimal[] T00696_A499CBonCan3 ;
      private decimal[] T00696_A494CBonBon3 ;
      private decimal[] T00696_A500CBonCan4 ;
      private decimal[] T00696_A495CBonBon4 ;
      private decimal[] T00696_A501CBonCan5 ;
      private decimal[] T00696_A496CBonBon5 ;
      private string[] T00696_A81CBonProdCod ;
      private string[] T00696_A82CBonDProdCod ;
      private string[] T00697_A503CBonProdDsc ;
      private string[] T00698_A502CBonDProdDsc ;
      private string[] T00699_A81CBonProdCod ;
      private decimal[] T00693_A497CBonCan1 ;
      private decimal[] T00693_A492CBonBon1 ;
      private decimal[] T00693_A498CBonCan2 ;
      private decimal[] T00693_A493CBonBon2 ;
      private decimal[] T00693_A499CBonCan3 ;
      private decimal[] T00693_A494CBonBon3 ;
      private decimal[] T00693_A500CBonCan4 ;
      private decimal[] T00693_A495CBonBon4 ;
      private decimal[] T00693_A501CBonCan5 ;
      private decimal[] T00693_A496CBonBon5 ;
      private string[] T00693_A81CBonProdCod ;
      private string[] T00693_A82CBonDProdCod ;
      private string[] T006910_A81CBonProdCod ;
      private string[] T006911_A81CBonProdCod ;
      private decimal[] T00692_A497CBonCan1 ;
      private decimal[] T00692_A492CBonBon1 ;
      private decimal[] T00692_A498CBonCan2 ;
      private decimal[] T00692_A493CBonBon2 ;
      private decimal[] T00692_A499CBonCan3 ;
      private decimal[] T00692_A494CBonBon3 ;
      private decimal[] T00692_A500CBonCan4 ;
      private decimal[] T00692_A495CBonBon4 ;
      private decimal[] T00692_A501CBonCan5 ;
      private decimal[] T00692_A496CBonBon5 ;
      private string[] T00692_A81CBonProdCod ;
      private string[] T00692_A82CBonDProdCod ;
      private string[] T006915_A503CBonProdDsc ;
      private string[] T006916_A502CBonDProdDsc ;
      private string[] T006917_A81CBonProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13CBonProdCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20CBonDProdCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class bonificacion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class bonificacion__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00696;
        prmT00696 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00694;
        prmT00694 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00695;
        prmT00695 = new Object[] {
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00697;
        prmT00697 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00698;
        prmT00698 = new Object[] {
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00699;
        prmT00699 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00693;
        prmT00693 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006910;
        prmT006910 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006911;
        prmT006911 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00692;
        prmT00692 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006912;
        prmT006912 = new Object[] {
        new ParDef("@CBonCan1",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon1",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan2",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon2",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan3",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon3",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan4",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon4",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan5",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon5",GXType.Decimal,15,2) ,
        new ParDef("@CBonProdCod",GXType.NChar,15,0) ,
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006913;
        prmT006913 = new Object[] {
        new ParDef("@CBonCan1",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon1",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan2",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon2",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan3",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon3",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan4",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon4",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan5",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon5",GXType.Decimal,15,2) ,
        new ParDef("@CBonDProdCod",GXType.NChar,15,0) ,
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006914;
        prmT006914 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006917;
        prmT006917 = new Object[] {
        };
        Object[] prmT006915;
        prmT006915 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006916;
        prmT006916 = new Object[] {
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00692", "SELECT [CBonCan1], [CBonBon1], [CBonCan2], [CBonBon2], [CBonCan3], [CBonBon3], [CBonCan4], [CBonBon4], [CBonCan5], [CBonBon5], [CBonProdCod] AS CBonProdCod, [CBonDProdCod] AS CBonDProdCod FROM [CBONIFICACION] WITH (UPDLOCK) WHERE [CBonProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00692,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00693", "SELECT [CBonCan1], [CBonBon1], [CBonCan2], [CBonBon2], [CBonCan3], [CBonBon3], [CBonCan4], [CBonBon4], [CBonCan5], [CBonBon5], [CBonProdCod] AS CBonProdCod, [CBonDProdCod] AS CBonDProdCod FROM [CBONIFICACION] WHERE [CBonProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00693,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00694", "SELECT [ProdDsc] AS CBonProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00694,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00695", "SELECT [ProdDsc] AS CBonDProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00695,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00696", "SELECT T2.[ProdDsc] AS CBonProdDsc, T3.[ProdDsc] AS CBonDProdDsc, TM1.[CBonCan1], TM1.[CBonBon1], TM1.[CBonCan2], TM1.[CBonBon2], TM1.[CBonCan3], TM1.[CBonBon3], TM1.[CBonCan4], TM1.[CBonBon4], TM1.[CBonCan5], TM1.[CBonBon5], TM1.[CBonProdCod] AS CBonProdCod, TM1.[CBonDProdCod] AS CBonDProdCod FROM (([CBONIFICACION] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[CBonProdCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = TM1.[CBonDProdCod]) WHERE TM1.[CBonProdCod] = @CBonProdCod ORDER BY TM1.[CBonProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00696,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00697", "SELECT [ProdDsc] AS CBonProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00697,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00698", "SELECT [ProdDsc] AS CBonDProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00698,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00699", "SELECT [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] WHERE [CBonProdCod] = @CBonProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00699,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006910", "SELECT TOP 1 [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] WHERE ( [CBonProdCod] > @CBonProdCod) ORDER BY [CBonProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006910,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006911", "SELECT TOP 1 [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] WHERE ( [CBonProdCod] < @CBonProdCod) ORDER BY [CBonProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006912", "INSERT INTO [CBONIFICACION]([CBonCan1], [CBonBon1], [CBonCan2], [CBonBon2], [CBonCan3], [CBonBon3], [CBonCan4], [CBonBon4], [CBonCan5], [CBonBon5], [CBonProdCod], [CBonDProdCod]) VALUES(@CBonCan1, @CBonBon1, @CBonCan2, @CBonBon2, @CBonCan3, @CBonBon3, @CBonCan4, @CBonBon4, @CBonCan5, @CBonBon5, @CBonProdCod, @CBonDProdCod)", GxErrorMask.GX_NOMASK,prmT006912)
           ,new CursorDef("T006913", "UPDATE [CBONIFICACION] SET [CBonCan1]=@CBonCan1, [CBonBon1]=@CBonBon1, [CBonCan2]=@CBonCan2, [CBonBon2]=@CBonBon2, [CBonCan3]=@CBonCan3, [CBonBon3]=@CBonBon3, [CBonCan4]=@CBonCan4, [CBonBon4]=@CBonBon4, [CBonCan5]=@CBonCan5, [CBonBon5]=@CBonBon5, [CBonDProdCod]=@CBonDProdCod  WHERE [CBonProdCod] = @CBonProdCod", GxErrorMask.GX_NOMASK,prmT006913)
           ,new CursorDef("T006914", "DELETE FROM [CBONIFICACION]  WHERE [CBonProdCod] = @CBonProdCod", GxErrorMask.GX_NOMASK,prmT006914)
           ,new CursorDef("T006915", "SELECT [ProdDsc] AS CBonProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006915,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006916", "SELECT [ProdDsc] AS CBonDProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006916,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006917", "SELECT [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] ORDER BY [CBonProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006917,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 15);
              ((string[]) buf[13])[0] = rslt.getString(14, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
