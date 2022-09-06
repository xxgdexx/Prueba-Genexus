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
   public class actbajaactivo : GXHttpHandler
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
            Form.Meta.addItem("description", "Baja de Activos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTABajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actbajaactivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actbajaactivo( IGxContext context )
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
            RenderHtmlCloseForm6U188( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Baja de Activos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTABajCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTABajCod_Internalname, "N° Baja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTABajCod_Internalname, A2106ACTABajCod, StringUtil.RTrim( context.localUtil.Format( A2106ACTABajCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTABajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTABajCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTABajFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTABajFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTABajFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTABajFec_Internalname, context.localUtil.Format(A2175ACTABajFec, "99/99/99"), context.localUtil.Format( A2175ACTABajFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTABajFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTABajFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_bitmap( context, edtACTABajFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTABajFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActDsc_Internalname, A2122ACTActDsc, StringUtil.RTrim( context.localUtil.Format( A2122ACTActDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTABajDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTABajDsc_Internalname, "Tipo de Baja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTABajDsc_Internalname, A2174ACTABajDsc, StringUtil.RTrim( context.localUtil.Format( A2174ACTABajDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTABajDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTABajDsc_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTBajGrupCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTBajGrupCod_Internalname, "- Componente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTBajGrupCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2179ACTBajGrupCod), 5, 0, ".", "")), StringUtil.LTrim( ((edtACTBajGrupCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2179ACTBajGrupCod), "ZZZZ9") : context.localUtil.Format( (decimal)(A2179ACTBajGrupCod), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTBajGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTBajGrupCod_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTClaCod_Internalname, A426ACTClaCod, StringUtil.RTrim( context.localUtil.Format( A426ACTClaCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTClaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTGrupCod_Internalname, A2103ACTGrupCod, StringUtil.RTrim( context.localUtil.Format( A2103ACTGrupCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTSGrupCod_Internalname, A2114ACTSGrupCod, StringUtil.RTrim( context.localUtil.Format( A2114ACTSGrupCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTABajObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTABajObs_Internalname, "Observaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtACTABajObs_Internalname, A2176ACTABajObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", 0, 1, edtACTABajObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2181ACTVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtACTVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2181ACTVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2181ACTVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2182ACTVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtACTVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2182ACTVouMes), "Z9") : context.localUtil.Format( (decimal)(A2182ACTVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTTasiCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTTasiCod_Internalname, "Tipo Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2180ACTTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2180ACTTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2180ACTTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTVouNum_Internalname, "N° Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTVouNum_Internalname, StringUtil.RTrim( A2183ACTVouNum), StringUtil.RTrim( context.localUtil.Format( A2183ACTVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTBajCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTBajCosto_Internalname, "Baja Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTBajCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A2177ACTBajCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTBajCosto_Enabled!=0) ? context.localUtil.Format( A2177ACTBajCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2177ACTBajCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTBajCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTBajCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTBajDepre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTBajDepre_Internalname, "Depreciación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTBajDepre_Internalname, StringUtil.LTrim( StringUtil.NToC( A2178ACTBajDepre, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTBajDepre_Enabled!=0) ? context.localUtil.Format( A2178ACTBajDepre, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2178ACTBajDepre, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTBajDepre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTBajDepre_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTBAJAACTIVO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTBAJAACTIVO.htm");
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
            Z2106ACTABajCod = cgiGet( "Z2106ACTABajCod");
            Z2175ACTABajFec = context.localUtil.CToD( cgiGet( "Z2175ACTABajFec"), 0);
            Z2174ACTABajDsc = cgiGet( "Z2174ACTABajDsc");
            Z2179ACTBajGrupCod = (int)(context.localUtil.CToN( cgiGet( "Z2179ACTBajGrupCod"), ".", ","));
            n2179ACTBajGrupCod = ((0==A2179ACTBajGrupCod) ? true : false);
            Z2181ACTVouAno = (short)(context.localUtil.CToN( cgiGet( "Z2181ACTVouAno"), ".", ","));
            Z2182ACTVouMes = (short)(context.localUtil.CToN( cgiGet( "Z2182ACTVouMes"), ".", ","));
            Z2180ACTTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z2180ACTTasiCod"), ".", ","));
            Z2183ACTVouNum = cgiGet( "Z2183ACTVouNum");
            Z2177ACTBajCosto = context.localUtil.CToN( cgiGet( "Z2177ACTBajCosto"), ".", ",");
            Z2178ACTBajDepre = context.localUtil.CToN( cgiGet( "Z2178ACTBajDepre"), ".", ",");
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2106ACTABajCod = cgiGet( edtACTABajCod_Internalname);
            AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
            if ( context.localUtil.VCDate( cgiGet( edtACTABajFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "ACTABAJFEC");
               AnyError = 1;
               GX_FocusControl = edtACTABajFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2175ACTABajFec = DateTime.MinValue;
               AssignAttri("", false, "A2175ACTABajFec", context.localUtil.Format(A2175ACTABajFec, "99/99/99"));
            }
            else
            {
               A2175ACTABajFec = context.localUtil.CToD( cgiGet( edtACTABajFec_Internalname), 2);
               AssignAttri("", false, "A2175ACTABajFec", context.localUtil.Format(A2175ACTABajFec, "99/99/99"));
            }
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2122ACTActDsc = cgiGet( edtACTActDsc_Internalname);
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            A2174ACTABajDsc = cgiGet( edtACTABajDsc_Internalname);
            AssignAttri("", false, "A2174ACTABajDsc", A2174ACTABajDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTBajGrupCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTBajGrupCod_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTBAJGRUPCOD");
               AnyError = 1;
               GX_FocusControl = edtACTBajGrupCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2179ACTBajGrupCod = 0;
               n2179ACTBajGrupCod = false;
               AssignAttri("", false, "A2179ACTBajGrupCod", StringUtil.LTrimStr( (decimal)(A2179ACTBajGrupCod), 5, 0));
            }
            else
            {
               A2179ACTBajGrupCod = (int)(context.localUtil.CToN( cgiGet( edtACTBajGrupCod_Internalname), ".", ","));
               n2179ACTBajGrupCod = false;
               AssignAttri("", false, "A2179ACTBajGrupCod", StringUtil.LTrimStr( (decimal)(A2179ACTBajGrupCod), 5, 0));
            }
            n2179ACTBajGrupCod = ((0==A2179ACTBajGrupCod) ? true : false);
            A426ACTClaCod = cgiGet( edtACTClaCod_Internalname);
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = cgiGet( edtACTGrupCod_Internalname);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = cgiGet( edtACTSGrupCod_Internalname);
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2176ACTABajObs = cgiGet( edtACTABajObs_Internalname);
            AssignAttri("", false, "A2176ACTABajObs", A2176ACTABajObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTVOUANO");
               AnyError = 1;
               GX_FocusControl = edtACTVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2181ACTVouAno = 0;
               AssignAttri("", false, "A2181ACTVouAno", StringUtil.LTrimStr( (decimal)(A2181ACTVouAno), 4, 0));
            }
            else
            {
               A2181ACTVouAno = (short)(context.localUtil.CToN( cgiGet( edtACTVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A2181ACTVouAno", StringUtil.LTrimStr( (decimal)(A2181ACTVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTVOUMES");
               AnyError = 1;
               GX_FocusControl = edtACTVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2182ACTVouMes = 0;
               AssignAttri("", false, "A2182ACTVouMes", StringUtil.LTrimStr( (decimal)(A2182ACTVouMes), 2, 0));
            }
            else
            {
               A2182ACTVouMes = (short)(context.localUtil.CToN( cgiGet( edtACTVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A2182ACTVouMes", StringUtil.LTrimStr( (decimal)(A2182ACTVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTTASICOD");
               AnyError = 1;
               GX_FocusControl = edtACTTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2180ACTTasiCod = 0;
               AssignAttri("", false, "A2180ACTTasiCod", StringUtil.LTrimStr( (decimal)(A2180ACTTasiCod), 6, 0));
            }
            else
            {
               A2180ACTTasiCod = (int)(context.localUtil.CToN( cgiGet( edtACTTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A2180ACTTasiCod", StringUtil.LTrimStr( (decimal)(A2180ACTTasiCod), 6, 0));
            }
            A2183ACTVouNum = cgiGet( edtACTVouNum_Internalname);
            AssignAttri("", false, "A2183ACTVouNum", A2183ACTVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTBajCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTBajCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTBAJCOSTO");
               AnyError = 1;
               GX_FocusControl = edtACTBajCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2177ACTBajCosto = 0;
               AssignAttri("", false, "A2177ACTBajCosto", StringUtil.LTrimStr( A2177ACTBajCosto, 15, 2));
            }
            else
            {
               A2177ACTBajCosto = context.localUtil.CToN( cgiGet( edtACTBajCosto_Internalname), ".", ",");
               AssignAttri("", false, "A2177ACTBajCosto", StringUtil.LTrimStr( A2177ACTBajCosto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTBajDepre_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTBajDepre_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTBAJDEPRE");
               AnyError = 1;
               GX_FocusControl = edtACTBajDepre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2178ACTBajDepre = 0;
               AssignAttri("", false, "A2178ACTBajDepre", StringUtil.LTrimStr( A2178ACTBajDepre, 15, 2));
            }
            else
            {
               A2178ACTBajDepre = context.localUtil.CToN( cgiGet( edtACTBajDepre_Internalname), ".", ",");
               AssignAttri("", false, "A2178ACTBajDepre", StringUtil.LTrimStr( A2178ACTBajDepre, 15, 2));
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
               A2106ACTABajCod = GetPar( "ACTABajCod");
               AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
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
               InitAll6U188( ) ;
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
         DisableAttributes6U188( ) ;
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

      protected void ResetCaption6U0( )
      {
      }

      protected void ZM6U188( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2175ACTABajFec = T006U3_A2175ACTABajFec[0];
               Z2174ACTABajDsc = T006U3_A2174ACTABajDsc[0];
               Z2179ACTBajGrupCod = T006U3_A2179ACTBajGrupCod[0];
               Z2181ACTVouAno = T006U3_A2181ACTVouAno[0];
               Z2182ACTVouMes = T006U3_A2182ACTVouMes[0];
               Z2180ACTTasiCod = T006U3_A2180ACTTasiCod[0];
               Z2183ACTVouNum = T006U3_A2183ACTVouNum[0];
               Z2177ACTBajCosto = T006U3_A2177ACTBajCosto[0];
               Z2178ACTBajDepre = T006U3_A2178ACTBajDepre[0];
               Z2100ACTActCod = T006U3_A2100ACTActCod[0];
               Z2104ActActItem = T006U3_A2104ActActItem[0];
            }
            else
            {
               Z2175ACTABajFec = A2175ACTABajFec;
               Z2174ACTABajDsc = A2174ACTABajDsc;
               Z2179ACTBajGrupCod = A2179ACTBajGrupCod;
               Z2181ACTVouAno = A2181ACTVouAno;
               Z2182ACTVouMes = A2182ACTVouMes;
               Z2180ACTTasiCod = A2180ACTTasiCod;
               Z2183ACTVouNum = A2183ACTVouNum;
               Z2177ACTBajCosto = A2177ACTBajCosto;
               Z2178ACTBajDepre = A2178ACTBajDepre;
               Z2100ACTActCod = A2100ACTActCod;
               Z2104ActActItem = A2104ActActItem;
            }
         }
         if ( GX_JID == -2 )
         {
            Z2106ACTABajCod = A2106ACTABajCod;
            Z2175ACTABajFec = A2175ACTABajFec;
            Z2174ACTABajDsc = A2174ACTABajDsc;
            Z2179ACTBajGrupCod = A2179ACTBajGrupCod;
            Z2176ACTABajObs = A2176ACTABajObs;
            Z2181ACTVouAno = A2181ACTVouAno;
            Z2182ACTVouMes = A2182ACTVouMes;
            Z2180ACTTasiCod = A2180ACTTasiCod;
            Z2183ACTVouNum = A2183ACTVouNum;
            Z2177ACTBajCosto = A2177ACTBajCosto;
            Z2178ACTBajDepre = A2178ACTBajDepre;
            Z2100ACTActCod = A2100ACTActCod;
            Z2104ActActItem = A2104ActActItem;
            Z2122ACTActDsc = A2122ACTActDsc;
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
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

      protected void Load6U188( )
      {
         /* Using cursor T006U6 */
         pr_default.execute(4, new Object[] {A2106ACTABajCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound188 = 1;
            A2175ACTABajFec = T006U6_A2175ACTABajFec[0];
            AssignAttri("", false, "A2175ACTABajFec", context.localUtil.Format(A2175ACTABajFec, "99/99/99"));
            A2122ACTActDsc = T006U6_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2174ACTABajDsc = T006U6_A2174ACTABajDsc[0];
            AssignAttri("", false, "A2174ACTABajDsc", A2174ACTABajDsc);
            A2179ACTBajGrupCod = T006U6_A2179ACTBajGrupCod[0];
            n2179ACTBajGrupCod = T006U6_n2179ACTBajGrupCod[0];
            AssignAttri("", false, "A2179ACTBajGrupCod", StringUtil.LTrimStr( (decimal)(A2179ACTBajGrupCod), 5, 0));
            A2176ACTABajObs = T006U6_A2176ACTABajObs[0];
            AssignAttri("", false, "A2176ACTABajObs", A2176ACTABajObs);
            A2181ACTVouAno = T006U6_A2181ACTVouAno[0];
            AssignAttri("", false, "A2181ACTVouAno", StringUtil.LTrimStr( (decimal)(A2181ACTVouAno), 4, 0));
            A2182ACTVouMes = T006U6_A2182ACTVouMes[0];
            AssignAttri("", false, "A2182ACTVouMes", StringUtil.LTrimStr( (decimal)(A2182ACTVouMes), 2, 0));
            A2180ACTTasiCod = T006U6_A2180ACTTasiCod[0];
            AssignAttri("", false, "A2180ACTTasiCod", StringUtil.LTrimStr( (decimal)(A2180ACTTasiCod), 6, 0));
            A2183ACTVouNum = T006U6_A2183ACTVouNum[0];
            AssignAttri("", false, "A2183ACTVouNum", A2183ACTVouNum);
            A2177ACTBajCosto = T006U6_A2177ACTBajCosto[0];
            AssignAttri("", false, "A2177ACTBajCosto", StringUtil.LTrimStr( A2177ACTBajCosto, 15, 2));
            A2178ACTBajDepre = T006U6_A2178ACTBajDepre[0];
            AssignAttri("", false, "A2178ACTBajDepre", StringUtil.LTrimStr( A2178ACTBajDepre, 15, 2));
            A2100ACTActCod = T006U6_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006U6_A2104ActActItem[0];
            n2104ActActItem = T006U6_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            A426ACTClaCod = T006U6_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006U6_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = T006U6_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            ZM6U188( -2) ;
         }
         pr_default.close(4);
         OnLoadActions6U188( ) ;
      }

      protected void OnLoadActions6U188( )
      {
      }

      protected void CheckExtendedTable6U188( )
      {
         nIsDirty_188 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2175ACTABajFec) || ( DateTimeUtil.ResetTime ( A2175ACTABajFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "ACTABAJFEC");
            AnyError = 1;
            GX_FocusControl = edtACTABajFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006U4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006U4_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A426ACTClaCod = T006U4_A426ACTClaCod[0];
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = T006U4_A2103ACTGrupCod[0];
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         pr_default.close(2);
         /* Using cursor T006U5 */
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
         A2114ACTSGrupCod = T006U5_A2114ACTSGrupCod[0];
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors6U188( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A2100ACTActCod )
      {
         /* Using cursor T006U7 */
         pr_default.execute(5, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006U7_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A426ACTClaCod = T006U7_A426ACTClaCod[0];
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = T006U7_A2103ACTGrupCod[0];
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2122ACTActDsc)+"\""+","+"\""+GXUtil.EncodeJSConstant( A426ACTClaCod)+"\""+","+"\""+GXUtil.EncodeJSConstant( A2103ACTGrupCod)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( string A2100ACTActCod ,
                               string A2104ActActItem )
      {
         /* Using cursor T006U8 */
         pr_default.execute(6, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2100ACTActCod)) || String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ) )
            {
               GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
               AnyError = 1;
               GX_FocusControl = edtACTActCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2114ACTSGrupCod = T006U8_A2114ACTSGrupCod[0];
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2114ACTSGrupCod)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey6U188( )
      {
         /* Using cursor T006U9 */
         pr_default.execute(7, new Object[] {A2106ACTABajCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound188 = 1;
         }
         else
         {
            RcdFound188 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006U3 */
         pr_default.execute(1, new Object[] {A2106ACTABajCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6U188( 2) ;
            RcdFound188 = 1;
            A2106ACTABajCod = T006U3_A2106ACTABajCod[0];
            AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
            A2175ACTABajFec = T006U3_A2175ACTABajFec[0];
            AssignAttri("", false, "A2175ACTABajFec", context.localUtil.Format(A2175ACTABajFec, "99/99/99"));
            A2174ACTABajDsc = T006U3_A2174ACTABajDsc[0];
            AssignAttri("", false, "A2174ACTABajDsc", A2174ACTABajDsc);
            A2179ACTBajGrupCod = T006U3_A2179ACTBajGrupCod[0];
            n2179ACTBajGrupCod = T006U3_n2179ACTBajGrupCod[0];
            AssignAttri("", false, "A2179ACTBajGrupCod", StringUtil.LTrimStr( (decimal)(A2179ACTBajGrupCod), 5, 0));
            A2176ACTABajObs = T006U3_A2176ACTABajObs[0];
            AssignAttri("", false, "A2176ACTABajObs", A2176ACTABajObs);
            A2181ACTVouAno = T006U3_A2181ACTVouAno[0];
            AssignAttri("", false, "A2181ACTVouAno", StringUtil.LTrimStr( (decimal)(A2181ACTVouAno), 4, 0));
            A2182ACTVouMes = T006U3_A2182ACTVouMes[0];
            AssignAttri("", false, "A2182ACTVouMes", StringUtil.LTrimStr( (decimal)(A2182ACTVouMes), 2, 0));
            A2180ACTTasiCod = T006U3_A2180ACTTasiCod[0];
            AssignAttri("", false, "A2180ACTTasiCod", StringUtil.LTrimStr( (decimal)(A2180ACTTasiCod), 6, 0));
            A2183ACTVouNum = T006U3_A2183ACTVouNum[0];
            AssignAttri("", false, "A2183ACTVouNum", A2183ACTVouNum);
            A2177ACTBajCosto = T006U3_A2177ACTBajCosto[0];
            AssignAttri("", false, "A2177ACTBajCosto", StringUtil.LTrimStr( A2177ACTBajCosto, 15, 2));
            A2178ACTBajDepre = T006U3_A2178ACTBajDepre[0];
            AssignAttri("", false, "A2178ACTBajDepre", StringUtil.LTrimStr( A2178ACTBajDepre, 15, 2));
            A2100ACTActCod = T006U3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006U3_A2104ActActItem[0];
            n2104ActActItem = T006U3_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            Z2106ACTABajCod = A2106ACTABajCod;
            sMode188 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6U188( ) ;
            if ( AnyError == 1 )
            {
               RcdFound188 = 0;
               InitializeNonKey6U188( ) ;
            }
            Gx_mode = sMode188;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound188 = 0;
            InitializeNonKey6U188( ) ;
            sMode188 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode188;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6U188( ) ;
         if ( RcdFound188 == 0 )
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
         RcdFound188 = 0;
         /* Using cursor T006U10 */
         pr_default.execute(8, new Object[] {A2106ACTABajCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006U10_A2106ACTABajCod[0], A2106ACTABajCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006U10_A2106ACTABajCod[0], A2106ACTABajCod) > 0 ) ) )
            {
               A2106ACTABajCod = T006U10_A2106ACTABajCod[0];
               AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
               RcdFound188 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound188 = 0;
         /* Using cursor T006U11 */
         pr_default.execute(9, new Object[] {A2106ACTABajCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006U11_A2106ACTABajCod[0], A2106ACTABajCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006U11_A2106ACTABajCod[0], A2106ACTABajCod) < 0 ) ) )
            {
               A2106ACTABajCod = T006U11_A2106ACTABajCod[0];
               AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
               RcdFound188 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6U188( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTABajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6U188( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound188 == 1 )
            {
               if ( StringUtil.StrCmp(A2106ACTABajCod, Z2106ACTABajCod) != 0 )
               {
                  A2106ACTABajCod = Z2106ACTABajCod;
                  AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTABAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTABajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTABajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6U188( ) ;
                  GX_FocusControl = edtACTABajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2106ACTABajCod, Z2106ACTABajCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTABajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6U188( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTABAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtACTABajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTABajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6U188( ) ;
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
         if ( StringUtil.StrCmp(A2106ACTABajCod, Z2106ACTABajCod) != 0 )
         {
            A2106ACTABajCod = Z2106ACTABajCod;
            AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTABAJCOD");
            AnyError = 1;
            GX_FocusControl = edtACTABajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTABajCod_Internalname;
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
         if ( RcdFound188 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTABAJCOD");
            AnyError = 1;
            GX_FocusControl = edtACTABajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTABajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6U188( ) ;
         if ( RcdFound188 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTABajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6U188( ) ;
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
         if ( RcdFound188 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTABajFec_Internalname;
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
         if ( RcdFound188 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTABajFec_Internalname;
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
         ScanStart6U188( ) ;
         if ( RcdFound188 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound188 != 0 )
            {
               ScanNext6U188( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTABajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6U188( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6U188( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006U2 */
            pr_default.execute(0, new Object[] {A2106ACTABajCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTBAJAACTIVO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2175ACTABajFec ) != DateTimeUtil.ResetTime ( T006U2_A2175ACTABajFec[0] ) ) || ( StringUtil.StrCmp(Z2174ACTABajDsc, T006U2_A2174ACTABajDsc[0]) != 0 ) || ( Z2179ACTBajGrupCod != T006U2_A2179ACTBajGrupCod[0] ) || ( Z2181ACTVouAno != T006U2_A2181ACTVouAno[0] ) || ( Z2182ACTVouMes != T006U2_A2182ACTVouMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2180ACTTasiCod != T006U2_A2180ACTTasiCod[0] ) || ( StringUtil.StrCmp(Z2183ACTVouNum, T006U2_A2183ACTVouNum[0]) != 0 ) || ( Z2177ACTBajCosto != T006U2_A2177ACTBajCosto[0] ) || ( Z2178ACTBajDepre != T006U2_A2178ACTBajDepre[0] ) || ( StringUtil.StrCmp(Z2100ACTActCod, T006U2_A2100ACTActCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2104ActActItem, T006U2_A2104ActActItem[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2175ACTABajFec ) != DateTimeUtil.ResetTime ( T006U2_A2175ACTABajFec[0] ) )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTABajFec");
                  GXUtil.WriteLogRaw("Old: ",Z2175ACTABajFec);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2175ACTABajFec[0]);
               }
               if ( StringUtil.StrCmp(Z2174ACTABajDsc, T006U2_A2174ACTABajDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTABajDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2174ACTABajDsc);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2174ACTABajDsc[0]);
               }
               if ( Z2179ACTBajGrupCod != T006U2_A2179ACTBajGrupCod[0] )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTBajGrupCod");
                  GXUtil.WriteLogRaw("Old: ",Z2179ACTBajGrupCod);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2179ACTBajGrupCod[0]);
               }
               if ( Z2181ACTVouAno != T006U2_A2181ACTVouAno[0] )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z2181ACTVouAno);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2181ACTVouAno[0]);
               }
               if ( Z2182ACTVouMes != T006U2_A2182ACTVouMes[0] )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z2182ACTVouMes);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2182ACTVouMes[0]);
               }
               if ( Z2180ACTTasiCod != T006U2_A2180ACTTasiCod[0] )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z2180ACTTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2180ACTTasiCod[0]);
               }
               if ( StringUtil.StrCmp(Z2183ACTVouNum, T006U2_A2183ACTVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z2183ACTVouNum);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2183ACTVouNum[0]);
               }
               if ( Z2177ACTBajCosto != T006U2_A2177ACTBajCosto[0] )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTBajCosto");
                  GXUtil.WriteLogRaw("Old: ",Z2177ACTBajCosto);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2177ACTBajCosto[0]);
               }
               if ( Z2178ACTBajDepre != T006U2_A2178ACTBajDepre[0] )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTBajDepre");
                  GXUtil.WriteLogRaw("Old: ",Z2178ACTBajDepre);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2178ACTBajDepre[0]);
               }
               if ( StringUtil.StrCmp(Z2100ACTActCod, T006U2_A2100ACTActCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ACTActCod");
                  GXUtil.WriteLogRaw("Old: ",Z2100ACTActCod);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2100ACTActCod[0]);
               }
               if ( StringUtil.StrCmp(Z2104ActActItem, T006U2_A2104ActActItem[0]) != 0 )
               {
                  GXUtil.WriteLog("actbajaactivo:[seudo value changed for attri]"+"ActActItem");
                  GXUtil.WriteLogRaw("Old: ",Z2104ActActItem);
                  GXUtil.WriteLogRaw("Current: ",T006U2_A2104ActActItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTBAJAACTIVO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6U188( )
      {
         BeforeValidate6U188( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6U188( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6U188( 0) ;
            CheckOptimisticConcurrency6U188( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6U188( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6U188( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006U12 */
                     pr_default.execute(10, new Object[] {A2106ACTABajCod, A2175ACTABajFec, A2174ACTABajDsc, n2179ACTBajGrupCod, A2179ACTBajGrupCod, A2176ACTABajObs, A2181ACTVouAno, A2182ACTVouMes, A2180ACTTasiCod, A2183ACTVouNum, A2177ACTBajCosto, A2178ACTBajDepre, A2100ACTActCod, n2104ActActItem, A2104ActActItem});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTBAJAACTIVO");
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
                           ResetCaption6U0( ) ;
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
               Load6U188( ) ;
            }
            EndLevel6U188( ) ;
         }
         CloseExtendedTableCursors6U188( ) ;
      }

      protected void Update6U188( )
      {
         BeforeValidate6U188( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6U188( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6U188( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6U188( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6U188( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006U13 */
                     pr_default.execute(11, new Object[] {A2175ACTABajFec, A2174ACTABajDsc, n2179ACTBajGrupCod, A2179ACTBajGrupCod, A2176ACTABajObs, A2181ACTVouAno, A2182ACTVouMes, A2180ACTTasiCod, A2183ACTVouNum, A2177ACTBajCosto, A2178ACTBajDepre, A2100ACTActCod, n2104ActActItem, A2104ActActItem, A2106ACTABajCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTBAJAACTIVO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTBAJAACTIVO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6U188( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6U0( ) ;
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
            EndLevel6U188( ) ;
         }
         CloseExtendedTableCursors6U188( ) ;
      }

      protected void DeferredUpdate6U188( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6U188( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6U188( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6U188( ) ;
            AfterConfirm6U188( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6U188( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006U14 */
                  pr_default.execute(12, new Object[] {A2106ACTABajCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTBAJAACTIVO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound188 == 0 )
                        {
                           InitAll6U188( ) ;
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
                        ResetCaption6U0( ) ;
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
         sMode188 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6U188( ) ;
         Gx_mode = sMode188;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6U188( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006U15 */
            pr_default.execute(13, new Object[] {A2100ACTActCod});
            A2122ACTActDsc = T006U15_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A426ACTClaCod = T006U15_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006U15_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            pr_default.close(13);
            /* Using cursor T006U16 */
            pr_default.execute(14, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
            A2114ACTSGrupCod = T006U16_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            pr_default.close(14);
         }
      }

      protected void EndLevel6U188( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6U188( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("actbajaactivo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("actbajaactivo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6U188( )
      {
         /* Using cursor T006U17 */
         pr_default.execute(15);
         RcdFound188 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound188 = 1;
            A2106ACTABajCod = T006U17_A2106ACTABajCod[0];
            AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6U188( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound188 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound188 = 1;
            A2106ACTABajCod = T006U17_A2106ACTABajCod[0];
            AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
         }
      }

      protected void ScanEnd6U188( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm6U188( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6U188( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6U188( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6U188( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6U188( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6U188( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6U188( )
      {
         edtACTABajCod_Enabled = 0;
         AssignProp("", false, edtACTABajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTABajCod_Enabled), 5, 0), true);
         edtACTABajFec_Enabled = 0;
         AssignProp("", false, edtACTABajFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTABajFec_Enabled), 5, 0), true);
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtACTActDsc_Enabled = 0;
         AssignProp("", false, edtACTActDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDsc_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtACTABajDsc_Enabled = 0;
         AssignProp("", false, edtACTABajDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTABajDsc_Enabled), 5, 0), true);
         edtACTBajGrupCod_Enabled = 0;
         AssignProp("", false, edtACTBajGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTBajGrupCod_Enabled), 5, 0), true);
         edtACTClaCod_Enabled = 0;
         AssignProp("", false, edtACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaCod_Enabled), 5, 0), true);
         edtACTGrupCod_Enabled = 0;
         AssignProp("", false, edtACTGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupCod_Enabled), 5, 0), true);
         edtACTSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupCod_Enabled), 5, 0), true);
         edtACTABajObs_Enabled = 0;
         AssignProp("", false, edtACTABajObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTABajObs_Enabled), 5, 0), true);
         edtACTVouAno_Enabled = 0;
         AssignProp("", false, edtACTVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTVouAno_Enabled), 5, 0), true);
         edtACTVouMes_Enabled = 0;
         AssignProp("", false, edtACTVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTVouMes_Enabled), 5, 0), true);
         edtACTTasiCod_Enabled = 0;
         AssignProp("", false, edtACTTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTTasiCod_Enabled), 5, 0), true);
         edtACTVouNum_Enabled = 0;
         AssignProp("", false, edtACTVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTVouNum_Enabled), 5, 0), true);
         edtACTBajCosto_Enabled = 0;
         AssignProp("", false, edtACTBajCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTBajCosto_Enabled), 5, 0), true);
         edtACTBajDepre_Enabled = 0;
         AssignProp("", false, edtACTBajDepre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTBajDepre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6U188( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6U0( )
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
         context.SendWebValue( "Baja de Activos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026506", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actbajaactivo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2106ACTABajCod", Z2106ACTABajCod);
         GxWebStd.gx_hidden_field( context, "Z2175ACTABajFec", context.localUtil.DToC( Z2175ACTABajFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2174ACTABajDsc", Z2174ACTABajDsc);
         GxWebStd.gx_hidden_field( context, "Z2179ACTBajGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2179ACTBajGrupCod), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2181ACTVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2181ACTVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2182ACTVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2182ACTVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2180ACTTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2180ACTTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2183ACTVouNum", StringUtil.RTrim( Z2183ACTVouNum));
         GxWebStd.gx_hidden_field( context, "Z2177ACTBajCosto", StringUtil.LTrim( StringUtil.NToC( Z2177ACTBajCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2178ACTBajDepre", StringUtil.LTrim( StringUtil.NToC( Z2178ACTBajDepre, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm6U188( )
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
         return "ACTBAJAACTIVO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Baja de Activos" ;
      }

      protected void InitializeNonKey6U188( )
      {
         A2175ACTABajFec = DateTime.MinValue;
         AssignAttri("", false, "A2175ACTABajFec", context.localUtil.Format(A2175ACTABajFec, "99/99/99"));
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2122ACTActDsc = "";
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A2104ActActItem = "";
         n2104ActActItem = false;
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
         A2174ACTABajDsc = "";
         AssignAttri("", false, "A2174ACTABajDsc", A2174ACTABajDsc);
         A2179ACTBajGrupCod = 0;
         n2179ACTBajGrupCod = false;
         AssignAttri("", false, "A2179ACTBajGrupCod", StringUtil.LTrimStr( (decimal)(A2179ACTBajGrupCod), 5, 0));
         n2179ACTBajGrupCod = ((0==A2179ACTBajGrupCod) ? true : false);
         A426ACTClaCod = "";
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = "";
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         A2114ACTSGrupCod = "";
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         A2176ACTABajObs = "";
         AssignAttri("", false, "A2176ACTABajObs", A2176ACTABajObs);
         A2181ACTVouAno = 0;
         AssignAttri("", false, "A2181ACTVouAno", StringUtil.LTrimStr( (decimal)(A2181ACTVouAno), 4, 0));
         A2182ACTVouMes = 0;
         AssignAttri("", false, "A2182ACTVouMes", StringUtil.LTrimStr( (decimal)(A2182ACTVouMes), 2, 0));
         A2180ACTTasiCod = 0;
         AssignAttri("", false, "A2180ACTTasiCod", StringUtil.LTrimStr( (decimal)(A2180ACTTasiCod), 6, 0));
         A2183ACTVouNum = "";
         AssignAttri("", false, "A2183ACTVouNum", A2183ACTVouNum);
         A2177ACTBajCosto = 0;
         AssignAttri("", false, "A2177ACTBajCosto", StringUtil.LTrimStr( A2177ACTBajCosto, 15, 2));
         A2178ACTBajDepre = 0;
         AssignAttri("", false, "A2178ACTBajDepre", StringUtil.LTrimStr( A2178ACTBajDepre, 15, 2));
         Z2175ACTABajFec = DateTime.MinValue;
         Z2174ACTABajDsc = "";
         Z2179ACTBajGrupCod = 0;
         Z2181ACTVouAno = 0;
         Z2182ACTVouMes = 0;
         Z2180ACTTasiCod = 0;
         Z2183ACTVouNum = "";
         Z2177ACTBajCosto = 0;
         Z2178ACTBajDepre = 0;
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
      }

      protected void InitAll6U188( )
      {
         A2106ACTABajCod = "";
         AssignAttri("", false, "A2106ACTABajCod", A2106ACTABajCod);
         InitializeNonKey6U188( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265017", true, true);
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
         context.AddJavascriptSource("actbajaactivo.js", "?202281810265017", false, true);
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
         edtACTABajCod_Internalname = "ACTABAJCOD";
         edtACTABajFec_Internalname = "ACTABAJFEC";
         edtACTActCod_Internalname = "ACTACTCOD";
         edtACTActDsc_Internalname = "ACTACTDSC";
         edtActActItem_Internalname = "ACTACTITEM";
         edtACTABajDsc_Internalname = "ACTABAJDSC";
         edtACTBajGrupCod_Internalname = "ACTBAJGRUPCOD";
         edtACTClaCod_Internalname = "ACTCLACOD";
         edtACTGrupCod_Internalname = "ACTGRUPCOD";
         edtACTSGrupCod_Internalname = "ACTSGRUPCOD";
         edtACTABajObs_Internalname = "ACTABAJOBS";
         edtACTVouAno_Internalname = "ACTVOUANO";
         edtACTVouMes_Internalname = "ACTVOUMES";
         edtACTTasiCod_Internalname = "ACTTASICOD";
         edtACTVouNum_Internalname = "ACTVOUNUM";
         edtACTBajCosto_Internalname = "ACTBAJCOSTO";
         edtACTBajDepre_Internalname = "ACTBAJDEPRE";
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
         edtACTBajDepre_Jsonclick = "";
         edtACTBajDepre_Enabled = 1;
         edtACTBajCosto_Jsonclick = "";
         edtACTBajCosto_Enabled = 1;
         edtACTVouNum_Jsonclick = "";
         edtACTVouNum_Enabled = 1;
         edtACTTasiCod_Jsonclick = "";
         edtACTTasiCod_Enabled = 1;
         edtACTVouMes_Jsonclick = "";
         edtACTVouMes_Enabled = 1;
         edtACTVouAno_Jsonclick = "";
         edtACTVouAno_Enabled = 1;
         edtACTABajObs_Enabled = 1;
         edtACTSGrupCod_Jsonclick = "";
         edtACTSGrupCod_Enabled = 0;
         edtACTGrupCod_Jsonclick = "";
         edtACTGrupCod_Enabled = 0;
         edtACTClaCod_Jsonclick = "";
         edtACTClaCod_Enabled = 0;
         edtACTBajGrupCod_Jsonclick = "";
         edtACTBajGrupCod_Enabled = 1;
         edtACTABajDsc_Jsonclick = "";
         edtACTABajDsc_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActDsc_Jsonclick = "";
         edtACTActDsc_Enabled = 0;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
         edtACTABajFec_Jsonclick = "";
         edtACTABajFec_Enabled = 1;
         edtACTABajCod_Jsonclick = "";
         edtACTABajCod_Enabled = 1;
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
         GX_FocusControl = edtACTABajFec_Internalname;
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

      public void Valid_Actabajcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2175ACTABajFec", context.localUtil.Format(A2175ACTABajFec, "99/99/99"));
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         AssignAttri("", false, "A2174ACTABajDsc", A2174ACTABajDsc);
         AssignAttri("", false, "A2179ACTBajGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2179ACTBajGrupCod), 5, 0, ".", "")));
         AssignAttri("", false, "A2176ACTABajObs", A2176ACTABajObs);
         AssignAttri("", false, "A2181ACTVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2181ACTVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A2182ACTVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2182ACTVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A2180ACTTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2180ACTTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2183ACTVouNum", StringUtil.RTrim( A2183ACTVouNum));
         AssignAttri("", false, "A2177ACTBajCosto", StringUtil.LTrim( StringUtil.NToC( A2177ACTBajCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A2178ACTBajDepre", StringUtil.LTrim( StringUtil.NToC( A2178ACTBajDepre, 15, 2, ".", "")));
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2106ACTABajCod", Z2106ACTABajCod);
         GxWebStd.gx_hidden_field( context, "Z2175ACTABajFec", context.localUtil.Format(Z2175ACTABajFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2174ACTABajDsc", Z2174ACTABajDsc);
         GxWebStd.gx_hidden_field( context, "Z2179ACTBajGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2179ACTBajGrupCod), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2176ACTABajObs", Z2176ACTABajObs);
         GxWebStd.gx_hidden_field( context, "Z2181ACTVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2181ACTVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2182ACTVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2182ACTVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2180ACTTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2180ACTTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2183ACTVouNum", StringUtil.RTrim( Z2183ACTVouNum));
         GxWebStd.gx_hidden_field( context, "Z2177ACTBajCosto", StringUtil.LTrim( StringUtil.NToC( Z2177ACTBajCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2178ACTBajDepre", StringUtil.LTrim( StringUtil.NToC( Z2178ACTBajDepre, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actactcod( )
      {
         /* Using cursor T006U15 */
         pr_default.execute(13, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         A2122ACTActDsc = T006U15_A2122ACTActDsc[0];
         A426ACTClaCod = T006U15_A426ACTClaCod[0];
         A2103ACTGrupCod = T006U15_A2103ACTGrupCod[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
      }

      public void Valid_Actactitem( )
      {
         n2104ActActItem = false;
         /* Using cursor T006U16 */
         pr_default.execute(14, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2100ACTActCod)) || String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ) )
            {
               GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
               AnyError = 1;
               GX_FocusControl = edtACTActCod_Internalname;
            }
         }
         A2114ACTSGrupCod = T006U16_A2114ACTSGrupCod[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
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
         setEventMetadata("VALID_ACTABAJCOD","{handler:'Valid_Actabajcod',iparms:[{av:'A2106ACTABajCod',fld:'ACTABAJCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTABAJCOD",",oparms:[{av:'A2175ACTABajFec',fld:'ACTABAJFEC',pic:''},{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'A2174ACTABajDsc',fld:'ACTABAJDSC',pic:''},{av:'A2179ACTBajGrupCod',fld:'ACTBAJGRUPCOD',pic:'ZZZZ9'},{av:'A2176ACTABajObs',fld:'ACTABAJOBS',pic:''},{av:'A2181ACTVouAno',fld:'ACTVOUANO',pic:'ZZZ9'},{av:'A2182ACTVouMes',fld:'ACTVOUMES',pic:'Z9'},{av:'A2180ACTTasiCod',fld:'ACTTASICOD',pic:'ZZZZZ9'},{av:'A2183ACTVouNum',fld:'ACTVOUNUM',pic:''},{av:'A2177ACTBajCosto',fld:'ACTBAJCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2178ACTBajDepre',fld:'ACTBAJDEPRE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2106ACTABajCod'},{av:'Z2175ACTABajFec'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2174ACTABajDsc'},{av:'Z2179ACTBajGrupCod'},{av:'Z2176ACTABajObs'},{av:'Z2181ACTVouAno'},{av:'Z2182ACTVouMes'},{av:'Z2180ACTTasiCod'},{av:'Z2183ACTVouNum'},{av:'Z2177ACTBajCosto'},{av:'Z2178ACTBajDepre'},{av:'Z2122ACTActDsc'},{av:'Z426ACTClaCod'},{av:'Z2103ACTGrupCod'},{av:'Z2114ACTSGrupCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTABAJFEC","{handler:'Valid_Actabajfec',iparms:[]");
         setEventMetadata("VALID_ACTABAJFEC",",oparms:[]}");
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("VALID_ACTACTITEM","{handler:'Valid_Actactitem',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTACTITEM",",oparms:[{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''}]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2106ACTABajCod = "";
         Z2175ACTABajFec = DateTime.MinValue;
         Z2174ACTABajDsc = "";
         Z2183ACTVouNum = "";
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
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
         A2106ACTABajCod = "";
         A2175ACTABajFec = DateTime.MinValue;
         A2122ACTActDsc = "";
         A2174ACTABajDsc = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2114ACTSGrupCod = "";
         A2176ACTABajObs = "";
         A2183ACTVouNum = "";
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
         Z2176ACTABajObs = "";
         Z2122ACTActDsc = "";
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2114ACTSGrupCod = "";
         T006U6_A2106ACTABajCod = new string[] {""} ;
         T006U6_A2175ACTABajFec = new DateTime[] {DateTime.MinValue} ;
         T006U6_A2122ACTActDsc = new string[] {""} ;
         T006U6_A2174ACTABajDsc = new string[] {""} ;
         T006U6_A2179ACTBajGrupCod = new int[1] ;
         T006U6_n2179ACTBajGrupCod = new bool[] {false} ;
         T006U6_A2176ACTABajObs = new string[] {""} ;
         T006U6_A2181ACTVouAno = new short[1] ;
         T006U6_A2182ACTVouMes = new short[1] ;
         T006U6_A2180ACTTasiCod = new int[1] ;
         T006U6_A2183ACTVouNum = new string[] {""} ;
         T006U6_A2177ACTBajCosto = new decimal[1] ;
         T006U6_A2178ACTBajDepre = new decimal[1] ;
         T006U6_A2100ACTActCod = new string[] {""} ;
         T006U6_A2104ActActItem = new string[] {""} ;
         T006U6_n2104ActActItem = new bool[] {false} ;
         T006U6_A426ACTClaCod = new string[] {""} ;
         T006U6_A2103ACTGrupCod = new string[] {""} ;
         T006U6_A2114ACTSGrupCod = new string[] {""} ;
         T006U4_A2122ACTActDsc = new string[] {""} ;
         T006U4_A426ACTClaCod = new string[] {""} ;
         T006U4_A2103ACTGrupCod = new string[] {""} ;
         T006U5_A2114ACTSGrupCod = new string[] {""} ;
         T006U7_A2122ACTActDsc = new string[] {""} ;
         T006U7_A426ACTClaCod = new string[] {""} ;
         T006U7_A2103ACTGrupCod = new string[] {""} ;
         T006U8_A2114ACTSGrupCod = new string[] {""} ;
         T006U9_A2106ACTABajCod = new string[] {""} ;
         T006U3_A2106ACTABajCod = new string[] {""} ;
         T006U3_A2175ACTABajFec = new DateTime[] {DateTime.MinValue} ;
         T006U3_A2174ACTABajDsc = new string[] {""} ;
         T006U3_A2179ACTBajGrupCod = new int[1] ;
         T006U3_n2179ACTBajGrupCod = new bool[] {false} ;
         T006U3_A2176ACTABajObs = new string[] {""} ;
         T006U3_A2181ACTVouAno = new short[1] ;
         T006U3_A2182ACTVouMes = new short[1] ;
         T006U3_A2180ACTTasiCod = new int[1] ;
         T006U3_A2183ACTVouNum = new string[] {""} ;
         T006U3_A2177ACTBajCosto = new decimal[1] ;
         T006U3_A2178ACTBajDepre = new decimal[1] ;
         T006U3_A2100ACTActCod = new string[] {""} ;
         T006U3_A2104ActActItem = new string[] {""} ;
         T006U3_n2104ActActItem = new bool[] {false} ;
         sMode188 = "";
         T006U10_A2106ACTABajCod = new string[] {""} ;
         T006U11_A2106ACTABajCod = new string[] {""} ;
         T006U2_A2106ACTABajCod = new string[] {""} ;
         T006U2_A2175ACTABajFec = new DateTime[] {DateTime.MinValue} ;
         T006U2_A2174ACTABajDsc = new string[] {""} ;
         T006U2_A2179ACTBajGrupCod = new int[1] ;
         T006U2_n2179ACTBajGrupCod = new bool[] {false} ;
         T006U2_A2176ACTABajObs = new string[] {""} ;
         T006U2_A2181ACTVouAno = new short[1] ;
         T006U2_A2182ACTVouMes = new short[1] ;
         T006U2_A2180ACTTasiCod = new int[1] ;
         T006U2_A2183ACTVouNum = new string[] {""} ;
         T006U2_A2177ACTBajCosto = new decimal[1] ;
         T006U2_A2178ACTBajDepre = new decimal[1] ;
         T006U2_A2100ACTActCod = new string[] {""} ;
         T006U2_A2104ActActItem = new string[] {""} ;
         T006U2_n2104ActActItem = new bool[] {false} ;
         T006U15_A2122ACTActDsc = new string[] {""} ;
         T006U15_A426ACTClaCod = new string[] {""} ;
         T006U15_A2103ACTGrupCod = new string[] {""} ;
         T006U16_A2114ACTSGrupCod = new string[] {""} ;
         T006U17_A2106ACTABajCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2106ACTABajCod = "";
         ZZ2175ACTABajFec = DateTime.MinValue;
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2174ACTABajDsc = "";
         ZZ2176ACTABajObs = "";
         ZZ2183ACTVouNum = "";
         ZZ2122ACTActDsc = "";
         ZZ426ACTClaCod = "";
         ZZ2103ACTGrupCod = "";
         ZZ2114ACTSGrupCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actbajaactivo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actbajaactivo__default(),
            new Object[][] {
                new Object[] {
               T006U2_A2106ACTABajCod, T006U2_A2175ACTABajFec, T006U2_A2174ACTABajDsc, T006U2_A2179ACTBajGrupCod, T006U2_n2179ACTBajGrupCod, T006U2_A2176ACTABajObs, T006U2_A2181ACTVouAno, T006U2_A2182ACTVouMes, T006U2_A2180ACTTasiCod, T006U2_A2183ACTVouNum,
               T006U2_A2177ACTBajCosto, T006U2_A2178ACTBajDepre, T006U2_A2100ACTActCod, T006U2_A2104ActActItem, T006U2_n2104ActActItem
               }
               , new Object[] {
               T006U3_A2106ACTABajCod, T006U3_A2175ACTABajFec, T006U3_A2174ACTABajDsc, T006U3_A2179ACTBajGrupCod, T006U3_n2179ACTBajGrupCod, T006U3_A2176ACTABajObs, T006U3_A2181ACTVouAno, T006U3_A2182ACTVouMes, T006U3_A2180ACTTasiCod, T006U3_A2183ACTVouNum,
               T006U3_A2177ACTBajCosto, T006U3_A2178ACTBajDepre, T006U3_A2100ACTActCod, T006U3_A2104ActActItem, T006U3_n2104ActActItem
               }
               , new Object[] {
               T006U4_A2122ACTActDsc, T006U4_A426ACTClaCod, T006U4_A2103ACTGrupCod
               }
               , new Object[] {
               T006U5_A2114ACTSGrupCod
               }
               , new Object[] {
               T006U6_A2106ACTABajCod, T006U6_A2175ACTABajFec, T006U6_A2122ACTActDsc, T006U6_A2174ACTABajDsc, T006U6_A2179ACTBajGrupCod, T006U6_n2179ACTBajGrupCod, T006U6_A2176ACTABajObs, T006U6_A2181ACTVouAno, T006U6_A2182ACTVouMes, T006U6_A2180ACTTasiCod,
               T006U6_A2183ACTVouNum, T006U6_A2177ACTBajCosto, T006U6_A2178ACTBajDepre, T006U6_A2100ACTActCod, T006U6_A2104ActActItem, T006U6_n2104ActActItem, T006U6_A426ACTClaCod, T006U6_A2103ACTGrupCod, T006U6_A2114ACTSGrupCod
               }
               , new Object[] {
               T006U7_A2122ACTActDsc, T006U7_A426ACTClaCod, T006U7_A2103ACTGrupCod
               }
               , new Object[] {
               T006U8_A2114ACTSGrupCod
               }
               , new Object[] {
               T006U9_A2106ACTABajCod
               }
               , new Object[] {
               T006U10_A2106ACTABajCod
               }
               , new Object[] {
               T006U11_A2106ACTABajCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006U15_A2122ACTActDsc, T006U15_A426ACTClaCod, T006U15_A2103ACTGrupCod
               }
               , new Object[] {
               T006U16_A2114ACTSGrupCod
               }
               , new Object[] {
               T006U17_A2106ACTABajCod
               }
            }
         );
      }

      private short Z2181ACTVouAno ;
      private short Z2182ACTVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2181ACTVouAno ;
      private short A2182ACTVouMes ;
      private short GX_JID ;
      private short RcdFound188 ;
      private short nIsDirty_188 ;
      private short Gx_BScreen ;
      private short ZZ2181ACTVouAno ;
      private short ZZ2182ACTVouMes ;
      private int Z2179ACTBajGrupCod ;
      private int Z2180ACTTasiCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTABajCod_Enabled ;
      private int edtACTABajFec_Enabled ;
      private int edtACTActCod_Enabled ;
      private int edtACTActDsc_Enabled ;
      private int edtActActItem_Enabled ;
      private int edtACTABajDsc_Enabled ;
      private int A2179ACTBajGrupCod ;
      private int edtACTBajGrupCod_Enabled ;
      private int edtACTClaCod_Enabled ;
      private int edtACTGrupCod_Enabled ;
      private int edtACTSGrupCod_Enabled ;
      private int edtACTABajObs_Enabled ;
      private int edtACTVouAno_Enabled ;
      private int edtACTVouMes_Enabled ;
      private int A2180ACTTasiCod ;
      private int edtACTTasiCod_Enabled ;
      private int edtACTVouNum_Enabled ;
      private int edtACTBajCosto_Enabled ;
      private int edtACTBajDepre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2179ACTBajGrupCod ;
      private int ZZ2180ACTTasiCod ;
      private decimal Z2177ACTBajCosto ;
      private decimal Z2178ACTBajDepre ;
      private decimal A2177ACTBajCosto ;
      private decimal A2178ACTBajDepre ;
      private decimal ZZ2177ACTBajCosto ;
      private decimal ZZ2178ACTBajDepre ;
      private string sPrefix ;
      private string Z2183ACTVouNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTABajCod_Internalname ;
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
      private string edtACTABajCod_Jsonclick ;
      private string edtACTABajFec_Internalname ;
      private string edtACTABajFec_Jsonclick ;
      private string edtACTActCod_Internalname ;
      private string edtACTActCod_Jsonclick ;
      private string edtACTActDsc_Internalname ;
      private string edtACTActDsc_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtACTABajDsc_Internalname ;
      private string edtACTABajDsc_Jsonclick ;
      private string edtACTBajGrupCod_Internalname ;
      private string edtACTBajGrupCod_Jsonclick ;
      private string edtACTClaCod_Internalname ;
      private string edtACTClaCod_Jsonclick ;
      private string edtACTGrupCod_Internalname ;
      private string edtACTGrupCod_Jsonclick ;
      private string edtACTSGrupCod_Internalname ;
      private string edtACTSGrupCod_Jsonclick ;
      private string edtACTABajObs_Internalname ;
      private string edtACTVouAno_Internalname ;
      private string edtACTVouAno_Jsonclick ;
      private string edtACTVouMes_Internalname ;
      private string edtACTVouMes_Jsonclick ;
      private string edtACTTasiCod_Internalname ;
      private string edtACTTasiCod_Jsonclick ;
      private string edtACTVouNum_Internalname ;
      private string A2183ACTVouNum ;
      private string edtACTVouNum_Jsonclick ;
      private string edtACTBajCosto_Internalname ;
      private string edtACTBajCosto_Jsonclick ;
      private string edtACTBajDepre_Internalname ;
      private string edtACTBajDepre_Jsonclick ;
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
      private string sMode188 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2183ACTVouNum ;
      private DateTime Z2175ACTABajFec ;
      private DateTime A2175ACTABajFec ;
      private DateTime ZZ2175ACTABajFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2104ActActItem ;
      private bool wbErr ;
      private bool n2179ACTBajGrupCod ;
      private bool Gx_longc ;
      private string A2176ACTABajObs ;
      private string Z2176ACTABajObs ;
      private string ZZ2176ACTABajObs ;
      private string Z2106ACTABajCod ;
      private string Z2174ACTABajDsc ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2106ACTABajCod ;
      private string A2122ACTActDsc ;
      private string A2174ACTABajDsc ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2114ACTSGrupCod ;
      private string Z2122ACTActDsc ;
      private string Z426ACTClaCod ;
      private string Z2103ACTGrupCod ;
      private string Z2114ACTSGrupCod ;
      private string ZZ2106ACTABajCod ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private string ZZ2174ACTABajDsc ;
      private string ZZ2122ACTActDsc ;
      private string ZZ426ACTClaCod ;
      private string ZZ2103ACTGrupCod ;
      private string ZZ2114ACTSGrupCod ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006U6_A2106ACTABajCod ;
      private DateTime[] T006U6_A2175ACTABajFec ;
      private string[] T006U6_A2122ACTActDsc ;
      private string[] T006U6_A2174ACTABajDsc ;
      private int[] T006U6_A2179ACTBajGrupCod ;
      private bool[] T006U6_n2179ACTBajGrupCod ;
      private string[] T006U6_A2176ACTABajObs ;
      private short[] T006U6_A2181ACTVouAno ;
      private short[] T006U6_A2182ACTVouMes ;
      private int[] T006U6_A2180ACTTasiCod ;
      private string[] T006U6_A2183ACTVouNum ;
      private decimal[] T006U6_A2177ACTBajCosto ;
      private decimal[] T006U6_A2178ACTBajDepre ;
      private string[] T006U6_A2100ACTActCod ;
      private string[] T006U6_A2104ActActItem ;
      private bool[] T006U6_n2104ActActItem ;
      private string[] T006U6_A426ACTClaCod ;
      private string[] T006U6_A2103ACTGrupCod ;
      private string[] T006U6_A2114ACTSGrupCod ;
      private string[] T006U4_A2122ACTActDsc ;
      private string[] T006U4_A426ACTClaCod ;
      private string[] T006U4_A2103ACTGrupCod ;
      private string[] T006U5_A2114ACTSGrupCod ;
      private string[] T006U7_A2122ACTActDsc ;
      private string[] T006U7_A426ACTClaCod ;
      private string[] T006U7_A2103ACTGrupCod ;
      private string[] T006U8_A2114ACTSGrupCod ;
      private string[] T006U9_A2106ACTABajCod ;
      private string[] T006U3_A2106ACTABajCod ;
      private DateTime[] T006U3_A2175ACTABajFec ;
      private string[] T006U3_A2174ACTABajDsc ;
      private int[] T006U3_A2179ACTBajGrupCod ;
      private bool[] T006U3_n2179ACTBajGrupCod ;
      private string[] T006U3_A2176ACTABajObs ;
      private short[] T006U3_A2181ACTVouAno ;
      private short[] T006U3_A2182ACTVouMes ;
      private int[] T006U3_A2180ACTTasiCod ;
      private string[] T006U3_A2183ACTVouNum ;
      private decimal[] T006U3_A2177ACTBajCosto ;
      private decimal[] T006U3_A2178ACTBajDepre ;
      private string[] T006U3_A2100ACTActCod ;
      private string[] T006U3_A2104ActActItem ;
      private bool[] T006U3_n2104ActActItem ;
      private string[] T006U10_A2106ACTABajCod ;
      private string[] T006U11_A2106ACTABajCod ;
      private string[] T006U2_A2106ACTABajCod ;
      private DateTime[] T006U2_A2175ACTABajFec ;
      private string[] T006U2_A2174ACTABajDsc ;
      private int[] T006U2_A2179ACTBajGrupCod ;
      private bool[] T006U2_n2179ACTBajGrupCod ;
      private string[] T006U2_A2176ACTABajObs ;
      private short[] T006U2_A2181ACTVouAno ;
      private short[] T006U2_A2182ACTVouMes ;
      private int[] T006U2_A2180ACTTasiCod ;
      private string[] T006U2_A2183ACTVouNum ;
      private decimal[] T006U2_A2177ACTBajCosto ;
      private decimal[] T006U2_A2178ACTBajDepre ;
      private string[] T006U2_A2100ACTActCod ;
      private string[] T006U2_A2104ActActItem ;
      private bool[] T006U2_n2104ActActItem ;
      private string[] T006U15_A2122ACTActDsc ;
      private string[] T006U15_A426ACTClaCod ;
      private string[] T006U15_A2103ACTGrupCod ;
      private string[] T006U16_A2114ACTSGrupCod ;
      private string[] T006U17_A2106ACTABajCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actbajaactivo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actbajaactivo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT006U6;
        prmT006U6 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U4;
        prmT006U4 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006U5;
        prmT006U5 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006U7;
        prmT006U7 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006U8;
        prmT006U8 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006U9;
        prmT006U9 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U3;
        prmT006U3 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U10;
        prmT006U10 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U11;
        prmT006U11 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U2;
        prmT006U2 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U12;
        prmT006U12 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0) ,
        new ParDef("@ACTABajFec",GXType.Date,8,0) ,
        new ParDef("@ACTABajDsc",GXType.NVarChar,40,0) ,
        new ParDef("@ACTBajGrupCod",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@ACTABajObs",GXType.NVarChar,500,0) ,
        new ParDef("@ACTVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTVouMes",GXType.Int16,2,0) ,
        new ParDef("@ACTTasiCod",GXType.Int32,6,0) ,
        new ParDef("@ACTVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTBajCosto",GXType.Decimal,15,2) ,
        new ParDef("@ACTBajDepre",GXType.Decimal,15,2) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006U13;
        prmT006U13 = new Object[] {
        new ParDef("@ACTABajFec",GXType.Date,8,0) ,
        new ParDef("@ACTABajDsc",GXType.NVarChar,40,0) ,
        new ParDef("@ACTBajGrupCod",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@ACTABajObs",GXType.NVarChar,500,0) ,
        new ParDef("@ACTVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTVouMes",GXType.Int16,2,0) ,
        new ParDef("@ACTTasiCod",GXType.Int32,6,0) ,
        new ParDef("@ACTVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTBajCosto",GXType.Decimal,15,2) ,
        new ParDef("@ACTBajDepre",GXType.Decimal,15,2) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U14;
        prmT006U14 = new Object[] {
        new ParDef("@ACTABajCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006U17;
        prmT006U17 = new Object[] {
        };
        Object[] prmT006U15;
        prmT006U15 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006U16;
        prmT006U16 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006U2", "SELECT [ACTABajCod], [ACTABajFec], [ACTABajDsc], [ACTBajGrupCod], [ACTABajObs], [ACTVouAno], [ACTVouMes], [ACTTasiCod], [ACTVouNum], [ACTBajCosto], [ACTBajDepre], [ACTActCod], [ActActItem] FROM [ACTBAJAACTIVO] WITH (UPDLOCK) WHERE [ACTABajCod] = @ACTABajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U3", "SELECT [ACTABajCod], [ACTABajFec], [ACTABajDsc], [ACTBajGrupCod], [ACTABajObs], [ACTVouAno], [ACTVouMes], [ACTTasiCod], [ACTVouNum], [ACTBajCosto], [ACTBajDepre], [ACTActCod], [ActActItem] FROM [ACTBAJAACTIVO] WHERE [ACTABajCod] = @ACTABajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U4", "SELECT [ACTActDsc], [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U5", "SELECT [ACTSGrupCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U6", "SELECT TM1.[ACTABajCod], TM1.[ACTABajFec], T2.[ACTActDsc], TM1.[ACTABajDsc], TM1.[ACTBajGrupCod], TM1.[ACTABajObs], TM1.[ACTVouAno], TM1.[ACTVouMes], TM1.[ACTTasiCod], TM1.[ACTVouNum], TM1.[ACTBajCosto], TM1.[ACTBajDepre], TM1.[ACTActCod], TM1.[ActActItem], T2.[ACTClaCod], T2.[ACTGrupCod], T3.[ACTSGrupCod] FROM (([ACTBAJAACTIVO] TM1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = TM1.[ACTActCod]) LEFT JOIN [ACTACTIVOSDET] T3 ON T3.[ACTActCod] = TM1.[ACTActCod] AND T3.[ActActItem] = TM1.[ActActItem]) WHERE TM1.[ACTABajCod] = @ACTABajCod ORDER BY TM1.[ACTABajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006U6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U7", "SELECT [ACTActDsc], [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U8", "SELECT [ACTSGrupCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U9", "SELECT [ACTABajCod] FROM [ACTBAJAACTIVO] WHERE [ACTABajCod] = @ACTABajCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U10", "SELECT TOP 1 [ACTABajCod] FROM [ACTBAJAACTIVO] WHERE ( [ACTABajCod] > @ACTABajCod) ORDER BY [ACTABajCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006U10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006U11", "SELECT TOP 1 [ACTABajCod] FROM [ACTBAJAACTIVO] WHERE ( [ACTABajCod] < @ACTABajCod) ORDER BY [ACTABajCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006U11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006U12", "INSERT INTO [ACTBAJAACTIVO]([ACTABajCod], [ACTABajFec], [ACTABajDsc], [ACTBajGrupCod], [ACTABajObs], [ACTVouAno], [ACTVouMes], [ACTTasiCod], [ACTVouNum], [ACTBajCosto], [ACTBajDepre], [ACTActCod], [ActActItem]) VALUES(@ACTABajCod, @ACTABajFec, @ACTABajDsc, @ACTBajGrupCod, @ACTABajObs, @ACTVouAno, @ACTVouMes, @ACTTasiCod, @ACTVouNum, @ACTBajCosto, @ACTBajDepre, @ACTActCod, @ActActItem)", GxErrorMask.GX_NOMASK,prmT006U12)
           ,new CursorDef("T006U13", "UPDATE [ACTBAJAACTIVO] SET [ACTABajFec]=@ACTABajFec, [ACTABajDsc]=@ACTABajDsc, [ACTBajGrupCod]=@ACTBajGrupCod, [ACTABajObs]=@ACTABajObs, [ACTVouAno]=@ACTVouAno, [ACTVouMes]=@ACTVouMes, [ACTTasiCod]=@ACTTasiCod, [ACTVouNum]=@ACTVouNum, [ACTBajCosto]=@ACTBajCosto, [ACTBajDepre]=@ACTBajDepre, [ACTActCod]=@ACTActCod, [ActActItem]=@ActActItem  WHERE [ACTABajCod] = @ACTABajCod", GxErrorMask.GX_NOMASK,prmT006U13)
           ,new CursorDef("T006U14", "DELETE FROM [ACTBAJAACTIVO]  WHERE [ACTABajCod] = @ACTABajCod", GxErrorMask.GX_NOMASK,prmT006U14)
           ,new CursorDef("T006U15", "SELECT [ACTActDsc], [ACTClaCod], [ACTGrupCod] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U16", "SELECT [ACTSGrupCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006U16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006U17", "SELECT [ACTABajCod] FROM [ACTBAJAACTIVO] ORDER BY [ACTABajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006U17,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              ((string[]) buf[13])[0] = rslt.getVarchar(13);
              ((bool[]) buf[14])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              ((string[]) buf[13])[0] = rslt.getVarchar(13);
              ((bool[]) buf[14])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((int[]) buf[9])[0] = rslt.getInt(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((string[]) buf[13])[0] = rslt.getVarchar(13);
              ((string[]) buf[14])[0] = rslt.getVarchar(14);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getVarchar(15);
              ((string[]) buf[17])[0] = rslt.getVarchar(16);
              ((string[]) buf[18])[0] = rslt.getVarchar(17);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
