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
   public class sgempresas : GXDataArea
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
            Form.Meta.addItem("description", "SGEMPRESAS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgempresas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgempresas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGEMPRESAS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGEMPRESAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGEMPRESAS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpCod_Internalname, "Codigo Empresa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A341EmpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtEmpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A341EmpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A341EmpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpDsc_Internalname, "Nombre Empresa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpDsc_Internalname, StringUtil.RTrim( A959EmpDsc), StringUtil.RTrim( context.localUtil.Format( A959EmpDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpODBC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpODBC_Internalname, "ODBC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpODBC_Internalname, StringUtil.RTrim( A961EmpODBC), StringUtil.RTrim( context.localUtil.Format( A961EmpODBC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpODBC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpODBC_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpAbr_Internalname, "Empresa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpAbr_Internalname, StringUtil.RTrim( A957EmpAbr), StringUtil.RTrim( context.localUtil.Format( A957EmpAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpAbr_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpDir_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpDir_Internalname, "Dirección", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpDir_Internalname, StringUtil.RTrim( A958EmpDir), StringUtil.RTrim( context.localUtil.Format( A958EmpDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpTelf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpTelf_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTelf_Internalname, StringUtil.RTrim( A965EmpTelf), StringUtil.RTrim( context.localUtil.Format( A965EmpTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpTelf_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpRUC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpRUC_Internalname, "R.U.C.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpRUC_Internalname, StringUtil.RTrim( A962EmpRUC), StringUtil.RTrim( context.localUtil.Format( A962EmpRUC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpRUC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpRUC_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpObs_Internalname, "Comentario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEmpObs_Internalname, A960EmpObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtEmpObs_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpUBIGEO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpUBIGEO_Internalname, "Ubigeo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpUBIGEO_Internalname, A968EmpUBIGEO, StringUtil.RTrim( context.localUtil.Format( A968EmpUBIGEO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpUBIGEO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpUBIGEO_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGEMPRESAS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGEMPRESAS.htm");
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
            Z341EmpCod = (int)(context.localUtil.CToN( cgiGet( "Z341EmpCod"), ".", ","));
            Z959EmpDsc = cgiGet( "Z959EmpDsc");
            Z961EmpODBC = cgiGet( "Z961EmpODBC");
            Z957EmpAbr = cgiGet( "Z957EmpAbr");
            Z958EmpDir = cgiGet( "Z958EmpDir");
            Z965EmpTelf = cgiGet( "Z965EmpTelf");
            Z962EmpRUC = cgiGet( "Z962EmpRUC");
            Z960EmpObs = cgiGet( "Z960EmpObs");
            Z968EmpUBIGEO = cgiGet( "Z968EmpUBIGEO");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEmpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A341EmpCod = 0;
               AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
            }
            else
            {
               A341EmpCod = (int)(context.localUtil.CToN( cgiGet( edtEmpCod_Internalname), ".", ","));
               AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
            }
            A959EmpDsc = cgiGet( edtEmpDsc_Internalname);
            AssignAttri("", false, "A959EmpDsc", A959EmpDsc);
            A961EmpODBC = cgiGet( edtEmpODBC_Internalname);
            AssignAttri("", false, "A961EmpODBC", A961EmpODBC);
            A957EmpAbr = cgiGet( edtEmpAbr_Internalname);
            AssignAttri("", false, "A957EmpAbr", A957EmpAbr);
            A958EmpDir = cgiGet( edtEmpDir_Internalname);
            AssignAttri("", false, "A958EmpDir", A958EmpDir);
            A965EmpTelf = cgiGet( edtEmpTelf_Internalname);
            AssignAttri("", false, "A965EmpTelf", A965EmpTelf);
            A962EmpRUC = cgiGet( edtEmpRUC_Internalname);
            AssignAttri("", false, "A962EmpRUC", A962EmpRUC);
            A960EmpObs = cgiGet( edtEmpObs_Internalname);
            AssignAttri("", false, "A960EmpObs", A960EmpObs);
            A968EmpUBIGEO = cgiGet( edtEmpUBIGEO_Internalname);
            AssignAttri("", false, "A968EmpUBIGEO", A968EmpUBIGEO);
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
               A341EmpCod = (int)(NumberUtil.Val( GetPar( "EmpCod"), "."));
               AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
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
               InitAll0M22( ) ;
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
         DisableAttributes0M22( ) ;
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

      protected void ResetCaption0M0( )
      {
      }

      protected void ZM0M22( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z959EmpDsc = T000M3_A959EmpDsc[0];
               Z961EmpODBC = T000M3_A961EmpODBC[0];
               Z957EmpAbr = T000M3_A957EmpAbr[0];
               Z958EmpDir = T000M3_A958EmpDir[0];
               Z965EmpTelf = T000M3_A965EmpTelf[0];
               Z962EmpRUC = T000M3_A962EmpRUC[0];
               Z960EmpObs = T000M3_A960EmpObs[0];
               Z968EmpUBIGEO = T000M3_A968EmpUBIGEO[0];
            }
            else
            {
               Z959EmpDsc = A959EmpDsc;
               Z961EmpODBC = A961EmpODBC;
               Z957EmpAbr = A957EmpAbr;
               Z958EmpDir = A958EmpDir;
               Z965EmpTelf = A965EmpTelf;
               Z962EmpRUC = A962EmpRUC;
               Z960EmpObs = A960EmpObs;
               Z968EmpUBIGEO = A968EmpUBIGEO;
            }
         }
         if ( GX_JID == -1 )
         {
            Z341EmpCod = A341EmpCod;
            Z959EmpDsc = A959EmpDsc;
            Z961EmpODBC = A961EmpODBC;
            Z957EmpAbr = A957EmpAbr;
            Z958EmpDir = A958EmpDir;
            Z965EmpTelf = A965EmpTelf;
            Z962EmpRUC = A962EmpRUC;
            Z960EmpObs = A960EmpObs;
            Z968EmpUBIGEO = A968EmpUBIGEO;
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

      protected void Load0M22( )
      {
         /* Using cursor T000M4 */
         pr_default.execute(2, new Object[] {A341EmpCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A959EmpDsc = T000M4_A959EmpDsc[0];
            AssignAttri("", false, "A959EmpDsc", A959EmpDsc);
            A961EmpODBC = T000M4_A961EmpODBC[0];
            AssignAttri("", false, "A961EmpODBC", A961EmpODBC);
            A957EmpAbr = T000M4_A957EmpAbr[0];
            AssignAttri("", false, "A957EmpAbr", A957EmpAbr);
            A958EmpDir = T000M4_A958EmpDir[0];
            AssignAttri("", false, "A958EmpDir", A958EmpDir);
            A965EmpTelf = T000M4_A965EmpTelf[0];
            AssignAttri("", false, "A965EmpTelf", A965EmpTelf);
            A962EmpRUC = T000M4_A962EmpRUC[0];
            AssignAttri("", false, "A962EmpRUC", A962EmpRUC);
            A960EmpObs = T000M4_A960EmpObs[0];
            AssignAttri("", false, "A960EmpObs", A960EmpObs);
            A968EmpUBIGEO = T000M4_A968EmpUBIGEO[0];
            AssignAttri("", false, "A968EmpUBIGEO", A968EmpUBIGEO);
            ZM0M22( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0M22( ) ;
      }

      protected void OnLoadActions0M22( )
      {
      }

      protected void CheckExtendedTable0M22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0M22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M22( )
      {
         /* Using cursor T000M5 */
         pr_default.execute(3, new Object[] {A341EmpCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A341EmpCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M22( 1) ;
            RcdFound22 = 1;
            A341EmpCod = T000M3_A341EmpCod[0];
            AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
            A959EmpDsc = T000M3_A959EmpDsc[0];
            AssignAttri("", false, "A959EmpDsc", A959EmpDsc);
            A961EmpODBC = T000M3_A961EmpODBC[0];
            AssignAttri("", false, "A961EmpODBC", A961EmpODBC);
            A957EmpAbr = T000M3_A957EmpAbr[0];
            AssignAttri("", false, "A957EmpAbr", A957EmpAbr);
            A958EmpDir = T000M3_A958EmpDir[0];
            AssignAttri("", false, "A958EmpDir", A958EmpDir);
            A965EmpTelf = T000M3_A965EmpTelf[0];
            AssignAttri("", false, "A965EmpTelf", A965EmpTelf);
            A962EmpRUC = T000M3_A962EmpRUC[0];
            AssignAttri("", false, "A962EmpRUC", A962EmpRUC);
            A960EmpObs = T000M3_A960EmpObs[0];
            AssignAttri("", false, "A960EmpObs", A960EmpObs);
            A968EmpUBIGEO = T000M3_A968EmpUBIGEO[0];
            AssignAttri("", false, "A968EmpUBIGEO", A968EmpUBIGEO);
            Z341EmpCod = A341EmpCod;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0M22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0M22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0M22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M22( ) ;
         if ( RcdFound22 == 0 )
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
         RcdFound22 = 0;
         /* Using cursor T000M6 */
         pr_default.execute(4, new Object[] {A341EmpCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000M6_A341EmpCod[0] < A341EmpCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000M6_A341EmpCod[0] > A341EmpCod ) ) )
            {
               A341EmpCod = T000M6_A341EmpCod[0];
               AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000M7 */
         pr_default.execute(5, new Object[] {A341EmpCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A341EmpCod[0] > A341EmpCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A341EmpCod[0] < A341EmpCod ) ) )
            {
               A341EmpCod = T000M7_A341EmpCod[0];
               AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0M22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A341EmpCod != Z341EmpCod )
               {
                  A341EmpCod = Z341EmpCod;
                  AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0M22( ) ;
                  GX_FocusControl = edtEmpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A341EmpCod != Z341EmpCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEmpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0M22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEmpCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEmpCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0M22( ) ;
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
         if ( A341EmpCod != Z341EmpCod )
         {
            A341EmpCod = Z341EmpCod;
            AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPCOD");
            AnyError = 1;
            GX_FocusControl = edtEmpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmpCod_Internalname;
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
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "EMPCOD");
            AnyError = 1;
            GX_FocusControl = edtEmpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtEmpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0M22( ) ;
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
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpDsc_Internalname;
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
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpDsc_Internalname;
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
         ScanStart0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound22 != 0 )
            {
               ScanNext0M22( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0M22( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0M22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A341EmpCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGEMPRESAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z959EmpDsc, T000M2_A959EmpDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z961EmpODBC, T000M2_A961EmpODBC[0]) != 0 ) || ( StringUtil.StrCmp(Z957EmpAbr, T000M2_A957EmpAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z958EmpDir, T000M2_A958EmpDir[0]) != 0 ) || ( StringUtil.StrCmp(Z965EmpTelf, T000M2_A965EmpTelf[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z962EmpRUC, T000M2_A962EmpRUC[0]) != 0 ) || ( StringUtil.StrCmp(Z960EmpObs, T000M2_A960EmpObs[0]) != 0 ) || ( StringUtil.StrCmp(Z968EmpUBIGEO, T000M2_A968EmpUBIGEO[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z959EmpDsc, T000M2_A959EmpDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpDsc");
                  GXUtil.WriteLogRaw("Old: ",Z959EmpDsc);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A959EmpDsc[0]);
               }
               if ( StringUtil.StrCmp(Z961EmpODBC, T000M2_A961EmpODBC[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpODBC");
                  GXUtil.WriteLogRaw("Old: ",Z961EmpODBC);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A961EmpODBC[0]);
               }
               if ( StringUtil.StrCmp(Z957EmpAbr, T000M2_A957EmpAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpAbr");
                  GXUtil.WriteLogRaw("Old: ",Z957EmpAbr);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A957EmpAbr[0]);
               }
               if ( StringUtil.StrCmp(Z958EmpDir, T000M2_A958EmpDir[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpDir");
                  GXUtil.WriteLogRaw("Old: ",Z958EmpDir);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A958EmpDir[0]);
               }
               if ( StringUtil.StrCmp(Z965EmpTelf, T000M2_A965EmpTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpTelf");
                  GXUtil.WriteLogRaw("Old: ",Z965EmpTelf);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A965EmpTelf[0]);
               }
               if ( StringUtil.StrCmp(Z962EmpRUC, T000M2_A962EmpRUC[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpRUC");
                  GXUtil.WriteLogRaw("Old: ",Z962EmpRUC);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A962EmpRUC[0]);
               }
               if ( StringUtil.StrCmp(Z960EmpObs, T000M2_A960EmpObs[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpObs");
                  GXUtil.WriteLogRaw("Old: ",Z960EmpObs);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A960EmpObs[0]);
               }
               if ( StringUtil.StrCmp(Z968EmpUBIGEO, T000M2_A968EmpUBIGEO[0]) != 0 )
               {
                  GXUtil.WriteLog("sgempresas:[seudo value changed for attri]"+"EmpUBIGEO");
                  GXUtil.WriteLogRaw("Old: ",Z968EmpUBIGEO);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A968EmpUBIGEO[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGEMPRESAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M22( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M22( 0) ;
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M8 */
                     pr_default.execute(6, new Object[] {A341EmpCod, A959EmpDsc, A961EmpODBC, A957EmpAbr, A958EmpDir, A965EmpTelf, A962EmpRUC, A960EmpObs, A968EmpUBIGEO});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGEMPRESAS");
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
                           ResetCaption0M0( ) ;
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
               Load0M22( ) ;
            }
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void Update0M22( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M9 */
                     pr_default.execute(7, new Object[] {A959EmpDsc, A961EmpODBC, A957EmpAbr, A958EmpDir, A965EmpTelf, A962EmpRUC, A960EmpObs, A968EmpUBIGEO, A341EmpCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGEMPRESAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGEMPRESAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M22( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0M0( ) ;
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
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void DeferredUpdate0M22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M22( ) ;
            AfterConfirm0M22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M10 */
                  pr_default.execute(8, new Object[] {A341EmpCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGEMPRESAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound22 == 0 )
                        {
                           InitAll0M22( ) ;
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
                        ResetCaption0M0( ) ;
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0M22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgempresas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgempresas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M22( )
      {
         /* Using cursor T000M11 */
         pr_default.execute(9);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A341EmpCod = T000M11_A341EmpCod[0];
            AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M22( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A341EmpCod = T000M11_A341EmpCod[0];
            AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
         }
      }

      protected void ScanEnd0M22( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0M22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M22( )
      {
         edtEmpCod_Enabled = 0;
         AssignProp("", false, edtEmpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpCod_Enabled), 5, 0), true);
         edtEmpDsc_Enabled = 0;
         AssignProp("", false, edtEmpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpDsc_Enabled), 5, 0), true);
         edtEmpODBC_Enabled = 0;
         AssignProp("", false, edtEmpODBC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpODBC_Enabled), 5, 0), true);
         edtEmpAbr_Enabled = 0;
         AssignProp("", false, edtEmpAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpAbr_Enabled), 5, 0), true);
         edtEmpDir_Enabled = 0;
         AssignProp("", false, edtEmpDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpDir_Enabled), 5, 0), true);
         edtEmpTelf_Enabled = 0;
         AssignProp("", false, edtEmpTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTelf_Enabled), 5, 0), true);
         edtEmpRUC_Enabled = 0;
         AssignProp("", false, edtEmpRUC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpRUC_Enabled), 5, 0), true);
         edtEmpObs_Enabled = 0;
         AssignProp("", false, edtEmpObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpObs_Enabled), 5, 0), true);
         edtEmpUBIGEO_Enabled = 0;
         AssignProp("", false, edtEmpUBIGEO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpUBIGEO_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0M22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442386", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgempresas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z341EmpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z341EmpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z959EmpDsc", StringUtil.RTrim( Z959EmpDsc));
         GxWebStd.gx_hidden_field( context, "Z961EmpODBC", StringUtil.RTrim( Z961EmpODBC));
         GxWebStd.gx_hidden_field( context, "Z957EmpAbr", StringUtil.RTrim( Z957EmpAbr));
         GxWebStd.gx_hidden_field( context, "Z958EmpDir", StringUtil.RTrim( Z958EmpDir));
         GxWebStd.gx_hidden_field( context, "Z965EmpTelf", StringUtil.RTrim( Z965EmpTelf));
         GxWebStd.gx_hidden_field( context, "Z962EmpRUC", StringUtil.RTrim( Z962EmpRUC));
         GxWebStd.gx_hidden_field( context, "Z960EmpObs", Z960EmpObs);
         GxWebStd.gx_hidden_field( context, "Z968EmpUBIGEO", Z968EmpUBIGEO);
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
         return formatLink("sgempresas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGEMPRESAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGEMPRESAS" ;
      }

      protected void InitializeNonKey0M22( )
      {
         A959EmpDsc = "";
         AssignAttri("", false, "A959EmpDsc", A959EmpDsc);
         A961EmpODBC = "";
         AssignAttri("", false, "A961EmpODBC", A961EmpODBC);
         A957EmpAbr = "";
         AssignAttri("", false, "A957EmpAbr", A957EmpAbr);
         A958EmpDir = "";
         AssignAttri("", false, "A958EmpDir", A958EmpDir);
         A965EmpTelf = "";
         AssignAttri("", false, "A965EmpTelf", A965EmpTelf);
         A962EmpRUC = "";
         AssignAttri("", false, "A962EmpRUC", A962EmpRUC);
         A960EmpObs = "";
         AssignAttri("", false, "A960EmpObs", A960EmpObs);
         A968EmpUBIGEO = "";
         AssignAttri("", false, "A968EmpUBIGEO", A968EmpUBIGEO);
         Z959EmpDsc = "";
         Z961EmpODBC = "";
         Z957EmpAbr = "";
         Z958EmpDir = "";
         Z965EmpTelf = "";
         Z962EmpRUC = "";
         Z960EmpObs = "";
         Z968EmpUBIGEO = "";
      }

      protected void InitAll0M22( )
      {
         A341EmpCod = 0;
         AssignAttri("", false, "A341EmpCod", StringUtil.LTrimStr( (decimal)(A341EmpCod), 6, 0));
         InitializeNonKey0M22( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811442394", true, true);
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
         context.AddJavascriptSource("sgempresas.js", "?202281811442395", false, true);
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
         edtEmpCod_Internalname = "EMPCOD";
         edtEmpDsc_Internalname = "EMPDSC";
         edtEmpODBC_Internalname = "EMPODBC";
         edtEmpAbr_Internalname = "EMPABR";
         edtEmpDir_Internalname = "EMPDIR";
         edtEmpTelf_Internalname = "EMPTELF";
         edtEmpRUC_Internalname = "EMPRUC";
         edtEmpObs_Internalname = "EMPOBS";
         edtEmpUBIGEO_Internalname = "EMPUBIGEO";
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
         Form.Caption = "SGEMPRESAS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEmpUBIGEO_Jsonclick = "";
         edtEmpUBIGEO_Enabled = 1;
         edtEmpObs_Enabled = 1;
         edtEmpRUC_Jsonclick = "";
         edtEmpRUC_Enabled = 1;
         edtEmpTelf_Jsonclick = "";
         edtEmpTelf_Enabled = 1;
         edtEmpDir_Jsonclick = "";
         edtEmpDir_Enabled = 1;
         edtEmpAbr_Jsonclick = "";
         edtEmpAbr_Enabled = 1;
         edtEmpODBC_Jsonclick = "";
         edtEmpODBC_Enabled = 1;
         edtEmpDsc_Jsonclick = "";
         edtEmpDsc_Enabled = 1;
         edtEmpCod_Jsonclick = "";
         edtEmpCod_Enabled = 1;
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
         GX_FocusControl = edtEmpDsc_Internalname;
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

      public void Valid_Empcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A959EmpDsc", StringUtil.RTrim( A959EmpDsc));
         AssignAttri("", false, "A961EmpODBC", StringUtil.RTrim( A961EmpODBC));
         AssignAttri("", false, "A957EmpAbr", StringUtil.RTrim( A957EmpAbr));
         AssignAttri("", false, "A958EmpDir", StringUtil.RTrim( A958EmpDir));
         AssignAttri("", false, "A965EmpTelf", StringUtil.RTrim( A965EmpTelf));
         AssignAttri("", false, "A962EmpRUC", StringUtil.RTrim( A962EmpRUC));
         AssignAttri("", false, "A960EmpObs", A960EmpObs);
         AssignAttri("", false, "A968EmpUBIGEO", A968EmpUBIGEO);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z341EmpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z341EmpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z959EmpDsc", StringUtil.RTrim( Z959EmpDsc));
         GxWebStd.gx_hidden_field( context, "Z961EmpODBC", StringUtil.RTrim( Z961EmpODBC));
         GxWebStd.gx_hidden_field( context, "Z957EmpAbr", StringUtil.RTrim( Z957EmpAbr));
         GxWebStd.gx_hidden_field( context, "Z958EmpDir", StringUtil.RTrim( Z958EmpDir));
         GxWebStd.gx_hidden_field( context, "Z965EmpTelf", StringUtil.RTrim( Z965EmpTelf));
         GxWebStd.gx_hidden_field( context, "Z962EmpRUC", StringUtil.RTrim( Z962EmpRUC));
         GxWebStd.gx_hidden_field( context, "Z960EmpObs", Z960EmpObs);
         GxWebStd.gx_hidden_field( context, "Z968EmpUBIGEO", Z968EmpUBIGEO);
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
         setEventMetadata("VALID_EMPCOD","{handler:'Valid_Empcod',iparms:[{av:'A341EmpCod',fld:'EMPCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_EMPCOD",",oparms:[{av:'A959EmpDsc',fld:'EMPDSC',pic:''},{av:'A961EmpODBC',fld:'EMPODBC',pic:''},{av:'A957EmpAbr',fld:'EMPABR',pic:''},{av:'A958EmpDir',fld:'EMPDIR',pic:''},{av:'A965EmpTelf',fld:'EMPTELF',pic:''},{av:'A962EmpRUC',fld:'EMPRUC',pic:''},{av:'A960EmpObs',fld:'EMPOBS',pic:''},{av:'A968EmpUBIGEO',fld:'EMPUBIGEO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z341EmpCod'},{av:'Z959EmpDsc'},{av:'Z961EmpODBC'},{av:'Z957EmpAbr'},{av:'Z958EmpDir'},{av:'Z965EmpTelf'},{av:'Z962EmpRUC'},{av:'Z960EmpObs'},{av:'Z968EmpUBIGEO'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z959EmpDsc = "";
         Z961EmpODBC = "";
         Z957EmpAbr = "";
         Z958EmpDir = "";
         Z965EmpTelf = "";
         Z962EmpRUC = "";
         Z960EmpObs = "";
         Z968EmpUBIGEO = "";
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
         A959EmpDsc = "";
         A961EmpODBC = "";
         A957EmpAbr = "";
         A958EmpDir = "";
         A965EmpTelf = "";
         A962EmpRUC = "";
         A960EmpObs = "";
         A968EmpUBIGEO = "";
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
         T000M4_A341EmpCod = new int[1] ;
         T000M4_A959EmpDsc = new string[] {""} ;
         T000M4_A961EmpODBC = new string[] {""} ;
         T000M4_A957EmpAbr = new string[] {""} ;
         T000M4_A958EmpDir = new string[] {""} ;
         T000M4_A965EmpTelf = new string[] {""} ;
         T000M4_A962EmpRUC = new string[] {""} ;
         T000M4_A960EmpObs = new string[] {""} ;
         T000M4_A968EmpUBIGEO = new string[] {""} ;
         T000M5_A341EmpCod = new int[1] ;
         T000M3_A341EmpCod = new int[1] ;
         T000M3_A959EmpDsc = new string[] {""} ;
         T000M3_A961EmpODBC = new string[] {""} ;
         T000M3_A957EmpAbr = new string[] {""} ;
         T000M3_A958EmpDir = new string[] {""} ;
         T000M3_A965EmpTelf = new string[] {""} ;
         T000M3_A962EmpRUC = new string[] {""} ;
         T000M3_A960EmpObs = new string[] {""} ;
         T000M3_A968EmpUBIGEO = new string[] {""} ;
         sMode22 = "";
         T000M6_A341EmpCod = new int[1] ;
         T000M7_A341EmpCod = new int[1] ;
         T000M2_A341EmpCod = new int[1] ;
         T000M2_A959EmpDsc = new string[] {""} ;
         T000M2_A961EmpODBC = new string[] {""} ;
         T000M2_A957EmpAbr = new string[] {""} ;
         T000M2_A958EmpDir = new string[] {""} ;
         T000M2_A965EmpTelf = new string[] {""} ;
         T000M2_A962EmpRUC = new string[] {""} ;
         T000M2_A960EmpObs = new string[] {""} ;
         T000M2_A968EmpUBIGEO = new string[] {""} ;
         T000M11_A341EmpCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ959EmpDsc = "";
         ZZ961EmpODBC = "";
         ZZ957EmpAbr = "";
         ZZ958EmpDir = "";
         ZZ965EmpTelf = "";
         ZZ962EmpRUC = "";
         ZZ960EmpObs = "";
         ZZ968EmpUBIGEO = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgempresas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgempresas__default(),
            new Object[][] {
                new Object[] {
               T000M2_A341EmpCod, T000M2_A959EmpDsc, T000M2_A961EmpODBC, T000M2_A957EmpAbr, T000M2_A958EmpDir, T000M2_A965EmpTelf, T000M2_A962EmpRUC, T000M2_A960EmpObs, T000M2_A968EmpUBIGEO
               }
               , new Object[] {
               T000M3_A341EmpCod, T000M3_A959EmpDsc, T000M3_A961EmpODBC, T000M3_A957EmpAbr, T000M3_A958EmpDir, T000M3_A965EmpTelf, T000M3_A962EmpRUC, T000M3_A960EmpObs, T000M3_A968EmpUBIGEO
               }
               , new Object[] {
               T000M4_A341EmpCod, T000M4_A959EmpDsc, T000M4_A961EmpODBC, T000M4_A957EmpAbr, T000M4_A958EmpDir, T000M4_A965EmpTelf, T000M4_A962EmpRUC, T000M4_A960EmpObs, T000M4_A968EmpUBIGEO
               }
               , new Object[] {
               T000M5_A341EmpCod
               }
               , new Object[] {
               T000M6_A341EmpCod
               }
               , new Object[] {
               T000M7_A341EmpCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M11_A341EmpCod
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
      private short RcdFound22 ;
      private short nIsDirty_22 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z341EmpCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A341EmpCod ;
      private int edtEmpCod_Enabled ;
      private int edtEmpDsc_Enabled ;
      private int edtEmpODBC_Enabled ;
      private int edtEmpAbr_Enabled ;
      private int edtEmpDir_Enabled ;
      private int edtEmpTelf_Enabled ;
      private int edtEmpRUC_Enabled ;
      private int edtEmpObs_Enabled ;
      private int edtEmpUBIGEO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ341EmpCod ;
      private string sPrefix ;
      private string Z959EmpDsc ;
      private string Z961EmpODBC ;
      private string Z957EmpAbr ;
      private string Z958EmpDir ;
      private string Z965EmpTelf ;
      private string Z962EmpRUC ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmpCod_Internalname ;
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
      private string edtEmpCod_Jsonclick ;
      private string edtEmpDsc_Internalname ;
      private string A959EmpDsc ;
      private string edtEmpDsc_Jsonclick ;
      private string edtEmpODBC_Internalname ;
      private string A961EmpODBC ;
      private string edtEmpODBC_Jsonclick ;
      private string edtEmpAbr_Internalname ;
      private string A957EmpAbr ;
      private string edtEmpAbr_Jsonclick ;
      private string edtEmpDir_Internalname ;
      private string A958EmpDir ;
      private string edtEmpDir_Jsonclick ;
      private string edtEmpTelf_Internalname ;
      private string A965EmpTelf ;
      private string edtEmpTelf_Jsonclick ;
      private string edtEmpRUC_Internalname ;
      private string A962EmpRUC ;
      private string edtEmpRUC_Jsonclick ;
      private string edtEmpObs_Internalname ;
      private string edtEmpUBIGEO_Internalname ;
      private string edtEmpUBIGEO_Jsonclick ;
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
      private string sMode22 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ959EmpDsc ;
      private string ZZ961EmpODBC ;
      private string ZZ957EmpAbr ;
      private string ZZ958EmpDir ;
      private string ZZ965EmpTelf ;
      private string ZZ962EmpRUC ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z960EmpObs ;
      private string Z968EmpUBIGEO ;
      private string A960EmpObs ;
      private string A968EmpUBIGEO ;
      private string ZZ960EmpObs ;
      private string ZZ968EmpUBIGEO ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000M4_A341EmpCod ;
      private string[] T000M4_A959EmpDsc ;
      private string[] T000M4_A961EmpODBC ;
      private string[] T000M4_A957EmpAbr ;
      private string[] T000M4_A958EmpDir ;
      private string[] T000M4_A965EmpTelf ;
      private string[] T000M4_A962EmpRUC ;
      private string[] T000M4_A960EmpObs ;
      private string[] T000M4_A968EmpUBIGEO ;
      private int[] T000M5_A341EmpCod ;
      private int[] T000M3_A341EmpCod ;
      private string[] T000M3_A959EmpDsc ;
      private string[] T000M3_A961EmpODBC ;
      private string[] T000M3_A957EmpAbr ;
      private string[] T000M3_A958EmpDir ;
      private string[] T000M3_A965EmpTelf ;
      private string[] T000M3_A962EmpRUC ;
      private string[] T000M3_A960EmpObs ;
      private string[] T000M3_A968EmpUBIGEO ;
      private int[] T000M6_A341EmpCod ;
      private int[] T000M7_A341EmpCod ;
      private int[] T000M2_A341EmpCod ;
      private string[] T000M2_A959EmpDsc ;
      private string[] T000M2_A961EmpODBC ;
      private string[] T000M2_A957EmpAbr ;
      private string[] T000M2_A958EmpDir ;
      private string[] T000M2_A965EmpTelf ;
      private string[] T000M2_A962EmpRUC ;
      private string[] T000M2_A960EmpObs ;
      private string[] T000M2_A968EmpUBIGEO ;
      private int[] T000M11_A341EmpCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgempresas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgempresas__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000M4;
        prmT000M4 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M5;
        prmT000M5 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M3;
        prmT000M3 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M6;
        prmT000M6 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M7;
        prmT000M7 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M2;
        prmT000M2 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M8;
        prmT000M8 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0) ,
        new ParDef("@EmpDsc",GXType.NChar,100,0) ,
        new ParDef("@EmpODBC",GXType.NChar,15,0) ,
        new ParDef("@EmpAbr",GXType.NChar,20,0) ,
        new ParDef("@EmpDir",GXType.NChar,100,0) ,
        new ParDef("@EmpTelf",GXType.NChar,20,0) ,
        new ParDef("@EmpRUC",GXType.NChar,20,0) ,
        new ParDef("@EmpObs",GXType.NVarChar,200,0) ,
        new ParDef("@EmpUBIGEO",GXType.NVarChar,6,0)
        };
        Object[] prmT000M9;
        prmT000M9 = new Object[] {
        new ParDef("@EmpDsc",GXType.NChar,100,0) ,
        new ParDef("@EmpODBC",GXType.NChar,15,0) ,
        new ParDef("@EmpAbr",GXType.NChar,20,0) ,
        new ParDef("@EmpDir",GXType.NChar,100,0) ,
        new ParDef("@EmpTelf",GXType.NChar,20,0) ,
        new ParDef("@EmpRUC",GXType.NChar,20,0) ,
        new ParDef("@EmpObs",GXType.NVarChar,200,0) ,
        new ParDef("@EmpUBIGEO",GXType.NVarChar,6,0) ,
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M10;
        prmT000M10 = new Object[] {
        new ParDef("@EmpCod",GXType.Int32,6,0)
        };
        Object[] prmT000M11;
        prmT000M11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000M2", "SELECT [EmpCod], [EmpDsc], [EmpODBC], [EmpAbr], [EmpDir], [EmpTelf], [EmpRUC], [EmpObs], [EmpUBIGEO] FROM [SGEMPRESAS] WITH (UPDLOCK) WHERE [EmpCod] = @EmpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M3", "SELECT [EmpCod], [EmpDsc], [EmpODBC], [EmpAbr], [EmpDir], [EmpTelf], [EmpRUC], [EmpObs], [EmpUBIGEO] FROM [SGEMPRESAS] WHERE [EmpCod] = @EmpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M4", "SELECT TM1.[EmpCod], TM1.[EmpDsc], TM1.[EmpODBC], TM1.[EmpAbr], TM1.[EmpDir], TM1.[EmpTelf], TM1.[EmpRUC], TM1.[EmpObs], TM1.[EmpUBIGEO] FROM [SGEMPRESAS] TM1 WHERE TM1.[EmpCod] = @EmpCod ORDER BY TM1.[EmpCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M5", "SELECT [EmpCod] FROM [SGEMPRESAS] WHERE [EmpCod] = @EmpCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M6", "SELECT TOP 1 [EmpCod] FROM [SGEMPRESAS] WHERE ( [EmpCod] > @EmpCod) ORDER BY [EmpCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M7", "SELECT TOP 1 [EmpCod] FROM [SGEMPRESAS] WHERE ( [EmpCod] < @EmpCod) ORDER BY [EmpCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M8", "INSERT INTO [SGEMPRESAS]([EmpCod], [EmpDsc], [EmpODBC], [EmpAbr], [EmpDir], [EmpTelf], [EmpRUC], [EmpObs], [EmpUBIGEO]) VALUES(@EmpCod, @EmpDsc, @EmpODBC, @EmpAbr, @EmpDir, @EmpTelf, @EmpRUC, @EmpObs, @EmpUBIGEO)", GxErrorMask.GX_NOMASK,prmT000M8)
           ,new CursorDef("T000M9", "UPDATE [SGEMPRESAS] SET [EmpDsc]=@EmpDsc, [EmpODBC]=@EmpODBC, [EmpAbr]=@EmpAbr, [EmpDir]=@EmpDir, [EmpTelf]=@EmpTelf, [EmpRUC]=@EmpRUC, [EmpObs]=@EmpObs, [EmpUBIGEO]=@EmpUBIGEO  WHERE [EmpCod] = @EmpCod", GxErrorMask.GX_NOMASK,prmT000M9)
           ,new CursorDef("T000M10", "DELETE FROM [SGEMPRESAS]  WHERE [EmpCod] = @EmpCod", GxErrorMask.GX_NOMASK,prmT000M10)
           ,new CursorDef("T000M11", "SELECT [EmpCod] FROM [SGEMPRESAS] ORDER BY [EmpCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
