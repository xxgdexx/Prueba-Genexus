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
   public class poordengasto : GXDataArea
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
            A322ProCod = GetPar( "ProCod");
            AssignAttri("", false, "A322ProCod", A322ProCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A322ProCod) ;
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
            Form.Meta.addItem("description", "Orden de Produccion Gastos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poordengasto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poordengasto( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Orden de Produccion Gastos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_POORDENGASTO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POORDENGASTO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCod_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCod_Internalname, StringUtil.RTrim( A322ProCod), StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasCod_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A328ProGasCod), 4, 0, ".", "")), StringUtil.LTrim( ((edtProGasCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A328ProGasCod), "ZZZ9") : context.localUtil.Format( (decimal)(A328ProGasCod), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasCod_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasConcepto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasConcepto_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasConcepto_Internalname, A1725ProGasConcepto, StringUtil.RTrim( context.localUtil.Format( A1725ProGasConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasCosto_Internalname, "Costo Unitario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1726ProGasCosto, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasCosto_Enabled!=0) ? context.localUtil.Format( A1726ProGasCosto, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A1726ProGasCosto, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasCosto_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_POORDENGASTO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENGASTO.htm");
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
            Z322ProCod = cgiGet( "Z322ProCod");
            Z328ProGasCod = (short)(context.localUtil.CToN( cgiGet( "Z328ProGasCod"), ".", ","));
            Z1725ProGasConcepto = cgiGet( "Z1725ProGasConcepto");
            Z1726ProGasCosto = context.localUtil.CToN( cgiGet( "Z1726ProGasCosto"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A322ProCod = cgiGet( edtProCod_Internalname);
            AssignAttri("", false, "A322ProCod", A322ProCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasCod_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASCOD");
               AnyError = 1;
               GX_FocusControl = edtProGasCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A328ProGasCod = 0;
               AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
            }
            else
            {
               A328ProGasCod = (short)(context.localUtil.CToN( cgiGet( edtProGasCod_Internalname), ".", ","));
               AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
            }
            A1725ProGasConcepto = cgiGet( edtProGasConcepto_Internalname);
            AssignAttri("", false, "A1725ProGasConcepto", A1725ProGasConcepto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasCosto_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasCosto_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASCOSTO");
               AnyError = 1;
               GX_FocusControl = edtProGasCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1726ProGasCosto = 0;
               AssignAttri("", false, "A1726ProGasCosto", StringUtil.LTrimStr( A1726ProGasCosto, 18, 6));
            }
            else
            {
               A1726ProGasCosto = context.localUtil.CToN( cgiGet( edtProGasCosto_Internalname), ".", ",");
               AssignAttri("", false, "A1726ProGasCosto", StringUtil.LTrimStr( A1726ProGasCosto, 18, 6));
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
               A322ProCod = GetPar( "ProCod");
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A328ProGasCod = (short)(NumberUtil.Val( GetPar( "ProGasCod"), "."));
               AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
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
               InitAll4A149( ) ;
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
         DisableAttributes4A149( ) ;
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

      protected void ResetCaption4A0( )
      {
      }

      protected void ZM4A149( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1725ProGasConcepto = T004A3_A1725ProGasConcepto[0];
               Z1726ProGasCosto = T004A3_A1726ProGasCosto[0];
            }
            else
            {
               Z1725ProGasConcepto = A1725ProGasConcepto;
               Z1726ProGasCosto = A1726ProGasCosto;
            }
         }
         if ( GX_JID == -1 )
         {
            Z328ProGasCod = A328ProGasCod;
            Z1725ProGasConcepto = A1725ProGasConcepto;
            Z1726ProGasCosto = A1726ProGasCosto;
            Z322ProCod = A322ProCod;
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

      protected void Load4A149( )
      {
         /* Using cursor T004A5 */
         pr_default.execute(3, new Object[] {A322ProCod, A328ProGasCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound149 = 1;
            A1725ProGasConcepto = T004A5_A1725ProGasConcepto[0];
            AssignAttri("", false, "A1725ProGasConcepto", A1725ProGasConcepto);
            A1726ProGasCosto = T004A5_A1726ProGasCosto[0];
            AssignAttri("", false, "A1726ProGasCosto", StringUtil.LTrimStr( A1726ProGasCosto, 18, 6));
            ZM4A149( -1) ;
         }
         pr_default.close(3);
         OnLoadActions4A149( ) ;
      }

      protected void OnLoadActions4A149( )
      {
      }

      protected void CheckExtendedTable4A149( )
      {
         nIsDirty_149 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004A4 */
         pr_default.execute(2, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors4A149( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A322ProCod )
      {
         /* Using cursor T004A6 */
         pr_default.execute(4, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey4A149( )
      {
         /* Using cursor T004A7 */
         pr_default.execute(5, new Object[] {A322ProCod, A328ProGasCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound149 = 1;
         }
         else
         {
            RcdFound149 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004A3 */
         pr_default.execute(1, new Object[] {A322ProCod, A328ProGasCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4A149( 1) ;
            RcdFound149 = 1;
            A328ProGasCod = T004A3_A328ProGasCod[0];
            AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
            A1725ProGasConcepto = T004A3_A1725ProGasConcepto[0];
            AssignAttri("", false, "A1725ProGasConcepto", A1725ProGasConcepto);
            A1726ProGasCosto = T004A3_A1726ProGasCosto[0];
            AssignAttri("", false, "A1726ProGasCosto", StringUtil.LTrimStr( A1726ProGasCosto, 18, 6));
            A322ProCod = T004A3_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            Z322ProCod = A322ProCod;
            Z328ProGasCod = A328ProGasCod;
            sMode149 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4A149( ) ;
            if ( AnyError == 1 )
            {
               RcdFound149 = 0;
               InitializeNonKey4A149( ) ;
            }
            Gx_mode = sMode149;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound149 = 0;
            InitializeNonKey4A149( ) ;
            sMode149 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode149;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4A149( ) ;
         if ( RcdFound149 == 0 )
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
         RcdFound149 = 0;
         /* Using cursor T004A8 */
         pr_default.execute(6, new Object[] {A322ProCod, A328ProGasCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T004A8_A322ProCod[0], A322ProCod) < 0 ) || ( StringUtil.StrCmp(T004A8_A322ProCod[0], A322ProCod) == 0 ) && ( T004A8_A328ProGasCod[0] < A328ProGasCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T004A8_A322ProCod[0], A322ProCod) > 0 ) || ( StringUtil.StrCmp(T004A8_A322ProCod[0], A322ProCod) == 0 ) && ( T004A8_A328ProGasCod[0] > A328ProGasCod ) ) )
            {
               A322ProCod = T004A8_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A328ProGasCod = T004A8_A328ProGasCod[0];
               AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
               RcdFound149 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound149 = 0;
         /* Using cursor T004A9 */
         pr_default.execute(7, new Object[] {A322ProCod, A328ProGasCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T004A9_A322ProCod[0], A322ProCod) > 0 ) || ( StringUtil.StrCmp(T004A9_A322ProCod[0], A322ProCod) == 0 ) && ( T004A9_A328ProGasCod[0] > A328ProGasCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T004A9_A322ProCod[0], A322ProCod) < 0 ) || ( StringUtil.StrCmp(T004A9_A322ProCod[0], A322ProCod) == 0 ) && ( T004A9_A328ProGasCod[0] < A328ProGasCod ) ) )
            {
               A322ProCod = T004A9_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A328ProGasCod = T004A9_A328ProGasCod[0];
               AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
               RcdFound149 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4A149( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4A149( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound149 == 1 )
            {
               if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( A328ProGasCod != Z328ProGasCod ) )
               {
                  A322ProCod = Z322ProCod;
                  AssignAttri("", false, "A322ProCod", A322ProCod);
                  A328ProGasCod = Z328ProGasCod;
                  AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4A149( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( A328ProGasCod != Z328ProGasCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4A149( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4A149( ) ;
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
         if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( A328ProGasCod != Z328ProGasCod ) )
         {
            A322ProCod = Z322ProCod;
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A328ProGasCod = Z328ProGasCod;
            AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCod_Internalname;
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
         if ( RcdFound149 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProGasConcepto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4A149( ) ;
         if ( RcdFound149 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasConcepto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4A149( ) ;
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
         if ( RcdFound149 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasConcepto_Internalname;
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
         if ( RcdFound149 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasConcepto_Internalname;
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
         ScanStart4A149( ) ;
         if ( RcdFound149 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound149 != 0 )
            {
               ScanNext4A149( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasConcepto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4A149( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4A149( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004A2 */
            pr_default.execute(0, new Object[] {A322ProCod, A328ProGasCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENGASTO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1725ProGasConcepto, T004A2_A1725ProGasConcepto[0]) != 0 ) || ( Z1726ProGasCosto != T004A2_A1726ProGasCosto[0] ) )
            {
               if ( StringUtil.StrCmp(Z1725ProGasConcepto, T004A2_A1725ProGasConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("poordengasto:[seudo value changed for attri]"+"ProGasConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1725ProGasConcepto);
                  GXUtil.WriteLogRaw("Current: ",T004A2_A1725ProGasConcepto[0]);
               }
               if ( Z1726ProGasCosto != T004A2_A1726ProGasCosto[0] )
               {
                  GXUtil.WriteLog("poordengasto:[seudo value changed for attri]"+"ProGasCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1726ProGasCosto);
                  GXUtil.WriteLogRaw("Current: ",T004A2_A1726ProGasCosto[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POORDENGASTO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4A149( )
      {
         BeforeValidate4A149( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4A149( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4A149( 0) ;
            CheckOptimisticConcurrency4A149( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4A149( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4A149( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004A10 */
                     pr_default.execute(8, new Object[] {A328ProGasCod, A1725ProGasConcepto, A1726ProGasCosto, A322ProCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENGASTO");
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
                           ResetCaption4A0( ) ;
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
               Load4A149( ) ;
            }
            EndLevel4A149( ) ;
         }
         CloseExtendedTableCursors4A149( ) ;
      }

      protected void Update4A149( )
      {
         BeforeValidate4A149( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4A149( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4A149( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4A149( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4A149( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004A11 */
                     pr_default.execute(9, new Object[] {A1725ProGasConcepto, A1726ProGasCosto, A322ProCod, A328ProGasCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENGASTO");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENGASTO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4A149( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4A0( ) ;
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
            EndLevel4A149( ) ;
         }
         CloseExtendedTableCursors4A149( ) ;
      }

      protected void DeferredUpdate4A149( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4A149( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4A149( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4A149( ) ;
            AfterConfirm4A149( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4A149( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004A12 */
                  pr_default.execute(10, new Object[] {A322ProCod, A328ProGasCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("POORDENGASTO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound149 == 0 )
                        {
                           InitAll4A149( ) ;
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
                        ResetCaption4A0( ) ;
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
         sMode149 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4A149( ) ;
         Gx_mode = sMode149;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4A149( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel4A149( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4A149( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("poordengasto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("poordengasto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4A149( )
      {
         /* Using cursor T004A13 */
         pr_default.execute(11);
         RcdFound149 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound149 = 1;
            A322ProCod = T004A13_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A328ProGasCod = T004A13_A328ProGasCod[0];
            AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4A149( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound149 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound149 = 1;
            A322ProCod = T004A13_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A328ProGasCod = T004A13_A328ProGasCod[0];
            AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
         }
      }

      protected void ScanEnd4A149( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm4A149( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4A149( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4A149( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4A149( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4A149( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4A149( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4A149( )
      {
         edtProCod_Enabled = 0;
         AssignProp("", false, edtProCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCod_Enabled), 5, 0), true);
         edtProGasCod_Enabled = 0;
         AssignProp("", false, edtProGasCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasCod_Enabled), 5, 0), true);
         edtProGasConcepto_Enabled = 0;
         AssignProp("", false, edtProGasConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasConcepto_Enabled), 5, 0), true);
         edtProGasCosto_Enabled = 0;
         AssignProp("", false, edtProGasCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasCosto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4A149( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253263", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("poordengasto.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z328ProGasCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328ProGasCod), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1725ProGasConcepto", Z1725ProGasConcepto);
         GxWebStd.gx_hidden_field( context, "Z1726ProGasCosto", StringUtil.LTrim( StringUtil.NToC( Z1726ProGasCosto, 18, 6, ".", "")));
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
         return formatLink("poordengasto.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POORDENGASTO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Orden de Produccion Gastos" ;
      }

      protected void InitializeNonKey4A149( )
      {
         A1725ProGasConcepto = "";
         AssignAttri("", false, "A1725ProGasConcepto", A1725ProGasConcepto);
         A1726ProGasCosto = 0;
         AssignAttri("", false, "A1726ProGasCosto", StringUtil.LTrimStr( A1726ProGasCosto, 18, 6));
         Z1725ProGasConcepto = "";
         Z1726ProGasCosto = 0;
      }

      protected void InitAll4A149( )
      {
         A322ProCod = "";
         AssignAttri("", false, "A322ProCod", A322ProCod);
         A328ProGasCod = 0;
         AssignAttri("", false, "A328ProGasCod", StringUtil.LTrimStr( (decimal)(A328ProGasCod), 4, 0));
         InitializeNonKey4A149( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253269", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("poordengasto.js", "?202281810253269", false, true);
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
         edtProCod_Internalname = "PROCOD";
         edtProGasCod_Internalname = "PROGASCOD";
         edtProGasConcepto_Internalname = "PROGASCONCEPTO";
         edtProGasCosto_Internalname = "PROGASCOSTO";
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
         Form.Caption = "Orden de Produccion Gastos";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProGasCosto_Jsonclick = "";
         edtProGasCosto_Enabled = 1;
         edtProGasConcepto_Jsonclick = "";
         edtProGasConcepto_Enabled = 1;
         edtProGasCod_Jsonclick = "";
         edtProGasCod_Enabled = 1;
         edtProCod_Jsonclick = "";
         edtProCod_Enabled = 1;
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
         /* Using cursor T004A14 */
         pr_default.execute(12, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtProGasConcepto_Internalname;
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

      public void Valid_Procod( )
      {
         /* Using cursor T004A14 */
         pr_default.execute(12, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Progascod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1725ProGasConcepto", A1725ProGasConcepto);
         AssignAttri("", false, "A1726ProGasCosto", StringUtil.LTrim( StringUtil.NToC( A1726ProGasCosto, 18, 6, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z328ProGasCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328ProGasCod), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1725ProGasConcepto", Z1725ProGasConcepto);
         GxWebStd.gx_hidden_field( context, "Z1726ProGasCosto", StringUtil.LTrim( StringUtil.NToC( Z1726ProGasCosto, 18, 6, ".", "")));
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
         setEventMetadata("VALID_PROCOD","{handler:'Valid_Procod',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''}]");
         setEventMetadata("VALID_PROCOD",",oparms:[]}");
         setEventMetadata("VALID_PROGASCOD","{handler:'Valid_Progascod',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''},{av:'A328ProGasCod',fld:'PROGASCOD',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROGASCOD",",oparms:[{av:'A1725ProGasConcepto',fld:'PROGASCONCEPTO',pic:''},{av:'A1726ProGasCosto',fld:'PROGASCOSTO',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z322ProCod'},{av:'Z328ProGasCod'},{av:'Z1725ProGasConcepto'},{av:'Z1726ProGasCosto'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z322ProCod = "";
         Z1725ProGasConcepto = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A322ProCod = "";
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
         A1725ProGasConcepto = "";
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
         T004A5_A328ProGasCod = new short[1] ;
         T004A5_A1725ProGasConcepto = new string[] {""} ;
         T004A5_A1726ProGasCosto = new decimal[1] ;
         T004A5_A322ProCod = new string[] {""} ;
         T004A4_A322ProCod = new string[] {""} ;
         T004A6_A322ProCod = new string[] {""} ;
         T004A7_A322ProCod = new string[] {""} ;
         T004A7_A328ProGasCod = new short[1] ;
         T004A3_A328ProGasCod = new short[1] ;
         T004A3_A1725ProGasConcepto = new string[] {""} ;
         T004A3_A1726ProGasCosto = new decimal[1] ;
         T004A3_A322ProCod = new string[] {""} ;
         sMode149 = "";
         T004A8_A322ProCod = new string[] {""} ;
         T004A8_A328ProGasCod = new short[1] ;
         T004A9_A322ProCod = new string[] {""} ;
         T004A9_A328ProGasCod = new short[1] ;
         T004A2_A328ProGasCod = new short[1] ;
         T004A2_A1725ProGasConcepto = new string[] {""} ;
         T004A2_A1726ProGasCosto = new decimal[1] ;
         T004A2_A322ProCod = new string[] {""} ;
         T004A13_A322ProCod = new string[] {""} ;
         T004A13_A328ProGasCod = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004A14_A322ProCod = new string[] {""} ;
         ZZ322ProCod = "";
         ZZ1725ProGasConcepto = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poordengasto__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poordengasto__default(),
            new Object[][] {
                new Object[] {
               T004A2_A328ProGasCod, T004A2_A1725ProGasConcepto, T004A2_A1726ProGasCosto, T004A2_A322ProCod
               }
               , new Object[] {
               T004A3_A328ProGasCod, T004A3_A1725ProGasConcepto, T004A3_A1726ProGasCosto, T004A3_A322ProCod
               }
               , new Object[] {
               T004A4_A322ProCod
               }
               , new Object[] {
               T004A5_A328ProGasCod, T004A5_A1725ProGasConcepto, T004A5_A1726ProGasCosto, T004A5_A322ProCod
               }
               , new Object[] {
               T004A6_A322ProCod
               }
               , new Object[] {
               T004A7_A322ProCod, T004A7_A328ProGasCod
               }
               , new Object[] {
               T004A8_A322ProCod, T004A8_A328ProGasCod
               }
               , new Object[] {
               T004A9_A322ProCod, T004A9_A328ProGasCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004A13_A322ProCod, T004A13_A328ProGasCod
               }
               , new Object[] {
               T004A14_A322ProCod
               }
            }
         );
      }

      private short Z328ProGasCod ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A328ProGasCod ;
      private short GX_JID ;
      private short RcdFound149 ;
      private short nIsDirty_149 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ328ProGasCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCod_Enabled ;
      private int edtProGasCod_Enabled ;
      private int edtProGasConcepto_Enabled ;
      private int edtProGasCosto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z1726ProGasCosto ;
      private decimal A1726ProGasCosto ;
      private decimal ZZ1726ProGasCosto ;
      private string sPrefix ;
      private string Z322ProCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A322ProCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCod_Internalname ;
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
      private string edtProCod_Jsonclick ;
      private string edtProGasCod_Internalname ;
      private string edtProGasCod_Jsonclick ;
      private string edtProGasConcepto_Internalname ;
      private string edtProGasConcepto_Jsonclick ;
      private string edtProGasCosto_Internalname ;
      private string edtProGasCosto_Jsonclick ;
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
      private string sMode149 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ322ProCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z1725ProGasConcepto ;
      private string A1725ProGasConcepto ;
      private string ZZ1725ProGasConcepto ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T004A5_A328ProGasCod ;
      private string[] T004A5_A1725ProGasConcepto ;
      private decimal[] T004A5_A1726ProGasCosto ;
      private string[] T004A5_A322ProCod ;
      private string[] T004A4_A322ProCod ;
      private string[] T004A6_A322ProCod ;
      private string[] T004A7_A322ProCod ;
      private short[] T004A7_A328ProGasCod ;
      private short[] T004A3_A328ProGasCod ;
      private string[] T004A3_A1725ProGasConcepto ;
      private decimal[] T004A3_A1726ProGasCosto ;
      private string[] T004A3_A322ProCod ;
      private string[] T004A8_A322ProCod ;
      private short[] T004A8_A328ProGasCod ;
      private string[] T004A9_A322ProCod ;
      private short[] T004A9_A328ProGasCod ;
      private short[] T004A2_A328ProGasCod ;
      private string[] T004A2_A1725ProGasConcepto ;
      private decimal[] T004A2_A1726ProGasCosto ;
      private string[] T004A2_A322ProCod ;
      private string[] T004A13_A322ProCod ;
      private short[] T004A13_A328ProGasCod ;
      private string[] T004A14_A322ProCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poordengasto__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poordengasto__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004A5;
        prmT004A5 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A4;
        prmT004A4 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004A6;
        prmT004A6 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004A7;
        prmT004A7 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A3;
        prmT004A3 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A8;
        prmT004A8 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A9;
        prmT004A9 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A2;
        prmT004A2 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A10;
        prmT004A10 = new Object[] {
        new ParDef("@ProGasCod",GXType.Int16,4,0) ,
        new ParDef("@ProGasConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@ProGasCosto",GXType.Decimal,18,6) ,
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004A11;
        prmT004A11 = new Object[] {
        new ParDef("@ProGasConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@ProGasCosto",GXType.Decimal,18,6) ,
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A12;
        prmT004A12 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProGasCod",GXType.Int16,4,0)
        };
        Object[] prmT004A13;
        prmT004A13 = new Object[] {
        };
        Object[] prmT004A14;
        prmT004A14 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004A2", "SELECT [ProGasCod], [ProGasConcepto], [ProGasCosto], [ProCod] FROM [POORDENGASTO] WITH (UPDLOCK) WHERE [ProCod] = @ProCod AND [ProGasCod] = @ProGasCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A3", "SELECT [ProGasCod], [ProGasConcepto], [ProGasCosto], [ProCod] FROM [POORDENGASTO] WHERE [ProCod] = @ProCod AND [ProGasCod] = @ProGasCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A4", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A5", "SELECT TM1.[ProGasCod], TM1.[ProGasConcepto], TM1.[ProGasCosto], TM1.[ProCod] FROM [POORDENGASTO] TM1 WHERE TM1.[ProCod] = @ProCod and TM1.[ProGasCod] = @ProGasCod ORDER BY TM1.[ProCod], TM1.[ProGasCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004A5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A6", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A7", "SELECT [ProCod], [ProGasCod] FROM [POORDENGASTO] WHERE [ProCod] = @ProCod AND [ProGasCod] = @ProGasCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A8", "SELECT TOP 1 [ProCod], [ProGasCod] FROM [POORDENGASTO] WHERE ( [ProCod] > @ProCod or [ProCod] = @ProCod and [ProGasCod] > @ProGasCod) ORDER BY [ProCod], [ProGasCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004A8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004A9", "SELECT TOP 1 [ProCod], [ProGasCod] FROM [POORDENGASTO] WHERE ( [ProCod] < @ProCod or [ProCod] = @ProCod and [ProGasCod] < @ProGasCod) ORDER BY [ProCod] DESC, [ProGasCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004A9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004A10", "INSERT INTO [POORDENGASTO]([ProGasCod], [ProGasConcepto], [ProGasCosto], [ProCod]) VALUES(@ProGasCod, @ProGasConcepto, @ProGasCosto, @ProCod)", GxErrorMask.GX_NOMASK,prmT004A10)
           ,new CursorDef("T004A11", "UPDATE [POORDENGASTO] SET [ProGasConcepto]=@ProGasConcepto, [ProGasCosto]=@ProGasCosto  WHERE [ProCod] = @ProCod AND [ProGasCod] = @ProGasCod", GxErrorMask.GX_NOMASK,prmT004A11)
           ,new CursorDef("T004A12", "DELETE FROM [POORDENGASTO]  WHERE [ProCod] = @ProCod AND [ProGasCod] = @ProGasCod", GxErrorMask.GX_NOMASK,prmT004A12)
           ,new CursorDef("T004A13", "SELECT [ProCod], [ProGasCod] FROM [POORDENGASTO] ORDER BY [ProCod], [ProGasCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004A13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004A14", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004A14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
