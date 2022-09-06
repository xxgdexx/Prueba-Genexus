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
   public class actretiroactivo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
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
            gxLoad_5( A2100ACTActCod, A2104ActActItem) ;
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
            Form.Meta.addItem("description", "Retiro de Activo Fijos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actretiroactivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actretiroactivo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Retiro de Activo Fijos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTRETIROACTIVO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTRETIROACTIVO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetCod_Internalname, "Retiro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetCod_Internalname, A2105ACTRetCod, StringUtil.RTrim( context.localUtil.Format( A2105ACTRetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTRetFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTRetFec_Internalname, context.localUtil.Format(A2159ACTRetFec, "99/99/99"), context.localUtil.Format( A2159ACTRetFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_bitmap( context, edtACTRetFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTRetFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTRETIROACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTRETIROACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtACTActDsc_Internalname, A2122ACTActDsc, StringUtil.RTrim( context.localUtil.Format( A2122ACTActDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTRETIROACTIVO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetGrupCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetGrupCod_Internalname, "Componente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetGrupCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2160ACTRetGrupCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTRetGrupCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2160ACTRetGrupCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2160ACTRetGrupCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetGrupCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetObs_Internalname, "Observaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtACTRetObs_Internalname, A2161ACTRetObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtACTRetObs_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetCosto_Internalname, "Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A2157ACTRetCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTRetCosto_Enabled!=0) ? context.localUtil.Format( A2157ACTRetCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2157ACTRetCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetVouAno_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2169ACTRetVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtACTRetVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2169ACTRetVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2169ACTRetVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetVouMes_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2170ACTRetVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtACTRetVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2170ACTRetVouMes), "Z9") : context.localUtil.Format( (decimal)(A2170ACTRetVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetTASICod_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2167ACTRetTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTRetTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2167ACTRetTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2167ACTRetTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetVouNum_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetVouNum_Internalname, StringUtil.RTrim( A2171ACTRetVouNum), StringUtil.RTrim( context.localUtil.Format( A2171ACTRetVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetValRes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetValRes_Internalname, "Residual", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetValRes_Internalname, StringUtil.LTrim( StringUtil.NToC( A2168ACTRetValRes, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTRetValRes_Enabled!=0) ? context.localUtil.Format( A2168ACTRetValRes, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2168ACTRetValRes, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetValRes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetValRes_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetDepre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetDepre_Internalname, "Acum.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetDepre_Internalname, StringUtil.LTrim( StringUtil.NToC( A2158ACTRetDepre, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTRetDepre_Enabled!=0) ? context.localUtil.Format( A2158ACTRetDepre, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2158ACTRetDepre, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetDepre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetDepre_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetRetFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetRetFec_Internalname, "Retorno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACTRetRetFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACTRetRetFec_Internalname, context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"), context.localUtil.Format( A2162ACTRetRetFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetRetFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetRetFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_bitmap( context, edtACTRetRetFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACTRetRetFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTRETIROACTIVO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetRetVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetRetVouNum_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetRetVouNum_Internalname, StringUtil.RTrim( A2166ACTRetRetVouNum), StringUtil.RTrim( context.localUtil.Format( A2166ACTRetRetVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetRetVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetRetVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetRetTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetRetTASICod_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetRetTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2163ACTRetRetTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTRetRetTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2163ACTRetRetTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2163ACTRetRetTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetRetTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetRetTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetRetVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetRetVouAno_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetRetVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2164ACTRetRetVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtACTRetRetVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2164ACTRetRetVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2164ACTRetRetVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetRetVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetRetVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTRetRetVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTRetRetVouMes_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTRetRetVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2165ACTRetRetVouMes), 1, 0, ".", "")), StringUtil.LTrim( ((edtACTRetRetVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2165ACTRetRetVouMes), "9") : context.localUtil.Format( (decimal)(A2165ACTRetRetVouMes), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTRetRetVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTRetRetVouMes_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTRETIROACTIVO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTRETIROACTIVO.htm");
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
            Z2105ACTRetCod = cgiGet( "Z2105ACTRetCod");
            Z2159ACTRetFec = context.localUtil.CToD( cgiGet( "Z2159ACTRetFec"), 0);
            Z2160ACTRetGrupCod = (int)(context.localUtil.CToN( cgiGet( "Z2160ACTRetGrupCod"), ".", ","));
            n2160ACTRetGrupCod = ((0==A2160ACTRetGrupCod) ? true : false);
            Z2157ACTRetCosto = context.localUtil.CToN( cgiGet( "Z2157ACTRetCosto"), ".", ",");
            Z2169ACTRetVouAno = (short)(context.localUtil.CToN( cgiGet( "Z2169ACTRetVouAno"), ".", ","));
            Z2170ACTRetVouMes = (short)(context.localUtil.CToN( cgiGet( "Z2170ACTRetVouMes"), ".", ","));
            Z2167ACTRetTASICod = (int)(context.localUtil.CToN( cgiGet( "Z2167ACTRetTASICod"), ".", ","));
            Z2171ACTRetVouNum = cgiGet( "Z2171ACTRetVouNum");
            Z2168ACTRetValRes = context.localUtil.CToN( cgiGet( "Z2168ACTRetValRes"), ".", ",");
            Z2158ACTRetDepre = context.localUtil.CToN( cgiGet( "Z2158ACTRetDepre"), ".", ",");
            Z2162ACTRetRetFec = context.localUtil.CToD( cgiGet( "Z2162ACTRetRetFec"), 0);
            Z2166ACTRetRetVouNum = cgiGet( "Z2166ACTRetRetVouNum");
            Z2163ACTRetRetTASICod = (int)(context.localUtil.CToN( cgiGet( "Z2163ACTRetRetTASICod"), ".", ","));
            Z2164ACTRetRetVouAno = (short)(context.localUtil.CToN( cgiGet( "Z2164ACTRetRetVouAno"), ".", ","));
            Z2165ACTRetRetVouMes = (short)(context.localUtil.CToN( cgiGet( "Z2165ACTRetRetVouMes"), ".", ","));
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2105ACTRetCod = cgiGet( edtACTRetCod_Internalname);
            AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
            if ( context.localUtil.VCDate( cgiGet( edtACTRetFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "ACTRETFEC");
               AnyError = 1;
               GX_FocusControl = edtACTRetFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2159ACTRetFec = DateTime.MinValue;
               AssignAttri("", false, "A2159ACTRetFec", context.localUtil.Format(A2159ACTRetFec, "99/99/99"));
            }
            else
            {
               A2159ACTRetFec = context.localUtil.CToD( cgiGet( edtACTRetFec_Internalname), 2);
               AssignAttri("", false, "A2159ACTRetFec", context.localUtil.Format(A2159ACTRetFec, "99/99/99"));
            }
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2122ACTActDsc = cgiGet( edtACTActDsc_Internalname);
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            n2104ActActItem = false;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetGrupCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetGrupCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETGRUPCOD");
               AnyError = 1;
               GX_FocusControl = edtACTRetGrupCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2160ACTRetGrupCod = 0;
               n2160ACTRetGrupCod = false;
               AssignAttri("", false, "A2160ACTRetGrupCod", StringUtil.LTrimStr( (decimal)(A2160ACTRetGrupCod), 6, 0));
            }
            else
            {
               A2160ACTRetGrupCod = (int)(context.localUtil.CToN( cgiGet( edtACTRetGrupCod_Internalname), ".", ","));
               n2160ACTRetGrupCod = false;
               AssignAttri("", false, "A2160ACTRetGrupCod", StringUtil.LTrimStr( (decimal)(A2160ACTRetGrupCod), 6, 0));
            }
            n2160ACTRetGrupCod = ((0==A2160ACTRetGrupCod) ? true : false);
            A2161ACTRetObs = cgiGet( edtACTRetObs_Internalname);
            AssignAttri("", false, "A2161ACTRetObs", A2161ACTRetObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETCOSTO");
               AnyError = 1;
               GX_FocusControl = edtACTRetCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2157ACTRetCosto = 0;
               AssignAttri("", false, "A2157ACTRetCosto", StringUtil.LTrimStr( A2157ACTRetCosto, 15, 2));
            }
            else
            {
               A2157ACTRetCosto = context.localUtil.CToN( cgiGet( edtACTRetCosto_Internalname), ".", ",");
               AssignAttri("", false, "A2157ACTRetCosto", StringUtil.LTrimStr( A2157ACTRetCosto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETVOUANO");
               AnyError = 1;
               GX_FocusControl = edtACTRetVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2169ACTRetVouAno = 0;
               AssignAttri("", false, "A2169ACTRetVouAno", StringUtil.LTrimStr( (decimal)(A2169ACTRetVouAno), 4, 0));
            }
            else
            {
               A2169ACTRetVouAno = (short)(context.localUtil.CToN( cgiGet( edtACTRetVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A2169ACTRetVouAno", StringUtil.LTrimStr( (decimal)(A2169ACTRetVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETVOUMES");
               AnyError = 1;
               GX_FocusControl = edtACTRetVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2170ACTRetVouMes = 0;
               AssignAttri("", false, "A2170ACTRetVouMes", StringUtil.LTrimStr( (decimal)(A2170ACTRetVouMes), 2, 0));
            }
            else
            {
               A2170ACTRetVouMes = (short)(context.localUtil.CToN( cgiGet( edtACTRetVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A2170ACTRetVouMes", StringUtil.LTrimStr( (decimal)(A2170ACTRetVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETTASICOD");
               AnyError = 1;
               GX_FocusControl = edtACTRetTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2167ACTRetTASICod = 0;
               AssignAttri("", false, "A2167ACTRetTASICod", StringUtil.LTrimStr( (decimal)(A2167ACTRetTASICod), 6, 0));
            }
            else
            {
               A2167ACTRetTASICod = (int)(context.localUtil.CToN( cgiGet( edtACTRetTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A2167ACTRetTASICod", StringUtil.LTrimStr( (decimal)(A2167ACTRetTASICod), 6, 0));
            }
            A2171ACTRetVouNum = cgiGet( edtACTRetVouNum_Internalname);
            AssignAttri("", false, "A2171ACTRetVouNum", A2171ACTRetVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetValRes_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetValRes_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETVALRES");
               AnyError = 1;
               GX_FocusControl = edtACTRetValRes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2168ACTRetValRes = 0;
               AssignAttri("", false, "A2168ACTRetValRes", StringUtil.LTrimStr( A2168ACTRetValRes, 15, 2));
            }
            else
            {
               A2168ACTRetValRes = context.localUtil.CToN( cgiGet( edtACTRetValRes_Internalname), ".", ",");
               AssignAttri("", false, "A2168ACTRetValRes", StringUtil.LTrimStr( A2168ACTRetValRes, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetDepre_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetDepre_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETDEPRE");
               AnyError = 1;
               GX_FocusControl = edtACTRetDepre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2158ACTRetDepre = 0;
               AssignAttri("", false, "A2158ACTRetDepre", StringUtil.LTrimStr( A2158ACTRetDepre, 15, 2));
            }
            else
            {
               A2158ACTRetDepre = context.localUtil.CToN( cgiGet( edtACTRetDepre_Internalname), ".", ",");
               AssignAttri("", false, "A2158ACTRetDepre", StringUtil.LTrimStr( A2158ACTRetDepre, 15, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtACTRetRetFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Retorno"}), 1, "ACTRETRETFEC");
               AnyError = 1;
               GX_FocusControl = edtACTRetRetFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2162ACTRetRetFec = DateTime.MinValue;
               AssignAttri("", false, "A2162ACTRetRetFec", context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"));
            }
            else
            {
               A2162ACTRetRetFec = context.localUtil.CToD( cgiGet( edtACTRetRetFec_Internalname), 2);
               AssignAttri("", false, "A2162ACTRetRetFec", context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"));
            }
            A2166ACTRetRetVouNum = cgiGet( edtACTRetRetVouNum_Internalname);
            AssignAttri("", false, "A2166ACTRetRetVouNum", A2166ACTRetRetVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetRetTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetRetTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETRETTASICOD");
               AnyError = 1;
               GX_FocusControl = edtACTRetRetTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2163ACTRetRetTASICod = 0;
               AssignAttri("", false, "A2163ACTRetRetTASICod", StringUtil.LTrimStr( (decimal)(A2163ACTRetRetTASICod), 6, 0));
            }
            else
            {
               A2163ACTRetRetTASICod = (int)(context.localUtil.CToN( cgiGet( edtACTRetRetTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A2163ACTRetRetTASICod", StringUtil.LTrimStr( (decimal)(A2163ACTRetRetTASICod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetRetVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetRetVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETRETVOUANO");
               AnyError = 1;
               GX_FocusControl = edtACTRetRetVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2164ACTRetRetVouAno = 0;
               AssignAttri("", false, "A2164ACTRetRetVouAno", StringUtil.LTrimStr( (decimal)(A2164ACTRetRetVouAno), 4, 0));
            }
            else
            {
               A2164ACTRetRetVouAno = (short)(context.localUtil.CToN( cgiGet( edtACTRetRetVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A2164ACTRetRetVouAno", StringUtil.LTrimStr( (decimal)(A2164ACTRetRetVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTRetRetVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTRetRetVouMes_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTRETRETVOUMES");
               AnyError = 1;
               GX_FocusControl = edtACTRetRetVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2165ACTRetRetVouMes = 0;
               AssignAttri("", false, "A2165ACTRetRetVouMes", StringUtil.Str( (decimal)(A2165ACTRetRetVouMes), 1, 0));
            }
            else
            {
               A2165ACTRetRetVouMes = (short)(context.localUtil.CToN( cgiGet( edtACTRetRetVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A2165ACTRetRetVouMes", StringUtil.Str( (decimal)(A2165ACTRetRetVouMes), 1, 0));
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
               A2105ACTRetCod = GetPar( "ACTRetCod");
               AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
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
               InitAll6S186( ) ;
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
         DisableAttributes6S186( ) ;
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

      protected void ResetCaption6S0( )
      {
      }

      protected void ZM6S186( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2159ACTRetFec = T006S3_A2159ACTRetFec[0];
               Z2160ACTRetGrupCod = T006S3_A2160ACTRetGrupCod[0];
               Z2157ACTRetCosto = T006S3_A2157ACTRetCosto[0];
               Z2169ACTRetVouAno = T006S3_A2169ACTRetVouAno[0];
               Z2170ACTRetVouMes = T006S3_A2170ACTRetVouMes[0];
               Z2167ACTRetTASICod = T006S3_A2167ACTRetTASICod[0];
               Z2171ACTRetVouNum = T006S3_A2171ACTRetVouNum[0];
               Z2168ACTRetValRes = T006S3_A2168ACTRetValRes[0];
               Z2158ACTRetDepre = T006S3_A2158ACTRetDepre[0];
               Z2162ACTRetRetFec = T006S3_A2162ACTRetRetFec[0];
               Z2166ACTRetRetVouNum = T006S3_A2166ACTRetRetVouNum[0];
               Z2163ACTRetRetTASICod = T006S3_A2163ACTRetRetTASICod[0];
               Z2164ACTRetRetVouAno = T006S3_A2164ACTRetRetVouAno[0];
               Z2165ACTRetRetVouMes = T006S3_A2165ACTRetRetVouMes[0];
               Z2100ACTActCod = T006S3_A2100ACTActCod[0];
               Z2104ActActItem = T006S3_A2104ActActItem[0];
            }
            else
            {
               Z2159ACTRetFec = A2159ACTRetFec;
               Z2160ACTRetGrupCod = A2160ACTRetGrupCod;
               Z2157ACTRetCosto = A2157ACTRetCosto;
               Z2169ACTRetVouAno = A2169ACTRetVouAno;
               Z2170ACTRetVouMes = A2170ACTRetVouMes;
               Z2167ACTRetTASICod = A2167ACTRetTASICod;
               Z2171ACTRetVouNum = A2171ACTRetVouNum;
               Z2168ACTRetValRes = A2168ACTRetValRes;
               Z2158ACTRetDepre = A2158ACTRetDepre;
               Z2162ACTRetRetFec = A2162ACTRetRetFec;
               Z2166ACTRetRetVouNum = A2166ACTRetRetVouNum;
               Z2163ACTRetRetTASICod = A2163ACTRetRetTASICod;
               Z2164ACTRetRetVouAno = A2164ACTRetRetVouAno;
               Z2165ACTRetRetVouMes = A2165ACTRetRetVouMes;
               Z2100ACTActCod = A2100ACTActCod;
               Z2104ActActItem = A2104ActActItem;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2105ACTRetCod = A2105ACTRetCod;
            Z2159ACTRetFec = A2159ACTRetFec;
            Z2160ACTRetGrupCod = A2160ACTRetGrupCod;
            Z2161ACTRetObs = A2161ACTRetObs;
            Z2157ACTRetCosto = A2157ACTRetCosto;
            Z2169ACTRetVouAno = A2169ACTRetVouAno;
            Z2170ACTRetVouMes = A2170ACTRetVouMes;
            Z2167ACTRetTASICod = A2167ACTRetTASICod;
            Z2171ACTRetVouNum = A2171ACTRetVouNum;
            Z2168ACTRetValRes = A2168ACTRetValRes;
            Z2158ACTRetDepre = A2158ACTRetDepre;
            Z2162ACTRetRetFec = A2162ACTRetRetFec;
            Z2166ACTRetRetVouNum = A2166ACTRetRetVouNum;
            Z2163ACTRetRetTASICod = A2163ACTRetRetTASICod;
            Z2164ACTRetRetVouAno = A2164ACTRetRetVouAno;
            Z2165ACTRetRetVouMes = A2165ACTRetRetVouMes;
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

      protected void Load6S186( )
      {
         /* Using cursor T006S6 */
         pr_default.execute(4, new Object[] {A2105ACTRetCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound186 = 1;
            A2159ACTRetFec = T006S6_A2159ACTRetFec[0];
            AssignAttri("", false, "A2159ACTRetFec", context.localUtil.Format(A2159ACTRetFec, "99/99/99"));
            A2122ACTActDsc = T006S6_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            A2160ACTRetGrupCod = T006S6_A2160ACTRetGrupCod[0];
            n2160ACTRetGrupCod = T006S6_n2160ACTRetGrupCod[0];
            AssignAttri("", false, "A2160ACTRetGrupCod", StringUtil.LTrimStr( (decimal)(A2160ACTRetGrupCod), 6, 0));
            A2161ACTRetObs = T006S6_A2161ACTRetObs[0];
            AssignAttri("", false, "A2161ACTRetObs", A2161ACTRetObs);
            A2157ACTRetCosto = T006S6_A2157ACTRetCosto[0];
            AssignAttri("", false, "A2157ACTRetCosto", StringUtil.LTrimStr( A2157ACTRetCosto, 15, 2));
            A2169ACTRetVouAno = T006S6_A2169ACTRetVouAno[0];
            AssignAttri("", false, "A2169ACTRetVouAno", StringUtil.LTrimStr( (decimal)(A2169ACTRetVouAno), 4, 0));
            A2170ACTRetVouMes = T006S6_A2170ACTRetVouMes[0];
            AssignAttri("", false, "A2170ACTRetVouMes", StringUtil.LTrimStr( (decimal)(A2170ACTRetVouMes), 2, 0));
            A2167ACTRetTASICod = T006S6_A2167ACTRetTASICod[0];
            AssignAttri("", false, "A2167ACTRetTASICod", StringUtil.LTrimStr( (decimal)(A2167ACTRetTASICod), 6, 0));
            A2171ACTRetVouNum = T006S6_A2171ACTRetVouNum[0];
            AssignAttri("", false, "A2171ACTRetVouNum", A2171ACTRetVouNum);
            A2168ACTRetValRes = T006S6_A2168ACTRetValRes[0];
            AssignAttri("", false, "A2168ACTRetValRes", StringUtil.LTrimStr( A2168ACTRetValRes, 15, 2));
            A2158ACTRetDepre = T006S6_A2158ACTRetDepre[0];
            AssignAttri("", false, "A2158ACTRetDepre", StringUtil.LTrimStr( A2158ACTRetDepre, 15, 2));
            A2162ACTRetRetFec = T006S6_A2162ACTRetRetFec[0];
            AssignAttri("", false, "A2162ACTRetRetFec", context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"));
            A2166ACTRetRetVouNum = T006S6_A2166ACTRetRetVouNum[0];
            AssignAttri("", false, "A2166ACTRetRetVouNum", A2166ACTRetRetVouNum);
            A2163ACTRetRetTASICod = T006S6_A2163ACTRetRetTASICod[0];
            AssignAttri("", false, "A2163ACTRetRetTASICod", StringUtil.LTrimStr( (decimal)(A2163ACTRetRetTASICod), 6, 0));
            A2164ACTRetRetVouAno = T006S6_A2164ACTRetRetVouAno[0];
            AssignAttri("", false, "A2164ACTRetRetVouAno", StringUtil.LTrimStr( (decimal)(A2164ACTRetRetVouAno), 4, 0));
            A2165ACTRetRetVouMes = T006S6_A2165ACTRetRetVouMes[0];
            AssignAttri("", false, "A2165ACTRetRetVouMes", StringUtil.Str( (decimal)(A2165ACTRetRetVouMes), 1, 0));
            A2100ACTActCod = T006S6_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006S6_A2104ActActItem[0];
            n2104ActActItem = T006S6_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            ZM6S186( -3) ;
         }
         pr_default.close(4);
         OnLoadActions6S186( ) ;
      }

      protected void OnLoadActions6S186( )
      {
      }

      protected void CheckExtendedTable6S186( )
      {
         nIsDirty_186 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2159ACTRetFec) || ( DateTimeUtil.ResetTime ( A2159ACTRetFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "ACTRETFEC");
            AnyError = 1;
            GX_FocusControl = edtACTRetFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T006S4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006S4_A2122ACTActDsc[0];
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         pr_default.close(2);
         /* Using cursor T006S5 */
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
         if ( ! ( (DateTime.MinValue==A2162ACTRetRetFec) || ( DateTimeUtil.ResetTime ( A2162ACTRetRetFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Retorno fuera de rango", "OutOfRange", 1, "ACTRETRETFEC");
            AnyError = 1;
            GX_FocusControl = edtACTRetRetFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6S186( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A2100ACTActCod )
      {
         /* Using cursor T006S7 */
         pr_default.execute(5, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2122ACTActDsc = T006S7_A2122ACTActDsc[0];
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

      protected void gxLoad_5( string A2100ACTActCod ,
                               string A2104ActActItem )
      {
         /* Using cursor T006S8 */
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

      protected void GetKey6S186( )
      {
         /* Using cursor T006S9 */
         pr_default.execute(7, new Object[] {A2105ACTRetCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound186 = 1;
         }
         else
         {
            RcdFound186 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006S3 */
         pr_default.execute(1, new Object[] {A2105ACTRetCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6S186( 3) ;
            RcdFound186 = 1;
            A2105ACTRetCod = T006S3_A2105ACTRetCod[0];
            AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
            A2159ACTRetFec = T006S3_A2159ACTRetFec[0];
            AssignAttri("", false, "A2159ACTRetFec", context.localUtil.Format(A2159ACTRetFec, "99/99/99"));
            A2160ACTRetGrupCod = T006S3_A2160ACTRetGrupCod[0];
            n2160ACTRetGrupCod = T006S3_n2160ACTRetGrupCod[0];
            AssignAttri("", false, "A2160ACTRetGrupCod", StringUtil.LTrimStr( (decimal)(A2160ACTRetGrupCod), 6, 0));
            A2161ACTRetObs = T006S3_A2161ACTRetObs[0];
            AssignAttri("", false, "A2161ACTRetObs", A2161ACTRetObs);
            A2157ACTRetCosto = T006S3_A2157ACTRetCosto[0];
            AssignAttri("", false, "A2157ACTRetCosto", StringUtil.LTrimStr( A2157ACTRetCosto, 15, 2));
            A2169ACTRetVouAno = T006S3_A2169ACTRetVouAno[0];
            AssignAttri("", false, "A2169ACTRetVouAno", StringUtil.LTrimStr( (decimal)(A2169ACTRetVouAno), 4, 0));
            A2170ACTRetVouMes = T006S3_A2170ACTRetVouMes[0];
            AssignAttri("", false, "A2170ACTRetVouMes", StringUtil.LTrimStr( (decimal)(A2170ACTRetVouMes), 2, 0));
            A2167ACTRetTASICod = T006S3_A2167ACTRetTASICod[0];
            AssignAttri("", false, "A2167ACTRetTASICod", StringUtil.LTrimStr( (decimal)(A2167ACTRetTASICod), 6, 0));
            A2171ACTRetVouNum = T006S3_A2171ACTRetVouNum[0];
            AssignAttri("", false, "A2171ACTRetVouNum", A2171ACTRetVouNum);
            A2168ACTRetValRes = T006S3_A2168ACTRetValRes[0];
            AssignAttri("", false, "A2168ACTRetValRes", StringUtil.LTrimStr( A2168ACTRetValRes, 15, 2));
            A2158ACTRetDepre = T006S3_A2158ACTRetDepre[0];
            AssignAttri("", false, "A2158ACTRetDepre", StringUtil.LTrimStr( A2158ACTRetDepre, 15, 2));
            A2162ACTRetRetFec = T006S3_A2162ACTRetRetFec[0];
            AssignAttri("", false, "A2162ACTRetRetFec", context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"));
            A2166ACTRetRetVouNum = T006S3_A2166ACTRetRetVouNum[0];
            AssignAttri("", false, "A2166ACTRetRetVouNum", A2166ACTRetRetVouNum);
            A2163ACTRetRetTASICod = T006S3_A2163ACTRetRetTASICod[0];
            AssignAttri("", false, "A2163ACTRetRetTASICod", StringUtil.LTrimStr( (decimal)(A2163ACTRetRetTASICod), 6, 0));
            A2164ACTRetRetVouAno = T006S3_A2164ACTRetRetVouAno[0];
            AssignAttri("", false, "A2164ACTRetRetVouAno", StringUtil.LTrimStr( (decimal)(A2164ACTRetRetVouAno), 4, 0));
            A2165ACTRetRetVouMes = T006S3_A2165ACTRetRetVouMes[0];
            AssignAttri("", false, "A2165ACTRetRetVouMes", StringUtil.Str( (decimal)(A2165ACTRetRetVouMes), 1, 0));
            A2100ACTActCod = T006S3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006S3_A2104ActActItem[0];
            n2104ActActItem = T006S3_n2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            Z2105ACTRetCod = A2105ACTRetCod;
            sMode186 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6S186( ) ;
            if ( AnyError == 1 )
            {
               RcdFound186 = 0;
               InitializeNonKey6S186( ) ;
            }
            Gx_mode = sMode186;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound186 = 0;
            InitializeNonKey6S186( ) ;
            sMode186 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode186;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6S186( ) ;
         if ( RcdFound186 == 0 )
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
         RcdFound186 = 0;
         /* Using cursor T006S10 */
         pr_default.execute(8, new Object[] {A2105ACTRetCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006S10_A2105ACTRetCod[0], A2105ACTRetCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T006S10_A2105ACTRetCod[0], A2105ACTRetCod) > 0 ) ) )
            {
               A2105ACTRetCod = T006S10_A2105ACTRetCod[0];
               AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
               RcdFound186 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound186 = 0;
         /* Using cursor T006S11 */
         pr_default.execute(9, new Object[] {A2105ACTRetCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006S11_A2105ACTRetCod[0], A2105ACTRetCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T006S11_A2105ACTRetCod[0], A2105ACTRetCod) < 0 ) ) )
            {
               A2105ACTRetCod = T006S11_A2105ACTRetCod[0];
               AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
               RcdFound186 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6S186( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6S186( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound186 == 1 )
            {
               if ( StringUtil.StrCmp(A2105ACTRetCod, Z2105ACTRetCod) != 0 )
               {
                  A2105ACTRetCod = Z2105ACTRetCod;
                  AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTRETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6S186( ) ;
                  GX_FocusControl = edtACTRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2105ACTRetCod, Z2105ACTRetCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6S186( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTRETCOD");
                     AnyError = 1;
                     GX_FocusControl = edtACTRetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTRetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6S186( ) ;
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
         if ( StringUtil.StrCmp(A2105ACTRetCod, Z2105ACTRetCod) != 0 )
         {
            A2105ACTRetCod = Z2105ACTRetCod;
            AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTRETCOD");
            AnyError = 1;
            GX_FocusControl = edtACTRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTRetCod_Internalname;
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
         if ( RcdFound186 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTRETCOD");
            AnyError = 1;
            GX_FocusControl = edtACTRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6S186( ) ;
         if ( RcdFound186 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6S186( ) ;
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
         if ( RcdFound186 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRetFec_Internalname;
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
         if ( RcdFound186 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRetFec_Internalname;
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
         ScanStart6S186( ) ;
         if ( RcdFound186 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound186 != 0 )
            {
               ScanNext6S186( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6S186( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6S186( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006S2 */
            pr_default.execute(0, new Object[] {A2105ACTRetCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTRETIROACTIVO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2159ACTRetFec ) != DateTimeUtil.ResetTime ( T006S2_A2159ACTRetFec[0] ) ) || ( Z2160ACTRetGrupCod != T006S2_A2160ACTRetGrupCod[0] ) || ( Z2157ACTRetCosto != T006S2_A2157ACTRetCosto[0] ) || ( Z2169ACTRetVouAno != T006S2_A2169ACTRetVouAno[0] ) || ( Z2170ACTRetVouMes != T006S2_A2170ACTRetVouMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2167ACTRetTASICod != T006S2_A2167ACTRetTASICod[0] ) || ( StringUtil.StrCmp(Z2171ACTRetVouNum, T006S2_A2171ACTRetVouNum[0]) != 0 ) || ( Z2168ACTRetValRes != T006S2_A2168ACTRetValRes[0] ) || ( Z2158ACTRetDepre != T006S2_A2158ACTRetDepre[0] ) || ( DateTimeUtil.ResetTime ( Z2162ACTRetRetFec ) != DateTimeUtil.ResetTime ( T006S2_A2162ACTRetRetFec[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2166ACTRetRetVouNum, T006S2_A2166ACTRetRetVouNum[0]) != 0 ) || ( Z2163ACTRetRetTASICod != T006S2_A2163ACTRetRetTASICod[0] ) || ( Z2164ACTRetRetVouAno != T006S2_A2164ACTRetRetVouAno[0] ) || ( Z2165ACTRetRetVouMes != T006S2_A2165ACTRetRetVouMes[0] ) || ( StringUtil.StrCmp(Z2100ACTActCod, T006S2_A2100ACTActCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2104ActActItem, T006S2_A2104ActActItem[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2159ACTRetFec ) != DateTimeUtil.ResetTime ( T006S2_A2159ACTRetFec[0] ) )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetFec");
                  GXUtil.WriteLogRaw("Old: ",Z2159ACTRetFec);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2159ACTRetFec[0]);
               }
               if ( Z2160ACTRetGrupCod != T006S2_A2160ACTRetGrupCod[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetGrupCod");
                  GXUtil.WriteLogRaw("Old: ",Z2160ACTRetGrupCod);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2160ACTRetGrupCod[0]);
               }
               if ( Z2157ACTRetCosto != T006S2_A2157ACTRetCosto[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetCosto");
                  GXUtil.WriteLogRaw("Old: ",Z2157ACTRetCosto);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2157ACTRetCosto[0]);
               }
               if ( Z2169ACTRetVouAno != T006S2_A2169ACTRetVouAno[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z2169ACTRetVouAno);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2169ACTRetVouAno[0]);
               }
               if ( Z2170ACTRetVouMes != T006S2_A2170ACTRetVouMes[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z2170ACTRetVouMes);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2170ACTRetVouMes[0]);
               }
               if ( Z2167ACTRetTASICod != T006S2_A2167ACTRetTASICod[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z2167ACTRetTASICod);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2167ACTRetTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z2171ACTRetVouNum, T006S2_A2171ACTRetVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z2171ACTRetVouNum);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2171ACTRetVouNum[0]);
               }
               if ( Z2168ACTRetValRes != T006S2_A2168ACTRetValRes[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetValRes");
                  GXUtil.WriteLogRaw("Old: ",Z2168ACTRetValRes);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2168ACTRetValRes[0]);
               }
               if ( Z2158ACTRetDepre != T006S2_A2158ACTRetDepre[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetDepre");
                  GXUtil.WriteLogRaw("Old: ",Z2158ACTRetDepre);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2158ACTRetDepre[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z2162ACTRetRetFec ) != DateTimeUtil.ResetTime ( T006S2_A2162ACTRetRetFec[0] ) )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetRetFec");
                  GXUtil.WriteLogRaw("Old: ",Z2162ACTRetRetFec);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2162ACTRetRetFec[0]);
               }
               if ( StringUtil.StrCmp(Z2166ACTRetRetVouNum, T006S2_A2166ACTRetRetVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetRetVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z2166ACTRetRetVouNum);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2166ACTRetRetVouNum[0]);
               }
               if ( Z2163ACTRetRetTASICod != T006S2_A2163ACTRetRetTASICod[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetRetTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z2163ACTRetRetTASICod);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2163ACTRetRetTASICod[0]);
               }
               if ( Z2164ACTRetRetVouAno != T006S2_A2164ACTRetRetVouAno[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetRetVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z2164ACTRetRetVouAno);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2164ACTRetRetVouAno[0]);
               }
               if ( Z2165ACTRetRetVouMes != T006S2_A2165ACTRetRetVouMes[0] )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTRetRetVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z2165ACTRetRetVouMes);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2165ACTRetRetVouMes[0]);
               }
               if ( StringUtil.StrCmp(Z2100ACTActCod, T006S2_A2100ACTActCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ACTActCod");
                  GXUtil.WriteLogRaw("Old: ",Z2100ACTActCod);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2100ACTActCod[0]);
               }
               if ( StringUtil.StrCmp(Z2104ActActItem, T006S2_A2104ActActItem[0]) != 0 )
               {
                  GXUtil.WriteLog("actretiroactivo:[seudo value changed for attri]"+"ActActItem");
                  GXUtil.WriteLogRaw("Old: ",Z2104ActActItem);
                  GXUtil.WriteLogRaw("Current: ",T006S2_A2104ActActItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTRETIROACTIVO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6S186( )
      {
         BeforeValidate6S186( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6S186( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6S186( 0) ;
            CheckOptimisticConcurrency6S186( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6S186( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6S186( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006S12 */
                     pr_default.execute(10, new Object[] {A2105ACTRetCod, A2159ACTRetFec, n2160ACTRetGrupCod, A2160ACTRetGrupCod, A2161ACTRetObs, A2157ACTRetCosto, A2169ACTRetVouAno, A2170ACTRetVouMes, A2167ACTRetTASICod, A2171ACTRetVouNum, A2168ACTRetValRes, A2158ACTRetDepre, A2162ACTRetRetFec, A2166ACTRetRetVouNum, A2163ACTRetRetTASICod, A2164ACTRetRetVouAno, A2165ACTRetRetVouMes, A2100ACTActCod, n2104ActActItem, A2104ActActItem});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTRETIROACTIVO");
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
                           ResetCaption6S0( ) ;
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
               Load6S186( ) ;
            }
            EndLevel6S186( ) ;
         }
         CloseExtendedTableCursors6S186( ) ;
      }

      protected void Update6S186( )
      {
         BeforeValidate6S186( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6S186( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6S186( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6S186( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6S186( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006S13 */
                     pr_default.execute(11, new Object[] {A2159ACTRetFec, n2160ACTRetGrupCod, A2160ACTRetGrupCod, A2161ACTRetObs, A2157ACTRetCosto, A2169ACTRetVouAno, A2170ACTRetVouMes, A2167ACTRetTASICod, A2171ACTRetVouNum, A2168ACTRetValRes, A2158ACTRetDepre, A2162ACTRetRetFec, A2166ACTRetRetVouNum, A2163ACTRetRetTASICod, A2164ACTRetRetVouAno, A2165ACTRetRetVouMes, A2100ACTActCod, n2104ActActItem, A2104ActActItem, A2105ACTRetCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTRETIROACTIVO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTRETIROACTIVO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6S186( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6S0( ) ;
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
            EndLevel6S186( ) ;
         }
         CloseExtendedTableCursors6S186( ) ;
      }

      protected void DeferredUpdate6S186( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6S186( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6S186( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6S186( ) ;
            AfterConfirm6S186( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6S186( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006S14 */
                  pr_default.execute(12, new Object[] {A2105ACTRetCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTRETIROACTIVO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound186 == 0 )
                        {
                           InitAll6S186( ) ;
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
                        ResetCaption6S0( ) ;
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
         sMode186 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6S186( ) ;
         Gx_mode = sMode186;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6S186( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006S15 */
            pr_default.execute(13, new Object[] {A2100ACTActCod});
            A2122ACTActDsc = T006S15_A2122ACTActDsc[0];
            AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
            pr_default.close(13);
         }
      }

      protected void EndLevel6S186( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6S186( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("actretiroactivo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("actretiroactivo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6S186( )
      {
         /* Using cursor T006S16 */
         pr_default.execute(14);
         RcdFound186 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound186 = 1;
            A2105ACTRetCod = T006S16_A2105ACTRetCod[0];
            AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6S186( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound186 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound186 = 1;
            A2105ACTRetCod = T006S16_A2105ACTRetCod[0];
            AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
         }
      }

      protected void ScanEnd6S186( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm6S186( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6S186( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6S186( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6S186( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6S186( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6S186( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6S186( )
      {
         edtACTRetCod_Enabled = 0;
         AssignProp("", false, edtACTRetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetCod_Enabled), 5, 0), true);
         edtACTRetFec_Enabled = 0;
         AssignProp("", false, edtACTRetFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetFec_Enabled), 5, 0), true);
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtACTActDsc_Enabled = 0;
         AssignProp("", false, edtACTActDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActDsc_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtACTRetGrupCod_Enabled = 0;
         AssignProp("", false, edtACTRetGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetGrupCod_Enabled), 5, 0), true);
         edtACTRetObs_Enabled = 0;
         AssignProp("", false, edtACTRetObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetObs_Enabled), 5, 0), true);
         edtACTRetCosto_Enabled = 0;
         AssignProp("", false, edtACTRetCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetCosto_Enabled), 5, 0), true);
         edtACTRetVouAno_Enabled = 0;
         AssignProp("", false, edtACTRetVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetVouAno_Enabled), 5, 0), true);
         edtACTRetVouMes_Enabled = 0;
         AssignProp("", false, edtACTRetVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetVouMes_Enabled), 5, 0), true);
         edtACTRetTASICod_Enabled = 0;
         AssignProp("", false, edtACTRetTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetTASICod_Enabled), 5, 0), true);
         edtACTRetVouNum_Enabled = 0;
         AssignProp("", false, edtACTRetVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetVouNum_Enabled), 5, 0), true);
         edtACTRetValRes_Enabled = 0;
         AssignProp("", false, edtACTRetValRes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetValRes_Enabled), 5, 0), true);
         edtACTRetDepre_Enabled = 0;
         AssignProp("", false, edtACTRetDepre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetDepre_Enabled), 5, 0), true);
         edtACTRetRetFec_Enabled = 0;
         AssignProp("", false, edtACTRetRetFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetRetFec_Enabled), 5, 0), true);
         edtACTRetRetVouNum_Enabled = 0;
         AssignProp("", false, edtACTRetRetVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetRetVouNum_Enabled), 5, 0), true);
         edtACTRetRetTASICod_Enabled = 0;
         AssignProp("", false, edtACTRetRetTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetRetTASICod_Enabled), 5, 0), true);
         edtACTRetRetVouAno_Enabled = 0;
         AssignProp("", false, edtACTRetRetVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetRetVouAno_Enabled), 5, 0), true);
         edtACTRetRetVouMes_Enabled = 0;
         AssignProp("", false, edtACTRetRetVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTRetRetVouMes_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6S186( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6S0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264525", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actretiroactivo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2105ACTRetCod", Z2105ACTRetCod);
         GxWebStd.gx_hidden_field( context, "Z2159ACTRetFec", context.localUtil.DToC( Z2159ACTRetFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2160ACTRetGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2160ACTRetGrupCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2157ACTRetCosto", StringUtil.LTrim( StringUtil.NToC( Z2157ACTRetCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2169ACTRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2169ACTRetVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2170ACTRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2170ACTRetVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2167ACTRetTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2167ACTRetTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2171ACTRetVouNum", StringUtil.RTrim( Z2171ACTRetVouNum));
         GxWebStd.gx_hidden_field( context, "Z2168ACTRetValRes", StringUtil.LTrim( StringUtil.NToC( Z2168ACTRetValRes, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2158ACTRetDepre", StringUtil.LTrim( StringUtil.NToC( Z2158ACTRetDepre, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2162ACTRetRetFec", context.localUtil.DToC( Z2162ACTRetRetFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2166ACTRetRetVouNum", StringUtil.RTrim( Z2166ACTRetRetVouNum));
         GxWebStd.gx_hidden_field( context, "Z2163ACTRetRetTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2163ACTRetRetTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2164ACTRetRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2164ACTRetRetVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2165ACTRetRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2165ACTRetRetVouMes), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
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
         return formatLink("actretiroactivo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ACTRETIROACTIVO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Retiro de Activo Fijos" ;
      }

      protected void InitializeNonKey6S186( )
      {
         A2159ACTRetFec = DateTime.MinValue;
         AssignAttri("", false, "A2159ACTRetFec", context.localUtil.Format(A2159ACTRetFec, "99/99/99"));
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2122ACTActDsc = "";
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         A2104ActActItem = "";
         n2104ActActItem = false;
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         n2104ActActItem = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? true : false);
         A2160ACTRetGrupCod = 0;
         n2160ACTRetGrupCod = false;
         AssignAttri("", false, "A2160ACTRetGrupCod", StringUtil.LTrimStr( (decimal)(A2160ACTRetGrupCod), 6, 0));
         n2160ACTRetGrupCod = ((0==A2160ACTRetGrupCod) ? true : false);
         A2161ACTRetObs = "";
         AssignAttri("", false, "A2161ACTRetObs", A2161ACTRetObs);
         A2157ACTRetCosto = 0;
         AssignAttri("", false, "A2157ACTRetCosto", StringUtil.LTrimStr( A2157ACTRetCosto, 15, 2));
         A2169ACTRetVouAno = 0;
         AssignAttri("", false, "A2169ACTRetVouAno", StringUtil.LTrimStr( (decimal)(A2169ACTRetVouAno), 4, 0));
         A2170ACTRetVouMes = 0;
         AssignAttri("", false, "A2170ACTRetVouMes", StringUtil.LTrimStr( (decimal)(A2170ACTRetVouMes), 2, 0));
         A2167ACTRetTASICod = 0;
         AssignAttri("", false, "A2167ACTRetTASICod", StringUtil.LTrimStr( (decimal)(A2167ACTRetTASICod), 6, 0));
         A2171ACTRetVouNum = "";
         AssignAttri("", false, "A2171ACTRetVouNum", A2171ACTRetVouNum);
         A2168ACTRetValRes = 0;
         AssignAttri("", false, "A2168ACTRetValRes", StringUtil.LTrimStr( A2168ACTRetValRes, 15, 2));
         A2158ACTRetDepre = 0;
         AssignAttri("", false, "A2158ACTRetDepre", StringUtil.LTrimStr( A2158ACTRetDepre, 15, 2));
         A2162ACTRetRetFec = DateTime.MinValue;
         AssignAttri("", false, "A2162ACTRetRetFec", context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"));
         A2166ACTRetRetVouNum = "";
         AssignAttri("", false, "A2166ACTRetRetVouNum", A2166ACTRetRetVouNum);
         A2163ACTRetRetTASICod = 0;
         AssignAttri("", false, "A2163ACTRetRetTASICod", StringUtil.LTrimStr( (decimal)(A2163ACTRetRetTASICod), 6, 0));
         A2164ACTRetRetVouAno = 0;
         AssignAttri("", false, "A2164ACTRetRetVouAno", StringUtil.LTrimStr( (decimal)(A2164ACTRetRetVouAno), 4, 0));
         A2165ACTRetRetVouMes = 0;
         AssignAttri("", false, "A2165ACTRetRetVouMes", StringUtil.Str( (decimal)(A2165ACTRetRetVouMes), 1, 0));
         Z2159ACTRetFec = DateTime.MinValue;
         Z2160ACTRetGrupCod = 0;
         Z2157ACTRetCosto = 0;
         Z2169ACTRetVouAno = 0;
         Z2170ACTRetVouMes = 0;
         Z2167ACTRetTASICod = 0;
         Z2171ACTRetVouNum = "";
         Z2168ACTRetValRes = 0;
         Z2158ACTRetDepre = 0;
         Z2162ACTRetRetFec = DateTime.MinValue;
         Z2166ACTRetRetVouNum = "";
         Z2163ACTRetRetTASICod = 0;
         Z2164ACTRetRetVouAno = 0;
         Z2165ACTRetRetVouMes = 0;
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
      }

      protected void InitAll6S186( )
      {
         A2105ACTRetCod = "";
         AssignAttri("", false, "A2105ACTRetCod", A2105ACTRetCod);
         InitializeNonKey6S186( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264539", true, true);
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
         context.AddJavascriptSource("actretiroactivo.js", "?202281810264539", false, true);
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
         edtACTRetCod_Internalname = "ACTRETCOD";
         edtACTRetFec_Internalname = "ACTRETFEC";
         edtACTActCod_Internalname = "ACTACTCOD";
         edtACTActDsc_Internalname = "ACTACTDSC";
         edtActActItem_Internalname = "ACTACTITEM";
         edtACTRetGrupCod_Internalname = "ACTRETGRUPCOD";
         edtACTRetObs_Internalname = "ACTRETOBS";
         edtACTRetCosto_Internalname = "ACTRETCOSTO";
         edtACTRetVouAno_Internalname = "ACTRETVOUANO";
         edtACTRetVouMes_Internalname = "ACTRETVOUMES";
         edtACTRetTASICod_Internalname = "ACTRETTASICOD";
         edtACTRetVouNum_Internalname = "ACTRETVOUNUM";
         edtACTRetValRes_Internalname = "ACTRETVALRES";
         edtACTRetDepre_Internalname = "ACTRETDEPRE";
         edtACTRetRetFec_Internalname = "ACTRETRETFEC";
         edtACTRetRetVouNum_Internalname = "ACTRETRETVOUNUM";
         edtACTRetRetTASICod_Internalname = "ACTRETRETTASICOD";
         edtACTRetRetVouAno_Internalname = "ACTRETRETVOUANO";
         edtACTRetRetVouMes_Internalname = "ACTRETRETVOUMES";
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
         Form.Caption = "Retiro de Activo Fijos";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtACTRetRetVouMes_Jsonclick = "";
         edtACTRetRetVouMes_Enabled = 1;
         edtACTRetRetVouAno_Jsonclick = "";
         edtACTRetRetVouAno_Enabled = 1;
         edtACTRetRetTASICod_Jsonclick = "";
         edtACTRetRetTASICod_Enabled = 1;
         edtACTRetRetVouNum_Jsonclick = "";
         edtACTRetRetVouNum_Enabled = 1;
         edtACTRetRetFec_Jsonclick = "";
         edtACTRetRetFec_Enabled = 1;
         edtACTRetDepre_Jsonclick = "";
         edtACTRetDepre_Enabled = 1;
         edtACTRetValRes_Jsonclick = "";
         edtACTRetValRes_Enabled = 1;
         edtACTRetVouNum_Jsonclick = "";
         edtACTRetVouNum_Enabled = 1;
         edtACTRetTASICod_Jsonclick = "";
         edtACTRetTASICod_Enabled = 1;
         edtACTRetVouMes_Jsonclick = "";
         edtACTRetVouMes_Enabled = 1;
         edtACTRetVouAno_Jsonclick = "";
         edtACTRetVouAno_Enabled = 1;
         edtACTRetCosto_Jsonclick = "";
         edtACTRetCosto_Enabled = 1;
         edtACTRetObs_Enabled = 1;
         edtACTRetGrupCod_Jsonclick = "";
         edtACTRetGrupCod_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActDsc_Jsonclick = "";
         edtACTActDsc_Enabled = 0;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
         edtACTRetFec_Jsonclick = "";
         edtACTRetFec_Enabled = 1;
         edtACTRetCod_Jsonclick = "";
         edtACTRetCod_Enabled = 1;
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
         GX_FocusControl = edtACTRetFec_Internalname;
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

      public void Valid_Actretcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2159ACTRetFec", context.localUtil.Format(A2159ACTRetFec, "99/99/99"));
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         AssignAttri("", false, "A2160ACTRetGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2160ACTRetGrupCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2161ACTRetObs", A2161ACTRetObs);
         AssignAttri("", false, "A2157ACTRetCosto", StringUtil.LTrim( StringUtil.NToC( A2157ACTRetCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A2169ACTRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2169ACTRetVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A2170ACTRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2170ACTRetVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A2167ACTRetTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2167ACTRetTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A2171ACTRetVouNum", StringUtil.RTrim( A2171ACTRetVouNum));
         AssignAttri("", false, "A2168ACTRetValRes", StringUtil.LTrim( StringUtil.NToC( A2168ACTRetValRes, 15, 2, ".", "")));
         AssignAttri("", false, "A2158ACTRetDepre", StringUtil.LTrim( StringUtil.NToC( A2158ACTRetDepre, 15, 2, ".", "")));
         AssignAttri("", false, "A2162ACTRetRetFec", context.localUtil.Format(A2162ACTRetRetFec, "99/99/99"));
         AssignAttri("", false, "A2166ACTRetRetVouNum", StringUtil.RTrim( A2166ACTRetRetVouNum));
         AssignAttri("", false, "A2163ACTRetRetTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2163ACTRetRetTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A2164ACTRetRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2164ACTRetRetVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A2165ACTRetRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2165ACTRetRetVouMes), 1, 0, ".", "")));
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2105ACTRetCod", Z2105ACTRetCod);
         GxWebStd.gx_hidden_field( context, "Z2159ACTRetFec", context.localUtil.Format(Z2159ACTRetFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2160ACTRetGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2160ACTRetGrupCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2161ACTRetObs", Z2161ACTRetObs);
         GxWebStd.gx_hidden_field( context, "Z2157ACTRetCosto", StringUtil.LTrim( StringUtil.NToC( Z2157ACTRetCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2169ACTRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2169ACTRetVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2170ACTRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2170ACTRetVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2167ACTRetTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2167ACTRetTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2171ACTRetVouNum", StringUtil.RTrim( Z2171ACTRetVouNum));
         GxWebStd.gx_hidden_field( context, "Z2168ACTRetValRes", StringUtil.LTrim( StringUtil.NToC( Z2168ACTRetValRes, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2158ACTRetDepre", StringUtil.LTrim( StringUtil.NToC( Z2158ACTRetDepre, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2162ACTRetRetFec", context.localUtil.Format(Z2162ACTRetRetFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2166ACTRetRetVouNum", StringUtil.RTrim( Z2166ACTRetRetVouNum));
         GxWebStd.gx_hidden_field( context, "Z2163ACTRetRetTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2163ACTRetRetTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2164ACTRetRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2164ACTRetRetVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2165ACTRetRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2165ACTRetRetVouMes), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2122ACTActDsc", Z2122ACTActDsc);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actactcod( )
      {
         /* Using cursor T006S15 */
         pr_default.execute(13, new Object[] {A2100ACTActCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOS'.", "ForeignKeyNotFound", 1, "ACTACTCOD");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         A2122ACTActDsc = T006S15_A2122ACTActDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2122ACTActDsc", A2122ACTActDsc);
      }

      public void Valid_Actactitem( )
      {
         n2104ActActItem = false;
         /* Using cursor T006S17 */
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
         setEventMetadata("VALID_ACTRETCOD","{handler:'Valid_Actretcod',iparms:[{av:'A2105ACTRetCod',fld:'ACTRETCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTRETCOD",",oparms:[{av:'A2159ACTRetFec',fld:'ACTRETFEC',pic:''},{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'A2160ACTRetGrupCod',fld:'ACTRETGRUPCOD',pic:'ZZZZZ9'},{av:'A2161ACTRetObs',fld:'ACTRETOBS',pic:''},{av:'A2157ACTRetCosto',fld:'ACTRETCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2169ACTRetVouAno',fld:'ACTRETVOUANO',pic:'ZZZ9'},{av:'A2170ACTRetVouMes',fld:'ACTRETVOUMES',pic:'Z9'},{av:'A2167ACTRetTASICod',fld:'ACTRETTASICOD',pic:'ZZZZZ9'},{av:'A2171ACTRetVouNum',fld:'ACTRETVOUNUM',pic:''},{av:'A2168ACTRetValRes',fld:'ACTRETVALRES',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2158ACTRetDepre',fld:'ACTRETDEPRE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2162ACTRetRetFec',fld:'ACTRETRETFEC',pic:''},{av:'A2166ACTRetRetVouNum',fld:'ACTRETRETVOUNUM',pic:''},{av:'A2163ACTRetRetTASICod',fld:'ACTRETRETTASICOD',pic:'ZZZZZ9'},{av:'A2164ACTRetRetVouAno',fld:'ACTRETRETVOUANO',pic:'ZZZ9'},{av:'A2165ACTRetRetVouMes',fld:'ACTRETRETVOUMES',pic:'9'},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2105ACTRetCod'},{av:'Z2159ACTRetFec'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2160ACTRetGrupCod'},{av:'Z2161ACTRetObs'},{av:'Z2157ACTRetCosto'},{av:'Z2169ACTRetVouAno'},{av:'Z2170ACTRetVouMes'},{av:'Z2167ACTRetTASICod'},{av:'Z2171ACTRetVouNum'},{av:'Z2168ACTRetValRes'},{av:'Z2158ACTRetDepre'},{av:'Z2162ACTRetRetFec'},{av:'Z2166ACTRetRetVouNum'},{av:'Z2163ACTRetRetTASICod'},{av:'Z2164ACTRetRetVouAno'},{av:'Z2165ACTRetRetVouMes'},{av:'Z2122ACTActDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTRETFEC","{handler:'Valid_Actretfec',iparms:[]");
         setEventMetadata("VALID_ACTRETFEC",",oparms:[]}");
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''}]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[{av:'A2122ACTActDsc',fld:'ACTACTDSC',pic:''}]}");
         setEventMetadata("VALID_ACTACTITEM","{handler:'Valid_Actactitem',iparms:[{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''}]");
         setEventMetadata("VALID_ACTACTITEM",",oparms:[]}");
         setEventMetadata("VALID_ACTRETRETFEC","{handler:'Valid_Actretretfec',iparms:[]");
         setEventMetadata("VALID_ACTRETRETFEC",",oparms:[]}");
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
         Z2105ACTRetCod = "";
         Z2159ACTRetFec = DateTime.MinValue;
         Z2171ACTRetVouNum = "";
         Z2162ACTRetRetFec = DateTime.MinValue;
         Z2166ACTRetRetVouNum = "";
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
         A2105ACTRetCod = "";
         A2159ACTRetFec = DateTime.MinValue;
         A2122ACTActDsc = "";
         A2161ACTRetObs = "";
         A2171ACTRetVouNum = "";
         A2162ACTRetRetFec = DateTime.MinValue;
         A2166ACTRetRetVouNum = "";
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
         Z2161ACTRetObs = "";
         Z2122ACTActDsc = "";
         T006S6_A2105ACTRetCod = new string[] {""} ;
         T006S6_A2159ACTRetFec = new DateTime[] {DateTime.MinValue} ;
         T006S6_A2122ACTActDsc = new string[] {""} ;
         T006S6_A2160ACTRetGrupCod = new int[1] ;
         T006S6_n2160ACTRetGrupCod = new bool[] {false} ;
         T006S6_A2161ACTRetObs = new string[] {""} ;
         T006S6_A2157ACTRetCosto = new decimal[1] ;
         T006S6_A2169ACTRetVouAno = new short[1] ;
         T006S6_A2170ACTRetVouMes = new short[1] ;
         T006S6_A2167ACTRetTASICod = new int[1] ;
         T006S6_A2171ACTRetVouNum = new string[] {""} ;
         T006S6_A2168ACTRetValRes = new decimal[1] ;
         T006S6_A2158ACTRetDepre = new decimal[1] ;
         T006S6_A2162ACTRetRetFec = new DateTime[] {DateTime.MinValue} ;
         T006S6_A2166ACTRetRetVouNum = new string[] {""} ;
         T006S6_A2163ACTRetRetTASICod = new int[1] ;
         T006S6_A2164ACTRetRetVouAno = new short[1] ;
         T006S6_A2165ACTRetRetVouMes = new short[1] ;
         T006S6_A2100ACTActCod = new string[] {""} ;
         T006S6_A2104ActActItem = new string[] {""} ;
         T006S6_n2104ActActItem = new bool[] {false} ;
         T006S4_A2122ACTActDsc = new string[] {""} ;
         T006S5_A2100ACTActCod = new string[] {""} ;
         T006S7_A2122ACTActDsc = new string[] {""} ;
         T006S8_A2100ACTActCod = new string[] {""} ;
         T006S9_A2105ACTRetCod = new string[] {""} ;
         T006S3_A2105ACTRetCod = new string[] {""} ;
         T006S3_A2159ACTRetFec = new DateTime[] {DateTime.MinValue} ;
         T006S3_A2160ACTRetGrupCod = new int[1] ;
         T006S3_n2160ACTRetGrupCod = new bool[] {false} ;
         T006S3_A2161ACTRetObs = new string[] {""} ;
         T006S3_A2157ACTRetCosto = new decimal[1] ;
         T006S3_A2169ACTRetVouAno = new short[1] ;
         T006S3_A2170ACTRetVouMes = new short[1] ;
         T006S3_A2167ACTRetTASICod = new int[1] ;
         T006S3_A2171ACTRetVouNum = new string[] {""} ;
         T006S3_A2168ACTRetValRes = new decimal[1] ;
         T006S3_A2158ACTRetDepre = new decimal[1] ;
         T006S3_A2162ACTRetRetFec = new DateTime[] {DateTime.MinValue} ;
         T006S3_A2166ACTRetRetVouNum = new string[] {""} ;
         T006S3_A2163ACTRetRetTASICod = new int[1] ;
         T006S3_A2164ACTRetRetVouAno = new short[1] ;
         T006S3_A2165ACTRetRetVouMes = new short[1] ;
         T006S3_A2100ACTActCod = new string[] {""} ;
         T006S3_A2104ActActItem = new string[] {""} ;
         T006S3_n2104ActActItem = new bool[] {false} ;
         sMode186 = "";
         T006S10_A2105ACTRetCod = new string[] {""} ;
         T006S11_A2105ACTRetCod = new string[] {""} ;
         T006S2_A2105ACTRetCod = new string[] {""} ;
         T006S2_A2159ACTRetFec = new DateTime[] {DateTime.MinValue} ;
         T006S2_A2160ACTRetGrupCod = new int[1] ;
         T006S2_n2160ACTRetGrupCod = new bool[] {false} ;
         T006S2_A2161ACTRetObs = new string[] {""} ;
         T006S2_A2157ACTRetCosto = new decimal[1] ;
         T006S2_A2169ACTRetVouAno = new short[1] ;
         T006S2_A2170ACTRetVouMes = new short[1] ;
         T006S2_A2167ACTRetTASICod = new int[1] ;
         T006S2_A2171ACTRetVouNum = new string[] {""} ;
         T006S2_A2168ACTRetValRes = new decimal[1] ;
         T006S2_A2158ACTRetDepre = new decimal[1] ;
         T006S2_A2162ACTRetRetFec = new DateTime[] {DateTime.MinValue} ;
         T006S2_A2166ACTRetRetVouNum = new string[] {""} ;
         T006S2_A2163ACTRetRetTASICod = new int[1] ;
         T006S2_A2164ACTRetRetVouAno = new short[1] ;
         T006S2_A2165ACTRetRetVouMes = new short[1] ;
         T006S2_A2100ACTActCod = new string[] {""} ;
         T006S2_A2104ActActItem = new string[] {""} ;
         T006S2_n2104ActActItem = new bool[] {false} ;
         T006S15_A2122ACTActDsc = new string[] {""} ;
         T006S16_A2105ACTRetCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2105ACTRetCod = "";
         ZZ2159ACTRetFec = DateTime.MinValue;
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2161ACTRetObs = "";
         ZZ2171ACTRetVouNum = "";
         ZZ2162ACTRetRetFec = DateTime.MinValue;
         ZZ2166ACTRetRetVouNum = "";
         ZZ2122ACTActDsc = "";
         T006S17_A2100ACTActCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actretiroactivo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actretiroactivo__default(),
            new Object[][] {
                new Object[] {
               T006S2_A2105ACTRetCod, T006S2_A2159ACTRetFec, T006S2_A2160ACTRetGrupCod, T006S2_n2160ACTRetGrupCod, T006S2_A2161ACTRetObs, T006S2_A2157ACTRetCosto, T006S2_A2169ACTRetVouAno, T006S2_A2170ACTRetVouMes, T006S2_A2167ACTRetTASICod, T006S2_A2171ACTRetVouNum,
               T006S2_A2168ACTRetValRes, T006S2_A2158ACTRetDepre, T006S2_A2162ACTRetRetFec, T006S2_A2166ACTRetRetVouNum, T006S2_A2163ACTRetRetTASICod, T006S2_A2164ACTRetRetVouAno, T006S2_A2165ACTRetRetVouMes, T006S2_A2100ACTActCod, T006S2_A2104ActActItem, T006S2_n2104ActActItem
               }
               , new Object[] {
               T006S3_A2105ACTRetCod, T006S3_A2159ACTRetFec, T006S3_A2160ACTRetGrupCod, T006S3_n2160ACTRetGrupCod, T006S3_A2161ACTRetObs, T006S3_A2157ACTRetCosto, T006S3_A2169ACTRetVouAno, T006S3_A2170ACTRetVouMes, T006S3_A2167ACTRetTASICod, T006S3_A2171ACTRetVouNum,
               T006S3_A2168ACTRetValRes, T006S3_A2158ACTRetDepre, T006S3_A2162ACTRetRetFec, T006S3_A2166ACTRetRetVouNum, T006S3_A2163ACTRetRetTASICod, T006S3_A2164ACTRetRetVouAno, T006S3_A2165ACTRetRetVouMes, T006S3_A2100ACTActCod, T006S3_A2104ActActItem, T006S3_n2104ActActItem
               }
               , new Object[] {
               T006S4_A2122ACTActDsc
               }
               , new Object[] {
               T006S5_A2100ACTActCod
               }
               , new Object[] {
               T006S6_A2105ACTRetCod, T006S6_A2159ACTRetFec, T006S6_A2122ACTActDsc, T006S6_A2160ACTRetGrupCod, T006S6_n2160ACTRetGrupCod, T006S6_A2161ACTRetObs, T006S6_A2157ACTRetCosto, T006S6_A2169ACTRetVouAno, T006S6_A2170ACTRetVouMes, T006S6_A2167ACTRetTASICod,
               T006S6_A2171ACTRetVouNum, T006S6_A2168ACTRetValRes, T006S6_A2158ACTRetDepre, T006S6_A2162ACTRetRetFec, T006S6_A2166ACTRetRetVouNum, T006S6_A2163ACTRetRetTASICod, T006S6_A2164ACTRetRetVouAno, T006S6_A2165ACTRetRetVouMes, T006S6_A2100ACTActCod, T006S6_A2104ActActItem,
               T006S6_n2104ActActItem
               }
               , new Object[] {
               T006S7_A2122ACTActDsc
               }
               , new Object[] {
               T006S8_A2100ACTActCod
               }
               , new Object[] {
               T006S9_A2105ACTRetCod
               }
               , new Object[] {
               T006S10_A2105ACTRetCod
               }
               , new Object[] {
               T006S11_A2105ACTRetCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006S15_A2122ACTActDsc
               }
               , new Object[] {
               T006S16_A2105ACTRetCod
               }
               , new Object[] {
               T006S17_A2100ACTActCod
               }
            }
         );
      }

      private short Z2169ACTRetVouAno ;
      private short Z2170ACTRetVouMes ;
      private short Z2164ACTRetRetVouAno ;
      private short Z2165ACTRetRetVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2169ACTRetVouAno ;
      private short A2170ACTRetVouMes ;
      private short A2164ACTRetRetVouAno ;
      private short A2165ACTRetRetVouMes ;
      private short GX_JID ;
      private short RcdFound186 ;
      private short nIsDirty_186 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2169ACTRetVouAno ;
      private short ZZ2170ACTRetVouMes ;
      private short ZZ2164ACTRetRetVouAno ;
      private short ZZ2165ACTRetRetVouMes ;
      private int Z2160ACTRetGrupCod ;
      private int Z2167ACTRetTASICod ;
      private int Z2163ACTRetRetTASICod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTRetCod_Enabled ;
      private int edtACTRetFec_Enabled ;
      private int edtACTActCod_Enabled ;
      private int edtACTActDsc_Enabled ;
      private int edtActActItem_Enabled ;
      private int A2160ACTRetGrupCod ;
      private int edtACTRetGrupCod_Enabled ;
      private int edtACTRetObs_Enabled ;
      private int edtACTRetCosto_Enabled ;
      private int edtACTRetVouAno_Enabled ;
      private int edtACTRetVouMes_Enabled ;
      private int A2167ACTRetTASICod ;
      private int edtACTRetTASICod_Enabled ;
      private int edtACTRetVouNum_Enabled ;
      private int edtACTRetValRes_Enabled ;
      private int edtACTRetDepre_Enabled ;
      private int edtACTRetRetFec_Enabled ;
      private int edtACTRetRetVouNum_Enabled ;
      private int A2163ACTRetRetTASICod ;
      private int edtACTRetRetTASICod_Enabled ;
      private int edtACTRetRetVouAno_Enabled ;
      private int edtACTRetRetVouMes_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2160ACTRetGrupCod ;
      private int ZZ2167ACTRetTASICod ;
      private int ZZ2163ACTRetRetTASICod ;
      private decimal Z2157ACTRetCosto ;
      private decimal Z2168ACTRetValRes ;
      private decimal Z2158ACTRetDepre ;
      private decimal A2157ACTRetCosto ;
      private decimal A2168ACTRetValRes ;
      private decimal A2158ACTRetDepre ;
      private decimal ZZ2157ACTRetCosto ;
      private decimal ZZ2168ACTRetValRes ;
      private decimal ZZ2158ACTRetDepre ;
      private string sPrefix ;
      private string Z2171ACTRetVouNum ;
      private string Z2166ACTRetRetVouNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTRetCod_Internalname ;
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
      private string edtACTRetCod_Jsonclick ;
      private string edtACTRetFec_Internalname ;
      private string edtACTRetFec_Jsonclick ;
      private string edtACTActCod_Internalname ;
      private string edtACTActCod_Jsonclick ;
      private string edtACTActDsc_Internalname ;
      private string edtACTActDsc_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtACTRetGrupCod_Internalname ;
      private string edtACTRetGrupCod_Jsonclick ;
      private string edtACTRetObs_Internalname ;
      private string edtACTRetCosto_Internalname ;
      private string edtACTRetCosto_Jsonclick ;
      private string edtACTRetVouAno_Internalname ;
      private string edtACTRetVouAno_Jsonclick ;
      private string edtACTRetVouMes_Internalname ;
      private string edtACTRetVouMes_Jsonclick ;
      private string edtACTRetTASICod_Internalname ;
      private string edtACTRetTASICod_Jsonclick ;
      private string edtACTRetVouNum_Internalname ;
      private string A2171ACTRetVouNum ;
      private string edtACTRetVouNum_Jsonclick ;
      private string edtACTRetValRes_Internalname ;
      private string edtACTRetValRes_Jsonclick ;
      private string edtACTRetDepre_Internalname ;
      private string edtACTRetDepre_Jsonclick ;
      private string edtACTRetRetFec_Internalname ;
      private string edtACTRetRetFec_Jsonclick ;
      private string edtACTRetRetVouNum_Internalname ;
      private string A2166ACTRetRetVouNum ;
      private string edtACTRetRetVouNum_Jsonclick ;
      private string edtACTRetRetTASICod_Internalname ;
      private string edtACTRetRetTASICod_Jsonclick ;
      private string edtACTRetRetVouAno_Internalname ;
      private string edtACTRetRetVouAno_Jsonclick ;
      private string edtACTRetRetVouMes_Internalname ;
      private string edtACTRetRetVouMes_Jsonclick ;
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
      private string sMode186 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2171ACTRetVouNum ;
      private string ZZ2166ACTRetRetVouNum ;
      private DateTime Z2159ACTRetFec ;
      private DateTime Z2162ACTRetRetFec ;
      private DateTime A2159ACTRetFec ;
      private DateTime A2162ACTRetRetFec ;
      private DateTime ZZ2159ACTRetFec ;
      private DateTime ZZ2162ACTRetRetFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2104ActActItem ;
      private bool wbErr ;
      private bool n2160ACTRetGrupCod ;
      private bool Gx_longc ;
      private string A2161ACTRetObs ;
      private string Z2161ACTRetObs ;
      private string ZZ2161ACTRetObs ;
      private string Z2105ACTRetCod ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2105ACTRetCod ;
      private string A2122ACTActDsc ;
      private string Z2122ACTActDsc ;
      private string ZZ2105ACTRetCod ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private string ZZ2122ACTActDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006S6_A2105ACTRetCod ;
      private DateTime[] T006S6_A2159ACTRetFec ;
      private string[] T006S6_A2122ACTActDsc ;
      private int[] T006S6_A2160ACTRetGrupCod ;
      private bool[] T006S6_n2160ACTRetGrupCod ;
      private string[] T006S6_A2161ACTRetObs ;
      private decimal[] T006S6_A2157ACTRetCosto ;
      private short[] T006S6_A2169ACTRetVouAno ;
      private short[] T006S6_A2170ACTRetVouMes ;
      private int[] T006S6_A2167ACTRetTASICod ;
      private string[] T006S6_A2171ACTRetVouNum ;
      private decimal[] T006S6_A2168ACTRetValRes ;
      private decimal[] T006S6_A2158ACTRetDepre ;
      private DateTime[] T006S6_A2162ACTRetRetFec ;
      private string[] T006S6_A2166ACTRetRetVouNum ;
      private int[] T006S6_A2163ACTRetRetTASICod ;
      private short[] T006S6_A2164ACTRetRetVouAno ;
      private short[] T006S6_A2165ACTRetRetVouMes ;
      private string[] T006S6_A2100ACTActCod ;
      private string[] T006S6_A2104ActActItem ;
      private bool[] T006S6_n2104ActActItem ;
      private string[] T006S4_A2122ACTActDsc ;
      private string[] T006S5_A2100ACTActCod ;
      private string[] T006S7_A2122ACTActDsc ;
      private string[] T006S8_A2100ACTActCod ;
      private string[] T006S9_A2105ACTRetCod ;
      private string[] T006S3_A2105ACTRetCod ;
      private DateTime[] T006S3_A2159ACTRetFec ;
      private int[] T006S3_A2160ACTRetGrupCod ;
      private bool[] T006S3_n2160ACTRetGrupCod ;
      private string[] T006S3_A2161ACTRetObs ;
      private decimal[] T006S3_A2157ACTRetCosto ;
      private short[] T006S3_A2169ACTRetVouAno ;
      private short[] T006S3_A2170ACTRetVouMes ;
      private int[] T006S3_A2167ACTRetTASICod ;
      private string[] T006S3_A2171ACTRetVouNum ;
      private decimal[] T006S3_A2168ACTRetValRes ;
      private decimal[] T006S3_A2158ACTRetDepre ;
      private DateTime[] T006S3_A2162ACTRetRetFec ;
      private string[] T006S3_A2166ACTRetRetVouNum ;
      private int[] T006S3_A2163ACTRetRetTASICod ;
      private short[] T006S3_A2164ACTRetRetVouAno ;
      private short[] T006S3_A2165ACTRetRetVouMes ;
      private string[] T006S3_A2100ACTActCod ;
      private string[] T006S3_A2104ActActItem ;
      private bool[] T006S3_n2104ActActItem ;
      private string[] T006S10_A2105ACTRetCod ;
      private string[] T006S11_A2105ACTRetCod ;
      private string[] T006S2_A2105ACTRetCod ;
      private DateTime[] T006S2_A2159ACTRetFec ;
      private int[] T006S2_A2160ACTRetGrupCod ;
      private bool[] T006S2_n2160ACTRetGrupCod ;
      private string[] T006S2_A2161ACTRetObs ;
      private decimal[] T006S2_A2157ACTRetCosto ;
      private short[] T006S2_A2169ACTRetVouAno ;
      private short[] T006S2_A2170ACTRetVouMes ;
      private int[] T006S2_A2167ACTRetTASICod ;
      private string[] T006S2_A2171ACTRetVouNum ;
      private decimal[] T006S2_A2168ACTRetValRes ;
      private decimal[] T006S2_A2158ACTRetDepre ;
      private DateTime[] T006S2_A2162ACTRetRetFec ;
      private string[] T006S2_A2166ACTRetRetVouNum ;
      private int[] T006S2_A2163ACTRetRetTASICod ;
      private short[] T006S2_A2164ACTRetRetVouAno ;
      private short[] T006S2_A2165ACTRetRetVouMes ;
      private string[] T006S2_A2100ACTActCod ;
      private string[] T006S2_A2104ActActItem ;
      private bool[] T006S2_n2104ActActItem ;
      private string[] T006S15_A2122ACTActDsc ;
      private string[] T006S16_A2105ACTRetCod ;
      private string[] T006S17_A2100ACTActCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class actretiroactivo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actretiroactivo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT006S6;
        prmT006S6 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S4;
        prmT006S4 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006S5;
        prmT006S5 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006S7;
        prmT006S7 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006S8;
        prmT006S8 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006S9;
        prmT006S9 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S3;
        prmT006S3 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S10;
        prmT006S10 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S11;
        prmT006S11 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S2;
        prmT006S2 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S12;
        prmT006S12 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0) ,
        new ParDef("@ACTRetFec",GXType.Date,8,0) ,
        new ParDef("@ACTRetGrupCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ACTRetObs",GXType.NVarChar,2000,0) ,
        new ParDef("@ACTRetCosto",GXType.Decimal,15,2) ,
        new ParDef("@ACTRetVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTRetVouMes",GXType.Int16,2,0) ,
        new ParDef("@ACTRetTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTRetVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTRetValRes",GXType.Decimal,15,2) ,
        new ParDef("@ACTRetDepre",GXType.Decimal,15,2) ,
        new ParDef("@ACTRetRetFec",GXType.Date,8,0) ,
        new ParDef("@ACTRetRetVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTRetRetTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTRetRetVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTRetRetVouMes",GXType.Int16,1,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006S13;
        prmT006S13 = new Object[] {
        new ParDef("@ACTRetFec",GXType.Date,8,0) ,
        new ParDef("@ACTRetGrupCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ACTRetObs",GXType.NVarChar,2000,0) ,
        new ParDef("@ACTRetCosto",GXType.Decimal,15,2) ,
        new ParDef("@ACTRetVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTRetVouMes",GXType.Int16,2,0) ,
        new ParDef("@ACTRetTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTRetVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTRetValRes",GXType.Decimal,15,2) ,
        new ParDef("@ACTRetDepre",GXType.Decimal,15,2) ,
        new ParDef("@ACTRetRetFec",GXType.Date,8,0) ,
        new ParDef("@ACTRetRetVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTRetRetTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTRetRetVouAno",GXType.Int16,4,0) ,
        new ParDef("@ACTRetRetVouMes",GXType.Int16,1,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S14;
        prmT006S14 = new Object[] {
        new ParDef("@ACTRetCod",GXType.NVarChar,10,0)
        };
        Object[] prmT006S16;
        prmT006S16 = new Object[] {
        };
        Object[] prmT006S15;
        prmT006S15 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0)
        };
        Object[] prmT006S17;
        prmT006S17 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006S2", "SELECT [ACTRetCod], [ACTRetFec], [ACTRetGrupCod], [ACTRetObs], [ACTRetCosto], [ACTRetVouAno], [ACTRetVouMes], [ACTRetTASICod], [ACTRetVouNum], [ACTRetValRes], [ACTRetDepre], [ACTRetRetFec], [ACTRetRetVouNum], [ACTRetRetTASICod], [ACTRetRetVouAno], [ACTRetRetVouMes], [ACTActCod], [ActActItem] FROM [ACTRETIROACTIVO] WITH (UPDLOCK) WHERE [ACTRetCod] = @ACTRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S3", "SELECT [ACTRetCod], [ACTRetFec], [ACTRetGrupCod], [ACTRetObs], [ACTRetCosto], [ACTRetVouAno], [ACTRetVouMes], [ACTRetTASICod], [ACTRetVouNum], [ACTRetValRes], [ACTRetDepre], [ACTRetRetFec], [ACTRetRetVouNum], [ACTRetRetTASICod], [ACTRetRetVouAno], [ACTRetRetVouMes], [ACTActCod], [ActActItem] FROM [ACTRETIROACTIVO] WHERE [ACTRetCod] = @ACTRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S4", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S5", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S6", "SELECT TM1.[ACTRetCod], TM1.[ACTRetFec], T2.[ACTActDsc], TM1.[ACTRetGrupCod], TM1.[ACTRetObs], TM1.[ACTRetCosto], TM1.[ACTRetVouAno], TM1.[ACTRetVouMes], TM1.[ACTRetTASICod], TM1.[ACTRetVouNum], TM1.[ACTRetValRes], TM1.[ACTRetDepre], TM1.[ACTRetRetFec], TM1.[ACTRetRetVouNum], TM1.[ACTRetRetTASICod], TM1.[ACTRetRetVouAno], TM1.[ACTRetRetVouMes], TM1.[ACTActCod], TM1.[ActActItem] FROM ([ACTRETIROACTIVO] TM1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = TM1.[ACTActCod]) WHERE TM1.[ACTRetCod] = @ACTRetCod ORDER BY TM1.[ACTRetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006S6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S7", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S8", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S9", "SELECT [ACTRetCod] FROM [ACTRETIROACTIVO] WHERE [ACTRetCod] = @ACTRetCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006S9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S10", "SELECT TOP 1 [ACTRetCod] FROM [ACTRETIROACTIVO] WHERE ( [ACTRetCod] > @ACTRetCod) ORDER BY [ACTRetCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006S10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006S11", "SELECT TOP 1 [ACTRetCod] FROM [ACTRETIROACTIVO] WHERE ( [ACTRetCod] < @ACTRetCod) ORDER BY [ACTRetCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006S11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006S12", "INSERT INTO [ACTRETIROACTIVO]([ACTRetCod], [ACTRetFec], [ACTRetGrupCod], [ACTRetObs], [ACTRetCosto], [ACTRetVouAno], [ACTRetVouMes], [ACTRetTASICod], [ACTRetVouNum], [ACTRetValRes], [ACTRetDepre], [ACTRetRetFec], [ACTRetRetVouNum], [ACTRetRetTASICod], [ACTRetRetVouAno], [ACTRetRetVouMes], [ACTActCod], [ActActItem]) VALUES(@ACTRetCod, @ACTRetFec, @ACTRetGrupCod, @ACTRetObs, @ACTRetCosto, @ACTRetVouAno, @ACTRetVouMes, @ACTRetTASICod, @ACTRetVouNum, @ACTRetValRes, @ACTRetDepre, @ACTRetRetFec, @ACTRetRetVouNum, @ACTRetRetTASICod, @ACTRetRetVouAno, @ACTRetRetVouMes, @ACTActCod, @ActActItem)", GxErrorMask.GX_NOMASK,prmT006S12)
           ,new CursorDef("T006S13", "UPDATE [ACTRETIROACTIVO] SET [ACTRetFec]=@ACTRetFec, [ACTRetGrupCod]=@ACTRetGrupCod, [ACTRetObs]=@ACTRetObs, [ACTRetCosto]=@ACTRetCosto, [ACTRetVouAno]=@ACTRetVouAno, [ACTRetVouMes]=@ACTRetVouMes, [ACTRetTASICod]=@ACTRetTASICod, [ACTRetVouNum]=@ACTRetVouNum, [ACTRetValRes]=@ACTRetValRes, [ACTRetDepre]=@ACTRetDepre, [ACTRetRetFec]=@ACTRetRetFec, [ACTRetRetVouNum]=@ACTRetRetVouNum, [ACTRetRetTASICod]=@ACTRetRetTASICod, [ACTRetRetVouAno]=@ACTRetRetVouAno, [ACTRetRetVouMes]=@ACTRetRetVouMes, [ACTActCod]=@ACTActCod, [ActActItem]=@ActActItem  WHERE [ACTRetCod] = @ACTRetCod", GxErrorMask.GX_NOMASK,prmT006S13)
           ,new CursorDef("T006S14", "DELETE FROM [ACTRETIROACTIVO]  WHERE [ACTRetCod] = @ACTRetCod", GxErrorMask.GX_NOMASK,prmT006S14)
           ,new CursorDef("T006S15", "SELECT [ACTActDsc] FROM [ACTACTIVOS] WHERE [ACTActCod] = @ACTActCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S16", "SELECT [ACTRetCod] FROM [ACTRETIROACTIVO] ORDER BY [ACTRetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006S16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006S17", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006S17,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 10);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((short[]) buf[15])[0] = rslt.getShort(15);
              ((short[]) buf[16])[0] = rslt.getShort(16);
              ((string[]) buf[17])[0] = rslt.getVarchar(17);
              ((string[]) buf[18])[0] = rslt.getVarchar(18);
              ((bool[]) buf[19])[0] = rslt.wasNull(18);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 10);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((short[]) buf[15])[0] = rslt.getShort(15);
              ((short[]) buf[16])[0] = rslt.getShort(16);
              ((string[]) buf[17])[0] = rslt.getVarchar(17);
              ((string[]) buf[18])[0] = rslt.getVarchar(18);
              ((bool[]) buf[19])[0] = rslt.wasNull(18);
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((int[]) buf[9])[0] = rslt.getInt(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
              ((string[]) buf[14])[0] = rslt.getString(14, 10);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((short[]) buf[16])[0] = rslt.getShort(16);
              ((short[]) buf[17])[0] = rslt.getShort(17);
              ((string[]) buf[18])[0] = rslt.getVarchar(18);
              ((string[]) buf[19])[0] = rslt.getVarchar(19);
              ((bool[]) buf[20])[0] = rslt.wasNull(19);
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
