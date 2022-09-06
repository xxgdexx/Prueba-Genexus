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
   public class sgmenuniv3 : GXDataArea
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
            gxLoad_2( A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID) ;
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
            Form.Meta.addItem("description", "Nivel 3", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgmenuniv3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgmenuniv3( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Nivel 3", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGMENUNIV3.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGMENUNIV3.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuPrograma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuPrograma_Internalname, "SGMenu Programa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuPrograma_Internalname, A342SGMenuPrograma, StringUtil.RTrim( context.localUtil.Format( A342SGMenuPrograma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuPrograma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuPrograma_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV3.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv1ID_Internalname, A343SGMenuNiv1ID, StringUtil.RTrim( context.localUtil.Format( A343SGMenuNiv1ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv1ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv1ID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV3.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv2ID_Internalname, A344SGMenuNiv2ID, StringUtil.RTrim( context.localUtil.Format( A344SGMenuNiv2ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv2ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv2ID_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV3.htm");
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
         GxWebStd.gx_label_element( context, edtSGMenuNiv3ID_Internalname, "Nivel 3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv3ID_Internalname, A345SGMenuNiv3ID, StringUtil.RTrim( context.localUtil.Format( A345SGMenuNiv3ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv3ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv3ID_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv3Dsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv3Dsc_Internalname, "Menu 3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv3Dsc_Internalname, A1853SGMenuNiv3Dsc, StringUtil.RTrim( context.localUtil.Format( A1853SGMenuNiv3Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv3Dsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv3Dsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv3Link_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv3Link_Internalname, "Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv3Link_Internalname, A1854SGMenuNiv3Link, StringUtil.RTrim( context.localUtil.Format( A1854SGMenuNiv3Link, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv3Link_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv3Link_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGMENUNIV3.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGMENUNIV3.htm");
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
            Z342SGMenuPrograma = cgiGet( "Z342SGMenuPrograma");
            Z343SGMenuNiv1ID = cgiGet( "Z343SGMenuNiv1ID");
            Z344SGMenuNiv2ID = cgiGet( "Z344SGMenuNiv2ID");
            Z345SGMenuNiv3ID = cgiGet( "Z345SGMenuNiv3ID");
            Z1853SGMenuNiv3Dsc = cgiGet( "Z1853SGMenuNiv3Dsc");
            Z1854SGMenuNiv3Link = cgiGet( "Z1854SGMenuNiv3Link");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A342SGMenuPrograma = cgiGet( edtSGMenuPrograma_Internalname);
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = cgiGet( edtSGMenuNiv1ID_Internalname);
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = cgiGet( edtSGMenuNiv2ID_Internalname);
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = cgiGet( edtSGMenuNiv3ID_Internalname);
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
            A1853SGMenuNiv3Dsc = cgiGet( edtSGMenuNiv3Dsc_Internalname);
            AssignAttri("", false, "A1853SGMenuNiv3Dsc", A1853SGMenuNiv3Dsc);
            A1854SGMenuNiv3Link = cgiGet( edtSGMenuNiv3Link_Internalname);
            AssignAttri("", false, "A1854SGMenuNiv3Link", A1854SGMenuNiv3Link);
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
               InitAll0P25( ) ;
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
         DisableAttributes0P25( ) ;
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

      protected void ResetCaption0P0( )
      {
      }

      protected void ZM0P25( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1853SGMenuNiv3Dsc = T000P3_A1853SGMenuNiv3Dsc[0];
               Z1854SGMenuNiv3Link = T000P3_A1854SGMenuNiv3Link[0];
            }
            else
            {
               Z1853SGMenuNiv3Dsc = A1853SGMenuNiv3Dsc;
               Z1854SGMenuNiv3Link = A1854SGMenuNiv3Link;
            }
         }
         if ( GX_JID == -1 )
         {
            Z345SGMenuNiv3ID = A345SGMenuNiv3ID;
            Z1853SGMenuNiv3Dsc = A1853SGMenuNiv3Dsc;
            Z1854SGMenuNiv3Link = A1854SGMenuNiv3Link;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z344SGMenuNiv2ID = A344SGMenuNiv2ID;
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

      protected void Load0P25( )
      {
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
            A1853SGMenuNiv3Dsc = T000P5_A1853SGMenuNiv3Dsc[0];
            AssignAttri("", false, "A1853SGMenuNiv3Dsc", A1853SGMenuNiv3Dsc);
            A1854SGMenuNiv3Link = T000P5_A1854SGMenuNiv3Link[0];
            AssignAttri("", false, "A1854SGMenuNiv3Link", A1854SGMenuNiv3Link);
            ZM0P25( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0P25( ) ;
      }

      protected void OnLoadActions0P25( )
      {
      }

      protected void CheckExtendedTable0P25( )
      {
         nIsDirty_25 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0P25( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A342SGMenuPrograma ,
                               string A343SGMenuNiv1ID ,
                               string A344SGMenuNiv2ID )
      {
         /* Using cursor T000P6 */
         pr_default.execute(4, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0P25( )
      {
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P25( 1) ;
            RcdFound25 = 1;
            A345SGMenuNiv3ID = T000P3_A345SGMenuNiv3ID[0];
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
            A1853SGMenuNiv3Dsc = T000P3_A1853SGMenuNiv3Dsc[0];
            AssignAttri("", false, "A1853SGMenuNiv3Dsc", A1853SGMenuNiv3Dsc);
            A1854SGMenuNiv3Link = T000P3_A1854SGMenuNiv3Link[0];
            AssignAttri("", false, "A1854SGMenuNiv3Link", A1854SGMenuNiv3Link);
            A342SGMenuPrograma = T000P3_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000P3_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000P3_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z344SGMenuNiv2ID = A344SGMenuNiv2ID;
            Z345SGMenuNiv3ID = A345SGMenuNiv3ID;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0P25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0P25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0P25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P25( ) ;
         if ( RcdFound25 == 0 )
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
         RcdFound25 = 0;
         /* Using cursor T000P8 */
         pr_default.execute(6, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P8_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) || ( StringUtil.StrCmp(T000P8_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P8_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) < 0 ) || ( StringUtil.StrCmp(T000P8_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000P8_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P8_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P8_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) || ( StringUtil.StrCmp(T000P8_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P8_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) > 0 ) || ( StringUtil.StrCmp(T000P8_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000P8_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P8_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P8_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) > 0 ) ) )
            {
               A342SGMenuPrograma = T000P8_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000P8_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = T000P8_A344SGMenuNiv2ID[0];
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               A345SGMenuNiv3ID = T000P8_A345SGMenuNiv3ID[0];
               AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
               RcdFound25 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000P9 */
         pr_default.execute(7, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P9_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) || ( StringUtil.StrCmp(T000P9_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P9_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) > 0 ) || ( StringUtil.StrCmp(T000P9_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000P9_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P9_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P9_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) || ( StringUtil.StrCmp(T000P9_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P9_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) < 0 ) || ( StringUtil.StrCmp(T000P9_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) == 0 ) && ( StringUtil.StrCmp(T000P9_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000P9_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000P9_A345SGMenuNiv3ID[0], A345SGMenuNiv3ID) < 0 ) ) )
            {
               A342SGMenuPrograma = T000P9_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000P9_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = T000P9_A344SGMenuNiv2ID[0];
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               A345SGMenuNiv3ID = T000P9_A345SGMenuNiv3ID[0];
               AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
               RcdFound25 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0P25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) || ( StringUtil.StrCmp(A345SGMenuNiv3ID, Z345SGMenuNiv3ID) != 0 ) )
               {
                  A342SGMenuPrograma = Z342SGMenuPrograma;
                  AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
                  A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
                  AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
                  A344SGMenuNiv2ID = Z344SGMenuNiv2ID;
                  AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
                  A345SGMenuNiv3ID = Z345SGMenuNiv3ID;
                  AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SGMENUPROGRAMA");
                  AnyError = 1;
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0P25( ) ;
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) || ( StringUtil.StrCmp(A345SGMenuNiv3ID, Z345SGMenuNiv3ID) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSGMenuPrograma_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0P25( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SGMENUPROGRAMA");
                     AnyError = 1;
                     GX_FocusControl = edtSGMenuPrograma_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSGMenuPrograma_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0P25( ) ;
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
         if ( ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) || ( StringUtil.StrCmp(A345SGMenuNiv3ID, Z345SGMenuNiv3ID) != 0 ) )
         {
            A342SGMenuPrograma = Z342SGMenuPrograma;
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = Z344SGMenuNiv2ID;
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = Z345SGMenuNiv3ID;
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SGMENUPROGRAMA");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
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
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SGMENUPROGRAMA");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGMenuNiv3Dsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0P25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv3Dsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0P25( ) ;
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
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv3Dsc_Internalname;
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
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv3Dsc_Internalname;
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
         ScanStart0P25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound25 != 0 )
            {
               ScanNext0P25( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGMenuNiv3Dsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0P25( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0P25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGMENUNIV3"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1853SGMenuNiv3Dsc, T000P2_A1853SGMenuNiv3Dsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1854SGMenuNiv3Link, T000P2_A1854SGMenuNiv3Link[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1853SGMenuNiv3Dsc, T000P2_A1853SGMenuNiv3Dsc[0]) != 0 )
               {
                  GXUtil.WriteLog("sgmenuniv3:[seudo value changed for attri]"+"SGMenuNiv3Dsc");
                  GXUtil.WriteLogRaw("Old: ",Z1853SGMenuNiv3Dsc);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A1853SGMenuNiv3Dsc[0]);
               }
               if ( StringUtil.StrCmp(Z1854SGMenuNiv3Link, T000P2_A1854SGMenuNiv3Link[0]) != 0 )
               {
                  GXUtil.WriteLog("sgmenuniv3:[seudo value changed for attri]"+"SGMenuNiv3Link");
                  GXUtil.WriteLogRaw("Old: ",Z1854SGMenuNiv3Link);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A1854SGMenuNiv3Link[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGMENUNIV3"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P25( )
      {
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P25( 0) ;
            CheckOptimisticConcurrency0P25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P10 */
                     pr_default.execute(8, new Object[] {A345SGMenuNiv3ID, A1853SGMenuNiv3Dsc, A1854SGMenuNiv3Link, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("SGMENUNIV3");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption0P0( ) ;
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
               Load0P25( ) ;
            }
            EndLevel0P25( ) ;
         }
         CloseExtendedTableCursors0P25( ) ;
      }

      protected void Update0P25( )
      {
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P11 */
                     pr_default.execute(9, new Object[] {A1853SGMenuNiv3Dsc, A1854SGMenuNiv3Link, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SGMENUNIV3");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGMENUNIV3"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0P0( ) ;
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
            EndLevel0P25( ) ;
         }
         CloseExtendedTableCursors0P25( ) ;
      }

      protected void DeferredUpdate0P25( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P25( ) ;
            AfterConfirm0P25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P12 */
                  pr_default.execute(10, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("SGMENUNIV3");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound25 == 0 )
                        {
                           InitAll0P25( ) ;
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
                        ResetCaption0P0( ) ;
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000P13 */
            pr_default.execute(11, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV3"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0P25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgmenuniv3",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgmenuniv3",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P25( )
      {
         /* Using cursor T000P14 */
         pr_default.execute(12);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A342SGMenuPrograma = T000P14_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000P14_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000P14_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = T000P14_A345SGMenuNiv3ID[0];
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P25( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A342SGMenuPrograma = T000P14_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000P14_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000P14_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            A345SGMenuNiv3ID = T000P14_A345SGMenuNiv3ID[0];
            AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
         }
      }

      protected void ScanEnd0P25( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0P25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P25( )
      {
         edtSGMenuPrograma_Enabled = 0;
         AssignProp("", false, edtSGMenuPrograma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuPrograma_Enabled), 5, 0), true);
         edtSGMenuNiv1ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv1ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1ID_Enabled), 5, 0), true);
         edtSGMenuNiv2ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv2ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv2ID_Enabled), 5, 0), true);
         edtSGMenuNiv3ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv3ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv3ID_Enabled), 5, 0), true);
         edtSGMenuNiv3Dsc_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv3Dsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv3Dsc_Enabled), 5, 0), true);
         edtSGMenuNiv3Link_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv3Link_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv3Link_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0P25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0P0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442842", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgmenuniv3.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z344SGMenuNiv2ID", Z344SGMenuNiv2ID);
         GxWebStd.gx_hidden_field( context, "Z345SGMenuNiv3ID", Z345SGMenuNiv3ID);
         GxWebStd.gx_hidden_field( context, "Z1853SGMenuNiv3Dsc", Z1853SGMenuNiv3Dsc);
         GxWebStd.gx_hidden_field( context, "Z1854SGMenuNiv3Link", Z1854SGMenuNiv3Link);
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
         return formatLink("sgmenuniv3.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGMENUNIV3" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nivel 3" ;
      }

      protected void InitializeNonKey0P25( )
      {
         A1853SGMenuNiv3Dsc = "";
         AssignAttri("", false, "A1853SGMenuNiv3Dsc", A1853SGMenuNiv3Dsc);
         A1854SGMenuNiv3Link = "";
         AssignAttri("", false, "A1854SGMenuNiv3Link", A1854SGMenuNiv3Link);
         Z1853SGMenuNiv3Dsc = "";
         Z1854SGMenuNiv3Link = "";
      }

      protected void InitAll0P25( )
      {
         A342SGMenuPrograma = "";
         AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
         A343SGMenuNiv1ID = "";
         AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         A344SGMenuNiv2ID = "";
         AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
         A345SGMenuNiv3ID = "";
         AssignAttri("", false, "A345SGMenuNiv3ID", A345SGMenuNiv3ID);
         InitializeNonKey0P25( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811442847", true, true);
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
         context.AddJavascriptSource("sgmenuniv3.js", "?202281811442847", false, true);
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
         edtSGMenuPrograma_Internalname = "SGMENUPROGRAMA";
         edtSGMenuNiv1ID_Internalname = "SGMENUNIV1ID";
         edtSGMenuNiv2ID_Internalname = "SGMENUNIV2ID";
         edtSGMenuNiv3ID_Internalname = "SGMENUNIV3ID";
         edtSGMenuNiv3Dsc_Internalname = "SGMENUNIV3DSC";
         edtSGMenuNiv3Link_Internalname = "SGMENUNIV3LINK";
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
         Form.Caption = "Nivel 3";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGMenuNiv3Link_Jsonclick = "";
         edtSGMenuNiv3Link_Enabled = 1;
         edtSGMenuNiv3Dsc_Jsonclick = "";
         edtSGMenuNiv3Dsc_Enabled = 1;
         edtSGMenuNiv3ID_Jsonclick = "";
         edtSGMenuNiv3ID_Enabled = 1;
         edtSGMenuNiv2ID_Jsonclick = "";
         edtSGMenuNiv2ID_Enabled = 1;
         edtSGMenuNiv1ID_Jsonclick = "";
         edtSGMenuNiv1ID_Enabled = 1;
         edtSGMenuPrograma_Jsonclick = "";
         edtSGMenuPrograma_Enabled = 1;
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
         /* Using cursor T000P15 */
         pr_default.execute(13, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         GX_FocusControl = edtSGMenuNiv3Dsc_Internalname;
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
         /* Using cursor T000P15 */
         pr_default.execute(13, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sgmenuniv3id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1853SGMenuNiv3Dsc", A1853SGMenuNiv3Dsc);
         AssignAttri("", false, "A1854SGMenuNiv3Link", A1854SGMenuNiv3Link);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z344SGMenuNiv2ID", Z344SGMenuNiv2ID);
         GxWebStd.gx_hidden_field( context, "Z345SGMenuNiv3ID", Z345SGMenuNiv3ID);
         GxWebStd.gx_hidden_field( context, "Z1853SGMenuNiv3Dsc", Z1853SGMenuNiv3Dsc);
         GxWebStd.gx_hidden_field( context, "Z1854SGMenuNiv3Link", Z1854SGMenuNiv3Link);
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
         setEventMetadata("VALID_SGMENUPROGRAMA","{handler:'Valid_Sgmenuprograma',iparms:[]");
         setEventMetadata("VALID_SGMENUPROGRAMA",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV1ID","{handler:'Valid_Sgmenuniv1id',iparms:[]");
         setEventMetadata("VALID_SGMENUNIV1ID",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV2ID","{handler:'Valid_Sgmenuniv2id',iparms:[{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'A344SGMenuNiv2ID',fld:'SGMENUNIV2ID',pic:''}]");
         setEventMetadata("VALID_SGMENUNIV2ID",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV3ID","{handler:'Valid_Sgmenuniv3id',iparms:[{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'A344SGMenuNiv2ID',fld:'SGMENUNIV2ID',pic:''},{av:'A345SGMenuNiv3ID',fld:'SGMENUNIV3ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGMENUNIV3ID",",oparms:[{av:'A1853SGMenuNiv3Dsc',fld:'SGMENUNIV3DSC',pic:''},{av:'A1854SGMenuNiv3Link',fld:'SGMENUNIV3LINK',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z342SGMenuPrograma'},{av:'Z343SGMenuNiv1ID'},{av:'Z344SGMenuNiv2ID'},{av:'Z345SGMenuNiv3ID'},{av:'Z1853SGMenuNiv3Dsc'},{av:'Z1854SGMenuNiv3Link'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z342SGMenuPrograma = "";
         Z343SGMenuNiv1ID = "";
         Z344SGMenuNiv2ID = "";
         Z345SGMenuNiv3ID = "";
         Z1853SGMenuNiv3Dsc = "";
         Z1854SGMenuNiv3Link = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A342SGMenuPrograma = "";
         A343SGMenuNiv1ID = "";
         A344SGMenuNiv2ID = "";
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
         A345SGMenuNiv3ID = "";
         A1853SGMenuNiv3Dsc = "";
         A1854SGMenuNiv3Link = "";
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
         T000P5_A345SGMenuNiv3ID = new string[] {""} ;
         T000P5_A1853SGMenuNiv3Dsc = new string[] {""} ;
         T000P5_A1854SGMenuNiv3Link = new string[] {""} ;
         T000P5_A342SGMenuPrograma = new string[] {""} ;
         T000P5_A343SGMenuNiv1ID = new string[] {""} ;
         T000P5_A344SGMenuNiv2ID = new string[] {""} ;
         T000P4_A342SGMenuPrograma = new string[] {""} ;
         T000P6_A342SGMenuPrograma = new string[] {""} ;
         T000P7_A342SGMenuPrograma = new string[] {""} ;
         T000P7_A343SGMenuNiv1ID = new string[] {""} ;
         T000P7_A344SGMenuNiv2ID = new string[] {""} ;
         T000P7_A345SGMenuNiv3ID = new string[] {""} ;
         T000P3_A345SGMenuNiv3ID = new string[] {""} ;
         T000P3_A1853SGMenuNiv3Dsc = new string[] {""} ;
         T000P3_A1854SGMenuNiv3Link = new string[] {""} ;
         T000P3_A342SGMenuPrograma = new string[] {""} ;
         T000P3_A343SGMenuNiv1ID = new string[] {""} ;
         T000P3_A344SGMenuNiv2ID = new string[] {""} ;
         sMode25 = "";
         T000P8_A342SGMenuPrograma = new string[] {""} ;
         T000P8_A343SGMenuNiv1ID = new string[] {""} ;
         T000P8_A344SGMenuNiv2ID = new string[] {""} ;
         T000P8_A345SGMenuNiv3ID = new string[] {""} ;
         T000P9_A342SGMenuPrograma = new string[] {""} ;
         T000P9_A343SGMenuNiv1ID = new string[] {""} ;
         T000P9_A344SGMenuNiv2ID = new string[] {""} ;
         T000P9_A345SGMenuNiv3ID = new string[] {""} ;
         T000P2_A345SGMenuNiv3ID = new string[] {""} ;
         T000P2_A1853SGMenuNiv3Dsc = new string[] {""} ;
         T000P2_A1854SGMenuNiv3Link = new string[] {""} ;
         T000P2_A342SGMenuPrograma = new string[] {""} ;
         T000P2_A343SGMenuNiv1ID = new string[] {""} ;
         T000P2_A344SGMenuNiv2ID = new string[] {""} ;
         T000P13_A348UsuCod = new string[] {""} ;
         T000P13_A342SGMenuPrograma = new string[] {""} ;
         T000P13_A343SGMenuNiv1ID = new string[] {""} ;
         T000P13_A344SGMenuNiv2ID = new string[] {""} ;
         T000P13_A345SGMenuNiv3ID = new string[] {""} ;
         T000P14_A342SGMenuPrograma = new string[] {""} ;
         T000P14_A343SGMenuNiv1ID = new string[] {""} ;
         T000P14_A344SGMenuNiv2ID = new string[] {""} ;
         T000P14_A345SGMenuNiv3ID = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000P15_A342SGMenuPrograma = new string[] {""} ;
         ZZ342SGMenuPrograma = "";
         ZZ343SGMenuNiv1ID = "";
         ZZ344SGMenuNiv2ID = "";
         ZZ345SGMenuNiv3ID = "";
         ZZ1853SGMenuNiv3Dsc = "";
         ZZ1854SGMenuNiv3Link = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgmenuniv3__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgmenuniv3__default(),
            new Object[][] {
                new Object[] {
               T000P2_A345SGMenuNiv3ID, T000P2_A1853SGMenuNiv3Dsc, T000P2_A1854SGMenuNiv3Link, T000P2_A342SGMenuPrograma, T000P2_A343SGMenuNiv1ID, T000P2_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000P3_A345SGMenuNiv3ID, T000P3_A1853SGMenuNiv3Dsc, T000P3_A1854SGMenuNiv3Link, T000P3_A342SGMenuPrograma, T000P3_A343SGMenuNiv1ID, T000P3_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000P4_A342SGMenuPrograma
               }
               , new Object[] {
               T000P5_A345SGMenuNiv3ID, T000P5_A1853SGMenuNiv3Dsc, T000P5_A1854SGMenuNiv3Link, T000P5_A342SGMenuPrograma, T000P5_A343SGMenuNiv1ID, T000P5_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000P6_A342SGMenuPrograma
               }
               , new Object[] {
               T000P7_A342SGMenuPrograma, T000P7_A343SGMenuNiv1ID, T000P7_A344SGMenuNiv2ID, T000P7_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000P8_A342SGMenuPrograma, T000P8_A343SGMenuNiv1ID, T000P8_A344SGMenuNiv2ID, T000P8_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000P9_A342SGMenuPrograma, T000P9_A343SGMenuNiv1ID, T000P9_A344SGMenuNiv2ID, T000P9_A345SGMenuNiv3ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P13_A348UsuCod, T000P13_A342SGMenuPrograma, T000P13_A343SGMenuNiv1ID, T000P13_A344SGMenuNiv2ID, T000P13_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000P14_A342SGMenuPrograma, T000P14_A343SGMenuNiv1ID, T000P14_A344SGMenuNiv2ID, T000P14_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000P15_A342SGMenuPrograma
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
      private short RcdFound25 ;
      private short nIsDirty_25 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSGMenuPrograma_Enabled ;
      private int edtSGMenuNiv1ID_Enabled ;
      private int edtSGMenuNiv2ID_Enabled ;
      private int edtSGMenuNiv3ID_Enabled ;
      private int edtSGMenuNiv3Dsc_Enabled ;
      private int edtSGMenuNiv3Link_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSGMenuPrograma_Internalname ;
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
      private string edtSGMenuPrograma_Jsonclick ;
      private string edtSGMenuNiv1ID_Internalname ;
      private string edtSGMenuNiv1ID_Jsonclick ;
      private string edtSGMenuNiv2ID_Internalname ;
      private string edtSGMenuNiv2ID_Jsonclick ;
      private string edtSGMenuNiv3ID_Internalname ;
      private string edtSGMenuNiv3ID_Jsonclick ;
      private string edtSGMenuNiv3Dsc_Internalname ;
      private string edtSGMenuNiv3Dsc_Jsonclick ;
      private string edtSGMenuNiv3Link_Internalname ;
      private string edtSGMenuNiv3Link_Jsonclick ;
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
      private string sMode25 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z342SGMenuPrograma ;
      private string Z343SGMenuNiv1ID ;
      private string Z344SGMenuNiv2ID ;
      private string Z345SGMenuNiv3ID ;
      private string Z1853SGMenuNiv3Dsc ;
      private string Z1854SGMenuNiv3Link ;
      private string A342SGMenuPrograma ;
      private string A343SGMenuNiv1ID ;
      private string A344SGMenuNiv2ID ;
      private string A345SGMenuNiv3ID ;
      private string A1853SGMenuNiv3Dsc ;
      private string A1854SGMenuNiv3Link ;
      private string ZZ342SGMenuPrograma ;
      private string ZZ343SGMenuNiv1ID ;
      private string ZZ344SGMenuNiv2ID ;
      private string ZZ345SGMenuNiv3ID ;
      private string ZZ1853SGMenuNiv3Dsc ;
      private string ZZ1854SGMenuNiv3Link ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000P5_A345SGMenuNiv3ID ;
      private string[] T000P5_A1853SGMenuNiv3Dsc ;
      private string[] T000P5_A1854SGMenuNiv3Link ;
      private string[] T000P5_A342SGMenuPrograma ;
      private string[] T000P5_A343SGMenuNiv1ID ;
      private string[] T000P5_A344SGMenuNiv2ID ;
      private string[] T000P4_A342SGMenuPrograma ;
      private string[] T000P6_A342SGMenuPrograma ;
      private string[] T000P7_A342SGMenuPrograma ;
      private string[] T000P7_A343SGMenuNiv1ID ;
      private string[] T000P7_A344SGMenuNiv2ID ;
      private string[] T000P7_A345SGMenuNiv3ID ;
      private string[] T000P3_A345SGMenuNiv3ID ;
      private string[] T000P3_A1853SGMenuNiv3Dsc ;
      private string[] T000P3_A1854SGMenuNiv3Link ;
      private string[] T000P3_A342SGMenuPrograma ;
      private string[] T000P3_A343SGMenuNiv1ID ;
      private string[] T000P3_A344SGMenuNiv2ID ;
      private string[] T000P8_A342SGMenuPrograma ;
      private string[] T000P8_A343SGMenuNiv1ID ;
      private string[] T000P8_A344SGMenuNiv2ID ;
      private string[] T000P8_A345SGMenuNiv3ID ;
      private string[] T000P9_A342SGMenuPrograma ;
      private string[] T000P9_A343SGMenuNiv1ID ;
      private string[] T000P9_A344SGMenuNiv2ID ;
      private string[] T000P9_A345SGMenuNiv3ID ;
      private string[] T000P2_A345SGMenuNiv3ID ;
      private string[] T000P2_A1853SGMenuNiv3Dsc ;
      private string[] T000P2_A1854SGMenuNiv3Link ;
      private string[] T000P2_A342SGMenuPrograma ;
      private string[] T000P2_A343SGMenuNiv1ID ;
      private string[] T000P2_A344SGMenuNiv2ID ;
      private string[] T000P13_A348UsuCod ;
      private string[] T000P13_A342SGMenuPrograma ;
      private string[] T000P13_A343SGMenuNiv1ID ;
      private string[] T000P13_A344SGMenuNiv2ID ;
      private string[] T000P13_A345SGMenuNiv3ID ;
      private string[] T000P14_A342SGMenuPrograma ;
      private string[] T000P14_A343SGMenuNiv1ID ;
      private string[] T000P14_A344SGMenuNiv2ID ;
      private string[] T000P14_A345SGMenuNiv3ID ;
      private string[] T000P15_A342SGMenuPrograma ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgmenuniv3__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgmenuniv3__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000P5;
        prmT000P5 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P4;
        prmT000P4 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P6;
        prmT000P6 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P7;
        prmT000P7 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P3;
        prmT000P3 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P8;
        prmT000P8 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P9;
        prmT000P9 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P2;
        prmT000P2 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P10;
        prmT000P10 = new Object[] {
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@SGMenuNiv3Link",GXType.NVarChar,100,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P11;
        prmT000P11 = new Object[] {
        new ParDef("@SGMenuNiv3Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@SGMenuNiv3Link",GXType.NVarChar,100,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P12;
        prmT000P12 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P13;
        prmT000P13 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000P14;
        prmT000P14 = new Object[] {
        };
        Object[] prmT000P15;
        prmT000P15 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000P2", "SELECT [SGMenuNiv3ID], [SGMenuNiv3Dsc], [SGMenuNiv3Link], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGMENUNIV3] WITH (UPDLOCK) WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P3", "SELECT [SGMenuNiv3ID], [SGMenuNiv3Dsc], [SGMenuNiv3Link], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGMENUNIV3] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P4", "SELECT [SGMenuPrograma] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P5", "SELECT TM1.[SGMenuNiv3ID], TM1.[SGMenuNiv3Dsc], TM1.[SGMenuNiv3Link], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv2ID] FROM [SGMENUNIV3] TM1 WHERE TM1.[SGMenuPrograma] = @SGMenuPrograma and TM1.[SGMenuNiv1ID] = @SGMenuNiv1ID and TM1.[SGMenuNiv2ID] = @SGMenuNiv2ID and TM1.[SGMenuNiv3ID] = @SGMenuNiv3ID ORDER BY TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv2ID], TM1.[SGMenuNiv3ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P6", "SELECT [SGMenuPrograma] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P7", "SELECT [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGMENUNIV3] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P8", "SELECT TOP 1 [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGMENUNIV3] WHERE ( [SGMenuPrograma] > @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv1ID] > @SGMenuNiv1ID or [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv2ID] > @SGMenuNiv2ID or [SGMenuNiv2ID] = @SGMenuNiv2ID and [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv3ID] > @SGMenuNiv3ID) ORDER BY [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P9", "SELECT TOP 1 [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGMENUNIV3] WHERE ( [SGMenuPrograma] < @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv1ID] < @SGMenuNiv1ID or [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv2ID] < @SGMenuNiv2ID or [SGMenuNiv2ID] = @SGMenuNiv2ID and [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [SGMenuNiv3ID] < @SGMenuNiv3ID) ORDER BY [SGMenuPrograma] DESC, [SGMenuNiv1ID] DESC, [SGMenuNiv2ID] DESC, [SGMenuNiv3ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P10", "INSERT INTO [SGMENUNIV3]([SGMenuNiv3ID], [SGMenuNiv3Dsc], [SGMenuNiv3Link], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID]) VALUES(@SGMenuNiv3ID, @SGMenuNiv3Dsc, @SGMenuNiv3Link, @SGMenuPrograma, @SGMenuNiv1ID, @SGMenuNiv2ID)", GxErrorMask.GX_NOMASK,prmT000P10)
           ,new CursorDef("T000P11", "UPDATE [SGMENUNIV3] SET [SGMenuNiv3Dsc]=@SGMenuNiv3Dsc, [SGMenuNiv3Link]=@SGMenuNiv3Link  WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID", GxErrorMask.GX_NOMASK,prmT000P11)
           ,new CursorDef("T000P12", "DELETE FROM [SGMENUNIV3]  WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID", GxErrorMask.GX_NOMASK,prmT000P12)
           ,new CursorDef("T000P13", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID AND [SGMenuNiv3ID] = @SGMenuNiv3ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P14", "SELECT [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGMENUNIV3] ORDER BY [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P15", "SELECT [SGMenuPrograma] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P15,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
