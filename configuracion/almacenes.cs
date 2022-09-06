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
   public class almacenes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel14"+"_"+"vCALMCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX14ASACALMCOD5I54( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = GetPar( "ProvCod");
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = GetPar( "DisCod");
            AssignAttri("", false, "A142DisCod", A142DisCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A139PaiCod, A140EstCod, A141ProvCod, A142DisCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.almacenes.aspx")), "configuracion.almacenes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.almacenes.aspx")))) ;
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
                  AV7AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AssignAttri("", false, "AV7AlmCod", StringUtil.LTrimStr( (decimal)(AV7AlmCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vALMCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AlmCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Almacenes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAlmDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public almacenes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public almacenes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_AlmCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AlmCod = aP1_AlmCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkAlmPed = new GXCheckbox();
         cmbAlmSts = new GXCombobox();
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
         A437AlmPed = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A437AlmPed), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
         if ( cmbAlmSts.ItemCount > 0 )
         {
            A438AlmSts = (short)(NumberUtil.Val( cmbAlmSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0))), "."));
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAlmSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            AssignProp("", false, cmbAlmSts_Internalname, "Values", cmbAlmSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divUnnamedtablealmdsc_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockalmdsc_Internalname, "Almacen", "", "", lblTextblockalmdsc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAlmDsc_Internalname, "Nombre Almacen", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmDsc_Internalname, StringUtil.RTrim( A436AlmDsc), StringUtil.RTrim( context.localUtil.Format( A436AlmDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtAlmDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
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
         GxWebStd.gx_div_start( context, divUnnamedtablealmdir_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockalmdir_Internalname, "Dirección", "", "", lblTextblockalmdir_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAlmDir_Internalname, "Dirección Almacen", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmDir_Internalname, A435AlmDir, StringUtil.RTrim( context.localUtil.Format( A435AlmDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmDir_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtAlmDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpaicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpaicod_Internalname, "Pais", "", "", lblTextblockpaicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paicod.SetProperty("Caption", Combo_paicod_Caption);
         ucCombo_paicod.SetProperty("Cls", Combo_paicod_Cls);
         ucCombo_paicod.SetProperty("DataListProc", Combo_paicod_Datalistproc);
         ucCombo_paicod.SetProperty("DataListProcParametersPrefix", Combo_paicod_Datalistprocparametersprefix);
         ucCombo_paicod.SetProperty("EmptyItem", Combo_paicod_Emptyitem);
         ucCombo_paicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_paicod.SetProperty("DropDownOptionsData", AV18PaiCod_Data);
         ucCombo_paicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paicod_Internalname, "COMBO_PAICODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaiCod_Internalname, "Pais", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPaiCod_Visible, edtPaiCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedestcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockestcod_Internalname, "Estado", "", "", lblTextblockestcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_estcod.SetProperty("Caption", Combo_estcod_Caption);
         ucCombo_estcod.SetProperty("Cls", Combo_estcod_Cls);
         ucCombo_estcod.SetProperty("DataListProc", Combo_estcod_Datalistproc);
         ucCombo_estcod.SetProperty("EmptyItem", Combo_estcod_Emptyitem);
         ucCombo_estcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_estcod.SetProperty("DropDownOptionsData", AV24EstCod_Data);
         ucCombo_estcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_estcod_Internalname, "COMBO_ESTCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstCod_Internalname, "Estado", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", edtEstCod_Visible, edtEstCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprovcod_Internalname, "Provincia", "", "", lblTextblockprovcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_provcod.SetProperty("Caption", Combo_provcod_Caption);
         ucCombo_provcod.SetProperty("Cls", Combo_provcod_Cls);
         ucCombo_provcod.SetProperty("DataListProc", Combo_provcod_Datalistproc);
         ucCombo_provcod.SetProperty("EmptyItem", Combo_provcod_Emptyitem);
         ucCombo_provcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_provcod.SetProperty("DropDownOptionsData", AV27ProvCod_Data);
         ucCombo_provcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_provcod_Internalname, "COMBO_PROVCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvCod_Internalname, "Provincia", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", edtProvCod_Visible, edtProvCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplitteddiscod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdiscod_Internalname, "Distrito", "", "", lblTextblockdiscod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_discod.SetProperty("Caption", Combo_discod_Caption);
         ucCombo_discod.SetProperty("Cls", Combo_discod_Cls);
         ucCombo_discod.SetProperty("DataListProc", Combo_discod_Datalistproc);
         ucCombo_discod.SetProperty("EmptyItem", Combo_discod_Emptyitem);
         ucCombo_discod.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_discod.SetProperty("DropDownOptionsData", AV30DisCod_Data);
         ucCombo_discod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_discod_Internalname, "COMBO_DISCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDisCod_Internalname, "Distrito", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisCod_Internalname, StringUtil.RTrim( A142DisCod), StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisCod_Jsonclick, 0, "Attribute", "", "", "", "", edtDisCod_Visible, edtDisCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAlmAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAlmAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmAbr_Internalname, StringUtil.RTrim( A433AlmAbr), StringUtil.RTrim( context.localUtil.Format( A433AlmAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmAbr_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAlmSunat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAlmSunat_Internalname, "Establecimiento Anexo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmSunat_Internalname, A439AlmSunat, StringUtil.RTrim( context.localUtil.Format( A439AlmSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmSunat_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAlmCos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAlmCos_Internalname, "Valoriza", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A434AlmCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtAlmCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A434AlmCos), "9") : context.localUtil.Format( (decimal)(A434AlmCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkAlmPed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAlmPed_Internalname, "Pedidos", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAlmPed_Internalname, StringUtil.Str( (decimal)(A437AlmPed), 1, 0), "", "Pedidos", 1, chkAlmPed.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,95);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablealmsts_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockalmsts_Internalname, "Estado", "", "", lblTextblockalmsts_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAlmSts_Internalname, "Situacion Almacen", "col-sm-3 AttributeLabel", 0, true, "");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAlmSts, cmbAlmSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0)), 1, cmbAlmSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbAlmSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "", true, 1, "HLP_Configuracion\\Almacenes.htm");
         cmbAlmSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         AssignProp("", false, cmbAlmSts_Internalname, "Values", (string)(cmbAlmSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Almacenes.htm");
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
         GxWebStd.gx_single_line_edit( context, edtavCombopaicod_Internalname, StringUtil.RTrim( AV23ComboPaiCod), StringUtil.RTrim( context.localUtil.Format( AV23ComboPaiCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaicod_Visible, edtavCombopaicod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_estcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboestcod_Internalname, StringUtil.RTrim( AV25ComboEstCod), StringUtil.RTrim( context.localUtil.Format( AV25ComboEstCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboestcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboestcod_Visible, edtavComboestcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_provcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprovcod_Internalname, StringUtil.RTrim( AV28ComboProvCod), StringUtil.RTrim( context.localUtil.Format( AV28ComboProvCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprovcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprovcod_Visible, edtavComboprovcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_discod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombodiscod_Internalname, StringUtil.RTrim( AV31ComboDisCod), StringUtil.RTrim( context.localUtil.Format( AV31ComboDisCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodiscod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodiscod_Visible, edtavCombodiscod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Almacenes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63AlmCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", edtAlmCod_Visible, edtAlmCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Almacenes.htm");
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
         E115I2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPAICOD_DATA"), AV18PaiCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vESTCOD_DATA"), AV24EstCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROVCOD_DATA"), AV27ProvCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDISCOD_DATA"), AV30DisCod_Data);
               /* Read saved values. */
               Z63AlmCod = (int)(context.localUtil.CToN( cgiGet( "Z63AlmCod"), ".", ","));
               Z436AlmDsc = cgiGet( "Z436AlmDsc");
               Z433AlmAbr = cgiGet( "Z433AlmAbr");
               Z434AlmCos = (short)(context.localUtil.CToN( cgiGet( "Z434AlmCos"), ".", ","));
               Z437AlmPed = (short)(context.localUtil.CToN( cgiGet( "Z437AlmPed"), ".", ","));
               Z438AlmSts = (short)(context.localUtil.CToN( cgiGet( "Z438AlmSts"), ".", ","));
               Z435AlmDir = cgiGet( "Z435AlmDir");
               Z439AlmSunat = cgiGet( "Z439AlmSunat");
               Z139PaiCod = cgiGet( "Z139PaiCod");
               Z140EstCod = cgiGet( "Z140EstCod");
               Z141ProvCod = cgiGet( "Z141ProvCod");
               Z142DisCod = cgiGet( "Z142DisCod");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N139PaiCod = cgiGet( "N139PaiCod");
               N140EstCod = cgiGet( "N140EstCod");
               N141ProvCod = cgiGet( "N141ProvCod");
               N142DisCod = cgiGet( "N142DisCod");
               AV26Cond_PaiCod = cgiGet( "vCOND_PAICOD");
               AV29Cond_EstCod = cgiGet( "vCOND_ESTCOD");
               AV32Cond_ProvCod = cgiGet( "vCOND_PROVCOD");
               AV7AlmCod = (int)(context.localUtil.CToN( cgiGet( "vALMCOD"), ".", ","));
               AV35cAlmCod = (int)(context.localUtil.CToN( cgiGet( "vCALMCOD"), ".", ","));
               AV13Insert_PaiCod = cgiGet( "vINSERT_PAICOD");
               AV14Insert_EstCod = cgiGet( "vINSERT_ESTCOD");
               AV15Insert_ProvCod = cgiGet( "vINSERT_PROVCOD");
               AV16Insert_DisCod = cgiGet( "vINSERT_DISCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV37Pgmname = cgiGet( "vPGMNAME");
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
               Combo_discod_Objectcall = cgiGet( "COMBO_DISCOD_Objectcall");
               Combo_discod_Class = cgiGet( "COMBO_DISCOD_Class");
               Combo_discod_Icontype = cgiGet( "COMBO_DISCOD_Icontype");
               Combo_discod_Icon = cgiGet( "COMBO_DISCOD_Icon");
               Combo_discod_Caption = cgiGet( "COMBO_DISCOD_Caption");
               Combo_discod_Tooltip = cgiGet( "COMBO_DISCOD_Tooltip");
               Combo_discod_Cls = cgiGet( "COMBO_DISCOD_Cls");
               Combo_discod_Selectedvalue_set = cgiGet( "COMBO_DISCOD_Selectedvalue_set");
               Combo_discod_Selectedvalue_get = cgiGet( "COMBO_DISCOD_Selectedvalue_get");
               Combo_discod_Selectedtext_set = cgiGet( "COMBO_DISCOD_Selectedtext_set");
               Combo_discod_Selectedtext_get = cgiGet( "COMBO_DISCOD_Selectedtext_get");
               Combo_discod_Gamoauthtoken = cgiGet( "COMBO_DISCOD_Gamoauthtoken");
               Combo_discod_Ddointernalname = cgiGet( "COMBO_DISCOD_Ddointernalname");
               Combo_discod_Titlecontrolalign = cgiGet( "COMBO_DISCOD_Titlecontrolalign");
               Combo_discod_Dropdownoptionstype = cgiGet( "COMBO_DISCOD_Dropdownoptionstype");
               Combo_discod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Enabled"));
               Combo_discod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Visible"));
               Combo_discod_Titlecontrolidtoreplace = cgiGet( "COMBO_DISCOD_Titlecontrolidtoreplace");
               Combo_discod_Datalisttype = cgiGet( "COMBO_DISCOD_Datalisttype");
               Combo_discod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Allowmultipleselection"));
               Combo_discod_Datalistfixedvalues = cgiGet( "COMBO_DISCOD_Datalistfixedvalues");
               Combo_discod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Isgriditem"));
               Combo_discod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Hasdescription"));
               Combo_discod_Datalistproc = cgiGet( "COMBO_DISCOD_Datalistproc");
               Combo_discod_Datalistprocparametersprefix = cgiGet( "COMBO_DISCOD_Datalistprocparametersprefix");
               Combo_discod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_DISCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_discod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Includeonlyselectedoption"));
               Combo_discod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Includeselectalloption"));
               Combo_discod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Emptyitem"));
               Combo_discod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Includeaddnewoption"));
               Combo_discod_Htmltemplate = cgiGet( "COMBO_DISCOD_Htmltemplate");
               Combo_discod_Multiplevaluestype = cgiGet( "COMBO_DISCOD_Multiplevaluestype");
               Combo_discod_Loadingdata = cgiGet( "COMBO_DISCOD_Loadingdata");
               Combo_discod_Noresultsfound = cgiGet( "COMBO_DISCOD_Noresultsfound");
               Combo_discod_Emptyitemtext = cgiGet( "COMBO_DISCOD_Emptyitemtext");
               Combo_discod_Onlyselectedvalues = cgiGet( "COMBO_DISCOD_Onlyselectedvalues");
               Combo_discod_Selectalltext = cgiGet( "COMBO_DISCOD_Selectalltext");
               Combo_discod_Multiplevaluesseparator = cgiGet( "COMBO_DISCOD_Multiplevaluesseparator");
               Combo_discod_Addnewoptiontext = cgiGet( "COMBO_DISCOD_Addnewoptiontext");
               Combo_discod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_DISCOD_Gxcontroltype"), ".", ","));
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
               A436AlmDsc = cgiGet( edtAlmDsc_Internalname);
               AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
               A435AlmDir = cgiGet( edtAlmDir_Internalname);
               AssignAttri("", false, "A435AlmDir", A435AlmDir);
               A139PaiCod = cgiGet( edtPaiCod_Internalname);
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = cgiGet( edtEstCod_Internalname);
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = cgiGet( edtProvCod_Internalname);
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = cgiGet( edtDisCod_Internalname);
               AssignAttri("", false, "A142DisCod", A142DisCod);
               A433AlmAbr = cgiGet( edtAlmAbr_Internalname);
               AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
               A439AlmSunat = cgiGet( edtAlmSunat_Internalname);
               AssignAttri("", false, "A439AlmSunat", A439AlmSunat);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAlmCos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAlmCos_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ALMCOS");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A434AlmCos = 0;
                  AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
               }
               else
               {
                  A434AlmCos = (short)(context.localUtil.CToN( cgiGet( edtAlmCos_Internalname), ".", ","));
                  AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkAlmPed_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkAlmPed_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ALMPED");
                  AnyError = 1;
                  GX_FocusControl = chkAlmPed_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A437AlmPed = 0;
                  AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
               }
               else
               {
                  A437AlmPed = (short)(((StringUtil.StrCmp(cgiGet( chkAlmPed_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
               }
               cmbAlmSts.CurrentValue = cgiGet( cmbAlmSts_Internalname);
               A438AlmSts = (short)(NumberUtil.Val( cgiGet( cmbAlmSts_Internalname), "."));
               AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
               AV23ComboPaiCod = cgiGet( edtavCombopaicod_Internalname);
               AssignAttri("", false, "AV23ComboPaiCod", AV23ComboPaiCod);
               AV25ComboEstCod = cgiGet( edtavComboestcod_Internalname);
               AssignAttri("", false, "AV25ComboEstCod", AV25ComboEstCod);
               AV28ComboProvCod = cgiGet( edtavComboprovcod_Internalname);
               AssignAttri("", false, "AV28ComboProvCod", AV28ComboProvCod);
               AV31ComboDisCod = cgiGet( edtavCombodiscod_Internalname);
               AssignAttri("", false, "AV31ComboDisCod", AV31ComboDisCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A63AlmCod = 0;
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               }
               else
               {
                  A63AlmCod = (int)(context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ","));
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Almacenes");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A63AlmCod != Z63AlmCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\almacenes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A63AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
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
                     sMode54 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode54;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound54 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ALMCOD");
                        AnyError = 1;
                        GX_FocusControl = edtAlmCod_Internalname;
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
                           E115I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125I2 ();
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
            E125I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5I54( ) ;
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
            DisableAttributes5I54( ) ;
         }
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombodiscod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodiscod_Enabled), 5, 0), true);
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

      protected void CONFIRM_5I0( )
      {
         BeforeValidate5I54( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5I54( ) ;
            }
            else
            {
               CheckExtendedTable5I54( ) ;
               CloseExtendedTableCursors5I54( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5I0( )
      {
      }

      protected void E115I2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtDisCod_Visible = 0;
         AssignProp("", false, edtDisCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDisCod_Visible), 5, 0), true);
         AV31ComboDisCod = "";
         AssignAttri("", false, "AV31ComboDisCod", AV31ComboDisCod);
         edtavCombodiscod_Visible = 0;
         AssignProp("", false, edtavCombodiscod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodiscod_Visible), 5, 0), true);
         edtProvCod_Visible = 0;
         AssignProp("", false, edtProvCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProvCod_Visible), 5, 0), true);
         AV28ComboProvCod = "";
         AssignAttri("", false, "AV28ComboProvCod", AV28ComboProvCod);
         edtavComboprovcod_Visible = 0;
         AssignProp("", false, edtavComboprovcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Visible), 5, 0), true);
         edtEstCod_Visible = 0;
         AssignProp("", false, edtEstCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstCod_Visible), 5, 0), true);
         AV25ComboEstCod = "";
         AssignAttri("", false, "AV25ComboEstCod", AV25ComboEstCod);
         edtavComboestcod_Visible = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Visible), 5, 0), true);
         edtPaiCod_Visible = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaiCod_Visible), 5, 0), true);
         AV23ComboPaiCod = "";
         AssignAttri("", false, "AV23ComboPaiCod", AV23ComboPaiCod);
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
         /* Execute user subroutine: 'LOADCOMBODISCOD' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV37Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV38GXV1 = 1;
            AssignAttri("", false, "AV38GXV1", StringUtil.LTrimStr( (decimal)(AV38GXV1), 8, 0));
            while ( AV38GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV38GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "PaiCod") == 0 )
               {
                  AV13Insert_PaiCod = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_PaiCod", AV13Insert_PaiCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_PaiCod)) )
                  {
                     AV23ComboPaiCod = AV13Insert_PaiCod;
                     AssignAttri("", false, "AV23ComboPaiCod", AV23ComboPaiCod);
                     Combo_paicod_Selectedvalue_set = AV23ComboPaiCod;
                     ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "PaiCod",  "GET",  false,  AV7AlmCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_paicod_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
                     Combo_paicod_Enabled = false;
                     ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "EstCod") == 0 )
               {
                  AV14Insert_EstCod = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV14Insert_EstCod", AV14Insert_EstCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_EstCod)) )
                  {
                     AV25ComboEstCod = AV14Insert_EstCod;
                     AssignAttri("", false, "AV25ComboEstCod", AV25ComboEstCod);
                     Combo_estcod_Selectedvalue_set = AV25ComboEstCod;
                     ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "EstCod",  "GET",  false,  AV7AlmCod,  AV13Insert_PaiCod,  A140EstCod,  A141ProvCod,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_estcod_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedText_set", Combo_estcod_Selectedtext_set);
                     Combo_estcod_Enabled = false;
                     ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ProvCod") == 0 )
               {
                  AV15Insert_ProvCod = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV15Insert_ProvCod", AV15Insert_ProvCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ProvCod)) )
                  {
                     AV28ComboProvCod = AV15Insert_ProvCod;
                     AssignAttri("", false, "AV28ComboProvCod", AV28ComboProvCod);
                     Combo_provcod_Selectedvalue_set = AV28ComboProvCod;
                     ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "ProvCod",  "GET",  false,  AV7AlmCod,  AV13Insert_PaiCod,  AV14Insert_EstCod,  A141ProvCod,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_provcod_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
                     Combo_provcod_Enabled = false;
                     ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "DisCod") == 0 )
               {
                  AV16Insert_DisCod = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV16Insert_DisCod", AV16Insert_DisCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_DisCod)) )
                  {
                     AV31ComboDisCod = AV16Insert_DisCod;
                     AssignAttri("", false, "AV31ComboDisCod", AV31ComboDisCod);
                     Combo_discod_Selectedvalue_set = AV31ComboDisCod;
                     ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedValue_set", Combo_discod_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "DisCod",  "GET",  false,  AV7AlmCod,  AV13Insert_PaiCod,  AV14Insert_EstCod,  AV15Insert_ProvCod,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_discod_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedText_set", Combo_discod_Selectedtext_set);
                     Combo_discod_Enabled = false;
                     ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_discod_Enabled));
                  }
               }
               AV38GXV1 = (int)(AV38GXV1+1);
               AssignAttri("", false, "AV38GXV1", StringUtil.LTrimStr( (decimal)(AV38GXV1), 8, 0));
            }
         }
         edtAlmCod_Visible = 0;
         AssignProp("", false, edtAlmCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAlmCod_Visible), 5, 0), true);
      }

      protected void E125I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV33SGAuDocGls = "Almacen N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A63AlmCod), 10, 0)) + " " + StringUtil.Trim( A436AlmDsc);
            AV34Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A63AlmCod), 10, 0));
            GXt_char2 = "CNF";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV33SGAuDocGls, ref  AV34Codigo, ref  AV34Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.almacenesww.aspx") );
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
         /* 'LOADCOMBODISCOD' Routine */
         returnInSub = false;
         Combo_discod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"DisCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AlmCod\": 0, \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\", \"Cond_ProvCod\": \"#%3#\"", edtPaiCod_Internalname, edtEstCod_Internalname, edtProvCod_Internalname, "", "", "", "", "", "");
         ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "DataListProcParametersPrefix", Combo_discod_Datalistprocparametersprefix);
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "DisCod",  Gx_mode,  false,  AV7AlmCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_discod_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedValue_set", Combo_discod_Selectedvalue_set);
         Combo_discod_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedText_set", Combo_discod_Selectedtext_set);
         AV31ComboDisCod = AV20ComboSelectedValue;
         AssignAttri("", false, "AV31ComboDisCod", AV31ComboDisCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_discod_Enabled = false;
            ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_discod_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOPROVCOD' Routine */
         returnInSub = false;
         Combo_provcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ProvCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AlmCod\": 0, \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\", \"Cond_ProvCod\": \"#%3#\"", edtPaiCod_Internalname, edtEstCod_Internalname, edtProvCod_Internalname, "", "", "", "", "", "");
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "DataListProcParametersPrefix", Combo_provcod_Datalistprocparametersprefix);
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "ProvCod",  Gx_mode,  false,  AV7AlmCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_provcod_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
         Combo_provcod_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
         AV28ComboProvCod = AV20ComboSelectedValue;
         AssignAttri("", false, "AV28ComboProvCod", AV28ComboProvCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_provcod_Enabled = false;
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOESTCOD' Routine */
         returnInSub = false;
         Combo_estcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"EstCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AlmCod\": 0, \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\", \"Cond_ProvCod\": \"#%3#\"", edtPaiCod_Internalname, edtEstCod_Internalname, edtProvCod_Internalname, "", "", "", "", "", "");
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "DataListProcParametersPrefix", Combo_estcod_Datalistprocparametersprefix);
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "EstCod",  Gx_mode,  false,  AV7AlmCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_estcod_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
         Combo_estcod_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedText_set", Combo_estcod_Selectedtext_set);
         AV25ComboEstCod = AV20ComboSelectedValue;
         AssignAttri("", false, "AV25ComboEstCod", AV25ComboEstCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_estcod_Enabled = false;
            ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPAICOD' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.configuracion.almacenesloaddvcombo(context ).execute(  "PaiCod",  Gx_mode,  false,  AV7AlmCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_paicod_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
         Combo_paicod_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
         AV23ComboPaiCod = AV20ComboSelectedValue;
         AssignAttri("", false, "AV23ComboPaiCod", AV23ComboPaiCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_paicod_Enabled = false;
            ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         }
      }

      protected void ZM5I54( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z436AlmDsc = T005I3_A436AlmDsc[0];
               Z433AlmAbr = T005I3_A433AlmAbr[0];
               Z434AlmCos = T005I3_A434AlmCos[0];
               Z437AlmPed = T005I3_A437AlmPed[0];
               Z438AlmSts = T005I3_A438AlmSts[0];
               Z435AlmDir = T005I3_A435AlmDir[0];
               Z439AlmSunat = T005I3_A439AlmSunat[0];
               Z139PaiCod = T005I3_A139PaiCod[0];
               Z140EstCod = T005I3_A140EstCod[0];
               Z141ProvCod = T005I3_A141ProvCod[0];
               Z142DisCod = T005I3_A142DisCod[0];
            }
            else
            {
               Z436AlmDsc = A436AlmDsc;
               Z433AlmAbr = A433AlmAbr;
               Z434AlmCos = A434AlmCos;
               Z437AlmPed = A437AlmPed;
               Z438AlmSts = A438AlmSts;
               Z435AlmDir = A435AlmDir;
               Z439AlmSunat = A439AlmSunat;
               Z139PaiCod = A139PaiCod;
               Z140EstCod = A140EstCod;
               Z141ProvCod = A141ProvCod;
               Z142DisCod = A142DisCod;
            }
         }
         if ( GX_JID == -27 )
         {
            Z63AlmCod = A63AlmCod;
            Z436AlmDsc = A436AlmDsc;
            Z433AlmAbr = A433AlmAbr;
            Z434AlmCos = A434AlmCos;
            Z437AlmPed = A437AlmPed;
            Z438AlmSts = A438AlmSts;
            Z435AlmDir = A435AlmDir;
            Z439AlmSunat = A439AlmSunat;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            Z142DisCod = A142DisCod;
         }
      }

      protected void standaloneNotModal( )
      {
         AV37Pgmname = "Configuracion.Almacenes";
         AssignAttri("", false, "AV37Pgmname", AV37Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AlmCod) )
         {
            A63AlmCod = AV7AlmCod;
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         }
         if ( ! (0==AV7AlmCod) )
         {
            edtAlmCod_Enabled = 0;
            AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
         }
         else
         {
            edtAlmCod_Enabled = 1;
            AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7AlmCod) )
         {
            edtAlmCod_Enabled = 0;
            AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_PaiCod)) )
         {
            edtPaiCod_Enabled = 0;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPaiCod_Enabled = 1;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_EstCod)) )
         {
            edtEstCod_Enabled = 0;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         else
         {
            edtEstCod_Enabled = 1;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ProvCod)) )
         {
            edtProvCod_Enabled = 0;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         else
         {
            edtProvCod_Enabled = 1;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_DisCod)) )
         {
            edtDisCod_Enabled = 0;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
         else
         {
            edtDisCod_Enabled = 1;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_PaiCod)) )
         {
            A139PaiCod = AV13Insert_PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         else
         {
            A139PaiCod = AV23ComboPaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_EstCod)) )
         {
            A140EstCod = AV14Insert_EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         else
         {
            A140EstCod = AV25ComboEstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ProvCod)) )
         {
            A141ProvCod = AV15Insert_ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         else
         {
            A141ProvCod = AV28ComboProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_DisCod)) )
         {
            A142DisCod = AV16Insert_DisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
         else
         {
            A142DisCod = AV31ComboDisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
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
         if ( IsIns( )  && (0==A438AlmSts) && ( Gx_BScreen == 0 ) )
         {
            A438AlmSts = 1;
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load5I54( )
      {
         /* Using cursor T005I5 */
         pr_default.execute(3, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound54 = 1;
            A436AlmDsc = T005I5_A436AlmDsc[0];
            AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
            A433AlmAbr = T005I5_A433AlmAbr[0];
            AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
            A434AlmCos = T005I5_A434AlmCos[0];
            AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
            A437AlmPed = T005I5_A437AlmPed[0];
            AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
            A438AlmSts = T005I5_A438AlmSts[0];
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            A435AlmDir = T005I5_A435AlmDir[0];
            AssignAttri("", false, "A435AlmDir", A435AlmDir);
            A439AlmSunat = T005I5_A439AlmSunat[0];
            AssignAttri("", false, "A439AlmSunat", A439AlmSunat);
            A139PaiCod = T005I5_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005I5_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005I5_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T005I5_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            ZM5I54( -27) ;
         }
         pr_default.close(3);
         OnLoadActions5I54( ) ;
      }

      protected void OnLoadActions5I54( )
      {
      }

      protected void CheckExtendedTable5I54( )
      {
         nIsDirty_54 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A436AlmDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Nombre Almacen", "", "", "", "", "", "", "", ""), 1, "ALMDSC");
            AnyError = 1;
            GX_FocusControl = edtAlmDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A435AlmDir)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Dirección Almacen", "", "", "", "", "", "", "", ""), 1, "ALMDIR");
            AnyError = 1;
            GX_FocusControl = edtAlmDir_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005I4 */
         pr_default.execute(2, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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
      }

      protected void CloseExtendedTableCursors5I54( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_28( string A139PaiCod ,
                                string A140EstCod ,
                                string A141ProvCod ,
                                string A142DisCod )
      {
         /* Using cursor T005I6 */
         pr_default.execute(4, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey5I54( )
      {
         /* Using cursor T005I7 */
         pr_default.execute(5, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound54 = 1;
         }
         else
         {
            RcdFound54 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005I3 */
         pr_default.execute(1, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5I54( 27) ;
            RcdFound54 = 1;
            A63AlmCod = T005I3_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A436AlmDsc = T005I3_A436AlmDsc[0];
            AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
            A433AlmAbr = T005I3_A433AlmAbr[0];
            AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
            A434AlmCos = T005I3_A434AlmCos[0];
            AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
            A437AlmPed = T005I3_A437AlmPed[0];
            AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
            A438AlmSts = T005I3_A438AlmSts[0];
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            A435AlmDir = T005I3_A435AlmDir[0];
            AssignAttri("", false, "A435AlmDir", A435AlmDir);
            A439AlmSunat = T005I3_A439AlmSunat[0];
            AssignAttri("", false, "A439AlmSunat", A439AlmSunat);
            A139PaiCod = T005I3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T005I3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T005I3_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T005I3_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            Z63AlmCod = A63AlmCod;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5I54( ) ;
            if ( AnyError == 1 )
            {
               RcdFound54 = 0;
               InitializeNonKey5I54( ) ;
            }
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound54 = 0;
            InitializeNonKey5I54( ) ;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5I54( ) ;
         if ( RcdFound54 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound54 = 0;
         /* Using cursor T005I8 */
         pr_default.execute(6, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T005I8_A63AlmCod[0] < A63AlmCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T005I8_A63AlmCod[0] > A63AlmCod ) ) )
            {
               A63AlmCod = T005I8_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               RcdFound54 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound54 = 0;
         /* Using cursor T005I9 */
         pr_default.execute(7, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T005I9_A63AlmCod[0] > A63AlmCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T005I9_A63AlmCod[0] < A63AlmCod ) ) )
            {
               A63AlmCod = T005I9_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               RcdFound54 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5I54( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAlmDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5I54( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound54 == 1 )
            {
               if ( A63AlmCod != Z63AlmCod )
               {
                  A63AlmCod = Z63AlmCod;
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAlmDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5I54( ) ;
                  GX_FocusControl = edtAlmDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A63AlmCod != Z63AlmCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtAlmDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5I54( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ALMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAlmDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5I54( ) ;
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
         if ( A63AlmCod != Z63AlmCod )
         {
            A63AlmCod = Z63AlmCod;
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAlmDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5I54( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005I2 */
            pr_default.execute(0, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CALMACEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z436AlmDsc, T005I2_A436AlmDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z433AlmAbr, T005I2_A433AlmAbr[0]) != 0 ) || ( Z434AlmCos != T005I2_A434AlmCos[0] ) || ( Z437AlmPed != T005I2_A437AlmPed[0] ) || ( Z438AlmSts != T005I2_A438AlmSts[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z435AlmDir, T005I2_A435AlmDir[0]) != 0 ) || ( StringUtil.StrCmp(Z439AlmSunat, T005I2_A439AlmSunat[0]) != 0 ) || ( StringUtil.StrCmp(Z139PaiCod, T005I2_A139PaiCod[0]) != 0 ) || ( StringUtil.StrCmp(Z140EstCod, T005I2_A140EstCod[0]) != 0 ) || ( StringUtil.StrCmp(Z141ProvCod, T005I2_A141ProvCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z142DisCod, T005I2_A142DisCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z436AlmDsc, T005I2_A436AlmDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmDsc");
                  GXUtil.WriteLogRaw("Old: ",Z436AlmDsc);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A436AlmDsc[0]);
               }
               if ( StringUtil.StrCmp(Z433AlmAbr, T005I2_A433AlmAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmAbr");
                  GXUtil.WriteLogRaw("Old: ",Z433AlmAbr);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A433AlmAbr[0]);
               }
               if ( Z434AlmCos != T005I2_A434AlmCos[0] )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmCos");
                  GXUtil.WriteLogRaw("Old: ",Z434AlmCos);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A434AlmCos[0]);
               }
               if ( Z437AlmPed != T005I2_A437AlmPed[0] )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmPed");
                  GXUtil.WriteLogRaw("Old: ",Z437AlmPed);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A437AlmPed[0]);
               }
               if ( Z438AlmSts != T005I2_A438AlmSts[0] )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmSts");
                  GXUtil.WriteLogRaw("Old: ",Z438AlmSts);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A438AlmSts[0]);
               }
               if ( StringUtil.StrCmp(Z435AlmDir, T005I2_A435AlmDir[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmDir");
                  GXUtil.WriteLogRaw("Old: ",Z435AlmDir);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A435AlmDir[0]);
               }
               if ( StringUtil.StrCmp(Z439AlmSunat, T005I2_A439AlmSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"AlmSunat");
                  GXUtil.WriteLogRaw("Old: ",Z439AlmSunat);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A439AlmSunat[0]);
               }
               if ( StringUtil.StrCmp(Z139PaiCod, T005I2_A139PaiCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"PaiCod");
                  GXUtil.WriteLogRaw("Old: ",Z139PaiCod);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A139PaiCod[0]);
               }
               if ( StringUtil.StrCmp(Z140EstCod, T005I2_A140EstCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"EstCod");
                  GXUtil.WriteLogRaw("Old: ",Z140EstCod);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A140EstCod[0]);
               }
               if ( StringUtil.StrCmp(Z141ProvCod, T005I2_A141ProvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"ProvCod");
                  GXUtil.WriteLogRaw("Old: ",Z141ProvCod);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A141ProvCod[0]);
               }
               if ( StringUtil.StrCmp(Z142DisCod, T005I2_A142DisCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.almacenes:[seudo value changed for attri]"+"DisCod");
                  GXUtil.WriteLogRaw("Old: ",Z142DisCod);
                  GXUtil.WriteLogRaw("Current: ",T005I2_A142DisCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CALMACEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5I54( )
      {
         BeforeValidate5I54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5I54( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5I54( 0) ;
            CheckOptimisticConcurrency5I54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5I54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5I54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005I10 */
                     pr_default.execute(8, new Object[] {A63AlmCod, A436AlmDsc, A433AlmAbr, A434AlmCos, A437AlmPed, A438AlmSts, A435AlmDir, A439AlmSunat, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CALMACEN");
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
                           ResetCaption5I0( ) ;
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
               Load5I54( ) ;
            }
            EndLevel5I54( ) ;
         }
         CloseExtendedTableCursors5I54( ) ;
      }

      protected void Update5I54( )
      {
         BeforeValidate5I54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5I54( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5I54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5I54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5I54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005I11 */
                     pr_default.execute(9, new Object[] {A436AlmDsc, A433AlmAbr, A434AlmCos, A437AlmPed, A438AlmSts, A435AlmDir, A439AlmSunat, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A63AlmCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CALMACEN");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CALMACEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5I54( ) ;
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
            EndLevel5I54( ) ;
         }
         CloseExtendedTableCursors5I54( ) ;
      }

      protected void DeferredUpdate5I54( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5I54( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5I54( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5I54( ) ;
            AfterConfirm5I54( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5I54( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005I12 */
                  pr_default.execute(10, new Object[] {A63AlmCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CALMACEN");
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
         sMode54 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5I54( ) ;
         Gx_mode = sMode54;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5I54( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005I13 */
            pr_default.execute(11, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005I14 */
            pr_default.execute(12, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005I15 */
            pr_default.execute(13, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldo Mensual de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005I16 */
            pr_default.execute(14, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel5I54( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5I54( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.almacenes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.almacenes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5I54( )
      {
         /* Scan By routine */
         /* Using cursor T005I17 */
         pr_default.execute(15);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound54 = 1;
            A63AlmCod = T005I17_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5I54( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound54 = 1;
            A63AlmCod = T005I17_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         }
      }

      protected void ScanEnd5I54( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm5I54( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV35cAlmCod;
            GXt_char4 = "ALMACENES";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV35cAlmCod = (int)(GXt_int5);
            AssignAttri("", false, "AV35cAlmCod", StringUtil.LTrimStr( (decimal)(AV35cAlmCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A63AlmCod = AV35cAlmCod;
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         }
      }

      protected void BeforeInsert5I54( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5I54( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5I54( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5I54( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5I54( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5I54( )
      {
         edtAlmDsc_Enabled = 0;
         AssignProp("", false, edtAlmDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmDsc_Enabled), 5, 0), true);
         edtAlmDir_Enabled = 0;
         AssignProp("", false, edtAlmDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmDir_Enabled), 5, 0), true);
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtDisCod_Enabled = 0;
         AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         edtAlmAbr_Enabled = 0;
         AssignProp("", false, edtAlmAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmAbr_Enabled), 5, 0), true);
         edtAlmSunat_Enabled = 0;
         AssignProp("", false, edtAlmSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmSunat_Enabled), 5, 0), true);
         edtAlmCos_Enabled = 0;
         AssignProp("", false, edtAlmCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCos_Enabled), 5, 0), true);
         chkAlmPed.Enabled = 0;
         AssignProp("", false, chkAlmPed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAlmPed.Enabled), 5, 0), true);
         cmbAlmSts.Enabled = 0;
         AssignProp("", false, cmbAlmSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAlmSts.Enabled), 5, 0), true);
         edtavCombopaicod_Enabled = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         edtavComboestcod_Enabled = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
         edtavComboprovcod_Enabled = 0;
         AssignProp("", false, edtavComboprovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Enabled), 5, 0), true);
         edtavCombodiscod_Enabled = 0;
         AssignProp("", false, edtavCombodiscod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodiscod_Enabled), 5, 0), true);
         edtAlmCod_Enabled = 0;
         AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5I54( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026726", false, true);
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
         GXEncryptionTmp = "configuracion.almacenes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AlmCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.almacenes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Almacenes");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\almacenes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z436AlmDsc", StringUtil.RTrim( Z436AlmDsc));
         GxWebStd.gx_hidden_field( context, "Z433AlmAbr", StringUtil.RTrim( Z433AlmAbr));
         GxWebStd.gx_hidden_field( context, "Z434AlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z434AlmCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z437AlmPed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z437AlmPed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z438AlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z438AlmSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z435AlmDir", Z435AlmDir);
         GxWebStd.gx_hidden_field( context, "Z439AlmSunat", Z439AlmSunat);
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N139PaiCod", StringUtil.RTrim( A139PaiCod));
         GxWebStd.gx_hidden_field( context, "N140EstCod", StringUtil.RTrim( A140EstCod));
         GxWebStd.gx_hidden_field( context, "N141ProvCod", StringUtil.RTrim( A141ProvCod));
         GxWebStd.gx_hidden_field( context, "N142DisCod", StringUtil.RTrim( A142DisCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAICOD_DATA", AV18PaiCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAICOD_DATA", AV18PaiCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTCOD_DATA", AV24EstCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTCOD_DATA", AV24EstCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROVCOD_DATA", AV27ProvCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROVCOD_DATA", AV27ProvCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCOD_DATA", AV30DisCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCOD_DATA", AV30DisCod_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vCOND_PAICOD", StringUtil.RTrim( AV26Cond_PaiCod));
         GxWebStd.gx_hidden_field( context, "vCOND_ESTCOD", StringUtil.RTrim( AV29Cond_EstCod));
         GxWebStd.gx_hidden_field( context, "vCOND_PROVCOD", StringUtil.RTrim( AV32Cond_ProvCod));
         GxWebStd.gx_hidden_field( context, "vALMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vALMCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AlmCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCALMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35cAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAICOD", StringUtil.RTrim( AV13Insert_PaiCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTCOD", StringUtil.RTrim( AV14Insert_EstCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVCOD", StringUtil.RTrim( AV15Insert_ProvCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_DISCOD", StringUtil.RTrim( AV16Insert_DisCod));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
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
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Objectcall", StringUtil.RTrim( Combo_discod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Cls", StringUtil.RTrim( Combo_discod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Selectedvalue_set", StringUtil.RTrim( Combo_discod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Selectedtext_set", StringUtil.RTrim( Combo_discod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Enabled", StringUtil.BoolToStr( Combo_discod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Datalistproc", StringUtil.RTrim( Combo_discod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_discod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Emptyitem", StringUtil.BoolToStr( Combo_discod_Emptyitem));
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
         GXEncryptionTmp = "configuracion.almacenes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AlmCod,6,0));
         return formatLink("configuracion.almacenes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Almacenes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Almacenes" ;
      }

      protected void InitializeNonKey5I54( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         A142DisCod = "";
         AssignAttri("", false, "A142DisCod", A142DisCod);
         AV35cAlmCod = 0;
         AssignAttri("", false, "AV35cAlmCod", StringUtil.LTrimStr( (decimal)(AV35cAlmCod), 6, 0));
         A436AlmDsc = "";
         AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
         A433AlmAbr = "";
         AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
         A434AlmCos = 0;
         AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
         A437AlmPed = 0;
         AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
         A435AlmDir = "";
         AssignAttri("", false, "A435AlmDir", A435AlmDir);
         A439AlmSunat = "";
         AssignAttri("", false, "A439AlmSunat", A439AlmSunat);
         A438AlmSts = 1;
         AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         Z436AlmDsc = "";
         Z433AlmAbr = "";
         Z434AlmCos = 0;
         Z437AlmPed = 0;
         Z438AlmSts = 0;
         Z435AlmDir = "";
         Z439AlmSunat = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
      }

      protected void InitAll5I54( )
      {
         A63AlmCod = 0;
         AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         InitializeNonKey5I54( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A438AlmSts = i438AlmSts;
         AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026794", true, true);
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
         context.AddJavascriptSource("configuracion/almacenes.js", "?20228181026795", false, true);
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
         lblTextblockalmdsc_Internalname = "TEXTBLOCKALMDSC";
         edtAlmDsc_Internalname = "ALMDSC";
         divUnnamedtablealmdsc_Internalname = "UNNAMEDTABLEALMDSC";
         lblTextblockalmdir_Internalname = "TEXTBLOCKALMDIR";
         edtAlmDir_Internalname = "ALMDIR";
         divUnnamedtablealmdir_Internalname = "UNNAMEDTABLEALMDIR";
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
         lblTextblockdiscod_Internalname = "TEXTBLOCKDISCOD";
         Combo_discod_Internalname = "COMBO_DISCOD";
         edtDisCod_Internalname = "DISCOD";
         divTablesplitteddiscod_Internalname = "TABLESPLITTEDDISCOD";
         edtAlmAbr_Internalname = "ALMABR";
         edtAlmSunat_Internalname = "ALMSUNAT";
         edtAlmCos_Internalname = "ALMCOS";
         chkAlmPed_Internalname = "ALMPED";
         lblTextblockalmsts_Internalname = "TEXTBLOCKALMSTS";
         cmbAlmSts_Internalname = "ALMSTS";
         divUnnamedtablealmsts_Internalname = "UNNAMEDTABLEALMSTS";
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
         edtavCombodiscod_Internalname = "vCOMBODISCOD";
         divSectionattribute_discod_Internalname = "SECTIONATTRIBUTE_DISCOD";
         edtAlmCod_Internalname = "ALMCOD";
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
         Form.Caption = "Almacenes";
         Combo_estcod_Datalistprocparametersprefix = "";
         Combo_provcod_Datalistprocparametersprefix = "";
         Combo_discod_Datalistprocparametersprefix = "";
         edtAlmCod_Jsonclick = "";
         edtAlmCod_Enabled = 1;
         edtAlmCod_Visible = 1;
         edtavCombodiscod_Jsonclick = "";
         edtavCombodiscod_Enabled = 0;
         edtavCombodiscod_Visible = 1;
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
         cmbAlmSts_Jsonclick = "";
         cmbAlmSts.Enabled = 1;
         chkAlmPed.Enabled = 1;
         edtAlmCos_Jsonclick = "";
         edtAlmCos_Enabled = 1;
         edtAlmSunat_Jsonclick = "";
         edtAlmSunat_Enabled = 1;
         edtAlmAbr_Jsonclick = "";
         edtAlmAbr_Enabled = 1;
         edtDisCod_Jsonclick = "";
         edtDisCod_Enabled = 1;
         edtDisCod_Visible = 1;
         Combo_discod_Emptyitem = Convert.ToBoolean( 0);
         Combo_discod_Datalistproc = "Configuracion.AlmacenesLoadDVCombo";
         Combo_discod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_discod_Caption = "";
         Combo_discod_Enabled = Convert.ToBoolean( -1);
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtProvCod_Visible = 1;
         Combo_provcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_provcod_Datalistproc = "Configuracion.AlmacenesLoadDVCombo";
         Combo_provcod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_provcod_Caption = "";
         Combo_provcod_Enabled = Convert.ToBoolean( -1);
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtEstCod_Visible = 1;
         Combo_estcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_estcod_Datalistproc = "Configuracion.AlmacenesLoadDVCombo";
         Combo_estcod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_estcod_Caption = "";
         Combo_estcod_Enabled = Convert.ToBoolean( -1);
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
         edtPaiCod_Visible = 1;
         Combo_paicod_Emptyitem = Convert.ToBoolean( 0);
         Combo_paicod_Datalistprocparametersprefix = " \"ComboName\": \"PaiCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AlmCod\": 0";
         Combo_paicod_Datalistproc = "Configuracion.AlmacenesLoadDVCombo";
         Combo_paicod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_paicod_Caption = "";
         Combo_paicod_Enabled = Convert.ToBoolean( -1);
         edtAlmDir_Jsonclick = "";
         edtAlmDir_Enabled = 1;
         edtAlmDsc_Jsonclick = "";
         edtAlmDsc_Enabled = 1;
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

      protected void GX14ASACALMCOD5I54( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int5 = AV35cAlmCod;
            GXt_char4 = "ALMACENES";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char4, out  GXt_int5) ;
            AV35cAlmCod = (int)(GXt_int5);
            AssignAttri("", false, "AV35cAlmCod", StringUtil.LTrimStr( (decimal)(AV35cAlmCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35cAlmCod), 6, 0, ".", "")))+"\"") ;
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
         chkAlmPed.Name = "ALMPED";
         chkAlmPed.WebTags = "";
         chkAlmPed.Caption = "";
         AssignProp("", false, chkAlmPed_Internalname, "TitleCaption", chkAlmPed.Caption, true);
         chkAlmPed.CheckedValue = "0";
         A437AlmPed = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A437AlmPed), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
         cmbAlmSts.Name = "ALMSTS";
         cmbAlmSts.WebTags = "";
         cmbAlmSts.addItem("1", "ACTIVO", 0);
         cmbAlmSts.addItem("0", "INACTIVO", 0);
         if ( cmbAlmSts.ItemCount > 0 )
         {
            if ( (0==A438AlmSts) )
            {
               A438AlmSts = 1;
               AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
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

      public void Valid_Discod( )
      {
         /* Using cursor T005I18 */
         pr_default.execute(16, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(16);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A142DisCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Distrito", "", "", "", "", "", "", "", ""), 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtDisCod_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AlmCod',fld:'vALMCOD',pic:'ZZZZZ9',hsh:true},{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7AlmCod',fld:'vALMCOD',pic:'ZZZZZ9',hsh:true},{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E125I2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A63AlmCod',fld:'ALMCOD',pic:'ZZZZZ9'},{av:'A436AlmDsc',fld:'ALMDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_ALMDSC","{handler:'Valid_Almdsc',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_ALMDSC",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_ALMDIR","{handler:'Valid_Almdir',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_ALMDIR",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_ESTCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_PROVCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_DISCOD","{handler:'Valid_Discod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'A142DisCod',fld:'DISCOD',pic:''},{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_DISCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOPAICOD","{handler:'Validv_Combopaicod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOPAICOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOESTCOD","{handler:'Validv_Comboestcod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOESTCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOPROVCOD","{handler:'Validv_Comboprovcod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOPROVCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBODISCOD","{handler:'Validv_Combodiscod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALIDV_COMBODISCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
         setEventMetadata("VALID_ALMCOD","{handler:'Valid_Almcod',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]");
         setEventMetadata("VALID_ALMCOD",",oparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z436AlmDsc = "";
         Z433AlmAbr = "";
         Z435AlmDir = "";
         Z439AlmSunat = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         N139PaiCod = "";
         N140EstCod = "";
         N141ProvCod = "";
         N142DisCod = "";
         Combo_discod_Selectedvalue_get = "";
         Combo_provcod_Selectedvalue_get = "";
         Combo_estcod_Selectedvalue_get = "";
         Combo_paicod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockalmdsc_Jsonclick = "";
         TempTags = "";
         A436AlmDsc = "";
         lblTextblockalmdir_Jsonclick = "";
         A435AlmDir = "";
         lblTextblockpaicod_Jsonclick = "";
         ucCombo_paicod = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18PaiCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockestcod_Jsonclick = "";
         ucCombo_estcod = new GXUserControl();
         AV24EstCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockprovcod_Jsonclick = "";
         ucCombo_provcod = new GXUserControl();
         AV27ProvCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockdiscod_Jsonclick = "";
         ucCombo_discod = new GXUserControl();
         AV30DisCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A433AlmAbr = "";
         A439AlmSunat = "";
         lblTextblockalmsts_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23ComboPaiCod = "";
         AV25ComboEstCod = "";
         AV28ComboProvCod = "";
         AV31ComboDisCod = "";
         AV26Cond_PaiCod = "";
         AV29Cond_EstCod = "";
         AV32Cond_ProvCod = "";
         AV13Insert_PaiCod = "";
         AV14Insert_EstCod = "";
         AV15Insert_ProvCod = "";
         AV16Insert_DisCod = "";
         AV37Pgmname = "";
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
         Combo_discod_Objectcall = "";
         Combo_discod_Class = "";
         Combo_discod_Icontype = "";
         Combo_discod_Icon = "";
         Combo_discod_Tooltip = "";
         Combo_discod_Selectedvalue_set = "";
         Combo_discod_Selectedtext_set = "";
         Combo_discod_Selectedtext_get = "";
         Combo_discod_Gamoauthtoken = "";
         Combo_discod_Ddointernalname = "";
         Combo_discod_Titlecontrolalign = "";
         Combo_discod_Dropdownoptionstype = "";
         Combo_discod_Titlecontrolidtoreplace = "";
         Combo_discod_Datalisttype = "";
         Combo_discod_Datalistfixedvalues = "";
         Combo_discod_Htmltemplate = "";
         Combo_discod_Multiplevaluestype = "";
         Combo_discod_Loadingdata = "";
         Combo_discod_Noresultsfound = "";
         Combo_discod_Emptyitemtext = "";
         Combo_discod_Onlyselectedvalues = "";
         Combo_discod_Selectalltext = "";
         Combo_discod_Multiplevaluesseparator = "";
         Combo_discod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode54 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV22Combo_DataJson = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         AV33SGAuDocGls = "";
         AV34Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         T005I5_A63AlmCod = new int[1] ;
         T005I5_A436AlmDsc = new string[] {""} ;
         T005I5_A433AlmAbr = new string[] {""} ;
         T005I5_A434AlmCos = new short[1] ;
         T005I5_A437AlmPed = new short[1] ;
         T005I5_A438AlmSts = new short[1] ;
         T005I5_A435AlmDir = new string[] {""} ;
         T005I5_A439AlmSunat = new string[] {""} ;
         T005I5_A139PaiCod = new string[] {""} ;
         T005I5_A140EstCod = new string[] {""} ;
         T005I5_A141ProvCod = new string[] {""} ;
         T005I5_A142DisCod = new string[] {""} ;
         T005I4_A139PaiCod = new string[] {""} ;
         T005I6_A139PaiCod = new string[] {""} ;
         T005I7_A63AlmCod = new int[1] ;
         T005I3_A63AlmCod = new int[1] ;
         T005I3_A436AlmDsc = new string[] {""} ;
         T005I3_A433AlmAbr = new string[] {""} ;
         T005I3_A434AlmCos = new short[1] ;
         T005I3_A437AlmPed = new short[1] ;
         T005I3_A438AlmSts = new short[1] ;
         T005I3_A435AlmDir = new string[] {""} ;
         T005I3_A439AlmSunat = new string[] {""} ;
         T005I3_A139PaiCod = new string[] {""} ;
         T005I3_A140EstCod = new string[] {""} ;
         T005I3_A141ProvCod = new string[] {""} ;
         T005I3_A142DisCod = new string[] {""} ;
         T005I8_A63AlmCod = new int[1] ;
         T005I9_A63AlmCod = new int[1] ;
         T005I2_A63AlmCod = new int[1] ;
         T005I2_A436AlmDsc = new string[] {""} ;
         T005I2_A433AlmAbr = new string[] {""} ;
         T005I2_A434AlmCos = new short[1] ;
         T005I2_A437AlmPed = new short[1] ;
         T005I2_A438AlmSts = new short[1] ;
         T005I2_A435AlmDir = new string[] {""} ;
         T005I2_A439AlmSunat = new string[] {""} ;
         T005I2_A139PaiCod = new string[] {""} ;
         T005I2_A140EstCod = new string[] {""} ;
         T005I2_A141ProvCod = new string[] {""} ;
         T005I2_A142DisCod = new string[] {""} ;
         T005I13_A348UsuCod = new string[] {""} ;
         T005I13_A349UsuAlmCod = new int[1] ;
         T005I14_A63AlmCod = new int[1] ;
         T005I14_A28ProdCod = new string[] {""} ;
         T005I15_A59SalCosAno = new int[1] ;
         T005I15_A60SalCosMes = new short[1] ;
         T005I15_A61SalCosAlmCod = new int[1] ;
         T005I15_A62SalCosProdCod = new string[] {""} ;
         T005I16_A13MvATip = new string[] {""} ;
         T005I16_A14MvACod = new string[] {""} ;
         T005I17_A63AlmCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char4 = "";
         T005I18_A139PaiCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.almacenes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.almacenes__default(),
            new Object[][] {
                new Object[] {
               T005I2_A63AlmCod, T005I2_A436AlmDsc, T005I2_A433AlmAbr, T005I2_A434AlmCos, T005I2_A437AlmPed, T005I2_A438AlmSts, T005I2_A435AlmDir, T005I2_A439AlmSunat, T005I2_A139PaiCod, T005I2_A140EstCod,
               T005I2_A141ProvCod, T005I2_A142DisCod
               }
               , new Object[] {
               T005I3_A63AlmCod, T005I3_A436AlmDsc, T005I3_A433AlmAbr, T005I3_A434AlmCos, T005I3_A437AlmPed, T005I3_A438AlmSts, T005I3_A435AlmDir, T005I3_A439AlmSunat, T005I3_A139PaiCod, T005I3_A140EstCod,
               T005I3_A141ProvCod, T005I3_A142DisCod
               }
               , new Object[] {
               T005I4_A139PaiCod
               }
               , new Object[] {
               T005I5_A63AlmCod, T005I5_A436AlmDsc, T005I5_A433AlmAbr, T005I5_A434AlmCos, T005I5_A437AlmPed, T005I5_A438AlmSts, T005I5_A435AlmDir, T005I5_A439AlmSunat, T005I5_A139PaiCod, T005I5_A140EstCod,
               T005I5_A141ProvCod, T005I5_A142DisCod
               }
               , new Object[] {
               T005I6_A139PaiCod
               }
               , new Object[] {
               T005I7_A63AlmCod
               }
               , new Object[] {
               T005I8_A63AlmCod
               }
               , new Object[] {
               T005I9_A63AlmCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005I13_A348UsuCod, T005I13_A349UsuAlmCod
               }
               , new Object[] {
               T005I14_A63AlmCod, T005I14_A28ProdCod
               }
               , new Object[] {
               T005I15_A59SalCosAno, T005I15_A60SalCosMes, T005I15_A61SalCosAlmCod, T005I15_A62SalCosProdCod
               }
               , new Object[] {
               T005I16_A13MvATip, T005I16_A14MvACod
               }
               , new Object[] {
               T005I17_A63AlmCod
               }
               , new Object[] {
               T005I18_A139PaiCod
               }
            }
         );
         AV37Pgmname = "Configuracion.Almacenes";
         Z438AlmSts = 1;
         A438AlmSts = 1;
         i438AlmSts = 1;
      }

      private short Z434AlmCos ;
      private short Z437AlmPed ;
      private short Z438AlmSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A437AlmPed ;
      private short A438AlmSts ;
      private short A434AlmCos ;
      private short Gx_BScreen ;
      private short RcdFound54 ;
      private short GX_JID ;
      private short nIsDirty_54 ;
      private short gxajaxcallmode ;
      private short i438AlmSts ;
      private int wcpOAV7AlmCod ;
      private int Z63AlmCod ;
      private int AV7AlmCod ;
      private int trnEnded ;
      private int edtAlmDsc_Enabled ;
      private int edtAlmDir_Enabled ;
      private int edtPaiCod_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Visible ;
      private int edtEstCod_Enabled ;
      private int edtProvCod_Visible ;
      private int edtProvCod_Enabled ;
      private int edtDisCod_Visible ;
      private int edtDisCod_Enabled ;
      private int edtAlmAbr_Enabled ;
      private int edtAlmSunat_Enabled ;
      private int edtAlmCos_Enabled ;
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
      private int edtavCombodiscod_Visible ;
      private int edtavCombodiscod_Enabled ;
      private int A63AlmCod ;
      private int edtAlmCod_Visible ;
      private int edtAlmCod_Enabled ;
      private int AV35cAlmCod ;
      private int Combo_paicod_Datalistupdateminimumcharacters ;
      private int Combo_paicod_Gxcontroltype ;
      private int Combo_estcod_Datalistupdateminimumcharacters ;
      private int Combo_estcod_Gxcontroltype ;
      private int Combo_provcod_Datalistupdateminimumcharacters ;
      private int Combo_provcod_Gxcontroltype ;
      private int Combo_discod_Datalistupdateminimumcharacters ;
      private int Combo_discod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV38GXV1 ;
      private int idxLst ;
      private long GXt_int5 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z436AlmDsc ;
      private string Z433AlmAbr ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z142DisCod ;
      private string N139PaiCod ;
      private string N140EstCod ;
      private string N141ProvCod ;
      private string N142DisCod ;
      private string Combo_discod_Selectedvalue_get ;
      private string Combo_provcod_Selectedvalue_get ;
      private string Combo_estcod_Selectedvalue_get ;
      private string Combo_paicod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAlmDsc_Internalname ;
      private string cmbAlmSts_Internalname ;
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
      private string divUnnamedtablealmdsc_Internalname ;
      private string lblTextblockalmdsc_Internalname ;
      private string lblTextblockalmdsc_Jsonclick ;
      private string TempTags ;
      private string A436AlmDsc ;
      private string edtAlmDsc_Jsonclick ;
      private string divUnnamedtablealmdir_Internalname ;
      private string lblTextblockalmdir_Internalname ;
      private string lblTextblockalmdir_Jsonclick ;
      private string edtAlmDir_Internalname ;
      private string edtAlmDir_Jsonclick ;
      private string divTablesplittedpaicod_Internalname ;
      private string lblTextblockpaicod_Internalname ;
      private string lblTextblockpaicod_Jsonclick ;
      private string Combo_paicod_Caption ;
      private string Combo_paicod_Cls ;
      private string Combo_paicod_Datalistproc ;
      private string Combo_paicod_Datalistprocparametersprefix ;
      private string Combo_paicod_Internalname ;
      private string edtPaiCod_Internalname ;
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
      private string divTablesplitteddiscod_Internalname ;
      private string lblTextblockdiscod_Internalname ;
      private string lblTextblockdiscod_Jsonclick ;
      private string Combo_discod_Caption ;
      private string Combo_discod_Cls ;
      private string Combo_discod_Datalistproc ;
      private string Combo_discod_Internalname ;
      private string edtDisCod_Internalname ;
      private string edtDisCod_Jsonclick ;
      private string edtAlmAbr_Internalname ;
      private string A433AlmAbr ;
      private string edtAlmAbr_Jsonclick ;
      private string edtAlmSunat_Internalname ;
      private string edtAlmSunat_Jsonclick ;
      private string edtAlmCos_Internalname ;
      private string edtAlmCos_Jsonclick ;
      private string chkAlmPed_Internalname ;
      private string divUnnamedtablealmsts_Internalname ;
      private string lblTextblockalmsts_Internalname ;
      private string lblTextblockalmsts_Jsonclick ;
      private string cmbAlmSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_paicod_Internalname ;
      private string edtavCombopaicod_Internalname ;
      private string AV23ComboPaiCod ;
      private string edtavCombopaicod_Jsonclick ;
      private string divSectionattribute_estcod_Internalname ;
      private string edtavComboestcod_Internalname ;
      private string AV25ComboEstCod ;
      private string edtavComboestcod_Jsonclick ;
      private string divSectionattribute_provcod_Internalname ;
      private string edtavComboprovcod_Internalname ;
      private string AV28ComboProvCod ;
      private string edtavComboprovcod_Jsonclick ;
      private string divSectionattribute_discod_Internalname ;
      private string edtavCombodiscod_Internalname ;
      private string AV31ComboDisCod ;
      private string edtavCombodiscod_Jsonclick ;
      private string edtAlmCod_Internalname ;
      private string edtAlmCod_Jsonclick ;
      private string AV26Cond_PaiCod ;
      private string AV29Cond_EstCod ;
      private string AV32Cond_ProvCod ;
      private string AV13Insert_PaiCod ;
      private string AV14Insert_EstCod ;
      private string AV15Insert_ProvCod ;
      private string AV16Insert_DisCod ;
      private string AV37Pgmname ;
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
      private string Combo_discod_Objectcall ;
      private string Combo_discod_Class ;
      private string Combo_discod_Icontype ;
      private string Combo_discod_Icon ;
      private string Combo_discod_Tooltip ;
      private string Combo_discod_Selectedvalue_set ;
      private string Combo_discod_Selectedtext_set ;
      private string Combo_discod_Selectedtext_get ;
      private string Combo_discod_Gamoauthtoken ;
      private string Combo_discod_Ddointernalname ;
      private string Combo_discod_Titlecontrolalign ;
      private string Combo_discod_Dropdownoptionstype ;
      private string Combo_discod_Titlecontrolidtoreplace ;
      private string Combo_discod_Datalisttype ;
      private string Combo_discod_Datalistfixedvalues ;
      private string Combo_discod_Datalistprocparametersprefix ;
      private string Combo_discod_Htmltemplate ;
      private string Combo_discod_Multiplevaluestype ;
      private string Combo_discod_Loadingdata ;
      private string Combo_discod_Noresultsfound ;
      private string Combo_discod_Emptyitemtext ;
      private string Combo_discod_Onlyselectedvalues ;
      private string Combo_discod_Selectalltext ;
      private string Combo_discod_Multiplevaluesseparator ;
      private string Combo_discod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode54 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char4 ;
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
      private bool Combo_discod_Emptyitem ;
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
      private bool Combo_discod_Enabled ;
      private bool Combo_discod_Visible ;
      private bool Combo_discod_Allowmultipleselection ;
      private bool Combo_discod_Isgriditem ;
      private bool Combo_discod_Hasdescription ;
      private bool Combo_discod_Includeonlyselectedoption ;
      private bool Combo_discod_Includeselectalloption ;
      private bool Combo_discod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV22Combo_DataJson ;
      private string Z435AlmDir ;
      private string Z439AlmSunat ;
      private string A435AlmDir ;
      private string A439AlmSunat ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string AV33SGAuDocGls ;
      private string AV34Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_paicod ;
      private GXUserControl ucCombo_estcod ;
      private GXUserControl ucCombo_provcod ;
      private GXUserControl ucCombo_discod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkAlmPed ;
      private GXCombobox cmbAlmSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005I5_A63AlmCod ;
      private string[] T005I5_A436AlmDsc ;
      private string[] T005I5_A433AlmAbr ;
      private short[] T005I5_A434AlmCos ;
      private short[] T005I5_A437AlmPed ;
      private short[] T005I5_A438AlmSts ;
      private string[] T005I5_A435AlmDir ;
      private string[] T005I5_A439AlmSunat ;
      private string[] T005I5_A139PaiCod ;
      private string[] T005I5_A140EstCod ;
      private string[] T005I5_A141ProvCod ;
      private string[] T005I5_A142DisCod ;
      private string[] T005I4_A139PaiCod ;
      private string[] T005I6_A139PaiCod ;
      private int[] T005I7_A63AlmCod ;
      private int[] T005I3_A63AlmCod ;
      private string[] T005I3_A436AlmDsc ;
      private string[] T005I3_A433AlmAbr ;
      private short[] T005I3_A434AlmCos ;
      private short[] T005I3_A437AlmPed ;
      private short[] T005I3_A438AlmSts ;
      private string[] T005I3_A435AlmDir ;
      private string[] T005I3_A439AlmSunat ;
      private string[] T005I3_A139PaiCod ;
      private string[] T005I3_A140EstCod ;
      private string[] T005I3_A141ProvCod ;
      private string[] T005I3_A142DisCod ;
      private int[] T005I8_A63AlmCod ;
      private int[] T005I9_A63AlmCod ;
      private int[] T005I2_A63AlmCod ;
      private string[] T005I2_A436AlmDsc ;
      private string[] T005I2_A433AlmAbr ;
      private short[] T005I2_A434AlmCos ;
      private short[] T005I2_A437AlmPed ;
      private short[] T005I2_A438AlmSts ;
      private string[] T005I2_A435AlmDir ;
      private string[] T005I2_A439AlmSunat ;
      private string[] T005I2_A139PaiCod ;
      private string[] T005I2_A140EstCod ;
      private string[] T005I2_A141ProvCod ;
      private string[] T005I2_A142DisCod ;
      private string[] T005I13_A348UsuCod ;
      private int[] T005I13_A349UsuAlmCod ;
      private int[] T005I14_A63AlmCod ;
      private string[] T005I14_A28ProdCod ;
      private int[] T005I15_A59SalCosAno ;
      private short[] T005I15_A60SalCosMes ;
      private int[] T005I15_A61SalCosAlmCod ;
      private string[] T005I15_A62SalCosProdCod ;
      private string[] T005I16_A13MvATip ;
      private string[] T005I16_A14MvACod ;
      private int[] T005I17_A63AlmCod ;
      private string[] T005I18_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18PaiCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24EstCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27ProvCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30DisCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class almacenes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class almacenes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005I5;
        prmT005I5 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I4;
        prmT005I4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005I6;
        prmT005I6 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005I7;
        prmT005I7 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I3;
        prmT005I3 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I8;
        prmT005I8 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I9;
        prmT005I9 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I2;
        prmT005I2 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I10;
        prmT005I10 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AlmDsc",GXType.NChar,100,0) ,
        new ParDef("@AlmAbr",GXType.NChar,10,0) ,
        new ParDef("@AlmCos",GXType.Int16,1,0) ,
        new ParDef("@AlmPed",GXType.Int16,1,0) ,
        new ParDef("@AlmSts",GXType.Int16,1,0) ,
        new ParDef("@AlmDir",GXType.NVarChar,100,0) ,
        new ParDef("@AlmSunat",GXType.NVarChar,4,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT005I11;
        prmT005I11 = new Object[] {
        new ParDef("@AlmDsc",GXType.NChar,100,0) ,
        new ParDef("@AlmAbr",GXType.NChar,10,0) ,
        new ParDef("@AlmCos",GXType.Int16,1,0) ,
        new ParDef("@AlmPed",GXType.Int16,1,0) ,
        new ParDef("@AlmSts",GXType.Int16,1,0) ,
        new ParDef("@AlmDir",GXType.NVarChar,100,0) ,
        new ParDef("@AlmSunat",GXType.NVarChar,4,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I12;
        prmT005I12 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I13;
        prmT005I13 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I14;
        prmT005I14 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I15;
        prmT005I15 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I16;
        prmT005I16 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT005I17;
        prmT005I17 = new Object[] {
        };
        Object[] prmT005I18;
        prmT005I18 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005I2", "SELECT [AlmCod], [AlmDsc], [AlmAbr], [AlmCos], [AlmPed], [AlmSts], [AlmDir], [AlmSunat], [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CALMACEN] WITH (UPDLOCK) WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I3", "SELECT [AlmCod], [AlmDsc], [AlmAbr], [AlmCos], [AlmPed], [AlmSts], [AlmDir], [AlmSunat], [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I4", "SELECT [PaiCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I5", "SELECT TM1.[AlmCod], TM1.[AlmDsc], TM1.[AlmAbr], TM1.[AlmCos], TM1.[AlmPed], TM1.[AlmSts], TM1.[AlmDir], TM1.[AlmSunat], TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod], TM1.[DisCod] FROM [CALMACEN] TM1 WHERE TM1.[AlmCod] = @AlmCod ORDER BY TM1.[AlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I6", "SELECT [PaiCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I7", "SELECT [AlmCod] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I8", "SELECT TOP 1 [AlmCod] FROM [CALMACEN] WHERE ( [AlmCod] > @AlmCod) ORDER BY [AlmCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005I8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005I9", "SELECT TOP 1 [AlmCod] FROM [CALMACEN] WHERE ( [AlmCod] < @AlmCod) ORDER BY [AlmCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005I9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005I10", "INSERT INTO [CALMACEN]([AlmCod], [AlmDsc], [AlmAbr], [AlmCos], [AlmPed], [AlmSts], [AlmDir], [AlmSunat], [PaiCod], [EstCod], [ProvCod], [DisCod]) VALUES(@AlmCod, @AlmDsc, @AlmAbr, @AlmCos, @AlmPed, @AlmSts, @AlmDir, @AlmSunat, @PaiCod, @EstCod, @ProvCod, @DisCod)", GxErrorMask.GX_NOMASK,prmT005I10)
           ,new CursorDef("T005I11", "UPDATE [CALMACEN] SET [AlmDsc]=@AlmDsc, [AlmAbr]=@AlmAbr, [AlmCos]=@AlmCos, [AlmPed]=@AlmPed, [AlmSts]=@AlmSts, [AlmDir]=@AlmDir, [AlmSunat]=@AlmSunat, [PaiCod]=@PaiCod, [EstCod]=@EstCod, [ProvCod]=@ProvCod, [DisCod]=@DisCod  WHERE [AlmCod] = @AlmCod", GxErrorMask.GX_NOMASK,prmT005I11)
           ,new CursorDef("T005I12", "DELETE FROM [CALMACEN]  WHERE [AlmCod] = @AlmCod", GxErrorMask.GX_NOMASK,prmT005I12)
           ,new CursorDef("T005I13", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuAlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005I14", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005I15", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod] FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosAlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005I16", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MvAlm] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005I17", "SELECT [AlmCod] FROM [CALMACEN] ORDER BY [AlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005I17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005I18", "SELECT [PaiCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005I18,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
