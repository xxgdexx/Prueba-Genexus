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
namespace GeneXus.Programs.reloj_interface {
   public class reloj_codigoid : GXDataArea
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
            A2498Reloj_ID = (short)(NumberUtil.Val( GetPar( "Reloj_ID"), "."));
            AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A2498Reloj_ID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A2589RHTrabajadorCodigo = GetPar( "RHTrabajadorCodigo");
            AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A2589RHTrabajadorCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A2591HorarioID = (short)(NumberUtil.Val( GetPar( "HorarioID"), "."));
            AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A2591HorarioID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reloj_interface.reloj_codigoid.aspx")), "reloj_interface.reloj_codigoid.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reloj_interface.reloj_codigoid.aspx")))) ;
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
                  AV29CodigoId = GetPar( "CodigoId");
                  AssignAttri("", false, "AV29CodigoId", AV29CodigoId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCODIGOID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29CodigoId, "")), context));
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
            Form.Meta.addItem("description", "Enrolar Codigos del Reloj Con Trabajador", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCodigoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reloj_codigoid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_codigoid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CodigoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV29CodigoId = aP1_CodigoId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcodigoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcodigoid_Internalname, "Trabajadores en Reloj", "", "", lblTextblockcodigoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_codigoid.SetProperty("Caption", Combo_codigoid_Caption);
         ucCombo_codigoid.SetProperty("Cls", Combo_codigoid_Cls);
         ucCombo_codigoid.SetProperty("EmptyItem", Combo_codigoid_Emptyitem);
         ucCombo_codigoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_codigoid.SetProperty("DropDownOptionsData", AV36CodigoId_Data);
         ucCombo_codigoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_codigoid_Internalname, "COMBO_CODIGOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCodigoId_Internalname, "Codigo Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCodigoId_Internalname, A2431CodigoId, StringUtil.RTrim( context.localUtil.Format( A2431CodigoId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCodigoId_Jsonclick, 0, "Attribute", "", "", "", "", edtCodigoId_Visible, edtCodigoId_Enabled, 1, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedreloj_id_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockreloj_id_Internalname, "Codigo Reloj", "", "", lblTextblockreloj_id_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_reloj_id.SetProperty("Caption", Combo_reloj_id_Caption);
         ucCombo_reloj_id.SetProperty("Cls", Combo_reloj_id_Cls);
         ucCombo_reloj_id.SetProperty("DataListProc", Combo_reloj_id_Datalistproc);
         ucCombo_reloj_id.SetProperty("DataListProcParametersPrefix", Combo_reloj_id_Datalistprocparametersprefix);
         ucCombo_reloj_id.SetProperty("EmptyItem", Combo_reloj_id_Emptyitem);
         ucCombo_reloj_id.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_reloj_id.SetProperty("DropDownOptionsData", AV30Reloj_ID_Data);
         ucCombo_reloj_id.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_reloj_id_Internalname, "COMBO_RELOJ_IDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReloj_ID_Internalname, "Reloj_ID", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReloj_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2498Reloj_ID), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2498Reloj_ID), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReloj_ID_Jsonclick, 0, "Attribute", "", "", "", "", edtReloj_ID_Visible, edtReloj_ID_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtReloj_Nombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReloj_Nombre_Internalname, "Reloj", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtReloj_Nombre_Internalname, A2592Reloj_Nombre, StringUtil.RTrim( context.localUtil.Format( A2592Reloj_Nombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReloj_Nombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReloj_Nombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedhorarioid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorarioid_Internalname, "Horario", "", "", lblTextblockhorarioid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_horarioid.SetProperty("Caption", Combo_horarioid_Caption);
         ucCombo_horarioid.SetProperty("Cls", Combo_horarioid_Cls);
         ucCombo_horarioid.SetProperty("DataListProc", Combo_horarioid_Datalistproc);
         ucCombo_horarioid.SetProperty("DataListProcParametersPrefix", Combo_horarioid_Datalistprocparametersprefix);
         ucCombo_horarioid.SetProperty("EmptyItem", Combo_horarioid_Emptyitem);
         ucCombo_horarioid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_horarioid.SetProperty("DropDownOptionsData", AV33HorarioID_Data);
         ucCombo_horarioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_horarioid_Internalname, "COMBO_HORARIOIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorarioID_Internalname, "Horario ID", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2591HorarioID), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2591HorarioID), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHorarioID_Jsonclick, 0, "Attribute", "", "", "", "", edtHorarioID_Visible, edtHorarioID_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHorarioDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorarioDescripcion_Internalname, "Horario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtHorarioDescripcion_Internalname, A2593HorarioDescripcion, StringUtil.RTrim( context.localUtil.Format( A2593HorarioDescripcion, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHorarioDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHorarioDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedrhtrabajadorcodigo_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockrhtrabajadorcodigo_Internalname, "Trabajador ID", "", "", lblTextblockrhtrabajadorcodigo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_rhtrabajadorcodigo.SetProperty("Caption", Combo_rhtrabajadorcodigo_Caption);
         ucCombo_rhtrabajadorcodigo.SetProperty("Cls", Combo_rhtrabajadorcodigo_Cls);
         ucCombo_rhtrabajadorcodigo.SetProperty("DataListProc", Combo_rhtrabajadorcodigo_Datalistproc);
         ucCombo_rhtrabajadorcodigo.SetProperty("DataListProcParametersPrefix", Combo_rhtrabajadorcodigo_Datalistprocparametersprefix);
         ucCombo_rhtrabajadorcodigo.SetProperty("EmptyItem", Combo_rhtrabajadorcodigo_Emptyitem);
         ucCombo_rhtrabajadorcodigo.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_rhtrabajadorcodigo.SetProperty("DropDownOptionsData", AV26RHTrabajadorCodigo_Data);
         ucCombo_rhtrabajadorcodigo.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_rhtrabajadorcodigo_Internalname, "COMBO_RHTRABAJADORCODIGOContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRHTrabajadorCodigo_Internalname, "RHTrabajador Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRHTrabajadorCodigo_Internalname, A2589RHTrabajadorCodigo, StringUtil.RTrim( context.localUtil.Format( A2589RHTrabajadorCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRHTrabajadorCodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtRHTrabajadorCodigo_Visible, edtRHTrabajadorCodigo_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRHTrabajadorNombres_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRHTrabajadorNombres_Internalname, "Nombres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRHTrabajadorNombres_Internalname, A2590RHTrabajadorNombres, "", "", 0, 1, edtRHTrabajadorNombres_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLectura_Ini_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLectura_Ini_Internalname, "Fecha de Alta", "col-sm-3 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLectura_Ini_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLectura_Ini_Internalname, context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2415Lectura_Ini, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLectura_Ini_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtLectura_Ini_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_bitmap( context, edtLectura_Ini_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLectura_Ini_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLectura_Fin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLectura_Fin_Internalname, "Fecha de Baja", "col-sm-3 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLectura_Fin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLectura_Fin_Internalname, context.localUtil.TToC( A2416Lectura_Fin, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2416Lectura_Fin, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLectura_Fin_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtLectura_Fin_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_bitmap( context, edtLectura_Fin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLectura_Fin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_codigoid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocodigoid_Internalname, AV37ComboCodigoId, StringUtil.RTrim( context.localUtil.Format( AV37ComboCodigoId, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocodigoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocodigoid_Visible, edtavCombocodigoid_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_reloj_id_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboreloj_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ComboReloj_ID), 4, 0, ".", "")), StringUtil.LTrim( ((edtavComboreloj_id_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31ComboReloj_ID), "ZZZ9") : context.localUtil.Format( (decimal)(AV31ComboReloj_ID), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreloj_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreloj_id_Visible, edtavComboreloj_id_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_horarioid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombohorarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ComboHorarioID), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCombohorarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV34ComboHorarioID), "ZZZ9") : context.localUtil.Format( (decimal)(AV34ComboHorarioID), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombohorarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombohorarioid_Visible, edtavCombohorarioid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_rhtrabajadorcodigo_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComborhtrabajadorcodigo_Internalname, AV27ComboRHTrabajadorCodigo, StringUtil.RTrim( context.localUtil.Format( AV27ComboRHTrabajadorCodigo, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComborhtrabajadorcodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavComborhtrabajadorcodigo_Visible, edtavComborhtrabajadorcodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_CodigoID.htm");
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
         E117Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCODIGOID_DATA"), AV36CodigoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vRELOJ_ID_DATA"), AV30Reloj_ID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vHORARIOID_DATA"), AV33HorarioID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vRHTRABAJADORCODIGO_DATA"), AV26RHTrabajadorCodigo_Data);
               /* Read saved values. */
               Z2431CodigoId = cgiGet( "Z2431CodigoId");
               Z2415Lectura_Ini = context.localUtil.CToT( cgiGet( "Z2415Lectura_Ini"), 0);
               Z2416Lectura_Fin = context.localUtil.CToT( cgiGet( "Z2416Lectura_Fin"), 0);
               n2416Lectura_Fin = ((DateTime.MinValue==A2416Lectura_Fin) ? true : false);
               Z2589RHTrabajadorCodigo = cgiGet( "Z2589RHTrabajadorCodigo");
               Z2498Reloj_ID = (short)(context.localUtil.CToN( cgiGet( "Z2498Reloj_ID"), ".", ","));
               Z2591HorarioID = (short)(context.localUtil.CToN( cgiGet( "Z2591HorarioID"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N2498Reloj_ID = (short)(context.localUtil.CToN( cgiGet( "N2498Reloj_ID"), ".", ","));
               N2589RHTrabajadorCodigo = cgiGet( "N2589RHTrabajadorCodigo");
               N2591HorarioID = (short)(context.localUtil.CToN( cgiGet( "N2591HorarioID"), ".", ","));
               A2525TrabApePat = cgiGet( "TRABAPEPAT");
               n2525TrabApePat = false;
               A2526TrabApeMat = cgiGet( "TRABAPEMAT");
               n2526TrabApeMat = false;
               A2527TrabNombres = cgiGet( "TRABNOMBRES");
               n2527TrabNombres = false;
               AV29CodigoId = cgiGet( "vCODIGOID");
               AV23Insert_Reloj_ID = (short)(context.localUtil.CToN( cgiGet( "vINSERT_RELOJ_ID"), ".", ","));
               AV24Insert_RHTrabajadorCodigo = cgiGet( "vINSERT_RHTRABAJADORCODIGO");
               AV25Insert_HorarioID = (short)(context.localUtil.CToN( cgiGet( "vINSERT_HORARIOID"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV39Pgmname = cgiGet( "vPGMNAME");
               Combo_codigoid_Objectcall = cgiGet( "COMBO_CODIGOID_Objectcall");
               Combo_codigoid_Class = cgiGet( "COMBO_CODIGOID_Class");
               Combo_codigoid_Icontype = cgiGet( "COMBO_CODIGOID_Icontype");
               Combo_codigoid_Icon = cgiGet( "COMBO_CODIGOID_Icon");
               Combo_codigoid_Caption = cgiGet( "COMBO_CODIGOID_Caption");
               Combo_codigoid_Tooltip = cgiGet( "COMBO_CODIGOID_Tooltip");
               Combo_codigoid_Cls = cgiGet( "COMBO_CODIGOID_Cls");
               Combo_codigoid_Selectedvalue_set = cgiGet( "COMBO_CODIGOID_Selectedvalue_set");
               Combo_codigoid_Selectedvalue_get = cgiGet( "COMBO_CODIGOID_Selectedvalue_get");
               Combo_codigoid_Selectedtext_set = cgiGet( "COMBO_CODIGOID_Selectedtext_set");
               Combo_codigoid_Selectedtext_get = cgiGet( "COMBO_CODIGOID_Selectedtext_get");
               Combo_codigoid_Gamoauthtoken = cgiGet( "COMBO_CODIGOID_Gamoauthtoken");
               Combo_codigoid_Ddointernalname = cgiGet( "COMBO_CODIGOID_Ddointernalname");
               Combo_codigoid_Titlecontrolalign = cgiGet( "COMBO_CODIGOID_Titlecontrolalign");
               Combo_codigoid_Dropdownoptionstype = cgiGet( "COMBO_CODIGOID_Dropdownoptionstype");
               Combo_codigoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Enabled"));
               Combo_codigoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Visible"));
               Combo_codigoid_Titlecontrolidtoreplace = cgiGet( "COMBO_CODIGOID_Titlecontrolidtoreplace");
               Combo_codigoid_Datalisttype = cgiGet( "COMBO_CODIGOID_Datalisttype");
               Combo_codigoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Allowmultipleselection"));
               Combo_codigoid_Datalistfixedvalues = cgiGet( "COMBO_CODIGOID_Datalistfixedvalues");
               Combo_codigoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Isgriditem"));
               Combo_codigoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Hasdescription"));
               Combo_codigoid_Datalistproc = cgiGet( "COMBO_CODIGOID_Datalistproc");
               Combo_codigoid_Datalistprocparametersprefix = cgiGet( "COMBO_CODIGOID_Datalistprocparametersprefix");
               Combo_codigoid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CODIGOID_Datalistupdateminimumcharacters"), ".", ","));
               Combo_codigoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Includeonlyselectedoption"));
               Combo_codigoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Includeselectalloption"));
               Combo_codigoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Emptyitem"));
               Combo_codigoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CODIGOID_Includeaddnewoption"));
               Combo_codigoid_Htmltemplate = cgiGet( "COMBO_CODIGOID_Htmltemplate");
               Combo_codigoid_Multiplevaluestype = cgiGet( "COMBO_CODIGOID_Multiplevaluestype");
               Combo_codigoid_Loadingdata = cgiGet( "COMBO_CODIGOID_Loadingdata");
               Combo_codigoid_Noresultsfound = cgiGet( "COMBO_CODIGOID_Noresultsfound");
               Combo_codigoid_Emptyitemtext = cgiGet( "COMBO_CODIGOID_Emptyitemtext");
               Combo_codigoid_Onlyselectedvalues = cgiGet( "COMBO_CODIGOID_Onlyselectedvalues");
               Combo_codigoid_Selectalltext = cgiGet( "COMBO_CODIGOID_Selectalltext");
               Combo_codigoid_Multiplevaluesseparator = cgiGet( "COMBO_CODIGOID_Multiplevaluesseparator");
               Combo_codigoid_Addnewoptiontext = cgiGet( "COMBO_CODIGOID_Addnewoptiontext");
               Combo_codigoid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CODIGOID_Gxcontroltype"), ".", ","));
               Combo_reloj_id_Objectcall = cgiGet( "COMBO_RELOJ_ID_Objectcall");
               Combo_reloj_id_Class = cgiGet( "COMBO_RELOJ_ID_Class");
               Combo_reloj_id_Icontype = cgiGet( "COMBO_RELOJ_ID_Icontype");
               Combo_reloj_id_Icon = cgiGet( "COMBO_RELOJ_ID_Icon");
               Combo_reloj_id_Caption = cgiGet( "COMBO_RELOJ_ID_Caption");
               Combo_reloj_id_Tooltip = cgiGet( "COMBO_RELOJ_ID_Tooltip");
               Combo_reloj_id_Cls = cgiGet( "COMBO_RELOJ_ID_Cls");
               Combo_reloj_id_Selectedvalue_set = cgiGet( "COMBO_RELOJ_ID_Selectedvalue_set");
               Combo_reloj_id_Selectedvalue_get = cgiGet( "COMBO_RELOJ_ID_Selectedvalue_get");
               Combo_reloj_id_Selectedtext_set = cgiGet( "COMBO_RELOJ_ID_Selectedtext_set");
               Combo_reloj_id_Selectedtext_get = cgiGet( "COMBO_RELOJ_ID_Selectedtext_get");
               Combo_reloj_id_Gamoauthtoken = cgiGet( "COMBO_RELOJ_ID_Gamoauthtoken");
               Combo_reloj_id_Ddointernalname = cgiGet( "COMBO_RELOJ_ID_Ddointernalname");
               Combo_reloj_id_Titlecontrolalign = cgiGet( "COMBO_RELOJ_ID_Titlecontrolalign");
               Combo_reloj_id_Dropdownoptionstype = cgiGet( "COMBO_RELOJ_ID_Dropdownoptionstype");
               Combo_reloj_id_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Enabled"));
               Combo_reloj_id_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Visible"));
               Combo_reloj_id_Titlecontrolidtoreplace = cgiGet( "COMBO_RELOJ_ID_Titlecontrolidtoreplace");
               Combo_reloj_id_Datalisttype = cgiGet( "COMBO_RELOJ_ID_Datalisttype");
               Combo_reloj_id_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Allowmultipleselection"));
               Combo_reloj_id_Datalistfixedvalues = cgiGet( "COMBO_RELOJ_ID_Datalistfixedvalues");
               Combo_reloj_id_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Isgriditem"));
               Combo_reloj_id_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Hasdescription"));
               Combo_reloj_id_Datalistproc = cgiGet( "COMBO_RELOJ_ID_Datalistproc");
               Combo_reloj_id_Datalistprocparametersprefix = cgiGet( "COMBO_RELOJ_ID_Datalistprocparametersprefix");
               Combo_reloj_id_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_RELOJ_ID_Datalistupdateminimumcharacters"), ".", ","));
               Combo_reloj_id_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Includeonlyselectedoption"));
               Combo_reloj_id_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Includeselectalloption"));
               Combo_reloj_id_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Emptyitem"));
               Combo_reloj_id_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RELOJ_ID_Includeaddnewoption"));
               Combo_reloj_id_Htmltemplate = cgiGet( "COMBO_RELOJ_ID_Htmltemplate");
               Combo_reloj_id_Multiplevaluestype = cgiGet( "COMBO_RELOJ_ID_Multiplevaluestype");
               Combo_reloj_id_Loadingdata = cgiGet( "COMBO_RELOJ_ID_Loadingdata");
               Combo_reloj_id_Noresultsfound = cgiGet( "COMBO_RELOJ_ID_Noresultsfound");
               Combo_reloj_id_Emptyitemtext = cgiGet( "COMBO_RELOJ_ID_Emptyitemtext");
               Combo_reloj_id_Onlyselectedvalues = cgiGet( "COMBO_RELOJ_ID_Onlyselectedvalues");
               Combo_reloj_id_Selectalltext = cgiGet( "COMBO_RELOJ_ID_Selectalltext");
               Combo_reloj_id_Multiplevaluesseparator = cgiGet( "COMBO_RELOJ_ID_Multiplevaluesseparator");
               Combo_reloj_id_Addnewoptiontext = cgiGet( "COMBO_RELOJ_ID_Addnewoptiontext");
               Combo_reloj_id_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_RELOJ_ID_Gxcontroltype"), ".", ","));
               Combo_horarioid_Objectcall = cgiGet( "COMBO_HORARIOID_Objectcall");
               Combo_horarioid_Class = cgiGet( "COMBO_HORARIOID_Class");
               Combo_horarioid_Icontype = cgiGet( "COMBO_HORARIOID_Icontype");
               Combo_horarioid_Icon = cgiGet( "COMBO_HORARIOID_Icon");
               Combo_horarioid_Caption = cgiGet( "COMBO_HORARIOID_Caption");
               Combo_horarioid_Tooltip = cgiGet( "COMBO_HORARIOID_Tooltip");
               Combo_horarioid_Cls = cgiGet( "COMBO_HORARIOID_Cls");
               Combo_horarioid_Selectedvalue_set = cgiGet( "COMBO_HORARIOID_Selectedvalue_set");
               Combo_horarioid_Selectedvalue_get = cgiGet( "COMBO_HORARIOID_Selectedvalue_get");
               Combo_horarioid_Selectedtext_set = cgiGet( "COMBO_HORARIOID_Selectedtext_set");
               Combo_horarioid_Selectedtext_get = cgiGet( "COMBO_HORARIOID_Selectedtext_get");
               Combo_horarioid_Gamoauthtoken = cgiGet( "COMBO_HORARIOID_Gamoauthtoken");
               Combo_horarioid_Ddointernalname = cgiGet( "COMBO_HORARIOID_Ddointernalname");
               Combo_horarioid_Titlecontrolalign = cgiGet( "COMBO_HORARIOID_Titlecontrolalign");
               Combo_horarioid_Dropdownoptionstype = cgiGet( "COMBO_HORARIOID_Dropdownoptionstype");
               Combo_horarioid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Enabled"));
               Combo_horarioid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Visible"));
               Combo_horarioid_Titlecontrolidtoreplace = cgiGet( "COMBO_HORARIOID_Titlecontrolidtoreplace");
               Combo_horarioid_Datalisttype = cgiGet( "COMBO_HORARIOID_Datalisttype");
               Combo_horarioid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Allowmultipleselection"));
               Combo_horarioid_Datalistfixedvalues = cgiGet( "COMBO_HORARIOID_Datalistfixedvalues");
               Combo_horarioid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Isgriditem"));
               Combo_horarioid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Hasdescription"));
               Combo_horarioid_Datalistproc = cgiGet( "COMBO_HORARIOID_Datalistproc");
               Combo_horarioid_Datalistprocparametersprefix = cgiGet( "COMBO_HORARIOID_Datalistprocparametersprefix");
               Combo_horarioid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_HORARIOID_Datalistupdateminimumcharacters"), ".", ","));
               Combo_horarioid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Includeonlyselectedoption"));
               Combo_horarioid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Includeselectalloption"));
               Combo_horarioid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Emptyitem"));
               Combo_horarioid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_HORARIOID_Includeaddnewoption"));
               Combo_horarioid_Htmltemplate = cgiGet( "COMBO_HORARIOID_Htmltemplate");
               Combo_horarioid_Multiplevaluestype = cgiGet( "COMBO_HORARIOID_Multiplevaluestype");
               Combo_horarioid_Loadingdata = cgiGet( "COMBO_HORARIOID_Loadingdata");
               Combo_horarioid_Noresultsfound = cgiGet( "COMBO_HORARIOID_Noresultsfound");
               Combo_horarioid_Emptyitemtext = cgiGet( "COMBO_HORARIOID_Emptyitemtext");
               Combo_horarioid_Onlyselectedvalues = cgiGet( "COMBO_HORARIOID_Onlyselectedvalues");
               Combo_horarioid_Selectalltext = cgiGet( "COMBO_HORARIOID_Selectalltext");
               Combo_horarioid_Multiplevaluesseparator = cgiGet( "COMBO_HORARIOID_Multiplevaluesseparator");
               Combo_horarioid_Addnewoptiontext = cgiGet( "COMBO_HORARIOID_Addnewoptiontext");
               Combo_horarioid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_HORARIOID_Gxcontroltype"), ".", ","));
               Combo_rhtrabajadorcodigo_Objectcall = cgiGet( "COMBO_RHTRABAJADORCODIGO_Objectcall");
               Combo_rhtrabajadorcodigo_Class = cgiGet( "COMBO_RHTRABAJADORCODIGO_Class");
               Combo_rhtrabajadorcodigo_Icontype = cgiGet( "COMBO_RHTRABAJADORCODIGO_Icontype");
               Combo_rhtrabajadorcodigo_Icon = cgiGet( "COMBO_RHTRABAJADORCODIGO_Icon");
               Combo_rhtrabajadorcodigo_Caption = cgiGet( "COMBO_RHTRABAJADORCODIGO_Caption");
               Combo_rhtrabajadorcodigo_Tooltip = cgiGet( "COMBO_RHTRABAJADORCODIGO_Tooltip");
               Combo_rhtrabajadorcodigo_Cls = cgiGet( "COMBO_RHTRABAJADORCODIGO_Cls");
               Combo_rhtrabajadorcodigo_Selectedvalue_set = cgiGet( "COMBO_RHTRABAJADORCODIGO_Selectedvalue_set");
               Combo_rhtrabajadorcodigo_Selectedvalue_get = cgiGet( "COMBO_RHTRABAJADORCODIGO_Selectedvalue_get");
               Combo_rhtrabajadorcodigo_Selectedtext_set = cgiGet( "COMBO_RHTRABAJADORCODIGO_Selectedtext_set");
               Combo_rhtrabajadorcodigo_Selectedtext_get = cgiGet( "COMBO_RHTRABAJADORCODIGO_Selectedtext_get");
               Combo_rhtrabajadorcodigo_Gamoauthtoken = cgiGet( "COMBO_RHTRABAJADORCODIGO_Gamoauthtoken");
               Combo_rhtrabajadorcodigo_Ddointernalname = cgiGet( "COMBO_RHTRABAJADORCODIGO_Ddointernalname");
               Combo_rhtrabajadorcodigo_Titlecontrolalign = cgiGet( "COMBO_RHTRABAJADORCODIGO_Titlecontrolalign");
               Combo_rhtrabajadorcodigo_Dropdownoptionstype = cgiGet( "COMBO_RHTRABAJADORCODIGO_Dropdownoptionstype");
               Combo_rhtrabajadorcodigo_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Enabled"));
               Combo_rhtrabajadorcodigo_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Visible"));
               Combo_rhtrabajadorcodigo_Titlecontrolidtoreplace = cgiGet( "COMBO_RHTRABAJADORCODIGO_Titlecontrolidtoreplace");
               Combo_rhtrabajadorcodigo_Datalisttype = cgiGet( "COMBO_RHTRABAJADORCODIGO_Datalisttype");
               Combo_rhtrabajadorcodigo_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Allowmultipleselection"));
               Combo_rhtrabajadorcodigo_Datalistfixedvalues = cgiGet( "COMBO_RHTRABAJADORCODIGO_Datalistfixedvalues");
               Combo_rhtrabajadorcodigo_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Isgriditem"));
               Combo_rhtrabajadorcodigo_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Hasdescription"));
               Combo_rhtrabajadorcodigo_Datalistproc = cgiGet( "COMBO_RHTRABAJADORCODIGO_Datalistproc");
               Combo_rhtrabajadorcodigo_Datalistprocparametersprefix = cgiGet( "COMBO_RHTRABAJADORCODIGO_Datalistprocparametersprefix");
               Combo_rhtrabajadorcodigo_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_RHTRABAJADORCODIGO_Datalistupdateminimumcharacters"), ".", ","));
               Combo_rhtrabajadorcodigo_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Includeonlyselectedoption"));
               Combo_rhtrabajadorcodigo_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Includeselectalloption"));
               Combo_rhtrabajadorcodigo_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Emptyitem"));
               Combo_rhtrabajadorcodigo_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RHTRABAJADORCODIGO_Includeaddnewoption"));
               Combo_rhtrabajadorcodigo_Htmltemplate = cgiGet( "COMBO_RHTRABAJADORCODIGO_Htmltemplate");
               Combo_rhtrabajadorcodigo_Multiplevaluestype = cgiGet( "COMBO_RHTRABAJADORCODIGO_Multiplevaluestype");
               Combo_rhtrabajadorcodigo_Loadingdata = cgiGet( "COMBO_RHTRABAJADORCODIGO_Loadingdata");
               Combo_rhtrabajadorcodigo_Noresultsfound = cgiGet( "COMBO_RHTRABAJADORCODIGO_Noresultsfound");
               Combo_rhtrabajadorcodigo_Emptyitemtext = cgiGet( "COMBO_RHTRABAJADORCODIGO_Emptyitemtext");
               Combo_rhtrabajadorcodigo_Onlyselectedvalues = cgiGet( "COMBO_RHTRABAJADORCODIGO_Onlyselectedvalues");
               Combo_rhtrabajadorcodigo_Selectalltext = cgiGet( "COMBO_RHTRABAJADORCODIGO_Selectalltext");
               Combo_rhtrabajadorcodigo_Multiplevaluesseparator = cgiGet( "COMBO_RHTRABAJADORCODIGO_Multiplevaluesseparator");
               Combo_rhtrabajadorcodigo_Addnewoptiontext = cgiGet( "COMBO_RHTRABAJADORCODIGO_Addnewoptiontext");
               Combo_rhtrabajadorcodigo_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_RHTRABAJADORCODIGO_Gxcontroltype"), ".", ","));
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
               A2431CodigoId = cgiGet( edtCodigoId_Internalname);
               AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
               if ( ( ( context.localUtil.CToN( cgiGet( edtReloj_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReloj_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RELOJ_ID");
                  AnyError = 1;
                  GX_FocusControl = edtReloj_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2498Reloj_ID = 0;
                  AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
               }
               else
               {
                  A2498Reloj_ID = (short)(context.localUtil.CToN( cgiGet( edtReloj_ID_Internalname), ".", ","));
                  AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
               }
               A2592Reloj_Nombre = cgiGet( edtReloj_Nombre_Internalname);
               AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtHorarioID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHorarioID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HORARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtHorarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2591HorarioID = 0;
                  AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
               }
               else
               {
                  A2591HorarioID = (short)(context.localUtil.CToN( cgiGet( edtHorarioID_Internalname), ".", ","));
                  AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
               }
               A2593HorarioDescripcion = cgiGet( edtHorarioDescripcion_Internalname);
               AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
               A2589RHTrabajadorCodigo = cgiGet( edtRHTrabajadorCodigo_Internalname);
               AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
               A2590RHTrabajadorNombres = cgiGet( edtRHTrabajadorNombres_Internalname);
               AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
               if ( context.localUtil.VCDateTime( cgiGet( edtLectura_Ini_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Lectura_Ini"}), 1, "LECTURA_INI");
                  AnyError = 1;
                  GX_FocusControl = edtLectura_Ini_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2415Lectura_Ini = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2415Lectura_Ini = context.localUtil.CToT( cgiGet( edtLectura_Ini_Internalname));
                  AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtLectura_Fin_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Lectura_Fin"}), 1, "LECTURA_FIN");
                  AnyError = 1;
                  GX_FocusControl = edtLectura_Fin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2416Lectura_Fin = (DateTime)(DateTime.MinValue);
                  n2416Lectura_Fin = false;
                  AssignAttri("", false, "A2416Lectura_Fin", context.localUtil.TToC( A2416Lectura_Fin, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2416Lectura_Fin = context.localUtil.CToT( cgiGet( edtLectura_Fin_Internalname));
                  n2416Lectura_Fin = false;
                  AssignAttri("", false, "A2416Lectura_Fin", context.localUtil.TToC( A2416Lectura_Fin, 10, 8, 0, 3, "/", ":", " "));
               }
               n2416Lectura_Fin = ((DateTime.MinValue==A2416Lectura_Fin) ? true : false);
               AV37ComboCodigoId = cgiGet( edtavCombocodigoid_Internalname);
               AssignAttri("", false, "AV37ComboCodigoId", AV37ComboCodigoId);
               AV31ComboReloj_ID = (short)(context.localUtil.CToN( cgiGet( edtavComboreloj_id_Internalname), ".", ","));
               AssignAttri("", false, "AV31ComboReloj_ID", StringUtil.LTrimStr( (decimal)(AV31ComboReloj_ID), 4, 0));
               AV34ComboHorarioID = (short)(context.localUtil.CToN( cgiGet( edtavCombohorarioid_Internalname), ".", ","));
               AssignAttri("", false, "AV34ComboHorarioID", StringUtil.LTrimStr( (decimal)(AV34ComboHorarioID), 4, 0));
               AV27ComboRHTrabajadorCodigo = cgiGet( edtavComborhtrabajadorcodigo_Internalname);
               AssignAttri("", false, "AV27ComboRHTrabajadorCodigo", AV27ComboRHTrabajadorCodigo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Reloj_CodigoID");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A2431CodigoId, Z2431CodigoId) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("reloj_interface\\reloj_codigoid:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A2431CodigoId = GetPar( "CodigoId");
                  AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
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
                     sMode222 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode222;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound222 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_7Z0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CODIGOID");
                        AnyError = 1;
                        GX_FocusControl = edtCodigoId_Internalname;
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
                           E117Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E127Z2 ();
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
            E127Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7Z222( ) ;
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
            DisableAttributes7Z222( ) ;
         }
         AssignProp("", false, edtavCombocodigoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocodigoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboreloj_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreloj_id_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombohorarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombohorarioid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComborhtrabajadorcodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborhtrabajadorcodigo_Enabled), 5, 0), true);
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

      protected void CONFIRM_7Z0( )
      {
         BeforeValidate7Z222( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7Z222( ) ;
            }
            else
            {
               CheckExtendedTable7Z222( ) ;
               CloseExtendedTableCursors7Z222( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption7Z0( )
      {
      }

      protected void E117Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtRHTrabajadorCodigo_Visible = 0;
         AssignProp("", false, edtRHTrabajadorCodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRHTrabajadorCodigo_Visible), 5, 0), true);
         AV27ComboRHTrabajadorCodigo = "";
         AssignAttri("", false, "AV27ComboRHTrabajadorCodigo", AV27ComboRHTrabajadorCodigo);
         edtavComborhtrabajadorcodigo_Visible = 0;
         AssignProp("", false, edtavComborhtrabajadorcodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComborhtrabajadorcodigo_Visible), 5, 0), true);
         edtHorarioID_Visible = 0;
         AssignProp("", false, edtHorarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHorarioID_Visible), 5, 0), true);
         AV34ComboHorarioID = 0;
         AssignAttri("", false, "AV34ComboHorarioID", StringUtil.LTrimStr( (decimal)(AV34ComboHorarioID), 4, 0));
         edtavCombohorarioid_Visible = 0;
         AssignProp("", false, edtavCombohorarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombohorarioid_Visible), 5, 0), true);
         edtReloj_ID_Visible = 0;
         AssignProp("", false, edtReloj_ID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReloj_ID_Visible), 5, 0), true);
         AV31ComboReloj_ID = 0;
         AssignAttri("", false, "AV31ComboReloj_ID", StringUtil.LTrimStr( (decimal)(AV31ComboReloj_ID), 4, 0));
         edtavComboreloj_id_Visible = 0;
         AssignProp("", false, edtavComboreloj_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreloj_id_Visible), 5, 0), true);
         edtCodigoId_Visible = 0;
         AssignProp("", false, edtCodigoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCodigoId_Visible), 5, 0), true);
         AV37ComboCodigoId = "";
         AssignAttri("", false, "AV37ComboCodigoId", AV37ComboCodigoId);
         edtavCombocodigoid_Visible = 0;
         AssignProp("", false, edtavCombocodigoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocodigoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCODIGOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBORELOJ_ID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOHORARIOID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBORHTRABAJADORCODIGO' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV39Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV40GXV1 = 1;
            AssignAttri("", false, "AV40GXV1", StringUtil.LTrimStr( (decimal)(AV40GXV1), 8, 0));
            while ( AV40GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV40GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "Reloj_ID") == 0 )
               {
                  AV23Insert_Reloj_ID = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV23Insert_Reloj_ID", StringUtil.LTrimStr( (decimal)(AV23Insert_Reloj_ID), 4, 0));
                  if ( ! (0==AV23Insert_Reloj_ID) )
                  {
                     AV31ComboReloj_ID = AV23Insert_Reloj_ID;
                     AssignAttri("", false, "AV31ComboReloj_ID", StringUtil.LTrimStr( (decimal)(AV31ComboReloj_ID), 4, 0));
                     Combo_reloj_id_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV31ComboReloj_ID), 4, 0));
                     ucCombo_reloj_id.SendProperty(context, "", false, Combo_reloj_id_Internalname, "SelectedValue_set", Combo_reloj_id_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "Reloj_ID",  "GET",  false,  AV29CodigoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_reloj_id_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_reloj_id.SendProperty(context, "", false, Combo_reloj_id_Internalname, "SelectedText_set", Combo_reloj_id_Selectedtext_set);
                     Combo_reloj_id_Enabled = false;
                     ucCombo_reloj_id.SendProperty(context, "", false, Combo_reloj_id_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reloj_id_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "RHTrabajadorCodigo") == 0 )
               {
                  AV24Insert_RHTrabajadorCodigo = AV13TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV24Insert_RHTrabajadorCodigo", AV24Insert_RHTrabajadorCodigo);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Insert_RHTrabajadorCodigo)) )
                  {
                     AV27ComboRHTrabajadorCodigo = AV24Insert_RHTrabajadorCodigo;
                     AssignAttri("", false, "AV27ComboRHTrabajadorCodigo", AV27ComboRHTrabajadorCodigo);
                     Combo_rhtrabajadorcodigo_Selectedvalue_set = AV27ComboRHTrabajadorCodigo;
                     ucCombo_rhtrabajadorcodigo.SendProperty(context, "", false, Combo_rhtrabajadorcodigo_Internalname, "SelectedValue_set", Combo_rhtrabajadorcodigo_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "RHTrabajadorCodigo",  "GET",  false,  AV29CodigoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_rhtrabajadorcodigo_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_rhtrabajadorcodigo.SendProperty(context, "", false, Combo_rhtrabajadorcodigo_Internalname, "SelectedText_set", Combo_rhtrabajadorcodigo_Selectedtext_set);
                     Combo_rhtrabajadorcodigo_Enabled = false;
                     ucCombo_rhtrabajadorcodigo.SendProperty(context, "", false, Combo_rhtrabajadorcodigo_Internalname, "Enabled", StringUtil.BoolToStr( Combo_rhtrabajadorcodigo_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "HorarioID") == 0 )
               {
                  AV25Insert_HorarioID = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV25Insert_HorarioID", StringUtil.LTrimStr( (decimal)(AV25Insert_HorarioID), 4, 0));
                  if ( ! (0==AV25Insert_HorarioID) )
                  {
                     AV34ComboHorarioID = AV25Insert_HorarioID;
                     AssignAttri("", false, "AV34ComboHorarioID", StringUtil.LTrimStr( (decimal)(AV34ComboHorarioID), 4, 0));
                     Combo_horarioid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV34ComboHorarioID), 4, 0));
                     ucCombo_horarioid.SendProperty(context, "", false, Combo_horarioid_Internalname, "SelectedValue_set", Combo_horarioid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "HorarioID",  "GET",  false,  AV29CodigoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_horarioid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_horarioid.SendProperty(context, "", false, Combo_horarioid_Internalname, "SelectedText_set", Combo_horarioid_Selectedtext_set);
                     Combo_horarioid_Enabled = false;
                     ucCombo_horarioid.SendProperty(context, "", false, Combo_horarioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_horarioid_Enabled));
                  }
               }
               AV40GXV1 = (int)(AV40GXV1+1);
               AssignAttri("", false, "AV40GXV1", StringUtil.LTrimStr( (decimal)(AV40GXV1), 8, 0));
            }
         }
      }

      protected void E127Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("reloj_interface.reloj_codigoidww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S142( )
      {
         /* 'LOADCOMBORHTRABAJADORCODIGO' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "RHTrabajadorCodigo",  Gx_mode,  false,  AV29CodigoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_rhtrabajadorcodigo_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_rhtrabajadorcodigo.SendProperty(context, "", false, Combo_rhtrabajadorcodigo_Internalname, "SelectedValue_set", Combo_rhtrabajadorcodigo_Selectedvalue_set);
         Combo_rhtrabajadorcodigo_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_rhtrabajadorcodigo.SendProperty(context, "", false, Combo_rhtrabajadorcodigo_Internalname, "SelectedText_set", Combo_rhtrabajadorcodigo_Selectedtext_set);
         AV27ComboRHTrabajadorCodigo = AV16ComboSelectedValue;
         AssignAttri("", false, "AV27ComboRHTrabajadorCodigo", AV27ComboRHTrabajadorCodigo);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_rhtrabajadorcodigo_Enabled = false;
            ucCombo_rhtrabajadorcodigo.SendProperty(context, "", false, Combo_rhtrabajadorcodigo_Internalname, "Enabled", StringUtil.BoolToStr( Combo_rhtrabajadorcodigo_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOHORARIOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "HorarioID",  Gx_mode,  false,  AV29CodigoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_horarioid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_horarioid.SendProperty(context, "", false, Combo_horarioid_Internalname, "SelectedValue_set", Combo_horarioid_Selectedvalue_set);
         Combo_horarioid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_horarioid.SendProperty(context, "", false, Combo_horarioid_Internalname, "SelectedText_set", Combo_horarioid_Selectedtext_set);
         AV34ComboHorarioID = (short)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV34ComboHorarioID", StringUtil.LTrimStr( (decimal)(AV34ComboHorarioID), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_horarioid_Enabled = false;
            ucCombo_horarioid.SendProperty(context, "", false, Combo_horarioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_horarioid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBORELOJ_ID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "Reloj_ID",  Gx_mode,  false,  AV29CodigoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_reloj_id_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_reloj_id.SendProperty(context, "", false, Combo_reloj_id_Internalname, "SelectedValue_set", Combo_reloj_id_Selectedvalue_set);
         Combo_reloj_id_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_reloj_id.SendProperty(context, "", false, Combo_reloj_id_Internalname, "SelectedText_set", Combo_reloj_id_Selectedtext_set);
         AV31ComboReloj_ID = (short)(NumberUtil.Val( AV16ComboSelectedValue, "."));
         AssignAttri("", false, "AV31ComboReloj_ID", StringUtil.LTrimStr( (decimal)(AV31ComboReloj_ID), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_reloj_id_Enabled = false;
            ucCombo_reloj_id.SendProperty(context, "", false, Combo_reloj_id_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reloj_id_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCODIGOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo(context ).execute(  "CodigoId",  Gx_mode,  false,  AV29CodigoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         AV36CodigoId_Data.FromJSonString(AV18Combo_DataJson, null);
         Combo_codigoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_codigoid.SendProperty(context, "", false, Combo_codigoid_Internalname, "SelectedValue_set", Combo_codigoid_Selectedvalue_set);
         AV37ComboCodigoId = AV16ComboSelectedValue;
         AssignAttri("", false, "AV37ComboCodigoId", AV37ComboCodigoId);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CodigoId)) )
         {
            Combo_codigoid_Enabled = false;
            ucCombo_codigoid.SendProperty(context, "", false, Combo_codigoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_codigoid_Enabled));
         }
      }

      protected void ZM7Z222( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2415Lectura_Ini = T007Z3_A2415Lectura_Ini[0];
               Z2416Lectura_Fin = T007Z3_A2416Lectura_Fin[0];
               Z2589RHTrabajadorCodigo = T007Z3_A2589RHTrabajadorCodigo[0];
               Z2498Reloj_ID = T007Z3_A2498Reloj_ID[0];
               Z2591HorarioID = T007Z3_A2591HorarioID[0];
            }
            else
            {
               Z2415Lectura_Ini = A2415Lectura_Ini;
               Z2416Lectura_Fin = A2416Lectura_Fin;
               Z2589RHTrabajadorCodigo = A2589RHTrabajadorCodigo;
               Z2498Reloj_ID = A2498Reloj_ID;
               Z2591HorarioID = A2591HorarioID;
            }
         }
         if ( GX_JID == -19 )
         {
            Z2431CodigoId = A2431CodigoId;
            Z2415Lectura_Ini = A2415Lectura_Ini;
            Z2416Lectura_Fin = A2416Lectura_Fin;
            Z2589RHTrabajadorCodigo = A2589RHTrabajadorCodigo;
            Z2498Reloj_ID = A2498Reloj_ID;
            Z2591HorarioID = A2591HorarioID;
            Z2592Reloj_Nombre = A2592Reloj_Nombre;
            Z2525TrabApePat = A2525TrabApePat;
            Z2526TrabApeMat = A2526TrabApeMat;
            Z2527TrabNombres = A2527TrabNombres;
            Z2593HorarioDescripcion = A2593HorarioDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         AV39Pgmname = "Reloj_Interface.Reloj_CodigoID";
         AssignAttri("", false, "AV39Pgmname", AV39Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CodigoId)) )
         {
            edtCodigoId_Enabled = 0;
            AssignProp("", false, edtCodigoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCodigoId_Enabled), 5, 0), true);
         }
         else
         {
            edtCodigoId_Enabled = 1;
            AssignProp("", false, edtCodigoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCodigoId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CodigoId)) )
         {
            edtCodigoId_Enabled = 0;
            AssignProp("", false, edtCodigoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCodigoId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CodigoId)) )
         {
            A2431CodigoId = AV29CodigoId;
            AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
         }
         else
         {
            A2431CodigoId = AV37ComboCodigoId;
            AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_Reloj_ID) )
         {
            edtReloj_ID_Enabled = 0;
            AssignProp("", false, edtReloj_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_ID_Enabled), 5, 0), true);
         }
         else
         {
            edtReloj_ID_Enabled = 1;
            AssignProp("", false, edtReloj_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_ID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Insert_RHTrabajadorCodigo)) )
         {
            edtRHTrabajadorCodigo_Enabled = 0;
            AssignProp("", false, edtRHTrabajadorCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRHTrabajadorCodigo_Enabled), 5, 0), true);
         }
         else
         {
            edtRHTrabajadorCodigo_Enabled = 1;
            AssignProp("", false, edtRHTrabajadorCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRHTrabajadorCodigo_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_HorarioID) )
         {
            edtHorarioID_Enabled = 0;
            AssignProp("", false, edtHorarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorarioID_Enabled), 5, 0), true);
         }
         else
         {
            edtHorarioID_Enabled = 1;
            AssignProp("", false, edtHorarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorarioID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_Reloj_ID) )
         {
            A2498Reloj_ID = AV23Insert_Reloj_ID;
            AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
         }
         else
         {
            A2498Reloj_ID = AV31ComboReloj_ID;
            AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_HorarioID) )
         {
            A2591HorarioID = AV25Insert_HorarioID;
            AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
         }
         else
         {
            A2591HorarioID = AV34ComboHorarioID;
            AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Insert_RHTrabajadorCodigo)) )
         {
            A2589RHTrabajadorCodigo = AV24Insert_RHTrabajadorCodigo;
            AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
         }
         else
         {
            A2589RHTrabajadorCodigo = AV27ComboRHTrabajadorCodigo;
            AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
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
         if ( IsIns( )  && (DateTime.MinValue==A2415Lectura_Ini) && ( Gx_BScreen == 0 ) )
         {
            A2415Lectura_Ini = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
            AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T007Z5 */
            pr_default.execute(3, new Object[] {A2498Reloj_ID});
            A2592Reloj_Nombre = T007Z5_A2592Reloj_Nombre[0];
            AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
            pr_default.close(3);
            /* Using cursor T007Z6 */
            pr_default.execute(4, new Object[] {A2591HorarioID});
            A2593HorarioDescripcion = T007Z6_A2593HorarioDescripcion[0];
            AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
            pr_default.close(4);
            /* Using cursor T007Z4 */
            pr_default.execute(2, new Object[] {A2589RHTrabajadorCodigo});
            A2525TrabApePat = T007Z4_A2525TrabApePat[0];
            n2525TrabApePat = T007Z4_n2525TrabApePat[0];
            A2526TrabApeMat = T007Z4_A2526TrabApeMat[0];
            n2526TrabApeMat = T007Z4_n2526TrabApeMat[0];
            A2527TrabNombres = T007Z4_A2527TrabNombres[0];
            n2527TrabNombres = T007Z4_n2527TrabNombres[0];
            pr_default.close(2);
            A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
            AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
         }
      }

      protected void Load7Z222( )
      {
         /* Using cursor T007Z7 */
         pr_default.execute(5, new Object[] {A2431CodigoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound222 = 1;
            A2592Reloj_Nombre = T007Z7_A2592Reloj_Nombre[0];
            AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
            A2415Lectura_Ini = T007Z7_A2415Lectura_Ini[0];
            AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
            A2416Lectura_Fin = T007Z7_A2416Lectura_Fin[0];
            n2416Lectura_Fin = T007Z7_n2416Lectura_Fin[0];
            AssignAttri("", false, "A2416Lectura_Fin", context.localUtil.TToC( A2416Lectura_Fin, 10, 8, 0, 3, "/", ":", " "));
            A2593HorarioDescripcion = T007Z7_A2593HorarioDescripcion[0];
            AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
            A2525TrabApePat = T007Z7_A2525TrabApePat[0];
            n2525TrabApePat = T007Z7_n2525TrabApePat[0];
            A2526TrabApeMat = T007Z7_A2526TrabApeMat[0];
            n2526TrabApeMat = T007Z7_n2526TrabApeMat[0];
            A2527TrabNombres = T007Z7_A2527TrabNombres[0];
            n2527TrabNombres = T007Z7_n2527TrabNombres[0];
            A2589RHTrabajadorCodigo = T007Z7_A2589RHTrabajadorCodigo[0];
            AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
            A2498Reloj_ID = T007Z7_A2498Reloj_ID[0];
            AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
            A2591HorarioID = T007Z7_A2591HorarioID[0];
            AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
            ZM7Z222( -19) ;
         }
         pr_default.close(5);
         OnLoadActions7Z222( ) ;
      }

      protected void OnLoadActions7Z222( )
      {
         A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
         AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
      }

      protected void CheckExtendedTable7Z222( )
      {
         nIsDirty_222 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T007Z5 */
         pr_default.execute(3, new Object[] {A2498Reloj_ID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_Reloj'.", "ForeignKeyNotFound", 1, "RELOJ_ID");
            AnyError = 1;
            GX_FocusControl = edtReloj_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2592Reloj_Nombre = T007Z5_A2592Reloj_Nombre[0];
         AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A2415Lectura_Ini) || ( A2415Lectura_Ini >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Lectura_Ini fuera de rango", "OutOfRange", 1, "LECTURA_INI");
            AnyError = 1;
            GX_FocusControl = edtLectura_Ini_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A2416Lectura_Fin) || ( A2416Lectura_Fin >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Lectura_Fin fuera de rango", "OutOfRange", 1, "LECTURA_FIN");
            AnyError = 1;
            GX_FocusControl = edtLectura_Fin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T007Z4 */
         pr_default.execute(2, new Object[] {A2589RHTrabajadorCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_Trabajador'.", "ForeignKeyNotFound", 1, "RHTRABAJADORCODIGO");
            AnyError = 1;
            GX_FocusControl = edtRHTrabajadorCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2525TrabApePat = T007Z4_A2525TrabApePat[0];
         n2525TrabApePat = T007Z4_n2525TrabApePat[0];
         A2526TrabApeMat = T007Z4_A2526TrabApeMat[0];
         n2526TrabApeMat = T007Z4_n2526TrabApeMat[0];
         A2527TrabNombres = T007Z4_A2527TrabNombres[0];
         n2527TrabNombres = T007Z4_n2527TrabNombres[0];
         pr_default.close(2);
         nIsDirty_222 = 1;
         A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
         AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
         /* Using cursor T007Z6 */
         pr_default.execute(4, new Object[] {A2591HorarioID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_horario'.", "ForeignKeyNotFound", 1, "HORARIOID");
            AnyError = 1;
            GX_FocusControl = edtHorarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2593HorarioDescripcion = T007Z6_A2593HorarioDescripcion[0];
         AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors7Z222( )
      {
         pr_default.close(3);
         pr_default.close(2);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( short A2498Reloj_ID )
      {
         /* Using cursor T007Z8 */
         pr_default.execute(6, new Object[] {A2498Reloj_ID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_Reloj'.", "ForeignKeyNotFound", 1, "RELOJ_ID");
            AnyError = 1;
            GX_FocusControl = edtReloj_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2592Reloj_Nombre = T007Z8_A2592Reloj_Nombre[0];
         AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2592Reloj_Nombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_20( string A2589RHTrabajadorCodigo )
      {
         /* Using cursor T007Z9 */
         pr_default.execute(7, new Object[] {A2589RHTrabajadorCodigo});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_Trabajador'.", "ForeignKeyNotFound", 1, "RHTRABAJADORCODIGO");
            AnyError = 1;
            GX_FocusControl = edtRHTrabajadorCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2525TrabApePat = T007Z9_A2525TrabApePat[0];
         n2525TrabApePat = T007Z9_n2525TrabApePat[0];
         A2526TrabApeMat = T007Z9_A2526TrabApeMat[0];
         n2526TrabApeMat = T007Z9_n2526TrabApeMat[0];
         A2527TrabNombres = T007Z9_A2527TrabNombres[0];
         n2527TrabNombres = T007Z9_n2527TrabNombres[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2525TrabApePat)+"\""+","+"\""+GXUtil.EncodeJSConstant( A2526TrabApeMat)+"\""+","+"\""+GXUtil.EncodeJSConstant( A2527TrabNombres)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_22( short A2591HorarioID )
      {
         /* Using cursor T007Z10 */
         pr_default.execute(8, new Object[] {A2591HorarioID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_horario'.", "ForeignKeyNotFound", 1, "HORARIOID");
            AnyError = 1;
            GX_FocusControl = edtHorarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2593HorarioDescripcion = T007Z10_A2593HorarioDescripcion[0];
         AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2593HorarioDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey7Z222( )
      {
         /* Using cursor T007Z11 */
         pr_default.execute(9, new Object[] {A2431CodigoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound222 = 1;
         }
         else
         {
            RcdFound222 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007Z3 */
         pr_default.execute(1, new Object[] {A2431CodigoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7Z222( 19) ;
            RcdFound222 = 1;
            A2431CodigoId = T007Z3_A2431CodigoId[0];
            AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
            A2415Lectura_Ini = T007Z3_A2415Lectura_Ini[0];
            AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
            A2416Lectura_Fin = T007Z3_A2416Lectura_Fin[0];
            n2416Lectura_Fin = T007Z3_n2416Lectura_Fin[0];
            AssignAttri("", false, "A2416Lectura_Fin", context.localUtil.TToC( A2416Lectura_Fin, 10, 8, 0, 3, "/", ":", " "));
            A2589RHTrabajadorCodigo = T007Z3_A2589RHTrabajadorCodigo[0];
            AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
            A2498Reloj_ID = T007Z3_A2498Reloj_ID[0];
            AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
            A2591HorarioID = T007Z3_A2591HorarioID[0];
            AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
            Z2431CodigoId = A2431CodigoId;
            sMode222 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7Z222( ) ;
            if ( AnyError == 1 )
            {
               RcdFound222 = 0;
               InitializeNonKey7Z222( ) ;
            }
            Gx_mode = sMode222;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound222 = 0;
            InitializeNonKey7Z222( ) ;
            sMode222 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode222;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7Z222( ) ;
         if ( RcdFound222 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound222 = 0;
         /* Using cursor T007Z12 */
         pr_default.execute(10, new Object[] {A2431CodigoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T007Z12_A2431CodigoId[0], A2431CodigoId) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T007Z12_A2431CodigoId[0], A2431CodigoId) > 0 ) ) )
            {
               A2431CodigoId = T007Z12_A2431CodigoId[0];
               AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
               RcdFound222 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound222 = 0;
         /* Using cursor T007Z13 */
         pr_default.execute(11, new Object[] {A2431CodigoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T007Z13_A2431CodigoId[0], A2431CodigoId) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T007Z13_A2431CodigoId[0], A2431CodigoId) < 0 ) ) )
            {
               A2431CodigoId = T007Z13_A2431CodigoId[0];
               AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
               RcdFound222 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7Z222( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCodigoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7Z222( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound222 == 1 )
            {
               if ( StringUtil.StrCmp(A2431CodigoId, Z2431CodigoId) != 0 )
               {
                  A2431CodigoId = Z2431CodigoId;
                  AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CODIGOID");
                  AnyError = 1;
                  GX_FocusControl = edtCodigoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCodigoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7Z222( ) ;
                  GX_FocusControl = edtCodigoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2431CodigoId, Z2431CodigoId) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtCodigoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7Z222( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CODIGOID");
                     AnyError = 1;
                     GX_FocusControl = edtCodigoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCodigoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7Z222( ) ;
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
         if ( StringUtil.StrCmp(A2431CodigoId, Z2431CodigoId) != 0 )
         {
            A2431CodigoId = Z2431CodigoId;
            AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CODIGOID");
            AnyError = 1;
            GX_FocusControl = edtCodigoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCodigoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7Z222( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007Z2 */
            pr_default.execute(0, new Object[] {A2431CodigoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj_CodigoID"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2415Lectura_Ini != T007Z2_A2415Lectura_Ini[0] ) || ( Z2416Lectura_Fin != T007Z2_A2416Lectura_Fin[0] ) || ( StringUtil.StrCmp(Z2589RHTrabajadorCodigo, T007Z2_A2589RHTrabajadorCodigo[0]) != 0 ) || ( Z2498Reloj_ID != T007Z2_A2498Reloj_ID[0] ) || ( Z2591HorarioID != T007Z2_A2591HorarioID[0] ) )
            {
               if ( Z2415Lectura_Ini != T007Z2_A2415Lectura_Ini[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_codigoid:[seudo value changed for attri]"+"Lectura_Ini");
                  GXUtil.WriteLogRaw("Old: ",Z2415Lectura_Ini);
                  GXUtil.WriteLogRaw("Current: ",T007Z2_A2415Lectura_Ini[0]);
               }
               if ( Z2416Lectura_Fin != T007Z2_A2416Lectura_Fin[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_codigoid:[seudo value changed for attri]"+"Lectura_Fin");
                  GXUtil.WriteLogRaw("Old: ",Z2416Lectura_Fin);
                  GXUtil.WriteLogRaw("Current: ",T007Z2_A2416Lectura_Fin[0]);
               }
               if ( StringUtil.StrCmp(Z2589RHTrabajadorCodigo, T007Z2_A2589RHTrabajadorCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_codigoid:[seudo value changed for attri]"+"RHTrabajadorCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z2589RHTrabajadorCodigo);
                  GXUtil.WriteLogRaw("Current: ",T007Z2_A2589RHTrabajadorCodigo[0]);
               }
               if ( Z2498Reloj_ID != T007Z2_A2498Reloj_ID[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_codigoid:[seudo value changed for attri]"+"Reloj_ID");
                  GXUtil.WriteLogRaw("Old: ",Z2498Reloj_ID);
                  GXUtil.WriteLogRaw("Current: ",T007Z2_A2498Reloj_ID[0]);
               }
               if ( Z2591HorarioID != T007Z2_A2591HorarioID[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_codigoid:[seudo value changed for attri]"+"HorarioID");
                  GXUtil.WriteLogRaw("Old: ",Z2591HorarioID);
                  GXUtil.WriteLogRaw("Current: ",T007Z2_A2591HorarioID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reloj_CodigoID"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7Z222( )
      {
         BeforeValidate7Z222( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7Z222( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7Z222( 0) ;
            CheckOptimisticConcurrency7Z222( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7Z222( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7Z222( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007Z14 */
                     pr_default.execute(12, new Object[] {A2431CodigoId, A2415Lectura_Ini, n2416Lectura_Fin, A2416Lectura_Fin, A2589RHTrabajadorCodigo, A2498Reloj_ID, A2591HorarioID});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj_CodigoID");
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
                           ResetCaption7Z0( ) ;
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
               Load7Z222( ) ;
            }
            EndLevel7Z222( ) ;
         }
         CloseExtendedTableCursors7Z222( ) ;
      }

      protected void Update7Z222( )
      {
         BeforeValidate7Z222( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7Z222( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7Z222( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7Z222( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7Z222( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007Z15 */
                     pr_default.execute(13, new Object[] {A2415Lectura_Ini, n2416Lectura_Fin, A2416Lectura_Fin, A2589RHTrabajadorCodigo, A2498Reloj_ID, A2591HorarioID, A2431CodigoId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj_CodigoID");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj_CodigoID"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7Z222( ) ;
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
            EndLevel7Z222( ) ;
         }
         CloseExtendedTableCursors7Z222( ) ;
      }

      protected void DeferredUpdate7Z222( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7Z222( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7Z222( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7Z222( ) ;
            AfterConfirm7Z222( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7Z222( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007Z16 */
                  pr_default.execute(14, new Object[] {A2431CodigoId});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("Reloj_CodigoID");
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
         sMode222 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7Z222( ) ;
         Gx_mode = sMode222;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7Z222( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007Z17 */
            pr_default.execute(15, new Object[] {A2498Reloj_ID});
            A2592Reloj_Nombre = T007Z17_A2592Reloj_Nombre[0];
            AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
            pr_default.close(15);
            /* Using cursor T007Z18 */
            pr_default.execute(16, new Object[] {A2589RHTrabajadorCodigo});
            A2525TrabApePat = T007Z18_A2525TrabApePat[0];
            n2525TrabApePat = T007Z18_n2525TrabApePat[0];
            A2526TrabApeMat = T007Z18_A2526TrabApeMat[0];
            n2526TrabApeMat = T007Z18_n2526TrabApeMat[0];
            A2527TrabNombres = T007Z18_A2527TrabNombres[0];
            n2527TrabNombres = T007Z18_n2527TrabNombres[0];
            pr_default.close(16);
            A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
            AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
            /* Using cursor T007Z19 */
            pr_default.execute(17, new Object[] {A2591HorarioID});
            A2593HorarioDescripcion = T007Z19_A2593HorarioDescripcion[0];
            AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
            pr_default.close(17);
         }
      }

      protected void EndLevel7Z222( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7Z222( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(15);
            pr_default.close(17);
            context.CommitDataStores("reloj_interface.reloj_codigoid",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(15);
            pr_default.close(17);
            context.RollbackDataStores("reloj_interface.reloj_codigoid",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7Z222( )
      {
         /* Scan By routine */
         /* Using cursor T007Z20 */
         pr_default.execute(18);
         RcdFound222 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound222 = 1;
            A2431CodigoId = T007Z20_A2431CodigoId[0];
            AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7Z222( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound222 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound222 = 1;
            A2431CodigoId = T007Z20_A2431CodigoId[0];
            AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
         }
      }

      protected void ScanEnd7Z222( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm7Z222( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7Z222( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7Z222( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7Z222( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7Z222( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7Z222( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7Z222( )
      {
         edtCodigoId_Enabled = 0;
         AssignProp("", false, edtCodigoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCodigoId_Enabled), 5, 0), true);
         edtReloj_ID_Enabled = 0;
         AssignProp("", false, edtReloj_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_ID_Enabled), 5, 0), true);
         edtReloj_Nombre_Enabled = 0;
         AssignProp("", false, edtReloj_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReloj_Nombre_Enabled), 5, 0), true);
         edtHorarioID_Enabled = 0;
         AssignProp("", false, edtHorarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorarioID_Enabled), 5, 0), true);
         edtHorarioDescripcion_Enabled = 0;
         AssignProp("", false, edtHorarioDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorarioDescripcion_Enabled), 5, 0), true);
         edtRHTrabajadorCodigo_Enabled = 0;
         AssignProp("", false, edtRHTrabajadorCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRHTrabajadorCodigo_Enabled), 5, 0), true);
         edtRHTrabajadorNombres_Enabled = 0;
         AssignProp("", false, edtRHTrabajadorNombres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRHTrabajadorNombres_Enabled), 5, 0), true);
         edtLectura_Ini_Enabled = 0;
         AssignProp("", false, edtLectura_Ini_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLectura_Ini_Enabled), 5, 0), true);
         edtLectura_Fin_Enabled = 0;
         AssignProp("", false, edtLectura_Fin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLectura_Fin_Enabled), 5, 0), true);
         edtavCombocodigoid_Enabled = 0;
         AssignProp("", false, edtavCombocodigoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocodigoid_Enabled), 5, 0), true);
         edtavComboreloj_id_Enabled = 0;
         AssignProp("", false, edtavComboreloj_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreloj_id_Enabled), 5, 0), true);
         edtavCombohorarioid_Enabled = 0;
         AssignProp("", false, edtavCombohorarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombohorarioid_Enabled), 5, 0), true);
         edtavComborhtrabajadorcodigo_Enabled = 0;
         AssignProp("", false, edtavComborhtrabajadorcodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborhtrabajadorcodigo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7Z222( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7Z0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181495430", false, true);
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
         GXEncryptionTmp = "reloj_interface.reloj_codigoid.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV29CodigoId));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.reloj_codigoid.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Reloj_CodigoID");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("reloj_interface\\reloj_codigoid:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2431CodigoId", Z2431CodigoId);
         GxWebStd.gx_hidden_field( context, "Z2415Lectura_Ini", context.localUtil.TToC( Z2415Lectura_Ini, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2416Lectura_Fin", context.localUtil.TToC( Z2416Lectura_Fin, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2589RHTrabajadorCodigo", Z2589RHTrabajadorCodigo);
         GxWebStd.gx_hidden_field( context, "Z2498Reloj_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2498Reloj_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2591HorarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2591HorarioID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N2498Reloj_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2498Reloj_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
         GxWebStd.gx_hidden_field( context, "N2591HorarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2591HorarioID), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCODIGOID_DATA", AV36CodigoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCODIGOID_DATA", AV36CodigoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRELOJ_ID_DATA", AV30Reloj_ID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRELOJ_ID_DATA", AV30Reloj_ID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHORARIOID_DATA", AV33HorarioID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHORARIOID_DATA", AV33HorarioID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRHTRABAJADORCODIGO_DATA", AV26RHTrabajadorCodigo_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRHTRABAJADORCODIGO_DATA", AV26RHTrabajadorCodigo_Data);
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
         GxWebStd.gx_hidden_field( context, "TRABAPEPAT", A2525TrabApePat);
         GxWebStd.gx_hidden_field( context, "TRABAPEMAT", A2526TrabApeMat);
         GxWebStd.gx_hidden_field( context, "TRABNOMBRES", A2527TrabNombres);
         GxWebStd.gx_hidden_field( context, "vCODIGOID", AV29CodigoId);
         GxWebStd.gx_hidden_field( context, "gxhash_vCODIGOID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29CodigoId, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_RELOJ_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Insert_Reloj_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_RHTRABAJADORCODIGO", AV24Insert_RHTrabajadorCodigo);
         GxWebStd.gx_hidden_field( context, "vINSERT_HORARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Insert_HorarioID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CODIGOID_Objectcall", StringUtil.RTrim( Combo_codigoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CODIGOID_Cls", StringUtil.RTrim( Combo_codigoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CODIGOID_Selectedvalue_set", StringUtil.RTrim( Combo_codigoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CODIGOID_Enabled", StringUtil.BoolToStr( Combo_codigoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CODIGOID_Emptyitem", StringUtil.BoolToStr( Combo_codigoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Objectcall", StringUtil.RTrim( Combo_reloj_id_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Cls", StringUtil.RTrim( Combo_reloj_id_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Selectedvalue_set", StringUtil.RTrim( Combo_reloj_id_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Selectedtext_set", StringUtil.RTrim( Combo_reloj_id_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Enabled", StringUtil.BoolToStr( Combo_reloj_id_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Datalistproc", StringUtil.RTrim( Combo_reloj_id_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_reloj_id_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_RELOJ_ID_Emptyitem", StringUtil.BoolToStr( Combo_reloj_id_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Objectcall", StringUtil.RTrim( Combo_horarioid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Cls", StringUtil.RTrim( Combo_horarioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Selectedvalue_set", StringUtil.RTrim( Combo_horarioid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Selectedtext_set", StringUtil.RTrim( Combo_horarioid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Enabled", StringUtil.BoolToStr( Combo_horarioid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Datalistproc", StringUtil.RTrim( Combo_horarioid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_horarioid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_HORARIOID_Emptyitem", StringUtil.BoolToStr( Combo_horarioid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Objectcall", StringUtil.RTrim( Combo_rhtrabajadorcodigo_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Cls", StringUtil.RTrim( Combo_rhtrabajadorcodigo_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Selectedvalue_set", StringUtil.RTrim( Combo_rhtrabajadorcodigo_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Selectedtext_set", StringUtil.RTrim( Combo_rhtrabajadorcodigo_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Enabled", StringUtil.BoolToStr( Combo_rhtrabajadorcodigo_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Datalistproc", StringUtil.RTrim( Combo_rhtrabajadorcodigo_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_rhtrabajadorcodigo_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_RHTRABAJADORCODIGO_Emptyitem", StringUtil.BoolToStr( Combo_rhtrabajadorcodigo_Emptyitem));
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
         GXEncryptionTmp = "reloj_interface.reloj_codigoid.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV29CodigoId));
         return formatLink("reloj_interface.reloj_codigoid.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Reloj_CodigoID" ;
      }

      public override string GetPgmdesc( )
      {
         return "Enrolar Codigos del Reloj Con Trabajador" ;
      }

      protected void InitializeNonKey7Z222( )
      {
         A2498Reloj_ID = 0;
         AssignAttri("", false, "A2498Reloj_ID", StringUtil.LTrimStr( (decimal)(A2498Reloj_ID), 4, 0));
         A2589RHTrabajadorCodigo = "";
         AssignAttri("", false, "A2589RHTrabajadorCodigo", A2589RHTrabajadorCodigo);
         A2591HorarioID = 0;
         AssignAttri("", false, "A2591HorarioID", StringUtil.LTrimStr( (decimal)(A2591HorarioID), 4, 0));
         A2592Reloj_Nombre = "";
         AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
         A2416Lectura_Fin = (DateTime)(DateTime.MinValue);
         n2416Lectura_Fin = false;
         AssignAttri("", false, "A2416Lectura_Fin", context.localUtil.TToC( A2416Lectura_Fin, 10, 8, 0, 3, "/", ":", " "));
         n2416Lectura_Fin = ((DateTime.MinValue==A2416Lectura_Fin) ? true : false);
         A2590RHTrabajadorNombres = "";
         AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
         A2593HorarioDescripcion = "";
         AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
         A2525TrabApePat = "";
         n2525TrabApePat = false;
         AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
         A2526TrabApeMat = "";
         n2526TrabApeMat = false;
         AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
         A2527TrabNombres = "";
         n2527TrabNombres = false;
         AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
         A2415Lectura_Ini = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
         Z2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         Z2416Lectura_Fin = (DateTime)(DateTime.MinValue);
         Z2589RHTrabajadorCodigo = "";
         Z2498Reloj_ID = 0;
         Z2591HorarioID = 0;
      }

      protected void InitAll7Z222( )
      {
         A2431CodigoId = "";
         AssignAttri("", false, "A2431CodigoId", A2431CodigoId);
         InitializeNonKey7Z222( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A2415Lectura_Ini = i2415Lectura_Ini;
         AssignAttri("", false, "A2415Lectura_Ini", context.localUtil.TToC( A2415Lectura_Ini, 10, 8, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181495471", true, true);
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
         context.AddJavascriptSource("reloj_interface/reloj_codigoid.js", "?20228181495472", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblockcodigoid_Internalname = "TEXTBLOCKCODIGOID";
         Combo_codigoid_Internalname = "COMBO_CODIGOID";
         edtCodigoId_Internalname = "CODIGOID";
         divTablesplittedcodigoid_Internalname = "TABLESPLITTEDCODIGOID";
         lblTextblockreloj_id_Internalname = "TEXTBLOCKRELOJ_ID";
         Combo_reloj_id_Internalname = "COMBO_RELOJ_ID";
         edtReloj_ID_Internalname = "RELOJ_ID";
         divTablesplittedreloj_id_Internalname = "TABLESPLITTEDRELOJ_ID";
         edtReloj_Nombre_Internalname = "RELOJ_NOMBRE";
         lblTextblockhorarioid_Internalname = "TEXTBLOCKHORARIOID";
         Combo_horarioid_Internalname = "COMBO_HORARIOID";
         edtHorarioID_Internalname = "HORARIOID";
         divTablesplittedhorarioid_Internalname = "TABLESPLITTEDHORARIOID";
         edtHorarioDescripcion_Internalname = "HORARIODESCRIPCION";
         lblTextblockrhtrabajadorcodigo_Internalname = "TEXTBLOCKRHTRABAJADORCODIGO";
         Combo_rhtrabajadorcodigo_Internalname = "COMBO_RHTRABAJADORCODIGO";
         edtRHTrabajadorCodigo_Internalname = "RHTRABAJADORCODIGO";
         divTablesplittedrhtrabajadorcodigo_Internalname = "TABLESPLITTEDRHTRABAJADORCODIGO";
         edtRHTrabajadorNombres_Internalname = "RHTRABAJADORNOMBRES";
         edtLectura_Ini_Internalname = "LECTURA_INI";
         edtLectura_Fin_Internalname = "LECTURA_FIN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocodigoid_Internalname = "vCOMBOCODIGOID";
         divSectionattribute_codigoid_Internalname = "SECTIONATTRIBUTE_CODIGOID";
         edtavComboreloj_id_Internalname = "vCOMBORELOJ_ID";
         divSectionattribute_reloj_id_Internalname = "SECTIONATTRIBUTE_RELOJ_ID";
         edtavCombohorarioid_Internalname = "vCOMBOHORARIOID";
         divSectionattribute_horarioid_Internalname = "SECTIONATTRIBUTE_HORARIOID";
         edtavComborhtrabajadorcodigo_Internalname = "vCOMBORHTRABAJADORCODIGO";
         divSectionattribute_rhtrabajadorcodigo_Internalname = "SECTIONATTRIBUTE_RHTRABAJADORCODIGO";
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
         Form.Caption = "Enrolar Codigos del Reloj Con Trabajador";
         edtavComborhtrabajadorcodigo_Jsonclick = "";
         edtavComborhtrabajadorcodigo_Enabled = 0;
         edtavComborhtrabajadorcodigo_Visible = 1;
         edtavCombohorarioid_Jsonclick = "";
         edtavCombohorarioid_Enabled = 0;
         edtavCombohorarioid_Visible = 1;
         edtavComboreloj_id_Jsonclick = "";
         edtavComboreloj_id_Enabled = 0;
         edtavComboreloj_id_Visible = 1;
         edtavCombocodigoid_Jsonclick = "";
         edtavCombocodigoid_Enabled = 0;
         edtavCombocodigoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLectura_Fin_Jsonclick = "";
         edtLectura_Fin_Enabled = 1;
         edtLectura_Ini_Jsonclick = "";
         edtLectura_Ini_Enabled = 1;
         edtRHTrabajadorNombres_Enabled = 0;
         edtRHTrabajadorCodigo_Jsonclick = "";
         edtRHTrabajadorCodigo_Enabled = 1;
         edtRHTrabajadorCodigo_Visible = 1;
         Combo_rhtrabajadorcodigo_Emptyitem = Convert.ToBoolean( 0);
         Combo_rhtrabajadorcodigo_Datalistprocparametersprefix = " \"ComboName\": \"RHTrabajadorCodigo\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CodigoId\": \"\"";
         Combo_rhtrabajadorcodigo_Datalistproc = "Reloj_Interface.Reloj_CodigoIDLoadDVCombo";
         Combo_rhtrabajadorcodigo_Cls = "ExtendedCombo Attribute";
         Combo_rhtrabajadorcodigo_Caption = "";
         Combo_rhtrabajadorcodigo_Enabled = Convert.ToBoolean( -1);
         edtHorarioDescripcion_Jsonclick = "";
         edtHorarioDescripcion_Enabled = 0;
         edtHorarioID_Jsonclick = "";
         edtHorarioID_Enabled = 1;
         edtHorarioID_Visible = 1;
         Combo_horarioid_Emptyitem = Convert.ToBoolean( 0);
         Combo_horarioid_Datalistprocparametersprefix = " \"ComboName\": \"HorarioID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CodigoId\": \"\"";
         Combo_horarioid_Datalistproc = "Reloj_Interface.Reloj_CodigoIDLoadDVCombo";
         Combo_horarioid_Cls = "ExtendedCombo Attribute";
         Combo_horarioid_Caption = "";
         Combo_horarioid_Enabled = Convert.ToBoolean( -1);
         edtReloj_Nombre_Jsonclick = "";
         edtReloj_Nombre_Enabled = 0;
         edtReloj_ID_Jsonclick = "";
         edtReloj_ID_Enabled = 1;
         edtReloj_ID_Visible = 1;
         Combo_reloj_id_Emptyitem = Convert.ToBoolean( 0);
         Combo_reloj_id_Datalistprocparametersprefix = " \"ComboName\": \"Reloj_ID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CodigoId\": \"\"";
         Combo_reloj_id_Datalistproc = "Reloj_Interface.Reloj_CodigoIDLoadDVCombo";
         Combo_reloj_id_Cls = "ExtendedCombo Attribute";
         Combo_reloj_id_Caption = "";
         Combo_reloj_id_Enabled = Convert.ToBoolean( -1);
         edtCodigoId_Jsonclick = "";
         edtCodigoId_Enabled = 1;
         edtCodigoId_Visible = 1;
         Combo_codigoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_codigoid_Cls = "ExtendedCombo Attribute";
         Combo_codigoid_Caption = "";
         Combo_codigoid_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Reloj_id( )
      {
         /* Using cursor T007Z17 */
         pr_default.execute(15, new Object[] {A2498Reloj_ID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_Reloj'.", "ForeignKeyNotFound", 1, "RELOJ_ID");
            AnyError = 1;
            GX_FocusControl = edtReloj_ID_Internalname;
         }
         A2592Reloj_Nombre = T007Z17_A2592Reloj_Nombre[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2592Reloj_Nombre", A2592Reloj_Nombre);
      }

      public void Valid_Horarioid( )
      {
         /* Using cursor T007Z19 */
         pr_default.execute(17, new Object[] {A2591HorarioID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_horario'.", "ForeignKeyNotFound", 1, "HORARIOID");
            AnyError = 1;
            GX_FocusControl = edtHorarioID_Internalname;
         }
         A2593HorarioDescripcion = T007Z19_A2593HorarioDescripcion[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2593HorarioDescripcion", A2593HorarioDescripcion);
      }

      public void Valid_Rhtrabajadorcodigo( )
      {
         n2525TrabApePat = false;
         n2526TrabApeMat = false;
         n2527TrabNombres = false;
         /* Using cursor T007Z18 */
         pr_default.execute(16, new Object[] {A2589RHTrabajadorCodigo});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub_Trabajador'.", "ForeignKeyNotFound", 1, "RHTRABAJADORCODIGO");
            AnyError = 1;
            GX_FocusControl = edtRHTrabajadorCodigo_Internalname;
         }
         A2525TrabApePat = T007Z18_A2525TrabApePat[0];
         n2525TrabApePat = T007Z18_n2525TrabApePat[0];
         A2526TrabApeMat = T007Z18_A2526TrabApeMat[0];
         n2526TrabApeMat = T007Z18_n2526TrabApeMat[0];
         A2527TrabNombres = T007Z18_A2527TrabNombres[0];
         n2527TrabNombres = T007Z18_n2527TrabNombres[0];
         pr_default.close(16);
         A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
         AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
         AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
         AssignAttri("", false, "A2590RHTrabajadorNombres", A2590RHTrabajadorNombres);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV29CodigoId',fld:'vCODIGOID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV29CodigoId',fld:'vCODIGOID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E127Z2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CODIGOID","{handler:'Valid_Codigoid',iparms:[]");
         setEventMetadata("VALID_CODIGOID",",oparms:[]}");
         setEventMetadata("VALID_RELOJ_ID","{handler:'Valid_Reloj_id',iparms:[{av:'A2498Reloj_ID',fld:'RELOJ_ID',pic:'ZZZ9'},{av:'A2592Reloj_Nombre',fld:'RELOJ_NOMBRE',pic:''}]");
         setEventMetadata("VALID_RELOJ_ID",",oparms:[{av:'A2592Reloj_Nombre',fld:'RELOJ_NOMBRE',pic:''}]}");
         setEventMetadata("VALID_HORARIOID","{handler:'Valid_Horarioid',iparms:[{av:'A2591HorarioID',fld:'HORARIOID',pic:'ZZZ9'},{av:'A2593HorarioDescripcion',fld:'HORARIODESCRIPCION',pic:''}]");
         setEventMetadata("VALID_HORARIOID",",oparms:[{av:'A2593HorarioDescripcion',fld:'HORARIODESCRIPCION',pic:''}]}");
         setEventMetadata("VALID_RHTRABAJADORCODIGO","{handler:'Valid_Rhtrabajadorcodigo',iparms:[{av:'A2589RHTrabajadorCodigo',fld:'RHTRABAJADORCODIGO',pic:''},{av:'A2525TrabApePat',fld:'TRABAPEPAT',pic:''},{av:'A2526TrabApeMat',fld:'TRABAPEMAT',pic:''},{av:'A2527TrabNombres',fld:'TRABNOMBRES',pic:''},{av:'A2590RHTrabajadorNombres',fld:'RHTRABAJADORNOMBRES',pic:''}]");
         setEventMetadata("VALID_RHTRABAJADORCODIGO",",oparms:[{av:'A2525TrabApePat',fld:'TRABAPEPAT',pic:''},{av:'A2526TrabApeMat',fld:'TRABAPEMAT',pic:''},{av:'A2527TrabNombres',fld:'TRABNOMBRES',pic:''},{av:'A2590RHTrabajadorNombres',fld:'RHTRABAJADORNOMBRES',pic:''}]}");
         setEventMetadata("VALID_LECTURA_INI","{handler:'Valid_Lectura_ini',iparms:[]");
         setEventMetadata("VALID_LECTURA_INI",",oparms:[]}");
         setEventMetadata("VALID_LECTURA_FIN","{handler:'Valid_Lectura_fin',iparms:[]");
         setEventMetadata("VALID_LECTURA_FIN",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCODIGOID","{handler:'Validv_Combocodigoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOCODIGOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBORELOJ_ID","{handler:'Validv_Comboreloj_id',iparms:[]");
         setEventMetadata("VALIDV_COMBORELOJ_ID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOHORARIOID","{handler:'Validv_Combohorarioid',iparms:[]");
         setEventMetadata("VALIDV_COMBOHORARIOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBORHTRABAJADORCODIGO","{handler:'Validv_Comborhtrabajadorcodigo',iparms:[]");
         setEventMetadata("VALIDV_COMBORHTRABAJADORCODIGO",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV29CodigoId = "";
         Z2431CodigoId = "";
         Z2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         Z2416Lectura_Fin = (DateTime)(DateTime.MinValue);
         Z2589RHTrabajadorCodigo = "";
         N2589RHTrabajadorCodigo = "";
         Combo_rhtrabajadorcodigo_Selectedvalue_get = "";
         Combo_horarioid_Selectedvalue_get = "";
         Combo_reloj_id_Selectedvalue_get = "";
         Combo_codigoid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2589RHTrabajadorCodigo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcodigoid_Jsonclick = "";
         ucCombo_codigoid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36CodigoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A2431CodigoId = "";
         lblTextblockreloj_id_Jsonclick = "";
         ucCombo_reloj_id = new GXUserControl();
         AV30Reloj_ID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A2592Reloj_Nombre = "";
         lblTextblockhorarioid_Jsonclick = "";
         ucCombo_horarioid = new GXUserControl();
         AV33HorarioID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A2593HorarioDescripcion = "";
         lblTextblockrhtrabajadorcodigo_Jsonclick = "";
         ucCombo_rhtrabajadorcodigo = new GXUserControl();
         AV26RHTrabajadorCodigo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A2590RHTrabajadorNombres = "";
         A2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         A2416Lectura_Fin = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV37ComboCodigoId = "";
         AV27ComboRHTrabajadorCodigo = "";
         A2525TrabApePat = "";
         A2526TrabApeMat = "";
         A2527TrabNombres = "";
         AV24Insert_RHTrabajadorCodigo = "";
         AV39Pgmname = "";
         Combo_codigoid_Objectcall = "";
         Combo_codigoid_Class = "";
         Combo_codigoid_Icontype = "";
         Combo_codigoid_Icon = "";
         Combo_codigoid_Tooltip = "";
         Combo_codigoid_Selectedvalue_set = "";
         Combo_codigoid_Selectedtext_set = "";
         Combo_codigoid_Selectedtext_get = "";
         Combo_codigoid_Gamoauthtoken = "";
         Combo_codigoid_Ddointernalname = "";
         Combo_codigoid_Titlecontrolalign = "";
         Combo_codigoid_Dropdownoptionstype = "";
         Combo_codigoid_Titlecontrolidtoreplace = "";
         Combo_codigoid_Datalisttype = "";
         Combo_codigoid_Datalistfixedvalues = "";
         Combo_codigoid_Datalistproc = "";
         Combo_codigoid_Datalistprocparametersprefix = "";
         Combo_codigoid_Htmltemplate = "";
         Combo_codigoid_Multiplevaluestype = "";
         Combo_codigoid_Loadingdata = "";
         Combo_codigoid_Noresultsfound = "";
         Combo_codigoid_Emptyitemtext = "";
         Combo_codigoid_Onlyselectedvalues = "";
         Combo_codigoid_Selectalltext = "";
         Combo_codigoid_Multiplevaluesseparator = "";
         Combo_codigoid_Addnewoptiontext = "";
         Combo_reloj_id_Objectcall = "";
         Combo_reloj_id_Class = "";
         Combo_reloj_id_Icontype = "";
         Combo_reloj_id_Icon = "";
         Combo_reloj_id_Tooltip = "";
         Combo_reloj_id_Selectedvalue_set = "";
         Combo_reloj_id_Selectedtext_set = "";
         Combo_reloj_id_Selectedtext_get = "";
         Combo_reloj_id_Gamoauthtoken = "";
         Combo_reloj_id_Ddointernalname = "";
         Combo_reloj_id_Titlecontrolalign = "";
         Combo_reloj_id_Dropdownoptionstype = "";
         Combo_reloj_id_Titlecontrolidtoreplace = "";
         Combo_reloj_id_Datalisttype = "";
         Combo_reloj_id_Datalistfixedvalues = "";
         Combo_reloj_id_Htmltemplate = "";
         Combo_reloj_id_Multiplevaluestype = "";
         Combo_reloj_id_Loadingdata = "";
         Combo_reloj_id_Noresultsfound = "";
         Combo_reloj_id_Emptyitemtext = "";
         Combo_reloj_id_Onlyselectedvalues = "";
         Combo_reloj_id_Selectalltext = "";
         Combo_reloj_id_Multiplevaluesseparator = "";
         Combo_reloj_id_Addnewoptiontext = "";
         Combo_horarioid_Objectcall = "";
         Combo_horarioid_Class = "";
         Combo_horarioid_Icontype = "";
         Combo_horarioid_Icon = "";
         Combo_horarioid_Tooltip = "";
         Combo_horarioid_Selectedvalue_set = "";
         Combo_horarioid_Selectedtext_set = "";
         Combo_horarioid_Selectedtext_get = "";
         Combo_horarioid_Gamoauthtoken = "";
         Combo_horarioid_Ddointernalname = "";
         Combo_horarioid_Titlecontrolalign = "";
         Combo_horarioid_Dropdownoptionstype = "";
         Combo_horarioid_Titlecontrolidtoreplace = "";
         Combo_horarioid_Datalisttype = "";
         Combo_horarioid_Datalistfixedvalues = "";
         Combo_horarioid_Htmltemplate = "";
         Combo_horarioid_Multiplevaluestype = "";
         Combo_horarioid_Loadingdata = "";
         Combo_horarioid_Noresultsfound = "";
         Combo_horarioid_Emptyitemtext = "";
         Combo_horarioid_Onlyselectedvalues = "";
         Combo_horarioid_Selectalltext = "";
         Combo_horarioid_Multiplevaluesseparator = "";
         Combo_horarioid_Addnewoptiontext = "";
         Combo_rhtrabajadorcodigo_Objectcall = "";
         Combo_rhtrabajadorcodigo_Class = "";
         Combo_rhtrabajadorcodigo_Icontype = "";
         Combo_rhtrabajadorcodigo_Icon = "";
         Combo_rhtrabajadorcodigo_Tooltip = "";
         Combo_rhtrabajadorcodigo_Selectedvalue_set = "";
         Combo_rhtrabajadorcodigo_Selectedtext_set = "";
         Combo_rhtrabajadorcodigo_Selectedtext_get = "";
         Combo_rhtrabajadorcodigo_Gamoauthtoken = "";
         Combo_rhtrabajadorcodigo_Ddointernalname = "";
         Combo_rhtrabajadorcodigo_Titlecontrolalign = "";
         Combo_rhtrabajadorcodigo_Dropdownoptionstype = "";
         Combo_rhtrabajadorcodigo_Titlecontrolidtoreplace = "";
         Combo_rhtrabajadorcodigo_Datalisttype = "";
         Combo_rhtrabajadorcodigo_Datalistfixedvalues = "";
         Combo_rhtrabajadorcodigo_Htmltemplate = "";
         Combo_rhtrabajadorcodigo_Multiplevaluestype = "";
         Combo_rhtrabajadorcodigo_Loadingdata = "";
         Combo_rhtrabajadorcodigo_Noresultsfound = "";
         Combo_rhtrabajadorcodigo_Emptyitemtext = "";
         Combo_rhtrabajadorcodigo_Onlyselectedvalues = "";
         Combo_rhtrabajadorcodigo_Selectalltext = "";
         Combo_rhtrabajadorcodigo_Multiplevaluesseparator = "";
         Combo_rhtrabajadorcodigo_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode222 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         Z2592Reloj_Nombre = "";
         Z2525TrabApePat = "";
         Z2526TrabApeMat = "";
         Z2527TrabNombres = "";
         Z2593HorarioDescripcion = "";
         T007Z5_A2592Reloj_Nombre = new string[] {""} ;
         T007Z6_A2593HorarioDescripcion = new string[] {""} ;
         T007Z4_A2525TrabApePat = new string[] {""} ;
         T007Z4_n2525TrabApePat = new bool[] {false} ;
         T007Z4_A2526TrabApeMat = new string[] {""} ;
         T007Z4_n2526TrabApeMat = new bool[] {false} ;
         T007Z4_A2527TrabNombres = new string[] {""} ;
         T007Z4_n2527TrabNombres = new bool[] {false} ;
         T007Z7_A2431CodigoId = new string[] {""} ;
         T007Z7_A2592Reloj_Nombre = new string[] {""} ;
         T007Z7_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         T007Z7_A2416Lectura_Fin = new DateTime[] {DateTime.MinValue} ;
         T007Z7_n2416Lectura_Fin = new bool[] {false} ;
         T007Z7_A2593HorarioDescripcion = new string[] {""} ;
         T007Z7_A2525TrabApePat = new string[] {""} ;
         T007Z7_n2525TrabApePat = new bool[] {false} ;
         T007Z7_A2526TrabApeMat = new string[] {""} ;
         T007Z7_n2526TrabApeMat = new bool[] {false} ;
         T007Z7_A2527TrabNombres = new string[] {""} ;
         T007Z7_n2527TrabNombres = new bool[] {false} ;
         T007Z7_A2589RHTrabajadorCodigo = new string[] {""} ;
         T007Z7_A2498Reloj_ID = new short[1] ;
         T007Z7_A2591HorarioID = new short[1] ;
         T007Z8_A2592Reloj_Nombre = new string[] {""} ;
         T007Z9_A2525TrabApePat = new string[] {""} ;
         T007Z9_n2525TrabApePat = new bool[] {false} ;
         T007Z9_A2526TrabApeMat = new string[] {""} ;
         T007Z9_n2526TrabApeMat = new bool[] {false} ;
         T007Z9_A2527TrabNombres = new string[] {""} ;
         T007Z9_n2527TrabNombres = new bool[] {false} ;
         T007Z10_A2593HorarioDescripcion = new string[] {""} ;
         T007Z11_A2431CodigoId = new string[] {""} ;
         T007Z3_A2431CodigoId = new string[] {""} ;
         T007Z3_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         T007Z3_A2416Lectura_Fin = new DateTime[] {DateTime.MinValue} ;
         T007Z3_n2416Lectura_Fin = new bool[] {false} ;
         T007Z3_A2589RHTrabajadorCodigo = new string[] {""} ;
         T007Z3_A2498Reloj_ID = new short[1] ;
         T007Z3_A2591HorarioID = new short[1] ;
         T007Z12_A2431CodigoId = new string[] {""} ;
         T007Z13_A2431CodigoId = new string[] {""} ;
         T007Z2_A2431CodigoId = new string[] {""} ;
         T007Z2_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         T007Z2_A2416Lectura_Fin = new DateTime[] {DateTime.MinValue} ;
         T007Z2_n2416Lectura_Fin = new bool[] {false} ;
         T007Z2_A2589RHTrabajadorCodigo = new string[] {""} ;
         T007Z2_A2498Reloj_ID = new short[1] ;
         T007Z2_A2591HorarioID = new short[1] ;
         T007Z17_A2592Reloj_Nombre = new string[] {""} ;
         T007Z18_A2525TrabApePat = new string[] {""} ;
         T007Z18_n2525TrabApePat = new bool[] {false} ;
         T007Z18_A2526TrabApeMat = new string[] {""} ;
         T007Z18_n2526TrabApeMat = new bool[] {false} ;
         T007Z18_A2527TrabNombres = new string[] {""} ;
         T007Z18_n2527TrabNombres = new bool[] {false} ;
         T007Z19_A2593HorarioDescripcion = new string[] {""} ;
         T007Z20_A2431CodigoId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         Z2590RHTrabajadorNombres = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoid__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoid__default(),
            new Object[][] {
                new Object[] {
               T007Z2_A2431CodigoId, T007Z2_A2415Lectura_Ini, T007Z2_A2416Lectura_Fin, T007Z2_n2416Lectura_Fin, T007Z2_A2589RHTrabajadorCodigo, T007Z2_A2498Reloj_ID, T007Z2_A2591HorarioID
               }
               , new Object[] {
               T007Z3_A2431CodigoId, T007Z3_A2415Lectura_Ini, T007Z3_A2416Lectura_Fin, T007Z3_n2416Lectura_Fin, T007Z3_A2589RHTrabajadorCodigo, T007Z3_A2498Reloj_ID, T007Z3_A2591HorarioID
               }
               , new Object[] {
               T007Z4_A2525TrabApePat, T007Z4_n2525TrabApePat, T007Z4_A2526TrabApeMat, T007Z4_n2526TrabApeMat, T007Z4_A2527TrabNombres, T007Z4_n2527TrabNombres
               }
               , new Object[] {
               T007Z5_A2592Reloj_Nombre
               }
               , new Object[] {
               T007Z6_A2593HorarioDescripcion
               }
               , new Object[] {
               T007Z7_A2431CodigoId, T007Z7_A2592Reloj_Nombre, T007Z7_A2415Lectura_Ini, T007Z7_A2416Lectura_Fin, T007Z7_n2416Lectura_Fin, T007Z7_A2593HorarioDescripcion, T007Z7_A2525TrabApePat, T007Z7_n2525TrabApePat, T007Z7_A2526TrabApeMat, T007Z7_n2526TrabApeMat,
               T007Z7_A2527TrabNombres, T007Z7_n2527TrabNombres, T007Z7_A2589RHTrabajadorCodigo, T007Z7_A2498Reloj_ID, T007Z7_A2591HorarioID
               }
               , new Object[] {
               T007Z8_A2592Reloj_Nombre
               }
               , new Object[] {
               T007Z9_A2525TrabApePat, T007Z9_n2525TrabApePat, T007Z9_A2526TrabApeMat, T007Z9_n2526TrabApeMat, T007Z9_A2527TrabNombres, T007Z9_n2527TrabNombres
               }
               , new Object[] {
               T007Z10_A2593HorarioDescripcion
               }
               , new Object[] {
               T007Z11_A2431CodigoId
               }
               , new Object[] {
               T007Z12_A2431CodigoId
               }
               , new Object[] {
               T007Z13_A2431CodigoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007Z17_A2592Reloj_Nombre
               }
               , new Object[] {
               T007Z18_A2525TrabApePat, T007Z18_n2525TrabApePat, T007Z18_A2526TrabApeMat, T007Z18_n2526TrabApeMat, T007Z18_A2527TrabNombres, T007Z18_n2527TrabNombres
               }
               , new Object[] {
               T007Z19_A2593HorarioDescripcion
               }
               , new Object[] {
               T007Z20_A2431CodigoId
               }
            }
         );
         AV39Pgmname = "Reloj_Interface.Reloj_CodigoID";
         Z2415Lectura_Ini = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         A2415Lectura_Ini = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         i2415Lectura_Ini = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
      }

      private short Z2498Reloj_ID ;
      private short Z2591HorarioID ;
      private short N2498Reloj_ID ;
      private short N2591HorarioID ;
      private short GxWebError ;
      private short A2498Reloj_ID ;
      private short A2591HorarioID ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short AV31ComboReloj_ID ;
      private short AV34ComboHorarioID ;
      private short AV23Insert_Reloj_ID ;
      private short AV25Insert_HorarioID ;
      private short Gx_BScreen ;
      private short RcdFound222 ;
      private short GX_JID ;
      private short nIsDirty_222 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCodigoId_Visible ;
      private int edtCodigoId_Enabled ;
      private int edtReloj_ID_Visible ;
      private int edtReloj_ID_Enabled ;
      private int edtReloj_Nombre_Enabled ;
      private int edtHorarioID_Visible ;
      private int edtHorarioID_Enabled ;
      private int edtHorarioDescripcion_Enabled ;
      private int edtRHTrabajadorCodigo_Visible ;
      private int edtRHTrabajadorCodigo_Enabled ;
      private int edtRHTrabajadorNombres_Enabled ;
      private int edtLectura_Ini_Enabled ;
      private int edtLectura_Fin_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocodigoid_Visible ;
      private int edtavCombocodigoid_Enabled ;
      private int edtavComboreloj_id_Enabled ;
      private int edtavComboreloj_id_Visible ;
      private int edtavCombohorarioid_Enabled ;
      private int edtavCombohorarioid_Visible ;
      private int edtavComborhtrabajadorcodigo_Visible ;
      private int edtavComborhtrabajadorcodigo_Enabled ;
      private int Combo_codigoid_Datalistupdateminimumcharacters ;
      private int Combo_codigoid_Gxcontroltype ;
      private int Combo_reloj_id_Datalistupdateminimumcharacters ;
      private int Combo_reloj_id_Gxcontroltype ;
      private int Combo_horarioid_Datalistupdateminimumcharacters ;
      private int Combo_horarioid_Gxcontroltype ;
      private int Combo_rhtrabajadorcodigo_Datalistupdateminimumcharacters ;
      private int Combo_rhtrabajadorcodigo_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV40GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_rhtrabajadorcodigo_Selectedvalue_get ;
      private string Combo_horarioid_Selectedvalue_get ;
      private string Combo_reloj_id_Selectedvalue_get ;
      private string Combo_codigoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCodigoId_Internalname ;
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
      private string divTablesplittedcodigoid_Internalname ;
      private string lblTextblockcodigoid_Internalname ;
      private string lblTextblockcodigoid_Jsonclick ;
      private string Combo_codigoid_Caption ;
      private string Combo_codigoid_Cls ;
      private string Combo_codigoid_Internalname ;
      private string TempTags ;
      private string edtCodigoId_Jsonclick ;
      private string divTablesplittedreloj_id_Internalname ;
      private string lblTextblockreloj_id_Internalname ;
      private string lblTextblockreloj_id_Jsonclick ;
      private string Combo_reloj_id_Caption ;
      private string Combo_reloj_id_Cls ;
      private string Combo_reloj_id_Datalistproc ;
      private string Combo_reloj_id_Datalistprocparametersprefix ;
      private string Combo_reloj_id_Internalname ;
      private string edtReloj_ID_Internalname ;
      private string edtReloj_ID_Jsonclick ;
      private string edtReloj_Nombre_Internalname ;
      private string edtReloj_Nombre_Jsonclick ;
      private string divTablesplittedhorarioid_Internalname ;
      private string lblTextblockhorarioid_Internalname ;
      private string lblTextblockhorarioid_Jsonclick ;
      private string Combo_horarioid_Caption ;
      private string Combo_horarioid_Cls ;
      private string Combo_horarioid_Datalistproc ;
      private string Combo_horarioid_Datalistprocparametersprefix ;
      private string Combo_horarioid_Internalname ;
      private string edtHorarioID_Internalname ;
      private string edtHorarioID_Jsonclick ;
      private string edtHorarioDescripcion_Internalname ;
      private string edtHorarioDescripcion_Jsonclick ;
      private string divTablesplittedrhtrabajadorcodigo_Internalname ;
      private string lblTextblockrhtrabajadorcodigo_Internalname ;
      private string lblTextblockrhtrabajadorcodigo_Jsonclick ;
      private string Combo_rhtrabajadorcodigo_Caption ;
      private string Combo_rhtrabajadorcodigo_Cls ;
      private string Combo_rhtrabajadorcodigo_Datalistproc ;
      private string Combo_rhtrabajadorcodigo_Datalistprocparametersprefix ;
      private string Combo_rhtrabajadorcodigo_Internalname ;
      private string edtRHTrabajadorCodigo_Internalname ;
      private string edtRHTrabajadorCodigo_Jsonclick ;
      private string edtRHTrabajadorNombres_Internalname ;
      private string edtLectura_Ini_Internalname ;
      private string edtLectura_Ini_Jsonclick ;
      private string edtLectura_Fin_Internalname ;
      private string edtLectura_Fin_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_codigoid_Internalname ;
      private string edtavCombocodigoid_Internalname ;
      private string edtavCombocodigoid_Jsonclick ;
      private string divSectionattribute_reloj_id_Internalname ;
      private string edtavComboreloj_id_Internalname ;
      private string edtavComboreloj_id_Jsonclick ;
      private string divSectionattribute_horarioid_Internalname ;
      private string edtavCombohorarioid_Internalname ;
      private string edtavCombohorarioid_Jsonclick ;
      private string divSectionattribute_rhtrabajadorcodigo_Internalname ;
      private string edtavComborhtrabajadorcodigo_Internalname ;
      private string edtavComborhtrabajadorcodigo_Jsonclick ;
      private string AV39Pgmname ;
      private string Combo_codigoid_Objectcall ;
      private string Combo_codigoid_Class ;
      private string Combo_codigoid_Icontype ;
      private string Combo_codigoid_Icon ;
      private string Combo_codigoid_Tooltip ;
      private string Combo_codigoid_Selectedvalue_set ;
      private string Combo_codigoid_Selectedtext_set ;
      private string Combo_codigoid_Selectedtext_get ;
      private string Combo_codigoid_Gamoauthtoken ;
      private string Combo_codigoid_Ddointernalname ;
      private string Combo_codigoid_Titlecontrolalign ;
      private string Combo_codigoid_Dropdownoptionstype ;
      private string Combo_codigoid_Titlecontrolidtoreplace ;
      private string Combo_codigoid_Datalisttype ;
      private string Combo_codigoid_Datalistfixedvalues ;
      private string Combo_codigoid_Datalistproc ;
      private string Combo_codigoid_Datalistprocparametersprefix ;
      private string Combo_codigoid_Htmltemplate ;
      private string Combo_codigoid_Multiplevaluestype ;
      private string Combo_codigoid_Loadingdata ;
      private string Combo_codigoid_Noresultsfound ;
      private string Combo_codigoid_Emptyitemtext ;
      private string Combo_codigoid_Onlyselectedvalues ;
      private string Combo_codigoid_Selectalltext ;
      private string Combo_codigoid_Multiplevaluesseparator ;
      private string Combo_codigoid_Addnewoptiontext ;
      private string Combo_reloj_id_Objectcall ;
      private string Combo_reloj_id_Class ;
      private string Combo_reloj_id_Icontype ;
      private string Combo_reloj_id_Icon ;
      private string Combo_reloj_id_Tooltip ;
      private string Combo_reloj_id_Selectedvalue_set ;
      private string Combo_reloj_id_Selectedtext_set ;
      private string Combo_reloj_id_Selectedtext_get ;
      private string Combo_reloj_id_Gamoauthtoken ;
      private string Combo_reloj_id_Ddointernalname ;
      private string Combo_reloj_id_Titlecontrolalign ;
      private string Combo_reloj_id_Dropdownoptionstype ;
      private string Combo_reloj_id_Titlecontrolidtoreplace ;
      private string Combo_reloj_id_Datalisttype ;
      private string Combo_reloj_id_Datalistfixedvalues ;
      private string Combo_reloj_id_Htmltemplate ;
      private string Combo_reloj_id_Multiplevaluestype ;
      private string Combo_reloj_id_Loadingdata ;
      private string Combo_reloj_id_Noresultsfound ;
      private string Combo_reloj_id_Emptyitemtext ;
      private string Combo_reloj_id_Onlyselectedvalues ;
      private string Combo_reloj_id_Selectalltext ;
      private string Combo_reloj_id_Multiplevaluesseparator ;
      private string Combo_reloj_id_Addnewoptiontext ;
      private string Combo_horarioid_Objectcall ;
      private string Combo_horarioid_Class ;
      private string Combo_horarioid_Icontype ;
      private string Combo_horarioid_Icon ;
      private string Combo_horarioid_Tooltip ;
      private string Combo_horarioid_Selectedvalue_set ;
      private string Combo_horarioid_Selectedtext_set ;
      private string Combo_horarioid_Selectedtext_get ;
      private string Combo_horarioid_Gamoauthtoken ;
      private string Combo_horarioid_Ddointernalname ;
      private string Combo_horarioid_Titlecontrolalign ;
      private string Combo_horarioid_Dropdownoptionstype ;
      private string Combo_horarioid_Titlecontrolidtoreplace ;
      private string Combo_horarioid_Datalisttype ;
      private string Combo_horarioid_Datalistfixedvalues ;
      private string Combo_horarioid_Htmltemplate ;
      private string Combo_horarioid_Multiplevaluestype ;
      private string Combo_horarioid_Loadingdata ;
      private string Combo_horarioid_Noresultsfound ;
      private string Combo_horarioid_Emptyitemtext ;
      private string Combo_horarioid_Onlyselectedvalues ;
      private string Combo_horarioid_Selectalltext ;
      private string Combo_horarioid_Multiplevaluesseparator ;
      private string Combo_horarioid_Addnewoptiontext ;
      private string Combo_rhtrabajadorcodigo_Objectcall ;
      private string Combo_rhtrabajadorcodigo_Class ;
      private string Combo_rhtrabajadorcodigo_Icontype ;
      private string Combo_rhtrabajadorcodigo_Icon ;
      private string Combo_rhtrabajadorcodigo_Tooltip ;
      private string Combo_rhtrabajadorcodigo_Selectedvalue_set ;
      private string Combo_rhtrabajadorcodigo_Selectedtext_set ;
      private string Combo_rhtrabajadorcodigo_Selectedtext_get ;
      private string Combo_rhtrabajadorcodigo_Gamoauthtoken ;
      private string Combo_rhtrabajadorcodigo_Ddointernalname ;
      private string Combo_rhtrabajadorcodigo_Titlecontrolalign ;
      private string Combo_rhtrabajadorcodigo_Dropdownoptionstype ;
      private string Combo_rhtrabajadorcodigo_Titlecontrolidtoreplace ;
      private string Combo_rhtrabajadorcodigo_Datalisttype ;
      private string Combo_rhtrabajadorcodigo_Datalistfixedvalues ;
      private string Combo_rhtrabajadorcodigo_Htmltemplate ;
      private string Combo_rhtrabajadorcodigo_Multiplevaluestype ;
      private string Combo_rhtrabajadorcodigo_Loadingdata ;
      private string Combo_rhtrabajadorcodigo_Noresultsfound ;
      private string Combo_rhtrabajadorcodigo_Emptyitemtext ;
      private string Combo_rhtrabajadorcodigo_Onlyselectedvalues ;
      private string Combo_rhtrabajadorcodigo_Selectalltext ;
      private string Combo_rhtrabajadorcodigo_Multiplevaluesseparator ;
      private string Combo_rhtrabajadorcodigo_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode222 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z2415Lectura_Ini ;
      private DateTime Z2416Lectura_Fin ;
      private DateTime A2415Lectura_Ini ;
      private DateTime A2416Lectura_Fin ;
      private DateTime i2415Lectura_Ini ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_codigoid_Emptyitem ;
      private bool Combo_reloj_id_Emptyitem ;
      private bool Combo_horarioid_Emptyitem ;
      private bool Combo_rhtrabajadorcodigo_Emptyitem ;
      private bool n2416Lectura_Fin ;
      private bool n2525TrabApePat ;
      private bool n2526TrabApeMat ;
      private bool n2527TrabNombres ;
      private bool Combo_codigoid_Enabled ;
      private bool Combo_codigoid_Visible ;
      private bool Combo_codigoid_Allowmultipleselection ;
      private bool Combo_codigoid_Isgriditem ;
      private bool Combo_codigoid_Hasdescription ;
      private bool Combo_codigoid_Includeonlyselectedoption ;
      private bool Combo_codigoid_Includeselectalloption ;
      private bool Combo_codigoid_Includeaddnewoption ;
      private bool Combo_reloj_id_Enabled ;
      private bool Combo_reloj_id_Visible ;
      private bool Combo_reloj_id_Allowmultipleselection ;
      private bool Combo_reloj_id_Isgriditem ;
      private bool Combo_reloj_id_Hasdescription ;
      private bool Combo_reloj_id_Includeonlyselectedoption ;
      private bool Combo_reloj_id_Includeselectalloption ;
      private bool Combo_reloj_id_Includeaddnewoption ;
      private bool Combo_horarioid_Enabled ;
      private bool Combo_horarioid_Visible ;
      private bool Combo_horarioid_Allowmultipleselection ;
      private bool Combo_horarioid_Isgriditem ;
      private bool Combo_horarioid_Hasdescription ;
      private bool Combo_horarioid_Includeonlyselectedoption ;
      private bool Combo_horarioid_Includeselectalloption ;
      private bool Combo_horarioid_Includeaddnewoption ;
      private bool Combo_rhtrabajadorcodigo_Enabled ;
      private bool Combo_rhtrabajadorcodigo_Visible ;
      private bool Combo_rhtrabajadorcodigo_Allowmultipleselection ;
      private bool Combo_rhtrabajadorcodigo_Isgriditem ;
      private bool Combo_rhtrabajadorcodigo_Hasdescription ;
      private bool Combo_rhtrabajadorcodigo_Includeonlyselectedoption ;
      private bool Combo_rhtrabajadorcodigo_Includeselectalloption ;
      private bool Combo_rhtrabajadorcodigo_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string wcpOAV29CodigoId ;
      private string Z2431CodigoId ;
      private string Z2589RHTrabajadorCodigo ;
      private string N2589RHTrabajadorCodigo ;
      private string A2589RHTrabajadorCodigo ;
      private string AV29CodigoId ;
      private string A2431CodigoId ;
      private string A2592Reloj_Nombre ;
      private string A2593HorarioDescripcion ;
      private string A2590RHTrabajadorNombres ;
      private string AV37ComboCodigoId ;
      private string AV27ComboRHTrabajadorCodigo ;
      private string A2525TrabApePat ;
      private string A2526TrabApeMat ;
      private string A2527TrabNombres ;
      private string AV24Insert_RHTrabajadorCodigo ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z2592Reloj_Nombre ;
      private string Z2525TrabApePat ;
      private string Z2526TrabApeMat ;
      private string Z2527TrabNombres ;
      private string Z2593HorarioDescripcion ;
      private string Z2590RHTrabajadorNombres ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_codigoid ;
      private GXUserControl ucCombo_reloj_id ;
      private GXUserControl ucCombo_horarioid ;
      private GXUserControl ucCombo_rhtrabajadorcodigo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007Z5_A2592Reloj_Nombre ;
      private string[] T007Z6_A2593HorarioDescripcion ;
      private string[] T007Z4_A2525TrabApePat ;
      private bool[] T007Z4_n2525TrabApePat ;
      private string[] T007Z4_A2526TrabApeMat ;
      private bool[] T007Z4_n2526TrabApeMat ;
      private string[] T007Z4_A2527TrabNombres ;
      private bool[] T007Z4_n2527TrabNombres ;
      private string[] T007Z7_A2431CodigoId ;
      private string[] T007Z7_A2592Reloj_Nombre ;
      private DateTime[] T007Z7_A2415Lectura_Ini ;
      private DateTime[] T007Z7_A2416Lectura_Fin ;
      private bool[] T007Z7_n2416Lectura_Fin ;
      private string[] T007Z7_A2593HorarioDescripcion ;
      private string[] T007Z7_A2525TrabApePat ;
      private bool[] T007Z7_n2525TrabApePat ;
      private string[] T007Z7_A2526TrabApeMat ;
      private bool[] T007Z7_n2526TrabApeMat ;
      private string[] T007Z7_A2527TrabNombres ;
      private bool[] T007Z7_n2527TrabNombres ;
      private string[] T007Z7_A2589RHTrabajadorCodigo ;
      private short[] T007Z7_A2498Reloj_ID ;
      private short[] T007Z7_A2591HorarioID ;
      private string[] T007Z8_A2592Reloj_Nombre ;
      private string[] T007Z9_A2525TrabApePat ;
      private bool[] T007Z9_n2525TrabApePat ;
      private string[] T007Z9_A2526TrabApeMat ;
      private bool[] T007Z9_n2526TrabApeMat ;
      private string[] T007Z9_A2527TrabNombres ;
      private bool[] T007Z9_n2527TrabNombres ;
      private string[] T007Z10_A2593HorarioDescripcion ;
      private string[] T007Z11_A2431CodigoId ;
      private string[] T007Z3_A2431CodigoId ;
      private DateTime[] T007Z3_A2415Lectura_Ini ;
      private DateTime[] T007Z3_A2416Lectura_Fin ;
      private bool[] T007Z3_n2416Lectura_Fin ;
      private string[] T007Z3_A2589RHTrabajadorCodigo ;
      private short[] T007Z3_A2498Reloj_ID ;
      private short[] T007Z3_A2591HorarioID ;
      private string[] T007Z12_A2431CodigoId ;
      private string[] T007Z13_A2431CodigoId ;
      private string[] T007Z2_A2431CodigoId ;
      private DateTime[] T007Z2_A2415Lectura_Ini ;
      private DateTime[] T007Z2_A2416Lectura_Fin ;
      private bool[] T007Z2_n2416Lectura_Fin ;
      private string[] T007Z2_A2589RHTrabajadorCodigo ;
      private short[] T007Z2_A2498Reloj_ID ;
      private short[] T007Z2_A2591HorarioID ;
      private string[] T007Z17_A2592Reloj_Nombre ;
      private string[] T007Z18_A2525TrabApePat ;
      private bool[] T007Z18_n2525TrabApePat ;
      private string[] T007Z18_A2526TrabApeMat ;
      private bool[] T007Z18_n2526TrabApeMat ;
      private string[] T007Z18_A2527TrabNombres ;
      private bool[] T007Z18_n2527TrabNombres ;
      private string[] T007Z19_A2593HorarioDescripcion ;
      private string[] T007Z20_A2431CodigoId ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV36CodigoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30Reloj_ID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33HorarioID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV26RHTrabajadorCodigo_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class reloj_codigoid__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class reloj_codigoid__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007Z7;
        prmT007Z7 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z5;
        prmT007Z5 = new Object[] {
        new ParDef("@Reloj_ID",GXType.Int16,4,0)
        };
        Object[] prmT007Z4;
        prmT007Z4 = new Object[] {
        new ParDef("@RHTrabajadorCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007Z6;
        prmT007Z6 = new Object[] {
        new ParDef("@HorarioID",GXType.Int16,4,0)
        };
        Object[] prmT007Z8;
        prmT007Z8 = new Object[] {
        new ParDef("@Reloj_ID",GXType.Int16,4,0)
        };
        Object[] prmT007Z9;
        prmT007Z9 = new Object[] {
        new ParDef("@RHTrabajadorCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007Z10;
        prmT007Z10 = new Object[] {
        new ParDef("@HorarioID",GXType.Int16,4,0)
        };
        Object[] prmT007Z11;
        prmT007Z11 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z3;
        prmT007Z3 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z12;
        prmT007Z12 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z13;
        prmT007Z13 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z2;
        prmT007Z2 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z14;
        prmT007Z14 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0) ,
        new ParDef("@Lectura_Ini",GXType.DateTime,10,8) ,
        new ParDef("@Lectura_Fin",GXType.DateTime,10,8){Nullable=true} ,
        new ParDef("@RHTrabajadorCodigo",GXType.NVarChar,20,0) ,
        new ParDef("@Reloj_ID",GXType.Int16,4,0) ,
        new ParDef("@HorarioID",GXType.Int16,4,0)
        };
        Object[] prmT007Z15;
        prmT007Z15 = new Object[] {
        new ParDef("@Lectura_Ini",GXType.DateTime,10,8) ,
        new ParDef("@Lectura_Fin",GXType.DateTime,10,8){Nullable=true} ,
        new ParDef("@RHTrabajadorCodigo",GXType.NVarChar,20,0) ,
        new ParDef("@Reloj_ID",GXType.Int16,4,0) ,
        new ParDef("@HorarioID",GXType.Int16,4,0) ,
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z16;
        prmT007Z16 = new Object[] {
        new ParDef("@CodigoId",GXType.NVarChar,25,0)
        };
        Object[] prmT007Z20;
        prmT007Z20 = new Object[] {
        };
        Object[] prmT007Z17;
        prmT007Z17 = new Object[] {
        new ParDef("@Reloj_ID",GXType.Int16,4,0)
        };
        Object[] prmT007Z19;
        prmT007Z19 = new Object[] {
        new ParDef("@HorarioID",GXType.Int16,4,0)
        };
        Object[] prmT007Z18;
        prmT007Z18 = new Object[] {
        new ParDef("@RHTrabajadorCodigo",GXType.NVarChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007Z2", "SELECT [CodigoId], [Lectura_Ini], [Lectura_Fin], [RHTrabajadorCodigo] AS RHTrabajadorCodigo, [Reloj_ID] AS Reloj_ID, [HorarioID] AS HorarioID FROM [Reloj_CodigoID] WITH (UPDLOCK) WHERE [CodigoId] = @CodigoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z3", "SELECT [CodigoId], [Lectura_Ini], [Lectura_Fin], [RHTrabajadorCodigo] AS RHTrabajadorCodigo, [Reloj_ID] AS Reloj_ID, [HorarioID] AS HorarioID FROM [Reloj_CodigoID] WHERE [CodigoId] = @CodigoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z4", "SELECT [TrabApePat], [TrabApeMat], [TrabNombres] FROM [Trab_Trabajador] WHERE [TrabCodigo] = @RHTrabajadorCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z5", "SELECT [Reloj_Nom] AS Reloj_Nombre FROM [Reloj] WHERE [RelojID] = @Reloj_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z6", "SELECT [Horario_Dsc] AS HorarioDescripcion FROM [Reloj_Horario] WHERE [Horario_ID] = @HorarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z7", "SELECT TM1.[CodigoId], T2.[Reloj_Nom] AS Reloj_Nombre, TM1.[Lectura_Ini], TM1.[Lectura_Fin], T4.[Horario_Dsc] AS HorarioDescripcion, T3.[TrabApePat], T3.[TrabApeMat], T3.[TrabNombres], TM1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, TM1.[Reloj_ID] AS Reloj_ID, TM1.[HorarioID] AS HorarioID FROM ((([Reloj_CodigoID] TM1 INNER JOIN [Reloj] T2 ON T2.[RelojID] = TM1.[Reloj_ID]) INNER JOIN [Trab_Trabajador] T3 ON T3.[TrabCodigo] = TM1.[RHTrabajadorCodigo]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = TM1.[HorarioID]) WHERE TM1.[CodigoId] = @CodigoId ORDER BY TM1.[CodigoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z8", "SELECT [Reloj_Nom] AS Reloj_Nombre FROM [Reloj] WHERE [RelojID] = @Reloj_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z9", "SELECT [TrabApePat], [TrabApeMat], [TrabNombres] FROM [Trab_Trabajador] WHERE [TrabCodigo] = @RHTrabajadorCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z10", "SELECT [Horario_Dsc] AS HorarioDescripcion FROM [Reloj_Horario] WHERE [Horario_ID] = @HorarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z11", "SELECT [CodigoId] FROM [Reloj_CodigoID] WHERE [CodigoId] = @CodigoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z12", "SELECT TOP 1 [CodigoId] FROM [Reloj_CodigoID] WHERE ( [CodigoId] > @CodigoId) ORDER BY [CodigoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007Z13", "SELECT TOP 1 [CodigoId] FROM [Reloj_CodigoID] WHERE ( [CodigoId] < @CodigoId) ORDER BY [CodigoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007Z14", "INSERT INTO [Reloj_CodigoID]([CodigoId], [Lectura_Ini], [Lectura_Fin], [RHTrabajadorCodigo], [Reloj_ID], [HorarioID]) VALUES(@CodigoId, @Lectura_Ini, @Lectura_Fin, @RHTrabajadorCodigo, @Reloj_ID, @HorarioID)", GxErrorMask.GX_NOMASK,prmT007Z14)
           ,new CursorDef("T007Z15", "UPDATE [Reloj_CodigoID] SET [Lectura_Ini]=@Lectura_Ini, [Lectura_Fin]=@Lectura_Fin, [RHTrabajadorCodigo]=@RHTrabajadorCodigo, [Reloj_ID]=@Reloj_ID, [HorarioID]=@HorarioID  WHERE [CodigoId] = @CodigoId", GxErrorMask.GX_NOMASK,prmT007Z15)
           ,new CursorDef("T007Z16", "DELETE FROM [Reloj_CodigoID]  WHERE [CodigoId] = @CodigoId", GxErrorMask.GX_NOMASK,prmT007Z16)
           ,new CursorDef("T007Z17", "SELECT [Reloj_Nom] AS Reloj_Nombre FROM [Reloj] WHERE [RelojID] = @Reloj_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z18", "SELECT [TrabApePat], [TrabApeMat], [TrabNombres] FROM [Trab_Trabajador] WHERE [TrabCodigo] = @RHTrabajadorCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z19", "SELECT [Horario_Dsc] AS HorarioDescripcion FROM [Reloj_Horario] WHERE [Horario_ID] = @HorarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Z20", "SELECT [CodigoId] FROM [Reloj_CodigoID] ORDER BY [CodigoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Z20,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getVarchar(3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((short[]) buf[13])[0] = rslt.getShort(10);
              ((short[]) buf[14])[0] = rslt.getShort(11);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getVarchar(3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getVarchar(3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
