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
   public class actactivosdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A2100ACTActCod = GetPar( "ACTActCod");
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A2100ACTActCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A426ACTClaCod = GetPar( "ACTClaCod");
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A426ACTClaCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A426ACTClaCod = GetPar( "ACTClaCod");
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = GetPar( "ACTGrupCod");
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = GetPar( "ACTSGrupCod");
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod) ;
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
            Form.Meta.addItem("description", "ACTACTIVOSDET", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actactivosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actactivosdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ACTACTIVOSDET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTACTIVOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTACTIVOSDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActCod_Internalname, "Codigo Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActActItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActActItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTSGrupCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTSGrupCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSGrupCod_Internalname, A2114ACTSGrupCod, StringUtil.RTrim( context.localUtil.Format( A2114ACTSGrupCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTSGrupDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTSGrupDsc_Internalname, "Descomposición", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtACTSGrupDsc_Internalname, StringUtil.RTrim( A2155ACTSGrupDsc), StringUtil.RTrim( context.localUtil.Format( A2155ACTSGrupDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSGrupDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTSGrupPor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTSGrupPor_Internalname, "% Distribución", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtACTSGrupPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2156ACTSGrupPor, 6, 2, ".", "")), StringUtil.LTrim( ((edtACTSGrupPor_Enabled!=0) ? context.localUtil.Format( A2156ACTSGrupPor, "ZZ9.99") : context.localUtil.Format( A2156ACTSGrupPor, "ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupPor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSGrupPor_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetParte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetParte_Internalname, "Parte", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetParte_Internalname, A2146ACTDetParte, StringUtil.RTrim( context.localUtil.Format( A2146ACTDetParte, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetParte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetParte_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetSerie_Internalname, "Serie", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetSerie_Internalname, A2147ACTDetSerie, StringUtil.RTrim( context.localUtil.Format( A2147ACTDetSerie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetSerie_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetModelo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetModelo_Internalname, "Modelo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetModelo_Internalname, A2145ACTDetModelo, StringUtil.RTrim( context.localUtil.Format( A2145ACTDetModelo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetModelo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetModelo_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetMarca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetMarca_Internalname, "Marca", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetMarca_Internalname, A2144ACTDetMarca, StringUtil.RTrim( context.localUtil.Format( A2144ACTDetMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetMarca_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetAno_Internalname, "Fabricación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetAno_Internalname, A2140ACTDetAno, StringUtil.RTrim( context.localUtil.Format( A2140ACTDetAno, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetAno_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetCap_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetCap_Internalname, "Capacidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetCap_Internalname, A2142ACTDetCap, StringUtil.RTrim( context.localUtil.Format( A2142ACTDetCap, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetCap_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetCap_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetFecIni_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetFecIni_Internalname, "Inic. Depreciacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTDetFecIni_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTDetFecIni_Internalname, context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"), context.localUtil.Format( A2143ACTDetFecIni, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetFecIni_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetFecIni_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_bitmap( context, edtACTDetFecIni_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTDetFecIni_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTACTIVOSDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetValorNeto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetValorNeto_Internalname, "Neto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetValorNeto_Internalname, StringUtil.LTrim( StringUtil.NToC( A2150ACTDetValorNeto, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTDetValorNeto_Enabled!=0) ? context.localUtil.Format( A2150ACTDetValorNeto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2150ACTDetValorNeto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetValorNeto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetValorNeto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetValorResiduo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetValorResiduo_Internalname, "Residual", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetValorResiduo_Internalname, StringUtil.LTrim( StringUtil.NToC( A2152ACTDetValorResiduo, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTDetValorResiduo_Enabled!=0) ? context.localUtil.Format( A2152ACTDetValorResiduo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2152ACTDetValorResiduo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetValorResiduo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetValorResiduo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetVidaUtil_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetVidaUtil_Internalname, "Util Estimada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetVidaUtil_Internalname, StringUtil.LTrim( StringUtil.NToC( A2154ACTDetVidaUtil, 6, 2, ".", "")), StringUtil.LTrim( ((edtACTDetVidaUtil_Enabled!=0) ? context.localUtil.Format( A2154ACTDetVidaUtil, "ZZ9.99") : context.localUtil.Format( A2154ACTDetVidaUtil, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetVidaUtil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetVidaUtil_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetValorReparacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetValorReparacion_Internalname, "Reparaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetValorReparacion_Internalname, StringUtil.LTrim( StringUtil.NToC( A2151ACTDetValorReparacion, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTDetValorReparacion_Enabled!=0) ? context.localUtil.Format( A2151ACTDetValorReparacion, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2151ACTDetValorReparacion, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetValorReparacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetValorReparacion_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetValorCompras_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetValorCompras_Internalname, "Compras Nuevas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetValorCompras_Internalname, StringUtil.LTrim( StringUtil.NToC( A2149ACTDetValorCompras, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTDetValorCompras_Enabled!=0) ? context.localUtil.Format( A2149ACTDetValorCompras, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2149ACTDetValorCompras, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetValorCompras_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetValorCompras_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetValorRetiro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetValorRetiro_Internalname, "Retiros", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetValorRetiro_Internalname, StringUtil.LTrim( StringUtil.NToC( A2153ACTDetValorRetiro, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTDetValorRetiro_Enabled!=0) ? context.localUtil.Format( A2153ACTDetValorRetiro, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2153ACTDetValorRetiro, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetValorRetiro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetValorRetiro_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTClaCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTClaCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtACTClaCod_Internalname, A426ACTClaCod, StringUtil.RTrim( context.localUtil.Format( A426ACTClaCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTClaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTGrupCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTGrupCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtACTGrupCod_Internalname, A2103ACTGrupCod, StringUtil.RTrim( context.localUtil.Format( A2103ACTGrupCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTDetSts_Internalname, A2148ACTDetSts, StringUtil.RTrim( context.localUtil.Format( A2148ACTDetSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTDetBajFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTDetBajFec_Internalname, "Baja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTDetBajFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTDetBajFec_Internalname, context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"), context.localUtil.Format( A2141ACTDetBajFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTDetBajFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTDetBajFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_bitmap( context, edtACTDetBajFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTDetBajFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTACTIVOSDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOSDET.htm");
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
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            Z2146ACTDetParte = cgiGet( "Z2146ACTDetParte");
            Z2147ACTDetSerie = cgiGet( "Z2147ACTDetSerie");
            Z2145ACTDetModelo = cgiGet( "Z2145ACTDetModelo");
            Z2144ACTDetMarca = cgiGet( "Z2144ACTDetMarca");
            Z2140ACTDetAno = cgiGet( "Z2140ACTDetAno");
            Z2142ACTDetCap = cgiGet( "Z2142ACTDetCap");
            Z2143ACTDetFecIni = context.localUtil.CToD( cgiGet( "Z2143ACTDetFecIni"), 0);
            Z2150ACTDetValorNeto = context.localUtil.CToN( cgiGet( "Z2150ACTDetValorNeto"), ".", ",");
            Z2152ACTDetValorResiduo = context.localUtil.CToN( cgiGet( "Z2152ACTDetValorResiduo"), ".", ",");
            Z2154ACTDetVidaUtil = context.localUtil.CToN( cgiGet( "Z2154ACTDetVidaUtil"), ".", ",");
            Z2151ACTDetValorReparacion = context.localUtil.CToN( cgiGet( "Z2151ACTDetValorReparacion"), ".", ",");
            Z2149ACTDetValorCompras = context.localUtil.CToN( cgiGet( "Z2149ACTDetValorCompras"), ".", ",");
            Z2153ACTDetValorRetiro = context.localUtil.CToN( cgiGet( "Z2153ACTDetValorRetiro"), ".", ",");
            Z2148ACTDetSts = cgiGet( "Z2148ACTDetSts");
            Z2141ACTDetBajFec = context.localUtil.CToD( cgiGet( "Z2141ACTDetBajFec"), 0);
            Z2114ACTSGrupCod = cgiGet( "Z2114ACTSGrupCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            A2114ACTSGrupCod = cgiGet( edtACTSGrupCod_Internalname);
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2155ACTSGrupDsc = cgiGet( edtACTSGrupDsc_Internalname);
            AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
            A2156ACTSGrupPor = context.localUtil.CToN( cgiGet( edtACTSGrupPor_Internalname), ".", ",");
            AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            A2146ACTDetParte = cgiGet( edtACTDetParte_Internalname);
            AssignAttri("", false, "A2146ACTDetParte", A2146ACTDetParte);
            A2147ACTDetSerie = cgiGet( edtACTDetSerie_Internalname);
            AssignAttri("", false, "A2147ACTDetSerie", A2147ACTDetSerie);
            A2145ACTDetModelo = cgiGet( edtACTDetModelo_Internalname);
            AssignAttri("", false, "A2145ACTDetModelo", A2145ACTDetModelo);
            A2144ACTDetMarca = cgiGet( edtACTDetMarca_Internalname);
            AssignAttri("", false, "A2144ACTDetMarca", A2144ACTDetMarca);
            A2140ACTDetAno = cgiGet( edtACTDetAno_Internalname);
            AssignAttri("", false, "A2140ACTDetAno", A2140ACTDetAno);
            A2142ACTDetCap = cgiGet( edtACTDetCap_Internalname);
            AssignAttri("", false, "A2142ACTDetCap", A2142ACTDetCap);
            if ( context.localUtil.VCDate( cgiGet( edtACTDetFecIni_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inic. Depreciacion"}), 1, "ACTDETFECINI");
               AnyError = 1;
               GX_FocusControl = edtACTDetFecIni_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2143ACTDetFecIni = DateTime.MinValue;
               AssignAttri("", false, "A2143ACTDetFecIni", context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"));
            }
            else
            {
               A2143ACTDetFecIni = context.localUtil.CToD( cgiGet( edtACTDetFecIni_Internalname), 2);
               AssignAttri("", false, "A2143ACTDetFecIni", context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTDetValorNeto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTDetValorNeto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTDETVALORNETO");
               AnyError = 1;
               GX_FocusControl = edtACTDetValorNeto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2150ACTDetValorNeto = 0;
               AssignAttri("", false, "A2150ACTDetValorNeto", StringUtil.LTrimStr( A2150ACTDetValorNeto, 15, 2));
            }
            else
            {
               A2150ACTDetValorNeto = context.localUtil.CToN( cgiGet( edtACTDetValorNeto_Internalname), ".", ",");
               AssignAttri("", false, "A2150ACTDetValorNeto", StringUtil.LTrimStr( A2150ACTDetValorNeto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTDetValorResiduo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTDetValorResiduo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTDETVALORRESIDUO");
               AnyError = 1;
               GX_FocusControl = edtACTDetValorResiduo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2152ACTDetValorResiduo = 0;
               AssignAttri("", false, "A2152ACTDetValorResiduo", StringUtil.LTrimStr( A2152ACTDetValorResiduo, 15, 2));
            }
            else
            {
               A2152ACTDetValorResiduo = context.localUtil.CToN( cgiGet( edtACTDetValorResiduo_Internalname), ".", ",");
               AssignAttri("", false, "A2152ACTDetValorResiduo", StringUtil.LTrimStr( A2152ACTDetValorResiduo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTDetVidaUtil_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTDetVidaUtil_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTDETVIDAUTIL");
               AnyError = 1;
               GX_FocusControl = edtACTDetVidaUtil_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2154ACTDetVidaUtil = 0;
               AssignAttri("", false, "A2154ACTDetVidaUtil", StringUtil.LTrimStr( A2154ACTDetVidaUtil, 6, 2));
            }
            else
            {
               A2154ACTDetVidaUtil = context.localUtil.CToN( cgiGet( edtACTDetVidaUtil_Internalname), ".", ",");
               AssignAttri("", false, "A2154ACTDetVidaUtil", StringUtil.LTrimStr( A2154ACTDetVidaUtil, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTDetValorReparacion_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTDetValorReparacion_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTDETVALORREPARACION");
               AnyError = 1;
               GX_FocusControl = edtACTDetValorReparacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2151ACTDetValorReparacion = 0;
               AssignAttri("", false, "A2151ACTDetValorReparacion", StringUtil.LTrimStr( A2151ACTDetValorReparacion, 15, 2));
            }
            else
            {
               A2151ACTDetValorReparacion = context.localUtil.CToN( cgiGet( edtACTDetValorReparacion_Internalname), ".", ",");
               AssignAttri("", false, "A2151ACTDetValorReparacion", StringUtil.LTrimStr( A2151ACTDetValorReparacion, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTDetValorCompras_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTDetValorCompras_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTDETVALORCOMPRAS");
               AnyError = 1;
               GX_FocusControl = edtACTDetValorCompras_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2149ACTDetValorCompras = 0;
               AssignAttri("", false, "A2149ACTDetValorCompras", StringUtil.LTrimStr( A2149ACTDetValorCompras, 15, 2));
            }
            else
            {
               A2149ACTDetValorCompras = context.localUtil.CToN( cgiGet( edtACTDetValorCompras_Internalname), ".", ",");
               AssignAttri("", false, "A2149ACTDetValorCompras", StringUtil.LTrimStr( A2149ACTDetValorCompras, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTDetValorRetiro_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTDetValorRetiro_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTDETVALORRETIRO");
               AnyError = 1;
               GX_FocusControl = edtACTDetValorRetiro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2153ACTDetValorRetiro = 0;
               AssignAttri("", false, "A2153ACTDetValorRetiro", StringUtil.LTrimStr( A2153ACTDetValorRetiro, 15, 2));
            }
            else
            {
               A2153ACTDetValorRetiro = context.localUtil.CToN( cgiGet( edtACTDetValorRetiro_Internalname), ".", ",");
               AssignAttri("", false, "A2153ACTDetValorRetiro", StringUtil.LTrimStr( A2153ACTDetValorRetiro, 15, 2));
            }
            A426ACTClaCod = cgiGet( edtACTClaCod_Internalname);
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = cgiGet( edtACTGrupCod_Internalname);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2148ACTDetSts = cgiGet( edtACTDetSts_Internalname);
            AssignAttri("", false, "A2148ACTDetSts", A2148ACTDetSts);
            if ( context.localUtil.VCDate( cgiGet( edtACTDetBajFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Baja"}), 1, "ACTDETBAJFEC");
               AnyError = 1;
               GX_FocusControl = edtACTDetBajFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2141ACTDetBajFec = DateTime.MinValue;
               AssignAttri("", false, "A2141ACTDetBajFec", context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"));
            }
            else
            {
               A2141ACTDetBajFec = context.localUtil.CToD( cgiGet( edtACTDetBajFec_Internalname), 2);
               AssignAttri("", false, "A2141ACTDetBajFec", context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"));
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
               A2100ACTActCod = GetPar( "ACTActCod");
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               A2104ActActItem = GetPar( "ActActItem");
               n2104ActActItem = false;
               AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
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
               InitAll6R185( ) ;
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
         DisableAttributes6R185( ) ;
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

      protected void ResetCaption6R0( )
      {
      }

      protected void ZM6R185( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2146ACTDetParte = T006R3_A2146ACTDetParte[0];
               Z2147ACTDetSerie = T006R3_A2147ACTDetSerie[0];
               Z2145ACTDetModelo = T006R3_A2145ACTDetModelo[0];
               Z2144ACTDetMarca = T006R3_A2144ACTDetMarca[0];
               Z2140ACTDetAno = T006R3_A2140ACTDetAno[0];
               Z2142ACTDetCap = T006R3_A2142ACTDetCap[0];
               Z2143ACTDetFecIni = T006R3_A2143ACTDetFecIni[0];
               Z2150ACTDetValorNeto = T006R3_A2150ACTDetValorNeto[0];
               Z2152ACTDetValorResiduo = T006R3_A2152ACTDetValorResiduo[0];
               Z2154ACTDetVidaUtil = T006R3_A2154ACTDetVidaUtil[0];
               Z2151ACTDetValorReparacion = T006R3_A2151ACTDetValorReparacion[0];
               Z2149ACTDetValorCompras = T006R3_A2149ACTDetValorCompras[0];
               Z2153ACTDetValorRetiro = T006R3_A2153ACTDetValorRetiro[0];
               Z2148ACTDetSts = T006R3_A2148ACTDetSts[0];
               Z2141ACTDetBajFec = T006R3_A2141ACTDetBajFec[0];
               Z2114ACTSGrupCod = T006R3_A2114ACTSGrupCod[0];
            }
            else
            {
               Z2146ACTDetParte = A2146ACTDetParte;
               Z2147ACTDetSerie = A2147ACTDetSerie;
               Z2145ACTDetModelo = A2145ACTDetModelo;
               Z2144ACTDetMarca = A2144ACTDetMarca;
               Z2140ACTDetAno = A2140ACTDetAno;
               Z2142ACTDetCap = A2142ACTDetCap;
               Z2143ACTDetFecIni = A2143ACTDetFecIni;
               Z2150ACTDetValorNeto = A2150ACTDetValorNeto;
               Z2152ACTDetValorResiduo = A2152ACTDetValorResiduo;
               Z2154ACTDetVidaUtil = A2154ACTDetVidaUtil;
               Z2151ACTDetValorReparacion = A2151ACTDetValorReparacion;
               Z2149ACTDetValorCompras = A2149ACTDetValorCompras;
               Z2153ACTDetValorRetiro = A2153ACTDetValorRetiro;
               Z2148ACTDetSts = A2148ACTDetSts;
               Z2141ACTDetBajFec = A2141ACTDetBajFec;
               Z2114ACTSGrupCod = A2114ACTSGrupCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2104ActActItem = A2104ActActItem;
            Z2146ACTDetParte = A2146ACTDetParte;
            Z2147ACTDetSerie = A2147ACTDetSerie;
            Z2145ACTDetModelo = A2145ACTDetModelo;
            Z2144ACTDetMarca = A2144ACTDetMarca;
            Z2140ACTDetAno = A2140ACTDetAno;
            Z2142ACTDetCap = A2142ACTDetCap;
            Z2143ACTDetFecIni = A2143ACTDetFecIni;
            Z2150ACTDetValorNeto = A2150ACTDetValorNeto;
            Z2152ACTDetValorResiduo = A2152ACTDetValorResiduo;
            Z2154ACTDetVidaUtil = A2154ACTDetVidaUtil;
            Z2151ACTDetValorReparacion = A2151ACTDetValorReparacion;
            Z2149ACTDetValorCompras = A2149ACTDetValorCompras;
            Z2153ACTDetValorRetiro = A2153ACTDetValorRetiro;
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2148ACTDetSts = A2148ACTDetSts;
            Z2141ACTDetBajFec = A2141ACTDetBajFec;
            Z2100ACTActCod = A2100ACTActCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
            Z2155ACTSGrupDsc = A2155ACTSGrupDsc;
            Z2156ACTSGrupPor = A2156ACTSGrupPor;
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

      protected void Load6R185( )
      {
         /* Using cursor T006R7 */
         pr_default.execute(5, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound185 = 1;
            A2155ACTSGrupDsc = T006R7_A2155ACTSGrupDsc[0];
            AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
            A2156ACTSGrupPor = T006R7_A2156ACTSGrupPor[0];
            AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            A2146ACTDetParte = T006R7_A2146ACTDetParte[0];
            AssignAttri("", false, "A2146ACTDetParte", A2146ACTDetParte);
            A2147ACTDetSerie = T006R7_A2147ACTDetSerie[0];
            AssignAttri("", false, "A2147ACTDetSerie", A2147ACTDetSerie);
            A2145ACTDetModelo = T006R7_A2145ACTDetModelo[0];
            AssignAttri("", false, "A2145ACTDetModelo", A2145ACTDetModelo);
            A2144ACTDetMarca = T006R7_A2144ACTDetMarca[0];
            AssignAttri("", false, "A2144ACTDetMarca", A2144ACTDetMarca);
            A2140ACTDetAno = T006R7_A2140ACTDetAno[0];
            AssignAttri("", false, "A2140ACTDetAno", A2140ACTDetAno);
            A2142ACTDetCap = T006R7_A2142ACTDetCap[0];
            AssignAttri("", false, "A2142ACTDetCap", A2142ACTDetCap);
            A2143ACTDetFecIni = T006R7_A2143ACTDetFecIni[0];
            AssignAttri("", false, "A2143ACTDetFecIni", context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"));
            A2150ACTDetValorNeto = T006R7_A2150ACTDetValorNeto[0];
            AssignAttri("", false, "A2150ACTDetValorNeto", StringUtil.LTrimStr( A2150ACTDetValorNeto, 15, 2));
            A2152ACTDetValorResiduo = T006R7_A2152ACTDetValorResiduo[0];
            AssignAttri("", false, "A2152ACTDetValorResiduo", StringUtil.LTrimStr( A2152ACTDetValorResiduo, 15, 2));
            A2154ACTDetVidaUtil = T006R7_A2154ACTDetVidaUtil[0];
            AssignAttri("", false, "A2154ACTDetVidaUtil", StringUtil.LTrimStr( A2154ACTDetVidaUtil, 6, 2));
            A2151ACTDetValorReparacion = T006R7_A2151ACTDetValorReparacion[0];
            AssignAttri("", false, "A2151ACTDetValorReparacion", StringUtil.LTrimStr( A2151ACTDetValorReparacion, 15, 2));
            A2149ACTDetValorCompras = T006R7_A2149ACTDetValorCompras[0];
            AssignAttri("", false, "A2149ACTDetValorCompras", StringUtil.LTrimStr( A2149ACTDetValorCompras, 15, 2));
            A2153ACTDetValorRetiro = T006R7_A2153ACTDetValorRetiro[0];
            AssignAttri("", false, "A2153ACTDetValorRetiro", StringUtil.LTrimStr( A2153ACTDetValorRetiro, 15, 2));
            A426ACTClaCod = T006R7_A426ACTClaCod[0];
            n426ACTClaCod = T006R7_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006R7_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2148ACTDetSts = T006R7_A2148ACTDetSts[0];
            AssignAttri("", false, "A2148ACTDetSts", A2148ACTDetSts);
            A2141ACTDetBajFec = T006R7_A2141ACTDetBajFec[0];
            AssignAttri("", false, "A2141ACTDetBajFec", context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"));
            A2114ACTSGrupCod = T006R7_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            ZM6R185( -3) ;
         }
         pr_default.close(5);
         OnLoadActions6R185( ) ;
      }

      protected void OnLoadActions6R185( )
      {
         /* Using cursor T006R4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         A426ACTClaCod = T006R4_A426ACTClaCod[0];
         n426ACTClaCod = T006R4_n426ACTClaCod[0];
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = T006R4_A2103ACTGrupCod[0];
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         pr_default.close(2);
      }

      protected void CheckExtendedTable6R185( )
      {
         nIsDirty_185 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T006R4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A426ACTClaCod = T006R4_A426ACTClaCod[0];
         n426ACTClaCod = T006R4_n426ACTClaCod[0];
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = T006R4_A2103ACTGrupCod[0];
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         pr_default.close(2);
         /* Using cursor T006R6 */
         pr_default.execute(4, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         /* Using cursor T006R5 */
         pr_default.execute(3, new Object[] {n426ACTClaCod, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTSGrupCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2155ACTSGrupDsc = T006R5_A2155ACTSGrupDsc[0];
         AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
         A2156ACTSGrupPor = T006R5_A2156ACTSGrupPor[0];
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A2143ACTDetFecIni) || ( DateTimeUtil.ResetTime ( A2143ACTDetFecIni ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Inic. Depreciacion fuera de rango", "OutOfRange", 1, "ACTDETFECINI");
            AnyError = 1;
            GX_FocusControl = edtACTDetFecIni_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A2141ACTDetBajFec) || ( DateTimeUtil.ResetTime ( A2141ACTDetBajFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Baja fuera de rango", "OutOfRange", 1, "ACTDETBAJFEC");
            AnyError = 1;
            GX_FocusControl = edtACTDetBajFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6R185( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A2100ACTActCod )
      {
         /* Using cursor T006R8 */
         pr_default.execute(6, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A426ACTClaCod = T006R8_A426ACTClaCod[0];
         n426ACTClaCod = T006R8_n426ACTClaCod[0];
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = T006R8_A2103ACTGrupCod[0];
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A426ACTClaCod)+"\""+","+"\""+GXUtil.EncodeJSConstant( A2103ACTGrupCod)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_6( string A426ACTClaCod )
      {
         /* Using cursor T006R9 */
         pr_default.execute(7, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
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

      protected void gxLoad_5( string A426ACTClaCod ,
                               string A2103ACTGrupCod ,
                               string A2114ACTSGrupCod )
      {
         /* Using cursor T006R10 */
         pr_default.execute(8, new Object[] {n426ACTClaCod, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTSGrupCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2155ACTSGrupDsc = T006R10_A2155ACTSGrupDsc[0];
         AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
         A2156ACTSGrupPor = T006R10_A2156ACTSGrupPor[0];
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2155ACTSGrupDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A2156ACTSGrupPor, 6, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey6R185( )
      {
         /* Using cursor T006R11 */
         pr_default.execute(9, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound185 = 1;
         }
         else
         {
            RcdFound185 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006R3 */
         pr_default.execute(1, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6R185( 3) ;
            RcdFound185 = 1;
            A2104ActActItem = T006R3_A2104ActActItem[0];
            n2104ActActItem = T006R3_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            A2146ACTDetParte = T006R3_A2146ACTDetParte[0];
            AssignAttri("", false, "A2146ACTDetParte", A2146ACTDetParte);
            A2147ACTDetSerie = T006R3_A2147ACTDetSerie[0];
            AssignAttri("", false, "A2147ACTDetSerie", A2147ACTDetSerie);
            A2145ACTDetModelo = T006R3_A2145ACTDetModelo[0];
            AssignAttri("", false, "A2145ACTDetModelo", A2145ACTDetModelo);
            A2144ACTDetMarca = T006R3_A2144ACTDetMarca[0];
            AssignAttri("", false, "A2144ACTDetMarca", A2144ACTDetMarca);
            A2140ACTDetAno = T006R3_A2140ACTDetAno[0];
            AssignAttri("", false, "A2140ACTDetAno", A2140ACTDetAno);
            A2142ACTDetCap = T006R3_A2142ACTDetCap[0];
            AssignAttri("", false, "A2142ACTDetCap", A2142ACTDetCap);
            A2143ACTDetFecIni = T006R3_A2143ACTDetFecIni[0];
            AssignAttri("", false, "A2143ACTDetFecIni", context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"));
            A2150ACTDetValorNeto = T006R3_A2150ACTDetValorNeto[0];
            AssignAttri("", false, "A2150ACTDetValorNeto", StringUtil.LTrimStr( A2150ACTDetValorNeto, 15, 2));
            A2152ACTDetValorResiduo = T006R3_A2152ACTDetValorResiduo[0];
            AssignAttri("", false, "A2152ACTDetValorResiduo", StringUtil.LTrimStr( A2152ACTDetValorResiduo, 15, 2));
            A2154ACTDetVidaUtil = T006R3_A2154ACTDetVidaUtil[0];
            AssignAttri("", false, "A2154ACTDetVidaUtil", StringUtil.LTrimStr( A2154ACTDetVidaUtil, 6, 2));
            A2151ACTDetValorReparacion = T006R3_A2151ACTDetValorReparacion[0];
            AssignAttri("", false, "A2151ACTDetValorReparacion", StringUtil.LTrimStr( A2151ACTDetValorReparacion, 15, 2));
            A2149ACTDetValorCompras = T006R3_A2149ACTDetValorCompras[0];
            AssignAttri("", false, "A2149ACTDetValorCompras", StringUtil.LTrimStr( A2149ACTDetValorCompras, 15, 2));
            A2153ACTDetValorRetiro = T006R3_A2153ACTDetValorRetiro[0];
            AssignAttri("", false, "A2153ACTDetValorRetiro", StringUtil.LTrimStr( A2153ACTDetValorRetiro, 15, 2));
            A2148ACTDetSts = T006R3_A2148ACTDetSts[0];
            AssignAttri("", false, "A2148ACTDetSts", A2148ACTDetSts);
            A2141ACTDetBajFec = T006R3_A2141ACTDetBajFec[0];
            AssignAttri("", false, "A2141ACTDetBajFec", context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"));
            A2100ACTActCod = T006R3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2114ACTSGrupCod = T006R3_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            Z2100ACTActCod = A2100ACTActCod;
            Z2104ActActItem = A2104ActActItem;
            sMode185 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6R185( ) ;
            if ( AnyError == 1 )
            {
               RcdFound185 = 0;
               InitializeNonKey6R185( ) ;
            }
            Gx_mode = sMode185;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound185 = 0;
            InitializeNonKey6R185( ) ;
            sMode185 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode185;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6R185( ) ;
         if ( RcdFound185 == 0 )
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
         RcdFound185 = 0;
         /* Using cursor T006R12 */
         pr_default.execute(10, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T006R12_A2100ACTActCod[0], A2100ACTActCod) < 0 ) || ( StringUtil.StrCmp(T006R12_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( StringUtil.StrCmp(T006R12_A2104ActActItem[0], A2104ActActItem) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T006R12_A2100ACTActCod[0], A2100ACTActCod) > 0 ) || ( StringUtil.StrCmp(T006R12_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( StringUtil.StrCmp(T006R12_A2104ActActItem[0], A2104ActActItem) > 0 ) ) )
            {
               A2100ACTActCod = T006R12_A2100ACTActCod[0];
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               A2104ActActItem = T006R12_A2104ActActItem[0];
               n2104ActActItem = T006R12_n2104ActActItem[0];
               AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
               RcdFound185 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound185 = 0;
         /* Using cursor T006R13 */
         pr_default.execute(11, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T006R13_A2100ACTActCod[0], A2100ACTActCod) > 0 ) || ( StringUtil.StrCmp(T006R13_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( StringUtil.StrCmp(T006R13_A2104ActActItem[0], A2104ActActItem) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T006R13_A2100ACTActCod[0], A2100ACTActCod) < 0 ) || ( StringUtil.StrCmp(T006R13_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( StringUtil.StrCmp(T006R13_A2104ActActItem[0], A2104ActActItem) < 0 ) ) )
            {
               A2100ACTActCod = T006R13_A2100ACTActCod[0];
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               A2104ActActItem = T006R13_A2104ActActItem[0];
               n2104ActActItem = T006R13_n2104ActActItem[0];
               AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
               RcdFound185 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6R185( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6R185( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound185 == 1 )
            {
               if ( ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 ) || ( StringUtil.StrCmp(A2104ActActItem, Z2104ActActItem) != 0 ) )
               {
                  A2100ACTActCod = Z2100ACTActCod;
                  AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
                  A2104ActActItem = Z2104ActActItem;
                  n2104ActActItem = false;
                  AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTACTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTActCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTActCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6R185( ) ;
                  GX_FocusControl = edtACTActCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 ) || ( StringUtil.StrCmp(A2104ActActItem, Z2104ActActItem) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTActCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6R185( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTACTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtACTActCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTActCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6R185( ) ;
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
         if ( ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 ) || ( StringUtil.StrCmp(A2104ActActItem, Z2104ActActItem) != 0 ) )
         {
            A2100ACTActCod = Z2100ACTActCod;
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = Z2104ActActItem;
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTActCod_Internalname;
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
         if ( RcdFound185 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTSGrupCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6R185( ) ;
         if ( RcdFound185 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6R185( ) ;
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
         if ( RcdFound185 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupCod_Internalname;
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
         if ( RcdFound185 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupCod_Internalname;
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
         ScanStart6R185( ) ;
         if ( RcdFound185 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound185 != 0 )
            {
               ScanNext6R185( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6R185( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6R185( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006R2 */
            pr_default.execute(0, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTACTIVOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2146ACTDetParte, T006R2_A2146ACTDetParte[0]) != 0 ) || ( StringUtil.StrCmp(Z2147ACTDetSerie, T006R2_A2147ACTDetSerie[0]) != 0 ) || ( StringUtil.StrCmp(Z2145ACTDetModelo, T006R2_A2145ACTDetModelo[0]) != 0 ) || ( StringUtil.StrCmp(Z2144ACTDetMarca, T006R2_A2144ACTDetMarca[0]) != 0 ) || ( StringUtil.StrCmp(Z2140ACTDetAno, T006R2_A2140ACTDetAno[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2142ACTDetCap, T006R2_A2142ACTDetCap[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z2143ACTDetFecIni ) != DateTimeUtil.ResetTime ( T006R2_A2143ACTDetFecIni[0] ) ) || ( Z2150ACTDetValorNeto != T006R2_A2150ACTDetValorNeto[0] ) || ( Z2152ACTDetValorResiduo != T006R2_A2152ACTDetValorResiduo[0] ) || ( Z2154ACTDetVidaUtil != T006R2_A2154ACTDetVidaUtil[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2151ACTDetValorReparacion != T006R2_A2151ACTDetValorReparacion[0] ) || ( Z2149ACTDetValorCompras != T006R2_A2149ACTDetValorCompras[0] ) || ( Z2153ACTDetValorRetiro != T006R2_A2153ACTDetValorRetiro[0] ) || ( StringUtil.StrCmp(Z2148ACTDetSts, T006R2_A2148ACTDetSts[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z2141ACTDetBajFec ) != DateTimeUtil.ResetTime ( T006R2_A2141ACTDetBajFec[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2114ACTSGrupCod, T006R2_A2114ACTSGrupCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2146ACTDetParte, T006R2_A2146ACTDetParte[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetParte");
                  GXUtil.WriteLogRaw("Old: ",Z2146ACTDetParte);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2146ACTDetParte[0]);
               }
               if ( StringUtil.StrCmp(Z2147ACTDetSerie, T006R2_A2147ACTDetSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetSerie");
                  GXUtil.WriteLogRaw("Old: ",Z2147ACTDetSerie);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2147ACTDetSerie[0]);
               }
               if ( StringUtil.StrCmp(Z2145ACTDetModelo, T006R2_A2145ACTDetModelo[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetModelo");
                  GXUtil.WriteLogRaw("Old: ",Z2145ACTDetModelo);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2145ACTDetModelo[0]);
               }
               if ( StringUtil.StrCmp(Z2144ACTDetMarca, T006R2_A2144ACTDetMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetMarca");
                  GXUtil.WriteLogRaw("Old: ",Z2144ACTDetMarca);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2144ACTDetMarca[0]);
               }
               if ( StringUtil.StrCmp(Z2140ACTDetAno, T006R2_A2140ACTDetAno[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetAno");
                  GXUtil.WriteLogRaw("Old: ",Z2140ACTDetAno);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2140ACTDetAno[0]);
               }
               if ( StringUtil.StrCmp(Z2142ACTDetCap, T006R2_A2142ACTDetCap[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetCap");
                  GXUtil.WriteLogRaw("Old: ",Z2142ACTDetCap);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2142ACTDetCap[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2143ACTDetFecIni ) != DateTimeUtil.ResetTime ( T006R2_A2143ACTDetFecIni[0] ) )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetFecIni");
                  GXUtil.WriteLogRaw("Old: ",Z2143ACTDetFecIni);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2143ACTDetFecIni[0]);
               }
               if ( Z2150ACTDetValorNeto != T006R2_A2150ACTDetValorNeto[0] )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetValorNeto");
                  GXUtil.WriteLogRaw("Old: ",Z2150ACTDetValorNeto);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2150ACTDetValorNeto[0]);
               }
               if ( Z2152ACTDetValorResiduo != T006R2_A2152ACTDetValorResiduo[0] )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetValorResiduo");
                  GXUtil.WriteLogRaw("Old: ",Z2152ACTDetValorResiduo);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2152ACTDetValorResiduo[0]);
               }
               if ( Z2154ACTDetVidaUtil != T006R2_A2154ACTDetVidaUtil[0] )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetVidaUtil");
                  GXUtil.WriteLogRaw("Old: ",Z2154ACTDetVidaUtil);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2154ACTDetVidaUtil[0]);
               }
               if ( Z2151ACTDetValorReparacion != T006R2_A2151ACTDetValorReparacion[0] )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetValorReparacion");
                  GXUtil.WriteLogRaw("Old: ",Z2151ACTDetValorReparacion);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2151ACTDetValorReparacion[0]);
               }
               if ( Z2149ACTDetValorCompras != T006R2_A2149ACTDetValorCompras[0] )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetValorCompras");
                  GXUtil.WriteLogRaw("Old: ",Z2149ACTDetValorCompras);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2149ACTDetValorCompras[0]);
               }
               if ( Z2153ACTDetValorRetiro != T006R2_A2153ACTDetValorRetiro[0] )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetValorRetiro");
                  GXUtil.WriteLogRaw("Old: ",Z2153ACTDetValorRetiro);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2153ACTDetValorRetiro[0]);
               }
               if ( StringUtil.StrCmp(Z2148ACTDetSts, T006R2_A2148ACTDetSts[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetSts");
                  GXUtil.WriteLogRaw("Old: ",Z2148ACTDetSts);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2148ACTDetSts[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2141ACTDetBajFec ) != DateTimeUtil.ResetTime ( T006R2_A2141ACTDetBajFec[0] ) )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTDetBajFec");
                  GXUtil.WriteLogRaw("Old: ",Z2141ACTDetBajFec);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2141ACTDetBajFec[0]);
               }
               if ( StringUtil.StrCmp(Z2114ACTSGrupCod, T006R2_A2114ACTSGrupCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivosdet:[seudo value changed for attri]"+"ACTSGrupCod");
                  GXUtil.WriteLogRaw("Old: ",Z2114ACTSGrupCod);
                  GXUtil.WriteLogRaw("Current: ",T006R2_A2114ACTSGrupCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTACTIVOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6R185( )
      {
         BeforeValidate6R185( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6R185( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6R185( 0) ;
            CheckOptimisticConcurrency6R185( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6R185( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6R185( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006R14 */
                     pr_default.execute(12, new Object[] {n426ACTClaCod, A426ACTClaCod, A2103ACTGrupCod, n2104ActActItem, A2104ActActItem, A2146ACTDetParte, A2147ACTDetSerie, A2145ACTDetModelo, A2144ACTDetMarca, A2140ACTDetAno, A2142ACTDetCap, A2143ACTDetFecIni, A2150ACTDetValorNeto, A2152ACTDetValorResiduo, A2154ACTDetVidaUtil, A2151ACTDetValorReparacion, A2149ACTDetValorCompras, A2153ACTDetValorRetiro, A2148ACTDetSts, A2141ACTDetBajFec, A2100ACTActCod, A2114ACTSGrupCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOSDET");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption6R0( ) ;
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
               Load6R185( ) ;
            }
            EndLevel6R185( ) ;
         }
         CloseExtendedTableCursors6R185( ) ;
      }

      protected void Update6R185( )
      {
         BeforeValidate6R185( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6R185( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6R185( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6R185( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6R185( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006R15 */
                     pr_default.execute(13, new Object[] {n426ACTClaCod, A426ACTClaCod, A2103ACTGrupCod, A2146ACTDetParte, A2147ACTDetSerie, A2145ACTDetModelo, A2144ACTDetMarca, A2140ACTDetAno, A2142ACTDetCap, A2143ACTDetFecIni, A2150ACTDetValorNeto, A2152ACTDetValorResiduo, A2154ACTDetVidaUtil, A2151ACTDetValorReparacion, A2149ACTDetValorCompras, A2153ACTDetValorRetiro, A2148ACTDetSts, A2141ACTDetBajFec, A2114ACTSGrupCod, A2100ACTActCod, n2104ActActItem, A2104ActActItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOSDET");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTACTIVOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6R185( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6R0( ) ;
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
            EndLevel6R185( ) ;
         }
         CloseExtendedTableCursors6R185( ) ;
      }

      protected void DeferredUpdate6R185( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6R185( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6R185( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6R185( ) ;
            AfterConfirm6R185( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6R185( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006R16 */
                  pr_default.execute(14, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound185 == 0 )
                        {
                           InitAll6R185( ) ;
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
                        ResetCaption6R0( ) ;
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
         sMode185 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6R185( ) ;
         Gx_mode = sMode185;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6R185( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006R17 */
            pr_default.execute(15, new Object[] {A2100ACTActCod});
            A426ACTClaCod = T006R17_A426ACTClaCod[0];
            n426ACTClaCod = T006R17_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006R17_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            pr_default.close(15);
            /* Using cursor T006R18 */
            pr_default.execute(16, new Object[] {n426ACTClaCod, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
            A2155ACTSGrupDsc = T006R18_A2155ACTSGrupDsc[0];
            AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
            A2156ACTSGrupPor = T006R18_A2156ACTSGrupPor[0];
            AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T006R19 */
            pr_default.execute(17, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTRevaluacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006R20 */
            pr_default.execute(18, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reparacion de Activos Fijos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006R21 */
            pr_default.execute(19, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Activo Fijo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T006R22 */
            pr_default.execute(20, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Baja de Activos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T006R23 */
            pr_default.execute(21, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Retiro de Activo Fijos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T006R24 */
            pr_default.execute(22, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico Costo Depreciación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel6R185( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6R185( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("actactivosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("actactivosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6R185( )
      {
         /* Using cursor T006R25 */
         pr_default.execute(23);
         RcdFound185 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound185 = 1;
            A2100ACTActCod = T006R25_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006R25_A2104ActActItem[0];
            n2104ActActItem = T006R25_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6R185( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound185 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound185 = 1;
            A2100ACTActCod = T006R25_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006R25_A2104ActActItem[0];
            n2104ActActItem = T006R25_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         }
      }

      protected void ScanEnd6R185( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm6R185( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6R185( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6R185( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6R185( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6R185( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6R185( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6R185( )
      {
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtACTSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupCod_Enabled), 5, 0), true);
         edtACTSGrupDsc_Enabled = 0;
         AssignProp("", false, edtACTSGrupDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupDsc_Enabled), 5, 0), true);
         edtACTSGrupPor_Enabled = 0;
         AssignProp("", false, edtACTSGrupPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupPor_Enabled), 5, 0), true);
         edtACTDetParte_Enabled = 0;
         AssignProp("", false, edtACTDetParte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetParte_Enabled), 5, 0), true);
         edtACTDetSerie_Enabled = 0;
         AssignProp("", false, edtACTDetSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetSerie_Enabled), 5, 0), true);
         edtACTDetModelo_Enabled = 0;
         AssignProp("", false, edtACTDetModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetModelo_Enabled), 5, 0), true);
         edtACTDetMarca_Enabled = 0;
         AssignProp("", false, edtACTDetMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetMarca_Enabled), 5, 0), true);
         edtACTDetAno_Enabled = 0;
         AssignProp("", false, edtACTDetAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetAno_Enabled), 5, 0), true);
         edtACTDetCap_Enabled = 0;
         AssignProp("", false, edtACTDetCap_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetCap_Enabled), 5, 0), true);
         edtACTDetFecIni_Enabled = 0;
         AssignProp("", false, edtACTDetFecIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetFecIni_Enabled), 5, 0), true);
         edtACTDetValorNeto_Enabled = 0;
         AssignProp("", false, edtACTDetValorNeto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetValorNeto_Enabled), 5, 0), true);
         edtACTDetValorResiduo_Enabled = 0;
         AssignProp("", false, edtACTDetValorResiduo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetValorResiduo_Enabled), 5, 0), true);
         edtACTDetVidaUtil_Enabled = 0;
         AssignProp("", false, edtACTDetVidaUtil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetVidaUtil_Enabled), 5, 0), true);
         edtACTDetValorReparacion_Enabled = 0;
         AssignProp("", false, edtACTDetValorReparacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetValorReparacion_Enabled), 5, 0), true);
         edtACTDetValorCompras_Enabled = 0;
         AssignProp("", false, edtACTDetValorCompras_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetValorCompras_Enabled), 5, 0), true);
         edtACTDetValorRetiro_Enabled = 0;
         AssignProp("", false, edtACTDetValorRetiro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetValorRetiro_Enabled), 5, 0), true);
         edtACTClaCod_Enabled = 0;
         AssignProp("", false, edtACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaCod_Enabled), 5, 0), true);
         edtACTGrupCod_Enabled = 0;
         AssignProp("", false, edtACTGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupCod_Enabled), 5, 0), true);
         edtACTDetSts_Enabled = 0;
         AssignProp("", false, edtACTDetSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetSts_Enabled), 5, 0), true);
         edtACTDetBajFec_Enabled = 0;
         AssignProp("", false, edtACTDetBajFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTDetBajFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6R185( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6R0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264750", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actactivosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2146ACTDetParte", Z2146ACTDetParte);
         GxWebStd.gx_hidden_field( context, "Z2147ACTDetSerie", Z2147ACTDetSerie);
         GxWebStd.gx_hidden_field( context, "Z2145ACTDetModelo", Z2145ACTDetModelo);
         GxWebStd.gx_hidden_field( context, "Z2144ACTDetMarca", Z2144ACTDetMarca);
         GxWebStd.gx_hidden_field( context, "Z2140ACTDetAno", Z2140ACTDetAno);
         GxWebStd.gx_hidden_field( context, "Z2142ACTDetCap", Z2142ACTDetCap);
         GxWebStd.gx_hidden_field( context, "Z2143ACTDetFecIni", context.localUtil.DToC( Z2143ACTDetFecIni, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2150ACTDetValorNeto", StringUtil.LTrim( StringUtil.NToC( Z2150ACTDetValorNeto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2152ACTDetValorResiduo", StringUtil.LTrim( StringUtil.NToC( Z2152ACTDetValorResiduo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2154ACTDetVidaUtil", StringUtil.LTrim( StringUtil.NToC( Z2154ACTDetVidaUtil, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2151ACTDetValorReparacion", StringUtil.LTrim( StringUtil.NToC( Z2151ACTDetValorReparacion, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2149ACTDetValorCompras", StringUtil.LTrim( StringUtil.NToC( Z2149ACTDetValorCompras, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2153ACTDetValorRetiro", StringUtil.LTrim( StringUtil.NToC( Z2153ACTDetValorRetiro, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2148ACTDetSts", Z2148ACTDetSts);
         GxWebStd.gx_hidden_field( context, "Z2141ACTDetBajFec", context.localUtil.DToC( Z2141ACTDetBajFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
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
         return formatLink("actactivosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ACTACTIVOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "ACTACTIVOSDET" ;
      }

      protected void InitializeNonKey6R185( )
      {
         A2114ACTSGrupCod = "";
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         A2155ACTSGrupDsc = "";
         AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
         A2156ACTSGrupPor = 0;
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
         A2146ACTDetParte = "";
         AssignAttri("", false, "A2146ACTDetParte", A2146ACTDetParte);
         A2147ACTDetSerie = "";
         AssignAttri("", false, "A2147ACTDetSerie", A2147ACTDetSerie);
         A2145ACTDetModelo = "";
         AssignAttri("", false, "A2145ACTDetModelo", A2145ACTDetModelo);
         A2144ACTDetMarca = "";
         AssignAttri("", false, "A2144ACTDetMarca", A2144ACTDetMarca);
         A2140ACTDetAno = "";
         AssignAttri("", false, "A2140ACTDetAno", A2140ACTDetAno);
         A2142ACTDetCap = "";
         AssignAttri("", false, "A2142ACTDetCap", A2142ACTDetCap);
         A2143ACTDetFecIni = DateTime.MinValue;
         AssignAttri("", false, "A2143ACTDetFecIni", context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"));
         A2150ACTDetValorNeto = 0;
         AssignAttri("", false, "A2150ACTDetValorNeto", StringUtil.LTrimStr( A2150ACTDetValorNeto, 15, 2));
         A2152ACTDetValorResiduo = 0;
         AssignAttri("", false, "A2152ACTDetValorResiduo", StringUtil.LTrimStr( A2152ACTDetValorResiduo, 15, 2));
         A2154ACTDetVidaUtil = 0;
         AssignAttri("", false, "A2154ACTDetVidaUtil", StringUtil.LTrimStr( A2154ACTDetVidaUtil, 6, 2));
         A2151ACTDetValorReparacion = 0;
         AssignAttri("", false, "A2151ACTDetValorReparacion", StringUtil.LTrimStr( A2151ACTDetValorReparacion, 15, 2));
         A2149ACTDetValorCompras = 0;
         AssignAttri("", false, "A2149ACTDetValorCompras", StringUtil.LTrimStr( A2149ACTDetValorCompras, 15, 2));
         A2153ACTDetValorRetiro = 0;
         AssignAttri("", false, "A2153ACTDetValorRetiro", StringUtil.LTrimStr( A2153ACTDetValorRetiro, 15, 2));
         A426ACTClaCod = "";
         n426ACTClaCod = false;
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = "";
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         A2148ACTDetSts = "";
         AssignAttri("", false, "A2148ACTDetSts", A2148ACTDetSts);
         A2141ACTDetBajFec = DateTime.MinValue;
         AssignAttri("", false, "A2141ACTDetBajFec", context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"));
         Z2146ACTDetParte = "";
         Z2147ACTDetSerie = "";
         Z2145ACTDetModelo = "";
         Z2144ACTDetMarca = "";
         Z2140ACTDetAno = "";
         Z2142ACTDetCap = "";
         Z2143ACTDetFecIni = DateTime.MinValue;
         Z2150ACTDetValorNeto = 0;
         Z2152ACTDetValorResiduo = 0;
         Z2154ACTDetVidaUtil = 0;
         Z2151ACTDetValorReparacion = 0;
         Z2149ACTDetValorCompras = 0;
         Z2153ACTDetValorRetiro = 0;
         Z2148ACTDetSts = "";
         Z2141ACTDetBajFec = DateTime.MinValue;
         Z2114ACTSGrupCod = "";
      }

      protected void InitAll6R185( )
      {
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2104ActActItem = "";
         n2104ActActItem = false;
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         InitializeNonKey6R185( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264764", true, true);
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
         context.AddJavascriptSource("actactivosdet.js", "?202281810264765", false, true);
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
         edtACTActCod_Internalname = "ACTACTCOD";
         edtActActItem_Internalname = "ACTACTITEM";
         edtACTSGrupCod_Internalname = "ACTSGRUPCOD";
         edtACTSGrupDsc_Internalname = "ACTSGRUPDSC";
         edtACTSGrupPor_Internalname = "ACTSGRUPPOR";
         edtACTDetParte_Internalname = "ACTDETPARTE";
         edtACTDetSerie_Internalname = "ACTDETSERIE";
         edtACTDetModelo_Internalname = "ACTDETMODELO";
         edtACTDetMarca_Internalname = "ACTDETMARCA";
         edtACTDetAno_Internalname = "ACTDETANO";
         edtACTDetCap_Internalname = "ACTDETCAP";
         edtACTDetFecIni_Internalname = "ACTDETFECINI";
         edtACTDetValorNeto_Internalname = "ACTDETVALORNETO";
         edtACTDetValorResiduo_Internalname = "ACTDETVALORRESIDUO";
         edtACTDetVidaUtil_Internalname = "ACTDETVIDAUTIL";
         edtACTDetValorReparacion_Internalname = "ACTDETVALORREPARACION";
         edtACTDetValorCompras_Internalname = "ACTDETVALORCOMPRAS";
         edtACTDetValorRetiro_Internalname = "ACTDETVALORRETIRO";
         edtACTClaCod_Internalname = "ACTCLACOD";
         edtACTGrupCod_Internalname = "ACTGRUPCOD";
         edtACTDetSts_Internalname = "ACTDETSTS";
         edtACTDetBajFec_Internalname = "ACTDETBAJFEC";
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
         Form.Caption = "ACTACTIVOSDET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtACTDetBajFec_Jsonclick = "";
         edtACTDetBajFec_Enabled = 1;
         edtACTDetSts_Jsonclick = "";
         edtACTDetSts_Enabled = 1;
         edtACTGrupCod_Jsonclick = "";
         edtACTGrupCod_Enabled = 0;
         edtACTClaCod_Jsonclick = "";
         edtACTClaCod_Enabled = 0;
         edtACTDetValorRetiro_Jsonclick = "";
         edtACTDetValorRetiro_Enabled = 1;
         edtACTDetValorCompras_Jsonclick = "";
         edtACTDetValorCompras_Enabled = 1;
         edtACTDetValorReparacion_Jsonclick = "";
         edtACTDetValorReparacion_Enabled = 1;
         edtACTDetVidaUtil_Jsonclick = "";
         edtACTDetVidaUtil_Enabled = 1;
         edtACTDetValorResiduo_Jsonclick = "";
         edtACTDetValorResiduo_Enabled = 1;
         edtACTDetValorNeto_Jsonclick = "";
         edtACTDetValorNeto_Enabled = 1;
         edtACTDetFecIni_Jsonclick = "";
         edtACTDetFecIni_Enabled = 1;
         edtACTDetCap_Jsonclick = "";
         edtACTDetCap_Enabled = 1;
         edtACTDetAno_Jsonclick = "";
         edtACTDetAno_Enabled = 1;
         edtACTDetMarca_Jsonclick = "";
         edtACTDetMarca_Enabled = 1;
         edtACTDetModelo_Jsonclick = "";
         edtACTDetModelo_Enabled = 1;
         edtACTDetSerie_Jsonclick = "";
         edtACTDetSerie_Enabled = 1;
         edtACTDetParte_Jsonclick = "";
         edtACTDetParte_Enabled = 1;
         edtACTSGrupPor_Jsonclick = "";
         edtACTSGrupPor_Enabled = 0;
         edtACTSGrupDsc_Jsonclick = "";
         edtACTSGrupDsc_Enabled = 0;
         edtACTSGrupCod_Jsonclick = "";
         edtACTSGrupCod_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
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
         /* Using cursor T006R17 */
         pr_default.execute(15, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A426ACTClaCod = T006R17_A426ACTClaCod[0];
         n426ACTClaCod = T006R17_n426ACTClaCod[0];
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = T006R17_A2103ACTGrupCod[0];
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         pr_default.close(15);
         /* Using cursor T006R26 */
         pr_default.execute(24, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
            }
         }
         pr_default.close(24);
         GX_FocusControl = edtACTSGrupCod_Internalname;
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

      public void Valid_Actactcod( )
      {
         n426ACTClaCod = false;
         /* Using cursor T006R17 */
         pr_default.execute(15, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         A426ACTClaCod = T006R17_A426ACTClaCod[0];
         n426ACTClaCod = T006R17_n426ACTClaCod[0];
         A2103ACTGrupCod = T006R17_A2103ACTGrupCod[0];
         pr_default.close(15);
         /* Using cursor T006R26 */
         pr_default.execute(24, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
      }

      public void Valid_Actactitem( )
      {
         n2104ActActItem = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         AssignAttri("", false, "A2146ACTDetParte", A2146ACTDetParte);
         AssignAttri("", false, "A2147ACTDetSerie", A2147ACTDetSerie);
         AssignAttri("", false, "A2145ACTDetModelo", A2145ACTDetModelo);
         AssignAttri("", false, "A2144ACTDetMarca", A2144ACTDetMarca);
         AssignAttri("", false, "A2140ACTDetAno", A2140ACTDetAno);
         AssignAttri("", false, "A2142ACTDetCap", A2142ACTDetCap);
         AssignAttri("", false, "A2143ACTDetFecIni", context.localUtil.Format(A2143ACTDetFecIni, "99/99/99"));
         AssignAttri("", false, "A2150ACTDetValorNeto", StringUtil.LTrim( StringUtil.NToC( A2150ACTDetValorNeto, 15, 2, ".", "")));
         AssignAttri("", false, "A2152ACTDetValorResiduo", StringUtil.LTrim( StringUtil.NToC( A2152ACTDetValorResiduo, 15, 2, ".", "")));
         AssignAttri("", false, "A2154ACTDetVidaUtil", StringUtil.LTrim( StringUtil.NToC( A2154ACTDetVidaUtil, 6, 2, ".", "")));
         AssignAttri("", false, "A2151ACTDetValorReparacion", StringUtil.LTrim( StringUtil.NToC( A2151ACTDetValorReparacion, 15, 2, ".", "")));
         AssignAttri("", false, "A2149ACTDetValorCompras", StringUtil.LTrim( StringUtil.NToC( A2149ACTDetValorCompras, 15, 2, ".", "")));
         AssignAttri("", false, "A2153ACTDetValorRetiro", StringUtil.LTrim( StringUtil.NToC( A2153ACTDetValorRetiro, 15, 2, ".", "")));
         AssignAttri("", false, "A2148ACTDetSts", A2148ACTDetSts);
         AssignAttri("", false, "A2141ACTDetBajFec", context.localUtil.Format(A2141ACTDetBajFec, "99/99/99"));
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         AssignAttri("", false, "A2155ACTSGrupDsc", StringUtil.RTrim( A2155ACTSGrupDsc));
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrim( StringUtil.NToC( A2156ACTSGrupPor, 6, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2146ACTDetParte", Z2146ACTDetParte);
         GxWebStd.gx_hidden_field( context, "Z2147ACTDetSerie", Z2147ACTDetSerie);
         GxWebStd.gx_hidden_field( context, "Z2145ACTDetModelo", Z2145ACTDetModelo);
         GxWebStd.gx_hidden_field( context, "Z2144ACTDetMarca", Z2144ACTDetMarca);
         GxWebStd.gx_hidden_field( context, "Z2140ACTDetAno", Z2140ACTDetAno);
         GxWebStd.gx_hidden_field( context, "Z2142ACTDetCap", Z2142ACTDetCap);
         GxWebStd.gx_hidden_field( context, "Z2143ACTDetFecIni", context.localUtil.Format(Z2143ACTDetFecIni, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2150ACTDetValorNeto", StringUtil.LTrim( StringUtil.NToC( Z2150ACTDetValorNeto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2152ACTDetValorResiduo", StringUtil.LTrim( StringUtil.NToC( Z2152ACTDetValorResiduo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2154ACTDetVidaUtil", StringUtil.LTrim( StringUtil.NToC( Z2154ACTDetVidaUtil, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2151ACTDetValorReparacion", StringUtil.LTrim( StringUtil.NToC( Z2151ACTDetValorReparacion, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2149ACTDetValorCompras", StringUtil.LTrim( StringUtil.NToC( Z2149ACTDetValorCompras, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2153ACTDetValorRetiro", StringUtil.LTrim( StringUtil.NToC( Z2153ACTDetValorRetiro, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2148ACTDetSts", Z2148ACTDetSts);
         GxWebStd.gx_hidden_field( context, "Z2141ACTDetBajFec", context.localUtil.Format(Z2141ACTDetBajFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2155ACTSGrupDsc", StringUtil.RTrim( Z2155ACTSGrupDsc));
         GxWebStd.gx_hidden_field( context, "Z2156ACTSGrupPor", StringUtil.LTrim( StringUtil.NToC( Z2156ACTSGrupPor, 6, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actsgrupcod( )
      {
         n426ACTClaCod = false;
         /* Using cursor T006R18 */
         pr_default.execute(16, new Object[] {n426ACTClaCod, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTSGrupCod_Internalname;
         }
         A2155ACTSGrupDsc = T006R18_A2155ACTSGrupDsc[0];
         A2156ACTSGrupPor = T006R18_A2156ACTSGrupPor[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2155ACTSGrupDsc", StringUtil.RTrim( A2155ACTSGrupDsc));
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrim( StringUtil.NToC( A2156ACTSGrupPor, 6, 2, ".", "")));
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
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("VALID_ACTACTITEM","{handler:'Valid_Actactitem',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTACTITEM",",oparms:[{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''},{av:'A2146ACTDetParte',fld:'ACTDETPARTE',pic:''},{av:'A2147ACTDetSerie',fld:'ACTDETSERIE',pic:''},{av:'A2145ACTDetModelo',fld:'ACTDETMODELO',pic:''},{av:'A2144ACTDetMarca',fld:'ACTDETMARCA',pic:''},{av:'A2140ACTDetAno',fld:'ACTDETANO',pic:''},{av:'A2142ACTDetCap',fld:'ACTDETCAP',pic:''},{av:'A2143ACTDetFecIni',fld:'ACTDETFECINI',pic:''},{av:'A2150ACTDetValorNeto',fld:'ACTDETVALORNETO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2152ACTDetValorResiduo',fld:'ACTDETVALORRESIDUO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2154ACTDetVidaUtil',fld:'ACTDETVIDAUTIL',pic:'ZZ9.99'},{av:'A2151ACTDetValorReparacion',fld:'ACTDETVALORREPARACION',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2149ACTDetValorCompras',fld:'ACTDETVALORCOMPRAS',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2153ACTDetValorRetiro',fld:'ACTDETVALORRETIRO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2148ACTDetSts',fld:'ACTDETSTS',pic:''},{av:'A2141ACTDetBajFec',fld:'ACTDETBAJFEC',pic:''},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'A2155ACTSGrupDsc',fld:'ACTSGRUPDSC',pic:''},{av:'A2156ACTSGrupPor',fld:'ACTSGRUPPOR',pic:'ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2114ACTSGrupCod'},{av:'Z2146ACTDetParte'},{av:'Z2147ACTDetSerie'},{av:'Z2145ACTDetModelo'},{av:'Z2144ACTDetMarca'},{av:'Z2140ACTDetAno'},{av:'Z2142ACTDetCap'},{av:'Z2143ACTDetFecIni'},{av:'Z2150ACTDetValorNeto'},{av:'Z2152ACTDetValorResiduo'},{av:'Z2154ACTDetVidaUtil'},{av:'Z2151ACTDetValorReparacion'},{av:'Z2149ACTDetValorCompras'},{av:'Z2153ACTDetValorRetiro'},{av:'Z2148ACTDetSts'},{av:'Z2141ACTDetBajFec'},{av:'Z426ACTClaCod'},{av:'Z2103ACTGrupCod'},{av:'Z2155ACTSGrupDsc'},{av:'Z2156ACTSGrupPor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTSGRUPCOD","{handler:'Valid_Actsgrupcod',iparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''},{av:'A2155ACTSGrupDsc',fld:'ACTSGRUPDSC',pic:''},{av:'A2156ACTSGrupPor',fld:'ACTSGRUPPOR',pic:'ZZ9.99'}]");
         setEventMetadata("VALID_ACTSGRUPCOD",",oparms:[{av:'A2155ACTSGrupDsc',fld:'ACTSGRUPDSC',pic:''},{av:'A2156ACTSGrupPor',fld:'ACTSGRUPPOR',pic:'ZZ9.99'}]}");
         setEventMetadata("VALID_ACTDETFECINI","{handler:'Valid_Actdetfecini',iparms:[]");
         setEventMetadata("VALID_ACTDETFECINI",",oparms:[]}");
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[]}");
         setEventMetadata("VALID_ACTGRUPCOD","{handler:'Valid_Actgrupcod',iparms:[]");
         setEventMetadata("VALID_ACTGRUPCOD",",oparms:[]}");
         setEventMetadata("VALID_ACTDETBAJFEC","{handler:'Valid_Actdetbajfec',iparms:[]");
         setEventMetadata("VALID_ACTDETBAJFEC",",oparms:[]}");
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
         pr_default.close(16);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
         Z2146ACTDetParte = "";
         Z2147ACTDetSerie = "";
         Z2145ACTDetModelo = "";
         Z2144ACTDetMarca = "";
         Z2140ACTDetAno = "";
         Z2142ACTDetCap = "";
         Z2143ACTDetFecIni = DateTime.MinValue;
         Z2148ACTDetSts = "";
         Z2141ACTDetBajFec = DateTime.MinValue;
         Z2114ACTSGrupCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2100ACTActCod = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2114ACTSGrupCod = "";
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
         A2104ActActItem = "";
         A2155ACTSGrupDsc = "";
         A2146ACTDetParte = "";
         A2147ACTDetSerie = "";
         A2145ACTDetModelo = "";
         A2144ACTDetMarca = "";
         A2140ACTDetAno = "";
         A2142ACTDetCap = "";
         A2143ACTDetFecIni = DateTime.MinValue;
         A2148ACTDetSts = "";
         A2141ACTDetBajFec = DateTime.MinValue;
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
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2155ACTSGrupDsc = "";
         T006R7_A2104ActActItem = new string[] {""} ;
         T006R7_n2104ActActItem = new bool[] {false} ;
         T006R7_A2155ACTSGrupDsc = new string[] {""} ;
         T006R7_A2156ACTSGrupPor = new decimal[1] ;
         T006R7_A2146ACTDetParte = new string[] {""} ;
         T006R7_A2147ACTDetSerie = new string[] {""} ;
         T006R7_A2145ACTDetModelo = new string[] {""} ;
         T006R7_A2144ACTDetMarca = new string[] {""} ;
         T006R7_A2140ACTDetAno = new string[] {""} ;
         T006R7_A2142ACTDetCap = new string[] {""} ;
         T006R7_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         T006R7_A2150ACTDetValorNeto = new decimal[1] ;
         T006R7_A2152ACTDetValorResiduo = new decimal[1] ;
         T006R7_A2154ACTDetVidaUtil = new decimal[1] ;
         T006R7_A2151ACTDetValorReparacion = new decimal[1] ;
         T006R7_A2149ACTDetValorCompras = new decimal[1] ;
         T006R7_A2153ACTDetValorRetiro = new decimal[1] ;
         T006R7_A426ACTClaCod = new string[] {""} ;
         T006R7_n426ACTClaCod = new bool[] {false} ;
         T006R7_A2103ACTGrupCod = new string[] {""} ;
         T006R7_A2148ACTDetSts = new string[] {""} ;
         T006R7_A2141ACTDetBajFec = new DateTime[] {DateTime.MinValue} ;
         T006R7_A2100ACTActCod = new string[] {""} ;
         T006R7_A2114ACTSGrupCod = new string[] {""} ;
         T006R4_A426ACTClaCod = new string[] {""} ;
         T006R4_n426ACTClaCod = new bool[] {false} ;
         T006R4_A2103ACTGrupCod = new string[] {""} ;
         T006R6_A426ACTClaCod = new string[] {""} ;
         T006R6_n426ACTClaCod = new bool[] {false} ;
         T006R5_A2155ACTSGrupDsc = new string[] {""} ;
         T006R5_A2156ACTSGrupPor = new decimal[1] ;
         T006R8_A426ACTClaCod = new string[] {""} ;
         T006R8_n426ACTClaCod = new bool[] {false} ;
         T006R8_A2103ACTGrupCod = new string[] {""} ;
         T006R9_A426ACTClaCod = new string[] {""} ;
         T006R9_n426ACTClaCod = new bool[] {false} ;
         T006R10_A2155ACTSGrupDsc = new string[] {""} ;
         T006R10_A2156ACTSGrupPor = new decimal[1] ;
         T006R11_A2100ACTActCod = new string[] {""} ;
         T006R11_A2104ActActItem = new string[] {""} ;
         T006R11_n2104ActActItem = new bool[] {false} ;
         T006R3_A2104ActActItem = new string[] {""} ;
         T006R3_n2104ActActItem = new bool[] {false} ;
         T006R3_A2146ACTDetParte = new string[] {""} ;
         T006R3_A2147ACTDetSerie = new string[] {""} ;
         T006R3_A2145ACTDetModelo = new string[] {""} ;
         T006R3_A2144ACTDetMarca = new string[] {""} ;
         T006R3_A2140ACTDetAno = new string[] {""} ;
         T006R3_A2142ACTDetCap = new string[] {""} ;
         T006R3_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         T006R3_A2150ACTDetValorNeto = new decimal[1] ;
         T006R3_A2152ACTDetValorResiduo = new decimal[1] ;
         T006R3_A2154ACTDetVidaUtil = new decimal[1] ;
         T006R3_A2151ACTDetValorReparacion = new decimal[1] ;
         T006R3_A2149ACTDetValorCompras = new decimal[1] ;
         T006R3_A2153ACTDetValorRetiro = new decimal[1] ;
         T006R3_A2148ACTDetSts = new string[] {""} ;
         T006R3_A2141ACTDetBajFec = new DateTime[] {DateTime.MinValue} ;
         T006R3_A2100ACTActCod = new string[] {""} ;
         T006R3_A2114ACTSGrupCod = new string[] {""} ;
         T006R3_A426ACTClaCod = new string[] {""} ;
         T006R3_n426ACTClaCod = new bool[] {false} ;
         T006R3_A2103ACTGrupCod = new string[] {""} ;
         sMode185 = "";
         T006R12_A2100ACTActCod = new string[] {""} ;
         T006R12_A2104ActActItem = new string[] {""} ;
         T006R12_n2104ActActItem = new bool[] {false} ;
         T006R13_A2100ACTActCod = new string[] {""} ;
         T006R13_A2104ActActItem = new string[] {""} ;
         T006R13_n2104ActActItem = new bool[] {false} ;
         T006R2_A2104ActActItem = new string[] {""} ;
         T006R2_n2104ActActItem = new bool[] {false} ;
         T006R2_A2146ACTDetParte = new string[] {""} ;
         T006R2_A2147ACTDetSerie = new string[] {""} ;
         T006R2_A2145ACTDetModelo = new string[] {""} ;
         T006R2_A2144ACTDetMarca = new string[] {""} ;
         T006R2_A2140ACTDetAno = new string[] {""} ;
         T006R2_A2142ACTDetCap = new string[] {""} ;
         T006R2_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         T006R2_A2150ACTDetValorNeto = new decimal[1] ;
         T006R2_A2152ACTDetValorResiduo = new decimal[1] ;
         T006R2_A2154ACTDetVidaUtil = new decimal[1] ;
         T006R2_A2151ACTDetValorReparacion = new decimal[1] ;
         T006R2_A2149ACTDetValorCompras = new decimal[1] ;
         T006R2_A2153ACTDetValorRetiro = new decimal[1] ;
         T006R2_A2148ACTDetSts = new string[] {""} ;
         T006R2_A2141ACTDetBajFec = new DateTime[] {DateTime.MinValue} ;
         T006R2_A2100ACTActCod = new string[] {""} ;
         T006R2_A2114ACTSGrupCod = new string[] {""} ;
         T006R2_A426ACTClaCod = new string[] {""} ;
         T006R2_n426ACTClaCod = new bool[] {false} ;
         T006R2_A2103ACTGrupCod = new string[] {""} ;
         T006R17_A426ACTClaCod = new string[] {""} ;
         T006R17_n426ACTClaCod = new bool[] {false} ;
         T006R17_A2103ACTGrupCod = new string[] {""} ;
         T006R18_A2155ACTSGrupDsc = new string[] {""} ;
         T006R18_A2156ACTSGrupPor = new decimal[1] ;
         T006R19_A2113ACTRevCod = new string[] {""} ;
         T006R20_A2112AMRepCod = new string[] {""} ;
         T006R21_A2109AMovCod = new string[] {""} ;
         T006R22_A2106ACTABajCod = new string[] {""} ;
         T006R23_A2105ACTRetCod = new string[] {""} ;
         T006R24_A2107ACTHisAno = new short[1] ;
         T006R24_A2108ACTHisMes = new short[1] ;
         T006R24_A2100ACTActCod = new string[] {""} ;
         T006R24_A2104ActActItem = new string[] {""} ;
         T006R24_n2104ActActItem = new bool[] {false} ;
         T006R25_A2100ACTActCod = new string[] {""} ;
         T006R25_A2104ActActItem = new string[] {""} ;
         T006R25_n2104ActActItem = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T006R26_A426ACTClaCod = new string[] {""} ;
         T006R26_n426ACTClaCod = new bool[] {false} ;
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2114ACTSGrupCod = "";
         ZZ2146ACTDetParte = "";
         ZZ2147ACTDetSerie = "";
         ZZ2145ACTDetModelo = "";
         ZZ2144ACTDetMarca = "";
         ZZ2140ACTDetAno = "";
         ZZ2142ACTDetCap = "";
         ZZ2143ACTDetFecIni = DateTime.MinValue;
         ZZ2148ACTDetSts = "";
         ZZ2141ACTDetBajFec = DateTime.MinValue;
         ZZ426ACTClaCod = "";
         ZZ2103ACTGrupCod = "";
         ZZ2155ACTSGrupDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actactivosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actactivosdet__default(),
            new Object[][] {
                new Object[] {
               T006R2_A2104ActActItem, T006R2_A2146ACTDetParte, T006R2_A2147ACTDetSerie, T006R2_A2145ACTDetModelo, T006R2_A2144ACTDetMarca, T006R2_A2140ACTDetAno, T006R2_A2142ACTDetCap, T006R2_A2143ACTDetFecIni, T006R2_A2150ACTDetValorNeto, T006R2_A2152ACTDetValorResiduo,
               T006R2_A2154ACTDetVidaUtil, T006R2_A2151ACTDetValorReparacion, T006R2_A2149ACTDetValorCompras, T006R2_A2153ACTDetValorRetiro, T006R2_A2148ACTDetSts, T006R2_A2141ACTDetBajFec, T006R2_A2100ACTActCod, T006R2_A2114ACTSGrupCod, T006R2_A426ACTClaCod, T006R2_n426ACTClaCod,
               T006R2_A2103ACTGrupCod
               }
               , new Object[] {
               T006R3_A2104ActActItem, T006R3_A2146ACTDetParte, T006R3_A2147ACTDetSerie, T006R3_A2145ACTDetModelo, T006R3_A2144ACTDetMarca, T006R3_A2140ACTDetAno, T006R3_A2142ACTDetCap, T006R3_A2143ACTDetFecIni, T006R3_A2150ACTDetValorNeto, T006R3_A2152ACTDetValorResiduo,
               T006R3_A2154ACTDetVidaUtil, T006R3_A2151ACTDetValorReparacion, T006R3_A2149ACTDetValorCompras, T006R3_A2153ACTDetValorRetiro, T006R3_A2148ACTDetSts, T006R3_A2141ACTDetBajFec, T006R3_A2100ACTActCod, T006R3_A2114ACTSGrupCod, T006R3_A426ACTClaCod, T006R3_n426ACTClaCod,
               T006R3_A2103ACTGrupCod
               }
               , new Object[] {
               T006R4_A426ACTClaCod, T006R4_A2103ACTGrupCod
               }
               , new Object[] {
               T006R5_A2155ACTSGrupDsc, T006R5_A2156ACTSGrupPor
               }
               , new Object[] {
               T006R6_A426ACTClaCod
               }
               , new Object[] {
               T006R7_A2104ActActItem, T006R7_A2155ACTSGrupDsc, T006R7_A2156ACTSGrupPor, T006R7_A2146ACTDetParte, T006R7_A2147ACTDetSerie, T006R7_A2145ACTDetModelo, T006R7_A2144ACTDetMarca, T006R7_A2140ACTDetAno, T006R7_A2142ACTDetCap, T006R7_A2143ACTDetFecIni,
               T006R7_A2150ACTDetValorNeto, T006R7_A2152ACTDetValorResiduo, T006R7_A2154ACTDetVidaUtil, T006R7_A2151ACTDetValorReparacion, T006R7_A2149ACTDetValorCompras, T006R7_A2153ACTDetValorRetiro, T006R7_A426ACTClaCod, T006R7_n426ACTClaCod, T006R7_A2103ACTGrupCod, T006R7_A2148ACTDetSts,
               T006R7_A2141ACTDetBajFec, T006R7_A2100ACTActCod, T006R7_A2114ACTSGrupCod
               }
               , new Object[] {
               T006R8_A426ACTClaCod, T006R8_A2103ACTGrupCod
               }
               , new Object[] {
               T006R9_A426ACTClaCod
               }
               , new Object[] {
               T006R10_A2155ACTSGrupDsc, T006R10_A2156ACTSGrupPor
               }
               , new Object[] {
               T006R11_A2100ACTActCod, T006R11_A2104ActActItem
               }
               , new Object[] {
               T006R12_A2100ACTActCod, T006R12_A2104ActActItem
               }
               , new Object[] {
               T006R13_A2100ACTActCod, T006R13_A2104ActActItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006R17_A426ACTClaCod, T006R17_A2103ACTGrupCod
               }
               , new Object[] {
               T006R18_A2155ACTSGrupDsc, T006R18_A2156ACTSGrupPor
               }
               , new Object[] {
               T006R19_A2113ACTRevCod
               }
               , new Object[] {
               T006R20_A2112AMRepCod
               }
               , new Object[] {
               T006R21_A2109AMovCod
               }
               , new Object[] {
               T006R22_A2106ACTABajCod
               }
               , new Object[] {
               T006R23_A2105ACTRetCod
               }
               , new Object[] {
               T006R24_A2107ACTHisAno, T006R24_A2108ACTHisMes, T006R24_A2100ACTActCod, T006R24_A2104ActActItem
               }
               , new Object[] {
               T006R25_A2100ACTActCod, T006R25_A2104ActActItem
               }
               , new Object[] {
               T006R26_A426ACTClaCod
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
      private short RcdFound185 ;
      private short nIsDirty_185 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTActCod_Enabled ;
      private int edtActActItem_Enabled ;
      private int edtACTSGrupCod_Enabled ;
      private int edtACTSGrupDsc_Enabled ;
      private int edtACTSGrupPor_Enabled ;
      private int edtACTDetParte_Enabled ;
      private int edtACTDetSerie_Enabled ;
      private int edtACTDetModelo_Enabled ;
      private int edtACTDetMarca_Enabled ;
      private int edtACTDetAno_Enabled ;
      private int edtACTDetCap_Enabled ;
      private int edtACTDetFecIni_Enabled ;
      private int edtACTDetValorNeto_Enabled ;
      private int edtACTDetValorResiduo_Enabled ;
      private int edtACTDetVidaUtil_Enabled ;
      private int edtACTDetValorReparacion_Enabled ;
      private int edtACTDetValorCompras_Enabled ;
      private int edtACTDetValorRetiro_Enabled ;
      private int edtACTClaCod_Enabled ;
      private int edtACTGrupCod_Enabled ;
      private int edtACTDetSts_Enabled ;
      private int edtACTDetBajFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z2150ACTDetValorNeto ;
      private decimal Z2152ACTDetValorResiduo ;
      private decimal Z2154ACTDetVidaUtil ;
      private decimal Z2151ACTDetValorReparacion ;
      private decimal Z2149ACTDetValorCompras ;
      private decimal Z2153ACTDetValorRetiro ;
      private decimal A2156ACTSGrupPor ;
      private decimal A2150ACTDetValorNeto ;
      private decimal A2152ACTDetValorResiduo ;
      private decimal A2154ACTDetVidaUtil ;
      private decimal A2151ACTDetValorReparacion ;
      private decimal A2149ACTDetValorCompras ;
      private decimal A2153ACTDetValorRetiro ;
      private decimal Z2156ACTSGrupPor ;
      private decimal ZZ2150ACTDetValorNeto ;
      private decimal ZZ2152ACTDetValorResiduo ;
      private decimal ZZ2154ACTDetVidaUtil ;
      private decimal ZZ2151ACTDetValorReparacion ;
      private decimal ZZ2149ACTDetValorCompras ;
      private decimal ZZ2153ACTDetValorRetiro ;
      private decimal ZZ2156ACTSGrupPor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTActCod_Internalname ;
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
      private string edtACTActCod_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtACTSGrupCod_Internalname ;
      private string edtACTSGrupCod_Jsonclick ;
      private string edtACTSGrupDsc_Internalname ;
      private string A2155ACTSGrupDsc ;
      private string edtACTSGrupDsc_Jsonclick ;
      private string edtACTSGrupPor_Internalname ;
      private string edtACTSGrupPor_Jsonclick ;
      private string edtACTDetParte_Internalname ;
      private string edtACTDetParte_Jsonclick ;
      private string edtACTDetSerie_Internalname ;
      private string edtACTDetSerie_Jsonclick ;
      private string edtACTDetModelo_Internalname ;
      private string edtACTDetModelo_Jsonclick ;
      private string edtACTDetMarca_Internalname ;
      private string edtACTDetMarca_Jsonclick ;
      private string edtACTDetAno_Internalname ;
      private string edtACTDetAno_Jsonclick ;
      private string edtACTDetCap_Internalname ;
      private string edtACTDetCap_Jsonclick ;
      private string edtACTDetFecIni_Internalname ;
      private string edtACTDetFecIni_Jsonclick ;
      private string edtACTDetValorNeto_Internalname ;
      private string edtACTDetValorNeto_Jsonclick ;
      private string edtACTDetValorResiduo_Internalname ;
      private string edtACTDetValorResiduo_Jsonclick ;
      private string edtACTDetVidaUtil_Internalname ;
      private string edtACTDetVidaUtil_Jsonclick ;
      private string edtACTDetValorReparacion_Internalname ;
      private string edtACTDetValorReparacion_Jsonclick ;
      private string edtACTDetValorCompras_Internalname ;
      private string edtACTDetValorCompras_Jsonclick ;
      private string edtACTDetValorRetiro_Internalname ;
      private string edtACTDetValorRetiro_Jsonclick ;
      private string edtACTClaCod_Internalname ;
      private string edtACTClaCod_Jsonclick ;
      private string edtACTGrupCod_Internalname ;
      private string edtACTGrupCod_Jsonclick ;
      private string edtACTDetSts_Internalname ;
      private string edtACTDetSts_Jsonclick ;
      private string edtACTDetBajFec_Internalname ;
      private string edtACTDetBajFec_Jsonclick ;
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
      private string Z2155ACTSGrupDsc ;
      private string sMode185 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2155ACTSGrupDsc ;
      private DateTime Z2143ACTDetFecIni ;
      private DateTime Z2141ACTDetBajFec ;
      private DateTime A2143ACTDetFecIni ;
      private DateTime A2141ACTDetBajFec ;
      private DateTime ZZ2143ACTDetFecIni ;
      private DateTime ZZ2141ACTDetBajFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n426ACTClaCod ;
      private bool wbErr ;
      private bool n2104ActActItem ;
      private bool Gx_longc ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string Z2146ACTDetParte ;
      private string Z2147ACTDetSerie ;
      private string Z2145ACTDetModelo ;
      private string Z2144ACTDetMarca ;
      private string Z2140ACTDetAno ;
      private string Z2142ACTDetCap ;
      private string Z2148ACTDetSts ;
      private string Z2114ACTSGrupCod ;
      private string A2100ACTActCod ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2114ACTSGrupCod ;
      private string A2104ActActItem ;
      private string A2146ACTDetParte ;
      private string A2147ACTDetSerie ;
      private string A2145ACTDetModelo ;
      private string A2144ACTDetMarca ;
      private string A2140ACTDetAno ;
      private string A2142ACTDetCap ;
      private string A2148ACTDetSts ;
      private string Z426ACTClaCod ;
      private string Z2103ACTGrupCod ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private string ZZ2114ACTSGrupCod ;
      private string ZZ2146ACTDetParte ;
      private string ZZ2147ACTDetSerie ;
      private string ZZ2145ACTDetModelo ;
      private string ZZ2144ACTDetMarca ;
      private string ZZ2140ACTDetAno ;
      private string ZZ2142ACTDetCap ;
      private string ZZ2148ACTDetSts ;
      private string ZZ426ACTClaCod ;
      private string ZZ2103ACTGrupCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006R7_A2104ActActItem ;
      private bool[] T006R7_n2104ActActItem ;
      private string[] T006R7_A2155ACTSGrupDsc ;
      private decimal[] T006R7_A2156ACTSGrupPor ;
      private string[] T006R7_A2146ACTDetParte ;
      private string[] T006R7_A2147ACTDetSerie ;
      private string[] T006R7_A2145ACTDetModelo ;
      private string[] T006R7_A2144ACTDetMarca ;
      private string[] T006R7_A2140ACTDetAno ;
      private string[] T006R7_A2142ACTDetCap ;
      private DateTime[] T006R7_A2143ACTDetFecIni ;
      private decimal[] T006R7_A2150ACTDetValorNeto ;
      private decimal[] T006R7_A2152ACTDetValorResiduo ;
      private decimal[] T006R7_A2154ACTDetVidaUtil ;
      private decimal[] T006R7_A2151ACTDetValorReparacion ;
      private decimal[] T006R7_A2149ACTDetValorCompras ;
      private decimal[] T006R7_A2153ACTDetValorRetiro ;
      private string[] T006R7_A426ACTClaCod ;
      private bool[] T006R7_n426ACTClaCod ;
      private string[] T006R7_A2103ACTGrupCod ;
      private string[] T006R7_A2148ACTDetSts ;
      private DateTime[] T006R7_A2141ACTDetBajFec ;
      private string[] T006R7_A2100ACTActCod ;
      private string[] T006R7_A2114ACTSGrupCod ;
      private string[] T006R4_A426ACTClaCod ;
      private bool[] T006R4_n426ACTClaCod ;
      private string[] T006R4_A2103ACTGrupCod ;
      private string[] T006R6_A426ACTClaCod ;
      private bool[] T006R6_n426ACTClaCod ;
      private string[] T006R5_A2155ACTSGrupDsc ;
      private decimal[] T006R5_A2156ACTSGrupPor ;
      private string[] T006R8_A426ACTClaCod ;
      private bool[] T006R8_n426ACTClaCod ;
      private string[] T006R8_A2103ACTGrupCod ;
      private string[] T006R9_A426ACTClaCod ;
      private bool[] T006R9_n426ACTClaCod ;
      private string[] T006R10_A2155ACTSGrupDsc ;
      private decimal[] T006R10_A2156ACTSGrupPor ;
      private string[] T006R11_A2100ACTActCod ;
      private string[] T006R11_A2104ActActItem ;
      private bool[] T006R11_n2104ActActItem ;
      private string[] T006R3_A2104ActActItem ;
      private bool[] T006R3_n2104ActActItem ;
      private string[] T006R3_A2146ACTDetParte ;
      private string[] T006R3_A2147ACTDetSerie ;
      private string[] T006R3_A2145ACTDetModelo ;
      private string[] T006R3_A2144ACTDetMarca ;
      private string[] T006R3_A2140ACTDetAno ;
      private string[] T006R3_A2142ACTDetCap ;
      private DateTime[] T006R3_A2143ACTDetFecIni ;
      private decimal[] T006R3_A2150ACTDetValorNeto ;
      private decimal[] T006R3_A2152ACTDetValorResiduo ;
      private decimal[] T006R3_A2154ACTDetVidaUtil ;
      private decimal[] T006R3_A2151ACTDetValorReparacion ;
      private decimal[] T006R3_A2149ACTDetValorCompras ;
      private decimal[] T006R3_A2153ACTDetValorRetiro ;
      private string[] T006R3_A2148ACTDetSts ;
      private DateTime[] T006R3_A2141ACTDetBajFec ;
      private string[] T006R3_A2100ACTActCod ;
      private string[] T006R3_A2114ACTSGrupCod ;
      private string[] T006R3_A426ACTClaCod ;
      private bool[] T006R3_n426ACTClaCod ;
      private string[] T006R3_A2103ACTGrupCod ;
      private string[] T006R12_A2100ACTActCod ;
      private string[] T006R12_A2104ActActItem ;
      private bool[] T006R12_n2104ActActItem ;
      private string[] T006R13_A2100ACTActCod ;
      private string[] T006R13_A2104ActActItem ;
      private bool[] T006R13_n2104ActActItem ;
      private string[] T006R2_A2104ActActItem ;
      private bool[] T006R2_n2104ActActItem ;
      private string[] T006R2_A2146ACTDetParte ;
      private string[] T006R2_A2147ACTDetSerie ;
      private string[] T006R2_A2145ACTDetModelo ;
      private string[] T006R2_A2144ACTDetMarca ;
      private string[] T006R2_A2140ACTDetAno ;
      private string[] T006R2_A2142ACTDetCap ;
      private DateTime[] T006R2_A2143ACTDetFecIni ;
      private decimal[] T006R2_A2150ACTDetValorNeto ;
      private decimal[] T006R2_A2152ACTDetValorResiduo ;
      private decimal[] T006R2_A2154ACTDetVidaUtil ;
      private decimal[] T006R2_A2151ACTDetValorReparacion ;
      private decimal[] T006R2_A2149ACTDetValorCompras ;
      private decimal[] T006R2_A2153ACTDetValorRetiro ;
      private string[] T006R2_A2148ACTDetSts ;
      private DateTime[] T006R2_A2141ACTDetBajFec ;
      private string[] T006R2_A2100ACTActCod ;
      private string[] T006R2_A2114ACTSGrupCod ;
      private string[] T006R2_A426ACTClaCod ;
      private bool[] T006R2_n426ACTClaCod ;
      private string[] T006R2_A2103ACTGrupCod ;
      private string[] T006R17_A426ACTClaCod ;
      private bool[] T006R17_n426ACTClaCod ;
      private string[] T006R17_A2103ACTGrupCod ;
      private string[] T006R18_A2155ACTSGrupDsc ;
      private decimal[] T006R18_A2156ACTSGrupPor ;
      private string[] T006R19_A2113ACTRevCod ;
      private string[] T006R20_A2112AMRepCod ;
      private string[] T006R21_A2109AMovCod ;
      private string[] T006R22_A2106ACTABajCod ;
      private string[] T006R23_A2105ACTRetCod ;
      private short[] T006R24_A2107ACTHisAno ;
      private short[] T006R24_A2108ACTHisMes ;
      private string[] T006R24_A2100ACTActCod ;
      private string[] T006R24_A2104ActActItem ;
      private bool[] T006R24_n2104ActActItem ;
      private string[] T006R25_A2100ACTActCod ;
      private string[] T006R25_A2104ActActItem ;
      private bool[] T006R25_n2104ActActItem ;
      private string[] T006R26_A426ACTClaCod ;
      private bool[] T006R26_n426ACTClaCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class actactivosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actactivosdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006R7;
        prmT006R7 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R4;
        prmT006R4 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006R6;
        prmT006R6 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R5;
        prmT006R5 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006R8;
        prmT006R8 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006R9;
        prmT006R9 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R10;
        prmT006R10 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006R11;
        prmT006R11 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R3;
        prmT006R3 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R12;
        prmT006R12 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R13;
        prmT006R13 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R2;
        prmT006R2 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R14;
        prmT006R14 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTDetParte",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetSerie",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetModelo",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetMarca",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetAno",GXType.NVarChar,4,0) ,
        new ParDef("@ACTDetCap",GXType.NVarChar,20,0) ,
        new ParDef("@ACTDetFecIni",GXType.Date,8,0) ,
        new ParDef("@ACTDetValorNeto",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetValorResiduo",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetVidaUtil",GXType.Decimal,6,2) ,
        new ParDef("@ACTDetValorReparacion",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetValorCompras",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetValorRetiro",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetSts",GXType.NVarChar,1,0) ,
        new ParDef("@ACTDetBajFec",GXType.Date,8,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006R15;
        prmT006R15 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTDetParte",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetSerie",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetModelo",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetMarca",GXType.NVarChar,50,0) ,
        new ParDef("@ACTDetAno",GXType.NVarChar,4,0) ,
        new ParDef("@ACTDetCap",GXType.NVarChar,20,0) ,
        new ParDef("@ACTDetFecIni",GXType.Date,8,0) ,
        new ParDef("@ACTDetValorNeto",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetValorResiduo",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetVidaUtil",GXType.Decimal,6,2) ,
        new ParDef("@ACTDetValorReparacion",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetValorCompras",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetValorRetiro",GXType.Decimal,15,2) ,
        new ParDef("@ACTDetSts",GXType.NVarChar,1,0) ,
        new ParDef("@ACTDetBajFec",GXType.Date,8,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R16;
        prmT006R16 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R19;
        prmT006R19 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R20;
        prmT006R20 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R21;
        prmT006R21 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R22;
        prmT006R22 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R23;
        prmT006R23 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R24;
        prmT006R24 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R25;
        prmT006R25 = new Object[] {
        };
        Object[] prmT006R17;
        prmT006R17 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006R26;
        prmT006R26 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006R18;
        prmT006R18 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006R2", "SELECT [ActActItem], [ACTDetParte], [ACTDetSerie], [ACTDetModelo], [ACTDetMarca], [ACTDetAno], [ACTDetCap], [ACTDetFecIni], [ACTDetValorNeto], [ACTDetValorResiduo], [ACTDetVidaUtil], [ACTDetValorReparacion], [ACTDetValorCompras], [ACTDetValorRetiro], [ACTDetSts], [ACTDetBajFec], [ACTActCod], [ACTSGrupCod], [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOSDET] WITH (UPDLOCK) WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R3", "SELECT [ActActItem], [ACTDetParte], [ACTDetSerie], [ACTDetModelo], [ACTDetMarca], [ACTDetAno], [ACTDetCap], [ACTDetFecIni], [ACTDetValorNeto], [ACTDetValorResiduo], [ACTDetVidaUtil], [ACTDetValorReparacion], [ACTDetValorCompras], [ACTDetValorRetiro], [ACTDetSts], [ACTDetBajFec], [ACTActCod], [ACTSGrupCod], [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R4", "SELECT [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R5", "SELECT [ACTSGrupDsc], [ACTSGrupPor] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R6", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R7", "SELECT TM1.[ActActItem], T2.[ACTSGrupDsc], T2.[ACTSGrupPor], TM1.[ACTDetParte], TM1.[ACTDetSerie], TM1.[ACTDetModelo], TM1.[ACTDetMarca], TM1.[ACTDetAno], TM1.[ACTDetCap], TM1.[ACTDetFecIni], TM1.[ACTDetValorNeto], TM1.[ACTDetValorResiduo], TM1.[ACTDetVidaUtil], TM1.[ACTDetValorReparacion], TM1.[ACTDetValorCompras], TM1.[ACTDetValorRetiro], TM1.[ACTClaCod], TM1.[ACTGrupCod], TM1.[ACTDetSts], TM1.[ACTDetBajFec], TM1.[ACTActCod], TM1.[ACTSGrupCod] FROM ([ACTACTIVOSDET] TM1 LEFT JOIN [ACTSUBGRUPO] T2 ON T2.[ACTClaCod] = TM1.[ACTClaCod] AND T2.[ACTGrupCod] = TM1.[ACTGrupCod] AND T2.[ACTSGrupCod] = TM1.[ACTSGrupCod]) WHERE TM1.[ACTActCod] = @ACTActCod and TM1.[ActActItem] = @ActActItem ORDER BY TM1.[ACTActCod], TM1.[ActActItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006R7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R8", "SELECT [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R9", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R10", "SELECT [ACTSGrupDsc], [ACTSGrupPor] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R11", "SELECT [ACTActCod], [ActActItem] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006R11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R12", "SELECT TOP 1 [ACTActCod], [ActActItem] FROM [ACTACTIVOSDET] WHERE ( [ACTActCod] > @ACTActCod or [ACTActCod] = @ACTActCod and [ActActItem] > @ActActItem) ORDER BY [ACTActCod], [ActActItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006R12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R13", "SELECT TOP 1 [ACTActCod], [ActActItem] FROM [ACTACTIVOSDET] WHERE ( [ACTActCod] < @ACTActCod or [ACTActCod] = @ACTActCod and [ActActItem] < @ActActItem) ORDER BY [ACTActCod] DESC, [ActActItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006R13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R14", "INSERT INTO [ACTACTIVOSDET]([ACTClaCod], [ACTGrupCod], [ActActItem], [ACTDetParte], [ACTDetSerie], [ACTDetModelo], [ACTDetMarca], [ACTDetAno], [ACTDetCap], [ACTDetFecIni], [ACTDetValorNeto], [ACTDetValorResiduo], [ACTDetVidaUtil], [ACTDetValorReparacion], [ACTDetValorCompras], [ACTDetValorRetiro], [ACTDetSts], [ACTDetBajFec], [ACTActCod], [ACTSGrupCod]) VALUES(@ACTClaCod, @ACTGrupCod, @ActActItem, @ACTDetParte, @ACTDetSerie, @ACTDetModelo, @ACTDetMarca, @ACTDetAno, @ACTDetCap, @ACTDetFecIni, @ACTDetValorNeto, @ACTDetValorResiduo, @ACTDetVidaUtil, @ACTDetValorReparacion, @ACTDetValorCompras, @ACTDetValorRetiro, @ACTDetSts, @ACTDetBajFec, @ACTActCod, @ACTSGrupCod)", GxErrorMask.GX_NOMASK,prmT006R14)
           ,new CursorDef("T006R15", "UPDATE [ACTACTIVOSDET] SET [ACTClaCod]=@ACTClaCod, [ACTGrupCod]=@ACTGrupCod, [ACTDetParte]=@ACTDetParte, [ACTDetSerie]=@ACTDetSerie, [ACTDetModelo]=@ACTDetModelo, [ACTDetMarca]=@ACTDetMarca, [ACTDetAno]=@ACTDetAno, [ACTDetCap]=@ACTDetCap, [ACTDetFecIni]=@ACTDetFecIni, [ACTDetValorNeto]=@ACTDetValorNeto, [ACTDetValorResiduo]=@ACTDetValorResiduo, [ACTDetVidaUtil]=@ACTDetVidaUtil, [ACTDetValorReparacion]=@ACTDetValorReparacion, [ACTDetValorCompras]=@ACTDetValorCompras, [ACTDetValorRetiro]=@ACTDetValorRetiro, [ACTDetSts]=@ACTDetSts, [ACTDetBajFec]=@ACTDetBajFec, [ACTSGrupCod]=@ACTSGrupCod  WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem", GxErrorMask.GX_NOMASK,prmT006R15)
           ,new CursorDef("T006R16", "DELETE FROM [ACTACTIVOSDET]  WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem", GxErrorMask.GX_NOMASK,prmT006R16)
           ,new CursorDef("T006R17", "SELECT [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R18", "SELECT [ACTSGrupDsc], [ACTSGrupPor] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R19", "SELECT TOP 1 [ACTRevCod] FROM [ACTRevaluacion] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R20", "SELECT TOP 1 [AMRepCod] FROM [ACTMOVREPARACION] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R21", "SELECT TOP 1 [AMovCod] FROM [ACTMOVACTIVO] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R22", "SELECT TOP 1 [ACTABajCod] FROM [ACTBAJAACTIVO] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R23", "SELECT TOP 1 [ACTRetCod] FROM [ACTRETIROACTIVO] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R24", "SELECT TOP 1 [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006R25", "SELECT [ACTActCod], [ActActItem] FROM [ACTACTIVOSDET] ORDER BY [ACTActCod], [ActActItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006R25,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006R26", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006R26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((bool[]) buf[19])[0] = rslt.wasNull(19);
              ((string[]) buf[20])[0] = rslt.getVarchar(20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((bool[]) buf[19])[0] = rslt.wasNull(19);
              ((string[]) buf[20])[0] = rslt.getVarchar(20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((bool[]) buf[17])[0] = rslt.wasNull(17);
              ((string[]) buf[18])[0] = rslt.getVarchar(18);
              ((string[]) buf[19])[0] = rslt.getVarchar(19);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(20);
              ((string[]) buf[21])[0] = rslt.getVarchar(21);
              ((string[]) buf[22])[0] = rslt.getVarchar(22);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
