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
   public class tspagosdet : GXDataArea
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
            A412PagReg = (long)(NumberUtil.Val( GetPar( "PagReg"), "."));
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A412PagReg) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A420PagDTipCod = GetPar( "PagDTipCod");
            AssignAttri("", false, "A420PagDTipCod", A420PagDTipCod);
            A421PagDComCod = GetPar( "PagDComCod");
            AssignAttri("", false, "A421PagDComCod", A421PagDComCod);
            A422PagDPrvCod = GetPar( "PagDPrvCod");
            AssignAttri("", false, "A422PagDPrvCod", A422PagDPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A420PagDTipCod, A421PagDComCod, A422PagDPrvCod) ;
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
            Form.Meta.addItem("description", "Pagos - Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tspagosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tspagosdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Pagos - Detalle", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_TSPAGOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSPAGOSDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagReg_Internalname, "Registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A412PagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A412PagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A412PagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagItem_Internalname, "Pag Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A419PagItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtPagItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A419PagItem), "ZZZ9") : context.localUtil.Format( (decimal)(A419PagItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDTipCod_Internalname, "D", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDTipCod_Internalname, StringUtil.RTrim( A420PagDTipCod), StringUtil.RTrim( context.localUtil.Format( A420PagDTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDComCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDComCod_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDComCod_Internalname, StringUtil.RTrim( A421PagDComCod), StringUtil.RTrim( context.localUtil.Format( A421PagDComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDComCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDTot_Internalname, "Importe Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1481PagDTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtPagDTot_Enabled!=0) ? context.localUtil.Format( A1481PagDTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1481PagDTot, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDImp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDImp_Internalname, "Importe Real", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A1480PagDImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtPagDImp_Enabled!=0) ? context.localUtil.Format( A1480PagDImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1480PagDImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDCanje_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDCanje_Internalname, "Canje Letra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDCanje_Internalname, StringUtil.RTrim( A1478PagDCanje), StringUtil.RTrim( context.localUtil.Format( A1478PagDCanje, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDCanje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDCanje_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDCajaC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDCajaC_Internalname, "Caja Chica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDCajaC_Internalname, StringUtil.RTrim( A1477PagDCajaC), StringUtil.RTrim( context.localUtil.Format( A1477PagDCajaC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDCajaC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDCajaC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDAnticipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDAnticipo_Internalname, "N° Anticipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDAnticipo_Internalname, StringUtil.RTrim( A1476PagDAnticipo), StringUtil.RTrim( context.localUtil.Format( A1476PagDAnticipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDAnticipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDAnticipo_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDConcepto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDConcepto_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDConcepto_Internalname, A1479PagDConcepto, StringUtil.RTrim( context.localUtil.Format( A1479PagDConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagDPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagDPrvCod_Internalname, "Proveedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagDPrvCod_Internalname, StringUtil.RTrim( A422PagDPrvCod), StringUtil.RTrim( context.localUtil.Format( A422PagDPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagDPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagDPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOSDET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOSDET.htm");
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
            Z412PagReg = (long)(context.localUtil.CToN( cgiGet( "Z412PagReg"), ".", ","));
            Z419PagItem = (short)(context.localUtil.CToN( cgiGet( "Z419PagItem"), ".", ","));
            Z1481PagDTot = context.localUtil.CToN( cgiGet( "Z1481PagDTot"), ".", ",");
            Z1480PagDImp = context.localUtil.CToN( cgiGet( "Z1480PagDImp"), ".", ",");
            Z1478PagDCanje = cgiGet( "Z1478PagDCanje");
            Z1477PagDCajaC = cgiGet( "Z1477PagDCajaC");
            Z1476PagDAnticipo = cgiGet( "Z1476PagDAnticipo");
            Z1479PagDConcepto = cgiGet( "Z1479PagDConcepto");
            Z420PagDTipCod = cgiGet( "Z420PagDTipCod");
            Z421PagDComCod = cgiGet( "Z421PagDComCod");
            Z422PagDPrvCod = cgiGet( "Z422PagDPrvCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGREG");
               AnyError = 1;
               GX_FocusControl = edtPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A412PagReg = 0;
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            }
            else
            {
               A412PagReg = (long)(context.localUtil.CToN( cgiGet( edtPagReg_Internalname), ".", ","));
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGITEM");
               AnyError = 1;
               GX_FocusControl = edtPagItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A419PagItem = 0;
               AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
            }
            else
            {
               A419PagItem = (short)(context.localUtil.CToN( cgiGet( edtPagItem_Internalname), ".", ","));
               AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
            }
            A420PagDTipCod = cgiGet( edtPagDTipCod_Internalname);
            AssignAttri("", false, "A420PagDTipCod", A420PagDTipCod);
            A421PagDComCod = cgiGet( edtPagDComCod_Internalname);
            AssignAttri("", false, "A421PagDComCod", A421PagDComCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagDTot_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPagDTot_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGDTOT");
               AnyError = 1;
               GX_FocusControl = edtPagDTot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1481PagDTot = 0;
               AssignAttri("", false, "A1481PagDTot", StringUtil.LTrimStr( A1481PagDTot, 15, 2));
            }
            else
            {
               A1481PagDTot = context.localUtil.CToN( cgiGet( edtPagDTot_Internalname), ".", ",");
               AssignAttri("", false, "A1481PagDTot", StringUtil.LTrimStr( A1481PagDTot, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagDImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPagDImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGDIMP");
               AnyError = 1;
               GX_FocusControl = edtPagDImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1480PagDImp = 0;
               AssignAttri("", false, "A1480PagDImp", StringUtil.LTrimStr( A1480PagDImp, 15, 2));
            }
            else
            {
               A1480PagDImp = context.localUtil.CToN( cgiGet( edtPagDImp_Internalname), ".", ",");
               AssignAttri("", false, "A1480PagDImp", StringUtil.LTrimStr( A1480PagDImp, 15, 2));
            }
            A1478PagDCanje = cgiGet( edtPagDCanje_Internalname);
            AssignAttri("", false, "A1478PagDCanje", A1478PagDCanje);
            A1477PagDCajaC = cgiGet( edtPagDCajaC_Internalname);
            AssignAttri("", false, "A1477PagDCajaC", A1477PagDCajaC);
            A1476PagDAnticipo = cgiGet( edtPagDAnticipo_Internalname);
            AssignAttri("", false, "A1476PagDAnticipo", A1476PagDAnticipo);
            A1479PagDConcepto = cgiGet( edtPagDConcepto_Internalname);
            AssignAttri("", false, "A1479PagDConcepto", A1479PagDConcepto);
            A422PagDPrvCod = StringUtil.Upper( cgiGet( edtPagDPrvCod_Internalname));
            AssignAttri("", false, "A422PagDPrvCod", A422PagDPrvCod);
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
               A412PagReg = (long)(NumberUtil.Val( GetPar( "PagReg"), "."));
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
               A419PagItem = (short)(NumberUtil.Val( GetPar( "PagItem"), "."));
               AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
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
               InitAll5E181( ) ;
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
         DisableAttributes5E181( ) ;
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

      protected void ResetCaption5E0( )
      {
      }

      protected void ZM5E181( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1481PagDTot = T005E3_A1481PagDTot[0];
               Z1480PagDImp = T005E3_A1480PagDImp[0];
               Z1478PagDCanje = T005E3_A1478PagDCanje[0];
               Z1477PagDCajaC = T005E3_A1477PagDCajaC[0];
               Z1476PagDAnticipo = T005E3_A1476PagDAnticipo[0];
               Z1479PagDConcepto = T005E3_A1479PagDConcepto[0];
               Z420PagDTipCod = T005E3_A420PagDTipCod[0];
               Z421PagDComCod = T005E3_A421PagDComCod[0];
               Z422PagDPrvCod = T005E3_A422PagDPrvCod[0];
            }
            else
            {
               Z1481PagDTot = A1481PagDTot;
               Z1480PagDImp = A1480PagDImp;
               Z1478PagDCanje = A1478PagDCanje;
               Z1477PagDCajaC = A1477PagDCajaC;
               Z1476PagDAnticipo = A1476PagDAnticipo;
               Z1479PagDConcepto = A1479PagDConcepto;
               Z420PagDTipCod = A420PagDTipCod;
               Z421PagDComCod = A421PagDComCod;
               Z422PagDPrvCod = A422PagDPrvCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z419PagItem = A419PagItem;
            Z1481PagDTot = A1481PagDTot;
            Z1480PagDImp = A1480PagDImp;
            Z1478PagDCanje = A1478PagDCanje;
            Z1477PagDCajaC = A1477PagDCajaC;
            Z1476PagDAnticipo = A1476PagDAnticipo;
            Z1479PagDConcepto = A1479PagDConcepto;
            Z412PagReg = A412PagReg;
            Z420PagDTipCod = A420PagDTipCod;
            Z421PagDComCod = A421PagDComCod;
            Z422PagDPrvCod = A422PagDPrvCod;
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

      protected void Load5E181( )
      {
         /* Using cursor T005E6 */
         pr_default.execute(4, new Object[] {A412PagReg, A419PagItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound181 = 1;
            A1481PagDTot = T005E6_A1481PagDTot[0];
            AssignAttri("", false, "A1481PagDTot", StringUtil.LTrimStr( A1481PagDTot, 15, 2));
            A1480PagDImp = T005E6_A1480PagDImp[0];
            AssignAttri("", false, "A1480PagDImp", StringUtil.LTrimStr( A1480PagDImp, 15, 2));
            A1478PagDCanje = T005E6_A1478PagDCanje[0];
            AssignAttri("", false, "A1478PagDCanje", A1478PagDCanje);
            A1477PagDCajaC = T005E6_A1477PagDCajaC[0];
            AssignAttri("", false, "A1477PagDCajaC", A1477PagDCajaC);
            A1476PagDAnticipo = T005E6_A1476PagDAnticipo[0];
            AssignAttri("", false, "A1476PagDAnticipo", A1476PagDAnticipo);
            A1479PagDConcepto = T005E6_A1479PagDConcepto[0];
            AssignAttri("", false, "A1479PagDConcepto", A1479PagDConcepto);
            A420PagDTipCod = T005E6_A420PagDTipCod[0];
            AssignAttri("", false, "A420PagDTipCod", A420PagDTipCod);
            A421PagDComCod = T005E6_A421PagDComCod[0];
            AssignAttri("", false, "A421PagDComCod", A421PagDComCod);
            A422PagDPrvCod = T005E6_A422PagDPrvCod[0];
            AssignAttri("", false, "A422PagDPrvCod", A422PagDPrvCod);
            ZM5E181( -1) ;
         }
         pr_default.close(4);
         OnLoadActions5E181( ) ;
      }

      protected void OnLoadActions5E181( )
      {
      }

      protected void CheckExtendedTable5E181( )
      {
         nIsDirty_181 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T005E4 */
         pr_default.execute(2, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Pagos a proveedores'.", "ForeignKeyNotFound", 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T005E5 */
         pr_default.execute(3, new Object[] {A420PagDTipCod, A421PagDComCod, A422PagDPrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Pagos Detalle Proveedor'.", "ForeignKeyNotFound", 1, "PAGDPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPagDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors5E181( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A412PagReg )
      {
         /* Using cursor T005E7 */
         pr_default.execute(5, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Pagos a proveedores'.", "ForeignKeyNotFound", 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
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

      protected void gxLoad_3( string A420PagDTipCod ,
                               string A421PagDComCod ,
                               string A422PagDPrvCod )
      {
         /* Using cursor T005E8 */
         pr_default.execute(6, new Object[] {A420PagDTipCod, A421PagDComCod, A422PagDPrvCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Pagos Detalle Proveedor'.", "ForeignKeyNotFound", 1, "PAGDPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPagDTipCod_Internalname;
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

      protected void GetKey5E181( )
      {
         /* Using cursor T005E9 */
         pr_default.execute(7, new Object[] {A412PagReg, A419PagItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound181 = 1;
         }
         else
         {
            RcdFound181 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005E3 */
         pr_default.execute(1, new Object[] {A412PagReg, A419PagItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5E181( 1) ;
            RcdFound181 = 1;
            A419PagItem = T005E3_A419PagItem[0];
            AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
            A1481PagDTot = T005E3_A1481PagDTot[0];
            AssignAttri("", false, "A1481PagDTot", StringUtil.LTrimStr( A1481PagDTot, 15, 2));
            A1480PagDImp = T005E3_A1480PagDImp[0];
            AssignAttri("", false, "A1480PagDImp", StringUtil.LTrimStr( A1480PagDImp, 15, 2));
            A1478PagDCanje = T005E3_A1478PagDCanje[0];
            AssignAttri("", false, "A1478PagDCanje", A1478PagDCanje);
            A1477PagDCajaC = T005E3_A1477PagDCajaC[0];
            AssignAttri("", false, "A1477PagDCajaC", A1477PagDCajaC);
            A1476PagDAnticipo = T005E3_A1476PagDAnticipo[0];
            AssignAttri("", false, "A1476PagDAnticipo", A1476PagDAnticipo);
            A1479PagDConcepto = T005E3_A1479PagDConcepto[0];
            AssignAttri("", false, "A1479PagDConcepto", A1479PagDConcepto);
            A412PagReg = T005E3_A412PagReg[0];
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            A420PagDTipCod = T005E3_A420PagDTipCod[0];
            AssignAttri("", false, "A420PagDTipCod", A420PagDTipCod);
            A421PagDComCod = T005E3_A421PagDComCod[0];
            AssignAttri("", false, "A421PagDComCod", A421PagDComCod);
            A422PagDPrvCod = T005E3_A422PagDPrvCod[0];
            AssignAttri("", false, "A422PagDPrvCod", A422PagDPrvCod);
            Z412PagReg = A412PagReg;
            Z419PagItem = A419PagItem;
            sMode181 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load5E181( ) ;
            if ( AnyError == 1 )
            {
               RcdFound181 = 0;
               InitializeNonKey5E181( ) ;
            }
            Gx_mode = sMode181;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound181 = 0;
            InitializeNonKey5E181( ) ;
            sMode181 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode181;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5E181( ) ;
         if ( RcdFound181 == 0 )
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
         RcdFound181 = 0;
         /* Using cursor T005E10 */
         pr_default.execute(8, new Object[] {A412PagReg, A419PagItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T005E10_A412PagReg[0] < A412PagReg ) || ( T005E10_A412PagReg[0] == A412PagReg ) && ( T005E10_A419PagItem[0] < A419PagItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T005E10_A412PagReg[0] > A412PagReg ) || ( T005E10_A412PagReg[0] == A412PagReg ) && ( T005E10_A419PagItem[0] > A419PagItem ) ) )
            {
               A412PagReg = T005E10_A412PagReg[0];
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
               A419PagItem = T005E10_A419PagItem[0];
               AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
               RcdFound181 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound181 = 0;
         /* Using cursor T005E11 */
         pr_default.execute(9, new Object[] {A412PagReg, A419PagItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T005E11_A412PagReg[0] > A412PagReg ) || ( T005E11_A412PagReg[0] == A412PagReg ) && ( T005E11_A419PagItem[0] > A419PagItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T005E11_A412PagReg[0] < A412PagReg ) || ( T005E11_A412PagReg[0] == A412PagReg ) && ( T005E11_A419PagItem[0] < A419PagItem ) ) )
            {
               A412PagReg = T005E11_A412PagReg[0];
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
               A419PagItem = T005E11_A419PagItem[0];
               AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
               RcdFound181 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5E181( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5E181( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound181 == 1 )
            {
               if ( ( A412PagReg != Z412PagReg ) || ( A419PagItem != Z419PagItem ) )
               {
                  A412PagReg = Z412PagReg;
                  AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
                  A419PagItem = Z419PagItem;
                  AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAGREG");
                  AnyError = 1;
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update5E181( ) ;
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A412PagReg != Z412PagReg ) || ( A419PagItem != Z419PagItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5E181( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAGREG");
                     AnyError = 1;
                     GX_FocusControl = edtPagReg_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPagReg_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5E181( ) ;
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
         if ( ( A412PagReg != Z412PagReg ) || ( A419PagItem != Z419PagItem ) )
         {
            A412PagReg = Z412PagReg;
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            A419PagItem = Z419PagItem;
            AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPagReg_Internalname;
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
         if ( RcdFound181 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPagDTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart5E181( ) ;
         if ( RcdFound181 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagDTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5E181( ) ;
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
         if ( RcdFound181 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagDTipCod_Internalname;
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
         if ( RcdFound181 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagDTipCod_Internalname;
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
         ScanStart5E181( ) ;
         if ( RcdFound181 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound181 != 0 )
            {
               ScanNext5E181( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagDTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5E181( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency5E181( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005E2 */
            pr_default.execute(0, new Object[] {A412PagReg, A419PagItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSPAGOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1481PagDTot != T005E2_A1481PagDTot[0] ) || ( Z1480PagDImp != T005E2_A1480PagDImp[0] ) || ( StringUtil.StrCmp(Z1478PagDCanje, T005E2_A1478PagDCanje[0]) != 0 ) || ( StringUtil.StrCmp(Z1477PagDCajaC, T005E2_A1477PagDCajaC[0]) != 0 ) || ( StringUtil.StrCmp(Z1476PagDAnticipo, T005E2_A1476PagDAnticipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1479PagDConcepto, T005E2_A1479PagDConcepto[0]) != 0 ) || ( StringUtil.StrCmp(Z420PagDTipCod, T005E2_A420PagDTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z421PagDComCod, T005E2_A421PagDComCod[0]) != 0 ) || ( StringUtil.StrCmp(Z422PagDPrvCod, T005E2_A422PagDPrvCod[0]) != 0 ) )
            {
               if ( Z1481PagDTot != T005E2_A1481PagDTot[0] )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDTot");
                  GXUtil.WriteLogRaw("Old: ",Z1481PagDTot);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A1481PagDTot[0]);
               }
               if ( Z1480PagDImp != T005E2_A1480PagDImp[0] )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDImp");
                  GXUtil.WriteLogRaw("Old: ",Z1480PagDImp);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A1480PagDImp[0]);
               }
               if ( StringUtil.StrCmp(Z1478PagDCanje, T005E2_A1478PagDCanje[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDCanje");
                  GXUtil.WriteLogRaw("Old: ",Z1478PagDCanje);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A1478PagDCanje[0]);
               }
               if ( StringUtil.StrCmp(Z1477PagDCajaC, T005E2_A1477PagDCajaC[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDCajaC");
                  GXUtil.WriteLogRaw("Old: ",Z1477PagDCajaC);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A1477PagDCajaC[0]);
               }
               if ( StringUtil.StrCmp(Z1476PagDAnticipo, T005E2_A1476PagDAnticipo[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDAnticipo");
                  GXUtil.WriteLogRaw("Old: ",Z1476PagDAnticipo);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A1476PagDAnticipo[0]);
               }
               if ( StringUtil.StrCmp(Z1479PagDConcepto, T005E2_A1479PagDConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1479PagDConcepto);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A1479PagDConcepto[0]);
               }
               if ( StringUtil.StrCmp(Z420PagDTipCod, T005E2_A420PagDTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z420PagDTipCod);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A420PagDTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z421PagDComCod, T005E2_A421PagDComCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDComCod");
                  GXUtil.WriteLogRaw("Old: ",Z421PagDComCod);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A421PagDComCod[0]);
               }
               if ( StringUtil.StrCmp(Z422PagDPrvCod, T005E2_A422PagDPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagosdet:[seudo value changed for attri]"+"PagDPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z422PagDPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T005E2_A422PagDPrvCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSPAGOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5E181( )
      {
         BeforeValidate5E181( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5E181( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5E181( 0) ;
            CheckOptimisticConcurrency5E181( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5E181( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5E181( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005E12 */
                     pr_default.execute(10, new Object[] {A419PagItem, A1481PagDTot, A1480PagDImp, A1478PagDCanje, A1477PagDCajaC, A1476PagDAnticipo, A1479PagDConcepto, A412PagReg, A420PagDTipCod, A421PagDComCod, A422PagDPrvCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("TSPAGOSDET");
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
                           ResetCaption5E0( ) ;
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
               Load5E181( ) ;
            }
            EndLevel5E181( ) ;
         }
         CloseExtendedTableCursors5E181( ) ;
      }

      protected void Update5E181( )
      {
         BeforeValidate5E181( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5E181( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5E181( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5E181( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5E181( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005E13 */
                     pr_default.execute(11, new Object[] {A1481PagDTot, A1480PagDImp, A1478PagDCanje, A1477PagDCajaC, A1476PagDAnticipo, A1479PagDConcepto, A420PagDTipCod, A421PagDComCod, A422PagDPrvCod, A412PagReg, A419PagItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("TSPAGOSDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSPAGOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5E181( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption5E0( ) ;
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
            EndLevel5E181( ) ;
         }
         CloseExtendedTableCursors5E181( ) ;
      }

      protected void DeferredUpdate5E181( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate5E181( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5E181( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5E181( ) ;
            AfterConfirm5E181( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5E181( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005E14 */
                  pr_default.execute(12, new Object[] {A412PagReg, A419PagItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("TSPAGOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound181 == 0 )
                        {
                           InitAll5E181( ) ;
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
                        ResetCaption5E0( ) ;
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
         sMode181 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5E181( ) ;
         Gx_mode = sMode181;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5E181( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel5E181( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5E181( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tspagosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tspagosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5E181( )
      {
         /* Using cursor T005E15 */
         pr_default.execute(13);
         RcdFound181 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound181 = 1;
            A412PagReg = T005E15_A412PagReg[0];
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            A419PagItem = T005E15_A419PagItem[0];
            AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5E181( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound181 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound181 = 1;
            A412PagReg = T005E15_A412PagReg[0];
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            A419PagItem = T005E15_A419PagItem[0];
            AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
         }
      }

      protected void ScanEnd5E181( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm5E181( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5E181( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5E181( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5E181( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5E181( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5E181( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5E181( )
      {
         edtPagReg_Enabled = 0;
         AssignProp("", false, edtPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagReg_Enabled), 5, 0), true);
         edtPagItem_Enabled = 0;
         AssignProp("", false, edtPagItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagItem_Enabled), 5, 0), true);
         edtPagDTipCod_Enabled = 0;
         AssignProp("", false, edtPagDTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDTipCod_Enabled), 5, 0), true);
         edtPagDComCod_Enabled = 0;
         AssignProp("", false, edtPagDComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDComCod_Enabled), 5, 0), true);
         edtPagDTot_Enabled = 0;
         AssignProp("", false, edtPagDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDTot_Enabled), 5, 0), true);
         edtPagDImp_Enabled = 0;
         AssignProp("", false, edtPagDImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDImp_Enabled), 5, 0), true);
         edtPagDCanje_Enabled = 0;
         AssignProp("", false, edtPagDCanje_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDCanje_Enabled), 5, 0), true);
         edtPagDCajaC_Enabled = 0;
         AssignProp("", false, edtPagDCajaC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDCajaC_Enabled), 5, 0), true);
         edtPagDAnticipo_Enabled = 0;
         AssignProp("", false, edtPagDAnticipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDAnticipo_Enabled), 5, 0), true);
         edtPagDConcepto_Enabled = 0;
         AssignProp("", false, edtPagDConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDConcepto_Enabled), 5, 0), true);
         edtPagDPrvCod_Enabled = 0;
         AssignProp("", false, edtPagDPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagDPrvCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5E181( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5E0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255457", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tspagosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z412PagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z412PagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z419PagItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z419PagItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1481PagDTot", StringUtil.LTrim( StringUtil.NToC( Z1481PagDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1480PagDImp", StringUtil.LTrim( StringUtil.NToC( Z1480PagDImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1478PagDCanje", StringUtil.RTrim( Z1478PagDCanje));
         GxWebStd.gx_hidden_field( context, "Z1477PagDCajaC", StringUtil.RTrim( Z1477PagDCajaC));
         GxWebStd.gx_hidden_field( context, "Z1476PagDAnticipo", StringUtil.RTrim( Z1476PagDAnticipo));
         GxWebStd.gx_hidden_field( context, "Z1479PagDConcepto", Z1479PagDConcepto);
         GxWebStd.gx_hidden_field( context, "Z420PagDTipCod", StringUtil.RTrim( Z420PagDTipCod));
         GxWebStd.gx_hidden_field( context, "Z421PagDComCod", StringUtil.RTrim( Z421PagDComCod));
         GxWebStd.gx_hidden_field( context, "Z422PagDPrvCod", StringUtil.RTrim( Z422PagDPrvCod));
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
         return formatLink("tspagosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSPAGOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pagos - Detalle" ;
      }

      protected void InitializeNonKey5E181( )
      {
         A420PagDTipCod = "";
         AssignAttri("", false, "A420PagDTipCod", A420PagDTipCod);
         A421PagDComCod = "";
         AssignAttri("", false, "A421PagDComCod", A421PagDComCod);
         A1481PagDTot = 0;
         AssignAttri("", false, "A1481PagDTot", StringUtil.LTrimStr( A1481PagDTot, 15, 2));
         A1480PagDImp = 0;
         AssignAttri("", false, "A1480PagDImp", StringUtil.LTrimStr( A1480PagDImp, 15, 2));
         A1478PagDCanje = "";
         AssignAttri("", false, "A1478PagDCanje", A1478PagDCanje);
         A1477PagDCajaC = "";
         AssignAttri("", false, "A1477PagDCajaC", A1477PagDCajaC);
         A1476PagDAnticipo = "";
         AssignAttri("", false, "A1476PagDAnticipo", A1476PagDAnticipo);
         A1479PagDConcepto = "";
         AssignAttri("", false, "A1479PagDConcepto", A1479PagDConcepto);
         A422PagDPrvCod = "";
         AssignAttri("", false, "A422PagDPrvCod", A422PagDPrvCod);
         Z1481PagDTot = 0;
         Z1480PagDImp = 0;
         Z1478PagDCanje = "";
         Z1477PagDCajaC = "";
         Z1476PagDAnticipo = "";
         Z1479PagDConcepto = "";
         Z420PagDTipCod = "";
         Z421PagDComCod = "";
         Z422PagDPrvCod = "";
      }

      protected void InitAll5E181( )
      {
         A412PagReg = 0;
         AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
         A419PagItem = 0;
         AssignAttri("", false, "A419PagItem", StringUtil.LTrimStr( (decimal)(A419PagItem), 4, 0));
         InitializeNonKey5E181( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810255468", true, true);
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
         context.AddJavascriptSource("tspagosdet.js", "?202281810255468", false, true);
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
         edtPagReg_Internalname = "PAGREG";
         edtPagItem_Internalname = "PAGITEM";
         edtPagDTipCod_Internalname = "PAGDTIPCOD";
         edtPagDComCod_Internalname = "PAGDCOMCOD";
         edtPagDTot_Internalname = "PAGDTOT";
         edtPagDImp_Internalname = "PAGDIMP";
         edtPagDCanje_Internalname = "PAGDCANJE";
         edtPagDCajaC_Internalname = "PAGDCAJAC";
         edtPagDAnticipo_Internalname = "PAGDANTICIPO";
         edtPagDConcepto_Internalname = "PAGDCONCEPTO";
         edtPagDPrvCod_Internalname = "PAGDPRVCOD";
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
         Form.Caption = "Pagos - Detalle";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPagDPrvCod_Jsonclick = "";
         edtPagDPrvCod_Enabled = 1;
         edtPagDConcepto_Jsonclick = "";
         edtPagDConcepto_Enabled = 1;
         edtPagDAnticipo_Jsonclick = "";
         edtPagDAnticipo_Enabled = 1;
         edtPagDCajaC_Jsonclick = "";
         edtPagDCajaC_Enabled = 1;
         edtPagDCanje_Jsonclick = "";
         edtPagDCanje_Enabled = 1;
         edtPagDImp_Jsonclick = "";
         edtPagDImp_Enabled = 1;
         edtPagDTot_Jsonclick = "";
         edtPagDTot_Enabled = 1;
         edtPagDComCod_Jsonclick = "";
         edtPagDComCod_Enabled = 1;
         edtPagDTipCod_Jsonclick = "";
         edtPagDTipCod_Enabled = 1;
         edtPagItem_Jsonclick = "";
         edtPagItem_Enabled = 1;
         edtPagReg_Jsonclick = "";
         edtPagReg_Enabled = 1;
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
         /* Using cursor T005E16 */
         pr_default.execute(14, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Pagos a proveedores'.", "ForeignKeyNotFound", 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtPagDTipCod_Internalname;
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

      public void Valid_Pagreg( )
      {
         /* Using cursor T005E16 */
         pr_default.execute(14, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Pagos a proveedores'.", "ForeignKeyNotFound", 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pagitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A420PagDTipCod", StringUtil.RTrim( A420PagDTipCod));
         AssignAttri("", false, "A421PagDComCod", StringUtil.RTrim( A421PagDComCod));
         AssignAttri("", false, "A1481PagDTot", StringUtil.LTrim( StringUtil.NToC( A1481PagDTot, 15, 2, ".", "")));
         AssignAttri("", false, "A1480PagDImp", StringUtil.LTrim( StringUtil.NToC( A1480PagDImp, 15, 2, ".", "")));
         AssignAttri("", false, "A1478PagDCanje", StringUtil.RTrim( A1478PagDCanje));
         AssignAttri("", false, "A1477PagDCajaC", StringUtil.RTrim( A1477PagDCajaC));
         AssignAttri("", false, "A1476PagDAnticipo", StringUtil.RTrim( A1476PagDAnticipo));
         AssignAttri("", false, "A1479PagDConcepto", A1479PagDConcepto);
         AssignAttri("", false, "A422PagDPrvCod", StringUtil.RTrim( A422PagDPrvCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z412PagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z412PagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z419PagItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z419PagItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z420PagDTipCod", StringUtil.RTrim( Z420PagDTipCod));
         GxWebStd.gx_hidden_field( context, "Z421PagDComCod", StringUtil.RTrim( Z421PagDComCod));
         GxWebStd.gx_hidden_field( context, "Z1481PagDTot", StringUtil.LTrim( StringUtil.NToC( Z1481PagDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1480PagDImp", StringUtil.LTrim( StringUtil.NToC( Z1480PagDImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1478PagDCanje", StringUtil.RTrim( Z1478PagDCanje));
         GxWebStd.gx_hidden_field( context, "Z1477PagDCajaC", StringUtil.RTrim( Z1477PagDCajaC));
         GxWebStd.gx_hidden_field( context, "Z1476PagDAnticipo", StringUtil.RTrim( Z1476PagDAnticipo));
         GxWebStd.gx_hidden_field( context, "Z1479PagDConcepto", Z1479PagDConcepto);
         GxWebStd.gx_hidden_field( context, "Z422PagDPrvCod", StringUtil.RTrim( Z422PagDPrvCod));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Pagdprvcod( )
      {
         /* Using cursor T005E17 */
         pr_default.execute(15, new Object[] {A420PagDTipCod, A421PagDComCod, A422PagDPrvCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Pagos Detalle Proveedor'.", "ForeignKeyNotFound", 1, "PAGDPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPagDTipCod_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_PAGREG","{handler:'Valid_Pagreg',iparms:[{av:'A412PagReg',fld:'PAGREG',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("VALID_PAGREG",",oparms:[]}");
         setEventMetadata("VALID_PAGITEM","{handler:'Valid_Pagitem',iparms:[{av:'A412PagReg',fld:'PAGREG',pic:'ZZZZZZZZZ9'},{av:'A419PagItem',fld:'PAGITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PAGITEM",",oparms:[{av:'A420PagDTipCod',fld:'PAGDTIPCOD',pic:''},{av:'A421PagDComCod',fld:'PAGDCOMCOD',pic:''},{av:'A1481PagDTot',fld:'PAGDTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1480PagDImp',fld:'PAGDIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1478PagDCanje',fld:'PAGDCANJE',pic:''},{av:'A1477PagDCajaC',fld:'PAGDCAJAC',pic:''},{av:'A1476PagDAnticipo',fld:'PAGDANTICIPO',pic:''},{av:'A1479PagDConcepto',fld:'PAGDCONCEPTO',pic:''},{av:'A422PagDPrvCod',fld:'PAGDPRVCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z412PagReg'},{av:'Z419PagItem'},{av:'Z420PagDTipCod'},{av:'Z421PagDComCod'},{av:'Z1481PagDTot'},{av:'Z1480PagDImp'},{av:'Z1478PagDCanje'},{av:'Z1477PagDCajaC'},{av:'Z1476PagDAnticipo'},{av:'Z1479PagDConcepto'},{av:'Z422PagDPrvCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PAGDTIPCOD","{handler:'Valid_Pagdtipcod',iparms:[]");
         setEventMetadata("VALID_PAGDTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_PAGDCOMCOD","{handler:'Valid_Pagdcomcod',iparms:[]");
         setEventMetadata("VALID_PAGDCOMCOD",",oparms:[]}");
         setEventMetadata("VALID_PAGDPRVCOD","{handler:'Valid_Pagdprvcod',iparms:[{av:'A420PagDTipCod',fld:'PAGDTIPCOD',pic:''},{av:'A421PagDComCod',fld:'PAGDCOMCOD',pic:''},{av:'A422PagDPrvCod',fld:'PAGDPRVCOD',pic:'@!'}]");
         setEventMetadata("VALID_PAGDPRVCOD",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1478PagDCanje = "";
         Z1477PagDCajaC = "";
         Z1476PagDAnticipo = "";
         Z1479PagDConcepto = "";
         Z420PagDTipCod = "";
         Z421PagDComCod = "";
         Z422PagDPrvCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A420PagDTipCod = "";
         A421PagDComCod = "";
         A422PagDPrvCod = "";
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
         A1478PagDCanje = "";
         A1477PagDCajaC = "";
         A1476PagDAnticipo = "";
         A1479PagDConcepto = "";
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
         T005E6_A419PagItem = new short[1] ;
         T005E6_A1481PagDTot = new decimal[1] ;
         T005E6_A1480PagDImp = new decimal[1] ;
         T005E6_A1478PagDCanje = new string[] {""} ;
         T005E6_A1477PagDCajaC = new string[] {""} ;
         T005E6_A1476PagDAnticipo = new string[] {""} ;
         T005E6_A1479PagDConcepto = new string[] {""} ;
         T005E6_A412PagReg = new long[1] ;
         T005E6_A420PagDTipCod = new string[] {""} ;
         T005E6_A421PagDComCod = new string[] {""} ;
         T005E6_A422PagDPrvCod = new string[] {""} ;
         T005E4_A412PagReg = new long[1] ;
         T005E5_A420PagDTipCod = new string[] {""} ;
         T005E7_A412PagReg = new long[1] ;
         T005E8_A420PagDTipCod = new string[] {""} ;
         T005E9_A412PagReg = new long[1] ;
         T005E9_A419PagItem = new short[1] ;
         T005E3_A419PagItem = new short[1] ;
         T005E3_A1481PagDTot = new decimal[1] ;
         T005E3_A1480PagDImp = new decimal[1] ;
         T005E3_A1478PagDCanje = new string[] {""} ;
         T005E3_A1477PagDCajaC = new string[] {""} ;
         T005E3_A1476PagDAnticipo = new string[] {""} ;
         T005E3_A1479PagDConcepto = new string[] {""} ;
         T005E3_A412PagReg = new long[1] ;
         T005E3_A420PagDTipCod = new string[] {""} ;
         T005E3_A421PagDComCod = new string[] {""} ;
         T005E3_A422PagDPrvCod = new string[] {""} ;
         sMode181 = "";
         T005E10_A412PagReg = new long[1] ;
         T005E10_A419PagItem = new short[1] ;
         T005E11_A412PagReg = new long[1] ;
         T005E11_A419PagItem = new short[1] ;
         T005E2_A419PagItem = new short[1] ;
         T005E2_A1481PagDTot = new decimal[1] ;
         T005E2_A1480PagDImp = new decimal[1] ;
         T005E2_A1478PagDCanje = new string[] {""} ;
         T005E2_A1477PagDCajaC = new string[] {""} ;
         T005E2_A1476PagDAnticipo = new string[] {""} ;
         T005E2_A1479PagDConcepto = new string[] {""} ;
         T005E2_A412PagReg = new long[1] ;
         T005E2_A420PagDTipCod = new string[] {""} ;
         T005E2_A421PagDComCod = new string[] {""} ;
         T005E2_A422PagDPrvCod = new string[] {""} ;
         T005E15_A412PagReg = new long[1] ;
         T005E15_A419PagItem = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T005E16_A412PagReg = new long[1] ;
         ZZ420PagDTipCod = "";
         ZZ421PagDComCod = "";
         ZZ1478PagDCanje = "";
         ZZ1477PagDCajaC = "";
         ZZ1476PagDAnticipo = "";
         ZZ1479PagDConcepto = "";
         ZZ422PagDPrvCod = "";
         T005E17_A420PagDTipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tspagosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tspagosdet__default(),
            new Object[][] {
                new Object[] {
               T005E2_A419PagItem, T005E2_A1481PagDTot, T005E2_A1480PagDImp, T005E2_A1478PagDCanje, T005E2_A1477PagDCajaC, T005E2_A1476PagDAnticipo, T005E2_A1479PagDConcepto, T005E2_A412PagReg, T005E2_A420PagDTipCod, T005E2_A421PagDComCod,
               T005E2_A422PagDPrvCod
               }
               , new Object[] {
               T005E3_A419PagItem, T005E3_A1481PagDTot, T005E3_A1480PagDImp, T005E3_A1478PagDCanje, T005E3_A1477PagDCajaC, T005E3_A1476PagDAnticipo, T005E3_A1479PagDConcepto, T005E3_A412PagReg, T005E3_A420PagDTipCod, T005E3_A421PagDComCod,
               T005E3_A422PagDPrvCod
               }
               , new Object[] {
               T005E4_A412PagReg
               }
               , new Object[] {
               T005E5_A420PagDTipCod
               }
               , new Object[] {
               T005E6_A419PagItem, T005E6_A1481PagDTot, T005E6_A1480PagDImp, T005E6_A1478PagDCanje, T005E6_A1477PagDCajaC, T005E6_A1476PagDAnticipo, T005E6_A1479PagDConcepto, T005E6_A412PagReg, T005E6_A420PagDTipCod, T005E6_A421PagDComCod,
               T005E6_A422PagDPrvCod
               }
               , new Object[] {
               T005E7_A412PagReg
               }
               , new Object[] {
               T005E8_A420PagDTipCod
               }
               , new Object[] {
               T005E9_A412PagReg, T005E9_A419PagItem
               }
               , new Object[] {
               T005E10_A412PagReg, T005E10_A419PagItem
               }
               , new Object[] {
               T005E11_A412PagReg, T005E11_A419PagItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005E15_A412PagReg, T005E15_A419PagItem
               }
               , new Object[] {
               T005E16_A412PagReg
               }
               , new Object[] {
               T005E17_A420PagDTipCod
               }
            }
         );
      }

      private short Z419PagItem ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A419PagItem ;
      private short GX_JID ;
      private short RcdFound181 ;
      private short nIsDirty_181 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ419PagItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPagReg_Enabled ;
      private int edtPagItem_Enabled ;
      private int edtPagDTipCod_Enabled ;
      private int edtPagDComCod_Enabled ;
      private int edtPagDTot_Enabled ;
      private int edtPagDImp_Enabled ;
      private int edtPagDCanje_Enabled ;
      private int edtPagDCajaC_Enabled ;
      private int edtPagDAnticipo_Enabled ;
      private int edtPagDConcepto_Enabled ;
      private int edtPagDPrvCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z412PagReg ;
      private long A412PagReg ;
      private long ZZ412PagReg ;
      private decimal Z1481PagDTot ;
      private decimal Z1480PagDImp ;
      private decimal A1481PagDTot ;
      private decimal A1480PagDImp ;
      private decimal ZZ1481PagDTot ;
      private decimal ZZ1480PagDImp ;
      private string sPrefix ;
      private string Z1478PagDCanje ;
      private string Z1477PagDCajaC ;
      private string Z1476PagDAnticipo ;
      private string Z420PagDTipCod ;
      private string Z421PagDComCod ;
      private string Z422PagDPrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A420PagDTipCod ;
      private string A421PagDComCod ;
      private string A422PagDPrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPagReg_Internalname ;
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
      private string edtPagReg_Jsonclick ;
      private string edtPagItem_Internalname ;
      private string edtPagItem_Jsonclick ;
      private string edtPagDTipCod_Internalname ;
      private string edtPagDTipCod_Jsonclick ;
      private string edtPagDComCod_Internalname ;
      private string edtPagDComCod_Jsonclick ;
      private string edtPagDTot_Internalname ;
      private string edtPagDTot_Jsonclick ;
      private string edtPagDImp_Internalname ;
      private string edtPagDImp_Jsonclick ;
      private string edtPagDCanje_Internalname ;
      private string A1478PagDCanje ;
      private string edtPagDCanje_Jsonclick ;
      private string edtPagDCajaC_Internalname ;
      private string A1477PagDCajaC ;
      private string edtPagDCajaC_Jsonclick ;
      private string edtPagDAnticipo_Internalname ;
      private string A1476PagDAnticipo ;
      private string edtPagDAnticipo_Jsonclick ;
      private string edtPagDConcepto_Internalname ;
      private string edtPagDConcepto_Jsonclick ;
      private string edtPagDPrvCod_Internalname ;
      private string edtPagDPrvCod_Jsonclick ;
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
      private string sMode181 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ420PagDTipCod ;
      private string ZZ421PagDComCod ;
      private string ZZ1478PagDCanje ;
      private string ZZ1477PagDCajaC ;
      private string ZZ1476PagDAnticipo ;
      private string ZZ422PagDPrvCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z1479PagDConcepto ;
      private string A1479PagDConcepto ;
      private string ZZ1479PagDConcepto ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T005E6_A419PagItem ;
      private decimal[] T005E6_A1481PagDTot ;
      private decimal[] T005E6_A1480PagDImp ;
      private string[] T005E6_A1478PagDCanje ;
      private string[] T005E6_A1477PagDCajaC ;
      private string[] T005E6_A1476PagDAnticipo ;
      private string[] T005E6_A1479PagDConcepto ;
      private long[] T005E6_A412PagReg ;
      private string[] T005E6_A420PagDTipCod ;
      private string[] T005E6_A421PagDComCod ;
      private string[] T005E6_A422PagDPrvCod ;
      private long[] T005E4_A412PagReg ;
      private string[] T005E5_A420PagDTipCod ;
      private long[] T005E7_A412PagReg ;
      private string[] T005E8_A420PagDTipCod ;
      private long[] T005E9_A412PagReg ;
      private short[] T005E9_A419PagItem ;
      private short[] T005E3_A419PagItem ;
      private decimal[] T005E3_A1481PagDTot ;
      private decimal[] T005E3_A1480PagDImp ;
      private string[] T005E3_A1478PagDCanje ;
      private string[] T005E3_A1477PagDCajaC ;
      private string[] T005E3_A1476PagDAnticipo ;
      private string[] T005E3_A1479PagDConcepto ;
      private long[] T005E3_A412PagReg ;
      private string[] T005E3_A420PagDTipCod ;
      private string[] T005E3_A421PagDComCod ;
      private string[] T005E3_A422PagDPrvCod ;
      private long[] T005E10_A412PagReg ;
      private short[] T005E10_A419PagItem ;
      private long[] T005E11_A412PagReg ;
      private short[] T005E11_A419PagItem ;
      private short[] T005E2_A419PagItem ;
      private decimal[] T005E2_A1481PagDTot ;
      private decimal[] T005E2_A1480PagDImp ;
      private string[] T005E2_A1478PagDCanje ;
      private string[] T005E2_A1477PagDCajaC ;
      private string[] T005E2_A1476PagDAnticipo ;
      private string[] T005E2_A1479PagDConcepto ;
      private long[] T005E2_A412PagReg ;
      private string[] T005E2_A420PagDTipCod ;
      private string[] T005E2_A421PagDComCod ;
      private string[] T005E2_A422PagDPrvCod ;
      private long[] T005E15_A412PagReg ;
      private short[] T005E15_A419PagItem ;
      private long[] T005E16_A412PagReg ;
      private string[] T005E17_A420PagDTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tspagosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tspagosdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT005E6;
        prmT005E6 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E4;
        prmT005E4 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005E5;
        prmT005E5 = new Object[] {
        new ParDef("@PagDTipCod",GXType.NChar,3,0) ,
        new ParDef("@PagDComCod",GXType.NChar,15,0) ,
        new ParDef("@PagDPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005E7;
        prmT005E7 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005E8;
        prmT005E8 = new Object[] {
        new ParDef("@PagDTipCod",GXType.NChar,3,0) ,
        new ParDef("@PagDComCod",GXType.NChar,15,0) ,
        new ParDef("@PagDPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005E9;
        prmT005E9 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E3;
        prmT005E3 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E10;
        prmT005E10 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E11;
        prmT005E11 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E2;
        prmT005E2 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E12;
        prmT005E12 = new Object[] {
        new ParDef("@PagItem",GXType.Int16,4,0) ,
        new ParDef("@PagDTot",GXType.Decimal,15,2) ,
        new ParDef("@PagDImp",GXType.Decimal,15,2) ,
        new ParDef("@PagDCanje",GXType.NChar,10,0) ,
        new ParDef("@PagDCajaC",GXType.NChar,10,0) ,
        new ParDef("@PagDAnticipo",GXType.NChar,10,0) ,
        new ParDef("@PagDConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagDTipCod",GXType.NChar,3,0) ,
        new ParDef("@PagDComCod",GXType.NChar,15,0) ,
        new ParDef("@PagDPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005E13;
        prmT005E13 = new Object[] {
        new ParDef("@PagDTot",GXType.Decimal,15,2) ,
        new ParDef("@PagDImp",GXType.Decimal,15,2) ,
        new ParDef("@PagDCanje",GXType.NChar,10,0) ,
        new ParDef("@PagDCajaC",GXType.NChar,10,0) ,
        new ParDef("@PagDAnticipo",GXType.NChar,10,0) ,
        new ParDef("@PagDConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@PagDTipCod",GXType.NChar,3,0) ,
        new ParDef("@PagDComCod",GXType.NChar,15,0) ,
        new ParDef("@PagDPrvCod",GXType.NChar,20,0) ,
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E14;
        prmT005E14 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagItem",GXType.Int16,4,0)
        };
        Object[] prmT005E15;
        prmT005E15 = new Object[] {
        };
        Object[] prmT005E16;
        prmT005E16 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005E17;
        prmT005E17 = new Object[] {
        new ParDef("@PagDTipCod",GXType.NChar,3,0) ,
        new ParDef("@PagDComCod",GXType.NChar,15,0) ,
        new ParDef("@PagDPrvCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005E2", "SELECT [PagItem], [PagDTot], [PagDImp], [PagDCanje], [PagDCajaC], [PagDAnticipo], [PagDConcepto], [PagReg], [PagDTipCod] AS PagDTipCod, [PagDComCod] AS PagDComCod, [PagDPrvCod] AS PagDPrvCod FROM [TSPAGOSDET] WITH (UPDLOCK) WHERE [PagReg] = @PagReg AND [PagItem] = @PagItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E3", "SELECT [PagItem], [PagDTot], [PagDImp], [PagDCanje], [PagDCajaC], [PagDAnticipo], [PagDConcepto], [PagReg], [PagDTipCod] AS PagDTipCod, [PagDComCod] AS PagDComCod, [PagDPrvCod] AS PagDPrvCod FROM [TSPAGOSDET] WHERE [PagReg] = @PagReg AND [PagItem] = @PagItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E4", "SELECT [PagReg] FROM [TSPAGOS] WHERE [PagReg] = @PagReg ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E5", "SELECT [CPTipCod] AS PagDTipCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @PagDTipCod AND [CPComCod] = @PagDComCod AND [CPPrvCod] = @PagDPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E6", "SELECT TM1.[PagItem], TM1.[PagDTot], TM1.[PagDImp], TM1.[PagDCanje], TM1.[PagDCajaC], TM1.[PagDAnticipo], TM1.[PagDConcepto], TM1.[PagReg], TM1.[PagDTipCod] AS PagDTipCod, TM1.[PagDComCod] AS PagDComCod, TM1.[PagDPrvCod] AS PagDPrvCod FROM [TSPAGOSDET] TM1 WHERE TM1.[PagReg] = @PagReg and TM1.[PagItem] = @PagItem ORDER BY TM1.[PagReg], TM1.[PagItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E7", "SELECT [PagReg] FROM [TSPAGOS] WHERE [PagReg] = @PagReg ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E8", "SELECT [CPTipCod] AS PagDTipCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @PagDTipCod AND [CPComCod] = @PagDComCod AND [CPPrvCod] = @PagDPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E9", "SELECT [PagReg], [PagItem] FROM [TSPAGOSDET] WHERE [PagReg] = @PagReg AND [PagItem] = @PagItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005E9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E10", "SELECT TOP 1 [PagReg], [PagItem] FROM [TSPAGOSDET] WHERE ( [PagReg] > @PagReg or [PagReg] = @PagReg and [PagItem] > @PagItem) ORDER BY [PagReg], [PagItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005E10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005E11", "SELECT TOP 1 [PagReg], [PagItem] FROM [TSPAGOSDET] WHERE ( [PagReg] < @PagReg or [PagReg] = @PagReg and [PagItem] < @PagItem) ORDER BY [PagReg] DESC, [PagItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005E12", "INSERT INTO [TSPAGOSDET]([PagItem], [PagDTot], [PagDImp], [PagDCanje], [PagDCajaC], [PagDAnticipo], [PagDConcepto], [PagReg], [PagDTipCod], [PagDComCod], [PagDPrvCod]) VALUES(@PagItem, @PagDTot, @PagDImp, @PagDCanje, @PagDCajaC, @PagDAnticipo, @PagDConcepto, @PagReg, @PagDTipCod, @PagDComCod, @PagDPrvCod)", GxErrorMask.GX_NOMASK,prmT005E12)
           ,new CursorDef("T005E13", "UPDATE [TSPAGOSDET] SET [PagDTot]=@PagDTot, [PagDImp]=@PagDImp, [PagDCanje]=@PagDCanje, [PagDCajaC]=@PagDCajaC, [PagDAnticipo]=@PagDAnticipo, [PagDConcepto]=@PagDConcepto, [PagDTipCod]=@PagDTipCod, [PagDComCod]=@PagDComCod, [PagDPrvCod]=@PagDPrvCod  WHERE [PagReg] = @PagReg AND [PagItem] = @PagItem", GxErrorMask.GX_NOMASK,prmT005E13)
           ,new CursorDef("T005E14", "DELETE FROM [TSPAGOSDET]  WHERE [PagReg] = @PagReg AND [PagItem] = @PagItem", GxErrorMask.GX_NOMASK,prmT005E14)
           ,new CursorDef("T005E15", "SELECT [PagReg], [PagItem] FROM [TSPAGOSDET] ORDER BY [PagReg], [PagItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005E15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E16", "SELECT [PagReg] FROM [TSPAGOS] WHERE [PagReg] = @PagReg ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005E17", "SELECT [CPTipCod] AS PagDTipCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @PagDTipCod AND [CPComCod] = @PagDComCod AND [CPPrvCod] = @PagDPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005E17,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
