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
   public class cbflujotitulodet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A2269CBFlujTip = GetPar( "CBFlujTip");
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = GetPar( "CBFlujCod");
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2269CBFlujTip, A2270CBFlujCod) ;
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
            Form.Meta.addItem("description", "Conceptos de Flujo de Caja", 0) ;
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

      public cbflujotitulodet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbflujotitulodet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Conceptos de Flujo de Caja", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBFLUJOTITULODET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBFLUJOTITULODET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujTip_Internalname, StringUtil.RTrim( A2269CBFlujTip), StringUtil.RTrim( context.localUtil.Format( A2269CBFlujTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULODET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCod_Internalname, StringUtil.RTrim( A2270CBFlujCod), StringUtil.RTrim( context.localUtil.Format( A2270CBFlujCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULODET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujDsc_Internalname, StringUtil.RTrim( A2277CBFlujDsc), StringUtil.RTrim( context.localUtil.Format( A2277CBFlujDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCCod_Internalname, "Codigo Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCCod_Internalname, StringUtil.RTrim( A2271CBFlujCCod), StringUtil.RTrim( context.localUtil.Format( A2271CBFlujCCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCDsc_Internalname, "Concepto Flujo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCDsc_Internalname, StringUtil.RTrim( A2276CBFlujCDsc), StringUtil.RTrim( context.localUtil.Format( A2276CBFlujCDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2279CBFlujCSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2279CBFlujCSts), "9") : context.localUtil.Format( (decimal)(A2279CBFlujCSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOTITULODET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOTITULODET.htm");
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
            Z2271CBFlujCCod = cgiGet( "Z2271CBFlujCCod");
            Z2276CBFlujCDsc = cgiGet( "Z2276CBFlujCDsc");
            Z2279CBFlujCSts = (short)(context.localUtil.CToN( cgiGet( "Z2279CBFlujCSts"), ".", ","));
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
            A2271CBFlujCCod = cgiGet( edtCBFlujCCod_Internalname);
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
            A2276CBFlujCDsc = cgiGet( edtCBFlujCDsc_Internalname);
            AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCSTS");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2279CBFlujCSts = 0;
               AssignAttri("", false, "A2279CBFlujCSts", StringUtil.Str( (decimal)(A2279CBFlujCSts), 1, 0));
            }
            else
            {
               A2279CBFlujCSts = (short)(context.localUtil.CToN( cgiGet( edtCBFlujCSts_Internalname), ".", ","));
               AssignAttri("", false, "A2279CBFlujCSts", StringUtil.Str( (decimal)(A2279CBFlujCSts), 1, 0));
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
               A2271CBFlujCCod = GetPar( "CBFlujCCod");
               AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
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
               InitAll7F203( ) ;
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
         DisableAttributes7F203( ) ;
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

      protected void ResetCaption7F0( )
      {
      }

      protected void ZM7F203( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2276CBFlujCDsc = T007F3_A2276CBFlujCDsc[0];
               Z2279CBFlujCSts = T007F3_A2279CBFlujCSts[0];
            }
            else
            {
               Z2276CBFlujCDsc = A2276CBFlujCDsc;
               Z2279CBFlujCSts = A2279CBFlujCSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2271CBFlujCCod = A2271CBFlujCCod;
            Z2276CBFlujCDsc = A2276CBFlujCDsc;
            Z2279CBFlujCSts = A2279CBFlujCSts;
            Z2269CBFlujTip = A2269CBFlujTip;
            Z2270CBFlujCod = A2270CBFlujCod;
            Z2277CBFlujDsc = A2277CBFlujDsc;
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

      protected void Load7F203( )
      {
         /* Using cursor T007F5 */
         pr_default.execute(3, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound203 = 1;
            A2277CBFlujDsc = T007F5_A2277CBFlujDsc[0];
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            A2276CBFlujCDsc = T007F5_A2276CBFlujCDsc[0];
            AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
            A2279CBFlujCSts = T007F5_A2279CBFlujCSts[0];
            AssignAttri("", false, "A2279CBFlujCSts", StringUtil.Str( (decimal)(A2279CBFlujCSts), 1, 0));
            ZM7F203( -1) ;
         }
         pr_default.close(3);
         OnLoadActions7F203( ) ;
      }

      protected void OnLoadActions7F203( )
      {
      }

      protected void CheckExtendedTable7F203( )
      {
         nIsDirty_203 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007F4 */
         pr_default.execute(2, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2277CBFlujDsc = T007F4_A2277CBFlujDsc[0];
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7F203( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A2269CBFlujTip ,
                               string A2270CBFlujCod )
      {
         /* Using cursor T007F6 */
         pr_default.execute(4, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2277CBFlujDsc = T007F6_A2277CBFlujDsc[0];
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2277CBFlujDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey7F203( )
      {
         /* Using cursor T007F7 */
         pr_default.execute(5, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound203 = 1;
         }
         else
         {
            RcdFound203 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007F3 */
         pr_default.execute(1, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7F203( 1) ;
            RcdFound203 = 1;
            A2271CBFlujCCod = T007F3_A2271CBFlujCCod[0];
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
            A2276CBFlujCDsc = T007F3_A2276CBFlujCDsc[0];
            AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
            A2279CBFlujCSts = T007F3_A2279CBFlujCSts[0];
            AssignAttri("", false, "A2279CBFlujCSts", StringUtil.Str( (decimal)(A2279CBFlujCSts), 1, 0));
            A2269CBFlujTip = T007F3_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007F3_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            Z2269CBFlujTip = A2269CBFlujTip;
            Z2270CBFlujCod = A2270CBFlujCod;
            Z2271CBFlujCCod = A2271CBFlujCCod;
            sMode203 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7F203( ) ;
            if ( AnyError == 1 )
            {
               RcdFound203 = 0;
               InitializeNonKey7F203( ) ;
            }
            Gx_mode = sMode203;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound203 = 0;
            InitializeNonKey7F203( ) ;
            sMode203 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode203;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7F203( ) ;
         if ( RcdFound203 == 0 )
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
         RcdFound203 = 0;
         /* Using cursor T007F8 */
         pr_default.execute(6, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T007F8_A2269CBFlujTip[0], A2269CBFlujTip) < 0 ) || ( StringUtil.StrCmp(T007F8_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F8_A2270CBFlujCod[0], A2270CBFlujCod) < 0 ) || ( StringUtil.StrCmp(T007F8_A2270CBFlujCod[0], A2270CBFlujCod) == 0 ) && ( StringUtil.StrCmp(T007F8_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F8_A2271CBFlujCCod[0], A2271CBFlujCCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T007F8_A2269CBFlujTip[0], A2269CBFlujTip) > 0 ) || ( StringUtil.StrCmp(T007F8_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F8_A2270CBFlujCod[0], A2270CBFlujCod) > 0 ) || ( StringUtil.StrCmp(T007F8_A2270CBFlujCod[0], A2270CBFlujCod) == 0 ) && ( StringUtil.StrCmp(T007F8_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F8_A2271CBFlujCCod[0], A2271CBFlujCCod) > 0 ) ) )
            {
               A2269CBFlujTip = T007F8_A2269CBFlujTip[0];
               AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
               A2270CBFlujCod = T007F8_A2270CBFlujCod[0];
               AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
               A2271CBFlujCCod = T007F8_A2271CBFlujCCod[0];
               AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
               RcdFound203 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound203 = 0;
         /* Using cursor T007F9 */
         pr_default.execute(7, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T007F9_A2269CBFlujTip[0], A2269CBFlujTip) > 0 ) || ( StringUtil.StrCmp(T007F9_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F9_A2270CBFlujCod[0], A2270CBFlujCod) > 0 ) || ( StringUtil.StrCmp(T007F9_A2270CBFlujCod[0], A2270CBFlujCod) == 0 ) && ( StringUtil.StrCmp(T007F9_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F9_A2271CBFlujCCod[0], A2271CBFlujCCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T007F9_A2269CBFlujTip[0], A2269CBFlujTip) < 0 ) || ( StringUtil.StrCmp(T007F9_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F9_A2270CBFlujCod[0], A2270CBFlujCod) < 0 ) || ( StringUtil.StrCmp(T007F9_A2270CBFlujCod[0], A2270CBFlujCod) == 0 ) && ( StringUtil.StrCmp(T007F9_A2269CBFlujTip[0], A2269CBFlujTip) == 0 ) && ( StringUtil.StrCmp(T007F9_A2271CBFlujCCod[0], A2271CBFlujCCod) < 0 ) ) )
            {
               A2269CBFlujTip = T007F9_A2269CBFlujTip[0];
               AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
               A2270CBFlujCod = T007F9_A2270CBFlujCod[0];
               AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
               A2271CBFlujCCod = T007F9_A2271CBFlujCCod[0];
               AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
               RcdFound203 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7F203( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7F203( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound203 == 1 )
            {
               if ( ( StringUtil.StrCmp(A2269CBFlujTip, Z2269CBFlujTip) != 0 ) || ( StringUtil.StrCmp(A2270CBFlujCod, Z2270CBFlujCod) != 0 ) || ( StringUtil.StrCmp(A2271CBFlujCCod, Z2271CBFlujCCod) != 0 ) )
               {
                  A2269CBFlujTip = Z2269CBFlujTip;
                  AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
                  A2270CBFlujCod = Z2270CBFlujCod;
                  AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
                  A2271CBFlujCCod = Z2271CBFlujCCod;
                  AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
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
                  Update7F203( ) ;
                  GX_FocusControl = edtCBFlujTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A2269CBFlujTip, Z2269CBFlujTip) != 0 ) || ( StringUtil.StrCmp(A2270CBFlujCod, Z2270CBFlujCod) != 0 ) || ( StringUtil.StrCmp(A2271CBFlujCCod, Z2271CBFlujCCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBFlujTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7F203( ) ;
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
                     Insert7F203( ) ;
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
         if ( ( StringUtil.StrCmp(A2269CBFlujTip, Z2269CBFlujTip) != 0 ) || ( StringUtil.StrCmp(A2270CBFlujCod, Z2270CBFlujCod) != 0 ) || ( StringUtil.StrCmp(A2271CBFlujCCod, Z2271CBFlujCCod) != 0 ) )
         {
            A2269CBFlujTip = Z2269CBFlujTip;
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = Z2270CBFlujCod;
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2271CBFlujCCod = Z2271CBFlujCCod;
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
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
         if ( RcdFound203 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBFLUJTIP");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBFlujCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7F203( ) ;
         if ( RcdFound203 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7F203( ) ;
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
         if ( RcdFound203 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCDsc_Internalname;
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
         if ( RcdFound203 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCDsc_Internalname;
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
         ScanStart7F203( ) ;
         if ( RcdFound203 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound203 != 0 )
            {
               ScanNext7F203( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7F203( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7F203( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007F2 */
            pr_default.execute(0, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOTITULODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2276CBFlujCDsc, T007F2_A2276CBFlujCDsc[0]) != 0 ) || ( Z2279CBFlujCSts != T007F2_A2279CBFlujCSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2276CBFlujCDsc, T007F2_A2276CBFlujCDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbflujotitulodet:[seudo value changed for attri]"+"CBFlujCDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2276CBFlujCDsc);
                  GXUtil.WriteLogRaw("Current: ",T007F2_A2276CBFlujCDsc[0]);
               }
               if ( Z2279CBFlujCSts != T007F2_A2279CBFlujCSts[0] )
               {
                  GXUtil.WriteLog("cbflujotitulodet:[seudo value changed for attri]"+"CBFlujCSts");
                  GXUtil.WriteLogRaw("Old: ",Z2279CBFlujCSts);
                  GXUtil.WriteLogRaw("Current: ",T007F2_A2279CBFlujCSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBFLUJOTITULODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7F203( )
      {
         BeforeValidate7F203( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7F203( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7F203( 0) ;
            CheckOptimisticConcurrency7F203( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7F203( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7F203( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007F10 */
                     pr_default.execute(8, new Object[] {A2271CBFlujCCod, A2276CBFlujCDsc, A2279CBFlujCSts, A2269CBFlujTip, A2270CBFlujCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOTITULODET");
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
                           ResetCaption7F0( ) ;
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
               Load7F203( ) ;
            }
            EndLevel7F203( ) ;
         }
         CloseExtendedTableCursors7F203( ) ;
      }

      protected void Update7F203( )
      {
         BeforeValidate7F203( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7F203( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7F203( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7F203( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7F203( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007F11 */
                     pr_default.execute(9, new Object[] {A2276CBFlujCDsc, A2279CBFlujCSts, A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOTITULODET");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOTITULODET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7F203( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7F0( ) ;
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
            EndLevel7F203( ) ;
         }
         CloseExtendedTableCursors7F203( ) ;
      }

      protected void DeferredUpdate7F203( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7F203( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7F203( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7F203( ) ;
            AfterConfirm7F203( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7F203( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007F12 */
                  pr_default.execute(10, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOTITULODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound203 == 0 )
                        {
                           InitAll7F203( ) ;
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
                        ResetCaption7F0( ) ;
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
         sMode203 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7F203( ) ;
         Gx_mode = sMode203;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7F203( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007F13 */
            pr_default.execute(11, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
            A2277CBFlujDsc = T007F13_A2277CBFlujDsc[0];
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007F14 */
            pr_default.execute(12, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel7F203( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7F203( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("cbflujotitulodet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("cbflujotitulodet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7F203( )
      {
         /* Using cursor T007F15 */
         pr_default.execute(13);
         RcdFound203 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound203 = 1;
            A2269CBFlujTip = T007F15_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007F15_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2271CBFlujCCod = T007F15_A2271CBFlujCCod[0];
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7F203( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound203 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound203 = 1;
            A2269CBFlujTip = T007F15_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007F15_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2271CBFlujCCod = T007F15_A2271CBFlujCCod[0];
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
         }
      }

      protected void ScanEnd7F203( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm7F203( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7F203( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7F203( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7F203( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7F203( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7F203( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7F203( )
      {
         edtCBFlujTip_Enabled = 0;
         AssignProp("", false, edtCBFlujTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujTip_Enabled), 5, 0), true);
         edtCBFlujCod_Enabled = 0;
         AssignProp("", false, edtCBFlujCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCod_Enabled), 5, 0), true);
         edtCBFlujDsc_Enabled = 0;
         AssignProp("", false, edtCBFlujDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujDsc_Enabled), 5, 0), true);
         edtCBFlujCCod_Enabled = 0;
         AssignProp("", false, edtCBFlujCCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCCod_Enabled), 5, 0), true);
         edtCBFlujCDsc_Enabled = 0;
         AssignProp("", false, edtCBFlujCDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCDsc_Enabled), 5, 0), true);
         edtCBFlujCSts_Enabled = 0;
         AssignProp("", false, edtCBFlujCSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7F203( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271231", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbflujotitulodet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2271CBFlujCCod", StringUtil.RTrim( Z2271CBFlujCCod));
         GxWebStd.gx_hidden_field( context, "Z2276CBFlujCDsc", StringUtil.RTrim( Z2276CBFlujCDsc));
         GxWebStd.gx_hidden_field( context, "Z2279CBFlujCSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2279CBFlujCSts), 1, 0, ".", "")));
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
         return formatLink("cbflujotitulodet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBFLUJOTITULODET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Flujo de Caja" ;
      }

      protected void InitializeNonKey7F203( )
      {
         A2277CBFlujDsc = "";
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         A2276CBFlujCDsc = "";
         AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
         A2279CBFlujCSts = 0;
         AssignAttri("", false, "A2279CBFlujCSts", StringUtil.Str( (decimal)(A2279CBFlujCSts), 1, 0));
         Z2276CBFlujCDsc = "";
         Z2279CBFlujCSts = 0;
      }

      protected void InitAll7F203( )
      {
         A2269CBFlujTip = "";
         AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
         A2270CBFlujCod = "";
         AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
         A2271CBFlujCCod = "";
         AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
         InitializeNonKey7F203( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271236", true, true);
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
         context.AddJavascriptSource("cbflujotitulodet.js", "?202281810271237", false, true);
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
         edtCBFlujCCod_Internalname = "CBFLUJCCOD";
         edtCBFlujCDsc_Internalname = "CBFLUJCDSC";
         edtCBFlujCSts_Internalname = "CBFLUJCSTS";
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
         Form.Caption = "Conceptos de Flujo de Caja";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBFlujCSts_Jsonclick = "";
         edtCBFlujCSts_Enabled = 1;
         edtCBFlujCDsc_Jsonclick = "";
         edtCBFlujCDsc_Enabled = 1;
         edtCBFlujCCod_Jsonclick = "";
         edtCBFlujCCod_Enabled = 1;
         edtCBFlujDsc_Jsonclick = "";
         edtCBFlujDsc_Enabled = 0;
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
         /* Using cursor T007F13 */
         pr_default.execute(11, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2277CBFlujDsc = T007F13_A2277CBFlujDsc[0];
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         pr_default.close(11);
         GX_FocusControl = edtCBFlujCDsc_Internalname;
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
         /* Using cursor T007F13 */
         pr_default.execute(11, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
         }
         A2277CBFlujDsc = T007F13_A2277CBFlujDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2277CBFlujDsc", StringUtil.RTrim( A2277CBFlujDsc));
      }

      public void Valid_Cbflujccod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2276CBFlujCDsc", StringUtil.RTrim( A2276CBFlujCDsc));
         AssignAttri("", false, "A2279CBFlujCSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2279CBFlujCSts), 1, 0, ".", "")));
         AssignAttri("", false, "A2277CBFlujDsc", StringUtil.RTrim( A2277CBFlujDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2269CBFlujTip", StringUtil.RTrim( Z2269CBFlujTip));
         GxWebStd.gx_hidden_field( context, "Z2270CBFlujCod", StringUtil.RTrim( Z2270CBFlujCod));
         GxWebStd.gx_hidden_field( context, "Z2271CBFlujCCod", StringUtil.RTrim( Z2271CBFlujCCod));
         GxWebStd.gx_hidden_field( context, "Z2276CBFlujCDsc", StringUtil.RTrim( Z2276CBFlujCDsc));
         GxWebStd.gx_hidden_field( context, "Z2279CBFlujCSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2279CBFlujCSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2277CBFlujDsc", StringUtil.RTrim( Z2277CBFlujDsc));
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
         setEventMetadata("VALID_CBFLUJCOD","{handler:'Valid_Cbflujcod',iparms:[{av:'A2269CBFlujTip',fld:'CBFLUJTIP',pic:''},{av:'A2270CBFlujCod',fld:'CBFLUJCOD',pic:''},{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''}]");
         setEventMetadata("VALID_CBFLUJCOD",",oparms:[{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''}]}");
         setEventMetadata("VALID_CBFLUJCCOD","{handler:'Valid_Cbflujccod',iparms:[{av:'A2269CBFlujTip',fld:'CBFLUJTIP',pic:''},{av:'A2270CBFlujCod',fld:'CBFLUJCOD',pic:''},{av:'A2271CBFlujCCod',fld:'CBFLUJCCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBFLUJCCOD",",oparms:[{av:'A2276CBFlujCDsc',fld:'CBFLUJCDSC',pic:''},{av:'A2279CBFlujCSts',fld:'CBFLUJCSTS',pic:'9'},{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2269CBFlujTip'},{av:'Z2270CBFlujCod'},{av:'Z2271CBFlujCCod'},{av:'Z2276CBFlujCDsc'},{av:'Z2279CBFlujCSts'},{av:'Z2277CBFlujDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z2269CBFlujTip = "";
         Z2270CBFlujCod = "";
         Z2271CBFlujCCod = "";
         Z2276CBFlujCDsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2269CBFlujTip = "";
         A2270CBFlujCod = "";
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
         A2277CBFlujDsc = "";
         A2271CBFlujCCod = "";
         A2276CBFlujCDsc = "";
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
         Z2277CBFlujDsc = "";
         T007F5_A2271CBFlujCCod = new string[] {""} ;
         T007F5_A2277CBFlujDsc = new string[] {""} ;
         T007F5_A2276CBFlujCDsc = new string[] {""} ;
         T007F5_A2279CBFlujCSts = new short[1] ;
         T007F5_A2269CBFlujTip = new string[] {""} ;
         T007F5_A2270CBFlujCod = new string[] {""} ;
         T007F4_A2277CBFlujDsc = new string[] {""} ;
         T007F6_A2277CBFlujDsc = new string[] {""} ;
         T007F7_A2269CBFlujTip = new string[] {""} ;
         T007F7_A2270CBFlujCod = new string[] {""} ;
         T007F7_A2271CBFlujCCod = new string[] {""} ;
         T007F3_A2271CBFlujCCod = new string[] {""} ;
         T007F3_A2276CBFlujCDsc = new string[] {""} ;
         T007F3_A2279CBFlujCSts = new short[1] ;
         T007F3_A2269CBFlujTip = new string[] {""} ;
         T007F3_A2270CBFlujCod = new string[] {""} ;
         sMode203 = "";
         T007F8_A2269CBFlujTip = new string[] {""} ;
         T007F8_A2270CBFlujCod = new string[] {""} ;
         T007F8_A2271CBFlujCCod = new string[] {""} ;
         T007F9_A2269CBFlujTip = new string[] {""} ;
         T007F9_A2270CBFlujCod = new string[] {""} ;
         T007F9_A2271CBFlujCCod = new string[] {""} ;
         T007F2_A2271CBFlujCCod = new string[] {""} ;
         T007F2_A2276CBFlujCDsc = new string[] {""} ;
         T007F2_A2279CBFlujCSts = new short[1] ;
         T007F2_A2269CBFlujTip = new string[] {""} ;
         T007F2_A2270CBFlujCod = new string[] {""} ;
         T007F13_A2277CBFlujDsc = new string[] {""} ;
         T007F14_A2263CBFlujCAno = new short[1] ;
         T007F14_A2264CBFlujCMes = new short[1] ;
         T007F14_A2265CBFlujCBanCod = new int[1] ;
         T007F14_A2266CBFlujCCuenta = new string[] {""} ;
         T007F14_A2267CBFlujCRegistro = new string[] {""} ;
         T007F14_A2268CBFlujCItem = new int[1] ;
         T007F15_A2269CBFlujTip = new string[] {""} ;
         T007F15_A2270CBFlujCod = new string[] {""} ;
         T007F15_A2271CBFlujCCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2269CBFlujTip = "";
         ZZ2270CBFlujCod = "";
         ZZ2271CBFlujCCod = "";
         ZZ2276CBFlujCDsc = "";
         ZZ2277CBFlujDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbflujotitulodet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbflujotitulodet__default(),
            new Object[][] {
                new Object[] {
               T007F2_A2271CBFlujCCod, T007F2_A2276CBFlujCDsc, T007F2_A2279CBFlujCSts, T007F2_A2269CBFlujTip, T007F2_A2270CBFlujCod
               }
               , new Object[] {
               T007F3_A2271CBFlujCCod, T007F3_A2276CBFlujCDsc, T007F3_A2279CBFlujCSts, T007F3_A2269CBFlujTip, T007F3_A2270CBFlujCod
               }
               , new Object[] {
               T007F4_A2277CBFlujDsc
               }
               , new Object[] {
               T007F5_A2271CBFlujCCod, T007F5_A2277CBFlujDsc, T007F5_A2276CBFlujCDsc, T007F5_A2279CBFlujCSts, T007F5_A2269CBFlujTip, T007F5_A2270CBFlujCod
               }
               , new Object[] {
               T007F6_A2277CBFlujDsc
               }
               , new Object[] {
               T007F7_A2269CBFlujTip, T007F7_A2270CBFlujCod, T007F7_A2271CBFlujCCod
               }
               , new Object[] {
               T007F8_A2269CBFlujTip, T007F8_A2270CBFlujCod, T007F8_A2271CBFlujCCod
               }
               , new Object[] {
               T007F9_A2269CBFlujTip, T007F9_A2270CBFlujCod, T007F9_A2271CBFlujCCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007F13_A2277CBFlujDsc
               }
               , new Object[] {
               T007F14_A2263CBFlujCAno, T007F14_A2264CBFlujCMes, T007F14_A2265CBFlujCBanCod, T007F14_A2266CBFlujCCuenta, T007F14_A2267CBFlujCRegistro, T007F14_A2268CBFlujCItem
               }
               , new Object[] {
               T007F15_A2269CBFlujTip, T007F15_A2270CBFlujCod, T007F15_A2271CBFlujCCod
               }
            }
         );
      }

      private short Z2279CBFlujCSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2279CBFlujCSts ;
      private short GX_JID ;
      private short RcdFound203 ;
      private short nIsDirty_203 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2279CBFlujCSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCBFlujTip_Enabled ;
      private int edtCBFlujCod_Enabled ;
      private int edtCBFlujDsc_Enabled ;
      private int edtCBFlujCCod_Enabled ;
      private int edtCBFlujCDsc_Enabled ;
      private int edtCBFlujCSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z2269CBFlujTip ;
      private string Z2270CBFlujCod ;
      private string Z2271CBFlujCCod ;
      private string Z2276CBFlujCDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2269CBFlujTip ;
      private string A2270CBFlujCod ;
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
      private string edtCBFlujTip_Jsonclick ;
      private string edtCBFlujCod_Internalname ;
      private string edtCBFlujCod_Jsonclick ;
      private string edtCBFlujDsc_Internalname ;
      private string A2277CBFlujDsc ;
      private string edtCBFlujDsc_Jsonclick ;
      private string edtCBFlujCCod_Internalname ;
      private string A2271CBFlujCCod ;
      private string edtCBFlujCCod_Jsonclick ;
      private string edtCBFlujCDsc_Internalname ;
      private string A2276CBFlujCDsc ;
      private string edtCBFlujCDsc_Jsonclick ;
      private string edtCBFlujCSts_Internalname ;
      private string edtCBFlujCSts_Jsonclick ;
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
      private string Z2277CBFlujDsc ;
      private string sMode203 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2269CBFlujTip ;
      private string ZZ2270CBFlujCod ;
      private string ZZ2271CBFlujCCod ;
      private string ZZ2276CBFlujCDsc ;
      private string ZZ2277CBFlujDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007F5_A2271CBFlujCCod ;
      private string[] T007F5_A2277CBFlujDsc ;
      private string[] T007F5_A2276CBFlujCDsc ;
      private short[] T007F5_A2279CBFlujCSts ;
      private string[] T007F5_A2269CBFlujTip ;
      private string[] T007F5_A2270CBFlujCod ;
      private string[] T007F4_A2277CBFlujDsc ;
      private string[] T007F6_A2277CBFlujDsc ;
      private string[] T007F7_A2269CBFlujTip ;
      private string[] T007F7_A2270CBFlujCod ;
      private string[] T007F7_A2271CBFlujCCod ;
      private string[] T007F3_A2271CBFlujCCod ;
      private string[] T007F3_A2276CBFlujCDsc ;
      private short[] T007F3_A2279CBFlujCSts ;
      private string[] T007F3_A2269CBFlujTip ;
      private string[] T007F3_A2270CBFlujCod ;
      private string[] T007F8_A2269CBFlujTip ;
      private string[] T007F8_A2270CBFlujCod ;
      private string[] T007F8_A2271CBFlujCCod ;
      private string[] T007F9_A2269CBFlujTip ;
      private string[] T007F9_A2270CBFlujCod ;
      private string[] T007F9_A2271CBFlujCCod ;
      private string[] T007F2_A2271CBFlujCCod ;
      private string[] T007F2_A2276CBFlujCDsc ;
      private short[] T007F2_A2279CBFlujCSts ;
      private string[] T007F2_A2269CBFlujTip ;
      private string[] T007F2_A2270CBFlujCod ;
      private string[] T007F13_A2277CBFlujDsc ;
      private short[] T007F14_A2263CBFlujCAno ;
      private short[] T007F14_A2264CBFlujCMes ;
      private int[] T007F14_A2265CBFlujCBanCod ;
      private string[] T007F14_A2266CBFlujCCuenta ;
      private string[] T007F14_A2267CBFlujCRegistro ;
      private int[] T007F14_A2268CBFlujCItem ;
      private string[] T007F15_A2269CBFlujTip ;
      private string[] T007F15_A2270CBFlujCod ;
      private string[] T007F15_A2271CBFlujCCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbflujotitulodet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbflujotitulodet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007F5;
        prmT007F5 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F4;
        prmT007F4 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007F6;
        prmT007F6 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007F7;
        prmT007F7 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F3;
        prmT007F3 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F8;
        prmT007F8 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F9;
        prmT007F9 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F2;
        prmT007F2 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F10;
        prmT007F10 = new Object[] {
        new ParDef("@CBFlujCCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCDsc",GXType.NChar,100,0) ,
        new ParDef("@CBFlujCSts",GXType.Int16,1,0) ,
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007F11;
        prmT007F11 = new Object[] {
        new ParDef("@CBFlujCDsc",GXType.NChar,100,0) ,
        new ParDef("@CBFlujCSts",GXType.Int16,1,0) ,
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F12;
        prmT007F12 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F14;
        prmT007F14 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007F15;
        prmT007F15 = new Object[] {
        };
        Object[] prmT007F13;
        prmT007F13 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007F2", "SELECT [CBFlujCCod], [CBFlujCDsc], [CBFlujCSts], [CBFlujTip], [CBFlujCod] FROM [CBFLUJOTITULODET] WITH (UPDLOCK) WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F3", "SELECT [CBFlujCCod], [CBFlujCDsc], [CBFlujCSts], [CBFlujTip], [CBFlujCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F4", "SELECT [CBFlujDsc] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F5", "SELECT TM1.[CBFlujCCod], T2.[CBFlujDsc], TM1.[CBFlujCDsc], TM1.[CBFlujCSts], TM1.[CBFlujTip], TM1.[CBFlujCod] FROM ([CBFLUJOTITULODET] TM1 INNER JOIN [CBFLUJOTITULO] T2 ON T2.[CBFlujTip] = TM1.[CBFlujTip] AND T2.[CBFlujCod] = TM1.[CBFlujCod]) WHERE TM1.[CBFlujTip] = @CBFlujTip and TM1.[CBFlujCod] = @CBFlujCod and TM1.[CBFlujCCod] = @CBFlujCCod ORDER BY TM1.[CBFlujTip], TM1.[CBFlujCod], TM1.[CBFlujCCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007F5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F6", "SELECT [CBFlujDsc] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F7", "SELECT [CBFlujTip], [CBFlujCod], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F8", "SELECT TOP 1 [CBFlujTip], [CBFlujCod], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE ( [CBFlujTip] > @CBFlujTip or [CBFlujTip] = @CBFlujTip and [CBFlujCod] > @CBFlujCod or [CBFlujCod] = @CBFlujCod and [CBFlujTip] = @CBFlujTip and [CBFlujCCod] > @CBFlujCCod) ORDER BY [CBFlujTip], [CBFlujCod], [CBFlujCCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007F8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007F9", "SELECT TOP 1 [CBFlujTip], [CBFlujCod], [CBFlujCCod] FROM [CBFLUJOTITULODET] WHERE ( [CBFlujTip] < @CBFlujTip or [CBFlujTip] = @CBFlujTip and [CBFlujCod] < @CBFlujCod or [CBFlujCod] = @CBFlujCod and [CBFlujTip] = @CBFlujTip and [CBFlujCCod] < @CBFlujCCod) ORDER BY [CBFlujTip] DESC, [CBFlujCod] DESC, [CBFlujCCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007F9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007F10", "INSERT INTO [CBFLUJOTITULODET]([CBFlujCCod], [CBFlujCDsc], [CBFlujCSts], [CBFlujTip], [CBFlujCod]) VALUES(@CBFlujCCod, @CBFlujCDsc, @CBFlujCSts, @CBFlujTip, @CBFlujCod)", GxErrorMask.GX_NOMASK,prmT007F10)
           ,new CursorDef("T007F11", "UPDATE [CBFLUJOTITULODET] SET [CBFlujCDsc]=@CBFlujCDsc, [CBFlujCSts]=@CBFlujCSts  WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod", GxErrorMask.GX_NOMASK,prmT007F11)
           ,new CursorDef("T007F12", "DELETE FROM [CBFLUJOTITULODET]  WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod", GxErrorMask.GX_NOMASK,prmT007F12)
           ,new CursorDef("T007F13", "SELECT [CBFlujDsc] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007F13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007F14", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007F14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007F15", "SELECT [CBFlujTip], [CBFlujCod], [CBFlujCCod] FROM [CBFLUJOTITULODET] ORDER BY [CBFlujTip], [CBFlujCod], [CBFlujCCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007F15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              return;
     }
  }

}

}
