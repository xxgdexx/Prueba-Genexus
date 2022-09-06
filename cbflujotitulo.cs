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
   public class cbflujotitulo : GXDataArea
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
            Form.Meta.addItem("description", "Titulos Flujos de Caja", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbflujotitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbflujotitulo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Titulos Flujos de Caja", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBFLUJOTITULO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBFLUJOTITULO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujTip_Internalname, "Tipo de Flujo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujTip_Internalname, StringUtil.RTrim( A2269CBFlujTip), StringUtil.RTrim( context.localUtil.Format( A2269CBFlujTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCod_Internalname, StringUtil.RTrim( A2270CBFlujCod), StringUtil.RTrim( context.localUtil.Format( A2270CBFlujCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujDsc_Internalname, "Titulo Flujo de Caja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujDsc_Internalname, StringUtil.RTrim( A2277CBFlujDsc), StringUtil.RTrim( context.localUtil.Format( A2277CBFlujDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2278CBFlujSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2278CBFlujSts), "9") : context.localUtil.Format( (decimal)(A2278CBFlujSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOTITULO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULO.htm");
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
            Z2269CBFlujTip = cgiGet( "Z2269CBFlujTip");
            Z2270CBFlujCod = cgiGet( "Z2270CBFlujCod");
            Z2277CBFlujDsc = cgiGet( "Z2277CBFlujDsc");
            Z2278CBFlujSts = (short)(context.localUtil.CToN( cgiGet( "Z2278CBFlujSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2269CBFlujTip = cgiGet( edtCBFlujTip_Internalname);
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = cgiGet( edtCBFlujCod_Internalname);
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2277CBFlujDsc = cgiGet( edtCBFlujDsc_Internalname);
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJSTS");
               AnyError = 1;
               GX_FocusControl = edtCBFlujSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2278CBFlujSts = 0;
               AssignAttri("", false, "A2278CBFlujSts", StringUtil.Str( (decimal)(A2278CBFlujSts), 1, 0));
            }
            else
            {
               A2278CBFlujSts = (short)(context.localUtil.CToN( cgiGet( edtCBFlujSts_Internalname), ".", ","));
               AssignAttri("", false, "A2278CBFlujSts", StringUtil.Str( (decimal)(A2278CBFlujSts), 1, 0));
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
               A2269CBFlujTip = GetPar( "CBFlujTip");
               AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
               A2270CBFlujCod = GetPar( "CBFlujCod");
               AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
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
               InitAll7E202( ) ;
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
         DisableAttributes7E202( ) ;
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

      protected void ResetCaption7E0( )
      {
      }

      protected void ZM7E202( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2277CBFlujDsc = T007E3_A2277CBFlujDsc[0];
               Z2278CBFlujSts = T007E3_A2278CBFlujSts[0];
            }
            else
            {
               Z2277CBFlujDsc = A2277CBFlujDsc;
               Z2278CBFlujSts = A2278CBFlujSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2269CBFlujTip = A2269CBFlujTip;
            Z2270CBFlujCod = A2270CBFlujCod;
            Z2277CBFlujDsc = A2277CBFlujDsc;
            Z2278CBFlujSts = A2278CBFlujSts;
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

      protected void Load7E202( )
      {
         /* Using cursor T007E4 */
         pr_default.execute(2, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound202 = 1;
            A2277CBFlujDsc = T007E4_A2277CBFlujDsc[0];
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            A2278CBFlujSts = T007E4_A2278CBFlujSts[0];
            AssignAttri("", false, "A2278CBFlujSts", StringUtil.Str( (decimal)(A2278CBFlujSts), 1, 0));
            ZM7E202( -1) ;
         }
         pr_default.close(2);
         OnLoadActions7E202( ) ;
      }

      protected void OnLoadActions7E202( )
      {
      }

      protected void CheckExtendedTable7E202( )
      {
         nIsDirty_202 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors7E202( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7E202( )
      {
         /* Using cursor T007E5 */
         pr_default.execute(3, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound202 = 1;
         }
         else
         {
            RcdFound202 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007E3 */
         pr_default.execute(1, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7E202( 1) ;
            RcdFound202 = 1;
            A2269CBFlujTip = T007E3_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007E3_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2277CBFlujDsc = T007E3_A2277CBFlujDsc[0];
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            A2278CBFlujSts = T007E3_A2278CBFlujSts[0];
            AssignAttri("", false, "A2278CBFlujSts", StringUtil.Str( (decimal)(A2278CBFlujSts), 1, 0));
            Z2269CBFlujTip = A2269CBFlujTip;
            Z2270CBFlujCod = A2270CBFlujCod;
            sMode202 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7E202( ) ;
            if ( AnyError == 1 )
            {
               RcdFound202 = 0;
               InitializeNonKey7E202( ) ;
            }
            Gx_mode = sMode202;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound202 = 0;
            InitializeNonKey7E202( ) ;
            sMode202 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode202;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7E202( ) ;
         if ( RcdFound202 == 0 )
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
         RcdFound202 = 0;
         /* Using cursor T007E6 */
         pr_default.execute(4, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T007E6_A2269CBFlujTip[0], A2269CBFlujTip) < 0 ) || ( StringUtil.StrCmp(T007E6_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007E6_A2270CBFlujCod[0], A2270CBFlujCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T007E6_A2269CBFlujTip[0], A2269CBFlujTip) > 0 ) || ( StringUtil.StrCmp(T007E6_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007E6_A2270CBFlujCod[0], A2270CBFlujCod) > 0 ) ) )
            {
               A2269CBFlujTip = T007E6_A2269CBFlujTip[0];
               AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
               A2270CBFlujCod = T007E6_A2270CBFlujCod[0];
               AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
               RcdFound202 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound202 = 0;
         /* Using cursor T007E7 */
         pr_default.execute(5, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T007E7_A2269CBFlujTip[0], A2269CBFlujTip) > 0 ) || ( StringUtil.StrCmp(T007E7_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007E7_A2270CBFlujCod[0], A2270CBFlujCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T007E7_A2269CBFlujTip[0], A2269CBFlujTip) < 0 ) || ( StringUtil.StrCmp(T007E7_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007E7_A2270CBFlujCod[0], A2270CBFlujCod) < 0 ) ) )
            {
               A2269CBFlujTip = T007E7_A2269CBFlujTip[0];
               AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
               A2270CBFlujCod = T007E7_A2270CBFlujCod[0];
               AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
               RcdFound202 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7E202( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7E202( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound202 == 1 )
            {
               if ( ( StringUtil.StrCmp(A2269CBFlujTip, Z2269CBFlujTip) != 0 ) || ( StringUtil.StrCmp(A2270CBFlujCod, Z2270CBFlujCod) != 0 ) )
               {
                  A2269CBFlujTip = Z2269CBFlujTip;
                  AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
                  A2270CBFlujCod = Z2270CBFlujCod;
                  AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CBFLUJTIP");
                  AnyError = 1;
                  GX_FocusControl = edtCBFlujTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCBFlujTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7E202( ) ;
                  GX_FocusControl = edtCBFlujTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A2269CBFlujTip, Z2269CBFlujTip) != 0 ) || ( StringUtil.StrCmp(A2270CBFlujCod, Z2270CBFlujCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBFlujTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7E202( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CBFLUJTIP");
                     AnyError = 1;
                     GX_FocusControl = edtCBFlujTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCBFlujTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7E202( ) ;
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
         if ( ( StringUtil.StrCmp(A2269CBFlujTip, Z2269CBFlujTip) != 0 ) || ( StringUtil.StrCmp(A2270CBFlujCod, Z2270CBFlujCod) != 0 ) )
         {
            A2269CBFlujTip = Z2269CBFlujTip;
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = Z2270CBFlujCod;
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CBFLUJTIP");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCBFlujTip_Internalname;
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
         if ( RcdFound202 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBFLUJTIP");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBFlujDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7E202( ) ;
         if ( RcdFound202 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7E202( ) ;
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
         if ( RcdFound202 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujDsc_Internalname;
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
         if ( RcdFound202 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujDsc_Internalname;
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
         ScanStart7E202( ) ;
         if ( RcdFound202 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound202 != 0 )
            {
               ScanNext7E202( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7E202( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7E202( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007E2 */
            pr_default.execute(0, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOTITULO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2277CBFlujDsc, T007E2_A2277CBFlujDsc[0]) != 0 ) || ( Z2278CBFlujSts != T007E2_A2278CBFlujSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2277CBFlujDsc, T007E2_A2277CBFlujDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbflujotitulo:[seudo value changed for attri]"+"CBFlujDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2277CBFlujDsc);
                  GXUtil.WriteLogRaw("Current: ",T007E2_A2277CBFlujDsc[0]);
               }
               if ( Z2278CBFlujSts != T007E2_A2278CBFlujSts[0] )
               {
                  GXUtil.WriteLog("cbflujotitulo:[seudo value changed for attri]"+"CBFlujSts");
                  GXUtil.WriteLogRaw("Old: ",Z2278CBFlujSts);
                  GXUtil.WriteLogRaw("Current: ",T007E2_A2278CBFlujSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBFLUJOTITULO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7E202( )
      {
         BeforeValidate7E202( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7E202( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7E202( 0) ;
            CheckOptimisticConcurrency7E202( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7E202( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7E202( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007E8 */
                     pr_default.execute(6, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2277CBFlujDsc, A2278CBFlujSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOTITULO");
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
                           ResetCaption7E0( ) ;
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
               Load7E202( ) ;
            }
            EndLevel7E202( ) ;
         }
         CloseExtendedTableCursors7E202( ) ;
      }

      protected void Update7E202( )
      {
         BeforeValidate7E202( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7E202( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7E202( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7E202( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7E202( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007E9 */
                     pr_default.execute(7, new Object[] {A2277CBFlujDsc, A2278CBFlujSts, A2269CBFlujTip, A2270CBFlujCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOTITULO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOTITULO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7E202( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7E0( ) ;
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
            EndLevel7E202( ) ;
         }
         CloseExtendedTableCursors7E202( ) ;
      }

      protected void DeferredUpdate7E202( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7E202( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7E202( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7E202( ) ;
            AfterConfirm7E202( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7E202( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007E10 */
                  pr_default.execute(8, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOTITULO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound202 == 0 )
                        {
                           InitAll7E202( ) ;
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
                        ResetCaption7E0( ) ;
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
         sMode202 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7E202( ) ;
         Gx_mode = sMode202;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7E202( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007E11 */
            pr_default.execute(9, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conceptos de Flujo de Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel7E202( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7E202( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbflujotitulo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbflujotitulo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7E202( )
      {
         /* Using cursor T007E12 */
         pr_default.execute(10);
         RcdFound202 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound202 = 1;
            A2269CBFlujTip = T007E12_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007E12_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7E202( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound202 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound202 = 1;
            A2269CBFlujTip = T007E12_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007E12_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
         }
      }

      protected void ScanEnd7E202( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm7E202( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7E202( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7E202( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7E202( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7E202( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7E202( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7E202( )
      {
         edtCBFlujTip_Enabled = 0;
         AssignProp("", false, edtCBFlujTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujTip_Enabled), 5, 0), true);
         edtCBFlujCod_Enabled = 0;
         AssignProp("", false, edtCBFlujCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCod_Enabled), 5, 0), true);
         edtCBFlujDsc_Enabled = 0;
         AssignProp("", false, edtCBFlujDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujDsc_Enabled), 5, 0), true);
         edtCBFlujSts_Enabled = 0;
         AssignProp("", false, edtCBFlujSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7E202( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7E0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271189", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbflujotitulo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2269CBFlujTip", StringUtil.RTrim( Z2269CBFlujTip));
         GxWebStd.gx_hidden_field( context, "Z2270CBFlujCod", StringUtil.RTrim( Z2270CBFlujCod));
         GxWebStd.gx_hidden_field( context, "Z2277CBFlujDsc", StringUtil.RTrim( Z2277CBFlujDsc));
         GxWebStd.gx_hidden_field( context, "Z2278CBFlujSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2278CBFlujSts), 1, 0, ".", "")));
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
         return formatLink("cbflujotitulo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBFLUJOTITULO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Titulos Flujos de Caja" ;
      }

      protected void InitializeNonKey7E202( )
      {
         A2277CBFlujDsc = "";
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         A2278CBFlujSts = 0;
         AssignAttri("", false, "A2278CBFlujSts", StringUtil.Str( (decimal)(A2278CBFlujSts), 1, 0));
         Z2277CBFlujDsc = "";
         Z2278CBFlujSts = 0;
      }

      protected void InitAll7E202( )
      {
         A2269CBFlujTip = "";
         AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
         A2270CBFlujCod = "";
         AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
         InitializeNonKey7E202( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271194", true, true);
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
         context.AddJavascriptSource("cbflujotitulo.js", "?202281810271195", false, true);
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
         edtCBFlujTip_Internalname = "CBFLUJTIP";
         edtCBFlujCod_Internalname = "CBFLUJCOD";
         edtCBFlujDsc_Internalname = "CBFLUJDSC";
         edtCBFlujSts_Internalname = "CBFLUJSTS";
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
         Form.Caption = "Titulos Flujos de Caja";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBFlujSts_Jsonclick = "";
         edtCBFlujSts_Enabled = 1;
         edtCBFlujDsc_Jsonclick = "";
         edtCBFlujDsc_Enabled = 1;
         edtCBFlujCod_Jsonclick = "";
         edtCBFlujCod_Enabled = 1;
         edtCBFlujTip_Jsonclick = "";
         edtCBFlujTip_Enabled = 1;
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
         GX_FocusControl = edtCBFlujDsc_Internalname;
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

      public void Valid_Cbflujcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2277CBFlujDsc", StringUtil.RTrim( A2277CBFlujDsc));
         AssignAttri("", false, "A2278CBFlujSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2278CBFlujSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2269CBFlujTip", StringUtil.RTrim( Z2269CBFlujTip));
         GxWebStd.gx_hidden_field( context, "Z2270CBFlujCod", StringUtil.RTrim( Z2270CBFlujCod));
         GxWebStd.gx_hidden_field( context, "Z2277CBFlujDsc", StringUtil.RTrim( Z2277CBFlujDsc));
         GxWebStd.gx_hidden_field( context, "Z2278CBFlujSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2278CBFlujSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_CBFLUJTIP","{handler:'Valid_Cbflujtip',iparms:[]");
         setEventMetadata("VALID_CBFLUJTIP",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCOD","{handler:'Valid_Cbflujcod',iparms:[{av:'A2269CBFlujTip',fld:'CBFLUJTIP',pic:''},{av:'A2270CBFlujCod',fld:'CBFLUJCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBFLUJCOD",",oparms:[{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''},{av:'A2278CBFlujSts',fld:'CBFLUJSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2269CBFlujTip'},{av:'Z2270CBFlujCod'},{av:'Z2277CBFlujDsc'},{av:'Z2278CBFlujSts'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z2269CBFlujTip = "";
         Z2270CBFlujCod = "";
         Z2277CBFlujDsc = "";
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
         A2269CBFlujTip = "";
         A2270CBFlujCod = "";
         A2277CBFlujDsc = "";
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
         T007E4_A2269CBFlujTip = new string[] {""} ;
         T007E4_A2270CBFlujCod = new string[] {""} ;
         T007E4_A2277CBFlujDsc = new string[] {""} ;
         T007E4_A2278CBFlujSts = new short[1] ;
         T007E5_A2269CBFlujTip = new string[] {""} ;
         T007E5_A2270CBFlujCod = new string[] {""} ;
         T007E3_A2269CBFlujTip = new string[] {""} ;
         T007E3_A2270CBFlujCod = new string[] {""} ;
         T007E3_A2277CBFlujDsc = new string[] {""} ;
         T007E3_A2278CBFlujSts = new short[1] ;
         sMode202 = "";
         T007E6_A2269CBFlujTip = new string[] {""} ;
         T007E6_A2270CBFlujCod = new string[] {""} ;
         T007E7_A2269CBFlujTip = new string[] {""} ;
         T007E7_A2270CBFlujCod = new string[] {""} ;
         T007E2_A2269CBFlujTip = new string[] {""} ;
         T007E2_A2270CBFlujCod = new string[] {""} ;
         T007E2_A2277CBFlujDsc = new string[] {""} ;
         T007E2_A2278CBFlujSts = new short[1] ;
         T007E11_A2269CBFlujTip = new string[] {""} ;
         T007E11_A2270CBFlujCod = new string[] {""} ;
         T007E11_A2271CBFlujCCod = new string[] {""} ;
         T007E12_A2269CBFlujTip = new string[] {""} ;
         T007E12_A2270CBFlujCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2269CBFlujTip = "";
         ZZ2270CBFlujCod = "";
         ZZ2277CBFlujDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbflujotitulo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbflujotitulo__default(),
            new Object[][] {
                new Object[] {
               T007E2_A2269CBFlujTip, T007E2_A2270CBFlujCod, T007E2_A2277CBFlujDsc, T007E2_A2278CBFlujSts
               }
               , new Object[] {
               T007E3_A2269CBFlujTip, T007E3_A2270CBFlujCod, T007E3_A2277CBFlujDsc, T007E3_A2278CBFlujSts
               }
               , new Object[] {
               T007E4_A2269CBFlujTip, T007E4_A2270CBFlujCod, T007E4_A2277CBFlujDsc, T007E4_A2278CBFlujSts
               }
               , new Object[] {
               T007E5_A2269CBFlujTip, T007E5_A2270CBFlujCod
               }
               , new Object[] {
               T007E6_A2269CBFlujTip, T007E6_A2270CBFlujCod
               }
               , new Object[] {
               T007E7_A2269CBFlujTip, T007E7_A2270CBFlujCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007E11_A2269CBFlujTip, T007E11_A2270CBFlujCod, T007E11_A2271CBFlujCCod
               }
               , new Object[] {
               T007E12_A2269CBFlujTip, T007E12_A2270CBFlujCod
               }
            }
         );
      }

      private short Z2278CBFlujSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2278CBFlujSts ;
      private short GX_JID ;
      private short RcdFound202 ;
      private short nIsDirty_202 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2278CBFlujSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCBFlujTip_Enabled ;
      private int edtCBFlujCod_Enabled ;
      private int edtCBFlujDsc_Enabled ;
      private int edtCBFlujSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z2269CBFlujTip ;
      private string Z2270CBFlujCod ;
      private string Z2277CBFlujDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCBFlujTip_Internalname ;
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
      private string A2269CBFlujTip ;
      private string edtCBFlujTip_Jsonclick ;
      private string edtCBFlujCod_Internalname ;
      private string A2270CBFlujCod ;
      private string edtCBFlujCod_Jsonclick ;
      private string edtCBFlujDsc_Internalname ;
      private string A2277CBFlujDsc ;
      private string edtCBFlujDsc_Jsonclick ;
      private string edtCBFlujSts_Internalname ;
      private string edtCBFlujSts_Jsonclick ;
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
      private string sMode202 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2269CBFlujTip ;
      private string ZZ2270CBFlujCod ;
      private string ZZ2277CBFlujDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007E4_A2269CBFlujTip ;
      private string[] T007E4_A2270CBFlujCod ;
      private string[] T007E4_A2277CBFlujDsc ;
      private short[] T007E4_A2278CBFlujSts ;
      private string[] T007E5_A2269CBFlujTip ;
      private string[] T007E5_A2270CBFlujCod ;
      private string[] T007E3_A2269CBFlujTip ;
      private string[] T007E3_A2270CBFlujCod ;
      private string[] T007E3_A2277CBFlujDsc ;
      private short[] T007E3_A2278CBFlujSts ;
      private string[] T007E6_A2269CBFlujTip ;
      private string[] T007E6_A2270CBFlujCod ;
      private string[] T007E7_A2269CBFlujTip ;
      private string[] T007E7_A2270CBFlujCod ;
      private string[] T007E2_A2269CBFlujTip ;
      private string[] T007E2_A2270CBFlujCod ;
      private string[] T007E2_A2277CBFlujDsc ;
      private short[] T007E2_A2278CBFlujSts ;
      private string[] T007E11_A2269CBFlujTip ;
      private string[] T007E11_A2270CBFlujCod ;
      private string[] T007E11_A2271CBFlujCCod ;
      private string[] T007E12_A2269CBFlujTip ;
      private string[] T007E12_A2270CBFlujCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbflujotitulo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbflujotitulo__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007E4;
        prmT007E4 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E5;
        prmT007E5 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E3;
        prmT007E3 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E6;
        prmT007E6 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E7;
        prmT007E7 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E2;
        prmT007E2 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E8;
        prmT007E8 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujDsc",GXType.NChar,100,0) ,
        new ParDef("@CBFlujSts",GXType.Int16,1,0)
        };
        Object[] prmT007E9;
        prmT007E9 = new Object[] {
        new ParDef("@CBFlujDsc",GXType.NChar,100,0) ,
        new ParDef("@CBFlujSts",GXType.Int16,1,0) ,
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E10;
        prmT007E10 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E11;
        prmT007E11 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007E12;
        prmT007E12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007E2", "SELECT [CBFlujTip], [CBFlujCod], [CBFlujDsc], [CBFlujSts] FROM [CBFLUJOTITULO] WITH (UPDLOCK) WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007E3", "SELECT [CBFlujTip], [CBFlujCod], [CBFlujDsc], [CBFlujSts] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007E4", "SELECT TM1.[CBFlujTip], TM1.[CBFlujCod], TM1.[CBFlujDsc], TM1.[CBFlujSts] FROM [CBFLUJOTITULO] TM1 WHERE TM1.[CBFlujTip] = @CBFlujTip and TM1.[CBFlujCod] = @CBFlujCod ORDER BY TM1.[CBFlujTip], TM1.[CBFlujCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007E4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007E5", "SELECT [CBFlujTip], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007E6", "SELECT TOP 1 [CBFlujTip], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE ( [CBFlujTip] > @CBFlujTip or [CBFlujTip] = @CBFlujTip and [CBFlujCod] > @CBFlujCod) ORDER BY [CBFlujTip], [CBFlujCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007E6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007E7", "SELECT TOP 1 [CBFlujTip], [CBFlujCod] FROM [CBFLUJOTITULO] WHERE ( [CBFlujTip] < @CBFlujTip or [CBFlujTip] = @CBFlujTip and [CBFlujCod] < @CBFlujCod) ORDER BY [CBFlujTip] DESC, [CBFlujCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007E7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007E8", "INSERT INTO [CBFLUJOTITULO]([CBFlujTip], [CBFlujCod], [CBFlujDsc], [CBFlujSts]) VALUES(@CBFlujTip, @CBFlujCod, @CBFlujDsc, @CBFlujSts)", GxErrorMask.GX_NOMASK,prmT007E8)
           ,new CursorDef("T007E9", "UPDATE [CBFLUJOTITULO] SET [CBFlujDsc]=@CBFlujDsc, [CBFlujSts]=@CBFlujSts  WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod", GxErrorMask.GX_NOMASK,prmT007E9)
           ,new CursorDef("T007E10", "DELETE FROM [CBFLUJOTITULO]  WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod", GxErrorMask.GX_NOMASK,prmT007E10)
           ,new CursorDef("T007E11", "SELECT TOP 1 [CBFlujTip], [CBFlujCod], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007E12", "SELECT [CBFlujTip], [CBFlujCod] FROM [CBFLUJOTITULO] ORDER BY [CBFlujTip], [CBFlujCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007E12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
     }
  }

}

}
