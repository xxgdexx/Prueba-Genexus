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
   public class trab_trabajador : GXDataArea
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
            Form.Meta.addItem("description", "Trab_Trabajador", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrabCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trab_trabajador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public trab_trabajador( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Trab_Trabajador", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Trab_Trabajador.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Reloj_Interface\\Trab_Trabajador.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabCodigo_Internalname, "Trabajador", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabCodigo_Internalname, A2417TrabCodigo, StringUtil.RTrim( context.localUtil.Format( A2417TrabCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabCodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrab_TipDocCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrab_TipDocCodigo_Internalname, "Tipo Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrab_TipDocCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2512Trab_TipDocCodigo), 4, 0, ".", "")), StringUtil.LTrim( ((edtTrab_TipDocCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A2512Trab_TipDocCodigo), "ZZZ9") : context.localUtil.Format( (decimal)(A2512Trab_TipDocCodigo), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrab_TipDocCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrab_TipDocCodigo_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabCodInterno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabCodInterno_Internalname, "Interno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabCodInterno_Internalname, A2528TrabCodInterno, StringUtil.RTrim( context.localUtil.Format( A2528TrabCodInterno, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabCodInterno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabCodInterno_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabApePat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabApePat_Internalname, "Paterno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabApePat_Internalname, A2525TrabApePat, StringUtil.RTrim( context.localUtil.Format( A2525TrabApePat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabApePat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabApePat_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabApeMat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabApeMat_Internalname, "Materno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabApeMat_Internalname, A2526TrabApeMat, StringUtil.RTrim( context.localUtil.Format( A2526TrabApeMat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabApeMat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabApeMat_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabNombres_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabNombres_Internalname, "Nombres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabNombres_Internalname, A2527TrabNombres, StringUtil.RTrim( context.localUtil.Format( A2527TrabNombres, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabNombres_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabNombres_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabFechNac_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabFechNac_Internalname, "Nacimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrabFechNac_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrabFechNac_Internalname, context.localUtil.Format(A2529TrabFechNac, "99/99/99"), context.localUtil.Format( A2529TrabFechNac, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabFechNac_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabFechNac_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_bitmap( context, edtTrabFechNac_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrabFechNac_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabSexo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabSexo_Internalname, "Sexo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabSexo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2530TrabSexo), 1, 0, ".", "")), StringUtil.LTrim( ((edtTrabSexo_Enabled!=0) ? context.localUtil.Format( (decimal)(A2530TrabSexo), "9") : context.localUtil.Format( (decimal)(A2530TrabSexo), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabSexo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabSexo_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2524TrabEstado), 1, 0, ".", "")), StringUtil.LTrim( ((edtTrabEstado_Enabled!=0) ? context.localUtil.Format( (decimal)(A2524TrabEstado), "9") : context.localUtil.Format( (decimal)(A2524TrabEstado), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabEstado_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabFechIng_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabFechIng_Internalname, "Fech Ing", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrabFechIng_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrabFechIng_Internalname, context.localUtil.Format(A2523TrabFechIng, "99/99/99"), context.localUtil.Format( A2523TrabFechIng, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabFechIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabFechIng_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_bitmap( context, edtTrabFechIng_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrabFechIng_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabFechFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabFechFin_Internalname, "Baja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrabFechFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrabFechFin_Internalname, context.localUtil.TToC( A2571TrabFechFin, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2571TrabFechFin, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabFechFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabFechFin_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_bitmap( context, edtTrabFechFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrabFechFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabNroTelf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabNroTelf_Internalname, "Nro Telf", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabNroTelf_Internalname, A2558TrabNroTelf, StringUtil.RTrim( context.localUtil.Format( A2558TrabNroTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrabNroTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabNroTelf_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabCorreo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabCorreo_Internalname, "Correo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrabCorreo_Internalname, A2559TrabCorreo, StringUtil.RTrim( context.localUtil.Format( A2559TrabCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A2559TrabCorreo, "", "", "", edtTrabCorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrabCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrabDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrabDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrabDescripcion_Internalname, A2568TrabDescripcion, "", "", 0, 1, edtTrabDescripcion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgTrabImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A2567TrabImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000TrabImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.PathToRelativeUrl( A2567TrabImagen));
         GxWebStd.gx_bitmap( context, imgTrabImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgTrabImagen_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", "", "", 0, A2567TrabImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         AssignProp("", false, imgTrabImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.PathToRelativeUrl( A2567TrabImagen)), true);
         AssignProp("", false, imgTrabImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A2567TrabImagen_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Trab_Trabajador.htm");
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
            Z2417TrabCodigo = cgiGet( "Z2417TrabCodigo");
            Z2512Trab_TipDocCodigo = (short)(context.localUtil.CToN( cgiGet( "Z2512Trab_TipDocCodigo"), ".", ","));
            n2512Trab_TipDocCodigo = ((0==A2512Trab_TipDocCodigo) ? true : false);
            Z2528TrabCodInterno = cgiGet( "Z2528TrabCodInterno");
            n2528TrabCodInterno = (String.IsNullOrEmpty(StringUtil.RTrim( A2528TrabCodInterno)) ? true : false);
            Z2525TrabApePat = cgiGet( "Z2525TrabApePat");
            n2525TrabApePat = (String.IsNullOrEmpty(StringUtil.RTrim( A2525TrabApePat)) ? true : false);
            Z2526TrabApeMat = cgiGet( "Z2526TrabApeMat");
            n2526TrabApeMat = (String.IsNullOrEmpty(StringUtil.RTrim( A2526TrabApeMat)) ? true : false);
            Z2527TrabNombres = cgiGet( "Z2527TrabNombres");
            n2527TrabNombres = (String.IsNullOrEmpty(StringUtil.RTrim( A2527TrabNombres)) ? true : false);
            Z2529TrabFechNac = context.localUtil.CToD( cgiGet( "Z2529TrabFechNac"), 0);
            n2529TrabFechNac = ((DateTime.MinValue==A2529TrabFechNac) ? true : false);
            Z2530TrabSexo = (short)(context.localUtil.CToN( cgiGet( "Z2530TrabSexo"), ".", ","));
            n2530TrabSexo = ((0==A2530TrabSexo) ? true : false);
            Z2524TrabEstado = (short)(context.localUtil.CToN( cgiGet( "Z2524TrabEstado"), ".", ","));
            n2524TrabEstado = ((0==A2524TrabEstado) ? true : false);
            Z2523TrabFechIng = context.localUtil.CToD( cgiGet( "Z2523TrabFechIng"), 0);
            n2523TrabFechIng = ((DateTime.MinValue==A2523TrabFechIng) ? true : false);
            Z2571TrabFechFin = context.localUtil.CToT( cgiGet( "Z2571TrabFechFin"), 0);
            n2571TrabFechFin = ((DateTime.MinValue==A2571TrabFechFin) ? true : false);
            Z2558TrabNroTelf = cgiGet( "Z2558TrabNroTelf");
            n2558TrabNroTelf = (String.IsNullOrEmpty(StringUtil.RTrim( A2558TrabNroTelf)) ? true : false);
            Z2559TrabCorreo = cgiGet( "Z2559TrabCorreo");
            n2559TrabCorreo = (String.IsNullOrEmpty(StringUtil.RTrim( A2559TrabCorreo)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A40000TrabImagen_GXI = cgiGet( "TRABIMAGEN_GXI");
            n40000TrabImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000TrabImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? true : false);
            /* Read variables values. */
            A2417TrabCodigo = cgiGet( edtTrabCodigo_Internalname);
            AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrab_TipDocCodigo_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrab_TipDocCodigo_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRAB_TIPDOCCODIGO");
               AnyError = 1;
               GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2512Trab_TipDocCodigo = 0;
               n2512Trab_TipDocCodigo = false;
               AssignAttri("", false, "A2512Trab_TipDocCodigo", StringUtil.LTrimStr( (decimal)(A2512Trab_TipDocCodigo), 4, 0));
            }
            else
            {
               A2512Trab_TipDocCodigo = (short)(context.localUtil.CToN( cgiGet( edtTrab_TipDocCodigo_Internalname), ".", ","));
               n2512Trab_TipDocCodigo = false;
               AssignAttri("", false, "A2512Trab_TipDocCodigo", StringUtil.LTrimStr( (decimal)(A2512Trab_TipDocCodigo), 4, 0));
            }
            n2512Trab_TipDocCodigo = ((0==A2512Trab_TipDocCodigo) ? true : false);
            A2528TrabCodInterno = cgiGet( edtTrabCodInterno_Internalname);
            n2528TrabCodInterno = false;
            AssignAttri("", false, "A2528TrabCodInterno", A2528TrabCodInterno);
            n2528TrabCodInterno = (String.IsNullOrEmpty(StringUtil.RTrim( A2528TrabCodInterno)) ? true : false);
            A2525TrabApePat = cgiGet( edtTrabApePat_Internalname);
            n2525TrabApePat = false;
            AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
            n2525TrabApePat = (String.IsNullOrEmpty(StringUtil.RTrim( A2525TrabApePat)) ? true : false);
            A2526TrabApeMat = cgiGet( edtTrabApeMat_Internalname);
            n2526TrabApeMat = false;
            AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
            n2526TrabApeMat = (String.IsNullOrEmpty(StringUtil.RTrim( A2526TrabApeMat)) ? true : false);
            A2527TrabNombres = cgiGet( edtTrabNombres_Internalname);
            n2527TrabNombres = false;
            AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
            n2527TrabNombres = (String.IsNullOrEmpty(StringUtil.RTrim( A2527TrabNombres)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrabFechNac_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Nacimiento"}), 1, "TRABFECHNAC");
               AnyError = 1;
               GX_FocusControl = edtTrabFechNac_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2529TrabFechNac = DateTime.MinValue;
               n2529TrabFechNac = false;
               AssignAttri("", false, "A2529TrabFechNac", context.localUtil.Format(A2529TrabFechNac, "99/99/99"));
            }
            else
            {
               A2529TrabFechNac = context.localUtil.CToD( cgiGet( edtTrabFechNac_Internalname), 2);
               n2529TrabFechNac = false;
               AssignAttri("", false, "A2529TrabFechNac", context.localUtil.Format(A2529TrabFechNac, "99/99/99"));
            }
            n2529TrabFechNac = ((DateTime.MinValue==A2529TrabFechNac) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrabSexo_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrabSexo_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRABSEXO");
               AnyError = 1;
               GX_FocusControl = edtTrabSexo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2530TrabSexo = 0;
               n2530TrabSexo = false;
               AssignAttri("", false, "A2530TrabSexo", StringUtil.Str( (decimal)(A2530TrabSexo), 1, 0));
            }
            else
            {
               A2530TrabSexo = (short)(context.localUtil.CToN( cgiGet( edtTrabSexo_Internalname), ".", ","));
               n2530TrabSexo = false;
               AssignAttri("", false, "A2530TrabSexo", StringUtil.Str( (decimal)(A2530TrabSexo), 1, 0));
            }
            n2530TrabSexo = ((0==A2530TrabSexo) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrabEstado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrabEstado_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRABESTADO");
               AnyError = 1;
               GX_FocusControl = edtTrabEstado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2524TrabEstado = 0;
               n2524TrabEstado = false;
               AssignAttri("", false, "A2524TrabEstado", StringUtil.Str( (decimal)(A2524TrabEstado), 1, 0));
            }
            else
            {
               A2524TrabEstado = (short)(context.localUtil.CToN( cgiGet( edtTrabEstado_Internalname), ".", ","));
               n2524TrabEstado = false;
               AssignAttri("", false, "A2524TrabEstado", StringUtil.Str( (decimal)(A2524TrabEstado), 1, 0));
            }
            n2524TrabEstado = ((0==A2524TrabEstado) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrabFechIng_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Trab Fech Ing"}), 1, "TRABFECHING");
               AnyError = 1;
               GX_FocusControl = edtTrabFechIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2523TrabFechIng = DateTime.MinValue;
               n2523TrabFechIng = false;
               AssignAttri("", false, "A2523TrabFechIng", context.localUtil.Format(A2523TrabFechIng, "99/99/99"));
            }
            else
            {
               A2523TrabFechIng = context.localUtil.CToD( cgiGet( edtTrabFechIng_Internalname), 2);
               n2523TrabFechIng = false;
               AssignAttri("", false, "A2523TrabFechIng", context.localUtil.Format(A2523TrabFechIng, "99/99/99"));
            }
            n2523TrabFechIng = ((DateTime.MinValue==A2523TrabFechIng) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtTrabFechFin_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Baja"}), 1, "TRABFECHFIN");
               AnyError = 1;
               GX_FocusControl = edtTrabFechFin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2571TrabFechFin = (DateTime)(DateTime.MinValue);
               n2571TrabFechFin = false;
               AssignAttri("", false, "A2571TrabFechFin", context.localUtil.TToC( A2571TrabFechFin, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A2571TrabFechFin = context.localUtil.CToT( cgiGet( edtTrabFechFin_Internalname));
               n2571TrabFechFin = false;
               AssignAttri("", false, "A2571TrabFechFin", context.localUtil.TToC( A2571TrabFechFin, 8, 5, 0, 3, "/", ":", " "));
            }
            n2571TrabFechFin = ((DateTime.MinValue==A2571TrabFechFin) ? true : false);
            A2558TrabNroTelf = cgiGet( edtTrabNroTelf_Internalname);
            n2558TrabNroTelf = false;
            AssignAttri("", false, "A2558TrabNroTelf", A2558TrabNroTelf);
            n2558TrabNroTelf = (String.IsNullOrEmpty(StringUtil.RTrim( A2558TrabNroTelf)) ? true : false);
            A2559TrabCorreo = cgiGet( edtTrabCorreo_Internalname);
            n2559TrabCorreo = false;
            AssignAttri("", false, "A2559TrabCorreo", A2559TrabCorreo);
            n2559TrabCorreo = (String.IsNullOrEmpty(StringUtil.RTrim( A2559TrabCorreo)) ? true : false);
            A2568TrabDescripcion = cgiGet( edtTrabDescripcion_Internalname);
            AssignAttri("", false, "A2568TrabDescripcion", A2568TrabDescripcion);
            A2567TrabImagen = cgiGet( imgTrabImagen_Internalname);
            n2567TrabImagen = false;
            AssignAttri("", false, "A2567TrabImagen", A2567TrabImagen);
            n2567TrabImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgTrabImagen_Internalname, ref  A2567TrabImagen, ref  A40000TrabImagen_GXI);
            n40000TrabImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000TrabImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? true : false);
            n2567TrabImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? true : false);
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
               A2417TrabCodigo = GetPar( "TrabCodigo");
               AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
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
               InitAll7X220( ) ;
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
         DisableAttributes7X220( ) ;
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

      protected void ResetCaption7X0( )
      {
      }

      protected void ZM7X220( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2512Trab_TipDocCodigo = T007X3_A2512Trab_TipDocCodigo[0];
               Z2528TrabCodInterno = T007X3_A2528TrabCodInterno[0];
               Z2525TrabApePat = T007X3_A2525TrabApePat[0];
               Z2526TrabApeMat = T007X3_A2526TrabApeMat[0];
               Z2527TrabNombres = T007X3_A2527TrabNombres[0];
               Z2529TrabFechNac = T007X3_A2529TrabFechNac[0];
               Z2530TrabSexo = T007X3_A2530TrabSexo[0];
               Z2524TrabEstado = T007X3_A2524TrabEstado[0];
               Z2523TrabFechIng = T007X3_A2523TrabFechIng[0];
               Z2571TrabFechFin = T007X3_A2571TrabFechFin[0];
               Z2558TrabNroTelf = T007X3_A2558TrabNroTelf[0];
               Z2559TrabCorreo = T007X3_A2559TrabCorreo[0];
            }
            else
            {
               Z2512Trab_TipDocCodigo = A2512Trab_TipDocCodigo;
               Z2528TrabCodInterno = A2528TrabCodInterno;
               Z2525TrabApePat = A2525TrabApePat;
               Z2526TrabApeMat = A2526TrabApeMat;
               Z2527TrabNombres = A2527TrabNombres;
               Z2529TrabFechNac = A2529TrabFechNac;
               Z2530TrabSexo = A2530TrabSexo;
               Z2524TrabEstado = A2524TrabEstado;
               Z2523TrabFechIng = A2523TrabFechIng;
               Z2571TrabFechFin = A2571TrabFechFin;
               Z2558TrabNroTelf = A2558TrabNroTelf;
               Z2559TrabCorreo = A2559TrabCorreo;
            }
         }
         if ( GX_JID == -6 )
         {
            Z2417TrabCodigo = A2417TrabCodigo;
            Z2512Trab_TipDocCodigo = A2512Trab_TipDocCodigo;
            Z2528TrabCodInterno = A2528TrabCodInterno;
            Z2525TrabApePat = A2525TrabApePat;
            Z2526TrabApeMat = A2526TrabApeMat;
            Z2527TrabNombres = A2527TrabNombres;
            Z2529TrabFechNac = A2529TrabFechNac;
            Z2530TrabSexo = A2530TrabSexo;
            Z2524TrabEstado = A2524TrabEstado;
            Z2523TrabFechIng = A2523TrabFechIng;
            Z2571TrabFechFin = A2571TrabFechFin;
            Z2558TrabNroTelf = A2558TrabNroTelf;
            Z2559TrabCorreo = A2559TrabCorreo;
            Z2567TrabImagen = A2567TrabImagen;
            Z40000TrabImagen_GXI = A40000TrabImagen_GXI;
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

      protected void Load7X220( )
      {
         /* Using cursor T007X4 */
         pr_default.execute(2, new Object[] {A2417TrabCodigo});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound220 = 1;
            A2512Trab_TipDocCodigo = T007X4_A2512Trab_TipDocCodigo[0];
            n2512Trab_TipDocCodigo = T007X4_n2512Trab_TipDocCodigo[0];
            AssignAttri("", false, "A2512Trab_TipDocCodigo", StringUtil.LTrimStr( (decimal)(A2512Trab_TipDocCodigo), 4, 0));
            A2528TrabCodInterno = T007X4_A2528TrabCodInterno[0];
            n2528TrabCodInterno = T007X4_n2528TrabCodInterno[0];
            AssignAttri("", false, "A2528TrabCodInterno", A2528TrabCodInterno);
            A2525TrabApePat = T007X4_A2525TrabApePat[0];
            n2525TrabApePat = T007X4_n2525TrabApePat[0];
            AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
            A2526TrabApeMat = T007X4_A2526TrabApeMat[0];
            n2526TrabApeMat = T007X4_n2526TrabApeMat[0];
            AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
            A2527TrabNombres = T007X4_A2527TrabNombres[0];
            n2527TrabNombres = T007X4_n2527TrabNombres[0];
            AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
            A2529TrabFechNac = T007X4_A2529TrabFechNac[0];
            n2529TrabFechNac = T007X4_n2529TrabFechNac[0];
            AssignAttri("", false, "A2529TrabFechNac", context.localUtil.Format(A2529TrabFechNac, "99/99/99"));
            A2530TrabSexo = T007X4_A2530TrabSexo[0];
            n2530TrabSexo = T007X4_n2530TrabSexo[0];
            AssignAttri("", false, "A2530TrabSexo", StringUtil.Str( (decimal)(A2530TrabSexo), 1, 0));
            A2524TrabEstado = T007X4_A2524TrabEstado[0];
            n2524TrabEstado = T007X4_n2524TrabEstado[0];
            AssignAttri("", false, "A2524TrabEstado", StringUtil.Str( (decimal)(A2524TrabEstado), 1, 0));
            A2523TrabFechIng = T007X4_A2523TrabFechIng[0];
            n2523TrabFechIng = T007X4_n2523TrabFechIng[0];
            AssignAttri("", false, "A2523TrabFechIng", context.localUtil.Format(A2523TrabFechIng, "99/99/99"));
            A2571TrabFechFin = T007X4_A2571TrabFechFin[0];
            n2571TrabFechFin = T007X4_n2571TrabFechFin[0];
            AssignAttri("", false, "A2571TrabFechFin", context.localUtil.TToC( A2571TrabFechFin, 8, 5, 0, 3, "/", ":", " "));
            A2558TrabNroTelf = T007X4_A2558TrabNroTelf[0];
            n2558TrabNroTelf = T007X4_n2558TrabNroTelf[0];
            AssignAttri("", false, "A2558TrabNroTelf", A2558TrabNroTelf);
            A2559TrabCorreo = T007X4_A2559TrabCorreo[0];
            n2559TrabCorreo = T007X4_n2559TrabCorreo[0];
            AssignAttri("", false, "A2559TrabCorreo", A2559TrabCorreo);
            A40000TrabImagen_GXI = T007X4_A40000TrabImagen_GXI[0];
            n40000TrabImagen_GXI = T007X4_n40000TrabImagen_GXI[0];
            AssignProp("", false, imgTrabImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.convertURL( context.PathToRelativeUrl( A2567TrabImagen))), true);
            AssignProp("", false, imgTrabImagen_Internalname, "SrcSet", context.GetImageSrcSet( A2567TrabImagen), true);
            A2567TrabImagen = T007X4_A2567TrabImagen[0];
            n2567TrabImagen = T007X4_n2567TrabImagen[0];
            AssignAttri("", false, "A2567TrabImagen", A2567TrabImagen);
            AssignProp("", false, imgTrabImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.convertURL( context.PathToRelativeUrl( A2567TrabImagen))), true);
            AssignProp("", false, imgTrabImagen_Internalname, "SrcSet", context.GetImageSrcSet( A2567TrabImagen), true);
            ZM7X220( -6) ;
         }
         pr_default.close(2);
         OnLoadActions7X220( ) ;
      }

      protected void OnLoadActions7X220( )
      {
         A2568TrabDescripcion = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
         AssignAttri("", false, "A2568TrabDescripcion", A2568TrabDescripcion);
      }

      protected void CheckExtendedTable7X220( )
      {
         nIsDirty_220 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         nIsDirty_220 = 1;
         A2568TrabDescripcion = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
         AssignAttri("", false, "A2568TrabDescripcion", A2568TrabDescripcion);
         if ( ! ( (DateTime.MinValue==A2529TrabFechNac) || ( DateTimeUtil.ResetTime ( A2529TrabFechNac ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Nacimiento fuera de rango", "OutOfRange", 1, "TRABFECHNAC");
            AnyError = 1;
            GX_FocusControl = edtTrabFechNac_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A2523TrabFechIng) || ( DateTimeUtil.ResetTime ( A2523TrabFechIng ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Trab Fech Ing fuera de rango", "OutOfRange", 1, "TRABFECHING");
            AnyError = 1;
            GX_FocusControl = edtTrabFechIng_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A2571TrabFechFin) || ( A2571TrabFechFin >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Baja fuera de rango", "OutOfRange", 1, "TRABFECHFIN");
            AnyError = 1;
            GX_FocusControl = edtTrabFechFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A2559TrabCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A2559TrabCorreo)) ) )
         {
            GX_msglist.addItem("El valor de Trab Correo no coincide con el patrón especificado", "OutOfRange", 1, "TRABCORREO");
            AnyError = 1;
            GX_FocusControl = edtTrabCorreo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7X220( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7X220( )
      {
         /* Using cursor T007X5 */
         pr_default.execute(3, new Object[] {A2417TrabCodigo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound220 = 1;
         }
         else
         {
            RcdFound220 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007X3 */
         pr_default.execute(1, new Object[] {A2417TrabCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7X220( 6) ;
            RcdFound220 = 1;
            A2417TrabCodigo = T007X3_A2417TrabCodigo[0];
            AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
            A2512Trab_TipDocCodigo = T007X3_A2512Trab_TipDocCodigo[0];
            n2512Trab_TipDocCodigo = T007X3_n2512Trab_TipDocCodigo[0];
            AssignAttri("", false, "A2512Trab_TipDocCodigo", StringUtil.LTrimStr( (decimal)(A2512Trab_TipDocCodigo), 4, 0));
            A2528TrabCodInterno = T007X3_A2528TrabCodInterno[0];
            n2528TrabCodInterno = T007X3_n2528TrabCodInterno[0];
            AssignAttri("", false, "A2528TrabCodInterno", A2528TrabCodInterno);
            A2525TrabApePat = T007X3_A2525TrabApePat[0];
            n2525TrabApePat = T007X3_n2525TrabApePat[0];
            AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
            A2526TrabApeMat = T007X3_A2526TrabApeMat[0];
            n2526TrabApeMat = T007X3_n2526TrabApeMat[0];
            AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
            A2527TrabNombres = T007X3_A2527TrabNombres[0];
            n2527TrabNombres = T007X3_n2527TrabNombres[0];
            AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
            A2529TrabFechNac = T007X3_A2529TrabFechNac[0];
            n2529TrabFechNac = T007X3_n2529TrabFechNac[0];
            AssignAttri("", false, "A2529TrabFechNac", context.localUtil.Format(A2529TrabFechNac, "99/99/99"));
            A2530TrabSexo = T007X3_A2530TrabSexo[0];
            n2530TrabSexo = T007X3_n2530TrabSexo[0];
            AssignAttri("", false, "A2530TrabSexo", StringUtil.Str( (decimal)(A2530TrabSexo), 1, 0));
            A2524TrabEstado = T007X3_A2524TrabEstado[0];
            n2524TrabEstado = T007X3_n2524TrabEstado[0];
            AssignAttri("", false, "A2524TrabEstado", StringUtil.Str( (decimal)(A2524TrabEstado), 1, 0));
            A2523TrabFechIng = T007X3_A2523TrabFechIng[0];
            n2523TrabFechIng = T007X3_n2523TrabFechIng[0];
            AssignAttri("", false, "A2523TrabFechIng", context.localUtil.Format(A2523TrabFechIng, "99/99/99"));
            A2571TrabFechFin = T007X3_A2571TrabFechFin[0];
            n2571TrabFechFin = T007X3_n2571TrabFechFin[0];
            AssignAttri("", false, "A2571TrabFechFin", context.localUtil.TToC( A2571TrabFechFin, 8, 5, 0, 3, "/", ":", " "));
            A2558TrabNroTelf = T007X3_A2558TrabNroTelf[0];
            n2558TrabNroTelf = T007X3_n2558TrabNroTelf[0];
            AssignAttri("", false, "A2558TrabNroTelf", A2558TrabNroTelf);
            A2559TrabCorreo = T007X3_A2559TrabCorreo[0];
            n2559TrabCorreo = T007X3_n2559TrabCorreo[0];
            AssignAttri("", false, "A2559TrabCorreo", A2559TrabCorreo);
            A40000TrabImagen_GXI = T007X3_A40000TrabImagen_GXI[0];
            n40000TrabImagen_GXI = T007X3_n40000TrabImagen_GXI[0];
            AssignProp("", false, imgTrabImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.convertURL( context.PathToRelativeUrl( A2567TrabImagen))), true);
            AssignProp("", false, imgTrabImagen_Internalname, "SrcSet", context.GetImageSrcSet( A2567TrabImagen), true);
            A2567TrabImagen = T007X3_A2567TrabImagen[0];
            n2567TrabImagen = T007X3_n2567TrabImagen[0];
            AssignAttri("", false, "A2567TrabImagen", A2567TrabImagen);
            AssignProp("", false, imgTrabImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.convertURL( context.PathToRelativeUrl( A2567TrabImagen))), true);
            AssignProp("", false, imgTrabImagen_Internalname, "SrcSet", context.GetImageSrcSet( A2567TrabImagen), true);
            Z2417TrabCodigo = A2417TrabCodigo;
            sMode220 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7X220( ) ;
            if ( AnyError == 1 )
            {
               RcdFound220 = 0;
               InitializeNonKey7X220( ) ;
            }
            Gx_mode = sMode220;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound220 = 0;
            InitializeNonKey7X220( ) ;
            sMode220 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode220;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7X220( ) ;
         if ( RcdFound220 == 0 )
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
         RcdFound220 = 0;
         /* Using cursor T007X6 */
         pr_default.execute(4, new Object[] {A2417TrabCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T007X6_A2417TrabCodigo[0], A2417TrabCodigo) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T007X6_A2417TrabCodigo[0], A2417TrabCodigo) > 0 ) ) )
            {
               A2417TrabCodigo = T007X6_A2417TrabCodigo[0];
               AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
               RcdFound220 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound220 = 0;
         /* Using cursor T007X7 */
         pr_default.execute(5, new Object[] {A2417TrabCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T007X7_A2417TrabCodigo[0], A2417TrabCodigo) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T007X7_A2417TrabCodigo[0], A2417TrabCodigo) < 0 ) ) )
            {
               A2417TrabCodigo = T007X7_A2417TrabCodigo[0];
               AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
               RcdFound220 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7X220( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrabCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7X220( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound220 == 1 )
            {
               if ( StringUtil.StrCmp(A2417TrabCodigo, Z2417TrabCodigo) != 0 )
               {
                  A2417TrabCodigo = Z2417TrabCodigo;
                  AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRABCODIGO");
                  AnyError = 1;
                  GX_FocusControl = edtTrabCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrabCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7X220( ) ;
                  GX_FocusControl = edtTrabCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2417TrabCodigo, Z2417TrabCodigo) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrabCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7X220( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRABCODIGO");
                     AnyError = 1;
                     GX_FocusControl = edtTrabCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrabCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7X220( ) ;
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
         if ( StringUtil.StrCmp(A2417TrabCodigo, Z2417TrabCodigo) != 0 )
         {
            A2417TrabCodigo = Z2417TrabCodigo;
            AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRABCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTrabCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrabCodigo_Internalname;
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
         if ( RcdFound220 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRABCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTrabCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7X220( ) ;
         if ( RcdFound220 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7X220( ) ;
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
         if ( RcdFound220 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
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
         if ( RcdFound220 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
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
         ScanStart7X220( ) ;
         if ( RcdFound220 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound220 != 0 )
            {
               ScanNext7X220( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7X220( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7X220( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007X2 */
            pr_default.execute(0, new Object[] {A2417TrabCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trab_Trabajador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z2512Trab_TipDocCodigo != T007X2_A2512Trab_TipDocCodigo[0] ) || ( StringUtil.StrCmp(Z2528TrabCodInterno, T007X2_A2528TrabCodInterno[0]) != 0 ) || ( StringUtil.StrCmp(Z2525TrabApePat, T007X2_A2525TrabApePat[0]) != 0 ) || ( StringUtil.StrCmp(Z2526TrabApeMat, T007X2_A2526TrabApeMat[0]) != 0 ) || ( StringUtil.StrCmp(Z2527TrabNombres, T007X2_A2527TrabNombres[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z2529TrabFechNac ) != DateTimeUtil.ResetTime ( T007X2_A2529TrabFechNac[0] ) ) || ( Z2530TrabSexo != T007X2_A2530TrabSexo[0] ) || ( Z2524TrabEstado != T007X2_A2524TrabEstado[0] ) || ( DateTimeUtil.ResetTime ( Z2523TrabFechIng ) != DateTimeUtil.ResetTime ( T007X2_A2523TrabFechIng[0] ) ) || ( Z2571TrabFechFin != T007X2_A2571TrabFechFin[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2558TrabNroTelf, T007X2_A2558TrabNroTelf[0]) != 0 ) || ( StringUtil.StrCmp(Z2559TrabCorreo, T007X2_A2559TrabCorreo[0]) != 0 ) )
            {
               if ( Z2512Trab_TipDocCodigo != T007X2_A2512Trab_TipDocCodigo[0] )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"Trab_TipDocCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z2512Trab_TipDocCodigo);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2512Trab_TipDocCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z2528TrabCodInterno, T007X2_A2528TrabCodInterno[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabCodInterno");
                  GXUtil.WriteLogRaw("Old: ",Z2528TrabCodInterno);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2528TrabCodInterno[0]);
               }
               if ( StringUtil.StrCmp(Z2525TrabApePat, T007X2_A2525TrabApePat[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabApePat");
                  GXUtil.WriteLogRaw("Old: ",Z2525TrabApePat);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2525TrabApePat[0]);
               }
               if ( StringUtil.StrCmp(Z2526TrabApeMat, T007X2_A2526TrabApeMat[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabApeMat");
                  GXUtil.WriteLogRaw("Old: ",Z2526TrabApeMat);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2526TrabApeMat[0]);
               }
               if ( StringUtil.StrCmp(Z2527TrabNombres, T007X2_A2527TrabNombres[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabNombres");
                  GXUtil.WriteLogRaw("Old: ",Z2527TrabNombres);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2527TrabNombres[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2529TrabFechNac ) != DateTimeUtil.ResetTime ( T007X2_A2529TrabFechNac[0] ) )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabFechNac");
                  GXUtil.WriteLogRaw("Old: ",Z2529TrabFechNac);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2529TrabFechNac[0]);
               }
               if ( Z2530TrabSexo != T007X2_A2530TrabSexo[0] )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabSexo");
                  GXUtil.WriteLogRaw("Old: ",Z2530TrabSexo);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2530TrabSexo[0]);
               }
               if ( Z2524TrabEstado != T007X2_A2524TrabEstado[0] )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabEstado");
                  GXUtil.WriteLogRaw("Old: ",Z2524TrabEstado);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2524TrabEstado[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2523TrabFechIng ) != DateTimeUtil.ResetTime ( T007X2_A2523TrabFechIng[0] ) )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabFechIng");
                  GXUtil.WriteLogRaw("Old: ",Z2523TrabFechIng);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2523TrabFechIng[0]);
               }
               if ( Z2571TrabFechFin != T007X2_A2571TrabFechFin[0] )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabFechFin");
                  GXUtil.WriteLogRaw("Old: ",Z2571TrabFechFin);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2571TrabFechFin[0]);
               }
               if ( StringUtil.StrCmp(Z2558TrabNroTelf, T007X2_A2558TrabNroTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabNroTelf");
                  GXUtil.WriteLogRaw("Old: ",Z2558TrabNroTelf);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2558TrabNroTelf[0]);
               }
               if ( StringUtil.StrCmp(Z2559TrabCorreo, T007X2_A2559TrabCorreo[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.trab_trabajador:[seudo value changed for attri]"+"TrabCorreo");
                  GXUtil.WriteLogRaw("Old: ",Z2559TrabCorreo);
                  GXUtil.WriteLogRaw("Current: ",T007X2_A2559TrabCorreo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trab_Trabajador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7X220( )
      {
         BeforeValidate7X220( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7X220( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7X220( 0) ;
            CheckOptimisticConcurrency7X220( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7X220( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7X220( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007X8 */
                     pr_default.execute(6, new Object[] {A2417TrabCodigo, n2512Trab_TipDocCodigo, A2512Trab_TipDocCodigo, n2528TrabCodInterno, A2528TrabCodInterno, n2525TrabApePat, A2525TrabApePat, n2526TrabApeMat, A2526TrabApeMat, n2527TrabNombres, A2527TrabNombres, n2529TrabFechNac, A2529TrabFechNac, n2530TrabSexo, A2530TrabSexo, n2524TrabEstado, A2524TrabEstado, n2523TrabFechIng, A2523TrabFechIng, n2571TrabFechFin, A2571TrabFechFin, n2558TrabNroTelf, A2558TrabNroTelf, n2559TrabCorreo, A2559TrabCorreo, n2567TrabImagen, A2567TrabImagen, n40000TrabImagen_GXI, A40000TrabImagen_GXI});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Trab_Trabajador");
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
                           ResetCaption7X0( ) ;
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
               Load7X220( ) ;
            }
            EndLevel7X220( ) ;
         }
         CloseExtendedTableCursors7X220( ) ;
      }

      protected void Update7X220( )
      {
         BeforeValidate7X220( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7X220( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7X220( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7X220( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7X220( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007X9 */
                     pr_default.execute(7, new Object[] {n2512Trab_TipDocCodigo, A2512Trab_TipDocCodigo, n2528TrabCodInterno, A2528TrabCodInterno, n2525TrabApePat, A2525TrabApePat, n2526TrabApeMat, A2526TrabApeMat, n2527TrabNombres, A2527TrabNombres, n2529TrabFechNac, A2529TrabFechNac, n2530TrabSexo, A2530TrabSexo, n2524TrabEstado, A2524TrabEstado, n2523TrabFechIng, A2523TrabFechIng, n2571TrabFechFin, A2571TrabFechFin, n2558TrabNroTelf, A2558TrabNroTelf, n2559TrabCorreo, A2559TrabCorreo, A2417TrabCodigo});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Trab_Trabajador");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trab_Trabajador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7X220( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7X0( ) ;
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
            EndLevel7X220( ) ;
         }
         CloseExtendedTableCursors7X220( ) ;
      }

      protected void DeferredUpdate7X220( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T007X10 */
            pr_default.execute(8, new Object[] {n2567TrabImagen, A2567TrabImagen, n40000TrabImagen_GXI, A40000TrabImagen_GXI, A2417TrabCodigo});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("Trab_Trabajador");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7X220( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7X220( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7X220( ) ;
            AfterConfirm7X220( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7X220( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007X11 */
                  pr_default.execute(9, new Object[] {A2417TrabCodigo});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("Trab_Trabajador");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound220 == 0 )
                        {
                           InitAll7X220( ) ;
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
                        ResetCaption7X0( ) ;
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
         sMode220 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7X220( ) ;
         Gx_mode = sMode220;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7X220( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A2568TrabDescripcion = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
            AssignAttri("", false, "A2568TrabDescripcion", A2568TrabDescripcion);
         }
      }

      protected void EndLevel7X220( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7X220( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("reloj_interface.trab_trabajador",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("reloj_interface.trab_trabajador",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7X220( )
      {
         /* Using cursor T007X12 */
         pr_default.execute(10);
         RcdFound220 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound220 = 1;
            A2417TrabCodigo = T007X12_A2417TrabCodigo[0];
            AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7X220( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound220 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound220 = 1;
            A2417TrabCodigo = T007X12_A2417TrabCodigo[0];
            AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
         }
      }

      protected void ScanEnd7X220( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm7X220( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7X220( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7X220( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7X220( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7X220( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7X220( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7X220( )
      {
         edtTrabCodigo_Enabled = 0;
         AssignProp("", false, edtTrabCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabCodigo_Enabled), 5, 0), true);
         edtTrab_TipDocCodigo_Enabled = 0;
         AssignProp("", false, edtTrab_TipDocCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrab_TipDocCodigo_Enabled), 5, 0), true);
         edtTrabCodInterno_Enabled = 0;
         AssignProp("", false, edtTrabCodInterno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabCodInterno_Enabled), 5, 0), true);
         edtTrabApePat_Enabled = 0;
         AssignProp("", false, edtTrabApePat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabApePat_Enabled), 5, 0), true);
         edtTrabApeMat_Enabled = 0;
         AssignProp("", false, edtTrabApeMat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabApeMat_Enabled), 5, 0), true);
         edtTrabNombres_Enabled = 0;
         AssignProp("", false, edtTrabNombres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabNombres_Enabled), 5, 0), true);
         edtTrabFechNac_Enabled = 0;
         AssignProp("", false, edtTrabFechNac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabFechNac_Enabled), 5, 0), true);
         edtTrabSexo_Enabled = 0;
         AssignProp("", false, edtTrabSexo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabSexo_Enabled), 5, 0), true);
         edtTrabEstado_Enabled = 0;
         AssignProp("", false, edtTrabEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabEstado_Enabled), 5, 0), true);
         edtTrabFechIng_Enabled = 0;
         AssignProp("", false, edtTrabFechIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabFechIng_Enabled), 5, 0), true);
         edtTrabFechFin_Enabled = 0;
         AssignProp("", false, edtTrabFechFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabFechFin_Enabled), 5, 0), true);
         edtTrabNroTelf_Enabled = 0;
         AssignProp("", false, edtTrabNroTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabNroTelf_Enabled), 5, 0), true);
         edtTrabCorreo_Enabled = 0;
         AssignProp("", false, edtTrabCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabCorreo_Enabled), 5, 0), true);
         edtTrabDescripcion_Enabled = 0;
         AssignProp("", false, edtTrabDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrabDescripcion_Enabled), 5, 0), true);
         imgTrabImagen_Enabled = 0;
         AssignProp("", false, imgTrabImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgTrabImagen_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7X220( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7X0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181282567", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.trab_trabajador.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2417TrabCodigo", Z2417TrabCodigo);
         GxWebStd.gx_hidden_field( context, "Z2512Trab_TipDocCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2512Trab_TipDocCodigo), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2528TrabCodInterno", Z2528TrabCodInterno);
         GxWebStd.gx_hidden_field( context, "Z2525TrabApePat", Z2525TrabApePat);
         GxWebStd.gx_hidden_field( context, "Z2526TrabApeMat", Z2526TrabApeMat);
         GxWebStd.gx_hidden_field( context, "Z2527TrabNombres", Z2527TrabNombres);
         GxWebStd.gx_hidden_field( context, "Z2529TrabFechNac", context.localUtil.DToC( Z2529TrabFechNac, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2530TrabSexo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2530TrabSexo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2524TrabEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2524TrabEstado), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2523TrabFechIng", context.localUtil.DToC( Z2523TrabFechIng, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2571TrabFechFin", context.localUtil.TToC( Z2571TrabFechFin, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2558TrabNroTelf", Z2558TrabNroTelf);
         GxWebStd.gx_hidden_field( context, "Z2559TrabCorreo", Z2559TrabCorreo);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "TRABIMAGEN_GXI", A40000TrabImagen_GXI);
         GXCCtlgxBlob = "TRABIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A2567TrabImagen);
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
         return formatLink("reloj_interface.trab_trabajador.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Trab_Trabajador" ;
      }

      public override string GetPgmdesc( )
      {
         return "Trab_Trabajador" ;
      }

      protected void InitializeNonKey7X220( )
      {
         A2568TrabDescripcion = "";
         AssignAttri("", false, "A2568TrabDescripcion", A2568TrabDescripcion);
         A2512Trab_TipDocCodigo = 0;
         n2512Trab_TipDocCodigo = false;
         AssignAttri("", false, "A2512Trab_TipDocCodigo", StringUtil.LTrimStr( (decimal)(A2512Trab_TipDocCodigo), 4, 0));
         n2512Trab_TipDocCodigo = ((0==A2512Trab_TipDocCodigo) ? true : false);
         A2528TrabCodInterno = "";
         n2528TrabCodInterno = false;
         AssignAttri("", false, "A2528TrabCodInterno", A2528TrabCodInterno);
         n2528TrabCodInterno = (String.IsNullOrEmpty(StringUtil.RTrim( A2528TrabCodInterno)) ? true : false);
         A2525TrabApePat = "";
         n2525TrabApePat = false;
         AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
         n2525TrabApePat = (String.IsNullOrEmpty(StringUtil.RTrim( A2525TrabApePat)) ? true : false);
         A2526TrabApeMat = "";
         n2526TrabApeMat = false;
         AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
         n2526TrabApeMat = (String.IsNullOrEmpty(StringUtil.RTrim( A2526TrabApeMat)) ? true : false);
         A2527TrabNombres = "";
         n2527TrabNombres = false;
         AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
         n2527TrabNombres = (String.IsNullOrEmpty(StringUtil.RTrim( A2527TrabNombres)) ? true : false);
         A2529TrabFechNac = DateTime.MinValue;
         n2529TrabFechNac = false;
         AssignAttri("", false, "A2529TrabFechNac", context.localUtil.Format(A2529TrabFechNac, "99/99/99"));
         n2529TrabFechNac = ((DateTime.MinValue==A2529TrabFechNac) ? true : false);
         A2530TrabSexo = 0;
         n2530TrabSexo = false;
         AssignAttri("", false, "A2530TrabSexo", StringUtil.Str( (decimal)(A2530TrabSexo), 1, 0));
         n2530TrabSexo = ((0==A2530TrabSexo) ? true : false);
         A2524TrabEstado = 0;
         n2524TrabEstado = false;
         AssignAttri("", false, "A2524TrabEstado", StringUtil.Str( (decimal)(A2524TrabEstado), 1, 0));
         n2524TrabEstado = ((0==A2524TrabEstado) ? true : false);
         A2523TrabFechIng = DateTime.MinValue;
         n2523TrabFechIng = false;
         AssignAttri("", false, "A2523TrabFechIng", context.localUtil.Format(A2523TrabFechIng, "99/99/99"));
         n2523TrabFechIng = ((DateTime.MinValue==A2523TrabFechIng) ? true : false);
         A2571TrabFechFin = (DateTime)(DateTime.MinValue);
         n2571TrabFechFin = false;
         AssignAttri("", false, "A2571TrabFechFin", context.localUtil.TToC( A2571TrabFechFin, 8, 5, 0, 3, "/", ":", " "));
         n2571TrabFechFin = ((DateTime.MinValue==A2571TrabFechFin) ? true : false);
         A2558TrabNroTelf = "";
         n2558TrabNroTelf = false;
         AssignAttri("", false, "A2558TrabNroTelf", A2558TrabNroTelf);
         n2558TrabNroTelf = (String.IsNullOrEmpty(StringUtil.RTrim( A2558TrabNroTelf)) ? true : false);
         A2559TrabCorreo = "";
         n2559TrabCorreo = false;
         AssignAttri("", false, "A2559TrabCorreo", A2559TrabCorreo);
         n2559TrabCorreo = (String.IsNullOrEmpty(StringUtil.RTrim( A2559TrabCorreo)) ? true : false);
         A2567TrabImagen = "";
         n2567TrabImagen = false;
         AssignAttri("", false, "A2567TrabImagen", A2567TrabImagen);
         AssignProp("", false, imgTrabImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.convertURL( context.PathToRelativeUrl( A2567TrabImagen))), true);
         AssignProp("", false, imgTrabImagen_Internalname, "SrcSet", context.GetImageSrcSet( A2567TrabImagen), true);
         n2567TrabImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? true : false);
         A40000TrabImagen_GXI = "";
         n40000TrabImagen_GXI = false;
         AssignProp("", false, imgTrabImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2567TrabImagen)) ? A40000TrabImagen_GXI : context.convertURL( context.PathToRelativeUrl( A2567TrabImagen))), true);
         AssignProp("", false, imgTrabImagen_Internalname, "SrcSet", context.GetImageSrcSet( A2567TrabImagen), true);
         Z2512Trab_TipDocCodigo = 0;
         Z2528TrabCodInterno = "";
         Z2525TrabApePat = "";
         Z2526TrabApeMat = "";
         Z2527TrabNombres = "";
         Z2529TrabFechNac = DateTime.MinValue;
         Z2530TrabSexo = 0;
         Z2524TrabEstado = 0;
         Z2523TrabFechIng = DateTime.MinValue;
         Z2571TrabFechFin = (DateTime)(DateTime.MinValue);
         Z2558TrabNroTelf = "";
         Z2559TrabCorreo = "";
      }

      protected void InitAll7X220( )
      {
         A2417TrabCodigo = "";
         AssignAttri("", false, "A2417TrabCodigo", A2417TrabCodigo);
         InitializeNonKey7X220( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181282573", true, true);
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
         context.AddJavascriptSource("reloj_interface/trab_trabajador.js", "?20228181282574", false, true);
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
         edtTrabCodigo_Internalname = "TRABCODIGO";
         edtTrab_TipDocCodigo_Internalname = "TRAB_TIPDOCCODIGO";
         edtTrabCodInterno_Internalname = "TRABCODINTERNO";
         edtTrabApePat_Internalname = "TRABAPEPAT";
         edtTrabApeMat_Internalname = "TRABAPEMAT";
         edtTrabNombres_Internalname = "TRABNOMBRES";
         edtTrabFechNac_Internalname = "TRABFECHNAC";
         edtTrabSexo_Internalname = "TRABSEXO";
         edtTrabEstado_Internalname = "TRABESTADO";
         edtTrabFechIng_Internalname = "TRABFECHING";
         edtTrabFechFin_Internalname = "TRABFECHFIN";
         edtTrabNroTelf_Internalname = "TRABNROTELF";
         edtTrabCorreo_Internalname = "TRABCORREO";
         edtTrabDescripcion_Internalname = "TRABDESCRIPCION";
         imgTrabImagen_Internalname = "TRABIMAGEN";
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
         Form.Caption = "Trab_Trabajador";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgTrabImagen_Enabled = 1;
         edtTrabDescripcion_Enabled = 0;
         edtTrabCorreo_Jsonclick = "";
         edtTrabCorreo_Enabled = 1;
         edtTrabNroTelf_Jsonclick = "";
         edtTrabNroTelf_Enabled = 1;
         edtTrabFechFin_Jsonclick = "";
         edtTrabFechFin_Enabled = 1;
         edtTrabFechIng_Jsonclick = "";
         edtTrabFechIng_Enabled = 1;
         edtTrabEstado_Jsonclick = "";
         edtTrabEstado_Enabled = 1;
         edtTrabSexo_Jsonclick = "";
         edtTrabSexo_Enabled = 1;
         edtTrabFechNac_Jsonclick = "";
         edtTrabFechNac_Enabled = 1;
         edtTrabNombres_Jsonclick = "";
         edtTrabNombres_Enabled = 1;
         edtTrabApeMat_Jsonclick = "";
         edtTrabApeMat_Enabled = 1;
         edtTrabApePat_Jsonclick = "";
         edtTrabApePat_Enabled = 1;
         edtTrabCodInterno_Jsonclick = "";
         edtTrabCodInterno_Enabled = 1;
         edtTrab_TipDocCodigo_Jsonclick = "";
         edtTrab_TipDocCodigo_Enabled = 1;
         edtTrabCodigo_Jsonclick = "";
         edtTrabCodigo_Enabled = 1;
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
         GX_FocusControl = edtTrab_TipDocCodigo_Internalname;
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

      public void Valid_Trabcodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2512Trab_TipDocCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2512Trab_TipDocCodigo), 4, 0, ".", "")));
         AssignAttri("", false, "A2528TrabCodInterno", A2528TrabCodInterno);
         AssignAttri("", false, "A2525TrabApePat", A2525TrabApePat);
         AssignAttri("", false, "A2526TrabApeMat", A2526TrabApeMat);
         AssignAttri("", false, "A2527TrabNombres", A2527TrabNombres);
         AssignAttri("", false, "A2529TrabFechNac", context.localUtil.Format(A2529TrabFechNac, "99/99/99"));
         AssignAttri("", false, "A2530TrabSexo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2530TrabSexo), 1, 0, ".", "")));
         AssignAttri("", false, "A2524TrabEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2524TrabEstado), 1, 0, ".", "")));
         AssignAttri("", false, "A2523TrabFechIng", context.localUtil.Format(A2523TrabFechIng, "99/99/99"));
         AssignAttri("", false, "A2571TrabFechFin", context.localUtil.TToC( A2571TrabFechFin, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A2558TrabNroTelf", A2558TrabNroTelf);
         AssignAttri("", false, "A2559TrabCorreo", A2559TrabCorreo);
         AssignAttri("", false, "A2567TrabImagen", context.PathToRelativeUrl( A2567TrabImagen));
         GXCCtlgxBlob = "TRABIMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A2567TrabImagen));
         AssignAttri("", false, "A40000TrabImagen_GXI", A40000TrabImagen_GXI);
         AssignAttri("", false, "A2568TrabDescripcion", A2568TrabDescripcion);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2417TrabCodigo", Z2417TrabCodigo);
         GxWebStd.gx_hidden_field( context, "Z2512Trab_TipDocCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2512Trab_TipDocCodigo), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2528TrabCodInterno", Z2528TrabCodInterno);
         GxWebStd.gx_hidden_field( context, "Z2525TrabApePat", Z2525TrabApePat);
         GxWebStd.gx_hidden_field( context, "Z2526TrabApeMat", Z2526TrabApeMat);
         GxWebStd.gx_hidden_field( context, "Z2527TrabNombres", Z2527TrabNombres);
         GxWebStd.gx_hidden_field( context, "Z2529TrabFechNac", context.localUtil.Format(Z2529TrabFechNac, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2530TrabSexo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2530TrabSexo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2524TrabEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2524TrabEstado), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2523TrabFechIng", context.localUtil.Format(Z2523TrabFechIng, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2571TrabFechFin", context.localUtil.TToC( Z2571TrabFechFin, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2558TrabNroTelf", Z2558TrabNroTelf);
         GxWebStd.gx_hidden_field( context, "Z2559TrabCorreo", Z2559TrabCorreo);
         GxWebStd.gx_hidden_field( context, "Z2567TrabImagen", context.PathToRelativeUrl( Z2567TrabImagen));
         GxWebStd.gx_hidden_field( context, "Z40000TrabImagen_GXI", Z40000TrabImagen_GXI);
         GxWebStd.gx_hidden_field( context, "Z2568TrabDescripcion", Z2568TrabDescripcion);
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
         setEventMetadata("VALID_TRABCODIGO","{handler:'Valid_Trabcodigo',iparms:[{av:'A2417TrabCodigo',fld:'TRABCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRABCODIGO",",oparms:[{av:'A2512Trab_TipDocCodigo',fld:'TRAB_TIPDOCCODIGO',pic:'ZZZ9'},{av:'A2528TrabCodInterno',fld:'TRABCODINTERNO',pic:''},{av:'A2525TrabApePat',fld:'TRABAPEPAT',pic:''},{av:'A2526TrabApeMat',fld:'TRABAPEMAT',pic:''},{av:'A2527TrabNombres',fld:'TRABNOMBRES',pic:''},{av:'A2529TrabFechNac',fld:'TRABFECHNAC',pic:''},{av:'A2530TrabSexo',fld:'TRABSEXO',pic:'9'},{av:'A2524TrabEstado',fld:'TRABESTADO',pic:'9'},{av:'A2523TrabFechIng',fld:'TRABFECHING',pic:''},{av:'A2571TrabFechFin',fld:'TRABFECHFIN',pic:'99/99/99 99:99'},{av:'A2558TrabNroTelf',fld:'TRABNROTELF',pic:''},{av:'A2559TrabCorreo',fld:'TRABCORREO',pic:''},{av:'A2567TrabImagen',fld:'TRABIMAGEN',pic:''},{av:'A40000TrabImagen_GXI',fld:'TRABIMAGEN_GXI',pic:''},{av:'A2568TrabDescripcion',fld:'TRABDESCRIPCION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2417TrabCodigo'},{av:'Z2512Trab_TipDocCodigo'},{av:'Z2528TrabCodInterno'},{av:'Z2525TrabApePat'},{av:'Z2526TrabApeMat'},{av:'Z2527TrabNombres'},{av:'Z2529TrabFechNac'},{av:'Z2530TrabSexo'},{av:'Z2524TrabEstado'},{av:'Z2523TrabFechIng'},{av:'Z2571TrabFechFin'},{av:'Z2558TrabNroTelf'},{av:'Z2559TrabCorreo'},{av:'Z2567TrabImagen'},{av:'Z40000TrabImagen_GXI'},{av:'Z2568TrabDescripcion'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRABAPEPAT","{handler:'Valid_Trabapepat',iparms:[]");
         setEventMetadata("VALID_TRABAPEPAT",",oparms:[]}");
         setEventMetadata("VALID_TRABAPEMAT","{handler:'Valid_Trabapemat',iparms:[]");
         setEventMetadata("VALID_TRABAPEMAT",",oparms:[]}");
         setEventMetadata("VALID_TRABNOMBRES","{handler:'Valid_Trabnombres',iparms:[]");
         setEventMetadata("VALID_TRABNOMBRES",",oparms:[]}");
         setEventMetadata("VALID_TRABFECHNAC","{handler:'Valid_Trabfechnac',iparms:[]");
         setEventMetadata("VALID_TRABFECHNAC",",oparms:[]}");
         setEventMetadata("VALID_TRABFECHING","{handler:'Valid_Trabfeching',iparms:[]");
         setEventMetadata("VALID_TRABFECHING",",oparms:[]}");
         setEventMetadata("VALID_TRABFECHFIN","{handler:'Valid_Trabfechfin',iparms:[]");
         setEventMetadata("VALID_TRABFECHFIN",",oparms:[]}");
         setEventMetadata("VALID_TRABCORREO","{handler:'Valid_Trabcorreo',iparms:[]");
         setEventMetadata("VALID_TRABCORREO",",oparms:[]}");
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
         Z2417TrabCodigo = "";
         Z2528TrabCodInterno = "";
         Z2525TrabApePat = "";
         Z2526TrabApeMat = "";
         Z2527TrabNombres = "";
         Z2529TrabFechNac = DateTime.MinValue;
         Z2523TrabFechIng = DateTime.MinValue;
         Z2571TrabFechFin = (DateTime)(DateTime.MinValue);
         Z2558TrabNroTelf = "";
         Z2559TrabCorreo = "";
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
         A2417TrabCodigo = "";
         A2528TrabCodInterno = "";
         A2525TrabApePat = "";
         A2526TrabApeMat = "";
         A2527TrabNombres = "";
         A2529TrabFechNac = DateTime.MinValue;
         A2523TrabFechIng = DateTime.MinValue;
         A2571TrabFechFin = (DateTime)(DateTime.MinValue);
         A2558TrabNroTelf = "";
         A2559TrabCorreo = "";
         A2568TrabDescripcion = "";
         A2567TrabImagen = "";
         A40000TrabImagen_GXI = "";
         sImgUrl = "";
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
         Z2567TrabImagen = "";
         Z40000TrabImagen_GXI = "";
         T007X4_A2417TrabCodigo = new string[] {""} ;
         T007X4_A2512Trab_TipDocCodigo = new short[1] ;
         T007X4_n2512Trab_TipDocCodigo = new bool[] {false} ;
         T007X4_A2528TrabCodInterno = new string[] {""} ;
         T007X4_n2528TrabCodInterno = new bool[] {false} ;
         T007X4_A2525TrabApePat = new string[] {""} ;
         T007X4_n2525TrabApePat = new bool[] {false} ;
         T007X4_A2526TrabApeMat = new string[] {""} ;
         T007X4_n2526TrabApeMat = new bool[] {false} ;
         T007X4_A2527TrabNombres = new string[] {""} ;
         T007X4_n2527TrabNombres = new bool[] {false} ;
         T007X4_A2529TrabFechNac = new DateTime[] {DateTime.MinValue} ;
         T007X4_n2529TrabFechNac = new bool[] {false} ;
         T007X4_A2530TrabSexo = new short[1] ;
         T007X4_n2530TrabSexo = new bool[] {false} ;
         T007X4_A2524TrabEstado = new short[1] ;
         T007X4_n2524TrabEstado = new bool[] {false} ;
         T007X4_A2523TrabFechIng = new DateTime[] {DateTime.MinValue} ;
         T007X4_n2523TrabFechIng = new bool[] {false} ;
         T007X4_A2571TrabFechFin = new DateTime[] {DateTime.MinValue} ;
         T007X4_n2571TrabFechFin = new bool[] {false} ;
         T007X4_A2558TrabNroTelf = new string[] {""} ;
         T007X4_n2558TrabNroTelf = new bool[] {false} ;
         T007X4_A2559TrabCorreo = new string[] {""} ;
         T007X4_n2559TrabCorreo = new bool[] {false} ;
         T007X4_A40000TrabImagen_GXI = new string[] {""} ;
         T007X4_n40000TrabImagen_GXI = new bool[] {false} ;
         T007X4_A2567TrabImagen = new string[] {""} ;
         T007X4_n2567TrabImagen = new bool[] {false} ;
         T007X5_A2417TrabCodigo = new string[] {""} ;
         T007X3_A2417TrabCodigo = new string[] {""} ;
         T007X3_A2512Trab_TipDocCodigo = new short[1] ;
         T007X3_n2512Trab_TipDocCodigo = new bool[] {false} ;
         T007X3_A2528TrabCodInterno = new string[] {""} ;
         T007X3_n2528TrabCodInterno = new bool[] {false} ;
         T007X3_A2525TrabApePat = new string[] {""} ;
         T007X3_n2525TrabApePat = new bool[] {false} ;
         T007X3_A2526TrabApeMat = new string[] {""} ;
         T007X3_n2526TrabApeMat = new bool[] {false} ;
         T007X3_A2527TrabNombres = new string[] {""} ;
         T007X3_n2527TrabNombres = new bool[] {false} ;
         T007X3_A2529TrabFechNac = new DateTime[] {DateTime.MinValue} ;
         T007X3_n2529TrabFechNac = new bool[] {false} ;
         T007X3_A2530TrabSexo = new short[1] ;
         T007X3_n2530TrabSexo = new bool[] {false} ;
         T007X3_A2524TrabEstado = new short[1] ;
         T007X3_n2524TrabEstado = new bool[] {false} ;
         T007X3_A2523TrabFechIng = new DateTime[] {DateTime.MinValue} ;
         T007X3_n2523TrabFechIng = new bool[] {false} ;
         T007X3_A2571TrabFechFin = new DateTime[] {DateTime.MinValue} ;
         T007X3_n2571TrabFechFin = new bool[] {false} ;
         T007X3_A2558TrabNroTelf = new string[] {""} ;
         T007X3_n2558TrabNroTelf = new bool[] {false} ;
         T007X3_A2559TrabCorreo = new string[] {""} ;
         T007X3_n2559TrabCorreo = new bool[] {false} ;
         T007X3_A40000TrabImagen_GXI = new string[] {""} ;
         T007X3_n40000TrabImagen_GXI = new bool[] {false} ;
         T007X3_A2567TrabImagen = new string[] {""} ;
         T007X3_n2567TrabImagen = new bool[] {false} ;
         sMode220 = "";
         T007X6_A2417TrabCodigo = new string[] {""} ;
         T007X7_A2417TrabCodigo = new string[] {""} ;
         T007X2_A2417TrabCodigo = new string[] {""} ;
         T007X2_A2512Trab_TipDocCodigo = new short[1] ;
         T007X2_n2512Trab_TipDocCodigo = new bool[] {false} ;
         T007X2_A2528TrabCodInterno = new string[] {""} ;
         T007X2_n2528TrabCodInterno = new bool[] {false} ;
         T007X2_A2525TrabApePat = new string[] {""} ;
         T007X2_n2525TrabApePat = new bool[] {false} ;
         T007X2_A2526TrabApeMat = new string[] {""} ;
         T007X2_n2526TrabApeMat = new bool[] {false} ;
         T007X2_A2527TrabNombres = new string[] {""} ;
         T007X2_n2527TrabNombres = new bool[] {false} ;
         T007X2_A2529TrabFechNac = new DateTime[] {DateTime.MinValue} ;
         T007X2_n2529TrabFechNac = new bool[] {false} ;
         T007X2_A2530TrabSexo = new short[1] ;
         T007X2_n2530TrabSexo = new bool[] {false} ;
         T007X2_A2524TrabEstado = new short[1] ;
         T007X2_n2524TrabEstado = new bool[] {false} ;
         T007X2_A2523TrabFechIng = new DateTime[] {DateTime.MinValue} ;
         T007X2_n2523TrabFechIng = new bool[] {false} ;
         T007X2_A2571TrabFechFin = new DateTime[] {DateTime.MinValue} ;
         T007X2_n2571TrabFechFin = new bool[] {false} ;
         T007X2_A2558TrabNroTelf = new string[] {""} ;
         T007X2_n2558TrabNroTelf = new bool[] {false} ;
         T007X2_A2559TrabCorreo = new string[] {""} ;
         T007X2_n2559TrabCorreo = new bool[] {false} ;
         T007X2_A40000TrabImagen_GXI = new string[] {""} ;
         T007X2_n40000TrabImagen_GXI = new bool[] {false} ;
         T007X2_A2567TrabImagen = new string[] {""} ;
         T007X2_n2567TrabImagen = new bool[] {false} ;
         T007X12_A2417TrabCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Z2568TrabDescripcion = "";
         ZZ2417TrabCodigo = "";
         ZZ2528TrabCodInterno = "";
         ZZ2525TrabApePat = "";
         ZZ2526TrabApeMat = "";
         ZZ2527TrabNombres = "";
         ZZ2529TrabFechNac = DateTime.MinValue;
         ZZ2523TrabFechIng = DateTime.MinValue;
         ZZ2571TrabFechFin = (DateTime)(DateTime.MinValue);
         ZZ2558TrabNroTelf = "";
         ZZ2559TrabCorreo = "";
         ZZ2567TrabImagen = "";
         ZZ40000TrabImagen_GXI = "";
         ZZ2568TrabDescripcion = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.trab_trabajador__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.trab_trabajador__default(),
            new Object[][] {
                new Object[] {
               T007X2_A2417TrabCodigo, T007X2_A2512Trab_TipDocCodigo, T007X2_n2512Trab_TipDocCodigo, T007X2_A2528TrabCodInterno, T007X2_n2528TrabCodInterno, T007X2_A2525TrabApePat, T007X2_n2525TrabApePat, T007X2_A2526TrabApeMat, T007X2_n2526TrabApeMat, T007X2_A2527TrabNombres,
               T007X2_n2527TrabNombres, T007X2_A2529TrabFechNac, T007X2_n2529TrabFechNac, T007X2_A2530TrabSexo, T007X2_n2530TrabSexo, T007X2_A2524TrabEstado, T007X2_n2524TrabEstado, T007X2_A2523TrabFechIng, T007X2_n2523TrabFechIng, T007X2_A2571TrabFechFin,
               T007X2_n2571TrabFechFin, T007X2_A2558TrabNroTelf, T007X2_n2558TrabNroTelf, T007X2_A2559TrabCorreo, T007X2_n2559TrabCorreo, T007X2_A40000TrabImagen_GXI, T007X2_n40000TrabImagen_GXI, T007X2_A2567TrabImagen, T007X2_n2567TrabImagen
               }
               , new Object[] {
               T007X3_A2417TrabCodigo, T007X3_A2512Trab_TipDocCodigo, T007X3_n2512Trab_TipDocCodigo, T007X3_A2528TrabCodInterno, T007X3_n2528TrabCodInterno, T007X3_A2525TrabApePat, T007X3_n2525TrabApePat, T007X3_A2526TrabApeMat, T007X3_n2526TrabApeMat, T007X3_A2527TrabNombres,
               T007X3_n2527TrabNombres, T007X3_A2529TrabFechNac, T007X3_n2529TrabFechNac, T007X3_A2530TrabSexo, T007X3_n2530TrabSexo, T007X3_A2524TrabEstado, T007X3_n2524TrabEstado, T007X3_A2523TrabFechIng, T007X3_n2523TrabFechIng, T007X3_A2571TrabFechFin,
               T007X3_n2571TrabFechFin, T007X3_A2558TrabNroTelf, T007X3_n2558TrabNroTelf, T007X3_A2559TrabCorreo, T007X3_n2559TrabCorreo, T007X3_A40000TrabImagen_GXI, T007X3_n40000TrabImagen_GXI, T007X3_A2567TrabImagen, T007X3_n2567TrabImagen
               }
               , new Object[] {
               T007X4_A2417TrabCodigo, T007X4_A2512Trab_TipDocCodigo, T007X4_n2512Trab_TipDocCodigo, T007X4_A2528TrabCodInterno, T007X4_n2528TrabCodInterno, T007X4_A2525TrabApePat, T007X4_n2525TrabApePat, T007X4_A2526TrabApeMat, T007X4_n2526TrabApeMat, T007X4_A2527TrabNombres,
               T007X4_n2527TrabNombres, T007X4_A2529TrabFechNac, T007X4_n2529TrabFechNac, T007X4_A2530TrabSexo, T007X4_n2530TrabSexo, T007X4_A2524TrabEstado, T007X4_n2524TrabEstado, T007X4_A2523TrabFechIng, T007X4_n2523TrabFechIng, T007X4_A2571TrabFechFin,
               T007X4_n2571TrabFechFin, T007X4_A2558TrabNroTelf, T007X4_n2558TrabNroTelf, T007X4_A2559TrabCorreo, T007X4_n2559TrabCorreo, T007X4_A40000TrabImagen_GXI, T007X4_n40000TrabImagen_GXI, T007X4_A2567TrabImagen, T007X4_n2567TrabImagen
               }
               , new Object[] {
               T007X5_A2417TrabCodigo
               }
               , new Object[] {
               T007X6_A2417TrabCodigo
               }
               , new Object[] {
               T007X7_A2417TrabCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007X12_A2417TrabCodigo
               }
            }
         );
      }

      private short Z2512Trab_TipDocCodigo ;
      private short Z2530TrabSexo ;
      private short Z2524TrabEstado ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2512Trab_TipDocCodigo ;
      private short A2530TrabSexo ;
      private short A2524TrabEstado ;
      private short GX_JID ;
      private short RcdFound220 ;
      private short nIsDirty_220 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2512Trab_TipDocCodigo ;
      private short ZZ2530TrabSexo ;
      private short ZZ2524TrabEstado ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrabCodigo_Enabled ;
      private int edtTrab_TipDocCodigo_Enabled ;
      private int edtTrabCodInterno_Enabled ;
      private int edtTrabApePat_Enabled ;
      private int edtTrabApeMat_Enabled ;
      private int edtTrabNombres_Enabled ;
      private int edtTrabFechNac_Enabled ;
      private int edtTrabSexo_Enabled ;
      private int edtTrabEstado_Enabled ;
      private int edtTrabFechIng_Enabled ;
      private int edtTrabFechFin_Enabled ;
      private int edtTrabNroTelf_Enabled ;
      private int edtTrabCorreo_Enabled ;
      private int edtTrabDescripcion_Enabled ;
      private int imgTrabImagen_Enabled ;
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
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrabCodigo_Internalname ;
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
      private string edtTrabCodigo_Jsonclick ;
      private string edtTrab_TipDocCodigo_Internalname ;
      private string edtTrab_TipDocCodigo_Jsonclick ;
      private string edtTrabCodInterno_Internalname ;
      private string edtTrabCodInterno_Jsonclick ;
      private string edtTrabApePat_Internalname ;
      private string edtTrabApePat_Jsonclick ;
      private string edtTrabApeMat_Internalname ;
      private string edtTrabApeMat_Jsonclick ;
      private string edtTrabNombres_Internalname ;
      private string edtTrabNombres_Jsonclick ;
      private string edtTrabFechNac_Internalname ;
      private string edtTrabFechNac_Jsonclick ;
      private string edtTrabSexo_Internalname ;
      private string edtTrabSexo_Jsonclick ;
      private string edtTrabEstado_Internalname ;
      private string edtTrabEstado_Jsonclick ;
      private string edtTrabFechIng_Internalname ;
      private string edtTrabFechIng_Jsonclick ;
      private string edtTrabFechFin_Internalname ;
      private string edtTrabFechFin_Jsonclick ;
      private string edtTrabNroTelf_Internalname ;
      private string edtTrabNroTelf_Jsonclick ;
      private string edtTrabCorreo_Internalname ;
      private string edtTrabCorreo_Jsonclick ;
      private string edtTrabDescripcion_Internalname ;
      private string imgTrabImagen_Internalname ;
      private string sImgUrl ;
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
      private string sMode220 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime Z2571TrabFechFin ;
      private DateTime A2571TrabFechFin ;
      private DateTime ZZ2571TrabFechFin ;
      private DateTime Z2529TrabFechNac ;
      private DateTime Z2523TrabFechIng ;
      private DateTime A2529TrabFechNac ;
      private DateTime A2523TrabFechIng ;
      private DateTime ZZ2529TrabFechNac ;
      private DateTime ZZ2523TrabFechIng ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A2567TrabImagen_IsBlob ;
      private bool n2512Trab_TipDocCodigo ;
      private bool n2528TrabCodInterno ;
      private bool n2525TrabApePat ;
      private bool n2526TrabApeMat ;
      private bool n2527TrabNombres ;
      private bool n2529TrabFechNac ;
      private bool n2530TrabSexo ;
      private bool n2524TrabEstado ;
      private bool n2523TrabFechIng ;
      private bool n2571TrabFechFin ;
      private bool n2558TrabNroTelf ;
      private bool n2559TrabCorreo ;
      private bool n40000TrabImagen_GXI ;
      private bool n2567TrabImagen ;
      private bool Gx_longc ;
      private string Z2417TrabCodigo ;
      private string Z2528TrabCodInterno ;
      private string Z2525TrabApePat ;
      private string Z2526TrabApeMat ;
      private string Z2527TrabNombres ;
      private string Z2558TrabNroTelf ;
      private string Z2559TrabCorreo ;
      private string A2417TrabCodigo ;
      private string A2528TrabCodInterno ;
      private string A2525TrabApePat ;
      private string A2526TrabApeMat ;
      private string A2527TrabNombres ;
      private string A2558TrabNroTelf ;
      private string A2559TrabCorreo ;
      private string A2568TrabDescripcion ;
      private string A40000TrabImagen_GXI ;
      private string Z40000TrabImagen_GXI ;
      private string Z2568TrabDescripcion ;
      private string ZZ2417TrabCodigo ;
      private string ZZ2528TrabCodInterno ;
      private string ZZ2525TrabApePat ;
      private string ZZ2526TrabApeMat ;
      private string ZZ2527TrabNombres ;
      private string ZZ2558TrabNroTelf ;
      private string ZZ2559TrabCorreo ;
      private string ZZ40000TrabImagen_GXI ;
      private string ZZ2568TrabDescripcion ;
      private string A2567TrabImagen ;
      private string Z2567TrabImagen ;
      private string ZZ2567TrabImagen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007X4_A2417TrabCodigo ;
      private short[] T007X4_A2512Trab_TipDocCodigo ;
      private bool[] T007X4_n2512Trab_TipDocCodigo ;
      private string[] T007X4_A2528TrabCodInterno ;
      private bool[] T007X4_n2528TrabCodInterno ;
      private string[] T007X4_A2525TrabApePat ;
      private bool[] T007X4_n2525TrabApePat ;
      private string[] T007X4_A2526TrabApeMat ;
      private bool[] T007X4_n2526TrabApeMat ;
      private string[] T007X4_A2527TrabNombres ;
      private bool[] T007X4_n2527TrabNombres ;
      private DateTime[] T007X4_A2529TrabFechNac ;
      private bool[] T007X4_n2529TrabFechNac ;
      private short[] T007X4_A2530TrabSexo ;
      private bool[] T007X4_n2530TrabSexo ;
      private short[] T007X4_A2524TrabEstado ;
      private bool[] T007X4_n2524TrabEstado ;
      private DateTime[] T007X4_A2523TrabFechIng ;
      private bool[] T007X4_n2523TrabFechIng ;
      private DateTime[] T007X4_A2571TrabFechFin ;
      private bool[] T007X4_n2571TrabFechFin ;
      private string[] T007X4_A2558TrabNroTelf ;
      private bool[] T007X4_n2558TrabNroTelf ;
      private string[] T007X4_A2559TrabCorreo ;
      private bool[] T007X4_n2559TrabCorreo ;
      private string[] T007X4_A40000TrabImagen_GXI ;
      private bool[] T007X4_n40000TrabImagen_GXI ;
      private string[] T007X4_A2567TrabImagen ;
      private bool[] T007X4_n2567TrabImagen ;
      private string[] T007X5_A2417TrabCodigo ;
      private string[] T007X3_A2417TrabCodigo ;
      private short[] T007X3_A2512Trab_TipDocCodigo ;
      private bool[] T007X3_n2512Trab_TipDocCodigo ;
      private string[] T007X3_A2528TrabCodInterno ;
      private bool[] T007X3_n2528TrabCodInterno ;
      private string[] T007X3_A2525TrabApePat ;
      private bool[] T007X3_n2525TrabApePat ;
      private string[] T007X3_A2526TrabApeMat ;
      private bool[] T007X3_n2526TrabApeMat ;
      private string[] T007X3_A2527TrabNombres ;
      private bool[] T007X3_n2527TrabNombres ;
      private DateTime[] T007X3_A2529TrabFechNac ;
      private bool[] T007X3_n2529TrabFechNac ;
      private short[] T007X3_A2530TrabSexo ;
      private bool[] T007X3_n2530TrabSexo ;
      private short[] T007X3_A2524TrabEstado ;
      private bool[] T007X3_n2524TrabEstado ;
      private DateTime[] T007X3_A2523TrabFechIng ;
      private bool[] T007X3_n2523TrabFechIng ;
      private DateTime[] T007X3_A2571TrabFechFin ;
      private bool[] T007X3_n2571TrabFechFin ;
      private string[] T007X3_A2558TrabNroTelf ;
      private bool[] T007X3_n2558TrabNroTelf ;
      private string[] T007X3_A2559TrabCorreo ;
      private bool[] T007X3_n2559TrabCorreo ;
      private string[] T007X3_A40000TrabImagen_GXI ;
      private bool[] T007X3_n40000TrabImagen_GXI ;
      private string[] T007X3_A2567TrabImagen ;
      private bool[] T007X3_n2567TrabImagen ;
      private string[] T007X6_A2417TrabCodigo ;
      private string[] T007X7_A2417TrabCodigo ;
      private string[] T007X2_A2417TrabCodigo ;
      private short[] T007X2_A2512Trab_TipDocCodigo ;
      private bool[] T007X2_n2512Trab_TipDocCodigo ;
      private string[] T007X2_A2528TrabCodInterno ;
      private bool[] T007X2_n2528TrabCodInterno ;
      private string[] T007X2_A2525TrabApePat ;
      private bool[] T007X2_n2525TrabApePat ;
      private string[] T007X2_A2526TrabApeMat ;
      private bool[] T007X2_n2526TrabApeMat ;
      private string[] T007X2_A2527TrabNombres ;
      private bool[] T007X2_n2527TrabNombres ;
      private DateTime[] T007X2_A2529TrabFechNac ;
      private bool[] T007X2_n2529TrabFechNac ;
      private short[] T007X2_A2530TrabSexo ;
      private bool[] T007X2_n2530TrabSexo ;
      private short[] T007X2_A2524TrabEstado ;
      private bool[] T007X2_n2524TrabEstado ;
      private DateTime[] T007X2_A2523TrabFechIng ;
      private bool[] T007X2_n2523TrabFechIng ;
      private DateTime[] T007X2_A2571TrabFechFin ;
      private bool[] T007X2_n2571TrabFechFin ;
      private string[] T007X2_A2558TrabNroTelf ;
      private bool[] T007X2_n2558TrabNroTelf ;
      private string[] T007X2_A2559TrabCorreo ;
      private bool[] T007X2_n2559TrabCorreo ;
      private string[] T007X2_A40000TrabImagen_GXI ;
      private bool[] T007X2_n40000TrabImagen_GXI ;
      private string[] T007X2_A2567TrabImagen ;
      private bool[] T007X2_n2567TrabImagen ;
      private string[] T007X12_A2417TrabCodigo ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class trab_trabajador__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class trab_trabajador__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007X4;
        prmT007X4 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X5;
        prmT007X5 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X3;
        prmT007X3 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X6;
        prmT007X6 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X7;
        prmT007X7 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X2;
        prmT007X2 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X8;
        prmT007X8 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0) ,
        new ParDef("@Trab_TipDocCodigo",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@TrabCodInterno",GXType.NVarChar,20,0){Nullable=true} ,
        new ParDef("@TrabApePat",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabApeMat",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabNombres",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabFechNac",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@TrabSexo",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@TrabEstado",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@TrabFechIng",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@TrabFechFin",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@TrabNroTelf",GXType.NVarChar,9,0){Nullable=true} ,
        new ParDef("@TrabCorreo",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@TrabImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=13, Tbl="Trab_Trabajador", Fld="TrabImagen"}
        };
        Object[] prmT007X9;
        prmT007X9 = new Object[] {
        new ParDef("@Trab_TipDocCodigo",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@TrabCodInterno",GXType.NVarChar,20,0){Nullable=true} ,
        new ParDef("@TrabApePat",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabApeMat",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabNombres",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabFechNac",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@TrabSexo",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@TrabEstado",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@TrabFechIng",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@TrabFechFin",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@TrabNroTelf",GXType.NVarChar,9,0){Nullable=true} ,
        new ParDef("@TrabCorreo",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X10;
        prmT007X10 = new Object[] {
        new ParDef("@TrabImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@TrabImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trab_Trabajador", Fld="TrabImagen"} ,
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X11;
        prmT007X11 = new Object[] {
        new ParDef("@TrabCodigo",GXType.NVarChar,20,0)
        };
        Object[] prmT007X12;
        prmT007X12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007X2", "SELECT [TrabCodigo], [Trab_TipDocCodigo], [TrabCodInterno], [TrabApePat], [TrabApeMat], [TrabNombres], [TrabFechNac], [TrabSexo], [TrabEstado], [TrabFechIng], [TrabFechFin], [TrabNroTelf], [TrabCorreo], [TrabImagen_GXI], [TrabImagen] FROM [Trab_Trabajador] WITH (UPDLOCK) WHERE [TrabCodigo] = @TrabCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT007X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007X3", "SELECT [TrabCodigo], [Trab_TipDocCodigo], [TrabCodInterno], [TrabApePat], [TrabApeMat], [TrabNombres], [TrabFechNac], [TrabSexo], [TrabEstado], [TrabFechIng], [TrabFechFin], [TrabNroTelf], [TrabCorreo], [TrabImagen_GXI], [TrabImagen] FROM [Trab_Trabajador] WHERE [TrabCodigo] = @TrabCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT007X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007X4", "SELECT TM1.[TrabCodigo], TM1.[Trab_TipDocCodigo], TM1.[TrabCodInterno], TM1.[TrabApePat], TM1.[TrabApeMat], TM1.[TrabNombres], TM1.[TrabFechNac], TM1.[TrabSexo], TM1.[TrabEstado], TM1.[TrabFechIng], TM1.[TrabFechFin], TM1.[TrabNroTelf], TM1.[TrabCorreo], TM1.[TrabImagen_GXI], TM1.[TrabImagen] FROM [Trab_Trabajador] TM1 WHERE TM1.[TrabCodigo] = @TrabCodigo ORDER BY TM1.[TrabCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007X4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007X5", "SELECT [TrabCodigo] FROM [Trab_Trabajador] WHERE [TrabCodigo] = @TrabCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007X6", "SELECT TOP 1 [TrabCodigo] FROM [Trab_Trabajador] WHERE ( [TrabCodigo] > @TrabCodigo) ORDER BY [TrabCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007X6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007X7", "SELECT TOP 1 [TrabCodigo] FROM [Trab_Trabajador] WHERE ( [TrabCodigo] < @TrabCodigo) ORDER BY [TrabCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007X7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007X8", "INSERT INTO [Trab_Trabajador]([TrabCodigo], [Trab_TipDocCodigo], [TrabCodInterno], [TrabApePat], [TrabApeMat], [TrabNombres], [TrabFechNac], [TrabSexo], [TrabEstado], [TrabFechIng], [TrabFechFin], [TrabNroTelf], [TrabCorreo], [TrabImagen], [TrabImagen_GXI]) VALUES(@TrabCodigo, @Trab_TipDocCodigo, @TrabCodInterno, @TrabApePat, @TrabApeMat, @TrabNombres, @TrabFechNac, @TrabSexo, @TrabEstado, @TrabFechIng, @TrabFechFin, @TrabNroTelf, @TrabCorreo, @TrabImagen, @TrabImagen_GXI)", GxErrorMask.GX_NOMASK,prmT007X8)
           ,new CursorDef("T007X9", "UPDATE [Trab_Trabajador] SET [Trab_TipDocCodigo]=@Trab_TipDocCodigo, [TrabCodInterno]=@TrabCodInterno, [TrabApePat]=@TrabApePat, [TrabApeMat]=@TrabApeMat, [TrabNombres]=@TrabNombres, [TrabFechNac]=@TrabFechNac, [TrabSexo]=@TrabSexo, [TrabEstado]=@TrabEstado, [TrabFechIng]=@TrabFechIng, [TrabFechFin]=@TrabFechFin, [TrabNroTelf]=@TrabNroTelf, [TrabCorreo]=@TrabCorreo  WHERE [TrabCodigo] = @TrabCodigo", GxErrorMask.GX_NOMASK,prmT007X9)
           ,new CursorDef("T007X10", "UPDATE [Trab_Trabajador] SET [TrabImagen]=@TrabImagen, [TrabImagen_GXI]=@TrabImagen_GXI  WHERE [TrabCodigo] = @TrabCodigo", GxErrorMask.GX_NOMASK,prmT007X10)
           ,new CursorDef("T007X11", "DELETE FROM [Trab_Trabajador]  WHERE [TrabCodigo] = @TrabCodigo", GxErrorMask.GX_NOMASK,prmT007X11)
           ,new CursorDef("T007X12", "SELECT [TrabCodigo] FROM [Trab_Trabajador] ORDER BY [TrabCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007X12,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((short[]) buf[13])[0] = rslt.getShort(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((short[]) buf[15])[0] = rslt.getShort(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((string[]) buf[23])[0] = rslt.getVarchar(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((string[]) buf[25])[0] = rslt.getMultimediaUri(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(14));
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((short[]) buf[13])[0] = rslt.getShort(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((short[]) buf[15])[0] = rslt.getShort(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((string[]) buf[23])[0] = rslt.getVarchar(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((string[]) buf[25])[0] = rslt.getMultimediaUri(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(14));
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((short[]) buf[13])[0] = rslt.getShort(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((short[]) buf[15])[0] = rslt.getShort(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((string[]) buf[23])[0] = rslt.getVarchar(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((string[]) buf[25])[0] = rslt.getMultimediaUri(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(14));
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
