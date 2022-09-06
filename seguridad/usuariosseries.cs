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
   public class usuariosseries : GXWebComponent
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
            {
               A149TipCod = GetPar( "TipCod");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_9( A149TipCod) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_tip") == 0 )
            {
               nRC_GXsfl_24 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_24"), "."));
               nGXsfl_24_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_24_idx"), "."));
               sGXsfl_24_idx = GetPar( "sGXsfl_24_idx");
               sPrefix = GetPar( "sPrefix");
               Gx_mode = GetPar( "Mode");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridlevel_tip_newrow( ) ;
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
         }
         GXKey = Crypto.GetSiteKey( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.usuariosseries.aspx")), "seguridad.usuariosseries.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.usuariosseries.aspx")))) ;
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
               Form.Meta.addItem("description", "Usuarios Series", 0) ;
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
            GX_FocusControl = edtUsuCod_Internalname;
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

      public usuariosseries( )
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

      public usuariosseries( IGxContext context )
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
            RenderHtmlCloseForm5G32( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "seguridad.usuariosseries.aspx");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
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
         GxWebStd.gx_label_ctrl( context, lblTxtcontacmsj_Internalname, "Por favor, confirme primero los datos generales.", "", "", lblTxtcontacmsj_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosSeries.htm");
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
         GxWebStd.gx_div_start( context, divTablacontenido_Internalname, divTablacontenido_Visible, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "left", "top", "", "", "div");
         gxdraw_Gridlevel_tip( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosSeries.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosSeries.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosSeries.htm");
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
         /* User Defined Control */
         ucCombo_tipcod.SetProperty("Caption", Combo_tipcod_Caption);
         ucCombo_tipcod.SetProperty("Cls", Combo_tipcod_Cls);
         ucCombo_tipcod.SetProperty("IsGridItem", Combo_tipcod_Isgriditem);
         ucCombo_tipcod.SetProperty("HasDescription", Combo_tipcod_Hasdescription);
         ucCombo_tipcod.SetProperty("DataListProc", Combo_tipcod_Datalistproc);
         ucCombo_tipcod.SetProperty("DataListProcParametersPrefix", Combo_tipcod_Datalistprocparametersprefix);
         ucCombo_tipcod.SetProperty("EmptyItem", Combo_tipcod_Emptyitem);
         ucCombo_tipcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
         ucCombo_tipcod.SetProperty("DropDownOptionsData", AV11TipCod_Data);
         ucCombo_tipcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipcod_Internalname, sPrefix+"COMBO_TIPCODContainer");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuCod_Visible, edtUsuCod_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\UsuariosSeries.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridlevel_tip( )
      {
         /*  Grid Control  */
         Gridlevel_tipContainer.AddObjectProperty("GridName", "Gridlevel_tip");
         Gridlevel_tipContainer.AddObjectProperty("Header", subGridlevel_tip_Header);
         Gridlevel_tipContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_tipContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridlevel_tipContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_tipColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_tipColumn.AddObjectProperty("Value", StringUtil.RTrim( A149TipCod));
         Gridlevel_tipColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", "")));
         Gridlevel_tipContainer.AddColumnProperties(Gridlevel_tipColumn);
         Gridlevel_tipColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_tipColumn.AddObjectProperty("Value", StringUtil.RTrim( A351UsuSerDet));
         Gridlevel_tipColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", "")));
         Gridlevel_tipContainer.AddColumnProperties(Gridlevel_tipColumn);
         Gridlevel_tipContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Selectedindex), 4, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Allowselection), 1, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Allowhovering), 1, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_tipContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_tip_Collapsed), 1, 0, ".", "")));
         nGXsfl_24_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount34 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_34 = 1;
               ScanStart5G34( ) ;
               while ( RcdFound34 != 0 )
               {
                  init_level_properties34( ) ;
                  getByPrimaryKey5G34( ) ;
                  AddRow5G34( ) ;
                  ScanNext5G34( ) ;
               }
               ScanEnd5G34( ) ;
               nBlankRcdCount34 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal5G34( ) ;
            standaloneModal5G34( ) ;
            sMode34 = Gx_mode;
            while ( nGXsfl_24_idx < nRC_GXsfl_24 )
            {
               bGXsfl_24_Refreshing = true;
               ReadRow5G34( ) ;
               edtTipCod_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TIPCOD_"+sGXsfl_24_idx+"Enabled"), ".", ","));
               AssignProp(sPrefix, false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_24_Refreshing);
               edtUsuSerDet_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"USUSERDET_"+sGXsfl_24_idx+"Enabled"), ".", ","));
               AssignProp(sPrefix, false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_24_Refreshing);
               if ( ( nRcdExists_34 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  standaloneModal5G34( ) ;
               }
               SendRow5G34( ) ;
               bGXsfl_24_Refreshing = false;
            }
            Gx_mode = sMode34;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount34 = 5;
            nRcdExists_34 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart5G34( ) ;
               while ( RcdFound34 != 0 )
               {
                  sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_2434( ) ;
                  init_level_properties34( ) ;
                  standaloneNotModal5G34( ) ;
                  getByPrimaryKey5G34( ) ;
                  standaloneModal5G34( ) ;
                  AddRow5G34( ) ;
                  ScanNext5G34( ) ;
               }
               ScanEnd5G34( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode34 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx+1), 4, 0), 4, "0");
            SubsflControlProps_2434( ) ;
            InitAll5G34( ) ;
            init_level_properties34( ) ;
            nRcdExists_34 = 0;
            nIsMod_34 = 0;
            nRcdDeleted_34 = 0;
            nBlankRcdCount34 = (short)(nBlankRcdUsr34+nBlankRcdCount34);
            fRowAdded = 0;
            while ( nBlankRcdCount34 > 0 )
            {
               standaloneNotModal5G34( ) ;
               standaloneModal5G34( ) ;
               AddRow5G34( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount34 = (short)(nBlankRcdCount34-1);
            }
            Gx_mode = sMode34;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+sPrefix+"Gridlevel_tipContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridlevel_tip", Gridlevel_tipContainer);
         if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_tipContainerData", Gridlevel_tipContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_tipContainerData"+"V", Gridlevel_tipContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridlevel_tipContainerData"+"V"+"\" value='"+Gridlevel_tipContainer.GridValuesHidden()+"'/>") ;
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
         E115G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vTIPCOD_DATA"), AV11TipCod_Data);
               /* Read saved values. */
               Z348UsuCod = cgiGet( sPrefix+"Z348UsuCod");
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7UsuCod = cgiGet( sPrefix+"wcpOAV7UsuCod");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               nRC_GXsfl_24 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_24"), ".", ","));
               AV7UsuCod = cgiGet( sPrefix+"vUSUCOD");
               Combo_tipcod_Objectcall = cgiGet( sPrefix+"COMBO_TIPCOD_Objectcall");
               Combo_tipcod_Class = cgiGet( sPrefix+"COMBO_TIPCOD_Class");
               Combo_tipcod_Icontype = cgiGet( sPrefix+"COMBO_TIPCOD_Icontype");
               Combo_tipcod_Icon = cgiGet( sPrefix+"COMBO_TIPCOD_Icon");
               Combo_tipcod_Caption = cgiGet( sPrefix+"COMBO_TIPCOD_Caption");
               Combo_tipcod_Tooltip = cgiGet( sPrefix+"COMBO_TIPCOD_Tooltip");
               Combo_tipcod_Cls = cgiGet( sPrefix+"COMBO_TIPCOD_Cls");
               Combo_tipcod_Selectedvalue_set = cgiGet( sPrefix+"COMBO_TIPCOD_Selectedvalue_set");
               Combo_tipcod_Selectedvalue_get = cgiGet( sPrefix+"COMBO_TIPCOD_Selectedvalue_get");
               Combo_tipcod_Selectedtext_set = cgiGet( sPrefix+"COMBO_TIPCOD_Selectedtext_set");
               Combo_tipcod_Selectedtext_get = cgiGet( sPrefix+"COMBO_TIPCOD_Selectedtext_get");
               Combo_tipcod_Gamoauthtoken = cgiGet( sPrefix+"COMBO_TIPCOD_Gamoauthtoken");
               Combo_tipcod_Ddointernalname = cgiGet( sPrefix+"COMBO_TIPCOD_Ddointernalname");
               Combo_tipcod_Titlecontrolalign = cgiGet( sPrefix+"COMBO_TIPCOD_Titlecontrolalign");
               Combo_tipcod_Dropdownoptionstype = cgiGet( sPrefix+"COMBO_TIPCOD_Dropdownoptionstype");
               Combo_tipcod_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Enabled"));
               Combo_tipcod_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Visible"));
               Combo_tipcod_Titlecontrolidtoreplace = cgiGet( sPrefix+"COMBO_TIPCOD_Titlecontrolidtoreplace");
               Combo_tipcod_Datalisttype = cgiGet( sPrefix+"COMBO_TIPCOD_Datalisttype");
               Combo_tipcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Allowmultipleselection"));
               Combo_tipcod_Datalistfixedvalues = cgiGet( sPrefix+"COMBO_TIPCOD_Datalistfixedvalues");
               Combo_tipcod_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Isgriditem"));
               Combo_tipcod_Hasdescription = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Hasdescription"));
               Combo_tipcod_Datalistproc = cgiGet( sPrefix+"COMBO_TIPCOD_Datalistproc");
               Combo_tipcod_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_TIPCOD_Datalistprocparametersprefix");
               Combo_tipcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_TIPCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tipcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Includeonlyselectedoption"));
               Combo_tipcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Includeselectalloption"));
               Combo_tipcod_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Emptyitem"));
               Combo_tipcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_TIPCOD_Includeaddnewoption"));
               Combo_tipcod_Htmltemplate = cgiGet( sPrefix+"COMBO_TIPCOD_Htmltemplate");
               Combo_tipcod_Multiplevaluestype = cgiGet( sPrefix+"COMBO_TIPCOD_Multiplevaluestype");
               Combo_tipcod_Loadingdata = cgiGet( sPrefix+"COMBO_TIPCOD_Loadingdata");
               Combo_tipcod_Noresultsfound = cgiGet( sPrefix+"COMBO_TIPCOD_Noresultsfound");
               Combo_tipcod_Emptyitemtext = cgiGet( sPrefix+"COMBO_TIPCOD_Emptyitemtext");
               Combo_tipcod_Onlyselectedvalues = cgiGet( sPrefix+"COMBO_TIPCOD_Onlyselectedvalues");
               Combo_tipcod_Selectalltext = cgiGet( sPrefix+"COMBO_TIPCOD_Selectalltext");
               Combo_tipcod_Multiplevaluesseparator = cgiGet( sPrefix+"COMBO_TIPCOD_Multiplevaluesseparator");
               Combo_tipcod_Addnewoptiontext = cgiGet( sPrefix+"COMBO_TIPCOD_Addnewoptiontext");
               Combo_tipcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"COMBO_TIPCOD_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A348UsuCod = cgiGet( edtUsuCod_Internalname);
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuariosSeries");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\usuariosseries:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                           CONFIRM_5G0( ) ;
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
                                 E115G2 ();
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
                                 E125G2 ();
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
            E125G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5G32( ) ;
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
            DisableAttributes5G32( ) ;
         }
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

      protected void CONFIRM_5G0( )
      {
         BeforeValidate5G32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5G32( ) ;
            }
            else
            {
               CheckExtendedTable5G32( ) ;
               CloseExtendedTableCursors5G32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode32 = Gx_mode;
            CONFIRM_5G34( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode32;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode32;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_5G34( )
      {
         nGXsfl_24_idx = 0;
         while ( nGXsfl_24_idx < nRC_GXsfl_24 )
         {
            ReadRow5G34( ) ;
            if ( ( nRcdExists_34 != 0 ) || ( nIsMod_34 != 0 ) )
            {
               GetKey5G34( ) ;
               if ( ( nRcdExists_34 == 0 ) && ( nRcdDeleted_34 == 0 ) )
               {
                  if ( RcdFound34 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     BeforeValidate5G34( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable5G34( ) ;
                        CloseExtendedTableCursors5G34( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "TIPCOD_" + sGXsfl_24_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound34 != 0 )
                  {
                     if ( nRcdDeleted_34 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        getByPrimaryKey5G34( ) ;
                        Load5G34( ) ;
                        BeforeValidate5G34( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls5G34( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_34 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           BeforeValidate5G34( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable5G34( ) ;
                              CloseExtendedTableCursors5G34( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_34 == 0 )
                     {
                        GXCCtl = "TIPCOD_" + sGXsfl_24_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtTipCod_Internalname, StringUtil.RTrim( A149TipCod)) ;
            ChangePostValue( sPrefix+edtUsuSerDet_Internalname, StringUtil.RTrim( A351UsuSerDet)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z149TipCod_"+sGXsfl_24_idx, StringUtil.RTrim( Z149TipCod)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z351UsuSerDet_"+sGXsfl_24_idx, StringUtil.RTrim( Z351UsuSerDet)) ;
            ChangePostValue( sPrefix+"nRcdDeleted_34_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_34), 4, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_34_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_34), 4, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_34_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_34), 4, 0, ".", ""))) ;
            if ( nIsMod_34 != 0 )
            {
               ChangePostValue( sPrefix+"TIPCOD_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"USUSERDET_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption5G0( )
      {
      }

      protected void E115G2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Combo_tipcod_Titlecontrolidtoreplace = edtTipCod_Internalname;
         ucCombo_tipcod.SendProperty(context, sPrefix, false, Combo_tipcod_Internalname, "TitleControlIdToReplace", Combo_tipcod_Titlecontrolidtoreplace);
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtUsuCod_Visible = 0;
         AssignProp(sPrefix, false, edtUsuCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuCod_Visible), 5, 0), true);
      }

      protected void E125G2( )
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

      protected void ZM5G32( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -7 )
         {
            Z348UsuCod = A348UsuCod;
         }
      }

      protected void standaloneNotModal( )
      {
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
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load5G32( )
      {
         /* Using cursor T005G7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
            ZM5G32( -7) ;
         }
         pr_default.close(5);
         OnLoadActions5G32( ) ;
      }

      protected void OnLoadActions5G32( )
      {
      }

      protected void CheckExtendedTable5G32( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors5G32( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5G32( )
      {
         /* Using cursor T005G8 */
         pr_default.execute(6, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005G6 */
         pr_default.execute(4, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM5G32( 7) ;
            RcdFound32 = 1;
            A348UsuCod = T005G6_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            Z348UsuCod = A348UsuCod;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load5G32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey5G32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey5G32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey5G32( ) ;
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
         /* Using cursor T005G9 */
         pr_default.execute(7, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T005G9_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T005G9_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               A348UsuCod = T005G9_A348UsuCod[0];
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T005G10 */
         pr_default.execute(8, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T005G10_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T005G10_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               A348UsuCod = T005G10_A348UsuCod[0];
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5G32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert5G32( ) ;
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
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5G32( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert5G32( ) ;
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
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert5G32( ) ;
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
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5G32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005G5 */
            pr_default.execute(3, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5G32( )
      {
         BeforeValidate5G32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5G32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5G32( 0) ;
            CheckOptimisticConcurrency5G32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5G32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5G32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005G11 */
                     pr_default.execute(9, new Object[] {A348UsuCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel5G32( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption5G0( ) ;
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
               Load5G32( ) ;
            }
            EndLevel5G32( ) ;
         }
         CloseExtendedTableCursors5G32( ) ;
      }

      protected void Update5G32( )
      {
         BeforeValidate5G32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5G32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5G32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5G32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5G32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [SGUSUARIOS] */
                     DeferredUpdate5G32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel5G32( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel5G32( ) ;
         }
         CloseExtendedTableCursors5G32( ) ;
      }

      protected void DeferredUpdate5G32( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5G32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5G32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5G32( ) ;
            AfterConfirm5G32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5G32( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart5G34( ) ;
                  while ( RcdFound34 != 0 )
                  {
                     getByPrimaryKey5G34( ) ;
                     Delete5G34( ) ;
                     ScanNext5G34( ) ;
                  }
                  ScanEnd5G34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005G12 */
                     pr_default.execute(10, new Object[] {A348UsuCod});
                     pr_default.close(10);
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
         }
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel5G32( ) ;
         Gx_mode = sMode32;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5G32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005G13 */
            pr_default.execute(11, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005G14 */
            pr_default.execute(12, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005G15 */
            pr_default.execute(13, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005G16 */
            pr_default.execute(14, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005G17 */
            pr_default.execute(15, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel5G34( )
      {
         nGXsfl_24_idx = 0;
         while ( nGXsfl_24_idx < nRC_GXsfl_24 )
         {
            ReadRow5G34( ) ;
            if ( ( nRcdExists_34 != 0 ) || ( nIsMod_34 != 0 ) )
            {
               standaloneNotModal5G34( ) ;
               GetKey5G34( ) ;
               if ( ( nRcdExists_34 == 0 ) && ( nRcdDeleted_34 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  Insert5G34( ) ;
               }
               else
               {
                  if ( RcdFound34 != 0 )
                  {
                     if ( ( nRcdDeleted_34 != 0 ) && ( nRcdExists_34 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        Delete5G34( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_34 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           Update5G34( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_34 == 0 )
                     {
                        GXCCtl = "TIPCOD_" + sGXsfl_24_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtTipCod_Internalname, StringUtil.RTrim( A149TipCod)) ;
            ChangePostValue( sPrefix+edtUsuSerDet_Internalname, StringUtil.RTrim( A351UsuSerDet)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z149TipCod_"+sGXsfl_24_idx, StringUtil.RTrim( Z149TipCod)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z351UsuSerDet_"+sGXsfl_24_idx, StringUtil.RTrim( Z351UsuSerDet)) ;
            ChangePostValue( sPrefix+"nRcdDeleted_34_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_34), 4, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_34_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_34), 4, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_34_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_34), 4, 0, ".", ""))) ;
            if ( nIsMod_34 != 0 )
            {
               ChangePostValue( sPrefix+"TIPCOD_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"USUSERDET_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll5G34( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_34 = 0;
         nIsMod_34 = 0;
         nRcdDeleted_34 = 0;
      }

      protected void ProcessLevel5G32( )
      {
         /* Save parent mode. */
         sMode32 = Gx_mode;
         ProcessNestedLevel5G34( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode32;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel5G32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5G32( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("seguridad.usuariosseries",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5G0( ) ;
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
            context.RollbackDataStores("seguridad.usuariosseries",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5G32( )
      {
         /* Scan By routine */
         /* Using cursor T005G18 */
         pr_default.execute(16);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T005G18_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5G32( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T005G18_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         }
      }

      protected void ScanEnd5G32( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm5G32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5G32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5G32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5G32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5G32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5G32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5G32( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
      }

      protected void ZM5G34( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -8 )
         {
            Z348UsuCod = A348UsuCod;
            Z351UsuSerDet = A351UsuSerDet;
            Z149TipCod = A149TipCod;
         }
      }

      protected void standaloneNotModal5G34( )
      {
      }

      protected void standaloneModal5G34( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtTipCod_Enabled = 0;
            AssignProp(sPrefix, false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         }
         else
         {
            edtTipCod_Enabled = 1;
            AssignProp(sPrefix, false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtUsuSerDet_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         }
         else
         {
            edtUsuSerDet_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         }
      }

      protected void Load5G34( )
      {
         /* Using cursor T005G19 */
         pr_default.execute(17, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound34 = 1;
            ZM5G34( -8) ;
         }
         pr_default.close(17);
         OnLoadActions5G34( ) ;
      }

      protected void OnLoadActions5G34( )
      {
      }

      protected void CheckExtendedTable5G34( )
      {
         nIsDirty_34 = 0;
         Gx_BScreen = 1;
         standaloneModal5G34( ) ;
         /* Using cursor T005G4 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "TIPCOD_" + sGXsfl_24_idx;
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A351UsuSerDet)) )
         {
            GXCCtl = "USUSERDET_" + sGXsfl_24_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Serie", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuSerDet_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5G34( )
      {
         pr_default.close(2);
      }

      protected void enableDisable5G34( )
      {
      }

      protected void gxLoad_9( string A149TipCod )
      {
         /* Using cursor T005G20 */
         pr_default.execute(18, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "TIPCOD_" + sGXsfl_24_idx;
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey5G34( )
      {
         /* Using cursor T005G21 */
         pr_default.execute(19, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey5G34( )
      {
         /* Using cursor T005G3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5G34( 8) ;
            RcdFound34 = 1;
            InitializeNonKey5G34( ) ;
            A351UsuSerDet = T005G3_A351UsuSerDet[0];
            A149TipCod = T005G3_A149TipCod[0];
            Z348UsuCod = A348UsuCod;
            Z149TipCod = A149TipCod;
            Z351UsuSerDet = A351UsuSerDet;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load5G34( ) ;
            Gx_mode = sMode34;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey5G34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal5G34( ) ;
            Gx_mode = sMode34;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes5G34( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency5G34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005G2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOSSERIES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOSSERIES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5G34( )
      {
         BeforeValidate5G34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5G34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5G34( 0) ;
            CheckOptimisticConcurrency5G34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5G34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5G34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005G22 */
                     pr_default.execute(20, new Object[] {A348UsuCod, A351UsuSerDet, A149TipCod});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSSERIES");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load5G34( ) ;
            }
            EndLevel5G34( ) ;
         }
         CloseExtendedTableCursors5G34( ) ;
      }

      protected void Update5G34( )
      {
         BeforeValidate5G34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5G34( ) ;
         }
         if ( ( nIsMod_34 != 0 ) || ( nIsDirty_34 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency5G34( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm5G34( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate5G34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [SGUSUARIOSSERIES] */
                        DeferredUpdate5G34( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey5G34( ) ;
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
               EndLevel5G34( ) ;
            }
         }
         CloseExtendedTableCursors5G34( ) ;
      }

      protected void DeferredUpdate5G34( )
      {
      }

      protected void Delete5G34( )
      {
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate5G34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5G34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5G34( ) ;
            AfterConfirm5G34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5G34( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005G23 */
                  pr_default.execute(21, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
                  pr_default.close(21);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSSERIES");
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel5G34( ) ;
         Gx_mode = sMode34;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5G34( )
      {
         standaloneModal5G34( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel5G34( )
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

      public void ScanStart5G34( )
      {
         /* Scan By routine */
         /* Using cursor T005G24 */
         pr_default.execute(22, new Object[] {A348UsuCod});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound34 = 1;
            A149TipCod = T005G24_A149TipCod[0];
            A351UsuSerDet = T005G24_A351UsuSerDet[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5G34( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound34 = 1;
            A149TipCod = T005G24_A149TipCod[0];
            A351UsuSerDet = T005G24_A351UsuSerDet[0];
         }
      }

      protected void ScanEnd5G34( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm5G34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5G34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5G34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5G34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5G34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5G34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5G34( )
      {
         edtTipCod_Enabled = 0;
         AssignProp(sPrefix, false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtUsuSerDet_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_24_Refreshing);
      }

      protected void send_integrity_lvl_hashes5G34( )
      {
      }

      protected void send_integrity_lvl_hashes5G32( )
      {
      }

      protected void SubsflControlProps_2434( )
      {
         edtTipCod_Internalname = sPrefix+"TIPCOD_"+sGXsfl_24_idx;
         edtUsuSerDet_Internalname = sPrefix+"USUSERDET_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_2434( )
      {
         edtTipCod_Internalname = sPrefix+"TIPCOD_"+sGXsfl_24_fel_idx;
         edtUsuSerDet_Internalname = sPrefix+"USUSERDET_"+sGXsfl_24_fel_idx;
      }

      protected void AddRow5G34( )
      {
         nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_2434( ) ;
         SendRow5G34( ) ;
      }

      protected void SendRow5G34( )
      {
         Gridlevel_tipRow = GXWebRow.GetNew(context);
         if ( subGridlevel_tip_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_tip_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_tip_Class, "") != 0 )
            {
               subGridlevel_tip_Linesclass = subGridlevel_tip_Class+"Odd";
            }
         }
         else if ( subGridlevel_tip_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_tip_Backstyle = 0;
            subGridlevel_tip_Backcolor = subGridlevel_tip_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_tip_Class, "") != 0 )
            {
               subGridlevel_tip_Linesclass = subGridlevel_tip_Class+"Uniform";
            }
         }
         else if ( subGridlevel_tip_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_tip_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_tip_Class, "") != 0 )
            {
               subGridlevel_tip_Linesclass = subGridlevel_tip_Class+"Odd";
            }
            subGridlevel_tip_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_tip_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_tip_Backstyle = 1;
            if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
            {
               subGridlevel_tip_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_tip_Class, "") != 0 )
               {
                  subGridlevel_tip_Linesclass = subGridlevel_tip_Class+"Even";
               }
            }
            else
            {
               subGridlevel_tip_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_tip_Class, "") != 0 )
               {
                  subGridlevel_tip_Linesclass = subGridlevel_tip_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_34_" + sGXsfl_24_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_24_idx + "',24)\"";
         ROClassString = "Attribute";
         Gridlevel_tipRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCod_Internalname,StringUtil.RTrim( A149TipCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtTipCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_34_" + sGXsfl_24_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_24_idx + "',24)\"";
         ROClassString = "Attribute";
         Gridlevel_tipRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuSerDet_Internalname,StringUtil.RTrim( A351UsuSerDet),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuSerDet_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtUsuSerDet_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_tipRow);
         send_integrity_lvl_hashes5G34( ) ;
         GXCCtl = "Z149TipCod_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Z149TipCod));
         GXCCtl = "Z351UsuSerDet_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Z351UsuSerDet));
         GXCCtl = "nRcdDeleted_34_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_34), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_34_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_34), 4, 0, ".", "")));
         GXCCtl = "nIsMod_34_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_34), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vUSUCOD_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( AV7UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPCOD_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUSERDET_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_tipContainer.AddRow(Gridlevel_tipRow);
      }

      protected void ReadRow5G34( )
      {
         nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_2434( ) ;
         edtTipCod_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TIPCOD_"+sGXsfl_24_idx+"Enabled"), ".", ","));
         edtUsuSerDet_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"USUSERDET_"+sGXsfl_24_idx+"Enabled"), ".", ","));
         A149TipCod = cgiGet( edtTipCod_Internalname);
         A351UsuSerDet = cgiGet( edtUsuSerDet_Internalname);
         GXCCtl = "Z149TipCod_" + sGXsfl_24_idx;
         Z149TipCod = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "Z351UsuSerDet_" + sGXsfl_24_idx;
         Z351UsuSerDet = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "nRcdDeleted_34_" + sGXsfl_24_idx;
         nRcdDeleted_34 = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_34_" + sGXsfl_24_idx;
         nRcdExists_34 = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ".", ","));
         GXCCtl = "nIsMod_34_" + sGXsfl_24_idx;
         nIsMod_34 = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtUsuSerDet_Enabled = edtUsuSerDet_Enabled;
         defedtTipCod_Enabled = edtTipCod_Enabled;
      }

      protected void ConfirmValues5G0( )
      {
         nGXsfl_24_idx = 0;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_2434( ) ;
         while ( nGXsfl_24_idx < nRC_GXsfl_24 )
         {
            nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_2434( ) ;
            ChangePostValue( sPrefix+"Z149TipCod_"+sGXsfl_24_idx, cgiGet( sPrefix+"ZT_"+"Z149TipCod_"+sGXsfl_24_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z149TipCod_"+sGXsfl_24_idx) ;
            ChangePostValue( sPrefix+"Z351UsuSerDet_"+sGXsfl_24_idx, cgiGet( sPrefix+"ZT_"+"Z351UsuSerDet_"+sGXsfl_24_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z351UsuSerDet_"+sGXsfl_24_idx) ;
         }
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
            context.SendWebValue( "Usuarios Series") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281811383576", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            GXEncryptionTmp = "seguridad.usuariosseries.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7UsuCod));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.usuariosseries.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuariosSeries");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\usuariosseries:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7UsuCod", StringUtil.RTrim( wcpOAV7UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_24_idx), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTIPCOD_DATA", AV11TipCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTIPCOD_DATA", AV11TipCod_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUCOD", StringUtil.RTrim( AV7UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Objectcall", StringUtil.RTrim( Combo_tipcod_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Cls", StringUtil.RTrim( Combo_tipcod_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Enabled", StringUtil.BoolToStr( Combo_tipcod_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_tipcod_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Isgriditem", StringUtil.BoolToStr( Combo_tipcod_Isgriditem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Hasdescription", StringUtil.BoolToStr( Combo_tipcod_Hasdescription));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Datalistproc", StringUtil.RTrim( Combo_tipcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_TIPCOD_Emptyitem", StringUtil.BoolToStr( Combo_tipcod_Emptyitem));
      }

      protected void RenderHtmlCloseForm5G32( )
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
         return "Seguridad.UsuariosSeries" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios Series" ;
      }

      protected void InitializeNonKey5G32( )
      {
      }

      protected void InitAll5G32( )
      {
         A348UsuCod = "";
         AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         InitializeNonKey5G32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey5G34( )
      {
      }

      protected void InitAll5G34( )
      {
         A149TipCod = "";
         A351UsuSerDet = "";
         InitializeNonKey5G34( ) ;
      }

      protected void StandaloneModalInsert5G34( )
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
         AddComponentObject(sPrefix, "seguridad\\usuariosseries", GetJustCreated( ));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181138360", true, true);
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
         context.AddJavascriptSource("seguridad/usuariosseries.js", "?20228181138361", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties34( )
      {
         edtUsuSerDet_Enabled = defedtUsuSerDet_Enabled;
         AssignProp(sPrefix, false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtTipCod_Enabled = defedtTipCod_Enabled;
         AssignProp(sPrefix, false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_24_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTxtcontacmsj_Internalname = sPrefix+"TXTCONTACMSJ";
         divTablamensaje_Internalname = sPrefix+"TABLAMENSAJE";
         edtTipCod_Internalname = sPrefix+"TIPCOD";
         edtUsuSerDet_Internalname = sPrefix+"USUSERDET";
         divTablacontenido_Internalname = sPrefix+"TABLACONTENIDO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Combo_tipcod_Internalname = sPrefix+"COMBO_TIPCOD";
         edtUsuCod_Internalname = sPrefix+"USUCOD";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridlevel_tip_Internalname = sPrefix+"GRIDLEVEL_TIP";
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
         Combo_tipcod_Enabled = Convert.ToBoolean( -1);
         edtUsuSerDet_Jsonclick = "";
         edtTipCod_Jsonclick = "";
         subGridlevel_tip_Class = "WorkWith";
         subGridlevel_tip_Backcolorstyle = 0;
         Combo_tipcod_Titlecontrolidtoreplace = "";
         subGridlevel_tip_Allowcollapsing = 0;
         subGridlevel_tip_Allowselection = 0;
         edtUsuSerDet_Enabled = 1;
         edtTipCod_Enabled = 1;
         subGridlevel_tip_Header = "";
         edtUsuCod_Jsonclick = "";
         edtUsuCod_Enabled = 1;
         edtUsuCod_Visible = 1;
         Combo_tipcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipcod_Datalistprocparametersprefix = " \"ComboName\": \"TipCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\"";
         Combo_tipcod_Datalistproc = "Seguridad.UsuariosSeriesLoadDVCombo";
         Combo_tipcod_Hasdescription = Convert.ToBoolean( -1);
         Combo_tipcod_Isgriditem = Convert.ToBoolean( -1);
         Combo_tipcod_Cls = "ExtendedCombo";
         Combo_tipcod_Caption = "";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
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

      protected void gxnrGridlevel_tip_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         SubsflControlProps_2434( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal5G34( ) ;
            standaloneModal5G34( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow5G34( ) ;
            nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_2434( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_tipContainer)) ;
         /* End function gxnrGridlevel_tip_newrow */
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

      public void Valid_Tipcod( )
      {
         /* Using cursor T005G25 */
         pr_default.execute(23, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7UsuCod',fld:'vUSUCOD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125G2',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[]");
         setEventMetadata("VALID_USUCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_USUSERDET","{handler:'Valid_Ususerdet',iparms:[]");
         setEventMetadata("VALID_USUSERDET",",oparms:[]}");
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
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7UsuCod = "";
         Z348UsuCod = "";
         Z149TipCod = "";
         Z351UsuSerDet = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A149TipCod = "";
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
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_tipcod = new GXUserControl();
         AV12DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TipCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A348UsuCod = "";
         Gridlevel_tipContainer = new GXWebGrid( context);
         Gridlevel_tipColumn = new GXWebColumn();
         A351UsuSerDet = "";
         sMode34 = "";
         sStyleString = "";
         Combo_tipcod_Objectcall = "";
         Combo_tipcod_Class = "";
         Combo_tipcod_Icontype = "";
         Combo_tipcod_Icon = "";
         Combo_tipcod_Tooltip = "";
         Combo_tipcod_Selectedvalue_set = "";
         Combo_tipcod_Selectedvalue_get = "";
         Combo_tipcod_Selectedtext_set = "";
         Combo_tipcod_Selectedtext_get = "";
         Combo_tipcod_Gamoauthtoken = "";
         Combo_tipcod_Ddointernalname = "";
         Combo_tipcod_Titlecontrolalign = "";
         Combo_tipcod_Dropdownoptionstype = "";
         Combo_tipcod_Datalisttype = "";
         Combo_tipcod_Datalistfixedvalues = "";
         Combo_tipcod_Htmltemplate = "";
         Combo_tipcod_Multiplevaluestype = "";
         Combo_tipcod_Loadingdata = "";
         Combo_tipcod_Noresultsfound = "";
         Combo_tipcod_Emptyitemtext = "";
         Combo_tipcod_Onlyselectedvalues = "";
         Combo_tipcod_Selectalltext = "";
         Combo_tipcod_Multiplevaluesseparator = "";
         Combo_tipcod_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode32 = "";
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
         T005G7_A348UsuCod = new string[] {""} ;
         T005G8_A348UsuCod = new string[] {""} ;
         T005G6_A348UsuCod = new string[] {""} ;
         T005G9_A348UsuCod = new string[] {""} ;
         T005G10_A348UsuCod = new string[] {""} ;
         T005G5_A348UsuCod = new string[] {""} ;
         T005G13_A2237SGNotificacionID = new long[1] ;
         T005G13_A2245SGNotificacionDetID = new short[1] ;
         T005G14_A2237SGNotificacionID = new long[1] ;
         T005G15_A348UsuCod = new string[] {""} ;
         T005G15_A346ObjCod = new int[1] ;
         T005G16_A348UsuCod = new string[] {""} ;
         T005G16_A342SGMenuPrograma = new string[] {""} ;
         T005G16_A343SGMenuNiv1ID = new string[] {""} ;
         T005G17_A348UsuCod = new string[] {""} ;
         T005G17_A349UsuAlmCod = new int[1] ;
         T005G18_A348UsuCod = new string[] {""} ;
         T005G19_A348UsuCod = new string[] {""} ;
         T005G19_A351UsuSerDet = new string[] {""} ;
         T005G19_A149TipCod = new string[] {""} ;
         T005G4_A149TipCod = new string[] {""} ;
         T005G20_A149TipCod = new string[] {""} ;
         T005G21_A348UsuCod = new string[] {""} ;
         T005G21_A149TipCod = new string[] {""} ;
         T005G21_A351UsuSerDet = new string[] {""} ;
         T005G3_A348UsuCod = new string[] {""} ;
         T005G3_A351UsuSerDet = new string[] {""} ;
         T005G3_A149TipCod = new string[] {""} ;
         T005G2_A348UsuCod = new string[] {""} ;
         T005G2_A351UsuSerDet = new string[] {""} ;
         T005G2_A149TipCod = new string[] {""} ;
         T005G24_A348UsuCod = new string[] {""} ;
         T005G24_A149TipCod = new string[] {""} ;
         T005G24_A351UsuSerDet = new string[] {""} ;
         Gridlevel_tipRow = new GXWebRow();
         subGridlevel_tip_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         sCtrlGx_mode = "";
         sCtrlAV7UsuCod = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         T005G25_A149TipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosseries__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosseries__default(),
            new Object[][] {
                new Object[] {
               T005G2_A348UsuCod, T005G2_A351UsuSerDet, T005G2_A149TipCod
               }
               , new Object[] {
               T005G3_A348UsuCod, T005G3_A351UsuSerDet, T005G3_A149TipCod
               }
               , new Object[] {
               T005G4_A149TipCod
               }
               , new Object[] {
               T005G5_A348UsuCod
               }
               , new Object[] {
               T005G6_A348UsuCod
               }
               , new Object[] {
               T005G7_A348UsuCod
               }
               , new Object[] {
               T005G8_A348UsuCod
               }
               , new Object[] {
               T005G9_A348UsuCod
               }
               , new Object[] {
               T005G10_A348UsuCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005G13_A2237SGNotificacionID, T005G13_A2245SGNotificacionDetID
               }
               , new Object[] {
               T005G14_A2237SGNotificacionID
               }
               , new Object[] {
               T005G15_A348UsuCod, T005G15_A346ObjCod
               }
               , new Object[] {
               T005G16_A348UsuCod, T005G16_A342SGMenuPrograma, T005G16_A343SGMenuNiv1ID
               }
               , new Object[] {
               T005G17_A348UsuCod, T005G17_A349UsuAlmCod
               }
               , new Object[] {
               T005G18_A348UsuCod
               }
               , new Object[] {
               T005G19_A348UsuCod, T005G19_A351UsuSerDet, T005G19_A149TipCod
               }
               , new Object[] {
               T005G20_A149TipCod
               }
               , new Object[] {
               T005G21_A348UsuCod, T005G21_A149TipCod, T005G21_A351UsuSerDet
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005G24_A348UsuCod, T005G24_A149TipCod, T005G24_A351UsuSerDet
               }
               , new Object[] {
               T005G25_A149TipCod
               }
            }
         );
      }

      private short nRcdDeleted_34 ;
      private short nRcdExists_34 ;
      private short nIsMod_34 ;
      private short GxWebError ;
      private short nDynComponent ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridlevel_tip_Backcolorstyle ;
      private short subGridlevel_tip_Allowselection ;
      private short subGridlevel_tip_Allowhovering ;
      private short subGridlevel_tip_Allowcollapsing ;
      private short subGridlevel_tip_Collapsed ;
      private short nBlankRcdCount34 ;
      private short RcdFound34 ;
      private short nBlankRcdUsr34 ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound32 ;
      private short GX_JID ;
      private short nIsDirty_32 ;
      private short Gx_BScreen ;
      private short nIsDirty_34 ;
      private short subGridlevel_tip_Backstyle ;
      private int nRC_GXsfl_24 ;
      private int nGXsfl_24_idx=1 ;
      private int trnEnded ;
      private int divTablamensaje_Visible ;
      private int divTablacontenido_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtUsuCod_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtTipCod_Enabled ;
      private int edtUsuSerDet_Enabled ;
      private int subGridlevel_tip_Selectedindex ;
      private int subGridlevel_tip_Selectioncolor ;
      private int subGridlevel_tip_Hoveringcolor ;
      private int fRowAdded ;
      private int Combo_tipcod_Datalistupdateminimumcharacters ;
      private int Combo_tipcod_Gxcontroltype ;
      private int subGridlevel_tip_Backcolor ;
      private int subGridlevel_tip_Allbackcolor ;
      private int defedtUsuSerDet_Enabled ;
      private int defedtTipCod_Enabled ;
      private int idxLst ;
      private long GRIDLEVEL_TIP_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7UsuCod ;
      private string Z348UsuCod ;
      private string Z149TipCod ;
      private string Z351UsuSerDet ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string AV7UsuCod ;
      private string A149TipCod ;
      private string sGXsfl_24_idx="0001" ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtUsuCod_Internalname ;
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
      private string TempTags ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_tipcod_Caption ;
      private string Combo_tipcod_Cls ;
      private string Combo_tipcod_Datalistproc ;
      private string Combo_tipcod_Datalistprocparametersprefix ;
      private string Combo_tipcod_Internalname ;
      private string A348UsuCod ;
      private string edtUsuCod_Jsonclick ;
      private string subGridlevel_tip_Header ;
      private string A351UsuSerDet ;
      private string sMode34 ;
      private string edtTipCod_Internalname ;
      private string edtUsuSerDet_Internalname ;
      private string sStyleString ;
      private string Combo_tipcod_Objectcall ;
      private string Combo_tipcod_Class ;
      private string Combo_tipcod_Icontype ;
      private string Combo_tipcod_Icon ;
      private string Combo_tipcod_Tooltip ;
      private string Combo_tipcod_Selectedvalue_set ;
      private string Combo_tipcod_Selectedvalue_get ;
      private string Combo_tipcod_Selectedtext_set ;
      private string Combo_tipcod_Selectedtext_get ;
      private string Combo_tipcod_Gamoauthtoken ;
      private string Combo_tipcod_Ddointernalname ;
      private string Combo_tipcod_Titlecontrolalign ;
      private string Combo_tipcod_Dropdownoptionstype ;
      private string Combo_tipcod_Titlecontrolidtoreplace ;
      private string Combo_tipcod_Datalisttype ;
      private string Combo_tipcod_Datalistfixedvalues ;
      private string Combo_tipcod_Htmltemplate ;
      private string Combo_tipcod_Multiplevaluestype ;
      private string Combo_tipcod_Loadingdata ;
      private string Combo_tipcod_Noresultsfound ;
      private string Combo_tipcod_Emptyitemtext ;
      private string Combo_tipcod_Onlyselectedvalues ;
      private string Combo_tipcod_Selectalltext ;
      private string Combo_tipcod_Multiplevaluesseparator ;
      private string Combo_tipcod_Addnewoptiontext ;
      private string hsh ;
      private string sMode32 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_24_fel_idx="0001" ;
      private string subGridlevel_tip_Class ;
      private string subGridlevel_tip_Linesclass ;
      private string ROClassString ;
      private string edtTipCod_Jsonclick ;
      private string edtUsuSerDet_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7UsuCod ;
      private string subGridlevel_tip_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_tipcod_Isgriditem ;
      private bool Combo_tipcod_Hasdescription ;
      private bool Combo_tipcod_Emptyitem ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool Combo_tipcod_Enabled ;
      private bool Combo_tipcod_Visible ;
      private bool Combo_tipcod_Allowmultipleselection ;
      private bool Combo_tipcod_Includeonlyselectedoption ;
      private bool Combo_tipcod_Includeselectalloption ;
      private bool Combo_tipcod_Includeaddnewoption ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_tipContainer ;
      private GXWebRow Gridlevel_tipRow ;
      private GXWebColumn Gridlevel_tipColumn ;
      private GXUserControl ucCombo_tipcod ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T005G7_A348UsuCod ;
      private string[] T005G8_A348UsuCod ;
      private string[] T005G6_A348UsuCod ;
      private string[] T005G9_A348UsuCod ;
      private string[] T005G10_A348UsuCod ;
      private string[] T005G5_A348UsuCod ;
      private long[] T005G13_A2237SGNotificacionID ;
      private short[] T005G13_A2245SGNotificacionDetID ;
      private long[] T005G14_A2237SGNotificacionID ;
      private string[] T005G15_A348UsuCod ;
      private int[] T005G15_A346ObjCod ;
      private string[] T005G16_A348UsuCod ;
      private string[] T005G16_A342SGMenuPrograma ;
      private string[] T005G16_A343SGMenuNiv1ID ;
      private string[] T005G17_A348UsuCod ;
      private int[] T005G17_A349UsuAlmCod ;
      private string[] T005G18_A348UsuCod ;
      private string[] T005G19_A348UsuCod ;
      private string[] T005G19_A351UsuSerDet ;
      private string[] T005G19_A149TipCod ;
      private string[] T005G4_A149TipCod ;
      private string[] T005G20_A149TipCod ;
      private string[] T005G21_A348UsuCod ;
      private string[] T005G21_A149TipCod ;
      private string[] T005G21_A351UsuSerDet ;
      private string[] T005G3_A348UsuCod ;
      private string[] T005G3_A351UsuSerDet ;
      private string[] T005G3_A149TipCod ;
      private string[] T005G2_A348UsuCod ;
      private string[] T005G2_A351UsuSerDet ;
      private string[] T005G2_A149TipCod ;
      private string[] T005G24_A348UsuCod ;
      private string[] T005G24_A149TipCod ;
      private string[] T005G24_A351UsuSerDet ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] T005G25_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11TipCod_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class usuariosseries__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class usuariosseries__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
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
        Object[] prmT005G7;
        prmT005G7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G8;
        prmT005G8 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G6;
        prmT005G6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G9;
        prmT005G9 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G10;
        prmT005G10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G5;
        prmT005G5 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G11;
        prmT005G11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G12;
        prmT005G12 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G13;
        prmT005G13 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G14;
        prmT005G14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G15;
        prmT005G15 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G16;
        prmT005G16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G17;
        prmT005G17 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G18;
        prmT005G18 = new Object[] {
        };
        Object[] prmT005G19;
        prmT005G19 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT005G4;
        prmT005G4 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT005G20;
        prmT005G20 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT005G21;
        prmT005G21 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT005G3;
        prmT005G3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT005G2;
        prmT005G2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT005G22;
        prmT005G22 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT005G23;
        prmT005G23 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT005G24;
        prmT005G24 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005G25;
        prmT005G25 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005G2", "SELECT [UsuCod], [UsuSerDet], [TipCod] FROM [SGUSUARIOSSERIES] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G3", "SELECT [UsuCod], [UsuSerDet], [TipCod] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G4", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G5", "SELECT [UsuCod] FROM [SGUSUARIOS] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G6", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G7", "SELECT TM1.[UsuCod] FROM [SGUSUARIOS] TM1 WHERE TM1.[UsuCod] = @UsuCod ORDER BY TM1.[UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005G7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G8", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G9", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] > @UsuCod) ORDER BY [UsuCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005G9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G10", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] < @UsuCod) ORDER BY [UsuCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005G10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G11", "INSERT INTO [SGUSUARIOS]([UsuCod], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod], [UsuMosCBCod], [UsuMosConcepto], [UsuPas], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuVend], [UsuSerie5], [UsuReqADM], [UsuTieCod], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [AreCod], [UsuSRet], [UsuDep], [UsuVendAut]) VALUES(@UsuCod, '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), '', convert(int, 0), '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT005G11)
           ,new CursorDef("T005G12", "DELETE FROM [SGUSUARIOS]  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT005G12)
           ,new CursorDef("T005G13", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionDetUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G14", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G15", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G16", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G17", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005G18", "SELECT [UsuCod] FROM [SGUSUARIOS] ORDER BY [UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005G18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G19", "SELECT [UsuCod], [UsuSerDet], [TipCod] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod and [TipCod] = @TipCod and [UsuSerDet] = @UsuSerDet ORDER BY [UsuCod], [TipCod], [UsuSerDet] ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G20", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G21", "SELECT [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G22", "INSERT INTO [SGUSUARIOSSERIES]([UsuCod], [UsuSerDet], [TipCod]) VALUES(@UsuCod, @UsuSerDet, @TipCod)", GxErrorMask.GX_NOMASK,prmT005G22)
           ,new CursorDef("T005G23", "DELETE FROM [SGUSUARIOSSERIES]  WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet", GxErrorMask.GX_NOMASK,prmT005G23)
           ,new CursorDef("T005G24", "SELECT [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod ORDER BY [UsuCod], [TipCod], [UsuSerDet] ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G24,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005G25", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005G25,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
