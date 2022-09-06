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
   public class sgtiendas : GXDataArea
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
            Form.Meta.addItem("description", "Tiendas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgtiendas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgtiendas( IGxContext context )
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
         cmbTieSts = new GXCombobox();
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
         if ( cmbTieSts.ItemCount > 0 )
         {
            A1899TieSts = (short)(NumberUtil.Val( cmbTieSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0))), "."));
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTieSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
            AssignProp("", false, cmbTieSts_Internalname, "Values", cmbTieSts.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tiendas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGTIENDAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGTIENDAS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTieCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTieCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTieCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTieCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTieCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTieDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTieDsc_Internalname, "Local", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTieDsc_Internalname, StringUtil.RTrim( A1898TieDsc), StringUtil.RTrim( context.localUtil.Format( A1898TieDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTieDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTieAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTieAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTieAbr_Internalname, A1897TieAbr, StringUtil.RTrim( context.localUtil.Format( A1897TieAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTieAbr_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTieSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTieSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTieSts, cmbTieSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0)), 1, cmbTieSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTieSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_SGTIENDAS.htm");
         cmbTieSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         AssignProp("", false, cmbTieSts_Internalname, "Values", (string)(cmbTieSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGTIENDAS.htm");
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
            Z178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
            Z1898TieDsc = cgiGet( "Z1898TieDsc");
            Z1897TieAbr = cgiGet( "Z1897TieAbr");
            Z1899TieSts = (short)(context.localUtil.CToN( cgiGet( "Z1899TieSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIECOD");
               AnyError = 1;
               GX_FocusControl = edtTieCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A178TieCod = 0;
               n178TieCod = false;
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            }
            else
            {
               A178TieCod = (int)(context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ","));
               n178TieCod = false;
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            }
            A1898TieDsc = cgiGet( edtTieDsc_Internalname);
            AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
            A1897TieAbr = cgiGet( edtTieAbr_Internalname);
            AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
            cmbTieSts.CurrentValue = cgiGet( cmbTieSts_Internalname);
            A1899TieSts = (short)(NumberUtil.Val( cgiGet( cmbTieSts_Internalname), "."));
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
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
               A178TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
               n178TieCod = false;
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
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
               InitAll0S18( ) ;
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
         DisableAttributes0S18( ) ;
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

      protected void ResetCaption0S0( )
      {
      }

      protected void ZM0S18( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1898TieDsc = T000S3_A1898TieDsc[0];
               Z1897TieAbr = T000S3_A1897TieAbr[0];
               Z1899TieSts = T000S3_A1899TieSts[0];
            }
            else
            {
               Z1898TieDsc = A1898TieDsc;
               Z1897TieAbr = A1897TieAbr;
               Z1899TieSts = A1899TieSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z178TieCod = A178TieCod;
            Z1898TieDsc = A1898TieDsc;
            Z1897TieAbr = A1897TieAbr;
            Z1899TieSts = A1899TieSts;
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

      protected void Load0S18( )
      {
         /* Using cursor T000S4 */
         pr_default.execute(2, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound18 = 1;
            A1898TieDsc = T000S4_A1898TieDsc[0];
            AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
            A1897TieAbr = T000S4_A1897TieAbr[0];
            AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
            A1899TieSts = T000S4_A1899TieSts[0];
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
            ZM0S18( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0S18( ) ;
      }

      protected void OnLoadActions0S18( )
      {
      }

      protected void CheckExtendedTable0S18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0S18( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0S18( )
      {
         /* Using cursor T000S5 */
         pr_default.execute(3, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000S3 */
         pr_default.execute(1, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S18( 1) ;
            RcdFound18 = 1;
            A178TieCod = T000S3_A178TieCod[0];
            n178TieCod = T000S3_n178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            A1898TieDsc = T000S3_A1898TieDsc[0];
            AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
            A1897TieAbr = T000S3_A1897TieAbr[0];
            AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
            A1899TieSts = T000S3_A1899TieSts[0];
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
            Z178TieCod = A178TieCod;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0S18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0S18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0S18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S18( ) ;
         if ( RcdFound18 == 0 )
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
         RcdFound18 = 0;
         /* Using cursor T000S6 */
         pr_default.execute(4, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000S6_A178TieCod[0] < A178TieCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000S6_A178TieCod[0] > A178TieCod ) ) )
            {
               A178TieCod = T000S6_A178TieCod[0];
               n178TieCod = T000S6_n178TieCod[0];
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000S7 */
         pr_default.execute(5, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000S7_A178TieCod[0] > A178TieCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000S7_A178TieCod[0] < A178TieCod ) ) )
            {
               A178TieCod = T000S7_A178TieCod[0];
               n178TieCod = T000S7_n178TieCod[0];
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0S18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0S18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A178TieCod != Z178TieCod )
               {
                  A178TieCod = Z178TieCod;
                  n178TieCod = false;
                  AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIECOD");
                  AnyError = 1;
                  GX_FocusControl = edtTieCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTieCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0S18( ) ;
                  GX_FocusControl = edtTieCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A178TieCod != Z178TieCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTieCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0S18( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIECOD");
                     AnyError = 1;
                     GX_FocusControl = edtTieCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTieCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0S18( ) ;
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
         if ( A178TieCod != Z178TieCod )
         {
            A178TieCod = Z178TieCod;
            n178TieCod = false;
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIECOD");
            AnyError = 1;
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTieCod_Internalname;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIECOD");
            AnyError = 1;
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTieDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0S18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTieDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0S18( ) ;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTieDsc_Internalname;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTieDsc_Internalname;
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
         ScanStart0S18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound18 != 0 )
            {
               ScanNext0S18( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTieDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0S18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0S18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S2 */
            pr_default.execute(0, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGTIENDAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1898TieDsc, T000S2_A1898TieDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1897TieAbr, T000S2_A1897TieAbr[0]) != 0 ) || ( Z1899TieSts != T000S2_A1899TieSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1898TieDsc, T000S2_A1898TieDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("sgtiendas:[seudo value changed for attri]"+"TieDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1898TieDsc);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A1898TieDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1897TieAbr, T000S2_A1897TieAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("sgtiendas:[seudo value changed for attri]"+"TieAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1897TieAbr);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A1897TieAbr[0]);
               }
               if ( Z1899TieSts != T000S2_A1899TieSts[0] )
               {
                  GXUtil.WriteLog("sgtiendas:[seudo value changed for attri]"+"TieSts");
                  GXUtil.WriteLogRaw("Old: ",Z1899TieSts);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A1899TieSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGTIENDAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S18( )
      {
         BeforeValidate0S18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S18( 0) ;
            CheckOptimisticConcurrency0S18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S8 */
                     pr_default.execute(6, new Object[] {n178TieCod, A178TieCod, A1898TieDsc, A1897TieAbr, A1899TieSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGTIENDAS");
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
                           ResetCaption0S0( ) ;
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
               Load0S18( ) ;
            }
            EndLevel0S18( ) ;
         }
         CloseExtendedTableCursors0S18( ) ;
      }

      protected void Update0S18( )
      {
         BeforeValidate0S18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S9 */
                     pr_default.execute(7, new Object[] {A1898TieDsc, A1897TieAbr, A1899TieSts, n178TieCod, A178TieCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGTIENDAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGTIENDAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0S0( ) ;
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
            EndLevel0S18( ) ;
         }
         CloseExtendedTableCursors0S18( ) ;
      }

      protected void DeferredUpdate0S18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0S18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S18( ) ;
            AfterConfirm0S18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S10 */
                  pr_default.execute(8, new Object[] {n178TieCod, A178TieCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGTIENDAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound18 == 0 )
                        {
                           InitAll0S18( ) ;
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
                        ResetCaption0S0( ) ;
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S18( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000S11 */
            pr_default.execute(9, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000S12 */
            pr_default.execute(10, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000S13 */
            pr_default.execute(11, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000S14 */
            pr_default.execute(12, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0S18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S18( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgtiendas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgtiendas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S18( )
      {
         /* Using cursor T000S15 */
         pr_default.execute(13);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
            A178TieCod = T000S15_A178TieCod[0];
            n178TieCod = T000S15_n178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S18( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
            A178TieCod = T000S15_A178TieCod[0];
            n178TieCod = T000S15_n178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         }
      }

      protected void ScanEnd0S18( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0S18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S18( )
      {
         edtTieCod_Enabled = 0;
         AssignProp("", false, edtTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieCod_Enabled), 5, 0), true);
         edtTieDsc_Enabled = 0;
         AssignProp("", false, edtTieDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieDsc_Enabled), 5, 0), true);
         edtTieAbr_Enabled = 0;
         AssignProp("", false, edtTieAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieAbr_Enabled), 5, 0), true);
         cmbTieSts.Enabled = 0;
         AssignProp("", false, cmbTieSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTieSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0S18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0S0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442626", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgtiendas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1898TieDsc", StringUtil.RTrim( Z1898TieDsc));
         GxWebStd.gx_hidden_field( context, "Z1897TieAbr", Z1897TieAbr);
         GxWebStd.gx_hidden_field( context, "Z1899TieSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1899TieSts), 1, 0, ".", "")));
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
         return formatLink("sgtiendas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGTIENDAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tiendas" ;
      }

      protected void InitializeNonKey0S18( )
      {
         A1898TieDsc = "";
         AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
         A1897TieAbr = "";
         AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
         A1899TieSts = 0;
         AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         Z1898TieDsc = "";
         Z1897TieAbr = "";
         Z1899TieSts = 0;
      }

      protected void InitAll0S18( )
      {
         A178TieCod = 0;
         n178TieCod = false;
         AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         InitializeNonKey0S18( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811442631", true, true);
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
         context.AddJavascriptSource("sgtiendas.js", "?202281811442631", false, true);
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
         edtTieCod_Internalname = "TIECOD";
         edtTieDsc_Internalname = "TIEDSC";
         edtTieAbr_Internalname = "TIEABR";
         cmbTieSts_Internalname = "TIESTS";
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
         Form.Caption = "Tiendas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbTieSts_Jsonclick = "";
         cmbTieSts.Enabled = 1;
         edtTieAbr_Jsonclick = "";
         edtTieAbr_Enabled = 1;
         edtTieDsc_Jsonclick = "";
         edtTieDsc_Enabled = 1;
         edtTieCod_Jsonclick = "";
         edtTieCod_Enabled = 1;
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
         cmbTieSts.Name = "TIESTS";
         cmbTieSts.WebTags = "";
         cmbTieSts.addItem("1", "ACTIVO", 0);
         cmbTieSts.addItem("0", "INACTIVO", 0);
         if ( cmbTieSts.ItemCount > 0 )
         {
            A1899TieSts = (short)(NumberUtil.Val( cmbTieSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0))), "."));
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTieDsc_Internalname;
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

      public void Valid_Tiecod( )
      {
         A1899TieSts = (short)(NumberUtil.Val( cmbTieSts.CurrentValue, "."));
         cmbTieSts.CurrentValue = StringUtil.Str( (decimal)(A1899TieSts), 1, 0);
         n178TieCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTieSts.ItemCount > 0 )
         {
            A1899TieSts = (short)(NumberUtil.Val( cmbTieSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0))), "."));
            cmbTieSts.CurrentValue = StringUtil.Str( (decimal)(A1899TieSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTieSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1898TieDsc", StringUtil.RTrim( A1898TieDsc));
         AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
         AssignAttri("", false, "A1899TieSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1899TieSts), 1, 0, ".", "")));
         cmbTieSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         AssignProp("", false, cmbTieSts_Internalname, "Values", cmbTieSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1898TieDsc", StringUtil.RTrim( Z1898TieDsc));
         GxWebStd.gx_hidden_field( context, "Z1897TieAbr", Z1897TieAbr);
         GxWebStd.gx_hidden_field( context, "Z1899TieSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1899TieSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TIECOD","{handler:'Valid_Tiecod',iparms:[{av:'cmbTieSts'},{av:'A1899TieSts',fld:'TIESTS',pic:'9'},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIECOD",",oparms:[{av:'A1898TieDsc',fld:'TIEDSC',pic:''},{av:'A1897TieAbr',fld:'TIEABR',pic:''},{av:'cmbTieSts'},{av:'A1899TieSts',fld:'TIESTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z178TieCod'},{av:'Z1898TieDsc'},{av:'Z1897TieAbr'},{av:'Z1899TieSts'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z1898TieDsc = "";
         Z1897TieAbr = "";
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
         A1898TieDsc = "";
         A1897TieAbr = "";
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
         T000S4_A178TieCod = new int[1] ;
         T000S4_n178TieCod = new bool[] {false} ;
         T000S4_A1898TieDsc = new string[] {""} ;
         T000S4_A1897TieAbr = new string[] {""} ;
         T000S4_A1899TieSts = new short[1] ;
         T000S5_A178TieCod = new int[1] ;
         T000S5_n178TieCod = new bool[] {false} ;
         T000S3_A178TieCod = new int[1] ;
         T000S3_n178TieCod = new bool[] {false} ;
         T000S3_A1898TieDsc = new string[] {""} ;
         T000S3_A1897TieAbr = new string[] {""} ;
         T000S3_A1899TieSts = new short[1] ;
         sMode18 = "";
         T000S6_A178TieCod = new int[1] ;
         T000S6_n178TieCod = new bool[] {false} ;
         T000S7_A178TieCod = new int[1] ;
         T000S7_n178TieCod = new bool[] {false} ;
         T000S2_A178TieCod = new int[1] ;
         T000S2_n178TieCod = new bool[] {false} ;
         T000S2_A1898TieDsc = new string[] {""} ;
         T000S2_A1897TieAbr = new string[] {""} ;
         T000S2_A1899TieSts = new short[1] ;
         T000S11_A348UsuCod = new string[] {""} ;
         T000S12_A149TipCod = new string[] {""} ;
         T000S12_A24DocNum = new string[] {""} ;
         T000S13_A210PedCod = new string[] {""} ;
         T000S14_A177CotCod = new string[] {""} ;
         T000S15_A178TieCod = new int[1] ;
         T000S15_n178TieCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1898TieDsc = "";
         ZZ1897TieAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgtiendas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgtiendas__default(),
            new Object[][] {
                new Object[] {
               T000S2_A178TieCod, T000S2_A1898TieDsc, T000S2_A1897TieAbr, T000S2_A1899TieSts
               }
               , new Object[] {
               T000S3_A178TieCod, T000S3_A1898TieDsc, T000S3_A1897TieAbr, T000S3_A1899TieSts
               }
               , new Object[] {
               T000S4_A178TieCod, T000S4_A1898TieDsc, T000S4_A1897TieAbr, T000S4_A1899TieSts
               }
               , new Object[] {
               T000S5_A178TieCod
               }
               , new Object[] {
               T000S6_A178TieCod
               }
               , new Object[] {
               T000S7_A178TieCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S11_A348UsuCod
               }
               , new Object[] {
               T000S12_A149TipCod, T000S12_A24DocNum
               }
               , new Object[] {
               T000S13_A210PedCod
               }
               , new Object[] {
               T000S14_A177CotCod
               }
               , new Object[] {
               T000S15_A178TieCod
               }
            }
         );
      }

      private short Z1899TieSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1899TieSts ;
      private short GX_JID ;
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1899TieSts ;
      private int Z178TieCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A178TieCod ;
      private int edtTieCod_Enabled ;
      private int edtTieDsc_Enabled ;
      private int edtTieAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ178TieCod ;
      private string sPrefix ;
      private string Z1898TieDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTieCod_Internalname ;
      private string cmbTieSts_Internalname ;
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
      private string edtTieCod_Jsonclick ;
      private string edtTieDsc_Internalname ;
      private string A1898TieDsc ;
      private string edtTieDsc_Jsonclick ;
      private string edtTieAbr_Internalname ;
      private string edtTieAbr_Jsonclick ;
      private string cmbTieSts_Jsonclick ;
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
      private string sMode18 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1898TieDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n178TieCod ;
      private string Z1897TieAbr ;
      private string A1897TieAbr ;
      private string ZZ1897TieAbr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTieSts ;
      private IDataStoreProvider pr_default ;
      private int[] T000S4_A178TieCod ;
      private bool[] T000S4_n178TieCod ;
      private string[] T000S4_A1898TieDsc ;
      private string[] T000S4_A1897TieAbr ;
      private short[] T000S4_A1899TieSts ;
      private int[] T000S5_A178TieCod ;
      private bool[] T000S5_n178TieCod ;
      private int[] T000S3_A178TieCod ;
      private bool[] T000S3_n178TieCod ;
      private string[] T000S3_A1898TieDsc ;
      private string[] T000S3_A1897TieAbr ;
      private short[] T000S3_A1899TieSts ;
      private int[] T000S6_A178TieCod ;
      private bool[] T000S6_n178TieCod ;
      private int[] T000S7_A178TieCod ;
      private bool[] T000S7_n178TieCod ;
      private int[] T000S2_A178TieCod ;
      private bool[] T000S2_n178TieCod ;
      private string[] T000S2_A1898TieDsc ;
      private string[] T000S2_A1897TieAbr ;
      private short[] T000S2_A1899TieSts ;
      private string[] T000S11_A348UsuCod ;
      private string[] T000S12_A149TipCod ;
      private string[] T000S12_A24DocNum ;
      private string[] T000S13_A210PedCod ;
      private string[] T000S14_A177CotCod ;
      private int[] T000S15_A178TieCod ;
      private bool[] T000S15_n178TieCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgtiendas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgtiendas__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000S4;
        prmT000S4 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S5;
        prmT000S5 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S3;
        prmT000S3 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S6;
        prmT000S6 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S7;
        prmT000S7 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S2;
        prmT000S2 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S8;
        prmT000S8 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TieDsc",GXType.NChar,100,0) ,
        new ParDef("@TieAbr",GXType.NVarChar,10,0) ,
        new ParDef("@TieSts",GXType.Int16,1,0)
        };
        Object[] prmT000S9;
        prmT000S9 = new Object[] {
        new ParDef("@TieDsc",GXType.NChar,100,0) ,
        new ParDef("@TieAbr",GXType.NVarChar,10,0) ,
        new ParDef("@TieSts",GXType.Int16,1,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S10;
        prmT000S10 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S11;
        prmT000S11 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S12;
        prmT000S12 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S13;
        prmT000S13 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S14;
        prmT000S14 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000S15;
        prmT000S15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000S2", "SELECT [TieCod], [TieDsc], [TieAbr], [TieSts] FROM [SGTIENDAS] WITH (UPDLOCK) WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S3", "SELECT [TieCod], [TieDsc], [TieAbr], [TieSts] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S4", "SELECT TM1.[TieCod], TM1.[TieDsc], TM1.[TieAbr], TM1.[TieSts] FROM [SGTIENDAS] TM1 WHERE TM1.[TieCod] = @TieCod ORDER BY TM1.[TieCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S5", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S6", "SELECT TOP 1 [TieCod] FROM [SGTIENDAS] WHERE ( [TieCod] > @TieCod) ORDER BY [TieCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S7", "SELECT TOP 1 [TieCod] FROM [SGTIENDAS] WHERE ( [TieCod] < @TieCod) ORDER BY [TieCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S8", "INSERT INTO [SGTIENDAS]([TieCod], [TieDsc], [TieAbr], [TieSts]) VALUES(@TieCod, @TieDsc, @TieAbr, @TieSts)", GxErrorMask.GX_NOMASK,prmT000S8)
           ,new CursorDef("T000S9", "UPDATE [SGTIENDAS] SET [TieDsc]=@TieDsc, [TieAbr]=@TieAbr, [TieSts]=@TieSts  WHERE [TieCod] = @TieCod", GxErrorMask.GX_NOMASK,prmT000S9)
           ,new CursorDef("T000S10", "DELETE FROM [SGTIENDAS]  WHERE [TieCod] = @TieCod", GxErrorMask.GX_NOMASK,prmT000S10)
           ,new CursorDef("T000S11", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuTieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S12", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S13", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S14", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S15", "SELECT [TieCod] FROM [SGTIENDAS] ORDER BY [TieCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
