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
   public class actmovreparacion : GXHttpHandler
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
            Form.Meta.addItem("description", "Reparacion de Activos Fijos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAMRepCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actmovreparacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actmovreparacion( IGxContext context )
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
            RenderHtmlCloseForm6Z193( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Reparacion de Activos Fijos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTMOVREPARACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTMOVREPARACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepCod_Internalname, "N° Reparación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepCod_Internalname, A2112AMRepCod, StringUtil.RTrim( context.localUtil.Format( A2112AMRepCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAMRepFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAMRepFec_Internalname, context.localUtil.Format(A2204AMRepFec, "99/99/99"), context.localUtil.Format( A2204AMRepFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_bitmap( context, edtAMRepFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAMRepFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTMOVREPARACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepTipo_Internalname, "Tipo de Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepTipo_Internalname, A2208AMRepTipo, StringUtil.RTrim( context.localUtil.Format( A2208AMRepTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepTipo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVREPARACION.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVREPARACION.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActDsc_Internalname, A2122ACTActDsc, StringUtil.RTrim( context.localUtil.Format( A2122ACTActDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVREPARACION.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepObs_Internalname, "Observaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAMRepObs_Internalname, A2206AMRepObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtAMRepObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepValor_Internalname, "Costo Reparación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2209AMRepValor, 17, 2, ".", "")), StringUtil.LTrim( ((edtAMRepValor_Enabled!=0) ? context.localUtil.Format( A2209AMRepValor, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2209AMRepValor, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepValor_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepGrupCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepGrupCod_Internalname, "Componente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepGrupCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2205AMRepGrupCod), 5, 0, ".", "")), StringUtil.LTrim( ((edtAMRepGrupCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2205AMRepGrupCod), "ZZZZ9") : context.localUtil.Format( (decimal)(A2205AMRepGrupCod), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepGrupCod_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepVouAno_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2210AMRepVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtAMRepVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2210AMRepVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2210AMRepVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepVouMes_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2211AMRepVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtAMRepVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2211AMRepVouMes), "Z9") : context.localUtil.Format( (decimal)(A2211AMRepVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepTASICod_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2207AMRepTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAMRepTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2207AMRepTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2207AMRepTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAMRepVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAMRepVouNum_Internalname, "Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAMRepVouNum_Internalname, StringUtil.RTrim( A2212AMRepVouNum), StringUtil.RTrim( context.localUtil.Format( A2212AMRepVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAMRepVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAMRepVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTMOVREPARACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTMOVREPARACION.htm");
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
            Z2112AMRepCod = cgiGet( "Z2112AMRepCod");
            Z2204AMRepFec = context.localUtil.CToD( cgiGet( "Z2204AMRepFec"), 0);
            Z2208AMRepTipo = cgiGet( "Z2208AMRepTipo");
            Z2206AMRepObs = cgiGet( "Z2206AMRepObs");
            Z2209AMRepValor = context.localUtil.CToN( cgiGet( "Z2209AMRepValor"), ".", ",");
            Z2205AMRepGrupCod = (int)(context.localUtil.CToN( cgiGet( "Z2205AMRepGrupCod"), ".", ","));
            Z2210AMRepVouAno = (short)(context.localUtil.CToN( cgiGet( "Z2210AMRepVouAno"), ".", ","));
            Z2211AMRepVouMes = (short)(context.localUtil.CToN( cgiGet( "Z2211AMRepVouMes"), ".", ","));
            Z2207AMRepTASICod = (int)(context.localUtil.CToN( cgiGet( "Z2207AMRepTASICod"), ".", ","));
            Z2212AMRepVouNum = cgiGet( "Z2212AMRepVouNum");
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2112AMRepCod = cgiGet( edtAMRepCod_Internalname);
            AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
            if ( context.localUtil.VCDate( cgiGet( edtAMRepFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "AMREPFEC");
               AnyError = 1;
               GX_FocusControl = edtAMRepFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2204AMRepFec = DateTime.MinValue;
               AssignAttri("", false, "A2204AMRepFec", context.localUtil.Format(A2204AMRepFec, "99/99/99"));
            }
            else
            {
               A2204AMRepFec = context.localUtil.CToD( cgiGet( edtAMRepFec_Internalname), 2);
               AssignAttri("", false, "A2204AMRepFec", context.localUtil.Format(A2204AMRepFec, "99/99/99"));
            }
            A2208AMRepTipo = cgiGet( edtAMRepTipo_Internalname);
            AssignAttri("", false, "A2208AMRepTipo", A2208AMRepTipo);
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2122ACTActDsc = cgiGet( edtACTActDsc_Internalname);
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            A2206AMRepObs = cgiGet( edtAMRepObs_Internalname);
            AssignAttri("", false, "A2206AMRepObs", A2206AMRepObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAMRepValor_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAMRepValor_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMREPVALOR");
               AnyError = 1;
               GX_FocusControl = edtAMRepValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2209AMRepValor = 0;
               AssignAttri("", false, "A2209AMRepValor", StringUtil.LTrimStr( A2209AMRepValor, 15, 2));
            }
            else
            {
               A2209AMRepValor = context.localUtil.CToN( cgiGet( edtAMRepValor_Internalname), ".", ",");
               AssignAttri("", false, "A2209AMRepValor", StringUtil.LTrimStr( A2209AMRepValor, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAMRepGrupCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAMRepGrupCod_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMREPGRUPCOD");
               AnyError = 1;
               GX_FocusControl = edtAMRepGrupCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2205AMRepGrupCod = 0;
               AssignAttri("", false, "A2205AMRepGrupCod", StringUtil.LTrimStr( (decimal)(A2205AMRepGrupCod), 5, 0));
            }
            else
            {
               A2205AMRepGrupCod = (int)(context.localUtil.CToN( cgiGet( edtAMRepGrupCod_Internalname), ".", ","));
               AssignAttri("", false, "A2205AMRepGrupCod", StringUtil.LTrimStr( (decimal)(A2205AMRepGrupCod), 5, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAMRepVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAMRepVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMREPVOUANO");
               AnyError = 1;
               GX_FocusControl = edtAMRepVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2210AMRepVouAno = 0;
               AssignAttri("", false, "A2210AMRepVouAno", StringUtil.LTrimStr( (decimal)(A2210AMRepVouAno), 4, 0));
            }
            else
            {
               A2210AMRepVouAno = (short)(context.localUtil.CToN( cgiGet( edtAMRepVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A2210AMRepVouAno", StringUtil.LTrimStr( (decimal)(A2210AMRepVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAMRepVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAMRepVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMREPVOUMES");
               AnyError = 1;
               GX_FocusControl = edtAMRepVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2211AMRepVouMes = 0;
               AssignAttri("", false, "A2211AMRepVouMes", StringUtil.LTrimStr( (decimal)(A2211AMRepVouMes), 2, 0));
            }
            else
            {
               A2211AMRepVouMes = (short)(context.localUtil.CToN( cgiGet( edtAMRepVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A2211AMRepVouMes", StringUtil.LTrimStr( (decimal)(A2211AMRepVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAMRepTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAMRepTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMREPTASICOD");
               AnyError = 1;
               GX_FocusControl = edtAMRepTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2207AMRepTASICod = 0;
               AssignAttri("", false, "A2207AMRepTASICod", StringUtil.LTrimStr( (decimal)(A2207AMRepTASICod), 6, 0));
            }
            else
            {
               A2207AMRepTASICod = (int)(context.localUtil.CToN( cgiGet( edtAMRepTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A2207AMRepTASICod", StringUtil.LTrimStr( (decimal)(A2207AMRepTASICod), 6, 0));
            }
            A2212AMRepVouNum = cgiGet( edtAMRepVouNum_Internalname);
            AssignAttri("", false, "A2212AMRepVouNum", A2212AMRepVouNum);
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
               A2112AMRepCod = GetPar( "AMRepCod");
               AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
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
               InitAll6Z193( ) ;
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
         DisableAttributes6Z193( ) ;
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

      protected void ResetCaption6Z0( )
      {
      }

      protected void ZM6Z193( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2204AMRepFec = T006Z3_A2204AMRepFec[0];
               Z2208AMRepTipo = T006Z3_A2208AMRepTipo[0];
               Z2206AMRepObs = T006Z3_A2206AMRepObs[0];
               Z2209AMRepValor = T006Z3_A2209AMRepValor[0];
               Z2205AMRepGrupCod = T006Z3_A2205AMRepGrupCod[0];
               Z2210AMRepVouAno = T006Z3_A2210AMRepVouAno[0];
               Z2211AMRepVouMes = T006Z3_A2211AMRepVouMes[0];
               Z2207AMRepTASICod = T006Z3_A2207AMRepTASICod[0];
               Z2212AMRepVouNum = T006Z3_A2212AMRepVouNum[0];
               Z2100ACTActCod = T006Z3_A2100ACTActCod[0];
               Z2104ActActItem = T006Z3_A2104ActActItem[0];
            }
            else
            {
               Z2204AMRepFec = A2204AMRepFec;
               Z2208AMRepTipo = A2208AMRepTipo;
               Z2206AMRepObs = A2206AMRepObs;
               Z2209AMRepValor = A2209AMRepValor;
               Z2205AMRepGrupCod = A2205AMRepGrupCod;
               Z2210AMRepVouAno = A2210AMRepVouAno;
               Z2211AMRepVouMes = A2211AMRepVouMes;
               Z2207AMRepTASICod = A2207AMRepTASICod;
               Z2212AMRepVouNum = A2212AMRepVouNum;
               Z2100ACTActCod = A2100ACTActCod;
               Z2104ActActItem = A2104ActActItem;
            }
         }
         if ( GX_JID == -2 )
         {
            Z2112AMRepCod = A2112AMRepCod;
            Z2204AMRepFec = A2204AMRepFec;
            Z2208AMRepTipo = A2208AMRepTipo;
            Z2206AMRepObs = A2206AMRepObs;
            Z2209AMRepValor = A2209AMRepValor;
            Z2205AMRepGrupCod = A2205AMRepGrupCod;
            Z2210AMRepVouAno = A2210AMRepVouAno;
            Z2211AMRepVouMes = A2211AMRepVouMes;
            Z2207AMRepTASICod = A2207AMRepTASICod;
            Z2212AMRepVouNum = A2212AMRepVouNum;
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

      protected void Load6Z193( )
      {
         /* Using cursor T006Z6 */
         pr_default.execute(4, new Object[] {A2112AMRepCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound193 = 1;
            A2204AMRepFec = T006Z6_A2204AMRepFec[0];
            AssignAttri("", false, "A2204AMRepFec", context.localUtil.Format(A2204AMRepFec, "99/99/99"));
            A2208AMRepTipo = T006Z6_A2208AMRepTipo[0];
            AssignAttri("", false, "A2208AMRepTipo", A2208AMRepTipo);
            A2122ACTActDsc = T006Z6_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2206AMRepObs = T006Z6_A2206AMRepObs[0];
            AssignAttri("", false, "A2206AMRepObs", A2206AMRepObs);
            A2209AMRepValor = T006Z6_A2209AMRepValor[0];
            AssignAttri("", false, "A2209AMRepValor", StringUtil.LTrimStr( A2209AMRepValor, 15, 2));
            A2205AMRepGrupCod = T006Z6_A2205AMRepGrupCod[0];
            AssignAttri("", false, "A2205AMRepGrupCod", StringUtil.LTrimStr( (decimal)(A2205AMRepGrupCod), 5, 0));
            A2210AMRepVouAno = T006Z6_A2210AMRepVouAno[0];
            AssignAttri("", false, "A2210AMRepVouAno", StringUtil.LTrimStr( (decimal)(A2210AMRepVouAno), 4, 0));
            A2211AMRepVouMes = T006Z6_A2211AMRepVouMes[0];
            AssignAttri("", false, "A2211AMRepVouMes", StringUtil.LTrimStr( (decimal)(A2211AMRepVouMes), 2, 0));
            A2207AMRepTASICod = T006Z6_A2207AMRepTASICod[0];
            AssignAttri("", false, "A2207AMRepTASICod", StringUtil.LTrimStr( (decimal)(A2207AMRepTASICod), 6, 0));
            A2212AMRepVouNum = T006Z6_A2212AMRepVouNum[0];
            AssignAttri("", false, "A2212AMRepVouNum", A2212AMRepVouNum);
            A2100ACTActCod = T006Z6_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006Z6_A2104ActActItem[0];
            n2104ActActItem = T006Z6_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            ZM6Z193( -2) ;
         }
         pr_default.close(4);
         OnLoadActions6Z193( ) ;
      }

      protected void OnLoadActions6Z193( )
      {
      }

      protected void CheckExtendedTable6Z193( )
      {
         nIsDirty_193 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2204AMRepFec) || ( DateTimeUtil.ResetTime ( A2204AMRepFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "AMREPFEC");
            AnyError = 1;
            GX_FocusControl = edtAMRepFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006Z4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006Z4_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         pr_default.close(2);
         /* Using cursor T006Z5 */
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

      protected void CloseExtendedTableCursors6Z193( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A2100ACTActCod )
      {
         /* Using cursor T006Z7 */
         pr_default.execute(5, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006Z7_A2122ACTActDsc[0];
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
         /* Using cursor T006Z8 */
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

      protected void GetKey6Z193( )
      {
         /* Using cursor T006Z9 */
         pr_default.execute(7, new Object[] {A2112AMRepCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound193 = 1;
         }
         else
         {
            RcdFound193 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006Z3 */
         pr_default.execute(1, new Object[] {A2112AMRepCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6Z193( 2) ;
            RcdFound193 = 1;
            A2112AMRepCod = T006Z3_A2112AMRepCod[0];
            AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
            A2204AMRepFec = T006Z3_A2204AMRepFec[0];
            AssignAttri("", false, "A2204AMRepFec", context.localUtil.Format(A2204AMRepFec, "99/99/99"));
            A2208AMRepTipo = T006Z3_A2208AMRepTipo[0];
            AssignAttri("", false, "A2208AMRepTipo", A2208AMRepTipo);
            A2206AMRepObs = T006Z3_A2206AMRepObs[0];
            AssignAttri("", false, "A2206AMRepObs", A2206AMRepObs);
            A2209AMRepValor = T006Z3_A2209AMRepValor[0];
            AssignAttri("", false, "A2209AMRepValor", StringUtil.LTrimStr( A2209AMRepValor, 15, 2));
            A2205AMRepGrupCod = T006Z3_A2205AMRepGrupCod[0];
            AssignAttri("", false, "A2205AMRepGrupCod", StringUtil.LTrimStr( (decimal)(A2205AMRepGrupCod), 5, 0));
            A2210AMRepVouAno = T006Z3_A2210AMRepVouAno[0];
            AssignAttri("", false, "A2210AMRepVouAno", StringUtil.LTrimStr( (decimal)(A2210AMRepVouAno), 4, 0));
            A2211AMRepVouMes = T006Z3_A2211AMRepVouMes[0];
            AssignAttri("", false, "A2211AMRepVouMes", StringUtil.LTrimStr( (decimal)(A2211AMRepVouMes), 2, 0));
            A2207AMRepTASICod = T006Z3_A2207AMRepTASICod[0];
            AssignAttri("", false, "A2207AMRepTASICod", StringUtil.LTrimStr( (decimal)(A2207AMRepTASICod), 6, 0));
            A2212AMRepVouNum = T006Z3_A2212AMRepVouNum[0];
            AssignAttri("", false, "A2212AMRepVouNum", A2212AMRepVouNum);
            A2100ACTActCod = T006Z3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006Z3_A2104ActActItem[0];
            n2104ActActItem = T006Z3_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            Z2112AMRepCod = A2112AMRepCod;
            sMode193 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6Z193( ) ;
            if ( AnyError == 1 )
            {
               RcdFound193 = 0;
               InitializeNonKey6Z193( ) ;
            }
            Gx_mode = sMode193;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound193 = 0;
            InitializeNonKey6Z193( ) ;
            sMode193 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode193;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6Z193( ) ;
         if ( RcdFound193 == 0 )
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
         RcdFound193 = 0;
         /* Using cursor T006Z10 */
         pr_default.execute(8, new Object[] {A2112AMRepCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006Z10_A2112AMRepCod[0], A2112AMRepCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006Z10_A2112AMRepCod[0], A2112AMRepCod) > 0 ) ) )
            {
               A2112AMRepCod = T006Z10_A2112AMRepCod[0];
               AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
               RcdFound193 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound193 = 0;
         /* Using cursor T006Z11 */
         pr_default.execute(9, new Object[] {A2112AMRepCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006Z11_A2112AMRepCod[0], A2112AMRepCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006Z11_A2112AMRepCod[0], A2112AMRepCod) < 0 ) ) )
            {
               A2112AMRepCod = T006Z11_A2112AMRepCod[0];
               AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
               RcdFound193 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6Z193( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAMRepCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6Z193( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound193 == 1 )
            {
               if ( StringUtil.StrCmp(A2112AMRepCod, Z2112AMRepCod) != 0 )
               {
                  A2112AMRepCod = Z2112AMRepCod;
                  AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AMREPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAMRepCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAMRepCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6Z193( ) ;
                  GX_FocusControl = edtAMRepCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2112AMRepCod, Z2112AMRepCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAMRepCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6Z193( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AMREPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtAMRepCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAMRepCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6Z193( ) ;
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
         if ( StringUtil.StrCmp(A2112AMRepCod, Z2112AMRepCod) != 0 )
         {
            A2112AMRepCod = Z2112AMRepCod;
            AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AMREPCOD");
            AnyError = 1;
            GX_FocusControl = edtAMRepCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAMRepCod_Internalname;
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
         if ( RcdFound193 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AMREPCOD");
            AnyError = 1;
            GX_FocusControl = edtAMRepCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAMRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6Z193( ) ;
         if ( RcdFound193 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6Z193( ) ;
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
         if ( RcdFound193 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMRepFec_Internalname;
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
         if ( RcdFound193 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMRepFec_Internalname;
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
         ScanStart6Z193( ) ;
         if ( RcdFound193 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound193 != 0 )
            {
               ScanNext6Z193( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAMRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6Z193( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6Z193( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006Z2 */
            pr_default.execute(0, new Object[] {A2112AMRepCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTMOVREPARACION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2204AMRepFec ) != DateTimeUtil.ResetTime ( T006Z2_A2204AMRepFec[0] ) ) || ( StringUtil.StrCmp(Z2208AMRepTipo, T006Z2_A2208AMRepTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z2206AMRepObs, T006Z2_A2206AMRepObs[0]) != 0 ) || ( Z2209AMRepValor != T006Z2_A2209AMRepValor[0] ) || ( Z2205AMRepGrupCod != T006Z2_A2205AMRepGrupCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2210AMRepVouAno != T006Z2_A2210AMRepVouAno[0] ) || ( Z2211AMRepVouMes != T006Z2_A2211AMRepVouMes[0] ) || ( Z2207AMRepTASICod != T006Z2_A2207AMRepTASICod[0] ) || ( StringUtil.StrCmp(Z2212AMRepVouNum, T006Z2_A2212AMRepVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z2100ACTActCod, T006Z2_A2100ACTActCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2104ActActItem, T006Z2_A2104ActActItem[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2204AMRepFec ) != DateTimeUtil.ResetTime ( T006Z2_A2204AMRepFec[0] ) )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepFec");
                  GXUtil.WriteLogRaw("Old: ",Z2204AMRepFec);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2204AMRepFec[0]);
               }
               if ( StringUtil.StrCmp(Z2208AMRepTipo, T006Z2_A2208AMRepTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepTipo");
                  GXUtil.WriteLogRaw("Old: ",Z2208AMRepTipo);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2208AMRepTipo[0]);
               }
               if ( StringUtil.StrCmp(Z2206AMRepObs, T006Z2_A2206AMRepObs[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepObs");
                  GXUtil.WriteLogRaw("Old: ",Z2206AMRepObs);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2206AMRepObs[0]);
               }
               if ( Z2209AMRepValor != T006Z2_A2209AMRepValor[0] )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepValor");
                  GXUtil.WriteLogRaw("Old: ",Z2209AMRepValor);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2209AMRepValor[0]);
               }
               if ( Z2205AMRepGrupCod != T006Z2_A2205AMRepGrupCod[0] )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepGrupCod");
                  GXUtil.WriteLogRaw("Old: ",Z2205AMRepGrupCod);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2205AMRepGrupCod[0]);
               }
               if ( Z2210AMRepVouAno != T006Z2_A2210AMRepVouAno[0] )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z2210AMRepVouAno);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2210AMRepVouAno[0]);
               }
               if ( Z2211AMRepVouMes != T006Z2_A2211AMRepVouMes[0] )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z2211AMRepVouMes);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2211AMRepVouMes[0]);
               }
               if ( Z2207AMRepTASICod != T006Z2_A2207AMRepTASICod[0] )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z2207AMRepTASICod);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2207AMRepTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z2212AMRepVouNum, T006Z2_A2212AMRepVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"AMRepVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z2212AMRepVouNum);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2212AMRepVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z2100ACTActCod, T006Z2_A2100ACTActCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"ACTActCod");
                  GXUtil.WriteLogRaw("Old: ",Z2100ACTActCod);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2100ACTActCod[0]);
               }
               if ( StringUtil.StrCmp(Z2104ActActItem, T006Z2_A2104ActActItem[0]) != 0 )
               {
                  GXUtil.WriteLog("actmovreparacion:[seudo value changed for attri]"+"ActActItem");
                  GXUtil.WriteLogRaw("Old: ",Z2104ActActItem);
                  GXUtil.WriteLogRaw("Current: ",T006Z2_A2104ActActItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTMOVREPARACION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6Z193( )
      {
         BeforeValidate6Z193( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6Z193( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6Z193( 0) ;
            CheckOptimisticConcurrency6Z193( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6Z193( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6Z193( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006Z12 */
                     pr_default.execute(10, new Object[] {A2112AMRepCod, A2204AMRepFec, A2208AMRepTipo, A2206AMRepObs, A2209AMRepValor, A2205AMRepGrupCod, A2210AMRepVouAno, A2211AMRepVouMes, A2207AMRepTASICod, A2212AMRepVouNum, A2100ACTActCod, n2104ActActItem, A2104ActActItem});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTMOVREPARACION");
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
                           ResetCaption6Z0( ) ;
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
               Load6Z193( ) ;
            }
            EndLevel6Z193( ) ;
         }
         CloseExtendedTableCursors6Z193( ) ;
      }

      protected void Update6Z193( )
      {
         BeforeValidate6Z193( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6Z193( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6Z193( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6Z193( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6Z193( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006Z13 */
                     pr_default.execute(11, new Object[] {A2204AMRepFec, A2208AMRepTipo, A2206AMRepObs, A2209AMRepValor, A2205AMRepGrupCod, A2210AMRepVouAno, A2211AMRepVouMes, A2207AMRepTASICod, A2212AMRepVouNum, A2100ACTActCod, n2104ActActItem, A2104ActActItem, A2112AMRepCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTMOVREPARACION");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTMOVREPARACION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6Z193( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6Z0( ) ;
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
            EndLevel6Z193( ) ;
         }
         CloseExtendedTableCursors6Z193( ) ;
      }

      protected void DeferredUpdate6Z193( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6Z193( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6Z193( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6Z193( ) ;
            AfterConfirm6Z193( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6Z193( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006Z14 */
                  pr_default.execute(12, new Object[] {A2112AMRepCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTMOVREPARACION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound193 == 0 )
                        {
                           InitAll6Z193( ) ;
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
                        ResetCaption6Z0( ) ;
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
         sMode193 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6Z193( ) ;
         Gx_mode = sMode193;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6Z193( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006Z15 */
            pr_default.execute(13, new Object[] {A2100ACTActCod});
            A2122ACTActDsc = T006Z15_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            pr_default.close(13);
         }
      }

      protected void EndLevel6Z193( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6Z193( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("actmovreparacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("actmovreparacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6Z193( )
      {
         /* Using cursor T006Z16 */
         pr_default.execute(14);
         RcdFound193 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound193 = 1;
            A2112AMRepCod = T006Z16_A2112AMRepCod[0];
            AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6Z193( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound193 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound193 = 1;
            A2112AMRepCod = T006Z16_A2112AMRepCod[0];
            AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
         }
      }

      protected void ScanEnd6Z193( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm6Z193( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6Z193( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6Z193( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6Z193( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6Z193( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6Z193( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6Z193( )
      {
         edtAMRepCod_Enabled = 0;
         AssignProp("", false, edtAMRepCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepCod_Enabled), 5, 0), true);
         edtAMRepFec_Enabled = 0;
         AssignProp("", false, edtAMRepFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepFec_Enabled), 5, 0), true);
         edtAMRepTipo_Enabled = 0;
         AssignProp("", false, edtAMRepTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepTipo_Enabled), 5, 0), true);
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtACTActDsc_Enabled = 0;
         AssignProp("", false, edtACTActDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDsc_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtAMRepObs_Enabled = 0;
         AssignProp("", false, edtAMRepObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepObs_Enabled), 5, 0), true);
         edtAMRepValor_Enabled = 0;
         AssignProp("", false, edtAMRepValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepValor_Enabled), 5, 0), true);
         edtAMRepGrupCod_Enabled = 0;
         AssignProp("", false, edtAMRepGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepGrupCod_Enabled), 5, 0), true);
         edtAMRepVouAno_Enabled = 0;
         AssignProp("", false, edtAMRepVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepVouAno_Enabled), 5, 0), true);
         edtAMRepVouMes_Enabled = 0;
         AssignProp("", false, edtAMRepVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepVouMes_Enabled), 5, 0), true);
         edtAMRepTASICod_Enabled = 0;
         AssignProp("", false, edtAMRepTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepTASICod_Enabled), 5, 0), true);
         edtAMRepVouNum_Enabled = 0;
         AssignProp("", false, edtAMRepVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAMRepVouNum_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6Z193( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6Z0( )
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
         context.SendWebValue( "Reparacion de Activos Fijos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265333", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actmovreparacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2112AMRepCod", Z2112AMRepCod);
         GxWebStd.gx_hidden_field( context, "Z2204AMRepFec", context.localUtil.DToC( Z2204AMRepFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2208AMRepTipo", Z2208AMRepTipo);
         GxWebStd.gx_hidden_field( context, "Z2206AMRepObs", Z2206AMRepObs);
         GxWebStd.gx_hidden_field( context, "Z2209AMRepValor", StringUtil.LTrim( StringUtil.NToC( Z2209AMRepValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2205AMRepGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2205AMRepGrupCod), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2210AMRepVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2210AMRepVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2211AMRepVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2211AMRepVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2207AMRepTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2207AMRepTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2212AMRepVouNum", StringUtil.RTrim( Z2212AMRepVouNum));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm6Z193( )
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
         return "ACTMOVREPARACION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reparacion de Activos Fijos" ;
      }

      protected void InitializeNonKey6Z193( )
      {
         A2204AMRepFec = DateTime.MinValue;
         AssignAttri("", false, "A2204AMRepFec", context.localUtil.Format(A2204AMRepFec, "99/99/99"));
         A2208AMRepTipo = "";
         AssignAttri("", false, "A2208AMRepTipo", A2208AMRepTipo);
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2122ACTActDsc = "";
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A2104ActActItem = "";
         n2104ActActItem = false;
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
         A2206AMRepObs = "";
         AssignAttri("", false, "A2206AMRepObs", A2206AMRepObs);
         A2209AMRepValor = 0;
         AssignAttri("", false, "A2209AMRepValor", StringUtil.LTrimStr( A2209AMRepValor, 15, 2));
         A2205AMRepGrupCod = 0;
         AssignAttri("", false, "A2205AMRepGrupCod", StringUtil.LTrimStr( (decimal)(A2205AMRepGrupCod), 5, 0));
         A2210AMRepVouAno = 0;
         AssignAttri("", false, "A2210AMRepVouAno", StringUtil.LTrimStr( (decimal)(A2210AMRepVouAno), 4, 0));
         A2211AMRepVouMes = 0;
         AssignAttri("", false, "A2211AMRepVouMes", StringUtil.LTrimStr( (decimal)(A2211AMRepVouMes), 2, 0));
         A2207AMRepTASICod = 0;
         AssignAttri("", false, "A2207AMRepTASICod", StringUtil.LTrimStr( (decimal)(A2207AMRepTASICod), 6, 0));
         A2212AMRepVouNum = "";
         AssignAttri("", false, "A2212AMRepVouNum", A2212AMRepVouNum);
         Z2204AMRepFec = DateTime.MinValue;
         Z2208AMRepTipo = "";
         Z2206AMRepObs = "";
         Z2209AMRepValor = 0;
         Z2205AMRepGrupCod = 0;
         Z2210AMRepVouAno = 0;
         Z2211AMRepVouMes = 0;
         Z2207AMRepTASICod = 0;
         Z2212AMRepVouNum = "";
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
      }

      protected void InitAll6Z193( )
      {
         A2112AMRepCod = "";
         AssignAttri("", false, "A2112AMRepCod", A2112AMRepCod);
         InitializeNonKey6Z193( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265343", true, true);
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
         context.AddJavascriptSource("actmovreparacion.js", "?202281810265343", false, true);
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
         edtAMRepCod_Internalname = "AMREPCOD";
         edtAMRepFec_Internalname = "AMREPFEC";
         edtAMRepTipo_Internalname = "AMREPTIPO";
         edtACTActCod_Internalname = "ACTACTCOD";
         edtACTActDsc_Internalname = "ACTACTDSC";
         edtActActItem_Internalname = "ACTACTITEM";
         edtAMRepObs_Internalname = "AMREPOBS";
         edtAMRepValor_Internalname = "AMREPVALOR";
         edtAMRepGrupCod_Internalname = "AMREPGRUPCOD";
         edtAMRepVouAno_Internalname = "AMREPVOUANO";
         edtAMRepVouMes_Internalname = "AMREPVOUMES";
         edtAMRepTASICod_Internalname = "AMREPTASICOD";
         edtAMRepVouNum_Internalname = "AMREPVOUNUM";
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
         edtAMRepVouNum_Jsonclick = "";
         edtAMRepVouNum_Enabled = 1;
         edtAMRepTASICod_Jsonclick = "";
         edtAMRepTASICod_Enabled = 1;
         edtAMRepVouMes_Jsonclick = "";
         edtAMRepVouMes_Enabled = 1;
         edtAMRepVouAno_Jsonclick = "";
         edtAMRepVouAno_Enabled = 1;
         edtAMRepGrupCod_Jsonclick = "";
         edtAMRepGrupCod_Enabled = 1;
         edtAMRepValor_Jsonclick = "";
         edtAMRepValor_Enabled = 1;
         edtAMRepObs_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActDsc_Jsonclick = "";
         edtACTActDsc_Enabled = 0;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
         edtAMRepTipo_Jsonclick = "";
         edtAMRepTipo_Enabled = 1;
         edtAMRepFec_Jsonclick = "";
         edtAMRepFec_Enabled = 1;
         edtAMRepCod_Jsonclick = "";
         edtAMRepCod_Enabled = 1;
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
         GX_FocusControl = edtAMRepFec_Internalname;
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

      public void Valid_Amrepcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2204AMRepFec", context.localUtil.Format(A2204AMRepFec, "99/99/99"));
         AssignAttri("", false, "A2208AMRepTipo", A2208AMRepTipo);
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         AssignAttri("", false, "A2206AMRepObs", A2206AMRepObs);
         AssignAttri("", false, "A2209AMRepValor", StringUtil.LTrim( StringUtil.NToC( A2209AMRepValor, 15, 2, ".", "")));
         AssignAttri("", false, "A2205AMRepGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2205AMRepGrupCod), 5, 0, ".", "")));
         AssignAttri("", false, "A2210AMRepVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2210AMRepVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A2211AMRepVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2211AMRepVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A2207AMRepTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2207AMRepTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A2212AMRepVouNum", StringUtil.RTrim( A2212AMRepVouNum));
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2112AMRepCod", Z2112AMRepCod);
         GxWebStd.gx_hidden_field( context, "Z2204AMRepFec", context.localUtil.Format(Z2204AMRepFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2208AMRepTipo", Z2208AMRepTipo);
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2206AMRepObs", Z2206AMRepObs);
         GxWebStd.gx_hidden_field( context, "Z2209AMRepValor", StringUtil.LTrim( StringUtil.NToC( Z2209AMRepValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2205AMRepGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2205AMRepGrupCod), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2210AMRepVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2210AMRepVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2211AMRepVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2211AMRepVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2207AMRepTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2207AMRepTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2212AMRepVouNum", StringUtil.RTrim( Z2212AMRepVouNum));
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actactcod( )
      {
         /* Using cursor T006Z15 */
         pr_default.execute(13, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         A2122ACTActDsc = T006Z15_A2122ACTActDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
      }

      public void Valid_Actactitem( )
      {
         n2104ActActItem = false;
         /* Using cursor T006Z17 */
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
         setEventMetadata("VALID_AMREPCOD","{handler:'Valid_Amrepcod',iparms:[{av:'A2112AMRepCod',fld:'AMREPCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_AMREPCOD",",oparms:[{av:'A2204AMRepFec',fld:'AMREPFEC',pic:''},{av:'A2208AMRepTipo',fld:'AMREPTIPO',pic:''},{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'A2206AMRepObs',fld:'AMREPOBS',pic:''},{av:'A2209AMRepValor',fld:'AMREPVALOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2205AMRepGrupCod',fld:'AMREPGRUPCOD',pic:'ZZZZ9'},{av:'A2210AMRepVouAno',fld:'AMREPVOUANO',pic:'ZZZ9'},{av:'A2211AMRepVouMes',fld:'AMREPVOUMES',pic:'Z9'},{av:'A2207AMRepTASICod',fld:'AMREPTASICOD',pic:'ZZZZZ9'},{av:'A2212AMRepVouNum',fld:'AMREPVOUNUM',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2112AMRepCod'},{av:'Z2204AMRepFec'},{av:'Z2208AMRepTipo'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2206AMRepObs'},{av:'Z2209AMRepValor'},{av:'Z2205AMRepGrupCod'},{av:'Z2210AMRepVouAno'},{av:'Z2211AMRepVouMes'},{av:'Z2207AMRepTASICod'},{av:'Z2212AMRepVouNum'},{av:'Z2122ACTActDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_AMREPFEC","{handler:'Valid_Amrepfec',iparms:[]");
         setEventMetadata("VALID_AMREPFEC",",oparms:[]}");
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
         Z2112AMRepCod = "";
         Z2204AMRepFec = DateTime.MinValue;
         Z2208AMRepTipo = "";
         Z2206AMRepObs = "";
         Z2212AMRepVouNum = "";
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
         A2112AMRepCod = "";
         A2204AMRepFec = DateTime.MinValue;
         A2208AMRepTipo = "";
         A2122ACTActDsc = "";
         A2206AMRepObs = "";
         A2212AMRepVouNum = "";
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
         T006Z6_A2112AMRepCod = new string[] {""} ;
         T006Z6_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         T006Z6_A2208AMRepTipo = new string[] {""} ;
         T006Z6_A2122ACTActDsc = new string[] {""} ;
         T006Z6_A2206AMRepObs = new string[] {""} ;
         T006Z6_A2209AMRepValor = new decimal[1] ;
         T006Z6_A2205AMRepGrupCod = new int[1] ;
         T006Z6_A2210AMRepVouAno = new short[1] ;
         T006Z6_A2211AMRepVouMes = new short[1] ;
         T006Z6_A2207AMRepTASICod = new int[1] ;
         T006Z6_A2212AMRepVouNum = new string[] {""} ;
         T006Z6_A2100ACTActCod = new string[] {""} ;
         T006Z6_A2104ActActItem = new string[] {""} ;
         T006Z6_n2104ActActItem = new bool[] {false} ;
         T006Z4_A2122ACTActDsc = new string[] {""} ;
         T006Z5_A2100ACTActCod = new string[] {""} ;
         T006Z7_A2122ACTActDsc = new string[] {""} ;
         T006Z8_A2100ACTActCod = new string[] {""} ;
         T006Z9_A2112AMRepCod = new string[] {""} ;
         T006Z3_A2112AMRepCod = new string[] {""} ;
         T006Z3_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         T006Z3_A2208AMRepTipo = new string[] {""} ;
         T006Z3_A2206AMRepObs = new string[] {""} ;
         T006Z3_A2209AMRepValor = new decimal[1] ;
         T006Z3_A2205AMRepGrupCod = new int[1] ;
         T006Z3_A2210AMRepVouAno = new short[1] ;
         T006Z3_A2211AMRepVouMes = new short[1] ;
         T006Z3_A2207AMRepTASICod = new int[1] ;
         T006Z3_A2212AMRepVouNum = new string[] {""} ;
         T006Z3_A2100ACTActCod = new string[] {""} ;
         T006Z3_A2104ActActItem = new string[] {""} ;
         T006Z3_n2104ActActItem = new bool[] {false} ;
         sMode193 = "";
         T006Z10_A2112AMRepCod = new string[] {""} ;
         T006Z11_A2112AMRepCod = new string[] {""} ;
         T006Z2_A2112AMRepCod = new string[] {""} ;
         T006Z2_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         T006Z2_A2208AMRepTipo = new string[] {""} ;
         T006Z2_A2206AMRepObs = new string[] {""} ;
         T006Z2_A2209AMRepValor = new decimal[1] ;
         T006Z2_A2205AMRepGrupCod = new int[1] ;
         T006Z2_A2210AMRepVouAno = new short[1] ;
         T006Z2_A2211AMRepVouMes = new short[1] ;
         T006Z2_A2207AMRepTASICod = new int[1] ;
         T006Z2_A2212AMRepVouNum = new string[] {""} ;
         T006Z2_A2100ACTActCod = new string[] {""} ;
         T006Z2_A2104ActActItem = new string[] {""} ;
         T006Z2_n2104ActActItem = new bool[] {false} ;
         T006Z15_A2122ACTActDsc = new string[] {""} ;
         T006Z16_A2112AMRepCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2112AMRepCod = "";
         ZZ2204AMRepFec = DateTime.MinValue;
         ZZ2208AMRepTipo = "";
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2206AMRepObs = "";
         ZZ2212AMRepVouNum = "";
         ZZ2122ACTActDsc = "";
         T006Z17_A2100ACTActCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actmovreparacion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actmovreparacion__default(),
            new Object[][] {
                new Object[] {
               T006Z2_A2112AMRepCod, T006Z2_A2204AMRepFec, T006Z2_A2208AMRepTipo, T006Z2_A2206AMRepObs, T006Z2_A2209AMRepValor, T006Z2_A2205AMRepGrupCod, T006Z2_A2210AMRepVouAno, T006Z2_A2211AMRepVouMes, T006Z2_A2207AMRepTASICod, T006Z2_A2212AMRepVouNum,
               T006Z2_A2100ACTActCod, T006Z2_A2104ActActItem, T006Z2_n2104ActActItem
               }
               , new Object[] {
               T006Z3_A2112AMRepCod, T006Z3_A2204AMRepFec, T006Z3_A2208AMRepTipo, T006Z3_A2206AMRepObs, T006Z3_A2209AMRepValor, T006Z3_A2205AMRepGrupCod, T006Z3_A2210AMRepVouAno, T006Z3_A2211AMRepVouMes, T006Z3_A2207AMRepTASICod, T006Z3_A2212AMRepVouNum,
               T006Z3_A2100ACTActCod, T006Z3_A2104ActActItem, T006Z3_n2104ActActItem
               }
               , new Object[] {
               T006Z4_A2122ACTActDsc
               }
               , new Object[] {
               T006Z5_A2100ACTActCod
               }
               , new Object[] {
               T006Z6_A2112AMRepCod, T006Z6_A2204AMRepFec, T006Z6_A2208AMRepTipo, T006Z6_A2122ACTActDsc, T006Z6_A2206AMRepObs, T006Z6_A2209AMRepValor, T006Z6_A2205AMRepGrupCod, T006Z6_A2210AMRepVouAno, T006Z6_A2211AMRepVouMes, T006Z6_A2207AMRepTASICod,
               T006Z6_A2212AMRepVouNum, T006Z6_A2100ACTActCod, T006Z6_A2104ActActItem, T006Z6_n2104ActActItem
               }
               , new Object[] {
               T006Z7_A2122ACTActDsc
               }
               , new Object[] {
               T006Z8_A2100ACTActCod
               }
               , new Object[] {
               T006Z9_A2112AMRepCod
               }
               , new Object[] {
               T006Z10_A2112AMRepCod
               }
               , new Object[] {
               T006Z11_A2112AMRepCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006Z15_A2122ACTActDsc
               }
               , new Object[] {
               T006Z16_A2112AMRepCod
               }
               , new Object[] {
               T006Z17_A2100ACTActCod
               }
            }
         );
      }

      private short Z2210AMRepVouAno ;
      private short Z2211AMRepVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2210AMRepVouAno ;
      private short A2211AMRepVouMes ;
      private short GX_JID ;
      private short RcdFound193 ;
      private short nIsDirty_193 ;
      private short Gx_BScreen ;
      private short ZZ2210AMRepVouAno ;
      private short ZZ2211AMRepVouMes ;
      private int Z2205AMRepGrupCod ;
      private int Z2207AMRepTASICod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAMRepCod_Enabled ;
      private int edtAMRepFec_Enabled ;
      private int edtAMRepTipo_Enabled ;
      private int edtACTActCod_Enabled ;
      private int edtACTActDsc_Enabled ;
      private int edtActActItem_Enabled ;
      private int edtAMRepObs_Enabled ;
      private int edtAMRepValor_Enabled ;
      private int A2205AMRepGrupCod ;
      private int edtAMRepGrupCod_Enabled ;
      private int edtAMRepVouAno_Enabled ;
      private int edtAMRepVouMes_Enabled ;
      private int A2207AMRepTASICod ;
      private int edtAMRepTASICod_Enabled ;
      private int edtAMRepVouNum_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2205AMRepGrupCod ;
      private int ZZ2207AMRepTASICod ;
      private decimal Z2209AMRepValor ;
      private decimal A2209AMRepValor ;
      private decimal ZZ2209AMRepValor ;
      private string sPrefix ;
      private string Z2212AMRepVouNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAMRepCod_Internalname ;
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
      private string edtAMRepCod_Jsonclick ;
      private string edtAMRepFec_Internalname ;
      private string edtAMRepFec_Jsonclick ;
      private string edtAMRepTipo_Internalname ;
      private string edtAMRepTipo_Jsonclick ;
      private string edtACTActCod_Internalname ;
      private string edtACTActCod_Jsonclick ;
      private string edtACTActDsc_Internalname ;
      private string edtACTActDsc_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtAMRepObs_Internalname ;
      private string edtAMRepValor_Internalname ;
      private string edtAMRepValor_Jsonclick ;
      private string edtAMRepGrupCod_Internalname ;
      private string edtAMRepGrupCod_Jsonclick ;
      private string edtAMRepVouAno_Internalname ;
      private string edtAMRepVouAno_Jsonclick ;
      private string edtAMRepVouMes_Internalname ;
      private string edtAMRepVouMes_Jsonclick ;
      private string edtAMRepTASICod_Internalname ;
      private string edtAMRepTASICod_Jsonclick ;
      private string edtAMRepVouNum_Internalname ;
      private string A2212AMRepVouNum ;
      private string edtAMRepVouNum_Jsonclick ;
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
      private string sMode193 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2212AMRepVouNum ;
      private DateTime Z2204AMRepFec ;
      private DateTime A2204AMRepFec ;
      private DateTime ZZ2204AMRepFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2104ActActItem ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2112AMRepCod ;
      private string Z2208AMRepTipo ;
      private string Z2206AMRepObs ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2112AMRepCod ;
      private string A2208AMRepTipo ;
      private string A2122ACTActDsc ;
      private string A2206AMRepObs ;
      private string Z2122ACTActDsc ;
      private string ZZ2112AMRepCod ;
      private string ZZ2208AMRepTipo ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private string ZZ2206AMRepObs ;
      private string ZZ2122ACTActDsc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006Z6_A2112AMRepCod ;
      private DateTime[] T006Z6_A2204AMRepFec ;
      private string[] T006Z6_A2208AMRepTipo ;
      private string[] T006Z6_A2122ACTActDsc ;
      private string[] T006Z6_A2206AMRepObs ;
      private decimal[] T006Z6_A2209AMRepValor ;
      private int[] T006Z6_A2205AMRepGrupCod ;
      private short[] T006Z6_A2210AMRepVouAno ;
      private short[] T006Z6_A2211AMRepVouMes ;
      private int[] T006Z6_A2207AMRepTASICod ;
      private string[] T006Z6_A2212AMRepVouNum ;
      private string[] T006Z6_A2100ACTActCod ;
      private string[] T006Z6_A2104ActActItem ;
      private bool[] T006Z6_n2104ActActItem ;
      private string[] T006Z4_A2122ACTActDsc ;
      private string[] T006Z5_A2100ACTActCod ;
      private string[] T006Z7_A2122ACTActDsc ;
      private string[] T006Z8_A2100ACTActCod ;
      private string[] T006Z9_A2112AMRepCod ;
      private string[] T006Z3_A2112AMRepCod ;
      private DateTime[] T006Z3_A2204AMRepFec ;
      private string[] T006Z3_A2208AMRepTipo ;
      private string[] T006Z3_A2206AMRepObs ;
      private decimal[] T006Z3_A2209AMRepValor ;
      private int[] T006Z3_A2205AMRepGrupCod ;
      private short[] T006Z3_A2210AMRepVouAno ;
      private short[] T006Z3_A2211AMRepVouMes ;
      private int[] T006Z3_A2207AMRepTASICod ;
      private string[] T006Z3_A2212AMRepVouNum ;
      private string[] T006Z3_A2100ACTActCod ;
      private string[] T006Z3_A2104ActActItem ;
      private bool[] T006Z3_n2104ActActItem ;
      private string[] T006Z10_A2112AMRepCod ;
      private string[] T006Z11_A2112AMRepCod ;
      private string[] T006Z2_A2112AMRepCod ;
      private DateTime[] T006Z2_A2204AMRepFec ;
      private string[] T006Z2_A2208AMRepTipo ;
      private string[] T006Z2_A2206AMRepObs ;
      private decimal[] T006Z2_A2209AMRepValor ;
      private int[] T006Z2_A2205AMRepGrupCod ;
      private short[] T006Z2_A2210AMRepVouAno ;
      private short[] T006Z2_A2211AMRepVouMes ;
      private int[] T006Z2_A2207AMRepTASICod ;
      private string[] T006Z2_A2212AMRepVouNum ;
      private string[] T006Z2_A2100ACTActCod ;
      private string[] T006Z2_A2104ActActItem ;
      private bool[] T006Z2_n2104ActActItem ;
      private string[] T006Z15_A2122ACTActDsc ;
      private string[] T006Z16_A2112AMRepCod ;
      private string[] T006Z17_A2100ACTActCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actmovreparacion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actmovreparacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT006Z6;
        prmT006Z6 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z4;
        prmT006Z4 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Z5;
        prmT006Z5 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Z7;
        prmT006Z7 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Z8;
        prmT006Z8 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Z9;
        prmT006Z9 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z3;
        prmT006Z3 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z10;
        prmT006Z10 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z11;
        prmT006Z11 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z2;
        prmT006Z2 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z12;
        prmT006Z12 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0) ,
        new ParDef("@AMRepFec",GXType.Date,8,0) ,
        new ParDef("@AMRepTipo",GXType.NVarChar,40,0) ,
        new ParDef("@AMRepObs",GXType.NVarChar,500,0) ,
        new ParDef("@AMRepValor",GXType.Decimal,15,2) ,
        new ParDef("@AMRepGrupCod",GXType.Int32,5,0) ,
        new ParDef("@AMRepVouAno",GXType.Int16,4,0) ,
        new ParDef("@AMRepVouMes",GXType.Int16,2,0) ,
        new ParDef("@AMRepTASICod",GXType.Int32,6,0) ,
        new ParDef("@AMRepVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006Z13;
        prmT006Z13 = new Object[] {
        new ParDef("@AMRepFec",GXType.Date,8,0) ,
        new ParDef("@AMRepTipo",GXType.NVarChar,40,0) ,
        new ParDef("@AMRepObs",GXType.NVarChar,500,0) ,
        new ParDef("@AMRepValor",GXType.Decimal,15,2) ,
        new ParDef("@AMRepGrupCod",GXType.Int32,5,0) ,
        new ParDef("@AMRepVouAno",GXType.Int16,4,0) ,
        new ParDef("@AMRepVouMes",GXType.Int16,2,0) ,
        new ParDef("@AMRepTASICod",GXType.Int32,6,0) ,
        new ParDef("@AMRepVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z14;
        prmT006Z14 = new Object[] {
        new ParDef("@AMRepCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006Z16;
        prmT006Z16 = new Object[] {
        };
        Object[] prmT006Z15;
        prmT006Z15 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006Z17;
        prmT006Z17 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006Z2", "SELECT [AMRepCod], [AMRepFec], [AMRepTipo], [AMRepObs], [AMRepValor], [AMRepGrupCod], [AMRepVouAno], [AMRepVouMes], [AMRepTASICod], [AMRepVouNum], [ACTActCod], [ActActItem] FROM [ACTMOVREPARACION] WITH (UPDLOCK) WHERE [AMRepCod] = @AMRepCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z3", "SELECT [AMRepCod], [AMRepFec], [AMRepTipo], [AMRepObs], [AMRepValor], [AMRepGrupCod], [AMRepVouAno], [AMRepVouMes], [AMRepTASICod], [AMRepVouNum], [ACTActCod], [ActActItem] FROM [ACTMOVREPARACION] WHERE [AMRepCod] = @AMRepCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z4", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z5", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z6", "SELECT TM1.[AMRepCod], TM1.[AMRepFec], TM1.[AMRepTipo], T2.[ACTActDsc], TM1.[AMRepObs], TM1.[AMRepValor], TM1.[AMRepGrupCod], TM1.[AMRepVouAno], TM1.[AMRepVouMes], TM1.[AMRepTASICod], TM1.[AMRepVouNum], TM1.[ACTActCod], TM1.[ActActItem] FROM ([ACTMOVREPARACION] TM1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = TM1.[ACTActCod]) WHERE TM1.[AMRepCod] = @AMRepCod ORDER BY TM1.[AMRepCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z7", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z8", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z9", "SELECT [AMRepCod] FROM [ACTMOVREPARACION] WHERE [AMRepCod] = @AMRepCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z10", "SELECT TOP 1 [AMRepCod] FROM [ACTMOVREPARACION] WHERE ( [AMRepCod] > @AMRepCod) ORDER BY [AMRepCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Z11", "SELECT TOP 1 [AMRepCod] FROM [ACTMOVREPARACION] WHERE ( [AMRepCod] < @AMRepCod) ORDER BY [AMRepCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006Z12", "INSERT INTO [ACTMOVREPARACION]([AMRepCod], [AMRepFec], [AMRepTipo], [AMRepObs], [AMRepValor], [AMRepGrupCod], [AMRepVouAno], [AMRepVouMes], [AMRepTASICod], [AMRepVouNum], [ACTActCod], [ActActItem]) VALUES(@AMRepCod, @AMRepFec, @AMRepTipo, @AMRepObs, @AMRepValor, @AMRepGrupCod, @AMRepVouAno, @AMRepVouMes, @AMRepTASICod, @AMRepVouNum, @ACTActCod, @ActActItem)", GxErrorMask.GX_NOMASK,prmT006Z12)
           ,new CursorDef("T006Z13", "UPDATE [ACTMOVREPARACION] SET [AMRepFec]=@AMRepFec, [AMRepTipo]=@AMRepTipo, [AMRepObs]=@AMRepObs, [AMRepValor]=@AMRepValor, [AMRepGrupCod]=@AMRepGrupCod, [AMRepVouAno]=@AMRepVouAno, [AMRepVouMes]=@AMRepVouMes, [AMRepTASICod]=@AMRepTASICod, [AMRepVouNum]=@AMRepVouNum, [ACTActCod]=@ACTActCod, [ActActItem]=@ActActItem  WHERE [AMRepCod] = @AMRepCod", GxErrorMask.GX_NOMASK,prmT006Z13)
           ,new CursorDef("T006Z14", "DELETE FROM [ACTMOVREPARACION]  WHERE [AMRepCod] = @AMRepCod", GxErrorMask.GX_NOMASK,prmT006Z14)
           ,new CursorDef("T006Z15", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z16", "SELECT [AMRepCod] FROM [ACTMOVREPARACION] ORDER BY [AMRepCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006Z17", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006Z17,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
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
