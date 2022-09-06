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
   public class reloj_lecturas : GXDataArea
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
            Form.Meta.addItem("description", "Reloj_Lecturas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtId_Lee_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reloj_lecturas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_lecturas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Reloj_Lecturas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtId_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtId_Lee_Internalname, "Id_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtId_Lee_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2577Id_Lee), 12, 0, ".", "")), StringUtil.LTrim( ((edtId_Lee_Enabled!=0) ? context.localUtil.Format( (decimal)(A2577Id_Lee), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2577Id_Lee), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtId_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtId_Lee_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCodEmp_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCodEmp_Lee_Internalname, "Emp_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCodEmp_Lee_Internalname, A2578CodEmp_Lee, StringUtil.RTrim( context.localUtil.Format( A2578CodEmp_Lee, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCodEmp_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCodEmp_Lee_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNomEmp_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNomEmp_Lee_Internalname, "Emp_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNomEmp_Lee_Internalname, A2579NomEmp_Lee, StringUtil.RTrim( context.localUtil.Format( A2579NomEmp_Lee, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNomEmp_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNomEmp_Lee_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtApeEmp_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtApeEmp_Lee_Internalname, "Emp_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtApeEmp_Lee_Internalname, A2580ApeEmp_Lee, StringUtil.RTrim( context.localUtil.Format( A2580ApeEmp_Lee, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtApeEmp_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtApeEmp_Lee_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMarca_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMarca_Lee_Internalname, "Marca_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMarca_Lee_Internalname, A2581Marca_Lee, StringUtil.RTrim( context.localUtil.Format( A2581Marca_Lee, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMarca_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMarca_Lee_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFec_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFec_Lee_Internalname, "Fec_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFec_Lee_Internalname, A2582Fec_Lee, StringUtil.RTrim( context.localUtil.Format( A2582Fec_Lee, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFec_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFec_Lee_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHora_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHora_Lee_Internalname, "Hora_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHora_Lee_Internalname, A2583Hora_Lee, StringUtil.RTrim( context.localUtil.Format( A2583Hora_Lee, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHora_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHora_Lee_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtanio_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtanio_Lee_Internalname, "anio_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtanio_Lee_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2584anio_Lee), 4, 0, ".", "")), StringUtil.LTrim( ((edtanio_Lee_Enabled!=0) ? context.localUtil.Format( (decimal)(A2584anio_Lee), "ZZZ9") : context.localUtil.Format( (decimal)(A2584anio_Lee), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtanio_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtanio_Lee_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMes_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMes_Lee_Internalname, "Mes_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMes_Lee_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2585Mes_Lee), 2, 0, ".", "")), StringUtil.LTrim( ((edtMes_Lee_Enabled!=0) ? context.localUtil.Format( (decimal)(A2585Mes_Lee), "Z9") : context.localUtil.Format( (decimal)(A2585Mes_Lee), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMes_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMes_Lee_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDia_Lee_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDia_Lee_Internalname, "Dia_Lee", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDia_Lee_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2586Dia_Lee), 2, 0, ".", "")), StringUtil.LTrim( ((edtDia_Lee_Enabled!=0) ? context.localUtil.Format( (decimal)(A2586Dia_Lee), "Z9") : context.localUtil.Format( (decimal)(A2586Dia_Lee), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDia_Lee_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDia_Lee_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Lecturas.htm");
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
            Z2577Id_Lee = (long)(context.localUtil.CToN( cgiGet( "Z2577Id_Lee"), ".", ","));
            Z2578CodEmp_Lee = cgiGet( "Z2578CodEmp_Lee");
            Z2579NomEmp_Lee = cgiGet( "Z2579NomEmp_Lee");
            Z2580ApeEmp_Lee = cgiGet( "Z2580ApeEmp_Lee");
            Z2581Marca_Lee = cgiGet( "Z2581Marca_Lee");
            Z2582Fec_Lee = cgiGet( "Z2582Fec_Lee");
            Z2583Hora_Lee = cgiGet( "Z2583Hora_Lee");
            Z2584anio_Lee = (short)(context.localUtil.CToN( cgiGet( "Z2584anio_Lee"), ".", ","));
            Z2585Mes_Lee = (short)(context.localUtil.CToN( cgiGet( "Z2585Mes_Lee"), ".", ","));
            Z2586Dia_Lee = (short)(context.localUtil.CToN( cgiGet( "Z2586Dia_Lee"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtId_Lee_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtId_Lee_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_LEE");
               AnyError = 1;
               GX_FocusControl = edtId_Lee_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2577Id_Lee = 0;
               AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
            }
            else
            {
               A2577Id_Lee = (long)(context.localUtil.CToN( cgiGet( edtId_Lee_Internalname), ".", ","));
               AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
            }
            A2578CodEmp_Lee = cgiGet( edtCodEmp_Lee_Internalname);
            AssignAttri("", false, "A2578CodEmp_Lee", A2578CodEmp_Lee);
            A2579NomEmp_Lee = cgiGet( edtNomEmp_Lee_Internalname);
            AssignAttri("", false, "A2579NomEmp_Lee", A2579NomEmp_Lee);
            A2580ApeEmp_Lee = cgiGet( edtApeEmp_Lee_Internalname);
            AssignAttri("", false, "A2580ApeEmp_Lee", A2580ApeEmp_Lee);
            A2581Marca_Lee = cgiGet( edtMarca_Lee_Internalname);
            AssignAttri("", false, "A2581Marca_Lee", A2581Marca_Lee);
            A2582Fec_Lee = cgiGet( edtFec_Lee_Internalname);
            AssignAttri("", false, "A2582Fec_Lee", A2582Fec_Lee);
            A2583Hora_Lee = cgiGet( edtHora_Lee_Internalname);
            AssignAttri("", false, "A2583Hora_Lee", A2583Hora_Lee);
            if ( ( ( context.localUtil.CToN( cgiGet( edtanio_Lee_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtanio_Lee_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ANIO_LEE");
               AnyError = 1;
               GX_FocusControl = edtanio_Lee_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2584anio_Lee = 0;
               AssignAttri("", false, "A2584anio_Lee", StringUtil.LTrimStr( (decimal)(A2584anio_Lee), 4, 0));
            }
            else
            {
               A2584anio_Lee = (short)(context.localUtil.CToN( cgiGet( edtanio_Lee_Internalname), ".", ","));
               AssignAttri("", false, "A2584anio_Lee", StringUtil.LTrimStr( (decimal)(A2584anio_Lee), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMes_Lee_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMes_Lee_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MES_LEE");
               AnyError = 1;
               GX_FocusControl = edtMes_Lee_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2585Mes_Lee = 0;
               AssignAttri("", false, "A2585Mes_Lee", StringUtil.LTrimStr( (decimal)(A2585Mes_Lee), 2, 0));
            }
            else
            {
               A2585Mes_Lee = (short)(context.localUtil.CToN( cgiGet( edtMes_Lee_Internalname), ".", ","));
               AssignAttri("", false, "A2585Mes_Lee", StringUtil.LTrimStr( (decimal)(A2585Mes_Lee), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDia_Lee_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDia_Lee_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DIA_LEE");
               AnyError = 1;
               GX_FocusControl = edtDia_Lee_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2586Dia_Lee = 0;
               AssignAttri("", false, "A2586Dia_Lee", StringUtil.LTrimStr( (decimal)(A2586Dia_Lee), 2, 0));
            }
            else
            {
               A2586Dia_Lee = (short)(context.localUtil.CToN( cgiGet( edtDia_Lee_Internalname), ".", ","));
               AssignAttri("", false, "A2586Dia_Lee", StringUtil.LTrimStr( (decimal)(A2586Dia_Lee), 2, 0));
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
               A2577Id_Lee = (long)(NumberUtil.Val( GetPar( "Id_Lee"), "."));
               AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
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
               InitAll7Y221( ) ;
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
         DisableAttributes7Y221( ) ;
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

      protected void ResetCaption7Y0( )
      {
      }

      protected void ZM7Y221( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2578CodEmp_Lee = T007Y3_A2578CodEmp_Lee[0];
               Z2579NomEmp_Lee = T007Y3_A2579NomEmp_Lee[0];
               Z2580ApeEmp_Lee = T007Y3_A2580ApeEmp_Lee[0];
               Z2581Marca_Lee = T007Y3_A2581Marca_Lee[0];
               Z2582Fec_Lee = T007Y3_A2582Fec_Lee[0];
               Z2583Hora_Lee = T007Y3_A2583Hora_Lee[0];
               Z2584anio_Lee = T007Y3_A2584anio_Lee[0];
               Z2585Mes_Lee = T007Y3_A2585Mes_Lee[0];
               Z2586Dia_Lee = T007Y3_A2586Dia_Lee[0];
            }
            else
            {
               Z2578CodEmp_Lee = A2578CodEmp_Lee;
               Z2579NomEmp_Lee = A2579NomEmp_Lee;
               Z2580ApeEmp_Lee = A2580ApeEmp_Lee;
               Z2581Marca_Lee = A2581Marca_Lee;
               Z2582Fec_Lee = A2582Fec_Lee;
               Z2583Hora_Lee = A2583Hora_Lee;
               Z2584anio_Lee = A2584anio_Lee;
               Z2585Mes_Lee = A2585Mes_Lee;
               Z2586Dia_Lee = A2586Dia_Lee;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2577Id_Lee = A2577Id_Lee;
            Z2578CodEmp_Lee = A2578CodEmp_Lee;
            Z2579NomEmp_Lee = A2579NomEmp_Lee;
            Z2580ApeEmp_Lee = A2580ApeEmp_Lee;
            Z2581Marca_Lee = A2581Marca_Lee;
            Z2582Fec_Lee = A2582Fec_Lee;
            Z2583Hora_Lee = A2583Hora_Lee;
            Z2584anio_Lee = A2584anio_Lee;
            Z2585Mes_Lee = A2585Mes_Lee;
            Z2586Dia_Lee = A2586Dia_Lee;
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

      protected void Load7Y221( )
      {
         /* Using cursor T007Y4 */
         pr_default.execute(2, new Object[] {A2577Id_Lee});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound221 = 1;
            A2578CodEmp_Lee = T007Y4_A2578CodEmp_Lee[0];
            AssignAttri("", false, "A2578CodEmp_Lee", A2578CodEmp_Lee);
            A2579NomEmp_Lee = T007Y4_A2579NomEmp_Lee[0];
            AssignAttri("", false, "A2579NomEmp_Lee", A2579NomEmp_Lee);
            A2580ApeEmp_Lee = T007Y4_A2580ApeEmp_Lee[0];
            AssignAttri("", false, "A2580ApeEmp_Lee", A2580ApeEmp_Lee);
            A2581Marca_Lee = T007Y4_A2581Marca_Lee[0];
            AssignAttri("", false, "A2581Marca_Lee", A2581Marca_Lee);
            A2582Fec_Lee = T007Y4_A2582Fec_Lee[0];
            AssignAttri("", false, "A2582Fec_Lee", A2582Fec_Lee);
            A2583Hora_Lee = T007Y4_A2583Hora_Lee[0];
            AssignAttri("", false, "A2583Hora_Lee", A2583Hora_Lee);
            A2584anio_Lee = T007Y4_A2584anio_Lee[0];
            AssignAttri("", false, "A2584anio_Lee", StringUtil.LTrimStr( (decimal)(A2584anio_Lee), 4, 0));
            A2585Mes_Lee = T007Y4_A2585Mes_Lee[0];
            AssignAttri("", false, "A2585Mes_Lee", StringUtil.LTrimStr( (decimal)(A2585Mes_Lee), 2, 0));
            A2586Dia_Lee = T007Y4_A2586Dia_Lee[0];
            AssignAttri("", false, "A2586Dia_Lee", StringUtil.LTrimStr( (decimal)(A2586Dia_Lee), 2, 0));
            ZM7Y221( -1) ;
         }
         pr_default.close(2);
         OnLoadActions7Y221( ) ;
      }

      protected void OnLoadActions7Y221( )
      {
      }

      protected void CheckExtendedTable7Y221( )
      {
         nIsDirty_221 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors7Y221( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7Y221( )
      {
         /* Using cursor T007Y5 */
         pr_default.execute(3, new Object[] {A2577Id_Lee});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound221 = 1;
         }
         else
         {
            RcdFound221 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007Y3 */
         pr_default.execute(1, new Object[] {A2577Id_Lee});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7Y221( 1) ;
            RcdFound221 = 1;
            A2577Id_Lee = T007Y3_A2577Id_Lee[0];
            AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
            A2578CodEmp_Lee = T007Y3_A2578CodEmp_Lee[0];
            AssignAttri("", false, "A2578CodEmp_Lee", A2578CodEmp_Lee);
            A2579NomEmp_Lee = T007Y3_A2579NomEmp_Lee[0];
            AssignAttri("", false, "A2579NomEmp_Lee", A2579NomEmp_Lee);
            A2580ApeEmp_Lee = T007Y3_A2580ApeEmp_Lee[0];
            AssignAttri("", false, "A2580ApeEmp_Lee", A2580ApeEmp_Lee);
            A2581Marca_Lee = T007Y3_A2581Marca_Lee[0];
            AssignAttri("", false, "A2581Marca_Lee", A2581Marca_Lee);
            A2582Fec_Lee = T007Y3_A2582Fec_Lee[0];
            AssignAttri("", false, "A2582Fec_Lee", A2582Fec_Lee);
            A2583Hora_Lee = T007Y3_A2583Hora_Lee[0];
            AssignAttri("", false, "A2583Hora_Lee", A2583Hora_Lee);
            A2584anio_Lee = T007Y3_A2584anio_Lee[0];
            AssignAttri("", false, "A2584anio_Lee", StringUtil.LTrimStr( (decimal)(A2584anio_Lee), 4, 0));
            A2585Mes_Lee = T007Y3_A2585Mes_Lee[0];
            AssignAttri("", false, "A2585Mes_Lee", StringUtil.LTrimStr( (decimal)(A2585Mes_Lee), 2, 0));
            A2586Dia_Lee = T007Y3_A2586Dia_Lee[0];
            AssignAttri("", false, "A2586Dia_Lee", StringUtil.LTrimStr( (decimal)(A2586Dia_Lee), 2, 0));
            Z2577Id_Lee = A2577Id_Lee;
            sMode221 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7Y221( ) ;
            if ( AnyError == 1 )
            {
               RcdFound221 = 0;
               InitializeNonKey7Y221( ) ;
            }
            Gx_mode = sMode221;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound221 = 0;
            InitializeNonKey7Y221( ) ;
            sMode221 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode221;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7Y221( ) ;
         if ( RcdFound221 == 0 )
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
         RcdFound221 = 0;
         /* Using cursor T007Y6 */
         pr_default.execute(4, new Object[] {A2577Id_Lee});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T007Y6_A2577Id_Lee[0] < A2577Id_Lee ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T007Y6_A2577Id_Lee[0] > A2577Id_Lee ) ) )
            {
               A2577Id_Lee = T007Y6_A2577Id_Lee[0];
               AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
               RcdFound221 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound221 = 0;
         /* Using cursor T007Y7 */
         pr_default.execute(5, new Object[] {A2577Id_Lee});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T007Y7_A2577Id_Lee[0] > A2577Id_Lee ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T007Y7_A2577Id_Lee[0] < A2577Id_Lee ) ) )
            {
               A2577Id_Lee = T007Y7_A2577Id_Lee[0];
               AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
               RcdFound221 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7Y221( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtId_Lee_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7Y221( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound221 == 1 )
            {
               if ( A2577Id_Lee != Z2577Id_Lee )
               {
                  A2577Id_Lee = Z2577Id_Lee;
                  AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ID_LEE");
                  AnyError = 1;
                  GX_FocusControl = edtId_Lee_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtId_Lee_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7Y221( ) ;
                  GX_FocusControl = edtId_Lee_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2577Id_Lee != Z2577Id_Lee )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtId_Lee_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7Y221( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ID_LEE");
                     AnyError = 1;
                     GX_FocusControl = edtId_Lee_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtId_Lee_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7Y221( ) ;
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
         if ( A2577Id_Lee != Z2577Id_Lee )
         {
            A2577Id_Lee = Z2577Id_Lee;
            AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ID_LEE");
            AnyError = 1;
            GX_FocusControl = edtId_Lee_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtId_Lee_Internalname;
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
         if ( RcdFound221 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ID_LEE");
            AnyError = 1;
            GX_FocusControl = edtId_Lee_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCodEmp_Lee_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7Y221( ) ;
         if ( RcdFound221 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCodEmp_Lee_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7Y221( ) ;
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
         if ( RcdFound221 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCodEmp_Lee_Internalname;
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
         if ( RcdFound221 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCodEmp_Lee_Internalname;
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
         ScanStart7Y221( ) ;
         if ( RcdFound221 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound221 != 0 )
            {
               ScanNext7Y221( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCodEmp_Lee_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7Y221( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7Y221( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007Y2 */
            pr_default.execute(0, new Object[] {A2577Id_Lee});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj_Lecturas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2578CodEmp_Lee, T007Y2_A2578CodEmp_Lee[0]) != 0 ) || ( StringUtil.StrCmp(Z2579NomEmp_Lee, T007Y2_A2579NomEmp_Lee[0]) != 0 ) || ( StringUtil.StrCmp(Z2580ApeEmp_Lee, T007Y2_A2580ApeEmp_Lee[0]) != 0 ) || ( StringUtil.StrCmp(Z2581Marca_Lee, T007Y2_A2581Marca_Lee[0]) != 0 ) || ( StringUtil.StrCmp(Z2582Fec_Lee, T007Y2_A2582Fec_Lee[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2583Hora_Lee, T007Y2_A2583Hora_Lee[0]) != 0 ) || ( Z2584anio_Lee != T007Y2_A2584anio_Lee[0] ) || ( Z2585Mes_Lee != T007Y2_A2585Mes_Lee[0] ) || ( Z2586Dia_Lee != T007Y2_A2586Dia_Lee[0] ) )
            {
               if ( StringUtil.StrCmp(Z2578CodEmp_Lee, T007Y2_A2578CodEmp_Lee[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"CodEmp_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2578CodEmp_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2578CodEmp_Lee[0]);
               }
               if ( StringUtil.StrCmp(Z2579NomEmp_Lee, T007Y2_A2579NomEmp_Lee[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"NomEmp_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2579NomEmp_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2579NomEmp_Lee[0]);
               }
               if ( StringUtil.StrCmp(Z2580ApeEmp_Lee, T007Y2_A2580ApeEmp_Lee[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"ApeEmp_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2580ApeEmp_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2580ApeEmp_Lee[0]);
               }
               if ( StringUtil.StrCmp(Z2581Marca_Lee, T007Y2_A2581Marca_Lee[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"Marca_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2581Marca_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2581Marca_Lee[0]);
               }
               if ( StringUtil.StrCmp(Z2582Fec_Lee, T007Y2_A2582Fec_Lee[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"Fec_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2582Fec_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2582Fec_Lee[0]);
               }
               if ( StringUtil.StrCmp(Z2583Hora_Lee, T007Y2_A2583Hora_Lee[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"Hora_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2583Hora_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2583Hora_Lee[0]);
               }
               if ( Z2584anio_Lee != T007Y2_A2584anio_Lee[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"anio_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2584anio_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2584anio_Lee[0]);
               }
               if ( Z2585Mes_Lee != T007Y2_A2585Mes_Lee[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"Mes_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2585Mes_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2585Mes_Lee[0]);
               }
               if ( Z2586Dia_Lee != T007Y2_A2586Dia_Lee[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_lecturas:[seudo value changed for attri]"+"Dia_Lee");
                  GXUtil.WriteLogRaw("Old: ",Z2586Dia_Lee);
                  GXUtil.WriteLogRaw("Current: ",T007Y2_A2586Dia_Lee[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reloj_Lecturas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7Y221( )
      {
         BeforeValidate7Y221( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7Y221( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7Y221( 0) ;
            CheckOptimisticConcurrency7Y221( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7Y221( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7Y221( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007Y8 */
                     pr_default.execute(6, new Object[] {A2577Id_Lee, A2578CodEmp_Lee, A2579NomEmp_Lee, A2580ApeEmp_Lee, A2581Marca_Lee, A2582Fec_Lee, A2583Hora_Lee, A2584anio_Lee, A2585Mes_Lee, A2586Dia_Lee});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj_Lecturas");
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
                           ResetCaption7Y0( ) ;
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
               Load7Y221( ) ;
            }
            EndLevel7Y221( ) ;
         }
         CloseExtendedTableCursors7Y221( ) ;
      }

      protected void Update7Y221( )
      {
         BeforeValidate7Y221( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7Y221( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7Y221( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7Y221( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7Y221( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007Y9 */
                     pr_default.execute(7, new Object[] {A2578CodEmp_Lee, A2579NomEmp_Lee, A2580ApeEmp_Lee, A2581Marca_Lee, A2582Fec_Lee, A2583Hora_Lee, A2584anio_Lee, A2585Mes_Lee, A2586Dia_Lee, A2577Id_Lee});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj_Lecturas");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj_Lecturas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7Y221( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7Y0( ) ;
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
            EndLevel7Y221( ) ;
         }
         CloseExtendedTableCursors7Y221( ) ;
      }

      protected void DeferredUpdate7Y221( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7Y221( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7Y221( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7Y221( ) ;
            AfterConfirm7Y221( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7Y221( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007Y10 */
                  pr_default.execute(8, new Object[] {A2577Id_Lee});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Reloj_Lecturas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound221 == 0 )
                        {
                           InitAll7Y221( ) ;
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
                        ResetCaption7Y0( ) ;
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
         sMode221 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7Y221( ) ;
         Gx_mode = sMode221;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7Y221( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7Y221( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7Y221( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("reloj_interface.reloj_lecturas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("reloj_interface.reloj_lecturas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7Y221( )
      {
         /* Using cursor T007Y11 */
         pr_default.execute(9);
         RcdFound221 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound221 = 1;
            A2577Id_Lee = T007Y11_A2577Id_Lee[0];
            AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7Y221( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound221 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound221 = 1;
            A2577Id_Lee = T007Y11_A2577Id_Lee[0];
            AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
         }
      }

      protected void ScanEnd7Y221( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm7Y221( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7Y221( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7Y221( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7Y221( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7Y221( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7Y221( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7Y221( )
      {
         edtId_Lee_Enabled = 0;
         AssignProp("", false, edtId_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtId_Lee_Enabled), 5, 0), true);
         edtCodEmp_Lee_Enabled = 0;
         AssignProp("", false, edtCodEmp_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCodEmp_Lee_Enabled), 5, 0), true);
         edtNomEmp_Lee_Enabled = 0;
         AssignProp("", false, edtNomEmp_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomEmp_Lee_Enabled), 5, 0), true);
         edtApeEmp_Lee_Enabled = 0;
         AssignProp("", false, edtApeEmp_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtApeEmp_Lee_Enabled), 5, 0), true);
         edtMarca_Lee_Enabled = 0;
         AssignProp("", false, edtMarca_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMarca_Lee_Enabled), 5, 0), true);
         edtFec_Lee_Enabled = 0;
         AssignProp("", false, edtFec_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFec_Lee_Enabled), 5, 0), true);
         edtHora_Lee_Enabled = 0;
         AssignProp("", false, edtHora_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHora_Lee_Enabled), 5, 0), true);
         edtanio_Lee_Enabled = 0;
         AssignProp("", false, edtanio_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtanio_Lee_Enabled), 5, 0), true);
         edtMes_Lee_Enabled = 0;
         AssignProp("", false, edtMes_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMes_Lee_Enabled), 5, 0), true);
         edtDia_Lee_Enabled = 0;
         AssignProp("", false, edtDia_Lee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDia_Lee_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7Y221( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7Y0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271966", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.reloj_lecturas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2577Id_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2577Id_Lee), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2578CodEmp_Lee", Z2578CodEmp_Lee);
         GxWebStd.gx_hidden_field( context, "Z2579NomEmp_Lee", Z2579NomEmp_Lee);
         GxWebStd.gx_hidden_field( context, "Z2580ApeEmp_Lee", Z2580ApeEmp_Lee);
         GxWebStd.gx_hidden_field( context, "Z2581Marca_Lee", Z2581Marca_Lee);
         GxWebStd.gx_hidden_field( context, "Z2582Fec_Lee", Z2582Fec_Lee);
         GxWebStd.gx_hidden_field( context, "Z2583Hora_Lee", Z2583Hora_Lee);
         GxWebStd.gx_hidden_field( context, "Z2584anio_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2584anio_Lee), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2585Mes_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2585Mes_Lee), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2586Dia_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2586Dia_Lee), 2, 0, ".", "")));
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
         return formatLink("reloj_interface.reloj_lecturas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Reloj_Lecturas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reloj_Lecturas" ;
      }

      protected void InitializeNonKey7Y221( )
      {
         A2578CodEmp_Lee = "";
         AssignAttri("", false, "A2578CodEmp_Lee", A2578CodEmp_Lee);
         A2579NomEmp_Lee = "";
         AssignAttri("", false, "A2579NomEmp_Lee", A2579NomEmp_Lee);
         A2580ApeEmp_Lee = "";
         AssignAttri("", false, "A2580ApeEmp_Lee", A2580ApeEmp_Lee);
         A2581Marca_Lee = "";
         AssignAttri("", false, "A2581Marca_Lee", A2581Marca_Lee);
         A2582Fec_Lee = "";
         AssignAttri("", false, "A2582Fec_Lee", A2582Fec_Lee);
         A2583Hora_Lee = "";
         AssignAttri("", false, "A2583Hora_Lee", A2583Hora_Lee);
         A2584anio_Lee = 0;
         AssignAttri("", false, "A2584anio_Lee", StringUtil.LTrimStr( (decimal)(A2584anio_Lee), 4, 0));
         A2585Mes_Lee = 0;
         AssignAttri("", false, "A2585Mes_Lee", StringUtil.LTrimStr( (decimal)(A2585Mes_Lee), 2, 0));
         A2586Dia_Lee = 0;
         AssignAttri("", false, "A2586Dia_Lee", StringUtil.LTrimStr( (decimal)(A2586Dia_Lee), 2, 0));
         Z2578CodEmp_Lee = "";
         Z2579NomEmp_Lee = "";
         Z2580ApeEmp_Lee = "";
         Z2581Marca_Lee = "";
         Z2582Fec_Lee = "";
         Z2583Hora_Lee = "";
         Z2584anio_Lee = 0;
         Z2585Mes_Lee = 0;
         Z2586Dia_Lee = 0;
      }

      protected void InitAll7Y221( )
      {
         A2577Id_Lee = 0;
         AssignAttri("", false, "A2577Id_Lee", StringUtil.LTrimStr( (decimal)(A2577Id_Lee), 12, 0));
         InitializeNonKey7Y221( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271974", true, true);
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
         context.AddJavascriptSource("reloj_interface/reloj_lecturas.js", "?202281810271975", false, true);
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
         edtId_Lee_Internalname = "ID_LEE";
         edtCodEmp_Lee_Internalname = "CODEMP_LEE";
         edtNomEmp_Lee_Internalname = "NOMEMP_LEE";
         edtApeEmp_Lee_Internalname = "APEEMP_LEE";
         edtMarca_Lee_Internalname = "MARCA_LEE";
         edtFec_Lee_Internalname = "FEC_LEE";
         edtHora_Lee_Internalname = "HORA_LEE";
         edtanio_Lee_Internalname = "ANIO_LEE";
         edtMes_Lee_Internalname = "MES_LEE";
         edtDia_Lee_Internalname = "DIA_LEE";
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
         Form.Caption = "Reloj_Lecturas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDia_Lee_Jsonclick = "";
         edtDia_Lee_Enabled = 1;
         edtMes_Lee_Jsonclick = "";
         edtMes_Lee_Enabled = 1;
         edtanio_Lee_Jsonclick = "";
         edtanio_Lee_Enabled = 1;
         edtHora_Lee_Jsonclick = "";
         edtHora_Lee_Enabled = 1;
         edtFec_Lee_Jsonclick = "";
         edtFec_Lee_Enabled = 1;
         edtMarca_Lee_Jsonclick = "";
         edtMarca_Lee_Enabled = 1;
         edtApeEmp_Lee_Jsonclick = "";
         edtApeEmp_Lee_Enabled = 1;
         edtNomEmp_Lee_Jsonclick = "";
         edtNomEmp_Lee_Enabled = 1;
         edtCodEmp_Lee_Jsonclick = "";
         edtCodEmp_Lee_Enabled = 1;
         edtId_Lee_Jsonclick = "";
         edtId_Lee_Enabled = 1;
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
         GX_FocusControl = edtCodEmp_Lee_Internalname;
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

      public void Valid_Id_lee( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2578CodEmp_Lee", A2578CodEmp_Lee);
         AssignAttri("", false, "A2579NomEmp_Lee", A2579NomEmp_Lee);
         AssignAttri("", false, "A2580ApeEmp_Lee", A2580ApeEmp_Lee);
         AssignAttri("", false, "A2581Marca_Lee", A2581Marca_Lee);
         AssignAttri("", false, "A2582Fec_Lee", A2582Fec_Lee);
         AssignAttri("", false, "A2583Hora_Lee", A2583Hora_Lee);
         AssignAttri("", false, "A2584anio_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2584anio_Lee), 4, 0, ".", "")));
         AssignAttri("", false, "A2585Mes_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2585Mes_Lee), 2, 0, ".", "")));
         AssignAttri("", false, "A2586Dia_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2586Dia_Lee), 2, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2577Id_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2577Id_Lee), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2578CodEmp_Lee", Z2578CodEmp_Lee);
         GxWebStd.gx_hidden_field( context, "Z2579NomEmp_Lee", Z2579NomEmp_Lee);
         GxWebStd.gx_hidden_field( context, "Z2580ApeEmp_Lee", Z2580ApeEmp_Lee);
         GxWebStd.gx_hidden_field( context, "Z2581Marca_Lee", Z2581Marca_Lee);
         GxWebStd.gx_hidden_field( context, "Z2582Fec_Lee", Z2582Fec_Lee);
         GxWebStd.gx_hidden_field( context, "Z2583Hora_Lee", Z2583Hora_Lee);
         GxWebStd.gx_hidden_field( context, "Z2584anio_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2584anio_Lee), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2585Mes_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2585Mes_Lee), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2586Dia_Lee", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2586Dia_Lee), 2, 0, ".", "")));
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
         setEventMetadata("VALID_ID_LEE","{handler:'Valid_Id_lee',iparms:[{av:'A2577Id_Lee',fld:'ID_LEE',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ID_LEE",",oparms:[{av:'A2578CodEmp_Lee',fld:'CODEMP_LEE',pic:''},{av:'A2579NomEmp_Lee',fld:'NOMEMP_LEE',pic:''},{av:'A2580ApeEmp_Lee',fld:'APEEMP_LEE',pic:''},{av:'A2581Marca_Lee',fld:'MARCA_LEE',pic:''},{av:'A2582Fec_Lee',fld:'FEC_LEE',pic:''},{av:'A2583Hora_Lee',fld:'HORA_LEE',pic:''},{av:'A2584anio_Lee',fld:'ANIO_LEE',pic:'ZZZ9'},{av:'A2585Mes_Lee',fld:'MES_LEE',pic:'Z9'},{av:'A2586Dia_Lee',fld:'DIA_LEE',pic:'Z9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2577Id_Lee'},{av:'Z2578CodEmp_Lee'},{av:'Z2579NomEmp_Lee'},{av:'Z2580ApeEmp_Lee'},{av:'Z2581Marca_Lee'},{av:'Z2582Fec_Lee'},{av:'Z2583Hora_Lee'},{av:'Z2584anio_Lee'},{av:'Z2585Mes_Lee'},{av:'Z2586Dia_Lee'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z2578CodEmp_Lee = "";
         Z2579NomEmp_Lee = "";
         Z2580ApeEmp_Lee = "";
         Z2581Marca_Lee = "";
         Z2582Fec_Lee = "";
         Z2583Hora_Lee = "";
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
         A2578CodEmp_Lee = "";
         A2579NomEmp_Lee = "";
         A2580ApeEmp_Lee = "";
         A2581Marca_Lee = "";
         A2582Fec_Lee = "";
         A2583Hora_Lee = "";
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
         T007Y4_A2577Id_Lee = new long[1] ;
         T007Y4_A2578CodEmp_Lee = new string[] {""} ;
         T007Y4_A2579NomEmp_Lee = new string[] {""} ;
         T007Y4_A2580ApeEmp_Lee = new string[] {""} ;
         T007Y4_A2581Marca_Lee = new string[] {""} ;
         T007Y4_A2582Fec_Lee = new string[] {""} ;
         T007Y4_A2583Hora_Lee = new string[] {""} ;
         T007Y4_A2584anio_Lee = new short[1] ;
         T007Y4_A2585Mes_Lee = new short[1] ;
         T007Y4_A2586Dia_Lee = new short[1] ;
         T007Y5_A2577Id_Lee = new long[1] ;
         T007Y3_A2577Id_Lee = new long[1] ;
         T007Y3_A2578CodEmp_Lee = new string[] {""} ;
         T007Y3_A2579NomEmp_Lee = new string[] {""} ;
         T007Y3_A2580ApeEmp_Lee = new string[] {""} ;
         T007Y3_A2581Marca_Lee = new string[] {""} ;
         T007Y3_A2582Fec_Lee = new string[] {""} ;
         T007Y3_A2583Hora_Lee = new string[] {""} ;
         T007Y3_A2584anio_Lee = new short[1] ;
         T007Y3_A2585Mes_Lee = new short[1] ;
         T007Y3_A2586Dia_Lee = new short[1] ;
         sMode221 = "";
         T007Y6_A2577Id_Lee = new long[1] ;
         T007Y7_A2577Id_Lee = new long[1] ;
         T007Y2_A2577Id_Lee = new long[1] ;
         T007Y2_A2578CodEmp_Lee = new string[] {""} ;
         T007Y2_A2579NomEmp_Lee = new string[] {""} ;
         T007Y2_A2580ApeEmp_Lee = new string[] {""} ;
         T007Y2_A2581Marca_Lee = new string[] {""} ;
         T007Y2_A2582Fec_Lee = new string[] {""} ;
         T007Y2_A2583Hora_Lee = new string[] {""} ;
         T007Y2_A2584anio_Lee = new short[1] ;
         T007Y2_A2585Mes_Lee = new short[1] ;
         T007Y2_A2586Dia_Lee = new short[1] ;
         T007Y11_A2577Id_Lee = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2578CodEmp_Lee = "";
         ZZ2579NomEmp_Lee = "";
         ZZ2580ApeEmp_Lee = "";
         ZZ2581Marca_Lee = "";
         ZZ2582Fec_Lee = "";
         ZZ2583Hora_Lee = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_lecturas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_lecturas__default(),
            new Object[][] {
                new Object[] {
               T007Y2_A2577Id_Lee, T007Y2_A2578CodEmp_Lee, T007Y2_A2579NomEmp_Lee, T007Y2_A2580ApeEmp_Lee, T007Y2_A2581Marca_Lee, T007Y2_A2582Fec_Lee, T007Y2_A2583Hora_Lee, T007Y2_A2584anio_Lee, T007Y2_A2585Mes_Lee, T007Y2_A2586Dia_Lee
               }
               , new Object[] {
               T007Y3_A2577Id_Lee, T007Y3_A2578CodEmp_Lee, T007Y3_A2579NomEmp_Lee, T007Y3_A2580ApeEmp_Lee, T007Y3_A2581Marca_Lee, T007Y3_A2582Fec_Lee, T007Y3_A2583Hora_Lee, T007Y3_A2584anio_Lee, T007Y3_A2585Mes_Lee, T007Y3_A2586Dia_Lee
               }
               , new Object[] {
               T007Y4_A2577Id_Lee, T007Y4_A2578CodEmp_Lee, T007Y4_A2579NomEmp_Lee, T007Y4_A2580ApeEmp_Lee, T007Y4_A2581Marca_Lee, T007Y4_A2582Fec_Lee, T007Y4_A2583Hora_Lee, T007Y4_A2584anio_Lee, T007Y4_A2585Mes_Lee, T007Y4_A2586Dia_Lee
               }
               , new Object[] {
               T007Y5_A2577Id_Lee
               }
               , new Object[] {
               T007Y6_A2577Id_Lee
               }
               , new Object[] {
               T007Y7_A2577Id_Lee
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007Y11_A2577Id_Lee
               }
            }
         );
      }

      private short Z2584anio_Lee ;
      private short Z2585Mes_Lee ;
      private short Z2586Dia_Lee ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2584anio_Lee ;
      private short A2585Mes_Lee ;
      private short A2586Dia_Lee ;
      private short GX_JID ;
      private short RcdFound221 ;
      private short nIsDirty_221 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2584anio_Lee ;
      private short ZZ2585Mes_Lee ;
      private short ZZ2586Dia_Lee ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtId_Lee_Enabled ;
      private int edtCodEmp_Lee_Enabled ;
      private int edtNomEmp_Lee_Enabled ;
      private int edtApeEmp_Lee_Enabled ;
      private int edtMarca_Lee_Enabled ;
      private int edtFec_Lee_Enabled ;
      private int edtHora_Lee_Enabled ;
      private int edtanio_Lee_Enabled ;
      private int edtMes_Lee_Enabled ;
      private int edtDia_Lee_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z2577Id_Lee ;
      private long A2577Id_Lee ;
      private long ZZ2577Id_Lee ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtId_Lee_Internalname ;
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
      private string edtId_Lee_Jsonclick ;
      private string edtCodEmp_Lee_Internalname ;
      private string edtCodEmp_Lee_Jsonclick ;
      private string edtNomEmp_Lee_Internalname ;
      private string edtNomEmp_Lee_Jsonclick ;
      private string edtApeEmp_Lee_Internalname ;
      private string edtApeEmp_Lee_Jsonclick ;
      private string edtMarca_Lee_Internalname ;
      private string edtMarca_Lee_Jsonclick ;
      private string edtFec_Lee_Internalname ;
      private string edtFec_Lee_Jsonclick ;
      private string edtHora_Lee_Internalname ;
      private string edtHora_Lee_Jsonclick ;
      private string edtanio_Lee_Internalname ;
      private string edtanio_Lee_Jsonclick ;
      private string edtMes_Lee_Internalname ;
      private string edtMes_Lee_Jsonclick ;
      private string edtDia_Lee_Internalname ;
      private string edtDia_Lee_Jsonclick ;
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
      private string sMode221 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2578CodEmp_Lee ;
      private string Z2579NomEmp_Lee ;
      private string Z2580ApeEmp_Lee ;
      private string Z2581Marca_Lee ;
      private string Z2582Fec_Lee ;
      private string Z2583Hora_Lee ;
      private string A2578CodEmp_Lee ;
      private string A2579NomEmp_Lee ;
      private string A2580ApeEmp_Lee ;
      private string A2581Marca_Lee ;
      private string A2582Fec_Lee ;
      private string A2583Hora_Lee ;
      private string ZZ2578CodEmp_Lee ;
      private string ZZ2579NomEmp_Lee ;
      private string ZZ2580ApeEmp_Lee ;
      private string ZZ2581Marca_Lee ;
      private string ZZ2582Fec_Lee ;
      private string ZZ2583Hora_Lee ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T007Y4_A2577Id_Lee ;
      private string[] T007Y4_A2578CodEmp_Lee ;
      private string[] T007Y4_A2579NomEmp_Lee ;
      private string[] T007Y4_A2580ApeEmp_Lee ;
      private string[] T007Y4_A2581Marca_Lee ;
      private string[] T007Y4_A2582Fec_Lee ;
      private string[] T007Y4_A2583Hora_Lee ;
      private short[] T007Y4_A2584anio_Lee ;
      private short[] T007Y4_A2585Mes_Lee ;
      private short[] T007Y4_A2586Dia_Lee ;
      private long[] T007Y5_A2577Id_Lee ;
      private long[] T007Y3_A2577Id_Lee ;
      private string[] T007Y3_A2578CodEmp_Lee ;
      private string[] T007Y3_A2579NomEmp_Lee ;
      private string[] T007Y3_A2580ApeEmp_Lee ;
      private string[] T007Y3_A2581Marca_Lee ;
      private string[] T007Y3_A2582Fec_Lee ;
      private string[] T007Y3_A2583Hora_Lee ;
      private short[] T007Y3_A2584anio_Lee ;
      private short[] T007Y3_A2585Mes_Lee ;
      private short[] T007Y3_A2586Dia_Lee ;
      private long[] T007Y6_A2577Id_Lee ;
      private long[] T007Y7_A2577Id_Lee ;
      private long[] T007Y2_A2577Id_Lee ;
      private string[] T007Y2_A2578CodEmp_Lee ;
      private string[] T007Y2_A2579NomEmp_Lee ;
      private string[] T007Y2_A2580ApeEmp_Lee ;
      private string[] T007Y2_A2581Marca_Lee ;
      private string[] T007Y2_A2582Fec_Lee ;
      private string[] T007Y2_A2583Hora_Lee ;
      private short[] T007Y2_A2584anio_Lee ;
      private short[] T007Y2_A2585Mes_Lee ;
      private short[] T007Y2_A2586Dia_Lee ;
      private long[] T007Y11_A2577Id_Lee ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class reloj_lecturas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class reloj_lecturas__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007Y4;
        prmT007Y4 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y5;
        prmT007Y5 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y3;
        prmT007Y3 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y6;
        prmT007Y6 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y7;
        prmT007Y7 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y2;
        prmT007Y2 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y8;
        prmT007Y8 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0) ,
        new ParDef("@CodEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@NomEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@ApeEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Marca_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Fec_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Hora_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@anio_Lee",GXType.Int16,4,0) ,
        new ParDef("@Mes_Lee",GXType.Int16,2,0) ,
        new ParDef("@Dia_Lee",GXType.Int16,2,0)
        };
        Object[] prmT007Y9;
        prmT007Y9 = new Object[] {
        new ParDef("@CodEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@NomEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@ApeEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Marca_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Fec_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Hora_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@anio_Lee",GXType.Int16,4,0) ,
        new ParDef("@Mes_Lee",GXType.Int16,2,0) ,
        new ParDef("@Dia_Lee",GXType.Int16,2,0) ,
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y10;
        prmT007Y10 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0)
        };
        Object[] prmT007Y11;
        prmT007Y11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007Y2", "SELECT [Id_Lee], [CodEmp_Lee], [NomEmp_Lee], [ApeEmp_Lee], [Marca_Lee], [Fec_Lee], [Hora_Lee], [anio_Lee], [Mes_Lee], [Dia_Lee] FROM [Reloj_Lecturas] WITH (UPDLOCK) WHERE [Id_Lee] = @Id_Lee ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Y3", "SELECT [Id_Lee], [CodEmp_Lee], [NomEmp_Lee], [ApeEmp_Lee], [Marca_Lee], [Fec_Lee], [Hora_Lee], [anio_Lee], [Mes_Lee], [Dia_Lee] FROM [Reloj_Lecturas] WHERE [Id_Lee] = @Id_Lee ",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Y4", "SELECT TM1.[Id_Lee], TM1.[CodEmp_Lee], TM1.[NomEmp_Lee], TM1.[ApeEmp_Lee], TM1.[Marca_Lee], TM1.[Fec_Lee], TM1.[Hora_Lee], TM1.[anio_Lee], TM1.[Mes_Lee], TM1.[Dia_Lee] FROM [Reloj_Lecturas] TM1 WHERE TM1.[Id_Lee] = @Id_Lee ORDER BY TM1.[Id_Lee]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Y5", "SELECT [Id_Lee] FROM [Reloj_Lecturas] WHERE [Id_Lee] = @Id_Lee  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007Y6", "SELECT TOP 1 [Id_Lee] FROM [Reloj_Lecturas] WHERE ( [Id_Lee] > @Id_Lee) ORDER BY [Id_Lee]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007Y7", "SELECT TOP 1 [Id_Lee] FROM [Reloj_Lecturas] WHERE ( [Id_Lee] < @Id_Lee) ORDER BY [Id_Lee] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007Y8", "INSERT INTO [Reloj_Lecturas]([Id_Lee], [CodEmp_Lee], [NomEmp_Lee], [ApeEmp_Lee], [Marca_Lee], [Fec_Lee], [Hora_Lee], [anio_Lee], [Mes_Lee], [Dia_Lee]) VALUES(@Id_Lee, @CodEmp_Lee, @NomEmp_Lee, @ApeEmp_Lee, @Marca_Lee, @Fec_Lee, @Hora_Lee, @anio_Lee, @Mes_Lee, @Dia_Lee)", GxErrorMask.GX_NOMASK,prmT007Y8)
           ,new CursorDef("T007Y9", "UPDATE [Reloj_Lecturas] SET [CodEmp_Lee]=@CodEmp_Lee, [NomEmp_Lee]=@NomEmp_Lee, [ApeEmp_Lee]=@ApeEmp_Lee, [Marca_Lee]=@Marca_Lee, [Fec_Lee]=@Fec_Lee, [Hora_Lee]=@Hora_Lee, [anio_Lee]=@anio_Lee, [Mes_Lee]=@Mes_Lee, [Dia_Lee]=@Dia_Lee  WHERE [Id_Lee] = @Id_Lee", GxErrorMask.GX_NOMASK,prmT007Y9)
           ,new CursorDef("T007Y10", "DELETE FROM [Reloj_Lecturas]  WHERE [Id_Lee] = @Id_Lee", GxErrorMask.GX_NOMASK,prmT007Y10)
           ,new CursorDef("T007Y11", "SELECT [Id_Lee] FROM [Reloj_Lecturas] ORDER BY [Id_Lee]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007Y11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
