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
   public class actrevaluacion : GXHttpHandler
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
            Form.Meta.addItem("description", "ACTREVALUACION", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTRevCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actrevaluacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actrevaluacion( IGxContext context )
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
            RenderHtmlCloseForm70194( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ACTREVALUACION", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTREVALUACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTREVALUACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRevCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRevCod_Internalname, "N° Revaluación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRevCod_Internalname, A2113ACTRevCod, StringUtil.RTrim( context.localUtil.Format( A2113ACTRevCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRevCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRevCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRevFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRevFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTRevFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTRevFec_Internalname, context.localUtil.Format(A2218ACTRevFec, "99/99/99"), context.localUtil.Format( A2218ACTRevFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRevFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRevFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_bitmap( context, edtACTRevFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTRevFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTREVALUACION.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTREVALUACION.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActDsc_Internalname, A2122ACTActDsc, StringUtil.RTrim( context.localUtil.Format( A2122ACTActDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTREVALUACION.htm");
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
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActRevCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActRevCosto_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActRevCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A2217ActRevCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtActRevCosto_Enabled!=0) ? context.localUtil.Format( A2217ActRevCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2217ActRevCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActRevCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActRevCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActRevObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActRevObs_Internalname, "Observación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtActRevObs_Internalname, A2220ActRevObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtActRevObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRevVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRevVouAno_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRevVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2223ACTRevVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtACTRevVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2223ACTRevVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2223ACTRevVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRevVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRevVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRevVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRevVouMes_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRevVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2224ACTRevVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtACTRevVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2224ACTRevVouMes), "Z9") : context.localUtil.Format( (decimal)(A2224ACTRevVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRevVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRevVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRevTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRevTASICod_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRevTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2221ACTRevTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTRevTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2221ACTRevTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2221ACTRevTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRevTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRevTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRevVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRevVouNum_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRevVouNum_Internalname, StringUtil.RTrim( A2225ACTRevVouNum), StringUtil.RTrim( context.localUtil.Format( A2225ACTRevVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRevVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRevVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTREVALUACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTREVALUACION.htm");
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
            Z2113ACTRevCod = cgiGet( "Z2113ACTRevCod");
            Z2218ACTRevFec = context.localUtil.CToD( cgiGet( "Z2218ACTRevFec"), 0);
            Z2217ActRevCosto = context.localUtil.CToN( cgiGet( "Z2217ActRevCosto"), ".", ",");
            Z2223ACTRevVouAno = (short)(context.localUtil.CToN( cgiGet( "Z2223ACTRevVouAno"), ".", ","));
            Z2224ACTRevVouMes = (short)(context.localUtil.CToN( cgiGet( "Z2224ACTRevVouMes"), ".", ","));
            Z2221ACTRevTASICod = (int)(context.localUtil.CToN( cgiGet( "Z2221ACTRevTASICod"), ".", ","));
            Z2225ACTRevVouNum = cgiGet( "Z2225ACTRevVouNum");
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2113ACTRevCod = cgiGet( edtACTRevCod_Internalname);
            AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
            if ( context.localUtil.VCDate( cgiGet( edtACTRevFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "ACTREVFEC");
               AnyError = 1;
               GX_FocusControl = edtACTRevFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2218ACTRevFec = DateTime.MinValue;
               AssignAttri("", false, "A2218ACTRevFec", context.localUtil.Format(A2218ACTRevFec, "99/99/99"));
            }
            else
            {
               A2218ACTRevFec = context.localUtil.CToD( cgiGet( edtACTRevFec_Internalname), 2);
               AssignAttri("", false, "A2218ACTRevFec", context.localUtil.Format(A2218ACTRevFec, "99/99/99"));
            }
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2122ACTActDsc = cgiGet( edtACTActDsc_Internalname);
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtActRevCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtActRevCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTREVCOSTO");
               AnyError = 1;
               GX_FocusControl = edtActRevCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2217ActRevCosto = 0;
               AssignAttri("", false, "A2217ActRevCosto", StringUtil.LTrimStr( A2217ActRevCosto, 15, 2));
            }
            else
            {
               A2217ActRevCosto = context.localUtil.CToN( cgiGet( edtActRevCosto_Internalname), ".", ",");
               AssignAttri("", false, "A2217ActRevCosto", StringUtil.LTrimStr( A2217ActRevCosto, 15, 2));
            }
            A2220ActRevObs = cgiGet( edtActRevObs_Internalname);
            AssignAttri("", false, "A2220ActRevObs", A2220ActRevObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRevVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRevVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTREVVOUANO");
               AnyError = 1;
               GX_FocusControl = edtACTRevVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2223ACTRevVouAno = 0;
               AssignAttri("", false, "A2223ACTRevVouAno", StringUtil.LTrimStr( (decimal)(A2223ACTRevVouAno), 4, 0));
            }
            else
            {
               A2223ACTRevVouAno = (short)(context.localUtil.CToN( cgiGet( edtACTRevVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A2223ACTRevVouAno", StringUtil.LTrimStr( (decimal)(A2223ACTRevVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRevVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRevVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTREVVOUMES");
               AnyError = 1;
               GX_FocusControl = edtACTRevVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2224ACTRevVouMes = 0;
               AssignAttri("", false, "A2224ACTRevVouMes", StringUtil.LTrimStr( (decimal)(A2224ACTRevVouMes), 2, 0));
            }
            else
            {
               A2224ACTRevVouMes = (short)(context.localUtil.CToN( cgiGet( edtACTRevVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A2224ACTRevVouMes", StringUtil.LTrimStr( (decimal)(A2224ACTRevVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRevTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRevTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTREVTASICOD");
               AnyError = 1;
               GX_FocusControl = edtACTRevTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2221ACTRevTASICod = 0;
               AssignAttri("", false, "A2221ACTRevTASICod", StringUtil.LTrimStr( (decimal)(A2221ACTRevTASICod), 6, 0));
            }
            else
            {
               A2221ACTRevTASICod = (int)(context.localUtil.CToN( cgiGet( edtACTRevTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A2221ACTRevTASICod", StringUtil.LTrimStr( (decimal)(A2221ACTRevTASICod), 6, 0));
            }
            A2225ACTRevVouNum = cgiGet( edtACTRevVouNum_Internalname);
            AssignAttri("", false, "A2225ACTRevVouNum", A2225ACTRevVouNum);
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
               A2113ACTRevCod = GetPar( "ACTRevCod");
               AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
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
               InitAll70194( ) ;
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
         DisableAttributes70194( ) ;
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

      protected void ResetCaption700( )
      {
      }

      protected void ZM70194( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2218ACTRevFec = T00703_A2218ACTRevFec[0];
               Z2217ActRevCosto = T00703_A2217ActRevCosto[0];
               Z2223ACTRevVouAno = T00703_A2223ACTRevVouAno[0];
               Z2224ACTRevVouMes = T00703_A2224ACTRevVouMes[0];
               Z2221ACTRevTASICod = T00703_A2221ACTRevTASICod[0];
               Z2225ACTRevVouNum = T00703_A2225ACTRevVouNum[0];
               Z2100ACTActCod = T00703_A2100ACTActCod[0];
               Z2104ActActItem = T00703_A2104ActActItem[0];
            }
            else
            {
               Z2218ACTRevFec = A2218ACTRevFec;
               Z2217ActRevCosto = A2217ActRevCosto;
               Z2223ACTRevVouAno = A2223ACTRevVouAno;
               Z2224ACTRevVouMes = A2224ACTRevVouMes;
               Z2221ACTRevTASICod = A2221ACTRevTASICod;
               Z2225ACTRevVouNum = A2225ACTRevVouNum;
               Z2100ACTActCod = A2100ACTActCod;
               Z2104ActActItem = A2104ActActItem;
            }
         }
         if ( GX_JID == -2 )
         {
            Z2113ACTRevCod = A2113ACTRevCod;
            Z2218ACTRevFec = A2218ACTRevFec;
            Z2217ActRevCosto = A2217ActRevCosto;
            Z2220ActRevObs = A2220ActRevObs;
            Z2223ACTRevVouAno = A2223ACTRevVouAno;
            Z2224ACTRevVouMes = A2224ACTRevVouMes;
            Z2221ACTRevTASICod = A2221ACTRevTASICod;
            Z2225ACTRevVouNum = A2225ACTRevVouNum;
            Z2100ACTActCod = A2100ACTActCod;
            Z2104ActActItem = A2104ActActItem;
            Z2122ACTActDsc = A2122ACTActDsc;
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

      protected void Load70194( )
      {
         /* Using cursor T00706 */
         pr_default.execute(4, new Object[] {A2113ACTRevCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound194 = 1;
            A2218ACTRevFec = T00706_A2218ACTRevFec[0];
            AssignAttri("", false, "A2218ACTRevFec", context.localUtil.Format(A2218ACTRevFec, "99/99/99"));
            A2122ACTActDsc = T00706_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2217ActRevCosto = T00706_A2217ActRevCosto[0];
            AssignAttri("", false, "A2217ActRevCosto", StringUtil.LTrimStr( A2217ActRevCosto, 15, 2));
            A2220ActRevObs = T00706_A2220ActRevObs[0];
            AssignAttri("", false, "A2220ActRevObs", A2220ActRevObs);
            A2223ACTRevVouAno = T00706_A2223ACTRevVouAno[0];
            AssignAttri("", false, "A2223ACTRevVouAno", StringUtil.LTrimStr( (decimal)(A2223ACTRevVouAno), 4, 0));
            A2224ACTRevVouMes = T00706_A2224ACTRevVouMes[0];
            AssignAttri("", false, "A2224ACTRevVouMes", StringUtil.LTrimStr( (decimal)(A2224ACTRevVouMes), 2, 0));
            A2221ACTRevTASICod = T00706_A2221ACTRevTASICod[0];
            AssignAttri("", false, "A2221ACTRevTASICod", StringUtil.LTrimStr( (decimal)(A2221ACTRevTASICod), 6, 0));
            A2225ACTRevVouNum = T00706_A2225ACTRevVouNum[0];
            AssignAttri("", false, "A2225ACTRevVouNum", A2225ACTRevVouNum);
            A2100ACTActCod = T00706_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T00706_A2104ActActItem[0];
            n2104ActActItem = T00706_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            ZM70194( -2) ;
         }
         pr_default.close(4);
         OnLoadActions70194( ) ;
      }

      protected void OnLoadActions70194( )
      {
      }

      protected void CheckExtendedTable70194( )
      {
         nIsDirty_194 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2218ACTRevFec) || ( DateTimeUtil.ResetTime ( A2218ACTRevFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "ACTREVFEC");
            AnyError = 1;
            GX_FocusControl = edtACTRevFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00704 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T00704_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         pr_default.close(2);
         /* Using cursor T00705 */
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
      }

      protected void CloseExtendedTableCursors70194( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A2100ACTActCod )
      {
         /* Using cursor T00707 */
         pr_default.execute(5, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T00707_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2122ACTActDsc)+"\"") ;
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
         /* Using cursor T00708 */
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

      protected void GetKey70194( )
      {
         /* Using cursor T00709 */
         pr_default.execute(7, new Object[] {A2113ACTRevCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound194 = 1;
         }
         else
         {
            RcdFound194 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00703 */
         pr_default.execute(1, new Object[] {A2113ACTRevCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM70194( 2) ;
            RcdFound194 = 1;
            A2113ACTRevCod = T00703_A2113ACTRevCod[0];
            AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
            A2218ACTRevFec = T00703_A2218ACTRevFec[0];
            AssignAttri("", false, "A2218ACTRevFec", context.localUtil.Format(A2218ACTRevFec, "99/99/99"));
            A2217ActRevCosto = T00703_A2217ActRevCosto[0];
            AssignAttri("", false, "A2217ActRevCosto", StringUtil.LTrimStr( A2217ActRevCosto, 15, 2));
            A2220ActRevObs = T00703_A2220ActRevObs[0];
            AssignAttri("", false, "A2220ActRevObs", A2220ActRevObs);
            A2223ACTRevVouAno = T00703_A2223ACTRevVouAno[0];
            AssignAttri("", false, "A2223ACTRevVouAno", StringUtil.LTrimStr( (decimal)(A2223ACTRevVouAno), 4, 0));
            A2224ACTRevVouMes = T00703_A2224ACTRevVouMes[0];
            AssignAttri("", false, "A2224ACTRevVouMes", StringUtil.LTrimStr( (decimal)(A2224ACTRevVouMes), 2, 0));
            A2221ACTRevTASICod = T00703_A2221ACTRevTASICod[0];
            AssignAttri("", false, "A2221ACTRevTASICod", StringUtil.LTrimStr( (decimal)(A2221ACTRevTASICod), 6, 0));
            A2225ACTRevVouNum = T00703_A2225ACTRevVouNum[0];
            AssignAttri("", false, "A2225ACTRevVouNum", A2225ACTRevVouNum);
            A2100ACTActCod = T00703_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T00703_A2104ActActItem[0];
            n2104ActActItem = T00703_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            Z2113ACTRevCod = A2113ACTRevCod;
            sMode194 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load70194( ) ;
            if ( AnyError == 1 )
            {
               RcdFound194 = 0;
               InitializeNonKey70194( ) ;
            }
            Gx_mode = sMode194;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound194 = 0;
            InitializeNonKey70194( ) ;
            sMode194 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode194;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey70194( ) ;
         if ( RcdFound194 == 0 )
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
         RcdFound194 = 0;
         /* Using cursor T007010 */
         pr_default.execute(8, new Object[] {A2113ACTRevCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T007010_A2113ACTRevCod[0], A2113ACTRevCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T007010_A2113ACTRevCod[0], A2113ACTRevCod) > 0 ) ) )
            {
               A2113ACTRevCod = T007010_A2113ACTRevCod[0];
               AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
               RcdFound194 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound194 = 0;
         /* Using cursor T007011 */
         pr_default.execute(9, new Object[] {A2113ACTRevCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007011_A2113ACTRevCod[0], A2113ACTRevCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007011_A2113ACTRevCod[0], A2113ACTRevCod) < 0 ) ) )
            {
               A2113ACTRevCod = T007011_A2113ACTRevCod[0];
               AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
               RcdFound194 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey70194( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTRevCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert70194( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound194 == 1 )
            {
               if ( StringUtil.StrCmp(A2113ACTRevCod, Z2113ACTRevCod) != 0 )
               {
                  A2113ACTRevCod = Z2113ACTRevCod;
                  AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTREVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTRevCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTRevCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update70194( ) ;
                  GX_FocusControl = edtACTRevCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2113ACTRevCod, Z2113ACTRevCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTRevCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert70194( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTREVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtACTRevCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTRevCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert70194( ) ;
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
         if ( StringUtil.StrCmp(A2113ACTRevCod, Z2113ACTRevCod) != 0 )
         {
            A2113ACTRevCod = Z2113ACTRevCod;
            AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTREVCOD");
            AnyError = 1;
            GX_FocusControl = edtACTRevCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTRevCod_Internalname;
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
         if ( RcdFound194 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTREVCOD");
            AnyError = 1;
            GX_FocusControl = edtACTRevCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTRevFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart70194( ) ;
         if ( RcdFound194 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRevFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd70194( ) ;
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
         if ( RcdFound194 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRevFec_Internalname;
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
         if ( RcdFound194 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRevFec_Internalname;
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
         ScanStart70194( ) ;
         if ( RcdFound194 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound194 != 0 )
            {
               ScanNext70194( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRevFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd70194( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency70194( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00702 */
            pr_default.execute(0, new Object[] {A2113ACTRevCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTRevaluacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2218ACTRevFec ) != DateTimeUtil.ResetTime ( T00702_A2218ACTRevFec[0] ) ) || ( Z2217ActRevCosto != T00702_A2217ActRevCosto[0] ) || ( Z2223ACTRevVouAno != T00702_A2223ACTRevVouAno[0] ) || ( Z2224ACTRevVouMes != T00702_A2224ACTRevVouMes[0] ) || ( Z2221ACTRevTASICod != T00702_A2221ACTRevTASICod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2225ACTRevVouNum, T00702_A2225ACTRevVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z2100ACTActCod, T00702_A2100ACTActCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2104ActActItem, T00702_A2104ActActItem[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2218ACTRevFec ) != DateTimeUtil.ResetTime ( T00702_A2218ACTRevFec[0] ) )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ACTRevFec");
                  GXUtil.WriteLogRaw("Old: ",Z2218ACTRevFec);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2218ACTRevFec[0]);
               }
               if ( Z2217ActRevCosto != T00702_A2217ActRevCosto[0] )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ActRevCosto");
                  GXUtil.WriteLogRaw("Old: ",Z2217ActRevCosto);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2217ActRevCosto[0]);
               }
               if ( Z2223ACTRevVouAno != T00702_A2223ACTRevVouAno[0] )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ACTRevVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z2223ACTRevVouAno);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2223ACTRevVouAno[0]);
               }
               if ( Z2224ACTRevVouMes != T00702_A2224ACTRevVouMes[0] )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ACTRevVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z2224ACTRevVouMes);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2224ACTRevVouMes[0]);
               }
               if ( Z2221ACTRevTASICod != T00702_A2221ACTRevTASICod[0] )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ACTRevTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z2221ACTRevTASICod);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2221ACTRevTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z2225ACTRevVouNum, T00702_A2225ACTRevVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ACTRevVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z2225ACTRevVouNum);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2225ACTRevVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z2100ACTActCod, T00702_A2100ACTActCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ACTActCod");
                  GXUtil.WriteLogRaw("Old: ",Z2100ACTActCod);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2100ACTActCod[0]);
               }
               if ( StringUtil.StrCmp(Z2104ActActItem, T00702_A2104ActActItem[0]) != 0 )
               {
                  GXUtil.WriteLog("actrevaluacion:[seudo value changed for attri]"+"ActActItem");
                  GXUtil.WriteLogRaw("Old: ",Z2104ActActItem);
                  GXUtil.WriteLogRaw("Current: ",T00702_A2104ActActItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTRevaluacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert70194( )
      {
         BeforeValidate70194( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable70194( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM70194( 0) ;
            CheckOptimisticConcurrency70194( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm70194( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert70194( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007012 */
                     pr_default.execute(10, new Object[] {A2113ACTRevCod, A2218ACTRevFec, A2217ActRevCosto, A2220ActRevObs, A2223ACTRevVouAno, A2224ACTRevVouMes, A2221ACTRevTASICod, A2225ACTRevVouNum, A2100ACTActCod, n2104ActActItem, A2104ActActItem});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTRevaluacion");
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
                           ResetCaption700( ) ;
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
               Load70194( ) ;
            }
            EndLevel70194( ) ;
         }
         CloseExtendedTableCursors70194( ) ;
      }

      protected void Update70194( )
      {
         BeforeValidate70194( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable70194( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency70194( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm70194( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate70194( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007013 */
                     pr_default.execute(11, new Object[] {A2218ACTRevFec, A2217ActRevCosto, A2220ActRevObs, A2223ACTRevVouAno, A2224ACTRevVouMes, A2221ACTRevTASICod, A2225ACTRevVouNum, A2100ACTActCod, n2104ActActItem, A2104ActActItem, A2113ACTRevCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTRevaluacion");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTRevaluacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate70194( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption700( ) ;
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
            EndLevel70194( ) ;
         }
         CloseExtendedTableCursors70194( ) ;
      }

      protected void DeferredUpdate70194( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate70194( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency70194( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls70194( ) ;
            AfterConfirm70194( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete70194( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007014 */
                  pr_default.execute(12, new Object[] {A2113ACTRevCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTRevaluacion");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound194 == 0 )
                        {
                           InitAll70194( ) ;
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
                        ResetCaption700( ) ;
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
         sMode194 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel70194( ) ;
         Gx_mode = sMode194;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls70194( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007015 */
            pr_default.execute(13, new Object[] {A2100ACTActCod});
            A2122ACTActDsc = T007015_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            pr_default.close(13);
         }
      }

      protected void EndLevel70194( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete70194( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("actrevaluacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues700( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("actrevaluacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart70194( )
      {
         /* Using cursor T007016 */
         pr_default.execute(14);
         RcdFound194 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound194 = 1;
            A2113ACTRevCod = T007016_A2113ACTRevCod[0];
            AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext70194( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound194 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound194 = 1;
            A2113ACTRevCod = T007016_A2113ACTRevCod[0];
            AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
         }
      }

      protected void ScanEnd70194( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm70194( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert70194( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate70194( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete70194( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete70194( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate70194( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes70194( )
      {
         edtACTRevCod_Enabled = 0;
         AssignProp("", false, edtACTRevCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRevCod_Enabled), 5, 0), true);
         edtACTRevFec_Enabled = 0;
         AssignProp("", false, edtACTRevFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRevFec_Enabled), 5, 0), true);
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtACTActDsc_Enabled = 0;
         AssignProp("", false, edtACTActDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDsc_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtActRevCosto_Enabled = 0;
         AssignProp("", false, edtActRevCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActRevCosto_Enabled), 5, 0), true);
         edtActRevObs_Enabled = 0;
         AssignProp("", false, edtActRevObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActRevObs_Enabled), 5, 0), true);
         edtACTRevVouAno_Enabled = 0;
         AssignProp("", false, edtACTRevVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRevVouAno_Enabled), 5, 0), true);
         edtACTRevVouMes_Enabled = 0;
         AssignProp("", false, edtACTRevVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRevVouMes_Enabled), 5, 0), true);
         edtACTRevTASICod_Enabled = 0;
         AssignProp("", false, edtACTRevTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRevTASICod_Enabled), 5, 0), true);
         edtACTRevVouNum_Enabled = 0;
         AssignProp("", false, edtACTRevVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRevVouNum_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes70194( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues700( )
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
         context.SendWebValue( "ACTREVALUACION") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265614", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actrevaluacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2113ACTRevCod", Z2113ACTRevCod);
         GxWebStd.gx_hidden_field( context, "Z2218ACTRevFec", context.localUtil.DToC( Z2218ACTRevFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2217ActRevCosto", StringUtil.LTrim( StringUtil.NToC( Z2217ActRevCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2223ACTRevVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2223ACTRevVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2224ACTRevVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2224ACTRevVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2221ACTRevTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2221ACTRevTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2225ACTRevVouNum", StringUtil.RTrim( Z2225ACTRevVouNum));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm70194( )
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
         return "ACTREVALUACION" ;
      }

      public override string GetPgmdesc( )
      {
         return "ACTREVALUACION" ;
      }

      protected void InitializeNonKey70194( )
      {
         A2218ACTRevFec = DateTime.MinValue;
         AssignAttri("", false, "A2218ACTRevFec", context.localUtil.Format(A2218ACTRevFec, "99/99/99"));
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2122ACTActDsc = "";
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A2104ActActItem = "";
         n2104ActActItem = false;
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
         A2217ActRevCosto = 0;
         AssignAttri("", false, "A2217ActRevCosto", StringUtil.LTrimStr( A2217ActRevCosto, 15, 2));
         A2220ActRevObs = "";
         AssignAttri("", false, "A2220ActRevObs", A2220ActRevObs);
         A2223ACTRevVouAno = 0;
         AssignAttri("", false, "A2223ACTRevVouAno", StringUtil.LTrimStr( (decimal)(A2223ACTRevVouAno), 4, 0));
         A2224ACTRevVouMes = 0;
         AssignAttri("", false, "A2224ACTRevVouMes", StringUtil.LTrimStr( (decimal)(A2224ACTRevVouMes), 2, 0));
         A2221ACTRevTASICod = 0;
         AssignAttri("", false, "A2221ACTRevTASICod", StringUtil.LTrimStr( (decimal)(A2221ACTRevTASICod), 6, 0));
         A2225ACTRevVouNum = "";
         AssignAttri("", false, "A2225ACTRevVouNum", A2225ACTRevVouNum);
         Z2218ACTRevFec = DateTime.MinValue;
         Z2217ActRevCosto = 0;
         Z2223ACTRevVouAno = 0;
         Z2224ACTRevVouMes = 0;
         Z2221ACTRevTASICod = 0;
         Z2225ACTRevVouNum = "";
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
      }

      protected void InitAll70194( )
      {
         A2113ACTRevCod = "";
         AssignAttri("", false, "A2113ACTRevCod", A2113ACTRevCod);
         InitializeNonKey70194( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265622", true, true);
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
         context.AddJavascriptSource("actrevaluacion.js", "?202281810265623", false, true);
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
         edtACTRevCod_Internalname = "ACTREVCOD";
         edtACTRevFec_Internalname = "ACTREVFEC";
         edtACTActCod_Internalname = "ACTACTCOD";
         edtACTActDsc_Internalname = "ACTACTDSC";
         edtActActItem_Internalname = "ACTACTITEM";
         edtActRevCosto_Internalname = "ACTREVCOSTO";
         edtActRevObs_Internalname = "ACTREVOBS";
         edtACTRevVouAno_Internalname = "ACTREVVOUANO";
         edtACTRevVouMes_Internalname = "ACTREVVOUMES";
         edtACTRevTASICod_Internalname = "ACTREVTASICOD";
         edtACTRevVouNum_Internalname = "ACTREVVOUNUM";
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
         edtACTRevVouNum_Jsonclick = "";
         edtACTRevVouNum_Enabled = 1;
         edtACTRevTASICod_Jsonclick = "";
         edtACTRevTASICod_Enabled = 1;
         edtACTRevVouMes_Jsonclick = "";
         edtACTRevVouMes_Enabled = 1;
         edtACTRevVouAno_Jsonclick = "";
         edtACTRevVouAno_Enabled = 1;
         edtActRevObs_Enabled = 1;
         edtActRevCosto_Jsonclick = "";
         edtActRevCosto_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActDsc_Jsonclick = "";
         edtACTActDsc_Enabled = 0;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
         edtACTRevFec_Jsonclick = "";
         edtACTRevFec_Enabled = 1;
         edtACTRevCod_Jsonclick = "";
         edtACTRevCod_Enabled = 1;
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
         GX_FocusControl = edtACTRevFec_Internalname;
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

      public void Valid_Actrevcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2218ACTRevFec", context.localUtil.Format(A2218ACTRevFec, "99/99/99"));
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         AssignAttri("", false, "A2217ActRevCosto", StringUtil.LTrim( StringUtil.NToC( A2217ActRevCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A2220ActRevObs", A2220ActRevObs);
         AssignAttri("", false, "A2223ACTRevVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2223ACTRevVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A2224ACTRevVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2224ACTRevVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A2221ACTRevTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2221ACTRevTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A2225ACTRevVouNum", StringUtil.RTrim( A2225ACTRevVouNum));
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2113ACTRevCod", Z2113ACTRevCod);
         GxWebStd.gx_hidden_field( context, "Z2218ACTRevFec", context.localUtil.Format(Z2218ACTRevFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2217ActRevCosto", StringUtil.LTrim( StringUtil.NToC( Z2217ActRevCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2220ActRevObs", Z2220ActRevObs);
         GxWebStd.gx_hidden_field( context, "Z2223ACTRevVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2223ACTRevVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2224ACTRevVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2224ACTRevVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2221ACTRevTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2221ACTRevTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2225ACTRevVouNum", StringUtil.RTrim( Z2225ACTRevVouNum));
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actactcod( )
      {
         /* Using cursor T007015 */
         pr_default.execute(13, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         A2122ACTActDsc = T007015_A2122ACTActDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
      }

      public void Valid_Actactitem( )
      {
         n2104ActActItem = false;
         /* Using cursor T007017 */
         pr_default.execute(15, new Object[] {A2100ACTActCod, n2104ActActItem, A2104ActActItem});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A2100ACTActCod)) || String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ) )
            {
               GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
               AnyError = 1;
               GX_FocusControl = edtACTActCod_Internalname;
            }
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
         setEventMetadata("VALID_ACTREVCOD","{handler:'Valid_Actrevcod',iparms:[{av:'A2113ACTRevCod',fld:'ACTREVCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTREVCOD",",oparms:[{av:'A2218ACTRevFec',fld:'ACTREVFEC',pic:''},{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'A2217ActRevCosto',fld:'ACTREVCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2220ActRevObs',fld:'ACTREVOBS',pic:''},{av:'A2223ACTRevVouAno',fld:'ACTREVVOUANO',pic:'ZZZ9'},{av:'A2224ACTRevVouMes',fld:'ACTREVVOUMES',pic:'Z9'},{av:'A2221ACTRevTASICod',fld:'ACTREVTASICOD',pic:'ZZZZZ9'},{av:'A2225ACTRevVouNum',fld:'ACTREVVOUNUM',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2113ACTRevCod'},{av:'Z2218ACTRevFec'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2217ActRevCosto'},{av:'Z2220ActRevObs'},{av:'Z2223ACTRevVouAno'},{av:'Z2224ACTRevVouMes'},{av:'Z2221ACTRevTASICod'},{av:'Z2225ACTRevVouNum'},{av:'Z2122ACTActDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTREVFEC","{handler:'Valid_Actrevfec',iparms:[]");
         setEventMetadata("VALID_ACTREVFEC",",oparms:[]}");
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''}]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''}]}");
         setEventMetadata("VALID_ACTACTITEM","{handler:'Valid_Actactitem',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''}]");
         setEventMetadata("VALID_ACTACTITEM",",oparms:[]}");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2113ACTRevCod = "";
         Z2218ACTRevFec = DateTime.MinValue;
         Z2225ACTRevVouNum = "";
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
         A2113ACTRevCod = "";
         A2218ACTRevFec = DateTime.MinValue;
         A2122ACTActDsc = "";
         A2220ActRevObs = "";
         A2225ACTRevVouNum = "";
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
         Z2220ActRevObs = "";
         Z2122ACTActDsc = "";
         T00706_A2113ACTRevCod = new string[] {""} ;
         T00706_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         T00706_A2122ACTActDsc = new string[] {""} ;
         T00706_A2217ActRevCosto = new decimal[1] ;
         T00706_A2220ActRevObs = new string[] {""} ;
         T00706_A2223ACTRevVouAno = new short[1] ;
         T00706_A2224ACTRevVouMes = new short[1] ;
         T00706_A2221ACTRevTASICod = new int[1] ;
         T00706_A2225ACTRevVouNum = new string[] {""} ;
         T00706_A2100ACTActCod = new string[] {""} ;
         T00706_A2104ActActItem = new string[] {""} ;
         T00706_n2104ActActItem = new bool[] {false} ;
         T00704_A2122ACTActDsc = new string[] {""} ;
         T00705_A2100ACTActCod = new string[] {""} ;
         T00707_A2122ACTActDsc = new string[] {""} ;
         T00708_A2100ACTActCod = new string[] {""} ;
         T00709_A2113ACTRevCod = new string[] {""} ;
         T00703_A2113ACTRevCod = new string[] {""} ;
         T00703_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         T00703_A2217ActRevCosto = new decimal[1] ;
         T00703_A2220ActRevObs = new string[] {""} ;
         T00703_A2223ACTRevVouAno = new short[1] ;
         T00703_A2224ACTRevVouMes = new short[1] ;
         T00703_A2221ACTRevTASICod = new int[1] ;
         T00703_A2225ACTRevVouNum = new string[] {""} ;
         T00703_A2100ACTActCod = new string[] {""} ;
         T00703_A2104ActActItem = new string[] {""} ;
         T00703_n2104ActActItem = new bool[] {false} ;
         sMode194 = "";
         T007010_A2113ACTRevCod = new string[] {""} ;
         T007011_A2113ACTRevCod = new string[] {""} ;
         T00702_A2113ACTRevCod = new string[] {""} ;
         T00702_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         T00702_A2217ActRevCosto = new decimal[1] ;
         T00702_A2220ActRevObs = new string[] {""} ;
         T00702_A2223ACTRevVouAno = new short[1] ;
         T00702_A2224ACTRevVouMes = new short[1] ;
         T00702_A2221ACTRevTASICod = new int[1] ;
         T00702_A2225ACTRevVouNum = new string[] {""} ;
         T00702_A2100ACTActCod = new string[] {""} ;
         T00702_A2104ActActItem = new string[] {""} ;
         T00702_n2104ActActItem = new bool[] {false} ;
         T007015_A2122ACTActDsc = new string[] {""} ;
         T007016_A2113ACTRevCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2113ACTRevCod = "";
         ZZ2218ACTRevFec = DateTime.MinValue;
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2220ActRevObs = "";
         ZZ2225ACTRevVouNum = "";
         ZZ2122ACTActDsc = "";
         T007017_A2100ACTActCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actrevaluacion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actrevaluacion__default(),
            new Object[][] {
                new Object[] {
               T00702_A2113ACTRevCod, T00702_A2218ACTRevFec, T00702_A2217ActRevCosto, T00702_A2220ActRevObs, T00702_A2223ACTRevVouAno, T00702_A2224ACTRevVouMes, T00702_A2221ACTRevTASICod, T00702_A2225ACTRevVouNum, T00702_A2100ACTActCod, T00702_A2104ActActItem,
               T00702_n2104ActActItem
               }
               , new Object[] {
               T00703_A2113ACTRevCod, T00703_A2218ACTRevFec, T00703_A2217ActRevCosto, T00703_A2220ActRevObs, T00703_A2223ACTRevVouAno, T00703_A2224ACTRevVouMes, T00703_A2221ACTRevTASICod, T00703_A2225ACTRevVouNum, T00703_A2100ACTActCod, T00703_A2104ActActItem,
               T00703_n2104ActActItem
               }
               , new Object[] {
               T00704_A2122ACTActDsc
               }
               , new Object[] {
               T00705_A2100ACTActCod
               }
               , new Object[] {
               T00706_A2113ACTRevCod, T00706_A2218ACTRevFec, T00706_A2122ACTActDsc, T00706_A2217ActRevCosto, T00706_A2220ActRevObs, T00706_A2223ACTRevVouAno, T00706_A2224ACTRevVouMes, T00706_A2221ACTRevTASICod, T00706_A2225ACTRevVouNum, T00706_A2100ACTActCod,
               T00706_A2104ActActItem, T00706_n2104ActActItem
               }
               , new Object[] {
               T00707_A2122ACTActDsc
               }
               , new Object[] {
               T00708_A2100ACTActCod
               }
               , new Object[] {
               T00709_A2113ACTRevCod
               }
               , new Object[] {
               T007010_A2113ACTRevCod
               }
               , new Object[] {
               T007011_A2113ACTRevCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007015_A2122ACTActDsc
               }
               , new Object[] {
               T007016_A2113ACTRevCod
               }
               , new Object[] {
               T007017_A2100ACTActCod
               }
            }
         );
      }

      private short Z2223ACTRevVouAno ;
      private short Z2224ACTRevVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2223ACTRevVouAno ;
      private short A2224ACTRevVouMes ;
      private short GX_JID ;
      private short RcdFound194 ;
      private short nIsDirty_194 ;
      private short Gx_BScreen ;
      private short ZZ2223ACTRevVouAno ;
      private short ZZ2224ACTRevVouMes ;
      private int Z2221ACTRevTASICod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTRevCod_Enabled ;
      private int edtACTRevFec_Enabled ;
      private int edtACTActCod_Enabled ;
      private int edtACTActDsc_Enabled ;
      private int edtActActItem_Enabled ;
      private int edtActRevCosto_Enabled ;
      private int edtActRevObs_Enabled ;
      private int edtACTRevVouAno_Enabled ;
      private int edtACTRevVouMes_Enabled ;
      private int A2221ACTRevTASICod ;
      private int edtACTRevTASICod_Enabled ;
      private int edtACTRevVouNum_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2221ACTRevTASICod ;
      private decimal Z2217ActRevCosto ;
      private decimal A2217ActRevCosto ;
      private decimal ZZ2217ActRevCosto ;
      private string sPrefix ;
      private string Z2225ACTRevVouNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTRevCod_Internalname ;
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
      private string edtACTRevCod_Jsonclick ;
      private string edtACTRevFec_Internalname ;
      private string edtACTRevFec_Jsonclick ;
      private string edtACTActCod_Internalname ;
      private string edtACTActCod_Jsonclick ;
      private string edtACTActDsc_Internalname ;
      private string edtACTActDsc_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtActRevCosto_Internalname ;
      private string edtActRevCosto_Jsonclick ;
      private string edtActRevObs_Internalname ;
      private string edtACTRevVouAno_Internalname ;
      private string edtACTRevVouAno_Jsonclick ;
      private string edtACTRevVouMes_Internalname ;
      private string edtACTRevVouMes_Jsonclick ;
      private string edtACTRevTASICod_Internalname ;
      private string edtACTRevTASICod_Jsonclick ;
      private string edtACTRevVouNum_Internalname ;
      private string A2225ACTRevVouNum ;
      private string edtACTRevVouNum_Jsonclick ;
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
      private string sMode194 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2225ACTRevVouNum ;
      private DateTime Z2218ACTRevFec ;
      private DateTime A2218ACTRevFec ;
      private DateTime ZZ2218ACTRevFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2104ActActItem ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A2220ActRevObs ;
      private string Z2220ActRevObs ;
      private string ZZ2220ActRevObs ;
      private string Z2113ACTRevCod ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2113ACTRevCod ;
      private string A2122ACTActDsc ;
      private string Z2122ACTActDsc ;
      private string ZZ2113ACTRevCod ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private string ZZ2122ACTActDsc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00706_A2113ACTRevCod ;
      private DateTime[] T00706_A2218ACTRevFec ;
      private string[] T00706_A2122ACTActDsc ;
      private decimal[] T00706_A2217ActRevCosto ;
      private string[] T00706_A2220ActRevObs ;
      private short[] T00706_A2223ACTRevVouAno ;
      private short[] T00706_A2224ACTRevVouMes ;
      private int[] T00706_A2221ACTRevTASICod ;
      private string[] T00706_A2225ACTRevVouNum ;
      private string[] T00706_A2100ACTActCod ;
      private string[] T00706_A2104ActActItem ;
      private bool[] T00706_n2104ActActItem ;
      private string[] T00704_A2122ACTActDsc ;
      private string[] T00705_A2100ACTActCod ;
      private string[] T00707_A2122ACTActDsc ;
      private string[] T00708_A2100ACTActCod ;
      private string[] T00709_A2113ACTRevCod ;
      private string[] T00703_A2113ACTRevCod ;
      private DateTime[] T00703_A2218ACTRevFec ;
      private decimal[] T00703_A2217ActRevCosto ;
      private string[] T00703_A2220ActRevObs ;
      private short[] T00703_A2223ACTRevVouAno ;
      private short[] T00703_A2224ACTRevVouMes ;
      private int[] T00703_A2221ACTRevTASICod ;
      private string[] T00703_A2225ACTRevVouNum ;
      private string[] T00703_A2100ACTActCod ;
      private string[] T00703_A2104ActActItem ;
      private bool[] T00703_n2104ActActItem ;
      private string[] T007010_A2113ACTRevCod ;
      private string[] T007011_A2113ACTRevCod ;
      private string[] T00702_A2113ACTRevCod ;
      private DateTime[] T00702_A2218ACTRevFec ;
      private decimal[] T00702_A2217ActRevCosto ;
      private string[] T00702_A2220ActRevObs ;
      private short[] T00702_A2223ACTRevVouAno ;
      private short[] T00702_A2224ACTRevVouMes ;
      private int[] T00702_A2221ACTRevTASICod ;
      private string[] T00702_A2225ACTRevVouNum ;
      private string[] T00702_A2100ACTActCod ;
      private string[] T00702_A2104ActActItem ;
      private bool[] T00702_n2104ActActItem ;
      private string[] T007015_A2122ACTActDsc ;
      private string[] T007016_A2113ACTRevCod ;
      private string[] T007017_A2100ACTActCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actrevaluacion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actrevaluacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00706;
        prmT00706 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT00704;
        prmT00704 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT00705;
        prmT00705 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT00707;
        prmT00707 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT00708;
        prmT00708 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT00709;
        prmT00709 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT00703;
        prmT00703 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT007010;
        prmT007010 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT007011;
        prmT007011 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT00702;
        prmT00702 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT007012;
        prmT007012 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0) ,
        new ParDef("@ACTRevFec",GXType.Date,8,0) ,
        new ParDef("@ActRevCosto",GXType.Decimal,15,2) ,
        new ParDef("@ActRevObs",GXType.NVarChar,500,0) ,
        new ParDef("@ACTRevVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTRevVouMes",GXType.Int16,2,0) ,
        new ParDef("@ACTRevTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTRevVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT007013;
        prmT007013 = new Object[] {
        new ParDef("@ACTRevFec",GXType.Date,8,0) ,
        new ParDef("@ActRevCosto",GXType.Decimal,15,2) ,
        new ParDef("@ActRevObs",GXType.NVarChar,500,0) ,
        new ParDef("@ACTRevVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTRevVouMes",GXType.Int16,2,0) ,
        new ParDef("@ACTRevTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTRevVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT007014;
        prmT007014 = new Object[] {
        new ParDef("@ACTRevCod",GXType.NVarChar,10,0)
        };
        Object[] prmT007016;
        prmT007016 = new Object[] {
        };
        Object[] prmT007015;
        prmT007015 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT007017;
        prmT007017 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00702", "SELECT [ACTRevCod], [ACTRevFec], [ActRevCosto], [ActRevObs], [ACTRevVouAno], [ACTRevVouMes], [ACTRevTASICod], [ACTRevVouNum], [ACTActCod], [ActActItem] FROM [ACTRevaluacion] WITH (UPDLOCK) WHERE [ACTRevCod] = @ACTRevCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00702,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00703", "SELECT [ACTRevCod], [ACTRevFec], [ActRevCosto], [ActRevObs], [ACTRevVouAno], [ACTRevVouMes], [ACTRevTASICod], [ACTRevVouNum], [ACTActCod], [ActActItem] FROM [ACTRevaluacion] WHERE [ACTRevCod] = @ACTRevCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00703,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00704", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00704,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00705", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00705,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00706", "SELECT TM1.[ACTRevCod], TM1.[ACTRevFec], T2.[ACTActDsc], TM1.[ActRevCosto], TM1.[ActRevObs], TM1.[ACTRevVouAno], TM1.[ACTRevVouMes], TM1.[ACTRevTASICod], TM1.[ACTRevVouNum], TM1.[ACTActCod], TM1.[ActActItem] FROM ([ACTRevaluacion] TM1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = TM1.[ACTActCod]) WHERE TM1.[ACTRevCod] = @ACTRevCod ORDER BY TM1.[ACTRevCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00706,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00707", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00707,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00708", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00708,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00709", "SELECT [ACTRevCod] FROM [ACTRevaluacion] WHERE [ACTRevCod] = @ACTRevCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00709,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007010", "SELECT TOP 1 [ACTRevCod] FROM [ACTRevaluacion] WHERE ( [ACTRevCod] > @ACTRevCod) ORDER BY [ACTRevCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007010,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007011", "SELECT TOP 1 [ACTRevCod] FROM [ACTRevaluacion] WHERE ( [ACTRevCod] < @ACTRevCod) ORDER BY [ACTRevCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007011,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007012", "INSERT INTO [ACTRevaluacion]([ACTRevCod], [ACTRevFec], [ActRevCosto], [ActRevObs], [ACTRevVouAno], [ACTRevVouMes], [ACTRevTASICod], [ACTRevVouNum], [ACTActCod], [ActActItem]) VALUES(@ACTRevCod, @ACTRevFec, @ActRevCosto, @ActRevObs, @ACTRevVouAno, @ACTRevVouMes, @ACTRevTASICod, @ACTRevVouNum, @ACTActCod, @ActActItem)", GxErrorMask.GX_NOMASK,prmT007012)
           ,new CursorDef("T007013", "UPDATE [ACTRevaluacion] SET [ACTRevFec]=@ACTRevFec, [ActRevCosto]=@ActRevCosto, [ActRevObs]=@ActRevObs, [ACTRevVouAno]=@ACTRevVouAno, [ACTRevVouMes]=@ACTRevVouMes, [ACTRevTASICod]=@ACTRevTASICod, [ACTRevVouNum]=@ACTRevVouNum, [ACTActCod]=@ACTActCod, [ActActItem]=@ActActItem  WHERE [ACTRevCod] = @ACTRevCod", GxErrorMask.GX_NOMASK,prmT007013)
           ,new CursorDef("T007014", "DELETE FROM [ACTRevaluacion]  WHERE [ACTRevCod] = @ACTRevCod", GxErrorMask.GX_NOMASK,prmT007014)
           ,new CursorDef("T007015", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007016", "SELECT [ACTRevCod] FROM [ACTRevaluacion] ORDER BY [ACTRevCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007016,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007017", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007017,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
