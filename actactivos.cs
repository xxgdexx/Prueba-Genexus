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
   public class actactivos : GXHttpHandler
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
            A426ACTClaCod = GetPar( "ACTClaCod");
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = GetPar( "ACTGrupCod");
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A426ACTClaCod, A2103ACTGrupCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A2102ACTAreaCod = GetPar( "ACTAreaCod");
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A2102ACTAreaCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A2101ActUbiCod = GetPar( "ActUbiCod");
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A2101ActUbiCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A79COSCod = GetPar( "COSCod");
            AssignAttri("", false, "A79COSCod", A79COSCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A79COSCod) ;
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
            Form.Meta.addItem("description", "ACTACTIVOS", 0) ;
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

      public actactivos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actactivos( IGxContext context )
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
            RenderHtmlCloseForm6Q184( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ACTACTIVOS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTACTIVOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTACTIVOS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActCodEQV_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActCodEQV_Internalname, "Codigo Equipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCodEQV_Internalname, A2118ACTActCodEQV, StringUtil.RTrim( context.localUtil.Format( A2118ACTActCodEQV, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCodEQV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCodEQV_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTClaCod_Internalname, A426ACTClaCod, StringUtil.RTrim( context.localUtil.Format( A426ACTClaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTClaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTGrupCod_Internalname, A2103ACTGrupCod, StringUtil.RTrim( context.localUtil.Format( A2103ACTGrupCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActDsc_Internalname, "Descripción Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActDsc_Internalname, A2122ACTActDsc, StringUtil.RTrim( context.localUtil.Format( A2122ACTActDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActObs_Internalname, "Comentarios Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtACTActObs_Internalname, A2131ACTActObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", 0, 1, edtACTActObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActTipCod_Internalname, "Tipo Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActTipCod_Internalname, StringUtil.RTrim( A2138ACTActTipCod), StringUtil.RTrim( context.localUtil.Format( A2138ACTActTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActTipCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActDocNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActDocNum_Internalname, "N° Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActDocNum_Internalname, A2121ACTActDocNum, StringUtil.RTrim( context.localUtil.Format( A2121ACTActDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDocNum_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActFech_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActFech_Internalname, "Fecha Adquisión", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTActFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTActFech_Internalname, context.localUtil.Format(A2123ACTActFech, "99/99/99"), context.localUtil.Format( A2123ACTActFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_bitmap( context, edtACTActFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTActFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTACTIVOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActReg_Internalname, "N° Registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActReg_Internalname, StringUtil.RTrim( A2134ACTActReg), StringUtil.RTrim( context.localUtil.Format( A2134ACTActReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActModelo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActModelo_Internalname, "Modelo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActModelo_Internalname, A2129ACTActModelo, StringUtil.RTrim( context.localUtil.Format( A2129ACTActModelo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActModelo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActModelo_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActSerie_Internalname, "N° Serie", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActSerie_Internalname, A2135ACTActSerie, StringUtil.RTrim( context.localUtil.Format( A2135ACTActSerie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActSerie_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActParte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActParte_Internalname, "N° Parte", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActParte_Internalname, A2133ACTActParte, StringUtil.RTrim( context.localUtil.Format( A2133ACTActParte, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActParte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActParte_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActCap_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActCap_Internalname, "Capacidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCap_Internalname, A2117ACTActCap, StringUtil.RTrim( context.localUtil.Format( A2117ACTActCap, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCap_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCap_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActAno_Internalname, "Fabricación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActAno_Internalname, A2116ACTActAno, StringUtil.RTrim( context.localUtil.Format( A2116ACTActAno, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActAno_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActMarca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActMarca_Internalname, "Marca", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActMarca_Internalname, A2128ACTActMarca, StringUtil.RTrim( context.localUtil.Format( A2128ACTActMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActMarca_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2130ACTActMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTActMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2130ACTActMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2130ACTActMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActActCostoMN_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActActCostoMN_Internalname, "Costo Adquisión MN", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActActCostoMN_Internalname, StringUtil.LTrim( StringUtil.NToC( A2119ActActCostoMN, 17, 2, ".", "")), StringUtil.LTrim( ((edtActActCostoMN_Enabled!=0) ? context.localUtil.Format( A2119ActActCostoMN, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2119ActActCostoMN, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActCostoMN_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActCostoMN_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActActTipCmb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActActTipCmb_Internalname, "Tipo Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActActTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A2137ActActTipCmb, 17, 4, ".", "")), StringUtil.LTrim( ((edtActActTipCmb_Enabled!=0) ? context.localUtil.Format( A2137ActActTipCmb, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2137ActActTipCmb, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActTipCmb_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActSts_Internalname, "Estado Actual", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActSts_Internalname, A2136ACTActSts, StringUtil.RTrim( context.localUtil.Format( A2136ACTActSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActVida_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActVida_Internalname, "Vida Util Estimada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActVida_Internalname, StringUtil.LTrim( StringUtil.NToC( A2139ACTActVida, 6, 2, ".", "")), StringUtil.LTrim( ((edtACTActVida_Enabled!=0) ? context.localUtil.Format( A2139ACTActVida, "ZZ9.99") : context.localUtil.Format( A2139ACTActVida, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActVida_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActVida_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgACTActFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A2125ACTActFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ACTActFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.PathToRelativeUrl( A2125ACTActFoto));
         GxWebStd.gx_bitmap( context, imgACTActFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgACTActFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "", "", "", 0, A2125ACTActFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ACTACTIVOS.htm");
         AssignProp("", false, imgACTActFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.PathToRelativeUrl( A2125ACTActFoto)), true);
         AssignProp("", false, imgACTActFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A2125ACTActFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTAreaCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTAreaCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTAreaCod_Internalname, A2102ACTAreaCod, StringUtil.RTrim( context.localUtil.Format( A2102ACTAreaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTAreaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTAreaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActOrd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActOrd_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActOrd_Internalname, A2132ACTActOrd, StringUtil.RTrim( context.localUtil.Format( A2132ACTActOrd, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActOrd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActOrd_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActUbiCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActUbiCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActUbiCod_Internalname, A2101ActUbiCod, StringUtil.RTrim( context.localUtil.Format( A2101ActUbiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActUbiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActUbiCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod), StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActFIni_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActFIni_Internalname, "Fecha Inicio Dep.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTActFIni_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTActFIni_Internalname, context.localUtil.Format(A2124ACTActFIni, "99/99/99"), context.localUtil.Format( A2124ACTActFIni, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActFIni_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActFIni_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_bitmap( context, edtACTActFIni_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTActFIni_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTACTIVOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActCostoMO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActCostoMO_Internalname, "Costo Adquisión MO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCostoMO_Internalname, StringUtil.LTrim( StringUtil.NToC( A2120ACTActCostoMO, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTActCostoMO_Enabled!=0) ? context.localUtil.Format( A2120ACTActCostoMO, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2120ACTActCostoMO, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCostoMO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCostoMO_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTACTIVOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTACTIVOS.htm");
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
            Z2118ACTActCodEQV = cgiGet( "Z2118ACTActCodEQV");
            Z2122ACTActDsc = cgiGet( "Z2122ACTActDsc");
            Z2138ACTActTipCod = cgiGet( "Z2138ACTActTipCod");
            Z2121ACTActDocNum = cgiGet( "Z2121ACTActDocNum");
            Z2123ACTActFech = context.localUtil.CToD( cgiGet( "Z2123ACTActFech"), 0);
            Z2134ACTActReg = cgiGet( "Z2134ACTActReg");
            Z2129ACTActModelo = cgiGet( "Z2129ACTActModelo");
            Z2135ACTActSerie = cgiGet( "Z2135ACTActSerie");
            Z2133ACTActParte = cgiGet( "Z2133ACTActParte");
            Z2117ACTActCap = cgiGet( "Z2117ACTActCap");
            Z2116ACTActAno = cgiGet( "Z2116ACTActAno");
            Z2128ACTActMarca = cgiGet( "Z2128ACTActMarca");
            Z2130ACTActMonCod = (int)(context.localUtil.CToN( cgiGet( "Z2130ACTActMonCod"), ".", ","));
            Z2119ActActCostoMN = context.localUtil.CToN( cgiGet( "Z2119ActActCostoMN"), ".", ",");
            Z2137ActActTipCmb = context.localUtil.CToN( cgiGet( "Z2137ActActTipCmb"), ".", ",");
            Z2136ACTActSts = cgiGet( "Z2136ACTActSts");
            Z2139ACTActVida = context.localUtil.CToN( cgiGet( "Z2139ACTActVida"), ".", ",");
            Z2132ACTActOrd = cgiGet( "Z2132ACTActOrd");
            Z2124ACTActFIni = context.localUtil.CToD( cgiGet( "Z2124ACTActFIni"), 0);
            Z2120ACTActCostoMO = context.localUtil.CToN( cgiGet( "Z2120ACTActCostoMO"), ".", ",");
            Z426ACTClaCod = cgiGet( "Z426ACTClaCod");
            Z2103ACTGrupCod = cgiGet( "Z2103ACTGrupCod");
            Z2102ACTAreaCod = cgiGet( "Z2102ACTAreaCod");
            Z2101ActUbiCod = cgiGet( "Z2101ActUbiCod");
            Z79COSCod = cgiGet( "Z79COSCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A40000ACTActFoto_GXI = cgiGet( "ACTACTFOTO_GXI");
            /* Read variables values. */
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2118ACTActCodEQV = cgiGet( edtACTActCodEQV_Internalname);
            AssignAttri("", false, "A2118ACTActCodEQV", A2118ACTActCodEQV);
            A426ACTClaCod = cgiGet( edtACTClaCod_Internalname);
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = cgiGet( edtACTGrupCod_Internalname);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2122ACTActDsc = cgiGet( edtACTActDsc_Internalname);
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2131ACTActObs = cgiGet( edtACTActObs_Internalname);
            AssignAttri("", false, "A2131ACTActObs", A2131ACTActObs);
            A2138ACTActTipCod = cgiGet( edtACTActTipCod_Internalname);
            AssignAttri("", false, "A2138ACTActTipCod", A2138ACTActTipCod);
            A2121ACTActDocNum = cgiGet( edtACTActDocNum_Internalname);
            AssignAttri("", false, "A2121ACTActDocNum", A2121ACTActDocNum);
            if ( context.localUtil.VCDate( cgiGet( edtACTActFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Adquisión"}), 1, "ACTACTFECH");
               AnyError = 1;
               GX_FocusControl = edtACTActFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2123ACTActFech = DateTime.MinValue;
               AssignAttri("", false, "A2123ACTActFech", context.localUtil.Format(A2123ACTActFech, "99/99/99"));
            }
            else
            {
               A2123ACTActFech = context.localUtil.CToD( cgiGet( edtACTActFech_Internalname), 2);
               AssignAttri("", false, "A2123ACTActFech", context.localUtil.Format(A2123ACTActFech, "99/99/99"));
            }
            A2134ACTActReg = cgiGet( edtACTActReg_Internalname);
            AssignAttri("", false, "A2134ACTActReg", A2134ACTActReg);
            A2129ACTActModelo = cgiGet( edtACTActModelo_Internalname);
            AssignAttri("", false, "A2129ACTActModelo", A2129ACTActModelo);
            A2135ACTActSerie = cgiGet( edtACTActSerie_Internalname);
            AssignAttri("", false, "A2135ACTActSerie", A2135ACTActSerie);
            A2133ACTActParte = cgiGet( edtACTActParte_Internalname);
            AssignAttri("", false, "A2133ACTActParte", A2133ACTActParte);
            A2117ACTActCap = cgiGet( edtACTActCap_Internalname);
            AssignAttri("", false, "A2117ACTActCap", A2117ACTActCap);
            A2116ACTActAno = cgiGet( edtACTActAno_Internalname);
            AssignAttri("", false, "A2116ACTActAno", A2116ACTActAno);
            A2128ACTActMarca = cgiGet( edtACTActMarca_Internalname);
            AssignAttri("", false, "A2128ACTActMarca", A2128ACTActMarca);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTActMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTActMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTACTMONCOD");
               AnyError = 1;
               GX_FocusControl = edtACTActMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2130ACTActMonCod = 0;
               AssignAttri("", false, "A2130ACTActMonCod", StringUtil.LTrimStr( (decimal)(A2130ACTActMonCod), 6, 0));
            }
            else
            {
               A2130ACTActMonCod = (int)(context.localUtil.CToN( cgiGet( edtACTActMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A2130ACTActMonCod", StringUtil.LTrimStr( (decimal)(A2130ACTActMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtActActCostoMN_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtActActCostoMN_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTACTCOSTOMN");
               AnyError = 1;
               GX_FocusControl = edtActActCostoMN_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2119ActActCostoMN = 0;
               AssignAttri("", false, "A2119ActActCostoMN", StringUtil.LTrimStr( A2119ActActCostoMN, 15, 2));
            }
            else
            {
               A2119ActActCostoMN = context.localUtil.CToN( cgiGet( edtActActCostoMN_Internalname), ".", ",");
               AssignAttri("", false, "A2119ActActCostoMN", StringUtil.LTrimStr( A2119ActActCostoMN, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtActActTipCmb_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtActActTipCmb_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTACTTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtActActTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2137ActActTipCmb = 0;
               AssignAttri("", false, "A2137ActActTipCmb", StringUtil.LTrimStr( A2137ActActTipCmb, 15, 4));
            }
            else
            {
               A2137ActActTipCmb = context.localUtil.CToN( cgiGet( edtActActTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A2137ActActTipCmb", StringUtil.LTrimStr( A2137ActActTipCmb, 15, 4));
            }
            A2136ACTActSts = cgiGet( edtACTActSts_Internalname);
            AssignAttri("", false, "A2136ACTActSts", A2136ACTActSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTActVida_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTActVida_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTACTVIDA");
               AnyError = 1;
               GX_FocusControl = edtACTActVida_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2139ACTActVida = 0;
               AssignAttri("", false, "A2139ACTActVida", StringUtil.LTrimStr( A2139ACTActVida, 6, 2));
            }
            else
            {
               A2139ACTActVida = context.localUtil.CToN( cgiGet( edtACTActVida_Internalname), ".", ",");
               AssignAttri("", false, "A2139ACTActVida", StringUtil.LTrimStr( A2139ACTActVida, 6, 2));
            }
            A2125ACTActFoto = cgiGet( imgACTActFoto_Internalname);
            AssignAttri("", false, "A2125ACTActFoto", A2125ACTActFoto);
            A2102ACTAreaCod = cgiGet( edtACTAreaCod_Internalname);
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            A2132ACTActOrd = cgiGet( edtACTActOrd_Internalname);
            AssignAttri("", false, "A2132ACTActOrd", A2132ACTActOrd);
            A2101ActUbiCod = cgiGet( edtActUbiCod_Internalname);
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            A79COSCod = cgiGet( edtCOSCod_Internalname);
            AssignAttri("", false, "A79COSCod", A79COSCod);
            if ( context.localUtil.VCDate( cgiGet( edtACTActFIni_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inicio Dep."}), 1, "ACTACTFINI");
               AnyError = 1;
               GX_FocusControl = edtACTActFIni_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2124ACTActFIni = DateTime.MinValue;
               AssignAttri("", false, "A2124ACTActFIni", context.localUtil.Format(A2124ACTActFIni, "99/99/99"));
            }
            else
            {
               A2124ACTActFIni = context.localUtil.CToD( cgiGet( edtACTActFIni_Internalname), 2);
               AssignAttri("", false, "A2124ACTActFIni", context.localUtil.Format(A2124ACTActFIni, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTActCostoMO_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTActCostoMO_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTACTCOSTOMO");
               AnyError = 1;
               GX_FocusControl = edtACTActCostoMO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2120ACTActCostoMO = 0;
               AssignAttri("", false, "A2120ACTActCostoMO", StringUtil.LTrimStr( A2120ACTActCostoMO, 15, 2));
            }
            else
            {
               A2120ACTActCostoMO = context.localUtil.CToN( cgiGet( edtACTActCostoMO_Internalname), ".", ",");
               AssignAttri("", false, "A2120ACTActCostoMO", StringUtil.LTrimStr( A2120ACTActCostoMO, 15, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgACTActFoto_Internalname, ref  A2125ACTActFoto, ref  A40000ACTActFoto_GXI);
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
               InitAll6Q184( ) ;
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
         DisableAttributes6Q184( ) ;
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

      protected void ResetCaption6Q0( )
      {
      }

      protected void ZM6Q184( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2118ACTActCodEQV = T006Q3_A2118ACTActCodEQV[0];
               Z2122ACTActDsc = T006Q3_A2122ACTActDsc[0];
               Z2138ACTActTipCod = T006Q3_A2138ACTActTipCod[0];
               Z2121ACTActDocNum = T006Q3_A2121ACTActDocNum[0];
               Z2123ACTActFech = T006Q3_A2123ACTActFech[0];
               Z2134ACTActReg = T006Q3_A2134ACTActReg[0];
               Z2129ACTActModelo = T006Q3_A2129ACTActModelo[0];
               Z2135ACTActSerie = T006Q3_A2135ACTActSerie[0];
               Z2133ACTActParte = T006Q3_A2133ACTActParte[0];
               Z2117ACTActCap = T006Q3_A2117ACTActCap[0];
               Z2116ACTActAno = T006Q3_A2116ACTActAno[0];
               Z2128ACTActMarca = T006Q3_A2128ACTActMarca[0];
               Z2130ACTActMonCod = T006Q3_A2130ACTActMonCod[0];
               Z2119ActActCostoMN = T006Q3_A2119ActActCostoMN[0];
               Z2137ActActTipCmb = T006Q3_A2137ActActTipCmb[0];
               Z2136ACTActSts = T006Q3_A2136ACTActSts[0];
               Z2139ACTActVida = T006Q3_A2139ACTActVida[0];
               Z2132ACTActOrd = T006Q3_A2132ACTActOrd[0];
               Z2124ACTActFIni = T006Q3_A2124ACTActFIni[0];
               Z2120ACTActCostoMO = T006Q3_A2120ACTActCostoMO[0];
               Z426ACTClaCod = T006Q3_A426ACTClaCod[0];
               Z2103ACTGrupCod = T006Q3_A2103ACTGrupCod[0];
               Z2102ACTAreaCod = T006Q3_A2102ACTAreaCod[0];
               Z2101ActUbiCod = T006Q3_A2101ActUbiCod[0];
               Z79COSCod = T006Q3_A79COSCod[0];
            }
            else
            {
               Z2118ACTActCodEQV = A2118ACTActCodEQV;
               Z2122ACTActDsc = A2122ACTActDsc;
               Z2138ACTActTipCod = A2138ACTActTipCod;
               Z2121ACTActDocNum = A2121ACTActDocNum;
               Z2123ACTActFech = A2123ACTActFech;
               Z2134ACTActReg = A2134ACTActReg;
               Z2129ACTActModelo = A2129ACTActModelo;
               Z2135ACTActSerie = A2135ACTActSerie;
               Z2133ACTActParte = A2133ACTActParte;
               Z2117ACTActCap = A2117ACTActCap;
               Z2116ACTActAno = A2116ACTActAno;
               Z2128ACTActMarca = A2128ACTActMarca;
               Z2130ACTActMonCod = A2130ACTActMonCod;
               Z2119ActActCostoMN = A2119ActActCostoMN;
               Z2137ActActTipCmb = A2137ActActTipCmb;
               Z2136ACTActSts = A2136ACTActSts;
               Z2139ACTActVida = A2139ACTActVida;
               Z2132ACTActOrd = A2132ACTActOrd;
               Z2124ACTActFIni = A2124ACTActFIni;
               Z2120ACTActCostoMO = A2120ACTActCostoMO;
               Z426ACTClaCod = A426ACTClaCod;
               Z2103ACTGrupCod = A2103ACTGrupCod;
               Z2102ACTAreaCod = A2102ACTAreaCod;
               Z2101ActUbiCod = A2101ActUbiCod;
               Z79COSCod = A79COSCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2100ACTActCod = A2100ACTActCod;
            Z2118ACTActCodEQV = A2118ACTActCodEQV;
            Z2122ACTActDsc = A2122ACTActDsc;
            Z2131ACTActObs = A2131ACTActObs;
            Z2138ACTActTipCod = A2138ACTActTipCod;
            Z2121ACTActDocNum = A2121ACTActDocNum;
            Z2123ACTActFech = A2123ACTActFech;
            Z2134ACTActReg = A2134ACTActReg;
            Z2129ACTActModelo = A2129ACTActModelo;
            Z2135ACTActSerie = A2135ACTActSerie;
            Z2133ACTActParte = A2133ACTActParte;
            Z2117ACTActCap = A2117ACTActCap;
            Z2116ACTActAno = A2116ACTActAno;
            Z2128ACTActMarca = A2128ACTActMarca;
            Z2130ACTActMonCod = A2130ACTActMonCod;
            Z2119ActActCostoMN = A2119ActActCostoMN;
            Z2137ActActTipCmb = A2137ActActTipCmb;
            Z2136ACTActSts = A2136ACTActSts;
            Z2139ACTActVida = A2139ACTActVida;
            Z2125ACTActFoto = A2125ACTActFoto;
            Z40000ACTActFoto_GXI = A40000ACTActFoto_GXI;
            Z2132ACTActOrd = A2132ACTActOrd;
            Z2124ACTActFIni = A2124ACTActFIni;
            Z2120ACTActCostoMO = A2120ACTActCostoMO;
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2102ACTAreaCod = A2102ACTAreaCod;
            Z2101ActUbiCod = A2101ActUbiCod;
            Z79COSCod = A79COSCod;
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

      protected void Load6Q184( )
      {
         /* Using cursor T006Q8 */
         pr_default.execute(6, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound184 = 1;
            A2118ACTActCodEQV = T006Q8_A2118ACTActCodEQV[0];
            AssignAttri("", false, "A2118ACTActCodEQV", A2118ACTActCodEQV);
            A2122ACTActDsc = T006Q8_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2131ACTActObs = T006Q8_A2131ACTActObs[0];
            AssignAttri("", false, "A2131ACTActObs", A2131ACTActObs);
            A2138ACTActTipCod = T006Q8_A2138ACTActTipCod[0];
            AssignAttri("", false, "A2138ACTActTipCod", A2138ACTActTipCod);
            A2121ACTActDocNum = T006Q8_A2121ACTActDocNum[0];
            AssignAttri("", false, "A2121ACTActDocNum", A2121ACTActDocNum);
            A2123ACTActFech = T006Q8_A2123ACTActFech[0];
            AssignAttri("", false, "A2123ACTActFech", context.localUtil.Format(A2123ACTActFech, "99/99/99"));
            A2134ACTActReg = T006Q8_A2134ACTActReg[0];
            AssignAttri("", false, "A2134ACTActReg", A2134ACTActReg);
            A2129ACTActModelo = T006Q8_A2129ACTActModelo[0];
            AssignAttri("", false, "A2129ACTActModelo", A2129ACTActModelo);
            A2135ACTActSerie = T006Q8_A2135ACTActSerie[0];
            AssignAttri("", false, "A2135ACTActSerie", A2135ACTActSerie);
            A2133ACTActParte = T006Q8_A2133ACTActParte[0];
            AssignAttri("", false, "A2133ACTActParte", A2133ACTActParte);
            A2117ACTActCap = T006Q8_A2117ACTActCap[0];
            AssignAttri("", false, "A2117ACTActCap", A2117ACTActCap);
            A2116ACTActAno = T006Q8_A2116ACTActAno[0];
            AssignAttri("", false, "A2116ACTActAno", A2116ACTActAno);
            A2128ACTActMarca = T006Q8_A2128ACTActMarca[0];
            AssignAttri("", false, "A2128ACTActMarca", A2128ACTActMarca);
            A2130ACTActMonCod = T006Q8_A2130ACTActMonCod[0];
            AssignAttri("", false, "A2130ACTActMonCod", StringUtil.LTrimStr( (decimal)(A2130ACTActMonCod), 6, 0));
            A2119ActActCostoMN = T006Q8_A2119ActActCostoMN[0];
            AssignAttri("", false, "A2119ActActCostoMN", StringUtil.LTrimStr( A2119ActActCostoMN, 15, 2));
            A2137ActActTipCmb = T006Q8_A2137ActActTipCmb[0];
            AssignAttri("", false, "A2137ActActTipCmb", StringUtil.LTrimStr( A2137ActActTipCmb, 15, 4));
            A2136ACTActSts = T006Q8_A2136ACTActSts[0];
            AssignAttri("", false, "A2136ACTActSts", A2136ACTActSts);
            A2139ACTActVida = T006Q8_A2139ACTActVida[0];
            AssignAttri("", false, "A2139ACTActVida", StringUtil.LTrimStr( A2139ACTActVida, 6, 2));
            A40000ACTActFoto_GXI = T006Q8_A40000ACTActFoto_GXI[0];
            AssignProp("", false, imgACTActFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.convertURL( context.PathToRelativeUrl( A2125ACTActFoto))), true);
            AssignProp("", false, imgACTActFoto_Internalname, "SrcSet", context.GetImageSrcSet( A2125ACTActFoto), true);
            A2132ACTActOrd = T006Q8_A2132ACTActOrd[0];
            AssignAttri("", false, "A2132ACTActOrd", A2132ACTActOrd);
            A2124ACTActFIni = T006Q8_A2124ACTActFIni[0];
            AssignAttri("", false, "A2124ACTActFIni", context.localUtil.Format(A2124ACTActFIni, "99/99/99"));
            A2120ACTActCostoMO = T006Q8_A2120ACTActCostoMO[0];
            AssignAttri("", false, "A2120ACTActCostoMO", StringUtil.LTrimStr( A2120ACTActCostoMO, 15, 2));
            A426ACTClaCod = T006Q8_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006Q8_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2102ACTAreaCod = T006Q8_A2102ACTAreaCod[0];
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            A2101ActUbiCod = T006Q8_A2101ActUbiCod[0];
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            A79COSCod = T006Q8_A79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A2125ACTActFoto = T006Q8_A2125ACTActFoto[0];
            AssignAttri("", false, "A2125ACTActFoto", A2125ACTActFoto);
            AssignProp("", false, imgACTActFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.convertURL( context.PathToRelativeUrl( A2125ACTActFoto))), true);
            AssignProp("", false, imgACTActFoto_Internalname, "SrcSet", context.GetImageSrcSet( A2125ACTActFoto), true);
            ZM6Q184( -3) ;
         }
         pr_default.close(6);
         OnLoadActions6Q184( ) ;
      }

      protected void OnLoadActions6Q184( )
      {
      }

      protected void CheckExtendedTable6Q184( )
      {
         nIsDirty_184 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T006Q4 */
         pr_default.execute(2, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A2123ACTActFech) || ( DateTimeUtil.ResetTime ( A2123ACTActFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Adquisión fuera de rango", "OutOfRange", 1, "ACTACTFECH");
            AnyError = 1;
            GX_FocusControl = edtACTActFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006Q5 */
         pr_default.execute(3, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Area Activo Fijo'.", "ForeignKeyNotFound", 1, "ACTAREACOD");
            AnyError = 1;
            GX_FocusControl = edtACTAreaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T006Q6 */
         pr_default.execute(4, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Ubicación Activos Fijos'.", "ForeignKeyNotFound", 1, "ACTUBICOD");
            AnyError = 1;
            GX_FocusControl = edtActUbiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T006Q7 */
         pr_default.execute(5, new Object[] {A79COSCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A2124ACTActFIni) || ( DateTimeUtil.ResetTime ( A2124ACTActFIni ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Inicio Dep. fuera de rango", "OutOfRange", 1, "ACTACTFINI");
            AnyError = 1;
            GX_FocusControl = edtACTActFIni_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6Q184( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A426ACTClaCod ,
                               string A2103ACTGrupCod )
      {
         /* Using cursor T006Q9 */
         pr_default.execute(7, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
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

      protected void gxLoad_5( string A2102ACTAreaCod )
      {
         /* Using cursor T006Q10 */
         pr_default.execute(8, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Area Activo Fijo'.", "ForeignKeyNotFound", 1, "ACTAREACOD");
            AnyError = 1;
            GX_FocusControl = edtACTAreaCod_Internalname;
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

      protected void gxLoad_6( string A2101ActUbiCod )
      {
         /* Using cursor T006Q11 */
         pr_default.execute(9, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Ubicación Activos Fijos'.", "ForeignKeyNotFound", 1, "ACTUBICOD");
            AnyError = 1;
            GX_FocusControl = edtActUbiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_7( string A79COSCod )
      {
         /* Using cursor T006Q12 */
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

      protected void GetKey6Q184( )
      {
         /* Using cursor T006Q13 */
         pr_default.execute(11, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound184 = 1;
         }
         else
         {
            RcdFound184 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006Q3 */
         pr_default.execute(1, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6Q184( 3) ;
            RcdFound184 = 1;
            A2100ACTActCod = T006Q3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2118ACTActCodEQV = T006Q3_A2118ACTActCodEQV[0];
            AssignAttri("", false, "A2118ACTActCodEQV", A2118ACTActCodEQV);
            A2122ACTActDsc = T006Q3_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2131ACTActObs = T006Q3_A2131ACTActObs[0];
            AssignAttri("", false, "A2131ACTActObs", A2131ACTActObs);
            A2138ACTActTipCod = T006Q3_A2138ACTActTipCod[0];
            AssignAttri("", false, "A2138ACTActTipCod", A2138ACTActTipCod);
            A2121ACTActDocNum = T006Q3_A2121ACTActDocNum[0];
            AssignAttri("", false, "A2121ACTActDocNum", A2121ACTActDocNum);
            A2123ACTActFech = T006Q3_A2123ACTActFech[0];
            AssignAttri("", false, "A2123ACTActFech", context.localUtil.Format(A2123ACTActFech, "99/99/99"));
            A2134ACTActReg = T006Q3_A2134ACTActReg[0];
            AssignAttri("", false, "A2134ACTActReg", A2134ACTActReg);
            A2129ACTActModelo = T006Q3_A2129ACTActModelo[0];
            AssignAttri("", false, "A2129ACTActModelo", A2129ACTActModelo);
            A2135ACTActSerie = T006Q3_A2135ACTActSerie[0];
            AssignAttri("", false, "A2135ACTActSerie", A2135ACTActSerie);
            A2133ACTActParte = T006Q3_A2133ACTActParte[0];
            AssignAttri("", false, "A2133ACTActParte", A2133ACTActParte);
            A2117ACTActCap = T006Q3_A2117ACTActCap[0];
            AssignAttri("", false, "A2117ACTActCap", A2117ACTActCap);
            A2116ACTActAno = T006Q3_A2116ACTActAno[0];
            AssignAttri("", false, "A2116ACTActAno", A2116ACTActAno);
            A2128ACTActMarca = T006Q3_A2128ACTActMarca[0];
            AssignAttri("", false, "A2128ACTActMarca", A2128ACTActMarca);
            A2130ACTActMonCod = T006Q3_A2130ACTActMonCod[0];
            AssignAttri("", false, "A2130ACTActMonCod", StringUtil.LTrimStr( (decimal)(A2130ACTActMonCod), 6, 0));
            A2119ActActCostoMN = T006Q3_A2119ActActCostoMN[0];
            AssignAttri("", false, "A2119ActActCostoMN", StringUtil.LTrimStr( A2119ActActCostoMN, 15, 2));
            A2137ActActTipCmb = T006Q3_A2137ActActTipCmb[0];
            AssignAttri("", false, "A2137ActActTipCmb", StringUtil.LTrimStr( A2137ActActTipCmb, 15, 4));
            A2136ACTActSts = T006Q3_A2136ACTActSts[0];
            AssignAttri("", false, "A2136ACTActSts", A2136ACTActSts);
            A2139ACTActVida = T006Q3_A2139ACTActVida[0];
            AssignAttri("", false, "A2139ACTActVida", StringUtil.LTrimStr( A2139ACTActVida, 6, 2));
            A40000ACTActFoto_GXI = T006Q3_A40000ACTActFoto_GXI[0];
            AssignProp("", false, imgACTActFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.convertURL( context.PathToRelativeUrl( A2125ACTActFoto))), true);
            AssignProp("", false, imgACTActFoto_Internalname, "SrcSet", context.GetImageSrcSet( A2125ACTActFoto), true);
            A2132ACTActOrd = T006Q3_A2132ACTActOrd[0];
            AssignAttri("", false, "A2132ACTActOrd", A2132ACTActOrd);
            A2124ACTActFIni = T006Q3_A2124ACTActFIni[0];
            AssignAttri("", false, "A2124ACTActFIni", context.localUtil.Format(A2124ACTActFIni, "99/99/99"));
            A2120ACTActCostoMO = T006Q3_A2120ACTActCostoMO[0];
            AssignAttri("", false, "A2120ACTActCostoMO", StringUtil.LTrimStr( A2120ACTActCostoMO, 15, 2));
            A426ACTClaCod = T006Q3_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006Q3_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2102ACTAreaCod = T006Q3_A2102ACTAreaCod[0];
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            A2101ActUbiCod = T006Q3_A2101ActUbiCod[0];
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            A79COSCod = T006Q3_A79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A2125ACTActFoto = T006Q3_A2125ACTActFoto[0];
            AssignAttri("", false, "A2125ACTActFoto", A2125ACTActFoto);
            AssignProp("", false, imgACTActFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.convertURL( context.PathToRelativeUrl( A2125ACTActFoto))), true);
            AssignProp("", false, imgACTActFoto_Internalname, "SrcSet", context.GetImageSrcSet( A2125ACTActFoto), true);
            Z2100ACTActCod = A2100ACTActCod;
            sMode184 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6Q184( ) ;
            if ( AnyError == 1 )
            {
               RcdFound184 = 0;
               InitializeNonKey6Q184( ) ;
            }
            Gx_mode = sMode184;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound184 = 0;
            InitializeNonKey6Q184( ) ;
            sMode184 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode184;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6Q184( ) ;
         if ( RcdFound184 == 0 )
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
         RcdFound184 = 0;
         /* Using cursor T006Q14 */
         pr_default.execute(12, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T006Q14_A2100ACTActCod[0], A2100ACTActCod) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T006Q14_A2100ACTActCod[0], A2100ACTActCod) > 0 ) ) )
            {
               A2100ACTActCod = T006Q14_A2100ACTActCod[0];
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               RcdFound184 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound184 = 0;
         /* Using cursor T006Q15 */
         pr_default.execute(13, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T006Q15_A2100ACTActCod[0], A2100ACTActCod) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T006Q15_A2100ACTActCod[0], A2100ACTActCod) < 0 ) ) )
            {
               A2100ACTActCod = T006Q15_A2100ACTActCod[0];
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               RcdFound184 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6Q184( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6Q184( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound184 == 1 )
            {
               if ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 )
               {
                  A2100ACTActCod = Z2100ACTActCod;
                  AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
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
                  Update6Q184( ) ;
                  GX_FocusControl = edtACTActCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTActCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6Q184( ) ;
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
                     Insert6Q184( ) ;
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
         if ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 )
         {
            A2100ACTActCod = Z2100ACTActCod;
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
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
         if ( RcdFound184 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTActCodEQV_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6Q184( ) ;
         if ( RcdFound184 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTActCodEQV_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6Q184( ) ;
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
         if ( RcdFound184 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTActCodEQV_Internalname;
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
         if ( RcdFound184 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTActCodEQV_Internalname;
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
         ScanStart6Q184( ) ;
         if ( RcdFound184 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound184 != 0 )
            {
               ScanNext6Q184( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTActCodEQV_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6Q184( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6Q184( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006Q2 */
            pr_default.execute(0, new Object[] {A2100ACTActCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTACTIVOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2118ACTActCodEQV, T006Q2_A2118ACTActCodEQV[0]) != 0 ) || ( StringUtil.StrCmp(Z2122ACTActDsc, T006Q2_A2122ACTActDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2138ACTActTipCod, T006Q2_A2138ACTActTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2121ACTActDocNum, T006Q2_A2121ACTActDocNum[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z2123ACTActFech ) != DateTimeUtil.ResetTime ( T006Q2_A2123ACTActFech[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2134ACTActReg, T006Q2_A2134ACTActReg[0]) != 0 ) || ( StringUtil.StrCmp(Z2129ACTActModelo, T006Q2_A2129ACTActModelo[0]) != 0 ) || ( StringUtil.StrCmp(Z2135ACTActSerie, T006Q2_A2135ACTActSerie[0]) != 0 ) || ( StringUtil.StrCmp(Z2133ACTActParte, T006Q2_A2133ACTActParte[0]) != 0 ) || ( StringUtil.StrCmp(Z2117ACTActCap, T006Q2_A2117ACTActCap[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2116ACTActAno, T006Q2_A2116ACTActAno[0]) != 0 ) || ( StringUtil.StrCmp(Z2128ACTActMarca, T006Q2_A2128ACTActMarca[0]) != 0 ) || ( Z2130ACTActMonCod != T006Q2_A2130ACTActMonCod[0] ) || ( Z2119ActActCostoMN != T006Q2_A2119ActActCostoMN[0] ) || ( Z2137ActActTipCmb != T006Q2_A2137ActActTipCmb[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2136ACTActSts, T006Q2_A2136ACTActSts[0]) != 0 ) || ( Z2139ACTActVida != T006Q2_A2139ACTActVida[0] ) || ( StringUtil.StrCmp(Z2132ACTActOrd, T006Q2_A2132ACTActOrd[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z2124ACTActFIni ) != DateTimeUtil.ResetTime ( T006Q2_A2124ACTActFIni[0] ) ) || ( Z2120ACTActCostoMO != T006Q2_A2120ACTActCostoMO[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z426ACTClaCod, T006Q2_A426ACTClaCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2103ACTGrupCod, T006Q2_A2103ACTGrupCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2102ACTAreaCod, T006Q2_A2102ACTAreaCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2101ActUbiCod, T006Q2_A2101ActUbiCod[0]) != 0 ) || ( StringUtil.StrCmp(Z79COSCod, T006Q2_A79COSCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2118ACTActCodEQV, T006Q2_A2118ACTActCodEQV[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActCodEQV");
                  GXUtil.WriteLogRaw("Old: ",Z2118ACTActCodEQV);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2118ACTActCodEQV[0]);
               }
               if ( StringUtil.StrCmp(Z2122ACTActDsc, T006Q2_A2122ACTActDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2122ACTActDsc);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2122ACTActDsc[0]);
               }
               if ( StringUtil.StrCmp(Z2138ACTActTipCod, T006Q2_A2138ACTActTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z2138ACTActTipCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2138ACTActTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z2121ACTActDocNum, T006Q2_A2121ACTActDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z2121ACTActDocNum);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2121ACTActDocNum[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2123ACTActFech ) != DateTimeUtil.ResetTime ( T006Q2_A2123ACTActFech[0] ) )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActFech");
                  GXUtil.WriteLogRaw("Old: ",Z2123ACTActFech);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2123ACTActFech[0]);
               }
               if ( StringUtil.StrCmp(Z2134ACTActReg, T006Q2_A2134ACTActReg[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActReg");
                  GXUtil.WriteLogRaw("Old: ",Z2134ACTActReg);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2134ACTActReg[0]);
               }
               if ( StringUtil.StrCmp(Z2129ACTActModelo, T006Q2_A2129ACTActModelo[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActModelo");
                  GXUtil.WriteLogRaw("Old: ",Z2129ACTActModelo);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2129ACTActModelo[0]);
               }
               if ( StringUtil.StrCmp(Z2135ACTActSerie, T006Q2_A2135ACTActSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActSerie");
                  GXUtil.WriteLogRaw("Old: ",Z2135ACTActSerie);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2135ACTActSerie[0]);
               }
               if ( StringUtil.StrCmp(Z2133ACTActParte, T006Q2_A2133ACTActParte[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActParte");
                  GXUtil.WriteLogRaw("Old: ",Z2133ACTActParte);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2133ACTActParte[0]);
               }
               if ( StringUtil.StrCmp(Z2117ACTActCap, T006Q2_A2117ACTActCap[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActCap");
                  GXUtil.WriteLogRaw("Old: ",Z2117ACTActCap);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2117ACTActCap[0]);
               }
               if ( StringUtil.StrCmp(Z2116ACTActAno, T006Q2_A2116ACTActAno[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActAno");
                  GXUtil.WriteLogRaw("Old: ",Z2116ACTActAno);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2116ACTActAno[0]);
               }
               if ( StringUtil.StrCmp(Z2128ACTActMarca, T006Q2_A2128ACTActMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActMarca");
                  GXUtil.WriteLogRaw("Old: ",Z2128ACTActMarca);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2128ACTActMarca[0]);
               }
               if ( Z2130ACTActMonCod != T006Q2_A2130ACTActMonCod[0] )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z2130ACTActMonCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2130ACTActMonCod[0]);
               }
               if ( Z2119ActActCostoMN != T006Q2_A2119ActActCostoMN[0] )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ActActCostoMN");
                  GXUtil.WriteLogRaw("Old: ",Z2119ActActCostoMN);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2119ActActCostoMN[0]);
               }
               if ( Z2137ActActTipCmb != T006Q2_A2137ActActTipCmb[0] )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ActActTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z2137ActActTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2137ActActTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z2136ACTActSts, T006Q2_A2136ACTActSts[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActSts");
                  GXUtil.WriteLogRaw("Old: ",Z2136ACTActSts);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2136ACTActSts[0]);
               }
               if ( Z2139ACTActVida != T006Q2_A2139ACTActVida[0] )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActVida");
                  GXUtil.WriteLogRaw("Old: ",Z2139ACTActVida);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2139ACTActVida[0]);
               }
               if ( StringUtil.StrCmp(Z2132ACTActOrd, T006Q2_A2132ACTActOrd[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActOrd");
                  GXUtil.WriteLogRaw("Old: ",Z2132ACTActOrd);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2132ACTActOrd[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2124ACTActFIni ) != DateTimeUtil.ResetTime ( T006Q2_A2124ACTActFIni[0] ) )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActFIni");
                  GXUtil.WriteLogRaw("Old: ",Z2124ACTActFIni);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2124ACTActFIni[0]);
               }
               if ( Z2120ACTActCostoMO != T006Q2_A2120ACTActCostoMO[0] )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTActCostoMO");
                  GXUtil.WriteLogRaw("Old: ",Z2120ACTActCostoMO);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2120ACTActCostoMO[0]);
               }
               if ( StringUtil.StrCmp(Z426ACTClaCod, T006Q2_A426ACTClaCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTClaCod");
                  GXUtil.WriteLogRaw("Old: ",Z426ACTClaCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A426ACTClaCod[0]);
               }
               if ( StringUtil.StrCmp(Z2103ACTGrupCod, T006Q2_A2103ACTGrupCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTGrupCod");
                  GXUtil.WriteLogRaw("Old: ",Z2103ACTGrupCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2103ACTGrupCod[0]);
               }
               if ( StringUtil.StrCmp(Z2102ACTAreaCod, T006Q2_A2102ACTAreaCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ACTAreaCod");
                  GXUtil.WriteLogRaw("Old: ",Z2102ACTAreaCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2102ACTAreaCod[0]);
               }
               if ( StringUtil.StrCmp(Z2101ActUbiCod, T006Q2_A2101ActUbiCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"ActUbiCod");
                  GXUtil.WriteLogRaw("Old: ",Z2101ActUbiCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A2101ActUbiCod[0]);
               }
               if ( StringUtil.StrCmp(Z79COSCod, T006Q2_A79COSCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actactivos:[seudo value changed for attri]"+"COSCod");
                  GXUtil.WriteLogRaw("Old: ",Z79COSCod);
                  GXUtil.WriteLogRaw("Current: ",T006Q2_A79COSCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTACTIVOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6Q184( )
      {
         BeforeValidate6Q184( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6Q184( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6Q184( 0) ;
            CheckOptimisticConcurrency6Q184( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6Q184( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6Q184( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006Q16 */
                     pr_default.execute(14, new Object[] {A2100ACTActCod, A2118ACTActCodEQV, A2122ACTActDsc, A2131ACTActObs, A2138ACTActTipCod, A2121ACTActDocNum, A2123ACTActFech, A2134ACTActReg, A2129ACTActModelo, A2135ACTActSerie, A2133ACTActParte, A2117ACTActCap, A2116ACTActAno, A2128ACTActMarca, A2130ACTActMonCod, A2119ActActCostoMN, A2137ActActTipCmb, A2136ACTActSts, A2139ACTActVida, A2125ACTActFoto, A40000ACTActFoto_GXI, A2132ACTActOrd, A2124ACTActFIni, A2120ACTActCostoMO, A426ACTClaCod, A2103ACTGrupCod, A2102ACTAreaCod, A2101ActUbiCod, A79COSCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOS");
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
                           ResetCaption6Q0( ) ;
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
               Load6Q184( ) ;
            }
            EndLevel6Q184( ) ;
         }
         CloseExtendedTableCursors6Q184( ) ;
      }

      protected void Update6Q184( )
      {
         BeforeValidate6Q184( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6Q184( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6Q184( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6Q184( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6Q184( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006Q17 */
                     pr_default.execute(15, new Object[] {A2118ACTActCodEQV, A2122ACTActDsc, A2131ACTActObs, A2138ACTActTipCod, A2121ACTActDocNum, A2123ACTActFech, A2134ACTActReg, A2129ACTActModelo, A2135ACTActSerie, A2133ACTActParte, A2117ACTActCap, A2116ACTActAno, A2128ACTActMarca, A2130ACTActMonCod, A2119ActActCostoMN, A2137ActActTipCmb, A2136ACTActSts, A2139ACTActVida, A2132ACTActOrd, A2124ACTActFIni, A2120ACTActCostoMO, A426ACTClaCod, A2103ACTGrupCod, A2102ACTAreaCod, A2101ActUbiCod, A79COSCod, A2100ACTActCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOS");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTACTIVOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6Q184( ) ;
                     if ( AnyError == 0 )
                     {
                        new actactivosupdateredundancy(context ).execute( ref  A2100ACTActCod) ;
                        AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6Q0( ) ;
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
            EndLevel6Q184( ) ;
         }
         CloseExtendedTableCursors6Q184( ) ;
      }

      protected void DeferredUpdate6Q184( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T006Q18 */
            pr_default.execute(16, new Object[] {A2125ACTActFoto, A40000ACTActFoto_GXI, A2100ACTActCod});
            pr_default.close(16);
            dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOS");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6Q184( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6Q184( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6Q184( ) ;
            AfterConfirm6Q184( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6Q184( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006Q19 */
                  pr_default.execute(17, new Object[] {A2100ACTActCod});
                  pr_default.close(17);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTACTIVOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound184 == 0 )
                        {
                           InitAll6Q184( ) ;
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
                        ResetCaption6Q0( ) ;
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
         sMode184 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6Q184( ) ;
         Gx_mode = sMode184;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6Q184( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006Q20 */
            pr_default.execute(18, new Object[] {A2100ACTActCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTACTIVOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel6Q184( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6Q184( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actactivos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actactivos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6Q184( )
      {
         /* Using cursor T006Q21 */
         pr_default.execute(19);
         RcdFound184 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound184 = 1;
            A2100ACTActCod = T006Q21_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6Q184( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound184 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound184 = 1;
            A2100ACTActCod = T006Q21_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         }
      }

      protected void ScanEnd6Q184( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm6Q184( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6Q184( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6Q184( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6Q184( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6Q184( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6Q184( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6Q184( )
      {
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtACTActCodEQV_Enabled = 0;
         AssignProp("", false, edtACTActCodEQV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCodEQV_Enabled), 5, 0), true);
         edtACTClaCod_Enabled = 0;
         AssignProp("", false, edtACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaCod_Enabled), 5, 0), true);
         edtACTGrupCod_Enabled = 0;
         AssignProp("", false, edtACTGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupCod_Enabled), 5, 0), true);
         edtACTActDsc_Enabled = 0;
         AssignProp("", false, edtACTActDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDsc_Enabled), 5, 0), true);
         edtACTActObs_Enabled = 0;
         AssignProp("", false, edtACTActObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActObs_Enabled), 5, 0), true);
         edtACTActTipCod_Enabled = 0;
         AssignProp("", false, edtACTActTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActTipCod_Enabled), 5, 0), true);
         edtACTActDocNum_Enabled = 0;
         AssignProp("", false, edtACTActDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDocNum_Enabled), 5, 0), true);
         edtACTActFech_Enabled = 0;
         AssignProp("", false, edtACTActFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActFech_Enabled), 5, 0), true);
         edtACTActReg_Enabled = 0;
         AssignProp("", false, edtACTActReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActReg_Enabled), 5, 0), true);
         edtACTActModelo_Enabled = 0;
         AssignProp("", false, edtACTActModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActModelo_Enabled), 5, 0), true);
         edtACTActSerie_Enabled = 0;
         AssignProp("", false, edtACTActSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActSerie_Enabled), 5, 0), true);
         edtACTActParte_Enabled = 0;
         AssignProp("", false, edtACTActParte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActParte_Enabled), 5, 0), true);
         edtACTActCap_Enabled = 0;
         AssignProp("", false, edtACTActCap_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCap_Enabled), 5, 0), true);
         edtACTActAno_Enabled = 0;
         AssignProp("", false, edtACTActAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActAno_Enabled), 5, 0), true);
         edtACTActMarca_Enabled = 0;
         AssignProp("", false, edtACTActMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActMarca_Enabled), 5, 0), true);
         edtACTActMonCod_Enabled = 0;
         AssignProp("", false, edtACTActMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActMonCod_Enabled), 5, 0), true);
         edtActActCostoMN_Enabled = 0;
         AssignProp("", false, edtActActCostoMN_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActCostoMN_Enabled), 5, 0), true);
         edtActActTipCmb_Enabled = 0;
         AssignProp("", false, edtActActTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActTipCmb_Enabled), 5, 0), true);
         edtACTActSts_Enabled = 0;
         AssignProp("", false, edtACTActSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActSts_Enabled), 5, 0), true);
         edtACTActVida_Enabled = 0;
         AssignProp("", false, edtACTActVida_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActVida_Enabled), 5, 0), true);
         imgACTActFoto_Enabled = 0;
         AssignProp("", false, imgACTActFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgACTActFoto_Enabled), 5, 0), true);
         edtACTAreaCod_Enabled = 0;
         AssignProp("", false, edtACTAreaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTAreaCod_Enabled), 5, 0), true);
         edtACTActOrd_Enabled = 0;
         AssignProp("", false, edtACTActOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActOrd_Enabled), 5, 0), true);
         edtActUbiCod_Enabled = 0;
         AssignProp("", false, edtActUbiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActUbiCod_Enabled), 5, 0), true);
         edtCOSCod_Enabled = 0;
         AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         edtACTActFIni_Enabled = 0;
         AssignProp("", false, edtACTActFIni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActFIni_Enabled), 5, 0), true);
         edtACTActCostoMO_Enabled = 0;
         AssignProp("", false, edtACTActCostoMO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCostoMO_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6Q184( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6Q0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "ACTACTIVOS") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810264483", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actactivos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2118ACTActCodEQV", Z2118ACTActCodEQV);
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         GxWebStd.gx_hidden_field( context, "Z2138ACTActTipCod", StringUtil.RTrim( Z2138ACTActTipCod));
         GxWebStd.gx_hidden_field( context, "Z2121ACTActDocNum", Z2121ACTActDocNum);
         GxWebStd.gx_hidden_field( context, "Z2123ACTActFech", context.localUtil.DToC( Z2123ACTActFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2134ACTActReg", StringUtil.RTrim( Z2134ACTActReg));
         GxWebStd.gx_hidden_field( context, "Z2129ACTActModelo", Z2129ACTActModelo);
         GxWebStd.gx_hidden_field( context, "Z2135ACTActSerie", Z2135ACTActSerie);
         GxWebStd.gx_hidden_field( context, "Z2133ACTActParte", Z2133ACTActParte);
         GxWebStd.gx_hidden_field( context, "Z2117ACTActCap", Z2117ACTActCap);
         GxWebStd.gx_hidden_field( context, "Z2116ACTActAno", Z2116ACTActAno);
         GxWebStd.gx_hidden_field( context, "Z2128ACTActMarca", Z2128ACTActMarca);
         GxWebStd.gx_hidden_field( context, "Z2130ACTActMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2130ACTActMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2119ActActCostoMN", StringUtil.LTrim( StringUtil.NToC( Z2119ActActCostoMN, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2137ActActTipCmb", StringUtil.LTrim( StringUtil.NToC( Z2137ActActTipCmb, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2136ACTActSts", Z2136ACTActSts);
         GxWebStd.gx_hidden_field( context, "Z2139ACTActVida", StringUtil.LTrim( StringUtil.NToC( Z2139ACTActVida, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2132ACTActOrd", Z2132ACTActOrd);
         GxWebStd.gx_hidden_field( context, "Z2124ACTActFIni", context.localUtil.DToC( Z2124ACTActFIni, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2120ACTActCostoMO", StringUtil.LTrim( StringUtil.NToC( Z2120ACTActCostoMO, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2102ACTAreaCod", Z2102ACTAreaCod);
         GxWebStd.gx_hidden_field( context, "Z2101ActUbiCod", Z2101ActUbiCod);
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "ACTACTFOTO_GXI", A40000ACTActFoto_GXI);
         GXCCtlgxBlob = "ACTACTFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A2125ACTActFoto);
      }

      protected void RenderHtmlCloseForm6Q184( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "ACTACTIVOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "ACTACTIVOS" ;
      }

      protected void InitializeNonKey6Q184( )
      {
         A2118ACTActCodEQV = "";
         AssignAttri("", false, "A2118ACTActCodEQV", A2118ACTActCodEQV);
         A426ACTClaCod = "";
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = "";
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         A2122ACTActDsc = "";
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A2131ACTActObs = "";
         AssignAttri("", false, "A2131ACTActObs", A2131ACTActObs);
         A2138ACTActTipCod = "";
         AssignAttri("", false, "A2138ACTActTipCod", A2138ACTActTipCod);
         A2121ACTActDocNum = "";
         AssignAttri("", false, "A2121ACTActDocNum", A2121ACTActDocNum);
         A2123ACTActFech = DateTime.MinValue;
         AssignAttri("", false, "A2123ACTActFech", context.localUtil.Format(A2123ACTActFech, "99/99/99"));
         A2134ACTActReg = "";
         AssignAttri("", false, "A2134ACTActReg", A2134ACTActReg);
         A2129ACTActModelo = "";
         AssignAttri("", false, "A2129ACTActModelo", A2129ACTActModelo);
         A2135ACTActSerie = "";
         AssignAttri("", false, "A2135ACTActSerie", A2135ACTActSerie);
         A2133ACTActParte = "";
         AssignAttri("", false, "A2133ACTActParte", A2133ACTActParte);
         A2117ACTActCap = "";
         AssignAttri("", false, "A2117ACTActCap", A2117ACTActCap);
         A2116ACTActAno = "";
         AssignAttri("", false, "A2116ACTActAno", A2116ACTActAno);
         A2128ACTActMarca = "";
         AssignAttri("", false, "A2128ACTActMarca", A2128ACTActMarca);
         A2130ACTActMonCod = 0;
         AssignAttri("", false, "A2130ACTActMonCod", StringUtil.LTrimStr( (decimal)(A2130ACTActMonCod), 6, 0));
         A2119ActActCostoMN = 0;
         AssignAttri("", false, "A2119ActActCostoMN", StringUtil.LTrimStr( A2119ActActCostoMN, 15, 2));
         A2137ActActTipCmb = 0;
         AssignAttri("", false, "A2137ActActTipCmb", StringUtil.LTrimStr( A2137ActActTipCmb, 15, 4));
         A2136ACTActSts = "";
         AssignAttri("", false, "A2136ACTActSts", A2136ACTActSts);
         A2139ACTActVida = 0;
         AssignAttri("", false, "A2139ACTActVida", StringUtil.LTrimStr( A2139ACTActVida, 6, 2));
         A2125ACTActFoto = "";
         AssignAttri("", false, "A2125ACTActFoto", A2125ACTActFoto);
         AssignProp("", false, imgACTActFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.convertURL( context.PathToRelativeUrl( A2125ACTActFoto))), true);
         AssignProp("", false, imgACTActFoto_Internalname, "SrcSet", context.GetImageSrcSet( A2125ACTActFoto), true);
         A40000ACTActFoto_GXI = "";
         AssignProp("", false, imgACTActFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A2125ACTActFoto)) ? A40000ACTActFoto_GXI : context.convertURL( context.PathToRelativeUrl( A2125ACTActFoto))), true);
         AssignProp("", false, imgACTActFoto_Internalname, "SrcSet", context.GetImageSrcSet( A2125ACTActFoto), true);
         A2102ACTAreaCod = "";
         AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
         A2132ACTActOrd = "";
         AssignAttri("", false, "A2132ACTActOrd", A2132ACTActOrd);
         A2101ActUbiCod = "";
         AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
         A79COSCod = "";
         AssignAttri("", false, "A79COSCod", A79COSCod);
         A2124ACTActFIni = DateTime.MinValue;
         AssignAttri("", false, "A2124ACTActFIni", context.localUtil.Format(A2124ACTActFIni, "99/99/99"));
         A2120ACTActCostoMO = 0;
         AssignAttri("", false, "A2120ACTActCostoMO", StringUtil.LTrimStr( A2120ACTActCostoMO, 15, 2));
         Z2118ACTActCodEQV = "";
         Z2122ACTActDsc = "";
         Z2138ACTActTipCod = "";
         Z2121ACTActDocNum = "";
         Z2123ACTActFech = DateTime.MinValue;
         Z2134ACTActReg = "";
         Z2129ACTActModelo = "";
         Z2135ACTActSerie = "";
         Z2133ACTActParte = "";
         Z2117ACTActCap = "";
         Z2116ACTActAno = "";
         Z2128ACTActMarca = "";
         Z2130ACTActMonCod = 0;
         Z2119ActActCostoMN = 0;
         Z2137ActActTipCmb = 0;
         Z2136ACTActSts = "";
         Z2139ACTActVida = 0;
         Z2132ACTActOrd = "";
         Z2124ACTActFIni = DateTime.MinValue;
         Z2120ACTActCostoMO = 0;
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2102ACTAreaCod = "";
         Z2101ActUbiCod = "";
         Z79COSCod = "";
      }

      protected void InitAll6Q184( )
      {
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         InitializeNonKey6Q184( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026457", true, true);
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
         context.AddJavascriptSource("actactivos.js", "?20228181026458", false, true);
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
         edtACTActCodEQV_Internalname = "ACTACTCODEQV";
         edtACTClaCod_Internalname = "ACTCLACOD";
         edtACTGrupCod_Internalname = "ACTGRUPCOD";
         edtACTActDsc_Internalname = "ACTACTDSC";
         edtACTActObs_Internalname = "ACTACTOBS";
         edtACTActTipCod_Internalname = "ACTACTTIPCOD";
         edtACTActDocNum_Internalname = "ACTACTDOCNUM";
         edtACTActFech_Internalname = "ACTACTFECH";
         edtACTActReg_Internalname = "ACTACTREG";
         edtACTActModelo_Internalname = "ACTACTMODELO";
         edtACTActSerie_Internalname = "ACTACTSERIE";
         edtACTActParte_Internalname = "ACTACTPARTE";
         edtACTActCap_Internalname = "ACTACTCAP";
         edtACTActAno_Internalname = "ACTACTANO";
         edtACTActMarca_Internalname = "ACTACTMARCA";
         edtACTActMonCod_Internalname = "ACTACTMONCOD";
         edtActActCostoMN_Internalname = "ACTACTCOSTOMN";
         edtActActTipCmb_Internalname = "ACTACTTIPCMB";
         edtACTActSts_Internalname = "ACTACTSTS";
         edtACTActVida_Internalname = "ACTACTVIDA";
         imgACTActFoto_Internalname = "ACTACTFOTO";
         edtACTAreaCod_Internalname = "ACTAREACOD";
         edtACTActOrd_Internalname = "ACTACTORD";
         edtActUbiCod_Internalname = "ACTUBICOD";
         edtCOSCod_Internalname = "COSCOD";
         edtACTActFIni_Internalname = "ACTACTFINI";
         edtACTActCostoMO_Internalname = "ACTACTCOSTOMO";
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
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtACTActCostoMO_Jsonclick = "";
         edtACTActCostoMO_Enabled = 1;
         edtACTActFIni_Jsonclick = "";
         edtACTActFIni_Enabled = 1;
         edtCOSCod_Jsonclick = "";
         edtCOSCod_Enabled = 1;
         edtActUbiCod_Jsonclick = "";
         edtActUbiCod_Enabled = 1;
         edtACTActOrd_Jsonclick = "";
         edtACTActOrd_Enabled = 1;
         edtACTAreaCod_Jsonclick = "";
         edtACTAreaCod_Enabled = 1;
         imgACTActFoto_Enabled = 1;
         edtACTActVida_Jsonclick = "";
         edtACTActVida_Enabled = 1;
         edtACTActSts_Jsonclick = "";
         edtACTActSts_Enabled = 1;
         edtActActTipCmb_Jsonclick = "";
         edtActActTipCmb_Enabled = 1;
         edtActActCostoMN_Jsonclick = "";
         edtActActCostoMN_Enabled = 1;
         edtACTActMonCod_Jsonclick = "";
         edtACTActMonCod_Enabled = 1;
         edtACTActMarca_Jsonclick = "";
         edtACTActMarca_Enabled = 1;
         edtACTActAno_Jsonclick = "";
         edtACTActAno_Enabled = 1;
         edtACTActCap_Jsonclick = "";
         edtACTActCap_Enabled = 1;
         edtACTActParte_Jsonclick = "";
         edtACTActParte_Enabled = 1;
         edtACTActSerie_Jsonclick = "";
         edtACTActSerie_Enabled = 1;
         edtACTActModelo_Jsonclick = "";
         edtACTActModelo_Enabled = 1;
         edtACTActReg_Jsonclick = "";
         edtACTActReg_Enabled = 1;
         edtACTActFech_Jsonclick = "";
         edtACTActFech_Enabled = 1;
         edtACTActDocNum_Jsonclick = "";
         edtACTActDocNum_Enabled = 1;
         edtACTActTipCod_Jsonclick = "";
         edtACTActTipCod_Enabled = 1;
         edtACTActObs_Enabled = 1;
         edtACTActDsc_Jsonclick = "";
         edtACTActDsc_Enabled = 1;
         edtACTGrupCod_Jsonclick = "";
         edtACTGrupCod_Enabled = 1;
         edtACTClaCod_Jsonclick = "";
         edtACTClaCod_Enabled = 1;
         edtACTActCodEQV_Jsonclick = "";
         edtACTActCodEQV_Enabled = 1;
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
         GX_FocusControl = edtACTActCodEQV_Internalname;
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
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2118ACTActCodEQV", A2118ACTActCodEQV);
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "A2131ACTActObs", A2131ACTActObs);
         AssignAttri("", false, "A2138ACTActTipCod", StringUtil.RTrim( A2138ACTActTipCod));
         AssignAttri("", false, "A2121ACTActDocNum", A2121ACTActDocNum);
         AssignAttri("", false, "A2123ACTActFech", context.localUtil.Format(A2123ACTActFech, "99/99/99"));
         AssignAttri("", false, "A2134ACTActReg", StringUtil.RTrim( A2134ACTActReg));
         AssignAttri("", false, "A2129ACTActModelo", A2129ACTActModelo);
         AssignAttri("", false, "A2135ACTActSerie", A2135ACTActSerie);
         AssignAttri("", false, "A2133ACTActParte", A2133ACTActParte);
         AssignAttri("", false, "A2117ACTActCap", A2117ACTActCap);
         AssignAttri("", false, "A2116ACTActAno", A2116ACTActAno);
         AssignAttri("", false, "A2128ACTActMarca", A2128ACTActMarca);
         AssignAttri("", false, "A2130ACTActMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2130ACTActMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2119ActActCostoMN", StringUtil.LTrim( StringUtil.NToC( A2119ActActCostoMN, 15, 2, ".", "")));
         AssignAttri("", false, "A2137ActActTipCmb", StringUtil.LTrim( StringUtil.NToC( A2137ActActTipCmb, 15, 4, ".", "")));
         AssignAttri("", false, "A2136ACTActSts", A2136ACTActSts);
         AssignAttri("", false, "A2139ACTActVida", StringUtil.LTrim( StringUtil.NToC( A2139ACTActVida, 6, 2, ".", "")));
         AssignAttri("", false, "A2125ACTActFoto", context.PathToRelativeUrl( A2125ACTActFoto));
         GXCCtlgxBlob = "ACTACTFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A2125ACTActFoto));
         AssignAttri("", false, "A40000ACTActFoto_GXI", A40000ACTActFoto_GXI);
         AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
         AssignAttri("", false, "A2132ACTActOrd", A2132ACTActOrd);
         AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
         AssignAttri("", false, "A79COSCod", StringUtil.RTrim( A79COSCod));
         AssignAttri("", false, "A2124ACTActFIni", context.localUtil.Format(A2124ACTActFIni, "99/99/99"));
         AssignAttri("", false, "A2120ACTActCostoMO", StringUtil.LTrim( StringUtil.NToC( A2120ACTActCostoMO, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2118ACTActCodEQV", Z2118ACTActCodEQV);
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         GxWebStd.gx_hidden_field( context, "Z2131ACTActObs", Z2131ACTActObs);
         GxWebStd.gx_hidden_field( context, "Z2138ACTActTipCod", StringUtil.RTrim( Z2138ACTActTipCod));
         GxWebStd.gx_hidden_field( context, "Z2121ACTActDocNum", Z2121ACTActDocNum);
         GxWebStd.gx_hidden_field( context, "Z2123ACTActFech", context.localUtil.Format(Z2123ACTActFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2134ACTActReg", StringUtil.RTrim( Z2134ACTActReg));
         GxWebStd.gx_hidden_field( context, "Z2129ACTActModelo", Z2129ACTActModelo);
         GxWebStd.gx_hidden_field( context, "Z2135ACTActSerie", Z2135ACTActSerie);
         GxWebStd.gx_hidden_field( context, "Z2133ACTActParte", Z2133ACTActParte);
         GxWebStd.gx_hidden_field( context, "Z2117ACTActCap", Z2117ACTActCap);
         GxWebStd.gx_hidden_field( context, "Z2116ACTActAno", Z2116ACTActAno);
         GxWebStd.gx_hidden_field( context, "Z2128ACTActMarca", Z2128ACTActMarca);
         GxWebStd.gx_hidden_field( context, "Z2130ACTActMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2130ACTActMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2119ActActCostoMN", StringUtil.LTrim( StringUtil.NToC( Z2119ActActCostoMN, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2137ActActTipCmb", StringUtil.LTrim( StringUtil.NToC( Z2137ActActTipCmb, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2136ACTActSts", Z2136ACTActSts);
         GxWebStd.gx_hidden_field( context, "Z2139ACTActVida", StringUtil.LTrim( StringUtil.NToC( Z2139ACTActVida, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2125ACTActFoto", context.PathToRelativeUrl( Z2125ACTActFoto));
         GxWebStd.gx_hidden_field( context, "Z40000ACTActFoto_GXI", Z40000ACTActFoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z2102ACTAreaCod", Z2102ACTAreaCod);
         GxWebStd.gx_hidden_field( context, "Z2132ACTActOrd", Z2132ACTActOrd);
         GxWebStd.gx_hidden_field( context, "Z2101ActUbiCod", Z2101ActUbiCod);
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z2124ACTActFIni", context.localUtil.Format(Z2124ACTActFIni, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2120ACTActCostoMO", StringUtil.LTrim( StringUtil.NToC( Z2120ACTActCostoMO, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actgrupcod( )
      {
         /* Using cursor T006Q22 */
         pr_default.execute(20, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Actareacod( )
      {
         /* Using cursor T006Q23 */
         pr_default.execute(21, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Area Activo Fijo'.", "ForeignKeyNotFound", 1, "ACTAREACOD");
            AnyError = 1;
            GX_FocusControl = edtACTAreaCod_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Actubicod( )
      {
         /* Using cursor T006Q24 */
         pr_default.execute(22, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Ubicación Activos Fijos'.", "ForeignKeyNotFound", 1, "ACTUBICOD");
            AnyError = 1;
            GX_FocusControl = edtActUbiCod_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Coscod( )
      {
         /* Using cursor T006Q25 */
         pr_default.execute(23, new Object[] {A79COSCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
         }
         pr_default.close(23);
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
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[{av:'A2118ACTActCodEQV',fld:'ACTACTCODEQV',pic:''},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'A2131ACTActObs',fld:'ACTACTOBS',pic:''},{av:'A2138ACTActTipCod',fld:'ACTACTTIPCOD',pic:''},{av:'A2121ACTActDocNum',fld:'ACTACTDOCNUM',pic:''},{av:'A2123ACTActFech',fld:'ACTACTFECH',pic:''},{av:'A2134ACTActReg',fld:'ACTACTREG',pic:''},{av:'A2129ACTActModelo',fld:'ACTACTMODELO',pic:''},{av:'A2135ACTActSerie',fld:'ACTACTSERIE',pic:''},{av:'A2133ACTActParte',fld:'ACTACTPARTE',pic:''},{av:'A2117ACTActCap',fld:'ACTACTCAP',pic:''},{av:'A2116ACTActAno',fld:'ACTACTANO',pic:''},{av:'A2128ACTActMarca',fld:'ACTACTMARCA',pic:''},{av:'A2130ACTActMonCod',fld:'ACTACTMONCOD',pic:'ZZZZZ9'},{av:'A2119ActActCostoMN',fld:'ACTACTCOSTOMN',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2137ActActTipCmb',fld:'ACTACTTIPCMB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2136ACTActSts',fld:'ACTACTSTS',pic:''},{av:'A2139ACTActVida',fld:'ACTACTVIDA',pic:'ZZ9.99'},{av:'A2125ACTActFoto',fld:'ACTACTFOTO',pic:''},{av:'A40000ACTActFoto_GXI',fld:'ACTACTFOTO_GXI',pic:''},{av:'A2102ACTAreaCod',fld:'ACTAREACOD',pic:''},{av:'A2132ACTActOrd',fld:'ACTACTORD',pic:''},{av:'A2101ActUbiCod',fld:'ACTUBICOD',pic:''},{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A2124ACTActFIni',fld:'ACTACTFINI',pic:''},{av:'A2120ACTActCostoMO',fld:'ACTACTCOSTOMO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2100ACTActCod'},{av:'Z2118ACTActCodEQV'},{av:'Z426ACTClaCod'},{av:'Z2103ACTGrupCod'},{av:'Z2122ACTActDsc'},{av:'Z2131ACTActObs'},{av:'Z2138ACTActTipCod'},{av:'Z2121ACTActDocNum'},{av:'Z2123ACTActFech'},{av:'Z2134ACTActReg'},{av:'Z2129ACTActModelo'},{av:'Z2135ACTActSerie'},{av:'Z2133ACTActParte'},{av:'Z2117ACTActCap'},{av:'Z2116ACTActAno'},{av:'Z2128ACTActMarca'},{av:'Z2130ACTActMonCod'},{av:'Z2119ActActCostoMN'},{av:'Z2137ActActTipCmb'},{av:'Z2136ACTActSts'},{av:'Z2139ACTActVida'},{av:'Z2125ACTActFoto'},{av:'Z40000ACTActFoto_GXI'},{av:'Z2102ACTAreaCod'},{av:'Z2132ACTActOrd'},{av:'Z2101ActUbiCod'},{av:'Z79COSCod'},{av:'Z2124ACTActFIni'},{av:'Z2120ACTActCostoMO'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[]}");
         setEventMetadata("VALID_ACTGRUPCOD","{handler:'Valid_Actgrupcod',iparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTGRUPCOD",",oparms:[]}");
         setEventMetadata("VALID_ACTACTFECH","{handler:'Valid_Actactfech',iparms:[]");
         setEventMetadata("VALID_ACTACTFECH",",oparms:[]}");
         setEventMetadata("VALID_ACTAREACOD","{handler:'Valid_Actareacod',iparms:[{av:'A2102ACTAreaCod',fld:'ACTAREACOD',pic:''}]");
         setEventMetadata("VALID_ACTAREACOD",",oparms:[]}");
         setEventMetadata("VALID_ACTUBICOD","{handler:'Valid_Actubicod',iparms:[{av:'A2101ActUbiCod',fld:'ACTUBICOD',pic:''}]");
         setEventMetadata("VALID_ACTUBICOD",",oparms:[]}");
         setEventMetadata("VALID_COSCOD","{handler:'Valid_Coscod',iparms:[{av:'A79COSCod',fld:'COSCOD',pic:''}]");
         setEventMetadata("VALID_COSCOD",",oparms:[]}");
         setEventMetadata("VALID_ACTACTFINI","{handler:'Valid_Actactfini',iparms:[]");
         setEventMetadata("VALID_ACTACTFINI",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2100ACTActCod = "";
         Z2118ACTActCodEQV = "";
         Z2122ACTActDsc = "";
         Z2138ACTActTipCod = "";
         Z2121ACTActDocNum = "";
         Z2123ACTActFech = DateTime.MinValue;
         Z2134ACTActReg = "";
         Z2129ACTActModelo = "";
         Z2135ACTActSerie = "";
         Z2133ACTActParte = "";
         Z2117ACTActCap = "";
         Z2116ACTActAno = "";
         Z2128ACTActMarca = "";
         Z2136ACTActSts = "";
         Z2132ACTActOrd = "";
         Z2124ACTActFIni = DateTime.MinValue;
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2102ACTAreaCod = "";
         Z2101ActUbiCod = "";
         Z79COSCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2102ACTAreaCod = "";
         A2101ActUbiCod = "";
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
         A2100ACTActCod = "";
         A2118ACTActCodEQV = "";
         A2122ACTActDsc = "";
         A2131ACTActObs = "";
         A2138ACTActTipCod = "";
         A2121ACTActDocNum = "";
         A2123ACTActFech = DateTime.MinValue;
         A2134ACTActReg = "";
         A2129ACTActModelo = "";
         A2135ACTActSerie = "";
         A2133ACTActParte = "";
         A2117ACTActCap = "";
         A2116ACTActAno = "";
         A2128ACTActMarca = "";
         A2136ACTActSts = "";
         A2125ACTActFoto = "";
         A40000ACTActFoto_GXI = "";
         sImgUrl = "";
         A2132ACTActOrd = "";
         A2124ACTActFIni = DateTime.MinValue;
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
         Z2131ACTActObs = "";
         Z2125ACTActFoto = "";
         Z40000ACTActFoto_GXI = "";
         T006Q8_A2100ACTActCod = new string[] {""} ;
         T006Q8_A2118ACTActCodEQV = new string[] {""} ;
         T006Q8_A2122ACTActDsc = new string[] {""} ;
         T006Q8_A2131ACTActObs = new string[] {""} ;
         T006Q8_A2138ACTActTipCod = new string[] {""} ;
         T006Q8_A2121ACTActDocNum = new string[] {""} ;
         T006Q8_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         T006Q8_A2134ACTActReg = new string[] {""} ;
         T006Q8_A2129ACTActModelo = new string[] {""} ;
         T006Q8_A2135ACTActSerie = new string[] {""} ;
         T006Q8_A2133ACTActParte = new string[] {""} ;
         T006Q8_A2117ACTActCap = new string[] {""} ;
         T006Q8_A2116ACTActAno = new string[] {""} ;
         T006Q8_A2128ACTActMarca = new string[] {""} ;
         T006Q8_A2130ACTActMonCod = new int[1] ;
         T006Q8_A2119ActActCostoMN = new decimal[1] ;
         T006Q8_A2137ActActTipCmb = new decimal[1] ;
         T006Q8_A2136ACTActSts = new string[] {""} ;
         T006Q8_A2139ACTActVida = new decimal[1] ;
         T006Q8_A40000ACTActFoto_GXI = new string[] {""} ;
         T006Q8_A2132ACTActOrd = new string[] {""} ;
         T006Q8_A2124ACTActFIni = new DateTime[] {DateTime.MinValue} ;
         T006Q8_A2120ACTActCostoMO = new decimal[1] ;
         T006Q8_A426ACTClaCod = new string[] {""} ;
         T006Q8_A2103ACTGrupCod = new string[] {""} ;
         T006Q8_A2102ACTAreaCod = new string[] {""} ;
         T006Q8_A2101ActUbiCod = new string[] {""} ;
         T006Q8_A79COSCod = new string[] {""} ;
         T006Q8_A2125ACTActFoto = new string[] {""} ;
         T006Q4_A426ACTClaCod = new string[] {""} ;
         T006Q5_A2102ACTAreaCod = new string[] {""} ;
         T006Q6_A2101ActUbiCod = new string[] {""} ;
         T006Q7_A79COSCod = new string[] {""} ;
         T006Q9_A426ACTClaCod = new string[] {""} ;
         T006Q10_A2102ACTAreaCod = new string[] {""} ;
         T006Q11_A2101ActUbiCod = new string[] {""} ;
         T006Q12_A79COSCod = new string[] {""} ;
         T006Q13_A2100ACTActCod = new string[] {""} ;
         T006Q3_A2100ACTActCod = new string[] {""} ;
         T006Q3_A2118ACTActCodEQV = new string[] {""} ;
         T006Q3_A2122ACTActDsc = new string[] {""} ;
         T006Q3_A2131ACTActObs = new string[] {""} ;
         T006Q3_A2138ACTActTipCod = new string[] {""} ;
         T006Q3_A2121ACTActDocNum = new string[] {""} ;
         T006Q3_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         T006Q3_A2134ACTActReg = new string[] {""} ;
         T006Q3_A2129ACTActModelo = new string[] {""} ;
         T006Q3_A2135ACTActSerie = new string[] {""} ;
         T006Q3_A2133ACTActParte = new string[] {""} ;
         T006Q3_A2117ACTActCap = new string[] {""} ;
         T006Q3_A2116ACTActAno = new string[] {""} ;
         T006Q3_A2128ACTActMarca = new string[] {""} ;
         T006Q3_A2130ACTActMonCod = new int[1] ;
         T006Q3_A2119ActActCostoMN = new decimal[1] ;
         T006Q3_A2137ActActTipCmb = new decimal[1] ;
         T006Q3_A2136ACTActSts = new string[] {""} ;
         T006Q3_A2139ACTActVida = new decimal[1] ;
         T006Q3_A40000ACTActFoto_GXI = new string[] {""} ;
         T006Q3_A2132ACTActOrd = new string[] {""} ;
         T006Q3_A2124ACTActFIni = new DateTime[] {DateTime.MinValue} ;
         T006Q3_A2120ACTActCostoMO = new decimal[1] ;
         T006Q3_A426ACTClaCod = new string[] {""} ;
         T006Q3_A2103ACTGrupCod = new string[] {""} ;
         T006Q3_A2102ACTAreaCod = new string[] {""} ;
         T006Q3_A2101ActUbiCod = new string[] {""} ;
         T006Q3_A79COSCod = new string[] {""} ;
         T006Q3_A2125ACTActFoto = new string[] {""} ;
         sMode184 = "";
         T006Q14_A2100ACTActCod = new string[] {""} ;
         T006Q15_A2100ACTActCod = new string[] {""} ;
         T006Q2_A2100ACTActCod = new string[] {""} ;
         T006Q2_A2118ACTActCodEQV = new string[] {""} ;
         T006Q2_A2122ACTActDsc = new string[] {""} ;
         T006Q2_A2131ACTActObs = new string[] {""} ;
         T006Q2_A2138ACTActTipCod = new string[] {""} ;
         T006Q2_A2121ACTActDocNum = new string[] {""} ;
         T006Q2_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         T006Q2_A2134ACTActReg = new string[] {""} ;
         T006Q2_A2129ACTActModelo = new string[] {""} ;
         T006Q2_A2135ACTActSerie = new string[] {""} ;
         T006Q2_A2133ACTActParte = new string[] {""} ;
         T006Q2_A2117ACTActCap = new string[] {""} ;
         T006Q2_A2116ACTActAno = new string[] {""} ;
         T006Q2_A2128ACTActMarca = new string[] {""} ;
         T006Q2_A2130ACTActMonCod = new int[1] ;
         T006Q2_A2119ActActCostoMN = new decimal[1] ;
         T006Q2_A2137ActActTipCmb = new decimal[1] ;
         T006Q2_A2136ACTActSts = new string[] {""} ;
         T006Q2_A2139ACTActVida = new decimal[1] ;
         T006Q2_A40000ACTActFoto_GXI = new string[] {""} ;
         T006Q2_A2132ACTActOrd = new string[] {""} ;
         T006Q2_A2124ACTActFIni = new DateTime[] {DateTime.MinValue} ;
         T006Q2_A2120ACTActCostoMO = new decimal[1] ;
         T006Q2_A426ACTClaCod = new string[] {""} ;
         T006Q2_A2103ACTGrupCod = new string[] {""} ;
         T006Q2_A2102ACTAreaCod = new string[] {""} ;
         T006Q2_A2101ActUbiCod = new string[] {""} ;
         T006Q2_A79COSCod = new string[] {""} ;
         T006Q2_A2125ACTActFoto = new string[] {""} ;
         T006Q20_A2100ACTActCod = new string[] {""} ;
         T006Q20_A2104ActActItem = new string[] {""} ;
         T006Q21_A2100ACTActCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ2100ACTActCod = "";
         ZZ2118ACTActCodEQV = "";
         ZZ426ACTClaCod = "";
         ZZ2103ACTGrupCod = "";
         ZZ2122ACTActDsc = "";
         ZZ2131ACTActObs = "";
         ZZ2138ACTActTipCod = "";
         ZZ2121ACTActDocNum = "";
         ZZ2123ACTActFech = DateTime.MinValue;
         ZZ2134ACTActReg = "";
         ZZ2129ACTActModelo = "";
         ZZ2135ACTActSerie = "";
         ZZ2133ACTActParte = "";
         ZZ2117ACTActCap = "";
         ZZ2116ACTActAno = "";
         ZZ2128ACTActMarca = "";
         ZZ2136ACTActSts = "";
         ZZ2125ACTActFoto = "";
         ZZ40000ACTActFoto_GXI = "";
         ZZ2102ACTAreaCod = "";
         ZZ2132ACTActOrd = "";
         ZZ2101ActUbiCod = "";
         ZZ79COSCod = "";
         ZZ2124ACTActFIni = DateTime.MinValue;
         T006Q22_A426ACTClaCod = new string[] {""} ;
         T006Q23_A2102ACTAreaCod = new string[] {""} ;
         T006Q24_A2101ActUbiCod = new string[] {""} ;
         T006Q25_A79COSCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actactivos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actactivos__default(),
            new Object[][] {
                new Object[] {
               T006Q2_A2100ACTActCod, T006Q2_A2118ACTActCodEQV, T006Q2_A2122ACTActDsc, T006Q2_A2131ACTActObs, T006Q2_A2138ACTActTipCod, T006Q2_A2121ACTActDocNum, T006Q2_A2123ACTActFech, T006Q2_A2134ACTActReg, T006Q2_A2129ACTActModelo, T006Q2_A2135ACTActSerie,
               T006Q2_A2133ACTActParte, T006Q2_A2117ACTActCap, T006Q2_A2116ACTActAno, T006Q2_A2128ACTActMarca, T006Q2_A2130ACTActMonCod, T006Q2_A2119ActActCostoMN, T006Q2_A2137ActActTipCmb, T006Q2_A2136ACTActSts, T006Q2_A2139ACTActVida, T006Q2_A40000ACTActFoto_GXI,
               T006Q2_A2132ACTActOrd, T006Q2_A2124ACTActFIni, T006Q2_A2120ACTActCostoMO, T006Q2_A426ACTClaCod, T006Q2_A2103ACTGrupCod, T006Q2_A2102ACTAreaCod, T006Q2_A2101ActUbiCod, T006Q2_A79COSCod, T006Q2_A2125ACTActFoto
               }
               , new Object[] {
               T006Q3_A2100ACTActCod, T006Q3_A2118ACTActCodEQV, T006Q3_A2122ACTActDsc, T006Q3_A2131ACTActObs, T006Q3_A2138ACTActTipCod, T006Q3_A2121ACTActDocNum, T006Q3_A2123ACTActFech, T006Q3_A2134ACTActReg, T006Q3_A2129ACTActModelo, T006Q3_A2135ACTActSerie,
               T006Q3_A2133ACTActParte, T006Q3_A2117ACTActCap, T006Q3_A2116ACTActAno, T006Q3_A2128ACTActMarca, T006Q3_A2130ACTActMonCod, T006Q3_A2119ActActCostoMN, T006Q3_A2137ActActTipCmb, T006Q3_A2136ACTActSts, T006Q3_A2139ACTActVida, T006Q3_A40000ACTActFoto_GXI,
               T006Q3_A2132ACTActOrd, T006Q3_A2124ACTActFIni, T006Q3_A2120ACTActCostoMO, T006Q3_A426ACTClaCod, T006Q3_A2103ACTGrupCod, T006Q3_A2102ACTAreaCod, T006Q3_A2101ActUbiCod, T006Q3_A79COSCod, T006Q3_A2125ACTActFoto
               }
               , new Object[] {
               T006Q4_A426ACTClaCod
               }
               , new Object[] {
               T006Q5_A2102ACTAreaCod
               }
               , new Object[] {
               T006Q6_A2101ActUbiCod
               }
               , new Object[] {
               T006Q7_A79COSCod
               }
               , new Object[] {
               T006Q8_A2100ACTActCod, T006Q8_A2118ACTActCodEQV, T006Q8_A2122ACTActDsc, T006Q8_A2131ACTActObs, T006Q8_A2138ACTActTipCod, T006Q8_A2121ACTActDocNum, T006Q8_A2123ACTActFech, T006Q8_A2134ACTActReg, T006Q8_A2129ACTActModelo, T006Q8_A2135ACTActSerie,
               T006Q8_A2133ACTActParte, T006Q8_A2117ACTActCap, T006Q8_A2116ACTActAno, T006Q8_A2128ACTActMarca, T006Q8_A2130ACTActMonCod, T006Q8_A2119ActActCostoMN, T006Q8_A2137ActActTipCmb, T006Q8_A2136ACTActSts, T006Q8_A2139ACTActVida, T006Q8_A40000ACTActFoto_GXI,
               T006Q8_A2132ACTActOrd, T006Q8_A2124ACTActFIni, T006Q8_A2120ACTActCostoMO, T006Q8_A426ACTClaCod, T006Q8_A2103ACTGrupCod, T006Q8_A2102ACTAreaCod, T006Q8_A2101ActUbiCod, T006Q8_A79COSCod, T006Q8_A2125ACTActFoto
               }
               , new Object[] {
               T006Q9_A426ACTClaCod
               }
               , new Object[] {
               T006Q10_A2102ACTAreaCod
               }
               , new Object[] {
               T006Q11_A2101ActUbiCod
               }
               , new Object[] {
               T006Q12_A79COSCod
               }
               , new Object[] {
               T006Q13_A2100ACTActCod
               }
               , new Object[] {
               T006Q14_A2100ACTActCod
               }
               , new Object[] {
               T006Q15_A2100ACTActCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006Q20_A2100ACTActCod, T006Q20_A2104ActActItem
               }
               , new Object[] {
               T006Q21_A2100ACTActCod
               }
               , new Object[] {
               T006Q22_A426ACTClaCod
               }
               , new Object[] {
               T006Q23_A2102ACTAreaCod
               }
               , new Object[] {
               T006Q24_A2101ActUbiCod
               }
               , new Object[] {
               T006Q25_A79COSCod
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
      private short nDynComponent ;
      private short GX_JID ;
      private short RcdFound184 ;
      private short nIsDirty_184 ;
      private short Gx_BScreen ;
      private int Z2130ACTActMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTActCod_Enabled ;
      private int edtACTActCodEQV_Enabled ;
      private int edtACTClaCod_Enabled ;
      private int edtACTGrupCod_Enabled ;
      private int edtACTActDsc_Enabled ;
      private int edtACTActObs_Enabled ;
      private int edtACTActTipCod_Enabled ;
      private int edtACTActDocNum_Enabled ;
      private int edtACTActFech_Enabled ;
      private int edtACTActReg_Enabled ;
      private int edtACTActModelo_Enabled ;
      private int edtACTActSerie_Enabled ;
      private int edtACTActParte_Enabled ;
      private int edtACTActCap_Enabled ;
      private int edtACTActAno_Enabled ;
      private int edtACTActMarca_Enabled ;
      private int A2130ACTActMonCod ;
      private int edtACTActMonCod_Enabled ;
      private int edtActActCostoMN_Enabled ;
      private int edtActActTipCmb_Enabled ;
      private int edtACTActSts_Enabled ;
      private int edtACTActVida_Enabled ;
      private int imgACTActFoto_Enabled ;
      private int edtACTAreaCod_Enabled ;
      private int edtACTActOrd_Enabled ;
      private int edtActUbiCod_Enabled ;
      private int edtCOSCod_Enabled ;
      private int edtACTActFIni_Enabled ;
      private int edtACTActCostoMO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2130ACTActMonCod ;
      private decimal Z2119ActActCostoMN ;
      private decimal Z2137ActActTipCmb ;
      private decimal Z2139ACTActVida ;
      private decimal Z2120ACTActCostoMO ;
      private decimal A2119ActActCostoMN ;
      private decimal A2137ActActTipCmb ;
      private decimal A2139ACTActVida ;
      private decimal A2120ACTActCostoMO ;
      private decimal ZZ2119ActActCostoMN ;
      private decimal ZZ2137ActActTipCmb ;
      private decimal ZZ2139ACTActVida ;
      private decimal ZZ2120ACTActCostoMO ;
      private string sPrefix ;
      private string Z2138ACTActTipCod ;
      private string Z2134ACTActReg ;
      private string Z79COSCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A79COSCod ;
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
      private string edtACTActCodEQV_Internalname ;
      private string edtACTActCodEQV_Jsonclick ;
      private string edtACTClaCod_Internalname ;
      private string edtACTClaCod_Jsonclick ;
      private string edtACTGrupCod_Internalname ;
      private string edtACTGrupCod_Jsonclick ;
      private string edtACTActDsc_Internalname ;
      private string edtACTActDsc_Jsonclick ;
      private string edtACTActObs_Internalname ;
      private string edtACTActTipCod_Internalname ;
      private string A2138ACTActTipCod ;
      private string edtACTActTipCod_Jsonclick ;
      private string edtACTActDocNum_Internalname ;
      private string edtACTActDocNum_Jsonclick ;
      private string edtACTActFech_Internalname ;
      private string edtACTActFech_Jsonclick ;
      private string edtACTActReg_Internalname ;
      private string A2134ACTActReg ;
      private string edtACTActReg_Jsonclick ;
      private string edtACTActModelo_Internalname ;
      private string edtACTActModelo_Jsonclick ;
      private string edtACTActSerie_Internalname ;
      private string edtACTActSerie_Jsonclick ;
      private string edtACTActParte_Internalname ;
      private string edtACTActParte_Jsonclick ;
      private string edtACTActCap_Internalname ;
      private string edtACTActCap_Jsonclick ;
      private string edtACTActAno_Internalname ;
      private string edtACTActAno_Jsonclick ;
      private string edtACTActMarca_Internalname ;
      private string edtACTActMarca_Jsonclick ;
      private string edtACTActMonCod_Internalname ;
      private string edtACTActMonCod_Jsonclick ;
      private string edtActActCostoMN_Internalname ;
      private string edtActActCostoMN_Jsonclick ;
      private string edtActActTipCmb_Internalname ;
      private string edtActActTipCmb_Jsonclick ;
      private string edtACTActSts_Internalname ;
      private string edtACTActSts_Jsonclick ;
      private string edtACTActVida_Internalname ;
      private string edtACTActVida_Jsonclick ;
      private string imgACTActFoto_Internalname ;
      private string sImgUrl ;
      private string edtACTAreaCod_Internalname ;
      private string edtACTAreaCod_Jsonclick ;
      private string edtACTActOrd_Internalname ;
      private string edtACTActOrd_Jsonclick ;
      private string edtActUbiCod_Internalname ;
      private string edtActUbiCod_Jsonclick ;
      private string edtCOSCod_Internalname ;
      private string edtCOSCod_Jsonclick ;
      private string edtACTActFIni_Internalname ;
      private string edtACTActFIni_Jsonclick ;
      private string edtACTActCostoMO_Internalname ;
      private string edtACTActCostoMO_Jsonclick ;
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
      private string sMode184 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ2138ACTActTipCod ;
      private string ZZ2134ACTActReg ;
      private string ZZ79COSCod ;
      private DateTime Z2123ACTActFech ;
      private DateTime Z2124ACTActFIni ;
      private DateTime A2123ACTActFech ;
      private DateTime A2124ACTActFIni ;
      private DateTime ZZ2123ACTActFech ;
      private DateTime ZZ2124ACTActFIni ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A2125ACTActFoto_IsBlob ;
      private bool Gx_longc ;
      private string A2131ACTActObs ;
      private string Z2131ACTActObs ;
      private string ZZ2131ACTActObs ;
      private string Z2100ACTActCod ;
      private string Z2118ACTActCodEQV ;
      private string Z2122ACTActDsc ;
      private string Z2121ACTActDocNum ;
      private string Z2129ACTActModelo ;
      private string Z2135ACTActSerie ;
      private string Z2133ACTActParte ;
      private string Z2117ACTActCap ;
      private string Z2116ACTActAno ;
      private string Z2128ACTActMarca ;
      private string Z2136ACTActSts ;
      private string Z2132ACTActOrd ;
      private string Z426ACTClaCod ;
      private string Z2103ACTGrupCod ;
      private string Z2102ACTAreaCod ;
      private string Z2101ActUbiCod ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2102ACTAreaCod ;
      private string A2101ActUbiCod ;
      private string A2100ACTActCod ;
      private string A2118ACTActCodEQV ;
      private string A2122ACTActDsc ;
      private string A2121ACTActDocNum ;
      private string A2129ACTActModelo ;
      private string A2135ACTActSerie ;
      private string A2133ACTActParte ;
      private string A2117ACTActCap ;
      private string A2116ACTActAno ;
      private string A2128ACTActMarca ;
      private string A2136ACTActSts ;
      private string A40000ACTActFoto_GXI ;
      private string A2132ACTActOrd ;
      private string Z40000ACTActFoto_GXI ;
      private string ZZ2100ACTActCod ;
      private string ZZ2118ACTActCodEQV ;
      private string ZZ426ACTClaCod ;
      private string ZZ2103ACTGrupCod ;
      private string ZZ2122ACTActDsc ;
      private string ZZ2121ACTActDocNum ;
      private string ZZ2129ACTActModelo ;
      private string ZZ2135ACTActSerie ;
      private string ZZ2133ACTActParte ;
      private string ZZ2117ACTActCap ;
      private string ZZ2116ACTActAno ;
      private string ZZ2128ACTActMarca ;
      private string ZZ2136ACTActSts ;
      private string ZZ40000ACTActFoto_GXI ;
      private string ZZ2102ACTAreaCod ;
      private string ZZ2132ACTActOrd ;
      private string ZZ2101ActUbiCod ;
      private string A2125ACTActFoto ;
      private string Z2125ACTActFoto ;
      private string ZZ2125ACTActFoto ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006Q8_A2100ACTActCod ;
      private string[] T006Q8_A2118ACTActCodEQV ;
      private string[] T006Q8_A2122ACTActDsc ;
      private string[] T006Q8_A2131ACTActObs ;
      private string[] T006Q8_A2138ACTActTipCod ;
      private string[] T006Q8_A2121ACTActDocNum ;
      private DateTime[] T006Q8_A2123ACTActFech ;
      private string[] T006Q8_A2134ACTActReg ;
      private string[] T006Q8_A2129ACTActModelo ;
      private string[] T006Q8_A2135ACTActSerie ;
      private string[] T006Q8_A2133ACTActParte ;
      private string[] T006Q8_A2117ACTActCap ;
      private string[] T006Q8_A2116ACTActAno ;
      private string[] T006Q8_A2128ACTActMarca ;
      private int[] T006Q8_A2130ACTActMonCod ;
      private decimal[] T006Q8_A2119ActActCostoMN ;
      private decimal[] T006Q8_A2137ActActTipCmb ;
      private string[] T006Q8_A2136ACTActSts ;
      private decimal[] T006Q8_A2139ACTActVida ;
      private string[] T006Q8_A40000ACTActFoto_GXI ;
      private string[] T006Q8_A2132ACTActOrd ;
      private DateTime[] T006Q8_A2124ACTActFIni ;
      private decimal[] T006Q8_A2120ACTActCostoMO ;
      private string[] T006Q8_A426ACTClaCod ;
      private string[] T006Q8_A2103ACTGrupCod ;
      private string[] T006Q8_A2102ACTAreaCod ;
      private string[] T006Q8_A2101ActUbiCod ;
      private string[] T006Q8_A79COSCod ;
      private string[] T006Q8_A2125ACTActFoto ;
      private string[] T006Q4_A426ACTClaCod ;
      private string[] T006Q5_A2102ACTAreaCod ;
      private string[] T006Q6_A2101ActUbiCod ;
      private string[] T006Q7_A79COSCod ;
      private string[] T006Q9_A426ACTClaCod ;
      private string[] T006Q10_A2102ACTAreaCod ;
      private string[] T006Q11_A2101ActUbiCod ;
      private string[] T006Q12_A79COSCod ;
      private string[] T006Q13_A2100ACTActCod ;
      private string[] T006Q3_A2100ACTActCod ;
      private string[] T006Q3_A2118ACTActCodEQV ;
      private string[] T006Q3_A2122ACTActDsc ;
      private string[] T006Q3_A2131ACTActObs ;
      private string[] T006Q3_A2138ACTActTipCod ;
      private string[] T006Q3_A2121ACTActDocNum ;
      private DateTime[] T006Q3_A2123ACTActFech ;
      private string[] T006Q3_A2134ACTActReg ;
      private string[] T006Q3_A2129ACTActModelo ;
      private string[] T006Q3_A2135ACTActSerie ;
      private string[] T006Q3_A2133ACTActParte ;
      private string[] T006Q3_A2117ACTActCap ;
      private string[] T006Q3_A2116ACTActAno ;
      private string[] T006Q3_A2128ACTActMarca ;
      private int[] T006Q3_A2130ACTActMonCod ;
      private decimal[] T006Q3_A2119ActActCostoMN ;
      private decimal[] T006Q3_A2137ActActTipCmb ;
      private string[] T006Q3_A2136ACTActSts ;
      private decimal[] T006Q3_A2139ACTActVida ;
      private string[] T006Q3_A40000ACTActFoto_GXI ;
      private string[] T006Q3_A2132ACTActOrd ;
      private DateTime[] T006Q3_A2124ACTActFIni ;
      private decimal[] T006Q3_A2120ACTActCostoMO ;
      private string[] T006Q3_A426ACTClaCod ;
      private string[] T006Q3_A2103ACTGrupCod ;
      private string[] T006Q3_A2102ACTAreaCod ;
      private string[] T006Q3_A2101ActUbiCod ;
      private string[] T006Q3_A79COSCod ;
      private string[] T006Q3_A2125ACTActFoto ;
      private string[] T006Q14_A2100ACTActCod ;
      private string[] T006Q15_A2100ACTActCod ;
      private string[] T006Q2_A2100ACTActCod ;
      private string[] T006Q2_A2118ACTActCodEQV ;
      private string[] T006Q2_A2122ACTActDsc ;
      private string[] T006Q2_A2131ACTActObs ;
      private string[] T006Q2_A2138ACTActTipCod ;
      private string[] T006Q2_A2121ACTActDocNum ;
      private DateTime[] T006Q2_A2123ACTActFech ;
      private string[] T006Q2_A2134ACTActReg ;
      private string[] T006Q2_A2129ACTActModelo ;
      private string[] T006Q2_A2135ACTActSerie ;
      private string[] T006Q2_A2133ACTActParte ;
      private string[] T006Q2_A2117ACTActCap ;
      private string[] T006Q2_A2116ACTActAno ;
      private string[] T006Q2_A2128ACTActMarca ;
      private int[] T006Q2_A2130ACTActMonCod ;
      private decimal[] T006Q2_A2119ActActCostoMN ;
      private decimal[] T006Q2_A2137ActActTipCmb ;
      private string[] T006Q2_A2136ACTActSts ;
      private decimal[] T006Q2_A2139ACTActVida ;
      private string[] T006Q2_A40000ACTActFoto_GXI ;
      private string[] T006Q2_A2132ACTActOrd ;
      private DateTime[] T006Q2_A2124ACTActFIni ;
      private decimal[] T006Q2_A2120ACTActCostoMO ;
      private string[] T006Q2_A426ACTClaCod ;
      private string[] T006Q2_A2103ACTGrupCod ;
      private string[] T006Q2_A2102ACTAreaCod ;
      private string[] T006Q2_A2101ActUbiCod ;
      private string[] T006Q2_A79COSCod ;
      private string[] T006Q2_A2125ACTActFoto ;
      private string[] T006Q20_A2100ACTActCod ;
      private string[] T006Q20_A2104ActActItem ;
      private string[] T006Q21_A2100ACTActCod ;
      private string[] T006Q22_A426ACTClaCod ;
      private string[] T006Q23_A2102ACTAreaCod ;
      private string[] T006Q24_A2101ActUbiCod ;
      private string[] T006Q25_A79COSCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actactivos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actactivos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
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
        Object[] prmT006Q8;
        prmT006Q8 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q4;
        prmT006Q4 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q5;
        prmT006Q5 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q6;
        prmT006Q6 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q7;
        prmT006Q7 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        Object[] prmT006Q9;
        prmT006Q9 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q10;
        prmT006Q10 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q11;
        prmT006Q11 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q12;
        prmT006Q12 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        Object[] prmT006Q13;
        prmT006Q13 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q3;
        prmT006Q3 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q14;
        prmT006Q14 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q15;
        prmT006Q15 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q2;
        prmT006Q2 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q16;
        prmT006Q16 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ACTActCodEQV",GXType.NVarChar,20,0) ,
        new ParDef("@ACTActDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTActObs",GXType.NVarChar,500,0) ,
        new ParDef("@ACTActTipCod",GXType.NChar,5,0) ,
        new ParDef("@ACTActDocNum",GXType.NVarChar,15,0) ,
        new ParDef("@ACTActFech",GXType.Date,8,0) ,
        new ParDef("@ACTActReg",GXType.NChar,10,0) ,
        new ParDef("@ACTActModelo",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActSerie",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActParte",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActCap",GXType.NVarChar,20,0) ,
        new ParDef("@ACTActAno",GXType.NVarChar,4,0) ,
        new ParDef("@ACTActMarca",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActMonCod",GXType.Int32,6,0) ,
        new ParDef("@ActActCostoMN",GXType.Decimal,15,2) ,
        new ParDef("@ActActTipCmb",GXType.Decimal,15,4) ,
        new ParDef("@ACTActSts",GXType.NVarChar,1,0) ,
        new ParDef("@ACTActVida",GXType.Decimal,6,2) ,
        new ParDef("@ACTActFoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ACTActFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=19, Tbl="ACTACTIVOS", Fld="ACTActFoto"} ,
        new ParDef("@ACTActOrd",GXType.NVarChar,10,0) ,
        new ParDef("@ACTActFIni",GXType.Date,8,0) ,
        new ParDef("@ACTActCostoMO",GXType.Decimal,15,2) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        Object[] prmT006Q17;
        prmT006Q17 = new Object[] {
        new ParDef("@ACTActCodEQV",GXType.NVarChar,20,0) ,
        new ParDef("@ACTActDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTActObs",GXType.NVarChar,500,0) ,
        new ParDef("@ACTActTipCod",GXType.NChar,5,0) ,
        new ParDef("@ACTActDocNum",GXType.NVarChar,15,0) ,
        new ParDef("@ACTActFech",GXType.Date,8,0) ,
        new ParDef("@ACTActReg",GXType.NChar,10,0) ,
        new ParDef("@ACTActModelo",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActSerie",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActParte",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActCap",GXType.NVarChar,20,0) ,
        new ParDef("@ACTActAno",GXType.NVarChar,4,0) ,
        new ParDef("@ACTActMarca",GXType.NVarChar,50,0) ,
        new ParDef("@ACTActMonCod",GXType.Int32,6,0) ,
        new ParDef("@ActActCostoMN",GXType.Decimal,15,2) ,
        new ParDef("@ActActTipCmb",GXType.Decimal,15,4) ,
        new ParDef("@ACTActSts",GXType.NVarChar,1,0) ,
        new ParDef("@ACTActVida",GXType.Decimal,6,2) ,
        new ParDef("@ACTActOrd",GXType.NVarChar,10,0) ,
        new ParDef("@ACTActFIni",GXType.Date,8,0) ,
        new ParDef("@ACTActCostoMO",GXType.Decimal,15,2) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q18;
        prmT006Q18 = new Object[] {
        new ParDef("@ACTActFoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ACTActFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="ACTACTIVOS", Fld="ACTActFoto"} ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q19;
        prmT006Q19 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q20;
        prmT006Q20 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Q21;
        prmT006Q21 = new Object[] {
        };
        Object[] prmT006Q22;
        prmT006Q22 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q23;
        prmT006Q23 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q24;
        prmT006Q24 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006Q25;
        prmT006Q25 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006Q2", "SELECT [ACTActCod], [ACTActCodEQV], [ACTActDsc], [ACTActObs], [ACTActTipCod], [ACTActDocNum], [ACTActFech], [ACTActReg], [ACTActModelo], [ACTActSerie], [ACTActParte], [ACTActCap], [ACTActAno], [ACTActMarca], [ACTActMonCod], [ActActCostoMN], [ActActTipCmb], [ACTActSts], [ACTActVida], [ACTActFoto_GXI], [ACTActOrd], [ACTActFIni], [ACTActCostoMO], [ACTClaCod], [ACTGrupCod], [ACTAreaCod], [ActUbiCod], [COSCod], [ACTActFoto] FROM [ACTACTIVOS] WITH (UPDLOCK) WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q3", "SELECT [ACTActCod], [ACTActCodEQV], [ACTActDsc], [ACTActObs], [ACTActTipCod], [ACTActDocNum], [ACTActFech], [ACTActReg], [ACTActModelo], [ACTActSerie], [ACTActParte], [ACTActCap], [ACTActAno], [ACTActMarca], [ACTActMonCod], [ActActCostoMN], [ActActTipCmb], [ACTActSts], [ACTActVida], [ACTActFoto_GXI], [ACTActOrd], [ACTActFIni], [ACTActCostoMO], [ACTClaCod], [ACTGrupCod], [ACTAreaCod], [ActUbiCod], [COSCod], [ACTActFoto] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q4", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q5", "SELECT [ACTAreaCod] FROM [ACTAREA] WHERE [ACTAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q6", "SELECT [ActUbiCod] FROM [ACTUBICACION] WHERE [ActUbiCod] = @ActUbiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q7", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q8", "SELECT TM1.[ACTActCod], TM1.[ACTActCodEQV], TM1.[ACTActDsc], TM1.[ACTActObs], TM1.[ACTActTipCod], TM1.[ACTActDocNum], TM1.[ACTActFech], TM1.[ACTActReg], TM1.[ACTActModelo], TM1.[ACTActSerie], TM1.[ACTActParte], TM1.[ACTActCap], TM1.[ACTActAno], TM1.[ACTActMarca], TM1.[ACTActMonCod], TM1.[ActActCostoMN], TM1.[ActActTipCmb], TM1.[ACTActSts], TM1.[ACTActVida], TM1.[ACTActFoto_GXI], TM1.[ACTActOrd], TM1.[ACTActFIni], TM1.[ACTActCostoMO], TM1.[ACTClaCod], TM1.[ACTGrupCod], TM1.[ACTAreaCod], TM1.[ActUbiCod], TM1.[COSCod], TM1.[ACTActFoto] FROM [ACTACTIVOS] TM1 WHERE TM1.[ACTActCod] = @ACTActCod ORDER BY TM1.[ACTActCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q9", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q10", "SELECT [ACTAreaCod] FROM [ACTAREA] WHERE [ACTAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q11", "SELECT [ActUbiCod] FROM [ACTUBICACION] WHERE [ActUbiCod] = @ActUbiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q12", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q13", "SELECT [ACTActCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q14", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE ( [ACTActCod] > @ACTActCod) ORDER BY [ACTActCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Q15", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE ( [ACTActCod] < @ACTActCod) ORDER BY [ACTActCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Q16", "INSERT INTO [ACTACTIVOS]([ACTActCod], [ACTActCodEQV], [ACTActDsc], [ACTActObs], [ACTActTipCod], [ACTActDocNum], [ACTActFech], [ACTActReg], [ACTActModelo], [ACTActSerie], [ACTActParte], [ACTActCap], [ACTActAno], [ACTActMarca], [ACTActMonCod], [ActActCostoMN], [ActActTipCmb], [ACTActSts], [ACTActVida], [ACTActFoto], [ACTActFoto_GXI], [ACTActOrd], [ACTActFIni], [ACTActCostoMO], [ACTClaCod], [ACTGrupCod], [ACTAreaCod], [ActUbiCod], [COSCod]) VALUES(@ACTActCod, @ACTActCodEQV, @ACTActDsc, @ACTActObs, @ACTActTipCod, @ACTActDocNum, @ACTActFech, @ACTActReg, @ACTActModelo, @ACTActSerie, @ACTActParte, @ACTActCap, @ACTActAno, @ACTActMarca, @ACTActMonCod, @ActActCostoMN, @ActActTipCmb, @ACTActSts, @ACTActVida, @ACTActFoto, @ACTActFoto_GXI, @ACTActOrd, @ACTActFIni, @ACTActCostoMO, @ACTClaCod, @ACTGrupCod, @ACTAreaCod, @ActUbiCod, @COSCod)", GxErrorMask.GX_NOMASK,prmT006Q16)
           ,new CursorDef("T006Q17", "UPDATE [ACTACTIVOS] SET [ACTActCodEQV]=@ACTActCodEQV, [ACTActDsc]=@ACTActDsc, [ACTActObs]=@ACTActObs, [ACTActTipCod]=@ACTActTipCod, [ACTActDocNum]=@ACTActDocNum, [ACTActFech]=@ACTActFech, [ACTActReg]=@ACTActReg, [ACTActModelo]=@ACTActModelo, [ACTActSerie]=@ACTActSerie, [ACTActParte]=@ACTActParte, [ACTActCap]=@ACTActCap, [ACTActAno]=@ACTActAno, [ACTActMarca]=@ACTActMarca, [ACTActMonCod]=@ACTActMonCod, [ActActCostoMN]=@ActActCostoMN, [ActActTipCmb]=@ActActTipCmb, [ACTActSts]=@ACTActSts, [ACTActVida]=@ACTActVida, [ACTActOrd]=@ACTActOrd, [ACTActFIni]=@ACTActFIni, [ACTActCostoMO]=@ACTActCostoMO, [ACTClaCod]=@ACTClaCod, [ACTGrupCod]=@ACTGrupCod, [ACTAreaCod]=@ACTAreaCod, [ActUbiCod]=@ActUbiCod, [COSCod]=@COSCod  WHERE [ACTActCod] = @ACTActCod", GxErrorMask.GX_NOMASK,prmT006Q17)
           ,new CursorDef("T006Q18", "UPDATE [ACTACTIVOS] SET [ACTActFoto]=@ACTActFoto, [ACTActFoto_GXI]=@ACTActFoto_GXI  WHERE [ACTActCod] = @ACTActCod", GxErrorMask.GX_NOMASK,prmT006Q18)
           ,new CursorDef("T006Q19", "DELETE FROM [ACTACTIVOS]  WHERE [ACTActCod] = @ACTActCod", GxErrorMask.GX_NOMASK,prmT006Q19)
           ,new CursorDef("T006Q20", "SELECT TOP 1 [ACTActCod], [ActActItem] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Q21", "SELECT [ACTActCod] FROM [ACTACTIVOS] ORDER BY [ACTActCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q22", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q23", "SELECT [ACTAreaCod] FROM [ACTAREA] WHERE [ACTAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q24", "SELECT [ActUbiCod] FROM [ACTUBICACION] WHERE [ActUbiCod] = @ActUbiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Q25", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Q25,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((int[]) buf[14])[0] = rslt.getInt(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((string[]) buf[19])[0] = rslt.getMultimediaUri(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(22);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((string[]) buf[27])[0] = rslt.getString(28, 10);
              ((string[]) buf[28])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(20));
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((int[]) buf[14])[0] = rslt.getInt(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((string[]) buf[19])[0] = rslt.getMultimediaUri(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(22);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((string[]) buf[27])[0] = rslt.getString(28, 10);
              ((string[]) buf[28])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(20));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((int[]) buf[14])[0] = rslt.getInt(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((string[]) buf[19])[0] = rslt.getMultimediaUri(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(22);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((string[]) buf[27])[0] = rslt.getString(28, 10);
              ((string[]) buf[28])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(20));
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
