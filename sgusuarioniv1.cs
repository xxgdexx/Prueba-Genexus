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
   public class sgusuarioniv1 : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A348UsuCod = GetPar( "UsuCod");
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A348UsuCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A342SGMenuPrograma = GetPar( "SGMenuPrograma");
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A342SGMenuPrograma, A343SGMenuNiv1ID) ;
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
            Form.Meta.addItem("description", "SGUSUARIONIV1", 0) ;
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

      public sgusuarioniv1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuarioniv1( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIONIV1", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIONIV1.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIONIV1.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuPrograma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuPrograma_Internalname, "SGMenu Programa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuPrograma_Internalname, A342SGMenuPrograma, StringUtil.RTrim( context.localUtil.Format( A342SGMenuPrograma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuPrograma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuPrograma_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv1ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv1ID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv1ID_Internalname, A343SGMenuNiv1ID, StringUtil.RTrim( context.localUtil.Format( A343SGMenuNiv1ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv1ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv1ID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuModuloSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuModuloSts_Internalname, "Modulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuModuloSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2015UsuModuloSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtUsuModuloSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2015UsuModuloSts), "9") : context.localUtil.Format( (decimal)(A2015UsuModuloSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuModuloSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuModuloSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV1.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV1.htm");
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
            Z342SGMenuPrograma = cgiGet( "Z342SGMenuPrograma");
            Z343SGMenuNiv1ID = cgiGet( "Z343SGMenuNiv1ID");
            Z2015UsuModuloSts = (short)(context.localUtil.CToN( cgiGet( "Z2015UsuModuloSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = cgiGet( edtSGMenuPrograma_Internalname);
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = cgiGet( edtSGMenuNiv1ID_Internalname);
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuModuloSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuModuloSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUMODULOSTS");
               AnyError = 1;
               GX_FocusControl = edtUsuModuloSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2015UsuModuloSts = 0;
               AssignAttri("", false, "A2015UsuModuloSts", StringUtil.Str( (decimal)(A2015UsuModuloSts), 1, 0));
            }
            else
            {
               A2015UsuModuloSts = (short)(context.localUtil.CToN( cgiGet( edtUsuModuloSts_Internalname), ".", ","));
               AssignAttri("", false, "A2015UsuModuloSts", StringUtil.Str( (decimal)(A2015UsuModuloSts), 1, 0));
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
               A342SGMenuPrograma = GetPar( "SGMenuPrograma");
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
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
               InitAll0U29( ) ;
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
         DisableAttributes0U29( ) ;
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

      protected void ResetCaption0U0( )
      {
      }

      protected void ZM0U29( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2015UsuModuloSts = T000U3_A2015UsuModuloSts[0];
            }
            else
            {
               Z2015UsuModuloSts = A2015UsuModuloSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2015UsuModuloSts = A2015UsuModuloSts;
            Z348UsuCod = A348UsuCod;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
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

      protected void Load0U29( )
      {
         /* Using cursor T000U6 */
         pr_default.execute(4, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound29 = 1;
            A2015UsuModuloSts = T000U6_A2015UsuModuloSts[0];
            AssignAttri("", false, "A2015UsuModuloSts", StringUtil.Str( (decimal)(A2015UsuModuloSts), 1, 0));
            ZM0U29( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0U29( ) ;
      }

      protected void OnLoadActions0U29( )
      {
      }

      protected void CheckExtendedTable0U29( )
      {
         nIsDirty_29 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000U4 */
         pr_default.execute(2, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000U5 */
         pr_default.execute(3, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0U29( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A348UsuCod )
      {
         /* Using cursor T000U7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A342SGMenuPrograma ,
                               string A343SGMenuNiv1ID )
      {
         /* Using cursor T000U8 */
         pr_default.execute(6, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
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

      protected void GetKey0U29( )
      {
         /* Using cursor T000U9 */
         pr_default.execute(7, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000U3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U29( 1) ;
            RcdFound29 = 1;
            A2015UsuModuloSts = T000U3_A2015UsuModuloSts[0];
            AssignAttri("", false, "A2015UsuModuloSts", StringUtil.Str( (decimal)(A2015UsuModuloSts), 1, 0));
            A348UsuCod = T000U3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000U3_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000U3_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            Z348UsuCod = A348UsuCod;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0U29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0U29( ) ;
            }
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0U29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U29( ) ;
         if ( RcdFound29 == 0 )
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
         RcdFound29 = 0;
         /* Using cursor T000U10 */
         pr_default.execute(8, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000U10_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000U10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U10_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000U10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000U10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000U10_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000U10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U10_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000U10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000U10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) ) )
            {
               A348UsuCod = T000U10_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A342SGMenuPrograma = T000U10_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000U10_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               RcdFound29 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound29 = 0;
         /* Using cursor T000U11 */
         pr_default.execute(9, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000U11_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000U11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U11_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000U11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000U11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000U11_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000U11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U11_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000U11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000U11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000U11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) ) )
            {
               A348UsuCod = T000U11_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A342SGMenuPrograma = T000U11_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000U11_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               RcdFound29 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0U29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0U29( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  A342SGMenuPrograma = Z342SGMenuPrograma;
                  AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
                  A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
                  AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
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
                  Update0U29( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0U29( ) ;
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
                     Insert0U29( ) ;
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
         if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = Z342SGMenuPrograma;
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuModuloSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0U29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuModuloSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0U29( ) ;
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuModuloSts_Internalname;
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuModuloSts_Internalname;
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
         ScanStart0U29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound29 != 0 )
            {
               ScanNext0U29( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuModuloSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0U29( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0U29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIONIV1"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2015UsuModuloSts != T000U2_A2015UsuModuloSts[0] ) )
            {
               if ( Z2015UsuModuloSts != T000U2_A2015UsuModuloSts[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv1:[seudo value changed for attri]"+"UsuModuloSts");
                  GXUtil.WriteLogRaw("Old: ",Z2015UsuModuloSts);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A2015UsuModuloSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIONIV1"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U29( )
      {
         BeforeValidate0U29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U29( 0) ;
            CheckOptimisticConcurrency0U29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U12 */
                     pr_default.execute(10, new Object[] {A2015UsuModuloSts, A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV1");
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
                           ResetCaption0U0( ) ;
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
               Load0U29( ) ;
            }
            EndLevel0U29( ) ;
         }
         CloseExtendedTableCursors0U29( ) ;
      }

      protected void Update0U29( )
      {
         BeforeValidate0U29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U13 */
                     pr_default.execute(11, new Object[] {A2015UsuModuloSts, A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV1");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIONIV1"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0U0( ) ;
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
            EndLevel0U29( ) ;
         }
         CloseExtendedTableCursors0U29( ) ;
      }

      protected void DeferredUpdate0U29( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0U29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U29( ) ;
            AfterConfirm0U29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000U14 */
                  pr_default.execute(12, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV1");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound29 == 0 )
                        {
                           InitAll0U29( ) ;
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
                        ResetCaption0U0( ) ;
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0U29( ) ;
         Gx_mode = sMode29;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U29( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000U15 */
            pr_default.execute(13, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV2"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0U29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U29( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgusuarioniv1",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgusuarioniv1",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0U29( )
      {
         /* Using cursor T000U16 */
         pr_default.execute(14);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound29 = 1;
            A348UsuCod = T000U16_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000U16_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000U16_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U29( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound29 = 1;
            A348UsuCod = T000U16_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000U16_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000U16_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         }
      }

      protected void ScanEnd0U29( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0U29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U29( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtSGMenuPrograma_Enabled = 0;
         AssignProp("", false, edtSGMenuPrograma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuPrograma_Enabled), 5, 0), true);
         edtSGMenuNiv1ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv1ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1ID_Enabled), 5, 0), true);
         edtUsuModuloSts_Enabled = 0;
         AssignProp("", false, edtUsuModuloSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuModuloSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0U29( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0U0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442665", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuarioniv1.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z2015UsuModuloSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2015UsuModuloSts), 1, 0, ".", "")));
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
         return formatLink("sgusuarioniv1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIONIV1" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIONIV1" ;
      }

      protected void InitializeNonKey0U29( )
      {
         A2015UsuModuloSts = 0;
         AssignAttri("", false, "A2015UsuModuloSts", StringUtil.Str( (decimal)(A2015UsuModuloSts), 1, 0));
         Z2015UsuModuloSts = 0;
      }

      protected void InitAll0U29( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         A342SGMenuPrograma = "";
         AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
         A343SGMenuNiv1ID = "";
         AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         InitializeNonKey0U29( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811442670", true, true);
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
         context.AddJavascriptSource("sgusuarioniv1.js", "?202281811442670", false, true);
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
         edtSGMenuPrograma_Internalname = "SGMENUPROGRAMA";
         edtSGMenuNiv1ID_Internalname = "SGMENUNIV1ID";
         edtUsuModuloSts_Internalname = "USUMODULOSTS";
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
         Form.Caption = "SGUSUARIONIV1";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUsuModuloSts_Jsonclick = "";
         edtUsuModuloSts_Enabled = 1;
         edtSGMenuNiv1ID_Jsonclick = "";
         edtSGMenuNiv1ID_Enabled = 1;
         edtSGMenuPrograma_Jsonclick = "";
         edtSGMenuPrograma_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000U17 */
         pr_default.execute(15, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         /* Using cursor T000U18 */
         pr_default.execute(16, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         GX_FocusControl = edtUsuModuloSts_Internalname;
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
         /* Using cursor T000U17 */
         pr_default.execute(15, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sgmenuniv1id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000U18 */
         pr_default.execute(16, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2015UsuModuloSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2015UsuModuloSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z2015UsuModuloSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2015UsuModuloSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''}]");
         setEventMetadata("VALID_USUCOD",",oparms:[]}");
         setEventMetadata("VALID_SGMENUPROGRAMA","{handler:'Valid_Sgmenuprograma',iparms:[]");
         setEventMetadata("VALID_SGMENUPROGRAMA",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV1ID","{handler:'Valid_Sgmenuniv1id',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGMENUNIV1ID",",oparms:[{av:'A2015UsuModuloSts',fld:'USUMODULOSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z342SGMenuPrograma'},{av:'Z343SGMenuNiv1ID'},{av:'Z2015UsuModuloSts'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         Z342SGMenuPrograma = "";
         Z343SGMenuNiv1ID = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A348UsuCod = "";
         A342SGMenuPrograma = "";
         A343SGMenuNiv1ID = "";
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
         T000U6_A2015UsuModuloSts = new short[1] ;
         T000U6_A348UsuCod = new string[] {""} ;
         T000U6_A342SGMenuPrograma = new string[] {""} ;
         T000U6_A343SGMenuNiv1ID = new string[] {""} ;
         T000U4_A348UsuCod = new string[] {""} ;
         T000U5_A342SGMenuPrograma = new string[] {""} ;
         T000U7_A348UsuCod = new string[] {""} ;
         T000U8_A342SGMenuPrograma = new string[] {""} ;
         T000U9_A348UsuCod = new string[] {""} ;
         T000U9_A342SGMenuPrograma = new string[] {""} ;
         T000U9_A343SGMenuNiv1ID = new string[] {""} ;
         T000U3_A2015UsuModuloSts = new short[1] ;
         T000U3_A348UsuCod = new string[] {""} ;
         T000U3_A342SGMenuPrograma = new string[] {""} ;
         T000U3_A343SGMenuNiv1ID = new string[] {""} ;
         sMode29 = "";
         T000U10_A348UsuCod = new string[] {""} ;
         T000U10_A342SGMenuPrograma = new string[] {""} ;
         T000U10_A343SGMenuNiv1ID = new string[] {""} ;
         T000U11_A348UsuCod = new string[] {""} ;
         T000U11_A342SGMenuPrograma = new string[] {""} ;
         T000U11_A343SGMenuNiv1ID = new string[] {""} ;
         T000U2_A2015UsuModuloSts = new short[1] ;
         T000U2_A348UsuCod = new string[] {""} ;
         T000U2_A342SGMenuPrograma = new string[] {""} ;
         T000U2_A343SGMenuNiv1ID = new string[] {""} ;
         T000U15_A348UsuCod = new string[] {""} ;
         T000U15_A342SGMenuPrograma = new string[] {""} ;
         T000U15_A343SGMenuNiv1ID = new string[] {""} ;
         T000U15_A344SGMenuNiv2ID = new string[] {""} ;
         T000U16_A348UsuCod = new string[] {""} ;
         T000U16_A342SGMenuPrograma = new string[] {""} ;
         T000U16_A343SGMenuNiv1ID = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000U17_A348UsuCod = new string[] {""} ;
         T000U18_A342SGMenuPrograma = new string[] {""} ;
         ZZ348UsuCod = "";
         ZZ342SGMenuPrograma = "";
         ZZ343SGMenuNiv1ID = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioniv1__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioniv1__default(),
            new Object[][] {
                new Object[] {
               T000U2_A2015UsuModuloSts, T000U2_A348UsuCod, T000U2_A342SGMenuPrograma, T000U2_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000U3_A2015UsuModuloSts, T000U3_A348UsuCod, T000U3_A342SGMenuPrograma, T000U3_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000U4_A348UsuCod
               }
               , new Object[] {
               T000U5_A342SGMenuPrograma
               }
               , new Object[] {
               T000U6_A2015UsuModuloSts, T000U6_A348UsuCod, T000U6_A342SGMenuPrograma, T000U6_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000U7_A348UsuCod
               }
               , new Object[] {
               T000U8_A342SGMenuPrograma
               }
               , new Object[] {
               T000U9_A348UsuCod, T000U9_A342SGMenuPrograma, T000U9_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000U10_A348UsuCod, T000U10_A342SGMenuPrograma, T000U10_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000U11_A348UsuCod, T000U11_A342SGMenuPrograma, T000U11_A343SGMenuNiv1ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U15_A348UsuCod, T000U15_A342SGMenuPrograma, T000U15_A343SGMenuNiv1ID, T000U15_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000U16_A348UsuCod, T000U16_A342SGMenuPrograma, T000U16_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000U17_A348UsuCod
               }
               , new Object[] {
               T000U18_A342SGMenuPrograma
               }
            }
         );
      }

      private short Z2015UsuModuloSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2015UsuModuloSts ;
      private short GX_JID ;
      private short RcdFound29 ;
      private short nIsDirty_29 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2015UsuModuloSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtSGMenuPrograma_Enabled ;
      private int edtSGMenuNiv1ID_Enabled ;
      private int edtUsuModuloSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z348UsuCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A348UsuCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUsuCod_Internalname ;
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
      private string edtUsuCod_Jsonclick ;
      private string edtSGMenuPrograma_Internalname ;
      private string edtSGMenuPrograma_Jsonclick ;
      private string edtSGMenuNiv1ID_Internalname ;
      private string edtSGMenuNiv1ID_Jsonclick ;
      private string edtUsuModuloSts_Internalname ;
      private string edtUsuModuloSts_Jsonclick ;
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
      private string sMode29 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z342SGMenuPrograma ;
      private string Z343SGMenuNiv1ID ;
      private string A342SGMenuPrograma ;
      private string A343SGMenuNiv1ID ;
      private string ZZ342SGMenuPrograma ;
      private string ZZ343SGMenuNiv1ID ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000U6_A2015UsuModuloSts ;
      private string[] T000U6_A348UsuCod ;
      private string[] T000U6_A342SGMenuPrograma ;
      private string[] T000U6_A343SGMenuNiv1ID ;
      private string[] T000U4_A348UsuCod ;
      private string[] T000U5_A342SGMenuPrograma ;
      private string[] T000U7_A348UsuCod ;
      private string[] T000U8_A342SGMenuPrograma ;
      private string[] T000U9_A348UsuCod ;
      private string[] T000U9_A342SGMenuPrograma ;
      private string[] T000U9_A343SGMenuNiv1ID ;
      private short[] T000U3_A2015UsuModuloSts ;
      private string[] T000U3_A348UsuCod ;
      private string[] T000U3_A342SGMenuPrograma ;
      private string[] T000U3_A343SGMenuNiv1ID ;
      private string[] T000U10_A348UsuCod ;
      private string[] T000U10_A342SGMenuPrograma ;
      private string[] T000U10_A343SGMenuNiv1ID ;
      private string[] T000U11_A348UsuCod ;
      private string[] T000U11_A342SGMenuPrograma ;
      private string[] T000U11_A343SGMenuNiv1ID ;
      private short[] T000U2_A2015UsuModuloSts ;
      private string[] T000U2_A348UsuCod ;
      private string[] T000U2_A342SGMenuPrograma ;
      private string[] T000U2_A343SGMenuNiv1ID ;
      private string[] T000U15_A348UsuCod ;
      private string[] T000U15_A342SGMenuPrograma ;
      private string[] T000U15_A343SGMenuNiv1ID ;
      private string[] T000U15_A344SGMenuNiv2ID ;
      private string[] T000U16_A348UsuCod ;
      private string[] T000U16_A342SGMenuPrograma ;
      private string[] T000U16_A343SGMenuNiv1ID ;
      private string[] T000U17_A348UsuCod ;
      private string[] T000U18_A342SGMenuPrograma ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuarioniv1__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarioniv1__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000U6;
        prmT000U6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U4;
        prmT000U4 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000U5;
        prmT000U5 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U7;
        prmT000U7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000U8;
        prmT000U8 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U9;
        prmT000U9 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U3;
        prmT000U3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U10;
        prmT000U10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U11;
        prmT000U11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U2;
        prmT000U2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U12;
        prmT000U12 = new Object[] {
        new ParDef("@UsuModuloSts",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U13;
        prmT000U13 = new Object[] {
        new ParDef("@UsuModuloSts",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U14;
        prmT000U14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U15;
        prmT000U15 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000U16;
        prmT000U16 = new Object[] {
        };
        Object[] prmT000U17;
        prmT000U17 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000U18;
        prmT000U18 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000U2", "SELECT [UsuModuloSts], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U3", "SELECT [UsuModuloSts], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U4", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U5", "SELECT [SGMenuPrograma] FROM [SGMENUNIV1] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U6", "SELECT TM1.[UsuModuloSts], TM1.[UsuCod], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID] FROM [SGUSUARIONIV1] TM1 WHERE TM1.[UsuCod] = @UsuCod and TM1.[SGMenuPrograma] = @SGMenuPrograma and TM1.[SGMenuNiv1ID] = @SGMenuNiv1ID ORDER BY TM1.[UsuCod], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U7", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U8", "SELECT [SGMenuPrograma] FROM [SGMENUNIV1] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U9", "SELECT [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U10", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE ( [UsuCod] > @UsuCod or [UsuCod] = @UsuCod and [SGMenuPrograma] > @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv1ID] > @SGMenuNiv1ID) ORDER BY [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U11", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE ( [UsuCod] < @UsuCod or [UsuCod] = @UsuCod and [SGMenuPrograma] < @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv1ID] < @SGMenuNiv1ID) ORDER BY [UsuCod] DESC, [SGMenuPrograma] DESC, [SGMenuNiv1ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U12", "INSERT INTO [SGUSUARIONIV1]([UsuModuloSts], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID]) VALUES(@UsuModuloSts, @UsuCod, @SGMenuPrograma, @SGMenuNiv1ID)", GxErrorMask.GX_NOMASK,prmT000U12)
           ,new CursorDef("T000U13", "UPDATE [SGUSUARIONIV1] SET [UsuModuloSts]=@UsuModuloSts  WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID", GxErrorMask.GX_NOMASK,prmT000U13)
           ,new CursorDef("T000U14", "DELETE FROM [SGUSUARIONIV1]  WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID", GxErrorMask.GX_NOMASK,prmT000U14)
           ,new CursorDef("T000U15", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U16", "SELECT [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] ORDER BY [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U17", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U18", "SELECT [SGMenuPrograma] FROM [SGMENUNIV1] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U18,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
