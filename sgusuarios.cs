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
   public class sgusuarios : GXDataArea
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
            A2041UsuVend = (int)(NumberUtil.Val( GetPar( "UsuVend"), "."));
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2041UsuVend) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A2040UsuTieCod = (int)(NumberUtil.Val( GetPar( "UsuTieCod"), "."));
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A2040UsuTieCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A69AreCod = (int)(NumberUtil.Val( GetPar( "AreCod"), "."));
            n69AreCod = false;
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A69AreCod) ;
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
            Form.Meta.addItem("description", "SGUSUARIOS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgusuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuarios( IGxContext context )
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
         chkUsuAutOcom = new GXCheckbox();
         cmbUsuSts = new GXCombobox();
         chkUsuReqADM = new GXCheckbox();
         chkUsuAut1 = new GXCheckbox();
         chkUsuAut2 = new GXCheckbox();
         chkUsuOcMail = new GXCheckbox();
         chkUsuPedMail = new GXCheckbox();
         chkUsuVendAut = new GXCheckbox();
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
         A2011UsuAutOcom = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2011UsuAutOcom), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
         if ( cmbUsuSts.ItemCount > 0 )
         {
            A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0))), "."));
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            AssignProp("", false, cmbUsuSts_Internalname, "Values", cmbUsuSts.ToJavascriptSource(), true);
         }
         A2030UsuReqADM = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2030UsuReqADM), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
         A2009UsuAut1 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2009UsuAut1), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
         A2010UsuAut2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2010UsuAut2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
         A2020UsuOcMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2020UsuOcMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
         A2025UsuPedMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2025UsuPedMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
         A2042UsuVendAut = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2042UsuVendAut), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIOS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuPas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuPas_Internalname, "Password", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuPas_Internalname, StringUtil.RTrim( A2021UsuPas), StringUtil.RTrim( context.localUtil.Format( A2021UsuPas, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuPas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuPas_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuNom_Internalname, "Nombre Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuNom_Internalname, StringUtil.RTrim( A2019UsuNom), StringUtil.RTrim( context.localUtil.Format( A2019UsuNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSerie_Internalname, "Serie Factura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSerie_Internalname, StringUtil.RTrim( A2031UsuSerie), StringUtil.RTrim( context.localUtil.Format( A2031UsuSerie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSerie_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuAutOcom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuAutOcom_Internalname, "Autorización Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuAutOcom_Internalname, StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0), "", "Autorización Orden", 1, chkUsuAutOcom.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(48, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuAutPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuAutPago_Internalname, "Autorización Doc. Pagos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuAutPago_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2012UsuAutPago), 1, 0, ".", "")), StringUtil.LTrim( ((edtUsuAutPago_Enabled!=0) ? context.localUtil.Format( (decimal)(A2012UsuAutPago), "9") : context.localUtil.Format( (decimal)(A2012UsuAutPago), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuAutPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuAutPago_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbUsuSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuSts_Internalname, "Situacion Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuSts, cmbUsuSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0)), 1, cmbUsuSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 1, "HLP_SGUSUARIOS.htm");
         cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         AssignProp("", false, cmbUsuSts_Internalname, "Values", (string)(cmbUsuSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSerie1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSerie1_Internalname, "Serie Boleta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSerie1_Internalname, StringUtil.RTrim( A2032UsuSerie1), StringUtil.RTrim( context.localUtil.Format( A2032UsuSerie1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSerie1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSerie1_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSerie2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSerie2_Internalname, "Serie Nota Credito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSerie2_Internalname, StringUtil.RTrim( A2033UsuSerie2), StringUtil.RTrim( context.localUtil.Format( A2033UsuSerie2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSerie2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSerie2_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSerie3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSerie3_Internalname, "Serie Nota Debito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSerie3_Internalname, StringUtil.RTrim( A2034UsuSerie3), StringUtil.RTrim( context.localUtil.Format( A2034UsuSerie3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSerie3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSerie3_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSerie4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSerie4_Internalname, "Serie Guia Remisión", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSerie4_Internalname, StringUtil.RTrim( A2035UsuSerie4), StringUtil.RTrim( context.localUtil.Format( A2035UsuSerie4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSerie4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSerie4_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuVend_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuVend_Internalname, "Vendedor Default", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuVend_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2041UsuVend), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuVend_Enabled!=0) ? context.localUtil.Format( (decimal)(A2041UsuVend), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2041UsuVend), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuVend_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuVend_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSerie5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSerie5_Internalname, "Serie Recibo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSerie5_Internalname, StringUtil.RTrim( A2036UsuSerie5), StringUtil.RTrim( context.localUtil.Format( A2036UsuSerie5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSerie5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSerie5_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuReqADM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuReqADM_Internalname, "Requerimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuReqADM_Internalname, StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0), "", "Requerimiento", 1, chkUsuReqADM.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(93, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuTieCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuTieCod_Internalname, "Local", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuTieCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2040UsuTieCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuTieCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2040UsuTieCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2040UsuTieCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuTieCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuTieCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuAut1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuAut1_Internalname, "Autorización Pedido 1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuAut1_Internalname, StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0), "", "Autorización Pedido 1", 1, chkUsuAut1.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,103);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuAut2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuAut2_Internalname, "Autorizacion Pedido 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuAut2_Internalname, StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0), "", "Autorizacion Pedido 2", 1, chkUsuAut2.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuOcMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuOcMail_Internalname, "Recibir Correo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuOcMail_Internalname, StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0), "", "Recibir Correo", 1, chkUsuOcMail.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(113, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,113);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuEMAIL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuEMAIL_Internalname, "E-Mail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuEMAIL_Internalname, A2014UsuEMAIL, StringUtil.RTrim( context.localUtil.Format( A2014UsuEMAIL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuEMAIL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuEMAIL_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedMail_Internalname, "Correo Pedido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedMail_Internalname, StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0), "", "Correo Pedido", 1, chkUsuPedMail.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(123, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,123);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSOrden_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSOrden_Internalname, "Serie Ordenes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSOrden_Internalname, StringUtil.RTrim( A2037UsuSOrden), StringUtil.RTrim( context.localUtil.Format( A2037UsuSOrden, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSOrden_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSOrden_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAreCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69AreCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAreCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A69AreCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A69AreCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuSRet_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuSRet_Internalname, "Retenciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuSRet_Internalname, StringUtil.RTrim( A2038UsuSRet), StringUtil.RTrim( context.localUtil.Format( A2038UsuSRet, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuSRet_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuSRet_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuDep_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuDep_Internalname, "Departamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuDep_Internalname, A2013UsuDep, StringUtil.RTrim( context.localUtil.Format( A2013UsuDep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuDep_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuDep_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuVendAut_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuVendAut_Internalname, "Vendedor Default", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuVendAut_Internalname, StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0), "", "Vendedor Default", 1, chkUsuVendAut.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(148, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,148);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOS.htm");
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
            Z348UsuCod = cgiGet( "Z348UsuCod");
            Z2021UsuPas = cgiGet( "Z2021UsuPas");
            Z2019UsuNom = cgiGet( "Z2019UsuNom");
            Z2031UsuSerie = cgiGet( "Z2031UsuSerie");
            Z2011UsuAutOcom = (short)(context.localUtil.CToN( cgiGet( "Z2011UsuAutOcom"), ".", ","));
            Z2012UsuAutPago = (short)(context.localUtil.CToN( cgiGet( "Z2012UsuAutPago"), ".", ","));
            Z2039UsuSts = (short)(context.localUtil.CToN( cgiGet( "Z2039UsuSts"), ".", ","));
            Z2032UsuSerie1 = cgiGet( "Z2032UsuSerie1");
            Z2033UsuSerie2 = cgiGet( "Z2033UsuSerie2");
            Z2034UsuSerie3 = cgiGet( "Z2034UsuSerie3");
            Z2035UsuSerie4 = cgiGet( "Z2035UsuSerie4");
            Z2036UsuSerie5 = cgiGet( "Z2036UsuSerie5");
            Z2030UsuReqADM = (short)(context.localUtil.CToN( cgiGet( "Z2030UsuReqADM"), ".", ","));
            Z2009UsuAut1 = (short)(context.localUtil.CToN( cgiGet( "Z2009UsuAut1"), ".", ","));
            Z2010UsuAut2 = (short)(context.localUtil.CToN( cgiGet( "Z2010UsuAut2"), ".", ","));
            Z2020UsuOcMail = (short)(context.localUtil.CToN( cgiGet( "Z2020UsuOcMail"), ".", ","));
            Z2014UsuEMAIL = cgiGet( "Z2014UsuEMAIL");
            Z2025UsuPedMail = (short)(context.localUtil.CToN( cgiGet( "Z2025UsuPedMail"), ".", ","));
            Z2037UsuSOrden = cgiGet( "Z2037UsuSOrden");
            Z2038UsuSRet = cgiGet( "Z2038UsuSRet");
            Z2013UsuDep = cgiGet( "Z2013UsuDep");
            Z2042UsuVendAut = (short)(context.localUtil.CToN( cgiGet( "Z2042UsuVendAut"), ".", ","));
            Z69AreCod = (int)(context.localUtil.CToN( cgiGet( "Z69AreCod"), ".", ","));
            n69AreCod = ((0==A69AreCod) ? true : false);
            Z2041UsuVend = (int)(context.localUtil.CToN( cgiGet( "Z2041UsuVend"), ".", ","));
            Z2040UsuTieCod = (int)(context.localUtil.CToN( cgiGet( "Z2040UsuTieCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A2021UsuPas = cgiGet( edtUsuPas_Internalname);
            AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
            A2019UsuNom = cgiGet( edtUsuNom_Internalname);
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2031UsuSerie = cgiGet( edtUsuSerie_Internalname);
            AssignAttri("", false, "A2031UsuSerie", A2031UsuSerie);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAutOcom_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAutOcom_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUTOCOM");
               AnyError = 1;
               GX_FocusControl = chkUsuAutOcom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2011UsuAutOcom = 0;
               AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
            }
            else
            {
               A2011UsuAutOcom = (short)(((StringUtil.StrCmp(cgiGet( chkUsuAutOcom_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuAutPago_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuAutPago_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUTPAGO");
               AnyError = 1;
               GX_FocusControl = edtUsuAutPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2012UsuAutPago = 0;
               AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            }
            else
            {
               A2012UsuAutPago = (short)(context.localUtil.CToN( cgiGet( edtUsuAutPago_Internalname), ".", ","));
               AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            }
            cmbUsuSts.CurrentValue = cgiGet( cmbUsuSts_Internalname);
            A2039UsuSts = (short)(NumberUtil.Val( cgiGet( cmbUsuSts_Internalname), "."));
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            A2032UsuSerie1 = cgiGet( edtUsuSerie1_Internalname);
            AssignAttri("", false, "A2032UsuSerie1", A2032UsuSerie1);
            A2033UsuSerie2 = cgiGet( edtUsuSerie2_Internalname);
            AssignAttri("", false, "A2033UsuSerie2", A2033UsuSerie2);
            A2034UsuSerie3 = cgiGet( edtUsuSerie3_Internalname);
            AssignAttri("", false, "A2034UsuSerie3", A2034UsuSerie3);
            A2035UsuSerie4 = cgiGet( edtUsuSerie4_Internalname);
            AssignAttri("", false, "A2035UsuSerie4", A2035UsuSerie4);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuVend_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuVend_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUVEND");
               AnyError = 1;
               GX_FocusControl = edtUsuVend_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2041UsuVend = 0;
               AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            }
            else
            {
               A2041UsuVend = (int)(context.localUtil.CToN( cgiGet( edtUsuVend_Internalname), ".", ","));
               AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            }
            A2036UsuSerie5 = cgiGet( edtUsuSerie5_Internalname);
            AssignAttri("", false, "A2036UsuSerie5", A2036UsuSerie5);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuReqADM_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuReqADM_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUREQADM");
               AnyError = 1;
               GX_FocusControl = chkUsuReqADM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2030UsuReqADM = 0;
               AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
            }
            else
            {
               A2030UsuReqADM = (short)(((StringUtil.StrCmp(cgiGet( chkUsuReqADM_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuTieCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuTieCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUTIECOD");
               AnyError = 1;
               GX_FocusControl = edtUsuTieCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2040UsuTieCod = 0;
               AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            }
            else
            {
               A2040UsuTieCod = (int)(context.localUtil.CToN( cgiGet( edtUsuTieCod_Internalname), ".", ","));
               AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut1_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut1_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUT1");
               AnyError = 1;
               GX_FocusControl = chkUsuAut1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2009UsuAut1 = 0;
               AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
            }
            else
            {
               A2009UsuAut1 = (short)(((StringUtil.StrCmp(cgiGet( chkUsuAut1_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut2_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut2_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUT2");
               AnyError = 1;
               GX_FocusControl = chkUsuAut2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2010UsuAut2 = 0;
               AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
            }
            else
            {
               A2010UsuAut2 = (short)(((StringUtil.StrCmp(cgiGet( chkUsuAut2_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuOcMail_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuOcMail_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUOCMAIL");
               AnyError = 1;
               GX_FocusControl = chkUsuOcMail_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2020UsuOcMail = 0;
               AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
            }
            else
            {
               A2020UsuOcMail = (short)(((StringUtil.StrCmp(cgiGet( chkUsuOcMail_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
            }
            A2014UsuEMAIL = cgiGet( edtUsuEMAIL_Internalname);
            AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedMail_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedMail_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDMAIL");
               AnyError = 1;
               GX_FocusControl = chkUsuPedMail_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2025UsuPedMail = 0;
               AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
            }
            else
            {
               A2025UsuPedMail = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedMail_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
            }
            A2037UsuSOrden = cgiGet( edtUsuSOrden_Internalname);
            AssignAttri("", false, "A2037UsuSOrden", A2037UsuSOrden);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A69AreCod = 0;
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            }
            else
            {
               A69AreCod = (int)(context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ","));
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            }
            n69AreCod = ((0==A69AreCod) ? true : false);
            A2038UsuSRet = cgiGet( edtUsuSRet_Internalname);
            AssignAttri("", false, "A2038UsuSRet", A2038UsuSRet);
            A2013UsuDep = cgiGet( edtUsuDep_Internalname);
            AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuVendAut_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuVendAut_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUVENDAUT");
               AnyError = 1;
               GX_FocusControl = chkUsuVendAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2042UsuVendAut = 0;
               AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
            }
            else
            {
               A2042UsuVendAut = (short)(((StringUtil.StrCmp(cgiGet( chkUsuVendAut_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
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
               A348UsuCod = GetPar( "UsuCod");
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
               InitAll0Y32( ) ;
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
         DisableAttributes0Y32( ) ;
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

      protected void ResetCaption0Y0( )
      {
      }

      protected void ZM0Y32( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2021UsuPas = T000Y3_A2021UsuPas[0];
               Z2019UsuNom = T000Y3_A2019UsuNom[0];
               Z2031UsuSerie = T000Y3_A2031UsuSerie[0];
               Z2011UsuAutOcom = T000Y3_A2011UsuAutOcom[0];
               Z2012UsuAutPago = T000Y3_A2012UsuAutPago[0];
               Z2039UsuSts = T000Y3_A2039UsuSts[0];
               Z2032UsuSerie1 = T000Y3_A2032UsuSerie1[0];
               Z2033UsuSerie2 = T000Y3_A2033UsuSerie2[0];
               Z2034UsuSerie3 = T000Y3_A2034UsuSerie3[0];
               Z2035UsuSerie4 = T000Y3_A2035UsuSerie4[0];
               Z2036UsuSerie5 = T000Y3_A2036UsuSerie5[0];
               Z2030UsuReqADM = T000Y3_A2030UsuReqADM[0];
               Z2009UsuAut1 = T000Y3_A2009UsuAut1[0];
               Z2010UsuAut2 = T000Y3_A2010UsuAut2[0];
               Z2020UsuOcMail = T000Y3_A2020UsuOcMail[0];
               Z2014UsuEMAIL = T000Y3_A2014UsuEMAIL[0];
               Z2025UsuPedMail = T000Y3_A2025UsuPedMail[0];
               Z2037UsuSOrden = T000Y3_A2037UsuSOrden[0];
               Z2038UsuSRet = T000Y3_A2038UsuSRet[0];
               Z2013UsuDep = T000Y3_A2013UsuDep[0];
               Z2042UsuVendAut = T000Y3_A2042UsuVendAut[0];
               Z69AreCod = T000Y3_A69AreCod[0];
               Z2041UsuVend = T000Y3_A2041UsuVend[0];
               Z2040UsuTieCod = T000Y3_A2040UsuTieCod[0];
            }
            else
            {
               Z2021UsuPas = A2021UsuPas;
               Z2019UsuNom = A2019UsuNom;
               Z2031UsuSerie = A2031UsuSerie;
               Z2011UsuAutOcom = A2011UsuAutOcom;
               Z2012UsuAutPago = A2012UsuAutPago;
               Z2039UsuSts = A2039UsuSts;
               Z2032UsuSerie1 = A2032UsuSerie1;
               Z2033UsuSerie2 = A2033UsuSerie2;
               Z2034UsuSerie3 = A2034UsuSerie3;
               Z2035UsuSerie4 = A2035UsuSerie4;
               Z2036UsuSerie5 = A2036UsuSerie5;
               Z2030UsuReqADM = A2030UsuReqADM;
               Z2009UsuAut1 = A2009UsuAut1;
               Z2010UsuAut2 = A2010UsuAut2;
               Z2020UsuOcMail = A2020UsuOcMail;
               Z2014UsuEMAIL = A2014UsuEMAIL;
               Z2025UsuPedMail = A2025UsuPedMail;
               Z2037UsuSOrden = A2037UsuSOrden;
               Z2038UsuSRet = A2038UsuSRet;
               Z2013UsuDep = A2013UsuDep;
               Z2042UsuVendAut = A2042UsuVendAut;
               Z69AreCod = A69AreCod;
               Z2041UsuVend = A2041UsuVend;
               Z2040UsuTieCod = A2040UsuTieCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z348UsuCod = A348UsuCod;
            Z2021UsuPas = A2021UsuPas;
            Z2019UsuNom = A2019UsuNom;
            Z2031UsuSerie = A2031UsuSerie;
            Z2011UsuAutOcom = A2011UsuAutOcom;
            Z2012UsuAutPago = A2012UsuAutPago;
            Z2039UsuSts = A2039UsuSts;
            Z2032UsuSerie1 = A2032UsuSerie1;
            Z2033UsuSerie2 = A2033UsuSerie2;
            Z2034UsuSerie3 = A2034UsuSerie3;
            Z2035UsuSerie4 = A2035UsuSerie4;
            Z2036UsuSerie5 = A2036UsuSerie5;
            Z2030UsuReqADM = A2030UsuReqADM;
            Z2009UsuAut1 = A2009UsuAut1;
            Z2010UsuAut2 = A2010UsuAut2;
            Z2020UsuOcMail = A2020UsuOcMail;
            Z2014UsuEMAIL = A2014UsuEMAIL;
            Z2025UsuPedMail = A2025UsuPedMail;
            Z2037UsuSOrden = A2037UsuSOrden;
            Z2038UsuSRet = A2038UsuSRet;
            Z2013UsuDep = A2013UsuDep;
            Z2042UsuVendAut = A2042UsuVendAut;
            Z69AreCod = A69AreCod;
            Z2041UsuVend = A2041UsuVend;
            Z2040UsuTieCod = A2040UsuTieCod;
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

      protected void Load0Y32( )
      {
         /* Using cursor T000Y7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
            A2021UsuPas = T000Y7_A2021UsuPas[0];
            AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
            A2019UsuNom = T000Y7_A2019UsuNom[0];
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2031UsuSerie = T000Y7_A2031UsuSerie[0];
            AssignAttri("", false, "A2031UsuSerie", A2031UsuSerie);
            A2011UsuAutOcom = T000Y7_A2011UsuAutOcom[0];
            AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
            A2012UsuAutPago = T000Y7_A2012UsuAutPago[0];
            AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            A2039UsuSts = T000Y7_A2039UsuSts[0];
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            A2032UsuSerie1 = T000Y7_A2032UsuSerie1[0];
            AssignAttri("", false, "A2032UsuSerie1", A2032UsuSerie1);
            A2033UsuSerie2 = T000Y7_A2033UsuSerie2[0];
            AssignAttri("", false, "A2033UsuSerie2", A2033UsuSerie2);
            A2034UsuSerie3 = T000Y7_A2034UsuSerie3[0];
            AssignAttri("", false, "A2034UsuSerie3", A2034UsuSerie3);
            A2035UsuSerie4 = T000Y7_A2035UsuSerie4[0];
            AssignAttri("", false, "A2035UsuSerie4", A2035UsuSerie4);
            A2036UsuSerie5 = T000Y7_A2036UsuSerie5[0];
            AssignAttri("", false, "A2036UsuSerie5", A2036UsuSerie5);
            A2030UsuReqADM = T000Y7_A2030UsuReqADM[0];
            AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
            A2009UsuAut1 = T000Y7_A2009UsuAut1[0];
            AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
            A2010UsuAut2 = T000Y7_A2010UsuAut2[0];
            AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
            A2020UsuOcMail = T000Y7_A2020UsuOcMail[0];
            AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
            A2014UsuEMAIL = T000Y7_A2014UsuEMAIL[0];
            AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
            A2025UsuPedMail = T000Y7_A2025UsuPedMail[0];
            AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
            A2037UsuSOrden = T000Y7_A2037UsuSOrden[0];
            AssignAttri("", false, "A2037UsuSOrden", A2037UsuSOrden);
            A2038UsuSRet = T000Y7_A2038UsuSRet[0];
            AssignAttri("", false, "A2038UsuSRet", A2038UsuSRet);
            A2013UsuDep = T000Y7_A2013UsuDep[0];
            AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
            A2042UsuVendAut = T000Y7_A2042UsuVendAut[0];
            AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
            A69AreCod = T000Y7_A69AreCod[0];
            n69AreCod = T000Y7_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            A2041UsuVend = T000Y7_A2041UsuVend[0];
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            A2040UsuTieCod = T000Y7_A2040UsuTieCod[0];
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            ZM0Y32( -1) ;
         }
         pr_default.close(5);
         OnLoadActions0Y32( ) ;
      }

      protected void OnLoadActions0Y32( )
      {
      }

      protected void CheckExtendedTable0Y32( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000Y5 */
         pr_default.execute(3, new Object[] {A2041UsuVend});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "USUVEND");
            AnyError = 1;
            GX_FocusControl = edtUsuVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000Y6 */
         pr_default.execute(4, new Object[] {A2040UsuTieCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tienda'.", "ForeignKeyNotFound", 1, "USUTIECOD");
            AnyError = 1;
            GX_FocusControl = edtUsuTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000Y4 */
         pr_default.execute(2, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A69AreCod) ) )
            {
               GX_msglist.addItem("No existe 'Areas Empresa'.", "ForeignKeyNotFound", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0Y32( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A2041UsuVend )
      {
         /* Using cursor T000Y8 */
         pr_default.execute(6, new Object[] {A2041UsuVend});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "USUVEND");
            AnyError = 1;
            GX_FocusControl = edtUsuVend_Internalname;
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

      protected void gxLoad_4( int A2040UsuTieCod )
      {
         /* Using cursor T000Y9 */
         pr_default.execute(7, new Object[] {A2040UsuTieCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Tienda'.", "ForeignKeyNotFound", 1, "USUTIECOD");
            AnyError = 1;
            GX_FocusControl = edtUsuTieCod_Internalname;
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

      protected void gxLoad_2( int A69AreCod )
      {
         /* Using cursor T000Y10 */
         pr_default.execute(8, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A69AreCod) ) )
            {
               GX_msglist.addItem("No existe 'Areas Empresa'.", "ForeignKeyNotFound", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
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

      protected void GetKey0Y32( )
      {
         /* Using cursor T000Y11 */
         pr_default.execute(9, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Y3 */
         pr_default.execute(1, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y32( 1) ;
            RcdFound32 = 1;
            A348UsuCod = T000Y3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A2021UsuPas = T000Y3_A2021UsuPas[0];
            AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
            A2019UsuNom = T000Y3_A2019UsuNom[0];
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2031UsuSerie = T000Y3_A2031UsuSerie[0];
            AssignAttri("", false, "A2031UsuSerie", A2031UsuSerie);
            A2011UsuAutOcom = T000Y3_A2011UsuAutOcom[0];
            AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
            A2012UsuAutPago = T000Y3_A2012UsuAutPago[0];
            AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            A2039UsuSts = T000Y3_A2039UsuSts[0];
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            A2032UsuSerie1 = T000Y3_A2032UsuSerie1[0];
            AssignAttri("", false, "A2032UsuSerie1", A2032UsuSerie1);
            A2033UsuSerie2 = T000Y3_A2033UsuSerie2[0];
            AssignAttri("", false, "A2033UsuSerie2", A2033UsuSerie2);
            A2034UsuSerie3 = T000Y3_A2034UsuSerie3[0];
            AssignAttri("", false, "A2034UsuSerie3", A2034UsuSerie3);
            A2035UsuSerie4 = T000Y3_A2035UsuSerie4[0];
            AssignAttri("", false, "A2035UsuSerie4", A2035UsuSerie4);
            A2036UsuSerie5 = T000Y3_A2036UsuSerie5[0];
            AssignAttri("", false, "A2036UsuSerie5", A2036UsuSerie5);
            A2030UsuReqADM = T000Y3_A2030UsuReqADM[0];
            AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
            A2009UsuAut1 = T000Y3_A2009UsuAut1[0];
            AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
            A2010UsuAut2 = T000Y3_A2010UsuAut2[0];
            AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
            A2020UsuOcMail = T000Y3_A2020UsuOcMail[0];
            AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
            A2014UsuEMAIL = T000Y3_A2014UsuEMAIL[0];
            AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
            A2025UsuPedMail = T000Y3_A2025UsuPedMail[0];
            AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
            A2037UsuSOrden = T000Y3_A2037UsuSOrden[0];
            AssignAttri("", false, "A2037UsuSOrden", A2037UsuSOrden);
            A2038UsuSRet = T000Y3_A2038UsuSRet[0];
            AssignAttri("", false, "A2038UsuSRet", A2038UsuSRet);
            A2013UsuDep = T000Y3_A2013UsuDep[0];
            AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
            A2042UsuVendAut = T000Y3_A2042UsuVendAut[0];
            AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
            A69AreCod = T000Y3_A69AreCod[0];
            n69AreCod = T000Y3_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            A2041UsuVend = T000Y3_A2041UsuVend[0];
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            A2040UsuTieCod = T000Y3_A2040UsuTieCod[0];
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            Z348UsuCod = A348UsuCod;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Y32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0Y32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0Y32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y32( ) ;
         if ( RcdFound32 == 0 )
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
         RcdFound32 = 0;
         /* Using cursor T000Y12 */
         pr_default.execute(10, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T000Y12_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T000Y12_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               A348UsuCod = T000Y12_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T000Y13 */
         pr_default.execute(11, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T000Y13_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T000Y13_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               A348UsuCod = T000Y13_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Y32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Y32( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0Y32( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Y32( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Y32( ) ;
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
         if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuCod_Internalname;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuPas_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Y32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuPas_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y32( ) ;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuPas_Internalname;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuPas_Internalname;
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
         ScanStart0Y32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound32 != 0 )
            {
               ScanNext0Y32( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuPas_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y32( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Y32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y2 */
            pr_default.execute(0, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2021UsuPas, T000Y2_A2021UsuPas[0]) != 0 ) || ( StringUtil.StrCmp(Z2019UsuNom, T000Y2_A2019UsuNom[0]) != 0 ) || ( StringUtil.StrCmp(Z2031UsuSerie, T000Y2_A2031UsuSerie[0]) != 0 ) || ( Z2011UsuAutOcom != T000Y2_A2011UsuAutOcom[0] ) || ( Z2012UsuAutPago != T000Y2_A2012UsuAutPago[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2039UsuSts != T000Y2_A2039UsuSts[0] ) || ( StringUtil.StrCmp(Z2032UsuSerie1, T000Y2_A2032UsuSerie1[0]) != 0 ) || ( StringUtil.StrCmp(Z2033UsuSerie2, T000Y2_A2033UsuSerie2[0]) != 0 ) || ( StringUtil.StrCmp(Z2034UsuSerie3, T000Y2_A2034UsuSerie3[0]) != 0 ) || ( StringUtil.StrCmp(Z2035UsuSerie4, T000Y2_A2035UsuSerie4[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2036UsuSerie5, T000Y2_A2036UsuSerie5[0]) != 0 ) || ( Z2030UsuReqADM != T000Y2_A2030UsuReqADM[0] ) || ( Z2009UsuAut1 != T000Y2_A2009UsuAut1[0] ) || ( Z2010UsuAut2 != T000Y2_A2010UsuAut2[0] ) || ( Z2020UsuOcMail != T000Y2_A2020UsuOcMail[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2014UsuEMAIL, T000Y2_A2014UsuEMAIL[0]) != 0 ) || ( Z2025UsuPedMail != T000Y2_A2025UsuPedMail[0] ) || ( StringUtil.StrCmp(Z2037UsuSOrden, T000Y2_A2037UsuSOrden[0]) != 0 ) || ( StringUtil.StrCmp(Z2038UsuSRet, T000Y2_A2038UsuSRet[0]) != 0 ) || ( StringUtil.StrCmp(Z2013UsuDep, T000Y2_A2013UsuDep[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2042UsuVendAut != T000Y2_A2042UsuVendAut[0] ) || ( Z69AreCod != T000Y2_A69AreCod[0] ) || ( Z2041UsuVend != T000Y2_A2041UsuVend[0] ) || ( Z2040UsuTieCod != T000Y2_A2040UsuTieCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z2021UsuPas, T000Y2_A2021UsuPas[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuPas");
                  GXUtil.WriteLogRaw("Old: ",Z2021UsuPas);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2021UsuPas[0]);
               }
               if ( StringUtil.StrCmp(Z2019UsuNom, T000Y2_A2019UsuNom[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuNom");
                  GXUtil.WriteLogRaw("Old: ",Z2019UsuNom);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2019UsuNom[0]);
               }
               if ( StringUtil.StrCmp(Z2031UsuSerie, T000Y2_A2031UsuSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSerie");
                  GXUtil.WriteLogRaw("Old: ",Z2031UsuSerie);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2031UsuSerie[0]);
               }
               if ( Z2011UsuAutOcom != T000Y2_A2011UsuAutOcom[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuAutOcom");
                  GXUtil.WriteLogRaw("Old: ",Z2011UsuAutOcom);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2011UsuAutOcom[0]);
               }
               if ( Z2012UsuAutPago != T000Y2_A2012UsuAutPago[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuAutPago");
                  GXUtil.WriteLogRaw("Old: ",Z2012UsuAutPago);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2012UsuAutPago[0]);
               }
               if ( Z2039UsuSts != T000Y2_A2039UsuSts[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSts");
                  GXUtil.WriteLogRaw("Old: ",Z2039UsuSts);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2039UsuSts[0]);
               }
               if ( StringUtil.StrCmp(Z2032UsuSerie1, T000Y2_A2032UsuSerie1[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSerie1");
                  GXUtil.WriteLogRaw("Old: ",Z2032UsuSerie1);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2032UsuSerie1[0]);
               }
               if ( StringUtil.StrCmp(Z2033UsuSerie2, T000Y2_A2033UsuSerie2[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSerie2");
                  GXUtil.WriteLogRaw("Old: ",Z2033UsuSerie2);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2033UsuSerie2[0]);
               }
               if ( StringUtil.StrCmp(Z2034UsuSerie3, T000Y2_A2034UsuSerie3[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSerie3");
                  GXUtil.WriteLogRaw("Old: ",Z2034UsuSerie3);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2034UsuSerie3[0]);
               }
               if ( StringUtil.StrCmp(Z2035UsuSerie4, T000Y2_A2035UsuSerie4[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSerie4");
                  GXUtil.WriteLogRaw("Old: ",Z2035UsuSerie4);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2035UsuSerie4[0]);
               }
               if ( StringUtil.StrCmp(Z2036UsuSerie5, T000Y2_A2036UsuSerie5[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSerie5");
                  GXUtil.WriteLogRaw("Old: ",Z2036UsuSerie5);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2036UsuSerie5[0]);
               }
               if ( Z2030UsuReqADM != T000Y2_A2030UsuReqADM[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuReqADM");
                  GXUtil.WriteLogRaw("Old: ",Z2030UsuReqADM);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2030UsuReqADM[0]);
               }
               if ( Z2009UsuAut1 != T000Y2_A2009UsuAut1[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuAut1");
                  GXUtil.WriteLogRaw("Old: ",Z2009UsuAut1);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2009UsuAut1[0]);
               }
               if ( Z2010UsuAut2 != T000Y2_A2010UsuAut2[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuAut2");
                  GXUtil.WriteLogRaw("Old: ",Z2010UsuAut2);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2010UsuAut2[0]);
               }
               if ( Z2020UsuOcMail != T000Y2_A2020UsuOcMail[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuOcMail");
                  GXUtil.WriteLogRaw("Old: ",Z2020UsuOcMail);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2020UsuOcMail[0]);
               }
               if ( StringUtil.StrCmp(Z2014UsuEMAIL, T000Y2_A2014UsuEMAIL[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuEMAIL");
                  GXUtil.WriteLogRaw("Old: ",Z2014UsuEMAIL);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2014UsuEMAIL[0]);
               }
               if ( Z2025UsuPedMail != T000Y2_A2025UsuPedMail[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuPedMail");
                  GXUtil.WriteLogRaw("Old: ",Z2025UsuPedMail);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2025UsuPedMail[0]);
               }
               if ( StringUtil.StrCmp(Z2037UsuSOrden, T000Y2_A2037UsuSOrden[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSOrden");
                  GXUtil.WriteLogRaw("Old: ",Z2037UsuSOrden);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2037UsuSOrden[0]);
               }
               if ( StringUtil.StrCmp(Z2038UsuSRet, T000Y2_A2038UsuSRet[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuSRet");
                  GXUtil.WriteLogRaw("Old: ",Z2038UsuSRet);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2038UsuSRet[0]);
               }
               if ( StringUtil.StrCmp(Z2013UsuDep, T000Y2_A2013UsuDep[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuDep");
                  GXUtil.WriteLogRaw("Old: ",Z2013UsuDep);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2013UsuDep[0]);
               }
               if ( Z2042UsuVendAut != T000Y2_A2042UsuVendAut[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuVendAut");
                  GXUtil.WriteLogRaw("Old: ",Z2042UsuVendAut);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2042UsuVendAut[0]);
               }
               if ( Z69AreCod != T000Y2_A69AreCod[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"AreCod");
                  GXUtil.WriteLogRaw("Old: ",Z69AreCod);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A69AreCod[0]);
               }
               if ( Z2041UsuVend != T000Y2_A2041UsuVend[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuVend");
                  GXUtil.WriteLogRaw("Old: ",Z2041UsuVend);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2041UsuVend[0]);
               }
               if ( Z2040UsuTieCod != T000Y2_A2040UsuTieCod[0] )
               {
                  GXUtil.WriteLog("sgusuarios:[seudo value changed for attri]"+"UsuTieCod");
                  GXUtil.WriteLogRaw("Old: ",Z2040UsuTieCod);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A2040UsuTieCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y32( )
      {
         BeforeValidate0Y32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y32( 0) ;
            CheckOptimisticConcurrency0Y32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y14 */
                     pr_default.execute(12, new Object[] {A348UsuCod, A2021UsuPas, A2019UsuNom, A2031UsuSerie, A2011UsuAutOcom, A2012UsuAutPago, A2039UsuSts, A2032UsuSerie1, A2033UsuSerie2, A2034UsuSerie3, A2035UsuSerie4, A2036UsuSerie5, A2030UsuReqADM, A2009UsuAut1, A2010UsuAut2, A2020UsuOcMail, A2014UsuEMAIL, A2025UsuPedMail, A2037UsuSOrden, A2038UsuSRet, A2013UsuDep, A2042UsuVendAut, n69AreCod, A69AreCod, A2041UsuVend, A2040UsuTieCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption0Y0( ) ;
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
               Load0Y32( ) ;
            }
            EndLevel0Y32( ) ;
         }
         CloseExtendedTableCursors0Y32( ) ;
      }

      protected void Update0Y32( )
      {
         BeforeValidate0Y32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y15 */
                     pr_default.execute(13, new Object[] {A2021UsuPas, A2019UsuNom, A2031UsuSerie, A2011UsuAutOcom, A2012UsuAutPago, A2039UsuSts, A2032UsuSerie1, A2033UsuSerie2, A2034UsuSerie3, A2035UsuSerie4, A2036UsuSerie5, A2030UsuReqADM, A2009UsuAut1, A2010UsuAut2, A2020UsuOcMail, A2014UsuEMAIL, A2025UsuPedMail, A2037UsuSOrden, A2038UsuSRet, A2013UsuDep, A2042UsuVendAut, n69AreCod, A69AreCod, A2041UsuVend, A2040UsuTieCod, A348UsuCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Y0( ) ;
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
            EndLevel0Y32( ) ;
         }
         CloseExtendedTableCursors0Y32( ) ;
      }

      protected void DeferredUpdate0Y32( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Y32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y32( ) ;
            AfterConfirm0Y32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Y16 */
                  pr_default.execute(14, new Object[] {A348UsuCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound32 == 0 )
                        {
                           InitAll0Y32( ) ;
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
                        ResetCaption0Y0( ) ;
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y32( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y17 */
            pr_default.execute(15, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000Y18 */
            pr_default.execute(16, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000Y19 */
            pr_default.execute(17, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000Y20 */
            pr_default.execute(18, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000Y21 */
            pr_default.execute(19, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000Y22 */
            pr_default.execute(20, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel0Y32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y32( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgusuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgusuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Y32( )
      {
         /* Using cursor T000Y23 */
         pr_default.execute(21);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T000Y23_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y32( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T000Y23_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
      }

      protected void ScanEnd0Y32( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0Y32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y32( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtUsuPas_Enabled = 0;
         AssignProp("", false, edtUsuPas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuPas_Enabled), 5, 0), true);
         edtUsuNom_Enabled = 0;
         AssignProp("", false, edtUsuNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuNom_Enabled), 5, 0), true);
         edtUsuSerie_Enabled = 0;
         AssignProp("", false, edtUsuSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerie_Enabled), 5, 0), true);
         chkUsuAutOcom.Enabled = 0;
         AssignProp("", false, chkUsuAutOcom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuAutOcom.Enabled), 5, 0), true);
         edtUsuAutPago_Enabled = 0;
         AssignProp("", false, edtUsuAutPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuAutPago_Enabled), 5, 0), true);
         cmbUsuSts.Enabled = 0;
         AssignProp("", false, cmbUsuSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuSts.Enabled), 5, 0), true);
         edtUsuSerie1_Enabled = 0;
         AssignProp("", false, edtUsuSerie1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerie1_Enabled), 5, 0), true);
         edtUsuSerie2_Enabled = 0;
         AssignProp("", false, edtUsuSerie2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerie2_Enabled), 5, 0), true);
         edtUsuSerie3_Enabled = 0;
         AssignProp("", false, edtUsuSerie3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerie3_Enabled), 5, 0), true);
         edtUsuSerie4_Enabled = 0;
         AssignProp("", false, edtUsuSerie4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerie4_Enabled), 5, 0), true);
         edtUsuVend_Enabled = 0;
         AssignProp("", false, edtUsuVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuVend_Enabled), 5, 0), true);
         edtUsuSerie5_Enabled = 0;
         AssignProp("", false, edtUsuSerie5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerie5_Enabled), 5, 0), true);
         chkUsuReqADM.Enabled = 0;
         AssignProp("", false, chkUsuReqADM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuReqADM.Enabled), 5, 0), true);
         edtUsuTieCod_Enabled = 0;
         AssignProp("", false, edtUsuTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuTieCod_Enabled), 5, 0), true);
         chkUsuAut1.Enabled = 0;
         AssignProp("", false, chkUsuAut1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuAut1.Enabled), 5, 0), true);
         chkUsuAut2.Enabled = 0;
         AssignProp("", false, chkUsuAut2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuAut2.Enabled), 5, 0), true);
         chkUsuOcMail.Enabled = 0;
         AssignProp("", false, chkUsuOcMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuOcMail.Enabled), 5, 0), true);
         edtUsuEMAIL_Enabled = 0;
         AssignProp("", false, edtUsuEMAIL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuEMAIL_Enabled), 5, 0), true);
         chkUsuPedMail.Enabled = 0;
         AssignProp("", false, chkUsuPedMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedMail.Enabled), 5, 0), true);
         edtUsuSOrden_Enabled = 0;
         AssignProp("", false, edtUsuSOrden_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSOrden_Enabled), 5, 0), true);
         edtAreCod_Enabled = 0;
         AssignProp("", false, edtAreCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreCod_Enabled), 5, 0), true);
         edtUsuSRet_Enabled = 0;
         AssignProp("", false, edtUsuSRet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSRet_Enabled), 5, 0), true);
         edtUsuDep_Enabled = 0;
         AssignProp("", false, edtUsuDep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuDep_Enabled), 5, 0), true);
         chkUsuVendAut.Enabled = 0;
         AssignProp("", false, chkUsuVendAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuVendAut.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Y32( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Y0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443657", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuarios.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z2021UsuPas", StringUtil.RTrim( Z2021UsuPas));
         GxWebStd.gx_hidden_field( context, "Z2019UsuNom", StringUtil.RTrim( Z2019UsuNom));
         GxWebStd.gx_hidden_field( context, "Z2031UsuSerie", StringUtil.RTrim( Z2031UsuSerie));
         GxWebStd.gx_hidden_field( context, "Z2011UsuAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2011UsuAutOcom), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2012UsuAutPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2012UsuAutPago), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2039UsuSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2039UsuSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2032UsuSerie1", StringUtil.RTrim( Z2032UsuSerie1));
         GxWebStd.gx_hidden_field( context, "Z2033UsuSerie2", StringUtil.RTrim( Z2033UsuSerie2));
         GxWebStd.gx_hidden_field( context, "Z2034UsuSerie3", StringUtil.RTrim( Z2034UsuSerie3));
         GxWebStd.gx_hidden_field( context, "Z2035UsuSerie4", StringUtil.RTrim( Z2035UsuSerie4));
         GxWebStd.gx_hidden_field( context, "Z2036UsuSerie5", StringUtil.RTrim( Z2036UsuSerie5));
         GxWebStd.gx_hidden_field( context, "Z2030UsuReqADM", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2030UsuReqADM), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2009UsuAut1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2009UsuAut1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2010UsuAut2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2010UsuAut2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2020UsuOcMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2020UsuOcMail), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2014UsuEMAIL", Z2014UsuEMAIL);
         GxWebStd.gx_hidden_field( context, "Z2025UsuPedMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2025UsuPedMail), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2037UsuSOrden", StringUtil.RTrim( Z2037UsuSOrden));
         GxWebStd.gx_hidden_field( context, "Z2038UsuSRet", StringUtil.RTrim( Z2038UsuSRet));
         GxWebStd.gx_hidden_field( context, "Z2013UsuDep", Z2013UsuDep);
         GxWebStd.gx_hidden_field( context, "Z2042UsuVendAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2042UsuVendAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69AreCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2041UsuVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2041UsuVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2040UsuTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2040UsuTieCod), 6, 0, ".", "")));
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
         return formatLink("sgusuarios.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIOS" ;
      }

      protected void InitializeNonKey0Y32( )
      {
         A2021UsuPas = "";
         AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
         A2019UsuNom = "";
         AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
         A2031UsuSerie = "";
         AssignAttri("", false, "A2031UsuSerie", A2031UsuSerie);
         A2011UsuAutOcom = 0;
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
         A2012UsuAutPago = 0;
         AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
         A2039UsuSts = 0;
         AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         A2032UsuSerie1 = "";
         AssignAttri("", false, "A2032UsuSerie1", A2032UsuSerie1);
         A2033UsuSerie2 = "";
         AssignAttri("", false, "A2033UsuSerie2", A2033UsuSerie2);
         A2034UsuSerie3 = "";
         AssignAttri("", false, "A2034UsuSerie3", A2034UsuSerie3);
         A2035UsuSerie4 = "";
         AssignAttri("", false, "A2035UsuSerie4", A2035UsuSerie4);
         A2041UsuVend = 0;
         AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
         A2036UsuSerie5 = "";
         AssignAttri("", false, "A2036UsuSerie5", A2036UsuSerie5);
         A2030UsuReqADM = 0;
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
         A2040UsuTieCod = 0;
         AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
         A2009UsuAut1 = 0;
         AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
         A2010UsuAut2 = 0;
         AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
         A2020UsuOcMail = 0;
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
         A2014UsuEMAIL = "";
         AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
         A2025UsuPedMail = 0;
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
         A2037UsuSOrden = "";
         AssignAttri("", false, "A2037UsuSOrden", A2037UsuSOrden);
         A69AreCod = 0;
         n69AreCod = false;
         AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
         n69AreCod = ((0==A69AreCod) ? true : false);
         A2038UsuSRet = "";
         AssignAttri("", false, "A2038UsuSRet", A2038UsuSRet);
         A2013UsuDep = "";
         AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
         A2042UsuVendAut = 0;
         AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
         Z2021UsuPas = "";
         Z2019UsuNom = "";
         Z2031UsuSerie = "";
         Z2011UsuAutOcom = 0;
         Z2012UsuAutPago = 0;
         Z2039UsuSts = 0;
         Z2032UsuSerie1 = "";
         Z2033UsuSerie2 = "";
         Z2034UsuSerie3 = "";
         Z2035UsuSerie4 = "";
         Z2036UsuSerie5 = "";
         Z2030UsuReqADM = 0;
         Z2009UsuAut1 = 0;
         Z2010UsuAut2 = 0;
         Z2020UsuOcMail = 0;
         Z2014UsuEMAIL = "";
         Z2025UsuPedMail = 0;
         Z2037UsuSOrden = "";
         Z2038UsuSRet = "";
         Z2013UsuDep = "";
         Z2042UsuVendAut = 0;
         Z69AreCod = 0;
         Z2041UsuVend = 0;
         Z2040UsuTieCod = 0;
      }

      protected void InitAll0Y32( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         InitializeNonKey0Y32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443676", true, true);
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
         context.AddJavascriptSource("sgusuarios.js", "?202281811443677", false, true);
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
         edtUsuCod_Internalname = "USUCOD";
         edtUsuPas_Internalname = "USUPAS";
         edtUsuNom_Internalname = "USUNOM";
         edtUsuSerie_Internalname = "USUSERIE";
         chkUsuAutOcom_Internalname = "USUAUTOCOM";
         edtUsuAutPago_Internalname = "USUAUTPAGO";
         cmbUsuSts_Internalname = "USUSTS";
         edtUsuSerie1_Internalname = "USUSERIE1";
         edtUsuSerie2_Internalname = "USUSERIE2";
         edtUsuSerie3_Internalname = "USUSERIE3";
         edtUsuSerie4_Internalname = "USUSERIE4";
         edtUsuVend_Internalname = "USUVEND";
         edtUsuSerie5_Internalname = "USUSERIE5";
         chkUsuReqADM_Internalname = "USUREQADM";
         edtUsuTieCod_Internalname = "USUTIECOD";
         chkUsuAut1_Internalname = "USUAUT1";
         chkUsuAut2_Internalname = "USUAUT2";
         chkUsuOcMail_Internalname = "USUOCMAIL";
         edtUsuEMAIL_Internalname = "USUEMAIL";
         chkUsuPedMail_Internalname = "USUPEDMAIL";
         edtUsuSOrden_Internalname = "USUSORDEN";
         edtAreCod_Internalname = "ARECOD";
         edtUsuSRet_Internalname = "USUSRET";
         edtUsuDep_Internalname = "USUDEP";
         chkUsuVendAut_Internalname = "USUVENDAUT";
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
         Form.Caption = "SGUSUARIOS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkUsuVendAut.Enabled = 1;
         edtUsuDep_Jsonclick = "";
         edtUsuDep_Enabled = 1;
         edtUsuSRet_Jsonclick = "";
         edtUsuSRet_Enabled = 1;
         edtAreCod_Jsonclick = "";
         edtAreCod_Enabled = 1;
         edtUsuSOrden_Jsonclick = "";
         edtUsuSOrden_Enabled = 1;
         chkUsuPedMail.Enabled = 1;
         edtUsuEMAIL_Jsonclick = "";
         edtUsuEMAIL_Enabled = 1;
         chkUsuOcMail.Enabled = 1;
         chkUsuAut2.Enabled = 1;
         chkUsuAut1.Enabled = 1;
         edtUsuTieCod_Jsonclick = "";
         edtUsuTieCod_Enabled = 1;
         chkUsuReqADM.Enabled = 1;
         edtUsuSerie5_Jsonclick = "";
         edtUsuSerie5_Enabled = 1;
         edtUsuVend_Jsonclick = "";
         edtUsuVend_Enabled = 1;
         edtUsuSerie4_Jsonclick = "";
         edtUsuSerie4_Enabled = 1;
         edtUsuSerie3_Jsonclick = "";
         edtUsuSerie3_Enabled = 1;
         edtUsuSerie2_Jsonclick = "";
         edtUsuSerie2_Enabled = 1;
         edtUsuSerie1_Jsonclick = "";
         edtUsuSerie1_Enabled = 1;
         cmbUsuSts_Jsonclick = "";
         cmbUsuSts.Enabled = 1;
         edtUsuAutPago_Jsonclick = "";
         edtUsuAutPago_Enabled = 1;
         chkUsuAutOcom.Enabled = 1;
         edtUsuSerie_Jsonclick = "";
         edtUsuSerie_Enabled = 1;
         edtUsuNom_Jsonclick = "";
         edtUsuNom_Enabled = 1;
         edtUsuPas_Jsonclick = "";
         edtUsuPas_Enabled = 1;
         edtUsuCod_Jsonclick = "";
         edtUsuCod_Enabled = 1;
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
         chkUsuAutOcom.Name = "USUAUTOCOM";
         chkUsuAutOcom.WebTags = "";
         chkUsuAutOcom.Caption = "";
         AssignProp("", false, chkUsuAutOcom_Internalname, "TitleCaption", chkUsuAutOcom.Caption, true);
         chkUsuAutOcom.CheckedValue = "0";
         A2011UsuAutOcom = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2011UsuAutOcom), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
         cmbUsuSts.Name = "USUSTS";
         cmbUsuSts.WebTags = "";
         cmbUsuSts.addItem("1", "ACTIVO", 0);
         cmbUsuSts.addItem("0", "INACTIVO", 0);
         if ( cmbUsuSts.ItemCount > 0 )
         {
            A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0))), "."));
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         }
         chkUsuReqADM.Name = "USUREQADM";
         chkUsuReqADM.WebTags = "";
         chkUsuReqADM.Caption = "";
         AssignProp("", false, chkUsuReqADM_Internalname, "TitleCaption", chkUsuReqADM.Caption, true);
         chkUsuReqADM.CheckedValue = "0";
         A2030UsuReqADM = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2030UsuReqADM), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
         chkUsuAut1.Name = "USUAUT1";
         chkUsuAut1.WebTags = "";
         chkUsuAut1.Caption = "";
         AssignProp("", false, chkUsuAut1_Internalname, "TitleCaption", chkUsuAut1.Caption, true);
         chkUsuAut1.CheckedValue = "0";
         A2009UsuAut1 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2009UsuAut1), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
         chkUsuAut2.Name = "USUAUT2";
         chkUsuAut2.WebTags = "";
         chkUsuAut2.Caption = "";
         AssignProp("", false, chkUsuAut2_Internalname, "TitleCaption", chkUsuAut2.Caption, true);
         chkUsuAut2.CheckedValue = "0";
         A2010UsuAut2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2010UsuAut2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
         chkUsuOcMail.Name = "USUOCMAIL";
         chkUsuOcMail.WebTags = "";
         chkUsuOcMail.Caption = "";
         AssignProp("", false, chkUsuOcMail_Internalname, "TitleCaption", chkUsuOcMail.Caption, true);
         chkUsuOcMail.CheckedValue = "0";
         A2020UsuOcMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2020UsuOcMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
         chkUsuPedMail.Name = "USUPEDMAIL";
         chkUsuPedMail.WebTags = "";
         chkUsuPedMail.Caption = "";
         AssignProp("", false, chkUsuPedMail_Internalname, "TitleCaption", chkUsuPedMail.Caption, true);
         chkUsuPedMail.CheckedValue = "0";
         A2025UsuPedMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2025UsuPedMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
         chkUsuVendAut.Name = "USUVENDAUT";
         chkUsuVendAut.WebTags = "";
         chkUsuVendAut.Caption = "";
         AssignProp("", false, chkUsuVendAut_Internalname, "TitleCaption", chkUsuVendAut.Caption, true);
         chkUsuVendAut.CheckedValue = "0";
         A2042UsuVendAut = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2042UsuVendAut), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2042UsuVendAut", StringUtil.Str( (decimal)(A2042UsuVendAut), 1, 0));
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtUsuPas_Internalname;
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

      public void Valid_Usucod( )
      {
         A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.CurrentValue, "."));
         cmbUsuSts.CurrentValue = StringUtil.Str( (decimal)(A2039UsuSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A2011UsuAutOcom = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2011UsuAutOcom), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         if ( cmbUsuSts.ItemCount > 0 )
         {
            A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0))), "."));
            cmbUsuSts.CurrentValue = StringUtil.Str( (decimal)(A2039UsuSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         }
         A2030UsuReqADM = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2030UsuReqADM), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2009UsuAut1 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2009UsuAut1), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2010UsuAut2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2010UsuAut2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2020UsuOcMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2020UsuOcMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2025UsuPedMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2025UsuPedMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2042UsuVendAut = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2042UsuVendAut), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         /*  Sending validation outputs */
         AssignAttri("", false, "A2021UsuPas", StringUtil.RTrim( A2021UsuPas));
         AssignAttri("", false, "A2019UsuNom", StringUtil.RTrim( A2019UsuNom));
         AssignAttri("", false, "A2031UsuSerie", StringUtil.RTrim( A2031UsuSerie));
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2011UsuAutOcom), 1, 0, ".", "")));
         AssignAttri("", false, "A2012UsuAutPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2012UsuAutPago), 1, 0, ".", "")));
         AssignAttri("", false, "A2039UsuSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2039UsuSts), 1, 0, ".", "")));
         cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         AssignProp("", false, cmbUsuSts_Internalname, "Values", cmbUsuSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A2032UsuSerie1", StringUtil.RTrim( A2032UsuSerie1));
         AssignAttri("", false, "A2033UsuSerie2", StringUtil.RTrim( A2033UsuSerie2));
         AssignAttri("", false, "A2034UsuSerie3", StringUtil.RTrim( A2034UsuSerie3));
         AssignAttri("", false, "A2035UsuSerie4", StringUtil.RTrim( A2035UsuSerie4));
         AssignAttri("", false, "A2041UsuVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2041UsuVend), 6, 0, ".", "")));
         AssignAttri("", false, "A2036UsuSerie5", StringUtil.RTrim( A2036UsuSerie5));
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2030UsuReqADM), 1, 0, ".", "")));
         AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2040UsuTieCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2009UsuAut1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2009UsuAut1), 1, 0, ".", "")));
         AssignAttri("", false, "A2010UsuAut2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2010UsuAut2), 1, 0, ".", "")));
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2020UsuOcMail), 1, 0, ".", "")));
         AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2025UsuPedMail), 1, 0, ".", "")));
         AssignAttri("", false, "A2037UsuSOrden", StringUtil.RTrim( A2037UsuSOrden));
         AssignAttri("", false, "A69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69AreCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2038UsuSRet", StringUtil.RTrim( A2038UsuSRet));
         AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
         AssignAttri("", false, "A2042UsuVendAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2042UsuVendAut), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z2021UsuPas", StringUtil.RTrim( Z2021UsuPas));
         GxWebStd.gx_hidden_field( context, "Z2019UsuNom", StringUtil.RTrim( Z2019UsuNom));
         GxWebStd.gx_hidden_field( context, "Z2031UsuSerie", StringUtil.RTrim( Z2031UsuSerie));
         GxWebStd.gx_hidden_field( context, "Z2011UsuAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2011UsuAutOcom), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2012UsuAutPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2012UsuAutPago), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2039UsuSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2039UsuSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2032UsuSerie1", StringUtil.RTrim( Z2032UsuSerie1));
         GxWebStd.gx_hidden_field( context, "Z2033UsuSerie2", StringUtil.RTrim( Z2033UsuSerie2));
         GxWebStd.gx_hidden_field( context, "Z2034UsuSerie3", StringUtil.RTrim( Z2034UsuSerie3));
         GxWebStd.gx_hidden_field( context, "Z2035UsuSerie4", StringUtil.RTrim( Z2035UsuSerie4));
         GxWebStd.gx_hidden_field( context, "Z2041UsuVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2041UsuVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2036UsuSerie5", StringUtil.RTrim( Z2036UsuSerie5));
         GxWebStd.gx_hidden_field( context, "Z2030UsuReqADM", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2030UsuReqADM), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2040UsuTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2040UsuTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2009UsuAut1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2009UsuAut1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2010UsuAut2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2010UsuAut2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2020UsuOcMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2020UsuOcMail), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2014UsuEMAIL", Z2014UsuEMAIL);
         GxWebStd.gx_hidden_field( context, "Z2025UsuPedMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2025UsuPedMail), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2037UsuSOrden", StringUtil.RTrim( Z2037UsuSOrden));
         GxWebStd.gx_hidden_field( context, "Z69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69AreCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2038UsuSRet", StringUtil.RTrim( Z2038UsuSRet));
         GxWebStd.gx_hidden_field( context, "Z2013UsuDep", Z2013UsuDep);
         GxWebStd.gx_hidden_field( context, "Z2042UsuVendAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2042UsuVendAut), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usuvend( )
      {
         /* Using cursor T000Y24 */
         pr_default.execute(22, new Object[] {A2041UsuVend});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "USUVEND");
            AnyError = 1;
            GX_FocusControl = edtUsuVend_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usutiecod( )
      {
         /* Using cursor T000Y25 */
         pr_default.execute(23, new Object[] {A2040UsuTieCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Tienda'.", "ForeignKeyNotFound", 1, "USUTIECOD");
            AnyError = 1;
            GX_FocusControl = edtUsuTieCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Arecod( )
      {
         n69AreCod = false;
         /* Using cursor T000Y26 */
         pr_default.execute(24, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A69AreCod) ) )
            {
               GX_msglist.addItem("No existe 'Areas Empresa'.", "ForeignKeyNotFound", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]}");
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'cmbUsuSts'},{av:'A2039UsuSts',fld:'USUSTS',pic:'9'},{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]");
         setEventMetadata("VALID_USUCOD",",oparms:[{av:'A2021UsuPas',fld:'USUPAS',pic:''},{av:'A2019UsuNom',fld:'USUNOM',pic:''},{av:'A2031UsuSerie',fld:'USUSERIE',pic:''},{av:'A2012UsuAutPago',fld:'USUAUTPAGO',pic:'9'},{av:'cmbUsuSts'},{av:'A2039UsuSts',fld:'USUSTS',pic:'9'},{av:'A2032UsuSerie1',fld:'USUSERIE1',pic:''},{av:'A2033UsuSerie2',fld:'USUSERIE2',pic:''},{av:'A2034UsuSerie3',fld:'USUSERIE3',pic:''},{av:'A2035UsuSerie4',fld:'USUSERIE4',pic:''},{av:'A2041UsuVend',fld:'USUVEND',pic:'ZZZZZ9'},{av:'A2036UsuSerie5',fld:'USUSERIE5',pic:''},{av:'A2040UsuTieCod',fld:'USUTIECOD',pic:'ZZZZZ9'},{av:'A2014UsuEMAIL',fld:'USUEMAIL',pic:''},{av:'A2037UsuSOrden',fld:'USUSORDEN',pic:''},{av:'A69AreCod',fld:'ARECOD',pic:'ZZZZZ9'},{av:'A2038UsuSRet',fld:'USUSRET',pic:''},{av:'A2013UsuDep',fld:'USUDEP',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z2021UsuPas'},{av:'Z2019UsuNom'},{av:'Z2031UsuSerie'},{av:'Z2011UsuAutOcom'},{av:'Z2012UsuAutPago'},{av:'Z2039UsuSts'},{av:'Z2032UsuSerie1'},{av:'Z2033UsuSerie2'},{av:'Z2034UsuSerie3'},{av:'Z2035UsuSerie4'},{av:'Z2041UsuVend'},{av:'Z2036UsuSerie5'},{av:'Z2030UsuReqADM'},{av:'Z2040UsuTieCod'},{av:'Z2009UsuAut1'},{av:'Z2010UsuAut2'},{av:'Z2020UsuOcMail'},{av:'Z2014UsuEMAIL'},{av:'Z2025UsuPedMail'},{av:'Z2037UsuSOrden'},{av:'Z69AreCod'},{av:'Z2038UsuSRet'},{av:'Z2013UsuDep'},{av:'Z2042UsuVendAut'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]}");
         setEventMetadata("VALID_USUVEND","{handler:'Valid_Usuvend',iparms:[{av:'A2041UsuVend',fld:'USUVEND',pic:'ZZZZZ9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]");
         setEventMetadata("VALID_USUVEND",",oparms:[{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]}");
         setEventMetadata("VALID_USUTIECOD","{handler:'Valid_Usutiecod',iparms:[{av:'A2040UsuTieCod',fld:'USUTIECOD',pic:'ZZZZZ9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]");
         setEventMetadata("VALID_USUTIECOD",",oparms:[{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]}");
         setEventMetadata("VALID_ARECOD","{handler:'Valid_Arecod',iparms:[{av:'A69AreCod',fld:'ARECOD',pic:'ZZZZZ9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]");
         setEventMetadata("VALID_ARECOD",",oparms:[{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'},{av:'A2042UsuVendAut',fld:'USUVENDAUT',pic:'9'}]}");
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
         pr_default.close(24);
         pr_default.close(22);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         Z2021UsuPas = "";
         Z2019UsuNom = "";
         Z2031UsuSerie = "";
         Z2032UsuSerie1 = "";
         Z2033UsuSerie2 = "";
         Z2034UsuSerie3 = "";
         Z2035UsuSerie4 = "";
         Z2036UsuSerie5 = "";
         Z2014UsuEMAIL = "";
         Z2037UsuSOrden = "";
         Z2038UsuSRet = "";
         Z2013UsuDep = "";
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
         A348UsuCod = "";
         A2021UsuPas = "";
         A2019UsuNom = "";
         A2031UsuSerie = "";
         A2032UsuSerie1 = "";
         A2033UsuSerie2 = "";
         A2034UsuSerie3 = "";
         A2035UsuSerie4 = "";
         A2036UsuSerie5 = "";
         A2014UsuEMAIL = "";
         A2037UsuSOrden = "";
         A2038UsuSRet = "";
         A2013UsuDep = "";
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
         T000Y7_A348UsuCod = new string[] {""} ;
         T000Y7_A2021UsuPas = new string[] {""} ;
         T000Y7_A2019UsuNom = new string[] {""} ;
         T000Y7_A2031UsuSerie = new string[] {""} ;
         T000Y7_A2011UsuAutOcom = new short[1] ;
         T000Y7_A2012UsuAutPago = new short[1] ;
         T000Y7_A2039UsuSts = new short[1] ;
         T000Y7_A2032UsuSerie1 = new string[] {""} ;
         T000Y7_A2033UsuSerie2 = new string[] {""} ;
         T000Y7_A2034UsuSerie3 = new string[] {""} ;
         T000Y7_A2035UsuSerie4 = new string[] {""} ;
         T000Y7_A2036UsuSerie5 = new string[] {""} ;
         T000Y7_A2030UsuReqADM = new short[1] ;
         T000Y7_A2009UsuAut1 = new short[1] ;
         T000Y7_A2010UsuAut2 = new short[1] ;
         T000Y7_A2020UsuOcMail = new short[1] ;
         T000Y7_A2014UsuEMAIL = new string[] {""} ;
         T000Y7_A2025UsuPedMail = new short[1] ;
         T000Y7_A2037UsuSOrden = new string[] {""} ;
         T000Y7_A2038UsuSRet = new string[] {""} ;
         T000Y7_A2013UsuDep = new string[] {""} ;
         T000Y7_A2042UsuVendAut = new short[1] ;
         T000Y7_A69AreCod = new int[1] ;
         T000Y7_n69AreCod = new bool[] {false} ;
         T000Y7_A2041UsuVend = new int[1] ;
         T000Y7_A2040UsuTieCod = new int[1] ;
         T000Y5_A2041UsuVend = new int[1] ;
         T000Y6_A2040UsuTieCod = new int[1] ;
         T000Y4_A69AreCod = new int[1] ;
         T000Y4_n69AreCod = new bool[] {false} ;
         T000Y8_A2041UsuVend = new int[1] ;
         T000Y9_A2040UsuTieCod = new int[1] ;
         T000Y10_A69AreCod = new int[1] ;
         T000Y10_n69AreCod = new bool[] {false} ;
         T000Y11_A348UsuCod = new string[] {""} ;
         T000Y3_A348UsuCod = new string[] {""} ;
         T000Y3_A2021UsuPas = new string[] {""} ;
         T000Y3_A2019UsuNom = new string[] {""} ;
         T000Y3_A2031UsuSerie = new string[] {""} ;
         T000Y3_A2011UsuAutOcom = new short[1] ;
         T000Y3_A2012UsuAutPago = new short[1] ;
         T000Y3_A2039UsuSts = new short[1] ;
         T000Y3_A2032UsuSerie1 = new string[] {""} ;
         T000Y3_A2033UsuSerie2 = new string[] {""} ;
         T000Y3_A2034UsuSerie3 = new string[] {""} ;
         T000Y3_A2035UsuSerie4 = new string[] {""} ;
         T000Y3_A2036UsuSerie5 = new string[] {""} ;
         T000Y3_A2030UsuReqADM = new short[1] ;
         T000Y3_A2009UsuAut1 = new short[1] ;
         T000Y3_A2010UsuAut2 = new short[1] ;
         T000Y3_A2020UsuOcMail = new short[1] ;
         T000Y3_A2014UsuEMAIL = new string[] {""} ;
         T000Y3_A2025UsuPedMail = new short[1] ;
         T000Y3_A2037UsuSOrden = new string[] {""} ;
         T000Y3_A2038UsuSRet = new string[] {""} ;
         T000Y3_A2013UsuDep = new string[] {""} ;
         T000Y3_A2042UsuVendAut = new short[1] ;
         T000Y3_A69AreCod = new int[1] ;
         T000Y3_n69AreCod = new bool[] {false} ;
         T000Y3_A2041UsuVend = new int[1] ;
         T000Y3_A2040UsuTieCod = new int[1] ;
         sMode32 = "";
         T000Y12_A348UsuCod = new string[] {""} ;
         T000Y13_A348UsuCod = new string[] {""} ;
         T000Y2_A348UsuCod = new string[] {""} ;
         T000Y2_A2021UsuPas = new string[] {""} ;
         T000Y2_A2019UsuNom = new string[] {""} ;
         T000Y2_A2031UsuSerie = new string[] {""} ;
         T000Y2_A2011UsuAutOcom = new short[1] ;
         T000Y2_A2012UsuAutPago = new short[1] ;
         T000Y2_A2039UsuSts = new short[1] ;
         T000Y2_A2032UsuSerie1 = new string[] {""} ;
         T000Y2_A2033UsuSerie2 = new string[] {""} ;
         T000Y2_A2034UsuSerie3 = new string[] {""} ;
         T000Y2_A2035UsuSerie4 = new string[] {""} ;
         T000Y2_A2036UsuSerie5 = new string[] {""} ;
         T000Y2_A2030UsuReqADM = new short[1] ;
         T000Y2_A2009UsuAut1 = new short[1] ;
         T000Y2_A2010UsuAut2 = new short[1] ;
         T000Y2_A2020UsuOcMail = new short[1] ;
         T000Y2_A2014UsuEMAIL = new string[] {""} ;
         T000Y2_A2025UsuPedMail = new short[1] ;
         T000Y2_A2037UsuSOrden = new string[] {""} ;
         T000Y2_A2038UsuSRet = new string[] {""} ;
         T000Y2_A2013UsuDep = new string[] {""} ;
         T000Y2_A2042UsuVendAut = new short[1] ;
         T000Y2_A69AreCod = new int[1] ;
         T000Y2_n69AreCod = new bool[] {false} ;
         T000Y2_A2041UsuVend = new int[1] ;
         T000Y2_A2040UsuTieCod = new int[1] ;
         T000Y17_A2237SGNotificacionID = new long[1] ;
         T000Y17_A2245SGNotificacionDetID = new short[1] ;
         T000Y18_A2237SGNotificacionID = new long[1] ;
         T000Y19_A348UsuCod = new string[] {""} ;
         T000Y19_A149TipCod = new string[] {""} ;
         T000Y19_A351UsuSerDet = new string[] {""} ;
         T000Y20_A348UsuCod = new string[] {""} ;
         T000Y20_A346ObjCod = new int[1] ;
         T000Y21_A348UsuCod = new string[] {""} ;
         T000Y21_A342SGMenuPrograma = new string[] {""} ;
         T000Y21_A343SGMenuNiv1ID = new string[] {""} ;
         T000Y22_A348UsuCod = new string[] {""} ;
         T000Y22_A349UsuAlmCod = new int[1] ;
         T000Y23_A348UsuCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ348UsuCod = "";
         ZZ2021UsuPas = "";
         ZZ2019UsuNom = "";
         ZZ2031UsuSerie = "";
         ZZ2032UsuSerie1 = "";
         ZZ2033UsuSerie2 = "";
         ZZ2034UsuSerie3 = "";
         ZZ2035UsuSerie4 = "";
         ZZ2036UsuSerie5 = "";
         ZZ2014UsuEMAIL = "";
         ZZ2037UsuSOrden = "";
         ZZ2038UsuSRet = "";
         ZZ2013UsuDep = "";
         T000Y24_A2041UsuVend = new int[1] ;
         T000Y25_A2040UsuTieCod = new int[1] ;
         T000Y26_A69AreCod = new int[1] ;
         T000Y26_n69AreCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarios__default(),
            new Object[][] {
                new Object[] {
               T000Y2_A348UsuCod, T000Y2_A2021UsuPas, T000Y2_A2019UsuNom, T000Y2_A2031UsuSerie, T000Y2_A2011UsuAutOcom, T000Y2_A2012UsuAutPago, T000Y2_A2039UsuSts, T000Y2_A2032UsuSerie1, T000Y2_A2033UsuSerie2, T000Y2_A2034UsuSerie3,
               T000Y2_A2035UsuSerie4, T000Y2_A2036UsuSerie5, T000Y2_A2030UsuReqADM, T000Y2_A2009UsuAut1, T000Y2_A2010UsuAut2, T000Y2_A2020UsuOcMail, T000Y2_A2014UsuEMAIL, T000Y2_A2025UsuPedMail, T000Y2_A2037UsuSOrden, T000Y2_A2038UsuSRet,
               T000Y2_A2013UsuDep, T000Y2_A2042UsuVendAut, T000Y2_A69AreCod, T000Y2_n69AreCod, T000Y2_A2041UsuVend, T000Y2_A2040UsuTieCod
               }
               , new Object[] {
               T000Y3_A348UsuCod, T000Y3_A2021UsuPas, T000Y3_A2019UsuNom, T000Y3_A2031UsuSerie, T000Y3_A2011UsuAutOcom, T000Y3_A2012UsuAutPago, T000Y3_A2039UsuSts, T000Y3_A2032UsuSerie1, T000Y3_A2033UsuSerie2, T000Y3_A2034UsuSerie3,
               T000Y3_A2035UsuSerie4, T000Y3_A2036UsuSerie5, T000Y3_A2030UsuReqADM, T000Y3_A2009UsuAut1, T000Y3_A2010UsuAut2, T000Y3_A2020UsuOcMail, T000Y3_A2014UsuEMAIL, T000Y3_A2025UsuPedMail, T000Y3_A2037UsuSOrden, T000Y3_A2038UsuSRet,
               T000Y3_A2013UsuDep, T000Y3_A2042UsuVendAut, T000Y3_A69AreCod, T000Y3_n69AreCod, T000Y3_A2041UsuVend, T000Y3_A2040UsuTieCod
               }
               , new Object[] {
               T000Y4_A69AreCod
               }
               , new Object[] {
               T000Y5_A2041UsuVend
               }
               , new Object[] {
               T000Y6_A2040UsuTieCod
               }
               , new Object[] {
               T000Y7_A348UsuCod, T000Y7_A2021UsuPas, T000Y7_A2019UsuNom, T000Y7_A2031UsuSerie, T000Y7_A2011UsuAutOcom, T000Y7_A2012UsuAutPago, T000Y7_A2039UsuSts, T000Y7_A2032UsuSerie1, T000Y7_A2033UsuSerie2, T000Y7_A2034UsuSerie3,
               T000Y7_A2035UsuSerie4, T000Y7_A2036UsuSerie5, T000Y7_A2030UsuReqADM, T000Y7_A2009UsuAut1, T000Y7_A2010UsuAut2, T000Y7_A2020UsuOcMail, T000Y7_A2014UsuEMAIL, T000Y7_A2025UsuPedMail, T000Y7_A2037UsuSOrden, T000Y7_A2038UsuSRet,
               T000Y7_A2013UsuDep, T000Y7_A2042UsuVendAut, T000Y7_A69AreCod, T000Y7_n69AreCod, T000Y7_A2041UsuVend, T000Y7_A2040UsuTieCod
               }
               , new Object[] {
               T000Y8_A2041UsuVend
               }
               , new Object[] {
               T000Y9_A2040UsuTieCod
               }
               , new Object[] {
               T000Y10_A69AreCod
               }
               , new Object[] {
               T000Y11_A348UsuCod
               }
               , new Object[] {
               T000Y12_A348UsuCod
               }
               , new Object[] {
               T000Y13_A348UsuCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y17_A2237SGNotificacionID, T000Y17_A2245SGNotificacionDetID
               }
               , new Object[] {
               T000Y18_A2237SGNotificacionID
               }
               , new Object[] {
               T000Y19_A348UsuCod, T000Y19_A149TipCod, T000Y19_A351UsuSerDet
               }
               , new Object[] {
               T000Y20_A348UsuCod, T000Y20_A346ObjCod
               }
               , new Object[] {
               T000Y21_A348UsuCod, T000Y21_A342SGMenuPrograma, T000Y21_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000Y22_A348UsuCod, T000Y22_A349UsuAlmCod
               }
               , new Object[] {
               T000Y23_A348UsuCod
               }
               , new Object[] {
               T000Y24_A2041UsuVend
               }
               , new Object[] {
               T000Y25_A2040UsuTieCod
               }
               , new Object[] {
               T000Y26_A69AreCod
               }
            }
         );
      }

      private short Z2011UsuAutOcom ;
      private short Z2012UsuAutPago ;
      private short Z2039UsuSts ;
      private short Z2030UsuReqADM ;
      private short Z2009UsuAut1 ;
      private short Z2010UsuAut2 ;
      private short Z2020UsuOcMail ;
      private short Z2025UsuPedMail ;
      private short Z2042UsuVendAut ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2011UsuAutOcom ;
      private short A2039UsuSts ;
      private short A2030UsuReqADM ;
      private short A2009UsuAut1 ;
      private short A2010UsuAut2 ;
      private short A2020UsuOcMail ;
      private short A2025UsuPedMail ;
      private short A2042UsuVendAut ;
      private short A2012UsuAutPago ;
      private short GX_JID ;
      private short RcdFound32 ;
      private short nIsDirty_32 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2011UsuAutOcom ;
      private short ZZ2012UsuAutPago ;
      private short ZZ2039UsuSts ;
      private short ZZ2030UsuReqADM ;
      private short ZZ2009UsuAut1 ;
      private short ZZ2010UsuAut2 ;
      private short ZZ2020UsuOcMail ;
      private short ZZ2025UsuPedMail ;
      private short ZZ2042UsuVendAut ;
      private int Z69AreCod ;
      private int Z2041UsuVend ;
      private int Z2040UsuTieCod ;
      private int A2041UsuVend ;
      private int A2040UsuTieCod ;
      private int A69AreCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtUsuPas_Enabled ;
      private int edtUsuNom_Enabled ;
      private int edtUsuSerie_Enabled ;
      private int edtUsuAutPago_Enabled ;
      private int edtUsuSerie1_Enabled ;
      private int edtUsuSerie2_Enabled ;
      private int edtUsuSerie3_Enabled ;
      private int edtUsuSerie4_Enabled ;
      private int edtUsuVend_Enabled ;
      private int edtUsuSerie5_Enabled ;
      private int edtUsuTieCod_Enabled ;
      private int edtUsuEMAIL_Enabled ;
      private int edtUsuSOrden_Enabled ;
      private int edtAreCod_Enabled ;
      private int edtUsuSRet_Enabled ;
      private int edtUsuDep_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2041UsuVend ;
      private int ZZ2040UsuTieCod ;
      private int ZZ69AreCod ;
      private string sPrefix ;
      private string Z348UsuCod ;
      private string Z2021UsuPas ;
      private string Z2019UsuNom ;
      private string Z2031UsuSerie ;
      private string Z2032UsuSerie1 ;
      private string Z2033UsuSerie2 ;
      private string Z2034UsuSerie3 ;
      private string Z2035UsuSerie4 ;
      private string Z2036UsuSerie5 ;
      private string Z2037UsuSOrden ;
      private string Z2038UsuSRet ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUsuCod_Internalname ;
      private string cmbUsuSts_Internalname ;
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
      private string A348UsuCod ;
      private string edtUsuCod_Jsonclick ;
      private string edtUsuPas_Internalname ;
      private string A2021UsuPas ;
      private string edtUsuPas_Jsonclick ;
      private string edtUsuNom_Internalname ;
      private string A2019UsuNom ;
      private string edtUsuNom_Jsonclick ;
      private string edtUsuSerie_Internalname ;
      private string A2031UsuSerie ;
      private string edtUsuSerie_Jsonclick ;
      private string chkUsuAutOcom_Internalname ;
      private string edtUsuAutPago_Internalname ;
      private string edtUsuAutPago_Jsonclick ;
      private string cmbUsuSts_Jsonclick ;
      private string edtUsuSerie1_Internalname ;
      private string A2032UsuSerie1 ;
      private string edtUsuSerie1_Jsonclick ;
      private string edtUsuSerie2_Internalname ;
      private string A2033UsuSerie2 ;
      private string edtUsuSerie2_Jsonclick ;
      private string edtUsuSerie3_Internalname ;
      private string A2034UsuSerie3 ;
      private string edtUsuSerie3_Jsonclick ;
      private string edtUsuSerie4_Internalname ;
      private string A2035UsuSerie4 ;
      private string edtUsuSerie4_Jsonclick ;
      private string edtUsuVend_Internalname ;
      private string edtUsuVend_Jsonclick ;
      private string edtUsuSerie5_Internalname ;
      private string A2036UsuSerie5 ;
      private string edtUsuSerie5_Jsonclick ;
      private string chkUsuReqADM_Internalname ;
      private string edtUsuTieCod_Internalname ;
      private string edtUsuTieCod_Jsonclick ;
      private string chkUsuAut1_Internalname ;
      private string chkUsuAut2_Internalname ;
      private string chkUsuOcMail_Internalname ;
      private string edtUsuEMAIL_Internalname ;
      private string edtUsuEMAIL_Jsonclick ;
      private string chkUsuPedMail_Internalname ;
      private string edtUsuSOrden_Internalname ;
      private string A2037UsuSOrden ;
      private string edtUsuSOrden_Jsonclick ;
      private string edtAreCod_Internalname ;
      private string edtAreCod_Jsonclick ;
      private string edtUsuSRet_Internalname ;
      private string A2038UsuSRet ;
      private string edtUsuSRet_Jsonclick ;
      private string edtUsuDep_Internalname ;
      private string edtUsuDep_Jsonclick ;
      private string chkUsuVendAut_Internalname ;
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
      private string sMode32 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private string ZZ2021UsuPas ;
      private string ZZ2019UsuNom ;
      private string ZZ2031UsuSerie ;
      private string ZZ2032UsuSerie1 ;
      private string ZZ2033UsuSerie2 ;
      private string ZZ2034UsuSerie3 ;
      private string ZZ2035UsuSerie4 ;
      private string ZZ2036UsuSerie5 ;
      private string ZZ2037UsuSOrden ;
      private string ZZ2038UsuSRet ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n69AreCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2014UsuEMAIL ;
      private string Z2013UsuDep ;
      private string A2014UsuEMAIL ;
      private string A2013UsuDep ;
      private string ZZ2014UsuEMAIL ;
      private string ZZ2013UsuDep ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkUsuAutOcom ;
      private GXCombobox cmbUsuSts ;
      private GXCheckbox chkUsuReqADM ;
      private GXCheckbox chkUsuAut1 ;
      private GXCheckbox chkUsuAut2 ;
      private GXCheckbox chkUsuOcMail ;
      private GXCheckbox chkUsuPedMail ;
      private GXCheckbox chkUsuVendAut ;
      private IDataStoreProvider pr_default ;
      private string[] T000Y7_A348UsuCod ;
      private string[] T000Y7_A2021UsuPas ;
      private string[] T000Y7_A2019UsuNom ;
      private string[] T000Y7_A2031UsuSerie ;
      private short[] T000Y7_A2011UsuAutOcom ;
      private short[] T000Y7_A2012UsuAutPago ;
      private short[] T000Y7_A2039UsuSts ;
      private string[] T000Y7_A2032UsuSerie1 ;
      private string[] T000Y7_A2033UsuSerie2 ;
      private string[] T000Y7_A2034UsuSerie3 ;
      private string[] T000Y7_A2035UsuSerie4 ;
      private string[] T000Y7_A2036UsuSerie5 ;
      private short[] T000Y7_A2030UsuReqADM ;
      private short[] T000Y7_A2009UsuAut1 ;
      private short[] T000Y7_A2010UsuAut2 ;
      private short[] T000Y7_A2020UsuOcMail ;
      private string[] T000Y7_A2014UsuEMAIL ;
      private short[] T000Y7_A2025UsuPedMail ;
      private string[] T000Y7_A2037UsuSOrden ;
      private string[] T000Y7_A2038UsuSRet ;
      private string[] T000Y7_A2013UsuDep ;
      private short[] T000Y7_A2042UsuVendAut ;
      private int[] T000Y7_A69AreCod ;
      private bool[] T000Y7_n69AreCod ;
      private int[] T000Y7_A2041UsuVend ;
      private int[] T000Y7_A2040UsuTieCod ;
      private int[] T000Y5_A2041UsuVend ;
      private int[] T000Y6_A2040UsuTieCod ;
      private int[] T000Y4_A69AreCod ;
      private bool[] T000Y4_n69AreCod ;
      private int[] T000Y8_A2041UsuVend ;
      private int[] T000Y9_A2040UsuTieCod ;
      private int[] T000Y10_A69AreCod ;
      private bool[] T000Y10_n69AreCod ;
      private string[] T000Y11_A348UsuCod ;
      private string[] T000Y3_A348UsuCod ;
      private string[] T000Y3_A2021UsuPas ;
      private string[] T000Y3_A2019UsuNom ;
      private string[] T000Y3_A2031UsuSerie ;
      private short[] T000Y3_A2011UsuAutOcom ;
      private short[] T000Y3_A2012UsuAutPago ;
      private short[] T000Y3_A2039UsuSts ;
      private string[] T000Y3_A2032UsuSerie1 ;
      private string[] T000Y3_A2033UsuSerie2 ;
      private string[] T000Y3_A2034UsuSerie3 ;
      private string[] T000Y3_A2035UsuSerie4 ;
      private string[] T000Y3_A2036UsuSerie5 ;
      private short[] T000Y3_A2030UsuReqADM ;
      private short[] T000Y3_A2009UsuAut1 ;
      private short[] T000Y3_A2010UsuAut2 ;
      private short[] T000Y3_A2020UsuOcMail ;
      private string[] T000Y3_A2014UsuEMAIL ;
      private short[] T000Y3_A2025UsuPedMail ;
      private string[] T000Y3_A2037UsuSOrden ;
      private string[] T000Y3_A2038UsuSRet ;
      private string[] T000Y3_A2013UsuDep ;
      private short[] T000Y3_A2042UsuVendAut ;
      private int[] T000Y3_A69AreCod ;
      private bool[] T000Y3_n69AreCod ;
      private int[] T000Y3_A2041UsuVend ;
      private int[] T000Y3_A2040UsuTieCod ;
      private string[] T000Y12_A348UsuCod ;
      private string[] T000Y13_A348UsuCod ;
      private string[] T000Y2_A348UsuCod ;
      private string[] T000Y2_A2021UsuPas ;
      private string[] T000Y2_A2019UsuNom ;
      private string[] T000Y2_A2031UsuSerie ;
      private short[] T000Y2_A2011UsuAutOcom ;
      private short[] T000Y2_A2012UsuAutPago ;
      private short[] T000Y2_A2039UsuSts ;
      private string[] T000Y2_A2032UsuSerie1 ;
      private string[] T000Y2_A2033UsuSerie2 ;
      private string[] T000Y2_A2034UsuSerie3 ;
      private string[] T000Y2_A2035UsuSerie4 ;
      private string[] T000Y2_A2036UsuSerie5 ;
      private short[] T000Y2_A2030UsuReqADM ;
      private short[] T000Y2_A2009UsuAut1 ;
      private short[] T000Y2_A2010UsuAut2 ;
      private short[] T000Y2_A2020UsuOcMail ;
      private string[] T000Y2_A2014UsuEMAIL ;
      private short[] T000Y2_A2025UsuPedMail ;
      private string[] T000Y2_A2037UsuSOrden ;
      private string[] T000Y2_A2038UsuSRet ;
      private string[] T000Y2_A2013UsuDep ;
      private short[] T000Y2_A2042UsuVendAut ;
      private int[] T000Y2_A69AreCod ;
      private bool[] T000Y2_n69AreCod ;
      private int[] T000Y2_A2041UsuVend ;
      private int[] T000Y2_A2040UsuTieCod ;
      private long[] T000Y17_A2237SGNotificacionID ;
      private short[] T000Y17_A2245SGNotificacionDetID ;
      private long[] T000Y18_A2237SGNotificacionID ;
      private string[] T000Y19_A348UsuCod ;
      private string[] T000Y19_A149TipCod ;
      private string[] T000Y19_A351UsuSerDet ;
      private string[] T000Y20_A348UsuCod ;
      private int[] T000Y20_A346ObjCod ;
      private string[] T000Y21_A348UsuCod ;
      private string[] T000Y21_A342SGMenuPrograma ;
      private string[] T000Y21_A343SGMenuNiv1ID ;
      private string[] T000Y22_A348UsuCod ;
      private int[] T000Y22_A349UsuAlmCod ;
      private string[] T000Y23_A348UsuCod ;
      private int[] T000Y24_A2041UsuVend ;
      private int[] T000Y25_A2040UsuTieCod ;
      private int[] T000Y26_A69AreCod ;
      private bool[] T000Y26_n69AreCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuarios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarios__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Y7;
        prmT000Y7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y5;
        prmT000Y5 = new Object[] {
        new ParDef("@UsuVend",GXType.Int32,6,0)
        };
        Object[] prmT000Y6;
        prmT000Y6 = new Object[] {
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT000Y4;
        prmT000Y4 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000Y8;
        prmT000Y8 = new Object[] {
        new ParDef("@UsuVend",GXType.Int32,6,0)
        };
        Object[] prmT000Y9;
        prmT000Y9 = new Object[] {
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT000Y10;
        prmT000Y10 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000Y11;
        prmT000Y11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y3;
        prmT000Y3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y12;
        prmT000Y12 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y13;
        prmT000Y13 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y2;
        prmT000Y2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y14;
        prmT000Y14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuPas",GXType.NChar,10,0) ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuSerie",GXType.NChar,4,0) ,
        new ParDef("@UsuAutOcom",GXType.Int16,1,0) ,
        new ParDef("@UsuAutPago",GXType.Int16,1,0) ,
        new ParDef("@UsuSts",GXType.Int16,1,0) ,
        new ParDef("@UsuSerie1",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie2",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie3",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie4",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie5",GXType.NChar,4,0) ,
        new ParDef("@UsuReqADM",GXType.Int16,1,0) ,
        new ParDef("@UsuAut1",GXType.Int16,1,0) ,
        new ParDef("@UsuAut2",GXType.Int16,1,0) ,
        new ParDef("@UsuOcMail",GXType.Int16,1,0) ,
        new ParDef("@UsuEMAIL",GXType.NVarChar,100,0) ,
        new ParDef("@UsuPedMail",GXType.Int16,1,0) ,
        new ParDef("@UsuSOrden",GXType.NChar,3,0) ,
        new ParDef("@UsuSRet",GXType.NChar,4,0) ,
        new ParDef("@UsuDep",GXType.NVarChar,100,0) ,
        new ParDef("@UsuVendAut",GXType.Int16,1,0) ,
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuVend",GXType.Int32,6,0) ,
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT000Y15;
        prmT000Y15 = new Object[] {
        new ParDef("@UsuPas",GXType.NChar,10,0) ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuSerie",GXType.NChar,4,0) ,
        new ParDef("@UsuAutOcom",GXType.Int16,1,0) ,
        new ParDef("@UsuAutPago",GXType.Int16,1,0) ,
        new ParDef("@UsuSts",GXType.Int16,1,0) ,
        new ParDef("@UsuSerie1",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie2",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie3",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie4",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie5",GXType.NChar,4,0) ,
        new ParDef("@UsuReqADM",GXType.Int16,1,0) ,
        new ParDef("@UsuAut1",GXType.Int16,1,0) ,
        new ParDef("@UsuAut2",GXType.Int16,1,0) ,
        new ParDef("@UsuOcMail",GXType.Int16,1,0) ,
        new ParDef("@UsuEMAIL",GXType.NVarChar,100,0) ,
        new ParDef("@UsuPedMail",GXType.Int16,1,0) ,
        new ParDef("@UsuSOrden",GXType.NChar,3,0) ,
        new ParDef("@UsuSRet",GXType.NChar,4,0) ,
        new ParDef("@UsuDep",GXType.NVarChar,100,0) ,
        new ParDef("@UsuVendAut",GXType.Int16,1,0) ,
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuVend",GXType.Int32,6,0) ,
        new ParDef("@UsuTieCod",GXType.Int32,6,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y16;
        prmT000Y16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y17;
        prmT000Y17 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y18;
        prmT000Y18 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y19;
        prmT000Y19 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y20;
        prmT000Y20 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y21;
        prmT000Y21 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y22;
        prmT000Y22 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Y23;
        prmT000Y23 = new Object[] {
        };
        Object[] prmT000Y24;
        prmT000Y24 = new Object[] {
        new ParDef("@UsuVend",GXType.Int32,6,0)
        };
        Object[] prmT000Y25;
        prmT000Y25 = new Object[] {
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT000Y26;
        prmT000Y26 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000Y2", "SELECT [UsuCod], [UsuPas], [UsuNom], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuSerie5], [UsuReqADM], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [UsuSRet], [UsuDep], [UsuVendAut], [AreCod], [UsuVend] AS UsuVend, [UsuTieCod] AS UsuTieCod FROM [SGUSUARIOS] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y3", "SELECT [UsuCod], [UsuPas], [UsuNom], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuSerie5], [UsuReqADM], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [UsuSRet], [UsuDep], [UsuVendAut], [AreCod], [UsuVend] AS UsuVend, [UsuTieCod] AS UsuTieCod FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y4", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y5", "SELECT [VenCod] AS UsuVend FROM [CVENDEDORES] WHERE [VenCod] = @UsuVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y6", "SELECT [TieCod] AS UsuTieCod FROM [SGTIENDAS] WHERE [TieCod] = @UsuTieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y7", "SELECT TM1.[UsuCod], TM1.[UsuPas], TM1.[UsuNom], TM1.[UsuSerie], TM1.[UsuAutOcom], TM1.[UsuAutPago], TM1.[UsuSts], TM1.[UsuSerie1], TM1.[UsuSerie2], TM1.[UsuSerie3], TM1.[UsuSerie4], TM1.[UsuSerie5], TM1.[UsuReqADM], TM1.[UsuAut1], TM1.[UsuAut2], TM1.[UsuOcMail], TM1.[UsuEMAIL], TM1.[UsuPedMail], TM1.[UsuSOrden], TM1.[UsuSRet], TM1.[UsuDep], TM1.[UsuVendAut], TM1.[AreCod], TM1.[UsuVend] AS UsuVend, TM1.[UsuTieCod] AS UsuTieCod FROM [SGUSUARIOS] TM1 WHERE TM1.[UsuCod] = @UsuCod ORDER BY TM1.[UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y8", "SELECT [VenCod] AS UsuVend FROM [CVENDEDORES] WHERE [VenCod] = @UsuVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y9", "SELECT [TieCod] AS UsuTieCod FROM [SGTIENDAS] WHERE [TieCod] = @UsuTieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y10", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y11", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y12", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] > @UsuCod) ORDER BY [UsuCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y13", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] < @UsuCod) ORDER BY [UsuCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y14", "INSERT INTO [SGUSUARIOS]([UsuCod], [UsuPas], [UsuNom], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuSerie5], [UsuReqADM], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [UsuSRet], [UsuDep], [UsuVendAut], [AreCod], [UsuVend], [UsuTieCod], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod], [UsuMosCBCod], [UsuMosConcepto]) VALUES(@UsuCod, @UsuPas, @UsuNom, @UsuSerie, @UsuAutOcom, @UsuAutPago, @UsuSts, @UsuSerie1, @UsuSerie2, @UsuSerie3, @UsuSerie4, @UsuSerie5, @UsuReqADM, @UsuAut1, @UsuAut2, @UsuOcMail, @UsuEMAIL, @UsuPedMail, @UsuSOrden, @UsuSRet, @UsuDep, @UsuVendAut, @AreCod, @UsuVend, @UsuTieCod, convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT000Y14)
           ,new CursorDef("T000Y15", "UPDATE [SGUSUARIOS] SET [UsuPas]=@UsuPas, [UsuNom]=@UsuNom, [UsuSerie]=@UsuSerie, [UsuAutOcom]=@UsuAutOcom, [UsuAutPago]=@UsuAutPago, [UsuSts]=@UsuSts, [UsuSerie1]=@UsuSerie1, [UsuSerie2]=@UsuSerie2, [UsuSerie3]=@UsuSerie3, [UsuSerie4]=@UsuSerie4, [UsuSerie5]=@UsuSerie5, [UsuReqADM]=@UsuReqADM, [UsuAut1]=@UsuAut1, [UsuAut2]=@UsuAut2, [UsuOcMail]=@UsuOcMail, [UsuEMAIL]=@UsuEMAIL, [UsuPedMail]=@UsuPedMail, [UsuSOrden]=@UsuSOrden, [UsuSRet]=@UsuSRet, [UsuDep]=@UsuDep, [UsuVendAut]=@UsuVendAut, [AreCod]=@AreCod, [UsuVend]=@UsuVend, [UsuTieCod]=@UsuTieCod  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT000Y15)
           ,new CursorDef("T000Y16", "DELETE FROM [SGUSUARIOS]  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT000Y16)
           ,new CursorDef("T000Y17", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionDetUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y18", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y19", "SELECT TOP 1 [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y20", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y21", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y22", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y23", "SELECT [UsuCod] FROM [SGUSUARIOS] ORDER BY [UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y24", "SELECT [VenCod] AS UsuVend FROM [CVENDEDORES] WHERE [VenCod] = @UsuVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y25", "SELECT [TieCod] AS UsuTieCod FROM [SGTIENDAS] WHERE [TieCod] = @UsuTieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y26", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 4);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((int[]) buf[25])[0] = rslt.getInt(25);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 4);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((int[]) buf[25])[0] = rslt.getInt(25);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 4);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((int[]) buf[25])[0] = rslt.getInt(25);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
