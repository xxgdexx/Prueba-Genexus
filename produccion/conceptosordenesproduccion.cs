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
namespace GeneXus.Programs.produccion {
   public class conceptosordenesproduccion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"vCPOCONCCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASACPOCONCCOD6J141( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A314PoConcLinCod = (int)(NumberUtil.Val( GetPar( "PoConcLinCod"), "."));
            n314PoConcLinCod = false;
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A314PoConcLinCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A315PoConcDCueCod = GetPar( "PoConcDCueCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A315PoConcDCueCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_level1") == 0 )
         {
            nRC_GXsfl_49 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_49"), "."));
            nGXsfl_49_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_49_idx"), "."));
            sGXsfl_49_idx = GetPar( "sGXsfl_49_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridlevel_level1_newrow( ) ;
            return  ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.conceptosordenesproduccion.aspx")), "produccion.conceptosordenesproduccion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.conceptosordenesproduccion.aspx")))) ;
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
                  AV7PoConcCod = (int)(NumberUtil.Val( GetPar( "PoConcCod"), "."));
                  AssignAttri("", false, "AV7PoConcCod", StringUtil.LTrimStr( (decimal)(AV7PoConcCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPOCONCCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PoConcCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Conceptos de Ordenes de Produccion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPoConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public conceptosordenesproduccion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesproduccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PoConcCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PoConcCod = aP1_PoConcCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPoConcTip = new GXCombobox();
         cmbPoConcSts = new GXCombobox();
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
         if ( cmbPoConcTip.ItemCount > 0 )
         {
            A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
            AssignProp("", false, cmbPoConcTip_Internalname, "Values", cmbPoConcTip.ToJavascriptSource(), true);
         }
         if ( cmbPoConcSts.ItemCount > 0 )
         {
            A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0))), "."));
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            AssignProp("", false, cmbPoConcSts_Internalname, "Values", cmbPoConcSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcDsc_Internalname, "Concepto", "col-sm-3 AttributeRealWidth100WithLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcDsc_Internalname, StringUtil.RTrim( A1648PoConcDsc), StringUtil.RTrim( context.localUtil.Format( A1648PoConcDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcDsc_Jsonclick, 0, "AttributeRealWidth100With", "", "", "", "", 1, edtPoConcDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPoConcTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPoConcTip_Internalname, "Tipo de Distribución", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPoConcTip, cmbPoConcTip_Internalname, StringUtil.RTrim( A1650PoConcTip), 1, cmbPoConcTip_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPoConcTip.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
         AssignProp("", false, cmbPoConcTip_Internalname, "Values", (string)(cmbPoConcTip.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpoconclincod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpoconclincod_Internalname, "Linea Producto", "", "", lblTextblockpoconclincod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_poconclincod.SetProperty("Caption", Combo_poconclincod_Caption);
         ucCombo_poconclincod.SetProperty("Cls", Combo_poconclincod_Cls);
         ucCombo_poconclincod.SetProperty("DataListProc", Combo_poconclincod_Datalistproc);
         ucCombo_poconclincod.SetProperty("DataListProcParametersPrefix", Combo_poconclincod_Datalistprocparametersprefix);
         ucCombo_poconclincod.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_poconclincod.SetProperty("DropDownOptionsData", AV18PoConcLinCod_Data);
         ucCombo_poconclincod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_poconclincod_Internalname, "COMBO_POCONCLINCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcLinCod_Internalname, "Linea Producto", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A314PoConcLinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A314PoConcLinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcLinCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPoConcLinCod_Visible, edtPoConcLinCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPoConcSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPoConcSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPoConcSts, cmbPoConcSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0)), 1, cmbPoConcSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbPoConcSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         AssignProp("", false, cmbPoConcSts_Internalname, "Values", (string)(cmbPoConcSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_level1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "left", "top", "", "", "div");
         gxdraw_Gridlevel_level1( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_poconclincod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombopoconclincod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboPoConcLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombopoconclincod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboPoConcLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboPoConcLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopoconclincod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopoconclincod_Visible, edtavCombopoconclincod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* User Defined Control */
         ucCombo_poconcdcuecod.SetProperty("Caption", Combo_poconcdcuecod_Caption);
         ucCombo_poconcdcuecod.SetProperty("Cls", Combo_poconcdcuecod_Cls);
         ucCombo_poconcdcuecod.SetProperty("IsGridItem", Combo_poconcdcuecod_Isgriditem);
         ucCombo_poconcdcuecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_poconcdcuecod.SetProperty("DropDownOptionsData", AV13PoConcDCueCod_Data);
         ucCombo_poconcdcuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_poconcdcuecod_Internalname, "COMBO_POCONCDCUECODContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A313PoConcCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPoConcCod_Visible, edtPoConcCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Produccion\\ConceptosOrdenesProduccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridlevel_level1( )
      {
         /*  Grid Control  */
         Gridlevel_level1Container.AddObjectProperty("GridName", "Gridlevel_level1");
         Gridlevel_level1Container.AddObjectProperty("Header", subGridlevel_level1_Header);
         Gridlevel_level1Container.AddObjectProperty("Class", "WorkWith");
         Gridlevel_level1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("CmpContext", "");
         Gridlevel_level1Container.AddObjectProperty("InMasterPage", "false");
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A315PoConcDCueCod));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A1647PoConcDCueDsc));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A316PoConcCosCod));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectedindex), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowselection), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowhovering), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_49_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount182 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_182 = 1;
               ScanStart6J182( ) ;
               while ( RcdFound182 != 0 )
               {
                  init_level_properties182( ) ;
                  getByPrimaryKey6J182( ) ;
                  AddRow6J182( ) ;
                  ScanNext6J182( ) ;
               }
               ScanEnd6J182( ) ;
               nBlankRcdCount182 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal6J182( ) ;
            standaloneModal6J182( ) ;
            sMode182 = Gx_mode;
            while ( nGXsfl_49_idx < nRC_GXsfl_49 )
            {
               bGXsfl_49_Refreshing = true;
               ReadRow6J182( ) ;
               edtPoConcDCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUECOD_"+sGXsfl_49_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtPoConcDCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUEDSC_"+sGXsfl_49_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtPoConcCosCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCCOSCOD_"+sGXsfl_49_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPoConcCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCosCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               if ( ( nRcdExists_182 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal6J182( ) ;
               }
               SendRow6J182( ) ;
               bGXsfl_49_Refreshing = false;
            }
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount182 = 5;
            nRcdExists_182 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart6J182( ) ;
               while ( RcdFound182 != 0 )
               {
                  sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_49182( ) ;
                  init_level_properties182( ) ;
                  standaloneNotModal6J182( ) ;
                  getByPrimaryKey6J182( ) ;
                  standaloneModal6J182( ) ;
                  AddRow6J182( ) ;
                  ScanNext6J182( ) ;
               }
               ScanEnd6J182( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode182 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx+1), 4, 0), 4, "0");
            SubsflControlProps_49182( ) ;
            InitAll6J182( ) ;
            init_level_properties182( ) ;
            nRcdExists_182 = 0;
            nIsMod_182 = 0;
            nRcdDeleted_182 = 0;
            nBlankRcdCount182 = (short)(nBlankRcdUsr182+nBlankRcdCount182);
            fRowAdded = 0;
            while ( nBlankRcdCount182 > 0 )
            {
               standaloneNotModal6J182( ) ;
               standaloneModal6J182( ) ;
               AddRow6J182( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtPoConcDCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount182 = (short)(nBlankRcdCount182-1);
            }
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_level1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_level1", Gridlevel_level1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_level1ContainerData", Gridlevel_level1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_level1ContainerData"+"V", Gridlevel_level1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_level1ContainerData"+"V"+"\" value='"+Gridlevel_level1Container.GridValuesHidden()+"'/>") ;
         }
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
         E116J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPOCONCLINCOD_DATA"), AV18PoConcLinCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPOCONCDCUECOD_DATA"), AV13PoConcDCueCod_Data);
               /* Read saved values. */
               Z313PoConcCod = (int)(context.localUtil.CToN( cgiGet( "Z313PoConcCod"), ".", ","));
               Z1648PoConcDsc = cgiGet( "Z1648PoConcDsc");
               Z1650PoConcTip = cgiGet( "Z1650PoConcTip");
               Z1649PoConcSts = (short)(context.localUtil.CToN( cgiGet( "Z1649PoConcSts"), ".", ","));
               Z314PoConcLinCod = (int)(context.localUtil.CToN( cgiGet( "Z314PoConcLinCod"), ".", ","));
               n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_49 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_49"), ".", ","));
               N314PoConcLinCod = (int)(context.localUtil.CToN( cgiGet( "N314PoConcLinCod"), ".", ","));
               n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
               AV7PoConcCod = (int)(context.localUtil.CToN( cgiGet( "vPOCONCCOD"), ".", ","));
               AV21cPoConcCod = (int)(context.localUtil.CToN( cgiGet( "vCPOCONCCOD"), ".", ","));
               AV11Insert_PoConcLinCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_POCONCLINCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_poconclincod_Objectcall = cgiGet( "COMBO_POCONCLINCOD_Objectcall");
               Combo_poconclincod_Class = cgiGet( "COMBO_POCONCLINCOD_Class");
               Combo_poconclincod_Icontype = cgiGet( "COMBO_POCONCLINCOD_Icontype");
               Combo_poconclincod_Icon = cgiGet( "COMBO_POCONCLINCOD_Icon");
               Combo_poconclincod_Caption = cgiGet( "COMBO_POCONCLINCOD_Caption");
               Combo_poconclincod_Tooltip = cgiGet( "COMBO_POCONCLINCOD_Tooltip");
               Combo_poconclincod_Cls = cgiGet( "COMBO_POCONCLINCOD_Cls");
               Combo_poconclincod_Selectedvalue_set = cgiGet( "COMBO_POCONCLINCOD_Selectedvalue_set");
               Combo_poconclincod_Selectedvalue_get = cgiGet( "COMBO_POCONCLINCOD_Selectedvalue_get");
               Combo_poconclincod_Selectedtext_set = cgiGet( "COMBO_POCONCLINCOD_Selectedtext_set");
               Combo_poconclincod_Selectedtext_get = cgiGet( "COMBO_POCONCLINCOD_Selectedtext_get");
               Combo_poconclincod_Gamoauthtoken = cgiGet( "COMBO_POCONCLINCOD_Gamoauthtoken");
               Combo_poconclincod_Ddointernalname = cgiGet( "COMBO_POCONCLINCOD_Ddointernalname");
               Combo_poconclincod_Titlecontrolalign = cgiGet( "COMBO_POCONCLINCOD_Titlecontrolalign");
               Combo_poconclincod_Dropdownoptionstype = cgiGet( "COMBO_POCONCLINCOD_Dropdownoptionstype");
               Combo_poconclincod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Enabled"));
               Combo_poconclincod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Visible"));
               Combo_poconclincod_Titlecontrolidtoreplace = cgiGet( "COMBO_POCONCLINCOD_Titlecontrolidtoreplace");
               Combo_poconclincod_Datalisttype = cgiGet( "COMBO_POCONCLINCOD_Datalisttype");
               Combo_poconclincod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Allowmultipleselection"));
               Combo_poconclincod_Datalistfixedvalues = cgiGet( "COMBO_POCONCLINCOD_Datalistfixedvalues");
               Combo_poconclincod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Isgriditem"));
               Combo_poconclincod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Hasdescription"));
               Combo_poconclincod_Datalistproc = cgiGet( "COMBO_POCONCLINCOD_Datalistproc");
               Combo_poconclincod_Datalistprocparametersprefix = cgiGet( "COMBO_POCONCLINCOD_Datalistprocparametersprefix");
               Combo_poconclincod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_POCONCLINCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_poconclincod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Includeonlyselectedoption"));
               Combo_poconclincod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Includeselectalloption"));
               Combo_poconclincod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Emptyitem"));
               Combo_poconclincod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_POCONCLINCOD_Includeaddnewoption"));
               Combo_poconclincod_Htmltemplate = cgiGet( "COMBO_POCONCLINCOD_Htmltemplate");
               Combo_poconclincod_Multiplevaluestype = cgiGet( "COMBO_POCONCLINCOD_Multiplevaluestype");
               Combo_poconclincod_Loadingdata = cgiGet( "COMBO_POCONCLINCOD_Loadingdata");
               Combo_poconclincod_Noresultsfound = cgiGet( "COMBO_POCONCLINCOD_Noresultsfound");
               Combo_poconclincod_Emptyitemtext = cgiGet( "COMBO_POCONCLINCOD_Emptyitemtext");
               Combo_poconclincod_Onlyselectedvalues = cgiGet( "COMBO_POCONCLINCOD_Onlyselectedvalues");
               Combo_poconclincod_Selectalltext = cgiGet( "COMBO_POCONCLINCOD_Selectalltext");
               Combo_poconclincod_Multiplevaluesseparator = cgiGet( "COMBO_POCONCLINCOD_Multiplevaluesseparator");
               Combo_poconclincod_Addnewoptiontext = cgiGet( "COMBO_POCONCLINCOD_Addnewoptiontext");
               Combo_poconclincod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_POCONCLINCOD_Gxcontroltype"), ".", ","));
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
               Combo_poconcdcuecod_Objectcall = cgiGet( "COMBO_POCONCDCUECOD_Objectcall");
               Combo_poconcdcuecod_Class = cgiGet( "COMBO_POCONCDCUECOD_Class");
               Combo_poconcdcuecod_Icontype = cgiGet( "COMBO_POCONCDCUECOD_Icontype");
               Combo_poconcdcuecod_Icon = cgiGet( "COMBO_POCONCDCUECOD_Icon");
               Combo_poconcdcuecod_Caption = cgiGet( "COMBO_POCONCDCUECOD_Caption");
               Combo_poconcdcuecod_Tooltip = cgiGet( "COMBO_POCONCDCUECOD_Tooltip");
               Combo_poconcdcuecod_Cls = cgiGet( "COMBO_POCONCDCUECOD_Cls");
               Combo_poconcdcuecod_Selectedvalue_set = cgiGet( "COMBO_POCONCDCUECOD_Selectedvalue_set");
               Combo_poconcdcuecod_Selectedvalue_get = cgiGet( "COMBO_POCONCDCUECOD_Selectedvalue_get");
               Combo_poconcdcuecod_Selectedtext_set = cgiGet( "COMBO_POCONCDCUECOD_Selectedtext_set");
               Combo_poconcdcuecod_Selectedtext_get = cgiGet( "COMBO_POCONCDCUECOD_Selectedtext_get");
               Combo_poconcdcuecod_Gamoauthtoken = cgiGet( "COMBO_POCONCDCUECOD_Gamoauthtoken");
               Combo_poconcdcuecod_Ddointernalname = cgiGet( "COMBO_POCONCDCUECOD_Ddointernalname");
               Combo_poconcdcuecod_Titlecontrolalign = cgiGet( "COMBO_POCONCDCUECOD_Titlecontrolalign");
               Combo_poconcdcuecod_Dropdownoptionstype = cgiGet( "COMBO_POCONCDCUECOD_Dropdownoptionstype");
               Combo_poconcdcuecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Enabled"));
               Combo_poconcdcuecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Visible"));
               Combo_poconcdcuecod_Titlecontrolidtoreplace = cgiGet( "COMBO_POCONCDCUECOD_Titlecontrolidtoreplace");
               Combo_poconcdcuecod_Datalisttype = cgiGet( "COMBO_POCONCDCUECOD_Datalisttype");
               Combo_poconcdcuecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Allowmultipleselection"));
               Combo_poconcdcuecod_Datalistfixedvalues = cgiGet( "COMBO_POCONCDCUECOD_Datalistfixedvalues");
               Combo_poconcdcuecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Isgriditem"));
               Combo_poconcdcuecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Hasdescription"));
               Combo_poconcdcuecod_Datalistproc = cgiGet( "COMBO_POCONCDCUECOD_Datalistproc");
               Combo_poconcdcuecod_Datalistprocparametersprefix = cgiGet( "COMBO_POCONCDCUECOD_Datalistprocparametersprefix");
               Combo_poconcdcuecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_POCONCDCUECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_poconcdcuecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Includeonlyselectedoption"));
               Combo_poconcdcuecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Includeselectalloption"));
               Combo_poconcdcuecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Emptyitem"));
               Combo_poconcdcuecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_POCONCDCUECOD_Includeaddnewoption"));
               Combo_poconcdcuecod_Htmltemplate = cgiGet( "COMBO_POCONCDCUECOD_Htmltemplate");
               Combo_poconcdcuecod_Multiplevaluestype = cgiGet( "COMBO_POCONCDCUECOD_Multiplevaluestype");
               Combo_poconcdcuecod_Loadingdata = cgiGet( "COMBO_POCONCDCUECOD_Loadingdata");
               Combo_poconcdcuecod_Noresultsfound = cgiGet( "COMBO_POCONCDCUECOD_Noresultsfound");
               Combo_poconcdcuecod_Emptyitemtext = cgiGet( "COMBO_POCONCDCUECOD_Emptyitemtext");
               Combo_poconcdcuecod_Onlyselectedvalues = cgiGet( "COMBO_POCONCDCUECOD_Onlyselectedvalues");
               Combo_poconcdcuecod_Selectalltext = cgiGet( "COMBO_POCONCDCUECOD_Selectalltext");
               Combo_poconcdcuecod_Multiplevaluesseparator = cgiGet( "COMBO_POCONCDCUECOD_Multiplevaluesseparator");
               Combo_poconcdcuecod_Addnewoptiontext = cgiGet( "COMBO_POCONCDCUECOD_Addnewoptiontext");
               Combo_poconcdcuecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_POCONCDCUECOD_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A1648PoConcDsc = cgiGet( edtPoConcDsc_Internalname);
               AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
               cmbPoConcTip.Name = cmbPoConcTip_Internalname;
               cmbPoConcTip.CurrentValue = cgiGet( cmbPoConcTip_Internalname);
               A1650PoConcTip = cgiGet( cmbPoConcTip_Internalname);
               AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPoConcLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPoConcLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POCONCLINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPoConcLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A314PoConcLinCod = 0;
                  n314PoConcLinCod = false;
                  AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
               }
               else
               {
                  A314PoConcLinCod = (int)(context.localUtil.CToN( cgiGet( edtPoConcLinCod_Internalname), ".", ","));
                  n314PoConcLinCod = false;
                  AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
               }
               n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
               cmbPoConcSts.Name = cmbPoConcSts_Internalname;
               cmbPoConcSts.CurrentValue = cgiGet( cmbPoConcSts_Internalname);
               A1649PoConcSts = (short)(NumberUtil.Val( cgiGet( cmbPoConcSts_Internalname), "."));
               AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
               AV19ComboPoConcLinCod = (int)(context.localUtil.CToN( cgiGet( edtavCombopoconclincod_Internalname), ".", ","));
               AssignAttri("", false, "AV19ComboPoConcLinCod", StringUtil.LTrimStr( (decimal)(AV19ComboPoConcLinCod), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A313PoConcCod = 0;
                  AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               }
               else
               {
                  A313PoConcCod = (int)(context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ","));
                  AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptosOrdenesProduccion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A313PoConcCod != Z313PoConcCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("produccion\\conceptosordenesproduccion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A313PoConcCod = (int)(NumberUtil.Val( GetPar( "PoConcCod"), "."));
                  AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
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
                     sMode141 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode141;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound141 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "POCONCCOD");
                        AnyError = 1;
                        GX_FocusControl = edtPoConcCod_Internalname;
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
                           E116J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126J2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E126J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6J141( ) ;
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
            DisableAttributes6J141( ) ;
         }
         AssignProp("", false, edtavCombopoconclincod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopoconclincod_Enabled), 5, 0), true);
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

      protected void CONFIRM_6J0( )
      {
         BeforeValidate6J141( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6J141( ) ;
            }
            else
            {
               CheckExtendedTable6J141( ) ;
               CloseExtendedTableCursors6J141( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode141 = Gx_mode;
            CONFIRM_6J182( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode141;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_6J182( )
      {
         nGXsfl_49_idx = 0;
         while ( nGXsfl_49_idx < nRC_GXsfl_49 )
         {
            ReadRow6J182( ) ;
            if ( ( nRcdExists_182 != 0 ) || ( nIsMod_182 != 0 ) )
            {
               GetKey6J182( ) ;
               if ( ( nRcdExists_182 == 0 ) && ( nRcdDeleted_182 == 0 ) )
               {
                  if ( RcdFound182 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate6J182( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable6J182( ) ;
                        CloseExtendedTableCursors6J182( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "POCONCDCUECOD_" + sGXsfl_49_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPoConcDCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound182 != 0 )
                  {
                     if ( nRcdDeleted_182 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey6J182( ) ;
                        Load6J182( ) ;
                        BeforeValidate6J182( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls6J182( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_182 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate6J182( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable6J182( ) ;
                              CloseExtendedTableCursors6J182( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_182 == 0 )
                     {
                        GXCCtl = "POCONCDCUECOD_" + sGXsfl_49_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPoConcDCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPoConcDCueCod_Internalname, StringUtil.RTrim( A315PoConcDCueCod)) ;
            ChangePostValue( edtPoConcDCueDsc_Internalname, StringUtil.RTrim( A1647PoConcDCueDsc)) ;
            ChangePostValue( edtPoConcCosCod_Internalname, StringUtil.RTrim( A316PoConcCosCod)) ;
            ChangePostValue( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_49_idx, StringUtil.RTrim( Z315PoConcDCueCod)) ;
            ChangePostValue( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_49_idx, StringUtil.RTrim( Z316PoConcCosCod)) ;
            ChangePostValue( "nRcdDeleted_182_"+sGXsfl_49_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_182_"+sGXsfl_49_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_182_"+sGXsfl_49_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_182), 4, 0, ".", ""))) ;
            if ( nIsMod_182 != 0 )
            {
               ChangePostValue( "POCONCDCUECOD_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCDCUEDSC_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCCOSCOD_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption6J0( )
      {
      }

      protected void E116J2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Combo_poconcdcuecod_Titlecontrolidtoreplace = edtPoConcDCueCod_Internalname;
         ucCombo_poconcdcuecod.SendProperty(context, "", false, Combo_poconcdcuecod_Internalname, "TitleControlIdToReplace", Combo_poconcdcuecod_Titlecontrolidtoreplace);
         edtPoConcLinCod_Visible = 0;
         AssignProp("", false, edtPoConcLinCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPoConcLinCod_Visible), 5, 0), true);
         AV19ComboPoConcLinCod = 0;
         AssignAttri("", false, "AV19ComboPoConcLinCod", StringUtil.LTrimStr( (decimal)(AV19ComboPoConcLinCod), 6, 0));
         edtavCombopoconclincod_Visible = 0;
         AssignProp("", false, edtavCombopoconclincod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopoconclincod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPOCONCLINCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPOCONCDCUECOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PoConcLinCod") == 0 )
               {
                  AV11Insert_PoConcLinCod = (int)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_PoConcLinCod", StringUtil.LTrimStr( (decimal)(AV11Insert_PoConcLinCod), 6, 0));
                  if ( ! (0==AV11Insert_PoConcLinCod) )
                  {
                     AV19ComboPoConcLinCod = AV11Insert_PoConcLinCod;
                     AssignAttri("", false, "AV19ComboPoConcLinCod", StringUtil.LTrimStr( (decimal)(AV19ComboPoConcLinCod), 6, 0));
                     Combo_poconclincod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboPoConcLinCod), 6, 0));
                     ucCombo_poconclincod.SendProperty(context, "", false, Combo_poconclincod_Internalname, "SelectedValue_set", Combo_poconclincod_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new GeneXus.Programs.produccion.conceptosordenesproduccionloaddvcombo(context ).execute(  "PoConcLinCod",  "GET",  false,  AV7PoConcCod,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_poconclincod_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_poconclincod.SendProperty(context, "", false, Combo_poconclincod_Internalname, "SelectedText_set", Combo_poconclincod_Selectedtext_set);
                     Combo_poconclincod_Enabled = false;
                     ucCombo_poconclincod.SendProperty(context, "", false, Combo_poconclincod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_poconclincod_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtPoConcCod_Visible = 0;
         AssignProp("", false, edtPoConcCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Visible), 5, 0), true);
      }

      protected void E126J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("produccion.conceptosordenesproduccionww.aspx") );
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
         /* 'LOADCOMBOPOCONCDCUECOD' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.produccion.conceptosordenesproduccionloaddvcombo(context ).execute(  "PoConcDCueCod",  Gx_mode,  false,  AV7PoConcCod,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         AV13PoConcDCueCod_Data.FromJSonString(AV17Combo_DataJson, null);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPOCONCLINCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.produccion.conceptosordenesproduccionloaddvcombo(context ).execute(  "PoConcLinCod",  Gx_mode,  false,  AV7PoConcCod,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_poconclincod_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_poconclincod.SendProperty(context, "", false, Combo_poconclincod_Internalname, "SelectedValue_set", Combo_poconclincod_Selectedvalue_set);
         Combo_poconclincod_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_poconclincod.SendProperty(context, "", false, Combo_poconclincod_Internalname, "SelectedText_set", Combo_poconclincod_Selectedtext_set);
         AV19ComboPoConcLinCod = (int)(NumberUtil.Val( AV15ComboSelectedValue, "."));
         AssignAttri("", false, "AV19ComboPoConcLinCod", StringUtil.LTrimStr( (decimal)(AV19ComboPoConcLinCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_poconclincod_Enabled = false;
            ucCombo_poconclincod.SendProperty(context, "", false, Combo_poconclincod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_poconclincod_Enabled));
         }
      }

      protected void ZM6J141( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1648PoConcDsc = T006J6_A1648PoConcDsc[0];
               Z1650PoConcTip = T006J6_A1650PoConcTip[0];
               Z1649PoConcSts = T006J6_A1649PoConcSts[0];
               Z314PoConcLinCod = T006J6_A314PoConcLinCod[0];
            }
            else
            {
               Z1648PoConcDsc = A1648PoConcDsc;
               Z1650PoConcTip = A1650PoConcTip;
               Z1649PoConcSts = A1649PoConcSts;
               Z314PoConcLinCod = A314PoConcLinCod;
            }
         }
         if ( GX_JID == -15 )
         {
            Z313PoConcCod = A313PoConcCod;
            Z1648PoConcDsc = A1648PoConcDsc;
            Z1650PoConcTip = A1650PoConcTip;
            Z1649PoConcSts = A1649PoConcSts;
            Z314PoConcLinCod = A314PoConcLinCod;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Produccion.ConceptosOrdenesProduccion";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PoConcCod) )
         {
            A313PoConcCod = AV7PoConcCod;
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         }
         if ( ! (0==AV7PoConcCod) )
         {
            edtPoConcCod_Enabled = 0;
            AssignProp("", false, edtPoConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPoConcCod_Enabled = 1;
            AssignProp("", false, edtPoConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7PoConcCod) )
         {
            edtPoConcCod_Enabled = 0;
            AssignProp("", false, edtPoConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PoConcLinCod) )
         {
            edtPoConcLinCod_Enabled = 0;
            AssignProp("", false, edtPoConcLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcLinCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPoConcLinCod_Enabled = 1;
            AssignProp("", false, edtPoConcLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcLinCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PoConcLinCod) )
         {
            A314PoConcLinCod = AV11Insert_PoConcLinCod;
            n314PoConcLinCod = false;
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
         }
         else
         {
            if ( (0==AV19ComboPoConcLinCod) )
            {
               A314PoConcLinCod = 0;
               n314PoConcLinCod = false;
               AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
               n314PoConcLinCod = true;
               AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV19ComboPoConcLinCod) )
               {
                  A314PoConcLinCod = AV19ComboPoConcLinCod;
                  n314PoConcLinCod = false;
                  AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
               }
            }
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
         if ( IsIns( )  && (0==A1649PoConcSts) && ( Gx_BScreen == 0 ) )
         {
            A1649PoConcSts = 1;
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         }
      }

      protected void Load6J141( )
      {
         /* Using cursor T006J8 */
         pr_default.execute(6, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound141 = 1;
            A1648PoConcDsc = T006J8_A1648PoConcDsc[0];
            AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
            A1650PoConcTip = T006J8_A1650PoConcTip[0];
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
            A1649PoConcSts = T006J8_A1649PoConcSts[0];
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            A314PoConcLinCod = T006J8_A314PoConcLinCod[0];
            n314PoConcLinCod = T006J8_n314PoConcLinCod[0];
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            ZM6J141( -15) ;
         }
         pr_default.close(6);
         OnLoadActions6J141( ) ;
      }

      protected void OnLoadActions6J141( )
      {
      }

      protected void CheckExtendedTable6J141( )
      {
         nIsDirty_141 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1648PoConcDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Concepto", "", "", "", "", "", "", "", ""), 1, "POCONCDSC");
            AnyError = 1;
            GX_FocusControl = edtPoConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006J7 */
         pr_default.execute(5, new Object[] {n314PoConcLinCod, A314PoConcLinCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A314PoConcLinCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Conceptos Produccion'.", "ForeignKeyNotFound", 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1650PoConcTip)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Distribución", "", "", "", "", "", "", "", ""), 1, "POCONCTIP");
            AnyError = 1;
            GX_FocusControl = cmbPoConcTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6J141( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( int A314PoConcLinCod )
      {
         /* Using cursor T006J9 */
         pr_default.execute(7, new Object[] {n314PoConcLinCod, A314PoConcLinCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A314PoConcLinCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Conceptos Produccion'.", "ForeignKeyNotFound", 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey6J141( )
      {
         /* Using cursor T006J10 */
         pr_default.execute(8, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound141 = 1;
         }
         else
         {
            RcdFound141 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006J6 */
         pr_default.execute(4, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM6J141( 15) ;
            RcdFound141 = 1;
            A313PoConcCod = T006J6_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            A1648PoConcDsc = T006J6_A1648PoConcDsc[0];
            AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
            A1650PoConcTip = T006J6_A1650PoConcTip[0];
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
            A1649PoConcSts = T006J6_A1649PoConcSts[0];
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            A314PoConcLinCod = T006J6_A314PoConcLinCod[0];
            n314PoConcLinCod = T006J6_n314PoConcLinCod[0];
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            Z313PoConcCod = A313PoConcCod;
            sMode141 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6J141( ) ;
            if ( AnyError == 1 )
            {
               RcdFound141 = 0;
               InitializeNonKey6J141( ) ;
            }
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound141 = 0;
            InitializeNonKey6J141( ) ;
            sMode141 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey6J141( ) ;
         if ( RcdFound141 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound141 = 0;
         /* Using cursor T006J11 */
         pr_default.execute(9, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T006J11_A313PoConcCod[0] < A313PoConcCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T006J11_A313PoConcCod[0] > A313PoConcCod ) ) )
            {
               A313PoConcCod = T006J11_A313PoConcCod[0];
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               RcdFound141 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound141 = 0;
         /* Using cursor T006J12 */
         pr_default.execute(10, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T006J12_A313PoConcCod[0] > A313PoConcCod ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T006J12_A313PoConcCod[0] < A313PoConcCod ) ) )
            {
               A313PoConcCod = T006J12_A313PoConcCod[0];
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               RcdFound141 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6J141( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPoConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6J141( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound141 == 1 )
            {
               if ( A313PoConcCod != Z313PoConcCod )
               {
                  A313PoConcCod = Z313PoConcCod;
                  AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "POCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPoConcDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6J141( ) ;
                  GX_FocusControl = edtPoConcDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A313PoConcCod != Z313PoConcCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtPoConcDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6J141( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "POCONCCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPoConcCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPoConcDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6J141( ) ;
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
         if ( A313PoConcCod != Z313PoConcCod )
         {
            A313PoConcCod = Z313PoConcCod;
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPoConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6J141( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006J5 */
            pr_default.execute(3, new Object[] {A313PoConcCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z1648PoConcDsc, T006J5_A1648PoConcDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1650PoConcTip, T006J5_A1650PoConcTip[0]) != 0 ) || ( Z1649PoConcSts != T006J5_A1649PoConcSts[0] ) || ( Z314PoConcLinCod != T006J5_A314PoConcLinCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z1648PoConcDsc, T006J5_A1648PoConcDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesproduccion:[seudo value changed for attri]"+"PoConcDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1648PoConcDsc);
                  GXUtil.WriteLogRaw("Current: ",T006J5_A1648PoConcDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1650PoConcTip, T006J5_A1650PoConcTip[0]) != 0 )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesproduccion:[seudo value changed for attri]"+"PoConcTip");
                  GXUtil.WriteLogRaw("Old: ",Z1650PoConcTip);
                  GXUtil.WriteLogRaw("Current: ",T006J5_A1650PoConcTip[0]);
               }
               if ( Z1649PoConcSts != T006J5_A1649PoConcSts[0] )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesproduccion:[seudo value changed for attri]"+"PoConcSts");
                  GXUtil.WriteLogRaw("Old: ",Z1649PoConcSts);
                  GXUtil.WriteLogRaw("Current: ",T006J5_A1649PoConcSts[0]);
               }
               if ( Z314PoConcLinCod != T006J5_A314PoConcLinCod[0] )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesproduccion:[seudo value changed for attri]"+"PoConcLinCod");
                  GXUtil.WriteLogRaw("Old: ",Z314PoConcLinCod);
                  GXUtil.WriteLogRaw("Current: ",T006J5_A314PoConcLinCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCONCEPTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6J141( )
      {
         BeforeValidate6J141( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6J141( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6J141( 0) ;
            CheckOptimisticConcurrency6J141( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6J141( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6J141( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006J13 */
                     pr_default.execute(11, new Object[] {A313PoConcCod, A1648PoConcDsc, A1650PoConcTip, A1649PoConcSts, n314PoConcLinCod, A314PoConcLinCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOS");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ProcessLevel6J141( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption6J0( ) ;
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
               Load6J141( ) ;
            }
            EndLevel6J141( ) ;
         }
         CloseExtendedTableCursors6J141( ) ;
      }

      protected void Update6J141( )
      {
         BeforeValidate6J141( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6J141( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6J141( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6J141( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6J141( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006J14 */
                     pr_default.execute(12, new Object[] {A1648PoConcDsc, A1650PoConcTip, A1649PoConcSts, n314PoConcLinCod, A314PoConcLinCod, A313PoConcCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOS");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6J141( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel6J141( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel6J141( ) ;
         }
         CloseExtendedTableCursors6J141( ) ;
      }

      protected void DeferredUpdate6J141( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6J141( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6J141( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6J141( ) ;
            AfterConfirm6J141( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6J141( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart6J182( ) ;
                  while ( RcdFound182 != 0 )
                  {
                     getByPrimaryKey6J182( ) ;
                     Delete6J182( ) ;
                     ScanNext6J182( ) ;
                  }
                  ScanEnd6J182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006J15 */
                     pr_default.execute(13, new Object[] {A313PoConcCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOS");
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
         }
         sMode141 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6J141( ) ;
         Gx_mode = sMode141;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6J141( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel6J182( )
      {
         nGXsfl_49_idx = 0;
         while ( nGXsfl_49_idx < nRC_GXsfl_49 )
         {
            ReadRow6J182( ) ;
            if ( ( nRcdExists_182 != 0 ) || ( nIsMod_182 != 0 ) )
            {
               standaloneNotModal6J182( ) ;
               GetKey6J182( ) ;
               if ( ( nRcdExists_182 == 0 ) && ( nRcdDeleted_182 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert6J182( ) ;
               }
               else
               {
                  if ( RcdFound182 != 0 )
                  {
                     if ( ( nRcdDeleted_182 != 0 ) && ( nRcdExists_182 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete6J182( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_182 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update6J182( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_182 == 0 )
                     {
                        GXCCtl = "POCONCDCUECOD_" + sGXsfl_49_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPoConcDCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPoConcDCueCod_Internalname, StringUtil.RTrim( A315PoConcDCueCod)) ;
            ChangePostValue( edtPoConcDCueDsc_Internalname, StringUtil.RTrim( A1647PoConcDCueDsc)) ;
            ChangePostValue( edtPoConcCosCod_Internalname, StringUtil.RTrim( A316PoConcCosCod)) ;
            ChangePostValue( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_49_idx, StringUtil.RTrim( Z315PoConcDCueCod)) ;
            ChangePostValue( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_49_idx, StringUtil.RTrim( Z316PoConcCosCod)) ;
            ChangePostValue( "nRcdDeleted_182_"+sGXsfl_49_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_182_"+sGXsfl_49_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_182_"+sGXsfl_49_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_182), 4, 0, ".", ""))) ;
            if ( nIsMod_182 != 0 )
            {
               ChangePostValue( "POCONCDCUECOD_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCDCUEDSC_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCCOSCOD_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll6J182( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_182 = 0;
         nIsMod_182 = 0;
         nRcdDeleted_182 = 0;
      }

      protected void ProcessLevel6J141( )
      {
         /* Save parent mode. */
         sMode141 = Gx_mode;
         ProcessNestedLevel6J182( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode141;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel6J141( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6J141( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("produccion.conceptosordenesproduccion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("produccion.conceptosordenesproduccion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6J141( )
      {
         /* Scan By routine */
         /* Using cursor T006J16 */
         pr_default.execute(14);
         RcdFound141 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound141 = 1;
            A313PoConcCod = T006J16_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6J141( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound141 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound141 = 1;
            A313PoConcCod = T006J16_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         }
      }

      protected void ScanEnd6J141( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm6J141( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int3 = AV21cPoConcCod;
            GXt_char2 = "POCONCEPTO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char2, out  GXt_int3) ;
            AV21cPoConcCod = (int)(GXt_int3);
            AssignAttri("", false, "AV21cPoConcCod", StringUtil.LTrimStr( (decimal)(AV21cPoConcCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A313PoConcCod = AV21cPoConcCod;
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         }
      }

      protected void BeforeInsert6J141( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6J141( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6J141( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6J141( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6J141( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6J141( )
      {
         edtPoConcDsc_Enabled = 0;
         AssignProp("", false, edtPoConcDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDsc_Enabled), 5, 0), true);
         cmbPoConcTip.Enabled = 0;
         AssignProp("", false, cmbPoConcTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPoConcTip.Enabled), 5, 0), true);
         edtPoConcLinCod_Enabled = 0;
         AssignProp("", false, edtPoConcLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcLinCod_Enabled), 5, 0), true);
         cmbPoConcSts.Enabled = 0;
         AssignProp("", false, cmbPoConcSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPoConcSts.Enabled), 5, 0), true);
         edtavCombopoconclincod_Enabled = 0;
         AssignProp("", false, edtavCombopoconclincod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopoconclincod_Enabled), 5, 0), true);
         edtPoConcCod_Enabled = 0;
         AssignProp("", false, edtPoConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Enabled), 5, 0), true);
      }

      protected void ZM6J182( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z316PoConcCosCod = T006J3_A316PoConcCosCod[0];
            }
            else
            {
               Z316PoConcCosCod = A316PoConcCosCod;
            }
         }
         if ( GX_JID == -17 )
         {
            Z313PoConcCod = A313PoConcCod;
            Z316PoConcCosCod = A316PoConcCosCod;
            Z315PoConcDCueCod = A315PoConcDCueCod;
            Z1647PoConcDCueDsc = A1647PoConcDCueDsc;
         }
      }

      protected void standaloneNotModal6J182( )
      {
         edtPoConcDCueDsc_Enabled = 0;
         AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), !bGXsfl_49_Refreshing);
      }

      protected void standaloneModal6J182( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPoConcDCueCod_Enabled = 0;
            AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         }
         else
         {
            edtPoConcDCueCod_Enabled = 1;
            AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         }
      }

      protected void Load6J182( )
      {
         /* Using cursor T006J17 */
         pr_default.execute(15, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound182 = 1;
            A1647PoConcDCueDsc = T006J17_A1647PoConcDCueDsc[0];
            A316PoConcCosCod = T006J17_A316PoConcCosCod[0];
            ZM6J182( -17) ;
         }
         pr_default.close(15);
         OnLoadActions6J182( ) ;
      }

      protected void OnLoadActions6J182( )
      {
      }

      protected void CheckExtendedTable6J182( )
      {
         nIsDirty_182 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal6J182( ) ;
         /* Using cursor T006J4 */
         pr_default.execute(2, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "POCONCDCUECOD_" + sGXsfl_49_idx;
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T006J4_A1647PoConcDCueDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors6J182( )
      {
         pr_default.close(2);
      }

      protected void enableDisable6J182( )
      {
      }

      protected void gxLoad_18( string A315PoConcDCueCod )
      {
         /* Using cursor T006J18 */
         pr_default.execute(16, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "POCONCDCUECOD_" + sGXsfl_49_idx;
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T006J18_A1647PoConcDCueDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1647PoConcDCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey6J182( )
      {
         /* Using cursor T006J19 */
         pr_default.execute(17, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound182 = 1;
         }
         else
         {
            RcdFound182 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey6J182( )
      {
         /* Using cursor T006J3 */
         pr_default.execute(1, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6J182( 17) ;
            RcdFound182 = 1;
            InitializeNonKey6J182( ) ;
            A316PoConcCosCod = T006J3_A316PoConcCosCod[0];
            A315PoConcDCueCod = T006J3_A315PoConcDCueCod[0];
            Z313PoConcCod = A313PoConcCod;
            Z315PoConcDCueCod = A315PoConcDCueCod;
            sMode182 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6J182( ) ;
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound182 = 0;
            InitializeNonKey6J182( ) ;
            sMode182 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal6J182( ) ;
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes6J182( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency6J182( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006J2 */
            pr_default.execute(0, new Object[] {A313PoConcCod, A315PoConcDCueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z316PoConcCosCod, T006J2_A316PoConcCosCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z316PoConcCosCod, T006J2_A316PoConcCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesproduccion:[seudo value changed for attri]"+"PoConcCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z316PoConcCosCod);
                  GXUtil.WriteLogRaw("Current: ",T006J2_A316PoConcCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCONCEPTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6J182( )
      {
         BeforeValidate6J182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6J182( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6J182( 0) ;
            CheckOptimisticConcurrency6J182( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6J182( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6J182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006J20 */
                     pr_default.execute(18, new Object[] {A313PoConcCod, A316PoConcCosCod, A315PoConcDCueCod});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load6J182( ) ;
            }
            EndLevel6J182( ) ;
         }
         CloseExtendedTableCursors6J182( ) ;
      }

      protected void Update6J182( )
      {
         BeforeValidate6J182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6J182( ) ;
         }
         if ( ( nIsMod_182 != 0 ) || ( nIsDirty_182 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency6J182( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm6J182( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate6J182( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T006J21 */
                        pr_default.execute(19, new Object[] {A316PoConcCosCod, A313PoConcCod, A315PoConcDCueCod});
                        pr_default.close(19);
                        dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOSDET"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate6J182( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey6J182( ) ;
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
               EndLevel6J182( ) ;
            }
         }
         CloseExtendedTableCursors6J182( ) ;
      }

      protected void DeferredUpdate6J182( )
      {
      }

      protected void Delete6J182( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6J182( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6J182( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6J182( ) ;
            AfterConfirm6J182( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6J182( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006J22 */
                  pr_default.execute(20, new Object[] {A313PoConcCod, A315PoConcDCueCod});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode182 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6J182( ) ;
         Gx_mode = sMode182;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6J182( )
      {
         standaloneModal6J182( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006J23 */
            pr_default.execute(21, new Object[] {A315PoConcDCueCod});
            A1647PoConcDCueDsc = T006J23_A1647PoConcDCueDsc[0];
            pr_default.close(21);
         }
      }

      protected void EndLevel6J182( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6J182( )
      {
         /* Scan By routine */
         /* Using cursor T006J24 */
         pr_default.execute(22, new Object[] {A313PoConcCod});
         RcdFound182 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound182 = 1;
            A315PoConcDCueCod = T006J24_A315PoConcDCueCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6J182( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound182 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound182 = 1;
            A315PoConcDCueCod = T006J24_A315PoConcDCueCod[0];
         }
      }

      protected void ScanEnd6J182( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm6J182( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6J182( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6J182( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6J182( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6J182( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6J182( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6J182( )
      {
         edtPoConcDCueCod_Enabled = 0;
         AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtPoConcDCueDsc_Enabled = 0;
         AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtPoConcCosCod_Enabled = 0;
         AssignProp("", false, edtPoConcCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCosCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
      }

      protected void send_integrity_lvl_hashes6J182( )
      {
      }

      protected void send_integrity_lvl_hashes6J141( )
      {
      }

      protected void SubsflControlProps_49182( )
      {
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD_"+sGXsfl_49_idx;
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC_"+sGXsfl_49_idx;
         edtPoConcCosCod_Internalname = "POCONCCOSCOD_"+sGXsfl_49_idx;
      }

      protected void SubsflControlProps_fel_49182( )
      {
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD_"+sGXsfl_49_fel_idx;
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC_"+sGXsfl_49_fel_idx;
         edtPoConcCosCod_Internalname = "POCONCCOSCOD_"+sGXsfl_49_fel_idx;
      }

      protected void AddRow6J182( )
      {
         nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_49182( ) ;
         SendRow6J182( ) ;
      }

      protected void SendRow6J182( )
      {
         Gridlevel_level1Row = GXWebRow.GetNew(context);
         if ( subGridlevel_level1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_level1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
            {
               subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Odd";
            }
         }
         else if ( subGridlevel_level1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_level1_Backstyle = 0;
            subGridlevel_level1_Backcolor = subGridlevel_level1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
            {
               subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Uniform";
            }
         }
         else if ( subGridlevel_level1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_level1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
            {
               subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Odd";
            }
            subGridlevel_level1_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_level1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_level1_Backstyle = 1;
            if ( ((int)((nGXsfl_49_idx) % (2))) == 0 )
            {
               subGridlevel_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
               {
                  subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Even";
               }
            }
            else
            {
               subGridlevel_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
               {
                  subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_182_" + sGXsfl_49_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_49_idx + "',49)\"";
         ROClassString = "AttributeRealWidth100With";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcDCueCod_Internalname,StringUtil.RTrim( A315PoConcDCueCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcDCueCod_Jsonclick,(short)0,(string)"AttributeRealWidth100With",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPoConcDCueCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)49,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcDCueDsc_Internalname,StringUtil.RTrim( A1647PoConcDCueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcDCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtPoConcDCueDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)49,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_182_" + sGXsfl_49_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_49_idx + "',49)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcCosCod_Internalname,StringUtil.RTrim( A316PoConcCosCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcCosCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPoConcCosCod_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)49,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_level1Row);
         send_integrity_lvl_hashes6J182( ) ;
         GXCCtl = "Z315PoConcDCueCod_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z315PoConcDCueCod));
         GXCCtl = "Z316PoConcCosCod_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z316PoConcCosCod));
         GXCCtl = "nRcdDeleted_182_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_182), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_182_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_182), 4, 0, ".", "")));
         GXCCtl = "nIsMod_182_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_182), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_49_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPOCONCCOD_" + sGXsfl_49_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POCONCDCUECOD_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POCONCDCUEDSC_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POCONCCOSCOD_"+sGXsfl_49_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_level1Container.AddRow(Gridlevel_level1Row);
      }

      protected void ReadRow6J182( )
      {
         nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_49182( ) ;
         edtPoConcDCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUECOD_"+sGXsfl_49_idx+"Enabled"), ".", ","));
         edtPoConcDCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUEDSC_"+sGXsfl_49_idx+"Enabled"), ".", ","));
         edtPoConcCosCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCCOSCOD_"+sGXsfl_49_idx+"Enabled"), ".", ","));
         A315PoConcDCueCod = cgiGet( edtPoConcDCueCod_Internalname);
         A1647PoConcDCueDsc = cgiGet( edtPoConcDCueDsc_Internalname);
         A316PoConcCosCod = cgiGet( edtPoConcCosCod_Internalname);
         GXCCtl = "Z315PoConcDCueCod_" + sGXsfl_49_idx;
         Z315PoConcDCueCod = cgiGet( GXCCtl);
         GXCCtl = "Z316PoConcCosCod_" + sGXsfl_49_idx;
         Z316PoConcCosCod = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_182_" + sGXsfl_49_idx;
         nRcdDeleted_182 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_182_" + sGXsfl_49_idx;
         nRcdExists_182 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_182_" + sGXsfl_49_idx;
         nIsMod_182 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtPoConcDCueDsc_Enabled = edtPoConcDCueDsc_Enabled;
         defedtPoConcDCueCod_Enabled = edtPoConcDCueCod_Enabled;
      }

      protected void ConfirmValues6J0( )
      {
         nGXsfl_49_idx = 0;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_49182( ) ;
         while ( nGXsfl_49_idx < nRC_GXsfl_49 )
         {
            nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_49182( ) ;
            ChangePostValue( "Z315PoConcDCueCod_"+sGXsfl_49_idx, cgiGet( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_49_idx)) ;
            DeletePostValue( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_49_idx) ;
            ChangePostValue( "Z316PoConcCosCod_"+sGXsfl_49_idx, cgiGet( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_49_idx)) ;
            DeletePostValue( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_49_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264399", false, true);
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
         GXEncryptionTmp = "produccion.conceptosordenesproduccion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PoConcCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("produccion.conceptosordenesproduccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptosOrdenesProduccion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("produccion\\conceptosordenesproduccion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z313PoConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z313PoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1648PoConcDsc", StringUtil.RTrim( Z1648PoConcDsc));
         GxWebStd.gx_hidden_field( context, "Z1650PoConcTip", StringUtil.RTrim( Z1650PoConcTip));
         GxWebStd.gx_hidden_field( context, "Z1649PoConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1649PoConcSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z314PoConcLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z314PoConcLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_49", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_49_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N314PoConcLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A314PoConcLinCod), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPOCONCLINCOD_DATA", AV18PoConcLinCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPOCONCLINCOD_DATA", AV18PoConcLinCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPOCONCDCUECOD_DATA", AV13PoConcDCueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPOCONCDCUECOD_DATA", AV13PoConcDCueCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vPOCONCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPOCONCCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PoConcCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCPOCONCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21cPoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_POCONCLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PoConcLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Objectcall", StringUtil.RTrim( Combo_poconclincod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Cls", StringUtil.RTrim( Combo_poconclincod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Selectedvalue_set", StringUtil.RTrim( Combo_poconclincod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Selectedtext_set", StringUtil.RTrim( Combo_poconclincod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Enabled", StringUtil.BoolToStr( Combo_poconclincod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Datalistproc", StringUtil.RTrim( Combo_poconclincod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCLINCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_poconclincod_Datalistprocparametersprefix));
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
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCDCUECOD_Objectcall", StringUtil.RTrim( Combo_poconcdcuecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCDCUECOD_Cls", StringUtil.RTrim( Combo_poconcdcuecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCDCUECOD_Enabled", StringUtil.BoolToStr( Combo_poconcdcuecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCDCUECOD_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_poconcdcuecod_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_POCONCDCUECOD_Isgriditem", StringUtil.BoolToStr( Combo_poconcdcuecod_Isgriditem));
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
         GXEncryptionTmp = "produccion.conceptosordenesproduccion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PoConcCod,6,0));
         return formatLink("produccion.conceptosordenesproduccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Produccion.ConceptosOrdenesProduccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Ordenes de Produccion" ;
      }

      protected void InitializeNonKey6J141( )
      {
         A314PoConcLinCod = 0;
         n314PoConcLinCod = false;
         AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
         n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
         AV21cPoConcCod = 0;
         AssignAttri("", false, "AV21cPoConcCod", StringUtil.LTrimStr( (decimal)(AV21cPoConcCod), 6, 0));
         A1648PoConcDsc = "";
         AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
         A1650PoConcTip = "";
         AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
         A1649PoConcSts = 1;
         AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         Z1648PoConcDsc = "";
         Z1650PoConcTip = "";
         Z1649PoConcSts = 0;
         Z314PoConcLinCod = 0;
      }

      protected void InitAll6J141( )
      {
         A313PoConcCod = 0;
         AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         InitializeNonKey6J141( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1649PoConcSts = i1649PoConcSts;
         AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
      }

      protected void InitializeNonKey6J182( )
      {
         A1647PoConcDCueDsc = "";
         A316PoConcCosCod = "";
         Z316PoConcCosCod = "";
      }

      protected void InitAll6J182( )
      {
         A315PoConcDCueCod = "";
         InitializeNonKey6J182( ) ;
      }

      protected void StandaloneModalInsert6J182( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264437", true, true);
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
         context.AddJavascriptSource("produccion/conceptosordenesproduccion.js", "?202281810264438", false, true);
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

      protected void init_level_properties182( )
      {
         edtPoConcDCueDsc_Enabled = defedtPoConcDCueDsc_Enabled;
         AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtPoConcDCueCod_Enabled = defedtPoConcDCueCod_Enabled;
         AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_49_Refreshing);
      }

      protected void init_default_properties( )
      {
         edtPoConcDsc_Internalname = "POCONCDSC";
         cmbPoConcTip_Internalname = "POCONCTIP";
         lblTextblockpoconclincod_Internalname = "TEXTBLOCKPOCONCLINCOD";
         Combo_poconclincod_Internalname = "COMBO_POCONCLINCOD";
         edtPoConcLinCod_Internalname = "POCONCLINCOD";
         divTablesplittedpoconclincod_Internalname = "TABLESPLITTEDPOCONCLINCOD";
         cmbPoConcSts_Internalname = "POCONCSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD";
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC";
         edtPoConcCosCod_Internalname = "POCONCCOSCOD";
         divTableleaflevel_level1_Internalname = "TABLELEAFLEVEL_LEVEL1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopoconclincod_Internalname = "vCOMBOPOCONCLINCOD";
         divSectionattribute_poconclincod_Internalname = "SECTIONATTRIBUTE_POCONCLINCOD";
         Combo_poconcdcuecod_Internalname = "COMBO_POCONCDCUECOD";
         edtPoConcCod_Internalname = "POCONCCOD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_level1_Internalname = "GRIDLEVEL_LEVEL1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Combo_poconcdcuecod_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Conceptos de Ordenes de Produccion";
         edtPoConcCosCod_Jsonclick = "";
         edtPoConcDCueDsc_Jsonclick = "";
         edtPoConcDCueCod_Jsonclick = "";
         subGridlevel_level1_Class = "WorkWith";
         subGridlevel_level1_Backcolorstyle = 0;
         Combo_poconcdcuecod_Titlecontrolidtoreplace = "";
         subGridlevel_level1_Allowcollapsing = 0;
         subGridlevel_level1_Allowselection = 0;
         edtPoConcCosCod_Enabled = 1;
         edtPoConcDCueDsc_Enabled = 0;
         edtPoConcDCueCod_Enabled = 1;
         subGridlevel_level1_Header = "";
         edtPoConcCod_Jsonclick = "";
         edtPoConcCod_Enabled = 1;
         edtPoConcCod_Visible = 1;
         Combo_poconcdcuecod_Isgriditem = Convert.ToBoolean( -1);
         Combo_poconcdcuecod_Cls = "ExtendedCombo";
         Combo_poconcdcuecod_Caption = "";
         edtavCombopoconclincod_Jsonclick = "";
         edtavCombopoconclincod_Enabled = 0;
         edtavCombopoconclincod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbPoConcSts_Jsonclick = "";
         cmbPoConcSts.Enabled = 1;
         edtPoConcLinCod_Jsonclick = "";
         edtPoConcLinCod_Enabled = 1;
         edtPoConcLinCod_Visible = 1;
         Combo_poconclincod_Datalistprocparametersprefix = " \"ComboName\": \"PoConcLinCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PoConcCod\": 0";
         Combo_poconclincod_Datalistproc = "Produccion.ConceptosOrdenesProduccionLoadDVCombo";
         Combo_poconclincod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_poconclincod_Caption = "";
         Combo_poconclincod_Enabled = Convert.ToBoolean( -1);
         cmbPoConcTip_Jsonclick = "";
         cmbPoConcTip.Enabled = 1;
         edtPoConcDsc_Jsonclick = "";
         edtPoConcDsc_Enabled = 1;
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

      protected void GX8ASACPOCONCCOD6J141( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int3 = AV21cPoConcCod;
            GXt_char2 = "POCONCEPTO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char2, out  GXt_int3) ;
            AV21cPoConcCod = (int)(GXt_int3);
            AssignAttri("", false, "AV21cPoConcCod", StringUtil.LTrimStr( (decimal)(AV21cPoConcCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21cPoConcCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_49182( ) ;
         while ( nGXsfl_49_idx <= nRC_GXsfl_49 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal6J182( ) ;
            standaloneModal6J182( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow6J182( ) ;
            nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_49182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_level1Container)) ;
         /* End function gxnrGridlevel_level1_newrow */
      }

      protected void init_web_controls( )
      {
         cmbPoConcTip.Name = "POCONCTIP";
         cmbPoConcTip.WebTags = "";
         cmbPoConcTip.addItem("C", "Cantidad", 0);
         cmbPoConcTip.addItem("T", "Costo", 0);
         cmbPoConcTip.addItem("H", "Horas", 0);
         cmbPoConcTip.addItem("P", "Peso", 0);
         cmbPoConcTip.addItem("V", "Volumen", 0);
         if ( cmbPoConcTip.ItemCount > 0 )
         {
            A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
         }
         cmbPoConcSts.Name = "POCONCSTS";
         cmbPoConcSts.WebTags = "";
         cmbPoConcSts.addItem("1", "ACTIVO", 0);
         cmbPoConcSts.addItem("0", "INACTIVO", 0);
         if ( cmbPoConcSts.ItemCount > 0 )
         {
            if ( (0==A1649PoConcSts) )
            {
               A1649PoConcSts = 1;
               AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
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

      public void Valid_Poconclincod( )
      {
         n314PoConcLinCod = false;
         /* Using cursor T006J25 */
         pr_default.execute(23, new Object[] {n314PoConcLinCod, A314PoConcLinCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A314PoConcLinCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Conceptos Produccion'.", "ForeignKeyNotFound", 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
            }
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Poconcdcuecod( )
      {
         /* Using cursor T006J23 */
         pr_default.execute(21, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, "POCONCDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
         }
         A1647PoConcDCueDsc = T006J23_A1647PoConcDCueDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1647PoConcDCueDsc", StringUtil.RTrim( A1647PoConcDCueDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PoConcCod',fld:'vPOCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PoConcCod',fld:'vPOCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_POCONCDSC","{handler:'Valid_Poconcdsc',iparms:[]");
         setEventMetadata("VALID_POCONCDSC",",oparms:[]}");
         setEventMetadata("VALID_POCONCTIP","{handler:'Valid_Poconctip',iparms:[]");
         setEventMetadata("VALID_POCONCTIP",",oparms:[]}");
         setEventMetadata("VALID_POCONCLINCOD","{handler:'Valid_Poconclincod',iparms:[{av:'A314PoConcLinCod',fld:'POCONCLINCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_POCONCLINCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPOCONCLINCOD","{handler:'Validv_Combopoconclincod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPOCONCLINCOD",",oparms:[]}");
         setEventMetadata("VALID_POCONCCOD","{handler:'Valid_Poconccod',iparms:[]");
         setEventMetadata("VALID_POCONCCOD",",oparms:[]}");
         setEventMetadata("VALID_POCONCDCUECOD","{handler:'Valid_Poconcdcuecod',iparms:[{av:'A315PoConcDCueCod',fld:'POCONCDCUECOD',pic:''},{av:'A1647PoConcDCueDsc',fld:'POCONCDCUEDSC',pic:''}]");
         setEventMetadata("VALID_POCONCDCUECOD",",oparms:[{av:'A1647PoConcDCueDsc',fld:'POCONCDCUEDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Poconccoscod',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(4);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1648PoConcDsc = "";
         Z1650PoConcTip = "";
         Combo_poconclincod_Selectedvalue_get = "";
         Z315PoConcDCueCod = "";
         Z316PoConcCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A315PoConcDCueCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1650PoConcTip = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A1648PoConcDsc = "";
         lblTextblockpoconclincod_Jsonclick = "";
         ucCombo_poconclincod = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18PoConcLinCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_poconcdcuecod = new GXUserControl();
         AV13PoConcDCueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Gridlevel_level1Container = new GXWebGrid( context);
         Gridlevel_level1Column = new GXWebColumn();
         A1647PoConcDCueDsc = "";
         A316PoConcCosCod = "";
         sMode182 = "";
         sStyleString = "";
         AV23Pgmname = "";
         Combo_poconclincod_Objectcall = "";
         Combo_poconclincod_Class = "";
         Combo_poconclincod_Icontype = "";
         Combo_poconclincod_Icon = "";
         Combo_poconclincod_Tooltip = "";
         Combo_poconclincod_Selectedvalue_set = "";
         Combo_poconclincod_Selectedtext_set = "";
         Combo_poconclincod_Selectedtext_get = "";
         Combo_poconclincod_Gamoauthtoken = "";
         Combo_poconclincod_Ddointernalname = "";
         Combo_poconclincod_Titlecontrolalign = "";
         Combo_poconclincod_Dropdownoptionstype = "";
         Combo_poconclincod_Titlecontrolidtoreplace = "";
         Combo_poconclincod_Datalisttype = "";
         Combo_poconclincod_Datalistfixedvalues = "";
         Combo_poconclincod_Htmltemplate = "";
         Combo_poconclincod_Multiplevaluestype = "";
         Combo_poconclincod_Loadingdata = "";
         Combo_poconclincod_Noresultsfound = "";
         Combo_poconclincod_Emptyitemtext = "";
         Combo_poconclincod_Onlyselectedvalues = "";
         Combo_poconclincod_Selectalltext = "";
         Combo_poconclincod_Multiplevaluesseparator = "";
         Combo_poconclincod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_poconcdcuecod_Objectcall = "";
         Combo_poconcdcuecod_Class = "";
         Combo_poconcdcuecod_Icontype = "";
         Combo_poconcdcuecod_Icon = "";
         Combo_poconcdcuecod_Tooltip = "";
         Combo_poconcdcuecod_Selectedvalue_set = "";
         Combo_poconcdcuecod_Selectedvalue_get = "";
         Combo_poconcdcuecod_Selectedtext_set = "";
         Combo_poconcdcuecod_Selectedtext_get = "";
         Combo_poconcdcuecod_Gamoauthtoken = "";
         Combo_poconcdcuecod_Ddointernalname = "";
         Combo_poconcdcuecod_Titlecontrolalign = "";
         Combo_poconcdcuecod_Dropdownoptionstype = "";
         Combo_poconcdcuecod_Datalisttype = "";
         Combo_poconcdcuecod_Datalistfixedvalues = "";
         Combo_poconcdcuecod_Datalistproc = "";
         Combo_poconcdcuecod_Datalistprocparametersprefix = "";
         Combo_poconcdcuecod_Htmltemplate = "";
         Combo_poconcdcuecod_Multiplevaluestype = "";
         Combo_poconcdcuecod_Loadingdata = "";
         Combo_poconcdcuecod_Noresultsfound = "";
         Combo_poconcdcuecod_Emptyitemtext = "";
         Combo_poconcdcuecod_Onlyselectedvalues = "";
         Combo_poconcdcuecod_Selectalltext = "";
         Combo_poconcdcuecod_Multiplevaluesseparator = "";
         Combo_poconcdcuecod_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode141 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         T006J8_A313PoConcCod = new int[1] ;
         T006J8_A1648PoConcDsc = new string[] {""} ;
         T006J8_A1650PoConcTip = new string[] {""} ;
         T006J8_A1649PoConcSts = new short[1] ;
         T006J8_A314PoConcLinCod = new int[1] ;
         T006J8_n314PoConcLinCod = new bool[] {false} ;
         T006J7_A314PoConcLinCod = new int[1] ;
         T006J7_n314PoConcLinCod = new bool[] {false} ;
         T006J9_A314PoConcLinCod = new int[1] ;
         T006J9_n314PoConcLinCod = new bool[] {false} ;
         T006J10_A313PoConcCod = new int[1] ;
         T006J6_A313PoConcCod = new int[1] ;
         T006J6_A1648PoConcDsc = new string[] {""} ;
         T006J6_A1650PoConcTip = new string[] {""} ;
         T006J6_A1649PoConcSts = new short[1] ;
         T006J6_A314PoConcLinCod = new int[1] ;
         T006J6_n314PoConcLinCod = new bool[] {false} ;
         T006J11_A313PoConcCod = new int[1] ;
         T006J12_A313PoConcCod = new int[1] ;
         T006J5_A313PoConcCod = new int[1] ;
         T006J5_A1648PoConcDsc = new string[] {""} ;
         T006J5_A1650PoConcTip = new string[] {""} ;
         T006J5_A1649PoConcSts = new short[1] ;
         T006J5_A314PoConcLinCod = new int[1] ;
         T006J5_n314PoConcLinCod = new bool[] {false} ;
         T006J16_A313PoConcCod = new int[1] ;
         Z1647PoConcDCueDsc = "";
         T006J17_A313PoConcCod = new int[1] ;
         T006J17_A1647PoConcDCueDsc = new string[] {""} ;
         T006J17_A316PoConcCosCod = new string[] {""} ;
         T006J17_A315PoConcDCueCod = new string[] {""} ;
         T006J4_A1647PoConcDCueDsc = new string[] {""} ;
         T006J18_A1647PoConcDCueDsc = new string[] {""} ;
         T006J19_A313PoConcCod = new int[1] ;
         T006J19_A315PoConcDCueCod = new string[] {""} ;
         T006J3_A313PoConcCod = new int[1] ;
         T006J3_A316PoConcCosCod = new string[] {""} ;
         T006J3_A315PoConcDCueCod = new string[] {""} ;
         T006J2_A313PoConcCod = new int[1] ;
         T006J2_A316PoConcCosCod = new string[] {""} ;
         T006J2_A315PoConcDCueCod = new string[] {""} ;
         T006J23_A1647PoConcDCueDsc = new string[] {""} ;
         T006J24_A313PoConcCod = new int[1] ;
         T006J24_A315PoConcDCueCod = new string[] {""} ;
         Gridlevel_level1Row = new GXWebRow();
         subGridlevel_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char2 = "";
         T006J25_A314PoConcLinCod = new int[1] ;
         T006J25_n314PoConcLinCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccion__default(),
            new Object[][] {
                new Object[] {
               T006J2_A313PoConcCod, T006J2_A316PoConcCosCod, T006J2_A315PoConcDCueCod
               }
               , new Object[] {
               T006J3_A313PoConcCod, T006J3_A316PoConcCosCod, T006J3_A315PoConcDCueCod
               }
               , new Object[] {
               T006J4_A1647PoConcDCueDsc
               }
               , new Object[] {
               T006J5_A313PoConcCod, T006J5_A1648PoConcDsc, T006J5_A1650PoConcTip, T006J5_A1649PoConcSts, T006J5_A314PoConcLinCod, T006J5_n314PoConcLinCod
               }
               , new Object[] {
               T006J6_A313PoConcCod, T006J6_A1648PoConcDsc, T006J6_A1650PoConcTip, T006J6_A1649PoConcSts, T006J6_A314PoConcLinCod, T006J6_n314PoConcLinCod
               }
               , new Object[] {
               T006J7_A314PoConcLinCod
               }
               , new Object[] {
               T006J8_A313PoConcCod, T006J8_A1648PoConcDsc, T006J8_A1650PoConcTip, T006J8_A1649PoConcSts, T006J8_A314PoConcLinCod, T006J8_n314PoConcLinCod
               }
               , new Object[] {
               T006J9_A314PoConcLinCod
               }
               , new Object[] {
               T006J10_A313PoConcCod
               }
               , new Object[] {
               T006J11_A313PoConcCod
               }
               , new Object[] {
               T006J12_A313PoConcCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006J16_A313PoConcCod
               }
               , new Object[] {
               T006J17_A313PoConcCod, T006J17_A1647PoConcDCueDsc, T006J17_A316PoConcCosCod, T006J17_A315PoConcDCueCod
               }
               , new Object[] {
               T006J18_A1647PoConcDCueDsc
               }
               , new Object[] {
               T006J19_A313PoConcCod, T006J19_A315PoConcDCueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006J23_A1647PoConcDCueDsc
               }
               , new Object[] {
               T006J24_A313PoConcCod, T006J24_A315PoConcDCueCod
               }
               , new Object[] {
               T006J25_A314PoConcLinCod
               }
            }
         );
         AV23Pgmname = "Produccion.ConceptosOrdenesProduccion";
         Z1649PoConcSts = 1;
         A1649PoConcSts = 1;
         i1649PoConcSts = 1;
      }

      private short Z1649PoConcSts ;
      private short nRcdDeleted_182 ;
      private short nRcdExists_182 ;
      private short nIsMod_182 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1649PoConcSts ;
      private short subGridlevel_level1_Backcolorstyle ;
      private short subGridlevel_level1_Allowselection ;
      private short subGridlevel_level1_Allowhovering ;
      private short subGridlevel_level1_Allowcollapsing ;
      private short subGridlevel_level1_Collapsed ;
      private short nBlankRcdCount182 ;
      private short RcdFound182 ;
      private short nBlankRcdUsr182 ;
      private short Gx_BScreen ;
      private short RcdFound141 ;
      private short GX_JID ;
      private short nIsDirty_141 ;
      private short nIsDirty_182 ;
      private short subGridlevel_level1_Backstyle ;
      private short gxajaxcallmode ;
      private short i1649PoConcSts ;
      private int wcpOAV7PoConcCod ;
      private int Z313PoConcCod ;
      private int Z314PoConcLinCod ;
      private int nRC_GXsfl_49 ;
      private int nGXsfl_49_idx=1 ;
      private int N314PoConcLinCod ;
      private int A314PoConcLinCod ;
      private int AV7PoConcCod ;
      private int trnEnded ;
      private int edtPoConcDsc_Enabled ;
      private int edtPoConcLinCod_Visible ;
      private int edtPoConcLinCod_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboPoConcLinCod ;
      private int edtavCombopoconclincod_Enabled ;
      private int edtavCombopoconclincod_Visible ;
      private int A313PoConcCod ;
      private int edtPoConcCod_Visible ;
      private int edtPoConcCod_Enabled ;
      private int edtPoConcDCueCod_Enabled ;
      private int edtPoConcDCueDsc_Enabled ;
      private int edtPoConcCosCod_Enabled ;
      private int subGridlevel_level1_Selectedindex ;
      private int subGridlevel_level1_Selectioncolor ;
      private int subGridlevel_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int AV21cPoConcCod ;
      private int AV11Insert_PoConcLinCod ;
      private int Combo_poconclincod_Datalistupdateminimumcharacters ;
      private int Combo_poconclincod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_poconcdcuecod_Datalistupdateminimumcharacters ;
      private int Combo_poconcdcuecod_Gxcontroltype ;
      private int AV24GXV1 ;
      private int subGridlevel_level1_Backcolor ;
      private int subGridlevel_level1_Allbackcolor ;
      private int defedtPoConcDCueDsc_Enabled ;
      private int defedtPoConcDCueCod_Enabled ;
      private int idxLst ;
      private long GRIDLEVEL_LEVEL1_nFirstRecordOnPage ;
      private long GXt_int3 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1648PoConcDsc ;
      private string Z1650PoConcTip ;
      private string Combo_poconclincod_Selectedvalue_get ;
      private string Z315PoConcDCueCod ;
      private string Z316PoConcCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A315PoConcDCueCod ;
      private string sGXsfl_49_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPoConcDsc_Internalname ;
      private string A1650PoConcTip ;
      private string cmbPoConcTip_Internalname ;
      private string cmbPoConcSts_Internalname ;
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
      private string A1648PoConcDsc ;
      private string edtPoConcDsc_Jsonclick ;
      private string cmbPoConcTip_Jsonclick ;
      private string divTablesplittedpoconclincod_Internalname ;
      private string lblTextblockpoconclincod_Internalname ;
      private string lblTextblockpoconclincod_Jsonclick ;
      private string Combo_poconclincod_Caption ;
      private string Combo_poconclincod_Cls ;
      private string Combo_poconclincod_Datalistproc ;
      private string Combo_poconclincod_Datalistprocparametersprefix ;
      private string Combo_poconclincod_Internalname ;
      private string edtPoConcLinCod_Internalname ;
      private string edtPoConcLinCod_Jsonclick ;
      private string cmbPoConcSts_Jsonclick ;
      private string divTableleaflevel_level1_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_poconclincod_Internalname ;
      private string edtavCombopoconclincod_Internalname ;
      private string edtavCombopoconclincod_Jsonclick ;
      private string Combo_poconcdcuecod_Caption ;
      private string Combo_poconcdcuecod_Cls ;
      private string Combo_poconcdcuecod_Internalname ;
      private string edtPoConcCod_Internalname ;
      private string edtPoConcCod_Jsonclick ;
      private string subGridlevel_level1_Header ;
      private string A1647PoConcDCueDsc ;
      private string A316PoConcCosCod ;
      private string sMode182 ;
      private string edtPoConcDCueCod_Internalname ;
      private string edtPoConcDCueDsc_Internalname ;
      private string edtPoConcCosCod_Internalname ;
      private string sStyleString ;
      private string AV23Pgmname ;
      private string Combo_poconclincod_Objectcall ;
      private string Combo_poconclincod_Class ;
      private string Combo_poconclincod_Icontype ;
      private string Combo_poconclincod_Icon ;
      private string Combo_poconclincod_Tooltip ;
      private string Combo_poconclincod_Selectedvalue_set ;
      private string Combo_poconclincod_Selectedtext_set ;
      private string Combo_poconclincod_Selectedtext_get ;
      private string Combo_poconclincod_Gamoauthtoken ;
      private string Combo_poconclincod_Ddointernalname ;
      private string Combo_poconclincod_Titlecontrolalign ;
      private string Combo_poconclincod_Dropdownoptionstype ;
      private string Combo_poconclincod_Titlecontrolidtoreplace ;
      private string Combo_poconclincod_Datalisttype ;
      private string Combo_poconclincod_Datalistfixedvalues ;
      private string Combo_poconclincod_Htmltemplate ;
      private string Combo_poconclincod_Multiplevaluestype ;
      private string Combo_poconclincod_Loadingdata ;
      private string Combo_poconclincod_Noresultsfound ;
      private string Combo_poconclincod_Emptyitemtext ;
      private string Combo_poconclincod_Onlyselectedvalues ;
      private string Combo_poconclincod_Selectalltext ;
      private string Combo_poconclincod_Multiplevaluesseparator ;
      private string Combo_poconclincod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_poconcdcuecod_Objectcall ;
      private string Combo_poconcdcuecod_Class ;
      private string Combo_poconcdcuecod_Icontype ;
      private string Combo_poconcdcuecod_Icon ;
      private string Combo_poconcdcuecod_Tooltip ;
      private string Combo_poconcdcuecod_Selectedvalue_set ;
      private string Combo_poconcdcuecod_Selectedvalue_get ;
      private string Combo_poconcdcuecod_Selectedtext_set ;
      private string Combo_poconcdcuecod_Selectedtext_get ;
      private string Combo_poconcdcuecod_Gamoauthtoken ;
      private string Combo_poconcdcuecod_Ddointernalname ;
      private string Combo_poconcdcuecod_Titlecontrolalign ;
      private string Combo_poconcdcuecod_Dropdownoptionstype ;
      private string Combo_poconcdcuecod_Titlecontrolidtoreplace ;
      private string Combo_poconcdcuecod_Datalisttype ;
      private string Combo_poconcdcuecod_Datalistfixedvalues ;
      private string Combo_poconcdcuecod_Datalistproc ;
      private string Combo_poconcdcuecod_Datalistprocparametersprefix ;
      private string Combo_poconcdcuecod_Htmltemplate ;
      private string Combo_poconcdcuecod_Multiplevaluestype ;
      private string Combo_poconcdcuecod_Loadingdata ;
      private string Combo_poconcdcuecod_Noresultsfound ;
      private string Combo_poconcdcuecod_Emptyitemtext ;
      private string Combo_poconcdcuecod_Onlyselectedvalues ;
      private string Combo_poconcdcuecod_Selectalltext ;
      private string Combo_poconcdcuecod_Multiplevaluesseparator ;
      private string Combo_poconcdcuecod_Addnewoptiontext ;
      private string hsh ;
      private string sMode141 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z1647PoConcDCueDsc ;
      private string sGXsfl_49_fel_idx="0001" ;
      private string subGridlevel_level1_Class ;
      private string subGridlevel_level1_Linesclass ;
      private string ROClassString ;
      private string edtPoConcDCueCod_Jsonclick ;
      private string edtPoConcDCueDsc_Jsonclick ;
      private string edtPoConcCosCod_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_level1_Internalname ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n314PoConcLinCod ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_poconcdcuecod_Isgriditem ;
      private bool bGXsfl_49_Refreshing=false ;
      private bool Combo_poconclincod_Enabled ;
      private bool Combo_poconclincod_Visible ;
      private bool Combo_poconclincod_Allowmultipleselection ;
      private bool Combo_poconclincod_Isgriditem ;
      private bool Combo_poconclincod_Hasdescription ;
      private bool Combo_poconclincod_Includeonlyselectedoption ;
      private bool Combo_poconclincod_Includeselectalloption ;
      private bool Combo_poconclincod_Emptyitem ;
      private bool Combo_poconclincod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_poconcdcuecod_Enabled ;
      private bool Combo_poconcdcuecod_Visible ;
      private bool Combo_poconcdcuecod_Allowmultipleselection ;
      private bool Combo_poconcdcuecod_Hasdescription ;
      private bool Combo_poconcdcuecod_Includeonlyselectedoption ;
      private bool Combo_poconcdcuecod_Includeselectalloption ;
      private bool Combo_poconcdcuecod_Emptyitem ;
      private bool Combo_poconcdcuecod_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV17Combo_DataJson ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_level1Container ;
      private GXWebRow Gridlevel_level1Row ;
      private GXWebColumn Gridlevel_level1Column ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_poconclincod ;
      private GXUserControl ucCombo_poconcdcuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPoConcTip ;
      private GXCombobox cmbPoConcSts ;
      private IDataStoreProvider pr_default ;
      private int[] T006J8_A313PoConcCod ;
      private string[] T006J8_A1648PoConcDsc ;
      private string[] T006J8_A1650PoConcTip ;
      private short[] T006J8_A1649PoConcSts ;
      private int[] T006J8_A314PoConcLinCod ;
      private bool[] T006J8_n314PoConcLinCod ;
      private int[] T006J7_A314PoConcLinCod ;
      private bool[] T006J7_n314PoConcLinCod ;
      private int[] T006J9_A314PoConcLinCod ;
      private bool[] T006J9_n314PoConcLinCod ;
      private int[] T006J10_A313PoConcCod ;
      private int[] T006J6_A313PoConcCod ;
      private string[] T006J6_A1648PoConcDsc ;
      private string[] T006J6_A1650PoConcTip ;
      private short[] T006J6_A1649PoConcSts ;
      private int[] T006J6_A314PoConcLinCod ;
      private bool[] T006J6_n314PoConcLinCod ;
      private int[] T006J11_A313PoConcCod ;
      private int[] T006J12_A313PoConcCod ;
      private int[] T006J5_A313PoConcCod ;
      private string[] T006J5_A1648PoConcDsc ;
      private string[] T006J5_A1650PoConcTip ;
      private short[] T006J5_A1649PoConcSts ;
      private int[] T006J5_A314PoConcLinCod ;
      private bool[] T006J5_n314PoConcLinCod ;
      private int[] T006J16_A313PoConcCod ;
      private int[] T006J17_A313PoConcCod ;
      private string[] T006J17_A1647PoConcDCueDsc ;
      private string[] T006J17_A316PoConcCosCod ;
      private string[] T006J17_A315PoConcDCueCod ;
      private string[] T006J4_A1647PoConcDCueDsc ;
      private string[] T006J18_A1647PoConcDCueDsc ;
      private int[] T006J19_A313PoConcCod ;
      private string[] T006J19_A315PoConcDCueCod ;
      private int[] T006J3_A313PoConcCod ;
      private string[] T006J3_A316PoConcCosCod ;
      private string[] T006J3_A315PoConcDCueCod ;
      private int[] T006J2_A313PoConcCod ;
      private string[] T006J2_A316PoConcCosCod ;
      private string[] T006J2_A315PoConcDCueCod ;
      private string[] T006J23_A1647PoConcDCueDsc ;
      private int[] T006J24_A313PoConcCod ;
      private string[] T006J24_A315PoConcDCueCod ;
      private int[] T006J25_A314PoConcLinCod ;
      private bool[] T006J25_n314PoConcLinCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18PoConcLinCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13PoConcDCueCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class conceptosordenesproduccion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class conceptosordenesproduccion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006J8;
        prmT006J8 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J7;
        prmT006J7 = new Object[] {
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006J9;
        prmT006J9 = new Object[] {
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006J10;
        prmT006J10 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J6;
        prmT006J6 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J11;
        prmT006J11 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J12;
        prmT006J12 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J5;
        prmT006J5 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J13;
        prmT006J13 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDsc",GXType.NChar,100,0) ,
        new ParDef("@PoConcTip",GXType.NChar,1,0) ,
        new ParDef("@PoConcSts",GXType.Int16,1,0) ,
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006J14;
        prmT006J14 = new Object[] {
        new ParDef("@PoConcDsc",GXType.NChar,100,0) ,
        new ParDef("@PoConcTip",GXType.NChar,1,0) ,
        new ParDef("@PoConcSts",GXType.Int16,1,0) ,
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J15;
        prmT006J15 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J16;
        prmT006J16 = new Object[] {
        };
        Object[] prmT006J17;
        prmT006J17 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J4;
        prmT006J4 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J18;
        prmT006J18 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J19;
        prmT006J19 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J3;
        prmT006J3 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J2;
        prmT006J2 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J20;
        prmT006J20 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcCosCod",GXType.NChar,10,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J21;
        prmT006J21 = new Object[] {
        new ParDef("@PoConcCosCod",GXType.NChar,10,0) ,
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J22;
        prmT006J22 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006J24;
        prmT006J24 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006J25;
        prmT006J25 = new Object[] {
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006J23;
        prmT006J23 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006J2", "SELECT [PoConcCod], [PoConcCosCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WITH (UPDLOCK) WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J3", "SELECT [PoConcCod], [PoConcCosCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J4", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J5", "SELECT [PoConcCod], [PoConcDsc], [PoConcTip], [PoConcSts], [PoConcLinCod] AS PoConcLinCod FROM [POCONCEPTOS] WITH (UPDLOCK) WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J6", "SELECT [PoConcCod], [PoConcDsc], [PoConcTip], [PoConcSts], [PoConcLinCod] AS PoConcLinCod FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J7", "SELECT [LinCod] AS PoConcLinCod FROM [CLINEAPROD] WHERE [LinCod] = @PoConcLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J8", "SELECT TM1.[PoConcCod], TM1.[PoConcDsc], TM1.[PoConcTip], TM1.[PoConcSts], TM1.[PoConcLinCod] AS PoConcLinCod FROM [POCONCEPTOS] TM1 WHERE TM1.[PoConcCod] = @PoConcCod ORDER BY TM1.[PoConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006J8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J9", "SELECT [LinCod] AS PoConcLinCod FROM [CLINEAPROD] WHERE [LinCod] = @PoConcLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J10", "SELECT [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006J10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J11", "SELECT TOP 1 [PoConcCod] FROM [POCONCEPTOS] WHERE ( [PoConcCod] > @PoConcCod) ORDER BY [PoConcCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006J12", "SELECT TOP 1 [PoConcCod] FROM [POCONCEPTOS] WHERE ( [PoConcCod] < @PoConcCod) ORDER BY [PoConcCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006J12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006J13", "INSERT INTO [POCONCEPTOS]([PoConcCod], [PoConcDsc], [PoConcTip], [PoConcSts], [PoConcLinCod]) VALUES(@PoConcCod, @PoConcDsc, @PoConcTip, @PoConcSts, @PoConcLinCod)", GxErrorMask.GX_NOMASK,prmT006J13)
           ,new CursorDef("T006J14", "UPDATE [POCONCEPTOS] SET [PoConcDsc]=@PoConcDsc, [PoConcTip]=@PoConcTip, [PoConcSts]=@PoConcSts, [PoConcLinCod]=@PoConcLinCod  WHERE [PoConcCod] = @PoConcCod", GxErrorMask.GX_NOMASK,prmT006J14)
           ,new CursorDef("T006J15", "DELETE FROM [POCONCEPTOS]  WHERE [PoConcCod] = @PoConcCod", GxErrorMask.GX_NOMASK,prmT006J15)
           ,new CursorDef("T006J16", "SELECT [PoConcCod] FROM [POCONCEPTOS] ORDER BY [PoConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006J16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J17", "SELECT T1.[PoConcCod], T2.[CueDsc] AS PoConcDCueDsc, T1.[PoConcCosCod], T1.[PoConcDCueCod] AS PoConcDCueCod FROM ([POCONCEPTOSDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[PoConcDCueCod]) WHERE T1.[PoConcCod] = @PoConcCod and T1.[PoConcDCueCod] = @PoConcDCueCod ORDER BY T1.[PoConcCod], T1.[PoConcDCueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J18", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J19", "SELECT [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J20", "INSERT INTO [POCONCEPTOSDET]([PoConcCod], [PoConcCosCod], [PoConcDCueCod]) VALUES(@PoConcCod, @PoConcCosCod, @PoConcDCueCod)", GxErrorMask.GX_NOMASK,prmT006J20)
           ,new CursorDef("T006J21", "UPDATE [POCONCEPTOSDET] SET [PoConcCosCod]=@PoConcCosCod  WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod", GxErrorMask.GX_NOMASK,prmT006J21)
           ,new CursorDef("T006J22", "DELETE FROM [POCONCEPTOSDET]  WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod", GxErrorMask.GX_NOMASK,prmT006J22)
           ,new CursorDef("T006J23", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J24", "SELECT [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod ORDER BY [PoConcCod], [PoConcDCueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J24,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006J25", "SELECT [LinCod] AS PoConcLinCod FROM [CLINEAPROD] WHERE [LinCod] = @PoConcLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006J25,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
