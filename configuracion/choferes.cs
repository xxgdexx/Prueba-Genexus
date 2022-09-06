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
   public class choferes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"vCCHOCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASACCHOCOD5O74( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.choferes.aspx")), "configuracion.choferes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.choferes.aspx")))) ;
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
                  AV7ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
                  AssignAttri("", false, "AV7ChoCod", StringUtil.LTrimStr( (decimal)(AV7ChoCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCHOCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ChoCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Choferes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtChoDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public choferes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public choferes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ChoCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ChoCod = aP1_ChoCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbChoSts = new GXCombobox();
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
         if ( cmbChoSts.ItemCount > 0 )
         {
            A549ChoSts = (short)(NumberUtil.Val( cmbChoSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0))), "."));
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChoSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
            AssignProp("", false, cmbChoSts_Internalname, "Values", cmbChoSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoDsc_Internalname, "Chofer", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoDsc_Internalname, StringUtil.RTrim( A542ChoDsc), StringUtil.RTrim( context.localUtil.Format( A542ChoDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtChoDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoDir_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoDir_Internalname, "Dirección", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoDir_Internalname, StringUtil.RTrim( A545ChoDir), StringUtil.RTrim( context.localUtil.Format( A545ChoDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoDir_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtChoDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoTel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoTel_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoTel_Internalname, StringUtil.RTrim( A550ChoTel), StringUtil.RTrim( context.localUtil.Format( A550ChoTel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoTel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoTel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoRuc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoRuc_Internalname, "R.U.C.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoRuc_Internalname, StringUtil.RTrim( A548ChoRuc), StringUtil.RTrim( context.localUtil.Format( A548ChoRuc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoRuc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoRuc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoMarca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoMarca_Internalname, "Marca", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoMarca_Internalname, StringUtil.RTrim( A547ChoMarca), StringUtil.RTrim( context.localUtil.Format( A547ChoMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoMarca_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoPlaca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoPlaca_Internalname, "Placa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoPlaca_Internalname, StringUtil.RTrim( A543ChoPlaca), StringUtil.RTrim( context.localUtil.Format( A543ChoPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoPlaca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoLicencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoLicencia_Internalname, "N° Licencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoLicencia_Internalname, StringUtil.RTrim( A546ChoLicencia), StringUtil.RTrim( context.localUtil.Format( A546ChoLicencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoLicencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoLicencia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChoConsta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChoConsta_Internalname, "N° Constancia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoConsta_Internalname, StringUtil.RTrim( A544ChoConsta), StringUtil.RTrim( context.localUtil.Format( A544ChoConsta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoConsta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoConsta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbChoSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbChoSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChoSts, cmbChoSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0)), 1, cmbChoSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbChoSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 1, "HLP_Configuracion\\Choferes.htm");
         cmbChoSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         AssignProp("", false, cmbChoSts_Internalname, "Values", (string)(cmbChoSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Choferes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Choferes.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ChoCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoCod_Jsonclick, 0, "Attribute", "", "", "", "", edtChoCod_Visible, edtChoCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Choferes.htm");
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
         E115O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z10ChoCod = (int)(context.localUtil.CToN( cgiGet( "Z10ChoCod"), ".", ","));
               Z542ChoDsc = cgiGet( "Z542ChoDsc");
               Z545ChoDir = cgiGet( "Z545ChoDir");
               Z550ChoTel = cgiGet( "Z550ChoTel");
               Z548ChoRuc = cgiGet( "Z548ChoRuc");
               Z547ChoMarca = cgiGet( "Z547ChoMarca");
               Z543ChoPlaca = cgiGet( "Z543ChoPlaca");
               Z546ChoLicencia = cgiGet( "Z546ChoLicencia");
               Z544ChoConsta = cgiGet( "Z544ChoConsta");
               Z549ChoSts = (short)(context.localUtil.CToN( cgiGet( "Z549ChoSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               A541ChoCompleto = cgiGet( "CHOCOMPLETO");
               AV7ChoCod = (int)(context.localUtil.CToN( cgiGet( "vCHOCOD"), ".", ","));
               AV13cChoCod = (int)(context.localUtil.CToN( cgiGet( "vCCHOCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
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
               A542ChoDsc = cgiGet( edtChoDsc_Internalname);
               AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
               A545ChoDir = cgiGet( edtChoDir_Internalname);
               AssignAttri("", false, "A545ChoDir", A545ChoDir);
               A550ChoTel = cgiGet( edtChoTel_Internalname);
               AssignAttri("", false, "A550ChoTel", A550ChoTel);
               A548ChoRuc = cgiGet( edtChoRuc_Internalname);
               AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
               A547ChoMarca = cgiGet( edtChoMarca_Internalname);
               AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
               A543ChoPlaca = cgiGet( edtChoPlaca_Internalname);
               AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
               A546ChoLicencia = cgiGet( edtChoLicencia_Internalname);
               AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
               A544ChoConsta = cgiGet( edtChoConsta_Internalname);
               AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
               cmbChoSts.CurrentValue = cgiGet( cmbChoSts_Internalname);
               A549ChoSts = (short)(NumberUtil.Val( cgiGet( cmbChoSts_Internalname), "."));
               AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHOCOD");
                  AnyError = 1;
                  GX_FocusControl = edtChoCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10ChoCod = 0;
                  AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               }
               else
               {
                  A10ChoCod = (int)(context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ","));
                  AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Choferes");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A10ChoCod != Z10ChoCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\choferes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A10ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
                  AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
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
                     sMode74 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode74;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound74 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CHOCOD");
                        AnyError = 1;
                        GX_FocusControl = edtChoCod_Internalname;
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
                           E115O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125O2 ();
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
            E125O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5O74( ) ;
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
            DisableAttributes5O74( ) ;
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

      protected void CONFIRM_5O0( )
      {
         BeforeValidate5O74( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5O74( ) ;
            }
            else
            {
               CheckExtendedTable5O74( ) ;
               CloseExtendedTableCursors5O74( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5O0( )
      {
      }

      protected void E115O2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtChoCod_Visible = 0;
         AssignProp("", false, edtChoCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtChoCod_Visible), 5, 0), true);
      }

      protected void E125O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Choferes N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A10ChoCod), 10, 0)) + " " + StringUtil.Trim( A542ChoDsc);
            AV16Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A10ChoCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV16Codigo, ref  AV16Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.choferesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5O74( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z542ChoDsc = T005O3_A542ChoDsc[0];
               Z545ChoDir = T005O3_A545ChoDir[0];
               Z550ChoTel = T005O3_A550ChoTel[0];
               Z548ChoRuc = T005O3_A548ChoRuc[0];
               Z547ChoMarca = T005O3_A547ChoMarca[0];
               Z543ChoPlaca = T005O3_A543ChoPlaca[0];
               Z546ChoLicencia = T005O3_A546ChoLicencia[0];
               Z544ChoConsta = T005O3_A544ChoConsta[0];
               Z549ChoSts = T005O3_A549ChoSts[0];
            }
            else
            {
               Z542ChoDsc = A542ChoDsc;
               Z545ChoDir = A545ChoDir;
               Z550ChoTel = A550ChoTel;
               Z548ChoRuc = A548ChoRuc;
               Z547ChoMarca = A547ChoMarca;
               Z543ChoPlaca = A543ChoPlaca;
               Z546ChoLicencia = A546ChoLicencia;
               Z544ChoConsta = A544ChoConsta;
               Z549ChoSts = A549ChoSts;
            }
         }
         if ( GX_JID == -10 )
         {
            Z10ChoCod = A10ChoCod;
            Z542ChoDsc = A542ChoDsc;
            Z545ChoDir = A545ChoDir;
            Z550ChoTel = A550ChoTel;
            Z548ChoRuc = A548ChoRuc;
            Z547ChoMarca = A547ChoMarca;
            Z543ChoPlaca = A543ChoPlaca;
            Z546ChoLicencia = A546ChoLicencia;
            Z544ChoConsta = A544ChoConsta;
            Z549ChoSts = A549ChoSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ChoCod) )
         {
            A10ChoCod = AV7ChoCod;
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         }
         if ( ! (0==AV7ChoCod) )
         {
            edtChoCod_Enabled = 0;
            AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
         }
         else
         {
            edtChoCod_Enabled = 1;
            AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7ChoCod) )
         {
            edtChoCod_Enabled = 0;
            AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A549ChoSts) && ( Gx_BScreen == 0 ) )
         {
            A549ChoSts = 1;
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         }
      }

      protected void Load5O74( )
      {
         /* Using cursor T005O4 */
         pr_default.execute(2, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound74 = 1;
            A542ChoDsc = T005O4_A542ChoDsc[0];
            AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
            A545ChoDir = T005O4_A545ChoDir[0];
            AssignAttri("", false, "A545ChoDir", A545ChoDir);
            A550ChoTel = T005O4_A550ChoTel[0];
            AssignAttri("", false, "A550ChoTel", A550ChoTel);
            A548ChoRuc = T005O4_A548ChoRuc[0];
            AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
            A547ChoMarca = T005O4_A547ChoMarca[0];
            AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
            A543ChoPlaca = T005O4_A543ChoPlaca[0];
            AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
            A546ChoLicencia = T005O4_A546ChoLicencia[0];
            AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
            A544ChoConsta = T005O4_A544ChoConsta[0];
            AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
            A549ChoSts = T005O4_A549ChoSts[0];
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
            ZM5O74( -10) ;
         }
         pr_default.close(2);
         OnLoadActions5O74( ) ;
      }

      protected void OnLoadActions5O74( )
      {
         A541ChoCompleto = StringUtil.Trim( A542ChoDsc) + " " + StringUtil.Trim( A543ChoPlaca);
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
      }

      protected void CheckExtendedTable5O74( )
      {
         nIsDirty_74 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         nIsDirty_74 = 1;
         A541ChoCompleto = StringUtil.Trim( A542ChoDsc) + " " + StringUtil.Trim( A543ChoPlaca);
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A542ChoDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Chofer", "", "", "", "", "", "", "", ""), 1, "CHODSC");
            AnyError = 1;
            GX_FocusControl = edtChoDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A545ChoDir)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Dirección", "", "", "", "", "", "", "", ""), 1, "CHODIR");
            AnyError = 1;
            GX_FocusControl = edtChoDir_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5O74( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5O74( )
      {
         /* Using cursor T005O5 */
         pr_default.execute(3, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005O3 */
         pr_default.execute(1, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5O74( 10) ;
            RcdFound74 = 1;
            A10ChoCod = T005O3_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            A542ChoDsc = T005O3_A542ChoDsc[0];
            AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
            A545ChoDir = T005O3_A545ChoDir[0];
            AssignAttri("", false, "A545ChoDir", A545ChoDir);
            A550ChoTel = T005O3_A550ChoTel[0];
            AssignAttri("", false, "A550ChoTel", A550ChoTel);
            A548ChoRuc = T005O3_A548ChoRuc[0];
            AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
            A547ChoMarca = T005O3_A547ChoMarca[0];
            AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
            A543ChoPlaca = T005O3_A543ChoPlaca[0];
            AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
            A546ChoLicencia = T005O3_A546ChoLicencia[0];
            AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
            A544ChoConsta = T005O3_A544ChoConsta[0];
            AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
            A549ChoSts = T005O3_A549ChoSts[0];
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
            Z10ChoCod = A10ChoCod;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5O74( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey5O74( ) ;
            }
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey5O74( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5O74( ) ;
         if ( RcdFound74 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound74 = 0;
         /* Using cursor T005O6 */
         pr_default.execute(4, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005O6_A10ChoCod[0] < A10ChoCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005O6_A10ChoCod[0] > A10ChoCod ) ) )
            {
               A10ChoCod = T005O6_A10ChoCod[0];
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound74 = 0;
         /* Using cursor T005O7 */
         pr_default.execute(5, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005O7_A10ChoCod[0] > A10ChoCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005O7_A10ChoCod[0] < A10ChoCod ) ) )
            {
               A10ChoCod = T005O7_A10ChoCod[0];
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5O74( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtChoDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5O74( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A10ChoCod != Z10ChoCod )
               {
                  A10ChoCod = Z10ChoCod;
                  AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CHOCOD");
                  AnyError = 1;
                  GX_FocusControl = edtChoCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtChoDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5O74( ) ;
                  GX_FocusControl = edtChoDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A10ChoCod != Z10ChoCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtChoDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5O74( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHOCOD");
                     AnyError = 1;
                     GX_FocusControl = edtChoCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtChoDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5O74( ) ;
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
         if ( A10ChoCod != Z10ChoCod )
         {
            A10ChoCod = Z10ChoCod;
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtChoDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5O74( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005O2 */
            pr_default.execute(0, new Object[] {A10ChoCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCHOFERES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z542ChoDsc, T005O2_A542ChoDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z545ChoDir, T005O2_A545ChoDir[0]) != 0 ) || ( StringUtil.StrCmp(Z550ChoTel, T005O2_A550ChoTel[0]) != 0 ) || ( StringUtil.StrCmp(Z548ChoRuc, T005O2_A548ChoRuc[0]) != 0 ) || ( StringUtil.StrCmp(Z547ChoMarca, T005O2_A547ChoMarca[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z543ChoPlaca, T005O2_A543ChoPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z546ChoLicencia, T005O2_A546ChoLicencia[0]) != 0 ) || ( StringUtil.StrCmp(Z544ChoConsta, T005O2_A544ChoConsta[0]) != 0 ) || ( Z549ChoSts != T005O2_A549ChoSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z542ChoDsc, T005O2_A542ChoDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoDsc");
                  GXUtil.WriteLogRaw("Old: ",Z542ChoDsc);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A542ChoDsc[0]);
               }
               if ( StringUtil.StrCmp(Z545ChoDir, T005O2_A545ChoDir[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoDir");
                  GXUtil.WriteLogRaw("Old: ",Z545ChoDir);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A545ChoDir[0]);
               }
               if ( StringUtil.StrCmp(Z550ChoTel, T005O2_A550ChoTel[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoTel");
                  GXUtil.WriteLogRaw("Old: ",Z550ChoTel);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A550ChoTel[0]);
               }
               if ( StringUtil.StrCmp(Z548ChoRuc, T005O2_A548ChoRuc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoRuc");
                  GXUtil.WriteLogRaw("Old: ",Z548ChoRuc);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A548ChoRuc[0]);
               }
               if ( StringUtil.StrCmp(Z547ChoMarca, T005O2_A547ChoMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoMarca");
                  GXUtil.WriteLogRaw("Old: ",Z547ChoMarca);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A547ChoMarca[0]);
               }
               if ( StringUtil.StrCmp(Z543ChoPlaca, T005O2_A543ChoPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z543ChoPlaca);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A543ChoPlaca[0]);
               }
               if ( StringUtil.StrCmp(Z546ChoLicencia, T005O2_A546ChoLicencia[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoLicencia");
                  GXUtil.WriteLogRaw("Old: ",Z546ChoLicencia);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A546ChoLicencia[0]);
               }
               if ( StringUtil.StrCmp(Z544ChoConsta, T005O2_A544ChoConsta[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoConsta");
                  GXUtil.WriteLogRaw("Old: ",Z544ChoConsta);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A544ChoConsta[0]);
               }
               if ( Z549ChoSts != T005O2_A549ChoSts[0] )
               {
                  GXUtil.WriteLog("configuracion.choferes:[seudo value changed for attri]"+"ChoSts");
                  GXUtil.WriteLogRaw("Old: ",Z549ChoSts);
                  GXUtil.WriteLogRaw("Current: ",T005O2_A549ChoSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CCHOFERES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5O74( )
      {
         BeforeValidate5O74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5O74( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5O74( 0) ;
            CheckOptimisticConcurrency5O74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5O74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5O74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005O8 */
                     pr_default.execute(6, new Object[] {A10ChoCod, A542ChoDsc, A545ChoDir, A550ChoTel, A548ChoRuc, A547ChoMarca, A543ChoPlaca, A546ChoLicencia, A544ChoConsta, A549ChoSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CCHOFERES");
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
                           ResetCaption5O0( ) ;
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
               Load5O74( ) ;
            }
            EndLevel5O74( ) ;
         }
         CloseExtendedTableCursors5O74( ) ;
      }

      protected void Update5O74( )
      {
         BeforeValidate5O74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5O74( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5O74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5O74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5O74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005O9 */
                     pr_default.execute(7, new Object[] {A542ChoDsc, A545ChoDir, A550ChoTel, A548ChoRuc, A547ChoMarca, A543ChoPlaca, A546ChoLicencia, A544ChoConsta, A549ChoSts, A10ChoCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CCHOFERES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCHOFERES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5O74( ) ;
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
            EndLevel5O74( ) ;
         }
         CloseExtendedTableCursors5O74( ) ;
      }

      protected void DeferredUpdate5O74( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5O74( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5O74( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5O74( ) ;
            AfterConfirm5O74( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5O74( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005O10 */
                  pr_default.execute(8, new Object[] {A10ChoCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CCHOFERES");
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5O74( ) ;
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5O74( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A541ChoCompleto = StringUtil.Trim( A542ChoDsc) + " " + StringUtil.Trim( A543ChoPlaca);
            AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005O11 */
            pr_default.execute(9, new Object[] {A10ChoCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005O12 */
            pr_default.execute(10, new Object[] {A10ChoCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Despacho"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel5O74( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5O74( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.choferes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.choferes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5O74( )
      {
         /* Scan By routine */
         /* Using cursor T005O13 */
         pr_default.execute(11);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A10ChoCod = T005O13_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5O74( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A10ChoCod = T005O13_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         }
      }

      protected void ScanEnd5O74( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm5O74( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cChoCod;
            GXt_char3 = "CHOFERES";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cChoCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cChoCod", StringUtil.LTrimStr( (decimal)(AV13cChoCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A10ChoCod = AV13cChoCod;
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         }
      }

      protected void BeforeInsert5O74( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5O74( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5O74( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5O74( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5O74( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5O74( )
      {
         edtChoDsc_Enabled = 0;
         AssignProp("", false, edtChoDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoDsc_Enabled), 5, 0), true);
         edtChoDir_Enabled = 0;
         AssignProp("", false, edtChoDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoDir_Enabled), 5, 0), true);
         edtChoTel_Enabled = 0;
         AssignProp("", false, edtChoTel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoTel_Enabled), 5, 0), true);
         edtChoRuc_Enabled = 0;
         AssignProp("", false, edtChoRuc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoRuc_Enabled), 5, 0), true);
         edtChoMarca_Enabled = 0;
         AssignProp("", false, edtChoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoMarca_Enabled), 5, 0), true);
         edtChoPlaca_Enabled = 0;
         AssignProp("", false, edtChoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoPlaca_Enabled), 5, 0), true);
         edtChoLicencia_Enabled = 0;
         AssignProp("", false, edtChoLicencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoLicencia_Enabled), 5, 0), true);
         edtChoConsta_Enabled = 0;
         AssignProp("", false, edtChoConsta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoConsta_Enabled), 5, 0), true);
         cmbChoSts.Enabled = 0;
         AssignProp("", false, cmbChoSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChoSts.Enabled), 5, 0), true);
         edtChoCod_Enabled = 0;
         AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5O74( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5O0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810261128", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         GXEncryptionTmp = "configuracion.choferes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ChoCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.choferes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Choferes");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\choferes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z542ChoDsc", StringUtil.RTrim( Z542ChoDsc));
         GxWebStd.gx_hidden_field( context, "Z545ChoDir", StringUtil.RTrim( Z545ChoDir));
         GxWebStd.gx_hidden_field( context, "Z550ChoTel", StringUtil.RTrim( Z550ChoTel));
         GxWebStd.gx_hidden_field( context, "Z548ChoRuc", StringUtil.RTrim( Z548ChoRuc));
         GxWebStd.gx_hidden_field( context, "Z547ChoMarca", StringUtil.RTrim( Z547ChoMarca));
         GxWebStd.gx_hidden_field( context, "Z543ChoPlaca", StringUtil.RTrim( Z543ChoPlaca));
         GxWebStd.gx_hidden_field( context, "Z546ChoLicencia", StringUtil.RTrim( Z546ChoLicencia));
         GxWebStd.gx_hidden_field( context, "Z544ChoConsta", StringUtil.RTrim( Z544ChoConsta));
         GxWebStd.gx_hidden_field( context, "Z549ChoSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z549ChoSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "CHOCOMPLETO", A541ChoCompleto);
         GxWebStd.gx_hidden_field( context, "vCHOCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCHOCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ChoCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCCHOCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.choferes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ChoCod,6,0));
         return formatLink("configuracion.choferes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Choferes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Choferes" ;
      }

      protected void InitializeNonKey5O74( )
      {
         AV13cChoCod = 0;
         AssignAttri("", false, "AV13cChoCod", StringUtil.LTrimStr( (decimal)(AV13cChoCod), 6, 0));
         A541ChoCompleto = "";
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
         A542ChoDsc = "";
         AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
         A545ChoDir = "";
         AssignAttri("", false, "A545ChoDir", A545ChoDir);
         A550ChoTel = "";
         AssignAttri("", false, "A550ChoTel", A550ChoTel);
         A548ChoRuc = "";
         AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
         A547ChoMarca = "";
         AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
         A543ChoPlaca = "";
         AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
         A546ChoLicencia = "";
         AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
         A544ChoConsta = "";
         AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
         A549ChoSts = 1;
         AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         Z542ChoDsc = "";
         Z545ChoDir = "";
         Z550ChoTel = "";
         Z548ChoRuc = "";
         Z547ChoMarca = "";
         Z543ChoPlaca = "";
         Z546ChoLicencia = "";
         Z544ChoConsta = "";
         Z549ChoSts = 0;
      }

      protected void InitAll5O74( )
      {
         A10ChoCod = 0;
         AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         InitializeNonKey5O74( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A549ChoSts = i549ChoSts;
         AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261148", true, true);
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
         context.AddJavascriptSource("configuracion/choferes.js", "?202281810261148", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtChoDsc_Internalname = "CHODSC";
         edtChoDir_Internalname = "CHODIR";
         edtChoTel_Internalname = "CHOTEL";
         edtChoRuc_Internalname = "CHORUC";
         edtChoMarca_Internalname = "CHOMARCA";
         edtChoPlaca_Internalname = "CHOPLACA";
         edtChoLicencia_Internalname = "CHOLICENCIA";
         edtChoConsta_Internalname = "CHOCONSTA";
         cmbChoSts_Internalname = "CHOSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtChoCod_Internalname = "CHOCOD";
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
         Form.Caption = "Choferes";
         edtChoCod_Jsonclick = "";
         edtChoCod_Enabled = 1;
         edtChoCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbChoSts_Jsonclick = "";
         cmbChoSts.Enabled = 1;
         edtChoConsta_Jsonclick = "";
         edtChoConsta_Enabled = 1;
         edtChoLicencia_Jsonclick = "";
         edtChoLicencia_Enabled = 1;
         edtChoPlaca_Jsonclick = "";
         edtChoPlaca_Enabled = 1;
         edtChoMarca_Jsonclick = "";
         edtChoMarca_Enabled = 1;
         edtChoRuc_Jsonclick = "";
         edtChoRuc_Enabled = 1;
         edtChoTel_Jsonclick = "";
         edtChoTel_Enabled = 1;
         edtChoDir_Jsonclick = "";
         edtChoDir_Enabled = 1;
         edtChoDsc_Jsonclick = "";
         edtChoDsc_Enabled = 1;
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

      protected void GX5ASACCHOCOD5O74( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cChoCod;
            GXt_char3 = "CHOFERES";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cChoCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cChoCod", StringUtil.LTrimStr( (decimal)(AV13cChoCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cChoCod), 6, 0, ".", "")))+"\"") ;
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
         cmbChoSts.Name = "CHOSTS";
         cmbChoSts.WebTags = "";
         cmbChoSts.addItem("1", "ACTIVO", 0);
         cmbChoSts.addItem("0", "INACTIVO", 0);
         if ( cmbChoSts.ItemCount > 0 )
         {
            if ( (0==A549ChoSts) )
            {
               A549ChoSts = 1;
               AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ChoCod',fld:'vCHOCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ChoCod',fld:'vCHOCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125O2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A10ChoCod',fld:'CHOCOD',pic:'ZZZZZ9'},{av:'A542ChoDsc',fld:'CHODSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CHODSC","{handler:'Valid_Chodsc',iparms:[]");
         setEventMetadata("VALID_CHODSC",",oparms:[]}");
         setEventMetadata("VALID_CHODIR","{handler:'Valid_Chodir',iparms:[]");
         setEventMetadata("VALID_CHODIR",",oparms:[]}");
         setEventMetadata("VALID_CHOPLACA","{handler:'Valid_Choplaca',iparms:[]");
         setEventMetadata("VALID_CHOPLACA",",oparms:[]}");
         setEventMetadata("VALID_CHOCOD","{handler:'Valid_Chocod',iparms:[]");
         setEventMetadata("VALID_CHOCOD",",oparms:[]}");
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
         Z542ChoDsc = "";
         Z545ChoDir = "";
         Z550ChoTel = "";
         Z548ChoRuc = "";
         Z547ChoMarca = "";
         Z543ChoPlaca = "";
         Z546ChoLicencia = "";
         Z544ChoConsta = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A542ChoDsc = "";
         A545ChoDir = "";
         A550ChoTel = "";
         A548ChoRuc = "";
         A547ChoMarca = "";
         A543ChoPlaca = "";
         A546ChoLicencia = "";
         A544ChoConsta = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A541ChoCompleto = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode74 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14SGAuDocGls = "";
         AV16Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T005O4_A10ChoCod = new int[1] ;
         T005O4_A542ChoDsc = new string[] {""} ;
         T005O4_A545ChoDir = new string[] {""} ;
         T005O4_A550ChoTel = new string[] {""} ;
         T005O4_A548ChoRuc = new string[] {""} ;
         T005O4_A547ChoMarca = new string[] {""} ;
         T005O4_A543ChoPlaca = new string[] {""} ;
         T005O4_A546ChoLicencia = new string[] {""} ;
         T005O4_A544ChoConsta = new string[] {""} ;
         T005O4_A549ChoSts = new short[1] ;
         T005O5_A10ChoCod = new int[1] ;
         T005O3_A10ChoCod = new int[1] ;
         T005O3_A542ChoDsc = new string[] {""} ;
         T005O3_A545ChoDir = new string[] {""} ;
         T005O3_A550ChoTel = new string[] {""} ;
         T005O3_A548ChoRuc = new string[] {""} ;
         T005O3_A547ChoMarca = new string[] {""} ;
         T005O3_A543ChoPlaca = new string[] {""} ;
         T005O3_A546ChoLicencia = new string[] {""} ;
         T005O3_A544ChoConsta = new string[] {""} ;
         T005O3_A549ChoSts = new short[1] ;
         T005O6_A10ChoCod = new int[1] ;
         T005O7_A10ChoCod = new int[1] ;
         T005O2_A10ChoCod = new int[1] ;
         T005O2_A542ChoDsc = new string[] {""} ;
         T005O2_A545ChoDir = new string[] {""} ;
         T005O2_A550ChoTel = new string[] {""} ;
         T005O2_A548ChoRuc = new string[] {""} ;
         T005O2_A547ChoMarca = new string[] {""} ;
         T005O2_A543ChoPlaca = new string[] {""} ;
         T005O2_A546ChoLicencia = new string[] {""} ;
         T005O2_A544ChoConsta = new string[] {""} ;
         T005O2_A549ChoSts = new short[1] ;
         T005O11_A13MvATip = new string[] {""} ;
         T005O11_A14MvACod = new string[] {""} ;
         T005O12_A8DesCod = new string[] {""} ;
         T005O13_A10ChoCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.choferes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.choferes__default(),
            new Object[][] {
                new Object[] {
               T005O2_A10ChoCod, T005O2_A542ChoDsc, T005O2_A545ChoDir, T005O2_A550ChoTel, T005O2_A548ChoRuc, T005O2_A547ChoMarca, T005O2_A543ChoPlaca, T005O2_A546ChoLicencia, T005O2_A544ChoConsta, T005O2_A549ChoSts
               }
               , new Object[] {
               T005O3_A10ChoCod, T005O3_A542ChoDsc, T005O3_A545ChoDir, T005O3_A550ChoTel, T005O3_A548ChoRuc, T005O3_A547ChoMarca, T005O3_A543ChoPlaca, T005O3_A546ChoLicencia, T005O3_A544ChoConsta, T005O3_A549ChoSts
               }
               , new Object[] {
               T005O4_A10ChoCod, T005O4_A542ChoDsc, T005O4_A545ChoDir, T005O4_A550ChoTel, T005O4_A548ChoRuc, T005O4_A547ChoMarca, T005O4_A543ChoPlaca, T005O4_A546ChoLicencia, T005O4_A544ChoConsta, T005O4_A549ChoSts
               }
               , new Object[] {
               T005O5_A10ChoCod
               }
               , new Object[] {
               T005O6_A10ChoCod
               }
               , new Object[] {
               T005O7_A10ChoCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005O11_A13MvATip, T005O11_A14MvACod
               }
               , new Object[] {
               T005O12_A8DesCod
               }
               , new Object[] {
               T005O13_A10ChoCod
               }
            }
         );
         Z549ChoSts = 1;
         A549ChoSts = 1;
         i549ChoSts = 1;
      }

      private short Z549ChoSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A549ChoSts ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private short GX_JID ;
      private short nIsDirty_74 ;
      private short gxajaxcallmode ;
      private short i549ChoSts ;
      private int wcpOAV7ChoCod ;
      private int Z10ChoCod ;
      private int AV7ChoCod ;
      private int trnEnded ;
      private int edtChoDsc_Enabled ;
      private int edtChoDir_Enabled ;
      private int edtChoTel_Enabled ;
      private int edtChoRuc_Enabled ;
      private int edtChoMarca_Enabled ;
      private int edtChoPlaca_Enabled ;
      private int edtChoLicencia_Enabled ;
      private int edtChoConsta_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A10ChoCod ;
      private int edtChoCod_Visible ;
      private int edtChoCod_Enabled ;
      private int AV13cChoCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z542ChoDsc ;
      private string Z545ChoDir ;
      private string Z550ChoTel ;
      private string Z548ChoRuc ;
      private string Z547ChoMarca ;
      private string Z543ChoPlaca ;
      private string Z546ChoLicencia ;
      private string Z544ChoConsta ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtChoDsc_Internalname ;
      private string cmbChoSts_Internalname ;
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
      private string A542ChoDsc ;
      private string edtChoDsc_Jsonclick ;
      private string edtChoDir_Internalname ;
      private string A545ChoDir ;
      private string edtChoDir_Jsonclick ;
      private string edtChoTel_Internalname ;
      private string A550ChoTel ;
      private string edtChoTel_Jsonclick ;
      private string edtChoRuc_Internalname ;
      private string A548ChoRuc ;
      private string edtChoRuc_Jsonclick ;
      private string edtChoMarca_Internalname ;
      private string A547ChoMarca ;
      private string edtChoMarca_Jsonclick ;
      private string edtChoPlaca_Internalname ;
      private string A543ChoPlaca ;
      private string edtChoPlaca_Jsonclick ;
      private string edtChoLicencia_Internalname ;
      private string A546ChoLicencia ;
      private string edtChoLicencia_Jsonclick ;
      private string edtChoConsta_Internalname ;
      private string A544ChoConsta ;
      private string edtChoConsta_Jsonclick ;
      private string cmbChoSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtChoCod_Internalname ;
      private string edtChoCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode74 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char3 ;
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
      private bool Gx_longc ;
      private string A541ChoCompleto ;
      private string AV14SGAuDocGls ;
      private string AV16Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbChoSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005O4_A10ChoCod ;
      private string[] T005O4_A542ChoDsc ;
      private string[] T005O4_A545ChoDir ;
      private string[] T005O4_A550ChoTel ;
      private string[] T005O4_A548ChoRuc ;
      private string[] T005O4_A547ChoMarca ;
      private string[] T005O4_A543ChoPlaca ;
      private string[] T005O4_A546ChoLicencia ;
      private string[] T005O4_A544ChoConsta ;
      private short[] T005O4_A549ChoSts ;
      private int[] T005O5_A10ChoCod ;
      private int[] T005O3_A10ChoCod ;
      private string[] T005O3_A542ChoDsc ;
      private string[] T005O3_A545ChoDir ;
      private string[] T005O3_A550ChoTel ;
      private string[] T005O3_A548ChoRuc ;
      private string[] T005O3_A547ChoMarca ;
      private string[] T005O3_A543ChoPlaca ;
      private string[] T005O3_A546ChoLicencia ;
      private string[] T005O3_A544ChoConsta ;
      private short[] T005O3_A549ChoSts ;
      private int[] T005O6_A10ChoCod ;
      private int[] T005O7_A10ChoCod ;
      private int[] T005O2_A10ChoCod ;
      private string[] T005O2_A542ChoDsc ;
      private string[] T005O2_A545ChoDir ;
      private string[] T005O2_A550ChoTel ;
      private string[] T005O2_A548ChoRuc ;
      private string[] T005O2_A547ChoMarca ;
      private string[] T005O2_A543ChoPlaca ;
      private string[] T005O2_A546ChoLicencia ;
      private string[] T005O2_A544ChoConsta ;
      private short[] T005O2_A549ChoSts ;
      private string[] T005O11_A13MvATip ;
      private string[] T005O11_A14MvACod ;
      private string[] T005O12_A8DesCod ;
      private int[] T005O13_A10ChoCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class choferes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class choferes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005O4;
        prmT005O4 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O5;
        prmT005O5 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O3;
        prmT005O3 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O6;
        prmT005O6 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O7;
        prmT005O7 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O2;
        prmT005O2 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O8;
        prmT005O8 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0) ,
        new ParDef("@ChoDsc",GXType.NChar,100,0) ,
        new ParDef("@ChoDir",GXType.NChar,100,0) ,
        new ParDef("@ChoTel",GXType.NChar,20,0) ,
        new ParDef("@ChoRuc",GXType.NChar,20,0) ,
        new ParDef("@ChoMarca",GXType.NChar,30,0) ,
        new ParDef("@ChoPlaca",GXType.NChar,20,0) ,
        new ParDef("@ChoLicencia",GXType.NChar,20,0) ,
        new ParDef("@ChoConsta",GXType.NChar,20,0) ,
        new ParDef("@ChoSts",GXType.Int16,1,0)
        };
        Object[] prmT005O9;
        prmT005O9 = new Object[] {
        new ParDef("@ChoDsc",GXType.NChar,100,0) ,
        new ParDef("@ChoDir",GXType.NChar,100,0) ,
        new ParDef("@ChoTel",GXType.NChar,20,0) ,
        new ParDef("@ChoRuc",GXType.NChar,20,0) ,
        new ParDef("@ChoMarca",GXType.NChar,30,0) ,
        new ParDef("@ChoPlaca",GXType.NChar,20,0) ,
        new ParDef("@ChoLicencia",GXType.NChar,20,0) ,
        new ParDef("@ChoConsta",GXType.NChar,20,0) ,
        new ParDef("@ChoSts",GXType.Int16,1,0) ,
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O10;
        prmT005O10 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O11;
        prmT005O11 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O12;
        prmT005O12 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT005O13;
        prmT005O13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005O2", "SELECT [ChoCod], [ChoDsc], [ChoDir], [ChoTel], [ChoRuc], [ChoMarca], [ChoPlaca], [ChoLicencia], [ChoConsta], [ChoSts] FROM [CCHOFERES] WITH (UPDLOCK) WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005O3", "SELECT [ChoCod], [ChoDsc], [ChoDir], [ChoTel], [ChoRuc], [ChoMarca], [ChoPlaca], [ChoLicencia], [ChoConsta], [ChoSts] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005O4", "SELECT TM1.[ChoCod], TM1.[ChoDsc], TM1.[ChoDir], TM1.[ChoTel], TM1.[ChoRuc], TM1.[ChoMarca], TM1.[ChoPlaca], TM1.[ChoLicencia], TM1.[ChoConsta], TM1.[ChoSts] FROM [CCHOFERES] TM1 WHERE TM1.[ChoCod] = @ChoCod ORDER BY TM1.[ChoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005O4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005O5", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005O6", "SELECT TOP 1 [ChoCod] FROM [CCHOFERES] WHERE ( [ChoCod] > @ChoCod) ORDER BY [ChoCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005O6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005O7", "SELECT TOP 1 [ChoCod] FROM [CCHOFERES] WHERE ( [ChoCod] < @ChoCod) ORDER BY [ChoCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005O7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005O8", "INSERT INTO [CCHOFERES]([ChoCod], [ChoDsc], [ChoDir], [ChoTel], [ChoRuc], [ChoMarca], [ChoPlaca], [ChoLicencia], [ChoConsta], [ChoSts]) VALUES(@ChoCod, @ChoDsc, @ChoDir, @ChoTel, @ChoRuc, @ChoMarca, @ChoPlaca, @ChoLicencia, @ChoConsta, @ChoSts)", GxErrorMask.GX_NOMASK,prmT005O8)
           ,new CursorDef("T005O9", "UPDATE [CCHOFERES] SET [ChoDsc]=@ChoDsc, [ChoDir]=@ChoDir, [ChoTel]=@ChoTel, [ChoRuc]=@ChoRuc, [ChoMarca]=@ChoMarca, [ChoPlaca]=@ChoPlaca, [ChoLicencia]=@ChoLicencia, [ChoConsta]=@ChoConsta, [ChoSts]=@ChoSts  WHERE [ChoCod] = @ChoCod", GxErrorMask.GX_NOMASK,prmT005O9)
           ,new CursorDef("T005O10", "DELETE FROM [CCHOFERES]  WHERE [ChoCod] = @ChoCod", GxErrorMask.GX_NOMASK,prmT005O10)
           ,new CursorDef("T005O11", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005O11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005O12", "SELECT TOP 1 [DesCod] FROM [ADESPACHO] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005O12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005O13", "SELECT [ChoCod] FROM [CCHOFERES] ORDER BY [ChoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005O13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
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
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
