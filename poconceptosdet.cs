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
   public class poconceptosdet : GXDataArea
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
            A313PoConcCod = (int)(NumberUtil.Val( GetPar( "PoConcCod"), "."));
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A313PoConcCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A315PoConcDCueCod = GetPar( "PoConcDCueCod");
            AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A315PoConcDCueCod) ;
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
            Form.Meta.addItem("description", "POCONCEPTOSDET", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poconceptosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poconceptosdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "POCONCEPTOSDET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_POCONCEPTOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POCONCEPTOSDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcCod_Internalname, "Codigo Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A313PoConcCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPoConcCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcDCueCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcDCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcDCueCod_Internalname, StringUtil.RTrim( A315PoConcDCueCod), StringUtil.RTrim( context.localUtil.Format( A315PoConcDCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcDCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcDCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcDCueDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcDCueDsc_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPoConcDCueDsc_Internalname, StringUtil.RTrim( A1647PoConcDCueDsc), StringUtil.RTrim( context.localUtil.Format( A1647PoConcDCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcDCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcDCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcCosCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcCosCod_Internalname, "de Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcCosCod_Internalname, StringUtil.RTrim( A316PoConcCosCod), StringUtil.RTrim( context.localUtil.Format( A316PoConcCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCONCEPTOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOSDET.htm");
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
            Z313PoConcCod = (int)(context.localUtil.CToN( cgiGet( "Z313PoConcCod"), ".", ","));
            Z315PoConcDCueCod = cgiGet( "Z315PoConcDCueCod");
            Z316PoConcCosCod = cgiGet( "Z316PoConcCosCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POCONCCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A313PoConcCod = 0;
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            }
            else
            {
               A313PoConcCod = (int)(context.localUtil.CToN( cgiGet( edtPoConcCod_Internalname), ".", ","));
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            }
            A315PoConcDCueCod = cgiGet( edtPoConcDCueCod_Internalname);
            AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
            A1647PoConcDCueDsc = cgiGet( edtPoConcDCueDsc_Internalname);
            AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
            A316PoConcCosCod = cgiGet( edtPoConcCosCod_Internalname);
            AssignAttri("", false, "A316PoConcCosCod", A316PoConcCosCod);
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
               A313PoConcCod = (int)(NumberUtil.Val( GetPar( "PoConcCod"), "."));
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               A315PoConcDCueCod = GetPar( "PoConcDCueCod");
               AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
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
               InitAll43182( ) ;
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
         DisableAttributes43182( ) ;
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

      protected void ResetCaption430( )
      {
      }

      protected void ZM43182( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z316PoConcCosCod = T00433_A316PoConcCosCod[0];
            }
            else
            {
               Z316PoConcCosCod = A316PoConcCosCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z316PoConcCosCod = A316PoConcCosCod;
            Z313PoConcCod = A313PoConcCod;
            Z315PoConcDCueCod = A315PoConcDCueCod;
            Z1647PoConcDCueDsc = A1647PoConcDCueDsc;
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

      protected void Load43182( )
      {
         /* Using cursor T00436 */
         pr_default.execute(4, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound182 = 1;
            A1647PoConcDCueDsc = T00436_A1647PoConcDCueDsc[0];
            AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
            A316PoConcCosCod = T00436_A316PoConcCosCod[0];
            AssignAttri("", false, "A316PoConcCosCod", A316PoConcCosCod);
            ZM43182( -1) ;
         }
         pr_default.close(4);
         OnLoadActions43182( ) ;
      }

      protected void OnLoadActions43182( )
      {
      }

      protected void CheckExtendedTable43182( )
      {
         nIsDirty_182 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00434 */
         pr_default.execute(2, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'POCONCEPTOS'.", "ForeignKeyNotFound", 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00435 */
         pr_default.execute(3, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, "POCONCDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T00435_A1647PoConcDCueDsc[0];
         AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors43182( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A313PoConcCod )
      {
         /* Using cursor T00437 */
         pr_default.execute(5, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'POCONCEPTOS'.", "ForeignKeyNotFound", 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_3( string A315PoConcDCueCod )
      {
         /* Using cursor T00438 */
         pr_default.execute(6, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, "POCONCDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T00438_A1647PoConcDCueDsc[0];
         AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1647PoConcDCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey43182( )
      {
         /* Using cursor T00439 */
         pr_default.execute(7, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound182 = 1;
         }
         else
         {
            RcdFound182 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00433 */
         pr_default.execute(1, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM43182( 1) ;
            RcdFound182 = 1;
            A316PoConcCosCod = T00433_A316PoConcCosCod[0];
            AssignAttri("", false, "A316PoConcCosCod", A316PoConcCosCod);
            A313PoConcCod = T00433_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            A315PoConcDCueCod = T00433_A315PoConcDCueCod[0];
            AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
            Z313PoConcCod = A313PoConcCod;
            Z315PoConcDCueCod = A315PoConcDCueCod;
            sMode182 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load43182( ) ;
            if ( AnyError == 1 )
            {
               RcdFound182 = 0;
               InitializeNonKey43182( ) ;
            }
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound182 = 0;
            InitializeNonKey43182( ) ;
            sMode182 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey43182( ) ;
         if ( RcdFound182 == 0 )
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
         RcdFound182 = 0;
         /* Using cursor T004310 */
         pr_default.execute(8, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T004310_A313PoConcCod[0] < A313PoConcCod ) || ( T004310_A313PoConcCod[0] == A313PoConcCod ) && ( StringUtil.StrCmp(T004310_A315PoConcDCueCod[0], A315PoConcDCueCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T004310_A313PoConcCod[0] > A313PoConcCod ) || ( T004310_A313PoConcCod[0] == A313PoConcCod ) && ( StringUtil.StrCmp(T004310_A315PoConcDCueCod[0], A315PoConcDCueCod) > 0 ) ) )
            {
               A313PoConcCod = T004310_A313PoConcCod[0];
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               A315PoConcDCueCod = T004310_A315PoConcDCueCod[0];
               AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
               RcdFound182 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound182 = 0;
         /* Using cursor T004311 */
         pr_default.execute(9, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T004311_A313PoConcCod[0] > A313PoConcCod ) || ( T004311_A313PoConcCod[0] == A313PoConcCod ) && ( StringUtil.StrCmp(T004311_A315PoConcDCueCod[0], A315PoConcDCueCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T004311_A313PoConcCod[0] < A313PoConcCod ) || ( T004311_A313PoConcCod[0] == A313PoConcCod ) && ( StringUtil.StrCmp(T004311_A315PoConcDCueCod[0], A315PoConcDCueCod) < 0 ) ) )
            {
               A313PoConcCod = T004311_A313PoConcCod[0];
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               A315PoConcDCueCod = T004311_A315PoConcDCueCod[0];
               AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
               RcdFound182 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey43182( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert43182( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound182 == 1 )
            {
               if ( ( A313PoConcCod != Z313PoConcCod ) || ( StringUtil.StrCmp(A315PoConcDCueCod, Z315PoConcDCueCod) != 0 ) )
               {
                  A313PoConcCod = Z313PoConcCod;
                  AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
                  A315PoConcDCueCod = Z315PoConcDCueCod;
                  AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "POCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update43182( ) ;
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A313PoConcCod != Z313PoConcCod ) || ( StringUtil.StrCmp(A315PoConcDCueCod, Z315PoConcDCueCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert43182( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "POCONCCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPoConcCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPoConcCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert43182( ) ;
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
         if ( ( A313PoConcCod != Z313PoConcCod ) || ( StringUtil.StrCmp(A315PoConcDCueCod, Z315PoConcDCueCod) != 0 ) )
         {
            A313PoConcCod = Z313PoConcCod;
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            A315PoConcDCueCod = Z315PoConcDCueCod;
            AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPoConcCod_Internalname;
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
         if ( RcdFound182 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPoConcCosCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart43182( ) ;
         if ( RcdFound182 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcCosCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd43182( ) ;
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
         if ( RcdFound182 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcCosCod_Internalname;
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
         if ( RcdFound182 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcCosCod_Internalname;
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
         ScanStart43182( ) ;
         if ( RcdFound182 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound182 != 0 )
            {
               ScanNext43182( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcCosCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd43182( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency43182( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00432 */
            pr_default.execute(0, new Object[] {A313PoConcCod, A315PoConcDCueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z316PoConcCosCod, T00432_A316PoConcCosCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z316PoConcCosCod, T00432_A316PoConcCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poconceptosdet:[seudo value changed for attri]"+"PoConcCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z316PoConcCosCod);
                  GXUtil.WriteLogRaw("Current: ",T00432_A316PoConcCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCONCEPTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert43182( )
      {
         BeforeValidate43182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable43182( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM43182( 0) ;
            CheckOptimisticConcurrency43182( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm43182( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert43182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004312 */
                     pr_default.execute(10, new Object[] {A316PoConcCosCod, A313PoConcCod, A315PoConcDCueCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
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
                           ResetCaption430( ) ;
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
               Load43182( ) ;
            }
            EndLevel43182( ) ;
         }
         CloseExtendedTableCursors43182( ) ;
      }

      protected void Update43182( )
      {
         BeforeValidate43182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable43182( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency43182( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm43182( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate43182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004313 */
                     pr_default.execute(11, new Object[] {A316PoConcCosCod, A313PoConcCod, A315PoConcDCueCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate43182( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption430( ) ;
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
            EndLevel43182( ) ;
         }
         CloseExtendedTableCursors43182( ) ;
      }

      protected void DeferredUpdate43182( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate43182( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency43182( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls43182( ) ;
            AfterConfirm43182( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete43182( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004314 */
                  pr_default.execute(12, new Object[] {A313PoConcCod, A315PoConcDCueCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound182 == 0 )
                        {
                           InitAll43182( ) ;
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
                        ResetCaption430( ) ;
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
         sMode182 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel43182( ) ;
         Gx_mode = sMode182;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls43182( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004315 */
            pr_default.execute(13, new Object[] {A315PoConcDCueCod});
            A1647PoConcDCueDsc = T004315_A1647PoConcDCueDsc[0];
            AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
            pr_default.close(13);
         }
      }

      protected void EndLevel43182( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete43182( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("poconceptosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues430( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("poconceptosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart43182( )
      {
         /* Using cursor T004316 */
         pr_default.execute(14);
         RcdFound182 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound182 = 1;
            A313PoConcCod = T004316_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            A315PoConcDCueCod = T004316_A315PoConcDCueCod[0];
            AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext43182( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound182 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound182 = 1;
            A313PoConcCod = T004316_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            A315PoConcDCueCod = T004316_A315PoConcDCueCod[0];
            AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
         }
      }

      protected void ScanEnd43182( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm43182( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert43182( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate43182( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete43182( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete43182( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate43182( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes43182( )
      {
         edtPoConcCod_Enabled = 0;
         AssignProp("", false, edtPoConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Enabled), 5, 0), true);
         edtPoConcDCueCod_Enabled = 0;
         AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), true);
         edtPoConcDCueDsc_Enabled = 0;
         AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), true);
         edtPoConcCosCod_Enabled = 0;
         AssignProp("", false, edtPoConcCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCosCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes43182( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues430( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252692", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("poconceptosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z313PoConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z313PoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z315PoConcDCueCod", StringUtil.RTrim( Z315PoConcDCueCod));
         GxWebStd.gx_hidden_field( context, "Z316PoConcCosCod", StringUtil.RTrim( Z316PoConcCosCod));
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
         return formatLink("poconceptosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POCONCEPTOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "POCONCEPTOSDET" ;
      }

      protected void InitializeNonKey43182( )
      {
         A1647PoConcDCueDsc = "";
         AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
         A316PoConcCosCod = "";
         AssignAttri("", false, "A316PoConcCosCod", A316PoConcCosCod);
         Z316PoConcCosCod = "";
      }

      protected void InitAll43182( )
      {
         A313PoConcCod = 0;
         AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         A315PoConcDCueCod = "";
         AssignAttri("", false, "A315PoConcDCueCod", A315PoConcDCueCod);
         InitializeNonKey43182( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252696", true, true);
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
         context.AddJavascriptSource("poconceptosdet.js", "?202281810252697", false, true);
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
         edtPoConcCod_Internalname = "POCONCCOD";
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD";
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC";
         edtPoConcCosCod_Internalname = "POCONCCOSCOD";
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
         Form.Caption = "POCONCEPTOSDET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPoConcCosCod_Jsonclick = "";
         edtPoConcCosCod_Enabled = 1;
         edtPoConcDCueDsc_Jsonclick = "";
         edtPoConcDCueDsc_Enabled = 0;
         edtPoConcDCueCod_Jsonclick = "";
         edtPoConcDCueCod_Enabled = 1;
         edtPoConcCod_Jsonclick = "";
         edtPoConcCod_Enabled = 1;
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
         /* Using cursor T004317 */
         pr_default.execute(15, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'POCONCEPTOS'.", "ForeignKeyNotFound", 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         /* Using cursor T004315 */
         pr_default.execute(13, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, "POCONCDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T004315_A1647PoConcDCueDsc[0];
         AssignAttri("", false, "A1647PoConcDCueDsc", A1647PoConcDCueDsc);
         pr_default.close(13);
         GX_FocusControl = edtPoConcCosCod_Internalname;
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

      public void Valid_Poconccod( )
      {
         /* Using cursor T004317 */
         pr_default.execute(15, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'POCONCEPTOS'.", "ForeignKeyNotFound", 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Poconcdcuecod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T004315 */
         pr_default.execute(13, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, "POCONCDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
         }
         A1647PoConcDCueDsc = T004315_A1647PoConcDCueDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A316PoConcCosCod", StringUtil.RTrim( A316PoConcCosCod));
         AssignAttri("", false, "A1647PoConcDCueDsc", StringUtil.RTrim( A1647PoConcDCueDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z313PoConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z313PoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z315PoConcDCueCod", StringUtil.RTrim( Z315PoConcDCueCod));
         GxWebStd.gx_hidden_field( context, "Z316PoConcCosCod", StringUtil.RTrim( Z316PoConcCosCod));
         GxWebStd.gx_hidden_field( context, "Z1647PoConcDCueDsc", StringUtil.RTrim( Z1647PoConcDCueDsc));
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
         setEventMetadata("VALID_POCONCCOD","{handler:'Valid_Poconccod',iparms:[{av:'A313PoConcCod',fld:'POCONCCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_POCONCCOD",",oparms:[]}");
         setEventMetadata("VALID_POCONCDCUECOD","{handler:'Valid_Poconcdcuecod',iparms:[{av:'A313PoConcCod',fld:'POCONCCOD',pic:'ZZZZZ9'},{av:'A315PoConcDCueCod',fld:'POCONCDCUECOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_POCONCDCUECOD",",oparms:[{av:'A316PoConcCosCod',fld:'POCONCCOSCOD',pic:''},{av:'A1647PoConcDCueDsc',fld:'POCONCDCUEDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z313PoConcCod'},{av:'Z315PoConcDCueCod'},{av:'Z316PoConcCosCod'},{av:'Z1647PoConcDCueDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z315PoConcDCueCod = "";
         Z316PoConcCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A315PoConcDCueCod = "";
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
         A1647PoConcDCueDsc = "";
         A316PoConcCosCod = "";
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
         Z1647PoConcDCueDsc = "";
         T00436_A1647PoConcDCueDsc = new string[] {""} ;
         T00436_A316PoConcCosCod = new string[] {""} ;
         T00436_A313PoConcCod = new int[1] ;
         T00436_A315PoConcDCueCod = new string[] {""} ;
         T00434_A313PoConcCod = new int[1] ;
         T00435_A1647PoConcDCueDsc = new string[] {""} ;
         T00437_A313PoConcCod = new int[1] ;
         T00438_A1647PoConcDCueDsc = new string[] {""} ;
         T00439_A313PoConcCod = new int[1] ;
         T00439_A315PoConcDCueCod = new string[] {""} ;
         T00433_A316PoConcCosCod = new string[] {""} ;
         T00433_A313PoConcCod = new int[1] ;
         T00433_A315PoConcDCueCod = new string[] {""} ;
         sMode182 = "";
         T004310_A313PoConcCod = new int[1] ;
         T004310_A315PoConcDCueCod = new string[] {""} ;
         T004311_A313PoConcCod = new int[1] ;
         T004311_A315PoConcDCueCod = new string[] {""} ;
         T00432_A316PoConcCosCod = new string[] {""} ;
         T00432_A313PoConcCod = new int[1] ;
         T00432_A315PoConcDCueCod = new string[] {""} ;
         T004315_A1647PoConcDCueDsc = new string[] {""} ;
         T004316_A313PoConcCod = new int[1] ;
         T004316_A315PoConcDCueCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004317_A313PoConcCod = new int[1] ;
         ZZ315PoConcDCueCod = "";
         ZZ316PoConcCosCod = "";
         ZZ1647PoConcDCueDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poconceptosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poconceptosdet__default(),
            new Object[][] {
                new Object[] {
               T00432_A316PoConcCosCod, T00432_A313PoConcCod, T00432_A315PoConcDCueCod
               }
               , new Object[] {
               T00433_A316PoConcCosCod, T00433_A313PoConcCod, T00433_A315PoConcDCueCod
               }
               , new Object[] {
               T00434_A313PoConcCod
               }
               , new Object[] {
               T00435_A1647PoConcDCueDsc
               }
               , new Object[] {
               T00436_A1647PoConcDCueDsc, T00436_A316PoConcCosCod, T00436_A313PoConcCod, T00436_A315PoConcDCueCod
               }
               , new Object[] {
               T00437_A313PoConcCod
               }
               , new Object[] {
               T00438_A1647PoConcDCueDsc
               }
               , new Object[] {
               T00439_A313PoConcCod, T00439_A315PoConcDCueCod
               }
               , new Object[] {
               T004310_A313PoConcCod, T004310_A315PoConcDCueCod
               }
               , new Object[] {
               T004311_A313PoConcCod, T004311_A315PoConcDCueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004315_A1647PoConcDCueDsc
               }
               , new Object[] {
               T004316_A313PoConcCod, T004316_A315PoConcDCueCod
               }
               , new Object[] {
               T004317_A313PoConcCod
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
      private short RcdFound182 ;
      private short nIsDirty_182 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z313PoConcCod ;
      private int A313PoConcCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPoConcCod_Enabled ;
      private int edtPoConcDCueCod_Enabled ;
      private int edtPoConcDCueDsc_Enabled ;
      private int edtPoConcCosCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ313PoConcCod ;
      private string sPrefix ;
      private string Z315PoConcDCueCod ;
      private string Z316PoConcCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A315PoConcDCueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPoConcCod_Internalname ;
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
      private string edtPoConcCod_Jsonclick ;
      private string edtPoConcDCueCod_Internalname ;
      private string edtPoConcDCueCod_Jsonclick ;
      private string edtPoConcDCueDsc_Internalname ;
      private string A1647PoConcDCueDsc ;
      private string edtPoConcDCueDsc_Jsonclick ;
      private string edtPoConcCosCod_Internalname ;
      private string A316PoConcCosCod ;
      private string edtPoConcCosCod_Jsonclick ;
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
      private string Z1647PoConcDCueDsc ;
      private string sMode182 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ315PoConcDCueCod ;
      private string ZZ316PoConcCosCod ;
      private string ZZ1647PoConcDCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00436_A1647PoConcDCueDsc ;
      private string[] T00436_A316PoConcCosCod ;
      private int[] T00436_A313PoConcCod ;
      private string[] T00436_A315PoConcDCueCod ;
      private int[] T00434_A313PoConcCod ;
      private string[] T00435_A1647PoConcDCueDsc ;
      private int[] T00437_A313PoConcCod ;
      private string[] T00438_A1647PoConcDCueDsc ;
      private int[] T00439_A313PoConcCod ;
      private string[] T00439_A315PoConcDCueCod ;
      private string[] T00433_A316PoConcCosCod ;
      private int[] T00433_A313PoConcCod ;
      private string[] T00433_A315PoConcDCueCod ;
      private int[] T004310_A313PoConcCod ;
      private string[] T004310_A315PoConcDCueCod ;
      private int[] T004311_A313PoConcCod ;
      private string[] T004311_A315PoConcDCueCod ;
      private string[] T00432_A316PoConcCosCod ;
      private int[] T00432_A313PoConcCod ;
      private string[] T00432_A315PoConcDCueCod ;
      private string[] T004315_A1647PoConcDCueDsc ;
      private int[] T004316_A313PoConcCod ;
      private string[] T004316_A315PoConcDCueCod ;
      private int[] T004317_A313PoConcCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poconceptosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poconceptosdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00436;
        prmT00436 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00434;
        prmT00434 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT00435;
        prmT00435 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00437;
        prmT00437 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT00438;
        prmT00438 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00439;
        prmT00439 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00433;
        prmT00433 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004310;
        prmT004310 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004311;
        prmT004311 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00432;
        prmT00432 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004312;
        prmT004312 = new Object[] {
        new ParDef("@PoConcCosCod",GXType.NChar,10,0) ,
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004313;
        prmT004313 = new Object[] {
        new ParDef("@PoConcCosCod",GXType.NChar,10,0) ,
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004314;
        prmT004314 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004316;
        prmT004316 = new Object[] {
        };
        Object[] prmT004317;
        prmT004317 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004315;
        prmT004315 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00432", "SELECT [PoConcCosCod], [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WITH (UPDLOCK) WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00432,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00433", "SELECT [PoConcCosCod], [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00433,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00434", "SELECT [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00434,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00435", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00435,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00436", "SELECT T2.[CueDsc] AS PoConcDCueDsc, TM1.[PoConcCosCod], TM1.[PoConcCod], TM1.[PoConcDCueCod] AS PoConcDCueCod FROM ([POCONCEPTOSDET] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[PoConcDCueCod]) WHERE TM1.[PoConcCod] = @PoConcCod and TM1.[PoConcDCueCod] = @PoConcDCueCod ORDER BY TM1.[PoConcCod], TM1.[PoConcDCueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00436,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00437", "SELECT [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00437,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00438", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00438,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00439", "SELECT [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00439,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004310", "SELECT TOP 1 [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE ( [PoConcCod] > @PoConcCod or [PoConcCod] = @PoConcCod and [PoConcDCueCod] > @PoConcDCueCod) ORDER BY [PoConcCod], [PoConcDCueCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004310,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004311", "SELECT TOP 1 [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE ( [PoConcCod] < @PoConcCod or [PoConcCod] = @PoConcCod and [PoConcDCueCod] < @PoConcDCueCod) ORDER BY [PoConcCod] DESC, [PoConcDCueCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004311,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004312", "INSERT INTO [POCONCEPTOSDET]([PoConcCosCod], [PoConcCod], [PoConcDCueCod]) VALUES(@PoConcCosCod, @PoConcCod, @PoConcDCueCod)", GxErrorMask.GX_NOMASK,prmT004312)
           ,new CursorDef("T004313", "UPDATE [POCONCEPTOSDET] SET [PoConcCosCod]=@PoConcCosCod  WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod", GxErrorMask.GX_NOMASK,prmT004313)
           ,new CursorDef("T004314", "DELETE FROM [POCONCEPTOSDET]  WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod", GxErrorMask.GX_NOMASK,prmT004314)
           ,new CursorDef("T004315", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004315,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004316", "SELECT [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] ORDER BY [PoConcCod], [PoConcDCueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004316,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004317", "SELECT [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004317,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
