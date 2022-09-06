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
   public class usuariosopciones : GXWebComponent
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               nDynComponent = 1;
               sCompPrefix = GetPar( "sCompPrefix");
               sSFPrefix = GetPar( "sSFPrefix");
               Gx_mode = GetPar( "Mode");
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               AV7UsuCod = GetPar( "UsuCod");
               AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV7UsuCod});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
            {
               A2016UsuMosBanCod = (int)(NumberUtil.Val( GetPar( "UsuMosBanCod"), "."));
               n2016UsuMosBanCod = false;
               AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_19( A2016UsuMosBanCod) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
            {
               A2016UsuMosBanCod = (int)(NumberUtil.Val( GetPar( "UsuMosBanCod"), "."));
               n2016UsuMosBanCod = false;
               AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
               A2017UsuMosCBCod = GetPar( "UsuMosCBCod");
               n2017UsuMosCBCod = false;
               AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_20( A2016UsuMosBanCod, A2017UsuMosCBCod) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
            {
               A350UsuMosConcepto = (int)(NumberUtil.Val( GetPar( "UsuMosConcepto"), "."));
               n350UsuMosConcepto = false;
               AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_21( A350UsuMosConcepto) ;
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
         }
         GXKey = Crypto.GetSiteKey( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.usuariosopciones.aspx")), "seguridad.usuariosopciones.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.usuariosopciones.aspx")))) ;
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
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Mode");
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_web_controls( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "Usuarios Opciones", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
            if ( nDynComponent == 0 )
            {
               context.HttpContext.Response.StatusCode = 404;
               GXUtil.WriteLog("send_http_error_code " + 404.ToString());
               GxWebError = 1;
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = chkUsuPedPrecio_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public usuariosopciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
      }

      public usuariosopciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_UsuCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7UsuCod = aP1_UsuCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkUsuPedPrecio = new GXCheckbox();
         chkUsuPedDscto = new GXCheckbox();
         chkUsuPedStock = new GXCheckbox();
         chkUsuPedVend = new GXCheckbox();
         chkUsuPedCond = new GXCheckbox();
         chkUsuPedList = new GXCheckbox();
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
         A2027UsuPedPrecio = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2027UsuPedPrecio), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
         A2023UsuPedDscto = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2023UsuPedDscto), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
         A2028UsuPedStock = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2028UsuPedStock), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
         A2029UsuPedVend = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2029UsuPedVend), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
         A2022UsuPedCond = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2022UsuPedCond), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
         A2024UsuPedList = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2024UsuPedList), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
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
            RenderHtmlCloseForm5H32( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "seguridad.usuariosopciones.aspx");
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         }
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablamensaje_Internalname, divTablamensaje_Visible, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtcontacmsj_Internalname, "Por favor, confirme primero los datos generales.", "", "", lblTxtcontacmsj_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablacontenido_Internalname, divTablacontenido_Visible, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_panelopcionespedidos.SetProperty("Width", Dvpanel_panelopcionespedidos_Width);
         ucDvpanel_panelopcionespedidos.SetProperty("AutoWidth", Dvpanel_panelopcionespedidos_Autowidth);
         ucDvpanel_panelopcionespedidos.SetProperty("AutoHeight", Dvpanel_panelopcionespedidos_Autoheight);
         ucDvpanel_panelopcionespedidos.SetProperty("Cls", Dvpanel_panelopcionespedidos_Cls);
         ucDvpanel_panelopcionespedidos.SetProperty("Title", Dvpanel_panelopcionespedidos_Title);
         ucDvpanel_panelopcionespedidos.SetProperty("Collapsible", Dvpanel_panelopcionespedidos_Collapsible);
         ucDvpanel_panelopcionespedidos.SetProperty("Collapsed", Dvpanel_panelopcionespedidos_Collapsed);
         ucDvpanel_panelopcionespedidos.SetProperty("ShowCollapseIcon", Dvpanel_panelopcionespedidos_Showcollapseicon);
         ucDvpanel_panelopcionespedidos.SetProperty("IconPosition", Dvpanel_panelopcionespedidos_Iconposition);
         ucDvpanel_panelopcionespedidos.SetProperty("AutoScroll", Dvpanel_panelopcionespedidos_Autoscroll);
         ucDvpanel_panelopcionespedidos.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panelopcionespedidos_Internalname, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_PANELOPCIONESPEDIDOSContainer"+"PanelOpcionesPedidos"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divPanelopcionespedidos_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedPrecio_Internalname, "Permite Modificar Precios", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedPrecio_Internalname, StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0), "", "Permite Modificar Precios", 1, chkUsuPedPrecio.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 1, 0,"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedDscto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedDscto_Internalname, "Permite Modificar Descuentos", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedDscto_Internalname, StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0), "", "Permite Modificar Descuentos", 1, chkUsuPedDscto.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 1, 0,"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedStock_Internalname, "Mostrar Stock Disponible", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedStock_Internalname, StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0), "", "Mostrar Stock Disponible", 1, chkUsuPedStock.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 1, 0,"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedVend_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedVend_Internalname, "Permite Modificar Vendedor", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedVend_Internalname, StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0), "", "Permite Modificar Vendedor", 1, chkUsuPedVend.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 1, 0,"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedCond_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedCond_Internalname, "Permite Modificar Condición de Pago", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedCond_Internalname, StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0), "", "Permite Modificar Condición de Pago", 1, chkUsuPedCond.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(51, this, 1, 0,"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedList_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedList_Internalname, "Permite Modificar Lista de Precios", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedList_Internalname, StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0), "", "Permite Modificar Lista de Precios", 1, chkUsuPedList.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 1, 0,"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedusupedmon_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusupedmon_Internalname, "Moneda Default", "", "", lblTextblockusupedmon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usupedmon.SetProperty("Caption", Combo_usupedmon_Caption);
         ucCombo_usupedmon.SetProperty("Cls", Combo_usupedmon_Cls);
         ucCombo_usupedmon.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_usupedmon.SetProperty("DropDownOptionsData", AV29UsuPedMon_Data);
         ucCombo_usupedmon.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usupedmon_Internalname, sPrefix+"COMBO_USUPEDMONContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuPedMon_Internalname, "Moneda Default", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuPedMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2026UsuPedMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuPedMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A2026UsuPedMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2026UsuPedMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuPedMon_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuPedMon_Visible, edtUsuPedMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\UsuariosOpciones.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_panelfiltromostrador.SetProperty("Width", Dvpanel_panelfiltromostrador_Width);
         ucDvpanel_panelfiltromostrador.SetProperty("AutoWidth", Dvpanel_panelfiltromostrador_Autowidth);
         ucDvpanel_panelfiltromostrador.SetProperty("AutoHeight", Dvpanel_panelfiltromostrador_Autoheight);
         ucDvpanel_panelfiltromostrador.SetProperty("Cls", Dvpanel_panelfiltromostrador_Cls);
         ucDvpanel_panelfiltromostrador.SetProperty("Title", Dvpanel_panelfiltromostrador_Title);
         ucDvpanel_panelfiltromostrador.SetProperty("Collapsible", Dvpanel_panelfiltromostrador_Collapsible);
         ucDvpanel_panelfiltromostrador.SetProperty("Collapsed", Dvpanel_panelfiltromostrador_Collapsed);
         ucDvpanel_panelfiltromostrador.SetProperty("ShowCollapseIcon", Dvpanel_panelfiltromostrador_Showcollapseicon);
         ucDvpanel_panelfiltromostrador.SetProperty("IconPosition", Dvpanel_panelfiltromostrador_Iconposition);
         ucDvpanel_panelfiltromostrador.SetProperty("AutoScroll", Dvpanel_panelfiltromostrador_Autoscroll);
         ucDvpanel_panelfiltromostrador.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panelfiltromostrador_Internalname, sPrefix+"DVPANEL_PANELFILTROMOSTRADORContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_PANELFILTROMOSTRADORContainer"+"PanelFiltroMostrador"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divPanelfiltromostrador_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedusumosbancod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusumosbancod_Internalname, "Banco", "", "", lblTextblockusumosbancod_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usumosbancod.SetProperty("Caption", Combo_usumosbancod_Caption);
         ucCombo_usumosbancod.SetProperty("Cls", Combo_usumosbancod_Cls);
         ucCombo_usumosbancod.SetProperty("DataListProc", Combo_usumosbancod_Datalistproc);
         ucCombo_usumosbancod.SetProperty("DataListProcParametersPrefix", Combo_usumosbancod_Datalistprocparametersprefix);
         ucCombo_usumosbancod.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_usumosbancod.SetProperty("DropDownOptionsData", AV22UsuMosBanCod_Data);
         ucCombo_usumosbancod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usumosbancod_Internalname, sPrefix+"COMBO_USUMOSBANCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosBanCod_Internalname, "Banco", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuMosBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2016UsuMosBanCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2016UsuMosBanCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosBanCod_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuMosBanCod_Visible, edtUsuMosBanCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\UsuariosOpciones.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedusumoscbcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusumoscbcod_Internalname, "Cuenta", "", "", lblTextblockusumoscbcod_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usumoscbcod.SetProperty("Caption", Combo_usumoscbcod_Caption);
         ucCombo_usumoscbcod.SetProperty("Cls", Combo_usumoscbcod_Cls);
         ucCombo_usumoscbcod.SetProperty("DataListProc", Combo_usumoscbcod_Datalistproc);
         ucCombo_usumoscbcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_usumoscbcod.SetProperty("DropDownOptionsData", AV25UsuMosCBCod_Data);
         ucCombo_usumoscbcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usumoscbcod_Internalname, sPrefix+"COMBO_USUMOSCBCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosCBCod_Internalname, "N° Cuenta", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuMosCBCod_Internalname, StringUtil.RTrim( A2017UsuMosCBCod), StringUtil.RTrim( context.localUtil.Format( A2017UsuMosCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosCBCod_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuMosCBCod_Visible, edtUsuMosCBCod_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosOpciones.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedusumosconcepto_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusumosconcepto_Internalname, "Concepto", "", "", lblTextblockusumosconcepto_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usumosconcepto.SetProperty("Caption", Combo_usumosconcepto_Caption);
         ucCombo_usumosconcepto.SetProperty("Cls", Combo_usumosconcepto_Cls);
         ucCombo_usumosconcepto.SetProperty("DataListProc", Combo_usumosconcepto_Datalistproc);
         ucCombo_usumosconcepto.SetProperty("DataListProcParametersPrefix", Combo_usumosconcepto_Datalistprocparametersprefix);
         ucCombo_usumosconcepto.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_usumosconcepto.SetProperty("DropDownOptionsData", AV13UsuMosConcepto_Data);
         ucCombo_usumosconcepto.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usumosconcepto_Internalname, sPrefix+"COMBO_USUMOSCONCEPTOContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosConcepto_Internalname, "Concepto", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuMosConcepto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A350UsuMosConcepto), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A350UsuMosConcepto), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosConcepto_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuMosConcepto_Visible, edtUsuMosConcepto_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\UsuariosOpciones.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosOpciones.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_usupedmon_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV30ComboUsuPedMon", StringUtil.LTrimStr( (decimal)(AV30ComboUsuPedMon), 6, 0));
         GxWebStd.gx_single_line_edit( context, edtavCombousupedmon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ComboUsuPedMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombousupedmon_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30ComboUsuPedMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV30ComboUsuPedMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombousupedmon_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombousupedmon_Visible, edtavCombousupedmon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_usumosbancod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV23ComboUsuMosBanCod", StringUtil.LTrimStr( (decimal)(AV23ComboUsuMosBanCod), 6, 0));
         GxWebStd.gx_single_line_edit( context, edtavCombousumosbancod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ComboUsuMosBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombousumosbancod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23ComboUsuMosBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV23ComboUsuMosBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombousumosbancod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombousumosbancod_Visible, edtavCombousumosbancod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_usumoscbcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV26ComboUsuMosCBCod", AV26ComboUsuMosCBCod);
         GxWebStd.gx_single_line_edit( context, edtavCombousumoscbcod_Internalname, StringUtil.RTrim( AV26ComboUsuMosCBCod), StringUtil.RTrim( context.localUtil.Format( AV26ComboUsuMosCBCod, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombousumoscbcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombousumoscbcod_Visible, edtavCombousumoscbcod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_usumosconcepto_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "AV18ComboUsuMosConcepto", StringUtil.LTrimStr( (decimal)(AV18ComboUsuMosConcepto), 6, 0));
         GxWebStd.gx_single_line_edit( context, edtavCombousumosconcepto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboUsuMosConcepto), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombousumosconcepto_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboUsuMosConcepto), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboUsuMosConcepto), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombousumosconcepto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombousumosconcepto_Visible, edtavCombousumosconcepto_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\UsuariosOpciones.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuCod_Visible, edtUsuCod_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosOpciones.htm");
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
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUSUPEDMON_DATA"), AV29UsuPedMon_Data);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUSUMOSBANCOD_DATA"), AV22UsuMosBanCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUSUMOSCBCOD_DATA"), AV25UsuMosCBCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUSUMOSCONCEPTO_DATA"), AV13UsuMosConcepto_Data);
               /* Read saved values. */
               Z348UsuCod = cgiGet( sPrefix+"Z348UsuCod");
               Z2026UsuPedMon = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z2026UsuPedMon"), ".", ","));
               n2026UsuPedMon = ((0==A2026UsuPedMon) ? true : false);
               Z2019UsuNom = cgiGet( sPrefix+"Z2019UsuNom");
               Z2027UsuPedPrecio = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2027UsuPedPrecio"), ".", ","));
               Z2023UsuPedDscto = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2023UsuPedDscto"), ".", ","));
               Z2028UsuPedStock = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2028UsuPedStock"), ".", ","));
               Z2029UsuPedVend = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2029UsuPedVend"), ".", ","));
               Z2022UsuPedCond = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2022UsuPedCond"), ".", ","));
               Z2024UsuPedList = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2024UsuPedList"), ".", ","));
               Z2016UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z2016UsuMosBanCod"), ".", ","));
               n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
               Z2017UsuMosCBCod = cgiGet( sPrefix+"Z2017UsuMosCBCod");
               n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
               Z350UsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z350UsuMosConcepto"), ".", ","));
               n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7UsuCod = cgiGet( sPrefix+"wcpOAV7UsuCod");
               A2019UsuNom = cgiGet( sPrefix+"Z2019UsuNom");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N2016UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N2016UsuMosBanCod"), ".", ","));
               n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
               N2017UsuMosCBCod = cgiGet( sPrefix+"N2017UsuMosCBCod");
               n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
               N350UsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N350UsuMosConcepto"), ".", ","));
               n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
               AV28Cond_UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vCOND_USUMOSBANCOD"), ".", ","));
               AV7UsuCod = cgiGet( sPrefix+"vUSUCOD");
               AV20Insert_UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_USUMOSBANCOD"), ".", ","));
               AV21Insert_UsuMosCBCod = cgiGet( sPrefix+"vINSERT_USUMOSCBCOD");
               AV11Insert_UsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_USUMOSCONCEPTO"), ".", ","));
               A2019UsuNom = cgiGet( sPrefix+"USUNOM");
               A2018UsuMosConceptoDsc = cgiGet( sPrefix+"USUMOSCONCEPTODSC");
               AV31Pgmname = cgiGet( sPrefix+"vPGMNAME");
               Combo_usupedmon_Objectcall = cgiGet( sPrefix+"COMBO_USUPEDMON_Objectcall");
               Combo_usupedmon_Class = cgiGet( sPrefix+"COMBO_USUPEDMON_Class");
               Combo_usupedmon_Icontype = cgiGet( sPrefix+"COMBO_USUPEDMON_Icontype");
               Combo_usupedmon_Icon = cgiGet( sPrefix+"COMBO_USUPEDMON_Icon");
               Combo_usupedmon_Caption = cgiGet( sPrefix+"COMBO_USUPEDMON_Caption");
               Combo_usupedmon_Tooltip = cgiGet( sPrefix+"COMBO_USUPEDMON_Tooltip");
               Combo_usupedmon_Cls = cgiGet( sPrefix+"COMBO_USUPEDMON_Cls");
               Combo_usupedmon_Selectedvalue_set = cgiGet( sPrefix+"COMBO_USUPEDMON_Selectedvalue_set");
               Combo_usupedmon_Selectedvalue_get = cgiGet( sPrefix+"COMBO_USUPEDMON_Selectedvalue_get");
               Combo_usupedmon_Selectedtext_set = cgiGet( sPrefix+"COMBO_USUPEDMON_Selectedtext_set");
               Combo_usupedmon_Selectedtext_get = cgiGet( sPrefix+"COMBO_USUPEDMON_Selectedtext_get");
               Combo_usupedmon_Gamoauthtoken = cgiGet( sPrefix+"COMBO_USUPEDMON_Gamoauthtoken");
               Combo_usupedmon_Ddointernalname = cgiGet( sPrefix+"COMBO_USUPEDMON_Ddointernalname");
               Combo_usupedmon_Titlecontrolalign = cgiGet( sPrefix+"COMBO_USUPEDMON_Titlecontrolalign");
               Combo_usupedmon_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_USUPEDMON_Dropdownoptionstype");
               Combo_usupedmon_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Enabled"));
               Combo_usupedmon_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Visible"));
               Combo_usupedmon_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_USUPEDMON_Titlecontrolidtoreplace");
               Combo_usupedmon_Datalisttype = cgiGet( sPrefix+"COMBO_USUPEDMON_Datalisttype");
               Combo_usupedmon_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Allowmultipleselection"));
               Combo_usupedmon_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_USUPEDMON_Datalistfixedvalues");
               Combo_usupedmon_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Isgriditem"));
               Combo_usupedmon_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Hasdescription"));
               Combo_usupedmon_Datalistproc = cgiGet( sPrefix+"COMBO_USUPEDMON_Datalistproc");
               Combo_usupedmon_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_USUPEDMON_Datalistprocparametersprefix");
               Combo_usupedmon_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUPEDMON_Datalistupdateminimumcharacters"), ".", ","));
               Combo_usupedmon_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Includeonlyselectedoption"));
               Combo_usupedmon_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Includeselectalloption"));
               Combo_usupedmon_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Emptyitem"));
               Combo_usupedmon_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUPEDMON_Includeaddnewoption"));
               Combo_usupedmon_Htmltemplate = cgiGet( sPrefix+"COMBO_USUPEDMON_Htmltemplate");
               Combo_usupedmon_Multiplevaluestype = cgiGet( sPrefix+"COMBO_USUPEDMON_Multiplevaluestype");
               Combo_usupedmon_Loadingdata = cgiGet( sPrefix+"COMBO_USUPEDMON_Loadingdata");
               Combo_usupedmon_Noresultsfound = cgiGet( sPrefix+"COMBO_USUPEDMON_Noresultsfound");
               Combo_usupedmon_Emptyitemtext = cgiGet( sPrefix+"COMBO_USUPEDMON_Emptyitemtext");
               Combo_usupedmon_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_USUPEDMON_Onlyselectedvalues");
               Combo_usupedmon_Selectalltext = cgiGet( sPrefix+"COMBO_USUPEDMON_Selectalltext");
               Combo_usupedmon_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_USUPEDMON_Multiplevaluesseparator");
               Combo_usupedmon_Addnewoptiontext = cgiGet( sPrefix+"COMBO_USUPEDMON_Addnewoptiontext");
               Combo_usupedmon_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUPEDMON_Gxcontroltype"), ".", ","));
               Dvpanel_panelopcionespedidos_Objectcall = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Objectcall");
               Dvpanel_panelopcionespedidos_Class = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Class");
               Dvpanel_panelopcionespedidos_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Enabled"));
               Dvpanel_panelopcionespedidos_Width = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Width");
               Dvpanel_panelopcionespedidos_Height = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Height");
               Dvpanel_panelopcionespedidos_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Autowidth"));
               Dvpanel_panelopcionespedidos_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Autoheight"));
               Dvpanel_panelopcionespedidos_Cls = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Cls");
               Dvpanel_panelopcionespedidos_Showheader = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Showheader"));
               Dvpanel_panelopcionespedidos_Title = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Title");
               Dvpanel_panelopcionespedidos_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Collapsible"));
               Dvpanel_panelopcionespedidos_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Collapsed"));
               Dvpanel_panelopcionespedidos_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Showcollapseicon"));
               Dvpanel_panelopcionespedidos_Iconposition = cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Iconposition");
               Dvpanel_panelopcionespedidos_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Autoscroll"));
               Dvpanel_panelopcionespedidos_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Visible"));
               Dvpanel_panelopcionespedidos_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Gxcontroltype"), ".", ","));
               Combo_usumosbancod_Objectcall = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Objectcall");
               Combo_usumosbancod_Class = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Class");
               Combo_usumosbancod_Icontype = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Icontype");
               Combo_usumosbancod_Icon = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Icon");
               Combo_usumosbancod_Caption = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Caption");
               Combo_usumosbancod_Tooltip = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Tooltip");
               Combo_usumosbancod_Cls = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Cls");
               Combo_usumosbancod_Selectedvalue_set = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Selectedvalue_set");
               Combo_usumosbancod_Selectedvalue_get = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Selectedvalue_get");
               Combo_usumosbancod_Selectedtext_set = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Selectedtext_set");
               Combo_usumosbancod_Selectedtext_get = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Selectedtext_get");
               Combo_usumosbancod_Gamoauthtoken = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Gamoauthtoken");
               Combo_usumosbancod_Ddointernalname = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Ddointernalname");
               Combo_usumosbancod_Titlecontrolalign = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Titlecontrolalign");
               Combo_usumosbancod_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Dropdownoptionstype");
               Combo_usumosbancod_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Enabled"));
               Combo_usumosbancod_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Visible"));
               Combo_usumosbancod_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Titlecontrolidtoreplace");
               Combo_usumosbancod_Datalisttype = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Datalisttype");
               Combo_usumosbancod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Allowmultipleselection"));
               Combo_usumosbancod_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Datalistfixedvalues");
               Combo_usumosbancod_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Isgriditem"));
               Combo_usumosbancod_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Hasdescription"));
               Combo_usumosbancod_Datalistproc = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Datalistproc");
               Combo_usumosbancod_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Datalistprocparametersprefix");
               Combo_usumosbancod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_usumosbancod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Includeonlyselectedoption"));
               Combo_usumosbancod_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Includeselectalloption"));
               Combo_usumosbancod_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Emptyitem"));
               Combo_usumosbancod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Includeaddnewoption"));
               Combo_usumosbancod_Htmltemplate = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Htmltemplate");
               Combo_usumosbancod_Multiplevaluestype = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Multiplevaluestype");
               Combo_usumosbancod_Loadingdata = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Loadingdata");
               Combo_usumosbancod_Noresultsfound = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Noresultsfound");
               Combo_usumosbancod_Emptyitemtext = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Emptyitemtext");
               Combo_usumosbancod_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Onlyselectedvalues");
               Combo_usumosbancod_Selectalltext = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Selectalltext");
               Combo_usumosbancod_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Multiplevaluesseparator");
               Combo_usumosbancod_Addnewoptiontext = cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Addnewoptiontext");
               Combo_usumosbancod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUMOSBANCOD_Gxcontroltype"), ".", ","));
               Combo_usumoscbcod_Objectcall = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Objectcall");
               Combo_usumoscbcod_Class = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Class");
               Combo_usumoscbcod_Icontype = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Icontype");
               Combo_usumoscbcod_Icon = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Icon");
               Combo_usumoscbcod_Caption = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Caption");
               Combo_usumoscbcod_Tooltip = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Tooltip");
               Combo_usumoscbcod_Cls = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Cls");
               Combo_usumoscbcod_Selectedvalue_set = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Selectedvalue_set");
               Combo_usumoscbcod_Selectedvalue_get = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Selectedvalue_get");
               Combo_usumoscbcod_Selectedtext_set = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Selectedtext_set");
               Combo_usumoscbcod_Selectedtext_get = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Selectedtext_get");
               Combo_usumoscbcod_Gamoauthtoken = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Gamoauthtoken");
               Combo_usumoscbcod_Ddointernalname = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Ddointernalname");
               Combo_usumoscbcod_Titlecontrolalign = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Titlecontrolalign");
               Combo_usumoscbcod_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Dropdownoptionstype");
               Combo_usumoscbcod_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Enabled"));
               Combo_usumoscbcod_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Visible"));
               Combo_usumoscbcod_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Titlecontrolidtoreplace");
               Combo_usumoscbcod_Datalisttype = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Datalisttype");
               Combo_usumoscbcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Allowmultipleselection"));
               Combo_usumoscbcod_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Datalistfixedvalues");
               Combo_usumoscbcod_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Isgriditem"));
               Combo_usumoscbcod_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Hasdescription"));
               Combo_usumoscbcod_Datalistproc = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Datalistproc");
               Combo_usumoscbcod_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Datalistprocparametersprefix");
               Combo_usumoscbcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_usumoscbcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Includeonlyselectedoption"));
               Combo_usumoscbcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Includeselectalloption"));
               Combo_usumoscbcod_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Emptyitem"));
               Combo_usumoscbcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Includeaddnewoption"));
               Combo_usumoscbcod_Htmltemplate = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Htmltemplate");
               Combo_usumoscbcod_Multiplevaluestype = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Multiplevaluestype");
               Combo_usumoscbcod_Loadingdata = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Loadingdata");
               Combo_usumoscbcod_Noresultsfound = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Noresultsfound");
               Combo_usumoscbcod_Emptyitemtext = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Emptyitemtext");
               Combo_usumoscbcod_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Onlyselectedvalues");
               Combo_usumoscbcod_Selectalltext = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Selectalltext");
               Combo_usumoscbcod_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Multiplevaluesseparator");
               Combo_usumoscbcod_Addnewoptiontext = cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Addnewoptiontext");
               Combo_usumoscbcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUMOSCBCOD_Gxcontroltype"), ".", ","));
               Combo_usumosconcepto_Objectcall = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Objectcall");
               Combo_usumosconcepto_Class = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Class");
               Combo_usumosconcepto_Icontype = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Icontype");
               Combo_usumosconcepto_Icon = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Icon");
               Combo_usumosconcepto_Caption = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Caption");
               Combo_usumosconcepto_Tooltip = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Tooltip");
               Combo_usumosconcepto_Cls = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Cls");
               Combo_usumosconcepto_Selectedvalue_set = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Selectedvalue_set");
               Combo_usumosconcepto_Selectedvalue_get = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Selectedvalue_get");
               Combo_usumosconcepto_Selectedtext_set = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Selectedtext_set");
               Combo_usumosconcepto_Selectedtext_get = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Selectedtext_get");
               Combo_usumosconcepto_Gamoauthtoken = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Gamoauthtoken");
               Combo_usumosconcepto_Ddointernalname = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Ddointernalname");
               Combo_usumosconcepto_Titlecontrolalign = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Titlecontrolalign");
               Combo_usumosconcepto_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Dropdownoptionstype");
               Combo_usumosconcepto_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Enabled"));
               Combo_usumosconcepto_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Visible"));
               Combo_usumosconcepto_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Titlecontrolidtoreplace");
               Combo_usumosconcepto_Datalisttype = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Datalisttype");
               Combo_usumosconcepto_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Allowmultipleselection"));
               Combo_usumosconcepto_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Datalistfixedvalues");
               Combo_usumosconcepto_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Isgriditem"));
               Combo_usumosconcepto_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Hasdescription"));
               Combo_usumosconcepto_Datalistproc = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Datalistproc");
               Combo_usumosconcepto_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Datalistprocparametersprefix");
               Combo_usumosconcepto_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Datalistupdateminimumcharacters"), ".", ","));
               Combo_usumosconcepto_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Includeonlyselectedoption"));
               Combo_usumosconcepto_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Includeselectalloption"));
               Combo_usumosconcepto_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Emptyitem"));
               Combo_usumosconcepto_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Includeaddnewoption"));
               Combo_usumosconcepto_Htmltemplate = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Htmltemplate");
               Combo_usumosconcepto_Multiplevaluestype = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Multiplevaluestype");
               Combo_usumosconcepto_Loadingdata = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Loadingdata");
               Combo_usumosconcepto_Noresultsfound = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Noresultsfound");
               Combo_usumosconcepto_Emptyitemtext = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Emptyitemtext");
               Combo_usumosconcepto_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Onlyselectedvalues");
               Combo_usumosconcepto_Selectalltext = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Selectalltext");
               Combo_usumosconcepto_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Multiplevaluesseparator");
               Combo_usumosconcepto_Addnewoptiontext = cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Addnewoptiontext");
               Combo_usumosconcepto_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_USUMOSCONCEPTO_Gxcontroltype"), ".", ","));
               Dvpanel_panelfiltromostrador_Objectcall = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Objectcall");
               Dvpanel_panelfiltromostrador_Class = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Class");
               Dvpanel_panelfiltromostrador_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Enabled"));
               Dvpanel_panelfiltromostrador_Width = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Width");
               Dvpanel_panelfiltromostrador_Height = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Height");
               Dvpanel_panelfiltromostrador_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Autowidth"));
               Dvpanel_panelfiltromostrador_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Autoheight"));
               Dvpanel_panelfiltromostrador_Cls = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Cls");
               Dvpanel_panelfiltromostrador_Showheader = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Showheader"));
               Dvpanel_panelfiltromostrador_Title = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Title");
               Dvpanel_panelfiltromostrador_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Collapsible"));
               Dvpanel_panelfiltromostrador_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Collapsed"));
               Dvpanel_panelfiltromostrador_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Showcollapseicon"));
               Dvpanel_panelfiltromostrador_Iconposition = cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Iconposition");
               Dvpanel_panelfiltromostrador_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Autoscroll"));
               Dvpanel_panelfiltromostrador_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Visible"));
               Dvpanel_panelfiltromostrador_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedPrecio_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedPrecio_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDPRECIO");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedPrecio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2027UsuPedPrecio = 0;
                  AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
               }
               else
               {
                  A2027UsuPedPrecio = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedPrecio_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedDscto_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedDscto_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDDSCTO");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedDscto_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2023UsuPedDscto = 0;
                  AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
               }
               else
               {
                  A2023UsuPedDscto = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedDscto_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedStock_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedStock_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDSTOCK");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedStock_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2028UsuPedStock = 0;
                  AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
               }
               else
               {
                  A2028UsuPedStock = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedStock_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedVend_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedVend_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDVEND");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedVend_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2029UsuPedVend = 0;
                  AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
               }
               else
               {
                  A2029UsuPedVend = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedVend_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedCond_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedCond_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDCOND");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedCond_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2022UsuPedCond = 0;
                  AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
               }
               else
               {
                  A2022UsuPedCond = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedCond_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedList_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedList_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDLIST");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedList_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2024UsuPedList = 0;
                  AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
               }
               else
               {
                  A2024UsuPedList = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedList_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuPedMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuPedMon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDMON");
                  AnyError = 1;
                  GX_FocusControl = edtUsuPedMon_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2026UsuPedMon = 0;
                  n2026UsuPedMon = false;
                  AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
               }
               else
               {
                  A2026UsuPedMon = (int)(context.localUtil.CToN( cgiGet( edtUsuPedMon_Internalname), ".", ","));
                  n2026UsuPedMon = false;
                  AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
               }
               n2026UsuPedMon = ((0==A2026UsuPedMon) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuMosBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuMosBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUMOSBANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuMosBanCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2016UsuMosBanCod = 0;
                  n2016UsuMosBanCod = false;
                  AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
               }
               else
               {
                  A2016UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( edtUsuMosBanCod_Internalname), ".", ","));
                  n2016UsuMosBanCod = false;
                  AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
               }
               n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
               A2017UsuMosCBCod = cgiGet( edtUsuMosCBCod_Internalname);
               n2017UsuMosCBCod = false;
               AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
               n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuMosConcepto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuMosConcepto_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUMOSCONCEPTO");
                  AnyError = 1;
                  GX_FocusControl = edtUsuMosConcepto_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A350UsuMosConcepto = 0;
                  n350UsuMosConcepto = false;
                  AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
               }
               else
               {
                  A350UsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( edtUsuMosConcepto_Internalname), ".", ","));
                  n350UsuMosConcepto = false;
                  AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
               }
               n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
               AV30ComboUsuPedMon = (int)(context.localUtil.CToN( cgiGet( edtavCombousupedmon_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "AV30ComboUsuPedMon", StringUtil.LTrimStr( (decimal)(AV30ComboUsuPedMon), 6, 0));
               AV23ComboUsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( edtavCombousumosbancod_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "AV23ComboUsuMosBanCod", StringUtil.LTrimStr( (decimal)(AV23ComboUsuMosBanCod), 6, 0));
               AV26ComboUsuMosCBCod = cgiGet( edtavCombousumoscbcod_Internalname);
               AssignAttri(sPrefix, false, "AV26ComboUsuMosCBCod", AV26ComboUsuMosCBCod);
               AV18ComboUsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( edtavCombousumosconcepto_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "AV18ComboUsuMosConcepto", StringUtil.LTrimStr( (decimal)(AV18ComboUsuMosConcepto), 6, 0));
               A348UsuCod = cgiGet( edtUsuCod_Internalname);
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuariosOpciones");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("UsuNom", StringUtil.RTrim( context.localUtil.Format( A2019UsuNom, "")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\usuariosopciones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A348UsuCod = GetPar( "UsuCod");
                  AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode32 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode32;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound32 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USUCOD");
                        AnyError = 1;
                        GX_FocusControl = edtUsuCod_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
            if ( context.wbHandled == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  sEvt = cgiGet( "_EventName");
                  EvtGridId = cgiGet( "_EventGridId");
                  EvtRowId = cgiGet( "_EventRowId");
               }
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E115H2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E125H2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
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
            E125H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5H32( ) ;
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
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes5H32( ) ;
         }
         AssignProp(sPrefix, false, chkUsuPedPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedPrecio.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkUsuPedDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedDscto.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkUsuPedStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedStock.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkUsuPedVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedVend.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkUsuPedCond_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedCond.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkUsuPedList_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedList.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuPedMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuPedMon_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtavCombousupedmon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousupedmon_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtavCombousumosbancod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousumosbancod_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtavCombousumoscbcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousumoscbcod_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtavCombousumosconcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousumosconcepto_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
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

      protected void CONFIRM_5H0( )
      {
         BeforeValidate5H32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5H32( ) ;
            }
            else
            {
               CheckExtendedTable5H32( ) ;
               CloseExtendedTableCursors5H32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5H0( )
      {
      }

      protected void E115H2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtUsuMosConcepto_Visible = 0;
         AssignProp(sPrefix, false, edtUsuMosConcepto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuMosConcepto_Visible), 5, 0), true);
         AV18ComboUsuMosConcepto = 0;
         AssignAttri(sPrefix, false, "AV18ComboUsuMosConcepto", StringUtil.LTrimStr( (decimal)(AV18ComboUsuMosConcepto), 6, 0));
         edtavCombousumosconcepto_Visible = 0;
         AssignProp(sPrefix, false, edtavCombousumosconcepto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombousumosconcepto_Visible), 5, 0), true);
         edtUsuMosCBCod_Visible = 0;
         AssignProp(sPrefix, false, edtUsuMosCBCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuMosCBCod_Visible), 5, 0), true);
         AV26ComboUsuMosCBCod = "";
         AssignAttri(sPrefix, false, "AV26ComboUsuMosCBCod", AV26ComboUsuMosCBCod);
         edtavCombousumoscbcod_Visible = 0;
         AssignProp(sPrefix, false, edtavCombousumoscbcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombousumoscbcod_Visible), 5, 0), true);
         edtUsuMosBanCod_Visible = 0;
         AssignProp(sPrefix, false, edtUsuMosBanCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuMosBanCod_Visible), 5, 0), true);
         AV23ComboUsuMosBanCod = 0;
         AssignAttri(sPrefix, false, "AV23ComboUsuMosBanCod", StringUtil.LTrimStr( (decimal)(AV23ComboUsuMosBanCod), 6, 0));
         edtavCombousumosbancod_Visible = 0;
         AssignProp(sPrefix, false, edtavCombousumosbancod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombousumosbancod_Visible), 5, 0), true);
         edtUsuPedMon_Visible = 0;
         AssignProp(sPrefix, false, edtUsuPedMon_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuPedMon_Visible), 5, 0), true);
         AV30ComboUsuPedMon = 0;
         AssignAttri(sPrefix, false, "AV30ComboUsuPedMon", StringUtil.LTrimStr( (decimal)(AV30ComboUsuPedMon), 6, 0));
         edtavCombousupedmon_Visible = 0;
         AssignProp(sPrefix, false, edtavCombousupedmon_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombousupedmon_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOUSUPEDMON' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOUSUMOSBANCOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOUSUMOSCBCOD' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOUSUMOSCONCEPTO' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri(sPrefix, false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "UsuMosBanCod") == 0 )
               {
                  AV20Insert_UsuMosBanCod = (int)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV20Insert_UsuMosBanCod", StringUtil.LTrimStr( (decimal)(AV20Insert_UsuMosBanCod), 6, 0));
                  if ( ! (0==AV20Insert_UsuMosBanCod) )
                  {
                     AV23ComboUsuMosBanCod = AV20Insert_UsuMosBanCod;
                     AssignAttri(sPrefix, false, "AV23ComboUsuMosBanCod", StringUtil.LTrimStr( (decimal)(AV23ComboUsuMosBanCod), 6, 0));
                     Combo_usumosbancod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV23ComboUsuMosBanCod), 6, 0));
                     ucCombo_usumosbancod.SendProperty(context, sPrefix, false, Combo_usumosbancod_Internalname, "SelectedValue_set", Combo_usumosbancod_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuMosBanCod",  "GET",  false,  AV7UsuCod,  A2016UsuMosBanCod,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_usumosbancod_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_usumosbancod.SendProperty(context, sPrefix, false, Combo_usumosbancod_Internalname, "SelectedText_set", Combo_usumosbancod_Selectedtext_set);
                     Combo_usumosbancod_Enabled = false;
                     ucCombo_usumosbancod.SendProperty(context, sPrefix, false, Combo_usumosbancod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usumosbancod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "UsuMosCBCod") == 0 )
               {
                  AV21Insert_UsuMosCBCod = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri(sPrefix, false, "AV21Insert_UsuMosCBCod", AV21Insert_UsuMosCBCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21Insert_UsuMosCBCod)) )
                  {
                     AV26ComboUsuMosCBCod = AV21Insert_UsuMosCBCod;
                     AssignAttri(sPrefix, false, "AV26ComboUsuMosCBCod", AV26ComboUsuMosCBCod);
                     Combo_usumoscbcod_Selectedvalue_set = AV26ComboUsuMosCBCod;
                     ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "SelectedValue_set", Combo_usumoscbcod_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuMosCBCod",  "GET",  false,  AV7UsuCod,  A2016UsuMosBanCod,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_usumoscbcod_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "SelectedText_set", Combo_usumoscbcod_Selectedtext_set);
                     Combo_usumoscbcod_Enabled = false;
                     ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usumoscbcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "UsuMosConcepto") == 0 )
               {
                  AV11Insert_UsuMosConcepto = (int)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV11Insert_UsuMosConcepto", StringUtil.LTrimStr( (decimal)(AV11Insert_UsuMosConcepto), 6, 0));
                  if ( ! (0==AV11Insert_UsuMosConcepto) )
                  {
                     AV18ComboUsuMosConcepto = AV11Insert_UsuMosConcepto;
                     AssignAttri(sPrefix, false, "AV18ComboUsuMosConcepto", StringUtil.LTrimStr( (decimal)(AV18ComboUsuMosConcepto), 6, 0));
                     Combo_usumosconcepto_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboUsuMosConcepto), 6, 0));
                     ucCombo_usumosconcepto.SendProperty(context, sPrefix, false, Combo_usumosconcepto_Internalname, "SelectedValue_set", Combo_usumosconcepto_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuMosConcepto",  "GET",  false,  AV7UsuCod,  A2016UsuMosBanCod,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_usumosconcepto_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_usumosconcepto.SendProperty(context, sPrefix, false, Combo_usumosconcepto_Internalname, "SelectedText_set", Combo_usumosconcepto_Selectedtext_set);
                     Combo_usumosconcepto_Enabled = false;
                     ucCombo_usumosconcepto.SendProperty(context, sPrefix, false, Combo_usumosconcepto_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usumosconcepto_Enabled));
                  }
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri(sPrefix, false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
         edtUsuCod_Visible = 0;
         AssignProp(sPrefix, false, edtUsuCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuCod_Visible), 5, 0), true);
      }

      protected void E125H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S142( )
      {
         /* 'LOADCOMBOUSUMOSCONCEPTO' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuMosConcepto",  Gx_mode,  false,  AV7UsuCod,  A2016UsuMosBanCod,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_usumosconcepto_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_usumosconcepto.SendProperty(context, sPrefix, false, Combo_usumosconcepto_Internalname, "SelectedValue_set", Combo_usumosconcepto_Selectedvalue_set);
         Combo_usumosconcepto_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_usumosconcepto.SendProperty(context, sPrefix, false, Combo_usumosconcepto_Internalname, "SelectedText_set", Combo_usumosconcepto_Selectedtext_set);
         AV18ComboUsuMosConcepto = (int)(NumberUtil.Val( AV15ComboSelectedValue, "."));
         AssignAttri(sPrefix, false, "AV18ComboUsuMosConcepto", StringUtil.LTrimStr( (decimal)(AV18ComboUsuMosConcepto), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_usumosconcepto_Enabled = false;
            ucCombo_usumosconcepto.SendProperty(context, sPrefix, false, Combo_usumosconcepto_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usumosconcepto_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOUSUMOSCBCOD' Routine */
         returnInSub = false;
         Combo_usumoscbcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"UsuMosCBCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\", \"Cond_UsuMosBanCod\": \"#%1#\"", edtUsuMosBanCod_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "DataListProcParametersPrefix", Combo_usumoscbcod_Datalistprocparametersprefix);
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuMosCBCod",  Gx_mode,  false,  AV7UsuCod,  A2016UsuMosBanCod,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_usumoscbcod_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "SelectedValue_set", Combo_usumoscbcod_Selectedvalue_set);
         Combo_usumoscbcod_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "SelectedText_set", Combo_usumoscbcod_Selectedtext_set);
         AV26ComboUsuMosCBCod = AV15ComboSelectedValue;
         AssignAttri(sPrefix, false, "AV26ComboUsuMosCBCod", AV26ComboUsuMosCBCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_usumoscbcod_Enabled = false;
            ucCombo_usumoscbcod.SendProperty(context, sPrefix, false, Combo_usumoscbcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usumoscbcod_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOUSUMOSBANCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuMosBanCod",  Gx_mode,  false,  AV7UsuCod,  A2016UsuMosBanCod,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_usumosbancod_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_usumosbancod.SendProperty(context, sPrefix, false, Combo_usumosbancod_Internalname, "SelectedValue_set", Combo_usumosbancod_Selectedvalue_set);
         Combo_usumosbancod_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_usumosbancod.SendProperty(context, sPrefix, false, Combo_usumosbancod_Internalname, "SelectedText_set", Combo_usumosbancod_Selectedtext_set);
         AV23ComboUsuMosBanCod = (int)(NumberUtil.Val( AV15ComboSelectedValue, "."));
         AssignAttri(sPrefix, false, "AV23ComboUsuMosBanCod", StringUtil.LTrimStr( (decimal)(AV23ComboUsuMosBanCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_usumosbancod_Enabled = false;
            ucCombo_usumosbancod.SendProperty(context, sPrefix, false, Combo_usumosbancod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usumosbancod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOUSUPEDMON' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo(context ).execute(  "UsuPedMon",  Gx_mode,  false,  AV7UsuCod,  A2016UsuMosBanCod,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri(sPrefix, false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri(sPrefix, false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri(sPrefix, false, "AV17Combo_DataJson", AV17Combo_DataJson);
         AV29UsuPedMon_Data.FromJSonString(AV17Combo_DataJson, null);
         Combo_usupedmon_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_usupedmon.SendProperty(context, sPrefix, false, Combo_usupedmon_Internalname, "SelectedValue_set", Combo_usupedmon_Selectedvalue_set);
         AV30ComboUsuPedMon = (int)(NumberUtil.Val( AV15ComboSelectedValue, "."));
         AssignAttri(sPrefix, false, "AV30ComboUsuPedMon", StringUtil.LTrimStr( (decimal)(AV30ComboUsuPedMon), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_usupedmon_Enabled = false;
            ucCombo_usupedmon.SendProperty(context, sPrefix, false, Combo_usupedmon_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usupedmon_Enabled));
         }
      }

      protected void ZM5H32( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2026UsuPedMon = T005H3_A2026UsuPedMon[0];
               Z2019UsuNom = T005H3_A2019UsuNom[0];
               Z2027UsuPedPrecio = T005H3_A2027UsuPedPrecio[0];
               Z2023UsuPedDscto = T005H3_A2023UsuPedDscto[0];
               Z2028UsuPedStock = T005H3_A2028UsuPedStock[0];
               Z2029UsuPedVend = T005H3_A2029UsuPedVend[0];
               Z2022UsuPedCond = T005H3_A2022UsuPedCond[0];
               Z2024UsuPedList = T005H3_A2024UsuPedList[0];
               Z2016UsuMosBanCod = T005H3_A2016UsuMosBanCod[0];
               Z2017UsuMosCBCod = T005H3_A2017UsuMosCBCod[0];
               Z350UsuMosConcepto = T005H3_A350UsuMosConcepto[0];
            }
            else
            {
               Z2026UsuPedMon = A2026UsuPedMon;
               Z2019UsuNom = A2019UsuNom;
               Z2027UsuPedPrecio = A2027UsuPedPrecio;
               Z2023UsuPedDscto = A2023UsuPedDscto;
               Z2028UsuPedStock = A2028UsuPedStock;
               Z2029UsuPedVend = A2029UsuPedVend;
               Z2022UsuPedCond = A2022UsuPedCond;
               Z2024UsuPedList = A2024UsuPedList;
               Z2016UsuMosBanCod = A2016UsuMosBanCod;
               Z2017UsuMosCBCod = A2017UsuMosCBCod;
               Z350UsuMosConcepto = A350UsuMosConcepto;
            }
         }
         if ( GX_JID == -18 )
         {
            Z348UsuCod = A348UsuCod;
            Z2026UsuPedMon = A2026UsuPedMon;
            Z2019UsuNom = A2019UsuNom;
            Z2027UsuPedPrecio = A2027UsuPedPrecio;
            Z2023UsuPedDscto = A2023UsuPedDscto;
            Z2028UsuPedStock = A2028UsuPedStock;
            Z2029UsuPedVend = A2029UsuPedVend;
            Z2022UsuPedCond = A2022UsuPedCond;
            Z2024UsuPedList = A2024UsuPedList;
            Z2016UsuMosBanCod = A2016UsuMosBanCod;
            Z2017UsuMosCBCod = A2017UsuMosCBCod;
            Z350UsuMosConcepto = A350UsuMosConcepto;
            Z2018UsuMosConceptoDsc = A2018UsuMosConceptoDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Seguridad.UsuariosOpciones";
         AssignAttri(sPrefix, false, "AV31Pgmname", AV31Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
         {
            A348UsuCod = AV7UsuCod;
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
         {
            edtUsuCod_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuCod_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
         {
            divTablamensaje_Visible = 0;
            AssignProp(sPrefix, false, divTablamensaje_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablamensaje_Visible), 5, 0), true);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
         {
            divTablacontenido_Visible = 0;
            AssignProp(sPrefix, false, divTablacontenido_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablacontenido_Visible), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
         {
            edtUsuCod_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_UsuMosBanCod) )
         {
            edtUsuMosBanCod_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuMosBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosBanCod_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuMosBanCod_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuMosBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosBanCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21Insert_UsuMosCBCod)) )
         {
            edtUsuMosCBCod_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuMosCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosCBCod_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuMosCBCod_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuMosCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosCBCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_UsuMosConcepto) )
         {
            edtUsuMosConcepto_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuMosConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosConcepto_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuMosConcepto_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuMosConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosConcepto_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A2026UsuPedMon = AV30ComboUsuPedMon;
         n2026UsuPedMon = false;
         AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_UsuMosBanCod) )
         {
            A2016UsuMosBanCod = AV20Insert_UsuMosBanCod;
            n2016UsuMosBanCod = false;
            AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
         }
         else
         {
            if ( (0==AV23ComboUsuMosBanCod) )
            {
               A2016UsuMosBanCod = 0;
               n2016UsuMosBanCod = false;
               AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
               n2016UsuMosBanCod = true;
               AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV23ComboUsuMosBanCod) )
               {
                  A2016UsuMosBanCod = AV23ComboUsuMosBanCod;
                  n2016UsuMosBanCod = false;
                  AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21Insert_UsuMosCBCod)) )
         {
            A2017UsuMosCBCod = AV21Insert_UsuMosCBCod;
            n2017UsuMosCBCod = false;
            AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ComboUsuMosCBCod)) )
            {
               A2017UsuMosCBCod = "";
               n2017UsuMosCBCod = false;
               AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
               n2017UsuMosCBCod = true;
               AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ComboUsuMosCBCod)) )
               {
                  A2017UsuMosCBCod = AV26ComboUsuMosCBCod;
                  n2017UsuMosCBCod = false;
                  AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_UsuMosConcepto) )
         {
            A350UsuMosConcepto = AV11Insert_UsuMosConcepto;
            n350UsuMosConcepto = false;
            AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
         }
         else
         {
            if ( (0==AV18ComboUsuMosConcepto) )
            {
               A350UsuMosConcepto = 0;
               n350UsuMosConcepto = false;
               AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
               n350UsuMosConcepto = true;
               AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            }
            else
            {
               if ( ! (0==AV18ComboUsuMosConcepto) )
               {
                  A350UsuMosConcepto = AV18ComboUsuMosConcepto;
                  n350UsuMosConcepto = false;
                  AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
               }
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T005H6 */
            pr_default.execute(4, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
            A2018UsuMosConceptoDsc = T005H6_A2018UsuMosConceptoDsc[0];
            pr_default.close(4);
         }
      }

      protected void Load5H32( )
      {
         /* Using cursor T005H7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
            A2026UsuPedMon = T005H7_A2026UsuPedMon[0];
            n2026UsuPedMon = T005H7_n2026UsuPedMon[0];
            AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
            A2019UsuNom = T005H7_A2019UsuNom[0];
            A2027UsuPedPrecio = T005H7_A2027UsuPedPrecio[0];
            AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
            A2023UsuPedDscto = T005H7_A2023UsuPedDscto[0];
            AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
            A2028UsuPedStock = T005H7_A2028UsuPedStock[0];
            AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
            A2029UsuPedVend = T005H7_A2029UsuPedVend[0];
            AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
            A2022UsuPedCond = T005H7_A2022UsuPedCond[0];
            AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
            A2024UsuPedList = T005H7_A2024UsuPedList[0];
            AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
            A2018UsuMosConceptoDsc = T005H7_A2018UsuMosConceptoDsc[0];
            A2016UsuMosBanCod = T005H7_A2016UsuMosBanCod[0];
            n2016UsuMosBanCod = T005H7_n2016UsuMosBanCod[0];
            AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            A2017UsuMosCBCod = T005H7_A2017UsuMosCBCod[0];
            n2017UsuMosCBCod = T005H7_n2017UsuMosCBCod[0];
            AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            A350UsuMosConcepto = T005H7_A350UsuMosConcepto[0];
            n350UsuMosConcepto = T005H7_n350UsuMosConcepto[0];
            AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            ZM5H32( -18) ;
         }
         pr_default.close(5);
         OnLoadActions5H32( ) ;
      }

      protected void OnLoadActions5H32( )
      {
      }

      protected void CheckExtendedTable5H32( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T005H4 */
         pr_default.execute(2, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T005H5 */
         pr_default.execute(3, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Banco'.", "ForeignKeyNotFound", 1, "USUMOSCBCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T005H6 */
         pr_default.execute(4, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A350UsuMosConcepto) ) )
            {
               GX_msglist.addItem("No existe 'Sub Banco Mostrador'.", "ForeignKeyNotFound", 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2018UsuMosConceptoDsc = T005H6_A2018UsuMosConceptoDsc[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors5H32( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( int A2016UsuMosBanCod )
      {
         /* Using cursor T005H8 */
         pr_default.execute(6, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_20( int A2016UsuMosBanCod ,
                                string A2017UsuMosCBCod )
      {
         /* Using cursor T005H9 */
         pr_default.execute(7, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Banco'.", "ForeignKeyNotFound", 1, "USUMOSCBCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_21( int A350UsuMosConcepto )
      {
         /* Using cursor T005H10 */
         pr_default.execute(8, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A350UsuMosConcepto) ) )
            {
               GX_msglist.addItem("No existe 'Sub Banco Mostrador'.", "ForeignKeyNotFound", 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2018UsuMosConceptoDsc = T005H10_A2018UsuMosConceptoDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2018UsuMosConceptoDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey5H32( )
      {
         /* Using cursor T005H11 */
         pr_default.execute(9, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005H3 */
         pr_default.execute(1, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5H32( 18) ;
            RcdFound32 = 1;
            A348UsuCod = T005H3_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            A2026UsuPedMon = T005H3_A2026UsuPedMon[0];
            n2026UsuPedMon = T005H3_n2026UsuPedMon[0];
            AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
            A2019UsuNom = T005H3_A2019UsuNom[0];
            A2027UsuPedPrecio = T005H3_A2027UsuPedPrecio[0];
            AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
            A2023UsuPedDscto = T005H3_A2023UsuPedDscto[0];
            AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
            A2028UsuPedStock = T005H3_A2028UsuPedStock[0];
            AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
            A2029UsuPedVend = T005H3_A2029UsuPedVend[0];
            AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
            A2022UsuPedCond = T005H3_A2022UsuPedCond[0];
            AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
            A2024UsuPedList = T005H3_A2024UsuPedList[0];
            AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
            A2016UsuMosBanCod = T005H3_A2016UsuMosBanCod[0];
            n2016UsuMosBanCod = T005H3_n2016UsuMosBanCod[0];
            AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            A2017UsuMosCBCod = T005H3_A2017UsuMosCBCod[0];
            n2017UsuMosCBCod = T005H3_n2017UsuMosCBCod[0];
            AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            A350UsuMosConcepto = T005H3_A350UsuMosConcepto[0];
            n350UsuMosConcepto = T005H3_n350UsuMosConcepto[0];
            AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            Z348UsuCod = A348UsuCod;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load5H32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey5H32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey5H32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5H32( ) ;
         if ( RcdFound32 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound32 = 0;
         /* Using cursor T005H12 */
         pr_default.execute(10, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T005H12_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T005H12_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               A348UsuCod = T005H12_A348UsuCod[0];
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T005H13 */
         pr_default.execute(11, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T005H13_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T005H13_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               A348UsuCod = T005H13_A348UsuCod[0];
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5H32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = chkUsuPedPrecio_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert5H32( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = chkUsuPedPrecio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5H32( ) ;
                  GX_FocusControl = chkUsuPedPrecio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = chkUsuPedPrecio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert5H32( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = chkUsuPedPrecio_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert5H32( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = chkUsuPedPrecio_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5H32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005H2 */
            pr_default.execute(0, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z2026UsuPedMon != T005H2_A2026UsuPedMon[0] ) || ( StringUtil.StrCmp(Z2019UsuNom, T005H2_A2019UsuNom[0]) != 0 ) || ( Z2027UsuPedPrecio != T005H2_A2027UsuPedPrecio[0] ) || ( Z2023UsuPedDscto != T005H2_A2023UsuPedDscto[0] ) || ( Z2028UsuPedStock != T005H2_A2028UsuPedStock[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2029UsuPedVend != T005H2_A2029UsuPedVend[0] ) || ( Z2022UsuPedCond != T005H2_A2022UsuPedCond[0] ) || ( Z2024UsuPedList != T005H2_A2024UsuPedList[0] ) || ( Z2016UsuMosBanCod != T005H2_A2016UsuMosBanCod[0] ) || ( StringUtil.StrCmp(Z2017UsuMosCBCod, T005H2_A2017UsuMosCBCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z350UsuMosConcepto != T005H2_A350UsuMosConcepto[0] ) )
            {
               if ( Z2026UsuPedMon != T005H2_A2026UsuPedMon[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedMon");
                  GXUtil.WriteLogRaw("Old: ",Z2026UsuPedMon);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2026UsuPedMon[0]);
               }
               if ( StringUtil.StrCmp(Z2019UsuNom, T005H2_A2019UsuNom[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuNom");
                  GXUtil.WriteLogRaw("Old: ",Z2019UsuNom);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2019UsuNom[0]);
               }
               if ( Z2027UsuPedPrecio != T005H2_A2027UsuPedPrecio[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z2027UsuPedPrecio);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2027UsuPedPrecio[0]);
               }
               if ( Z2023UsuPedDscto != T005H2_A2023UsuPedDscto[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedDscto");
                  GXUtil.WriteLogRaw("Old: ",Z2023UsuPedDscto);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2023UsuPedDscto[0]);
               }
               if ( Z2028UsuPedStock != T005H2_A2028UsuPedStock[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedStock");
                  GXUtil.WriteLogRaw("Old: ",Z2028UsuPedStock);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2028UsuPedStock[0]);
               }
               if ( Z2029UsuPedVend != T005H2_A2029UsuPedVend[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedVend");
                  GXUtil.WriteLogRaw("Old: ",Z2029UsuPedVend);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2029UsuPedVend[0]);
               }
               if ( Z2022UsuPedCond != T005H2_A2022UsuPedCond[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedCond");
                  GXUtil.WriteLogRaw("Old: ",Z2022UsuPedCond);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2022UsuPedCond[0]);
               }
               if ( Z2024UsuPedList != T005H2_A2024UsuPedList[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuPedList");
                  GXUtil.WriteLogRaw("Old: ",Z2024UsuPedList);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2024UsuPedList[0]);
               }
               if ( Z2016UsuMosBanCod != T005H2_A2016UsuMosBanCod[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuMosBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z2016UsuMosBanCod);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2016UsuMosBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z2017UsuMosCBCod, T005H2_A2017UsuMosCBCod[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuMosCBCod");
                  GXUtil.WriteLogRaw("Old: ",Z2017UsuMosCBCod);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A2017UsuMosCBCod[0]);
               }
               if ( Z350UsuMosConcepto != T005H2_A350UsuMosConcepto[0] )
               {
                  GXUtil.WriteLog("seguridad.usuariosopciones:[seudo value changed for attri]"+"UsuMosConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z350UsuMosConcepto);
                  GXUtil.WriteLogRaw("Current: ",T005H2_A350UsuMosConcepto[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5H32( )
      {
         BeforeValidate5H32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5H32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5H32( 0) ;
            CheckOptimisticConcurrency5H32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5H32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5H32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005H14 */
                     pr_default.execute(12, new Object[] {A348UsuCod, n2026UsuPedMon, A2026UsuPedMon, A2019UsuNom, A2027UsuPedPrecio, A2023UsuPedDscto, A2028UsuPedStock, A2029UsuPedVend, A2022UsuPedCond, A2024UsuPedList, n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod, n350UsuMosConcepto, A350UsuMosConcepto});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
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
                           ResetCaption5H0( ) ;
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
               Load5H32( ) ;
            }
            EndLevel5H32( ) ;
         }
         CloseExtendedTableCursors5H32( ) ;
      }

      protected void Update5H32( )
      {
         BeforeValidate5H32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5H32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5H32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5H32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5H32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005H15 */
                     pr_default.execute(13, new Object[] {n2026UsuPedMon, A2026UsuPedMon, A2019UsuNom, A2027UsuPedPrecio, A2023UsuPedDscto, A2028UsuPedStock, A2029UsuPedVend, A2022UsuPedCond, A2024UsuPedList, n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod, n350UsuMosConcepto, A350UsuMosConcepto, A348UsuCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5H32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
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
            EndLevel5H32( ) ;
         }
         CloseExtendedTableCursors5H32( ) ;
      }

      protected void DeferredUpdate5H32( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5H32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5H32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5H32( ) ;
            AfterConfirm5H32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5H32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005H16 */
                  pr_default.execute(14, new Object[] {A348UsuCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel5H32( ) ;
         Gx_mode = sMode32;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5H32( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005H17 */
            pr_default.execute(15, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
            A2018UsuMosConceptoDsc = T005H17_A2018UsuMosConceptoDsc[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005H18 */
            pr_default.execute(16, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T005H19 */
            pr_default.execute(17, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T005H20 */
            pr_default.execute(18, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T005H21 */
            pr_default.execute(19, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T005H22 */
            pr_default.execute(20, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T005H23 */
            pr_default.execute(21, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel5H32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5H32( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            context.CommitDataStores("seguridad.usuariosopciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            context.RollbackDataStores("seguridad.usuariosopciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5H32( )
      {
         /* Scan By routine */
         /* Using cursor T005H24 */
         pr_default.execute(22);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T005H24_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5H32( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T005H24_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         }
      }

      protected void ScanEnd5H32( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm5H32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5H32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5H32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5H32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5H32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5H32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5H32( )
      {
         chkUsuPedPrecio.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuPedPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedPrecio.Enabled), 5, 0), true);
         chkUsuPedDscto.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuPedDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedDscto.Enabled), 5, 0), true);
         chkUsuPedStock.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuPedStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedStock.Enabled), 5, 0), true);
         chkUsuPedVend.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuPedVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedVend.Enabled), 5, 0), true);
         chkUsuPedCond.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuPedCond_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedCond.Enabled), 5, 0), true);
         chkUsuPedList.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuPedList_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedList.Enabled), 5, 0), true);
         edtUsuPedMon_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuPedMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuPedMon_Enabled), 5, 0), true);
         edtUsuMosBanCod_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuMosBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosBanCod_Enabled), 5, 0), true);
         edtUsuMosCBCod_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuMosCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosCBCod_Enabled), 5, 0), true);
         edtUsuMosConcepto_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuMosConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosConcepto_Enabled), 5, 0), true);
         edtavCombousupedmon_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombousupedmon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousupedmon_Enabled), 5, 0), true);
         edtavCombousumosbancod_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombousumosbancod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousumosbancod_Enabled), 5, 0), true);
         edtavCombousumoscbcod_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombousumoscbcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousumoscbcod_Enabled), 5, 0), true);
         edtavCombousumosconcepto_Enabled = 0;
         AssignProp(sPrefix, false, edtavCombousumosconcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousumosconcepto_Enabled), 5, 0), true);
         edtUsuCod_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5H32( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5H0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Usuarios Opciones") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281811384334", false, true);
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "seguridad.usuariosopciones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7UsuCod));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.usuariosopciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuariosOpciones");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("UsuNom", StringUtil.RTrim( context.localUtil.Format( A2019UsuNom, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\usuariosopciones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2026UsuPedMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2026UsuPedMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2019UsuNom", StringUtil.RTrim( Z2019UsuNom));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2027UsuPedPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2027UsuPedPrecio), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2023UsuPedDscto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2023UsuPedDscto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2028UsuPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2028UsuPedStock), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2029UsuPedVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2029UsuPedVend), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2022UsuPedCond", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2022UsuPedCond), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2024UsuPedList", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2024UsuPedList), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2016UsuMosBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2016UsuMosBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2017UsuMosCBCod", StringUtil.RTrim( Z2017UsuMosCBCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z350UsuMosConcepto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350UsuMosConcepto), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7UsuCod", StringUtil.RTrim( wcpOAV7UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N2016UsuMosBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2016UsuMosBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N2017UsuMosCBCod", StringUtil.RTrim( A2017UsuMosCBCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"N350UsuMosConcepto", StringUtil.LTrim( StringUtil.NToC( (decimal)(A350UsuMosConcepto), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUSUPEDMON_DATA", AV29UsuPedMon_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUSUPEDMON_DATA", AV29UsuPedMon_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUSUMOSBANCOD_DATA", AV22UsuMosBanCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUSUMOSBANCOD_DATA", AV22UsuMosBanCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUSUMOSCBCOD_DATA", AV25UsuMosCBCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUSUMOSCBCOD_DATA", AV25UsuMosCBCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUSUMOSCONCEPTO_DATA", AV13UsuMosConcepto_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUSUMOSCONCEPTO_DATA", AV13UsuMosConcepto_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOND_USUMOSBANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28Cond_UsuMosBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUCOD", StringUtil.RTrim( AV7UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_USUMOSBANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_UsuMosBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_USUMOSCBCOD", StringUtil.RTrim( AV21Insert_UsuMosCBCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_USUMOSCONCEPTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_UsuMosConcepto), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUNOM", StringUtil.RTrim( A2019UsuNom));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUMOSCONCEPTODSC", StringUtil.RTrim( A2018UsuMosConceptoDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV31Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUPEDMON_Objectcall", StringUtil.RTrim( Combo_usupedmon_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUPEDMON_Cls", StringUtil.RTrim( Combo_usupedmon_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUPEDMON_Selectedvalue_set", StringUtil.RTrim( Combo_usupedmon_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUPEDMON_Enabled", StringUtil.BoolToStr( Combo_usupedmon_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Objectcall", StringUtil.RTrim( Dvpanel_panelopcionespedidos_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Enabled", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Width", StringUtil.RTrim( Dvpanel_panelopcionespedidos_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Autowidth", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Autoheight", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Cls", StringUtil.RTrim( Dvpanel_panelopcionespedidos_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Title", StringUtil.RTrim( Dvpanel_panelopcionespedidos_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Collapsible", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Collapsed", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Iconposition", StringUtil.RTrim( Dvpanel_panelopcionespedidos_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS_Autoscroll", StringUtil.BoolToStr( Dvpanel_panelopcionespedidos_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Objectcall", StringUtil.RTrim( Combo_usumosbancod_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Cls", StringUtil.RTrim( Combo_usumosbancod_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Selectedvalue_set", StringUtil.RTrim( Combo_usumosbancod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Selectedtext_set", StringUtil.RTrim( Combo_usumosbancod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Enabled", StringUtil.BoolToStr( Combo_usumosbancod_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Datalistproc", StringUtil.RTrim( Combo_usumosbancod_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSBANCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usumosbancod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Objectcall", StringUtil.RTrim( Combo_usumoscbcod_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Cls", StringUtil.RTrim( Combo_usumoscbcod_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Selectedvalue_set", StringUtil.RTrim( Combo_usumoscbcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Selectedtext_set", StringUtil.RTrim( Combo_usumoscbcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Enabled", StringUtil.BoolToStr( Combo_usumoscbcod_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Datalistproc", StringUtil.RTrim( Combo_usumoscbcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCBCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usumoscbcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Objectcall", StringUtil.RTrim( Combo_usumosconcepto_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Cls", StringUtil.RTrim( Combo_usumosconcepto_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Selectedvalue_set", StringUtil.RTrim( Combo_usumosconcepto_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Selectedtext_set", StringUtil.RTrim( Combo_usumosconcepto_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Enabled", StringUtil.BoolToStr( Combo_usumosconcepto_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Datalistproc", StringUtil.RTrim( Combo_usumosconcepto_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_USUMOSCONCEPTO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usumosconcepto_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Objectcall", StringUtil.RTrim( Dvpanel_panelfiltromostrador_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Enabled", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Width", StringUtil.RTrim( Dvpanel_panelfiltromostrador_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Autowidth", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Autoheight", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Cls", StringUtil.RTrim( Dvpanel_panelfiltromostrador_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Title", StringUtil.RTrim( Dvpanel_panelfiltromostrador_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Collapsible", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Collapsed", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Iconposition", StringUtil.RTrim( Dvpanel_panelfiltromostrador_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELFILTROMOSTRADOR_Autoscroll", StringUtil.BoolToStr( Dvpanel_panelfiltromostrador_Autoscroll));
      }

      protected void RenderHtmlCloseForm5H32( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "Seguridad.UsuariosOpciones" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios Opciones" ;
      }

      protected void InitializeNonKey5H32( )
      {
         A2016UsuMosBanCod = 0;
         n2016UsuMosBanCod = false;
         AssignAttri(sPrefix, false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
         n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
         A2017UsuMosCBCod = "";
         n2017UsuMosCBCod = false;
         AssignAttri(sPrefix, false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
         n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
         A350UsuMosConcepto = 0;
         n350UsuMosConcepto = false;
         AssignAttri(sPrefix, false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
         n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
         A2026UsuPedMon = 0;
         n2026UsuPedMon = false;
         AssignAttri(sPrefix, false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
         n2026UsuPedMon = ((0==A2026UsuPedMon) ? true : false);
         A2019UsuNom = "";
         AssignAttri(sPrefix, false, "A2019UsuNom", A2019UsuNom);
         A2027UsuPedPrecio = 0;
         AssignAttri(sPrefix, false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
         A2023UsuPedDscto = 0;
         AssignAttri(sPrefix, false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
         A2028UsuPedStock = 0;
         AssignAttri(sPrefix, false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
         A2029UsuPedVend = 0;
         AssignAttri(sPrefix, false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
         A2022UsuPedCond = 0;
         AssignAttri(sPrefix, false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
         A2024UsuPedList = 0;
         AssignAttri(sPrefix, false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
         A2018UsuMosConceptoDsc = "";
         AssignAttri(sPrefix, false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
         Z2026UsuPedMon = 0;
         Z2019UsuNom = "";
         Z2027UsuPedPrecio = 0;
         Z2023UsuPedDscto = 0;
         Z2028UsuPedStock = 0;
         Z2029UsuPedVend = 0;
         Z2022UsuPedCond = 0;
         Z2024UsuPedList = 0;
         Z2016UsuMosBanCod = 0;
         Z2017UsuMosCBCod = "";
         Z350UsuMosConcepto = 0;
      }

      protected void InitAll5H32( )
      {
         A348UsuCod = "";
         AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         InitializeNonKey5H32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7UsuCod = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "seguridad\\usuariosopciones", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV7UsuCod = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7UsuCod = cgiGet( sPrefix+"wcpOAV7UsuCod");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV7UsuCod, wcpOAV7UsuCod) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7UsuCod = AV7UsuCod;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV7UsuCod = cgiGet( sPrefix+"AV7UsuCod_CTRL");
         if ( StringUtil.Len( sCtrlAV7UsuCod) > 0 )
         {
            AV7UsuCod = cgiGet( sCtrlAV7UsuCod);
            AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
         }
         else
         {
            AV7UsuCod = cgiGet( sPrefix+"AV7UsuCod_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuCod_PARM", StringUtil.RTrim( AV7UsuCod));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7UsuCod)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuCod_CTRL", StringUtil.RTrim( sCtrlAV7UsuCod));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         Draw( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181138446", true, true);
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
         context.AddJavascriptSource("seguridad/usuariosopciones.js", "?20228181138446", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         lblTxtcontacmsj_Internalname = sPrefix+"TXTCONTACMSJ";
         divTablamensaje_Internalname = sPrefix+"TABLAMENSAJE";
         chkUsuPedPrecio_Internalname = sPrefix+"USUPEDPRECIO";
         chkUsuPedDscto_Internalname = sPrefix+"USUPEDDSCTO";
         chkUsuPedStock_Internalname = sPrefix+"USUPEDSTOCK";
         chkUsuPedVend_Internalname = sPrefix+"USUPEDVEND";
         chkUsuPedCond_Internalname = sPrefix+"USUPEDCOND";
         chkUsuPedList_Internalname = sPrefix+"USUPEDLIST";
         lblTextblockusupedmon_Internalname = sPrefix+"TEXTBLOCKUSUPEDMON";
         Combo_usupedmon_Internalname = sPrefix+"COMBO_USUPEDMON";
         edtUsuPedMon_Internalname = sPrefix+"USUPEDMON";
         divTablesplittedusupedmon_Internalname = sPrefix+"TABLESPLITTEDUSUPEDMON";
         divPanelopcionespedidos_Internalname = sPrefix+"PANELOPCIONESPEDIDOS";
         Dvpanel_panelopcionespedidos_Internalname = sPrefix+"DVPANEL_PANELOPCIONESPEDIDOS";
         lblTextblockusumosbancod_Internalname = sPrefix+"TEXTBLOCKUSUMOSBANCOD";
         Combo_usumosbancod_Internalname = sPrefix+"COMBO_USUMOSBANCOD";
         edtUsuMosBanCod_Internalname = sPrefix+"USUMOSBANCOD";
         divTablesplittedusumosbancod_Internalname = sPrefix+"TABLESPLITTEDUSUMOSBANCOD";
         lblTextblockusumoscbcod_Internalname = sPrefix+"TEXTBLOCKUSUMOSCBCOD";
         Combo_usumoscbcod_Internalname = sPrefix+"COMBO_USUMOSCBCOD";
         edtUsuMosCBCod_Internalname = sPrefix+"USUMOSCBCOD";
         divTablesplittedusumoscbcod_Internalname = sPrefix+"TABLESPLITTEDUSUMOSCBCOD";
         lblTextblockusumosconcepto_Internalname = sPrefix+"TEXTBLOCKUSUMOSCONCEPTO";
         Combo_usumosconcepto_Internalname = sPrefix+"COMBO_USUMOSCONCEPTO";
         edtUsuMosConcepto_Internalname = sPrefix+"USUMOSCONCEPTO";
         divTablesplittedusumosconcepto_Internalname = sPrefix+"TABLESPLITTEDUSUMOSCONCEPTO";
         divPanelfiltromostrador_Internalname = sPrefix+"PANELFILTROMOSTRADOR";
         Dvpanel_panelfiltromostrador_Internalname = sPrefix+"DVPANEL_PANELFILTROMOSTRADOR";
         divTablacontenido_Internalname = sPrefix+"TABLACONTENIDO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCombousupedmon_Internalname = sPrefix+"vCOMBOUSUPEDMON";
         divSectionattribute_usupedmon_Internalname = sPrefix+"SECTIONATTRIBUTE_USUPEDMON";
         edtavCombousumosbancod_Internalname = sPrefix+"vCOMBOUSUMOSBANCOD";
         divSectionattribute_usumosbancod_Internalname = sPrefix+"SECTIONATTRIBUTE_USUMOSBANCOD";
         edtavCombousumoscbcod_Internalname = sPrefix+"vCOMBOUSUMOSCBCOD";
         divSectionattribute_usumoscbcod_Internalname = sPrefix+"SECTIONATTRIBUTE_USUMOSCBCOD";
         edtavCombousumosconcepto_Internalname = sPrefix+"vCOMBOUSUMOSCONCEPTO";
         divSectionattribute_usumosconcepto_Internalname = sPrefix+"SECTIONATTRIBUTE_USUMOSCONCEPTO";
         edtUsuCod_Internalname = sPrefix+"USUCOD";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         Combo_usumoscbcod_Datalistprocparametersprefix = "";
         edtUsuCod_Jsonclick = "";
         edtUsuCod_Enabled = 1;
         edtUsuCod_Visible = 1;
         edtavCombousumosconcepto_Jsonclick = "";
         edtavCombousumosconcepto_Enabled = 0;
         edtavCombousumosconcepto_Visible = 1;
         edtavCombousumoscbcod_Jsonclick = "";
         edtavCombousumoscbcod_Enabled = 0;
         edtavCombousumoscbcod_Visible = 1;
         edtavCombousumosbancod_Jsonclick = "";
         edtavCombousumosbancod_Enabled = 0;
         edtavCombousumosbancod_Visible = 1;
         edtavCombousupedmon_Jsonclick = "";
         edtavCombousupedmon_Enabled = 0;
         edtavCombousupedmon_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtUsuMosConcepto_Jsonclick = "";
         edtUsuMosConcepto_Enabled = 1;
         edtUsuMosConcepto_Visible = 1;
         Combo_usumosconcepto_Datalistprocparametersprefix = " \"ComboName\": \"UsuMosConcepto\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\"";
         Combo_usumosconcepto_Datalistproc = "Seguridad.UsuariosOpcionesLoadDVCombo";
         Combo_usumosconcepto_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_usumosconcepto_Caption = "";
         Combo_usumosconcepto_Enabled = Convert.ToBoolean( -1);
         edtUsuMosCBCod_Jsonclick = "";
         edtUsuMosCBCod_Enabled = 1;
         edtUsuMosCBCod_Visible = 1;
         Combo_usumoscbcod_Datalistproc = "Seguridad.UsuariosOpcionesLoadDVCombo";
         Combo_usumoscbcod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_usumoscbcod_Caption = "";
         Combo_usumoscbcod_Enabled = Convert.ToBoolean( -1);
         edtUsuMosBanCod_Jsonclick = "";
         edtUsuMosBanCod_Enabled = 1;
         edtUsuMosBanCod_Visible = 1;
         Combo_usumosbancod_Datalistprocparametersprefix = " \"ComboName\": \"UsuMosBanCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\"";
         Combo_usumosbancod_Datalistproc = "Seguridad.UsuariosOpcionesLoadDVCombo";
         Combo_usumosbancod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_usumosbancod_Caption = "";
         Combo_usumosbancod_Enabled = Convert.ToBoolean( -1);
         Dvpanel_panelfiltromostrador_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panelfiltromostrador_Iconposition = "Right";
         Dvpanel_panelfiltromostrador_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panelfiltromostrador_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panelfiltromostrador_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panelfiltromostrador_Title = "Opciones Venta Mostrador";
         Dvpanel_panelfiltromostrador_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panelfiltromostrador_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panelfiltromostrador_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panelfiltromostrador_Width = "100%";
         edtUsuPedMon_Jsonclick = "";
         edtUsuPedMon_Enabled = 1;
         edtUsuPedMon_Visible = 1;
         Combo_usupedmon_Cls = "ExtendedCombo Attribute";
         Combo_usupedmon_Caption = "";
         Combo_usupedmon_Enabled = Convert.ToBoolean( -1);
         chkUsuPedList.Enabled = 1;
         chkUsuPedCond.Enabled = 1;
         chkUsuPedVend.Enabled = 1;
         chkUsuPedStock.Enabled = 1;
         chkUsuPedDscto.Enabled = 1;
         chkUsuPedPrecio.Enabled = 1;
         Dvpanel_panelopcionespedidos_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panelopcionespedidos_Iconposition = "Right";
         Dvpanel_panelopcionespedidos_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panelopcionespedidos_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panelopcionespedidos_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panelopcionespedidos_Title = "Opciones de Pedidos";
         Dvpanel_panelopcionespedidos_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panelopcionespedidos_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panelopcionespedidos_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panelopcionespedidos_Width = "100%";
         divTablacontenido_Visible = 1;
         divTablamensaje_Visible = 1;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         chkUsuPedPrecio.Name = "USUPEDPRECIO";
         chkUsuPedPrecio.WebTags = "";
         chkUsuPedPrecio.Caption = "";
         AssignProp(sPrefix, false, chkUsuPedPrecio_Internalname, "TitleCaption", chkUsuPedPrecio.Caption, true);
         chkUsuPedPrecio.CheckedValue = "0";
         chkUsuPedDscto.Name = "USUPEDDSCTO";
         chkUsuPedDscto.WebTags = "";
         chkUsuPedDscto.Caption = "";
         AssignProp(sPrefix, false, chkUsuPedDscto_Internalname, "TitleCaption", chkUsuPedDscto.Caption, true);
         chkUsuPedDscto.CheckedValue = "0";
         chkUsuPedStock.Name = "USUPEDSTOCK";
         chkUsuPedStock.WebTags = "";
         chkUsuPedStock.Caption = "";
         AssignProp(sPrefix, false, chkUsuPedStock_Internalname, "TitleCaption", chkUsuPedStock.Caption, true);
         chkUsuPedStock.CheckedValue = "0";
         chkUsuPedVend.Name = "USUPEDVEND";
         chkUsuPedVend.WebTags = "";
         chkUsuPedVend.Caption = "";
         AssignProp(sPrefix, false, chkUsuPedVend_Internalname, "TitleCaption", chkUsuPedVend.Caption, true);
         chkUsuPedVend.CheckedValue = "0";
         chkUsuPedCond.Name = "USUPEDCOND";
         chkUsuPedCond.WebTags = "";
         chkUsuPedCond.Caption = "";
         AssignProp(sPrefix, false, chkUsuPedCond_Internalname, "TitleCaption", chkUsuPedCond.Caption, true);
         chkUsuPedCond.CheckedValue = "0";
         chkUsuPedList.Name = "USUPEDLIST";
         chkUsuPedList.WebTags = "";
         chkUsuPedList.Caption = "";
         AssignProp(sPrefix, false, chkUsuPedList_Internalname, "TitleCaption", chkUsuPedList.Caption, true);
         chkUsuPedList.CheckedValue = "0";
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

      public void Valid_Usumosbancod( )
      {
         n2016UsuMosBanCod = false;
         /* Using cursor T005H25 */
         pr_default.execute(23, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
            }
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usumoscbcod( )
      {
         n2016UsuMosBanCod = false;
         n2017UsuMosCBCod = false;
         /* Using cursor T005H26 */
         pr_default.execute(24, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Banco'.", "ForeignKeyNotFound", 1, "USUMOSCBCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usumosconcepto( )
      {
         n350UsuMosConcepto = false;
         /* Using cursor T005H17 */
         pr_default.execute(15, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A350UsuMosConcepto) ) )
            {
               GX_msglist.addItem("No existe 'Sub Banco Mostrador'.", "ForeignKeyNotFound", 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
            }
         }
         A2018UsuMosConceptoDsc = T005H17_A2018UsuMosConceptoDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A2018UsuMosConceptoDsc", StringUtil.RTrim( A2018UsuMosConceptoDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7UsuCod',fld:'vUSUCOD',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A2019UsuNom',fld:'USUNOM',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E125H2',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUMOSBANCOD","{handler:'Valid_Usumosbancod',iparms:[{av:'A2016UsuMosBanCod',fld:'USUMOSBANCOD',pic:'ZZZZZ9'},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUMOSBANCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUMOSCBCOD","{handler:'Valid_Usumoscbcod',iparms:[{av:'A2016UsuMosBanCod',fld:'USUMOSBANCOD',pic:'ZZZZZ9'},{av:'A2017UsuMosCBCod',fld:'USUMOSCBCOD',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUMOSCBCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUMOSCONCEPTO","{handler:'Valid_Usumosconcepto',iparms:[{av:'A350UsuMosConcepto',fld:'USUMOSCONCEPTO',pic:'ZZZZZ9'},{av:'A2018UsuMosConceptoDsc',fld:'USUMOSCONCEPTODSC',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUMOSCONCEPTO",",oparms:[{av:'A2018UsuMosConceptoDsc',fld:'USUMOSCONCEPTODSC',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUSUPEDMON","{handler:'Validv_Combousupedmon',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUSUPEDMON",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUSUMOSBANCOD","{handler:'Validv_Combousumosbancod',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUSUMOSBANCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUSUMOSCBCOD","{handler:'Validv_Combousumoscbcod',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUSUMOSCBCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUSUMOSCONCEPTO","{handler:'Validv_Combousumosconcepto',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUSUMOSCONCEPTO",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7UsuCod = "";
         Z348UsuCod = "";
         Z2019UsuNom = "";
         Z2017UsuMosCBCod = "";
         N2017UsuMosCBCod = "";
         Combo_usumosconcepto_Selectedvalue_get = "";
         Combo_usumoscbcod_Selectedvalue_get = "";
         Combo_usumosbancod_Selectedvalue_get = "";
         Combo_usupedmon_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2017UsuMosCBCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTxtcontacmsj_Jsonclick = "";
         ucDvpanel_panelopcionespedidos = new GXUserControl();
         TempTags = "";
         lblTextblockusupedmon_Jsonclick = "";
         ucCombo_usupedmon = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV29UsuPedMon_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucDvpanel_panelfiltromostrador = new GXUserControl();
         lblTextblockusumosbancod_Jsonclick = "";
         ucCombo_usumosbancod = new GXUserControl();
         AV22UsuMosBanCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockusumoscbcod_Jsonclick = "";
         ucCombo_usumoscbcod = new GXUserControl();
         AV25UsuMosCBCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockusumosconcepto_Jsonclick = "";
         ucCombo_usumosconcepto = new GXUserControl();
         AV13UsuMosConcepto_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV26ComboUsuMosCBCod = "";
         A348UsuCod = "";
         A2019UsuNom = "";
         AV21Insert_UsuMosCBCod = "";
         A2018UsuMosConceptoDsc = "";
         AV31Pgmname = "";
         Combo_usupedmon_Objectcall = "";
         Combo_usupedmon_Class = "";
         Combo_usupedmon_Icontype = "";
         Combo_usupedmon_Icon = "";
         Combo_usupedmon_Tooltip = "";
         Combo_usupedmon_Selectedvalue_set = "";
         Combo_usupedmon_Selectedtext_set = "";
         Combo_usupedmon_Selectedtext_get = "";
         Combo_usupedmon_Gamoauthtoken = "";
         Combo_usupedmon_Ddointernalname = "";
         Combo_usupedmon_Titlecontrolalign = "";
         Combo_usupedmon_Dropdownoptionstype = "";
         Combo_usupedmon_Titlecontrolidtoreplace = "";
         Combo_usupedmon_Datalisttype = "";
         Combo_usupedmon_Datalistfixedvalues = "";
         Combo_usupedmon_Datalistproc = "";
         Combo_usupedmon_Datalistprocparametersprefix = "";
         Combo_usupedmon_Htmltemplate = "";
         Combo_usupedmon_Multiplevaluestype = "";
         Combo_usupedmon_Loadingdata = "";
         Combo_usupedmon_Noresultsfound = "";
         Combo_usupedmon_Emptyitemtext = "";
         Combo_usupedmon_Onlyselectedvalues = "";
         Combo_usupedmon_Selectalltext = "";
         Combo_usupedmon_Multiplevaluesseparator = "";
         Combo_usupedmon_Addnewoptiontext = "";
         Dvpanel_panelopcionespedidos_Objectcall = "";
         Dvpanel_panelopcionespedidos_Class = "";
         Dvpanel_panelopcionespedidos_Height = "";
         Combo_usumosbancod_Objectcall = "";
         Combo_usumosbancod_Class = "";
         Combo_usumosbancod_Icontype = "";
         Combo_usumosbancod_Icon = "";
         Combo_usumosbancod_Tooltip = "";
         Combo_usumosbancod_Selectedvalue_set = "";
         Combo_usumosbancod_Selectedtext_set = "";
         Combo_usumosbancod_Selectedtext_get = "";
         Combo_usumosbancod_Gamoauthtoken = "";
         Combo_usumosbancod_Ddointernalname = "";
         Combo_usumosbancod_Titlecontrolalign = "";
         Combo_usumosbancod_Dropdownoptionstype = "";
         Combo_usumosbancod_Titlecontrolidtoreplace = "";
         Combo_usumosbancod_Datalisttype = "";
         Combo_usumosbancod_Datalistfixedvalues = "";
         Combo_usumosbancod_Htmltemplate = "";
         Combo_usumosbancod_Multiplevaluestype = "";
         Combo_usumosbancod_Loadingdata = "";
         Combo_usumosbancod_Noresultsfound = "";
         Combo_usumosbancod_Emptyitemtext = "";
         Combo_usumosbancod_Onlyselectedvalues = "";
         Combo_usumosbancod_Selectalltext = "";
         Combo_usumosbancod_Multiplevaluesseparator = "";
         Combo_usumosbancod_Addnewoptiontext = "";
         Combo_usumoscbcod_Objectcall = "";
         Combo_usumoscbcod_Class = "";
         Combo_usumoscbcod_Icontype = "";
         Combo_usumoscbcod_Icon = "";
         Combo_usumoscbcod_Tooltip = "";
         Combo_usumoscbcod_Selectedvalue_set = "";
         Combo_usumoscbcod_Selectedtext_set = "";
         Combo_usumoscbcod_Selectedtext_get = "";
         Combo_usumoscbcod_Gamoauthtoken = "";
         Combo_usumoscbcod_Ddointernalname = "";
         Combo_usumoscbcod_Titlecontrolalign = "";
         Combo_usumoscbcod_Dropdownoptionstype = "";
         Combo_usumoscbcod_Titlecontrolidtoreplace = "";
         Combo_usumoscbcod_Datalisttype = "";
         Combo_usumoscbcod_Datalistfixedvalues = "";
         Combo_usumoscbcod_Htmltemplate = "";
         Combo_usumoscbcod_Multiplevaluestype = "";
         Combo_usumoscbcod_Loadingdata = "";
         Combo_usumoscbcod_Noresultsfound = "";
         Combo_usumoscbcod_Emptyitemtext = "";
         Combo_usumoscbcod_Onlyselectedvalues = "";
         Combo_usumoscbcod_Selectalltext = "";
         Combo_usumoscbcod_Multiplevaluesseparator = "";
         Combo_usumoscbcod_Addnewoptiontext = "";
         Combo_usumosconcepto_Objectcall = "";
         Combo_usumosconcepto_Class = "";
         Combo_usumosconcepto_Icontype = "";
         Combo_usumosconcepto_Icon = "";
         Combo_usumosconcepto_Tooltip = "";
         Combo_usumosconcepto_Selectedvalue_set = "";
         Combo_usumosconcepto_Selectedtext_set = "";
         Combo_usumosconcepto_Selectedtext_get = "";
         Combo_usumosconcepto_Gamoauthtoken = "";
         Combo_usumosconcepto_Ddointernalname = "";
         Combo_usumosconcepto_Titlecontrolalign = "";
         Combo_usumosconcepto_Dropdownoptionstype = "";
         Combo_usumosconcepto_Titlecontrolidtoreplace = "";
         Combo_usumosconcepto_Datalisttype = "";
         Combo_usumosconcepto_Datalistfixedvalues = "";
         Combo_usumosconcepto_Htmltemplate = "";
         Combo_usumosconcepto_Multiplevaluestype = "";
         Combo_usumosconcepto_Loadingdata = "";
         Combo_usumosconcepto_Noresultsfound = "";
         Combo_usumosconcepto_Emptyitemtext = "";
         Combo_usumosconcepto_Onlyselectedvalues = "";
         Combo_usumosconcepto_Selectalltext = "";
         Combo_usumosconcepto_Multiplevaluesseparator = "";
         Combo_usumosconcepto_Addnewoptiontext = "";
         Dvpanel_panelfiltromostrador_Objectcall = "";
         Dvpanel_panelfiltromostrador_Class = "";
         Dvpanel_panelfiltromostrador_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode32 = "";
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
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         Z2018UsuMosConceptoDsc = "";
         T005H6_A2018UsuMosConceptoDsc = new string[] {""} ;
         T005H7_A348UsuCod = new string[] {""} ;
         T005H7_A2026UsuPedMon = new int[1] ;
         T005H7_n2026UsuPedMon = new bool[] {false} ;
         T005H7_A2019UsuNom = new string[] {""} ;
         T005H7_A2027UsuPedPrecio = new short[1] ;
         T005H7_A2023UsuPedDscto = new short[1] ;
         T005H7_A2028UsuPedStock = new short[1] ;
         T005H7_A2029UsuPedVend = new short[1] ;
         T005H7_A2022UsuPedCond = new short[1] ;
         T005H7_A2024UsuPedList = new short[1] ;
         T005H7_A2018UsuMosConceptoDsc = new string[] {""} ;
         T005H7_A2016UsuMosBanCod = new int[1] ;
         T005H7_n2016UsuMosBanCod = new bool[] {false} ;
         T005H7_A2017UsuMosCBCod = new string[] {""} ;
         T005H7_n2017UsuMosCBCod = new bool[] {false} ;
         T005H7_A350UsuMosConcepto = new int[1] ;
         T005H7_n350UsuMosConcepto = new bool[] {false} ;
         T005H4_A2016UsuMosBanCod = new int[1] ;
         T005H4_n2016UsuMosBanCod = new bool[] {false} ;
         T005H5_A2016UsuMosBanCod = new int[1] ;
         T005H5_n2016UsuMosBanCod = new bool[] {false} ;
         T005H8_A2016UsuMosBanCod = new int[1] ;
         T005H8_n2016UsuMosBanCod = new bool[] {false} ;
         T005H9_A2016UsuMosBanCod = new int[1] ;
         T005H9_n2016UsuMosBanCod = new bool[] {false} ;
         T005H10_A2018UsuMosConceptoDsc = new string[] {""} ;
         T005H11_A348UsuCod = new string[] {""} ;
         T005H3_A348UsuCod = new string[] {""} ;
         T005H3_A2026UsuPedMon = new int[1] ;
         T005H3_n2026UsuPedMon = new bool[] {false} ;
         T005H3_A2019UsuNom = new string[] {""} ;
         T005H3_A2027UsuPedPrecio = new short[1] ;
         T005H3_A2023UsuPedDscto = new short[1] ;
         T005H3_A2028UsuPedStock = new short[1] ;
         T005H3_A2029UsuPedVend = new short[1] ;
         T005H3_A2022UsuPedCond = new short[1] ;
         T005H3_A2024UsuPedList = new short[1] ;
         T005H3_A2016UsuMosBanCod = new int[1] ;
         T005H3_n2016UsuMosBanCod = new bool[] {false} ;
         T005H3_A2017UsuMosCBCod = new string[] {""} ;
         T005H3_n2017UsuMosCBCod = new bool[] {false} ;
         T005H3_A350UsuMosConcepto = new int[1] ;
         T005H3_n350UsuMosConcepto = new bool[] {false} ;
         T005H12_A348UsuCod = new string[] {""} ;
         T005H13_A348UsuCod = new string[] {""} ;
         T005H2_A348UsuCod = new string[] {""} ;
         T005H2_A2026UsuPedMon = new int[1] ;
         T005H2_n2026UsuPedMon = new bool[] {false} ;
         T005H2_A2019UsuNom = new string[] {""} ;
         T005H2_A2027UsuPedPrecio = new short[1] ;
         T005H2_A2023UsuPedDscto = new short[1] ;
         T005H2_A2028UsuPedStock = new short[1] ;
         T005H2_A2029UsuPedVend = new short[1] ;
         T005H2_A2022UsuPedCond = new short[1] ;
         T005H2_A2024UsuPedList = new short[1] ;
         T005H2_A2016UsuMosBanCod = new int[1] ;
         T005H2_n2016UsuMosBanCod = new bool[] {false} ;
         T005H2_A2017UsuMosCBCod = new string[] {""} ;
         T005H2_n2017UsuMosCBCod = new bool[] {false} ;
         T005H2_A350UsuMosConcepto = new int[1] ;
         T005H2_n350UsuMosConcepto = new bool[] {false} ;
         T005H17_A2018UsuMosConceptoDsc = new string[] {""} ;
         T005H18_A2237SGNotificacionID = new long[1] ;
         T005H18_A2245SGNotificacionDetID = new short[1] ;
         T005H19_A2237SGNotificacionID = new long[1] ;
         T005H20_A348UsuCod = new string[] {""} ;
         T005H20_A149TipCod = new string[] {""} ;
         T005H20_A351UsuSerDet = new string[] {""} ;
         T005H21_A348UsuCod = new string[] {""} ;
         T005H21_A346ObjCod = new int[1] ;
         T005H22_A348UsuCod = new string[] {""} ;
         T005H22_A342SGMenuPrograma = new string[] {""} ;
         T005H22_A343SGMenuNiv1ID = new string[] {""} ;
         T005H23_A348UsuCod = new string[] {""} ;
         T005H23_A349UsuAlmCod = new int[1] ;
         T005H24_A348UsuCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         sCtrlGx_mode = "";
         sCtrlAV7UsuCod = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         T005H25_A2016UsuMosBanCod = new int[1] ;
         T005H25_n2016UsuMosBanCod = new bool[] {false} ;
         T005H26_A2016UsuMosBanCod = new int[1] ;
         T005H26_n2016UsuMosBanCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosopciones__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosopciones__default(),
            new Object[][] {
                new Object[] {
               T005H2_A348UsuCod, T005H2_A2026UsuPedMon, T005H2_n2026UsuPedMon, T005H2_A2019UsuNom, T005H2_A2027UsuPedPrecio, T005H2_A2023UsuPedDscto, T005H2_A2028UsuPedStock, T005H2_A2029UsuPedVend, T005H2_A2022UsuPedCond, T005H2_A2024UsuPedList,
               T005H2_A2016UsuMosBanCod, T005H2_n2016UsuMosBanCod, T005H2_A2017UsuMosCBCod, T005H2_n2017UsuMosCBCod, T005H2_A350UsuMosConcepto, T005H2_n350UsuMosConcepto
               }
               , new Object[] {
               T005H3_A348UsuCod, T005H3_A2026UsuPedMon, T005H3_n2026UsuPedMon, T005H3_A2019UsuNom, T005H3_A2027UsuPedPrecio, T005H3_A2023UsuPedDscto, T005H3_A2028UsuPedStock, T005H3_A2029UsuPedVend, T005H3_A2022UsuPedCond, T005H3_A2024UsuPedList,
               T005H3_A2016UsuMosBanCod, T005H3_n2016UsuMosBanCod, T005H3_A2017UsuMosCBCod, T005H3_n2017UsuMosCBCod, T005H3_A350UsuMosConcepto, T005H3_n350UsuMosConcepto
               }
               , new Object[] {
               T005H4_A2016UsuMosBanCod
               }
               , new Object[] {
               T005H5_A2016UsuMosBanCod
               }
               , new Object[] {
               T005H6_A2018UsuMosConceptoDsc
               }
               , new Object[] {
               T005H7_A348UsuCod, T005H7_A2026UsuPedMon, T005H7_n2026UsuPedMon, T005H7_A2019UsuNom, T005H7_A2027UsuPedPrecio, T005H7_A2023UsuPedDscto, T005H7_A2028UsuPedStock, T005H7_A2029UsuPedVend, T005H7_A2022UsuPedCond, T005H7_A2024UsuPedList,
               T005H7_A2018UsuMosConceptoDsc, T005H7_A2016UsuMosBanCod, T005H7_n2016UsuMosBanCod, T005H7_A2017UsuMosCBCod, T005H7_n2017UsuMosCBCod, T005H7_A350UsuMosConcepto, T005H7_n350UsuMosConcepto
               }
               , new Object[] {
               T005H8_A2016UsuMosBanCod
               }
               , new Object[] {
               T005H9_A2016UsuMosBanCod
               }
               , new Object[] {
               T005H10_A2018UsuMosConceptoDsc
               }
               , new Object[] {
               T005H11_A348UsuCod
               }
               , new Object[] {
               T005H12_A348UsuCod
               }
               , new Object[] {
               T005H13_A348UsuCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005H17_A2018UsuMosConceptoDsc
               }
               , new Object[] {
               T005H18_A2237SGNotificacionID, T005H18_A2245SGNotificacionDetID
               }
               , new Object[] {
               T005H19_A2237SGNotificacionID
               }
               , new Object[] {
               T005H20_A348UsuCod, T005H20_A149TipCod, T005H20_A351UsuSerDet
               }
               , new Object[] {
               T005H21_A348UsuCod, T005H21_A346ObjCod
               }
               , new Object[] {
               T005H22_A348UsuCod, T005H22_A342SGMenuPrograma, T005H22_A343SGMenuNiv1ID
               }
               , new Object[] {
               T005H23_A348UsuCod, T005H23_A349UsuAlmCod
               }
               , new Object[] {
               T005H24_A348UsuCod
               }
               , new Object[] {
               T005H25_A2016UsuMosBanCod
               }
               , new Object[] {
               T005H26_A2016UsuMosBanCod
               }
            }
         );
         AV31Pgmname = "Seguridad.UsuariosOpciones";
      }

      private short Z2027UsuPedPrecio ;
      private short Z2023UsuPedDscto ;
      private short Z2028UsuPedStock ;
      private short Z2029UsuPedVend ;
      private short Z2022UsuPedCond ;
      private short Z2024UsuPedList ;
      private short GxWebError ;
      private short nDynComponent ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2027UsuPedPrecio ;
      private short A2023UsuPedDscto ;
      private short A2028UsuPedStock ;
      private short A2029UsuPedVend ;
      private short A2022UsuPedCond ;
      private short A2024UsuPedList ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound32 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_32 ;
      private int Z2026UsuPedMon ;
      private int Z2016UsuMosBanCod ;
      private int Z350UsuMosConcepto ;
      private int N2016UsuMosBanCod ;
      private int N350UsuMosConcepto ;
      private int A2016UsuMosBanCod ;
      private int A350UsuMosConcepto ;
      private int trnEnded ;
      private int divTablamensaje_Visible ;
      private int divTablacontenido_Visible ;
      private int A2026UsuPedMon ;
      private int edtUsuPedMon_Enabled ;
      private int edtUsuPedMon_Visible ;
      private int edtUsuMosBanCod_Visible ;
      private int edtUsuMosBanCod_Enabled ;
      private int edtUsuMosCBCod_Visible ;
      private int edtUsuMosCBCod_Enabled ;
      private int edtUsuMosConcepto_Visible ;
      private int edtUsuMosConcepto_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV30ComboUsuPedMon ;
      private int edtavCombousupedmon_Enabled ;
      private int edtavCombousupedmon_Visible ;
      private int AV23ComboUsuMosBanCod ;
      private int edtavCombousumosbancod_Enabled ;
      private int edtavCombousumosbancod_Visible ;
      private int edtavCombousumoscbcod_Visible ;
      private int edtavCombousumoscbcod_Enabled ;
      private int AV18ComboUsuMosConcepto ;
      private int edtavCombousumosconcepto_Enabled ;
      private int edtavCombousumosconcepto_Visible ;
      private int edtUsuCod_Visible ;
      private int edtUsuCod_Enabled ;
      private int AV28Cond_UsuMosBanCod ;
      private int AV20Insert_UsuMosBanCod ;
      private int AV11Insert_UsuMosConcepto ;
      private int Combo_usupedmon_Datalistupdateminimumcharacters ;
      private int Combo_usupedmon_Gxcontroltype ;
      private int Dvpanel_panelopcionespedidos_Gxcontroltype ;
      private int Combo_usumosbancod_Datalistupdateminimumcharacters ;
      private int Combo_usumosbancod_Gxcontroltype ;
      private int Combo_usumoscbcod_Datalistupdateminimumcharacters ;
      private int Combo_usumoscbcod_Gxcontroltype ;
      private int Combo_usumosconcepto_Datalistupdateminimumcharacters ;
      private int Combo_usumosconcepto_Gxcontroltype ;
      private int Dvpanel_panelfiltromostrador_Gxcontroltype ;
      private int AV32GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7UsuCod ;
      private string Z348UsuCod ;
      private string Z2019UsuNom ;
      private string Z2017UsuMosCBCod ;
      private string N2017UsuMosCBCod ;
      private string Combo_usumosconcepto_Selectedvalue_get ;
      private string Combo_usumoscbcod_Selectedvalue_get ;
      private string Combo_usumosbancod_Selectedvalue_get ;
      private string Combo_usupedmon_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string AV7UsuCod ;
      private string A2017UsuMosCBCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string chkUsuPedPrecio_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTablamensaje_Internalname ;
      private string lblTxtcontacmsj_Internalname ;
      private string lblTxtcontacmsj_Jsonclick ;
      private string divTablacontenido_Internalname ;
      private string Dvpanel_panelopcionespedidos_Width ;
      private string Dvpanel_panelopcionespedidos_Cls ;
      private string Dvpanel_panelopcionespedidos_Title ;
      private string Dvpanel_panelopcionespedidos_Iconposition ;
      private string Dvpanel_panelopcionespedidos_Internalname ;
      private string divPanelopcionespedidos_Internalname ;
      private string TempTags ;
      private string chkUsuPedDscto_Internalname ;
      private string chkUsuPedStock_Internalname ;
      private string chkUsuPedVend_Internalname ;
      private string chkUsuPedCond_Internalname ;
      private string chkUsuPedList_Internalname ;
      private string divTablesplittedusupedmon_Internalname ;
      private string lblTextblockusupedmon_Internalname ;
      private string lblTextblockusupedmon_Jsonclick ;
      private string Combo_usupedmon_Caption ;
      private string Combo_usupedmon_Cls ;
      private string Combo_usupedmon_Internalname ;
      private string edtUsuPedMon_Internalname ;
      private string edtUsuPedMon_Jsonclick ;
      private string Dvpanel_panelfiltromostrador_Width ;
      private string Dvpanel_panelfiltromostrador_Cls ;
      private string Dvpanel_panelfiltromostrador_Title ;
      private string Dvpanel_panelfiltromostrador_Iconposition ;
      private string Dvpanel_panelfiltromostrador_Internalname ;
      private string divPanelfiltromostrador_Internalname ;
      private string divTablesplittedusumosbancod_Internalname ;
      private string lblTextblockusumosbancod_Internalname ;
      private string lblTextblockusumosbancod_Jsonclick ;
      private string Combo_usumosbancod_Caption ;
      private string Combo_usumosbancod_Cls ;
      private string Combo_usumosbancod_Datalistproc ;
      private string Combo_usumosbancod_Datalistprocparametersprefix ;
      private string Combo_usumosbancod_Internalname ;
      private string edtUsuMosBanCod_Internalname ;
      private string edtUsuMosBanCod_Jsonclick ;
      private string divTablesplittedusumoscbcod_Internalname ;
      private string lblTextblockusumoscbcod_Internalname ;
      private string lblTextblockusumoscbcod_Jsonclick ;
      private string Combo_usumoscbcod_Caption ;
      private string Combo_usumoscbcod_Cls ;
      private string Combo_usumoscbcod_Datalistproc ;
      private string Combo_usumoscbcod_Internalname ;
      private string edtUsuMosCBCod_Internalname ;
      private string edtUsuMosCBCod_Jsonclick ;
      private string divTablesplittedusumosconcepto_Internalname ;
      private string lblTextblockusumosconcepto_Internalname ;
      private string lblTextblockusumosconcepto_Jsonclick ;
      private string Combo_usumosconcepto_Caption ;
      private string Combo_usumosconcepto_Cls ;
      private string Combo_usumosconcepto_Datalistproc ;
      private string Combo_usumosconcepto_Datalistprocparametersprefix ;
      private string Combo_usumosconcepto_Internalname ;
      private string edtUsuMosConcepto_Internalname ;
      private string edtUsuMosConcepto_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_usupedmon_Internalname ;
      private string edtavCombousupedmon_Internalname ;
      private string edtavCombousupedmon_Jsonclick ;
      private string divSectionattribute_usumosbancod_Internalname ;
      private string edtavCombousumosbancod_Internalname ;
      private string edtavCombousumosbancod_Jsonclick ;
      private string divSectionattribute_usumoscbcod_Internalname ;
      private string AV26ComboUsuMosCBCod ;
      private string edtavCombousumoscbcod_Internalname ;
      private string edtavCombousumoscbcod_Jsonclick ;
      private string divSectionattribute_usumosconcepto_Internalname ;
      private string edtavCombousumosconcepto_Internalname ;
      private string edtavCombousumosconcepto_Jsonclick ;
      private string A348UsuCod ;
      private string edtUsuCod_Internalname ;
      private string edtUsuCod_Jsonclick ;
      private string A2019UsuNom ;
      private string AV21Insert_UsuMosCBCod ;
      private string A2018UsuMosConceptoDsc ;
      private string AV31Pgmname ;
      private string Combo_usupedmon_Objectcall ;
      private string Combo_usupedmon_Class ;
      private string Combo_usupedmon_Icontype ;
      private string Combo_usupedmon_Icon ;
      private string Combo_usupedmon_Tooltip ;
      private string Combo_usupedmon_Selectedvalue_set ;
      private string Combo_usupedmon_Selectedtext_set ;
      private string Combo_usupedmon_Selectedtext_get ;
      private string Combo_usupedmon_Gamoauthtoken ;
      private string Combo_usupedmon_Ddointernalname ;
      private string Combo_usupedmon_Titlecontrolalign ;
      private string Combo_usupedmon_Dropdownoptionstype ;
      private string Combo_usupedmon_Titlecontrolidtoreplace ;
      private string Combo_usupedmon_Datalisttype ;
      private string Combo_usupedmon_Datalistfixedvalues ;
      private string Combo_usupedmon_Datalistproc ;
      private string Combo_usupedmon_Datalistprocparametersprefix ;
      private string Combo_usupedmon_Htmltemplate ;
      private string Combo_usupedmon_Multiplevaluestype ;
      private string Combo_usupedmon_Loadingdata ;
      private string Combo_usupedmon_Noresultsfound ;
      private string Combo_usupedmon_Emptyitemtext ;
      private string Combo_usupedmon_Onlyselectedvalues ;
      private string Combo_usupedmon_Selectalltext ;
      private string Combo_usupedmon_Multiplevaluesseparator ;
      private string Combo_usupedmon_Addnewoptiontext ;
      private string Dvpanel_panelopcionespedidos_Objectcall ;
      private string Dvpanel_panelopcionespedidos_Class ;
      private string Dvpanel_panelopcionespedidos_Height ;
      private string Combo_usumosbancod_Objectcall ;
      private string Combo_usumosbancod_Class ;
      private string Combo_usumosbancod_Icontype ;
      private string Combo_usumosbancod_Icon ;
      private string Combo_usumosbancod_Tooltip ;
      private string Combo_usumosbancod_Selectedvalue_set ;
      private string Combo_usumosbancod_Selectedtext_set ;
      private string Combo_usumosbancod_Selectedtext_get ;
      private string Combo_usumosbancod_Gamoauthtoken ;
      private string Combo_usumosbancod_Ddointernalname ;
      private string Combo_usumosbancod_Titlecontrolalign ;
      private string Combo_usumosbancod_Dropdownoptionstype ;
      private string Combo_usumosbancod_Titlecontrolidtoreplace ;
      private string Combo_usumosbancod_Datalisttype ;
      private string Combo_usumosbancod_Datalistfixedvalues ;
      private string Combo_usumosbancod_Htmltemplate ;
      private string Combo_usumosbancod_Multiplevaluestype ;
      private string Combo_usumosbancod_Loadingdata ;
      private string Combo_usumosbancod_Noresultsfound ;
      private string Combo_usumosbancod_Emptyitemtext ;
      private string Combo_usumosbancod_Onlyselectedvalues ;
      private string Combo_usumosbancod_Selectalltext ;
      private string Combo_usumosbancod_Multiplevaluesseparator ;
      private string Combo_usumosbancod_Addnewoptiontext ;
      private string Combo_usumoscbcod_Objectcall ;
      private string Combo_usumoscbcod_Class ;
      private string Combo_usumoscbcod_Icontype ;
      private string Combo_usumoscbcod_Icon ;
      private string Combo_usumoscbcod_Tooltip ;
      private string Combo_usumoscbcod_Selectedvalue_set ;
      private string Combo_usumoscbcod_Selectedtext_set ;
      private string Combo_usumoscbcod_Selectedtext_get ;
      private string Combo_usumoscbcod_Gamoauthtoken ;
      private string Combo_usumoscbcod_Ddointernalname ;
      private string Combo_usumoscbcod_Titlecontrolalign ;
      private string Combo_usumoscbcod_Dropdownoptionstype ;
      private string Combo_usumoscbcod_Titlecontrolidtoreplace ;
      private string Combo_usumoscbcod_Datalisttype ;
      private string Combo_usumoscbcod_Datalistfixedvalues ;
      private string Combo_usumoscbcod_Datalistprocparametersprefix ;
      private string Combo_usumoscbcod_Htmltemplate ;
      private string Combo_usumoscbcod_Multiplevaluestype ;
      private string Combo_usumoscbcod_Loadingdata ;
      private string Combo_usumoscbcod_Noresultsfound ;
      private string Combo_usumoscbcod_Emptyitemtext ;
      private string Combo_usumoscbcod_Onlyselectedvalues ;
      private string Combo_usumoscbcod_Selectalltext ;
      private string Combo_usumoscbcod_Multiplevaluesseparator ;
      private string Combo_usumoscbcod_Addnewoptiontext ;
      private string Combo_usumosconcepto_Objectcall ;
      private string Combo_usumosconcepto_Class ;
      private string Combo_usumosconcepto_Icontype ;
      private string Combo_usumosconcepto_Icon ;
      private string Combo_usumosconcepto_Tooltip ;
      private string Combo_usumosconcepto_Selectedvalue_set ;
      private string Combo_usumosconcepto_Selectedtext_set ;
      private string Combo_usumosconcepto_Selectedtext_get ;
      private string Combo_usumosconcepto_Gamoauthtoken ;
      private string Combo_usumosconcepto_Ddointernalname ;
      private string Combo_usumosconcepto_Titlecontrolalign ;
      private string Combo_usumosconcepto_Dropdownoptionstype ;
      private string Combo_usumosconcepto_Titlecontrolidtoreplace ;
      private string Combo_usumosconcepto_Datalisttype ;
      private string Combo_usumosconcepto_Datalistfixedvalues ;
      private string Combo_usumosconcepto_Htmltemplate ;
      private string Combo_usumosconcepto_Multiplevaluestype ;
      private string Combo_usumosconcepto_Loadingdata ;
      private string Combo_usumosconcepto_Noresultsfound ;
      private string Combo_usumosconcepto_Emptyitemtext ;
      private string Combo_usumosconcepto_Onlyselectedvalues ;
      private string Combo_usumosconcepto_Selectalltext ;
      private string Combo_usumosconcepto_Multiplevaluesseparator ;
      private string Combo_usumosconcepto_Addnewoptiontext ;
      private string Dvpanel_panelfiltromostrador_Objectcall ;
      private string Dvpanel_panelfiltromostrador_Class ;
      private string Dvpanel_panelfiltromostrador_Height ;
      private string hsh ;
      private string sMode32 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z2018UsuMosConceptoDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2016UsuMosBanCod ;
      private bool n2017UsuMosCBCod ;
      private bool n350UsuMosConcepto ;
      private bool wbErr ;
      private bool Dvpanel_panelopcionespedidos_Autowidth ;
      private bool Dvpanel_panelopcionespedidos_Autoheight ;
      private bool Dvpanel_panelopcionespedidos_Collapsible ;
      private bool Dvpanel_panelopcionespedidos_Collapsed ;
      private bool Dvpanel_panelopcionespedidos_Showcollapseicon ;
      private bool Dvpanel_panelopcionespedidos_Autoscroll ;
      private bool Dvpanel_panelfiltromostrador_Autowidth ;
      private bool Dvpanel_panelfiltromostrador_Autoheight ;
      private bool Dvpanel_panelfiltromostrador_Collapsible ;
      private bool Dvpanel_panelfiltromostrador_Collapsed ;
      private bool Dvpanel_panelfiltromostrador_Showcollapseicon ;
      private bool Dvpanel_panelfiltromostrador_Autoscroll ;
      private bool n2026UsuPedMon ;
      private bool Combo_usupedmon_Enabled ;
      private bool Combo_usupedmon_Visible ;
      private bool Combo_usupedmon_Allowmultipleselection ;
      private bool Combo_usupedmon_Isgriditem ;
      private bool Combo_usupedmon_Hasdescription ;
      private bool Combo_usupedmon_Includeonlyselectedoption ;
      private bool Combo_usupedmon_Includeselectalloption ;
      private bool Combo_usupedmon_Emptyitem ;
      private bool Combo_usupedmon_Includeaddnewoption ;
      private bool Dvpanel_panelopcionespedidos_Enabled ;
      private bool Dvpanel_panelopcionespedidos_Showheader ;
      private bool Dvpanel_panelopcionespedidos_Visible ;
      private bool Combo_usumosbancod_Enabled ;
      private bool Combo_usumosbancod_Visible ;
      private bool Combo_usumosbancod_Allowmultipleselection ;
      private bool Combo_usumosbancod_Isgriditem ;
      private bool Combo_usumosbancod_Hasdescription ;
      private bool Combo_usumosbancod_Includeonlyselectedoption ;
      private bool Combo_usumosbancod_Includeselectalloption ;
      private bool Combo_usumosbancod_Emptyitem ;
      private bool Combo_usumosbancod_Includeaddnewoption ;
      private bool Combo_usumoscbcod_Enabled ;
      private bool Combo_usumoscbcod_Visible ;
      private bool Combo_usumoscbcod_Allowmultipleselection ;
      private bool Combo_usumoscbcod_Isgriditem ;
      private bool Combo_usumoscbcod_Hasdescription ;
      private bool Combo_usumoscbcod_Includeonlyselectedoption ;
      private bool Combo_usumoscbcod_Includeselectalloption ;
      private bool Combo_usumoscbcod_Emptyitem ;
      private bool Combo_usumoscbcod_Includeaddnewoption ;
      private bool Combo_usumosconcepto_Enabled ;
      private bool Combo_usumosconcepto_Visible ;
      private bool Combo_usumosconcepto_Allowmultipleselection ;
      private bool Combo_usumosconcepto_Isgriditem ;
      private bool Combo_usumosconcepto_Hasdescription ;
      private bool Combo_usumosconcepto_Includeonlyselectedoption ;
      private bool Combo_usumosconcepto_Includeselectalloption ;
      private bool Combo_usumosconcepto_Emptyitem ;
      private bool Combo_usumosconcepto_Includeaddnewoption ;
      private bool Dvpanel_panelfiltromostrador_Enabled ;
      private bool Dvpanel_panelfiltromostrador_Showheader ;
      private bool Dvpanel_panelfiltromostrador_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV17Combo_DataJson ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_panelopcionespedidos ;
      private GXUserControl ucCombo_usupedmon ;
      private GXUserControl ucDvpanel_panelfiltromostrador ;
      private GXUserControl ucCombo_usumosbancod ;
      private GXUserControl ucCombo_usumoscbcod ;
      private GXUserControl ucCombo_usumosconcepto ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkUsuPedPrecio ;
      private GXCheckbox chkUsuPedDscto ;
      private GXCheckbox chkUsuPedStock ;
      private GXCheckbox chkUsuPedVend ;
      private GXCheckbox chkUsuPedCond ;
      private GXCheckbox chkUsuPedList ;
      private IDataStoreProvider pr_default ;
      private string[] T005H6_A2018UsuMosConceptoDsc ;
      private string[] T005H7_A348UsuCod ;
      private int[] T005H7_A2026UsuPedMon ;
      private bool[] T005H7_n2026UsuPedMon ;
      private string[] T005H7_A2019UsuNom ;
      private short[] T005H7_A2027UsuPedPrecio ;
      private short[] T005H7_A2023UsuPedDscto ;
      private short[] T005H7_A2028UsuPedStock ;
      private short[] T005H7_A2029UsuPedVend ;
      private short[] T005H7_A2022UsuPedCond ;
      private short[] T005H7_A2024UsuPedList ;
      private string[] T005H7_A2018UsuMosConceptoDsc ;
      private int[] T005H7_A2016UsuMosBanCod ;
      private bool[] T005H7_n2016UsuMosBanCod ;
      private string[] T005H7_A2017UsuMosCBCod ;
      private bool[] T005H7_n2017UsuMosCBCod ;
      private int[] T005H7_A350UsuMosConcepto ;
      private bool[] T005H7_n350UsuMosConcepto ;
      private int[] T005H4_A2016UsuMosBanCod ;
      private bool[] T005H4_n2016UsuMosBanCod ;
      private int[] T005H5_A2016UsuMosBanCod ;
      private bool[] T005H5_n2016UsuMosBanCod ;
      private int[] T005H8_A2016UsuMosBanCod ;
      private bool[] T005H8_n2016UsuMosBanCod ;
      private int[] T005H9_A2016UsuMosBanCod ;
      private bool[] T005H9_n2016UsuMosBanCod ;
      private string[] T005H10_A2018UsuMosConceptoDsc ;
      private string[] T005H11_A348UsuCod ;
      private string[] T005H3_A348UsuCod ;
      private int[] T005H3_A2026UsuPedMon ;
      private bool[] T005H3_n2026UsuPedMon ;
      private string[] T005H3_A2019UsuNom ;
      private short[] T005H3_A2027UsuPedPrecio ;
      private short[] T005H3_A2023UsuPedDscto ;
      private short[] T005H3_A2028UsuPedStock ;
      private short[] T005H3_A2029UsuPedVend ;
      private short[] T005H3_A2022UsuPedCond ;
      private short[] T005H3_A2024UsuPedList ;
      private int[] T005H3_A2016UsuMosBanCod ;
      private bool[] T005H3_n2016UsuMosBanCod ;
      private string[] T005H3_A2017UsuMosCBCod ;
      private bool[] T005H3_n2017UsuMosCBCod ;
      private int[] T005H3_A350UsuMosConcepto ;
      private bool[] T005H3_n350UsuMosConcepto ;
      private string[] T005H12_A348UsuCod ;
      private string[] T005H13_A348UsuCod ;
      private string[] T005H2_A348UsuCod ;
      private int[] T005H2_A2026UsuPedMon ;
      private bool[] T005H2_n2026UsuPedMon ;
      private string[] T005H2_A2019UsuNom ;
      private short[] T005H2_A2027UsuPedPrecio ;
      private short[] T005H2_A2023UsuPedDscto ;
      private short[] T005H2_A2028UsuPedStock ;
      private short[] T005H2_A2029UsuPedVend ;
      private short[] T005H2_A2022UsuPedCond ;
      private short[] T005H2_A2024UsuPedList ;
      private int[] T005H2_A2016UsuMosBanCod ;
      private bool[] T005H2_n2016UsuMosBanCod ;
      private string[] T005H2_A2017UsuMosCBCod ;
      private bool[] T005H2_n2017UsuMosCBCod ;
      private int[] T005H2_A350UsuMosConcepto ;
      private bool[] T005H2_n350UsuMosConcepto ;
      private string[] T005H17_A2018UsuMosConceptoDsc ;
      private long[] T005H18_A2237SGNotificacionID ;
      private short[] T005H18_A2245SGNotificacionDetID ;
      private long[] T005H19_A2237SGNotificacionID ;
      private string[] T005H20_A348UsuCod ;
      private string[] T005H20_A149TipCod ;
      private string[] T005H20_A351UsuSerDet ;
      private string[] T005H21_A348UsuCod ;
      private int[] T005H21_A346ObjCod ;
      private string[] T005H22_A348UsuCod ;
      private string[] T005H22_A342SGMenuPrograma ;
      private string[] T005H22_A343SGMenuNiv1ID ;
      private string[] T005H23_A348UsuCod ;
      private int[] T005H23_A349UsuAlmCod ;
      private string[] T005H24_A348UsuCod ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] T005H25_A2016UsuMosBanCod ;
      private bool[] T005H25_n2016UsuMosBanCod ;
      private int[] T005H26_A2016UsuMosBanCod ;
      private bool[] T005H26_n2016UsuMosBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29UsuPedMon_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22UsuMosBanCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25UsuMosCBCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13UsuMosConcepto_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class usuariosopciones__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class usuariosopciones__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005H7;
        prmT005H7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H4;
        prmT005H4 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005H5;
        prmT005H5 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005H6;
        prmT005H6 = new Object[] {
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005H8;
        prmT005H8 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005H9;
        prmT005H9 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005H10;
        prmT005H10 = new Object[] {
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005H11;
        prmT005H11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H3;
        prmT005H3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H12;
        prmT005H12 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H13;
        prmT005H13 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H2;
        prmT005H2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H14;
        prmT005H14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuPedMon",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuPedPrecio",GXType.Int16,1,0) ,
        new ParDef("@UsuPedDscto",GXType.Int16,1,0) ,
        new ParDef("@UsuPedStock",GXType.Int16,1,0) ,
        new ParDef("@UsuPedVend",GXType.Int16,1,0) ,
        new ParDef("@UsuPedCond",GXType.Int16,1,0) ,
        new ParDef("@UsuPedList",GXType.Int16,1,0) ,
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005H15;
        prmT005H15 = new Object[] {
        new ParDef("@UsuPedMon",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuPedPrecio",GXType.Int16,1,0) ,
        new ParDef("@UsuPedDscto",GXType.Int16,1,0) ,
        new ParDef("@UsuPedStock",GXType.Int16,1,0) ,
        new ParDef("@UsuPedVend",GXType.Int16,1,0) ,
        new ParDef("@UsuPedCond",GXType.Int16,1,0) ,
        new ParDef("@UsuPedList",GXType.Int16,1,0) ,
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H16;
        prmT005H16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H18;
        prmT005H18 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H19;
        prmT005H19 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H20;
        prmT005H20 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H21;
        prmT005H21 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H22;
        prmT005H22 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H23;
        prmT005H23 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005H24;
        prmT005H24 = new Object[] {
        };
        Object[] prmT005H25;
        prmT005H25 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005H26;
        prmT005H26 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005H17;
        prmT005H17 = new Object[] {
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T005H2", "SELECT [UsuCod], [UsuPedMon], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuMosBanCod] AS UsuMosBanCod, [UsuMosCBCod] AS UsuMosCBCod, [UsuMosConcepto] AS UsuMosConcepto FROM [SGUSUARIOS] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H3", "SELECT [UsuCod], [UsuPedMon], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuMosBanCod] AS UsuMosBanCod, [UsuMosCBCod] AS UsuMosCBCod, [UsuMosConcepto] AS UsuMosConcepto FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H4", "SELECT [BanCod] AS UsuMosBanCod FROM [TSBANCOS] WHERE [BanCod] = @UsuMosBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H5", "SELECT [BanCod] AS UsuMosBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @UsuMosBanCod AND [CBCod] = @UsuMosCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H6", "SELECT [ConBDsc] AS UsuMosConceptoDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @UsuMosConcepto ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H7", "SELECT TM1.[UsuCod], TM1.[UsuPedMon], TM1.[UsuNom], TM1.[UsuPedPrecio], TM1.[UsuPedDscto], TM1.[UsuPedStock], TM1.[UsuPedVend], TM1.[UsuPedCond], TM1.[UsuPedList], T2.[ConBDsc] AS UsuMosConceptoDsc, TM1.[UsuMosBanCod] AS UsuMosBanCod, TM1.[UsuMosCBCod] AS UsuMosCBCod, TM1.[UsuMosConcepto] AS UsuMosConcepto FROM ([SGUSUARIOS] TM1 LEFT JOIN [TSCONCEPTOBANCOS] T2 ON T2.[ConBCod] = TM1.[UsuMosConcepto]) WHERE TM1.[UsuCod] = @UsuCod ORDER BY TM1.[UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005H7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H8", "SELECT [BanCod] AS UsuMosBanCod FROM [TSBANCOS] WHERE [BanCod] = @UsuMosBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H9", "SELECT [BanCod] AS UsuMosBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @UsuMosBanCod AND [CBCod] = @UsuMosCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H10", "SELECT [ConBDsc] AS UsuMosConceptoDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @UsuMosConcepto ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H11", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H12", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] > @UsuCod) ORDER BY [UsuCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005H12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H13", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] < @UsuCod) ORDER BY [UsuCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005H13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H14", "INSERT INTO [SGUSUARIOS]([UsuCod], [UsuPedMon], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuMosBanCod], [UsuMosCBCod], [UsuMosConcepto], [UsuPas], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuVend], [UsuSerie5], [UsuReqADM], [UsuTieCod], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [AreCod], [UsuSRet], [UsuDep], [UsuVendAut]) VALUES(@UsuCod, @UsuPedMon, @UsuNom, @UsuPedPrecio, @UsuPedDscto, @UsuPedStock, @UsuPedVend, @UsuPedCond, @UsuPedList, @UsuMosBanCod, @UsuMosCBCod, @UsuMosConcepto, '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), '', convert(int, 0), '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT005H14)
           ,new CursorDef("T005H15", "UPDATE [SGUSUARIOS] SET [UsuPedMon]=@UsuPedMon, [UsuNom]=@UsuNom, [UsuPedPrecio]=@UsuPedPrecio, [UsuPedDscto]=@UsuPedDscto, [UsuPedStock]=@UsuPedStock, [UsuPedVend]=@UsuPedVend, [UsuPedCond]=@UsuPedCond, [UsuPedList]=@UsuPedList, [UsuMosBanCod]=@UsuMosBanCod, [UsuMosCBCod]=@UsuMosCBCod, [UsuMosConcepto]=@UsuMosConcepto  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT005H15)
           ,new CursorDef("T005H16", "DELETE FROM [SGUSUARIOS]  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT005H16)
           ,new CursorDef("T005H17", "SELECT [ConBDsc] AS UsuMosConceptoDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @UsuMosConcepto ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H18", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionDetUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H19", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H20", "SELECT TOP 1 [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H21", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H22", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H23", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005H24", "SELECT [UsuCod] FROM [SGUSUARIOS] ORDER BY [UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005H24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H25", "SELECT [BanCod] AS UsuMosBanCod FROM [TSBANCOS] WHERE [BanCod] = @UsuMosBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005H26", "SELECT [BanCod] AS UsuMosBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @UsuMosBanCod AND [CBCod] = @UsuMosCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005H26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 100);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 20);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((int[]) buf[14])[0] = rslt.getInt(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 100);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 20);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((int[]) buf[14])[0] = rslt.getInt(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 100);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 100);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((int[]) buf[15])[0] = rslt.getInt(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
