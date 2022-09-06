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
   public class notificaciones : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"vCSGNOTIFICACIONID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASACSGNOTIFICACIONID7A198( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A2241SGNotificacionUsuario = GetPar( "SGNotificacionUsuario");
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A2241SGNotificacionUsuario) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A2246SGNotificacionDetUsuario = GetPar( "SGNotificacionDetUsuario");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A2246SGNotificacionDetUsuario) ;
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
            nRC_GXsfl_59 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_59"), "."));
            nGXsfl_59_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_59_idx"), "."));
            sGXsfl_59_idx = GetPar( "sGXsfl_59_idx");
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.notificaciones.aspx")), "seguridad.notificaciones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.notificaciones.aspx")))) ;
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
                  AV7SGNotificacionID = (long)(NumberUtil.Val( GetPar( "SGNotificacionID"), "."));
                  AssignAttri("", false, "AV7SGNotificacionID", StringUtil.LTrimStr( (decimal)(AV7SGNotificacionID), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSGNOTIFICACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SGNotificacionID), "ZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Notificaciones", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public notificaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SGNotificacionID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SGNotificacionID = aP1_SGNotificacionID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbSGNotificacionIconClass = new GXCombobox();
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
         if ( cmbSGNotificacionIconClass.ItemCount > 0 )
         {
            A2243SGNotificacionIconClass = cmbSGNotificacionIconClass.getValidValue(A2243SGNotificacionIconClass);
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSGNotificacionIconClass.CurrentValue = StringUtil.RTrim( A2243SGNotificacionIconClass);
            AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Values", cmbSGNotificacionIconClass.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2237SGNotificacionID), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionID_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionTitulo_Internalname, "Titulo", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionTitulo_Internalname, A2238SGNotificacionTitulo, StringUtil.RTrim( context.localUtil.Format( A2238SGNotificacionTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionTitulo_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtSGNotificacionTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionDescripcion_Internalname, "Descripción", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeRealWidth";
         StyleString = "";
         ClassString = "AttributeRealWidth";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSGNotificacionDescripcion_Internalname, A2239SGNotificacionDescripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, 1, edtSGNotificacionDescripcion_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionFecha_Internalname, "Hora", "col-sm-3 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSGNotificacionFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionFecha_Internalname, context.localUtil.TToC( A2240SGNotificacionFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2240SGNotificacionFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionFecha_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtSGNotificacionFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_bitmap( context, edtSGNotificacionFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSGNotificacionFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Seguridad\\Notificaciones.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsgnotificacionusuario_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksgnotificacionusuario_Internalname, "Usuario", "", "", lblTextblocksgnotificacionusuario_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_sgnotificacionusuario.SetProperty("Caption", Combo_sgnotificacionusuario_Caption);
         ucCombo_sgnotificacionusuario.SetProperty("Cls", Combo_sgnotificacionusuario_Cls);
         ucCombo_sgnotificacionusuario.SetProperty("DataListProc", Combo_sgnotificacionusuario_Datalistproc);
         ucCombo_sgnotificacionusuario.SetProperty("DataListProcParametersPrefix", Combo_sgnotificacionusuario_Datalistprocparametersprefix);
         ucCombo_sgnotificacionusuario.SetProperty("EmptyItem", Combo_sgnotificacionusuario_Emptyitem);
         ucCombo_sgnotificacionusuario.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_sgnotificacionusuario.SetProperty("DropDownOptionsData", AV13SGNotificacionUsuario_Data);
         ucCombo_sgnotificacionusuario.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sgnotificacionusuario_Internalname, "COMBO_SGNOTIFICACIONUSUARIOContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionUsuario_Internalname, "Usuario", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionUsuario_Internalname, StringUtil.RTrim( A2241SGNotificacionUsuario), StringUtil.RTrim( context.localUtil.Format( A2241SGNotificacionUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionUsuario_Jsonclick, 0, "Attribute", "", "", "", "", edtSGNotificacionUsuario_Visible, edtSGNotificacionUsuario_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Notificaciones.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbSGNotificacionIconClass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSGNotificacionIconClass_Internalname, "Icon Class", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSGNotificacionIconClass, cmbSGNotificacionIconClass_Internalname, StringUtil.RTrim( A2243SGNotificacionIconClass), 1, cmbSGNotificacionIconClass_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbSGNotificacionIconClass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 1, "HLP_Seguridad\\Notificaciones.htm");
         cmbSGNotificacionIconClass.CurrentValue = StringUtil.RTrim( A2243SGNotificacionIconClass);
         AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Values", (string)(cmbSGNotificacionIconClass.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Notificaciones.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_sgnotificacionusuario_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombosgnotificacionusuario_Internalname, StringUtil.RTrim( AV18ComboSGNotificacionUsuario), StringUtil.RTrim( context.localUtil.Format( AV18ComboSGNotificacionUsuario, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosgnotificacionusuario_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosgnotificacionusuario_Visible, edtavCombosgnotificacionusuario_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Notificaciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* User Defined Control */
         ucCombo_sgnotificaciondetusuario.SetProperty("Caption", Combo_sgnotificaciondetusuario_Caption);
         ucCombo_sgnotificaciondetusuario.SetProperty("Cls", Combo_sgnotificaciondetusuario_Cls);
         ucCombo_sgnotificaciondetusuario.SetProperty("IsGridItem", Combo_sgnotificaciondetusuario_Isgriditem);
         ucCombo_sgnotificaciondetusuario.SetProperty("HasDescription", Combo_sgnotificaciondetusuario_Hasdescription);
         ucCombo_sgnotificaciondetusuario.SetProperty("DataListProc", Combo_sgnotificaciondetusuario_Datalistproc);
         ucCombo_sgnotificaciondetusuario.SetProperty("DataListProcParametersPrefix", Combo_sgnotificaciondetusuario_Datalistprocparametersprefix);
         ucCombo_sgnotificaciondetusuario.SetProperty("EmptyItem", Combo_sgnotificaciondetusuario_Emptyitem);
         ucCombo_sgnotificaciondetusuario.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_sgnotificaciondetusuario.SetProperty("DropDownOptionsData", AV20SGNotificacionDetUsuario_Data);
         ucCombo_sgnotificaciondetusuario.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sgnotificaciondetusuario_Internalname, "COMBO_SGNOTIFICACIONDETUSUARIOContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionTUsuario_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2244SGNotificacionTUsuario), 4, 0, ".", "")), StringUtil.LTrim( ((edtSGNotificacionTUsuario_Enabled!=0) ? context.localUtil.Format( (decimal)(A2244SGNotificacionTUsuario), "ZZZ9") : context.localUtil.Format( (decimal)(A2244SGNotificacionTUsuario), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionTUsuario_Jsonclick, 0, "Attribute", "", "", "", "", edtSGNotificacionTUsuario_Visible, edtSGNotificacionTUsuario_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Notificaciones.htm");
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
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2245SGNotificacionDetID), 4, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A2246SGNotificacionDetUsuario));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2248SGNotificacionDetEstado), 1, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectedindex), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowselection), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowhovering), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_59_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount199 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_199 = 1;
               ScanStart7A199( ) ;
               while ( RcdFound199 != 0 )
               {
                  init_level_properties199( ) ;
                  getByPrimaryKey7A199( ) ;
                  AddRow7A199( ) ;
                  ScanNext7A199( ) ;
               }
               ScanEnd7A199( ) ;
               nBlankRcdCount199 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal7A199( ) ;
            standaloneModal7A199( ) ;
            sMode199 = Gx_mode;
            while ( nGXsfl_59_idx < nRC_GXsfl_59 )
            {
               bGXsfl_59_Refreshing = true;
               ReadRow7A199( ) ;
               edtSGNotificacionDetID_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETID_"+sGXsfl_59_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtSGNotificacionDetID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0), !bGXsfl_59_Refreshing);
               edtSGNotificacionDetUsuario_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtSGNotificacionDetUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0), !bGXsfl_59_Refreshing);
               edtSGNotificacionDetUsuarioDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtSGNotificacionDetUsuarioDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0), !bGXsfl_59_Refreshing);
               edtSGNotificacionDetEstado_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtSGNotificacionDetEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0), !bGXsfl_59_Refreshing);
               if ( ( nRcdExists_199 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal7A199( ) ;
               }
               SendRow7A199( ) ;
               bGXsfl_59_Refreshing = false;
            }
            Gx_mode = sMode199;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount199 = 5;
            nRcdExists_199 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart7A199( ) ;
               while ( RcdFound199 != 0 )
               {
                  sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_59199( ) ;
                  init_level_properties199( ) ;
                  standaloneNotModal7A199( ) ;
                  getByPrimaryKey7A199( ) ;
                  standaloneModal7A199( ) ;
                  AddRow7A199( ) ;
                  ScanNext7A199( ) ;
               }
               ScanEnd7A199( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode199 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx+1), 4, 0), 4, "0");
            SubsflControlProps_59199( ) ;
            InitAll7A199( ) ;
            init_level_properties199( ) ;
            nRcdExists_199 = 0;
            nIsMod_199 = 0;
            nRcdDeleted_199 = 0;
            nBlankRcdCount199 = (short)(nBlankRcdUsr199+nBlankRcdCount199);
            fRowAdded = 0;
            while ( nBlankRcdCount199 > 0 )
            {
               standaloneNotModal7A199( ) ;
               standaloneModal7A199( ) ;
               AddRow7A199( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtSGNotificacionDetID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount199 = (short)(nBlankRcdCount199-1);
            }
            Gx_mode = sMode199;
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
         E117A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSGNOTIFICACIONUSUARIO_DATA"), AV13SGNotificacionUsuario_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSGNOTIFICACIONDETUSUARIO_DATA"), AV20SGNotificacionDetUsuario_Data);
               /* Read saved values. */
               Z2237SGNotificacionID = (long)(context.localUtil.CToN( cgiGet( "Z2237SGNotificacionID"), ".", ","));
               Z2238SGNotificacionTitulo = cgiGet( "Z2238SGNotificacionTitulo");
               Z2239SGNotificacionDescripcion = cgiGet( "Z2239SGNotificacionDescripcion");
               Z2240SGNotificacionFecha = context.localUtil.CToT( cgiGet( "Z2240SGNotificacionFecha"), 0);
               Z2243SGNotificacionIconClass = cgiGet( "Z2243SGNotificacionIconClass");
               Z2244SGNotificacionTUsuario = (short)(context.localUtil.CToN( cgiGet( "Z2244SGNotificacionTUsuario"), ".", ","));
               Z2241SGNotificacionUsuario = cgiGet( "Z2241SGNotificacionUsuario");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_59 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_59"), ".", ","));
               N2241SGNotificacionUsuario = cgiGet( "N2241SGNotificacionUsuario");
               AV7SGNotificacionID = (long)(context.localUtil.CToN( cgiGet( "vSGNOTIFICACIONID"), ".", ","));
               AV21cSGNotificacionID = (long)(context.localUtil.CToN( cgiGet( "vCSGNOTIFICACIONID"), ".", ","));
               AV11Insert_SGNotificacionUsuario = cgiGet( "vINSERT_SGNOTIFICACIONUSUARIO");
               A2242SGNotificacionUsuarioDsc = cgiGet( "SGNOTIFICACIONUSUARIODSC");
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_sgnotificacionusuario_Objectcall = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Objectcall");
               Combo_sgnotificacionusuario_Class = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Class");
               Combo_sgnotificacionusuario_Icontype = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Icontype");
               Combo_sgnotificacionusuario_Icon = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Icon");
               Combo_sgnotificacionusuario_Caption = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Caption");
               Combo_sgnotificacionusuario_Tooltip = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Tooltip");
               Combo_sgnotificacionusuario_Cls = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Cls");
               Combo_sgnotificacionusuario_Selectedvalue_set = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Selectedvalue_set");
               Combo_sgnotificacionusuario_Selectedvalue_get = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Selectedvalue_get");
               Combo_sgnotificacionusuario_Selectedtext_set = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Selectedtext_set");
               Combo_sgnotificacionusuario_Selectedtext_get = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Selectedtext_get");
               Combo_sgnotificacionusuario_Gamoauthtoken = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Gamoauthtoken");
               Combo_sgnotificacionusuario_Ddointernalname = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Ddointernalname");
               Combo_sgnotificacionusuario_Titlecontrolalign = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Titlecontrolalign");
               Combo_sgnotificacionusuario_Dropdownoptionstype = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Dropdownoptionstype");
               Combo_sgnotificacionusuario_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Enabled"));
               Combo_sgnotificacionusuario_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Visible"));
               Combo_sgnotificacionusuario_Titlecontrolidtoreplace = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Titlecontrolidtoreplace");
               Combo_sgnotificacionusuario_Datalisttype = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Datalisttype");
               Combo_sgnotificacionusuario_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Allowmultipleselection"));
               Combo_sgnotificacionusuario_Datalistfixedvalues = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Datalistfixedvalues");
               Combo_sgnotificacionusuario_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Isgriditem"));
               Combo_sgnotificacionusuario_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Hasdescription"));
               Combo_sgnotificacionusuario_Datalistproc = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Datalistproc");
               Combo_sgnotificacionusuario_Datalistprocparametersprefix = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Datalistprocparametersprefix");
               Combo_sgnotificacionusuario_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Datalistupdateminimumcharacters"), ".", ","));
               Combo_sgnotificacionusuario_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Includeonlyselectedoption"));
               Combo_sgnotificacionusuario_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Includeselectalloption"));
               Combo_sgnotificacionusuario_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Emptyitem"));
               Combo_sgnotificacionusuario_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Includeaddnewoption"));
               Combo_sgnotificacionusuario_Htmltemplate = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Htmltemplate");
               Combo_sgnotificacionusuario_Multiplevaluestype = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Multiplevaluestype");
               Combo_sgnotificacionusuario_Loadingdata = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Loadingdata");
               Combo_sgnotificacionusuario_Noresultsfound = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Noresultsfound");
               Combo_sgnotificacionusuario_Emptyitemtext = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Emptyitemtext");
               Combo_sgnotificacionusuario_Onlyselectedvalues = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Onlyselectedvalues");
               Combo_sgnotificacionusuario_Selectalltext = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Selectalltext");
               Combo_sgnotificacionusuario_Multiplevaluesseparator = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Multiplevaluesseparator");
               Combo_sgnotificacionusuario_Addnewoptiontext = cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Addnewoptiontext");
               Combo_sgnotificacionusuario_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_SGNOTIFICACIONUSUARIO_Gxcontroltype"), ".", ","));
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
               Combo_sgnotificaciondetusuario_Objectcall = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Objectcall");
               Combo_sgnotificaciondetusuario_Class = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Class");
               Combo_sgnotificaciondetusuario_Icontype = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Icontype");
               Combo_sgnotificaciondetusuario_Icon = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Icon");
               Combo_sgnotificaciondetusuario_Caption = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Caption");
               Combo_sgnotificaciondetusuario_Tooltip = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Tooltip");
               Combo_sgnotificaciondetusuario_Cls = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Cls");
               Combo_sgnotificaciondetusuario_Selectedvalue_set = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Selectedvalue_set");
               Combo_sgnotificaciondetusuario_Selectedvalue_get = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Selectedvalue_get");
               Combo_sgnotificaciondetusuario_Selectedtext_set = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Selectedtext_set");
               Combo_sgnotificaciondetusuario_Selectedtext_get = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Selectedtext_get");
               Combo_sgnotificaciondetusuario_Gamoauthtoken = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Gamoauthtoken");
               Combo_sgnotificaciondetusuario_Ddointernalname = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Ddointernalname");
               Combo_sgnotificaciondetusuario_Titlecontrolalign = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Titlecontrolalign");
               Combo_sgnotificaciondetusuario_Dropdownoptionstype = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Dropdownoptionstype");
               Combo_sgnotificaciondetusuario_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Enabled"));
               Combo_sgnotificaciondetusuario_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Visible"));
               Combo_sgnotificaciondetusuario_Titlecontrolidtoreplace = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Titlecontrolidtoreplace");
               Combo_sgnotificaciondetusuario_Datalisttype = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Datalisttype");
               Combo_sgnotificaciondetusuario_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Allowmultipleselection"));
               Combo_sgnotificaciondetusuario_Datalistfixedvalues = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Datalistfixedvalues");
               Combo_sgnotificaciondetusuario_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Isgriditem"));
               Combo_sgnotificaciondetusuario_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Hasdescription"));
               Combo_sgnotificaciondetusuario_Datalistproc = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Datalistproc");
               Combo_sgnotificaciondetusuario_Datalistprocparametersprefix = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Datalistprocparametersprefix");
               Combo_sgnotificaciondetusuario_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Datalistupdateminimumcharacters"), ".", ","));
               Combo_sgnotificaciondetusuario_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Includeonlyselectedoption"));
               Combo_sgnotificaciondetusuario_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Includeselectalloption"));
               Combo_sgnotificaciondetusuario_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Emptyitem"));
               Combo_sgnotificaciondetusuario_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Includeaddnewoption"));
               Combo_sgnotificaciondetusuario_Htmltemplate = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Htmltemplate");
               Combo_sgnotificaciondetusuario_Multiplevaluestype = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Multiplevaluestype");
               Combo_sgnotificaciondetusuario_Loadingdata = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Loadingdata");
               Combo_sgnotificaciondetusuario_Noresultsfound = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Noresultsfound");
               Combo_sgnotificaciondetusuario_Emptyitemtext = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Emptyitemtext");
               Combo_sgnotificaciondetusuario_Onlyselectedvalues = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Onlyselectedvalues");
               Combo_sgnotificaciondetusuario_Selectalltext = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Selectalltext");
               Combo_sgnotificaciondetusuario_Multiplevaluesseparator = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Multiplevaluesseparator");
               Combo_sgnotificaciondetusuario_Addnewoptiontext = cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Addnewoptiontext");
               Combo_sgnotificaciondetusuario_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_SGNOTIFICACIONDETUSUARIO_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGNOTIFICACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2237SGNotificacionID = 0;
                  AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               }
               else
               {
                  A2237SGNotificacionID = (long)(context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ","));
                  AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               }
               A2238SGNotificacionTitulo = cgiGet( edtSGNotificacionTitulo_Internalname);
               AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
               A2239SGNotificacionDescripcion = cgiGet( edtSGNotificacionDescripcion_Internalname);
               AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
               if ( context.localUtil.VCDateTime( cgiGet( edtSGNotificacionFecha_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora"}), 1, "SGNOTIFICACIONFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtSGNotificacionFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2240SGNotificacionFecha = context.localUtil.CToT( cgiGet( edtSGNotificacionFecha_Internalname));
                  AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
               }
               A2241SGNotificacionUsuario = cgiGet( edtSGNotificacionUsuario_Internalname);
               AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
               cmbSGNotificacionIconClass.Name = cmbSGNotificacionIconClass_Internalname;
               cmbSGNotificacionIconClass.CurrentValue = cgiGet( cmbSGNotificacionIconClass_Internalname);
               A2243SGNotificacionIconClass = cgiGet( cmbSGNotificacionIconClass_Internalname);
               AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
               AV18ComboSGNotificacionUsuario = cgiGet( edtavCombosgnotificacionusuario_Internalname);
               AssignAttri("", false, "AV18ComboSGNotificacionUsuario", AV18ComboSGNotificacionUsuario);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionTUsuario_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionTUsuario_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGNOTIFICACIONTUSUARIO");
                  AnyError = 1;
                  GX_FocusControl = edtSGNotificacionTUsuario_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2244SGNotificacionTUsuario = 0;
                  AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
               }
               else
               {
                  A2244SGNotificacionTUsuario = (short)(context.localUtil.CToN( cgiGet( edtSGNotificacionTUsuario_Internalname), ".", ","));
                  AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Notificaciones");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A2237SGNotificacionID != Z2237SGNotificacionID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\notificaciones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A2237SGNotificacionID = (long)(NumberUtil.Val( GetPar( "SGNotificacionID"), "."));
                  AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
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
                     sMode198 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode198;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound198 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_7A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SGNOTIFICACIONID");
                        AnyError = 1;
                        GX_FocusControl = edtSGNotificacionID_Internalname;
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
                           E117A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E127A2 ();
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
            E127A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7A198( ) ;
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
            DisableAttributes7A198( ) ;
         }
         AssignProp("", false, edtavCombosgnotificacionusuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosgnotificacionusuario_Enabled), 5, 0), true);
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

      protected void CONFIRM_7A0( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7A198( ) ;
            }
            else
            {
               CheckExtendedTable7A198( ) ;
               CloseExtendedTableCursors7A198( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode198 = Gx_mode;
            CONFIRM_7A199( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode198;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode198;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_7A199( )
      {
         nGXsfl_59_idx = 0;
         while ( nGXsfl_59_idx < nRC_GXsfl_59 )
         {
            ReadRow7A199( ) ;
            if ( ( nRcdExists_199 != 0 ) || ( nIsMod_199 != 0 ) )
            {
               GetKey7A199( ) ;
               if ( ( nRcdExists_199 == 0 ) && ( nRcdDeleted_199 == 0 ) )
               {
                  if ( RcdFound199 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate7A199( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7A199( ) ;
                        CloseExtendedTableCursors7A199( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "SGNOTIFICACIONDETID_" + sGXsfl_59_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtSGNotificacionDetID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound199 != 0 )
                  {
                     if ( nRcdDeleted_199 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey7A199( ) ;
                        Load7A199( ) ;
                        BeforeValidate7A199( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7A199( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_199 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate7A199( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7A199( ) ;
                              CloseExtendedTableCursors7A199( ) ;
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
                     if ( nRcdDeleted_199 == 0 )
                     {
                        GXCCtl = "SGNOTIFICACIONDETID_" + sGXsfl_59_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSGNotificacionDetID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSGNotificacionDetID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2245SGNotificacionDetID), 4, 0, ".", ""))) ;
            ChangePostValue( edtSGNotificacionDetUsuario_Internalname, StringUtil.RTrim( A2246SGNotificacionDetUsuario)) ;
            ChangePostValue( edtSGNotificacionDetUsuarioDsc_Internalname, StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc)) ;
            ChangePostValue( edtSGNotificacionDetEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2248SGNotificacionDetEstado), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2245SGNotificacionDetID_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2245SGNotificacionDetID), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2248SGNotificacionDetEstado_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2248SGNotificacionDetEstado), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2246SGNotificacionDetUsuario_"+sGXsfl_59_idx, StringUtil.RTrim( Z2246SGNotificacionDetUsuario)) ;
            ChangePostValue( "nRcdDeleted_199_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_199), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_199_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_199), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_199_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_199), 4, 0, ".", ""))) ;
            if ( nIsMod_199 != 0 )
            {
               ChangePostValue( "SGNOTIFICACIONDETID_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption7A0( )
      {
      }

      protected void E117A2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Combo_sgnotificaciondetusuario_Titlecontrolidtoreplace = edtSGNotificacionDetUsuario_Internalname;
         ucCombo_sgnotificaciondetusuario.SendProperty(context, "", false, Combo_sgnotificaciondetusuario_Internalname, "TitleControlIdToReplace", Combo_sgnotificaciondetusuario_Titlecontrolidtoreplace);
         edtSGNotificacionUsuario_Visible = 0;
         AssignProp("", false, edtSGNotificacionUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSGNotificacionUsuario_Visible), 5, 0), true);
         AV18ComboSGNotificacionUsuario = "";
         AssignAttri("", false, "AV18ComboSGNotificacionUsuario", AV18ComboSGNotificacionUsuario);
         edtavCombosgnotificacionusuario_Visible = 0;
         AssignProp("", false, edtavCombosgnotificacionusuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosgnotificacionusuario_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSGNOTIFICACIONUSUARIO' */
         S112 ();
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
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SGNotificacionUsuario") == 0 )
               {
                  AV11Insert_SGNotificacionUsuario = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_SGNotificacionUsuario", AV11Insert_SGNotificacionUsuario);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_SGNotificacionUsuario)) )
                  {
                     AV18ComboSGNotificacionUsuario = AV11Insert_SGNotificacionUsuario;
                     AssignAttri("", false, "AV18ComboSGNotificacionUsuario", AV18ComboSGNotificacionUsuario);
                     Combo_sgnotificacionusuario_Selectedvalue_set = AV18ComboSGNotificacionUsuario;
                     ucCombo_sgnotificacionusuario.SendProperty(context, "", false, Combo_sgnotificacionusuario_Internalname, "SelectedValue_set", Combo_sgnotificacionusuario_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new GeneXus.Programs.seguridad.notificacionesloaddvcombo(context ).execute(  "SGNotificacionUsuario",  "GET",  false,  AV7SGNotificacionID,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_sgnotificacionusuario_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_sgnotificacionusuario.SendProperty(context, "", false, Combo_sgnotificacionusuario_Internalname, "SelectedText_set", Combo_sgnotificacionusuario_Selectedtext_set);
                     Combo_sgnotificacionusuario_Enabled = false;
                     ucCombo_sgnotificacionusuario.SendProperty(context, "", false, Combo_sgnotificacionusuario_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sgnotificacionusuario_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
         edtSGNotificacionTUsuario_Visible = 0;
         AssignProp("", false, edtSGNotificacionTUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSGNotificacionTUsuario_Visible), 5, 0), true);
      }

      protected void E127A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("seguridad.notificacionesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSGNOTIFICACIONUSUARIO' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.seguridad.notificacionesloaddvcombo(context ).execute(  "SGNotificacionUsuario",  Gx_mode,  false,  AV7SGNotificacionID,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_sgnotificacionusuario_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_sgnotificacionusuario.SendProperty(context, "", false, Combo_sgnotificacionusuario_Internalname, "SelectedValue_set", Combo_sgnotificacionusuario_Selectedvalue_set);
         Combo_sgnotificacionusuario_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_sgnotificacionusuario.SendProperty(context, "", false, Combo_sgnotificacionusuario_Internalname, "SelectedText_set", Combo_sgnotificacionusuario_Selectedtext_set);
         AV18ComboSGNotificacionUsuario = AV15ComboSelectedValue;
         AssignAttri("", false, "AV18ComboSGNotificacionUsuario", AV18ComboSGNotificacionUsuario);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_sgnotificacionusuario_Enabled = false;
            ucCombo_sgnotificacionusuario.SendProperty(context, "", false, Combo_sgnotificacionusuario_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sgnotificacionusuario_Enabled));
         }
      }

      protected void ZM7A198( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2238SGNotificacionTitulo = T007A6_A2238SGNotificacionTitulo[0];
               Z2239SGNotificacionDescripcion = T007A6_A2239SGNotificacionDescripcion[0];
               Z2240SGNotificacionFecha = T007A6_A2240SGNotificacionFecha[0];
               Z2243SGNotificacionIconClass = T007A6_A2243SGNotificacionIconClass[0];
               Z2244SGNotificacionTUsuario = T007A6_A2244SGNotificacionTUsuario[0];
               Z2241SGNotificacionUsuario = T007A6_A2241SGNotificacionUsuario[0];
            }
            else
            {
               Z2238SGNotificacionTitulo = A2238SGNotificacionTitulo;
               Z2239SGNotificacionDescripcion = A2239SGNotificacionDescripcion;
               Z2240SGNotificacionFecha = A2240SGNotificacionFecha;
               Z2243SGNotificacionIconClass = A2243SGNotificacionIconClass;
               Z2244SGNotificacionTUsuario = A2244SGNotificacionTUsuario;
               Z2241SGNotificacionUsuario = A2241SGNotificacionUsuario;
            }
         }
         if ( GX_JID == -18 )
         {
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2238SGNotificacionTitulo = A2238SGNotificacionTitulo;
            Z2239SGNotificacionDescripcion = A2239SGNotificacionDescripcion;
            Z2240SGNotificacionFecha = A2240SGNotificacionFecha;
            Z2243SGNotificacionIconClass = A2243SGNotificacionIconClass;
            Z2244SGNotificacionTUsuario = A2244SGNotificacionTUsuario;
            Z2241SGNotificacionUsuario = A2241SGNotificacionUsuario;
            Z2242SGNotificacionUsuarioDsc = A2242SGNotificacionUsuarioDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "Seguridad.Notificaciones";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SGNotificacionID) )
         {
            A2237SGNotificacionID = AV7SGNotificacionID;
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         }
         if ( ! (0==AV7SGNotificacionID) )
         {
            edtSGNotificacionID_Enabled = 0;
            AssignProp("", false, edtSGNotificacionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionID_Enabled), 5, 0), true);
         }
         else
         {
            edtSGNotificacionID_Enabled = 1;
            AssignProp("", false, edtSGNotificacionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7SGNotificacionID) )
         {
            edtSGNotificacionID_Enabled = 0;
            AssignProp("", false, edtSGNotificacionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_SGNotificacionUsuario)) )
         {
            edtSGNotificacionUsuario_Enabled = 0;
            AssignProp("", false, edtSGNotificacionUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionUsuario_Enabled), 5, 0), true);
         }
         else
         {
            edtSGNotificacionUsuario_Enabled = 1;
            AssignProp("", false, edtSGNotificacionUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionUsuario_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_SGNotificacionUsuario)) )
         {
            A2241SGNotificacionUsuario = AV11Insert_SGNotificacionUsuario;
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
         }
         else
         {
            A2241SGNotificacionUsuario = AV18ComboSGNotificacionUsuario;
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
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
            /* Using cursor T007A7 */
            pr_default.execute(5, new Object[] {A2241SGNotificacionUsuario});
            A2242SGNotificacionUsuarioDsc = T007A7_A2242SGNotificacionUsuarioDsc[0];
            pr_default.close(5);
         }
      }

      protected void Load7A198( )
      {
         /* Using cursor T007A8 */
         pr_default.execute(6, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound198 = 1;
            A2238SGNotificacionTitulo = T007A8_A2238SGNotificacionTitulo[0];
            AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
            A2239SGNotificacionDescripcion = T007A8_A2239SGNotificacionDescripcion[0];
            AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
            A2240SGNotificacionFecha = T007A8_A2240SGNotificacionFecha[0];
            AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
            A2242SGNotificacionUsuarioDsc = T007A8_A2242SGNotificacionUsuarioDsc[0];
            A2243SGNotificacionIconClass = T007A8_A2243SGNotificacionIconClass[0];
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
            A2244SGNotificacionTUsuario = T007A8_A2244SGNotificacionTUsuario[0];
            AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
            A2241SGNotificacionUsuario = T007A8_A2241SGNotificacionUsuario[0];
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
            ZM7A198( -18) ;
         }
         pr_default.close(6);
         OnLoadActions7A198( ) ;
      }

      protected void OnLoadActions7A198( )
      {
      }

      protected void CheckExtendedTable7A198( )
      {
         nIsDirty_198 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2238SGNotificacionTitulo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Titulo", "", "", "", "", "", "", "", ""), 1, "SGNOTIFICACIONTITULO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionTitulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2239SGNotificacionDescripcion)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripción", "", "", "", "", "", "", "", ""), 1, "SGNOTIFICACIONDESCRIPCION");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A2240SGNotificacionFecha) || ( A2240SGNotificacionFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "SGNOTIFICACIONFECHA");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A2240SGNotificacionFecha) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Fecha Hora", "", "", "", "", "", "", "", ""), 1, "SGNOTIFICACIONFECHA");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T007A7 */
         pr_default.execute(5, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2242SGNotificacionUsuarioDsc = T007A7_A2242SGNotificacionUsuarioDsc[0];
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2241SGNotificacionUsuario)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Usuario", "", "", "", "", "", "", "", ""), 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-info NotificationFontIconInfoLight") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-clipboard-check NotificationFontIconInfo") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "far fa-thumbs-up NotificationFontIconSuccess") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-exclamation-triangle NotificationFontIconDanger") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Notificación Icon Class fuera de rango", "OutOfRange", 1, "SGNOTIFICACIONICONCLASS");
            AnyError = 1;
            GX_FocusControl = cmbSGNotificacionIconClass_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2243SGNotificacionIconClass)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Notificación Icon Class", "", "", "", "", "", "", "", ""), 1, "SGNOTIFICACIONICONCLASS");
            AnyError = 1;
            GX_FocusControl = cmbSGNotificacionIconClass_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7A198( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( string A2241SGNotificacionUsuario )
      {
         /* Using cursor T007A9 */
         pr_default.execute(7, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2242SGNotificacionUsuarioDsc = T007A9_A2242SGNotificacionUsuarioDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2242SGNotificacionUsuarioDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey7A198( )
      {
         /* Using cursor T007A10 */
         pr_default.execute(8, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound198 = 1;
         }
         else
         {
            RcdFound198 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007A6 */
         pr_default.execute(4, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM7A198( 18) ;
            RcdFound198 = 1;
            A2237SGNotificacionID = T007A6_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            A2238SGNotificacionTitulo = T007A6_A2238SGNotificacionTitulo[0];
            AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
            A2239SGNotificacionDescripcion = T007A6_A2239SGNotificacionDescripcion[0];
            AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
            A2240SGNotificacionFecha = T007A6_A2240SGNotificacionFecha[0];
            AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
            A2243SGNotificacionIconClass = T007A6_A2243SGNotificacionIconClass[0];
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
            A2244SGNotificacionTUsuario = T007A6_A2244SGNotificacionTUsuario[0];
            AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
            A2241SGNotificacionUsuario = T007A6_A2241SGNotificacionUsuario[0];
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
            Z2237SGNotificacionID = A2237SGNotificacionID;
            sMode198 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7A198( ) ;
            if ( AnyError == 1 )
            {
               RcdFound198 = 0;
               InitializeNonKey7A198( ) ;
            }
            Gx_mode = sMode198;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound198 = 0;
            InitializeNonKey7A198( ) ;
            sMode198 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode198;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey7A198( ) ;
         if ( RcdFound198 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound198 = 0;
         /* Using cursor T007A11 */
         pr_default.execute(9, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T007A11_A2237SGNotificacionID[0] < A2237SGNotificacionID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T007A11_A2237SGNotificacionID[0] > A2237SGNotificacionID ) ) )
            {
               A2237SGNotificacionID = T007A11_A2237SGNotificacionID[0];
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               RcdFound198 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound198 = 0;
         /* Using cursor T007A12 */
         pr_default.execute(10, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T007A12_A2237SGNotificacionID[0] > A2237SGNotificacionID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T007A12_A2237SGNotificacionID[0] < A2237SGNotificacionID ) ) )
            {
               A2237SGNotificacionID = T007A12_A2237SGNotificacionID[0];
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               RcdFound198 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7A198( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7A198( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound198 == 1 )
            {
               if ( A2237SGNotificacionID != Z2237SGNotificacionID )
               {
                  A2237SGNotificacionID = Z2237SGNotificacionID;
                  AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SGNOTIFICACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7A198( ) ;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2237SGNotificacionID != Z2237SGNotificacionID )
               {
                  /* Insert record */
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7A198( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SGNOTIFICACIONID");
                     AnyError = 1;
                     GX_FocusControl = edtSGNotificacionID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSGNotificacionID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7A198( ) ;
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
         if ( A2237SGNotificacionID != Z2237SGNotificacionID )
         {
            A2237SGNotificacionID = Z2237SGNotificacionID;
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7A198( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007A5 */
            pr_default.execute(3, new Object[] {A2237SGNotificacionID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z2238SGNotificacionTitulo, T007A5_A2238SGNotificacionTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z2239SGNotificacionDescripcion, T007A5_A2239SGNotificacionDescripcion[0]) != 0 ) || ( Z2240SGNotificacionFecha != T007A5_A2240SGNotificacionFecha[0] ) || ( StringUtil.StrCmp(Z2243SGNotificacionIconClass, T007A5_A2243SGNotificacionIconClass[0]) != 0 ) || ( Z2244SGNotificacionTUsuario != T007A5_A2244SGNotificacionTUsuario[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2241SGNotificacionUsuario, T007A5_A2241SGNotificacionUsuario[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2238SGNotificacionTitulo, T007A5_A2238SGNotificacionTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z2238SGNotificacionTitulo);
                  GXUtil.WriteLogRaw("Current: ",T007A5_A2238SGNotificacionTitulo[0]);
               }
               if ( StringUtil.StrCmp(Z2239SGNotificacionDescripcion, T007A5_A2239SGNotificacionDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z2239SGNotificacionDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T007A5_A2239SGNotificacionDescripcion[0]);
               }
               if ( Z2240SGNotificacionFecha != T007A5_A2240SGNotificacionFecha[0] )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionFecha");
                  GXUtil.WriteLogRaw("Old: ",Z2240SGNotificacionFecha);
                  GXUtil.WriteLogRaw("Current: ",T007A5_A2240SGNotificacionFecha[0]);
               }
               if ( StringUtil.StrCmp(Z2243SGNotificacionIconClass, T007A5_A2243SGNotificacionIconClass[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionIconClass");
                  GXUtil.WriteLogRaw("Old: ",Z2243SGNotificacionIconClass);
                  GXUtil.WriteLogRaw("Current: ",T007A5_A2243SGNotificacionIconClass[0]);
               }
               if ( Z2244SGNotificacionTUsuario != T007A5_A2244SGNotificacionTUsuario[0] )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionTUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z2244SGNotificacionTUsuario);
                  GXUtil.WriteLogRaw("Current: ",T007A5_A2244SGNotificacionTUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z2241SGNotificacionUsuario, T007A5_A2241SGNotificacionUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z2241SGNotificacionUsuario);
                  GXUtil.WriteLogRaw("Current: ",T007A5_A2241SGNotificacionUsuario[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGNOTIFICACIONES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7A198( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7A198( 0) ;
            CheckOptimisticConcurrency7A198( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A198( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7A198( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007A13 */
                     pr_default.execute(11, new Object[] {A2237SGNotificacionID, A2238SGNotificacionTitulo, A2239SGNotificacionDescripcion, A2240SGNotificacionFecha, A2243SGNotificacionIconClass, A2244SGNotificacionTUsuario, A2241SGNotificacionUsuario});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
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
                           ProcessLevel7A198( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption7A0( ) ;
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
               Load7A198( ) ;
            }
            EndLevel7A198( ) ;
         }
         CloseExtendedTableCursors7A198( ) ;
      }

      protected void Update7A198( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A198( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A198( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7A198( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007A14 */
                     pr_default.execute(12, new Object[] {A2238SGNotificacionTitulo, A2239SGNotificacionDescripcion, A2240SGNotificacionFecha, A2243SGNotificacionIconClass, A2244SGNotificacionTUsuario, A2241SGNotificacionUsuario, A2237SGNotificacionID});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7A198( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel7A198( ) ;
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
            EndLevel7A198( ) ;
         }
         CloseExtendedTableCursors7A198( ) ;
      }

      protected void DeferredUpdate7A198( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7A198( ) ;
            AfterConfirm7A198( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7A198( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart7A199( ) ;
                  while ( RcdFound199 != 0 )
                  {
                     getByPrimaryKey7A199( ) ;
                     Delete7A199( ) ;
                     ScanNext7A199( ) ;
                  }
                  ScanEnd7A199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007A15 */
                     pr_default.execute(13, new Object[] {A2237SGNotificacionID});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
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
         sMode198 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7A198( ) ;
         Gx_mode = sMode198;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7A198( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007A16 */
            pr_default.execute(14, new Object[] {A2241SGNotificacionUsuario});
            A2242SGNotificacionUsuarioDsc = T007A16_A2242SGNotificacionUsuarioDsc[0];
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel7A199( )
      {
         nGXsfl_59_idx = 0;
         while ( nGXsfl_59_idx < nRC_GXsfl_59 )
         {
            ReadRow7A199( ) ;
            if ( ( nRcdExists_199 != 0 ) || ( nIsMod_199 != 0 ) )
            {
               standaloneNotModal7A199( ) ;
               GetKey7A199( ) ;
               if ( ( nRcdExists_199 == 0 ) && ( nRcdDeleted_199 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert7A199( ) ;
               }
               else
               {
                  if ( RcdFound199 != 0 )
                  {
                     if ( ( nRcdDeleted_199 != 0 ) && ( nRcdExists_199 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete7A199( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_199 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update7A199( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_199 == 0 )
                     {
                        GXCCtl = "SGNOTIFICACIONDETID_" + sGXsfl_59_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSGNotificacionDetID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSGNotificacionDetID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2245SGNotificacionDetID), 4, 0, ".", ""))) ;
            ChangePostValue( edtSGNotificacionDetUsuario_Internalname, StringUtil.RTrim( A2246SGNotificacionDetUsuario)) ;
            ChangePostValue( edtSGNotificacionDetUsuarioDsc_Internalname, StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc)) ;
            ChangePostValue( edtSGNotificacionDetEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2248SGNotificacionDetEstado), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2245SGNotificacionDetID_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2245SGNotificacionDetID), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2248SGNotificacionDetEstado_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2248SGNotificacionDetEstado), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2246SGNotificacionDetUsuario_"+sGXsfl_59_idx, StringUtil.RTrim( Z2246SGNotificacionDetUsuario)) ;
            ChangePostValue( "nRcdDeleted_199_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_199), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_199_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_199), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_199_"+sGXsfl_59_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_199), 4, 0, ".", ""))) ;
            if ( nIsMod_199 != 0 )
            {
               ChangePostValue( "SGNOTIFICACIONDETID_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7A199( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_199 = 0;
         nIsMod_199 = 0;
         nRcdDeleted_199 = 0;
      }

      protected void ProcessLevel7A198( )
      {
         /* Save parent mode. */
         sMode198 = Gx_mode;
         ProcessNestedLevel7A199( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode198;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel7A198( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(14);
            pr_default.close(2);
            context.CommitDataStores("seguridad.notificaciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7A0( ) ;
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
            pr_default.close(14);
            pr_default.close(2);
            context.RollbackDataStores("seguridad.notificaciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7A198( )
      {
         /* Scan By routine */
         /* Using cursor T007A17 */
         pr_default.execute(15);
         RcdFound198 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound198 = 1;
            A2237SGNotificacionID = T007A17_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7A198( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound198 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound198 = 1;
            A2237SGNotificacionID = T007A17_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         }
      }

      protected void ScanEnd7A198( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm7A198( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int3 = AV21cSGNotificacionID;
            new GeneXus.Programs.seguridad.notificacionescorrelativo(context ).execute( out  GXt_int3) ;
            AV21cSGNotificacionID = GXt_int3;
            AssignAttri("", false, "AV21cSGNotificacionID", StringUtil.LTrimStr( (decimal)(AV21cSGNotificacionID), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A2237SGNotificacionID = AV21cSGNotificacionID;
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         }
      }

      protected void BeforeInsert7A198( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7A198( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7A198( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7A198( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7A198( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7A198( )
      {
         edtSGNotificacionID_Enabled = 0;
         AssignProp("", false, edtSGNotificacionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionID_Enabled), 5, 0), true);
         edtSGNotificacionTitulo_Enabled = 0;
         AssignProp("", false, edtSGNotificacionTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionTitulo_Enabled), 5, 0), true);
         edtSGNotificacionDescripcion_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDescripcion_Enabled), 5, 0), true);
         edtSGNotificacionFecha_Enabled = 0;
         AssignProp("", false, edtSGNotificacionFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionFecha_Enabled), 5, 0), true);
         edtSGNotificacionUsuario_Enabled = 0;
         AssignProp("", false, edtSGNotificacionUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionUsuario_Enabled), 5, 0), true);
         cmbSGNotificacionIconClass.Enabled = 0;
         AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSGNotificacionIconClass.Enabled), 5, 0), true);
         edtavCombosgnotificacionusuario_Enabled = 0;
         AssignProp("", false, edtavCombosgnotificacionusuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosgnotificacionusuario_Enabled), 5, 0), true);
         edtSGNotificacionTUsuario_Enabled = 0;
         AssignProp("", false, edtSGNotificacionTUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionTUsuario_Enabled), 5, 0), true);
      }

      protected void ZM7A199( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2248SGNotificacionDetEstado = T007A3_A2248SGNotificacionDetEstado[0];
               Z2246SGNotificacionDetUsuario = T007A3_A2246SGNotificacionDetUsuario[0];
            }
            else
            {
               Z2248SGNotificacionDetEstado = A2248SGNotificacionDetEstado;
               Z2246SGNotificacionDetUsuario = A2246SGNotificacionDetUsuario;
            }
         }
         if ( GX_JID == -20 )
         {
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
            Z2248SGNotificacionDetEstado = A2248SGNotificacionDetEstado;
            Z2246SGNotificacionDetUsuario = A2246SGNotificacionDetUsuario;
            Z2247SGNotificacionDetUsuarioDsc = A2247SGNotificacionDetUsuarioDsc;
         }
      }

      protected void standaloneNotModal7A199( )
      {
      }

      protected void standaloneModal7A199( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSGNotificacionDetID_Enabled = 0;
            AssignProp("", false, edtSGNotificacionDetID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         }
         else
         {
            edtSGNotificacionDetID_Enabled = 1;
            AssignProp("", false, edtSGNotificacionDetID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         }
      }

      protected void Load7A199( )
      {
         /* Using cursor T007A18 */
         pr_default.execute(16, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound199 = 1;
            A2247SGNotificacionDetUsuarioDsc = T007A18_A2247SGNotificacionDetUsuarioDsc[0];
            A2248SGNotificacionDetEstado = T007A18_A2248SGNotificacionDetEstado[0];
            A2246SGNotificacionDetUsuario = T007A18_A2246SGNotificacionDetUsuario[0];
            ZM7A199( -20) ;
         }
         pr_default.close(16);
         OnLoadActions7A199( ) ;
      }

      protected void OnLoadActions7A199( )
      {
      }

      protected void CheckExtendedTable7A199( )
      {
         nIsDirty_199 = 0;
         Gx_BScreen = 1;
         standaloneModal7A199( ) ;
         /* Using cursor T007A4 */
         pr_default.execute(2, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "SGNOTIFICACIONDETUSUARIO_" + sGXsfl_59_idx;
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2247SGNotificacionDetUsuarioDsc = T007A4_A2247SGNotificacionDetUsuarioDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7A199( )
      {
         pr_default.close(2);
      }

      protected void enableDisable7A199( )
      {
      }

      protected void gxLoad_21( string A2246SGNotificacionDetUsuario )
      {
         /* Using cursor T007A19 */
         pr_default.execute(17, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GXCCtl = "SGNOTIFICACIONDETUSUARIO_" + sGXsfl_59_idx;
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2247SGNotificacionDetUsuarioDsc = T007A19_A2247SGNotificacionDetUsuarioDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void GetKey7A199( )
      {
         /* Using cursor T007A20 */
         pr_default.execute(18, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound199 = 1;
         }
         else
         {
            RcdFound199 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey7A199( )
      {
         /* Using cursor T007A3 */
         pr_default.execute(1, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7A199( 20) ;
            RcdFound199 = 1;
            InitializeNonKey7A199( ) ;
            A2245SGNotificacionDetID = T007A3_A2245SGNotificacionDetID[0];
            A2248SGNotificacionDetEstado = T007A3_A2248SGNotificacionDetEstado[0];
            A2246SGNotificacionDetUsuario = T007A3_A2246SGNotificacionDetUsuario[0];
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
            sMode199 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7A199( ) ;
            Gx_mode = sMode199;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound199 = 0;
            InitializeNonKey7A199( ) ;
            sMode199 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7A199( ) ;
            Gx_mode = sMode199;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7A199( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency7A199( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007A2 */
            pr_default.execute(0, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2248SGNotificacionDetEstado != T007A2_A2248SGNotificacionDetEstado[0] ) || ( StringUtil.StrCmp(Z2246SGNotificacionDetUsuario, T007A2_A2246SGNotificacionDetUsuario[0]) != 0 ) )
            {
               if ( Z2248SGNotificacionDetEstado != T007A2_A2248SGNotificacionDetEstado[0] )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionDetEstado");
                  GXUtil.WriteLogRaw("Old: ",Z2248SGNotificacionDetEstado);
                  GXUtil.WriteLogRaw("Current: ",T007A2_A2248SGNotificacionDetEstado[0]);
               }
               if ( StringUtil.StrCmp(Z2246SGNotificacionDetUsuario, T007A2_A2246SGNotificacionDetUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.notificaciones:[seudo value changed for attri]"+"SGNotificacionDetUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z2246SGNotificacionDetUsuario);
                  GXUtil.WriteLogRaw("Current: ",T007A2_A2246SGNotificacionDetUsuario[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7A199( )
      {
         BeforeValidate7A199( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A199( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7A199( 0) ;
            CheckOptimisticConcurrency7A199( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A199( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7A199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007A21 */
                     pr_default.execute(19, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID, A2248SGNotificacionDetEstado, A2246SGNotificacionDetUsuario});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load7A199( ) ;
            }
            EndLevel7A199( ) ;
         }
         CloseExtendedTableCursors7A199( ) ;
      }

      protected void Update7A199( )
      {
         BeforeValidate7A199( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A199( ) ;
         }
         if ( ( nIsMod_199 != 0 ) || ( nIsDirty_199 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency7A199( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm7A199( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate7A199( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007A22 */
                        pr_default.execute(20, new Object[] {A2248SGNotificacionDetEstado, A2246SGNotificacionDetUsuario, A2237SGNotificacionID, A2245SGNotificacionDetID});
                        pr_default.close(20);
                        dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                        if ( (pr_default.getStatus(20) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate7A199( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey7A199( ) ;
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
               EndLevel7A199( ) ;
            }
         }
         CloseExtendedTableCursors7A199( ) ;
      }

      protected void DeferredUpdate7A199( )
      {
      }

      protected void Delete7A199( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7A199( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A199( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7A199( ) ;
            AfterConfirm7A199( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7A199( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007A23 */
                  pr_default.execute(21, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
                  pr_default.close(21);
                  dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
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
         sMode199 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7A199( ) ;
         Gx_mode = sMode199;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7A199( )
      {
         standaloneModal7A199( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007A24 */
            pr_default.execute(22, new Object[] {A2246SGNotificacionDetUsuario});
            A2247SGNotificacionDetUsuarioDsc = T007A24_A2247SGNotificacionDetUsuarioDsc[0];
            pr_default.close(22);
         }
      }

      protected void EndLevel7A199( )
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

      public void ScanStart7A199( )
      {
         /* Scan By routine */
         /* Using cursor T007A25 */
         pr_default.execute(23, new Object[] {A2237SGNotificacionID});
         RcdFound199 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound199 = 1;
            A2245SGNotificacionDetID = T007A25_A2245SGNotificacionDetID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7A199( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound199 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound199 = 1;
            A2245SGNotificacionDetID = T007A25_A2245SGNotificacionDetID[0];
         }
      }

      protected void ScanEnd7A199( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm7A199( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7A199( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7A199( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7A199( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7A199( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7A199( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7A199( )
      {
         edtSGNotificacionDetID_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtSGNotificacionDetUsuario_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtSGNotificacionDetUsuarioDsc_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetUsuarioDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtSGNotificacionDetEstado_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0), !bGXsfl_59_Refreshing);
      }

      protected void send_integrity_lvl_hashes7A199( )
      {
      }

      protected void send_integrity_lvl_hashes7A198( )
      {
      }

      protected void SubsflControlProps_59199( )
      {
         edtSGNotificacionDetID_Internalname = "SGNOTIFICACIONDETID_"+sGXsfl_59_idx;
         edtSGNotificacionDetUsuario_Internalname = "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_idx;
         edtSGNotificacionDetUsuarioDsc_Internalname = "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_idx;
         edtSGNotificacionDetEstado_Internalname = "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_idx;
      }

      protected void SubsflControlProps_fel_59199( )
      {
         edtSGNotificacionDetID_Internalname = "SGNOTIFICACIONDETID_"+sGXsfl_59_fel_idx;
         edtSGNotificacionDetUsuario_Internalname = "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_fel_idx;
         edtSGNotificacionDetUsuarioDsc_Internalname = "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_fel_idx;
         edtSGNotificacionDetEstado_Internalname = "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_fel_idx;
      }

      protected void AddRow7A199( )
      {
         nGXsfl_59_idx = (int)(nGXsfl_59_idx+1);
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_59199( ) ;
         SendRow7A199( ) ;
      }

      protected void SendRow7A199( )
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
            if ( ((int)((nGXsfl_59_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_199_" + sGXsfl_59_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_59_idx + "',59)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionDetID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2245SGNotificacionDetID), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2245SGNotificacionDetID), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionDetID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSGNotificacionDetID_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)59,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_199_" + sGXsfl_59_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_59_idx + "',59)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionDetUsuario_Internalname,StringUtil.RTrim( A2246SGNotificacionDetUsuario),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionDetUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSGNotificacionDetUsuario_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)59,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionDetUsuarioDsc_Internalname,StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionDetUsuarioDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSGNotificacionDetUsuarioDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)59,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_199_" + sGXsfl_59_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_59_idx + "',59)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSGNotificacionDetEstado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2248SGNotificacionDetEstado), 1, 0, ".", "")),StringUtil.LTrim( ((edtSGNotificacionDetEstado_Enabled!=0) ? context.localUtil.Format( (decimal)(A2248SGNotificacionDetEstado), "9") : context.localUtil.Format( (decimal)(A2248SGNotificacionDetEstado), "9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSGNotificacionDetEstado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSGNotificacionDetEstado_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)59,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_level1Row);
         send_integrity_lvl_hashes7A199( ) ;
         GXCCtl = "Z2245SGNotificacionDetID_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2245SGNotificacionDetID), 4, 0, ".", "")));
         GXCCtl = "Z2248SGNotificacionDetEstado_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2248SGNotificacionDetEstado), 1, 0, ".", "")));
         GXCCtl = "Z2246SGNotificacionDetUsuario_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z2246SGNotificacionDetUsuario));
         GXCCtl = "nRcdDeleted_199_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_199), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_199_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_199), 4, 0, ".", "")));
         GXCCtl = "nIsMod_199_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_199), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_59_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vSGNOTIFICACIONID_" + sGXsfl_59_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SGNOTIFICACIONDETID_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_level1Container.AddRow(Gridlevel_level1Row);
      }

      protected void ReadRow7A199( )
      {
         nGXsfl_59_idx = (int)(nGXsfl_59_idx+1);
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_59199( ) ;
         edtSGNotificacionDetID_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETID_"+sGXsfl_59_idx+"Enabled"), ".", ","));
         edtSGNotificacionDetUsuario_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETUSUARIO_"+sGXsfl_59_idx+"Enabled"), ".", ","));
         edtSGNotificacionDetUsuarioDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETUSUARIODSC_"+sGXsfl_59_idx+"Enabled"), ".", ","));
         edtSGNotificacionDetEstado_Enabled = (int)(context.localUtil.CToN( cgiGet( "SGNOTIFICACIONDETESTADO_"+sGXsfl_59_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "SGNOTIFICACIONDETID_" + sGXsfl_59_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetID_Internalname;
            wbErr = true;
            A2245SGNotificacionDetID = 0;
         }
         else
         {
            A2245SGNotificacionDetID = (short)(context.localUtil.CToN( cgiGet( edtSGNotificacionDetID_Internalname), ".", ","));
         }
         A2246SGNotificacionDetUsuario = cgiGet( edtSGNotificacionDetUsuario_Internalname);
         A2247SGNotificacionDetUsuarioDsc = cgiGet( edtSGNotificacionDetUsuarioDsc_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetEstado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetEstado_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "SGNOTIFICACIONDETESTADO_" + sGXsfl_59_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetEstado_Internalname;
            wbErr = true;
            A2248SGNotificacionDetEstado = 0;
         }
         else
         {
            A2248SGNotificacionDetEstado = (short)(context.localUtil.CToN( cgiGet( edtSGNotificacionDetEstado_Internalname), ".", ","));
         }
         GXCCtl = "Z2245SGNotificacionDetID_" + sGXsfl_59_idx;
         Z2245SGNotificacionDetID = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z2248SGNotificacionDetEstado_" + sGXsfl_59_idx;
         Z2248SGNotificacionDetEstado = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z2246SGNotificacionDetUsuario_" + sGXsfl_59_idx;
         Z2246SGNotificacionDetUsuario = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_199_" + sGXsfl_59_idx;
         nRcdDeleted_199 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_199_" + sGXsfl_59_idx;
         nRcdExists_199 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_199_" + sGXsfl_59_idx;
         nIsMod_199 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtSGNotificacionDetID_Enabled = edtSGNotificacionDetID_Enabled;
      }

      protected void ConfirmValues7A0( )
      {
         nGXsfl_59_idx = 0;
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_59199( ) ;
         while ( nGXsfl_59_idx < nRC_GXsfl_59 )
         {
            nGXsfl_59_idx = (int)(nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_59199( ) ;
            ChangePostValue( "Z2245SGNotificacionDetID_"+sGXsfl_59_idx, cgiGet( "ZT_"+"Z2245SGNotificacionDetID_"+sGXsfl_59_idx)) ;
            DeletePostValue( "ZT_"+"Z2245SGNotificacionDetID_"+sGXsfl_59_idx) ;
            ChangePostValue( "Z2248SGNotificacionDetEstado_"+sGXsfl_59_idx, cgiGet( "ZT_"+"Z2248SGNotificacionDetEstado_"+sGXsfl_59_idx)) ;
            DeletePostValue( "ZT_"+"Z2248SGNotificacionDetEstado_"+sGXsfl_59_idx) ;
            ChangePostValue( "Z2246SGNotificacionDetUsuario_"+sGXsfl_59_idx, cgiGet( "ZT_"+"Z2246SGNotificacionDetUsuario_"+sGXsfl_59_idx)) ;
            DeletePostValue( "ZT_"+"Z2246SGNotificacionDetUsuario_"+sGXsfl_59_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027828", false, true);
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
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SGNotificacionID,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Notificaciones");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\notificaciones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2237SGNotificacionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2237SGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2238SGNotificacionTitulo", Z2238SGNotificacionTitulo);
         GxWebStd.gx_hidden_field( context, "Z2239SGNotificacionDescripcion", Z2239SGNotificacionDescripcion);
         GxWebStd.gx_hidden_field( context, "Z2240SGNotificacionFecha", context.localUtil.TToC( Z2240SGNotificacionFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2243SGNotificacionIconClass", Z2243SGNotificacionIconClass);
         GxWebStd.gx_hidden_field( context, "Z2244SGNotificacionTUsuario", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2244SGNotificacionTUsuario), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2241SGNotificacionUsuario", StringUtil.RTrim( Z2241SGNotificacionUsuario));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_59", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_59_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N2241SGNotificacionUsuario", StringUtil.RTrim( A2241SGNotificacionUsuario));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSGNOTIFICACIONUSUARIO_DATA", AV13SGNotificacionUsuario_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSGNOTIFICACIONUSUARIO_DATA", AV13SGNotificacionUsuario_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSGNOTIFICACIONDETUSUARIO_DATA", AV20SGNotificacionDetUsuario_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSGNOTIFICACIONDETUSUARIO_DATA", AV20SGNotificacionDetUsuario_Data);
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
         GxWebStd.gx_hidden_field( context, "vSGNOTIFICACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSGNOTIFICACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SGNotificacionID), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCSGNOTIFICACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21cSGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SGNOTIFICACIONUSUARIO", StringUtil.RTrim( AV11Insert_SGNotificacionUsuario));
         GxWebStd.gx_hidden_field( context, "SGNOTIFICACIONUSUARIODSC", StringUtil.RTrim( A2242SGNotificacionUsuarioDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Objectcall", StringUtil.RTrim( Combo_sgnotificacionusuario_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Cls", StringUtil.RTrim( Combo_sgnotificacionusuario_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Selectedvalue_set", StringUtil.RTrim( Combo_sgnotificacionusuario_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Selectedtext_set", StringUtil.RTrim( Combo_sgnotificacionusuario_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Enabled", StringUtil.BoolToStr( Combo_sgnotificacionusuario_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Datalistproc", StringUtil.RTrim( Combo_sgnotificacionusuario_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sgnotificacionusuario_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONUSUARIO_Emptyitem", StringUtil.BoolToStr( Combo_sgnotificacionusuario_Emptyitem));
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
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Objectcall", StringUtil.RTrim( Combo_sgnotificaciondetusuario_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Cls", StringUtil.RTrim( Combo_sgnotificaciondetusuario_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Enabled", StringUtil.BoolToStr( Combo_sgnotificaciondetusuario_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_sgnotificaciondetusuario_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Isgriditem", StringUtil.BoolToStr( Combo_sgnotificaciondetusuario_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Hasdescription", StringUtil.BoolToStr( Combo_sgnotificaciondetusuario_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Datalistproc", StringUtil.RTrim( Combo_sgnotificaciondetusuario_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sgnotificaciondetusuario_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SGNOTIFICACIONDETUSUARIO_Emptyitem", StringUtil.BoolToStr( Combo_sgnotificaciondetusuario_Emptyitem));
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
         GXEncryptionTmp = "seguridad.notificaciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SGNotificacionID,10,0));
         return formatLink("seguridad.notificaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.Notificaciones" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notificaciones" ;
      }

      protected void InitializeNonKey7A198( )
      {
         A2241SGNotificacionUsuario = "";
         AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
         AV21cSGNotificacionID = 0;
         AssignAttri("", false, "AV21cSGNotificacionID", StringUtil.LTrimStr( (decimal)(AV21cSGNotificacionID), 10, 0));
         A2238SGNotificacionTitulo = "";
         AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
         A2239SGNotificacionDescripcion = "";
         AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
         A2242SGNotificacionUsuarioDsc = "";
         AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", A2242SGNotificacionUsuarioDsc);
         A2243SGNotificacionIconClass = "";
         AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
         A2244SGNotificacionTUsuario = 0;
         AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
         Z2238SGNotificacionTitulo = "";
         Z2239SGNotificacionDescripcion = "";
         Z2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z2243SGNotificacionIconClass = "";
         Z2244SGNotificacionTUsuario = 0;
         Z2241SGNotificacionUsuario = "";
      }

      protected void InitAll7A198( )
      {
         A2237SGNotificacionID = 0;
         AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         InitializeNonKey7A198( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey7A199( )
      {
         A2246SGNotificacionDetUsuario = "";
         A2247SGNotificacionDetUsuarioDsc = "";
         A2248SGNotificacionDetEstado = 0;
         Z2248SGNotificacionDetEstado = 0;
         Z2246SGNotificacionDetUsuario = "";
      }

      protected void InitAll7A199( )
      {
         A2245SGNotificacionDetID = 0;
         InitializeNonKey7A199( ) ;
      }

      protected void StandaloneModalInsert7A199( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027872", true, true);
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
         context.AddJavascriptSource("seguridad/notificaciones.js", "?20228181027872", false, true);
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

      protected void init_level_properties199( )
      {
         edtSGNotificacionDetID_Enabled = defedtSGNotificacionDetID_Enabled;
         AssignProp("", false, edtSGNotificacionDetID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0), !bGXsfl_59_Refreshing);
      }

      protected void init_default_properties( )
      {
         edtSGNotificacionID_Internalname = "SGNOTIFICACIONID";
         edtSGNotificacionTitulo_Internalname = "SGNOTIFICACIONTITULO";
         edtSGNotificacionDescripcion_Internalname = "SGNOTIFICACIONDESCRIPCION";
         edtSGNotificacionFecha_Internalname = "SGNOTIFICACIONFECHA";
         lblTextblocksgnotificacionusuario_Internalname = "TEXTBLOCKSGNOTIFICACIONUSUARIO";
         Combo_sgnotificacionusuario_Internalname = "COMBO_SGNOTIFICACIONUSUARIO";
         edtSGNotificacionUsuario_Internalname = "SGNOTIFICACIONUSUARIO";
         divTablesplittedsgnotificacionusuario_Internalname = "TABLESPLITTEDSGNOTIFICACIONUSUARIO";
         cmbSGNotificacionIconClass_Internalname = "SGNOTIFICACIONICONCLASS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtSGNotificacionDetID_Internalname = "SGNOTIFICACIONDETID";
         edtSGNotificacionDetUsuario_Internalname = "SGNOTIFICACIONDETUSUARIO";
         edtSGNotificacionDetUsuarioDsc_Internalname = "SGNOTIFICACIONDETUSUARIODSC";
         edtSGNotificacionDetEstado_Internalname = "SGNOTIFICACIONDETESTADO";
         divTableleaflevel_level1_Internalname = "TABLELEAFLEVEL_LEVEL1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosgnotificacionusuario_Internalname = "vCOMBOSGNOTIFICACIONUSUARIO";
         divSectionattribute_sgnotificacionusuario_Internalname = "SECTIONATTRIBUTE_SGNOTIFICACIONUSUARIO";
         Combo_sgnotificaciondetusuario_Internalname = "COMBO_SGNOTIFICACIONDETUSUARIO";
         edtSGNotificacionTUsuario_Internalname = "SGNOTIFICACIONTUSUARIO";
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
         Combo_sgnotificaciondetusuario_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Notificaciones";
         edtSGNotificacionDetEstado_Jsonclick = "";
         edtSGNotificacionDetUsuarioDsc_Jsonclick = "";
         edtSGNotificacionDetUsuario_Jsonclick = "";
         edtSGNotificacionDetID_Jsonclick = "";
         subGridlevel_level1_Class = "WorkWith";
         subGridlevel_level1_Backcolorstyle = 0;
         Combo_sgnotificaciondetusuario_Titlecontrolidtoreplace = "";
         subGridlevel_level1_Allowcollapsing = 0;
         subGridlevel_level1_Allowselection = 0;
         edtSGNotificacionDetEstado_Enabled = 1;
         edtSGNotificacionDetUsuarioDsc_Enabled = 0;
         edtSGNotificacionDetUsuario_Enabled = 1;
         edtSGNotificacionDetID_Enabled = 1;
         subGridlevel_level1_Header = "";
         edtSGNotificacionTUsuario_Jsonclick = "";
         edtSGNotificacionTUsuario_Enabled = 1;
         edtSGNotificacionTUsuario_Visible = 1;
         Combo_sgnotificaciondetusuario_Emptyitem = Convert.ToBoolean( 0);
         Combo_sgnotificaciondetusuario_Datalistprocparametersprefix = " \"ComboName\": \"SGNotificacionDetUsuario\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SGNotificacionID\": 0";
         Combo_sgnotificaciondetusuario_Datalistproc = "Seguridad.NotificacionesLoadDVCombo";
         Combo_sgnotificaciondetusuario_Hasdescription = Convert.ToBoolean( -1);
         Combo_sgnotificaciondetusuario_Isgriditem = Convert.ToBoolean( -1);
         Combo_sgnotificaciondetusuario_Cls = "ExtendedCombo";
         Combo_sgnotificaciondetusuario_Caption = "";
         edtavCombosgnotificacionusuario_Jsonclick = "";
         edtavCombosgnotificacionusuario_Enabled = 0;
         edtavCombosgnotificacionusuario_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbSGNotificacionIconClass_Jsonclick = "";
         cmbSGNotificacionIconClass.Enabled = 1;
         edtSGNotificacionUsuario_Jsonclick = "";
         edtSGNotificacionUsuario_Enabled = 1;
         edtSGNotificacionUsuario_Visible = 1;
         Combo_sgnotificacionusuario_Emptyitem = Convert.ToBoolean( 0);
         Combo_sgnotificacionusuario_Datalistprocparametersprefix = " \"ComboName\": \"SGNotificacionUsuario\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SGNotificacionID\": 0";
         Combo_sgnotificacionusuario_Datalistproc = "Seguridad.NotificacionesLoadDVCombo";
         Combo_sgnotificacionusuario_Cls = "ExtendedCombo Attribute";
         Combo_sgnotificacionusuario_Caption = "";
         Combo_sgnotificacionusuario_Enabled = Convert.ToBoolean( -1);
         edtSGNotificacionFecha_Jsonclick = "";
         edtSGNotificacionFecha_Enabled = 1;
         edtSGNotificacionDescripcion_Enabled = 1;
         edtSGNotificacionTitulo_Jsonclick = "";
         edtSGNotificacionTitulo_Enabled = 1;
         edtSGNotificacionID_Jsonclick = "";
         edtSGNotificacionID_Enabled = 1;
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

      protected void GX10ASACSGNOTIFICACIONID7A198( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int3 = AV21cSGNotificacionID;
            new GeneXus.Programs.seguridad.notificacionescorrelativo(context ).execute( out  GXt_int3) ;
            AV21cSGNotificacionID = GXt_int3;
            AssignAttri("", false, "AV21cSGNotificacionID", StringUtil.LTrimStr( (decimal)(AV21cSGNotificacionID), 10, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21cSGNotificacionID), 10, 0, ".", "")))+"\"") ;
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
         SubsflControlProps_59199( ) ;
         while ( nGXsfl_59_idx <= nRC_GXsfl_59 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal7A199( ) ;
            standaloneModal7A199( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow7A199( ) ;
            nGXsfl_59_idx = (int)(nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_59199( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_level1Container)) ;
         /* End function gxnrGridlevel_level1_newrow */
      }

      protected void init_web_controls( )
      {
         cmbSGNotificacionIconClass.Name = "SGNOTIFICACIONICONCLASS";
         cmbSGNotificacionIconClass.WebTags = "";
         cmbSGNotificacionIconClass.addItem("fas fa-info NotificationFontIconInfoLight", "Informativo", 0);
         cmbSGNotificacionIconClass.addItem("fas fa-clipboard-check NotificationFontIconInfo", "Verificación", 0);
         cmbSGNotificacionIconClass.addItem("far fa-thumbs-up NotificationFontIconSuccess", "Conforme", 0);
         cmbSGNotificacionIconClass.addItem("fas fa-exclamation-triangle NotificationFontIconDanger", "Urgente", 0);
         if ( cmbSGNotificacionIconClass.ItemCount > 0 )
         {
            A2243SGNotificacionIconClass = cmbSGNotificacionIconClass.getValidValue(A2243SGNotificacionIconClass);
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
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

      public void Valid_Sgnotificacionusuario( )
      {
         /* Using cursor T007A16 */
         pr_default.execute(14, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
         }
         A2242SGNotificacionUsuarioDsc = T007A16_A2242SGNotificacionUsuarioDsc[0];
         pr_default.close(14);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2241SGNotificacionUsuario)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Usuario", "", "", "", "", "", "", "", ""), 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", StringUtil.RTrim( A2242SGNotificacionUsuarioDsc));
      }

      public void Valid_Sgnotificaciondetusuario( )
      {
         /* Using cursor T007A24 */
         pr_default.execute(22, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONDETUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
         }
         A2247SGNotificacionDetUsuarioDsc = T007A24_A2247SGNotificacionDetUsuarioDsc[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7SGNotificacionID',fld:'vSGNOTIFICACIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SGNotificacionID',fld:'vSGNOTIFICACIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E127A2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONID","{handler:'Valid_Sgnotificacionid',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONID",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONTITULO","{handler:'Valid_Sgnotificaciontitulo',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONTITULO",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONDESCRIPCION","{handler:'Valid_Sgnotificaciondescripcion',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONDESCRIPCION",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONFECHA","{handler:'Valid_Sgnotificacionfecha',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONFECHA",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONUSUARIO","{handler:'Valid_Sgnotificacionusuario',iparms:[{av:'A2241SGNotificacionUsuario',fld:'SGNOTIFICACIONUSUARIO',pic:''},{av:'A2242SGNotificacionUsuarioDsc',fld:'SGNOTIFICACIONUSUARIODSC',pic:''}]");
         setEventMetadata("VALID_SGNOTIFICACIONUSUARIO",",oparms:[{av:'A2242SGNotificacionUsuarioDsc',fld:'SGNOTIFICACIONUSUARIODSC',pic:''}]}");
         setEventMetadata("VALID_SGNOTIFICACIONICONCLASS","{handler:'Valid_Sgnotificacioniconclass',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONICONCLASS",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOSGNOTIFICACIONUSUARIO","{handler:'Validv_Combosgnotificacionusuario',iparms:[]");
         setEventMetadata("VALIDV_COMBOSGNOTIFICACIONUSUARIO",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONDETID","{handler:'Valid_Sgnotificaciondetid',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONDETID",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONDETUSUARIO","{handler:'Valid_Sgnotificaciondetusuario',iparms:[{av:'A2246SGNotificacionDetUsuario',fld:'SGNOTIFICACIONDETUSUARIO',pic:''},{av:'A2247SGNotificacionDetUsuarioDsc',fld:'SGNOTIFICACIONDETUSUARIODSC',pic:''}]");
         setEventMetadata("VALID_SGNOTIFICACIONDETUSUARIO",",oparms:[{av:'A2247SGNotificacionDetUsuarioDsc',fld:'SGNOTIFICACIONDETUSUARIODSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Sgnotificaciondetestado',iparms:[]");
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
         pr_default.close(22);
         pr_default.close(4);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2238SGNotificacionTitulo = "";
         Z2239SGNotificacionDescripcion = "";
         Z2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z2243SGNotificacionIconClass = "";
         Z2241SGNotificacionUsuario = "";
         N2241SGNotificacionUsuario = "";
         Combo_sgnotificacionusuario_Selectedvalue_get = "";
         Z2246SGNotificacionDetUsuario = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2241SGNotificacionUsuario = "";
         A2246SGNotificacionDetUsuario = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A2243SGNotificacionIconClass = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         lblTextblocksgnotificacionusuario_Jsonclick = "";
         ucCombo_sgnotificacionusuario = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13SGNotificacionUsuario_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV18ComboSGNotificacionUsuario = "";
         ucCombo_sgnotificaciondetusuario = new GXUserControl();
         AV20SGNotificacionDetUsuario_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Gridlevel_level1Container = new GXWebGrid( context);
         Gridlevel_level1Column = new GXWebColumn();
         A2247SGNotificacionDetUsuarioDsc = "";
         sMode199 = "";
         sStyleString = "";
         AV11Insert_SGNotificacionUsuario = "";
         A2242SGNotificacionUsuarioDsc = "";
         AV22Pgmname = "";
         Combo_sgnotificacionusuario_Objectcall = "";
         Combo_sgnotificacionusuario_Class = "";
         Combo_sgnotificacionusuario_Icontype = "";
         Combo_sgnotificacionusuario_Icon = "";
         Combo_sgnotificacionusuario_Tooltip = "";
         Combo_sgnotificacionusuario_Selectedvalue_set = "";
         Combo_sgnotificacionusuario_Selectedtext_set = "";
         Combo_sgnotificacionusuario_Selectedtext_get = "";
         Combo_sgnotificacionusuario_Gamoauthtoken = "";
         Combo_sgnotificacionusuario_Ddointernalname = "";
         Combo_sgnotificacionusuario_Titlecontrolalign = "";
         Combo_sgnotificacionusuario_Dropdownoptionstype = "";
         Combo_sgnotificacionusuario_Titlecontrolidtoreplace = "";
         Combo_sgnotificacionusuario_Datalisttype = "";
         Combo_sgnotificacionusuario_Datalistfixedvalues = "";
         Combo_sgnotificacionusuario_Htmltemplate = "";
         Combo_sgnotificacionusuario_Multiplevaluestype = "";
         Combo_sgnotificacionusuario_Loadingdata = "";
         Combo_sgnotificacionusuario_Noresultsfound = "";
         Combo_sgnotificacionusuario_Emptyitemtext = "";
         Combo_sgnotificacionusuario_Onlyselectedvalues = "";
         Combo_sgnotificacionusuario_Selectalltext = "";
         Combo_sgnotificacionusuario_Multiplevaluesseparator = "";
         Combo_sgnotificacionusuario_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_sgnotificaciondetusuario_Objectcall = "";
         Combo_sgnotificaciondetusuario_Class = "";
         Combo_sgnotificaciondetusuario_Icontype = "";
         Combo_sgnotificaciondetusuario_Icon = "";
         Combo_sgnotificaciondetusuario_Tooltip = "";
         Combo_sgnotificaciondetusuario_Selectedvalue_set = "";
         Combo_sgnotificaciondetusuario_Selectedvalue_get = "";
         Combo_sgnotificaciondetusuario_Selectedtext_set = "";
         Combo_sgnotificaciondetusuario_Selectedtext_get = "";
         Combo_sgnotificaciondetusuario_Gamoauthtoken = "";
         Combo_sgnotificaciondetusuario_Ddointernalname = "";
         Combo_sgnotificaciondetusuario_Titlecontrolalign = "";
         Combo_sgnotificaciondetusuario_Dropdownoptionstype = "";
         Combo_sgnotificaciondetusuario_Datalisttype = "";
         Combo_sgnotificaciondetusuario_Datalistfixedvalues = "";
         Combo_sgnotificaciondetusuario_Htmltemplate = "";
         Combo_sgnotificaciondetusuario_Multiplevaluestype = "";
         Combo_sgnotificaciondetusuario_Loadingdata = "";
         Combo_sgnotificaciondetusuario_Noresultsfound = "";
         Combo_sgnotificaciondetusuario_Emptyitemtext = "";
         Combo_sgnotificaciondetusuario_Onlyselectedvalues = "";
         Combo_sgnotificaciondetusuario_Selectalltext = "";
         Combo_sgnotificaciondetusuario_Multiplevaluesseparator = "";
         Combo_sgnotificaciondetusuario_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode198 = "";
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
         GXt_char2 = "";
         Z2242SGNotificacionUsuarioDsc = "";
         T007A7_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T007A8_A2237SGNotificacionID = new long[1] ;
         T007A8_A2238SGNotificacionTitulo = new string[] {""} ;
         T007A8_A2239SGNotificacionDescripcion = new string[] {""} ;
         T007A8_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T007A8_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T007A8_A2243SGNotificacionIconClass = new string[] {""} ;
         T007A8_A2244SGNotificacionTUsuario = new short[1] ;
         T007A8_A2241SGNotificacionUsuario = new string[] {""} ;
         T007A9_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T007A10_A2237SGNotificacionID = new long[1] ;
         T007A6_A2237SGNotificacionID = new long[1] ;
         T007A6_A2238SGNotificacionTitulo = new string[] {""} ;
         T007A6_A2239SGNotificacionDescripcion = new string[] {""} ;
         T007A6_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T007A6_A2243SGNotificacionIconClass = new string[] {""} ;
         T007A6_A2244SGNotificacionTUsuario = new short[1] ;
         T007A6_A2241SGNotificacionUsuario = new string[] {""} ;
         T007A11_A2237SGNotificacionID = new long[1] ;
         T007A12_A2237SGNotificacionID = new long[1] ;
         T007A5_A2237SGNotificacionID = new long[1] ;
         T007A5_A2238SGNotificacionTitulo = new string[] {""} ;
         T007A5_A2239SGNotificacionDescripcion = new string[] {""} ;
         T007A5_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T007A5_A2243SGNotificacionIconClass = new string[] {""} ;
         T007A5_A2244SGNotificacionTUsuario = new short[1] ;
         T007A5_A2241SGNotificacionUsuario = new string[] {""} ;
         T007A16_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T007A17_A2237SGNotificacionID = new long[1] ;
         Z2247SGNotificacionDetUsuarioDsc = "";
         T007A18_A2237SGNotificacionID = new long[1] ;
         T007A18_A2245SGNotificacionDetID = new short[1] ;
         T007A18_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T007A18_A2248SGNotificacionDetEstado = new short[1] ;
         T007A18_A2246SGNotificacionDetUsuario = new string[] {""} ;
         T007A4_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T007A19_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T007A20_A2237SGNotificacionID = new long[1] ;
         T007A20_A2245SGNotificacionDetID = new short[1] ;
         T007A3_A2237SGNotificacionID = new long[1] ;
         T007A3_A2245SGNotificacionDetID = new short[1] ;
         T007A3_A2248SGNotificacionDetEstado = new short[1] ;
         T007A3_A2246SGNotificacionDetUsuario = new string[] {""} ;
         T007A2_A2237SGNotificacionID = new long[1] ;
         T007A2_A2245SGNotificacionDetID = new short[1] ;
         T007A2_A2248SGNotificacionDetEstado = new short[1] ;
         T007A2_A2246SGNotificacionDetUsuario = new string[] {""} ;
         T007A24_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T007A25_A2237SGNotificacionID = new long[1] ;
         T007A25_A2245SGNotificacionDetID = new short[1] ;
         Gridlevel_level1Row = new GXWebRow();
         subGridlevel_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificaciones__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificaciones__default(),
            new Object[][] {
                new Object[] {
               T007A2_A2237SGNotificacionID, T007A2_A2245SGNotificacionDetID, T007A2_A2248SGNotificacionDetEstado, T007A2_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               T007A3_A2237SGNotificacionID, T007A3_A2245SGNotificacionDetID, T007A3_A2248SGNotificacionDetEstado, T007A3_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               T007A4_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               T007A5_A2237SGNotificacionID, T007A5_A2238SGNotificacionTitulo, T007A5_A2239SGNotificacionDescripcion, T007A5_A2240SGNotificacionFecha, T007A5_A2243SGNotificacionIconClass, T007A5_A2244SGNotificacionTUsuario, T007A5_A2241SGNotificacionUsuario
               }
               , new Object[] {
               T007A6_A2237SGNotificacionID, T007A6_A2238SGNotificacionTitulo, T007A6_A2239SGNotificacionDescripcion, T007A6_A2240SGNotificacionFecha, T007A6_A2243SGNotificacionIconClass, T007A6_A2244SGNotificacionTUsuario, T007A6_A2241SGNotificacionUsuario
               }
               , new Object[] {
               T007A7_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               T007A8_A2237SGNotificacionID, T007A8_A2238SGNotificacionTitulo, T007A8_A2239SGNotificacionDescripcion, T007A8_A2240SGNotificacionFecha, T007A8_A2242SGNotificacionUsuarioDsc, T007A8_A2243SGNotificacionIconClass, T007A8_A2244SGNotificacionTUsuario, T007A8_A2241SGNotificacionUsuario
               }
               , new Object[] {
               T007A9_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               T007A10_A2237SGNotificacionID
               }
               , new Object[] {
               T007A11_A2237SGNotificacionID
               }
               , new Object[] {
               T007A12_A2237SGNotificacionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007A16_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               T007A17_A2237SGNotificacionID
               }
               , new Object[] {
               T007A18_A2237SGNotificacionID, T007A18_A2245SGNotificacionDetID, T007A18_A2247SGNotificacionDetUsuarioDsc, T007A18_A2248SGNotificacionDetEstado, T007A18_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               T007A19_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               T007A20_A2237SGNotificacionID, T007A20_A2245SGNotificacionDetID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007A24_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               T007A25_A2237SGNotificacionID, T007A25_A2245SGNotificacionDetID
               }
            }
         );
         AV22Pgmname = "Seguridad.Notificaciones";
      }

      private short Z2244SGNotificacionTUsuario ;
      private short Z2245SGNotificacionDetID ;
      private short Z2248SGNotificacionDetEstado ;
      private short nRcdDeleted_199 ;
      private short nRcdExists_199 ;
      private short nIsMod_199 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2244SGNotificacionTUsuario ;
      private short subGridlevel_level1_Backcolorstyle ;
      private short A2245SGNotificacionDetID ;
      private short A2248SGNotificacionDetEstado ;
      private short subGridlevel_level1_Allowselection ;
      private short subGridlevel_level1_Allowhovering ;
      private short subGridlevel_level1_Allowcollapsing ;
      private short subGridlevel_level1_Collapsed ;
      private short nBlankRcdCount199 ;
      private short RcdFound199 ;
      private short nBlankRcdUsr199 ;
      private short RcdFound198 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_198 ;
      private short nIsDirty_199 ;
      private short subGridlevel_level1_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_59 ;
      private int nGXsfl_59_idx=1 ;
      private int trnEnded ;
      private int edtSGNotificacionID_Enabled ;
      private int edtSGNotificacionTitulo_Enabled ;
      private int edtSGNotificacionDescripcion_Enabled ;
      private int edtSGNotificacionFecha_Enabled ;
      private int edtSGNotificacionUsuario_Visible ;
      private int edtSGNotificacionUsuario_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosgnotificacionusuario_Visible ;
      private int edtavCombosgnotificacionusuario_Enabled ;
      private int edtSGNotificacionTUsuario_Enabled ;
      private int edtSGNotificacionTUsuario_Visible ;
      private int edtSGNotificacionDetID_Enabled ;
      private int edtSGNotificacionDetUsuario_Enabled ;
      private int edtSGNotificacionDetUsuarioDsc_Enabled ;
      private int edtSGNotificacionDetEstado_Enabled ;
      private int subGridlevel_level1_Selectedindex ;
      private int subGridlevel_level1_Selectioncolor ;
      private int subGridlevel_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int Combo_sgnotificacionusuario_Datalistupdateminimumcharacters ;
      private int Combo_sgnotificacionusuario_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_sgnotificaciondetusuario_Datalistupdateminimumcharacters ;
      private int Combo_sgnotificaciondetusuario_Gxcontroltype ;
      private int AV23GXV1 ;
      private int subGridlevel_level1_Backcolor ;
      private int subGridlevel_level1_Allbackcolor ;
      private int defedtSGNotificacionDetID_Enabled ;
      private int idxLst ;
      private long wcpOAV7SGNotificacionID ;
      private long Z2237SGNotificacionID ;
      private long AV7SGNotificacionID ;
      private long A2237SGNotificacionID ;
      private long AV21cSGNotificacionID ;
      private long GRIDLEVEL_LEVEL1_nFirstRecordOnPage ;
      private long GXt_int3 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z2241SGNotificacionUsuario ;
      private string N2241SGNotificacionUsuario ;
      private string Combo_sgnotificacionusuario_Selectedvalue_get ;
      private string Z2246SGNotificacionDetUsuario ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2241SGNotificacionUsuario ;
      private string A2246SGNotificacionDetUsuario ;
      private string sGXsfl_59_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSGNotificacionID_Internalname ;
      private string cmbSGNotificacionIconClass_Internalname ;
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
      private string edtSGNotificacionID_Jsonclick ;
      private string edtSGNotificacionTitulo_Internalname ;
      private string edtSGNotificacionTitulo_Jsonclick ;
      private string edtSGNotificacionDescripcion_Internalname ;
      private string edtSGNotificacionFecha_Internalname ;
      private string edtSGNotificacionFecha_Jsonclick ;
      private string divTablesplittedsgnotificacionusuario_Internalname ;
      private string lblTextblocksgnotificacionusuario_Internalname ;
      private string lblTextblocksgnotificacionusuario_Jsonclick ;
      private string Combo_sgnotificacionusuario_Caption ;
      private string Combo_sgnotificacionusuario_Cls ;
      private string Combo_sgnotificacionusuario_Datalistproc ;
      private string Combo_sgnotificacionusuario_Datalistprocparametersprefix ;
      private string Combo_sgnotificacionusuario_Internalname ;
      private string edtSGNotificacionUsuario_Internalname ;
      private string edtSGNotificacionUsuario_Jsonclick ;
      private string cmbSGNotificacionIconClass_Jsonclick ;
      private string divTableleaflevel_level1_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_sgnotificacionusuario_Internalname ;
      private string edtavCombosgnotificacionusuario_Internalname ;
      private string AV18ComboSGNotificacionUsuario ;
      private string edtavCombosgnotificacionusuario_Jsonclick ;
      private string Combo_sgnotificaciondetusuario_Caption ;
      private string Combo_sgnotificaciondetusuario_Cls ;
      private string Combo_sgnotificaciondetusuario_Datalistproc ;
      private string Combo_sgnotificaciondetusuario_Datalistprocparametersprefix ;
      private string Combo_sgnotificaciondetusuario_Internalname ;
      private string edtSGNotificacionTUsuario_Internalname ;
      private string edtSGNotificacionTUsuario_Jsonclick ;
      private string subGridlevel_level1_Header ;
      private string A2247SGNotificacionDetUsuarioDsc ;
      private string sMode199 ;
      private string edtSGNotificacionDetID_Internalname ;
      private string edtSGNotificacionDetUsuario_Internalname ;
      private string edtSGNotificacionDetUsuarioDsc_Internalname ;
      private string edtSGNotificacionDetEstado_Internalname ;
      private string sStyleString ;
      private string AV11Insert_SGNotificacionUsuario ;
      private string A2242SGNotificacionUsuarioDsc ;
      private string AV22Pgmname ;
      private string Combo_sgnotificacionusuario_Objectcall ;
      private string Combo_sgnotificacionusuario_Class ;
      private string Combo_sgnotificacionusuario_Icontype ;
      private string Combo_sgnotificacionusuario_Icon ;
      private string Combo_sgnotificacionusuario_Tooltip ;
      private string Combo_sgnotificacionusuario_Selectedvalue_set ;
      private string Combo_sgnotificacionusuario_Selectedtext_set ;
      private string Combo_sgnotificacionusuario_Selectedtext_get ;
      private string Combo_sgnotificacionusuario_Gamoauthtoken ;
      private string Combo_sgnotificacionusuario_Ddointernalname ;
      private string Combo_sgnotificacionusuario_Titlecontrolalign ;
      private string Combo_sgnotificacionusuario_Dropdownoptionstype ;
      private string Combo_sgnotificacionusuario_Titlecontrolidtoreplace ;
      private string Combo_sgnotificacionusuario_Datalisttype ;
      private string Combo_sgnotificacionusuario_Datalistfixedvalues ;
      private string Combo_sgnotificacionusuario_Htmltemplate ;
      private string Combo_sgnotificacionusuario_Multiplevaluestype ;
      private string Combo_sgnotificacionusuario_Loadingdata ;
      private string Combo_sgnotificacionusuario_Noresultsfound ;
      private string Combo_sgnotificacionusuario_Emptyitemtext ;
      private string Combo_sgnotificacionusuario_Onlyselectedvalues ;
      private string Combo_sgnotificacionusuario_Selectalltext ;
      private string Combo_sgnotificacionusuario_Multiplevaluesseparator ;
      private string Combo_sgnotificacionusuario_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_sgnotificaciondetusuario_Objectcall ;
      private string Combo_sgnotificaciondetusuario_Class ;
      private string Combo_sgnotificaciondetusuario_Icontype ;
      private string Combo_sgnotificaciondetusuario_Icon ;
      private string Combo_sgnotificaciondetusuario_Tooltip ;
      private string Combo_sgnotificaciondetusuario_Selectedvalue_set ;
      private string Combo_sgnotificaciondetusuario_Selectedvalue_get ;
      private string Combo_sgnotificaciondetusuario_Selectedtext_set ;
      private string Combo_sgnotificaciondetusuario_Selectedtext_get ;
      private string Combo_sgnotificaciondetusuario_Gamoauthtoken ;
      private string Combo_sgnotificaciondetusuario_Ddointernalname ;
      private string Combo_sgnotificaciondetusuario_Titlecontrolalign ;
      private string Combo_sgnotificaciondetusuario_Dropdownoptionstype ;
      private string Combo_sgnotificaciondetusuario_Titlecontrolidtoreplace ;
      private string Combo_sgnotificaciondetusuario_Datalisttype ;
      private string Combo_sgnotificaciondetusuario_Datalistfixedvalues ;
      private string Combo_sgnotificaciondetusuario_Htmltemplate ;
      private string Combo_sgnotificaciondetusuario_Multiplevaluestype ;
      private string Combo_sgnotificaciondetusuario_Loadingdata ;
      private string Combo_sgnotificaciondetusuario_Noresultsfound ;
      private string Combo_sgnotificaciondetusuario_Emptyitemtext ;
      private string Combo_sgnotificaciondetusuario_Onlyselectedvalues ;
      private string Combo_sgnotificaciondetusuario_Selectalltext ;
      private string Combo_sgnotificaciondetusuario_Multiplevaluesseparator ;
      private string Combo_sgnotificaciondetusuario_Addnewoptiontext ;
      private string hsh ;
      private string sMode198 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string GXt_char2 ;
      private string Z2242SGNotificacionUsuarioDsc ;
      private string Z2247SGNotificacionDetUsuarioDsc ;
      private string sGXsfl_59_fel_idx="0001" ;
      private string subGridlevel_level1_Class ;
      private string subGridlevel_level1_Linesclass ;
      private string ROClassString ;
      private string edtSGNotificacionDetID_Jsonclick ;
      private string edtSGNotificacionDetUsuario_Jsonclick ;
      private string edtSGNotificacionDetUsuarioDsc_Jsonclick ;
      private string edtSGNotificacionDetEstado_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_level1_Internalname ;
      private DateTime Z2240SGNotificacionFecha ;
      private DateTime A2240SGNotificacionFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_sgnotificacionusuario_Emptyitem ;
      private bool Combo_sgnotificaciondetusuario_Isgriditem ;
      private bool Combo_sgnotificaciondetusuario_Hasdescription ;
      private bool Combo_sgnotificaciondetusuario_Emptyitem ;
      private bool bGXsfl_59_Refreshing=false ;
      private bool Combo_sgnotificacionusuario_Enabled ;
      private bool Combo_sgnotificacionusuario_Visible ;
      private bool Combo_sgnotificacionusuario_Allowmultipleselection ;
      private bool Combo_sgnotificacionusuario_Isgriditem ;
      private bool Combo_sgnotificacionusuario_Hasdescription ;
      private bool Combo_sgnotificacionusuario_Includeonlyselectedoption ;
      private bool Combo_sgnotificacionusuario_Includeselectalloption ;
      private bool Combo_sgnotificacionusuario_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_sgnotificaciondetusuario_Enabled ;
      private bool Combo_sgnotificaciondetusuario_Visible ;
      private bool Combo_sgnotificaciondetusuario_Allowmultipleselection ;
      private bool Combo_sgnotificaciondetusuario_Includeonlyselectedoption ;
      private bool Combo_sgnotificaciondetusuario_Includeselectalloption ;
      private bool Combo_sgnotificaciondetusuario_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV17Combo_DataJson ;
      private string Z2238SGNotificacionTitulo ;
      private string Z2239SGNotificacionDescripcion ;
      private string Z2243SGNotificacionIconClass ;
      private string A2243SGNotificacionIconClass ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_level1Container ;
      private GXWebRow Gridlevel_level1Row ;
      private GXWebColumn Gridlevel_level1Column ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_sgnotificacionusuario ;
      private GXUserControl ucCombo_sgnotificaciondetusuario ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSGNotificacionIconClass ;
      private IDataStoreProvider pr_default ;
      private string[] T007A7_A2242SGNotificacionUsuarioDsc ;
      private long[] T007A8_A2237SGNotificacionID ;
      private string[] T007A8_A2238SGNotificacionTitulo ;
      private string[] T007A8_A2239SGNotificacionDescripcion ;
      private DateTime[] T007A8_A2240SGNotificacionFecha ;
      private string[] T007A8_A2242SGNotificacionUsuarioDsc ;
      private string[] T007A8_A2243SGNotificacionIconClass ;
      private short[] T007A8_A2244SGNotificacionTUsuario ;
      private string[] T007A8_A2241SGNotificacionUsuario ;
      private string[] T007A9_A2242SGNotificacionUsuarioDsc ;
      private long[] T007A10_A2237SGNotificacionID ;
      private long[] T007A6_A2237SGNotificacionID ;
      private string[] T007A6_A2238SGNotificacionTitulo ;
      private string[] T007A6_A2239SGNotificacionDescripcion ;
      private DateTime[] T007A6_A2240SGNotificacionFecha ;
      private string[] T007A6_A2243SGNotificacionIconClass ;
      private short[] T007A6_A2244SGNotificacionTUsuario ;
      private string[] T007A6_A2241SGNotificacionUsuario ;
      private long[] T007A11_A2237SGNotificacionID ;
      private long[] T007A12_A2237SGNotificacionID ;
      private long[] T007A5_A2237SGNotificacionID ;
      private string[] T007A5_A2238SGNotificacionTitulo ;
      private string[] T007A5_A2239SGNotificacionDescripcion ;
      private DateTime[] T007A5_A2240SGNotificacionFecha ;
      private string[] T007A5_A2243SGNotificacionIconClass ;
      private short[] T007A5_A2244SGNotificacionTUsuario ;
      private string[] T007A5_A2241SGNotificacionUsuario ;
      private string[] T007A16_A2242SGNotificacionUsuarioDsc ;
      private long[] T007A17_A2237SGNotificacionID ;
      private long[] T007A18_A2237SGNotificacionID ;
      private short[] T007A18_A2245SGNotificacionDetID ;
      private string[] T007A18_A2247SGNotificacionDetUsuarioDsc ;
      private short[] T007A18_A2248SGNotificacionDetEstado ;
      private string[] T007A18_A2246SGNotificacionDetUsuario ;
      private string[] T007A4_A2247SGNotificacionDetUsuarioDsc ;
      private string[] T007A19_A2247SGNotificacionDetUsuarioDsc ;
      private long[] T007A20_A2237SGNotificacionID ;
      private short[] T007A20_A2245SGNotificacionDetID ;
      private long[] T007A3_A2237SGNotificacionID ;
      private short[] T007A3_A2245SGNotificacionDetID ;
      private short[] T007A3_A2248SGNotificacionDetEstado ;
      private string[] T007A3_A2246SGNotificacionDetUsuario ;
      private long[] T007A2_A2237SGNotificacionID ;
      private short[] T007A2_A2245SGNotificacionDetID ;
      private short[] T007A2_A2248SGNotificacionDetEstado ;
      private string[] T007A2_A2246SGNotificacionDetUsuario ;
      private string[] T007A24_A2247SGNotificacionDetUsuarioDsc ;
      private long[] T007A25_A2237SGNotificacionID ;
      private short[] T007A25_A2245SGNotificacionDetID ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13SGNotificacionUsuario_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20SGNotificacionDetUsuario_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class notificaciones__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class notificaciones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007A8;
        prmT007A8 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A7;
        prmT007A7 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A9;
        prmT007A9 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A10;
        prmT007A10 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A6;
        prmT007A6 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A11;
        prmT007A11 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A12;
        prmT007A12 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A5;
        prmT007A5 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A13;
        prmT007A13 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionTitulo",GXType.NVarChar,100,0) ,
        new ParDef("@SGNotificacionDescripcion",GXType.NVarChar,200,0) ,
        new ParDef("@SGNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGNotificacionIconClass",GXType.NVarChar,60,0) ,
        new ParDef("@SGNotificacionTUsuario",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A14;
        prmT007A14 = new Object[] {
        new ParDef("@SGNotificacionTitulo",GXType.NVarChar,100,0) ,
        new ParDef("@SGNotificacionDescripcion",GXType.NVarChar,200,0) ,
        new ParDef("@SGNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGNotificacionIconClass",GXType.NVarChar,60,0) ,
        new ParDef("@SGNotificacionTUsuario",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A15;
        prmT007A15 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A17;
        prmT007A17 = new Object[] {
        };
        Object[] prmT007A18;
        prmT007A18 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007A4;
        prmT007A4 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A19;
        prmT007A19 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A20;
        prmT007A20 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007A3;
        prmT007A3 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007A2;
        prmT007A2 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007A21;
        prmT007A21 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionDetEstado",GXType.Int16,1,0) ,
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A22;
        prmT007A22 = new Object[] {
        new ParDef("@SGNotificacionDetEstado",GXType.Int16,1,0) ,
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007A23;
        prmT007A23 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007A25;
        prmT007A25 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007A16;
        prmT007A16 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007A24;
        prmT007A24 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007A2", "SELECT [SGNotificacionID], [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM [SGNOTIFICACIONESDET] WITH (UPDLOCK) WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A3", "SELECT [SGNotificacionID], [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A4", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A5", "SELECT [SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario] AS SGNotificacionUsuario FROM [SGNOTIFICACIONES] WITH (UPDLOCK) WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A6", "SELECT [SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario] AS SGNotificacionUsuario FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A7", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A8", "SELECT TM1.[SGNotificacionID], TM1.[SGNotificacionTitulo], TM1.[SGNotificacionDescripcion], TM1.[SGNotificacionFecha], T2.[UsuNom] AS SGNotificacionUsuarioDsc, TM1.[SGNotificacionIconClass], TM1.[SGNotificacionTUsuario], TM1.[SGNotificacionUsuario] AS SGNotificacionUsuario FROM ([SGNOTIFICACIONES] TM1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = TM1.[SGNotificacionUsuario]) WHERE TM1.[SGNotificacionID] = @SGNotificacionID ORDER BY TM1.[SGNotificacionID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007A8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A9", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A10", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007A10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A11", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE ( [SGNotificacionID] > @SGNotificacionID) ORDER BY [SGNotificacionID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007A12", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE ( [SGNotificacionID] < @SGNotificacionID) ORDER BY [SGNotificacionID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007A12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007A13", "INSERT INTO [SGNOTIFICACIONES]([SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario]) VALUES(@SGNotificacionID, @SGNotificacionTitulo, @SGNotificacionDescripcion, @SGNotificacionFecha, @SGNotificacionIconClass, @SGNotificacionTUsuario, @SGNotificacionUsuario)", GxErrorMask.GX_NOMASK,prmT007A13)
           ,new CursorDef("T007A14", "UPDATE [SGNOTIFICACIONES] SET [SGNotificacionTitulo]=@SGNotificacionTitulo, [SGNotificacionDescripcion]=@SGNotificacionDescripcion, [SGNotificacionFecha]=@SGNotificacionFecha, [SGNotificacionIconClass]=@SGNotificacionIconClass, [SGNotificacionTUsuario]=@SGNotificacionTUsuario, [SGNotificacionUsuario]=@SGNotificacionUsuario  WHERE [SGNotificacionID] = @SGNotificacionID", GxErrorMask.GX_NOMASK,prmT007A14)
           ,new CursorDef("T007A15", "DELETE FROM [SGNOTIFICACIONES]  WHERE [SGNotificacionID] = @SGNotificacionID", GxErrorMask.GX_NOMASK,prmT007A15)
           ,new CursorDef("T007A16", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A17", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] ORDER BY [SGNotificacionID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007A17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A18", "SELECT T1.[SGNotificacionID], T1.[SGNotificacionDetID], T2.[UsuNom] AS SGNotificacionDetUsuarioDsc, T1.[SGNotificacionDetEstado], T1.[SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM ([SGNOTIFICACIONESDET] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionDetUsuario]) WHERE T1.[SGNotificacionID] = @SGNotificacionID and T1.[SGNotificacionDetID] = @SGNotificacionDetID ORDER BY T1.[SGNotificacionID], T1.[SGNotificacionDetID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A18,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A19", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A20", "SELECT [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A21", "INSERT INTO [SGNOTIFICACIONESDET]([SGNotificacionID], [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionDetUsuario]) VALUES(@SGNotificacionID, @SGNotificacionDetID, @SGNotificacionDetEstado, @SGNotificacionDetUsuario)", GxErrorMask.GX_NOMASK,prmT007A21)
           ,new CursorDef("T007A22", "UPDATE [SGNOTIFICACIONESDET] SET [SGNotificacionDetEstado]=@SGNotificacionDetEstado, [SGNotificacionDetUsuario]=@SGNotificacionDetUsuario  WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID", GxErrorMask.GX_NOMASK,prmT007A22)
           ,new CursorDef("T007A23", "DELETE FROM [SGNOTIFICACIONESDET]  WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID", GxErrorMask.GX_NOMASK,prmT007A23)
           ,new CursorDef("T007A24", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007A25", "SELECT [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID ORDER BY [SGNotificacionID], [SGNotificacionDetID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007A25,11, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
