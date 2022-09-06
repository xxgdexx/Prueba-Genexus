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
   public class clcotiza : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A177CotCod = GetPar( "CotCod");
            AssignAttri("", false, "A177CotCod", A177CotCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A177CotCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A45CliCod = GetPar( "CliCod");
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A45CliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A180MonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A182CotConpCod = (int)(NumberUtil.Val( GetPar( "CotConpCod"), "."));
            AssignAttri("", false, "A182CotConpCod", StringUtil.LTrimStr( (decimal)(A182CotConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A182CotConpCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A181CotLista = (int)(NumberUtil.Val( GetPar( "CotLista"), "."));
            n181CotLista = false;
            AssignAttri("", false, "A181CotLista", StringUtil.LTrimStr( (decimal)(A181CotLista), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A181CotLista) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A179CotVendCod = (int)(NumberUtil.Val( GetPar( "CotVendCod"), "."));
            AssignAttri("", false, "A179CotVendCod", StringUtil.LTrimStr( (decimal)(A179CotVendCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A179CotVendCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A178TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A178TieCod) ;
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
            Form.Meta.addItem("description", "CLCOTIZA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clcotiza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clcotiza( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CLCOTIZA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCOTIZA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotCod_Internalname, "N° Cotización", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotCod_Internalname, StringUtil.RTrim( A177CotCod), StringUtil.RTrim( context.localUtil.Format( A177CotCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCotFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCotFec_Internalname, context.localUtil.Format(A796CotFec, "99/99/99"), context.localUtil.Format( A796CotFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_bitmap( context, edtCotFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCotFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOTIZA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCod_Internalname, "Codigo Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonCod_Internalname, "Codigo Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotConpCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotConpCod_Internalname, "Condicion de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A182CotConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCotConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A182CotConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A182CotConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotLista_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotLista_Internalname, "Lista de Precios", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotLista_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A181CotLista), 6, 0, ".", "")), StringUtil.LTrim( ((edtCotLista_Enabled!=0) ? context.localUtil.Format( (decimal)(A181CotLista), "ZZZZZ9") : context.localUtil.Format( (decimal)(A181CotLista), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotLista_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotLista_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotRef_Internalname, "Referencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotRef_Internalname, A806CotRef, StringUtil.RTrim( context.localUtil.Format( A806CotRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotRef_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotPorDsct_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotPorDsct_Internalname, "% Dscto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotPorDsct_Internalname, StringUtil.LTrim( StringUtil.NToC( A794CotPorDsct, 6, 2, ".", "")), StringUtil.LTrim( ((edtCotPorDsct_Enabled!=0) ? context.localUtil.Format( A794CotPorDsct, "ZZ9.99") : context.localUtil.Format( A794CotPorDsct, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotPorDsct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotPorDsct_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotPorIVA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotPorIVA_Internalname, "% I.G.V.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotPorIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A802CotPorIVA, 6, 2, ".", "")), StringUtil.LTrim( ((edtCotPorIVA_Enabled!=0) ? context.localUtil.Format( A802CotPorIVA, "ZZ9.99") : context.localUtil.Format( A802CotPorIVA, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotPorIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotPorIVA_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotObs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotObs_Internalname, "Observaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCotObs_Internalname, A804CotObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", 0, 1, edtCotObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotTItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotTItem_Internalname, "Total Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A810CotTItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtCotTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A810CotTItem), "ZZZ9") : context.localUtil.Format( (decimal)(A810CotTItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotTItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotSts_Internalname, StringUtil.RTrim( A807CotSts), StringUtil.RTrim( context.localUtil.Format( A807CotSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotVendCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotVendCod_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotVendCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A179CotVendCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCotVendCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A179CotVendCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A179CotVendCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotVendCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotVendCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotUsuC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotUsuC_Internalname, "Usuario C", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotUsuC_Internalname, A812CotUsuC, StringUtil.RTrim( context.localUtil.Format( A812CotUsuC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotFecC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotFecC_Internalname, "Fecha Creación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCotFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCotFecC_Internalname, context.localUtil.TToC( A798CotFecC, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A798CotFecC, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotFecC_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_bitmap( context, edtCotFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCotFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOTIZA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotUsuM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotUsuM_Internalname, "Usuario M", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotUsuM_Internalname, A813CotUsuM, StringUtil.RTrim( context.localUtil.Format( A813CotUsuM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotFecM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotFecM_Internalname, "Fecha Modificación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCotFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCotFecM_Internalname, context.localUtil.TToC( A799CotFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A799CotFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_bitmap( context, edtCotFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCotFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOTIZA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotPedCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotPedCod_Internalname, "N° Pedido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotPedCod_Internalname, StringUtil.RTrim( A805CotPedCod), StringUtil.RTrim( context.localUtil.Format( A805CotPedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotCliDespacho_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotCliDespacho_Internalname, "Cliente Despacho", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotCliDespacho_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A764CotCliDespacho), 6, 0, ".", "")), StringUtil.LTrim( ((edtCotCliDespacho_Enabled!=0) ? context.localUtil.Format( (decimal)(A764CotCliDespacho), "ZZZZZ9") : context.localUtil.Format( (decimal)(A764CotCliDespacho), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotCliDespacho_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotCliDespacho_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotImp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotImp_Internalname, "Tipo Impresión", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotImp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A800CotImp), 1, 0, ".", "")), StringUtil.LTrim( ((edtCotImp_Enabled!=0) ? context.localUtil.Format( (decimal)(A800CotImp), "9") : context.localUtil.Format( (decimal)(A800CotImp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotImp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotAIVA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotAIVA_Internalname, "IGV", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotAIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A763CotAIVA), 1, 0, ".", "")), StringUtil.LTrim( ((edtCotAIVA_Enabled!=0) ? context.localUtil.Format( (decimal)(A763CotAIVA), "9") : context.localUtil.Format( (decimal)(A763CotAIVA), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotAIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotAIVA_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotIVA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotIVA_Internalname, "I.G.V.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A801CotIVA, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotIVA_Enabled!=0) ? context.localUtil.Format( A801CotIVA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A801CotIVA, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotIVA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotRedondeo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotRedondeo_Internalname, "Redondeo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotRedondeo_Internalname, StringUtil.LTrim( StringUtil.NToC( A803CotRedondeo, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotRedondeo_Enabled!=0) ? context.localUtil.Format( A803CotRedondeo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A803CotRedondeo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotRedondeo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotRedondeo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotTotal_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A811CotTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotTotal_Enabled!=0) ? context.localUtil.Format( A811CotTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A811CotTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubAfecto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubAfecto_Internalname, "Afecto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A788CotSubAfecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubAfecto_Enabled!=0) ? context.localUtil.Format( A788CotSubAfecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A788CotSubAfecto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubAfecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubInafecto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubInafecto_Internalname, "Inafecto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A789CotSubInafecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubInafecto_Enabled!=0) ? context.localUtil.Format( A789CotSubInafecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A789CotSubInafecto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubInafecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubSelectivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubSelectivo_Internalname, "Selectivo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubSelectivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A790CotSubSelectivo, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubSelectivo_Enabled!=0) ? context.localUtil.Format( A790CotSubSelectivo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A790CotSubSelectivo, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubSelectivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubSelectivo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubExonerado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubExonerado_Internalname, "Exonerado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubExonerado_Internalname, StringUtil.LTrim( StringUtil.NToC( A793CotSubExonerado, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubExonerado_Enabled!=0) ? context.localUtil.Format( A793CotSubExonerado, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A793CotSubExonerado, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubExonerado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubExonerado_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubGratuito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubGratuito_Internalname, "Gratuito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubGratuito_Internalname, StringUtil.LTrim( StringUtil.NToC( A808CotSubGratuito, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubGratuito_Enabled!=0) ? context.localUtil.Format( A808CotSubGratuito, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A808CotSubGratuito, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubGratuito_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubGratuito_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubT_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubT_Internalname, "Sub Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubT_Internalname, StringUtil.LTrim( StringUtil.NToC( A787CotSubT, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubT_Enabled!=0) ? context.localUtil.Format( A787CotSubT, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A787CotSubT, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubT_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotSubTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSubTotal_Internalname, "Sub Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotSubTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A809CotSubTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotSubTotal_Enabled!=0) ? context.localUtil.Format( A809CotSubTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A809CotSubTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSubTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotSubTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotDscto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotDscto_Internalname, "Descuento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotDscto_Internalname, StringUtil.LTrim( StringUtil.NToC( A786CotDscto, 17, 2, ".", "")), StringUtil.LTrim( ((edtCotDscto_Enabled!=0) ? context.localUtil.Format( A786CotDscto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A786CotDscto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDscto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDscto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCotFecAten_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotFecAten_Internalname, "Atención", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCotFecAten_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCotFecAten_Internalname, context.localUtil.Format(A797CotFecAten, "99/99/99"), context.localUtil.Format( A797CotFecAten, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,188);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotFecAten_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotFecAten_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
         GxWebStd.gx_bitmap( context, edtCotFecAten_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCotFecAten_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOTIZA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTieCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTieCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTieCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTieCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,193);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTieCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZA.htm");
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
            Z177CotCod = cgiGet( "Z177CotCod");
            Z796CotFec = context.localUtil.CToD( cgiGet( "Z796CotFec"), 0);
            Z806CotRef = cgiGet( "Z806CotRef");
            Z794CotPorDsct = context.localUtil.CToN( cgiGet( "Z794CotPorDsct"), ".", ",");
            Z802CotPorIVA = context.localUtil.CToN( cgiGet( "Z802CotPorIVA"), ".", ",");
            Z810CotTItem = (short)(context.localUtil.CToN( cgiGet( "Z810CotTItem"), ".", ","));
            Z807CotSts = cgiGet( "Z807CotSts");
            Z812CotUsuC = cgiGet( "Z812CotUsuC");
            Z798CotFecC = context.localUtil.CToT( cgiGet( "Z798CotFecC"), 0);
            Z813CotUsuM = cgiGet( "Z813CotUsuM");
            Z799CotFecM = context.localUtil.CToT( cgiGet( "Z799CotFecM"), 0);
            Z805CotPedCod = cgiGet( "Z805CotPedCod");
            Z764CotCliDespacho = (int)(context.localUtil.CToN( cgiGet( "Z764CotCliDespacho"), ".", ","));
            Z800CotImp = (short)(context.localUtil.CToN( cgiGet( "Z800CotImp"), ".", ","));
            Z763CotAIVA = (short)(context.localUtil.CToN( cgiGet( "Z763CotAIVA"), ".", ","));
            Z803CotRedondeo = context.localUtil.CToN( cgiGet( "Z803CotRedondeo"), ".", ",");
            Z797CotFecAten = context.localUtil.CToD( cgiGet( "Z797CotFecAten"), 0);
            Z45CliCod = cgiGet( "Z45CliCod");
            Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            Z178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
            Z182CotConpCod = (int)(context.localUtil.CToN( cgiGet( "Z182CotConpCod"), ".", ","));
            Z181CotLista = (int)(context.localUtil.CToN( cgiGet( "Z181CotLista"), ".", ","));
            n181CotLista = ((0==A181CotLista) ? true : false);
            Z179CotVendCod = (int)(context.localUtil.CToN( cgiGet( "Z179CotVendCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A177CotCod = cgiGet( edtCotCod_Internalname);
            AssignAttri("", false, "A177CotCod", A177CotCod);
            if ( context.localUtil.VCDate( cgiGet( edtCotFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "COTFEC");
               AnyError = 1;
               GX_FocusControl = edtCotFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A796CotFec = DateTime.MinValue;
               AssignAttri("", false, "A796CotFec", context.localUtil.Format(A796CotFec, "99/99/99"));
            }
            else
            {
               A796CotFec = context.localUtil.CToD( cgiGet( edtCotFec_Internalname), 2);
               AssignAttri("", false, "A796CotFec", context.localUtil.Format(A796CotFec, "99/99/99"));
            }
            A45CliCod = cgiGet( edtCliCod_Internalname);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONCOD");
               AnyError = 1;
               GX_FocusControl = edtMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A180MonCod = 0;
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            else
            {
               A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtCotConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A182CotConpCod = 0;
               AssignAttri("", false, "A182CotConpCod", StringUtil.LTrimStr( (decimal)(A182CotConpCod), 6, 0));
            }
            else
            {
               A182CotConpCod = (int)(context.localUtil.CToN( cgiGet( edtCotConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A182CotConpCod", StringUtil.LTrimStr( (decimal)(A182CotConpCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotLista_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotLista_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTLISTA");
               AnyError = 1;
               GX_FocusControl = edtCotLista_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A181CotLista = 0;
               n181CotLista = false;
               AssignAttri("", false, "A181CotLista", StringUtil.LTrimStr( (decimal)(A181CotLista), 6, 0));
            }
            else
            {
               A181CotLista = (int)(context.localUtil.CToN( cgiGet( edtCotLista_Internalname), ".", ","));
               n181CotLista = false;
               AssignAttri("", false, "A181CotLista", StringUtil.LTrimStr( (decimal)(A181CotLista), 6, 0));
            }
            n181CotLista = ((0==A181CotLista) ? true : false);
            A806CotRef = cgiGet( edtCotRef_Internalname);
            AssignAttri("", false, "A806CotRef", A806CotRef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotPorDsct_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotPorDsct_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTPORDSCT");
               AnyError = 1;
               GX_FocusControl = edtCotPorDsct_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A794CotPorDsct = 0;
               AssignAttri("", false, "A794CotPorDsct", StringUtil.LTrimStr( A794CotPorDsct, 6, 2));
            }
            else
            {
               A794CotPorDsct = context.localUtil.CToN( cgiGet( edtCotPorDsct_Internalname), ".", ",");
               AssignAttri("", false, "A794CotPorDsct", StringUtil.LTrimStr( A794CotPorDsct, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotPorIVA_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotPorIVA_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTPORIVA");
               AnyError = 1;
               GX_FocusControl = edtCotPorIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A802CotPorIVA = 0;
               AssignAttri("", false, "A802CotPorIVA", StringUtil.LTrimStr( A802CotPorIVA, 6, 2));
            }
            else
            {
               A802CotPorIVA = context.localUtil.CToN( cgiGet( edtCotPorIVA_Internalname), ".", ",");
               AssignAttri("", false, "A802CotPorIVA", StringUtil.LTrimStr( A802CotPorIVA, 6, 2));
            }
            A804CotObs = cgiGet( edtCotObs_Internalname);
            AssignAttri("", false, "A804CotObs", A804CotObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotTItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTTITEM");
               AnyError = 1;
               GX_FocusControl = edtCotTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A810CotTItem = 0;
               AssignAttri("", false, "A810CotTItem", StringUtil.LTrimStr( (decimal)(A810CotTItem), 4, 0));
            }
            else
            {
               A810CotTItem = (short)(context.localUtil.CToN( cgiGet( edtCotTItem_Internalname), ".", ","));
               AssignAttri("", false, "A810CotTItem", StringUtil.LTrimStr( (decimal)(A810CotTItem), 4, 0));
            }
            A807CotSts = cgiGet( edtCotSts_Internalname);
            AssignAttri("", false, "A807CotSts", A807CotSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotVendCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotVendCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTVENDCOD");
               AnyError = 1;
               GX_FocusControl = edtCotVendCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A179CotVendCod = 0;
               AssignAttri("", false, "A179CotVendCod", StringUtil.LTrimStr( (decimal)(A179CotVendCod), 6, 0));
            }
            else
            {
               A179CotVendCod = (int)(context.localUtil.CToN( cgiGet( edtCotVendCod_Internalname), ".", ","));
               AssignAttri("", false, "A179CotVendCod", StringUtil.LTrimStr( (decimal)(A179CotVendCod), 6, 0));
            }
            A812CotUsuC = cgiGet( edtCotUsuC_Internalname);
            AssignAttri("", false, "A812CotUsuC", A812CotUsuC);
            if ( context.localUtil.VCDateTime( cgiGet( edtCotFecC_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Creación"}), 1, "COTFECC");
               AnyError = 1;
               GX_FocusControl = edtCotFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A798CotFecC = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A798CotFecC", context.localUtil.TToC( A798CotFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A798CotFecC = context.localUtil.CToT( cgiGet( edtCotFecC_Internalname));
               AssignAttri("", false, "A798CotFecC", context.localUtil.TToC( A798CotFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            A813CotUsuM = cgiGet( edtCotUsuM_Internalname);
            AssignAttri("", false, "A813CotUsuM", A813CotUsuM);
            if ( context.localUtil.VCDateTime( cgiGet( edtCotFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Modificación"}), 1, "COTFECM");
               AnyError = 1;
               GX_FocusControl = edtCotFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A799CotFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A799CotFecM", context.localUtil.TToC( A799CotFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A799CotFecM = context.localUtil.CToT( cgiGet( edtCotFecM_Internalname));
               AssignAttri("", false, "A799CotFecM", context.localUtil.TToC( A799CotFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            A805CotPedCod = cgiGet( edtCotPedCod_Internalname);
            AssignAttri("", false, "A805CotPedCod", A805CotPedCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotCliDespacho_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotCliDespacho_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTCLIDESPACHO");
               AnyError = 1;
               GX_FocusControl = edtCotCliDespacho_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A764CotCliDespacho = 0;
               AssignAttri("", false, "A764CotCliDespacho", StringUtil.LTrimStr( (decimal)(A764CotCliDespacho), 6, 0));
            }
            else
            {
               A764CotCliDespacho = (int)(context.localUtil.CToN( cgiGet( edtCotCliDespacho_Internalname), ".", ","));
               AssignAttri("", false, "A764CotCliDespacho", StringUtil.LTrimStr( (decimal)(A764CotCliDespacho), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotImp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotImp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTIMP");
               AnyError = 1;
               GX_FocusControl = edtCotImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A800CotImp = 0;
               AssignAttri("", false, "A800CotImp", StringUtil.Str( (decimal)(A800CotImp), 1, 0));
            }
            else
            {
               A800CotImp = (short)(context.localUtil.CToN( cgiGet( edtCotImp_Internalname), ".", ","));
               AssignAttri("", false, "A800CotImp", StringUtil.Str( (decimal)(A800CotImp), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotAIVA_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotAIVA_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTAIVA");
               AnyError = 1;
               GX_FocusControl = edtCotAIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A763CotAIVA = 0;
               AssignAttri("", false, "A763CotAIVA", StringUtil.Str( (decimal)(A763CotAIVA), 1, 0));
            }
            else
            {
               A763CotAIVA = (short)(context.localUtil.CToN( cgiGet( edtCotAIVA_Internalname), ".", ","));
               AssignAttri("", false, "A763CotAIVA", StringUtil.Str( (decimal)(A763CotAIVA), 1, 0));
            }
            A801CotIVA = context.localUtil.CToN( cgiGet( edtCotIVA_Internalname), ".", ",");
            AssignAttri("", false, "A801CotIVA", StringUtil.LTrimStr( A801CotIVA, 15, 2));
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotRedondeo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCotRedondeo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTREDONDEO");
               AnyError = 1;
               GX_FocusControl = edtCotRedondeo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A803CotRedondeo = 0;
               AssignAttri("", false, "A803CotRedondeo", StringUtil.LTrimStr( A803CotRedondeo, 15, 2));
            }
            else
            {
               A803CotRedondeo = context.localUtil.CToN( cgiGet( edtCotRedondeo_Internalname), ".", ",");
               AssignAttri("", false, "A803CotRedondeo", StringUtil.LTrimStr( A803CotRedondeo, 15, 2));
            }
            A811CotTotal = context.localUtil.CToN( cgiGet( edtCotTotal_Internalname), ".", ",");
            AssignAttri("", false, "A811CotTotal", StringUtil.LTrimStr( A811CotTotal, 15, 2));
            A788CotSubAfecto = context.localUtil.CToN( cgiGet( edtCotSubAfecto_Internalname), ".", ",");
            AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
            A789CotSubInafecto = context.localUtil.CToN( cgiGet( edtCotSubInafecto_Internalname), ".", ",");
            AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
            A790CotSubSelectivo = context.localUtil.CToN( cgiGet( edtCotSubSelectivo_Internalname), ".", ",");
            AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
            A793CotSubExonerado = context.localUtil.CToN( cgiGet( edtCotSubExonerado_Internalname), ".", ",");
            AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
            A808CotSubGratuito = context.localUtil.CToN( cgiGet( edtCotSubGratuito_Internalname), ".", ",");
            AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
            A787CotSubT = context.localUtil.CToN( cgiGet( edtCotSubT_Internalname), ".", ",");
            AssignAttri("", false, "A787CotSubT", StringUtil.LTrimStr( A787CotSubT, 15, 2));
            A809CotSubTotal = context.localUtil.CToN( cgiGet( edtCotSubTotal_Internalname), ".", ",");
            AssignAttri("", false, "A809CotSubTotal", StringUtil.LTrimStr( A809CotSubTotal, 15, 2));
            A786CotDscto = context.localUtil.CToN( cgiGet( edtCotDscto_Internalname), ".", ",");
            AssignAttri("", false, "A786CotDscto", StringUtil.LTrimStr( A786CotDscto, 15, 2));
            if ( context.localUtil.VCDate( cgiGet( edtCotFecAten_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Atención"}), 1, "COTFECATEN");
               AnyError = 1;
               GX_FocusControl = edtCotFecAten_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A797CotFecAten = DateTime.MinValue;
               AssignAttri("", false, "A797CotFecAten", context.localUtil.Format(A797CotFecAten, "99/99/99"));
            }
            else
            {
               A797CotFecAten = context.localUtil.CToD( cgiGet( edtCotFecAten_Internalname), 2);
               AssignAttri("", false, "A797CotFecAten", context.localUtil.Format(A797CotFecAten, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIECOD");
               AnyError = 1;
               GX_FocusControl = edtTieCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A178TieCod = 0;
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            }
            else
            {
               A178TieCod = (int)(context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ","));
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
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
               A177CotCod = GetPar( "CotCod");
               AssignAttri("", false, "A177CotCod", A177CotCod);
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
               InitAll2I86( ) ;
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
         DisableAttributes2I86( ) ;
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

      protected void ResetCaption2I0( )
      {
      }

      protected void ZM2I86( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z796CotFec = T002I3_A796CotFec[0];
               Z806CotRef = T002I3_A806CotRef[0];
               Z794CotPorDsct = T002I3_A794CotPorDsct[0];
               Z802CotPorIVA = T002I3_A802CotPorIVA[0];
               Z810CotTItem = T002I3_A810CotTItem[0];
               Z807CotSts = T002I3_A807CotSts[0];
               Z812CotUsuC = T002I3_A812CotUsuC[0];
               Z798CotFecC = T002I3_A798CotFecC[0];
               Z813CotUsuM = T002I3_A813CotUsuM[0];
               Z799CotFecM = T002I3_A799CotFecM[0];
               Z805CotPedCod = T002I3_A805CotPedCod[0];
               Z764CotCliDespacho = T002I3_A764CotCliDespacho[0];
               Z800CotImp = T002I3_A800CotImp[0];
               Z763CotAIVA = T002I3_A763CotAIVA[0];
               Z803CotRedondeo = T002I3_A803CotRedondeo[0];
               Z797CotFecAten = T002I3_A797CotFecAten[0];
               Z45CliCod = T002I3_A45CliCod[0];
               Z180MonCod = T002I3_A180MonCod[0];
               Z178TieCod = T002I3_A178TieCod[0];
               Z182CotConpCod = T002I3_A182CotConpCod[0];
               Z181CotLista = T002I3_A181CotLista[0];
               Z179CotVendCod = T002I3_A179CotVendCod[0];
            }
            else
            {
               Z796CotFec = A796CotFec;
               Z806CotRef = A806CotRef;
               Z794CotPorDsct = A794CotPorDsct;
               Z802CotPorIVA = A802CotPorIVA;
               Z810CotTItem = A810CotTItem;
               Z807CotSts = A807CotSts;
               Z812CotUsuC = A812CotUsuC;
               Z798CotFecC = A798CotFecC;
               Z813CotUsuM = A813CotUsuM;
               Z799CotFecM = A799CotFecM;
               Z805CotPedCod = A805CotPedCod;
               Z764CotCliDespacho = A764CotCliDespacho;
               Z800CotImp = A800CotImp;
               Z763CotAIVA = A763CotAIVA;
               Z803CotRedondeo = A803CotRedondeo;
               Z797CotFecAten = A797CotFecAten;
               Z45CliCod = A45CliCod;
               Z180MonCod = A180MonCod;
               Z178TieCod = A178TieCod;
               Z182CotConpCod = A182CotConpCod;
               Z181CotLista = A181CotLista;
               Z179CotVendCod = A179CotVendCod;
            }
         }
         if ( GX_JID == -10 )
         {
            Z177CotCod = A177CotCod;
            Z796CotFec = A796CotFec;
            Z806CotRef = A806CotRef;
            Z794CotPorDsct = A794CotPorDsct;
            Z802CotPorIVA = A802CotPorIVA;
            Z804CotObs = A804CotObs;
            Z810CotTItem = A810CotTItem;
            Z807CotSts = A807CotSts;
            Z812CotUsuC = A812CotUsuC;
            Z798CotFecC = A798CotFecC;
            Z813CotUsuM = A813CotUsuM;
            Z799CotFecM = A799CotFecM;
            Z805CotPedCod = A805CotPedCod;
            Z764CotCliDespacho = A764CotCliDespacho;
            Z800CotImp = A800CotImp;
            Z763CotAIVA = A763CotAIVA;
            Z803CotRedondeo = A803CotRedondeo;
            Z797CotFecAten = A797CotFecAten;
            Z45CliCod = A45CliCod;
            Z180MonCod = A180MonCod;
            Z178TieCod = A178TieCod;
            Z182CotConpCod = A182CotConpCod;
            Z181CotLista = A181CotLista;
            Z179CotVendCod = A179CotVendCod;
            Z788CotSubAfecto = A788CotSubAfecto;
            Z789CotSubInafecto = A789CotSubInafecto;
            Z790CotSubSelectivo = A790CotSubSelectivo;
            Z793CotSubExonerado = A793CotSubExonerado;
            Z808CotSubGratuito = A808CotSubGratuito;
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

      protected void Load2I86( )
      {
         /* Using cursor T002I13 */
         pr_default.execute(9, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound86 = 1;
            A796CotFec = T002I13_A796CotFec[0];
            AssignAttri("", false, "A796CotFec", context.localUtil.Format(A796CotFec, "99/99/99"));
            A806CotRef = T002I13_A806CotRef[0];
            AssignAttri("", false, "A806CotRef", A806CotRef);
            A794CotPorDsct = T002I13_A794CotPorDsct[0];
            AssignAttri("", false, "A794CotPorDsct", StringUtil.LTrimStr( A794CotPorDsct, 6, 2));
            A802CotPorIVA = T002I13_A802CotPorIVA[0];
            AssignAttri("", false, "A802CotPorIVA", StringUtil.LTrimStr( A802CotPorIVA, 6, 2));
            A804CotObs = T002I13_A804CotObs[0];
            AssignAttri("", false, "A804CotObs", A804CotObs);
            A810CotTItem = T002I13_A810CotTItem[0];
            AssignAttri("", false, "A810CotTItem", StringUtil.LTrimStr( (decimal)(A810CotTItem), 4, 0));
            A807CotSts = T002I13_A807CotSts[0];
            AssignAttri("", false, "A807CotSts", A807CotSts);
            A812CotUsuC = T002I13_A812CotUsuC[0];
            AssignAttri("", false, "A812CotUsuC", A812CotUsuC);
            A798CotFecC = T002I13_A798CotFecC[0];
            AssignAttri("", false, "A798CotFecC", context.localUtil.TToC( A798CotFecC, 8, 5, 0, 3, "/", ":", " "));
            A813CotUsuM = T002I13_A813CotUsuM[0];
            AssignAttri("", false, "A813CotUsuM", A813CotUsuM);
            A799CotFecM = T002I13_A799CotFecM[0];
            AssignAttri("", false, "A799CotFecM", context.localUtil.TToC( A799CotFecM, 8, 5, 0, 3, "/", ":", " "));
            A805CotPedCod = T002I13_A805CotPedCod[0];
            AssignAttri("", false, "A805CotPedCod", A805CotPedCod);
            A764CotCliDespacho = T002I13_A764CotCliDespacho[0];
            AssignAttri("", false, "A764CotCliDespacho", StringUtil.LTrimStr( (decimal)(A764CotCliDespacho), 6, 0));
            A800CotImp = T002I13_A800CotImp[0];
            AssignAttri("", false, "A800CotImp", StringUtil.Str( (decimal)(A800CotImp), 1, 0));
            A763CotAIVA = T002I13_A763CotAIVA[0];
            AssignAttri("", false, "A763CotAIVA", StringUtil.Str( (decimal)(A763CotAIVA), 1, 0));
            A803CotRedondeo = T002I13_A803CotRedondeo[0];
            AssignAttri("", false, "A803CotRedondeo", StringUtil.LTrimStr( A803CotRedondeo, 15, 2));
            A797CotFecAten = T002I13_A797CotFecAten[0];
            AssignAttri("", false, "A797CotFecAten", context.localUtil.Format(A797CotFecAten, "99/99/99"));
            A45CliCod = T002I13_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A180MonCod = T002I13_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A178TieCod = T002I13_A178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            A182CotConpCod = T002I13_A182CotConpCod[0];
            AssignAttri("", false, "A182CotConpCod", StringUtil.LTrimStr( (decimal)(A182CotConpCod), 6, 0));
            A181CotLista = T002I13_A181CotLista[0];
            n181CotLista = T002I13_n181CotLista[0];
            AssignAttri("", false, "A181CotLista", StringUtil.LTrimStr( (decimal)(A181CotLista), 6, 0));
            A179CotVendCod = T002I13_A179CotVendCod[0];
            AssignAttri("", false, "A179CotVendCod", StringUtil.LTrimStr( (decimal)(A179CotVendCod), 6, 0));
            A788CotSubAfecto = T002I13_A788CotSubAfecto[0];
            AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
            A789CotSubInafecto = T002I13_A789CotSubInafecto[0];
            AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
            A790CotSubSelectivo = T002I13_A790CotSubSelectivo[0];
            AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
            A793CotSubExonerado = T002I13_A793CotSubExonerado[0];
            AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
            A808CotSubGratuito = T002I13_A808CotSubGratuito[0];
            AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
            ZM2I86( -10) ;
         }
         pr_default.close(9);
         OnLoadActions2I86( ) ;
      }

      protected void OnLoadActions2I86( )
      {
         A787CotSubT = (decimal)(A788CotSubAfecto+A789CotSubInafecto+A790CotSubSelectivo+A793CotSubExonerado);
         AssignAttri("", false, "A787CotSubT", StringUtil.LTrimStr( A787CotSubT, 15, 2));
         A786CotDscto = (decimal)(((A787CotSubT*A794CotPorDsct)/ (decimal)(100)));
         AssignAttri("", false, "A786CotDscto", StringUtil.LTrimStr( A786CotDscto, 15, 2));
         A801CotIVA = (decimal)((((A788CotSubAfecto+A790CotSubSelectivo-A786CotDscto)*A802CotPorIVA)/ (decimal)(100))+A803CotRedondeo);
         AssignAttri("", false, "A801CotIVA", StringUtil.LTrimStr( A801CotIVA, 15, 2));
         A809CotSubTotal = (decimal)(A788CotSubAfecto+A790CotSubSelectivo-A786CotDscto);
         AssignAttri("", false, "A809CotSubTotal", StringUtil.LTrimStr( A809CotSubTotal, 15, 2));
         A811CotTotal = (decimal)((A787CotSubT-A786CotDscto)+A801CotIVA);
         AssignAttri("", false, "A811CotTotal", StringUtil.LTrimStr( A811CotTotal, 15, 2));
      }

      protected void CheckExtendedTable2I86( )
      {
         nIsDirty_86 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002I11 */
         pr_default.execute(8, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A788CotSubAfecto = T002I11_A788CotSubAfecto[0];
            AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
            A789CotSubInafecto = T002I11_A789CotSubInafecto[0];
            AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
            A790CotSubSelectivo = T002I11_A790CotSubSelectivo[0];
            AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
            A793CotSubExonerado = T002I11_A793CotSubExonerado[0];
            AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
            A808CotSubGratuito = T002I11_A808CotSubGratuito[0];
            AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
         }
         else
         {
            nIsDirty_86 = 1;
            A788CotSubAfecto = 0;
            AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
            nIsDirty_86 = 1;
            A789CotSubInafecto = 0;
            AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
            nIsDirty_86 = 1;
            A790CotSubSelectivo = 0;
            AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
            nIsDirty_86 = 1;
            A793CotSubExonerado = 0;
            AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
            nIsDirty_86 = 1;
            A808CotSubGratuito = 0;
            AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
         }
         pr_default.close(8);
         nIsDirty_86 = 1;
         A787CotSubT = (decimal)(A788CotSubAfecto+A789CotSubInafecto+A790CotSubSelectivo+A793CotSubExonerado);
         AssignAttri("", false, "A787CotSubT", StringUtil.LTrimStr( A787CotSubT, 15, 2));
         nIsDirty_86 = 1;
         A786CotDscto = (decimal)(((A787CotSubT*A794CotPorDsct)/ (decimal)(100)));
         AssignAttri("", false, "A786CotDscto", StringUtil.LTrimStr( A786CotDscto, 15, 2));
         nIsDirty_86 = 1;
         A801CotIVA = (decimal)((((A788CotSubAfecto+A790CotSubSelectivo-A786CotDscto)*A802CotPorIVA)/ (decimal)(100))+A803CotRedondeo);
         AssignAttri("", false, "A801CotIVA", StringUtil.LTrimStr( A801CotIVA, 15, 2));
         nIsDirty_86 = 1;
         A809CotSubTotal = (decimal)(A788CotSubAfecto+A790CotSubSelectivo-A786CotDscto);
         AssignAttri("", false, "A809CotSubTotal", StringUtil.LTrimStr( A809CotSubTotal, 15, 2));
         nIsDirty_86 = 1;
         A811CotTotal = (decimal)((A787CotSubT-A786CotDscto)+A801CotIVA);
         AssignAttri("", false, "A811CotTotal", StringUtil.LTrimStr( A811CotTotal, 15, 2));
         if ( ! ( (DateTime.MinValue==A796CotFec) || ( DateTimeUtil.ResetTime ( A796CotFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "COTFEC");
            AnyError = 1;
            GX_FocusControl = edtCotFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002I4 */
         pr_default.execute(2, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002I5 */
         pr_default.execute(3, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T002I7 */
         pr_default.execute(5, new Object[] {A182CotConpCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion de Pago'.", "ForeignKeyNotFound", 1, "COTCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtCotConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T002I8 */
         pr_default.execute(6, new Object[] {n181CotLista, A181CotLista});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A181CotLista) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "COTLISTA");
               AnyError = 1;
               GX_FocusControl = edtCotLista_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T002I9 */
         pr_default.execute(7, new Object[] {A179CotVendCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "COTVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCotVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A798CotFecC) || ( A798CotFecC >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Creación fuera de rango", "OutOfRange", 1, "COTFECC");
            AnyError = 1;
            GX_FocusControl = edtCotFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A799CotFecM) || ( A799CotFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Modificación fuera de rango", "OutOfRange", 1, "COTFECM");
            AnyError = 1;
            GX_FocusControl = edtCotFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A797CotFecAten) || ( DateTimeUtil.ResetTime ( A797CotFecAten ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Atención fuera de rango", "OutOfRange", 1, "COTFECATEN");
            AnyError = 1;
            GX_FocusControl = edtCotFecAten_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002I6 */
         pr_default.execute(4, new Object[] {A178TieCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tiendas'.", "ForeignKeyNotFound", 1, "TIECOD");
            AnyError = 1;
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2I86( )
      {
         pr_default.close(8);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( string A177CotCod )
      {
         /* Using cursor T002I15 */
         pr_default.execute(10, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A788CotSubAfecto = T002I15_A788CotSubAfecto[0];
            AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
            A789CotSubInafecto = T002I15_A789CotSubInafecto[0];
            AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
            A790CotSubSelectivo = T002I15_A790CotSubSelectivo[0];
            AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
            A793CotSubExonerado = T002I15_A793CotSubExonerado[0];
            AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
            A808CotSubGratuito = T002I15_A808CotSubGratuito[0];
            AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
         }
         else
         {
            A788CotSubAfecto = 0;
            AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
            A789CotSubInafecto = 0;
            AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
            A790CotSubSelectivo = 0;
            AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
            A793CotSubExonerado = 0;
            AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
            A808CotSubGratuito = 0;
            AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A788CotSubAfecto, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A789CotSubInafecto, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A790CotSubSelectivo, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A793CotSubExonerado, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A808CotSubGratuito, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_11( string A45CliCod )
      {
         /* Using cursor T002I16 */
         pr_default.execute(11, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_12( int A180MonCod )
      {
         /* Using cursor T002I17 */
         pr_default.execute(12, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_14( int A182CotConpCod )
      {
         /* Using cursor T002I18 */
         pr_default.execute(13, new Object[] {A182CotConpCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion de Pago'.", "ForeignKeyNotFound", 1, "COTCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtCotConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_15( int A181CotLista )
      {
         /* Using cursor T002I19 */
         pr_default.execute(14, new Object[] {n181CotLista, A181CotLista});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A181CotLista) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "COTLISTA");
               AnyError = 1;
               GX_FocusControl = edtCotLista_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_16( int A179CotVendCod )
      {
         /* Using cursor T002I20 */
         pr_default.execute(15, new Object[] {A179CotVendCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "COTVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCotVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_13( int A178TieCod )
      {
         /* Using cursor T002I21 */
         pr_default.execute(16, new Object[] {A178TieCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tiendas'.", "ForeignKeyNotFound", 1, "TIECOD");
            AnyError = 1;
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey2I86( )
      {
         /* Using cursor T002I22 */
         pr_default.execute(17, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002I3 */
         pr_default.execute(1, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2I86( 10) ;
            RcdFound86 = 1;
            A177CotCod = T002I3_A177CotCod[0];
            AssignAttri("", false, "A177CotCod", A177CotCod);
            A796CotFec = T002I3_A796CotFec[0];
            AssignAttri("", false, "A796CotFec", context.localUtil.Format(A796CotFec, "99/99/99"));
            A806CotRef = T002I3_A806CotRef[0];
            AssignAttri("", false, "A806CotRef", A806CotRef);
            A794CotPorDsct = T002I3_A794CotPorDsct[0];
            AssignAttri("", false, "A794CotPorDsct", StringUtil.LTrimStr( A794CotPorDsct, 6, 2));
            A802CotPorIVA = T002I3_A802CotPorIVA[0];
            AssignAttri("", false, "A802CotPorIVA", StringUtil.LTrimStr( A802CotPorIVA, 6, 2));
            A804CotObs = T002I3_A804CotObs[0];
            AssignAttri("", false, "A804CotObs", A804CotObs);
            A810CotTItem = T002I3_A810CotTItem[0];
            AssignAttri("", false, "A810CotTItem", StringUtil.LTrimStr( (decimal)(A810CotTItem), 4, 0));
            A807CotSts = T002I3_A807CotSts[0];
            AssignAttri("", false, "A807CotSts", A807CotSts);
            A812CotUsuC = T002I3_A812CotUsuC[0];
            AssignAttri("", false, "A812CotUsuC", A812CotUsuC);
            A798CotFecC = T002I3_A798CotFecC[0];
            AssignAttri("", false, "A798CotFecC", context.localUtil.TToC( A798CotFecC, 8, 5, 0, 3, "/", ":", " "));
            A813CotUsuM = T002I3_A813CotUsuM[0];
            AssignAttri("", false, "A813CotUsuM", A813CotUsuM);
            A799CotFecM = T002I3_A799CotFecM[0];
            AssignAttri("", false, "A799CotFecM", context.localUtil.TToC( A799CotFecM, 8, 5, 0, 3, "/", ":", " "));
            A805CotPedCod = T002I3_A805CotPedCod[0];
            AssignAttri("", false, "A805CotPedCod", A805CotPedCod);
            A764CotCliDespacho = T002I3_A764CotCliDespacho[0];
            AssignAttri("", false, "A764CotCliDespacho", StringUtil.LTrimStr( (decimal)(A764CotCliDespacho), 6, 0));
            A800CotImp = T002I3_A800CotImp[0];
            AssignAttri("", false, "A800CotImp", StringUtil.Str( (decimal)(A800CotImp), 1, 0));
            A763CotAIVA = T002I3_A763CotAIVA[0];
            AssignAttri("", false, "A763CotAIVA", StringUtil.Str( (decimal)(A763CotAIVA), 1, 0));
            A803CotRedondeo = T002I3_A803CotRedondeo[0];
            AssignAttri("", false, "A803CotRedondeo", StringUtil.LTrimStr( A803CotRedondeo, 15, 2));
            A797CotFecAten = T002I3_A797CotFecAten[0];
            AssignAttri("", false, "A797CotFecAten", context.localUtil.Format(A797CotFecAten, "99/99/99"));
            A45CliCod = T002I3_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A180MonCod = T002I3_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A178TieCod = T002I3_A178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            A182CotConpCod = T002I3_A182CotConpCod[0];
            AssignAttri("", false, "A182CotConpCod", StringUtil.LTrimStr( (decimal)(A182CotConpCod), 6, 0));
            A181CotLista = T002I3_A181CotLista[0];
            n181CotLista = T002I3_n181CotLista[0];
            AssignAttri("", false, "A181CotLista", StringUtil.LTrimStr( (decimal)(A181CotLista), 6, 0));
            A179CotVendCod = T002I3_A179CotVendCod[0];
            AssignAttri("", false, "A179CotVendCod", StringUtil.LTrimStr( (decimal)(A179CotVendCod), 6, 0));
            Z177CotCod = A177CotCod;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2I86( ) ;
            if ( AnyError == 1 )
            {
               RcdFound86 = 0;
               InitializeNonKey2I86( ) ;
            }
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey2I86( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2I86( ) ;
         if ( RcdFound86 == 0 )
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
         RcdFound86 = 0;
         /* Using cursor T002I23 */
         pr_default.execute(18, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( StringUtil.StrCmp(T002I23_A177CotCod[0], A177CotCod) < 0 ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( StringUtil.StrCmp(T002I23_A177CotCod[0], A177CotCod) > 0 ) ) )
            {
               A177CotCod = T002I23_A177CotCod[0];
               AssignAttri("", false, "A177CotCod", A177CotCod);
               RcdFound86 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void move_previous( )
      {
         RcdFound86 = 0;
         /* Using cursor T002I24 */
         pr_default.execute(19, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( StringUtil.StrCmp(T002I24_A177CotCod[0], A177CotCod) > 0 ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( StringUtil.StrCmp(T002I24_A177CotCod[0], A177CotCod) < 0 ) ) )
            {
               A177CotCod = T002I24_A177CotCod[0];
               AssignAttri("", false, "A177CotCod", A177CotCod);
               RcdFound86 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2I86( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2I86( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound86 == 1 )
            {
               if ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 )
               {
                  A177CotCod = Z177CotCod;
                  AssignAttri("", false, "A177CotCod", A177CotCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2I86( ) ;
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2I86( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCotCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCotCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2I86( ) ;
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
         if ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 )
         {
            A177CotCod = Z177CotCod;
            AssignAttri("", false, "A177CotCod", A177CotCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCotCod_Internalname;
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
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCotFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2I86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCotFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2I86( ) ;
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
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCotFec_Internalname;
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
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCotFec_Internalname;
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
         ScanStart2I86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound86 != 0 )
            {
               ScanNext2I86( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCotFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2I86( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2I86( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002I2 */
            pr_default.execute(0, new Object[] {A177CotCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOTIZA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z796CotFec ) != DateTimeUtil.ResetTime ( T002I2_A796CotFec[0] ) ) || ( StringUtil.StrCmp(Z806CotRef, T002I2_A806CotRef[0]) != 0 ) || ( Z794CotPorDsct != T002I2_A794CotPorDsct[0] ) || ( Z802CotPorIVA != T002I2_A802CotPorIVA[0] ) || ( Z810CotTItem != T002I2_A810CotTItem[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z807CotSts, T002I2_A807CotSts[0]) != 0 ) || ( StringUtil.StrCmp(Z812CotUsuC, T002I2_A812CotUsuC[0]) != 0 ) || ( Z798CotFecC != T002I2_A798CotFecC[0] ) || ( StringUtil.StrCmp(Z813CotUsuM, T002I2_A813CotUsuM[0]) != 0 ) || ( Z799CotFecM != T002I2_A799CotFecM[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z805CotPedCod, T002I2_A805CotPedCod[0]) != 0 ) || ( Z764CotCliDespacho != T002I2_A764CotCliDespacho[0] ) || ( Z800CotImp != T002I2_A800CotImp[0] ) || ( Z763CotAIVA != T002I2_A763CotAIVA[0] ) || ( Z803CotRedondeo != T002I2_A803CotRedondeo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z797CotFecAten ) != DateTimeUtil.ResetTime ( T002I2_A797CotFecAten[0] ) ) || ( StringUtil.StrCmp(Z45CliCod, T002I2_A45CliCod[0]) != 0 ) || ( Z180MonCod != T002I2_A180MonCod[0] ) || ( Z178TieCod != T002I2_A178TieCod[0] ) || ( Z182CotConpCod != T002I2_A182CotConpCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z181CotLista != T002I2_A181CotLista[0] ) || ( Z179CotVendCod != T002I2_A179CotVendCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z796CotFec ) != DateTimeUtil.ResetTime ( T002I2_A796CotFec[0] ) )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotFec");
                  GXUtil.WriteLogRaw("Old: ",Z796CotFec);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A796CotFec[0]);
               }
               if ( StringUtil.StrCmp(Z806CotRef, T002I2_A806CotRef[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotRef");
                  GXUtil.WriteLogRaw("Old: ",Z806CotRef);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A806CotRef[0]);
               }
               if ( Z794CotPorDsct != T002I2_A794CotPorDsct[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotPorDsct");
                  GXUtil.WriteLogRaw("Old: ",Z794CotPorDsct);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A794CotPorDsct[0]);
               }
               if ( Z802CotPorIVA != T002I2_A802CotPorIVA[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotPorIVA");
                  GXUtil.WriteLogRaw("Old: ",Z802CotPorIVA);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A802CotPorIVA[0]);
               }
               if ( Z810CotTItem != T002I2_A810CotTItem[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotTItem");
                  GXUtil.WriteLogRaw("Old: ",Z810CotTItem);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A810CotTItem[0]);
               }
               if ( StringUtil.StrCmp(Z807CotSts, T002I2_A807CotSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotSts");
                  GXUtil.WriteLogRaw("Old: ",Z807CotSts);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A807CotSts[0]);
               }
               if ( StringUtil.StrCmp(Z812CotUsuC, T002I2_A812CotUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z812CotUsuC);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A812CotUsuC[0]);
               }
               if ( Z798CotFecC != T002I2_A798CotFecC[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotFecC");
                  GXUtil.WriteLogRaw("Old: ",Z798CotFecC);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A798CotFecC[0]);
               }
               if ( StringUtil.StrCmp(Z813CotUsuM, T002I2_A813CotUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z813CotUsuM);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A813CotUsuM[0]);
               }
               if ( Z799CotFecM != T002I2_A799CotFecM[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotFecM");
                  GXUtil.WriteLogRaw("Old: ",Z799CotFecM);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A799CotFecM[0]);
               }
               if ( StringUtil.StrCmp(Z805CotPedCod, T002I2_A805CotPedCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotPedCod");
                  GXUtil.WriteLogRaw("Old: ",Z805CotPedCod);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A805CotPedCod[0]);
               }
               if ( Z764CotCliDespacho != T002I2_A764CotCliDespacho[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotCliDespacho");
                  GXUtil.WriteLogRaw("Old: ",Z764CotCliDespacho);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A764CotCliDespacho[0]);
               }
               if ( Z800CotImp != T002I2_A800CotImp[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotImp");
                  GXUtil.WriteLogRaw("Old: ",Z800CotImp);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A800CotImp[0]);
               }
               if ( Z763CotAIVA != T002I2_A763CotAIVA[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotAIVA");
                  GXUtil.WriteLogRaw("Old: ",Z763CotAIVA);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A763CotAIVA[0]);
               }
               if ( Z803CotRedondeo != T002I2_A803CotRedondeo[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotRedondeo");
                  GXUtil.WriteLogRaw("Old: ",Z803CotRedondeo);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A803CotRedondeo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z797CotFecAten ) != DateTimeUtil.ResetTime ( T002I2_A797CotFecAten[0] ) )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotFecAten");
                  GXUtil.WriteLogRaw("Old: ",Z797CotFecAten);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A797CotFecAten[0]);
               }
               if ( StringUtil.StrCmp(Z45CliCod, T002I2_A45CliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CliCod");
                  GXUtil.WriteLogRaw("Old: ",Z45CliCod);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A45CliCod[0]);
               }
               if ( Z180MonCod != T002I2_A180MonCod[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"MonCod");
                  GXUtil.WriteLogRaw("Old: ",Z180MonCod);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A180MonCod[0]);
               }
               if ( Z178TieCod != T002I2_A178TieCod[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"TieCod");
                  GXUtil.WriteLogRaw("Old: ",Z178TieCod);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A178TieCod[0]);
               }
               if ( Z182CotConpCod != T002I2_A182CotConpCod[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotConpCod");
                  GXUtil.WriteLogRaw("Old: ",Z182CotConpCod);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A182CotConpCod[0]);
               }
               if ( Z181CotLista != T002I2_A181CotLista[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotLista");
                  GXUtil.WriteLogRaw("Old: ",Z181CotLista);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A181CotLista[0]);
               }
               if ( Z179CotVendCod != T002I2_A179CotVendCod[0] )
               {
                  GXUtil.WriteLog("clcotiza:[seudo value changed for attri]"+"CotVendCod");
                  GXUtil.WriteLogRaw("Old: ",Z179CotVendCod);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A179CotVendCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCOTIZA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2I86( )
      {
         BeforeValidate2I86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I86( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2I86( 0) ;
            CheckOptimisticConcurrency2I86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2I86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002I25 */
                     pr_default.execute(20, new Object[] {A177CotCod, A796CotFec, A806CotRef, A794CotPorDsct, A802CotPorIVA, A804CotObs, A810CotTItem, A807CotSts, A812CotUsuC, A798CotFecC, A813CotUsuM, A799CotFecM, A805CotPedCod, A764CotCliDespacho, A800CotImp, A763CotAIVA, A803CotRedondeo, A797CotFecAten, A45CliCod, A180MonCod, A178TieCod, A182CotConpCod, n181CotLista, A181CotLista, A179CotVendCod});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZA");
                     if ( (pr_default.getStatus(20) == 1) )
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
                           ResetCaption2I0( ) ;
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
               Load2I86( ) ;
            }
            EndLevel2I86( ) ;
         }
         CloseExtendedTableCursors2I86( ) ;
      }

      protected void Update2I86( )
      {
         BeforeValidate2I86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I86( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2I86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002I26 */
                     pr_default.execute(21, new Object[] {A796CotFec, A806CotRef, A794CotPorDsct, A802CotPorIVA, A804CotObs, A810CotTItem, A807CotSts, A812CotUsuC, A798CotFecC, A813CotUsuM, A799CotFecM, A805CotPedCod, A764CotCliDespacho, A800CotImp, A763CotAIVA, A803CotRedondeo, A797CotFecAten, A45CliCod, A180MonCod, A178TieCod, A182CotConpCod, n181CotLista, A181CotLista, A179CotVendCod, A177CotCod});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZA");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOTIZA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2I86( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2I0( ) ;
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
            EndLevel2I86( ) ;
         }
         CloseExtendedTableCursors2I86( ) ;
      }

      protected void DeferredUpdate2I86( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2I86( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I86( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2I86( ) ;
            AfterConfirm2I86( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2I86( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002I27 */
                  pr_default.execute(22, new Object[] {A177CotCod});
                  pr_default.close(22);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound86 == 0 )
                        {
                           InitAll2I86( ) ;
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
                        ResetCaption2I0( ) ;
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2I86( ) ;
         Gx_mode = sMode86;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2I86( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002I29 */
            pr_default.execute(23, new Object[] {A177CotCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A788CotSubAfecto = T002I29_A788CotSubAfecto[0];
               AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
               A789CotSubInafecto = T002I29_A789CotSubInafecto[0];
               AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
               A790CotSubSelectivo = T002I29_A790CotSubSelectivo[0];
               AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
               A793CotSubExonerado = T002I29_A793CotSubExonerado[0];
               AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
               A808CotSubGratuito = T002I29_A808CotSubGratuito[0];
               AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
            }
            else
            {
               A788CotSubAfecto = 0;
               AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
               A789CotSubInafecto = 0;
               AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
               A790CotSubSelectivo = 0;
               AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
               A793CotSubExonerado = 0;
               AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
               A808CotSubGratuito = 0;
               AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
            }
            pr_default.close(23);
            A787CotSubT = (decimal)(A788CotSubAfecto+A789CotSubInafecto+A790CotSubSelectivo+A793CotSubExonerado);
            AssignAttri("", false, "A787CotSubT", StringUtil.LTrimStr( A787CotSubT, 15, 2));
            A786CotDscto = (decimal)(((A787CotSubT*A794CotPorDsct)/ (decimal)(100)));
            AssignAttri("", false, "A786CotDscto", StringUtil.LTrimStr( A786CotDscto, 15, 2));
            A809CotSubTotal = (decimal)(A788CotSubAfecto+A790CotSubSelectivo-A786CotDscto);
            AssignAttri("", false, "A809CotSubTotal", StringUtil.LTrimStr( A809CotSubTotal, 15, 2));
            A801CotIVA = (decimal)((((A788CotSubAfecto+A790CotSubSelectivo-A786CotDscto)*A802CotPorIVA)/ (decimal)(100))+A803CotRedondeo);
            AssignAttri("", false, "A801CotIVA", StringUtil.LTrimStr( A801CotIVA, 15, 2));
            A811CotTotal = (decimal)((A787CotSubT-A786CotDscto)+A801CotIVA);
            AssignAttri("", false, "A811CotTotal", StringUtil.LTrimStr( A811CotTotal, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002I30 */
            pr_default.execute(24, new Object[] {A177CotCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel2I86( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2I86( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(23);
            context.CommitDataStores("clcotiza",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(23);
            context.RollbackDataStores("clcotiza",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2I86( )
      {
         /* Using cursor T002I31 */
         pr_default.execute(25);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound86 = 1;
            A177CotCod = T002I31_A177CotCod[0];
            AssignAttri("", false, "A177CotCod", A177CotCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2I86( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound86 = 1;
            A177CotCod = T002I31_A177CotCod[0];
            AssignAttri("", false, "A177CotCod", A177CotCod);
         }
      }

      protected void ScanEnd2I86( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm2I86( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2I86( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2I86( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2I86( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2I86( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2I86( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2I86( )
      {
         edtCotCod_Enabled = 0;
         AssignProp("", false, edtCotCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotCod_Enabled), 5, 0), true);
         edtCotFec_Enabled = 0;
         AssignProp("", false, edtCotFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotFec_Enabled), 5, 0), true);
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         edtCotConpCod_Enabled = 0;
         AssignProp("", false, edtCotConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotConpCod_Enabled), 5, 0), true);
         edtCotLista_Enabled = 0;
         AssignProp("", false, edtCotLista_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotLista_Enabled), 5, 0), true);
         edtCotRef_Enabled = 0;
         AssignProp("", false, edtCotRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotRef_Enabled), 5, 0), true);
         edtCotPorDsct_Enabled = 0;
         AssignProp("", false, edtCotPorDsct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotPorDsct_Enabled), 5, 0), true);
         edtCotPorIVA_Enabled = 0;
         AssignProp("", false, edtCotPorIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotPorIVA_Enabled), 5, 0), true);
         edtCotObs_Enabled = 0;
         AssignProp("", false, edtCotObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotObs_Enabled), 5, 0), true);
         edtCotTItem_Enabled = 0;
         AssignProp("", false, edtCotTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotTItem_Enabled), 5, 0), true);
         edtCotSts_Enabled = 0;
         AssignProp("", false, edtCotSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSts_Enabled), 5, 0), true);
         edtCotVendCod_Enabled = 0;
         AssignProp("", false, edtCotVendCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotVendCod_Enabled), 5, 0), true);
         edtCotUsuC_Enabled = 0;
         AssignProp("", false, edtCotUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotUsuC_Enabled), 5, 0), true);
         edtCotFecC_Enabled = 0;
         AssignProp("", false, edtCotFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotFecC_Enabled), 5, 0), true);
         edtCotUsuM_Enabled = 0;
         AssignProp("", false, edtCotUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotUsuM_Enabled), 5, 0), true);
         edtCotFecM_Enabled = 0;
         AssignProp("", false, edtCotFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotFecM_Enabled), 5, 0), true);
         edtCotPedCod_Enabled = 0;
         AssignProp("", false, edtCotPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotPedCod_Enabled), 5, 0), true);
         edtCotCliDespacho_Enabled = 0;
         AssignProp("", false, edtCotCliDespacho_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotCliDespacho_Enabled), 5, 0), true);
         edtCotImp_Enabled = 0;
         AssignProp("", false, edtCotImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotImp_Enabled), 5, 0), true);
         edtCotAIVA_Enabled = 0;
         AssignProp("", false, edtCotAIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotAIVA_Enabled), 5, 0), true);
         edtCotIVA_Enabled = 0;
         AssignProp("", false, edtCotIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotIVA_Enabled), 5, 0), true);
         edtCotRedondeo_Enabled = 0;
         AssignProp("", false, edtCotRedondeo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotRedondeo_Enabled), 5, 0), true);
         edtCotTotal_Enabled = 0;
         AssignProp("", false, edtCotTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotTotal_Enabled), 5, 0), true);
         edtCotSubAfecto_Enabled = 0;
         AssignProp("", false, edtCotSubAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubAfecto_Enabled), 5, 0), true);
         edtCotSubInafecto_Enabled = 0;
         AssignProp("", false, edtCotSubInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubInafecto_Enabled), 5, 0), true);
         edtCotSubSelectivo_Enabled = 0;
         AssignProp("", false, edtCotSubSelectivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubSelectivo_Enabled), 5, 0), true);
         edtCotSubExonerado_Enabled = 0;
         AssignProp("", false, edtCotSubExonerado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubExonerado_Enabled), 5, 0), true);
         edtCotSubGratuito_Enabled = 0;
         AssignProp("", false, edtCotSubGratuito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubGratuito_Enabled), 5, 0), true);
         edtCotSubT_Enabled = 0;
         AssignProp("", false, edtCotSubT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubT_Enabled), 5, 0), true);
         edtCotSubTotal_Enabled = 0;
         AssignProp("", false, edtCotSubTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSubTotal_Enabled), 5, 0), true);
         edtCotDscto_Enabled = 0;
         AssignProp("", false, edtCotDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDscto_Enabled), 5, 0), true);
         edtCotFecAten_Enabled = 0;
         AssignProp("", false, edtCotFecAten_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotFecAten_Enabled), 5, 0), true);
         edtTieCod_Enabled = 0;
         AssignProp("", false, edtTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2I86( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810244125", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clcotiza.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z177CotCod", StringUtil.RTrim( Z177CotCod));
         GxWebStd.gx_hidden_field( context, "Z796CotFec", context.localUtil.DToC( Z796CotFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z806CotRef", Z806CotRef);
         GxWebStd.gx_hidden_field( context, "Z794CotPorDsct", StringUtil.LTrim( StringUtil.NToC( Z794CotPorDsct, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z802CotPorIVA", StringUtil.LTrim( StringUtil.NToC( Z802CotPorIVA, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z810CotTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z810CotTItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z807CotSts", StringUtil.RTrim( Z807CotSts));
         GxWebStd.gx_hidden_field( context, "Z812CotUsuC", Z812CotUsuC);
         GxWebStd.gx_hidden_field( context, "Z798CotFecC", context.localUtil.TToC( Z798CotFecC, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z813CotUsuM", Z813CotUsuM);
         GxWebStd.gx_hidden_field( context, "Z799CotFecM", context.localUtil.TToC( Z799CotFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z805CotPedCod", StringUtil.RTrim( Z805CotPedCod));
         GxWebStd.gx_hidden_field( context, "Z764CotCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z764CotCliDespacho), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z800CotImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z800CotImp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z763CotAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z763CotAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z803CotRedondeo", StringUtil.LTrim( StringUtil.NToC( Z803CotRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z797CotFecAten", context.localUtil.DToC( Z797CotFecAten, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z182CotConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z182CotConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z181CotLista", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z181CotLista), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z179CotVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z179CotVendCod), 6, 0, ".", "")));
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
         return formatLink("clcotiza.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCOTIZA" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLCOTIZA" ;
      }

      protected void InitializeNonKey2I86( )
      {
         A787CotSubT = 0;
         AssignAttri("", false, "A787CotSubT", StringUtil.LTrimStr( A787CotSubT, 15, 2));
         A809CotSubTotal = 0;
         AssignAttri("", false, "A809CotSubTotal", StringUtil.LTrimStr( A809CotSubTotal, 15, 2));
         A811CotTotal = 0;
         AssignAttri("", false, "A811CotTotal", StringUtil.LTrimStr( A811CotTotal, 15, 2));
         A801CotIVA = 0;
         AssignAttri("", false, "A801CotIVA", StringUtil.LTrimStr( A801CotIVA, 15, 2));
         A786CotDscto = 0;
         AssignAttri("", false, "A786CotDscto", StringUtil.LTrimStr( A786CotDscto, 15, 2));
         A796CotFec = DateTime.MinValue;
         AssignAttri("", false, "A796CotFec", context.localUtil.Format(A796CotFec, "99/99/99"));
         A45CliCod = "";
         AssignAttri("", false, "A45CliCod", A45CliCod);
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         A182CotConpCod = 0;
         AssignAttri("", false, "A182CotConpCod", StringUtil.LTrimStr( (decimal)(A182CotConpCod), 6, 0));
         A181CotLista = 0;
         n181CotLista = false;
         AssignAttri("", false, "A181CotLista", StringUtil.LTrimStr( (decimal)(A181CotLista), 6, 0));
         n181CotLista = ((0==A181CotLista) ? true : false);
         A806CotRef = "";
         AssignAttri("", false, "A806CotRef", A806CotRef);
         A794CotPorDsct = 0;
         AssignAttri("", false, "A794CotPorDsct", StringUtil.LTrimStr( A794CotPorDsct, 6, 2));
         A802CotPorIVA = 0;
         AssignAttri("", false, "A802CotPorIVA", StringUtil.LTrimStr( A802CotPorIVA, 6, 2));
         A804CotObs = "";
         AssignAttri("", false, "A804CotObs", A804CotObs);
         A810CotTItem = 0;
         AssignAttri("", false, "A810CotTItem", StringUtil.LTrimStr( (decimal)(A810CotTItem), 4, 0));
         A807CotSts = "";
         AssignAttri("", false, "A807CotSts", A807CotSts);
         A179CotVendCod = 0;
         AssignAttri("", false, "A179CotVendCod", StringUtil.LTrimStr( (decimal)(A179CotVendCod), 6, 0));
         A812CotUsuC = "";
         AssignAttri("", false, "A812CotUsuC", A812CotUsuC);
         A798CotFecC = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A798CotFecC", context.localUtil.TToC( A798CotFecC, 8, 5, 0, 3, "/", ":", " "));
         A813CotUsuM = "";
         AssignAttri("", false, "A813CotUsuM", A813CotUsuM);
         A799CotFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A799CotFecM", context.localUtil.TToC( A799CotFecM, 8, 5, 0, 3, "/", ":", " "));
         A805CotPedCod = "";
         AssignAttri("", false, "A805CotPedCod", A805CotPedCod);
         A764CotCliDespacho = 0;
         AssignAttri("", false, "A764CotCliDespacho", StringUtil.LTrimStr( (decimal)(A764CotCliDespacho), 6, 0));
         A800CotImp = 0;
         AssignAttri("", false, "A800CotImp", StringUtil.Str( (decimal)(A800CotImp), 1, 0));
         A763CotAIVA = 0;
         AssignAttri("", false, "A763CotAIVA", StringUtil.Str( (decimal)(A763CotAIVA), 1, 0));
         A803CotRedondeo = 0;
         AssignAttri("", false, "A803CotRedondeo", StringUtil.LTrimStr( A803CotRedondeo, 15, 2));
         A788CotSubAfecto = 0;
         AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrimStr( A788CotSubAfecto, 15, 2));
         A789CotSubInafecto = 0;
         AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrimStr( A789CotSubInafecto, 15, 2));
         A790CotSubSelectivo = 0;
         AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrimStr( A790CotSubSelectivo, 15, 2));
         A793CotSubExonerado = 0;
         AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrimStr( A793CotSubExonerado, 15, 2));
         A808CotSubGratuito = 0;
         AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrimStr( A808CotSubGratuito, 15, 2));
         A797CotFecAten = DateTime.MinValue;
         AssignAttri("", false, "A797CotFecAten", context.localUtil.Format(A797CotFecAten, "99/99/99"));
         A178TieCod = 0;
         AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         Z796CotFec = DateTime.MinValue;
         Z806CotRef = "";
         Z794CotPorDsct = 0;
         Z802CotPorIVA = 0;
         Z810CotTItem = 0;
         Z807CotSts = "";
         Z812CotUsuC = "";
         Z798CotFecC = (DateTime)(DateTime.MinValue);
         Z813CotUsuM = "";
         Z799CotFecM = (DateTime)(DateTime.MinValue);
         Z805CotPedCod = "";
         Z764CotCliDespacho = 0;
         Z800CotImp = 0;
         Z763CotAIVA = 0;
         Z803CotRedondeo = 0;
         Z797CotFecAten = DateTime.MinValue;
         Z45CliCod = "";
         Z180MonCod = 0;
         Z178TieCod = 0;
         Z182CotConpCod = 0;
         Z181CotLista = 0;
         Z179CotVendCod = 0;
      }

      protected void InitAll2I86( )
      {
         A177CotCod = "";
         AssignAttri("", false, "A177CotCod", A177CotCod);
         InitializeNonKey2I86( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810244148", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("clcotiza.js", "?202281810244148", false, true);
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
         edtCotCod_Internalname = "COTCOD";
         edtCotFec_Internalname = "COTFEC";
         edtCliCod_Internalname = "CLICOD";
         edtMonCod_Internalname = "MONCOD";
         edtCotConpCod_Internalname = "COTCONPCOD";
         edtCotLista_Internalname = "COTLISTA";
         edtCotRef_Internalname = "COTREF";
         edtCotPorDsct_Internalname = "COTPORDSCT";
         edtCotPorIVA_Internalname = "COTPORIVA";
         edtCotObs_Internalname = "COTOBS";
         edtCotTItem_Internalname = "COTTITEM";
         edtCotSts_Internalname = "COTSTS";
         edtCotVendCod_Internalname = "COTVENDCOD";
         edtCotUsuC_Internalname = "COTUSUC";
         edtCotFecC_Internalname = "COTFECC";
         edtCotUsuM_Internalname = "COTUSUM";
         edtCotFecM_Internalname = "COTFECM";
         edtCotPedCod_Internalname = "COTPEDCOD";
         edtCotCliDespacho_Internalname = "COTCLIDESPACHO";
         edtCotImp_Internalname = "COTIMP";
         edtCotAIVA_Internalname = "COTAIVA";
         edtCotIVA_Internalname = "COTIVA";
         edtCotRedondeo_Internalname = "COTREDONDEO";
         edtCotTotal_Internalname = "COTTOTAL";
         edtCotSubAfecto_Internalname = "COTSUBAFECTO";
         edtCotSubInafecto_Internalname = "COTSUBINAFECTO";
         edtCotSubSelectivo_Internalname = "COTSUBSELECTIVO";
         edtCotSubExonerado_Internalname = "COTSUBEXONERADO";
         edtCotSubGratuito_Internalname = "COTSUBGRATUITO";
         edtCotSubT_Internalname = "COTSUBT";
         edtCotSubTotal_Internalname = "COTSUBTOTAL";
         edtCotDscto_Internalname = "COTDSCTO";
         edtCotFecAten_Internalname = "COTFECATEN";
         edtTieCod_Internalname = "TIECOD";
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
         Form.Caption = "CLCOTIZA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTieCod_Jsonclick = "";
         edtTieCod_Enabled = 1;
         edtCotFecAten_Jsonclick = "";
         edtCotFecAten_Enabled = 1;
         edtCotDscto_Jsonclick = "";
         edtCotDscto_Enabled = 0;
         edtCotSubTotal_Jsonclick = "";
         edtCotSubTotal_Enabled = 0;
         edtCotSubT_Jsonclick = "";
         edtCotSubT_Enabled = 0;
         edtCotSubGratuito_Jsonclick = "";
         edtCotSubGratuito_Enabled = 0;
         edtCotSubExonerado_Jsonclick = "";
         edtCotSubExonerado_Enabled = 0;
         edtCotSubSelectivo_Jsonclick = "";
         edtCotSubSelectivo_Enabled = 0;
         edtCotSubInafecto_Jsonclick = "";
         edtCotSubInafecto_Enabled = 0;
         edtCotSubAfecto_Jsonclick = "";
         edtCotSubAfecto_Enabled = 0;
         edtCotTotal_Jsonclick = "";
         edtCotTotal_Enabled = 0;
         edtCotRedondeo_Jsonclick = "";
         edtCotRedondeo_Enabled = 1;
         edtCotIVA_Jsonclick = "";
         edtCotIVA_Enabled = 0;
         edtCotAIVA_Jsonclick = "";
         edtCotAIVA_Enabled = 1;
         edtCotImp_Jsonclick = "";
         edtCotImp_Enabled = 1;
         edtCotCliDespacho_Jsonclick = "";
         edtCotCliDespacho_Enabled = 1;
         edtCotPedCod_Jsonclick = "";
         edtCotPedCod_Enabled = 1;
         edtCotFecM_Jsonclick = "";
         edtCotFecM_Enabled = 1;
         edtCotUsuM_Jsonclick = "";
         edtCotUsuM_Enabled = 1;
         edtCotFecC_Jsonclick = "";
         edtCotFecC_Enabled = 1;
         edtCotUsuC_Jsonclick = "";
         edtCotUsuC_Enabled = 1;
         edtCotVendCod_Jsonclick = "";
         edtCotVendCod_Enabled = 1;
         edtCotSts_Jsonclick = "";
         edtCotSts_Enabled = 1;
         edtCotTItem_Jsonclick = "";
         edtCotTItem_Enabled = 1;
         edtCotObs_Enabled = 1;
         edtCotPorIVA_Jsonclick = "";
         edtCotPorIVA_Enabled = 1;
         edtCotPorDsct_Jsonclick = "";
         edtCotPorDsct_Enabled = 1;
         edtCotRef_Jsonclick = "";
         edtCotRef_Enabled = 1;
         edtCotLista_Jsonclick = "";
         edtCotLista_Enabled = 1;
         edtCotConpCod_Jsonclick = "";
         edtCotConpCod_Enabled = 1;
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
         edtCotFec_Jsonclick = "";
         edtCotFec_Enabled = 1;
         edtCotCod_Jsonclick = "";
         edtCotCod_Enabled = 1;
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
         GX_FocusControl = edtCotFec_Internalname;
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

      public void Valid_Cotcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002I29 */
         pr_default.execute(23, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A788CotSubAfecto = T002I29_A788CotSubAfecto[0];
            A789CotSubInafecto = T002I29_A789CotSubInafecto[0];
            A790CotSubSelectivo = T002I29_A790CotSubSelectivo[0];
            A793CotSubExonerado = T002I29_A793CotSubExonerado[0];
            A808CotSubGratuito = T002I29_A808CotSubGratuito[0];
         }
         else
         {
            A788CotSubAfecto = 0;
            A789CotSubInafecto = 0;
            A790CotSubSelectivo = 0;
            A793CotSubExonerado = 0;
            A808CotSubGratuito = 0;
         }
         pr_default.close(23);
         A787CotSubT = (decimal)(A788CotSubAfecto+A789CotSubInafecto+A790CotSubSelectivo+A793CotSubExonerado);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A796CotFec", context.localUtil.Format(A796CotFec, "99/99/99"));
         AssignAttri("", false, "A45CliCod", StringUtil.RTrim( A45CliCod));
         AssignAttri("", false, "A180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A182CotConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A182CotConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A181CotLista", StringUtil.LTrim( StringUtil.NToC( (decimal)(A181CotLista), 6, 0, ".", "")));
         AssignAttri("", false, "A806CotRef", A806CotRef);
         AssignAttri("", false, "A794CotPorDsct", StringUtil.LTrim( StringUtil.NToC( A794CotPorDsct, 6, 2, ".", "")));
         AssignAttri("", false, "A802CotPorIVA", StringUtil.LTrim( StringUtil.NToC( A802CotPorIVA, 6, 2, ".", "")));
         AssignAttri("", false, "A804CotObs", A804CotObs);
         AssignAttri("", false, "A810CotTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A810CotTItem), 4, 0, ".", "")));
         AssignAttri("", false, "A807CotSts", StringUtil.RTrim( A807CotSts));
         AssignAttri("", false, "A179CotVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A179CotVendCod), 6, 0, ".", "")));
         AssignAttri("", false, "A812CotUsuC", A812CotUsuC);
         AssignAttri("", false, "A798CotFecC", context.localUtil.TToC( A798CotFecC, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A813CotUsuM", A813CotUsuM);
         AssignAttri("", false, "A799CotFecM", context.localUtil.TToC( A799CotFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A805CotPedCod", StringUtil.RTrim( A805CotPedCod));
         AssignAttri("", false, "A764CotCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(A764CotCliDespacho), 6, 0, ".", "")));
         AssignAttri("", false, "A800CotImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A800CotImp), 1, 0, ".", "")));
         AssignAttri("", false, "A763CotAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A763CotAIVA), 1, 0, ".", "")));
         AssignAttri("", false, "A803CotRedondeo", StringUtil.LTrim( StringUtil.NToC( A803CotRedondeo, 15, 2, ".", "")));
         AssignAttri("", false, "A797CotFecAten", context.localUtil.Format(A797CotFecAten, "99/99/99"));
         AssignAttri("", false, "A178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")));
         AssignAttri("", false, "A788CotSubAfecto", StringUtil.LTrim( StringUtil.NToC( A788CotSubAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A789CotSubInafecto", StringUtil.LTrim( StringUtil.NToC( A789CotSubInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A790CotSubSelectivo", StringUtil.LTrim( StringUtil.NToC( A790CotSubSelectivo, 15, 2, ".", "")));
         AssignAttri("", false, "A793CotSubExonerado", StringUtil.LTrim( StringUtil.NToC( A793CotSubExonerado, 15, 2, ".", "")));
         AssignAttri("", false, "A808CotSubGratuito", StringUtil.LTrim( StringUtil.NToC( A808CotSubGratuito, 15, 2, ".", "")));
         AssignAttri("", false, "A787CotSubT", StringUtil.LTrim( StringUtil.NToC( A787CotSubT, 15, 2, ".", "")));
         AssignAttri("", false, "A786CotDscto", StringUtil.LTrim( StringUtil.NToC( A786CotDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A801CotIVA", StringUtil.LTrim( StringUtil.NToC( A801CotIVA, 15, 2, ".", "")));
         AssignAttri("", false, "A809CotSubTotal", StringUtil.LTrim( StringUtil.NToC( A809CotSubTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A811CotTotal", StringUtil.LTrim( StringUtil.NToC( A811CotTotal, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z177CotCod", StringUtil.RTrim( Z177CotCod));
         GxWebStd.gx_hidden_field( context, "Z796CotFec", context.localUtil.Format(Z796CotFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z182CotConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z182CotConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z181CotLista", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z181CotLista), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z806CotRef", Z806CotRef);
         GxWebStd.gx_hidden_field( context, "Z794CotPorDsct", StringUtil.LTrim( StringUtil.NToC( Z794CotPorDsct, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z802CotPorIVA", StringUtil.LTrim( StringUtil.NToC( Z802CotPorIVA, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z804CotObs", Z804CotObs);
         GxWebStd.gx_hidden_field( context, "Z810CotTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z810CotTItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z807CotSts", StringUtil.RTrim( Z807CotSts));
         GxWebStd.gx_hidden_field( context, "Z179CotVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z179CotVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z812CotUsuC", Z812CotUsuC);
         GxWebStd.gx_hidden_field( context, "Z798CotFecC", context.localUtil.TToC( Z798CotFecC, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z813CotUsuM", Z813CotUsuM);
         GxWebStd.gx_hidden_field( context, "Z799CotFecM", context.localUtil.TToC( Z799CotFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z805CotPedCod", StringUtil.RTrim( Z805CotPedCod));
         GxWebStd.gx_hidden_field( context, "Z764CotCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z764CotCliDespacho), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z800CotImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z800CotImp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z763CotAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z763CotAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z803CotRedondeo", StringUtil.LTrim( StringUtil.NToC( Z803CotRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z797CotFecAten", context.localUtil.Format(Z797CotFecAten, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z788CotSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z788CotSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z789CotSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z789CotSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z790CotSubSelectivo", StringUtil.LTrim( StringUtil.NToC( Z790CotSubSelectivo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z793CotSubExonerado", StringUtil.LTrim( StringUtil.NToC( Z793CotSubExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z808CotSubGratuito", StringUtil.LTrim( StringUtil.NToC( Z808CotSubGratuito, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z787CotSubT", StringUtil.LTrim( StringUtil.NToC( Z787CotSubT, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z786CotDscto", StringUtil.LTrim( StringUtil.NToC( Z786CotDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z801CotIVA", StringUtil.LTrim( StringUtil.NToC( Z801CotIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z809CotSubTotal", StringUtil.LTrim( StringUtil.NToC( Z809CotSubTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z811CotTotal", StringUtil.LTrim( StringUtil.NToC( Z811CotTotal, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clicod( )
      {
         /* Using cursor T002I32 */
         pr_default.execute(26, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
         }
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Moncod( )
      {
         /* Using cursor T002I33 */
         pr_default.execute(27, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cotconpcod( )
      {
         /* Using cursor T002I34 */
         pr_default.execute(28, new Object[] {A182CotConpCod});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion de Pago'.", "ForeignKeyNotFound", 1, "COTCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtCotConpCod_Internalname;
         }
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cotlista( )
      {
         n181CotLista = false;
         /* Using cursor T002I35 */
         pr_default.execute(29, new Object[] {n181CotLista, A181CotLista});
         if ( (pr_default.getStatus(29) == 101) )
         {
            if ( ! ( (0==A181CotLista) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "COTLISTA");
               AnyError = 1;
               GX_FocusControl = edtCotLista_Internalname;
            }
         }
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cotvendcod( )
      {
         /* Using cursor T002I36 */
         pr_default.execute(30, new Object[] {A179CotVendCod});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "COTVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCotVendCod_Internalname;
         }
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tiecod( )
      {
         /* Using cursor T002I37 */
         pr_default.execute(31, new Object[] {A178TieCod});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No existe 'Tiendas'.", "ForeignKeyNotFound", 1, "TIECOD");
            AnyError = 1;
            GX_FocusControl = edtTieCod_Internalname;
         }
         pr_default.close(31);
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
         setEventMetadata("VALID_COTCOD","{handler:'Valid_Cotcod',iparms:[{av:'A177CotCod',fld:'COTCOD',pic:''},{av:'A788CotSubAfecto',fld:'COTSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A789CotSubInafecto',fld:'COTSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A790CotSubSelectivo',fld:'COTSUBSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A793CotSubExonerado',fld:'COTSUBEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COTCOD",",oparms:[{av:'A796CotFec',fld:'COTFEC',pic:''},{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A182CotConpCod',fld:'COTCONPCOD',pic:'ZZZZZ9'},{av:'A181CotLista',fld:'COTLISTA',pic:'ZZZZZ9'},{av:'A806CotRef',fld:'COTREF',pic:''},{av:'A794CotPorDsct',fld:'COTPORDSCT',pic:'ZZ9.99'},{av:'A802CotPorIVA',fld:'COTPORIVA',pic:'ZZ9.99'},{av:'A804CotObs',fld:'COTOBS',pic:''},{av:'A810CotTItem',fld:'COTTITEM',pic:'ZZZ9'},{av:'A807CotSts',fld:'COTSTS',pic:''},{av:'A179CotVendCod',fld:'COTVENDCOD',pic:'ZZZZZ9'},{av:'A812CotUsuC',fld:'COTUSUC',pic:''},{av:'A798CotFecC',fld:'COTFECC',pic:'99/99/99 99:99'},{av:'A813CotUsuM',fld:'COTUSUM',pic:''},{av:'A799CotFecM',fld:'COTFECM',pic:'99/99/99 99:99'},{av:'A805CotPedCod',fld:'COTPEDCOD',pic:''},{av:'A764CotCliDespacho',fld:'COTCLIDESPACHO',pic:'ZZZZZ9'},{av:'A800CotImp',fld:'COTIMP',pic:'9'},{av:'A763CotAIVA',fld:'COTAIVA',pic:'9'},{av:'A803CotRedondeo',fld:'COTREDONDEO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A797CotFecAten',fld:'COTFECATEN',pic:''},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'A788CotSubAfecto',fld:'COTSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A789CotSubInafecto',fld:'COTSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A790CotSubSelectivo',fld:'COTSUBSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A793CotSubExonerado',fld:'COTSUBEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A808CotSubGratuito',fld:'COTSUBGRATUITO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A787CotSubT',fld:'COTSUBT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A786CotDscto',fld:'COTDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A801CotIVA',fld:'COTIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A809CotSubTotal',fld:'COTSUBTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A811CotTotal',fld:'COTTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z177CotCod'},{av:'Z796CotFec'},{av:'Z45CliCod'},{av:'Z180MonCod'},{av:'Z182CotConpCod'},{av:'Z181CotLista'},{av:'Z806CotRef'},{av:'Z794CotPorDsct'},{av:'Z802CotPorIVA'},{av:'Z804CotObs'},{av:'Z810CotTItem'},{av:'Z807CotSts'},{av:'Z179CotVendCod'},{av:'Z812CotUsuC'},{av:'Z798CotFecC'},{av:'Z813CotUsuM'},{av:'Z799CotFecM'},{av:'Z805CotPedCod'},{av:'Z764CotCliDespacho'},{av:'Z800CotImp'},{av:'Z763CotAIVA'},{av:'Z803CotRedondeo'},{av:'Z797CotFecAten'},{av:'Z178TieCod'},{av:'Z788CotSubAfecto'},{av:'Z789CotSubInafecto'},{av:'Z790CotSubSelectivo'},{av:'Z793CotSubExonerado'},{av:'Z808CotSubGratuito'},{av:'Z787CotSubT'},{av:'Z786CotDscto'},{av:'Z801CotIVA'},{av:'Z809CotSubTotal'},{av:'Z811CotTotal'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_COTFEC","{handler:'Valid_Cotfec',iparms:[]");
         setEventMetadata("VALID_COTFEC",",oparms:[]}");
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[]}");
         setEventMetadata("VALID_COTCONPCOD","{handler:'Valid_Cotconpcod',iparms:[{av:'A182CotConpCod',fld:'COTCONPCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COTCONPCOD",",oparms:[]}");
         setEventMetadata("VALID_COTLISTA","{handler:'Valid_Cotlista',iparms:[{av:'A181CotLista',fld:'COTLISTA',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COTLISTA",",oparms:[]}");
         setEventMetadata("VALID_COTPORDSCT","{handler:'Valid_Cotpordsct',iparms:[]");
         setEventMetadata("VALID_COTPORDSCT",",oparms:[]}");
         setEventMetadata("VALID_COTPORIVA","{handler:'Valid_Cotporiva',iparms:[]");
         setEventMetadata("VALID_COTPORIVA",",oparms:[]}");
         setEventMetadata("VALID_COTVENDCOD","{handler:'Valid_Cotvendcod',iparms:[{av:'A179CotVendCod',fld:'COTVENDCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COTVENDCOD",",oparms:[]}");
         setEventMetadata("VALID_COTFECC","{handler:'Valid_Cotfecc',iparms:[]");
         setEventMetadata("VALID_COTFECC",",oparms:[]}");
         setEventMetadata("VALID_COTFECM","{handler:'Valid_Cotfecm',iparms:[]");
         setEventMetadata("VALID_COTFECM",",oparms:[]}");
         setEventMetadata("VALID_COTIVA","{handler:'Valid_Cotiva',iparms:[]");
         setEventMetadata("VALID_COTIVA",",oparms:[]}");
         setEventMetadata("VALID_COTREDONDEO","{handler:'Valid_Cotredondeo',iparms:[]");
         setEventMetadata("VALID_COTREDONDEO",",oparms:[]}");
         setEventMetadata("VALID_COTSUBAFECTO","{handler:'Valid_Cotsubafecto',iparms:[]");
         setEventMetadata("VALID_COTSUBAFECTO",",oparms:[]}");
         setEventMetadata("VALID_COTSUBINAFECTO","{handler:'Valid_Cotsubinafecto',iparms:[]");
         setEventMetadata("VALID_COTSUBINAFECTO",",oparms:[]}");
         setEventMetadata("VALID_COTSUBSELECTIVO","{handler:'Valid_Cotsubselectivo',iparms:[]");
         setEventMetadata("VALID_COTSUBSELECTIVO",",oparms:[]}");
         setEventMetadata("VALID_COTSUBEXONERADO","{handler:'Valid_Cotsubexonerado',iparms:[]");
         setEventMetadata("VALID_COTSUBEXONERADO",",oparms:[]}");
         setEventMetadata("VALID_COTSUBT","{handler:'Valid_Cotsubt',iparms:[]");
         setEventMetadata("VALID_COTSUBT",",oparms:[]}");
         setEventMetadata("VALID_COTDSCTO","{handler:'Valid_Cotdscto',iparms:[]");
         setEventMetadata("VALID_COTDSCTO",",oparms:[]}");
         setEventMetadata("VALID_COTFECATEN","{handler:'Valid_Cotfecaten',iparms:[]");
         setEventMetadata("VALID_COTFECATEN",",oparms:[]}");
         setEventMetadata("VALID_TIECOD","{handler:'Valid_Tiecod',iparms:[{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIECOD",",oparms:[]}");
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
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(31);
         pr_default.close(28);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z177CotCod = "";
         Z796CotFec = DateTime.MinValue;
         Z806CotRef = "";
         Z807CotSts = "";
         Z812CotUsuC = "";
         Z798CotFecC = (DateTime)(DateTime.MinValue);
         Z813CotUsuM = "";
         Z799CotFecM = (DateTime)(DateTime.MinValue);
         Z805CotPedCod = "";
         Z797CotFecAten = DateTime.MinValue;
         Z45CliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A177CotCod = "";
         A45CliCod = "";
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
         A796CotFec = DateTime.MinValue;
         A806CotRef = "";
         A804CotObs = "";
         A807CotSts = "";
         A812CotUsuC = "";
         A798CotFecC = (DateTime)(DateTime.MinValue);
         A813CotUsuM = "";
         A799CotFecM = (DateTime)(DateTime.MinValue);
         A805CotPedCod = "";
         A797CotFecAten = DateTime.MinValue;
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
         Z804CotObs = "";
         T002I13_A177CotCod = new string[] {""} ;
         T002I13_A796CotFec = new DateTime[] {DateTime.MinValue} ;
         T002I13_A806CotRef = new string[] {""} ;
         T002I13_A794CotPorDsct = new decimal[1] ;
         T002I13_A802CotPorIVA = new decimal[1] ;
         T002I13_A804CotObs = new string[] {""} ;
         T002I13_A810CotTItem = new short[1] ;
         T002I13_A807CotSts = new string[] {""} ;
         T002I13_A812CotUsuC = new string[] {""} ;
         T002I13_A798CotFecC = new DateTime[] {DateTime.MinValue} ;
         T002I13_A813CotUsuM = new string[] {""} ;
         T002I13_A799CotFecM = new DateTime[] {DateTime.MinValue} ;
         T002I13_A805CotPedCod = new string[] {""} ;
         T002I13_A764CotCliDespacho = new int[1] ;
         T002I13_A800CotImp = new short[1] ;
         T002I13_A763CotAIVA = new short[1] ;
         T002I13_A803CotRedondeo = new decimal[1] ;
         T002I13_A797CotFecAten = new DateTime[] {DateTime.MinValue} ;
         T002I13_A45CliCod = new string[] {""} ;
         T002I13_A180MonCod = new int[1] ;
         T002I13_A178TieCod = new int[1] ;
         T002I13_A182CotConpCod = new int[1] ;
         T002I13_A181CotLista = new int[1] ;
         T002I13_n181CotLista = new bool[] {false} ;
         T002I13_A179CotVendCod = new int[1] ;
         T002I13_A788CotSubAfecto = new decimal[1] ;
         T002I13_A789CotSubInafecto = new decimal[1] ;
         T002I13_A790CotSubSelectivo = new decimal[1] ;
         T002I13_A793CotSubExonerado = new decimal[1] ;
         T002I13_A808CotSubGratuito = new decimal[1] ;
         T002I11_A788CotSubAfecto = new decimal[1] ;
         T002I11_A789CotSubInafecto = new decimal[1] ;
         T002I11_A790CotSubSelectivo = new decimal[1] ;
         T002I11_A793CotSubExonerado = new decimal[1] ;
         T002I11_A808CotSubGratuito = new decimal[1] ;
         T002I4_A45CliCod = new string[] {""} ;
         T002I5_A180MonCod = new int[1] ;
         T002I7_A182CotConpCod = new int[1] ;
         T002I8_A181CotLista = new int[1] ;
         T002I8_n181CotLista = new bool[] {false} ;
         T002I9_A179CotVendCod = new int[1] ;
         T002I6_A178TieCod = new int[1] ;
         T002I15_A788CotSubAfecto = new decimal[1] ;
         T002I15_A789CotSubInafecto = new decimal[1] ;
         T002I15_A790CotSubSelectivo = new decimal[1] ;
         T002I15_A793CotSubExonerado = new decimal[1] ;
         T002I15_A808CotSubGratuito = new decimal[1] ;
         T002I16_A45CliCod = new string[] {""} ;
         T002I17_A180MonCod = new int[1] ;
         T002I18_A182CotConpCod = new int[1] ;
         T002I19_A181CotLista = new int[1] ;
         T002I19_n181CotLista = new bool[] {false} ;
         T002I20_A179CotVendCod = new int[1] ;
         T002I21_A178TieCod = new int[1] ;
         T002I22_A177CotCod = new string[] {""} ;
         T002I3_A177CotCod = new string[] {""} ;
         T002I3_A796CotFec = new DateTime[] {DateTime.MinValue} ;
         T002I3_A806CotRef = new string[] {""} ;
         T002I3_A794CotPorDsct = new decimal[1] ;
         T002I3_A802CotPorIVA = new decimal[1] ;
         T002I3_A804CotObs = new string[] {""} ;
         T002I3_A810CotTItem = new short[1] ;
         T002I3_A807CotSts = new string[] {""} ;
         T002I3_A812CotUsuC = new string[] {""} ;
         T002I3_A798CotFecC = new DateTime[] {DateTime.MinValue} ;
         T002I3_A813CotUsuM = new string[] {""} ;
         T002I3_A799CotFecM = new DateTime[] {DateTime.MinValue} ;
         T002I3_A805CotPedCod = new string[] {""} ;
         T002I3_A764CotCliDespacho = new int[1] ;
         T002I3_A800CotImp = new short[1] ;
         T002I3_A763CotAIVA = new short[1] ;
         T002I3_A803CotRedondeo = new decimal[1] ;
         T002I3_A797CotFecAten = new DateTime[] {DateTime.MinValue} ;
         T002I3_A45CliCod = new string[] {""} ;
         T002I3_A180MonCod = new int[1] ;
         T002I3_A178TieCod = new int[1] ;
         T002I3_A182CotConpCod = new int[1] ;
         T002I3_A181CotLista = new int[1] ;
         T002I3_n181CotLista = new bool[] {false} ;
         T002I3_A179CotVendCod = new int[1] ;
         sMode86 = "";
         T002I23_A177CotCod = new string[] {""} ;
         T002I24_A177CotCod = new string[] {""} ;
         T002I2_A177CotCod = new string[] {""} ;
         T002I2_A796CotFec = new DateTime[] {DateTime.MinValue} ;
         T002I2_A806CotRef = new string[] {""} ;
         T002I2_A794CotPorDsct = new decimal[1] ;
         T002I2_A802CotPorIVA = new decimal[1] ;
         T002I2_A804CotObs = new string[] {""} ;
         T002I2_A810CotTItem = new short[1] ;
         T002I2_A807CotSts = new string[] {""} ;
         T002I2_A812CotUsuC = new string[] {""} ;
         T002I2_A798CotFecC = new DateTime[] {DateTime.MinValue} ;
         T002I2_A813CotUsuM = new string[] {""} ;
         T002I2_A799CotFecM = new DateTime[] {DateTime.MinValue} ;
         T002I2_A805CotPedCod = new string[] {""} ;
         T002I2_A764CotCliDespacho = new int[1] ;
         T002I2_A800CotImp = new short[1] ;
         T002I2_A763CotAIVA = new short[1] ;
         T002I2_A803CotRedondeo = new decimal[1] ;
         T002I2_A797CotFecAten = new DateTime[] {DateTime.MinValue} ;
         T002I2_A45CliCod = new string[] {""} ;
         T002I2_A180MonCod = new int[1] ;
         T002I2_A178TieCod = new int[1] ;
         T002I2_A182CotConpCod = new int[1] ;
         T002I2_A181CotLista = new int[1] ;
         T002I2_n181CotLista = new bool[] {false} ;
         T002I2_A179CotVendCod = new int[1] ;
         T002I29_A788CotSubAfecto = new decimal[1] ;
         T002I29_A789CotSubInafecto = new decimal[1] ;
         T002I29_A790CotSubSelectivo = new decimal[1] ;
         T002I29_A793CotSubExonerado = new decimal[1] ;
         T002I29_A808CotSubGratuito = new decimal[1] ;
         T002I30_A177CotCod = new string[] {""} ;
         T002I30_A183CotDItem = new short[1] ;
         T002I31_A177CotCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ177CotCod = "";
         ZZ796CotFec = DateTime.MinValue;
         ZZ45CliCod = "";
         ZZ806CotRef = "";
         ZZ804CotObs = "";
         ZZ807CotSts = "";
         ZZ812CotUsuC = "";
         ZZ798CotFecC = (DateTime)(DateTime.MinValue);
         ZZ813CotUsuM = "";
         ZZ799CotFecM = (DateTime)(DateTime.MinValue);
         ZZ805CotPedCod = "";
         ZZ797CotFecAten = DateTime.MinValue;
         T002I32_A45CliCod = new string[] {""} ;
         T002I33_A180MonCod = new int[1] ;
         T002I34_A182CotConpCod = new int[1] ;
         T002I35_A181CotLista = new int[1] ;
         T002I35_n181CotLista = new bool[] {false} ;
         T002I36_A179CotVendCod = new int[1] ;
         T002I37_A178TieCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clcotiza__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clcotiza__default(),
            new Object[][] {
                new Object[] {
               T002I2_A177CotCod, T002I2_A796CotFec, T002I2_A806CotRef, T002I2_A794CotPorDsct, T002I2_A802CotPorIVA, T002I2_A804CotObs, T002I2_A810CotTItem, T002I2_A807CotSts, T002I2_A812CotUsuC, T002I2_A798CotFecC,
               T002I2_A813CotUsuM, T002I2_A799CotFecM, T002I2_A805CotPedCod, T002I2_A764CotCliDespacho, T002I2_A800CotImp, T002I2_A763CotAIVA, T002I2_A803CotRedondeo, T002I2_A797CotFecAten, T002I2_A45CliCod, T002I2_A180MonCod,
               T002I2_A178TieCod, T002I2_A182CotConpCod, T002I2_A181CotLista, T002I2_n181CotLista, T002I2_A179CotVendCod
               }
               , new Object[] {
               T002I3_A177CotCod, T002I3_A796CotFec, T002I3_A806CotRef, T002I3_A794CotPorDsct, T002I3_A802CotPorIVA, T002I3_A804CotObs, T002I3_A810CotTItem, T002I3_A807CotSts, T002I3_A812CotUsuC, T002I3_A798CotFecC,
               T002I3_A813CotUsuM, T002I3_A799CotFecM, T002I3_A805CotPedCod, T002I3_A764CotCliDespacho, T002I3_A800CotImp, T002I3_A763CotAIVA, T002I3_A803CotRedondeo, T002I3_A797CotFecAten, T002I3_A45CliCod, T002I3_A180MonCod,
               T002I3_A178TieCod, T002I3_A182CotConpCod, T002I3_A181CotLista, T002I3_n181CotLista, T002I3_A179CotVendCod
               }
               , new Object[] {
               T002I4_A45CliCod
               }
               , new Object[] {
               T002I5_A180MonCod
               }
               , new Object[] {
               T002I6_A178TieCod
               }
               , new Object[] {
               T002I7_A182CotConpCod
               }
               , new Object[] {
               T002I8_A181CotLista
               }
               , new Object[] {
               T002I9_A179CotVendCod
               }
               , new Object[] {
               T002I11_A788CotSubAfecto, T002I11_A789CotSubInafecto, T002I11_A790CotSubSelectivo, T002I11_A793CotSubExonerado, T002I11_A808CotSubGratuito
               }
               , new Object[] {
               T002I13_A177CotCod, T002I13_A796CotFec, T002I13_A806CotRef, T002I13_A794CotPorDsct, T002I13_A802CotPorIVA, T002I13_A804CotObs, T002I13_A810CotTItem, T002I13_A807CotSts, T002I13_A812CotUsuC, T002I13_A798CotFecC,
               T002I13_A813CotUsuM, T002I13_A799CotFecM, T002I13_A805CotPedCod, T002I13_A764CotCliDespacho, T002I13_A800CotImp, T002I13_A763CotAIVA, T002I13_A803CotRedondeo, T002I13_A797CotFecAten, T002I13_A45CliCod, T002I13_A180MonCod,
               T002I13_A178TieCod, T002I13_A182CotConpCod, T002I13_A181CotLista, T002I13_n181CotLista, T002I13_A179CotVendCod, T002I13_A788CotSubAfecto, T002I13_A789CotSubInafecto, T002I13_A790CotSubSelectivo, T002I13_A793CotSubExonerado, T002I13_A808CotSubGratuito
               }
               , new Object[] {
               T002I15_A788CotSubAfecto, T002I15_A789CotSubInafecto, T002I15_A790CotSubSelectivo, T002I15_A793CotSubExonerado, T002I15_A808CotSubGratuito
               }
               , new Object[] {
               T002I16_A45CliCod
               }
               , new Object[] {
               T002I17_A180MonCod
               }
               , new Object[] {
               T002I18_A182CotConpCod
               }
               , new Object[] {
               T002I19_A181CotLista
               }
               , new Object[] {
               T002I20_A179CotVendCod
               }
               , new Object[] {
               T002I21_A178TieCod
               }
               , new Object[] {
               T002I22_A177CotCod
               }
               , new Object[] {
               T002I23_A177CotCod
               }
               , new Object[] {
               T002I24_A177CotCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002I29_A788CotSubAfecto, T002I29_A789CotSubInafecto, T002I29_A790CotSubSelectivo, T002I29_A793CotSubExonerado, T002I29_A808CotSubGratuito
               }
               , new Object[] {
               T002I30_A177CotCod, T002I30_A183CotDItem
               }
               , new Object[] {
               T002I31_A177CotCod
               }
               , new Object[] {
               T002I32_A45CliCod
               }
               , new Object[] {
               T002I33_A180MonCod
               }
               , new Object[] {
               T002I34_A182CotConpCod
               }
               , new Object[] {
               T002I35_A181CotLista
               }
               , new Object[] {
               T002I36_A179CotVendCod
               }
               , new Object[] {
               T002I37_A178TieCod
               }
            }
         );
      }

      private short Z810CotTItem ;
      private short Z800CotImp ;
      private short Z763CotAIVA ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A810CotTItem ;
      private short A800CotImp ;
      private short A763CotAIVA ;
      private short GX_JID ;
      private short RcdFound86 ;
      private short nIsDirty_86 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ810CotTItem ;
      private short ZZ800CotImp ;
      private short ZZ763CotAIVA ;
      private int Z764CotCliDespacho ;
      private int Z180MonCod ;
      private int Z178TieCod ;
      private int Z182CotConpCod ;
      private int Z181CotLista ;
      private int Z179CotVendCod ;
      private int A180MonCod ;
      private int A182CotConpCod ;
      private int A181CotLista ;
      private int A179CotVendCod ;
      private int A178TieCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCotCod_Enabled ;
      private int edtCotFec_Enabled ;
      private int edtCliCod_Enabled ;
      private int edtMonCod_Enabled ;
      private int edtCotConpCod_Enabled ;
      private int edtCotLista_Enabled ;
      private int edtCotRef_Enabled ;
      private int edtCotPorDsct_Enabled ;
      private int edtCotPorIVA_Enabled ;
      private int edtCotObs_Enabled ;
      private int edtCotTItem_Enabled ;
      private int edtCotSts_Enabled ;
      private int edtCotVendCod_Enabled ;
      private int edtCotUsuC_Enabled ;
      private int edtCotFecC_Enabled ;
      private int edtCotUsuM_Enabled ;
      private int edtCotFecM_Enabled ;
      private int edtCotPedCod_Enabled ;
      private int A764CotCliDespacho ;
      private int edtCotCliDespacho_Enabled ;
      private int edtCotImp_Enabled ;
      private int edtCotAIVA_Enabled ;
      private int edtCotIVA_Enabled ;
      private int edtCotRedondeo_Enabled ;
      private int edtCotTotal_Enabled ;
      private int edtCotSubAfecto_Enabled ;
      private int edtCotSubInafecto_Enabled ;
      private int edtCotSubSelectivo_Enabled ;
      private int edtCotSubExonerado_Enabled ;
      private int edtCotSubGratuito_Enabled ;
      private int edtCotSubT_Enabled ;
      private int edtCotSubTotal_Enabled ;
      private int edtCotDscto_Enabled ;
      private int edtCotFecAten_Enabled ;
      private int edtTieCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ180MonCod ;
      private int ZZ182CotConpCod ;
      private int ZZ181CotLista ;
      private int ZZ179CotVendCod ;
      private int ZZ764CotCliDespacho ;
      private int ZZ178TieCod ;
      private decimal Z794CotPorDsct ;
      private decimal Z802CotPorIVA ;
      private decimal Z803CotRedondeo ;
      private decimal A794CotPorDsct ;
      private decimal A802CotPorIVA ;
      private decimal A801CotIVA ;
      private decimal A803CotRedondeo ;
      private decimal A811CotTotal ;
      private decimal A788CotSubAfecto ;
      private decimal A789CotSubInafecto ;
      private decimal A790CotSubSelectivo ;
      private decimal A793CotSubExonerado ;
      private decimal A808CotSubGratuito ;
      private decimal A787CotSubT ;
      private decimal A809CotSubTotal ;
      private decimal A786CotDscto ;
      private decimal Z788CotSubAfecto ;
      private decimal Z789CotSubInafecto ;
      private decimal Z790CotSubSelectivo ;
      private decimal Z793CotSubExonerado ;
      private decimal Z808CotSubGratuito ;
      private decimal Z787CotSubT ;
      private decimal Z786CotDscto ;
      private decimal Z801CotIVA ;
      private decimal Z809CotSubTotal ;
      private decimal Z811CotTotal ;
      private decimal ZZ794CotPorDsct ;
      private decimal ZZ802CotPorIVA ;
      private decimal ZZ803CotRedondeo ;
      private decimal ZZ788CotSubAfecto ;
      private decimal ZZ789CotSubInafecto ;
      private decimal ZZ790CotSubSelectivo ;
      private decimal ZZ793CotSubExonerado ;
      private decimal ZZ808CotSubGratuito ;
      private decimal ZZ787CotSubT ;
      private decimal ZZ786CotDscto ;
      private decimal ZZ801CotIVA ;
      private decimal ZZ809CotSubTotal ;
      private decimal ZZ811CotTotal ;
      private string sPrefix ;
      private string Z177CotCod ;
      private string Z807CotSts ;
      private string Z805CotPedCod ;
      private string Z45CliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A177CotCod ;
      private string A45CliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCotCod_Internalname ;
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
      private string edtCotCod_Jsonclick ;
      private string edtCotFec_Internalname ;
      private string edtCotFec_Jsonclick ;
      private string edtCliCod_Internalname ;
      private string edtCliCod_Jsonclick ;
      private string edtMonCod_Internalname ;
      private string edtMonCod_Jsonclick ;
      private string edtCotConpCod_Internalname ;
      private string edtCotConpCod_Jsonclick ;
      private string edtCotLista_Internalname ;
      private string edtCotLista_Jsonclick ;
      private string edtCotRef_Internalname ;
      private string edtCotRef_Jsonclick ;
      private string edtCotPorDsct_Internalname ;
      private string edtCotPorDsct_Jsonclick ;
      private string edtCotPorIVA_Internalname ;
      private string edtCotPorIVA_Jsonclick ;
      private string edtCotObs_Internalname ;
      private string edtCotTItem_Internalname ;
      private string edtCotTItem_Jsonclick ;
      private string edtCotSts_Internalname ;
      private string A807CotSts ;
      private string edtCotSts_Jsonclick ;
      private string edtCotVendCod_Internalname ;
      private string edtCotVendCod_Jsonclick ;
      private string edtCotUsuC_Internalname ;
      private string edtCotUsuC_Jsonclick ;
      private string edtCotFecC_Internalname ;
      private string edtCotFecC_Jsonclick ;
      private string edtCotUsuM_Internalname ;
      private string edtCotUsuM_Jsonclick ;
      private string edtCotFecM_Internalname ;
      private string edtCotFecM_Jsonclick ;
      private string edtCotPedCod_Internalname ;
      private string A805CotPedCod ;
      private string edtCotPedCod_Jsonclick ;
      private string edtCotCliDespacho_Internalname ;
      private string edtCotCliDespacho_Jsonclick ;
      private string edtCotImp_Internalname ;
      private string edtCotImp_Jsonclick ;
      private string edtCotAIVA_Internalname ;
      private string edtCotAIVA_Jsonclick ;
      private string edtCotIVA_Internalname ;
      private string edtCotIVA_Jsonclick ;
      private string edtCotRedondeo_Internalname ;
      private string edtCotRedondeo_Jsonclick ;
      private string edtCotTotal_Internalname ;
      private string edtCotTotal_Jsonclick ;
      private string edtCotSubAfecto_Internalname ;
      private string edtCotSubAfecto_Jsonclick ;
      private string edtCotSubInafecto_Internalname ;
      private string edtCotSubInafecto_Jsonclick ;
      private string edtCotSubSelectivo_Internalname ;
      private string edtCotSubSelectivo_Jsonclick ;
      private string edtCotSubExonerado_Internalname ;
      private string edtCotSubExonerado_Jsonclick ;
      private string edtCotSubGratuito_Internalname ;
      private string edtCotSubGratuito_Jsonclick ;
      private string edtCotSubT_Internalname ;
      private string edtCotSubT_Jsonclick ;
      private string edtCotSubTotal_Internalname ;
      private string edtCotSubTotal_Jsonclick ;
      private string edtCotDscto_Internalname ;
      private string edtCotDscto_Jsonclick ;
      private string edtCotFecAten_Internalname ;
      private string edtCotFecAten_Jsonclick ;
      private string edtTieCod_Internalname ;
      private string edtTieCod_Jsonclick ;
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
      private string sMode86 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ177CotCod ;
      private string ZZ45CliCod ;
      private string ZZ807CotSts ;
      private string ZZ805CotPedCod ;
      private DateTime Z798CotFecC ;
      private DateTime Z799CotFecM ;
      private DateTime A798CotFecC ;
      private DateTime A799CotFecM ;
      private DateTime ZZ798CotFecC ;
      private DateTime ZZ799CotFecM ;
      private DateTime Z796CotFec ;
      private DateTime Z797CotFecAten ;
      private DateTime A796CotFec ;
      private DateTime A797CotFecAten ;
      private DateTime ZZ796CotFec ;
      private DateTime ZZ797CotFecAten ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n181CotLista ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A804CotObs ;
      private string Z804CotObs ;
      private string ZZ804CotObs ;
      private string Z806CotRef ;
      private string Z812CotUsuC ;
      private string Z813CotUsuM ;
      private string A806CotRef ;
      private string A812CotUsuC ;
      private string A813CotUsuM ;
      private string ZZ806CotRef ;
      private string ZZ812CotUsuC ;
      private string ZZ813CotUsuM ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002I13_A177CotCod ;
      private DateTime[] T002I13_A796CotFec ;
      private string[] T002I13_A806CotRef ;
      private decimal[] T002I13_A794CotPorDsct ;
      private decimal[] T002I13_A802CotPorIVA ;
      private string[] T002I13_A804CotObs ;
      private short[] T002I13_A810CotTItem ;
      private string[] T002I13_A807CotSts ;
      private string[] T002I13_A812CotUsuC ;
      private DateTime[] T002I13_A798CotFecC ;
      private string[] T002I13_A813CotUsuM ;
      private DateTime[] T002I13_A799CotFecM ;
      private string[] T002I13_A805CotPedCod ;
      private int[] T002I13_A764CotCliDespacho ;
      private short[] T002I13_A800CotImp ;
      private short[] T002I13_A763CotAIVA ;
      private decimal[] T002I13_A803CotRedondeo ;
      private DateTime[] T002I13_A797CotFecAten ;
      private string[] T002I13_A45CliCod ;
      private int[] T002I13_A180MonCod ;
      private int[] T002I13_A178TieCod ;
      private int[] T002I13_A182CotConpCod ;
      private int[] T002I13_A181CotLista ;
      private bool[] T002I13_n181CotLista ;
      private int[] T002I13_A179CotVendCod ;
      private decimal[] T002I13_A788CotSubAfecto ;
      private decimal[] T002I13_A789CotSubInafecto ;
      private decimal[] T002I13_A790CotSubSelectivo ;
      private decimal[] T002I13_A793CotSubExonerado ;
      private decimal[] T002I13_A808CotSubGratuito ;
      private decimal[] T002I11_A788CotSubAfecto ;
      private decimal[] T002I11_A789CotSubInafecto ;
      private decimal[] T002I11_A790CotSubSelectivo ;
      private decimal[] T002I11_A793CotSubExonerado ;
      private decimal[] T002I11_A808CotSubGratuito ;
      private string[] T002I4_A45CliCod ;
      private int[] T002I5_A180MonCod ;
      private int[] T002I7_A182CotConpCod ;
      private int[] T002I8_A181CotLista ;
      private bool[] T002I8_n181CotLista ;
      private int[] T002I9_A179CotVendCod ;
      private int[] T002I6_A178TieCod ;
      private decimal[] T002I15_A788CotSubAfecto ;
      private decimal[] T002I15_A789CotSubInafecto ;
      private decimal[] T002I15_A790CotSubSelectivo ;
      private decimal[] T002I15_A793CotSubExonerado ;
      private decimal[] T002I15_A808CotSubGratuito ;
      private string[] T002I16_A45CliCod ;
      private int[] T002I17_A180MonCod ;
      private int[] T002I18_A182CotConpCod ;
      private int[] T002I19_A181CotLista ;
      private bool[] T002I19_n181CotLista ;
      private int[] T002I20_A179CotVendCod ;
      private int[] T002I21_A178TieCod ;
      private string[] T002I22_A177CotCod ;
      private string[] T002I3_A177CotCod ;
      private DateTime[] T002I3_A796CotFec ;
      private string[] T002I3_A806CotRef ;
      private decimal[] T002I3_A794CotPorDsct ;
      private decimal[] T002I3_A802CotPorIVA ;
      private string[] T002I3_A804CotObs ;
      private short[] T002I3_A810CotTItem ;
      private string[] T002I3_A807CotSts ;
      private string[] T002I3_A812CotUsuC ;
      private DateTime[] T002I3_A798CotFecC ;
      private string[] T002I3_A813CotUsuM ;
      private DateTime[] T002I3_A799CotFecM ;
      private string[] T002I3_A805CotPedCod ;
      private int[] T002I3_A764CotCliDespacho ;
      private short[] T002I3_A800CotImp ;
      private short[] T002I3_A763CotAIVA ;
      private decimal[] T002I3_A803CotRedondeo ;
      private DateTime[] T002I3_A797CotFecAten ;
      private string[] T002I3_A45CliCod ;
      private int[] T002I3_A180MonCod ;
      private int[] T002I3_A178TieCod ;
      private int[] T002I3_A182CotConpCod ;
      private int[] T002I3_A181CotLista ;
      private bool[] T002I3_n181CotLista ;
      private int[] T002I3_A179CotVendCod ;
      private string[] T002I23_A177CotCod ;
      private string[] T002I24_A177CotCod ;
      private string[] T002I2_A177CotCod ;
      private DateTime[] T002I2_A796CotFec ;
      private string[] T002I2_A806CotRef ;
      private decimal[] T002I2_A794CotPorDsct ;
      private decimal[] T002I2_A802CotPorIVA ;
      private string[] T002I2_A804CotObs ;
      private short[] T002I2_A810CotTItem ;
      private string[] T002I2_A807CotSts ;
      private string[] T002I2_A812CotUsuC ;
      private DateTime[] T002I2_A798CotFecC ;
      private string[] T002I2_A813CotUsuM ;
      private DateTime[] T002I2_A799CotFecM ;
      private string[] T002I2_A805CotPedCod ;
      private int[] T002I2_A764CotCliDespacho ;
      private short[] T002I2_A800CotImp ;
      private short[] T002I2_A763CotAIVA ;
      private decimal[] T002I2_A803CotRedondeo ;
      private DateTime[] T002I2_A797CotFecAten ;
      private string[] T002I2_A45CliCod ;
      private int[] T002I2_A180MonCod ;
      private int[] T002I2_A178TieCod ;
      private int[] T002I2_A182CotConpCod ;
      private int[] T002I2_A181CotLista ;
      private bool[] T002I2_n181CotLista ;
      private int[] T002I2_A179CotVendCod ;
      private decimal[] T002I29_A788CotSubAfecto ;
      private decimal[] T002I29_A789CotSubInafecto ;
      private decimal[] T002I29_A790CotSubSelectivo ;
      private decimal[] T002I29_A793CotSubExonerado ;
      private decimal[] T002I29_A808CotSubGratuito ;
      private string[] T002I30_A177CotCod ;
      private short[] T002I30_A183CotDItem ;
      private string[] T002I31_A177CotCod ;
      private string[] T002I32_A45CliCod ;
      private int[] T002I33_A180MonCod ;
      private int[] T002I34_A182CotConpCod ;
      private int[] T002I35_A181CotLista ;
      private bool[] T002I35_n181CotLista ;
      private int[] T002I36_A179CotVendCod ;
      private int[] T002I37_A178TieCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clcotiza__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clcotiza__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002I13;
        prmT002I13 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I11;
        prmT002I11 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I4;
        prmT002I4 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002I5;
        prmT002I5 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT002I7;
        prmT002I7 = new Object[] {
        new ParDef("@CotConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002I8;
        prmT002I8 = new Object[] {
        new ParDef("@CotLista",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002I9;
        prmT002I9 = new Object[] {
        new ParDef("@CotVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002I6;
        prmT002I6 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0)
        };
        Object[] prmT002I15;
        prmT002I15 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I16;
        prmT002I16 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002I17;
        prmT002I17 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT002I18;
        prmT002I18 = new Object[] {
        new ParDef("@CotConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002I19;
        prmT002I19 = new Object[] {
        new ParDef("@CotLista",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002I20;
        prmT002I20 = new Object[] {
        new ParDef("@CotVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002I21;
        prmT002I21 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0)
        };
        Object[] prmT002I22;
        prmT002I22 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I3;
        prmT002I3 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I23;
        prmT002I23 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I24;
        prmT002I24 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I2;
        prmT002I2 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I25;
        prmT002I25 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotFec",GXType.Date,8,0) ,
        new ParDef("@CotRef",GXType.NVarChar,20,0) ,
        new ParDef("@CotPorDsct",GXType.Decimal,6,2) ,
        new ParDef("@CotPorIVA",GXType.Decimal,6,2) ,
        new ParDef("@CotObs",GXType.NVarChar,500,0) ,
        new ParDef("@CotTItem",GXType.Int16,4,0) ,
        new ParDef("@CotSts",GXType.NChar,1,0) ,
        new ParDef("@CotUsuC",GXType.NVarChar,10,0) ,
        new ParDef("@CotFecC",GXType.DateTime,8,5) ,
        new ParDef("@CotUsuM",GXType.NVarChar,10,0) ,
        new ParDef("@CotFecM",GXType.DateTime,8,5) ,
        new ParDef("@CotPedCod",GXType.NChar,10,0) ,
        new ParDef("@CotCliDespacho",GXType.Int32,6,0) ,
        new ParDef("@CotImp",GXType.Int16,1,0) ,
        new ParDef("@CotAIVA",GXType.Int16,1,0) ,
        new ParDef("@CotRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@CotFecAten",GXType.Date,8,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0) ,
        new ParDef("@CotConpCod",GXType.Int32,6,0) ,
        new ParDef("@CotLista",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CotVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002I26;
        prmT002I26 = new Object[] {
        new ParDef("@CotFec",GXType.Date,8,0) ,
        new ParDef("@CotRef",GXType.NVarChar,20,0) ,
        new ParDef("@CotPorDsct",GXType.Decimal,6,2) ,
        new ParDef("@CotPorIVA",GXType.Decimal,6,2) ,
        new ParDef("@CotObs",GXType.NVarChar,500,0) ,
        new ParDef("@CotTItem",GXType.Int16,4,0) ,
        new ParDef("@CotSts",GXType.NChar,1,0) ,
        new ParDef("@CotUsuC",GXType.NVarChar,10,0) ,
        new ParDef("@CotFecC",GXType.DateTime,8,5) ,
        new ParDef("@CotUsuM",GXType.NVarChar,10,0) ,
        new ParDef("@CotFecM",GXType.DateTime,8,5) ,
        new ParDef("@CotPedCod",GXType.NChar,10,0) ,
        new ParDef("@CotCliDespacho",GXType.Int32,6,0) ,
        new ParDef("@CotImp",GXType.Int16,1,0) ,
        new ParDef("@CotAIVA",GXType.Int16,1,0) ,
        new ParDef("@CotRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@CotFecAten",GXType.Date,8,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0) ,
        new ParDef("@CotConpCod",GXType.Int32,6,0) ,
        new ParDef("@CotLista",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CotVendCod",GXType.Int32,6,0) ,
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I27;
        prmT002I27 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I30;
        prmT002I30 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I31;
        prmT002I31 = new Object[] {
        };
        Object[] prmT002I29;
        prmT002I29 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002I32;
        prmT002I32 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002I33;
        prmT002I33 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT002I34;
        prmT002I34 = new Object[] {
        new ParDef("@CotConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002I35;
        prmT002I35 = new Object[] {
        new ParDef("@CotLista",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002I36;
        prmT002I36 = new Object[] {
        new ParDef("@CotVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002I37;
        prmT002I37 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002I2", "SELECT [CotCod], [CotFec], [CotRef], [CotPorDsct], [CotPorIVA], [CotObs], [CotTItem], [CotSts], [CotUsuC], [CotFecC], [CotUsuM], [CotFecM], [CotPedCod], [CotCliDespacho], [CotImp], [CotAIVA], [CotRedondeo], [CotFecAten], [CliCod], [MonCod], [TieCod], [CotConpCod] AS CotConpCod, [CotLista] AS CotLista, [CotVendCod] AS CotVendCod FROM [CLCOTIZA] WITH (UPDLOCK) WHERE [CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I3", "SELECT [CotCod], [CotFec], [CotRef], [CotPorDsct], [CotPorIVA], [CotObs], [CotTItem], [CotSts], [CotUsuC], [CotFecC], [CotUsuM], [CotFecM], [CotPedCod], [CotCliDespacho], [CotImp], [CotAIVA], [CotRedondeo], [CotFecAten], [CliCod], [MonCod], [TieCod], [CotConpCod] AS CotConpCod, [CotLista] AS CotLista, [CotVendCod] AS CotVendCod FROM [CLCOTIZA] WHERE [CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I4", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I5", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I6", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I7", "SELECT [Conpcod] AS CotConpCod FROM [CCONDICIONPAGO] WHERE [Conpcod] = @CotConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I8", "SELECT [TipLCod] AS CotLista FROM [CTIPOSLISTAS] WHERE [TipLCod] = @CotLista ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I9", "SELECT [VenCod] AS CotVendCod FROM [CVENDEDORES] WHERE [VenCod] = @CotVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I11", "SELECT COALESCE( T1.[CotSubAfecto], 0) AS CotSubAfecto, COALESCE( T1.[CotSubInafecto], 0) AS CotSubInafecto, COALESCE( T1.[CotSubSelectivo], 0) AS CotSubSelectivo, COALESCE( T1.[CotSubExonerado], 0) AS CotSubExonerado, COALESCE( T1.[CotSubGratuito], 0) AS CotSubGratuito FROM (SELECT SUM(CASE  WHEN [CotDIna] = 0 THEN [CotDTot] ELSE 0 END) AS CotSubAfecto, [CotCod], SUM(CASE  WHEN [CotDIna] = 1 or [CotDIna] = 4 THEN [CotDTot] ELSE 0 END) AS CotSubInafecto, SUM(ROUND(CAST(( [CotDTot] * CAST([CotDSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) AS CotSubSelectivo, SUM(CASE  WHEN [CotDIna] = 2 THEN [CotDTot] ELSE 0 END) AS CotSubExonerado, SUM(CASE  WHEN [CotDIna] = 3 THEN [CotDTot] ELSE 0 END) AS CotSubGratuito FROM [CLCOTIZADET] GROUP BY [CotCod] ) T1 WHERE T1.[CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I13", "SELECT TM1.[CotCod], TM1.[CotFec], TM1.[CotRef], TM1.[CotPorDsct], TM1.[CotPorIVA], TM1.[CotObs], TM1.[CotTItem], TM1.[CotSts], TM1.[CotUsuC], TM1.[CotFecC], TM1.[CotUsuM], TM1.[CotFecM], TM1.[CotPedCod], TM1.[CotCliDespacho], TM1.[CotImp], TM1.[CotAIVA], TM1.[CotRedondeo], TM1.[CotFecAten], TM1.[CliCod], TM1.[MonCod], TM1.[TieCod], TM1.[CotConpCod] AS CotConpCod, TM1.[CotLista] AS CotLista, TM1.[CotVendCod] AS CotVendCod, COALESCE( T2.[CotSubAfecto], 0) AS CotSubAfecto, COALESCE( T2.[CotSubInafecto], 0) AS CotSubInafecto, COALESCE( T2.[CotSubSelectivo], 0) AS CotSubSelectivo, COALESCE( T2.[CotSubExonerado], 0) AS CotSubExonerado, COALESCE( T2.[CotSubGratuito], 0) AS CotSubGratuito FROM ([CLCOTIZA] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN [CotDIna] = 0 THEN [CotDTot] ELSE 0 END) AS CotSubAfecto, [CotCod], SUM(CASE  WHEN [CotDIna] = 1 or [CotDIna] = 4 THEN [CotDTot] ELSE 0 END) AS CotSubInafecto, SUM(ROUND(CAST(( [CotDTot] * CAST([CotDSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) AS CotSubSelectivo, SUM(CASE  WHEN [CotDIna] = 2 THEN [CotDTot] ELSE 0 END) AS CotSubExonerado, SUM(CASE  WHEN [CotDIna] = 3 THEN [CotDTot] ELSE 0 END) AS CotSubGratuito FROM [CLCOTIZADET] GROUP BY [CotCod] ) T2 ON T2.[CotCod] = TM1.[CotCod]) WHERE TM1.[CotCod] = @CotCod ORDER BY TM1.[CotCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002I13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I15", "SELECT COALESCE( T1.[CotSubAfecto], 0) AS CotSubAfecto, COALESCE( T1.[CotSubInafecto], 0) AS CotSubInafecto, COALESCE( T1.[CotSubSelectivo], 0) AS CotSubSelectivo, COALESCE( T1.[CotSubExonerado], 0) AS CotSubExonerado, COALESCE( T1.[CotSubGratuito], 0) AS CotSubGratuito FROM (SELECT SUM(CASE  WHEN [CotDIna] = 0 THEN [CotDTot] ELSE 0 END) AS CotSubAfecto, [CotCod], SUM(CASE  WHEN [CotDIna] = 1 or [CotDIna] = 4 THEN [CotDTot] ELSE 0 END) AS CotSubInafecto, SUM(ROUND(CAST(( [CotDTot] * CAST([CotDSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) AS CotSubSelectivo, SUM(CASE  WHEN [CotDIna] = 2 THEN [CotDTot] ELSE 0 END) AS CotSubExonerado, SUM(CASE  WHEN [CotDIna] = 3 THEN [CotDTot] ELSE 0 END) AS CotSubGratuito FROM [CLCOTIZADET] GROUP BY [CotCod] ) T1 WHERE T1.[CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I16", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I17", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I18", "SELECT [Conpcod] AS CotConpCod FROM [CCONDICIONPAGO] WHERE [Conpcod] = @CotConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I19", "SELECT [TipLCod] AS CotLista FROM [CTIPOSLISTAS] WHERE [TipLCod] = @CotLista ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I20", "SELECT [VenCod] AS CotVendCod FROM [CVENDEDORES] WHERE [VenCod] = @CotVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I21", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I22", "SELECT [CotCod] FROM [CLCOTIZA] WHERE [CotCod] = @CotCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002I22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I23", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE ( [CotCod] > @CotCod) ORDER BY [CotCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002I23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002I24", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE ( [CotCod] < @CotCod) ORDER BY [CotCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002I24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002I25", "INSERT INTO [CLCOTIZA]([CotCod], [CotFec], [CotRef], [CotPorDsct], [CotPorIVA], [CotObs], [CotTItem], [CotSts], [CotUsuC], [CotFecC], [CotUsuM], [CotFecM], [CotPedCod], [CotCliDespacho], [CotImp], [CotAIVA], [CotRedondeo], [CotFecAten], [CliCod], [MonCod], [TieCod], [CotConpCod], [CotLista], [CotVendCod]) VALUES(@CotCod, @CotFec, @CotRef, @CotPorDsct, @CotPorIVA, @CotObs, @CotTItem, @CotSts, @CotUsuC, @CotFecC, @CotUsuM, @CotFecM, @CotPedCod, @CotCliDespacho, @CotImp, @CotAIVA, @CotRedondeo, @CotFecAten, @CliCod, @MonCod, @TieCod, @CotConpCod, @CotLista, @CotVendCod)", GxErrorMask.GX_NOMASK,prmT002I25)
           ,new CursorDef("T002I26", "UPDATE [CLCOTIZA] SET [CotFec]=@CotFec, [CotRef]=@CotRef, [CotPorDsct]=@CotPorDsct, [CotPorIVA]=@CotPorIVA, [CotObs]=@CotObs, [CotTItem]=@CotTItem, [CotSts]=@CotSts, [CotUsuC]=@CotUsuC, [CotFecC]=@CotFecC, [CotUsuM]=@CotUsuM, [CotFecM]=@CotFecM, [CotPedCod]=@CotPedCod, [CotCliDespacho]=@CotCliDespacho, [CotImp]=@CotImp, [CotAIVA]=@CotAIVA, [CotRedondeo]=@CotRedondeo, [CotFecAten]=@CotFecAten, [CliCod]=@CliCod, [MonCod]=@MonCod, [TieCod]=@TieCod, [CotConpCod]=@CotConpCod, [CotLista]=@CotLista, [CotVendCod]=@CotVendCod  WHERE [CotCod] = @CotCod", GxErrorMask.GX_NOMASK,prmT002I26)
           ,new CursorDef("T002I27", "DELETE FROM [CLCOTIZA]  WHERE [CotCod] = @CotCod", GxErrorMask.GX_NOMASK,prmT002I27)
           ,new CursorDef("T002I29", "SELECT COALESCE( T1.[CotSubAfecto], 0) AS CotSubAfecto, COALESCE( T1.[CotSubInafecto], 0) AS CotSubInafecto, COALESCE( T1.[CotSubSelectivo], 0) AS CotSubSelectivo, COALESCE( T1.[CotSubExonerado], 0) AS CotSubExonerado, COALESCE( T1.[CotSubGratuito], 0) AS CotSubGratuito FROM (SELECT SUM(CASE  WHEN [CotDIna] = 0 THEN [CotDTot] ELSE 0 END) AS CotSubAfecto, [CotCod], SUM(CASE  WHEN [CotDIna] = 1 or [CotDIna] = 4 THEN [CotDTot] ELSE 0 END) AS CotSubInafecto, SUM(ROUND(CAST(( [CotDTot] * CAST([CotDSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) AS CotSubSelectivo, SUM(CASE  WHEN [CotDIna] = 2 THEN [CotDTot] ELSE 0 END) AS CotSubExonerado, SUM(CASE  WHEN [CotDIna] = 3 THEN [CotDTot] ELSE 0 END) AS CotSubGratuito FROM [CLCOTIZADET] GROUP BY [CotCod] ) T1 WHERE T1.[CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I30", "SELECT TOP 1 [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE [CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002I31", "SELECT [CotCod] FROM [CLCOTIZA] ORDER BY [CotCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002I31,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I32", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I33", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I34", "SELECT [Conpcod] AS CotConpCod FROM [CCONDICIONPAGO] WHERE [Conpcod] = @CotConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I35", "SELECT [TipLCod] AS CotLista FROM [CTIPOSLISTAS] WHERE [TipLCod] = @CotLista ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I36", "SELECT [VenCod] AS CotVendCod FROM [CVENDEDORES] WHERE [VenCod] = @CotVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002I37", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I37,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(26);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(27);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(29);
              return;
           case 10 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 23 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 31 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
