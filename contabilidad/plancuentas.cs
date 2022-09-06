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
   public class plancuentas : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A109CueGasDebe = GetPar( "CueGasDebe");
            n109CueGasDebe = false;
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A109CueGasDebe) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A110CueGasHaber = GetPar( "CueGasHaber");
            n110CueGasHaber = false;
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A110CueGasHaber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A111CueMonDebe = GetPar( "CueMonDebe");
            n111CueMonDebe = false;
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A111CueMonDebe) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A112CueMonHaber = GetPar( "CueMonHaber");
            n112CueMonHaber = false;
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A112CueMonHaber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A70TipACod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A113CueCierre = GetPar( "CueCierre");
            n113CueCierre = false;
            AssignAttri("", false, "A113CueCierre", A113CueCierre);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A113CueCierre) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.plancuentas.aspx")), "contabilidad.plancuentas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.plancuentas.aspx")))) ;
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
                  AV7CueCod = GetPar( "CueCod");
                  AssignAttri("", false, "AV7CueCod", AV7CueCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCUECOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CueCod, "")), context));
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
            Form.Meta.addItem("description", "Plan de Cuentas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public plancuentas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public plancuentas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CueCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CueCod = aP1_CueCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCueSts = new GXCombobox();
         cmbCueBienes = new GXCombobox();
         cmbCueRef4 = new GXCombobox();
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
         if ( cmbCueSts.ItemCount > 0 )
         {
            A873CueSts = (short)(NumberUtil.Val( cmbCueSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0))), "."));
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            AssignProp("", false, cmbCueSts_Internalname, "Values", cmbCueSts.ToJavascriptSource(), true);
         }
         if ( cmbCueBienes.ItemCount > 0 )
         {
            A2099CueBienes = (int)(NumberUtil.Val( cmbCueBienes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2099CueBienes), 6, 0))), "."));
            AssignAttri("", false, "A2099CueBienes", StringUtil.LTrimStr( (decimal)(A2099CueBienes), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueBienes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2099CueBienes), 6, 0));
            AssignProp("", false, cmbCueBienes_Internalname, "Values", cmbCueBienes.ToJavascriptSource(), true);
         }
         if ( cmbCueRef4.ItemCount > 0 )
         {
            A871CueRef4 = (short)(NumberUtil.Val( cmbCueRef4.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0))), "."));
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueRef4.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            AssignProp("", false, cmbCueRef4_Internalname, "Values", cmbCueRef4.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueCod_Internalname, "Cuenta Contable", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCueSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCueSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCueSts, cmbCueSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0)), 1, cmbCueSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCueSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentas.htm");
         cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         AssignProp("", false, cmbCueSts_Internalname, "Values", (string)(cmbCueSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablecuedsc_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuedsc_Internalname, "Descripción", "", "", lblTextblockcuedsc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueDsc_Internalname, "Descripción de Cuenta", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc), StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtipacod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktipacod_Internalname, "Tipo Auxiliar", "", "", lblTextblocktipacod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tipacod.SetProperty("Caption", Combo_tipacod_Caption);
         ucCombo_tipacod.SetProperty("Cls", Combo_tipacod_Cls);
         ucCombo_tipacod.SetProperty("DataListProc", Combo_tipacod_Datalistproc);
         ucCombo_tipacod.SetProperty("DataListProcParametersPrefix", Combo_tipacod_Datalistprocparametersprefix);
         ucCombo_tipacod.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_tipacod.SetProperty("DropDownOptionsData", AV30TipACod_Data);
         ucCombo_tipacod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipacod_Internalname, "COMBO_TIPACODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipACod_Internalname, "Codigo T. Auxiliar", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipACod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipACod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipACod_Visible, edtTipACod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
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
         GxWebStd.gx_div_start( context, divUnnamedtablecuebienes_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuebienes_Internalname, "Clasificación B y/o Servicios", "", "", lblTextblockcuebienes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCueBienes_Internalname, "Clasificación Bienes y Servicios", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCueBienes, cmbCueBienes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2099CueBienes), 6, 0)), 1, cmbCueBienes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCueBienes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentas.htm");
         cmbCueBienes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2099CueBienes), 6, 0));
         AssignProp("", false, cmbCueBienes_Internalname, "Values", (string)(cmbCueBienes.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueMov_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueMov_Internalname, "Movimiento Cuenta", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A867CueMov), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueMov_Enabled!=0) ? context.localUtil.Format( (decimal)(A867CueMov), "9") : context.localUtil.Format( (decimal)(A867CueMov), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMov_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueMov_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueMon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueMon_Internalname, "Monetaria", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A864CueMon), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A864CueMon), "9") : context.localUtil.Format( (decimal)(A864CueMon), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMon_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueMon_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueCos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueCos_Internalname, "Centro de Costos", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A859CueCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A859CueCos), "9") : context.localUtil.Format( (decimal)(A859CueCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCos_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCueRef4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCueRef4_Internalname, "Tipo de Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCueRef4, cmbCueRef4_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0)), 1, cmbCueRef4_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCueRef4.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 1, "HLP_Contabilidad\\PlanCuentas.htm");
         cmbCueRef4.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         AssignProp("", false, cmbCueRef4_Internalname, "Values", (string)(cmbCueRef4.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Afectación", 1, 0, "px", 0, "px", "Group", "", "HLP_Contabilidad\\PlanCuentas.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divGrupo1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueRef1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueRef1_Internalname, "Balance General", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A868CueRef1), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef1_Enabled!=0) ? context.localUtil.Format( (decimal)(A868CueRef1), "9") : context.localUtil.Format( (decimal)(A868CueRef1), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef1_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueRef1_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueRef2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueRef2_Internalname, "Estado Ganancia y Perdida(Función)", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A869CueRef2), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef2_Enabled!=0) ? context.localUtil.Format( (decimal)(A869CueRef2), "9") : context.localUtil.Format( (decimal)(A869CueRef2), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef2_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueRef2_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueRef3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueRef3_Internalname, "Estado Ganancia y Perdida(Naturaleza)", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A870CueRef3), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef3_Enabled!=0) ? context.localUtil.Format( (decimal)(A870CueRef3), "9") : context.localUtil.Format( (decimal)(A870CueRef3), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef3_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueRef3_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCueRef5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueRef5_Internalname, "Estado de Costos", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef5_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A872CueRef5), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef5_Enabled!=0) ? context.localUtil.Format( (decimal)(A872CueRef5), "9") : context.localUtil.Format( (decimal)(A872CueRef5), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef5_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtCueRef5_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Cuentas Destino", 1, 0, "px", 0, "px", "Group", "", "HLP_Contabilidad\\PlanCuentas.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTab2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcuegasdebe_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuegasdebe_Internalname, "Cuenta de Gasto Debe", "", "", lblTextblockcuegasdebe_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuegasdebe.SetProperty("Caption", Combo_cuegasdebe_Caption);
         ucCombo_cuegasdebe.SetProperty("Cls", Combo_cuegasdebe_Cls);
         ucCombo_cuegasdebe.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_cuegasdebe.SetProperty("DropDownOptionsData", AV18CueGasDebe_Data);
         ucCombo_cuegasdebe.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuegasdebe_Internalname, "COMBO_CUEGASDEBEContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueGasDebe_Internalname, "Cuenta de Gasto Debe", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueGasDebe_Internalname, StringUtil.RTrim( A109CueGasDebe), StringUtil.RTrim( context.localUtil.Format( A109CueGasDebe, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueGasDebe_Jsonclick, 0, "Attribute", "", "", "", "", edtCueGasDebe_Visible, edtCueGasDebe_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcuegashaber_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuegashaber_Internalname, "Cuenta de Gasto Haber", "", "", lblTextblockcuegashaber_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuegashaber.SetProperty("Caption", Combo_cuegashaber_Caption);
         ucCombo_cuegashaber.SetProperty("Cls", Combo_cuegashaber_Cls);
         ucCombo_cuegashaber.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_cuegashaber.SetProperty("DropDownOptionsData", AV24CueGasHaber_Data);
         ucCombo_cuegashaber.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuegashaber_Internalname, "COMBO_CUEGASHABERContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueGasHaber_Internalname, "Cuenta de Gasto Haber", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueGasHaber_Internalname, StringUtil.RTrim( A110CueGasHaber), StringUtil.RTrim( context.localUtil.Format( A110CueGasHaber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueGasHaber_Jsonclick, 0, "Attribute", "", "", "", "", edtCueGasHaber_Visible, edtCueGasHaber_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Cuentas Monetarias", 1, 0, "px", 0, "px", "Group", "", "HLP_Contabilidad\\PlanCuentas.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTab3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcuemondebe_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuemondebe_Internalname, "Cuenta Monetaria Debe", "", "", lblTextblockcuemondebe_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuemondebe.SetProperty("Caption", Combo_cuemondebe_Caption);
         ucCombo_cuemondebe.SetProperty("Cls", Combo_cuemondebe_Cls);
         ucCombo_cuemondebe.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_cuemondebe.SetProperty("DropDownOptionsData", AV26CueMonDebe_Data);
         ucCombo_cuemondebe.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuemondebe_Internalname, "COMBO_CUEMONDEBEContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueMonDebe_Internalname, "Cuenta Monetaria Debe", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMonDebe_Internalname, StringUtil.RTrim( A111CueMonDebe), StringUtil.RTrim( context.localUtil.Format( A111CueMonDebe, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMonDebe_Jsonclick, 0, "Attribute", "", "", "", "", edtCueMonDebe_Visible, edtCueMonDebe_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcuemonhaber_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuemonhaber_Internalname, "Cuenta Monetaria Haber", "", "", lblTextblockcuemonhaber_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuemonhaber.SetProperty("Caption", Combo_cuemonhaber_Caption);
         ucCombo_cuemonhaber.SetProperty("Cls", Combo_cuemonhaber_Cls);
         ucCombo_cuemonhaber.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_cuemonhaber.SetProperty("DropDownOptionsData", AV28CueMonHaber_Data);
         ucCombo_cuemonhaber.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuemonhaber_Internalname, "COMBO_CUEMONHABERContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueMonHaber_Internalname, "Cuenta Monetaria Haber", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMonHaber_Internalname, StringUtil.RTrim( A112CueMonHaber), StringUtil.RTrim( context.localUtil.Format( A112CueMonHaber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMonHaber_Jsonclick, 0, "Attribute", "", "", "", "", edtCueMonHaber_Visible, edtCueMonHaber_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, "Cuenta Cierre", 1, 0, "px", 0, "px", "Group", "", "HLP_Contabilidad\\PlanCuentas.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTab4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcuecierre_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcuecierre_Internalname, "Cierre", "", "", lblTextblockcuecierre_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cuecierre.SetProperty("Caption", Combo_cuecierre_Caption);
         ucCombo_cuecierre.SetProperty("Cls", Combo_cuecierre_Cls);
         ucCombo_cuecierre.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_cuecierre.SetProperty("DropDownOptionsData", AV32CueCierre_Data);
         ucCombo_cuecierre.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cuecierre_Internalname, "COMBO_CUECIERREContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCueCierre_Internalname, "Cuenta Cierre", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCierre_Internalname, StringUtil.RTrim( A113CueCierre), StringUtil.RTrim( context.localUtil.Format( A113CueCierre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCierre_Jsonclick, 0, "Attribute", "", "", "", "", edtCueCierre_Visible, edtCueCierre_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\PlanCuentas.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_tipacod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotipacod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ComboTipACod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotipacod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31ComboTipACod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV31ComboTipACod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotipacod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotipacod_Visible, edtavCombotipacod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cuegasdebe_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocuegasdebe_Internalname, StringUtil.RTrim( AV23ComboCueGasDebe), StringUtil.RTrim( context.localUtil.Format( AV23ComboCueGasDebe, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuegasdebe_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuegasdebe_Visible, edtavCombocuegasdebe_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cuegashaber_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocuegashaber_Internalname, StringUtil.RTrim( AV25ComboCueGasHaber), StringUtil.RTrim( context.localUtil.Format( AV25ComboCueGasHaber, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuegashaber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuegashaber_Visible, edtavCombocuegashaber_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cuemondebe_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocuemondebe_Internalname, StringUtil.RTrim( AV27ComboCueMonDebe), StringUtil.RTrim( context.localUtil.Format( AV27ComboCueMonDebe, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuemondebe_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuemondebe_Visible, edtavCombocuemondebe_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cuemonhaber_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocuemonhaber_Internalname, StringUtil.RTrim( AV29ComboCueMonHaber), StringUtil.RTrim( context.localUtil.Format( AV29ComboCueMonHaber, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuemonhaber_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuemonhaber_Visible, edtavCombocuemonhaber_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cuecierre_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocuecierre_Internalname, StringUtil.RTrim( AV33ComboCueCierre), StringUtil.RTrim( context.localUtil.Format( AV33ComboCueCierre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocuecierre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocuecierre_Visible, edtavCombocuecierre_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\PlanCuentas.htm");
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
         E116L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPACOD_DATA"), AV30TipACod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCUEGASDEBE_DATA"), AV18CueGasDebe_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCUEGASHABER_DATA"), AV24CueGasHaber_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCUEMONDEBE_DATA"), AV26CueMonDebe_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCUEMONHABER_DATA"), AV28CueMonHaber_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCUECIERRE_DATA"), AV32CueCierre_Data);
               /* Read saved values. */
               Z91CueCod = cgiGet( "Z91CueCod");
               Z860CueDsc = cgiGet( "Z860CueDsc");
               Z857CueAbr = cgiGet( "Z857CueAbr");
               Z867CueMov = (short)(context.localUtil.CToN( cgiGet( "Z867CueMov"), ".", ","));
               Z864CueMon = (short)(context.localUtil.CToN( cgiGet( "Z864CueMon"), ".", ","));
               Z859CueCos = (short)(context.localUtil.CToN( cgiGet( "Z859CueCos"), ".", ","));
               Z873CueSts = (short)(context.localUtil.CToN( cgiGet( "Z873CueSts"), ".", ","));
               Z868CueRef1 = (short)(context.localUtil.CToN( cgiGet( "Z868CueRef1"), ".", ","));
               Z869CueRef2 = (short)(context.localUtil.CToN( cgiGet( "Z869CueRef2"), ".", ","));
               Z870CueRef3 = (short)(context.localUtil.CToN( cgiGet( "Z870CueRef3"), ".", ","));
               Z871CueRef4 = (short)(context.localUtil.CToN( cgiGet( "Z871CueRef4"), ".", ","));
               Z2099CueBienes = (int)(context.localUtil.CToN( cgiGet( "Z2099CueBienes"), ".", ","));
               Z872CueRef5 = (short)(context.localUtil.CToN( cgiGet( "Z872CueRef5"), ".", ","));
               Z863CueGrupDoc = (short)(context.localUtil.CToN( cgiGet( "Z863CueGrupDoc"), ".", ","));
               Z70TipACod = (int)(context.localUtil.CToN( cgiGet( "Z70TipACod"), ".", ","));
               n70TipACod = ((0==A70TipACod) ? true : false);
               Z109CueGasDebe = cgiGet( "Z109CueGasDebe");
               Z110CueGasHaber = cgiGet( "Z110CueGasHaber");
               Z111CueMonDebe = cgiGet( "Z111CueMonDebe");
               Z112CueMonHaber = cgiGet( "Z112CueMonHaber");
               Z113CueCierre = cgiGet( "Z113CueCierre");
               n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
               A857CueAbr = cgiGet( "Z857CueAbr");
               n857CueAbr = false;
               A863CueGrupDoc = (short)(context.localUtil.CToN( cgiGet( "Z863CueGrupDoc"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N109CueGasDebe = cgiGet( "N109CueGasDebe");
               N110CueGasHaber = cgiGet( "N110CueGasHaber");
               N111CueMonDebe = cgiGet( "N111CueMonDebe");
               N112CueMonHaber = cgiGet( "N112CueMonHaber");
               N70TipACod = (int)(context.localUtil.CToN( cgiGet( "N70TipACod"), ".", ","));
               n70TipACod = ((0==A70TipACod) ? true : false);
               N113CueCierre = cgiGet( "N113CueCierre");
               n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
               A2098CueDscCompleto = cgiGet( "CUEDSCCOMPLETO");
               AV7CueCod = cgiGet( "vCUECOD");
               AV11Insert_CueGasDebe = cgiGet( "vINSERT_CUEGASDEBE");
               AV12Insert_CueGasHaber = cgiGet( "vINSERT_CUEGASHABER");
               AV13Insert_CueMonDebe = cgiGet( "vINSERT_CUEMONDEBE");
               AV14Insert_CueMonHaber = cgiGet( "vINSERT_CUEMONHABER");
               AV15Insert_TipACod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TIPACOD"), ".", ","));
               AV16Insert_CueCierre = cgiGet( "vINSERT_CUECIERRE");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A857CueAbr = cgiGet( "CUEABR");
               A863CueGrupDoc = (short)(context.localUtil.CToN( cgiGet( "CUEGRUPDOC"), ".", ","));
               A858CueCierreDsc = cgiGet( "CUECIERREDSC");
               AV37Pgmname = cgiGet( "vPGMNAME");
               Combo_tipacod_Objectcall = cgiGet( "COMBO_TIPACOD_Objectcall");
               Combo_tipacod_Class = cgiGet( "COMBO_TIPACOD_Class");
               Combo_tipacod_Icontype = cgiGet( "COMBO_TIPACOD_Icontype");
               Combo_tipacod_Icon = cgiGet( "COMBO_TIPACOD_Icon");
               Combo_tipacod_Caption = cgiGet( "COMBO_TIPACOD_Caption");
               Combo_tipacod_Tooltip = cgiGet( "COMBO_TIPACOD_Tooltip");
               Combo_tipacod_Cls = cgiGet( "COMBO_TIPACOD_Cls");
               Combo_tipacod_Selectedvalue_set = cgiGet( "COMBO_TIPACOD_Selectedvalue_set");
               Combo_tipacod_Selectedvalue_get = cgiGet( "COMBO_TIPACOD_Selectedvalue_get");
               Combo_tipacod_Selectedtext_set = cgiGet( "COMBO_TIPACOD_Selectedtext_set");
               Combo_tipacod_Selectedtext_get = cgiGet( "COMBO_TIPACOD_Selectedtext_get");
               Combo_tipacod_Gamoauthtoken = cgiGet( "COMBO_TIPACOD_Gamoauthtoken");
               Combo_tipacod_Ddointernalname = cgiGet( "COMBO_TIPACOD_Ddointernalname");
               Combo_tipacod_Titlecontrolalign = cgiGet( "COMBO_TIPACOD_Titlecontrolalign");
               Combo_tipacod_Dropdownoptionstype = cgiGet( "COMBO_TIPACOD_Dropdownoptionstype");
               Combo_tipacod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Enabled"));
               Combo_tipacod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Visible"));
               Combo_tipacod_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPACOD_Titlecontrolidtoreplace");
               Combo_tipacod_Datalisttype = cgiGet( "COMBO_TIPACOD_Datalisttype");
               Combo_tipacod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Allowmultipleselection"));
               Combo_tipacod_Datalistfixedvalues = cgiGet( "COMBO_TIPACOD_Datalistfixedvalues");
               Combo_tipacod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Isgriditem"));
               Combo_tipacod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Hasdescription"));
               Combo_tipacod_Datalistproc = cgiGet( "COMBO_TIPACOD_Datalistproc");
               Combo_tipacod_Datalistprocparametersprefix = cgiGet( "COMBO_TIPACOD_Datalistprocparametersprefix");
               Combo_tipacod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPACOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tipacod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Includeonlyselectedoption"));
               Combo_tipacod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Includeselectalloption"));
               Combo_tipacod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Emptyitem"));
               Combo_tipacod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Includeaddnewoption"));
               Combo_tipacod_Htmltemplate = cgiGet( "COMBO_TIPACOD_Htmltemplate");
               Combo_tipacod_Multiplevaluestype = cgiGet( "COMBO_TIPACOD_Multiplevaluestype");
               Combo_tipacod_Loadingdata = cgiGet( "COMBO_TIPACOD_Loadingdata");
               Combo_tipacod_Noresultsfound = cgiGet( "COMBO_TIPACOD_Noresultsfound");
               Combo_tipacod_Emptyitemtext = cgiGet( "COMBO_TIPACOD_Emptyitemtext");
               Combo_tipacod_Onlyselectedvalues = cgiGet( "COMBO_TIPACOD_Onlyselectedvalues");
               Combo_tipacod_Selectalltext = cgiGet( "COMBO_TIPACOD_Selectalltext");
               Combo_tipacod_Multiplevaluesseparator = cgiGet( "COMBO_TIPACOD_Multiplevaluesseparator");
               Combo_tipacod_Addnewoptiontext = cgiGet( "COMBO_TIPACOD_Addnewoptiontext");
               Combo_tipacod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPACOD_Gxcontroltype"), ".", ","));
               Combo_cuegasdebe_Objectcall = cgiGet( "COMBO_CUEGASDEBE_Objectcall");
               Combo_cuegasdebe_Class = cgiGet( "COMBO_CUEGASDEBE_Class");
               Combo_cuegasdebe_Icontype = cgiGet( "COMBO_CUEGASDEBE_Icontype");
               Combo_cuegasdebe_Icon = cgiGet( "COMBO_CUEGASDEBE_Icon");
               Combo_cuegasdebe_Caption = cgiGet( "COMBO_CUEGASDEBE_Caption");
               Combo_cuegasdebe_Tooltip = cgiGet( "COMBO_CUEGASDEBE_Tooltip");
               Combo_cuegasdebe_Cls = cgiGet( "COMBO_CUEGASDEBE_Cls");
               Combo_cuegasdebe_Selectedvalue_set = cgiGet( "COMBO_CUEGASDEBE_Selectedvalue_set");
               Combo_cuegasdebe_Selectedvalue_get = cgiGet( "COMBO_CUEGASDEBE_Selectedvalue_get");
               Combo_cuegasdebe_Selectedtext_set = cgiGet( "COMBO_CUEGASDEBE_Selectedtext_set");
               Combo_cuegasdebe_Selectedtext_get = cgiGet( "COMBO_CUEGASDEBE_Selectedtext_get");
               Combo_cuegasdebe_Gamoauthtoken = cgiGet( "COMBO_CUEGASDEBE_Gamoauthtoken");
               Combo_cuegasdebe_Ddointernalname = cgiGet( "COMBO_CUEGASDEBE_Ddointernalname");
               Combo_cuegasdebe_Titlecontrolalign = cgiGet( "COMBO_CUEGASDEBE_Titlecontrolalign");
               Combo_cuegasdebe_Dropdownoptionstype = cgiGet( "COMBO_CUEGASDEBE_Dropdownoptionstype");
               Combo_cuegasdebe_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Enabled"));
               Combo_cuegasdebe_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Visible"));
               Combo_cuegasdebe_Titlecontrolidtoreplace = cgiGet( "COMBO_CUEGASDEBE_Titlecontrolidtoreplace");
               Combo_cuegasdebe_Datalisttype = cgiGet( "COMBO_CUEGASDEBE_Datalisttype");
               Combo_cuegasdebe_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Allowmultipleselection"));
               Combo_cuegasdebe_Datalistfixedvalues = cgiGet( "COMBO_CUEGASDEBE_Datalistfixedvalues");
               Combo_cuegasdebe_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Isgriditem"));
               Combo_cuegasdebe_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Hasdescription"));
               Combo_cuegasdebe_Datalistproc = cgiGet( "COMBO_CUEGASDEBE_Datalistproc");
               Combo_cuegasdebe_Datalistprocparametersprefix = cgiGet( "COMBO_CUEGASDEBE_Datalistprocparametersprefix");
               Combo_cuegasdebe_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEGASDEBE_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cuegasdebe_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Includeonlyselectedoption"));
               Combo_cuegasdebe_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Includeselectalloption"));
               Combo_cuegasdebe_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Emptyitem"));
               Combo_cuegasdebe_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASDEBE_Includeaddnewoption"));
               Combo_cuegasdebe_Htmltemplate = cgiGet( "COMBO_CUEGASDEBE_Htmltemplate");
               Combo_cuegasdebe_Multiplevaluestype = cgiGet( "COMBO_CUEGASDEBE_Multiplevaluestype");
               Combo_cuegasdebe_Loadingdata = cgiGet( "COMBO_CUEGASDEBE_Loadingdata");
               Combo_cuegasdebe_Noresultsfound = cgiGet( "COMBO_CUEGASDEBE_Noresultsfound");
               Combo_cuegasdebe_Emptyitemtext = cgiGet( "COMBO_CUEGASDEBE_Emptyitemtext");
               Combo_cuegasdebe_Onlyselectedvalues = cgiGet( "COMBO_CUEGASDEBE_Onlyselectedvalues");
               Combo_cuegasdebe_Selectalltext = cgiGet( "COMBO_CUEGASDEBE_Selectalltext");
               Combo_cuegasdebe_Multiplevaluesseparator = cgiGet( "COMBO_CUEGASDEBE_Multiplevaluesseparator");
               Combo_cuegasdebe_Addnewoptiontext = cgiGet( "COMBO_CUEGASDEBE_Addnewoptiontext");
               Combo_cuegasdebe_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEGASDEBE_Gxcontroltype"), ".", ","));
               Combo_cuegashaber_Objectcall = cgiGet( "COMBO_CUEGASHABER_Objectcall");
               Combo_cuegashaber_Class = cgiGet( "COMBO_CUEGASHABER_Class");
               Combo_cuegashaber_Icontype = cgiGet( "COMBO_CUEGASHABER_Icontype");
               Combo_cuegashaber_Icon = cgiGet( "COMBO_CUEGASHABER_Icon");
               Combo_cuegashaber_Caption = cgiGet( "COMBO_CUEGASHABER_Caption");
               Combo_cuegashaber_Tooltip = cgiGet( "COMBO_CUEGASHABER_Tooltip");
               Combo_cuegashaber_Cls = cgiGet( "COMBO_CUEGASHABER_Cls");
               Combo_cuegashaber_Selectedvalue_set = cgiGet( "COMBO_CUEGASHABER_Selectedvalue_set");
               Combo_cuegashaber_Selectedvalue_get = cgiGet( "COMBO_CUEGASHABER_Selectedvalue_get");
               Combo_cuegashaber_Selectedtext_set = cgiGet( "COMBO_CUEGASHABER_Selectedtext_set");
               Combo_cuegashaber_Selectedtext_get = cgiGet( "COMBO_CUEGASHABER_Selectedtext_get");
               Combo_cuegashaber_Gamoauthtoken = cgiGet( "COMBO_CUEGASHABER_Gamoauthtoken");
               Combo_cuegashaber_Ddointernalname = cgiGet( "COMBO_CUEGASHABER_Ddointernalname");
               Combo_cuegashaber_Titlecontrolalign = cgiGet( "COMBO_CUEGASHABER_Titlecontrolalign");
               Combo_cuegashaber_Dropdownoptionstype = cgiGet( "COMBO_CUEGASHABER_Dropdownoptionstype");
               Combo_cuegashaber_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Enabled"));
               Combo_cuegashaber_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Visible"));
               Combo_cuegashaber_Titlecontrolidtoreplace = cgiGet( "COMBO_CUEGASHABER_Titlecontrolidtoreplace");
               Combo_cuegashaber_Datalisttype = cgiGet( "COMBO_CUEGASHABER_Datalisttype");
               Combo_cuegashaber_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Allowmultipleselection"));
               Combo_cuegashaber_Datalistfixedvalues = cgiGet( "COMBO_CUEGASHABER_Datalistfixedvalues");
               Combo_cuegashaber_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Isgriditem"));
               Combo_cuegashaber_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Hasdescription"));
               Combo_cuegashaber_Datalistproc = cgiGet( "COMBO_CUEGASHABER_Datalistproc");
               Combo_cuegashaber_Datalistprocparametersprefix = cgiGet( "COMBO_CUEGASHABER_Datalistprocparametersprefix");
               Combo_cuegashaber_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEGASHABER_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cuegashaber_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Includeonlyselectedoption"));
               Combo_cuegashaber_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Includeselectalloption"));
               Combo_cuegashaber_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Emptyitem"));
               Combo_cuegashaber_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEGASHABER_Includeaddnewoption"));
               Combo_cuegashaber_Htmltemplate = cgiGet( "COMBO_CUEGASHABER_Htmltemplate");
               Combo_cuegashaber_Multiplevaluestype = cgiGet( "COMBO_CUEGASHABER_Multiplevaluestype");
               Combo_cuegashaber_Loadingdata = cgiGet( "COMBO_CUEGASHABER_Loadingdata");
               Combo_cuegashaber_Noresultsfound = cgiGet( "COMBO_CUEGASHABER_Noresultsfound");
               Combo_cuegashaber_Emptyitemtext = cgiGet( "COMBO_CUEGASHABER_Emptyitemtext");
               Combo_cuegashaber_Onlyselectedvalues = cgiGet( "COMBO_CUEGASHABER_Onlyselectedvalues");
               Combo_cuegashaber_Selectalltext = cgiGet( "COMBO_CUEGASHABER_Selectalltext");
               Combo_cuegashaber_Multiplevaluesseparator = cgiGet( "COMBO_CUEGASHABER_Multiplevaluesseparator");
               Combo_cuegashaber_Addnewoptiontext = cgiGet( "COMBO_CUEGASHABER_Addnewoptiontext");
               Combo_cuegashaber_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEGASHABER_Gxcontroltype"), ".", ","));
               Combo_cuemondebe_Objectcall = cgiGet( "COMBO_CUEMONDEBE_Objectcall");
               Combo_cuemondebe_Class = cgiGet( "COMBO_CUEMONDEBE_Class");
               Combo_cuemondebe_Icontype = cgiGet( "COMBO_CUEMONDEBE_Icontype");
               Combo_cuemondebe_Icon = cgiGet( "COMBO_CUEMONDEBE_Icon");
               Combo_cuemondebe_Caption = cgiGet( "COMBO_CUEMONDEBE_Caption");
               Combo_cuemondebe_Tooltip = cgiGet( "COMBO_CUEMONDEBE_Tooltip");
               Combo_cuemondebe_Cls = cgiGet( "COMBO_CUEMONDEBE_Cls");
               Combo_cuemondebe_Selectedvalue_set = cgiGet( "COMBO_CUEMONDEBE_Selectedvalue_set");
               Combo_cuemondebe_Selectedvalue_get = cgiGet( "COMBO_CUEMONDEBE_Selectedvalue_get");
               Combo_cuemondebe_Selectedtext_set = cgiGet( "COMBO_CUEMONDEBE_Selectedtext_set");
               Combo_cuemondebe_Selectedtext_get = cgiGet( "COMBO_CUEMONDEBE_Selectedtext_get");
               Combo_cuemondebe_Gamoauthtoken = cgiGet( "COMBO_CUEMONDEBE_Gamoauthtoken");
               Combo_cuemondebe_Ddointernalname = cgiGet( "COMBO_CUEMONDEBE_Ddointernalname");
               Combo_cuemondebe_Titlecontrolalign = cgiGet( "COMBO_CUEMONDEBE_Titlecontrolalign");
               Combo_cuemondebe_Dropdownoptionstype = cgiGet( "COMBO_CUEMONDEBE_Dropdownoptionstype");
               Combo_cuemondebe_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Enabled"));
               Combo_cuemondebe_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Visible"));
               Combo_cuemondebe_Titlecontrolidtoreplace = cgiGet( "COMBO_CUEMONDEBE_Titlecontrolidtoreplace");
               Combo_cuemondebe_Datalisttype = cgiGet( "COMBO_CUEMONDEBE_Datalisttype");
               Combo_cuemondebe_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Allowmultipleselection"));
               Combo_cuemondebe_Datalistfixedvalues = cgiGet( "COMBO_CUEMONDEBE_Datalistfixedvalues");
               Combo_cuemondebe_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Isgriditem"));
               Combo_cuemondebe_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Hasdescription"));
               Combo_cuemondebe_Datalistproc = cgiGet( "COMBO_CUEMONDEBE_Datalistproc");
               Combo_cuemondebe_Datalistprocparametersprefix = cgiGet( "COMBO_CUEMONDEBE_Datalistprocparametersprefix");
               Combo_cuemondebe_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEMONDEBE_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cuemondebe_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Includeonlyselectedoption"));
               Combo_cuemondebe_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Includeselectalloption"));
               Combo_cuemondebe_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Emptyitem"));
               Combo_cuemondebe_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONDEBE_Includeaddnewoption"));
               Combo_cuemondebe_Htmltemplate = cgiGet( "COMBO_CUEMONDEBE_Htmltemplate");
               Combo_cuemondebe_Multiplevaluestype = cgiGet( "COMBO_CUEMONDEBE_Multiplevaluestype");
               Combo_cuemondebe_Loadingdata = cgiGet( "COMBO_CUEMONDEBE_Loadingdata");
               Combo_cuemondebe_Noresultsfound = cgiGet( "COMBO_CUEMONDEBE_Noresultsfound");
               Combo_cuemondebe_Emptyitemtext = cgiGet( "COMBO_CUEMONDEBE_Emptyitemtext");
               Combo_cuemondebe_Onlyselectedvalues = cgiGet( "COMBO_CUEMONDEBE_Onlyselectedvalues");
               Combo_cuemondebe_Selectalltext = cgiGet( "COMBO_CUEMONDEBE_Selectalltext");
               Combo_cuemondebe_Multiplevaluesseparator = cgiGet( "COMBO_CUEMONDEBE_Multiplevaluesseparator");
               Combo_cuemondebe_Addnewoptiontext = cgiGet( "COMBO_CUEMONDEBE_Addnewoptiontext");
               Combo_cuemondebe_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEMONDEBE_Gxcontroltype"), ".", ","));
               Combo_cuemonhaber_Objectcall = cgiGet( "COMBO_CUEMONHABER_Objectcall");
               Combo_cuemonhaber_Class = cgiGet( "COMBO_CUEMONHABER_Class");
               Combo_cuemonhaber_Icontype = cgiGet( "COMBO_CUEMONHABER_Icontype");
               Combo_cuemonhaber_Icon = cgiGet( "COMBO_CUEMONHABER_Icon");
               Combo_cuemonhaber_Caption = cgiGet( "COMBO_CUEMONHABER_Caption");
               Combo_cuemonhaber_Tooltip = cgiGet( "COMBO_CUEMONHABER_Tooltip");
               Combo_cuemonhaber_Cls = cgiGet( "COMBO_CUEMONHABER_Cls");
               Combo_cuemonhaber_Selectedvalue_set = cgiGet( "COMBO_CUEMONHABER_Selectedvalue_set");
               Combo_cuemonhaber_Selectedvalue_get = cgiGet( "COMBO_CUEMONHABER_Selectedvalue_get");
               Combo_cuemonhaber_Selectedtext_set = cgiGet( "COMBO_CUEMONHABER_Selectedtext_set");
               Combo_cuemonhaber_Selectedtext_get = cgiGet( "COMBO_CUEMONHABER_Selectedtext_get");
               Combo_cuemonhaber_Gamoauthtoken = cgiGet( "COMBO_CUEMONHABER_Gamoauthtoken");
               Combo_cuemonhaber_Ddointernalname = cgiGet( "COMBO_CUEMONHABER_Ddointernalname");
               Combo_cuemonhaber_Titlecontrolalign = cgiGet( "COMBO_CUEMONHABER_Titlecontrolalign");
               Combo_cuemonhaber_Dropdownoptionstype = cgiGet( "COMBO_CUEMONHABER_Dropdownoptionstype");
               Combo_cuemonhaber_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Enabled"));
               Combo_cuemonhaber_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Visible"));
               Combo_cuemonhaber_Titlecontrolidtoreplace = cgiGet( "COMBO_CUEMONHABER_Titlecontrolidtoreplace");
               Combo_cuemonhaber_Datalisttype = cgiGet( "COMBO_CUEMONHABER_Datalisttype");
               Combo_cuemonhaber_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Allowmultipleselection"));
               Combo_cuemonhaber_Datalistfixedvalues = cgiGet( "COMBO_CUEMONHABER_Datalistfixedvalues");
               Combo_cuemonhaber_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Isgriditem"));
               Combo_cuemonhaber_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Hasdescription"));
               Combo_cuemonhaber_Datalistproc = cgiGet( "COMBO_CUEMONHABER_Datalistproc");
               Combo_cuemonhaber_Datalistprocparametersprefix = cgiGet( "COMBO_CUEMONHABER_Datalistprocparametersprefix");
               Combo_cuemonhaber_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEMONHABER_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cuemonhaber_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Includeonlyselectedoption"));
               Combo_cuemonhaber_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Includeselectalloption"));
               Combo_cuemonhaber_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Emptyitem"));
               Combo_cuemonhaber_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUEMONHABER_Includeaddnewoption"));
               Combo_cuemonhaber_Htmltemplate = cgiGet( "COMBO_CUEMONHABER_Htmltemplate");
               Combo_cuemonhaber_Multiplevaluestype = cgiGet( "COMBO_CUEMONHABER_Multiplevaluestype");
               Combo_cuemonhaber_Loadingdata = cgiGet( "COMBO_CUEMONHABER_Loadingdata");
               Combo_cuemonhaber_Noresultsfound = cgiGet( "COMBO_CUEMONHABER_Noresultsfound");
               Combo_cuemonhaber_Emptyitemtext = cgiGet( "COMBO_CUEMONHABER_Emptyitemtext");
               Combo_cuemonhaber_Onlyselectedvalues = cgiGet( "COMBO_CUEMONHABER_Onlyselectedvalues");
               Combo_cuemonhaber_Selectalltext = cgiGet( "COMBO_CUEMONHABER_Selectalltext");
               Combo_cuemonhaber_Multiplevaluesseparator = cgiGet( "COMBO_CUEMONHABER_Multiplevaluesseparator");
               Combo_cuemonhaber_Addnewoptiontext = cgiGet( "COMBO_CUEMONHABER_Addnewoptiontext");
               Combo_cuemonhaber_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUEMONHABER_Gxcontroltype"), ".", ","));
               Combo_cuecierre_Objectcall = cgiGet( "COMBO_CUECIERRE_Objectcall");
               Combo_cuecierre_Class = cgiGet( "COMBO_CUECIERRE_Class");
               Combo_cuecierre_Icontype = cgiGet( "COMBO_CUECIERRE_Icontype");
               Combo_cuecierre_Icon = cgiGet( "COMBO_CUECIERRE_Icon");
               Combo_cuecierre_Caption = cgiGet( "COMBO_CUECIERRE_Caption");
               Combo_cuecierre_Tooltip = cgiGet( "COMBO_CUECIERRE_Tooltip");
               Combo_cuecierre_Cls = cgiGet( "COMBO_CUECIERRE_Cls");
               Combo_cuecierre_Selectedvalue_set = cgiGet( "COMBO_CUECIERRE_Selectedvalue_set");
               Combo_cuecierre_Selectedvalue_get = cgiGet( "COMBO_CUECIERRE_Selectedvalue_get");
               Combo_cuecierre_Selectedtext_set = cgiGet( "COMBO_CUECIERRE_Selectedtext_set");
               Combo_cuecierre_Selectedtext_get = cgiGet( "COMBO_CUECIERRE_Selectedtext_get");
               Combo_cuecierre_Gamoauthtoken = cgiGet( "COMBO_CUECIERRE_Gamoauthtoken");
               Combo_cuecierre_Ddointernalname = cgiGet( "COMBO_CUECIERRE_Ddointernalname");
               Combo_cuecierre_Titlecontrolalign = cgiGet( "COMBO_CUECIERRE_Titlecontrolalign");
               Combo_cuecierre_Dropdownoptionstype = cgiGet( "COMBO_CUECIERRE_Dropdownoptionstype");
               Combo_cuecierre_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Enabled"));
               Combo_cuecierre_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Visible"));
               Combo_cuecierre_Titlecontrolidtoreplace = cgiGet( "COMBO_CUECIERRE_Titlecontrolidtoreplace");
               Combo_cuecierre_Datalisttype = cgiGet( "COMBO_CUECIERRE_Datalisttype");
               Combo_cuecierre_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Allowmultipleselection"));
               Combo_cuecierre_Datalistfixedvalues = cgiGet( "COMBO_CUECIERRE_Datalistfixedvalues");
               Combo_cuecierre_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Isgriditem"));
               Combo_cuecierre_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Hasdescription"));
               Combo_cuecierre_Datalistproc = cgiGet( "COMBO_CUECIERRE_Datalistproc");
               Combo_cuecierre_Datalistprocparametersprefix = cgiGet( "COMBO_CUECIERRE_Datalistprocparametersprefix");
               Combo_cuecierre_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUECIERRE_Datalistupdateminimumcharacters"), ".", ","));
               Combo_cuecierre_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Includeonlyselectedoption"));
               Combo_cuecierre_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Includeselectalloption"));
               Combo_cuecierre_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Emptyitem"));
               Combo_cuecierre_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUECIERRE_Includeaddnewoption"));
               Combo_cuecierre_Htmltemplate = cgiGet( "COMBO_CUECIERRE_Htmltemplate");
               Combo_cuecierre_Multiplevaluestype = cgiGet( "COMBO_CUECIERRE_Multiplevaluestype");
               Combo_cuecierre_Loadingdata = cgiGet( "COMBO_CUECIERRE_Loadingdata");
               Combo_cuecierre_Noresultsfound = cgiGet( "COMBO_CUECIERRE_Noresultsfound");
               Combo_cuecierre_Emptyitemtext = cgiGet( "COMBO_CUECIERRE_Emptyitemtext");
               Combo_cuecierre_Onlyselectedvalues = cgiGet( "COMBO_CUECIERRE_Onlyselectedvalues");
               Combo_cuecierre_Selectalltext = cgiGet( "COMBO_CUECIERRE_Selectalltext");
               Combo_cuecierre_Multiplevaluesseparator = cgiGet( "COMBO_CUECIERRE_Multiplevaluesseparator");
               Combo_cuecierre_Addnewoptiontext = cgiGet( "COMBO_CUECIERRE_Addnewoptiontext");
               Combo_cuecierre_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CUECIERRE_Gxcontroltype"), ".", ","));
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
               A91CueCod = cgiGet( edtCueCod_Internalname);
               AssignAttri("", false, "A91CueCod", A91CueCod);
               cmbCueSts.CurrentValue = cgiGet( cmbCueSts_Internalname);
               A873CueSts = (short)(NumberUtil.Val( cgiGet( cmbCueSts_Internalname), "."));
               AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
               A860CueDsc = cgiGet( edtCueDsc_Internalname);
               AssignAttri("", false, "A860CueDsc", A860CueDsc);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPACOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A70TipACod = 0;
                  n70TipACod = false;
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               }
               else
               {
                  A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
                  n70TipACod = false;
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               }
               n70TipACod = ((0==A70TipACod) ? true : false);
               cmbCueBienes.CurrentValue = cgiGet( cmbCueBienes_Internalname);
               A2099CueBienes = (int)(NumberUtil.Val( cgiGet( cmbCueBienes_Internalname), "."));
               AssignAttri("", false, "A2099CueBienes", StringUtil.LTrimStr( (decimal)(A2099CueBienes), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEMOV");
                  AnyError = 1;
                  GX_FocusControl = edtCueMov_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A867CueMov = 0;
                  AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
               }
               else
               {
                  A867CueMov = (short)(context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ","));
                  AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEMON");
                  AnyError = 1;
                  GX_FocusControl = edtCueMon_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A864CueMon = 0;
                  AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
               }
               else
               {
                  A864CueMon = (short)(context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ","));
                  AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUECOS");
                  AnyError = 1;
                  GX_FocusControl = edtCueCos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A859CueCos = 0;
                  AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
               }
               else
               {
                  A859CueCos = (short)(context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ","));
                  AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
               }
               cmbCueRef4.CurrentValue = cgiGet( cmbCueRef4_Internalname);
               A871CueRef4 = (short)(NumberUtil.Val( cgiGet( cmbCueRef4_Internalname), "."));
               AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef1_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF1");
                  AnyError = 1;
                  GX_FocusControl = edtCueRef1_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A868CueRef1 = 0;
                  AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
               }
               else
               {
                  A868CueRef1 = (short)(context.localUtil.CToN( cgiGet( edtCueRef1_Internalname), ".", ","));
                  AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef2_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF2");
                  AnyError = 1;
                  GX_FocusControl = edtCueRef2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A869CueRef2 = 0;
                  AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
               }
               else
               {
                  A869CueRef2 = (short)(context.localUtil.CToN( cgiGet( edtCueRef2_Internalname), ".", ","));
                  AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef3_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef3_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF3");
                  AnyError = 1;
                  GX_FocusControl = edtCueRef3_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A870CueRef3 = 0;
                  AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
               }
               else
               {
                  A870CueRef3 = (short)(context.localUtil.CToN( cgiGet( edtCueRef3_Internalname), ".", ","));
                  AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef5_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef5_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF5");
                  AnyError = 1;
                  GX_FocusControl = edtCueRef5_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A872CueRef5 = 0;
                  AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
               }
               else
               {
                  A872CueRef5 = (short)(context.localUtil.CToN( cgiGet( edtCueRef5_Internalname), ".", ","));
                  AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
               }
               A109CueGasDebe = cgiGet( edtCueGasDebe_Internalname);
               n109CueGasDebe = false;
               AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
               A110CueGasHaber = cgiGet( edtCueGasHaber_Internalname);
               n110CueGasHaber = false;
               AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
               A111CueMonDebe = cgiGet( edtCueMonDebe_Internalname);
               n111CueMonDebe = false;
               AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
               A112CueMonHaber = cgiGet( edtCueMonHaber_Internalname);
               n112CueMonHaber = false;
               AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
               A113CueCierre = cgiGet( edtCueCierre_Internalname);
               n113CueCierre = false;
               AssignAttri("", false, "A113CueCierre", A113CueCierre);
               n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
               AV31ComboTipACod = (int)(context.localUtil.CToN( cgiGet( edtavCombotipacod_Internalname), ".", ","));
               AssignAttri("", false, "AV31ComboTipACod", StringUtil.LTrimStr( (decimal)(AV31ComboTipACod), 6, 0));
               AV23ComboCueGasDebe = cgiGet( edtavCombocuegasdebe_Internalname);
               AssignAttri("", false, "AV23ComboCueGasDebe", AV23ComboCueGasDebe);
               AV25ComboCueGasHaber = cgiGet( edtavCombocuegashaber_Internalname);
               AssignAttri("", false, "AV25ComboCueGasHaber", AV25ComboCueGasHaber);
               AV27ComboCueMonDebe = cgiGet( edtavCombocuemondebe_Internalname);
               AssignAttri("", false, "AV27ComboCueMonDebe", AV27ComboCueMonDebe);
               AV29ComboCueMonHaber = cgiGet( edtavCombocuemonhaber_Internalname);
               AssignAttri("", false, "AV29ComboCueMonHaber", AV29ComboCueMonHaber);
               AV33ComboCueCierre = cgiGet( edtavCombocuecierre_Internalname);
               AssignAttri("", false, "AV33ComboCueCierre", AV33ComboCueCierre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PlanCuentas");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("CueAbr", StringUtil.RTrim( context.localUtil.Format( A857CueAbr, "")));
               forbiddenHiddens.Add("CueGrupDoc", context.localUtil.Format( (decimal)(A863CueGrupDoc), "9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\plancuentas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A91CueCod = GetPar( "CueCod");
                  AssignAttri("", false, "A91CueCod", A91CueCod);
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
                     sMode64 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode64;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound64 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CUECOD");
                        AnyError = 1;
                        GX_FocusControl = edtCueCod_Internalname;
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
                           E116L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126L2 ();
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
            E126L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6L64( ) ;
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
            DisableAttributes6L64( ) ;
         }
         AssignProp("", false, edtavCombotipacod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipacod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocuegasdebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuegasdebe_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocuegashaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuegashaber_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocuemondebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuemondebe_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocuemonhaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuemonhaber_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocuecierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuecierre_Enabled), 5, 0), true);
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

      protected void CONFIRM_6L0( )
      {
         BeforeValidate6L64( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6L64( ) ;
            }
            else
            {
               CheckExtendedTable6L64( ) ;
               CloseExtendedTableCursors6L64( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6L0( )
      {
      }

      protected void E116L2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtCueCierre_Visible = 0;
         AssignProp("", false, edtCueCierre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueCierre_Visible), 5, 0), true);
         AV33ComboCueCierre = "";
         AssignAttri("", false, "AV33ComboCueCierre", AV33ComboCueCierre);
         edtavCombocuecierre_Visible = 0;
         AssignProp("", false, edtavCombocuecierre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuecierre_Visible), 5, 0), true);
         edtCueMonHaber_Visible = 0;
         AssignProp("", false, edtCueMonHaber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueMonHaber_Visible), 5, 0), true);
         AV29ComboCueMonHaber = "";
         AssignAttri("", false, "AV29ComboCueMonHaber", AV29ComboCueMonHaber);
         edtavCombocuemonhaber_Visible = 0;
         AssignProp("", false, edtavCombocuemonhaber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuemonhaber_Visible), 5, 0), true);
         edtCueMonDebe_Visible = 0;
         AssignProp("", false, edtCueMonDebe_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueMonDebe_Visible), 5, 0), true);
         AV27ComboCueMonDebe = "";
         AssignAttri("", false, "AV27ComboCueMonDebe", AV27ComboCueMonDebe);
         edtavCombocuemondebe_Visible = 0;
         AssignProp("", false, edtavCombocuemondebe_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuemondebe_Visible), 5, 0), true);
         edtCueGasHaber_Visible = 0;
         AssignProp("", false, edtCueGasHaber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueGasHaber_Visible), 5, 0), true);
         AV25ComboCueGasHaber = "";
         AssignAttri("", false, "AV25ComboCueGasHaber", AV25ComboCueGasHaber);
         edtavCombocuegashaber_Visible = 0;
         AssignProp("", false, edtavCombocuegashaber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuegashaber_Visible), 5, 0), true);
         edtCueGasDebe_Visible = 0;
         AssignProp("", false, edtCueGasDebe_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCueGasDebe_Visible), 5, 0), true);
         AV23ComboCueGasDebe = "";
         AssignAttri("", false, "AV23ComboCueGasDebe", AV23ComboCueGasDebe);
         edtavCombocuegasdebe_Visible = 0;
         AssignProp("", false, edtavCombocuegasdebe_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocuegasdebe_Visible), 5, 0), true);
         edtTipACod_Visible = 0;
         AssignProp("", false, edtTipACod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipACod_Visible), 5, 0), true);
         AV31ComboTipACod = 0;
         AssignAttri("", false, "AV31ComboTipACod", StringUtil.LTrimStr( (decimal)(AV31ComboTipACod), 6, 0));
         edtavCombotipacod_Visible = 0;
         AssignProp("", false, edtavCombotipacod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotipacod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPACOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCUEGASDEBE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCUEGASHABER' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCUEMONDEBE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCUEMONHABER' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCUECIERRE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV37Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV38GXV1 = 1;
            AssignAttri("", false, "AV38GXV1", StringUtil.LTrimStr( (decimal)(AV38GXV1), 8, 0));
            while ( AV38GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV38GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "CueGasDebe") == 0 )
               {
                  AV11Insert_CueGasDebe = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_CueGasDebe", AV11Insert_CueGasDebe);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CueGasDebe)) )
                  {
                     AV23ComboCueGasDebe = AV11Insert_CueGasDebe;
                     AssignAttri("", false, "AV23ComboCueGasDebe", AV23ComboCueGasDebe);
                     Combo_cuegasdebe_Selectedvalue_set = AV23ComboCueGasDebe;
                     ucCombo_cuegasdebe.SendProperty(context, "", false, Combo_cuegasdebe_Internalname, "SelectedValue_set", Combo_cuegasdebe_Selectedvalue_set);
                     Combo_cuegasdebe_Enabled = false;
                     ucCombo_cuegasdebe.SendProperty(context, "", false, Combo_cuegasdebe_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuegasdebe_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "CueGasHaber") == 0 )
               {
                  AV12Insert_CueGasHaber = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV12Insert_CueGasHaber", AV12Insert_CueGasHaber);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_CueGasHaber)) )
                  {
                     AV25ComboCueGasHaber = AV12Insert_CueGasHaber;
                     AssignAttri("", false, "AV25ComboCueGasHaber", AV25ComboCueGasHaber);
                     Combo_cuegashaber_Selectedvalue_set = AV25ComboCueGasHaber;
                     ucCombo_cuegashaber.SendProperty(context, "", false, Combo_cuegashaber_Internalname, "SelectedValue_set", Combo_cuegashaber_Selectedvalue_set);
                     Combo_cuegashaber_Enabled = false;
                     ucCombo_cuegashaber.SendProperty(context, "", false, Combo_cuegashaber_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuegashaber_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "CueMonDebe") == 0 )
               {
                  AV13Insert_CueMonDebe = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_CueMonDebe", AV13Insert_CueMonDebe);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CueMonDebe)) )
                  {
                     AV27ComboCueMonDebe = AV13Insert_CueMonDebe;
                     AssignAttri("", false, "AV27ComboCueMonDebe", AV27ComboCueMonDebe);
                     Combo_cuemondebe_Selectedvalue_set = AV27ComboCueMonDebe;
                     ucCombo_cuemondebe.SendProperty(context, "", false, Combo_cuemondebe_Internalname, "SelectedValue_set", Combo_cuemondebe_Selectedvalue_set);
                     Combo_cuemondebe_Enabled = false;
                     ucCombo_cuemondebe.SendProperty(context, "", false, Combo_cuemondebe_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuemondebe_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "CueMonHaber") == 0 )
               {
                  AV14Insert_CueMonHaber = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV14Insert_CueMonHaber", AV14Insert_CueMonHaber);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_CueMonHaber)) )
                  {
                     AV29ComboCueMonHaber = AV14Insert_CueMonHaber;
                     AssignAttri("", false, "AV29ComboCueMonHaber", AV29ComboCueMonHaber);
                     Combo_cuemonhaber_Selectedvalue_set = AV29ComboCueMonHaber;
                     ucCombo_cuemonhaber.SendProperty(context, "", false, Combo_cuemonhaber_Internalname, "SelectedValue_set", Combo_cuemonhaber_Selectedvalue_set);
                     Combo_cuemonhaber_Enabled = false;
                     ucCombo_cuemonhaber.SendProperty(context, "", false, Combo_cuemonhaber_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuemonhaber_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "TipACod") == 0 )
               {
                  AV15Insert_TipACod = (int)(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV15Insert_TipACod", StringUtil.LTrimStr( (decimal)(AV15Insert_TipACod), 6, 0));
                  if ( ! (0==AV15Insert_TipACod) )
                  {
                     AV31ComboTipACod = AV15Insert_TipACod;
                     AssignAttri("", false, "AV31ComboTipACod", StringUtil.LTrimStr( (decimal)(AV31ComboTipACod), 6, 0));
                     Combo_tipacod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV31ComboTipACod), 6, 0));
                     ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "SelectedValue_set", Combo_tipacod_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "TipACod",  "GET",  false,  AV7CueCod,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_tipacod_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "SelectedText_set", Combo_tipacod_Selectedtext_set);
                     Combo_tipacod_Enabled = false;
                     ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipacod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "CueCierre") == 0 )
               {
                  AV16Insert_CueCierre = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV16Insert_CueCierre", AV16Insert_CueCierre);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_CueCierre)) )
                  {
                     AV33ComboCueCierre = AV16Insert_CueCierre;
                     AssignAttri("", false, "AV33ComboCueCierre", AV33ComboCueCierre);
                     Combo_cuecierre_Selectedvalue_set = AV33ComboCueCierre;
                     ucCombo_cuecierre.SendProperty(context, "", false, Combo_cuecierre_Internalname, "SelectedValue_set", Combo_cuecierre_Selectedvalue_set);
                     Combo_cuecierre_Enabled = false;
                     ucCombo_cuecierre.SendProperty(context, "", false, Combo_cuecierre_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuecierre_Enabled));
                  }
               }
               AV38GXV1 = (int)(AV38GXV1+1);
               AssignAttri("", false, "AV38GXV1", StringUtil.LTrimStr( (decimal)(AV38GXV1), 8, 0));
            }
         }
      }

      protected void E126L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV34SGAuDocGls = "Plan de Cuenta N° " + StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
            AV35Codigo = StringUtil.Trim( A91CueCod);
            GXt_char2 = "CON";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV34SGAuDocGls, ref  AV35Codigo, ref  AV35Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.plancuentasww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S162( )
      {
         /* 'LOADCOMBOCUECIERRE' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "CueCierre",  Gx_mode,  false,  AV7CueCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV32CueCierre_Data.FromJSonString(AV22Combo_DataJson, null);
         Combo_cuecierre_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_cuecierre.SendProperty(context, "", false, Combo_cuecierre_Internalname, "SelectedValue_set", Combo_cuecierre_Selectedvalue_set);
         AV33ComboCueCierre = AV20ComboSelectedValue;
         AssignAttri("", false, "AV33ComboCueCierre", AV33ComboCueCierre);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuecierre_Enabled = false;
            ucCombo_cuecierre.SendProperty(context, "", false, Combo_cuecierre_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuecierre_Enabled));
         }
      }

      protected void S152( )
      {
         /* 'LOADCOMBOCUEMONHABER' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "CueMonHaber",  Gx_mode,  false,  AV7CueCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV28CueMonHaber_Data.FromJSonString(AV22Combo_DataJson, null);
         Combo_cuemonhaber_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_cuemonhaber.SendProperty(context, "", false, Combo_cuemonhaber_Internalname, "SelectedValue_set", Combo_cuemonhaber_Selectedvalue_set);
         AV29ComboCueMonHaber = AV20ComboSelectedValue;
         AssignAttri("", false, "AV29ComboCueMonHaber", AV29ComboCueMonHaber);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuemonhaber_Enabled = false;
            ucCombo_cuemonhaber.SendProperty(context, "", false, Combo_cuemonhaber_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuemonhaber_Enabled));
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCUEMONDEBE' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "CueMonDebe",  Gx_mode,  false,  AV7CueCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV26CueMonDebe_Data.FromJSonString(AV22Combo_DataJson, null);
         Combo_cuemondebe_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_cuemondebe.SendProperty(context, "", false, Combo_cuemondebe_Internalname, "SelectedValue_set", Combo_cuemondebe_Selectedvalue_set);
         AV27ComboCueMonDebe = AV20ComboSelectedValue;
         AssignAttri("", false, "AV27ComboCueMonDebe", AV27ComboCueMonDebe);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuemondebe_Enabled = false;
            ucCombo_cuemondebe.SendProperty(context, "", false, Combo_cuemondebe_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuemondebe_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCUEGASHABER' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "CueGasHaber",  Gx_mode,  false,  AV7CueCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV24CueGasHaber_Data.FromJSonString(AV22Combo_DataJson, null);
         Combo_cuegashaber_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_cuegashaber.SendProperty(context, "", false, Combo_cuegashaber_Internalname, "SelectedValue_set", Combo_cuegashaber_Selectedvalue_set);
         AV25ComboCueGasHaber = AV20ComboSelectedValue;
         AssignAttri("", false, "AV25ComboCueGasHaber", AV25ComboCueGasHaber);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuegashaber_Enabled = false;
            ucCombo_cuegashaber.SendProperty(context, "", false, Combo_cuegashaber_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuegashaber_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCUEGASDEBE' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "CueGasDebe",  Gx_mode,  false,  AV7CueCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         AV18CueGasDebe_Data.FromJSonString(AV22Combo_DataJson, null);
         Combo_cuegasdebe_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_cuegasdebe.SendProperty(context, "", false, Combo_cuegasdebe_Internalname, "SelectedValue_set", Combo_cuegasdebe_Selectedvalue_set);
         AV23ComboCueGasDebe = AV20ComboSelectedValue;
         AssignAttri("", false, "AV23ComboCueGasDebe", AV23ComboCueGasDebe);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cuegasdebe_Enabled = false;
            ucCombo_cuegasdebe.SendProperty(context, "", false, Combo_cuegasdebe_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cuegasdebe_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIPACOD' Routine */
         returnInSub = false;
         GXt_char4 = AV22Combo_DataJson;
         new GeneXus.Programs.contabilidad.plancuentasloaddvcombo(context ).execute(  "TipACod",  Gx_mode,  false,  AV7CueCod,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char4) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char4;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_tipacod_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "SelectedValue_set", Combo_tipacod_Selectedvalue_set);
         Combo_tipacod_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "SelectedText_set", Combo_tipacod_Selectedtext_set);
         AV31ComboTipACod = (int)(NumberUtil.Val( AV20ComboSelectedValue, "."));
         AssignAttri("", false, "AV31ComboTipACod", StringUtil.LTrimStr( (decimal)(AV31ComboTipACod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tipacod_Enabled = false;
            ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipacod_Enabled));
         }
      }

      protected void ZM6L64( short GX_JID )
      {
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z860CueDsc = T006L3_A860CueDsc[0];
               Z857CueAbr = T006L3_A857CueAbr[0];
               Z867CueMov = T006L3_A867CueMov[0];
               Z864CueMon = T006L3_A864CueMon[0];
               Z859CueCos = T006L3_A859CueCos[0];
               Z873CueSts = T006L3_A873CueSts[0];
               Z868CueRef1 = T006L3_A868CueRef1[0];
               Z869CueRef2 = T006L3_A869CueRef2[0];
               Z870CueRef3 = T006L3_A870CueRef3[0];
               Z871CueRef4 = T006L3_A871CueRef4[0];
               Z2099CueBienes = T006L3_A2099CueBienes[0];
               Z872CueRef5 = T006L3_A872CueRef5[0];
               Z863CueGrupDoc = T006L3_A863CueGrupDoc[0];
               Z70TipACod = T006L3_A70TipACod[0];
               Z109CueGasDebe = T006L3_A109CueGasDebe[0];
               Z110CueGasHaber = T006L3_A110CueGasHaber[0];
               Z111CueMonDebe = T006L3_A111CueMonDebe[0];
               Z112CueMonHaber = T006L3_A112CueMonHaber[0];
               Z113CueCierre = T006L3_A113CueCierre[0];
            }
            else
            {
               Z860CueDsc = A860CueDsc;
               Z857CueAbr = A857CueAbr;
               Z867CueMov = A867CueMov;
               Z864CueMon = A864CueMon;
               Z859CueCos = A859CueCos;
               Z873CueSts = A873CueSts;
               Z868CueRef1 = A868CueRef1;
               Z869CueRef2 = A869CueRef2;
               Z870CueRef3 = A870CueRef3;
               Z871CueRef4 = A871CueRef4;
               Z2099CueBienes = A2099CueBienes;
               Z872CueRef5 = A872CueRef5;
               Z863CueGrupDoc = A863CueGrupDoc;
               Z70TipACod = A70TipACod;
               Z109CueGasDebe = A109CueGasDebe;
               Z110CueGasHaber = A110CueGasHaber;
               Z111CueMonDebe = A111CueMonDebe;
               Z112CueMonHaber = A112CueMonHaber;
               Z113CueCierre = A113CueCierre;
            }
         }
         if ( GX_JID == -28 )
         {
            Z91CueCod = A91CueCod;
            Z860CueDsc = A860CueDsc;
            Z857CueAbr = A857CueAbr;
            Z867CueMov = A867CueMov;
            Z864CueMon = A864CueMon;
            Z859CueCos = A859CueCos;
            Z873CueSts = A873CueSts;
            Z868CueRef1 = A868CueRef1;
            Z869CueRef2 = A869CueRef2;
            Z870CueRef3 = A870CueRef3;
            Z871CueRef4 = A871CueRef4;
            Z2099CueBienes = A2099CueBienes;
            Z872CueRef5 = A872CueRef5;
            Z863CueGrupDoc = A863CueGrupDoc;
            Z70TipACod = A70TipACod;
            Z109CueGasDebe = A109CueGasDebe;
            Z110CueGasHaber = A110CueGasHaber;
            Z111CueMonDebe = A111CueMonDebe;
            Z112CueMonHaber = A112CueMonHaber;
            Z113CueCierre = A113CueCierre;
            Z858CueCierreDsc = A858CueCierreDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV37Pgmname = "Contabilidad.PlanCuentas";
         AssignAttri("", false, "AV37Pgmname", AV37Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CueCod)) )
         {
            A91CueCod = AV7CueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CueCod)) )
         {
            edtCueCod_Enabled = 0;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCueCod_Enabled = 1;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CueCod)) )
         {
            edtCueCod_Enabled = 0;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CueGasDebe)) )
         {
            edtCueGasDebe_Enabled = 0;
            AssignProp("", false, edtCueGasDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasDebe_Enabled), 5, 0), true);
         }
         else
         {
            edtCueGasDebe_Enabled = 1;
            AssignProp("", false, edtCueGasDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasDebe_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_CueGasHaber)) )
         {
            edtCueGasHaber_Enabled = 0;
            AssignProp("", false, edtCueGasHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasHaber_Enabled), 5, 0), true);
         }
         else
         {
            edtCueGasHaber_Enabled = 1;
            AssignProp("", false, edtCueGasHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasHaber_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CueMonDebe)) )
         {
            edtCueMonDebe_Enabled = 0;
            AssignProp("", false, edtCueMonDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonDebe_Enabled), 5, 0), true);
         }
         else
         {
            edtCueMonDebe_Enabled = 1;
            AssignProp("", false, edtCueMonDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonDebe_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_CueMonHaber)) )
         {
            edtCueMonHaber_Enabled = 0;
            AssignProp("", false, edtCueMonHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonHaber_Enabled), 5, 0), true);
         }
         else
         {
            edtCueMonHaber_Enabled = 1;
            AssignProp("", false, edtCueMonHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonHaber_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_TipACod) )
         {
            edtTipACod_Enabled = 0;
            AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipACod_Enabled = 1;
            AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_CueCierre)) )
         {
            edtCueCierre_Enabled = 0;
            AssignProp("", false, edtCueCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCierre_Enabled), 5, 0), true);
         }
         else
         {
            edtCueCierre_Enabled = 1;
            AssignProp("", false, edtCueCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCierre_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_TipACod) )
         {
            A70TipACod = AV15Insert_TipACod;
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         }
         else
         {
            if ( (0==AV31ComboTipACod) )
            {
               A70TipACod = 0;
               n70TipACod = false;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               n70TipACod = true;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            }
            else
            {
               if ( ! (0==AV31ComboTipACod) )
               {
                  A70TipACod = AV31ComboTipACod;
                  n70TipACod = false;
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_CueGasDebe)) )
         {
            A109CueGasDebe = AV11Insert_CueGasDebe;
            n109CueGasDebe = false;
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboCueGasDebe)) )
            {
               A109CueGasDebe = "";
               n109CueGasDebe = false;
               AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
               n109CueGasDebe = true;
               AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboCueGasDebe)) )
               {
                  A109CueGasDebe = AV23ComboCueGasDebe;
                  n109CueGasDebe = false;
                  AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_CueGasHaber)) )
         {
            A110CueGasHaber = AV12Insert_CueGasHaber;
            n110CueGasHaber = false;
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComboCueGasHaber)) )
            {
               A110CueGasHaber = "";
               n110CueGasHaber = false;
               AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
               n110CueGasHaber = true;
               AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ComboCueGasHaber)) )
               {
                  A110CueGasHaber = AV25ComboCueGasHaber;
                  n110CueGasHaber = false;
                  AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CueMonDebe)) )
         {
            A111CueMonDebe = AV13Insert_CueMonDebe;
            n111CueMonDebe = false;
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ComboCueMonDebe)) )
            {
               A111CueMonDebe = "";
               n111CueMonDebe = false;
               AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
               n111CueMonDebe = true;
               AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ComboCueMonDebe)) )
               {
                  A111CueMonDebe = AV27ComboCueMonDebe;
                  n111CueMonDebe = false;
                  AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Insert_CueMonHaber)) )
         {
            A112CueMonHaber = AV14Insert_CueMonHaber;
            n112CueMonHaber = false;
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29ComboCueMonHaber)) )
            {
               A112CueMonHaber = "";
               n112CueMonHaber = false;
               AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
               n112CueMonHaber = true;
               AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ComboCueMonHaber)) )
               {
                  A112CueMonHaber = AV29ComboCueMonHaber;
                  n112CueMonHaber = false;
                  AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_CueCierre)) )
         {
            A113CueCierre = AV16Insert_CueCierre;
            n113CueCierre = false;
            AssignAttri("", false, "A113CueCierre", A113CueCierre);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ComboCueCierre)) )
            {
               A113CueCierre = "";
               n113CueCierre = false;
               AssignAttri("", false, "A113CueCierre", A113CueCierre);
               n113CueCierre = true;
               AssignAttri("", false, "A113CueCierre", A113CueCierre);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ComboCueCierre)) )
               {
                  A113CueCierre = AV33ComboCueCierre;
                  n113CueCierre = false;
                  AssignAttri("", false, "A113CueCierre", A113CueCierre);
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
         if ( IsIns( )  && (0==A873CueSts) && ( Gx_BScreen == 0 ) )
         {
            A873CueSts = 1;
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T006L9 */
            pr_default.execute(7, new Object[] {n113CueCierre, A113CueCierre});
            A858CueCierreDsc = T006L9_A858CueCierreDsc[0];
            pr_default.close(7);
         }
      }

      protected void Load6L64( )
      {
         /* Using cursor T006L10 */
         pr_default.execute(8, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound64 = 1;
            A860CueDsc = T006L10_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A857CueAbr = T006L10_A857CueAbr[0];
            n857CueAbr = T006L10_n857CueAbr[0];
            A867CueMov = T006L10_A867CueMov[0];
            AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
            A864CueMon = T006L10_A864CueMon[0];
            AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
            A859CueCos = T006L10_A859CueCos[0];
            AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
            A873CueSts = T006L10_A873CueSts[0];
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            A868CueRef1 = T006L10_A868CueRef1[0];
            AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
            A869CueRef2 = T006L10_A869CueRef2[0];
            AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
            A870CueRef3 = T006L10_A870CueRef3[0];
            AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
            A871CueRef4 = T006L10_A871CueRef4[0];
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            A2099CueBienes = T006L10_A2099CueBienes[0];
            AssignAttri("", false, "A2099CueBienes", StringUtil.LTrimStr( (decimal)(A2099CueBienes), 6, 0));
            A872CueRef5 = T006L10_A872CueRef5[0];
            AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
            A863CueGrupDoc = T006L10_A863CueGrupDoc[0];
            A858CueCierreDsc = T006L10_A858CueCierreDsc[0];
            A70TipACod = T006L10_A70TipACod[0];
            n70TipACod = T006L10_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A109CueGasDebe = T006L10_A109CueGasDebe[0];
            n109CueGasDebe = T006L10_n109CueGasDebe[0];
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            A110CueGasHaber = T006L10_A110CueGasHaber[0];
            n110CueGasHaber = T006L10_n110CueGasHaber[0];
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            A111CueMonDebe = T006L10_A111CueMonDebe[0];
            n111CueMonDebe = T006L10_n111CueMonDebe[0];
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            A112CueMonHaber = T006L10_A112CueMonHaber[0];
            n112CueMonHaber = T006L10_n112CueMonHaber[0];
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            A113CueCierre = T006L10_A113CueCierre[0];
            n113CueCierre = T006L10_n113CueCierre[0];
            AssignAttri("", false, "A113CueCierre", A113CueCierre);
            ZM6L64( -28) ;
         }
         pr_default.close(8);
         OnLoadActions6L64( ) ;
      }

      protected void OnLoadActions6L64( )
      {
         A2098CueDscCompleto = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
         AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
      }

      protected void CheckExtendedTable6L64( )
      {
         nIsDirty_64 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_64 = 1;
         A2098CueDscCompleto = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
         AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cuenta", "", "", "", "", "", "", "", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A860CueDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripción de Cuenta", "", "", "", "", "", "", "", ""), 1, "CUEDSC");
            AnyError = 1;
            GX_FocusControl = edtCueDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006L5 */
         pr_default.execute(3, new Object[] {n109CueGasDebe, A109CueGasDebe});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueGasDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T006L6 */
         pr_default.execute(4, new Object[] {n110CueGasHaber, A110CueGasHaber});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASHABER");
               AnyError = 1;
               GX_FocusControl = edtCueGasHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T006L7 */
         pr_default.execute(5, new Object[] {n111CueMonDebe, A111CueMonDebe});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A111CueMonDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueMonDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T006L8 */
         pr_default.execute(6, new Object[] {n112CueMonHaber, A112CueMonHaber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112CueMonHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONHABER");
               AnyError = 1;
               GX_FocusControl = edtCueMonHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T006L4 */
         pr_default.execute(2, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T006L9 */
         pr_default.execute(7, new Object[] {n113CueCierre, A113CueCierre});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Cierre'.", "ForeignKeyNotFound", 1, "CUECIERRE");
               AnyError = 1;
               GX_FocusControl = edtCueCierre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A858CueCierreDsc = T006L9_A858CueCierreDsc[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors6L64( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_30( string A109CueGasDebe )
      {
         /* Using cursor T006L11 */
         pr_default.execute(9, new Object[] {n109CueGasDebe, A109CueGasDebe});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueGasDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_31( string A110CueGasHaber )
      {
         /* Using cursor T006L12 */
         pr_default.execute(10, new Object[] {n110CueGasHaber, A110CueGasHaber});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASHABER");
               AnyError = 1;
               GX_FocusControl = edtCueGasHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_32( string A111CueMonDebe )
      {
         /* Using cursor T006L13 */
         pr_default.execute(11, new Object[] {n111CueMonDebe, A111CueMonDebe});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A111CueMonDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueMonDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_33( string A112CueMonHaber )
      {
         /* Using cursor T006L14 */
         pr_default.execute(12, new Object[] {n112CueMonHaber, A112CueMonHaber});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112CueMonHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONHABER");
               AnyError = 1;
               GX_FocusControl = edtCueMonHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_29( int A70TipACod )
      {
         /* Using cursor T006L15 */
         pr_default.execute(13, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
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

      protected void gxLoad_34( string A113CueCierre )
      {
         /* Using cursor T006L16 */
         pr_default.execute(14, new Object[] {n113CueCierre, A113CueCierre});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Cierre'.", "ForeignKeyNotFound", 1, "CUECIERRE");
               AnyError = 1;
               GX_FocusControl = edtCueCierre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A858CueCierreDsc = T006L16_A858CueCierreDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A858CueCierreDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey6L64( )
      {
         /* Using cursor T006L17 */
         pr_default.execute(15, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound64 = 1;
         }
         else
         {
            RcdFound64 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006L3 */
         pr_default.execute(1, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6L64( 28) ;
            RcdFound64 = 1;
            A91CueCod = T006L3_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A860CueDsc = T006L3_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A857CueAbr = T006L3_A857CueAbr[0];
            n857CueAbr = T006L3_n857CueAbr[0];
            A867CueMov = T006L3_A867CueMov[0];
            AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
            A864CueMon = T006L3_A864CueMon[0];
            AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
            A859CueCos = T006L3_A859CueCos[0];
            AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
            A873CueSts = T006L3_A873CueSts[0];
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            A868CueRef1 = T006L3_A868CueRef1[0];
            AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
            A869CueRef2 = T006L3_A869CueRef2[0];
            AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
            A870CueRef3 = T006L3_A870CueRef3[0];
            AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
            A871CueRef4 = T006L3_A871CueRef4[0];
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            A2099CueBienes = T006L3_A2099CueBienes[0];
            AssignAttri("", false, "A2099CueBienes", StringUtil.LTrimStr( (decimal)(A2099CueBienes), 6, 0));
            A872CueRef5 = T006L3_A872CueRef5[0];
            AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
            A863CueGrupDoc = T006L3_A863CueGrupDoc[0];
            A70TipACod = T006L3_A70TipACod[0];
            n70TipACod = T006L3_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A109CueGasDebe = T006L3_A109CueGasDebe[0];
            n109CueGasDebe = T006L3_n109CueGasDebe[0];
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            A110CueGasHaber = T006L3_A110CueGasHaber[0];
            n110CueGasHaber = T006L3_n110CueGasHaber[0];
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            A111CueMonDebe = T006L3_A111CueMonDebe[0];
            n111CueMonDebe = T006L3_n111CueMonDebe[0];
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            A112CueMonHaber = T006L3_A112CueMonHaber[0];
            n112CueMonHaber = T006L3_n112CueMonHaber[0];
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            A113CueCierre = T006L3_A113CueCierre[0];
            n113CueCierre = T006L3_n113CueCierre[0];
            AssignAttri("", false, "A113CueCierre", A113CueCierre);
            Z91CueCod = A91CueCod;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6L64( ) ;
            if ( AnyError == 1 )
            {
               RcdFound64 = 0;
               InitializeNonKey6L64( ) ;
            }
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound64 = 0;
            InitializeNonKey6L64( ) ;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6L64( ) ;
         if ( RcdFound64 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound64 = 0;
         /* Using cursor T006L18 */
         pr_default.execute(16, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T006L18_A91CueCod[0], A91CueCod) < 0 ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T006L18_A91CueCod[0], A91CueCod) > 0 ) ) )
            {
               A91CueCod = T006L18_A91CueCod[0];
               AssignAttri("", false, "A91CueCod", A91CueCod);
               RcdFound64 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound64 = 0;
         /* Using cursor T006L19 */
         pr_default.execute(17, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( StringUtil.StrCmp(T006L19_A91CueCod[0], A91CueCod) > 0 ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( StringUtil.StrCmp(T006L19_A91CueCod[0], A91CueCod) < 0 ) ) )
            {
               A91CueCod = T006L19_A91CueCod[0];
               AssignAttri("", false, "A91CueCod", A91CueCod);
               RcdFound64 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6L64( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6L64( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound64 == 1 )
            {
               if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
               {
                  A91CueCod = Z91CueCod;
                  AssignAttri("", false, "A91CueCod", A91CueCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CUECOD");
                  AnyError = 1;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6L64( ) ;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6L64( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUECOD");
                     AnyError = 1;
                     GX_FocusControl = edtCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6L64( ) ;
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
         if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
         {
            A91CueCod = Z91CueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6L64( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006L2 */
            pr_default.execute(0, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPLANCUENTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z860CueDsc, T006L2_A860CueDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z857CueAbr, T006L2_A857CueAbr[0]) != 0 ) || ( Z867CueMov != T006L2_A867CueMov[0] ) || ( Z864CueMon != T006L2_A864CueMon[0] ) || ( Z859CueCos != T006L2_A859CueCos[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z873CueSts != T006L2_A873CueSts[0] ) || ( Z868CueRef1 != T006L2_A868CueRef1[0] ) || ( Z869CueRef2 != T006L2_A869CueRef2[0] ) || ( Z870CueRef3 != T006L2_A870CueRef3[0] ) || ( Z871CueRef4 != T006L2_A871CueRef4[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2099CueBienes != T006L2_A2099CueBienes[0] ) || ( Z872CueRef5 != T006L2_A872CueRef5[0] ) || ( Z863CueGrupDoc != T006L2_A863CueGrupDoc[0] ) || ( Z70TipACod != T006L2_A70TipACod[0] ) || ( StringUtil.StrCmp(Z109CueGasDebe, T006L2_A109CueGasDebe[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z110CueGasHaber, T006L2_A110CueGasHaber[0]) != 0 ) || ( StringUtil.StrCmp(Z111CueMonDebe, T006L2_A111CueMonDebe[0]) != 0 ) || ( StringUtil.StrCmp(Z112CueMonHaber, T006L2_A112CueMonHaber[0]) != 0 ) || ( StringUtil.StrCmp(Z113CueCierre, T006L2_A113CueCierre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z860CueDsc, T006L2_A860CueDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueDsc");
                  GXUtil.WriteLogRaw("Old: ",Z860CueDsc);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A860CueDsc[0]);
               }
               if ( StringUtil.StrCmp(Z857CueAbr, T006L2_A857CueAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueAbr");
                  GXUtil.WriteLogRaw("Old: ",Z857CueAbr);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A857CueAbr[0]);
               }
               if ( Z867CueMov != T006L2_A867CueMov[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueMov");
                  GXUtil.WriteLogRaw("Old: ",Z867CueMov);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A867CueMov[0]);
               }
               if ( Z864CueMon != T006L2_A864CueMon[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueMon");
                  GXUtil.WriteLogRaw("Old: ",Z864CueMon);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A864CueMon[0]);
               }
               if ( Z859CueCos != T006L2_A859CueCos[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueCos");
                  GXUtil.WriteLogRaw("Old: ",Z859CueCos);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A859CueCos[0]);
               }
               if ( Z873CueSts != T006L2_A873CueSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueSts");
                  GXUtil.WriteLogRaw("Old: ",Z873CueSts);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A873CueSts[0]);
               }
               if ( Z868CueRef1 != T006L2_A868CueRef1[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueRef1");
                  GXUtil.WriteLogRaw("Old: ",Z868CueRef1);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A868CueRef1[0]);
               }
               if ( Z869CueRef2 != T006L2_A869CueRef2[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueRef2");
                  GXUtil.WriteLogRaw("Old: ",Z869CueRef2);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A869CueRef2[0]);
               }
               if ( Z870CueRef3 != T006L2_A870CueRef3[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueRef3");
                  GXUtil.WriteLogRaw("Old: ",Z870CueRef3);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A870CueRef3[0]);
               }
               if ( Z871CueRef4 != T006L2_A871CueRef4[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueRef4");
                  GXUtil.WriteLogRaw("Old: ",Z871CueRef4);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A871CueRef4[0]);
               }
               if ( Z2099CueBienes != T006L2_A2099CueBienes[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueBienes");
                  GXUtil.WriteLogRaw("Old: ",Z2099CueBienes);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A2099CueBienes[0]);
               }
               if ( Z872CueRef5 != T006L2_A872CueRef5[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueRef5");
                  GXUtil.WriteLogRaw("Old: ",Z872CueRef5);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A872CueRef5[0]);
               }
               if ( Z863CueGrupDoc != T006L2_A863CueGrupDoc[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueGrupDoc");
                  GXUtil.WriteLogRaw("Old: ",Z863CueGrupDoc);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A863CueGrupDoc[0]);
               }
               if ( Z70TipACod != T006L2_A70TipACod[0] )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"TipACod");
                  GXUtil.WriteLogRaw("Old: ",Z70TipACod);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A70TipACod[0]);
               }
               if ( StringUtil.StrCmp(Z109CueGasDebe, T006L2_A109CueGasDebe[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueGasDebe");
                  GXUtil.WriteLogRaw("Old: ",Z109CueGasDebe);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A109CueGasDebe[0]);
               }
               if ( StringUtil.StrCmp(Z110CueGasHaber, T006L2_A110CueGasHaber[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueGasHaber");
                  GXUtil.WriteLogRaw("Old: ",Z110CueGasHaber);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A110CueGasHaber[0]);
               }
               if ( StringUtil.StrCmp(Z111CueMonDebe, T006L2_A111CueMonDebe[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueMonDebe");
                  GXUtil.WriteLogRaw("Old: ",Z111CueMonDebe);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A111CueMonDebe[0]);
               }
               if ( StringUtil.StrCmp(Z112CueMonHaber, T006L2_A112CueMonHaber[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueMonHaber");
                  GXUtil.WriteLogRaw("Old: ",Z112CueMonHaber);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A112CueMonHaber[0]);
               }
               if ( StringUtil.StrCmp(Z113CueCierre, T006L2_A113CueCierre[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.plancuentas:[seudo value changed for attri]"+"CueCierre");
                  GXUtil.WriteLogRaw("Old: ",Z113CueCierre);
                  GXUtil.WriteLogRaw("Current: ",T006L2_A113CueCierre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPLANCUENTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6L64( )
      {
         BeforeValidate6L64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6L64( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6L64( 0) ;
            CheckOptimisticConcurrency6L64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6L64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6L64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006L20 */
                     pr_default.execute(18, new Object[] {A91CueCod, A860CueDsc, n857CueAbr, A857CueAbr, A867CueMov, A864CueMon, A859CueCos, A873CueSts, A868CueRef1, A869CueRef2, A870CueRef3, A871CueRef4, A2099CueBienes, A872CueRef5, A863CueGrupDoc, n70TipACod, A70TipACod, n109CueGasDebe, A109CueGasDebe, n110CueGasHaber, A110CueGasHaber, n111CueMonDebe, A111CueMonDebe, n112CueMonHaber, A112CueMonHaber, n113CueCierre, A113CueCierre});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPLANCUENTA");
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption6L0( ) ;
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
               Load6L64( ) ;
            }
            EndLevel6L64( ) ;
         }
         CloseExtendedTableCursors6L64( ) ;
      }

      protected void Update6L64( )
      {
         BeforeValidate6L64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6L64( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6L64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6L64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6L64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006L21 */
                     pr_default.execute(19, new Object[] {A860CueDsc, n857CueAbr, A857CueAbr, A867CueMov, A864CueMon, A859CueCos, A873CueSts, A868CueRef1, A869CueRef2, A870CueRef3, A871CueRef4, A2099CueBienes, A872CueRef5, A863CueGrupDoc, n70TipACod, A70TipACod, n109CueGasDebe, A109CueGasDebe, n110CueGasHaber, A110CueGasHaber, n111CueMonDebe, A111CueMonDebe, n112CueMonHaber, A112CueMonHaber, n113CueCierre, A113CueCierre, A91CueCod});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPLANCUENTA");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPLANCUENTA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6L64( ) ;
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
            EndLevel6L64( ) ;
         }
         CloseExtendedTableCursors6L64( ) ;
      }

      protected void DeferredUpdate6L64( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6L64( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6L64( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6L64( ) ;
            AfterConfirm6L64( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6L64( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006L22 */
                  pr_default.execute(20, new Object[] {A91CueCod});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPLANCUENTA");
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
         sMode64 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6L64( ) ;
         Gx_mode = sMode64;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6L64( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A2098CueDscCompleto = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
            AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
            /* Using cursor T006L23 */
            pr_default.execute(21, new Object[] {n113CueCierre, A113CueCierre});
            A858CueCierreDsc = T006L23_A858CueCierreDsc[0];
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T006L24 */
            pr_default.execute(22, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T006L25 */
            pr_default.execute(23, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T006L26 */
            pr_default.execute(24, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T006L27 */
            pr_default.execute(25, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T006L28 */
            pr_default.execute(26, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T006L29 */
            pr_default.execute(27, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T006L30 */
            pr_default.execute(28, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T006L31 */
            pr_default.execute(29, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuentas de Banco"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T006L32 */
            pr_default.execute(30, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Concepto de Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T006L33 */
            pr_default.execute(31, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Conceptos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T006L34 */
            pr_default.execute(32, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCONCEPTOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T006L35 */
            pr_default.execute(33, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T006L36 */
            pr_default.execute(34, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldos Mensuales Contables"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T006L37 */
            pr_default.execute(35, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T006L38 */
            pr_default.execute(36, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T006L39 */
            pr_default.execute(37, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T006L40 */
            pr_default.execute(38, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T006L41 */
            pr_default.execute(39, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T006L42 */
            pr_default.execute(40, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T006L43 */
            pr_default.execute(41, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T006L44 */
            pr_default.execute(42, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T006L45 */
            pr_default.execute(43, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T006L46 */
            pr_default.execute(44, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T006L47 */
            pr_default.execute(45, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T006L48 */
            pr_default.execute(46, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T006L49 */
            pr_default.execute(47, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T006L50 */
            pr_default.execute(48, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conceptos de Planilla"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor T006L51 */
            pr_default.execute(49, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entregas a rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor T006L52 */
            pr_default.execute(50, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Concepto de entregas a rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor T006L53 */
            pr_default.execute(51, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Concepto Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor T006L54 */
            pr_default.execute(52, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor T006L55 */
            pr_default.execute(53, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agentes de Aduana"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor T006L56 */
            pr_default.execute(54, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
            /* Using cursor T006L57 */
            pr_default.execute(55, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(55) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lineas Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(55);
            /* Using cursor T006L58 */
            pr_default.execute(56, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(56) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta 4"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(56);
            /* Using cursor T006L59 */
            pr_default.execute(57, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(57) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta 3"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(57);
            /* Using cursor T006L60 */
            pr_default.execute(58, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(58) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta Haber"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(58);
            /* Using cursor T006L61 */
            pr_default.execute(59, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(59) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta Debe"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(59);
            /* Using cursor T006L62 */
            pr_default.execute(60, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(60) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Centro de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(60);
            /* Using cursor T006L63 */
            pr_default.execute(61, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(61) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conceptos de Compras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(61);
            /* Using cursor T006L64 */
            pr_default.execute(62, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(62) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"+" ("+"Cuenta Almacen"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(62);
            /* Using cursor T006L65 */
            pr_default.execute(63, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(63) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(63);
            /* Using cursor T006L66 */
            pr_default.execute(64, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(64) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(64);
         }
      }

      protected void EndLevel6L64( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6L64( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(21);
            context.CommitDataStores("contabilidad.plancuentas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(21);
            context.RollbackDataStores("contabilidad.plancuentas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6L64( )
      {
         /* Scan By routine */
         /* Using cursor T006L67 */
         pr_default.execute(65);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound64 = 1;
            A91CueCod = T006L67_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6L64( )
      {
         /* Scan next routine */
         pr_default.readNext(65);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound64 = 1;
            A91CueCod = T006L67_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
      }

      protected void ScanEnd6L64( )
      {
         pr_default.close(65);
      }

      protected void AfterConfirm6L64( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6L64( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6L64( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6L64( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6L64( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6L64( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6L64( )
      {
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         cmbCueSts.Enabled = 0;
         AssignProp("", false, cmbCueSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCueSts.Enabled), 5, 0), true);
         edtCueDsc_Enabled = 0;
         AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), true);
         edtTipACod_Enabled = 0;
         AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         cmbCueBienes.Enabled = 0;
         AssignProp("", false, cmbCueBienes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCueBienes.Enabled), 5, 0), true);
         edtCueMov_Enabled = 0;
         AssignProp("", false, edtCueMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMov_Enabled), 5, 0), true);
         edtCueMon_Enabled = 0;
         AssignProp("", false, edtCueMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMon_Enabled), 5, 0), true);
         edtCueCos_Enabled = 0;
         AssignProp("", false, edtCueCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCos_Enabled), 5, 0), true);
         cmbCueRef4.Enabled = 0;
         AssignProp("", false, cmbCueRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCueRef4.Enabled), 5, 0), true);
         edtCueRef1_Enabled = 0;
         AssignProp("", false, edtCueRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef1_Enabled), 5, 0), true);
         edtCueRef2_Enabled = 0;
         AssignProp("", false, edtCueRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef2_Enabled), 5, 0), true);
         edtCueRef3_Enabled = 0;
         AssignProp("", false, edtCueRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef3_Enabled), 5, 0), true);
         edtCueRef5_Enabled = 0;
         AssignProp("", false, edtCueRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef5_Enabled), 5, 0), true);
         edtCueGasDebe_Enabled = 0;
         AssignProp("", false, edtCueGasDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasDebe_Enabled), 5, 0), true);
         edtCueGasHaber_Enabled = 0;
         AssignProp("", false, edtCueGasHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasHaber_Enabled), 5, 0), true);
         edtCueMonDebe_Enabled = 0;
         AssignProp("", false, edtCueMonDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonDebe_Enabled), 5, 0), true);
         edtCueMonHaber_Enabled = 0;
         AssignProp("", false, edtCueMonHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonHaber_Enabled), 5, 0), true);
         edtCueCierre_Enabled = 0;
         AssignProp("", false, edtCueCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCierre_Enabled), 5, 0), true);
         edtavCombotipacod_Enabled = 0;
         AssignProp("", false, edtavCombotipacod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipacod_Enabled), 5, 0), true);
         edtavCombocuegasdebe_Enabled = 0;
         AssignProp("", false, edtavCombocuegasdebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuegasdebe_Enabled), 5, 0), true);
         edtavCombocuegashaber_Enabled = 0;
         AssignProp("", false, edtavCombocuegashaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuegashaber_Enabled), 5, 0), true);
         edtavCombocuemondebe_Enabled = 0;
         AssignProp("", false, edtavCombocuemondebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuemondebe_Enabled), 5, 0), true);
         edtavCombocuemonhaber_Enabled = 0;
         AssignProp("", false, edtavCombocuemonhaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuemonhaber_Enabled), 5, 0), true);
         edtavCombocuecierre_Enabled = 0;
         AssignProp("", false, edtavCombocuecierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocuecierre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6L64( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027453", false, true);
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
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CueCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"PlanCuentas");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("CueAbr", StringUtil.RTrim( context.localUtil.Format( A857CueAbr, "")));
         forbiddenHiddens.Add("CueGrupDoc", context.localUtil.Format( (decimal)(A863CueGrupDoc), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\plancuentas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z860CueDsc", StringUtil.RTrim( Z860CueDsc));
         GxWebStd.gx_hidden_field( context, "Z857CueAbr", StringUtil.RTrim( Z857CueAbr));
         GxWebStd.gx_hidden_field( context, "Z867CueMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z867CueMov), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z864CueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z864CueMon), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z859CueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z859CueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z873CueSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z873CueSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z868CueRef1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z868CueRef1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z869CueRef2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z869CueRef2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z870CueRef3", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z870CueRef3), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z871CueRef4", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z871CueRef4), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2099CueBienes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2099CueBienes), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z872CueRef5", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z872CueRef5), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z863CueGrupDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z863CueGrupDoc), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z109CueGasDebe", StringUtil.RTrim( Z109CueGasDebe));
         GxWebStd.gx_hidden_field( context, "Z110CueGasHaber", StringUtil.RTrim( Z110CueGasHaber));
         GxWebStd.gx_hidden_field( context, "Z111CueMonDebe", StringUtil.RTrim( Z111CueMonDebe));
         GxWebStd.gx_hidden_field( context, "Z112CueMonHaber", StringUtil.RTrim( Z112CueMonHaber));
         GxWebStd.gx_hidden_field( context, "Z113CueCierre", StringUtil.RTrim( Z113CueCierre));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N109CueGasDebe", StringUtil.RTrim( A109CueGasDebe));
         GxWebStd.gx_hidden_field( context, "N110CueGasHaber", StringUtil.RTrim( A110CueGasHaber));
         GxWebStd.gx_hidden_field( context, "N111CueMonDebe", StringUtil.RTrim( A111CueMonDebe));
         GxWebStd.gx_hidden_field( context, "N112CueMonHaber", StringUtil.RTrim( A112CueMonHaber));
         GxWebStd.gx_hidden_field( context, "N70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N113CueCierre", StringUtil.RTrim( A113CueCierre));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPACOD_DATA", AV30TipACod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPACOD_DATA", AV30TipACod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUEGASDEBE_DATA", AV18CueGasDebe_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUEGASDEBE_DATA", AV18CueGasDebe_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUEGASHABER_DATA", AV24CueGasHaber_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUEGASHABER_DATA", AV24CueGasHaber_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUEMONDEBE_DATA", AV26CueMonDebe_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUEMONDEBE_DATA", AV26CueMonDebe_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUEMONHABER_DATA", AV28CueMonHaber_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUEMONHABER_DATA", AV28CueMonHaber_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUECIERRE_DATA", AV32CueCierre_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUECIERRE_DATA", AV32CueCierre_Data);
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
         GxWebStd.gx_hidden_field( context, "CUEDSCCOMPLETO", StringUtil.RTrim( A2098CueDscCompleto));
         GxWebStd.gx_hidden_field( context, "vCUECOD", StringUtil.RTrim( AV7CueCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUECOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CueCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUEGASDEBE", StringUtil.RTrim( AV11Insert_CueGasDebe));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUEGASHABER", StringUtil.RTrim( AV12Insert_CueGasHaber));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUEMONDEBE", StringUtil.RTrim( AV13Insert_CueMonDebe));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUEMONHABER", StringUtil.RTrim( AV14Insert_CueMonHaber));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPACOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUECIERRE", StringUtil.RTrim( AV16Insert_CueCierre));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUEABR", StringUtil.RTrim( A857CueAbr));
         GxWebStd.gx_hidden_field( context, "CUEGRUPDOC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A863CueGrupDoc), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUECIERREDSC", StringUtil.RTrim( A858CueCierreDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Objectcall", StringUtil.RTrim( Combo_tipacod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Cls", StringUtil.RTrim( Combo_tipacod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipacod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Selectedtext_set", StringUtil.RTrim( Combo_tipacod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Enabled", StringUtil.BoolToStr( Combo_tipacod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Datalistproc", StringUtil.RTrim( Combo_tipacod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipacod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASDEBE_Objectcall", StringUtil.RTrim( Combo_cuegasdebe_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASDEBE_Cls", StringUtil.RTrim( Combo_cuegasdebe_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASDEBE_Selectedvalue_set", StringUtil.RTrim( Combo_cuegasdebe_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASDEBE_Enabled", StringUtil.BoolToStr( Combo_cuegasdebe_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASHABER_Objectcall", StringUtil.RTrim( Combo_cuegashaber_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASHABER_Cls", StringUtil.RTrim( Combo_cuegashaber_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASHABER_Selectedvalue_set", StringUtil.RTrim( Combo_cuegashaber_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEGASHABER_Enabled", StringUtil.BoolToStr( Combo_cuegashaber_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONDEBE_Objectcall", StringUtil.RTrim( Combo_cuemondebe_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONDEBE_Cls", StringUtil.RTrim( Combo_cuemondebe_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONDEBE_Selectedvalue_set", StringUtil.RTrim( Combo_cuemondebe_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONDEBE_Enabled", StringUtil.BoolToStr( Combo_cuemondebe_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONHABER_Objectcall", StringUtil.RTrim( Combo_cuemonhaber_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONHABER_Cls", StringUtil.RTrim( Combo_cuemonhaber_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONHABER_Selectedvalue_set", StringUtil.RTrim( Combo_cuemonhaber_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUEMONHABER_Enabled", StringUtil.BoolToStr( Combo_cuemonhaber_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECIERRE_Objectcall", StringUtil.RTrim( Combo_cuecierre_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECIERRE_Cls", StringUtil.RTrim( Combo_cuecierre_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECIERRE_Selectedvalue_set", StringUtil.RTrim( Combo_cuecierre_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUECIERRE_Enabled", StringUtil.BoolToStr( Combo_cuecierre_Enabled));
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
         GXEncryptionTmp = "contabilidad.plancuentas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CueCod));
         return formatLink("contabilidad.plancuentas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.PlanCuentas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Plan de Cuentas" ;
      }

      protected void InitializeNonKey6L64( )
      {
         A109CueGasDebe = "";
         n109CueGasDebe = false;
         AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
         A110CueGasHaber = "";
         n110CueGasHaber = false;
         AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
         A111CueMonDebe = "";
         n111CueMonDebe = false;
         AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
         A112CueMonHaber = "";
         n112CueMonHaber = false;
         AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
         A70TipACod = 0;
         n70TipACod = false;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         n70TipACod = ((0==A70TipACod) ? true : false);
         A113CueCierre = "";
         n113CueCierre = false;
         AssignAttri("", false, "A113CueCierre", A113CueCierre);
         n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
         A2098CueDscCompleto = "";
         AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
         A860CueDsc = "";
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A857CueAbr = "";
         n857CueAbr = false;
         AssignAttri("", false, "A857CueAbr", A857CueAbr);
         A867CueMov = 0;
         AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
         A864CueMon = 0;
         AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
         A859CueCos = 0;
         AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
         A868CueRef1 = 0;
         AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
         A869CueRef2 = 0;
         AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
         A870CueRef3 = 0;
         AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
         A871CueRef4 = 0;
         AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         A2099CueBienes = 0;
         AssignAttri("", false, "A2099CueBienes", StringUtil.LTrimStr( (decimal)(A2099CueBienes), 6, 0));
         A872CueRef5 = 0;
         AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
         A863CueGrupDoc = 0;
         AssignAttri("", false, "A863CueGrupDoc", StringUtil.Str( (decimal)(A863CueGrupDoc), 1, 0));
         A858CueCierreDsc = "";
         AssignAttri("", false, "A858CueCierreDsc", A858CueCierreDsc);
         A873CueSts = 1;
         AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         Z860CueDsc = "";
         Z857CueAbr = "";
         Z867CueMov = 0;
         Z864CueMon = 0;
         Z859CueCos = 0;
         Z873CueSts = 0;
         Z868CueRef1 = 0;
         Z869CueRef2 = 0;
         Z870CueRef3 = 0;
         Z871CueRef4 = 0;
         Z2099CueBienes = 0;
         Z872CueRef5 = 0;
         Z863CueGrupDoc = 0;
         Z70TipACod = 0;
         Z109CueGasDebe = "";
         Z110CueGasHaber = "";
         Z111CueMonDebe = "";
         Z112CueMonHaber = "";
         Z113CueCierre = "";
      }

      protected void InitAll6L64( )
      {
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         InitializeNonKey6L64( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A873CueSts = i873CueSts;
         AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027557", true, true);
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
         context.AddJavascriptSource("contabilidad/plancuentas.js", "?20228181027558", false, true);
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
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCueCod_Internalname = "CUECOD";
         cmbCueSts_Internalname = "CUESTS";
         lblTextblockcuedsc_Internalname = "TEXTBLOCKCUEDSC";
         edtCueDsc_Internalname = "CUEDSC";
         divUnnamedtablecuedsc_Internalname = "UNNAMEDTABLECUEDSC";
         lblTextblocktipacod_Internalname = "TEXTBLOCKTIPACOD";
         Combo_tipacod_Internalname = "COMBO_TIPACOD";
         edtTipACod_Internalname = "TIPACOD";
         divTablesplittedtipacod_Internalname = "TABLESPLITTEDTIPACOD";
         lblTextblockcuebienes_Internalname = "TEXTBLOCKCUEBIENES";
         cmbCueBienes_Internalname = "CUEBIENES";
         divUnnamedtablecuebienes_Internalname = "UNNAMEDTABLECUEBIENES";
         edtCueMov_Internalname = "CUEMOV";
         edtCueMon_Internalname = "CUEMON";
         edtCueCos_Internalname = "CUECOS";
         cmbCueRef4_Internalname = "CUEREF4";
         edtCueRef1_Internalname = "CUEREF1";
         edtCueRef2_Internalname = "CUEREF2";
         edtCueRef3_Internalname = "CUEREF3";
         edtCueRef5_Internalname = "CUEREF5";
         divGrupo1_Internalname = "GRUPO1";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         lblTextblockcuegasdebe_Internalname = "TEXTBLOCKCUEGASDEBE";
         Combo_cuegasdebe_Internalname = "COMBO_CUEGASDEBE";
         edtCueGasDebe_Internalname = "CUEGASDEBE";
         divTablesplittedcuegasdebe_Internalname = "TABLESPLITTEDCUEGASDEBE";
         lblTextblockcuegashaber_Internalname = "TEXTBLOCKCUEGASHABER";
         Combo_cuegashaber_Internalname = "COMBO_CUEGASHABER";
         edtCueGasHaber_Internalname = "CUEGASHABER";
         divTablesplittedcuegashaber_Internalname = "TABLESPLITTEDCUEGASHABER";
         divTab2_Internalname = "TAB2";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         lblTextblockcuemondebe_Internalname = "TEXTBLOCKCUEMONDEBE";
         Combo_cuemondebe_Internalname = "COMBO_CUEMONDEBE";
         edtCueMonDebe_Internalname = "CUEMONDEBE";
         divTablesplittedcuemondebe_Internalname = "TABLESPLITTEDCUEMONDEBE";
         lblTextblockcuemonhaber_Internalname = "TEXTBLOCKCUEMONHABER";
         Combo_cuemonhaber_Internalname = "COMBO_CUEMONHABER";
         edtCueMonHaber_Internalname = "CUEMONHABER";
         divTablesplittedcuemonhaber_Internalname = "TABLESPLITTEDCUEMONHABER";
         divTab3_Internalname = "TAB3";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         lblTextblockcuecierre_Internalname = "TEXTBLOCKCUECIERRE";
         Combo_cuecierre_Internalname = "COMBO_CUECIERRE";
         edtCueCierre_Internalname = "CUECIERRE";
         divTablesplittedcuecierre_Internalname = "TABLESPLITTEDCUECIERRE";
         divTab4_Internalname = "TAB4";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotipacod_Internalname = "vCOMBOTIPACOD";
         divSectionattribute_tipacod_Internalname = "SECTIONATTRIBUTE_TIPACOD";
         edtavCombocuegasdebe_Internalname = "vCOMBOCUEGASDEBE";
         divSectionattribute_cuegasdebe_Internalname = "SECTIONATTRIBUTE_CUEGASDEBE";
         edtavCombocuegashaber_Internalname = "vCOMBOCUEGASHABER";
         divSectionattribute_cuegashaber_Internalname = "SECTIONATTRIBUTE_CUEGASHABER";
         edtavCombocuemondebe_Internalname = "vCOMBOCUEMONDEBE";
         divSectionattribute_cuemondebe_Internalname = "SECTIONATTRIBUTE_CUEMONDEBE";
         edtavCombocuemonhaber_Internalname = "vCOMBOCUEMONHABER";
         divSectionattribute_cuemonhaber_Internalname = "SECTIONATTRIBUTE_CUEMONHABER";
         edtavCombocuecierre_Internalname = "vCOMBOCUECIERRE";
         divSectionattribute_cuecierre_Internalname = "SECTIONATTRIBUTE_CUECIERRE";
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
         Form.Caption = "Plan de Cuentas";
         edtavCombocuecierre_Jsonclick = "";
         edtavCombocuecierre_Enabled = 0;
         edtavCombocuecierre_Visible = 1;
         edtavCombocuemonhaber_Jsonclick = "";
         edtavCombocuemonhaber_Enabled = 0;
         edtavCombocuemonhaber_Visible = 1;
         edtavCombocuemondebe_Jsonclick = "";
         edtavCombocuemondebe_Enabled = 0;
         edtavCombocuemondebe_Visible = 1;
         edtavCombocuegashaber_Jsonclick = "";
         edtavCombocuegashaber_Enabled = 0;
         edtavCombocuegashaber_Visible = 1;
         edtavCombocuegasdebe_Jsonclick = "";
         edtavCombocuegasdebe_Enabled = 0;
         edtavCombocuegasdebe_Visible = 1;
         edtavCombotipacod_Jsonclick = "";
         edtavCombotipacod_Enabled = 0;
         edtavCombotipacod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCueCierre_Jsonclick = "";
         edtCueCierre_Enabled = 1;
         edtCueCierre_Visible = 1;
         Combo_cuecierre_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_cuecierre_Caption = "";
         Combo_cuecierre_Enabled = Convert.ToBoolean( -1);
         edtCueMonHaber_Jsonclick = "";
         edtCueMonHaber_Enabled = 1;
         edtCueMonHaber_Visible = 1;
         Combo_cuemonhaber_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_cuemonhaber_Caption = "";
         Combo_cuemonhaber_Enabled = Convert.ToBoolean( -1);
         edtCueMonDebe_Jsonclick = "";
         edtCueMonDebe_Enabled = 1;
         edtCueMonDebe_Visible = 1;
         Combo_cuemondebe_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_cuemondebe_Caption = "";
         Combo_cuemondebe_Enabled = Convert.ToBoolean( -1);
         edtCueGasHaber_Jsonclick = "";
         edtCueGasHaber_Enabled = 1;
         edtCueGasHaber_Visible = 1;
         Combo_cuegashaber_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_cuegashaber_Caption = "";
         Combo_cuegashaber_Enabled = Convert.ToBoolean( -1);
         edtCueGasDebe_Jsonclick = "";
         edtCueGasDebe_Enabled = 1;
         edtCueGasDebe_Visible = 1;
         Combo_cuegasdebe_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_cuegasdebe_Caption = "";
         Combo_cuegasdebe_Enabled = Convert.ToBoolean( -1);
         edtCueRef5_Jsonclick = "";
         edtCueRef5_Enabled = 1;
         edtCueRef3_Jsonclick = "";
         edtCueRef3_Enabled = 1;
         edtCueRef2_Jsonclick = "";
         edtCueRef2_Enabled = 1;
         edtCueRef1_Jsonclick = "";
         edtCueRef1_Enabled = 1;
         cmbCueRef4_Jsonclick = "";
         cmbCueRef4.Enabled = 1;
         edtCueCos_Jsonclick = "";
         edtCueCos_Enabled = 1;
         edtCueMon_Jsonclick = "";
         edtCueMon_Enabled = 1;
         edtCueMov_Jsonclick = "";
         edtCueMov_Enabled = 1;
         cmbCueBienes_Jsonclick = "";
         cmbCueBienes.Enabled = 1;
         edtTipACod_Jsonclick = "";
         edtTipACod_Enabled = 1;
         edtTipACod_Visible = 1;
         Combo_tipacod_Datalistprocparametersprefix = " \"ComboName\": \"TipACod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CueCod\": \"\"";
         Combo_tipacod_Datalistproc = "Contabilidad.PlanCuentasLoadDVCombo";
         Combo_tipacod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_tipacod_Caption = "";
         Combo_tipacod_Enabled = Convert.ToBoolean( -1);
         edtCueDsc_Jsonclick = "";
         edtCueDsc_Enabled = 1;
         cmbCueSts_Jsonclick = "";
         cmbCueSts.Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
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
         cmbCueSts.Name = "CUESTS";
         cmbCueSts.WebTags = "";
         cmbCueSts.addItem("1", "ACTIVO", 0);
         cmbCueSts.addItem("0", "INACTIVO", 0);
         if ( cmbCueSts.ItemCount > 0 )
         {
            if ( (0==A873CueSts) )
            {
               A873CueSts = 1;
               AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            }
         }
         cmbCueBienes.Name = "CUEBIENES";
         cmbCueBienes.WebTags = "";
         cmbCueBienes.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 6, 0)), "(Ninguno)", 0);
         cmbCueBienes.addItem("1", "1.- MERCADERIA, MATERIA PRIMA,SUMINISTRO,ENVASES Y EMBALAJES", 0);
         cmbCueBienes.addItem("2", "2.- ACTIVO FIJOS", 0);
         cmbCueBienes.addItem("3", "3.- OTROS ACTIVOS NO CONSIDERADOS EN EL NUMERAL 1 Y 2", 0);
         cmbCueBienes.addItem("4", "4.- GASTOS DE EDUCACIÓN,RECREACIÓN,SALUD,CULTURALES,REPRESENTACIÓN,CAPACITACIÓN,DE VIAJE,MANTENIMIENTO DE VEHICULO Y DE PREMIOS", 0);
         cmbCueBienes.addItem("5", "5.- OTROS GASTOS NO INCLUIDOS EN EL NUMERAL 4", 0);
         if ( cmbCueBienes.ItemCount > 0 )
         {
            A2099CueBienes = (int)(NumberUtil.Val( cmbCueBienes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2099CueBienes), 6, 0))), "."));
            AssignAttri("", false, "A2099CueBienes", StringUtil.LTrimStr( (decimal)(A2099CueBienes), 6, 0));
         }
         cmbCueRef4.Name = "CUEREF4";
         cmbCueRef4.WebTags = "";
         cmbCueRef4.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "(Ninguno)", 0);
         cmbCueRef4.addItem("1", "Venta", 0);
         cmbCueRef4.addItem("2", "Compra", 0);
         if ( cmbCueRef4.ItemCount > 0 )
         {
            A871CueRef4 = (short)(NumberUtil.Val( cmbCueRef4.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0))), "."));
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
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

      public void Valid_Tipacod( )
      {
         n70TipACod = false;
         /* Using cursor T006L68 */
         pr_default.execute(66, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(66) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
            }
         }
         pr_default.close(66);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuegasdebe( )
      {
         n109CueGasDebe = false;
         /* Using cursor T006L69 */
         pr_default.execute(67, new Object[] {n109CueGasDebe, A109CueGasDebe});
         if ( (pr_default.getStatus(67) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueGasDebe_Internalname;
            }
         }
         pr_default.close(67);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuegashaber( )
      {
         n110CueGasHaber = false;
         /* Using cursor T006L70 */
         pr_default.execute(68, new Object[] {n110CueGasHaber, A110CueGasHaber});
         if ( (pr_default.getStatus(68) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASHABER");
               AnyError = 1;
               GX_FocusControl = edtCueGasHaber_Internalname;
            }
         }
         pr_default.close(68);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuemondebe( )
      {
         n111CueMonDebe = false;
         /* Using cursor T006L71 */
         pr_default.execute(69, new Object[] {n111CueMonDebe, A111CueMonDebe});
         if ( (pr_default.getStatus(69) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A111CueMonDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueMonDebe_Internalname;
            }
         }
         pr_default.close(69);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuemonhaber( )
      {
         n112CueMonHaber = false;
         /* Using cursor T006L72 */
         pr_default.execute(70, new Object[] {n112CueMonHaber, A112CueMonHaber});
         if ( (pr_default.getStatus(70) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112CueMonHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONHABER");
               AnyError = 1;
               GX_FocusControl = edtCueMonHaber_Internalname;
            }
         }
         pr_default.close(70);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuecierre( )
      {
         n113CueCierre = false;
         /* Using cursor T006L23 */
         pr_default.execute(21, new Object[] {n113CueCierre, A113CueCierre});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Cierre'.", "ForeignKeyNotFound", 1, "CUECIERRE");
               AnyError = 1;
               GX_FocusControl = edtCueCierre_Internalname;
            }
         }
         A858CueCierreDsc = T006L23_A858CueCierreDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A858CueCierreDsc", StringUtil.RTrim( A858CueCierreDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CueCod',fld:'vCUECOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CueCod',fld:'vCUECOD',pic:'',hsh:true},{av:'A857CueAbr',fld:'CUEABR',pic:''},{av:'A863CueGrupDoc',fld:'CUEGRUPDOC',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126L2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
         setEventMetadata("VALID_CUEDSC","{handler:'Valid_Cuedsc',iparms:[]");
         setEventMetadata("VALID_CUEDSC",",oparms:[]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
         setEventMetadata("VALID_CUEGASDEBE","{handler:'Valid_Cuegasdebe',iparms:[{av:'A109CueGasDebe',fld:'CUEGASDEBE',pic:''}]");
         setEventMetadata("VALID_CUEGASDEBE",",oparms:[]}");
         setEventMetadata("VALID_CUEGASHABER","{handler:'Valid_Cuegashaber',iparms:[{av:'A110CueGasHaber',fld:'CUEGASHABER',pic:''}]");
         setEventMetadata("VALID_CUEGASHABER",",oparms:[]}");
         setEventMetadata("VALID_CUEMONDEBE","{handler:'Valid_Cuemondebe',iparms:[{av:'A111CueMonDebe',fld:'CUEMONDEBE',pic:''}]");
         setEventMetadata("VALID_CUEMONDEBE",",oparms:[]}");
         setEventMetadata("VALID_CUEMONHABER","{handler:'Valid_Cuemonhaber',iparms:[{av:'A112CueMonHaber',fld:'CUEMONHABER',pic:''}]");
         setEventMetadata("VALID_CUEMONHABER",",oparms:[]}");
         setEventMetadata("VALID_CUECIERRE","{handler:'Valid_Cuecierre',iparms:[{av:'A113CueCierre',fld:'CUECIERRE',pic:''},{av:'A858CueCierreDsc',fld:'CUECIERREDSC',pic:''}]");
         setEventMetadata("VALID_CUECIERRE",",oparms:[{av:'A858CueCierreDsc',fld:'CUECIERREDSC',pic:''}]}");
         setEventMetadata("VALIDV_COMBOTIPACOD","{handler:'Validv_Combotipacod',iparms:[]");
         setEventMetadata("VALIDV_COMBOTIPACOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCUEGASDEBE","{handler:'Validv_Combocuegasdebe',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUEGASDEBE",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCUEGASHABER","{handler:'Validv_Combocuegashaber',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUEGASHABER",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCUEMONDEBE","{handler:'Validv_Combocuemondebe',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUEMONDEBE",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCUEMONHABER","{handler:'Validv_Combocuemonhaber',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUEMONHABER",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCUECIERRE","{handler:'Validv_Combocuecierre',iparms:[]");
         setEventMetadata("VALIDV_COMBOCUECIERRE",",oparms:[]}");
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
         pr_default.close(66);
         pr_default.close(67);
         pr_default.close(68);
         pr_default.close(69);
         pr_default.close(70);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CueCod = "";
         Z91CueCod = "";
         Z860CueDsc = "";
         Z857CueAbr = "";
         Z109CueGasDebe = "";
         Z110CueGasHaber = "";
         Z111CueMonDebe = "";
         Z112CueMonHaber = "";
         Z113CueCierre = "";
         N109CueGasDebe = "";
         N110CueGasHaber = "";
         N111CueMonDebe = "";
         N112CueMonHaber = "";
         N113CueCierre = "";
         Combo_cuecierre_Selectedvalue_get = "";
         Combo_cuemonhaber_Selectedvalue_get = "";
         Combo_cuemondebe_Selectedvalue_get = "";
         Combo_cuegashaber_Selectedvalue_get = "";
         Combo_cuegasdebe_Selectedvalue_get = "";
         Combo_tipacod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A109CueGasDebe = "";
         A110CueGasHaber = "";
         A111CueMonDebe = "";
         A112CueMonHaber = "";
         A113CueCierre = "";
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
         A91CueCod = "";
         lblTextblockcuedsc_Jsonclick = "";
         A860CueDsc = "";
         lblTextblocktipacod_Jsonclick = "";
         ucCombo_tipacod = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV30TipACod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcuebienes_Jsonclick = "";
         lblTextblockcuegasdebe_Jsonclick = "";
         ucCombo_cuegasdebe = new GXUserControl();
         AV18CueGasDebe_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcuegashaber_Jsonclick = "";
         ucCombo_cuegashaber = new GXUserControl();
         AV24CueGasHaber_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcuemondebe_Jsonclick = "";
         ucCombo_cuemondebe = new GXUserControl();
         AV26CueMonDebe_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcuemonhaber_Jsonclick = "";
         ucCombo_cuemonhaber = new GXUserControl();
         AV28CueMonHaber_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockcuecierre_Jsonclick = "";
         ucCombo_cuecierre = new GXUserControl();
         AV32CueCierre_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23ComboCueGasDebe = "";
         AV25ComboCueGasHaber = "";
         AV27ComboCueMonDebe = "";
         AV29ComboCueMonHaber = "";
         AV33ComboCueCierre = "";
         A857CueAbr = "";
         A2098CueDscCompleto = "";
         AV11Insert_CueGasDebe = "";
         AV12Insert_CueGasHaber = "";
         AV13Insert_CueMonDebe = "";
         AV14Insert_CueMonHaber = "";
         AV16Insert_CueCierre = "";
         A858CueCierreDsc = "";
         AV37Pgmname = "";
         Combo_tipacod_Objectcall = "";
         Combo_tipacod_Class = "";
         Combo_tipacod_Icontype = "";
         Combo_tipacod_Icon = "";
         Combo_tipacod_Tooltip = "";
         Combo_tipacod_Selectedvalue_set = "";
         Combo_tipacod_Selectedtext_set = "";
         Combo_tipacod_Selectedtext_get = "";
         Combo_tipacod_Gamoauthtoken = "";
         Combo_tipacod_Ddointernalname = "";
         Combo_tipacod_Titlecontrolalign = "";
         Combo_tipacod_Dropdownoptionstype = "";
         Combo_tipacod_Titlecontrolidtoreplace = "";
         Combo_tipacod_Datalisttype = "";
         Combo_tipacod_Datalistfixedvalues = "";
         Combo_tipacod_Htmltemplate = "";
         Combo_tipacod_Multiplevaluestype = "";
         Combo_tipacod_Loadingdata = "";
         Combo_tipacod_Noresultsfound = "";
         Combo_tipacod_Emptyitemtext = "";
         Combo_tipacod_Onlyselectedvalues = "";
         Combo_tipacod_Selectalltext = "";
         Combo_tipacod_Multiplevaluesseparator = "";
         Combo_tipacod_Addnewoptiontext = "";
         Combo_cuegasdebe_Objectcall = "";
         Combo_cuegasdebe_Class = "";
         Combo_cuegasdebe_Icontype = "";
         Combo_cuegasdebe_Icon = "";
         Combo_cuegasdebe_Tooltip = "";
         Combo_cuegasdebe_Selectedvalue_set = "";
         Combo_cuegasdebe_Selectedtext_set = "";
         Combo_cuegasdebe_Selectedtext_get = "";
         Combo_cuegasdebe_Gamoauthtoken = "";
         Combo_cuegasdebe_Ddointernalname = "";
         Combo_cuegasdebe_Titlecontrolalign = "";
         Combo_cuegasdebe_Dropdownoptionstype = "";
         Combo_cuegasdebe_Titlecontrolidtoreplace = "";
         Combo_cuegasdebe_Datalisttype = "";
         Combo_cuegasdebe_Datalistfixedvalues = "";
         Combo_cuegasdebe_Datalistproc = "";
         Combo_cuegasdebe_Datalistprocparametersprefix = "";
         Combo_cuegasdebe_Htmltemplate = "";
         Combo_cuegasdebe_Multiplevaluestype = "";
         Combo_cuegasdebe_Loadingdata = "";
         Combo_cuegasdebe_Noresultsfound = "";
         Combo_cuegasdebe_Emptyitemtext = "";
         Combo_cuegasdebe_Onlyselectedvalues = "";
         Combo_cuegasdebe_Selectalltext = "";
         Combo_cuegasdebe_Multiplevaluesseparator = "";
         Combo_cuegasdebe_Addnewoptiontext = "";
         Combo_cuegashaber_Objectcall = "";
         Combo_cuegashaber_Class = "";
         Combo_cuegashaber_Icontype = "";
         Combo_cuegashaber_Icon = "";
         Combo_cuegashaber_Tooltip = "";
         Combo_cuegashaber_Selectedvalue_set = "";
         Combo_cuegashaber_Selectedtext_set = "";
         Combo_cuegashaber_Selectedtext_get = "";
         Combo_cuegashaber_Gamoauthtoken = "";
         Combo_cuegashaber_Ddointernalname = "";
         Combo_cuegashaber_Titlecontrolalign = "";
         Combo_cuegashaber_Dropdownoptionstype = "";
         Combo_cuegashaber_Titlecontrolidtoreplace = "";
         Combo_cuegashaber_Datalisttype = "";
         Combo_cuegashaber_Datalistfixedvalues = "";
         Combo_cuegashaber_Datalistproc = "";
         Combo_cuegashaber_Datalistprocparametersprefix = "";
         Combo_cuegashaber_Htmltemplate = "";
         Combo_cuegashaber_Multiplevaluestype = "";
         Combo_cuegashaber_Loadingdata = "";
         Combo_cuegashaber_Noresultsfound = "";
         Combo_cuegashaber_Emptyitemtext = "";
         Combo_cuegashaber_Onlyselectedvalues = "";
         Combo_cuegashaber_Selectalltext = "";
         Combo_cuegashaber_Multiplevaluesseparator = "";
         Combo_cuegashaber_Addnewoptiontext = "";
         Combo_cuemondebe_Objectcall = "";
         Combo_cuemondebe_Class = "";
         Combo_cuemondebe_Icontype = "";
         Combo_cuemondebe_Icon = "";
         Combo_cuemondebe_Tooltip = "";
         Combo_cuemondebe_Selectedvalue_set = "";
         Combo_cuemondebe_Selectedtext_set = "";
         Combo_cuemondebe_Selectedtext_get = "";
         Combo_cuemondebe_Gamoauthtoken = "";
         Combo_cuemondebe_Ddointernalname = "";
         Combo_cuemondebe_Titlecontrolalign = "";
         Combo_cuemondebe_Dropdownoptionstype = "";
         Combo_cuemondebe_Titlecontrolidtoreplace = "";
         Combo_cuemondebe_Datalisttype = "";
         Combo_cuemondebe_Datalistfixedvalues = "";
         Combo_cuemondebe_Datalistproc = "";
         Combo_cuemondebe_Datalistprocparametersprefix = "";
         Combo_cuemondebe_Htmltemplate = "";
         Combo_cuemondebe_Multiplevaluestype = "";
         Combo_cuemondebe_Loadingdata = "";
         Combo_cuemondebe_Noresultsfound = "";
         Combo_cuemondebe_Emptyitemtext = "";
         Combo_cuemondebe_Onlyselectedvalues = "";
         Combo_cuemondebe_Selectalltext = "";
         Combo_cuemondebe_Multiplevaluesseparator = "";
         Combo_cuemondebe_Addnewoptiontext = "";
         Combo_cuemonhaber_Objectcall = "";
         Combo_cuemonhaber_Class = "";
         Combo_cuemonhaber_Icontype = "";
         Combo_cuemonhaber_Icon = "";
         Combo_cuemonhaber_Tooltip = "";
         Combo_cuemonhaber_Selectedvalue_set = "";
         Combo_cuemonhaber_Selectedtext_set = "";
         Combo_cuemonhaber_Selectedtext_get = "";
         Combo_cuemonhaber_Gamoauthtoken = "";
         Combo_cuemonhaber_Ddointernalname = "";
         Combo_cuemonhaber_Titlecontrolalign = "";
         Combo_cuemonhaber_Dropdownoptionstype = "";
         Combo_cuemonhaber_Titlecontrolidtoreplace = "";
         Combo_cuemonhaber_Datalisttype = "";
         Combo_cuemonhaber_Datalistfixedvalues = "";
         Combo_cuemonhaber_Datalistproc = "";
         Combo_cuemonhaber_Datalistprocparametersprefix = "";
         Combo_cuemonhaber_Htmltemplate = "";
         Combo_cuemonhaber_Multiplevaluestype = "";
         Combo_cuemonhaber_Loadingdata = "";
         Combo_cuemonhaber_Noresultsfound = "";
         Combo_cuemonhaber_Emptyitemtext = "";
         Combo_cuemonhaber_Onlyselectedvalues = "";
         Combo_cuemonhaber_Selectalltext = "";
         Combo_cuemonhaber_Multiplevaluesseparator = "";
         Combo_cuemonhaber_Addnewoptiontext = "";
         Combo_cuecierre_Objectcall = "";
         Combo_cuecierre_Class = "";
         Combo_cuecierre_Icontype = "";
         Combo_cuecierre_Icon = "";
         Combo_cuecierre_Tooltip = "";
         Combo_cuecierre_Selectedvalue_set = "";
         Combo_cuecierre_Selectedtext_set = "";
         Combo_cuecierre_Selectedtext_get = "";
         Combo_cuecierre_Gamoauthtoken = "";
         Combo_cuecierre_Ddointernalname = "";
         Combo_cuecierre_Titlecontrolalign = "";
         Combo_cuecierre_Dropdownoptionstype = "";
         Combo_cuecierre_Titlecontrolidtoreplace = "";
         Combo_cuecierre_Datalisttype = "";
         Combo_cuecierre_Datalistfixedvalues = "";
         Combo_cuecierre_Datalistproc = "";
         Combo_cuecierre_Datalistprocparametersprefix = "";
         Combo_cuecierre_Htmltemplate = "";
         Combo_cuecierre_Multiplevaluestype = "";
         Combo_cuecierre_Loadingdata = "";
         Combo_cuecierre_Noresultsfound = "";
         Combo_cuecierre_Emptyitemtext = "";
         Combo_cuecierre_Onlyselectedvalues = "";
         Combo_cuecierre_Selectalltext = "";
         Combo_cuecierre_Multiplevaluesseparator = "";
         Combo_cuecierre_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode64 = "";
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
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV22Combo_DataJson = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         AV34SGAuDocGls = "";
         AV35Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         GXt_char4 = "";
         Z858CueCierreDsc = "";
         T006L9_A858CueCierreDsc = new string[] {""} ;
         T006L10_A91CueCod = new string[] {""} ;
         T006L10_A860CueDsc = new string[] {""} ;
         T006L10_A857CueAbr = new string[] {""} ;
         T006L10_n857CueAbr = new bool[] {false} ;
         T006L10_A867CueMov = new short[1] ;
         T006L10_A864CueMon = new short[1] ;
         T006L10_A859CueCos = new short[1] ;
         T006L10_A873CueSts = new short[1] ;
         T006L10_A868CueRef1 = new short[1] ;
         T006L10_A869CueRef2 = new short[1] ;
         T006L10_A870CueRef3 = new short[1] ;
         T006L10_A871CueRef4 = new short[1] ;
         T006L10_A2099CueBienes = new int[1] ;
         T006L10_A872CueRef5 = new short[1] ;
         T006L10_A863CueGrupDoc = new short[1] ;
         T006L10_A858CueCierreDsc = new string[] {""} ;
         T006L10_A70TipACod = new int[1] ;
         T006L10_n70TipACod = new bool[] {false} ;
         T006L10_A109CueGasDebe = new string[] {""} ;
         T006L10_n109CueGasDebe = new bool[] {false} ;
         T006L10_A110CueGasHaber = new string[] {""} ;
         T006L10_n110CueGasHaber = new bool[] {false} ;
         T006L10_A111CueMonDebe = new string[] {""} ;
         T006L10_n111CueMonDebe = new bool[] {false} ;
         T006L10_A112CueMonHaber = new string[] {""} ;
         T006L10_n112CueMonHaber = new bool[] {false} ;
         T006L10_A113CueCierre = new string[] {""} ;
         T006L10_n113CueCierre = new bool[] {false} ;
         T006L5_A109CueGasDebe = new string[] {""} ;
         T006L5_n109CueGasDebe = new bool[] {false} ;
         T006L6_A110CueGasHaber = new string[] {""} ;
         T006L6_n110CueGasHaber = new bool[] {false} ;
         T006L7_A111CueMonDebe = new string[] {""} ;
         T006L7_n111CueMonDebe = new bool[] {false} ;
         T006L8_A112CueMonHaber = new string[] {""} ;
         T006L8_n112CueMonHaber = new bool[] {false} ;
         T006L4_A70TipACod = new int[1] ;
         T006L4_n70TipACod = new bool[] {false} ;
         T006L11_A109CueGasDebe = new string[] {""} ;
         T006L11_n109CueGasDebe = new bool[] {false} ;
         T006L12_A110CueGasHaber = new string[] {""} ;
         T006L12_n110CueGasHaber = new bool[] {false} ;
         T006L13_A111CueMonDebe = new string[] {""} ;
         T006L13_n111CueMonDebe = new bool[] {false} ;
         T006L14_A112CueMonHaber = new string[] {""} ;
         T006L14_n112CueMonHaber = new bool[] {false} ;
         T006L15_A70TipACod = new int[1] ;
         T006L15_n70TipACod = new bool[] {false} ;
         T006L16_A858CueCierreDsc = new string[] {""} ;
         T006L17_A91CueCod = new string[] {""} ;
         T006L3_A91CueCod = new string[] {""} ;
         T006L3_A860CueDsc = new string[] {""} ;
         T006L3_A857CueAbr = new string[] {""} ;
         T006L3_n857CueAbr = new bool[] {false} ;
         T006L3_A867CueMov = new short[1] ;
         T006L3_A864CueMon = new short[1] ;
         T006L3_A859CueCos = new short[1] ;
         T006L3_A873CueSts = new short[1] ;
         T006L3_A868CueRef1 = new short[1] ;
         T006L3_A869CueRef2 = new short[1] ;
         T006L3_A870CueRef3 = new short[1] ;
         T006L3_A871CueRef4 = new short[1] ;
         T006L3_A2099CueBienes = new int[1] ;
         T006L3_A872CueRef5 = new short[1] ;
         T006L3_A863CueGrupDoc = new short[1] ;
         T006L3_A70TipACod = new int[1] ;
         T006L3_n70TipACod = new bool[] {false} ;
         T006L3_A109CueGasDebe = new string[] {""} ;
         T006L3_n109CueGasDebe = new bool[] {false} ;
         T006L3_A110CueGasHaber = new string[] {""} ;
         T006L3_n110CueGasHaber = new bool[] {false} ;
         T006L3_A111CueMonDebe = new string[] {""} ;
         T006L3_n111CueMonDebe = new bool[] {false} ;
         T006L3_A112CueMonHaber = new string[] {""} ;
         T006L3_n112CueMonHaber = new bool[] {false} ;
         T006L3_A113CueCierre = new string[] {""} ;
         T006L3_n113CueCierre = new bool[] {false} ;
         T006L18_A91CueCod = new string[] {""} ;
         T006L19_A91CueCod = new string[] {""} ;
         T006L2_A91CueCod = new string[] {""} ;
         T006L2_A860CueDsc = new string[] {""} ;
         T006L2_A857CueAbr = new string[] {""} ;
         T006L2_n857CueAbr = new bool[] {false} ;
         T006L2_A867CueMov = new short[1] ;
         T006L2_A864CueMon = new short[1] ;
         T006L2_A859CueCos = new short[1] ;
         T006L2_A873CueSts = new short[1] ;
         T006L2_A868CueRef1 = new short[1] ;
         T006L2_A869CueRef2 = new short[1] ;
         T006L2_A870CueRef3 = new short[1] ;
         T006L2_A871CueRef4 = new short[1] ;
         T006L2_A2099CueBienes = new int[1] ;
         T006L2_A872CueRef5 = new short[1] ;
         T006L2_A863CueGrupDoc = new short[1] ;
         T006L2_A70TipACod = new int[1] ;
         T006L2_n70TipACod = new bool[] {false} ;
         T006L2_A109CueGasDebe = new string[] {""} ;
         T006L2_n109CueGasDebe = new bool[] {false} ;
         T006L2_A110CueGasHaber = new string[] {""} ;
         T006L2_n110CueGasHaber = new bool[] {false} ;
         T006L2_A111CueMonDebe = new string[] {""} ;
         T006L2_n111CueMonDebe = new bool[] {false} ;
         T006L2_A112CueMonHaber = new string[] {""} ;
         T006L2_n112CueMonHaber = new bool[] {false} ;
         T006L2_A113CueCierre = new string[] {""} ;
         T006L2_n113CueCierre = new bool[] {false} ;
         T006L23_A858CueCierreDsc = new string[] {""} ;
         T006L24_A113CueCierre = new string[] {""} ;
         T006L24_n113CueCierre = new bool[] {false} ;
         T006L25_A112CueMonHaber = new string[] {""} ;
         T006L25_n112CueMonHaber = new bool[] {false} ;
         T006L26_A111CueMonDebe = new string[] {""} ;
         T006L26_n111CueMonDebe = new bool[] {false} ;
         T006L27_A110CueGasHaber = new string[] {""} ;
         T006L27_n110CueGasHaber = new bool[] {false} ;
         T006L28_A109CueGasDebe = new string[] {""} ;
         T006L28_n109CueGasDebe = new bool[] {false} ;
         T006L29_A365EntCod = new int[1] ;
         T006L29_A403MVLEntCod = new string[] {""} ;
         T006L29_A404MVLEITem = new int[1] ;
         T006L30_A358CajCod = new int[1] ;
         T006L30_A391MVLCajCod = new string[] {""} ;
         T006L30_A392MVLITem = new int[1] ;
         T006L31_A372BanCod = new int[1] ;
         T006L31_A377CBCod = new string[] {""} ;
         T006L32_A355ConBCod = new int[1] ;
         T006L33_A332PSerConcCod = new int[1] ;
         T006L33_A333PSerDConcCueCod = new string[] {""} ;
         T006L34_A313PoConcCod = new int[1] ;
         T006L34_A315PoConcDCueCod = new string[] {""} ;
         T006L35_A149TipCod = new string[] {""} ;
         T006L35_A243ComCod = new string[] {""} ;
         T006L35_A244PrvCod = new string[] {""} ;
         T006L35_A250ComDItem = new short[1] ;
         T006L35_A251ComDOrdCod = new string[] {""} ;
         T006L36_A121SalVouAno = new short[1] ;
         T006L36_A122SalVouMes = new short[1] ;
         T006L36_A123SalCueCod = new string[] {""} ;
         T006L36_A124SalMonCod = new int[1] ;
         T006L36_A125SalCueAux = new string[] {""} ;
         T006L37_A83ParTip = new string[] {""} ;
         T006L37_A84ParCod = new int[1] ;
         T006L37_A104ParDItem = new short[1] ;
         T006L38_A83ParTip = new string[] {""} ;
         T006L38_A84ParCod = new int[1] ;
         T006L38_A104ParDItem = new short[1] ;
         T006L39_A83ParTip = new string[] {""} ;
         T006L39_A84ParCod = new int[1] ;
         T006L40_A83ParTip = new string[] {""} ;
         T006L40_A84ParCod = new int[1] ;
         T006L41_A83ParTip = new string[] {""} ;
         T006L41_A84ParCod = new int[1] ;
         T006L42_A83ParTip = new string[] {""} ;
         T006L42_A84ParCod = new int[1] ;
         T006L43_A83ParTip = new string[] {""} ;
         T006L43_A84ParCod = new int[1] ;
         T006L44_A83ParTip = new string[] {""} ;
         T006L44_A84ParCod = new int[1] ;
         T006L45_A83ParTip = new string[] {""} ;
         T006L45_A84ParCod = new int[1] ;
         T006L46_A83ParTip = new string[] {""} ;
         T006L46_A84ParCod = new int[1] ;
         T006L47_A83ParTip = new string[] {""} ;
         T006L47_A84ParCod = new int[1] ;
         T006L48_A83ParTip = new string[] {""} ;
         T006L48_A84ParCod = new int[1] ;
         T006L49_A2280CBTipPre = new int[1] ;
         T006L49_A2281CBTipTipo = new string[] {""} ;
         T006L49_A2282CBLinPre = new int[1] ;
         T006L49_A2283CBRubPre = new int[1] ;
         T006L49_A2284CBRubDItem = new int[1] ;
         T006L50_A83ParTip = new string[] {""} ;
         T006L50_A84ParCod = new int[1] ;
         T006L50_A90ParDTipItem = new int[1] ;
         T006L51_A365EntCod = new int[1] ;
         T006L52_A376ConEntCod = new int[1] ;
         T006L53_A375ConCajCod = new int[1] ;
         T006L54_A358CajCod = new int[1] ;
         T006L55_A236LiqPrvCod = new string[] {""} ;
         T006L56_A127VouAno = new short[1] ;
         T006L56_A128VouMes = new short[1] ;
         T006L56_A126TASICod = new int[1] ;
         T006L56_A129VouNum = new string[] {""} ;
         T006L56_A130VouDSec = new int[1] ;
         T006L57_A114TotTipo = new string[] {""} ;
         T006L57_A115TotRub = new int[1] ;
         T006L57_A116RubCod = new int[1] ;
         T006L57_A118RubLinCod = new int[1] ;
         T006L57_A91CueCod = new string[] {""} ;
         T006L58_A83ParTip = new string[] {""} ;
         T006L58_A84ParCod = new int[1] ;
         T006L58_A85ParDActItem = new int[1] ;
         T006L59_A83ParTip = new string[] {""} ;
         T006L59_A84ParCod = new int[1] ;
         T006L59_A85ParDActItem = new int[1] ;
         T006L60_A83ParTip = new string[] {""} ;
         T006L60_A84ParCod = new int[1] ;
         T006L60_A85ParDActItem = new int[1] ;
         T006L61_A83ParTip = new string[] {""} ;
         T006L61_A84ParCod = new int[1] ;
         T006L61_A85ParDActItem = new int[1] ;
         T006L62_A79COSCod = new string[] {""} ;
         T006L63_A76CConpCod = new int[1] ;
         T006L64_A28ProdCod = new string[] {""} ;
         T006L65_A28ProdCod = new string[] {""} ;
         T006L66_A28ProdCod = new string[] {""} ;
         T006L67_A91CueCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T006L68_A70TipACod = new int[1] ;
         T006L68_n70TipACod = new bool[] {false} ;
         T006L69_A109CueGasDebe = new string[] {""} ;
         T006L69_n109CueGasDebe = new bool[] {false} ;
         T006L70_A110CueGasHaber = new string[] {""} ;
         T006L70_n110CueGasHaber = new bool[] {false} ;
         T006L71_A111CueMonDebe = new string[] {""} ;
         T006L71_n111CueMonDebe = new bool[] {false} ;
         T006L72_A112CueMonHaber = new string[] {""} ;
         T006L72_n112CueMonHaber = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentas__default(),
            new Object[][] {
                new Object[] {
               T006L2_A91CueCod, T006L2_A860CueDsc, T006L2_A857CueAbr, T006L2_n857CueAbr, T006L2_A867CueMov, T006L2_A864CueMon, T006L2_A859CueCos, T006L2_A873CueSts, T006L2_A868CueRef1, T006L2_A869CueRef2,
               T006L2_A870CueRef3, T006L2_A871CueRef4, T006L2_A2099CueBienes, T006L2_A872CueRef5, T006L2_A863CueGrupDoc, T006L2_A70TipACod, T006L2_n70TipACod, T006L2_A109CueGasDebe, T006L2_n109CueGasDebe, T006L2_A110CueGasHaber,
               T006L2_n110CueGasHaber, T006L2_A111CueMonDebe, T006L2_n111CueMonDebe, T006L2_A112CueMonHaber, T006L2_n112CueMonHaber, T006L2_A113CueCierre, T006L2_n113CueCierre
               }
               , new Object[] {
               T006L3_A91CueCod, T006L3_A860CueDsc, T006L3_A857CueAbr, T006L3_n857CueAbr, T006L3_A867CueMov, T006L3_A864CueMon, T006L3_A859CueCos, T006L3_A873CueSts, T006L3_A868CueRef1, T006L3_A869CueRef2,
               T006L3_A870CueRef3, T006L3_A871CueRef4, T006L3_A2099CueBienes, T006L3_A872CueRef5, T006L3_A863CueGrupDoc, T006L3_A70TipACod, T006L3_n70TipACod, T006L3_A109CueGasDebe, T006L3_n109CueGasDebe, T006L3_A110CueGasHaber,
               T006L3_n110CueGasHaber, T006L3_A111CueMonDebe, T006L3_n111CueMonDebe, T006L3_A112CueMonHaber, T006L3_n112CueMonHaber, T006L3_A113CueCierre, T006L3_n113CueCierre
               }
               , new Object[] {
               T006L4_A70TipACod
               }
               , new Object[] {
               T006L5_A109CueGasDebe
               }
               , new Object[] {
               T006L6_A110CueGasHaber
               }
               , new Object[] {
               T006L7_A111CueMonDebe
               }
               , new Object[] {
               T006L8_A112CueMonHaber
               }
               , new Object[] {
               T006L9_A858CueCierreDsc
               }
               , new Object[] {
               T006L10_A91CueCod, T006L10_A860CueDsc, T006L10_A857CueAbr, T006L10_n857CueAbr, T006L10_A867CueMov, T006L10_A864CueMon, T006L10_A859CueCos, T006L10_A873CueSts, T006L10_A868CueRef1, T006L10_A869CueRef2,
               T006L10_A870CueRef3, T006L10_A871CueRef4, T006L10_A2099CueBienes, T006L10_A872CueRef5, T006L10_A863CueGrupDoc, T006L10_A858CueCierreDsc, T006L10_A70TipACod, T006L10_n70TipACod, T006L10_A109CueGasDebe, T006L10_n109CueGasDebe,
               T006L10_A110CueGasHaber, T006L10_n110CueGasHaber, T006L10_A111CueMonDebe, T006L10_n111CueMonDebe, T006L10_A112CueMonHaber, T006L10_n112CueMonHaber, T006L10_A113CueCierre, T006L10_n113CueCierre
               }
               , new Object[] {
               T006L11_A109CueGasDebe
               }
               , new Object[] {
               T006L12_A110CueGasHaber
               }
               , new Object[] {
               T006L13_A111CueMonDebe
               }
               , new Object[] {
               T006L14_A112CueMonHaber
               }
               , new Object[] {
               T006L15_A70TipACod
               }
               , new Object[] {
               T006L16_A858CueCierreDsc
               }
               , new Object[] {
               T006L17_A91CueCod
               }
               , new Object[] {
               T006L18_A91CueCod
               }
               , new Object[] {
               T006L19_A91CueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006L23_A858CueCierreDsc
               }
               , new Object[] {
               T006L24_A113CueCierre
               }
               , new Object[] {
               T006L25_A112CueMonHaber
               }
               , new Object[] {
               T006L26_A111CueMonDebe
               }
               , new Object[] {
               T006L27_A110CueGasHaber
               }
               , new Object[] {
               T006L28_A109CueGasDebe
               }
               , new Object[] {
               T006L29_A365EntCod, T006L29_A403MVLEntCod, T006L29_A404MVLEITem
               }
               , new Object[] {
               T006L30_A358CajCod, T006L30_A391MVLCajCod, T006L30_A392MVLITem
               }
               , new Object[] {
               T006L31_A372BanCod, T006L31_A377CBCod
               }
               , new Object[] {
               T006L32_A355ConBCod
               }
               , new Object[] {
               T006L33_A332PSerConcCod, T006L33_A333PSerDConcCueCod
               }
               , new Object[] {
               T006L34_A313PoConcCod, T006L34_A315PoConcDCueCod
               }
               , new Object[] {
               T006L35_A149TipCod, T006L35_A243ComCod, T006L35_A244PrvCod, T006L35_A250ComDItem, T006L35_A251ComDOrdCod
               }
               , new Object[] {
               T006L36_A121SalVouAno, T006L36_A122SalVouMes, T006L36_A123SalCueCod, T006L36_A124SalMonCod, T006L36_A125SalCueAux
               }
               , new Object[] {
               T006L37_A83ParTip, T006L37_A84ParCod, T006L37_A104ParDItem
               }
               , new Object[] {
               T006L38_A83ParTip, T006L38_A84ParCod, T006L38_A104ParDItem
               }
               , new Object[] {
               T006L39_A83ParTip, T006L39_A84ParCod
               }
               , new Object[] {
               T006L40_A83ParTip, T006L40_A84ParCod
               }
               , new Object[] {
               T006L41_A83ParTip, T006L41_A84ParCod
               }
               , new Object[] {
               T006L42_A83ParTip, T006L42_A84ParCod
               }
               , new Object[] {
               T006L43_A83ParTip, T006L43_A84ParCod
               }
               , new Object[] {
               T006L44_A83ParTip, T006L44_A84ParCod
               }
               , new Object[] {
               T006L45_A83ParTip, T006L45_A84ParCod
               }
               , new Object[] {
               T006L46_A83ParTip, T006L46_A84ParCod
               }
               , new Object[] {
               T006L47_A83ParTip, T006L47_A84ParCod
               }
               , new Object[] {
               T006L48_A83ParTip, T006L48_A84ParCod
               }
               , new Object[] {
               T006L49_A2280CBTipPre, T006L49_A2281CBTipTipo, T006L49_A2282CBLinPre, T006L49_A2283CBRubPre, T006L49_A2284CBRubDItem
               }
               , new Object[] {
               T006L50_A83ParTip, T006L50_A84ParCod, T006L50_A90ParDTipItem
               }
               , new Object[] {
               T006L51_A365EntCod
               }
               , new Object[] {
               T006L52_A376ConEntCod
               }
               , new Object[] {
               T006L53_A375ConCajCod
               }
               , new Object[] {
               T006L54_A358CajCod
               }
               , new Object[] {
               T006L55_A236LiqPrvCod
               }
               , new Object[] {
               T006L56_A127VouAno, T006L56_A128VouMes, T006L56_A126TASICod, T006L56_A129VouNum, T006L56_A130VouDSec
               }
               , new Object[] {
               T006L57_A114TotTipo, T006L57_A115TotRub, T006L57_A116RubCod, T006L57_A118RubLinCod, T006L57_A91CueCod
               }
               , new Object[] {
               T006L58_A83ParTip, T006L58_A84ParCod, T006L58_A85ParDActItem
               }
               , new Object[] {
               T006L59_A83ParTip, T006L59_A84ParCod, T006L59_A85ParDActItem
               }
               , new Object[] {
               T006L60_A83ParTip, T006L60_A84ParCod, T006L60_A85ParDActItem
               }
               , new Object[] {
               T006L61_A83ParTip, T006L61_A84ParCod, T006L61_A85ParDActItem
               }
               , new Object[] {
               T006L62_A79COSCod
               }
               , new Object[] {
               T006L63_A76CConpCod
               }
               , new Object[] {
               T006L64_A28ProdCod
               }
               , new Object[] {
               T006L65_A28ProdCod
               }
               , new Object[] {
               T006L66_A28ProdCod
               }
               , new Object[] {
               T006L67_A91CueCod
               }
               , new Object[] {
               T006L68_A70TipACod
               }
               , new Object[] {
               T006L69_A109CueGasDebe
               }
               , new Object[] {
               T006L70_A110CueGasHaber
               }
               , new Object[] {
               T006L71_A111CueMonDebe
               }
               , new Object[] {
               T006L72_A112CueMonHaber
               }
            }
         );
         AV37Pgmname = "Contabilidad.PlanCuentas";
         Z873CueSts = 1;
         A873CueSts = 1;
         i873CueSts = 1;
      }

      private short Z867CueMov ;
      private short Z864CueMon ;
      private short Z859CueCos ;
      private short Z873CueSts ;
      private short Z868CueRef1 ;
      private short Z869CueRef2 ;
      private short Z870CueRef3 ;
      private short Z871CueRef4 ;
      private short Z872CueRef5 ;
      private short Z863CueGrupDoc ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A873CueSts ;
      private short A871CueRef4 ;
      private short A867CueMov ;
      private short A864CueMon ;
      private short A859CueCos ;
      private short A868CueRef1 ;
      private short A869CueRef2 ;
      private short A870CueRef3 ;
      private short A872CueRef5 ;
      private short A863CueGrupDoc ;
      private short Gx_BScreen ;
      private short RcdFound64 ;
      private short GX_JID ;
      private short nIsDirty_64 ;
      private short gxajaxcallmode ;
      private short i873CueSts ;
      private int Z2099CueBienes ;
      private int Z70TipACod ;
      private int N70TipACod ;
      private int A70TipACod ;
      private int trnEnded ;
      private int A2099CueBienes ;
      private int edtCueCod_Enabled ;
      private int edtCueDsc_Enabled ;
      private int edtTipACod_Visible ;
      private int edtTipACod_Enabled ;
      private int edtCueMov_Enabled ;
      private int edtCueMon_Enabled ;
      private int edtCueCos_Enabled ;
      private int edtCueRef1_Enabled ;
      private int edtCueRef2_Enabled ;
      private int edtCueRef3_Enabled ;
      private int edtCueRef5_Enabled ;
      private int edtCueGasDebe_Visible ;
      private int edtCueGasDebe_Enabled ;
      private int edtCueGasHaber_Visible ;
      private int edtCueGasHaber_Enabled ;
      private int edtCueMonDebe_Visible ;
      private int edtCueMonDebe_Enabled ;
      private int edtCueMonHaber_Visible ;
      private int edtCueMonHaber_Enabled ;
      private int edtCueCierre_Visible ;
      private int edtCueCierre_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV31ComboTipACod ;
      private int edtavCombotipacod_Enabled ;
      private int edtavCombotipacod_Visible ;
      private int edtavCombocuegasdebe_Visible ;
      private int edtavCombocuegasdebe_Enabled ;
      private int edtavCombocuegashaber_Visible ;
      private int edtavCombocuegashaber_Enabled ;
      private int edtavCombocuemondebe_Visible ;
      private int edtavCombocuemondebe_Enabled ;
      private int edtavCombocuemonhaber_Visible ;
      private int edtavCombocuemonhaber_Enabled ;
      private int edtavCombocuecierre_Visible ;
      private int edtavCombocuecierre_Enabled ;
      private int AV15Insert_TipACod ;
      private int Combo_tipacod_Datalistupdateminimumcharacters ;
      private int Combo_tipacod_Gxcontroltype ;
      private int Combo_cuegasdebe_Datalistupdateminimumcharacters ;
      private int Combo_cuegasdebe_Gxcontroltype ;
      private int Combo_cuegashaber_Datalistupdateminimumcharacters ;
      private int Combo_cuegashaber_Gxcontroltype ;
      private int Combo_cuemondebe_Datalistupdateminimumcharacters ;
      private int Combo_cuemondebe_Gxcontroltype ;
      private int Combo_cuemonhaber_Datalistupdateminimumcharacters ;
      private int Combo_cuemonhaber_Gxcontroltype ;
      private int Combo_cuecierre_Datalistupdateminimumcharacters ;
      private int Combo_cuecierre_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV38GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7CueCod ;
      private string Z91CueCod ;
      private string Z860CueDsc ;
      private string Z857CueAbr ;
      private string Z109CueGasDebe ;
      private string Z110CueGasHaber ;
      private string Z111CueMonDebe ;
      private string Z112CueMonHaber ;
      private string Z113CueCierre ;
      private string N109CueGasDebe ;
      private string N110CueGasHaber ;
      private string N111CueMonDebe ;
      private string N112CueMonHaber ;
      private string N113CueCierre ;
      private string Combo_cuecierre_Selectedvalue_get ;
      private string Combo_cuemonhaber_Selectedvalue_get ;
      private string Combo_cuemondebe_Selectedvalue_get ;
      private string Combo_cuegashaber_Selectedvalue_get ;
      private string Combo_cuegasdebe_Selectedvalue_get ;
      private string Combo_tipacod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
      private string A111CueMonDebe ;
      private string A112CueMonHaber ;
      private string A113CueCierre ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7CueCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCueCod_Internalname ;
      private string cmbCueSts_Internalname ;
      private string cmbCueBienes_Internalname ;
      private string cmbCueRef4_Internalname ;
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
      private string A91CueCod ;
      private string edtCueCod_Jsonclick ;
      private string cmbCueSts_Jsonclick ;
      private string divUnnamedtablecuedsc_Internalname ;
      private string lblTextblockcuedsc_Internalname ;
      private string lblTextblockcuedsc_Jsonclick ;
      private string edtCueDsc_Internalname ;
      private string A860CueDsc ;
      private string edtCueDsc_Jsonclick ;
      private string divTablesplittedtipacod_Internalname ;
      private string lblTextblocktipacod_Internalname ;
      private string lblTextblocktipacod_Jsonclick ;
      private string Combo_tipacod_Caption ;
      private string Combo_tipacod_Cls ;
      private string Combo_tipacod_Datalistproc ;
      private string Combo_tipacod_Datalistprocparametersprefix ;
      private string Combo_tipacod_Internalname ;
      private string edtTipACod_Internalname ;
      private string edtTipACod_Jsonclick ;
      private string divUnnamedtablecuebienes_Internalname ;
      private string lblTextblockcuebienes_Internalname ;
      private string lblTextblockcuebienes_Jsonclick ;
      private string cmbCueBienes_Jsonclick ;
      private string edtCueMov_Internalname ;
      private string edtCueMov_Jsonclick ;
      private string edtCueMon_Internalname ;
      private string edtCueMon_Jsonclick ;
      private string edtCueCos_Internalname ;
      private string edtCueCos_Jsonclick ;
      private string cmbCueRef4_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divGrupo1_Internalname ;
      private string edtCueRef1_Internalname ;
      private string edtCueRef1_Jsonclick ;
      private string edtCueRef2_Internalname ;
      private string edtCueRef2_Jsonclick ;
      private string edtCueRef3_Internalname ;
      private string edtCueRef3_Jsonclick ;
      private string edtCueRef5_Internalname ;
      private string edtCueRef5_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTab2_Internalname ;
      private string divTablesplittedcuegasdebe_Internalname ;
      private string lblTextblockcuegasdebe_Internalname ;
      private string lblTextblockcuegasdebe_Jsonclick ;
      private string Combo_cuegasdebe_Caption ;
      private string Combo_cuegasdebe_Cls ;
      private string Combo_cuegasdebe_Internalname ;
      private string edtCueGasDebe_Internalname ;
      private string edtCueGasDebe_Jsonclick ;
      private string divTablesplittedcuegashaber_Internalname ;
      private string lblTextblockcuegashaber_Internalname ;
      private string lblTextblockcuegashaber_Jsonclick ;
      private string Combo_cuegashaber_Caption ;
      private string Combo_cuegashaber_Cls ;
      private string Combo_cuegashaber_Internalname ;
      private string edtCueGasHaber_Internalname ;
      private string edtCueGasHaber_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTab3_Internalname ;
      private string divTablesplittedcuemondebe_Internalname ;
      private string lblTextblockcuemondebe_Internalname ;
      private string lblTextblockcuemondebe_Jsonclick ;
      private string Combo_cuemondebe_Caption ;
      private string Combo_cuemondebe_Cls ;
      private string Combo_cuemondebe_Internalname ;
      private string edtCueMonDebe_Internalname ;
      private string edtCueMonDebe_Jsonclick ;
      private string divTablesplittedcuemonhaber_Internalname ;
      private string lblTextblockcuemonhaber_Internalname ;
      private string lblTextblockcuemonhaber_Jsonclick ;
      private string Combo_cuemonhaber_Caption ;
      private string Combo_cuemonhaber_Cls ;
      private string Combo_cuemonhaber_Internalname ;
      private string edtCueMonHaber_Internalname ;
      private string edtCueMonHaber_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divTab4_Internalname ;
      private string divTablesplittedcuecierre_Internalname ;
      private string lblTextblockcuecierre_Internalname ;
      private string lblTextblockcuecierre_Jsonclick ;
      private string Combo_cuecierre_Caption ;
      private string Combo_cuecierre_Cls ;
      private string Combo_cuecierre_Internalname ;
      private string edtCueCierre_Internalname ;
      private string edtCueCierre_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_tipacod_Internalname ;
      private string edtavCombotipacod_Internalname ;
      private string edtavCombotipacod_Jsonclick ;
      private string divSectionattribute_cuegasdebe_Internalname ;
      private string edtavCombocuegasdebe_Internalname ;
      private string AV23ComboCueGasDebe ;
      private string edtavCombocuegasdebe_Jsonclick ;
      private string divSectionattribute_cuegashaber_Internalname ;
      private string edtavCombocuegashaber_Internalname ;
      private string AV25ComboCueGasHaber ;
      private string edtavCombocuegashaber_Jsonclick ;
      private string divSectionattribute_cuemondebe_Internalname ;
      private string edtavCombocuemondebe_Internalname ;
      private string AV27ComboCueMonDebe ;
      private string edtavCombocuemondebe_Jsonclick ;
      private string divSectionattribute_cuemonhaber_Internalname ;
      private string edtavCombocuemonhaber_Internalname ;
      private string AV29ComboCueMonHaber ;
      private string edtavCombocuemonhaber_Jsonclick ;
      private string divSectionattribute_cuecierre_Internalname ;
      private string edtavCombocuecierre_Internalname ;
      private string AV33ComboCueCierre ;
      private string edtavCombocuecierre_Jsonclick ;
      private string A857CueAbr ;
      private string A2098CueDscCompleto ;
      private string AV11Insert_CueGasDebe ;
      private string AV12Insert_CueGasHaber ;
      private string AV13Insert_CueMonDebe ;
      private string AV14Insert_CueMonHaber ;
      private string AV16Insert_CueCierre ;
      private string A858CueCierreDsc ;
      private string AV37Pgmname ;
      private string Combo_tipacod_Objectcall ;
      private string Combo_tipacod_Class ;
      private string Combo_tipacod_Icontype ;
      private string Combo_tipacod_Icon ;
      private string Combo_tipacod_Tooltip ;
      private string Combo_tipacod_Selectedvalue_set ;
      private string Combo_tipacod_Selectedtext_set ;
      private string Combo_tipacod_Selectedtext_get ;
      private string Combo_tipacod_Gamoauthtoken ;
      private string Combo_tipacod_Ddointernalname ;
      private string Combo_tipacod_Titlecontrolalign ;
      private string Combo_tipacod_Dropdownoptionstype ;
      private string Combo_tipacod_Titlecontrolidtoreplace ;
      private string Combo_tipacod_Datalisttype ;
      private string Combo_tipacod_Datalistfixedvalues ;
      private string Combo_tipacod_Htmltemplate ;
      private string Combo_tipacod_Multiplevaluestype ;
      private string Combo_tipacod_Loadingdata ;
      private string Combo_tipacod_Noresultsfound ;
      private string Combo_tipacod_Emptyitemtext ;
      private string Combo_tipacod_Onlyselectedvalues ;
      private string Combo_tipacod_Selectalltext ;
      private string Combo_tipacod_Multiplevaluesseparator ;
      private string Combo_tipacod_Addnewoptiontext ;
      private string Combo_cuegasdebe_Objectcall ;
      private string Combo_cuegasdebe_Class ;
      private string Combo_cuegasdebe_Icontype ;
      private string Combo_cuegasdebe_Icon ;
      private string Combo_cuegasdebe_Tooltip ;
      private string Combo_cuegasdebe_Selectedvalue_set ;
      private string Combo_cuegasdebe_Selectedtext_set ;
      private string Combo_cuegasdebe_Selectedtext_get ;
      private string Combo_cuegasdebe_Gamoauthtoken ;
      private string Combo_cuegasdebe_Ddointernalname ;
      private string Combo_cuegasdebe_Titlecontrolalign ;
      private string Combo_cuegasdebe_Dropdownoptionstype ;
      private string Combo_cuegasdebe_Titlecontrolidtoreplace ;
      private string Combo_cuegasdebe_Datalisttype ;
      private string Combo_cuegasdebe_Datalistfixedvalues ;
      private string Combo_cuegasdebe_Datalistproc ;
      private string Combo_cuegasdebe_Datalistprocparametersprefix ;
      private string Combo_cuegasdebe_Htmltemplate ;
      private string Combo_cuegasdebe_Multiplevaluestype ;
      private string Combo_cuegasdebe_Loadingdata ;
      private string Combo_cuegasdebe_Noresultsfound ;
      private string Combo_cuegasdebe_Emptyitemtext ;
      private string Combo_cuegasdebe_Onlyselectedvalues ;
      private string Combo_cuegasdebe_Selectalltext ;
      private string Combo_cuegasdebe_Multiplevaluesseparator ;
      private string Combo_cuegasdebe_Addnewoptiontext ;
      private string Combo_cuegashaber_Objectcall ;
      private string Combo_cuegashaber_Class ;
      private string Combo_cuegashaber_Icontype ;
      private string Combo_cuegashaber_Icon ;
      private string Combo_cuegashaber_Tooltip ;
      private string Combo_cuegashaber_Selectedvalue_set ;
      private string Combo_cuegashaber_Selectedtext_set ;
      private string Combo_cuegashaber_Selectedtext_get ;
      private string Combo_cuegashaber_Gamoauthtoken ;
      private string Combo_cuegashaber_Ddointernalname ;
      private string Combo_cuegashaber_Titlecontrolalign ;
      private string Combo_cuegashaber_Dropdownoptionstype ;
      private string Combo_cuegashaber_Titlecontrolidtoreplace ;
      private string Combo_cuegashaber_Datalisttype ;
      private string Combo_cuegashaber_Datalistfixedvalues ;
      private string Combo_cuegashaber_Datalistproc ;
      private string Combo_cuegashaber_Datalistprocparametersprefix ;
      private string Combo_cuegashaber_Htmltemplate ;
      private string Combo_cuegashaber_Multiplevaluestype ;
      private string Combo_cuegashaber_Loadingdata ;
      private string Combo_cuegashaber_Noresultsfound ;
      private string Combo_cuegashaber_Emptyitemtext ;
      private string Combo_cuegashaber_Onlyselectedvalues ;
      private string Combo_cuegashaber_Selectalltext ;
      private string Combo_cuegashaber_Multiplevaluesseparator ;
      private string Combo_cuegashaber_Addnewoptiontext ;
      private string Combo_cuemondebe_Objectcall ;
      private string Combo_cuemondebe_Class ;
      private string Combo_cuemondebe_Icontype ;
      private string Combo_cuemondebe_Icon ;
      private string Combo_cuemondebe_Tooltip ;
      private string Combo_cuemondebe_Selectedvalue_set ;
      private string Combo_cuemondebe_Selectedtext_set ;
      private string Combo_cuemondebe_Selectedtext_get ;
      private string Combo_cuemondebe_Gamoauthtoken ;
      private string Combo_cuemondebe_Ddointernalname ;
      private string Combo_cuemondebe_Titlecontrolalign ;
      private string Combo_cuemondebe_Dropdownoptionstype ;
      private string Combo_cuemondebe_Titlecontrolidtoreplace ;
      private string Combo_cuemondebe_Datalisttype ;
      private string Combo_cuemondebe_Datalistfixedvalues ;
      private string Combo_cuemondebe_Datalistproc ;
      private string Combo_cuemondebe_Datalistprocparametersprefix ;
      private string Combo_cuemondebe_Htmltemplate ;
      private string Combo_cuemondebe_Multiplevaluestype ;
      private string Combo_cuemondebe_Loadingdata ;
      private string Combo_cuemondebe_Noresultsfound ;
      private string Combo_cuemondebe_Emptyitemtext ;
      private string Combo_cuemondebe_Onlyselectedvalues ;
      private string Combo_cuemondebe_Selectalltext ;
      private string Combo_cuemondebe_Multiplevaluesseparator ;
      private string Combo_cuemondebe_Addnewoptiontext ;
      private string Combo_cuemonhaber_Objectcall ;
      private string Combo_cuemonhaber_Class ;
      private string Combo_cuemonhaber_Icontype ;
      private string Combo_cuemonhaber_Icon ;
      private string Combo_cuemonhaber_Tooltip ;
      private string Combo_cuemonhaber_Selectedvalue_set ;
      private string Combo_cuemonhaber_Selectedtext_set ;
      private string Combo_cuemonhaber_Selectedtext_get ;
      private string Combo_cuemonhaber_Gamoauthtoken ;
      private string Combo_cuemonhaber_Ddointernalname ;
      private string Combo_cuemonhaber_Titlecontrolalign ;
      private string Combo_cuemonhaber_Dropdownoptionstype ;
      private string Combo_cuemonhaber_Titlecontrolidtoreplace ;
      private string Combo_cuemonhaber_Datalisttype ;
      private string Combo_cuemonhaber_Datalistfixedvalues ;
      private string Combo_cuemonhaber_Datalistproc ;
      private string Combo_cuemonhaber_Datalistprocparametersprefix ;
      private string Combo_cuemonhaber_Htmltemplate ;
      private string Combo_cuemonhaber_Multiplevaluestype ;
      private string Combo_cuemonhaber_Loadingdata ;
      private string Combo_cuemonhaber_Noresultsfound ;
      private string Combo_cuemonhaber_Emptyitemtext ;
      private string Combo_cuemonhaber_Onlyselectedvalues ;
      private string Combo_cuemonhaber_Selectalltext ;
      private string Combo_cuemonhaber_Multiplevaluesseparator ;
      private string Combo_cuemonhaber_Addnewoptiontext ;
      private string Combo_cuecierre_Objectcall ;
      private string Combo_cuecierre_Class ;
      private string Combo_cuecierre_Icontype ;
      private string Combo_cuecierre_Icon ;
      private string Combo_cuecierre_Tooltip ;
      private string Combo_cuecierre_Selectedvalue_set ;
      private string Combo_cuecierre_Selectedtext_set ;
      private string Combo_cuecierre_Selectedtext_get ;
      private string Combo_cuecierre_Gamoauthtoken ;
      private string Combo_cuecierre_Ddointernalname ;
      private string Combo_cuecierre_Titlecontrolalign ;
      private string Combo_cuecierre_Dropdownoptionstype ;
      private string Combo_cuecierre_Titlecontrolidtoreplace ;
      private string Combo_cuecierre_Datalisttype ;
      private string Combo_cuecierre_Datalistfixedvalues ;
      private string Combo_cuecierre_Datalistproc ;
      private string Combo_cuecierre_Datalistprocparametersprefix ;
      private string Combo_cuecierre_Htmltemplate ;
      private string Combo_cuecierre_Multiplevaluestype ;
      private string Combo_cuecierre_Loadingdata ;
      private string Combo_cuecierre_Noresultsfound ;
      private string Combo_cuecierre_Emptyitemtext ;
      private string Combo_cuecierre_Onlyselectedvalues ;
      private string Combo_cuecierre_Selectalltext ;
      private string Combo_cuecierre_Multiplevaluesseparator ;
      private string Combo_cuecierre_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode64 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string Z858CueCierreDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n109CueGasDebe ;
      private bool n110CueGasHaber ;
      private bool n111CueMonDebe ;
      private bool n112CueMonHaber ;
      private bool n70TipACod ;
      private bool n113CueCierre ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n857CueAbr ;
      private bool Combo_tipacod_Enabled ;
      private bool Combo_tipacod_Visible ;
      private bool Combo_tipacod_Allowmultipleselection ;
      private bool Combo_tipacod_Isgriditem ;
      private bool Combo_tipacod_Hasdescription ;
      private bool Combo_tipacod_Includeonlyselectedoption ;
      private bool Combo_tipacod_Includeselectalloption ;
      private bool Combo_tipacod_Emptyitem ;
      private bool Combo_tipacod_Includeaddnewoption ;
      private bool Combo_cuegasdebe_Enabled ;
      private bool Combo_cuegasdebe_Visible ;
      private bool Combo_cuegasdebe_Allowmultipleselection ;
      private bool Combo_cuegasdebe_Isgriditem ;
      private bool Combo_cuegasdebe_Hasdescription ;
      private bool Combo_cuegasdebe_Includeonlyselectedoption ;
      private bool Combo_cuegasdebe_Includeselectalloption ;
      private bool Combo_cuegasdebe_Emptyitem ;
      private bool Combo_cuegasdebe_Includeaddnewoption ;
      private bool Combo_cuegashaber_Enabled ;
      private bool Combo_cuegashaber_Visible ;
      private bool Combo_cuegashaber_Allowmultipleselection ;
      private bool Combo_cuegashaber_Isgriditem ;
      private bool Combo_cuegashaber_Hasdescription ;
      private bool Combo_cuegashaber_Includeonlyselectedoption ;
      private bool Combo_cuegashaber_Includeselectalloption ;
      private bool Combo_cuegashaber_Emptyitem ;
      private bool Combo_cuegashaber_Includeaddnewoption ;
      private bool Combo_cuemondebe_Enabled ;
      private bool Combo_cuemondebe_Visible ;
      private bool Combo_cuemondebe_Allowmultipleselection ;
      private bool Combo_cuemondebe_Isgriditem ;
      private bool Combo_cuemondebe_Hasdescription ;
      private bool Combo_cuemondebe_Includeonlyselectedoption ;
      private bool Combo_cuemondebe_Includeselectalloption ;
      private bool Combo_cuemondebe_Emptyitem ;
      private bool Combo_cuemondebe_Includeaddnewoption ;
      private bool Combo_cuemonhaber_Enabled ;
      private bool Combo_cuemonhaber_Visible ;
      private bool Combo_cuemonhaber_Allowmultipleselection ;
      private bool Combo_cuemonhaber_Isgriditem ;
      private bool Combo_cuemonhaber_Hasdescription ;
      private bool Combo_cuemonhaber_Includeonlyselectedoption ;
      private bool Combo_cuemonhaber_Includeselectalloption ;
      private bool Combo_cuemonhaber_Emptyitem ;
      private bool Combo_cuemonhaber_Includeaddnewoption ;
      private bool Combo_cuecierre_Enabled ;
      private bool Combo_cuecierre_Visible ;
      private bool Combo_cuecierre_Allowmultipleselection ;
      private bool Combo_cuecierre_Isgriditem ;
      private bool Combo_cuecierre_Hasdescription ;
      private bool Combo_cuecierre_Includeonlyselectedoption ;
      private bool Combo_cuecierre_Includeselectalloption ;
      private bool Combo_cuecierre_Emptyitem ;
      private bool Combo_cuecierre_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV22Combo_DataJson ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string AV34SGAuDocGls ;
      private string AV35Codigo ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tipacod ;
      private GXUserControl ucCombo_cuegasdebe ;
      private GXUserControl ucCombo_cuegashaber ;
      private GXUserControl ucCombo_cuemondebe ;
      private GXUserControl ucCombo_cuemonhaber ;
      private GXUserControl ucCombo_cuecierre ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCueSts ;
      private GXCombobox cmbCueBienes ;
      private GXCombobox cmbCueRef4 ;
      private IDataStoreProvider pr_default ;
      private string[] T006L9_A858CueCierreDsc ;
      private string[] T006L10_A91CueCod ;
      private string[] T006L10_A860CueDsc ;
      private string[] T006L10_A857CueAbr ;
      private bool[] T006L10_n857CueAbr ;
      private short[] T006L10_A867CueMov ;
      private short[] T006L10_A864CueMon ;
      private short[] T006L10_A859CueCos ;
      private short[] T006L10_A873CueSts ;
      private short[] T006L10_A868CueRef1 ;
      private short[] T006L10_A869CueRef2 ;
      private short[] T006L10_A870CueRef3 ;
      private short[] T006L10_A871CueRef4 ;
      private int[] T006L10_A2099CueBienes ;
      private short[] T006L10_A872CueRef5 ;
      private short[] T006L10_A863CueGrupDoc ;
      private string[] T006L10_A858CueCierreDsc ;
      private int[] T006L10_A70TipACod ;
      private bool[] T006L10_n70TipACod ;
      private string[] T006L10_A109CueGasDebe ;
      private bool[] T006L10_n109CueGasDebe ;
      private string[] T006L10_A110CueGasHaber ;
      private bool[] T006L10_n110CueGasHaber ;
      private string[] T006L10_A111CueMonDebe ;
      private bool[] T006L10_n111CueMonDebe ;
      private string[] T006L10_A112CueMonHaber ;
      private bool[] T006L10_n112CueMonHaber ;
      private string[] T006L10_A113CueCierre ;
      private bool[] T006L10_n113CueCierre ;
      private string[] T006L5_A109CueGasDebe ;
      private bool[] T006L5_n109CueGasDebe ;
      private string[] T006L6_A110CueGasHaber ;
      private bool[] T006L6_n110CueGasHaber ;
      private string[] T006L7_A111CueMonDebe ;
      private bool[] T006L7_n111CueMonDebe ;
      private string[] T006L8_A112CueMonHaber ;
      private bool[] T006L8_n112CueMonHaber ;
      private int[] T006L4_A70TipACod ;
      private bool[] T006L4_n70TipACod ;
      private string[] T006L11_A109CueGasDebe ;
      private bool[] T006L11_n109CueGasDebe ;
      private string[] T006L12_A110CueGasHaber ;
      private bool[] T006L12_n110CueGasHaber ;
      private string[] T006L13_A111CueMonDebe ;
      private bool[] T006L13_n111CueMonDebe ;
      private string[] T006L14_A112CueMonHaber ;
      private bool[] T006L14_n112CueMonHaber ;
      private int[] T006L15_A70TipACod ;
      private bool[] T006L15_n70TipACod ;
      private string[] T006L16_A858CueCierreDsc ;
      private string[] T006L17_A91CueCod ;
      private string[] T006L3_A91CueCod ;
      private string[] T006L3_A860CueDsc ;
      private string[] T006L3_A857CueAbr ;
      private bool[] T006L3_n857CueAbr ;
      private short[] T006L3_A867CueMov ;
      private short[] T006L3_A864CueMon ;
      private short[] T006L3_A859CueCos ;
      private short[] T006L3_A873CueSts ;
      private short[] T006L3_A868CueRef1 ;
      private short[] T006L3_A869CueRef2 ;
      private short[] T006L3_A870CueRef3 ;
      private short[] T006L3_A871CueRef4 ;
      private int[] T006L3_A2099CueBienes ;
      private short[] T006L3_A872CueRef5 ;
      private short[] T006L3_A863CueGrupDoc ;
      private int[] T006L3_A70TipACod ;
      private bool[] T006L3_n70TipACod ;
      private string[] T006L3_A109CueGasDebe ;
      private bool[] T006L3_n109CueGasDebe ;
      private string[] T006L3_A110CueGasHaber ;
      private bool[] T006L3_n110CueGasHaber ;
      private string[] T006L3_A111CueMonDebe ;
      private bool[] T006L3_n111CueMonDebe ;
      private string[] T006L3_A112CueMonHaber ;
      private bool[] T006L3_n112CueMonHaber ;
      private string[] T006L3_A113CueCierre ;
      private bool[] T006L3_n113CueCierre ;
      private string[] T006L18_A91CueCod ;
      private string[] T006L19_A91CueCod ;
      private string[] T006L2_A91CueCod ;
      private string[] T006L2_A860CueDsc ;
      private string[] T006L2_A857CueAbr ;
      private bool[] T006L2_n857CueAbr ;
      private short[] T006L2_A867CueMov ;
      private short[] T006L2_A864CueMon ;
      private short[] T006L2_A859CueCos ;
      private short[] T006L2_A873CueSts ;
      private short[] T006L2_A868CueRef1 ;
      private short[] T006L2_A869CueRef2 ;
      private short[] T006L2_A870CueRef3 ;
      private short[] T006L2_A871CueRef4 ;
      private int[] T006L2_A2099CueBienes ;
      private short[] T006L2_A872CueRef5 ;
      private short[] T006L2_A863CueGrupDoc ;
      private int[] T006L2_A70TipACod ;
      private bool[] T006L2_n70TipACod ;
      private string[] T006L2_A109CueGasDebe ;
      private bool[] T006L2_n109CueGasDebe ;
      private string[] T006L2_A110CueGasHaber ;
      private bool[] T006L2_n110CueGasHaber ;
      private string[] T006L2_A111CueMonDebe ;
      private bool[] T006L2_n111CueMonDebe ;
      private string[] T006L2_A112CueMonHaber ;
      private bool[] T006L2_n112CueMonHaber ;
      private string[] T006L2_A113CueCierre ;
      private bool[] T006L2_n113CueCierre ;
      private string[] T006L23_A858CueCierreDsc ;
      private string[] T006L24_A113CueCierre ;
      private bool[] T006L24_n113CueCierre ;
      private string[] T006L25_A112CueMonHaber ;
      private bool[] T006L25_n112CueMonHaber ;
      private string[] T006L26_A111CueMonDebe ;
      private bool[] T006L26_n111CueMonDebe ;
      private string[] T006L27_A110CueGasHaber ;
      private bool[] T006L27_n110CueGasHaber ;
      private string[] T006L28_A109CueGasDebe ;
      private bool[] T006L28_n109CueGasDebe ;
      private int[] T006L29_A365EntCod ;
      private string[] T006L29_A403MVLEntCod ;
      private int[] T006L29_A404MVLEITem ;
      private int[] T006L30_A358CajCod ;
      private string[] T006L30_A391MVLCajCod ;
      private int[] T006L30_A392MVLITem ;
      private int[] T006L31_A372BanCod ;
      private string[] T006L31_A377CBCod ;
      private int[] T006L32_A355ConBCod ;
      private int[] T006L33_A332PSerConcCod ;
      private string[] T006L33_A333PSerDConcCueCod ;
      private int[] T006L34_A313PoConcCod ;
      private string[] T006L34_A315PoConcDCueCod ;
      private string[] T006L35_A149TipCod ;
      private string[] T006L35_A243ComCod ;
      private string[] T006L35_A244PrvCod ;
      private short[] T006L35_A250ComDItem ;
      private string[] T006L35_A251ComDOrdCod ;
      private short[] T006L36_A121SalVouAno ;
      private short[] T006L36_A122SalVouMes ;
      private string[] T006L36_A123SalCueCod ;
      private int[] T006L36_A124SalMonCod ;
      private string[] T006L36_A125SalCueAux ;
      private string[] T006L37_A83ParTip ;
      private int[] T006L37_A84ParCod ;
      private short[] T006L37_A104ParDItem ;
      private string[] T006L38_A83ParTip ;
      private int[] T006L38_A84ParCod ;
      private short[] T006L38_A104ParDItem ;
      private string[] T006L39_A83ParTip ;
      private int[] T006L39_A84ParCod ;
      private string[] T006L40_A83ParTip ;
      private int[] T006L40_A84ParCod ;
      private string[] T006L41_A83ParTip ;
      private int[] T006L41_A84ParCod ;
      private string[] T006L42_A83ParTip ;
      private int[] T006L42_A84ParCod ;
      private string[] T006L43_A83ParTip ;
      private int[] T006L43_A84ParCod ;
      private string[] T006L44_A83ParTip ;
      private int[] T006L44_A84ParCod ;
      private string[] T006L45_A83ParTip ;
      private int[] T006L45_A84ParCod ;
      private string[] T006L46_A83ParTip ;
      private int[] T006L46_A84ParCod ;
      private string[] T006L47_A83ParTip ;
      private int[] T006L47_A84ParCod ;
      private string[] T006L48_A83ParTip ;
      private int[] T006L48_A84ParCod ;
      private int[] T006L49_A2280CBTipPre ;
      private string[] T006L49_A2281CBTipTipo ;
      private int[] T006L49_A2282CBLinPre ;
      private int[] T006L49_A2283CBRubPre ;
      private int[] T006L49_A2284CBRubDItem ;
      private string[] T006L50_A83ParTip ;
      private int[] T006L50_A84ParCod ;
      private int[] T006L50_A90ParDTipItem ;
      private int[] T006L51_A365EntCod ;
      private int[] T006L52_A376ConEntCod ;
      private int[] T006L53_A375ConCajCod ;
      private int[] T006L54_A358CajCod ;
      private string[] T006L55_A236LiqPrvCod ;
      private short[] T006L56_A127VouAno ;
      private short[] T006L56_A128VouMes ;
      private int[] T006L56_A126TASICod ;
      private string[] T006L56_A129VouNum ;
      private int[] T006L56_A130VouDSec ;
      private string[] T006L57_A114TotTipo ;
      private int[] T006L57_A115TotRub ;
      private int[] T006L57_A116RubCod ;
      private int[] T006L57_A118RubLinCod ;
      private string[] T006L57_A91CueCod ;
      private string[] T006L58_A83ParTip ;
      private int[] T006L58_A84ParCod ;
      private int[] T006L58_A85ParDActItem ;
      private string[] T006L59_A83ParTip ;
      private int[] T006L59_A84ParCod ;
      private int[] T006L59_A85ParDActItem ;
      private string[] T006L60_A83ParTip ;
      private int[] T006L60_A84ParCod ;
      private int[] T006L60_A85ParDActItem ;
      private string[] T006L61_A83ParTip ;
      private int[] T006L61_A84ParCod ;
      private int[] T006L61_A85ParDActItem ;
      private string[] T006L62_A79COSCod ;
      private int[] T006L63_A76CConpCod ;
      private string[] T006L64_A28ProdCod ;
      private string[] T006L65_A28ProdCod ;
      private string[] T006L66_A28ProdCod ;
      private string[] T006L67_A91CueCod ;
      private int[] T006L68_A70TipACod ;
      private bool[] T006L68_n70TipACod ;
      private string[] T006L69_A109CueGasDebe ;
      private bool[] T006L69_n109CueGasDebe ;
      private string[] T006L70_A110CueGasHaber ;
      private bool[] T006L70_n110CueGasHaber ;
      private string[] T006L71_A111CueMonDebe ;
      private bool[] T006L71_n111CueMonDebe ;
      private string[] T006L72_A112CueMonHaber ;
      private bool[] T006L72_n112CueMonHaber ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30TipACod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18CueGasDebe_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24CueGasHaber_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV26CueMonDebe_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV28CueMonHaber_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32CueCierre_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class plancuentas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class plancuentas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
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
        Object[] prmT006L10;
        prmT006L10 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L5;
        prmT006L5 = new Object[] {
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L6;
        prmT006L6 = new Object[] {
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L7;
        prmT006L7 = new Object[] {
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L8;
        prmT006L8 = new Object[] {
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L4;
        prmT006L4 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006L9;
        prmT006L9 = new Object[] {
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L11;
        prmT006L11 = new Object[] {
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L12;
        prmT006L12 = new Object[] {
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L13;
        prmT006L13 = new Object[] {
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L14;
        prmT006L14 = new Object[] {
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L15;
        prmT006L15 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006L16;
        prmT006L16 = new Object[] {
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L17;
        prmT006L17 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L3;
        prmT006L3 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L18;
        prmT006L18 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L19;
        prmT006L19 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L2;
        prmT006L2 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L20;
        prmT006L20 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@CueDsc",GXType.NChar,100,0) ,
        new ParDef("@CueAbr",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CueMov",GXType.Int16,1,0) ,
        new ParDef("@CueMon",GXType.Int16,1,0) ,
        new ParDef("@CueCos",GXType.Int16,1,0) ,
        new ParDef("@CueSts",GXType.Int16,1,0) ,
        new ParDef("@CueRef1",GXType.Int16,1,0) ,
        new ParDef("@CueRef2",GXType.Int16,1,0) ,
        new ParDef("@CueRef3",GXType.Int16,1,0) ,
        new ParDef("@CueRef4",GXType.Int16,1,0) ,
        new ParDef("@CueBienes",GXType.Int32,6,0) ,
        new ParDef("@CueRef5",GXType.Int16,1,0) ,
        new ParDef("@CueGrupDoc",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L21;
        prmT006L21 = new Object[] {
        new ParDef("@CueDsc",GXType.NChar,100,0) ,
        new ParDef("@CueAbr",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CueMov",GXType.Int16,1,0) ,
        new ParDef("@CueMon",GXType.Int16,1,0) ,
        new ParDef("@CueCos",GXType.Int16,1,0) ,
        new ParDef("@CueSts",GXType.Int16,1,0) ,
        new ParDef("@CueRef1",GXType.Int16,1,0) ,
        new ParDef("@CueRef2",GXType.Int16,1,0) ,
        new ParDef("@CueRef3",GXType.Int16,1,0) ,
        new ParDef("@CueRef4",GXType.Int16,1,0) ,
        new ParDef("@CueBienes",GXType.Int32,6,0) ,
        new ParDef("@CueRef5",GXType.Int16,1,0) ,
        new ParDef("@CueGrupDoc",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L22;
        prmT006L22 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L24;
        prmT006L24 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L25;
        prmT006L25 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L26;
        prmT006L26 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L27;
        prmT006L27 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L28;
        prmT006L28 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L29;
        prmT006L29 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L30;
        prmT006L30 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L31;
        prmT006L31 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L32;
        prmT006L32 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L33;
        prmT006L33 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L34;
        prmT006L34 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L35;
        prmT006L35 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L36;
        prmT006L36 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L37;
        prmT006L37 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L38;
        prmT006L38 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L39;
        prmT006L39 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L40;
        prmT006L40 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L41;
        prmT006L41 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L42;
        prmT006L42 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L43;
        prmT006L43 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L44;
        prmT006L44 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L45;
        prmT006L45 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L46;
        prmT006L46 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L47;
        prmT006L47 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L48;
        prmT006L48 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L49;
        prmT006L49 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L50;
        prmT006L50 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L51;
        prmT006L51 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L52;
        prmT006L52 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L53;
        prmT006L53 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L54;
        prmT006L54 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L55;
        prmT006L55 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L56;
        prmT006L56 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L57;
        prmT006L57 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L58;
        prmT006L58 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L59;
        prmT006L59 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L60;
        prmT006L60 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L61;
        prmT006L61 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L62;
        prmT006L62 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L63;
        prmT006L63 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L64;
        prmT006L64 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L65;
        prmT006L65 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L66;
        prmT006L66 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT006L67;
        prmT006L67 = new Object[] {
        };
        Object[] prmT006L68;
        prmT006L68 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006L69;
        prmT006L69 = new Object[] {
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L70;
        prmT006L70 = new Object[] {
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L71;
        prmT006L71 = new Object[] {
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L72;
        prmT006L72 = new Object[] {
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT006L23;
        prmT006L23 = new Object[] {
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006L2", "SELECT [CueCod], [CueDsc], [CueAbr], [CueMov], [CueMon], [CueCos], [CueSts], [CueRef1], [CueRef2], [CueRef3], [CueRef4], [CueBienes], [CueRef5], [CueGrupDoc], [TipACod], [CueGasDebe] AS CueGasDebe, [CueGasHaber] AS CueGasHaber, [CueMonDebe] AS CueMonDebe, [CueMonHaber] AS CueMonHaber, [CueCierre] AS CueCierre FROM [CBPLANCUENTA] WITH (UPDLOCK) WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L3", "SELECT [CueCod], [CueDsc], [CueAbr], [CueMov], [CueMon], [CueCos], [CueSts], [CueRef1], [CueRef2], [CueRef3], [CueRef4], [CueBienes], [CueRef5], [CueGrupDoc], [TipACod], [CueGasDebe] AS CueGasDebe, [CueGasHaber] AS CueGasHaber, [CueMonDebe] AS CueMonDebe, [CueMonHaber] AS CueMonHaber, [CueCierre] AS CueCierre FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L4", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L5", "SELECT [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L6", "SELECT [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L7", "SELECT [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L8", "SELECT [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L9", "SELECT [CueDsc] AS CueCierreDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCierre ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L10", "SELECT TM1.[CueCod], TM1.[CueDsc], TM1.[CueAbr], TM1.[CueMov], TM1.[CueMon], TM1.[CueCos], TM1.[CueSts], TM1.[CueRef1], TM1.[CueRef2], TM1.[CueRef3], TM1.[CueRef4], TM1.[CueBienes], TM1.[CueRef5], TM1.[CueGrupDoc], T2.[CueDsc] AS CueCierreDsc, TM1.[TipACod], TM1.[CueGasDebe] AS CueGasDebe, TM1.[CueGasHaber] AS CueGasHaber, TM1.[CueMonDebe] AS CueMonDebe, TM1.[CueMonHaber] AS CueMonHaber, TM1.[CueCierre] AS CueCierre FROM ([CBPLANCUENTA] TM1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CueCierre]) WHERE TM1.[CueCod] = @CueCod ORDER BY TM1.[CueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006L10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L11", "SELECT [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L12", "SELECT [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L13", "SELECT [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L14", "SELECT [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L15", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L16", "SELECT [CueDsc] AS CueCierreDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCierre ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L17", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006L17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L18", "SELECT TOP 1 [CueCod] FROM [CBPLANCUENTA] WHERE ( [CueCod] > @CueCod) ORDER BY [CueCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006L18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L19", "SELECT TOP 1 [CueCod] FROM [CBPLANCUENTA] WHERE ( [CueCod] < @CueCod) ORDER BY [CueCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006L19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L20", "INSERT INTO [CBPLANCUENTA]([CueCod], [CueDsc], [CueAbr], [CueMov], [CueMon], [CueCos], [CueSts], [CueRef1], [CueRef2], [CueRef3], [CueRef4], [CueBienes], [CueRef5], [CueGrupDoc], [TipACod], [CueGasDebe], [CueGasHaber], [CueMonDebe], [CueMonHaber], [CueCierre]) VALUES(@CueCod, @CueDsc, @CueAbr, @CueMov, @CueMon, @CueCos, @CueSts, @CueRef1, @CueRef2, @CueRef3, @CueRef4, @CueBienes, @CueRef5, @CueGrupDoc, @TipACod, @CueGasDebe, @CueGasHaber, @CueMonDebe, @CueMonHaber, @CueCierre)", GxErrorMask.GX_NOMASK,prmT006L20)
           ,new CursorDef("T006L21", "UPDATE [CBPLANCUENTA] SET [CueDsc]=@CueDsc, [CueAbr]=@CueAbr, [CueMov]=@CueMov, [CueMon]=@CueMon, [CueCos]=@CueCos, [CueSts]=@CueSts, [CueRef1]=@CueRef1, [CueRef2]=@CueRef2, [CueRef3]=@CueRef3, [CueRef4]=@CueRef4, [CueBienes]=@CueBienes, [CueRef5]=@CueRef5, [CueGrupDoc]=@CueGrupDoc, [TipACod]=@TipACod, [CueGasDebe]=@CueGasDebe, [CueGasHaber]=@CueGasHaber, [CueMonDebe]=@CueMonDebe, [CueMonHaber]=@CueMonHaber, [CueCierre]=@CueCierre  WHERE [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT006L21)
           ,new CursorDef("T006L22", "DELETE FROM [CBPLANCUENTA]  WHERE [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT006L22)
           ,new CursorDef("T006L23", "SELECT [CueDsc] AS CueCierreDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCierre ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L24", "SELECT TOP 1 [CueCod] AS CueCierre FROM [CBPLANCUENTA] WHERE [CueCierre] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L25", "SELECT TOP 1 [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueMonHaber] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L26", "SELECT TOP 1 [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueMonDebe] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L27", "SELECT TOP 1 [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueGasHaber] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L28", "SELECT TOP 1 [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueGasDebe] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L29", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLECueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L30", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L31", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [CBCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L32", "SELECT TOP 1 [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE [ConBCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L33", "SELECT TOP 1 [PSerConcCod], [PSerDConcCueCod] FROM [POSERCONCEPTOSDET] WHERE [PSerDConcCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L34", "SELECT TOP 1 [PoConcCod], [PoConcDCueCod] FROM [POCONCEPTOSDET] WHERE [PoConcDCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L35", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComDCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L36", "SELECT TOP 1 [SalVouAno], [SalVouMes], [SalCueCod], [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE [SalCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L37", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDCueCod1] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L38", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L39", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue10] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L40", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue9] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L41", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue8] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L41,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L42", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue7] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L42,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L43", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue6] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L44", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue5] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L44,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L45", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue4] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L45,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L46", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue3] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L46,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L47", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue2] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L47,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L48", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue1] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L48,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L49", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L49,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L50", "SELECT TOP 1 [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L50,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L51", "SELECT TOP 1 [EntCod] FROM [TSENTREGAS] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L51,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L52", "SELECT TOP 1 [ConEntCod] FROM [TSCONCEPTOENTREGA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L52,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L53", "SELECT TOP 1 [ConCajCod] FROM [TSCONCEPTOCAJA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L53,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L54", "SELECT TOP 1 [CajCod] FROM [TSCAJACHICA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L54,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L55", "SELECT TOP 1 [LiqPrvCod] FROM [CPAGENTES] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L55,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L56", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L56,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L57", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L57,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L58", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod4] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L58,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L59", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod3] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L59,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L60", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod2] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L60,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L61", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod1] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L61,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L62", "SELECT TOP 1 [COSCod] FROM [CBCOSTOS] WHERE [COSCueDestino] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L62,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L63", "SELECT TOP 1 [CConpCod] FROM [CBCOMPRASCONC] WHERE [CConpCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L63,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L64", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [ProdCuentaA] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L64,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L65", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [ProdCuentaC] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L65,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L66", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [ProdCuentaV] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L66,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006L67", "SELECT [CueCod] FROM [CBPLANCUENTA] ORDER BY [CueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006L67,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L68", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L68,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L69", "SELECT [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L69,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L70", "SELECT [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L70,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L71", "SELECT [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L71,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006L72", "SELECT [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT006L72,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((short[]) buf[14])[0] = rslt.getShort(14);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 15);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              ((string[]) buf[19])[0] = rslt.getString(17, 15);
              ((bool[]) buf[20])[0] = rslt.wasNull(17);
              ((string[]) buf[21])[0] = rslt.getString(18, 15);
              ((bool[]) buf[22])[0] = rslt.wasNull(18);
              ((string[]) buf[23])[0] = rslt.getString(19, 15);
              ((bool[]) buf[24])[0] = rslt.wasNull(19);
              ((string[]) buf[25])[0] = rslt.getString(20, 15);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((short[]) buf[14])[0] = rslt.getShort(14);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 15);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              ((string[]) buf[19])[0] = rslt.getString(17, 15);
              ((bool[]) buf[20])[0] = rslt.wasNull(17);
              ((string[]) buf[21])[0] = rslt.getString(18, 15);
              ((bool[]) buf[22])[0] = rslt.wasNull(18);
              ((string[]) buf[23])[0] = rslt.getString(19, 15);
              ((bool[]) buf[24])[0] = rslt.wasNull(19);
              ((string[]) buf[25])[0] = rslt.getString(20, 15);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((short[]) buf[14])[0] = rslt.getShort(14);
              ((string[]) buf[15])[0] = rslt.getString(15, 100);
              ((int[]) buf[16])[0] = rslt.getInt(16);
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((string[]) buf[20])[0] = rslt.getString(18, 15);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              ((string[]) buf[22])[0] = rslt.getString(19, 15);
              ((bool[]) buf[23])[0] = rslt.wasNull(19);
              ((string[]) buf[24])[0] = rslt.getString(20, 15);
              ((bool[]) buf[25])[0] = rslt.wasNull(20);
              ((string[]) buf[26])[0] = rslt.getString(21, 15);
              ((bool[]) buf[27])[0] = rslt.wasNull(21);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 31 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 32 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 34 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 47 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 48 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 49 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 50 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 51 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 52 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 54 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 55 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 57 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 58 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 59 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 61 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 62 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 63 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 64 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 65 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 66 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 67 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 68 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 69 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 70 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
