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
   public class cbflujoconceptos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A2265CBFlujCBanCod = (int)(NumberUtil.Val( GetPar( "CBFlujCBanCod"), "."));
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = GetPar( "CBFlujCCuenta");
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2265CBFlujCBanCod, A2266CBFlujCCuenta) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A2265CBFlujCBanCod = (int)(NumberUtil.Val( GetPar( "CBFlujCBanCod"), "."));
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = GetPar( "CBFlujCCuenta");
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = GetPar( "CBFlujCRegistro");
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro) ;
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
            Form.Meta.addItem("description", "Flujo Conceptos Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbflujoconceptos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbflujoconceptos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Flujo Conceptos Cabecera", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBFLUJOCONCEPTOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBFLUJOCONCEPTOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCAno_Internalname, "Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2263CBFlujCAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2263CBFlujCAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2263CBFlujCAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2264CBFlujCMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2264CBFlujCMes), "Z9") : context.localUtil.Format( (decimal)(A2264CBFlujCMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCBanCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCBanCod_Internalname, "Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2265CBFlujCBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2265CBFlujCBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2265CBFlujCBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCCuenta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCCuenta_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCCuenta_Internalname, StringUtil.RTrim( A2266CBFlujCCuenta), StringUtil.RTrim( context.localUtil.Format( A2266CBFlujCCuenta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCCuenta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCCuenta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCRegistro_Internalname, "N° Registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCRegistro_Internalname, StringUtil.RTrim( A2267CBFlujCRegistro), StringUtil.RTrim( context.localUtil.Format( A2267CBFlujCRegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCRegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCTItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCTItem_Internalname, "Total Items", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2273CBFlujCTItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A2273CBFlujCTItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2273CBFlujCTItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCTItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCBFlujCMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2272CBFlujCMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2272CBFlujCMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2272CBFlujCMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOS.htm");
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
            Z2263CBFlujCAno = (short)(context.localUtil.CToN( cgiGet( "Z2263CBFlujCAno"), ".", ","));
            Z2264CBFlujCMes = (short)(context.localUtil.CToN( cgiGet( "Z2264CBFlujCMes"), ".", ","));
            Z2265CBFlujCBanCod = (int)(context.localUtil.CToN( cgiGet( "Z2265CBFlujCBanCod"), ".", ","));
            Z2266CBFlujCCuenta = cgiGet( "Z2266CBFlujCCuenta");
            Z2267CBFlujCRegistro = cgiGet( "Z2267CBFlujCRegistro");
            Z2273CBFlujCTItem = (long)(context.localUtil.CToN( cgiGet( "Z2273CBFlujCTItem"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCANO");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2263CBFlujCAno = 0;
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            }
            else
            {
               A2263CBFlujCAno = (short)(context.localUtil.CToN( cgiGet( edtCBFlujCAno_Internalname), ".", ","));
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCMES");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2264CBFlujCMes = 0;
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            }
            else
            {
               A2264CBFlujCMes = (short)(context.localUtil.CToN( cgiGet( edtCBFlujCMes_Internalname), ".", ","));
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCBANCOD");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2265CBFlujCBanCod = 0;
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            }
            else
            {
               A2265CBFlujCBanCod = (int)(context.localUtil.CToN( cgiGet( edtCBFlujCBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            }
            A2266CBFlujCCuenta = cgiGet( edtCBFlujCCuenta_Internalname);
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = cgiGet( edtCBFlujCRegistro_Internalname);
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCTItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCTITEM");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2273CBFlujCTItem = 0;
               AssignAttri("", false, "A2273CBFlujCTItem", StringUtil.LTrimStr( (decimal)(A2273CBFlujCTItem), 10, 0));
            }
            else
            {
               A2273CBFlujCTItem = (long)(context.localUtil.CToN( cgiGet( edtCBFlujCTItem_Internalname), ".", ","));
               AssignAttri("", false, "A2273CBFlujCTItem", StringUtil.LTrimStr( (decimal)(A2273CBFlujCTItem), 10, 0));
            }
            A2272CBFlujCMonCod = (int)(context.localUtil.CToN( cgiGet( edtCBFlujCMonCod_Internalname), ".", ","));
            AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
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
               A2263CBFlujCAno = (short)(NumberUtil.Val( GetPar( "CBFlujCAno"), "."));
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
               A2264CBFlujCMes = (short)(NumberUtil.Val( GetPar( "CBFlujCMes"), "."));
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
               A2265CBFlujCBanCod = (int)(NumberUtil.Val( GetPar( "CBFlujCBanCod"), "."));
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
               A2266CBFlujCCuenta = GetPar( "CBFlujCCuenta");
               AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
               A2267CBFlujCRegistro = GetPar( "CBFlujCRegistro");
               AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
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
               InitAll7C200( ) ;
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
         DisableAttributes7C200( ) ;
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

      protected void ResetCaption7C0( )
      {
      }

      protected void ZM7C200( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2273CBFlujCTItem = T007C3_A2273CBFlujCTItem[0];
            }
            else
            {
               Z2273CBFlujCTItem = A2273CBFlujCTItem;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2263CBFlujCAno = A2263CBFlujCAno;
            Z2264CBFlujCMes = A2264CBFlujCMes;
            Z2273CBFlujCTItem = A2273CBFlujCTItem;
            Z2265CBFlujCBanCod = A2265CBFlujCBanCod;
            Z2266CBFlujCCuenta = A2266CBFlujCCuenta;
            Z2267CBFlujCRegistro = A2267CBFlujCRegistro;
            Z2272CBFlujCMonCod = A2272CBFlujCMonCod;
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

      protected void Load7C200( )
      {
         /* Using cursor T007C6 */
         pr_default.execute(4, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound200 = 1;
            A2273CBFlujCTItem = T007C6_A2273CBFlujCTItem[0];
            AssignAttri("", false, "A2273CBFlujCTItem", StringUtil.LTrimStr( (decimal)(A2273CBFlujCTItem), 10, 0));
            A2272CBFlujCMonCod = T007C6_A2272CBFlujCMonCod[0];
            AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
            ZM7C200( -1) ;
         }
         pr_default.close(4);
         OnLoadActions7C200( ) ;
      }

      protected void OnLoadActions7C200( )
      {
      }

      protected void CheckExtendedTable7C200( )
      {
         nIsDirty_200 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007C5 */
         pr_default.execute(3, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuentas de Banco'.", "ForeignKeyNotFound", 1, "CBFLUJCCUENTA");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2272CBFlujCMonCod = T007C5_A2272CBFlujCMonCod[0];
         AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
         pr_default.close(3);
         /* Using cursor T007C4 */
         pr_default.execute(2, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Flujo Cuenta'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7C200( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A2265CBFlujCBanCod ,
                               string A2266CBFlujCCuenta )
      {
         /* Using cursor T007C7 */
         pr_default.execute(5, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuentas de Banco'.", "ForeignKeyNotFound", 1, "CBFLUJCCUENTA");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2272CBFlujCMonCod = T007C7_A2272CBFlujCMonCod[0];
         AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A2272CBFlujCMonCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_2( int A2265CBFlujCBanCod ,
                               string A2266CBFlujCCuenta ,
                               string A2267CBFlujCRegistro )
      {
         /* Using cursor T007C8 */
         pr_default.execute(6, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Flujo Cuenta'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey7C200( )
      {
         /* Using cursor T007C9 */
         pr_default.execute(7, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound200 = 1;
         }
         else
         {
            RcdFound200 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007C3 */
         pr_default.execute(1, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7C200( 1) ;
            RcdFound200 = 1;
            A2263CBFlujCAno = T007C3_A2263CBFlujCAno[0];
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = T007C3_A2264CBFlujCMes[0];
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2273CBFlujCTItem = T007C3_A2273CBFlujCTItem[0];
            AssignAttri("", false, "A2273CBFlujCTItem", StringUtil.LTrimStr( (decimal)(A2273CBFlujCTItem), 10, 0));
            A2265CBFlujCBanCod = T007C3_A2265CBFlujCBanCod[0];
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = T007C3_A2266CBFlujCCuenta[0];
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = T007C3_A2267CBFlujCRegistro[0];
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            Z2263CBFlujCAno = A2263CBFlujCAno;
            Z2264CBFlujCMes = A2264CBFlujCMes;
            Z2265CBFlujCBanCod = A2265CBFlujCBanCod;
            Z2266CBFlujCCuenta = A2266CBFlujCCuenta;
            Z2267CBFlujCRegistro = A2267CBFlujCRegistro;
            sMode200 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7C200( ) ;
            if ( AnyError == 1 )
            {
               RcdFound200 = 0;
               InitializeNonKey7C200( ) ;
            }
            Gx_mode = sMode200;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound200 = 0;
            InitializeNonKey7C200( ) ;
            sMode200 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode200;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7C200( ) ;
         if ( RcdFound200 == 0 )
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
         RcdFound200 = 0;
         /* Using cursor T007C10 */
         pr_default.execute(8, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T007C10_A2263CBFlujCAno[0] < A2263CBFlujCAno ) || ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C10_A2264CBFlujCMes[0] < A2264CBFlujCMes ) || ( T007C10_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C10_A2265CBFlujCBanCod[0] < A2265CBFlujCBanCod ) || ( T007C10_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C10_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C10_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) < 0 ) || ( StringUtil.StrCmp(T007C10_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007C10_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C10_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C10_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T007C10_A2263CBFlujCAno[0] > A2263CBFlujCAno ) || ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C10_A2264CBFlujCMes[0] > A2264CBFlujCMes ) || ( T007C10_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C10_A2265CBFlujCBanCod[0] > A2265CBFlujCBanCod ) || ( T007C10_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C10_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C10_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) > 0 ) || ( StringUtil.StrCmp(T007C10_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007C10_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C10_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C10_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C10_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) > 0 ) ) )
            {
               A2263CBFlujCAno = T007C10_A2263CBFlujCAno[0];
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
               A2264CBFlujCMes = T007C10_A2264CBFlujCMes[0];
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
               A2265CBFlujCBanCod = T007C10_A2265CBFlujCBanCod[0];
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
               A2266CBFlujCCuenta = T007C10_A2266CBFlujCCuenta[0];
               AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
               A2267CBFlujCRegistro = T007C10_A2267CBFlujCRegistro[0];
               AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
               RcdFound200 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound200 = 0;
         /* Using cursor T007C11 */
         pr_default.execute(9, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T007C11_A2263CBFlujCAno[0] > A2263CBFlujCAno ) || ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C11_A2264CBFlujCMes[0] > A2264CBFlujCMes ) || ( T007C11_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C11_A2265CBFlujCBanCod[0] > A2265CBFlujCBanCod ) || ( T007C11_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C11_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C11_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) > 0 ) || ( StringUtil.StrCmp(T007C11_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007C11_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C11_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C11_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T007C11_A2263CBFlujCAno[0] < A2263CBFlujCAno ) || ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C11_A2264CBFlujCMes[0] < A2264CBFlujCMes ) || ( T007C11_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007C11_A2265CBFlujCBanCod[0] < A2265CBFlujCBanCod ) || ( T007C11_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C11_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C11_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) < 0 ) || ( StringUtil.StrCmp(T007C11_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007C11_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007C11_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007C11_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007C11_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) < 0 ) ) )
            {
               A2263CBFlujCAno = T007C11_A2263CBFlujCAno[0];
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
               A2264CBFlujCMes = T007C11_A2264CBFlujCMes[0];
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
               A2265CBFlujCBanCod = T007C11_A2265CBFlujCBanCod[0];
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
               A2266CBFlujCCuenta = T007C11_A2266CBFlujCCuenta[0];
               AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
               A2267CBFlujCRegistro = T007C11_A2267CBFlujCRegistro[0];
               AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
               RcdFound200 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7C200( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7C200( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound200 == 1 )
            {
               if ( ( A2263CBFlujCAno != Z2263CBFlujCAno ) || ( A2264CBFlujCMes != Z2264CBFlujCMes ) || ( A2265CBFlujCBanCod != Z2265CBFlujCBanCod ) || ( StringUtil.StrCmp(A2266CBFlujCCuenta, Z2266CBFlujCCuenta) != 0 ) || ( StringUtil.StrCmp(A2267CBFlujCRegistro, Z2267CBFlujCRegistro) != 0 ) )
               {
                  A2263CBFlujCAno = Z2263CBFlujCAno;
                  AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
                  A2264CBFlujCMes = Z2264CBFlujCMes;
                  AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
                  A2265CBFlujCBanCod = Z2265CBFlujCBanCod;
                  AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
                  A2266CBFlujCCuenta = Z2266CBFlujCCuenta;
                  AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
                  A2267CBFlujCRegistro = Z2267CBFlujCRegistro;
                  AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CBFLUJCANO");
                  AnyError = 1;
                  GX_FocusControl = edtCBFlujCAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCBFlujCAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7C200( ) ;
                  GX_FocusControl = edtCBFlujCAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2263CBFlujCAno != Z2263CBFlujCAno ) || ( A2264CBFlujCMes != Z2264CBFlujCMes ) || ( A2265CBFlujCBanCod != Z2265CBFlujCBanCod ) || ( StringUtil.StrCmp(A2266CBFlujCCuenta, Z2266CBFlujCCuenta) != 0 ) || ( StringUtil.StrCmp(A2267CBFlujCRegistro, Z2267CBFlujCRegistro) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBFlujCAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7C200( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CBFLUJCANO");
                     AnyError = 1;
                     GX_FocusControl = edtCBFlujCAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCBFlujCAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7C200( ) ;
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
         if ( ( A2263CBFlujCAno != Z2263CBFlujCAno ) || ( A2264CBFlujCMes != Z2264CBFlujCMes ) || ( A2265CBFlujCBanCod != Z2265CBFlujCBanCod ) || ( StringUtil.StrCmp(A2266CBFlujCCuenta, Z2266CBFlujCCuenta) != 0 ) || ( StringUtil.StrCmp(A2267CBFlujCRegistro, Z2267CBFlujCRegistro) != 0 ) )
         {
            A2263CBFlujCAno = Z2263CBFlujCAno;
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = Z2264CBFlujCMes;
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2265CBFlujCBanCod = Z2265CBFlujCBanCod;
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = Z2266CBFlujCCuenta;
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = Z2267CBFlujCRegistro;
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CBFLUJCANO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCBFlujCAno_Internalname;
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
         if ( RcdFound200 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBFLUJCANO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBFlujCTItem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7C200( ) ;
         if ( RcdFound200 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCTItem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7C200( ) ;
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
         if ( RcdFound200 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCTItem_Internalname;
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
         if ( RcdFound200 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCTItem_Internalname;
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
         ScanStart7C200( ) ;
         if ( RcdFound200 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound200 != 0 )
            {
               ScanNext7C200( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujCTItem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7C200( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7C200( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007C2 */
            pr_default.execute(0, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOCONCEPTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2273CBFlujCTItem != T007C2_A2273CBFlujCTItem[0] ) )
            {
               if ( Z2273CBFlujCTItem != T007C2_A2273CBFlujCTItem[0] )
               {
                  GXUtil.WriteLog("cbflujoconceptos:[seudo value changed for attri]"+"CBFlujCTItem");
                  GXUtil.WriteLogRaw("Old: ",Z2273CBFlujCTItem);
                  GXUtil.WriteLogRaw("Current: ",T007C2_A2273CBFlujCTItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBFLUJOCONCEPTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7C200( )
      {
         BeforeValidate7C200( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7C200( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7C200( 0) ;
            CheckOptimisticConcurrency7C200( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7C200( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7C200( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007C12 */
                     pr_default.execute(10, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2273CBFlujCTItem, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOCONCEPTOS");
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
                           ResetCaption7C0( ) ;
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
               Load7C200( ) ;
            }
            EndLevel7C200( ) ;
         }
         CloseExtendedTableCursors7C200( ) ;
      }

      protected void Update7C200( )
      {
         BeforeValidate7C200( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7C200( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7C200( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7C200( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7C200( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007C13 */
                     pr_default.execute(11, new Object[] {A2273CBFlujCTItem, A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOCONCEPTOS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOCONCEPTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7C200( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7C0( ) ;
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
            EndLevel7C200( ) ;
         }
         CloseExtendedTableCursors7C200( ) ;
      }

      protected void DeferredUpdate7C200( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7C200( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7C200( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7C200( ) ;
            AfterConfirm7C200( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7C200( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007C14 */
                  pr_default.execute(12, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOCONCEPTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound200 == 0 )
                        {
                           InitAll7C200( ) ;
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
                        ResetCaption7C0( ) ;
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
         sMode200 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7C200( ) ;
         Gx_mode = sMode200;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7C200( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007C15 */
            pr_default.execute(13, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta});
            A2272CBFlujCMonCod = T007C15_A2272CBFlujCMonCod[0];
            AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007C16 */
            pr_default.execute(14, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel7C200( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7C200( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("cbflujoconceptos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("cbflujoconceptos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7C200( )
      {
         /* Using cursor T007C17 */
         pr_default.execute(15);
         RcdFound200 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound200 = 1;
            A2263CBFlujCAno = T007C17_A2263CBFlujCAno[0];
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = T007C17_A2264CBFlujCMes[0];
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2265CBFlujCBanCod = T007C17_A2265CBFlujCBanCod[0];
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = T007C17_A2266CBFlujCCuenta[0];
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = T007C17_A2267CBFlujCRegistro[0];
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7C200( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound200 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound200 = 1;
            A2263CBFlujCAno = T007C17_A2263CBFlujCAno[0];
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = T007C17_A2264CBFlujCMes[0];
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2265CBFlujCBanCod = T007C17_A2265CBFlujCBanCod[0];
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = T007C17_A2266CBFlujCCuenta[0];
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = T007C17_A2267CBFlujCRegistro[0];
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
         }
      }

      protected void ScanEnd7C200( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm7C200( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7C200( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7C200( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7C200( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7C200( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7C200( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7C200( )
      {
         edtCBFlujCAno_Enabled = 0;
         AssignProp("", false, edtCBFlujCAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCAno_Enabled), 5, 0), true);
         edtCBFlujCMes_Enabled = 0;
         AssignProp("", false, edtCBFlujCMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCMes_Enabled), 5, 0), true);
         edtCBFlujCBanCod_Enabled = 0;
         AssignProp("", false, edtCBFlujCBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCBanCod_Enabled), 5, 0), true);
         edtCBFlujCCuenta_Enabled = 0;
         AssignProp("", false, edtCBFlujCCuenta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCCuenta_Enabled), 5, 0), true);
         edtCBFlujCRegistro_Enabled = 0;
         AssignProp("", false, edtCBFlujCRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCRegistro_Enabled), 5, 0), true);
         edtCBFlujCTItem_Enabled = 0;
         AssignProp("", false, edtCBFlujCTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCTItem_Enabled), 5, 0), true);
         edtCBFlujCMonCod_Enabled = 0;
         AssignProp("", false, edtCBFlujCMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCMonCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7C200( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027484", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbflujoconceptos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2263CBFlujCAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2263CBFlujCAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2264CBFlujCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2264CBFlujCMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2265CBFlujCBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2265CBFlujCBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2266CBFlujCCuenta", StringUtil.RTrim( Z2266CBFlujCCuenta));
         GxWebStd.gx_hidden_field( context, "Z2267CBFlujCRegistro", StringUtil.RTrim( Z2267CBFlujCRegistro));
         GxWebStd.gx_hidden_field( context, "Z2273CBFlujCTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2273CBFlujCTItem), 10, 0, ".", "")));
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
         return formatLink("cbflujoconceptos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBFLUJOCONCEPTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Flujo Conceptos Cabecera" ;
      }

      protected void InitializeNonKey7C200( )
      {
         A2273CBFlujCTItem = 0;
         AssignAttri("", false, "A2273CBFlujCTItem", StringUtil.LTrimStr( (decimal)(A2273CBFlujCTItem), 10, 0));
         A2272CBFlujCMonCod = 0;
         AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
         Z2273CBFlujCTItem = 0;
      }

      protected void InitAll7C200( )
      {
         A2263CBFlujCAno = 0;
         AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
         A2264CBFlujCMes = 0;
         AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
         A2265CBFlujCBanCod = 0;
         AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
         A2266CBFlujCCuenta = "";
         AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
         A2267CBFlujCRegistro = "";
         AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
         InitializeNonKey7C200( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027491", true, true);
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
         context.AddJavascriptSource("cbflujoconceptos.js", "?20228181027491", false, true);
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
         edtCBFlujCAno_Internalname = "CBFLUJCANO";
         edtCBFlujCMes_Internalname = "CBFLUJCMES";
         edtCBFlujCBanCod_Internalname = "CBFLUJCBANCOD";
         edtCBFlujCCuenta_Internalname = "CBFLUJCCUENTA";
         edtCBFlujCRegistro_Internalname = "CBFLUJCREGISTRO";
         edtCBFlujCTItem_Internalname = "CBFLUJCTITEM";
         edtCBFlujCMonCod_Internalname = "CBFLUJCMONCOD";
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
         Form.Caption = "Flujo Conceptos Cabecera";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBFlujCMonCod_Jsonclick = "";
         edtCBFlujCMonCod_Enabled = 0;
         edtCBFlujCTItem_Jsonclick = "";
         edtCBFlujCTItem_Enabled = 1;
         edtCBFlujCRegistro_Jsonclick = "";
         edtCBFlujCRegistro_Enabled = 1;
         edtCBFlujCCuenta_Jsonclick = "";
         edtCBFlujCCuenta_Enabled = 1;
         edtCBFlujCBanCod_Jsonclick = "";
         edtCBFlujCBanCod_Enabled = 1;
         edtCBFlujCMes_Jsonclick = "";
         edtCBFlujCMes_Enabled = 1;
         edtCBFlujCAno_Jsonclick = "";
         edtCBFlujCAno_Enabled = 1;
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
         /* Using cursor T007C15 */
         pr_default.execute(13, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuentas de Banco'.", "ForeignKeyNotFound", 1, "CBFLUJCCUENTA");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2272CBFlujCMonCod = T007C15_A2272CBFlujCMonCod[0];
         AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrimStr( (decimal)(A2272CBFlujCMonCod), 6, 0));
         pr_default.close(13);
         /* Using cursor T007C18 */
         pr_default.execute(16, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Flujo Cuenta'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         GX_FocusControl = edtCBFlujCTItem_Internalname;
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

      public void Valid_Cbflujccuenta( )
      {
         /* Using cursor T007C15 */
         pr_default.execute(13, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuentas de Banco'.", "ForeignKeyNotFound", 1, "CBFLUJCCUENTA");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
         }
         A2272CBFlujCMonCod = T007C15_A2272CBFlujCMonCod[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2272CBFlujCMonCod), 6, 0, ".", "")));
      }

      public void Valid_Cbflujcregistro( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T007C18 */
         pr_default.execute(16, new Object[] {A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Flujo Cuenta'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCBanCod_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2273CBFlujCTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2273CBFlujCTItem), 10, 0, ".", "")));
         AssignAttri("", false, "A2272CBFlujCMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2272CBFlujCMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2263CBFlujCAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2263CBFlujCAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2264CBFlujCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2264CBFlujCMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2265CBFlujCBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2265CBFlujCBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2266CBFlujCCuenta", StringUtil.RTrim( Z2266CBFlujCCuenta));
         GxWebStd.gx_hidden_field( context, "Z2267CBFlujCRegistro", StringUtil.RTrim( Z2267CBFlujCRegistro));
         GxWebStd.gx_hidden_field( context, "Z2273CBFlujCTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2273CBFlujCTItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2272CBFlujCMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2272CBFlujCMonCod), 6, 0, ".", "")));
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
         setEventMetadata("VALID_CBFLUJCANO","{handler:'Valid_Cbflujcano',iparms:[]");
         setEventMetadata("VALID_CBFLUJCANO",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCMES","{handler:'Valid_Cbflujcmes',iparms:[]");
         setEventMetadata("VALID_CBFLUJCMES",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCBANCOD","{handler:'Valid_Cbflujcbancod',iparms:[]");
         setEventMetadata("VALID_CBFLUJCBANCOD",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCCUENTA","{handler:'Valid_Cbflujccuenta',iparms:[{av:'A2265CBFlujCBanCod',fld:'CBFLUJCBANCOD',pic:'ZZZZZ9'},{av:'A2266CBFlujCCuenta',fld:'CBFLUJCCUENTA',pic:''},{av:'A2272CBFlujCMonCod',fld:'CBFLUJCMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CBFLUJCCUENTA",",oparms:[{av:'A2272CBFlujCMonCod',fld:'CBFLUJCMONCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_CBFLUJCREGISTRO","{handler:'Valid_Cbflujcregistro',iparms:[{av:'A2263CBFlujCAno',fld:'CBFLUJCANO',pic:'ZZZ9'},{av:'A2264CBFlujCMes',fld:'CBFLUJCMES',pic:'Z9'},{av:'A2265CBFlujCBanCod',fld:'CBFLUJCBANCOD',pic:'ZZZZZ9'},{av:'A2266CBFlujCCuenta',fld:'CBFLUJCCUENTA',pic:''},{av:'A2267CBFlujCRegistro',fld:'CBFLUJCREGISTRO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBFLUJCREGISTRO",",oparms:[{av:'A2273CBFlujCTItem',fld:'CBFLUJCTITEM',pic:'ZZZZZZZZZ9'},{av:'A2272CBFlujCMonCod',fld:'CBFLUJCMONCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2263CBFlujCAno'},{av:'Z2264CBFlujCMes'},{av:'Z2265CBFlujCBanCod'},{av:'Z2266CBFlujCCuenta'},{av:'Z2267CBFlujCRegistro'},{av:'Z2273CBFlujCTItem'},{av:'Z2272CBFlujCMonCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2266CBFlujCCuenta = "";
         Z2267CBFlujCRegistro = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2266CBFlujCCuenta = "";
         A2267CBFlujCRegistro = "";
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
         T007C6_A2263CBFlujCAno = new short[1] ;
         T007C6_A2264CBFlujCMes = new short[1] ;
         T007C6_A2273CBFlujCTItem = new long[1] ;
         T007C6_A2265CBFlujCBanCod = new int[1] ;
         T007C6_A2266CBFlujCCuenta = new string[] {""} ;
         T007C6_A2267CBFlujCRegistro = new string[] {""} ;
         T007C6_A2272CBFlujCMonCod = new int[1] ;
         T007C5_A2272CBFlujCMonCod = new int[1] ;
         T007C4_A2265CBFlujCBanCod = new int[1] ;
         T007C7_A2272CBFlujCMonCod = new int[1] ;
         T007C8_A2265CBFlujCBanCod = new int[1] ;
         T007C9_A2263CBFlujCAno = new short[1] ;
         T007C9_A2264CBFlujCMes = new short[1] ;
         T007C9_A2265CBFlujCBanCod = new int[1] ;
         T007C9_A2266CBFlujCCuenta = new string[] {""} ;
         T007C9_A2267CBFlujCRegistro = new string[] {""} ;
         T007C3_A2263CBFlujCAno = new short[1] ;
         T007C3_A2264CBFlujCMes = new short[1] ;
         T007C3_A2273CBFlujCTItem = new long[1] ;
         T007C3_A2265CBFlujCBanCod = new int[1] ;
         T007C3_A2266CBFlujCCuenta = new string[] {""} ;
         T007C3_A2267CBFlujCRegistro = new string[] {""} ;
         sMode200 = "";
         T007C10_A2263CBFlujCAno = new short[1] ;
         T007C10_A2264CBFlujCMes = new short[1] ;
         T007C10_A2265CBFlujCBanCod = new int[1] ;
         T007C10_A2266CBFlujCCuenta = new string[] {""} ;
         T007C10_A2267CBFlujCRegistro = new string[] {""} ;
         T007C11_A2263CBFlujCAno = new short[1] ;
         T007C11_A2264CBFlujCMes = new short[1] ;
         T007C11_A2265CBFlujCBanCod = new int[1] ;
         T007C11_A2266CBFlujCCuenta = new string[] {""} ;
         T007C11_A2267CBFlujCRegistro = new string[] {""} ;
         T007C2_A2263CBFlujCAno = new short[1] ;
         T007C2_A2264CBFlujCMes = new short[1] ;
         T007C2_A2273CBFlujCTItem = new long[1] ;
         T007C2_A2265CBFlujCBanCod = new int[1] ;
         T007C2_A2266CBFlujCCuenta = new string[] {""} ;
         T007C2_A2267CBFlujCRegistro = new string[] {""} ;
         T007C15_A2272CBFlujCMonCod = new int[1] ;
         T007C16_A2263CBFlujCAno = new short[1] ;
         T007C16_A2264CBFlujCMes = new short[1] ;
         T007C16_A2265CBFlujCBanCod = new int[1] ;
         T007C16_A2266CBFlujCCuenta = new string[] {""} ;
         T007C16_A2267CBFlujCRegistro = new string[] {""} ;
         T007C16_A2268CBFlujCItem = new int[1] ;
         T007C17_A2263CBFlujCAno = new short[1] ;
         T007C17_A2264CBFlujCMes = new short[1] ;
         T007C17_A2265CBFlujCBanCod = new int[1] ;
         T007C17_A2266CBFlujCCuenta = new string[] {""} ;
         T007C17_A2267CBFlujCRegistro = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007C18_A2265CBFlujCBanCod = new int[1] ;
         ZZ2266CBFlujCCuenta = "";
         ZZ2267CBFlujCRegistro = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbflujoconceptos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbflujoconceptos__default(),
            new Object[][] {
                new Object[] {
               T007C2_A2263CBFlujCAno, T007C2_A2264CBFlujCMes, T007C2_A2273CBFlujCTItem, T007C2_A2265CBFlujCBanCod, T007C2_A2266CBFlujCCuenta, T007C2_A2267CBFlujCRegistro
               }
               , new Object[] {
               T007C3_A2263CBFlujCAno, T007C3_A2264CBFlujCMes, T007C3_A2273CBFlujCTItem, T007C3_A2265CBFlujCBanCod, T007C3_A2266CBFlujCCuenta, T007C3_A2267CBFlujCRegistro
               }
               , new Object[] {
               T007C4_A2265CBFlujCBanCod
               }
               , new Object[] {
               T007C5_A2272CBFlujCMonCod
               }
               , new Object[] {
               T007C6_A2263CBFlujCAno, T007C6_A2264CBFlujCMes, T007C6_A2273CBFlujCTItem, T007C6_A2265CBFlujCBanCod, T007C6_A2266CBFlujCCuenta, T007C6_A2267CBFlujCRegistro, T007C6_A2272CBFlujCMonCod
               }
               , new Object[] {
               T007C7_A2272CBFlujCMonCod
               }
               , new Object[] {
               T007C8_A2265CBFlujCBanCod
               }
               , new Object[] {
               T007C9_A2263CBFlujCAno, T007C9_A2264CBFlujCMes, T007C9_A2265CBFlujCBanCod, T007C9_A2266CBFlujCCuenta, T007C9_A2267CBFlujCRegistro
               }
               , new Object[] {
               T007C10_A2263CBFlujCAno, T007C10_A2264CBFlujCMes, T007C10_A2265CBFlujCBanCod, T007C10_A2266CBFlujCCuenta, T007C10_A2267CBFlujCRegistro
               }
               , new Object[] {
               T007C11_A2263CBFlujCAno, T007C11_A2264CBFlujCMes, T007C11_A2265CBFlujCBanCod, T007C11_A2266CBFlujCCuenta, T007C11_A2267CBFlujCRegistro
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007C15_A2272CBFlujCMonCod
               }
               , new Object[] {
               T007C16_A2263CBFlujCAno, T007C16_A2264CBFlujCMes, T007C16_A2265CBFlujCBanCod, T007C16_A2266CBFlujCCuenta, T007C16_A2267CBFlujCRegistro, T007C16_A2268CBFlujCItem
               }
               , new Object[] {
               T007C17_A2263CBFlujCAno, T007C17_A2264CBFlujCMes, T007C17_A2265CBFlujCBanCod, T007C17_A2266CBFlujCCuenta, T007C17_A2267CBFlujCRegistro
               }
               , new Object[] {
               T007C18_A2265CBFlujCBanCod
               }
            }
         );
      }

      private short Z2263CBFlujCAno ;
      private short Z2264CBFlujCMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2263CBFlujCAno ;
      private short A2264CBFlujCMes ;
      private short GX_JID ;
      private short RcdFound200 ;
      private short nIsDirty_200 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2263CBFlujCAno ;
      private short ZZ2264CBFlujCMes ;
      private int Z2265CBFlujCBanCod ;
      private int A2265CBFlujCBanCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCBFlujCAno_Enabled ;
      private int edtCBFlujCMes_Enabled ;
      private int edtCBFlujCBanCod_Enabled ;
      private int edtCBFlujCCuenta_Enabled ;
      private int edtCBFlujCRegistro_Enabled ;
      private int edtCBFlujCTItem_Enabled ;
      private int A2272CBFlujCMonCod ;
      private int edtCBFlujCMonCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z2272CBFlujCMonCod ;
      private int idxLst ;
      private int ZZ2265CBFlujCBanCod ;
      private int ZZ2272CBFlujCMonCod ;
      private long Z2273CBFlujCTItem ;
      private long A2273CBFlujCTItem ;
      private long ZZ2273CBFlujCTItem ;
      private string sPrefix ;
      private string Z2266CBFlujCCuenta ;
      private string Z2267CBFlujCRegistro ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2266CBFlujCCuenta ;
      private string A2267CBFlujCRegistro ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCBFlujCAno_Internalname ;
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
      private string edtCBFlujCAno_Jsonclick ;
      private string edtCBFlujCMes_Internalname ;
      private string edtCBFlujCMes_Jsonclick ;
      private string edtCBFlujCBanCod_Internalname ;
      private string edtCBFlujCBanCod_Jsonclick ;
      private string edtCBFlujCCuenta_Internalname ;
      private string edtCBFlujCCuenta_Jsonclick ;
      private string edtCBFlujCRegistro_Internalname ;
      private string edtCBFlujCRegistro_Jsonclick ;
      private string edtCBFlujCTItem_Internalname ;
      private string edtCBFlujCTItem_Jsonclick ;
      private string edtCBFlujCMonCod_Internalname ;
      private string edtCBFlujCMonCod_Jsonclick ;
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
      private string sMode200 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2266CBFlujCCuenta ;
      private string ZZ2267CBFlujCRegistro ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T007C6_A2263CBFlujCAno ;
      private short[] T007C6_A2264CBFlujCMes ;
      private long[] T007C6_A2273CBFlujCTItem ;
      private int[] T007C6_A2265CBFlujCBanCod ;
      private string[] T007C6_A2266CBFlujCCuenta ;
      private string[] T007C6_A2267CBFlujCRegistro ;
      private int[] T007C6_A2272CBFlujCMonCod ;
      private int[] T007C5_A2272CBFlujCMonCod ;
      private int[] T007C4_A2265CBFlujCBanCod ;
      private int[] T007C7_A2272CBFlujCMonCod ;
      private int[] T007C8_A2265CBFlujCBanCod ;
      private short[] T007C9_A2263CBFlujCAno ;
      private short[] T007C9_A2264CBFlujCMes ;
      private int[] T007C9_A2265CBFlujCBanCod ;
      private string[] T007C9_A2266CBFlujCCuenta ;
      private string[] T007C9_A2267CBFlujCRegistro ;
      private short[] T007C3_A2263CBFlujCAno ;
      private short[] T007C3_A2264CBFlujCMes ;
      private long[] T007C3_A2273CBFlujCTItem ;
      private int[] T007C3_A2265CBFlujCBanCod ;
      private string[] T007C3_A2266CBFlujCCuenta ;
      private string[] T007C3_A2267CBFlujCRegistro ;
      private short[] T007C10_A2263CBFlujCAno ;
      private short[] T007C10_A2264CBFlujCMes ;
      private int[] T007C10_A2265CBFlujCBanCod ;
      private string[] T007C10_A2266CBFlujCCuenta ;
      private string[] T007C10_A2267CBFlujCRegistro ;
      private short[] T007C11_A2263CBFlujCAno ;
      private short[] T007C11_A2264CBFlujCMes ;
      private int[] T007C11_A2265CBFlujCBanCod ;
      private string[] T007C11_A2266CBFlujCCuenta ;
      private string[] T007C11_A2267CBFlujCRegistro ;
      private short[] T007C2_A2263CBFlujCAno ;
      private short[] T007C2_A2264CBFlujCMes ;
      private long[] T007C2_A2273CBFlujCTItem ;
      private int[] T007C2_A2265CBFlujCBanCod ;
      private string[] T007C2_A2266CBFlujCCuenta ;
      private string[] T007C2_A2267CBFlujCRegistro ;
      private int[] T007C15_A2272CBFlujCMonCod ;
      private short[] T007C16_A2263CBFlujCAno ;
      private short[] T007C16_A2264CBFlujCMes ;
      private int[] T007C16_A2265CBFlujCBanCod ;
      private string[] T007C16_A2266CBFlujCCuenta ;
      private string[] T007C16_A2267CBFlujCRegistro ;
      private int[] T007C16_A2268CBFlujCItem ;
      private short[] T007C17_A2263CBFlujCAno ;
      private short[] T007C17_A2264CBFlujCMes ;
      private int[] T007C17_A2265CBFlujCBanCod ;
      private string[] T007C17_A2266CBFlujCCuenta ;
      private string[] T007C17_A2267CBFlujCRegistro ;
      private int[] T007C18_A2265CBFlujCBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbflujoconceptos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbflujoconceptos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007C6;
        prmT007C6 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C5;
        prmT007C5 = new Object[] {
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0)
        };
        Object[] prmT007C4;
        prmT007C4 = new Object[] {
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C7;
        prmT007C7 = new Object[] {
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0)
        };
        Object[] prmT007C8;
        prmT007C8 = new Object[] {
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C9;
        prmT007C9 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C3;
        prmT007C3 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C10;
        prmT007C10 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C11;
        prmT007C11 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C2;
        prmT007C2 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C12;
        prmT007C12 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCTItem",GXType.Decimal,10,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C13;
        prmT007C13 = new Object[] {
        new ParDef("@CBFlujCTItem",GXType.Decimal,10,0) ,
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C14;
        prmT007C14 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C16;
        prmT007C16 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007C17;
        prmT007C17 = new Object[] {
        };
        Object[] prmT007C15;
        prmT007C15 = new Object[] {
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0)
        };
        Object[] prmT007C18;
        prmT007C18 = new Object[] {
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007C2", "SELECT [CBFlujCAno], [CBFlujCMes], [CBFlujCTItem], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro FROM [CBFLUJOCONCEPTOS] WITH (UPDLOCK) WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C3", "SELECT [CBFlujCAno], [CBFlujCMes], [CBFlujCTItem], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro FROM [CBFLUJOCONCEPTOS] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C4", "SELECT [LBBanCod] AS CBFlujCBanCod FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @CBFlujCBanCod AND [LBCBCod] = @CBFlujCCuenta AND [LBRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C5", "SELECT [MonCod] AS CBFlujCMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @CBFlujCBanCod AND [CBCod] = @CBFlujCCuenta ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C6", "SELECT TM1.[CBFlujCAno], TM1.[CBFlujCMes], TM1.[CBFlujCTItem], TM1.[CBFlujCBanCod] AS CBFlujCBanCod, TM1.[CBFlujCCuenta] AS CBFlujCCuenta, TM1.[CBFlujCRegistro] AS CBFlujCRegistro, T2.[MonCod] AS CBFlujCMonCod FROM (([CBFLUJOCONCEPTOS] TM1 INNER JOIN [TSLIBROBANCOS] T3 ON T3.[LBBanCod] = TM1.[CBFlujCBanCod] AND T3.[LBCBCod] = TM1.[CBFlujCCuenta] AND T3.[LBRegistro] = TM1.[CBFlujCRegistro]) INNER JOIN [TSCUENTABANCO] T2 ON T2.[BanCod] = T3.[LBBanCod] AND T2.[CBCod] = T3.[LBCBCod]) WHERE TM1.[CBFlujCAno] = @CBFlujCAno and TM1.[CBFlujCMes] = @CBFlujCMes and TM1.[CBFlujCBanCod] = @CBFlujCBanCod and TM1.[CBFlujCCuenta] = @CBFlujCCuenta and TM1.[CBFlujCRegistro] = @CBFlujCRegistro ORDER BY TM1.[CBFlujCAno], TM1.[CBFlujCMes], TM1.[CBFlujCBanCod], TM1.[CBFlujCCuenta], TM1.[CBFlujCRegistro]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007C6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C7", "SELECT [MonCod] AS CBFlujCMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @CBFlujCBanCod AND [CBCod] = @CBFlujCCuenta ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C8", "SELECT [LBBanCod] AS CBFlujCBanCod FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @CBFlujCBanCod AND [LBCBCod] = @CBFlujCCuenta AND [LBRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C9", "SELECT [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro FROM [CBFLUJOCONCEPTOS] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007C9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C10", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro FROM [CBFLUJOCONCEPTOS] WHERE ( [CBFlujCAno] > @CBFlujCAno or [CBFlujCAno] = @CBFlujCAno and [CBFlujCMes] > @CBFlujCMes or [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCBanCod] > @CBFlujCBanCod or [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCCuenta] > @CBFlujCCuenta or [CBFlujCCuenta] = @CBFlujCCuenta and [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCRegistro] > @CBFlujCRegistro) ORDER BY [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007C10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007C11", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro FROM [CBFLUJOCONCEPTOS] WHERE ( [CBFlujCAno] < @CBFlujCAno or [CBFlujCAno] = @CBFlujCAno and [CBFlujCMes] < @CBFlujCMes or [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCBanCod] < @CBFlujCBanCod or [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCCuenta] < @CBFlujCCuenta or [CBFlujCCuenta] = @CBFlujCCuenta and [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCRegistro] < @CBFlujCRegistro) ORDER BY [CBFlujCAno] DESC, [CBFlujCMes] DESC, [CBFlujCBanCod] DESC, [CBFlujCCuenta] DESC, [CBFlujCRegistro] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007C11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007C12", "INSERT INTO [CBFLUJOCONCEPTOS]([CBFlujCAno], [CBFlujCMes], [CBFlujCTItem], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro]) VALUES(@CBFlujCAno, @CBFlujCMes, @CBFlujCTItem, @CBFlujCBanCod, @CBFlujCCuenta, @CBFlujCRegistro)", GxErrorMask.GX_NOMASK,prmT007C12)
           ,new CursorDef("T007C13", "UPDATE [CBFLUJOCONCEPTOS] SET [CBFlujCTItem]=@CBFlujCTItem  WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro", GxErrorMask.GX_NOMASK,prmT007C13)
           ,new CursorDef("T007C14", "DELETE FROM [CBFLUJOCONCEPTOS]  WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro", GxErrorMask.GX_NOMASK,prmT007C14)
           ,new CursorDef("T007C15", "SELECT [MonCod] AS CBFlujCMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @CBFlujCBanCod AND [CBCod] = @CBFlujCCuenta ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C16", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro, [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007C17", "SELECT [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod] AS CBFlujCBanCod, [CBFlujCCuenta] AS CBFlujCCuenta, [CBFlujCRegistro] AS CBFlujCRegistro FROM [CBFLUJOCONCEPTOS] ORDER BY [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007C17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007C18", "SELECT [LBBanCod] AS CBFlujCBanCod FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @CBFlujCBanCod AND [LBCBCod] = @CBFlujCCuenta AND [LBRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007C18,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
