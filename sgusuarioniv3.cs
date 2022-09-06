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
   public class sgusuarioniv3 : GXDataArea
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
            A342SGMenuPrograma = GetPar( "SGMenuPrograma");
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = GetPar( "SGMenuNiv2ID");
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A342SGMenuPrograma = GetPar( "SGMenuPrograma");
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = GetPar( "SGMenuNiv2ID");
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = GetPar( "SGMenuNiv3ID");
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID) ;
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
            Form.Meta.addItem("description", "SGUSUARIONIV3", 0) ;
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

      public sgusuarioniv3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuarioniv3( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIONIV3", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIONIV3.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIONIV3.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV3.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSGMenuPrograma_Internalname, A342SGMenuPrograma, StringUtil.RTrim( context.localUtil.Format( A342SGMenuPrograma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuPrograma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuPrograma_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV3.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv1ID_Internalname, A343SGMenuNiv1ID, StringUtil.RTrim( context.localUtil.Format( A343SGMenuNiv1ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv1ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv1ID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv2ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv2ID_Internalname, "ID Nivel 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv2ID_Internalname, A344SGMenuNiv2ID, StringUtil.RTrim( context.localUtil.Format( A344SGMenuNiv2ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv2ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv2ID_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv3ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv3ID_Internalname, "ID Nivel 3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv3ID_Internalname, A345SGMenuNiv3ID, StringUtil.RTrim( context.localUtil.Format( A345SGMenuNiv3ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv3ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv3ID_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN2New_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN2New_Internalname, "Nuevo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN2New_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1862SGUsuN2New), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN2New_Enabled!=0) ? context.localUtil.Format( (decimal)(A1862SGUsuN2New), "9") : context.localUtil.Format( (decimal)(A1862SGUsuN2New), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN2New_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN2New_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN2Upd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN2Upd_Internalname, "Modificar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN2Upd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1864SGUsuN2Upd), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN2Upd_Enabled!=0) ? context.localUtil.Format( (decimal)(A1864SGUsuN2Upd), "9") : context.localUtil.Format( (decimal)(A1864SGUsuN2Upd), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN2Upd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN2Upd_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN2Del_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN2Del_Internalname, "Borrar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN2Del_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1860SGUsuN2Del), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN2Del_Enabled!=0) ? context.localUtil.Format( (decimal)(A1860SGUsuN2Del), "9") : context.localUtil.Format( (decimal)(A1860SGUsuN2Del), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN2Del_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN2Del_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN2DSP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN2DSP_Internalname, "Visualizar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN2DSP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1861SGUsuN2DSP), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN2DSP_Enabled!=0) ? context.localUtil.Format( (decimal)(A1861SGUsuN2DSP), "9") : context.localUtil.Format( (decimal)(A1861SGUsuN2DSP), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN2DSP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN2DSP_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN2Tot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN2Tot_Internalname, "Todos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN2Tot_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1863SGUsuN2Tot), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN2Tot_Enabled!=0) ? context.localUtil.Format( (decimal)(A1863SGUsuN2Tot), "9") : context.localUtil.Format( (decimal)(A1863SGUsuN2Tot), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN2Tot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN2Tot_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV3.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV3.htm");
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
            Z344SGMenuNiv2ID = cgiGet( "Z344SGMenuNiv2ID");
            Z345SGMenuNiv3ID = cgiGet( "Z345SGMenuNiv3ID");
            Z1862SGUsuN2New = (short)(context.localUtil.CToN( cgiGet( "Z1862SGUsuN2New"), ".", ","));
            Z1864SGUsuN2Upd = (short)(context.localUtil.CToN( cgiGet( "Z1864SGUsuN2Upd"), ".", ","));
            Z1860SGUsuN2Del = (short)(context.localUtil.CToN( cgiGet( "Z1860SGUsuN2Del"), ".", ","));
            Z1861SGUsuN2DSP = (short)(context.localUtil.CToN( cgiGet( "Z1861SGUsuN2DSP"), ".", ","));
            Z1863SGUsuN2Tot = (short)(context.localUtil.CToN( cgiGet( "Z1863SGUsuN2Tot"), ".", ","));
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
            A344SGMenuNiv2ID = cgiGet( edtSGMenuNiv2ID_Internalname);
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = cgiGet( edtSGMenuNiv3ID_Internalname);
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2New_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2New_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN2NEW");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN2New_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1862SGUsuN2New = 0;
               AssignAttri("", false, "A1862SGUsuN2New", StringUtil.Str( (decimal)(A1862SGUsuN2New), 1, 0));
            }
            else
            {
               A1862SGUsuN2New = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN2New_Internalname), ".", ","));
               AssignAttri("", false, "A1862SGUsuN2New", StringUtil.Str( (decimal)(A1862SGUsuN2New), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2Upd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2Upd_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN2UPD");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN2Upd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1864SGUsuN2Upd = 0;
               AssignAttri("", false, "A1864SGUsuN2Upd", StringUtil.Str( (decimal)(A1864SGUsuN2Upd), 1, 0));
            }
            else
            {
               A1864SGUsuN2Upd = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN2Upd_Internalname), ".", ","));
               AssignAttri("", false, "A1864SGUsuN2Upd", StringUtil.Str( (decimal)(A1864SGUsuN2Upd), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2Del_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2Del_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN2DEL");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN2Del_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1860SGUsuN2Del = 0;
               AssignAttri("", false, "A1860SGUsuN2Del", StringUtil.Str( (decimal)(A1860SGUsuN2Del), 1, 0));
            }
            else
            {
               A1860SGUsuN2Del = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN2Del_Internalname), ".", ","));
               AssignAttri("", false, "A1860SGUsuN2Del", StringUtil.Str( (decimal)(A1860SGUsuN2Del), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2DSP_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2DSP_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN2DSP");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN2DSP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1861SGUsuN2DSP = 0;
               AssignAttri("", false, "A1861SGUsuN2DSP", StringUtil.Str( (decimal)(A1861SGUsuN2DSP), 1, 0));
            }
            else
            {
               A1861SGUsuN2DSP = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN2DSP_Internalname), ".", ","));
               AssignAttri("", false, "A1861SGUsuN2DSP", StringUtil.Str( (decimal)(A1861SGUsuN2DSP), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2Tot_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN2Tot_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN2TOT");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN2Tot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1863SGUsuN2Tot = 0;
               AssignAttri("", false, "A1863SGUsuN2Tot", StringUtil.Str( (decimal)(A1863SGUsuN2Tot), 1, 0));
            }
            else
            {
               A1863SGUsuN2Tot = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN2Tot_Internalname), ".", ","));
               AssignAttri("", false, "A1863SGUsuN2Tot", StringUtil.Str( (decimal)(A1863SGUsuN2Tot), 1, 0));
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
               A344SGMenuNiv2ID = GetPar( "SGMenuNiv2ID");
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               A345SGMenuNiv3ID = GetPar( "SGMenuNiv3ID");
               AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
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
               InitAll0W31( ) ;
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
         DisableAttributes0W31( ) ;
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

      protected void ResetCaption0W0( )
      {
      }

      protected void ZM0W31( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1862SGUsuN2New = T000W3_A1862SGUsuN2New[0];
               Z1864SGUsuN2Upd = T000W3_A1864SGUsuN2Upd[0];
               Z1860SGUsuN2Del = T000W3_A1860SGUsuN2Del[0];
               Z1861SGUsuN2DSP = T000W3_A1861SGUsuN2DSP[0];
               Z1863SGUsuN2Tot = T000W3_A1863SGUsuN2Tot[0];
            }
            else
            {
               Z1862SGUsuN2New = A1862SGUsuN2New;
               Z1864SGUsuN2Upd = A1864SGUsuN2Upd;
               Z1860SGUsuN2Del = A1860SGUsuN2Del;
               Z1861SGUsuN2DSP = A1861SGUsuN2DSP;
               Z1863SGUsuN2Tot = A1863SGUsuN2Tot;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1862SGUsuN2New = A1862SGUsuN2New;
            Z1864SGUsuN2Upd = A1864SGUsuN2Upd;
            Z1860SGUsuN2Del = A1860SGUsuN2Del;
            Z1861SGUsuN2DSP = A1861SGUsuN2DSP;
            Z1863SGUsuN2Tot = A1863SGUsuN2Tot;
            Z348UsuCod = A348UsuCod;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z344SGMenuNiv2ID = A344SGMenuNiv2ID;
            Z345SGMenuNiv3ID = A345SGMenuNiv3ID;
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

      protected void Load0W31( )
      {
         /* Using cursor T000W6 */
         pr_default.execute(4, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound31 = 1;
            A1862SGUsuN2New = T000W6_A1862SGUsuN2New[0];
            AssignAttri("", false, "A1862SGUsuN2New", StringUtil.Str( (decimal)(A1862SGUsuN2New), 1, 0));
            A1864SGUsuN2Upd = T000W6_A1864SGUsuN2Upd[0];
            AssignAttri("", false, "A1864SGUsuN2Upd", StringUtil.Str( (decimal)(A1864SGUsuN2Upd), 1, 0));
            A1860SGUsuN2Del = T000W6_A1860SGUsuN2Del[0];
            AssignAttri("", false, "A1860SGUsuN2Del", StringUtil.Str( (decimal)(A1860SGUsuN2Del), 1, 0));
            A1861SGUsuN2DSP = T000W6_A1861SGUsuN2DSP[0];
            AssignAttri("", false, "A1861SGUsuN2DSP", StringUtil.Str( (decimal)(A1861SGUsuN2DSP), 1, 0));
            A1863SGUsuN2Tot = T000W6_A1863SGUsuN2Tot[0];
            AssignAttri("", false, "A1863SGUsuN2Tot", StringUtil.Str( (decimal)(A1863SGUsuN2Tot), 1, 0));
            ZM0W31( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0W31( ) ;
      }

      protected void OnLoadActions0W31( )
      {
      }

      protected void CheckExtendedTable0W31( )
      {
         nIsDirty_31 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000W4 */
         pr_default.execute(2, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 3'.", "ForeignKeyNotFound", 1, "SGMENUNIV3ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0W31( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A348UsuCod ,
                               string A342SGMenuPrograma ,
                               string A343SGMenuNiv1ID ,
                               string A344SGMenuNiv2ID )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
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
                               string A343SGMenuNiv1ID ,
                               string A344SGMenuNiv2ID ,
                               string A345SGMenuNiv3ID )
      {
         /* Using cursor T000W8 */
         pr_default.execute(6, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 3'.", "ForeignKeyNotFound", 1, "SGMENUNIV3ID");
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

      protected void GetKey0W31( )
      {
         /* Using cursor T000W9 */
         pr_default.execute(7, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W31( 1) ;
            RcdFound31 = 1;
            A1862SGUsuN2New = T000W3_A1862SGUsuN2New[0];
            AssignAttri("", false, "A1862SGUsuN2New", StringUtil.Str( (decimal)(A1862SGUsuN2New), 1, 0));
            A1864SGUsuN2Upd = T000W3_A1864SGUsuN2Upd[0];
            AssignAttri("", false, "A1864SGUsuN2Upd", StringUtil.Str( (decimal)(A1864SGUsuN2Upd), 1, 0));
            A1860SGUsuN2Del = T000W3_A1860SGUsuN2Del[0];
            AssignAttri("", false, "A1860SGUsuN2Del", StringUtil.Str( (decimal)(A1860SGUsuN2Del), 1, 0));
            A1861SGUsuN2DSP = T000W3_A1861SGUsuN2DSP[0];
            AssignAttri("", false, "A1861SGUsuN2DSP", StringUtil.Str( (decimal)(A1861SGUsuN2DSP), 1, 0));
            A1863SGUsuN2Tot = T000W3_A1863SGUsuN2Tot[0];
            AssignAttri("", false, "A1863SGUsuN2Tot", StringUtil.Str( (decimal)(A1863SGUsuN2Tot), 1, 0));
            A348UsuCod = T000W3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000W3_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000W3_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000W3_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = T000W3_A345SGMenuNiv3ID[0];
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
            Z348UsuCod = A348UsuCod;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z344SGMenuNiv2ID = A344SGMenuNiv2ID;
            Z345SGMenuNiv3ID = A345SGMenuNiv3ID;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0W31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0W31( ) ;
            }
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0W31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W31( ) ;
         if ( RcdFound31 == 0 )
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
         RcdFound31 = 0;
         /* Using cursor T000W10 */
         pr_default.execute(8, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) || ( StringUtil.StrCmp(T000W10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) < 0 ) || ( StringUtil.StrCmp(T000W10_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000W10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) || ( StringUtil.StrCmp(T000W10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) > 0 ) || ( StringUtil.StrCmp(T000W10_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000W10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W10_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) > 0 ) ) )
            {
               A348UsuCod = T000W10_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A342SGMenuPrograma = T000W10_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000W10_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = T000W10_A344SGMenuNiv2ID[0];
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               A345SGMenuNiv3ID = T000W10_A345SGMenuNiv3ID[0];
               AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
               RcdFound31 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound31 = 0;
         /* Using cursor T000W11 */
         pr_default.execute(9, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) || ( StringUtil.StrCmp(T000W11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) > 0 ) || ( StringUtil.StrCmp(T000W11_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000W11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) || ( StringUtil.StrCmp(T000W11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) < 0 ) || ( StringUtil.StrCmp(T000W11_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000W11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000W11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000W11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000W11_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) < 0 ) ) )
            {
               A348UsuCod = T000W11_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A342SGMenuPrograma = T000W11_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000W11_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = T000W11_A344SGMenuNiv2ID[0];
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               A345SGMenuNiv3ID = T000W11_A345SGMenuNiv3ID[0];
               AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
               RcdFound31 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0W31( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) || ( StringUtil.StrCmp(A345SGMenuNiv3ID, Z345SGMenuNiv3ID) != 0 ) )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  A342SGMenuPrograma = Z342SGMenuPrograma;
                  AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
                  A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
                  AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
                  A344SGMenuNiv2ID = Z344SGMenuNiv2ID;
                  AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
                  A345SGMenuNiv3ID = Z345SGMenuNiv3ID;
                  AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
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
                  Update0W31( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) || ( StringUtil.StrCmp(A345SGMenuNiv3ID, Z345SGMenuNiv3ID) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0W31( ) ;
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
                     Insert0W31( ) ;
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
         if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) || ( StringUtil.StrCmp(A345SGMenuNiv3ID, Z345SGMenuNiv3ID) != 0 ) )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = Z342SGMenuPrograma;
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = Z344SGMenuNiv2ID;
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = Z345SGMenuNiv3ID;
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGUsuN2New_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0W31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN2New_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0W31( ) ;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN2New_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN2New_Internalname;
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
         ScanStart0W31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound31 != 0 )
            {
               ScanNext0W31( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN2New_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0W31( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0W31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIONIV3"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1862SGUsuN2New != T000W2_A1862SGUsuN2New[0] ) || ( Z1864SGUsuN2Upd != T000W2_A1864SGUsuN2Upd[0] ) || ( Z1860SGUsuN2Del != T000W2_A1860SGUsuN2Del[0] ) || ( Z1861SGUsuN2DSP != T000W2_A1861SGUsuN2DSP[0] ) || ( Z1863SGUsuN2Tot != T000W2_A1863SGUsuN2Tot[0] ) )
            {
               if ( Z1862SGUsuN2New != T000W2_A1862SGUsuN2New[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv3:[seudo value changed for attri]"+"SGUsuN2New");
                  GXUtil.WriteLogRaw("Old: ",Z1862SGUsuN2New);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A1862SGUsuN2New[0]);
               }
               if ( Z1864SGUsuN2Upd != T000W2_A1864SGUsuN2Upd[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv3:[seudo value changed for attri]"+"SGUsuN2Upd");
                  GXUtil.WriteLogRaw("Old: ",Z1864SGUsuN2Upd);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A1864SGUsuN2Upd[0]);
               }
               if ( Z1860SGUsuN2Del != T000W2_A1860SGUsuN2Del[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv3:[seudo value changed for attri]"+"SGUsuN2Del");
                  GXUtil.WriteLogRaw("Old: ",Z1860SGUsuN2Del);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A1860SGUsuN2Del[0]);
               }
               if ( Z1861SGUsuN2DSP != T000W2_A1861SGUsuN2DSP[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv3:[seudo value changed for attri]"+"SGUsuN2DSP");
                  GXUtil.WriteLogRaw("Old: ",Z1861SGUsuN2DSP);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A1861SGUsuN2DSP[0]);
               }
               if ( Z1863SGUsuN2Tot != T000W2_A1863SGUsuN2Tot[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv3:[seudo value changed for attri]"+"SGUsuN2Tot");
                  GXUtil.WriteLogRaw("Old: ",Z1863SGUsuN2Tot);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A1863SGUsuN2Tot[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIONIV3"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W31( )
      {
         BeforeValidate0W31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W31( 0) ;
            CheckOptimisticConcurrency0W31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W12 */
                     pr_default.execute(10, new Object[] {A1862SGUsuN2New, A1864SGUsuN2Upd, A1860SGUsuN2Del, A1861SGUsuN2DSP, A1863SGUsuN2Tot, A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV3");
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
                           ResetCaption0W0( ) ;
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
               Load0W31( ) ;
            }
            EndLevel0W31( ) ;
         }
         CloseExtendedTableCursors0W31( ) ;
      }

      protected void Update0W31( )
      {
         BeforeValidate0W31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W13 */
                     pr_default.execute(11, new Object[] {A1862SGUsuN2New, A1864SGUsuN2Upd, A1860SGUsuN2Del, A1861SGUsuN2DSP, A1863SGUsuN2Tot, A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV3");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIONIV3"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W31( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0W0( ) ;
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
            EndLevel0W31( ) ;
         }
         CloseExtendedTableCursors0W31( ) ;
      }

      protected void DeferredUpdate0W31( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0W31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W31( ) ;
            AfterConfirm0W31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W14 */
                  pr_default.execute(12, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV3");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound31 == 0 )
                        {
                           InitAll0W31( ) ;
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
                        ResetCaption0W0( ) ;
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W31( ) ;
         Gx_mode = sMode31;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W31( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W31( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgusuarioniv3",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgusuarioniv3",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W31( )
      {
         /* Using cursor T000W15 */
         pr_default.execute(13);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound31 = 1;
            A348UsuCod = T000W15_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000W15_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000W15_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000W15_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = T000W15_A345SGMenuNiv3ID[0];
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W31( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound31 = 1;
            A348UsuCod = T000W15_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000W15_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000W15_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000W15_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = T000W15_A345SGMenuNiv3ID[0];
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
         }
      }

      protected void ScanEnd0W31( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0W31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W31( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtSGMenuPrograma_Enabled = 0;
         AssignProp("", false, edtSGMenuPrograma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuPrograma_Enabled), 5, 0), true);
         edtSGMenuNiv1ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv1ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1ID_Enabled), 5, 0), true);
         edtSGMenuNiv2ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv2ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv2ID_Enabled), 5, 0), true);
         edtSGMenuNiv3ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv3ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv3ID_Enabled), 5, 0), true);
         edtSGUsuN2New_Enabled = 0;
         AssignProp("", false, edtSGUsuN2New_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN2New_Enabled), 5, 0), true);
         edtSGUsuN2Upd_Enabled = 0;
         AssignProp("", false, edtSGUsuN2Upd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN2Upd_Enabled), 5, 0), true);
         edtSGUsuN2Del_Enabled = 0;
         AssignProp("", false, edtSGUsuN2Del_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN2Del_Enabled), 5, 0), true);
         edtSGUsuN2DSP_Enabled = 0;
         AssignProp("", false, edtSGUsuN2DSP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN2DSP_Enabled), 5, 0), true);
         edtSGUsuN2Tot_Enabled = 0;
         AssignProp("", false, edtSGUsuN2Tot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN2Tot_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0W31( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0W0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443050", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuarioniv3.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z344SGMenuNiv2ID", Z344SGMenuNiv2ID);
         GxWebStd.gx_hidden_field( context, "Z345SGMenuNiv3ID", Z345SGMenuNiv3ID);
         GxWebStd.gx_hidden_field( context, "Z1862SGUsuN2New", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1862SGUsuN2New), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1864SGUsuN2Upd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1864SGUsuN2Upd), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1860SGUsuN2Del", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1860SGUsuN2Del), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1861SGUsuN2DSP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1861SGUsuN2DSP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1863SGUsuN2Tot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1863SGUsuN2Tot), 1, 0, ".", "")));
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
         return formatLink("sgusuarioniv3.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIONIV3" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIONIV3" ;
      }

      protected void InitializeNonKey0W31( )
      {
         A1862SGUsuN2New = 0;
         AssignAttri("", false, "A1862SGUsuN2New", StringUtil.Str( (decimal)(A1862SGUsuN2New), 1, 0));
         A1864SGUsuN2Upd = 0;
         AssignAttri("", false, "A1864SGUsuN2Upd", StringUtil.Str( (decimal)(A1864SGUsuN2Upd), 1, 0));
         A1860SGUsuN2Del = 0;
         AssignAttri("", false, "A1860SGUsuN2Del", StringUtil.Str( (decimal)(A1860SGUsuN2Del), 1, 0));
         A1861SGUsuN2DSP = 0;
         AssignAttri("", false, "A1861SGUsuN2DSP", StringUtil.Str( (decimal)(A1861SGUsuN2DSP), 1, 0));
         A1863SGUsuN2Tot = 0;
         AssignAttri("", false, "A1863SGUsuN2Tot", StringUtil.Str( (decimal)(A1863SGUsuN2Tot), 1, 0));
         Z1862SGUsuN2New = 0;
         Z1864SGUsuN2Upd = 0;
         Z1860SGUsuN2Del = 0;
         Z1861SGUsuN2DSP = 0;
         Z1863SGUsuN2Tot = 0;
      }

      protected void InitAll0W31( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         A342SGMenuPrograma = "";
         AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
         A343SGMenuNiv1ID = "";
         AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         A344SGMenuNiv2ID = "";
         AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
         A345SGMenuNiv3ID = "";
         AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
         InitializeNonKey0W31( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443056", true, true);
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
         context.AddJavascriptSource("sgusuarioniv3.js", "?202281811443056", false, true);
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
         edtSGMenuNiv2ID_Internalname = "SGMENUNIV2ID";
         edtSGMenuNiv3ID_Internalname = "SGMENUNIV3ID";
         edtSGUsuN2New_Internalname = "SGUSUN2NEW";
         edtSGUsuN2Upd_Internalname = "SGUSUN2UPD";
         edtSGUsuN2Del_Internalname = "SGUSUN2DEL";
         edtSGUsuN2DSP_Internalname = "SGUSUN2DSP";
         edtSGUsuN2Tot_Internalname = "SGUSUN2TOT";
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
         Form.Caption = "SGUSUARIONIV3";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGUsuN2Tot_Jsonclick = "";
         edtSGUsuN2Tot_Enabled = 1;
         edtSGUsuN2DSP_Jsonclick = "";
         edtSGUsuN2DSP_Enabled = 1;
         edtSGUsuN2Del_Jsonclick = "";
         edtSGUsuN2Del_Enabled = 1;
         edtSGUsuN2Upd_Jsonclick = "";
         edtSGUsuN2Upd_Enabled = 1;
         edtSGUsuN2New_Jsonclick = "";
         edtSGUsuN2New_Enabled = 1;
         edtSGMenuNiv3ID_Jsonclick = "";
         edtSGMenuNiv3ID_Enabled = 1;
         edtSGMenuNiv2ID_Jsonclick = "";
         edtSGMenuNiv2ID_Enabled = 1;
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
         /* Using cursor T000W16 */
         pr_default.execute(14, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000W17 */
         pr_default.execute(15, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 3'.", "ForeignKeyNotFound", 1, "SGMENUNIV3ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtSGUsuN2New_Internalname;
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

      public void Valid_Sgmenuniv2id( )
      {
         /* Using cursor T000W16 */
         pr_default.execute(14, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sgmenuniv3id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000W17 */
         pr_default.execute(15, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 3'.", "ForeignKeyNotFound", 1, "SGMENUNIV3ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1862SGUsuN2New", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1862SGUsuN2New), 1, 0, ".", "")));
         AssignAttri("", false, "A1864SGUsuN2Upd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1864SGUsuN2Upd), 1, 0, ".", "")));
         AssignAttri("", false, "A1860SGUsuN2Del", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1860SGUsuN2Del), 1, 0, ".", "")));
         AssignAttri("", false, "A1861SGUsuN2DSP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1861SGUsuN2DSP), 1, 0, ".", "")));
         AssignAttri("", false, "A1863SGUsuN2Tot", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1863SGUsuN2Tot), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z344SGMenuNiv2ID", Z344SGMenuNiv2ID);
         GxWebStd.gx_hidden_field( context, "Z345SGMenuNiv3ID", Z345SGMenuNiv3ID);
         GxWebStd.gx_hidden_field( context, "Z1862SGUsuN2New", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1862SGUsuN2New), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1864SGUsuN2Upd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1864SGUsuN2Upd), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1860SGUsuN2Del", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1860SGUsuN2Del), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1861SGUsuN2DSP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1861SGUsuN2DSP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1863SGUsuN2Tot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1863SGUsuN2Tot), 1, 0, ".", "")));
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
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[]");
         setEventMetadata("VALID_USUCOD",",oparms:[]}");
         setEventMetadata("VALID_SGMENUPROGRAMA","{handler:'Valid_Sgmenuprograma',iparms:[]");
         setEventMetadata("VALID_SGMENUPROGRAMA",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV1ID","{handler:'Valid_Sgmenuniv1id',iparms:[]");
         setEventMetadata("VALID_SGMENUNIV1ID",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV2ID","{handler:'Valid_Sgmenuniv2id',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'A344SGMenuNiv2ID',fld:'SGMENUNIV2ID',pic:''}]");
         setEventMetadata("VALID_SGMENUNIV2ID",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV3ID","{handler:'Valid_Sgmenuniv3id',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'A344SGMenuNiv2ID',fld:'SGMENUNIV2ID',pic:''},{av:'A345SGMenuNiv3ID',fld:'SGMENUNIV3ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGMENUNIV3ID",",oparms:[{av:'A1862SGUsuN2New',fld:'SGUSUN2NEW',pic:'9'},{av:'A1864SGUsuN2Upd',fld:'SGUSUN2UPD',pic:'9'},{av:'A1860SGUsuN2Del',fld:'SGUSUN2DEL',pic:'9'},{av:'A1861SGUsuN2DSP',fld:'SGUSUN2DSP',pic:'9'},{av:'A1863SGUsuN2Tot',fld:'SGUSUN2TOT',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z342SGMenuPrograma'},{av:'Z343SGMenuNiv1ID'},{av:'Z344SGMenuNiv2ID'},{av:'Z345SGMenuNiv3ID'},{av:'Z1862SGUsuN2New'},{av:'Z1864SGUsuN2Upd'},{av:'Z1860SGUsuN2Del'},{av:'Z1861SGUsuN2DSP'},{av:'Z1863SGUsuN2Tot'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         Z342SGMenuPrograma = "";
         Z343SGMenuNiv1ID = "";
         Z344SGMenuNiv2ID = "";
         Z345SGMenuNiv3ID = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A348UsuCod = "";
         A342SGMenuPrograma = "";
         A343SGMenuNiv1ID = "";
         A344SGMenuNiv2ID = "";
         A345SGMenuNiv3ID = "";
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
         T000W6_A1862SGUsuN2New = new short[1] ;
         T000W6_A1864SGUsuN2Upd = new short[1] ;
         T000W6_A1860SGUsuN2Del = new short[1] ;
         T000W6_A1861SGUsuN2DSP = new short[1] ;
         T000W6_A1863SGUsuN2Tot = new short[1] ;
         T000W6_A348UsuCod = new string[] {""} ;
         T000W6_A342SGMenuPrograma = new string[] {""} ;
         T000W6_A343SGMenuNiv1ID = new string[] {""} ;
         T000W6_A344SGMenuNiv2ID = new string[] {""} ;
         T000W6_A345SGMenuNiv3ID = new string[] {""} ;
         T000W4_A348UsuCod = new string[] {""} ;
         T000W5_A342SGMenuPrograma = new string[] {""} ;
         T000W7_A348UsuCod = new string[] {""} ;
         T000W8_A342SGMenuPrograma = new string[] {""} ;
         T000W9_A348UsuCod = new string[] {""} ;
         T000W9_A342SGMenuPrograma = new string[] {""} ;
         T000W9_A343SGMenuNiv1ID = new string[] {""} ;
         T000W9_A344SGMenuNiv2ID = new string[] {""} ;
         T000W9_A345SGMenuNiv3ID = new string[] {""} ;
         T000W3_A1862SGUsuN2New = new short[1] ;
         T000W3_A1864SGUsuN2Upd = new short[1] ;
         T000W3_A1860SGUsuN2Del = new short[1] ;
         T000W3_A1861SGUsuN2DSP = new short[1] ;
         T000W3_A1863SGUsuN2Tot = new short[1] ;
         T000W3_A348UsuCod = new string[] {""} ;
         T000W3_A342SGMenuPrograma = new string[] {""} ;
         T000W3_A343SGMenuNiv1ID = new string[] {""} ;
         T000W3_A344SGMenuNiv2ID = new string[] {""} ;
         T000W3_A345SGMenuNiv3ID = new string[] {""} ;
         sMode31 = "";
         T000W10_A348UsuCod = new string[] {""} ;
         T000W10_A342SGMenuPrograma = new string[] {""} ;
         T000W10_A343SGMenuNiv1ID = new string[] {""} ;
         T000W10_A344SGMenuNiv2ID = new string[] {""} ;
         T000W10_A345SGMenuNiv3ID = new string[] {""} ;
         T000W11_A348UsuCod = new string[] {""} ;
         T000W11_A342SGMenuPrograma = new string[] {""} ;
         T000W11_A343SGMenuNiv1ID = new string[] {""} ;
         T000W11_A344SGMenuNiv2ID = new string[] {""} ;
         T000W11_A345SGMenuNiv3ID = new string[] {""} ;
         T000W2_A1862SGUsuN2New = new short[1] ;
         T000W2_A1864SGUsuN2Upd = new short[1] ;
         T000W2_A1860SGUsuN2Del = new short[1] ;
         T000W2_A1861SGUsuN2DSP = new short[1] ;
         T000W2_A1863SGUsuN2Tot = new short[1] ;
         T000W2_A348UsuCod = new string[] {""} ;
         T000W2_A342SGMenuPrograma = new string[] {""} ;
         T000W2_A343SGMenuNiv1ID = new string[] {""} ;
         T000W2_A344SGMenuNiv2ID = new string[] {""} ;
         T000W2_A345SGMenuNiv3ID = new string[] {""} ;
         T000W15_A348UsuCod = new string[] {""} ;
         T000W15_A342SGMenuPrograma = new string[] {""} ;
         T000W15_A343SGMenuNiv1ID = new string[] {""} ;
         T000W15_A344SGMenuNiv2ID = new string[] {""} ;
         T000W15_A345SGMenuNiv3ID = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000W16_A348UsuCod = new string[] {""} ;
         T000W17_A342SGMenuPrograma = new string[] {""} ;
         ZZ348UsuCod = "";
         ZZ342SGMenuPrograma = "";
         ZZ343SGMenuNiv1ID = "";
         ZZ344SGMenuNiv2ID = "";
         ZZ345SGMenuNiv3ID = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioniv3__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioniv3__default(),
            new Object[][] {
                new Object[] {
               T000W2_A1862SGUsuN2New, T000W2_A1864SGUsuN2Upd, T000W2_A1860SGUsuN2Del, T000W2_A1861SGUsuN2DSP, T000W2_A1863SGUsuN2Tot, T000W2_A348UsuCod, T000W2_A342SGMenuPrograma, T000W2_A343SGMenuNiv1ID, T000W2_A344SGMenuNiv2ID, T000W2_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000W3_A1862SGUsuN2New, T000W3_A1864SGUsuN2Upd, T000W3_A1860SGUsuN2Del, T000W3_A1861SGUsuN2DSP, T000W3_A1863SGUsuN2Tot, T000W3_A348UsuCod, T000W3_A342SGMenuPrograma, T000W3_A343SGMenuNiv1ID, T000W3_A344SGMenuNiv2ID, T000W3_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000W4_A348UsuCod
               }
               , new Object[] {
               T000W5_A342SGMenuPrograma
               }
               , new Object[] {
               T000W6_A1862SGUsuN2New, T000W6_A1864SGUsuN2Upd, T000W6_A1860SGUsuN2Del, T000W6_A1861SGUsuN2DSP, T000W6_A1863SGUsuN2Tot, T000W6_A348UsuCod, T000W6_A342SGMenuPrograma, T000W6_A343SGMenuNiv1ID, T000W6_A344SGMenuNiv2ID, T000W6_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000W7_A348UsuCod
               }
               , new Object[] {
               T000W8_A342SGMenuPrograma
               }
               , new Object[] {
               T000W9_A348UsuCod, T000W9_A342SGMenuPrograma, T000W9_A343SGMenuNiv1ID, T000W9_A344SGMenuNiv2ID, T000W9_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000W10_A348UsuCod, T000W10_A342SGMenuPrograma, T000W10_A343SGMenuNiv1ID, T000W10_A344SGMenuNiv2ID, T000W10_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000W11_A348UsuCod, T000W11_A342SGMenuPrograma, T000W11_A343SGMenuNiv1ID, T000W11_A344SGMenuNiv2ID, T000W11_A345SGMenuNiv3ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W15_A348UsuCod, T000W15_A342SGMenuPrograma, T000W15_A343SGMenuNiv1ID, T000W15_A344SGMenuNiv2ID, T000W15_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000W16_A348UsuCod
               }
               , new Object[] {
               T000W17_A342SGMenuPrograma
               }
            }
         );
      }

      private short Z1862SGUsuN2New ;
      private short Z1864SGUsuN2Upd ;
      private short Z1860SGUsuN2Del ;
      private short Z1861SGUsuN2DSP ;
      private short Z1863SGUsuN2Tot ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1862SGUsuN2New ;
      private short A1864SGUsuN2Upd ;
      private short A1860SGUsuN2Del ;
      private short A1861SGUsuN2DSP ;
      private short A1863SGUsuN2Tot ;
      private short GX_JID ;
      private short RcdFound31 ;
      private short nIsDirty_31 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1862SGUsuN2New ;
      private short ZZ1864SGUsuN2Upd ;
      private short ZZ1860SGUsuN2Del ;
      private short ZZ1861SGUsuN2DSP ;
      private short ZZ1863SGUsuN2Tot ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtSGMenuPrograma_Enabled ;
      private int edtSGMenuNiv1ID_Enabled ;
      private int edtSGMenuNiv2ID_Enabled ;
      private int edtSGMenuNiv3ID_Enabled ;
      private int edtSGUsuN2New_Enabled ;
      private int edtSGUsuN2Upd_Enabled ;
      private int edtSGUsuN2Del_Enabled ;
      private int edtSGUsuN2DSP_Enabled ;
      private int edtSGUsuN2Tot_Enabled ;
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
      private string edtSGMenuNiv2ID_Internalname ;
      private string edtSGMenuNiv2ID_Jsonclick ;
      private string edtSGMenuNiv3ID_Internalname ;
      private string edtSGMenuNiv3ID_Jsonclick ;
      private string edtSGUsuN2New_Internalname ;
      private string edtSGUsuN2New_Jsonclick ;
      private string edtSGUsuN2Upd_Internalname ;
      private string edtSGUsuN2Upd_Jsonclick ;
      private string edtSGUsuN2Del_Internalname ;
      private string edtSGUsuN2Del_Jsonclick ;
      private string edtSGUsuN2DSP_Internalname ;
      private string edtSGUsuN2DSP_Jsonclick ;
      private string edtSGUsuN2Tot_Internalname ;
      private string edtSGUsuN2Tot_Jsonclick ;
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
      private string sMode31 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z342SGMenuPrograma ;
      private string Z343SGMenuNiv1ID ;
      private string Z344SGMenuNiv2ID ;
      private string Z345SGMenuNiv3ID ;
      private string A342SGMenuPrograma ;
      private string A343SGMenuNiv1ID ;
      private string A344SGMenuNiv2ID ;
      private string A345SGMenuNiv3ID ;
      private string ZZ342SGMenuPrograma ;
      private string ZZ343SGMenuNiv1ID ;
      private string ZZ344SGMenuNiv2ID ;
      private string ZZ345SGMenuNiv3ID ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000W6_A1862SGUsuN2New ;
      private short[] T000W6_A1864SGUsuN2Upd ;
      private short[] T000W6_A1860SGUsuN2Del ;
      private short[] T000W6_A1861SGUsuN2DSP ;
      private short[] T000W6_A1863SGUsuN2Tot ;
      private string[] T000W6_A348UsuCod ;
      private string[] T000W6_A342SGMenuPrograma ;
      private string[] T000W6_A343SGMenuNiv1ID ;
      private string[] T000W6_A344SGMenuNiv2ID ;
      private string[] T000W6_A345SGMenuNiv3ID ;
      private string[] T000W4_A348UsuCod ;
      private string[] T000W5_A342SGMenuPrograma ;
      private string[] T000W7_A348UsuCod ;
      private string[] T000W8_A342SGMenuPrograma ;
      private string[] T000W9_A348UsuCod ;
      private string[] T000W9_A342SGMenuPrograma ;
      private string[] T000W9_A343SGMenuNiv1ID ;
      private string[] T000W9_A344SGMenuNiv2ID ;
      private string[] T000W9_A345SGMenuNiv3ID ;
      private short[] T000W3_A1862SGUsuN2New ;
      private short[] T000W3_A1864SGUsuN2Upd ;
      private short[] T000W3_A1860SGUsuN2Del ;
      private short[] T000W3_A1861SGUsuN2DSP ;
      private short[] T000W3_A1863SGUsuN2Tot ;
      private string[] T000W3_A348UsuCod ;
      private string[] T000W3_A342SGMenuPrograma ;
      private string[] T000W3_A343SGMenuNiv1ID ;
      private string[] T000W3_A344SGMenuNiv2ID ;
      private string[] T000W3_A345SGMenuNiv3ID ;
      private string[] T000W10_A348UsuCod ;
      private string[] T000W10_A342SGMenuPrograma ;
      private string[] T000W10_A343SGMenuNiv1ID ;
      private string[] T000W10_A344SGMenuNiv2ID ;
      private string[] T000W10_A345SGMenuNiv3ID ;
      private string[] T000W11_A348UsuCod ;
      private string[] T000W11_A342SGMenuPrograma ;
      private string[] T000W11_A343SGMenuNiv1ID ;
      private string[] T000W11_A344SGMenuNiv2ID ;
      private string[] T000W11_A345SGMenuNiv3ID ;
      private short[] T000W2_A1862SGUsuN2New ;
      private short[] T000W2_A1864SGUsuN2Upd ;
      private short[] T000W2_A1860SGUsuN2Del ;
      private short[] T000W2_A1861SGUsuN2DSP ;
      private short[] T000W2_A1863SGUsuN2Tot ;
      private string[] T000W2_A348UsuCod ;
      private string[] T000W2_A342SGMenuPrograma ;
      private string[] T000W2_A343SGMenuNiv1ID ;
      private string[] T000W2_A344SGMenuNiv2ID ;
      private string[] T000W2_A345SGMenuNiv3ID ;
      private string[] T000W15_A348UsuCod ;
      private string[] T000W15_A342SGMenuPrograma ;
      private string[] T000W15_A343SGMenuNiv1ID ;
      private string[] T000W15_A344SGMenuNiv2ID ;
      private string[] T000W15_A345SGMenuNiv3ID ;
      private string[] T000W16_A348UsuCod ;
      private string[] T000W17_A342SGMenuPrograma ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuarioniv3__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarioniv3__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000W6;
        prmT000W6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W4;
        prmT000W4 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W5;
        prmT000W5 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W7;
        prmT000W7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W8;
        prmT000W8 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W9;
        prmT000W9 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W3;
        prmT000W3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W10;
        prmT000W10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W11;
        prmT000W11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W2;
        prmT000W2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W12;
        prmT000W12 = new Object[] {
        new ParDef("@SGUsuN2New",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Upd",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Del",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2DSP",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Tot",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W13;
        prmT000W13 = new Object[] {
        new ParDef("@SGUsuN2New",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Upd",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Del",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2DSP",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Tot",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W14;
        prmT000W14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W15;
        prmT000W15 = new Object[] {
        };
        Object[] prmT000W16;
        prmT000W16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000W17;
        prmT000W17 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000W2", "SELECT [SGUsuN2New], [SGUsuN2Upd], [SGUsuN2Del], [SGUsuN2DSP], [SGUsuN2Tot], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W3", "SELECT [SGUsuN2New], [SGUsuN2Upd], [SGUsuN2Del], [SGUsuN2DSP], [SGUsuN2Tot], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W4", "SELECT [UsuCod] FROM [SGUSUARIONIV2] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W5", "SELECT [SGMenuPrograma] FROM [SGMENUNIV3] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W6", "SELECT TM1.[SGUsuN2New], TM1.[SGUsuN2Upd], TM1.[SGUsuN2Del], TM1.[SGUsuN2DSP], TM1.[SGUsuN2Tot], TM1.[UsuCod], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv2ID], TM1.[SGMenuNiv3ID] FROM [SGUSUARIONIV3] TM1 WHERE TM1.[UsuCod] = @UsuCod and TM1.[SGMenuPrograma] = @SGMenuPrograma and TM1.[SGMenuNiv1ID] = @SGMenuNiv1ID and TM1.[SGMenuNiv2ID] = @SGMenuNiv2ID and TM1.[SGMenuNiv3ID] = @SGMenuNiv3ID ORDER BY TM1.[UsuCod], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv2ID], TM1.[SGMenuNiv3ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W7", "SELECT [UsuCod] FROM [SGUSUARIONIV2] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W8", "SELECT [SGMenuPrograma] FROM [SGMENUNIV3] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W9", "SELECT [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W10", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WHERE ( [UsuCod] > @UsuCod or [UsuCod] = @UsuCod and [SGMenuPrograma] > @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv1ID] > @SGMenuNiv1ID or [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv2ID] > @SGMenuNiv2ID or [SGMenuNiv2ID] = @SGMenuNiv2ID and [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv3ID] > @SGMenuNiv3ID) ORDER BY [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W11", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WHERE ( [UsuCod] < @UsuCod or [UsuCod] = @UsuCod and [SGMenuPrograma] < @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv1ID] < @SGMenuNiv1ID or [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv2ID] < @SGMenuNiv2ID or [SGMenuNiv2ID] = @SGMenuNiv2ID and [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv3ID] < @SGMenuNiv3ID) ORDER BY [UsuCod] DESC, [SGMenuPrograma] DESC, [SGMenuNiv1ID] DESC, [SGMenuNiv2ID] DESC, [SGMenuNiv3ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W12", "INSERT INTO [SGUSUARIONIV3]([SGUsuN2New], [SGUsuN2Upd], [SGUsuN2Del], [SGUsuN2DSP], [SGUsuN2Tot], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID]) VALUES(@SGUsuN2New, @SGUsuN2Upd, @SGUsuN2Del, @SGUsuN2DSP, @SGUsuN2Tot, @UsuCod, @SGMenuPrograma, @SGMenuNiv1ID, @SGMenuNiv2ID, @SGMenuNiv3ID)", GxErrorMask.GX_NOMASK,prmT000W12)
           ,new CursorDef("T000W13", "UPDATE [SGUSUARIONIV3] SET [SGUsuN2New]=@SGUsuN2New, [SGUsuN2Upd]=@SGUsuN2Upd, [SGUsuN2Del]=@SGUsuN2Del, [SGUsuN2DSP]=@SGUsuN2DSP, [SGUsuN2Tot]=@SGUsuN2Tot  WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID", GxErrorMask.GX_NOMASK,prmT000W13)
           ,new CursorDef("T000W14", "DELETE FROM [SGUSUARIONIV3]  WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID", GxErrorMask.GX_NOMASK,prmT000W14)
           ,new CursorDef("T000W15", "SELECT [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] ORDER BY [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W16", "SELECT [UsuCod] FROM [SGUSUARIONIV2] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W17", "SELECT [SGMenuPrograma] FROM [SGMENUNIV3] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W17,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
