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
   public class sgusuarioalmacen : GXWebComponent
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
            {
               A348UsuCod = GetPar( "UsuCod");
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_2( A348UsuCod) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
            {
               A349UsuAlmCod = (int)(NumberUtil.Val( GetPar( "UsuAlmCod"), "."));
               AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_3( A349UsuAlmCod) ;
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
               Form.Meta.addItem("description", "SGUSUARIOALMACEN", 0) ;
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

      public sgusuarioalmacen( )
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

      public sgusuarioalmacen( IGxContext context )
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
            RenderHtmlCloseForm0T28( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "sgusuarioalmacen.aspx");
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIOALMACEN", "", "", lblTitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIOALMACEN.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIOALMACEN.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuAlmCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuAlmCod_Internalname, "Almacen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A349UsuAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A349UsuAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A349UsuAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuAlmDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuAlmDsc_Internalname, "Almacen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
         GxWebStd.gx_single_line_edit( context, edtUsuAlmDsc_Internalname, StringUtil.RTrim( A2007UsuAlmDsc), StringUtil.RTrim( context.localUtil.Format( A2007UsuAlmDsc, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuAlmDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuAlmDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuAlmSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuAlmSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.Str( (decimal)(A2008UsuAlmSts), 1, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuAlmSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2008UsuAlmSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtUsuAlmSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2008UsuAlmSts), "9") : context.localUtil.Format( (decimal)(A2008UsuAlmSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuAlmSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuAlmSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOALMACEN.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOALMACEN.htm");
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
            Z348UsuCod = cgiGet( sPrefix+"Z348UsuCod");
            Z349UsuAlmCod = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z349UsuAlmCod"), ".", ","));
            Z2008UsuAlmSts = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z2008UsuAlmSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
            Gx_mode = cgiGet( sPrefix+"Mode");
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUALMCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuAlmCod_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A349UsuAlmCod = 0;
               AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
            }
            else
            {
               A349UsuAlmCod = (int)(context.localUtil.CToN( cgiGet( edtUsuAlmCod_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
            }
            A2007UsuAlmDsc = cgiGet( edtUsuAlmDsc_Internalname);
            AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuAlmSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuAlmSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUALMSTS");
               AnyError = 1;
               GX_FocusControl = edtUsuAlmSts_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2008UsuAlmSts = 0;
               AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.Str( (decimal)(A2008UsuAlmSts), 1, 0));
            }
            else
            {
               A2008UsuAlmSts = (short)(context.localUtil.CToN( cgiGet( edtUsuAlmSts_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.Str( (decimal)(A2008UsuAlmSts), 1, 0));
            }
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
               A348UsuCod = GetPar( "UsuCod");
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               A349UsuAlmCod = (int)(NumberUtil.Val( GetPar( "UsuAlmCod"), "."));
               AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
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
               InitAll0T28( ) ;
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
         AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAlmCod_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuAlmDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAlmDsc_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuAlmSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAlmSts_Enabled), 5, 0), true);
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
         DisableAttributes0T28( ) ;
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

      protected void ResetCaption0T0( )
      {
      }

      protected void ZM0T28( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2008UsuAlmSts = T000T3_A2008UsuAlmSts[0];
            }
            else
            {
               Z2008UsuAlmSts = A2008UsuAlmSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2008UsuAlmSts = A2008UsuAlmSts;
            Z348UsuCod = A348UsuCod;
            Z349UsuAlmCod = A349UsuAlmCod;
            Z2007UsuAlmDsc = A2007UsuAlmDsc;
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

      protected void Load0T28( )
      {
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound28 = 1;
            A2007UsuAlmDsc = T000T6_A2007UsuAlmDsc[0];
            AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
            A2008UsuAlmSts = T000T6_A2008UsuAlmSts[0];
            AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.Str( (decimal)(A2008UsuAlmSts), 1, 0));
            ZM0T28( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0T28( ) ;
      }

      protected void OnLoadActions0T28( )
      {
      }

      protected void CheckExtendedTable0T28( )
      {
         nIsDirty_28 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000T5 */
         pr_default.execute(3, new Object[] {A349UsuAlmCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuAlmCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A2007UsuAlmDsc = T000T5_A2007UsuAlmDsc[0];
         AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0T28( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A348UsuCod )
      {
         /* Using cursor T000T7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A349UsuAlmCod )
      {
         /* Using cursor T000T8 */
         pr_default.execute(6, new Object[] {A349UsuAlmCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuAlmCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A2007UsuAlmDsc = T000T8_A2007UsuAlmDsc[0];
         AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2007UsuAlmDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0T28( )
      {
         /* Using cursor T000T9 */
         pr_default.execute(7, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T28( 1) ;
            RcdFound28 = 1;
            A2008UsuAlmSts = T000T3_A2008UsuAlmSts[0];
            AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.Str( (decimal)(A2008UsuAlmSts), 1, 0));
            A348UsuCod = T000T3_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            A349UsuAlmCod = T000T3_A349UsuAlmCod[0];
            AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
            Z348UsuCod = A348UsuCod;
            Z349UsuAlmCod = A349UsuAlmCod;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0T28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0T28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0T28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T28( ) ;
         if ( RcdFound28 == 0 )
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
         RcdFound28 = 0;
         /* Using cursor T000T10 */
         pr_default.execute(8, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000T10_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000T10_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000T10_A349UsuAlmCod[0] < A349UsuAlmCod ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000T10_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000T10_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000T10_A349UsuAlmCod[0] > A349UsuAlmCod ) ) )
            {
               A348UsuCod = T000T10_A348UsuCod[0];
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               A349UsuAlmCod = T000T10_A349UsuAlmCod[0];
               AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000T11 */
         pr_default.execute(9, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000T11_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000T11_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000T11_A349UsuAlmCod[0] > A349UsuAlmCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000T11_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000T11_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000T11_A349UsuAlmCod[0] < A349UsuAlmCod ) ) )
            {
               A348UsuCod = T000T11_A348UsuCod[0];
               AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
               A349UsuAlmCod = T000T11_A349UsuAlmCod[0];
               AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0T28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
                  A349UsuAlmCod = Z349UsuAlmCod;
                  AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
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
                  Gx_mode = "UPD";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0T28( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0T28( ) ;
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
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0T28( ) ;
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
         if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            A349UsuAlmCod = Z349UsuAlmCod;
            AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuAlmSts_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0T28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuAlmSts_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0T28( ) ;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuAlmSts_Internalname;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuAlmSts_Internalname;
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
         ScanStart0T28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound28 != 0 )
            {
               ScanNext0T28( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuAlmSts_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0T28( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0T28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A349UsuAlmCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOALMACEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2008UsuAlmSts != T000T2_A2008UsuAlmSts[0] ) )
            {
               if ( Z2008UsuAlmSts != T000T2_A2008UsuAlmSts[0] )
               {
                  GXUtil.WriteLog("sgusuarioalmacen:[seudo value changed for attri]"+"UsuAlmSts");
                  GXUtil.WriteLogRaw("Old: ",Z2008UsuAlmSts);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A2008UsuAlmSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOALMACEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T28( )
      {
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T28( 0) ;
            CheckOptimisticConcurrency0T28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T12 */
                     pr_default.execute(10, new Object[] {A2008UsuAlmSts, A348UsuCod, A349UsuAlmCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOALMACEN");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption0T0( ) ;
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
               Load0T28( ) ;
            }
            EndLevel0T28( ) ;
         }
         CloseExtendedTableCursors0T28( ) ;
      }

      protected void Update0T28( )
      {
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T13 */
                     pr_default.execute(11, new Object[] {A2008UsuAlmSts, A348UsuCod, A349UsuAlmCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOALMACEN");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOALMACEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0T0( ) ;
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
            EndLevel0T28( ) ;
         }
         CloseExtendedTableCursors0T28( ) ;
      }

      protected void DeferredUpdate0T28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T28( ) ;
            AfterConfirm0T28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000T14 */
                  pr_default.execute(12, new Object[] {A348UsuCod, A349UsuAlmCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOALMACEN");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound28 == 0 )
                        {
                           InitAll0T28( ) ;
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
                        ResetCaption0T0( ) ;
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0T28( ) ;
         Gx_mode = sMode28;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000T15 */
            pr_default.execute(13, new Object[] {A349UsuAlmCod});
            A2007UsuAlmDsc = T000T15_A2007UsuAlmDsc[0];
            AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
            pr_default.close(13);
         }
      }

      protected void EndLevel0T28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("sgusuarioalmacen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("sgusuarioalmacen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T28( )
      {
         /* Using cursor T000T16 */
         pr_default.execute(14);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound28 = 1;
            A348UsuCod = T000T16_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            A349UsuAlmCod = T000T16_A349UsuAlmCod[0];
            AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T28( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound28 = 1;
            A348UsuCod = T000T16_A348UsuCod[0];
            AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
            A349UsuAlmCod = T000T16_A349UsuAlmCod[0];
            AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
         }
      }

      protected void ScanEnd0T28( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0T28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T28( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtUsuAlmCod_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAlmCod_Enabled), 5, 0), true);
         edtUsuAlmDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuAlmDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAlmDsc_Enabled), 5, 0), true);
         edtUsuAlmSts_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuAlmSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAlmSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0T28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0T0( )
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
            context.SendWebValue( "SGUSUARIOALMACEN") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281811383321", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuarioalmacen.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z349UsuAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z349UsuAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2008UsuAlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2008UsuAlmSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm0T28( )
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
         return "SGUSUARIOALMACEN" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIOALMACEN" ;
      }

      protected void InitializeNonKey0T28( )
      {
         A2007UsuAlmDsc = "";
         AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
         A2008UsuAlmSts = 0;
         AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.Str( (decimal)(A2008UsuAlmSts), 1, 0));
         Z2008UsuAlmSts = 0;
      }

      protected void InitAll0T28( )
      {
         A348UsuCod = "";
         AssignAttri(sPrefix, false, "A348UsuCod", A348UsuCod);
         A349UsuAlmCod = 0;
         AssignAttri(sPrefix, false, "A349UsuAlmCod", StringUtil.LTrimStr( (decimal)(A349UsuAlmCod), 6, 0));
         InitializeNonKey0T28( ) ;
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
         AddComponentObject(sPrefix, "sgusuarioalmacen", GetJustCreated( ));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811383331", true, true);
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
         context.AddJavascriptSource("sgusuarioalmacen.js", "?202281811383331", false, true);
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
         edtUsuCod_Internalname = sPrefix+"USUCOD";
         edtUsuAlmCod_Internalname = sPrefix+"USUALMCOD";
         edtUsuAlmDsc_Internalname = sPrefix+"USUALMDSC";
         edtUsuAlmSts_Internalname = sPrefix+"USUALMSTS";
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
         edtUsuAlmSts_Jsonclick = "";
         edtUsuAlmSts_Enabled = 1;
         edtUsuAlmDsc_Jsonclick = "";
         edtUsuAlmDsc_Enabled = 0;
         edtUsuAlmCod_Jsonclick = "";
         edtUsuAlmCod_Enabled = 1;
         edtUsuCod_Jsonclick = "";
         edtUsuCod_Enabled = 1;
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
         /* Using cursor T000T17 */
         pr_default.execute(15, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         /* Using cursor T000T15 */
         pr_default.execute(13, new Object[] {A349UsuAlmCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuAlmCod_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A2007UsuAlmDsc = T000T15_A2007UsuAlmDsc[0];
         AssignAttri(sPrefix, false, "A2007UsuAlmDsc", A2007UsuAlmDsc);
         pr_default.close(13);
         GX_FocusControl = edtUsuAlmSts_Internalname;
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

      public void Valid_Usucod( )
      {
         /* Using cursor T000T17 */
         pr_default.execute(15, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usualmcod( )
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
         /* Using cursor T000T15 */
         pr_default.execute(13, new Object[] {A349UsuAlmCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuAlmCod_Internalname;
         }
         A2007UsuAlmDsc = T000T15_A2007UsuAlmDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A2008UsuAlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2008UsuAlmSts), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A2007UsuAlmDsc", StringUtil.RTrim( A2007UsuAlmDsc));
         AssignAttri(sPrefix, false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z349UsuAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z349UsuAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2008UsuAlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2008UsuAlmSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2007UsuAlmDsc", StringUtil.RTrim( Z2007UsuAlmDsc));
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
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''}]");
         setEventMetadata("VALID_USUCOD",",oparms:[]}");
         setEventMetadata("VALID_USUALMCOD","{handler:'Valid_Usualmcod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A349UsuAlmCod',fld:'USUALMCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_USUALMCOD",",oparms:[{av:'A2008UsuAlmSts',fld:'USUALMSTS',pic:'9'},{av:'A2007UsuAlmDsc',fld:'USUALMDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z349UsuAlmCod'},{av:'Z2008UsuAlmSts'},{av:'Z2007UsuAlmDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(15);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A348UsuCod = "";
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
         A2007UsuAlmDsc = "";
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
         Z2007UsuAlmDsc = "";
         T000T6_A2007UsuAlmDsc = new string[] {""} ;
         T000T6_A2008UsuAlmSts = new short[1] ;
         T000T6_A348UsuCod = new string[] {""} ;
         T000T6_A349UsuAlmCod = new int[1] ;
         T000T4_A348UsuCod = new string[] {""} ;
         T000T5_A2007UsuAlmDsc = new string[] {""} ;
         T000T7_A348UsuCod = new string[] {""} ;
         T000T8_A2007UsuAlmDsc = new string[] {""} ;
         T000T9_A348UsuCod = new string[] {""} ;
         T000T9_A349UsuAlmCod = new int[1] ;
         T000T3_A2008UsuAlmSts = new short[1] ;
         T000T3_A348UsuCod = new string[] {""} ;
         T000T3_A349UsuAlmCod = new int[1] ;
         sMode28 = "";
         T000T10_A348UsuCod = new string[] {""} ;
         T000T10_A349UsuAlmCod = new int[1] ;
         T000T11_A348UsuCod = new string[] {""} ;
         T000T11_A349UsuAlmCod = new int[1] ;
         T000T2_A2008UsuAlmSts = new short[1] ;
         T000T2_A348UsuCod = new string[] {""} ;
         T000T2_A349UsuAlmCod = new int[1] ;
         T000T15_A2007UsuAlmDsc = new string[] {""} ;
         T000T16_A348UsuCod = new string[] {""} ;
         T000T16_A349UsuAlmCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         T000T17_A348UsuCod = new string[] {""} ;
         ZZ348UsuCod = "";
         ZZ2007UsuAlmDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioalmacen__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioalmacen__default(),
            new Object[][] {
                new Object[] {
               T000T2_A2008UsuAlmSts, T000T2_A348UsuCod, T000T2_A349UsuAlmCod
               }
               , new Object[] {
               T000T3_A2008UsuAlmSts, T000T3_A348UsuCod, T000T3_A349UsuAlmCod
               }
               , new Object[] {
               T000T4_A348UsuCod
               }
               , new Object[] {
               T000T5_A2007UsuAlmDsc
               }
               , new Object[] {
               T000T6_A2007UsuAlmDsc, T000T6_A2008UsuAlmSts, T000T6_A348UsuCod, T000T6_A349UsuAlmCod
               }
               , new Object[] {
               T000T7_A348UsuCod
               }
               , new Object[] {
               T000T8_A2007UsuAlmDsc
               }
               , new Object[] {
               T000T9_A348UsuCod, T000T9_A349UsuAlmCod
               }
               , new Object[] {
               T000T10_A348UsuCod, T000T10_A349UsuAlmCod
               }
               , new Object[] {
               T000T11_A348UsuCod, T000T11_A349UsuAlmCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T15_A2007UsuAlmDsc
               }
               , new Object[] {
               T000T16_A348UsuCod, T000T16_A349UsuAlmCod
               }
               , new Object[] {
               T000T17_A348UsuCod
               }
            }
         );
      }

      private short Z2008UsuAlmSts ;
      private short GxWebError ;
      private short nDynComponent ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2008UsuAlmSts ;
      private short nDraw ;
      private short nDoneStart ;
      private short GX_JID ;
      private short RcdFound28 ;
      private short nIsDirty_28 ;
      private short Gx_BScreen ;
      private short ZZ2008UsuAlmSts ;
      private int Z349UsuAlmCod ;
      private int A349UsuAlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtUsuAlmCod_Enabled ;
      private int edtUsuAlmDsc_Enabled ;
      private int edtUsuAlmSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ349UsuAlmCod ;
      private string sPrefix ;
      private string Z348UsuCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string A348UsuCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtUsuCod_Internalname ;
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
      private string edtUsuCod_Jsonclick ;
      private string edtUsuAlmCod_Internalname ;
      private string edtUsuAlmCod_Jsonclick ;
      private string edtUsuAlmDsc_Internalname ;
      private string A2007UsuAlmDsc ;
      private string edtUsuAlmDsc_Jsonclick ;
      private string edtUsuAlmSts_Internalname ;
      private string edtUsuAlmSts_Jsonclick ;
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
      private string Z2007UsuAlmDsc ;
      private string sMode28 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private string ZZ2007UsuAlmDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000T6_A2007UsuAlmDsc ;
      private short[] T000T6_A2008UsuAlmSts ;
      private string[] T000T6_A348UsuCod ;
      private int[] T000T6_A349UsuAlmCod ;
      private string[] T000T4_A348UsuCod ;
      private string[] T000T5_A2007UsuAlmDsc ;
      private string[] T000T7_A348UsuCod ;
      private string[] T000T8_A2007UsuAlmDsc ;
      private string[] T000T9_A348UsuCod ;
      private int[] T000T9_A349UsuAlmCod ;
      private short[] T000T3_A2008UsuAlmSts ;
      private string[] T000T3_A348UsuCod ;
      private int[] T000T3_A349UsuAlmCod ;
      private string[] T000T10_A348UsuCod ;
      private int[] T000T10_A349UsuAlmCod ;
      private string[] T000T11_A348UsuCod ;
      private int[] T000T11_A349UsuAlmCod ;
      private short[] T000T2_A2008UsuAlmSts ;
      private string[] T000T2_A348UsuCod ;
      private int[] T000T2_A349UsuAlmCod ;
      private string[] T000T15_A2007UsuAlmDsc ;
      private string[] T000T16_A348UsuCod ;
      private int[] T000T16_A349UsuAlmCod ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] T000T17_A348UsuCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class sgusuarioalmacen__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarioalmacen__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000T6;
        prmT000T6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T4;
        prmT000T4 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000T5;
        prmT000T5 = new Object[] {
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T7;
        prmT000T7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000T8;
        prmT000T8 = new Object[] {
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T9;
        prmT000T9 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T3;
        prmT000T3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T10;
        prmT000T10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T11;
        prmT000T11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T2;
        prmT000T2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T12;
        prmT000T12 = new Object[] {
        new ParDef("@UsuAlmSts",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T13;
        prmT000T13 = new Object[] {
        new ParDef("@UsuAlmSts",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T14;
        prmT000T14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT000T16;
        prmT000T16 = new Object[] {
        };
        Object[] prmT000T17;
        prmT000T17 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000T15;
        prmT000T15 = new Object[] {
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000T2", "SELECT [UsuAlmSts], [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T3", "SELECT [UsuAlmSts], [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T4", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T5", "SELECT [AlmDsc] AS UsuAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T6", "SELECT T2.[AlmDsc] AS UsuAlmDsc, TM1.[UsuAlmSts], TM1.[UsuCod], TM1.[UsuAlmCod] AS UsuAlmCod FROM ([SGUSUARIOALMACEN] TM1 INNER JOIN [CALMACEN] T2 ON T2.[AlmCod] = TM1.[UsuAlmCod]) WHERE TM1.[UsuCod] = @UsuCod and TM1.[UsuAlmCod] = @UsuAlmCod ORDER BY TM1.[UsuCod], TM1.[UsuAlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T7", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T8", "SELECT [AlmDsc] AS UsuAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T9", "SELECT [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T10", "SELECT TOP 1 [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WHERE ( [UsuCod] > @UsuCod or [UsuCod] = @UsuCod and [UsuAlmCod] > @UsuAlmCod) ORDER BY [UsuCod], [UsuAlmCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T11", "SELECT TOP 1 [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WHERE ( [UsuCod] < @UsuCod or [UsuCod] = @UsuCod and [UsuAlmCod] < @UsuAlmCod) ORDER BY [UsuCod] DESC, [UsuAlmCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T12", "INSERT INTO [SGUSUARIOALMACEN]([UsuAlmSts], [UsuCod], [UsuAlmCod]) VALUES(@UsuAlmSts, @UsuCod, @UsuAlmCod)", GxErrorMask.GX_NOMASK,prmT000T12)
           ,new CursorDef("T000T13", "UPDATE [SGUSUARIOALMACEN] SET [UsuAlmSts]=@UsuAlmSts  WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod", GxErrorMask.GX_NOMASK,prmT000T13)
           ,new CursorDef("T000T14", "DELETE FROM [SGUSUARIOALMACEN]  WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod", GxErrorMask.GX_NOMASK,prmT000T14)
           ,new CursorDef("T000T15", "SELECT [AlmDsc] AS UsuAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T16", "SELECT [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] ORDER BY [UsuCod], [UsuAlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T17", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T17,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
