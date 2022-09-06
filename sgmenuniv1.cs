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
namespace GeneXus.Programs {
   public class sgmenuniv1 : GXWebComponent
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
            gxfirstwebparm = GetNextPar( );
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
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
               Form.Meta.addItem("description", "Nivel 1", 0) ;
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
            GX_FocusControl = edtSGMenuPrograma_Internalname;
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

      public sgmenuniv1( )
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

      public sgmenuniv1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
            RenderHtmlCloseForm0N23( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "sgmenuniv1.aspx");
         }
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Nivel 1", "", "", lblTitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ESELECT."+"'", TempTags, "", 2, "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuPrograma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuPrograma_Internalname, "Programa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuPrograma_Internalname, A342SGMenuPrograma, StringUtil.RTrim( context.localUtil.Format( A342SGMenuPrograma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuPrograma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuPrograma_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv1ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv1ID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv1ID_Internalname, A343SGMenuNiv1ID, StringUtil.RTrim( context.localUtil.Format( A343SGMenuNiv1ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv1ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv1ID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv1Dsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv1Dsc_Internalname, "Menu", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A1850SGMenuNiv1Dsc", A1850SGMenuNiv1Dsc);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv1Dsc_Internalname, A1850SGMenuNiv1Dsc, StringUtil.RTrim( context.localUtil.Format( A1850SGMenuNiv1Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv1Dsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv1Dsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV1.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z342SGMenuPrograma = cgiGet( sPrefix+"Z342SGMenuPrograma");
            Z343SGMenuNiv1ID = cgiGet( sPrefix+"Z343SGMenuNiv1ID");
            Z1850SGMenuNiv1Dsc = cgiGet( sPrefix+"Z1850SGMenuNiv1Dsc");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
            Gx_mode = cgiGet( sPrefix+"Mode");
            /* Read variables values. */
            A342SGMenuPrograma = cgiGet( edtSGMenuPrograma_Internalname);
            AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = cgiGet( edtSGMenuNiv1ID_Internalname);
            AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A1850SGMenuNiv1Dsc = cgiGet( edtSGMenuNiv1Dsc_Internalname);
            AssignAttri(sPrefix, false, "A1850SGMenuNiv1Dsc", A1850SGMenuNiv1Dsc);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               A342SGMenuPrograma = GetPar( "SGMenuPrograma");
               AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
               AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
                                 btn_enter( ) ;
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
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
                                 btn_first( ) ;
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
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
                                 btn_previous( ) ;
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
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
                                 btn_next( ) ;
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
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
                                 btn_last( ) ;
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
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
                                 btn_select( ) ;
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
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
                                 btn_delete( ) ;
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
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
                                 AfterKeyLoadScreen( ) ;
                              }
                           }
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0N23( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         AssignProp(sPrefix, false, edtSGMenuPrograma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuPrograma_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSGMenuNiv1ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1ID_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSGMenuNiv1Dsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1Dsc_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         AssignProp(sPrefix, false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp(sPrefix, false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0N23( ) ;
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

      protected void ResetCaption0N0( )
      {
      }

      protected void ZM0N23( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1850SGMenuNiv1Dsc = T000N3_A1850SGMenuNiv1Dsc[0];
            }
            else
            {
               Z1850SGMenuNiv1Dsc = A1850SGMenuNiv1Dsc;
            }
         }
         if ( GX_JID == -1 )
         {
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z1850SGMenuNiv1Dsc = A1850SGMenuNiv1Dsc;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0N23( )
      {
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A1850SGMenuNiv1Dsc = T000N4_A1850SGMenuNiv1Dsc[0];
            AssignAttri(sPrefix, false, "A1850SGMenuNiv1Dsc", A1850SGMenuNiv1Dsc);
            ZM0N23( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0N23( ) ;
      }

      protected void OnLoadActions0N23( )
      {
      }

      protected void CheckExtendedTable0N23( )
      {
         nIsDirty_23 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0N23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N23( )
      {
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N23( 1) ;
            RcdFound23 = 1;
            A342SGMenuPrograma = T000N3_A342SGMenuPrograma[0];
            AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000N3_A343SGMenuNiv1ID[0];
            AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A1850SGMenuNiv1Dsc = T000N3_A1850SGMenuNiv1Dsc[0];
            AssignAttri(sPrefix, false, "A1850SGMenuNiv1Dsc", A1850SGMenuNiv1Dsc);
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0N23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0N23( ) ;
            }
            Gx_mode = sMode23;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0N23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode23;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound23 = 0;
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000N6_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000N6_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000N6_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000N6_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000N6_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000N6_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) ) )
            {
               A342SGMenuPrograma = T000N6_A342SGMenuPrograma[0];
               AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000N6_A343SGMenuNiv1ID[0];
               AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               RcdFound23 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound23 = 0;
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000N7_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000N7_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000N7_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000N7_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000N7_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000N7_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) ) )
            {
               A342SGMenuPrograma = T000N7_A342SGMenuPrograma[0];
               AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000N7_A343SGMenuNiv1ID[0];
               AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               RcdFound23 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0N23( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) )
               {
                  A342SGMenuPrograma = Z342SGMenuPrograma;
                  AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
                  A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
                  AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SGMENUPROGRAMA");
                  AnyError = 1;
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0N23( ) ;
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0N23( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SGMENUPROGRAMA");
                     AnyError = 1;
                     GX_FocusControl = edtSGMenuPrograma_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSGMenuPrograma_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0N23( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) )
         {
            A342SGMenuPrograma = Z342SGMenuPrograma;
            AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
            AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SGMENUPROGRAMA");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SGMENUPROGRAMA");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGMenuNiv1Dsc_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv1Dsc_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N23( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv1Dsc_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv1Dsc_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound23 != 0 )
            {
               ScanNext0N23( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv1Dsc_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N23( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0N23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGMENUNIV1"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1850SGMenuNiv1Dsc, T000N2_A1850SGMenuNiv1Dsc[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1850SGMenuNiv1Dsc, T000N2_A1850SGMenuNiv1Dsc[0]) != 0 )
               {
                  GXUtil.WriteLog("sgmenuniv1:[seudo value changed for attri]"+"SGMenuNiv1Dsc");
                  GXUtil.WriteLogRaw("Old: ",Z1850SGMenuNiv1Dsc);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A1850SGMenuNiv1Dsc[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGMENUNIV1"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N23( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N23( 0) ;
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N8 */
                     pr_default.execute(6, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A1850SGMenuNiv1Dsc});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGMENUNIV1");
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
                           ResetCaption0N0( ) ;
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
               Load0N23( ) ;
            }
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void Update0N23( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N9 */
                     pr_default.execute(7, new Object[] {A1850SGMenuNiv1Dsc, A342SGMenuPrograma, A343SGMenuNiv1ID});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGMENUNIV1");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGMENUNIV1"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N23( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0N0( ) ;
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
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void DeferredUpdate0N23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N23( ) ;
            AfterConfirm0N23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N10 */
                  pr_default.execute(8, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGMENUNIV1");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound23 == 0 )
                        {
                           InitAll0N23( ) ;
                           Gx_mode = "INS";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0N0( ) ;
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0N23( ) ;
         Gx_mode = sMode23;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N23( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000N11 */
            pr_default.execute(9, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000N12 */
            pr_default.execute(10, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Nivel 2"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0N23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgmenuniv1",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgmenuniv1",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N23( )
      {
         /* Using cursor T000N13 */
         pr_default.execute(11);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound23 = 1;
            A342SGMenuPrograma = T000N13_A342SGMenuPrograma[0];
            AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000N13_A343SGMenuNiv1ID[0];
            AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N23( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound23 = 1;
            A342SGMenuPrograma = T000N13_A342SGMenuPrograma[0];
            AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000N13_A343SGMenuNiv1ID[0];
            AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         }
      }

      protected void ScanEnd0N23( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0N23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N23( )
      {
         edtSGMenuPrograma_Enabled = 0;
         AssignProp(sPrefix, false, edtSGMenuPrograma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuPrograma_Enabled), 5, 0), true);
         edtSGMenuNiv1ID_Enabled = 0;
         AssignProp(sPrefix, false, edtSGMenuNiv1ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1ID_Enabled), 5, 0), true);
         edtSGMenuNiv1Dsc_Enabled = 0;
         AssignProp(sPrefix, false, edtSGMenuNiv1Dsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1Dsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N23( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
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
            context.SendWebValue( "Nivel 1") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281811383472", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgmenuniv1.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z1850SGMenuNiv1Dsc", Z1850SGMenuNiv1Dsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm0N23( )
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
         return "SGMENUNIV1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nivel 1" ;
      }

      protected void InitializeNonKey0N23( )
      {
         A1850SGMenuNiv1Dsc = "";
         AssignAttri(sPrefix, false, "A1850SGMenuNiv1Dsc", A1850SGMenuNiv1Dsc);
         Z1850SGMenuNiv1Dsc = "";
      }

      protected void InitAll0N23( )
      {
         A342SGMenuPrograma = "";
         AssignAttri(sPrefix, false, "A342SGMenuPrograma", A342SGMenuPrograma);
         A343SGMenuNiv1ID = "";
         AssignAttri(sPrefix, false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         InitializeNonKey0N23( ) ;
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
         AddComponentObject(sPrefix, "sgmenuniv1", GetJustCreated( ));
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
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811383478", true, true);
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
         context.AddJavascriptSource("sgmenuniv1.js", "?202281811383478", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = sPrefix+"TITLE";
         bttBtn_first_Internalname = sPrefix+"BTN_FIRST";
         bttBtn_previous_Internalname = sPrefix+"BTN_PREVIOUS";
         bttBtn_next_Internalname = sPrefix+"BTN_NEXT";
         bttBtn_last_Internalname = sPrefix+"BTN_LAST";
         bttBtn_select_Internalname = sPrefix+"BTN_SELECT";
         edtSGMenuPrograma_Internalname = sPrefix+"SGMENUPROGRAMA";
         edtSGMenuNiv1ID_Internalname = sPrefix+"SGMENUNIV1ID";
         edtSGMenuNiv1Dsc_Internalname = sPrefix+"SGMENUNIV1DSC";
         bttBtn_enter_Internalname = sPrefix+"BTN_ENTER";
         bttBtn_cancel_Internalname = sPrefix+"BTN_CANCEL";
         bttBtn_delete_Internalname = sPrefix+"BTN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGMenuNiv1Dsc_Jsonclick = "";
         edtSGMenuNiv1Dsc_Enabled = 1;
         edtSGMenuNiv1ID_Jsonclick = "";
         edtSGMenuNiv1ID_Enabled = 1;
         edtSGMenuPrograma_Jsonclick = "";
         edtSGMenuPrograma_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSGMenuNiv1Dsc_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Sgmenuniv1id( )
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
               AfterKeyLoadScreen( ) ;
            }
         }
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A1850SGMenuNiv1Dsc", A1850SGMenuNiv1Dsc);
         AssignAttri(sPrefix, false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z1850SGMenuNiv1Dsc", Z1850SGMenuNiv1Dsc);
         AssignProp(sPrefix, false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_SGMENUPROGRAMA","{handler:'Valid_Sgmenuprograma',iparms:[]");
         setEventMetadata("VALID_SGMENUPROGRAMA",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV1ID","{handler:'Valid_Sgmenuniv1id',iparms:[{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGMENUNIV1ID",",oparms:[{av:'A1850SGMenuNiv1Dsc',fld:'SGMENUNIV1DSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z342SGMenuPrograma'},{av:'Z343SGMenuNiv1ID'},{av:'Z1850SGMenuNiv1Dsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z342SGMenuPrograma = "";
         Z343SGMenuNiv1ID = "";
         Z1850SGMenuNiv1Dsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A342SGMenuPrograma = "";
         A343SGMenuNiv1ID = "";
         A1850SGMenuNiv1Dsc = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000N4_A342SGMenuPrograma = new string[] {""} ;
         T000N4_A343SGMenuNiv1ID = new string[] {""} ;
         T000N4_A1850SGMenuNiv1Dsc = new string[] {""} ;
         T000N5_A342SGMenuPrograma = new string[] {""} ;
         T000N5_A343SGMenuNiv1ID = new string[] {""} ;
         T000N3_A342SGMenuPrograma = new string[] {""} ;
         T000N3_A343SGMenuNiv1ID = new string[] {""} ;
         T000N3_A1850SGMenuNiv1Dsc = new string[] {""} ;
         sMode23 = "";
         T000N6_A342SGMenuPrograma = new string[] {""} ;
         T000N6_A343SGMenuNiv1ID = new string[] {""} ;
         T000N7_A342SGMenuPrograma = new string[] {""} ;
         T000N7_A343SGMenuNiv1ID = new string[] {""} ;
         T000N2_A342SGMenuPrograma = new string[] {""} ;
         T000N2_A343SGMenuNiv1ID = new string[] {""} ;
         T000N2_A1850SGMenuNiv1Dsc = new string[] {""} ;
         T000N11_A348UsuCod = new string[] {""} ;
         T000N11_A342SGMenuPrograma = new string[] {""} ;
         T000N11_A343SGMenuNiv1ID = new string[] {""} ;
         T000N12_A342SGMenuPrograma = new string[] {""} ;
         T000N12_A343SGMenuNiv1ID = new string[] {""} ;
         T000N12_A344SGMenuNiv2ID = new string[] {""} ;
         T000N13_A342SGMenuPrograma = new string[] {""} ;
         T000N13_A343SGMenuNiv1ID = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ZZ342SGMenuPrograma = "";
         ZZ343SGMenuNiv1ID = "";
         ZZ1850SGMenuNiv1Dsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgmenuniv1__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgmenuniv1__default(),
            new Object[][] {
                new Object[] {
               T000N2_A342SGMenuPrograma, T000N2_A343SGMenuNiv1ID, T000N2_A1850SGMenuNiv1Dsc
               }
               , new Object[] {
               T000N3_A342SGMenuPrograma, T000N3_A343SGMenuNiv1ID, T000N3_A1850SGMenuNiv1Dsc
               }
               , new Object[] {
               T000N4_A342SGMenuPrograma, T000N4_A343SGMenuNiv1ID, T000N4_A1850SGMenuNiv1Dsc
               }
               , new Object[] {
               T000N5_A342SGMenuPrograma, T000N5_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000N6_A342SGMenuPrograma, T000N6_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000N7_A342SGMenuPrograma, T000N7_A343SGMenuNiv1ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N11_A348UsuCod, T000N11_A342SGMenuPrograma, T000N11_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000N12_A342SGMenuPrograma, T000N12_A343SGMenuNiv1ID, T000N12_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000N13_A342SGMenuPrograma, T000N13_A343SGMenuNiv1ID
               }
            }
         );
      }

      private short GxWebError ;
      private short nDynComponent ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short GX_JID ;
      private short RcdFound23 ;
      private short nIsDirty_23 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSGMenuPrograma_Enabled ;
      private int edtSGMenuNiv1ID_Enabled ;
      private int edtSGMenuNiv1Dsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtSGMenuPrograma_Internalname ;
      private string divTablemain_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtSGMenuPrograma_Jsonclick ;
      private string edtSGMenuNiv1ID_Internalname ;
      private string edtSGMenuNiv1ID_Jsonclick ;
      private string edtSGMenuNiv1Dsc_Internalname ;
      private string edtSGMenuNiv1Dsc_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode23 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z342SGMenuPrograma ;
      private string Z343SGMenuNiv1ID ;
      private string Z1850SGMenuNiv1Dsc ;
      private string A342SGMenuPrograma ;
      private string A343SGMenuNiv1ID ;
      private string A1850SGMenuNiv1Dsc ;
      private string ZZ342SGMenuPrograma ;
      private string ZZ343SGMenuNiv1ID ;
      private string ZZ1850SGMenuNiv1Dsc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000N4_A342SGMenuPrograma ;
      private string[] T000N4_A343SGMenuNiv1ID ;
      private string[] T000N4_A1850SGMenuNiv1Dsc ;
      private string[] T000N5_A342SGMenuPrograma ;
      private string[] T000N5_A343SGMenuNiv1ID ;
      private string[] T000N3_A342SGMenuPrograma ;
      private string[] T000N3_A343SGMenuNiv1ID ;
      private string[] T000N3_A1850SGMenuNiv1Dsc ;
      private string[] T000N6_A342SGMenuPrograma ;
      private string[] T000N6_A343SGMenuNiv1ID ;
      private string[] T000N7_A342SGMenuPrograma ;
      private string[] T000N7_A343SGMenuNiv1ID ;
      private string[] T000N2_A342SGMenuPrograma ;
      private string[] T000N2_A343SGMenuNiv1ID ;
      private string[] T000N2_A1850SGMenuNiv1Dsc ;
      private string[] T000N11_A348UsuCod ;
      private string[] T000N11_A342SGMenuPrograma ;
      private string[] T000N11_A343SGMenuNiv1ID ;
      private string[] T000N12_A342SGMenuPrograma ;
      private string[] T000N12_A343SGMenuNiv1ID ;
      private string[] T000N12_A344SGMenuNiv2ID ;
      private string[] T000N13_A342SGMenuPrograma ;
      private string[] T000N13_A343SGMenuNiv1ID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class sgmenuniv1__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgmenuniv1__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000N4;
        prmT000N4 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N5;
        prmT000N5 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N3;
        prmT000N3 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N6;
        prmT000N6 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N7;
        prmT000N7 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N2;
        prmT000N2 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N8;
        prmT000N8 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv1Dsc",GXType.NVarChar,100,0)
        };
        Object[] prmT000N9;
        prmT000N9 = new Object[] {
        new ParDef("@SGMenuNiv1Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N10;
        prmT000N10 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N11;
        prmT000N11 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N12;
        prmT000N12 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000N13;
        prmT000N13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000N2", "SELECT [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv1Dsc] FROM [SGMENUNIV1] WITH (UPDLOCK) WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N3", "SELECT [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv1Dsc] FROM [SGMENUNIV1] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N4", "SELECT TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv1Dsc] FROM [SGMENUNIV1] TM1 WHERE TM1.[SGMenuPrograma] = @SGMenuPrograma and TM1.[SGMenuNiv1ID] = @SGMenuNiv1ID ORDER BY TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N5", "SELECT [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGMENUNIV1] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N6", "SELECT TOP 1 [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGMENUNIV1] WHERE ( [SGMenuPrograma] > @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv1ID] > @SGMenuNiv1ID) ORDER BY [SGMenuPrograma], [SGMenuNiv1ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N7", "SELECT TOP 1 [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGMENUNIV1] WHERE ( [SGMenuPrograma] < @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv1ID] < @SGMenuNiv1ID) ORDER BY [SGMenuPrograma] DESC, [SGMenuNiv1ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N8", "INSERT INTO [SGMENUNIV1]([SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv1Dsc]) VALUES(@SGMenuPrograma, @SGMenuNiv1ID, @SGMenuNiv1Dsc)", GxErrorMask.GX_NOMASK,prmT000N8)
           ,new CursorDef("T000N9", "UPDATE [SGMENUNIV1] SET [SGMenuNiv1Dsc]=@SGMenuNiv1Dsc  WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID", GxErrorMask.GX_NOMASK,prmT000N9)
           ,new CursorDef("T000N10", "DELETE FROM [SGMENUNIV1]  WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID", GxErrorMask.GX_NOMASK,prmT000N10)
           ,new CursorDef("T000N11", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N12", "SELECT TOP 1 [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N13", "SELECT [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGMENUNIV1] ORDER BY [SGMenuPrograma], [SGMenuNiv1ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
