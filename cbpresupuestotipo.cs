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
   public class cbpresupuestotipo : GXDataArea
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
            A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A180MonCod) ;
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
            Form.Meta.addItem("description", "Tipo de Presupuesto", 0) ;
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

      public cbpresupuestotipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbpresupuestotipo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tipo de Presupuesto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPRESUPUESTOTIPO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPRESUPUESTOTIPO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBTipPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2280CBTipPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBTipPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBTipPreDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBTipPreDsc_Internalname, "de Presupuesto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBTipPreDsc_Internalname, A2291CBTipPreDsc, StringUtil.RTrim( context.localUtil.Format( A2291CBTipPreDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipPreDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipPreDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBTipPreSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBTipPreSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBTipPreSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2292CBTipPreSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBTipPreSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2292CBTipPreSts), "9") : context.localUtil.Format( (decimal)(A2292CBTipPreSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipPreSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipPreSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonCod_Internalname, "Codigo Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTOTIPO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOTIPO.htm");
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
            Z2280CBTipPre = (int)(context.localUtil.CToN( cgiGet( "Z2280CBTipPre"), ".", ","));
            Z2291CBTipPreDsc = cgiGet( "Z2291CBTipPreDsc");
            Z2292CBTipPreSts = (short)(context.localUtil.CToN( cgiGet( "Z2292CBTipPreSts"), ".", ","));
            Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
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
            A2291CBTipPreDsc = cgiGet( edtCBTipPreDsc_Internalname);
            AssignAttri("", false, "A2291CBTipPreDsc", A2291CBTipPreDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBTipPreSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBTipPreSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBTIPPRESTS");
               AnyError = 1;
               GX_FocusControl = edtCBTipPreSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2292CBTipPreSts = 0;
               AssignAttri("", false, "A2292CBTipPreSts", StringUtil.Str( (decimal)(A2292CBTipPreSts), 1, 0));
            }
            else
            {
               A2292CBTipPreSts = (short)(context.localUtil.CToN( cgiGet( edtCBTipPreSts_Internalname), ".", ","));
               AssignAttri("", false, "A2292CBTipPreSts", StringUtil.Str( (decimal)(A2292CBTipPreSts), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONCOD");
               AnyError = 1;
               GX_FocusControl = edtMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A180MonCod = 0;
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            else
            {
               A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
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
               A2280CBTipPre = (int)(NumberUtil.Val( GetPar( "CBTipPre"), "."));
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
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
               InitAll7J208( ) ;
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
         DisableAttributes7J208( ) ;
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

      protected void ResetCaption7J0( )
      {
      }

      protected void ZM7J208( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2291CBTipPreDsc = T007J3_A2291CBTipPreDsc[0];
               Z2292CBTipPreSts = T007J3_A2292CBTipPreSts[0];
               Z180MonCod = T007J3_A180MonCod[0];
            }
            else
            {
               Z2291CBTipPreDsc = A2291CBTipPreDsc;
               Z2292CBTipPreSts = A2292CBTipPreSts;
               Z180MonCod = A180MonCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2280CBTipPre = A2280CBTipPre;
            Z2291CBTipPreDsc = A2291CBTipPreDsc;
            Z2292CBTipPreSts = A2292CBTipPreSts;
            Z180MonCod = A180MonCod;
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

      protected void Load7J208( )
      {
         /* Using cursor T007J5 */
         pr_default.execute(3, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound208 = 1;
            A2291CBTipPreDsc = T007J5_A2291CBTipPreDsc[0];
            AssignAttri("", false, "A2291CBTipPreDsc", A2291CBTipPreDsc);
            A2292CBTipPreSts = T007J5_A2292CBTipPreSts[0];
            AssignAttri("", false, "A2292CBTipPreSts", StringUtil.Str( (decimal)(A2292CBTipPreSts), 1, 0));
            A180MonCod = T007J5_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            ZM7J208( -1) ;
         }
         pr_default.close(3);
         OnLoadActions7J208( ) ;
      }

      protected void OnLoadActions7J208( )
      {
      }

      protected void CheckExtendedTable7J208( )
      {
         nIsDirty_208 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007J4 */
         pr_default.execute(2, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7J208( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A180MonCod )
      {
         /* Using cursor T007J6 */
         pr_default.execute(4, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
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

      protected void GetKey7J208( )
      {
         /* Using cursor T007J7 */
         pr_default.execute(5, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound208 = 1;
         }
         else
         {
            RcdFound208 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007J3 */
         pr_default.execute(1, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7J208( 1) ;
            RcdFound208 = 1;
            A2280CBTipPre = T007J3_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2291CBTipPreDsc = T007J3_A2291CBTipPreDsc[0];
            AssignAttri("", false, "A2291CBTipPreDsc", A2291CBTipPreDsc);
            A2292CBTipPreSts = T007J3_A2292CBTipPreSts[0];
            AssignAttri("", false, "A2292CBTipPreSts", StringUtil.Str( (decimal)(A2292CBTipPreSts), 1, 0));
            A180MonCod = T007J3_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            Z2280CBTipPre = A2280CBTipPre;
            sMode208 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7J208( ) ;
            if ( AnyError == 1 )
            {
               RcdFound208 = 0;
               InitializeNonKey7J208( ) ;
            }
            Gx_mode = sMode208;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound208 = 0;
            InitializeNonKey7J208( ) ;
            sMode208 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode208;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7J208( ) ;
         if ( RcdFound208 == 0 )
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
         RcdFound208 = 0;
         /* Using cursor T007J8 */
         pr_default.execute(6, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T007J8_A2280CBTipPre[0] < A2280CBTipPre ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T007J8_A2280CBTipPre[0] > A2280CBTipPre ) ) )
            {
               A2280CBTipPre = T007J8_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               RcdFound208 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound208 = 0;
         /* Using cursor T007J9 */
         pr_default.execute(7, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T007J9_A2280CBTipPre[0] > A2280CBTipPre ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T007J9_A2280CBTipPre[0] < A2280CBTipPre ) ) )
            {
               A2280CBTipPre = T007J9_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               RcdFound208 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7J208( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7J208( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound208 == 1 )
            {
               if ( A2280CBTipPre != Z2280CBTipPre )
               {
                  A2280CBTipPre = Z2280CBTipPre;
                  AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
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
                  Update7J208( ) ;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2280CBTipPre != Z2280CBTipPre )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7J208( ) ;
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
                     Insert7J208( ) ;
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
         if ( A2280CBTipPre != Z2280CBTipPre )
         {
            A2280CBTipPre = Z2280CBTipPre;
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
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
         if ( RcdFound208 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBTipPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7J208( ) ;
         if ( RcdFound208 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBTipPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7J208( ) ;
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
         if ( RcdFound208 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBTipPreDsc_Internalname;
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
         if ( RcdFound208 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBTipPreDsc_Internalname;
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
         ScanStart7J208( ) ;
         if ( RcdFound208 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound208 != 0 )
            {
               ScanNext7J208( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBTipPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7J208( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7J208( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007J2 */
            pr_default.execute(0, new Object[] {A2280CBTipPre});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTOTIPO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2291CBTipPreDsc, T007J2_A2291CBTipPreDsc[0]) != 0 ) || ( Z2292CBTipPreSts != T007J2_A2292CBTipPreSts[0] ) || ( Z180MonCod != T007J2_A180MonCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z2291CBTipPreDsc, T007J2_A2291CBTipPreDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbpresupuestotipo:[seudo value changed for attri]"+"CBTipPreDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2291CBTipPreDsc);
                  GXUtil.WriteLogRaw("Current: ",T007J2_A2291CBTipPreDsc[0]);
               }
               if ( Z2292CBTipPreSts != T007J2_A2292CBTipPreSts[0] )
               {
                  GXUtil.WriteLog("cbpresupuestotipo:[seudo value changed for attri]"+"CBTipPreSts");
                  GXUtil.WriteLogRaw("Old: ",Z2292CBTipPreSts);
                  GXUtil.WriteLogRaw("Current: ",T007J2_A2292CBTipPreSts[0]);
               }
               if ( Z180MonCod != T007J2_A180MonCod[0] )
               {
                  GXUtil.WriteLog("cbpresupuestotipo:[seudo value changed for attri]"+"MonCod");
                  GXUtil.WriteLogRaw("Old: ",Z180MonCod);
                  GXUtil.WriteLogRaw("Current: ",T007J2_A180MonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPRESUPUESTOTIPO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7J208( )
      {
         BeforeValidate7J208( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7J208( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7J208( 0) ;
            CheckOptimisticConcurrency7J208( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7J208( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7J208( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007J10 */
                     pr_default.execute(8, new Object[] {A2280CBTipPre, A2291CBTipPreDsc, A2292CBTipPreSts, A180MonCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTOTIPO");
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
                           ResetCaption7J0( ) ;
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
               Load7J208( ) ;
            }
            EndLevel7J208( ) ;
         }
         CloseExtendedTableCursors7J208( ) ;
      }

      protected void Update7J208( )
      {
         BeforeValidate7J208( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7J208( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7J208( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7J208( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7J208( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007J11 */
                     pr_default.execute(9, new Object[] {A2291CBTipPreDsc, A2292CBTipPreSts, A180MonCod, A2280CBTipPre});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTOTIPO");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTOTIPO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7J208( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7J0( ) ;
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
            EndLevel7J208( ) ;
         }
         CloseExtendedTableCursors7J208( ) ;
      }

      protected void DeferredUpdate7J208( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7J208( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7J208( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7J208( ) ;
            AfterConfirm7J208( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7J208( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007J12 */
                  pr_default.execute(10, new Object[] {A2280CBTipPre});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTOTIPO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound208 == 0 )
                        {
                           InitAll7J208( ) ;
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
                        ResetCaption7J0( ) ;
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
         sMode208 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7J208( ) ;
         Gx_mode = sMode208;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7J208( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007J13 */
            pr_default.execute(11, new Object[] {A2280CBTipPre});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Presupuesto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel7J208( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7J208( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbpresupuestotipo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbpresupuestotipo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7J208( )
      {
         /* Using cursor T007J14 */
         pr_default.execute(12);
         RcdFound208 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound208 = 1;
            A2280CBTipPre = T007J14_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7J208( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound208 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound208 = 1;
            A2280CBTipPre = T007J14_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
         }
      }

      protected void ScanEnd7J208( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm7J208( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7J208( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7J208( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7J208( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7J208( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7J208( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7J208( )
      {
         edtCBTipPre_Enabled = 0;
         AssignProp("", false, edtCBTipPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipPre_Enabled), 5, 0), true);
         edtCBTipPreDsc_Enabled = 0;
         AssignProp("", false, edtCBTipPreDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipPreDsc_Enabled), 5, 0), true);
         edtCBTipPreSts_Enabled = 0;
         AssignProp("", false, edtCBTipPreSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipPreSts_Enabled), 5, 0), true);
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7J208( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271721", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbpresupuestotipo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2291CBTipPreDsc", Z2291CBTipPreDsc);
         GxWebStd.gx_hidden_field( context, "Z2292CBTipPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2292CBTipPreSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
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
         return formatLink("cbpresupuestotipo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPRESUPUESTOTIPO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Presupuesto" ;
      }

      protected void InitializeNonKey7J208( )
      {
         A2291CBTipPreDsc = "";
         AssignAttri("", false, "A2291CBTipPreDsc", A2291CBTipPreDsc);
         A2292CBTipPreSts = 0;
         AssignAttri("", false, "A2292CBTipPreSts", StringUtil.Str( (decimal)(A2292CBTipPreSts), 1, 0));
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         Z2291CBTipPreDsc = "";
         Z2292CBTipPreSts = 0;
         Z180MonCod = 0;
      }

      protected void InitAll7J208( )
      {
         A2280CBTipPre = 0;
         AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
         InitializeNonKey7J208( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271726", true, true);
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
         context.AddJavascriptSource("cbpresupuestotipo.js", "?202281810271727", false, true);
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
         edtCBTipPre_Internalname = "CBTIPPRE";
         edtCBTipPreDsc_Internalname = "CBTIPPREDSC";
         edtCBTipPreSts_Internalname = "CBTIPPRESTS";
         edtMonCod_Internalname = "MONCOD";
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
         Form.Caption = "Tipo de Presupuesto";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
         edtCBTipPreSts_Jsonclick = "";
         edtCBTipPreSts_Enabled = 1;
         edtCBTipPreDsc_Jsonclick = "";
         edtCBTipPreDsc_Enabled = 1;
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

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCBTipPreDsc_Internalname;
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

      public void Valid_Cbtippre( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2291CBTipPreDsc", A2291CBTipPreDsc);
         AssignAttri("", false, "A2292CBTipPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2292CBTipPreSts), 1, 0, ".", "")));
         AssignAttri("", false, "A180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2280CBTipPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2280CBTipPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2291CBTipPreDsc", Z2291CBTipPreDsc);
         GxWebStd.gx_hidden_field( context, "Z2292CBTipPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2292CBTipPreSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Moncod( )
      {
         /* Using cursor T007J15 */
         pr_default.execute(13, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_CBTIPPRE","{handler:'Valid_Cbtippre',iparms:[{av:'A2280CBTipPre',fld:'CBTIPPRE',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBTIPPRE",",oparms:[{av:'A2291CBTipPreDsc',fld:'CBTIPPREDSC',pic:''},{av:'A2292CBTipPreSts',fld:'CBTIPPRESTS',pic:'9'},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2280CBTipPre'},{av:'Z2291CBTipPreDsc'},{av:'Z2292CBTipPreSts'},{av:'Z180MonCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2291CBTipPreDsc = "";
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
         A2291CBTipPreDsc = "";
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
         T007J5_A2280CBTipPre = new int[1] ;
         T007J5_A2291CBTipPreDsc = new string[] {""} ;
         T007J5_A2292CBTipPreSts = new short[1] ;
         T007J5_A180MonCod = new int[1] ;
         T007J4_A180MonCod = new int[1] ;
         T007J6_A180MonCod = new int[1] ;
         T007J7_A2280CBTipPre = new int[1] ;
         T007J3_A2280CBTipPre = new int[1] ;
         T007J3_A2291CBTipPreDsc = new string[] {""} ;
         T007J3_A2292CBTipPreSts = new short[1] ;
         T007J3_A180MonCod = new int[1] ;
         sMode208 = "";
         T007J8_A2280CBTipPre = new int[1] ;
         T007J9_A2280CBTipPre = new int[1] ;
         T007J2_A2280CBTipPre = new int[1] ;
         T007J2_A2291CBTipPreDsc = new string[] {""} ;
         T007J2_A2292CBTipPreSts = new short[1] ;
         T007J2_A180MonCod = new int[1] ;
         T007J13_A2280CBTipPre = new int[1] ;
         T007J13_A2281CBTipTipo = new string[] {""} ;
         T007J13_A2282CBLinPre = new int[1] ;
         T007J14_A2280CBTipPre = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2291CBTipPreDsc = "";
         T007J15_A180MonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestotipo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestotipo__default(),
            new Object[][] {
                new Object[] {
               T007J2_A2280CBTipPre, T007J2_A2291CBTipPreDsc, T007J2_A2292CBTipPreSts, T007J2_A180MonCod
               }
               , new Object[] {
               T007J3_A2280CBTipPre, T007J3_A2291CBTipPreDsc, T007J3_A2292CBTipPreSts, T007J3_A180MonCod
               }
               , new Object[] {
               T007J4_A180MonCod
               }
               , new Object[] {
               T007J5_A2280CBTipPre, T007J5_A2291CBTipPreDsc, T007J5_A2292CBTipPreSts, T007J5_A180MonCod
               }
               , new Object[] {
               T007J6_A180MonCod
               }
               , new Object[] {
               T007J7_A2280CBTipPre
               }
               , new Object[] {
               T007J8_A2280CBTipPre
               }
               , new Object[] {
               T007J9_A2280CBTipPre
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007J13_A2280CBTipPre, T007J13_A2281CBTipTipo, T007J13_A2282CBLinPre
               }
               , new Object[] {
               T007J14_A2280CBTipPre
               }
               , new Object[] {
               T007J15_A180MonCod
               }
            }
         );
      }

      private short Z2292CBTipPreSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2292CBTipPreSts ;
      private short GX_JID ;
      private short RcdFound208 ;
      private short nIsDirty_208 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2292CBTipPreSts ;
      private int Z2280CBTipPre ;
      private int Z180MonCod ;
      private int A180MonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A2280CBTipPre ;
      private int edtCBTipPre_Enabled ;
      private int edtCBTipPreDsc_Enabled ;
      private int edtCBTipPreSts_Enabled ;
      private int edtMonCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2280CBTipPre ;
      private int ZZ180MonCod ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
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
      private string edtCBTipPreDsc_Internalname ;
      private string edtCBTipPreDsc_Jsonclick ;
      private string edtCBTipPreSts_Internalname ;
      private string edtCBTipPreSts_Jsonclick ;
      private string edtMonCod_Internalname ;
      private string edtMonCod_Jsonclick ;
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
      private string sMode208 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z2291CBTipPreDsc ;
      private string A2291CBTipPreDsc ;
      private string ZZ2291CBTipPreDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T007J5_A2280CBTipPre ;
      private string[] T007J5_A2291CBTipPreDsc ;
      private short[] T007J5_A2292CBTipPreSts ;
      private int[] T007J5_A180MonCod ;
      private int[] T007J4_A180MonCod ;
      private int[] T007J6_A180MonCod ;
      private int[] T007J7_A2280CBTipPre ;
      private int[] T007J3_A2280CBTipPre ;
      private string[] T007J3_A2291CBTipPreDsc ;
      private short[] T007J3_A2292CBTipPreSts ;
      private int[] T007J3_A180MonCod ;
      private int[] T007J8_A2280CBTipPre ;
      private int[] T007J9_A2280CBTipPre ;
      private int[] T007J2_A2280CBTipPre ;
      private string[] T007J2_A2291CBTipPreDsc ;
      private short[] T007J2_A2292CBTipPreSts ;
      private int[] T007J2_A180MonCod ;
      private int[] T007J13_A2280CBTipPre ;
      private string[] T007J13_A2281CBTipTipo ;
      private int[] T007J13_A2282CBLinPre ;
      private int[] T007J14_A2280CBTipPre ;
      private int[] T007J15_A180MonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbpresupuestotipo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbpresupuestotipo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007J5;
        prmT007J5 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J4;
        prmT007J4 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT007J6;
        prmT007J6 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT007J7;
        prmT007J7 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J3;
        prmT007J3 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J8;
        prmT007J8 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J9;
        prmT007J9 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J2;
        prmT007J2 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J10;
        prmT007J10 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBTipPreSts",GXType.Int16,1,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT007J11;
        prmT007J11 = new Object[] {
        new ParDef("@CBTipPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBTipPreSts",GXType.Int16,1,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J12;
        prmT007J12 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J13;
        prmT007J13 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007J14;
        prmT007J14 = new Object[] {
        };
        Object[] prmT007J15;
        prmT007J15 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007J2", "SELECT [CBTipPre], [CBTipPreDsc], [CBTipPreSts], [MonCod] FROM [CBPRESUPUESTOTIPO] WITH (UPDLOCK) WHERE [CBTipPre] = @CBTipPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J3", "SELECT [CBTipPre], [CBTipPreDsc], [CBTipPreSts], [MonCod] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @CBTipPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J4", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J5", "SELECT TM1.[CBTipPre], TM1.[CBTipPreDsc], TM1.[CBTipPreSts], TM1.[MonCod] FROM [CBPRESUPUESTOTIPO] TM1 WHERE TM1.[CBTipPre] = @CBTipPre ORDER BY TM1.[CBTipPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007J5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J6", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007J6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J7", "SELECT [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @CBTipPre  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J8", "SELECT TOP 1 [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE ( [CBTipPre] > @CBTipPre) ORDER BY [CBTipPre]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007J8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007J9", "SELECT TOP 1 [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE ( [CBTipPre] < @CBTipPre) ORDER BY [CBTipPre] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007J9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007J10", "INSERT INTO [CBPRESUPUESTOTIPO]([CBTipPre], [CBTipPreDsc], [CBTipPreSts], [MonCod]) VALUES(@CBTipPre, @CBTipPreDsc, @CBTipPreSts, @MonCod)", GxErrorMask.GX_NOMASK,prmT007J10)
           ,new CursorDef("T007J11", "UPDATE [CBPRESUPUESTOTIPO] SET [CBTipPreDsc]=@CBTipPreDsc, [CBTipPreSts]=@CBTipPreSts, [MonCod]=@MonCod  WHERE [CBTipPre] = @CBTipPre", GxErrorMask.GX_NOMASK,prmT007J11)
           ,new CursorDef("T007J12", "DELETE FROM [CBPRESUPUESTOTIPO]  WHERE [CBTipPre] = @CBTipPre", GxErrorMask.GX_NOMASK,prmT007J12)
           ,new CursorDef("T007J13", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007J13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007J14", "SELECT [CBTipPre] FROM [CBPRESUPUESTOTIPO] ORDER BY [CBTipPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007J14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007J15", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007J15,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
