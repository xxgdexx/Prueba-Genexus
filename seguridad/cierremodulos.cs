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
namespace GeneXus.Programs.seguridad {
   public class cierremodulos : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.cierremodulos.aspx")), "seguridad.cierremodulos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.cierremodulos.aspx")))) ;
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
                  AV8CMModCod = GetPar( "CMModCod");
                  AssignAttri("", false, "AV8CMModCod", AV8CMModCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCMMODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8CMModCod, "")), context));
                  AV7CMModAno = (short)(NumberUtil.Val( GetPar( "CMModAno"), "."));
                  AssignAttri("", false, "AV7CMModAno", StringUtil.LTrimStr( (decimal)(AV7CMModAno), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCMMODANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CMModAno), "ZZZ9"), context));
                  AV9CMModMes = (short)(NumberUtil.Val( GetPar( "CMModMes"), "."));
                  AssignAttri("", false, "AV9CMModMes", StringUtil.LTrimStr( (decimal)(AV9CMModMes), 2, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCMMODMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9CMModMes), "Z9"), context));
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
            Form.Meta.addItem("description", "Cierre Modulos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cierremodulos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cierremodulos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CMModCod ,
                           short aP2_CMModAno ,
                           short aP3_CMModMes )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8CMModCod = aP1_CMModCod;
         this.AV7CMModAno = aP2_CMModAno;
         this.AV9CMModMes = aP3_CMModMes;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCMModCod = new GXCombobox();
         cmbCMModMes = new GXCombobox();
         cmbCMModSts = new GXCombobox();
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
         if ( cmbCMModCod.ItemCount > 0 )
         {
            A73CMModCod = cmbCMModCod.getValidValue(A73CMModCod);
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCMModCod.CurrentValue = StringUtil.RTrim( A73CMModCod);
            AssignProp("", false, cmbCMModCod_Internalname, "Values", cmbCMModCod.ToJavascriptSource(), true);
         }
         if ( cmbCMModMes.ItemCount > 0 )
         {
            A75CMModMes = (short)(NumberUtil.Val( cmbCMModMes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0))), "."));
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCMModMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0));
            AssignProp("", false, cmbCMModMes_Internalname, "Values", cmbCMModMes.ToJavascriptSource(), true);
         }
         if ( cmbCMModSts.ItemCount > 0 )
         {
            A640CMModSts = (short)(NumberUtil.Val( cmbCMModSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0))), "."));
            AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCMModSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            AssignProp("", false, cmbCMModSts_Internalname, "Values", cmbCMModSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCMModCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCMModCod_Internalname, "Modulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCMModCod, cmbCMModCod_Internalname, StringUtil.RTrim( A73CMModCod), 1, cmbCMModCod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCMModCod.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 1, "HLP_Seguridad\\CierreModulos.htm");
         cmbCMModCod.CurrentValue = StringUtil.RTrim( A73CMModCod);
         AssignProp("", false, cmbCMModCod_Internalname, "Values", (string)(cmbCMModCod.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCMModAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCMModAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A74CMModAno), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModAno_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCMModMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCMModMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCMModMes, cmbCMModMes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0)), 1, cmbCMModMes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCMModMes.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Seguridad\\CierreModulos.htm");
         cmbCMModMes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A75CMModMes), 2, 0));
         AssignProp("", false, cmbCMModMes_Internalname, "Values", (string)(cmbCMModMes.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCMModSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCMModSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCMModSts, cmbCMModSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0)), 1, cmbCMModSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCMModSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_Seguridad\\CierreModulos.htm");
         cmbCMModSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
         AssignProp("", false, cmbCMModSts_Internalname, "Values", (string)(cmbCMModSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCMModUsuC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCMModUsuC_Internalname, "Usuario Creación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCMModUsuC_Internalname, StringUtil.RTrim( A641CMModUsuC), StringUtil.RTrim( context.localUtil.Format( A641CMModUsuC, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCMModFecC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCMModFecC_Internalname, "Fecha Creación", "col-sm-3 AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtCMModFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCMModFecC_Internalname, context.localUtil.Format(A638CMModFecC, "99/99/99"), context.localUtil.Format( A638CMModFecC, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModFecC_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtCMModFecC_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_bitmap( context, edtCMModFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCMModFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Seguridad\\CierreModulos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCMModUsuM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCMModUsuM_Internalname, "Usuario Modificación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCMModUsuM_Internalname, StringUtil.RTrim( A642CMModUsuM), StringUtil.RTrim( context.localUtil.Format( A642CMModUsuM, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCMModFecM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCMModFecM_Internalname, "Fecha Modificación", "col-sm-3 AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtCMModFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCMModFecM_Internalname, context.localUtil.Format(A639CMModFecM, "99/99/99"), context.localUtil.Format( A639CMModFecM, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModFecM_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtCMModFecM_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_bitmap( context, edtCMModFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCMModFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Seguridad\\CierreModulos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\CierreModulos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\CierreModulos.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z73CMModCod = cgiGet( "Z73CMModCod");
               Z74CMModAno = (short)(context.localUtil.CToN( cgiGet( "Z74CMModAno"), ".", ","));
               Z75CMModMes = (short)(context.localUtil.CToN( cgiGet( "Z75CMModMes"), ".", ","));
               Z638CMModFecC = context.localUtil.CToD( cgiGet( "Z638CMModFecC"), 0);
               Z639CMModFecM = context.localUtil.CToD( cgiGet( "Z639CMModFecM"), 0);
               Z640CMModSts = (short)(context.localUtil.CToN( cgiGet( "Z640CMModSts"), ".", ","));
               Z641CMModUsuC = cgiGet( "Z641CMModUsuC");
               Z642CMModUsuM = cgiGet( "Z642CMModUsuM");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV8CMModCod = cgiGet( "vCMMODCOD");
               AV7CMModAno = (short)(context.localUtil.CToN( cgiGet( "vCMMODANO"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV9CMModMes = (short)(context.localUtil.CToN( cgiGet( "vCMMODMES"), ".", ","));
               AV14UsuCod = cgiGet( "vUSUCOD");
               ajax_req_read_hidden_sdt(cgiGet( "vWWPCONTEXT"), AV13WWPContext);
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
               cmbCMModCod.CurrentValue = cgiGet( cmbCMModCod_Internalname);
               A73CMModCod = cgiGet( cmbCMModCod_Internalname);
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CMMODANO");
                  AnyError = 1;
                  GX_FocusControl = edtCMModAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A74CMModAno = 0;
                  AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               }
               else
               {
                  A74CMModAno = (short)(context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ","));
                  AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               }
               cmbCMModMes.CurrentValue = cgiGet( cmbCMModMes_Internalname);
               A75CMModMes = (short)(NumberUtil.Val( cgiGet( cmbCMModMes_Internalname), "."));
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
               cmbCMModSts.CurrentValue = cgiGet( cmbCMModSts_Internalname);
               A640CMModSts = (short)(NumberUtil.Val( cgiGet( cmbCMModSts_Internalname), "."));
               AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
               A641CMModUsuC = cgiGet( edtCMModUsuC_Internalname);
               AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
               A638CMModFecC = context.localUtil.CToD( cgiGet( edtCMModFecC_Internalname), 2);
               AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
               A642CMModUsuM = cgiGet( edtCMModUsuM_Internalname);
               AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
               A639CMModFecM = context.localUtil.CToD( cgiGet( edtCMModFecM_Internalname), 2);
               AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CierreModulos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\cierremodulos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A73CMModCod = GetPar( "CMModCod");
                  AssignAttri("", false, "A73CMModCod", A73CMModCod);
                  A74CMModAno = (short)(NumberUtil.Val( GetPar( "CMModAno"), "."));
                  AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                  A75CMModMes = (short)(NumberUtil.Val( GetPar( "CMModMes"), "."));
                  AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7CMModAno) )
                  {
                     A74CMModAno = AV7CMModAno;
                     AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A74CMModAno) && ( Gx_BScreen == 0 ) )
                     {
                        A74CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
                        AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                     }
                  }
                  if ( ! (0==AV9CMModMes) )
                  {
                     A75CMModMes = AV9CMModMes;
                     AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A75CMModMes) && ( Gx_BScreen == 0 ) )
                     {
                        A75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
                        AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7CMModAno) )
                     {
                        A74CMModAno = AV7CMModAno;
                        AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A74CMModAno) && ( Gx_BScreen == 0 ) )
                        {
                           A74CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
                           AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                        }
                     }
                     if ( ! (0==AV9CMModMes) )
                     {
                        A75CMModMes = AV9CMModMes;
                        AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A75CMModMes) && ( Gx_BScreen == 0 ) )
                        {
                           A75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
                           AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                        }
                     }
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CMMODCOD");
                        AnyError = 1;
                        GX_FocusControl = cmbCMModCod_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
            DisableAttributes077( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         AV10TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("seguridad.cierremodulosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z638CMModFecC = T00073_A638CMModFecC[0];
               Z639CMModFecM = T00073_A639CMModFecM[0];
               Z640CMModSts = T00073_A640CMModSts[0];
               Z641CMModUsuC = T00073_A641CMModUsuC[0];
               Z642CMModUsuM = T00073_A642CMModUsuM[0];
            }
            else
            {
               Z638CMModFecC = A638CMModFecC;
               Z639CMModFecM = A639CMModFecM;
               Z640CMModSts = A640CMModSts;
               Z641CMModUsuC = A641CMModUsuC;
               Z642CMModUsuM = A642CMModUsuM;
            }
         }
         if ( GX_JID == -25 )
         {
            Z73CMModCod = A73CMModCod;
            Z74CMModAno = A74CMModAno;
            Z75CMModMes = A75CMModMes;
            Z638CMModFecC = A638CMModFecC;
            Z639CMModFecM = A639CMModFecM;
            Z640CMModSts = A640CMModSts;
            Z641CMModUsuC = A641CMModUsuC;
            Z642CMModUsuM = A642CMModUsuM;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCMModUsuC_Enabled = 0;
         AssignProp("", false, edtCMModUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuC_Enabled), 5, 0), true);
         edtCMModFecC_Enabled = 0;
         AssignProp("", false, edtCMModFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecC_Enabled), 5, 0), true);
         edtCMModUsuM_Enabled = 0;
         AssignProp("", false, edtCMModUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuM_Enabled), 5, 0), true);
         edtCMModFecM_Enabled = 0;
         AssignProp("", false, edtCMModFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecM_Enabled), 5, 0), true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCMModUsuC_Enabled = 0;
         AssignProp("", false, edtCMModUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuC_Enabled), 5, 0), true);
         edtCMModFecC_Enabled = 0;
         AssignProp("", false, edtCMModFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecC_Enabled), 5, 0), true);
         edtCMModUsuM_Enabled = 0;
         AssignProp("", false, edtCMModUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuM_Enabled), 5, 0), true);
         edtCMModFecM_Enabled = 0;
         AssignProp("", false, edtCMModFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecM_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CMModCod)) )
         {
            A73CMModCod = AV8CMModCod;
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CMModCod)) )
         {
            cmbCMModCod.Enabled = 0;
            AssignProp("", false, cmbCMModCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModCod.Enabled), 5, 0), true);
         }
         else
         {
            cmbCMModCod.Enabled = 1;
            AssignProp("", false, cmbCMModCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModCod.Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CMModCod)) )
         {
            cmbCMModCod.Enabled = 0;
            AssignProp("", false, cmbCMModCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModCod.Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CMModAno) )
         {
            edtCMModAno_Enabled = 0;
            AssignProp("", false, edtCMModAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModAno_Enabled), 5, 0), true);
         }
         else
         {
            edtCMModAno_Enabled = 1;
            AssignProp("", false, edtCMModAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModAno_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CMModAno) )
         {
            edtCMModAno_Enabled = 0;
            AssignProp("", false, edtCMModAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModAno_Enabled), 5, 0), true);
         }
         if ( ! (0==AV9CMModMes) )
         {
            cmbCMModMes.Enabled = 0;
            AssignProp("", false, cmbCMModMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModMes.Enabled), 5, 0), true);
         }
         else
         {
            cmbCMModMes.Enabled = 1;
            AssignProp("", false, cmbCMModMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModMes.Enabled), 5, 0), true);
         }
         if ( ! (0==AV9CMModMes) )
         {
            cmbCMModMes.Enabled = 0;
            AssignProp("", false, cmbCMModMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModMes.Enabled), 5, 0), true);
         }
         AV14UsuCod = AV13WWPContext.gxTpr_Username;
         AssignAttri("", false, "AV14UsuCod", AV14UsuCod);
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
         if ( ! (0==AV7CMModAno) )
         {
            A74CMModAno = AV7CMModAno;
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A74CMModAno) && ( Gx_BScreen == 0 ) )
            {
               A74CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            }
         }
         if ( ! (0==AV9CMModMes) )
         {
            A75CMModMes = AV9CMModMes;
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A75CMModMes) && ( Gx_BScreen == 0 ) )
            {
               A75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            }
         }
         if ( IsIns( )  && (0==A640CMModSts) && ( Gx_BScreen == 0 ) )
         {
            A640CMModSts = 1;
            AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load077( )
      {
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound7 = 1;
            A638CMModFecC = T00074_A638CMModFecC[0];
            AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
            A639CMModFecM = T00074_A639CMModFecM[0];
            AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
            A640CMModSts = T00074_A640CMModSts[0];
            AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            A641CMModUsuC = T00074_A641CMModUsuC[0];
            AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
            A642CMModUsuM = T00074_A642CMModUsuM[0];
            AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
            ZM077( -25) ;
         }
         pr_default.close(2);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A73CMModCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Modulo", "", "", "", "", "", "", "", ""), 1, "CMMODCOD");
            AnyError = 1;
            GX_FocusControl = cmbCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A74CMModAno) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Año", "", "", "", "", "", "", "", ""), 1, "CMMODANO");
            AnyError = 1;
            GX_FocusControl = edtCMModAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A75CMModMes) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Mes", "", "", "", "", "", "", "", ""), 1, "CMMODMES");
            AnyError = 1;
            GX_FocusControl = cmbCMModMes_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A640CMModSts) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Estado", "", "", "", "", "", "", "", ""), 1, "CMMODSTS");
            AnyError = 1;
            GX_FocusControl = cmbCMModSts_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors077( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 25) ;
            RcdFound7 = 1;
            A73CMModCod = T00073_A73CMModCod[0];
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = T00073_A74CMModAno[0];
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = T00073_A75CMModMes[0];
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            A638CMModFecC = T00073_A638CMModFecC[0];
            AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
            A639CMModFecM = T00073_A639CMModFecM[0];
            AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
            A640CMModSts = T00073_A640CMModSts[0];
            AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            A641CMModUsuC = T00073_A641CMModUsuC[0];
            AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
            A642CMModUsuM = T00073_A642CMModUsuM[0];
            AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
            Z73CMModCod = A73CMModCod;
            Z74CMModAno = A74CMModAno;
            Z75CMModMes = A75CMModMes;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00076_A73CMModCod[0], A73CMModCod) < 0 ) || ( StringUtil.StrCmp(T00076_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00076_A74CMModAno[0] < A74CMModAno ) || ( T00076_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T00076_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00076_A75CMModMes[0] < A75CMModMes ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00076_A73CMModCod[0], A73CMModCod) > 0 ) || ( StringUtil.StrCmp(T00076_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00076_A74CMModAno[0] > A74CMModAno ) || ( T00076_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T00076_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00076_A75CMModMes[0] > A75CMModMes ) ) )
            {
               A73CMModCod = T00076_A73CMModCod[0];
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               A74CMModAno = T00076_A74CMModAno[0];
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               A75CMModMes = T00076_A75CMModMes[0];
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00077_A73CMModCod[0], A73CMModCod) > 0 ) || ( StringUtil.StrCmp(T00077_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00077_A74CMModAno[0] > A74CMModAno ) || ( T00077_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T00077_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00077_A75CMModMes[0] > A75CMModMes ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00077_A73CMModCod[0], A73CMModCod) < 0 ) || ( StringUtil.StrCmp(T00077_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00077_A74CMModAno[0] < A74CMModAno ) || ( T00077_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T00077_A73CMModCod[0], A73CMModCod) == 0 ) && ( T00077_A75CMModMes[0] < A75CMModMes ) ) )
            {
               A73CMModCod = T00077_A73CMModCod[0];
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               A74CMModAno = T00077_A74CMModAno[0];
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               A75CMModMes = T00077_A75CMModMes[0];
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
               {
                  A73CMModCod = Z73CMModCod;
                  AssignAttri("", false, "A73CMModCod", A73CMModCod);
                  A74CMModAno = Z74CMModAno;
                  AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                  A75CMModMes = Z75CMModMes;
                  AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CMMODCOD");
                  AnyError = 1;
                  GX_FocusControl = cmbCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = cmbCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
               {
                  /* Insert record */
                  GX_FocusControl = cmbCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CMMODCOD");
                     AnyError = 1;
                     GX_FocusControl = cmbCMModCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbCMModCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
         {
            A73CMModCod = Z73CMModCod;
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = Z74CMModAno;
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = Z75CMModMes;
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CMMODCOD");
            AnyError = 1;
            GX_FocusControl = cmbCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCIERREMODULO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z638CMModFecC ) != DateTimeUtil.ResetTime ( T00072_A638CMModFecC[0] ) ) || ( DateTimeUtil.ResetTime ( Z639CMModFecM ) != DateTimeUtil.ResetTime ( T00072_A639CMModFecM[0] ) ) || ( Z640CMModSts != T00072_A640CMModSts[0] ) || ( StringUtil.StrCmp(Z641CMModUsuC, T00072_A641CMModUsuC[0]) != 0 ) || ( StringUtil.StrCmp(Z642CMModUsuM, T00072_A642CMModUsuM[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z638CMModFecC ) != DateTimeUtil.ResetTime ( T00072_A638CMModFecC[0] ) )
               {
                  GXUtil.WriteLog("seguridad.cierremodulos:[seudo value changed for attri]"+"CMModFecC");
                  GXUtil.WriteLogRaw("Old: ",Z638CMModFecC);
                  GXUtil.WriteLogRaw("Current: ",T00072_A638CMModFecC[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z639CMModFecM ) != DateTimeUtil.ResetTime ( T00072_A639CMModFecM[0] ) )
               {
                  GXUtil.WriteLog("seguridad.cierremodulos:[seudo value changed for attri]"+"CMModFecM");
                  GXUtil.WriteLogRaw("Old: ",Z639CMModFecM);
                  GXUtil.WriteLogRaw("Current: ",T00072_A639CMModFecM[0]);
               }
               if ( Z640CMModSts != T00072_A640CMModSts[0] )
               {
                  GXUtil.WriteLog("seguridad.cierremodulos:[seudo value changed for attri]"+"CMModSts");
                  GXUtil.WriteLogRaw("Old: ",Z640CMModSts);
                  GXUtil.WriteLogRaw("Current: ",T00072_A640CMModSts[0]);
               }
               if ( StringUtil.StrCmp(Z641CMModUsuC, T00072_A641CMModUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.cierremodulos:[seudo value changed for attri]"+"CMModUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z641CMModUsuC);
                  GXUtil.WriteLogRaw("Current: ",T00072_A641CMModUsuC[0]);
               }
               if ( StringUtil.StrCmp(Z642CMModUsuM, T00072_A642CMModUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.cierremodulos:[seudo value changed for attri]"+"CMModUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z642CMModUsuM);
                  GXUtil.WriteLogRaw("Current: ",T00072_A642CMModUsuM[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBCIERREMODULO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00078 */
                     pr_default.execute(6, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes, A638CMModFecC, A639CMModFecM, A640CMModSts, A641CMModUsuC, A642CMModUsuM});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCIERREMODULO");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption070( ) ;
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00079 */
                     pr_default.execute(7, new Object[] {A638CMModFecC, A639CMModFecM, A640CMModSts, A641CMModUsuC, A642CMModUsuM, A73CMModCod, A74CMModAno, A75CMModMes});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCIERREMODULO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCIERREMODULO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000710 */
                  pr_default.execute(8, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBCIERREMODULO");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("seguridad.cierremodulos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("seguridad.cierremodulos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000711 */
         pr_default.execute(9);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A73CMModCod = T000711_A73CMModCod[0];
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = T000711_A74CMModAno[0];
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = T000711_A75CMModMes[0];
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A73CMModCod = T000711_A73CMModCod[0];
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = T000711_A74CMModAno[0];
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = T000711_A75CMModMes[0];
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  )
         {
            A638CMModFecC = DateTimeUtil.Today( context);
            AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
         }
         if ( IsUpd( )  )
         {
            A639CMModFecM = DateTimeUtil.Today( context);
            AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
         }
         if ( IsIns( )  )
         {
            A641CMModUsuC = AV14UsuCod;
            AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
         }
         if ( IsUpd( )  )
         {
            A642CMModUsuM = AV14UsuCod;
            AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
         }
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         cmbCMModCod.Enabled = 0;
         AssignProp("", false, cmbCMModCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModCod.Enabled), 5, 0), true);
         edtCMModAno_Enabled = 0;
         AssignProp("", false, edtCMModAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModAno_Enabled), 5, 0), true);
         cmbCMModMes.Enabled = 0;
         AssignProp("", false, cmbCMModMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModMes.Enabled), 5, 0), true);
         cmbCMModSts.Enabled = 0;
         AssignProp("", false, cmbCMModSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCMModSts.Enabled), 5, 0), true);
         edtCMModUsuC_Enabled = 0;
         AssignProp("", false, edtCMModUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuC_Enabled), 5, 0), true);
         edtCMModFecC_Enabled = 0;
         AssignProp("", false, edtCMModFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecC_Enabled), 5, 0), true);
         edtCMModUsuM_Enabled = 0;
         AssignProp("", false, edtCMModUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuM_Enabled), 5, 0), true);
         edtCMModFecM_Enabled = 0;
         AssignProp("", false, edtCMModFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecM_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181144108", false, true);
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
         GXEncryptionTmp = "seguridad.cierremodulos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV8CMModCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CMModAno,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9CMModMes,2,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.cierremodulos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CierreModulos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\cierremodulos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z73CMModCod", StringUtil.RTrim( Z73CMModCod));
         GxWebStd.gx_hidden_field( context, "Z74CMModAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z74CMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z75CMModMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75CMModMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z638CMModFecC", context.localUtil.DToC( Z638CMModFecC, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z639CMModFecM", context.localUtil.DToC( Z639CMModFecM, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z640CMModSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z640CMModSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z641CMModUsuC", StringUtil.RTrim( Z641CMModUsuC));
         GxWebStd.gx_hidden_field( context, "Z642CMModUsuM", StringUtil.RTrim( Z642CMModUsuM));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCMMODCOD", StringUtil.RTrim( AV8CMModCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vCMMODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8CMModCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vCMMODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCMMODANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CMModAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCMMODMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CMModMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCMMODMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9CMModMes), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUCOD", StringUtil.RTrim( AV14UsuCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV13WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV13WWPContext);
         }
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
         GXEncryptionTmp = "seguridad.cierremodulos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV8CMModCod)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CMModAno,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9CMModMes,2,0));
         return formatLink("seguridad.cierremodulos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.CierreModulos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cierre Modulos" ;
      }

      protected void InitializeNonKey077( )
      {
         A638CMModFecC = DateTime.MinValue;
         AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
         A639CMModFecM = DateTime.MinValue;
         AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
         A641CMModUsuC = "";
         AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
         A642CMModUsuM = "";
         AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
         A640CMModSts = 1;
         AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
         Z638CMModFecC = DateTime.MinValue;
         Z639CMModFecM = DateTime.MinValue;
         Z640CMModSts = 0;
         Z641CMModUsuC = "";
         Z642CMModUsuM = "";
      }

      protected void InitAll077( )
      {
         A73CMModCod = "";
         AssignAttri("", false, "A73CMModCod", A73CMModCod);
         A74CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
         A75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A640CMModSts = i640CMModSts;
         AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441032", true, true);
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
         context.AddJavascriptSource("seguridad/cierremodulos.js", "?202281811441033", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbCMModCod_Internalname = "CMMODCOD";
         edtCMModAno_Internalname = "CMMODANO";
         cmbCMModMes_Internalname = "CMMODMES";
         cmbCMModSts_Internalname = "CMMODSTS";
         edtCMModUsuC_Internalname = "CMMODUSUC";
         edtCMModFecC_Internalname = "CMMODFECC";
         edtCMModUsuM_Internalname = "CMMODUSUM";
         edtCMModFecM_Internalname = "CMMODFECM";
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
         Form.Caption = "Cierre Modulos";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCMModFecM_Jsonclick = "";
         edtCMModFecM_Enabled = 0;
         edtCMModUsuM_Jsonclick = "";
         edtCMModUsuM_Enabled = 0;
         edtCMModFecC_Jsonclick = "";
         edtCMModFecC_Enabled = 0;
         edtCMModUsuC_Jsonclick = "";
         edtCMModUsuC_Enabled = 0;
         cmbCMModSts_Jsonclick = "";
         cmbCMModSts.Enabled = 1;
         cmbCMModMes_Jsonclick = "";
         cmbCMModMes.Enabled = 1;
         edtCMModAno_Jsonclick = "";
         edtCMModAno_Enabled = 1;
         cmbCMModCod_Jsonclick = "";
         cmbCMModCod.Enabled = 1;
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

      protected void XC_24_077( )
      {
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV13WWPContext.ToXml(false, true, "", "")))+"\"") ;
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
         cmbCMModCod.Name = "CMMODCOD";
         cmbCMModCod.WebTags = "";
         cmbCMModCod.addItem("ALM", "Almacenes", 0);
         cmbCMModCod.addItem("CLI", "Ventas", 0);
         cmbCMModCod.addItem("PRV", "Compras", 0);
         cmbCMModCod.addItem("CON", "Contabilidad", 0);
         cmbCMModCod.addItem("PRO", "Produccion", 0);
         cmbCMModCod.addItem("PLA", "Planilla", 0);
         cmbCMModCod.addItem("TES", "Bancos", 0);
         cmbCMModCod.addItem("ACT", "Activos Fijos", 0);
         if ( cmbCMModCod.ItemCount > 0 )
         {
            A73CMModCod = cmbCMModCod.getValidValue(A73CMModCod);
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
         }
         cmbCMModMes.Name = "CMMODMES";
         cmbCMModMes.WebTags = "";
         cmbCMModMes.addItem("1", "Enero", 0);
         cmbCMModMes.addItem("2", "Febrero", 0);
         cmbCMModMes.addItem("3", "Marzo", 0);
         cmbCMModMes.addItem("4", "Abril", 0);
         cmbCMModMes.addItem("5", "Mayo", 0);
         cmbCMModMes.addItem("6", "Junio", 0);
         cmbCMModMes.addItem("7", "Julio", 0);
         cmbCMModMes.addItem("8", "Agosto", 0);
         cmbCMModMes.addItem("9", "Setiembre", 0);
         cmbCMModMes.addItem("10", "Octubre", 0);
         cmbCMModMes.addItem("11", "Noviembre", 0);
         cmbCMModMes.addItem("12", "Diciembre", 0);
         if ( cmbCMModMes.ItemCount > 0 )
         {
            if ( (0==A75CMModMes) )
            {
               A75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            }
         }
         cmbCMModSts.Name = "CMMODSTS";
         cmbCMModSts.WebTags = "";
         cmbCMModSts.addItem("1", "Abierto", 0);
         cmbCMModSts.addItem("2", "Cerrado", 0);
         if ( cmbCMModSts.ItemCount > 0 )
         {
            if ( (0==A640CMModSts) )
            {
               A640CMModSts = 1;
               AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8CMModCod',fld:'vCMMODCOD',pic:'',hsh:true},{av:'AV7CMModAno',fld:'vCMMODANO',pic:'ZZZ9',hsh:true},{av:'AV9CMModMes',fld:'vCMMODMES',pic:'Z9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV8CMModCod',fld:'vCMMODCOD',pic:'',hsh:true},{av:'AV7CMModAno',fld:'vCMMODANO',pic:'ZZZ9',hsh:true},{av:'AV9CMModMes',fld:'vCMMODMES',pic:'Z9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CMMODCOD","{handler:'Valid_Cmmodcod',iparms:[]");
         setEventMetadata("VALID_CMMODCOD",",oparms:[]}");
         setEventMetadata("VALID_CMMODANO","{handler:'Valid_Cmmodano',iparms:[]");
         setEventMetadata("VALID_CMMODANO",",oparms:[]}");
         setEventMetadata("VALID_CMMODMES","{handler:'Valid_Cmmodmes',iparms:[]");
         setEventMetadata("VALID_CMMODMES",",oparms:[]}");
         setEventMetadata("VALID_CMMODSTS","{handler:'Valid_Cmmodsts',iparms:[]");
         setEventMetadata("VALID_CMMODSTS",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV8CMModCod = "";
         Z73CMModCod = "";
         Z638CMModFecC = DateTime.MinValue;
         Z639CMModFecM = DateTime.MinValue;
         Z641CMModUsuC = "";
         Z642CMModUsuM = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A73CMModCod = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A641CMModUsuC = "";
         A638CMModFecC = DateTime.MinValue;
         A642CMModUsuM = "";
         A639CMModFecM = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV14UsuCod = "";
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00074_A73CMModCod = new string[] {""} ;
         T00074_A74CMModAno = new short[1] ;
         T00074_A75CMModMes = new short[1] ;
         T00074_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         T00074_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         T00074_A640CMModSts = new short[1] ;
         T00074_A641CMModUsuC = new string[] {""} ;
         T00074_A642CMModUsuM = new string[] {""} ;
         T00075_A73CMModCod = new string[] {""} ;
         T00075_A74CMModAno = new short[1] ;
         T00075_A75CMModMes = new short[1] ;
         T00073_A73CMModCod = new string[] {""} ;
         T00073_A74CMModAno = new short[1] ;
         T00073_A75CMModMes = new short[1] ;
         T00073_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         T00073_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         T00073_A640CMModSts = new short[1] ;
         T00073_A641CMModUsuC = new string[] {""} ;
         T00073_A642CMModUsuM = new string[] {""} ;
         T00076_A73CMModCod = new string[] {""} ;
         T00076_A74CMModAno = new short[1] ;
         T00076_A75CMModMes = new short[1] ;
         T00077_A73CMModCod = new string[] {""} ;
         T00077_A74CMModAno = new short[1] ;
         T00077_A75CMModMes = new short[1] ;
         T00072_A73CMModCod = new string[] {""} ;
         T00072_A74CMModAno = new short[1] ;
         T00072_A75CMModMes = new short[1] ;
         T00072_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         T00072_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         T00072_A640CMModSts = new short[1] ;
         T00072_A641CMModUsuC = new string[] {""} ;
         T00072_A642CMModUsuM = new string[] {""} ;
         T000711_A73CMModCod = new string[] {""} ;
         T000711_A74CMModAno = new short[1] ;
         T000711_A75CMModMes = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.cierremodulos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.cierremodulos__default(),
            new Object[][] {
                new Object[] {
               T00072_A73CMModCod, T00072_A74CMModAno, T00072_A75CMModMes, T00072_A638CMModFecC, T00072_A639CMModFecM, T00072_A640CMModSts, T00072_A641CMModUsuC, T00072_A642CMModUsuM
               }
               , new Object[] {
               T00073_A73CMModCod, T00073_A74CMModAno, T00073_A75CMModMes, T00073_A638CMModFecC, T00073_A639CMModFecM, T00073_A640CMModSts, T00073_A641CMModUsuC, T00073_A642CMModUsuM
               }
               , new Object[] {
               T00074_A73CMModCod, T00074_A74CMModAno, T00074_A75CMModMes, T00074_A638CMModFecC, T00074_A639CMModFecM, T00074_A640CMModSts, T00074_A641CMModUsuC, T00074_A642CMModUsuM
               }
               , new Object[] {
               T00075_A73CMModCod, T00075_A74CMModAno, T00075_A75CMModMes
               }
               , new Object[] {
               T00076_A73CMModCod, T00076_A74CMModAno, T00076_A75CMModMes
               }
               , new Object[] {
               T00077_A73CMModCod, T00077_A74CMModAno, T00077_A75CMModMes
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000711_A73CMModCod, T000711_A74CMModAno, T000711_A75CMModMes
               }
            }
         );
         Z640CMModSts = 1;
         A640CMModSts = 1;
         i640CMModSts = 1;
         Z75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         A75CMModMes = (short)(DateTimeUtil.Month( DateTimeUtil.Today( context)));
         Z74CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         A74CMModAno = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
      }

      private short wcpOAV7CMModAno ;
      private short wcpOAV9CMModMes ;
      private short Z74CMModAno ;
      private short Z75CMModMes ;
      private short Z640CMModSts ;
      private short GxWebError ;
      private short AV7CMModAno ;
      private short AV9CMModMes ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A75CMModMes ;
      private short A640CMModSts ;
      private short A74CMModAno ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short nIsDirty_7 ;
      private short gxajaxcallmode ;
      private short i640CMModSts ;
      private int trnEnded ;
      private int edtCMModAno_Enabled ;
      private int edtCMModUsuC_Enabled ;
      private int edtCMModFecC_Enabled ;
      private int edtCMModUsuM_Enabled ;
      private int edtCMModFecM_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV8CMModCod ;
      private string Z73CMModCod ;
      private string Z641CMModUsuC ;
      private string Z642CMModUsuM ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV8CMModCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbCMModCod_Internalname ;
      private string A73CMModCod ;
      private string cmbCMModMes_Internalname ;
      private string cmbCMModSts_Internalname ;
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
      private string cmbCMModCod_Jsonclick ;
      private string edtCMModAno_Internalname ;
      private string edtCMModAno_Jsonclick ;
      private string cmbCMModMes_Jsonclick ;
      private string cmbCMModSts_Jsonclick ;
      private string edtCMModUsuC_Internalname ;
      private string A641CMModUsuC ;
      private string edtCMModUsuC_Jsonclick ;
      private string edtCMModFecC_Internalname ;
      private string edtCMModFecC_Jsonclick ;
      private string edtCMModUsuM_Internalname ;
      private string A642CMModUsuM ;
      private string edtCMModUsuM_Jsonclick ;
      private string edtCMModFecM_Internalname ;
      private string edtCMModFecM_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV14UsuCod ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z638CMModFecC ;
      private DateTime Z639CMModFecM ;
      private DateTime A638CMModFecC ;
      private DateTime A639CMModFecM ;
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
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCMModCod ;
      private GXCombobox cmbCMModMes ;
      private GXCombobox cmbCMModSts ;
      private IDataStoreProvider pr_default ;
      private string[] T00074_A73CMModCod ;
      private short[] T00074_A74CMModAno ;
      private short[] T00074_A75CMModMes ;
      private DateTime[] T00074_A638CMModFecC ;
      private DateTime[] T00074_A639CMModFecM ;
      private short[] T00074_A640CMModSts ;
      private string[] T00074_A641CMModUsuC ;
      private string[] T00074_A642CMModUsuM ;
      private string[] T00075_A73CMModCod ;
      private short[] T00075_A74CMModAno ;
      private short[] T00075_A75CMModMes ;
      private string[] T00073_A73CMModCod ;
      private short[] T00073_A74CMModAno ;
      private short[] T00073_A75CMModMes ;
      private DateTime[] T00073_A638CMModFecC ;
      private DateTime[] T00073_A639CMModFecM ;
      private short[] T00073_A640CMModSts ;
      private string[] T00073_A641CMModUsuC ;
      private string[] T00073_A642CMModUsuM ;
      private string[] T00076_A73CMModCod ;
      private short[] T00076_A74CMModAno ;
      private short[] T00076_A75CMModMes ;
      private string[] T00077_A73CMModCod ;
      private short[] T00077_A74CMModAno ;
      private short[] T00077_A75CMModMes ;
      private string[] T00072_A73CMModCod ;
      private short[] T00072_A74CMModAno ;
      private short[] T00072_A75CMModMes ;
      private DateTime[] T00072_A638CMModFecC ;
      private DateTime[] T00072_A639CMModFecM ;
      private short[] T00072_A640CMModSts ;
      private string[] T00072_A641CMModUsuC ;
      private string[] T00072_A642CMModUsuM ;
      private string[] T000711_A73CMModCod ;
      private short[] T000711_A74CMModAno ;
      private short[] T000711_A75CMModMes ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
   }

   public class cierremodulos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cierremodulos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0) ,
        new ParDef("@CMModFecC",GXType.Date,8,0) ,
        new ParDef("@CMModFecM",GXType.Date,8,0) ,
        new ParDef("@CMModSts",GXType.Int16,1,0) ,
        new ParDef("@CMModUsuC",GXType.NChar,10,0) ,
        new ParDef("@CMModUsuM",GXType.NChar,10,0)
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        new ParDef("@CMModFecC",GXType.Date,8,0) ,
        new ParDef("@CMModFecM",GXType.Date,8,0) ,
        new ParDef("@CMModSts",GXType.Int16,1,0) ,
        new ParDef("@CMModUsuC",GXType.NChar,10,0) ,
        new ParDef("@CMModUsuM",GXType.NChar,10,0) ,
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT [CMModCod], [CMModAno], [CMModMes], [CMModFecC], [CMModFecM], [CMModSts], [CMModUsuC], [CMModUsuM] FROM [CBCIERREMODULO] WITH (UPDLOCK) WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT [CMModCod], [CMModAno], [CMModMes], [CMModFecC], [CMModFecM], [CMModSts], [CMModUsuC], [CMModUsuM] FROM [CBCIERREMODULO] WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT TM1.[CMModCod], TM1.[CMModAno], TM1.[CMModMes], TM1.[CMModFecC], TM1.[CMModFecM], TM1.[CMModSts], TM1.[CMModUsuC], TM1.[CMModUsuM] FROM [CBCIERREMODULO] TM1 WHERE TM1.[CMModCod] = @CMModCod and TM1.[CMModAno] = @CMModAno and TM1.[CMModMes] = @CMModMes ORDER BY TM1.[CMModCod], TM1.[CMModAno], TM1.[CMModMes]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT TOP 1 [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] WHERE ( [CMModCod] > @CMModCod or [CMModCod] = @CMModCod and [CMModAno] > @CMModAno or [CMModAno] = @CMModAno and [CMModCod] = @CMModCod and [CMModMes] > @CMModMes) ORDER BY [CMModCod], [CMModAno], [CMModMes]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00077", "SELECT TOP 1 [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] WHERE ( [CMModCod] < @CMModCod or [CMModCod] = @CMModCod and [CMModAno] < @CMModAno or [CMModAno] = @CMModAno and [CMModCod] = @CMModCod and [CMModMes] < @CMModMes) ORDER BY [CMModCod] DESC, [CMModAno] DESC, [CMModMes] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00078", "INSERT INTO [CBCIERREMODULO]([CMModCod], [CMModAno], [CMModMes], [CMModFecC], [CMModFecM], [CMModSts], [CMModUsuC], [CMModUsuM]) VALUES(@CMModCod, @CMModAno, @CMModMes, @CMModFecC, @CMModFecM, @CMModSts, @CMModUsuC, @CMModUsuM)", GxErrorMask.GX_NOMASK,prmT00078)
           ,new CursorDef("T00079", "UPDATE [CBCIERREMODULO] SET [CMModFecC]=@CMModFecC, [CMModFecM]=@CMModFecM, [CMModSts]=@CMModSts, [CMModUsuC]=@CMModUsuC, [CMModUsuM]=@CMModUsuM  WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes", GxErrorMask.GX_NOMASK,prmT00079)
           ,new CursorDef("T000710", "DELETE FROM [CBCIERREMODULO]  WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes", GxErrorMask.GX_NOMASK,prmT000710)
           ,new CursorDef("T000711", "SELECT [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] ORDER BY [CMModCod], [CMModAno], [CMModMes]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
     }
  }

}

}
