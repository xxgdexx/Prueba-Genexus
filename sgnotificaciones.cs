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
   public class sgnotificaciones : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A2241SGNotificacionUsuario = GetPar( "SGNotificacionUsuario");
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A2241SGNotificacionUsuario) ;
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
         GXKey = Crypto.GetSiteKey( );
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
            Form.Meta.addItem("description", "SGNOTIFICACIONES", 0) ;
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

      public sgnotificaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgnotificaciones( IGxContext context )
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGNOTIFICACIONES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGNOTIFICACIONES.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGNOTIFICACIONES.htm");
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2237SGNotificacionID), 10, 0, ".", "")), StringUtil.LTrim( ((edtSGNotificacionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionID_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionTitulo_Internalname, "Titulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionTitulo_Internalname, A2238SGNotificacionTitulo, StringUtil.RTrim( context.localUtil.Format( A2238SGNotificacionTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionTitulo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionDescripcion_Internalname, "Descripción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSGNotificacionDescripcion_Internalname, A2239SGNotificacionDescripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtSGNotificacionDescripcion_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionFecha_Internalname, "Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSGNotificacionFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionFecha_Internalname, context.localUtil.TToC( A2240SGNotificacionFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2240SGNotificacionFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_bitmap( context, edtSGNotificacionFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSGNotificacionFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SGNOTIFICACIONES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionUsuario_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionUsuario_Internalname, StringUtil.RTrim( A2241SGNotificacionUsuario), StringUtil.RTrim( context.localUtil.Format( A2241SGNotificacionUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionUsuario_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionUsuarioDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionUsuarioDsc_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionUsuarioDsc_Internalname, StringUtil.RTrim( A2242SGNotificacionUsuarioDsc), StringUtil.RTrim( context.localUtil.Format( A2242SGNotificacionUsuarioDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionUsuarioDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionUsuarioDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbSGNotificacionIconClass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSGNotificacionIconClass_Internalname, "Icon Class", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSGNotificacionIconClass, cmbSGNotificacionIconClass_Internalname, StringUtil.RTrim( A2243SGNotificacionIconClass), 1, cmbSGNotificacionIconClass_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbSGNotificacionIconClass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 1, "HLP_SGNOTIFICACIONES.htm");
         cmbSGNotificacionIconClass.CurrentValue = StringUtil.RTrim( A2243SGNotificacionIconClass);
         AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Values", (string)(cmbSGNotificacionIconClass.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionTUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionTUsuario_Internalname, "Usuarios", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionTUsuario_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2244SGNotificacionTUsuario), 4, 0, ".", "")), StringUtil.LTrim( ((edtSGNotificacionTUsuario_Enabled!=0) ? context.localUtil.Format( (decimal)(A2244SGNotificacionTUsuario), "ZZZ9") : context.localUtil.Format( (decimal)(A2244SGNotificacionTUsuario), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionTUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionTUsuario_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGNOTIFICACIONES.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONES.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
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
            A2242SGNotificacionUsuarioDsc = cgiGet( edtSGNotificacionUsuarioDsc_Internalname);
            AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", A2242SGNotificacionUsuarioDsc);
            cmbSGNotificacionIconClass.CurrentValue = cgiGet( cmbSGNotificacionIconClass_Internalname);
            A2243SGNotificacionIconClass = cgiGet( cmbSGNotificacionIconClass_Internalname);
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
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
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
               InitAll78198( ) ;
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
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes78198( ) ;
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

      protected void ResetCaption780( )
      {
      }

      protected void ZM78198( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2238SGNotificacionTitulo = T00783_A2238SGNotificacionTitulo[0];
               Z2239SGNotificacionDescripcion = T00783_A2239SGNotificacionDescripcion[0];
               Z2240SGNotificacionFecha = T00783_A2240SGNotificacionFecha[0];
               Z2243SGNotificacionIconClass = T00783_A2243SGNotificacionIconClass[0];
               Z2244SGNotificacionTUsuario = T00783_A2244SGNotificacionTUsuario[0];
               Z2241SGNotificacionUsuario = T00783_A2241SGNotificacionUsuario[0];
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
         if ( GX_JID == -3 )
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
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load78198( )
      {
         /* Using cursor T00785 */
         pr_default.execute(3, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound198 = 1;
            A2238SGNotificacionTitulo = T00785_A2238SGNotificacionTitulo[0];
            AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
            A2239SGNotificacionDescripcion = T00785_A2239SGNotificacionDescripcion[0];
            AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
            A2240SGNotificacionFecha = T00785_A2240SGNotificacionFecha[0];
            AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
            A2242SGNotificacionUsuarioDsc = T00785_A2242SGNotificacionUsuarioDsc[0];
            AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", A2242SGNotificacionUsuarioDsc);
            A2243SGNotificacionIconClass = T00785_A2243SGNotificacionIconClass[0];
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
            A2244SGNotificacionTUsuario = T00785_A2244SGNotificacionTUsuario[0];
            AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
            A2241SGNotificacionUsuario = T00785_A2241SGNotificacionUsuario[0];
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
            ZM78198( -3) ;
         }
         pr_default.close(3);
         OnLoadActions78198( ) ;
      }

      protected void OnLoadActions78198( )
      {
      }

      protected void CheckExtendedTable78198( )
      {
         nIsDirty_198 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2240SGNotificacionFecha) || ( A2240SGNotificacionFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "SGNOTIFICACIONFECHA");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00784 */
         pr_default.execute(2, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2242SGNotificacionUsuarioDsc = T00784_A2242SGNotificacionUsuarioDsc[0];
         AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", A2242SGNotificacionUsuarioDsc);
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-info NotificationFontIconInfoLight") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-clipboard-check NotificationFontIconInfo") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "far fa-thumbs-up NotificationFontIconSuccess") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-exclamation-triangle NotificationFontIconDanger") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Notificación Icon Class fuera de rango", "OutOfRange", 1, "SGNOTIFICACIONICONCLASS");
            AnyError = 1;
            GX_FocusControl = cmbSGNotificacionIconClass_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors78198( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A2241SGNotificacionUsuario )
      {
         /* Using cursor T00786 */
         pr_default.execute(4, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2242SGNotificacionUsuarioDsc = T00786_A2242SGNotificacionUsuarioDsc[0];
         AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", A2242SGNotificacionUsuarioDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2242SGNotificacionUsuarioDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey78198( )
      {
         /* Using cursor T00787 */
         pr_default.execute(5, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound198 = 1;
         }
         else
         {
            RcdFound198 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00783 */
         pr_default.execute(1, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM78198( 3) ;
            RcdFound198 = 1;
            A2237SGNotificacionID = T00783_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            A2238SGNotificacionTitulo = T00783_A2238SGNotificacionTitulo[0];
            AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
            A2239SGNotificacionDescripcion = T00783_A2239SGNotificacionDescripcion[0];
            AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
            A2240SGNotificacionFecha = T00783_A2240SGNotificacionFecha[0];
            AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
            A2243SGNotificacionIconClass = T00783_A2243SGNotificacionIconClass[0];
            AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
            A2244SGNotificacionTUsuario = T00783_A2244SGNotificacionTUsuario[0];
            AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrimStr( (decimal)(A2244SGNotificacionTUsuario), 4, 0));
            A2241SGNotificacionUsuario = T00783_A2241SGNotificacionUsuario[0];
            AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
            Z2237SGNotificacionID = A2237SGNotificacionID;
            sMode198 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load78198( ) ;
            if ( AnyError == 1 )
            {
               RcdFound198 = 0;
               InitializeNonKey78198( ) ;
            }
            Gx_mode = sMode198;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound198 = 0;
            InitializeNonKey78198( ) ;
            sMode198 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode198;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey78198( ) ;
         if ( RcdFound198 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound198 = 0;
         /* Using cursor T00788 */
         pr_default.execute(6, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00788_A2237SGNotificacionID[0] < A2237SGNotificacionID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00788_A2237SGNotificacionID[0] > A2237SGNotificacionID ) ) )
            {
               A2237SGNotificacionID = T00788_A2237SGNotificacionID[0];
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               RcdFound198 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound198 = 0;
         /* Using cursor T00789 */
         pr_default.execute(7, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00789_A2237SGNotificacionID[0] > A2237SGNotificacionID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00789_A2237SGNotificacionID[0] < A2237SGNotificacionID ) ) )
            {
               A2237SGNotificacionID = T00789_A2237SGNotificacionID[0];
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               RcdFound198 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey78198( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert78198( ) ;
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
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update78198( ) ;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2237SGNotificacionID != Z2237SGNotificacionID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert78198( ) ;
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
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSGNotificacionID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert78198( ) ;
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
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound198 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGNotificacionTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart78198( ) ;
         if ( RcdFound198 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd78198( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound198 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound198 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart78198( ) ;
         if ( RcdFound198 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound198 != 0 )
            {
               ScanNext78198( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd78198( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency78198( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00782 */
            pr_default.execute(0, new Object[] {A2237SGNotificacionID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2238SGNotificacionTitulo, T00782_A2238SGNotificacionTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z2239SGNotificacionDescripcion, T00782_A2239SGNotificacionDescripcion[0]) != 0 ) || ( Z2240SGNotificacionFecha != T00782_A2240SGNotificacionFecha[0] ) || ( StringUtil.StrCmp(Z2243SGNotificacionIconClass, T00782_A2243SGNotificacionIconClass[0]) != 0 ) || ( Z2244SGNotificacionTUsuario != T00782_A2244SGNotificacionTUsuario[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2241SGNotificacionUsuario, T00782_A2241SGNotificacionUsuario[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2238SGNotificacionTitulo, T00782_A2238SGNotificacionTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("sgnotificaciones:[seudo value changed for attri]"+"SGNotificacionTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z2238SGNotificacionTitulo);
                  GXUtil.WriteLogRaw("Current: ",T00782_A2238SGNotificacionTitulo[0]);
               }
               if ( StringUtil.StrCmp(Z2239SGNotificacionDescripcion, T00782_A2239SGNotificacionDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("sgnotificaciones:[seudo value changed for attri]"+"SGNotificacionDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z2239SGNotificacionDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00782_A2239SGNotificacionDescripcion[0]);
               }
               if ( Z2240SGNotificacionFecha != T00782_A2240SGNotificacionFecha[0] )
               {
                  GXUtil.WriteLog("sgnotificaciones:[seudo value changed for attri]"+"SGNotificacionFecha");
                  GXUtil.WriteLogRaw("Old: ",Z2240SGNotificacionFecha);
                  GXUtil.WriteLogRaw("Current: ",T00782_A2240SGNotificacionFecha[0]);
               }
               if ( StringUtil.StrCmp(Z2243SGNotificacionIconClass, T00782_A2243SGNotificacionIconClass[0]) != 0 )
               {
                  GXUtil.WriteLog("sgnotificaciones:[seudo value changed for attri]"+"SGNotificacionIconClass");
                  GXUtil.WriteLogRaw("Old: ",Z2243SGNotificacionIconClass);
                  GXUtil.WriteLogRaw("Current: ",T00782_A2243SGNotificacionIconClass[0]);
               }
               if ( Z2244SGNotificacionTUsuario != T00782_A2244SGNotificacionTUsuario[0] )
               {
                  GXUtil.WriteLog("sgnotificaciones:[seudo value changed for attri]"+"SGNotificacionTUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z2244SGNotificacionTUsuario);
                  GXUtil.WriteLogRaw("Current: ",T00782_A2244SGNotificacionTUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z2241SGNotificacionUsuario, T00782_A2241SGNotificacionUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("sgnotificaciones:[seudo value changed for attri]"+"SGNotificacionUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z2241SGNotificacionUsuario);
                  GXUtil.WriteLogRaw("Current: ",T00782_A2241SGNotificacionUsuario[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGNOTIFICACIONES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert78198( )
      {
         BeforeValidate78198( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable78198( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM78198( 0) ;
            CheckOptimisticConcurrency78198( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm78198( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert78198( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007810 */
                     pr_default.execute(8, new Object[] {A2237SGNotificacionID, A2238SGNotificacionTitulo, A2239SGNotificacionDescripcion, A2240SGNotificacionFecha, A2243SGNotificacionIconClass, A2244SGNotificacionTUsuario, A2241SGNotificacionUsuario});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption780( ) ;
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
               Load78198( ) ;
            }
            EndLevel78198( ) ;
         }
         CloseExtendedTableCursors78198( ) ;
      }

      protected void Update78198( )
      {
         BeforeValidate78198( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable78198( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency78198( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm78198( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate78198( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007811 */
                     pr_default.execute(9, new Object[] {A2238SGNotificacionTitulo, A2239SGNotificacionDescripcion, A2240SGNotificacionFecha, A2243SGNotificacionIconClass, A2244SGNotificacionTUsuario, A2241SGNotificacionUsuario, A2237SGNotificacionID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate78198( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption780( ) ;
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
            EndLevel78198( ) ;
         }
         CloseExtendedTableCursors78198( ) ;
      }

      protected void DeferredUpdate78198( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate78198( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency78198( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls78198( ) ;
            AfterConfirm78198( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete78198( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007812 */
                  pr_default.execute(10, new Object[] {A2237SGNotificacionID});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound198 == 0 )
                        {
                           InitAll78198( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption780( ) ;
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
         sMode198 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel78198( ) ;
         Gx_mode = sMode198;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls78198( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007813 */
            pr_default.execute(11, new Object[] {A2241SGNotificacionUsuario});
            A2242SGNotificacionUsuarioDsc = T007813_A2242SGNotificacionUsuarioDsc[0];
            AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", A2242SGNotificacionUsuarioDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007814 */
            pr_default.execute(12, new Object[] {A2237SGNotificacionID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel78198( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete78198( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("sgnotificaciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues780( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("sgnotificaciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart78198( )
      {
         /* Using cursor T007815 */
         pr_default.execute(13);
         RcdFound198 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound198 = 1;
            A2237SGNotificacionID = T007815_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext78198( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound198 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound198 = 1;
            A2237SGNotificacionID = T007815_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         }
      }

      protected void ScanEnd78198( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm78198( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert78198( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate78198( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete78198( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete78198( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate78198( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes78198( )
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
         edtSGNotificacionUsuarioDsc_Enabled = 0;
         AssignProp("", false, edtSGNotificacionUsuarioDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionUsuarioDsc_Enabled), 5, 0), true);
         cmbSGNotificacionIconClass.Enabled = 0;
         AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSGNotificacionIconClass.Enabled), 5, 0), true);
         edtSGNotificacionTUsuario_Enabled = 0;
         AssignProp("", false, edtSGNotificacionTUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionTUsuario_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes78198( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues780( )
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
         context.AddJavascriptSource("gxcfg.js", "?2022818102709", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgnotificaciones.aspx") +"\">") ;
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
         return formatLink("sgnotificaciones.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGNOTIFICACIONES" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGNOTIFICACIONES" ;
      }

      protected void InitializeNonKey78198( )
      {
         A2238SGNotificacionTitulo = "";
         AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
         A2239SGNotificacionDescripcion = "";
         AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 8, 5, 0, 3, "/", ":", " "));
         A2241SGNotificacionUsuario = "";
         AssignAttri("", false, "A2241SGNotificacionUsuario", A2241SGNotificacionUsuario);
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

      protected void InitAll78198( )
      {
         A2237SGNotificacionID = 0;
         AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         InitializeNonKey78198( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027018", true, true);
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
         context.AddJavascriptSource("sgnotificaciones.js", "?20228181027019", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtSGNotificacionID_Internalname = "SGNOTIFICACIONID";
         edtSGNotificacionTitulo_Internalname = "SGNOTIFICACIONTITULO";
         edtSGNotificacionDescripcion_Internalname = "SGNOTIFICACIONDESCRIPCION";
         edtSGNotificacionFecha_Internalname = "SGNOTIFICACIONFECHA";
         edtSGNotificacionUsuario_Internalname = "SGNOTIFICACIONUSUARIO";
         edtSGNotificacionUsuarioDsc_Internalname = "SGNOTIFICACIONUSUARIODSC";
         cmbSGNotificacionIconClass_Internalname = "SGNOTIFICACIONICONCLASS";
         edtSGNotificacionTUsuario_Internalname = "SGNOTIFICACIONTUSUARIO";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "SGNOTIFICACIONES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGNotificacionTUsuario_Jsonclick = "";
         edtSGNotificacionTUsuario_Enabled = 1;
         cmbSGNotificacionIconClass_Jsonclick = "";
         cmbSGNotificacionIconClass.Enabled = 1;
         edtSGNotificacionUsuarioDsc_Jsonclick = "";
         edtSGNotificacionUsuarioDsc_Enabled = 0;
         edtSGNotificacionUsuario_Jsonclick = "";
         edtSGNotificacionUsuario_Enabled = 1;
         edtSGNotificacionFecha_Jsonclick = "";
         edtSGNotificacionFecha_Enabled = 1;
         edtSGNotificacionDescripcion_Enabled = 1;
         edtSGNotificacionTitulo_Jsonclick = "";
         edtSGNotificacionTitulo_Enabled = 1;
         edtSGNotificacionID_Jsonclick = "";
         edtSGNotificacionID_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSGNotificacionTitulo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      public void Valid_Sgnotificacionid( )
      {
         A2243SGNotificacionIconClass = cmbSGNotificacionIconClass.CurrentValue;
         cmbSGNotificacionIconClass.CurrentValue = A2243SGNotificacionIconClass;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbSGNotificacionIconClass.ItemCount > 0 )
         {
            A2243SGNotificacionIconClass = cmbSGNotificacionIconClass.getValidValue(A2243SGNotificacionIconClass);
            cmbSGNotificacionIconClass.CurrentValue = A2243SGNotificacionIconClass;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSGNotificacionIconClass.CurrentValue = StringUtil.RTrim( A2243SGNotificacionIconClass);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2238SGNotificacionTitulo", A2238SGNotificacionTitulo);
         AssignAttri("", false, "A2239SGNotificacionDescripcion", A2239SGNotificacionDescripcion);
         AssignAttri("", false, "A2240SGNotificacionFecha", context.localUtil.TToC( A2240SGNotificacionFecha, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A2241SGNotificacionUsuario", StringUtil.RTrim( A2241SGNotificacionUsuario));
         AssignAttri("", false, "A2243SGNotificacionIconClass", A2243SGNotificacionIconClass);
         cmbSGNotificacionIconClass.CurrentValue = StringUtil.RTrim( A2243SGNotificacionIconClass);
         AssignProp("", false, cmbSGNotificacionIconClass_Internalname, "Values", cmbSGNotificacionIconClass.ToJavascriptSource(), true);
         AssignAttri("", false, "A2244SGNotificacionTUsuario", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2244SGNotificacionTUsuario), 4, 0, ".", "")));
         AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", StringUtil.RTrim( A2242SGNotificacionUsuarioDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2237SGNotificacionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2237SGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2238SGNotificacionTitulo", Z2238SGNotificacionTitulo);
         GxWebStd.gx_hidden_field( context, "Z2239SGNotificacionDescripcion", Z2239SGNotificacionDescripcion);
         GxWebStd.gx_hidden_field( context, "Z2240SGNotificacionFecha", context.localUtil.TToC( Z2240SGNotificacionFecha, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2241SGNotificacionUsuario", StringUtil.RTrim( Z2241SGNotificacionUsuario));
         GxWebStd.gx_hidden_field( context, "Z2243SGNotificacionIconClass", Z2243SGNotificacionIconClass);
         GxWebStd.gx_hidden_field( context, "Z2244SGNotificacionTUsuario", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2244SGNotificacionTUsuario), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2242SGNotificacionUsuarioDsc", StringUtil.RTrim( Z2242SGNotificacionUsuarioDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Sgnotificacionusuario( )
      {
         /* Using cursor T007813 */
         pr_default.execute(11, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionUsuario_Internalname;
         }
         A2242SGNotificacionUsuarioDsc = T007813_A2242SGNotificacionUsuarioDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2242SGNotificacionUsuarioDsc", StringUtil.RTrim( A2242SGNotificacionUsuarioDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONID","{handler:'Valid_Sgnotificacionid',iparms:[{av:'cmbSGNotificacionIconClass'},{av:'A2243SGNotificacionIconClass',fld:'SGNOTIFICACIONICONCLASS',pic:''},{av:'A2237SGNotificacionID',fld:'SGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGNOTIFICACIONID",",oparms:[{av:'A2238SGNotificacionTitulo',fld:'SGNOTIFICACIONTITULO',pic:''},{av:'A2239SGNotificacionDescripcion',fld:'SGNOTIFICACIONDESCRIPCION',pic:''},{av:'A2240SGNotificacionFecha',fld:'SGNOTIFICACIONFECHA',pic:'99/99/99 99:99'},{av:'A2241SGNotificacionUsuario',fld:'SGNOTIFICACIONUSUARIO',pic:''},{av:'cmbSGNotificacionIconClass'},{av:'A2243SGNotificacionIconClass',fld:'SGNOTIFICACIONICONCLASS',pic:''},{av:'A2244SGNotificacionTUsuario',fld:'SGNOTIFICACIONTUSUARIO',pic:'ZZZ9'},{av:'A2242SGNotificacionUsuarioDsc',fld:'SGNOTIFICACIONUSUARIODSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2237SGNotificacionID'},{av:'Z2238SGNotificacionTitulo'},{av:'Z2239SGNotificacionDescripcion'},{av:'Z2240SGNotificacionFecha'},{av:'Z2241SGNotificacionUsuario'},{av:'Z2243SGNotificacionIconClass'},{av:'Z2244SGNotificacionTUsuario'},{av:'Z2242SGNotificacionUsuarioDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SGNOTIFICACIONFECHA","{handler:'Valid_Sgnotificacionfecha',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONFECHA",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONUSUARIO","{handler:'Valid_Sgnotificacionusuario',iparms:[{av:'A2241SGNotificacionUsuario',fld:'SGNOTIFICACIONUSUARIO',pic:''},{av:'A2242SGNotificacionUsuarioDsc',fld:'SGNOTIFICACIONUSUARIODSC',pic:''}]");
         setEventMetadata("VALID_SGNOTIFICACIONUSUARIO",",oparms:[{av:'A2242SGNotificacionUsuarioDsc',fld:'SGNOTIFICACIONUSUARIODSC',pic:''}]}");
         setEventMetadata("VALID_SGNOTIFICACIONICONCLASS","{handler:'Valid_Sgnotificacioniconclass',iparms:[]");
         setEventMetadata("VALID_SGNOTIFICACIONICONCLASS",",oparms:[]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2238SGNotificacionTitulo = "";
         Z2239SGNotificacionDescripcion = "";
         Z2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z2243SGNotificacionIconClass = "";
         Z2241SGNotificacionUsuario = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2241SGNotificacionUsuario = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A2243SGNotificacionIconClass = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2242SGNotificacionUsuarioDsc = "";
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
         Z2242SGNotificacionUsuarioDsc = "";
         T00785_A2237SGNotificacionID = new long[1] ;
         T00785_A2238SGNotificacionTitulo = new string[] {""} ;
         T00785_A2239SGNotificacionDescripcion = new string[] {""} ;
         T00785_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T00785_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T00785_A2243SGNotificacionIconClass = new string[] {""} ;
         T00785_A2244SGNotificacionTUsuario = new short[1] ;
         T00785_A2241SGNotificacionUsuario = new string[] {""} ;
         T00784_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T00786_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T00787_A2237SGNotificacionID = new long[1] ;
         T00783_A2237SGNotificacionID = new long[1] ;
         T00783_A2238SGNotificacionTitulo = new string[] {""} ;
         T00783_A2239SGNotificacionDescripcion = new string[] {""} ;
         T00783_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T00783_A2243SGNotificacionIconClass = new string[] {""} ;
         T00783_A2244SGNotificacionTUsuario = new short[1] ;
         T00783_A2241SGNotificacionUsuario = new string[] {""} ;
         sMode198 = "";
         T00788_A2237SGNotificacionID = new long[1] ;
         T00789_A2237SGNotificacionID = new long[1] ;
         T00782_A2237SGNotificacionID = new long[1] ;
         T00782_A2238SGNotificacionTitulo = new string[] {""} ;
         T00782_A2239SGNotificacionDescripcion = new string[] {""} ;
         T00782_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         T00782_A2243SGNotificacionIconClass = new string[] {""} ;
         T00782_A2244SGNotificacionTUsuario = new short[1] ;
         T00782_A2241SGNotificacionUsuario = new string[] {""} ;
         T007813_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         T007814_A2237SGNotificacionID = new long[1] ;
         T007814_A2245SGNotificacionDetID = new short[1] ;
         T007815_A2237SGNotificacionID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2238SGNotificacionTitulo = "";
         ZZ2239SGNotificacionDescripcion = "";
         ZZ2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         ZZ2241SGNotificacionUsuario = "";
         ZZ2243SGNotificacionIconClass = "";
         ZZ2242SGNotificacionUsuarioDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgnotificaciones__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgnotificaciones__default(),
            new Object[][] {
                new Object[] {
               T00782_A2237SGNotificacionID, T00782_A2238SGNotificacionTitulo, T00782_A2239SGNotificacionDescripcion, T00782_A2240SGNotificacionFecha, T00782_A2243SGNotificacionIconClass, T00782_A2244SGNotificacionTUsuario, T00782_A2241SGNotificacionUsuario
               }
               , new Object[] {
               T00783_A2237SGNotificacionID, T00783_A2238SGNotificacionTitulo, T00783_A2239SGNotificacionDescripcion, T00783_A2240SGNotificacionFecha, T00783_A2243SGNotificacionIconClass, T00783_A2244SGNotificacionTUsuario, T00783_A2241SGNotificacionUsuario
               }
               , new Object[] {
               T00784_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               T00785_A2237SGNotificacionID, T00785_A2238SGNotificacionTitulo, T00785_A2239SGNotificacionDescripcion, T00785_A2240SGNotificacionFecha, T00785_A2242SGNotificacionUsuarioDsc, T00785_A2243SGNotificacionIconClass, T00785_A2244SGNotificacionTUsuario, T00785_A2241SGNotificacionUsuario
               }
               , new Object[] {
               T00786_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               T00787_A2237SGNotificacionID
               }
               , new Object[] {
               T00788_A2237SGNotificacionID
               }
               , new Object[] {
               T00789_A2237SGNotificacionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007813_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               T007814_A2237SGNotificacionID, T007814_A2245SGNotificacionDetID
               }
               , new Object[] {
               T007815_A2237SGNotificacionID
               }
            }
         );
      }

      private short Z2244SGNotificacionTUsuario ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2244SGNotificacionTUsuario ;
      private short GX_JID ;
      private short RcdFound198 ;
      private short nIsDirty_198 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2244SGNotificacionTUsuario ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSGNotificacionID_Enabled ;
      private int edtSGNotificacionTitulo_Enabled ;
      private int edtSGNotificacionDescripcion_Enabled ;
      private int edtSGNotificacionFecha_Enabled ;
      private int edtSGNotificacionUsuario_Enabled ;
      private int edtSGNotificacionUsuarioDsc_Enabled ;
      private int edtSGNotificacionTUsuario_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z2237SGNotificacionID ;
      private long A2237SGNotificacionID ;
      private long ZZ2237SGNotificacionID ;
      private string sPrefix ;
      private string Z2241SGNotificacionUsuario ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2241SGNotificacionUsuario ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSGNotificacionID_Internalname ;
      private string cmbSGNotificacionIconClass_Internalname ;
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
      private string edtSGNotificacionID_Jsonclick ;
      private string edtSGNotificacionTitulo_Internalname ;
      private string edtSGNotificacionTitulo_Jsonclick ;
      private string edtSGNotificacionDescripcion_Internalname ;
      private string edtSGNotificacionFecha_Internalname ;
      private string edtSGNotificacionFecha_Jsonclick ;
      private string edtSGNotificacionUsuario_Internalname ;
      private string edtSGNotificacionUsuario_Jsonclick ;
      private string edtSGNotificacionUsuarioDsc_Internalname ;
      private string A2242SGNotificacionUsuarioDsc ;
      private string edtSGNotificacionUsuarioDsc_Jsonclick ;
      private string cmbSGNotificacionIconClass_Jsonclick ;
      private string edtSGNotificacionTUsuario_Internalname ;
      private string edtSGNotificacionTUsuario_Jsonclick ;
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
      private string Z2242SGNotificacionUsuarioDsc ;
      private string sMode198 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2241SGNotificacionUsuario ;
      private string ZZ2242SGNotificacionUsuarioDsc ;
      private DateTime Z2240SGNotificacionFecha ;
      private DateTime A2240SGNotificacionFecha ;
      private DateTime ZZ2240SGNotificacionFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2238SGNotificacionTitulo ;
      private string Z2239SGNotificacionDescripcion ;
      private string Z2243SGNotificacionIconClass ;
      private string A2243SGNotificacionIconClass ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private string ZZ2238SGNotificacionTitulo ;
      private string ZZ2239SGNotificacionDescripcion ;
      private string ZZ2243SGNotificacionIconClass ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSGNotificacionIconClass ;
      private IDataStoreProvider pr_default ;
      private long[] T00785_A2237SGNotificacionID ;
      private string[] T00785_A2238SGNotificacionTitulo ;
      private string[] T00785_A2239SGNotificacionDescripcion ;
      private DateTime[] T00785_A2240SGNotificacionFecha ;
      private string[] T00785_A2242SGNotificacionUsuarioDsc ;
      private string[] T00785_A2243SGNotificacionIconClass ;
      private short[] T00785_A2244SGNotificacionTUsuario ;
      private string[] T00785_A2241SGNotificacionUsuario ;
      private string[] T00784_A2242SGNotificacionUsuarioDsc ;
      private string[] T00786_A2242SGNotificacionUsuarioDsc ;
      private long[] T00787_A2237SGNotificacionID ;
      private long[] T00783_A2237SGNotificacionID ;
      private string[] T00783_A2238SGNotificacionTitulo ;
      private string[] T00783_A2239SGNotificacionDescripcion ;
      private DateTime[] T00783_A2240SGNotificacionFecha ;
      private string[] T00783_A2243SGNotificacionIconClass ;
      private short[] T00783_A2244SGNotificacionTUsuario ;
      private string[] T00783_A2241SGNotificacionUsuario ;
      private long[] T00788_A2237SGNotificacionID ;
      private long[] T00789_A2237SGNotificacionID ;
      private long[] T00782_A2237SGNotificacionID ;
      private string[] T00782_A2238SGNotificacionTitulo ;
      private string[] T00782_A2239SGNotificacionDescripcion ;
      private DateTime[] T00782_A2240SGNotificacionFecha ;
      private string[] T00782_A2243SGNotificacionIconClass ;
      private short[] T00782_A2244SGNotificacionTUsuario ;
      private string[] T00782_A2241SGNotificacionUsuario ;
      private string[] T007813_A2242SGNotificacionUsuarioDsc ;
      private long[] T007814_A2237SGNotificacionID ;
      private short[] T007814_A2245SGNotificacionDetID ;
      private long[] T007815_A2237SGNotificacionID ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgnotificaciones__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgnotificaciones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00785;
        prmT00785 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00784;
        prmT00784 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT00786;
        prmT00786 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT00787;
        prmT00787 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00783;
        prmT00783 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00788;
        prmT00788 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00789;
        prmT00789 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00782;
        prmT00782 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007810;
        prmT007810 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionTitulo",GXType.NVarChar,100,0) ,
        new ParDef("@SGNotificacionDescripcion",GXType.NVarChar,200,0) ,
        new ParDef("@SGNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGNotificacionIconClass",GXType.NVarChar,60,0) ,
        new ParDef("@SGNotificacionTUsuario",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007811;
        prmT007811 = new Object[] {
        new ParDef("@SGNotificacionTitulo",GXType.NVarChar,100,0) ,
        new ParDef("@SGNotificacionDescripcion",GXType.NVarChar,200,0) ,
        new ParDef("@SGNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGNotificacionIconClass",GXType.NVarChar,60,0) ,
        new ParDef("@SGNotificacionTUsuario",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007812;
        prmT007812 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007814;
        prmT007814 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007815;
        prmT007815 = new Object[] {
        };
        Object[] prmT007813;
        prmT007813 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00782", "SELECT [SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario] AS SGNotificacionUsuario FROM [SGNOTIFICACIONES] WITH (UPDLOCK) WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00782,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00783", "SELECT [SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario] AS SGNotificacionUsuario FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00783,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00784", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT00784,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00785", "SELECT TM1.[SGNotificacionID], TM1.[SGNotificacionTitulo], TM1.[SGNotificacionDescripcion], TM1.[SGNotificacionFecha], T2.[UsuNom] AS SGNotificacionUsuarioDsc, TM1.[SGNotificacionIconClass], TM1.[SGNotificacionTUsuario], TM1.[SGNotificacionUsuario] AS SGNotificacionUsuario FROM ([SGNOTIFICACIONES] TM1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = TM1.[SGNotificacionUsuario]) WHERE TM1.[SGNotificacionID] = @SGNotificacionID ORDER BY TM1.[SGNotificacionID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00785,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00786", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT00786,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00787", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00787,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00788", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE ( [SGNotificacionID] > @SGNotificacionID) ORDER BY [SGNotificacionID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00788,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00789", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE ( [SGNotificacionID] < @SGNotificacionID) ORDER BY [SGNotificacionID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00789,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007810", "INSERT INTO [SGNOTIFICACIONES]([SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario]) VALUES(@SGNotificacionID, @SGNotificacionTitulo, @SGNotificacionDescripcion, @SGNotificacionFecha, @SGNotificacionIconClass, @SGNotificacionTUsuario, @SGNotificacionUsuario)", GxErrorMask.GX_NOMASK,prmT007810)
           ,new CursorDef("T007811", "UPDATE [SGNOTIFICACIONES] SET [SGNotificacionTitulo]=@SGNotificacionTitulo, [SGNotificacionDescripcion]=@SGNotificacionDescripcion, [SGNotificacionFecha]=@SGNotificacionFecha, [SGNotificacionIconClass]=@SGNotificacionIconClass, [SGNotificacionTUsuario]=@SGNotificacionTUsuario, [SGNotificacionUsuario]=@SGNotificacionUsuario  WHERE [SGNotificacionID] = @SGNotificacionID", GxErrorMask.GX_NOMASK,prmT007811)
           ,new CursorDef("T007812", "DELETE FROM [SGNOTIFICACIONES]  WHERE [SGNotificacionID] = @SGNotificacionID", GxErrorMask.GX_NOMASK,prmT007812)
           ,new CursorDef("T007813", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007813,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007814", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007814,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007815", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] ORDER BY [SGNotificacionID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007815,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
