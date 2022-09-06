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
   public class actmovactivo : GXHttpHandler
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A2100ACTActCod = GetPar( "ACTActCod");
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2100ACTActCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A2100ACTActCod = GetPar( "ACTActCod");
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = GetPar( "ActActItem");
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A2100ACTActCod, A2104ActActItem) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A2111AMovAreaCod = GetPar( "AMovAreaCod");
            n2111AMovAreaCod = false;
            AssignAttri("", false, "A2111AMovAreaCod", A2111AMovAreaCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A2111AMovAreaCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A2110AMovCosCod = GetPar( "AMovCosCod");
            n2110AMovCosCod = false;
            AssignAttri("", false, "A2110AMovCosCod", A2110AMovCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A2110AMovCosCod) ;
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
            Form.Meta.addItem("description", "Movimiento de Activo Fijo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actmovactivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actmovactivo( IGxContext context )
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
            RenderHtmlCloseForm6Y192( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Movimiento de Activo Fijo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTMOVACTIVO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTMOVACTIVO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovCod_Internalname, "N° Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMovCod_Internalname, A2109AMovCod, StringUtil.RTrim( context.localUtil.Format( A2109AMovCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAMovFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAMovFec_Internalname, context.localUtil.Format(A2200AMovFec, "99/99/99"), context.localUtil.Format( A2200AMovFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_bitmap( context, edtAMovFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAMovFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTMOVACTIVO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActCod_Internalname, "Codigo Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActDsc_Internalname, A2122ACTActDsc, StringUtil.RTrim( context.localUtil.Format( A2122ACTActDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovAreaCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovAreaCod_Internalname, "Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMovAreaCod_Internalname, A2111AMovAreaCod, StringUtil.RTrim( context.localUtil.Format( A2111AMovAreaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovAreaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovAreaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovAreaDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovAreaDsc_Internalname, "Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAMovAreaDsc_Internalname, A2198AMovAreaDsc, StringUtil.RTrim( context.localUtil.Format( A2198AMovAreaDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovAreaDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovAreaDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovCosCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovCosCod_Internalname, "C.Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMovCosCod_Internalname, StringUtil.RTrim( A2110AMovCosCod), StringUtil.RTrim( context.localUtil.Format( A2110AMovCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovCosDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovCosDsc_Internalname, "C.Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAMovCosDsc_Internalname, StringUtil.RTrim( A2199AMovCosDsc), StringUtil.RTrim( context.localUtil.Format( A2199AMovCosDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovCosDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovCosDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovTipo_Internalname, "Tipo Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMovTipo_Internalname, A2203AMovTipo, StringUtil.RTrim( context.localUtil.Format( A2203AMovTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovTipo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovObs_Internalname, "Observaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAMovObs_Internalname, A2201AMovObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", 0, 1, edtAMovObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMovSubGrup_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMovSubGrup_Internalname, "Componente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMovSubGrup_Internalname, A2202AMovSubGrup, StringUtil.RTrim( context.localUtil.Format( A2202AMovSubGrup, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMovSubGrup_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMovSubGrup_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVACTIVO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVACTIVO.htm");
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
            Z2109AMovCod = cgiGet( "Z2109AMovCod");
            Z2200AMovFec = context.localUtil.CToD( cgiGet( "Z2200AMovFec"), 0);
            Z2203AMovTipo = cgiGet( "Z2203AMovTipo");
            Z2201AMovObs = cgiGet( "Z2201AMovObs");
            Z2202AMovSubGrup = cgiGet( "Z2202AMovSubGrup");
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            Z2111AMovAreaCod = cgiGet( "Z2111AMovAreaCod");
            Z2110AMovCosCod = cgiGet( "Z2110AMovCosCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2109AMovCod = cgiGet( edtAMovCod_Internalname);
            AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
            if ( context.localUtil.VCDate( cgiGet( edtAMovFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "AMOVFEC");
               AnyError = 1;
               GX_FocusControl = edtAMovFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2200AMovFec = DateTime.MinValue;
               AssignAttri("", false, "A2200AMovFec", context.localUtil.Format(A2200AMovFec, "99/99/99"));
            }
            else
            {
               A2200AMovFec = context.localUtil.CToD( cgiGet( edtAMovFec_Internalname), 2);
               AssignAttri("", false, "A2200AMovFec", context.localUtil.Format(A2200AMovFec, "99/99/99"));
            }
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2122ACTActDsc = cgiGet( edtACTActDsc_Internalname);
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            A2111AMovAreaCod = cgiGet( edtAMovAreaCod_Internalname);
            n2111AMovAreaCod = false;
            AssignAttri("", false, "A2111AMovAreaCod", A2111AMovAreaCod);
            A2198AMovAreaDsc = cgiGet( edtAMovAreaDsc_Internalname);
            AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
            A2110AMovCosCod = cgiGet( edtAMovCosCod_Internalname);
            n2110AMovCosCod = false;
            AssignAttri("", false, "A2110AMovCosCod", A2110AMovCosCod);
            A2199AMovCosDsc = cgiGet( edtAMovCosDsc_Internalname);
            AssignAttri("", false, "A2199AMovCosDsc", A2199AMovCosDsc);
            A2203AMovTipo = cgiGet( edtAMovTipo_Internalname);
            AssignAttri("", false, "A2203AMovTipo", A2203AMovTipo);
            A2201AMovObs = cgiGet( edtAMovObs_Internalname);
            AssignAttri("", false, "A2201AMovObs", A2201AMovObs);
            A2202AMovSubGrup = cgiGet( edtAMovSubGrup_Internalname);
            AssignAttri("", false, "A2202AMovSubGrup", A2202AMovSubGrup);
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
               A2109AMovCod = GetPar( "AMovCod");
               AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
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
               InitAll6Y192( ) ;
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
         DisableAttributes6Y192( ) ;
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

      protected void ResetCaption6Y0( )
      {
      }

      protected void ZM6Y192( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2200AMovFec = T006Y3_A2200AMovFec[0];
               Z2203AMovTipo = T006Y3_A2203AMovTipo[0];
               Z2201AMovObs = T006Y3_A2201AMovObs[0];
               Z2202AMovSubGrup = T006Y3_A2202AMovSubGrup[0];
               Z2100ACTActCod = T006Y3_A2100ACTActCod[0];
               Z2104ActActItem = T006Y3_A2104ActActItem[0];
               Z2111AMovAreaCod = T006Y3_A2111AMovAreaCod[0];
               Z2110AMovCosCod = T006Y3_A2110AMovCosCod[0];
            }
            else
            {
               Z2200AMovFec = A2200AMovFec;
               Z2203AMovTipo = A2203AMovTipo;
               Z2201AMovObs = A2201AMovObs;
               Z2202AMovSubGrup = A2202AMovSubGrup;
               Z2100ACTActCod = A2100ACTActCod;
               Z2104ActActItem = A2104ActActItem;
               Z2111AMovAreaCod = A2111AMovAreaCod;
               Z2110AMovCosCod = A2110AMovCosCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z2109AMovCod = A2109AMovCod;
            Z2200AMovFec = A2200AMovFec;
            Z2203AMovTipo = A2203AMovTipo;
            Z2201AMovObs = A2201AMovObs;
            Z2202AMovSubGrup = A2202AMovSubGrup;
            Z2100ACTActCod = A2100ACTActCod;
            Z2104ActActItem = A2104ActActItem;
            Z2111AMovAreaCod = A2111AMovAreaCod;
            Z2110AMovCosCod = A2110AMovCosCod;
            Z2122ACTActDsc = A2122ACTActDsc;
            Z2198AMovAreaDsc = A2198AMovAreaDsc;
            Z2199AMovCosDsc = A2199AMovCosDsc;
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

      protected void Load6Y192( )
      {
         /* Using cursor T006Y8 */
         pr_default.execute(6, new Object[] {A2109AMovCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound192 = 1;
            A2200AMovFec = T006Y8_A2200AMovFec[0];
            AssignAttri("", false, "A2200AMovFec", context.localUtil.Format(A2200AMovFec, "99/99/99"));
            A2122ACTActDsc = T006Y8_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2198AMovAreaDsc = T006Y8_A2198AMovAreaDsc[0];
            AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
            A2199AMovCosDsc = T006Y8_A2199AMovCosDsc[0];
            AssignAttri("", false, "A2199AMovCosDsc", A2199AMovCosDsc);
            A2203AMovTipo = T006Y8_A2203AMovTipo[0];
            AssignAttri("", false, "A2203AMovTipo", A2203AMovTipo);
            A2201AMovObs = T006Y8_A2201AMovObs[0];
            AssignAttri("", false, "A2201AMovObs", A2201AMovObs);
            A2202AMovSubGrup = T006Y8_A2202AMovSubGrup[0];
            AssignAttri("", false, "A2202AMovSubGrup", A2202AMovSubGrup);
            A2100ACTActCod = T006Y8_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006Y8_A2104ActActItem[0];
            n2104ActActItem = T006Y8_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            A2111AMovAreaCod = T006Y8_A2111AMovAreaCod[0];
            n2111AMovAreaCod = T006Y8_n2111AMovAreaCod[0];
            AssignAttri("", false, "A2111AMovAreaCod", A2111AMovAreaCod);
            A2110AMovCosCod = T006Y8_A2110AMovCosCod[0];
            n2110AMovCosCod = T006Y8_n2110AMovCosCod[0];
            AssignAttri("", false, "A2110AMovCosCod", A2110AMovCosCod);
            ZM6Y192( -2) ;
         }
         pr_default.close(6);
         OnLoadActions6Y192( ) ;
      }

      protected void OnLoadActions6Y192( )
      {
      }

      protected void CheckExtendedTable6Y192( )
      {
         nIsDirty_192 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2200AMovFec) || ( DateTimeUtil.ResetTime ( A2200AMovFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "AMOVFEC");
            AnyError = 1;
            GX_FocusControl = edtAMovFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006Y4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006Y4_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         pr_default.close(2);
         /* Using cursor T006Y5 */
         pr_default.execute(3, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2100ACTActCod)) || String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ) )
            {
               GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
               AnyError = 1;
               GX_FocusControl = edtACTActCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T006Y6 */
         pr_default.execute(4, new Object[] {n2111AMovAreaCod, A2111AMovAreaCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2111AMovAreaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Areas de Activo Fijo'.", "ForeignKeyNotFound", 1, "AMOVAREACOD");
               AnyError = 1;
               GX_FocusControl = edtAMovAreaCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2198AMovAreaDsc = T006Y6_A2198AMovAreaDsc[0];
         AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
         pr_default.close(4);
         /* Using cursor T006Y7 */
         pr_default.execute(5, new Object[] {n2110AMovCosCod, A2110AMovCosCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2110AMovCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "AMOVCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtAMovCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2199AMovCosDsc = T006Y7_A2199AMovCosDsc[0];
         AssignAttri("", false, "A2199AMovCosDsc", A2199AMovCosDsc);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors6Y192( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A2100ACTActCod )
      {
         /* Using cursor T006Y9 */
         pr_default.execute(7, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006Y9_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2122ACTActDsc)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( string A2100ACTActCod ,
                               string A2104ActActItem )
      {
         /* Using cursor T006Y10 */
         pr_default.execute(8, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2100ACTActCod)) || String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ) )
            {
               GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
               AnyError = 1;
               GX_FocusControl = edtACTActCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_5( string A2111AMovAreaCod )
      {
         /* Using cursor T006Y11 */
         pr_default.execute(9, new Object[] {n2111AMovAreaCod, A2111AMovAreaCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2111AMovAreaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Areas de Activo Fijo'.", "ForeignKeyNotFound", 1, "AMOVAREACOD");
               AnyError = 1;
               GX_FocusControl = edtAMovAreaCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2198AMovAreaDsc = T006Y11_A2198AMovAreaDsc[0];
         AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2198AMovAreaDsc)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( string A2110AMovCosCod )
      {
         /* Using cursor T006Y12 */
         pr_default.execute(10, new Object[] {n2110AMovCosCod, A2110AMovCosCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2110AMovCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "AMOVCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtAMovCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2199AMovCosDsc = T006Y12_A2199AMovCosDsc[0];
         AssignAttri("", false, "A2199AMovCosDsc", A2199AMovCosDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2199AMovCosDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey6Y192( )
      {
         /* Using cursor T006Y13 */
         pr_default.execute(11, new Object[] {A2109AMovCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound192 = 1;
         }
         else
         {
            RcdFound192 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006Y3 */
         pr_default.execute(1, new Object[] {A2109AMovCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6Y192( 2) ;
            RcdFound192 = 1;
            A2109AMovCod = T006Y3_A2109AMovCod[0];
            AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
            A2200AMovFec = T006Y3_A2200AMovFec[0];
            AssignAttri("", false, "A2200AMovFec", context.localUtil.Format(A2200AMovFec, "99/99/99"));
            A2203AMovTipo = T006Y3_A2203AMovTipo[0];
            AssignAttri("", false, "A2203AMovTipo", A2203AMovTipo);
            A2201AMovObs = T006Y3_A2201AMovObs[0];
            AssignAttri("", false, "A2201AMovObs", A2201AMovObs);
            A2202AMovSubGrup = T006Y3_A2202AMovSubGrup[0];
            AssignAttri("", false, "A2202AMovSubGrup", A2202AMovSubGrup);
            A2100ACTActCod = T006Y3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006Y3_A2104ActActItem[0];
            n2104ActActItem = T006Y3_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            A2111AMovAreaCod = T006Y3_A2111AMovAreaCod[0];
            n2111AMovAreaCod = T006Y3_n2111AMovAreaCod[0];
            AssignAttri("", false, "A2111AMovAreaCod", A2111AMovAreaCod);
            A2110AMovCosCod = T006Y3_A2110AMovCosCod[0];
            n2110AMovCosCod = T006Y3_n2110AMovCosCod[0];
            AssignAttri("", false, "A2110AMovCosCod", A2110AMovCosCod);
            Z2109AMovCod = A2109AMovCod;
            sMode192 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6Y192( ) ;
            if ( AnyError == 1 )
            {
               RcdFound192 = 0;
               InitializeNonKey6Y192( ) ;
            }
            Gx_mode = sMode192;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound192 = 0;
            InitializeNonKey6Y192( ) ;
            sMode192 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode192;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6Y192( ) ;
         if ( RcdFound192 == 0 )
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
         RcdFound192 = 0;
         /* Using cursor T006Y14 */
         pr_default.execute(12, new Object[] {A2109AMovCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T006Y14_A2109AMovCod[0], A2109AMovCod) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T006Y14_A2109AMovCod[0], A2109AMovCod) > 0 ) ) )
            {
               A2109AMovCod = T006Y14_A2109AMovCod[0];
               AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
               RcdFound192 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound192 = 0;
         /* Using cursor T006Y15 */
         pr_default.execute(13, new Object[] {A2109AMovCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T006Y15_A2109AMovCod[0], A2109AMovCod) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T006Y15_A2109AMovCod[0], A2109AMovCod) < 0 ) ) )
            {
               A2109AMovCod = T006Y15_A2109AMovCod[0];
               AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
               RcdFound192 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6Y192( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6Y192( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound192 == 1 )
            {
               if ( StringUtil.StrCmp(A2109AMovCod, Z2109AMovCod) != 0 )
               {
                  A2109AMovCod = Z2109AMovCod;
                  AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AMOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6Y192( ) ;
                  GX_FocusControl = edtAMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2109AMovCod, Z2109AMovCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6Y192( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AMOVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtAMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6Y192( ) ;
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
         if ( StringUtil.StrCmp(A2109AMovCod, Z2109AMovCod) != 0 )
         {
            A2109AMovCod = Z2109AMovCod;
            AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtAMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAMovCod_Internalname;
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
         if ( RcdFound192 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtAMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAMovFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6Y192( ) ;
         if ( RcdFound192 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMovFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6Y192( ) ;
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
         if ( RcdFound192 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMovFec_Internalname;
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
         if ( RcdFound192 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMovFec_Internalname;
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
         ScanStart6Y192( ) ;
         if ( RcdFound192 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound192 != 0 )
            {
               ScanNext6Y192( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMovFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6Y192( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6Y192( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006Y2 */
            pr_default.execute(0, new Object[] {A2109AMovCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTMOVACTIVO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2200AMovFec ) != DateTimeUtil.ResetTime ( T006Y2_A2200AMovFec[0] ) ) || ( StringUtil.StrCmp(Z2203AMovTipo, T006Y2_A2203AMovTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z2201AMovObs, T006Y2_A2201AMovObs[0]) != 0 ) || ( StringUtil.StrCmp(Z2202AMovSubGrup, T006Y2_A2202AMovSubGrup[0]) != 0 ) || ( StringUtil.StrCmp(Z2100ACTActCod, T006Y2_A2100ACTActCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2104ActActItem, T006Y2_A2104ActActItem[0]) != 0 ) || ( StringUtil.StrCmp(Z2111AMovAreaCod, T006Y2_A2111AMovAreaCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2110AMovCosCod, T006Y2_A2110AMovCosCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2200AMovFec ) != DateTimeUtil.ResetTime ( T006Y2_A2200AMovFec[0] ) )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"AMovFec");
                  GXUtil.WriteLogRaw("Old: ",Z2200AMovFec);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2200AMovFec[0]);
               }
               if ( StringUtil.StrCmp(Z2203AMovTipo, T006Y2_A2203AMovTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"AMovTipo");
                  GXUtil.WriteLogRaw("Old: ",Z2203AMovTipo);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2203AMovTipo[0]);
               }
               if ( StringUtil.StrCmp(Z2201AMovObs, T006Y2_A2201AMovObs[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"AMovObs");
                  GXUtil.WriteLogRaw("Old: ",Z2201AMovObs);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2201AMovObs[0]);
               }
               if ( StringUtil.StrCmp(Z2202AMovSubGrup, T006Y2_A2202AMovSubGrup[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"AMovSubGrup");
                  GXUtil.WriteLogRaw("Old: ",Z2202AMovSubGrup);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2202AMovSubGrup[0]);
               }
               if ( StringUtil.StrCmp(Z2100ACTActCod, T006Y2_A2100ACTActCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"ACTActCod");
                  GXUtil.WriteLogRaw("Old: ",Z2100ACTActCod);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2100ACTActCod[0]);
               }
               if ( StringUtil.StrCmp(Z2104ActActItem, T006Y2_A2104ActActItem[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"ActActItem");
                  GXUtil.WriteLogRaw("Old: ",Z2104ActActItem);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2104ActActItem[0]);
               }
               if ( StringUtil.StrCmp(Z2111AMovAreaCod, T006Y2_A2111AMovAreaCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"AMovAreaCod");
                  GXUtil.WriteLogRaw("Old: ",Z2111AMovAreaCod);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2111AMovAreaCod[0]);
               }
               if ( StringUtil.StrCmp(Z2110AMovCosCod, T006Y2_A2110AMovCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovactivo:[seudo value changed for attri]"+"AMovCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z2110AMovCosCod);
                  GXUtil.WriteLogRaw("Current: ",T006Y2_A2110AMovCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTMOVACTIVO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6Y192( )
      {
         BeforeValidate6Y192( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6Y192( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6Y192( 0) ;
            CheckOptimisticConcurrency6Y192( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6Y192( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6Y192( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006Y16 */
                     pr_default.execute(14, new Object[] {A2109AMovCod, A2200AMovFec, A2203AMovTipo, A2201AMovObs, A2202AMovSubGrup, A2100ACTActCod, n2104ActActItem, A2104ActActItem, n2111AMovAreaCod, A2111AMovAreaCod, n2110AMovCosCod, A2110AMovCosCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTMOVACTIVO");
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
                           ResetCaption6Y0( ) ;
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
               Load6Y192( ) ;
            }
            EndLevel6Y192( ) ;
         }
         CloseExtendedTableCursors6Y192( ) ;
      }

      protected void Update6Y192( )
      {
         BeforeValidate6Y192( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6Y192( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6Y192( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6Y192( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6Y192( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006Y17 */
                     pr_default.execute(15, new Object[] {A2200AMovFec, A2203AMovTipo, A2201AMovObs, A2202AMovSubGrup, A2100ACTActCod, n2104ActActItem, A2104ActActItem, n2111AMovAreaCod, A2111AMovAreaCod, n2110AMovCosCod, A2110AMovCosCod, A2109AMovCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTMOVACTIVO");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTMOVACTIVO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6Y192( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6Y0( ) ;
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
            EndLevel6Y192( ) ;
         }
         CloseExtendedTableCursors6Y192( ) ;
      }

      protected void DeferredUpdate6Y192( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6Y192( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6Y192( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6Y192( ) ;
            AfterConfirm6Y192( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6Y192( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006Y18 */
                  pr_default.execute(16, new Object[] {A2109AMovCod});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTMOVACTIVO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound192 == 0 )
                        {
                           InitAll6Y192( ) ;
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
                        ResetCaption6Y0( ) ;
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
         sMode192 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6Y192( ) ;
         Gx_mode = sMode192;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6Y192( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006Y19 */
            pr_default.execute(17, new Object[] {A2100ACTActCod});
            A2122ACTActDsc = T006Y19_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            pr_default.close(17);
            /* Using cursor T006Y20 */
            pr_default.execute(18, new Object[] {n2111AMovAreaCod, A2111AMovAreaCod});
            A2198AMovAreaDsc = T006Y20_A2198AMovAreaDsc[0];
            AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
            pr_default.close(18);
            /* Using cursor T006Y21 */
            pr_default.execute(19, new Object[] {n2110AMovCosCod, A2110AMovCosCod});
            A2199AMovCosDsc = T006Y21_A2199AMovCosDsc[0];
            AssignAttri("", false, "A2199AMovCosDsc", A2199AMovCosDsc);
            pr_default.close(19);
         }
      }

      protected void EndLevel6Y192( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6Y192( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(19);
            context.CommitDataStores("actmovactivo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6Y0( ) ;
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
            pr_default.close(19);
            context.RollbackDataStores("actmovactivo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6Y192( )
      {
         /* Using cursor T006Y22 */
         pr_default.execute(20);
         RcdFound192 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound192 = 1;
            A2109AMovCod = T006Y22_A2109AMovCod[0];
            AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6Y192( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound192 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound192 = 1;
            A2109AMovCod = T006Y22_A2109AMovCod[0];
            AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
         }
      }

      protected void ScanEnd6Y192( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm6Y192( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6Y192( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6Y192( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6Y192( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6Y192( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6Y192( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6Y192( )
      {
         edtAMovCod_Enabled = 0;
         AssignProp("", false, edtAMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovCod_Enabled), 5, 0), true);
         edtAMovFec_Enabled = 0;
         AssignProp("", false, edtAMovFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovFec_Enabled), 5, 0), true);
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtACTActDsc_Enabled = 0;
         AssignProp("", false, edtACTActDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDsc_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtAMovAreaCod_Enabled = 0;
         AssignProp("", false, edtAMovAreaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovAreaCod_Enabled), 5, 0), true);
         edtAMovAreaDsc_Enabled = 0;
         AssignProp("", false, edtAMovAreaDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovAreaDsc_Enabled), 5, 0), true);
         edtAMovCosCod_Enabled = 0;
         AssignProp("", false, edtAMovCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovCosCod_Enabled), 5, 0), true);
         edtAMovCosDsc_Enabled = 0;
         AssignProp("", false, edtAMovCosDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovCosDsc_Enabled), 5, 0), true);
         edtAMovTipo_Enabled = 0;
         AssignProp("", false, edtAMovTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovTipo_Enabled), 5, 0), true);
         edtAMovObs_Enabled = 0;
         AssignProp("", false, edtAMovObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovObs_Enabled), 5, 0), true);
         edtAMovSubGrup_Enabled = 0;
         AssignProp("", false, edtAMovSubGrup_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMovSubGrup_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6Y192( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6Y0( )
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
         context.SendWebValue( "Movimiento de Activo Fijo") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265332", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actmovactivo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2109AMovCod", Z2109AMovCod);
         GxWebStd.gx_hidden_field( context, "Z2200AMovFec", context.localUtil.DToC( Z2200AMovFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2203AMovTipo", Z2203AMovTipo);
         GxWebStd.gx_hidden_field( context, "Z2201AMovObs", Z2201AMovObs);
         GxWebStd.gx_hidden_field( context, "Z2202AMovSubGrup", Z2202AMovSubGrup);
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2111AMovAreaCod", Z2111AMovAreaCod);
         GxWebStd.gx_hidden_field( context, "Z2110AMovCosCod", StringUtil.RTrim( Z2110AMovCosCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm6Y192( )
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
         return "ACTMOVACTIVO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimiento de Activo Fijo" ;
      }

      protected void InitializeNonKey6Y192( )
      {
         A2200AMovFec = DateTime.MinValue;
         AssignAttri("", false, "A2200AMovFec", context.localUtil.Format(A2200AMovFec, "99/99/99"));
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2122ACTActDsc = "";
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A2104ActActItem = "";
         n2104ActActItem = false;
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
         A2111AMovAreaCod = "";
         n2111AMovAreaCod = false;
         AssignAttri("", false, "A2111AMovAreaCod", A2111AMovAreaCod);
         A2198AMovAreaDsc = "";
         AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
         A2110AMovCosCod = "";
         n2110AMovCosCod = false;
         AssignAttri("", false, "A2110AMovCosCod", A2110AMovCosCod);
         A2199AMovCosDsc = "";
         AssignAttri("", false, "A2199AMovCosDsc", A2199AMovCosDsc);
         A2203AMovTipo = "";
         AssignAttri("", false, "A2203AMovTipo", A2203AMovTipo);
         A2201AMovObs = "";
         AssignAttri("", false, "A2201AMovObs", A2201AMovObs);
         A2202AMovSubGrup = "";
         AssignAttri("", false, "A2202AMovSubGrup", A2202AMovSubGrup);
         Z2200AMovFec = DateTime.MinValue;
         Z2203AMovTipo = "";
         Z2201AMovObs = "";
         Z2202AMovSubGrup = "";
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
         Z2111AMovAreaCod = "";
         Z2110AMovCosCod = "";
      }

      protected void InitAll6Y192( )
      {
         A2109AMovCod = "";
         AssignAttri("", false, "A2109AMovCod", A2109AMovCod);
         InitializeNonKey6Y192( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265341", true, true);
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
         context.AddJavascriptSource("actmovactivo.js", "?202281810265341", false, true);
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
         edtAMovCod_Internalname = "AMOVCOD";
         edtAMovFec_Internalname = "AMOVFEC";
         edtACTActCod_Internalname = "ACTACTCOD";
         edtACTActDsc_Internalname = "ACTACTDSC";
         edtActActItem_Internalname = "ACTACTITEM";
         edtAMovAreaCod_Internalname = "AMOVAREACOD";
         edtAMovAreaDsc_Internalname = "AMOVAREADSC";
         edtAMovCosCod_Internalname = "AMOVCOSCOD";
         edtAMovCosDsc_Internalname = "AMOVCOSDSC";
         edtAMovTipo_Internalname = "AMOVTIPO";
         edtAMovObs_Internalname = "AMOVOBS";
         edtAMovSubGrup_Internalname = "AMOVSUBGRUP";
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
         edtAMovSubGrup_Jsonclick = "";
         edtAMovSubGrup_Enabled = 1;
         edtAMovObs_Enabled = 1;
         edtAMovTipo_Jsonclick = "";
         edtAMovTipo_Enabled = 1;
         edtAMovCosDsc_Jsonclick = "";
         edtAMovCosDsc_Enabled = 0;
         edtAMovCosCod_Jsonclick = "";
         edtAMovCosCod_Enabled = 1;
         edtAMovAreaDsc_Jsonclick = "";
         edtAMovAreaDsc_Enabled = 0;
         edtAMovAreaCod_Jsonclick = "";
         edtAMovAreaCod_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActDsc_Jsonclick = "";
         edtACTActDsc_Enabled = 0;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
         edtAMovFec_Jsonclick = "";
         edtAMovFec_Enabled = 1;
         edtAMovCod_Jsonclick = "";
         edtAMovCod_Enabled = 1;
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
         GX_FocusControl = edtAMovFec_Internalname;
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

      public void Valid_Amovcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2200AMovFec", context.localUtil.Format(A2200AMovFec, "99/99/99"));
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         AssignAttri("", false, "A2111AMovAreaCod", A2111AMovAreaCod);
         AssignAttri("", false, "A2110AMovCosCod", StringUtil.RTrim( A2110AMovCosCod));
         AssignAttri("", false, "A2203AMovTipo", A2203AMovTipo);
         AssignAttri("", false, "A2201AMovObs", A2201AMovObs);
         AssignAttri("", false, "A2202AMovSubGrup", A2202AMovSubGrup);
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
         AssignAttri("", false, "A2199AMovCosDsc", StringUtil.RTrim( A2199AMovCosDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2109AMovCod", Z2109AMovCod);
         GxWebStd.gx_hidden_field( context, "Z2200AMovFec", context.localUtil.Format(Z2200AMovFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2111AMovAreaCod", Z2111AMovAreaCod);
         GxWebStd.gx_hidden_field( context, "Z2110AMovCosCod", StringUtil.RTrim( Z2110AMovCosCod));
         GxWebStd.gx_hidden_field( context, "Z2203AMovTipo", Z2203AMovTipo);
         GxWebStd.gx_hidden_field( context, "Z2201AMovObs", Z2201AMovObs);
         GxWebStd.gx_hidden_field( context, "Z2202AMovSubGrup", Z2202AMovSubGrup);
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         GxWebStd.gx_hidden_field( context, "Z2198AMovAreaDsc", Z2198AMovAreaDsc);
         GxWebStd.gx_hidden_field( context, "Z2199AMovCosDsc", StringUtil.RTrim( Z2199AMovCosDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actactcod( )
      {
         /* Using cursor T006Y19 */
         pr_default.execute(17, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         A2122ACTActDsc = T006Y19_A2122ACTActDsc[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
      }

      public void Valid_Actactitem( )
      {
         n2104ActActItem = false;
         /* Using cursor T006Y23 */
         pr_default.execute(21, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2100ACTActCod)) || String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ) )
            {
               GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
               AnyError = 1;
               GX_FocusControl = edtACTActCod_Internalname;
            }
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Amovareacod( )
      {
         n2111AMovAreaCod = false;
         /* Using cursor T006Y20 */
         pr_default.execute(18, new Object[] {n2111AMovAreaCod, A2111AMovAreaCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2111AMovAreaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Areas de Activo Fijo'.", "ForeignKeyNotFound", 1, "AMOVAREACOD");
               AnyError = 1;
               GX_FocusControl = edtAMovAreaCod_Internalname;
            }
         }
         A2198AMovAreaDsc = T006Y20_A2198AMovAreaDsc[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2198AMovAreaDsc", A2198AMovAreaDsc);
      }

      public void Valid_Amovcoscod( )
      {
         n2110AMovCosCod = false;
         /* Using cursor T006Y21 */
         pr_default.execute(19, new Object[] {n2110AMovCosCod, A2110AMovCosCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2110AMovCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "AMOVCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtAMovCosCod_Internalname;
            }
         }
         A2199AMovCosDsc = T006Y21_A2199AMovCosDsc[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2199AMovCosDsc", StringUtil.RTrim( A2199AMovCosDsc));
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
         setEventMetadata("VALID_AMOVCOD","{handler:'Valid_Amovcod',iparms:[{av:'A2109AMovCod',fld:'AMOVCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_AMOVCOD",",oparms:[{av:'A2200AMovFec',fld:'AMOVFEC',pic:''},{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'A2111AMovAreaCod',fld:'AMOVAREACOD',pic:''},{av:'A2110AMovCosCod',fld:'AMOVCOSCOD',pic:''},{av:'A2203AMovTipo',fld:'AMOVTIPO',pic:''},{av:'A2201AMovObs',fld:'AMOVOBS',pic:''},{av:'A2202AMovSubGrup',fld:'AMOVSUBGRUP',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'A2198AMovAreaDsc',fld:'AMOVAREADSC',pic:''},{av:'A2199AMovCosDsc',fld:'AMOVCOSDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2109AMovCod'},{av:'Z2200AMovFec'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2111AMovAreaCod'},{av:'Z2110AMovCosCod'},{av:'Z2203AMovTipo'},{av:'Z2201AMovObs'},{av:'Z2202AMovSubGrup'},{av:'Z2122ACTActDsc'},{av:'Z2198AMovAreaDsc'},{av:'Z2199AMovCosDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_AMOVFEC","{handler:'Valid_Amovfec',iparms:[]");
         setEventMetadata("VALID_AMOVFEC",",oparms:[]}");
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''}]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''}]}");
         setEventMetadata("VALID_ACTACTITEM","{handler:'Valid_Actactitem',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''}]");
         setEventMetadata("VALID_ACTACTITEM",",oparms:[]}");
         setEventMetadata("VALID_AMOVAREACOD","{handler:'Valid_Amovareacod',iparms:[{av:'A2111AMovAreaCod',fld:'AMOVAREACOD',pic:''},{av:'A2198AMovAreaDsc',fld:'AMOVAREADSC',pic:''}]");
         setEventMetadata("VALID_AMOVAREACOD",",oparms:[{av:'A2198AMovAreaDsc',fld:'AMOVAREADSC',pic:''}]}");
         setEventMetadata("VALID_AMOVCOSCOD","{handler:'Valid_Amovcoscod',iparms:[{av:'A2110AMovCosCod',fld:'AMOVCOSCOD',pic:''},{av:'A2199AMovCosDsc',fld:'AMOVCOSDSC',pic:''}]");
         setEventMetadata("VALID_AMOVCOSCOD",",oparms:[{av:'A2199AMovCosDsc',fld:'AMOVCOSDSC',pic:''}]}");
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
         pr_default.close(17);
         pr_default.close(21);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2109AMovCod = "";
         Z2200AMovFec = DateTime.MinValue;
         Z2203AMovTipo = "";
         Z2201AMovObs = "";
         Z2202AMovSubGrup = "";
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
         Z2111AMovAreaCod = "";
         Z2110AMovCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
         A2111AMovAreaCod = "";
         A2110AMovCosCod = "";
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
         A2109AMovCod = "";
         A2200AMovFec = DateTime.MinValue;
         A2122ACTActDsc = "";
         A2198AMovAreaDsc = "";
         A2199AMovCosDsc = "";
         A2203AMovTipo = "";
         A2201AMovObs = "";
         A2202AMovSubGrup = "";
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
         Z2122ACTActDsc = "";
         Z2198AMovAreaDsc = "";
         Z2199AMovCosDsc = "";
         T006Y8_A2109AMovCod = new string[] {""} ;
         T006Y8_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         T006Y8_A2122ACTActDsc = new string[] {""} ;
         T006Y8_A2198AMovAreaDsc = new string[] {""} ;
         T006Y8_A2199AMovCosDsc = new string[] {""} ;
         T006Y8_A2203AMovTipo = new string[] {""} ;
         T006Y8_A2201AMovObs = new string[] {""} ;
         T006Y8_A2202AMovSubGrup = new string[] {""} ;
         T006Y8_A2100ACTActCod = new string[] {""} ;
         T006Y8_A2104ActActItem = new string[] {""} ;
         T006Y8_n2104ActActItem = new bool[] {false} ;
         T006Y8_A2111AMovAreaCod = new string[] {""} ;
         T006Y8_n2111AMovAreaCod = new bool[] {false} ;
         T006Y8_A2110AMovCosCod = new string[] {""} ;
         T006Y8_n2110AMovCosCod = new bool[] {false} ;
         T006Y4_A2122ACTActDsc = new string[] {""} ;
         T006Y5_A2100ACTActCod = new string[] {""} ;
         T006Y6_A2198AMovAreaDsc = new string[] {""} ;
         T006Y7_A2199AMovCosDsc = new string[] {""} ;
         T006Y9_A2122ACTActDsc = new string[] {""} ;
         T006Y10_A2100ACTActCod = new string[] {""} ;
         T006Y11_A2198AMovAreaDsc = new string[] {""} ;
         T006Y12_A2199AMovCosDsc = new string[] {""} ;
         T006Y13_A2109AMovCod = new string[] {""} ;
         T006Y3_A2109AMovCod = new string[] {""} ;
         T006Y3_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         T006Y3_A2203AMovTipo = new string[] {""} ;
         T006Y3_A2201AMovObs = new string[] {""} ;
         T006Y3_A2202AMovSubGrup = new string[] {""} ;
         T006Y3_A2100ACTActCod = new string[] {""} ;
         T006Y3_A2104ActActItem = new string[] {""} ;
         T006Y3_n2104ActActItem = new bool[] {false} ;
         T006Y3_A2111AMovAreaCod = new string[] {""} ;
         T006Y3_n2111AMovAreaCod = new bool[] {false} ;
         T006Y3_A2110AMovCosCod = new string[] {""} ;
         T006Y3_n2110AMovCosCod = new bool[] {false} ;
         sMode192 = "";
         T006Y14_A2109AMovCod = new string[] {""} ;
         T006Y15_A2109AMovCod = new string[] {""} ;
         T006Y2_A2109AMovCod = new string[] {""} ;
         T006Y2_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         T006Y2_A2203AMovTipo = new string[] {""} ;
         T006Y2_A2201AMovObs = new string[] {""} ;
         T006Y2_A2202AMovSubGrup = new string[] {""} ;
         T006Y2_A2100ACTActCod = new string[] {""} ;
         T006Y2_A2104ActActItem = new string[] {""} ;
         T006Y2_n2104ActActItem = new bool[] {false} ;
         T006Y2_A2111AMovAreaCod = new string[] {""} ;
         T006Y2_n2111AMovAreaCod = new bool[] {false} ;
         T006Y2_A2110AMovCosCod = new string[] {""} ;
         T006Y2_n2110AMovCosCod = new bool[] {false} ;
         T006Y19_A2122ACTActDsc = new string[] {""} ;
         T006Y20_A2198AMovAreaDsc = new string[] {""} ;
         T006Y21_A2199AMovCosDsc = new string[] {""} ;
         T006Y22_A2109AMovCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2109AMovCod = "";
         ZZ2200AMovFec = DateTime.MinValue;
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2111AMovAreaCod = "";
         ZZ2110AMovCosCod = "";
         ZZ2203AMovTipo = "";
         ZZ2201AMovObs = "";
         ZZ2202AMovSubGrup = "";
         ZZ2122ACTActDsc = "";
         ZZ2198AMovAreaDsc = "";
         ZZ2199AMovCosDsc = "";
         T006Y23_A2100ACTActCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actmovactivo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actmovactivo__default(),
            new Object[][] {
                new Object[] {
               T006Y2_A2109AMovCod, T006Y2_A2200AMovFec, T006Y2_A2203AMovTipo, T006Y2_A2201AMovObs, T006Y2_A2202AMovSubGrup, T006Y2_A2100ACTActCod, T006Y2_A2104ActActItem, T006Y2_n2104ActActItem, T006Y2_A2111AMovAreaCod, T006Y2_n2111AMovAreaCod,
               T006Y2_A2110AMovCosCod, T006Y2_n2110AMovCosCod
               }
               , new Object[] {
               T006Y3_A2109AMovCod, T006Y3_A2200AMovFec, T006Y3_A2203AMovTipo, T006Y3_A2201AMovObs, T006Y3_A2202AMovSubGrup, T006Y3_A2100ACTActCod, T006Y3_A2104ActActItem, T006Y3_n2104ActActItem, T006Y3_A2111AMovAreaCod, T006Y3_n2111AMovAreaCod,
               T006Y3_A2110AMovCosCod, T006Y3_n2110AMovCosCod
               }
               , new Object[] {
               T006Y4_A2122ACTActDsc
               }
               , new Object[] {
               T006Y5_A2100ACTActCod
               }
               , new Object[] {
               T006Y6_A2198AMovAreaDsc
               }
               , new Object[] {
               T006Y7_A2199AMovCosDsc
               }
               , new Object[] {
               T006Y8_A2109AMovCod, T006Y8_A2200AMovFec, T006Y8_A2122ACTActDsc, T006Y8_A2198AMovAreaDsc, T006Y8_A2199AMovCosDsc, T006Y8_A2203AMovTipo, T006Y8_A2201AMovObs, T006Y8_A2202AMovSubGrup, T006Y8_A2100ACTActCod, T006Y8_A2104ActActItem,
               T006Y8_n2104ActActItem, T006Y8_A2111AMovAreaCod, T006Y8_n2111AMovAreaCod, T006Y8_A2110AMovCosCod, T006Y8_n2110AMovCosCod
               }
               , new Object[] {
               T006Y9_A2122ACTActDsc
               }
               , new Object[] {
               T006Y10_A2100ACTActCod
               }
               , new Object[] {
               T006Y11_A2198AMovAreaDsc
               }
               , new Object[] {
               T006Y12_A2199AMovCosDsc
               }
               , new Object[] {
               T006Y13_A2109AMovCod
               }
               , new Object[] {
               T006Y14_A2109AMovCod
               }
               , new Object[] {
               T006Y15_A2109AMovCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006Y19_A2122ACTActDsc
               }
               , new Object[] {
               T006Y20_A2198AMovAreaDsc
               }
               , new Object[] {
               T006Y21_A2199AMovCosDsc
               }
               , new Object[] {
               T006Y22_A2109AMovCod
               }
               , new Object[] {
               T006Y23_A2100ACTActCod
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
      private short RcdFound192 ;
      private short nIsDirty_192 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAMovCod_Enabled ;
      private int edtAMovFec_Enabled ;
      private int edtACTActCod_Enabled ;
      private int edtACTActDsc_Enabled ;
      private int edtActActItem_Enabled ;
      private int edtAMovAreaCod_Enabled ;
      private int edtAMovAreaDsc_Enabled ;
      private int edtAMovCosCod_Enabled ;
      private int edtAMovCosDsc_Enabled ;
      private int edtAMovTipo_Enabled ;
      private int edtAMovObs_Enabled ;
      private int edtAMovSubGrup_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z2110AMovCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2110AMovCosCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAMovCod_Internalname ;
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
      private string edtAMovCod_Jsonclick ;
      private string edtAMovFec_Internalname ;
      private string edtAMovFec_Jsonclick ;
      private string edtACTActCod_Internalname ;
      private string edtACTActCod_Jsonclick ;
      private string edtACTActDsc_Internalname ;
      private string edtACTActDsc_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtAMovAreaCod_Internalname ;
      private string edtAMovAreaCod_Jsonclick ;
      private string edtAMovAreaDsc_Internalname ;
      private string edtAMovAreaDsc_Jsonclick ;
      private string edtAMovCosCod_Internalname ;
      private string edtAMovCosCod_Jsonclick ;
      private string edtAMovCosDsc_Internalname ;
      private string A2199AMovCosDsc ;
      private string edtAMovCosDsc_Jsonclick ;
      private string edtAMovTipo_Internalname ;
      private string edtAMovTipo_Jsonclick ;
      private string edtAMovObs_Internalname ;
      private string edtAMovSubGrup_Internalname ;
      private string edtAMovSubGrup_Jsonclick ;
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
      private string Z2199AMovCosDsc ;
      private string sMode192 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2110AMovCosCod ;
      private string ZZ2199AMovCosDsc ;
      private DateTime Z2200AMovFec ;
      private DateTime A2200AMovFec ;
      private DateTime ZZ2200AMovFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2104ActActItem ;
      private bool n2111AMovAreaCod ;
      private bool n2110AMovCosCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2109AMovCod ;
      private string Z2203AMovTipo ;
      private string Z2201AMovObs ;
      private string Z2202AMovSubGrup ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string Z2111AMovAreaCod ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2111AMovAreaCod ;
      private string A2109AMovCod ;
      private string A2122ACTActDsc ;
      private string A2198AMovAreaDsc ;
      private string A2203AMovTipo ;
      private string A2201AMovObs ;
      private string A2202AMovSubGrup ;
      private string Z2122ACTActDsc ;
      private string Z2198AMovAreaDsc ;
      private string ZZ2109AMovCod ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private string ZZ2111AMovAreaCod ;
      private string ZZ2203AMovTipo ;
      private string ZZ2201AMovObs ;
      private string ZZ2202AMovSubGrup ;
      private string ZZ2122ACTActDsc ;
      private string ZZ2198AMovAreaDsc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006Y8_A2109AMovCod ;
      private DateTime[] T006Y8_A2200AMovFec ;
      private string[] T006Y8_A2122ACTActDsc ;
      private string[] T006Y8_A2198AMovAreaDsc ;
      private string[] T006Y8_A2199AMovCosDsc ;
      private string[] T006Y8_A2203AMovTipo ;
      private string[] T006Y8_A2201AMovObs ;
      private string[] T006Y8_A2202AMovSubGrup ;
      private string[] T006Y8_A2100ACTActCod ;
      private string[] T006Y8_A2104ActActItem ;
      private bool[] T006Y8_n2104ActActItem ;
      private string[] T006Y8_A2111AMovAreaCod ;
      private bool[] T006Y8_n2111AMovAreaCod ;
      private string[] T006Y8_A2110AMovCosCod ;
      private bool[] T006Y8_n2110AMovCosCod ;
      private string[] T006Y4_A2122ACTActDsc ;
      private string[] T006Y5_A2100ACTActCod ;
      private string[] T006Y6_A2198AMovAreaDsc ;
      private string[] T006Y7_A2199AMovCosDsc ;
      private string[] T006Y9_A2122ACTActDsc ;
      private string[] T006Y10_A2100ACTActCod ;
      private string[] T006Y11_A2198AMovAreaDsc ;
      private string[] T006Y12_A2199AMovCosDsc ;
      private string[] T006Y13_A2109AMovCod ;
      private string[] T006Y3_A2109AMovCod ;
      private DateTime[] T006Y3_A2200AMovFec ;
      private string[] T006Y3_A2203AMovTipo ;
      private string[] T006Y3_A2201AMovObs ;
      private string[] T006Y3_A2202AMovSubGrup ;
      private string[] T006Y3_A2100ACTActCod ;
      private string[] T006Y3_A2104ActActItem ;
      private bool[] T006Y3_n2104ActActItem ;
      private string[] T006Y3_A2111AMovAreaCod ;
      private bool[] T006Y3_n2111AMovAreaCod ;
      private string[] T006Y3_A2110AMovCosCod ;
      private bool[] T006Y3_n2110AMovCosCod ;
      private string[] T006Y14_A2109AMovCod ;
      private string[] T006Y15_A2109AMovCod ;
      private string[] T006Y2_A2109AMovCod ;
      private DateTime[] T006Y2_A2200AMovFec ;
      private string[] T006Y2_A2203AMovTipo ;
      private string[] T006Y2_A2201AMovObs ;
      private string[] T006Y2_A2202AMovSubGrup ;
      private string[] T006Y2_A2100ACTActCod ;
      private string[] T006Y2_A2104ActActItem ;
      private bool[] T006Y2_n2104ActActItem ;
      private string[] T006Y2_A2111AMovAreaCod ;
      private bool[] T006Y2_n2111AMovAreaCod ;
      private string[] T006Y2_A2110AMovCosCod ;
      private bool[] T006Y2_n2110AMovCosCod ;
      private string[] T006Y19_A2122ACTActDsc ;
      private string[] T006Y20_A2198AMovAreaDsc ;
      private string[] T006Y21_A2199AMovCosDsc ;
      private string[] T006Y22_A2109AMovCod ;
      private string[] T006Y23_A2100ACTActCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actmovactivo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actmovactivo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT006Y8;
        prmT006Y8 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y4;
        prmT006Y4 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Y5;
        prmT006Y5 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Y6;
        prmT006Y6 = new Object[] {
        new ParDef("@AMovAreaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Y7;
        prmT006Y7 = new Object[] {
        new ParDef("@AMovCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006Y9;
        prmT006Y9 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Y10;
        prmT006Y10 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Y11;
        prmT006Y11 = new Object[] {
        new ParDef("@AMovAreaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Y12;
        prmT006Y12 = new Object[] {
        new ParDef("@AMovCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006Y13;
        prmT006Y13 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y3;
        prmT006Y3 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y14;
        prmT006Y14 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y15;
        prmT006Y15 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y2;
        prmT006Y2 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y16;
        prmT006Y16 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@AMovFec",GXType.Date,8,0) ,
        new ParDef("@AMovTipo",GXType.NVarChar,20,0) ,
        new ParDef("@AMovObs",GXType.NVarChar,500,0) ,
        new ParDef("@AMovSubGrup",GXType.NVarChar,5,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@AMovAreaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@AMovCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT006Y17;
        prmT006Y17 = new Object[] {
        new ParDef("@AMovFec",GXType.Date,8,0) ,
        new ParDef("@AMovTipo",GXType.NVarChar,20,0) ,
        new ParDef("@AMovObs",GXType.NVarChar,500,0) ,
        new ParDef("@AMovSubGrup",GXType.NVarChar,5,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@AMovAreaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@AMovCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y18;
        prmT006Y18 = new Object[] {
        new ParDef("@AMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Y22;
        prmT006Y22 = new Object[] {
        };
        Object[] prmT006Y19;
        prmT006Y19 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Y23;
        prmT006Y23 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Y20;
        prmT006Y20 = new Object[] {
        new ParDef("@AMovAreaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Y21;
        prmT006Y21 = new Object[] {
        new ParDef("@AMovCosCod",GXType.NChar,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006Y2", "SELECT [AMovCod], [AMovFec], [AMovTipo], [AMovObs], [AMovSubGrup], [ACTActCod], [ActActItem], [AMovAreaCod] AS AMovAreaCod, [AMovCosCod] AS AMovCosCod FROM [ACTMOVACTIVO] WITH (UPDLOCK) WHERE [AMovCod] = @AMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y3", "SELECT [AMovCod], [AMovFec], [AMovTipo], [AMovObs], [AMovSubGrup], [ACTActCod], [ActActItem], [AMovAreaCod] AS AMovAreaCod, [AMovCosCod] AS AMovCosCod FROM [ACTMOVACTIVO] WHERE [AMovCod] = @AMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y4", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y5", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y6", "SELECT [ACTAreaDsc] AS AMovAreaDsc FROM [ACTAREA] WHERE [ACTAreaCod] = @AMovAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y7", "SELECT [COSDsc] AS AMovCosDsc FROM [CBCOSTOS] WHERE [COSCod] = @AMovCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y8", "SELECT TM1.[AMovCod], TM1.[AMovFec], T2.[ACTActDsc], T3.[ACTAreaDsc] AS AMovAreaDsc, T4.[COSDsc] AS AMovCosDsc, TM1.[AMovTipo], TM1.[AMovObs], TM1.[AMovSubGrup], TM1.[ACTActCod], TM1.[ActActItem], TM1.[AMovAreaCod] AS AMovAreaCod, TM1.[AMovCosCod] AS AMovCosCod FROM ((([ACTMOVACTIVO] TM1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = TM1.[ACTActCod]) LEFT JOIN [ACTAREA] T3 ON T3.[ACTAreaCod] = TM1.[AMovAreaCod]) LEFT JOIN [CBCOSTOS] T4 ON T4.[COSCod] = TM1.[AMovCosCod]) WHERE TM1.[AMovCod] = @AMovCod ORDER BY TM1.[AMovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y9", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y10", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y11", "SELECT [ACTAreaDsc] AS AMovAreaDsc FROM [ACTAREA] WHERE [ACTAreaCod] = @AMovAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y12", "SELECT [COSDsc] AS AMovCosDsc FROM [CBCOSTOS] WHERE [COSCod] = @AMovCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y13", "SELECT [AMovCod] FROM [ACTMOVACTIVO] WHERE [AMovCod] = @AMovCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y14", "SELECT TOP 1 [AMovCod] FROM [ACTMOVACTIVO] WHERE ( [AMovCod] > @AMovCod) ORDER BY [AMovCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Y15", "SELECT TOP 1 [AMovCod] FROM [ACTMOVACTIVO] WHERE ( [AMovCod] < @AMovCod) ORDER BY [AMovCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Y16", "INSERT INTO [ACTMOVACTIVO]([AMovCod], [AMovFec], [AMovTipo], [AMovObs], [AMovSubGrup], [ACTActCod], [ActActItem], [AMovAreaCod], [AMovCosCod]) VALUES(@AMovCod, @AMovFec, @AMovTipo, @AMovObs, @AMovSubGrup, @ACTActCod, @ActActItem, @AMovAreaCod, @AMovCosCod)", GxErrorMask.GX_NOMASK,prmT006Y16)
           ,new CursorDef("T006Y17", "UPDATE [ACTMOVACTIVO] SET [AMovFec]=@AMovFec, [AMovTipo]=@AMovTipo, [AMovObs]=@AMovObs, [AMovSubGrup]=@AMovSubGrup, [ACTActCod]=@ACTActCod, [ActActItem]=@ActActItem, [AMovAreaCod]=@AMovAreaCod, [AMovCosCod]=@AMovCosCod  WHERE [AMovCod] = @AMovCod", GxErrorMask.GX_NOMASK,prmT006Y17)
           ,new CursorDef("T006Y18", "DELETE FROM [ACTMOVACTIVO]  WHERE [AMovCod] = @AMovCod", GxErrorMask.GX_NOMASK,prmT006Y18)
           ,new CursorDef("T006Y19", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y20", "SELECT [ACTAreaDsc] AS AMovAreaDsc FROM [ACTAREA] WHERE [ACTAreaCod] = @AMovAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y21", "SELECT [COSDsc] AS AMovCosDsc FROM [CBCOSTOS] WHERE [COSCod] = @AMovCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y22", "SELECT [AMovCod] FROM [ACTMOVACTIVO] ORDER BY [AMovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Y23", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Y23,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 10);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 10);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 10);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
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
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
