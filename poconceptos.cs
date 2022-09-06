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
   public class poconceptos : GXDataArea
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
            A314PoConcLinCod = (int)(NumberUtil.Val( GetPar( "PoConcLinCod"), "."));
            n314PoConcLinCod = false;
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A314PoConcLinCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A315PoConcDCueCod = GetPar( "PoConcDCueCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A315PoConcDCueCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpoconceptos_level1") == 0 )
         {
            nRC_GXsfl_54 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_54"), "."));
            nGXsfl_54_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_54_idx"), "."));
            sGXsfl_54_idx = GetPar( "sGXsfl_54_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridpoconceptos_level1_newrow( ) ;
            return  ;
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
            Form.Meta.addItem("description", "POCONCEPTOS", 0) ;
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

      public poconceptos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poconceptos( IGxContext context )
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
         cmbPoConcTip = new GXCombobox();
         cmbPoConcSts = new GXCombobox();
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
         if ( cmbPoConcTip.ItemCount > 0 )
         {
            A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
            AssignProp("", false, cmbPoConcTip_Internalname, "Values", cmbPoConcTip.ToJavascriptSource(), true);
         }
         if ( cmbPoConcSts.ItemCount > 0 )
         {
            A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0))), "."));
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            AssignProp("", false, cmbPoConcSts_Internalname, "Values", cmbPoConcSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "POCONCEPTOS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_POCONCEPTOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POCONCEPTOS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPoConcCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A313PoConcCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPoConcCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcDsc_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcDsc_Internalname, StringUtil.RTrim( A1648PoConcDsc), StringUtil.RTrim( context.localUtil.Format( A1648PoConcDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPoConcLinCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPoConcLinCod_Internalname, "Linea Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPoConcLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A314PoConcLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPoConcLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A314PoConcLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A314PoConcLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPoConcLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPoConcLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPoConcTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPoConcTip_Internalname, "Tipo de Distribución", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPoConcTip, cmbPoConcTip_Internalname, StringUtil.RTrim( A1650PoConcTip), 1, cmbPoConcTip_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPoConcTip.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_POCONCEPTOS.htm");
         cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
         AssignProp("", false, cmbPoConcTip_Internalname, "Values", (string)(cmbPoConcTip.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPoConcSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPoConcSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPoConcSts, cmbPoConcSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0)), 1, cmbPoConcSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbPoConcSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 1, "HLP_POCONCEPTOS.htm");
         cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         AssignProp("", false, cmbPoConcSts_Internalname, "Values", (string)(cmbPoConcSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelevel1_Internalname, "Level1", "", "", lblTitlelevel1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridpoconceptos_level1( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCONCEPTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridpoconceptos_level1( )
      {
         /*  Grid Control  */
         Gridpoconceptos_level1Container.AddObjectProperty("GridName", "Gridpoconceptos_level1");
         Gridpoconceptos_level1Container.AddObjectProperty("Header", subGridpoconceptos_level1_Header);
         Gridpoconceptos_level1Container.AddObjectProperty("Class", "Grid");
         Gridpoconceptos_level1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Backcolorstyle), 1, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("CmpContext", "");
         Gridpoconceptos_level1Container.AddObjectProperty("InMasterPage", "false");
         Gridpoconceptos_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpoconceptos_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A315PoConcDCueCod));
         Gridpoconceptos_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", "")));
         Gridpoconceptos_level1Container.AddColumnProperties(Gridpoconceptos_level1Column);
         Gridpoconceptos_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpoconceptos_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A1647PoConcDCueDsc));
         Gridpoconceptos_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", "")));
         Gridpoconceptos_level1Container.AddColumnProperties(Gridpoconceptos_level1Column);
         Gridpoconceptos_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpoconceptos_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A316PoConcCosCod));
         Gridpoconceptos_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", "")));
         Gridpoconceptos_level1Container.AddColumnProperties(Gridpoconceptos_level1Column);
         Gridpoconceptos_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Selectedindex), 4, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Allowselection), 1, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Selectioncolor), 9, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Allowhovering), 1, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridpoconceptos_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpoconceptos_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_54_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount182 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_182 = 1;
               ScanStart42182( ) ;
               while ( RcdFound182 != 0 )
               {
                  init_level_properties182( ) ;
                  getByPrimaryKey42182( ) ;
                  AddRow42182( ) ;
                  ScanNext42182( ) ;
               }
               ScanEnd42182( ) ;
               nBlankRcdCount182 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal42182( ) ;
            standaloneModal42182( ) ;
            sMode182 = Gx_mode;
            while ( nGXsfl_54_idx < nRC_GXsfl_54 )
            {
               bGXsfl_54_Refreshing = true;
               ReadRow42182( ) ;
               edtPoConcDCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUECOD_"+sGXsfl_54_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
               edtPoConcDCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUEDSC_"+sGXsfl_54_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), !bGXsfl_54_Refreshing);
               edtPoConcCosCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCCOSCOD_"+sGXsfl_54_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPoConcCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCosCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
               if ( ( nRcdExists_182 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal42182( ) ;
               }
               SendRow42182( ) ;
               bGXsfl_54_Refreshing = false;
            }
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount182 = 5;
            nRcdExists_182 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart42182( ) ;
               while ( RcdFound182 != 0 )
               {
                  sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_54182( ) ;
                  init_level_properties182( ) ;
                  standaloneNotModal42182( ) ;
                  getByPrimaryKey42182( ) ;
                  standaloneModal42182( ) ;
                  AddRow42182( ) ;
                  ScanNext42182( ) ;
               }
               ScanEnd42182( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode182 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx+1), 4, 0), 4, "0");
         SubsflControlProps_54182( ) ;
         InitAll42182( ) ;
         init_level_properties182( ) ;
         nRcdExists_182 = 0;
         nIsMod_182 = 0;
         nRcdDeleted_182 = 0;
         nBlankRcdCount182 = (short)(nBlankRcdUsr182+nBlankRcdCount182);
         fRowAdded = 0;
         while ( nBlankRcdCount182 > 0 )
         {
            standaloneNotModal42182( ) ;
            standaloneModal42182( ) ;
            AddRow42182( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPoConcDCueCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount182 = (short)(nBlankRcdCount182-1);
         }
         Gx_mode = sMode182;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpoconceptos_level1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpoconceptos_level1", Gridpoconceptos_level1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpoconceptos_level1ContainerData", Gridpoconceptos_level1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpoconceptos_level1ContainerData"+"V", Gridpoconceptos_level1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpoconceptos_level1ContainerData"+"V"+"\" value='"+Gridpoconceptos_level1Container.GridValuesHidden()+"'/>") ;
         }
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
            Z1648PoConcDsc = cgiGet( "Z1648PoConcDsc");
            Z1650PoConcTip = cgiGet( "Z1650PoConcTip");
            Z1649PoConcSts = (short)(context.localUtil.CToN( cgiGet( "Z1649PoConcSts"), ".", ","));
            Z314PoConcLinCod = (int)(context.localUtil.CToN( cgiGet( "Z314PoConcLinCod"), ".", ","));
            n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_54 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_54"), ".", ","));
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
            A1648PoConcDsc = cgiGet( edtPoConcDsc_Internalname);
            AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPoConcLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPoConcLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A314PoConcLinCod = 0;
               n314PoConcLinCod = false;
               AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            }
            else
            {
               A314PoConcLinCod = (int)(context.localUtil.CToN( cgiGet( edtPoConcLinCod_Internalname), ".", ","));
               n314PoConcLinCod = false;
               AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            }
            n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
            cmbPoConcTip.Name = cmbPoConcTip_Internalname;
            cmbPoConcTip.CurrentValue = cgiGet( cmbPoConcTip_Internalname);
            A1650PoConcTip = cgiGet( cmbPoConcTip_Internalname);
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
            cmbPoConcSts.Name = cmbPoConcSts_Internalname;
            cmbPoConcSts.CurrentValue = cgiGet( cmbPoConcSts_Internalname);
            A1649PoConcSts = (short)(NumberUtil.Val( cgiGet( cmbPoConcSts_Internalname), "."));
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll42141( ) ;
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
         DisableAttributes42141( ) ;
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

      protected void CONFIRM_42182( )
      {
         nGXsfl_54_idx = 0;
         while ( nGXsfl_54_idx < nRC_GXsfl_54 )
         {
            ReadRow42182( ) ;
            if ( ( nRcdExists_182 != 0 ) || ( nIsMod_182 != 0 ) )
            {
               GetKey42182( ) ;
               if ( ( nRcdExists_182 == 0 ) && ( nRcdDeleted_182 == 0 ) )
               {
                  if ( RcdFound182 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate42182( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable42182( ) ;
                        CloseExtendedTableCursors42182( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "POCONCDCUECOD_" + sGXsfl_54_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPoConcDCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound182 != 0 )
                  {
                     if ( nRcdDeleted_182 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey42182( ) ;
                        Load42182( ) ;
                        BeforeValidate42182( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls42182( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_182 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate42182( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable42182( ) ;
                              CloseExtendedTableCursors42182( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_182 == 0 )
                     {
                        GXCCtl = "POCONCDCUECOD_" + sGXsfl_54_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPoConcDCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPoConcDCueCod_Internalname, StringUtil.RTrim( A315PoConcDCueCod)) ;
            ChangePostValue( edtPoConcDCueDsc_Internalname, StringUtil.RTrim( A1647PoConcDCueDsc)) ;
            ChangePostValue( edtPoConcCosCod_Internalname, StringUtil.RTrim( A316PoConcCosCod)) ;
            ChangePostValue( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_54_idx, StringUtil.RTrim( Z315PoConcDCueCod)) ;
            ChangePostValue( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_54_idx, StringUtil.RTrim( Z316PoConcCosCod)) ;
            ChangePostValue( "nRcdDeleted_182_"+sGXsfl_54_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_182_"+sGXsfl_54_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_182_"+sGXsfl_54_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_182), 4, 0, ".", ""))) ;
            if ( nIsMod_182 != 0 )
            {
               ChangePostValue( "POCONCDCUECOD_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCDCUEDSC_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCCOSCOD_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption420( )
      {
      }

      protected void ZM42141( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1648PoConcDsc = T00426_A1648PoConcDsc[0];
               Z1650PoConcTip = T00426_A1650PoConcTip[0];
               Z1649PoConcSts = T00426_A1649PoConcSts[0];
               Z314PoConcLinCod = T00426_A314PoConcLinCod[0];
            }
            else
            {
               Z1648PoConcDsc = A1648PoConcDsc;
               Z1650PoConcTip = A1650PoConcTip;
               Z1649PoConcSts = A1649PoConcSts;
               Z314PoConcLinCod = A314PoConcLinCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z313PoConcCod = A313PoConcCod;
            Z1648PoConcDsc = A1648PoConcDsc;
            Z1650PoConcTip = A1650PoConcTip;
            Z1649PoConcSts = A1649PoConcSts;
            Z314PoConcLinCod = A314PoConcLinCod;
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

      protected void Load42141( )
      {
         /* Using cursor T00428 */
         pr_default.execute(6, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound141 = 1;
            A1648PoConcDsc = T00428_A1648PoConcDsc[0];
            AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
            A1650PoConcTip = T00428_A1650PoConcTip[0];
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
            A1649PoConcSts = T00428_A1649PoConcSts[0];
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            A314PoConcLinCod = T00428_A314PoConcLinCod[0];
            n314PoConcLinCod = T00428_n314PoConcLinCod[0];
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            ZM42141( -1) ;
         }
         pr_default.close(6);
         OnLoadActions42141( ) ;
      }

      protected void OnLoadActions42141( )
      {
      }

      protected void CheckExtendedTable42141( )
      {
         nIsDirty_141 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00427 */
         pr_default.execute(5, new Object[] {n314PoConcLinCod, A314PoConcLinCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A314PoConcLinCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Conceptos Produccion'.", "ForeignKeyNotFound", 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors42141( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A314PoConcLinCod )
      {
         /* Using cursor T00429 */
         pr_default.execute(7, new Object[] {n314PoConcLinCod, A314PoConcLinCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A314PoConcLinCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Conceptos Produccion'.", "ForeignKeyNotFound", 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey42141( )
      {
         /* Using cursor T004210 */
         pr_default.execute(8, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound141 = 1;
         }
         else
         {
            RcdFound141 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00426 */
         pr_default.execute(4, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM42141( 1) ;
            RcdFound141 = 1;
            A313PoConcCod = T00426_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
            A1648PoConcDsc = T00426_A1648PoConcDsc[0];
            AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
            A1650PoConcTip = T00426_A1650PoConcTip[0];
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
            A1649PoConcSts = T00426_A1649PoConcSts[0];
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
            A314PoConcLinCod = T00426_A314PoConcLinCod[0];
            n314PoConcLinCod = T00426_n314PoConcLinCod[0];
            AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
            Z313PoConcCod = A313PoConcCod;
            sMode141 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load42141( ) ;
            if ( AnyError == 1 )
            {
               RcdFound141 = 0;
               InitializeNonKey42141( ) ;
            }
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound141 = 0;
            InitializeNonKey42141( ) ;
            sMode141 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode141;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey42141( ) ;
         if ( RcdFound141 == 0 )
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
         RcdFound141 = 0;
         /* Using cursor T004211 */
         pr_default.execute(9, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T004211_A313PoConcCod[0] < A313PoConcCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T004211_A313PoConcCod[0] > A313PoConcCod ) ) )
            {
               A313PoConcCod = T004211_A313PoConcCod[0];
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               RcdFound141 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound141 = 0;
         /* Using cursor T004212 */
         pr_default.execute(10, new Object[] {A313PoConcCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T004212_A313PoConcCod[0] > A313PoConcCod ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T004212_A313PoConcCod[0] < A313PoConcCod ) ) )
            {
               A313PoConcCod = T004212_A313PoConcCod[0];
               AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
               RcdFound141 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey42141( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert42141( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound141 == 1 )
            {
               if ( A313PoConcCod != Z313PoConcCod )
               {
                  A313PoConcCod = Z313PoConcCod;
                  AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
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
                  Update42141( ) ;
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A313PoConcCod != Z313PoConcCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPoConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert42141( ) ;
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
                     Insert42141( ) ;
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
         if ( A313PoConcCod != Z313PoConcCod )
         {
            A313PoConcCod = Z313PoConcCod;
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
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
         if ( RcdFound141 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "POCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPoConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart42141( ) ;
         if ( RcdFound141 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd42141( ) ;
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
         if ( RcdFound141 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcDsc_Internalname;
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
         if ( RcdFound141 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcDsc_Internalname;
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
         ScanStart42141( ) ;
         if ( RcdFound141 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound141 != 0 )
            {
               ScanNext42141( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPoConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd42141( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency42141( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00425 */
            pr_default.execute(3, new Object[] {A313PoConcCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z1648PoConcDsc, T00425_A1648PoConcDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1650PoConcTip, T00425_A1650PoConcTip[0]) != 0 ) || ( Z1649PoConcSts != T00425_A1649PoConcSts[0] ) || ( Z314PoConcLinCod != T00425_A314PoConcLinCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z1648PoConcDsc, T00425_A1648PoConcDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("poconceptos:[seudo value changed for attri]"+"PoConcDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1648PoConcDsc);
                  GXUtil.WriteLogRaw("Current: ",T00425_A1648PoConcDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1650PoConcTip, T00425_A1650PoConcTip[0]) != 0 )
               {
                  GXUtil.WriteLog("poconceptos:[seudo value changed for attri]"+"PoConcTip");
                  GXUtil.WriteLogRaw("Old: ",Z1650PoConcTip);
                  GXUtil.WriteLogRaw("Current: ",T00425_A1650PoConcTip[0]);
               }
               if ( Z1649PoConcSts != T00425_A1649PoConcSts[0] )
               {
                  GXUtil.WriteLog("poconceptos:[seudo value changed for attri]"+"PoConcSts");
                  GXUtil.WriteLogRaw("Old: ",Z1649PoConcSts);
                  GXUtil.WriteLogRaw("Current: ",T00425_A1649PoConcSts[0]);
               }
               if ( Z314PoConcLinCod != T00425_A314PoConcLinCod[0] )
               {
                  GXUtil.WriteLog("poconceptos:[seudo value changed for attri]"+"PoConcLinCod");
                  GXUtil.WriteLogRaw("Old: ",Z314PoConcLinCod);
                  GXUtil.WriteLogRaw("Current: ",T00425_A314PoConcLinCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCONCEPTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert42141( )
      {
         BeforeValidate42141( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable42141( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM42141( 0) ;
            CheckOptimisticConcurrency42141( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm42141( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert42141( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004213 */
                     pr_default.execute(11, new Object[] {A313PoConcCod, A1648PoConcDsc, A1650PoConcTip, A1649PoConcSts, n314PoConcLinCod, A314PoConcLinCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOS");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ProcessLevel42141( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption420( ) ;
                           }
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
               Load42141( ) ;
            }
            EndLevel42141( ) ;
         }
         CloseExtendedTableCursors42141( ) ;
      }

      protected void Update42141( )
      {
         BeforeValidate42141( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable42141( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency42141( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm42141( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate42141( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004214 */
                     pr_default.execute(12, new Object[] {A1648PoConcDsc, A1650PoConcTip, A1649PoConcSts, n314PoConcLinCod, A314PoConcLinCod, A313PoConcCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOS");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate42141( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel42141( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption420( ) ;
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
            }
            EndLevel42141( ) ;
         }
         CloseExtendedTableCursors42141( ) ;
      }

      protected void DeferredUpdate42141( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate42141( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency42141( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls42141( ) ;
            AfterConfirm42141( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete42141( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart42182( ) ;
                  while ( RcdFound182 != 0 )
                  {
                     getByPrimaryKey42182( ) ;
                     Delete42182( ) ;
                     ScanNext42182( ) ;
                  }
                  ScanEnd42182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004215 */
                     pr_default.execute(13, new Object[] {A313PoConcCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound141 == 0 )
                           {
                              InitAll42141( ) ;
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
                           ResetCaption420( ) ;
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
         }
         sMode141 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel42141( ) ;
         Gx_mode = sMode141;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls42141( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel42182( )
      {
         nGXsfl_54_idx = 0;
         while ( nGXsfl_54_idx < nRC_GXsfl_54 )
         {
            ReadRow42182( ) ;
            if ( ( nRcdExists_182 != 0 ) || ( nIsMod_182 != 0 ) )
            {
               standaloneNotModal42182( ) ;
               GetKey42182( ) ;
               if ( ( nRcdExists_182 == 0 ) && ( nRcdDeleted_182 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert42182( ) ;
               }
               else
               {
                  if ( RcdFound182 != 0 )
                  {
                     if ( ( nRcdDeleted_182 != 0 ) && ( nRcdExists_182 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete42182( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_182 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update42182( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_182 == 0 )
                     {
                        GXCCtl = "POCONCDCUECOD_" + sGXsfl_54_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPoConcDCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPoConcDCueCod_Internalname, StringUtil.RTrim( A315PoConcDCueCod)) ;
            ChangePostValue( edtPoConcDCueDsc_Internalname, StringUtil.RTrim( A1647PoConcDCueDsc)) ;
            ChangePostValue( edtPoConcCosCod_Internalname, StringUtil.RTrim( A316PoConcCosCod)) ;
            ChangePostValue( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_54_idx, StringUtil.RTrim( Z315PoConcDCueCod)) ;
            ChangePostValue( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_54_idx, StringUtil.RTrim( Z316PoConcCosCod)) ;
            ChangePostValue( "nRcdDeleted_182_"+sGXsfl_54_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_182_"+sGXsfl_54_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_182), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_182_"+sGXsfl_54_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_182), 4, 0, ".", ""))) ;
            if ( nIsMod_182 != 0 )
            {
               ChangePostValue( "POCONCDCUECOD_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCDCUEDSC_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "POCONCCOSCOD_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll42182( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_182 = 0;
         nIsMod_182 = 0;
         nRcdDeleted_182 = 0;
      }

      protected void ProcessLevel42141( )
      {
         /* Save parent mode. */
         sMode141 = Gx_mode;
         ProcessNestedLevel42182( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode141;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel42141( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete42141( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("poconceptos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues420( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("poconceptos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart42141( )
      {
         /* Using cursor T004216 */
         pr_default.execute(14);
         RcdFound141 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound141 = 1;
            A313PoConcCod = T004216_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext42141( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound141 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound141 = 1;
            A313PoConcCod = T004216_A313PoConcCod[0];
            AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         }
      }

      protected void ScanEnd42141( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm42141( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert42141( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate42141( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete42141( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete42141( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate42141( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes42141( )
      {
         edtPoConcCod_Enabled = 0;
         AssignProp("", false, edtPoConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCod_Enabled), 5, 0), true);
         edtPoConcDsc_Enabled = 0;
         AssignProp("", false, edtPoConcDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDsc_Enabled), 5, 0), true);
         edtPoConcLinCod_Enabled = 0;
         AssignProp("", false, edtPoConcLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcLinCod_Enabled), 5, 0), true);
         cmbPoConcTip.Enabled = 0;
         AssignProp("", false, cmbPoConcTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPoConcTip.Enabled), 5, 0), true);
         cmbPoConcSts.Enabled = 0;
         AssignProp("", false, cmbPoConcSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPoConcSts.Enabled), 5, 0), true);
      }

      protected void ZM42182( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z316PoConcCosCod = T00423_A316PoConcCosCod[0];
            }
            else
            {
               Z316PoConcCosCod = A316PoConcCosCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z313PoConcCod = A313PoConcCod;
            Z316PoConcCosCod = A316PoConcCosCod;
            Z315PoConcDCueCod = A315PoConcDCueCod;
            Z1647PoConcDCueDsc = A1647PoConcDCueDsc;
         }
      }

      protected void standaloneNotModal42182( )
      {
      }

      protected void standaloneModal42182( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPoConcDCueCod_Enabled = 0;
            AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
         }
         else
         {
            edtPoConcDCueCod_Enabled = 1;
            AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
         }
      }

      protected void Load42182( )
      {
         /* Using cursor T004217 */
         pr_default.execute(15, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound182 = 1;
            A1647PoConcDCueDsc = T004217_A1647PoConcDCueDsc[0];
            A316PoConcCosCod = T004217_A316PoConcCosCod[0];
            ZM42182( -3) ;
         }
         pr_default.close(15);
         OnLoadActions42182( ) ;
      }

      protected void OnLoadActions42182( )
      {
      }

      protected void CheckExtendedTable42182( )
      {
         nIsDirty_182 = 0;
         Gx_BScreen = 1;
         standaloneModal42182( ) ;
         /* Using cursor T00424 */
         pr_default.execute(2, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "POCONCDCUECOD_" + sGXsfl_54_idx;
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T00424_A1647PoConcDCueDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors42182( )
      {
         pr_default.close(2);
      }

      protected void enableDisable42182( )
      {
      }

      protected void gxLoad_4( string A315PoConcDCueCod )
      {
         /* Using cursor T004218 */
         pr_default.execute(16, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "POCONCDCUECOD_" + sGXsfl_54_idx;
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1647PoConcDCueDsc = T004218_A1647PoConcDCueDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1647PoConcDCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey42182( )
      {
         /* Using cursor T004219 */
         pr_default.execute(17, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound182 = 1;
         }
         else
         {
            RcdFound182 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey42182( )
      {
         /* Using cursor T00423 */
         pr_default.execute(1, new Object[] {A313PoConcCod, A315PoConcDCueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM42182( 3) ;
            RcdFound182 = 1;
            InitializeNonKey42182( ) ;
            A316PoConcCosCod = T00423_A316PoConcCosCod[0];
            A315PoConcDCueCod = T00423_A315PoConcDCueCod[0];
            Z313PoConcCod = A313PoConcCod;
            Z315PoConcDCueCod = A315PoConcDCueCod;
            sMode182 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal42182( ) ;
            Load42182( ) ;
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound182 = 0;
            InitializeNonKey42182( ) ;
            sMode182 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal42182( ) ;
            Gx_mode = sMode182;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes42182( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency42182( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00422 */
            pr_default.execute(0, new Object[] {A313PoConcCod, A315PoConcDCueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z316PoConcCosCod, T00422_A316PoConcCosCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z316PoConcCosCod, T00422_A316PoConcCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poconceptos:[seudo value changed for attri]"+"PoConcCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z316PoConcCosCod);
                  GXUtil.WriteLogRaw("Current: ",T00422_A316PoConcCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCONCEPTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert42182( )
      {
         BeforeValidate42182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable42182( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM42182( 0) ;
            CheckOptimisticConcurrency42182( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm42182( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert42182( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004220 */
                     pr_default.execute(18, new Object[] {A313PoConcCod, A316PoConcCosCod, A315PoConcDCueCod});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load42182( ) ;
            }
            EndLevel42182( ) ;
         }
         CloseExtendedTableCursors42182( ) ;
      }

      protected void Update42182( )
      {
         BeforeValidate42182( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable42182( ) ;
         }
         if ( ( nIsMod_182 != 0 ) || ( nIsDirty_182 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency42182( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm42182( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate42182( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T004221 */
                        pr_default.execute(19, new Object[] {A316PoConcCosCod, A313PoConcCod, A315PoConcDCueCod});
                        pr_default.close(19);
                        dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCONCEPTOSDET"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate42182( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey42182( ) ;
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
               EndLevel42182( ) ;
            }
         }
         CloseExtendedTableCursors42182( ) ;
      }

      protected void DeferredUpdate42182( )
      {
      }

      protected void Delete42182( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate42182( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency42182( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls42182( ) ;
            AfterConfirm42182( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete42182( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004222 */
                  pr_default.execute(20, new Object[] {A313PoConcCod, A315PoConcDCueCod});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("POCONCEPTOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
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
         EndLevel42182( ) ;
         Gx_mode = sMode182;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls42182( )
      {
         standaloneModal42182( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004223 */
            pr_default.execute(21, new Object[] {A315PoConcDCueCod});
            A1647PoConcDCueDsc = T004223_A1647PoConcDCueDsc[0];
            pr_default.close(21);
         }
      }

      protected void EndLevel42182( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart42182( )
      {
         /* Scan By routine */
         /* Using cursor T004224 */
         pr_default.execute(22, new Object[] {A313PoConcCod});
         RcdFound182 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound182 = 1;
            A315PoConcDCueCod = T004224_A315PoConcDCueCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext42182( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound182 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound182 = 1;
            A315PoConcDCueCod = T004224_A315PoConcDCueCod[0];
         }
      }

      protected void ScanEnd42182( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm42182( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert42182( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate42182( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete42182( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete42182( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate42182( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes42182( )
      {
         edtPoConcDCueCod_Enabled = 0;
         AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
         edtPoConcDCueDsc_Enabled = 0;
         AssignProp("", false, edtPoConcDCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0), !bGXsfl_54_Refreshing);
         edtPoConcCosCod_Enabled = 0;
         AssignProp("", false, edtPoConcCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcCosCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
      }

      protected void send_integrity_lvl_hashes42182( )
      {
      }

      protected void send_integrity_lvl_hashes42141( )
      {
      }

      protected void SubsflControlProps_54182( )
      {
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD_"+sGXsfl_54_idx;
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC_"+sGXsfl_54_idx;
         edtPoConcCosCod_Internalname = "POCONCCOSCOD_"+sGXsfl_54_idx;
      }

      protected void SubsflControlProps_fel_54182( )
      {
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD_"+sGXsfl_54_fel_idx;
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC_"+sGXsfl_54_fel_idx;
         edtPoConcCosCod_Internalname = "POCONCCOSCOD_"+sGXsfl_54_fel_idx;
      }

      protected void AddRow42182( )
      {
         nGXsfl_54_idx = (int)(nGXsfl_54_idx+1);
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_54182( ) ;
         SendRow42182( ) ;
      }

      protected void SendRow42182( )
      {
         Gridpoconceptos_level1Row = GXWebRow.GetNew(context);
         if ( subGridpoconceptos_level1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpoconceptos_level1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpoconceptos_level1_Class, "") != 0 )
            {
               subGridpoconceptos_level1_Linesclass = subGridpoconceptos_level1_Class+"Odd";
            }
         }
         else if ( subGridpoconceptos_level1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpoconceptos_level1_Backstyle = 0;
            subGridpoconceptos_level1_Backcolor = subGridpoconceptos_level1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpoconceptos_level1_Class, "") != 0 )
            {
               subGridpoconceptos_level1_Linesclass = subGridpoconceptos_level1_Class+"Uniform";
            }
         }
         else if ( subGridpoconceptos_level1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpoconceptos_level1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpoconceptos_level1_Class, "") != 0 )
            {
               subGridpoconceptos_level1_Linesclass = subGridpoconceptos_level1_Class+"Odd";
            }
            subGridpoconceptos_level1_Backcolor = (int)(0x0);
         }
         else if ( subGridpoconceptos_level1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpoconceptos_level1_Backstyle = 1;
            if ( ((int)((nGXsfl_54_idx) % (2))) == 0 )
            {
               subGridpoconceptos_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpoconceptos_level1_Class, "") != 0 )
               {
                  subGridpoconceptos_level1_Linesclass = subGridpoconceptos_level1_Class+"Even";
               }
            }
            else
            {
               subGridpoconceptos_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpoconceptos_level1_Class, "") != 0 )
               {
                  subGridpoconceptos_level1_Linesclass = subGridpoconceptos_level1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_182_" + sGXsfl_54_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_54_idx + "',54)\"";
         ROClassString = "Attribute";
         Gridpoconceptos_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcDCueCod_Internalname,StringUtil.RTrim( A315PoConcDCueCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcDCueCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPoConcDCueCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpoconceptos_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcDCueDsc_Internalname,StringUtil.RTrim( A1647PoConcDCueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcDCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPoConcDCueDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_182_" + sGXsfl_54_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_54_idx + "',54)\"";
         ROClassString = "Attribute";
         Gridpoconceptos_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPoConcCosCod_Internalname,StringUtil.RTrim( A316PoConcCosCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPoConcCosCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPoConcCosCod_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridpoconceptos_level1Row);
         send_integrity_lvl_hashes42182( ) ;
         GXCCtl = "Z315PoConcDCueCod_" + sGXsfl_54_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z315PoConcDCueCod));
         GXCCtl = "Z316PoConcCosCod_" + sGXsfl_54_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z316PoConcCosCod));
         GXCCtl = "nRcdDeleted_182_" + sGXsfl_54_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_182), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_182_" + sGXsfl_54_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_182), 4, 0, ".", "")));
         GXCCtl = "nIsMod_182_" + sGXsfl_54_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_182), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POCONCDCUECOD_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POCONCDCUEDSC_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcDCueDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POCONCCOSCOD_"+sGXsfl_54_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPoConcCosCod_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridpoconceptos_level1Container.AddRow(Gridpoconceptos_level1Row);
      }

      protected void ReadRow42182( )
      {
         nGXsfl_54_idx = (int)(nGXsfl_54_idx+1);
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_54182( ) ;
         edtPoConcDCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUECOD_"+sGXsfl_54_idx+"Enabled"), ".", ","));
         edtPoConcDCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCDCUEDSC_"+sGXsfl_54_idx+"Enabled"), ".", ","));
         edtPoConcCosCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "POCONCCOSCOD_"+sGXsfl_54_idx+"Enabled"), ".", ","));
         A315PoConcDCueCod = cgiGet( edtPoConcDCueCod_Internalname);
         A1647PoConcDCueDsc = cgiGet( edtPoConcDCueDsc_Internalname);
         A316PoConcCosCod = cgiGet( edtPoConcCosCod_Internalname);
         GXCCtl = "Z315PoConcDCueCod_" + sGXsfl_54_idx;
         Z315PoConcDCueCod = cgiGet( GXCCtl);
         GXCCtl = "Z316PoConcCosCod_" + sGXsfl_54_idx;
         Z316PoConcCosCod = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_182_" + sGXsfl_54_idx;
         nRcdDeleted_182 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_182_" + sGXsfl_54_idx;
         nRcdExists_182 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_182_" + sGXsfl_54_idx;
         nIsMod_182 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtPoConcDCueCod_Enabled = edtPoConcDCueCod_Enabled;
      }

      protected void ConfirmValues420( )
      {
         nGXsfl_54_idx = 0;
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_54182( ) ;
         while ( nGXsfl_54_idx < nRC_GXsfl_54 )
         {
            nGXsfl_54_idx = (int)(nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_54182( ) ;
            ChangePostValue( "Z315PoConcDCueCod_"+sGXsfl_54_idx, cgiGet( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_54_idx)) ;
            DeletePostValue( "ZT_"+"Z315PoConcDCueCod_"+sGXsfl_54_idx) ;
            ChangePostValue( "Z316PoConcCosCod_"+sGXsfl_54_idx, cgiGet( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_54_idx)) ;
            DeletePostValue( "ZT_"+"Z316PoConcCosCod_"+sGXsfl_54_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252626", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("poconceptos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1648PoConcDsc", StringUtil.RTrim( Z1648PoConcDsc));
         GxWebStd.gx_hidden_field( context, "Z1650PoConcTip", StringUtil.RTrim( Z1650PoConcTip));
         GxWebStd.gx_hidden_field( context, "Z1649PoConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1649PoConcSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z314PoConcLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z314PoConcLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_54", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_54_idx), 8, 0, ".", "")));
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
         return formatLink("poconceptos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POCONCEPTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "POCONCEPTOS" ;
      }

      protected void InitializeNonKey42141( )
      {
         A1648PoConcDsc = "";
         AssignAttri("", false, "A1648PoConcDsc", A1648PoConcDsc);
         A314PoConcLinCod = 0;
         n314PoConcLinCod = false;
         AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrimStr( (decimal)(A314PoConcLinCod), 6, 0));
         n314PoConcLinCod = ((0==A314PoConcLinCod) ? true : false);
         A1650PoConcTip = "";
         AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
         A1649PoConcSts = 0;
         AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         Z1648PoConcDsc = "";
         Z1650PoConcTip = "";
         Z1649PoConcSts = 0;
         Z314PoConcLinCod = 0;
      }

      protected void InitAll42141( )
      {
         A313PoConcCod = 0;
         AssignAttri("", false, "A313PoConcCod", StringUtil.LTrimStr( (decimal)(A313PoConcCod), 6, 0));
         InitializeNonKey42141( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey42182( )
      {
         A1647PoConcDCueDsc = "";
         A316PoConcCosCod = "";
         Z316PoConcCosCod = "";
      }

      protected void InitAll42182( )
      {
         A315PoConcDCueCod = "";
         InitializeNonKey42182( ) ;
      }

      protected void StandaloneModalInsert42182( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252635", true, true);
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
         context.AddJavascriptSource("poconceptos.js", "?202281810252635", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties182( )
      {
         edtPoConcDCueCod_Enabled = defedtPoConcDCueCod_Enabled;
         AssignProp("", false, edtPoConcDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPoConcDCueCod_Enabled), 5, 0), !bGXsfl_54_Refreshing);
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
         edtPoConcDsc_Internalname = "POCONCDSC";
         edtPoConcLinCod_Internalname = "POCONCLINCOD";
         cmbPoConcTip_Internalname = "POCONCTIP";
         cmbPoConcSts_Internalname = "POCONCSTS";
         lblTitlelevel1_Internalname = "TITLELEVEL1";
         edtPoConcDCueCod_Internalname = "POCONCDCUECOD";
         edtPoConcDCueDsc_Internalname = "POCONCDCUEDSC";
         edtPoConcCosCod_Internalname = "POCONCCOSCOD";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridpoconceptos_level1_Internalname = "GRIDPOCONCEPTOS_LEVEL1";
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
         Form.Caption = "POCONCEPTOS";
         edtPoConcCosCod_Jsonclick = "";
         edtPoConcDCueDsc_Jsonclick = "";
         edtPoConcDCueCod_Jsonclick = "";
         subGridpoconceptos_level1_Class = "Grid";
         subGridpoconceptos_level1_Backcolorstyle = 0;
         subGridpoconceptos_level1_Allowcollapsing = 0;
         subGridpoconceptos_level1_Allowselection = 0;
         edtPoConcCosCod_Enabled = 1;
         edtPoConcDCueDsc_Enabled = 0;
         edtPoConcDCueCod_Enabled = 1;
         subGridpoconceptos_level1_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbPoConcSts_Jsonclick = "";
         cmbPoConcSts.Enabled = 1;
         cmbPoConcTip_Jsonclick = "";
         cmbPoConcTip.Enabled = 1;
         edtPoConcLinCod_Jsonclick = "";
         edtPoConcLinCod_Enabled = 1;
         edtPoConcDsc_Jsonclick = "";
         edtPoConcDsc_Enabled = 1;
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

      protected void gxnrGridpoconceptos_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_54182( ) ;
         while ( nGXsfl_54_idx <= nRC_GXsfl_54 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal42182( ) ;
            standaloneModal42182( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow42182( ) ;
            nGXsfl_54_idx = (int)(nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_54182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpoconceptos_level1Container)) ;
         /* End function gxnrGridpoconceptos_level1_newrow */
      }

      protected void init_web_controls( )
      {
         cmbPoConcTip.Name = "POCONCTIP";
         cmbPoConcTip.WebTags = "";
         cmbPoConcTip.addItem("C", "Cantidad", 0);
         cmbPoConcTip.addItem("T", "Costo", 0);
         cmbPoConcTip.addItem("H", "Horas", 0);
         cmbPoConcTip.addItem("P", "Peso", 0);
         cmbPoConcTip.addItem("V", "Volumen", 0);
         if ( cmbPoConcTip.ItemCount > 0 )
         {
            A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
            AssignAttri("", false, "A1650PoConcTip", A1650PoConcTip);
         }
         cmbPoConcSts.Name = "POCONCSTS";
         cmbPoConcSts.WebTags = "";
         cmbPoConcSts.addItem("1", "ACTIVO", 0);
         cmbPoConcSts.addItem("0", "INACTIVO", 0);
         if ( cmbPoConcSts.ItemCount > 0 )
         {
            A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0))), "."));
            AssignAttri("", false, "A1649PoConcSts", StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPoConcDsc_Internalname;
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
         A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.CurrentValue, "."));
         cmbPoConcSts.CurrentValue = StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0);
         A1650PoConcTip = cmbPoConcTip.CurrentValue;
         cmbPoConcTip.CurrentValue = A1650PoConcTip;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbPoConcTip.ItemCount > 0 )
         {
            A1650PoConcTip = cmbPoConcTip.getValidValue(A1650PoConcTip);
            cmbPoConcTip.CurrentValue = A1650PoConcTip;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
         }
         if ( cmbPoConcSts.ItemCount > 0 )
         {
            A1649PoConcSts = (short)(NumberUtil.Val( cmbPoConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0))), "."));
            cmbPoConcSts.CurrentValue = StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1648PoConcDsc", StringUtil.RTrim( A1648PoConcDsc));
         AssignAttri("", false, "A314PoConcLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A314PoConcLinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1650PoConcTip", StringUtil.RTrim( A1650PoConcTip));
         cmbPoConcTip.CurrentValue = StringUtil.RTrim( A1650PoConcTip);
         AssignProp("", false, cmbPoConcTip_Internalname, "Values", cmbPoConcTip.ToJavascriptSource(), true);
         AssignAttri("", false, "A1649PoConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1649PoConcSts), 1, 0, ".", "")));
         cmbPoConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1649PoConcSts), 1, 0));
         AssignProp("", false, cmbPoConcSts_Internalname, "Values", cmbPoConcSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z313PoConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z313PoConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1648PoConcDsc", StringUtil.RTrim( Z1648PoConcDsc));
         GxWebStd.gx_hidden_field( context, "Z314PoConcLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z314PoConcLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1650PoConcTip", StringUtil.RTrim( Z1650PoConcTip));
         GxWebStd.gx_hidden_field( context, "Z1649PoConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1649PoConcSts), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Poconclincod( )
      {
         n314PoConcLinCod = false;
         /* Using cursor T004225 */
         pr_default.execute(23, new Object[] {n314PoConcLinCod, A314PoConcLinCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A314PoConcLinCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Conceptos Produccion'.", "ForeignKeyNotFound", 1, "POCONCLINCOD");
               AnyError = 1;
               GX_FocusControl = edtPoConcLinCod_Internalname;
            }
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Poconcdcuecod( )
      {
         /* Using cursor T004223 */
         pr_default.execute(21, new Object[] {A315PoConcDCueCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Conceptos Produccion Detalle'.", "ForeignKeyNotFound", 1, "POCONCDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPoConcDCueCod_Internalname;
         }
         A1647PoConcDCueDsc = T004223_A1647PoConcDCueDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1647PoConcDCueDsc", StringUtil.RTrim( A1647PoConcDCueDsc));
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
         setEventMetadata("VALID_POCONCCOD","{handler:'Valid_Poconccod',iparms:[{av:'cmbPoConcSts'},{av:'A1649PoConcSts',fld:'POCONCSTS',pic:'9'},{av:'cmbPoConcTip'},{av:'A1650PoConcTip',fld:'POCONCTIP',pic:''},{av:'A313PoConcCod',fld:'POCONCCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_POCONCCOD",",oparms:[{av:'A1648PoConcDsc',fld:'POCONCDSC',pic:''},{av:'A314PoConcLinCod',fld:'POCONCLINCOD',pic:'ZZZZZ9'},{av:'cmbPoConcTip'},{av:'A1650PoConcTip',fld:'POCONCTIP',pic:''},{av:'cmbPoConcSts'},{av:'A1649PoConcSts',fld:'POCONCSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z313PoConcCod'},{av:'Z1648PoConcDsc'},{av:'Z314PoConcLinCod'},{av:'Z1650PoConcTip'},{av:'Z1649PoConcSts'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_POCONCLINCOD","{handler:'Valid_Poconclincod',iparms:[{av:'A314PoConcLinCod',fld:'POCONCLINCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_POCONCLINCOD",",oparms:[]}");
         setEventMetadata("VALID_POCONCDCUECOD","{handler:'Valid_Poconcdcuecod',iparms:[{av:'A315PoConcDCueCod',fld:'POCONCDCUECOD',pic:''},{av:'A1647PoConcDCueDsc',fld:'POCONCDCUEDSC',pic:''}]");
         setEventMetadata("VALID_POCONCDCUECOD",",oparms:[{av:'A1647PoConcDCueDsc',fld:'POCONCDCUEDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Poconccoscod',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(4);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1648PoConcDsc = "";
         Z1650PoConcTip = "";
         Z315PoConcDCueCod = "";
         Z316PoConcCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A315PoConcDCueCod = "";
         Gx_mode = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1650PoConcTip = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A1648PoConcDsc = "";
         lblTitlelevel1_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpoconceptos_level1Container = new GXWebGrid( context);
         Gridpoconceptos_level1Column = new GXWebColumn();
         A1647PoConcDCueDsc = "";
         A316PoConcCosCod = "";
         sMode182 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T00428_A313PoConcCod = new int[1] ;
         T00428_A1648PoConcDsc = new string[] {""} ;
         T00428_A1650PoConcTip = new string[] {""} ;
         T00428_A1649PoConcSts = new short[1] ;
         T00428_A314PoConcLinCod = new int[1] ;
         T00428_n314PoConcLinCod = new bool[] {false} ;
         T00427_A314PoConcLinCod = new int[1] ;
         T00427_n314PoConcLinCod = new bool[] {false} ;
         T00429_A314PoConcLinCod = new int[1] ;
         T00429_n314PoConcLinCod = new bool[] {false} ;
         T004210_A313PoConcCod = new int[1] ;
         T00426_A313PoConcCod = new int[1] ;
         T00426_A1648PoConcDsc = new string[] {""} ;
         T00426_A1650PoConcTip = new string[] {""} ;
         T00426_A1649PoConcSts = new short[1] ;
         T00426_A314PoConcLinCod = new int[1] ;
         T00426_n314PoConcLinCod = new bool[] {false} ;
         sMode141 = "";
         T004211_A313PoConcCod = new int[1] ;
         T004212_A313PoConcCod = new int[1] ;
         T00425_A313PoConcCod = new int[1] ;
         T00425_A1648PoConcDsc = new string[] {""} ;
         T00425_A1650PoConcTip = new string[] {""} ;
         T00425_A1649PoConcSts = new short[1] ;
         T00425_A314PoConcLinCod = new int[1] ;
         T00425_n314PoConcLinCod = new bool[] {false} ;
         T004216_A313PoConcCod = new int[1] ;
         Z1647PoConcDCueDsc = "";
         T004217_A313PoConcCod = new int[1] ;
         T004217_A1647PoConcDCueDsc = new string[] {""} ;
         T004217_A316PoConcCosCod = new string[] {""} ;
         T004217_A315PoConcDCueCod = new string[] {""} ;
         T00424_A1647PoConcDCueDsc = new string[] {""} ;
         T004218_A1647PoConcDCueDsc = new string[] {""} ;
         T004219_A313PoConcCod = new int[1] ;
         T004219_A315PoConcDCueCod = new string[] {""} ;
         T00423_A313PoConcCod = new int[1] ;
         T00423_A316PoConcCosCod = new string[] {""} ;
         T00423_A315PoConcDCueCod = new string[] {""} ;
         T00422_A313PoConcCod = new int[1] ;
         T00422_A316PoConcCosCod = new string[] {""} ;
         T00422_A315PoConcDCueCod = new string[] {""} ;
         T004223_A1647PoConcDCueDsc = new string[] {""} ;
         T004224_A313PoConcCod = new int[1] ;
         T004224_A315PoConcDCueCod = new string[] {""} ;
         Gridpoconceptos_level1Row = new GXWebRow();
         subGridpoconceptos_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1648PoConcDsc = "";
         ZZ1650PoConcTip = "";
         T004225_A314PoConcLinCod = new int[1] ;
         T004225_n314PoConcLinCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poconceptos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poconceptos__default(),
            new Object[][] {
                new Object[] {
               T00422_A313PoConcCod, T00422_A316PoConcCosCod, T00422_A315PoConcDCueCod
               }
               , new Object[] {
               T00423_A313PoConcCod, T00423_A316PoConcCosCod, T00423_A315PoConcDCueCod
               }
               , new Object[] {
               T00424_A1647PoConcDCueDsc
               }
               , new Object[] {
               T00425_A313PoConcCod, T00425_A1648PoConcDsc, T00425_A1650PoConcTip, T00425_A1649PoConcSts, T00425_A314PoConcLinCod, T00425_n314PoConcLinCod
               }
               , new Object[] {
               T00426_A313PoConcCod, T00426_A1648PoConcDsc, T00426_A1650PoConcTip, T00426_A1649PoConcSts, T00426_A314PoConcLinCod, T00426_n314PoConcLinCod
               }
               , new Object[] {
               T00427_A314PoConcLinCod
               }
               , new Object[] {
               T00428_A313PoConcCod, T00428_A1648PoConcDsc, T00428_A1650PoConcTip, T00428_A1649PoConcSts, T00428_A314PoConcLinCod, T00428_n314PoConcLinCod
               }
               , new Object[] {
               T00429_A314PoConcLinCod
               }
               , new Object[] {
               T004210_A313PoConcCod
               }
               , new Object[] {
               T004211_A313PoConcCod
               }
               , new Object[] {
               T004212_A313PoConcCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004216_A313PoConcCod
               }
               , new Object[] {
               T004217_A313PoConcCod, T004217_A1647PoConcDCueDsc, T004217_A316PoConcCosCod, T004217_A315PoConcDCueCod
               }
               , new Object[] {
               T004218_A1647PoConcDCueDsc
               }
               , new Object[] {
               T004219_A313PoConcCod, T004219_A315PoConcDCueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004223_A1647PoConcDCueDsc
               }
               , new Object[] {
               T004224_A313PoConcCod, T004224_A315PoConcDCueCod
               }
               , new Object[] {
               T004225_A314PoConcLinCod
               }
            }
         );
      }

      private short Z1649PoConcSts ;
      private short nRcdDeleted_182 ;
      private short nRcdExists_182 ;
      private short nIsMod_182 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1649PoConcSts ;
      private short subGridpoconceptos_level1_Backcolorstyle ;
      private short subGridpoconceptos_level1_Allowselection ;
      private short subGridpoconceptos_level1_Allowhovering ;
      private short subGridpoconceptos_level1_Allowcollapsing ;
      private short subGridpoconceptos_level1_Collapsed ;
      private short nBlankRcdCount182 ;
      private short RcdFound182 ;
      private short nBlankRcdUsr182 ;
      private short GX_JID ;
      private short RcdFound141 ;
      private short nIsDirty_141 ;
      private short Gx_BScreen ;
      private short nIsDirty_182 ;
      private short subGridpoconceptos_level1_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ1649PoConcSts ;
      private int Z313PoConcCod ;
      private int Z314PoConcLinCod ;
      private int nRC_GXsfl_54 ;
      private int nGXsfl_54_idx=1 ;
      private int A314PoConcLinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A313PoConcCod ;
      private int edtPoConcCod_Enabled ;
      private int edtPoConcDsc_Enabled ;
      private int edtPoConcLinCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPoConcDCueCod_Enabled ;
      private int edtPoConcDCueDsc_Enabled ;
      private int edtPoConcCosCod_Enabled ;
      private int subGridpoconceptos_level1_Selectedindex ;
      private int subGridpoconceptos_level1_Selectioncolor ;
      private int subGridpoconceptos_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridpoconceptos_level1_Backcolor ;
      private int subGridpoconceptos_level1_Allbackcolor ;
      private int defedtPoConcDCueCod_Enabled ;
      private int idxLst ;
      private int ZZ313PoConcCod ;
      private int ZZ314PoConcLinCod ;
      private long GRIDPOCONCEPTOS_LEVEL1_nFirstRecordOnPage ;
      private string sPrefix ;
      private string Z1648PoConcDsc ;
      private string Z1650PoConcTip ;
      private string Z315PoConcDCueCod ;
      private string Z316PoConcCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A315PoConcDCueCod ;
      private string sGXsfl_54_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPoConcCod_Internalname ;
      private string A1650PoConcTip ;
      private string cmbPoConcTip_Internalname ;
      private string cmbPoConcSts_Internalname ;
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
      private string edtPoConcDsc_Internalname ;
      private string A1648PoConcDsc ;
      private string edtPoConcDsc_Jsonclick ;
      private string edtPoConcLinCod_Internalname ;
      private string edtPoConcLinCod_Jsonclick ;
      private string cmbPoConcTip_Jsonclick ;
      private string cmbPoConcSts_Jsonclick ;
      private string lblTitlelevel1_Internalname ;
      private string lblTitlelevel1_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridpoconceptos_level1_Header ;
      private string A1647PoConcDCueDsc ;
      private string A316PoConcCosCod ;
      private string sMode182 ;
      private string edtPoConcDCueCod_Internalname ;
      private string edtPoConcDCueDsc_Internalname ;
      private string edtPoConcCosCod_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode141 ;
      private string Z1647PoConcDCueDsc ;
      private string sGXsfl_54_fel_idx="0001" ;
      private string subGridpoconceptos_level1_Class ;
      private string subGridpoconceptos_level1_Linesclass ;
      private string ROClassString ;
      private string edtPoConcDCueCod_Jsonclick ;
      private string edtPoConcDCueDsc_Jsonclick ;
      private string edtPoConcCosCod_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridpoconceptos_level1_Internalname ;
      private string ZZ1648PoConcDsc ;
      private string ZZ1650PoConcTip ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n314PoConcLinCod ;
      private bool wbErr ;
      private bool bGXsfl_54_Refreshing=false ;
      private GXWebGrid Gridpoconceptos_level1Container ;
      private GXWebRow Gridpoconceptos_level1Row ;
      private GXWebColumn Gridpoconceptos_level1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPoConcTip ;
      private GXCombobox cmbPoConcSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00428_A313PoConcCod ;
      private string[] T00428_A1648PoConcDsc ;
      private string[] T00428_A1650PoConcTip ;
      private short[] T00428_A1649PoConcSts ;
      private int[] T00428_A314PoConcLinCod ;
      private bool[] T00428_n314PoConcLinCod ;
      private int[] T00427_A314PoConcLinCod ;
      private bool[] T00427_n314PoConcLinCod ;
      private int[] T00429_A314PoConcLinCod ;
      private bool[] T00429_n314PoConcLinCod ;
      private int[] T004210_A313PoConcCod ;
      private int[] T00426_A313PoConcCod ;
      private string[] T00426_A1648PoConcDsc ;
      private string[] T00426_A1650PoConcTip ;
      private short[] T00426_A1649PoConcSts ;
      private int[] T00426_A314PoConcLinCod ;
      private bool[] T00426_n314PoConcLinCod ;
      private int[] T004211_A313PoConcCod ;
      private int[] T004212_A313PoConcCod ;
      private int[] T00425_A313PoConcCod ;
      private string[] T00425_A1648PoConcDsc ;
      private string[] T00425_A1650PoConcTip ;
      private short[] T00425_A1649PoConcSts ;
      private int[] T00425_A314PoConcLinCod ;
      private bool[] T00425_n314PoConcLinCod ;
      private int[] T004216_A313PoConcCod ;
      private int[] T004217_A313PoConcCod ;
      private string[] T004217_A1647PoConcDCueDsc ;
      private string[] T004217_A316PoConcCosCod ;
      private string[] T004217_A315PoConcDCueCod ;
      private string[] T00424_A1647PoConcDCueDsc ;
      private string[] T004218_A1647PoConcDCueDsc ;
      private int[] T004219_A313PoConcCod ;
      private string[] T004219_A315PoConcDCueCod ;
      private int[] T00423_A313PoConcCod ;
      private string[] T00423_A316PoConcCosCod ;
      private string[] T00423_A315PoConcDCueCod ;
      private int[] T00422_A313PoConcCod ;
      private string[] T00422_A316PoConcCosCod ;
      private string[] T00422_A315PoConcDCueCod ;
      private string[] T004223_A1647PoConcDCueDsc ;
      private int[] T004224_A313PoConcCod ;
      private string[] T004224_A315PoConcDCueCod ;
      private int[] T004225_A314PoConcLinCod ;
      private bool[] T004225_n314PoConcLinCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poconceptos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poconceptos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00428;
        prmT00428 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT00427;
        prmT00427 = new Object[] {
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00429;
        prmT00429 = new Object[] {
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT004210;
        prmT004210 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT00426;
        prmT00426 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004211;
        prmT004211 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004212;
        prmT004212 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT00425;
        prmT00425 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004213;
        prmT004213 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDsc",GXType.NChar,100,0) ,
        new ParDef("@PoConcTip",GXType.NChar,1,0) ,
        new ParDef("@PoConcSts",GXType.Int16,1,0) ,
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT004214;
        prmT004214 = new Object[] {
        new ParDef("@PoConcDsc",GXType.NChar,100,0) ,
        new ParDef("@PoConcTip",GXType.NChar,1,0) ,
        new ParDef("@PoConcSts",GXType.Int16,1,0) ,
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004215;
        prmT004215 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004216;
        prmT004216 = new Object[] {
        };
        Object[] prmT004217;
        prmT004217 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00424;
        prmT00424 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004218;
        prmT004218 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004219;
        prmT004219 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00423;
        prmT00423 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00422;
        prmT00422 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004220;
        prmT004220 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcCosCod",GXType.NChar,10,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004221;
        prmT004221 = new Object[] {
        new ParDef("@PoConcCosCod",GXType.NChar,10,0) ,
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004222;
        prmT004222 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0) ,
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004224;
        prmT004224 = new Object[] {
        new ParDef("@PoConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004225;
        prmT004225 = new Object[] {
        new ParDef("@PoConcLinCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT004223;
        prmT004223 = new Object[] {
        new ParDef("@PoConcDCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00422", "SELECT [PoConcCod], [PoConcCosCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WITH (UPDLOCK) WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00422,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00423", "SELECT [PoConcCod], [PoConcCosCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00423,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00424", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00424,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00425", "SELECT [PoConcCod], [PoConcDsc], [PoConcTip], [PoConcSts], [PoConcLinCod] AS PoConcLinCod FROM [POCONCEPTOS] WITH (UPDLOCK) WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00425,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00426", "SELECT [PoConcCod], [PoConcDsc], [PoConcTip], [PoConcSts], [PoConcLinCod] AS PoConcLinCod FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00426,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00427", "SELECT [LinCod] AS PoConcLinCod FROM [CLINEAPROD] WHERE [LinCod] = @PoConcLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00427,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00428", "SELECT TM1.[PoConcCod], TM1.[PoConcDsc], TM1.[PoConcTip], TM1.[PoConcSts], TM1.[PoConcLinCod] AS PoConcLinCod FROM [POCONCEPTOS] TM1 WHERE TM1.[PoConcCod] = @PoConcCod ORDER BY TM1.[PoConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00428,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00429", "SELECT [LinCod] AS PoConcLinCod FROM [CLINEAPROD] WHERE [LinCod] = @PoConcLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00429,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004210", "SELECT [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcCod] = @PoConcCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004210,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004211", "SELECT TOP 1 [PoConcCod] FROM [POCONCEPTOS] WHERE ( [PoConcCod] > @PoConcCod) ORDER BY [PoConcCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004211,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004212", "SELECT TOP 1 [PoConcCod] FROM [POCONCEPTOS] WHERE ( [PoConcCod] < @PoConcCod) ORDER BY [PoConcCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004212,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004213", "INSERT INTO [POCONCEPTOS]([PoConcCod], [PoConcDsc], [PoConcTip], [PoConcSts], [PoConcLinCod]) VALUES(@PoConcCod, @PoConcDsc, @PoConcTip, @PoConcSts, @PoConcLinCod)", GxErrorMask.GX_NOMASK,prmT004213)
           ,new CursorDef("T004214", "UPDATE [POCONCEPTOS] SET [PoConcDsc]=@PoConcDsc, [PoConcTip]=@PoConcTip, [PoConcSts]=@PoConcSts, [PoConcLinCod]=@PoConcLinCod  WHERE [PoConcCod] = @PoConcCod", GxErrorMask.GX_NOMASK,prmT004214)
           ,new CursorDef("T004215", "DELETE FROM [POCONCEPTOS]  WHERE [PoConcCod] = @PoConcCod", GxErrorMask.GX_NOMASK,prmT004215)
           ,new CursorDef("T004216", "SELECT [PoConcCod] FROM [POCONCEPTOS] ORDER BY [PoConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004216,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004217", "SELECT T1.[PoConcCod], T2.[CueDsc] AS PoConcDCueDsc, T1.[PoConcCosCod], T1.[PoConcDCueCod] AS PoConcDCueCod FROM ([POCONCEPTOSDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[PoConcDCueCod]) WHERE T1.[PoConcCod] = @PoConcCod and T1.[PoConcDCueCod] = @PoConcDCueCod ORDER BY T1.[PoConcCod], T1.[PoConcDCueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT004217,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004218", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004218,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004219", "SELECT [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004219,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004220", "INSERT INTO [POCONCEPTOSDET]([PoConcCod], [PoConcCosCod], [PoConcDCueCod]) VALUES(@PoConcCod, @PoConcCosCod, @PoConcDCueCod)", GxErrorMask.GX_NOMASK,prmT004220)
           ,new CursorDef("T004221", "UPDATE [POCONCEPTOSDET] SET [PoConcCosCod]=@PoConcCosCod  WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod", GxErrorMask.GX_NOMASK,prmT004221)
           ,new CursorDef("T004222", "DELETE FROM [POCONCEPTOSDET]  WHERE [PoConcCod] = @PoConcCod AND [PoConcDCueCod] = @PoConcDCueCod", GxErrorMask.GX_NOMASK,prmT004222)
           ,new CursorDef("T004223", "SELECT [CueDsc] AS PoConcDCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PoConcDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004223,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004224", "SELECT [PoConcCod], [PoConcDCueCod] AS PoConcDCueCod FROM [POCONCEPTOSDET] WHERE [PoConcCod] = @PoConcCod ORDER BY [PoConcCod], [PoConcDCueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT004224,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004225", "SELECT [LinCod] AS PoConcLinCod FROM [CLINEAPROD] WHERE [LinCod] = @PoConcLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004225,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
