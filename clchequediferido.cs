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
   public class clchequediferido : GXDataArea
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
            A152CLCheqDCliCod = GetPar( "CLCheqDCliCod");
            AssignAttri("", false, "A152CLCheqDCliCod", A152CLCheqDCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A152CLCheqDCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A151CLCheqDMonCod = (int)(NumberUtil.Val( GetPar( "CLCheqDMonCod"), "."));
            AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrimStr( (decimal)(A151CLCheqDMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A151CLCheqDMonCod) ;
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
            Form.Meta.addItem("description", "CLCHEQUEDIFERIDO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clchequediferido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clchequediferido( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CLCHEQUEDIFERIDO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDCod_Internalname, "Canje Cheque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDCod_Internalname, StringUtil.RTrim( A150CLCheqDCod), StringUtil.RTrim( context.localUtil.Format( A150CLCheqDCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDCliCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDCliCod_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDCliCod_Internalname, StringUtil.RTrim( A152CLCheqDCliCod), StringUtil.RTrim( context.localUtil.Format( A152CLCheqDCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDCliDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDCliDsc_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCLCheqDCliDsc_Internalname, StringUtil.RTrim( A556CLCheqDCliDsc), StringUtil.RTrim( context.localUtil.Format( A556CLCheqDCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCLCheqDFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCLCheqDFec_Internalname, context.localUtil.Format(A558CLCheqDFec, "99/99/99"), context.localUtil.Format( A558CLCheqDFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_bitmap( context, edtCLCheqDFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCLCheqDFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDForCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDForCod_Internalname, "de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A561CLCheqDForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A561CLCheqDForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A561CLCheqDForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDTipCmb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDTipCmb_Internalname, "de Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A566CLCheqDTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtCLCheqDTipCmb_Enabled!=0) ? context.localUtil.Format( A566CLCheqDTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A566CLCheqDTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDSts_Internalname, StringUtil.RTrim( A564CLCheqDSts), StringUtil.RTrim( context.localUtil.Format( A564CLCheqDSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A151CLCheqDMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A151CLCheqDMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A151CLCheqDMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDImporte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDImporte_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A563CLCheqDImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtCLCheqDImporte_Enabled!=0) ? context.localUtil.Format( A563CLCheqDImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A563CLCheqDImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A570CLCheqDVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A570CLCheqDVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A570CLCheqDVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A571CLCheqDVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A571CLCheqDVouMes), "Z9") : context.localUtil.Format( (decimal)(A571CLCheqDVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDTasiCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDTasiCod_Internalname, "de Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A565CLCheqDTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A565CLCheqDTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A565CLCheqDTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDVouNum_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDVouNum_Internalname, StringUtil.RTrim( A572CLCheqDVouNum), StringUtil.RTrim( context.localUtil.Format( A572CLCheqDVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDUsuCod_Internalname, StringUtil.RTrim( A568CLCheqDUsuCod), StringUtil.RTrim( context.localUtil.Format( A568CLCheqDUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDUsuFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDUsuFec_Internalname, "Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCLCheqDUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCLCheqDUsuFec_Internalname, context.localUtil.TToC( A569CLCheqDUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A569CLCheqDUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_bitmap( context, edtCLCheqDUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCLCheqDUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCHEQUEDIFERIDO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDO.htm");
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
            Z150CLCheqDCod = cgiGet( "Z150CLCheqDCod");
            Z558CLCheqDFec = context.localUtil.CToD( cgiGet( "Z558CLCheqDFec"), 0);
            Z561CLCheqDForCod = (int)(context.localUtil.CToN( cgiGet( "Z561CLCheqDForCod"), ".", ","));
            Z566CLCheqDTipCmb = context.localUtil.CToN( cgiGet( "Z566CLCheqDTipCmb"), ".", ",");
            Z564CLCheqDSts = cgiGet( "Z564CLCheqDSts");
            Z563CLCheqDImporte = context.localUtil.CToN( cgiGet( "Z563CLCheqDImporte"), ".", ",");
            Z570CLCheqDVouAno = (short)(context.localUtil.CToN( cgiGet( "Z570CLCheqDVouAno"), ".", ","));
            Z571CLCheqDVouMes = (short)(context.localUtil.CToN( cgiGet( "Z571CLCheqDVouMes"), ".", ","));
            Z565CLCheqDTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z565CLCheqDTasiCod"), ".", ","));
            Z572CLCheqDVouNum = cgiGet( "Z572CLCheqDVouNum");
            Z568CLCheqDUsuCod = cgiGet( "Z568CLCheqDUsuCod");
            Z569CLCheqDUsuFec = context.localUtil.CToT( cgiGet( "Z569CLCheqDUsuFec"), 0);
            Z152CLCheqDCliCod = cgiGet( "Z152CLCheqDCliCod");
            Z151CLCheqDMonCod = (int)(context.localUtil.CToN( cgiGet( "Z151CLCheqDMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A150CLCheqDCod = cgiGet( edtCLCheqDCod_Internalname);
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            A152CLCheqDCliCod = cgiGet( edtCLCheqDCliCod_Internalname);
            AssignAttri("", false, "A152CLCheqDCliCod", A152CLCheqDCliCod);
            A556CLCheqDCliDsc = cgiGet( edtCLCheqDCliDsc_Internalname);
            AssignAttri("", false, "A556CLCheqDCliDsc", A556CLCheqDCliDsc);
            if ( context.localUtil.VCDate( cgiGet( edtCLCheqDFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CLCHEQDFEC");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A558CLCheqDFec = DateTime.MinValue;
               AssignAttri("", false, "A558CLCheqDFec", context.localUtil.Format(A558CLCheqDFec, "99/99/99"));
            }
            else
            {
               A558CLCheqDFec = context.localUtil.CToD( cgiGet( edtCLCheqDFec_Internalname), 2);
               AssignAttri("", false, "A558CLCheqDFec", context.localUtil.Format(A558CLCheqDFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDFORCOD");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A561CLCheqDForCod = 0;
               AssignAttri("", false, "A561CLCheqDForCod", StringUtil.LTrimStr( (decimal)(A561CLCheqDForCod), 6, 0));
            }
            else
            {
               A561CLCheqDForCod = (int)(context.localUtil.CToN( cgiGet( edtCLCheqDForCod_Internalname), ".", ","));
               AssignAttri("", false, "A561CLCheqDForCod", StringUtil.LTrimStr( (decimal)(A561CLCheqDForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A566CLCheqDTipCmb = 0;
               AssignAttri("", false, "A566CLCheqDTipCmb", StringUtil.LTrimStr( A566CLCheqDTipCmb, 15, 5));
            }
            else
            {
               A566CLCheqDTipCmb = context.localUtil.CToN( cgiGet( edtCLCheqDTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A566CLCheqDTipCmb", StringUtil.LTrimStr( A566CLCheqDTipCmb, 15, 5));
            }
            A564CLCheqDSts = cgiGet( edtCLCheqDSts_Internalname);
            AssignAttri("", false, "A564CLCheqDSts", A564CLCheqDSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDMONCOD");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A151CLCheqDMonCod = 0;
               AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrimStr( (decimal)(A151CLCheqDMonCod), 6, 0));
            }
            else
            {
               A151CLCheqDMonCod = (int)(context.localUtil.CToN( cgiGet( edtCLCheqDMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrimStr( (decimal)(A151CLCheqDMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A563CLCheqDImporte = 0;
               AssignAttri("", false, "A563CLCheqDImporte", StringUtil.LTrimStr( A563CLCheqDImporte, 15, 2));
            }
            else
            {
               A563CLCheqDImporte = context.localUtil.CToN( cgiGet( edtCLCheqDImporte_Internalname), ".", ",");
               AssignAttri("", false, "A563CLCheqDImporte", StringUtil.LTrimStr( A563CLCheqDImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDVOUANO");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A570CLCheqDVouAno = 0;
               AssignAttri("", false, "A570CLCheqDVouAno", StringUtil.LTrimStr( (decimal)(A570CLCheqDVouAno), 4, 0));
            }
            else
            {
               A570CLCheqDVouAno = (short)(context.localUtil.CToN( cgiGet( edtCLCheqDVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A570CLCheqDVouAno", StringUtil.LTrimStr( (decimal)(A570CLCheqDVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDVOUMES");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A571CLCheqDVouMes = 0;
               AssignAttri("", false, "A571CLCheqDVouMes", StringUtil.LTrimStr( (decimal)(A571CLCheqDVouMes), 2, 0));
            }
            else
            {
               A571CLCheqDVouMes = (short)(context.localUtil.CToN( cgiGet( edtCLCheqDVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A571CLCheqDVouMes", StringUtil.LTrimStr( (decimal)(A571CLCheqDVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDTASICOD");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A565CLCheqDTasiCod = 0;
               AssignAttri("", false, "A565CLCheqDTasiCod", StringUtil.LTrimStr( (decimal)(A565CLCheqDTasiCod), 6, 0));
            }
            else
            {
               A565CLCheqDTasiCod = (int)(context.localUtil.CToN( cgiGet( edtCLCheqDTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A565CLCheqDTasiCod", StringUtil.LTrimStr( (decimal)(A565CLCheqDTasiCod), 6, 0));
            }
            A572CLCheqDVouNum = cgiGet( edtCLCheqDVouNum_Internalname);
            AssignAttri("", false, "A572CLCheqDVouNum", A572CLCheqDVouNum);
            A568CLCheqDUsuCod = cgiGet( edtCLCheqDUsuCod_Internalname);
            AssignAttri("", false, "A568CLCheqDUsuCod", A568CLCheqDUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtCLCheqDUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora"}), 1, "CLCHEQDUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A569CLCheqDUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A569CLCheqDUsuFec", context.localUtil.TToC( A569CLCheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A569CLCheqDUsuFec = context.localUtil.CToT( cgiGet( edtCLCheqDUsuFec_Internalname));
               AssignAttri("", false, "A569CLCheqDUsuFec", context.localUtil.TToC( A569CLCheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
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
               A150CLCheqDCod = GetPar( "CLCheqDCod");
               AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
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
               InitAll099( ) ;
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
         DisableAttributes099( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z558CLCheqDFec = T00093_A558CLCheqDFec[0];
               Z561CLCheqDForCod = T00093_A561CLCheqDForCod[0];
               Z566CLCheqDTipCmb = T00093_A566CLCheqDTipCmb[0];
               Z564CLCheqDSts = T00093_A564CLCheqDSts[0];
               Z563CLCheqDImporte = T00093_A563CLCheqDImporte[0];
               Z570CLCheqDVouAno = T00093_A570CLCheqDVouAno[0];
               Z571CLCheqDVouMes = T00093_A571CLCheqDVouMes[0];
               Z565CLCheqDTasiCod = T00093_A565CLCheqDTasiCod[0];
               Z572CLCheqDVouNum = T00093_A572CLCheqDVouNum[0];
               Z568CLCheqDUsuCod = T00093_A568CLCheqDUsuCod[0];
               Z569CLCheqDUsuFec = T00093_A569CLCheqDUsuFec[0];
               Z152CLCheqDCliCod = T00093_A152CLCheqDCliCod[0];
               Z151CLCheqDMonCod = T00093_A151CLCheqDMonCod[0];
            }
            else
            {
               Z558CLCheqDFec = A558CLCheqDFec;
               Z561CLCheqDForCod = A561CLCheqDForCod;
               Z566CLCheqDTipCmb = A566CLCheqDTipCmb;
               Z564CLCheqDSts = A564CLCheqDSts;
               Z563CLCheqDImporte = A563CLCheqDImporte;
               Z570CLCheqDVouAno = A570CLCheqDVouAno;
               Z571CLCheqDVouMes = A571CLCheqDVouMes;
               Z565CLCheqDTasiCod = A565CLCheqDTasiCod;
               Z572CLCheqDVouNum = A572CLCheqDVouNum;
               Z568CLCheqDUsuCod = A568CLCheqDUsuCod;
               Z569CLCheqDUsuFec = A569CLCheqDUsuFec;
               Z152CLCheqDCliCod = A152CLCheqDCliCod;
               Z151CLCheqDMonCod = A151CLCheqDMonCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z150CLCheqDCod = A150CLCheqDCod;
            Z558CLCheqDFec = A558CLCheqDFec;
            Z561CLCheqDForCod = A561CLCheqDForCod;
            Z566CLCheqDTipCmb = A566CLCheqDTipCmb;
            Z564CLCheqDSts = A564CLCheqDSts;
            Z563CLCheqDImporte = A563CLCheqDImporte;
            Z570CLCheqDVouAno = A570CLCheqDVouAno;
            Z571CLCheqDVouMes = A571CLCheqDVouMes;
            Z565CLCheqDTasiCod = A565CLCheqDTasiCod;
            Z572CLCheqDVouNum = A572CLCheqDVouNum;
            Z568CLCheqDUsuCod = A568CLCheqDUsuCod;
            Z569CLCheqDUsuFec = A569CLCheqDUsuFec;
            Z152CLCheqDCliCod = A152CLCheqDCliCod;
            Z151CLCheqDMonCod = A151CLCheqDMonCod;
            Z556CLCheqDCliDsc = A556CLCheqDCliDsc;
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

      protected void Load099( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A556CLCheqDCliDsc = T00096_A556CLCheqDCliDsc[0];
            AssignAttri("", false, "A556CLCheqDCliDsc", A556CLCheqDCliDsc);
            A558CLCheqDFec = T00096_A558CLCheqDFec[0];
            AssignAttri("", false, "A558CLCheqDFec", context.localUtil.Format(A558CLCheqDFec, "99/99/99"));
            A561CLCheqDForCod = T00096_A561CLCheqDForCod[0];
            AssignAttri("", false, "A561CLCheqDForCod", StringUtil.LTrimStr( (decimal)(A561CLCheqDForCod), 6, 0));
            A566CLCheqDTipCmb = T00096_A566CLCheqDTipCmb[0];
            AssignAttri("", false, "A566CLCheqDTipCmb", StringUtil.LTrimStr( A566CLCheqDTipCmb, 15, 5));
            A564CLCheqDSts = T00096_A564CLCheqDSts[0];
            AssignAttri("", false, "A564CLCheqDSts", A564CLCheqDSts);
            A563CLCheqDImporte = T00096_A563CLCheqDImporte[0];
            AssignAttri("", false, "A563CLCheqDImporte", StringUtil.LTrimStr( A563CLCheqDImporte, 15, 2));
            A570CLCheqDVouAno = T00096_A570CLCheqDVouAno[0];
            AssignAttri("", false, "A570CLCheqDVouAno", StringUtil.LTrimStr( (decimal)(A570CLCheqDVouAno), 4, 0));
            A571CLCheqDVouMes = T00096_A571CLCheqDVouMes[0];
            AssignAttri("", false, "A571CLCheqDVouMes", StringUtil.LTrimStr( (decimal)(A571CLCheqDVouMes), 2, 0));
            A565CLCheqDTasiCod = T00096_A565CLCheqDTasiCod[0];
            AssignAttri("", false, "A565CLCheqDTasiCod", StringUtil.LTrimStr( (decimal)(A565CLCheqDTasiCod), 6, 0));
            A572CLCheqDVouNum = T00096_A572CLCheqDVouNum[0];
            AssignAttri("", false, "A572CLCheqDVouNum", A572CLCheqDVouNum);
            A568CLCheqDUsuCod = T00096_A568CLCheqDUsuCod[0];
            AssignAttri("", false, "A568CLCheqDUsuCod", A568CLCheqDUsuCod);
            A569CLCheqDUsuFec = T00096_A569CLCheqDUsuFec[0];
            AssignAttri("", false, "A569CLCheqDUsuFec", context.localUtil.TToC( A569CLCheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A152CLCheqDCliCod = T00096_A152CLCheqDCliCod[0];
            AssignAttri("", false, "A152CLCheqDCliCod", A152CLCheqDCliCod);
            A151CLCheqDMonCod = T00096_A151CLCheqDMonCod[0];
            AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrimStr( (decimal)(A151CLCheqDMonCod), 6, 0));
            ZM099( -3) ;
         }
         pr_default.close(4);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A152CLCheqDCliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLCHEQDCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A556CLCheqDCliDsc = T00094_A556CLCheqDCliDsc[0];
         AssignAttri("", false, "A556CLCheqDCliDsc", A556CLCheqDCliDsc);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A558CLCheqDFec) || ( DateTimeUtil.ResetTime ( A558CLCheqDFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CLCHEQDFEC");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A151CLCheqDMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CLCHEQDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A569CLCheqDUsuFec) || ( A569CLCheqDUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "CLCHEQDUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A152CLCheqDCliCod )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A152CLCheqDCliCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLCHEQDCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A556CLCheqDCliDsc = T00097_A556CLCheqDCliDsc[0];
         AssignAttri("", false, "A556CLCheqDCliDsc", A556CLCheqDCliDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A556CLCheqDCliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( int A151CLCheqDMonCod )
      {
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A151CLCheqDMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CLCHEQDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDMonCod_Internalname;
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

      protected void GetKey099( )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 3) ;
            RcdFound9 = 1;
            A150CLCheqDCod = T00093_A150CLCheqDCod[0];
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            A558CLCheqDFec = T00093_A558CLCheqDFec[0];
            AssignAttri("", false, "A558CLCheqDFec", context.localUtil.Format(A558CLCheqDFec, "99/99/99"));
            A561CLCheqDForCod = T00093_A561CLCheqDForCod[0];
            AssignAttri("", false, "A561CLCheqDForCod", StringUtil.LTrimStr( (decimal)(A561CLCheqDForCod), 6, 0));
            A566CLCheqDTipCmb = T00093_A566CLCheqDTipCmb[0];
            AssignAttri("", false, "A566CLCheqDTipCmb", StringUtil.LTrimStr( A566CLCheqDTipCmb, 15, 5));
            A564CLCheqDSts = T00093_A564CLCheqDSts[0];
            AssignAttri("", false, "A564CLCheqDSts", A564CLCheqDSts);
            A563CLCheqDImporte = T00093_A563CLCheqDImporte[0];
            AssignAttri("", false, "A563CLCheqDImporte", StringUtil.LTrimStr( A563CLCheqDImporte, 15, 2));
            A570CLCheqDVouAno = T00093_A570CLCheqDVouAno[0];
            AssignAttri("", false, "A570CLCheqDVouAno", StringUtil.LTrimStr( (decimal)(A570CLCheqDVouAno), 4, 0));
            A571CLCheqDVouMes = T00093_A571CLCheqDVouMes[0];
            AssignAttri("", false, "A571CLCheqDVouMes", StringUtil.LTrimStr( (decimal)(A571CLCheqDVouMes), 2, 0));
            A565CLCheqDTasiCod = T00093_A565CLCheqDTasiCod[0];
            AssignAttri("", false, "A565CLCheqDTasiCod", StringUtil.LTrimStr( (decimal)(A565CLCheqDTasiCod), 6, 0));
            A572CLCheqDVouNum = T00093_A572CLCheqDVouNum[0];
            AssignAttri("", false, "A572CLCheqDVouNum", A572CLCheqDVouNum);
            A568CLCheqDUsuCod = T00093_A568CLCheqDUsuCod[0];
            AssignAttri("", false, "A568CLCheqDUsuCod", A568CLCheqDUsuCod);
            A569CLCheqDUsuFec = T00093_A569CLCheqDUsuFec[0];
            AssignAttri("", false, "A569CLCheqDUsuFec", context.localUtil.TToC( A569CLCheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A152CLCheqDCliCod = T00093_A152CLCheqDCliCod[0];
            AssignAttri("", false, "A152CLCheqDCliCod", A152CLCheqDCliCod);
            A151CLCheqDMonCod = T00093_A151CLCheqDMonCod[0];
            AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrimStr( (decimal)(A151CLCheqDMonCod), 6, 0));
            Z150CLCheqDCod = A150CLCheqDCod;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000910_A150CLCheqDCod[0], A150CLCheqDCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000910_A150CLCheqDCod[0], A150CLCheqDCod) > 0 ) ) )
            {
               A150CLCheqDCod = T000910_A150CLCheqDCod[0];
               AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
               RcdFound9 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000911_A150CLCheqDCod[0], A150CLCheqDCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000911_A150CLCheqDCod[0], A150CLCheqDCod) < 0 ) ) )
            {
               A150CLCheqDCod = T000911_A150CLCheqDCod[0];
               AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
               RcdFound9 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( StringUtil.StrCmp(A150CLCheqDCod, Z150CLCheqDCod) != 0 )
               {
                  A150CLCheqDCod = Z150CLCheqDCod;
                  AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLCHEQDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update099( ) ;
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A150CLCheqDCod, Z150CLCheqDCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLCHEQDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCLCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCLCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
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
         if ( StringUtil.StrCmp(A150CLCheqDCod, Z150CLCheqDCod) != 0 )
         {
            A150CLCheqDCod = Z150CLCheqDCod;
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCLCheqDCod_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCLCheqDCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDCliCod_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDCliCod_Internalname;
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
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext099( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A150CLCheqDCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCHEQUEDIFERIDO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z558CLCheqDFec ) != DateTimeUtil.ResetTime ( T00092_A558CLCheqDFec[0] ) ) || ( Z561CLCheqDForCod != T00092_A561CLCheqDForCod[0] ) || ( Z566CLCheqDTipCmb != T00092_A566CLCheqDTipCmb[0] ) || ( StringUtil.StrCmp(Z564CLCheqDSts, T00092_A564CLCheqDSts[0]) != 0 ) || ( Z563CLCheqDImporte != T00092_A563CLCheqDImporte[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z570CLCheqDVouAno != T00092_A570CLCheqDVouAno[0] ) || ( Z571CLCheqDVouMes != T00092_A571CLCheqDVouMes[0] ) || ( Z565CLCheqDTasiCod != T00092_A565CLCheqDTasiCod[0] ) || ( StringUtil.StrCmp(Z572CLCheqDVouNum, T00092_A572CLCheqDVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z568CLCheqDUsuCod, T00092_A568CLCheqDUsuCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z569CLCheqDUsuFec != T00092_A569CLCheqDUsuFec[0] ) || ( StringUtil.StrCmp(Z152CLCheqDCliCod, T00092_A152CLCheqDCliCod[0]) != 0 ) || ( Z151CLCheqDMonCod != T00092_A151CLCheqDMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z558CLCheqDFec ) != DateTimeUtil.ResetTime ( T00092_A558CLCheqDFec[0] ) )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDFec");
                  GXUtil.WriteLogRaw("Old: ",Z558CLCheqDFec);
                  GXUtil.WriteLogRaw("Current: ",T00092_A558CLCheqDFec[0]);
               }
               if ( Z561CLCheqDForCod != T00092_A561CLCheqDForCod[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDForCod");
                  GXUtil.WriteLogRaw("Old: ",Z561CLCheqDForCod);
                  GXUtil.WriteLogRaw("Current: ",T00092_A561CLCheqDForCod[0]);
               }
               if ( Z566CLCheqDTipCmb != T00092_A566CLCheqDTipCmb[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z566CLCheqDTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T00092_A566CLCheqDTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z564CLCheqDSts, T00092_A564CLCheqDSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDSts");
                  GXUtil.WriteLogRaw("Old: ",Z564CLCheqDSts);
                  GXUtil.WriteLogRaw("Current: ",T00092_A564CLCheqDSts[0]);
               }
               if ( Z563CLCheqDImporte != T00092_A563CLCheqDImporte[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDImporte");
                  GXUtil.WriteLogRaw("Old: ",Z563CLCheqDImporte);
                  GXUtil.WriteLogRaw("Current: ",T00092_A563CLCheqDImporte[0]);
               }
               if ( Z570CLCheqDVouAno != T00092_A570CLCheqDVouAno[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z570CLCheqDVouAno);
                  GXUtil.WriteLogRaw("Current: ",T00092_A570CLCheqDVouAno[0]);
               }
               if ( Z571CLCheqDVouMes != T00092_A571CLCheqDVouMes[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z571CLCheqDVouMes);
                  GXUtil.WriteLogRaw("Current: ",T00092_A571CLCheqDVouMes[0]);
               }
               if ( Z565CLCheqDTasiCod != T00092_A565CLCheqDTasiCod[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z565CLCheqDTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T00092_A565CLCheqDTasiCod[0]);
               }
               if ( StringUtil.StrCmp(Z572CLCheqDVouNum, T00092_A572CLCheqDVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z572CLCheqDVouNum);
                  GXUtil.WriteLogRaw("Current: ",T00092_A572CLCheqDVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z568CLCheqDUsuCod, T00092_A568CLCheqDUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z568CLCheqDUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T00092_A568CLCheqDUsuCod[0]);
               }
               if ( Z569CLCheqDUsuFec != T00092_A569CLCheqDUsuFec[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z569CLCheqDUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T00092_A569CLCheqDUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z152CLCheqDCliCod, T00092_A152CLCheqDCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z152CLCheqDCliCod);
                  GXUtil.WriteLogRaw("Current: ",T00092_A152CLCheqDCliCod[0]);
               }
               if ( Z151CLCheqDMonCod != T00092_A151CLCheqDMonCod[0] )
               {
                  GXUtil.WriteLog("clchequediferido:[seudo value changed for attri]"+"CLCheqDMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z151CLCheqDMonCod);
                  GXUtil.WriteLogRaw("Current: ",T00092_A151CLCheqDMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCHEQUEDIFERIDO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A150CLCheqDCod, A558CLCheqDFec, A561CLCheqDForCod, A566CLCheqDTipCmb, A564CLCheqDSts, A563CLCheqDImporte, A570CLCheqDVouAno, A571CLCheqDVouMes, A565CLCheqDTasiCod, A572CLCheqDVouNum, A568CLCheqDUsuCod, A569CLCheqDUsuFec, A152CLCheqDCliCod, A151CLCheqDMonCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCHEQUEDIFERIDO");
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
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000913 */
                     pr_default.execute(11, new Object[] {A558CLCheqDFec, A561CLCheqDForCod, A566CLCheqDTipCmb, A564CLCheqDSts, A563CLCheqDImporte, A570CLCheqDVouAno, A571CLCheqDVouMes, A565CLCheqDTasiCod, A572CLCheqDVouNum, A568CLCheqDUsuCod, A569CLCheqDUsuFec, A152CLCheqDCliCod, A151CLCheqDMonCod, A150CLCheqDCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCHEQUEDIFERIDO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCHEQUEDIFERIDO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000914 */
                  pr_default.execute(12, new Object[] {A150CLCheqDCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCHEQUEDIFERIDO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll099( ) ;
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
                        ResetCaption090( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000915 */
            pr_default.execute(13, new Object[] {A152CLCheqDCliCod});
            A556CLCheqDCliDsc = T000915_A556CLCheqDCliDsc[0];
            AssignAttri("", false, "A556CLCheqDCliDsc", A556CLCheqDCliDsc);
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000916 */
            pr_default.execute(14, new Object[] {A150CLCheqDCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQDIFERIDODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("clchequediferido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("clchequediferido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Using cursor T000917 */
         pr_default.execute(15);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A150CLCheqDCod = T000917_A150CLCheqDCod[0];
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A150CLCheqDCod = T000917_A150CLCheqDCod[0];
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtCLCheqDCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDCod_Enabled), 5, 0), true);
         edtCLCheqDCliCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDCliCod_Enabled), 5, 0), true);
         edtCLCheqDCliDsc_Enabled = 0;
         AssignProp("", false, edtCLCheqDCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDCliDsc_Enabled), 5, 0), true);
         edtCLCheqDFec_Enabled = 0;
         AssignProp("", false, edtCLCheqDFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDFec_Enabled), 5, 0), true);
         edtCLCheqDForCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDForCod_Enabled), 5, 0), true);
         edtCLCheqDTipCmb_Enabled = 0;
         AssignProp("", false, edtCLCheqDTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDTipCmb_Enabled), 5, 0), true);
         edtCLCheqDSts_Enabled = 0;
         AssignProp("", false, edtCLCheqDSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDSts_Enabled), 5, 0), true);
         edtCLCheqDMonCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDMonCod_Enabled), 5, 0), true);
         edtCLCheqDImporte_Enabled = 0;
         AssignProp("", false, edtCLCheqDImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDImporte_Enabled), 5, 0), true);
         edtCLCheqDVouAno_Enabled = 0;
         AssignProp("", false, edtCLCheqDVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDVouAno_Enabled), 5, 0), true);
         edtCLCheqDVouMes_Enabled = 0;
         AssignProp("", false, edtCLCheqDVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDVouMes_Enabled), 5, 0), true);
         edtCLCheqDTasiCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDTasiCod_Enabled), 5, 0), true);
         edtCLCheqDVouNum_Enabled = 0;
         AssignProp("", false, edtCLCheqDVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDVouNum_Enabled), 5, 0), true);
         edtCLCheqDUsuCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDUsuCod_Enabled), 5, 0), true);
         edtCLCheqDUsuFec_Enabled = 0;
         AssignProp("", false, edtCLCheqDUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDUsuFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816421510", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clchequediferido.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z150CLCheqDCod", StringUtil.RTrim( Z150CLCheqDCod));
         GxWebStd.gx_hidden_field( context, "Z558CLCheqDFec", context.localUtil.DToC( Z558CLCheqDFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z561CLCheqDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z561CLCheqDForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z566CLCheqDTipCmb", StringUtil.LTrim( StringUtil.NToC( Z566CLCheqDTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z564CLCheqDSts", StringUtil.RTrim( Z564CLCheqDSts));
         GxWebStd.gx_hidden_field( context, "Z563CLCheqDImporte", StringUtil.LTrim( StringUtil.NToC( Z563CLCheqDImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z570CLCheqDVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z570CLCheqDVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z571CLCheqDVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z571CLCheqDVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z565CLCheqDTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z565CLCheqDTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z572CLCheqDVouNum", StringUtil.RTrim( Z572CLCheqDVouNum));
         GxWebStd.gx_hidden_field( context, "Z568CLCheqDUsuCod", StringUtil.RTrim( Z568CLCheqDUsuCod));
         GxWebStd.gx_hidden_field( context, "Z569CLCheqDUsuFec", context.localUtil.TToC( Z569CLCheqDUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z152CLCheqDCliCod", StringUtil.RTrim( Z152CLCheqDCliCod));
         GxWebStd.gx_hidden_field( context, "Z151CLCheqDMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z151CLCheqDMonCod), 6, 0, ".", "")));
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
         return formatLink("clchequediferido.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCHEQUEDIFERIDO" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLCHEQUEDIFERIDO" ;
      }

      protected void InitializeNonKey099( )
      {
         A152CLCheqDCliCod = "";
         AssignAttri("", false, "A152CLCheqDCliCod", A152CLCheqDCliCod);
         A556CLCheqDCliDsc = "";
         AssignAttri("", false, "A556CLCheqDCliDsc", A556CLCheqDCliDsc);
         A558CLCheqDFec = DateTime.MinValue;
         AssignAttri("", false, "A558CLCheqDFec", context.localUtil.Format(A558CLCheqDFec, "99/99/99"));
         A561CLCheqDForCod = 0;
         AssignAttri("", false, "A561CLCheqDForCod", StringUtil.LTrimStr( (decimal)(A561CLCheqDForCod), 6, 0));
         A566CLCheqDTipCmb = 0;
         AssignAttri("", false, "A566CLCheqDTipCmb", StringUtil.LTrimStr( A566CLCheqDTipCmb, 15, 5));
         A564CLCheqDSts = "";
         AssignAttri("", false, "A564CLCheqDSts", A564CLCheqDSts);
         A151CLCheqDMonCod = 0;
         AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrimStr( (decimal)(A151CLCheqDMonCod), 6, 0));
         A563CLCheqDImporte = 0;
         AssignAttri("", false, "A563CLCheqDImporte", StringUtil.LTrimStr( A563CLCheqDImporte, 15, 2));
         A570CLCheqDVouAno = 0;
         AssignAttri("", false, "A570CLCheqDVouAno", StringUtil.LTrimStr( (decimal)(A570CLCheqDVouAno), 4, 0));
         A571CLCheqDVouMes = 0;
         AssignAttri("", false, "A571CLCheqDVouMes", StringUtil.LTrimStr( (decimal)(A571CLCheqDVouMes), 2, 0));
         A565CLCheqDTasiCod = 0;
         AssignAttri("", false, "A565CLCheqDTasiCod", StringUtil.LTrimStr( (decimal)(A565CLCheqDTasiCod), 6, 0));
         A572CLCheqDVouNum = "";
         AssignAttri("", false, "A572CLCheqDVouNum", A572CLCheqDVouNum);
         A568CLCheqDUsuCod = "";
         AssignAttri("", false, "A568CLCheqDUsuCod", A568CLCheqDUsuCod);
         A569CLCheqDUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A569CLCheqDUsuFec", context.localUtil.TToC( A569CLCheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
         Z558CLCheqDFec = DateTime.MinValue;
         Z561CLCheqDForCod = 0;
         Z566CLCheqDTipCmb = 0;
         Z564CLCheqDSts = "";
         Z563CLCheqDImporte = 0;
         Z570CLCheqDVouAno = 0;
         Z571CLCheqDVouMes = 0;
         Z565CLCheqDTasiCod = 0;
         Z572CLCheqDVouNum = "";
         Z568CLCheqDUsuCod = "";
         Z569CLCheqDUsuFec = (DateTime)(DateTime.MinValue);
         Z152CLCheqDCliCod = "";
         Z151CLCheqDMonCod = 0;
      }

      protected void InitAll099( )
      {
         A150CLCheqDCod = "";
         AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
         InitializeNonKey099( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816421526", true, true);
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
         context.AddJavascriptSource("clchequediferido.js", "?202281816421528", false, true);
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
         edtCLCheqDCod_Internalname = "CLCHEQDCOD";
         edtCLCheqDCliCod_Internalname = "CLCHEQDCLICOD";
         edtCLCheqDCliDsc_Internalname = "CLCHEQDCLIDSC";
         edtCLCheqDFec_Internalname = "CLCHEQDFEC";
         edtCLCheqDForCod_Internalname = "CLCHEQDFORCOD";
         edtCLCheqDTipCmb_Internalname = "CLCHEQDTIPCMB";
         edtCLCheqDSts_Internalname = "CLCHEQDSTS";
         edtCLCheqDMonCod_Internalname = "CLCHEQDMONCOD";
         edtCLCheqDImporte_Internalname = "CLCHEQDIMPORTE";
         edtCLCheqDVouAno_Internalname = "CLCHEQDVOUANO";
         edtCLCheqDVouMes_Internalname = "CLCHEQDVOUMES";
         edtCLCheqDTasiCod_Internalname = "CLCHEQDTASICOD";
         edtCLCheqDVouNum_Internalname = "CLCHEQDVOUNUM";
         edtCLCheqDUsuCod_Internalname = "CLCHEQDUSUCOD";
         edtCLCheqDUsuFec_Internalname = "CLCHEQDUSUFEC";
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
         Form.Caption = "CLCHEQUEDIFERIDO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCLCheqDUsuFec_Jsonclick = "";
         edtCLCheqDUsuFec_Enabled = 1;
         edtCLCheqDUsuCod_Jsonclick = "";
         edtCLCheqDUsuCod_Enabled = 1;
         edtCLCheqDVouNum_Jsonclick = "";
         edtCLCheqDVouNum_Enabled = 1;
         edtCLCheqDTasiCod_Jsonclick = "";
         edtCLCheqDTasiCod_Enabled = 1;
         edtCLCheqDVouMes_Jsonclick = "";
         edtCLCheqDVouMes_Enabled = 1;
         edtCLCheqDVouAno_Jsonclick = "";
         edtCLCheqDVouAno_Enabled = 1;
         edtCLCheqDImporte_Jsonclick = "";
         edtCLCheqDImporte_Enabled = 1;
         edtCLCheqDMonCod_Jsonclick = "";
         edtCLCheqDMonCod_Enabled = 1;
         edtCLCheqDSts_Jsonclick = "";
         edtCLCheqDSts_Enabled = 1;
         edtCLCheqDTipCmb_Jsonclick = "";
         edtCLCheqDTipCmb_Enabled = 1;
         edtCLCheqDForCod_Jsonclick = "";
         edtCLCheqDForCod_Enabled = 1;
         edtCLCheqDFec_Jsonclick = "";
         edtCLCheqDFec_Enabled = 1;
         edtCLCheqDCliDsc_Jsonclick = "";
         edtCLCheqDCliDsc_Enabled = 0;
         edtCLCheqDCliCod_Jsonclick = "";
         edtCLCheqDCliCod_Enabled = 1;
         edtCLCheqDCod_Jsonclick = "";
         edtCLCheqDCod_Enabled = 1;
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
         GX_FocusControl = edtCLCheqDCliCod_Internalname;
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

      public void Valid_Clcheqdcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A152CLCheqDCliCod", StringUtil.RTrim( A152CLCheqDCliCod));
         AssignAttri("", false, "A558CLCheqDFec", context.localUtil.Format(A558CLCheqDFec, "99/99/99"));
         AssignAttri("", false, "A561CLCheqDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A561CLCheqDForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A566CLCheqDTipCmb", StringUtil.LTrim( StringUtil.NToC( A566CLCheqDTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A564CLCheqDSts", StringUtil.RTrim( A564CLCheqDSts));
         AssignAttri("", false, "A151CLCheqDMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151CLCheqDMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A563CLCheqDImporte", StringUtil.LTrim( StringUtil.NToC( A563CLCheqDImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A570CLCheqDVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A570CLCheqDVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A571CLCheqDVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A571CLCheqDVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A565CLCheqDTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A565CLCheqDTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A572CLCheqDVouNum", StringUtil.RTrim( A572CLCheqDVouNum));
         AssignAttri("", false, "A568CLCheqDUsuCod", StringUtil.RTrim( A568CLCheqDUsuCod));
         AssignAttri("", false, "A569CLCheqDUsuFec", context.localUtil.TToC( A569CLCheqDUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A556CLCheqDCliDsc", StringUtil.RTrim( A556CLCheqDCliDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z150CLCheqDCod", StringUtil.RTrim( Z150CLCheqDCod));
         GxWebStd.gx_hidden_field( context, "Z152CLCheqDCliCod", StringUtil.RTrim( Z152CLCheqDCliCod));
         GxWebStd.gx_hidden_field( context, "Z558CLCheqDFec", context.localUtil.Format(Z558CLCheqDFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z561CLCheqDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z561CLCheqDForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z566CLCheqDTipCmb", StringUtil.LTrim( StringUtil.NToC( Z566CLCheqDTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z564CLCheqDSts", StringUtil.RTrim( Z564CLCheqDSts));
         GxWebStd.gx_hidden_field( context, "Z151CLCheqDMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z151CLCheqDMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z563CLCheqDImporte", StringUtil.LTrim( StringUtil.NToC( Z563CLCheqDImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z570CLCheqDVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z570CLCheqDVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z571CLCheqDVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z571CLCheqDVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z565CLCheqDTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z565CLCheqDTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z572CLCheqDVouNum", StringUtil.RTrim( Z572CLCheqDVouNum));
         GxWebStd.gx_hidden_field( context, "Z568CLCheqDUsuCod", StringUtil.RTrim( Z568CLCheqDUsuCod));
         GxWebStd.gx_hidden_field( context, "Z569CLCheqDUsuFec", context.localUtil.TToC( Z569CLCheqDUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z556CLCheqDCliDsc", StringUtil.RTrim( Z556CLCheqDCliDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clcheqdclicod( )
      {
         /* Using cursor T000915 */
         pr_default.execute(13, new Object[] {A152CLCheqDCliCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLCHEQDCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCliCod_Internalname;
         }
         A556CLCheqDCliDsc = T000915_A556CLCheqDCliDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A556CLCheqDCliDsc", StringUtil.RTrim( A556CLCheqDCliDsc));
      }

      public void Valid_Clcheqdmoncod( )
      {
         /* Using cursor T000918 */
         pr_default.execute(16, new Object[] {A151CLCheqDMonCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CLCHEQDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDMonCod_Internalname;
         }
         pr_default.close(16);
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
         setEventMetadata("VALID_CLCHEQDCOD","{handler:'Valid_Clcheqdcod',iparms:[{av:'A150CLCheqDCod',fld:'CLCHEQDCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLCHEQDCOD",",oparms:[{av:'A152CLCheqDCliCod',fld:'CLCHEQDCLICOD',pic:''},{av:'A558CLCheqDFec',fld:'CLCHEQDFEC',pic:''},{av:'A561CLCheqDForCod',fld:'CLCHEQDFORCOD',pic:'ZZZZZ9'},{av:'A566CLCheqDTipCmb',fld:'CLCHEQDTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A564CLCheqDSts',fld:'CLCHEQDSTS',pic:''},{av:'A151CLCheqDMonCod',fld:'CLCHEQDMONCOD',pic:'ZZZZZ9'},{av:'A563CLCheqDImporte',fld:'CLCHEQDIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A570CLCheqDVouAno',fld:'CLCHEQDVOUANO',pic:'ZZZ9'},{av:'A571CLCheqDVouMes',fld:'CLCHEQDVOUMES',pic:'Z9'},{av:'A565CLCheqDTasiCod',fld:'CLCHEQDTASICOD',pic:'ZZZZZ9'},{av:'A572CLCheqDVouNum',fld:'CLCHEQDVOUNUM',pic:''},{av:'A568CLCheqDUsuCod',fld:'CLCHEQDUSUCOD',pic:''},{av:'A569CLCheqDUsuFec',fld:'CLCHEQDUSUFEC',pic:'99/99/99 99:99'},{av:'A556CLCheqDCliDsc',fld:'CLCHEQDCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z150CLCheqDCod'},{av:'Z152CLCheqDCliCod'},{av:'Z558CLCheqDFec'},{av:'Z561CLCheqDForCod'},{av:'Z566CLCheqDTipCmb'},{av:'Z564CLCheqDSts'},{av:'Z151CLCheqDMonCod'},{av:'Z563CLCheqDImporte'},{av:'Z570CLCheqDVouAno'},{av:'Z571CLCheqDVouMes'},{av:'Z565CLCheqDTasiCod'},{av:'Z572CLCheqDVouNum'},{av:'Z568CLCheqDUsuCod'},{av:'Z569CLCheqDUsuFec'},{av:'Z556CLCheqDCliDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLCHEQDCLICOD","{handler:'Valid_Clcheqdclicod',iparms:[{av:'A152CLCheqDCliCod',fld:'CLCHEQDCLICOD',pic:''},{av:'A556CLCheqDCliDsc',fld:'CLCHEQDCLIDSC',pic:''}]");
         setEventMetadata("VALID_CLCHEQDCLICOD",",oparms:[{av:'A556CLCheqDCliDsc',fld:'CLCHEQDCLIDSC',pic:''}]}");
         setEventMetadata("VALID_CLCHEQDFEC","{handler:'Valid_Clcheqdfec',iparms:[]");
         setEventMetadata("VALID_CLCHEQDFEC",",oparms:[]}");
         setEventMetadata("VALID_CLCHEQDMONCOD","{handler:'Valid_Clcheqdmoncod',iparms:[{av:'A151CLCheqDMonCod',fld:'CLCHEQDMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CLCHEQDMONCOD",",oparms:[]}");
         setEventMetadata("VALID_CLCHEQDUSUFEC","{handler:'Valid_Clcheqdusufec',iparms:[]");
         setEventMetadata("VALID_CLCHEQDUSUFEC",",oparms:[]}");
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
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z150CLCheqDCod = "";
         Z558CLCheqDFec = DateTime.MinValue;
         Z564CLCheqDSts = "";
         Z572CLCheqDVouNum = "";
         Z568CLCheqDUsuCod = "";
         Z569CLCheqDUsuFec = (DateTime)(DateTime.MinValue);
         Z152CLCheqDCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A152CLCheqDCliCod = "";
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
         A150CLCheqDCod = "";
         A556CLCheqDCliDsc = "";
         A558CLCheqDFec = DateTime.MinValue;
         A564CLCheqDSts = "";
         A572CLCheqDVouNum = "";
         A568CLCheqDUsuCod = "";
         A569CLCheqDUsuFec = (DateTime)(DateTime.MinValue);
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
         Z556CLCheqDCliDsc = "";
         T00096_A150CLCheqDCod = new string[] {""} ;
         T00096_A556CLCheqDCliDsc = new string[] {""} ;
         T00096_A558CLCheqDFec = new DateTime[] {DateTime.MinValue} ;
         T00096_A561CLCheqDForCod = new int[1] ;
         T00096_A566CLCheqDTipCmb = new decimal[1] ;
         T00096_A564CLCheqDSts = new string[] {""} ;
         T00096_A563CLCheqDImporte = new decimal[1] ;
         T00096_A570CLCheqDVouAno = new short[1] ;
         T00096_A571CLCheqDVouMes = new short[1] ;
         T00096_A565CLCheqDTasiCod = new int[1] ;
         T00096_A572CLCheqDVouNum = new string[] {""} ;
         T00096_A568CLCheqDUsuCod = new string[] {""} ;
         T00096_A569CLCheqDUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00096_A152CLCheqDCliCod = new string[] {""} ;
         T00096_A151CLCheqDMonCod = new int[1] ;
         T00094_A556CLCheqDCliDsc = new string[] {""} ;
         T00095_A151CLCheqDMonCod = new int[1] ;
         T00097_A556CLCheqDCliDsc = new string[] {""} ;
         T00098_A151CLCheqDMonCod = new int[1] ;
         T00099_A150CLCheqDCod = new string[] {""} ;
         T00093_A150CLCheqDCod = new string[] {""} ;
         T00093_A558CLCheqDFec = new DateTime[] {DateTime.MinValue} ;
         T00093_A561CLCheqDForCod = new int[1] ;
         T00093_A566CLCheqDTipCmb = new decimal[1] ;
         T00093_A564CLCheqDSts = new string[] {""} ;
         T00093_A563CLCheqDImporte = new decimal[1] ;
         T00093_A570CLCheqDVouAno = new short[1] ;
         T00093_A571CLCheqDVouMes = new short[1] ;
         T00093_A565CLCheqDTasiCod = new int[1] ;
         T00093_A572CLCheqDVouNum = new string[] {""} ;
         T00093_A568CLCheqDUsuCod = new string[] {""} ;
         T00093_A569CLCheqDUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00093_A152CLCheqDCliCod = new string[] {""} ;
         T00093_A151CLCheqDMonCod = new int[1] ;
         sMode9 = "";
         T000910_A150CLCheqDCod = new string[] {""} ;
         T000911_A150CLCheqDCod = new string[] {""} ;
         T00092_A150CLCheqDCod = new string[] {""} ;
         T00092_A558CLCheqDFec = new DateTime[] {DateTime.MinValue} ;
         T00092_A561CLCheqDForCod = new int[1] ;
         T00092_A566CLCheqDTipCmb = new decimal[1] ;
         T00092_A564CLCheqDSts = new string[] {""} ;
         T00092_A563CLCheqDImporte = new decimal[1] ;
         T00092_A570CLCheqDVouAno = new short[1] ;
         T00092_A571CLCheqDVouMes = new short[1] ;
         T00092_A565CLCheqDTasiCod = new int[1] ;
         T00092_A572CLCheqDVouNum = new string[] {""} ;
         T00092_A568CLCheqDUsuCod = new string[] {""} ;
         T00092_A569CLCheqDUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00092_A152CLCheqDCliCod = new string[] {""} ;
         T00092_A151CLCheqDMonCod = new int[1] ;
         T000915_A556CLCheqDCliDsc = new string[] {""} ;
         T000916_A150CLCheqDCod = new string[] {""} ;
         T000916_A153CLCheqDItem = new int[1] ;
         T000917_A150CLCheqDCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ150CLCheqDCod = "";
         ZZ152CLCheqDCliCod = "";
         ZZ558CLCheqDFec = DateTime.MinValue;
         ZZ564CLCheqDSts = "";
         ZZ572CLCheqDVouNum = "";
         ZZ568CLCheqDUsuCod = "";
         ZZ569CLCheqDUsuFec = (DateTime)(DateTime.MinValue);
         ZZ556CLCheqDCliDsc = "";
         T000918_A151CLCheqDMonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clchequediferido__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clchequediferido__default(),
            new Object[][] {
                new Object[] {
               T00092_A150CLCheqDCod, T00092_A558CLCheqDFec, T00092_A561CLCheqDForCod, T00092_A566CLCheqDTipCmb, T00092_A564CLCheqDSts, T00092_A563CLCheqDImporte, T00092_A570CLCheqDVouAno, T00092_A571CLCheqDVouMes, T00092_A565CLCheqDTasiCod, T00092_A572CLCheqDVouNum,
               T00092_A568CLCheqDUsuCod, T00092_A569CLCheqDUsuFec, T00092_A152CLCheqDCliCod, T00092_A151CLCheqDMonCod
               }
               , new Object[] {
               T00093_A150CLCheqDCod, T00093_A558CLCheqDFec, T00093_A561CLCheqDForCod, T00093_A566CLCheqDTipCmb, T00093_A564CLCheqDSts, T00093_A563CLCheqDImporte, T00093_A570CLCheqDVouAno, T00093_A571CLCheqDVouMes, T00093_A565CLCheqDTasiCod, T00093_A572CLCheqDVouNum,
               T00093_A568CLCheqDUsuCod, T00093_A569CLCheqDUsuFec, T00093_A152CLCheqDCliCod, T00093_A151CLCheqDMonCod
               }
               , new Object[] {
               T00094_A556CLCheqDCliDsc
               }
               , new Object[] {
               T00095_A151CLCheqDMonCod
               }
               , new Object[] {
               T00096_A150CLCheqDCod, T00096_A556CLCheqDCliDsc, T00096_A558CLCheqDFec, T00096_A561CLCheqDForCod, T00096_A566CLCheqDTipCmb, T00096_A564CLCheqDSts, T00096_A563CLCheqDImporte, T00096_A570CLCheqDVouAno, T00096_A571CLCheqDVouMes, T00096_A565CLCheqDTasiCod,
               T00096_A572CLCheqDVouNum, T00096_A568CLCheqDUsuCod, T00096_A569CLCheqDUsuFec, T00096_A152CLCheqDCliCod, T00096_A151CLCheqDMonCod
               }
               , new Object[] {
               T00097_A556CLCheqDCliDsc
               }
               , new Object[] {
               T00098_A151CLCheqDMonCod
               }
               , new Object[] {
               T00099_A150CLCheqDCod
               }
               , new Object[] {
               T000910_A150CLCheqDCod
               }
               , new Object[] {
               T000911_A150CLCheqDCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000915_A556CLCheqDCliDsc
               }
               , new Object[] {
               T000916_A150CLCheqDCod, T000916_A153CLCheqDItem
               }
               , new Object[] {
               T000917_A150CLCheqDCod
               }
               , new Object[] {
               T000918_A151CLCheqDMonCod
               }
            }
         );
      }

      private short Z570CLCheqDVouAno ;
      private short Z571CLCheqDVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A570CLCheqDVouAno ;
      private short A571CLCheqDVouMes ;
      private short GX_JID ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ570CLCheqDVouAno ;
      private short ZZ571CLCheqDVouMes ;
      private int Z561CLCheqDForCod ;
      private int Z565CLCheqDTasiCod ;
      private int Z151CLCheqDMonCod ;
      private int A151CLCheqDMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCLCheqDCod_Enabled ;
      private int edtCLCheqDCliCod_Enabled ;
      private int edtCLCheqDCliDsc_Enabled ;
      private int edtCLCheqDFec_Enabled ;
      private int A561CLCheqDForCod ;
      private int edtCLCheqDForCod_Enabled ;
      private int edtCLCheqDTipCmb_Enabled ;
      private int edtCLCheqDSts_Enabled ;
      private int edtCLCheqDMonCod_Enabled ;
      private int edtCLCheqDImporte_Enabled ;
      private int edtCLCheqDVouAno_Enabled ;
      private int edtCLCheqDVouMes_Enabled ;
      private int A565CLCheqDTasiCod ;
      private int edtCLCheqDTasiCod_Enabled ;
      private int edtCLCheqDVouNum_Enabled ;
      private int edtCLCheqDUsuCod_Enabled ;
      private int edtCLCheqDUsuFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ561CLCheqDForCod ;
      private int ZZ151CLCheqDMonCod ;
      private int ZZ565CLCheqDTasiCod ;
      private decimal Z566CLCheqDTipCmb ;
      private decimal Z563CLCheqDImporte ;
      private decimal A566CLCheqDTipCmb ;
      private decimal A563CLCheqDImporte ;
      private decimal ZZ566CLCheqDTipCmb ;
      private decimal ZZ563CLCheqDImporte ;
      private string sPrefix ;
      private string Z150CLCheqDCod ;
      private string Z564CLCheqDSts ;
      private string Z572CLCheqDVouNum ;
      private string Z568CLCheqDUsuCod ;
      private string Z152CLCheqDCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A152CLCheqDCliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCLCheqDCod_Internalname ;
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
      private string A150CLCheqDCod ;
      private string edtCLCheqDCod_Jsonclick ;
      private string edtCLCheqDCliCod_Internalname ;
      private string edtCLCheqDCliCod_Jsonclick ;
      private string edtCLCheqDCliDsc_Internalname ;
      private string A556CLCheqDCliDsc ;
      private string edtCLCheqDCliDsc_Jsonclick ;
      private string edtCLCheqDFec_Internalname ;
      private string edtCLCheqDFec_Jsonclick ;
      private string edtCLCheqDForCod_Internalname ;
      private string edtCLCheqDForCod_Jsonclick ;
      private string edtCLCheqDTipCmb_Internalname ;
      private string edtCLCheqDTipCmb_Jsonclick ;
      private string edtCLCheqDSts_Internalname ;
      private string A564CLCheqDSts ;
      private string edtCLCheqDSts_Jsonclick ;
      private string edtCLCheqDMonCod_Internalname ;
      private string edtCLCheqDMonCod_Jsonclick ;
      private string edtCLCheqDImporte_Internalname ;
      private string edtCLCheqDImporte_Jsonclick ;
      private string edtCLCheqDVouAno_Internalname ;
      private string edtCLCheqDVouAno_Jsonclick ;
      private string edtCLCheqDVouMes_Internalname ;
      private string edtCLCheqDVouMes_Jsonclick ;
      private string edtCLCheqDTasiCod_Internalname ;
      private string edtCLCheqDTasiCod_Jsonclick ;
      private string edtCLCheqDVouNum_Internalname ;
      private string A572CLCheqDVouNum ;
      private string edtCLCheqDVouNum_Jsonclick ;
      private string edtCLCheqDUsuCod_Internalname ;
      private string A568CLCheqDUsuCod ;
      private string edtCLCheqDUsuCod_Jsonclick ;
      private string edtCLCheqDUsuFec_Internalname ;
      private string edtCLCheqDUsuFec_Jsonclick ;
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
      private string Z556CLCheqDCliDsc ;
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ150CLCheqDCod ;
      private string ZZ152CLCheqDCliCod ;
      private string ZZ564CLCheqDSts ;
      private string ZZ572CLCheqDVouNum ;
      private string ZZ568CLCheqDUsuCod ;
      private string ZZ556CLCheqDCliDsc ;
      private DateTime Z569CLCheqDUsuFec ;
      private DateTime A569CLCheqDUsuFec ;
      private DateTime ZZ569CLCheqDUsuFec ;
      private DateTime Z558CLCheqDFec ;
      private DateTime A558CLCheqDFec ;
      private DateTime ZZ558CLCheqDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00096_A150CLCheqDCod ;
      private string[] T00096_A556CLCheqDCliDsc ;
      private DateTime[] T00096_A558CLCheqDFec ;
      private int[] T00096_A561CLCheqDForCod ;
      private decimal[] T00096_A566CLCheqDTipCmb ;
      private string[] T00096_A564CLCheqDSts ;
      private decimal[] T00096_A563CLCheqDImporte ;
      private short[] T00096_A570CLCheqDVouAno ;
      private short[] T00096_A571CLCheqDVouMes ;
      private int[] T00096_A565CLCheqDTasiCod ;
      private string[] T00096_A572CLCheqDVouNum ;
      private string[] T00096_A568CLCheqDUsuCod ;
      private DateTime[] T00096_A569CLCheqDUsuFec ;
      private string[] T00096_A152CLCheqDCliCod ;
      private int[] T00096_A151CLCheqDMonCod ;
      private string[] T00094_A556CLCheqDCliDsc ;
      private int[] T00095_A151CLCheqDMonCod ;
      private string[] T00097_A556CLCheqDCliDsc ;
      private int[] T00098_A151CLCheqDMonCod ;
      private string[] T00099_A150CLCheqDCod ;
      private string[] T00093_A150CLCheqDCod ;
      private DateTime[] T00093_A558CLCheqDFec ;
      private int[] T00093_A561CLCheqDForCod ;
      private decimal[] T00093_A566CLCheqDTipCmb ;
      private string[] T00093_A564CLCheqDSts ;
      private decimal[] T00093_A563CLCheqDImporte ;
      private short[] T00093_A570CLCheqDVouAno ;
      private short[] T00093_A571CLCheqDVouMes ;
      private int[] T00093_A565CLCheqDTasiCod ;
      private string[] T00093_A572CLCheqDVouNum ;
      private string[] T00093_A568CLCheqDUsuCod ;
      private DateTime[] T00093_A569CLCheqDUsuFec ;
      private string[] T00093_A152CLCheqDCliCod ;
      private int[] T00093_A151CLCheqDMonCod ;
      private string[] T000910_A150CLCheqDCod ;
      private string[] T000911_A150CLCheqDCod ;
      private string[] T00092_A150CLCheqDCod ;
      private DateTime[] T00092_A558CLCheqDFec ;
      private int[] T00092_A561CLCheqDForCod ;
      private decimal[] T00092_A566CLCheqDTipCmb ;
      private string[] T00092_A564CLCheqDSts ;
      private decimal[] T00092_A563CLCheqDImporte ;
      private short[] T00092_A570CLCheqDVouAno ;
      private short[] T00092_A571CLCheqDVouMes ;
      private int[] T00092_A565CLCheqDTasiCod ;
      private string[] T00092_A572CLCheqDVouNum ;
      private string[] T00092_A568CLCheqDUsuCod ;
      private DateTime[] T00092_A569CLCheqDUsuFec ;
      private string[] T00092_A152CLCheqDCliCod ;
      private int[] T00092_A151CLCheqDMonCod ;
      private string[] T000915_A556CLCheqDCliDsc ;
      private string[] T000916_A150CLCheqDCod ;
      private int[] T000916_A153CLCheqDItem ;
      private string[] T000917_A150CLCheqDCod ;
      private int[] T000918_A151CLCheqDMonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clchequediferido__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clchequediferido__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00096;
        prmT00096 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT00094;
        prmT00094 = new Object[] {
        new ParDef("@CLCheqDCliCod",GXType.NChar,20,0)
        };
        Object[] prmT00095;
        prmT00095 = new Object[] {
        new ParDef("@CLCheqDMonCod",GXType.Int32,6,0)
        };
        Object[] prmT00097;
        prmT00097 = new Object[] {
        new ParDef("@CLCheqDCliCod",GXType.NChar,20,0)
        };
        Object[] prmT00098;
        prmT00098 = new Object[] {
        new ParDef("@CLCheqDMonCod",GXType.Int32,6,0)
        };
        Object[] prmT00099;
        prmT00099 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT00093;
        prmT00093 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000910;
        prmT000910 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000911;
        prmT000911 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT00092;
        prmT00092 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000912;
        prmT000912 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDFec",GXType.Date,8,0) ,
        new ParDef("@CLCheqDForCod",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@CLCheqDSts",GXType.NChar,1,0) ,
        new ParDef("@CLCheqDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CLCheqDVouAno",GXType.Int16,4,0) ,
        new ParDef("@CLCheqDVouMes",GXType.Int16,2,0) ,
        new ParDef("@CLCheqDTasiCod",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDVouNum",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CLCheqDCliCod",GXType.NChar,20,0) ,
        new ParDef("@CLCheqDMonCod",GXType.Int32,6,0)
        };
        Object[] prmT000913;
        prmT000913 = new Object[] {
        new ParDef("@CLCheqDFec",GXType.Date,8,0) ,
        new ParDef("@CLCheqDForCod",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@CLCheqDSts",GXType.NChar,1,0) ,
        new ParDef("@CLCheqDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CLCheqDVouAno",GXType.Int16,4,0) ,
        new ParDef("@CLCheqDVouMes",GXType.Int16,2,0) ,
        new ParDef("@CLCheqDTasiCod",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDVouNum",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CLCheqDCliCod",GXType.NChar,20,0) ,
        new ParDef("@CLCheqDMonCod",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000914;
        prmT000914 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000916;
        prmT000916 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000917;
        prmT000917 = new Object[] {
        };
        Object[] prmT000915;
        prmT000915 = new Object[] {
        new ParDef("@CLCheqDCliCod",GXType.NChar,20,0)
        };
        Object[] prmT000918;
        prmT000918 = new Object[] {
        new ParDef("@CLCheqDMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00092", "SELECT [CLCheqDCod], [CLCheqDFec], [CLCheqDForCod], [CLCheqDTipCmb], [CLCheqDSts], [CLCheqDImporte], [CLCheqDVouAno], [CLCheqDVouMes], [CLCheqDTasiCod], [CLCheqDVouNum], [CLCheqDUsuCod], [CLCheqDUsuFec], [CLCheqDCliCod] AS CLCheqDCliCod, [CLCheqDMonCod] AS CLCheqDMonCod FROM [CLCHEQUEDIFERIDO] WITH (UPDLOCK) WHERE [CLCheqDCod] = @CLCheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00093", "SELECT [CLCheqDCod], [CLCheqDFec], [CLCheqDForCod], [CLCheqDTipCmb], [CLCheqDSts], [CLCheqDImporte], [CLCheqDVouAno], [CLCheqDVouMes], [CLCheqDTasiCod], [CLCheqDVouNum], [CLCheqDUsuCod], [CLCheqDUsuFec], [CLCheqDCliCod] AS CLCheqDCliCod, [CLCheqDMonCod] AS CLCheqDMonCod FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCod] = @CLCheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00094", "SELECT [CliDsc] AS CLCheqDCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @CLCheqDCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00095", "SELECT [MonCod] AS CLCheqDMonCod FROM [CMONEDAS] WHERE [MonCod] = @CLCheqDMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00096", "SELECT TM1.[CLCheqDCod], T2.[CliDsc] AS CLCheqDCliDsc, TM1.[CLCheqDFec], TM1.[CLCheqDForCod], TM1.[CLCheqDTipCmb], TM1.[CLCheqDSts], TM1.[CLCheqDImporte], TM1.[CLCheqDVouAno], TM1.[CLCheqDVouMes], TM1.[CLCheqDTasiCod], TM1.[CLCheqDVouNum], TM1.[CLCheqDUsuCod], TM1.[CLCheqDUsuFec], TM1.[CLCheqDCliCod] AS CLCheqDCliCod, TM1.[CLCheqDMonCod] AS CLCheqDMonCod FROM ([CLCHEQUEDIFERIDO] TM1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = TM1.[CLCheqDCliCod]) WHERE TM1.[CLCheqDCod] = @CLCheqDCod ORDER BY TM1.[CLCheqDCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00097", "SELECT [CliDsc] AS CLCheqDCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @CLCheqDCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00098", "SELECT [MonCod] AS CLCheqDMonCod FROM [CMONEDAS] WHERE [MonCod] = @CLCheqDMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00099", "SELECT [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCod] = @CLCheqDCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000910", "SELECT TOP 1 [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE ( [CLCheqDCod] > @CLCheqDCod) ORDER BY [CLCheqDCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000911", "SELECT TOP 1 [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE ( [CLCheqDCod] < @CLCheqDCod) ORDER BY [CLCheqDCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000912", "INSERT INTO [CLCHEQUEDIFERIDO]([CLCheqDCod], [CLCheqDFec], [CLCheqDForCod], [CLCheqDTipCmb], [CLCheqDSts], [CLCheqDImporte], [CLCheqDVouAno], [CLCheqDVouMes], [CLCheqDTasiCod], [CLCheqDVouNum], [CLCheqDUsuCod], [CLCheqDUsuFec], [CLCheqDCliCod], [CLCheqDMonCod]) VALUES(@CLCheqDCod, @CLCheqDFec, @CLCheqDForCod, @CLCheqDTipCmb, @CLCheqDSts, @CLCheqDImporte, @CLCheqDVouAno, @CLCheqDVouMes, @CLCheqDTasiCod, @CLCheqDVouNum, @CLCheqDUsuCod, @CLCheqDUsuFec, @CLCheqDCliCod, @CLCheqDMonCod)", GxErrorMask.GX_NOMASK,prmT000912)
           ,new CursorDef("T000913", "UPDATE [CLCHEQUEDIFERIDO] SET [CLCheqDFec]=@CLCheqDFec, [CLCheqDForCod]=@CLCheqDForCod, [CLCheqDTipCmb]=@CLCheqDTipCmb, [CLCheqDSts]=@CLCheqDSts, [CLCheqDImporte]=@CLCheqDImporte, [CLCheqDVouAno]=@CLCheqDVouAno, [CLCheqDVouMes]=@CLCheqDVouMes, [CLCheqDTasiCod]=@CLCheqDTasiCod, [CLCheqDVouNum]=@CLCheqDVouNum, [CLCheqDUsuCod]=@CLCheqDUsuCod, [CLCheqDUsuFec]=@CLCheqDUsuFec, [CLCheqDCliCod]=@CLCheqDCliCod, [CLCheqDMonCod]=@CLCheqDMonCod  WHERE [CLCheqDCod] = @CLCheqDCod", GxErrorMask.GX_NOMASK,prmT000913)
           ,new CursorDef("T000914", "DELETE FROM [CLCHEQUEDIFERIDO]  WHERE [CLCheqDCod] = @CLCheqDCod", GxErrorMask.GX_NOMASK,prmT000914)
           ,new CursorDef("T000915", "SELECT [CliDsc] AS CLCheqDCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @CLCheqDCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000916", "SELECT TOP 1 [CLCheqDCod], [CLCheqDItem] FROM [CLCHEQUEDIFERIDODET] WHERE [CLCheqDCod] = @CLCheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000917", "SELECT [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] ORDER BY [CLCheqDCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000918", "SELECT [MonCod] AS CLCheqDMonCod FROM [CMONEDAS] WHERE [MonCod] = @CLCheqDMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((int[]) buf[14])[0] = rslt.getInt(15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
