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
   public class cpchequediferido : GXDataArea
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
            A240CheqDPrvCod = GetPar( "CheqDPrvCod");
            AssignAttri("", false, "A240CheqDPrvCod", A240CheqDPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A240CheqDPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A239CheqDMonCod = (int)(NumberUtil.Val( GetPar( "CheqDMonCod"), "."));
            AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrimStr( (decimal)(A239CheqDMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A239CheqDMonCod) ;
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
            Form.Meta.addItem("description", "CPCHEQUEDIFERIDO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpchequediferido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpchequediferido( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CPCHEQUEDIFERIDO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDCod_Internalname, "Canje Cheque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDCod_Internalname, StringUtil.RTrim( A238CheqDCod), StringUtil.RTrim( context.localUtil.Format( A238CheqDCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDPrvCod_Internalname, "Proveedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDPrvCod_Internalname, StringUtil.RTrim( A240CheqDPrvCod), StringUtil.RTrim( context.localUtil.Format( A240CheqDPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDPrvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDPrvDsc_Internalname, "Proveedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCheqDPrvDsc_Internalname, StringUtil.RTrim( A531CheqDPrvDsc), StringUtil.RTrim( context.localUtil.Format( A531CheqDPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDFec_Internalname, "Canje", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCheqDFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCheqDFec_Internalname, context.localUtil.Format(A524CheqDFec, "99/99/99"), context.localUtil.Format( A524CheqDFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_bitmap( context, edtCheqDFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCheqDFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDForCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDForCod_Internalname, "Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A527CheqDForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCheqDForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A527CheqDForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A527CheqDForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDTipCmb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDTipCmb_Internalname, "de Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A534CheqDTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtCheqDTipCmb_Enabled!=0) ? context.localUtil.Format( A534CheqDTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A534CheqDTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDSts_Internalname, StringUtil.RTrim( A532CheqDSts), StringUtil.RTrim( context.localUtil.Format( A532CheqDSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A239CheqDMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCheqDMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A239CheqDMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A239CheqDMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDImporte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDImporte_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A529CheqDImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtCheqDImporte_Enabled!=0) ? context.localUtil.Format( A529CheqDImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A529CheqDImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A538CheqDVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCheqDVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A538CheqDVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A538CheqDVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A539CheqDVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCheqDVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A539CheqDVouMes), "Z9") : context.localUtil.Format( (decimal)(A539CheqDVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDTasiCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDTasiCod_Internalname, "de Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A533CheqDTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCheqDTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A533CheqDTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A533CheqDTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDVouNum_Internalname, "Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDVouNum_Internalname, StringUtil.RTrim( A540CheqDVouNum), StringUtil.RTrim( context.localUtil.Format( A540CheqDVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDUsuCod_Internalname, StringUtil.RTrim( A536CheqDUsuCod), StringUtil.RTrim( context.localUtil.Format( A536CheqDUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDUsuFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDUsuFec_Internalname, "Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCheqDUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCheqDUsuFec_Internalname, context.localUtil.TToC( A537CheqDUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A537CheqDUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_bitmap( context, edtCheqDUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCheqDUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCHEQUEDIFERIDO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDO.htm");
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
            Z238CheqDCod = cgiGet( "Z238CheqDCod");
            Z524CheqDFec = context.localUtil.CToD( cgiGet( "Z524CheqDFec"), 0);
            Z527CheqDForCod = (int)(context.localUtil.CToN( cgiGet( "Z527CheqDForCod"), ".", ","));
            Z534CheqDTipCmb = context.localUtil.CToN( cgiGet( "Z534CheqDTipCmb"), ".", ",");
            Z532CheqDSts = cgiGet( "Z532CheqDSts");
            Z529CheqDImporte = context.localUtil.CToN( cgiGet( "Z529CheqDImporte"), ".", ",");
            Z538CheqDVouAno = (short)(context.localUtil.CToN( cgiGet( "Z538CheqDVouAno"), ".", ","));
            Z539CheqDVouMes = (short)(context.localUtil.CToN( cgiGet( "Z539CheqDVouMes"), ".", ","));
            Z533CheqDTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z533CheqDTasiCod"), ".", ","));
            Z540CheqDVouNum = cgiGet( "Z540CheqDVouNum");
            Z536CheqDUsuCod = cgiGet( "Z536CheqDUsuCod");
            Z537CheqDUsuFec = context.localUtil.CToT( cgiGet( "Z537CheqDUsuFec"), 0);
            Z240CheqDPrvCod = cgiGet( "Z240CheqDPrvCod");
            Z239CheqDMonCod = (int)(context.localUtil.CToN( cgiGet( "Z239CheqDMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A238CheqDCod = cgiGet( edtCheqDCod_Internalname);
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            A240CheqDPrvCod = StringUtil.Upper( cgiGet( edtCheqDPrvCod_Internalname));
            AssignAttri("", false, "A240CheqDPrvCod", A240CheqDPrvCod);
            A531CheqDPrvDsc = cgiGet( edtCheqDPrvDsc_Internalname);
            AssignAttri("", false, "A531CheqDPrvDsc", A531CheqDPrvDsc);
            if ( context.localUtil.VCDate( cgiGet( edtCheqDFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Canje"}), 1, "CHEQDFEC");
               AnyError = 1;
               GX_FocusControl = edtCheqDFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A524CheqDFec = DateTime.MinValue;
               AssignAttri("", false, "A524CheqDFec", context.localUtil.Format(A524CheqDFec, "99/99/99"));
            }
            else
            {
               A524CheqDFec = context.localUtil.CToD( cgiGet( edtCheqDFec_Internalname), 2);
               AssignAttri("", false, "A524CheqDFec", context.localUtil.Format(A524CheqDFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDFORCOD");
               AnyError = 1;
               GX_FocusControl = edtCheqDForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A527CheqDForCod = 0;
               AssignAttri("", false, "A527CheqDForCod", StringUtil.LTrimStr( (decimal)(A527CheqDForCod), 6, 0));
            }
            else
            {
               A527CheqDForCod = (int)(context.localUtil.CToN( cgiGet( edtCheqDForCod_Internalname), ".", ","));
               AssignAttri("", false, "A527CheqDForCod", StringUtil.LTrimStr( (decimal)(A527CheqDForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtCheqDTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A534CheqDTipCmb = 0;
               AssignAttri("", false, "A534CheqDTipCmb", StringUtil.LTrimStr( A534CheqDTipCmb, 15, 5));
            }
            else
            {
               A534CheqDTipCmb = context.localUtil.CToN( cgiGet( edtCheqDTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A534CheqDTipCmb", StringUtil.LTrimStr( A534CheqDTipCmb, 15, 5));
            }
            A532CheqDSts = cgiGet( edtCheqDSts_Internalname);
            AssignAttri("", false, "A532CheqDSts", A532CheqDSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDMONCOD");
               AnyError = 1;
               GX_FocusControl = edtCheqDMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A239CheqDMonCod = 0;
               AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrimStr( (decimal)(A239CheqDMonCod), 6, 0));
            }
            else
            {
               A239CheqDMonCod = (int)(context.localUtil.CToN( cgiGet( edtCheqDMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrimStr( (decimal)(A239CheqDMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtCheqDImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A529CheqDImporte = 0;
               AssignAttri("", false, "A529CheqDImporte", StringUtil.LTrimStr( A529CheqDImporte, 15, 2));
            }
            else
            {
               A529CheqDImporte = context.localUtil.CToN( cgiGet( edtCheqDImporte_Internalname), ".", ",");
               AssignAttri("", false, "A529CheqDImporte", StringUtil.LTrimStr( A529CheqDImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDVOUANO");
               AnyError = 1;
               GX_FocusControl = edtCheqDVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A538CheqDVouAno = 0;
               AssignAttri("", false, "A538CheqDVouAno", StringUtil.LTrimStr( (decimal)(A538CheqDVouAno), 4, 0));
            }
            else
            {
               A538CheqDVouAno = (short)(context.localUtil.CToN( cgiGet( edtCheqDVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A538CheqDVouAno", StringUtil.LTrimStr( (decimal)(A538CheqDVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDVOUMES");
               AnyError = 1;
               GX_FocusControl = edtCheqDVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A539CheqDVouMes = 0;
               AssignAttri("", false, "A539CheqDVouMes", StringUtil.LTrimStr( (decimal)(A539CheqDVouMes), 2, 0));
            }
            else
            {
               A539CheqDVouMes = (short)(context.localUtil.CToN( cgiGet( edtCheqDVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A539CheqDVouMes", StringUtil.LTrimStr( (decimal)(A539CheqDVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDTASICOD");
               AnyError = 1;
               GX_FocusControl = edtCheqDTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A533CheqDTasiCod = 0;
               AssignAttri("", false, "A533CheqDTasiCod", StringUtil.LTrimStr( (decimal)(A533CheqDTasiCod), 6, 0));
            }
            else
            {
               A533CheqDTasiCod = (int)(context.localUtil.CToN( cgiGet( edtCheqDTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A533CheqDTasiCod", StringUtil.LTrimStr( (decimal)(A533CheqDTasiCod), 6, 0));
            }
            A540CheqDVouNum = cgiGet( edtCheqDVouNum_Internalname);
            AssignAttri("", false, "A540CheqDVouNum", A540CheqDVouNum);
            A536CheqDUsuCod = cgiGet( edtCheqDUsuCod_Internalname);
            AssignAttri("", false, "A536CheqDUsuCod", A536CheqDUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtCheqDUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora"}), 1, "CHEQDUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtCheqDUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A537CheqDUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A537CheqDUsuFec", context.localUtil.TToC( A537CheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A537CheqDUsuFec = context.localUtil.CToT( cgiGet( edtCheqDUsuFec_Internalname));
               AssignAttri("", false, "A537CheqDUsuFec", context.localUtil.TToC( A537CheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
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
               A238CheqDCod = GetPar( "CheqDCod");
               AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
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
               InitAll0D14( ) ;
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
         DisableAttributes0D14( ) ;
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

      protected void ResetCaption0D0( )
      {
      }

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z524CheqDFec = T000D3_A524CheqDFec[0];
               Z527CheqDForCod = T000D3_A527CheqDForCod[0];
               Z534CheqDTipCmb = T000D3_A534CheqDTipCmb[0];
               Z532CheqDSts = T000D3_A532CheqDSts[0];
               Z529CheqDImporte = T000D3_A529CheqDImporte[0];
               Z538CheqDVouAno = T000D3_A538CheqDVouAno[0];
               Z539CheqDVouMes = T000D3_A539CheqDVouMes[0];
               Z533CheqDTasiCod = T000D3_A533CheqDTasiCod[0];
               Z540CheqDVouNum = T000D3_A540CheqDVouNum[0];
               Z536CheqDUsuCod = T000D3_A536CheqDUsuCod[0];
               Z537CheqDUsuFec = T000D3_A537CheqDUsuFec[0];
               Z240CheqDPrvCod = T000D3_A240CheqDPrvCod[0];
               Z239CheqDMonCod = T000D3_A239CheqDMonCod[0];
            }
            else
            {
               Z524CheqDFec = A524CheqDFec;
               Z527CheqDForCod = A527CheqDForCod;
               Z534CheqDTipCmb = A534CheqDTipCmb;
               Z532CheqDSts = A532CheqDSts;
               Z529CheqDImporte = A529CheqDImporte;
               Z538CheqDVouAno = A538CheqDVouAno;
               Z539CheqDVouMes = A539CheqDVouMes;
               Z533CheqDTasiCod = A533CheqDTasiCod;
               Z540CheqDVouNum = A540CheqDVouNum;
               Z536CheqDUsuCod = A536CheqDUsuCod;
               Z537CheqDUsuFec = A537CheqDUsuFec;
               Z240CheqDPrvCod = A240CheqDPrvCod;
               Z239CheqDMonCod = A239CheqDMonCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z238CheqDCod = A238CheqDCod;
            Z524CheqDFec = A524CheqDFec;
            Z527CheqDForCod = A527CheqDForCod;
            Z534CheqDTipCmb = A534CheqDTipCmb;
            Z532CheqDSts = A532CheqDSts;
            Z529CheqDImporte = A529CheqDImporte;
            Z538CheqDVouAno = A538CheqDVouAno;
            Z539CheqDVouMes = A539CheqDVouMes;
            Z533CheqDTasiCod = A533CheqDTasiCod;
            Z540CheqDVouNum = A540CheqDVouNum;
            Z536CheqDUsuCod = A536CheqDUsuCod;
            Z537CheqDUsuFec = A537CheqDUsuFec;
            Z240CheqDPrvCod = A240CheqDPrvCod;
            Z239CheqDMonCod = A239CheqDMonCod;
            Z531CheqDPrvDsc = A531CheqDPrvDsc;
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

      protected void Load0D14( )
      {
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound14 = 1;
            A531CheqDPrvDsc = T000D6_A531CheqDPrvDsc[0];
            AssignAttri("", false, "A531CheqDPrvDsc", A531CheqDPrvDsc);
            A524CheqDFec = T000D6_A524CheqDFec[0];
            AssignAttri("", false, "A524CheqDFec", context.localUtil.Format(A524CheqDFec, "99/99/99"));
            A527CheqDForCod = T000D6_A527CheqDForCod[0];
            AssignAttri("", false, "A527CheqDForCod", StringUtil.LTrimStr( (decimal)(A527CheqDForCod), 6, 0));
            A534CheqDTipCmb = T000D6_A534CheqDTipCmb[0];
            AssignAttri("", false, "A534CheqDTipCmb", StringUtil.LTrimStr( A534CheqDTipCmb, 15, 5));
            A532CheqDSts = T000D6_A532CheqDSts[0];
            AssignAttri("", false, "A532CheqDSts", A532CheqDSts);
            A529CheqDImporte = T000D6_A529CheqDImporte[0];
            AssignAttri("", false, "A529CheqDImporte", StringUtil.LTrimStr( A529CheqDImporte, 15, 2));
            A538CheqDVouAno = T000D6_A538CheqDVouAno[0];
            AssignAttri("", false, "A538CheqDVouAno", StringUtil.LTrimStr( (decimal)(A538CheqDVouAno), 4, 0));
            A539CheqDVouMes = T000D6_A539CheqDVouMes[0];
            AssignAttri("", false, "A539CheqDVouMes", StringUtil.LTrimStr( (decimal)(A539CheqDVouMes), 2, 0));
            A533CheqDTasiCod = T000D6_A533CheqDTasiCod[0];
            AssignAttri("", false, "A533CheqDTasiCod", StringUtil.LTrimStr( (decimal)(A533CheqDTasiCod), 6, 0));
            A540CheqDVouNum = T000D6_A540CheqDVouNum[0];
            AssignAttri("", false, "A540CheqDVouNum", A540CheqDVouNum);
            A536CheqDUsuCod = T000D6_A536CheqDUsuCod[0];
            AssignAttri("", false, "A536CheqDUsuCod", A536CheqDUsuCod);
            A537CheqDUsuFec = T000D6_A537CheqDUsuFec[0];
            AssignAttri("", false, "A537CheqDUsuFec", context.localUtil.TToC( A537CheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A240CheqDPrvCod = T000D6_A240CheqDPrvCod[0];
            AssignAttri("", false, "A240CheqDPrvCod", A240CheqDPrvCod);
            A239CheqDMonCod = T000D6_A239CheqDMonCod[0];
            AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrimStr( (decimal)(A239CheqDMonCod), 6, 0));
            ZM0D14( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
      }

      protected void CheckExtendedTable0D14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A240CheqDPrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "CHEQDPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A531CheqDPrvDsc = T000D4_A531CheqDPrvDsc[0];
         AssignAttri("", false, "A531CheqDPrvDsc", A531CheqDPrvDsc);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A524CheqDFec) || ( DateTimeUtil.ResetTime ( A524CheqDFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Canje fuera de rango", "OutOfRange", 1, "CHEQDFEC");
            AnyError = 1;
            GX_FocusControl = edtCheqDFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A239CheqDMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CHEQDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A537CheqDUsuFec) || ( A537CheqDUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "CHEQDUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtCheqDUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0D14( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A240CheqDPrvCod )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A240CheqDPrvCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "CHEQDPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A531CheqDPrvDsc = T000D7_A531CheqDPrvDsc[0];
         AssignAttri("", false, "A531CheqDPrvDsc", A531CheqDPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A531CheqDPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( int A239CheqDMonCod )
      {
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {A239CheqDMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CHEQDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDMonCod_Internalname;
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

      protected void GetKey0D14( )
      {
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D14( 3) ;
            RcdFound14 = 1;
            A238CheqDCod = T000D3_A238CheqDCod[0];
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            A524CheqDFec = T000D3_A524CheqDFec[0];
            AssignAttri("", false, "A524CheqDFec", context.localUtil.Format(A524CheqDFec, "99/99/99"));
            A527CheqDForCod = T000D3_A527CheqDForCod[0];
            AssignAttri("", false, "A527CheqDForCod", StringUtil.LTrimStr( (decimal)(A527CheqDForCod), 6, 0));
            A534CheqDTipCmb = T000D3_A534CheqDTipCmb[0];
            AssignAttri("", false, "A534CheqDTipCmb", StringUtil.LTrimStr( A534CheqDTipCmb, 15, 5));
            A532CheqDSts = T000D3_A532CheqDSts[0];
            AssignAttri("", false, "A532CheqDSts", A532CheqDSts);
            A529CheqDImporte = T000D3_A529CheqDImporte[0];
            AssignAttri("", false, "A529CheqDImporte", StringUtil.LTrimStr( A529CheqDImporte, 15, 2));
            A538CheqDVouAno = T000D3_A538CheqDVouAno[0];
            AssignAttri("", false, "A538CheqDVouAno", StringUtil.LTrimStr( (decimal)(A538CheqDVouAno), 4, 0));
            A539CheqDVouMes = T000D3_A539CheqDVouMes[0];
            AssignAttri("", false, "A539CheqDVouMes", StringUtil.LTrimStr( (decimal)(A539CheqDVouMes), 2, 0));
            A533CheqDTasiCod = T000D3_A533CheqDTasiCod[0];
            AssignAttri("", false, "A533CheqDTasiCod", StringUtil.LTrimStr( (decimal)(A533CheqDTasiCod), 6, 0));
            A540CheqDVouNum = T000D3_A540CheqDVouNum[0];
            AssignAttri("", false, "A540CheqDVouNum", A540CheqDVouNum);
            A536CheqDUsuCod = T000D3_A536CheqDUsuCod[0];
            AssignAttri("", false, "A536CheqDUsuCod", A536CheqDUsuCod);
            A537CheqDUsuFec = T000D3_A537CheqDUsuFec[0];
            AssignAttri("", false, "A537CheqDUsuFec", context.localUtil.TToC( A537CheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A240CheqDPrvCod = T000D3_A240CheqDPrvCod[0];
            AssignAttri("", false, "A240CheqDPrvCod", A240CheqDPrvCod);
            A239CheqDMonCod = T000D3_A239CheqDMonCod[0];
            AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrimStr( (decimal)(A239CheqDMonCod), 6, 0));
            Z238CheqDCod = A238CheqDCod;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
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
         RcdFound14 = 0;
         /* Using cursor T000D10 */
         pr_default.execute(8, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000D10_A238CheqDCod[0], A238CheqDCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000D10_A238CheqDCod[0], A238CheqDCod) > 0 ) ) )
            {
               A238CheqDCod = T000D10_A238CheqDCod[0];
               AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
               RcdFound14 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D11 */
         pr_default.execute(9, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000D11_A238CheqDCod[0], A238CheqDCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000D11_A238CheqDCod[0], A238CheqDCod) < 0 ) ) )
            {
               A238CheqDCod = T000D11_A238CheqDCod[0];
               AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
               RcdFound14 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( StringUtil.StrCmp(A238CheqDCod, Z238CheqDCod) != 0 )
               {
                  A238CheqDCod = Z238CheqDCod;
                  AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CHEQDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0D14( ) ;
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A238CheqDCod, Z238CheqDCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHEQDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D14( ) ;
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
         if ( StringUtil.StrCmp(A238CheqDCod, Z238CheqDCod) != 0 )
         {
            A238CheqDCod = Z238CheqDCod;
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCheqDCod_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCheqDPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0D14( ) ;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDPrvCod_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDPrvCod_Internalname;
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
         ScanStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound14 != 0 )
            {
               ScanNext0D14( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0D14( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A238CheqDCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCHEQUEDIFERIDO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z524CheqDFec ) != DateTimeUtil.ResetTime ( T000D2_A524CheqDFec[0] ) ) || ( Z527CheqDForCod != T000D2_A527CheqDForCod[0] ) || ( Z534CheqDTipCmb != T000D2_A534CheqDTipCmb[0] ) || ( StringUtil.StrCmp(Z532CheqDSts, T000D2_A532CheqDSts[0]) != 0 ) || ( Z529CheqDImporte != T000D2_A529CheqDImporte[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z538CheqDVouAno != T000D2_A538CheqDVouAno[0] ) || ( Z539CheqDVouMes != T000D2_A539CheqDVouMes[0] ) || ( Z533CheqDTasiCod != T000D2_A533CheqDTasiCod[0] ) || ( StringUtil.StrCmp(Z540CheqDVouNum, T000D2_A540CheqDVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z536CheqDUsuCod, T000D2_A536CheqDUsuCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z537CheqDUsuFec != T000D2_A537CheqDUsuFec[0] ) || ( StringUtil.StrCmp(Z240CheqDPrvCod, T000D2_A240CheqDPrvCod[0]) != 0 ) || ( Z239CheqDMonCod != T000D2_A239CheqDMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z524CheqDFec ) != DateTimeUtil.ResetTime ( T000D2_A524CheqDFec[0] ) )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDFec");
                  GXUtil.WriteLogRaw("Old: ",Z524CheqDFec);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A524CheqDFec[0]);
               }
               if ( Z527CheqDForCod != T000D2_A527CheqDForCod[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDForCod");
                  GXUtil.WriteLogRaw("Old: ",Z527CheqDForCod);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A527CheqDForCod[0]);
               }
               if ( Z534CheqDTipCmb != T000D2_A534CheqDTipCmb[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z534CheqDTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A534CheqDTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z532CheqDSts, T000D2_A532CheqDSts[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDSts");
                  GXUtil.WriteLogRaw("Old: ",Z532CheqDSts);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A532CheqDSts[0]);
               }
               if ( Z529CheqDImporte != T000D2_A529CheqDImporte[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDImporte");
                  GXUtil.WriteLogRaw("Old: ",Z529CheqDImporte);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A529CheqDImporte[0]);
               }
               if ( Z538CheqDVouAno != T000D2_A538CheqDVouAno[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z538CheqDVouAno);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A538CheqDVouAno[0]);
               }
               if ( Z539CheqDVouMes != T000D2_A539CheqDVouMes[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z539CheqDVouMes);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A539CheqDVouMes[0]);
               }
               if ( Z533CheqDTasiCod != T000D2_A533CheqDTasiCod[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z533CheqDTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A533CheqDTasiCod[0]);
               }
               if ( StringUtil.StrCmp(Z540CheqDVouNum, T000D2_A540CheqDVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z540CheqDVouNum);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A540CheqDVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z536CheqDUsuCod, T000D2_A536CheqDUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z536CheqDUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A536CheqDUsuCod[0]);
               }
               if ( Z537CheqDUsuFec != T000D2_A537CheqDUsuFec[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z537CheqDUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A537CheqDUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z240CheqDPrvCod, T000D2_A240CheqDPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z240CheqDPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A240CheqDPrvCod[0]);
               }
               if ( Z239CheqDMonCod != T000D2_A239CheqDMonCod[0] )
               {
                  GXUtil.WriteLog("cpchequediferido:[seudo value changed for attri]"+"CheqDMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z239CheqDMonCod);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A239CheqDMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPCHEQUEDIFERIDO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D12 */
                     pr_default.execute(10, new Object[] {A238CheqDCod, A524CheqDFec, A527CheqDForCod, A534CheqDTipCmb, A532CheqDSts, A529CheqDImporte, A538CheqDVouAno, A539CheqDVouMes, A533CheqDTasiCod, A540CheqDVouNum, A536CheqDUsuCod, A537CheqDUsuFec, A240CheqDPrvCod, A239CheqDMonCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCHEQUEDIFERIDO");
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
                           ResetCaption0D0( ) ;
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D13 */
                     pr_default.execute(11, new Object[] {A524CheqDFec, A527CheqDForCod, A534CheqDTipCmb, A532CheqDSts, A529CheqDImporte, A538CheqDVouAno, A539CheqDVouMes, A533CheqDTasiCod, A540CheqDVouNum, A536CheqDUsuCod, A537CheqDUsuFec, A240CheqDPrvCod, A239CheqDMonCod, A238CheqDCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCHEQUEDIFERIDO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCHEQUEDIFERIDO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0D0( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D14 */
                  pr_default.execute(12, new Object[] {A238CheqDCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPCHEQUEDIFERIDO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound14 == 0 )
                        {
                           InitAll0D14( ) ;
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
                        ResetCaption0D0( ) ;
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D15 */
            pr_default.execute(13, new Object[] {A240CheqDPrvCod});
            A531CheqDPrvDsc = T000D15_A531CheqDPrvDsc[0];
            AssignAttri("", false, "A531CheqDPrvDsc", A531CheqDPrvDsc);
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000D16 */
            pr_default.execute(14, new Object[] {A238CheqDCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ChequeDiferido Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("cpchequediferido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("cpchequediferido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D14( )
      {
         /* Using cursor T000D17 */
         pr_default.execute(15);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A238CheqDCod = T000D17_A238CheqDCod[0];
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D14( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A238CheqDCod = T000D17_A238CheqDCod[0];
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
         }
      }

      protected void ScanEnd0D14( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
         edtCheqDCod_Enabled = 0;
         AssignProp("", false, edtCheqDCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDCod_Enabled), 5, 0), true);
         edtCheqDPrvCod_Enabled = 0;
         AssignProp("", false, edtCheqDPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDPrvCod_Enabled), 5, 0), true);
         edtCheqDPrvDsc_Enabled = 0;
         AssignProp("", false, edtCheqDPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDPrvDsc_Enabled), 5, 0), true);
         edtCheqDFec_Enabled = 0;
         AssignProp("", false, edtCheqDFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDFec_Enabled), 5, 0), true);
         edtCheqDForCod_Enabled = 0;
         AssignProp("", false, edtCheqDForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDForCod_Enabled), 5, 0), true);
         edtCheqDTipCmb_Enabled = 0;
         AssignProp("", false, edtCheqDTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDTipCmb_Enabled), 5, 0), true);
         edtCheqDSts_Enabled = 0;
         AssignProp("", false, edtCheqDSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDSts_Enabled), 5, 0), true);
         edtCheqDMonCod_Enabled = 0;
         AssignProp("", false, edtCheqDMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDMonCod_Enabled), 5, 0), true);
         edtCheqDImporte_Enabled = 0;
         AssignProp("", false, edtCheqDImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDImporte_Enabled), 5, 0), true);
         edtCheqDVouAno_Enabled = 0;
         AssignProp("", false, edtCheqDVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDVouAno_Enabled), 5, 0), true);
         edtCheqDVouMes_Enabled = 0;
         AssignProp("", false, edtCheqDVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDVouMes_Enabled), 5, 0), true);
         edtCheqDTasiCod_Enabled = 0;
         AssignProp("", false, edtCheqDTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDTasiCod_Enabled), 5, 0), true);
         edtCheqDVouNum_Enabled = 0;
         AssignProp("", false, edtCheqDVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDVouNum_Enabled), 5, 0), true);
         edtCheqDUsuCod_Enabled = 0;
         AssignProp("", false, edtCheqDUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDUsuCod_Enabled), 5, 0), true);
         edtCheqDUsuFec_Enabled = 0;
         AssignProp("", false, edtCheqDUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDUsuFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816422043", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cpchequediferido.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z238CheqDCod", StringUtil.RTrim( Z238CheqDCod));
         GxWebStd.gx_hidden_field( context, "Z524CheqDFec", context.localUtil.DToC( Z524CheqDFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z527CheqDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z527CheqDForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z534CheqDTipCmb", StringUtil.LTrim( StringUtil.NToC( Z534CheqDTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z532CheqDSts", StringUtil.RTrim( Z532CheqDSts));
         GxWebStd.gx_hidden_field( context, "Z529CheqDImporte", StringUtil.LTrim( StringUtil.NToC( Z529CheqDImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z538CheqDVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z538CheqDVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z539CheqDVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z539CheqDVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z533CheqDTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z533CheqDTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z540CheqDVouNum", StringUtil.RTrim( Z540CheqDVouNum));
         GxWebStd.gx_hidden_field( context, "Z536CheqDUsuCod", StringUtil.RTrim( Z536CheqDUsuCod));
         GxWebStd.gx_hidden_field( context, "Z537CheqDUsuFec", context.localUtil.TToC( Z537CheqDUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z240CheqDPrvCod", StringUtil.RTrim( Z240CheqDPrvCod));
         GxWebStd.gx_hidden_field( context, "Z239CheqDMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z239CheqDMonCod), 6, 0, ".", "")));
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
         return formatLink("cpchequediferido.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPCHEQUEDIFERIDO" ;
      }

      public override string GetPgmdesc( )
      {
         return "CPCHEQUEDIFERIDO" ;
      }

      protected void InitializeNonKey0D14( )
      {
         A240CheqDPrvCod = "";
         AssignAttri("", false, "A240CheqDPrvCod", A240CheqDPrvCod);
         A531CheqDPrvDsc = "";
         AssignAttri("", false, "A531CheqDPrvDsc", A531CheqDPrvDsc);
         A524CheqDFec = DateTime.MinValue;
         AssignAttri("", false, "A524CheqDFec", context.localUtil.Format(A524CheqDFec, "99/99/99"));
         A527CheqDForCod = 0;
         AssignAttri("", false, "A527CheqDForCod", StringUtil.LTrimStr( (decimal)(A527CheqDForCod), 6, 0));
         A534CheqDTipCmb = 0;
         AssignAttri("", false, "A534CheqDTipCmb", StringUtil.LTrimStr( A534CheqDTipCmb, 15, 5));
         A532CheqDSts = "";
         AssignAttri("", false, "A532CheqDSts", A532CheqDSts);
         A239CheqDMonCod = 0;
         AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrimStr( (decimal)(A239CheqDMonCod), 6, 0));
         A529CheqDImporte = 0;
         AssignAttri("", false, "A529CheqDImporte", StringUtil.LTrimStr( A529CheqDImporte, 15, 2));
         A538CheqDVouAno = 0;
         AssignAttri("", false, "A538CheqDVouAno", StringUtil.LTrimStr( (decimal)(A538CheqDVouAno), 4, 0));
         A539CheqDVouMes = 0;
         AssignAttri("", false, "A539CheqDVouMes", StringUtil.LTrimStr( (decimal)(A539CheqDVouMes), 2, 0));
         A533CheqDTasiCod = 0;
         AssignAttri("", false, "A533CheqDTasiCod", StringUtil.LTrimStr( (decimal)(A533CheqDTasiCod), 6, 0));
         A540CheqDVouNum = "";
         AssignAttri("", false, "A540CheqDVouNum", A540CheqDVouNum);
         A536CheqDUsuCod = "";
         AssignAttri("", false, "A536CheqDUsuCod", A536CheqDUsuCod);
         A537CheqDUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A537CheqDUsuFec", context.localUtil.TToC( A537CheqDUsuFec, 8, 5, 0, 3, "/", ":", " "));
         Z524CheqDFec = DateTime.MinValue;
         Z527CheqDForCod = 0;
         Z534CheqDTipCmb = 0;
         Z532CheqDSts = "";
         Z529CheqDImporte = 0;
         Z538CheqDVouAno = 0;
         Z539CheqDVouMes = 0;
         Z533CheqDTasiCod = 0;
         Z540CheqDVouNum = "";
         Z536CheqDUsuCod = "";
         Z537CheqDUsuFec = (DateTime)(DateTime.MinValue);
         Z240CheqDPrvCod = "";
         Z239CheqDMonCod = 0;
      }

      protected void InitAll0D14( )
      {
         A238CheqDCod = "";
         AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
         InitializeNonKey0D14( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816422056", true, true);
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
         context.AddJavascriptSource("cpchequediferido.js", "?202281816422057", false, true);
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
         edtCheqDCod_Internalname = "CHEQDCOD";
         edtCheqDPrvCod_Internalname = "CHEQDPRVCOD";
         edtCheqDPrvDsc_Internalname = "CHEQDPRVDSC";
         edtCheqDFec_Internalname = "CHEQDFEC";
         edtCheqDForCod_Internalname = "CHEQDFORCOD";
         edtCheqDTipCmb_Internalname = "CHEQDTIPCMB";
         edtCheqDSts_Internalname = "CHEQDSTS";
         edtCheqDMonCod_Internalname = "CHEQDMONCOD";
         edtCheqDImporte_Internalname = "CHEQDIMPORTE";
         edtCheqDVouAno_Internalname = "CHEQDVOUANO";
         edtCheqDVouMes_Internalname = "CHEQDVOUMES";
         edtCheqDTasiCod_Internalname = "CHEQDTASICOD";
         edtCheqDVouNum_Internalname = "CHEQDVOUNUM";
         edtCheqDUsuCod_Internalname = "CHEQDUSUCOD";
         edtCheqDUsuFec_Internalname = "CHEQDUSUFEC";
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
         Form.Caption = "CPCHEQUEDIFERIDO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCheqDUsuFec_Jsonclick = "";
         edtCheqDUsuFec_Enabled = 1;
         edtCheqDUsuCod_Jsonclick = "";
         edtCheqDUsuCod_Enabled = 1;
         edtCheqDVouNum_Jsonclick = "";
         edtCheqDVouNum_Enabled = 1;
         edtCheqDTasiCod_Jsonclick = "";
         edtCheqDTasiCod_Enabled = 1;
         edtCheqDVouMes_Jsonclick = "";
         edtCheqDVouMes_Enabled = 1;
         edtCheqDVouAno_Jsonclick = "";
         edtCheqDVouAno_Enabled = 1;
         edtCheqDImporte_Jsonclick = "";
         edtCheqDImporte_Enabled = 1;
         edtCheqDMonCod_Jsonclick = "";
         edtCheqDMonCod_Enabled = 1;
         edtCheqDSts_Jsonclick = "";
         edtCheqDSts_Enabled = 1;
         edtCheqDTipCmb_Jsonclick = "";
         edtCheqDTipCmb_Enabled = 1;
         edtCheqDForCod_Jsonclick = "";
         edtCheqDForCod_Enabled = 1;
         edtCheqDFec_Jsonclick = "";
         edtCheqDFec_Enabled = 1;
         edtCheqDPrvDsc_Jsonclick = "";
         edtCheqDPrvDsc_Enabled = 0;
         edtCheqDPrvCod_Jsonclick = "";
         edtCheqDPrvCod_Enabled = 1;
         edtCheqDCod_Jsonclick = "";
         edtCheqDCod_Enabled = 1;
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
         GX_FocusControl = edtCheqDPrvCod_Internalname;
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

      public void Valid_Cheqdcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A240CheqDPrvCod", StringUtil.RTrim( A240CheqDPrvCod));
         AssignAttri("", false, "A524CheqDFec", context.localUtil.Format(A524CheqDFec, "99/99/99"));
         AssignAttri("", false, "A527CheqDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A527CheqDForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A534CheqDTipCmb", StringUtil.LTrim( StringUtil.NToC( A534CheqDTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A532CheqDSts", StringUtil.RTrim( A532CheqDSts));
         AssignAttri("", false, "A239CheqDMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A239CheqDMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A529CheqDImporte", StringUtil.LTrim( StringUtil.NToC( A529CheqDImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A538CheqDVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A538CheqDVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A539CheqDVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A539CheqDVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A533CheqDTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A533CheqDTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A540CheqDVouNum", StringUtil.RTrim( A540CheqDVouNum));
         AssignAttri("", false, "A536CheqDUsuCod", StringUtil.RTrim( A536CheqDUsuCod));
         AssignAttri("", false, "A537CheqDUsuFec", context.localUtil.TToC( A537CheqDUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A531CheqDPrvDsc", StringUtil.RTrim( A531CheqDPrvDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z238CheqDCod", StringUtil.RTrim( Z238CheqDCod));
         GxWebStd.gx_hidden_field( context, "Z240CheqDPrvCod", StringUtil.RTrim( Z240CheqDPrvCod));
         GxWebStd.gx_hidden_field( context, "Z524CheqDFec", context.localUtil.Format(Z524CheqDFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z527CheqDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z527CheqDForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z534CheqDTipCmb", StringUtil.LTrim( StringUtil.NToC( Z534CheqDTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z532CheqDSts", StringUtil.RTrim( Z532CheqDSts));
         GxWebStd.gx_hidden_field( context, "Z239CheqDMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z239CheqDMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z529CheqDImporte", StringUtil.LTrim( StringUtil.NToC( Z529CheqDImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z538CheqDVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z538CheqDVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z539CheqDVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z539CheqDVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z533CheqDTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z533CheqDTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z540CheqDVouNum", StringUtil.RTrim( Z540CheqDVouNum));
         GxWebStd.gx_hidden_field( context, "Z536CheqDUsuCod", StringUtil.RTrim( Z536CheqDUsuCod));
         GxWebStd.gx_hidden_field( context, "Z537CheqDUsuFec", context.localUtil.TToC( Z537CheqDUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z531CheqDPrvDsc", StringUtil.RTrim( Z531CheqDPrvDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cheqdprvcod( )
      {
         /* Using cursor T000D15 */
         pr_default.execute(13, new Object[] {A240CheqDPrvCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "CHEQDPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDPrvCod_Internalname;
         }
         A531CheqDPrvDsc = T000D15_A531CheqDPrvDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A531CheqDPrvDsc", StringUtil.RTrim( A531CheqDPrvDsc));
      }

      public void Valid_Cheqdmoncod( )
      {
         /* Using cursor T000D18 */
         pr_default.execute(16, new Object[] {A239CheqDMonCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CHEQDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDMonCod_Internalname;
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
         setEventMetadata("VALID_CHEQDCOD","{handler:'Valid_Cheqdcod',iparms:[{av:'A238CheqDCod',fld:'CHEQDCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CHEQDCOD",",oparms:[{av:'A240CheqDPrvCod',fld:'CHEQDPRVCOD',pic:'@!'},{av:'A524CheqDFec',fld:'CHEQDFEC',pic:''},{av:'A527CheqDForCod',fld:'CHEQDFORCOD',pic:'ZZZZZ9'},{av:'A534CheqDTipCmb',fld:'CHEQDTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A532CheqDSts',fld:'CHEQDSTS',pic:''},{av:'A239CheqDMonCod',fld:'CHEQDMONCOD',pic:'ZZZZZ9'},{av:'A529CheqDImporte',fld:'CHEQDIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A538CheqDVouAno',fld:'CHEQDVOUANO',pic:'ZZZ9'},{av:'A539CheqDVouMes',fld:'CHEQDVOUMES',pic:'Z9'},{av:'A533CheqDTasiCod',fld:'CHEQDTASICOD',pic:'ZZZZZ9'},{av:'A540CheqDVouNum',fld:'CHEQDVOUNUM',pic:''},{av:'A536CheqDUsuCod',fld:'CHEQDUSUCOD',pic:''},{av:'A537CheqDUsuFec',fld:'CHEQDUSUFEC',pic:'99/99/99 99:99'},{av:'A531CheqDPrvDsc',fld:'CHEQDPRVDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z238CheqDCod'},{av:'Z240CheqDPrvCod'},{av:'Z524CheqDFec'},{av:'Z527CheqDForCod'},{av:'Z534CheqDTipCmb'},{av:'Z532CheqDSts'},{av:'Z239CheqDMonCod'},{av:'Z529CheqDImporte'},{av:'Z538CheqDVouAno'},{av:'Z539CheqDVouMes'},{av:'Z533CheqDTasiCod'},{av:'Z540CheqDVouNum'},{av:'Z536CheqDUsuCod'},{av:'Z537CheqDUsuFec'},{av:'Z531CheqDPrvDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CHEQDPRVCOD","{handler:'Valid_Cheqdprvcod',iparms:[{av:'A240CheqDPrvCod',fld:'CHEQDPRVCOD',pic:'@!'},{av:'A531CheqDPrvDsc',fld:'CHEQDPRVDSC',pic:''}]");
         setEventMetadata("VALID_CHEQDPRVCOD",",oparms:[{av:'A531CheqDPrvDsc',fld:'CHEQDPRVDSC',pic:''}]}");
         setEventMetadata("VALID_CHEQDFEC","{handler:'Valid_Cheqdfec',iparms:[]");
         setEventMetadata("VALID_CHEQDFEC",",oparms:[]}");
         setEventMetadata("VALID_CHEQDMONCOD","{handler:'Valid_Cheqdmoncod',iparms:[{av:'A239CheqDMonCod',fld:'CHEQDMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CHEQDMONCOD",",oparms:[]}");
         setEventMetadata("VALID_CHEQDUSUFEC","{handler:'Valid_Cheqdusufec',iparms:[]");
         setEventMetadata("VALID_CHEQDUSUFEC",",oparms:[]}");
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
         Z238CheqDCod = "";
         Z524CheqDFec = DateTime.MinValue;
         Z532CheqDSts = "";
         Z540CheqDVouNum = "";
         Z536CheqDUsuCod = "";
         Z537CheqDUsuFec = (DateTime)(DateTime.MinValue);
         Z240CheqDPrvCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A240CheqDPrvCod = "";
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
         A238CheqDCod = "";
         A531CheqDPrvDsc = "";
         A524CheqDFec = DateTime.MinValue;
         A532CheqDSts = "";
         A540CheqDVouNum = "";
         A536CheqDUsuCod = "";
         A537CheqDUsuFec = (DateTime)(DateTime.MinValue);
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
         Z531CheqDPrvDsc = "";
         T000D6_A238CheqDCod = new string[] {""} ;
         T000D6_A531CheqDPrvDsc = new string[] {""} ;
         T000D6_A524CheqDFec = new DateTime[] {DateTime.MinValue} ;
         T000D6_A527CheqDForCod = new int[1] ;
         T000D6_A534CheqDTipCmb = new decimal[1] ;
         T000D6_A532CheqDSts = new string[] {""} ;
         T000D6_A529CheqDImporte = new decimal[1] ;
         T000D6_A538CheqDVouAno = new short[1] ;
         T000D6_A539CheqDVouMes = new short[1] ;
         T000D6_A533CheqDTasiCod = new int[1] ;
         T000D6_A540CheqDVouNum = new string[] {""} ;
         T000D6_A536CheqDUsuCod = new string[] {""} ;
         T000D6_A537CheqDUsuFec = new DateTime[] {DateTime.MinValue} ;
         T000D6_A240CheqDPrvCod = new string[] {""} ;
         T000D6_A239CheqDMonCod = new int[1] ;
         T000D4_A531CheqDPrvDsc = new string[] {""} ;
         T000D5_A239CheqDMonCod = new int[1] ;
         T000D7_A531CheqDPrvDsc = new string[] {""} ;
         T000D8_A239CheqDMonCod = new int[1] ;
         T000D9_A238CheqDCod = new string[] {""} ;
         T000D3_A238CheqDCod = new string[] {""} ;
         T000D3_A524CheqDFec = new DateTime[] {DateTime.MinValue} ;
         T000D3_A527CheqDForCod = new int[1] ;
         T000D3_A534CheqDTipCmb = new decimal[1] ;
         T000D3_A532CheqDSts = new string[] {""} ;
         T000D3_A529CheqDImporte = new decimal[1] ;
         T000D3_A538CheqDVouAno = new short[1] ;
         T000D3_A539CheqDVouMes = new short[1] ;
         T000D3_A533CheqDTasiCod = new int[1] ;
         T000D3_A540CheqDVouNum = new string[] {""} ;
         T000D3_A536CheqDUsuCod = new string[] {""} ;
         T000D3_A537CheqDUsuFec = new DateTime[] {DateTime.MinValue} ;
         T000D3_A240CheqDPrvCod = new string[] {""} ;
         T000D3_A239CheqDMonCod = new int[1] ;
         sMode14 = "";
         T000D10_A238CheqDCod = new string[] {""} ;
         T000D11_A238CheqDCod = new string[] {""} ;
         T000D2_A238CheqDCod = new string[] {""} ;
         T000D2_A524CheqDFec = new DateTime[] {DateTime.MinValue} ;
         T000D2_A527CheqDForCod = new int[1] ;
         T000D2_A534CheqDTipCmb = new decimal[1] ;
         T000D2_A532CheqDSts = new string[] {""} ;
         T000D2_A529CheqDImporte = new decimal[1] ;
         T000D2_A538CheqDVouAno = new short[1] ;
         T000D2_A539CheqDVouMes = new short[1] ;
         T000D2_A533CheqDTasiCod = new int[1] ;
         T000D2_A540CheqDVouNum = new string[] {""} ;
         T000D2_A536CheqDUsuCod = new string[] {""} ;
         T000D2_A537CheqDUsuFec = new DateTime[] {DateTime.MinValue} ;
         T000D2_A240CheqDPrvCod = new string[] {""} ;
         T000D2_A239CheqDMonCod = new int[1] ;
         T000D15_A531CheqDPrvDsc = new string[] {""} ;
         T000D16_A238CheqDCod = new string[] {""} ;
         T000D16_A241CheqDItem = new int[1] ;
         T000D17_A238CheqDCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ238CheqDCod = "";
         ZZ240CheqDPrvCod = "";
         ZZ524CheqDFec = DateTime.MinValue;
         ZZ532CheqDSts = "";
         ZZ540CheqDVouNum = "";
         ZZ536CheqDUsuCod = "";
         ZZ537CheqDUsuFec = (DateTime)(DateTime.MinValue);
         ZZ531CheqDPrvDsc = "";
         T000D18_A239CheqDMonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpchequediferido__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpchequediferido__default(),
            new Object[][] {
                new Object[] {
               T000D2_A238CheqDCod, T000D2_A524CheqDFec, T000D2_A527CheqDForCod, T000D2_A534CheqDTipCmb, T000D2_A532CheqDSts, T000D2_A529CheqDImporte, T000D2_A538CheqDVouAno, T000D2_A539CheqDVouMes, T000D2_A533CheqDTasiCod, T000D2_A540CheqDVouNum,
               T000D2_A536CheqDUsuCod, T000D2_A537CheqDUsuFec, T000D2_A240CheqDPrvCod, T000D2_A239CheqDMonCod
               }
               , new Object[] {
               T000D3_A238CheqDCod, T000D3_A524CheqDFec, T000D3_A527CheqDForCod, T000D3_A534CheqDTipCmb, T000D3_A532CheqDSts, T000D3_A529CheqDImporte, T000D3_A538CheqDVouAno, T000D3_A539CheqDVouMes, T000D3_A533CheqDTasiCod, T000D3_A540CheqDVouNum,
               T000D3_A536CheqDUsuCod, T000D3_A537CheqDUsuFec, T000D3_A240CheqDPrvCod, T000D3_A239CheqDMonCod
               }
               , new Object[] {
               T000D4_A531CheqDPrvDsc
               }
               , new Object[] {
               T000D5_A239CheqDMonCod
               }
               , new Object[] {
               T000D6_A238CheqDCod, T000D6_A531CheqDPrvDsc, T000D6_A524CheqDFec, T000D6_A527CheqDForCod, T000D6_A534CheqDTipCmb, T000D6_A532CheqDSts, T000D6_A529CheqDImporte, T000D6_A538CheqDVouAno, T000D6_A539CheqDVouMes, T000D6_A533CheqDTasiCod,
               T000D6_A540CheqDVouNum, T000D6_A536CheqDUsuCod, T000D6_A537CheqDUsuFec, T000D6_A240CheqDPrvCod, T000D6_A239CheqDMonCod
               }
               , new Object[] {
               T000D7_A531CheqDPrvDsc
               }
               , new Object[] {
               T000D8_A239CheqDMonCod
               }
               , new Object[] {
               T000D9_A238CheqDCod
               }
               , new Object[] {
               T000D10_A238CheqDCod
               }
               , new Object[] {
               T000D11_A238CheqDCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D15_A531CheqDPrvDsc
               }
               , new Object[] {
               T000D16_A238CheqDCod, T000D16_A241CheqDItem
               }
               , new Object[] {
               T000D17_A238CheqDCod
               }
               , new Object[] {
               T000D18_A239CheqDMonCod
               }
            }
         );
      }

      private short Z538CheqDVouAno ;
      private short Z539CheqDVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A538CheqDVouAno ;
      private short A539CheqDVouMes ;
      private short GX_JID ;
      private short RcdFound14 ;
      private short nIsDirty_14 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ538CheqDVouAno ;
      private short ZZ539CheqDVouMes ;
      private int Z527CheqDForCod ;
      private int Z533CheqDTasiCod ;
      private int Z239CheqDMonCod ;
      private int A239CheqDMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCheqDCod_Enabled ;
      private int edtCheqDPrvCod_Enabled ;
      private int edtCheqDPrvDsc_Enabled ;
      private int edtCheqDFec_Enabled ;
      private int A527CheqDForCod ;
      private int edtCheqDForCod_Enabled ;
      private int edtCheqDTipCmb_Enabled ;
      private int edtCheqDSts_Enabled ;
      private int edtCheqDMonCod_Enabled ;
      private int edtCheqDImporte_Enabled ;
      private int edtCheqDVouAno_Enabled ;
      private int edtCheqDVouMes_Enabled ;
      private int A533CheqDTasiCod ;
      private int edtCheqDTasiCod_Enabled ;
      private int edtCheqDVouNum_Enabled ;
      private int edtCheqDUsuCod_Enabled ;
      private int edtCheqDUsuFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ527CheqDForCod ;
      private int ZZ239CheqDMonCod ;
      private int ZZ533CheqDTasiCod ;
      private decimal Z534CheqDTipCmb ;
      private decimal Z529CheqDImporte ;
      private decimal A534CheqDTipCmb ;
      private decimal A529CheqDImporte ;
      private decimal ZZ534CheqDTipCmb ;
      private decimal ZZ529CheqDImporte ;
      private string sPrefix ;
      private string Z238CheqDCod ;
      private string Z532CheqDSts ;
      private string Z540CheqDVouNum ;
      private string Z536CheqDUsuCod ;
      private string Z240CheqDPrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A240CheqDPrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCheqDCod_Internalname ;
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
      private string A238CheqDCod ;
      private string edtCheqDCod_Jsonclick ;
      private string edtCheqDPrvCod_Internalname ;
      private string edtCheqDPrvCod_Jsonclick ;
      private string edtCheqDPrvDsc_Internalname ;
      private string A531CheqDPrvDsc ;
      private string edtCheqDPrvDsc_Jsonclick ;
      private string edtCheqDFec_Internalname ;
      private string edtCheqDFec_Jsonclick ;
      private string edtCheqDForCod_Internalname ;
      private string edtCheqDForCod_Jsonclick ;
      private string edtCheqDTipCmb_Internalname ;
      private string edtCheqDTipCmb_Jsonclick ;
      private string edtCheqDSts_Internalname ;
      private string A532CheqDSts ;
      private string edtCheqDSts_Jsonclick ;
      private string edtCheqDMonCod_Internalname ;
      private string edtCheqDMonCod_Jsonclick ;
      private string edtCheqDImporte_Internalname ;
      private string edtCheqDImporte_Jsonclick ;
      private string edtCheqDVouAno_Internalname ;
      private string edtCheqDVouAno_Jsonclick ;
      private string edtCheqDVouMes_Internalname ;
      private string edtCheqDVouMes_Jsonclick ;
      private string edtCheqDTasiCod_Internalname ;
      private string edtCheqDTasiCod_Jsonclick ;
      private string edtCheqDVouNum_Internalname ;
      private string A540CheqDVouNum ;
      private string edtCheqDVouNum_Jsonclick ;
      private string edtCheqDUsuCod_Internalname ;
      private string A536CheqDUsuCod ;
      private string edtCheqDUsuCod_Jsonclick ;
      private string edtCheqDUsuFec_Internalname ;
      private string edtCheqDUsuFec_Jsonclick ;
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
      private string Z531CheqDPrvDsc ;
      private string sMode14 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ238CheqDCod ;
      private string ZZ240CheqDPrvCod ;
      private string ZZ532CheqDSts ;
      private string ZZ540CheqDVouNum ;
      private string ZZ536CheqDUsuCod ;
      private string ZZ531CheqDPrvDsc ;
      private DateTime Z537CheqDUsuFec ;
      private DateTime A537CheqDUsuFec ;
      private DateTime ZZ537CheqDUsuFec ;
      private DateTime Z524CheqDFec ;
      private DateTime A524CheqDFec ;
      private DateTime ZZ524CheqDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000D6_A238CheqDCod ;
      private string[] T000D6_A531CheqDPrvDsc ;
      private DateTime[] T000D6_A524CheqDFec ;
      private int[] T000D6_A527CheqDForCod ;
      private decimal[] T000D6_A534CheqDTipCmb ;
      private string[] T000D6_A532CheqDSts ;
      private decimal[] T000D6_A529CheqDImporte ;
      private short[] T000D6_A538CheqDVouAno ;
      private short[] T000D6_A539CheqDVouMes ;
      private int[] T000D6_A533CheqDTasiCod ;
      private string[] T000D6_A540CheqDVouNum ;
      private string[] T000D6_A536CheqDUsuCod ;
      private DateTime[] T000D6_A537CheqDUsuFec ;
      private string[] T000D6_A240CheqDPrvCod ;
      private int[] T000D6_A239CheqDMonCod ;
      private string[] T000D4_A531CheqDPrvDsc ;
      private int[] T000D5_A239CheqDMonCod ;
      private string[] T000D7_A531CheqDPrvDsc ;
      private int[] T000D8_A239CheqDMonCod ;
      private string[] T000D9_A238CheqDCod ;
      private string[] T000D3_A238CheqDCod ;
      private DateTime[] T000D3_A524CheqDFec ;
      private int[] T000D3_A527CheqDForCod ;
      private decimal[] T000D3_A534CheqDTipCmb ;
      private string[] T000D3_A532CheqDSts ;
      private decimal[] T000D3_A529CheqDImporte ;
      private short[] T000D3_A538CheqDVouAno ;
      private short[] T000D3_A539CheqDVouMes ;
      private int[] T000D3_A533CheqDTasiCod ;
      private string[] T000D3_A540CheqDVouNum ;
      private string[] T000D3_A536CheqDUsuCod ;
      private DateTime[] T000D3_A537CheqDUsuFec ;
      private string[] T000D3_A240CheqDPrvCod ;
      private int[] T000D3_A239CheqDMonCod ;
      private string[] T000D10_A238CheqDCod ;
      private string[] T000D11_A238CheqDCod ;
      private string[] T000D2_A238CheqDCod ;
      private DateTime[] T000D2_A524CheqDFec ;
      private int[] T000D2_A527CheqDForCod ;
      private decimal[] T000D2_A534CheqDTipCmb ;
      private string[] T000D2_A532CheqDSts ;
      private decimal[] T000D2_A529CheqDImporte ;
      private short[] T000D2_A538CheqDVouAno ;
      private short[] T000D2_A539CheqDVouMes ;
      private int[] T000D2_A533CheqDTasiCod ;
      private string[] T000D2_A540CheqDVouNum ;
      private string[] T000D2_A536CheqDUsuCod ;
      private DateTime[] T000D2_A537CheqDUsuFec ;
      private string[] T000D2_A240CheqDPrvCod ;
      private int[] T000D2_A239CheqDMonCod ;
      private string[] T000D15_A531CheqDPrvDsc ;
      private string[] T000D16_A238CheqDCod ;
      private int[] T000D16_A241CheqDItem ;
      private string[] T000D17_A238CheqDCod ;
      private int[] T000D18_A239CheqDMonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpchequediferido__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpchequediferido__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new ParDef("@CheqDPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new ParDef("@CheqDMonCod",GXType.Int32,6,0)
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new ParDef("@CheqDPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new ParDef("@CheqDMonCod",GXType.Int32,6,0)
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D11;
        prmT000D11 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D12;
        prmT000D12 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDFec",GXType.Date,8,0) ,
        new ParDef("@CheqDForCod",GXType.Int32,6,0) ,
        new ParDef("@CheqDTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@CheqDSts",GXType.NChar,1,0) ,
        new ParDef("@CheqDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CheqDVouAno",GXType.Int16,4,0) ,
        new ParDef("@CheqDVouMes",GXType.Int16,2,0) ,
        new ParDef("@CheqDTasiCod",GXType.Int32,6,0) ,
        new ParDef("@CheqDVouNum",GXType.NChar,10,0) ,
        new ParDef("@CheqDUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CheqDPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CheqDMonCod",GXType.Int32,6,0)
        };
        Object[] prmT000D13;
        prmT000D13 = new Object[] {
        new ParDef("@CheqDFec",GXType.Date,8,0) ,
        new ParDef("@CheqDForCod",GXType.Int32,6,0) ,
        new ParDef("@CheqDTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@CheqDSts",GXType.NChar,1,0) ,
        new ParDef("@CheqDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CheqDVouAno",GXType.Int16,4,0) ,
        new ParDef("@CheqDVouMes",GXType.Int16,2,0) ,
        new ParDef("@CheqDTasiCod",GXType.Int32,6,0) ,
        new ParDef("@CheqDVouNum",GXType.NChar,10,0) ,
        new ParDef("@CheqDUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CheqDPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CheqDMonCod",GXType.Int32,6,0) ,
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D14;
        prmT000D14 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D16;
        prmT000D16 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000D17;
        prmT000D17 = new Object[] {
        };
        Object[] prmT000D15;
        prmT000D15 = new Object[] {
        new ParDef("@CheqDPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT000D18;
        prmT000D18 = new Object[] {
        new ParDef("@CheqDMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT [CheqDCod], [CheqDFec], [CheqDForCod], [CheqDTipCmb], [CheqDSts], [CheqDImporte], [CheqDVouAno], [CheqDVouMes], [CheqDTasiCod], [CheqDVouNum], [CheqDUsuCod], [CheqDUsuFec], [CheqDPrvCod] AS CheqDPrvCod, [CheqDMonCod] AS CheqDMonCod FROM [CPCHEQUEDIFERIDO] WITH (UPDLOCK) WHERE [CheqDCod] = @CheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT [CheqDCod], [CheqDFec], [CheqDForCod], [CheqDTipCmb], [CheqDSts], [CheqDImporte], [CheqDVouAno], [CheqDVouMes], [CheqDTasiCod], [CheqDVouNum], [CheqDUsuCod], [CheqDUsuFec], [CheqDPrvCod] AS CheqDPrvCod, [CheqDMonCod] AS CheqDMonCod FROM [CPCHEQUEDIFERIDO] WHERE [CheqDCod] = @CheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT [PrvDsc] AS CheqDPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CheqDPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT [MonCod] AS CheqDMonCod FROM [CMONEDAS] WHERE [MonCod] = @CheqDMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT TM1.[CheqDCod], T2.[PrvDsc] AS CheqDPrvDsc, TM1.[CheqDFec], TM1.[CheqDForCod], TM1.[CheqDTipCmb], TM1.[CheqDSts], TM1.[CheqDImporte], TM1.[CheqDVouAno], TM1.[CheqDVouMes], TM1.[CheqDTasiCod], TM1.[CheqDVouNum], TM1.[CheqDUsuCod], TM1.[CheqDUsuFec], TM1.[CheqDPrvCod] AS CheqDPrvCod, TM1.[CheqDMonCod] AS CheqDMonCod FROM ([CPCHEQUEDIFERIDO] TM1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = TM1.[CheqDPrvCod]) WHERE TM1.[CheqDCod] = @CheqDCod ORDER BY TM1.[CheqDCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D7", "SELECT [PrvDsc] AS CheqDPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CheqDPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D8", "SELECT [MonCod] AS CheqDMonCod FROM [CMONEDAS] WHERE [MonCod] = @CheqDMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D9", "SELECT [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDCod] = @CheqDCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D10", "SELECT TOP 1 [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE ( [CheqDCod] > @CheqDCod) ORDER BY [CheqDCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D11", "SELECT TOP 1 [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE ( [CheqDCod] < @CheqDCod) ORDER BY [CheqDCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D12", "INSERT INTO [CPCHEQUEDIFERIDO]([CheqDCod], [CheqDFec], [CheqDForCod], [CheqDTipCmb], [CheqDSts], [CheqDImporte], [CheqDVouAno], [CheqDVouMes], [CheqDTasiCod], [CheqDVouNum], [CheqDUsuCod], [CheqDUsuFec], [CheqDPrvCod], [CheqDMonCod]) VALUES(@CheqDCod, @CheqDFec, @CheqDForCod, @CheqDTipCmb, @CheqDSts, @CheqDImporte, @CheqDVouAno, @CheqDVouMes, @CheqDTasiCod, @CheqDVouNum, @CheqDUsuCod, @CheqDUsuFec, @CheqDPrvCod, @CheqDMonCod)", GxErrorMask.GX_NOMASK,prmT000D12)
           ,new CursorDef("T000D13", "UPDATE [CPCHEQUEDIFERIDO] SET [CheqDFec]=@CheqDFec, [CheqDForCod]=@CheqDForCod, [CheqDTipCmb]=@CheqDTipCmb, [CheqDSts]=@CheqDSts, [CheqDImporte]=@CheqDImporte, [CheqDVouAno]=@CheqDVouAno, [CheqDVouMes]=@CheqDVouMes, [CheqDTasiCod]=@CheqDTasiCod, [CheqDVouNum]=@CheqDVouNum, [CheqDUsuCod]=@CheqDUsuCod, [CheqDUsuFec]=@CheqDUsuFec, [CheqDPrvCod]=@CheqDPrvCod, [CheqDMonCod]=@CheqDMonCod  WHERE [CheqDCod] = @CheqDCod", GxErrorMask.GX_NOMASK,prmT000D13)
           ,new CursorDef("T000D14", "DELETE FROM [CPCHEQUEDIFERIDO]  WHERE [CheqDCod] = @CheqDCod", GxErrorMask.GX_NOMASK,prmT000D14)
           ,new CursorDef("T000D15", "SELECT [PrvDsc] AS CheqDPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CheqDPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D16", "SELECT TOP 1 [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] WHERE [CheqDCod] = @CheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D17", "SELECT [CheqDCod] FROM [CPCHEQUEDIFERIDO] ORDER BY [CheqDCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D18", "SELECT [MonCod] AS CheqDMonCod FROM [CMONEDAS] WHERE [MonCod] = @CheqDMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D18,1, GxCacheFrequency.OFF ,true,false )
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
