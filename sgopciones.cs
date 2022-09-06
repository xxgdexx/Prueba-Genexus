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
   public class sgopciones : GXDataArea
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
            Form.Meta.addItem("description", "SGOPCIONES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOpcId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgopciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgopciones( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGOPCIONES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGOPCIONES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGOPCIONES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A347OpcId), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcId_Enabled!=0) ? context.localUtil.Format( (decimal)(A347OpcId), "9") : context.localUtil.Format( (decimal)(A347OpcId), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcId_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcStk_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcStk_Internalname, "Verifica Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1419OpcStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1419OpcStk), "9") : context.localUtil.Format( (decimal)(A1419OpcStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcIVA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcIVA_Internalname, "% I.G.V.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A1402OpcIVA, 10, 2, ".", "")), StringUtil.LTrim( ((edtOpcIVA_Enabled!=0) ? context.localUtil.Format( A1402OpcIVA, "ZZZZZZ9.99") : context.localUtil.Format( A1402OpcIVA, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcIVA_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEmp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEmp_Internalname, "Nombre Empresa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEmp_Internalname, StringUtil.RTrim( A1397OpcEmp), StringUtil.RTrim( context.localUtil.Format( A1397OpcEmp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEmp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEmp_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcAutOcom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcAutOcom_Internalname, "Manejo de Autorización O.Compra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcAutOcom_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1390OpcAutOcom), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcAutOcom_Enabled!=0) ? context.localUtil.Format( (decimal)(A1390OpcAutOcom), "9") : context.localUtil.Format( (decimal)(A1390OpcAutOcom), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcAutOcom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcAutOcom_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcAutCompras_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcAutCompras_Internalname, "Manejo de Autorización de Compras", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcAutCompras_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1389OpcAutCompras), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcAutCompras_Enabled!=0) ? context.localUtil.Format( (decimal)(A1389OpcAutCompras), "9") : context.localUtil.Format( (decimal)(A1389OpcAutCompras), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcAutCompras_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcAutCompras_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedAut_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedAut_Internalname, "Todos los pedidos Autorización", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1406OpcPedAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A1406OpcPedAut), "9") : context.localUtil.Format( (decimal)(A1406OpcPedAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcVersion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcVersion_Internalname, "Versión", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcVersion_Internalname, StringUtil.RTrim( A1421OpcVersion), StringUtil.RTrim( context.localUtil.Format( A1421OpcVersion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcVersion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcVersion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcRetencion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcRetencion_Internalname, "% Retención", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcRetencion_Internalname, StringUtil.LTrim( StringUtil.NToC( A1417OpcRetencion, 10, 2, ".", "")), StringUtil.LTrim( ((edtOpcRetencion_Enabled!=0) ? context.localUtil.Format( A1417OpcRetencion, "ZZZZZZ9.99") : context.localUtil.Format( A1417OpcRetencion, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcRetencion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcRetencion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPercepcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPercepcion_Internalname, "% Percepción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPercepcion_Internalname, StringUtil.LTrim( StringUtil.NToC( A1415OpcPercepcion, 10, 2, ".", "")), StringUtil.LTrim( ((edtOpcPercepcion_Enabled!=0) ? context.localUtil.Format( A1415OpcPercepcion, "ZZZZZZ9.99") : context.localUtil.Format( A1415OpcPercepcion, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPercepcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPercepcion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPercepcionAgentes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPercepcionAgentes_Internalname, "% Percepción Agentes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPercepcionAgentes_Internalname, StringUtil.LTrim( StringUtil.NToC( A1416OpcPercepcionAgentes, 10, 2, ".", "")), StringUtil.LTrim( ((edtOpcPercepcionAgentes_Enabled!=0) ? context.localUtil.Format( A1416OpcPercepcionAgentes, "ZZZZZZ9.99") : context.localUtil.Format( A1416OpcPercepcionAgentes, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPercepcionAgentes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPercepcionAgentes_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedAutNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedAutNum_Internalname, "Numero de Autorizaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedAutNum_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1407OpcPedAutNum), 2, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedAutNum_Enabled!=0) ? context.localUtil.Format( (decimal)(A1407OpcPedAutNum), "Z9") : context.localUtil.Format( (decimal)(A1407OpcPedAutNum), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedAutNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedAutNum_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcListaPrecios_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcListaPrecios_Internalname, "Historico Lista de Precios", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcListaPrecios_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1405OpcListaPrecios), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcListaPrecios_Enabled!=0) ? context.localUtil.Format( (decimal)(A1405OpcListaPrecios), "9") : context.localUtil.Format( (decimal)(A1405OpcListaPrecios), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcListaPrecios_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcListaPrecios_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEntrada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEntrada_Internalname, "Estado Entrada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEntrada_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1399OpcEntrada), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcEntrada_Enabled!=0) ? context.localUtil.Format( (decimal)(A1399OpcEntrada), "9") : context.localUtil.Format( (decimal)(A1399OpcEntrada), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEntrada_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEntrada_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcStkComp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcStkComp_Internalname, "Stock Comprometido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcStkComp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1420OpcStkComp), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcStkComp_Enabled!=0) ? context.localUtil.Format( (decimal)(A1420OpcStkComp), "9") : context.localUtil.Format( (decimal)(A1420OpcStkComp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcStkComp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcStkComp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEMailHost_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEMailHost_Internalname, "Host", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEMailHost_Internalname, StringUtil.RTrim( A1392OpcEMailHost), StringUtil.RTrim( context.localUtil.Format( A1392OpcEMailHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEMailHost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEMailHost_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEMailSalida_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEMailSalida_Internalname, "Correo Saliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEMailSalida_Internalname, StringUtil.RTrim( A1395OpcEMailSalida), StringUtil.RTrim( context.localUtil.Format( A1395OpcEMailSalida, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEMailSalida_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEMailSalida_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEMailUsu_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEMailUsu_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEMailUsu_Internalname, StringUtil.RTrim( A1396OpcEMailUsu), StringUtil.RTrim( context.localUtil.Format( A1396OpcEMailUsu, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEMailUsu_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEMailUsu_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEMailPass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEMailPass_Internalname, "Password", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEMailPass_Internalname, StringUtil.RTrim( A1393OpcEMailPass), StringUtil.RTrim( context.localUtil.Format( A1393OpcEMailPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEMailPass_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEMailPass_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEmpAgente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEmpAgente_Internalname, "Empresa Agente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEmpAgente_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1398OpcEmpAgente), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcEmpAgente_Enabled!=0) ? context.localUtil.Format( (decimal)(A1398OpcEmpAgente), "9") : context.localUtil.Format( (decimal)(A1398OpcEmpAgente), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEmpAgente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEmpAgente_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcEMailPort_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcEMailPort_Internalname, "Puerto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcEMailPort_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1394OpcEMailPort), 4, 0, ".", "")), StringUtil.LTrim( ((edtOpcEMailPort_Enabled!=0) ? context.localUtil.Format( (decimal)(A1394OpcEMailPort), "ZZZ9") : context.localUtil.Format( (decimal)(A1394OpcEMailPort), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcEMailPort_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcEMailPort_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcCosIngreso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcCosIngreso_Internalname, "en ingresos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcCosIngreso_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1391OpcCosIngreso), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcCosIngreso_Enabled!=0) ? context.localUtil.Format( (decimal)(A1391OpcCosIngreso), "9") : context.localUtil.Format( (decimal)(A1391OpcCosIngreso), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcCosIngreso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcCosIngreso_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcFE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcFE_Internalname, "Electronica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcFE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1400OpcFE), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcFE_Enabled!=0) ? context.localUtil.Format( (decimal)(A1400OpcFE), "9") : context.localUtil.Format( (decimal)(A1400OpcFE), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcFE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcFE_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcFERetencion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcFERetencion_Internalname, "Electronica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcFERetencion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1401OpcFERetencion), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcFERetencion_Enabled!=0) ? context.localUtil.Format( (decimal)(A1401OpcFERetencion), "9") : context.localUtil.Format( (decimal)(A1401OpcFERetencion), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcFERetencion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcFERetencion_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcLetrasGirador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcLetrasGirador_Internalname, "- Girador", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcLetrasGirador_Internalname, A1403OpcLetrasGirador, StringUtil.RTrim( context.localUtil.Format( A1403OpcLetrasGirador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcLetrasGirador_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcLetrasGirador_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcLetrasLugar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcLetrasLugar_Internalname, "- Lugar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcLetrasLugar_Internalname, A1404OpcLetrasLugar, StringUtil.RTrim( context.localUtil.Format( A1404OpcLetrasLugar, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcLetrasLugar_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcLetrasLugar_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcAutOComNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcAutOComNum_Internalname, "OCom Num", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcAutOComNum_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2260OpcAutOComNum), 4, 0, ".", "")), StringUtil.LTrim( ((edtOpcAutOComNum_Enabled!=0) ? context.localUtil.Format( (decimal)(A2260OpcAutOComNum), "ZZZ9") : context.localUtil.Format( (decimal)(A2260OpcAutOComNum), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcAutOComNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcAutOComNum_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcServerFE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcServerFE_Internalname, "FE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcServerFE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1418OpcServerFE), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcServerFE_Enabled!=0) ? context.localUtil.Format( (decimal)(A1418OpcServerFE), "9") : context.localUtil.Format( (decimal)(A1418OpcServerFE), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcServerFE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcServerFE_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcCuentaDetraccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcCuentaDetraccion_Internalname, "Cuenta Detraccion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcCuentaDetraccion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2261OpcCuentaDetraccion), 4, 0, ".", "")), StringUtil.LTrim( ((edtOpcCuentaDetraccion_Enabled!=0) ? context.localUtil.Format( (decimal)(A2261OpcCuentaDetraccion), "ZZZ9") : context.localUtil.Format( (decimal)(A2261OpcCuentaDetraccion), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcCuentaDetraccion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcCuentaDetraccion_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedPrecios_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedPrecios_Internalname, "Modificar Precios", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedPrecios_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1412OpcPedPrecios), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedPrecios_Enabled!=0) ? context.localUtil.Format( (decimal)(A1412OpcPedPrecios), "9") : context.localUtil.Format( (decimal)(A1412OpcPedPrecios), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,173);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedPrecios_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedPrecios_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedDescuento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedDescuento_Internalname, "Modificar Descuentos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedDescuento_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1409OpcPedDescuento), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedDescuento_Enabled!=0) ? context.localUtil.Format( (decimal)(A1409OpcPedDescuento), "9") : context.localUtil.Format( (decimal)(A1409OpcPedDescuento), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedDescuento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedDescuento_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedStock_Internalname, "Stock Pedidos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1413OpcPedStock), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A1413OpcPedStock), "9") : context.localUtil.Format( (decimal)(A1413OpcPedStock), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,183);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedStock_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedVendedor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedVendedor_Internalname, "Modificar Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedVendedor_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1414OpcPedVendedor), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedVendedor_Enabled!=0) ? context.localUtil.Format( (decimal)(A1414OpcPedVendedor), "9") : context.localUtil.Format( (decimal)(A1414OpcPedVendedor), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,188);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedVendedor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedVendedor_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedMonCod_Internalname, "Moneda Pedido Default", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1411OpcPedMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1411OpcPedMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1411OpcPedMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,193);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedCondPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedCondPago_Internalname, "Modificar Condicion de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedCondPago_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1408OpcPedCondPago), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedCondPago_Enabled!=0) ? context.localUtil.Format( (decimal)(A1408OpcPedCondPago), "9") : context.localUtil.Format( (decimal)(A1408OpcPedCondPago), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,198);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedCondPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedCondPago_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOpcPedLista_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOpcPedLista_Internalname, "Modificar Lista de Precios", "col-sm-3 AttributeLabel", 1, true, "");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOpcPedLista_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1410OpcPedLista), 1, 0, ".", "")), StringUtil.LTrim( ((edtOpcPedLista_Enabled!=0) ? context.localUtil.Format( (decimal)(A1410OpcPedLista), "9") : context.localUtil.Format( (decimal)(A1410OpcPedLista), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,203);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOpcPedLista_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOpcPedLista_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOPCIONES.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOPCIONES.htm");
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
            Z347OpcId = (short)(context.localUtil.CToN( cgiGet( "Z347OpcId"), ".", ","));
            Z1419OpcStk = (short)(context.localUtil.CToN( cgiGet( "Z1419OpcStk"), ".", ","));
            Z1402OpcIVA = context.localUtil.CToN( cgiGet( "Z1402OpcIVA"), ".", ",");
            Z1397OpcEmp = cgiGet( "Z1397OpcEmp");
            Z1390OpcAutOcom = (short)(context.localUtil.CToN( cgiGet( "Z1390OpcAutOcom"), ".", ","));
            Z1389OpcAutCompras = (short)(context.localUtil.CToN( cgiGet( "Z1389OpcAutCompras"), ".", ","));
            Z1406OpcPedAut = (short)(context.localUtil.CToN( cgiGet( "Z1406OpcPedAut"), ".", ","));
            Z1421OpcVersion = cgiGet( "Z1421OpcVersion");
            Z1417OpcRetencion = context.localUtil.CToN( cgiGet( "Z1417OpcRetencion"), ".", ",");
            Z1415OpcPercepcion = context.localUtil.CToN( cgiGet( "Z1415OpcPercepcion"), ".", ",");
            Z1416OpcPercepcionAgentes = context.localUtil.CToN( cgiGet( "Z1416OpcPercepcionAgentes"), ".", ",");
            Z1407OpcPedAutNum = (short)(context.localUtil.CToN( cgiGet( "Z1407OpcPedAutNum"), ".", ","));
            Z1405OpcListaPrecios = (short)(context.localUtil.CToN( cgiGet( "Z1405OpcListaPrecios"), ".", ","));
            Z1399OpcEntrada = (short)(context.localUtil.CToN( cgiGet( "Z1399OpcEntrada"), ".", ","));
            Z1420OpcStkComp = (short)(context.localUtil.CToN( cgiGet( "Z1420OpcStkComp"), ".", ","));
            Z1392OpcEMailHost = cgiGet( "Z1392OpcEMailHost");
            Z1395OpcEMailSalida = cgiGet( "Z1395OpcEMailSalida");
            Z1396OpcEMailUsu = cgiGet( "Z1396OpcEMailUsu");
            Z1393OpcEMailPass = cgiGet( "Z1393OpcEMailPass");
            Z1398OpcEmpAgente = (short)(context.localUtil.CToN( cgiGet( "Z1398OpcEmpAgente"), ".", ","));
            Z1394OpcEMailPort = (short)(context.localUtil.CToN( cgiGet( "Z1394OpcEMailPort"), ".", ","));
            Z1391OpcCosIngreso = (short)(context.localUtil.CToN( cgiGet( "Z1391OpcCosIngreso"), ".", ","));
            Z1400OpcFE = (short)(context.localUtil.CToN( cgiGet( "Z1400OpcFE"), ".", ","));
            Z1401OpcFERetencion = (short)(context.localUtil.CToN( cgiGet( "Z1401OpcFERetencion"), ".", ","));
            Z1403OpcLetrasGirador = cgiGet( "Z1403OpcLetrasGirador");
            Z1404OpcLetrasLugar = cgiGet( "Z1404OpcLetrasLugar");
            Z2260OpcAutOComNum = (short)(context.localUtil.CToN( cgiGet( "Z2260OpcAutOComNum"), ".", ","));
            Z1418OpcServerFE = (short)(context.localUtil.CToN( cgiGet( "Z1418OpcServerFE"), ".", ","));
            Z2261OpcCuentaDetraccion = (short)(context.localUtil.CToN( cgiGet( "Z2261OpcCuentaDetraccion"), ".", ","));
            Z1412OpcPedPrecios = (short)(context.localUtil.CToN( cgiGet( "Z1412OpcPedPrecios"), ".", ","));
            Z1409OpcPedDescuento = (short)(context.localUtil.CToN( cgiGet( "Z1409OpcPedDescuento"), ".", ","));
            Z1413OpcPedStock = (short)(context.localUtil.CToN( cgiGet( "Z1413OpcPedStock"), ".", ","));
            Z1414OpcPedVendedor = (short)(context.localUtil.CToN( cgiGet( "Z1414OpcPedVendedor"), ".", ","));
            Z1411OpcPedMonCod = (int)(context.localUtil.CToN( cgiGet( "Z1411OpcPedMonCod"), ".", ","));
            Z1408OpcPedCondPago = (short)(context.localUtil.CToN( cgiGet( "Z1408OpcPedCondPago"), ".", ","));
            Z1410OpcPedLista = (short)(context.localUtil.CToN( cgiGet( "Z1410OpcPedLista"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcId_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCID");
               AnyError = 1;
               GX_FocusControl = edtOpcId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A347OpcId = 0;
               AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
            }
            else
            {
               A347OpcId = (short)(context.localUtil.CToN( cgiGet( edtOpcId_Internalname), ".", ","));
               AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcStk_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcStk_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCSTK");
               AnyError = 1;
               GX_FocusControl = edtOpcStk_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1419OpcStk = 0;
               AssignAttri("", false, "A1419OpcStk", StringUtil.Str( (decimal)(A1419OpcStk), 1, 0));
            }
            else
            {
               A1419OpcStk = (short)(context.localUtil.CToN( cgiGet( edtOpcStk_Internalname), ".", ","));
               AssignAttri("", false, "A1419OpcStk", StringUtil.Str( (decimal)(A1419OpcStk), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcIVA_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcIVA_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCIVA");
               AnyError = 1;
               GX_FocusControl = edtOpcIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1402OpcIVA = 0;
               AssignAttri("", false, "A1402OpcIVA", StringUtil.LTrimStr( A1402OpcIVA, 10, 2));
            }
            else
            {
               A1402OpcIVA = context.localUtil.CToN( cgiGet( edtOpcIVA_Internalname), ".", ",");
               AssignAttri("", false, "A1402OpcIVA", StringUtil.LTrimStr( A1402OpcIVA, 10, 2));
            }
            A1397OpcEmp = cgiGet( edtOpcEmp_Internalname);
            AssignAttri("", false, "A1397OpcEmp", A1397OpcEmp);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcAutOcom_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcAutOcom_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCAUTOCOM");
               AnyError = 1;
               GX_FocusControl = edtOpcAutOcom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1390OpcAutOcom = 0;
               AssignAttri("", false, "A1390OpcAutOcom", StringUtil.Str( (decimal)(A1390OpcAutOcom), 1, 0));
            }
            else
            {
               A1390OpcAutOcom = (short)(context.localUtil.CToN( cgiGet( edtOpcAutOcom_Internalname), ".", ","));
               AssignAttri("", false, "A1390OpcAutOcom", StringUtil.Str( (decimal)(A1390OpcAutOcom), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcAutCompras_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcAutCompras_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCAUTCOMPRAS");
               AnyError = 1;
               GX_FocusControl = edtOpcAutCompras_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1389OpcAutCompras = 0;
               AssignAttri("", false, "A1389OpcAutCompras", StringUtil.Str( (decimal)(A1389OpcAutCompras), 1, 0));
            }
            else
            {
               A1389OpcAutCompras = (short)(context.localUtil.CToN( cgiGet( edtOpcAutCompras_Internalname), ".", ","));
               AssignAttri("", false, "A1389OpcAutCompras", StringUtil.Str( (decimal)(A1389OpcAutCompras), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedAut_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedAut_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDAUT");
               AnyError = 1;
               GX_FocusControl = edtOpcPedAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1406OpcPedAut = 0;
               AssignAttri("", false, "A1406OpcPedAut", StringUtil.Str( (decimal)(A1406OpcPedAut), 1, 0));
            }
            else
            {
               A1406OpcPedAut = (short)(context.localUtil.CToN( cgiGet( edtOpcPedAut_Internalname), ".", ","));
               AssignAttri("", false, "A1406OpcPedAut", StringUtil.Str( (decimal)(A1406OpcPedAut), 1, 0));
            }
            A1421OpcVersion = cgiGet( edtOpcVersion_Internalname);
            AssignAttri("", false, "A1421OpcVersion", A1421OpcVersion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcRetencion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcRetencion_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCRETENCION");
               AnyError = 1;
               GX_FocusControl = edtOpcRetencion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1417OpcRetencion = 0;
               AssignAttri("", false, "A1417OpcRetencion", StringUtil.LTrimStr( A1417OpcRetencion, 10, 2));
            }
            else
            {
               A1417OpcRetencion = context.localUtil.CToN( cgiGet( edtOpcRetencion_Internalname), ".", ",");
               AssignAttri("", false, "A1417OpcRetencion", StringUtil.LTrimStr( A1417OpcRetencion, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPercepcion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPercepcion_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPERCEPCION");
               AnyError = 1;
               GX_FocusControl = edtOpcPercepcion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1415OpcPercepcion = 0;
               AssignAttri("", false, "A1415OpcPercepcion", StringUtil.LTrimStr( A1415OpcPercepcion, 10, 2));
            }
            else
            {
               A1415OpcPercepcion = context.localUtil.CToN( cgiGet( edtOpcPercepcion_Internalname), ".", ",");
               AssignAttri("", false, "A1415OpcPercepcion", StringUtil.LTrimStr( A1415OpcPercepcion, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPercepcionAgentes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPercepcionAgentes_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPERCEPCIONAGENTES");
               AnyError = 1;
               GX_FocusControl = edtOpcPercepcionAgentes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1416OpcPercepcionAgentes = 0;
               AssignAttri("", false, "A1416OpcPercepcionAgentes", StringUtil.LTrimStr( A1416OpcPercepcionAgentes, 10, 2));
            }
            else
            {
               A1416OpcPercepcionAgentes = context.localUtil.CToN( cgiGet( edtOpcPercepcionAgentes_Internalname), ".", ",");
               AssignAttri("", false, "A1416OpcPercepcionAgentes", StringUtil.LTrimStr( A1416OpcPercepcionAgentes, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedAutNum_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedAutNum_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDAUTNUM");
               AnyError = 1;
               GX_FocusControl = edtOpcPedAutNum_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1407OpcPedAutNum = 0;
               AssignAttri("", false, "A1407OpcPedAutNum", StringUtil.LTrimStr( (decimal)(A1407OpcPedAutNum), 2, 0));
            }
            else
            {
               A1407OpcPedAutNum = (short)(context.localUtil.CToN( cgiGet( edtOpcPedAutNum_Internalname), ".", ","));
               AssignAttri("", false, "A1407OpcPedAutNum", StringUtil.LTrimStr( (decimal)(A1407OpcPedAutNum), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcListaPrecios_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcListaPrecios_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCLISTAPRECIOS");
               AnyError = 1;
               GX_FocusControl = edtOpcListaPrecios_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1405OpcListaPrecios = 0;
               AssignAttri("", false, "A1405OpcListaPrecios", StringUtil.Str( (decimal)(A1405OpcListaPrecios), 1, 0));
            }
            else
            {
               A1405OpcListaPrecios = (short)(context.localUtil.CToN( cgiGet( edtOpcListaPrecios_Internalname), ".", ","));
               AssignAttri("", false, "A1405OpcListaPrecios", StringUtil.Str( (decimal)(A1405OpcListaPrecios), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcEntrada_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcEntrada_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCENTRADA");
               AnyError = 1;
               GX_FocusControl = edtOpcEntrada_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1399OpcEntrada = 0;
               AssignAttri("", false, "A1399OpcEntrada", StringUtil.Str( (decimal)(A1399OpcEntrada), 1, 0));
            }
            else
            {
               A1399OpcEntrada = (short)(context.localUtil.CToN( cgiGet( edtOpcEntrada_Internalname), ".", ","));
               AssignAttri("", false, "A1399OpcEntrada", StringUtil.Str( (decimal)(A1399OpcEntrada), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcStkComp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcStkComp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCSTKCOMP");
               AnyError = 1;
               GX_FocusControl = edtOpcStkComp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1420OpcStkComp = 0;
               AssignAttri("", false, "A1420OpcStkComp", StringUtil.Str( (decimal)(A1420OpcStkComp), 1, 0));
            }
            else
            {
               A1420OpcStkComp = (short)(context.localUtil.CToN( cgiGet( edtOpcStkComp_Internalname), ".", ","));
               AssignAttri("", false, "A1420OpcStkComp", StringUtil.Str( (decimal)(A1420OpcStkComp), 1, 0));
            }
            A1392OpcEMailHost = cgiGet( edtOpcEMailHost_Internalname);
            AssignAttri("", false, "A1392OpcEMailHost", A1392OpcEMailHost);
            A1395OpcEMailSalida = cgiGet( edtOpcEMailSalida_Internalname);
            AssignAttri("", false, "A1395OpcEMailSalida", A1395OpcEMailSalida);
            A1396OpcEMailUsu = cgiGet( edtOpcEMailUsu_Internalname);
            AssignAttri("", false, "A1396OpcEMailUsu", A1396OpcEMailUsu);
            A1393OpcEMailPass = cgiGet( edtOpcEMailPass_Internalname);
            AssignAttri("", false, "A1393OpcEMailPass", A1393OpcEMailPass);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcEmpAgente_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcEmpAgente_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCEMPAGENTE");
               AnyError = 1;
               GX_FocusControl = edtOpcEmpAgente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1398OpcEmpAgente = 0;
               AssignAttri("", false, "A1398OpcEmpAgente", StringUtil.Str( (decimal)(A1398OpcEmpAgente), 1, 0));
            }
            else
            {
               A1398OpcEmpAgente = (short)(context.localUtil.CToN( cgiGet( edtOpcEmpAgente_Internalname), ".", ","));
               AssignAttri("", false, "A1398OpcEmpAgente", StringUtil.Str( (decimal)(A1398OpcEmpAgente), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcEMailPort_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcEMailPort_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCEMAILPORT");
               AnyError = 1;
               GX_FocusControl = edtOpcEMailPort_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1394OpcEMailPort = 0;
               AssignAttri("", false, "A1394OpcEMailPort", StringUtil.LTrimStr( (decimal)(A1394OpcEMailPort), 4, 0));
            }
            else
            {
               A1394OpcEMailPort = (short)(context.localUtil.CToN( cgiGet( edtOpcEMailPort_Internalname), ".", ","));
               AssignAttri("", false, "A1394OpcEMailPort", StringUtil.LTrimStr( (decimal)(A1394OpcEMailPort), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcCosIngreso_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcCosIngreso_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCCOSINGRESO");
               AnyError = 1;
               GX_FocusControl = edtOpcCosIngreso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1391OpcCosIngreso = 0;
               AssignAttri("", false, "A1391OpcCosIngreso", StringUtil.Str( (decimal)(A1391OpcCosIngreso), 1, 0));
            }
            else
            {
               A1391OpcCosIngreso = (short)(context.localUtil.CToN( cgiGet( edtOpcCosIngreso_Internalname), ".", ","));
               AssignAttri("", false, "A1391OpcCosIngreso", StringUtil.Str( (decimal)(A1391OpcCosIngreso), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcFE_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcFE_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCFE");
               AnyError = 1;
               GX_FocusControl = edtOpcFE_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1400OpcFE = 0;
               AssignAttri("", false, "A1400OpcFE", StringUtil.Str( (decimal)(A1400OpcFE), 1, 0));
            }
            else
            {
               A1400OpcFE = (short)(context.localUtil.CToN( cgiGet( edtOpcFE_Internalname), ".", ","));
               AssignAttri("", false, "A1400OpcFE", StringUtil.Str( (decimal)(A1400OpcFE), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcFERetencion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcFERetencion_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCFERETENCION");
               AnyError = 1;
               GX_FocusControl = edtOpcFERetencion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1401OpcFERetencion = 0;
               AssignAttri("", false, "A1401OpcFERetencion", StringUtil.Str( (decimal)(A1401OpcFERetencion), 1, 0));
            }
            else
            {
               A1401OpcFERetencion = (short)(context.localUtil.CToN( cgiGet( edtOpcFERetencion_Internalname), ".", ","));
               AssignAttri("", false, "A1401OpcFERetencion", StringUtil.Str( (decimal)(A1401OpcFERetencion), 1, 0));
            }
            A1403OpcLetrasGirador = cgiGet( edtOpcLetrasGirador_Internalname);
            AssignAttri("", false, "A1403OpcLetrasGirador", A1403OpcLetrasGirador);
            A1404OpcLetrasLugar = cgiGet( edtOpcLetrasLugar_Internalname);
            AssignAttri("", false, "A1404OpcLetrasLugar", A1404OpcLetrasLugar);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcAutOComNum_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcAutOComNum_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCAUTOCOMNUM");
               AnyError = 1;
               GX_FocusControl = edtOpcAutOComNum_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2260OpcAutOComNum = 0;
               AssignAttri("", false, "A2260OpcAutOComNum", StringUtil.LTrimStr( (decimal)(A2260OpcAutOComNum), 4, 0));
            }
            else
            {
               A2260OpcAutOComNum = (short)(context.localUtil.CToN( cgiGet( edtOpcAutOComNum_Internalname), ".", ","));
               AssignAttri("", false, "A2260OpcAutOComNum", StringUtil.LTrimStr( (decimal)(A2260OpcAutOComNum), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcServerFE_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcServerFE_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCSERVERFE");
               AnyError = 1;
               GX_FocusControl = edtOpcServerFE_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1418OpcServerFE = 0;
               AssignAttri("", false, "A1418OpcServerFE", StringUtil.Str( (decimal)(A1418OpcServerFE), 1, 0));
            }
            else
            {
               A1418OpcServerFE = (short)(context.localUtil.CToN( cgiGet( edtOpcServerFE_Internalname), ".", ","));
               AssignAttri("", false, "A1418OpcServerFE", StringUtil.Str( (decimal)(A1418OpcServerFE), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcCuentaDetraccion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcCuentaDetraccion_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCCUENTADETRACCION");
               AnyError = 1;
               GX_FocusControl = edtOpcCuentaDetraccion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2261OpcCuentaDetraccion = 0;
               AssignAttri("", false, "A2261OpcCuentaDetraccion", StringUtil.LTrimStr( (decimal)(A2261OpcCuentaDetraccion), 4, 0));
            }
            else
            {
               A2261OpcCuentaDetraccion = (short)(context.localUtil.CToN( cgiGet( edtOpcCuentaDetraccion_Internalname), ".", ","));
               AssignAttri("", false, "A2261OpcCuentaDetraccion", StringUtil.LTrimStr( (decimal)(A2261OpcCuentaDetraccion), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedPrecios_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedPrecios_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDPRECIOS");
               AnyError = 1;
               GX_FocusControl = edtOpcPedPrecios_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1412OpcPedPrecios = 0;
               AssignAttri("", false, "A1412OpcPedPrecios", StringUtil.Str( (decimal)(A1412OpcPedPrecios), 1, 0));
            }
            else
            {
               A1412OpcPedPrecios = (short)(context.localUtil.CToN( cgiGet( edtOpcPedPrecios_Internalname), ".", ","));
               AssignAttri("", false, "A1412OpcPedPrecios", StringUtil.Str( (decimal)(A1412OpcPedPrecios), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedDescuento_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedDescuento_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDDESCUENTO");
               AnyError = 1;
               GX_FocusControl = edtOpcPedDescuento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1409OpcPedDescuento = 0;
               AssignAttri("", false, "A1409OpcPedDescuento", StringUtil.Str( (decimal)(A1409OpcPedDescuento), 1, 0));
            }
            else
            {
               A1409OpcPedDescuento = (short)(context.localUtil.CToN( cgiGet( edtOpcPedDescuento_Internalname), ".", ","));
               AssignAttri("", false, "A1409OpcPedDescuento", StringUtil.Str( (decimal)(A1409OpcPedDescuento), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedStock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedStock_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDSTOCK");
               AnyError = 1;
               GX_FocusControl = edtOpcPedStock_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1413OpcPedStock = 0;
               AssignAttri("", false, "A1413OpcPedStock", StringUtil.Str( (decimal)(A1413OpcPedStock), 1, 0));
            }
            else
            {
               A1413OpcPedStock = (short)(context.localUtil.CToN( cgiGet( edtOpcPedStock_Internalname), ".", ","));
               AssignAttri("", false, "A1413OpcPedStock", StringUtil.Str( (decimal)(A1413OpcPedStock), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedVendedor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedVendedor_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDVENDEDOR");
               AnyError = 1;
               GX_FocusControl = edtOpcPedVendedor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1414OpcPedVendedor = 0;
               AssignAttri("", false, "A1414OpcPedVendedor", StringUtil.Str( (decimal)(A1414OpcPedVendedor), 1, 0));
            }
            else
            {
               A1414OpcPedVendedor = (short)(context.localUtil.CToN( cgiGet( edtOpcPedVendedor_Internalname), ".", ","));
               AssignAttri("", false, "A1414OpcPedVendedor", StringUtil.Str( (decimal)(A1414OpcPedVendedor), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDMONCOD");
               AnyError = 1;
               GX_FocusControl = edtOpcPedMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1411OpcPedMonCod = 0;
               AssignAttri("", false, "A1411OpcPedMonCod", StringUtil.LTrimStr( (decimal)(A1411OpcPedMonCod), 6, 0));
            }
            else
            {
               A1411OpcPedMonCod = (int)(context.localUtil.CToN( cgiGet( edtOpcPedMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A1411OpcPedMonCod", StringUtil.LTrimStr( (decimal)(A1411OpcPedMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedCondPago_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedCondPago_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDCONDPAGO");
               AnyError = 1;
               GX_FocusControl = edtOpcPedCondPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1408OpcPedCondPago = 0;
               AssignAttri("", false, "A1408OpcPedCondPago", StringUtil.Str( (decimal)(A1408OpcPedCondPago), 1, 0));
            }
            else
            {
               A1408OpcPedCondPago = (short)(context.localUtil.CToN( cgiGet( edtOpcPedCondPago_Internalname), ".", ","));
               AssignAttri("", false, "A1408OpcPedCondPago", StringUtil.Str( (decimal)(A1408OpcPedCondPago), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOpcPedLista_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOpcPedLista_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPCPEDLISTA");
               AnyError = 1;
               GX_FocusControl = edtOpcPedLista_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1410OpcPedLista = 0;
               AssignAttri("", false, "A1410OpcPedLista", StringUtil.Str( (decimal)(A1410OpcPedLista), 1, 0));
            }
            else
            {
               A1410OpcPedLista = (short)(context.localUtil.CToN( cgiGet( edtOpcPedLista_Internalname), ".", ","));
               AssignAttri("", false, "A1410OpcPedLista", StringUtil.Str( (decimal)(A1410OpcPedLista), 1, 0));
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
               A347OpcId = (short)(NumberUtil.Val( GetPar( "OpcId"), "."));
               AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
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
               InitAll0R27( ) ;
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
         DisableAttributes0R27( ) ;
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

      protected void ResetCaption0R0( )
      {
      }

      protected void ZM0R27( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1419OpcStk = T000R3_A1419OpcStk[0];
               Z1402OpcIVA = T000R3_A1402OpcIVA[0];
               Z1397OpcEmp = T000R3_A1397OpcEmp[0];
               Z1390OpcAutOcom = T000R3_A1390OpcAutOcom[0];
               Z1389OpcAutCompras = T000R3_A1389OpcAutCompras[0];
               Z1406OpcPedAut = T000R3_A1406OpcPedAut[0];
               Z1421OpcVersion = T000R3_A1421OpcVersion[0];
               Z1417OpcRetencion = T000R3_A1417OpcRetencion[0];
               Z1415OpcPercepcion = T000R3_A1415OpcPercepcion[0];
               Z1416OpcPercepcionAgentes = T000R3_A1416OpcPercepcionAgentes[0];
               Z1407OpcPedAutNum = T000R3_A1407OpcPedAutNum[0];
               Z1405OpcListaPrecios = T000R3_A1405OpcListaPrecios[0];
               Z1399OpcEntrada = T000R3_A1399OpcEntrada[0];
               Z1420OpcStkComp = T000R3_A1420OpcStkComp[0];
               Z1392OpcEMailHost = T000R3_A1392OpcEMailHost[0];
               Z1395OpcEMailSalida = T000R3_A1395OpcEMailSalida[0];
               Z1396OpcEMailUsu = T000R3_A1396OpcEMailUsu[0];
               Z1393OpcEMailPass = T000R3_A1393OpcEMailPass[0];
               Z1398OpcEmpAgente = T000R3_A1398OpcEmpAgente[0];
               Z1394OpcEMailPort = T000R3_A1394OpcEMailPort[0];
               Z1391OpcCosIngreso = T000R3_A1391OpcCosIngreso[0];
               Z1400OpcFE = T000R3_A1400OpcFE[0];
               Z1401OpcFERetencion = T000R3_A1401OpcFERetencion[0];
               Z1403OpcLetrasGirador = T000R3_A1403OpcLetrasGirador[0];
               Z1404OpcLetrasLugar = T000R3_A1404OpcLetrasLugar[0];
               Z2260OpcAutOComNum = T000R3_A2260OpcAutOComNum[0];
               Z1418OpcServerFE = T000R3_A1418OpcServerFE[0];
               Z2261OpcCuentaDetraccion = T000R3_A2261OpcCuentaDetraccion[0];
               Z1412OpcPedPrecios = T000R3_A1412OpcPedPrecios[0];
               Z1409OpcPedDescuento = T000R3_A1409OpcPedDescuento[0];
               Z1413OpcPedStock = T000R3_A1413OpcPedStock[0];
               Z1414OpcPedVendedor = T000R3_A1414OpcPedVendedor[0];
               Z1411OpcPedMonCod = T000R3_A1411OpcPedMonCod[0];
               Z1408OpcPedCondPago = T000R3_A1408OpcPedCondPago[0];
               Z1410OpcPedLista = T000R3_A1410OpcPedLista[0];
            }
            else
            {
               Z1419OpcStk = A1419OpcStk;
               Z1402OpcIVA = A1402OpcIVA;
               Z1397OpcEmp = A1397OpcEmp;
               Z1390OpcAutOcom = A1390OpcAutOcom;
               Z1389OpcAutCompras = A1389OpcAutCompras;
               Z1406OpcPedAut = A1406OpcPedAut;
               Z1421OpcVersion = A1421OpcVersion;
               Z1417OpcRetencion = A1417OpcRetencion;
               Z1415OpcPercepcion = A1415OpcPercepcion;
               Z1416OpcPercepcionAgentes = A1416OpcPercepcionAgentes;
               Z1407OpcPedAutNum = A1407OpcPedAutNum;
               Z1405OpcListaPrecios = A1405OpcListaPrecios;
               Z1399OpcEntrada = A1399OpcEntrada;
               Z1420OpcStkComp = A1420OpcStkComp;
               Z1392OpcEMailHost = A1392OpcEMailHost;
               Z1395OpcEMailSalida = A1395OpcEMailSalida;
               Z1396OpcEMailUsu = A1396OpcEMailUsu;
               Z1393OpcEMailPass = A1393OpcEMailPass;
               Z1398OpcEmpAgente = A1398OpcEmpAgente;
               Z1394OpcEMailPort = A1394OpcEMailPort;
               Z1391OpcCosIngreso = A1391OpcCosIngreso;
               Z1400OpcFE = A1400OpcFE;
               Z1401OpcFERetencion = A1401OpcFERetencion;
               Z1403OpcLetrasGirador = A1403OpcLetrasGirador;
               Z1404OpcLetrasLugar = A1404OpcLetrasLugar;
               Z2260OpcAutOComNum = A2260OpcAutOComNum;
               Z1418OpcServerFE = A1418OpcServerFE;
               Z2261OpcCuentaDetraccion = A2261OpcCuentaDetraccion;
               Z1412OpcPedPrecios = A1412OpcPedPrecios;
               Z1409OpcPedDescuento = A1409OpcPedDescuento;
               Z1413OpcPedStock = A1413OpcPedStock;
               Z1414OpcPedVendedor = A1414OpcPedVendedor;
               Z1411OpcPedMonCod = A1411OpcPedMonCod;
               Z1408OpcPedCondPago = A1408OpcPedCondPago;
               Z1410OpcPedLista = A1410OpcPedLista;
            }
         }
         if ( GX_JID == -1 )
         {
            Z347OpcId = A347OpcId;
            Z1419OpcStk = A1419OpcStk;
            Z1402OpcIVA = A1402OpcIVA;
            Z1397OpcEmp = A1397OpcEmp;
            Z1390OpcAutOcom = A1390OpcAutOcom;
            Z1389OpcAutCompras = A1389OpcAutCompras;
            Z1406OpcPedAut = A1406OpcPedAut;
            Z1421OpcVersion = A1421OpcVersion;
            Z1417OpcRetencion = A1417OpcRetencion;
            Z1415OpcPercepcion = A1415OpcPercepcion;
            Z1416OpcPercepcionAgentes = A1416OpcPercepcionAgentes;
            Z1407OpcPedAutNum = A1407OpcPedAutNum;
            Z1405OpcListaPrecios = A1405OpcListaPrecios;
            Z1399OpcEntrada = A1399OpcEntrada;
            Z1420OpcStkComp = A1420OpcStkComp;
            Z1392OpcEMailHost = A1392OpcEMailHost;
            Z1395OpcEMailSalida = A1395OpcEMailSalida;
            Z1396OpcEMailUsu = A1396OpcEMailUsu;
            Z1393OpcEMailPass = A1393OpcEMailPass;
            Z1398OpcEmpAgente = A1398OpcEmpAgente;
            Z1394OpcEMailPort = A1394OpcEMailPort;
            Z1391OpcCosIngreso = A1391OpcCosIngreso;
            Z1400OpcFE = A1400OpcFE;
            Z1401OpcFERetencion = A1401OpcFERetencion;
            Z1403OpcLetrasGirador = A1403OpcLetrasGirador;
            Z1404OpcLetrasLugar = A1404OpcLetrasLugar;
            Z2260OpcAutOComNum = A2260OpcAutOComNum;
            Z1418OpcServerFE = A1418OpcServerFE;
            Z2261OpcCuentaDetraccion = A2261OpcCuentaDetraccion;
            Z1412OpcPedPrecios = A1412OpcPedPrecios;
            Z1409OpcPedDescuento = A1409OpcPedDescuento;
            Z1413OpcPedStock = A1413OpcPedStock;
            Z1414OpcPedVendedor = A1414OpcPedVendedor;
            Z1411OpcPedMonCod = A1411OpcPedMonCod;
            Z1408OpcPedCondPago = A1408OpcPedCondPago;
            Z1410OpcPedLista = A1410OpcPedLista;
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

      protected void Load0R27( )
      {
         /* Using cursor T000R4 */
         pr_default.execute(2, new Object[] {A347OpcId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound27 = 1;
            A1419OpcStk = T000R4_A1419OpcStk[0];
            AssignAttri("", false, "A1419OpcStk", StringUtil.Str( (decimal)(A1419OpcStk), 1, 0));
            A1402OpcIVA = T000R4_A1402OpcIVA[0];
            AssignAttri("", false, "A1402OpcIVA", StringUtil.LTrimStr( A1402OpcIVA, 10, 2));
            A1397OpcEmp = T000R4_A1397OpcEmp[0];
            AssignAttri("", false, "A1397OpcEmp", A1397OpcEmp);
            A1390OpcAutOcom = T000R4_A1390OpcAutOcom[0];
            AssignAttri("", false, "A1390OpcAutOcom", StringUtil.Str( (decimal)(A1390OpcAutOcom), 1, 0));
            A1389OpcAutCompras = T000R4_A1389OpcAutCompras[0];
            AssignAttri("", false, "A1389OpcAutCompras", StringUtil.Str( (decimal)(A1389OpcAutCompras), 1, 0));
            A1406OpcPedAut = T000R4_A1406OpcPedAut[0];
            AssignAttri("", false, "A1406OpcPedAut", StringUtil.Str( (decimal)(A1406OpcPedAut), 1, 0));
            A1421OpcVersion = T000R4_A1421OpcVersion[0];
            AssignAttri("", false, "A1421OpcVersion", A1421OpcVersion);
            A1417OpcRetencion = T000R4_A1417OpcRetencion[0];
            AssignAttri("", false, "A1417OpcRetencion", StringUtil.LTrimStr( A1417OpcRetencion, 10, 2));
            A1415OpcPercepcion = T000R4_A1415OpcPercepcion[0];
            AssignAttri("", false, "A1415OpcPercepcion", StringUtil.LTrimStr( A1415OpcPercepcion, 10, 2));
            A1416OpcPercepcionAgentes = T000R4_A1416OpcPercepcionAgentes[0];
            AssignAttri("", false, "A1416OpcPercepcionAgentes", StringUtil.LTrimStr( A1416OpcPercepcionAgentes, 10, 2));
            A1407OpcPedAutNum = T000R4_A1407OpcPedAutNum[0];
            AssignAttri("", false, "A1407OpcPedAutNum", StringUtil.LTrimStr( (decimal)(A1407OpcPedAutNum), 2, 0));
            A1405OpcListaPrecios = T000R4_A1405OpcListaPrecios[0];
            AssignAttri("", false, "A1405OpcListaPrecios", StringUtil.Str( (decimal)(A1405OpcListaPrecios), 1, 0));
            A1399OpcEntrada = T000R4_A1399OpcEntrada[0];
            AssignAttri("", false, "A1399OpcEntrada", StringUtil.Str( (decimal)(A1399OpcEntrada), 1, 0));
            A1420OpcStkComp = T000R4_A1420OpcStkComp[0];
            AssignAttri("", false, "A1420OpcStkComp", StringUtil.Str( (decimal)(A1420OpcStkComp), 1, 0));
            A1392OpcEMailHost = T000R4_A1392OpcEMailHost[0];
            AssignAttri("", false, "A1392OpcEMailHost", A1392OpcEMailHost);
            A1395OpcEMailSalida = T000R4_A1395OpcEMailSalida[0];
            AssignAttri("", false, "A1395OpcEMailSalida", A1395OpcEMailSalida);
            A1396OpcEMailUsu = T000R4_A1396OpcEMailUsu[0];
            AssignAttri("", false, "A1396OpcEMailUsu", A1396OpcEMailUsu);
            A1393OpcEMailPass = T000R4_A1393OpcEMailPass[0];
            AssignAttri("", false, "A1393OpcEMailPass", A1393OpcEMailPass);
            A1398OpcEmpAgente = T000R4_A1398OpcEmpAgente[0];
            AssignAttri("", false, "A1398OpcEmpAgente", StringUtil.Str( (decimal)(A1398OpcEmpAgente), 1, 0));
            A1394OpcEMailPort = T000R4_A1394OpcEMailPort[0];
            AssignAttri("", false, "A1394OpcEMailPort", StringUtil.LTrimStr( (decimal)(A1394OpcEMailPort), 4, 0));
            A1391OpcCosIngreso = T000R4_A1391OpcCosIngreso[0];
            AssignAttri("", false, "A1391OpcCosIngreso", StringUtil.Str( (decimal)(A1391OpcCosIngreso), 1, 0));
            A1400OpcFE = T000R4_A1400OpcFE[0];
            AssignAttri("", false, "A1400OpcFE", StringUtil.Str( (decimal)(A1400OpcFE), 1, 0));
            A1401OpcFERetencion = T000R4_A1401OpcFERetencion[0];
            AssignAttri("", false, "A1401OpcFERetencion", StringUtil.Str( (decimal)(A1401OpcFERetencion), 1, 0));
            A1403OpcLetrasGirador = T000R4_A1403OpcLetrasGirador[0];
            AssignAttri("", false, "A1403OpcLetrasGirador", A1403OpcLetrasGirador);
            A1404OpcLetrasLugar = T000R4_A1404OpcLetrasLugar[0];
            AssignAttri("", false, "A1404OpcLetrasLugar", A1404OpcLetrasLugar);
            A2260OpcAutOComNum = T000R4_A2260OpcAutOComNum[0];
            AssignAttri("", false, "A2260OpcAutOComNum", StringUtil.LTrimStr( (decimal)(A2260OpcAutOComNum), 4, 0));
            A1418OpcServerFE = T000R4_A1418OpcServerFE[0];
            AssignAttri("", false, "A1418OpcServerFE", StringUtil.Str( (decimal)(A1418OpcServerFE), 1, 0));
            A2261OpcCuentaDetraccion = T000R4_A2261OpcCuentaDetraccion[0];
            AssignAttri("", false, "A2261OpcCuentaDetraccion", StringUtil.LTrimStr( (decimal)(A2261OpcCuentaDetraccion), 4, 0));
            A1412OpcPedPrecios = T000R4_A1412OpcPedPrecios[0];
            AssignAttri("", false, "A1412OpcPedPrecios", StringUtil.Str( (decimal)(A1412OpcPedPrecios), 1, 0));
            A1409OpcPedDescuento = T000R4_A1409OpcPedDescuento[0];
            AssignAttri("", false, "A1409OpcPedDescuento", StringUtil.Str( (decimal)(A1409OpcPedDescuento), 1, 0));
            A1413OpcPedStock = T000R4_A1413OpcPedStock[0];
            AssignAttri("", false, "A1413OpcPedStock", StringUtil.Str( (decimal)(A1413OpcPedStock), 1, 0));
            A1414OpcPedVendedor = T000R4_A1414OpcPedVendedor[0];
            AssignAttri("", false, "A1414OpcPedVendedor", StringUtil.Str( (decimal)(A1414OpcPedVendedor), 1, 0));
            A1411OpcPedMonCod = T000R4_A1411OpcPedMonCod[0];
            AssignAttri("", false, "A1411OpcPedMonCod", StringUtil.LTrimStr( (decimal)(A1411OpcPedMonCod), 6, 0));
            A1408OpcPedCondPago = T000R4_A1408OpcPedCondPago[0];
            AssignAttri("", false, "A1408OpcPedCondPago", StringUtil.Str( (decimal)(A1408OpcPedCondPago), 1, 0));
            A1410OpcPedLista = T000R4_A1410OpcPedLista[0];
            AssignAttri("", false, "A1410OpcPedLista", StringUtil.Str( (decimal)(A1410OpcPedLista), 1, 0));
            ZM0R27( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0R27( ) ;
      }

      protected void OnLoadActions0R27( )
      {
      }

      protected void CheckExtendedTable0R27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0R27( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R27( )
      {
         /* Using cursor T000R5 */
         pr_default.execute(3, new Object[] {A347OpcId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000R3 */
         pr_default.execute(1, new Object[] {A347OpcId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R27( 1) ;
            RcdFound27 = 1;
            A347OpcId = T000R3_A347OpcId[0];
            AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
            A1419OpcStk = T000R3_A1419OpcStk[0];
            AssignAttri("", false, "A1419OpcStk", StringUtil.Str( (decimal)(A1419OpcStk), 1, 0));
            A1402OpcIVA = T000R3_A1402OpcIVA[0];
            AssignAttri("", false, "A1402OpcIVA", StringUtil.LTrimStr( A1402OpcIVA, 10, 2));
            A1397OpcEmp = T000R3_A1397OpcEmp[0];
            AssignAttri("", false, "A1397OpcEmp", A1397OpcEmp);
            A1390OpcAutOcom = T000R3_A1390OpcAutOcom[0];
            AssignAttri("", false, "A1390OpcAutOcom", StringUtil.Str( (decimal)(A1390OpcAutOcom), 1, 0));
            A1389OpcAutCompras = T000R3_A1389OpcAutCompras[0];
            AssignAttri("", false, "A1389OpcAutCompras", StringUtil.Str( (decimal)(A1389OpcAutCompras), 1, 0));
            A1406OpcPedAut = T000R3_A1406OpcPedAut[0];
            AssignAttri("", false, "A1406OpcPedAut", StringUtil.Str( (decimal)(A1406OpcPedAut), 1, 0));
            A1421OpcVersion = T000R3_A1421OpcVersion[0];
            AssignAttri("", false, "A1421OpcVersion", A1421OpcVersion);
            A1417OpcRetencion = T000R3_A1417OpcRetencion[0];
            AssignAttri("", false, "A1417OpcRetencion", StringUtil.LTrimStr( A1417OpcRetencion, 10, 2));
            A1415OpcPercepcion = T000R3_A1415OpcPercepcion[0];
            AssignAttri("", false, "A1415OpcPercepcion", StringUtil.LTrimStr( A1415OpcPercepcion, 10, 2));
            A1416OpcPercepcionAgentes = T000R3_A1416OpcPercepcionAgentes[0];
            AssignAttri("", false, "A1416OpcPercepcionAgentes", StringUtil.LTrimStr( A1416OpcPercepcionAgentes, 10, 2));
            A1407OpcPedAutNum = T000R3_A1407OpcPedAutNum[0];
            AssignAttri("", false, "A1407OpcPedAutNum", StringUtil.LTrimStr( (decimal)(A1407OpcPedAutNum), 2, 0));
            A1405OpcListaPrecios = T000R3_A1405OpcListaPrecios[0];
            AssignAttri("", false, "A1405OpcListaPrecios", StringUtil.Str( (decimal)(A1405OpcListaPrecios), 1, 0));
            A1399OpcEntrada = T000R3_A1399OpcEntrada[0];
            AssignAttri("", false, "A1399OpcEntrada", StringUtil.Str( (decimal)(A1399OpcEntrada), 1, 0));
            A1420OpcStkComp = T000R3_A1420OpcStkComp[0];
            AssignAttri("", false, "A1420OpcStkComp", StringUtil.Str( (decimal)(A1420OpcStkComp), 1, 0));
            A1392OpcEMailHost = T000R3_A1392OpcEMailHost[0];
            AssignAttri("", false, "A1392OpcEMailHost", A1392OpcEMailHost);
            A1395OpcEMailSalida = T000R3_A1395OpcEMailSalida[0];
            AssignAttri("", false, "A1395OpcEMailSalida", A1395OpcEMailSalida);
            A1396OpcEMailUsu = T000R3_A1396OpcEMailUsu[0];
            AssignAttri("", false, "A1396OpcEMailUsu", A1396OpcEMailUsu);
            A1393OpcEMailPass = T000R3_A1393OpcEMailPass[0];
            AssignAttri("", false, "A1393OpcEMailPass", A1393OpcEMailPass);
            A1398OpcEmpAgente = T000R3_A1398OpcEmpAgente[0];
            AssignAttri("", false, "A1398OpcEmpAgente", StringUtil.Str( (decimal)(A1398OpcEmpAgente), 1, 0));
            A1394OpcEMailPort = T000R3_A1394OpcEMailPort[0];
            AssignAttri("", false, "A1394OpcEMailPort", StringUtil.LTrimStr( (decimal)(A1394OpcEMailPort), 4, 0));
            A1391OpcCosIngreso = T000R3_A1391OpcCosIngreso[0];
            AssignAttri("", false, "A1391OpcCosIngreso", StringUtil.Str( (decimal)(A1391OpcCosIngreso), 1, 0));
            A1400OpcFE = T000R3_A1400OpcFE[0];
            AssignAttri("", false, "A1400OpcFE", StringUtil.Str( (decimal)(A1400OpcFE), 1, 0));
            A1401OpcFERetencion = T000R3_A1401OpcFERetencion[0];
            AssignAttri("", false, "A1401OpcFERetencion", StringUtil.Str( (decimal)(A1401OpcFERetencion), 1, 0));
            A1403OpcLetrasGirador = T000R3_A1403OpcLetrasGirador[0];
            AssignAttri("", false, "A1403OpcLetrasGirador", A1403OpcLetrasGirador);
            A1404OpcLetrasLugar = T000R3_A1404OpcLetrasLugar[0];
            AssignAttri("", false, "A1404OpcLetrasLugar", A1404OpcLetrasLugar);
            A2260OpcAutOComNum = T000R3_A2260OpcAutOComNum[0];
            AssignAttri("", false, "A2260OpcAutOComNum", StringUtil.LTrimStr( (decimal)(A2260OpcAutOComNum), 4, 0));
            A1418OpcServerFE = T000R3_A1418OpcServerFE[0];
            AssignAttri("", false, "A1418OpcServerFE", StringUtil.Str( (decimal)(A1418OpcServerFE), 1, 0));
            A2261OpcCuentaDetraccion = T000R3_A2261OpcCuentaDetraccion[0];
            AssignAttri("", false, "A2261OpcCuentaDetraccion", StringUtil.LTrimStr( (decimal)(A2261OpcCuentaDetraccion), 4, 0));
            A1412OpcPedPrecios = T000R3_A1412OpcPedPrecios[0];
            AssignAttri("", false, "A1412OpcPedPrecios", StringUtil.Str( (decimal)(A1412OpcPedPrecios), 1, 0));
            A1409OpcPedDescuento = T000R3_A1409OpcPedDescuento[0];
            AssignAttri("", false, "A1409OpcPedDescuento", StringUtil.Str( (decimal)(A1409OpcPedDescuento), 1, 0));
            A1413OpcPedStock = T000R3_A1413OpcPedStock[0];
            AssignAttri("", false, "A1413OpcPedStock", StringUtil.Str( (decimal)(A1413OpcPedStock), 1, 0));
            A1414OpcPedVendedor = T000R3_A1414OpcPedVendedor[0];
            AssignAttri("", false, "A1414OpcPedVendedor", StringUtil.Str( (decimal)(A1414OpcPedVendedor), 1, 0));
            A1411OpcPedMonCod = T000R3_A1411OpcPedMonCod[0];
            AssignAttri("", false, "A1411OpcPedMonCod", StringUtil.LTrimStr( (decimal)(A1411OpcPedMonCod), 6, 0));
            A1408OpcPedCondPago = T000R3_A1408OpcPedCondPago[0];
            AssignAttri("", false, "A1408OpcPedCondPago", StringUtil.Str( (decimal)(A1408OpcPedCondPago), 1, 0));
            A1410OpcPedLista = T000R3_A1410OpcPedLista[0];
            AssignAttri("", false, "A1410OpcPedLista", StringUtil.Str( (decimal)(A1410OpcPedLista), 1, 0));
            Z347OpcId = A347OpcId;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0R27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0R27( ) ;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0R27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R27( ) ;
         if ( RcdFound27 == 0 )
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
         RcdFound27 = 0;
         /* Using cursor T000R6 */
         pr_default.execute(4, new Object[] {A347OpcId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000R6_A347OpcId[0] < A347OpcId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000R6_A347OpcId[0] > A347OpcId ) ) )
            {
               A347OpcId = T000R6_A347OpcId[0];
               AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound27 = 0;
         /* Using cursor T000R7 */
         pr_default.execute(5, new Object[] {A347OpcId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000R7_A347OpcId[0] > A347OpcId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000R7_A347OpcId[0] < A347OpcId ) ) )
            {
               A347OpcId = T000R7_A347OpcId[0];
               AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0R27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOpcId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0R27( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A347OpcId != Z347OpcId )
               {
                  A347OpcId = Z347OpcId;
                  AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "OPCID");
                  AnyError = 1;
                  GX_FocusControl = edtOpcId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOpcId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0R27( ) ;
                  GX_FocusControl = edtOpcId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A347OpcId != Z347OpcId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtOpcId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0R27( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OPCID");
                     AnyError = 1;
                     GX_FocusControl = edtOpcId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtOpcId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0R27( ) ;
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
         if ( A347OpcId != Z347OpcId )
         {
            A347OpcId = Z347OpcId;
            AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "OPCID");
            AnyError = 1;
            GX_FocusControl = edtOpcId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOpcId_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "OPCID");
            AnyError = 1;
            GX_FocusControl = edtOpcId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtOpcStk_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0R27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOpcStk_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R27( ) ;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOpcStk_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOpcStk_Internalname;
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
         ScanStart0R27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound27 != 0 )
            {
               ScanNext0R27( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOpcStk_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R27( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0R27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000R2 */
            pr_default.execute(0, new Object[] {A347OpcId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGOPCIONES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1419OpcStk != T000R2_A1419OpcStk[0] ) || ( Z1402OpcIVA != T000R2_A1402OpcIVA[0] ) || ( StringUtil.StrCmp(Z1397OpcEmp, T000R2_A1397OpcEmp[0]) != 0 ) || ( Z1390OpcAutOcom != T000R2_A1390OpcAutOcom[0] ) || ( Z1389OpcAutCompras != T000R2_A1389OpcAutCompras[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1406OpcPedAut != T000R2_A1406OpcPedAut[0] ) || ( StringUtil.StrCmp(Z1421OpcVersion, T000R2_A1421OpcVersion[0]) != 0 ) || ( Z1417OpcRetencion != T000R2_A1417OpcRetencion[0] ) || ( Z1415OpcPercepcion != T000R2_A1415OpcPercepcion[0] ) || ( Z1416OpcPercepcionAgentes != T000R2_A1416OpcPercepcionAgentes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1407OpcPedAutNum != T000R2_A1407OpcPedAutNum[0] ) || ( Z1405OpcListaPrecios != T000R2_A1405OpcListaPrecios[0] ) || ( Z1399OpcEntrada != T000R2_A1399OpcEntrada[0] ) || ( Z1420OpcStkComp != T000R2_A1420OpcStkComp[0] ) || ( StringUtil.StrCmp(Z1392OpcEMailHost, T000R2_A1392OpcEMailHost[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1395OpcEMailSalida, T000R2_A1395OpcEMailSalida[0]) != 0 ) || ( StringUtil.StrCmp(Z1396OpcEMailUsu, T000R2_A1396OpcEMailUsu[0]) != 0 ) || ( StringUtil.StrCmp(Z1393OpcEMailPass, T000R2_A1393OpcEMailPass[0]) != 0 ) || ( Z1398OpcEmpAgente != T000R2_A1398OpcEmpAgente[0] ) || ( Z1394OpcEMailPort != T000R2_A1394OpcEMailPort[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1391OpcCosIngreso != T000R2_A1391OpcCosIngreso[0] ) || ( Z1400OpcFE != T000R2_A1400OpcFE[0] ) || ( Z1401OpcFERetencion != T000R2_A1401OpcFERetencion[0] ) || ( StringUtil.StrCmp(Z1403OpcLetrasGirador, T000R2_A1403OpcLetrasGirador[0]) != 0 ) || ( StringUtil.StrCmp(Z1404OpcLetrasLugar, T000R2_A1404OpcLetrasLugar[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2260OpcAutOComNum != T000R2_A2260OpcAutOComNum[0] ) || ( Z1418OpcServerFE != T000R2_A1418OpcServerFE[0] ) || ( Z2261OpcCuentaDetraccion != T000R2_A2261OpcCuentaDetraccion[0] ) || ( Z1412OpcPedPrecios != T000R2_A1412OpcPedPrecios[0] ) || ( Z1409OpcPedDescuento != T000R2_A1409OpcPedDescuento[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1413OpcPedStock != T000R2_A1413OpcPedStock[0] ) || ( Z1414OpcPedVendedor != T000R2_A1414OpcPedVendedor[0] ) || ( Z1411OpcPedMonCod != T000R2_A1411OpcPedMonCod[0] ) || ( Z1408OpcPedCondPago != T000R2_A1408OpcPedCondPago[0] ) || ( Z1410OpcPedLista != T000R2_A1410OpcPedLista[0] ) )
            {
               if ( Z1419OpcStk != T000R2_A1419OpcStk[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcStk");
                  GXUtil.WriteLogRaw("Old: ",Z1419OpcStk);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1419OpcStk[0]);
               }
               if ( Z1402OpcIVA != T000R2_A1402OpcIVA[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1402OpcIVA);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1402OpcIVA[0]);
               }
               if ( StringUtil.StrCmp(Z1397OpcEmp, T000R2_A1397OpcEmp[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEmp");
                  GXUtil.WriteLogRaw("Old: ",Z1397OpcEmp);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1397OpcEmp[0]);
               }
               if ( Z1390OpcAutOcom != T000R2_A1390OpcAutOcom[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcAutOcom");
                  GXUtil.WriteLogRaw("Old: ",Z1390OpcAutOcom);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1390OpcAutOcom[0]);
               }
               if ( Z1389OpcAutCompras != T000R2_A1389OpcAutCompras[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcAutCompras");
                  GXUtil.WriteLogRaw("Old: ",Z1389OpcAutCompras);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1389OpcAutCompras[0]);
               }
               if ( Z1406OpcPedAut != T000R2_A1406OpcPedAut[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedAut");
                  GXUtil.WriteLogRaw("Old: ",Z1406OpcPedAut);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1406OpcPedAut[0]);
               }
               if ( StringUtil.StrCmp(Z1421OpcVersion, T000R2_A1421OpcVersion[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcVersion");
                  GXUtil.WriteLogRaw("Old: ",Z1421OpcVersion);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1421OpcVersion[0]);
               }
               if ( Z1417OpcRetencion != T000R2_A1417OpcRetencion[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcRetencion");
                  GXUtil.WriteLogRaw("Old: ",Z1417OpcRetencion);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1417OpcRetencion[0]);
               }
               if ( Z1415OpcPercepcion != T000R2_A1415OpcPercepcion[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPercepcion");
                  GXUtil.WriteLogRaw("Old: ",Z1415OpcPercepcion);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1415OpcPercepcion[0]);
               }
               if ( Z1416OpcPercepcionAgentes != T000R2_A1416OpcPercepcionAgentes[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPercepcionAgentes");
                  GXUtil.WriteLogRaw("Old: ",Z1416OpcPercepcionAgentes);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1416OpcPercepcionAgentes[0]);
               }
               if ( Z1407OpcPedAutNum != T000R2_A1407OpcPedAutNum[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedAutNum");
                  GXUtil.WriteLogRaw("Old: ",Z1407OpcPedAutNum);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1407OpcPedAutNum[0]);
               }
               if ( Z1405OpcListaPrecios != T000R2_A1405OpcListaPrecios[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcListaPrecios");
                  GXUtil.WriteLogRaw("Old: ",Z1405OpcListaPrecios);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1405OpcListaPrecios[0]);
               }
               if ( Z1399OpcEntrada != T000R2_A1399OpcEntrada[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEntrada");
                  GXUtil.WriteLogRaw("Old: ",Z1399OpcEntrada);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1399OpcEntrada[0]);
               }
               if ( Z1420OpcStkComp != T000R2_A1420OpcStkComp[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcStkComp");
                  GXUtil.WriteLogRaw("Old: ",Z1420OpcStkComp);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1420OpcStkComp[0]);
               }
               if ( StringUtil.StrCmp(Z1392OpcEMailHost, T000R2_A1392OpcEMailHost[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEMailHost");
                  GXUtil.WriteLogRaw("Old: ",Z1392OpcEMailHost);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1392OpcEMailHost[0]);
               }
               if ( StringUtil.StrCmp(Z1395OpcEMailSalida, T000R2_A1395OpcEMailSalida[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEMailSalida");
                  GXUtil.WriteLogRaw("Old: ",Z1395OpcEMailSalida);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1395OpcEMailSalida[0]);
               }
               if ( StringUtil.StrCmp(Z1396OpcEMailUsu, T000R2_A1396OpcEMailUsu[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEMailUsu");
                  GXUtil.WriteLogRaw("Old: ",Z1396OpcEMailUsu);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1396OpcEMailUsu[0]);
               }
               if ( StringUtil.StrCmp(Z1393OpcEMailPass, T000R2_A1393OpcEMailPass[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEMailPass");
                  GXUtil.WriteLogRaw("Old: ",Z1393OpcEMailPass);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1393OpcEMailPass[0]);
               }
               if ( Z1398OpcEmpAgente != T000R2_A1398OpcEmpAgente[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEmpAgente");
                  GXUtil.WriteLogRaw("Old: ",Z1398OpcEmpAgente);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1398OpcEmpAgente[0]);
               }
               if ( Z1394OpcEMailPort != T000R2_A1394OpcEMailPort[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcEMailPort");
                  GXUtil.WriteLogRaw("Old: ",Z1394OpcEMailPort);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1394OpcEMailPort[0]);
               }
               if ( Z1391OpcCosIngreso != T000R2_A1391OpcCosIngreso[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcCosIngreso");
                  GXUtil.WriteLogRaw("Old: ",Z1391OpcCosIngreso);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1391OpcCosIngreso[0]);
               }
               if ( Z1400OpcFE != T000R2_A1400OpcFE[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcFE");
                  GXUtil.WriteLogRaw("Old: ",Z1400OpcFE);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1400OpcFE[0]);
               }
               if ( Z1401OpcFERetencion != T000R2_A1401OpcFERetencion[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcFERetencion");
                  GXUtil.WriteLogRaw("Old: ",Z1401OpcFERetencion);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1401OpcFERetencion[0]);
               }
               if ( StringUtil.StrCmp(Z1403OpcLetrasGirador, T000R2_A1403OpcLetrasGirador[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcLetrasGirador");
                  GXUtil.WriteLogRaw("Old: ",Z1403OpcLetrasGirador);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1403OpcLetrasGirador[0]);
               }
               if ( StringUtil.StrCmp(Z1404OpcLetrasLugar, T000R2_A1404OpcLetrasLugar[0]) != 0 )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcLetrasLugar");
                  GXUtil.WriteLogRaw("Old: ",Z1404OpcLetrasLugar);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1404OpcLetrasLugar[0]);
               }
               if ( Z2260OpcAutOComNum != T000R2_A2260OpcAutOComNum[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcAutOComNum");
                  GXUtil.WriteLogRaw("Old: ",Z2260OpcAutOComNum);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A2260OpcAutOComNum[0]);
               }
               if ( Z1418OpcServerFE != T000R2_A1418OpcServerFE[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcServerFE");
                  GXUtil.WriteLogRaw("Old: ",Z1418OpcServerFE);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1418OpcServerFE[0]);
               }
               if ( Z2261OpcCuentaDetraccion != T000R2_A2261OpcCuentaDetraccion[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcCuentaDetraccion");
                  GXUtil.WriteLogRaw("Old: ",Z2261OpcCuentaDetraccion);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A2261OpcCuentaDetraccion[0]);
               }
               if ( Z1412OpcPedPrecios != T000R2_A1412OpcPedPrecios[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedPrecios");
                  GXUtil.WriteLogRaw("Old: ",Z1412OpcPedPrecios);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1412OpcPedPrecios[0]);
               }
               if ( Z1409OpcPedDescuento != T000R2_A1409OpcPedDescuento[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedDescuento");
                  GXUtil.WriteLogRaw("Old: ",Z1409OpcPedDescuento);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1409OpcPedDescuento[0]);
               }
               if ( Z1413OpcPedStock != T000R2_A1413OpcPedStock[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedStock");
                  GXUtil.WriteLogRaw("Old: ",Z1413OpcPedStock);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1413OpcPedStock[0]);
               }
               if ( Z1414OpcPedVendedor != T000R2_A1414OpcPedVendedor[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedVendedor");
                  GXUtil.WriteLogRaw("Old: ",Z1414OpcPedVendedor);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1414OpcPedVendedor[0]);
               }
               if ( Z1411OpcPedMonCod != T000R2_A1411OpcPedMonCod[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z1411OpcPedMonCod);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1411OpcPedMonCod[0]);
               }
               if ( Z1408OpcPedCondPago != T000R2_A1408OpcPedCondPago[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedCondPago");
                  GXUtil.WriteLogRaw("Old: ",Z1408OpcPedCondPago);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1408OpcPedCondPago[0]);
               }
               if ( Z1410OpcPedLista != T000R2_A1410OpcPedLista[0] )
               {
                  GXUtil.WriteLog("sgopciones:[seudo value changed for attri]"+"OpcPedLista");
                  GXUtil.WriteLogRaw("Old: ",Z1410OpcPedLista);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A1410OpcPedLista[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGOPCIONES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R27( )
      {
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R27( 0) ;
            CheckOptimisticConcurrency0R27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R8 */
                     pr_default.execute(6, new Object[] {A347OpcId, A1419OpcStk, A1402OpcIVA, A1397OpcEmp, A1390OpcAutOcom, A1389OpcAutCompras, A1406OpcPedAut, A1421OpcVersion, A1417OpcRetencion, A1415OpcPercepcion, A1416OpcPercepcionAgentes, A1407OpcPedAutNum, A1405OpcListaPrecios, A1399OpcEntrada, A1420OpcStkComp, A1392OpcEMailHost, A1395OpcEMailSalida, A1396OpcEMailUsu, A1393OpcEMailPass, A1398OpcEmpAgente, A1394OpcEMailPort, A1391OpcCosIngreso, A1400OpcFE, A1401OpcFERetencion, A1403OpcLetrasGirador, A1404OpcLetrasLugar, A2260OpcAutOComNum, A1418OpcServerFE, A2261OpcCuentaDetraccion, A1412OpcPedPrecios, A1409OpcPedDescuento, A1413OpcPedStock, A1414OpcPedVendedor, A1411OpcPedMonCod, A1408OpcPedCondPago, A1410OpcPedLista});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGOPCIONES");
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
                           ResetCaption0R0( ) ;
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
               Load0R27( ) ;
            }
            EndLevel0R27( ) ;
         }
         CloseExtendedTableCursors0R27( ) ;
      }

      protected void Update0R27( )
      {
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R9 */
                     pr_default.execute(7, new Object[] {A1419OpcStk, A1402OpcIVA, A1397OpcEmp, A1390OpcAutOcom, A1389OpcAutCompras, A1406OpcPedAut, A1421OpcVersion, A1417OpcRetencion, A1415OpcPercepcion, A1416OpcPercepcionAgentes, A1407OpcPedAutNum, A1405OpcListaPrecios, A1399OpcEntrada, A1420OpcStkComp, A1392OpcEMailHost, A1395OpcEMailSalida, A1396OpcEMailUsu, A1393OpcEMailPass, A1398OpcEmpAgente, A1394OpcEMailPort, A1391OpcCosIngreso, A1400OpcFE, A1401OpcFERetencion, A1403OpcLetrasGirador, A1404OpcLetrasLugar, A2260OpcAutOComNum, A1418OpcServerFE, A2261OpcCuentaDetraccion, A1412OpcPedPrecios, A1409OpcPedDescuento, A1413OpcPedStock, A1414OpcPedVendedor, A1411OpcPedMonCod, A1408OpcPedCondPago, A1410OpcPedLista, A347OpcId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGOPCIONES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGOPCIONES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0R0( ) ;
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
            EndLevel0R27( ) ;
         }
         CloseExtendedTableCursors0R27( ) ;
      }

      protected void DeferredUpdate0R27( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R27( ) ;
            AfterConfirm0R27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000R10 */
                  pr_default.execute(8, new Object[] {A347OpcId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGOPCIONES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound27 == 0 )
                        {
                           InitAll0R27( ) ;
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
                        ResetCaption0R0( ) ;
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0R27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0R27( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0R27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgopciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgopciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0R27( )
      {
         /* Using cursor T000R11 */
         pr_default.execute(9);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound27 = 1;
            A347OpcId = T000R11_A347OpcId[0];
            AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0R27( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound27 = 1;
            A347OpcId = T000R11_A347OpcId[0];
            AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
         }
      }

      protected void ScanEnd0R27( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0R27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0R27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R27( )
      {
         edtOpcId_Enabled = 0;
         AssignProp("", false, edtOpcId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcId_Enabled), 5, 0), true);
         edtOpcStk_Enabled = 0;
         AssignProp("", false, edtOpcStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcStk_Enabled), 5, 0), true);
         edtOpcIVA_Enabled = 0;
         AssignProp("", false, edtOpcIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcIVA_Enabled), 5, 0), true);
         edtOpcEmp_Enabled = 0;
         AssignProp("", false, edtOpcEmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEmp_Enabled), 5, 0), true);
         edtOpcAutOcom_Enabled = 0;
         AssignProp("", false, edtOpcAutOcom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcAutOcom_Enabled), 5, 0), true);
         edtOpcAutCompras_Enabled = 0;
         AssignProp("", false, edtOpcAutCompras_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcAutCompras_Enabled), 5, 0), true);
         edtOpcPedAut_Enabled = 0;
         AssignProp("", false, edtOpcPedAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedAut_Enabled), 5, 0), true);
         edtOpcVersion_Enabled = 0;
         AssignProp("", false, edtOpcVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcVersion_Enabled), 5, 0), true);
         edtOpcRetencion_Enabled = 0;
         AssignProp("", false, edtOpcRetencion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcRetencion_Enabled), 5, 0), true);
         edtOpcPercepcion_Enabled = 0;
         AssignProp("", false, edtOpcPercepcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPercepcion_Enabled), 5, 0), true);
         edtOpcPercepcionAgentes_Enabled = 0;
         AssignProp("", false, edtOpcPercepcionAgentes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPercepcionAgentes_Enabled), 5, 0), true);
         edtOpcPedAutNum_Enabled = 0;
         AssignProp("", false, edtOpcPedAutNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedAutNum_Enabled), 5, 0), true);
         edtOpcListaPrecios_Enabled = 0;
         AssignProp("", false, edtOpcListaPrecios_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcListaPrecios_Enabled), 5, 0), true);
         edtOpcEntrada_Enabled = 0;
         AssignProp("", false, edtOpcEntrada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEntrada_Enabled), 5, 0), true);
         edtOpcStkComp_Enabled = 0;
         AssignProp("", false, edtOpcStkComp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcStkComp_Enabled), 5, 0), true);
         edtOpcEMailHost_Enabled = 0;
         AssignProp("", false, edtOpcEMailHost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEMailHost_Enabled), 5, 0), true);
         edtOpcEMailSalida_Enabled = 0;
         AssignProp("", false, edtOpcEMailSalida_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEMailSalida_Enabled), 5, 0), true);
         edtOpcEMailUsu_Enabled = 0;
         AssignProp("", false, edtOpcEMailUsu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEMailUsu_Enabled), 5, 0), true);
         edtOpcEMailPass_Enabled = 0;
         AssignProp("", false, edtOpcEMailPass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEMailPass_Enabled), 5, 0), true);
         edtOpcEmpAgente_Enabled = 0;
         AssignProp("", false, edtOpcEmpAgente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEmpAgente_Enabled), 5, 0), true);
         edtOpcEMailPort_Enabled = 0;
         AssignProp("", false, edtOpcEMailPort_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcEMailPort_Enabled), 5, 0), true);
         edtOpcCosIngreso_Enabled = 0;
         AssignProp("", false, edtOpcCosIngreso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcCosIngreso_Enabled), 5, 0), true);
         edtOpcFE_Enabled = 0;
         AssignProp("", false, edtOpcFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcFE_Enabled), 5, 0), true);
         edtOpcFERetencion_Enabled = 0;
         AssignProp("", false, edtOpcFERetencion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcFERetencion_Enabled), 5, 0), true);
         edtOpcLetrasGirador_Enabled = 0;
         AssignProp("", false, edtOpcLetrasGirador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcLetrasGirador_Enabled), 5, 0), true);
         edtOpcLetrasLugar_Enabled = 0;
         AssignProp("", false, edtOpcLetrasLugar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcLetrasLugar_Enabled), 5, 0), true);
         edtOpcAutOComNum_Enabled = 0;
         AssignProp("", false, edtOpcAutOComNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcAutOComNum_Enabled), 5, 0), true);
         edtOpcServerFE_Enabled = 0;
         AssignProp("", false, edtOpcServerFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcServerFE_Enabled), 5, 0), true);
         edtOpcCuentaDetraccion_Enabled = 0;
         AssignProp("", false, edtOpcCuentaDetraccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcCuentaDetraccion_Enabled), 5, 0), true);
         edtOpcPedPrecios_Enabled = 0;
         AssignProp("", false, edtOpcPedPrecios_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedPrecios_Enabled), 5, 0), true);
         edtOpcPedDescuento_Enabled = 0;
         AssignProp("", false, edtOpcPedDescuento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedDescuento_Enabled), 5, 0), true);
         edtOpcPedStock_Enabled = 0;
         AssignProp("", false, edtOpcPedStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedStock_Enabled), 5, 0), true);
         edtOpcPedVendedor_Enabled = 0;
         AssignProp("", false, edtOpcPedVendedor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedVendedor_Enabled), 5, 0), true);
         edtOpcPedMonCod_Enabled = 0;
         AssignProp("", false, edtOpcPedMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedMonCod_Enabled), 5, 0), true);
         edtOpcPedCondPago_Enabled = 0;
         AssignProp("", false, edtOpcPedCondPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedCondPago_Enabled), 5, 0), true);
         edtOpcPedLista_Enabled = 0;
         AssignProp("", false, edtOpcPedLista_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOpcPedLista_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0R27( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0R0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443124", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgopciones.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z347OpcId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z347OpcId), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1419OpcStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1419OpcStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1402OpcIVA", StringUtil.LTrim( StringUtil.NToC( Z1402OpcIVA, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1397OpcEmp", StringUtil.RTrim( Z1397OpcEmp));
         GxWebStd.gx_hidden_field( context, "Z1390OpcAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1390OpcAutOcom), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1389OpcAutCompras", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1389OpcAutCompras), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1406OpcPedAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1406OpcPedAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1421OpcVersion", StringUtil.RTrim( Z1421OpcVersion));
         GxWebStd.gx_hidden_field( context, "Z1417OpcRetencion", StringUtil.LTrim( StringUtil.NToC( Z1417OpcRetencion, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1415OpcPercepcion", StringUtil.LTrim( StringUtil.NToC( Z1415OpcPercepcion, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1416OpcPercepcionAgentes", StringUtil.LTrim( StringUtil.NToC( Z1416OpcPercepcionAgentes, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1407OpcPedAutNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1407OpcPedAutNum), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1405OpcListaPrecios", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1405OpcListaPrecios), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1399OpcEntrada", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1399OpcEntrada), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1420OpcStkComp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1420OpcStkComp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1392OpcEMailHost", StringUtil.RTrim( Z1392OpcEMailHost));
         GxWebStd.gx_hidden_field( context, "Z1395OpcEMailSalida", StringUtil.RTrim( Z1395OpcEMailSalida));
         GxWebStd.gx_hidden_field( context, "Z1396OpcEMailUsu", StringUtil.RTrim( Z1396OpcEMailUsu));
         GxWebStd.gx_hidden_field( context, "Z1393OpcEMailPass", StringUtil.RTrim( Z1393OpcEMailPass));
         GxWebStd.gx_hidden_field( context, "Z1398OpcEmpAgente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1398OpcEmpAgente), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1394OpcEMailPort", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1394OpcEMailPort), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1391OpcCosIngreso", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1391OpcCosIngreso), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1400OpcFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1400OpcFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1401OpcFERetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1401OpcFERetencion), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1403OpcLetrasGirador", Z1403OpcLetrasGirador);
         GxWebStd.gx_hidden_field( context, "Z1404OpcLetrasLugar", Z1404OpcLetrasLugar);
         GxWebStd.gx_hidden_field( context, "Z2260OpcAutOComNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2260OpcAutOComNum), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1418OpcServerFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1418OpcServerFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2261OpcCuentaDetraccion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2261OpcCuentaDetraccion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1412OpcPedPrecios", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1412OpcPedPrecios), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1409OpcPedDescuento", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1409OpcPedDescuento), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1413OpcPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1413OpcPedStock), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1414OpcPedVendedor", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1414OpcPedVendedor), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1411OpcPedMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1411OpcPedMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1408OpcPedCondPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1408OpcPedCondPago), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1410OpcPedLista", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1410OpcPedLista), 1, 0, ".", "")));
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
         return formatLink("sgopciones.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGOPCIONES" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGOPCIONES" ;
      }

      protected void InitializeNonKey0R27( )
      {
         A1419OpcStk = 0;
         AssignAttri("", false, "A1419OpcStk", StringUtil.Str( (decimal)(A1419OpcStk), 1, 0));
         A1402OpcIVA = 0;
         AssignAttri("", false, "A1402OpcIVA", StringUtil.LTrimStr( A1402OpcIVA, 10, 2));
         A1397OpcEmp = "";
         AssignAttri("", false, "A1397OpcEmp", A1397OpcEmp);
         A1390OpcAutOcom = 0;
         AssignAttri("", false, "A1390OpcAutOcom", StringUtil.Str( (decimal)(A1390OpcAutOcom), 1, 0));
         A1389OpcAutCompras = 0;
         AssignAttri("", false, "A1389OpcAutCompras", StringUtil.Str( (decimal)(A1389OpcAutCompras), 1, 0));
         A1406OpcPedAut = 0;
         AssignAttri("", false, "A1406OpcPedAut", StringUtil.Str( (decimal)(A1406OpcPedAut), 1, 0));
         A1421OpcVersion = "";
         AssignAttri("", false, "A1421OpcVersion", A1421OpcVersion);
         A1417OpcRetencion = 0;
         AssignAttri("", false, "A1417OpcRetencion", StringUtil.LTrimStr( A1417OpcRetencion, 10, 2));
         A1415OpcPercepcion = 0;
         AssignAttri("", false, "A1415OpcPercepcion", StringUtil.LTrimStr( A1415OpcPercepcion, 10, 2));
         A1416OpcPercepcionAgentes = 0;
         AssignAttri("", false, "A1416OpcPercepcionAgentes", StringUtil.LTrimStr( A1416OpcPercepcionAgentes, 10, 2));
         A1407OpcPedAutNum = 0;
         AssignAttri("", false, "A1407OpcPedAutNum", StringUtil.LTrimStr( (decimal)(A1407OpcPedAutNum), 2, 0));
         A1405OpcListaPrecios = 0;
         AssignAttri("", false, "A1405OpcListaPrecios", StringUtil.Str( (decimal)(A1405OpcListaPrecios), 1, 0));
         A1399OpcEntrada = 0;
         AssignAttri("", false, "A1399OpcEntrada", StringUtil.Str( (decimal)(A1399OpcEntrada), 1, 0));
         A1420OpcStkComp = 0;
         AssignAttri("", false, "A1420OpcStkComp", StringUtil.Str( (decimal)(A1420OpcStkComp), 1, 0));
         A1392OpcEMailHost = "";
         AssignAttri("", false, "A1392OpcEMailHost", A1392OpcEMailHost);
         A1395OpcEMailSalida = "";
         AssignAttri("", false, "A1395OpcEMailSalida", A1395OpcEMailSalida);
         A1396OpcEMailUsu = "";
         AssignAttri("", false, "A1396OpcEMailUsu", A1396OpcEMailUsu);
         A1393OpcEMailPass = "";
         AssignAttri("", false, "A1393OpcEMailPass", A1393OpcEMailPass);
         A1398OpcEmpAgente = 0;
         AssignAttri("", false, "A1398OpcEmpAgente", StringUtil.Str( (decimal)(A1398OpcEmpAgente), 1, 0));
         A1394OpcEMailPort = 0;
         AssignAttri("", false, "A1394OpcEMailPort", StringUtil.LTrimStr( (decimal)(A1394OpcEMailPort), 4, 0));
         A1391OpcCosIngreso = 0;
         AssignAttri("", false, "A1391OpcCosIngreso", StringUtil.Str( (decimal)(A1391OpcCosIngreso), 1, 0));
         A1400OpcFE = 0;
         AssignAttri("", false, "A1400OpcFE", StringUtil.Str( (decimal)(A1400OpcFE), 1, 0));
         A1401OpcFERetencion = 0;
         AssignAttri("", false, "A1401OpcFERetencion", StringUtil.Str( (decimal)(A1401OpcFERetencion), 1, 0));
         A1403OpcLetrasGirador = "";
         AssignAttri("", false, "A1403OpcLetrasGirador", A1403OpcLetrasGirador);
         A1404OpcLetrasLugar = "";
         AssignAttri("", false, "A1404OpcLetrasLugar", A1404OpcLetrasLugar);
         A2260OpcAutOComNum = 0;
         AssignAttri("", false, "A2260OpcAutOComNum", StringUtil.LTrimStr( (decimal)(A2260OpcAutOComNum), 4, 0));
         A1418OpcServerFE = 0;
         AssignAttri("", false, "A1418OpcServerFE", StringUtil.Str( (decimal)(A1418OpcServerFE), 1, 0));
         A2261OpcCuentaDetraccion = 0;
         AssignAttri("", false, "A2261OpcCuentaDetraccion", StringUtil.LTrimStr( (decimal)(A2261OpcCuentaDetraccion), 4, 0));
         A1412OpcPedPrecios = 0;
         AssignAttri("", false, "A1412OpcPedPrecios", StringUtil.Str( (decimal)(A1412OpcPedPrecios), 1, 0));
         A1409OpcPedDescuento = 0;
         AssignAttri("", false, "A1409OpcPedDescuento", StringUtil.Str( (decimal)(A1409OpcPedDescuento), 1, 0));
         A1413OpcPedStock = 0;
         AssignAttri("", false, "A1413OpcPedStock", StringUtil.Str( (decimal)(A1413OpcPedStock), 1, 0));
         A1414OpcPedVendedor = 0;
         AssignAttri("", false, "A1414OpcPedVendedor", StringUtil.Str( (decimal)(A1414OpcPedVendedor), 1, 0));
         A1411OpcPedMonCod = 0;
         AssignAttri("", false, "A1411OpcPedMonCod", StringUtil.LTrimStr( (decimal)(A1411OpcPedMonCod), 6, 0));
         A1408OpcPedCondPago = 0;
         AssignAttri("", false, "A1408OpcPedCondPago", StringUtil.Str( (decimal)(A1408OpcPedCondPago), 1, 0));
         A1410OpcPedLista = 0;
         AssignAttri("", false, "A1410OpcPedLista", StringUtil.Str( (decimal)(A1410OpcPedLista), 1, 0));
         Z1419OpcStk = 0;
         Z1402OpcIVA = 0;
         Z1397OpcEmp = "";
         Z1390OpcAutOcom = 0;
         Z1389OpcAutCompras = 0;
         Z1406OpcPedAut = 0;
         Z1421OpcVersion = "";
         Z1417OpcRetencion = 0;
         Z1415OpcPercepcion = 0;
         Z1416OpcPercepcionAgentes = 0;
         Z1407OpcPedAutNum = 0;
         Z1405OpcListaPrecios = 0;
         Z1399OpcEntrada = 0;
         Z1420OpcStkComp = 0;
         Z1392OpcEMailHost = "";
         Z1395OpcEMailSalida = "";
         Z1396OpcEMailUsu = "";
         Z1393OpcEMailPass = "";
         Z1398OpcEmpAgente = 0;
         Z1394OpcEMailPort = 0;
         Z1391OpcCosIngreso = 0;
         Z1400OpcFE = 0;
         Z1401OpcFERetencion = 0;
         Z1403OpcLetrasGirador = "";
         Z1404OpcLetrasLugar = "";
         Z2260OpcAutOComNum = 0;
         Z1418OpcServerFE = 0;
         Z2261OpcCuentaDetraccion = 0;
         Z1412OpcPedPrecios = 0;
         Z1409OpcPedDescuento = 0;
         Z1413OpcPedStock = 0;
         Z1414OpcPedVendedor = 0;
         Z1411OpcPedMonCod = 0;
         Z1408OpcPedCondPago = 0;
         Z1410OpcPedLista = 0;
      }

      protected void InitAll0R27( )
      {
         A347OpcId = 0;
         AssignAttri("", false, "A347OpcId", StringUtil.Str( (decimal)(A347OpcId), 1, 0));
         InitializeNonKey0R27( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443155", true, true);
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
         context.AddJavascriptSource("sgopciones.js", "?202281811443155", false, true);
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
         edtOpcId_Internalname = "OPCID";
         edtOpcStk_Internalname = "OPCSTK";
         edtOpcIVA_Internalname = "OPCIVA";
         edtOpcEmp_Internalname = "OPCEMP";
         edtOpcAutOcom_Internalname = "OPCAUTOCOM";
         edtOpcAutCompras_Internalname = "OPCAUTCOMPRAS";
         edtOpcPedAut_Internalname = "OPCPEDAUT";
         edtOpcVersion_Internalname = "OPCVERSION";
         edtOpcRetencion_Internalname = "OPCRETENCION";
         edtOpcPercepcion_Internalname = "OPCPERCEPCION";
         edtOpcPercepcionAgentes_Internalname = "OPCPERCEPCIONAGENTES";
         edtOpcPedAutNum_Internalname = "OPCPEDAUTNUM";
         edtOpcListaPrecios_Internalname = "OPCLISTAPRECIOS";
         edtOpcEntrada_Internalname = "OPCENTRADA";
         edtOpcStkComp_Internalname = "OPCSTKCOMP";
         edtOpcEMailHost_Internalname = "OPCEMAILHOST";
         edtOpcEMailSalida_Internalname = "OPCEMAILSALIDA";
         edtOpcEMailUsu_Internalname = "OPCEMAILUSU";
         edtOpcEMailPass_Internalname = "OPCEMAILPASS";
         edtOpcEmpAgente_Internalname = "OPCEMPAGENTE";
         edtOpcEMailPort_Internalname = "OPCEMAILPORT";
         edtOpcCosIngreso_Internalname = "OPCCOSINGRESO";
         edtOpcFE_Internalname = "OPCFE";
         edtOpcFERetencion_Internalname = "OPCFERETENCION";
         edtOpcLetrasGirador_Internalname = "OPCLETRASGIRADOR";
         edtOpcLetrasLugar_Internalname = "OPCLETRASLUGAR";
         edtOpcAutOComNum_Internalname = "OPCAUTOCOMNUM";
         edtOpcServerFE_Internalname = "OPCSERVERFE";
         edtOpcCuentaDetraccion_Internalname = "OPCCUENTADETRACCION";
         edtOpcPedPrecios_Internalname = "OPCPEDPRECIOS";
         edtOpcPedDescuento_Internalname = "OPCPEDDESCUENTO";
         edtOpcPedStock_Internalname = "OPCPEDSTOCK";
         edtOpcPedVendedor_Internalname = "OPCPEDVENDEDOR";
         edtOpcPedMonCod_Internalname = "OPCPEDMONCOD";
         edtOpcPedCondPago_Internalname = "OPCPEDCONDPAGO";
         edtOpcPedLista_Internalname = "OPCPEDLISTA";
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
         Form.Caption = "SGOPCIONES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtOpcPedLista_Jsonclick = "";
         edtOpcPedLista_Enabled = 1;
         edtOpcPedCondPago_Jsonclick = "";
         edtOpcPedCondPago_Enabled = 1;
         edtOpcPedMonCod_Jsonclick = "";
         edtOpcPedMonCod_Enabled = 1;
         edtOpcPedVendedor_Jsonclick = "";
         edtOpcPedVendedor_Enabled = 1;
         edtOpcPedStock_Jsonclick = "";
         edtOpcPedStock_Enabled = 1;
         edtOpcPedDescuento_Jsonclick = "";
         edtOpcPedDescuento_Enabled = 1;
         edtOpcPedPrecios_Jsonclick = "";
         edtOpcPedPrecios_Enabled = 1;
         edtOpcCuentaDetraccion_Jsonclick = "";
         edtOpcCuentaDetraccion_Enabled = 1;
         edtOpcServerFE_Jsonclick = "";
         edtOpcServerFE_Enabled = 1;
         edtOpcAutOComNum_Jsonclick = "";
         edtOpcAutOComNum_Enabled = 1;
         edtOpcLetrasLugar_Jsonclick = "";
         edtOpcLetrasLugar_Enabled = 1;
         edtOpcLetrasGirador_Jsonclick = "";
         edtOpcLetrasGirador_Enabled = 1;
         edtOpcFERetencion_Jsonclick = "";
         edtOpcFERetencion_Enabled = 1;
         edtOpcFE_Jsonclick = "";
         edtOpcFE_Enabled = 1;
         edtOpcCosIngreso_Jsonclick = "";
         edtOpcCosIngreso_Enabled = 1;
         edtOpcEMailPort_Jsonclick = "";
         edtOpcEMailPort_Enabled = 1;
         edtOpcEmpAgente_Jsonclick = "";
         edtOpcEmpAgente_Enabled = 1;
         edtOpcEMailPass_Jsonclick = "";
         edtOpcEMailPass_Enabled = 1;
         edtOpcEMailUsu_Jsonclick = "";
         edtOpcEMailUsu_Enabled = 1;
         edtOpcEMailSalida_Jsonclick = "";
         edtOpcEMailSalida_Enabled = 1;
         edtOpcEMailHost_Jsonclick = "";
         edtOpcEMailHost_Enabled = 1;
         edtOpcStkComp_Jsonclick = "";
         edtOpcStkComp_Enabled = 1;
         edtOpcEntrada_Jsonclick = "";
         edtOpcEntrada_Enabled = 1;
         edtOpcListaPrecios_Jsonclick = "";
         edtOpcListaPrecios_Enabled = 1;
         edtOpcPedAutNum_Jsonclick = "";
         edtOpcPedAutNum_Enabled = 1;
         edtOpcPercepcionAgentes_Jsonclick = "";
         edtOpcPercepcionAgentes_Enabled = 1;
         edtOpcPercepcion_Jsonclick = "";
         edtOpcPercepcion_Enabled = 1;
         edtOpcRetencion_Jsonclick = "";
         edtOpcRetencion_Enabled = 1;
         edtOpcVersion_Jsonclick = "";
         edtOpcVersion_Enabled = 1;
         edtOpcPedAut_Jsonclick = "";
         edtOpcPedAut_Enabled = 1;
         edtOpcAutCompras_Jsonclick = "";
         edtOpcAutCompras_Enabled = 1;
         edtOpcAutOcom_Jsonclick = "";
         edtOpcAutOcom_Enabled = 1;
         edtOpcEmp_Jsonclick = "";
         edtOpcEmp_Enabled = 1;
         edtOpcIVA_Jsonclick = "";
         edtOpcIVA_Enabled = 1;
         edtOpcStk_Jsonclick = "";
         edtOpcStk_Enabled = 1;
         edtOpcId_Jsonclick = "";
         edtOpcId_Enabled = 1;
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
         GX_FocusControl = edtOpcStk_Internalname;
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

      public void Valid_Opcid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1419OpcStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1419OpcStk), 1, 0, ".", "")));
         AssignAttri("", false, "A1402OpcIVA", StringUtil.LTrim( StringUtil.NToC( A1402OpcIVA, 10, 2, ".", "")));
         AssignAttri("", false, "A1397OpcEmp", StringUtil.RTrim( A1397OpcEmp));
         AssignAttri("", false, "A1390OpcAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1390OpcAutOcom), 1, 0, ".", "")));
         AssignAttri("", false, "A1389OpcAutCompras", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1389OpcAutCompras), 1, 0, ".", "")));
         AssignAttri("", false, "A1406OpcPedAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1406OpcPedAut), 1, 0, ".", "")));
         AssignAttri("", false, "A1421OpcVersion", StringUtil.RTrim( A1421OpcVersion));
         AssignAttri("", false, "A1417OpcRetencion", StringUtil.LTrim( StringUtil.NToC( A1417OpcRetencion, 10, 2, ".", "")));
         AssignAttri("", false, "A1415OpcPercepcion", StringUtil.LTrim( StringUtil.NToC( A1415OpcPercepcion, 10, 2, ".", "")));
         AssignAttri("", false, "A1416OpcPercepcionAgentes", StringUtil.LTrim( StringUtil.NToC( A1416OpcPercepcionAgentes, 10, 2, ".", "")));
         AssignAttri("", false, "A1407OpcPedAutNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1407OpcPedAutNum), 2, 0, ".", "")));
         AssignAttri("", false, "A1405OpcListaPrecios", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1405OpcListaPrecios), 1, 0, ".", "")));
         AssignAttri("", false, "A1399OpcEntrada", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1399OpcEntrada), 1, 0, ".", "")));
         AssignAttri("", false, "A1420OpcStkComp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1420OpcStkComp), 1, 0, ".", "")));
         AssignAttri("", false, "A1392OpcEMailHost", StringUtil.RTrim( A1392OpcEMailHost));
         AssignAttri("", false, "A1395OpcEMailSalida", StringUtil.RTrim( A1395OpcEMailSalida));
         AssignAttri("", false, "A1396OpcEMailUsu", StringUtil.RTrim( A1396OpcEMailUsu));
         AssignAttri("", false, "A1393OpcEMailPass", StringUtil.RTrim( A1393OpcEMailPass));
         AssignAttri("", false, "A1398OpcEmpAgente", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1398OpcEmpAgente), 1, 0, ".", "")));
         AssignAttri("", false, "A1394OpcEMailPort", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1394OpcEMailPort), 4, 0, ".", "")));
         AssignAttri("", false, "A1391OpcCosIngreso", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1391OpcCosIngreso), 1, 0, ".", "")));
         AssignAttri("", false, "A1400OpcFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1400OpcFE), 1, 0, ".", "")));
         AssignAttri("", false, "A1401OpcFERetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1401OpcFERetencion), 1, 0, ".", "")));
         AssignAttri("", false, "A1403OpcLetrasGirador", A1403OpcLetrasGirador);
         AssignAttri("", false, "A1404OpcLetrasLugar", A1404OpcLetrasLugar);
         AssignAttri("", false, "A2260OpcAutOComNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2260OpcAutOComNum), 4, 0, ".", "")));
         AssignAttri("", false, "A1418OpcServerFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1418OpcServerFE), 1, 0, ".", "")));
         AssignAttri("", false, "A2261OpcCuentaDetraccion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2261OpcCuentaDetraccion), 4, 0, ".", "")));
         AssignAttri("", false, "A1412OpcPedPrecios", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1412OpcPedPrecios), 1, 0, ".", "")));
         AssignAttri("", false, "A1409OpcPedDescuento", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1409OpcPedDescuento), 1, 0, ".", "")));
         AssignAttri("", false, "A1413OpcPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1413OpcPedStock), 1, 0, ".", "")));
         AssignAttri("", false, "A1414OpcPedVendedor", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1414OpcPedVendedor), 1, 0, ".", "")));
         AssignAttri("", false, "A1411OpcPedMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1411OpcPedMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1408OpcPedCondPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1408OpcPedCondPago), 1, 0, ".", "")));
         AssignAttri("", false, "A1410OpcPedLista", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1410OpcPedLista), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z347OpcId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z347OpcId), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1419OpcStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1419OpcStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1402OpcIVA", StringUtil.LTrim( StringUtil.NToC( Z1402OpcIVA, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1397OpcEmp", StringUtil.RTrim( Z1397OpcEmp));
         GxWebStd.gx_hidden_field( context, "Z1390OpcAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1390OpcAutOcom), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1389OpcAutCompras", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1389OpcAutCompras), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1406OpcPedAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1406OpcPedAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1421OpcVersion", StringUtil.RTrim( Z1421OpcVersion));
         GxWebStd.gx_hidden_field( context, "Z1417OpcRetencion", StringUtil.LTrim( StringUtil.NToC( Z1417OpcRetencion, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1415OpcPercepcion", StringUtil.LTrim( StringUtil.NToC( Z1415OpcPercepcion, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1416OpcPercepcionAgentes", StringUtil.LTrim( StringUtil.NToC( Z1416OpcPercepcionAgentes, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1407OpcPedAutNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1407OpcPedAutNum), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1405OpcListaPrecios", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1405OpcListaPrecios), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1399OpcEntrada", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1399OpcEntrada), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1420OpcStkComp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1420OpcStkComp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1392OpcEMailHost", StringUtil.RTrim( Z1392OpcEMailHost));
         GxWebStd.gx_hidden_field( context, "Z1395OpcEMailSalida", StringUtil.RTrim( Z1395OpcEMailSalida));
         GxWebStd.gx_hidden_field( context, "Z1396OpcEMailUsu", StringUtil.RTrim( Z1396OpcEMailUsu));
         GxWebStd.gx_hidden_field( context, "Z1393OpcEMailPass", StringUtil.RTrim( Z1393OpcEMailPass));
         GxWebStd.gx_hidden_field( context, "Z1398OpcEmpAgente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1398OpcEmpAgente), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1394OpcEMailPort", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1394OpcEMailPort), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1391OpcCosIngreso", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1391OpcCosIngreso), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1400OpcFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1400OpcFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1401OpcFERetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1401OpcFERetencion), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1403OpcLetrasGirador", Z1403OpcLetrasGirador);
         GxWebStd.gx_hidden_field( context, "Z1404OpcLetrasLugar", Z1404OpcLetrasLugar);
         GxWebStd.gx_hidden_field( context, "Z2260OpcAutOComNum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2260OpcAutOComNum), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1418OpcServerFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1418OpcServerFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2261OpcCuentaDetraccion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2261OpcCuentaDetraccion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1412OpcPedPrecios", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1412OpcPedPrecios), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1409OpcPedDescuento", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1409OpcPedDescuento), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1413OpcPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1413OpcPedStock), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1414OpcPedVendedor", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1414OpcPedVendedor), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1411OpcPedMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1411OpcPedMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1408OpcPedCondPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1408OpcPedCondPago), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1410OpcPedLista", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1410OpcPedLista), 1, 0, ".", "")));
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
         setEventMetadata("VALID_OPCID","{handler:'Valid_Opcid',iparms:[{av:'A347OpcId',fld:'OPCID',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_OPCID",",oparms:[{av:'A1419OpcStk',fld:'OPCSTK',pic:'9'},{av:'A1402OpcIVA',fld:'OPCIVA',pic:'ZZZZZZ9.99'},{av:'A1397OpcEmp',fld:'OPCEMP',pic:''},{av:'A1390OpcAutOcom',fld:'OPCAUTOCOM',pic:'9'},{av:'A1389OpcAutCompras',fld:'OPCAUTCOMPRAS',pic:'9'},{av:'A1406OpcPedAut',fld:'OPCPEDAUT',pic:'9'},{av:'A1421OpcVersion',fld:'OPCVERSION',pic:''},{av:'A1417OpcRetencion',fld:'OPCRETENCION',pic:'ZZZZZZ9.99'},{av:'A1415OpcPercepcion',fld:'OPCPERCEPCION',pic:'ZZZZZZ9.99'},{av:'A1416OpcPercepcionAgentes',fld:'OPCPERCEPCIONAGENTES',pic:'ZZZZZZ9.99'},{av:'A1407OpcPedAutNum',fld:'OPCPEDAUTNUM',pic:'Z9'},{av:'A1405OpcListaPrecios',fld:'OPCLISTAPRECIOS',pic:'9'},{av:'A1399OpcEntrada',fld:'OPCENTRADA',pic:'9'},{av:'A1420OpcStkComp',fld:'OPCSTKCOMP',pic:'9'},{av:'A1392OpcEMailHost',fld:'OPCEMAILHOST',pic:''},{av:'A1395OpcEMailSalida',fld:'OPCEMAILSALIDA',pic:''},{av:'A1396OpcEMailUsu',fld:'OPCEMAILUSU',pic:''},{av:'A1393OpcEMailPass',fld:'OPCEMAILPASS',pic:''},{av:'A1398OpcEmpAgente',fld:'OPCEMPAGENTE',pic:'9'},{av:'A1394OpcEMailPort',fld:'OPCEMAILPORT',pic:'ZZZ9'},{av:'A1391OpcCosIngreso',fld:'OPCCOSINGRESO',pic:'9'},{av:'A1400OpcFE',fld:'OPCFE',pic:'9'},{av:'A1401OpcFERetencion',fld:'OPCFERETENCION',pic:'9'},{av:'A1403OpcLetrasGirador',fld:'OPCLETRASGIRADOR',pic:''},{av:'A1404OpcLetrasLugar',fld:'OPCLETRASLUGAR',pic:''},{av:'A2260OpcAutOComNum',fld:'OPCAUTOCOMNUM',pic:'ZZZ9'},{av:'A1418OpcServerFE',fld:'OPCSERVERFE',pic:'9'},{av:'A2261OpcCuentaDetraccion',fld:'OPCCUENTADETRACCION',pic:'ZZZ9'},{av:'A1412OpcPedPrecios',fld:'OPCPEDPRECIOS',pic:'9'},{av:'A1409OpcPedDescuento',fld:'OPCPEDDESCUENTO',pic:'9'},{av:'A1413OpcPedStock',fld:'OPCPEDSTOCK',pic:'9'},{av:'A1414OpcPedVendedor',fld:'OPCPEDVENDEDOR',pic:'9'},{av:'A1411OpcPedMonCod',fld:'OPCPEDMONCOD',pic:'ZZZZZ9'},{av:'A1408OpcPedCondPago',fld:'OPCPEDCONDPAGO',pic:'9'},{av:'A1410OpcPedLista',fld:'OPCPEDLISTA',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z347OpcId'},{av:'Z1419OpcStk'},{av:'Z1402OpcIVA'},{av:'Z1397OpcEmp'},{av:'Z1390OpcAutOcom'},{av:'Z1389OpcAutCompras'},{av:'Z1406OpcPedAut'},{av:'Z1421OpcVersion'},{av:'Z1417OpcRetencion'},{av:'Z1415OpcPercepcion'},{av:'Z1416OpcPercepcionAgentes'},{av:'Z1407OpcPedAutNum'},{av:'Z1405OpcListaPrecios'},{av:'Z1399OpcEntrada'},{av:'Z1420OpcStkComp'},{av:'Z1392OpcEMailHost'},{av:'Z1395OpcEMailSalida'},{av:'Z1396OpcEMailUsu'},{av:'Z1393OpcEMailPass'},{av:'Z1398OpcEmpAgente'},{av:'Z1394OpcEMailPort'},{av:'Z1391OpcCosIngreso'},{av:'Z1400OpcFE'},{av:'Z1401OpcFERetencion'},{av:'Z1403OpcLetrasGirador'},{av:'Z1404OpcLetrasLugar'},{av:'Z2260OpcAutOComNum'},{av:'Z1418OpcServerFE'},{av:'Z2261OpcCuentaDetraccion'},{av:'Z1412OpcPedPrecios'},{av:'Z1409OpcPedDescuento'},{av:'Z1413OpcPedStock'},{av:'Z1414OpcPedVendedor'},{av:'Z1411OpcPedMonCod'},{av:'Z1408OpcPedCondPago'},{av:'Z1410OpcPedLista'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z1397OpcEmp = "";
         Z1421OpcVersion = "";
         Z1392OpcEMailHost = "";
         Z1395OpcEMailSalida = "";
         Z1396OpcEMailUsu = "";
         Z1393OpcEMailPass = "";
         Z1403OpcLetrasGirador = "";
         Z1404OpcLetrasLugar = "";
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
         A1397OpcEmp = "";
         A1421OpcVersion = "";
         A1392OpcEMailHost = "";
         A1395OpcEMailSalida = "";
         A1396OpcEMailUsu = "";
         A1393OpcEMailPass = "";
         A1403OpcLetrasGirador = "";
         A1404OpcLetrasLugar = "";
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
         T000R4_A347OpcId = new short[1] ;
         T000R4_A1419OpcStk = new short[1] ;
         T000R4_A1402OpcIVA = new decimal[1] ;
         T000R4_A1397OpcEmp = new string[] {""} ;
         T000R4_A1390OpcAutOcom = new short[1] ;
         T000R4_A1389OpcAutCompras = new short[1] ;
         T000R4_A1406OpcPedAut = new short[1] ;
         T000R4_A1421OpcVersion = new string[] {""} ;
         T000R4_A1417OpcRetencion = new decimal[1] ;
         T000R4_A1415OpcPercepcion = new decimal[1] ;
         T000R4_A1416OpcPercepcionAgentes = new decimal[1] ;
         T000R4_A1407OpcPedAutNum = new short[1] ;
         T000R4_A1405OpcListaPrecios = new short[1] ;
         T000R4_A1399OpcEntrada = new short[1] ;
         T000R4_A1420OpcStkComp = new short[1] ;
         T000R4_A1392OpcEMailHost = new string[] {""} ;
         T000R4_A1395OpcEMailSalida = new string[] {""} ;
         T000R4_A1396OpcEMailUsu = new string[] {""} ;
         T000R4_A1393OpcEMailPass = new string[] {""} ;
         T000R4_A1398OpcEmpAgente = new short[1] ;
         T000R4_A1394OpcEMailPort = new short[1] ;
         T000R4_A1391OpcCosIngreso = new short[1] ;
         T000R4_A1400OpcFE = new short[1] ;
         T000R4_A1401OpcFERetencion = new short[1] ;
         T000R4_A1403OpcLetrasGirador = new string[] {""} ;
         T000R4_A1404OpcLetrasLugar = new string[] {""} ;
         T000R4_A2260OpcAutOComNum = new short[1] ;
         T000R4_A1418OpcServerFE = new short[1] ;
         T000R4_A2261OpcCuentaDetraccion = new short[1] ;
         T000R4_A1412OpcPedPrecios = new short[1] ;
         T000R4_A1409OpcPedDescuento = new short[1] ;
         T000R4_A1413OpcPedStock = new short[1] ;
         T000R4_A1414OpcPedVendedor = new short[1] ;
         T000R4_A1411OpcPedMonCod = new int[1] ;
         T000R4_A1408OpcPedCondPago = new short[1] ;
         T000R4_A1410OpcPedLista = new short[1] ;
         T000R5_A347OpcId = new short[1] ;
         T000R3_A347OpcId = new short[1] ;
         T000R3_A1419OpcStk = new short[1] ;
         T000R3_A1402OpcIVA = new decimal[1] ;
         T000R3_A1397OpcEmp = new string[] {""} ;
         T000R3_A1390OpcAutOcom = new short[1] ;
         T000R3_A1389OpcAutCompras = new short[1] ;
         T000R3_A1406OpcPedAut = new short[1] ;
         T000R3_A1421OpcVersion = new string[] {""} ;
         T000R3_A1417OpcRetencion = new decimal[1] ;
         T000R3_A1415OpcPercepcion = new decimal[1] ;
         T000R3_A1416OpcPercepcionAgentes = new decimal[1] ;
         T000R3_A1407OpcPedAutNum = new short[1] ;
         T000R3_A1405OpcListaPrecios = new short[1] ;
         T000R3_A1399OpcEntrada = new short[1] ;
         T000R3_A1420OpcStkComp = new short[1] ;
         T000R3_A1392OpcEMailHost = new string[] {""} ;
         T000R3_A1395OpcEMailSalida = new string[] {""} ;
         T000R3_A1396OpcEMailUsu = new string[] {""} ;
         T000R3_A1393OpcEMailPass = new string[] {""} ;
         T000R3_A1398OpcEmpAgente = new short[1] ;
         T000R3_A1394OpcEMailPort = new short[1] ;
         T000R3_A1391OpcCosIngreso = new short[1] ;
         T000R3_A1400OpcFE = new short[1] ;
         T000R3_A1401OpcFERetencion = new short[1] ;
         T000R3_A1403OpcLetrasGirador = new string[] {""} ;
         T000R3_A1404OpcLetrasLugar = new string[] {""} ;
         T000R3_A2260OpcAutOComNum = new short[1] ;
         T000R3_A1418OpcServerFE = new short[1] ;
         T000R3_A2261OpcCuentaDetraccion = new short[1] ;
         T000R3_A1412OpcPedPrecios = new short[1] ;
         T000R3_A1409OpcPedDescuento = new short[1] ;
         T000R3_A1413OpcPedStock = new short[1] ;
         T000R3_A1414OpcPedVendedor = new short[1] ;
         T000R3_A1411OpcPedMonCod = new int[1] ;
         T000R3_A1408OpcPedCondPago = new short[1] ;
         T000R3_A1410OpcPedLista = new short[1] ;
         sMode27 = "";
         T000R6_A347OpcId = new short[1] ;
         T000R7_A347OpcId = new short[1] ;
         T000R2_A347OpcId = new short[1] ;
         T000R2_A1419OpcStk = new short[1] ;
         T000R2_A1402OpcIVA = new decimal[1] ;
         T000R2_A1397OpcEmp = new string[] {""} ;
         T000R2_A1390OpcAutOcom = new short[1] ;
         T000R2_A1389OpcAutCompras = new short[1] ;
         T000R2_A1406OpcPedAut = new short[1] ;
         T000R2_A1421OpcVersion = new string[] {""} ;
         T000R2_A1417OpcRetencion = new decimal[1] ;
         T000R2_A1415OpcPercepcion = new decimal[1] ;
         T000R2_A1416OpcPercepcionAgentes = new decimal[1] ;
         T000R2_A1407OpcPedAutNum = new short[1] ;
         T000R2_A1405OpcListaPrecios = new short[1] ;
         T000R2_A1399OpcEntrada = new short[1] ;
         T000R2_A1420OpcStkComp = new short[1] ;
         T000R2_A1392OpcEMailHost = new string[] {""} ;
         T000R2_A1395OpcEMailSalida = new string[] {""} ;
         T000R2_A1396OpcEMailUsu = new string[] {""} ;
         T000R2_A1393OpcEMailPass = new string[] {""} ;
         T000R2_A1398OpcEmpAgente = new short[1] ;
         T000R2_A1394OpcEMailPort = new short[1] ;
         T000R2_A1391OpcCosIngreso = new short[1] ;
         T000R2_A1400OpcFE = new short[1] ;
         T000R2_A1401OpcFERetencion = new short[1] ;
         T000R2_A1403OpcLetrasGirador = new string[] {""} ;
         T000R2_A1404OpcLetrasLugar = new string[] {""} ;
         T000R2_A2260OpcAutOComNum = new short[1] ;
         T000R2_A1418OpcServerFE = new short[1] ;
         T000R2_A2261OpcCuentaDetraccion = new short[1] ;
         T000R2_A1412OpcPedPrecios = new short[1] ;
         T000R2_A1409OpcPedDescuento = new short[1] ;
         T000R2_A1413OpcPedStock = new short[1] ;
         T000R2_A1414OpcPedVendedor = new short[1] ;
         T000R2_A1411OpcPedMonCod = new int[1] ;
         T000R2_A1408OpcPedCondPago = new short[1] ;
         T000R2_A1410OpcPedLista = new short[1] ;
         T000R11_A347OpcId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1397OpcEmp = "";
         ZZ1421OpcVersion = "";
         ZZ1392OpcEMailHost = "";
         ZZ1395OpcEMailSalida = "";
         ZZ1396OpcEMailUsu = "";
         ZZ1393OpcEMailPass = "";
         ZZ1403OpcLetrasGirador = "";
         ZZ1404OpcLetrasLugar = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgopciones__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgopciones__default(),
            new Object[][] {
                new Object[] {
               T000R2_A347OpcId, T000R2_A1419OpcStk, T000R2_A1402OpcIVA, T000R2_A1397OpcEmp, T000R2_A1390OpcAutOcom, T000R2_A1389OpcAutCompras, T000R2_A1406OpcPedAut, T000R2_A1421OpcVersion, T000R2_A1417OpcRetencion, T000R2_A1415OpcPercepcion,
               T000R2_A1416OpcPercepcionAgentes, T000R2_A1407OpcPedAutNum, T000R2_A1405OpcListaPrecios, T000R2_A1399OpcEntrada, T000R2_A1420OpcStkComp, T000R2_A1392OpcEMailHost, T000R2_A1395OpcEMailSalida, T000R2_A1396OpcEMailUsu, T000R2_A1393OpcEMailPass, T000R2_A1398OpcEmpAgente,
               T000R2_A1394OpcEMailPort, T000R2_A1391OpcCosIngreso, T000R2_A1400OpcFE, T000R2_A1401OpcFERetencion, T000R2_A1403OpcLetrasGirador, T000R2_A1404OpcLetrasLugar, T000R2_A2260OpcAutOComNum, T000R2_A1418OpcServerFE, T000R2_A2261OpcCuentaDetraccion, T000R2_A1412OpcPedPrecios,
               T000R2_A1409OpcPedDescuento, T000R2_A1413OpcPedStock, T000R2_A1414OpcPedVendedor, T000R2_A1411OpcPedMonCod, T000R2_A1408OpcPedCondPago, T000R2_A1410OpcPedLista
               }
               , new Object[] {
               T000R3_A347OpcId, T000R3_A1419OpcStk, T000R3_A1402OpcIVA, T000R3_A1397OpcEmp, T000R3_A1390OpcAutOcom, T000R3_A1389OpcAutCompras, T000R3_A1406OpcPedAut, T000R3_A1421OpcVersion, T000R3_A1417OpcRetencion, T000R3_A1415OpcPercepcion,
               T000R3_A1416OpcPercepcionAgentes, T000R3_A1407OpcPedAutNum, T000R3_A1405OpcListaPrecios, T000R3_A1399OpcEntrada, T000R3_A1420OpcStkComp, T000R3_A1392OpcEMailHost, T000R3_A1395OpcEMailSalida, T000R3_A1396OpcEMailUsu, T000R3_A1393OpcEMailPass, T000R3_A1398OpcEmpAgente,
               T000R3_A1394OpcEMailPort, T000R3_A1391OpcCosIngreso, T000R3_A1400OpcFE, T000R3_A1401OpcFERetencion, T000R3_A1403OpcLetrasGirador, T000R3_A1404OpcLetrasLugar, T000R3_A2260OpcAutOComNum, T000R3_A1418OpcServerFE, T000R3_A2261OpcCuentaDetraccion, T000R3_A1412OpcPedPrecios,
               T000R3_A1409OpcPedDescuento, T000R3_A1413OpcPedStock, T000R3_A1414OpcPedVendedor, T000R3_A1411OpcPedMonCod, T000R3_A1408OpcPedCondPago, T000R3_A1410OpcPedLista
               }
               , new Object[] {
               T000R4_A347OpcId, T000R4_A1419OpcStk, T000R4_A1402OpcIVA, T000R4_A1397OpcEmp, T000R4_A1390OpcAutOcom, T000R4_A1389OpcAutCompras, T000R4_A1406OpcPedAut, T000R4_A1421OpcVersion, T000R4_A1417OpcRetencion, T000R4_A1415OpcPercepcion,
               T000R4_A1416OpcPercepcionAgentes, T000R4_A1407OpcPedAutNum, T000R4_A1405OpcListaPrecios, T000R4_A1399OpcEntrada, T000R4_A1420OpcStkComp, T000R4_A1392OpcEMailHost, T000R4_A1395OpcEMailSalida, T000R4_A1396OpcEMailUsu, T000R4_A1393OpcEMailPass, T000R4_A1398OpcEmpAgente,
               T000R4_A1394OpcEMailPort, T000R4_A1391OpcCosIngreso, T000R4_A1400OpcFE, T000R4_A1401OpcFERetencion, T000R4_A1403OpcLetrasGirador, T000R4_A1404OpcLetrasLugar, T000R4_A2260OpcAutOComNum, T000R4_A1418OpcServerFE, T000R4_A2261OpcCuentaDetraccion, T000R4_A1412OpcPedPrecios,
               T000R4_A1409OpcPedDescuento, T000R4_A1413OpcPedStock, T000R4_A1414OpcPedVendedor, T000R4_A1411OpcPedMonCod, T000R4_A1408OpcPedCondPago, T000R4_A1410OpcPedLista
               }
               , new Object[] {
               T000R5_A347OpcId
               }
               , new Object[] {
               T000R6_A347OpcId
               }
               , new Object[] {
               T000R7_A347OpcId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000R11_A347OpcId
               }
            }
         );
      }

      private short Z347OpcId ;
      private short Z1419OpcStk ;
      private short Z1390OpcAutOcom ;
      private short Z1389OpcAutCompras ;
      private short Z1406OpcPedAut ;
      private short Z1407OpcPedAutNum ;
      private short Z1405OpcListaPrecios ;
      private short Z1399OpcEntrada ;
      private short Z1420OpcStkComp ;
      private short Z1398OpcEmpAgente ;
      private short Z1394OpcEMailPort ;
      private short Z1391OpcCosIngreso ;
      private short Z1400OpcFE ;
      private short Z1401OpcFERetencion ;
      private short Z2260OpcAutOComNum ;
      private short Z1418OpcServerFE ;
      private short Z2261OpcCuentaDetraccion ;
      private short Z1412OpcPedPrecios ;
      private short Z1409OpcPedDescuento ;
      private short Z1413OpcPedStock ;
      private short Z1414OpcPedVendedor ;
      private short Z1408OpcPedCondPago ;
      private short Z1410OpcPedLista ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A347OpcId ;
      private short A1419OpcStk ;
      private short A1390OpcAutOcom ;
      private short A1389OpcAutCompras ;
      private short A1406OpcPedAut ;
      private short A1407OpcPedAutNum ;
      private short A1405OpcListaPrecios ;
      private short A1399OpcEntrada ;
      private short A1420OpcStkComp ;
      private short A1398OpcEmpAgente ;
      private short A1394OpcEMailPort ;
      private short A1391OpcCosIngreso ;
      private short A1400OpcFE ;
      private short A1401OpcFERetencion ;
      private short A2260OpcAutOComNum ;
      private short A1418OpcServerFE ;
      private short A2261OpcCuentaDetraccion ;
      private short A1412OpcPedPrecios ;
      private short A1409OpcPedDescuento ;
      private short A1413OpcPedStock ;
      private short A1414OpcPedVendedor ;
      private short A1408OpcPedCondPago ;
      private short A1410OpcPedLista ;
      private short GX_JID ;
      private short RcdFound27 ;
      private short nIsDirty_27 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ347OpcId ;
      private short ZZ1419OpcStk ;
      private short ZZ1390OpcAutOcom ;
      private short ZZ1389OpcAutCompras ;
      private short ZZ1406OpcPedAut ;
      private short ZZ1407OpcPedAutNum ;
      private short ZZ1405OpcListaPrecios ;
      private short ZZ1399OpcEntrada ;
      private short ZZ1420OpcStkComp ;
      private short ZZ1398OpcEmpAgente ;
      private short ZZ1394OpcEMailPort ;
      private short ZZ1391OpcCosIngreso ;
      private short ZZ1400OpcFE ;
      private short ZZ1401OpcFERetencion ;
      private short ZZ2260OpcAutOComNum ;
      private short ZZ1418OpcServerFE ;
      private short ZZ2261OpcCuentaDetraccion ;
      private short ZZ1412OpcPedPrecios ;
      private short ZZ1409OpcPedDescuento ;
      private short ZZ1413OpcPedStock ;
      private short ZZ1414OpcPedVendedor ;
      private short ZZ1408OpcPedCondPago ;
      private short ZZ1410OpcPedLista ;
      private int Z1411OpcPedMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtOpcId_Enabled ;
      private int edtOpcStk_Enabled ;
      private int edtOpcIVA_Enabled ;
      private int edtOpcEmp_Enabled ;
      private int edtOpcAutOcom_Enabled ;
      private int edtOpcAutCompras_Enabled ;
      private int edtOpcPedAut_Enabled ;
      private int edtOpcVersion_Enabled ;
      private int edtOpcRetencion_Enabled ;
      private int edtOpcPercepcion_Enabled ;
      private int edtOpcPercepcionAgentes_Enabled ;
      private int edtOpcPedAutNum_Enabled ;
      private int edtOpcListaPrecios_Enabled ;
      private int edtOpcEntrada_Enabled ;
      private int edtOpcStkComp_Enabled ;
      private int edtOpcEMailHost_Enabled ;
      private int edtOpcEMailSalida_Enabled ;
      private int edtOpcEMailUsu_Enabled ;
      private int edtOpcEMailPass_Enabled ;
      private int edtOpcEmpAgente_Enabled ;
      private int edtOpcEMailPort_Enabled ;
      private int edtOpcCosIngreso_Enabled ;
      private int edtOpcFE_Enabled ;
      private int edtOpcFERetencion_Enabled ;
      private int edtOpcLetrasGirador_Enabled ;
      private int edtOpcLetrasLugar_Enabled ;
      private int edtOpcAutOComNum_Enabled ;
      private int edtOpcServerFE_Enabled ;
      private int edtOpcCuentaDetraccion_Enabled ;
      private int edtOpcPedPrecios_Enabled ;
      private int edtOpcPedDescuento_Enabled ;
      private int edtOpcPedStock_Enabled ;
      private int edtOpcPedVendedor_Enabled ;
      private int A1411OpcPedMonCod ;
      private int edtOpcPedMonCod_Enabled ;
      private int edtOpcPedCondPago_Enabled ;
      private int edtOpcPedLista_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ1411OpcPedMonCod ;
      private decimal Z1402OpcIVA ;
      private decimal Z1417OpcRetencion ;
      private decimal Z1415OpcPercepcion ;
      private decimal Z1416OpcPercepcionAgentes ;
      private decimal A1402OpcIVA ;
      private decimal A1417OpcRetencion ;
      private decimal A1415OpcPercepcion ;
      private decimal A1416OpcPercepcionAgentes ;
      private decimal ZZ1402OpcIVA ;
      private decimal ZZ1417OpcRetencion ;
      private decimal ZZ1415OpcPercepcion ;
      private decimal ZZ1416OpcPercepcionAgentes ;
      private string sPrefix ;
      private string Z1397OpcEmp ;
      private string Z1421OpcVersion ;
      private string Z1392OpcEMailHost ;
      private string Z1395OpcEMailSalida ;
      private string Z1396OpcEMailUsu ;
      private string Z1393OpcEMailPass ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOpcId_Internalname ;
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
      private string edtOpcId_Jsonclick ;
      private string edtOpcStk_Internalname ;
      private string edtOpcStk_Jsonclick ;
      private string edtOpcIVA_Internalname ;
      private string edtOpcIVA_Jsonclick ;
      private string edtOpcEmp_Internalname ;
      private string A1397OpcEmp ;
      private string edtOpcEmp_Jsonclick ;
      private string edtOpcAutOcom_Internalname ;
      private string edtOpcAutOcom_Jsonclick ;
      private string edtOpcAutCompras_Internalname ;
      private string edtOpcAutCompras_Jsonclick ;
      private string edtOpcPedAut_Internalname ;
      private string edtOpcPedAut_Jsonclick ;
      private string edtOpcVersion_Internalname ;
      private string A1421OpcVersion ;
      private string edtOpcVersion_Jsonclick ;
      private string edtOpcRetencion_Internalname ;
      private string edtOpcRetencion_Jsonclick ;
      private string edtOpcPercepcion_Internalname ;
      private string edtOpcPercepcion_Jsonclick ;
      private string edtOpcPercepcionAgentes_Internalname ;
      private string edtOpcPercepcionAgentes_Jsonclick ;
      private string edtOpcPedAutNum_Internalname ;
      private string edtOpcPedAutNum_Jsonclick ;
      private string edtOpcListaPrecios_Internalname ;
      private string edtOpcListaPrecios_Jsonclick ;
      private string edtOpcEntrada_Internalname ;
      private string edtOpcEntrada_Jsonclick ;
      private string edtOpcStkComp_Internalname ;
      private string edtOpcStkComp_Jsonclick ;
      private string edtOpcEMailHost_Internalname ;
      private string A1392OpcEMailHost ;
      private string edtOpcEMailHost_Jsonclick ;
      private string edtOpcEMailSalida_Internalname ;
      private string A1395OpcEMailSalida ;
      private string edtOpcEMailSalida_Jsonclick ;
      private string edtOpcEMailUsu_Internalname ;
      private string A1396OpcEMailUsu ;
      private string edtOpcEMailUsu_Jsonclick ;
      private string edtOpcEMailPass_Internalname ;
      private string A1393OpcEMailPass ;
      private string edtOpcEMailPass_Jsonclick ;
      private string edtOpcEmpAgente_Internalname ;
      private string edtOpcEmpAgente_Jsonclick ;
      private string edtOpcEMailPort_Internalname ;
      private string edtOpcEMailPort_Jsonclick ;
      private string edtOpcCosIngreso_Internalname ;
      private string edtOpcCosIngreso_Jsonclick ;
      private string edtOpcFE_Internalname ;
      private string edtOpcFE_Jsonclick ;
      private string edtOpcFERetencion_Internalname ;
      private string edtOpcFERetencion_Jsonclick ;
      private string edtOpcLetrasGirador_Internalname ;
      private string edtOpcLetrasGirador_Jsonclick ;
      private string edtOpcLetrasLugar_Internalname ;
      private string edtOpcLetrasLugar_Jsonclick ;
      private string edtOpcAutOComNum_Internalname ;
      private string edtOpcAutOComNum_Jsonclick ;
      private string edtOpcServerFE_Internalname ;
      private string edtOpcServerFE_Jsonclick ;
      private string edtOpcCuentaDetraccion_Internalname ;
      private string edtOpcCuentaDetraccion_Jsonclick ;
      private string edtOpcPedPrecios_Internalname ;
      private string edtOpcPedPrecios_Jsonclick ;
      private string edtOpcPedDescuento_Internalname ;
      private string edtOpcPedDescuento_Jsonclick ;
      private string edtOpcPedStock_Internalname ;
      private string edtOpcPedStock_Jsonclick ;
      private string edtOpcPedVendedor_Internalname ;
      private string edtOpcPedVendedor_Jsonclick ;
      private string edtOpcPedMonCod_Internalname ;
      private string edtOpcPedMonCod_Jsonclick ;
      private string edtOpcPedCondPago_Internalname ;
      private string edtOpcPedCondPago_Jsonclick ;
      private string edtOpcPedLista_Internalname ;
      private string edtOpcPedLista_Jsonclick ;
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
      private string sMode27 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1397OpcEmp ;
      private string ZZ1421OpcVersion ;
      private string ZZ1392OpcEMailHost ;
      private string ZZ1395OpcEMailSalida ;
      private string ZZ1396OpcEMailUsu ;
      private string ZZ1393OpcEMailPass ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z1403OpcLetrasGirador ;
      private string Z1404OpcLetrasLugar ;
      private string A1403OpcLetrasGirador ;
      private string A1404OpcLetrasLugar ;
      private string ZZ1403OpcLetrasGirador ;
      private string ZZ1404OpcLetrasLugar ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000R4_A347OpcId ;
      private short[] T000R4_A1419OpcStk ;
      private decimal[] T000R4_A1402OpcIVA ;
      private string[] T000R4_A1397OpcEmp ;
      private short[] T000R4_A1390OpcAutOcom ;
      private short[] T000R4_A1389OpcAutCompras ;
      private short[] T000R4_A1406OpcPedAut ;
      private string[] T000R4_A1421OpcVersion ;
      private decimal[] T000R4_A1417OpcRetencion ;
      private decimal[] T000R4_A1415OpcPercepcion ;
      private decimal[] T000R4_A1416OpcPercepcionAgentes ;
      private short[] T000R4_A1407OpcPedAutNum ;
      private short[] T000R4_A1405OpcListaPrecios ;
      private short[] T000R4_A1399OpcEntrada ;
      private short[] T000R4_A1420OpcStkComp ;
      private string[] T000R4_A1392OpcEMailHost ;
      private string[] T000R4_A1395OpcEMailSalida ;
      private string[] T000R4_A1396OpcEMailUsu ;
      private string[] T000R4_A1393OpcEMailPass ;
      private short[] T000R4_A1398OpcEmpAgente ;
      private short[] T000R4_A1394OpcEMailPort ;
      private short[] T000R4_A1391OpcCosIngreso ;
      private short[] T000R4_A1400OpcFE ;
      private short[] T000R4_A1401OpcFERetencion ;
      private string[] T000R4_A1403OpcLetrasGirador ;
      private string[] T000R4_A1404OpcLetrasLugar ;
      private short[] T000R4_A2260OpcAutOComNum ;
      private short[] T000R4_A1418OpcServerFE ;
      private short[] T000R4_A2261OpcCuentaDetraccion ;
      private short[] T000R4_A1412OpcPedPrecios ;
      private short[] T000R4_A1409OpcPedDescuento ;
      private short[] T000R4_A1413OpcPedStock ;
      private short[] T000R4_A1414OpcPedVendedor ;
      private int[] T000R4_A1411OpcPedMonCod ;
      private short[] T000R4_A1408OpcPedCondPago ;
      private short[] T000R4_A1410OpcPedLista ;
      private short[] T000R5_A347OpcId ;
      private short[] T000R3_A347OpcId ;
      private short[] T000R3_A1419OpcStk ;
      private decimal[] T000R3_A1402OpcIVA ;
      private string[] T000R3_A1397OpcEmp ;
      private short[] T000R3_A1390OpcAutOcom ;
      private short[] T000R3_A1389OpcAutCompras ;
      private short[] T000R3_A1406OpcPedAut ;
      private string[] T000R3_A1421OpcVersion ;
      private decimal[] T000R3_A1417OpcRetencion ;
      private decimal[] T000R3_A1415OpcPercepcion ;
      private decimal[] T000R3_A1416OpcPercepcionAgentes ;
      private short[] T000R3_A1407OpcPedAutNum ;
      private short[] T000R3_A1405OpcListaPrecios ;
      private short[] T000R3_A1399OpcEntrada ;
      private short[] T000R3_A1420OpcStkComp ;
      private string[] T000R3_A1392OpcEMailHost ;
      private string[] T000R3_A1395OpcEMailSalida ;
      private string[] T000R3_A1396OpcEMailUsu ;
      private string[] T000R3_A1393OpcEMailPass ;
      private short[] T000R3_A1398OpcEmpAgente ;
      private short[] T000R3_A1394OpcEMailPort ;
      private short[] T000R3_A1391OpcCosIngreso ;
      private short[] T000R3_A1400OpcFE ;
      private short[] T000R3_A1401OpcFERetencion ;
      private string[] T000R3_A1403OpcLetrasGirador ;
      private string[] T000R3_A1404OpcLetrasLugar ;
      private short[] T000R3_A2260OpcAutOComNum ;
      private short[] T000R3_A1418OpcServerFE ;
      private short[] T000R3_A2261OpcCuentaDetraccion ;
      private short[] T000R3_A1412OpcPedPrecios ;
      private short[] T000R3_A1409OpcPedDescuento ;
      private short[] T000R3_A1413OpcPedStock ;
      private short[] T000R3_A1414OpcPedVendedor ;
      private int[] T000R3_A1411OpcPedMonCod ;
      private short[] T000R3_A1408OpcPedCondPago ;
      private short[] T000R3_A1410OpcPedLista ;
      private short[] T000R6_A347OpcId ;
      private short[] T000R7_A347OpcId ;
      private short[] T000R2_A347OpcId ;
      private short[] T000R2_A1419OpcStk ;
      private decimal[] T000R2_A1402OpcIVA ;
      private string[] T000R2_A1397OpcEmp ;
      private short[] T000R2_A1390OpcAutOcom ;
      private short[] T000R2_A1389OpcAutCompras ;
      private short[] T000R2_A1406OpcPedAut ;
      private string[] T000R2_A1421OpcVersion ;
      private decimal[] T000R2_A1417OpcRetencion ;
      private decimal[] T000R2_A1415OpcPercepcion ;
      private decimal[] T000R2_A1416OpcPercepcionAgentes ;
      private short[] T000R2_A1407OpcPedAutNum ;
      private short[] T000R2_A1405OpcListaPrecios ;
      private short[] T000R2_A1399OpcEntrada ;
      private short[] T000R2_A1420OpcStkComp ;
      private string[] T000R2_A1392OpcEMailHost ;
      private string[] T000R2_A1395OpcEMailSalida ;
      private string[] T000R2_A1396OpcEMailUsu ;
      private string[] T000R2_A1393OpcEMailPass ;
      private short[] T000R2_A1398OpcEmpAgente ;
      private short[] T000R2_A1394OpcEMailPort ;
      private short[] T000R2_A1391OpcCosIngreso ;
      private short[] T000R2_A1400OpcFE ;
      private short[] T000R2_A1401OpcFERetencion ;
      private string[] T000R2_A1403OpcLetrasGirador ;
      private string[] T000R2_A1404OpcLetrasLugar ;
      private short[] T000R2_A2260OpcAutOComNum ;
      private short[] T000R2_A1418OpcServerFE ;
      private short[] T000R2_A2261OpcCuentaDetraccion ;
      private short[] T000R2_A1412OpcPedPrecios ;
      private short[] T000R2_A1409OpcPedDescuento ;
      private short[] T000R2_A1413OpcPedStock ;
      private short[] T000R2_A1414OpcPedVendedor ;
      private int[] T000R2_A1411OpcPedMonCod ;
      private short[] T000R2_A1408OpcPedCondPago ;
      private short[] T000R2_A1410OpcPedLista ;
      private short[] T000R11_A347OpcId ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgopciones__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgopciones__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000R4;
        prmT000R4 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R5;
        prmT000R5 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R3;
        prmT000R3 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R6;
        prmT000R6 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R7;
        prmT000R7 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R2;
        prmT000R2 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R8;
        prmT000R8 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0) ,
        new ParDef("@OpcStk",GXType.Int16,1,0) ,
        new ParDef("@OpcIVA",GXType.Decimal,10,2) ,
        new ParDef("@OpcEmp",GXType.NChar,80,0) ,
        new ParDef("@OpcAutOcom",GXType.Int16,1,0) ,
        new ParDef("@OpcAutCompras",GXType.Int16,1,0) ,
        new ParDef("@OpcPedAut",GXType.Int16,1,0) ,
        new ParDef("@OpcVersion",GXType.NChar,20,0) ,
        new ParDef("@OpcRetencion",GXType.Decimal,10,2) ,
        new ParDef("@OpcPercepcion",GXType.Decimal,10,2) ,
        new ParDef("@OpcPercepcionAgentes",GXType.Decimal,10,2) ,
        new ParDef("@OpcPedAutNum",GXType.Int16,2,0) ,
        new ParDef("@OpcListaPrecios",GXType.Int16,1,0) ,
        new ParDef("@OpcEntrada",GXType.Int16,1,0) ,
        new ParDef("@OpcStkComp",GXType.Int16,1,0) ,
        new ParDef("@OpcEMailHost",GXType.NChar,100,0) ,
        new ParDef("@OpcEMailSalida",GXType.NChar,100,0) ,
        new ParDef("@OpcEMailUsu",GXType.NChar,100,0) ,
        new ParDef("@OpcEMailPass",GXType.NChar,20,0) ,
        new ParDef("@OpcEmpAgente",GXType.Int16,1,0) ,
        new ParDef("@OpcEMailPort",GXType.Int16,4,0) ,
        new ParDef("@OpcCosIngreso",GXType.Int16,1,0) ,
        new ParDef("@OpcFE",GXType.Int16,1,0) ,
        new ParDef("@OpcFERetencion",GXType.Int16,1,0) ,
        new ParDef("@OpcLetrasGirador",GXType.NVarChar,100,0) ,
        new ParDef("@OpcLetrasLugar",GXType.NVarChar,100,0) ,
        new ParDef("@OpcAutOComNum",GXType.Int16,4,0) ,
        new ParDef("@OpcServerFE",GXType.Int16,1,0) ,
        new ParDef("@OpcCuentaDetraccion",GXType.Int16,4,0) ,
        new ParDef("@OpcPedPrecios",GXType.Int16,1,0) ,
        new ParDef("@OpcPedDescuento",GXType.Int16,1,0) ,
        new ParDef("@OpcPedStock",GXType.Int16,1,0) ,
        new ParDef("@OpcPedVendedor",GXType.Int16,1,0) ,
        new ParDef("@OpcPedMonCod",GXType.Int32,6,0) ,
        new ParDef("@OpcPedCondPago",GXType.Int16,1,0) ,
        new ParDef("@OpcPedLista",GXType.Int16,1,0)
        };
        Object[] prmT000R9;
        prmT000R9 = new Object[] {
        new ParDef("@OpcStk",GXType.Int16,1,0) ,
        new ParDef("@OpcIVA",GXType.Decimal,10,2) ,
        new ParDef("@OpcEmp",GXType.NChar,80,0) ,
        new ParDef("@OpcAutOcom",GXType.Int16,1,0) ,
        new ParDef("@OpcAutCompras",GXType.Int16,1,0) ,
        new ParDef("@OpcPedAut",GXType.Int16,1,0) ,
        new ParDef("@OpcVersion",GXType.NChar,20,0) ,
        new ParDef("@OpcRetencion",GXType.Decimal,10,2) ,
        new ParDef("@OpcPercepcion",GXType.Decimal,10,2) ,
        new ParDef("@OpcPercepcionAgentes",GXType.Decimal,10,2) ,
        new ParDef("@OpcPedAutNum",GXType.Int16,2,0) ,
        new ParDef("@OpcListaPrecios",GXType.Int16,1,0) ,
        new ParDef("@OpcEntrada",GXType.Int16,1,0) ,
        new ParDef("@OpcStkComp",GXType.Int16,1,0) ,
        new ParDef("@OpcEMailHost",GXType.NChar,100,0) ,
        new ParDef("@OpcEMailSalida",GXType.NChar,100,0) ,
        new ParDef("@OpcEMailUsu",GXType.NChar,100,0) ,
        new ParDef("@OpcEMailPass",GXType.NChar,20,0) ,
        new ParDef("@OpcEmpAgente",GXType.Int16,1,0) ,
        new ParDef("@OpcEMailPort",GXType.Int16,4,0) ,
        new ParDef("@OpcCosIngreso",GXType.Int16,1,0) ,
        new ParDef("@OpcFE",GXType.Int16,1,0) ,
        new ParDef("@OpcFERetencion",GXType.Int16,1,0) ,
        new ParDef("@OpcLetrasGirador",GXType.NVarChar,100,0) ,
        new ParDef("@OpcLetrasLugar",GXType.NVarChar,100,0) ,
        new ParDef("@OpcAutOComNum",GXType.Int16,4,0) ,
        new ParDef("@OpcServerFE",GXType.Int16,1,0) ,
        new ParDef("@OpcCuentaDetraccion",GXType.Int16,4,0) ,
        new ParDef("@OpcPedPrecios",GXType.Int16,1,0) ,
        new ParDef("@OpcPedDescuento",GXType.Int16,1,0) ,
        new ParDef("@OpcPedStock",GXType.Int16,1,0) ,
        new ParDef("@OpcPedVendedor",GXType.Int16,1,0) ,
        new ParDef("@OpcPedMonCod",GXType.Int32,6,0) ,
        new ParDef("@OpcPedCondPago",GXType.Int16,1,0) ,
        new ParDef("@OpcPedLista",GXType.Int16,1,0) ,
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R10;
        prmT000R10 = new Object[] {
        new ParDef("@OpcId",GXType.Int16,1,0)
        };
        Object[] prmT000R11;
        prmT000R11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000R2", "SELECT [OpcId], [OpcStk], [OpcIVA], [OpcEmp], [OpcAutOcom], [OpcAutCompras], [OpcPedAut], [OpcVersion], [OpcRetencion], [OpcPercepcion], [OpcPercepcionAgentes], [OpcPedAutNum], [OpcListaPrecios], [OpcEntrada], [OpcStkComp], [OpcEMailHost], [OpcEMailSalida], [OpcEMailUsu], [OpcEMailPass], [OpcEmpAgente], [OpcEMailPort], [OpcCosIngreso], [OpcFE], [OpcFERetencion], [OpcLetrasGirador], [OpcLetrasLugar], [OpcAutOComNum], [OpcServerFE], [OpcCuentaDetraccion], [OpcPedPrecios], [OpcPedDescuento], [OpcPedStock], [OpcPedVendedor], [OpcPedMonCod], [OpcPedCondPago], [OpcPedLista] FROM [SGOPCIONES] WITH (UPDLOCK) WHERE [OpcId] = @OpcId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R3", "SELECT [OpcId], [OpcStk], [OpcIVA], [OpcEmp], [OpcAutOcom], [OpcAutCompras], [OpcPedAut], [OpcVersion], [OpcRetencion], [OpcPercepcion], [OpcPercepcionAgentes], [OpcPedAutNum], [OpcListaPrecios], [OpcEntrada], [OpcStkComp], [OpcEMailHost], [OpcEMailSalida], [OpcEMailUsu], [OpcEMailPass], [OpcEmpAgente], [OpcEMailPort], [OpcCosIngreso], [OpcFE], [OpcFERetencion], [OpcLetrasGirador], [OpcLetrasLugar], [OpcAutOComNum], [OpcServerFE], [OpcCuentaDetraccion], [OpcPedPrecios], [OpcPedDescuento], [OpcPedStock], [OpcPedVendedor], [OpcPedMonCod], [OpcPedCondPago], [OpcPedLista] FROM [SGOPCIONES] WHERE [OpcId] = @OpcId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R4", "SELECT TM1.[OpcId], TM1.[OpcStk], TM1.[OpcIVA], TM1.[OpcEmp], TM1.[OpcAutOcom], TM1.[OpcAutCompras], TM1.[OpcPedAut], TM1.[OpcVersion], TM1.[OpcRetencion], TM1.[OpcPercepcion], TM1.[OpcPercepcionAgentes], TM1.[OpcPedAutNum], TM1.[OpcListaPrecios], TM1.[OpcEntrada], TM1.[OpcStkComp], TM1.[OpcEMailHost], TM1.[OpcEMailSalida], TM1.[OpcEMailUsu], TM1.[OpcEMailPass], TM1.[OpcEmpAgente], TM1.[OpcEMailPort], TM1.[OpcCosIngreso], TM1.[OpcFE], TM1.[OpcFERetencion], TM1.[OpcLetrasGirador], TM1.[OpcLetrasLugar], TM1.[OpcAutOComNum], TM1.[OpcServerFE], TM1.[OpcCuentaDetraccion], TM1.[OpcPedPrecios], TM1.[OpcPedDescuento], TM1.[OpcPedStock], TM1.[OpcPedVendedor], TM1.[OpcPedMonCod], TM1.[OpcPedCondPago], TM1.[OpcPedLista] FROM [SGOPCIONES] TM1 WHERE TM1.[OpcId] = @OpcId ORDER BY TM1.[OpcId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R5", "SELECT [OpcId] FROM [SGOPCIONES] WHERE [OpcId] = @OpcId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R6", "SELECT TOP 1 [OpcId] FROM [SGOPCIONES] WHERE ( [OpcId] > @OpcId) ORDER BY [OpcId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R7", "SELECT TOP 1 [OpcId] FROM [SGOPCIONES] WHERE ( [OpcId] < @OpcId) ORDER BY [OpcId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R8", "INSERT INTO [SGOPCIONES]([OpcId], [OpcStk], [OpcIVA], [OpcEmp], [OpcAutOcom], [OpcAutCompras], [OpcPedAut], [OpcVersion], [OpcRetencion], [OpcPercepcion], [OpcPercepcionAgentes], [OpcPedAutNum], [OpcListaPrecios], [OpcEntrada], [OpcStkComp], [OpcEMailHost], [OpcEMailSalida], [OpcEMailUsu], [OpcEMailPass], [OpcEmpAgente], [OpcEMailPort], [OpcCosIngreso], [OpcFE], [OpcFERetencion], [OpcLetrasGirador], [OpcLetrasLugar], [OpcAutOComNum], [OpcServerFE], [OpcCuentaDetraccion], [OpcPedPrecios], [OpcPedDescuento], [OpcPedStock], [OpcPedVendedor], [OpcPedMonCod], [OpcPedCondPago], [OpcPedLista]) VALUES(@OpcId, @OpcStk, @OpcIVA, @OpcEmp, @OpcAutOcom, @OpcAutCompras, @OpcPedAut, @OpcVersion, @OpcRetencion, @OpcPercepcion, @OpcPercepcionAgentes, @OpcPedAutNum, @OpcListaPrecios, @OpcEntrada, @OpcStkComp, @OpcEMailHost, @OpcEMailSalida, @OpcEMailUsu, @OpcEMailPass, @OpcEmpAgente, @OpcEMailPort, @OpcCosIngreso, @OpcFE, @OpcFERetencion, @OpcLetrasGirador, @OpcLetrasLugar, @OpcAutOComNum, @OpcServerFE, @OpcCuentaDetraccion, @OpcPedPrecios, @OpcPedDescuento, @OpcPedStock, @OpcPedVendedor, @OpcPedMonCod, @OpcPedCondPago, @OpcPedLista)", GxErrorMask.GX_NOMASK,prmT000R8)
           ,new CursorDef("T000R9", "UPDATE [SGOPCIONES] SET [OpcStk]=@OpcStk, [OpcIVA]=@OpcIVA, [OpcEmp]=@OpcEmp, [OpcAutOcom]=@OpcAutOcom, [OpcAutCompras]=@OpcAutCompras, [OpcPedAut]=@OpcPedAut, [OpcVersion]=@OpcVersion, [OpcRetencion]=@OpcRetencion, [OpcPercepcion]=@OpcPercepcion, [OpcPercepcionAgentes]=@OpcPercepcionAgentes, [OpcPedAutNum]=@OpcPedAutNum, [OpcListaPrecios]=@OpcListaPrecios, [OpcEntrada]=@OpcEntrada, [OpcStkComp]=@OpcStkComp, [OpcEMailHost]=@OpcEMailHost, [OpcEMailSalida]=@OpcEMailSalida, [OpcEMailUsu]=@OpcEMailUsu, [OpcEMailPass]=@OpcEMailPass, [OpcEmpAgente]=@OpcEmpAgente, [OpcEMailPort]=@OpcEMailPort, [OpcCosIngreso]=@OpcCosIngreso, [OpcFE]=@OpcFE, [OpcFERetencion]=@OpcFERetencion, [OpcLetrasGirador]=@OpcLetrasGirador, [OpcLetrasLugar]=@OpcLetrasLugar, [OpcAutOComNum]=@OpcAutOComNum, [OpcServerFE]=@OpcServerFE, [OpcCuentaDetraccion]=@OpcCuentaDetraccion, [OpcPedPrecios]=@OpcPedPrecios, [OpcPedDescuento]=@OpcPedDescuento, [OpcPedStock]=@OpcPedStock, [OpcPedVendedor]=@OpcPedVendedor, [OpcPedMonCod]=@OpcPedMonCod, [OpcPedCondPago]=@OpcPedCondPago, [OpcPedLista]=@OpcPedLista  WHERE [OpcId] = @OpcId", GxErrorMask.GX_NOMASK,prmT000R9)
           ,new CursorDef("T000R10", "DELETE FROM [SGOPCIONES]  WHERE [OpcId] = @OpcId", GxErrorMask.GX_NOMASK,prmT000R10)
           ,new CursorDef("T000R11", "SELECT [OpcId] FROM [SGOPCIONES] ORDER BY [OpcId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R11,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((short[]) buf[19])[0] = rslt.getShort(20);
              ((short[]) buf[20])[0] = rslt.getShort(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((short[]) buf[28])[0] = rslt.getShort(29);
              ((short[]) buf[29])[0] = rslt.getShort(30);
              ((short[]) buf[30])[0] = rslt.getShort(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((short[]) buf[32])[0] = rslt.getShort(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((short[]) buf[34])[0] = rslt.getShort(35);
              ((short[]) buf[35])[0] = rslt.getShort(36);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((short[]) buf[19])[0] = rslt.getShort(20);
              ((short[]) buf[20])[0] = rslt.getShort(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((short[]) buf[28])[0] = rslt.getShort(29);
              ((short[]) buf[29])[0] = rslt.getShort(30);
              ((short[]) buf[30])[0] = rslt.getShort(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((short[]) buf[32])[0] = rslt.getShort(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((short[]) buf[34])[0] = rslt.getShort(35);
              ((short[]) buf[35])[0] = rslt.getShort(36);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((short[]) buf[19])[0] = rslt.getShort(20);
              ((short[]) buf[20])[0] = rslt.getShort(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((short[]) buf[28])[0] = rslt.getShort(29);
              ((short[]) buf[29])[0] = rslt.getShort(30);
              ((short[]) buf[30])[0] = rslt.getShort(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((short[]) buf[32])[0] = rslt.getShort(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((short[]) buf[34])[0] = rslt.getShort(35);
              ((short[]) buf[35])[0] = rslt.getShort(36);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
