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
   public class cbpresupuestorubroscuenta : GXDataArea
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
            A2280CBTipPre = (int)(NumberUtil.Val( GetPar( "CBTipPre"), "."));
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = GetPar( "CBTipTipo");
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = (int)(NumberUtil.Val( GetPar( "CBLinPre"), "."));
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A91CueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A79COSCod = GetPar( "COSCod");
            n79COSCod = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A79COSCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdet") == 0 )
         {
            nRC_GXsfl_64 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."));
            nGXsfl_64_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."));
            sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_newrow( ) ;
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
            Form.Meta.addItem("description", "Presupuesto Rubros Cuenta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbpresupuestorubroscuenta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbpresupuestorubroscuenta( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Presupuesto Rubros Cuenta", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBTipPre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBTipPre_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBTipPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2280CBTipPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBTipPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBTipTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBTipTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBTipTipo_Internalname, A2281CBTipTipo, StringUtil.RTrim( context.localUtil.Format( A2281CBTipTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBLinPre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBLinPre_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBLinPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2282CBLinPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBLinPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2282CBLinPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2282CBLinPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBLinPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBLinPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBRubPre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBRubPre_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBRubPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2283CBRubPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBRubPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2283CBRubPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2283CBRubPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBRubPreDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBRubPreDsc_Internalname, "de Presupuestos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBRubPreDsc_Internalname, A2293CBRubPreDsc, StringUtil.RTrim( context.localUtil.Format( A2293CBRubPreDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubPreDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubPreDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBRubPreSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBRubPreSts_Internalname, "Pre Sts", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBRubPreSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2294CBRubPreSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBRubPreSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2294CBRubPreSts), "9") : context.localUtil.Format( (decimal)(A2294CBRubPreSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubPreSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubPreSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBRubTItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBRubTItem_Internalname, "Items", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBRubTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2295CBRubTItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBRubTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A2295CBRubTItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2295CBRubTItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubTItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlecbpresupuestorubrosdet_Internalname, "CBPRESUPUESTORUBROSDET", "", "", lblTitlecbpresupuestorubrosdet_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdet( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROSCUENTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdet( )
      {
         /*  Grid Control  */
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("GridName", "Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdet");
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Header", subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Header);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Class", "Grid");
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle), 1, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("CmpContext", "");
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("InMasterPage", "false");
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2284CBRubDItem), 6, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubDItem_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.RTrim( A91CueCod));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.RTrim( A79COSCod));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSCod_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.RTrim( A860CueDsc));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.RTrim( A761COSDsc));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSDsc_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Selectedindex), 4, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowselection), 1, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Selectioncolor), 9, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowhovering), 1, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Hoveringcolor), 9, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowcollapsing), 1, 0, ".", "")));
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Collapsed), 1, 0, ".", "")));
         nGXsfl_64_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount207 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_207 = 1;
               ScanStart7I207( ) ;
               while ( RcdFound207 != 0 )
               {
                  init_level_properties207( ) ;
                  getByPrimaryKey7I207( ) ;
                  AddRow7I207( ) ;
                  ScanNext7I207( ) ;
               }
               ScanEnd7I207( ) ;
               nBlankRcdCount207 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal7I207( ) ;
            standaloneModal7I207( ) ;
            sMode207 = Gx_mode;
            while ( nGXsfl_64_idx < nRC_GXsfl_64 )
            {
               bGXsfl_64_Refreshing = true;
               ReadRow7I207( ) ;
               edtCBRubDItem_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBDITEM_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubDItem_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUECOD_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCOSCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "COSCOD_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUEDSC_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCOSDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "COSDSC_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCOSDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSDsc_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               if ( ( nRcdExists_207 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal7I207( ) ;
               }
               SendRow7I207( ) ;
               bGXsfl_64_Refreshing = false;
            }
            Gx_mode = sMode207;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount207 = 5;
            nRcdExists_207 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart7I207( ) ;
               while ( RcdFound207 != 0 )
               {
                  sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_64207( ) ;
                  init_level_properties207( ) ;
                  standaloneNotModal7I207( ) ;
                  getByPrimaryKey7I207( ) ;
                  standaloneModal7I207( ) ;
                  AddRow7I207( ) ;
                  ScanNext7I207( ) ;
               }
               ScanEnd7I207( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode207 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
         SubsflControlProps_64207( ) ;
         InitAll7I207( ) ;
         init_level_properties207( ) ;
         nRcdExists_207 = 0;
         nIsMod_207 = 0;
         nRcdDeleted_207 = 0;
         nBlankRcdCount207 = (short)(nBlankRcdUsr207+nBlankRcdCount207);
         fRowAdded = 0;
         while ( nBlankRcdCount207 > 0 )
         {
            standaloneNotModal7I207( ) ;
            standaloneModal7I207( ) ;
            AddRow7I207( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtCBRubDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount207 = (short)(nBlankRcdCount207-1);
         }
         Gx_mode = sMode207;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdet", Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainerData", Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainerData"+"V", Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainerData"+"V"+"\" value='"+Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.GridValuesHidden()+"'/>") ;
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
            Z2280CBTipPre = (int)(context.localUtil.CToN( cgiGet( "Z2280CBTipPre"), ".", ","));
            Z2281CBTipTipo = cgiGet( "Z2281CBTipTipo");
            Z2282CBLinPre = (int)(context.localUtil.CToN( cgiGet( "Z2282CBLinPre"), ".", ","));
            Z2283CBRubPre = (int)(context.localUtil.CToN( cgiGet( "Z2283CBRubPre"), ".", ","));
            Z2293CBRubPreDsc = cgiGet( "Z2293CBRubPreDsc");
            Z2294CBRubPreSts = (short)(context.localUtil.CToN( cgiGet( "Z2294CBRubPreSts"), ".", ","));
            Z2295CBRubTItem = (int)(context.localUtil.CToN( cgiGet( "Z2295CBRubTItem"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_64 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBTipPre_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBTipPre_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBTIPPRE");
               AnyError = 1;
               GX_FocusControl = edtCBTipPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2280CBTipPre = 0;
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            }
            else
            {
               A2280CBTipPre = (int)(context.localUtil.CToN( cgiGet( edtCBTipPre_Internalname), ".", ","));
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            }
            A2281CBTipTipo = cgiGet( edtCBTipTipo_Internalname);
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBLinPre_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBLinPre_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBLINPRE");
               AnyError = 1;
               GX_FocusControl = edtCBLinPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2282CBLinPre = 0;
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            }
            else
            {
               A2282CBLinPre = (int)(context.localUtil.CToN( cgiGet( edtCBLinPre_Internalname), ".", ","));
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPre_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPre_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBRUBPRE");
               AnyError = 1;
               GX_FocusControl = edtCBRubPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2283CBRubPre = 0;
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
            }
            else
            {
               A2283CBRubPre = (int)(context.localUtil.CToN( cgiGet( edtCBRubPre_Internalname), ".", ","));
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
            }
            A2293CBRubPreDsc = cgiGet( edtCBRubPreDsc_Internalname);
            AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBRUBPRESTS");
               AnyError = 1;
               GX_FocusControl = edtCBRubPreSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2294CBRubPreSts = 0;
               AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
            }
            else
            {
               A2294CBRubPreSts = (short)(context.localUtil.CToN( cgiGet( edtCBRubPreSts_Internalname), ".", ","));
               AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubTItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBRUBTITEM");
               AnyError = 1;
               GX_FocusControl = edtCBRubTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2295CBRubTItem = 0;
               AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
            }
            else
            {
               A2295CBRubTItem = (int)(context.localUtil.CToN( cgiGet( edtCBRubTItem_Internalname), ".", ","));
               AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
            }
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
               A2280CBTipPre = (int)(NumberUtil.Val( GetPar( "CBTipPre"), "."));
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = GetPar( "CBTipTipo");
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = (int)(NumberUtil.Val( GetPar( "CBLinPre"), "."));
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               A2283CBRubPre = (int)(NumberUtil.Val( GetPar( "CBRubPre"), "."));
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
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
               InitAll7I205( ) ;
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
         DisableAttributes7I205( ) ;
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

      protected void CONFIRM_7I207( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow7I207( ) ;
            if ( ( nRcdExists_207 != 0 ) || ( nIsMod_207 != 0 ) )
            {
               GetKey7I207( ) ;
               if ( ( nRcdExists_207 == 0 ) && ( nRcdDeleted_207 == 0 ) )
               {
                  if ( RcdFound207 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate7I207( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7I207( ) ;
                        CloseExtendedTableCursors7I207( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CBRUBDITEM_" + sGXsfl_64_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCBRubDItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound207 != 0 )
                  {
                     if ( nRcdDeleted_207 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey7I207( ) ;
                        Load7I207( ) ;
                        BeforeValidate7I207( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7I207( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_207 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate7I207( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7I207( ) ;
                              CloseExtendedTableCursors7I207( ) ;
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
                     if ( nRcdDeleted_207 == 0 )
                     {
                        GXCCtl = "CBRUBDITEM_" + sGXsfl_64_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCBRubDItem_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCBRubDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2284CBRubDItem), 6, 0, ".", ""))) ;
            ChangePostValue( edtCueCod_Internalname, StringUtil.RTrim( A91CueCod)) ;
            ChangePostValue( edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod)) ;
            ChangePostValue( edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc)) ;
            ChangePostValue( edtCOSDsc_Internalname, StringUtil.RTrim( A761COSDsc)) ;
            ChangePostValue( "ZT_"+"Z2284CBRubDItem_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2284CBRubDItem), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z91CueCod_"+sGXsfl_64_idx, StringUtil.RTrim( Z91CueCod)) ;
            ChangePostValue( "ZT_"+"Z79COSCod_"+sGXsfl_64_idx, StringUtil.RTrim( Z79COSCod)) ;
            ChangePostValue( "nRcdDeleted_207_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_207), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_207_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_207), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_207_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_207), 4, 0, ".", ""))) ;
            if ( nIsMod_207 != 0 )
            {
               ChangePostValue( "CBRUBDITEM_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubDItem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUECOD_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COSCOD_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUEDSC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COSDSC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption7I0( )
      {
      }

      protected void ZM7I205( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2293CBRubPreDsc = T007I7_A2293CBRubPreDsc[0];
               Z2294CBRubPreSts = T007I7_A2294CBRubPreSts[0];
               Z2295CBRubTItem = T007I7_A2295CBRubTItem[0];
            }
            else
            {
               Z2293CBRubPreDsc = A2293CBRubPreDsc;
               Z2294CBRubPreSts = A2294CBRubPreSts;
               Z2295CBRubTItem = A2295CBRubTItem;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2283CBRubPre = A2283CBRubPre;
            Z2293CBRubPreDsc = A2293CBRubPreDsc;
            Z2294CBRubPreSts = A2294CBRubPreSts;
            Z2295CBRubTItem = A2295CBRubTItem;
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
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

      protected void Load7I205( )
      {
         /* Using cursor T007I9 */
         pr_default.execute(7, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound205 = 1;
            A2293CBRubPreDsc = T007I9_A2293CBRubPreDsc[0];
            AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
            A2294CBRubPreSts = T007I9_A2294CBRubPreSts[0];
            AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
            A2295CBRubTItem = T007I9_A2295CBRubTItem[0];
            AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
            ZM7I205( -1) ;
         }
         pr_default.close(7);
         OnLoadActions7I205( ) ;
      }

      protected void OnLoadActions7I205( )
      {
      }

      protected void CheckExtendedTable7I205( )
      {
         nIsDirty_205 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007I8 */
         pr_default.execute(6, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors7I205( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A2280CBTipPre ,
                               string A2281CBTipTipo ,
                               int A2282CBLinPre )
      {
         /* Using cursor T007I10 */
         pr_default.execute(8, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey7I205( )
      {
         /* Using cursor T007I11 */
         pr_default.execute(9, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound205 = 1;
         }
         else
         {
            RcdFound205 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007I7 */
         pr_default.execute(5, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM7I205( 1) ;
            RcdFound205 = 1;
            A2283CBRubPre = T007I7_A2283CBRubPre[0];
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
            A2293CBRubPreDsc = T007I7_A2293CBRubPreDsc[0];
            AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
            A2294CBRubPreSts = T007I7_A2294CBRubPreSts[0];
            AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
            A2295CBRubTItem = T007I7_A2295CBRubTItem[0];
            AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
            A2280CBTipPre = T007I7_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007I7_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007I7_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2283CBRubPre = A2283CBRubPre;
            sMode205 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7I205( ) ;
            if ( AnyError == 1 )
            {
               RcdFound205 = 0;
               InitializeNonKey7I205( ) ;
            }
            Gx_mode = sMode205;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound205 = 0;
            InitializeNonKey7I205( ) ;
            sMode205 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode205;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey7I205( ) ;
         if ( RcdFound205 == 0 )
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
         RcdFound205 = 0;
         /* Using cursor T007I12 */
         pr_default.execute(10, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T007I12_A2280CBTipPre[0] < A2280CBTipPre ) || ( T007I12_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007I12_A2281CBTipTipo[0], A2281CBTipTipo) < 0 ) || ( StringUtil.StrCmp(T007I12_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I12_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I12_A2282CBLinPre[0] < A2282CBLinPre ) || ( T007I12_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007I12_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I12_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I12_A2283CBRubPre[0] < A2283CBRubPre ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T007I12_A2280CBTipPre[0] > A2280CBTipPre ) || ( T007I12_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007I12_A2281CBTipTipo[0], A2281CBTipTipo) > 0 ) || ( StringUtil.StrCmp(T007I12_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I12_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I12_A2282CBLinPre[0] > A2282CBLinPre ) || ( T007I12_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007I12_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I12_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I12_A2283CBRubPre[0] > A2283CBRubPre ) ) )
            {
               A2280CBTipPre = T007I12_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = T007I12_A2281CBTipTipo[0];
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = T007I12_A2282CBLinPre[0];
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               A2283CBRubPre = T007I12_A2283CBRubPre[0];
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
               RcdFound205 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound205 = 0;
         /* Using cursor T007I13 */
         pr_default.execute(11, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T007I13_A2280CBTipPre[0] > A2280CBTipPre ) || ( T007I13_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007I13_A2281CBTipTipo[0], A2281CBTipTipo) > 0 ) || ( StringUtil.StrCmp(T007I13_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I13_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I13_A2282CBLinPre[0] > A2282CBLinPre ) || ( T007I13_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007I13_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I13_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I13_A2283CBRubPre[0] > A2283CBRubPre ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T007I13_A2280CBTipPre[0] < A2280CBTipPre ) || ( T007I13_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007I13_A2281CBTipTipo[0], A2281CBTipTipo) < 0 ) || ( StringUtil.StrCmp(T007I13_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I13_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I13_A2282CBLinPre[0] < A2282CBLinPre ) || ( T007I13_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007I13_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007I13_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007I13_A2283CBRubPre[0] < A2283CBRubPre ) ) )
            {
               A2280CBTipPre = T007I13_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = T007I13_A2281CBTipTipo[0];
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = T007I13_A2282CBLinPre[0];
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               A2283CBRubPre = T007I13_A2283CBRubPre[0];
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
               RcdFound205 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7I205( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7I205( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound205 == 1 )
            {
               if ( ( A2280CBTipPre != Z2280CBTipPre ) || ( StringUtil.StrCmp(A2281CBTipTipo, Z2281CBTipTipo) != 0 ) || ( A2282CBLinPre != Z2282CBLinPre ) || ( A2283CBRubPre != Z2283CBRubPre ) )
               {
                  A2280CBTipPre = Z2280CBTipPre;
                  AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
                  A2281CBTipTipo = Z2281CBTipTipo;
                  AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
                  A2282CBLinPre = Z2282CBLinPre;
                  AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
                  A2283CBRubPre = Z2283CBRubPre;
                  AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CBTIPPRE");
                  AnyError = 1;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7I205( ) ;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2280CBTipPre != Z2280CBTipPre ) || ( StringUtil.StrCmp(A2281CBTipTipo, Z2281CBTipTipo) != 0 ) || ( A2282CBLinPre != Z2282CBLinPre ) || ( A2283CBRubPre != Z2283CBRubPre ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7I205( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CBTIPPRE");
                     AnyError = 1;
                     GX_FocusControl = edtCBTipPre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCBTipPre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7I205( ) ;
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
         if ( ( A2280CBTipPre != Z2280CBTipPre ) || ( StringUtil.StrCmp(A2281CBTipTipo, Z2281CBTipTipo) != 0 ) || ( A2282CBLinPre != Z2282CBLinPre ) || ( A2283CBRubPre != Z2283CBRubPre ) )
         {
            A2280CBTipPre = Z2280CBTipPre;
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = Z2281CBTipTipo;
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = Z2282CBLinPre;
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            A2283CBRubPre = Z2283CBRubPre;
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCBTipPre_Internalname;
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
         if ( RcdFound205 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBRubPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7I205( ) ;
         if ( RcdFound205 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBRubPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7I205( ) ;
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
         if ( RcdFound205 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBRubPreDsc_Internalname;
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
         if ( RcdFound205 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBRubPreDsc_Internalname;
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
         ScanStart7I205( ) ;
         if ( RcdFound205 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound205 != 0 )
            {
               ScanNext7I205( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBRubPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7I205( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7I205( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007I6 */
            pr_default.execute(4, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z2293CBRubPreDsc, T007I6_A2293CBRubPreDsc[0]) != 0 ) || ( Z2294CBRubPreSts != T007I6_A2294CBRubPreSts[0] ) || ( Z2295CBRubTItem != T007I6_A2295CBRubTItem[0] ) )
            {
               if ( StringUtil.StrCmp(Z2293CBRubPreDsc, T007I6_A2293CBRubPreDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbpresupuestorubroscuenta:[seudo value changed for attri]"+"CBRubPreDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2293CBRubPreDsc);
                  GXUtil.WriteLogRaw("Current: ",T007I6_A2293CBRubPreDsc[0]);
               }
               if ( Z2294CBRubPreSts != T007I6_A2294CBRubPreSts[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubroscuenta:[seudo value changed for attri]"+"CBRubPreSts");
                  GXUtil.WriteLogRaw("Old: ",Z2294CBRubPreSts);
                  GXUtil.WriteLogRaw("Current: ",T007I6_A2294CBRubPreSts[0]);
               }
               if ( Z2295CBRubTItem != T007I6_A2295CBRubTItem[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubroscuenta:[seudo value changed for attri]"+"CBRubTItem");
                  GXUtil.WriteLogRaw("Old: ",Z2295CBRubTItem);
                  GXUtil.WriteLogRaw("Current: ",T007I6_A2295CBRubTItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPRESUPUESTORUBROS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7I205( )
      {
         BeforeValidate7I205( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7I205( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7I205( 0) ;
            CheckOptimisticConcurrency7I205( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7I205( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7I205( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007I14 */
                     pr_default.execute(12, new Object[] {A2283CBRubPre, A2293CBRubPreDsc, A2294CBRubPreSts, A2295CBRubTItem, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROS");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ProcessLevel7I205( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption7I0( ) ;
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
               Load7I205( ) ;
            }
            EndLevel7I205( ) ;
         }
         CloseExtendedTableCursors7I205( ) ;
      }

      protected void Update7I205( )
      {
         BeforeValidate7I205( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7I205( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7I205( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7I205( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7I205( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007I15 */
                     pr_default.execute(13, new Object[] {A2293CBRubPreDsc, A2294CBRubPreSts, A2295CBRubTItem, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7I205( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel7I205( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption7I0( ) ;
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
            EndLevel7I205( ) ;
         }
         CloseExtendedTableCursors7I205( ) ;
      }

      protected void DeferredUpdate7I205( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7I205( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7I205( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7I205( ) ;
            AfterConfirm7I205( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7I205( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart7I207( ) ;
                  while ( RcdFound207 != 0 )
                  {
                     getByPrimaryKey7I207( ) ;
                     Delete7I207( ) ;
                     ScanNext7I207( ) ;
                  }
                  ScanEnd7I207( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007I16 */
                     pr_default.execute(14, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound205 == 0 )
                           {
                              InitAll7I205( ) ;
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
                           ResetCaption7I0( ) ;
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
         sMode205 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7I205( ) ;
         Gx_mode = sMode205;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7I205( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007I17 */
            pr_default.execute(15, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel7I207( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow7I207( ) ;
            if ( ( nRcdExists_207 != 0 ) || ( nIsMod_207 != 0 ) )
            {
               standaloneNotModal7I207( ) ;
               GetKey7I207( ) ;
               if ( ( nRcdExists_207 == 0 ) && ( nRcdDeleted_207 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert7I207( ) ;
               }
               else
               {
                  if ( RcdFound207 != 0 )
                  {
                     if ( ( nRcdDeleted_207 != 0 ) && ( nRcdExists_207 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete7I207( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_207 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update7I207( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_207 == 0 )
                     {
                        GXCCtl = "CBRUBDITEM_" + sGXsfl_64_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCBRubDItem_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCBRubDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2284CBRubDItem), 6, 0, ".", ""))) ;
            ChangePostValue( edtCueCod_Internalname, StringUtil.RTrim( A91CueCod)) ;
            ChangePostValue( edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod)) ;
            ChangePostValue( edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc)) ;
            ChangePostValue( edtCOSDsc_Internalname, StringUtil.RTrim( A761COSDsc)) ;
            ChangePostValue( "ZT_"+"Z2284CBRubDItem_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2284CBRubDItem), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z91CueCod_"+sGXsfl_64_idx, StringUtil.RTrim( Z91CueCod)) ;
            ChangePostValue( "ZT_"+"Z79COSCod_"+sGXsfl_64_idx, StringUtil.RTrim( Z79COSCod)) ;
            ChangePostValue( "nRcdDeleted_207_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_207), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_207_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_207), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_207_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_207), 4, 0, ".", ""))) ;
            if ( nIsMod_207 != 0 )
            {
               ChangePostValue( "CBRUBDITEM_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubDItem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUECOD_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COSCOD_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUEDSC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COSDSC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7I207( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_207 = 0;
         nIsMod_207 = 0;
         nRcdDeleted_207 = 0;
      }

      protected void ProcessLevel7I205( )
      {
         /* Save parent mode. */
         sMode205 = Gx_mode;
         ProcessNestedLevel7I207( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode205;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel7I205( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7I205( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("cbpresupuestorubroscuenta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("cbpresupuestorubroscuenta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7I205( )
      {
         /* Using cursor T007I18 */
         pr_default.execute(16);
         RcdFound205 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound205 = 1;
            A2280CBTipPre = T007I18_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007I18_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007I18_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            A2283CBRubPre = T007I18_A2283CBRubPre[0];
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7I205( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound205 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound205 = 1;
            A2280CBTipPre = T007I18_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007I18_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007I18_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            A2283CBRubPre = T007I18_A2283CBRubPre[0];
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
         }
      }

      protected void ScanEnd7I205( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm7I205( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7I205( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7I205( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7I205( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7I205( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7I205( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7I205( )
      {
         edtCBTipPre_Enabled = 0;
         AssignProp("", false, edtCBTipPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipPre_Enabled), 5, 0), true);
         edtCBTipTipo_Enabled = 0;
         AssignProp("", false, edtCBTipTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipTipo_Enabled), 5, 0), true);
         edtCBLinPre_Enabled = 0;
         AssignProp("", false, edtCBLinPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBLinPre_Enabled), 5, 0), true);
         edtCBRubPre_Enabled = 0;
         AssignProp("", false, edtCBRubPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPre_Enabled), 5, 0), true);
         edtCBRubPreDsc_Enabled = 0;
         AssignProp("", false, edtCBRubPreDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreDsc_Enabled), 5, 0), true);
         edtCBRubPreSts_Enabled = 0;
         AssignProp("", false, edtCBRubPreSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreSts_Enabled), 5, 0), true);
         edtCBRubTItem_Enabled = 0;
         AssignProp("", false, edtCBRubTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubTItem_Enabled), 5, 0), true);
      }

      protected void ZM7I207( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z91CueCod = T007I3_A91CueCod[0];
               Z79COSCod = T007I3_A79COSCod[0];
            }
            else
            {
               Z91CueCod = A91CueCod;
               Z79COSCod = A79COSCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2283CBRubPre = A2283CBRubPre;
            Z2284CBRubDItem = A2284CBRubDItem;
            Z91CueCod = A91CueCod;
            Z79COSCod = A79COSCod;
            Z860CueDsc = A860CueDsc;
            Z761COSDsc = A761COSDsc;
         }
      }

      protected void standaloneNotModal7I207( )
      {
      }

      protected void standaloneModal7I207( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCBRubDItem_Enabled = 0;
            AssignProp("", false, edtCBRubDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubDItem_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         }
         else
         {
            edtCBRubDItem_Enabled = 1;
            AssignProp("", false, edtCBRubDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubDItem_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         }
      }

      protected void Load7I207( )
      {
         /* Using cursor T007I19 */
         pr_default.execute(17, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound207 = 1;
            A860CueDsc = T007I19_A860CueDsc[0];
            A761COSDsc = T007I19_A761COSDsc[0];
            A91CueCod = T007I19_A91CueCod[0];
            A79COSCod = T007I19_A79COSCod[0];
            n79COSCod = T007I19_n79COSCod[0];
            ZM7I207( -3) ;
         }
         pr_default.close(17);
         OnLoadActions7I207( ) ;
      }

      protected void OnLoadActions7I207( )
      {
      }

      protected void CheckExtendedTable7I207( )
      {
         nIsDirty_207 = 0;
         Gx_BScreen = 1;
         standaloneModal7I207( ) ;
         /* Using cursor T007I4 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "CUECOD_" + sGXsfl_64_idx;
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T007I4_A860CueDsc[0];
         pr_default.close(2);
         /* Using cursor T007I5 */
         pr_default.execute(3, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) ) )
            {
               GXCCtl = "COSCOD_" + sGXsfl_64_idx;
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A761COSDsc = T007I5_A761COSDsc[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors7I207( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable7I207( )
      {
      }

      protected void gxLoad_4( string A91CueCod )
      {
         /* Using cursor T007I20 */
         pr_default.execute(18, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "CUECOD_" + sGXsfl_64_idx;
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T007I20_A860CueDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A860CueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_5( string A79COSCod )
      {
         /* Using cursor T007I21 */
         pr_default.execute(19, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) ) )
            {
               GXCCtl = "COSCOD_" + sGXsfl_64_idx;
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A761COSDsc = T007I21_A761COSDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A761COSDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void GetKey7I207( )
      {
         /* Using cursor T007I22 */
         pr_default.execute(20, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound207 = 1;
         }
         else
         {
            RcdFound207 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey7I207( )
      {
         /* Using cursor T007I3 */
         pr_default.execute(1, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7I207( 3) ;
            RcdFound207 = 1;
            InitializeNonKey7I207( ) ;
            A2284CBRubDItem = T007I3_A2284CBRubDItem[0];
            A91CueCod = T007I3_A91CueCod[0];
            A79COSCod = T007I3_A79COSCod[0];
            n79COSCod = T007I3_n79COSCod[0];
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2283CBRubPre = A2283CBRubPre;
            Z2284CBRubDItem = A2284CBRubDItem;
            sMode207 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7I207( ) ;
            Load7I207( ) ;
            Gx_mode = sMode207;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound207 = 0;
            InitializeNonKey7I207( ) ;
            sMode207 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7I207( ) ;
            Gx_mode = sMode207;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7I207( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency7I207( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007I2 */
            pr_default.execute(0, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROSCUENTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z91CueCod, T007I2_A91CueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z79COSCod, T007I2_A79COSCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z91CueCod, T007I2_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbpresupuestorubroscuenta:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T007I2_A91CueCod[0]);
               }
               if ( StringUtil.StrCmp(Z79COSCod, T007I2_A79COSCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbpresupuestorubroscuenta:[seudo value changed for attri]"+"COSCod");
                  GXUtil.WriteLogRaw("Old: ",Z79COSCod);
                  GXUtil.WriteLogRaw("Current: ",T007I2_A79COSCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPRESUPUESTORUBROSCUENTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7I207( )
      {
         BeforeValidate7I207( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7I207( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7I207( 0) ;
            CheckOptimisticConcurrency7I207( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7I207( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7I207( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007I23 */
                     pr_default.execute(21, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem, A91CueCod, n79COSCod, A79COSCod});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROSCUENTA");
                     if ( (pr_default.getStatus(21) == 1) )
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
               Load7I207( ) ;
            }
            EndLevel7I207( ) ;
         }
         CloseExtendedTableCursors7I207( ) ;
      }

      protected void Update7I207( )
      {
         BeforeValidate7I207( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7I207( ) ;
         }
         if ( ( nIsMod_207 != 0 ) || ( nIsDirty_207 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency7I207( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm7I207( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate7I207( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007I24 */
                        pr_default.execute(22, new Object[] {A91CueCod, n79COSCod, A79COSCod, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem});
                        pr_default.close(22);
                        dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROSCUENTA");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROSCUENTA"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate7I207( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey7I207( ) ;
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
               EndLevel7I207( ) ;
            }
         }
         CloseExtendedTableCursors7I207( ) ;
      }

      protected void DeferredUpdate7I207( )
      {
      }

      protected void Delete7I207( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7I207( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7I207( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7I207( ) ;
            AfterConfirm7I207( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7I207( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007I25 */
                  pr_default.execute(23, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2284CBRubDItem});
                  pr_default.close(23);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROSCUENTA");
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
         sMode207 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7I207( ) ;
         Gx_mode = sMode207;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7I207( )
      {
         standaloneModal7I207( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007I26 */
            pr_default.execute(24, new Object[] {A91CueCod});
            A860CueDsc = T007I26_A860CueDsc[0];
            pr_default.close(24);
            /* Using cursor T007I27 */
            pr_default.execute(25, new Object[] {n79COSCod, A79COSCod});
            A761COSDsc = T007I27_A761COSDsc[0];
            pr_default.close(25);
         }
      }

      protected void EndLevel7I207( )
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

      public void ScanStart7I207( )
      {
         /* Scan By routine */
         /* Using cursor T007I28 */
         pr_default.execute(26, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         RcdFound207 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound207 = 1;
            A2284CBRubDItem = T007I28_A2284CBRubDItem[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7I207( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound207 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound207 = 1;
            A2284CBRubDItem = T007I28_A2284CBRubDItem[0];
         }
      }

      protected void ScanEnd7I207( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm7I207( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7I207( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7I207( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7I207( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7I207( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7I207( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7I207( )
      {
         edtCBRubDItem_Enabled = 0;
         AssignProp("", false, edtCBRubDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubDItem_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCOSCod_Enabled = 0;
         AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCueDsc_Enabled = 0;
         AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCOSDsc_Enabled = 0;
         AssignProp("", false, edtCOSDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSDsc_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void send_integrity_lvl_hashes7I207( )
      {
      }

      protected void send_integrity_lvl_hashes7I205( )
      {
      }

      protected void SubsflControlProps_64207( )
      {
         edtCBRubDItem_Internalname = "CBRUBDITEM_"+sGXsfl_64_idx;
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_64_idx;
         edtCOSCod_Internalname = "COSCOD_"+sGXsfl_64_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_64_idx;
         edtCOSDsc_Internalname = "COSDSC_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_64207( )
      {
         edtCBRubDItem_Internalname = "CBRUBDITEM_"+sGXsfl_64_fel_idx;
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_64_fel_idx;
         edtCOSCod_Internalname = "COSCOD_"+sGXsfl_64_fel_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_64_fel_idx;
         edtCOSDsc_Internalname = "COSDSC_"+sGXsfl_64_fel_idx;
      }

      protected void AddRow7I207( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_64207( ) ;
         SendRow7I207( ) ;
      }

      protected void SendRow7I207( )
      {
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow = GXWebRow.GetNew(context);
         if ( subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class, "") != 0 )
            {
               subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class+"Odd";
            }
         }
         else if ( subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backstyle = 0;
            subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolor = subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class, "") != 0 )
            {
               subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class+"Uniform";
            }
         }
         else if ( subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class, "") != 0 )
            {
               subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class+"Odd";
            }
            subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolor = (int)(0x0);
         }
         else if ( subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backstyle = 1;
            if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
            {
               subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class, "") != 0 )
               {
                  subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class+"Even";
               }
            }
            else
            {
               subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class, "") != 0 )
               {
                  subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_207_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubDItem_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2284CBRubDItem), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2284CBRubDItem), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubDItem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubDItem_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_207_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueCod_Internalname,StringUtil.RTrim( A91CueCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCueCod_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_207_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSCod_Internalname,StringUtil.RTrim( A79COSCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCOSCod_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueDsc_Internalname,StringUtil.RTrim( A860CueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCueDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSDsc_Internalname,StringUtil.RTrim( A761COSDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCOSDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow);
         send_integrity_lvl_hashes7I207( ) ;
         GXCCtl = "Z2284CBRubDItem_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2284CBRubDItem), 6, 0, ".", "")));
         GXCCtl = "Z91CueCod_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z91CueCod));
         GXCCtl = "Z79COSCod_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z79COSCod));
         GXCCtl = "nRcdDeleted_207_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_207), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_207_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_207), 4, 0, ".", "")));
         GXCCtl = "nIsMod_207_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_207), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBDITEM_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubDItem_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUECOD_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COSCOD_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUEDSC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COSDSC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCOSDsc_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer.AddRow(Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow);
      }

      protected void ReadRow7I207( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_64207( ) ;
         edtCBRubDItem_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBDITEM_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUECOD_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCOSCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "COSCOD_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUEDSC_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCOSDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "COSDSC_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "CBRUBDITEM_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubDItem_Internalname;
            wbErr = true;
            A2284CBRubDItem = 0;
         }
         else
         {
            A2284CBRubDItem = (int)(context.localUtil.CToN( cgiGet( edtCBRubDItem_Internalname), ".", ","));
         }
         A91CueCod = cgiGet( edtCueCod_Internalname);
         A79COSCod = cgiGet( edtCOSCod_Internalname);
         n79COSCod = false;
         A860CueDsc = cgiGet( edtCueDsc_Internalname);
         A761COSDsc = cgiGet( edtCOSDsc_Internalname);
         GXCCtl = "Z2284CBRubDItem_" + sGXsfl_64_idx;
         Z2284CBRubDItem = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z91CueCod_" + sGXsfl_64_idx;
         Z91CueCod = cgiGet( GXCCtl);
         GXCCtl = "Z79COSCod_" + sGXsfl_64_idx;
         Z79COSCod = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_207_" + sGXsfl_64_idx;
         nRcdDeleted_207 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_207_" + sGXsfl_64_idx;
         nRcdExists_207 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_207_" + sGXsfl_64_idx;
         nIsMod_207 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtCBRubDItem_Enabled = edtCBRubDItem_Enabled;
      }

      protected void ConfirmValues7I0( )
      {
         nGXsfl_64_idx = 0;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_64207( ) ;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_64207( ) ;
            ChangePostValue( "Z2284CBRubDItem_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2284CBRubDItem_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2284CBRubDItem_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z91CueCod_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z91CueCod_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z91CueCod_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z79COSCod_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z79COSCod_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z79COSCod_"+sGXsfl_64_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271629", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbpresupuestorubroscuenta.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2280CBTipPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2280CBTipPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2281CBTipTipo", Z2281CBTipTipo);
         GxWebStd.gx_hidden_field( context, "Z2282CBLinPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2282CBLinPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2283CBRubPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2283CBRubPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2293CBRubPreDsc", Z2293CBRubPreDsc);
         GxWebStd.gx_hidden_field( context, "Z2294CBRubPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2294CBRubPreSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2295CBRubTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2295CBRubTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_64_idx), 8, 0, ".", "")));
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
         return formatLink("cbpresupuestorubroscuenta.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPRESUPUESTORUBROSCUENTA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Presupuesto Rubros Cuenta" ;
      }

      protected void InitializeNonKey7I205( )
      {
         A2293CBRubPreDsc = "";
         AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
         A2294CBRubPreSts = 0;
         AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
         A2295CBRubTItem = 0;
         AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
         Z2293CBRubPreDsc = "";
         Z2294CBRubPreSts = 0;
         Z2295CBRubTItem = 0;
      }

      protected void InitAll7I205( )
      {
         A2280CBTipPre = 0;
         AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
         A2281CBTipTipo = "";
         AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
         A2282CBLinPre = 0;
         AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
         A2283CBRubPre = 0;
         AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
         InitializeNonKey7I205( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey7I207( )
      {
         A91CueCod = "";
         A79COSCod = "";
         n79COSCod = false;
         A860CueDsc = "";
         A761COSDsc = "";
         Z91CueCod = "";
         Z79COSCod = "";
      }

      protected void InitAll7I207( )
      {
         A2284CBRubDItem = 0;
         InitializeNonKey7I207( ) ;
      }

      protected void StandaloneModalInsert7I207( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271637", true, true);
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
         context.AddJavascriptSource("cbpresupuestorubroscuenta.js", "?202281810271637", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties207( )
      {
         edtCBRubDItem_Enabled = defedtCBRubDItem_Enabled;
         AssignProp("", false, edtCBRubDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubDItem_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtCBTipPre_Internalname = "CBTIPPRE";
         edtCBTipTipo_Internalname = "CBTIPTIPO";
         edtCBLinPre_Internalname = "CBLINPRE";
         edtCBRubPre_Internalname = "CBRUBPRE";
         edtCBRubPreDsc_Internalname = "CBRUBPREDSC";
         edtCBRubPreSts_Internalname = "CBRUBPRESTS";
         edtCBRubTItem_Internalname = "CBRUBTITEM";
         lblTitlecbpresupuestorubrosdet_Internalname = "TITLECBPRESUPUESTORUBROSDET";
         edtCBRubDItem_Internalname = "CBRUBDITEM";
         edtCueCod_Internalname = "CUECOD";
         edtCOSCod_Internalname = "COSCOD";
         edtCueDsc_Internalname = "CUEDSC";
         edtCOSDsc_Internalname = "COSDSC";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Internalname = "GRIDCBPRESUPUESTORUBROSCUENTA_CBPRESUPUESTORUBROSDET";
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
         Form.Caption = "Presupuesto Rubros Cuenta";
         edtCOSDsc_Jsonclick = "";
         edtCueDsc_Jsonclick = "";
         edtCOSCod_Jsonclick = "";
         edtCueCod_Jsonclick = "";
         edtCBRubDItem_Jsonclick = "";
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class = "Grid";
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle = 0;
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowcollapsing = 0;
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowselection = 0;
         edtCOSDsc_Enabled = 0;
         edtCueDsc_Enabled = 0;
         edtCOSCod_Enabled = 1;
         edtCueCod_Enabled = 1;
         edtCBRubDItem_Enabled = 1;
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBRubTItem_Jsonclick = "";
         edtCBRubTItem_Enabled = 1;
         edtCBRubPreSts_Jsonclick = "";
         edtCBRubPreSts_Enabled = 1;
         edtCBRubPreDsc_Jsonclick = "";
         edtCBRubPreDsc_Enabled = 1;
         edtCBRubPre_Jsonclick = "";
         edtCBRubPre_Enabled = 1;
         edtCBLinPre_Jsonclick = "";
         edtCBLinPre_Enabled = 1;
         edtCBTipTipo_Jsonclick = "";
         edtCBTipTipo_Enabled = 1;
         edtCBTipPre_Jsonclick = "";
         edtCBTipPre_Enabled = 1;
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

      protected void gxnrGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_64207( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal7I207( ) ;
            standaloneModal7I207( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow7I207( ) ;
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_64207( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer)) ;
         /* End function gxnrGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_newrow */
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
         /* Using cursor T007I29 */
         pr_default.execute(27, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(27);
         GX_FocusControl = edtCBRubPreDsc_Internalname;
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

      public void Valid_Cblinpre( )
      {
         /* Using cursor T007I29 */
         pr_default.execute(27, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cbrubpre( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
         AssignAttri("", false, "A2294CBRubPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2294CBRubPreSts), 1, 0, ".", "")));
         AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2295CBRubTItem), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2280CBTipPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2280CBTipPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2281CBTipTipo", Z2281CBTipTipo);
         GxWebStd.gx_hidden_field( context, "Z2282CBLinPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2282CBLinPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2283CBRubPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2283CBRubPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2293CBRubPreDsc", Z2293CBRubPreDsc);
         GxWebStd.gx_hidden_field( context, "Z2294CBRubPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2294CBRubPreSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2295CBRubTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2295CBRubTItem), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T007I26 */
         pr_default.execute(24, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         A860CueDsc = T007I26_A860CueDsc[0];
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
      }

      public void Valid_Coscod( )
      {
         n79COSCod = false;
         /* Using cursor T007I27 */
         pr_default.execute(25, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
            }
         }
         A761COSDsc = T007I27_A761COSDsc[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A761COSDsc", StringUtil.RTrim( A761COSDsc));
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
         setEventMetadata("VALID_CBTIPPRE","{handler:'Valid_Cbtippre',iparms:[]");
         setEventMetadata("VALID_CBTIPPRE",",oparms:[]}");
         setEventMetadata("VALID_CBTIPTIPO","{handler:'Valid_Cbtiptipo',iparms:[]");
         setEventMetadata("VALID_CBTIPTIPO",",oparms:[]}");
         setEventMetadata("VALID_CBLINPRE","{handler:'Valid_Cblinpre',iparms:[{av:'A2280CBTipPre',fld:'CBTIPPRE',pic:'ZZZZZ9'},{av:'A2281CBTipTipo',fld:'CBTIPTIPO',pic:''},{av:'A2282CBLinPre',fld:'CBLINPRE',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CBLINPRE",",oparms:[]}");
         setEventMetadata("VALID_CBRUBPRE","{handler:'Valid_Cbrubpre',iparms:[{av:'A2280CBTipPre',fld:'CBTIPPRE',pic:'ZZZZZ9'},{av:'A2281CBTipTipo',fld:'CBTIPTIPO',pic:''},{av:'A2282CBLinPre',fld:'CBLINPRE',pic:'ZZZZZ9'},{av:'A2283CBRubPre',fld:'CBRUBPRE',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBRUBPRE",",oparms:[{av:'A2293CBRubPreDsc',fld:'CBRUBPREDSC',pic:''},{av:'A2294CBRubPreSts',fld:'CBRUBPRESTS',pic:'9'},{av:'A2295CBRubTItem',fld:'CBRUBTITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2280CBTipPre'},{av:'Z2281CBTipTipo'},{av:'Z2282CBLinPre'},{av:'Z2283CBRubPre'},{av:'Z2293CBRubPreDsc'},{av:'Z2294CBRubPreSts'},{av:'Z2295CBRubTItem'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CBRUBDITEM","{handler:'Valid_Cbrubditem',iparms:[]");
         setEventMetadata("VALID_CBRUBDITEM",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A860CueDsc',fld:'CUEDSC',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A860CueDsc',fld:'CUEDSC',pic:''}]}");
         setEventMetadata("VALID_COSCOD","{handler:'Valid_Coscod',iparms:[{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A761COSDsc',fld:'COSDSC',pic:''}]");
         setEventMetadata("VALID_COSCOD",",oparms:[{av:'A761COSDsc',fld:'COSDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Cosdsc',iparms:[]");
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
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(5);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2281CBTipTipo = "";
         Z2293CBRubPreDsc = "";
         Z91CueCod = "";
         Z79COSCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2281CBTipTipo = "";
         A91CueCod = "";
         A79COSCod = "";
         Gx_mode = "";
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
         A2293CBRubPreDsc = "";
         lblTitlecbpresupuestorubrosdet_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer = new GXWebGrid( context);
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn = new GXWebColumn();
         A860CueDsc = "";
         A761COSDsc = "";
         sMode207 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T007I9_A2283CBRubPre = new int[1] ;
         T007I9_A2293CBRubPreDsc = new string[] {""} ;
         T007I9_A2294CBRubPreSts = new short[1] ;
         T007I9_A2295CBRubTItem = new int[1] ;
         T007I9_A2280CBTipPre = new int[1] ;
         T007I9_A2281CBTipTipo = new string[] {""} ;
         T007I9_A2282CBLinPre = new int[1] ;
         T007I8_A2280CBTipPre = new int[1] ;
         T007I10_A2280CBTipPre = new int[1] ;
         T007I11_A2280CBTipPre = new int[1] ;
         T007I11_A2281CBTipTipo = new string[] {""} ;
         T007I11_A2282CBLinPre = new int[1] ;
         T007I11_A2283CBRubPre = new int[1] ;
         T007I7_A2283CBRubPre = new int[1] ;
         T007I7_A2293CBRubPreDsc = new string[] {""} ;
         T007I7_A2294CBRubPreSts = new short[1] ;
         T007I7_A2295CBRubTItem = new int[1] ;
         T007I7_A2280CBTipPre = new int[1] ;
         T007I7_A2281CBTipTipo = new string[] {""} ;
         T007I7_A2282CBLinPre = new int[1] ;
         sMode205 = "";
         T007I12_A2280CBTipPre = new int[1] ;
         T007I12_A2281CBTipTipo = new string[] {""} ;
         T007I12_A2282CBLinPre = new int[1] ;
         T007I12_A2283CBRubPre = new int[1] ;
         T007I13_A2280CBTipPre = new int[1] ;
         T007I13_A2281CBTipTipo = new string[] {""} ;
         T007I13_A2282CBLinPre = new int[1] ;
         T007I13_A2283CBRubPre = new int[1] ;
         T007I6_A2283CBRubPre = new int[1] ;
         T007I6_A2293CBRubPreDsc = new string[] {""} ;
         T007I6_A2294CBRubPreSts = new short[1] ;
         T007I6_A2295CBRubTItem = new int[1] ;
         T007I6_A2280CBTipPre = new int[1] ;
         T007I6_A2281CBTipTipo = new string[] {""} ;
         T007I6_A2282CBLinPre = new int[1] ;
         T007I17_A2280CBTipPre = new int[1] ;
         T007I17_A2281CBTipTipo = new string[] {""} ;
         T007I17_A2282CBLinPre = new int[1] ;
         T007I17_A2283CBRubPre = new int[1] ;
         T007I17_A2285CBRubPreAno = new short[1] ;
         T007I18_A2280CBTipPre = new int[1] ;
         T007I18_A2281CBTipTipo = new string[] {""} ;
         T007I18_A2282CBLinPre = new int[1] ;
         T007I18_A2283CBRubPre = new int[1] ;
         Z860CueDsc = "";
         Z761COSDsc = "";
         T007I19_A2280CBTipPre = new int[1] ;
         T007I19_A2281CBTipTipo = new string[] {""} ;
         T007I19_A2282CBLinPre = new int[1] ;
         T007I19_A2283CBRubPre = new int[1] ;
         T007I19_A2284CBRubDItem = new int[1] ;
         T007I19_A860CueDsc = new string[] {""} ;
         T007I19_A761COSDsc = new string[] {""} ;
         T007I19_A91CueCod = new string[] {""} ;
         T007I19_A79COSCod = new string[] {""} ;
         T007I19_n79COSCod = new bool[] {false} ;
         T007I4_A860CueDsc = new string[] {""} ;
         T007I5_A761COSDsc = new string[] {""} ;
         T007I20_A860CueDsc = new string[] {""} ;
         T007I21_A761COSDsc = new string[] {""} ;
         T007I22_A2280CBTipPre = new int[1] ;
         T007I22_A2281CBTipTipo = new string[] {""} ;
         T007I22_A2282CBLinPre = new int[1] ;
         T007I22_A2283CBRubPre = new int[1] ;
         T007I22_A2284CBRubDItem = new int[1] ;
         T007I3_A2280CBTipPre = new int[1] ;
         T007I3_A2281CBTipTipo = new string[] {""} ;
         T007I3_A2282CBLinPre = new int[1] ;
         T007I3_A2283CBRubPre = new int[1] ;
         T007I3_A2284CBRubDItem = new int[1] ;
         T007I3_A91CueCod = new string[] {""} ;
         T007I3_A79COSCod = new string[] {""} ;
         T007I3_n79COSCod = new bool[] {false} ;
         T007I2_A2280CBTipPre = new int[1] ;
         T007I2_A2281CBTipTipo = new string[] {""} ;
         T007I2_A2282CBLinPre = new int[1] ;
         T007I2_A2283CBRubPre = new int[1] ;
         T007I2_A2284CBRubDItem = new int[1] ;
         T007I2_A91CueCod = new string[] {""} ;
         T007I2_A79COSCod = new string[] {""} ;
         T007I2_n79COSCod = new bool[] {false} ;
         T007I26_A860CueDsc = new string[] {""} ;
         T007I27_A761COSDsc = new string[] {""} ;
         T007I28_A2280CBTipPre = new int[1] ;
         T007I28_A2281CBTipTipo = new string[] {""} ;
         T007I28_A2282CBLinPre = new int[1] ;
         T007I28_A2283CBRubPre = new int[1] ;
         T007I28_A2284CBRubDItem = new int[1] ;
         Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow = new GXWebRow();
         subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007I29_A2280CBTipPre = new int[1] ;
         ZZ2281CBTipTipo = "";
         ZZ2293CBRubPreDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestorubroscuenta__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestorubroscuenta__default(),
            new Object[][] {
                new Object[] {
               T007I2_A2280CBTipPre, T007I2_A2281CBTipTipo, T007I2_A2282CBLinPre, T007I2_A2283CBRubPre, T007I2_A2284CBRubDItem, T007I2_A91CueCod, T007I2_A79COSCod, T007I2_n79COSCod
               }
               , new Object[] {
               T007I3_A2280CBTipPre, T007I3_A2281CBTipTipo, T007I3_A2282CBLinPre, T007I3_A2283CBRubPre, T007I3_A2284CBRubDItem, T007I3_A91CueCod, T007I3_A79COSCod, T007I3_n79COSCod
               }
               , new Object[] {
               T007I4_A860CueDsc
               }
               , new Object[] {
               T007I5_A761COSDsc
               }
               , new Object[] {
               T007I6_A2283CBRubPre, T007I6_A2293CBRubPreDsc, T007I6_A2294CBRubPreSts, T007I6_A2295CBRubTItem, T007I6_A2280CBTipPre, T007I6_A2281CBTipTipo, T007I6_A2282CBLinPre
               }
               , new Object[] {
               T007I7_A2283CBRubPre, T007I7_A2293CBRubPreDsc, T007I7_A2294CBRubPreSts, T007I7_A2295CBRubTItem, T007I7_A2280CBTipPre, T007I7_A2281CBTipTipo, T007I7_A2282CBLinPre
               }
               , new Object[] {
               T007I8_A2280CBTipPre
               }
               , new Object[] {
               T007I9_A2283CBRubPre, T007I9_A2293CBRubPreDsc, T007I9_A2294CBRubPreSts, T007I9_A2295CBRubTItem, T007I9_A2280CBTipPre, T007I9_A2281CBTipTipo, T007I9_A2282CBLinPre
               }
               , new Object[] {
               T007I10_A2280CBTipPre
               }
               , new Object[] {
               T007I11_A2280CBTipPre, T007I11_A2281CBTipTipo, T007I11_A2282CBLinPre, T007I11_A2283CBRubPre
               }
               , new Object[] {
               T007I12_A2280CBTipPre, T007I12_A2281CBTipTipo, T007I12_A2282CBLinPre, T007I12_A2283CBRubPre
               }
               , new Object[] {
               T007I13_A2280CBTipPre, T007I13_A2281CBTipTipo, T007I13_A2282CBLinPre, T007I13_A2283CBRubPre
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007I17_A2280CBTipPre, T007I17_A2281CBTipTipo, T007I17_A2282CBLinPre, T007I17_A2283CBRubPre, T007I17_A2285CBRubPreAno
               }
               , new Object[] {
               T007I18_A2280CBTipPre, T007I18_A2281CBTipTipo, T007I18_A2282CBLinPre, T007I18_A2283CBRubPre
               }
               , new Object[] {
               T007I19_A2280CBTipPre, T007I19_A2281CBTipTipo, T007I19_A2282CBLinPre, T007I19_A2283CBRubPre, T007I19_A2284CBRubDItem, T007I19_A860CueDsc, T007I19_A761COSDsc, T007I19_A91CueCod, T007I19_A79COSCod, T007I19_n79COSCod
               }
               , new Object[] {
               T007I20_A860CueDsc
               }
               , new Object[] {
               T007I21_A761COSDsc
               }
               , new Object[] {
               T007I22_A2280CBTipPre, T007I22_A2281CBTipTipo, T007I22_A2282CBLinPre, T007I22_A2283CBRubPre, T007I22_A2284CBRubDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007I26_A860CueDsc
               }
               , new Object[] {
               T007I27_A761COSDsc
               }
               , new Object[] {
               T007I28_A2280CBTipPre, T007I28_A2281CBTipTipo, T007I28_A2282CBLinPre, T007I28_A2283CBRubPre, T007I28_A2284CBRubDItem
               }
               , new Object[] {
               T007I29_A2280CBTipPre
               }
            }
         );
      }

      private short Z2294CBRubPreSts ;
      private short nRcdDeleted_207 ;
      private short nRcdExists_207 ;
      private short nIsMod_207 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2294CBRubPreSts ;
      private short subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolorstyle ;
      private short subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowselection ;
      private short subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowhovering ;
      private short subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allowcollapsing ;
      private short subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Collapsed ;
      private short nBlankRcdCount207 ;
      private short RcdFound207 ;
      private short nBlankRcdUsr207 ;
      private short GX_JID ;
      private short RcdFound205 ;
      private short nIsDirty_205 ;
      private short Gx_BScreen ;
      private short nIsDirty_207 ;
      private short subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ2294CBRubPreSts ;
      private int Z2280CBTipPre ;
      private int Z2282CBLinPre ;
      private int Z2283CBRubPre ;
      private int Z2295CBRubTItem ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int Z2284CBRubDItem ;
      private int A2280CBTipPre ;
      private int A2282CBLinPre ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCBTipPre_Enabled ;
      private int edtCBTipTipo_Enabled ;
      private int edtCBLinPre_Enabled ;
      private int A2283CBRubPre ;
      private int edtCBRubPre_Enabled ;
      private int edtCBRubPreDsc_Enabled ;
      private int edtCBRubPreSts_Enabled ;
      private int A2295CBRubTItem ;
      private int edtCBRubTItem_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int A2284CBRubDItem ;
      private int edtCBRubDItem_Enabled ;
      private int edtCueCod_Enabled ;
      private int edtCOSCod_Enabled ;
      private int edtCueDsc_Enabled ;
      private int edtCOSDsc_Enabled ;
      private int subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Selectedindex ;
      private int subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Selectioncolor ;
      private int subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Backcolor ;
      private int subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Allbackcolor ;
      private int defedtCBRubDItem_Enabled ;
      private int idxLst ;
      private int ZZ2280CBTipPre ;
      private int ZZ2282CBLinPre ;
      private int ZZ2283CBRubPre ;
      private int ZZ2295CBRubTItem ;
      private long GRIDCBPRESUPUESTORUBROSCUENTA_CBPRESUPUESTORUBROSDET_nFirstRecordOnPage ;
      private string sPrefix ;
      private string Z91CueCod ;
      private string Z79COSCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string sGXsfl_64_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCBTipPre_Internalname ;
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
      private string edtCBTipPre_Jsonclick ;
      private string edtCBTipTipo_Internalname ;
      private string edtCBTipTipo_Jsonclick ;
      private string edtCBLinPre_Internalname ;
      private string edtCBLinPre_Jsonclick ;
      private string edtCBRubPre_Internalname ;
      private string edtCBRubPre_Jsonclick ;
      private string edtCBRubPreDsc_Internalname ;
      private string edtCBRubPreDsc_Jsonclick ;
      private string edtCBRubPreSts_Internalname ;
      private string edtCBRubPreSts_Jsonclick ;
      private string edtCBRubTItem_Internalname ;
      private string edtCBRubTItem_Jsonclick ;
      private string lblTitlecbpresupuestorubrosdet_Internalname ;
      private string lblTitlecbpresupuestorubrosdet_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Header ;
      private string A860CueDsc ;
      private string A761COSDsc ;
      private string sMode207 ;
      private string edtCBRubDItem_Internalname ;
      private string edtCueCod_Internalname ;
      private string edtCOSCod_Internalname ;
      private string edtCueDsc_Internalname ;
      private string edtCOSDsc_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode205 ;
      private string Z860CueDsc ;
      private string Z761COSDsc ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Class ;
      private string subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Linesclass ;
      private string ROClassString ;
      private string edtCBRubDItem_Jsonclick ;
      private string edtCueCod_Jsonclick ;
      private string edtCOSCod_Jsonclick ;
      private string edtCueDsc_Jsonclick ;
      private string edtCOSDsc_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcbpresupuestorubroscuenta_cbpresupuestorubrosdet_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n79COSCod ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private string Z2281CBTipTipo ;
      private string Z2293CBRubPreDsc ;
      private string A2281CBTipTipo ;
      private string A2293CBRubPreDsc ;
      private string ZZ2281CBTipTipo ;
      private string ZZ2293CBRubPreDsc ;
      private GXWebGrid Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetContainer ;
      private GXWebRow Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetRow ;
      private GXWebColumn Gridcbpresupuestorubroscuenta_cbpresupuestorubrosdetColumn ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T007I9_A2283CBRubPre ;
      private string[] T007I9_A2293CBRubPreDsc ;
      private short[] T007I9_A2294CBRubPreSts ;
      private int[] T007I9_A2295CBRubTItem ;
      private int[] T007I9_A2280CBTipPre ;
      private string[] T007I9_A2281CBTipTipo ;
      private int[] T007I9_A2282CBLinPre ;
      private int[] T007I8_A2280CBTipPre ;
      private int[] T007I10_A2280CBTipPre ;
      private int[] T007I11_A2280CBTipPre ;
      private string[] T007I11_A2281CBTipTipo ;
      private int[] T007I11_A2282CBLinPre ;
      private int[] T007I11_A2283CBRubPre ;
      private int[] T007I7_A2283CBRubPre ;
      private string[] T007I7_A2293CBRubPreDsc ;
      private short[] T007I7_A2294CBRubPreSts ;
      private int[] T007I7_A2295CBRubTItem ;
      private int[] T007I7_A2280CBTipPre ;
      private string[] T007I7_A2281CBTipTipo ;
      private int[] T007I7_A2282CBLinPre ;
      private int[] T007I12_A2280CBTipPre ;
      private string[] T007I12_A2281CBTipTipo ;
      private int[] T007I12_A2282CBLinPre ;
      private int[] T007I12_A2283CBRubPre ;
      private int[] T007I13_A2280CBTipPre ;
      private string[] T007I13_A2281CBTipTipo ;
      private int[] T007I13_A2282CBLinPre ;
      private int[] T007I13_A2283CBRubPre ;
      private int[] T007I6_A2283CBRubPre ;
      private string[] T007I6_A2293CBRubPreDsc ;
      private short[] T007I6_A2294CBRubPreSts ;
      private int[] T007I6_A2295CBRubTItem ;
      private int[] T007I6_A2280CBTipPre ;
      private string[] T007I6_A2281CBTipTipo ;
      private int[] T007I6_A2282CBLinPre ;
      private int[] T007I17_A2280CBTipPre ;
      private string[] T007I17_A2281CBTipTipo ;
      private int[] T007I17_A2282CBLinPre ;
      private int[] T007I17_A2283CBRubPre ;
      private short[] T007I17_A2285CBRubPreAno ;
      private int[] T007I18_A2280CBTipPre ;
      private string[] T007I18_A2281CBTipTipo ;
      private int[] T007I18_A2282CBLinPre ;
      private int[] T007I18_A2283CBRubPre ;
      private int[] T007I19_A2280CBTipPre ;
      private string[] T007I19_A2281CBTipTipo ;
      private int[] T007I19_A2282CBLinPre ;
      private int[] T007I19_A2283CBRubPre ;
      private int[] T007I19_A2284CBRubDItem ;
      private string[] T007I19_A860CueDsc ;
      private string[] T007I19_A761COSDsc ;
      private string[] T007I19_A91CueCod ;
      private string[] T007I19_A79COSCod ;
      private bool[] T007I19_n79COSCod ;
      private string[] T007I4_A860CueDsc ;
      private string[] T007I5_A761COSDsc ;
      private string[] T007I20_A860CueDsc ;
      private string[] T007I21_A761COSDsc ;
      private int[] T007I22_A2280CBTipPre ;
      private string[] T007I22_A2281CBTipTipo ;
      private int[] T007I22_A2282CBLinPre ;
      private int[] T007I22_A2283CBRubPre ;
      private int[] T007I22_A2284CBRubDItem ;
      private int[] T007I3_A2280CBTipPre ;
      private string[] T007I3_A2281CBTipTipo ;
      private int[] T007I3_A2282CBLinPre ;
      private int[] T007I3_A2283CBRubPre ;
      private int[] T007I3_A2284CBRubDItem ;
      private string[] T007I3_A91CueCod ;
      private string[] T007I3_A79COSCod ;
      private bool[] T007I3_n79COSCod ;
      private int[] T007I2_A2280CBTipPre ;
      private string[] T007I2_A2281CBTipTipo ;
      private int[] T007I2_A2282CBLinPre ;
      private int[] T007I2_A2283CBRubPre ;
      private int[] T007I2_A2284CBRubDItem ;
      private string[] T007I2_A91CueCod ;
      private string[] T007I2_A79COSCod ;
      private bool[] T007I2_n79COSCod ;
      private string[] T007I26_A860CueDsc ;
      private string[] T007I27_A761COSDsc ;
      private int[] T007I28_A2280CBTipPre ;
      private string[] T007I28_A2281CBTipTipo ;
      private int[] T007I28_A2282CBLinPre ;
      private int[] T007I28_A2283CBRubPre ;
      private int[] T007I28_A2284CBRubDItem ;
      private int[] T007I29_A2280CBTipPre ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbpresupuestorubroscuenta__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbpresupuestorubroscuenta__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007I9;
        prmT007I9 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I8;
        prmT007I8 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007I10;
        prmT007I10 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007I11;
        prmT007I11 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I7;
        prmT007I7 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I12;
        prmT007I12 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I13;
        prmT007I13 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I6;
        prmT007I6 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I14;
        prmT007I14 = new Object[] {
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBRubPreSts",GXType.Int16,1,0) ,
        new ParDef("@CBRubTItem",GXType.Int32,6,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007I15;
        prmT007I15 = new Object[] {
        new ParDef("@CBRubPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBRubPreSts",GXType.Int16,1,0) ,
        new ParDef("@CBRubTItem",GXType.Int32,6,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I16;
        prmT007I16 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I17;
        prmT007I17 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I18;
        prmT007I18 = new Object[] {
        };
        Object[] prmT007I19;
        prmT007I19 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0)
        };
        Object[] prmT007I4;
        prmT007I4 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007I5;
        prmT007I5 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT007I20;
        prmT007I20 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007I21;
        prmT007I21 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT007I22;
        prmT007I22 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0)
        };
        Object[] prmT007I3;
        prmT007I3 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0)
        };
        Object[] prmT007I2;
        prmT007I2 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0)
        };
        Object[] prmT007I23;
        prmT007I23 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT007I24;
        prmT007I24 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0)
        };
        Object[] prmT007I25;
        prmT007I25 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubDItem",GXType.Int32,6,0)
        };
        Object[] prmT007I28;
        prmT007I28 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007I29;
        prmT007I29 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007I26;
        prmT007I26 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007I27;
        prmT007I27 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T007I2", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem], [CueCod], [COSCod] FROM [CBPRESUPUESTORUBROSCUENTA] WITH (UPDLOCK) WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubDItem] = @CBRubDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I3", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem], [CueCod], [COSCod] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubDItem] = @CBRubDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I4", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I5", "SELECT [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I6", "SELECT [CBRubPre], [CBRubPreDsc], [CBRubPreSts], [CBRubTItem], [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTORUBROS] WITH (UPDLOCK) WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I7", "SELECT [CBRubPre], [CBRubPreDsc], [CBRubPreSts], [CBRubTItem], [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I8", "SELECT [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I9", "SELECT TM1.[CBRubPre], TM1.[CBRubPreDsc], TM1.[CBRubPreSts], TM1.[CBRubTItem], TM1.[CBTipPre], TM1.[CBTipTipo], TM1.[CBLinPre] FROM [CBPRESUPUESTORUBROS] TM1 WHERE TM1.[CBTipPre] = @CBTipPre and TM1.[CBTipTipo] = @CBTipTipo and TM1.[CBLinPre] = @CBLinPre and TM1.[CBRubPre] = @CBRubPre ORDER BY TM1.[CBTipPre], TM1.[CBTipTipo], TM1.[CBLinPre], TM1.[CBRubPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007I9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I10", "SELECT [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I11", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007I11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I12", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE ( [CBTipPre] > @CBTipPre or [CBTipPre] = @CBTipPre and [CBTipTipo] > @CBTipTipo or [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBLinPre] > @CBLinPre or [CBLinPre] = @CBLinPre and [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBRubPre] > @CBRubPre) ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007I12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007I13", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE ( [CBTipPre] < @CBTipPre or [CBTipPre] = @CBTipPre and [CBTipTipo] < @CBTipTipo or [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBLinPre] < @CBLinPre or [CBLinPre] = @CBLinPre and [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBRubPre] < @CBRubPre) ORDER BY [CBTipPre] DESC, [CBTipTipo] DESC, [CBLinPre] DESC, [CBRubPre] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007I13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007I14", "INSERT INTO [CBPRESUPUESTORUBROS]([CBRubPre], [CBRubPreDsc], [CBRubPreSts], [CBRubTItem], [CBTipPre], [CBTipTipo], [CBLinPre]) VALUES(@CBRubPre, @CBRubPreDsc, @CBRubPreSts, @CBRubTItem, @CBTipPre, @CBTipTipo, @CBLinPre)", GxErrorMask.GX_NOMASK,prmT007I14)
           ,new CursorDef("T007I15", "UPDATE [CBPRESUPUESTORUBROS] SET [CBRubPreDsc]=@CBRubPreDsc, [CBRubPreSts]=@CBRubPreSts, [CBRubTItem]=@CBRubTItem  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre", GxErrorMask.GX_NOMASK,prmT007I15)
           ,new CursorDef("T007I16", "DELETE FROM [CBPRESUPUESTORUBROS]  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre", GxErrorMask.GX_NOMASK,prmT007I16)
           ,new CursorDef("T007I17", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007I18", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007I18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I19", "SELECT T1.[CBTipPre], T1.[CBTipTipo], T1.[CBLinPre], T1.[CBRubPre], T1.[CBRubDItem], T2.[CueDsc], T3.[COSDsc], T1.[CueCod], T1.[COSCod] FROM (([CBPRESUPUESTORUBROSCUENTA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) LEFT JOIN [CBCOSTOS] T3 ON T3.[COSCod] = T1.[COSCod]) WHERE T1.[CBTipPre] = @CBTipPre and T1.[CBTipTipo] = @CBTipTipo and T1.[CBLinPre] = @CBLinPre and T1.[CBRubPre] = @CBRubPre and T1.[CBRubDItem] = @CBRubDItem ORDER BY T1.[CBTipPre], T1.[CBTipTipo], T1.[CBLinPre], T1.[CBRubPre], T1.[CBRubDItem] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I20", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I21", "SELECT [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I22", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubDItem] = @CBRubDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I23", "INSERT INTO [CBPRESUPUESTORUBROSCUENTA]([CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem], [CueCod], [COSCod]) VALUES(@CBTipPre, @CBTipTipo, @CBLinPre, @CBRubPre, @CBRubDItem, @CueCod, @COSCod)", GxErrorMask.GX_NOMASK,prmT007I23)
           ,new CursorDef("T007I24", "UPDATE [CBPRESUPUESTORUBROSCUENTA] SET [CueCod]=@CueCod, [COSCod]=@COSCod  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubDItem] = @CBRubDItem", GxErrorMask.GX_NOMASK,prmT007I24)
           ,new CursorDef("T007I25", "DELETE FROM [CBPRESUPUESTORUBROSCUENTA]  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubDItem] = @CBRubDItem", GxErrorMask.GX_NOMASK,prmT007I25)
           ,new CursorDef("T007I26", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I27", "SELECT [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I28", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @CBTipPre and [CBTipTipo] = @CBTipTipo and [CBLinPre] = @CBLinPre and [CBRubPre] = @CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007I29", "SELECT [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007I29,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
