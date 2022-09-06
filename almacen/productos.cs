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
namespace GeneXus.Programs.almacen {
   public class productos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A52LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A52LinCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_38") == 0 )
         {
            A51SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_38( A51SublCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_39") == 0 )
         {
            A50FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_39( A50FamCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_40") == 0 )
         {
            A49UniCod = (int)(NumberUtil.Val( GetPar( "UniCod"), "."));
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_40( A49UniCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A48ProdCuentaV = GetPar( "ProdCuentaV");
            n48ProdCuentaV = false;
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A48ProdCuentaV) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A53ProdCuentaC = GetPar( "ProdCuentaC");
            n53ProdCuentaC = false;
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A53ProdCuentaC) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A54ProdCuentaA = GetPar( "ProdCuentaA");
            n54ProdCuentaA = false;
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A54ProdCuentaA) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_41") == 0 )
         {
            A47CBSuCod = GetPar( "CBSuCod");
            n47CBSuCod = false;
            AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_41( A47CBSuCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_42") == 0 )
         {
            A46cDetCod = (int)(NumberUtil.Val( GetPar( "cDetCod"), "."));
            n46cDetCod = false;
            AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_42( A46cDetCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.productos.aspx")), "almacen.productos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.productos.aspx")))) ;
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
                  AV7ProdCod = GetPar( "ProdCod");
                  AssignAttri("", false, "AV7ProdCod", AV7ProdCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPRODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProdCod, "@!")), context));
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
            Form.Meta.addItem("description", "Productos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public productos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public productos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_ProdCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProdCod = aP1_ProdCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkProdVta = new GXCheckbox();
         chkProdCmp = new GXCheckbox();
         cmbProdSts = new GXCombobox();
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
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            AssignProp("", false, cmbProdSts_Internalname, "Values", cmbProdSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCod_Internalname, "Codigo Producto", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedlincod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklincod_Internalname, "Codigo de Linea", "", "", lblTextblocklincod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_lincod.SetProperty("Caption", Combo_lincod_Caption);
         ucCombo_lincod.SetProperty("Cls", Combo_lincod_Cls);
         ucCombo_lincod.SetProperty("DataListProc", Combo_lincod_Datalistproc);
         ucCombo_lincod.SetProperty("DataListProcParametersPrefix", Combo_lincod_Datalistprocparametersprefix);
         ucCombo_lincod.SetProperty("EmptyItem", Combo_lincod_Emptyitem);
         ucCombo_lincod.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_lincod.SetProperty("DropDownOptionsData", AV21LinCod_Data);
         ucCombo_lincod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_lincod_Internalname, "COMBO_LINCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinCod_Internalname, "Codigo de Linea", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinCod_Jsonclick, 0, "Attribute", "", "", "", "", edtLinCod_Visible, edtLinCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdDsc_Internalname, "Descripcion producto", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsublcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksublcod_Internalname, "Codigo Sub Linea", "", "", lblTextblocksublcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_sublcod.SetProperty("Caption", Combo_sublcod_Caption);
         ucCombo_sublcod.SetProperty("Cls", Combo_sublcod_Cls);
         ucCombo_sublcod.SetProperty("DataListProc", Combo_sublcod_Datalistproc);
         ucCombo_sublcod.SetProperty("DataListProcParametersPrefix", Combo_sublcod_Datalistprocparametersprefix);
         ucCombo_sublcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_sublcod.SetProperty("DropDownOptionsData", AV27SublCod_Data);
         ucCombo_sublcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sublcod_Internalname, "COMBO_SUBLCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSublCod_Internalname, "Codigo Sub Linea", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublCod_Jsonclick, 0, "Attribute", "", "", "", "", edtSublCod_Visible, edtSublCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedfamcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockfamcod_Internalname, "Codigo Familia", "", "", lblTextblockfamcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_famcod.SetProperty("Caption", Combo_famcod_Caption);
         ucCombo_famcod.SetProperty("Cls", Combo_famcod_Cls);
         ucCombo_famcod.SetProperty("DataListProc", Combo_famcod_Datalistproc);
         ucCombo_famcod.SetProperty("DataListProcParametersPrefix", Combo_famcod_Datalistprocparametersprefix);
         ucCombo_famcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_famcod.SetProperty("DropDownOptionsData", AV29FamCod_Data);
         ucCombo_famcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_famcod_Internalname, "COMBO_FAMCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFamCod_Internalname, "Codigo Familia", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamCod_Jsonclick, 0, "Attribute", "", "", "", "", edtFamCod_Visible, edtFamCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedunicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockunicod_Internalname, "Codigo Unidad Medida", "", "", lblTextblockunicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_unicod.SetProperty("Caption", Combo_unicod_Caption);
         ucCombo_unicod.SetProperty("Cls", Combo_unicod_Cls);
         ucCombo_unicod.SetProperty("DataListProc", Combo_unicod_Datalistproc);
         ucCombo_unicod.SetProperty("DataListProcParametersPrefix", Combo_unicod_Datalistprocparametersprefix);
         ucCombo_unicod.SetProperty("EmptyItem", Combo_unicod_Emptyitem);
         ucCombo_unicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_unicod.SetProperty("DropDownOptionsData", AV31UniCod_Data);
         ucCombo_unicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_unicod_Internalname, "COMBO_UNICODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUniCod_Internalname, "Codigo Unidad Medida", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUniCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUniCod_Jsonclick, 0, "Attribute", "", "", "", "", edtUniCod_Visible, edtUniCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkProdVta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkProdVta_Internalname, "Destinado Venta", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProdVta_Internalname, StringUtil.Str( (decimal)(A1724ProdVta), 1, 0), "", "Destinado Venta", 1, chkProdVta.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkProdCmp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkProdCmp_Internalname, "Destinado Compra", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProdCmp_Internalname, StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0), "", "Destinado Compra", 1, chkProdCmp.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(77, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,77);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdPeso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdPeso_Internalname, "Peso producto", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdPeso_Internalname, StringUtil.LTrim( StringUtil.NToC( A1702ProdPeso, 15, 5, ".", "")), StringUtil.LTrim( ((edtProdPeso_Enabled!=0) ? context.localUtil.Format( A1702ProdPeso, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1702ProdPeso, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdPeso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdPeso_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdVolumen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdVolumen_Internalname, "Volumen producto", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdVolumen_Internalname, StringUtil.LTrim( StringUtil.NToC( A1723ProdVolumen, 15, 5, ".", "")), StringUtil.LTrim( ((edtProdVolumen_Enabled!=0) ? context.localUtil.Format( A1723ProdVolumen, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1723ProdVolumen, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdVolumen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdVolumen_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdStkMax_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdStkMax_Internalname, "Stock Maximo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdStkMax_Internalname, StringUtil.LTrim( StringUtil.NToC( A1716ProdStkMax, 17, 4, ".", "")), StringUtil.LTrim( ((edtProdStkMax_Enabled!=0) ? context.localUtil.Format( A1716ProdStkMax, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1716ProdStkMax, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdStkMax_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdStkMax_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdStkMin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdStkMin_Internalname, "Stock Minimo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdStkMin_Internalname, StringUtil.LTrim( StringUtil.NToC( A1717ProdStkMin, 17, 4, ".", "")), StringUtil.LTrim( ((edtProdStkMin_Enabled!=0) ? context.localUtil.Format( A1717ProdStkMin, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1717ProdStkMin, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdStkMin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdStkMin_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgProdFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto Producto", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A1695ProdFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.PathToRelativeUrl( A1695ProdFoto));
         GxWebStd.gx_bitmap( context, imgProdFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProdFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "", "", "", 0, A1695ProdFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\Productos.htm");
         AssignProp("", false, imgProdFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.PathToRelativeUrl( A1695ProdFoto)), true);
         AssignProp("", false, imgProdFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A1695ProdFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef1_Internalname, "Referencia 1", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef1_Internalname, StringUtil.RTrim( A1705ProdRef1), StringUtil.RTrim( context.localUtil.Format( A1705ProdRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef2_Internalname, "Referencia 2", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef2_Internalname, StringUtil.RTrim( A1707ProdRef2), StringUtil.RTrim( context.localUtil.Format( A1707ProdRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef3_Internalname, "Referencia 3", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef3_Internalname, StringUtil.RTrim( A1708ProdRef3), StringUtil.RTrim( context.localUtil.Format( A1708ProdRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef4_Internalname, "Referencia 4", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef4_Internalname, StringUtil.RTrim( A1709ProdRef4), StringUtil.RTrim( context.localUtil.Format( A1709ProdRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef5_Internalname, "Referencia 5", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef5_Internalname, StringUtil.RTrim( A1710ProdRef5), StringUtil.RTrim( context.localUtil.Format( A1710ProdRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef6_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef6_Internalname, "Referencia 6", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef6_Internalname, StringUtil.RTrim( A1711ProdRef6), StringUtil.RTrim( context.localUtil.Format( A1711ProdRef6, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef6_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef7_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef7_Internalname, "Referencia 7", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef7_Internalname, StringUtil.RTrim( A1712ProdRef7), StringUtil.RTrim( context.localUtil.Format( A1712ProdRef7, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef7_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef8_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef8_Internalname, "Referencia 8", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef8_Internalname, StringUtil.RTrim( A1713ProdRef8), StringUtil.RTrim( context.localUtil.Format( A1713ProdRef8, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef8_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef9_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef9_Internalname, "Referencia 9", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef9_Internalname, StringUtil.RTrim( A1714ProdRef9), StringUtil.RTrim( context.localUtil.Format( A1714ProdRef9, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef9_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef9_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdRef10_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdRef10_Internalname, "Referencia 10", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef10_Internalname, StringUtil.RTrim( A1706ProdRef10), StringUtil.RTrim( context.localUtil.Format( A1706ProdRef10, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef10_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef10_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbProdSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProdSts_Internalname, "Situacion", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProdSts, cmbProdSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0)), 1, cmbProdSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbProdSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "", true, 1, "HLP_Almacen\\Productos.htm");
         cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         AssignProp("", false, cmbProdSts_Internalname, "Values", (string)(cmbProdSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCosto_Internalname, "Ult. Costo MN", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1681ProdCosto, 18, 5, ".", "")), StringUtil.LTrim( ((edtProdCosto_Enabled!=0) ? context.localUtil.Format( A1681ProdCosto, "ZZZZZZZZZZZ9.99999") : context.localUtil.Format( A1681ProdCosto, "ZZZZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCosto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCostoFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCostoFec_Internalname, "Fecha Ult. Costo", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProdCostoFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProdCostoFec_Internalname, context.localUtil.Format(A1683ProdCostoFec, "99/99/99"), context.localUtil.Format( A1683ProdCostoFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCostoFec_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtProdCostoFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_bitmap( context, edtProdCostoFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProdCostoFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\Productos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCostoD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCostoD_Internalname, "Ult. Costo ME", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCostoD_Internalname, StringUtil.LTrim( StringUtil.NToC( A1682ProdCostoD, 18, 5, ".", "")), StringUtil.LTrim( ((edtProdCostoD_Enabled!=0) ? context.localUtil.Format( A1682ProdCostoD, "ZZZZZZZZZZZ9.99999") : context.localUtil.Format( A1682ProdCostoD, "ZZZZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCostoD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCostoD_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdIna_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdIna_Internalname, "Inafecta IGV", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdIna_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1698ProdIna), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdIna_Enabled!=0) ? context.localUtil.Format( (decimal)(A1698ProdIna), "9") : context.localUtil.Format( (decimal)(A1698ProdIna), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdIna_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdPorSel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdPorSel_Internalname, "% Impuesto Selectivo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdPorSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")), StringUtil.LTrim( ((edtProdPorSel_Enabled!=0) ? context.localUtil.Format( A1703ProdPorSel, "ZZ9.99") : context.localUtil.Format( A1703ProdPorSel, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdPorSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdPorSel_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdImpSel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdImpSel_Internalname, "Selectivo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdImpSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A1697ProdImpSel, 17, 2, ".", "")), StringUtil.LTrim( ((edtProdImpSel_Enabled!=0) ? context.localUtil.Format( A1697ProdImpSel, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1697ProdImpSel, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdImpSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdImpSel_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdAdValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdAdValor_Internalname, "% AdValorem", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdAdValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A1672ProdAdValor, 6, 2, ".", "")), StringUtil.LTrim( ((edtProdAdValor_Enabled!=0) ? context.localUtil.Format( A1672ProdAdValor, "ZZ9.99") : context.localUtil.Format( A1672ProdAdValor, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdAdValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdAdValor_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdReferencias_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdReferencias_Internalname, "Referencias", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProdReferencias_Internalname, A1715ProdReferencias, "", "", 0, 1, edtProdReferencias_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdFrecuente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdFrecuente_Internalname, "Producto Frecuente", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdFrecuente_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1696ProdFrecuente), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdFrecuente_Enabled!=0) ? context.localUtil.Format( (decimal)(A1696ProdFrecuente), "9") : context.localUtil.Format( (decimal)(A1696ProdFrecuente), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,190);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdFrecuente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdFrecuente_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprodcuentav_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprodcuentav_Internalname, "Cuenta Venta", "", "", lblTextblockprodcuentav_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_prodcuentav.SetProperty("Caption", Combo_prodcuentav_Caption);
         ucCombo_prodcuentav.SetProperty("Cls", Combo_prodcuentav_Cls);
         ucCombo_prodcuentav.SetProperty("DataListProc", Combo_prodcuentav_Datalistproc);
         ucCombo_prodcuentav.SetProperty("DataListProcParametersPrefix", Combo_prodcuentav_Datalistprocparametersprefix);
         ucCombo_prodcuentav.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_prodcuentav.SetProperty("DropDownOptionsData", AV33ProdCuentaV_Data);
         ucCombo_prodcuentav.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_prodcuentav_Internalname, "COMBO_PRODCUENTAVContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCuentaV_Internalname, "Cuenta Venta", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCuentaV_Internalname, StringUtil.RTrim( A48ProdCuentaV), StringUtil.RTrim( context.localUtil.Format( A48ProdCuentaV, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,200);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaV_Jsonclick, 0, "Attribute", "", "", "", "", edtProdCuentaV_Visible, edtProdCuentaV_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCuentaVDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCuentaVDsc_Internalname, "Descripción Cuenta Venta", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCuentaVDsc_Internalname, StringUtil.RTrim( A1686ProdCuentaVDsc), StringUtil.RTrim( context.localUtil.Format( A1686ProdCuentaVDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaVDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaVDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprodcuentac_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprodcuentac_Internalname, "Cuenta Compras", "", "", lblTextblockprodcuentac_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_prodcuentac.SetProperty("Caption", Combo_prodcuentac_Caption);
         ucCombo_prodcuentac.SetProperty("Cls", Combo_prodcuentac_Cls);
         ucCombo_prodcuentac.SetProperty("DataListProc", Combo_prodcuentac_Datalistproc);
         ucCombo_prodcuentac.SetProperty("DataListProcParametersPrefix", Combo_prodcuentac_Datalistprocparametersprefix);
         ucCombo_prodcuentac.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_prodcuentac.SetProperty("DropDownOptionsData", AV36ProdCuentaC_Data);
         ucCombo_prodcuentac.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_prodcuentac_Internalname, "COMBO_PRODCUENTACContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCuentaC_Internalname, "Cuenta Compras", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 215,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCuentaC_Internalname, StringUtil.RTrim( A53ProdCuentaC), StringUtil.RTrim( context.localUtil.Format( A53ProdCuentaC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,215);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaC_Jsonclick, 0, "Attribute", "", "", "", "", edtProdCuentaC_Visible, edtProdCuentaC_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCuentaCDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCuentaCDsc_Internalname, "Descripción Cuenta Compra", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCuentaCDsc_Internalname, StringUtil.RTrim( A1685ProdCuentaCDsc), StringUtil.RTrim( context.localUtil.Format( A1685ProdCuentaCDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaCDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaCDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprodcuentaa_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprodcuentaa_Internalname, "Cuenta Almacen", "", "", lblTextblockprodcuentaa_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_prodcuentaa.SetProperty("Caption", Combo_prodcuentaa_Caption);
         ucCombo_prodcuentaa.SetProperty("Cls", Combo_prodcuentaa_Cls);
         ucCombo_prodcuentaa.SetProperty("DataListProc", Combo_prodcuentaa_Datalistproc);
         ucCombo_prodcuentaa.SetProperty("DataListProcParametersPrefix", Combo_prodcuentaa_Datalistprocparametersprefix);
         ucCombo_prodcuentaa.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_prodcuentaa.SetProperty("DropDownOptionsData", AV38ProdCuentaA_Data);
         ucCombo_prodcuentaa.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_prodcuentaa_Internalname, "COMBO_PRODCUENTAAContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCuentaA_Internalname, "Cuenta Almacen", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCuentaA_Internalname, StringUtil.RTrim( A54ProdCuentaA), StringUtil.RTrim( context.localUtil.Format( A54ProdCuentaA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,230);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaA_Jsonclick, 0, "Attribute", "", "", "", "", edtProdCuentaA_Visible, edtProdCuentaA_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCuentaADsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCuentaADsc_Internalname, "Descripción Cuenta Almacen", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCuentaADsc_Internalname, StringUtil.RTrim( A1684ProdCuentaADsc), StringUtil.RTrim( context.localUtil.Format( A1684ProdCuentaADsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaADsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaADsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdUsuCod_Internalname, "Usuario", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdUsuCod_Internalname, StringUtil.RTrim( A1721ProdUsuCod), StringUtil.RTrim( context.localUtil.Format( A1721ProdUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,239);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdUsuFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdUsuFec_Internalname, "Usuario Fecha", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProdUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProdUsuFec_Internalname, context.localUtil.TToC( A1722ProdUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1722ProdUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,244);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdUsuFec_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtProdUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_bitmap( context, edtProdUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProdUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Almacen\\Productos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdAfec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdAfec_Internalname, "Inafecto", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 248,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdAfec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1673ProdAfec), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdAfec_Enabled!=0) ? context.localUtil.Format( (decimal)(A1673ProdAfec), "9") : context.localUtil.Format( (decimal)(A1673ProdAfec), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,248);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdAfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdAfec_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdObs_Internalname, "Observaciones", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 253,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProdObs_Internalname, A1701ProdObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,253);\"", 0, 1, edtProdObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCanLote_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCanLote_Internalname, "Lote", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 257,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCanLote_Internalname, StringUtil.LTrim( StringUtil.NToC( A1675ProdCanLote, 17, 2, ".", "")), StringUtil.LTrim( ((edtProdCanLote_Enabled!=0) ? context.localUtil.Format( A1675ProdCanLote, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1675ProdCanLote, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,257);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCanLote_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCanLote_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdBarra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdBarra_Internalname, "de Barra", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 262,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdBarra_Internalname, A1674ProdBarra, StringUtil.RTrim( context.localUtil.Format( A1674ProdBarra, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,262);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdBarra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdBarra_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdExportacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdExportacion_Internalname, "Internacional", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdExportacion_Internalname, A1689ProdExportacion, StringUtil.RTrim( context.localUtil.Format( A1689ProdExportacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdExportacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdExportacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcbsucod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcbsucod_Internalname, "Codigo", "", "", lblTextblockcbsucod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cbsucod.SetProperty("Caption", Combo_cbsucod_Caption);
         ucCombo_cbsucod.SetProperty("Cls", Combo_cbsucod_Cls);
         ucCombo_cbsucod.SetProperty("DataListProc", Combo_cbsucod_Datalistproc);
         ucCombo_cbsucod.SetProperty("DataListProcParametersPrefix", Combo_cbsucod_Datalistprocparametersprefix);
         ucCombo_cbsucod.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_cbsucod.SetProperty("DropDownOptionsData", AV40CBSuCod_Data);
         ucCombo_cbsucod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cbsucod_Internalname, "COMBO_CBSUCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBSuCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 277,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBSuCod_Internalname, A47CBSuCod, StringUtil.RTrim( context.localUtil.Format( A47CBSuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,277);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBSuCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCBSuCod_Visible, edtCBSuCod_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdAfecICBPER_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdAfecICBPER_Internalname, "ICBPER", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdAfecICBPER_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdAfecICBPER_Enabled!=0) ? context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9") : context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,281);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdAfecICBPER_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdAfecICBPER_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdValICBPER_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdValICBPER_Internalname, "ICBPER S/.", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 286,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdValICBPER_Internalname, StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 17, 2, ".", "")), StringUtil.LTrim( ((edtProdValICBPER_Enabled!=0) ? context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,286);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdValICBPER_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdValICBPER_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdValICBPERD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdValICBPERD_Internalname, "ICBPER US$", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 290,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdValICBPERD_Internalname, StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 17, 2, ".", "")), StringUtil.LTrim( ((edtProdValICBPERD_Enabled!=0) ? context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,290);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdValICBPERD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdValICBPERD_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcdetcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcdetcod_Internalname, "Codigo", "", "", lblTextblockcdetcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cdetcod.SetProperty("Caption", Combo_cdetcod_Caption);
         ucCombo_cdetcod.SetProperty("Cls", Combo_cdetcod_Cls);
         ucCombo_cdetcod.SetProperty("DataListProc", Combo_cdetcod_Datalistproc);
         ucCombo_cdetcod.SetProperty("DataListProcParametersPrefix", Combo_cdetcod_Datalistprocparametersprefix);
         ucCombo_cdetcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_cdetcod.SetProperty("DropDownOptionsData", AV42cDetCod_Data);
         ucCombo_cdetcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cdetcod_Internalname, "COMBO_CDETCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcDetCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 301,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcDetCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A46cDetCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A46cDetCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,301);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcDetCod_Jsonclick, 0, "Attribute", "", "", "", "", edtcDetCod_Visible, edtcDetCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinDsc_Internalname, "Descripcion de Linea", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLinDsc_Internalname, StringUtil.RTrim( A1153LinDsc), StringUtil.RTrim( context.localUtil.Format( A1153LinDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 310,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 312,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 314,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\Productos.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_lincod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombolincod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ComboLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombolincod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ComboLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV26ComboLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombolincod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombolincod_Visible, edtavCombolincod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_sublcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombosublcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ComboSublCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombosublcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV28ComboSublCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV28ComboSublCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosublcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosublcod_Visible, edtavCombosublcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_famcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombofamcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ComboFamCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombofamcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30ComboFamCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV30ComboFamCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombofamcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombofamcod_Visible, edtavCombofamcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_unicod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombounicod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ComboUniCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombounicod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV32ComboUniCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV32ComboUniCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombounicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombounicod_Visible, edtavCombounicod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_prodcuentav_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprodcuentav_Internalname, StringUtil.RTrim( AV34ComboProdCuentaV), StringUtil.RTrim( context.localUtil.Format( AV34ComboProdCuentaV, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprodcuentav_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprodcuentav_Visible, edtavComboprodcuentav_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_prodcuentac_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprodcuentac_Internalname, StringUtil.RTrim( AV37ComboProdCuentaC), StringUtil.RTrim( context.localUtil.Format( AV37ComboProdCuentaC, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprodcuentac_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprodcuentac_Visible, edtavComboprodcuentac_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_prodcuentaa_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprodcuentaa_Internalname, StringUtil.RTrim( AV39ComboProdCuentaA), StringUtil.RTrim( context.localUtil.Format( AV39ComboProdCuentaA, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprodcuentaa_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprodcuentaa_Visible, edtavComboprodcuentaa_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cbsucod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocbsucod_Internalname, AV41ComboCBSuCod, StringUtil.RTrim( context.localUtil.Format( AV41ComboCBSuCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocbsucod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocbsucod_Visible, edtavCombocbsucod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\Productos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cdetcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocdetcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43CombocDetCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombocdetcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV43CombocDetCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV43CombocDetCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocdetcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocdetcod_Visible, edtavCombocdetcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Almacen\\Productos.htm");
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
         E117K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vLINCOD_DATA"), AV21LinCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUBLCOD_DATA"), AV27SublCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vFAMCOD_DATA"), AV29FamCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vUNICOD_DATA"), AV31UniCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODCUENTAV_DATA"), AV33ProdCuentaV_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODCUENTAC_DATA"), AV36ProdCuentaC_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODCUENTAA_DATA"), AV38ProdCuentaA_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCBSUCOD_DATA"), AV40CBSuCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCDETCOD_DATA"), AV42cDetCod_Data);
               /* Read saved values. */
               Z28ProdCod = cgiGet( "Z28ProdCod");
               Z55ProdDsc = cgiGet( "Z55ProdDsc");
               Z1724ProdVta = (short)(context.localUtil.CToN( cgiGet( "Z1724ProdVta"), ".", ","));
               Z1679ProdCmp = (short)(context.localUtil.CToN( cgiGet( "Z1679ProdCmp"), ".", ","));
               Z1702ProdPeso = context.localUtil.CToN( cgiGet( "Z1702ProdPeso"), ".", ",");
               Z1723ProdVolumen = context.localUtil.CToN( cgiGet( "Z1723ProdVolumen"), ".", ",");
               Z1716ProdStkMax = context.localUtil.CToN( cgiGet( "Z1716ProdStkMax"), ".", ",");
               Z1717ProdStkMin = context.localUtil.CToN( cgiGet( "Z1717ProdStkMin"), ".", ",");
               Z1705ProdRef1 = cgiGet( "Z1705ProdRef1");
               Z1707ProdRef2 = cgiGet( "Z1707ProdRef2");
               Z1708ProdRef3 = cgiGet( "Z1708ProdRef3");
               Z1709ProdRef4 = cgiGet( "Z1709ProdRef4");
               Z1710ProdRef5 = cgiGet( "Z1710ProdRef5");
               Z1711ProdRef6 = cgiGet( "Z1711ProdRef6");
               Z1712ProdRef7 = cgiGet( "Z1712ProdRef7");
               Z1713ProdRef8 = cgiGet( "Z1713ProdRef8");
               Z1714ProdRef9 = cgiGet( "Z1714ProdRef9");
               Z1706ProdRef10 = cgiGet( "Z1706ProdRef10");
               Z1718ProdSts = (short)(context.localUtil.CToN( cgiGet( "Z1718ProdSts"), ".", ","));
               Z1681ProdCosto = context.localUtil.CToN( cgiGet( "Z1681ProdCosto"), ".", ",");
               Z1683ProdCostoFec = context.localUtil.CToD( cgiGet( "Z1683ProdCostoFec"), 0);
               Z1682ProdCostoD = context.localUtil.CToN( cgiGet( "Z1682ProdCostoD"), ".", ",");
               Z1698ProdIna = (short)(context.localUtil.CToN( cgiGet( "Z1698ProdIna"), ".", ","));
               Z1703ProdPorSel = context.localUtil.CToN( cgiGet( "Z1703ProdPorSel"), ".", ",");
               Z1697ProdImpSel = context.localUtil.CToN( cgiGet( "Z1697ProdImpSel"), ".", ",");
               Z1672ProdAdValor = context.localUtil.CToN( cgiGet( "Z1672ProdAdValor"), ".", ",");
               Z1696ProdFrecuente = (short)(context.localUtil.CToN( cgiGet( "Z1696ProdFrecuente"), ".", ","));
               Z1721ProdUsuCod = cgiGet( "Z1721ProdUsuCod");
               Z1722ProdUsuFec = context.localUtil.CToT( cgiGet( "Z1722ProdUsuFec"), 0);
               Z1673ProdAfec = (short)(context.localUtil.CToN( cgiGet( "Z1673ProdAfec"), ".", ","));
               Z1701ProdObs = cgiGet( "Z1701ProdObs");
               Z1675ProdCanLote = context.localUtil.CToN( cgiGet( "Z1675ProdCanLote"), ".", ",");
               Z1674ProdBarra = cgiGet( "Z1674ProdBarra");
               Z1689ProdExportacion = cgiGet( "Z1689ProdExportacion");
               Z906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
               Z907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
               Z908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
               Z52LinCod = (int)(context.localUtil.CToN( cgiGet( "Z52LinCod"), ".", ","));
               Z51SublCod = (int)(context.localUtil.CToN( cgiGet( "Z51SublCod"), ".", ","));
               n51SublCod = ((0==A51SublCod) ? true : false);
               Z50FamCod = (int)(context.localUtil.CToN( cgiGet( "Z50FamCod"), ".", ","));
               n50FamCod = ((0==A50FamCod) ? true : false);
               Z49UniCod = (int)(context.localUtil.CToN( cgiGet( "Z49UniCod"), ".", ","));
               Z47CBSuCod = cgiGet( "Z47CBSuCod");
               n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
               Z46cDetCod = (int)(context.localUtil.CToN( cgiGet( "Z46cDetCod"), ".", ","));
               n46cDetCod = ((0==A46cDetCod) ? true : false);
               Z48ProdCuentaV = cgiGet( "Z48ProdCuentaV");
               n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
               Z53ProdCuentaC = cgiGet( "Z53ProdCuentaC");
               n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
               Z54ProdCuentaA = cgiGet( "Z54ProdCuentaA");
               n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N52LinCod = (int)(context.localUtil.CToN( cgiGet( "N52LinCod"), ".", ","));
               N51SublCod = (int)(context.localUtil.CToN( cgiGet( "N51SublCod"), ".", ","));
               n51SublCod = ((0==A51SublCod) ? true : false);
               N50FamCod = (int)(context.localUtil.CToN( cgiGet( "N50FamCod"), ".", ","));
               n50FamCod = ((0==A50FamCod) ? true : false);
               N49UniCod = (int)(context.localUtil.CToN( cgiGet( "N49UniCod"), ".", ","));
               N48ProdCuentaV = cgiGet( "N48ProdCuentaV");
               n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
               N53ProdCuentaC = cgiGet( "N53ProdCuentaC");
               n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
               N54ProdCuentaA = cgiGet( "N54ProdCuentaA");
               n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
               N47CBSuCod = cgiGet( "N47CBSuCod");
               n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
               N46cDetCod = (int)(context.localUtil.CToN( cgiGet( "N46cDetCod"), ".", ","));
               n46cDetCod = ((0==A46cDetCod) ? true : false);
               AV7ProdCod = cgiGet( "vPRODCOD");
               AV11Insert_LinCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_LINCOD"), ".", ","));
               AV12Insert_SublCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_SUBLCOD"), ".", ","));
               AV13Insert_FamCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_FAMCOD"), ".", ","));
               AV14Insert_UniCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_UNICOD"), ".", ","));
               AV15Insert_ProdCuentaV = cgiGet( "vINSERT_PRODCUENTAV");
               AV16Insert_ProdCuentaC = cgiGet( "vINSERT_PRODCUENTAC");
               AV17Insert_ProdCuentaA = cgiGet( "vINSERT_PRODCUENTAA");
               AV18Insert_CBSuCod = cgiGet( "vINSERT_CBSUCOD");
               AV19Insert_cDetCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CDETCOD"), ".", ","));
               A40000ProdFoto_GXI = cgiGet( "PRODFOTO_GXI");
               n40000ProdFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               AV44Pgmname = cgiGet( "vPGMNAME");
               Combo_lincod_Objectcall = cgiGet( "COMBO_LINCOD_Objectcall");
               Combo_lincod_Class = cgiGet( "COMBO_LINCOD_Class");
               Combo_lincod_Icontype = cgiGet( "COMBO_LINCOD_Icontype");
               Combo_lincod_Icon = cgiGet( "COMBO_LINCOD_Icon");
               Combo_lincod_Caption = cgiGet( "COMBO_LINCOD_Caption");
               Combo_lincod_Tooltip = cgiGet( "COMBO_LINCOD_Tooltip");
               Combo_lincod_Cls = cgiGet( "COMBO_LINCOD_Cls");
               Combo_lincod_Selectedvalue_set = cgiGet( "COMBO_LINCOD_Selectedvalue_set");
               Combo_lincod_Selectedvalue_get = cgiGet( "COMBO_LINCOD_Selectedvalue_get");
               Combo_lincod_Selectedtext_set = cgiGet( "COMBO_LINCOD_Selectedtext_set");
               Combo_lincod_Selectedtext_get = cgiGet( "COMBO_LINCOD_Selectedtext_get");
               Combo_lincod_Gamoauthtoken = cgiGet( "COMBO_LINCOD_Gamoauthtoken");
               Combo_lincod_Ddointernalname = cgiGet( "COMBO_LINCOD_Ddointernalname");
               Combo_lincod_Titlecontrolalign = cgiGet( "COMBO_LINCOD_Titlecontrolalign");
               Combo_lincod_Dropdownoptionstype = cgiGet( "COMBO_LINCOD_Dropdownoptionstype");
               Combo_lincod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Enabled"));
               Combo_lincod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Visible"));
               Combo_lincod_Titlecontrolidtoreplace = cgiGet( "COMBO_LINCOD_Titlecontrolidtoreplace");
               Combo_lincod_Datalisttype = cgiGet( "COMBO_LINCOD_Datalisttype");
               Combo_lincod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Allowmultipleselection"));
               Combo_lincod_Datalistfixedvalues = cgiGet( "COMBO_LINCOD_Datalistfixedvalues");
               Combo_lincod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Isgriditem"));
               Combo_lincod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Hasdescription"));
               Combo_lincod_Datalistproc = cgiGet( "COMBO_LINCOD_Datalistproc");
               Combo_lincod_Datalistprocparametersprefix = cgiGet( "COMBO_LINCOD_Datalistprocparametersprefix");
               Combo_lincod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_LINCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_lincod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Includeonlyselectedoption"));
               Combo_lincod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Includeselectalloption"));
               Combo_lincod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Emptyitem"));
               Combo_lincod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LINCOD_Includeaddnewoption"));
               Combo_lincod_Htmltemplate = cgiGet( "COMBO_LINCOD_Htmltemplate");
               Combo_lincod_Multiplevaluestype = cgiGet( "COMBO_LINCOD_Multiplevaluestype");
               Combo_lincod_Loadingdata = cgiGet( "COMBO_LINCOD_Loadingdata");
               Combo_lincod_Noresultsfound = cgiGet( "COMBO_LINCOD_Noresultsfound");
               Combo_lincod_Emptyitemtext = cgiGet( "COMBO_LINCOD_Emptyitemtext");
               Combo_lincod_Onlyselectedvalues = cgiGet( "COMBO_LINCOD_Onlyselectedvalues");
               Combo_lincod_Selectalltext = cgiGet( "COMBO_LINCOD_Selectalltext");
               Combo_lincod_Multiplevaluesseparator = cgiGet( "COMBO_LINCOD_Multiplevaluesseparator");
               Combo_lincod_Addnewoptiontext = cgiGet( "COMBO_LINCOD_Addnewoptiontext");
               Combo_lincod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_LINCOD_Gxcontroltype"), ".", ","));
               Combo_sublcod_Objectcall = cgiGet( "COMBO_SUBLCOD_Objectcall");
               Combo_sublcod_Class = cgiGet( "COMBO_SUBLCOD_Class");
               Combo_sublcod_Icontype = cgiGet( "COMBO_SUBLCOD_Icontype");
               Combo_sublcod_Icon = cgiGet( "COMBO_SUBLCOD_Icon");
               Combo_sublcod_Caption = cgiGet( "COMBO_SUBLCOD_Caption");
               Combo_sublcod_Tooltip = cgiGet( "COMBO_SUBLCOD_Tooltip");
               Combo_sublcod_Cls = cgiGet( "COMBO_SUBLCOD_Cls");
               Combo_sublcod_Selectedvalue_set = cgiGet( "COMBO_SUBLCOD_Selectedvalue_set");
               Combo_sublcod_Selectedvalue_get = cgiGet( "COMBO_SUBLCOD_Selectedvalue_get");
               Combo_sublcod_Selectedtext_set = cgiGet( "COMBO_SUBLCOD_Selectedtext_set");
               Combo_sublcod_Selectedtext_get = cgiGet( "COMBO_SUBLCOD_Selectedtext_get");
               Combo_sublcod_Gamoauthtoken = cgiGet( "COMBO_SUBLCOD_Gamoauthtoken");
               Combo_sublcod_Ddointernalname = cgiGet( "COMBO_SUBLCOD_Ddointernalname");
               Combo_sublcod_Titlecontrolalign = cgiGet( "COMBO_SUBLCOD_Titlecontrolalign");
               Combo_sublcod_Dropdownoptionstype = cgiGet( "COMBO_SUBLCOD_Dropdownoptionstype");
               Combo_sublcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Enabled"));
               Combo_sublcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Visible"));
               Combo_sublcod_Titlecontrolidtoreplace = cgiGet( "COMBO_SUBLCOD_Titlecontrolidtoreplace");
               Combo_sublcod_Datalisttype = cgiGet( "COMBO_SUBLCOD_Datalisttype");
               Combo_sublcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Allowmultipleselection"));
               Combo_sublcod_Datalistfixedvalues = cgiGet( "COMBO_SUBLCOD_Datalistfixedvalues");
               Combo_sublcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Isgriditem"));
               Combo_sublcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Hasdescription"));
               Combo_sublcod_Datalistproc = cgiGet( "COMBO_SUBLCOD_Datalistproc");
               Combo_sublcod_Datalistprocparametersprefix = cgiGet( "COMBO_SUBLCOD_Datalistprocparametersprefix");
               Combo_sublcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_SUBLCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_sublcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Includeonlyselectedoption"));
               Combo_sublcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Includeselectalloption"));
               Combo_sublcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Emptyitem"));
               Combo_sublcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUBLCOD_Includeaddnewoption"));
               Combo_sublcod_Htmltemplate = cgiGet( "COMBO_SUBLCOD_Htmltemplate");
               Combo_sublcod_Multiplevaluestype = cgiGet( "COMBO_SUBLCOD_Multiplevaluestype");
               Combo_sublcod_Loadingdata = cgiGet( "COMBO_SUBLCOD_Loadingdata");
               Combo_sublcod_Noresultsfound = cgiGet( "COMBO_SUBLCOD_Noresultsfound");
               Combo_sublcod_Emptyitemtext = cgiGet( "COMBO_SUBLCOD_Emptyitemtext");
               Combo_sublcod_Onlyselectedvalues = cgiGet( "COMBO_SUBLCOD_Onlyselectedvalues");
               Combo_sublcod_Selectalltext = cgiGet( "COMBO_SUBLCOD_Selectalltext");
               Combo_sublcod_Multiplevaluesseparator = cgiGet( "COMBO_SUBLCOD_Multiplevaluesseparator");
               Combo_sublcod_Addnewoptiontext = cgiGet( "COMBO_SUBLCOD_Addnewoptiontext");
               Combo_sublcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_SUBLCOD_Gxcontroltype"), ".", ","));
               Combo_famcod_Objectcall = cgiGet( "COMBO_FAMCOD_Objectcall");
               Combo_famcod_Class = cgiGet( "COMBO_FAMCOD_Class");
               Combo_famcod_Icontype = cgiGet( "COMBO_FAMCOD_Icontype");
               Combo_famcod_Icon = cgiGet( "COMBO_FAMCOD_Icon");
               Combo_famcod_Caption = cgiGet( "COMBO_FAMCOD_Caption");
               Combo_famcod_Tooltip = cgiGet( "COMBO_FAMCOD_Tooltip");
               Combo_famcod_Cls = cgiGet( "COMBO_FAMCOD_Cls");
               Combo_famcod_Selectedvalue_set = cgiGet( "COMBO_FAMCOD_Selectedvalue_set");
               Combo_famcod_Selectedvalue_get = cgiGet( "COMBO_FAMCOD_Selectedvalue_get");
               Combo_famcod_Selectedtext_set = cgiGet( "COMBO_FAMCOD_Selectedtext_set");
               Combo_famcod_Selectedtext_get = cgiGet( "COMBO_FAMCOD_Selectedtext_get");
               Combo_famcod_Gamoauthtoken = cgiGet( "COMBO_FAMCOD_Gamoauthtoken");
               Combo_famcod_Ddointernalname = cgiGet( "COMBO_FAMCOD_Ddointernalname");
               Combo_famcod_Titlecontrolalign = cgiGet( "COMBO_FAMCOD_Titlecontrolalign");
               Combo_famcod_Dropdownoptionstype = cgiGet( "COMBO_FAMCOD_Dropdownoptionstype");
               Combo_famcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Enabled"));
               Combo_famcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Visible"));
               Combo_famcod_Titlecontrolidtoreplace = cgiGet( "COMBO_FAMCOD_Titlecontrolidtoreplace");
               Combo_famcod_Datalisttype = cgiGet( "COMBO_FAMCOD_Datalisttype");
               Combo_famcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Allowmultipleselection"));
               Combo_famcod_Datalistfixedvalues = cgiGet( "COMBO_FAMCOD_Datalistfixedvalues");
               Combo_famcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Isgriditem"));
               Combo_famcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Hasdescription"));
               Combo_famcod_Datalistproc = cgiGet( "COMBO_FAMCOD_Datalistproc");
               Combo_famcod_Datalistprocparametersprefix = cgiGet( "COMBO_FAMCOD_Datalistprocparametersprefix");
               Combo_famcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_FAMCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_famcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Includeonlyselectedoption"));
               Combo_famcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Includeselectalloption"));
               Combo_famcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Emptyitem"));
               Combo_famcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_FAMCOD_Includeaddnewoption"));
               Combo_famcod_Htmltemplate = cgiGet( "COMBO_FAMCOD_Htmltemplate");
               Combo_famcod_Multiplevaluestype = cgiGet( "COMBO_FAMCOD_Multiplevaluestype");
               Combo_famcod_Loadingdata = cgiGet( "COMBO_FAMCOD_Loadingdata");
               Combo_famcod_Noresultsfound = cgiGet( "COMBO_FAMCOD_Noresultsfound");
               Combo_famcod_Emptyitemtext = cgiGet( "COMBO_FAMCOD_Emptyitemtext");
               Combo_famcod_Onlyselectedvalues = cgiGet( "COMBO_FAMCOD_Onlyselectedvalues");
               Combo_famcod_Selectalltext = cgiGet( "COMBO_FAMCOD_Selectalltext");
               Combo_famcod_Multiplevaluesseparator = cgiGet( "COMBO_FAMCOD_Multiplevaluesseparator");
               Combo_famcod_Addnewoptiontext = cgiGet( "COMBO_FAMCOD_Addnewoptiontext");
               Combo_famcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_FAMCOD_Gxcontroltype"), ".", ","));
               Combo_unicod_Objectcall = cgiGet( "COMBO_UNICOD_Objectcall");
               Combo_unicod_Class = cgiGet( "COMBO_UNICOD_Class");
               Combo_unicod_Icontype = cgiGet( "COMBO_UNICOD_Icontype");
               Combo_unicod_Icon = cgiGet( "COMBO_UNICOD_Icon");
               Combo_unicod_Caption = cgiGet( "COMBO_UNICOD_Caption");
               Combo_unicod_Tooltip = cgiGet( "COMBO_UNICOD_Tooltip");
               Combo_unicod_Cls = cgiGet( "COMBO_UNICOD_Cls");
               Combo_unicod_Selectedvalue_set = cgiGet( "COMBO_UNICOD_Selectedvalue_set");
               Combo_unicod_Selectedvalue_get = cgiGet( "COMBO_UNICOD_Selectedvalue_get");
               Combo_unicod_Selectedtext_set = cgiGet( "COMBO_UNICOD_Selectedtext_set");
               Combo_unicod_Selectedtext_get = cgiGet( "COMBO_UNICOD_Selectedtext_get");
               Combo_unicod_Gamoauthtoken = cgiGet( "COMBO_UNICOD_Gamoauthtoken");
               Combo_unicod_Ddointernalname = cgiGet( "COMBO_UNICOD_Ddointernalname");
               Combo_unicod_Titlecontrolalign = cgiGet( "COMBO_UNICOD_Titlecontrolalign");
               Combo_unicod_Dropdownoptionstype = cgiGet( "COMBO_UNICOD_Dropdownoptionstype");
               Combo_unicod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Enabled"));
               Combo_unicod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Visible"));
               Combo_unicod_Titlecontrolidtoreplace = cgiGet( "COMBO_UNICOD_Titlecontrolidtoreplace");
               Combo_unicod_Datalisttype = cgiGet( "COMBO_UNICOD_Datalisttype");
               Combo_unicod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Allowmultipleselection"));
               Combo_unicod_Datalistfixedvalues = cgiGet( "COMBO_UNICOD_Datalistfixedvalues");
               Combo_unicod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Isgriditem"));
               Combo_unicod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Hasdescription"));
               Combo_unicod_Datalistproc = cgiGet( "COMBO_UNICOD_Datalistproc");
               Combo_unicod_Datalistprocparametersprefix = cgiGet( "COMBO_UNICOD_Datalistprocparametersprefix");
               Combo_unicod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_UNICOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_unicod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Includeonlyselectedoption"));
               Combo_unicod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Includeselectalloption"));
               Combo_unicod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Emptyitem"));
               Combo_unicod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_UNICOD_Includeaddnewoption"));
               Combo_unicod_Htmltemplate = cgiGet( "COMBO_UNICOD_Htmltemplate");
               Combo_unicod_Multiplevaluestype = cgiGet( "COMBO_UNICOD_Multiplevaluestype");
               Combo_unicod_Loadingdata = cgiGet( "COMBO_UNICOD_Loadingdata");
               Combo_unicod_Noresultsfound = cgiGet( "COMBO_UNICOD_Noresultsfound");
               Combo_unicod_Emptyitemtext = cgiGet( "COMBO_UNICOD_Emptyitemtext");
               Combo_unicod_Onlyselectedvalues = cgiGet( "COMBO_UNICOD_Onlyselectedvalues");
               Combo_unicod_Selectalltext = cgiGet( "COMBO_UNICOD_Selectalltext");
               Combo_unicod_Multiplevaluesseparator = cgiGet( "COMBO_UNICOD_Multiplevaluesseparator");
               Combo_unicod_Addnewoptiontext = cgiGet( "COMBO_UNICOD_Addnewoptiontext");
               Combo_unicod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_UNICOD_Gxcontroltype"), ".", ","));
               Combo_prodcuentav_Objectcall = cgiGet( "COMBO_PRODCUENTAV_Objectcall");
               Combo_prodcuentav_Class = cgiGet( "COMBO_PRODCUENTAV_Class");
               Combo_prodcuentav_Icontype = cgiGet( "COMBO_PRODCUENTAV_Icontype");
               Combo_prodcuentav_Icon = cgiGet( "COMBO_PRODCUENTAV_Icon");
               Combo_prodcuentav_Caption = cgiGet( "COMBO_PRODCUENTAV_Caption");
               Combo_prodcuentav_Tooltip = cgiGet( "COMBO_PRODCUENTAV_Tooltip");
               Combo_prodcuentav_Cls = cgiGet( "COMBO_PRODCUENTAV_Cls");
               Combo_prodcuentav_Selectedvalue_set = cgiGet( "COMBO_PRODCUENTAV_Selectedvalue_set");
               Combo_prodcuentav_Selectedvalue_get = cgiGet( "COMBO_PRODCUENTAV_Selectedvalue_get");
               Combo_prodcuentav_Selectedtext_set = cgiGet( "COMBO_PRODCUENTAV_Selectedtext_set");
               Combo_prodcuentav_Selectedtext_get = cgiGet( "COMBO_PRODCUENTAV_Selectedtext_get");
               Combo_prodcuentav_Gamoauthtoken = cgiGet( "COMBO_PRODCUENTAV_Gamoauthtoken");
               Combo_prodcuentav_Ddointernalname = cgiGet( "COMBO_PRODCUENTAV_Ddointernalname");
               Combo_prodcuentav_Titlecontrolalign = cgiGet( "COMBO_PRODCUENTAV_Titlecontrolalign");
               Combo_prodcuentav_Dropdownoptionstype = cgiGet( "COMBO_PRODCUENTAV_Dropdownoptionstype");
               Combo_prodcuentav_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Enabled"));
               Combo_prodcuentav_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Visible"));
               Combo_prodcuentav_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODCUENTAV_Titlecontrolidtoreplace");
               Combo_prodcuentav_Datalisttype = cgiGet( "COMBO_PRODCUENTAV_Datalisttype");
               Combo_prodcuentav_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Allowmultipleselection"));
               Combo_prodcuentav_Datalistfixedvalues = cgiGet( "COMBO_PRODCUENTAV_Datalistfixedvalues");
               Combo_prodcuentav_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Isgriditem"));
               Combo_prodcuentav_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Hasdescription"));
               Combo_prodcuentav_Datalistproc = cgiGet( "COMBO_PRODCUENTAV_Datalistproc");
               Combo_prodcuentav_Datalistprocparametersprefix = cgiGet( "COMBO_PRODCUENTAV_Datalistprocparametersprefix");
               Combo_prodcuentav_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PRODCUENTAV_Datalistupdateminimumcharacters"), ".", ","));
               Combo_prodcuentav_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Includeonlyselectedoption"));
               Combo_prodcuentav_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Includeselectalloption"));
               Combo_prodcuentav_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Emptyitem"));
               Combo_prodcuentav_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAV_Includeaddnewoption"));
               Combo_prodcuentav_Htmltemplate = cgiGet( "COMBO_PRODCUENTAV_Htmltemplate");
               Combo_prodcuentav_Multiplevaluestype = cgiGet( "COMBO_PRODCUENTAV_Multiplevaluestype");
               Combo_prodcuentav_Loadingdata = cgiGet( "COMBO_PRODCUENTAV_Loadingdata");
               Combo_prodcuentav_Noresultsfound = cgiGet( "COMBO_PRODCUENTAV_Noresultsfound");
               Combo_prodcuentav_Emptyitemtext = cgiGet( "COMBO_PRODCUENTAV_Emptyitemtext");
               Combo_prodcuentav_Onlyselectedvalues = cgiGet( "COMBO_PRODCUENTAV_Onlyselectedvalues");
               Combo_prodcuentav_Selectalltext = cgiGet( "COMBO_PRODCUENTAV_Selectalltext");
               Combo_prodcuentav_Multiplevaluesseparator = cgiGet( "COMBO_PRODCUENTAV_Multiplevaluesseparator");
               Combo_prodcuentav_Addnewoptiontext = cgiGet( "COMBO_PRODCUENTAV_Addnewoptiontext");
               Combo_prodcuentav_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PRODCUENTAV_Gxcontroltype"), ".", ","));
               Combo_prodcuentac_Objectcall = cgiGet( "COMBO_PRODCUENTAC_Objectcall");
               Combo_prodcuentac_Class = cgiGet( "COMBO_PRODCUENTAC_Class");
               Combo_prodcuentac_Icontype = cgiGet( "COMBO_PRODCUENTAC_Icontype");
               Combo_prodcuentac_Icon = cgiGet( "COMBO_PRODCUENTAC_Icon");
               Combo_prodcuentac_Caption = cgiGet( "COMBO_PRODCUENTAC_Caption");
               Combo_prodcuentac_Tooltip = cgiGet( "COMBO_PRODCUENTAC_Tooltip");
               Combo_prodcuentac_Cls = cgiGet( "COMBO_PRODCUENTAC_Cls");
               Combo_prodcuentac_Selectedvalue_set = cgiGet( "COMBO_PRODCUENTAC_Selectedvalue_set");
               Combo_prodcuentac_Selectedvalue_get = cgiGet( "COMBO_PRODCUENTAC_Selectedvalue_get");
               Combo_prodcuentac_Selectedtext_set = cgiGet( "COMBO_PRODCUENTAC_Selectedtext_set");
               Combo_prodcuentac_Selectedtext_get = cgiGet( "COMBO_PRODCUENTAC_Selectedtext_get");
               Combo_prodcuentac_Gamoauthtoken = cgiGet( "COMBO_PRODCUENTAC_Gamoauthtoken");
               Combo_prodcuentac_Ddointernalname = cgiGet( "COMBO_PRODCUENTAC_Ddointernalname");
               Combo_prodcuentac_Titlecontrolalign = cgiGet( "COMBO_PRODCUENTAC_Titlecontrolalign");
               Combo_prodcuentac_Dropdownoptionstype = cgiGet( "COMBO_PRODCUENTAC_Dropdownoptionstype");
               Combo_prodcuentac_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Enabled"));
               Combo_prodcuentac_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Visible"));
               Combo_prodcuentac_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODCUENTAC_Titlecontrolidtoreplace");
               Combo_prodcuentac_Datalisttype = cgiGet( "COMBO_PRODCUENTAC_Datalisttype");
               Combo_prodcuentac_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Allowmultipleselection"));
               Combo_prodcuentac_Datalistfixedvalues = cgiGet( "COMBO_PRODCUENTAC_Datalistfixedvalues");
               Combo_prodcuentac_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Isgriditem"));
               Combo_prodcuentac_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Hasdescription"));
               Combo_prodcuentac_Datalistproc = cgiGet( "COMBO_PRODCUENTAC_Datalistproc");
               Combo_prodcuentac_Datalistprocparametersprefix = cgiGet( "COMBO_PRODCUENTAC_Datalistprocparametersprefix");
               Combo_prodcuentac_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PRODCUENTAC_Datalistupdateminimumcharacters"), ".", ","));
               Combo_prodcuentac_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Includeonlyselectedoption"));
               Combo_prodcuentac_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Includeselectalloption"));
               Combo_prodcuentac_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Emptyitem"));
               Combo_prodcuentac_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAC_Includeaddnewoption"));
               Combo_prodcuentac_Htmltemplate = cgiGet( "COMBO_PRODCUENTAC_Htmltemplate");
               Combo_prodcuentac_Multiplevaluestype = cgiGet( "COMBO_PRODCUENTAC_Multiplevaluestype");
               Combo_prodcuentac_Loadingdata = cgiGet( "COMBO_PRODCUENTAC_Loadingdata");
               Combo_prodcuentac_Noresultsfound = cgiGet( "COMBO_PRODCUENTAC_Noresultsfound");
               Combo_prodcuentac_Emptyitemtext = cgiGet( "COMBO_PRODCUENTAC_Emptyitemtext");
               Combo_prodcuentac_Onlyselectedvalues = cgiGet( "COMBO_PRODCUENTAC_Onlyselectedvalues");
               Combo_prodcuentac_Selectalltext = cgiGet( "COMBO_PRODCUENTAC_Selectalltext");
               Combo_prodcuentac_Multiplevaluesseparator = cgiGet( "COMBO_PRODCUENTAC_Multiplevaluesseparator");
               Combo_prodcuentac_Addnewoptiontext = cgiGet( "COMBO_PRODCUENTAC_Addnewoptiontext");
               Combo_prodcuentac_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PRODCUENTAC_Gxcontroltype"), ".", ","));
               Combo_prodcuentaa_Objectcall = cgiGet( "COMBO_PRODCUENTAA_Objectcall");
               Combo_prodcuentaa_Class = cgiGet( "COMBO_PRODCUENTAA_Class");
               Combo_prodcuentaa_Icontype = cgiGet( "COMBO_PRODCUENTAA_Icontype");
               Combo_prodcuentaa_Icon = cgiGet( "COMBO_PRODCUENTAA_Icon");
               Combo_prodcuentaa_Caption = cgiGet( "COMBO_PRODCUENTAA_Caption");
               Combo_prodcuentaa_Tooltip = cgiGet( "COMBO_PRODCUENTAA_Tooltip");
               Combo_prodcuentaa_Cls = cgiGet( "COMBO_PRODCUENTAA_Cls");
               Combo_prodcuentaa_Selectedvalue_set = cgiGet( "COMBO_PRODCUENTAA_Selectedvalue_set");
               Combo_prodcuentaa_Selectedvalue_get = cgiGet( "COMBO_PRODCUENTAA_Selectedvalue_get");
               Combo_prodcuentaa_Selectedtext_set = cgiGet( "COMBO_PRODCUENTAA_Selectedtext_set");
               Combo_prodcuentaa_Selectedtext_get = cgiGet( "COMBO_PRODCUENTAA_Selectedtext_get");
               Combo_prodcuentaa_Gamoauthtoken = cgiGet( "COMBO_PRODCUENTAA_Gamoauthtoken");
               Combo_prodcuentaa_Ddointernalname = cgiGet( "COMBO_PRODCUENTAA_Ddointernalname");
               Combo_prodcuentaa_Titlecontrolalign = cgiGet( "COMBO_PRODCUENTAA_Titlecontrolalign");
               Combo_prodcuentaa_Dropdownoptionstype = cgiGet( "COMBO_PRODCUENTAA_Dropdownoptionstype");
               Combo_prodcuentaa_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Enabled"));
               Combo_prodcuentaa_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Visible"));
               Combo_prodcuentaa_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODCUENTAA_Titlecontrolidtoreplace");
               Combo_prodcuentaa_Datalisttype = cgiGet( "COMBO_PRODCUENTAA_Datalisttype");
               Combo_prodcuentaa_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Allowmultipleselection"));
               Combo_prodcuentaa_Datalistfixedvalues = cgiGet( "COMBO_PRODCUENTAA_Datalistfixedvalues");
               Combo_prodcuentaa_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Isgriditem"));
               Combo_prodcuentaa_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Hasdescription"));
               Combo_prodcuentaa_Datalistproc = cgiGet( "COMBO_PRODCUENTAA_Datalistproc");
               Combo_prodcuentaa_Datalistprocparametersprefix = cgiGet( "COMBO_PRODCUENTAA_Datalistprocparametersprefix");
               Combo_prodcuentaa_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PRODCUENTAA_Datalistupdateminimumcharacters"), ".", ","));
               Combo_prodcuentaa_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Includeonlyselectedoption"));
               Combo_prodcuentaa_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Includeselectalloption"));
               Combo_prodcuentaa_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Emptyitem"));
               Combo_prodcuentaa_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODCUENTAA_Includeaddnewoption"));
               Combo_prodcuentaa_Htmltemplate = cgiGet( "COMBO_PRODCUENTAA_Htmltemplate");
               Combo_prodcuentaa_Multiplevaluestype = cgiGet( "COMBO_PRODCUENTAA_Multiplevaluestype");
               Combo_prodcuentaa_Loadingdata = cgiGet( "COMBO_PRODCUENTAA_Loadingdata");
               Combo_prodcuentaa_Noresultsfound = cgiGet( "COMBO_PRODCUENTAA_Noresultsfound");
               Combo_prodcuentaa_Emptyitemtext = cgiGet( "COMBO_PRODCUENTAA_Emptyitemtext");
               Combo_prodcuentaa_Onlyselectedvalues = cgiGet( "COMBO_PRODCUENTAA_Onlyselectedvalues");
               Combo_prodcuentaa_Selectalltext = cgiGet( "COMBO_PRODCUENTAA_Selectalltext");
               Combo_prodcuentaa_Multiplevaluesseparator = cgiGet( "COMBO_PRODCUENTAA_Multiplevaluesseparator");
               Combo_prodcuentaa_Addnewoptiontext = cgiGet( "COMBO_PRODCUENTAA_Addnewoptiontext");
               Combo_prodcuentaa_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PRODCUENTAA_Gxcontroltype"), ".", ","));
               Combo_cbsucod_Objectcall = cgiGet( "COMBO_CBSUCOD_Objectcall");
               Combo_cbsucod_Class = cgiGet( "COMBO_CBSUCOD_Class");
               Combo_cbsucod_Icontype = cgiGet( "COMBO_CBSUCOD_Icontype");
               Combo_cbsucod_Icon = cgiGet( "COMBO_CBSUCOD_Icon");
               Combo_cbsucod_Caption = cgiGet( "COMBO_CBSUCOD_Caption");
               Combo_cbsucod_Tooltip = cgiGet( "COMBO_CBSUCOD_Tooltip");
               Combo_cbsucod_Cls = cgiGet( "COMBO_CBSUCOD_Cls");
               Combo_cbsucod_Selectedvalue_set = cgiGet( "COMBO_CBSUCOD_Selectedvalue_set");
               Combo_cbsucod_Selectedvalue_get = cgiGet( "COMBO_CBSUCOD_Selectedvalue_get");
               Combo_cbsucod_Selectedtext_set = cgiGet( "COMBO_CBSUCOD_Selectedtext_set");
               Combo_cbsucod_Selectedtext_get = cgiGet( "COMBO_CBSUCOD_Selectedtext_get");
               Combo_cbsucod_Gamoauthtoken = cgiGet( "COMBO_CBSUCOD_Gamoauthtoken");
               Combo_cbsucod_Ddointernalname = cgiGet( "COMBO_CBSUCOD_Ddointernalname");
               Combo_cbsucod_Titlecontrolalign = cgiGet( "COMBO_CBSUCOD_Titlecontrolalign");
               Combo_cbsucod_Dropdownoptionstype = cgiGet( "COMBO_CBSUCOD_Dropdownoptionstype");
               Combo_cbsucod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Enabled"));
               Combo_cbsucod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Visible"));
               Combo_cbsucod_Titlecontrolidtoreplace = cgiGet( "COMBO_CBSUCOD_Titlecontrolidtoreplace");
               Combo_cbsucod_Datalisttype = cgiGet( "COMBO_CBSUCOD_Datalisttype");
               Combo_cbsucod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Allowmultipleselection"));
               Combo_cbsucod_Datalistfixedvalues = cgiGet( "COMBO_CBSUCOD_Datalistfixedvalues");
               Combo_cbsucod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Isgriditem"));
               Combo_cbsucod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Hasdescription"));
               Combo_cbsucod_Datalistproc = cgiGet( "COMBO_CBSUCOD_Datalistproc");
               Combo_cbsucod_Datalistprocparametersprefix = cgiGet( "COMBO_CBSUCOD_Datalistprocparametersprefix");
               Combo_cbsucod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBSUCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cbsucod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Includeonlyselectedoption"));
               Combo_cbsucod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Includeselectalloption"));
               Combo_cbsucod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Emptyitem"));
               Combo_cbsucod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CBSUCOD_Includeaddnewoption"));
               Combo_cbsucod_Htmltemplate = cgiGet( "COMBO_CBSUCOD_Htmltemplate");
               Combo_cbsucod_Multiplevaluestype = cgiGet( "COMBO_CBSUCOD_Multiplevaluestype");
               Combo_cbsucod_Loadingdata = cgiGet( "COMBO_CBSUCOD_Loadingdata");
               Combo_cbsucod_Noresultsfound = cgiGet( "COMBO_CBSUCOD_Noresultsfound");
               Combo_cbsucod_Emptyitemtext = cgiGet( "COMBO_CBSUCOD_Emptyitemtext");
               Combo_cbsucod_Onlyselectedvalues = cgiGet( "COMBO_CBSUCOD_Onlyselectedvalues");
               Combo_cbsucod_Selectalltext = cgiGet( "COMBO_CBSUCOD_Selectalltext");
               Combo_cbsucod_Multiplevaluesseparator = cgiGet( "COMBO_CBSUCOD_Multiplevaluesseparator");
               Combo_cbsucod_Addnewoptiontext = cgiGet( "COMBO_CBSUCOD_Addnewoptiontext");
               Combo_cbsucod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CBSUCOD_Gxcontroltype"), ".", ","));
               Combo_cdetcod_Objectcall = cgiGet( "COMBO_CDETCOD_Objectcall");
               Combo_cdetcod_Class = cgiGet( "COMBO_CDETCOD_Class");
               Combo_cdetcod_Icontype = cgiGet( "COMBO_CDETCOD_Icontype");
               Combo_cdetcod_Icon = cgiGet( "COMBO_CDETCOD_Icon");
               Combo_cdetcod_Caption = cgiGet( "COMBO_CDETCOD_Caption");
               Combo_cdetcod_Tooltip = cgiGet( "COMBO_CDETCOD_Tooltip");
               Combo_cdetcod_Cls = cgiGet( "COMBO_CDETCOD_Cls");
               Combo_cdetcod_Selectedvalue_set = cgiGet( "COMBO_CDETCOD_Selectedvalue_set");
               Combo_cdetcod_Selectedvalue_get = cgiGet( "COMBO_CDETCOD_Selectedvalue_get");
               Combo_cdetcod_Selectedtext_set = cgiGet( "COMBO_CDETCOD_Selectedtext_set");
               Combo_cdetcod_Selectedtext_get = cgiGet( "COMBO_CDETCOD_Selectedtext_get");
               Combo_cdetcod_Gamoauthtoken = cgiGet( "COMBO_CDETCOD_Gamoauthtoken");
               Combo_cdetcod_Ddointernalname = cgiGet( "COMBO_CDETCOD_Ddointernalname");
               Combo_cdetcod_Titlecontrolalign = cgiGet( "COMBO_CDETCOD_Titlecontrolalign");
               Combo_cdetcod_Dropdownoptionstype = cgiGet( "COMBO_CDETCOD_Dropdownoptionstype");
               Combo_cdetcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Enabled"));
               Combo_cdetcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Visible"));
               Combo_cdetcod_Titlecontrolidtoreplace = cgiGet( "COMBO_CDETCOD_Titlecontrolidtoreplace");
               Combo_cdetcod_Datalisttype = cgiGet( "COMBO_CDETCOD_Datalisttype");
               Combo_cdetcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Allowmultipleselection"));
               Combo_cdetcod_Datalistfixedvalues = cgiGet( "COMBO_CDETCOD_Datalistfixedvalues");
               Combo_cdetcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Isgriditem"));
               Combo_cdetcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Hasdescription"));
               Combo_cdetcod_Datalistproc = cgiGet( "COMBO_CDETCOD_Datalistproc");
               Combo_cdetcod_Datalistprocparametersprefix = cgiGet( "COMBO_CDETCOD_Datalistprocparametersprefix");
               Combo_cdetcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CDETCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cdetcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Includeonlyselectedoption"));
               Combo_cdetcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Includeselectalloption"));
               Combo_cdetcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Emptyitem"));
               Combo_cdetcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CDETCOD_Includeaddnewoption"));
               Combo_cdetcod_Htmltemplate = cgiGet( "COMBO_CDETCOD_Htmltemplate");
               Combo_cdetcod_Multiplevaluestype = cgiGet( "COMBO_CDETCOD_Multiplevaluestype");
               Combo_cdetcod_Loadingdata = cgiGet( "COMBO_CDETCOD_Loadingdata");
               Combo_cdetcod_Noresultsfound = cgiGet( "COMBO_CDETCOD_Noresultsfound");
               Combo_cdetcod_Emptyitemtext = cgiGet( "COMBO_CDETCOD_Emptyitemtext");
               Combo_cdetcod_Onlyselectedvalues = cgiGet( "COMBO_CDETCOD_Onlyselectedvalues");
               Combo_cdetcod_Selectalltext = cgiGet( "COMBO_CDETCOD_Selectalltext");
               Combo_cdetcod_Multiplevaluesseparator = cgiGet( "COMBO_CDETCOD_Multiplevaluesseparator");
               Combo_cdetcod_Addnewoptiontext = cgiGet( "COMBO_CDETCOD_Addnewoptiontext");
               Combo_cdetcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CDETCOD_Gxcontroltype"), ".", ","));
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
               A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A52LinCod = 0;
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               }
               else
               {
                  A52LinCod = (int)(context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ","));
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               }
               A55ProdDsc = cgiGet( edtProdDsc_Internalname);
               AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUBLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A51SublCod = 0;
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
               else
               {
                  A51SublCod = (int)(context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ","));
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
               n51SublCod = ((0==A51SublCod) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FAMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50FamCod = 0;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               else
               {
                  A50FamCod = (int)(context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ","));
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               n50FamCod = ((0==A50FamCod) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNICOD");
                  AnyError = 1;
                  GX_FocusControl = edtUniCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A49UniCod = 0;
                  AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               }
               else
               {
                  A49UniCod = (int)(context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ","));
                  AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODVTA");
                  AnyError = 1;
                  GX_FocusControl = chkProdVta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1724ProdVta = 0;
                  AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
               }
               else
               {
                  A1724ProdVta = (short)(((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCMP");
                  AnyError = 1;
                  GX_FocusControl = chkProdCmp_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1679ProdCmp = 0;
                  AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
               }
               else
               {
                  A1679ProdCmp = (short)(((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",") > 999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODPESO");
                  AnyError = 1;
                  GX_FocusControl = edtProdPeso_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1702ProdPeso = 0;
                  AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
               }
               else
               {
                  A1702ProdPeso = context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",");
                  AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",") > 999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODVOLUMEN");
                  AnyError = 1;
                  GX_FocusControl = edtProdVolumen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1723ProdVolumen = 0;
                  AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
               }
               else
               {
                  A1723ProdVolumen = context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",");
                  AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",") > 9999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODSTKMAX");
                  AnyError = 1;
                  GX_FocusControl = edtProdStkMax_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1716ProdStkMax = 0;
                  AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
               }
               else
               {
                  A1716ProdStkMax = context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",");
                  AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",") > 9999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODSTKMIN");
                  AnyError = 1;
                  GX_FocusControl = edtProdStkMin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1717ProdStkMin = 0;
                  AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
               }
               else
               {
                  A1717ProdStkMin = context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",");
                  AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
               }
               A1695ProdFoto = cgiGet( imgProdFoto_Internalname);
               n1695ProdFoto = false;
               AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
               n1695ProdFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               A1705ProdRef1 = cgiGet( edtProdRef1_Internalname);
               AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
               A1707ProdRef2 = cgiGet( edtProdRef2_Internalname);
               AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
               A1708ProdRef3 = cgiGet( edtProdRef3_Internalname);
               AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
               A1709ProdRef4 = cgiGet( edtProdRef4_Internalname);
               AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
               A1710ProdRef5 = cgiGet( edtProdRef5_Internalname);
               AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
               A1711ProdRef6 = cgiGet( edtProdRef6_Internalname);
               AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
               A1712ProdRef7 = cgiGet( edtProdRef7_Internalname);
               AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
               A1713ProdRef8 = cgiGet( edtProdRef8_Internalname);
               AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
               A1714ProdRef9 = cgiGet( edtProdRef9_Internalname);
               AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
               A1706ProdRef10 = cgiGet( edtProdRef10_Internalname);
               AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
               cmbProdSts.CurrentValue = cgiGet( cmbProdSts_Internalname);
               A1718ProdSts = (short)(NumberUtil.Val( cgiGet( cmbProdSts_Internalname), "."));
               AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",") < -99999999999.99999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",") > 999999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCOSTO");
                  AnyError = 1;
                  GX_FocusControl = edtProdCosto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1681ProdCosto = 0;
                  AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
               }
               else
               {
                  A1681ProdCosto = context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",");
                  AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
               }
               if ( context.localUtil.VCDate( cgiGet( edtProdCostoFec_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Ult. Costo"}), 1, "PRODCOSTOFEC");
                  AnyError = 1;
                  GX_FocusControl = edtProdCostoFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1683ProdCostoFec = DateTime.MinValue;
                  AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
               }
               else
               {
                  A1683ProdCostoFec = context.localUtil.CToD( cgiGet( edtProdCostoFec_Internalname), 2);
                  AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdCostoD_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdCostoD_Internalname), ".", ",") > 999999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCOSTOD");
                  AnyError = 1;
                  GX_FocusControl = edtProdCostoD_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1682ProdCostoD = 0;
                  AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
               }
               else
               {
                  A1682ProdCostoD = context.localUtil.CToN( cgiGet( edtProdCostoD_Internalname), ".", ",");
                  AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdIna_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdIna_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODINA");
                  AnyError = 1;
                  GX_FocusControl = edtProdIna_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1698ProdIna = 0;
                  AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
               }
               else
               {
                  A1698ProdIna = (short)(context.localUtil.CToN( cgiGet( edtProdIna_Internalname), ".", ","));
                  AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",") > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODPORSEL");
                  AnyError = 1;
                  GX_FocusControl = edtProdPorSel_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1703ProdPorSel = 0;
                  AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
               }
               else
               {
                  A1703ProdPorSel = context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",");
                  AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdImpSel_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdImpSel_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODIMPSEL");
                  AnyError = 1;
                  GX_FocusControl = edtProdImpSel_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1697ProdImpSel = 0;
                  AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrimStr( A1697ProdImpSel, 15, 2));
               }
               else
               {
                  A1697ProdImpSel = context.localUtil.CToN( cgiGet( edtProdImpSel_Internalname), ".", ",");
                  AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrimStr( A1697ProdImpSel, 15, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdAdValor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdAdValor_Internalname), ".", ",") > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODADVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtProdAdValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1672ProdAdValor = 0;
                  AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
               }
               else
               {
                  A1672ProdAdValor = context.localUtil.CToN( cgiGet( edtProdAdValor_Internalname), ".", ",");
                  AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
               }
               A1715ProdReferencias = cgiGet( edtProdReferencias_Internalname);
               AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdFrecuente_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdFrecuente_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODFRECUENTE");
                  AnyError = 1;
                  GX_FocusControl = edtProdFrecuente_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1696ProdFrecuente = 0;
                  AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
               }
               else
               {
                  A1696ProdFrecuente = (short)(context.localUtil.CToN( cgiGet( edtProdFrecuente_Internalname), ".", ","));
                  AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
               }
               A48ProdCuentaV = cgiGet( edtProdCuentaV_Internalname);
               n48ProdCuentaV = false;
               AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
               n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
               A1686ProdCuentaVDsc = cgiGet( edtProdCuentaVDsc_Internalname);
               AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
               A53ProdCuentaC = cgiGet( edtProdCuentaC_Internalname);
               n53ProdCuentaC = false;
               AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
               n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
               A1685ProdCuentaCDsc = cgiGet( edtProdCuentaCDsc_Internalname);
               AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
               A54ProdCuentaA = cgiGet( edtProdCuentaA_Internalname);
               n54ProdCuentaA = false;
               AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
               n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
               A1684ProdCuentaADsc = cgiGet( edtProdCuentaADsc_Internalname);
               AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
               A1721ProdUsuCod = cgiGet( edtProdUsuCod_Internalname);
               AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
               if ( context.localUtil.VCDateTime( cgiGet( edtProdUsuFec_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "PRODUSUFEC");
                  AnyError = 1;
                  GX_FocusControl = edtProdUsuFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1722ProdUsuFec = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1722ProdUsuFec = context.localUtil.CToT( cgiGet( edtProdUsuFec_Internalname));
                  AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdAfec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdAfec_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODAFEC");
                  AnyError = 1;
                  GX_FocusControl = edtProdAfec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1673ProdAfec = 0;
                  AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
               }
               else
               {
                  A1673ProdAfec = (short)(context.localUtil.CToN( cgiGet( edtProdAfec_Internalname), ".", ","));
                  AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
               }
               A1701ProdObs = cgiGet( edtProdObs_Internalname);
               AssignAttri("", false, "A1701ProdObs", A1701ProdObs);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdCanLote_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdCanLote_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCANLOTE");
                  AnyError = 1;
                  GX_FocusControl = edtProdCanLote_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1675ProdCanLote = 0;
                  AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrimStr( A1675ProdCanLote, 15, 2));
               }
               else
               {
                  A1675ProdCanLote = context.localUtil.CToN( cgiGet( edtProdCanLote_Internalname), ".", ",");
                  AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrimStr( A1675ProdCanLote, 15, 2));
               }
               A1674ProdBarra = cgiGet( edtProdBarra_Internalname);
               AssignAttri("", false, "A1674ProdBarra", A1674ProdBarra);
               A1689ProdExportacion = cgiGet( edtProdExportacion_Internalname);
               AssignAttri("", false, "A1689ProdExportacion", A1689ProdExportacion);
               A47CBSuCod = cgiGet( edtCBSuCod_Internalname);
               n47CBSuCod = false;
               AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
               n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdAfecICBPER_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdAfecICBPER_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODAFECICBPER");
                  AnyError = 1;
                  GX_FocusControl = edtProdAfecICBPER_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A906ProdAfecICBPER = 0;
                  AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
               }
               else
               {
                  A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( edtProdAfecICBPER_Internalname), ".", ","));
                  AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdValICBPER_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdValICBPER_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODVALICBPER");
                  AnyError = 1;
                  GX_FocusControl = edtProdValICBPER_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A907ProdValICBPER = 0;
                  AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
               }
               else
               {
                  A907ProdValICBPER = context.localUtil.CToN( cgiGet( edtProdValICBPER_Internalname), ".", ",");
                  AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdValICBPERD_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdValICBPERD_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODVALICBPERD");
                  AnyError = 1;
                  GX_FocusControl = edtProdValICBPERD_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A908ProdValICBPERD = 0;
                  AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
               }
               else
               {
                  A908ProdValICBPERD = context.localUtil.CToN( cgiGet( edtProdValICBPERD_Internalname), ".", ",");
                  AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtcDetCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtcDetCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CDETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtcDetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A46cDetCod = 0;
                  n46cDetCod = false;
                  AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
               }
               else
               {
                  A46cDetCod = (int)(context.localUtil.CToN( cgiGet( edtcDetCod_Internalname), ".", ","));
                  n46cDetCod = false;
                  AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
               }
               n46cDetCod = ((0==A46cDetCod) ? true : false);
               A1153LinDsc = cgiGet( edtLinDsc_Internalname);
               AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
               AV26ComboLinCod = (int)(context.localUtil.CToN( cgiGet( edtavCombolincod_Internalname), ".", ","));
               AssignAttri("", false, "AV26ComboLinCod", StringUtil.LTrimStr( (decimal)(AV26ComboLinCod), 6, 0));
               AV28ComboSublCod = (int)(context.localUtil.CToN( cgiGet( edtavCombosublcod_Internalname), ".", ","));
               AssignAttri("", false, "AV28ComboSublCod", StringUtil.LTrimStr( (decimal)(AV28ComboSublCod), 6, 0));
               AV30ComboFamCod = (int)(context.localUtil.CToN( cgiGet( edtavCombofamcod_Internalname), ".", ","));
               AssignAttri("", false, "AV30ComboFamCod", StringUtil.LTrimStr( (decimal)(AV30ComboFamCod), 6, 0));
               AV32ComboUniCod = (int)(context.localUtil.CToN( cgiGet( edtavCombounicod_Internalname), ".", ","));
               AssignAttri("", false, "AV32ComboUniCod", StringUtil.LTrimStr( (decimal)(AV32ComboUniCod), 6, 0));
               AV34ComboProdCuentaV = cgiGet( edtavComboprodcuentav_Internalname);
               AssignAttri("", false, "AV34ComboProdCuentaV", AV34ComboProdCuentaV);
               AV37ComboProdCuentaC = cgiGet( edtavComboprodcuentac_Internalname);
               AssignAttri("", false, "AV37ComboProdCuentaC", AV37ComboProdCuentaC);
               AV39ComboProdCuentaA = cgiGet( edtavComboprodcuentaa_Internalname);
               AssignAttri("", false, "AV39ComboProdCuentaA", AV39ComboProdCuentaA);
               AV41ComboCBSuCod = cgiGet( edtavCombocbsucod_Internalname);
               AssignAttri("", false, "AV41ComboCBSuCod", AV41ComboCBSuCod);
               AV43CombocDetCod = (int)(context.localUtil.CToN( cgiGet( edtavCombocdetcod_Internalname), ".", ","));
               AssignAttri("", false, "AV43CombocDetCod", StringUtil.LTrimStr( (decimal)(AV43CombocDetCod), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProdFoto_Internalname, ref  A1695ProdFoto, ref  A40000ProdFoto_GXI);
               n40000ProdFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               n1695ProdFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Productos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("almacen\\productos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A28ProdCod = GetPar( "ProdCod");
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
                     sMode44 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode44;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound44 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_7K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODCOD");
                        AnyError = 1;
                        GX_FocusControl = edtProdCod_Internalname;
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
                           E117K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E127K2 ();
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
            E127K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7K44( ) ;
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
            DisableAttributes7K44( ) ;
         }
         AssignProp("", false, edtavCombolincod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolincod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosublcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosublcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombofamcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombofamcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombounicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombounicod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprodcuentav_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentav_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprodcuentac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentac_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprodcuentaa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentaa_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocbsucod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbsucod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocdetcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocdetcod_Enabled), 5, 0), true);
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

      protected void CONFIRM_7K0( )
      {
         BeforeValidate7K44( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7K44( ) ;
            }
            else
            {
               CheckExtendedTable7K44( ) ;
               CloseExtendedTableCursors7K44( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption7K0( )
      {
      }

      protected void E117K2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtcDetCod_Visible = 0;
         AssignProp("", false, edtcDetCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtcDetCod_Visible), 5, 0), true);
         AV43CombocDetCod = 0;
         AssignAttri("", false, "AV43CombocDetCod", StringUtil.LTrimStr( (decimal)(AV43CombocDetCod), 6, 0));
         edtavCombocdetcod_Visible = 0;
         AssignProp("", false, edtavCombocdetcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocdetcod_Visible), 5, 0), true);
         edtCBSuCod_Visible = 0;
         AssignProp("", false, edtCBSuCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCBSuCod_Visible), 5, 0), true);
         AV41ComboCBSuCod = "";
         AssignAttri("", false, "AV41ComboCBSuCod", AV41ComboCBSuCod);
         edtavCombocbsucod_Visible = 0;
         AssignProp("", false, edtavCombocbsucod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocbsucod_Visible), 5, 0), true);
         edtProdCuentaA_Visible = 0;
         AssignProp("", false, edtProdCuentaA_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProdCuentaA_Visible), 5, 0), true);
         AV39ComboProdCuentaA = "";
         AssignAttri("", false, "AV39ComboProdCuentaA", AV39ComboProdCuentaA);
         edtavComboprodcuentaa_Visible = 0;
         AssignProp("", false, edtavComboprodcuentaa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentaa_Visible), 5, 0), true);
         edtProdCuentaC_Visible = 0;
         AssignProp("", false, edtProdCuentaC_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProdCuentaC_Visible), 5, 0), true);
         AV37ComboProdCuentaC = "";
         AssignAttri("", false, "AV37ComboProdCuentaC", AV37ComboProdCuentaC);
         edtavComboprodcuentac_Visible = 0;
         AssignProp("", false, edtavComboprodcuentac_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentac_Visible), 5, 0), true);
         edtProdCuentaV_Visible = 0;
         AssignProp("", false, edtProdCuentaV_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProdCuentaV_Visible), 5, 0), true);
         AV34ComboProdCuentaV = "";
         AssignAttri("", false, "AV34ComboProdCuentaV", AV34ComboProdCuentaV);
         edtavComboprodcuentav_Visible = 0;
         AssignProp("", false, edtavComboprodcuentav_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentav_Visible), 5, 0), true);
         edtUniCod_Visible = 0;
         AssignProp("", false, edtUniCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUniCod_Visible), 5, 0), true);
         AV32ComboUniCod = 0;
         AssignAttri("", false, "AV32ComboUniCod", StringUtil.LTrimStr( (decimal)(AV32ComboUniCod), 6, 0));
         edtavCombounicod_Visible = 0;
         AssignProp("", false, edtavCombounicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombounicod_Visible), 5, 0), true);
         edtFamCod_Visible = 0;
         AssignProp("", false, edtFamCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFamCod_Visible), 5, 0), true);
         AV30ComboFamCod = 0;
         AssignAttri("", false, "AV30ComboFamCod", StringUtil.LTrimStr( (decimal)(AV30ComboFamCod), 6, 0));
         edtavCombofamcod_Visible = 0;
         AssignProp("", false, edtavCombofamcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombofamcod_Visible), 5, 0), true);
         edtSublCod_Visible = 0;
         AssignProp("", false, edtSublCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSublCod_Visible), 5, 0), true);
         AV28ComboSublCod = 0;
         AssignAttri("", false, "AV28ComboSublCod", StringUtil.LTrimStr( (decimal)(AV28ComboSublCod), 6, 0));
         edtavCombosublcod_Visible = 0;
         AssignProp("", false, edtavCombosublcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosublcod_Visible), 5, 0), true);
         edtLinCod_Visible = 0;
         AssignProp("", false, edtLinCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLinCod_Visible), 5, 0), true);
         AV26ComboLinCod = 0;
         AssignAttri("", false, "AV26ComboLinCod", StringUtil.LTrimStr( (decimal)(AV26ComboLinCod), 6, 0));
         edtavCombolincod_Visible = 0;
         AssignProp("", false, edtavCombolincod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombolincod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLINCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUBLCOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOFAMCOD' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOUNICOD' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPRODCUENTAV' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPRODCUENTAC' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPRODCUENTAA' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCBSUCOD' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCDETCOD' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV44Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV45GXV1 = 1;
            AssignAttri("", false, "AV45GXV1", StringUtil.LTrimStr( (decimal)(AV45GXV1), 8, 0));
            while ( AV45GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV20TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV45GXV1));
               if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "LinCod") == 0 )
               {
                  AV11Insert_LinCod = (int)(NumberUtil.Val( AV20TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_LinCod", StringUtil.LTrimStr( (decimal)(AV11Insert_LinCod), 6, 0));
                  if ( ! (0==AV11Insert_LinCod) )
                  {
                     AV26ComboLinCod = AV11Insert_LinCod;
                     AssignAttri("", false, "AV26ComboLinCod", StringUtil.LTrimStr( (decimal)(AV26ComboLinCod), 6, 0));
                     Combo_lincod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV26ComboLinCod), 6, 0));
                     ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedValue_set", Combo_lincod_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "LinCod",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_lincod_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedText_set", Combo_lincod_Selectedtext_set);
                     Combo_lincod_Enabled = false;
                     ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_lincod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "SublCod") == 0 )
               {
                  AV12Insert_SublCod = (int)(NumberUtil.Val( AV20TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_SublCod", StringUtil.LTrimStr( (decimal)(AV12Insert_SublCod), 6, 0));
                  if ( ! (0==AV12Insert_SublCod) )
                  {
                     AV28ComboSublCod = AV12Insert_SublCod;
                     AssignAttri("", false, "AV28ComboSublCod", StringUtil.LTrimStr( (decimal)(AV28ComboSublCod), 6, 0));
                     Combo_sublcod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV28ComboSublCod), 6, 0));
                     ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedValue_set", Combo_sublcod_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "SublCod",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_sublcod_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedText_set", Combo_sublcod_Selectedtext_set);
                     Combo_sublcod_Enabled = false;
                     ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sublcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "FamCod") == 0 )
               {
                  AV13Insert_FamCod = (int)(NumberUtil.Val( AV20TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_FamCod", StringUtil.LTrimStr( (decimal)(AV13Insert_FamCod), 6, 0));
                  if ( ! (0==AV13Insert_FamCod) )
                  {
                     AV30ComboFamCod = AV13Insert_FamCod;
                     AssignAttri("", false, "AV30ComboFamCod", StringUtil.LTrimStr( (decimal)(AV30ComboFamCod), 6, 0));
                     Combo_famcod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV30ComboFamCod), 6, 0));
                     ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedValue_set", Combo_famcod_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "FamCod",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_famcod_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedText_set", Combo_famcod_Selectedtext_set);
                     Combo_famcod_Enabled = false;
                     ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_famcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "UniCod") == 0 )
               {
                  AV14Insert_UniCod = (int)(NumberUtil.Val( AV20TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_UniCod", StringUtil.LTrimStr( (decimal)(AV14Insert_UniCod), 6, 0));
                  if ( ! (0==AV14Insert_UniCod) )
                  {
                     AV32ComboUniCod = AV14Insert_UniCod;
                     AssignAttri("", false, "AV32ComboUniCod", StringUtil.LTrimStr( (decimal)(AV32ComboUniCod), 6, 0));
                     Combo_unicod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV32ComboUniCod), 6, 0));
                     ucCombo_unicod.SendProperty(context, "", false, Combo_unicod_Internalname, "SelectedValue_set", Combo_unicod_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "UniCod",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_unicod_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_unicod.SendProperty(context, "", false, Combo_unicod_Internalname, "SelectedText_set", Combo_unicod_Selectedtext_set);
                     Combo_unicod_Enabled = false;
                     ucCombo_unicod.SendProperty(context, "", false, Combo_unicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_unicod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "ProdCuentaV") == 0 )
               {
                  AV15Insert_ProdCuentaV = AV20TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV15Insert_ProdCuentaV", AV15Insert_ProdCuentaV);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ProdCuentaV)) )
                  {
                     AV34ComboProdCuentaV = AV15Insert_ProdCuentaV;
                     AssignAttri("", false, "AV34ComboProdCuentaV", AV34ComboProdCuentaV);
                     Combo_prodcuentav_Selectedvalue_set = AV34ComboProdCuentaV;
                     ucCombo_prodcuentav.SendProperty(context, "", false, Combo_prodcuentav_Internalname, "SelectedValue_set", Combo_prodcuentav_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "ProdCuentaV",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_prodcuentav_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_prodcuentav.SendProperty(context, "", false, Combo_prodcuentav_Internalname, "SelectedText_set", Combo_prodcuentav_Selectedtext_set);
                     Combo_prodcuentav_Enabled = false;
                     ucCombo_prodcuentav.SendProperty(context, "", false, Combo_prodcuentav_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prodcuentav_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "ProdCuentaC") == 0 )
               {
                  AV16Insert_ProdCuentaC = AV20TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV16Insert_ProdCuentaC", AV16Insert_ProdCuentaC);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_ProdCuentaC)) )
                  {
                     AV37ComboProdCuentaC = AV16Insert_ProdCuentaC;
                     AssignAttri("", false, "AV37ComboProdCuentaC", AV37ComboProdCuentaC);
                     Combo_prodcuentac_Selectedvalue_set = AV37ComboProdCuentaC;
                     ucCombo_prodcuentac.SendProperty(context, "", false, Combo_prodcuentac_Internalname, "SelectedValue_set", Combo_prodcuentac_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "ProdCuentaC",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_prodcuentac_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_prodcuentac.SendProperty(context, "", false, Combo_prodcuentac_Internalname, "SelectedText_set", Combo_prodcuentac_Selectedtext_set);
                     Combo_prodcuentac_Enabled = false;
                     ucCombo_prodcuentac.SendProperty(context, "", false, Combo_prodcuentac_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prodcuentac_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "ProdCuentaA") == 0 )
               {
                  AV17Insert_ProdCuentaA = AV20TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV17Insert_ProdCuentaA", AV17Insert_ProdCuentaA);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_ProdCuentaA)) )
                  {
                     AV39ComboProdCuentaA = AV17Insert_ProdCuentaA;
                     AssignAttri("", false, "AV39ComboProdCuentaA", AV39ComboProdCuentaA);
                     Combo_prodcuentaa_Selectedvalue_set = AV39ComboProdCuentaA;
                     ucCombo_prodcuentaa.SendProperty(context, "", false, Combo_prodcuentaa_Internalname, "SelectedValue_set", Combo_prodcuentaa_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "ProdCuentaA",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_prodcuentaa_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_prodcuentaa.SendProperty(context, "", false, Combo_prodcuentaa_Internalname, "SelectedText_set", Combo_prodcuentaa_Selectedtext_set);
                     Combo_prodcuentaa_Enabled = false;
                     ucCombo_prodcuentaa.SendProperty(context, "", false, Combo_prodcuentaa_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prodcuentaa_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "CBSuCod") == 0 )
               {
                  AV18Insert_CBSuCod = AV20TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV18Insert_CBSuCod", AV18Insert_CBSuCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Insert_CBSuCod)) )
                  {
                     AV41ComboCBSuCod = AV18Insert_CBSuCod;
                     AssignAttri("", false, "AV41ComboCBSuCod", AV41ComboCBSuCod);
                     Combo_cbsucod_Selectedvalue_set = AV41ComboCBSuCod;
                     ucCombo_cbsucod.SendProperty(context, "", false, Combo_cbsucod_Internalname, "SelectedValue_set", Combo_cbsucod_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "CBSuCod",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_cbsucod_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_cbsucod.SendProperty(context, "", false, Combo_cbsucod_Internalname, "SelectedText_set", Combo_cbsucod_Selectedtext_set);
                     Combo_cbsucod_Enabled = false;
                     ucCombo_cbsucod.SendProperty(context, "", false, Combo_cbsucod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbsucod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV20TrnContextAtt.gxTpr_Attributename, "cDetCod") == 0 )
               {
                  AV19Insert_cDetCod = (int)(NumberUtil.Val( AV20TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV19Insert_cDetCod", StringUtil.LTrimStr( (decimal)(AV19Insert_cDetCod), 6, 0));
                  if ( ! (0==AV19Insert_cDetCod) )
                  {
                     AV43CombocDetCod = AV19Insert_cDetCod;
                     AssignAttri("", false, "AV43CombocDetCod", StringUtil.LTrimStr( (decimal)(AV43CombocDetCod), 6, 0));
                     Combo_cdetcod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV43CombocDetCod), 6, 0));
                     ucCombo_cdetcod.SendProperty(context, "", false, Combo_cdetcod_Internalname, "SelectedValue_set", Combo_cdetcod_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "cDetCod",  "GET",  false,  AV7ProdCod,  AV20TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_cdetcod_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_cdetcod.SendProperty(context, "", false, Combo_cdetcod_Internalname, "SelectedText_set", Combo_cdetcod_Selectedtext_set);
                     Combo_cdetcod_Enabled = false;
                     ucCombo_cdetcod.SendProperty(context, "", false, Combo_cdetcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cdetcod_Enabled));
                  }
               }
               AV45GXV1 = (int)(AV45GXV1+1);
               AssignAttri("", false, "AV45GXV1", StringUtil.LTrimStr( (decimal)(AV45GXV1), 8, 0));
            }
         }
      }

      protected void E127K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("almacen.productosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S192( )
      {
         /* 'LOADCOMBOCDETCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "cDetCod",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_cdetcod_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_cdetcod.SendProperty(context, "", false, Combo_cdetcod_Internalname, "SelectedValue_set", Combo_cdetcod_Selectedvalue_set);
         Combo_cdetcod_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_cdetcod.SendProperty(context, "", false, Combo_cdetcod_Internalname, "SelectedText_set", Combo_cdetcod_Selectedtext_set);
         AV43CombocDetCod = (int)(NumberUtil.Val( AV23ComboSelectedValue, "."));
         AssignAttri("", false, "AV43CombocDetCod", StringUtil.LTrimStr( (decimal)(AV43CombocDetCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cdetcod_Enabled = false;
            ucCombo_cdetcod.SendProperty(context, "", false, Combo_cdetcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cdetcod_Enabled));
         }
      }

      protected void S182( )
      {
         /* 'LOADCOMBOCBSUCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "CBSuCod",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_cbsucod_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_cbsucod.SendProperty(context, "", false, Combo_cbsucod_Internalname, "SelectedValue_set", Combo_cbsucod_Selectedvalue_set);
         Combo_cbsucod_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_cbsucod.SendProperty(context, "", false, Combo_cbsucod_Internalname, "SelectedText_set", Combo_cbsucod_Selectedtext_set);
         AV41ComboCBSuCod = AV23ComboSelectedValue;
         AssignAttri("", false, "AV41ComboCBSuCod", AV41ComboCBSuCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cbsucod_Enabled = false;
            ucCombo_cbsucod.SendProperty(context, "", false, Combo_cbsucod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cbsucod_Enabled));
         }
      }

      protected void S172( )
      {
         /* 'LOADCOMBOPRODCUENTAA' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "ProdCuentaA",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_prodcuentaa_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_prodcuentaa.SendProperty(context, "", false, Combo_prodcuentaa_Internalname, "SelectedValue_set", Combo_prodcuentaa_Selectedvalue_set);
         Combo_prodcuentaa_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_prodcuentaa.SendProperty(context, "", false, Combo_prodcuentaa_Internalname, "SelectedText_set", Combo_prodcuentaa_Selectedtext_set);
         AV39ComboProdCuentaA = AV23ComboSelectedValue;
         AssignAttri("", false, "AV39ComboProdCuentaA", AV39ComboProdCuentaA);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_prodcuentaa_Enabled = false;
            ucCombo_prodcuentaa.SendProperty(context, "", false, Combo_prodcuentaa_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prodcuentaa_Enabled));
         }
      }

      protected void S162( )
      {
         /* 'LOADCOMBOPRODCUENTAC' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "ProdCuentaC",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_prodcuentac_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_prodcuentac.SendProperty(context, "", false, Combo_prodcuentac_Internalname, "SelectedValue_set", Combo_prodcuentac_Selectedvalue_set);
         Combo_prodcuentac_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_prodcuentac.SendProperty(context, "", false, Combo_prodcuentac_Internalname, "SelectedText_set", Combo_prodcuentac_Selectedtext_set);
         AV37ComboProdCuentaC = AV23ComboSelectedValue;
         AssignAttri("", false, "AV37ComboProdCuentaC", AV37ComboProdCuentaC);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_prodcuentac_Enabled = false;
            ucCombo_prodcuentac.SendProperty(context, "", false, Combo_prodcuentac_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prodcuentac_Enabled));
         }
      }

      protected void S152( )
      {
         /* 'LOADCOMBOPRODCUENTAV' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "ProdCuentaV",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_prodcuentav_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_prodcuentav.SendProperty(context, "", false, Combo_prodcuentav_Internalname, "SelectedValue_set", Combo_prodcuentav_Selectedvalue_set);
         Combo_prodcuentav_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_prodcuentav.SendProperty(context, "", false, Combo_prodcuentav_Internalname, "SelectedText_set", Combo_prodcuentav_Selectedtext_set);
         AV34ComboProdCuentaV = AV23ComboSelectedValue;
         AssignAttri("", false, "AV34ComboProdCuentaV", AV34ComboProdCuentaV);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_prodcuentav_Enabled = false;
            ucCombo_prodcuentav.SendProperty(context, "", false, Combo_prodcuentav_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prodcuentav_Enabled));
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOUNICOD' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "UniCod",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_unicod_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_unicod.SendProperty(context, "", false, Combo_unicod_Internalname, "SelectedValue_set", Combo_unicod_Selectedvalue_set);
         Combo_unicod_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_unicod.SendProperty(context, "", false, Combo_unicod_Internalname, "SelectedText_set", Combo_unicod_Selectedtext_set);
         AV32ComboUniCod = (int)(NumberUtil.Val( AV23ComboSelectedValue, "."));
         AssignAttri("", false, "AV32ComboUniCod", StringUtil.LTrimStr( (decimal)(AV32ComboUniCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_unicod_Enabled = false;
            ucCombo_unicod.SendProperty(context, "", false, Combo_unicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_unicod_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOFAMCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "FamCod",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_famcod_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedValue_set", Combo_famcod_Selectedvalue_set);
         Combo_famcod_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "SelectedText_set", Combo_famcod_Selectedtext_set);
         AV30ComboFamCod = (int)(NumberUtil.Val( AV23ComboSelectedValue, "."));
         AssignAttri("", false, "AV30ComboFamCod", StringUtil.LTrimStr( (decimal)(AV30ComboFamCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_famcod_Enabled = false;
            ucCombo_famcod.SendProperty(context, "", false, Combo_famcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_famcod_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUBLCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "SublCod",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_sublcod_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedValue_set", Combo_sublcod_Selectedvalue_set);
         Combo_sublcod_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "SelectedText_set", Combo_sublcod_Selectedtext_set);
         AV28ComboSublCod = (int)(NumberUtil.Val( AV23ComboSelectedValue, "."));
         AssignAttri("", false, "AV28ComboSublCod", StringUtil.LTrimStr( (decimal)(AV28ComboSublCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_sublcod_Enabled = false;
            ucCombo_sublcod.SendProperty(context, "", false, Combo_sublcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sublcod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLINCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new GeneXus.Programs.almacen.productosloaddvcombo(context ).execute(  "LinCod",  Gx_mode,  false,  AV7ProdCod,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_lincod_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedValue_set", Combo_lincod_Selectedvalue_set);
         Combo_lincod_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "SelectedText_set", Combo_lincod_Selectedtext_set);
         AV26ComboLinCod = (int)(NumberUtil.Val( AV23ComboSelectedValue, "."));
         AssignAttri("", false, "AV26ComboLinCod", StringUtil.LTrimStr( (decimal)(AV26ComboLinCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_lincod_Enabled = false;
            ucCombo_lincod.SendProperty(context, "", false, Combo_lincod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_lincod_Enabled));
         }
      }

      protected void ZM7K44( short GX_JID )
      {
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z55ProdDsc = T007K3_A55ProdDsc[0];
               Z1724ProdVta = T007K3_A1724ProdVta[0];
               Z1679ProdCmp = T007K3_A1679ProdCmp[0];
               Z1702ProdPeso = T007K3_A1702ProdPeso[0];
               Z1723ProdVolumen = T007K3_A1723ProdVolumen[0];
               Z1716ProdStkMax = T007K3_A1716ProdStkMax[0];
               Z1717ProdStkMin = T007K3_A1717ProdStkMin[0];
               Z1705ProdRef1 = T007K3_A1705ProdRef1[0];
               Z1707ProdRef2 = T007K3_A1707ProdRef2[0];
               Z1708ProdRef3 = T007K3_A1708ProdRef3[0];
               Z1709ProdRef4 = T007K3_A1709ProdRef4[0];
               Z1710ProdRef5 = T007K3_A1710ProdRef5[0];
               Z1711ProdRef6 = T007K3_A1711ProdRef6[0];
               Z1712ProdRef7 = T007K3_A1712ProdRef7[0];
               Z1713ProdRef8 = T007K3_A1713ProdRef8[0];
               Z1714ProdRef9 = T007K3_A1714ProdRef9[0];
               Z1706ProdRef10 = T007K3_A1706ProdRef10[0];
               Z1718ProdSts = T007K3_A1718ProdSts[0];
               Z1681ProdCosto = T007K3_A1681ProdCosto[0];
               Z1683ProdCostoFec = T007K3_A1683ProdCostoFec[0];
               Z1682ProdCostoD = T007K3_A1682ProdCostoD[0];
               Z1698ProdIna = T007K3_A1698ProdIna[0];
               Z1703ProdPorSel = T007K3_A1703ProdPorSel[0];
               Z1697ProdImpSel = T007K3_A1697ProdImpSel[0];
               Z1672ProdAdValor = T007K3_A1672ProdAdValor[0];
               Z1696ProdFrecuente = T007K3_A1696ProdFrecuente[0];
               Z1721ProdUsuCod = T007K3_A1721ProdUsuCod[0];
               Z1722ProdUsuFec = T007K3_A1722ProdUsuFec[0];
               Z1673ProdAfec = T007K3_A1673ProdAfec[0];
               Z1701ProdObs = T007K3_A1701ProdObs[0];
               Z1675ProdCanLote = T007K3_A1675ProdCanLote[0];
               Z1674ProdBarra = T007K3_A1674ProdBarra[0];
               Z1689ProdExportacion = T007K3_A1689ProdExportacion[0];
               Z906ProdAfecICBPER = T007K3_A906ProdAfecICBPER[0];
               Z907ProdValICBPER = T007K3_A907ProdValICBPER[0];
               Z908ProdValICBPERD = T007K3_A908ProdValICBPERD[0];
               Z52LinCod = T007K3_A52LinCod[0];
               Z51SublCod = T007K3_A51SublCod[0];
               Z50FamCod = T007K3_A50FamCod[0];
               Z49UniCod = T007K3_A49UniCod[0];
               Z47CBSuCod = T007K3_A47CBSuCod[0];
               Z46cDetCod = T007K3_A46cDetCod[0];
               Z48ProdCuentaV = T007K3_A48ProdCuentaV[0];
               Z53ProdCuentaC = T007K3_A53ProdCuentaC[0];
               Z54ProdCuentaA = T007K3_A54ProdCuentaA[0];
            }
            else
            {
               Z55ProdDsc = A55ProdDsc;
               Z1724ProdVta = A1724ProdVta;
               Z1679ProdCmp = A1679ProdCmp;
               Z1702ProdPeso = A1702ProdPeso;
               Z1723ProdVolumen = A1723ProdVolumen;
               Z1716ProdStkMax = A1716ProdStkMax;
               Z1717ProdStkMin = A1717ProdStkMin;
               Z1705ProdRef1 = A1705ProdRef1;
               Z1707ProdRef2 = A1707ProdRef2;
               Z1708ProdRef3 = A1708ProdRef3;
               Z1709ProdRef4 = A1709ProdRef4;
               Z1710ProdRef5 = A1710ProdRef5;
               Z1711ProdRef6 = A1711ProdRef6;
               Z1712ProdRef7 = A1712ProdRef7;
               Z1713ProdRef8 = A1713ProdRef8;
               Z1714ProdRef9 = A1714ProdRef9;
               Z1706ProdRef10 = A1706ProdRef10;
               Z1718ProdSts = A1718ProdSts;
               Z1681ProdCosto = A1681ProdCosto;
               Z1683ProdCostoFec = A1683ProdCostoFec;
               Z1682ProdCostoD = A1682ProdCostoD;
               Z1698ProdIna = A1698ProdIna;
               Z1703ProdPorSel = A1703ProdPorSel;
               Z1697ProdImpSel = A1697ProdImpSel;
               Z1672ProdAdValor = A1672ProdAdValor;
               Z1696ProdFrecuente = A1696ProdFrecuente;
               Z1721ProdUsuCod = A1721ProdUsuCod;
               Z1722ProdUsuFec = A1722ProdUsuFec;
               Z1673ProdAfec = A1673ProdAfec;
               Z1701ProdObs = A1701ProdObs;
               Z1675ProdCanLote = A1675ProdCanLote;
               Z1674ProdBarra = A1674ProdBarra;
               Z1689ProdExportacion = A1689ProdExportacion;
               Z906ProdAfecICBPER = A906ProdAfecICBPER;
               Z907ProdValICBPER = A907ProdValICBPER;
               Z908ProdValICBPERD = A908ProdValICBPERD;
               Z52LinCod = A52LinCod;
               Z51SublCod = A51SublCod;
               Z50FamCod = A50FamCod;
               Z49UniCod = A49UniCod;
               Z47CBSuCod = A47CBSuCod;
               Z46cDetCod = A46cDetCod;
               Z48ProdCuentaV = A48ProdCuentaV;
               Z53ProdCuentaC = A53ProdCuentaC;
               Z54ProdCuentaA = A54ProdCuentaA;
            }
         }
         if ( GX_JID == -36 )
         {
            Z28ProdCod = A28ProdCod;
            Z55ProdDsc = A55ProdDsc;
            Z1724ProdVta = A1724ProdVta;
            Z1679ProdCmp = A1679ProdCmp;
            Z1702ProdPeso = A1702ProdPeso;
            Z1723ProdVolumen = A1723ProdVolumen;
            Z1716ProdStkMax = A1716ProdStkMax;
            Z1717ProdStkMin = A1717ProdStkMin;
            Z1695ProdFoto = A1695ProdFoto;
            Z40000ProdFoto_GXI = A40000ProdFoto_GXI;
            Z1705ProdRef1 = A1705ProdRef1;
            Z1707ProdRef2 = A1707ProdRef2;
            Z1708ProdRef3 = A1708ProdRef3;
            Z1709ProdRef4 = A1709ProdRef4;
            Z1710ProdRef5 = A1710ProdRef5;
            Z1711ProdRef6 = A1711ProdRef6;
            Z1712ProdRef7 = A1712ProdRef7;
            Z1713ProdRef8 = A1713ProdRef8;
            Z1714ProdRef9 = A1714ProdRef9;
            Z1706ProdRef10 = A1706ProdRef10;
            Z1718ProdSts = A1718ProdSts;
            Z1681ProdCosto = A1681ProdCosto;
            Z1683ProdCostoFec = A1683ProdCostoFec;
            Z1682ProdCostoD = A1682ProdCostoD;
            Z1698ProdIna = A1698ProdIna;
            Z1703ProdPorSel = A1703ProdPorSel;
            Z1697ProdImpSel = A1697ProdImpSel;
            Z1672ProdAdValor = A1672ProdAdValor;
            Z1696ProdFrecuente = A1696ProdFrecuente;
            Z1721ProdUsuCod = A1721ProdUsuCod;
            Z1722ProdUsuFec = A1722ProdUsuFec;
            Z1673ProdAfec = A1673ProdAfec;
            Z1701ProdObs = A1701ProdObs;
            Z1675ProdCanLote = A1675ProdCanLote;
            Z1674ProdBarra = A1674ProdBarra;
            Z1689ProdExportacion = A1689ProdExportacion;
            Z906ProdAfecICBPER = A906ProdAfecICBPER;
            Z907ProdValICBPER = A907ProdValICBPER;
            Z908ProdValICBPERD = A908ProdValICBPERD;
            Z52LinCod = A52LinCod;
            Z51SublCod = A51SublCod;
            Z50FamCod = A50FamCod;
            Z49UniCod = A49UniCod;
            Z47CBSuCod = A47CBSuCod;
            Z46cDetCod = A46cDetCod;
            Z48ProdCuentaV = A48ProdCuentaV;
            Z53ProdCuentaC = A53ProdCuentaC;
            Z54ProdCuentaA = A54ProdCuentaA;
            Z1153LinDsc = A1153LinDsc;
            Z1686ProdCuentaVDsc = A1686ProdCuentaVDsc;
            Z1685ProdCuentaCDsc = A1685ProdCuentaCDsc;
            Z1684ProdCuentaADsc = A1684ProdCuentaADsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV44Pgmname = "Almacen.Productos";
         AssignAttri("", false, "AV44Pgmname", AV44Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProdCod)) )
         {
            A28ProdCod = AV7ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProdCod)) )
         {
            edtProdCod_Enabled = 0;
            AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         }
         else
         {
            edtProdCod_Enabled = 1;
            AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProdCod)) )
         {
            edtProdCod_Enabled = 0;
            AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LinCod) )
         {
            edtLinCod_Enabled = 0;
            AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         }
         else
         {
            edtLinCod_Enabled = 1;
            AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SublCod) )
         {
            edtSublCod_Enabled = 0;
            AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         }
         else
         {
            edtSublCod_Enabled = 1;
            AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_FamCod) )
         {
            edtFamCod_Enabled = 0;
            AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         }
         else
         {
            edtFamCod_Enabled = 1;
            AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_UniCod) )
         {
            edtUniCod_Enabled = 0;
            AssignProp("", false, edtUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniCod_Enabled), 5, 0), true);
         }
         else
         {
            edtUniCod_Enabled = 1;
            AssignProp("", false, edtUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ProdCuentaV)) )
         {
            edtProdCuentaV_Enabled = 0;
            AssignProp("", false, edtProdCuentaV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaV_Enabled), 5, 0), true);
         }
         else
         {
            edtProdCuentaV_Enabled = 1;
            AssignProp("", false, edtProdCuentaV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaV_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_ProdCuentaC)) )
         {
            edtProdCuentaC_Enabled = 0;
            AssignProp("", false, edtProdCuentaC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaC_Enabled), 5, 0), true);
         }
         else
         {
            edtProdCuentaC_Enabled = 1;
            AssignProp("", false, edtProdCuentaC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaC_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_ProdCuentaA)) )
         {
            edtProdCuentaA_Enabled = 0;
            AssignProp("", false, edtProdCuentaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaA_Enabled), 5, 0), true);
         }
         else
         {
            edtProdCuentaA_Enabled = 1;
            AssignProp("", false, edtProdCuentaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaA_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Insert_CBSuCod)) )
         {
            edtCBSuCod_Enabled = 0;
            AssignProp("", false, edtCBSuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBSuCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCBSuCod_Enabled = 1;
            AssignProp("", false, edtCBSuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBSuCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_cDetCod) )
         {
            edtcDetCod_Enabled = 0;
            AssignProp("", false, edtcDetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcDetCod_Enabled), 5, 0), true);
         }
         else
         {
            edtcDetCod_Enabled = 1;
            AssignProp("", false, edtcDetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcDetCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LinCod) )
         {
            A52LinCod = AV11Insert_LinCod;
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
         else
         {
            A52LinCod = AV26ComboLinCod;
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SublCod) )
         {
            A51SublCod = AV12Insert_SublCod;
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
         else
         {
            if ( (0==AV28ComboSublCod) )
            {
               A51SublCod = 0;
               n51SublCod = false;
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               n51SublCod = true;
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV28ComboSublCod) )
               {
                  A51SublCod = AV28ComboSublCod;
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_FamCod) )
         {
            A50FamCod = AV13Insert_FamCod;
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
         else
         {
            if ( (0==AV30ComboFamCod) )
            {
               A50FamCod = 0;
               n50FamCod = false;
               AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               n50FamCod = true;
               AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV30ComboFamCod) )
               {
                  A50FamCod = AV30ComboFamCod;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_UniCod) )
         {
            A49UniCod = AV14Insert_UniCod;
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         }
         else
         {
            A49UniCod = AV32ComboUniCod;
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Insert_ProdCuentaV)) )
         {
            A48ProdCuentaV = AV15Insert_ProdCuentaV;
            n48ProdCuentaV = false;
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34ComboProdCuentaV)) )
            {
               A48ProdCuentaV = "";
               n48ProdCuentaV = false;
               AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
               n48ProdCuentaV = true;
               AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ComboProdCuentaV)) )
               {
                  A48ProdCuentaV = AV34ComboProdCuentaV;
                  n48ProdCuentaV = false;
                  AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_ProdCuentaC)) )
         {
            A53ProdCuentaC = AV16Insert_ProdCuentaC;
            n53ProdCuentaC = false;
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ComboProdCuentaC)) )
            {
               A53ProdCuentaC = "";
               n53ProdCuentaC = false;
               AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
               n53ProdCuentaC = true;
               AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ComboProdCuentaC)) )
               {
                  A53ProdCuentaC = AV37ComboProdCuentaC;
                  n53ProdCuentaC = false;
                  AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_ProdCuentaA)) )
         {
            A54ProdCuentaA = AV17Insert_ProdCuentaA;
            n54ProdCuentaA = false;
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ComboProdCuentaA)) )
            {
               A54ProdCuentaA = "";
               n54ProdCuentaA = false;
               AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
               n54ProdCuentaA = true;
               AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ComboProdCuentaA)) )
               {
                  A54ProdCuentaA = AV39ComboProdCuentaA;
                  n54ProdCuentaA = false;
                  AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Insert_CBSuCod)) )
         {
            A47CBSuCod = AV18Insert_CBSuCod;
            n47CBSuCod = false;
            AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41ComboCBSuCod)) )
            {
               A47CBSuCod = "";
               n47CBSuCod = false;
               AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
               n47CBSuCod = true;
               AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41ComboCBSuCod)) )
               {
                  A47CBSuCod = AV41ComboCBSuCod;
                  n47CBSuCod = false;
                  AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_cDetCod) )
         {
            A46cDetCod = AV19Insert_cDetCod;
            n46cDetCod = false;
            AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
         }
         else
         {
            if ( (0==AV43CombocDetCod) )
            {
               A46cDetCod = 0;
               n46cDetCod = false;
               AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
               n46cDetCod = true;
               AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV43CombocDetCod) )
               {
                  A46cDetCod = AV43CombocDetCod;
                  n46cDetCod = false;
                  AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T007K4 */
            pr_default.execute(2, new Object[] {A52LinCod});
            A1153LinDsc = T007K4_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            pr_default.close(2);
            /* Using cursor T007K10 */
            pr_default.execute(8, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
            A1686ProdCuentaVDsc = T007K10_A1686ProdCuentaVDsc[0];
            AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
            pr_default.close(8);
            /* Using cursor T007K11 */
            pr_default.execute(9, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
            A1685ProdCuentaCDsc = T007K11_A1685ProdCuentaCDsc[0];
            AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
            pr_default.close(9);
            /* Using cursor T007K12 */
            pr_default.execute(10, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
            A1684ProdCuentaADsc = T007K12_A1684ProdCuentaADsc[0];
            AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
            pr_default.close(10);
         }
      }

      protected void Load7K44( )
      {
         /* Using cursor T007K13 */
         pr_default.execute(11, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound44 = 1;
            A55ProdDsc = T007K13_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1724ProdVta = T007K13_A1724ProdVta[0];
            AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
            A1679ProdCmp = T007K13_A1679ProdCmp[0];
            AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
            A1702ProdPeso = T007K13_A1702ProdPeso[0];
            AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
            A1723ProdVolumen = T007K13_A1723ProdVolumen[0];
            AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
            A1716ProdStkMax = T007K13_A1716ProdStkMax[0];
            AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
            A1717ProdStkMin = T007K13_A1717ProdStkMin[0];
            AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
            A40000ProdFoto_GXI = T007K13_A40000ProdFoto_GXI[0];
            n40000ProdFoto_GXI = T007K13_n40000ProdFoto_GXI[0];
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            A1705ProdRef1 = T007K13_A1705ProdRef1[0];
            AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
            A1707ProdRef2 = T007K13_A1707ProdRef2[0];
            AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
            A1708ProdRef3 = T007K13_A1708ProdRef3[0];
            AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
            A1709ProdRef4 = T007K13_A1709ProdRef4[0];
            AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
            A1710ProdRef5 = T007K13_A1710ProdRef5[0];
            AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
            A1711ProdRef6 = T007K13_A1711ProdRef6[0];
            AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
            A1712ProdRef7 = T007K13_A1712ProdRef7[0];
            AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
            A1713ProdRef8 = T007K13_A1713ProdRef8[0];
            AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
            A1714ProdRef9 = T007K13_A1714ProdRef9[0];
            AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
            A1706ProdRef10 = T007K13_A1706ProdRef10[0];
            AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
            A1718ProdSts = T007K13_A1718ProdSts[0];
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            A1681ProdCosto = T007K13_A1681ProdCosto[0];
            AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
            A1683ProdCostoFec = T007K13_A1683ProdCostoFec[0];
            AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
            A1682ProdCostoD = T007K13_A1682ProdCostoD[0];
            AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
            A1698ProdIna = T007K13_A1698ProdIna[0];
            AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
            A1703ProdPorSel = T007K13_A1703ProdPorSel[0];
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A1697ProdImpSel = T007K13_A1697ProdImpSel[0];
            AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrimStr( A1697ProdImpSel, 15, 2));
            A1672ProdAdValor = T007K13_A1672ProdAdValor[0];
            AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
            A1696ProdFrecuente = T007K13_A1696ProdFrecuente[0];
            AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
            A1686ProdCuentaVDsc = T007K13_A1686ProdCuentaVDsc[0];
            AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
            A1685ProdCuentaCDsc = T007K13_A1685ProdCuentaCDsc[0];
            AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
            A1684ProdCuentaADsc = T007K13_A1684ProdCuentaADsc[0];
            AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
            A1721ProdUsuCod = T007K13_A1721ProdUsuCod[0];
            AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
            A1722ProdUsuFec = T007K13_A1722ProdUsuFec[0];
            AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1673ProdAfec = T007K13_A1673ProdAfec[0];
            AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
            A1701ProdObs = T007K13_A1701ProdObs[0];
            AssignAttri("", false, "A1701ProdObs", A1701ProdObs);
            A1675ProdCanLote = T007K13_A1675ProdCanLote[0];
            AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrimStr( A1675ProdCanLote, 15, 2));
            A1674ProdBarra = T007K13_A1674ProdBarra[0];
            AssignAttri("", false, "A1674ProdBarra", A1674ProdBarra);
            A1689ProdExportacion = T007K13_A1689ProdExportacion[0];
            AssignAttri("", false, "A1689ProdExportacion", A1689ProdExportacion);
            A906ProdAfecICBPER = T007K13_A906ProdAfecICBPER[0];
            AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
            A907ProdValICBPER = T007K13_A907ProdValICBPER[0];
            AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
            A908ProdValICBPERD = T007K13_A908ProdValICBPERD[0];
            AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
            A1153LinDsc = T007K13_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            A52LinCod = T007K13_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            A51SublCod = T007K13_A51SublCod[0];
            n51SublCod = T007K13_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            A50FamCod = T007K13_A50FamCod[0];
            n50FamCod = T007K13_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            A49UniCod = T007K13_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            A47CBSuCod = T007K13_A47CBSuCod[0];
            n47CBSuCod = T007K13_n47CBSuCod[0];
            AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
            A46cDetCod = T007K13_A46cDetCod[0];
            n46cDetCod = T007K13_n46cDetCod[0];
            AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
            A48ProdCuentaV = T007K13_A48ProdCuentaV[0];
            n48ProdCuentaV = T007K13_n48ProdCuentaV[0];
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            A53ProdCuentaC = T007K13_A53ProdCuentaC[0];
            n53ProdCuentaC = T007K13_n53ProdCuentaC[0];
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            A54ProdCuentaA = T007K13_A54ProdCuentaA[0];
            n54ProdCuentaA = T007K13_n54ProdCuentaA[0];
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            A1695ProdFoto = T007K13_A1695ProdFoto[0];
            n1695ProdFoto = T007K13_n1695ProdFoto[0];
            AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            ZM7K44( -36) ;
         }
         pr_default.close(11);
         OnLoadActions7K44( ) ;
      }

      protected void OnLoadActions7K44( )
      {
         A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
      }

      protected void CheckExtendedTable7K44( )
      {
         nIsDirty_44 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007K4 */
         pr_default.execute(2, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1153LinDsc = T007K4_A1153LinDsc[0];
         AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
         pr_default.close(2);
         /* Using cursor T007K5 */
         pr_default.execute(3, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A51SublCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T007K6 */
         pr_default.execute(4, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A50FamCod) ) )
            {
               GX_msglist.addItem("No existe 'Familia'.", "ForeignKeyNotFound", 1, "FAMCOD");
               AnyError = 1;
               GX_FocusControl = edtFamCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T007K7 */
         pr_default.execute(5, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidad de Medida'.", "ForeignKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         nIsDirty_44 = 1;
         A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
         if ( ! ( (DateTime.MinValue==A1683ProdCostoFec) || ( DateTimeUtil.ResetTime ( A1683ProdCostoFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Ult. Costo fuera de rango", "OutOfRange", 1, "PRODCOSTOFEC");
            AnyError = 1;
            GX_FocusControl = edtProdCostoFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T007K10 */
         pr_default.execute(8, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAV");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1686ProdCuentaVDsc = T007K10_A1686ProdCuentaVDsc[0];
         AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
         pr_default.close(8);
         /* Using cursor T007K11 */
         pr_default.execute(9, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAC");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1685ProdCuentaCDsc = T007K11_A1685ProdCuentaCDsc[0];
         AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
         pr_default.close(9);
         /* Using cursor T007K12 */
         pr_default.execute(10, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Almacen'.", "ForeignKeyNotFound", 1, "PRODCUENTAA");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1684ProdCuentaADsc = T007K12_A1684ProdCuentaADsc[0];
         AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
         pr_default.close(10);
         if ( ! ( (DateTime.MinValue==A1722ProdUsuFec) || ( A1722ProdUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "PRODUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtProdUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T007K8 */
         pr_default.execute(6, new Object[] {n47CBSuCod, A47CBSuCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos Sunat'.", "ForeignKeyNotFound", 1, "CBSUCOD");
               AnyError = 1;
               GX_FocusControl = edtCBSuCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T007K9 */
         pr_default.execute(7, new Object[] {n46cDetCod, A46cDetCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A46cDetCod) ) )
            {
               GX_msglist.addItem("No existe 'CDETRACCIONES'.", "ForeignKeyNotFound", 1, "CDETCOD");
               AnyError = 1;
               GX_FocusControl = edtcDetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors7K44( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_37( int A52LinCod )
      {
         /* Using cursor T007K14 */
         pr_default.execute(12, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1153LinDsc = T007K14_A1153LinDsc[0];
         AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1153LinDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_38( int A51SublCod )
      {
         /* Using cursor T007K15 */
         pr_default.execute(13, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A51SublCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_39( int A50FamCod )
      {
         /* Using cursor T007K16 */
         pr_default.execute(14, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A50FamCod) ) )
            {
               GX_msglist.addItem("No existe 'Familia'.", "ForeignKeyNotFound", 1, "FAMCOD");
               AnyError = 1;
               GX_FocusControl = edtFamCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_40( int A49UniCod )
      {
         /* Using cursor T007K17 */
         pr_default.execute(15, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidad de Medida'.", "ForeignKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_43( string A48ProdCuentaV )
      {
         /* Using cursor T007K18 */
         pr_default.execute(16, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAV");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1686ProdCuentaVDsc = T007K18_A1686ProdCuentaVDsc[0];
         AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1686ProdCuentaVDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_44( string A53ProdCuentaC )
      {
         /* Using cursor T007K19 */
         pr_default.execute(17, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAC");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1685ProdCuentaCDsc = T007K19_A1685ProdCuentaCDsc[0];
         AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1685ProdCuentaCDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_45( string A54ProdCuentaA )
      {
         /* Using cursor T007K20 */
         pr_default.execute(18, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Almacen'.", "ForeignKeyNotFound", 1, "PRODCUENTAA");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1684ProdCuentaADsc = T007K20_A1684ProdCuentaADsc[0];
         AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1684ProdCuentaADsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_41( string A47CBSuCod )
      {
         /* Using cursor T007K21 */
         pr_default.execute(19, new Object[] {n47CBSuCod, A47CBSuCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos Sunat'.", "ForeignKeyNotFound", 1, "CBSUCOD");
               AnyError = 1;
               GX_FocusControl = edtCBSuCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_42( int A46cDetCod )
      {
         /* Using cursor T007K22 */
         pr_default.execute(20, new Object[] {n46cDetCod, A46cDetCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A46cDetCod) ) )
            {
               GX_msglist.addItem("No existe 'CDETRACCIONES'.", "ForeignKeyNotFound", 1, "CDETCOD");
               AnyError = 1;
               GX_FocusControl = edtcDetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey7K44( )
      {
         /* Using cursor T007K23 */
         pr_default.execute(21, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007K3 */
         pr_default.execute(1, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7K44( 36) ;
            RcdFound44 = 1;
            A28ProdCod = T007K3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A55ProdDsc = T007K3_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1724ProdVta = T007K3_A1724ProdVta[0];
            AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
            A1679ProdCmp = T007K3_A1679ProdCmp[0];
            AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
            A1702ProdPeso = T007K3_A1702ProdPeso[0];
            AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
            A1723ProdVolumen = T007K3_A1723ProdVolumen[0];
            AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
            A1716ProdStkMax = T007K3_A1716ProdStkMax[0];
            AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
            A1717ProdStkMin = T007K3_A1717ProdStkMin[0];
            AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
            A40000ProdFoto_GXI = T007K3_A40000ProdFoto_GXI[0];
            n40000ProdFoto_GXI = T007K3_n40000ProdFoto_GXI[0];
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            A1705ProdRef1 = T007K3_A1705ProdRef1[0];
            AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
            A1707ProdRef2 = T007K3_A1707ProdRef2[0];
            AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
            A1708ProdRef3 = T007K3_A1708ProdRef3[0];
            AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
            A1709ProdRef4 = T007K3_A1709ProdRef4[0];
            AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
            A1710ProdRef5 = T007K3_A1710ProdRef5[0];
            AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
            A1711ProdRef6 = T007K3_A1711ProdRef6[0];
            AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
            A1712ProdRef7 = T007K3_A1712ProdRef7[0];
            AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
            A1713ProdRef8 = T007K3_A1713ProdRef8[0];
            AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
            A1714ProdRef9 = T007K3_A1714ProdRef9[0];
            AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
            A1706ProdRef10 = T007K3_A1706ProdRef10[0];
            AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
            A1718ProdSts = T007K3_A1718ProdSts[0];
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            A1681ProdCosto = T007K3_A1681ProdCosto[0];
            AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
            A1683ProdCostoFec = T007K3_A1683ProdCostoFec[0];
            AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
            A1682ProdCostoD = T007K3_A1682ProdCostoD[0];
            AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
            A1698ProdIna = T007K3_A1698ProdIna[0];
            AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
            A1703ProdPorSel = T007K3_A1703ProdPorSel[0];
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A1697ProdImpSel = T007K3_A1697ProdImpSel[0];
            AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrimStr( A1697ProdImpSel, 15, 2));
            A1672ProdAdValor = T007K3_A1672ProdAdValor[0];
            AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
            A1696ProdFrecuente = T007K3_A1696ProdFrecuente[0];
            AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
            A1721ProdUsuCod = T007K3_A1721ProdUsuCod[0];
            AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
            A1722ProdUsuFec = T007K3_A1722ProdUsuFec[0];
            AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1673ProdAfec = T007K3_A1673ProdAfec[0];
            AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
            A1701ProdObs = T007K3_A1701ProdObs[0];
            AssignAttri("", false, "A1701ProdObs", A1701ProdObs);
            A1675ProdCanLote = T007K3_A1675ProdCanLote[0];
            AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrimStr( A1675ProdCanLote, 15, 2));
            A1674ProdBarra = T007K3_A1674ProdBarra[0];
            AssignAttri("", false, "A1674ProdBarra", A1674ProdBarra);
            A1689ProdExportacion = T007K3_A1689ProdExportacion[0];
            AssignAttri("", false, "A1689ProdExportacion", A1689ProdExportacion);
            A906ProdAfecICBPER = T007K3_A906ProdAfecICBPER[0];
            AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
            A907ProdValICBPER = T007K3_A907ProdValICBPER[0];
            AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
            A908ProdValICBPERD = T007K3_A908ProdValICBPERD[0];
            AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
            A52LinCod = T007K3_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            A51SublCod = T007K3_A51SublCod[0];
            n51SublCod = T007K3_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            A50FamCod = T007K3_A50FamCod[0];
            n50FamCod = T007K3_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            A49UniCod = T007K3_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            A47CBSuCod = T007K3_A47CBSuCod[0];
            n47CBSuCod = T007K3_n47CBSuCod[0];
            AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
            A46cDetCod = T007K3_A46cDetCod[0];
            n46cDetCod = T007K3_n46cDetCod[0];
            AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
            A48ProdCuentaV = T007K3_A48ProdCuentaV[0];
            n48ProdCuentaV = T007K3_n48ProdCuentaV[0];
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            A53ProdCuentaC = T007K3_A53ProdCuentaC[0];
            n53ProdCuentaC = T007K3_n53ProdCuentaC[0];
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            A54ProdCuentaA = T007K3_A54ProdCuentaA[0];
            n54ProdCuentaA = T007K3_n54ProdCuentaA[0];
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            A1695ProdFoto = T007K3_A1695ProdFoto[0];
            n1695ProdFoto = T007K3_n1695ProdFoto[0];
            AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            Z28ProdCod = A28ProdCod;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7K44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey7K44( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey7K44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7K44( ) ;
         if ( RcdFound44 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound44 = 0;
         /* Using cursor T007K24 */
         pr_default.execute(22, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T007K24_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T007K24_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               A28ProdCod = T007K24_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T007K25 */
         pr_default.execute(23, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( StringUtil.StrCmp(T007K25_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( StringUtil.StrCmp(T007K25_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               A28ProdCod = T007K25_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7K44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7K44( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
               {
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7K44( ) ;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7K44( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7K44( ) ;
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
         if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
         {
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7K44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007K2 */
            pr_default.execute(0, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z55ProdDsc, T007K2_A55ProdDsc[0]) != 0 ) || ( Z1724ProdVta != T007K2_A1724ProdVta[0] ) || ( Z1679ProdCmp != T007K2_A1679ProdCmp[0] ) || ( Z1702ProdPeso != T007K2_A1702ProdPeso[0] ) || ( Z1723ProdVolumen != T007K2_A1723ProdVolumen[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1716ProdStkMax != T007K2_A1716ProdStkMax[0] ) || ( Z1717ProdStkMin != T007K2_A1717ProdStkMin[0] ) || ( StringUtil.StrCmp(Z1705ProdRef1, T007K2_A1705ProdRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1707ProdRef2, T007K2_A1707ProdRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1708ProdRef3, T007K2_A1708ProdRef3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1709ProdRef4, T007K2_A1709ProdRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1710ProdRef5, T007K2_A1710ProdRef5[0]) != 0 ) || ( StringUtil.StrCmp(Z1711ProdRef6, T007K2_A1711ProdRef6[0]) != 0 ) || ( StringUtil.StrCmp(Z1712ProdRef7, T007K2_A1712ProdRef7[0]) != 0 ) || ( StringUtil.StrCmp(Z1713ProdRef8, T007K2_A1713ProdRef8[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1714ProdRef9, T007K2_A1714ProdRef9[0]) != 0 ) || ( StringUtil.StrCmp(Z1706ProdRef10, T007K2_A1706ProdRef10[0]) != 0 ) || ( Z1718ProdSts != T007K2_A1718ProdSts[0] ) || ( Z1681ProdCosto != T007K2_A1681ProdCosto[0] ) || ( DateTimeUtil.ResetTime ( Z1683ProdCostoFec ) != DateTimeUtil.ResetTime ( T007K2_A1683ProdCostoFec[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1682ProdCostoD != T007K2_A1682ProdCostoD[0] ) || ( Z1698ProdIna != T007K2_A1698ProdIna[0] ) || ( Z1703ProdPorSel != T007K2_A1703ProdPorSel[0] ) || ( Z1697ProdImpSel != T007K2_A1697ProdImpSel[0] ) || ( Z1672ProdAdValor != T007K2_A1672ProdAdValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1696ProdFrecuente != T007K2_A1696ProdFrecuente[0] ) || ( StringUtil.StrCmp(Z1721ProdUsuCod, T007K2_A1721ProdUsuCod[0]) != 0 ) || ( Z1722ProdUsuFec != T007K2_A1722ProdUsuFec[0] ) || ( Z1673ProdAfec != T007K2_A1673ProdAfec[0] ) || ( StringUtil.StrCmp(Z1701ProdObs, T007K2_A1701ProdObs[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1675ProdCanLote != T007K2_A1675ProdCanLote[0] ) || ( StringUtil.StrCmp(Z1674ProdBarra, T007K2_A1674ProdBarra[0]) != 0 ) || ( StringUtil.StrCmp(Z1689ProdExportacion, T007K2_A1689ProdExportacion[0]) != 0 ) || ( Z906ProdAfecICBPER != T007K2_A906ProdAfecICBPER[0] ) || ( Z907ProdValICBPER != T007K2_A907ProdValICBPER[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z908ProdValICBPERD != T007K2_A908ProdValICBPERD[0] ) || ( Z52LinCod != T007K2_A52LinCod[0] ) || ( Z51SublCod != T007K2_A51SublCod[0] ) || ( Z50FamCod != T007K2_A50FamCod[0] ) || ( Z49UniCod != T007K2_A49UniCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z47CBSuCod, T007K2_A47CBSuCod[0]) != 0 ) || ( Z46cDetCod != T007K2_A46cDetCod[0] ) || ( StringUtil.StrCmp(Z48ProdCuentaV, T007K2_A48ProdCuentaV[0]) != 0 ) || ( StringUtil.StrCmp(Z53ProdCuentaC, T007K2_A53ProdCuentaC[0]) != 0 ) || ( StringUtil.StrCmp(Z54ProdCuentaA, T007K2_A54ProdCuentaA[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z55ProdDsc, T007K2_A55ProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z55ProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A55ProdDsc[0]);
               }
               if ( Z1724ProdVta != T007K2_A1724ProdVta[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdVta");
                  GXUtil.WriteLogRaw("Old: ",Z1724ProdVta);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1724ProdVta[0]);
               }
               if ( Z1679ProdCmp != T007K2_A1679ProdCmp[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCmp");
                  GXUtil.WriteLogRaw("Old: ",Z1679ProdCmp);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1679ProdCmp[0]);
               }
               if ( Z1702ProdPeso != T007K2_A1702ProdPeso[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdPeso");
                  GXUtil.WriteLogRaw("Old: ",Z1702ProdPeso);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1702ProdPeso[0]);
               }
               if ( Z1723ProdVolumen != T007K2_A1723ProdVolumen[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdVolumen");
                  GXUtil.WriteLogRaw("Old: ",Z1723ProdVolumen);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1723ProdVolumen[0]);
               }
               if ( Z1716ProdStkMax != T007K2_A1716ProdStkMax[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdStkMax");
                  GXUtil.WriteLogRaw("Old: ",Z1716ProdStkMax);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1716ProdStkMax[0]);
               }
               if ( Z1717ProdStkMin != T007K2_A1717ProdStkMin[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdStkMin");
                  GXUtil.WriteLogRaw("Old: ",Z1717ProdStkMin);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1717ProdStkMin[0]);
               }
               if ( StringUtil.StrCmp(Z1705ProdRef1, T007K2_A1705ProdRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1705ProdRef1);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1705ProdRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1707ProdRef2, T007K2_A1707ProdRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1707ProdRef2);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1707ProdRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1708ProdRef3, T007K2_A1708ProdRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1708ProdRef3);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1708ProdRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1709ProdRef4, T007K2_A1709ProdRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1709ProdRef4);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1709ProdRef4[0]);
               }
               if ( StringUtil.StrCmp(Z1710ProdRef5, T007K2_A1710ProdRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef5");
                  GXUtil.WriteLogRaw("Old: ",Z1710ProdRef5);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1710ProdRef5[0]);
               }
               if ( StringUtil.StrCmp(Z1711ProdRef6, T007K2_A1711ProdRef6[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef6");
                  GXUtil.WriteLogRaw("Old: ",Z1711ProdRef6);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1711ProdRef6[0]);
               }
               if ( StringUtil.StrCmp(Z1712ProdRef7, T007K2_A1712ProdRef7[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef7");
                  GXUtil.WriteLogRaw("Old: ",Z1712ProdRef7);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1712ProdRef7[0]);
               }
               if ( StringUtil.StrCmp(Z1713ProdRef8, T007K2_A1713ProdRef8[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef8");
                  GXUtil.WriteLogRaw("Old: ",Z1713ProdRef8);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1713ProdRef8[0]);
               }
               if ( StringUtil.StrCmp(Z1714ProdRef9, T007K2_A1714ProdRef9[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef9");
                  GXUtil.WriteLogRaw("Old: ",Z1714ProdRef9);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1714ProdRef9[0]);
               }
               if ( StringUtil.StrCmp(Z1706ProdRef10, T007K2_A1706ProdRef10[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdRef10");
                  GXUtil.WriteLogRaw("Old: ",Z1706ProdRef10);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1706ProdRef10[0]);
               }
               if ( Z1718ProdSts != T007K2_A1718ProdSts[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdSts");
                  GXUtil.WriteLogRaw("Old: ",Z1718ProdSts);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1718ProdSts[0]);
               }
               if ( Z1681ProdCosto != T007K2_A1681ProdCosto[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1681ProdCosto);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1681ProdCosto[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1683ProdCostoFec ) != DateTimeUtil.ResetTime ( T007K2_A1683ProdCostoFec[0] ) )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCostoFec");
                  GXUtil.WriteLogRaw("Old: ",Z1683ProdCostoFec);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1683ProdCostoFec[0]);
               }
               if ( Z1682ProdCostoD != T007K2_A1682ProdCostoD[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCostoD");
                  GXUtil.WriteLogRaw("Old: ",Z1682ProdCostoD);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1682ProdCostoD[0]);
               }
               if ( Z1698ProdIna != T007K2_A1698ProdIna[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdIna");
                  GXUtil.WriteLogRaw("Old: ",Z1698ProdIna);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1698ProdIna[0]);
               }
               if ( Z1703ProdPorSel != T007K2_A1703ProdPorSel[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdPorSel");
                  GXUtil.WriteLogRaw("Old: ",Z1703ProdPorSel);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1703ProdPorSel[0]);
               }
               if ( Z1697ProdImpSel != T007K2_A1697ProdImpSel[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdImpSel");
                  GXUtil.WriteLogRaw("Old: ",Z1697ProdImpSel);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1697ProdImpSel[0]);
               }
               if ( Z1672ProdAdValor != T007K2_A1672ProdAdValor[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdAdValor");
                  GXUtil.WriteLogRaw("Old: ",Z1672ProdAdValor);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1672ProdAdValor[0]);
               }
               if ( Z1696ProdFrecuente != T007K2_A1696ProdFrecuente[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdFrecuente");
                  GXUtil.WriteLogRaw("Old: ",Z1696ProdFrecuente);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1696ProdFrecuente[0]);
               }
               if ( StringUtil.StrCmp(Z1721ProdUsuCod, T007K2_A1721ProdUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1721ProdUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1721ProdUsuCod[0]);
               }
               if ( Z1722ProdUsuFec != T007K2_A1722ProdUsuFec[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1722ProdUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1722ProdUsuFec[0]);
               }
               if ( Z1673ProdAfec != T007K2_A1673ProdAfec[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdAfec");
                  GXUtil.WriteLogRaw("Old: ",Z1673ProdAfec);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1673ProdAfec[0]);
               }
               if ( StringUtil.StrCmp(Z1701ProdObs, T007K2_A1701ProdObs[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdObs");
                  GXUtil.WriteLogRaw("Old: ",Z1701ProdObs);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1701ProdObs[0]);
               }
               if ( Z1675ProdCanLote != T007K2_A1675ProdCanLote[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCanLote");
                  GXUtil.WriteLogRaw("Old: ",Z1675ProdCanLote);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1675ProdCanLote[0]);
               }
               if ( StringUtil.StrCmp(Z1674ProdBarra, T007K2_A1674ProdBarra[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdBarra");
                  GXUtil.WriteLogRaw("Old: ",Z1674ProdBarra);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1674ProdBarra[0]);
               }
               if ( StringUtil.StrCmp(Z1689ProdExportacion, T007K2_A1689ProdExportacion[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdExportacion");
                  GXUtil.WriteLogRaw("Old: ",Z1689ProdExportacion);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A1689ProdExportacion[0]);
               }
               if ( Z906ProdAfecICBPER != T007K2_A906ProdAfecICBPER[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdAfecICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z906ProdAfecICBPER);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A906ProdAfecICBPER[0]);
               }
               if ( Z907ProdValICBPER != T007K2_A907ProdValICBPER[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdValICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z907ProdValICBPER);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A907ProdValICBPER[0]);
               }
               if ( Z908ProdValICBPERD != T007K2_A908ProdValICBPERD[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdValICBPERD");
                  GXUtil.WriteLogRaw("Old: ",Z908ProdValICBPERD);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A908ProdValICBPERD[0]);
               }
               if ( Z52LinCod != T007K2_A52LinCod[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"LinCod");
                  GXUtil.WriteLogRaw("Old: ",Z52LinCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A52LinCod[0]);
               }
               if ( Z51SublCod != T007K2_A51SublCod[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"SublCod");
                  GXUtil.WriteLogRaw("Old: ",Z51SublCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A51SublCod[0]);
               }
               if ( Z50FamCod != T007K2_A50FamCod[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"FamCod");
                  GXUtil.WriteLogRaw("Old: ",Z50FamCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A50FamCod[0]);
               }
               if ( Z49UniCod != T007K2_A49UniCod[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"UniCod");
                  GXUtil.WriteLogRaw("Old: ",Z49UniCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A49UniCod[0]);
               }
               if ( StringUtil.StrCmp(Z47CBSuCod, T007K2_A47CBSuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"CBSuCod");
                  GXUtil.WriteLogRaw("Old: ",Z47CBSuCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A47CBSuCod[0]);
               }
               if ( Z46cDetCod != T007K2_A46cDetCod[0] )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"cDetCod");
                  GXUtil.WriteLogRaw("Old: ",Z46cDetCod);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A46cDetCod[0]);
               }
               if ( StringUtil.StrCmp(Z48ProdCuentaV, T007K2_A48ProdCuentaV[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCuentaV");
                  GXUtil.WriteLogRaw("Old: ",Z48ProdCuentaV);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A48ProdCuentaV[0]);
               }
               if ( StringUtil.StrCmp(Z53ProdCuentaC, T007K2_A53ProdCuentaC[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCuentaC");
                  GXUtil.WriteLogRaw("Old: ",Z53ProdCuentaC);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A53ProdCuentaC[0]);
               }
               if ( StringUtil.StrCmp(Z54ProdCuentaA, T007K2_A54ProdCuentaA[0]) != 0 )
               {
                  GXUtil.WriteLog("almacen.productos:[seudo value changed for attri]"+"ProdCuentaA");
                  GXUtil.WriteLogRaw("Old: ",Z54ProdCuentaA);
                  GXUtil.WriteLogRaw("Current: ",T007K2_A54ProdCuentaA[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APRODUCTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7K44( )
      {
         BeforeValidate7K44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7K44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7K44( 0) ;
            CheckOptimisticConcurrency7K44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7K44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7K44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007K26 */
                     pr_default.execute(24, new Object[] {A28ProdCod, A55ProdDsc, A1724ProdVta, A1679ProdCmp, A1702ProdPeso, A1723ProdVolumen, A1716ProdStkMax, A1717ProdStkMin, n1695ProdFoto, A1695ProdFoto, n40000ProdFoto_GXI, A40000ProdFoto_GXI, A1705ProdRef1, A1707ProdRef2, A1708ProdRef3, A1709ProdRef4, A1710ProdRef5, A1711ProdRef6, A1712ProdRef7, A1713ProdRef8, A1714ProdRef9, A1706ProdRef10, A1718ProdSts, A1681ProdCosto, A1683ProdCostoFec, A1682ProdCostoD, A1698ProdIna, A1703ProdPorSel, A1697ProdImpSel, A1672ProdAdValor, A1696ProdFrecuente, A1721ProdUsuCod, A1722ProdUsuFec, A1673ProdAfec, A1701ProdObs, A1675ProdCanLote, A1674ProdBarra, A1689ProdExportacion, A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD, A52LinCod, n51SublCod, A51SublCod, n50FamCod, A50FamCod, A49UniCod, n47CBSuCod, A47CBSuCod, n46cDetCod, A46cDetCod, n48ProdCuentaV, A48ProdCuentaV, n53ProdCuentaC, A53ProdCuentaC, n54ProdCuentaA, A54ProdCuentaA});
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(24) == 1) )
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
                           ResetCaption7K0( ) ;
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
               Load7K44( ) ;
            }
            EndLevel7K44( ) ;
         }
         CloseExtendedTableCursors7K44( ) ;
      }

      protected void Update7K44( )
      {
         BeforeValidate7K44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7K44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7K44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7K44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7K44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007K27 */
                     pr_default.execute(25, new Object[] {A55ProdDsc, A1724ProdVta, A1679ProdCmp, A1702ProdPeso, A1723ProdVolumen, A1716ProdStkMax, A1717ProdStkMin, A1705ProdRef1, A1707ProdRef2, A1708ProdRef3, A1709ProdRef4, A1710ProdRef5, A1711ProdRef6, A1712ProdRef7, A1713ProdRef8, A1714ProdRef9, A1706ProdRef10, A1718ProdSts, A1681ProdCosto, A1683ProdCostoFec, A1682ProdCostoD, A1698ProdIna, A1703ProdPorSel, A1697ProdImpSel, A1672ProdAdValor, A1696ProdFrecuente, A1721ProdUsuCod, A1722ProdUsuFec, A1673ProdAfec, A1701ProdObs, A1675ProdCanLote, A1674ProdBarra, A1689ProdExportacion, A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD, A52LinCod, n51SublCod, A51SublCod, n50FamCod, A50FamCod, A49UniCod, n47CBSuCod, A47CBSuCod, n46cDetCod, A46cDetCod, n48ProdCuentaV, A48ProdCuentaV, n53ProdCuentaC, A53ProdCuentaC, n54ProdCuentaA, A54ProdCuentaA, A28ProdCod});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7K44( ) ;
                     if ( AnyError == 0 )
                     {
                        new aproductosupdateredundancy(context ).execute( ref  A28ProdCod) ;
                        AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
            EndLevel7K44( ) ;
         }
         CloseExtendedTableCursors7K44( ) ;
      }

      protected void DeferredUpdate7K44( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T007K28 */
            pr_default.execute(26, new Object[] {n1695ProdFoto, A1695ProdFoto, n40000ProdFoto_GXI, A40000ProdFoto_GXI, A28ProdCod});
            pr_default.close(26);
            dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
         }
      }

      protected void delete( )
      {
         BeforeValidate7K44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7K44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7K44( ) ;
            AfterConfirm7K44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7K44( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007K29 */
                  pr_default.execute(27, new Object[] {A28ProdCod});
                  pr_default.close(27);
                  dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7K44( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7K44( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007K30 */
            pr_default.execute(28, new Object[] {A52LinCod});
            A1153LinDsc = T007K30_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            pr_default.close(28);
            A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
            AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
            /* Using cursor T007K31 */
            pr_default.execute(29, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
            A1686ProdCuentaVDsc = T007K31_A1686ProdCuentaVDsc[0];
            AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
            pr_default.close(29);
            /* Using cursor T007K32 */
            pr_default.execute(30, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
            A1685ProdCuentaCDsc = T007K32_A1685ProdCuentaCDsc[0];
            AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
            pr_default.close(30);
            /* Using cursor T007K33 */
            pr_default.execute(31, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
            A1684ProdCuentaADsc = T007K33_A1684ProdCuentaADsc[0];
            AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
            pr_default.close(31);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007K34 */
            pr_default.execute(32, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Materias Primas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T007K35 */
            pr_default.execute(33, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Gastos de Fabricación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T007K36 */
            pr_default.execute(34, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POSERVICIODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T007K37 */
            pr_default.execute(35, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Servicio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T007K38 */
            pr_default.execute(36, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Plan de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T007K39 */
            pr_default.execute(37, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T007K40 */
            pr_default.execute(38, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T007K41 */
            pr_default.execute(39, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZADET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T007K42 */
            pr_default.execute(40, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T007K43 */
            pr_default.execute(41, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sabana de Compras "}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T007K44 */
            pr_default.execute(42, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T007K45 */
            pr_default.execute(43, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T007K46 */
            pr_default.execute(44, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T007K47 */
            pr_default.execute(45, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T007K48 */
            pr_default.execute(46, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Detalle Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T007K49 */
            pr_default.execute(47, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Sub Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T007K50 */
            pr_default.execute(48, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldo Mensual de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor T007K51 */
            pr_default.execute(49, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor T007K52 */
            pr_default.execute(50, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Orden de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor T007K53 */
            pr_default.execute(51, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ventas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor T007K54 */
            pr_default.execute(52, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor T007K55 */
            pr_default.execute(53, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor T007K56 */
            pr_default.execute(54, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
            /* Using cursor T007K57 */
            pr_default.execute(55, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(55) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(55);
            /* Using cursor T007K58 */
            pr_default.execute(56, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(56) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov Almacen Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(56);
            /* Using cursor T007K59 */
            pr_default.execute(57, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(57) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLPEDIDOSDETLOTE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(57);
            /* Using cursor T007K60 */
            pr_default.execute(58, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(58) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(58);
            /* Using cursor T007K61 */
            pr_default.execute(59, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(59) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos Unidades de Medida"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(59);
            /* Using cursor T007K62 */
            pr_default.execute(60, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(60) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"+" ("+"Producto en Formula"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(60);
            /* Using cursor T007K63 */
            pr_default.execute(61, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(61) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(61);
            /* Using cursor T007K64 */
            pr_default.execute(62, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(62) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"+" ("+"Productos Equivalentes"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(62);
            /* Using cursor T007K65 */
            pr_default.execute(63, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(63) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(63);
            /* Using cursor T007K66 */
            pr_default.execute(64, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(64) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(64);
         }
      }

      protected void EndLevel7K44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7K44( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(31);
            context.CommitDataStores("almacen.productos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(31);
            context.RollbackDataStores("almacen.productos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7K44( )
      {
         /* Scan By routine */
         /* Using cursor T007K67 */
         pr_default.execute(65);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T007K67_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7K44( )
      {
         /* Scan next routine */
         pr_default.readNext(65);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T007K67_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
      }

      protected void ScanEnd7K44( )
      {
         pr_default.close(65);
      }

      protected void AfterConfirm7K44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7K44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7K44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7K44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7K44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7K44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7K44( )
      {
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtLinCod_Enabled = 0;
         AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtSublCod_Enabled = 0;
         AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         edtFamCod_Enabled = 0;
         AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         edtUniCod_Enabled = 0;
         AssignProp("", false, edtUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniCod_Enabled), 5, 0), true);
         chkProdVta.Enabled = 0;
         AssignProp("", false, chkProdVta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProdVta.Enabled), 5, 0), true);
         chkProdCmp.Enabled = 0;
         AssignProp("", false, chkProdCmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProdCmp.Enabled), 5, 0), true);
         edtProdPeso_Enabled = 0;
         AssignProp("", false, edtProdPeso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdPeso_Enabled), 5, 0), true);
         edtProdVolumen_Enabled = 0;
         AssignProp("", false, edtProdVolumen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdVolumen_Enabled), 5, 0), true);
         edtProdStkMax_Enabled = 0;
         AssignProp("", false, edtProdStkMax_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdStkMax_Enabled), 5, 0), true);
         edtProdStkMin_Enabled = 0;
         AssignProp("", false, edtProdStkMin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdStkMin_Enabled), 5, 0), true);
         imgProdFoto_Enabled = 0;
         AssignProp("", false, imgProdFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProdFoto_Enabled), 5, 0), true);
         edtProdRef1_Enabled = 0;
         AssignProp("", false, edtProdRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef1_Enabled), 5, 0), true);
         edtProdRef2_Enabled = 0;
         AssignProp("", false, edtProdRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef2_Enabled), 5, 0), true);
         edtProdRef3_Enabled = 0;
         AssignProp("", false, edtProdRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef3_Enabled), 5, 0), true);
         edtProdRef4_Enabled = 0;
         AssignProp("", false, edtProdRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef4_Enabled), 5, 0), true);
         edtProdRef5_Enabled = 0;
         AssignProp("", false, edtProdRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef5_Enabled), 5, 0), true);
         edtProdRef6_Enabled = 0;
         AssignProp("", false, edtProdRef6_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef6_Enabled), 5, 0), true);
         edtProdRef7_Enabled = 0;
         AssignProp("", false, edtProdRef7_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef7_Enabled), 5, 0), true);
         edtProdRef8_Enabled = 0;
         AssignProp("", false, edtProdRef8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef8_Enabled), 5, 0), true);
         edtProdRef9_Enabled = 0;
         AssignProp("", false, edtProdRef9_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef9_Enabled), 5, 0), true);
         edtProdRef10_Enabled = 0;
         AssignProp("", false, edtProdRef10_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef10_Enabled), 5, 0), true);
         cmbProdSts.Enabled = 0;
         AssignProp("", false, cmbProdSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProdSts.Enabled), 5, 0), true);
         edtProdCosto_Enabled = 0;
         AssignProp("", false, edtProdCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCosto_Enabled), 5, 0), true);
         edtProdCostoFec_Enabled = 0;
         AssignProp("", false, edtProdCostoFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCostoFec_Enabled), 5, 0), true);
         edtProdCostoD_Enabled = 0;
         AssignProp("", false, edtProdCostoD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCostoD_Enabled), 5, 0), true);
         edtProdIna_Enabled = 0;
         AssignProp("", false, edtProdIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdIna_Enabled), 5, 0), true);
         edtProdPorSel_Enabled = 0;
         AssignProp("", false, edtProdPorSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdPorSel_Enabled), 5, 0), true);
         edtProdImpSel_Enabled = 0;
         AssignProp("", false, edtProdImpSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdImpSel_Enabled), 5, 0), true);
         edtProdAdValor_Enabled = 0;
         AssignProp("", false, edtProdAdValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdAdValor_Enabled), 5, 0), true);
         edtProdReferencias_Enabled = 0;
         AssignProp("", false, edtProdReferencias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdReferencias_Enabled), 5, 0), true);
         edtProdFrecuente_Enabled = 0;
         AssignProp("", false, edtProdFrecuente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdFrecuente_Enabled), 5, 0), true);
         edtProdCuentaV_Enabled = 0;
         AssignProp("", false, edtProdCuentaV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaV_Enabled), 5, 0), true);
         edtProdCuentaVDsc_Enabled = 0;
         AssignProp("", false, edtProdCuentaVDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaVDsc_Enabled), 5, 0), true);
         edtProdCuentaC_Enabled = 0;
         AssignProp("", false, edtProdCuentaC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaC_Enabled), 5, 0), true);
         edtProdCuentaCDsc_Enabled = 0;
         AssignProp("", false, edtProdCuentaCDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaCDsc_Enabled), 5, 0), true);
         edtProdCuentaA_Enabled = 0;
         AssignProp("", false, edtProdCuentaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaA_Enabled), 5, 0), true);
         edtProdCuentaADsc_Enabled = 0;
         AssignProp("", false, edtProdCuentaADsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaADsc_Enabled), 5, 0), true);
         edtProdUsuCod_Enabled = 0;
         AssignProp("", false, edtProdUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdUsuCod_Enabled), 5, 0), true);
         edtProdUsuFec_Enabled = 0;
         AssignProp("", false, edtProdUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdUsuFec_Enabled), 5, 0), true);
         edtProdAfec_Enabled = 0;
         AssignProp("", false, edtProdAfec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdAfec_Enabled), 5, 0), true);
         edtProdObs_Enabled = 0;
         AssignProp("", false, edtProdObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdObs_Enabled), 5, 0), true);
         edtProdCanLote_Enabled = 0;
         AssignProp("", false, edtProdCanLote_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCanLote_Enabled), 5, 0), true);
         edtProdBarra_Enabled = 0;
         AssignProp("", false, edtProdBarra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdBarra_Enabled), 5, 0), true);
         edtProdExportacion_Enabled = 0;
         AssignProp("", false, edtProdExportacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdExportacion_Enabled), 5, 0), true);
         edtCBSuCod_Enabled = 0;
         AssignProp("", false, edtCBSuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBSuCod_Enabled), 5, 0), true);
         edtProdAfecICBPER_Enabled = 0;
         AssignProp("", false, edtProdAfecICBPER_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdAfecICBPER_Enabled), 5, 0), true);
         edtProdValICBPER_Enabled = 0;
         AssignProp("", false, edtProdValICBPER_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdValICBPER_Enabled), 5, 0), true);
         edtProdValICBPERD_Enabled = 0;
         AssignProp("", false, edtProdValICBPERD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdValICBPERD_Enabled), 5, 0), true);
         edtcDetCod_Enabled = 0;
         AssignProp("", false, edtcDetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcDetCod_Enabled), 5, 0), true);
         edtLinDsc_Enabled = 0;
         AssignProp("", false, edtLinDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinDsc_Enabled), 5, 0), true);
         edtavCombolincod_Enabled = 0;
         AssignProp("", false, edtavCombolincod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombolincod_Enabled), 5, 0), true);
         edtavCombosublcod_Enabled = 0;
         AssignProp("", false, edtavCombosublcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosublcod_Enabled), 5, 0), true);
         edtavCombofamcod_Enabled = 0;
         AssignProp("", false, edtavCombofamcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombofamcod_Enabled), 5, 0), true);
         edtavCombounicod_Enabled = 0;
         AssignProp("", false, edtavCombounicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombounicod_Enabled), 5, 0), true);
         edtavComboprodcuentav_Enabled = 0;
         AssignProp("", false, edtavComboprodcuentav_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentav_Enabled), 5, 0), true);
         edtavComboprodcuentac_Enabled = 0;
         AssignProp("", false, edtavComboprodcuentac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentac_Enabled), 5, 0), true);
         edtavComboprodcuentaa_Enabled = 0;
         AssignProp("", false, edtavComboprodcuentaa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprodcuentaa_Enabled), 5, 0), true);
         edtavCombocbsucod_Enabled = 0;
         AssignProp("", false, edtavCombocbsucod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocbsucod_Enabled), 5, 0), true);
         edtavCombocdetcod_Enabled = 0;
         AssignProp("", false, edtavCombocdetcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocdetcod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7K44( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7K0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181028044", false, true);
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
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ProdCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Productos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("almacen\\productos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1724ProdVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1724ProdVta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1679ProdCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1679ProdCmp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1702ProdPeso", StringUtil.LTrim( StringUtil.NToC( Z1702ProdPeso, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1723ProdVolumen", StringUtil.LTrim( StringUtil.NToC( Z1723ProdVolumen, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1716ProdStkMax", StringUtil.LTrim( StringUtil.NToC( Z1716ProdStkMax, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1717ProdStkMin", StringUtil.LTrim( StringUtil.NToC( Z1717ProdStkMin, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1705ProdRef1", StringUtil.RTrim( Z1705ProdRef1));
         GxWebStd.gx_hidden_field( context, "Z1707ProdRef2", StringUtil.RTrim( Z1707ProdRef2));
         GxWebStd.gx_hidden_field( context, "Z1708ProdRef3", StringUtil.RTrim( Z1708ProdRef3));
         GxWebStd.gx_hidden_field( context, "Z1709ProdRef4", StringUtil.RTrim( Z1709ProdRef4));
         GxWebStd.gx_hidden_field( context, "Z1710ProdRef5", StringUtil.RTrim( Z1710ProdRef5));
         GxWebStd.gx_hidden_field( context, "Z1711ProdRef6", StringUtil.RTrim( Z1711ProdRef6));
         GxWebStd.gx_hidden_field( context, "Z1712ProdRef7", StringUtil.RTrim( Z1712ProdRef7));
         GxWebStd.gx_hidden_field( context, "Z1713ProdRef8", StringUtil.RTrim( Z1713ProdRef8));
         GxWebStd.gx_hidden_field( context, "Z1714ProdRef9", StringUtil.RTrim( Z1714ProdRef9));
         GxWebStd.gx_hidden_field( context, "Z1706ProdRef10", StringUtil.RTrim( Z1706ProdRef10));
         GxWebStd.gx_hidden_field( context, "Z1718ProdSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1718ProdSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1681ProdCosto", StringUtil.LTrim( StringUtil.NToC( Z1681ProdCosto, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1683ProdCostoFec", context.localUtil.DToC( Z1683ProdCostoFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1682ProdCostoD", StringUtil.LTrim( StringUtil.NToC( Z1682ProdCostoD, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1698ProdIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1698ProdIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( Z1703ProdPorSel, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1697ProdImpSel", StringUtil.LTrim( StringUtil.NToC( Z1697ProdImpSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1672ProdAdValor", StringUtil.LTrim( StringUtil.NToC( Z1672ProdAdValor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1696ProdFrecuente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1696ProdFrecuente), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1721ProdUsuCod", StringUtil.RTrim( Z1721ProdUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1722ProdUsuFec", context.localUtil.TToC( Z1722ProdUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1673ProdAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1673ProdAfec), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1701ProdObs", Z1701ProdObs);
         GxWebStd.gx_hidden_field( context, "Z1675ProdCanLote", StringUtil.LTrim( StringUtil.NToC( Z1675ProdCanLote, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1674ProdBarra", Z1674ProdBarra);
         GxWebStd.gx_hidden_field( context, "Z1689ProdExportacion", Z1689ProdExportacion);
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z47CBSuCod", Z47CBSuCod);
         GxWebStd.gx_hidden_field( context, "Z46cDetCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46cDetCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z48ProdCuentaV", StringUtil.RTrim( Z48ProdCuentaV));
         GxWebStd.gx_hidden_field( context, "Z53ProdCuentaC", StringUtil.RTrim( Z53ProdCuentaC));
         GxWebStd.gx_hidden_field( context, "Z54ProdCuentaA", StringUtil.RTrim( Z54ProdCuentaA));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N48ProdCuentaV", StringUtil.RTrim( A48ProdCuentaV));
         GxWebStd.gx_hidden_field( context, "N53ProdCuentaC", StringUtil.RTrim( A53ProdCuentaC));
         GxWebStd.gx_hidden_field( context, "N54ProdCuentaA", StringUtil.RTrim( A54ProdCuentaA));
         GxWebStd.gx_hidden_field( context, "N47CBSuCod", A47CBSuCod);
         GxWebStd.gx_hidden_field( context, "N46cDetCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A46cDetCod), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLINCOD_DATA", AV21LinCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLINCOD_DATA", AV21LinCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUBLCOD_DATA", AV27SublCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUBLCOD_DATA", AV27SublCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAMCOD_DATA", AV29FamCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAMCOD_DATA", AV29FamCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUNICOD_DATA", AV31UniCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUNICOD_DATA", AV31UniCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODCUENTAV_DATA", AV33ProdCuentaV_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODCUENTAV_DATA", AV33ProdCuentaV_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODCUENTAC_DATA", AV36ProdCuentaC_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODCUENTAC_DATA", AV36ProdCuentaC_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODCUENTAA_DATA", AV38ProdCuentaA_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODCUENTAA_DATA", AV38ProdCuentaA_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCBSUCOD_DATA", AV40CBSuCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCBSUCOD_DATA", AV40CBSuCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCDETCOD_DATA", AV42cDetCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCDETCOD_DATA", AV42cDetCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vPRODCOD", StringUtil.RTrim( AV7ProdCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProdCod, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_LINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUBLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_FAMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_UNICOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODCUENTAV", StringUtil.RTrim( AV15Insert_ProdCuentaV));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODCUENTAC", StringUtil.RTrim( AV16Insert_ProdCuentaC));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODCUENTAA", StringUtil.RTrim( AV17Insert_ProdCuentaA));
         GxWebStd.gx_hidden_field( context, "vINSERT_CBSUCOD", AV18Insert_CBSuCod);
         GxWebStd.gx_hidden_field( context, "vINSERT_CDETCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Insert_cDetCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODFOTO_GXI", A40000ProdFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GXCCtlgxBlob = "PRODFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A1695ProdFoto);
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Objectcall", StringUtil.RTrim( Combo_lincod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Cls", StringUtil.RTrim( Combo_lincod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedvalue_set", StringUtil.RTrim( Combo_lincod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Selectedtext_set", StringUtil.RTrim( Combo_lincod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Enabled", StringUtil.BoolToStr( Combo_lincod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Datalistproc", StringUtil.RTrim( Combo_lincod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_lincod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_LINCOD_Emptyitem", StringUtil.BoolToStr( Combo_lincod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Objectcall", StringUtil.RTrim( Combo_sublcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Cls", StringUtil.RTrim( Combo_sublcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedvalue_set", StringUtil.RTrim( Combo_sublcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Selectedtext_set", StringUtil.RTrim( Combo_sublcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Enabled", StringUtil.BoolToStr( Combo_sublcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Datalistproc", StringUtil.RTrim( Combo_sublcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SUBLCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sublcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Objectcall", StringUtil.RTrim( Combo_famcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Cls", StringUtil.RTrim( Combo_famcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Selectedvalue_set", StringUtil.RTrim( Combo_famcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Selectedtext_set", StringUtil.RTrim( Combo_famcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Enabled", StringUtil.BoolToStr( Combo_famcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Datalistproc", StringUtil.RTrim( Combo_famcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_FAMCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_famcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Objectcall", StringUtil.RTrim( Combo_unicod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Cls", StringUtil.RTrim( Combo_unicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Selectedvalue_set", StringUtil.RTrim( Combo_unicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Selectedtext_set", StringUtil.RTrim( Combo_unicod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Enabled", StringUtil.BoolToStr( Combo_unicod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Datalistproc", StringUtil.RTrim( Combo_unicod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_unicod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_UNICOD_Emptyitem", StringUtil.BoolToStr( Combo_unicod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Objectcall", StringUtil.RTrim( Combo_prodcuentav_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Cls", StringUtil.RTrim( Combo_prodcuentav_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Selectedvalue_set", StringUtil.RTrim( Combo_prodcuentav_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Selectedtext_set", StringUtil.RTrim( Combo_prodcuentav_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Enabled", StringUtil.BoolToStr( Combo_prodcuentav_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Datalistproc", StringUtil.RTrim( Combo_prodcuentav_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAV_Datalistprocparametersprefix", StringUtil.RTrim( Combo_prodcuentav_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Objectcall", StringUtil.RTrim( Combo_prodcuentac_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Cls", StringUtil.RTrim( Combo_prodcuentac_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Selectedvalue_set", StringUtil.RTrim( Combo_prodcuentac_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Selectedtext_set", StringUtil.RTrim( Combo_prodcuentac_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Enabled", StringUtil.BoolToStr( Combo_prodcuentac_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Datalistproc", StringUtil.RTrim( Combo_prodcuentac_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAC_Datalistprocparametersprefix", StringUtil.RTrim( Combo_prodcuentac_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Objectcall", StringUtil.RTrim( Combo_prodcuentaa_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Cls", StringUtil.RTrim( Combo_prodcuentaa_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Selectedvalue_set", StringUtil.RTrim( Combo_prodcuentaa_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Selectedtext_set", StringUtil.RTrim( Combo_prodcuentaa_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Enabled", StringUtil.BoolToStr( Combo_prodcuentaa_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Datalistproc", StringUtil.RTrim( Combo_prodcuentaa_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODCUENTAA_Datalistprocparametersprefix", StringUtil.RTrim( Combo_prodcuentaa_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Objectcall", StringUtil.RTrim( Combo_cbsucod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Cls", StringUtil.RTrim( Combo_cbsucod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Selectedvalue_set", StringUtil.RTrim( Combo_cbsucod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Selectedtext_set", StringUtil.RTrim( Combo_cbsucod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Enabled", StringUtil.BoolToStr( Combo_cbsucod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Datalistproc", StringUtil.RTrim( Combo_cbsucod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CBSUCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cbsucod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Objectcall", StringUtil.RTrim( Combo_cdetcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Cls", StringUtil.RTrim( Combo_cdetcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Selectedvalue_set", StringUtil.RTrim( Combo_cdetcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Selectedtext_set", StringUtil.RTrim( Combo_cdetcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Enabled", StringUtil.BoolToStr( Combo_cdetcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Datalistproc", StringUtil.RTrim( Combo_cdetcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CDETCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cdetcod_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ProdCod));
         return formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Almacen.Productos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Productos" ;
      }

      protected void InitializeNonKey7K44( )
      {
         A52LinCod = 0;
         AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         A51SublCod = 0;
         n51SublCod = false;
         AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         n51SublCod = ((0==A51SublCod) ? true : false);
         A50FamCod = 0;
         n50FamCod = false;
         AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         n50FamCod = ((0==A50FamCod) ? true : false);
         A49UniCod = 0;
         AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         A48ProdCuentaV = "";
         n48ProdCuentaV = false;
         AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
         n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
         A53ProdCuentaC = "";
         n53ProdCuentaC = false;
         AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
         n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
         A54ProdCuentaA = "";
         n54ProdCuentaA = false;
         AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
         n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
         A47CBSuCod = "";
         n47CBSuCod = false;
         AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
         n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
         A46cDetCod = 0;
         n46cDetCod = false;
         AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
         n46cDetCod = ((0==A46cDetCod) ? true : false);
         A1715ProdReferencias = "";
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1724ProdVta = 0;
         AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
         A1679ProdCmp = 0;
         AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
         A1702ProdPeso = 0;
         AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
         A1723ProdVolumen = 0;
         AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
         A1716ProdStkMax = 0;
         AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
         A1717ProdStkMin = 0;
         AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
         A1695ProdFoto = "";
         n1695ProdFoto = false;
         AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
         AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
         AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
         n1695ProdFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
         A40000ProdFoto_GXI = "";
         n40000ProdFoto_GXI = false;
         AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
         AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
         A1705ProdRef1 = "";
         AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
         A1707ProdRef2 = "";
         AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
         A1708ProdRef3 = "";
         AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
         A1709ProdRef4 = "";
         AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
         A1710ProdRef5 = "";
         AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
         A1711ProdRef6 = "";
         AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
         A1712ProdRef7 = "";
         AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
         A1713ProdRef8 = "";
         AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
         A1714ProdRef9 = "";
         AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
         A1706ProdRef10 = "";
         AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
         A1718ProdSts = 0;
         AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         A1681ProdCosto = 0;
         AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
         A1683ProdCostoFec = DateTime.MinValue;
         AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
         A1682ProdCostoD = 0;
         AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
         A1698ProdIna = 0;
         AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
         A1703ProdPorSel = 0;
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
         A1697ProdImpSel = 0;
         AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrimStr( A1697ProdImpSel, 15, 2));
         A1672ProdAdValor = 0;
         AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
         A1696ProdFrecuente = 0;
         AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
         A1686ProdCuentaVDsc = "";
         AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
         A1685ProdCuentaCDsc = "";
         AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
         A1684ProdCuentaADsc = "";
         AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
         A1721ProdUsuCod = "";
         AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
         A1722ProdUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1673ProdAfec = 0;
         AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
         A1701ProdObs = "";
         AssignAttri("", false, "A1701ProdObs", A1701ProdObs);
         A1675ProdCanLote = 0;
         AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrimStr( A1675ProdCanLote, 15, 2));
         A1674ProdBarra = "";
         AssignAttri("", false, "A1674ProdBarra", A1674ProdBarra);
         A1689ProdExportacion = "";
         AssignAttri("", false, "A1689ProdExportacion", A1689ProdExportacion);
         A906ProdAfecICBPER = 0;
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
         A907ProdValICBPER = 0;
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
         A908ProdValICBPERD = 0;
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
         A1153LinDsc = "";
         AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
         Z55ProdDsc = "";
         Z1724ProdVta = 0;
         Z1679ProdCmp = 0;
         Z1702ProdPeso = 0;
         Z1723ProdVolumen = 0;
         Z1716ProdStkMax = 0;
         Z1717ProdStkMin = 0;
         Z1705ProdRef1 = "";
         Z1707ProdRef2 = "";
         Z1708ProdRef3 = "";
         Z1709ProdRef4 = "";
         Z1710ProdRef5 = "";
         Z1711ProdRef6 = "";
         Z1712ProdRef7 = "";
         Z1713ProdRef8 = "";
         Z1714ProdRef9 = "";
         Z1706ProdRef10 = "";
         Z1718ProdSts = 0;
         Z1681ProdCosto = 0;
         Z1683ProdCostoFec = DateTime.MinValue;
         Z1682ProdCostoD = 0;
         Z1698ProdIna = 0;
         Z1703ProdPorSel = 0;
         Z1697ProdImpSel = 0;
         Z1672ProdAdValor = 0;
         Z1696ProdFrecuente = 0;
         Z1721ProdUsuCod = "";
         Z1722ProdUsuFec = (DateTime)(DateTime.MinValue);
         Z1673ProdAfec = 0;
         Z1701ProdObs = "";
         Z1675ProdCanLote = 0;
         Z1674ProdBarra = "";
         Z1689ProdExportacion = "";
         Z906ProdAfecICBPER = 0;
         Z907ProdValICBPER = 0;
         Z908ProdValICBPERD = 0;
         Z52LinCod = 0;
         Z51SublCod = 0;
         Z50FamCod = 0;
         Z49UniCod = 0;
         Z47CBSuCod = "";
         Z46cDetCod = 0;
         Z48ProdCuentaV = "";
         Z53ProdCuentaC = "";
         Z54ProdCuentaA = "";
      }

      protected void InitAll7K44( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         InitializeNonKey7K44( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181028291", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("almacen/productos.js", "?20228181028295", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtProdCod_Internalname = "PRODCOD";
         lblTextblocklincod_Internalname = "TEXTBLOCKLINCOD";
         Combo_lincod_Internalname = "COMBO_LINCOD";
         edtLinCod_Internalname = "LINCOD";
         divTablesplittedlincod_Internalname = "TABLESPLITTEDLINCOD";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblocksublcod_Internalname = "TEXTBLOCKSUBLCOD";
         Combo_sublcod_Internalname = "COMBO_SUBLCOD";
         edtSublCod_Internalname = "SUBLCOD";
         divTablesplittedsublcod_Internalname = "TABLESPLITTEDSUBLCOD";
         lblTextblockfamcod_Internalname = "TEXTBLOCKFAMCOD";
         Combo_famcod_Internalname = "COMBO_FAMCOD";
         edtFamCod_Internalname = "FAMCOD";
         divTablesplittedfamcod_Internalname = "TABLESPLITTEDFAMCOD";
         lblTextblockunicod_Internalname = "TEXTBLOCKUNICOD";
         Combo_unicod_Internalname = "COMBO_UNICOD";
         edtUniCod_Internalname = "UNICOD";
         divTablesplittedunicod_Internalname = "TABLESPLITTEDUNICOD";
         chkProdVta_Internalname = "PRODVTA";
         chkProdCmp_Internalname = "PRODCMP";
         edtProdPeso_Internalname = "PRODPESO";
         edtProdVolumen_Internalname = "PRODVOLUMEN";
         edtProdStkMax_Internalname = "PRODSTKMAX";
         edtProdStkMin_Internalname = "PRODSTKMIN";
         imgProdFoto_Internalname = "PRODFOTO";
         edtProdRef1_Internalname = "PRODREF1";
         edtProdRef2_Internalname = "PRODREF2";
         edtProdRef3_Internalname = "PRODREF3";
         edtProdRef4_Internalname = "PRODREF4";
         edtProdRef5_Internalname = "PRODREF5";
         edtProdRef6_Internalname = "PRODREF6";
         edtProdRef7_Internalname = "PRODREF7";
         edtProdRef8_Internalname = "PRODREF8";
         edtProdRef9_Internalname = "PRODREF9";
         edtProdRef10_Internalname = "PRODREF10";
         cmbProdSts_Internalname = "PRODSTS";
         edtProdCosto_Internalname = "PRODCOSTO";
         edtProdCostoFec_Internalname = "PRODCOSTOFEC";
         edtProdCostoD_Internalname = "PRODCOSTOD";
         edtProdIna_Internalname = "PRODINA";
         edtProdPorSel_Internalname = "PRODPORSEL";
         edtProdImpSel_Internalname = "PRODIMPSEL";
         edtProdAdValor_Internalname = "PRODADVALOR";
         edtProdReferencias_Internalname = "PRODREFERENCIAS";
         edtProdFrecuente_Internalname = "PRODFRECUENTE";
         lblTextblockprodcuentav_Internalname = "TEXTBLOCKPRODCUENTAV";
         Combo_prodcuentav_Internalname = "COMBO_PRODCUENTAV";
         edtProdCuentaV_Internalname = "PRODCUENTAV";
         divTablesplittedprodcuentav_Internalname = "TABLESPLITTEDPRODCUENTAV";
         edtProdCuentaVDsc_Internalname = "PRODCUENTAVDSC";
         lblTextblockprodcuentac_Internalname = "TEXTBLOCKPRODCUENTAC";
         Combo_prodcuentac_Internalname = "COMBO_PRODCUENTAC";
         edtProdCuentaC_Internalname = "PRODCUENTAC";
         divTablesplittedprodcuentac_Internalname = "TABLESPLITTEDPRODCUENTAC";
         edtProdCuentaCDsc_Internalname = "PRODCUENTACDSC";
         lblTextblockprodcuentaa_Internalname = "TEXTBLOCKPRODCUENTAA";
         Combo_prodcuentaa_Internalname = "COMBO_PRODCUENTAA";
         edtProdCuentaA_Internalname = "PRODCUENTAA";
         divTablesplittedprodcuentaa_Internalname = "TABLESPLITTEDPRODCUENTAA";
         edtProdCuentaADsc_Internalname = "PRODCUENTAADSC";
         edtProdUsuCod_Internalname = "PRODUSUCOD";
         edtProdUsuFec_Internalname = "PRODUSUFEC";
         edtProdAfec_Internalname = "PRODAFEC";
         edtProdObs_Internalname = "PRODOBS";
         edtProdCanLote_Internalname = "PRODCANLOTE";
         edtProdBarra_Internalname = "PRODBARRA";
         edtProdExportacion_Internalname = "PRODEXPORTACION";
         lblTextblockcbsucod_Internalname = "TEXTBLOCKCBSUCOD";
         Combo_cbsucod_Internalname = "COMBO_CBSUCOD";
         edtCBSuCod_Internalname = "CBSUCOD";
         divTablesplittedcbsucod_Internalname = "TABLESPLITTEDCBSUCOD";
         edtProdAfecICBPER_Internalname = "PRODAFECICBPER";
         edtProdValICBPER_Internalname = "PRODVALICBPER";
         edtProdValICBPERD_Internalname = "PRODVALICBPERD";
         lblTextblockcdetcod_Internalname = "TEXTBLOCKCDETCOD";
         Combo_cdetcod_Internalname = "COMBO_CDETCOD";
         edtcDetCod_Internalname = "CDETCOD";
         divTablesplittedcdetcod_Internalname = "TABLESPLITTEDCDETCOD";
         edtLinDsc_Internalname = "LINDSC";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombolincod_Internalname = "vCOMBOLINCOD";
         divSectionattribute_lincod_Internalname = "SECTIONATTRIBUTE_LINCOD";
         edtavCombosublcod_Internalname = "vCOMBOSUBLCOD";
         divSectionattribute_sublcod_Internalname = "SECTIONATTRIBUTE_SUBLCOD";
         edtavCombofamcod_Internalname = "vCOMBOFAMCOD";
         divSectionattribute_famcod_Internalname = "SECTIONATTRIBUTE_FAMCOD";
         edtavCombounicod_Internalname = "vCOMBOUNICOD";
         divSectionattribute_unicod_Internalname = "SECTIONATTRIBUTE_UNICOD";
         edtavComboprodcuentav_Internalname = "vCOMBOPRODCUENTAV";
         divSectionattribute_prodcuentav_Internalname = "SECTIONATTRIBUTE_PRODCUENTAV";
         edtavComboprodcuentac_Internalname = "vCOMBOPRODCUENTAC";
         divSectionattribute_prodcuentac_Internalname = "SECTIONATTRIBUTE_PRODCUENTAC";
         edtavComboprodcuentaa_Internalname = "vCOMBOPRODCUENTAA";
         divSectionattribute_prodcuentaa_Internalname = "SECTIONATTRIBUTE_PRODCUENTAA";
         edtavCombocbsucod_Internalname = "vCOMBOCBSUCOD";
         divSectionattribute_cbsucod_Internalname = "SECTIONATTRIBUTE_CBSUCOD";
         edtavCombocdetcod_Internalname = "vCOMBOCDETCOD";
         divSectionattribute_cdetcod_Internalname = "SECTIONATTRIBUTE_CDETCOD";
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
         Form.Caption = "Productos";
         edtavCombocdetcod_Jsonclick = "";
         edtavCombocdetcod_Enabled = 0;
         edtavCombocdetcod_Visible = 1;
         edtavCombocbsucod_Jsonclick = "";
         edtavCombocbsucod_Enabled = 0;
         edtavCombocbsucod_Visible = 1;
         edtavComboprodcuentaa_Jsonclick = "";
         edtavComboprodcuentaa_Enabled = 0;
         edtavComboprodcuentaa_Visible = 1;
         edtavComboprodcuentac_Jsonclick = "";
         edtavComboprodcuentac_Enabled = 0;
         edtavComboprodcuentac_Visible = 1;
         edtavComboprodcuentav_Jsonclick = "";
         edtavComboprodcuentav_Enabled = 0;
         edtavComboprodcuentav_Visible = 1;
         edtavCombounicod_Jsonclick = "";
         edtavCombounicod_Enabled = 0;
         edtavCombounicod_Visible = 1;
         edtavCombofamcod_Jsonclick = "";
         edtavCombofamcod_Enabled = 0;
         edtavCombofamcod_Visible = 1;
         edtavCombosublcod_Jsonclick = "";
         edtavCombosublcod_Enabled = 0;
         edtavCombosublcod_Visible = 1;
         edtavCombolincod_Jsonclick = "";
         edtavCombolincod_Enabled = 0;
         edtavCombolincod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLinDsc_Jsonclick = "";
         edtLinDsc_Enabled = 0;
         edtcDetCod_Jsonclick = "";
         edtcDetCod_Enabled = 1;
         edtcDetCod_Visible = 1;
         Combo_cdetcod_Datalistprocparametersprefix = " \"ComboName\": \"cDetCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_cdetcod_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_cdetcod_Cls = "ExtendedCombo Attribute";
         Combo_cdetcod_Caption = "";
         Combo_cdetcod_Enabled = Convert.ToBoolean( -1);
         edtProdValICBPERD_Jsonclick = "";
         edtProdValICBPERD_Enabled = 1;
         edtProdValICBPER_Jsonclick = "";
         edtProdValICBPER_Enabled = 1;
         edtProdAfecICBPER_Jsonclick = "";
         edtProdAfecICBPER_Enabled = 1;
         edtCBSuCod_Jsonclick = "";
         edtCBSuCod_Enabled = 1;
         edtCBSuCod_Visible = 1;
         Combo_cbsucod_Datalistprocparametersprefix = " \"ComboName\": \"CBSuCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_cbsucod_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_cbsucod_Cls = "ExtendedCombo Attribute";
         Combo_cbsucod_Caption = "";
         Combo_cbsucod_Enabled = Convert.ToBoolean( -1);
         edtProdExportacion_Jsonclick = "";
         edtProdExportacion_Enabled = 1;
         edtProdBarra_Jsonclick = "";
         edtProdBarra_Enabled = 1;
         edtProdCanLote_Jsonclick = "";
         edtProdCanLote_Enabled = 1;
         edtProdObs_Enabled = 1;
         edtProdAfec_Jsonclick = "";
         edtProdAfec_Enabled = 1;
         edtProdUsuFec_Jsonclick = "";
         edtProdUsuFec_Enabled = 1;
         edtProdUsuCod_Jsonclick = "";
         edtProdUsuCod_Enabled = 1;
         edtProdCuentaADsc_Jsonclick = "";
         edtProdCuentaADsc_Enabled = 0;
         edtProdCuentaA_Jsonclick = "";
         edtProdCuentaA_Enabled = 1;
         edtProdCuentaA_Visible = 1;
         Combo_prodcuentaa_Datalistprocparametersprefix = " \"ComboName\": \"ProdCuentaA\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_prodcuentaa_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_prodcuentaa_Cls = "ExtendedCombo Attribute";
         Combo_prodcuentaa_Caption = "";
         Combo_prodcuentaa_Enabled = Convert.ToBoolean( -1);
         edtProdCuentaCDsc_Jsonclick = "";
         edtProdCuentaCDsc_Enabled = 0;
         edtProdCuentaC_Jsonclick = "";
         edtProdCuentaC_Enabled = 1;
         edtProdCuentaC_Visible = 1;
         Combo_prodcuentac_Datalistprocparametersprefix = " \"ComboName\": \"ProdCuentaC\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_prodcuentac_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_prodcuentac_Cls = "ExtendedCombo Attribute";
         Combo_prodcuentac_Caption = "";
         Combo_prodcuentac_Enabled = Convert.ToBoolean( -1);
         edtProdCuentaVDsc_Jsonclick = "";
         edtProdCuentaVDsc_Enabled = 0;
         edtProdCuentaV_Jsonclick = "";
         edtProdCuentaV_Enabled = 1;
         edtProdCuentaV_Visible = 1;
         Combo_prodcuentav_Datalistprocparametersprefix = " \"ComboName\": \"ProdCuentaV\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_prodcuentav_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_prodcuentav_Cls = "ExtendedCombo Attribute";
         Combo_prodcuentav_Caption = "";
         Combo_prodcuentav_Enabled = Convert.ToBoolean( -1);
         edtProdFrecuente_Jsonclick = "";
         edtProdFrecuente_Enabled = 1;
         edtProdReferencias_Enabled = 0;
         edtProdAdValor_Jsonclick = "";
         edtProdAdValor_Enabled = 1;
         edtProdImpSel_Jsonclick = "";
         edtProdImpSel_Enabled = 1;
         edtProdPorSel_Jsonclick = "";
         edtProdPorSel_Enabled = 1;
         edtProdIna_Jsonclick = "";
         edtProdIna_Enabled = 1;
         edtProdCostoD_Jsonclick = "";
         edtProdCostoD_Enabled = 1;
         edtProdCostoFec_Jsonclick = "";
         edtProdCostoFec_Enabled = 1;
         edtProdCosto_Jsonclick = "";
         edtProdCosto_Enabled = 1;
         cmbProdSts_Jsonclick = "";
         cmbProdSts.Enabled = 1;
         edtProdRef10_Jsonclick = "";
         edtProdRef10_Enabled = 1;
         edtProdRef9_Jsonclick = "";
         edtProdRef9_Enabled = 1;
         edtProdRef8_Jsonclick = "";
         edtProdRef8_Enabled = 1;
         edtProdRef7_Jsonclick = "";
         edtProdRef7_Enabled = 1;
         edtProdRef6_Jsonclick = "";
         edtProdRef6_Enabled = 1;
         edtProdRef5_Jsonclick = "";
         edtProdRef5_Enabled = 1;
         edtProdRef4_Jsonclick = "";
         edtProdRef4_Enabled = 1;
         edtProdRef3_Jsonclick = "";
         edtProdRef3_Enabled = 1;
         edtProdRef2_Jsonclick = "";
         edtProdRef2_Enabled = 1;
         edtProdRef1_Jsonclick = "";
         edtProdRef1_Enabled = 1;
         imgProdFoto_Enabled = 1;
         edtProdStkMin_Jsonclick = "";
         edtProdStkMin_Enabled = 1;
         edtProdStkMax_Jsonclick = "";
         edtProdStkMax_Enabled = 1;
         edtProdVolumen_Jsonclick = "";
         edtProdVolumen_Enabled = 1;
         edtProdPeso_Jsonclick = "";
         edtProdPeso_Enabled = 1;
         chkProdCmp.Enabled = 1;
         chkProdVta.Enabled = 1;
         edtUniCod_Jsonclick = "";
         edtUniCod_Enabled = 1;
         edtUniCod_Visible = 1;
         Combo_unicod_Emptyitem = Convert.ToBoolean( 0);
         Combo_unicod_Datalistprocparametersprefix = " \"ComboName\": \"UniCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_unicod_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_unicod_Cls = "ExtendedCombo Attribute";
         Combo_unicod_Caption = "";
         Combo_unicod_Enabled = Convert.ToBoolean( -1);
         edtFamCod_Jsonclick = "";
         edtFamCod_Enabled = 1;
         edtFamCod_Visible = 1;
         Combo_famcod_Datalistprocparametersprefix = " \"ComboName\": \"FamCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_famcod_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_famcod_Cls = "ExtendedCombo Attribute";
         Combo_famcod_Caption = "";
         Combo_famcod_Enabled = Convert.ToBoolean( -1);
         edtSublCod_Jsonclick = "";
         edtSublCod_Enabled = 1;
         edtSublCod_Visible = 1;
         Combo_sublcod_Datalistprocparametersprefix = " \"ComboName\": \"SublCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_sublcod_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_sublcod_Cls = "ExtendedCombo Attribute";
         Combo_sublcod_Caption = "";
         Combo_sublcod_Enabled = Convert.ToBoolean( -1);
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 1;
         edtLinCod_Jsonclick = "";
         edtLinCod_Enabled = 1;
         edtLinCod_Visible = 1;
         Combo_lincod_Emptyitem = Convert.ToBoolean( 0);
         Combo_lincod_Datalistprocparametersprefix = " \"ComboName\": \"LinCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProdCod\": \"\"";
         Combo_lincod_Datalistproc = "Almacen.ProductosLoadDVCombo";
         Combo_lincod_Cls = "ExtendedCombo Attribute";
         Combo_lincod_Caption = "";
         Combo_lincod_Enabled = Convert.ToBoolean( -1);
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
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
         chkProdVta.Name = "PRODVTA";
         chkProdVta.WebTags = "";
         chkProdVta.Caption = "";
         AssignProp("", false, chkProdVta_Internalname, "TitleCaption", chkProdVta.Caption, true);
         chkProdVta.CheckedValue = "0";
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
         chkProdCmp.Name = "PRODCMP";
         chkProdCmp.WebTags = "";
         chkProdCmp.Caption = "";
         AssignProp("", false, chkProdCmp_Internalname, "TitleCaption", chkProdCmp.Caption, true);
         chkProdCmp.CheckedValue = "0";
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
         cmbProdSts.Name = "PRODSTS";
         cmbProdSts.WebTags = "";
         cmbProdSts.addItem("1", "ACTIVO", 0);
         cmbProdSts.addItem("0", "INACTIVO", 0);
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
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

      public void Valid_Lincod( )
      {
         /* Using cursor T007K30 */
         pr_default.execute(28, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
         }
         A1153LinDsc = T007K30_A1153LinDsc[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1153LinDsc", StringUtil.RTrim( A1153LinDsc));
      }

      public void Valid_Sublcod( )
      {
         n51SublCod = false;
         /* Using cursor T007K68 */
         pr_default.execute(66, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(66) == 101) )
         {
            if ( ! ( (0==A51SublCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
            }
         }
         pr_default.close(66);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Famcod( )
      {
         n50FamCod = false;
         /* Using cursor T007K69 */
         pr_default.execute(67, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(67) == 101) )
         {
            if ( ! ( (0==A50FamCod) ) )
            {
               GX_msglist.addItem("No existe 'Familia'.", "ForeignKeyNotFound", 1, "FAMCOD");
               AnyError = 1;
               GX_FocusControl = edtFamCod_Internalname;
            }
         }
         pr_default.close(67);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Unicod( )
      {
         /* Using cursor T007K70 */
         pr_default.execute(68, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(68) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidad de Medida'.", "ForeignKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
         }
         pr_default.close(68);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prodcuentav( )
      {
         n48ProdCuentaV = false;
         /* Using cursor T007K31 */
         pr_default.execute(29, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
         if ( (pr_default.getStatus(29) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAV");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaV_Internalname;
            }
         }
         A1686ProdCuentaVDsc = T007K31_A1686ProdCuentaVDsc[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1686ProdCuentaVDsc", StringUtil.RTrim( A1686ProdCuentaVDsc));
      }

      public void Valid_Prodcuentac( )
      {
         n53ProdCuentaC = false;
         /* Using cursor T007K32 */
         pr_default.execute(30, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAC");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaC_Internalname;
            }
         }
         A1685ProdCuentaCDsc = T007K32_A1685ProdCuentaCDsc[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1685ProdCuentaCDsc", StringUtil.RTrim( A1685ProdCuentaCDsc));
      }

      public void Valid_Prodcuentaa( )
      {
         n54ProdCuentaA = false;
         /* Using cursor T007K33 */
         pr_default.execute(31, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Almacen'.", "ForeignKeyNotFound", 1, "PRODCUENTAA");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaA_Internalname;
            }
         }
         A1684ProdCuentaADsc = T007K33_A1684ProdCuentaADsc[0];
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1684ProdCuentaADsc", StringUtil.RTrim( A1684ProdCuentaADsc));
      }

      public void Valid_Cbsucod( )
      {
         n47CBSuCod = false;
         /* Using cursor T007K71 */
         pr_default.execute(69, new Object[] {n47CBSuCod, A47CBSuCod});
         if ( (pr_default.getStatus(69) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos Sunat'.", "ForeignKeyNotFound", 1, "CBSUCOD");
               AnyError = 1;
               GX_FocusControl = edtCBSuCod_Internalname;
            }
         }
         pr_default.close(69);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cdetcod( )
      {
         n46cDetCod = false;
         /* Using cursor T007K72 */
         pr_default.execute(70, new Object[] {n46cDetCod, A46cDetCod});
         if ( (pr_default.getStatus(70) == 101) )
         {
            if ( ! ( (0==A46cDetCod) ) )
            {
               GX_msglist.addItem("No existe 'CDETRACCIONES'.", "ForeignKeyNotFound", 1, "CDETCOD");
               AnyError = 1;
               GX_FocusControl = edtcDetCod_Internalname;
            }
         }
         pr_default.close(70);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ProdCod',fld:'vPRODCOD',pic:'@!',hsh:true},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProdCod',fld:'vPRODCOD',pic:'@!',hsh:true},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E127K2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_LINCOD","{handler:'Valid_Lincod',iparms:[{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A1153LinDsc',fld:'LINDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_LINCOD",",oparms:[{av:'A1153LinDsc',fld:'LINDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_SUBLCOD","{handler:'Valid_Sublcod',iparms:[{av:'A51SublCod',fld:'SUBLCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_SUBLCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_FAMCOD","{handler:'Valid_Famcod',iparms:[{av:'A50FamCod',fld:'FAMCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_FAMCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_UNICOD","{handler:'Valid_Unicod',iparms:[{av:'A49UniCod',fld:'UNICOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_UNICOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF1","{handler:'Valid_Prodref1',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF1",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF2","{handler:'Valid_Prodref2',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF2",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF3","{handler:'Valid_Prodref3',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF3",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF4","{handler:'Valid_Prodref4',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF4",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF5","{handler:'Valid_Prodref5',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF5",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF6","{handler:'Valid_Prodref6',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF6",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF7","{handler:'Valid_Prodref7',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF7",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF8","{handler:'Valid_Prodref8',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF8",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF9","{handler:'Valid_Prodref9',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF9",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF10","{handler:'Valid_Prodref10',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF10",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCOSTOFEC","{handler:'Valid_Prodcostofec',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCOSTOFEC",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCUENTAV","{handler:'Valid_Prodcuentav',iparms:[{av:'A48ProdCuentaV',fld:'PRODCUENTAV',pic:''},{av:'A1686ProdCuentaVDsc',fld:'PRODCUENTAVDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCUENTAV",",oparms:[{av:'A1686ProdCuentaVDsc',fld:'PRODCUENTAVDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCUENTAC","{handler:'Valid_Prodcuentac',iparms:[{av:'A53ProdCuentaC',fld:'PRODCUENTAC',pic:''},{av:'A1685ProdCuentaCDsc',fld:'PRODCUENTACDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCUENTAC",",oparms:[{av:'A1685ProdCuentaCDsc',fld:'PRODCUENTACDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCUENTAA","{handler:'Valid_Prodcuentaa',iparms:[{av:'A54ProdCuentaA',fld:'PRODCUENTAA',pic:''},{av:'A1684ProdCuentaADsc',fld:'PRODCUENTAADSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCUENTAA",",oparms:[{av:'A1684ProdCuentaADsc',fld:'PRODCUENTAADSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODUSUFEC","{handler:'Valid_Produsufec',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODUSUFEC",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_CBSUCOD","{handler:'Valid_Cbsucod',iparms:[{av:'A47CBSuCod',fld:'CBSUCOD',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_CBSUCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_CDETCOD","{handler:'Valid_Cdetcod',iparms:[{av:'A46cDetCod',fld:'CDETCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_CDETCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOLINCOD","{handler:'Validv_Combolincod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOLINCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOSUBLCOD","{handler:'Validv_Combosublcod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOSUBLCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOFAMCOD","{handler:'Validv_Combofamcod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOFAMCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUNICOD","{handler:'Validv_Combounicod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUNICOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOPRODCUENTAV","{handler:'Validv_Comboprodcuentav',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOPRODCUENTAV",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOPRODCUENTAC","{handler:'Validv_Comboprodcuentac',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOPRODCUENTAC",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOPRODCUENTAA","{handler:'Validv_Comboprodcuentaa',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOPRODCUENTAA",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOCBSUCOD","{handler:'Validv_Combocbsucod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOCBSUCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOCDETCOD","{handler:'Validv_Combocdetcod',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOCDETCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
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
         pr_default.close(28);
         pr_default.close(66);
         pr_default.close(67);
         pr_default.close(68);
         pr_default.close(69);
         pr_default.close(70);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(31);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7ProdCod = "";
         Z28ProdCod = "";
         Z55ProdDsc = "";
         Z1705ProdRef1 = "";
         Z1707ProdRef2 = "";
         Z1708ProdRef3 = "";
         Z1709ProdRef4 = "";
         Z1710ProdRef5 = "";
         Z1711ProdRef6 = "";
         Z1712ProdRef7 = "";
         Z1713ProdRef8 = "";
         Z1714ProdRef9 = "";
         Z1706ProdRef10 = "";
         Z1683ProdCostoFec = DateTime.MinValue;
         Z1721ProdUsuCod = "";
         Z1722ProdUsuFec = (DateTime)(DateTime.MinValue);
         Z1701ProdObs = "";
         Z1674ProdBarra = "";
         Z1689ProdExportacion = "";
         Z47CBSuCod = "";
         Z48ProdCuentaV = "";
         Z53ProdCuentaC = "";
         Z54ProdCuentaA = "";
         N48ProdCuentaV = "";
         N53ProdCuentaC = "";
         N54ProdCuentaA = "";
         N47CBSuCod = "";
         Combo_cdetcod_Selectedvalue_get = "";
         Combo_cbsucod_Selectedvalue_get = "";
         Combo_prodcuentaa_Selectedvalue_get = "";
         Combo_prodcuentac_Selectedvalue_get = "";
         Combo_prodcuentav_Selectedvalue_get = "";
         Combo_unicod_Selectedvalue_get = "";
         Combo_famcod_Selectedvalue_get = "";
         Combo_sublcod_Selectedvalue_get = "";
         Combo_lincod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A48ProdCuentaV = "";
         A53ProdCuentaC = "";
         A54ProdCuentaA = "";
         A47CBSuCod = "";
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
         A28ProdCod = "";
         lblTextblocklincod_Jsonclick = "";
         ucCombo_lincod = new GXUserControl();
         AV22DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21LinCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A55ProdDsc = "";
         lblTextblocksublcod_Jsonclick = "";
         ucCombo_sublcod = new GXUserControl();
         AV27SublCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockfamcod_Jsonclick = "";
         ucCombo_famcod = new GXUserControl();
         AV29FamCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockunicod_Jsonclick = "";
         ucCombo_unicod = new GXUserControl();
         AV31UniCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1695ProdFoto = "";
         A40000ProdFoto_GXI = "";
         sImgUrl = "";
         A1705ProdRef1 = "";
         A1707ProdRef2 = "";
         A1708ProdRef3 = "";
         A1709ProdRef4 = "";
         A1710ProdRef5 = "";
         A1711ProdRef6 = "";
         A1712ProdRef7 = "";
         A1713ProdRef8 = "";
         A1714ProdRef9 = "";
         A1706ProdRef10 = "";
         A1683ProdCostoFec = DateTime.MinValue;
         A1715ProdReferencias = "";
         lblTextblockprodcuentav_Jsonclick = "";
         ucCombo_prodcuentav = new GXUserControl();
         AV33ProdCuentaV_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1686ProdCuentaVDsc = "";
         lblTextblockprodcuentac_Jsonclick = "";
         ucCombo_prodcuentac = new GXUserControl();
         AV36ProdCuentaC_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1685ProdCuentaCDsc = "";
         lblTextblockprodcuentaa_Jsonclick = "";
         ucCombo_prodcuentaa = new GXUserControl();
         AV38ProdCuentaA_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1684ProdCuentaADsc = "";
         A1721ProdUsuCod = "";
         A1722ProdUsuFec = (DateTime)(DateTime.MinValue);
         A1701ProdObs = "";
         A1674ProdBarra = "";
         A1689ProdExportacion = "";
         lblTextblockcbsucod_Jsonclick = "";
         ucCombo_cbsucod = new GXUserControl();
         AV40CBSuCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcdetcod_Jsonclick = "";
         ucCombo_cdetcod = new GXUserControl();
         AV42cDetCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1153LinDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV34ComboProdCuentaV = "";
         AV37ComboProdCuentaC = "";
         AV39ComboProdCuentaA = "";
         AV41ComboCBSuCod = "";
         AV15Insert_ProdCuentaV = "";
         AV16Insert_ProdCuentaC = "";
         AV17Insert_ProdCuentaA = "";
         AV18Insert_CBSuCod = "";
         AV44Pgmname = "";
         Combo_lincod_Objectcall = "";
         Combo_lincod_Class = "";
         Combo_lincod_Icontype = "";
         Combo_lincod_Icon = "";
         Combo_lincod_Tooltip = "";
         Combo_lincod_Selectedvalue_set = "";
         Combo_lincod_Selectedtext_set = "";
         Combo_lincod_Selectedtext_get = "";
         Combo_lincod_Gamoauthtoken = "";
         Combo_lincod_Ddointernalname = "";
         Combo_lincod_Titlecontrolalign = "";
         Combo_lincod_Dropdownoptionstype = "";
         Combo_lincod_Titlecontrolidtoreplace = "";
         Combo_lincod_Datalisttype = "";
         Combo_lincod_Datalistfixedvalues = "";
         Combo_lincod_Htmltemplate = "";
         Combo_lincod_Multiplevaluestype = "";
         Combo_lincod_Loadingdata = "";
         Combo_lincod_Noresultsfound = "";
         Combo_lincod_Emptyitemtext = "";
         Combo_lincod_Onlyselectedvalues = "";
         Combo_lincod_Selectalltext = "";
         Combo_lincod_Multiplevaluesseparator = "";
         Combo_lincod_Addnewoptiontext = "";
         Combo_sublcod_Objectcall = "";
         Combo_sublcod_Class = "";
         Combo_sublcod_Icontype = "";
         Combo_sublcod_Icon = "";
         Combo_sublcod_Tooltip = "";
         Combo_sublcod_Selectedvalue_set = "";
         Combo_sublcod_Selectedtext_set = "";
         Combo_sublcod_Selectedtext_get = "";
         Combo_sublcod_Gamoauthtoken = "";
         Combo_sublcod_Ddointernalname = "";
         Combo_sublcod_Titlecontrolalign = "";
         Combo_sublcod_Dropdownoptionstype = "";
         Combo_sublcod_Titlecontrolidtoreplace = "";
         Combo_sublcod_Datalisttype = "";
         Combo_sublcod_Datalistfixedvalues = "";
         Combo_sublcod_Htmltemplate = "";
         Combo_sublcod_Multiplevaluestype = "";
         Combo_sublcod_Loadingdata = "";
         Combo_sublcod_Noresultsfound = "";
         Combo_sublcod_Emptyitemtext = "";
         Combo_sublcod_Onlyselectedvalues = "";
         Combo_sublcod_Selectalltext = "";
         Combo_sublcod_Multiplevaluesseparator = "";
         Combo_sublcod_Addnewoptiontext = "";
         Combo_famcod_Objectcall = "";
         Combo_famcod_Class = "";
         Combo_famcod_Icontype = "";
         Combo_famcod_Icon = "";
         Combo_famcod_Tooltip = "";
         Combo_famcod_Selectedvalue_set = "";
         Combo_famcod_Selectedtext_set = "";
         Combo_famcod_Selectedtext_get = "";
         Combo_famcod_Gamoauthtoken = "";
         Combo_famcod_Ddointernalname = "";
         Combo_famcod_Titlecontrolalign = "";
         Combo_famcod_Dropdownoptionstype = "";
         Combo_famcod_Titlecontrolidtoreplace = "";
         Combo_famcod_Datalisttype = "";
         Combo_famcod_Datalistfixedvalues = "";
         Combo_famcod_Htmltemplate = "";
         Combo_famcod_Multiplevaluestype = "";
         Combo_famcod_Loadingdata = "";
         Combo_famcod_Noresultsfound = "";
         Combo_famcod_Emptyitemtext = "";
         Combo_famcod_Onlyselectedvalues = "";
         Combo_famcod_Selectalltext = "";
         Combo_famcod_Multiplevaluesseparator = "";
         Combo_famcod_Addnewoptiontext = "";
         Combo_unicod_Objectcall = "";
         Combo_unicod_Class = "";
         Combo_unicod_Icontype = "";
         Combo_unicod_Icon = "";
         Combo_unicod_Tooltip = "";
         Combo_unicod_Selectedvalue_set = "";
         Combo_unicod_Selectedtext_set = "";
         Combo_unicod_Selectedtext_get = "";
         Combo_unicod_Gamoauthtoken = "";
         Combo_unicod_Ddointernalname = "";
         Combo_unicod_Titlecontrolalign = "";
         Combo_unicod_Dropdownoptionstype = "";
         Combo_unicod_Titlecontrolidtoreplace = "";
         Combo_unicod_Datalisttype = "";
         Combo_unicod_Datalistfixedvalues = "";
         Combo_unicod_Htmltemplate = "";
         Combo_unicod_Multiplevaluestype = "";
         Combo_unicod_Loadingdata = "";
         Combo_unicod_Noresultsfound = "";
         Combo_unicod_Emptyitemtext = "";
         Combo_unicod_Onlyselectedvalues = "";
         Combo_unicod_Selectalltext = "";
         Combo_unicod_Multiplevaluesseparator = "";
         Combo_unicod_Addnewoptiontext = "";
         Combo_prodcuentav_Objectcall = "";
         Combo_prodcuentav_Class = "";
         Combo_prodcuentav_Icontype = "";
         Combo_prodcuentav_Icon = "";
         Combo_prodcuentav_Tooltip = "";
         Combo_prodcuentav_Selectedvalue_set = "";
         Combo_prodcuentav_Selectedtext_set = "";
         Combo_prodcuentav_Selectedtext_get = "";
         Combo_prodcuentav_Gamoauthtoken = "";
         Combo_prodcuentav_Ddointernalname = "";
         Combo_prodcuentav_Titlecontrolalign = "";
         Combo_prodcuentav_Dropdownoptionstype = "";
         Combo_prodcuentav_Titlecontrolidtoreplace = "";
         Combo_prodcuentav_Datalisttype = "";
         Combo_prodcuentav_Datalistfixedvalues = "";
         Combo_prodcuentav_Htmltemplate = "";
         Combo_prodcuentav_Multiplevaluestype = "";
         Combo_prodcuentav_Loadingdata = "";
         Combo_prodcuentav_Noresultsfound = "";
         Combo_prodcuentav_Emptyitemtext = "";
         Combo_prodcuentav_Onlyselectedvalues = "";
         Combo_prodcuentav_Selectalltext = "";
         Combo_prodcuentav_Multiplevaluesseparator = "";
         Combo_prodcuentav_Addnewoptiontext = "";
         Combo_prodcuentac_Objectcall = "";
         Combo_prodcuentac_Class = "";
         Combo_prodcuentac_Icontype = "";
         Combo_prodcuentac_Icon = "";
         Combo_prodcuentac_Tooltip = "";
         Combo_prodcuentac_Selectedvalue_set = "";
         Combo_prodcuentac_Selectedtext_set = "";
         Combo_prodcuentac_Selectedtext_get = "";
         Combo_prodcuentac_Gamoauthtoken = "";
         Combo_prodcuentac_Ddointernalname = "";
         Combo_prodcuentac_Titlecontrolalign = "";
         Combo_prodcuentac_Dropdownoptionstype = "";
         Combo_prodcuentac_Titlecontrolidtoreplace = "";
         Combo_prodcuentac_Datalisttype = "";
         Combo_prodcuentac_Datalistfixedvalues = "";
         Combo_prodcuentac_Htmltemplate = "";
         Combo_prodcuentac_Multiplevaluestype = "";
         Combo_prodcuentac_Loadingdata = "";
         Combo_prodcuentac_Noresultsfound = "";
         Combo_prodcuentac_Emptyitemtext = "";
         Combo_prodcuentac_Onlyselectedvalues = "";
         Combo_prodcuentac_Selectalltext = "";
         Combo_prodcuentac_Multiplevaluesseparator = "";
         Combo_prodcuentac_Addnewoptiontext = "";
         Combo_prodcuentaa_Objectcall = "";
         Combo_prodcuentaa_Class = "";
         Combo_prodcuentaa_Icontype = "";
         Combo_prodcuentaa_Icon = "";
         Combo_prodcuentaa_Tooltip = "";
         Combo_prodcuentaa_Selectedvalue_set = "";
         Combo_prodcuentaa_Selectedtext_set = "";
         Combo_prodcuentaa_Selectedtext_get = "";
         Combo_prodcuentaa_Gamoauthtoken = "";
         Combo_prodcuentaa_Ddointernalname = "";
         Combo_prodcuentaa_Titlecontrolalign = "";
         Combo_prodcuentaa_Dropdownoptionstype = "";
         Combo_prodcuentaa_Titlecontrolidtoreplace = "";
         Combo_prodcuentaa_Datalisttype = "";
         Combo_prodcuentaa_Datalistfixedvalues = "";
         Combo_prodcuentaa_Htmltemplate = "";
         Combo_prodcuentaa_Multiplevaluestype = "";
         Combo_prodcuentaa_Loadingdata = "";
         Combo_prodcuentaa_Noresultsfound = "";
         Combo_prodcuentaa_Emptyitemtext = "";
         Combo_prodcuentaa_Onlyselectedvalues = "";
         Combo_prodcuentaa_Selectalltext = "";
         Combo_prodcuentaa_Multiplevaluesseparator = "";
         Combo_prodcuentaa_Addnewoptiontext = "";
         Combo_cbsucod_Objectcall = "";
         Combo_cbsucod_Class = "";
         Combo_cbsucod_Icontype = "";
         Combo_cbsucod_Icon = "";
         Combo_cbsucod_Tooltip = "";
         Combo_cbsucod_Selectedvalue_set = "";
         Combo_cbsucod_Selectedtext_set = "";
         Combo_cbsucod_Selectedtext_get = "";
         Combo_cbsucod_Gamoauthtoken = "";
         Combo_cbsucod_Ddointernalname = "";
         Combo_cbsucod_Titlecontrolalign = "";
         Combo_cbsucod_Dropdownoptionstype = "";
         Combo_cbsucod_Titlecontrolidtoreplace = "";
         Combo_cbsucod_Datalisttype = "";
         Combo_cbsucod_Datalistfixedvalues = "";
         Combo_cbsucod_Htmltemplate = "";
         Combo_cbsucod_Multiplevaluestype = "";
         Combo_cbsucod_Loadingdata = "";
         Combo_cbsucod_Noresultsfound = "";
         Combo_cbsucod_Emptyitemtext = "";
         Combo_cbsucod_Onlyselectedvalues = "";
         Combo_cbsucod_Selectalltext = "";
         Combo_cbsucod_Multiplevaluesseparator = "";
         Combo_cbsucod_Addnewoptiontext = "";
         Combo_cdetcod_Objectcall = "";
         Combo_cdetcod_Class = "";
         Combo_cdetcod_Icontype = "";
         Combo_cdetcod_Icon = "";
         Combo_cdetcod_Tooltip = "";
         Combo_cdetcod_Selectedvalue_set = "";
         Combo_cdetcod_Selectedtext_set = "";
         Combo_cdetcod_Selectedtext_get = "";
         Combo_cdetcod_Gamoauthtoken = "";
         Combo_cdetcod_Ddointernalname = "";
         Combo_cdetcod_Titlecontrolalign = "";
         Combo_cdetcod_Dropdownoptionstype = "";
         Combo_cdetcod_Titlecontrolidtoreplace = "";
         Combo_cdetcod_Datalisttype = "";
         Combo_cdetcod_Datalistfixedvalues = "";
         Combo_cdetcod_Htmltemplate = "";
         Combo_cdetcod_Multiplevaluestype = "";
         Combo_cdetcod_Loadingdata = "";
         Combo_cdetcod_Noresultsfound = "";
         Combo_cdetcod_Emptyitemtext = "";
         Combo_cdetcod_Onlyselectedvalues = "";
         Combo_cdetcod_Selectalltext = "";
         Combo_cdetcod_Multiplevaluesseparator = "";
         Combo_cdetcod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode44 = "";
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
         AV20TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV25Combo_DataJson = "";
         AV23ComboSelectedValue = "";
         AV24ComboSelectedText = "";
         GXt_char2 = "";
         Z1695ProdFoto = "";
         Z40000ProdFoto_GXI = "";
         Z1153LinDsc = "";
         Z1686ProdCuentaVDsc = "";
         Z1685ProdCuentaCDsc = "";
         Z1684ProdCuentaADsc = "";
         T007K4_A1153LinDsc = new string[] {""} ;
         T007K10_A1686ProdCuentaVDsc = new string[] {""} ;
         T007K11_A1685ProdCuentaCDsc = new string[] {""} ;
         T007K12_A1684ProdCuentaADsc = new string[] {""} ;
         T007K13_A28ProdCod = new string[] {""} ;
         T007K13_A55ProdDsc = new string[] {""} ;
         T007K13_A1724ProdVta = new short[1] ;
         T007K13_A1679ProdCmp = new short[1] ;
         T007K13_A1702ProdPeso = new decimal[1] ;
         T007K13_A1723ProdVolumen = new decimal[1] ;
         T007K13_A1716ProdStkMax = new decimal[1] ;
         T007K13_A1717ProdStkMin = new decimal[1] ;
         T007K13_A40000ProdFoto_GXI = new string[] {""} ;
         T007K13_n40000ProdFoto_GXI = new bool[] {false} ;
         T007K13_A1705ProdRef1 = new string[] {""} ;
         T007K13_A1707ProdRef2 = new string[] {""} ;
         T007K13_A1708ProdRef3 = new string[] {""} ;
         T007K13_A1709ProdRef4 = new string[] {""} ;
         T007K13_A1710ProdRef5 = new string[] {""} ;
         T007K13_A1711ProdRef6 = new string[] {""} ;
         T007K13_A1712ProdRef7 = new string[] {""} ;
         T007K13_A1713ProdRef8 = new string[] {""} ;
         T007K13_A1714ProdRef9 = new string[] {""} ;
         T007K13_A1706ProdRef10 = new string[] {""} ;
         T007K13_A1718ProdSts = new short[1] ;
         T007K13_A1681ProdCosto = new decimal[1] ;
         T007K13_A1683ProdCostoFec = new DateTime[] {DateTime.MinValue} ;
         T007K13_A1682ProdCostoD = new decimal[1] ;
         T007K13_A1698ProdIna = new short[1] ;
         T007K13_A1703ProdPorSel = new decimal[1] ;
         T007K13_A1697ProdImpSel = new decimal[1] ;
         T007K13_A1672ProdAdValor = new decimal[1] ;
         T007K13_A1696ProdFrecuente = new short[1] ;
         T007K13_A1686ProdCuentaVDsc = new string[] {""} ;
         T007K13_A1685ProdCuentaCDsc = new string[] {""} ;
         T007K13_A1684ProdCuentaADsc = new string[] {""} ;
         T007K13_A1721ProdUsuCod = new string[] {""} ;
         T007K13_A1722ProdUsuFec = new DateTime[] {DateTime.MinValue} ;
         T007K13_A1673ProdAfec = new short[1] ;
         T007K13_A1701ProdObs = new string[] {""} ;
         T007K13_A1675ProdCanLote = new decimal[1] ;
         T007K13_A1674ProdBarra = new string[] {""} ;
         T007K13_A1689ProdExportacion = new string[] {""} ;
         T007K13_A906ProdAfecICBPER = new short[1] ;
         T007K13_A907ProdValICBPER = new decimal[1] ;
         T007K13_A908ProdValICBPERD = new decimal[1] ;
         T007K13_A1153LinDsc = new string[] {""} ;
         T007K13_A52LinCod = new int[1] ;
         T007K13_A51SublCod = new int[1] ;
         T007K13_n51SublCod = new bool[] {false} ;
         T007K13_A50FamCod = new int[1] ;
         T007K13_n50FamCod = new bool[] {false} ;
         T007K13_A49UniCod = new int[1] ;
         T007K13_A47CBSuCod = new string[] {""} ;
         T007K13_n47CBSuCod = new bool[] {false} ;
         T007K13_A46cDetCod = new int[1] ;
         T007K13_n46cDetCod = new bool[] {false} ;
         T007K13_A48ProdCuentaV = new string[] {""} ;
         T007K13_n48ProdCuentaV = new bool[] {false} ;
         T007K13_A53ProdCuentaC = new string[] {""} ;
         T007K13_n53ProdCuentaC = new bool[] {false} ;
         T007K13_A54ProdCuentaA = new string[] {""} ;
         T007K13_n54ProdCuentaA = new bool[] {false} ;
         T007K13_A1695ProdFoto = new string[] {""} ;
         T007K13_n1695ProdFoto = new bool[] {false} ;
         T007K5_A51SublCod = new int[1] ;
         T007K5_n51SublCod = new bool[] {false} ;
         T007K6_A50FamCod = new int[1] ;
         T007K6_n50FamCod = new bool[] {false} ;
         T007K7_A49UniCod = new int[1] ;
         T007K8_A47CBSuCod = new string[] {""} ;
         T007K8_n47CBSuCod = new bool[] {false} ;
         T007K9_A46cDetCod = new int[1] ;
         T007K9_n46cDetCod = new bool[] {false} ;
         T007K14_A1153LinDsc = new string[] {""} ;
         T007K15_A51SublCod = new int[1] ;
         T007K15_n51SublCod = new bool[] {false} ;
         T007K16_A50FamCod = new int[1] ;
         T007K16_n50FamCod = new bool[] {false} ;
         T007K17_A49UniCod = new int[1] ;
         T007K18_A1686ProdCuentaVDsc = new string[] {""} ;
         T007K19_A1685ProdCuentaCDsc = new string[] {""} ;
         T007K20_A1684ProdCuentaADsc = new string[] {""} ;
         T007K21_A47CBSuCod = new string[] {""} ;
         T007K21_n47CBSuCod = new bool[] {false} ;
         T007K22_A46cDetCod = new int[1] ;
         T007K22_n46cDetCod = new bool[] {false} ;
         T007K23_A28ProdCod = new string[] {""} ;
         T007K3_A28ProdCod = new string[] {""} ;
         T007K3_A55ProdDsc = new string[] {""} ;
         T007K3_A1724ProdVta = new short[1] ;
         T007K3_A1679ProdCmp = new short[1] ;
         T007K3_A1702ProdPeso = new decimal[1] ;
         T007K3_A1723ProdVolumen = new decimal[1] ;
         T007K3_A1716ProdStkMax = new decimal[1] ;
         T007K3_A1717ProdStkMin = new decimal[1] ;
         T007K3_A40000ProdFoto_GXI = new string[] {""} ;
         T007K3_n40000ProdFoto_GXI = new bool[] {false} ;
         T007K3_A1705ProdRef1 = new string[] {""} ;
         T007K3_A1707ProdRef2 = new string[] {""} ;
         T007K3_A1708ProdRef3 = new string[] {""} ;
         T007K3_A1709ProdRef4 = new string[] {""} ;
         T007K3_A1710ProdRef5 = new string[] {""} ;
         T007K3_A1711ProdRef6 = new string[] {""} ;
         T007K3_A1712ProdRef7 = new string[] {""} ;
         T007K3_A1713ProdRef8 = new string[] {""} ;
         T007K3_A1714ProdRef9 = new string[] {""} ;
         T007K3_A1706ProdRef10 = new string[] {""} ;
         T007K3_A1718ProdSts = new short[1] ;
         T007K3_A1681ProdCosto = new decimal[1] ;
         T007K3_A1683ProdCostoFec = new DateTime[] {DateTime.MinValue} ;
         T007K3_A1682ProdCostoD = new decimal[1] ;
         T007K3_A1698ProdIna = new short[1] ;
         T007K3_A1703ProdPorSel = new decimal[1] ;
         T007K3_A1697ProdImpSel = new decimal[1] ;
         T007K3_A1672ProdAdValor = new decimal[1] ;
         T007K3_A1696ProdFrecuente = new short[1] ;
         T007K3_A1721ProdUsuCod = new string[] {""} ;
         T007K3_A1722ProdUsuFec = new DateTime[] {DateTime.MinValue} ;
         T007K3_A1673ProdAfec = new short[1] ;
         T007K3_A1701ProdObs = new string[] {""} ;
         T007K3_A1675ProdCanLote = new decimal[1] ;
         T007K3_A1674ProdBarra = new string[] {""} ;
         T007K3_A1689ProdExportacion = new string[] {""} ;
         T007K3_A906ProdAfecICBPER = new short[1] ;
         T007K3_A907ProdValICBPER = new decimal[1] ;
         T007K3_A908ProdValICBPERD = new decimal[1] ;
         T007K3_A52LinCod = new int[1] ;
         T007K3_A51SublCod = new int[1] ;
         T007K3_n51SublCod = new bool[] {false} ;
         T007K3_A50FamCod = new int[1] ;
         T007K3_n50FamCod = new bool[] {false} ;
         T007K3_A49UniCod = new int[1] ;
         T007K3_A47CBSuCod = new string[] {""} ;
         T007K3_n47CBSuCod = new bool[] {false} ;
         T007K3_A46cDetCod = new int[1] ;
         T007K3_n46cDetCod = new bool[] {false} ;
         T007K3_A48ProdCuentaV = new string[] {""} ;
         T007K3_n48ProdCuentaV = new bool[] {false} ;
         T007K3_A53ProdCuentaC = new string[] {""} ;
         T007K3_n53ProdCuentaC = new bool[] {false} ;
         T007K3_A54ProdCuentaA = new string[] {""} ;
         T007K3_n54ProdCuentaA = new bool[] {false} ;
         T007K3_A1695ProdFoto = new string[] {""} ;
         T007K3_n1695ProdFoto = new bool[] {false} ;
         T007K24_A28ProdCod = new string[] {""} ;
         T007K25_A28ProdCod = new string[] {""} ;
         T007K2_A28ProdCod = new string[] {""} ;
         T007K2_A55ProdDsc = new string[] {""} ;
         T007K2_A1724ProdVta = new short[1] ;
         T007K2_A1679ProdCmp = new short[1] ;
         T007K2_A1702ProdPeso = new decimal[1] ;
         T007K2_A1723ProdVolumen = new decimal[1] ;
         T007K2_A1716ProdStkMax = new decimal[1] ;
         T007K2_A1717ProdStkMin = new decimal[1] ;
         T007K2_A40000ProdFoto_GXI = new string[] {""} ;
         T007K2_n40000ProdFoto_GXI = new bool[] {false} ;
         T007K2_A1705ProdRef1 = new string[] {""} ;
         T007K2_A1707ProdRef2 = new string[] {""} ;
         T007K2_A1708ProdRef3 = new string[] {""} ;
         T007K2_A1709ProdRef4 = new string[] {""} ;
         T007K2_A1710ProdRef5 = new string[] {""} ;
         T007K2_A1711ProdRef6 = new string[] {""} ;
         T007K2_A1712ProdRef7 = new string[] {""} ;
         T007K2_A1713ProdRef8 = new string[] {""} ;
         T007K2_A1714ProdRef9 = new string[] {""} ;
         T007K2_A1706ProdRef10 = new string[] {""} ;
         T007K2_A1718ProdSts = new short[1] ;
         T007K2_A1681ProdCosto = new decimal[1] ;
         T007K2_A1683ProdCostoFec = new DateTime[] {DateTime.MinValue} ;
         T007K2_A1682ProdCostoD = new decimal[1] ;
         T007K2_A1698ProdIna = new short[1] ;
         T007K2_A1703ProdPorSel = new decimal[1] ;
         T007K2_A1697ProdImpSel = new decimal[1] ;
         T007K2_A1672ProdAdValor = new decimal[1] ;
         T007K2_A1696ProdFrecuente = new short[1] ;
         T007K2_A1721ProdUsuCod = new string[] {""} ;
         T007K2_A1722ProdUsuFec = new DateTime[] {DateTime.MinValue} ;
         T007K2_A1673ProdAfec = new short[1] ;
         T007K2_A1701ProdObs = new string[] {""} ;
         T007K2_A1675ProdCanLote = new decimal[1] ;
         T007K2_A1674ProdBarra = new string[] {""} ;
         T007K2_A1689ProdExportacion = new string[] {""} ;
         T007K2_A906ProdAfecICBPER = new short[1] ;
         T007K2_A907ProdValICBPER = new decimal[1] ;
         T007K2_A908ProdValICBPERD = new decimal[1] ;
         T007K2_A52LinCod = new int[1] ;
         T007K2_A51SublCod = new int[1] ;
         T007K2_n51SublCod = new bool[] {false} ;
         T007K2_A50FamCod = new int[1] ;
         T007K2_n50FamCod = new bool[] {false} ;
         T007K2_A49UniCod = new int[1] ;
         T007K2_A47CBSuCod = new string[] {""} ;
         T007K2_n47CBSuCod = new bool[] {false} ;
         T007K2_A46cDetCod = new int[1] ;
         T007K2_n46cDetCod = new bool[] {false} ;
         T007K2_A48ProdCuentaV = new string[] {""} ;
         T007K2_n48ProdCuentaV = new bool[] {false} ;
         T007K2_A53ProdCuentaC = new string[] {""} ;
         T007K2_n53ProdCuentaC = new bool[] {false} ;
         T007K2_A54ProdCuentaA = new string[] {""} ;
         T007K2_n54ProdCuentaA = new bool[] {false} ;
         T007K2_A1695ProdFoto = new string[] {""} ;
         T007K2_n1695ProdFoto = new bool[] {false} ;
         T007K30_A1153LinDsc = new string[] {""} ;
         T007K31_A1686ProdCuentaVDsc = new string[] {""} ;
         T007K32_A1685ProdCuentaCDsc = new string[] {""} ;
         T007K33_A1684ProdCuentaADsc = new string[] {""} ;
         T007K34_A2385ProCosProdCod = new string[] {""} ;
         T007K35_A2382ProGasProdCod = new string[] {""} ;
         T007K36_A329PSerCod = new string[] {""} ;
         T007K36_A335PSerDItem = new int[1] ;
         T007K37_A329PSerCod = new string[] {""} ;
         T007K38_A324ProPlanCod = new string[] {""} ;
         T007K38_A331ProPlanDProdCod = new string[] {""} ;
         T007K39_A322ProCod = new string[] {""} ;
         T007K39_A326ProDItem = new int[1] ;
         T007K40_A322ProCod = new string[] {""} ;
         T007K41_A317ProCotProdCod = new string[] {""} ;
         T007K41_A318ProCotItem = new int[1] ;
         T007K42_A317ProCotProdCod = new string[] {""} ;
         T007K43_A310Iesa_SabPedCod = new string[] {""} ;
         T007K43_A311Iesa_SabProdSec = new int[1] ;
         T007K43_A312Iesa_SabProdCod = new string[] {""} ;
         T007K44_A286CPLisHisProdCod = new string[] {""} ;
         T007K44_A287CPLisHisPrvCod = new string[] {""} ;
         T007K44_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T007K45_A284CPLisProdCod = new string[] {""} ;
         T007K46_A149TipCod = new string[] {""} ;
         T007K46_A243ComCod = new string[] {""} ;
         T007K46_A244PrvCod = new string[] {""} ;
         T007K46_A250ComDItem = new short[1] ;
         T007K46_A251ComDOrdCod = new string[] {""} ;
         T007K47_A191ImpItem = new long[1] ;
         T007K47_A197ImpDItem = new int[1] ;
         T007K48_A81CBonProdCod = new string[] {""} ;
         T007K49_A81CBonProdCod = new string[] {""} ;
         T007K50_A59SalCosAno = new int[1] ;
         T007K50_A60SalCosMes = new short[1] ;
         T007K50_A61SalCosAlmCod = new int[1] ;
         T007K50_A62SalCosProdCod = new string[] {""} ;
         T007K51_A37ListItem = new int[1] ;
         T007K52_A289OrdCod = new string[] {""} ;
         T007K52_A295OrdDItem = new int[1] ;
         T007K53_A149TipCod = new string[] {""} ;
         T007K53_A24DocNum = new string[] {""} ;
         T007K53_A233DocItem = new long[1] ;
         T007K54_A224LotCliCod = new string[] {""} ;
         T007K55_A210PedCod = new string[] {""} ;
         T007K55_A216PedDItem = new short[1] ;
         T007K56_A202TipLCod = new int[1] ;
         T007K56_A203TipLItem = new int[1] ;
         T007K57_A177CotCod = new string[] {""} ;
         T007K57_A183CotDItem = new short[1] ;
         T007K58_A13MvATip = new string[] {""} ;
         T007K58_A14MvACod = new string[] {""} ;
         T007K58_A30MvADItem = new int[1] ;
         T007K59_A210PedCod = new string[] {""} ;
         T007K59_A28ProdCod = new string[] {""} ;
         T007K59_A217PedDLRef1 = new string[] {""} ;
         T007K60_A63AlmCod = new int[1] ;
         T007K60_A28ProdCod = new string[] {""} ;
         T007K61_A28ProdCod = new string[] {""} ;
         T007K61_A58ProdMedUniCod = new int[1] ;
         T007K62_A28ProdCod = new string[] {""} ;
         T007K62_A57ProdForProdCod = new string[] {""} ;
         T007K63_A28ProdCod = new string[] {""} ;
         T007K63_A57ProdForProdCod = new string[] {""} ;
         T007K64_A28ProdCod = new string[] {""} ;
         T007K64_A56ProdEQVCod = new string[] {""} ;
         T007K65_A28ProdCod = new string[] {""} ;
         T007K65_A56ProdEQVCod = new string[] {""} ;
         T007K66_A26AGMVATip = new string[] {""} ;
         T007K66_A27AGMVACod = new string[] {""} ;
         T007K66_A28ProdCod = new string[] {""} ;
         T007K67_A28ProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         T007K68_A51SublCod = new int[1] ;
         T007K68_n51SublCod = new bool[] {false} ;
         T007K69_A50FamCod = new int[1] ;
         T007K69_n50FamCod = new bool[] {false} ;
         T007K70_A49UniCod = new int[1] ;
         T007K71_A47CBSuCod = new string[] {""} ;
         T007K71_n47CBSuCod = new bool[] {false} ;
         T007K72_A46cDetCod = new int[1] ;
         T007K72_n46cDetCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.almacen.productos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.productos__default(),
            new Object[][] {
                new Object[] {
               T007K2_A28ProdCod, T007K2_A55ProdDsc, T007K2_A1724ProdVta, T007K2_A1679ProdCmp, T007K2_A1702ProdPeso, T007K2_A1723ProdVolumen, T007K2_A1716ProdStkMax, T007K2_A1717ProdStkMin, T007K2_A40000ProdFoto_GXI, T007K2_n40000ProdFoto_GXI,
               T007K2_A1705ProdRef1, T007K2_A1707ProdRef2, T007K2_A1708ProdRef3, T007K2_A1709ProdRef4, T007K2_A1710ProdRef5, T007K2_A1711ProdRef6, T007K2_A1712ProdRef7, T007K2_A1713ProdRef8, T007K2_A1714ProdRef9, T007K2_A1706ProdRef10,
               T007K2_A1718ProdSts, T007K2_A1681ProdCosto, T007K2_A1683ProdCostoFec, T007K2_A1682ProdCostoD, T007K2_A1698ProdIna, T007K2_A1703ProdPorSel, T007K2_A1697ProdImpSel, T007K2_A1672ProdAdValor, T007K2_A1696ProdFrecuente, T007K2_A1721ProdUsuCod,
               T007K2_A1722ProdUsuFec, T007K2_A1673ProdAfec, T007K2_A1701ProdObs, T007K2_A1675ProdCanLote, T007K2_A1674ProdBarra, T007K2_A1689ProdExportacion, T007K2_A906ProdAfecICBPER, T007K2_A907ProdValICBPER, T007K2_A908ProdValICBPERD, T007K2_A52LinCod,
               T007K2_A51SublCod, T007K2_n51SublCod, T007K2_A50FamCod, T007K2_n50FamCod, T007K2_A49UniCod, T007K2_A47CBSuCod, T007K2_n47CBSuCod, T007K2_A46cDetCod, T007K2_n46cDetCod, T007K2_A48ProdCuentaV,
               T007K2_n48ProdCuentaV, T007K2_A53ProdCuentaC, T007K2_n53ProdCuentaC, T007K2_A54ProdCuentaA, T007K2_n54ProdCuentaA, T007K2_A1695ProdFoto, T007K2_n1695ProdFoto
               }
               , new Object[] {
               T007K3_A28ProdCod, T007K3_A55ProdDsc, T007K3_A1724ProdVta, T007K3_A1679ProdCmp, T007K3_A1702ProdPeso, T007K3_A1723ProdVolumen, T007K3_A1716ProdStkMax, T007K3_A1717ProdStkMin, T007K3_A40000ProdFoto_GXI, T007K3_n40000ProdFoto_GXI,
               T007K3_A1705ProdRef1, T007K3_A1707ProdRef2, T007K3_A1708ProdRef3, T007K3_A1709ProdRef4, T007K3_A1710ProdRef5, T007K3_A1711ProdRef6, T007K3_A1712ProdRef7, T007K3_A1713ProdRef8, T007K3_A1714ProdRef9, T007K3_A1706ProdRef10,
               T007K3_A1718ProdSts, T007K3_A1681ProdCosto, T007K3_A1683ProdCostoFec, T007K3_A1682ProdCostoD, T007K3_A1698ProdIna, T007K3_A1703ProdPorSel, T007K3_A1697ProdImpSel, T007K3_A1672ProdAdValor, T007K3_A1696ProdFrecuente, T007K3_A1721ProdUsuCod,
               T007K3_A1722ProdUsuFec, T007K3_A1673ProdAfec, T007K3_A1701ProdObs, T007K3_A1675ProdCanLote, T007K3_A1674ProdBarra, T007K3_A1689ProdExportacion, T007K3_A906ProdAfecICBPER, T007K3_A907ProdValICBPER, T007K3_A908ProdValICBPERD, T007K3_A52LinCod,
               T007K3_A51SublCod, T007K3_n51SublCod, T007K3_A50FamCod, T007K3_n50FamCod, T007K3_A49UniCod, T007K3_A47CBSuCod, T007K3_n47CBSuCod, T007K3_A46cDetCod, T007K3_n46cDetCod, T007K3_A48ProdCuentaV,
               T007K3_n48ProdCuentaV, T007K3_A53ProdCuentaC, T007K3_n53ProdCuentaC, T007K3_A54ProdCuentaA, T007K3_n54ProdCuentaA, T007K3_A1695ProdFoto, T007K3_n1695ProdFoto
               }
               , new Object[] {
               T007K4_A1153LinDsc
               }
               , new Object[] {
               T007K5_A51SublCod
               }
               , new Object[] {
               T007K6_A50FamCod
               }
               , new Object[] {
               T007K7_A49UniCod
               }
               , new Object[] {
               T007K8_A47CBSuCod
               }
               , new Object[] {
               T007K9_A46cDetCod
               }
               , new Object[] {
               T007K10_A1686ProdCuentaVDsc
               }
               , new Object[] {
               T007K11_A1685ProdCuentaCDsc
               }
               , new Object[] {
               T007K12_A1684ProdCuentaADsc
               }
               , new Object[] {
               T007K13_A28ProdCod, T007K13_A55ProdDsc, T007K13_A1724ProdVta, T007K13_A1679ProdCmp, T007K13_A1702ProdPeso, T007K13_A1723ProdVolumen, T007K13_A1716ProdStkMax, T007K13_A1717ProdStkMin, T007K13_A40000ProdFoto_GXI, T007K13_n40000ProdFoto_GXI,
               T007K13_A1705ProdRef1, T007K13_A1707ProdRef2, T007K13_A1708ProdRef3, T007K13_A1709ProdRef4, T007K13_A1710ProdRef5, T007K13_A1711ProdRef6, T007K13_A1712ProdRef7, T007K13_A1713ProdRef8, T007K13_A1714ProdRef9, T007K13_A1706ProdRef10,
               T007K13_A1718ProdSts, T007K13_A1681ProdCosto, T007K13_A1683ProdCostoFec, T007K13_A1682ProdCostoD, T007K13_A1698ProdIna, T007K13_A1703ProdPorSel, T007K13_A1697ProdImpSel, T007K13_A1672ProdAdValor, T007K13_A1696ProdFrecuente, T007K13_A1686ProdCuentaVDsc,
               T007K13_A1685ProdCuentaCDsc, T007K13_A1684ProdCuentaADsc, T007K13_A1721ProdUsuCod, T007K13_A1722ProdUsuFec, T007K13_A1673ProdAfec, T007K13_A1701ProdObs, T007K13_A1675ProdCanLote, T007K13_A1674ProdBarra, T007K13_A1689ProdExportacion, T007K13_A906ProdAfecICBPER,
               T007K13_A907ProdValICBPER, T007K13_A908ProdValICBPERD, T007K13_A1153LinDsc, T007K13_A52LinCod, T007K13_A51SublCod, T007K13_n51SublCod, T007K13_A50FamCod, T007K13_n50FamCod, T007K13_A49UniCod, T007K13_A47CBSuCod,
               T007K13_n47CBSuCod, T007K13_A46cDetCod, T007K13_n46cDetCod, T007K13_A48ProdCuentaV, T007K13_n48ProdCuentaV, T007K13_A53ProdCuentaC, T007K13_n53ProdCuentaC, T007K13_A54ProdCuentaA, T007K13_n54ProdCuentaA, T007K13_A1695ProdFoto,
               T007K13_n1695ProdFoto
               }
               , new Object[] {
               T007K14_A1153LinDsc
               }
               , new Object[] {
               T007K15_A51SublCod
               }
               , new Object[] {
               T007K16_A50FamCod
               }
               , new Object[] {
               T007K17_A49UniCod
               }
               , new Object[] {
               T007K18_A1686ProdCuentaVDsc
               }
               , new Object[] {
               T007K19_A1685ProdCuentaCDsc
               }
               , new Object[] {
               T007K20_A1684ProdCuentaADsc
               }
               , new Object[] {
               T007K21_A47CBSuCod
               }
               , new Object[] {
               T007K22_A46cDetCod
               }
               , new Object[] {
               T007K23_A28ProdCod
               }
               , new Object[] {
               T007K24_A28ProdCod
               }
               , new Object[] {
               T007K25_A28ProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007K30_A1153LinDsc
               }
               , new Object[] {
               T007K31_A1686ProdCuentaVDsc
               }
               , new Object[] {
               T007K32_A1685ProdCuentaCDsc
               }
               , new Object[] {
               T007K33_A1684ProdCuentaADsc
               }
               , new Object[] {
               T007K34_A2385ProCosProdCod
               }
               , new Object[] {
               T007K35_A2382ProGasProdCod
               }
               , new Object[] {
               T007K36_A329PSerCod, T007K36_A335PSerDItem
               }
               , new Object[] {
               T007K37_A329PSerCod
               }
               , new Object[] {
               T007K38_A324ProPlanCod, T007K38_A331ProPlanDProdCod
               }
               , new Object[] {
               T007K39_A322ProCod, T007K39_A326ProDItem
               }
               , new Object[] {
               T007K40_A322ProCod
               }
               , new Object[] {
               T007K41_A317ProCotProdCod, T007K41_A318ProCotItem
               }
               , new Object[] {
               T007K42_A317ProCotProdCod
               }
               , new Object[] {
               T007K43_A310Iesa_SabPedCod, T007K43_A311Iesa_SabProdSec, T007K43_A312Iesa_SabProdCod
               }
               , new Object[] {
               T007K44_A286CPLisHisProdCod, T007K44_A287CPLisHisPrvCod, T007K44_A288CPLisHisFecha
               }
               , new Object[] {
               T007K45_A284CPLisProdCod
               }
               , new Object[] {
               T007K46_A149TipCod, T007K46_A243ComCod, T007K46_A244PrvCod, T007K46_A250ComDItem, T007K46_A251ComDOrdCod
               }
               , new Object[] {
               T007K47_A191ImpItem, T007K47_A197ImpDItem
               }
               , new Object[] {
               T007K48_A81CBonProdCod
               }
               , new Object[] {
               T007K49_A81CBonProdCod
               }
               , new Object[] {
               T007K50_A59SalCosAno, T007K50_A60SalCosMes, T007K50_A61SalCosAlmCod, T007K50_A62SalCosProdCod
               }
               , new Object[] {
               T007K51_A37ListItem
               }
               , new Object[] {
               T007K52_A289OrdCod, T007K52_A295OrdDItem
               }
               , new Object[] {
               T007K53_A149TipCod, T007K53_A24DocNum, T007K53_A233DocItem
               }
               , new Object[] {
               T007K54_A224LotCliCod
               }
               , new Object[] {
               T007K55_A210PedCod, T007K55_A216PedDItem
               }
               , new Object[] {
               T007K56_A202TipLCod, T007K56_A203TipLItem
               }
               , new Object[] {
               T007K57_A177CotCod, T007K57_A183CotDItem
               }
               , new Object[] {
               T007K58_A13MvATip, T007K58_A14MvACod, T007K58_A30MvADItem
               }
               , new Object[] {
               T007K59_A210PedCod, T007K59_A28ProdCod, T007K59_A217PedDLRef1
               }
               , new Object[] {
               T007K60_A63AlmCod, T007K60_A28ProdCod
               }
               , new Object[] {
               T007K61_A28ProdCod, T007K61_A58ProdMedUniCod
               }
               , new Object[] {
               T007K62_A28ProdCod, T007K62_A57ProdForProdCod
               }
               , new Object[] {
               T007K63_A28ProdCod, T007K63_A57ProdForProdCod
               }
               , new Object[] {
               T007K64_A28ProdCod, T007K64_A56ProdEQVCod
               }
               , new Object[] {
               T007K65_A28ProdCod, T007K65_A56ProdEQVCod
               }
               , new Object[] {
               T007K66_A26AGMVATip, T007K66_A27AGMVACod, T007K66_A28ProdCod
               }
               , new Object[] {
               T007K67_A28ProdCod
               }
               , new Object[] {
               T007K68_A51SublCod
               }
               , new Object[] {
               T007K69_A50FamCod
               }
               , new Object[] {
               T007K70_A49UniCod
               }
               , new Object[] {
               T007K71_A47CBSuCod
               }
               , new Object[] {
               T007K72_A46cDetCod
               }
            }
         );
         AV44Pgmname = "Almacen.Productos";
      }

      private short Z1724ProdVta ;
      private short Z1679ProdCmp ;
      private short Z1718ProdSts ;
      private short Z1698ProdIna ;
      private short Z1696ProdFrecuente ;
      private short Z1673ProdAfec ;
      private short Z906ProdAfecICBPER ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1724ProdVta ;
      private short A1679ProdCmp ;
      private short A1718ProdSts ;
      private short A1698ProdIna ;
      private short A1696ProdFrecuente ;
      private short A1673ProdAfec ;
      private short A906ProdAfecICBPER ;
      private short RcdFound44 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_44 ;
      private short gxajaxcallmode ;
      private int Z52LinCod ;
      private int Z51SublCod ;
      private int Z50FamCod ;
      private int Z49UniCod ;
      private int Z46cDetCod ;
      private int N52LinCod ;
      private int N51SublCod ;
      private int N50FamCod ;
      private int N49UniCod ;
      private int N46cDetCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A49UniCod ;
      private int A46cDetCod ;
      private int trnEnded ;
      private int edtProdCod_Enabled ;
      private int edtLinCod_Visible ;
      private int edtLinCod_Enabled ;
      private int edtProdDsc_Enabled ;
      private int edtSublCod_Visible ;
      private int edtSublCod_Enabled ;
      private int edtFamCod_Visible ;
      private int edtFamCod_Enabled ;
      private int edtUniCod_Visible ;
      private int edtUniCod_Enabled ;
      private int edtProdPeso_Enabled ;
      private int edtProdVolumen_Enabled ;
      private int edtProdStkMax_Enabled ;
      private int edtProdStkMin_Enabled ;
      private int imgProdFoto_Enabled ;
      private int edtProdRef1_Enabled ;
      private int edtProdRef2_Enabled ;
      private int edtProdRef3_Enabled ;
      private int edtProdRef4_Enabled ;
      private int edtProdRef5_Enabled ;
      private int edtProdRef6_Enabled ;
      private int edtProdRef7_Enabled ;
      private int edtProdRef8_Enabled ;
      private int edtProdRef9_Enabled ;
      private int edtProdRef10_Enabled ;
      private int edtProdCosto_Enabled ;
      private int edtProdCostoFec_Enabled ;
      private int edtProdCostoD_Enabled ;
      private int edtProdIna_Enabled ;
      private int edtProdPorSel_Enabled ;
      private int edtProdImpSel_Enabled ;
      private int edtProdAdValor_Enabled ;
      private int edtProdReferencias_Enabled ;
      private int edtProdFrecuente_Enabled ;
      private int edtProdCuentaV_Visible ;
      private int edtProdCuentaV_Enabled ;
      private int edtProdCuentaVDsc_Enabled ;
      private int edtProdCuentaC_Visible ;
      private int edtProdCuentaC_Enabled ;
      private int edtProdCuentaCDsc_Enabled ;
      private int edtProdCuentaA_Visible ;
      private int edtProdCuentaA_Enabled ;
      private int edtProdCuentaADsc_Enabled ;
      private int edtProdUsuCod_Enabled ;
      private int edtProdUsuFec_Enabled ;
      private int edtProdAfec_Enabled ;
      private int edtProdObs_Enabled ;
      private int edtProdCanLote_Enabled ;
      private int edtProdBarra_Enabled ;
      private int edtProdExportacion_Enabled ;
      private int edtCBSuCod_Visible ;
      private int edtCBSuCod_Enabled ;
      private int edtProdAfecICBPER_Enabled ;
      private int edtProdValICBPER_Enabled ;
      private int edtProdValICBPERD_Enabled ;
      private int edtcDetCod_Visible ;
      private int edtcDetCod_Enabled ;
      private int edtLinDsc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV26ComboLinCod ;
      private int edtavCombolincod_Enabled ;
      private int edtavCombolincod_Visible ;
      private int AV28ComboSublCod ;
      private int edtavCombosublcod_Enabled ;
      private int edtavCombosublcod_Visible ;
      private int AV30ComboFamCod ;
      private int edtavCombofamcod_Enabled ;
      private int edtavCombofamcod_Visible ;
      private int AV32ComboUniCod ;
      private int edtavCombounicod_Enabled ;
      private int edtavCombounicod_Visible ;
      private int edtavComboprodcuentav_Visible ;
      private int edtavComboprodcuentav_Enabled ;
      private int edtavComboprodcuentac_Visible ;
      private int edtavComboprodcuentac_Enabled ;
      private int edtavComboprodcuentaa_Visible ;
      private int edtavComboprodcuentaa_Enabled ;
      private int edtavCombocbsucod_Visible ;
      private int edtavCombocbsucod_Enabled ;
      private int AV43CombocDetCod ;
      private int edtavCombocdetcod_Enabled ;
      private int edtavCombocdetcod_Visible ;
      private int AV11Insert_LinCod ;
      private int AV12Insert_SublCod ;
      private int AV13Insert_FamCod ;
      private int AV14Insert_UniCod ;
      private int AV19Insert_cDetCod ;
      private int Combo_lincod_Datalistupdateminimumcharacters ;
      private int Combo_lincod_Gxcontroltype ;
      private int Combo_sublcod_Datalistupdateminimumcharacters ;
      private int Combo_sublcod_Gxcontroltype ;
      private int Combo_famcod_Datalistupdateminimumcharacters ;
      private int Combo_famcod_Gxcontroltype ;
      private int Combo_unicod_Datalistupdateminimumcharacters ;
      private int Combo_unicod_Gxcontroltype ;
      private int Combo_prodcuentav_Datalistupdateminimumcharacters ;
      private int Combo_prodcuentav_Gxcontroltype ;
      private int Combo_prodcuentac_Datalistupdateminimumcharacters ;
      private int Combo_prodcuentac_Gxcontroltype ;
      private int Combo_prodcuentaa_Datalistupdateminimumcharacters ;
      private int Combo_prodcuentaa_Gxcontroltype ;
      private int Combo_cbsucod_Datalistupdateminimumcharacters ;
      private int Combo_cbsucod_Gxcontroltype ;
      private int Combo_cdetcod_Datalistupdateminimumcharacters ;
      private int Combo_cdetcod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV45GXV1 ;
      private int idxLst ;
      private decimal Z1702ProdPeso ;
      private decimal Z1723ProdVolumen ;
      private decimal Z1716ProdStkMax ;
      private decimal Z1717ProdStkMin ;
      private decimal Z1681ProdCosto ;
      private decimal Z1682ProdCostoD ;
      private decimal Z1703ProdPorSel ;
      private decimal Z1697ProdImpSel ;
      private decimal Z1672ProdAdValor ;
      private decimal Z1675ProdCanLote ;
      private decimal Z907ProdValICBPER ;
      private decimal Z908ProdValICBPERD ;
      private decimal A1702ProdPeso ;
      private decimal A1723ProdVolumen ;
      private decimal A1716ProdStkMax ;
      private decimal A1717ProdStkMin ;
      private decimal A1681ProdCosto ;
      private decimal A1682ProdCostoD ;
      private decimal A1703ProdPorSel ;
      private decimal A1697ProdImpSel ;
      private decimal A1672ProdAdValor ;
      private decimal A1675ProdCanLote ;
      private decimal A907ProdValICBPER ;
      private decimal A908ProdValICBPERD ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7ProdCod ;
      private string Z28ProdCod ;
      private string Z55ProdDsc ;
      private string Z1705ProdRef1 ;
      private string Z1707ProdRef2 ;
      private string Z1708ProdRef3 ;
      private string Z1709ProdRef4 ;
      private string Z1710ProdRef5 ;
      private string Z1711ProdRef6 ;
      private string Z1712ProdRef7 ;
      private string Z1713ProdRef8 ;
      private string Z1714ProdRef9 ;
      private string Z1706ProdRef10 ;
      private string Z1721ProdUsuCod ;
      private string Z48ProdCuentaV ;
      private string Z53ProdCuentaC ;
      private string Z54ProdCuentaA ;
      private string N48ProdCuentaV ;
      private string N53ProdCuentaC ;
      private string N54ProdCuentaA ;
      private string Combo_cdetcod_Selectedvalue_get ;
      private string Combo_cbsucod_Selectedvalue_get ;
      private string Combo_prodcuentaa_Selectedvalue_get ;
      private string Combo_prodcuentac_Selectedvalue_get ;
      private string Combo_prodcuentav_Selectedvalue_get ;
      private string Combo_unicod_Selectedvalue_get ;
      private string Combo_famcod_Selectedvalue_get ;
      private string Combo_sublcod_Selectedvalue_get ;
      private string Combo_lincod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A48ProdCuentaV ;
      private string A53ProdCuentaC ;
      private string A54ProdCuentaA ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7ProdCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProdCod_Internalname ;
      private string cmbProdSts_Internalname ;
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
      private string A28ProdCod ;
      private string edtProdCod_Jsonclick ;
      private string divTablesplittedlincod_Internalname ;
      private string lblTextblocklincod_Internalname ;
      private string lblTextblocklincod_Jsonclick ;
      private string Combo_lincod_Caption ;
      private string Combo_lincod_Cls ;
      private string Combo_lincod_Datalistproc ;
      private string Combo_lincod_Datalistprocparametersprefix ;
      private string Combo_lincod_Internalname ;
      private string edtLinCod_Internalname ;
      private string edtLinCod_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string divTablesplittedsublcod_Internalname ;
      private string lblTextblocksublcod_Internalname ;
      private string lblTextblocksublcod_Jsonclick ;
      private string Combo_sublcod_Caption ;
      private string Combo_sublcod_Cls ;
      private string Combo_sublcod_Datalistproc ;
      private string Combo_sublcod_Datalistprocparametersprefix ;
      private string Combo_sublcod_Internalname ;
      private string edtSublCod_Internalname ;
      private string edtSublCod_Jsonclick ;
      private string divTablesplittedfamcod_Internalname ;
      private string lblTextblockfamcod_Internalname ;
      private string lblTextblockfamcod_Jsonclick ;
      private string Combo_famcod_Caption ;
      private string Combo_famcod_Cls ;
      private string Combo_famcod_Datalistproc ;
      private string Combo_famcod_Datalistprocparametersprefix ;
      private string Combo_famcod_Internalname ;
      private string edtFamCod_Internalname ;
      private string edtFamCod_Jsonclick ;
      private string divTablesplittedunicod_Internalname ;
      private string lblTextblockunicod_Internalname ;
      private string lblTextblockunicod_Jsonclick ;
      private string Combo_unicod_Caption ;
      private string Combo_unicod_Cls ;
      private string Combo_unicod_Datalistproc ;
      private string Combo_unicod_Datalistprocparametersprefix ;
      private string Combo_unicod_Internalname ;
      private string edtUniCod_Internalname ;
      private string edtUniCod_Jsonclick ;
      private string chkProdVta_Internalname ;
      private string chkProdCmp_Internalname ;
      private string edtProdPeso_Internalname ;
      private string edtProdPeso_Jsonclick ;
      private string edtProdVolumen_Internalname ;
      private string edtProdVolumen_Jsonclick ;
      private string edtProdStkMax_Internalname ;
      private string edtProdStkMax_Jsonclick ;
      private string edtProdStkMin_Internalname ;
      private string edtProdStkMin_Jsonclick ;
      private string imgProdFoto_Internalname ;
      private string sImgUrl ;
      private string edtProdRef1_Internalname ;
      private string A1705ProdRef1 ;
      private string edtProdRef1_Jsonclick ;
      private string edtProdRef2_Internalname ;
      private string A1707ProdRef2 ;
      private string edtProdRef2_Jsonclick ;
      private string edtProdRef3_Internalname ;
      private string A1708ProdRef3 ;
      private string edtProdRef3_Jsonclick ;
      private string edtProdRef4_Internalname ;
      private string A1709ProdRef4 ;
      private string edtProdRef4_Jsonclick ;
      private string edtProdRef5_Internalname ;
      private string A1710ProdRef5 ;
      private string edtProdRef5_Jsonclick ;
      private string edtProdRef6_Internalname ;
      private string A1711ProdRef6 ;
      private string edtProdRef6_Jsonclick ;
      private string edtProdRef7_Internalname ;
      private string A1712ProdRef7 ;
      private string edtProdRef7_Jsonclick ;
      private string edtProdRef8_Internalname ;
      private string A1713ProdRef8 ;
      private string edtProdRef8_Jsonclick ;
      private string edtProdRef9_Internalname ;
      private string A1714ProdRef9 ;
      private string edtProdRef9_Jsonclick ;
      private string edtProdRef10_Internalname ;
      private string A1706ProdRef10 ;
      private string edtProdRef10_Jsonclick ;
      private string cmbProdSts_Jsonclick ;
      private string edtProdCosto_Internalname ;
      private string edtProdCosto_Jsonclick ;
      private string edtProdCostoFec_Internalname ;
      private string edtProdCostoFec_Jsonclick ;
      private string edtProdCostoD_Internalname ;
      private string edtProdCostoD_Jsonclick ;
      private string edtProdIna_Internalname ;
      private string edtProdIna_Jsonclick ;
      private string edtProdPorSel_Internalname ;
      private string edtProdPorSel_Jsonclick ;
      private string edtProdImpSel_Internalname ;
      private string edtProdImpSel_Jsonclick ;
      private string edtProdAdValor_Internalname ;
      private string edtProdAdValor_Jsonclick ;
      private string edtProdReferencias_Internalname ;
      private string edtProdFrecuente_Internalname ;
      private string edtProdFrecuente_Jsonclick ;
      private string divTablesplittedprodcuentav_Internalname ;
      private string lblTextblockprodcuentav_Internalname ;
      private string lblTextblockprodcuentav_Jsonclick ;
      private string Combo_prodcuentav_Caption ;
      private string Combo_prodcuentav_Cls ;
      private string Combo_prodcuentav_Datalistproc ;
      private string Combo_prodcuentav_Datalistprocparametersprefix ;
      private string Combo_prodcuentav_Internalname ;
      private string edtProdCuentaV_Internalname ;
      private string edtProdCuentaV_Jsonclick ;
      private string edtProdCuentaVDsc_Internalname ;
      private string A1686ProdCuentaVDsc ;
      private string edtProdCuentaVDsc_Jsonclick ;
      private string divTablesplittedprodcuentac_Internalname ;
      private string lblTextblockprodcuentac_Internalname ;
      private string lblTextblockprodcuentac_Jsonclick ;
      private string Combo_prodcuentac_Caption ;
      private string Combo_prodcuentac_Cls ;
      private string Combo_prodcuentac_Datalistproc ;
      private string Combo_prodcuentac_Datalistprocparametersprefix ;
      private string Combo_prodcuentac_Internalname ;
      private string edtProdCuentaC_Internalname ;
      private string edtProdCuentaC_Jsonclick ;
      private string edtProdCuentaCDsc_Internalname ;
      private string A1685ProdCuentaCDsc ;
      private string edtProdCuentaCDsc_Jsonclick ;
      private string divTablesplittedprodcuentaa_Internalname ;
      private string lblTextblockprodcuentaa_Internalname ;
      private string lblTextblockprodcuentaa_Jsonclick ;
      private string Combo_prodcuentaa_Caption ;
      private string Combo_prodcuentaa_Cls ;
      private string Combo_prodcuentaa_Datalistproc ;
      private string Combo_prodcuentaa_Datalistprocparametersprefix ;
      private string Combo_prodcuentaa_Internalname ;
      private string edtProdCuentaA_Internalname ;
      private string edtProdCuentaA_Jsonclick ;
      private string edtProdCuentaADsc_Internalname ;
      private string A1684ProdCuentaADsc ;
      private string edtProdCuentaADsc_Jsonclick ;
      private string edtProdUsuCod_Internalname ;
      private string A1721ProdUsuCod ;
      private string edtProdUsuCod_Jsonclick ;
      private string edtProdUsuFec_Internalname ;
      private string edtProdUsuFec_Jsonclick ;
      private string edtProdAfec_Internalname ;
      private string edtProdAfec_Jsonclick ;
      private string edtProdObs_Internalname ;
      private string edtProdCanLote_Internalname ;
      private string edtProdCanLote_Jsonclick ;
      private string edtProdBarra_Internalname ;
      private string edtProdBarra_Jsonclick ;
      private string edtProdExportacion_Internalname ;
      private string edtProdExportacion_Jsonclick ;
      private string divTablesplittedcbsucod_Internalname ;
      private string lblTextblockcbsucod_Internalname ;
      private string lblTextblockcbsucod_Jsonclick ;
      private string Combo_cbsucod_Caption ;
      private string Combo_cbsucod_Cls ;
      private string Combo_cbsucod_Datalistproc ;
      private string Combo_cbsucod_Datalistprocparametersprefix ;
      private string Combo_cbsucod_Internalname ;
      private string edtCBSuCod_Internalname ;
      private string edtCBSuCod_Jsonclick ;
      private string edtProdAfecICBPER_Internalname ;
      private string edtProdAfecICBPER_Jsonclick ;
      private string edtProdValICBPER_Internalname ;
      private string edtProdValICBPER_Jsonclick ;
      private string edtProdValICBPERD_Internalname ;
      private string edtProdValICBPERD_Jsonclick ;
      private string divTablesplittedcdetcod_Internalname ;
      private string lblTextblockcdetcod_Internalname ;
      private string lblTextblockcdetcod_Jsonclick ;
      private string Combo_cdetcod_Caption ;
      private string Combo_cdetcod_Cls ;
      private string Combo_cdetcod_Datalistproc ;
      private string Combo_cdetcod_Datalistprocparametersprefix ;
      private string Combo_cdetcod_Internalname ;
      private string edtcDetCod_Internalname ;
      private string edtcDetCod_Jsonclick ;
      private string edtLinDsc_Internalname ;
      private string A1153LinDsc ;
      private string edtLinDsc_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_lincod_Internalname ;
      private string edtavCombolincod_Internalname ;
      private string edtavCombolincod_Jsonclick ;
      private string divSectionattribute_sublcod_Internalname ;
      private string edtavCombosublcod_Internalname ;
      private string edtavCombosublcod_Jsonclick ;
      private string divSectionattribute_famcod_Internalname ;
      private string edtavCombofamcod_Internalname ;
      private string edtavCombofamcod_Jsonclick ;
      private string divSectionattribute_unicod_Internalname ;
      private string edtavCombounicod_Internalname ;
      private string edtavCombounicod_Jsonclick ;
      private string divSectionattribute_prodcuentav_Internalname ;
      private string edtavComboprodcuentav_Internalname ;
      private string AV34ComboProdCuentaV ;
      private string edtavComboprodcuentav_Jsonclick ;
      private string divSectionattribute_prodcuentac_Internalname ;
      private string edtavComboprodcuentac_Internalname ;
      private string AV37ComboProdCuentaC ;
      private string edtavComboprodcuentac_Jsonclick ;
      private string divSectionattribute_prodcuentaa_Internalname ;
      private string edtavComboprodcuentaa_Internalname ;
      private string AV39ComboProdCuentaA ;
      private string edtavComboprodcuentaa_Jsonclick ;
      private string divSectionattribute_cbsucod_Internalname ;
      private string edtavCombocbsucod_Internalname ;
      private string edtavCombocbsucod_Jsonclick ;
      private string divSectionattribute_cdetcod_Internalname ;
      private string edtavCombocdetcod_Internalname ;
      private string edtavCombocdetcod_Jsonclick ;
      private string AV15Insert_ProdCuentaV ;
      private string AV16Insert_ProdCuentaC ;
      private string AV17Insert_ProdCuentaA ;
      private string AV44Pgmname ;
      private string Combo_lincod_Objectcall ;
      private string Combo_lincod_Class ;
      private string Combo_lincod_Icontype ;
      private string Combo_lincod_Icon ;
      private string Combo_lincod_Tooltip ;
      private string Combo_lincod_Selectedvalue_set ;
      private string Combo_lincod_Selectedtext_set ;
      private string Combo_lincod_Selectedtext_get ;
      private string Combo_lincod_Gamoauthtoken ;
      private string Combo_lincod_Ddointernalname ;
      private string Combo_lincod_Titlecontrolalign ;
      private string Combo_lincod_Dropdownoptionstype ;
      private string Combo_lincod_Titlecontrolidtoreplace ;
      private string Combo_lincod_Datalisttype ;
      private string Combo_lincod_Datalistfixedvalues ;
      private string Combo_lincod_Htmltemplate ;
      private string Combo_lincod_Multiplevaluestype ;
      private string Combo_lincod_Loadingdata ;
      private string Combo_lincod_Noresultsfound ;
      private string Combo_lincod_Emptyitemtext ;
      private string Combo_lincod_Onlyselectedvalues ;
      private string Combo_lincod_Selectalltext ;
      private string Combo_lincod_Multiplevaluesseparator ;
      private string Combo_lincod_Addnewoptiontext ;
      private string Combo_sublcod_Objectcall ;
      private string Combo_sublcod_Class ;
      private string Combo_sublcod_Icontype ;
      private string Combo_sublcod_Icon ;
      private string Combo_sublcod_Tooltip ;
      private string Combo_sublcod_Selectedvalue_set ;
      private string Combo_sublcod_Selectedtext_set ;
      private string Combo_sublcod_Selectedtext_get ;
      private string Combo_sublcod_Gamoauthtoken ;
      private string Combo_sublcod_Ddointernalname ;
      private string Combo_sublcod_Titlecontrolalign ;
      private string Combo_sublcod_Dropdownoptionstype ;
      private string Combo_sublcod_Titlecontrolidtoreplace ;
      private string Combo_sublcod_Datalisttype ;
      private string Combo_sublcod_Datalistfixedvalues ;
      private string Combo_sublcod_Htmltemplate ;
      private string Combo_sublcod_Multiplevaluestype ;
      private string Combo_sublcod_Loadingdata ;
      private string Combo_sublcod_Noresultsfound ;
      private string Combo_sublcod_Emptyitemtext ;
      private string Combo_sublcod_Onlyselectedvalues ;
      private string Combo_sublcod_Selectalltext ;
      private string Combo_sublcod_Multiplevaluesseparator ;
      private string Combo_sublcod_Addnewoptiontext ;
      private string Combo_famcod_Objectcall ;
      private string Combo_famcod_Class ;
      private string Combo_famcod_Icontype ;
      private string Combo_famcod_Icon ;
      private string Combo_famcod_Tooltip ;
      private string Combo_famcod_Selectedvalue_set ;
      private string Combo_famcod_Selectedtext_set ;
      private string Combo_famcod_Selectedtext_get ;
      private string Combo_famcod_Gamoauthtoken ;
      private string Combo_famcod_Ddointernalname ;
      private string Combo_famcod_Titlecontrolalign ;
      private string Combo_famcod_Dropdownoptionstype ;
      private string Combo_famcod_Titlecontrolidtoreplace ;
      private string Combo_famcod_Datalisttype ;
      private string Combo_famcod_Datalistfixedvalues ;
      private string Combo_famcod_Htmltemplate ;
      private string Combo_famcod_Multiplevaluestype ;
      private string Combo_famcod_Loadingdata ;
      private string Combo_famcod_Noresultsfound ;
      private string Combo_famcod_Emptyitemtext ;
      private string Combo_famcod_Onlyselectedvalues ;
      private string Combo_famcod_Selectalltext ;
      private string Combo_famcod_Multiplevaluesseparator ;
      private string Combo_famcod_Addnewoptiontext ;
      private string Combo_unicod_Objectcall ;
      private string Combo_unicod_Class ;
      private string Combo_unicod_Icontype ;
      private string Combo_unicod_Icon ;
      private string Combo_unicod_Tooltip ;
      private string Combo_unicod_Selectedvalue_set ;
      private string Combo_unicod_Selectedtext_set ;
      private string Combo_unicod_Selectedtext_get ;
      private string Combo_unicod_Gamoauthtoken ;
      private string Combo_unicod_Ddointernalname ;
      private string Combo_unicod_Titlecontrolalign ;
      private string Combo_unicod_Dropdownoptionstype ;
      private string Combo_unicod_Titlecontrolidtoreplace ;
      private string Combo_unicod_Datalisttype ;
      private string Combo_unicod_Datalistfixedvalues ;
      private string Combo_unicod_Htmltemplate ;
      private string Combo_unicod_Multiplevaluestype ;
      private string Combo_unicod_Loadingdata ;
      private string Combo_unicod_Noresultsfound ;
      private string Combo_unicod_Emptyitemtext ;
      private string Combo_unicod_Onlyselectedvalues ;
      private string Combo_unicod_Selectalltext ;
      private string Combo_unicod_Multiplevaluesseparator ;
      private string Combo_unicod_Addnewoptiontext ;
      private string Combo_prodcuentav_Objectcall ;
      private string Combo_prodcuentav_Class ;
      private string Combo_prodcuentav_Icontype ;
      private string Combo_prodcuentav_Icon ;
      private string Combo_prodcuentav_Tooltip ;
      private string Combo_prodcuentav_Selectedvalue_set ;
      private string Combo_prodcuentav_Selectedtext_set ;
      private string Combo_prodcuentav_Selectedtext_get ;
      private string Combo_prodcuentav_Gamoauthtoken ;
      private string Combo_prodcuentav_Ddointernalname ;
      private string Combo_prodcuentav_Titlecontrolalign ;
      private string Combo_prodcuentav_Dropdownoptionstype ;
      private string Combo_prodcuentav_Titlecontrolidtoreplace ;
      private string Combo_prodcuentav_Datalisttype ;
      private string Combo_prodcuentav_Datalistfixedvalues ;
      private string Combo_prodcuentav_Htmltemplate ;
      private string Combo_prodcuentav_Multiplevaluestype ;
      private string Combo_prodcuentav_Loadingdata ;
      private string Combo_prodcuentav_Noresultsfound ;
      private string Combo_prodcuentav_Emptyitemtext ;
      private string Combo_prodcuentav_Onlyselectedvalues ;
      private string Combo_prodcuentav_Selectalltext ;
      private string Combo_prodcuentav_Multiplevaluesseparator ;
      private string Combo_prodcuentav_Addnewoptiontext ;
      private string Combo_prodcuentac_Objectcall ;
      private string Combo_prodcuentac_Class ;
      private string Combo_prodcuentac_Icontype ;
      private string Combo_prodcuentac_Icon ;
      private string Combo_prodcuentac_Tooltip ;
      private string Combo_prodcuentac_Selectedvalue_set ;
      private string Combo_prodcuentac_Selectedtext_set ;
      private string Combo_prodcuentac_Selectedtext_get ;
      private string Combo_prodcuentac_Gamoauthtoken ;
      private string Combo_prodcuentac_Ddointernalname ;
      private string Combo_prodcuentac_Titlecontrolalign ;
      private string Combo_prodcuentac_Dropdownoptionstype ;
      private string Combo_prodcuentac_Titlecontrolidtoreplace ;
      private string Combo_prodcuentac_Datalisttype ;
      private string Combo_prodcuentac_Datalistfixedvalues ;
      private string Combo_prodcuentac_Htmltemplate ;
      private string Combo_prodcuentac_Multiplevaluestype ;
      private string Combo_prodcuentac_Loadingdata ;
      private string Combo_prodcuentac_Noresultsfound ;
      private string Combo_prodcuentac_Emptyitemtext ;
      private string Combo_prodcuentac_Onlyselectedvalues ;
      private string Combo_prodcuentac_Selectalltext ;
      private string Combo_prodcuentac_Multiplevaluesseparator ;
      private string Combo_prodcuentac_Addnewoptiontext ;
      private string Combo_prodcuentaa_Objectcall ;
      private string Combo_prodcuentaa_Class ;
      private string Combo_prodcuentaa_Icontype ;
      private string Combo_prodcuentaa_Icon ;
      private string Combo_prodcuentaa_Tooltip ;
      private string Combo_prodcuentaa_Selectedvalue_set ;
      private string Combo_prodcuentaa_Selectedtext_set ;
      private string Combo_prodcuentaa_Selectedtext_get ;
      private string Combo_prodcuentaa_Gamoauthtoken ;
      private string Combo_prodcuentaa_Ddointernalname ;
      private string Combo_prodcuentaa_Titlecontrolalign ;
      private string Combo_prodcuentaa_Dropdownoptionstype ;
      private string Combo_prodcuentaa_Titlecontrolidtoreplace ;
      private string Combo_prodcuentaa_Datalisttype ;
      private string Combo_prodcuentaa_Datalistfixedvalues ;
      private string Combo_prodcuentaa_Htmltemplate ;
      private string Combo_prodcuentaa_Multiplevaluestype ;
      private string Combo_prodcuentaa_Loadingdata ;
      private string Combo_prodcuentaa_Noresultsfound ;
      private string Combo_prodcuentaa_Emptyitemtext ;
      private string Combo_prodcuentaa_Onlyselectedvalues ;
      private string Combo_prodcuentaa_Selectalltext ;
      private string Combo_prodcuentaa_Multiplevaluesseparator ;
      private string Combo_prodcuentaa_Addnewoptiontext ;
      private string Combo_cbsucod_Objectcall ;
      private string Combo_cbsucod_Class ;
      private string Combo_cbsucod_Icontype ;
      private string Combo_cbsucod_Icon ;
      private string Combo_cbsucod_Tooltip ;
      private string Combo_cbsucod_Selectedvalue_set ;
      private string Combo_cbsucod_Selectedtext_set ;
      private string Combo_cbsucod_Selectedtext_get ;
      private string Combo_cbsucod_Gamoauthtoken ;
      private string Combo_cbsucod_Ddointernalname ;
      private string Combo_cbsucod_Titlecontrolalign ;
      private string Combo_cbsucod_Dropdownoptionstype ;
      private string Combo_cbsucod_Titlecontrolidtoreplace ;
      private string Combo_cbsucod_Datalisttype ;
      private string Combo_cbsucod_Datalistfixedvalues ;
      private string Combo_cbsucod_Htmltemplate ;
      private string Combo_cbsucod_Multiplevaluestype ;
      private string Combo_cbsucod_Loadingdata ;
      private string Combo_cbsucod_Noresultsfound ;
      private string Combo_cbsucod_Emptyitemtext ;
      private string Combo_cbsucod_Onlyselectedvalues ;
      private string Combo_cbsucod_Selectalltext ;
      private string Combo_cbsucod_Multiplevaluesseparator ;
      private string Combo_cbsucod_Addnewoptiontext ;
      private string Combo_cdetcod_Objectcall ;
      private string Combo_cdetcod_Class ;
      private string Combo_cdetcod_Icontype ;
      private string Combo_cdetcod_Icon ;
      private string Combo_cdetcod_Tooltip ;
      private string Combo_cdetcod_Selectedvalue_set ;
      private string Combo_cdetcod_Selectedtext_set ;
      private string Combo_cdetcod_Selectedtext_get ;
      private string Combo_cdetcod_Gamoauthtoken ;
      private string Combo_cdetcod_Ddointernalname ;
      private string Combo_cdetcod_Titlecontrolalign ;
      private string Combo_cdetcod_Dropdownoptionstype ;
      private string Combo_cdetcod_Titlecontrolidtoreplace ;
      private string Combo_cdetcod_Datalisttype ;
      private string Combo_cdetcod_Datalistfixedvalues ;
      private string Combo_cdetcod_Htmltemplate ;
      private string Combo_cdetcod_Multiplevaluestype ;
      private string Combo_cdetcod_Loadingdata ;
      private string Combo_cdetcod_Noresultsfound ;
      private string Combo_cdetcod_Emptyitemtext ;
      private string Combo_cdetcod_Onlyselectedvalues ;
      private string Combo_cdetcod_Selectalltext ;
      private string Combo_cdetcod_Multiplevaluesseparator ;
      private string Combo_cdetcod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode44 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z1153LinDsc ;
      private string Z1686ProdCuentaVDsc ;
      private string Z1685ProdCuentaCDsc ;
      private string Z1684ProdCuentaADsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private DateTime Z1722ProdUsuFec ;
      private DateTime A1722ProdUsuFec ;
      private DateTime Z1683ProdCostoFec ;
      private DateTime A1683ProdCostoFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n51SublCod ;
      private bool n50FamCod ;
      private bool n48ProdCuentaV ;
      private bool n53ProdCuentaC ;
      private bool n54ProdCuentaA ;
      private bool n47CBSuCod ;
      private bool n46cDetCod ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_lincod_Emptyitem ;
      private bool Combo_unicod_Emptyitem ;
      private bool A1695ProdFoto_IsBlob ;
      private bool n40000ProdFoto_GXI ;
      private bool Combo_lincod_Enabled ;
      private bool Combo_lincod_Visible ;
      private bool Combo_lincod_Allowmultipleselection ;
      private bool Combo_lincod_Isgriditem ;
      private bool Combo_lincod_Hasdescription ;
      private bool Combo_lincod_Includeonlyselectedoption ;
      private bool Combo_lincod_Includeselectalloption ;
      private bool Combo_lincod_Includeaddnewoption ;
      private bool Combo_sublcod_Enabled ;
      private bool Combo_sublcod_Visible ;
      private bool Combo_sublcod_Allowmultipleselection ;
      private bool Combo_sublcod_Isgriditem ;
      private bool Combo_sublcod_Hasdescription ;
      private bool Combo_sublcod_Includeonlyselectedoption ;
      private bool Combo_sublcod_Includeselectalloption ;
      private bool Combo_sublcod_Emptyitem ;
      private bool Combo_sublcod_Includeaddnewoption ;
      private bool Combo_famcod_Enabled ;
      private bool Combo_famcod_Visible ;
      private bool Combo_famcod_Allowmultipleselection ;
      private bool Combo_famcod_Isgriditem ;
      private bool Combo_famcod_Hasdescription ;
      private bool Combo_famcod_Includeonlyselectedoption ;
      private bool Combo_famcod_Includeselectalloption ;
      private bool Combo_famcod_Emptyitem ;
      private bool Combo_famcod_Includeaddnewoption ;
      private bool Combo_unicod_Enabled ;
      private bool Combo_unicod_Visible ;
      private bool Combo_unicod_Allowmultipleselection ;
      private bool Combo_unicod_Isgriditem ;
      private bool Combo_unicod_Hasdescription ;
      private bool Combo_unicod_Includeonlyselectedoption ;
      private bool Combo_unicod_Includeselectalloption ;
      private bool Combo_unicod_Includeaddnewoption ;
      private bool Combo_prodcuentav_Enabled ;
      private bool Combo_prodcuentav_Visible ;
      private bool Combo_prodcuentav_Allowmultipleselection ;
      private bool Combo_prodcuentav_Isgriditem ;
      private bool Combo_prodcuentav_Hasdescription ;
      private bool Combo_prodcuentav_Includeonlyselectedoption ;
      private bool Combo_prodcuentav_Includeselectalloption ;
      private bool Combo_prodcuentav_Emptyitem ;
      private bool Combo_prodcuentav_Includeaddnewoption ;
      private bool Combo_prodcuentac_Enabled ;
      private bool Combo_prodcuentac_Visible ;
      private bool Combo_prodcuentac_Allowmultipleselection ;
      private bool Combo_prodcuentac_Isgriditem ;
      private bool Combo_prodcuentac_Hasdescription ;
      private bool Combo_prodcuentac_Includeonlyselectedoption ;
      private bool Combo_prodcuentac_Includeselectalloption ;
      private bool Combo_prodcuentac_Emptyitem ;
      private bool Combo_prodcuentac_Includeaddnewoption ;
      private bool Combo_prodcuentaa_Enabled ;
      private bool Combo_prodcuentaa_Visible ;
      private bool Combo_prodcuentaa_Allowmultipleselection ;
      private bool Combo_prodcuentaa_Isgriditem ;
      private bool Combo_prodcuentaa_Hasdescription ;
      private bool Combo_prodcuentaa_Includeonlyselectedoption ;
      private bool Combo_prodcuentaa_Includeselectalloption ;
      private bool Combo_prodcuentaa_Emptyitem ;
      private bool Combo_prodcuentaa_Includeaddnewoption ;
      private bool Combo_cbsucod_Enabled ;
      private bool Combo_cbsucod_Visible ;
      private bool Combo_cbsucod_Allowmultipleselection ;
      private bool Combo_cbsucod_Isgriditem ;
      private bool Combo_cbsucod_Hasdescription ;
      private bool Combo_cbsucod_Includeonlyselectedoption ;
      private bool Combo_cbsucod_Includeselectalloption ;
      private bool Combo_cbsucod_Emptyitem ;
      private bool Combo_cbsucod_Includeaddnewoption ;
      private bool Combo_cdetcod_Enabled ;
      private bool Combo_cdetcod_Visible ;
      private bool Combo_cdetcod_Allowmultipleselection ;
      private bool Combo_cdetcod_Isgriditem ;
      private bool Combo_cdetcod_Hasdescription ;
      private bool Combo_cdetcod_Includeonlyselectedoption ;
      private bool Combo_cdetcod_Includeselectalloption ;
      private bool Combo_cdetcod_Emptyitem ;
      private bool Combo_cdetcod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n1695ProdFoto ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV25Combo_DataJson ;
      private string Z1701ProdObs ;
      private string Z1674ProdBarra ;
      private string Z1689ProdExportacion ;
      private string Z47CBSuCod ;
      private string N47CBSuCod ;
      private string A47CBSuCod ;
      private string A40000ProdFoto_GXI ;
      private string A1715ProdReferencias ;
      private string A1701ProdObs ;
      private string A1674ProdBarra ;
      private string A1689ProdExportacion ;
      private string AV41ComboCBSuCod ;
      private string AV18Insert_CBSuCod ;
      private string AV23ComboSelectedValue ;
      private string AV24ComboSelectedText ;
      private string Z40000ProdFoto_GXI ;
      private string A1695ProdFoto ;
      private string Z1695ProdFoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_lincod ;
      private GXUserControl ucCombo_sublcod ;
      private GXUserControl ucCombo_famcod ;
      private GXUserControl ucCombo_unicod ;
      private GXUserControl ucCombo_prodcuentav ;
      private GXUserControl ucCombo_prodcuentac ;
      private GXUserControl ucCombo_prodcuentaa ;
      private GXUserControl ucCombo_cbsucod ;
      private GXUserControl ucCombo_cdetcod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkProdVta ;
      private GXCheckbox chkProdCmp ;
      private GXCombobox cmbProdSts ;
      private IDataStoreProvider pr_default ;
      private string[] T007K4_A1153LinDsc ;
      private string[] T007K10_A1686ProdCuentaVDsc ;
      private string[] T007K11_A1685ProdCuentaCDsc ;
      private string[] T007K12_A1684ProdCuentaADsc ;
      private string[] T007K13_A28ProdCod ;
      private string[] T007K13_A55ProdDsc ;
      private short[] T007K13_A1724ProdVta ;
      private short[] T007K13_A1679ProdCmp ;
      private decimal[] T007K13_A1702ProdPeso ;
      private decimal[] T007K13_A1723ProdVolumen ;
      private decimal[] T007K13_A1716ProdStkMax ;
      private decimal[] T007K13_A1717ProdStkMin ;
      private string[] T007K13_A40000ProdFoto_GXI ;
      private bool[] T007K13_n40000ProdFoto_GXI ;
      private string[] T007K13_A1705ProdRef1 ;
      private string[] T007K13_A1707ProdRef2 ;
      private string[] T007K13_A1708ProdRef3 ;
      private string[] T007K13_A1709ProdRef4 ;
      private string[] T007K13_A1710ProdRef5 ;
      private string[] T007K13_A1711ProdRef6 ;
      private string[] T007K13_A1712ProdRef7 ;
      private string[] T007K13_A1713ProdRef8 ;
      private string[] T007K13_A1714ProdRef9 ;
      private string[] T007K13_A1706ProdRef10 ;
      private short[] T007K13_A1718ProdSts ;
      private decimal[] T007K13_A1681ProdCosto ;
      private DateTime[] T007K13_A1683ProdCostoFec ;
      private decimal[] T007K13_A1682ProdCostoD ;
      private short[] T007K13_A1698ProdIna ;
      private decimal[] T007K13_A1703ProdPorSel ;
      private decimal[] T007K13_A1697ProdImpSel ;
      private decimal[] T007K13_A1672ProdAdValor ;
      private short[] T007K13_A1696ProdFrecuente ;
      private string[] T007K13_A1686ProdCuentaVDsc ;
      private string[] T007K13_A1685ProdCuentaCDsc ;
      private string[] T007K13_A1684ProdCuentaADsc ;
      private string[] T007K13_A1721ProdUsuCod ;
      private DateTime[] T007K13_A1722ProdUsuFec ;
      private short[] T007K13_A1673ProdAfec ;
      private string[] T007K13_A1701ProdObs ;
      private decimal[] T007K13_A1675ProdCanLote ;
      private string[] T007K13_A1674ProdBarra ;
      private string[] T007K13_A1689ProdExportacion ;
      private short[] T007K13_A906ProdAfecICBPER ;
      private decimal[] T007K13_A907ProdValICBPER ;
      private decimal[] T007K13_A908ProdValICBPERD ;
      private string[] T007K13_A1153LinDsc ;
      private int[] T007K13_A52LinCod ;
      private int[] T007K13_A51SublCod ;
      private bool[] T007K13_n51SublCod ;
      private int[] T007K13_A50FamCod ;
      private bool[] T007K13_n50FamCod ;
      private int[] T007K13_A49UniCod ;
      private string[] T007K13_A47CBSuCod ;
      private bool[] T007K13_n47CBSuCod ;
      private int[] T007K13_A46cDetCod ;
      private bool[] T007K13_n46cDetCod ;
      private string[] T007K13_A48ProdCuentaV ;
      private bool[] T007K13_n48ProdCuentaV ;
      private string[] T007K13_A53ProdCuentaC ;
      private bool[] T007K13_n53ProdCuentaC ;
      private string[] T007K13_A54ProdCuentaA ;
      private bool[] T007K13_n54ProdCuentaA ;
      private string[] T007K13_A1695ProdFoto ;
      private bool[] T007K13_n1695ProdFoto ;
      private int[] T007K5_A51SublCod ;
      private bool[] T007K5_n51SublCod ;
      private int[] T007K6_A50FamCod ;
      private bool[] T007K6_n50FamCod ;
      private int[] T007K7_A49UniCod ;
      private string[] T007K8_A47CBSuCod ;
      private bool[] T007K8_n47CBSuCod ;
      private int[] T007K9_A46cDetCod ;
      private bool[] T007K9_n46cDetCod ;
      private string[] T007K14_A1153LinDsc ;
      private int[] T007K15_A51SublCod ;
      private bool[] T007K15_n51SublCod ;
      private int[] T007K16_A50FamCod ;
      private bool[] T007K16_n50FamCod ;
      private int[] T007K17_A49UniCod ;
      private string[] T007K18_A1686ProdCuentaVDsc ;
      private string[] T007K19_A1685ProdCuentaCDsc ;
      private string[] T007K20_A1684ProdCuentaADsc ;
      private string[] T007K21_A47CBSuCod ;
      private bool[] T007K21_n47CBSuCod ;
      private int[] T007K22_A46cDetCod ;
      private bool[] T007K22_n46cDetCod ;
      private string[] T007K23_A28ProdCod ;
      private string[] T007K3_A28ProdCod ;
      private string[] T007K3_A55ProdDsc ;
      private short[] T007K3_A1724ProdVta ;
      private short[] T007K3_A1679ProdCmp ;
      private decimal[] T007K3_A1702ProdPeso ;
      private decimal[] T007K3_A1723ProdVolumen ;
      private decimal[] T007K3_A1716ProdStkMax ;
      private decimal[] T007K3_A1717ProdStkMin ;
      private string[] T007K3_A40000ProdFoto_GXI ;
      private bool[] T007K3_n40000ProdFoto_GXI ;
      private string[] T007K3_A1705ProdRef1 ;
      private string[] T007K3_A1707ProdRef2 ;
      private string[] T007K3_A1708ProdRef3 ;
      private string[] T007K3_A1709ProdRef4 ;
      private string[] T007K3_A1710ProdRef5 ;
      private string[] T007K3_A1711ProdRef6 ;
      private string[] T007K3_A1712ProdRef7 ;
      private string[] T007K3_A1713ProdRef8 ;
      private string[] T007K3_A1714ProdRef9 ;
      private string[] T007K3_A1706ProdRef10 ;
      private short[] T007K3_A1718ProdSts ;
      private decimal[] T007K3_A1681ProdCosto ;
      private DateTime[] T007K3_A1683ProdCostoFec ;
      private decimal[] T007K3_A1682ProdCostoD ;
      private short[] T007K3_A1698ProdIna ;
      private decimal[] T007K3_A1703ProdPorSel ;
      private decimal[] T007K3_A1697ProdImpSel ;
      private decimal[] T007K3_A1672ProdAdValor ;
      private short[] T007K3_A1696ProdFrecuente ;
      private string[] T007K3_A1721ProdUsuCod ;
      private DateTime[] T007K3_A1722ProdUsuFec ;
      private short[] T007K3_A1673ProdAfec ;
      private string[] T007K3_A1701ProdObs ;
      private decimal[] T007K3_A1675ProdCanLote ;
      private string[] T007K3_A1674ProdBarra ;
      private string[] T007K3_A1689ProdExportacion ;
      private short[] T007K3_A906ProdAfecICBPER ;
      private decimal[] T007K3_A907ProdValICBPER ;
      private decimal[] T007K3_A908ProdValICBPERD ;
      private int[] T007K3_A52LinCod ;
      private int[] T007K3_A51SublCod ;
      private bool[] T007K3_n51SublCod ;
      private int[] T007K3_A50FamCod ;
      private bool[] T007K3_n50FamCod ;
      private int[] T007K3_A49UniCod ;
      private string[] T007K3_A47CBSuCod ;
      private bool[] T007K3_n47CBSuCod ;
      private int[] T007K3_A46cDetCod ;
      private bool[] T007K3_n46cDetCod ;
      private string[] T007K3_A48ProdCuentaV ;
      private bool[] T007K3_n48ProdCuentaV ;
      private string[] T007K3_A53ProdCuentaC ;
      private bool[] T007K3_n53ProdCuentaC ;
      private string[] T007K3_A54ProdCuentaA ;
      private bool[] T007K3_n54ProdCuentaA ;
      private string[] T007K3_A1695ProdFoto ;
      private bool[] T007K3_n1695ProdFoto ;
      private string[] T007K24_A28ProdCod ;
      private string[] T007K25_A28ProdCod ;
      private string[] T007K2_A28ProdCod ;
      private string[] T007K2_A55ProdDsc ;
      private short[] T007K2_A1724ProdVta ;
      private short[] T007K2_A1679ProdCmp ;
      private decimal[] T007K2_A1702ProdPeso ;
      private decimal[] T007K2_A1723ProdVolumen ;
      private decimal[] T007K2_A1716ProdStkMax ;
      private decimal[] T007K2_A1717ProdStkMin ;
      private string[] T007K2_A40000ProdFoto_GXI ;
      private bool[] T007K2_n40000ProdFoto_GXI ;
      private string[] T007K2_A1705ProdRef1 ;
      private string[] T007K2_A1707ProdRef2 ;
      private string[] T007K2_A1708ProdRef3 ;
      private string[] T007K2_A1709ProdRef4 ;
      private string[] T007K2_A1710ProdRef5 ;
      private string[] T007K2_A1711ProdRef6 ;
      private string[] T007K2_A1712ProdRef7 ;
      private string[] T007K2_A1713ProdRef8 ;
      private string[] T007K2_A1714ProdRef9 ;
      private string[] T007K2_A1706ProdRef10 ;
      private short[] T007K2_A1718ProdSts ;
      private decimal[] T007K2_A1681ProdCosto ;
      private DateTime[] T007K2_A1683ProdCostoFec ;
      private decimal[] T007K2_A1682ProdCostoD ;
      private short[] T007K2_A1698ProdIna ;
      private decimal[] T007K2_A1703ProdPorSel ;
      private decimal[] T007K2_A1697ProdImpSel ;
      private decimal[] T007K2_A1672ProdAdValor ;
      private short[] T007K2_A1696ProdFrecuente ;
      private string[] T007K2_A1721ProdUsuCod ;
      private DateTime[] T007K2_A1722ProdUsuFec ;
      private short[] T007K2_A1673ProdAfec ;
      private string[] T007K2_A1701ProdObs ;
      private decimal[] T007K2_A1675ProdCanLote ;
      private string[] T007K2_A1674ProdBarra ;
      private string[] T007K2_A1689ProdExportacion ;
      private short[] T007K2_A906ProdAfecICBPER ;
      private decimal[] T007K2_A907ProdValICBPER ;
      private decimal[] T007K2_A908ProdValICBPERD ;
      private int[] T007K2_A52LinCod ;
      private int[] T007K2_A51SublCod ;
      private bool[] T007K2_n51SublCod ;
      private int[] T007K2_A50FamCod ;
      private bool[] T007K2_n50FamCod ;
      private int[] T007K2_A49UniCod ;
      private string[] T007K2_A47CBSuCod ;
      private bool[] T007K2_n47CBSuCod ;
      private int[] T007K2_A46cDetCod ;
      private bool[] T007K2_n46cDetCod ;
      private string[] T007K2_A48ProdCuentaV ;
      private bool[] T007K2_n48ProdCuentaV ;
      private string[] T007K2_A53ProdCuentaC ;
      private bool[] T007K2_n53ProdCuentaC ;
      private string[] T007K2_A54ProdCuentaA ;
      private bool[] T007K2_n54ProdCuentaA ;
      private string[] T007K2_A1695ProdFoto ;
      private bool[] T007K2_n1695ProdFoto ;
      private string[] T007K30_A1153LinDsc ;
      private string[] T007K31_A1686ProdCuentaVDsc ;
      private string[] T007K32_A1685ProdCuentaCDsc ;
      private string[] T007K33_A1684ProdCuentaADsc ;
      private string[] T007K34_A2385ProCosProdCod ;
      private string[] T007K35_A2382ProGasProdCod ;
      private string[] T007K36_A329PSerCod ;
      private int[] T007K36_A335PSerDItem ;
      private string[] T007K37_A329PSerCod ;
      private string[] T007K38_A324ProPlanCod ;
      private string[] T007K38_A331ProPlanDProdCod ;
      private string[] T007K39_A322ProCod ;
      private int[] T007K39_A326ProDItem ;
      private string[] T007K40_A322ProCod ;
      private string[] T007K41_A317ProCotProdCod ;
      private int[] T007K41_A318ProCotItem ;
      private string[] T007K42_A317ProCotProdCod ;
      private string[] T007K43_A310Iesa_SabPedCod ;
      private int[] T007K43_A311Iesa_SabProdSec ;
      private string[] T007K43_A312Iesa_SabProdCod ;
      private string[] T007K44_A286CPLisHisProdCod ;
      private string[] T007K44_A287CPLisHisPrvCod ;
      private DateTime[] T007K44_A288CPLisHisFecha ;
      private string[] T007K45_A284CPLisProdCod ;
      private string[] T007K46_A149TipCod ;
      private string[] T007K46_A243ComCod ;
      private string[] T007K46_A244PrvCod ;
      private short[] T007K46_A250ComDItem ;
      private string[] T007K46_A251ComDOrdCod ;
      private long[] T007K47_A191ImpItem ;
      private int[] T007K47_A197ImpDItem ;
      private string[] T007K48_A81CBonProdCod ;
      private string[] T007K49_A81CBonProdCod ;
      private int[] T007K50_A59SalCosAno ;
      private short[] T007K50_A60SalCosMes ;
      private int[] T007K50_A61SalCosAlmCod ;
      private string[] T007K50_A62SalCosProdCod ;
      private int[] T007K51_A37ListItem ;
      private string[] T007K52_A289OrdCod ;
      private int[] T007K52_A295OrdDItem ;
      private string[] T007K53_A149TipCod ;
      private string[] T007K53_A24DocNum ;
      private long[] T007K53_A233DocItem ;
      private string[] T007K54_A224LotCliCod ;
      private string[] T007K55_A210PedCod ;
      private short[] T007K55_A216PedDItem ;
      private int[] T007K56_A202TipLCod ;
      private int[] T007K56_A203TipLItem ;
      private string[] T007K57_A177CotCod ;
      private short[] T007K57_A183CotDItem ;
      private string[] T007K58_A13MvATip ;
      private string[] T007K58_A14MvACod ;
      private int[] T007K58_A30MvADItem ;
      private string[] T007K59_A210PedCod ;
      private string[] T007K59_A28ProdCod ;
      private string[] T007K59_A217PedDLRef1 ;
      private int[] T007K60_A63AlmCod ;
      private string[] T007K60_A28ProdCod ;
      private string[] T007K61_A28ProdCod ;
      private int[] T007K61_A58ProdMedUniCod ;
      private string[] T007K62_A28ProdCod ;
      private string[] T007K62_A57ProdForProdCod ;
      private string[] T007K63_A28ProdCod ;
      private string[] T007K63_A57ProdForProdCod ;
      private string[] T007K64_A28ProdCod ;
      private string[] T007K64_A56ProdEQVCod ;
      private string[] T007K65_A28ProdCod ;
      private string[] T007K65_A56ProdEQVCod ;
      private string[] T007K66_A26AGMVATip ;
      private string[] T007K66_A27AGMVACod ;
      private string[] T007K66_A28ProdCod ;
      private string[] T007K67_A28ProdCod ;
      private int[] T007K68_A51SublCod ;
      private bool[] T007K68_n51SublCod ;
      private int[] T007K69_A50FamCod ;
      private bool[] T007K69_n50FamCod ;
      private int[] T007K70_A49UniCod ;
      private string[] T007K71_A47CBSuCod ;
      private bool[] T007K71_n47CBSuCod ;
      private int[] T007K72_A46cDetCod ;
      private bool[] T007K72_n46cDetCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21LinCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27SublCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29FamCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31UniCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33ProdCuentaV_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV36ProdCuentaC_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV38ProdCuentaA_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV40CBSuCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV42cDetCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV20TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class productos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class productos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new ForEachCursor(def[59])
       ,new ForEachCursor(def[60])
       ,new ForEachCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new ForEachCursor(def[65])
       ,new ForEachCursor(def[66])
       ,new ForEachCursor(def[67])
       ,new ForEachCursor(def[68])
       ,new ForEachCursor(def[69])
       ,new ForEachCursor(def[70])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007K13;
        prmT007K13 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K4;
        prmT007K4 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT007K5;
        prmT007K5 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K6;
        prmT007K6 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K7;
        prmT007K7 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT007K10;
        prmT007K10 = new Object[] {
        new ParDef("@ProdCuentaV",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K11;
        prmT007K11 = new Object[] {
        new ParDef("@ProdCuentaC",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K12;
        prmT007K12 = new Object[] {
        new ParDef("@ProdCuentaA",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K8;
        prmT007K8 = new Object[] {
        new ParDef("@CBSuCod",GXType.NVarChar,40,0){Nullable=true}
        };
        Object[] prmT007K9;
        prmT007K9 = new Object[] {
        new ParDef("@cDetCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K14;
        prmT007K14 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT007K15;
        prmT007K15 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K16;
        prmT007K16 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K17;
        prmT007K17 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT007K18;
        prmT007K18 = new Object[] {
        new ParDef("@ProdCuentaV",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K19;
        prmT007K19 = new Object[] {
        new ParDef("@ProdCuentaC",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K20;
        prmT007K20 = new Object[] {
        new ParDef("@ProdCuentaA",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K21;
        prmT007K21 = new Object[] {
        new ParDef("@CBSuCod",GXType.NVarChar,40,0){Nullable=true}
        };
        Object[] prmT007K22;
        prmT007K22 = new Object[] {
        new ParDef("@cDetCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K23;
        prmT007K23 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K3;
        prmT007K3 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K24;
        prmT007K24 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K25;
        prmT007K25 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K2;
        prmT007K2 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K26;
        prmT007K26 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdDsc",GXType.NChar,100,0) ,
        new ParDef("@ProdVta",GXType.Int16,1,0) ,
        new ParDef("@ProdCmp",GXType.Int16,1,0) ,
        new ParDef("@ProdPeso",GXType.Decimal,15,5) ,
        new ParDef("@ProdVolumen",GXType.Decimal,15,5) ,
        new ParDef("@ProdStkMax",GXType.Decimal,15,4) ,
        new ParDef("@ProdStkMin",GXType.Decimal,15,4) ,
        new ParDef("@ProdFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProdFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=8, Tbl="APRODUCTOS", Fld="ProdFoto"} ,
        new ParDef("@ProdRef1",GXType.NChar,20,0) ,
        new ParDef("@ProdRef2",GXType.NChar,20,0) ,
        new ParDef("@ProdRef3",GXType.NChar,20,0) ,
        new ParDef("@ProdRef4",GXType.NChar,20,0) ,
        new ParDef("@ProdRef5",GXType.NChar,20,0) ,
        new ParDef("@ProdRef6",GXType.NChar,20,0) ,
        new ParDef("@ProdRef7",GXType.NChar,20,0) ,
        new ParDef("@ProdRef8",GXType.NChar,20,0) ,
        new ParDef("@ProdRef9",GXType.NChar,20,0) ,
        new ParDef("@ProdRef10",GXType.NChar,20,0) ,
        new ParDef("@ProdSts",GXType.Int16,1,0) ,
        new ParDef("@ProdCosto",GXType.Decimal,18,5) ,
        new ParDef("@ProdCostoFec",GXType.Date,8,0) ,
        new ParDef("@ProdCostoD",GXType.Decimal,18,5) ,
        new ParDef("@ProdIna",GXType.Int16,1,0) ,
        new ParDef("@ProdPorSel",GXType.Decimal,6,2) ,
        new ParDef("@ProdImpSel",GXType.Decimal,15,2) ,
        new ParDef("@ProdAdValor",GXType.Decimal,6,2) ,
        new ParDef("@ProdFrecuente",GXType.Int16,1,0) ,
        new ParDef("@ProdUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProdUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@ProdAfec",GXType.Int16,1,0) ,
        new ParDef("@ProdObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProdCanLote",GXType.Decimal,15,2) ,
        new ParDef("@ProdBarra",GXType.NVarChar,40,0) ,
        new ParDef("@ProdExportacion",GXType.NVarChar,20,0) ,
        new ParDef("@ProdAfecICBPER",GXType.Int16,1,0) ,
        new ParDef("@ProdValICBPER",GXType.Decimal,15,2) ,
        new ParDef("@ProdValICBPERD",GXType.Decimal,15,2) ,
        new ParDef("@LinCod",GXType.Int32,6,0) ,
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UniCod",GXType.Int32,6,0) ,
        new ParDef("@CBSuCod",GXType.NVarChar,40,0){Nullable=true} ,
        new ParDef("@cDetCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ProdCuentaV",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProdCuentaC",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProdCuentaA",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K27;
        prmT007K27 = new Object[] {
        new ParDef("@ProdDsc",GXType.NChar,100,0) ,
        new ParDef("@ProdVta",GXType.Int16,1,0) ,
        new ParDef("@ProdCmp",GXType.Int16,1,0) ,
        new ParDef("@ProdPeso",GXType.Decimal,15,5) ,
        new ParDef("@ProdVolumen",GXType.Decimal,15,5) ,
        new ParDef("@ProdStkMax",GXType.Decimal,15,4) ,
        new ParDef("@ProdStkMin",GXType.Decimal,15,4) ,
        new ParDef("@ProdRef1",GXType.NChar,20,0) ,
        new ParDef("@ProdRef2",GXType.NChar,20,0) ,
        new ParDef("@ProdRef3",GXType.NChar,20,0) ,
        new ParDef("@ProdRef4",GXType.NChar,20,0) ,
        new ParDef("@ProdRef5",GXType.NChar,20,0) ,
        new ParDef("@ProdRef6",GXType.NChar,20,0) ,
        new ParDef("@ProdRef7",GXType.NChar,20,0) ,
        new ParDef("@ProdRef8",GXType.NChar,20,0) ,
        new ParDef("@ProdRef9",GXType.NChar,20,0) ,
        new ParDef("@ProdRef10",GXType.NChar,20,0) ,
        new ParDef("@ProdSts",GXType.Int16,1,0) ,
        new ParDef("@ProdCosto",GXType.Decimal,18,5) ,
        new ParDef("@ProdCostoFec",GXType.Date,8,0) ,
        new ParDef("@ProdCostoD",GXType.Decimal,18,5) ,
        new ParDef("@ProdIna",GXType.Int16,1,0) ,
        new ParDef("@ProdPorSel",GXType.Decimal,6,2) ,
        new ParDef("@ProdImpSel",GXType.Decimal,15,2) ,
        new ParDef("@ProdAdValor",GXType.Decimal,6,2) ,
        new ParDef("@ProdFrecuente",GXType.Int16,1,0) ,
        new ParDef("@ProdUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProdUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@ProdAfec",GXType.Int16,1,0) ,
        new ParDef("@ProdObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProdCanLote",GXType.Decimal,15,2) ,
        new ParDef("@ProdBarra",GXType.NVarChar,40,0) ,
        new ParDef("@ProdExportacion",GXType.NVarChar,20,0) ,
        new ParDef("@ProdAfecICBPER",GXType.Int16,1,0) ,
        new ParDef("@ProdValICBPER",GXType.Decimal,15,2) ,
        new ParDef("@ProdValICBPERD",GXType.Decimal,15,2) ,
        new ParDef("@LinCod",GXType.Int32,6,0) ,
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UniCod",GXType.Int32,6,0) ,
        new ParDef("@CBSuCod",GXType.NVarChar,40,0){Nullable=true} ,
        new ParDef("@cDetCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ProdCuentaV",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProdCuentaC",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProdCuentaA",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K28;
        prmT007K28 = new Object[] {
        new ParDef("@ProdFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProdFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="APRODUCTOS", Fld="ProdFoto"} ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K29;
        prmT007K29 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K34;
        prmT007K34 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K35;
        prmT007K35 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K36;
        prmT007K36 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K37;
        prmT007K37 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K38;
        prmT007K38 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K39;
        prmT007K39 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K40;
        prmT007K40 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K41;
        prmT007K41 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K42;
        prmT007K42 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K43;
        prmT007K43 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K44;
        prmT007K44 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K45;
        prmT007K45 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K46;
        prmT007K46 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K47;
        prmT007K47 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K48;
        prmT007K48 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K49;
        prmT007K49 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K50;
        prmT007K50 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K51;
        prmT007K51 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K52;
        prmT007K52 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K53;
        prmT007K53 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K54;
        prmT007K54 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K55;
        prmT007K55 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K56;
        prmT007K56 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K57;
        prmT007K57 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K58;
        prmT007K58 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K59;
        prmT007K59 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K60;
        prmT007K60 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K61;
        prmT007K61 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K62;
        prmT007K62 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K63;
        prmT007K63 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K64;
        prmT007K64 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K65;
        prmT007K65 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K66;
        prmT007K66 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007K67;
        prmT007K67 = new Object[] {
        };
        Object[] prmT007K30;
        prmT007K30 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT007K68;
        prmT007K68 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K69;
        prmT007K69 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007K70;
        prmT007K70 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT007K31;
        prmT007K31 = new Object[] {
        new ParDef("@ProdCuentaV",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K32;
        prmT007K32 = new Object[] {
        new ParDef("@ProdCuentaC",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K33;
        prmT007K33 = new Object[] {
        new ParDef("@ProdCuentaA",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT007K71;
        prmT007K71 = new Object[] {
        new ParDef("@CBSuCod",GXType.NVarChar,40,0){Nullable=true}
        };
        Object[] prmT007K72;
        prmT007K72 = new Object[] {
        new ParDef("@cDetCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T007K2", "SELECT [ProdCod], [ProdDsc], [ProdVta], [ProdCmp], [ProdPeso], [ProdVolumen], [ProdStkMax], [ProdStkMin], [ProdFoto_GXI], [ProdRef1], [ProdRef2], [ProdRef3], [ProdRef4], [ProdRef5], [ProdRef6], [ProdRef7], [ProdRef8], [ProdRef9], [ProdRef10], [ProdSts], [ProdCosto], [ProdCostoFec], [ProdCostoD], [ProdIna], [ProdPorSel], [ProdImpSel], [ProdAdValor], [ProdFrecuente], [ProdUsuCod], [ProdUsuFec], [ProdAfec], [ProdObs], [ProdCanLote], [ProdBarra], [ProdExportacion], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD], [LinCod], [SublCod], [FamCod], [UniCod], [CBSuCod], [cDetCod], [ProdCuentaV] AS ProdCuentaV, [ProdCuentaC] AS ProdCuentaC, [ProdCuentaA] AS ProdCuentaA, [ProdFoto] FROM [APRODUCTOS] WITH (UPDLOCK) WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K3", "SELECT [ProdCod], [ProdDsc], [ProdVta], [ProdCmp], [ProdPeso], [ProdVolumen], [ProdStkMax], [ProdStkMin], [ProdFoto_GXI], [ProdRef1], [ProdRef2], [ProdRef3], [ProdRef4], [ProdRef5], [ProdRef6], [ProdRef7], [ProdRef8], [ProdRef9], [ProdRef10], [ProdSts], [ProdCosto], [ProdCostoFec], [ProdCostoD], [ProdIna], [ProdPorSel], [ProdImpSel], [ProdAdValor], [ProdFrecuente], [ProdUsuCod], [ProdUsuFec], [ProdAfec], [ProdObs], [ProdCanLote], [ProdBarra], [ProdExportacion], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD], [LinCod], [SublCod], [FamCod], [UniCod], [CBSuCod], [cDetCod], [ProdCuentaV] AS ProdCuentaV, [ProdCuentaC] AS ProdCuentaC, [ProdCuentaA] AS ProdCuentaA, [ProdFoto] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K4", "SELECT [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K5", "SELECT [SublCod] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K6", "SELECT [FamCod] FROM [CFAMILIA] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K7", "SELECT [UniCod] FROM [CUNIDADMEDIDA] WHERE [UniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K8", "SELECT [CBSuCod] FROM [CBPRODUCTOSSUNAT] WHERE [CBSuCod] = @CBSuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K9", "SELECT [cDetCod] FROM [CDETRACCIONES] WHERE [cDetCod] = @cDetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K10", "SELECT [CueDsc] AS ProdCuentaVDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaV ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K11", "SELECT [CueDsc] AS ProdCuentaCDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaC ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K12", "SELECT [CueDsc] AS ProdCuentaADsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaA ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K13", "SELECT TM1.[ProdCod], TM1.[ProdDsc], TM1.[ProdVta], TM1.[ProdCmp], TM1.[ProdPeso], TM1.[ProdVolumen], TM1.[ProdStkMax], TM1.[ProdStkMin], TM1.[ProdFoto_GXI], TM1.[ProdRef1], TM1.[ProdRef2], TM1.[ProdRef3], TM1.[ProdRef4], TM1.[ProdRef5], TM1.[ProdRef6], TM1.[ProdRef7], TM1.[ProdRef8], TM1.[ProdRef9], TM1.[ProdRef10], TM1.[ProdSts], TM1.[ProdCosto], TM1.[ProdCostoFec], TM1.[ProdCostoD], TM1.[ProdIna], TM1.[ProdPorSel], TM1.[ProdImpSel], TM1.[ProdAdValor], TM1.[ProdFrecuente], T3.[CueDsc] AS ProdCuentaVDsc, T4.[CueDsc] AS ProdCuentaCDsc, T5.[CueDsc] AS ProdCuentaADsc, TM1.[ProdUsuCod], TM1.[ProdUsuFec], TM1.[ProdAfec], TM1.[ProdObs], TM1.[ProdCanLote], TM1.[ProdBarra], TM1.[ProdExportacion], TM1.[ProdAfecICBPER], TM1.[ProdValICBPER], TM1.[ProdValICBPERD], T2.[LinDsc], TM1.[LinCod], TM1.[SublCod], TM1.[FamCod], TM1.[UniCod], TM1.[CBSuCod], TM1.[cDetCod], TM1.[ProdCuentaV] AS ProdCuentaV, TM1.[ProdCuentaC] AS ProdCuentaC, TM1.[ProdCuentaA] AS ProdCuentaA, TM1.[ProdFoto] FROM (((([APRODUCTOS] TM1 INNER JOIN [CLINEAPROD] T2 ON T2.[LinCod] = TM1.[LinCod]) LEFT JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = TM1.[ProdCuentaV]) LEFT JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = TM1.[ProdCuentaC]) LEFT JOIN [CBPLANCUENTA] T5 ON T5.[CueCod] = TM1.[ProdCuentaA]) WHERE TM1.[ProdCod] = @ProdCod ORDER BY TM1.[ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007K13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K14", "SELECT [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K15", "SELECT [SublCod] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K16", "SELECT [FamCod] FROM [CFAMILIA] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K17", "SELECT [UniCod] FROM [CUNIDADMEDIDA] WHERE [UniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K18", "SELECT [CueDsc] AS ProdCuentaVDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaV ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K19", "SELECT [CueDsc] AS ProdCuentaCDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaC ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K20", "SELECT [CueDsc] AS ProdCuentaADsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaA ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K21", "SELECT [CBSuCod] FROM [CBPRODUCTOSSUNAT] WHERE [CBSuCod] = @CBSuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K22", "SELECT [cDetCod] FROM [CDETRACCIONES] WHERE [cDetCod] = @cDetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K23", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007K23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K24", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE ( [ProdCod] > @ProdCod) ORDER BY [ProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007K24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K25", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE ( [ProdCod] < @ProdCod) ORDER BY [ProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007K25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K26", "INSERT INTO [APRODUCTOS]([ProdCod], [ProdDsc], [ProdVta], [ProdCmp], [ProdPeso], [ProdVolumen], [ProdStkMax], [ProdStkMin], [ProdFoto], [ProdFoto_GXI], [ProdRef1], [ProdRef2], [ProdRef3], [ProdRef4], [ProdRef5], [ProdRef6], [ProdRef7], [ProdRef8], [ProdRef9], [ProdRef10], [ProdSts], [ProdCosto], [ProdCostoFec], [ProdCostoD], [ProdIna], [ProdPorSel], [ProdImpSel], [ProdAdValor], [ProdFrecuente], [ProdUsuCod], [ProdUsuFec], [ProdAfec], [ProdObs], [ProdCanLote], [ProdBarra], [ProdExportacion], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD], [LinCod], [SublCod], [FamCod], [UniCod], [CBSuCod], [cDetCod], [ProdCuentaV], [ProdCuentaC], [ProdCuentaA]) VALUES(@ProdCod, @ProdDsc, @ProdVta, @ProdCmp, @ProdPeso, @ProdVolumen, @ProdStkMax, @ProdStkMin, @ProdFoto, @ProdFoto_GXI, @ProdRef1, @ProdRef2, @ProdRef3, @ProdRef4, @ProdRef5, @ProdRef6, @ProdRef7, @ProdRef8, @ProdRef9, @ProdRef10, @ProdSts, @ProdCosto, @ProdCostoFec, @ProdCostoD, @ProdIna, @ProdPorSel, @ProdImpSel, @ProdAdValor, @ProdFrecuente, @ProdUsuCod, @ProdUsuFec, @ProdAfec, @ProdObs, @ProdCanLote, @ProdBarra, @ProdExportacion, @ProdAfecICBPER, @ProdValICBPER, @ProdValICBPERD, @LinCod, @SublCod, @FamCod, @UniCod, @CBSuCod, @cDetCod, @ProdCuentaV, @ProdCuentaC, @ProdCuentaA)", GxErrorMask.GX_NOMASK,prmT007K26)
           ,new CursorDef("T007K27", "UPDATE [APRODUCTOS] SET [ProdDsc]=@ProdDsc, [ProdVta]=@ProdVta, [ProdCmp]=@ProdCmp, [ProdPeso]=@ProdPeso, [ProdVolumen]=@ProdVolumen, [ProdStkMax]=@ProdStkMax, [ProdStkMin]=@ProdStkMin, [ProdRef1]=@ProdRef1, [ProdRef2]=@ProdRef2, [ProdRef3]=@ProdRef3, [ProdRef4]=@ProdRef4, [ProdRef5]=@ProdRef5, [ProdRef6]=@ProdRef6, [ProdRef7]=@ProdRef7, [ProdRef8]=@ProdRef8, [ProdRef9]=@ProdRef9, [ProdRef10]=@ProdRef10, [ProdSts]=@ProdSts, [ProdCosto]=@ProdCosto, [ProdCostoFec]=@ProdCostoFec, [ProdCostoD]=@ProdCostoD, [ProdIna]=@ProdIna, [ProdPorSel]=@ProdPorSel, [ProdImpSel]=@ProdImpSel, [ProdAdValor]=@ProdAdValor, [ProdFrecuente]=@ProdFrecuente, [ProdUsuCod]=@ProdUsuCod, [ProdUsuFec]=@ProdUsuFec, [ProdAfec]=@ProdAfec, [ProdObs]=@ProdObs, [ProdCanLote]=@ProdCanLote, [ProdBarra]=@ProdBarra, [ProdExportacion]=@ProdExportacion, [ProdAfecICBPER]=@ProdAfecICBPER, [ProdValICBPER]=@ProdValICBPER, [ProdValICBPERD]=@ProdValICBPERD, [LinCod]=@LinCod, [SublCod]=@SublCod, [FamCod]=@FamCod, [UniCod]=@UniCod, [CBSuCod]=@CBSuCod, [cDetCod]=@cDetCod, [ProdCuentaV]=@ProdCuentaV, [ProdCuentaC]=@ProdCuentaC, [ProdCuentaA]=@ProdCuentaA  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT007K27)
           ,new CursorDef("T007K28", "UPDATE [APRODUCTOS] SET [ProdFoto]=@ProdFoto, [ProdFoto_GXI]=@ProdFoto_GXI  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT007K28)
           ,new CursorDef("T007K29", "DELETE FROM [APRODUCTOS]  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT007K29)
           ,new CursorDef("T007K30", "SELECT [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K31", "SELECT [CueDsc] AS ProdCuentaVDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaV ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K32", "SELECT [CueDsc] AS ProdCuentaCDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaC ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K33", "SELECT [CueDsc] AS ProdCuentaADsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ProdCuentaA ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K34", "SELECT TOP 1 [ProCosProdCod] FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K35", "SELECT TOP 1 [ProGasProdCod] FROM [PROCOSTOGASTOS] WHERE [ProGasProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K36", "SELECT TOP 1 [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE [PSerDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K37", "SELECT TOP 1 [PSerCod] FROM [POSERVICIO] WHERE [PSerProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K38", "SELECT TOP 1 [ProPlanCod], [ProPlanDProdCod] FROM [POPLANDET] WHERE [ProPlanDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K39", "SELECT TOP 1 [ProCod], [ProDItem] FROM [POORDENESDET] WHERE [ProDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K40", "SELECT TOP 1 [ProCod] FROM [POORDENES] WHERE [ProProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K41", "SELECT TOP 1 [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] WHERE [ProCotDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K41,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K42", "SELECT TOP 1 [ProCotProdCod] FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K42,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K43", "SELECT TOP 1 [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] FROM [OBR_SABANA] WHERE [Iesa_SabProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K44", "SELECT TOP 1 [CPLisHisProdCod], [CPLisHisPrvCod], [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE [CPLisHisProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K44,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K45", "SELECT TOP 1 [CPLisProdCod] FROM [CPLISTAPRECIOS] WHERE [CPLisProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K45,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K46", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComDProCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K46,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K47", "SELECT TOP 1 [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE [ImpDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K47,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K48", "SELECT TOP 1 [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K48,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K49", "SELECT TOP 1 [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K49,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K50", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod] FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K50,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K51", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE [ListProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K51,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K52", "SELECT TOP 1 [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K52,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K53", "SELECT TOP 1 [TipCod], [DocNum], [DocItem] FROM [CLVENTASDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K53,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K54", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K54,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K55", "SELECT TOP 1 [PedCod], [PedDItem] FROM [CLPEDIDOSDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K55,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K56", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K56,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K57", "SELECT TOP 1 [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K57,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K58", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem] FROM [AGUIASDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K58,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K59", "SELECT TOP 1 [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K59,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K60", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K60,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K61", "SELECT TOP 1 [ProdCod], [ProdMedUniCod] FROM [APRODUCTOSMEDIDAS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K61,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K62", "SELECT TOP 1 [ProdCod], [ProdForProdCod] FROM [APRODUCTOSFORMULA] WHERE [ProdForProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K62,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K63", "SELECT TOP 1 [ProdCod], [ProdForProdCod] FROM [APRODUCTOSFORMULA] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K63,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K64", "SELECT TOP 1 [ProdCod], [ProdEQVCod] FROM [APRODUCTOSEQUIVALENTE] WHERE [ProdEQVCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K64,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K65", "SELECT TOP 1 [ProdCod], [ProdEQVCod] FROM [APRODUCTOSEQUIVALENTE] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K65,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K66", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K66,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007K67", "SELECT [ProdCod] FROM [APRODUCTOS] ORDER BY [ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007K67,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K68", "SELECT [SublCod] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K68,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K69", "SELECT [FamCod] FROM [CFAMILIA] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K69,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K70", "SELECT [UniCod] FROM [CUNIDADMEDIDA] WHERE [UniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K70,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K71", "SELECT [CBSuCod] FROM [CBPRODUCTOSSUNAT] WHERE [CBSuCod] = @CBSuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K71,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007K72", "SELECT [cDetCod] FROM [CDETRACCIONES] WHERE [cDetCod] = @cDetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007K72,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 20);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((string[]) buf[12])[0] = rslt.getString(12, 20);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((string[]) buf[14])[0] = rslt.getString(14, 20);
              ((string[]) buf[15])[0] = rslt.getString(15, 20);
              ((string[]) buf[16])[0] = rslt.getString(16, 20);
              ((string[]) buf[17])[0] = rslt.getString(17, 20);
              ((string[]) buf[18])[0] = rslt.getString(18, 20);
              ((string[]) buf[19])[0] = rslt.getString(19, 20);
              ((short[]) buf[20])[0] = rslt.getShort(20);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(22);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
              ((short[]) buf[24])[0] = rslt.getShort(24);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(26);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(27);
              ((short[]) buf[28])[0] = rslt.getShort(28);
              ((string[]) buf[29])[0] = rslt.getString(29, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(30);
              ((short[]) buf[31])[0] = rslt.getShort(31);
              ((string[]) buf[32])[0] = rslt.getVarchar(32);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(33);
              ((string[]) buf[34])[0] = rslt.getVarchar(34);
              ((string[]) buf[35])[0] = rslt.getVarchar(35);
              ((short[]) buf[36])[0] = rslt.getShort(36);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(37);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(38);
              ((int[]) buf[39])[0] = rslt.getInt(39);
              ((int[]) buf[40])[0] = rslt.getInt(40);
              ((bool[]) buf[41])[0] = rslt.wasNull(40);
              ((int[]) buf[42])[0] = rslt.getInt(41);
              ((bool[]) buf[43])[0] = rslt.wasNull(41);
              ((int[]) buf[44])[0] = rslt.getInt(42);
              ((string[]) buf[45])[0] = rslt.getVarchar(43);
              ((bool[]) buf[46])[0] = rslt.wasNull(43);
              ((int[]) buf[47])[0] = rslt.getInt(44);
              ((bool[]) buf[48])[0] = rslt.wasNull(44);
              ((string[]) buf[49])[0] = rslt.getString(45, 15);
              ((bool[]) buf[50])[0] = rslt.wasNull(45);
              ((string[]) buf[51])[0] = rslt.getString(46, 15);
              ((bool[]) buf[52])[0] = rslt.wasNull(46);
              ((string[]) buf[53])[0] = rslt.getString(47, 15);
              ((bool[]) buf[54])[0] = rslt.wasNull(47);
              ((string[]) buf[55])[0] = rslt.getMultimediaFile(48, rslt.getVarchar(9));
              ((bool[]) buf[56])[0] = rslt.wasNull(48);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 20);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((string[]) buf[12])[0] = rslt.getString(12, 20);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((string[]) buf[14])[0] = rslt.getString(14, 20);
              ((string[]) buf[15])[0] = rslt.getString(15, 20);
              ((string[]) buf[16])[0] = rslt.getString(16, 20);
              ((string[]) buf[17])[0] = rslt.getString(17, 20);
              ((string[]) buf[18])[0] = rslt.getString(18, 20);
              ((string[]) buf[19])[0] = rslt.getString(19, 20);
              ((short[]) buf[20])[0] = rslt.getShort(20);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(22);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
              ((short[]) buf[24])[0] = rslt.getShort(24);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(26);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(27);
              ((short[]) buf[28])[0] = rslt.getShort(28);
              ((string[]) buf[29])[0] = rslt.getString(29, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(30);
              ((short[]) buf[31])[0] = rslt.getShort(31);
              ((string[]) buf[32])[0] = rslt.getVarchar(32);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(33);
              ((string[]) buf[34])[0] = rslt.getVarchar(34);
              ((string[]) buf[35])[0] = rslt.getVarchar(35);
              ((short[]) buf[36])[0] = rslt.getShort(36);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(37);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(38);
              ((int[]) buf[39])[0] = rslt.getInt(39);
              ((int[]) buf[40])[0] = rslt.getInt(40);
              ((bool[]) buf[41])[0] = rslt.wasNull(40);
              ((int[]) buf[42])[0] = rslt.getInt(41);
              ((bool[]) buf[43])[0] = rslt.wasNull(41);
              ((int[]) buf[44])[0] = rslt.getInt(42);
              ((string[]) buf[45])[0] = rslt.getVarchar(43);
              ((bool[]) buf[46])[0] = rslt.wasNull(43);
              ((int[]) buf[47])[0] = rslt.getInt(44);
              ((bool[]) buf[48])[0] = rslt.wasNull(44);
              ((string[]) buf[49])[0] = rslt.getString(45, 15);
              ((bool[]) buf[50])[0] = rslt.wasNull(45);
              ((string[]) buf[51])[0] = rslt.getString(46, 15);
              ((bool[]) buf[52])[0] = rslt.wasNull(46);
              ((string[]) buf[53])[0] = rslt.getString(47, 15);
              ((bool[]) buf[54])[0] = rslt.wasNull(47);
              ((string[]) buf[55])[0] = rslt.getMultimediaFile(48, rslt.getVarchar(9));
              ((bool[]) buf[56])[0] = rslt.wasNull(48);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 20);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((string[]) buf[12])[0] = rslt.getString(12, 20);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((string[]) buf[14])[0] = rslt.getString(14, 20);
              ((string[]) buf[15])[0] = rslt.getString(15, 20);
              ((string[]) buf[16])[0] = rslt.getString(16, 20);
              ((string[]) buf[17])[0] = rslt.getString(17, 20);
              ((string[]) buf[18])[0] = rslt.getString(18, 20);
              ((string[]) buf[19])[0] = rslt.getString(19, 20);
              ((short[]) buf[20])[0] = rslt.getShort(20);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(22);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
              ((short[]) buf[24])[0] = rslt.getShort(24);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(26);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(27);
              ((short[]) buf[28])[0] = rslt.getShort(28);
              ((string[]) buf[29])[0] = rslt.getString(29, 100);
              ((string[]) buf[30])[0] = rslt.getString(30, 100);
              ((string[]) buf[31])[0] = rslt.getString(31, 100);
              ((string[]) buf[32])[0] = rslt.getString(32, 10);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((string[]) buf[35])[0] = rslt.getVarchar(35);
              ((decimal[]) buf[36])[0] = rslt.getDecimal(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((string[]) buf[38])[0] = rslt.getVarchar(38);
              ((short[]) buf[39])[0] = rslt.getShort(39);
              ((decimal[]) buf[40])[0] = rslt.getDecimal(40);
              ((decimal[]) buf[41])[0] = rslt.getDecimal(41);
              ((string[]) buf[42])[0] = rslt.getString(42, 100);
              ((int[]) buf[43])[0] = rslt.getInt(43);
              ((int[]) buf[44])[0] = rslt.getInt(44);
              ((bool[]) buf[45])[0] = rslt.wasNull(44);
              ((int[]) buf[46])[0] = rslt.getInt(45);
              ((bool[]) buf[47])[0] = rslt.wasNull(45);
              ((int[]) buf[48])[0] = rslt.getInt(46);
              ((string[]) buf[49])[0] = rslt.getVarchar(47);
              ((bool[]) buf[50])[0] = rslt.wasNull(47);
              ((int[]) buf[51])[0] = rslt.getInt(48);
              ((bool[]) buf[52])[0] = rslt.wasNull(48);
              ((string[]) buf[53])[0] = rslt.getString(49, 15);
              ((bool[]) buf[54])[0] = rslt.wasNull(49);
              ((string[]) buf[55])[0] = rslt.getString(50, 15);
              ((bool[]) buf[56])[0] = rslt.wasNull(50);
              ((string[]) buf[57])[0] = rslt.getString(51, 15);
              ((bool[]) buf[58])[0] = rslt.wasNull(51);
              ((string[]) buf[59])[0] = rslt.getMultimediaFile(52, rslt.getVarchar(9));
              ((bool[]) buf[60])[0] = rslt.wasNull(52);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 45 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 48 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 49 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 50 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 54 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 55 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 57 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 58 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 59 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
     getresults60( cursor, rslt, buf) ;
  }

  public void getresults60( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 60 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 61 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 62 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 63 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 64 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 65 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 66 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 67 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 68 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 69 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 70 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
