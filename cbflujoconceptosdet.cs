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
   public class cbflujoconceptosdet : GXDataArea
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
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
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
            gxLoad_3( A2269CBFlujTip, A2270CBFlujCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A2269CBFlujTip = GetPar( "CBFlujTip");
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = GetPar( "CBFlujCod");
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2271CBFlujCCod = GetPar( "CBFlujCCod");
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A79COSCod = GetPar( "COSCod");
            AssignAttri("", false, "A79COSCod", A79COSCod);
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
            Form.Meta.addItem("description", "CBFLUJOCONCEPTOSDET", 0) ;
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

      public cbflujoconceptosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbflujoconceptosdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CBFLUJOCONCEPTOSDET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2263CBFlujCAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2263CBFlujCAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2263CBFlujCAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2264CBFlujCMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2264CBFlujCMes), "Z9") : context.localUtil.Format( (decimal)(A2264CBFlujCMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2265CBFlujCBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2265CBFlujCBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2265CBFlujCBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCCuenta_Internalname, StringUtil.RTrim( A2266CBFlujCCuenta), StringUtil.RTrim( context.localUtil.Format( A2266CBFlujCCuenta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCCuenta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCCuenta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCRegistro_Internalname, StringUtil.RTrim( A2267CBFlujCRegistro), StringUtil.RTrim( context.localUtil.Format( A2267CBFlujCRegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCRegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2268CBFlujCItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBFlujCItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A2268CBFlujCItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2268CBFlujCItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujTip_Internalname, StringUtil.RTrim( A2269CBFlujTip), StringUtil.RTrim( context.localUtil.Format( A2269CBFlujTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCod_Internalname, StringUtil.RTrim( A2270CBFlujCod), StringUtil.RTrim( context.localUtil.Format( A2270CBFlujCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujDsc_Internalname, StringUtil.RTrim( A2277CBFlujDsc), StringUtil.RTrim( context.localUtil.Format( A2277CBFlujDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCCod_Internalname, StringUtil.RTrim( A2271CBFlujCCod), StringUtil.RTrim( context.localUtil.Format( A2271CBFlujCCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCBFlujCDsc_Internalname, StringUtil.RTrim( A2276CBFlujCDsc), StringUtil.RTrim( context.localUtil.Format( A2276CBFlujCDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSCod_Internalname, "Codigo de C.Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod), StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBFlujCCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBFlujCCosto_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBFlujCCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A2275CBFlujCCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBFlujCCosto_Enabled!=0) ? context.localUtil.Format( A2275CBFlujCCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2275CBFlujCCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBFlujCCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBFlujCCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBFLUJOCONCEPTOSDET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBFLUJOCONCEPTOSDET.htm");
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
            Z2268CBFlujCItem = (int)(context.localUtil.CToN( cgiGet( "Z2268CBFlujCItem"), ".", ","));
            Z2275CBFlujCCosto = context.localUtil.CToN( cgiGet( "Z2275CBFlujCCosto"), ".", ",");
            Z2269CBFlujTip = cgiGet( "Z2269CBFlujTip");
            Z2270CBFlujCod = cgiGet( "Z2270CBFlujCod");
            Z2271CBFlujCCod = cgiGet( "Z2271CBFlujCCod");
            Z79COSCod = cgiGet( "Z79COSCod");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCITEM");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2268CBFlujCItem = 0;
               AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
            }
            else
            {
               A2268CBFlujCItem = (int)(context.localUtil.CToN( cgiGet( edtCBFlujCItem_Internalname), ".", ","));
               AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
            }
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
            A79COSCod = cgiGet( edtCOSCod_Internalname);
            AssignAttri("", false, "A79COSCod", A79COSCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBFlujCCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBFlujCCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBFLUJCCOSTO");
               AnyError = 1;
               GX_FocusControl = edtCBFlujCCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2275CBFlujCCosto = 0;
               AssignAttri("", false, "A2275CBFlujCCosto", StringUtil.LTrimStr( A2275CBFlujCCosto, 15, 2));
            }
            else
            {
               A2275CBFlujCCosto = context.localUtil.CToN( cgiGet( edtCBFlujCCosto_Internalname), ".", ",");
               AssignAttri("", false, "A2275CBFlujCCosto", StringUtil.LTrimStr( A2275CBFlujCCosto, 15, 2));
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
               A2268CBFlujCItem = (int)(NumberUtil.Val( GetPar( "CBFlujCItem"), "."));
               AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
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
               InitAll7D201( ) ;
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
         DisableAttributes7D201( ) ;
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

      protected void ResetCaption7D0( )
      {
      }

      protected void ZM7D201( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2275CBFlujCCosto = T007D3_A2275CBFlujCCosto[0];
               Z2269CBFlujTip = T007D3_A2269CBFlujTip[0];
               Z2270CBFlujCod = T007D3_A2270CBFlujCod[0];
               Z2271CBFlujCCod = T007D3_A2271CBFlujCCod[0];
               Z79COSCod = T007D3_A79COSCod[0];
            }
            else
            {
               Z2275CBFlujCCosto = A2275CBFlujCCosto;
               Z2269CBFlujTip = A2269CBFlujTip;
               Z2270CBFlujCod = A2270CBFlujCod;
               Z2271CBFlujCCod = A2271CBFlujCCod;
               Z79COSCod = A79COSCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2268CBFlujCItem = A2268CBFlujCItem;
            Z2275CBFlujCCosto = A2275CBFlujCCosto;
            Z2263CBFlujCAno = A2263CBFlujCAno;
            Z2264CBFlujCMes = A2264CBFlujCMes;
            Z2265CBFlujCBanCod = A2265CBFlujCBanCod;
            Z2266CBFlujCCuenta = A2266CBFlujCCuenta;
            Z2267CBFlujCRegistro = A2267CBFlujCRegistro;
            Z2269CBFlujTip = A2269CBFlujTip;
            Z2270CBFlujCod = A2270CBFlujCod;
            Z2271CBFlujCCod = A2271CBFlujCCod;
            Z79COSCod = A79COSCod;
            Z2277CBFlujDsc = A2277CBFlujDsc;
            Z2276CBFlujCDsc = A2276CBFlujCDsc;
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

      protected void Load7D201( )
      {
         /* Using cursor T007D8 */
         pr_default.execute(6, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound201 = 1;
            A2277CBFlujDsc = T007D8_A2277CBFlujDsc[0];
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            A2276CBFlujCDsc = T007D8_A2276CBFlujCDsc[0];
            AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
            A2275CBFlujCCosto = T007D8_A2275CBFlujCCosto[0];
            AssignAttri("", false, "A2275CBFlujCCosto", StringUtil.LTrimStr( A2275CBFlujCCosto, 15, 2));
            A2269CBFlujTip = T007D8_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007D8_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2271CBFlujCCod = T007D8_A2271CBFlujCCod[0];
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
            A79COSCod = T007D8_A79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            ZM7D201( -1) ;
         }
         pr_default.close(6);
         OnLoadActions7D201( ) ;
      }

      protected void OnLoadActions7D201( )
      {
      }

      protected void CheckExtendedTable7D201( )
      {
         nIsDirty_201 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007D4 */
         pr_default.execute(2, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Flujo Conceptos Cabecera'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T007D5 */
         pr_default.execute(3, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2277CBFlujDsc = T007D5_A2277CBFlujDsc[0];
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         pr_default.close(3);
         /* Using cursor T007D6 */
         pr_default.execute(4, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Flujo de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2276CBFlujCDsc = T007D6_A2276CBFlujCDsc[0];
         AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
         pr_default.close(4);
         /* Using cursor T007D7 */
         pr_default.execute(5, new Object[] {A79COSCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors7D201( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A2263CBFlujCAno ,
                               short A2264CBFlujCMes ,
                               int A2265CBFlujCBanCod ,
                               string A2266CBFlujCCuenta ,
                               string A2267CBFlujCRegistro )
      {
         /* Using cursor T007D9 */
         pr_default.execute(7, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Flujo Conceptos Cabecera'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_3( string A2269CBFlujTip ,
                               string A2270CBFlujCod )
      {
         /* Using cursor T007D10 */
         pr_default.execute(8, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2277CBFlujDsc = T007D10_A2277CBFlujDsc[0];
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2277CBFlujDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_4( string A2269CBFlujTip ,
                               string A2270CBFlujCod ,
                               string A2271CBFlujCCod )
      {
         /* Using cursor T007D11 */
         pr_default.execute(9, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Flujo de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2276CBFlujCDsc = T007D11_A2276CBFlujCDsc[0];
         AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2276CBFlujCDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_5( string A79COSCod )
      {
         /* Using cursor T007D12 */
         pr_default.execute(10, new Object[] {A79COSCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey7D201( )
      {
         /* Using cursor T007D13 */
         pr_default.execute(11, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound201 = 1;
         }
         else
         {
            RcdFound201 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007D3 */
         pr_default.execute(1, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7D201( 1) ;
            RcdFound201 = 1;
            A2268CBFlujCItem = T007D3_A2268CBFlujCItem[0];
            AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
            A2275CBFlujCCosto = T007D3_A2275CBFlujCCosto[0];
            AssignAttri("", false, "A2275CBFlujCCosto", StringUtil.LTrimStr( A2275CBFlujCCosto, 15, 2));
            A2263CBFlujCAno = T007D3_A2263CBFlujCAno[0];
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = T007D3_A2264CBFlujCMes[0];
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2265CBFlujCBanCod = T007D3_A2265CBFlujCBanCod[0];
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = T007D3_A2266CBFlujCCuenta[0];
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = T007D3_A2267CBFlujCRegistro[0];
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            A2269CBFlujTip = T007D3_A2269CBFlujTip[0];
            AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
            A2270CBFlujCod = T007D3_A2270CBFlujCod[0];
            AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
            A2271CBFlujCCod = T007D3_A2271CBFlujCCod[0];
            AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
            A79COSCod = T007D3_A79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            Z2263CBFlujCAno = A2263CBFlujCAno;
            Z2264CBFlujCMes = A2264CBFlujCMes;
            Z2265CBFlujCBanCod = A2265CBFlujCBanCod;
            Z2266CBFlujCCuenta = A2266CBFlujCCuenta;
            Z2267CBFlujCRegistro = A2267CBFlujCRegistro;
            Z2268CBFlujCItem = A2268CBFlujCItem;
            sMode201 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7D201( ) ;
            if ( AnyError == 1 )
            {
               RcdFound201 = 0;
               InitializeNonKey7D201( ) ;
            }
            Gx_mode = sMode201;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound201 = 0;
            InitializeNonKey7D201( ) ;
            sMode201 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode201;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7D201( ) ;
         if ( RcdFound201 == 0 )
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
         RcdFound201 = 0;
         /* Using cursor T007D14 */
         pr_default.execute(12, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T007D14_A2263CBFlujCAno[0] < A2263CBFlujCAno ) || ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D14_A2264CBFlujCMes[0] < A2264CBFlujCMes ) || ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D14_A2265CBFlujCBanCod[0] < A2265CBFlujCBanCod ) || ( T007D14_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D14_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) < 0 ) || ( StringUtil.StrCmp(T007D14_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D14_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D14_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) < 0 ) || ( StringUtil.StrCmp(T007D14_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) == 0 ) && ( StringUtil.StrCmp(T007D14_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D14_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D14_A2268CBFlujCItem[0] < A2268CBFlujCItem ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T007D14_A2263CBFlujCAno[0] > A2263CBFlujCAno ) || ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D14_A2264CBFlujCMes[0] > A2264CBFlujCMes ) || ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D14_A2265CBFlujCBanCod[0] > A2265CBFlujCBanCod ) || ( T007D14_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D14_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) > 0 ) || ( StringUtil.StrCmp(T007D14_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D14_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D14_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) > 0 ) || ( StringUtil.StrCmp(T007D14_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) == 0 ) && ( StringUtil.StrCmp(T007D14_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D14_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D14_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D14_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D14_A2268CBFlujCItem[0] > A2268CBFlujCItem ) ) )
            {
               A2263CBFlujCAno = T007D14_A2263CBFlujCAno[0];
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
               A2264CBFlujCMes = T007D14_A2264CBFlujCMes[0];
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
               A2265CBFlujCBanCod = T007D14_A2265CBFlujCBanCod[0];
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
               A2266CBFlujCCuenta = T007D14_A2266CBFlujCCuenta[0];
               AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
               A2267CBFlujCRegistro = T007D14_A2267CBFlujCRegistro[0];
               AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
               A2268CBFlujCItem = T007D14_A2268CBFlujCItem[0];
               AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
               RcdFound201 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound201 = 0;
         /* Using cursor T007D15 */
         pr_default.execute(13, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T007D15_A2263CBFlujCAno[0] > A2263CBFlujCAno ) || ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D15_A2264CBFlujCMes[0] > A2264CBFlujCMes ) || ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D15_A2265CBFlujCBanCod[0] > A2265CBFlujCBanCod ) || ( T007D15_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D15_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) > 0 ) || ( StringUtil.StrCmp(T007D15_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D15_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D15_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) > 0 ) || ( StringUtil.StrCmp(T007D15_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) == 0 ) && ( StringUtil.StrCmp(T007D15_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D15_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D15_A2268CBFlujCItem[0] > A2268CBFlujCItem ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T007D15_A2263CBFlujCAno[0] < A2263CBFlujCAno ) || ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D15_A2264CBFlujCMes[0] < A2264CBFlujCMes ) || ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D15_A2265CBFlujCBanCod[0] < A2265CBFlujCBanCod ) || ( T007D15_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D15_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) < 0 ) || ( StringUtil.StrCmp(T007D15_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D15_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( StringUtil.StrCmp(T007D15_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) < 0 ) || ( StringUtil.StrCmp(T007D15_A2267CBFlujCRegistro[0], A2267CBFlujCRegistro) == 0 ) && ( StringUtil.StrCmp(T007D15_A2266CBFlujCCuenta[0], A2266CBFlujCCuenta) == 0 ) && ( T007D15_A2265CBFlujCBanCod[0] == A2265CBFlujCBanCod ) && ( T007D15_A2264CBFlujCMes[0] == A2264CBFlujCMes ) && ( T007D15_A2263CBFlujCAno[0] == A2263CBFlujCAno ) && ( T007D15_A2268CBFlujCItem[0] < A2268CBFlujCItem ) ) )
            {
               A2263CBFlujCAno = T007D15_A2263CBFlujCAno[0];
               AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
               A2264CBFlujCMes = T007D15_A2264CBFlujCMes[0];
               AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
               A2265CBFlujCBanCod = T007D15_A2265CBFlujCBanCod[0];
               AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
               A2266CBFlujCCuenta = T007D15_A2266CBFlujCCuenta[0];
               AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
               A2267CBFlujCRegistro = T007D15_A2267CBFlujCRegistro[0];
               AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
               A2268CBFlujCItem = T007D15_A2268CBFlujCItem[0];
               AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
               RcdFound201 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7D201( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7D201( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound201 == 1 )
            {
               if ( ( A2263CBFlujCAno != Z2263CBFlujCAno ) || ( A2264CBFlujCMes != Z2264CBFlujCMes ) || ( A2265CBFlujCBanCod != Z2265CBFlujCBanCod ) || ( StringUtil.StrCmp(A2266CBFlujCCuenta, Z2266CBFlujCCuenta) != 0 ) || ( StringUtil.StrCmp(A2267CBFlujCRegistro, Z2267CBFlujCRegistro) != 0 ) || ( A2268CBFlujCItem != Z2268CBFlujCItem ) )
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
                  A2268CBFlujCItem = Z2268CBFlujCItem;
                  AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
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
                  Update7D201( ) ;
                  GX_FocusControl = edtCBFlujCAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2263CBFlujCAno != Z2263CBFlujCAno ) || ( A2264CBFlujCMes != Z2264CBFlujCMes ) || ( A2265CBFlujCBanCod != Z2265CBFlujCBanCod ) || ( StringUtil.StrCmp(A2266CBFlujCCuenta, Z2266CBFlujCCuenta) != 0 ) || ( StringUtil.StrCmp(A2267CBFlujCRegistro, Z2267CBFlujCRegistro) != 0 ) || ( A2268CBFlujCItem != Z2268CBFlujCItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBFlujCAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7D201( ) ;
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
                     Insert7D201( ) ;
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
         if ( ( A2263CBFlujCAno != Z2263CBFlujCAno ) || ( A2264CBFlujCMes != Z2264CBFlujCMes ) || ( A2265CBFlujCBanCod != Z2265CBFlujCBanCod ) || ( StringUtil.StrCmp(A2266CBFlujCCuenta, Z2266CBFlujCCuenta) != 0 ) || ( StringUtil.StrCmp(A2267CBFlujCRegistro, Z2267CBFlujCRegistro) != 0 ) || ( A2268CBFlujCItem != Z2268CBFlujCItem ) )
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
            A2268CBFlujCItem = Z2268CBFlujCItem;
            AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
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
         if ( RcdFound201 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBFLUJCANO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBFlujTip_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7D201( ) ;
         if ( RcdFound201 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujTip_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7D201( ) ;
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
         if ( RcdFound201 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujTip_Internalname;
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
         if ( RcdFound201 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujTip_Internalname;
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
         ScanStart7D201( ) ;
         if ( RcdFound201 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound201 != 0 )
            {
               ScanNext7D201( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBFlujTip_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7D201( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7D201( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007D2 */
            pr_default.execute(0, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2275CBFlujCCosto != T007D2_A2275CBFlujCCosto[0] ) || ( StringUtil.StrCmp(Z2269CBFlujTip, T007D2_A2269CBFlujTip[0]) != 0 ) || ( StringUtil.StrCmp(Z2270CBFlujCod, T007D2_A2270CBFlujCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2271CBFlujCCod, T007D2_A2271CBFlujCCod[0]) != 0 ) || ( StringUtil.StrCmp(Z79COSCod, T007D2_A79COSCod[0]) != 0 ) )
            {
               if ( Z2275CBFlujCCosto != T007D2_A2275CBFlujCCosto[0] )
               {
                  GXUtil.WriteLog("cbflujoconceptosdet:[seudo value changed for attri]"+"CBFlujCCosto");
                  GXUtil.WriteLogRaw("Old: ",Z2275CBFlujCCosto);
                  GXUtil.WriteLogRaw("Current: ",T007D2_A2275CBFlujCCosto[0]);
               }
               if ( StringUtil.StrCmp(Z2269CBFlujTip, T007D2_A2269CBFlujTip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbflujoconceptosdet:[seudo value changed for attri]"+"CBFlujTip");
                  GXUtil.WriteLogRaw("Old: ",Z2269CBFlujTip);
                  GXUtil.WriteLogRaw("Current: ",T007D2_A2269CBFlujTip[0]);
               }
               if ( StringUtil.StrCmp(Z2270CBFlujCod, T007D2_A2270CBFlujCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbflujoconceptosdet:[seudo value changed for attri]"+"CBFlujCod");
                  GXUtil.WriteLogRaw("Old: ",Z2270CBFlujCod);
                  GXUtil.WriteLogRaw("Current: ",T007D2_A2270CBFlujCod[0]);
               }
               if ( StringUtil.StrCmp(Z2271CBFlujCCod, T007D2_A2271CBFlujCCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbflujoconceptosdet:[seudo value changed for attri]"+"CBFlujCCod");
                  GXUtil.WriteLogRaw("Old: ",Z2271CBFlujCCod);
                  GXUtil.WriteLogRaw("Current: ",T007D2_A2271CBFlujCCod[0]);
               }
               if ( StringUtil.StrCmp(Z79COSCod, T007D2_A79COSCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbflujoconceptosdet:[seudo value changed for attri]"+"COSCod");
                  GXUtil.WriteLogRaw("Old: ",Z79COSCod);
                  GXUtil.WriteLogRaw("Current: ",T007D2_A79COSCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7D201( )
      {
         BeforeValidate7D201( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7D201( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7D201( 0) ;
            CheckOptimisticConcurrency7D201( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7D201( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7D201( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007D16 */
                     pr_default.execute(14, new Object[] {A2268CBFlujCItem, A2275CBFlujCCosto, A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod, A79COSCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOCONCEPTOSDET");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption7D0( ) ;
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
               Load7D201( ) ;
            }
            EndLevel7D201( ) ;
         }
         CloseExtendedTableCursors7D201( ) ;
      }

      protected void Update7D201( )
      {
         BeforeValidate7D201( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7D201( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7D201( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7D201( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7D201( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007D17 */
                     pr_default.execute(15, new Object[] {A2275CBFlujCCosto, A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod, A79COSCod, A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOCONCEPTOSDET");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7D201( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7D0( ) ;
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
            EndLevel7D201( ) ;
         }
         CloseExtendedTableCursors7D201( ) ;
      }

      protected void DeferredUpdate7D201( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7D201( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7D201( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7D201( ) ;
            AfterConfirm7D201( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7D201( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007D18 */
                  pr_default.execute(16, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro, A2268CBFlujCItem});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CBFLUJOCONCEPTOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound201 == 0 )
                        {
                           InitAll7D201( ) ;
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
                        ResetCaption7D0( ) ;
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
         sMode201 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7D201( ) ;
         Gx_mode = sMode201;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7D201( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007D19 */
            pr_default.execute(17, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
            A2277CBFlujDsc = T007D19_A2277CBFlujDsc[0];
            AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
            pr_default.close(17);
            /* Using cursor T007D20 */
            pr_default.execute(18, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
            A2276CBFlujCDsc = T007D20_A2276CBFlujCDsc[0];
            AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
            pr_default.close(18);
         }
      }

      protected void EndLevel7D201( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7D201( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            context.CommitDataStores("cbflujoconceptosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            context.RollbackDataStores("cbflujoconceptosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7D201( )
      {
         /* Using cursor T007D21 */
         pr_default.execute(19);
         RcdFound201 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound201 = 1;
            A2263CBFlujCAno = T007D21_A2263CBFlujCAno[0];
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = T007D21_A2264CBFlujCMes[0];
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2265CBFlujCBanCod = T007D21_A2265CBFlujCBanCod[0];
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = T007D21_A2266CBFlujCCuenta[0];
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = T007D21_A2267CBFlujCRegistro[0];
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            A2268CBFlujCItem = T007D21_A2268CBFlujCItem[0];
            AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7D201( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound201 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound201 = 1;
            A2263CBFlujCAno = T007D21_A2263CBFlujCAno[0];
            AssignAttri("", false, "A2263CBFlujCAno", StringUtil.LTrimStr( (decimal)(A2263CBFlujCAno), 4, 0));
            A2264CBFlujCMes = T007D21_A2264CBFlujCMes[0];
            AssignAttri("", false, "A2264CBFlujCMes", StringUtil.LTrimStr( (decimal)(A2264CBFlujCMes), 2, 0));
            A2265CBFlujCBanCod = T007D21_A2265CBFlujCBanCod[0];
            AssignAttri("", false, "A2265CBFlujCBanCod", StringUtil.LTrimStr( (decimal)(A2265CBFlujCBanCod), 6, 0));
            A2266CBFlujCCuenta = T007D21_A2266CBFlujCCuenta[0];
            AssignAttri("", false, "A2266CBFlujCCuenta", A2266CBFlujCCuenta);
            A2267CBFlujCRegistro = T007D21_A2267CBFlujCRegistro[0];
            AssignAttri("", false, "A2267CBFlujCRegistro", A2267CBFlujCRegistro);
            A2268CBFlujCItem = T007D21_A2268CBFlujCItem[0];
            AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
         }
      }

      protected void ScanEnd7D201( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm7D201( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7D201( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7D201( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7D201( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7D201( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7D201( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7D201( )
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
         edtCBFlujCItem_Enabled = 0;
         AssignProp("", false, edtCBFlujCItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCItem_Enabled), 5, 0), true);
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
         edtCOSCod_Enabled = 0;
         AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         edtCBFlujCCosto_Enabled = 0;
         AssignProp("", false, edtCBFlujCCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBFlujCCosto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7D201( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7D0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027941", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbflujoconceptosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2268CBFlujCItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2268CBFlujCItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2275CBFlujCCosto", StringUtil.LTrim( StringUtil.NToC( Z2275CBFlujCCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2269CBFlujTip", StringUtil.RTrim( Z2269CBFlujTip));
         GxWebStd.gx_hidden_field( context, "Z2270CBFlujCod", StringUtil.RTrim( Z2270CBFlujCod));
         GxWebStd.gx_hidden_field( context, "Z2271CBFlujCCod", StringUtil.RTrim( Z2271CBFlujCCod));
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
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
         return formatLink("cbflujoconceptosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBFLUJOCONCEPTOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "CBFLUJOCONCEPTOSDET" ;
      }

      protected void InitializeNonKey7D201( )
      {
         A2269CBFlujTip = "";
         AssignAttri("", false, "A2269CBFlujTip", A2269CBFlujTip);
         A2270CBFlujCod = "";
         AssignAttri("", false, "A2270CBFlujCod", A2270CBFlujCod);
         A2277CBFlujDsc = "";
         AssignAttri("", false, "A2277CBFlujDsc", A2277CBFlujDsc);
         A2271CBFlujCCod = "";
         AssignAttri("", false, "A2271CBFlujCCod", A2271CBFlujCCod);
         A2276CBFlujCDsc = "";
         AssignAttri("", false, "A2276CBFlujCDsc", A2276CBFlujCDsc);
         A79COSCod = "";
         AssignAttri("", false, "A79COSCod", A79COSCod);
         A2275CBFlujCCosto = 0;
         AssignAttri("", false, "A2275CBFlujCCosto", StringUtil.LTrimStr( A2275CBFlujCCosto, 15, 2));
         Z2275CBFlujCCosto = 0;
         Z2269CBFlujTip = "";
         Z2270CBFlujCod = "";
         Z2271CBFlujCCod = "";
         Z79COSCod = "";
      }

      protected void InitAll7D201( )
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
         A2268CBFlujCItem = 0;
         AssignAttri("", false, "A2268CBFlujCItem", StringUtil.LTrimStr( (decimal)(A2268CBFlujCItem), 6, 0));
         InitializeNonKey7D201( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027950", true, true);
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
         context.AddJavascriptSource("cbflujoconceptosdet.js", "?20228181027950", false, true);
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
         edtCBFlujCItem_Internalname = "CBFLUJCITEM";
         edtCBFlujTip_Internalname = "CBFLUJTIP";
         edtCBFlujCod_Internalname = "CBFLUJCOD";
         edtCBFlujDsc_Internalname = "CBFLUJDSC";
         edtCBFlujCCod_Internalname = "CBFLUJCCOD";
         edtCBFlujCDsc_Internalname = "CBFLUJCDSC";
         edtCOSCod_Internalname = "COSCOD";
         edtCBFlujCCosto_Internalname = "CBFLUJCCOSTO";
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
         Form.Caption = "CBFLUJOCONCEPTOSDET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBFlujCCosto_Jsonclick = "";
         edtCBFlujCCosto_Enabled = 1;
         edtCOSCod_Jsonclick = "";
         edtCOSCod_Enabled = 1;
         edtCBFlujCDsc_Jsonclick = "";
         edtCBFlujCDsc_Enabled = 0;
         edtCBFlujCCod_Jsonclick = "";
         edtCBFlujCCod_Enabled = 1;
         edtCBFlujDsc_Jsonclick = "";
         edtCBFlujDsc_Enabled = 0;
         edtCBFlujCod_Jsonclick = "";
         edtCBFlujCod_Enabled = 1;
         edtCBFlujTip_Jsonclick = "";
         edtCBFlujTip_Enabled = 1;
         edtCBFlujCItem_Jsonclick = "";
         edtCBFlujCItem_Enabled = 1;
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
         /* Using cursor T007D22 */
         pr_default.execute(20, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Flujo Conceptos Cabecera'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
         GX_FocusControl = edtCBFlujTip_Internalname;
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

      public void Valid_Cbflujcregistro( )
      {
         /* Using cursor T007D22 */
         pr_default.execute(20, new Object[] {A2263CBFlujCAno, A2264CBFlujCMes, A2265CBFlujCBanCod, A2266CBFlujCCuenta, A2267CBFlujCRegistro});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Flujo Conceptos Cabecera'.", "ForeignKeyNotFound", 1, "CBFLUJCREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtCBFlujCAno_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cbflujcitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2269CBFlujTip", StringUtil.RTrim( A2269CBFlujTip));
         AssignAttri("", false, "A2270CBFlujCod", StringUtil.RTrim( A2270CBFlujCod));
         AssignAttri("", false, "A2271CBFlujCCod", StringUtil.RTrim( A2271CBFlujCCod));
         AssignAttri("", false, "A79COSCod", StringUtil.RTrim( A79COSCod));
         AssignAttri("", false, "A2275CBFlujCCosto", StringUtil.LTrim( StringUtil.NToC( A2275CBFlujCCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A2277CBFlujDsc", StringUtil.RTrim( A2277CBFlujDsc));
         AssignAttri("", false, "A2276CBFlujCDsc", StringUtil.RTrim( A2276CBFlujCDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2263CBFlujCAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2263CBFlujCAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2264CBFlujCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2264CBFlujCMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2265CBFlujCBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2265CBFlujCBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2266CBFlujCCuenta", StringUtil.RTrim( Z2266CBFlujCCuenta));
         GxWebStd.gx_hidden_field( context, "Z2267CBFlujCRegistro", StringUtil.RTrim( Z2267CBFlujCRegistro));
         GxWebStd.gx_hidden_field( context, "Z2268CBFlujCItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2268CBFlujCItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2269CBFlujTip", StringUtil.RTrim( Z2269CBFlujTip));
         GxWebStd.gx_hidden_field( context, "Z2270CBFlujCod", StringUtil.RTrim( Z2270CBFlujCod));
         GxWebStd.gx_hidden_field( context, "Z2271CBFlujCCod", StringUtil.RTrim( Z2271CBFlujCCod));
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z2275CBFlujCCosto", StringUtil.LTrim( StringUtil.NToC( Z2275CBFlujCCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2277CBFlujDsc", StringUtil.RTrim( Z2277CBFlujDsc));
         GxWebStd.gx_hidden_field( context, "Z2276CBFlujCDsc", StringUtil.RTrim( Z2276CBFlujCDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cbflujcod( )
      {
         /* Using cursor T007D19 */
         pr_default.execute(17, new Object[] {A2269CBFlujTip, A2270CBFlujCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Titulos Flujos de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
         }
         A2277CBFlujDsc = T007D19_A2277CBFlujDsc[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2277CBFlujDsc", StringUtil.RTrim( A2277CBFlujDsc));
      }

      public void Valid_Cbflujccod( )
      {
         /* Using cursor T007D20 */
         pr_default.execute(18, new Object[] {A2269CBFlujTip, A2270CBFlujCod, A2271CBFlujCCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Flujo de Caja'.", "ForeignKeyNotFound", 1, "CBFLUJCCOD");
            AnyError = 1;
            GX_FocusControl = edtCBFlujTip_Internalname;
         }
         A2276CBFlujCDsc = T007D20_A2276CBFlujCDsc[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2276CBFlujCDsc", StringUtil.RTrim( A2276CBFlujCDsc));
      }

      public void Valid_Coscod( )
      {
         /* Using cursor T007D23 */
         pr_default.execute(21, new Object[] {A79COSCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
         }
         pr_default.close(21);
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
         setEventMetadata("VALID_CBFLUJCANO","{handler:'Valid_Cbflujcano',iparms:[]");
         setEventMetadata("VALID_CBFLUJCANO",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCMES","{handler:'Valid_Cbflujcmes',iparms:[]");
         setEventMetadata("VALID_CBFLUJCMES",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCBANCOD","{handler:'Valid_Cbflujcbancod',iparms:[]");
         setEventMetadata("VALID_CBFLUJCBANCOD",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCCUENTA","{handler:'Valid_Cbflujccuenta',iparms:[]");
         setEventMetadata("VALID_CBFLUJCCUENTA",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCREGISTRO","{handler:'Valid_Cbflujcregistro',iparms:[{av:'A2263CBFlujCAno',fld:'CBFLUJCANO',pic:'ZZZ9'},{av:'A2264CBFlujCMes',fld:'CBFLUJCMES',pic:'Z9'},{av:'A2265CBFlujCBanCod',fld:'CBFLUJCBANCOD',pic:'ZZZZZ9'},{av:'A2266CBFlujCCuenta',fld:'CBFLUJCCUENTA',pic:''},{av:'A2267CBFlujCRegistro',fld:'CBFLUJCREGISTRO',pic:''}]");
         setEventMetadata("VALID_CBFLUJCREGISTRO",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCITEM","{handler:'Valid_Cbflujcitem',iparms:[{av:'A2263CBFlujCAno',fld:'CBFLUJCANO',pic:'ZZZ9'},{av:'A2264CBFlujCMes',fld:'CBFLUJCMES',pic:'Z9'},{av:'A2265CBFlujCBanCod',fld:'CBFLUJCBANCOD',pic:'ZZZZZ9'},{av:'A2266CBFlujCCuenta',fld:'CBFLUJCCUENTA',pic:''},{av:'A2267CBFlujCRegistro',fld:'CBFLUJCREGISTRO',pic:''},{av:'A2268CBFlujCItem',fld:'CBFLUJCITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBFLUJCITEM",",oparms:[{av:'A2269CBFlujTip',fld:'CBFLUJTIP',pic:''},{av:'A2270CBFlujCod',fld:'CBFLUJCOD',pic:''},{av:'A2271CBFlujCCod',fld:'CBFLUJCCOD',pic:''},{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A2275CBFlujCCosto',fld:'CBFLUJCCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''},{av:'A2276CBFlujCDsc',fld:'CBFLUJCDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2263CBFlujCAno'},{av:'Z2264CBFlujCMes'},{av:'Z2265CBFlujCBanCod'},{av:'Z2266CBFlujCCuenta'},{av:'Z2267CBFlujCRegistro'},{av:'Z2268CBFlujCItem'},{av:'Z2269CBFlujTip'},{av:'Z2270CBFlujCod'},{av:'Z2271CBFlujCCod'},{av:'Z79COSCod'},{av:'Z2275CBFlujCCosto'},{av:'Z2277CBFlujDsc'},{av:'Z2276CBFlujCDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CBFLUJTIP","{handler:'Valid_Cbflujtip',iparms:[]");
         setEventMetadata("VALID_CBFLUJTIP",",oparms:[]}");
         setEventMetadata("VALID_CBFLUJCOD","{handler:'Valid_Cbflujcod',iparms:[{av:'A2269CBFlujTip',fld:'CBFLUJTIP',pic:''},{av:'A2270CBFlujCod',fld:'CBFLUJCOD',pic:''},{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''}]");
         setEventMetadata("VALID_CBFLUJCOD",",oparms:[{av:'A2277CBFlujDsc',fld:'CBFLUJDSC',pic:''}]}");
         setEventMetadata("VALID_CBFLUJCCOD","{handler:'Valid_Cbflujccod',iparms:[{av:'A2269CBFlujTip',fld:'CBFLUJTIP',pic:''},{av:'A2270CBFlujCod',fld:'CBFLUJCOD',pic:''},{av:'A2271CBFlujCCod',fld:'CBFLUJCCOD',pic:''},{av:'A2276CBFlujCDsc',fld:'CBFLUJCDSC',pic:''}]");
         setEventMetadata("VALID_CBFLUJCCOD",",oparms:[{av:'A2276CBFlujCDsc',fld:'CBFLUJCDSC',pic:''}]}");
         setEventMetadata("VALID_COSCOD","{handler:'Valid_Coscod',iparms:[{av:'A79COSCod',fld:'COSCOD',pic:''}]");
         setEventMetadata("VALID_COSCOD",",oparms:[]}");
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
         pr_default.close(20);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2266CBFlujCCuenta = "";
         Z2267CBFlujCRegistro = "";
         Z2269CBFlujTip = "";
         Z2270CBFlujCod = "";
         Z2271CBFlujCCod = "";
         Z79COSCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2266CBFlujCCuenta = "";
         A2267CBFlujCRegistro = "";
         A2269CBFlujTip = "";
         A2270CBFlujCod = "";
         A2271CBFlujCCod = "";
         A79COSCod = "";
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
         Z2276CBFlujCDsc = "";
         T007D8_A2268CBFlujCItem = new int[1] ;
         T007D8_A2277CBFlujDsc = new string[] {""} ;
         T007D8_A2276CBFlujCDsc = new string[] {""} ;
         T007D8_A2275CBFlujCCosto = new decimal[1] ;
         T007D8_A2263CBFlujCAno = new short[1] ;
         T007D8_A2264CBFlujCMes = new short[1] ;
         T007D8_A2265CBFlujCBanCod = new int[1] ;
         T007D8_A2266CBFlujCCuenta = new string[] {""} ;
         T007D8_A2267CBFlujCRegistro = new string[] {""} ;
         T007D8_A2269CBFlujTip = new string[] {""} ;
         T007D8_A2270CBFlujCod = new string[] {""} ;
         T007D8_A2271CBFlujCCod = new string[] {""} ;
         T007D8_A79COSCod = new string[] {""} ;
         T007D4_A2263CBFlujCAno = new short[1] ;
         T007D5_A2277CBFlujDsc = new string[] {""} ;
         T007D6_A2276CBFlujCDsc = new string[] {""} ;
         T007D7_A79COSCod = new string[] {""} ;
         T007D9_A2263CBFlujCAno = new short[1] ;
         T007D10_A2277CBFlujDsc = new string[] {""} ;
         T007D11_A2276CBFlujCDsc = new string[] {""} ;
         T007D12_A79COSCod = new string[] {""} ;
         T007D13_A2263CBFlujCAno = new short[1] ;
         T007D13_A2264CBFlujCMes = new short[1] ;
         T007D13_A2265CBFlujCBanCod = new int[1] ;
         T007D13_A2266CBFlujCCuenta = new string[] {""} ;
         T007D13_A2267CBFlujCRegistro = new string[] {""} ;
         T007D13_A2268CBFlujCItem = new int[1] ;
         T007D3_A2268CBFlujCItem = new int[1] ;
         T007D3_A2275CBFlujCCosto = new decimal[1] ;
         T007D3_A2263CBFlujCAno = new short[1] ;
         T007D3_A2264CBFlujCMes = new short[1] ;
         T007D3_A2265CBFlujCBanCod = new int[1] ;
         T007D3_A2266CBFlujCCuenta = new string[] {""} ;
         T007D3_A2267CBFlujCRegistro = new string[] {""} ;
         T007D3_A2269CBFlujTip = new string[] {""} ;
         T007D3_A2270CBFlujCod = new string[] {""} ;
         T007D3_A2271CBFlujCCod = new string[] {""} ;
         T007D3_A79COSCod = new string[] {""} ;
         sMode201 = "";
         T007D14_A2263CBFlujCAno = new short[1] ;
         T007D14_A2264CBFlujCMes = new short[1] ;
         T007D14_A2265CBFlujCBanCod = new int[1] ;
         T007D14_A2266CBFlujCCuenta = new string[] {""} ;
         T007D14_A2267CBFlujCRegistro = new string[] {""} ;
         T007D14_A2268CBFlujCItem = new int[1] ;
         T007D15_A2263CBFlujCAno = new short[1] ;
         T007D15_A2264CBFlujCMes = new short[1] ;
         T007D15_A2265CBFlujCBanCod = new int[1] ;
         T007D15_A2266CBFlujCCuenta = new string[] {""} ;
         T007D15_A2267CBFlujCRegistro = new string[] {""} ;
         T007D15_A2268CBFlujCItem = new int[1] ;
         T007D2_A2268CBFlujCItem = new int[1] ;
         T007D2_A2275CBFlujCCosto = new decimal[1] ;
         T007D2_A2263CBFlujCAno = new short[1] ;
         T007D2_A2264CBFlujCMes = new short[1] ;
         T007D2_A2265CBFlujCBanCod = new int[1] ;
         T007D2_A2266CBFlujCCuenta = new string[] {""} ;
         T007D2_A2267CBFlujCRegistro = new string[] {""} ;
         T007D2_A2269CBFlujTip = new string[] {""} ;
         T007D2_A2270CBFlujCod = new string[] {""} ;
         T007D2_A2271CBFlujCCod = new string[] {""} ;
         T007D2_A79COSCod = new string[] {""} ;
         T007D19_A2277CBFlujDsc = new string[] {""} ;
         T007D20_A2276CBFlujCDsc = new string[] {""} ;
         T007D21_A2263CBFlujCAno = new short[1] ;
         T007D21_A2264CBFlujCMes = new short[1] ;
         T007D21_A2265CBFlujCBanCod = new int[1] ;
         T007D21_A2266CBFlujCCuenta = new string[] {""} ;
         T007D21_A2267CBFlujCRegistro = new string[] {""} ;
         T007D21_A2268CBFlujCItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007D22_A2263CBFlujCAno = new short[1] ;
         ZZ2266CBFlujCCuenta = "";
         ZZ2267CBFlujCRegistro = "";
         ZZ2269CBFlujTip = "";
         ZZ2270CBFlujCod = "";
         ZZ2271CBFlujCCod = "";
         ZZ79COSCod = "";
         ZZ2277CBFlujDsc = "";
         ZZ2276CBFlujCDsc = "";
         T007D23_A79COSCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbflujoconceptosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbflujoconceptosdet__default(),
            new Object[][] {
                new Object[] {
               T007D2_A2268CBFlujCItem, T007D2_A2275CBFlujCCosto, T007D2_A2263CBFlujCAno, T007D2_A2264CBFlujCMes, T007D2_A2265CBFlujCBanCod, T007D2_A2266CBFlujCCuenta, T007D2_A2267CBFlujCRegistro, T007D2_A2269CBFlujTip, T007D2_A2270CBFlujCod, T007D2_A2271CBFlujCCod,
               T007D2_A79COSCod
               }
               , new Object[] {
               T007D3_A2268CBFlujCItem, T007D3_A2275CBFlujCCosto, T007D3_A2263CBFlujCAno, T007D3_A2264CBFlujCMes, T007D3_A2265CBFlujCBanCod, T007D3_A2266CBFlujCCuenta, T007D3_A2267CBFlujCRegistro, T007D3_A2269CBFlujTip, T007D3_A2270CBFlujCod, T007D3_A2271CBFlujCCod,
               T007D3_A79COSCod
               }
               , new Object[] {
               T007D4_A2263CBFlujCAno
               }
               , new Object[] {
               T007D5_A2277CBFlujDsc
               }
               , new Object[] {
               T007D6_A2276CBFlujCDsc
               }
               , new Object[] {
               T007D7_A79COSCod
               }
               , new Object[] {
               T007D8_A2268CBFlujCItem, T007D8_A2277CBFlujDsc, T007D8_A2276CBFlujCDsc, T007D8_A2275CBFlujCCosto, T007D8_A2263CBFlujCAno, T007D8_A2264CBFlujCMes, T007D8_A2265CBFlujCBanCod, T007D8_A2266CBFlujCCuenta, T007D8_A2267CBFlujCRegistro, T007D8_A2269CBFlujTip,
               T007D8_A2270CBFlujCod, T007D8_A2271CBFlujCCod, T007D8_A79COSCod
               }
               , new Object[] {
               T007D9_A2263CBFlujCAno
               }
               , new Object[] {
               T007D10_A2277CBFlujDsc
               }
               , new Object[] {
               T007D11_A2276CBFlujCDsc
               }
               , new Object[] {
               T007D12_A79COSCod
               }
               , new Object[] {
               T007D13_A2263CBFlujCAno, T007D13_A2264CBFlujCMes, T007D13_A2265CBFlujCBanCod, T007D13_A2266CBFlujCCuenta, T007D13_A2267CBFlujCRegistro, T007D13_A2268CBFlujCItem
               }
               , new Object[] {
               T007D14_A2263CBFlujCAno, T007D14_A2264CBFlujCMes, T007D14_A2265CBFlujCBanCod, T007D14_A2266CBFlujCCuenta, T007D14_A2267CBFlujCRegistro, T007D14_A2268CBFlujCItem
               }
               , new Object[] {
               T007D15_A2263CBFlujCAno, T007D15_A2264CBFlujCMes, T007D15_A2265CBFlujCBanCod, T007D15_A2266CBFlujCCuenta, T007D15_A2267CBFlujCRegistro, T007D15_A2268CBFlujCItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007D19_A2277CBFlujDsc
               }
               , new Object[] {
               T007D20_A2276CBFlujCDsc
               }
               , new Object[] {
               T007D21_A2263CBFlujCAno, T007D21_A2264CBFlujCMes, T007D21_A2265CBFlujCBanCod, T007D21_A2266CBFlujCCuenta, T007D21_A2267CBFlujCRegistro, T007D21_A2268CBFlujCItem
               }
               , new Object[] {
               T007D22_A2263CBFlujCAno
               }
               , new Object[] {
               T007D23_A79COSCod
               }
            }
         );
      }

      private short Z2263CBFlujCAno ;
      private short Z2264CBFlujCMes ;
      private short GxWebError ;
      private short A2263CBFlujCAno ;
      private short A2264CBFlujCMes ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound201 ;
      private short nIsDirty_201 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2263CBFlujCAno ;
      private short ZZ2264CBFlujCMes ;
      private int Z2265CBFlujCBanCod ;
      private int Z2268CBFlujCItem ;
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
      private int A2268CBFlujCItem ;
      private int edtCBFlujCItem_Enabled ;
      private int edtCBFlujTip_Enabled ;
      private int edtCBFlujCod_Enabled ;
      private int edtCBFlujDsc_Enabled ;
      private int edtCBFlujCCod_Enabled ;
      private int edtCBFlujCDsc_Enabled ;
      private int edtCOSCod_Enabled ;
      private int edtCBFlujCCosto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2265CBFlujCBanCod ;
      private int ZZ2268CBFlujCItem ;
      private decimal Z2275CBFlujCCosto ;
      private decimal A2275CBFlujCCosto ;
      private decimal ZZ2275CBFlujCCosto ;
      private string sPrefix ;
      private string Z2266CBFlujCCuenta ;
      private string Z2267CBFlujCRegistro ;
      private string Z2269CBFlujTip ;
      private string Z2270CBFlujCod ;
      private string Z2271CBFlujCCod ;
      private string Z79COSCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2266CBFlujCCuenta ;
      private string A2267CBFlujCRegistro ;
      private string A2269CBFlujTip ;
      private string A2270CBFlujCod ;
      private string A2271CBFlujCCod ;
      private string A79COSCod ;
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
      private string edtCBFlujCItem_Internalname ;
      private string edtCBFlujCItem_Jsonclick ;
      private string edtCBFlujTip_Internalname ;
      private string edtCBFlujTip_Jsonclick ;
      private string edtCBFlujCod_Internalname ;
      private string edtCBFlujCod_Jsonclick ;
      private string edtCBFlujDsc_Internalname ;
      private string A2277CBFlujDsc ;
      private string edtCBFlujDsc_Jsonclick ;
      private string edtCBFlujCCod_Internalname ;
      private string edtCBFlujCCod_Jsonclick ;
      private string edtCBFlujCDsc_Internalname ;
      private string A2276CBFlujCDsc ;
      private string edtCBFlujCDsc_Jsonclick ;
      private string edtCOSCod_Internalname ;
      private string edtCOSCod_Jsonclick ;
      private string edtCBFlujCCosto_Internalname ;
      private string edtCBFlujCCosto_Jsonclick ;
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
      private string Z2276CBFlujCDsc ;
      private string sMode201 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2266CBFlujCCuenta ;
      private string ZZ2267CBFlujCRegistro ;
      private string ZZ2269CBFlujTip ;
      private string ZZ2270CBFlujCod ;
      private string ZZ2271CBFlujCCod ;
      private string ZZ79COSCod ;
      private string ZZ2277CBFlujDsc ;
      private string ZZ2276CBFlujCDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T007D8_A2268CBFlujCItem ;
      private string[] T007D8_A2277CBFlujDsc ;
      private string[] T007D8_A2276CBFlujCDsc ;
      private decimal[] T007D8_A2275CBFlujCCosto ;
      private short[] T007D8_A2263CBFlujCAno ;
      private short[] T007D8_A2264CBFlujCMes ;
      private int[] T007D8_A2265CBFlujCBanCod ;
      private string[] T007D8_A2266CBFlujCCuenta ;
      private string[] T007D8_A2267CBFlujCRegistro ;
      private string[] T007D8_A2269CBFlujTip ;
      private string[] T007D8_A2270CBFlujCod ;
      private string[] T007D8_A2271CBFlujCCod ;
      private string[] T007D8_A79COSCod ;
      private short[] T007D4_A2263CBFlujCAno ;
      private string[] T007D5_A2277CBFlujDsc ;
      private string[] T007D6_A2276CBFlujCDsc ;
      private string[] T007D7_A79COSCod ;
      private short[] T007D9_A2263CBFlujCAno ;
      private string[] T007D10_A2277CBFlujDsc ;
      private string[] T007D11_A2276CBFlujCDsc ;
      private string[] T007D12_A79COSCod ;
      private short[] T007D13_A2263CBFlujCAno ;
      private short[] T007D13_A2264CBFlujCMes ;
      private int[] T007D13_A2265CBFlujCBanCod ;
      private string[] T007D13_A2266CBFlujCCuenta ;
      private string[] T007D13_A2267CBFlujCRegistro ;
      private int[] T007D13_A2268CBFlujCItem ;
      private int[] T007D3_A2268CBFlujCItem ;
      private decimal[] T007D3_A2275CBFlujCCosto ;
      private short[] T007D3_A2263CBFlujCAno ;
      private short[] T007D3_A2264CBFlujCMes ;
      private int[] T007D3_A2265CBFlujCBanCod ;
      private string[] T007D3_A2266CBFlujCCuenta ;
      private string[] T007D3_A2267CBFlujCRegistro ;
      private string[] T007D3_A2269CBFlujTip ;
      private string[] T007D3_A2270CBFlujCod ;
      private string[] T007D3_A2271CBFlujCCod ;
      private string[] T007D3_A79COSCod ;
      private short[] T007D14_A2263CBFlujCAno ;
      private short[] T007D14_A2264CBFlujCMes ;
      private int[] T007D14_A2265CBFlujCBanCod ;
      private string[] T007D14_A2266CBFlujCCuenta ;
      private string[] T007D14_A2267CBFlujCRegistro ;
      private int[] T007D14_A2268CBFlujCItem ;
      private short[] T007D15_A2263CBFlujCAno ;
      private short[] T007D15_A2264CBFlujCMes ;
      private int[] T007D15_A2265CBFlujCBanCod ;
      private string[] T007D15_A2266CBFlujCCuenta ;
      private string[] T007D15_A2267CBFlujCRegistro ;
      private int[] T007D15_A2268CBFlujCItem ;
      private int[] T007D2_A2268CBFlujCItem ;
      private decimal[] T007D2_A2275CBFlujCCosto ;
      private short[] T007D2_A2263CBFlujCAno ;
      private short[] T007D2_A2264CBFlujCMes ;
      private int[] T007D2_A2265CBFlujCBanCod ;
      private string[] T007D2_A2266CBFlujCCuenta ;
      private string[] T007D2_A2267CBFlujCRegistro ;
      private string[] T007D2_A2269CBFlujTip ;
      private string[] T007D2_A2270CBFlujCod ;
      private string[] T007D2_A2271CBFlujCCod ;
      private string[] T007D2_A79COSCod ;
      private string[] T007D19_A2277CBFlujDsc ;
      private string[] T007D20_A2276CBFlujCDsc ;
      private short[] T007D21_A2263CBFlujCAno ;
      private short[] T007D21_A2264CBFlujCMes ;
      private int[] T007D21_A2265CBFlujCBanCod ;
      private string[] T007D21_A2266CBFlujCCuenta ;
      private string[] T007D21_A2267CBFlujCRegistro ;
      private int[] T007D21_A2268CBFlujCItem ;
      private short[] T007D22_A2263CBFlujCAno ;
      private string[] T007D23_A79COSCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbflujoconceptosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbflujoconceptosdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007D8;
        prmT007D8 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D4;
        prmT007D4 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007D5;
        prmT007D5 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007D6;
        prmT007D6 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007D7;
        prmT007D7 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        Object[] prmT007D9;
        prmT007D9 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007D10;
        prmT007D10 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007D11;
        prmT007D11 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007D12;
        prmT007D12 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        Object[] prmT007D13;
        prmT007D13 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D3;
        prmT007D3 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D14;
        prmT007D14 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D15;
        prmT007D15 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D2;
        prmT007D2 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D16;
        prmT007D16 = new Object[] {
        new ParDef("@CBFlujCItem",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCosto",GXType.Decimal,15,2) ,
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        Object[] prmT007D17;
        prmT007D17 = new Object[] {
        new ParDef("@CBFlujCCosto",GXType.Decimal,15,2) ,
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D18;
        prmT007D18 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0) ,
        new ParDef("@CBFlujCItem",GXType.Int32,6,0)
        };
        Object[] prmT007D21;
        prmT007D21 = new Object[] {
        };
        Object[] prmT007D22;
        prmT007D22 = new Object[] {
        new ParDef("@CBFlujCAno",GXType.Int16,4,0) ,
        new ParDef("@CBFlujCMes",GXType.Int16,2,0) ,
        new ParDef("@CBFlujCBanCod",GXType.Int32,6,0) ,
        new ParDef("@CBFlujCCuenta",GXType.NChar,20,0) ,
        new ParDef("@CBFlujCRegistro",GXType.NChar,10,0)
        };
        Object[] prmT007D19;
        prmT007D19 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0)
        };
        Object[] prmT007D20;
        prmT007D20 = new Object[] {
        new ParDef("@CBFlujTip",GXType.NChar,1,0) ,
        new ParDef("@CBFlujCod",GXType.NChar,5,0) ,
        new ParDef("@CBFlujCCod",GXType.NChar,5,0)
        };
        Object[] prmT007D23;
        prmT007D23 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007D2", "SELECT [CBFlujCItem], [CBFlujCCosto], [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujTip], [CBFlujCod], [CBFlujCCod], [COSCod] FROM [CBFLUJOCONCEPTOSDET] WITH (UPDLOCK) WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro AND [CBFlujCItem] = @CBFlujCItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D3", "SELECT [CBFlujCItem], [CBFlujCCosto], [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujTip], [CBFlujCod], [CBFlujCCod], [COSCod] FROM [CBFLUJOCONCEPTOSDET] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro AND [CBFlujCItem] = @CBFlujCItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D4", "SELECT [CBFlujCAno] FROM [CBFLUJOCONCEPTOS] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D5", "SELECT [CBFlujDsc] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D6", "SELECT [CBFlujCDsc] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D7", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D8", "SELECT TM1.[CBFlujCItem], T2.[CBFlujDsc], T3.[CBFlujCDsc], TM1.[CBFlujCCosto], TM1.[CBFlujCAno], TM1.[CBFlujCMes], TM1.[CBFlujCBanCod], TM1.[CBFlujCCuenta], TM1.[CBFlujCRegistro], TM1.[CBFlujTip], TM1.[CBFlujCod], TM1.[CBFlujCCod], TM1.[COSCod] FROM (([CBFLUJOCONCEPTOSDET] TM1 INNER JOIN [CBFLUJOTITULO] T2 ON T2.[CBFlujTip] = TM1.[CBFlujTip] AND T2.[CBFlujCod] = TM1.[CBFlujCod]) INNER JOIN [CBFLUJOTITULODET] T3 ON T3.[CBFlujTip] = TM1.[CBFlujTip] AND T3.[CBFlujCod] = TM1.[CBFlujCod] AND T3.[CBFlujCCod] = TM1.[CBFlujCCod]) WHERE TM1.[CBFlujCAno] = @CBFlujCAno and TM1.[CBFlujCMes] = @CBFlujCMes and TM1.[CBFlujCBanCod] = @CBFlujCBanCod and TM1.[CBFlujCCuenta] = @CBFlujCCuenta and TM1.[CBFlujCRegistro] = @CBFlujCRegistro and TM1.[CBFlujCItem] = @CBFlujCItem ORDER BY TM1.[CBFlujCAno], TM1.[CBFlujCMes], TM1.[CBFlujCBanCod], TM1.[CBFlujCCuenta], TM1.[CBFlujCRegistro], TM1.[CBFlujCItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007D8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D9", "SELECT [CBFlujCAno] FROM [CBFLUJOCONCEPTOS] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D10", "SELECT [CBFlujDsc] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D11", "SELECT [CBFlujCDsc] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D12", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D13", "SELECT [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro AND [CBFlujCItem] = @CBFlujCItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D14", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE ( [CBFlujCAno] > @CBFlujCAno or [CBFlujCAno] = @CBFlujCAno and [CBFlujCMes] > @CBFlujCMes or [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCBanCod] > @CBFlujCBanCod or [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCCuenta] > @CBFlujCCuenta or [CBFlujCCuenta] = @CBFlujCCuenta and [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCRegistro] > @CBFlujCRegistro or [CBFlujCRegistro] = @CBFlujCRegistro and [CBFlujCCuenta] = @CBFlujCCuenta and [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCItem] > @CBFlujCItem) ORDER BY [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007D15", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE ( [CBFlujCAno] < @CBFlujCAno or [CBFlujCAno] = @CBFlujCAno and [CBFlujCMes] < @CBFlujCMes or [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCBanCod] < @CBFlujCBanCod or [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCCuenta] < @CBFlujCCuenta or [CBFlujCCuenta] = @CBFlujCCuenta and [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCRegistro] < @CBFlujCRegistro or [CBFlujCRegistro] = @CBFlujCRegistro and [CBFlujCCuenta] = @CBFlujCCuenta and [CBFlujCBanCod] = @CBFlujCBanCod and [CBFlujCMes] = @CBFlujCMes and [CBFlujCAno] = @CBFlujCAno and [CBFlujCItem] < @CBFlujCItem) ORDER BY [CBFlujCAno] DESC, [CBFlujCMes] DESC, [CBFlujCBanCod] DESC, [CBFlujCCuenta] DESC, [CBFlujCRegistro] DESC, [CBFlujCItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007D16", "INSERT INTO [CBFLUJOCONCEPTOSDET]([CBFlujCItem], [CBFlujCCosto], [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujTip], [CBFlujCod], [CBFlujCCod], [COSCod]) VALUES(@CBFlujCItem, @CBFlujCCosto, @CBFlujCAno, @CBFlujCMes, @CBFlujCBanCod, @CBFlujCCuenta, @CBFlujCRegistro, @CBFlujTip, @CBFlujCod, @CBFlujCCod, @COSCod)", GxErrorMask.GX_NOMASK,prmT007D16)
           ,new CursorDef("T007D17", "UPDATE [CBFLUJOCONCEPTOSDET] SET [CBFlujCCosto]=@CBFlujCCosto, [CBFlujTip]=@CBFlujTip, [CBFlujCod]=@CBFlujCod, [CBFlujCCod]=@CBFlujCCod, [COSCod]=@COSCod  WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro AND [CBFlujCItem] = @CBFlujCItem", GxErrorMask.GX_NOMASK,prmT007D17)
           ,new CursorDef("T007D18", "DELETE FROM [CBFLUJOCONCEPTOSDET]  WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro AND [CBFlujCItem] = @CBFlujCItem", GxErrorMask.GX_NOMASK,prmT007D18)
           ,new CursorDef("T007D19", "SELECT [CBFlujDsc] FROM [CBFLUJOTITULO] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D20", "SELECT [CBFlujCDsc] FROM [CBFLUJOTITULODET] WHERE [CBFlujTip] = @CBFlujTip AND [CBFlujCod] = @CBFlujCod AND [CBFlujCCod] = @CBFlujCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D21", "SELECT [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] ORDER BY [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007D21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D22", "SELECT [CBFlujCAno] FROM [CBFLUJOCONCEPTOS] WHERE [CBFlujCAno] = @CBFlujCAno AND [CBFlujCMes] = @CBFlujCMes AND [CBFlujCBanCod] = @CBFlujCBanCod AND [CBFlujCCuenta] = @CBFlujCCuenta AND [CBFlujCRegistro] = @CBFlujCRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007D23", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007D23,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getString(9, 5);
              ((string[]) buf[9])[0] = rslt.getString(10, 5);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getString(9, 5);
              ((string[]) buf[9])[0] = rslt.getString(10, 5);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((string[]) buf[10])[0] = rslt.getString(11, 5);
              ((string[]) buf[11])[0] = rslt.getString(12, 5);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
