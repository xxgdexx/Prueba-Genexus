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
   public class cbpresupuestorubros : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcbpresupuestorubros_cbpresupuestorubrosdet") == 0 )
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
            gxnrGridcbpresupuestorubros_cbpresupuestorubrosdet_newrow( ) ;
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
            Form.Meta.addItem("description", "Rubros de Presupuestos", 0) ;
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

      public cbpresupuestorubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbpresupuestorubros( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Rubros de Presupuestos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBTipPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2280CBTipPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBTipPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBTipTipo_Internalname, A2281CBTipTipo, StringUtil.RTrim( context.localUtil.Format( A2281CBTipTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBLinPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2282CBLinPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBLinPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2282CBLinPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2282CBLinPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBLinPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBLinPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBRubPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2283CBRubPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBRubPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2283CBRubPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2283CBRubPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBRubPreDsc_Internalname, A2293CBRubPreDsc, StringUtil.RTrim( context.localUtil.Format( A2293CBRubPreDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubPreDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubPreDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBRubPreSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2294CBRubPreSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBRubPreSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2294CBRubPreSts), "9") : context.localUtil.Format( (decimal)(A2294CBRubPreSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubPreSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubPreSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBRubTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2295CBRubTItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBRubTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A2295CBRubTItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2295CBRubTItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBRubTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBRubTItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlecbpresupuestorubrosdet_Internalname, "CBPRESUPUESTORUBROSDET", "", "", lblTitlecbpresupuestorubrosdet_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridcbpresupuestorubros_cbpresupuestorubrosdet( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTORUBROS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridcbpresupuestorubros_cbpresupuestorubrosdet( )
      {
         /*  Grid Control  */
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("GridName", "Gridcbpresupuestorubros_cbpresupuestorubrosdet");
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Header", subGridcbpresupuestorubros_cbpresupuestorubrosdet_Header);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Class", "Grid");
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle), 1, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("CmpContext", "");
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("InMasterPage", "false");
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2285CBRubPreAno), 4, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAno_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2296CBRubPreEne, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreEne_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2297CBRubPreFeb, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreFeb_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2298CBRubPreMar, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMar_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2299CBRubPreAbr, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAbr_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2300CBRubPreMay, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMay_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2301CBRubPreJun, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJun_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2302CBRubPreJul, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJul_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2303CBRubPreAgo, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAgo_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2304CBRubPreSep, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreSep_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2305CBRubPreOct, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreOct_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2306CBRubPreNov, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreNov_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2307CBRubPreDic, 17, 2, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreDic_Enabled), 5, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddColumnProperties(Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Selectedindex), 4, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowselection), 1, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Selectioncolor), 9, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowhovering), 1, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Hoveringcolor), 9, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowcollapsing), 1, 0, ".", "")));
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Collapsed), 1, 0, ".", "")));
         nGXsfl_64_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount206 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_206 = 1;
               ScanStart7H206( ) ;
               while ( RcdFound206 != 0 )
               {
                  init_level_properties206( ) ;
                  getByPrimaryKey7H206( ) ;
                  AddRow7H206( ) ;
                  ScanNext7H206( ) ;
               }
               ScanEnd7H206( ) ;
               nBlankRcdCount206 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal7H206( ) ;
            standaloneModal7H206( ) ;
            sMode206 = Gx_mode;
            while ( nGXsfl_64_idx < nRC_GXsfl_64 )
            {
               bGXsfl_64_Refreshing = true;
               ReadRow7H206( ) ;
               edtCBRubPreAno_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREANO_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAno_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreEne_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREENE_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreEne_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreEne_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreFeb_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREFEB_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreFeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreFeb_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreMar_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREMAR_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreMar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreMar_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreAbr_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREABR_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAbr_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreMay_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREMAY_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreMay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreMay_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreJun_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREJUN_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreJun_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreJun_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreJul_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREJUL_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreJul_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreJul_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreAgo_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREAGO_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreAgo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAgo_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreSep_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPRESEP_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreSep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreSep_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreOct_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREOCT_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreOct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreOct_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreNov_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPRENOV_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreNov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreNov_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               edtCBRubPreDic_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREDIC_"+sGXsfl_64_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCBRubPreDic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreDic_Enabled), 5, 0), !bGXsfl_64_Refreshing);
               if ( ( nRcdExists_206 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal7H206( ) ;
               }
               SendRow7H206( ) ;
               bGXsfl_64_Refreshing = false;
            }
            Gx_mode = sMode206;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount206 = 5;
            nRcdExists_206 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart7H206( ) ;
               while ( RcdFound206 != 0 )
               {
                  sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_64206( ) ;
                  init_level_properties206( ) ;
                  standaloneNotModal7H206( ) ;
                  getByPrimaryKey7H206( ) ;
                  standaloneModal7H206( ) ;
                  AddRow7H206( ) ;
                  ScanNext7H206( ) ;
               }
               ScanEnd7H206( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode206 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx+1), 4, 0), 4, "0");
         SubsflControlProps_64206( ) ;
         InitAll7H206( ) ;
         init_level_properties206( ) ;
         nRcdExists_206 = 0;
         nIsMod_206 = 0;
         nRcdDeleted_206 = 0;
         nBlankRcdCount206 = (short)(nBlankRcdUsr206+nBlankRcdCount206);
         fRowAdded = 0;
         while ( nBlankRcdCount206 > 0 )
         {
            standaloneNotModal7H206( ) ;
            standaloneModal7H206( ) ;
            AddRow7H206( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtCBRubPreAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount206 = (short)(nBlankRcdCount206-1);
         }
         Gx_mode = sMode206;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcbpresupuestorubros_cbpresupuestorubrosdet", Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcbpresupuestorubros_cbpresupuestorubrosdetContainerData", Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcbpresupuestorubros_cbpresupuestorubrosdetContainerData"+"V", Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcbpresupuestorubros_cbpresupuestorubrosdetContainerData"+"V"+"\" value='"+Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.GridValuesHidden()+"'/>") ;
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
               InitAll7H205( ) ;
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
         DisableAttributes7H205( ) ;
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

      protected void CONFIRM_7H206( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow7H206( ) ;
            if ( ( nRcdExists_206 != 0 ) || ( nIsMod_206 != 0 ) )
            {
               GetKey7H206( ) ;
               if ( ( nRcdExists_206 == 0 ) && ( nRcdDeleted_206 == 0 ) )
               {
                  if ( RcdFound206 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate7H206( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7H206( ) ;
                        CloseExtendedTableCursors7H206( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CBRUBPREANO_" + sGXsfl_64_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCBRubPreAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound206 != 0 )
                  {
                     if ( nRcdDeleted_206 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey7H206( ) ;
                        Load7H206( ) ;
                        BeforeValidate7H206( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7H206( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_206 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate7H206( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7H206( ) ;
                              CloseExtendedTableCursors7H206( ) ;
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
                     if ( nRcdDeleted_206 == 0 )
                     {
                        GXCCtl = "CBRUBPREANO_" + sGXsfl_64_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCBRubPreAno_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCBRubPreAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2285CBRubPreAno), 4, 0, ".", ""))) ;
            ChangePostValue( edtCBRubPreEne_Internalname, StringUtil.LTrim( StringUtil.NToC( A2296CBRubPreEne, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreFeb_Internalname, StringUtil.LTrim( StringUtil.NToC( A2297CBRubPreFeb, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreMar_Internalname, StringUtil.LTrim( StringUtil.NToC( A2298CBRubPreMar, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreAbr_Internalname, StringUtil.LTrim( StringUtil.NToC( A2299CBRubPreAbr, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreMay_Internalname, StringUtil.LTrim( StringUtil.NToC( A2300CBRubPreMay, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreJun_Internalname, StringUtil.LTrim( StringUtil.NToC( A2301CBRubPreJun, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreJul_Internalname, StringUtil.LTrim( StringUtil.NToC( A2302CBRubPreJul, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreAgo_Internalname, StringUtil.LTrim( StringUtil.NToC( A2303CBRubPreAgo, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreSep_Internalname, StringUtil.LTrim( StringUtil.NToC( A2304CBRubPreSep, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreOct_Internalname, StringUtil.LTrim( StringUtil.NToC( A2305CBRubPreOct, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreNov_Internalname, StringUtil.LTrim( StringUtil.NToC( A2306CBRubPreNov, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreDic_Internalname, StringUtil.LTrim( StringUtil.NToC( A2307CBRubPreDic, 17, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2285CBRubPreAno_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2285CBRubPreAno), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2296CBRubPreEne_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2296CBRubPreEne, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2297CBRubPreFeb_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2297CBRubPreFeb, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2298CBRubPreMar_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2298CBRubPreMar, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2299CBRubPreAbr_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2299CBRubPreAbr, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2300CBRubPreMay_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2300CBRubPreMay, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2301CBRubPreJun_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2301CBRubPreJun, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2302CBRubPreJul_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2302CBRubPreJul, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2303CBRubPreAgo_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2303CBRubPreAgo, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2304CBRubPreSep_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2304CBRubPreSep, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2305CBRubPreOct_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2305CBRubPreOct, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2306CBRubPreNov_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2306CBRubPreNov, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2307CBRubPreDic_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2307CBRubPreDic, 15, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_206_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_206), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_206_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_206), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_206_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_206), 4, 0, ".", ""))) ;
            if ( nIsMod_206 != 0 )
            {
               ChangePostValue( "CBRUBPREANO_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAno_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREENE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreEne_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREFEB_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreFeb_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREMAR_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREABR_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAbr_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREMAY_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMay_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREJUN_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJun_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREJUL_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJul_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREAGO_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAgo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPRESEP_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreSep_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREOCT_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreOct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPRENOV_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreNov_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREDIC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreDic_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption7H0( )
      {
      }

      protected void ZM7H205( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2293CBRubPreDsc = T007H5_A2293CBRubPreDsc[0];
               Z2294CBRubPreSts = T007H5_A2294CBRubPreSts[0];
               Z2295CBRubTItem = T007H5_A2295CBRubTItem[0];
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

      protected void Load7H205( )
      {
         /* Using cursor T007H7 */
         pr_default.execute(5, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound205 = 1;
            A2293CBRubPreDsc = T007H7_A2293CBRubPreDsc[0];
            AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
            A2294CBRubPreSts = T007H7_A2294CBRubPreSts[0];
            AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
            A2295CBRubTItem = T007H7_A2295CBRubTItem[0];
            AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
            ZM7H205( -1) ;
         }
         pr_default.close(5);
         OnLoadActions7H205( ) ;
      }

      protected void OnLoadActions7H205( )
      {
      }

      protected void CheckExtendedTable7H205( )
      {
         nIsDirty_205 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007H6 */
         pr_default.execute(4, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors7H205( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A2280CBTipPre ,
                               string A2281CBTipTipo ,
                               int A2282CBLinPre )
      {
         /* Using cursor T007H8 */
         pr_default.execute(6, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
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

      protected void GetKey7H205( )
      {
         /* Using cursor T007H9 */
         pr_default.execute(7, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound205 = 1;
         }
         else
         {
            RcdFound205 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007H5 */
         pr_default.execute(3, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM7H205( 1) ;
            RcdFound205 = 1;
            A2283CBRubPre = T007H5_A2283CBRubPre[0];
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
            A2293CBRubPreDsc = T007H5_A2293CBRubPreDsc[0];
            AssignAttri("", false, "A2293CBRubPreDsc", A2293CBRubPreDsc);
            A2294CBRubPreSts = T007H5_A2294CBRubPreSts[0];
            AssignAttri("", false, "A2294CBRubPreSts", StringUtil.Str( (decimal)(A2294CBRubPreSts), 1, 0));
            A2295CBRubTItem = T007H5_A2295CBRubTItem[0];
            AssignAttri("", false, "A2295CBRubTItem", StringUtil.LTrimStr( (decimal)(A2295CBRubTItem), 6, 0));
            A2280CBTipPre = T007H5_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007H5_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007H5_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2283CBRubPre = A2283CBRubPre;
            sMode205 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7H205( ) ;
            if ( AnyError == 1 )
            {
               RcdFound205 = 0;
               InitializeNonKey7H205( ) ;
            }
            Gx_mode = sMode205;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound205 = 0;
            InitializeNonKey7H205( ) ;
            sMode205 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode205;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey7H205( ) ;
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
         /* Using cursor T007H10 */
         pr_default.execute(8, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T007H10_A2280CBTipPre[0] < A2280CBTipPre ) || ( T007H10_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007H10_A2281CBTipTipo[0], A2281CBTipTipo) < 0 ) || ( StringUtil.StrCmp(T007H10_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H10_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H10_A2282CBLinPre[0] < A2282CBLinPre ) || ( T007H10_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007H10_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H10_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H10_A2283CBRubPre[0] < A2283CBRubPre ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T007H10_A2280CBTipPre[0] > A2280CBTipPre ) || ( T007H10_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007H10_A2281CBTipTipo[0], A2281CBTipTipo) > 0 ) || ( StringUtil.StrCmp(T007H10_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H10_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H10_A2282CBLinPre[0] > A2282CBLinPre ) || ( T007H10_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007H10_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H10_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H10_A2283CBRubPre[0] > A2283CBRubPre ) ) )
            {
               A2280CBTipPre = T007H10_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = T007H10_A2281CBTipTipo[0];
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = T007H10_A2282CBLinPre[0];
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               A2283CBRubPre = T007H10_A2283CBRubPre[0];
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
               RcdFound205 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound205 = 0;
         /* Using cursor T007H11 */
         pr_default.execute(9, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T007H11_A2280CBTipPre[0] > A2280CBTipPre ) || ( T007H11_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007H11_A2281CBTipTipo[0], A2281CBTipTipo) > 0 ) || ( StringUtil.StrCmp(T007H11_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H11_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H11_A2282CBLinPre[0] > A2282CBLinPre ) || ( T007H11_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007H11_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H11_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H11_A2283CBRubPre[0] > A2283CBRubPre ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T007H11_A2280CBTipPre[0] < A2280CBTipPre ) || ( T007H11_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007H11_A2281CBTipTipo[0], A2281CBTipTipo) < 0 ) || ( StringUtil.StrCmp(T007H11_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H11_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H11_A2282CBLinPre[0] < A2282CBLinPre ) || ( T007H11_A2282CBLinPre[0] == A2282CBLinPre ) && ( StringUtil.StrCmp(T007H11_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007H11_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007H11_A2283CBRubPre[0] < A2283CBRubPre ) ) )
            {
               A2280CBTipPre = T007H11_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = T007H11_A2281CBTipTipo[0];
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = T007H11_A2282CBLinPre[0];
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               A2283CBRubPre = T007H11_A2283CBRubPre[0];
               AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
               RcdFound205 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7H205( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7H205( ) ;
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
                  Update7H205( ) ;
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
                  Insert7H205( ) ;
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
                     Insert7H205( ) ;
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
         ScanStart7H205( ) ;
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
         ScanEnd7H205( ) ;
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
         ScanStart7H205( ) ;
         if ( RcdFound205 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound205 != 0 )
            {
               ScanNext7H205( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBRubPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7H205( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7H205( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007H4 */
            pr_default.execute(2, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z2293CBRubPreDsc, T007H4_A2293CBRubPreDsc[0]) != 0 ) || ( Z2294CBRubPreSts != T007H4_A2294CBRubPreSts[0] ) || ( Z2295CBRubTItem != T007H4_A2295CBRubTItem[0] ) )
            {
               if ( StringUtil.StrCmp(Z2293CBRubPreDsc, T007H4_A2293CBRubPreDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2293CBRubPreDsc);
                  GXUtil.WriteLogRaw("Current: ",T007H4_A2293CBRubPreDsc[0]);
               }
               if ( Z2294CBRubPreSts != T007H4_A2294CBRubPreSts[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreSts");
                  GXUtil.WriteLogRaw("Old: ",Z2294CBRubPreSts);
                  GXUtil.WriteLogRaw("Current: ",T007H4_A2294CBRubPreSts[0]);
               }
               if ( Z2295CBRubTItem != T007H4_A2295CBRubTItem[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubTItem");
                  GXUtil.WriteLogRaw("Old: ",Z2295CBRubTItem);
                  GXUtil.WriteLogRaw("Current: ",T007H4_A2295CBRubTItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPRESUPUESTORUBROS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7H205( )
      {
         BeforeValidate7H205( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7H205( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7H205( 0) ;
            CheckOptimisticConcurrency7H205( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7H205( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7H205( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007H12 */
                     pr_default.execute(10, new Object[] {A2283CBRubPre, A2293CBRubPreDsc, A2294CBRubPreSts, A2295CBRubTItem, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROS");
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
                           ProcessLevel7H205( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption7H0( ) ;
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
               Load7H205( ) ;
            }
            EndLevel7H205( ) ;
         }
         CloseExtendedTableCursors7H205( ) ;
      }

      protected void Update7H205( )
      {
         BeforeValidate7H205( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7H205( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7H205( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7H205( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7H205( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007H13 */
                     pr_default.execute(11, new Object[] {A2293CBRubPreDsc, A2294CBRubPreSts, A2295CBRubTItem, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7H205( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel7H205( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption7H0( ) ;
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
            EndLevel7H205( ) ;
         }
         CloseExtendedTableCursors7H205( ) ;
      }

      protected void DeferredUpdate7H205( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7H205( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7H205( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7H205( ) ;
            AfterConfirm7H205( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7H205( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart7H206( ) ;
                  while ( RcdFound206 != 0 )
                  {
                     getByPrimaryKey7H206( ) ;
                     Delete7H206( ) ;
                     ScanNext7H206( ) ;
                  }
                  ScanEnd7H206( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007H14 */
                     pr_default.execute(12, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
                     pr_default.close(12);
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
                              InitAll7H205( ) ;
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
                           ResetCaption7H0( ) ;
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
         EndLevel7H205( ) ;
         Gx_mode = sMode205;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7H205( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007H15 */
            pr_default.execute(13, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel7H206( )
      {
         nGXsfl_64_idx = 0;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            ReadRow7H206( ) ;
            if ( ( nRcdExists_206 != 0 ) || ( nIsMod_206 != 0 ) )
            {
               standaloneNotModal7H206( ) ;
               GetKey7H206( ) ;
               if ( ( nRcdExists_206 == 0 ) && ( nRcdDeleted_206 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert7H206( ) ;
               }
               else
               {
                  if ( RcdFound206 != 0 )
                  {
                     if ( ( nRcdDeleted_206 != 0 ) && ( nRcdExists_206 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete7H206( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_206 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update7H206( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_206 == 0 )
                     {
                        GXCCtl = "CBRUBPREANO_" + sGXsfl_64_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCBRubPreAno_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCBRubPreAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2285CBRubPreAno), 4, 0, ".", ""))) ;
            ChangePostValue( edtCBRubPreEne_Internalname, StringUtil.LTrim( StringUtil.NToC( A2296CBRubPreEne, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreFeb_Internalname, StringUtil.LTrim( StringUtil.NToC( A2297CBRubPreFeb, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreMar_Internalname, StringUtil.LTrim( StringUtil.NToC( A2298CBRubPreMar, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreAbr_Internalname, StringUtil.LTrim( StringUtil.NToC( A2299CBRubPreAbr, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreMay_Internalname, StringUtil.LTrim( StringUtil.NToC( A2300CBRubPreMay, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreJun_Internalname, StringUtil.LTrim( StringUtil.NToC( A2301CBRubPreJun, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreJul_Internalname, StringUtil.LTrim( StringUtil.NToC( A2302CBRubPreJul, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreAgo_Internalname, StringUtil.LTrim( StringUtil.NToC( A2303CBRubPreAgo, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreSep_Internalname, StringUtil.LTrim( StringUtil.NToC( A2304CBRubPreSep, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreOct_Internalname, StringUtil.LTrim( StringUtil.NToC( A2305CBRubPreOct, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreNov_Internalname, StringUtil.LTrim( StringUtil.NToC( A2306CBRubPreNov, 17, 2, ".", ""))) ;
            ChangePostValue( edtCBRubPreDic_Internalname, StringUtil.LTrim( StringUtil.NToC( A2307CBRubPreDic, 17, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2285CBRubPreAno_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2285CBRubPreAno), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2296CBRubPreEne_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2296CBRubPreEne, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2297CBRubPreFeb_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2297CBRubPreFeb, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2298CBRubPreMar_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2298CBRubPreMar, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2299CBRubPreAbr_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2299CBRubPreAbr, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2300CBRubPreMay_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2300CBRubPreMay, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2301CBRubPreJun_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2301CBRubPreJun, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2302CBRubPreJul_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2302CBRubPreJul, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2303CBRubPreAgo_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2303CBRubPreAgo, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2304CBRubPreSep_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2304CBRubPreSep, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2305CBRubPreOct_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2305CBRubPreOct, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2306CBRubPreNov_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2306CBRubPreNov, 15, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2307CBRubPreDic_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( Z2307CBRubPreDic, 15, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_206_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_206), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_206_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_206), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_206_"+sGXsfl_64_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_206), 4, 0, ".", ""))) ;
            if ( nIsMod_206 != 0 )
            {
               ChangePostValue( "CBRUBPREANO_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAno_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREENE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreEne_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREFEB_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreFeb_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREMAR_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREABR_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAbr_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREMAY_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMay_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREJUN_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJun_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREJUL_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJul_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREAGO_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAgo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPRESEP_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreSep_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREOCT_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreOct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPRENOV_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreNov_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CBRUBPREDIC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreDic_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7H206( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_206 = 0;
         nIsMod_206 = 0;
         nRcdDeleted_206 = 0;
      }

      protected void ProcessLevel7H205( )
      {
         /* Save parent mode. */
         sMode205 = Gx_mode;
         ProcessNestedLevel7H206( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode205;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel7H205( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7H205( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("cbpresupuestorubros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("cbpresupuestorubros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7H205( )
      {
         /* Using cursor T007H16 */
         pr_default.execute(14);
         RcdFound205 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound205 = 1;
            A2280CBTipPre = T007H16_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007H16_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007H16_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            A2283CBRubPre = T007H16_A2283CBRubPre[0];
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7H205( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound205 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound205 = 1;
            A2280CBTipPre = T007H16_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007H16_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007H16_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            A2283CBRubPre = T007H16_A2283CBRubPre[0];
            AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
         }
      }

      protected void ScanEnd7H205( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm7H205( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7H205( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7H205( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7H205( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7H205( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7H205( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7H205( )
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

      protected void ZM7H206( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2296CBRubPreEne = T007H3_A2296CBRubPreEne[0];
               Z2297CBRubPreFeb = T007H3_A2297CBRubPreFeb[0];
               Z2298CBRubPreMar = T007H3_A2298CBRubPreMar[0];
               Z2299CBRubPreAbr = T007H3_A2299CBRubPreAbr[0];
               Z2300CBRubPreMay = T007H3_A2300CBRubPreMay[0];
               Z2301CBRubPreJun = T007H3_A2301CBRubPreJun[0];
               Z2302CBRubPreJul = T007H3_A2302CBRubPreJul[0];
               Z2303CBRubPreAgo = T007H3_A2303CBRubPreAgo[0];
               Z2304CBRubPreSep = T007H3_A2304CBRubPreSep[0];
               Z2305CBRubPreOct = T007H3_A2305CBRubPreOct[0];
               Z2306CBRubPreNov = T007H3_A2306CBRubPreNov[0];
               Z2307CBRubPreDic = T007H3_A2307CBRubPreDic[0];
            }
            else
            {
               Z2296CBRubPreEne = A2296CBRubPreEne;
               Z2297CBRubPreFeb = A2297CBRubPreFeb;
               Z2298CBRubPreMar = A2298CBRubPreMar;
               Z2299CBRubPreAbr = A2299CBRubPreAbr;
               Z2300CBRubPreMay = A2300CBRubPreMay;
               Z2301CBRubPreJun = A2301CBRubPreJun;
               Z2302CBRubPreJul = A2302CBRubPreJul;
               Z2303CBRubPreAgo = A2303CBRubPreAgo;
               Z2304CBRubPreSep = A2304CBRubPreSep;
               Z2305CBRubPreOct = A2305CBRubPreOct;
               Z2306CBRubPreNov = A2306CBRubPreNov;
               Z2307CBRubPreDic = A2307CBRubPreDic;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2283CBRubPre = A2283CBRubPre;
            Z2285CBRubPreAno = A2285CBRubPreAno;
            Z2296CBRubPreEne = A2296CBRubPreEne;
            Z2297CBRubPreFeb = A2297CBRubPreFeb;
            Z2298CBRubPreMar = A2298CBRubPreMar;
            Z2299CBRubPreAbr = A2299CBRubPreAbr;
            Z2300CBRubPreMay = A2300CBRubPreMay;
            Z2301CBRubPreJun = A2301CBRubPreJun;
            Z2302CBRubPreJul = A2302CBRubPreJul;
            Z2303CBRubPreAgo = A2303CBRubPreAgo;
            Z2304CBRubPreSep = A2304CBRubPreSep;
            Z2305CBRubPreOct = A2305CBRubPreOct;
            Z2306CBRubPreNov = A2306CBRubPreNov;
            Z2307CBRubPreDic = A2307CBRubPreDic;
         }
      }

      protected void standaloneNotModal7H206( )
      {
      }

      protected void standaloneModal7H206( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCBRubPreAno_Enabled = 0;
            AssignProp("", false, edtCBRubPreAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAno_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         }
         else
         {
            edtCBRubPreAno_Enabled = 1;
            AssignProp("", false, edtCBRubPreAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAno_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         }
      }

      protected void Load7H206( )
      {
         /* Using cursor T007H17 */
         pr_default.execute(15, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound206 = 1;
            A2296CBRubPreEne = T007H17_A2296CBRubPreEne[0];
            A2297CBRubPreFeb = T007H17_A2297CBRubPreFeb[0];
            A2298CBRubPreMar = T007H17_A2298CBRubPreMar[0];
            A2299CBRubPreAbr = T007H17_A2299CBRubPreAbr[0];
            A2300CBRubPreMay = T007H17_A2300CBRubPreMay[0];
            A2301CBRubPreJun = T007H17_A2301CBRubPreJun[0];
            A2302CBRubPreJul = T007H17_A2302CBRubPreJul[0];
            A2303CBRubPreAgo = T007H17_A2303CBRubPreAgo[0];
            A2304CBRubPreSep = T007H17_A2304CBRubPreSep[0];
            A2305CBRubPreOct = T007H17_A2305CBRubPreOct[0];
            A2306CBRubPreNov = T007H17_A2306CBRubPreNov[0];
            A2307CBRubPreDic = T007H17_A2307CBRubPreDic[0];
            ZM7H206( -3) ;
         }
         pr_default.close(15);
         OnLoadActions7H206( ) ;
      }

      protected void OnLoadActions7H206( )
      {
      }

      protected void CheckExtendedTable7H206( )
      {
         nIsDirty_206 = 0;
         Gx_BScreen = 1;
         standaloneModal7H206( ) ;
      }

      protected void CloseExtendedTableCursors7H206( )
      {
      }

      protected void enableDisable7H206( )
      {
      }

      protected void GetKey7H206( )
      {
         /* Using cursor T007H18 */
         pr_default.execute(16, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound206 = 1;
         }
         else
         {
            RcdFound206 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey7H206( )
      {
         /* Using cursor T007H3 */
         pr_default.execute(1, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7H206( 3) ;
            RcdFound206 = 1;
            InitializeNonKey7H206( ) ;
            A2285CBRubPreAno = T007H3_A2285CBRubPreAno[0];
            A2296CBRubPreEne = T007H3_A2296CBRubPreEne[0];
            A2297CBRubPreFeb = T007H3_A2297CBRubPreFeb[0];
            A2298CBRubPreMar = T007H3_A2298CBRubPreMar[0];
            A2299CBRubPreAbr = T007H3_A2299CBRubPreAbr[0];
            A2300CBRubPreMay = T007H3_A2300CBRubPreMay[0];
            A2301CBRubPreJun = T007H3_A2301CBRubPreJun[0];
            A2302CBRubPreJul = T007H3_A2302CBRubPreJul[0];
            A2303CBRubPreAgo = T007H3_A2303CBRubPreAgo[0];
            A2304CBRubPreSep = T007H3_A2304CBRubPreSep[0];
            A2305CBRubPreOct = T007H3_A2305CBRubPreOct[0];
            A2306CBRubPreNov = T007H3_A2306CBRubPreNov[0];
            A2307CBRubPreDic = T007H3_A2307CBRubPreDic[0];
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2283CBRubPre = A2283CBRubPre;
            Z2285CBRubPreAno = A2285CBRubPreAno;
            sMode206 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7H206( ) ;
            Load7H206( ) ;
            Gx_mode = sMode206;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound206 = 0;
            InitializeNonKey7H206( ) ;
            sMode206 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7H206( ) ;
            Gx_mode = sMode206;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7H206( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency7H206( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007H2 */
            pr_default.execute(0, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z2296CBRubPreEne != T007H2_A2296CBRubPreEne[0] ) || ( Z2297CBRubPreFeb != T007H2_A2297CBRubPreFeb[0] ) || ( Z2298CBRubPreMar != T007H2_A2298CBRubPreMar[0] ) || ( Z2299CBRubPreAbr != T007H2_A2299CBRubPreAbr[0] ) || ( Z2300CBRubPreMay != T007H2_A2300CBRubPreMay[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2301CBRubPreJun != T007H2_A2301CBRubPreJun[0] ) || ( Z2302CBRubPreJul != T007H2_A2302CBRubPreJul[0] ) || ( Z2303CBRubPreAgo != T007H2_A2303CBRubPreAgo[0] ) || ( Z2304CBRubPreSep != T007H2_A2304CBRubPreSep[0] ) || ( Z2305CBRubPreOct != T007H2_A2305CBRubPreOct[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2306CBRubPreNov != T007H2_A2306CBRubPreNov[0] ) || ( Z2307CBRubPreDic != T007H2_A2307CBRubPreDic[0] ) )
            {
               if ( Z2296CBRubPreEne != T007H2_A2296CBRubPreEne[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreEne");
                  GXUtil.WriteLogRaw("Old: ",Z2296CBRubPreEne);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2296CBRubPreEne[0]);
               }
               if ( Z2297CBRubPreFeb != T007H2_A2297CBRubPreFeb[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreFeb");
                  GXUtil.WriteLogRaw("Old: ",Z2297CBRubPreFeb);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2297CBRubPreFeb[0]);
               }
               if ( Z2298CBRubPreMar != T007H2_A2298CBRubPreMar[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreMar");
                  GXUtil.WriteLogRaw("Old: ",Z2298CBRubPreMar);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2298CBRubPreMar[0]);
               }
               if ( Z2299CBRubPreAbr != T007H2_A2299CBRubPreAbr[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreAbr");
                  GXUtil.WriteLogRaw("Old: ",Z2299CBRubPreAbr);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2299CBRubPreAbr[0]);
               }
               if ( Z2300CBRubPreMay != T007H2_A2300CBRubPreMay[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreMay");
                  GXUtil.WriteLogRaw("Old: ",Z2300CBRubPreMay);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2300CBRubPreMay[0]);
               }
               if ( Z2301CBRubPreJun != T007H2_A2301CBRubPreJun[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreJun");
                  GXUtil.WriteLogRaw("Old: ",Z2301CBRubPreJun);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2301CBRubPreJun[0]);
               }
               if ( Z2302CBRubPreJul != T007H2_A2302CBRubPreJul[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreJul");
                  GXUtil.WriteLogRaw("Old: ",Z2302CBRubPreJul);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2302CBRubPreJul[0]);
               }
               if ( Z2303CBRubPreAgo != T007H2_A2303CBRubPreAgo[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreAgo");
                  GXUtil.WriteLogRaw("Old: ",Z2303CBRubPreAgo);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2303CBRubPreAgo[0]);
               }
               if ( Z2304CBRubPreSep != T007H2_A2304CBRubPreSep[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreSep");
                  GXUtil.WriteLogRaw("Old: ",Z2304CBRubPreSep);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2304CBRubPreSep[0]);
               }
               if ( Z2305CBRubPreOct != T007H2_A2305CBRubPreOct[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreOct");
                  GXUtil.WriteLogRaw("Old: ",Z2305CBRubPreOct);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2305CBRubPreOct[0]);
               }
               if ( Z2306CBRubPreNov != T007H2_A2306CBRubPreNov[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreNov");
                  GXUtil.WriteLogRaw("Old: ",Z2306CBRubPreNov);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2306CBRubPreNov[0]);
               }
               if ( Z2307CBRubPreDic != T007H2_A2307CBRubPreDic[0] )
               {
                  GXUtil.WriteLog("cbpresupuestorubros:[seudo value changed for attri]"+"CBRubPreDic");
                  GXUtil.WriteLogRaw("Old: ",Z2307CBRubPreDic);
                  GXUtil.WriteLogRaw("Current: ",T007H2_A2307CBRubPreDic[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7H206( )
      {
         BeforeValidate7H206( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7H206( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7H206( 0) ;
            CheckOptimisticConcurrency7H206( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7H206( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7H206( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007H19 */
                     pr_default.execute(17, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno, A2296CBRubPreEne, A2297CBRubPreFeb, A2298CBRubPreMar, A2299CBRubPreAbr, A2300CBRubPreMay, A2301CBRubPreJun, A2302CBRubPreJul, A2303CBRubPreAgo, A2304CBRubPreSep, A2305CBRubPreOct, A2306CBRubPreNov, A2307CBRubPreDic});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROSDET");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load7H206( ) ;
            }
            EndLevel7H206( ) ;
         }
         CloseExtendedTableCursors7H206( ) ;
      }

      protected void Update7H206( )
      {
         BeforeValidate7H206( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7H206( ) ;
         }
         if ( ( nIsMod_206 != 0 ) || ( nIsDirty_206 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency7H206( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm7H206( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate7H206( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007H20 */
                        pr_default.execute(18, new Object[] {A2296CBRubPreEne, A2297CBRubPreFeb, A2298CBRubPreMar, A2299CBRubPreAbr, A2300CBRubPreMay, A2301CBRubPreJun, A2302CBRubPreJul, A2303CBRubPreAgo, A2304CBRubPreSep, A2305CBRubPreOct, A2306CBRubPreNov, A2307CBRubPreDic, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno});
                        pr_default.close(18);
                        dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROSDET");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate7H206( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey7H206( ) ;
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
               EndLevel7H206( ) ;
            }
         }
         CloseExtendedTableCursors7H206( ) ;
      }

      protected void DeferredUpdate7H206( )
      {
      }

      protected void Delete7H206( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7H206( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7H206( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7H206( ) ;
            AfterConfirm7H206( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7H206( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007H21 */
                  pr_default.execute(19, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre, A2285CBRubPreAno});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTORUBROSDET");
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
         sMode206 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7H206( ) ;
         Gx_mode = sMode206;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7H206( )
      {
         standaloneModal7H206( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7H206( )
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

      public void ScanStart7H206( )
      {
         /* Scan By routine */
         /* Using cursor T007H22 */
         pr_default.execute(20, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre, A2283CBRubPre});
         RcdFound206 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound206 = 1;
            A2285CBRubPreAno = T007H22_A2285CBRubPreAno[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7H206( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound206 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound206 = 1;
            A2285CBRubPreAno = T007H22_A2285CBRubPreAno[0];
         }
      }

      protected void ScanEnd7H206( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm7H206( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7H206( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7H206( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7H206( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7H206( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7H206( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7H206( )
      {
         edtCBRubPreAno_Enabled = 0;
         AssignProp("", false, edtCBRubPreAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAno_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreEne_Enabled = 0;
         AssignProp("", false, edtCBRubPreEne_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreEne_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreFeb_Enabled = 0;
         AssignProp("", false, edtCBRubPreFeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreFeb_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreMar_Enabled = 0;
         AssignProp("", false, edtCBRubPreMar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreMar_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreAbr_Enabled = 0;
         AssignProp("", false, edtCBRubPreAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAbr_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreMay_Enabled = 0;
         AssignProp("", false, edtCBRubPreMay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreMay_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreJun_Enabled = 0;
         AssignProp("", false, edtCBRubPreJun_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreJun_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreJul_Enabled = 0;
         AssignProp("", false, edtCBRubPreJul_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreJul_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreAgo_Enabled = 0;
         AssignProp("", false, edtCBRubPreAgo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAgo_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreSep_Enabled = 0;
         AssignProp("", false, edtCBRubPreSep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreSep_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreOct_Enabled = 0;
         AssignProp("", false, edtCBRubPreOct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreOct_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreNov_Enabled = 0;
         AssignProp("", false, edtCBRubPreNov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreNov_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtCBRubPreDic_Enabled = 0;
         AssignProp("", false, edtCBRubPreDic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreDic_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void send_integrity_lvl_hashes7H206( )
      {
      }

      protected void send_integrity_lvl_hashes7H205( )
      {
      }

      protected void SubsflControlProps_64206( )
      {
         edtCBRubPreAno_Internalname = "CBRUBPREANO_"+sGXsfl_64_idx;
         edtCBRubPreEne_Internalname = "CBRUBPREENE_"+sGXsfl_64_idx;
         edtCBRubPreFeb_Internalname = "CBRUBPREFEB_"+sGXsfl_64_idx;
         edtCBRubPreMar_Internalname = "CBRUBPREMAR_"+sGXsfl_64_idx;
         edtCBRubPreAbr_Internalname = "CBRUBPREABR_"+sGXsfl_64_idx;
         edtCBRubPreMay_Internalname = "CBRUBPREMAY_"+sGXsfl_64_idx;
         edtCBRubPreJun_Internalname = "CBRUBPREJUN_"+sGXsfl_64_idx;
         edtCBRubPreJul_Internalname = "CBRUBPREJUL_"+sGXsfl_64_idx;
         edtCBRubPreAgo_Internalname = "CBRUBPREAGO_"+sGXsfl_64_idx;
         edtCBRubPreSep_Internalname = "CBRUBPRESEP_"+sGXsfl_64_idx;
         edtCBRubPreOct_Internalname = "CBRUBPREOCT_"+sGXsfl_64_idx;
         edtCBRubPreNov_Internalname = "CBRUBPRENOV_"+sGXsfl_64_idx;
         edtCBRubPreDic_Internalname = "CBRUBPREDIC_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_64206( )
      {
         edtCBRubPreAno_Internalname = "CBRUBPREANO_"+sGXsfl_64_fel_idx;
         edtCBRubPreEne_Internalname = "CBRUBPREENE_"+sGXsfl_64_fel_idx;
         edtCBRubPreFeb_Internalname = "CBRUBPREFEB_"+sGXsfl_64_fel_idx;
         edtCBRubPreMar_Internalname = "CBRUBPREMAR_"+sGXsfl_64_fel_idx;
         edtCBRubPreAbr_Internalname = "CBRUBPREABR_"+sGXsfl_64_fel_idx;
         edtCBRubPreMay_Internalname = "CBRUBPREMAY_"+sGXsfl_64_fel_idx;
         edtCBRubPreJun_Internalname = "CBRUBPREJUN_"+sGXsfl_64_fel_idx;
         edtCBRubPreJul_Internalname = "CBRUBPREJUL_"+sGXsfl_64_fel_idx;
         edtCBRubPreAgo_Internalname = "CBRUBPREAGO_"+sGXsfl_64_fel_idx;
         edtCBRubPreSep_Internalname = "CBRUBPRESEP_"+sGXsfl_64_fel_idx;
         edtCBRubPreOct_Internalname = "CBRUBPREOCT_"+sGXsfl_64_fel_idx;
         edtCBRubPreNov_Internalname = "CBRUBPRENOV_"+sGXsfl_64_fel_idx;
         edtCBRubPreDic_Internalname = "CBRUBPREDIC_"+sGXsfl_64_fel_idx;
      }

      protected void AddRow7H206( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_64206( ) ;
         SendRow7H206( ) ;
      }

      protected void SendRow7H206( )
      {
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow = GXWebRow.GetNew(context);
         if ( subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class, "") != 0 )
            {
               subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class+"Odd";
            }
         }
         else if ( subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backstyle = 0;
            subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolor = subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class, "") != 0 )
            {
               subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class+"Uniform";
            }
         }
         else if ( subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class, "") != 0 )
            {
               subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class+"Odd";
            }
            subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolor = (int)(0x0);
         }
         else if ( subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backstyle = 1;
            if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
            {
               subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class, "") != 0 )
               {
                  subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class+"Even";
               }
            }
            else
            {
               subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class, "") != 0 )
               {
                  subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass = subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2285CBRubPreAno), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2285CBRubPreAno), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreAno_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreEne_Internalname,StringUtil.LTrim( StringUtil.NToC( A2296CBRubPreEne, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreEne_Enabled!=0) ? context.localUtil.Format( A2296CBRubPreEne, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2296CBRubPreEne, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreEne_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreEne_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreFeb_Internalname,StringUtil.LTrim( StringUtil.NToC( A2297CBRubPreFeb, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreFeb_Enabled!=0) ? context.localUtil.Format( A2297CBRubPreFeb, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2297CBRubPreFeb, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreFeb_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreFeb_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreMar_Internalname,StringUtil.LTrim( StringUtil.NToC( A2298CBRubPreMar, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreMar_Enabled!=0) ? context.localUtil.Format( A2298CBRubPreMar, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2298CBRubPreMar, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreMar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreMar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreAbr_Internalname,StringUtil.LTrim( StringUtil.NToC( A2299CBRubPreAbr, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreAbr_Enabled!=0) ? context.localUtil.Format( A2299CBRubPreAbr, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2299CBRubPreAbr, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreAbr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreAbr_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreMay_Internalname,StringUtil.LTrim( StringUtil.NToC( A2300CBRubPreMay, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreMay_Enabled!=0) ? context.localUtil.Format( A2300CBRubPreMay, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2300CBRubPreMay, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,70);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreMay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreMay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreJun_Internalname,StringUtil.LTrim( StringUtil.NToC( A2301CBRubPreJun, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreJun_Enabled!=0) ? context.localUtil.Format( A2301CBRubPreJun, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2301CBRubPreJun, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreJun_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreJun_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreJul_Internalname,StringUtil.LTrim( StringUtil.NToC( A2302CBRubPreJul, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreJul_Enabled!=0) ? context.localUtil.Format( A2302CBRubPreJul, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2302CBRubPreJul, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,72);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreJul_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreJul_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreAgo_Internalname,StringUtil.LTrim( StringUtil.NToC( A2303CBRubPreAgo, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreAgo_Enabled!=0) ? context.localUtil.Format( A2303CBRubPreAgo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2303CBRubPreAgo, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreAgo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreAgo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreSep_Internalname,StringUtil.LTrim( StringUtil.NToC( A2304CBRubPreSep, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreSep_Enabled!=0) ? context.localUtil.Format( A2304CBRubPreSep, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2304CBRubPreSep, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreSep_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreSep_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreOct_Internalname,StringUtil.LTrim( StringUtil.NToC( A2305CBRubPreOct, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreOct_Enabled!=0) ? context.localUtil.Format( A2305CBRubPreOct, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2305CBRubPreOct, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreOct_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreOct_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreNov_Internalname,StringUtil.LTrim( StringUtil.NToC( A2306CBRubPreNov, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreNov_Enabled!=0) ? context.localUtil.Format( A2306CBRubPreNov, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2306CBRubPreNov, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreNov_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreNov_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_206_" + sGXsfl_64_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "Attribute";
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCBRubPreDic_Internalname,StringUtil.LTrim( StringUtil.NToC( A2307CBRubPreDic, 17, 2, ".", "")),StringUtil.LTrim( ((edtCBRubPreDic_Enabled!=0) ? context.localUtil.Format( A2307CBRubPreDic, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2307CBRubPreDic, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCBRubPreDic_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCBRubPreDic_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridcbpresupuestorubros_cbpresupuestorubrosdetRow);
         send_integrity_lvl_hashes7H206( ) ;
         GXCCtl = "Z2285CBRubPreAno_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2285CBRubPreAno), 4, 0, ".", "")));
         GXCCtl = "Z2296CBRubPreEne_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2296CBRubPreEne, 15, 2, ".", "")));
         GXCCtl = "Z2297CBRubPreFeb_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2297CBRubPreFeb, 15, 2, ".", "")));
         GXCCtl = "Z2298CBRubPreMar_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2298CBRubPreMar, 15, 2, ".", "")));
         GXCCtl = "Z2299CBRubPreAbr_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2299CBRubPreAbr, 15, 2, ".", "")));
         GXCCtl = "Z2300CBRubPreMay_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2300CBRubPreMay, 15, 2, ".", "")));
         GXCCtl = "Z2301CBRubPreJun_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2301CBRubPreJun, 15, 2, ".", "")));
         GXCCtl = "Z2302CBRubPreJul_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2302CBRubPreJul, 15, 2, ".", "")));
         GXCCtl = "Z2303CBRubPreAgo_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2303CBRubPreAgo, 15, 2, ".", "")));
         GXCCtl = "Z2304CBRubPreSep_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2304CBRubPreSep, 15, 2, ".", "")));
         GXCCtl = "Z2305CBRubPreOct_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2305CBRubPreOct, 15, 2, ".", "")));
         GXCCtl = "Z2306CBRubPreNov_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2306CBRubPreNov, 15, 2, ".", "")));
         GXCCtl = "Z2307CBRubPreDic_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2307CBRubPreDic, 15, 2, ".", "")));
         GXCCtl = "nRcdDeleted_206_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_206), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_206_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_206), 4, 0, ".", "")));
         GXCCtl = "nIsMod_206_" + sGXsfl_64_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_206), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREANO_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAno_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREENE_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreEne_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREFEB_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreFeb_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREMAR_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMar_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREABR_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAbr_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREMAY_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreMay_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREJUN_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJun_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREJUL_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreJul_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREAGO_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreAgo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPRESEP_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreSep_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREOCT_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreOct_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPRENOV_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreNov_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBRUBPREDIC_"+sGXsfl_64_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCBRubPreDic_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer.AddRow(Gridcbpresupuestorubros_cbpresupuestorubrosdetRow);
      }

      protected void ReadRow7H206( )
      {
         nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_64206( ) ;
         edtCBRubPreAno_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREANO_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreEne_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREENE_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreFeb_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREFEB_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreMar_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREMAR_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreAbr_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREABR_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreMay_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREMAY_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreJun_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREJUN_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreJul_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREJUL_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreAgo_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREAGO_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreSep_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPRESEP_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreOct_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREOCT_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreNov_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPRENOV_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         edtCBRubPreDic_Enabled = (int)(context.localUtil.CToN( cgiGet( "CBRUBPREDIC_"+sGXsfl_64_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CBRUBPREANO_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreAno_Internalname;
            wbErr = true;
            A2285CBRubPreAno = 0;
         }
         else
         {
            A2285CBRubPreAno = (short)(context.localUtil.CToN( cgiGet( edtCBRubPreAno_Internalname), ".", ","));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreEne_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreEne_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREENE_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreEne_Internalname;
            wbErr = true;
            A2296CBRubPreEne = 0;
         }
         else
         {
            A2296CBRubPreEne = context.localUtil.CToN( cgiGet( edtCBRubPreEne_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreFeb_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreFeb_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREFEB_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreFeb_Internalname;
            wbErr = true;
            A2297CBRubPreFeb = 0;
         }
         else
         {
            A2297CBRubPreFeb = context.localUtil.CToN( cgiGet( edtCBRubPreFeb_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreMar_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreMar_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREMAR_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreMar_Internalname;
            wbErr = true;
            A2298CBRubPreMar = 0;
         }
         else
         {
            A2298CBRubPreMar = context.localUtil.CToN( cgiGet( edtCBRubPreMar_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreAbr_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreAbr_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREABR_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreAbr_Internalname;
            wbErr = true;
            A2299CBRubPreAbr = 0;
         }
         else
         {
            A2299CBRubPreAbr = context.localUtil.CToN( cgiGet( edtCBRubPreAbr_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreMay_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreMay_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREMAY_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreMay_Internalname;
            wbErr = true;
            A2300CBRubPreMay = 0;
         }
         else
         {
            A2300CBRubPreMay = context.localUtil.CToN( cgiGet( edtCBRubPreMay_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreJun_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreJun_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREJUN_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreJun_Internalname;
            wbErr = true;
            A2301CBRubPreJun = 0;
         }
         else
         {
            A2301CBRubPreJun = context.localUtil.CToN( cgiGet( edtCBRubPreJun_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreJul_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreJul_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREJUL_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreJul_Internalname;
            wbErr = true;
            A2302CBRubPreJul = 0;
         }
         else
         {
            A2302CBRubPreJul = context.localUtil.CToN( cgiGet( edtCBRubPreJul_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreAgo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreAgo_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREAGO_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreAgo_Internalname;
            wbErr = true;
            A2303CBRubPreAgo = 0;
         }
         else
         {
            A2303CBRubPreAgo = context.localUtil.CToN( cgiGet( edtCBRubPreAgo_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreSep_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreSep_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPRESEP_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreSep_Internalname;
            wbErr = true;
            A2304CBRubPreSep = 0;
         }
         else
         {
            A2304CBRubPreSep = context.localUtil.CToN( cgiGet( edtCBRubPreSep_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreOct_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreOct_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREOCT_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreOct_Internalname;
            wbErr = true;
            A2305CBRubPreOct = 0;
         }
         else
         {
            A2305CBRubPreOct = context.localUtil.CToN( cgiGet( edtCBRubPreOct_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreNov_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreNov_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPRENOV_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreNov_Internalname;
            wbErr = true;
            A2306CBRubPreNov = 0;
         }
         else
         {
            A2306CBRubPreNov = context.localUtil.CToN( cgiGet( edtCBRubPreNov_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtCBRubPreDic_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBRubPreDic_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CBRUBPREDIC_" + sGXsfl_64_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCBRubPreDic_Internalname;
            wbErr = true;
            A2307CBRubPreDic = 0;
         }
         else
         {
            A2307CBRubPreDic = context.localUtil.CToN( cgiGet( edtCBRubPreDic_Internalname), ".", ",");
         }
         GXCCtl = "Z2285CBRubPreAno_" + sGXsfl_64_idx;
         Z2285CBRubPreAno = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z2296CBRubPreEne_" + sGXsfl_64_idx;
         Z2296CBRubPreEne = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2297CBRubPreFeb_" + sGXsfl_64_idx;
         Z2297CBRubPreFeb = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2298CBRubPreMar_" + sGXsfl_64_idx;
         Z2298CBRubPreMar = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2299CBRubPreAbr_" + sGXsfl_64_idx;
         Z2299CBRubPreAbr = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2300CBRubPreMay_" + sGXsfl_64_idx;
         Z2300CBRubPreMay = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2301CBRubPreJun_" + sGXsfl_64_idx;
         Z2301CBRubPreJun = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2302CBRubPreJul_" + sGXsfl_64_idx;
         Z2302CBRubPreJul = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2303CBRubPreAgo_" + sGXsfl_64_idx;
         Z2303CBRubPreAgo = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2304CBRubPreSep_" + sGXsfl_64_idx;
         Z2304CBRubPreSep = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2305CBRubPreOct_" + sGXsfl_64_idx;
         Z2305CBRubPreOct = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2306CBRubPreNov_" + sGXsfl_64_idx;
         Z2306CBRubPreNov = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2307CBRubPreDic_" + sGXsfl_64_idx;
         Z2307CBRubPreDic = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_206_" + sGXsfl_64_idx;
         nRcdDeleted_206 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_206_" + sGXsfl_64_idx;
         nRcdExists_206 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_206_" + sGXsfl_64_idx;
         nIsMod_206 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtCBRubPreAno_Enabled = edtCBRubPreAno_Enabled;
      }

      protected void ConfirmValues7H0( )
      {
         nGXsfl_64_idx = 0;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_64206( ) ;
         while ( nGXsfl_64_idx < nRC_GXsfl_64 )
         {
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_64206( ) ;
            ChangePostValue( "Z2285CBRubPreAno_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2285CBRubPreAno_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2285CBRubPreAno_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2296CBRubPreEne_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2296CBRubPreEne_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2296CBRubPreEne_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2297CBRubPreFeb_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2297CBRubPreFeb_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2297CBRubPreFeb_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2298CBRubPreMar_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2298CBRubPreMar_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2298CBRubPreMar_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2299CBRubPreAbr_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2299CBRubPreAbr_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2299CBRubPreAbr_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2300CBRubPreMay_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2300CBRubPreMay_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2300CBRubPreMay_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2301CBRubPreJun_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2301CBRubPreJun_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2301CBRubPreJun_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2302CBRubPreJul_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2302CBRubPreJul_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2302CBRubPreJul_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2303CBRubPreAgo_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2303CBRubPreAgo_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2303CBRubPreAgo_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2304CBRubPreSep_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2304CBRubPreSep_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2304CBRubPreSep_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2305CBRubPreOct_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2305CBRubPreOct_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2305CBRubPreOct_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2306CBRubPreNov_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2306CBRubPreNov_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2306CBRubPreNov_"+sGXsfl_64_idx) ;
            ChangePostValue( "Z2307CBRubPreDic_"+sGXsfl_64_idx, cgiGet( "ZT_"+"Z2307CBRubPreDic_"+sGXsfl_64_idx)) ;
            DeletePostValue( "ZT_"+"Z2307CBRubPreDic_"+sGXsfl_64_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271670", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbpresupuestorubros.aspx") +"\">") ;
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
         return formatLink("cbpresupuestorubros.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPRESUPUESTORUBROS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rubros de Presupuestos" ;
      }

      protected void InitializeNonKey7H205( )
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

      protected void InitAll7H205( )
      {
         A2280CBTipPre = 0;
         AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
         A2281CBTipTipo = "";
         AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
         A2282CBLinPre = 0;
         AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
         A2283CBRubPre = 0;
         AssignAttri("", false, "A2283CBRubPre", StringUtil.LTrimStr( (decimal)(A2283CBRubPre), 6, 0));
         InitializeNonKey7H205( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey7H206( )
      {
         A2296CBRubPreEne = 0;
         A2297CBRubPreFeb = 0;
         A2298CBRubPreMar = 0;
         A2299CBRubPreAbr = 0;
         A2300CBRubPreMay = 0;
         A2301CBRubPreJun = 0;
         A2302CBRubPreJul = 0;
         A2303CBRubPreAgo = 0;
         A2304CBRubPreSep = 0;
         A2305CBRubPreOct = 0;
         A2306CBRubPreNov = 0;
         A2307CBRubPreDic = 0;
         Z2296CBRubPreEne = 0;
         Z2297CBRubPreFeb = 0;
         Z2298CBRubPreMar = 0;
         Z2299CBRubPreAbr = 0;
         Z2300CBRubPreMay = 0;
         Z2301CBRubPreJun = 0;
         Z2302CBRubPreJul = 0;
         Z2303CBRubPreAgo = 0;
         Z2304CBRubPreSep = 0;
         Z2305CBRubPreOct = 0;
         Z2306CBRubPreNov = 0;
         Z2307CBRubPreDic = 0;
      }

      protected void InitAll7H206( )
      {
         A2285CBRubPreAno = 0;
         InitializeNonKey7H206( ) ;
      }

      protected void StandaloneModalInsert7H206( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271681", true, true);
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
         context.AddJavascriptSource("cbpresupuestorubros.js", "?202281810271681", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties206( )
      {
         edtCBRubPreAno_Enabled = defedtCBRubPreAno_Enabled;
         AssignProp("", false, edtCBRubPreAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBRubPreAno_Enabled), 5, 0), !bGXsfl_64_Refreshing);
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
         edtCBRubPreAno_Internalname = "CBRUBPREANO";
         edtCBRubPreEne_Internalname = "CBRUBPREENE";
         edtCBRubPreFeb_Internalname = "CBRUBPREFEB";
         edtCBRubPreMar_Internalname = "CBRUBPREMAR";
         edtCBRubPreAbr_Internalname = "CBRUBPREABR";
         edtCBRubPreMay_Internalname = "CBRUBPREMAY";
         edtCBRubPreJun_Internalname = "CBRUBPREJUN";
         edtCBRubPreJul_Internalname = "CBRUBPREJUL";
         edtCBRubPreAgo_Internalname = "CBRUBPREAGO";
         edtCBRubPreSep_Internalname = "CBRUBPRESEP";
         edtCBRubPreOct_Internalname = "CBRUBPREOCT";
         edtCBRubPreNov_Internalname = "CBRUBPRENOV";
         edtCBRubPreDic_Internalname = "CBRUBPREDIC";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Internalname = "GRIDCBPRESUPUESTORUBROS_CBPRESUPUESTORUBROSDET";
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
         Form.Caption = "Rubros de Presupuestos";
         edtCBRubPreDic_Jsonclick = "";
         edtCBRubPreNov_Jsonclick = "";
         edtCBRubPreOct_Jsonclick = "";
         edtCBRubPreSep_Jsonclick = "";
         edtCBRubPreAgo_Jsonclick = "";
         edtCBRubPreJul_Jsonclick = "";
         edtCBRubPreJun_Jsonclick = "";
         edtCBRubPreMay_Jsonclick = "";
         edtCBRubPreAbr_Jsonclick = "";
         edtCBRubPreMar_Jsonclick = "";
         edtCBRubPreFeb_Jsonclick = "";
         edtCBRubPreEne_Jsonclick = "";
         edtCBRubPreAno_Jsonclick = "";
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class = "Grid";
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle = 0;
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowcollapsing = 0;
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowselection = 0;
         edtCBRubPreDic_Enabled = 1;
         edtCBRubPreNov_Enabled = 1;
         edtCBRubPreOct_Enabled = 1;
         edtCBRubPreSep_Enabled = 1;
         edtCBRubPreAgo_Enabled = 1;
         edtCBRubPreJul_Enabled = 1;
         edtCBRubPreJun_Enabled = 1;
         edtCBRubPreMay_Enabled = 1;
         edtCBRubPreAbr_Enabled = 1;
         edtCBRubPreMar_Enabled = 1;
         edtCBRubPreFeb_Enabled = 1;
         edtCBRubPreEne_Enabled = 1;
         edtCBRubPreAno_Enabled = 1;
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Header = "";
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

      protected void gxnrGridcbpresupuestorubros_cbpresupuestorubrosdet_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_64206( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal7H206( ) ;
            standaloneModal7H206( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow7H206( ) ;
            nGXsfl_64_idx = (int)(nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_64206( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer)) ;
         /* End function gxnrGridcbpresupuestorubros_cbpresupuestorubrosdet_newrow */
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
         /* Using cursor T007H23 */
         pr_default.execute(21, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(21);
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
         /* Using cursor T007H23 */
         pr_default.execute(21, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Presupuesto'.", "ForeignKeyNotFound", 1, "CBLINPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
         }
         pr_default.close(21);
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
         setEventMetadata("VALID_CBRUBPREANO","{handler:'Valid_Cbrubpreano',iparms:[]");
         setEventMetadata("VALID_CBRUBPREANO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cbrubpredic',iparms:[]");
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
         pr_default.close(3);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2281CBTipTipo = "";
         Z2293CBRubPreDsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2281CBTipTipo = "";
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
         Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer = new GXWebGrid( context);
         Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn = new GXWebColumn();
         sMode206 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T007H7_A2283CBRubPre = new int[1] ;
         T007H7_A2293CBRubPreDsc = new string[] {""} ;
         T007H7_A2294CBRubPreSts = new short[1] ;
         T007H7_A2295CBRubTItem = new int[1] ;
         T007H7_A2280CBTipPre = new int[1] ;
         T007H7_A2281CBTipTipo = new string[] {""} ;
         T007H7_A2282CBLinPre = new int[1] ;
         T007H6_A2280CBTipPre = new int[1] ;
         T007H8_A2280CBTipPre = new int[1] ;
         T007H9_A2280CBTipPre = new int[1] ;
         T007H9_A2281CBTipTipo = new string[] {""} ;
         T007H9_A2282CBLinPre = new int[1] ;
         T007H9_A2283CBRubPre = new int[1] ;
         T007H5_A2283CBRubPre = new int[1] ;
         T007H5_A2293CBRubPreDsc = new string[] {""} ;
         T007H5_A2294CBRubPreSts = new short[1] ;
         T007H5_A2295CBRubTItem = new int[1] ;
         T007H5_A2280CBTipPre = new int[1] ;
         T007H5_A2281CBTipTipo = new string[] {""} ;
         T007H5_A2282CBLinPre = new int[1] ;
         sMode205 = "";
         T007H10_A2280CBTipPre = new int[1] ;
         T007H10_A2281CBTipTipo = new string[] {""} ;
         T007H10_A2282CBLinPre = new int[1] ;
         T007H10_A2283CBRubPre = new int[1] ;
         T007H11_A2280CBTipPre = new int[1] ;
         T007H11_A2281CBTipTipo = new string[] {""} ;
         T007H11_A2282CBLinPre = new int[1] ;
         T007H11_A2283CBRubPre = new int[1] ;
         T007H4_A2283CBRubPre = new int[1] ;
         T007H4_A2293CBRubPreDsc = new string[] {""} ;
         T007H4_A2294CBRubPreSts = new short[1] ;
         T007H4_A2295CBRubTItem = new int[1] ;
         T007H4_A2280CBTipPre = new int[1] ;
         T007H4_A2281CBTipTipo = new string[] {""} ;
         T007H4_A2282CBLinPre = new int[1] ;
         T007H15_A2280CBTipPre = new int[1] ;
         T007H15_A2281CBTipTipo = new string[] {""} ;
         T007H15_A2282CBLinPre = new int[1] ;
         T007H15_A2283CBRubPre = new int[1] ;
         T007H15_A2284CBRubDItem = new int[1] ;
         T007H16_A2280CBTipPre = new int[1] ;
         T007H16_A2281CBTipTipo = new string[] {""} ;
         T007H16_A2282CBLinPre = new int[1] ;
         T007H16_A2283CBRubPre = new int[1] ;
         T007H17_A2280CBTipPre = new int[1] ;
         T007H17_A2281CBTipTipo = new string[] {""} ;
         T007H17_A2282CBLinPre = new int[1] ;
         T007H17_A2283CBRubPre = new int[1] ;
         T007H17_A2285CBRubPreAno = new short[1] ;
         T007H17_A2296CBRubPreEne = new decimal[1] ;
         T007H17_A2297CBRubPreFeb = new decimal[1] ;
         T007H17_A2298CBRubPreMar = new decimal[1] ;
         T007H17_A2299CBRubPreAbr = new decimal[1] ;
         T007H17_A2300CBRubPreMay = new decimal[1] ;
         T007H17_A2301CBRubPreJun = new decimal[1] ;
         T007H17_A2302CBRubPreJul = new decimal[1] ;
         T007H17_A2303CBRubPreAgo = new decimal[1] ;
         T007H17_A2304CBRubPreSep = new decimal[1] ;
         T007H17_A2305CBRubPreOct = new decimal[1] ;
         T007H17_A2306CBRubPreNov = new decimal[1] ;
         T007H17_A2307CBRubPreDic = new decimal[1] ;
         T007H18_A2280CBTipPre = new int[1] ;
         T007H18_A2281CBTipTipo = new string[] {""} ;
         T007H18_A2282CBLinPre = new int[1] ;
         T007H18_A2283CBRubPre = new int[1] ;
         T007H18_A2285CBRubPreAno = new short[1] ;
         T007H3_A2280CBTipPre = new int[1] ;
         T007H3_A2281CBTipTipo = new string[] {""} ;
         T007H3_A2282CBLinPre = new int[1] ;
         T007H3_A2283CBRubPre = new int[1] ;
         T007H3_A2285CBRubPreAno = new short[1] ;
         T007H3_A2296CBRubPreEne = new decimal[1] ;
         T007H3_A2297CBRubPreFeb = new decimal[1] ;
         T007H3_A2298CBRubPreMar = new decimal[1] ;
         T007H3_A2299CBRubPreAbr = new decimal[1] ;
         T007H3_A2300CBRubPreMay = new decimal[1] ;
         T007H3_A2301CBRubPreJun = new decimal[1] ;
         T007H3_A2302CBRubPreJul = new decimal[1] ;
         T007H3_A2303CBRubPreAgo = new decimal[1] ;
         T007H3_A2304CBRubPreSep = new decimal[1] ;
         T007H3_A2305CBRubPreOct = new decimal[1] ;
         T007H3_A2306CBRubPreNov = new decimal[1] ;
         T007H3_A2307CBRubPreDic = new decimal[1] ;
         T007H2_A2280CBTipPre = new int[1] ;
         T007H2_A2281CBTipTipo = new string[] {""} ;
         T007H2_A2282CBLinPre = new int[1] ;
         T007H2_A2283CBRubPre = new int[1] ;
         T007H2_A2285CBRubPreAno = new short[1] ;
         T007H2_A2296CBRubPreEne = new decimal[1] ;
         T007H2_A2297CBRubPreFeb = new decimal[1] ;
         T007H2_A2298CBRubPreMar = new decimal[1] ;
         T007H2_A2299CBRubPreAbr = new decimal[1] ;
         T007H2_A2300CBRubPreMay = new decimal[1] ;
         T007H2_A2301CBRubPreJun = new decimal[1] ;
         T007H2_A2302CBRubPreJul = new decimal[1] ;
         T007H2_A2303CBRubPreAgo = new decimal[1] ;
         T007H2_A2304CBRubPreSep = new decimal[1] ;
         T007H2_A2305CBRubPreOct = new decimal[1] ;
         T007H2_A2306CBRubPreNov = new decimal[1] ;
         T007H2_A2307CBRubPreDic = new decimal[1] ;
         T007H22_A2280CBTipPre = new int[1] ;
         T007H22_A2281CBTipTipo = new string[] {""} ;
         T007H22_A2282CBLinPre = new int[1] ;
         T007H22_A2283CBRubPre = new int[1] ;
         T007H22_A2285CBRubPreAno = new short[1] ;
         Gridcbpresupuestorubros_cbpresupuestorubrosdetRow = new GXWebRow();
         subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007H23_A2280CBTipPre = new int[1] ;
         ZZ2281CBTipTipo = "";
         ZZ2293CBRubPreDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestorubros__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestorubros__default(),
            new Object[][] {
                new Object[] {
               T007H2_A2280CBTipPre, T007H2_A2281CBTipTipo, T007H2_A2282CBLinPre, T007H2_A2283CBRubPre, T007H2_A2285CBRubPreAno, T007H2_A2296CBRubPreEne, T007H2_A2297CBRubPreFeb, T007H2_A2298CBRubPreMar, T007H2_A2299CBRubPreAbr, T007H2_A2300CBRubPreMay,
               T007H2_A2301CBRubPreJun, T007H2_A2302CBRubPreJul, T007H2_A2303CBRubPreAgo, T007H2_A2304CBRubPreSep, T007H2_A2305CBRubPreOct, T007H2_A2306CBRubPreNov, T007H2_A2307CBRubPreDic
               }
               , new Object[] {
               T007H3_A2280CBTipPre, T007H3_A2281CBTipTipo, T007H3_A2282CBLinPre, T007H3_A2283CBRubPre, T007H3_A2285CBRubPreAno, T007H3_A2296CBRubPreEne, T007H3_A2297CBRubPreFeb, T007H3_A2298CBRubPreMar, T007H3_A2299CBRubPreAbr, T007H3_A2300CBRubPreMay,
               T007H3_A2301CBRubPreJun, T007H3_A2302CBRubPreJul, T007H3_A2303CBRubPreAgo, T007H3_A2304CBRubPreSep, T007H3_A2305CBRubPreOct, T007H3_A2306CBRubPreNov, T007H3_A2307CBRubPreDic
               }
               , new Object[] {
               T007H4_A2283CBRubPre, T007H4_A2293CBRubPreDsc, T007H4_A2294CBRubPreSts, T007H4_A2295CBRubTItem, T007H4_A2280CBTipPre, T007H4_A2281CBTipTipo, T007H4_A2282CBLinPre
               }
               , new Object[] {
               T007H5_A2283CBRubPre, T007H5_A2293CBRubPreDsc, T007H5_A2294CBRubPreSts, T007H5_A2295CBRubTItem, T007H5_A2280CBTipPre, T007H5_A2281CBTipTipo, T007H5_A2282CBLinPre
               }
               , new Object[] {
               T007H6_A2280CBTipPre
               }
               , new Object[] {
               T007H7_A2283CBRubPre, T007H7_A2293CBRubPreDsc, T007H7_A2294CBRubPreSts, T007H7_A2295CBRubTItem, T007H7_A2280CBTipPre, T007H7_A2281CBTipTipo, T007H7_A2282CBLinPre
               }
               , new Object[] {
               T007H8_A2280CBTipPre
               }
               , new Object[] {
               T007H9_A2280CBTipPre, T007H9_A2281CBTipTipo, T007H9_A2282CBLinPre, T007H9_A2283CBRubPre
               }
               , new Object[] {
               T007H10_A2280CBTipPre, T007H10_A2281CBTipTipo, T007H10_A2282CBLinPre, T007H10_A2283CBRubPre
               }
               , new Object[] {
               T007H11_A2280CBTipPre, T007H11_A2281CBTipTipo, T007H11_A2282CBLinPre, T007H11_A2283CBRubPre
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007H15_A2280CBTipPre, T007H15_A2281CBTipTipo, T007H15_A2282CBLinPre, T007H15_A2283CBRubPre, T007H15_A2284CBRubDItem
               }
               , new Object[] {
               T007H16_A2280CBTipPre, T007H16_A2281CBTipTipo, T007H16_A2282CBLinPre, T007H16_A2283CBRubPre
               }
               , new Object[] {
               T007H17_A2280CBTipPre, T007H17_A2281CBTipTipo, T007H17_A2282CBLinPre, T007H17_A2283CBRubPre, T007H17_A2285CBRubPreAno, T007H17_A2296CBRubPreEne, T007H17_A2297CBRubPreFeb, T007H17_A2298CBRubPreMar, T007H17_A2299CBRubPreAbr, T007H17_A2300CBRubPreMay,
               T007H17_A2301CBRubPreJun, T007H17_A2302CBRubPreJul, T007H17_A2303CBRubPreAgo, T007H17_A2304CBRubPreSep, T007H17_A2305CBRubPreOct, T007H17_A2306CBRubPreNov, T007H17_A2307CBRubPreDic
               }
               , new Object[] {
               T007H18_A2280CBTipPre, T007H18_A2281CBTipTipo, T007H18_A2282CBLinPre, T007H18_A2283CBRubPre, T007H18_A2285CBRubPreAno
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007H22_A2280CBTipPre, T007H22_A2281CBTipTipo, T007H22_A2282CBLinPre, T007H22_A2283CBRubPre, T007H22_A2285CBRubPreAno
               }
               , new Object[] {
               T007H23_A2280CBTipPre
               }
            }
         );
      }

      private short Z2294CBRubPreSts ;
      private short Z2285CBRubPreAno ;
      private short nRcdDeleted_206 ;
      private short nRcdExists_206 ;
      private short nIsMod_206 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2294CBRubPreSts ;
      private short subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolorstyle ;
      private short A2285CBRubPreAno ;
      private short subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowselection ;
      private short subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowhovering ;
      private short subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allowcollapsing ;
      private short subGridcbpresupuestorubros_cbpresupuestorubrosdet_Collapsed ;
      private short nBlankRcdCount206 ;
      private short RcdFound206 ;
      private short nBlankRcdUsr206 ;
      private short GX_JID ;
      private short RcdFound205 ;
      private short nIsDirty_205 ;
      private short Gx_BScreen ;
      private short nIsDirty_206 ;
      private short subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ2294CBRubPreSts ;
      private int Z2280CBTipPre ;
      private int Z2282CBLinPre ;
      private int Z2283CBRubPre ;
      private int Z2295CBRubTItem ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
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
      private int edtCBRubPreAno_Enabled ;
      private int edtCBRubPreEne_Enabled ;
      private int edtCBRubPreFeb_Enabled ;
      private int edtCBRubPreMar_Enabled ;
      private int edtCBRubPreAbr_Enabled ;
      private int edtCBRubPreMay_Enabled ;
      private int edtCBRubPreJun_Enabled ;
      private int edtCBRubPreJul_Enabled ;
      private int edtCBRubPreAgo_Enabled ;
      private int edtCBRubPreSep_Enabled ;
      private int edtCBRubPreOct_Enabled ;
      private int edtCBRubPreNov_Enabled ;
      private int edtCBRubPreDic_Enabled ;
      private int subGridcbpresupuestorubros_cbpresupuestorubrosdet_Selectedindex ;
      private int subGridcbpresupuestorubros_cbpresupuestorubrosdet_Selectioncolor ;
      private int subGridcbpresupuestorubros_cbpresupuestorubrosdet_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridcbpresupuestorubros_cbpresupuestorubrosdet_Backcolor ;
      private int subGridcbpresupuestorubros_cbpresupuestorubrosdet_Allbackcolor ;
      private int defedtCBRubPreAno_Enabled ;
      private int idxLst ;
      private int ZZ2280CBTipPre ;
      private int ZZ2282CBLinPre ;
      private int ZZ2283CBRubPre ;
      private int ZZ2295CBRubTItem ;
      private long GRIDCBPRESUPUESTORUBROS_CBPRESUPUESTORUBROSDET_nFirstRecordOnPage ;
      private decimal Z2296CBRubPreEne ;
      private decimal Z2297CBRubPreFeb ;
      private decimal Z2298CBRubPreMar ;
      private decimal Z2299CBRubPreAbr ;
      private decimal Z2300CBRubPreMay ;
      private decimal Z2301CBRubPreJun ;
      private decimal Z2302CBRubPreJul ;
      private decimal Z2303CBRubPreAgo ;
      private decimal Z2304CBRubPreSep ;
      private decimal Z2305CBRubPreOct ;
      private decimal Z2306CBRubPreNov ;
      private decimal Z2307CBRubPreDic ;
      private decimal A2296CBRubPreEne ;
      private decimal A2297CBRubPreFeb ;
      private decimal A2298CBRubPreMar ;
      private decimal A2299CBRubPreAbr ;
      private decimal A2300CBRubPreMay ;
      private decimal A2301CBRubPreJun ;
      private decimal A2302CBRubPreJul ;
      private decimal A2303CBRubPreAgo ;
      private decimal A2304CBRubPreSep ;
      private decimal A2305CBRubPreOct ;
      private decimal A2306CBRubPreNov ;
      private decimal A2307CBRubPreDic ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
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
      private string subGridcbpresupuestorubros_cbpresupuestorubrosdet_Header ;
      private string sMode206 ;
      private string edtCBRubPreAno_Internalname ;
      private string edtCBRubPreEne_Internalname ;
      private string edtCBRubPreFeb_Internalname ;
      private string edtCBRubPreMar_Internalname ;
      private string edtCBRubPreAbr_Internalname ;
      private string edtCBRubPreMay_Internalname ;
      private string edtCBRubPreJun_Internalname ;
      private string edtCBRubPreJul_Internalname ;
      private string edtCBRubPreAgo_Internalname ;
      private string edtCBRubPreSep_Internalname ;
      private string edtCBRubPreOct_Internalname ;
      private string edtCBRubPreNov_Internalname ;
      private string edtCBRubPreDic_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode205 ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGridcbpresupuestorubros_cbpresupuestorubrosdet_Class ;
      private string subGridcbpresupuestorubros_cbpresupuestorubrosdet_Linesclass ;
      private string ROClassString ;
      private string edtCBRubPreAno_Jsonclick ;
      private string edtCBRubPreEne_Jsonclick ;
      private string edtCBRubPreFeb_Jsonclick ;
      private string edtCBRubPreMar_Jsonclick ;
      private string edtCBRubPreAbr_Jsonclick ;
      private string edtCBRubPreMay_Jsonclick ;
      private string edtCBRubPreJun_Jsonclick ;
      private string edtCBRubPreJul_Jsonclick ;
      private string edtCBRubPreAgo_Jsonclick ;
      private string edtCBRubPreSep_Jsonclick ;
      private string edtCBRubPreOct_Jsonclick ;
      private string edtCBRubPreNov_Jsonclick ;
      private string edtCBRubPreDic_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcbpresupuestorubros_cbpresupuestorubrosdet_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool Gx_longc ;
      private string Z2281CBTipTipo ;
      private string Z2293CBRubPreDsc ;
      private string A2281CBTipTipo ;
      private string A2293CBRubPreDsc ;
      private string ZZ2281CBTipTipo ;
      private string ZZ2293CBRubPreDsc ;
      private GXWebGrid Gridcbpresupuestorubros_cbpresupuestorubrosdetContainer ;
      private GXWebRow Gridcbpresupuestorubros_cbpresupuestorubrosdetRow ;
      private GXWebColumn Gridcbpresupuestorubros_cbpresupuestorubrosdetColumn ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T007H7_A2283CBRubPre ;
      private string[] T007H7_A2293CBRubPreDsc ;
      private short[] T007H7_A2294CBRubPreSts ;
      private int[] T007H7_A2295CBRubTItem ;
      private int[] T007H7_A2280CBTipPre ;
      private string[] T007H7_A2281CBTipTipo ;
      private int[] T007H7_A2282CBLinPre ;
      private int[] T007H6_A2280CBTipPre ;
      private int[] T007H8_A2280CBTipPre ;
      private int[] T007H9_A2280CBTipPre ;
      private string[] T007H9_A2281CBTipTipo ;
      private int[] T007H9_A2282CBLinPre ;
      private int[] T007H9_A2283CBRubPre ;
      private int[] T007H5_A2283CBRubPre ;
      private string[] T007H5_A2293CBRubPreDsc ;
      private short[] T007H5_A2294CBRubPreSts ;
      private int[] T007H5_A2295CBRubTItem ;
      private int[] T007H5_A2280CBTipPre ;
      private string[] T007H5_A2281CBTipTipo ;
      private int[] T007H5_A2282CBLinPre ;
      private int[] T007H10_A2280CBTipPre ;
      private string[] T007H10_A2281CBTipTipo ;
      private int[] T007H10_A2282CBLinPre ;
      private int[] T007H10_A2283CBRubPre ;
      private int[] T007H11_A2280CBTipPre ;
      private string[] T007H11_A2281CBTipTipo ;
      private int[] T007H11_A2282CBLinPre ;
      private int[] T007H11_A2283CBRubPre ;
      private int[] T007H4_A2283CBRubPre ;
      private string[] T007H4_A2293CBRubPreDsc ;
      private short[] T007H4_A2294CBRubPreSts ;
      private int[] T007H4_A2295CBRubTItem ;
      private int[] T007H4_A2280CBTipPre ;
      private string[] T007H4_A2281CBTipTipo ;
      private int[] T007H4_A2282CBLinPre ;
      private int[] T007H15_A2280CBTipPre ;
      private string[] T007H15_A2281CBTipTipo ;
      private int[] T007H15_A2282CBLinPre ;
      private int[] T007H15_A2283CBRubPre ;
      private int[] T007H15_A2284CBRubDItem ;
      private int[] T007H16_A2280CBTipPre ;
      private string[] T007H16_A2281CBTipTipo ;
      private int[] T007H16_A2282CBLinPre ;
      private int[] T007H16_A2283CBRubPre ;
      private int[] T007H17_A2280CBTipPre ;
      private string[] T007H17_A2281CBTipTipo ;
      private int[] T007H17_A2282CBLinPre ;
      private int[] T007H17_A2283CBRubPre ;
      private short[] T007H17_A2285CBRubPreAno ;
      private decimal[] T007H17_A2296CBRubPreEne ;
      private decimal[] T007H17_A2297CBRubPreFeb ;
      private decimal[] T007H17_A2298CBRubPreMar ;
      private decimal[] T007H17_A2299CBRubPreAbr ;
      private decimal[] T007H17_A2300CBRubPreMay ;
      private decimal[] T007H17_A2301CBRubPreJun ;
      private decimal[] T007H17_A2302CBRubPreJul ;
      private decimal[] T007H17_A2303CBRubPreAgo ;
      private decimal[] T007H17_A2304CBRubPreSep ;
      private decimal[] T007H17_A2305CBRubPreOct ;
      private decimal[] T007H17_A2306CBRubPreNov ;
      private decimal[] T007H17_A2307CBRubPreDic ;
      private int[] T007H18_A2280CBTipPre ;
      private string[] T007H18_A2281CBTipTipo ;
      private int[] T007H18_A2282CBLinPre ;
      private int[] T007H18_A2283CBRubPre ;
      private short[] T007H18_A2285CBRubPreAno ;
      private int[] T007H3_A2280CBTipPre ;
      private string[] T007H3_A2281CBTipTipo ;
      private int[] T007H3_A2282CBLinPre ;
      private int[] T007H3_A2283CBRubPre ;
      private short[] T007H3_A2285CBRubPreAno ;
      private decimal[] T007H3_A2296CBRubPreEne ;
      private decimal[] T007H3_A2297CBRubPreFeb ;
      private decimal[] T007H3_A2298CBRubPreMar ;
      private decimal[] T007H3_A2299CBRubPreAbr ;
      private decimal[] T007H3_A2300CBRubPreMay ;
      private decimal[] T007H3_A2301CBRubPreJun ;
      private decimal[] T007H3_A2302CBRubPreJul ;
      private decimal[] T007H3_A2303CBRubPreAgo ;
      private decimal[] T007H3_A2304CBRubPreSep ;
      private decimal[] T007H3_A2305CBRubPreOct ;
      private decimal[] T007H3_A2306CBRubPreNov ;
      private decimal[] T007H3_A2307CBRubPreDic ;
      private int[] T007H2_A2280CBTipPre ;
      private string[] T007H2_A2281CBTipTipo ;
      private int[] T007H2_A2282CBLinPre ;
      private int[] T007H2_A2283CBRubPre ;
      private short[] T007H2_A2285CBRubPreAno ;
      private decimal[] T007H2_A2296CBRubPreEne ;
      private decimal[] T007H2_A2297CBRubPreFeb ;
      private decimal[] T007H2_A2298CBRubPreMar ;
      private decimal[] T007H2_A2299CBRubPreAbr ;
      private decimal[] T007H2_A2300CBRubPreMay ;
      private decimal[] T007H2_A2301CBRubPreJun ;
      private decimal[] T007H2_A2302CBRubPreJul ;
      private decimal[] T007H2_A2303CBRubPreAgo ;
      private decimal[] T007H2_A2304CBRubPreSep ;
      private decimal[] T007H2_A2305CBRubPreOct ;
      private decimal[] T007H2_A2306CBRubPreNov ;
      private decimal[] T007H2_A2307CBRubPreDic ;
      private int[] T007H22_A2280CBTipPre ;
      private string[] T007H22_A2281CBTipTipo ;
      private int[] T007H22_A2282CBLinPre ;
      private int[] T007H22_A2283CBRubPre ;
      private short[] T007H22_A2285CBRubPreAno ;
      private int[] T007H23_A2280CBTipPre ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbpresupuestorubros__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbpresupuestorubros__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007H7;
        prmT007H7 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H6;
        prmT007H6 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007H8;
        prmT007H8 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007H9;
        prmT007H9 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H5;
        prmT007H5 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H10;
        prmT007H10 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H11;
        prmT007H11 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H4;
        prmT007H4 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H12;
        prmT007H12 = new Object[] {
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBRubPreSts",GXType.Int16,1,0) ,
        new ParDef("@CBRubTItem",GXType.Int32,6,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007H13;
        prmT007H13 = new Object[] {
        new ParDef("@CBRubPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBRubPreSts",GXType.Int16,1,0) ,
        new ParDef("@CBRubTItem",GXType.Int32,6,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H14;
        prmT007H14 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H15;
        prmT007H15 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H16;
        prmT007H16 = new Object[] {
        };
        Object[] prmT007H17;
        prmT007H17 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0)
        };
        Object[] prmT007H18;
        prmT007H18 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0)
        };
        Object[] prmT007H3;
        prmT007H3 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0)
        };
        Object[] prmT007H2;
        prmT007H2 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0)
        };
        Object[] prmT007H19;
        prmT007H19 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0) ,
        new ParDef("@CBRubPreEne",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreFeb",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreMar",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreAbr",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreMay",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreJun",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreJul",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreAgo",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreSep",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreOct",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreNov",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreDic",GXType.Decimal,15,2)
        };
        Object[] prmT007H20;
        prmT007H20 = new Object[] {
        new ParDef("@CBRubPreEne",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreFeb",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreMar",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreAbr",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreMay",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreJun",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreJul",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreAgo",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreSep",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreOct",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreNov",GXType.Decimal,15,2) ,
        new ParDef("@CBRubPreDic",GXType.Decimal,15,2) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0)
        };
        Object[] prmT007H21;
        prmT007H21 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPreAno",GXType.Int16,4,0)
        };
        Object[] prmT007H22;
        prmT007H22 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBRubPre",GXType.Int32,6,0)
        };
        Object[] prmT007H23;
        prmT007H23 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007H2", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic] FROM [CBPRESUPUESTORUBROSDET] WITH (UPDLOCK) WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubPreAno] = @CBRubPreAno ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H3", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubPreAno] = @CBRubPreAno ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H4", "SELECT [CBRubPre], [CBRubPreDsc], [CBRubPreSts], [CBRubTItem], [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTORUBROS] WITH (UPDLOCK) WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H5", "SELECT [CBRubPre], [CBRubPreDsc], [CBRubPreSts], [CBRubTItem], [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H6", "SELECT [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H7", "SELECT TM1.[CBRubPre], TM1.[CBRubPreDsc], TM1.[CBRubPreSts], TM1.[CBRubTItem], TM1.[CBTipPre], TM1.[CBTipTipo], TM1.[CBLinPre] FROM [CBPRESUPUESTORUBROS] TM1 WHERE TM1.[CBTipPre] = @CBTipPre and TM1.[CBTipTipo] = @CBTipTipo and TM1.[CBLinPre] = @CBLinPre and TM1.[CBRubPre] = @CBRubPre ORDER BY TM1.[CBTipPre], TM1.[CBTipTipo], TM1.[CBLinPre], TM1.[CBRubPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007H7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H8", "SELECT [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H9", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H10", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE ( [CBTipPre] > @CBTipPre or [CBTipPre] = @CBTipPre and [CBTipTipo] > @CBTipTipo or [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBLinPre] > @CBLinPre or [CBLinPre] = @CBLinPre and [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBRubPre] > @CBRubPre) ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007H10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007H11", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE ( [CBTipPre] < @CBTipPre or [CBTipPre] = @CBTipPre and [CBTipTipo] < @CBTipTipo or [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBLinPre] < @CBLinPre or [CBLinPre] = @CBLinPre and [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBRubPre] < @CBRubPre) ORDER BY [CBTipPre] DESC, [CBTipTipo] DESC, [CBLinPre] DESC, [CBRubPre] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007H12", "INSERT INTO [CBPRESUPUESTORUBROS]([CBRubPre], [CBRubPreDsc], [CBRubPreSts], [CBRubTItem], [CBTipPre], [CBTipTipo], [CBLinPre]) VALUES(@CBRubPre, @CBRubPreDsc, @CBRubPreSts, @CBRubTItem, @CBTipPre, @CBTipTipo, @CBLinPre)", GxErrorMask.GX_NOMASK,prmT007H12)
           ,new CursorDef("T007H13", "UPDATE [CBPRESUPUESTORUBROS] SET [CBRubPreDsc]=@CBRubPreDsc, [CBRubPreSts]=@CBRubPreSts, [CBRubTItem]=@CBRubTItem  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre", GxErrorMask.GX_NOMASK,prmT007H13)
           ,new CursorDef("T007H14", "DELETE FROM [CBPRESUPUESTORUBROS]  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre", GxErrorMask.GX_NOMASK,prmT007H14)
           ,new CursorDef("T007H15", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007H16", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007H16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H17", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @CBTipPre and [CBTipTipo] = @CBTipTipo and [CBLinPre] = @CBLinPre and [CBRubPre] = @CBRubPre and [CBRubPreAno] = @CBRubPreAno ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H18", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubPreAno] = @CBRubPreAno ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H19", "INSERT INTO [CBPRESUPUESTORUBROSDET]([CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic]) VALUES(@CBTipPre, @CBTipTipo, @CBLinPre, @CBRubPre, @CBRubPreAno, @CBRubPreEne, @CBRubPreFeb, @CBRubPreMar, @CBRubPreAbr, @CBRubPreMay, @CBRubPreJun, @CBRubPreJul, @CBRubPreAgo, @CBRubPreSep, @CBRubPreOct, @CBRubPreNov, @CBRubPreDic)", GxErrorMask.GX_NOMASK,prmT007H19)
           ,new CursorDef("T007H20", "UPDATE [CBPRESUPUESTORUBROSDET] SET [CBRubPreEne]=@CBRubPreEne, [CBRubPreFeb]=@CBRubPreFeb, [CBRubPreMar]=@CBRubPreMar, [CBRubPreAbr]=@CBRubPreAbr, [CBRubPreMay]=@CBRubPreMay, [CBRubPreJun]=@CBRubPreJun, [CBRubPreJul]=@CBRubPreJul, [CBRubPreAgo]=@CBRubPreAgo, [CBRubPreSep]=@CBRubPreSep, [CBRubPreOct]=@CBRubPreOct, [CBRubPreNov]=@CBRubPreNov, [CBRubPreDic]=@CBRubPreDic  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubPreAno] = @CBRubPreAno", GxErrorMask.GX_NOMASK,prmT007H20)
           ,new CursorDef("T007H21", "DELETE FROM [CBPRESUPUESTORUBROSDET]  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre AND [CBRubPre] = @CBRubPre AND [CBRubPreAno] = @CBRubPreAno", GxErrorMask.GX_NOMASK,prmT007H21)
           ,new CursorDef("T007H22", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @CBTipPre and [CBTipTipo] = @CBTipTipo and [CBLinPre] = @CBLinPre and [CBRubPre] = @CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H22,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007H23", "SELECT [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007H23,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 14 :
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
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
