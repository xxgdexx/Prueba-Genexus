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
namespace GeneXus.Programs.reloj_interface {
   public class v_reloj_asistencia : GXDataArea
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
            Form.Meta.addItem("description", "V_Reloj_Asistencia", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public v_reloj_asistencia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public v_reloj_asistencia( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "V_Reloj_Asistencia", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_Internalname, "id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2467id), 9, 0, ".", "")), StringUtil.LTrim( ((edtid_Enabled!=0) ? context.localUtil.Format( (decimal)(A2467id), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2467id), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCod_EmpReloj_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCod_EmpReloj_Internalname, "Cod_Emp Reloj", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCod_EmpReloj_Internalname, A2468Cod_EmpReloj, StringUtil.RTrim( context.localUtil.Format( A2468Cod_EmpReloj, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_EmpReloj_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_EmpReloj_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNombre_Internalname, A2380Nombre, StringUtil.RTrim( context.localUtil.Format( A2380Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNombre_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtApellido_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtApellido_Internalname, "Apellido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtApellido_Internalname, A2469Apellido, StringUtil.RTrim( context.localUtil.Format( A2469Apellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtApellido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtApellido_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMarcacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMarcacion_Internalname, "Marcacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMarcacion_Internalname, A2470Marcacion, StringUtil.RTrim( context.localUtil.Format( A2470Marcacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMarcacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMarcacion_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFec_Marcacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFec_Marcacion_Internalname, "Fec_Marcacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFec_Marcacion_Internalname, A2471Fec_Marcacion, StringUtil.RTrim( context.localUtil.Format( A2471Fec_Marcacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFec_Marcacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFec_Marcacion_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHor_Marcacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHor_Marcacion_Internalname, "Hor_Marcacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHor_Marcacion_Internalname, A2472Hor_Marcacion, StringUtil.RTrim( context.localUtil.Format( A2472Hor_Marcacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHor_Marcacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHor_Marcacion_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAnio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAnio_Internalname, "Anio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAnio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2473Anio), 9, 0, ".", "")), StringUtil.LTrim( ((edtAnio_Enabled!=0) ? context.localUtil.Format( (decimal)(A2473Anio), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2473Anio), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAnio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAnio_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtmes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtmes_Internalname, "mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2474mes), 9, 0, ".", "")), StringUtil.LTrim( ((edtmes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2474mes), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2474mes), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtmes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtmes_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtdia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdia_Internalname, "dia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtdia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2475dia), 9, 0, ".", "")), StringUtil.LTrim( ((edtdia_Enabled!=0) ? context.localUtil.Format( (decimal)(A2475dia), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2475dia), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtdia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtdia_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\V_Reloj_Asistencia.htm");
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
            Z2467id = (int)(context.localUtil.CToN( cgiGet( "Z2467id"), ".", ","));
            Z2468Cod_EmpReloj = cgiGet( "Z2468Cod_EmpReloj");
            Z2380Nombre = cgiGet( "Z2380Nombre");
            Z2469Apellido = cgiGet( "Z2469Apellido");
            Z2470Marcacion = cgiGet( "Z2470Marcacion");
            Z2471Fec_Marcacion = cgiGet( "Z2471Fec_Marcacion");
            Z2472Hor_Marcacion = cgiGet( "Z2472Hor_Marcacion");
            Z2473Anio = (int)(context.localUtil.CToN( cgiGet( "Z2473Anio"), ".", ","));
            Z2474mes = (int)(context.localUtil.CToN( cgiGet( "Z2474mes"), ".", ","));
            Z2475dia = (int)(context.localUtil.CToN( cgiGet( "Z2475dia"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID");
               AnyError = 1;
               GX_FocusControl = edtid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2467id = 0;
               AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
            }
            else
            {
               A2467id = (int)(context.localUtil.CToN( cgiGet( edtid_Internalname), ".", ","));
               AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
            }
            A2468Cod_EmpReloj = cgiGet( edtCod_EmpReloj_Internalname);
            AssignAttri("", false, "A2468Cod_EmpReloj", A2468Cod_EmpReloj);
            A2380Nombre = cgiGet( edtNombre_Internalname);
            AssignAttri("", false, "A2380Nombre", A2380Nombre);
            A2469Apellido = cgiGet( edtApellido_Internalname);
            AssignAttri("", false, "A2469Apellido", A2469Apellido);
            A2470Marcacion = cgiGet( edtMarcacion_Internalname);
            AssignAttri("", false, "A2470Marcacion", A2470Marcacion);
            A2471Fec_Marcacion = cgiGet( edtFec_Marcacion_Internalname);
            AssignAttri("", false, "A2471Fec_Marcacion", A2471Fec_Marcacion);
            A2472Hor_Marcacion = cgiGet( edtHor_Marcacion_Internalname);
            AssignAttri("", false, "A2472Hor_Marcacion", A2472Hor_Marcacion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAnio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAnio_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ANIO");
               AnyError = 1;
               GX_FocusControl = edtAnio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2473Anio = 0;
               AssignAttri("", false, "A2473Anio", StringUtil.LTrimStr( (decimal)(A2473Anio), 9, 0));
            }
            else
            {
               A2473Anio = (int)(context.localUtil.CToN( cgiGet( edtAnio_Internalname), ".", ","));
               AssignAttri("", false, "A2473Anio", StringUtil.LTrimStr( (decimal)(A2473Anio), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtmes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtmes_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MES");
               AnyError = 1;
               GX_FocusControl = edtmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2474mes = 0;
               AssignAttri("", false, "A2474mes", StringUtil.LTrimStr( (decimal)(A2474mes), 9, 0));
            }
            else
            {
               A2474mes = (int)(context.localUtil.CToN( cgiGet( edtmes_Internalname), ".", ","));
               AssignAttri("", false, "A2474mes", StringUtil.LTrimStr( (decimal)(A2474mes), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtdia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtdia_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DIA");
               AnyError = 1;
               GX_FocusControl = edtdia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2475dia = 0;
               AssignAttri("", false, "A2475dia", StringUtil.LTrimStr( (decimal)(A2475dia), 9, 0));
            }
            else
            {
               A2475dia = (int)(context.localUtil.CToN( cgiGet( edtdia_Internalname), ".", ","));
               AssignAttri("", false, "A2475dia", StringUtil.LTrimStr( (decimal)(A2475dia), 9, 0));
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
               A2467id = (int)(NumberUtil.Val( GetPar( "id"), "."));
               AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
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
               InitAll7U216( ) ;
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
         DisableAttributes7U216( ) ;
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

      protected void ResetCaption7U0( )
      {
      }

      protected void ZM7U216( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2468Cod_EmpReloj = T007U3_A2468Cod_EmpReloj[0];
               Z2380Nombre = T007U3_A2380Nombre[0];
               Z2469Apellido = T007U3_A2469Apellido[0];
               Z2470Marcacion = T007U3_A2470Marcacion[0];
               Z2471Fec_Marcacion = T007U3_A2471Fec_Marcacion[0];
               Z2472Hor_Marcacion = T007U3_A2472Hor_Marcacion[0];
               Z2473Anio = T007U3_A2473Anio[0];
               Z2474mes = T007U3_A2474mes[0];
               Z2475dia = T007U3_A2475dia[0];
            }
            else
            {
               Z2468Cod_EmpReloj = A2468Cod_EmpReloj;
               Z2380Nombre = A2380Nombre;
               Z2469Apellido = A2469Apellido;
               Z2470Marcacion = A2470Marcacion;
               Z2471Fec_Marcacion = A2471Fec_Marcacion;
               Z2472Hor_Marcacion = A2472Hor_Marcacion;
               Z2473Anio = A2473Anio;
               Z2474mes = A2474mes;
               Z2475dia = A2475dia;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2467id = A2467id;
            Z2468Cod_EmpReloj = A2468Cod_EmpReloj;
            Z2380Nombre = A2380Nombre;
            Z2469Apellido = A2469Apellido;
            Z2470Marcacion = A2470Marcacion;
            Z2471Fec_Marcacion = A2471Fec_Marcacion;
            Z2472Hor_Marcacion = A2472Hor_Marcacion;
            Z2473Anio = A2473Anio;
            Z2474mes = A2474mes;
            Z2475dia = A2475dia;
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

      protected void Load7U216( )
      {
         /* Using cursor T007U4 */
         pr_default.execute(2, new Object[] {A2467id});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound216 = 1;
            A2468Cod_EmpReloj = T007U4_A2468Cod_EmpReloj[0];
            AssignAttri("", false, "A2468Cod_EmpReloj", A2468Cod_EmpReloj);
            A2380Nombre = T007U4_A2380Nombre[0];
            AssignAttri("", false, "A2380Nombre", A2380Nombre);
            A2469Apellido = T007U4_A2469Apellido[0];
            AssignAttri("", false, "A2469Apellido", A2469Apellido);
            A2470Marcacion = T007U4_A2470Marcacion[0];
            AssignAttri("", false, "A2470Marcacion", A2470Marcacion);
            A2471Fec_Marcacion = T007U4_A2471Fec_Marcacion[0];
            AssignAttri("", false, "A2471Fec_Marcacion", A2471Fec_Marcacion);
            A2472Hor_Marcacion = T007U4_A2472Hor_Marcacion[0];
            AssignAttri("", false, "A2472Hor_Marcacion", A2472Hor_Marcacion);
            A2473Anio = T007U4_A2473Anio[0];
            AssignAttri("", false, "A2473Anio", StringUtil.LTrimStr( (decimal)(A2473Anio), 9, 0));
            A2474mes = T007U4_A2474mes[0];
            AssignAttri("", false, "A2474mes", StringUtil.LTrimStr( (decimal)(A2474mes), 9, 0));
            A2475dia = T007U4_A2475dia[0];
            AssignAttri("", false, "A2475dia", StringUtil.LTrimStr( (decimal)(A2475dia), 9, 0));
            ZM7U216( -1) ;
         }
         pr_default.close(2);
         OnLoadActions7U216( ) ;
      }

      protected void OnLoadActions7U216( )
      {
      }

      protected void CheckExtendedTable7U216( )
      {
         nIsDirty_216 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors7U216( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7U216( )
      {
         /* Using cursor T007U5 */
         pr_default.execute(3, new Object[] {A2467id});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound216 = 1;
         }
         else
         {
            RcdFound216 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007U3 */
         pr_default.execute(1, new Object[] {A2467id});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7U216( 1) ;
            RcdFound216 = 1;
            A2467id = T007U3_A2467id[0];
            AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
            A2468Cod_EmpReloj = T007U3_A2468Cod_EmpReloj[0];
            AssignAttri("", false, "A2468Cod_EmpReloj", A2468Cod_EmpReloj);
            A2380Nombre = T007U3_A2380Nombre[0];
            AssignAttri("", false, "A2380Nombre", A2380Nombre);
            A2469Apellido = T007U3_A2469Apellido[0];
            AssignAttri("", false, "A2469Apellido", A2469Apellido);
            A2470Marcacion = T007U3_A2470Marcacion[0];
            AssignAttri("", false, "A2470Marcacion", A2470Marcacion);
            A2471Fec_Marcacion = T007U3_A2471Fec_Marcacion[0];
            AssignAttri("", false, "A2471Fec_Marcacion", A2471Fec_Marcacion);
            A2472Hor_Marcacion = T007U3_A2472Hor_Marcacion[0];
            AssignAttri("", false, "A2472Hor_Marcacion", A2472Hor_Marcacion);
            A2473Anio = T007U3_A2473Anio[0];
            AssignAttri("", false, "A2473Anio", StringUtil.LTrimStr( (decimal)(A2473Anio), 9, 0));
            A2474mes = T007U3_A2474mes[0];
            AssignAttri("", false, "A2474mes", StringUtil.LTrimStr( (decimal)(A2474mes), 9, 0));
            A2475dia = T007U3_A2475dia[0];
            AssignAttri("", false, "A2475dia", StringUtil.LTrimStr( (decimal)(A2475dia), 9, 0));
            Z2467id = A2467id;
            sMode216 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7U216( ) ;
            if ( AnyError == 1 )
            {
               RcdFound216 = 0;
               InitializeNonKey7U216( ) ;
            }
            Gx_mode = sMode216;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound216 = 0;
            InitializeNonKey7U216( ) ;
            sMode216 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode216;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7U216( ) ;
         if ( RcdFound216 == 0 )
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
         RcdFound216 = 0;
         /* Using cursor T007U6 */
         pr_default.execute(4, new Object[] {A2467id});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T007U6_A2467id[0] < A2467id ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T007U6_A2467id[0] > A2467id ) ) )
            {
               A2467id = T007U6_A2467id[0];
               AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
               RcdFound216 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound216 = 0;
         /* Using cursor T007U7 */
         pr_default.execute(5, new Object[] {A2467id});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T007U7_A2467id[0] > A2467id ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T007U7_A2467id[0] < A2467id ) ) )
            {
               A2467id = T007U7_A2467id[0];
               AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
               RcdFound216 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7U216( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7U216( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound216 == 1 )
            {
               if ( A2467id != Z2467id )
               {
                  A2467id = Z2467id;
                  AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ID");
                  AnyError = 1;
                  GX_FocusControl = edtid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7U216( ) ;
                  GX_FocusControl = edtid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2467id != Z2467id )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7U216( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ID");
                     AnyError = 1;
                     GX_FocusControl = edtid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7U216( ) ;
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
         if ( A2467id != Z2467id )
         {
            A2467id = Z2467id;
            AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ID");
            AnyError = 1;
            GX_FocusControl = edtid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtid_Internalname;
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
         if ( RcdFound216 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ID");
            AnyError = 1;
            GX_FocusControl = edtid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCod_EmpReloj_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7U216( ) ;
         if ( RcdFound216 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCod_EmpReloj_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7U216( ) ;
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
         if ( RcdFound216 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCod_EmpReloj_Internalname;
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
         if ( RcdFound216 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCod_EmpReloj_Internalname;
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
         ScanStart7U216( ) ;
         if ( RcdFound216 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound216 != 0 )
            {
               ScanNext7U216( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCod_EmpReloj_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7U216( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7U216( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007U2 */
            pr_default.execute(0, new Object[] {A2467id});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"V_Reloj_Asistencia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2468Cod_EmpReloj, T007U2_A2468Cod_EmpReloj[0]) != 0 ) || ( StringUtil.StrCmp(Z2380Nombre, T007U2_A2380Nombre[0]) != 0 ) || ( StringUtil.StrCmp(Z2469Apellido, T007U2_A2469Apellido[0]) != 0 ) || ( StringUtil.StrCmp(Z2470Marcacion, T007U2_A2470Marcacion[0]) != 0 ) || ( StringUtil.StrCmp(Z2471Fec_Marcacion, T007U2_A2471Fec_Marcacion[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2472Hor_Marcacion, T007U2_A2472Hor_Marcacion[0]) != 0 ) || ( Z2473Anio != T007U2_A2473Anio[0] ) || ( Z2474mes != T007U2_A2474mes[0] ) || ( Z2475dia != T007U2_A2475dia[0] ) )
            {
               if ( StringUtil.StrCmp(Z2468Cod_EmpReloj, T007U2_A2468Cod_EmpReloj[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Cod_EmpReloj");
                  GXUtil.WriteLogRaw("Old: ",Z2468Cod_EmpReloj);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2468Cod_EmpReloj[0]);
               }
               if ( StringUtil.StrCmp(Z2380Nombre, T007U2_A2380Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z2380Nombre);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2380Nombre[0]);
               }
               if ( StringUtil.StrCmp(Z2469Apellido, T007U2_A2469Apellido[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Apellido");
                  GXUtil.WriteLogRaw("Old: ",Z2469Apellido);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2469Apellido[0]);
               }
               if ( StringUtil.StrCmp(Z2470Marcacion, T007U2_A2470Marcacion[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Marcacion");
                  GXUtil.WriteLogRaw("Old: ",Z2470Marcacion);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2470Marcacion[0]);
               }
               if ( StringUtil.StrCmp(Z2471Fec_Marcacion, T007U2_A2471Fec_Marcacion[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Fec_Marcacion");
                  GXUtil.WriteLogRaw("Old: ",Z2471Fec_Marcacion);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2471Fec_Marcacion[0]);
               }
               if ( StringUtil.StrCmp(Z2472Hor_Marcacion, T007U2_A2472Hor_Marcacion[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Hor_Marcacion");
                  GXUtil.WriteLogRaw("Old: ",Z2472Hor_Marcacion);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2472Hor_Marcacion[0]);
               }
               if ( Z2473Anio != T007U2_A2473Anio[0] )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"Anio");
                  GXUtil.WriteLogRaw("Old: ",Z2473Anio);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2473Anio[0]);
               }
               if ( Z2474mes != T007U2_A2474mes[0] )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"mes");
                  GXUtil.WriteLogRaw("Old: ",Z2474mes);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2474mes[0]);
               }
               if ( Z2475dia != T007U2_A2475dia[0] )
               {
                  GXUtil.WriteLog("reloj_interface.v_reloj_asistencia:[seudo value changed for attri]"+"dia");
                  GXUtil.WriteLogRaw("Old: ",Z2475dia);
                  GXUtil.WriteLogRaw("Current: ",T007U2_A2475dia[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"V_Reloj_Asistencia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7U216( )
      {
         BeforeValidate7U216( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7U216( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7U216( 0) ;
            CheckOptimisticConcurrency7U216( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7U216( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7U216( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007U8 */
                     pr_default.execute(6, new Object[] {A2468Cod_EmpReloj, A2380Nombre, A2469Apellido, A2470Marcacion, A2471Fec_Marcacion, A2472Hor_Marcacion, A2473Anio, A2474mes, A2475dia});
                     A2467id = T007U8_A2467id[0];
                     AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("V_Reloj_Asistencia");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption7U0( ) ;
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
               Load7U216( ) ;
            }
            EndLevel7U216( ) ;
         }
         CloseExtendedTableCursors7U216( ) ;
      }

      protected void Update7U216( )
      {
         BeforeValidate7U216( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7U216( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7U216( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7U216( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7U216( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007U9 */
                     pr_default.execute(7, new Object[] {A2468Cod_EmpReloj, A2380Nombre, A2469Apellido, A2470Marcacion, A2471Fec_Marcacion, A2472Hor_Marcacion, A2473Anio, A2474mes, A2475dia, A2467id});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("V_Reloj_Asistencia");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"V_Reloj_Asistencia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7U216( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7U0( ) ;
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
            EndLevel7U216( ) ;
         }
         CloseExtendedTableCursors7U216( ) ;
      }

      protected void DeferredUpdate7U216( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7U216( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7U216( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7U216( ) ;
            AfterConfirm7U216( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7U216( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007U10 */
                  pr_default.execute(8, new Object[] {A2467id});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("V_Reloj_Asistencia");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound216 == 0 )
                        {
                           InitAll7U216( ) ;
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
                        ResetCaption7U0( ) ;
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
         sMode216 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7U216( ) ;
         Gx_mode = sMode216;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7U216( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7U216( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7U216( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("reloj_interface.v_reloj_asistencia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("reloj_interface.v_reloj_asistencia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7U216( )
      {
         /* Using cursor T007U11 */
         pr_default.execute(9);
         RcdFound216 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound216 = 1;
            A2467id = T007U11_A2467id[0];
            AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7U216( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound216 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound216 = 1;
            A2467id = T007U11_A2467id[0];
            AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
         }
      }

      protected void ScanEnd7U216( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm7U216( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7U216( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7U216( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7U216( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7U216( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7U216( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7U216( )
      {
         edtid_Enabled = 0;
         AssignProp("", false, edtid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_Enabled), 5, 0), true);
         edtCod_EmpReloj_Enabled = 0;
         AssignProp("", false, edtCod_EmpReloj_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_EmpReloj_Enabled), 5, 0), true);
         edtNombre_Enabled = 0;
         AssignProp("", false, edtNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNombre_Enabled), 5, 0), true);
         edtApellido_Enabled = 0;
         AssignProp("", false, edtApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtApellido_Enabled), 5, 0), true);
         edtMarcacion_Enabled = 0;
         AssignProp("", false, edtMarcacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMarcacion_Enabled), 5, 0), true);
         edtFec_Marcacion_Enabled = 0;
         AssignProp("", false, edtFec_Marcacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFec_Marcacion_Enabled), 5, 0), true);
         edtHor_Marcacion_Enabled = 0;
         AssignProp("", false, edtHor_Marcacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHor_Marcacion_Enabled), 5, 0), true);
         edtAnio_Enabled = 0;
         AssignProp("", false, edtAnio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAnio_Enabled), 5, 0), true);
         edtmes_Enabled = 0;
         AssignProp("", false, edtmes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtmes_Enabled), 5, 0), true);
         edtdia_Enabled = 0;
         AssignProp("", false, edtdia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdia_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7U216( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7U0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271910", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.v_reloj_asistencia.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2467id", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2467id), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2468Cod_EmpReloj", Z2468Cod_EmpReloj);
         GxWebStd.gx_hidden_field( context, "Z2380Nombre", Z2380Nombre);
         GxWebStd.gx_hidden_field( context, "Z2469Apellido", Z2469Apellido);
         GxWebStd.gx_hidden_field( context, "Z2470Marcacion", Z2470Marcacion);
         GxWebStd.gx_hidden_field( context, "Z2471Fec_Marcacion", Z2471Fec_Marcacion);
         GxWebStd.gx_hidden_field( context, "Z2472Hor_Marcacion", Z2472Hor_Marcacion);
         GxWebStd.gx_hidden_field( context, "Z2473Anio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2473Anio), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2474mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2474mes), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2475dia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2475dia), 9, 0, ".", "")));
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
         return formatLink("reloj_interface.v_reloj_asistencia.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.V_Reloj_Asistencia" ;
      }

      public override string GetPgmdesc( )
      {
         return "V_Reloj_Asistencia" ;
      }

      protected void InitializeNonKey7U216( )
      {
         A2468Cod_EmpReloj = "";
         AssignAttri("", false, "A2468Cod_EmpReloj", A2468Cod_EmpReloj);
         A2380Nombre = "";
         AssignAttri("", false, "A2380Nombre", A2380Nombre);
         A2469Apellido = "";
         AssignAttri("", false, "A2469Apellido", A2469Apellido);
         A2470Marcacion = "";
         AssignAttri("", false, "A2470Marcacion", A2470Marcacion);
         A2471Fec_Marcacion = "";
         AssignAttri("", false, "A2471Fec_Marcacion", A2471Fec_Marcacion);
         A2472Hor_Marcacion = "";
         AssignAttri("", false, "A2472Hor_Marcacion", A2472Hor_Marcacion);
         A2473Anio = 0;
         AssignAttri("", false, "A2473Anio", StringUtil.LTrimStr( (decimal)(A2473Anio), 9, 0));
         A2474mes = 0;
         AssignAttri("", false, "A2474mes", StringUtil.LTrimStr( (decimal)(A2474mes), 9, 0));
         A2475dia = 0;
         AssignAttri("", false, "A2475dia", StringUtil.LTrimStr( (decimal)(A2475dia), 9, 0));
         Z2468Cod_EmpReloj = "";
         Z2380Nombre = "";
         Z2469Apellido = "";
         Z2470Marcacion = "";
         Z2471Fec_Marcacion = "";
         Z2472Hor_Marcacion = "";
         Z2473Anio = 0;
         Z2474mes = 0;
         Z2475dia = 0;
      }

      protected void InitAll7U216( )
      {
         A2467id = 0;
         AssignAttri("", false, "A2467id", StringUtil.LTrimStr( (decimal)(A2467id), 9, 0));
         InitializeNonKey7U216( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271919", true, true);
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
         context.AddJavascriptSource("reloj_interface/v_reloj_asistencia.js", "?202281810271919", false, true);
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
         edtid_Internalname = "ID";
         edtCod_EmpReloj_Internalname = "COD_EMPRELOJ";
         edtNombre_Internalname = "NOMBRE";
         edtApellido_Internalname = "APELLIDO";
         edtMarcacion_Internalname = "MARCACION";
         edtFec_Marcacion_Internalname = "FEC_MARCACION";
         edtHor_Marcacion_Internalname = "HOR_MARCACION";
         edtAnio_Internalname = "ANIO";
         edtmes_Internalname = "MES";
         edtdia_Internalname = "DIA";
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
         Form.Caption = "V_Reloj_Asistencia";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtdia_Jsonclick = "";
         edtdia_Enabled = 1;
         edtmes_Jsonclick = "";
         edtmes_Enabled = 1;
         edtAnio_Jsonclick = "";
         edtAnio_Enabled = 1;
         edtHor_Marcacion_Jsonclick = "";
         edtHor_Marcacion_Enabled = 1;
         edtFec_Marcacion_Jsonclick = "";
         edtFec_Marcacion_Enabled = 1;
         edtMarcacion_Jsonclick = "";
         edtMarcacion_Enabled = 1;
         edtApellido_Jsonclick = "";
         edtApellido_Enabled = 1;
         edtNombre_Jsonclick = "";
         edtNombre_Enabled = 1;
         edtCod_EmpReloj_Jsonclick = "";
         edtCod_EmpReloj_Enabled = 1;
         edtid_Jsonclick = "";
         edtid_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCod_EmpReloj_Internalname;
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

      public void Valid_Id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2468Cod_EmpReloj", A2468Cod_EmpReloj);
         AssignAttri("", false, "A2380Nombre", A2380Nombre);
         AssignAttri("", false, "A2469Apellido", A2469Apellido);
         AssignAttri("", false, "A2470Marcacion", A2470Marcacion);
         AssignAttri("", false, "A2471Fec_Marcacion", A2471Fec_Marcacion);
         AssignAttri("", false, "A2472Hor_Marcacion", A2472Hor_Marcacion);
         AssignAttri("", false, "A2473Anio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2473Anio), 9, 0, ".", "")));
         AssignAttri("", false, "A2474mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2474mes), 9, 0, ".", "")));
         AssignAttri("", false, "A2475dia", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2475dia), 9, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2467id", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2467id), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2468Cod_EmpReloj", Z2468Cod_EmpReloj);
         GxWebStd.gx_hidden_field( context, "Z2380Nombre", Z2380Nombre);
         GxWebStd.gx_hidden_field( context, "Z2469Apellido", Z2469Apellido);
         GxWebStd.gx_hidden_field( context, "Z2470Marcacion", Z2470Marcacion);
         GxWebStd.gx_hidden_field( context, "Z2471Fec_Marcacion", Z2471Fec_Marcacion);
         GxWebStd.gx_hidden_field( context, "Z2472Hor_Marcacion", Z2472Hor_Marcacion);
         GxWebStd.gx_hidden_field( context, "Z2473Anio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2473Anio), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2474mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2474mes), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2475dia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2475dia), 9, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("VALID_ID","{handler:'Valid_Id',iparms:[{av:'A2467id',fld:'ID',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ID",",oparms:[{av:'A2468Cod_EmpReloj',fld:'COD_EMPRELOJ',pic:''},{av:'A2380Nombre',fld:'NOMBRE',pic:''},{av:'A2469Apellido',fld:'APELLIDO',pic:''},{av:'A2470Marcacion',fld:'MARCACION',pic:''},{av:'A2471Fec_Marcacion',fld:'FEC_MARCACION',pic:''},{av:'A2472Hor_Marcacion',fld:'HOR_MARCACION',pic:''},{av:'A2473Anio',fld:'ANIO',pic:'ZZZZZZZZ9'},{av:'A2474mes',fld:'MES',pic:'ZZZZZZZZ9'},{av:'A2475dia',fld:'DIA',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2467id'},{av:'Z2468Cod_EmpReloj'},{av:'Z2380Nombre'},{av:'Z2469Apellido'},{av:'Z2470Marcacion'},{av:'Z2471Fec_Marcacion'},{av:'Z2472Hor_Marcacion'},{av:'Z2473Anio'},{av:'Z2474mes'},{av:'Z2475dia'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z2468Cod_EmpReloj = "";
         Z2380Nombre = "";
         Z2469Apellido = "";
         Z2470Marcacion = "";
         Z2471Fec_Marcacion = "";
         Z2472Hor_Marcacion = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
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
         A2468Cod_EmpReloj = "";
         A2380Nombre = "";
         A2469Apellido = "";
         A2470Marcacion = "";
         A2471Fec_Marcacion = "";
         A2472Hor_Marcacion = "";
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
         T007U4_A2467id = new int[1] ;
         T007U4_A2468Cod_EmpReloj = new string[] {""} ;
         T007U4_A2380Nombre = new string[] {""} ;
         T007U4_A2469Apellido = new string[] {""} ;
         T007U4_A2470Marcacion = new string[] {""} ;
         T007U4_A2471Fec_Marcacion = new string[] {""} ;
         T007U4_A2472Hor_Marcacion = new string[] {""} ;
         T007U4_A2473Anio = new int[1] ;
         T007U4_A2474mes = new int[1] ;
         T007U4_A2475dia = new int[1] ;
         T007U5_A2467id = new int[1] ;
         T007U3_A2467id = new int[1] ;
         T007U3_A2468Cod_EmpReloj = new string[] {""} ;
         T007U3_A2380Nombre = new string[] {""} ;
         T007U3_A2469Apellido = new string[] {""} ;
         T007U3_A2470Marcacion = new string[] {""} ;
         T007U3_A2471Fec_Marcacion = new string[] {""} ;
         T007U3_A2472Hor_Marcacion = new string[] {""} ;
         T007U3_A2473Anio = new int[1] ;
         T007U3_A2474mes = new int[1] ;
         T007U3_A2475dia = new int[1] ;
         sMode216 = "";
         T007U6_A2467id = new int[1] ;
         T007U7_A2467id = new int[1] ;
         T007U2_A2467id = new int[1] ;
         T007U2_A2468Cod_EmpReloj = new string[] {""} ;
         T007U2_A2380Nombre = new string[] {""} ;
         T007U2_A2469Apellido = new string[] {""} ;
         T007U2_A2470Marcacion = new string[] {""} ;
         T007U2_A2471Fec_Marcacion = new string[] {""} ;
         T007U2_A2472Hor_Marcacion = new string[] {""} ;
         T007U2_A2473Anio = new int[1] ;
         T007U2_A2474mes = new int[1] ;
         T007U2_A2475dia = new int[1] ;
         T007U8_A2467id = new int[1] ;
         T007U11_A2467id = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2468Cod_EmpReloj = "";
         ZZ2380Nombre = "";
         ZZ2469Apellido = "";
         ZZ2470Marcacion = "";
         ZZ2471Fec_Marcacion = "";
         ZZ2472Hor_Marcacion = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.v_reloj_asistencia__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.v_reloj_asistencia__default(),
            new Object[][] {
                new Object[] {
               T007U2_A2467id, T007U2_A2468Cod_EmpReloj, T007U2_A2380Nombre, T007U2_A2469Apellido, T007U2_A2470Marcacion, T007U2_A2471Fec_Marcacion, T007U2_A2472Hor_Marcacion, T007U2_A2473Anio, T007U2_A2474mes, T007U2_A2475dia
               }
               , new Object[] {
               T007U3_A2467id, T007U3_A2468Cod_EmpReloj, T007U3_A2380Nombre, T007U3_A2469Apellido, T007U3_A2470Marcacion, T007U3_A2471Fec_Marcacion, T007U3_A2472Hor_Marcacion, T007U3_A2473Anio, T007U3_A2474mes, T007U3_A2475dia
               }
               , new Object[] {
               T007U4_A2467id, T007U4_A2468Cod_EmpReloj, T007U4_A2380Nombre, T007U4_A2469Apellido, T007U4_A2470Marcacion, T007U4_A2471Fec_Marcacion, T007U4_A2472Hor_Marcacion, T007U4_A2473Anio, T007U4_A2474mes, T007U4_A2475dia
               }
               , new Object[] {
               T007U5_A2467id
               }
               , new Object[] {
               T007U6_A2467id
               }
               , new Object[] {
               T007U7_A2467id
               }
               , new Object[] {
               T007U8_A2467id
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007U11_A2467id
               }
            }
         );
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound216 ;
      private short nIsDirty_216 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z2467id ;
      private int Z2473Anio ;
      private int Z2474mes ;
      private int Z2475dia ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A2467id ;
      private int edtid_Enabled ;
      private int edtCod_EmpReloj_Enabled ;
      private int edtNombre_Enabled ;
      private int edtApellido_Enabled ;
      private int edtMarcacion_Enabled ;
      private int edtFec_Marcacion_Enabled ;
      private int edtHor_Marcacion_Enabled ;
      private int A2473Anio ;
      private int edtAnio_Enabled ;
      private int A2474mes ;
      private int edtmes_Enabled ;
      private int A2475dia ;
      private int edtdia_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2467id ;
      private int ZZ2473Anio ;
      private int ZZ2474mes ;
      private int ZZ2475dia ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtid_Internalname ;
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
      private string edtid_Jsonclick ;
      private string edtCod_EmpReloj_Internalname ;
      private string edtCod_EmpReloj_Jsonclick ;
      private string edtNombre_Internalname ;
      private string edtNombre_Jsonclick ;
      private string edtApellido_Internalname ;
      private string edtApellido_Jsonclick ;
      private string edtMarcacion_Internalname ;
      private string edtMarcacion_Jsonclick ;
      private string edtFec_Marcacion_Internalname ;
      private string edtFec_Marcacion_Jsonclick ;
      private string edtHor_Marcacion_Internalname ;
      private string edtHor_Marcacion_Jsonclick ;
      private string edtAnio_Internalname ;
      private string edtAnio_Jsonclick ;
      private string edtmes_Internalname ;
      private string edtmes_Jsonclick ;
      private string edtdia_Internalname ;
      private string edtdia_Jsonclick ;
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
      private string sMode216 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2468Cod_EmpReloj ;
      private string Z2380Nombre ;
      private string Z2469Apellido ;
      private string Z2470Marcacion ;
      private string Z2471Fec_Marcacion ;
      private string Z2472Hor_Marcacion ;
      private string A2468Cod_EmpReloj ;
      private string A2380Nombre ;
      private string A2469Apellido ;
      private string A2470Marcacion ;
      private string A2471Fec_Marcacion ;
      private string A2472Hor_Marcacion ;
      private string ZZ2468Cod_EmpReloj ;
      private string ZZ2380Nombre ;
      private string ZZ2469Apellido ;
      private string ZZ2470Marcacion ;
      private string ZZ2471Fec_Marcacion ;
      private string ZZ2472Hor_Marcacion ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T007U4_A2467id ;
      private string[] T007U4_A2468Cod_EmpReloj ;
      private string[] T007U4_A2380Nombre ;
      private string[] T007U4_A2469Apellido ;
      private string[] T007U4_A2470Marcacion ;
      private string[] T007U4_A2471Fec_Marcacion ;
      private string[] T007U4_A2472Hor_Marcacion ;
      private int[] T007U4_A2473Anio ;
      private int[] T007U4_A2474mes ;
      private int[] T007U4_A2475dia ;
      private int[] T007U5_A2467id ;
      private int[] T007U3_A2467id ;
      private string[] T007U3_A2468Cod_EmpReloj ;
      private string[] T007U3_A2380Nombre ;
      private string[] T007U3_A2469Apellido ;
      private string[] T007U3_A2470Marcacion ;
      private string[] T007U3_A2471Fec_Marcacion ;
      private string[] T007U3_A2472Hor_Marcacion ;
      private int[] T007U3_A2473Anio ;
      private int[] T007U3_A2474mes ;
      private int[] T007U3_A2475dia ;
      private int[] T007U6_A2467id ;
      private int[] T007U7_A2467id ;
      private int[] T007U2_A2467id ;
      private string[] T007U2_A2468Cod_EmpReloj ;
      private string[] T007U2_A2380Nombre ;
      private string[] T007U2_A2469Apellido ;
      private string[] T007U2_A2470Marcacion ;
      private string[] T007U2_A2471Fec_Marcacion ;
      private string[] T007U2_A2472Hor_Marcacion ;
      private int[] T007U2_A2473Anio ;
      private int[] T007U2_A2474mes ;
      private int[] T007U2_A2475dia ;
      private int[] T007U8_A2467id ;
      private int[] T007U11_A2467id ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class v_reloj_asistencia__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class v_reloj_asistencia__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007U4;
        prmT007U4 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U5;
        prmT007U5 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U3;
        prmT007U3 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U6;
        prmT007U6 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U7;
        prmT007U7 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U2;
        prmT007U2 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U8;
        prmT007U8 = new Object[] {
        new ParDef("@Cod_EmpReloj",GXType.NVarChar,20,0) ,
        new ParDef("@Nombre",GXType.NVarChar,25,0) ,
        new ParDef("@Apellido",GXType.NVarChar,25,0) ,
        new ParDef("@Marcacion",GXType.NVarChar,30,0) ,
        new ParDef("@Fec_Marcacion",GXType.NVarChar,30,0) ,
        new ParDef("@Hor_Marcacion",GXType.NVarChar,30,0) ,
        new ParDef("@Anio",GXType.Int32,9,0) ,
        new ParDef("@mes",GXType.Int32,9,0) ,
        new ParDef("@dia",GXType.Int32,9,0)
        };
        Object[] prmT007U9;
        prmT007U9 = new Object[] {
        new ParDef("@Cod_EmpReloj",GXType.NVarChar,20,0) ,
        new ParDef("@Nombre",GXType.NVarChar,25,0) ,
        new ParDef("@Apellido",GXType.NVarChar,25,0) ,
        new ParDef("@Marcacion",GXType.NVarChar,30,0) ,
        new ParDef("@Fec_Marcacion",GXType.NVarChar,30,0) ,
        new ParDef("@Hor_Marcacion",GXType.NVarChar,30,0) ,
        new ParDef("@Anio",GXType.Int32,9,0) ,
        new ParDef("@mes",GXType.Int32,9,0) ,
        new ParDef("@dia",GXType.Int32,9,0) ,
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U10;
        prmT007U10 = new Object[] {
        new ParDef("@id",GXType.Int32,9,0)
        };
        Object[] prmT007U11;
        prmT007U11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007U2", "SELECT [id], [Cod_EmpReloj], [Nombre], [Apellido], [Marcacion], [Fec_Marcacion], [Hor_Marcacion], [Anio], [mes], [dia] FROM [V_Reloj_Asistencia] WITH (UPDLOCK) WHERE [id] = @id ",true, GxErrorMask.GX_NOMASK, false, this,prmT007U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007U3", "SELECT [id], [Cod_EmpReloj], [Nombre], [Apellido], [Marcacion], [Fec_Marcacion], [Hor_Marcacion], [Anio], [mes], [dia] FROM [V_Reloj_Asistencia] WHERE [id] = @id ",true, GxErrorMask.GX_NOMASK, false, this,prmT007U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007U4", "SELECT TM1.[id], TM1.[Cod_EmpReloj], TM1.[Nombre], TM1.[Apellido], TM1.[Marcacion], TM1.[Fec_Marcacion], TM1.[Hor_Marcacion], TM1.[Anio], TM1.[mes], TM1.[dia] FROM [V_Reloj_Asistencia] TM1 WHERE TM1.[id] = @id ORDER BY TM1.[id]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007U4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007U5", "SELECT [id] FROM [V_Reloj_Asistencia] WHERE [id] = @id  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007U6", "SELECT TOP 1 [id] FROM [V_Reloj_Asistencia] WHERE ( [id] > @id) ORDER BY [id]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007U6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007U7", "SELECT TOP 1 [id] FROM [V_Reloj_Asistencia] WHERE ( [id] < @id) ORDER BY [id] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007U7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007U8", "INSERT INTO [V_Reloj_Asistencia]([Cod_EmpReloj], [Nombre], [Apellido], [Marcacion], [Fec_Marcacion], [Hor_Marcacion], [Anio], [mes], [dia]) VALUES(@Cod_EmpReloj, @Nombre, @Apellido, @Marcacion, @Fec_Marcacion, @Hor_Marcacion, @Anio, @mes, @dia); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT007U8)
           ,new CursorDef("T007U9", "UPDATE [V_Reloj_Asistencia] SET [Cod_EmpReloj]=@Cod_EmpReloj, [Nombre]=@Nombre, [Apellido]=@Apellido, [Marcacion]=@Marcacion, [Fec_Marcacion]=@Fec_Marcacion, [Hor_Marcacion]=@Hor_Marcacion, [Anio]=@Anio, [mes]=@mes, [dia]=@dia  WHERE [id] = @id", GxErrorMask.GX_NOMASK,prmT007U9)
           ,new CursorDef("T007U10", "DELETE FROM [V_Reloj_Asistencia]  WHERE [id] = @id", GxErrorMask.GX_NOMASK,prmT007U10)
           ,new CursorDef("T007U11", "SELECT [id] FROM [V_Reloj_Asistencia] ORDER BY [id]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007U11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
