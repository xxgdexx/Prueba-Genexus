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
   public class tsmovcajachicasubir : GXDataArea
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
            Form.Meta.addItem("description", "TSMOVCAJACHICASUBIR", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsmovcajachicasubir( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsmovcajachicasubir( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TSMOVCAJACHICASUBIR", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICASUBIR.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSMOVCAJACHICASUBIR.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSCajCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSCajCod_Internalname, "Caja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A400SCajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A400SCajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A400SCajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCajCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCajCod_Internalname, "Caja", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCajCod_Internalname, StringUtil.RTrim( A401SMVLCajCod), StringUtil.RTrim( context.localUtil.Format( A401SMVLCajCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCajCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLITem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLITem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLITem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A402SMVLITem), 6, 0, ".", "")), StringUtil.LTrim( ((edtSMVLITem_Enabled!=0) ? context.localUtil.Format( (decimal)(A402SMVLITem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A402SMVLITem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLITem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLITem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCajFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCajFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSMVLCajFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSMVLCajFec_Internalname, context.localUtil.Format(A1868SMVLCajFec, "99/99/99"), context.localUtil.Format( A1868SMVLCajFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCajFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCajFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_bitmap( context, edtSMVLCajFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSMVLCajFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCajConc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCajConc_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCajConc_Internalname, StringUtil.RTrim( A1865SMVLCajConc), StringUtil.RTrim( context.localUtil.Format( A1865SMVLCajConc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCajConc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCajConc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCajDoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCajDoc_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCajDoc_Internalname, StringUtil.RTrim( A1866SMVLCajDoc), StringUtil.RTrim( context.localUtil.Format( A1866SMVLCajDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCajDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCajDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLConcCajCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLConcCajCod_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLConcCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1871SMVLConcCajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSMVLConcCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1871SMVLConcCajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1871SMVLConcCajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLConcCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLConcCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCajTCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCajTCod_Internalname, "D", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCajTCod_Internalname, StringUtil.RTrim( A1869SMVLCajTCod), StringUtil.RTrim( context.localUtil.Format( A1869SMVLCajTCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCajTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCajTCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCajDocP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCajDocP_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCajDocP_Internalname, StringUtil.RTrim( A1867SMVLCajDocP), StringUtil.RTrim( context.localUtil.Format( A1867SMVLCajDocP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCajDocP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCajDocP_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLComFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLComFec_Internalname, "Emisión", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSMVLComFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSMVLComFec_Internalname, context.localUtil.Format(A1870SMVLComFec, "99/99/99"), context.localUtil.Format( A1870SMVLComFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLComFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLComFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_bitmap( context, edtSMVLComFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSMVLComFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLSubAfecto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLSubAfecto_Internalname, "Afecto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLSubAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1877SMVLSubAfecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtSMVLSubAfecto_Enabled!=0) ? context.localUtil.Format( A1877SMVLSubAfecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1877SMVLSubAfecto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLSubAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLSubAfecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLSubInafecto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLSubInafecto_Internalname, "Inafecto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLSubInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1878SMVLSubInafecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtSMVLSubInafecto_Enabled!=0) ? context.localUtil.Format( A1878SMVLSubInafecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1878SMVLSubInafecto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLSubInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLSubInafecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLIGV_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLIGV_Internalname, "G. V.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLIGV_Internalname, StringUtil.LTrim( StringUtil.NToC( A1875SMVLIGV, 17, 2, ".", "")), StringUtil.LTrim( ((edtSMVLIGV_Enabled!=0) ? context.localUtil.Format( A1875SMVLIGV, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1875SMVLIGV, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLIGV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLIGV_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLTotal_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1879SMVLTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtSMVLTotal_Enabled!=0) ? context.localUtil.Format( A1879SMVLTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1879SMVLTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLPrvCod_Internalname, "U. C.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLPrvCod_Internalname, StringUtil.RTrim( A1876SMVLPrvCod), StringUtil.RTrim( context.localUtil.Format( A1876SMVLPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCueCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCueCod_Internalname, StringUtil.RTrim( A1874SMVLCueCod), StringUtil.RTrim( context.localUtil.Format( A1874SMVLCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCosCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCosCod_Internalname, "de Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCosCod_Internalname, StringUtil.RTrim( A1872SMVLCosCod), StringUtil.RTrim( context.localUtil.Format( A1872SMVLCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSMVLCueAuxCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSMVLCueAuxCod_Internalname, "Auxiliar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSMVLCueAuxCod_Internalname, StringUtil.RTrim( A1873SMVLCueAuxCod), StringUtil.RTrim( context.localUtil.Format( A1873SMVLCueAuxCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSMVLCueAuxCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSMVLCueAuxCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICASUBIR.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICASUBIR.htm");
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
            Z400SCajCod = (int)(context.localUtil.CToN( cgiGet( "Z400SCajCod"), ".", ","));
            Z401SMVLCajCod = cgiGet( "Z401SMVLCajCod");
            Z402SMVLITem = (int)(context.localUtil.CToN( cgiGet( "Z402SMVLITem"), ".", ","));
            Z1868SMVLCajFec = context.localUtil.CToD( cgiGet( "Z1868SMVLCajFec"), 0);
            Z1865SMVLCajConc = cgiGet( "Z1865SMVLCajConc");
            Z1866SMVLCajDoc = cgiGet( "Z1866SMVLCajDoc");
            Z1871SMVLConcCajCod = (int)(context.localUtil.CToN( cgiGet( "Z1871SMVLConcCajCod"), ".", ","));
            Z1869SMVLCajTCod = cgiGet( "Z1869SMVLCajTCod");
            Z1867SMVLCajDocP = cgiGet( "Z1867SMVLCajDocP");
            Z1870SMVLComFec = context.localUtil.CToD( cgiGet( "Z1870SMVLComFec"), 0);
            Z1877SMVLSubAfecto = context.localUtil.CToN( cgiGet( "Z1877SMVLSubAfecto"), ".", ",");
            Z1878SMVLSubInafecto = context.localUtil.CToN( cgiGet( "Z1878SMVLSubInafecto"), ".", ",");
            Z1875SMVLIGV = context.localUtil.CToN( cgiGet( "Z1875SMVLIGV"), ".", ",");
            Z1879SMVLTotal = context.localUtil.CToN( cgiGet( "Z1879SMVLTotal"), ".", ",");
            Z1876SMVLPrvCod = cgiGet( "Z1876SMVLPrvCod");
            Z1874SMVLCueCod = cgiGet( "Z1874SMVLCueCod");
            Z1872SMVLCosCod = cgiGet( "Z1872SMVLCosCod");
            Z1873SMVLCueAuxCod = cgiGet( "Z1873SMVLCueAuxCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SCAJCOD");
               AnyError = 1;
               GX_FocusControl = edtSCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A400SCajCod = 0;
               AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
            }
            else
            {
               A400SCajCod = (int)(context.localUtil.CToN( cgiGet( edtSCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
            }
            A401SMVLCajCod = cgiGet( edtSMVLCajCod_Internalname);
            AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSMVLITem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSMVLITem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SMVLITEM");
               AnyError = 1;
               GX_FocusControl = edtSMVLITem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A402SMVLITem = 0;
               AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
            }
            else
            {
               A402SMVLITem = (int)(context.localUtil.CToN( cgiGet( edtSMVLITem_Internalname), ".", ","));
               AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtSMVLCajFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "SMVLCAJFEC");
               AnyError = 1;
               GX_FocusControl = edtSMVLCajFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1868SMVLCajFec = DateTime.MinValue;
               AssignAttri("", false, "A1868SMVLCajFec", context.localUtil.Format(A1868SMVLCajFec, "99/99/99"));
            }
            else
            {
               A1868SMVLCajFec = context.localUtil.CToD( cgiGet( edtSMVLCajFec_Internalname), 2);
               AssignAttri("", false, "A1868SMVLCajFec", context.localUtil.Format(A1868SMVLCajFec, "99/99/99"));
            }
            A1865SMVLCajConc = cgiGet( edtSMVLCajConc_Internalname);
            AssignAttri("", false, "A1865SMVLCajConc", A1865SMVLCajConc);
            A1866SMVLCajDoc = cgiGet( edtSMVLCajDoc_Internalname);
            AssignAttri("", false, "A1866SMVLCajDoc", A1866SMVLCajDoc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSMVLConcCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSMVLConcCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SMVLCONCCAJCOD");
               AnyError = 1;
               GX_FocusControl = edtSMVLConcCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1871SMVLConcCajCod = 0;
               AssignAttri("", false, "A1871SMVLConcCajCod", StringUtil.LTrimStr( (decimal)(A1871SMVLConcCajCod), 6, 0));
            }
            else
            {
               A1871SMVLConcCajCod = (int)(context.localUtil.CToN( cgiGet( edtSMVLConcCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A1871SMVLConcCajCod", StringUtil.LTrimStr( (decimal)(A1871SMVLConcCajCod), 6, 0));
            }
            A1869SMVLCajTCod = cgiGet( edtSMVLCajTCod_Internalname);
            AssignAttri("", false, "A1869SMVLCajTCod", A1869SMVLCajTCod);
            A1867SMVLCajDocP = cgiGet( edtSMVLCajDocP_Internalname);
            AssignAttri("", false, "A1867SMVLCajDocP", A1867SMVLCajDocP);
            if ( context.localUtil.VCDate( cgiGet( edtSMVLComFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Emisión"}), 1, "SMVLCOMFEC");
               AnyError = 1;
               GX_FocusControl = edtSMVLComFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1870SMVLComFec = DateTime.MinValue;
               AssignAttri("", false, "A1870SMVLComFec", context.localUtil.Format(A1870SMVLComFec, "99/99/99"));
            }
            else
            {
               A1870SMVLComFec = context.localUtil.CToD( cgiGet( edtSMVLComFec_Internalname), 2);
               AssignAttri("", false, "A1870SMVLComFec", context.localUtil.Format(A1870SMVLComFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSMVLSubAfecto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSMVLSubAfecto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SMVLSUBAFECTO");
               AnyError = 1;
               GX_FocusControl = edtSMVLSubAfecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1877SMVLSubAfecto = 0;
               AssignAttri("", false, "A1877SMVLSubAfecto", StringUtil.LTrimStr( A1877SMVLSubAfecto, 15, 2));
            }
            else
            {
               A1877SMVLSubAfecto = context.localUtil.CToN( cgiGet( edtSMVLSubAfecto_Internalname), ".", ",");
               AssignAttri("", false, "A1877SMVLSubAfecto", StringUtil.LTrimStr( A1877SMVLSubAfecto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSMVLSubInafecto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSMVLSubInafecto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SMVLSUBINAFECTO");
               AnyError = 1;
               GX_FocusControl = edtSMVLSubInafecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1878SMVLSubInafecto = 0;
               AssignAttri("", false, "A1878SMVLSubInafecto", StringUtil.LTrimStr( A1878SMVLSubInafecto, 15, 2));
            }
            else
            {
               A1878SMVLSubInafecto = context.localUtil.CToN( cgiGet( edtSMVLSubInafecto_Internalname), ".", ",");
               AssignAttri("", false, "A1878SMVLSubInafecto", StringUtil.LTrimStr( A1878SMVLSubInafecto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSMVLIGV_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSMVLIGV_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SMVLIGV");
               AnyError = 1;
               GX_FocusControl = edtSMVLIGV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1875SMVLIGV = 0;
               AssignAttri("", false, "A1875SMVLIGV", StringUtil.LTrimStr( A1875SMVLIGV, 15, 2));
            }
            else
            {
               A1875SMVLIGV = context.localUtil.CToN( cgiGet( edtSMVLIGV_Internalname), ".", ",");
               AssignAttri("", false, "A1875SMVLIGV", StringUtil.LTrimStr( A1875SMVLIGV, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSMVLTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSMVLTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SMVLTOTAL");
               AnyError = 1;
               GX_FocusControl = edtSMVLTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1879SMVLTotal = 0;
               AssignAttri("", false, "A1879SMVLTotal", StringUtil.LTrimStr( A1879SMVLTotal, 15, 2));
            }
            else
            {
               A1879SMVLTotal = context.localUtil.CToN( cgiGet( edtSMVLTotal_Internalname), ".", ",");
               AssignAttri("", false, "A1879SMVLTotal", StringUtil.LTrimStr( A1879SMVLTotal, 15, 2));
            }
            A1876SMVLPrvCod = cgiGet( edtSMVLPrvCod_Internalname);
            AssignAttri("", false, "A1876SMVLPrvCod", A1876SMVLPrvCod);
            A1874SMVLCueCod = cgiGet( edtSMVLCueCod_Internalname);
            AssignAttri("", false, "A1874SMVLCueCod", A1874SMVLCueCod);
            A1872SMVLCosCod = cgiGet( edtSMVLCosCod_Internalname);
            AssignAttri("", false, "A1872SMVLCosCod", A1872SMVLCosCod);
            A1873SMVLCueAuxCod = cgiGet( edtSMVLCueAuxCod_Internalname);
            AssignAttri("", false, "A1873SMVLCueAuxCod", A1873SMVLCueAuxCod);
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
               A400SCajCod = (int)(NumberUtil.Val( GetPar( "SCajCod"), "."));
               AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
               A401SMVLCajCod = GetPar( "SMVLCajCod");
               AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
               A402SMVLITem = (int)(NumberUtil.Val( GetPar( "SMVLITem"), "."));
               AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
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
               InitAll4W163( ) ;
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
         DisableAttributes4W163( ) ;
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

      protected void ResetCaption4W0( )
      {
      }

      protected void ZM4W163( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1868SMVLCajFec = T004W3_A1868SMVLCajFec[0];
               Z1865SMVLCajConc = T004W3_A1865SMVLCajConc[0];
               Z1866SMVLCajDoc = T004W3_A1866SMVLCajDoc[0];
               Z1871SMVLConcCajCod = T004W3_A1871SMVLConcCajCod[0];
               Z1869SMVLCajTCod = T004W3_A1869SMVLCajTCod[0];
               Z1867SMVLCajDocP = T004W3_A1867SMVLCajDocP[0];
               Z1870SMVLComFec = T004W3_A1870SMVLComFec[0];
               Z1877SMVLSubAfecto = T004W3_A1877SMVLSubAfecto[0];
               Z1878SMVLSubInafecto = T004W3_A1878SMVLSubInafecto[0];
               Z1875SMVLIGV = T004W3_A1875SMVLIGV[0];
               Z1879SMVLTotal = T004W3_A1879SMVLTotal[0];
               Z1876SMVLPrvCod = T004W3_A1876SMVLPrvCod[0];
               Z1874SMVLCueCod = T004W3_A1874SMVLCueCod[0];
               Z1872SMVLCosCod = T004W3_A1872SMVLCosCod[0];
               Z1873SMVLCueAuxCod = T004W3_A1873SMVLCueAuxCod[0];
            }
            else
            {
               Z1868SMVLCajFec = A1868SMVLCajFec;
               Z1865SMVLCajConc = A1865SMVLCajConc;
               Z1866SMVLCajDoc = A1866SMVLCajDoc;
               Z1871SMVLConcCajCod = A1871SMVLConcCajCod;
               Z1869SMVLCajTCod = A1869SMVLCajTCod;
               Z1867SMVLCajDocP = A1867SMVLCajDocP;
               Z1870SMVLComFec = A1870SMVLComFec;
               Z1877SMVLSubAfecto = A1877SMVLSubAfecto;
               Z1878SMVLSubInafecto = A1878SMVLSubInafecto;
               Z1875SMVLIGV = A1875SMVLIGV;
               Z1879SMVLTotal = A1879SMVLTotal;
               Z1876SMVLPrvCod = A1876SMVLPrvCod;
               Z1874SMVLCueCod = A1874SMVLCueCod;
               Z1872SMVLCosCod = A1872SMVLCosCod;
               Z1873SMVLCueAuxCod = A1873SMVLCueAuxCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z400SCajCod = A400SCajCod;
            Z401SMVLCajCod = A401SMVLCajCod;
            Z402SMVLITem = A402SMVLITem;
            Z1868SMVLCajFec = A1868SMVLCajFec;
            Z1865SMVLCajConc = A1865SMVLCajConc;
            Z1866SMVLCajDoc = A1866SMVLCajDoc;
            Z1871SMVLConcCajCod = A1871SMVLConcCajCod;
            Z1869SMVLCajTCod = A1869SMVLCajTCod;
            Z1867SMVLCajDocP = A1867SMVLCajDocP;
            Z1870SMVLComFec = A1870SMVLComFec;
            Z1877SMVLSubAfecto = A1877SMVLSubAfecto;
            Z1878SMVLSubInafecto = A1878SMVLSubInafecto;
            Z1875SMVLIGV = A1875SMVLIGV;
            Z1879SMVLTotal = A1879SMVLTotal;
            Z1876SMVLPrvCod = A1876SMVLPrvCod;
            Z1874SMVLCueCod = A1874SMVLCueCod;
            Z1872SMVLCosCod = A1872SMVLCosCod;
            Z1873SMVLCueAuxCod = A1873SMVLCueAuxCod;
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

      protected void Load4W163( )
      {
         /* Using cursor T004W4 */
         pr_default.execute(2, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound163 = 1;
            A1868SMVLCajFec = T004W4_A1868SMVLCajFec[0];
            AssignAttri("", false, "A1868SMVLCajFec", context.localUtil.Format(A1868SMVLCajFec, "99/99/99"));
            A1865SMVLCajConc = T004W4_A1865SMVLCajConc[0];
            AssignAttri("", false, "A1865SMVLCajConc", A1865SMVLCajConc);
            A1866SMVLCajDoc = T004W4_A1866SMVLCajDoc[0];
            AssignAttri("", false, "A1866SMVLCajDoc", A1866SMVLCajDoc);
            A1871SMVLConcCajCod = T004W4_A1871SMVLConcCajCod[0];
            AssignAttri("", false, "A1871SMVLConcCajCod", StringUtil.LTrimStr( (decimal)(A1871SMVLConcCajCod), 6, 0));
            A1869SMVLCajTCod = T004W4_A1869SMVLCajTCod[0];
            AssignAttri("", false, "A1869SMVLCajTCod", A1869SMVLCajTCod);
            A1867SMVLCajDocP = T004W4_A1867SMVLCajDocP[0];
            AssignAttri("", false, "A1867SMVLCajDocP", A1867SMVLCajDocP);
            A1870SMVLComFec = T004W4_A1870SMVLComFec[0];
            AssignAttri("", false, "A1870SMVLComFec", context.localUtil.Format(A1870SMVLComFec, "99/99/99"));
            A1877SMVLSubAfecto = T004W4_A1877SMVLSubAfecto[0];
            AssignAttri("", false, "A1877SMVLSubAfecto", StringUtil.LTrimStr( A1877SMVLSubAfecto, 15, 2));
            A1878SMVLSubInafecto = T004W4_A1878SMVLSubInafecto[0];
            AssignAttri("", false, "A1878SMVLSubInafecto", StringUtil.LTrimStr( A1878SMVLSubInafecto, 15, 2));
            A1875SMVLIGV = T004W4_A1875SMVLIGV[0];
            AssignAttri("", false, "A1875SMVLIGV", StringUtil.LTrimStr( A1875SMVLIGV, 15, 2));
            A1879SMVLTotal = T004W4_A1879SMVLTotal[0];
            AssignAttri("", false, "A1879SMVLTotal", StringUtil.LTrimStr( A1879SMVLTotal, 15, 2));
            A1876SMVLPrvCod = T004W4_A1876SMVLPrvCod[0];
            AssignAttri("", false, "A1876SMVLPrvCod", A1876SMVLPrvCod);
            A1874SMVLCueCod = T004W4_A1874SMVLCueCod[0];
            AssignAttri("", false, "A1874SMVLCueCod", A1874SMVLCueCod);
            A1872SMVLCosCod = T004W4_A1872SMVLCosCod[0];
            AssignAttri("", false, "A1872SMVLCosCod", A1872SMVLCosCod);
            A1873SMVLCueAuxCod = T004W4_A1873SMVLCueAuxCod[0];
            AssignAttri("", false, "A1873SMVLCueAuxCod", A1873SMVLCueAuxCod);
            ZM4W163( -3) ;
         }
         pr_default.close(2);
         OnLoadActions4W163( ) ;
      }

      protected void OnLoadActions4W163( )
      {
      }

      protected void CheckExtendedTable4W163( )
      {
         nIsDirty_163 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1868SMVLCajFec) || ( DateTimeUtil.ResetTime ( A1868SMVLCajFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "SMVLCAJFEC");
            AnyError = 1;
            GX_FocusControl = edtSMVLCajFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1870SMVLComFec) || ( DateTimeUtil.ResetTime ( A1870SMVLComFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Emisión fuera de rango", "OutOfRange", 1, "SMVLCOMFEC");
            AnyError = 1;
            GX_FocusControl = edtSMVLComFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors4W163( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey4W163( )
      {
         /* Using cursor T004W5 */
         pr_default.execute(3, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound163 = 1;
         }
         else
         {
            RcdFound163 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004W3 */
         pr_default.execute(1, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4W163( 3) ;
            RcdFound163 = 1;
            A400SCajCod = T004W3_A400SCajCod[0];
            AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
            A401SMVLCajCod = T004W3_A401SMVLCajCod[0];
            AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
            A402SMVLITem = T004W3_A402SMVLITem[0];
            AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
            A1868SMVLCajFec = T004W3_A1868SMVLCajFec[0];
            AssignAttri("", false, "A1868SMVLCajFec", context.localUtil.Format(A1868SMVLCajFec, "99/99/99"));
            A1865SMVLCajConc = T004W3_A1865SMVLCajConc[0];
            AssignAttri("", false, "A1865SMVLCajConc", A1865SMVLCajConc);
            A1866SMVLCajDoc = T004W3_A1866SMVLCajDoc[0];
            AssignAttri("", false, "A1866SMVLCajDoc", A1866SMVLCajDoc);
            A1871SMVLConcCajCod = T004W3_A1871SMVLConcCajCod[0];
            AssignAttri("", false, "A1871SMVLConcCajCod", StringUtil.LTrimStr( (decimal)(A1871SMVLConcCajCod), 6, 0));
            A1869SMVLCajTCod = T004W3_A1869SMVLCajTCod[0];
            AssignAttri("", false, "A1869SMVLCajTCod", A1869SMVLCajTCod);
            A1867SMVLCajDocP = T004W3_A1867SMVLCajDocP[0];
            AssignAttri("", false, "A1867SMVLCajDocP", A1867SMVLCajDocP);
            A1870SMVLComFec = T004W3_A1870SMVLComFec[0];
            AssignAttri("", false, "A1870SMVLComFec", context.localUtil.Format(A1870SMVLComFec, "99/99/99"));
            A1877SMVLSubAfecto = T004W3_A1877SMVLSubAfecto[0];
            AssignAttri("", false, "A1877SMVLSubAfecto", StringUtil.LTrimStr( A1877SMVLSubAfecto, 15, 2));
            A1878SMVLSubInafecto = T004W3_A1878SMVLSubInafecto[0];
            AssignAttri("", false, "A1878SMVLSubInafecto", StringUtil.LTrimStr( A1878SMVLSubInafecto, 15, 2));
            A1875SMVLIGV = T004W3_A1875SMVLIGV[0];
            AssignAttri("", false, "A1875SMVLIGV", StringUtil.LTrimStr( A1875SMVLIGV, 15, 2));
            A1879SMVLTotal = T004W3_A1879SMVLTotal[0];
            AssignAttri("", false, "A1879SMVLTotal", StringUtil.LTrimStr( A1879SMVLTotal, 15, 2));
            A1876SMVLPrvCod = T004W3_A1876SMVLPrvCod[0];
            AssignAttri("", false, "A1876SMVLPrvCod", A1876SMVLPrvCod);
            A1874SMVLCueCod = T004W3_A1874SMVLCueCod[0];
            AssignAttri("", false, "A1874SMVLCueCod", A1874SMVLCueCod);
            A1872SMVLCosCod = T004W3_A1872SMVLCosCod[0];
            AssignAttri("", false, "A1872SMVLCosCod", A1872SMVLCosCod);
            A1873SMVLCueAuxCod = T004W3_A1873SMVLCueAuxCod[0];
            AssignAttri("", false, "A1873SMVLCueAuxCod", A1873SMVLCueAuxCod);
            Z400SCajCod = A400SCajCod;
            Z401SMVLCajCod = A401SMVLCajCod;
            Z402SMVLITem = A402SMVLITem;
            sMode163 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4W163( ) ;
            if ( AnyError == 1 )
            {
               RcdFound163 = 0;
               InitializeNonKey4W163( ) ;
            }
            Gx_mode = sMode163;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound163 = 0;
            InitializeNonKey4W163( ) ;
            sMode163 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode163;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4W163( ) ;
         if ( RcdFound163 == 0 )
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
         RcdFound163 = 0;
         /* Using cursor T004W6 */
         pr_default.execute(4, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T004W6_A400SCajCod[0] < A400SCajCod ) || ( T004W6_A400SCajCod[0] == A400SCajCod ) && ( StringUtil.StrCmp(T004W6_A401SMVLCajCod[0], A401SMVLCajCod) < 0 ) || ( StringUtil.StrCmp(T004W6_A401SMVLCajCod[0], A401SMVLCajCod) == 0 ) && ( T004W6_A400SCajCod[0] == A400SCajCod ) && ( T004W6_A402SMVLITem[0] < A402SMVLITem ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T004W6_A400SCajCod[0] > A400SCajCod ) || ( T004W6_A400SCajCod[0] == A400SCajCod ) && ( StringUtil.StrCmp(T004W6_A401SMVLCajCod[0], A401SMVLCajCod) > 0 ) || ( StringUtil.StrCmp(T004W6_A401SMVLCajCod[0], A401SMVLCajCod) == 0 ) && ( T004W6_A400SCajCod[0] == A400SCajCod ) && ( T004W6_A402SMVLITem[0] > A402SMVLITem ) ) )
            {
               A400SCajCod = T004W6_A400SCajCod[0];
               AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
               A401SMVLCajCod = T004W6_A401SMVLCajCod[0];
               AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
               A402SMVLITem = T004W6_A402SMVLITem[0];
               AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
               RcdFound163 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound163 = 0;
         /* Using cursor T004W7 */
         pr_default.execute(5, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T004W7_A400SCajCod[0] > A400SCajCod ) || ( T004W7_A400SCajCod[0] == A400SCajCod ) && ( StringUtil.StrCmp(T004W7_A401SMVLCajCod[0], A401SMVLCajCod) > 0 ) || ( StringUtil.StrCmp(T004W7_A401SMVLCajCod[0], A401SMVLCajCod) == 0 ) && ( T004W7_A400SCajCod[0] == A400SCajCod ) && ( T004W7_A402SMVLITem[0] > A402SMVLITem ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T004W7_A400SCajCod[0] < A400SCajCod ) || ( T004W7_A400SCajCod[0] == A400SCajCod ) && ( StringUtil.StrCmp(T004W7_A401SMVLCajCod[0], A401SMVLCajCod) < 0 ) || ( StringUtil.StrCmp(T004W7_A401SMVLCajCod[0], A401SMVLCajCod) == 0 ) && ( T004W7_A400SCajCod[0] == A400SCajCod ) && ( T004W7_A402SMVLITem[0] < A402SMVLITem ) ) )
            {
               A400SCajCod = T004W7_A400SCajCod[0];
               AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
               A401SMVLCajCod = T004W7_A401SMVLCajCod[0];
               AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
               A402SMVLITem = T004W7_A402SMVLITem[0];
               AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
               RcdFound163 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4W163( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4W163( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound163 == 1 )
            {
               if ( ( A400SCajCod != Z400SCajCod ) || ( StringUtil.StrCmp(A401SMVLCajCod, Z401SMVLCajCod) != 0 ) || ( A402SMVLITem != Z402SMVLITem ) )
               {
                  A400SCajCod = Z400SCajCod;
                  AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
                  A401SMVLCajCod = Z401SMVLCajCod;
                  AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
                  A402SMVLITem = Z402SMVLITem;
                  AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SCAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4W163( ) ;
                  GX_FocusControl = edtSCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A400SCajCod != Z400SCajCod ) || ( StringUtil.StrCmp(A401SMVLCajCod, Z401SMVLCajCod) != 0 ) || ( A402SMVLITem != Z402SMVLITem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4W163( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SCAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtSCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4W163( ) ;
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
         if ( ( A400SCajCod != Z400SCajCod ) || ( StringUtil.StrCmp(A401SMVLCajCod, Z401SMVLCajCod) != 0 ) || ( A402SMVLITem != Z402SMVLITem ) )
         {
            A400SCajCod = Z400SCajCod;
            AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
            A401SMVLCajCod = Z401SMVLCajCod;
            AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
            A402SMVLITem = Z402SMVLITem;
            AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtSCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSCajCod_Internalname;
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
         if ( RcdFound163 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtSCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4W163( ) ;
         if ( RcdFound163 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4W163( ) ;
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
         if ( RcdFound163 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSMVLCajFec_Internalname;
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
         if ( RcdFound163 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSMVLCajFec_Internalname;
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
         ScanStart4W163( ) ;
         if ( RcdFound163 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound163 != 0 )
            {
               ScanNext4W163( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4W163( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4W163( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004W2 */
            pr_default.execute(0, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVCAJACHICASUBIR"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1868SMVLCajFec ) != DateTimeUtil.ResetTime ( T004W2_A1868SMVLCajFec[0] ) ) || ( StringUtil.StrCmp(Z1865SMVLCajConc, T004W2_A1865SMVLCajConc[0]) != 0 ) || ( StringUtil.StrCmp(Z1866SMVLCajDoc, T004W2_A1866SMVLCajDoc[0]) != 0 ) || ( Z1871SMVLConcCajCod != T004W2_A1871SMVLConcCajCod[0] ) || ( StringUtil.StrCmp(Z1869SMVLCajTCod, T004W2_A1869SMVLCajTCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1867SMVLCajDocP, T004W2_A1867SMVLCajDocP[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1870SMVLComFec ) != DateTimeUtil.ResetTime ( T004W2_A1870SMVLComFec[0] ) ) || ( Z1877SMVLSubAfecto != T004W2_A1877SMVLSubAfecto[0] ) || ( Z1878SMVLSubInafecto != T004W2_A1878SMVLSubInafecto[0] ) || ( Z1875SMVLIGV != T004W2_A1875SMVLIGV[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1879SMVLTotal != T004W2_A1879SMVLTotal[0] ) || ( StringUtil.StrCmp(Z1876SMVLPrvCod, T004W2_A1876SMVLPrvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1874SMVLCueCod, T004W2_A1874SMVLCueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1872SMVLCosCod, T004W2_A1872SMVLCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1873SMVLCueAuxCod, T004W2_A1873SMVLCueAuxCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1868SMVLCajFec ) != DateTimeUtil.ResetTime ( T004W2_A1868SMVLCajFec[0] ) )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCajFec");
                  GXUtil.WriteLogRaw("Old: ",Z1868SMVLCajFec);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1868SMVLCajFec[0]);
               }
               if ( StringUtil.StrCmp(Z1865SMVLCajConc, T004W2_A1865SMVLCajConc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCajConc");
                  GXUtil.WriteLogRaw("Old: ",Z1865SMVLCajConc);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1865SMVLCajConc[0]);
               }
               if ( StringUtil.StrCmp(Z1866SMVLCajDoc, T004W2_A1866SMVLCajDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCajDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1866SMVLCajDoc);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1866SMVLCajDoc[0]);
               }
               if ( Z1871SMVLConcCajCod != T004W2_A1871SMVLConcCajCod[0] )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLConcCajCod");
                  GXUtil.WriteLogRaw("Old: ",Z1871SMVLConcCajCod);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1871SMVLConcCajCod[0]);
               }
               if ( StringUtil.StrCmp(Z1869SMVLCajTCod, T004W2_A1869SMVLCajTCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCajTCod");
                  GXUtil.WriteLogRaw("Old: ",Z1869SMVLCajTCod);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1869SMVLCajTCod[0]);
               }
               if ( StringUtil.StrCmp(Z1867SMVLCajDocP, T004W2_A1867SMVLCajDocP[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCajDocP");
                  GXUtil.WriteLogRaw("Old: ",Z1867SMVLCajDocP);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1867SMVLCajDocP[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1870SMVLComFec ) != DateTimeUtil.ResetTime ( T004W2_A1870SMVLComFec[0] ) )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLComFec");
                  GXUtil.WriteLogRaw("Old: ",Z1870SMVLComFec);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1870SMVLComFec[0]);
               }
               if ( Z1877SMVLSubAfecto != T004W2_A1877SMVLSubAfecto[0] )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLSubAfecto");
                  GXUtil.WriteLogRaw("Old: ",Z1877SMVLSubAfecto);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1877SMVLSubAfecto[0]);
               }
               if ( Z1878SMVLSubInafecto != T004W2_A1878SMVLSubInafecto[0] )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLSubInafecto");
                  GXUtil.WriteLogRaw("Old: ",Z1878SMVLSubInafecto);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1878SMVLSubInafecto[0]);
               }
               if ( Z1875SMVLIGV != T004W2_A1875SMVLIGV[0] )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLIGV");
                  GXUtil.WriteLogRaw("Old: ",Z1875SMVLIGV);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1875SMVLIGV[0]);
               }
               if ( Z1879SMVLTotal != T004W2_A1879SMVLTotal[0] )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLTotal");
                  GXUtil.WriteLogRaw("Old: ",Z1879SMVLTotal);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1879SMVLTotal[0]);
               }
               if ( StringUtil.StrCmp(Z1876SMVLPrvCod, T004W2_A1876SMVLPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z1876SMVLPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1876SMVLPrvCod[0]);
               }
               if ( StringUtil.StrCmp(Z1874SMVLCueCod, T004W2_A1874SMVLCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z1874SMVLCueCod);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1874SMVLCueCod[0]);
               }
               if ( StringUtil.StrCmp(Z1872SMVLCosCod, T004W2_A1872SMVLCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z1872SMVLCosCod);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1872SMVLCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z1873SMVLCueAuxCod, T004W2_A1873SMVLCueAuxCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachicasubir:[seudo value changed for attri]"+"SMVLCueAuxCod");
                  GXUtil.WriteLogRaw("Old: ",Z1873SMVLCueAuxCod);
                  GXUtil.WriteLogRaw("Current: ",T004W2_A1873SMVLCueAuxCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSMOVCAJACHICASUBIR"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4W163( )
      {
         BeforeValidate4W163( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4W163( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4W163( 0) ;
            CheckOptimisticConcurrency4W163( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4W163( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4W163( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004W8 */
                     pr_default.execute(6, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem, A1868SMVLCajFec, A1865SMVLCajConc, A1866SMVLCajDoc, A1871SMVLConcCajCod, A1869SMVLCajTCod, A1867SMVLCajDocP, A1870SMVLComFec, A1877SMVLSubAfecto, A1878SMVLSubInafecto, A1875SMVLIGV, A1879SMVLTotal, A1876SMVLPrvCod, A1874SMVLCueCod, A1872SMVLCosCod, A1873SMVLCueAuxCod});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVCAJACHICASUBIR");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption4W0( ) ;
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
               Load4W163( ) ;
            }
            EndLevel4W163( ) ;
         }
         CloseExtendedTableCursors4W163( ) ;
      }

      protected void Update4W163( )
      {
         BeforeValidate4W163( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4W163( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4W163( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4W163( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4W163( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004W9 */
                     pr_default.execute(7, new Object[] {A1868SMVLCajFec, A1865SMVLCajConc, A1866SMVLCajDoc, A1871SMVLConcCajCod, A1869SMVLCajTCod, A1867SMVLCajDocP, A1870SMVLComFec, A1877SMVLSubAfecto, A1878SMVLSubInafecto, A1875SMVLIGV, A1879SMVLTotal, A1876SMVLPrvCod, A1874SMVLCueCod, A1872SMVLCosCod, A1873SMVLCueAuxCod, A400SCajCod, A401SMVLCajCod, A402SMVLITem});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVCAJACHICASUBIR");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVCAJACHICASUBIR"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4W163( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4W0( ) ;
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
            EndLevel4W163( ) ;
         }
         CloseExtendedTableCursors4W163( ) ;
      }

      protected void DeferredUpdate4W163( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4W163( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4W163( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4W163( ) ;
            AfterConfirm4W163( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4W163( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004W10 */
                  pr_default.execute(8, new Object[] {A400SCajCod, A401SMVLCajCod, A402SMVLITem});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TSMOVCAJACHICASUBIR");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound163 == 0 )
                        {
                           InitAll4W163( ) ;
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
                        ResetCaption4W0( ) ;
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
         sMode163 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4W163( ) ;
         Gx_mode = sMode163;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4W163( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel4W163( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4W163( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tsmovcajachicasubir",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tsmovcajachicasubir",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4W163( )
      {
         /* Using cursor T004W11 */
         pr_default.execute(9);
         RcdFound163 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound163 = 1;
            A400SCajCod = T004W11_A400SCajCod[0];
            AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
            A401SMVLCajCod = T004W11_A401SMVLCajCod[0];
            AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
            A402SMVLITem = T004W11_A402SMVLITem[0];
            AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4W163( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound163 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound163 = 1;
            A400SCajCod = T004W11_A400SCajCod[0];
            AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
            A401SMVLCajCod = T004W11_A401SMVLCajCod[0];
            AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
            A402SMVLITem = T004W11_A402SMVLITem[0];
            AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
         }
      }

      protected void ScanEnd4W163( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm4W163( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4W163( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4W163( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4W163( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4W163( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4W163( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4W163( )
      {
         edtSCajCod_Enabled = 0;
         AssignProp("", false, edtSCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSCajCod_Enabled), 5, 0), true);
         edtSMVLCajCod_Enabled = 0;
         AssignProp("", false, edtSMVLCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCajCod_Enabled), 5, 0), true);
         edtSMVLITem_Enabled = 0;
         AssignProp("", false, edtSMVLITem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLITem_Enabled), 5, 0), true);
         edtSMVLCajFec_Enabled = 0;
         AssignProp("", false, edtSMVLCajFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCajFec_Enabled), 5, 0), true);
         edtSMVLCajConc_Enabled = 0;
         AssignProp("", false, edtSMVLCajConc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCajConc_Enabled), 5, 0), true);
         edtSMVLCajDoc_Enabled = 0;
         AssignProp("", false, edtSMVLCajDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCajDoc_Enabled), 5, 0), true);
         edtSMVLConcCajCod_Enabled = 0;
         AssignProp("", false, edtSMVLConcCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLConcCajCod_Enabled), 5, 0), true);
         edtSMVLCajTCod_Enabled = 0;
         AssignProp("", false, edtSMVLCajTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCajTCod_Enabled), 5, 0), true);
         edtSMVLCajDocP_Enabled = 0;
         AssignProp("", false, edtSMVLCajDocP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCajDocP_Enabled), 5, 0), true);
         edtSMVLComFec_Enabled = 0;
         AssignProp("", false, edtSMVLComFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLComFec_Enabled), 5, 0), true);
         edtSMVLSubAfecto_Enabled = 0;
         AssignProp("", false, edtSMVLSubAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLSubAfecto_Enabled), 5, 0), true);
         edtSMVLSubInafecto_Enabled = 0;
         AssignProp("", false, edtSMVLSubInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLSubInafecto_Enabled), 5, 0), true);
         edtSMVLIGV_Enabled = 0;
         AssignProp("", false, edtSMVLIGV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLIGV_Enabled), 5, 0), true);
         edtSMVLTotal_Enabled = 0;
         AssignProp("", false, edtSMVLTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLTotal_Enabled), 5, 0), true);
         edtSMVLPrvCod_Enabled = 0;
         AssignProp("", false, edtSMVLPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLPrvCod_Enabled), 5, 0), true);
         edtSMVLCueCod_Enabled = 0;
         AssignProp("", false, edtSMVLCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCueCod_Enabled), 5, 0), true);
         edtSMVLCosCod_Enabled = 0;
         AssignProp("", false, edtSMVLCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCosCod_Enabled), 5, 0), true);
         edtSMVLCueAuxCod_Enabled = 0;
         AssignProp("", false, edtSMVLCueAuxCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSMVLCueAuxCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4W163( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4W0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254346", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tsmovcajachicasubir.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z400SCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z400SCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z401SMVLCajCod", StringUtil.RTrim( Z401SMVLCajCod));
         GxWebStd.gx_hidden_field( context, "Z402SMVLITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z402SMVLITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1868SMVLCajFec", context.localUtil.DToC( Z1868SMVLCajFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1865SMVLCajConc", StringUtil.RTrim( Z1865SMVLCajConc));
         GxWebStd.gx_hidden_field( context, "Z1866SMVLCajDoc", StringUtil.RTrim( Z1866SMVLCajDoc));
         GxWebStd.gx_hidden_field( context, "Z1871SMVLConcCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1871SMVLConcCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1869SMVLCajTCod", StringUtil.RTrim( Z1869SMVLCajTCod));
         GxWebStd.gx_hidden_field( context, "Z1867SMVLCajDocP", StringUtil.RTrim( Z1867SMVLCajDocP));
         GxWebStd.gx_hidden_field( context, "Z1870SMVLComFec", context.localUtil.DToC( Z1870SMVLComFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1877SMVLSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1877SMVLSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1878SMVLSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1878SMVLSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1875SMVLIGV", StringUtil.LTrim( StringUtil.NToC( Z1875SMVLIGV, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1879SMVLTotal", StringUtil.LTrim( StringUtil.NToC( Z1879SMVLTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1876SMVLPrvCod", StringUtil.RTrim( Z1876SMVLPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1874SMVLCueCod", StringUtil.RTrim( Z1874SMVLCueCod));
         GxWebStd.gx_hidden_field( context, "Z1872SMVLCosCod", StringUtil.RTrim( Z1872SMVLCosCod));
         GxWebStd.gx_hidden_field( context, "Z1873SMVLCueAuxCod", StringUtil.RTrim( Z1873SMVLCueAuxCod));
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
         return formatLink("tsmovcajachicasubir.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSMOVCAJACHICASUBIR" ;
      }

      public override string GetPgmdesc( )
      {
         return "TSMOVCAJACHICASUBIR" ;
      }

      protected void InitializeNonKey4W163( )
      {
         A1868SMVLCajFec = DateTime.MinValue;
         AssignAttri("", false, "A1868SMVLCajFec", context.localUtil.Format(A1868SMVLCajFec, "99/99/99"));
         A1865SMVLCajConc = "";
         AssignAttri("", false, "A1865SMVLCajConc", A1865SMVLCajConc);
         A1866SMVLCajDoc = "";
         AssignAttri("", false, "A1866SMVLCajDoc", A1866SMVLCajDoc);
         A1871SMVLConcCajCod = 0;
         AssignAttri("", false, "A1871SMVLConcCajCod", StringUtil.LTrimStr( (decimal)(A1871SMVLConcCajCod), 6, 0));
         A1869SMVLCajTCod = "";
         AssignAttri("", false, "A1869SMVLCajTCod", A1869SMVLCajTCod);
         A1867SMVLCajDocP = "";
         AssignAttri("", false, "A1867SMVLCajDocP", A1867SMVLCajDocP);
         A1870SMVLComFec = DateTime.MinValue;
         AssignAttri("", false, "A1870SMVLComFec", context.localUtil.Format(A1870SMVLComFec, "99/99/99"));
         A1877SMVLSubAfecto = 0;
         AssignAttri("", false, "A1877SMVLSubAfecto", StringUtil.LTrimStr( A1877SMVLSubAfecto, 15, 2));
         A1878SMVLSubInafecto = 0;
         AssignAttri("", false, "A1878SMVLSubInafecto", StringUtil.LTrimStr( A1878SMVLSubInafecto, 15, 2));
         A1875SMVLIGV = 0;
         AssignAttri("", false, "A1875SMVLIGV", StringUtil.LTrimStr( A1875SMVLIGV, 15, 2));
         A1879SMVLTotal = 0;
         AssignAttri("", false, "A1879SMVLTotal", StringUtil.LTrimStr( A1879SMVLTotal, 15, 2));
         A1876SMVLPrvCod = "";
         AssignAttri("", false, "A1876SMVLPrvCod", A1876SMVLPrvCod);
         A1874SMVLCueCod = "";
         AssignAttri("", false, "A1874SMVLCueCod", A1874SMVLCueCod);
         A1872SMVLCosCod = "";
         AssignAttri("", false, "A1872SMVLCosCod", A1872SMVLCosCod);
         A1873SMVLCueAuxCod = "";
         AssignAttri("", false, "A1873SMVLCueAuxCod", A1873SMVLCueAuxCod);
         Z1868SMVLCajFec = DateTime.MinValue;
         Z1865SMVLCajConc = "";
         Z1866SMVLCajDoc = "";
         Z1871SMVLConcCajCod = 0;
         Z1869SMVLCajTCod = "";
         Z1867SMVLCajDocP = "";
         Z1870SMVLComFec = DateTime.MinValue;
         Z1877SMVLSubAfecto = 0;
         Z1878SMVLSubInafecto = 0;
         Z1875SMVLIGV = 0;
         Z1879SMVLTotal = 0;
         Z1876SMVLPrvCod = "";
         Z1874SMVLCueCod = "";
         Z1872SMVLCosCod = "";
         Z1873SMVLCueAuxCod = "";
      }

      protected void InitAll4W163( )
      {
         A400SCajCod = 0;
         AssignAttri("", false, "A400SCajCod", StringUtil.LTrimStr( (decimal)(A400SCajCod), 6, 0));
         A401SMVLCajCod = "";
         AssignAttri("", false, "A401SMVLCajCod", A401SMVLCajCod);
         A402SMVLITem = 0;
         AssignAttri("", false, "A402SMVLITem", StringUtil.LTrimStr( (decimal)(A402SMVLITem), 6, 0));
         InitializeNonKey4W163( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254360", true, true);
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
         context.AddJavascriptSource("tsmovcajachicasubir.js", "?202281810254360", false, true);
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
         edtSCajCod_Internalname = "SCAJCOD";
         edtSMVLCajCod_Internalname = "SMVLCAJCOD";
         edtSMVLITem_Internalname = "SMVLITEM";
         edtSMVLCajFec_Internalname = "SMVLCAJFEC";
         edtSMVLCajConc_Internalname = "SMVLCAJCONC";
         edtSMVLCajDoc_Internalname = "SMVLCAJDOC";
         edtSMVLConcCajCod_Internalname = "SMVLCONCCAJCOD";
         edtSMVLCajTCod_Internalname = "SMVLCAJTCOD";
         edtSMVLCajDocP_Internalname = "SMVLCAJDOCP";
         edtSMVLComFec_Internalname = "SMVLCOMFEC";
         edtSMVLSubAfecto_Internalname = "SMVLSUBAFECTO";
         edtSMVLSubInafecto_Internalname = "SMVLSUBINAFECTO";
         edtSMVLIGV_Internalname = "SMVLIGV";
         edtSMVLTotal_Internalname = "SMVLTOTAL";
         edtSMVLPrvCod_Internalname = "SMVLPRVCOD";
         edtSMVLCueCod_Internalname = "SMVLCUECOD";
         edtSMVLCosCod_Internalname = "SMVLCOSCOD";
         edtSMVLCueAuxCod_Internalname = "SMVLCUEAUXCOD";
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
         Form.Caption = "TSMOVCAJACHICASUBIR";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSMVLCueAuxCod_Jsonclick = "";
         edtSMVLCueAuxCod_Enabled = 1;
         edtSMVLCosCod_Jsonclick = "";
         edtSMVLCosCod_Enabled = 1;
         edtSMVLCueCod_Jsonclick = "";
         edtSMVLCueCod_Enabled = 1;
         edtSMVLPrvCod_Jsonclick = "";
         edtSMVLPrvCod_Enabled = 1;
         edtSMVLTotal_Jsonclick = "";
         edtSMVLTotal_Enabled = 1;
         edtSMVLIGV_Jsonclick = "";
         edtSMVLIGV_Enabled = 1;
         edtSMVLSubInafecto_Jsonclick = "";
         edtSMVLSubInafecto_Enabled = 1;
         edtSMVLSubAfecto_Jsonclick = "";
         edtSMVLSubAfecto_Enabled = 1;
         edtSMVLComFec_Jsonclick = "";
         edtSMVLComFec_Enabled = 1;
         edtSMVLCajDocP_Jsonclick = "";
         edtSMVLCajDocP_Enabled = 1;
         edtSMVLCajTCod_Jsonclick = "";
         edtSMVLCajTCod_Enabled = 1;
         edtSMVLConcCajCod_Jsonclick = "";
         edtSMVLConcCajCod_Enabled = 1;
         edtSMVLCajDoc_Jsonclick = "";
         edtSMVLCajDoc_Enabled = 1;
         edtSMVLCajConc_Jsonclick = "";
         edtSMVLCajConc_Enabled = 1;
         edtSMVLCajFec_Jsonclick = "";
         edtSMVLCajFec_Enabled = 1;
         edtSMVLITem_Jsonclick = "";
         edtSMVLITem_Enabled = 1;
         edtSMVLCajCod_Jsonclick = "";
         edtSMVLCajCod_Enabled = 1;
         edtSCajCod_Jsonclick = "";
         edtSCajCod_Enabled = 1;
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
         GX_FocusControl = edtSMVLCajFec_Internalname;
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

      public void Valid_Smvlitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1868SMVLCajFec", context.localUtil.Format(A1868SMVLCajFec, "99/99/99"));
         AssignAttri("", false, "A1865SMVLCajConc", StringUtil.RTrim( A1865SMVLCajConc));
         AssignAttri("", false, "A1866SMVLCajDoc", StringUtil.RTrim( A1866SMVLCajDoc));
         AssignAttri("", false, "A1871SMVLConcCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1871SMVLConcCajCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1869SMVLCajTCod", StringUtil.RTrim( A1869SMVLCajTCod));
         AssignAttri("", false, "A1867SMVLCajDocP", StringUtil.RTrim( A1867SMVLCajDocP));
         AssignAttri("", false, "A1870SMVLComFec", context.localUtil.Format(A1870SMVLComFec, "99/99/99"));
         AssignAttri("", false, "A1877SMVLSubAfecto", StringUtil.LTrim( StringUtil.NToC( A1877SMVLSubAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1878SMVLSubInafecto", StringUtil.LTrim( StringUtil.NToC( A1878SMVLSubInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1875SMVLIGV", StringUtil.LTrim( StringUtil.NToC( A1875SMVLIGV, 15, 2, ".", "")));
         AssignAttri("", false, "A1879SMVLTotal", StringUtil.LTrim( StringUtil.NToC( A1879SMVLTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A1876SMVLPrvCod", StringUtil.RTrim( A1876SMVLPrvCod));
         AssignAttri("", false, "A1874SMVLCueCod", StringUtil.RTrim( A1874SMVLCueCod));
         AssignAttri("", false, "A1872SMVLCosCod", StringUtil.RTrim( A1872SMVLCosCod));
         AssignAttri("", false, "A1873SMVLCueAuxCod", StringUtil.RTrim( A1873SMVLCueAuxCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z400SCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z400SCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z401SMVLCajCod", StringUtil.RTrim( Z401SMVLCajCod));
         GxWebStd.gx_hidden_field( context, "Z402SMVLITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z402SMVLITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1868SMVLCajFec", context.localUtil.Format(Z1868SMVLCajFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1865SMVLCajConc", StringUtil.RTrim( Z1865SMVLCajConc));
         GxWebStd.gx_hidden_field( context, "Z1866SMVLCajDoc", StringUtil.RTrim( Z1866SMVLCajDoc));
         GxWebStd.gx_hidden_field( context, "Z1871SMVLConcCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1871SMVLConcCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1869SMVLCajTCod", StringUtil.RTrim( Z1869SMVLCajTCod));
         GxWebStd.gx_hidden_field( context, "Z1867SMVLCajDocP", StringUtil.RTrim( Z1867SMVLCajDocP));
         GxWebStd.gx_hidden_field( context, "Z1870SMVLComFec", context.localUtil.Format(Z1870SMVLComFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1877SMVLSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1877SMVLSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1878SMVLSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1878SMVLSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1875SMVLIGV", StringUtil.LTrim( StringUtil.NToC( Z1875SMVLIGV, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1879SMVLTotal", StringUtil.LTrim( StringUtil.NToC( Z1879SMVLTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1876SMVLPrvCod", StringUtil.RTrim( Z1876SMVLPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1874SMVLCueCod", StringUtil.RTrim( Z1874SMVLCueCod));
         GxWebStd.gx_hidden_field( context, "Z1872SMVLCosCod", StringUtil.RTrim( Z1872SMVLCosCod));
         GxWebStd.gx_hidden_field( context, "Z1873SMVLCueAuxCod", StringUtil.RTrim( Z1873SMVLCueAuxCod));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("VALID_SCAJCOD","{handler:'Valid_Scajcod',iparms:[]");
         setEventMetadata("VALID_SCAJCOD",",oparms:[]}");
         setEventMetadata("VALID_SMVLCAJCOD","{handler:'Valid_Smvlcajcod',iparms:[]");
         setEventMetadata("VALID_SMVLCAJCOD",",oparms:[]}");
         setEventMetadata("VALID_SMVLITEM","{handler:'Valid_Smvlitem',iparms:[{av:'A400SCajCod',fld:'SCAJCOD',pic:'ZZZZZ9'},{av:'A401SMVLCajCod',fld:'SMVLCAJCOD',pic:''},{av:'A402SMVLITem',fld:'SMVLITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SMVLITEM",",oparms:[{av:'A1868SMVLCajFec',fld:'SMVLCAJFEC',pic:''},{av:'A1865SMVLCajConc',fld:'SMVLCAJCONC',pic:''},{av:'A1866SMVLCajDoc',fld:'SMVLCAJDOC',pic:''},{av:'A1871SMVLConcCajCod',fld:'SMVLCONCCAJCOD',pic:'ZZZZZ9'},{av:'A1869SMVLCajTCod',fld:'SMVLCAJTCOD',pic:''},{av:'A1867SMVLCajDocP',fld:'SMVLCAJDOCP',pic:''},{av:'A1870SMVLComFec',fld:'SMVLCOMFEC',pic:''},{av:'A1877SMVLSubAfecto',fld:'SMVLSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1878SMVLSubInafecto',fld:'SMVLSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1875SMVLIGV',fld:'SMVLIGV',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1879SMVLTotal',fld:'SMVLTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1876SMVLPrvCod',fld:'SMVLPRVCOD',pic:''},{av:'A1874SMVLCueCod',fld:'SMVLCUECOD',pic:''},{av:'A1872SMVLCosCod',fld:'SMVLCOSCOD',pic:''},{av:'A1873SMVLCueAuxCod',fld:'SMVLCUEAUXCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z400SCajCod'},{av:'Z401SMVLCajCod'},{av:'Z402SMVLITem'},{av:'Z1868SMVLCajFec'},{av:'Z1865SMVLCajConc'},{av:'Z1866SMVLCajDoc'},{av:'Z1871SMVLConcCajCod'},{av:'Z1869SMVLCajTCod'},{av:'Z1867SMVLCajDocP'},{av:'Z1870SMVLComFec'},{av:'Z1877SMVLSubAfecto'},{av:'Z1878SMVLSubInafecto'},{av:'Z1875SMVLIGV'},{av:'Z1879SMVLTotal'},{av:'Z1876SMVLPrvCod'},{av:'Z1874SMVLCueCod'},{av:'Z1872SMVLCosCod'},{av:'Z1873SMVLCueAuxCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SMVLCAJFEC","{handler:'Valid_Smvlcajfec',iparms:[]");
         setEventMetadata("VALID_SMVLCAJFEC",",oparms:[]}");
         setEventMetadata("VALID_SMVLCOMFEC","{handler:'Valid_Smvlcomfec',iparms:[]");
         setEventMetadata("VALID_SMVLCOMFEC",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z401SMVLCajCod = "";
         Z1868SMVLCajFec = DateTime.MinValue;
         Z1865SMVLCajConc = "";
         Z1866SMVLCajDoc = "";
         Z1869SMVLCajTCod = "";
         Z1867SMVLCajDocP = "";
         Z1870SMVLComFec = DateTime.MinValue;
         Z1876SMVLPrvCod = "";
         Z1874SMVLCueCod = "";
         Z1872SMVLCosCod = "";
         Z1873SMVLCueAuxCod = "";
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
         A401SMVLCajCod = "";
         A1868SMVLCajFec = DateTime.MinValue;
         A1865SMVLCajConc = "";
         A1866SMVLCajDoc = "";
         A1869SMVLCajTCod = "";
         A1867SMVLCajDocP = "";
         A1870SMVLComFec = DateTime.MinValue;
         A1876SMVLPrvCod = "";
         A1874SMVLCueCod = "";
         A1872SMVLCosCod = "";
         A1873SMVLCueAuxCod = "";
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
         T004W4_A400SCajCod = new int[1] ;
         T004W4_A401SMVLCajCod = new string[] {""} ;
         T004W4_A402SMVLITem = new int[1] ;
         T004W4_A1868SMVLCajFec = new DateTime[] {DateTime.MinValue} ;
         T004W4_A1865SMVLCajConc = new string[] {""} ;
         T004W4_A1866SMVLCajDoc = new string[] {""} ;
         T004W4_A1871SMVLConcCajCod = new int[1] ;
         T004W4_A1869SMVLCajTCod = new string[] {""} ;
         T004W4_A1867SMVLCajDocP = new string[] {""} ;
         T004W4_A1870SMVLComFec = new DateTime[] {DateTime.MinValue} ;
         T004W4_A1877SMVLSubAfecto = new decimal[1] ;
         T004W4_A1878SMVLSubInafecto = new decimal[1] ;
         T004W4_A1875SMVLIGV = new decimal[1] ;
         T004W4_A1879SMVLTotal = new decimal[1] ;
         T004W4_A1876SMVLPrvCod = new string[] {""} ;
         T004W4_A1874SMVLCueCod = new string[] {""} ;
         T004W4_A1872SMVLCosCod = new string[] {""} ;
         T004W4_A1873SMVLCueAuxCod = new string[] {""} ;
         T004W5_A400SCajCod = new int[1] ;
         T004W5_A401SMVLCajCod = new string[] {""} ;
         T004W5_A402SMVLITem = new int[1] ;
         T004W3_A400SCajCod = new int[1] ;
         T004W3_A401SMVLCajCod = new string[] {""} ;
         T004W3_A402SMVLITem = new int[1] ;
         T004W3_A1868SMVLCajFec = new DateTime[] {DateTime.MinValue} ;
         T004W3_A1865SMVLCajConc = new string[] {""} ;
         T004W3_A1866SMVLCajDoc = new string[] {""} ;
         T004W3_A1871SMVLConcCajCod = new int[1] ;
         T004W3_A1869SMVLCajTCod = new string[] {""} ;
         T004W3_A1867SMVLCajDocP = new string[] {""} ;
         T004W3_A1870SMVLComFec = new DateTime[] {DateTime.MinValue} ;
         T004W3_A1877SMVLSubAfecto = new decimal[1] ;
         T004W3_A1878SMVLSubInafecto = new decimal[1] ;
         T004W3_A1875SMVLIGV = new decimal[1] ;
         T004W3_A1879SMVLTotal = new decimal[1] ;
         T004W3_A1876SMVLPrvCod = new string[] {""} ;
         T004W3_A1874SMVLCueCod = new string[] {""} ;
         T004W3_A1872SMVLCosCod = new string[] {""} ;
         T004W3_A1873SMVLCueAuxCod = new string[] {""} ;
         sMode163 = "";
         T004W6_A400SCajCod = new int[1] ;
         T004W6_A401SMVLCajCod = new string[] {""} ;
         T004W6_A402SMVLITem = new int[1] ;
         T004W7_A400SCajCod = new int[1] ;
         T004W7_A401SMVLCajCod = new string[] {""} ;
         T004W7_A402SMVLITem = new int[1] ;
         T004W2_A400SCajCod = new int[1] ;
         T004W2_A401SMVLCajCod = new string[] {""} ;
         T004W2_A402SMVLITem = new int[1] ;
         T004W2_A1868SMVLCajFec = new DateTime[] {DateTime.MinValue} ;
         T004W2_A1865SMVLCajConc = new string[] {""} ;
         T004W2_A1866SMVLCajDoc = new string[] {""} ;
         T004W2_A1871SMVLConcCajCod = new int[1] ;
         T004W2_A1869SMVLCajTCod = new string[] {""} ;
         T004W2_A1867SMVLCajDocP = new string[] {""} ;
         T004W2_A1870SMVLComFec = new DateTime[] {DateTime.MinValue} ;
         T004W2_A1877SMVLSubAfecto = new decimal[1] ;
         T004W2_A1878SMVLSubInafecto = new decimal[1] ;
         T004W2_A1875SMVLIGV = new decimal[1] ;
         T004W2_A1879SMVLTotal = new decimal[1] ;
         T004W2_A1876SMVLPrvCod = new string[] {""} ;
         T004W2_A1874SMVLCueCod = new string[] {""} ;
         T004W2_A1872SMVLCosCod = new string[] {""} ;
         T004W2_A1873SMVLCueAuxCod = new string[] {""} ;
         T004W11_A400SCajCod = new int[1] ;
         T004W11_A401SMVLCajCod = new string[] {""} ;
         T004W11_A402SMVLITem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ401SMVLCajCod = "";
         ZZ1868SMVLCajFec = DateTime.MinValue;
         ZZ1865SMVLCajConc = "";
         ZZ1866SMVLCajDoc = "";
         ZZ1869SMVLCajTCod = "";
         ZZ1867SMVLCajDocP = "";
         ZZ1870SMVLComFec = DateTime.MinValue;
         ZZ1876SMVLPrvCod = "";
         ZZ1874SMVLCueCod = "";
         ZZ1872SMVLCosCod = "";
         ZZ1873SMVLCueAuxCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsmovcajachicasubir__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsmovcajachicasubir__default(),
            new Object[][] {
                new Object[] {
               T004W2_A400SCajCod, T004W2_A401SMVLCajCod, T004W2_A402SMVLITem, T004W2_A1868SMVLCajFec, T004W2_A1865SMVLCajConc, T004W2_A1866SMVLCajDoc, T004W2_A1871SMVLConcCajCod, T004W2_A1869SMVLCajTCod, T004W2_A1867SMVLCajDocP, T004W2_A1870SMVLComFec,
               T004W2_A1877SMVLSubAfecto, T004W2_A1878SMVLSubInafecto, T004W2_A1875SMVLIGV, T004W2_A1879SMVLTotal, T004W2_A1876SMVLPrvCod, T004W2_A1874SMVLCueCod, T004W2_A1872SMVLCosCod, T004W2_A1873SMVLCueAuxCod
               }
               , new Object[] {
               T004W3_A400SCajCod, T004W3_A401SMVLCajCod, T004W3_A402SMVLITem, T004W3_A1868SMVLCajFec, T004W3_A1865SMVLCajConc, T004W3_A1866SMVLCajDoc, T004W3_A1871SMVLConcCajCod, T004W3_A1869SMVLCajTCod, T004W3_A1867SMVLCajDocP, T004W3_A1870SMVLComFec,
               T004W3_A1877SMVLSubAfecto, T004W3_A1878SMVLSubInafecto, T004W3_A1875SMVLIGV, T004W3_A1879SMVLTotal, T004W3_A1876SMVLPrvCod, T004W3_A1874SMVLCueCod, T004W3_A1872SMVLCosCod, T004W3_A1873SMVLCueAuxCod
               }
               , new Object[] {
               T004W4_A400SCajCod, T004W4_A401SMVLCajCod, T004W4_A402SMVLITem, T004W4_A1868SMVLCajFec, T004W4_A1865SMVLCajConc, T004W4_A1866SMVLCajDoc, T004W4_A1871SMVLConcCajCod, T004W4_A1869SMVLCajTCod, T004W4_A1867SMVLCajDocP, T004W4_A1870SMVLComFec,
               T004W4_A1877SMVLSubAfecto, T004W4_A1878SMVLSubInafecto, T004W4_A1875SMVLIGV, T004W4_A1879SMVLTotal, T004W4_A1876SMVLPrvCod, T004W4_A1874SMVLCueCod, T004W4_A1872SMVLCosCod, T004W4_A1873SMVLCueAuxCod
               }
               , new Object[] {
               T004W5_A400SCajCod, T004W5_A401SMVLCajCod, T004W5_A402SMVLITem
               }
               , new Object[] {
               T004W6_A400SCajCod, T004W6_A401SMVLCajCod, T004W6_A402SMVLITem
               }
               , new Object[] {
               T004W7_A400SCajCod, T004W7_A401SMVLCajCod, T004W7_A402SMVLITem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004W11_A400SCajCod, T004W11_A401SMVLCajCod, T004W11_A402SMVLITem
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
      private short RcdFound163 ;
      private short nIsDirty_163 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z400SCajCod ;
      private int Z402SMVLITem ;
      private int Z1871SMVLConcCajCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A400SCajCod ;
      private int edtSCajCod_Enabled ;
      private int edtSMVLCajCod_Enabled ;
      private int A402SMVLITem ;
      private int edtSMVLITem_Enabled ;
      private int edtSMVLCajFec_Enabled ;
      private int edtSMVLCajConc_Enabled ;
      private int edtSMVLCajDoc_Enabled ;
      private int A1871SMVLConcCajCod ;
      private int edtSMVLConcCajCod_Enabled ;
      private int edtSMVLCajTCod_Enabled ;
      private int edtSMVLCajDocP_Enabled ;
      private int edtSMVLComFec_Enabled ;
      private int edtSMVLSubAfecto_Enabled ;
      private int edtSMVLSubInafecto_Enabled ;
      private int edtSMVLIGV_Enabled ;
      private int edtSMVLTotal_Enabled ;
      private int edtSMVLPrvCod_Enabled ;
      private int edtSMVLCueCod_Enabled ;
      private int edtSMVLCosCod_Enabled ;
      private int edtSMVLCueAuxCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ400SCajCod ;
      private int ZZ402SMVLITem ;
      private int ZZ1871SMVLConcCajCod ;
      private decimal Z1877SMVLSubAfecto ;
      private decimal Z1878SMVLSubInafecto ;
      private decimal Z1875SMVLIGV ;
      private decimal Z1879SMVLTotal ;
      private decimal A1877SMVLSubAfecto ;
      private decimal A1878SMVLSubInafecto ;
      private decimal A1875SMVLIGV ;
      private decimal A1879SMVLTotal ;
      private decimal ZZ1877SMVLSubAfecto ;
      private decimal ZZ1878SMVLSubInafecto ;
      private decimal ZZ1875SMVLIGV ;
      private decimal ZZ1879SMVLTotal ;
      private string sPrefix ;
      private string Z401SMVLCajCod ;
      private string Z1865SMVLCajConc ;
      private string Z1866SMVLCajDoc ;
      private string Z1869SMVLCajTCod ;
      private string Z1867SMVLCajDocP ;
      private string Z1876SMVLPrvCod ;
      private string Z1874SMVLCueCod ;
      private string Z1872SMVLCosCod ;
      private string Z1873SMVLCueAuxCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSCajCod_Internalname ;
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
      private string edtSCajCod_Jsonclick ;
      private string edtSMVLCajCod_Internalname ;
      private string A401SMVLCajCod ;
      private string edtSMVLCajCod_Jsonclick ;
      private string edtSMVLITem_Internalname ;
      private string edtSMVLITem_Jsonclick ;
      private string edtSMVLCajFec_Internalname ;
      private string edtSMVLCajFec_Jsonclick ;
      private string edtSMVLCajConc_Internalname ;
      private string A1865SMVLCajConc ;
      private string edtSMVLCajConc_Jsonclick ;
      private string edtSMVLCajDoc_Internalname ;
      private string A1866SMVLCajDoc ;
      private string edtSMVLCajDoc_Jsonclick ;
      private string edtSMVLConcCajCod_Internalname ;
      private string edtSMVLConcCajCod_Jsonclick ;
      private string edtSMVLCajTCod_Internalname ;
      private string A1869SMVLCajTCod ;
      private string edtSMVLCajTCod_Jsonclick ;
      private string edtSMVLCajDocP_Internalname ;
      private string A1867SMVLCajDocP ;
      private string edtSMVLCajDocP_Jsonclick ;
      private string edtSMVLComFec_Internalname ;
      private string edtSMVLComFec_Jsonclick ;
      private string edtSMVLSubAfecto_Internalname ;
      private string edtSMVLSubAfecto_Jsonclick ;
      private string edtSMVLSubInafecto_Internalname ;
      private string edtSMVLSubInafecto_Jsonclick ;
      private string edtSMVLIGV_Internalname ;
      private string edtSMVLIGV_Jsonclick ;
      private string edtSMVLTotal_Internalname ;
      private string edtSMVLTotal_Jsonclick ;
      private string edtSMVLPrvCod_Internalname ;
      private string A1876SMVLPrvCod ;
      private string edtSMVLPrvCod_Jsonclick ;
      private string edtSMVLCueCod_Internalname ;
      private string A1874SMVLCueCod ;
      private string edtSMVLCueCod_Jsonclick ;
      private string edtSMVLCosCod_Internalname ;
      private string A1872SMVLCosCod ;
      private string edtSMVLCosCod_Jsonclick ;
      private string edtSMVLCueAuxCod_Internalname ;
      private string A1873SMVLCueAuxCod ;
      private string edtSMVLCueAuxCod_Jsonclick ;
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
      private string sMode163 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ401SMVLCajCod ;
      private string ZZ1865SMVLCajConc ;
      private string ZZ1866SMVLCajDoc ;
      private string ZZ1869SMVLCajTCod ;
      private string ZZ1867SMVLCajDocP ;
      private string ZZ1876SMVLPrvCod ;
      private string ZZ1874SMVLCueCod ;
      private string ZZ1872SMVLCosCod ;
      private string ZZ1873SMVLCueAuxCod ;
      private DateTime Z1868SMVLCajFec ;
      private DateTime Z1870SMVLComFec ;
      private DateTime A1868SMVLCajFec ;
      private DateTime A1870SMVLComFec ;
      private DateTime ZZ1868SMVLCajFec ;
      private DateTime ZZ1870SMVLComFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T004W4_A400SCajCod ;
      private string[] T004W4_A401SMVLCajCod ;
      private int[] T004W4_A402SMVLITem ;
      private DateTime[] T004W4_A1868SMVLCajFec ;
      private string[] T004W4_A1865SMVLCajConc ;
      private string[] T004W4_A1866SMVLCajDoc ;
      private int[] T004W4_A1871SMVLConcCajCod ;
      private string[] T004W4_A1869SMVLCajTCod ;
      private string[] T004W4_A1867SMVLCajDocP ;
      private DateTime[] T004W4_A1870SMVLComFec ;
      private decimal[] T004W4_A1877SMVLSubAfecto ;
      private decimal[] T004W4_A1878SMVLSubInafecto ;
      private decimal[] T004W4_A1875SMVLIGV ;
      private decimal[] T004W4_A1879SMVLTotal ;
      private string[] T004W4_A1876SMVLPrvCod ;
      private string[] T004W4_A1874SMVLCueCod ;
      private string[] T004W4_A1872SMVLCosCod ;
      private string[] T004W4_A1873SMVLCueAuxCod ;
      private int[] T004W5_A400SCajCod ;
      private string[] T004W5_A401SMVLCajCod ;
      private int[] T004W5_A402SMVLITem ;
      private int[] T004W3_A400SCajCod ;
      private string[] T004W3_A401SMVLCajCod ;
      private int[] T004W3_A402SMVLITem ;
      private DateTime[] T004W3_A1868SMVLCajFec ;
      private string[] T004W3_A1865SMVLCajConc ;
      private string[] T004W3_A1866SMVLCajDoc ;
      private int[] T004W3_A1871SMVLConcCajCod ;
      private string[] T004W3_A1869SMVLCajTCod ;
      private string[] T004W3_A1867SMVLCajDocP ;
      private DateTime[] T004W3_A1870SMVLComFec ;
      private decimal[] T004W3_A1877SMVLSubAfecto ;
      private decimal[] T004W3_A1878SMVLSubInafecto ;
      private decimal[] T004W3_A1875SMVLIGV ;
      private decimal[] T004W3_A1879SMVLTotal ;
      private string[] T004W3_A1876SMVLPrvCod ;
      private string[] T004W3_A1874SMVLCueCod ;
      private string[] T004W3_A1872SMVLCosCod ;
      private string[] T004W3_A1873SMVLCueAuxCod ;
      private int[] T004W6_A400SCajCod ;
      private string[] T004W6_A401SMVLCajCod ;
      private int[] T004W6_A402SMVLITem ;
      private int[] T004W7_A400SCajCod ;
      private string[] T004W7_A401SMVLCajCod ;
      private int[] T004W7_A402SMVLITem ;
      private int[] T004W2_A400SCajCod ;
      private string[] T004W2_A401SMVLCajCod ;
      private int[] T004W2_A402SMVLITem ;
      private DateTime[] T004W2_A1868SMVLCajFec ;
      private string[] T004W2_A1865SMVLCajConc ;
      private string[] T004W2_A1866SMVLCajDoc ;
      private int[] T004W2_A1871SMVLConcCajCod ;
      private string[] T004W2_A1869SMVLCajTCod ;
      private string[] T004W2_A1867SMVLCajDocP ;
      private DateTime[] T004W2_A1870SMVLComFec ;
      private decimal[] T004W2_A1877SMVLSubAfecto ;
      private decimal[] T004W2_A1878SMVLSubInafecto ;
      private decimal[] T004W2_A1875SMVLIGV ;
      private decimal[] T004W2_A1879SMVLTotal ;
      private string[] T004W2_A1876SMVLPrvCod ;
      private string[] T004W2_A1874SMVLCueCod ;
      private string[] T004W2_A1872SMVLCosCod ;
      private string[] T004W2_A1873SMVLCueAuxCod ;
      private int[] T004W11_A400SCajCod ;
      private string[] T004W11_A401SMVLCajCod ;
      private int[] T004W11_A402SMVLITem ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsmovcajachicasubir__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsmovcajachicasubir__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004W4;
        prmT004W4 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W5;
        prmT004W5 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W3;
        prmT004W3 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W6;
        prmT004W6 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W7;
        prmT004W7 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W2;
        prmT004W2 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W8;
        prmT004W8 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajFec",GXType.Date,8,0) ,
        new ParDef("@SMVLCajConc",GXType.NChar,100,0) ,
        new ParDef("@SMVLCajDoc",GXType.NChar,20,0) ,
        new ParDef("@SMVLConcCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajTCod",GXType.NChar,3,0) ,
        new ParDef("@SMVLCajDocP",GXType.NChar,20,0) ,
        new ParDef("@SMVLComFec",GXType.Date,8,0) ,
        new ParDef("@SMVLSubAfecto",GXType.Decimal,15,2) ,
        new ParDef("@SMVLSubInafecto",GXType.Decimal,15,2) ,
        new ParDef("@SMVLIGV",GXType.Decimal,15,2) ,
        new ParDef("@SMVLTotal",GXType.Decimal,15,2) ,
        new ParDef("@SMVLPrvCod",GXType.NChar,20,0) ,
        new ParDef("@SMVLCueCod",GXType.NChar,15,0) ,
        new ParDef("@SMVLCosCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLCueAuxCod",GXType.NChar,15,0)
        };
        Object[] prmT004W9;
        prmT004W9 = new Object[] {
        new ParDef("@SMVLCajFec",GXType.Date,8,0) ,
        new ParDef("@SMVLCajConc",GXType.NChar,100,0) ,
        new ParDef("@SMVLCajDoc",GXType.NChar,20,0) ,
        new ParDef("@SMVLConcCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajTCod",GXType.NChar,3,0) ,
        new ParDef("@SMVLCajDocP",GXType.NChar,20,0) ,
        new ParDef("@SMVLComFec",GXType.Date,8,0) ,
        new ParDef("@SMVLSubAfecto",GXType.Decimal,15,2) ,
        new ParDef("@SMVLSubInafecto",GXType.Decimal,15,2) ,
        new ParDef("@SMVLIGV",GXType.Decimal,15,2) ,
        new ParDef("@SMVLTotal",GXType.Decimal,15,2) ,
        new ParDef("@SMVLPrvCod",GXType.NChar,20,0) ,
        new ParDef("@SMVLCueCod",GXType.NChar,15,0) ,
        new ParDef("@SMVLCosCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLCueAuxCod",GXType.NChar,15,0) ,
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W10;
        prmT004W10 = new Object[] {
        new ParDef("@SCajCod",GXType.Int32,6,0) ,
        new ParDef("@SMVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@SMVLITem",GXType.Int32,6,0)
        };
        Object[] prmT004W11;
        prmT004W11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T004W2", "SELECT [SCajCod], [SMVLCajCod], [SMVLITem], [SMVLCajFec], [SMVLCajConc], [SMVLCajDoc], [SMVLConcCajCod], [SMVLCajTCod], [SMVLCajDocP], [SMVLComFec], [SMVLSubAfecto], [SMVLSubInafecto], [SMVLIGV], [SMVLTotal], [SMVLPrvCod], [SMVLCueCod], [SMVLCosCod], [SMVLCueAuxCod] FROM [TSMOVCAJACHICASUBIR] WITH (UPDLOCK) WHERE [SCajCod] = @SCajCod AND [SMVLCajCod] = @SMVLCajCod AND [SMVLITem] = @SMVLITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT004W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004W3", "SELECT [SCajCod], [SMVLCajCod], [SMVLITem], [SMVLCajFec], [SMVLCajConc], [SMVLCajDoc], [SMVLConcCajCod], [SMVLCajTCod], [SMVLCajDocP], [SMVLComFec], [SMVLSubAfecto], [SMVLSubInafecto], [SMVLIGV], [SMVLTotal], [SMVLPrvCod], [SMVLCueCod], [SMVLCosCod], [SMVLCueAuxCod] FROM [TSMOVCAJACHICASUBIR] WHERE [SCajCod] = @SCajCod AND [SMVLCajCod] = @SMVLCajCod AND [SMVLITem] = @SMVLITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT004W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004W4", "SELECT TM1.[SCajCod], TM1.[SMVLCajCod], TM1.[SMVLITem], TM1.[SMVLCajFec], TM1.[SMVLCajConc], TM1.[SMVLCajDoc], TM1.[SMVLConcCajCod], TM1.[SMVLCajTCod], TM1.[SMVLCajDocP], TM1.[SMVLComFec], TM1.[SMVLSubAfecto], TM1.[SMVLSubInafecto], TM1.[SMVLIGV], TM1.[SMVLTotal], TM1.[SMVLPrvCod], TM1.[SMVLCueCod], TM1.[SMVLCosCod], TM1.[SMVLCueAuxCod] FROM [TSMOVCAJACHICASUBIR] TM1 WHERE TM1.[SCajCod] = @SCajCod and TM1.[SMVLCajCod] = @SMVLCajCod and TM1.[SMVLITem] = @SMVLITem ORDER BY TM1.[SCajCod], TM1.[SMVLCajCod], TM1.[SMVLITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004W4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004W5", "SELECT [SCajCod], [SMVLCajCod], [SMVLITem] FROM [TSMOVCAJACHICASUBIR] WHERE [SCajCod] = @SCajCod AND [SMVLCajCod] = @SMVLCajCod AND [SMVLITem] = @SMVLITem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004W6", "SELECT TOP 1 [SCajCod], [SMVLCajCod], [SMVLITem] FROM [TSMOVCAJACHICASUBIR] WHERE ( [SCajCod] > @SCajCod or [SCajCod] = @SCajCod and [SMVLCajCod] > @SMVLCajCod or [SMVLCajCod] = @SMVLCajCod and [SCajCod] = @SCajCod and [SMVLITem] > @SMVLITem) ORDER BY [SCajCod], [SMVLCajCod], [SMVLITem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004W6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004W7", "SELECT TOP 1 [SCajCod], [SMVLCajCod], [SMVLITem] FROM [TSMOVCAJACHICASUBIR] WHERE ( [SCajCod] < @SCajCod or [SCajCod] = @SCajCod and [SMVLCajCod] < @SMVLCajCod or [SMVLCajCod] = @SMVLCajCod and [SCajCod] = @SCajCod and [SMVLITem] < @SMVLITem) ORDER BY [SCajCod] DESC, [SMVLCajCod] DESC, [SMVLITem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004W7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004W8", "INSERT INTO [TSMOVCAJACHICASUBIR]([SCajCod], [SMVLCajCod], [SMVLITem], [SMVLCajFec], [SMVLCajConc], [SMVLCajDoc], [SMVLConcCajCod], [SMVLCajTCod], [SMVLCajDocP], [SMVLComFec], [SMVLSubAfecto], [SMVLSubInafecto], [SMVLIGV], [SMVLTotal], [SMVLPrvCod], [SMVLCueCod], [SMVLCosCod], [SMVLCueAuxCod]) VALUES(@SCajCod, @SMVLCajCod, @SMVLITem, @SMVLCajFec, @SMVLCajConc, @SMVLCajDoc, @SMVLConcCajCod, @SMVLCajTCod, @SMVLCajDocP, @SMVLComFec, @SMVLSubAfecto, @SMVLSubInafecto, @SMVLIGV, @SMVLTotal, @SMVLPrvCod, @SMVLCueCod, @SMVLCosCod, @SMVLCueAuxCod)", GxErrorMask.GX_NOMASK,prmT004W8)
           ,new CursorDef("T004W9", "UPDATE [TSMOVCAJACHICASUBIR] SET [SMVLCajFec]=@SMVLCajFec, [SMVLCajConc]=@SMVLCajConc, [SMVLCajDoc]=@SMVLCajDoc, [SMVLConcCajCod]=@SMVLConcCajCod, [SMVLCajTCod]=@SMVLCajTCod, [SMVLCajDocP]=@SMVLCajDocP, [SMVLComFec]=@SMVLComFec, [SMVLSubAfecto]=@SMVLSubAfecto, [SMVLSubInafecto]=@SMVLSubInafecto, [SMVLIGV]=@SMVLIGV, [SMVLTotal]=@SMVLTotal, [SMVLPrvCod]=@SMVLPrvCod, [SMVLCueCod]=@SMVLCueCod, [SMVLCosCod]=@SMVLCosCod, [SMVLCueAuxCod]=@SMVLCueAuxCod  WHERE [SCajCod] = @SCajCod AND [SMVLCajCod] = @SMVLCajCod AND [SMVLITem] = @SMVLITem", GxErrorMask.GX_NOMASK,prmT004W9)
           ,new CursorDef("T004W10", "DELETE FROM [TSMOVCAJACHICASUBIR]  WHERE [SCajCod] = @SCajCod AND [SMVLCajCod] = @SMVLCajCod AND [SMVLITem] = @SMVLITem", GxErrorMask.GX_NOMASK,prmT004W10)
           ,new CursorDef("T004W11", "SELECT [SCajCod], [SMVLCajCod], [SMVLITem] FROM [TSMOVCAJACHICASUBIR] ORDER BY [SCajCod], [SMVLCajCod], [SMVLITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004W11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
     }
  }

}

}
